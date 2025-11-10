#define MYDEBUG

using System.Linq;
using System.ComponentModel;
using System.Data;

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
using modsDictionary = System.Collections.Generic.Dictionary<string, Mod>;
using YamlDotNet.Serialization.ObjectGraphTraversalStrategies;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Immutable;


//Compile and analyze Mods
public partial class HIOXModEditor : Form
{
    private void InitializeAnalysis() {}

    private void CheckAllMods()
    {
        int errct = 0;

        // Assuming modsDict is a modsDictionary
        foreach (var kvp in modsDict.OrderBy(kvp => kvp.Key))
        {
            modsDictionary singleModDict = new modsDictionary { { kvp.Key, kvp.Value } };
            try {
                HEL.EvaluateMods(statsDict, singleModDict);
            } catch (Exception ex)
            {
                errct++;
                WriteMessage($"ERROR: ({kvp.Key}) {ex.Message}", Color.Red);
            }
        }
        WriteMessage($"Mod Check Complete. {errct} errors found.");
    }

    private void EvaluateSelectedMods()
    {
        statsDictionary tempStats;
        statsDictionary baseStats;

        //Randomize VAL and VAL2 for simulation
        modsDict = AssignVal1Val2(modsDict);

        // Always compare against base stats (no mods) to show full delta
        try {
            baseStats = HEL.EvaluateMods(statsDict, new modsDictionary()); // Evaluate with no mods
        } catch (Exception ex) {
            WriteMessage($"ERROR evaluating base stats: {ex.Message}", Color.Red);
            return;
        }

        // Tell Interpreter to add the selected mods to the player mods (equip them)
        modsDictionary evalMods = CreateEvaluationModsDictFromEquipped();
        foreach (var kvp in markIndices) {
            // Find mod by modid and add it using its uuid
            var mod = modsDict.Values.FirstOrDefault(m => m.modid == kvp.Key);
            if (mod != null) {
                evalMods[mod.uuid] = mod;
            }
        }

        try {
            tempStats = HEL.EvaluateMods(statsDict, evalMods); // Evaluate all equipped and selected mods
        } catch (Exception ex)
        {
            WriteMessage($"ERROR in Selected MODs: {ex.Message}", Color.Red);
            return;
        }

        WriteMessage($"Stats evaluates Equipped MODs + Selected MODs.\r\nDeltas shown from base stats.");
        DisplayStats(tempStats, baseStats);
        previousStats = tempStats;
    }

