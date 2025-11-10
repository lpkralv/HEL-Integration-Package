/*  HELYAMLFile.cs

    This class loads and saves the ".asset" files in YAML format. 
    It is used by the Editor. It can be used by the HEL class to
    load assets, but by default it is not configured to do so.
    Otherwise, this file is not needed for HEL evaluation.
*/

//#define MYDEBUG       //Comment this line to turn off debugging

using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.CodeDom;

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
using modsDictionary = System.Collections.Generic.Dictionary<string, Mod>;

/// <summary>
/// Handles loading and saving of asset files in YAML format for the HEL system.
/// Supports both mod and stat data serialization/deserialization using YamlDotNet.
/// Used primarily by the Editor but can also be used by the HEL class for asset loading.
/// </summary>
public class HELYAMLFile
{
    
    /// <summary>
    /// Initializes a new instance of the HELYAMLFile class.
    /// Use the static LoadAsset() method to load YAML asset files.
    /// </summary>
    public HELYAMLFile() {}
    
    /// <summary>
    /// Loads a YAML asset file and returns the appropriate data structure based on the root node type.
    /// If root starts with 'm', loads as mods data. Otherwise, loads as stats data.
    /// </summary>
    /// <param name="path">The file path to the YAML asset file</param>
    /// <param name="root">The name of the root node in the YAML file</param>
    /// <returns>
    /// A tuple where the first element is either a modsDictionary or statsDictionary,
    /// and the second element is null for mods or a List&lt;string&gt; statsOrder for stats
    /// </returns>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist</exception>
    /// <exception cref="YamlException">Thrown when YAML parsing fails</exception>
    public static (object, object?) LoadAsset(string path, string root) {

        ModsList modsData;
        StatsList statsData;

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("The specified file was not found.", path);
        }
        
        string yaml = GetYAMLContent(path, root);
        #if MYDEBUG            
            Console.WriteLine($"Path: {path}");
            Console.WriteLine($"Root: {root}");
            Console.WriteLine(yaml);
            Console.WriteLine("--END OF ASSET--");
        #endif
        
        // Build the deserializer
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        // Deserialize the YAML string into ModsData
        if (root[0] == 'm') {
            modsData = deserializer.Deserialize<ModsList>(yaml);
            return (modsData.mods.ToDictionary(mod => mod.uuid), null);
        } else {
            statsData = deserializer.Deserialize<StatsList>(yaml);

            // Create an ordered list of modIDs representing the original load order.
            List<string> statsOrder = statsData.stats.Select(stat => stat.name).ToList();

            return (statsData.stats.ToDictionary(stat => stat.name), statsOrder);
        }

    }

    /// <summary>
    /// Extracts YAML content from an asset file starting at the specified node name.
    /// Processes the file to remove headers and format the content for deserialization.
    /// </summary>
    /// <param name="filePath">The path to the YAML file to read</param>
    /// <param name="nodename">The name of the node where YAML content extraction should begin</param>
    /// <returns>The extracted YAML content as a string, starting from the specified node</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file cannot be read</exception>
    /// <exception cref="ArgumentException">Thrown when the specified node name is not found</exception>
    private static string GetYAMLContent(string filePath, string nodename)
    {
        string[] lines = File.ReadAllLines(filePath);
        StringBuilder contentBuilder = new();

        bool firstLine = true;

        foreach (var line in lines)
        {
            if (line.Contains(":"))
            {
                if (!firstLine)
                {
                    contentBuilder.AppendLine();
                }
                contentBuilder.Append(line);
            }
            else
            {
                contentBuilder.Append(line);
            }
            firstLine = false;
        }

        string content = contentBuilder.ToString();
        int index = content.IndexOf(nodename);

        return content.Substring(index);
    }

    /// <summary>
    /// Serializes a dictionary of ModsData or StatsData back into YAML format and writes it to the specified file.
    /// Includes Unity-specific YAML headers and metadata. The dictionary keys are of type int (modid) for ModsData 
    /// and type string (name) for StatsData.
    /// </summary>
    /// <param name="filePath">The file path where the YAML asset will be written</param>
    /// <param name="assetObj">Either a modsDictionary or statsDictionary to serialize</param>
    /// <exception cref="DirectoryNotFoundException">Thrown when the directory path does not exist</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access to the file path is denied</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs during file writing</exception>
    public static void WriteAsset(string filePath, object assetObj)
    {
        // Build the YAML serializer using the same CamelCaseNamingConvention.
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        // Reconstruct the ModsData or statsData container.
        string yaml = "ERROR in YAML serialization.";
        ModsList modsData;
        StatsList statsData;
        string guidStr;
        
        if (assetObj is modsDictionary modsDict) {
            modsData = new ModsList
            {
                mods = modsDict.Values.ToList()
            };

            // Serialize the object to a YAML string.
            yaml = serializer.Serialize(modsData);
            guidStr = "2089455f10e0bb044bfbd1dbcca6bb00";
        }
        else if (assetObj is statsDictionary statsDict) {
            statsData = new StatsList
            {
                stats = statsDict.Values.ToList()
            };

            yaml = serializer.Serialize(statsData);
            guidStr = "09dbea449d423d24c9e3cc308f3a5c62";
        }
        else {
            Console.WriteLine("ERROR: Bad object sent to WriteAsset.");
            return;
        }

        string header = 
@"%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!114 &11400000
MonoBehaviour:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 11500000, guid: XXX, type: 3}
  m_Name: ModsData
  m_EditorClassIdentifier: ";

        string outputStr = header.Replace("XXX", guidStr) + "\n" + yaml;

        // Write the YAML string to the given file.
        File.WriteAllText(filePath, outputStr);
    }

}
