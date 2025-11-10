

// object classes corresponding to Stats and Mods (for the purposes of deserialization).
// These don't need to match corresponding classes elsewhere, but they could.
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Represents a game modification with all its properties including values, ranges, colors, and equations.
/// Used for serialization/deserialization of mod data from asset files.
/// </summary>
public class Mod
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
    public ModColor modColor { get; set; } = new ModColor();
    
    /// <summary>
    /// Gets or sets the name of the armor effect associated with this mod.
    /// </summary>
    public string armorEffectName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the name of the armor mesh associated with this mod.
    /// </summary>
    public string armorMeshName { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the Mod class with default values.
    /// </summary>
    public Mod() {}

    /// <summary>
    /// Initializes a new instance of the Mod class by copying values from another Mod instance.
    /// Creates a deep copy of the source mod.
    /// </summary>
    /// <param name="other">The Mod instance to copy from</param>
    public Mod(Mod other)
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
        modColor = other.modColor; // this is shallow copy, but we're not using color
        armorEffectName = other.armorEffectName;
        armorMeshName = other.armorMeshName;
    }
}

/// <summary>
/// Represents RGBA color values for mod visual representation.
/// Each color component is stored as an integer value.
/// </summary>
public class ModColor
{
    /// <summary>
    /// Gets or sets the red color component.
    /// </summary>
    public int r { get; set; }
    
    /// <summary>
    /// Gets or sets the green color component.
    /// </summary>
    public int g { get; set; }
    
    /// <summary>
    /// Gets or sets the blue color component.
    /// </summary>
    public int b { get; set; }
    
    /// <summary>
    /// Gets or sets the alpha (transparency) component.
    /// </summary>
    public int a { get; set; }
}

/// <summary>
/// Container class for a collection of Mod objects.
/// Used for YAML/JSON serialization of mod collections.
/// </summary>
public class ModsList
{
    /// <summary>
    /// Gets or sets the list of mods contained in this collection.
    /// </summary>
    public List<Mod> mods { get; set; } = new List<Mod>();
}

/// <summary>
/// Represents a game statistic with its current value and allowable range.
/// Used for serialization/deserialization of stat data from asset files.
/// </summary>
public class Stat
{
    /// <summary>
    /// Gets or sets the name identifier of the stat.
    /// </summary>
    public string name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of the stat.
    /// </summary>
    public string desc { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the current value of the stat.
    /// </summary>
    public float value { get; set; }
    
    /// <summary>
    /// Gets or sets the minimum allowable value for the stat.
    /// </summary>
    public float min { get; set; }
    
    /// <summary>
    /// Gets or sets the maximum allowable value for the stat.
    /// </summary>
    public float max { get; set; }

    /// <summary>
    /// Initializes a new instance of the Stat class with default values.
    /// </summary>
    public Stat() {}

    /// <summary>
    /// Initializes a new instance of the Stat class by copying values from another Stat instance.
    /// Creates a deep copy of the source stat.
    /// </summary>
    /// <param name="other">The Stat instance to copy from</param>
    public Stat(Stat other)
    {
        // Strings are immutable so a direct assignment is acceptable.
        name = other.name;
        desc = other.desc;
        value = other.value;
        min = other.min;
        max = other.max;
    }
}

/// <summary>
/// Container class for a collection of Stat objects.
/// Used for YAML/JSON serialization of stat collections.
/// </summary>
public class StatsList
{
    /// <summary>
    /// Gets or sets the list of stats contained in this collection.
    /// </summary>
    public List<Stat> stats { get; set; } = new List<Stat>();
}
