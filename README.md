# HEL4Unity Integration Package

## Overview

This package contains the C# implementation of the HIOX Equation Language (HEL) system, designed for Unity integration. HEL is a stateless equation evaluator that processes mathematical equations to modify game statistics through mods (modifications).

## Integration Instructions

### 1. File Integration

Copy all `.cs` files from this package into your Unity project's `Assets/Scripts/` directory. You can organize them in a subfolder (e.g., `Assets/Scripts/HEL/`) to keep them organized.

**Required Files:**
- `HEL.cs` - Main entry point and static evaluation methods
- `HELAssetDefs.cs` - Data models (Mod, Stat, ModColor, etc.)
- `HELLexer.cs` - Tokenizes equation strings
- `HELInterpreter.cs` - Executes parsed statements using coefficient system
- `HELOrdering.cs` - Dependency analysis and cycle detection
- `HELLangDefs.cs` - Language parsing structures (Token, Statement)
- `HELCSVFile.cs` - CSV asset serialization (optional)
- `HELYAMLFile.cs` - YAML asset serialization (currently disabled)
- `TestUnityCompilation.cs` - Test script (optional, can be removed in production)

### 2. Unity Requirements

- **Unity Version:** 2022.3.4f1 or newer
- **Scripting Backend:** Mono or IL2CPP
- **API Compatibility Level:** .NET Standard 2.1 or .NET Framework

### 3. Dependencies

The HEL system has minimal dependencies:
- Uses standard Unity namespaces (`UnityEngine`, `UnityEngine.Localization`)
- No external package dependencies required
- YamlDotNet functionality is currently disabled for Unity compatibility

### 4. Basic Usage Example

```csharp
using System.Collections.Generic;
using UnityEngine;

public class HELExample : MonoBehaviour
{
    void Start()
    {
        // Create stats dictionary
        var stats = new Dictionary<string, Stat>
        {
            ["HEALTH"] = new Stat 
            { 
                name = "HEALTH", 
                displayname = "Health",
                desc = "Player health points",
                value = 100f, 
                min = 0f, 
                max = 200f,
                persistent = false
            }
        };

        // Create mods dictionary
        var mods = new Dictionary<string, Mod>
        {
            ["HEALTH_BOOST"] = new Mod 
            { 
                name = "Health Boost",
                equation = "#!1;S_HEALTH = S_HEALTH + VAL;",
                val = 25f
            }
        };

        // Evaluate mods against stats
        var result = HEL.EvaluateMods(stats, mods);
        
        Debug.Log($"Final Health: {result["HEALTH"].value}"); // Should output 125
    }
}
```csharp
using System.Collections.Generic;
using UnityEngine;

public class HELExample : MonoBehaviour
{
    void Start()
    {
        // Create stats dictionary
        var stats = new Dictionary<string, Stat>
        {
            ["HEALTH"] = new Stat 
            { 
                name = "HEALTH", 
                displayname = "Health",
                desc = "Player health points",
                value = 100f, 
                min = 0f, 
                max = 200f,
                persistent = false
            }
        };

        // Create mods dictionary
        var mods = new Dictionary<string, Mod>
        {
            ["HEALTH_BOOST"] = new Mod 
            { 
                name = "Health Boost",
                equation = "#!1;S_HEALTH = S_HEALTH + VAL;",
                val = 25f
            }
        };

        // Evaluate mods against stats
        var result = HEL.EvaluateMods(stats, mods);
        
        Debug.Log($"Final Health: {result["HEALTH"].value}"); // Should output 125
    }
}
```

## HEL System Architecture

### Variable Prefix System

HEL uses prefixed variables to categorize different types of stat modifications:
- `S_` - Base stat values (read-only)
- `B_` - Base additive modifiers
- `A_` - Absolute additive modifiers  
- `M_` - Multiplicative modifiers (percentage-based)
- `Z_` - Minimum value adjustments
- `U_` - Maximum value adjustments
- `T_` - Temporary modifiers (read-only)

### Calculation Formula

The final stat calculation follows this formula:
```
result = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

### Equation Format

HEL equations follow this format:
```
#!123;S_HEALTH = S_HEALTH + VAL;
```
- `#!123` - Embedded mod ID comment (added automatically by EvaluateMods())
- `S_HEALTH` - Target stat variable
- `VAL` - Placeholder replaced with mod value during preparation

## Potential Issues & Solutions## Potential Issues & Solutions

### 1. Compilation Errors

**Missing Unity References:**
- Ensure `using UnityEngine;` is present in files using Unity attributes
- Add `using UnityEngine.Localization;` for localization features (Editor only)

**Assembly Definition Issues:**
- If using Assembly Definitions, ensure HEL scripts are in the same assembly or reference the appropriate assemblies

### 2. Performance Considerations

**Large Mod Sets:**
- The system processes all mods sequentially
- For performance-critical applications with hundreds of mods, consider caching results
- Use the dependency ordering system to minimize cycle resolution overhead

**Memory Usage:**
- The system creates temporary dictionaries during evaluation
- Consider object pooling for frequently evaluated mod sets

### 3. Integration with Existing Systems

**Stat Structure Compatibility:**
- The `Stat` class includes Unity serialization attributes
- If you have existing stat systems, you may need to create adapter methods
- The `persistent` field is designed for stats that survive equipment changes

**Localization Integration:**
- Localization wrappers are conditionally compiled for Editor-only use
- Remove localization code if not using Unity's Localization Package

### 4. Debugging

**Enable Debug Output:**
- Uncomment `#define MYDEBUG` in relevant files for detailed console output
- This shows tokenization, parsing, and evaluation steps

**Common Issues:**
- Ensure mod equations include proper mod ID comments (`#!123`) [Only for debugging. Added automatically by EvaluateMods()]
- Check that stat names in equations match dictionary keys (case-insensitive)
- Verify VAL/VAL1/VAL2 placeholders are properly replaced

### 5. YAML/CSV File Loading

**Current Status:**
- YAML functionality is disabled (`NotImplementedException`)
- CSV loading works but may need adjustment for your data format
- Consider implementing JSON serialization as an alternative

## Testing

Run the included `TestUnityCompilation.cs` script to verify basic functionality:
1. Attach the script to a GameObject in your scene
2. Enter Play mode
3. Check the Console for test results

## Support

This integration package was created for Unity 2022.3.4f1. If you encounter issues with newer Unity versions:
- Check for API deprecation warnings
- Update Unity-specific code as needed
- Verify .NET compatibility settings

For questions about HEL language features or equation syntax, refer to the HIOX documentation or the inline code comments.