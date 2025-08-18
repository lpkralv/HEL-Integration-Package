using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Localization;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "StatsData", menuName = "ScriptableObjects/StatsData", order = 2)]
public class StatsData : ScriptableObject
{
    public Stat[] stats;
}

[System.Serializable]
public class Stat {
    //public string id; // Unique key used for localization and reference
    [Tooltip("Default fallback name")]
    public string name;
    public string displayname;
    [Tooltip("Default fallback description")]
    [TextArea]
    public string desc;

    public float value;
    public float min = 0;
    public float max = 0;
    
    [Tooltip("If true, this stat persists through weapon switching and equipment changes")]
    public bool persistent = false;

    public Stat() {}

    public Stat(Stat other)
    {
        name = other.name;
        displayname = other.displayname;
        desc = other.desc;
        value = other.value;
        min = other.min;
        max = other.max;
        persistent = other.persistent;
    }

    // Runtime localization wrappers
    public LocalizedString localizedName => new LocalizedString("StatNames", name);
    public LocalizedString localizedDesc => new LocalizedString("StatDescriptions", name);
}
