#if HELYAML
/*  HELYAMLFile.cs

    This class loads and saves the ".asset" files in YAML format. 
    It is used by the Editor. It can be used by the HEL class to
    load assets, but by default it is not configured to do so.
    Otherwise, this file is not needed for HEL evaluation.
*/

//#define MYDEBUG       //Comment this line to turn off debugging

using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
// NOTE: YamlDotNet functionality disabled for Unity compatibility
// using YamlDotNet.Serialization.NamingConventions;
// using YamlDotNet.Serialization;

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
using modsDictionary = System.Collections.Generic.Dictionary<string, Modifier>;

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
    public static (modsDictionary, statsDictionary) LoadAsset(string path)
    {
        // NOTE: YamlDotNet functionality disabled for Unity compatibility
        // This method would normally load YAML files, but is currently not functional
        throw new System.NotImplementedException("YAML loading is disabled in Unity build. Use JSON or other serialization methods instead.");
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
    public static void WriteAsset(string path, modsDictionary mods = null, statsDictionary stats = null)
    {
        // NOTE: YamlDotNet functionality disabled for Unity compatibility
        // This method would normally write YAML files, but is currently not functional
        throw new System.NotImplementedException("YAML writing is disabled in Unity build. Use JSON or other serialization methods instead.");
    }

}
#endif