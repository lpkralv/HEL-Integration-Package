

// object classes corresponding to Stats and Mods (for the purposes of deserialization).
// These don't need to match corresponding classes elsewhere, but they could.

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a game modification with all its properties including values, ranges, colors, and equations.
/// Used for serialization/deserialization of mod data from asset files.
/// </summary>
public class Modifier
{
    /// <summary>
    /// Gets or sets the unique identifier for this mod.
    /// </summary>
    public int modid { get; set; }
    
    /// <summary>
    /// Gets or sets the unique UUID for this mod instance.
    /// </summary>
    public string uuid { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the primary value of the mod.
    /// </summary>
    public float val { get; set; }
    
    /// <summary>
    /// Gets or sets the secondary value of the mod.
    /// </summary>
    public float val2 { get; set; }
    
    /// <summary>
    /// Gets or sets the minimum value for the primary mod value range.
    /// </summary>
    public float val1min { get; set; }
    
    /// <summary>
    /// Gets or sets the maximum value for the primary mod value range.
    /// </summary>
    public float val1max { get; set; }
    
    /// <summary>
    /// Gets or sets the minimum value for the secondary mod value range.
    /// </summary>
    public float val2min { get; set; }
    
    /// <summary>
    /// Gets or sets the maximum value for the secondary mod value range.
    /// </summary>
    public float val2max { get; set; }
    
    /// <summary>
    /// Gets or sets the display name of the mod.
    /// </summary>
    public string name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of the mod.
    /// </summary>
    public string desc { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the weight/priority of the mod for ordering purposes.
    /// </summary>
    public int modweight { get; set; }
    
    /// <summary>
    /// Gets or sets the type identifier of the mod.
    /// </summary>
    public int type { get; set; }
    
    /// <summary>
    /// Gets or sets whether this mod has a special process (0 = no, 1 = yes).
    /// </summary>
    public int hasProc { get; set; }
    
    /// <summary>
    /// Gets or sets the HEL equation string that defines how this mod modifies stats.
    /// </summary>
    public string equation { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the color properties for visual representation of the mod.
    /// </summary>
    public Color modColor { get; set; } = Color.white;
    
    /// <summary>
    /// Gets or sets the name of the armor effect associated with this mod.
    /// </summary>
    public string armorEffectName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the name of the armor mesh associated with this mod.
    /// </summary>
    public string armorMeshName { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the Modifier class with default values.
    /// </summary>
    public Modifier() {}

    /// <summary>
    /// Initializes a new instance of the Modifier class by copying values from another Modifier instance.
    /// Creates a deep copy of the source mod.
    /// </summary>
    /// <param name="other">The Modifier instance to copy from</param>
    public Modifier(Modifier other)
    {
        modid = other.modid;
        uuid = other.uuid;
        val = other.val;
        val2 = other.val2; 
        val1min = other.val1min;
        val1max = other.val1max;
        val2min = other.val2min;
        val2max = other.val2max;       
        name = other.name;          // For strings this is fine as they are immutable.
        desc = other.desc;
        modweight = other.modweight;
        type = other.type;
        hasProc = other.hasProc;
        equation = other.equation;
        modColor = other.modColor;
        armorEffectName = other.armorEffectName;
        armorMeshName = other.armorMeshName;
    }
}

/// <summary>
/// Container class for a collection of Modifier objects.
/// Used for YAML/JSON serialization of mod collections.
/// </summary>
public class ModsList
{
    /// <summary>
    /// Gets or sets the list of mods contained in this collection.
    /// </summary>
    public List<Modifier> mods { get; set; } = new List<Modifier>();
}



#if HELYAML
/// <summary>
/// Container class for a collection of Stat objects.
/// Used for YAML/JSON serialization of stat collections.
/// </summary>
[System.Serializable]
public class StatsList
{
    /// <summary>
    /// Gets or sets the array of stats contained in this collection.
    /// Updated to match StatsData.cs structure using array instead of List.
    /// </summary>
    public Stat[] stats;
}
#endif
