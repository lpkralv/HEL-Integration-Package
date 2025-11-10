//#define OLD_STUFF 
//#define MYDEBUG         //Uncomment to output debugging info to the console.

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
using modsDictionary = System.Collections.Generic.Dictionary<string, Mod>;
using System.Globalization;

/// <summary>
/// HEL - HIOX EQUATION LANGUAGE
/// Core class for evaluating HIOX mod equations to modify game statistics.
/// Provides static methods for equation evaluation and processing without maintaining state.
/// All evaluation methods are stateless for thread safety and performance.
/// </summary>
/// <remarks>
/// The HEL system processes mod equations that can modify game stats through mathematical expressions.
/// Equations are tokenized, parsed, and executed against a stats dictionary to produce updated values.
/// Supports variable substitution, mathematical operations, and dependency resolution.
/// </remarks>
public class HEL {

    /// <summary>
    /// Evaluates the equations of player mods and returns updated statistics.
    /// Processes all mods in the provided dictionary.
    /// </summary>
    /// <param name=\"statsDict\">Dictionary of base statistics keyed by stat name</param>
    /// <param name=\"modsDict\">Dictionary of player's mods keyed by UUID</param>
    /// <returns>A new statistics dictionary containing the results after applying mod equations</returns>
    /// <exception cref=\"ArgumentException\">Thrown when mod equations contain syntax errors</exception>
    public static statsDictionary EvaluateMods(statsDictionary statsDict, modsDictionary modsDict) 
    {
        var baseStats = statsDict.ToDictionary(kvp => kvp.Key.ToUpper(), kvp => new Stat(kvp.Value)); //copy and upper case names
        var eqn_list = "";
        
        // Simple iteration through all mods in modsDict (now contains only player's mods)
        foreach (var mod in modsDict.Values) 
        {
            if (mod.equation != null) 
            {
                string eqn = PrepareEquation(mod);  // Clean up mod equations for later use.
                eqn_list += eqn + '\n';   // '\n' used to delimit EOLN for comments
            }
        }
        eqn_list += "$"; // EOF token

        return EvaluateEquation(eqn_list, baseStats);
    }

    /// <summary>
    /// Prepares a mod's equation for evaluation by performing variable substitutions and formatting.
    /// Replaces VAL, VAL1, and VAL2 references with actual mod values and adds necessary delimiters.
    /// </summary>
    /// <param name="mod">The mod containing the equation to prepare</param>
    /// <returns>A formatted equation string ready for tokenization and evaluation</returns>
    /// <example>
    /// For a mod with equation "S_HEALTH = S_HEALTH + VAL" and val=10, 
    /// returns "#!123;S_HEALTH = S_HEALTH + 10;" where 123 is the mod ID.
    /// </example>
    public static string PrepareEquation(Mod mod) {
        string eqn = Token.EncodeComment(mod.modid) + ';' + mod.equation.ToUpper() + ';';      //Prepare equation for processing
        eqn = eqn.Replace("VAL1", FormatFloat(mod.val));         //Replace reference to VAL1 with it's value
        eqn = eqn.Replace("VAL2", FormatFloat(mod.val2));        //Replace reference to VAL2 with it's value
        eqn = eqn.Replace("VAL",  FormatFloat(mod.val));         //Replace reference to VAL with it's value
        return eqn;
    }

    /// <summary>
    /// Formats a float value for use in HEL equations with proper precision and zero handling.
    /// Rounds to 7 decimal places and converts very small values to "0" to avoid precision issues.
    /// </summary>
    /// <param name="f">The float value to format</param>
    /// <returns>A string representation of the float suitable for equation substitution</returns>
    /// <example>
    /// FormatFloat(3.1415926535f) returns "3.1415927"
    /// FormatFloat(0.0000001f) returns "0"
    /// </example>
    public static string FormatFloat(float f)
    {
        f = (float)Math.Round(f, 7);  // round to 7 decimal places

        if (Math.Abs(f) < 1e-7f)
            return "0";

        return f.ToString("0.#######");
    }



