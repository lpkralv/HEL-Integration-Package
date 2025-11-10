# HEL Quick Start

## 1. Setup (2 minutes)

Copy `src/` files to your project and install dependency:
```bash
dotnet add package YamlDotNet --version 16.1.3
```

## 2. Integration (3 minutes)

```csharp
public class HELManager
{
    private Dictionary<string, Stat> baseStats;
    private Dictionary<string, Mod> availableMods;
    
    public void Initialize()
    {
        // Load assets
        var (statsObj, _) = HELYAMLFile.LoadAsset("StatsData.asset", "statsList");
        baseStats = (Dictionary<string, Stat>)statsObj;
        
        var (modsObj, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsList");
        var modsList = (Dictionary<int, Mod>)modsObj;
        
        // Convert to UUID-keyed dictionary
        availableMods = new Dictionary<string, Mod>();
        foreach (var mod in modsList.Values)
        {
            if (string.IsNullOrEmpty(mod.uuid))
                mod.uuid = $"uuid-{mod.modid}-{Guid.NewGuid().ToString("N")[..6]}";
            availableMods[mod.uuid] = mod;
        }
    }
    
    public Dictionary<string, Stat> CalculateStats(List<string> equippedModUUIDs)
    {
        var equippedMods = new Dictionary<string, Mod>();
        foreach (string uuid in equippedModUUIDs)
            if (availableMods.ContainsKey(uuid))
                equippedMods[uuid] = availableMods[uuid];
        
        return HEL.EvaluateMods(baseStats, equippedMods);
    }
}
```

## 3. Usage

```csharp
var helManager = new HELManager();
helManager.Initialize();

var playerMods = new List<string> { "uuid-0-abc123" };
var finalStats = helManager.CalculateStats(playerMods);

float health = finalStats["HP"].value;
```

## Done! ✅

✅ Mod equations evaluate automatically  
✅ Dependencies resolved automatically  
✅ Multiple mod instances supported  
✅ Thread-safe stateless evaluation

## Next Steps

- Customize: Edit `assets/` files for your game
- Optimize: See `examples/Performance-Optimized.cs`
- Editor: Use `tools/HEL-Editor/` for visual mod creation

## Troubleshooting

- **YamlDotNet not found**: `dotnet add package YamlDotNet`
- **Assets not loading**: Check file paths
- **Stats not updating**: Call `CalculateStats()` after equipment changes