    /// <summary>
    /// Simulate random MOD selection from the "modweight" distribution for many trials.
    /// Evaluate and record the Stat deltas from the most recent MOD addition. 
    /// When complete, analyze the results into the format needed for box-and-whiskers graphs
    /// describing the effect of each MOD on the Stats.
    /// NOTE: Assume the initial weapons are 500 and 800. Newly selected weapons replace old ones.
    /// </summary>
    private void AnalyzeAllMods()
    {
        // Constants control depth of the analysis. Time is proportional to MAXTRIALS * MAXMODS.
        // Approx. 0.00021 seconds per inner loop.
        const int MAXTRIALS = 10000;
        int MAXMODS = 50;  //Math.Min(50, MaxNonWeaponMods());

        // Relevant values from the input data are extracted here
        WriteMessage("A");
        List<string> statNames = statsDict.Keys.ToList();
        List<string> modUUIDs = modsDict.Keys.ToList();
        List<int> modIDs = modsDict.Values.Select(m => m.modid).ToList();
        List<int> modWeights = GetModWeights();
        List<int> modCounts = Enumerable.Repeat(0, modIDs.Count).ToList();

        WriteMessage("B");

        // Result data points are immediately converted into incremental statistics by PointwiseDataCollector. 
        // Results are collected for every (MOD, STAT) combination. This means that we can run for any number
        // of trials without worrying about memory.
        Dictionary<Tuple<int, string>, PointwiseDataCollector> results = new Dictionary<Tuple<int, string>, PointwiseDataCollector>();
        foreach (int mid in modIDs) {
            foreach (string snm in statNames) {
                var tup = new Tuple<int, string>(mid, snm);
                results[tup] = new PointwiseDataCollector();
            }
        }

        WriteMessage("C");

        //Initialize a MOD picker (selects from modweight distribution)
        HELPicker picker = new HELPicker(modWeights);

        WriteMessage("D");

        WriteMessage($"Beginnning Analaysis... ({MAXTRIALS} trials, {MAXMODS} mods)");
        int seconds = (int) Math.Round(0.0000755f * (double) MAXTRIALS * (double) MAXMODS);
        int minutes = seconds / 60;
        seconds -= minutes * 60;
        WriteMessage($"Estimated time: {minutes:D2}:{seconds:D2}");
        for (int trial = 1; trial <= MAXTRIALS; trial++) {
            if (trial % 100 == 0)
                WriteMessage($"{trial} ~");
            if (trial > 1 && trial % 1001 == 0)
                WriteMessage(" ");

            //Randomize VAL and VAL2 for simulation
            modsDict = AssignVal1Val2(modsDict);

            //Initialize each trial mod list
            Dictionary<int, int> equippedMods = new Dictionary<int, int>{{500, 1}, {800, 1}}; //initial weapons only

            //Evaluate initial stats
            modsDictionary initialMods = CreateEvaluationModsDict(equippedMods);
            statsDictionary prevStats = HEL.EvaluateMods(statsDict, initialMods);
            List<float> prevStatVals = prevStats.Select(stat => stat.Value.value).ToList();
            statsDictionary newStats;
            for (int mct = 0; mct < MAXMODS; /*increment below*/) {
                //Select a MOD and prepare for analysis
                int pickedMod = picker.Sample();   //returns mod position in modIDs;
                int lastMod = modIDs[pickedMod]; //modIDs and PickedMod are 0-based
                modCounts[pickedMod]++;

                //Equip lastMod
                var selectedMod = modsDict.Values.FirstOrDefault(m => m.modid == lastMod);
                int modType = selectedMod?.type ?? 0;
                if (modType == 2 || modType == 4) {   //It's a weapon
                    ReplaceWeapon(modType, lastMod, equippedMods);
                } else {
                    equippedMods[lastMod] = 1;
                    mct++;
                }
               
                //Analyze the effect of lastMod
                modsDictionary currentMods = CreateEvaluationModsDict(equippedMods);
                newStats = HEL.EvaluateMods(statsDict, currentMods);

                foreach (string sname in statNames) {
                    Tuple<int, string> tup = new Tuple<int, string>(lastMod, sname);
                    results[tup].Add(newStats[sname].value - previousStats[sname].value);
                }
                prevStats = newStats;
            }
        }
        WriteMessage(" ");
        WriteMessage("Data Collection Complete. Generating output...");
        #if MYDEBUG
            Console.WriteLine("MOD Distribution");
            for (int i=0; i <modCounts.Count; i++) {
                Console.WriteLine($"{modIDs[i]} \t{modCounts[i]}");
            }
        #endif

        //Write out the results in a meaningful way
        List<string> probs = IdentifyProbStats();
        Dictionary<Tuple<int, string>, double []> dresults = ExtractResults(modIDs, statNames, results);
        var baselines = BaselineCalculator.CalculateStatistics(dresults, statNames, modIDs);
        WriteBaselines(baselines);
        WriteResults(modIDs, statNames, baselines, dresults, probs);
    }

    public modsDictionary AssignVal1Val2(modsDictionary mDict)
    {
        modsDictionary tempModsDict = new modsDictionary(mDict); //shallow copy
        Random random = new Random();
        foreach (Mod mod in tempModsDict.Values) {
            //Randomize VAL and VAL2 for simulation
            mod.val = mod.val1min + (float)random.NextDouble() * (mod.val1max - mod.val1min);
            mod.val2 = mod.val2min + (float)random.NextDouble() * (mod.val2max - mod.val2min);
            if (Math.Abs(mod.val) < 1e-7)
                mod.val = 0;
            if (Math.Abs(mod.val2) < 1e-7)
                mod.val2 = 0;
        }

        return tempModsDict;
    }

     /// <summary>
    /// Return a list of STAT names of the probability stats (min==0, max==1)
    /// </summary>
    /// <returns></returns>
    public List<string> IdentifyProbStats() {
        List<string> probs = new List<string>();
        foreach (string s in statsDict.Keys){
            Stat stat = statsDict[s];
            if (stat.min == 0.0f && stat.max == 1.0f) 
                probs.Add(s);
        }
        return probs;
    }