    /// <summary>
    /// Evaluates a HEL equation string against a statistics dictionary and returns updated statistics.
    /// Tokenizes the input, interprets the tokens, and applies the operations to produce new stat values.
    /// </summary>
    /// <param name="input">The HEL equation string to evaluate (can contain multiple statements)</param>
    /// <param name="stats">The base statistics dictionary to operate on</param>
    /// <returns>A new statistics dictionary with updated values after equation evaluation</returns>
    /// <exception cref="ArgumentException">Thrown when the equation string contains syntax errors</exception>
    /// <exception cref="InvalidOperationException">Thrown when evaluation encounters runtime errors</exception>
    public static statsDictionary EvaluateEquation(string input, statsDictionary stats) {

        //Tokenize the equation
        List<Token> tokens = new HELLexer(input).Tokenize(); 

        statsDictionary tempStats = Interpreter.Interpret(tokens, stats);

        #if MYDEBUG            
            Console.WriteLine("\nBASE STATS:");
            foreach (Stat stat in stats.Values) {
                Console.WriteLine($"STAT: {stat.name} = {stat.value}");
            }

            Console.WriteLine("\nOUTPUT STATS:");
            foreach (Stat stat in tempStats.Values) {
                Console.WriteLine($"STAT: {stat.name} = {stat.value}");
            }
        #endif       

        return tempStats;
    }
    

// BELOW HERE IS OLD CODE THAT LOADED MODS/STATS INTO OBJECT VARS
// AND KEPT IT AROUND BETWEEN CALLS. CURRENTLY, EVERYTHING IS
// STATIC, SO NOTHING HANGS AROUND BETWEEN CALLS. KEEPING THIS
// CODE ONLY IN CASE LOADING FROM MOD/STAT ASSET FILES OR 
// LISTS IS NEEDED IN FUTURE. 
// IT IS NOT COMPILED UNLESS "OLD_STUFF" IS DEFINED, SO IT CAN BE IGNORED OR DELETED

#if OLD_STUFF
    /// <summary>
    /// Base stats, as found in the stats asset file. 
    /// </summary>
    private statsDictionary baseStats;
    
    /// <summary>
    /// Mods catalog, as found in the mods asset file.
    /// </summary>
    private modsDictionary baseMods;

    /// <summary>
    /// List of IDs for the mods owned by the player.
    /// </summary>
    private List<int> playerMods = [];

    /// <summary>
    ///  CONSTRUCTOR - provide current mods and stats dictionaries.
    /// </summary>
    /// <param name="statsDict">Dictionary of base stats (as in stats asset file) keyed by name</param>
    /// <param name="modsDict">Dictionary of all mods (as in mods asset file) keyed by mod ID</param>
    /// <param name="playerModIDs">Optional list of mod IDs owned by the player. Default is NO mods</param>
    public HEL(statsDictionary statsDict, modsDictionary modsDict, List<int>? playerModIDs=default) {
        var baseStats = statsDict.ToDictionary(kvp => kvp.Key.ToUpper(), kvp => kvp.Value); //copy and upper case names
        baseMods = new modsDictionary(modsDict);
        playerMods = (playerModIDs != default) ? playerModIDs : new List<int>();
    }

    /// <summary>
    /// CONSTRUCTOR - provide paths to mods and stats asset files.
    /// </summary>
    /// <param name="statsPath">Path to stats asset JSON file</param>
    /// <param name="modsPath">Path to mods asset JSON file</param>
    /// <param name="playerModIDs">Optional list of mod IDs owned by the player. Default or null means NO mods.</param>
     public HEL(string statsPath, string modsPath, List<int> playerModIDs=null!) {
        var tempStats = (statsDictionary) HELYAMLFile.LoadAsset(statsPath, "stats:").Item1;
        baseStats = tempStats.ToDictionary(kvp => kvp.Key.ToUpper(), kvp => kvp.Value); //copy and upper case names
        var tempMods = (modsDictionary) HELYAMLFile.LoadAsset(modsPath, "mods:").Item1;
        baseMods = tempMods.ToDictionary(kvp => kvp.Key, kvp => kvp.Value); //copy and upper case names
        playerMods = (playerModIDs is not null) ? playerModIDs : new List<int>();
    }

    /// <summary>
    /// Add mod to player's inventory by ID
    /// </summary>
    /// <param name="ID">ID of the mod to add</param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void AddMod(int ID) {
        if (!baseMods.ContainsKey(ID)) {
            throw new KeyNotFoundException($"The mod ID '{ID}' was not found.");
        }
        playerMods.Add(ID);
    }

    /// <summary>
    /// Add mod to player's inventory by name
    /// </summary>
    /// <param name="name">Name of the mod to add</param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void AddMod(string name) {
        // Find the ID of the named mod
        int theID = -123456789;
        foreach (var id in baseMods.Keys) {
            if (baseMods[id].name == name) {
                theID = id;
                break;
            }
        }

        if (theID == -123456789) {
            throw new KeyNotFoundException($"The mod named '{name}' was not found.");
        }
        playerMods.Add(theID);
    }    

    /// <summary>
    /// Remove ALL mods from player's inventory 
    /// </summary>
    public void ClearAllMods() {
        playerMods.Clear();
    }

    /// <summary>
    /// Remove mod from player's inventory by ID
    /// </summary>
    /// <param name="ID">ID of the mod to remove</param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void DelMod(int ID) {
        if (!playerMods.Remove(ID)) {
            throw new KeyNotFoundException($"Player mod ID '{ID}' not found.");
        }
    }

    /// <summary>
    /// Remove mod to player's inventory by name
    /// </summary>
    /// <param name="name">Name of the mod to remove</param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void DelMod(string name) {
        // Find the ID of the named mod
        bool found = false;
        foreach (var id in playerMods) {
            if (baseMods[id].name == name) {
                playerMods.Remove(id);
                found = true;
                break;
            }
        }

        if (!found) {
            throw new KeyNotFoundException($"Player mod named '{name}' not found.");
        }
    }    
#endif

}