/*  HELCSVFile.cs

    This class loads and saves the ".asset" files in CSV format. 
    It is used by the Editor, but is NOT needed for HEL evaluation.
*/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
using modsDictionary = System.Collections.Generic.Dictionary<string, Mod>;

public class HELCSVFile
{
    /// <summary>
    /// Loads a CSV asset file and returns a tuple containing either ModsData or StatsData dictionary.
    /// For mods data, returns (modsDictionary, null). For stats data, returns (statsDictionary, statsOrder).
    /// </summary>
    /// <param name="filePath">The path to the CSV file to load</param>
    /// <param name="assetType">Asset type identifier - should start with "m" for mods, otherwise treated as stats</param>
    /// <returns>
    /// A tuple where the first element is either a modsDictionary or statsDictionary,
    /// and the second element is null for mods or a List&lt;string&gt; statsOrder for stats
    /// </returns>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist</exception>
    /// <exception cref="Exception">Thrown when the CSV file is empty or missing data</exception>
    /// <exception cref="FormatException">Thrown when parsing numeric values fails</exception>
    /// <exception cref="IndexOutOfRangeException">Thrown when CSV fields are missing</exception>
    public static (object, object?) LoadAsset(string filePath, string assetType)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("CSV file not found.", filePath);

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length < 2)
            throw new Exception("CSV file is empty or missing data.");

        // First line is header; data lines follow.
        if (assetType.ToLower().StartsWith("m"))
        {
            // Load mods data.
            modsDictionary modsDict = new modsDictionary();
            // Expected header order:
            // modid,val,val2,val1min,val1max,val2min,val2max,name,desc,type,hasProc,equation,
            // modColor_r,modColor_g,modColor_b,modColor_a,armorEffectName,armorMeshName
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = ParseCsvLine(line);
                Mod mod = new Mod
                {
                    modid = int.Parse(fields[0]),
                    val = float.Parse(fields[1]),
                    val2 = float.Parse(fields[2]),
                    val1min = float.Parse(fields[3]),
                    val1max = float.Parse(fields[4]),
                    val2min = float.Parse(fields[5]),
                    val2max = float.Parse(fields[6]),
                    modweight = int.Parse(fields[7]),
                    name = fields[8],
                    desc = fields[9],
                    type = int.Parse(fields[10]),
                    hasProc = int.Parse(fields[11]),
                    equation = fields[12],
                    modColor = new ModColor
                    {
                        r = int.Parse(fields[13]),
                        g = int.Parse(fields[14]),
                        b = int.Parse(fields[15]),
                        a = int.Parse(fields[16])
                    },
                    armorEffectName = fields[17],
                    armorMeshName = fields[18]
                };

                modsDict[mod.uuid] = mod;
            }
            return (modsDict, null);
        }
        else
        {
            // Load stats data.
            statsDictionary statsDict = new statsDictionary();
            List<string> statsOrder = new List<string>();
            // Expected header order: name,desc,value,min,max
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(',');
                Stat stat = new Stat
                {
                    name = fields[0],
                    displayname = fields.Length > 5 ? fields[5] : fields[0], // Use displayname if available, fallback to name  
                    desc = fields[1],
                    value = float.Parse(fields[2]),
                    min = float.Parse(fields[3]),
                    max = float.Parse(fields[4]),
                    persistent = fields.Length > 6 ? bool.Parse(fields[6]) : false
                };

                statsDict[stat.name] = stat;
                statsOrder = (List<string>) statsOrder.Append(stat.name);
            }
            return (statsDict, statsOrder);
        }
    }

    /// <summary>
    /// Serializes a dictionary of ModsData or StatsData into CSV format and writes it to a file.
    /// If assetObj is a modsDictionary then a mods CSV is generated;
    /// if it's a statsDictionary then a stats CSV is generated.
    /// </summary>
    /// <param name="filePath">The path where the CSV file will be written</param>
    /// <param name="assetObj">Either a modsDictionary or statsDictionary to serialize</param>
    /// <exception cref="DirectoryNotFoundException">Thrown when the directory path does not exist</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file path is denied</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs during file writing</exception>
    public static void WriteAsset(string filePath, object assetObj)
    {
        List<string> csvLines = new List<string>();

        if (assetObj is modsDictionary modsDict)
        {
            // CSV Header for mods
            csvLines.Add("modid,val,val2,val1min,val1max,val2min,val2max,modweight,name,desc,type,hasProc,equation,modColor_r,modColor_g,modColor_b,modColor_a,armorEffectName,armorMeshName");

            foreach (var mod in modsDict.Values)
            {
                var fields = new[]
                {
                    mod.modid.ToString(),
                    mod.val.ToString(),
                    mod.val2.ToString(),
                    mod.val1min.ToString(),
                    mod.val1max.ToString(),
                    mod.val2min.ToString(),
                    mod.val2max.ToString(),
                    mod.modweight.ToString(),
                    EscapeCsvField(mod.name),
                    EscapeCsvField(mod.desc),
                    mod.type.ToString(),
                    mod.hasProc.ToString(),
                    EscapeCsvField(mod.equation),
                    mod.modColor.r.ToString(),
                    mod.modColor.g.ToString(),
                    mod.modColor.b.ToString(),
                    mod.modColor.a.ToString(),
                    EscapeCsvField(mod.armorEffectName),
                    EscapeCsvField(mod.armorMeshName)
                };

                csvLines.Add(string.Join(",", fields));
            }
        }
        else if (assetObj is statsDictionary statsDict)
        {
            // CSV Header for stats
            csvLines.Add("name,desc,value,min,max");

            foreach (var stat in statsDict.Values)
            {
                var fields = new[]
                {
                    EscapeCsvField(stat.name),
                    EscapeCsvField(stat.desc),
                    stat.value.ToString(),
                    stat.min.ToString(),
                    stat.max.ToString()
                };

                csvLines.Add(string.Join(",", fields));
            }
        }
        else
        {
            Console.WriteLine("ERROR: Bad object sent to WriteAsset.");
            return;
        }

        File.WriteAllLines(filePath, csvLines);
    }

    /// <summary>
    /// Escapes special characters in CSV fields by wrapping them in quotes and escaping internal quotes.
    /// Fields containing commas, quotes, or newlines will be wrapped in double quotes.
    /// Internal double quotes are escaped by doubling them.
    /// </summary>
    /// <param name="field">The field value to escape, can be null</param>
    /// <returns>The escaped field value, or the original value if no escaping is needed</returns>
    private static string? EscapeCsvField(string field)
    {
        if (field is not null && (field.Contains(',') || field.Contains('"') || field.Contains('\n')))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    /// <summary>
    /// Parses a CSV line handling quoted fields that may contain commas, quotes, or newlines.
    /// Properly handles escaped quotes (double quotes within quoted fields).
    /// </summary>
    /// <param name="line">The CSV line to parse</param>
    /// <returns>An array of field values extracted from the CSV line</returns>
    /// <example>
    /// ParseCsvLine("name,\"description with, comma\",123") returns ["name", "description with, comma", "123"]
    /// </example>
    private static string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool insideQuotes = false;
        string currentField = "";

        foreach (char c in line)
        {
            if (c == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        fields.Add(currentField);

        // Remove surrounding quotes and unescape inner quotes
        for (int i = 0; i < fields.Count; i++)
        {
            string field = fields[i];
            if (field.StartsWith("\"") && field.EndsWith("\""))
            {
                field = field.Substring(1, field.Length - 2).Replace("\"\"", "\"");
            }
            fields[i] = field;
        }

        return fields.ToArray();
    }
}