    /// <summary>
    /// Extract the Box Plot Stats (double []) from the Pointwise Data Collectors
    /// </summary>
    /// <param name="modIDs">List of MOD IDs in 'results'</param>
    /// <param name="statNames">List of STAT Names in 'results'</param>
    /// <param name="results">Dictionary of PointwiseDataCollectors keyed by (modID, statName)</param>
    /// <returns></returns>
    public Dictionary<Tuple<int, string>, double []> ExtractResults(List<int> modIDs, 
                                                        List<string> statNames,
                                                        Dictionary<Tuple<int, string>, PointwiseDataCollector> results) {

        Dictionary<Tuple<int, string>, double []> dresults = new Dictionary<Tuple<int, string>, double []>();                                                 
        foreach (int mid in modIDs) {
            //Extract the float array results for all stats
            foreach (string sname in statNames) {
                Tuple<int, string> tup = new Tuple<int, string>(mid, sname);
                double[] row = results[tup].GetBoxPlotStats();
                //if (row[0] != 0.0f || row[4] != 0.0f)   -- No idea why this was there
                dresults[tup] = row;
            }
        }                                                    
        return dresults;
    }

    public void WriteResults(List<int> modIDs, 
                            List<string> statNames, 
                            Dictionary<string, BaselineResult> baselines,
                            Dictionary<Tuple<int, string>, double []> dresults, 
                            List<string> probs) 
    {
        foreach (int mid in modIDs) {
            var mod = modsDict.Values.FirstOrDefault(m => m.modid == mid);
            Console.WriteLine($"----------- {mid}  {mod?.name ?? "Unknown"} -----------");

            //Sort the resulting stats by mean value
            List<string> sortedKeys = dresults
                .Where(kvp => kvp.Key.Item1 == mid && kvp.Value.Length > 6 && kvp.Value[6] != 0) // ensure safe indexing and no divide-by-zero
                .OrderByDescending(kvp => kvp.Value[5] / kvp.Value[6])
                .Select(kvp => kvp.Key.Item2) // extract the string part of the Tuple<int, string>
                .ToList();

            foreach (string sname in sortedKeys) {
                Tuple<int, string> tup = new Tuple<int, string>(mid, sname);
                double [] row = dresults[tup];
                // output the row (send to CSV)
                double mean = row[5]/row[6];
                double baseline = baselines[sname].Mean;
                double sd = baselines[sname].StdDev;
                double delta = mean - baseline;
                if (delta < -sd  || delta > sd) {
                    Console.Write($"{mid:D4} {sname,24} \t");
                    if (probs.Contains(sname))
                        Console.WriteLine($"DELTA:{100*delta:F2}% SD:{100*sd:F2}%  MEAN:{100*mean:F2}%  MEDIAN:{100*row[2]:F2}%  1Q:{100*row[1]:F2}%  3Q:{100*row[3]:F2}%" +
                                            $"  MIN:{100*row[0]:F2}%  MAX:{100*row[4]:F2}%  COUNT:{row[6]:F0}");
                    else
                        Console.WriteLine($"DELTA:{delta:F2} SD:{sd:F2}  MEAN:{mean:F2}  MEDIAN:{row[2]:F2}  1Q:{row[1]:F2}  3Q:{row[3]:F2}" +
                                            $"  MIN:{row[0]:F2}  MAX:{row[4]:F2}  COUNT:{row[6]:F0}");
                } else {
                        //Console.Write($"{mid:D4} {sname,24} \t");
                        //Console.WriteLine($"XXX DELTA:{delta:F2}+/-{sd:F2}  MEAN:{mean:F2}  MEDIAN:{row[2]:F2}  1Q:{row[1]:F2}  3Q:{row[3]:F2}" +
                        //                    $"  MIN:{row[0]:F2}  MAX:{row[4]:F2}  COUNT:{row[6]:F0}");
                }
            }
        }
        WriteMessage("Analysis Complete.");
    }

