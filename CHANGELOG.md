# Changelog

## [1.0.0] - 2025-08-16

**UUID Support Release** - Major API update enabling multiple mod instances.

### Added
- UUID-based mod instances with unique identifiers
- Simplified 2-parameter `EvaluateMods()` API
- Support for multiple copies of same mod type
- Integration examples and visual editor

### Breaking Changes
- Method: `EvaluateMods(statsDict, modsDict)` (removed inventory parameter)
- Equipped mods: `Dictionary<string, Mod>` (UUID-keyed) vs `Dictionary<int, int>` (count-based)
- Added `uuid` property to Mod class

### Migration from 0.9.x

**Update method calls:**
```csharp
// OLD: HEL.EvaluateMods(stats, mods, playerInventory);
// NEW: HEL.EvaluateMods(stats, equippedMods);
```

**Generate UUIDs for existing mods:**
```csharp
if (string.IsNullOrEmpty(mod.uuid))
    mod.uuid = $"uuid-{mod.modid}-{Guid.NewGuid().ToString("N")[..6]}";
```

## Requirements

- .NET 8.0+ (updated from previous versions)
- YamlDotNet 16.1.3
- Asset files: Fully backward compatible