    public void WriteBaselines(Dictionary<string, BaselineResult> baselines)
    {
        Console.WriteLine($"------------------- BASELINE -------------------");
        List<string> sortedNames = baselines.Keys.ToList();
        sortedNames.Sort();
        foreach (string sname in baselines.Keys) {
            Console.WriteLine($"{sname,24}  MEAN:{baselines[sname].Mean:F2}  SD:{baselines[sname].StdDev:F2}");
        }
    }

    /// <summary>
    /// Replace modweight values for some MODs to improve the simulation. Specifically:
    ///     500, 800: These starting weapons have 0 modweight. But we do want to test how they 
    ///                 interact with other mods. So we bump them up to 10.
    ///     6000+   : These MODs are purchased in the interface, so modweights are actually
    ///                 prices. We give these modweights of 10 to simulate probability of 
    ///                 purchase.
    /// NOTE: This is just for simulation. These changes are not for use in the game.
    /// </summary>
    /// <returns></returns>
    public List<int> GetModWeights()
    {
        List<int> modWeights = new List<int>();
        List<int> special = new List<int> {500, 503, 505, 800};

        foreach (Mod mod in modsDict.Values) {
            if (special.Contains(mod.modid) || (mod.modid >= 6000 && mod.modid < 7000)) {
                modWeights.Add(5);
            } else
                modWeights.Add(mod.modweight);
        }
        
        return modWeights;
    }

    //Modify 'modLIst' to replace any mod of 'type' with 'modID'.
    //All done via side-effects rather than function results. Bad Zoot.
    public void ReplaceWeapon(int type, int modID, Dictionary<int, int> modInventory)
    {
        foreach (int mid in modInventory.Keys.ToList()) {
            var mod = modsDict.Values.FirstOrDefault(m => m.modid == mid);
            if (mod != null && mod.type == type) {
                modInventory.Remove(mid);
                modInventory[modID] = 1;
                return;
            }
        }
        //No weapon of this type found, add the new one
        modInventory[modID] = 1;
    }

    public int MaxNonWeaponMods()
    {
        int count = 0;
        List<Mod> ml = modsDict.Values.ToList();
        for (int m=0; m < modsDict.Count; m++) {
            int type = ml[m].type;
            if (type != 2 && type != 4) 
                count++;
        }
        return count;
    }

    
    /// <summary>
    /// Generate summary statistics incrementally, for each new data point.
    /// Will require one of these for every MOD/STAT combination.
    /// </summary>
    public class PointwiseDataCollector
    {
        P2QuantileEstimator estimator = new P2QuantileEstimator();
        double min = double.MaxValue;
        double max = double.MinValue;
        double sum = 0;
        int count = 0;

        public PointwiseDataCollector()
        {}

        public void Add(double x)
        {
            estimator.Add(x);
            if (x < min) min = x;
            if (x > max) max = x;
            sum += x;
            count++;
        }

        public double[] GetBoxPlotStats()
        {
            return new double[]
            {
                min,
                estimator.Q1,
                estimator.Median,
                estimator.Q3,
                max,
                sum,        //BoxPlot actually wants sum / count
                count
            };
        }

        /// <summary>
        /// This class estimates the Median and Quartile statistics needed by a box-and-whiskers plot
        /// given data points one at a time. This means we don't need to store a huge table of data 
        /// and then compute statistics, afterward. Both adding data and retrieving result are O(1).
        /// </summary>
        private class P2QuantileEstimator
        {
            private readonly double[] q = new double[5];  // marker heights
            private readonly int[] n = new int[5];        // marker positions
            private readonly double[] np = new double[5]; // desired positions
            private readonly double[] dn = new double[5]; // increments
            private int count = 0;

            public double Q1 => q[1];
            public double Median => q[2];
            public double Q3 => q[3];

            public void Add(double x)
            {
                if (count < 5)
                {
                    q[count++] = x;
                    if (count == 5)
                    {
                        Array.Sort(q);
                        for (int i = 0; i < 5; i++) n[i] = i + 1;
                        np[0] = 1; np[1] = 1 + 0.25 * (count - 1);
                        np[2] = 1 + 0.5 * (count - 1);
                        np[3] = 1 + 0.75 * (count - 1);
                        np[4] = 5;
                        for (int i = 0; i < 5; i++) dn[i] = new[] { 0, 0.25, 0.5, 0.75, 1 }[i];
                    }
                    return;
                }

                int k;
                if (x < q[0]) { q[0] = x; k = 0; }
                else if (x < q[1]) k = 0;
                else if (x < q[2]) k = 1;
                else if (x < q[3]) k = 2;
                else if (x < q[4]) k = 3;
                else { q[4] = x; k = 3; }

                for (int i = k + 1; i < 5; i++) n[i]++;
                for (int i = 0; i < 5; i++) np[i] += dn[i];

                for (int i = 1; i < 4; i++)
                {
                    double d = np[i] - n[i];
                    if ((d >= 1 && n[i + 1] - n[i] > 1) || (d <= -1 && n[i - 1] - n[i] < -1))
                    {
                        int dsign = Math.Sign(d);
                        double qd = Parabolic(i, dsign);
                        if (q[i - 1] < qd && qd < q[i + 1])
                            q[i] = qd;
                        else
                            q[i] = Linear(i, dsign);
                        n[i] += dsign;
                    }
                }

                count++;
            }

            private double Parabolic(int i, int d)
            {
                double a = d, n0 = n[i - 1], n1 = n[i], n2 = n[i + 1];
                double q0 = q[i - 1], q1 = q[i], q2 = q[i + 1];
                return q1 + a / (n2 - n0) * ((n1 - n0 + a) * (q2 - q1) / (n2 - n1) + (n2 - n1 - a) * (q1 - q0) / (n1 - n0));
            }

            private double Linear(int i, int d)
            {
                return q[i] + d * (q[i + d] - q[i]) / (n[i + d] - n[i]);
            }
        }
    }

    public struct BaselineResult
    {
        public double Mean { get; }
        public double StdDev { get; }

        public BaselineResult(double mean, double stddev)
        {
            Mean = mean;
            StdDev = stddev;
        }
    }

    /// <summary>
    /// Helper method to create a UUID-keyed mod dictionary for evaluation.
    /// Takes a dictionary of modid->count and returns a dictionary of uuid->Mod
    /// containing only mods with count > 0.
    /// </summary>
    /// <param name="modInventory">Dictionary of modid to count</param>
    /// <returns>Dictionary of uuid to Mod for evaluation</returns>
    private modsDictionary CreateEvaluationModsDict(Dictionary<int, int> modInventory)
    {
        modsDictionary evalMods = new modsDictionary();
        foreach (var kvp in modInventory)
        {
            if (kvp.Value > 0)
            {
                // Find mod by modid and add it using its uuid
                var mod = modsDict.Values.FirstOrDefault(m => m.modid == kvp.Key);
                if (mod != null)
                {
                    evalMods[mod.uuid] = mod;
                }
            }
        }
        return evalMods;
    }

    /// <summary>
    /// Helper method to create a UUID-keyed mod dictionary from playerEquippedMods.
    /// </summary>
    /// <returns>Dictionary of uuid to Mod for evaluation</returns>
    private modsDictionary CreateEvaluationModsDictFromEquipped()
    {
        return new modsDictionary(playerEquippedMods);
    }

    public class BaselineCalculator
    {
 
        public static Dictionary<string, BaselineResult> CalculateStatistics(
            Dictionary<Tuple<int, string>, double[]> inResults,
            List<string> statNames,
            List<int> modIDs)
        {
            var result = new Dictionary<string, BaselineResult>();

            foreach (var statName in statNames)
            {
                double sum = 0;
                double sumSq = 0;
                int count = 0;

                foreach (var modID in modIDs)
                {
                    var key = Tuple.Create(modID, statName);
                    if (inResults.TryGetValue(key, out var values))
                    {
                        double mean = 0.0f;
                        if (values[6] != 0.0f)
                        mean = values[5]/values[6];
                        sum += mean;
                        sumSq += mean * mean;
                        count++;
                    }
                }

                var statResults = new BaselineResult();
                for (int i = 0; i < 6; i++)
                {
                    if (count > 0)
                    {
                        double mean = sum / count;
                        double variance = (sumSq / count) - (mean * mean);
                        double stddev = Math.Sqrt(variance);
                        statResults = new BaselineResult(mean, stddev);
                    }
                    else
                    {
                        statResults = new BaselineResult(double.NaN, double.NaN);
                    }
                }

                result[statName] = statResults;
            }

            return result;
        }
    }

}