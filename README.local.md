# HEL Integration Package

HIOX Equation Language system for dynamic stat modification through mod equations.

## Contents

- **`src/`** - Core HEL system (9 files)
- **`assets/`** - Sample mod/stat data files  
- **`docs/`** - Complete documentation
- **`examples/`** - Integration examples (Basic, Unity, Performance)
- **`tools/`** - Visual mod editor

## Quick Integration

1. Copy `src/` files to your project
2. Install: `dotnet add package YamlDotNet --version 16.1.3`
3. See **QUICK-START.md** for 5-minute setup

## Core API

```csharp
// Load assets
var (statsObj, _) = HELYAMLFile.LoadAsset("StatsData.asset", "statsList");
var baseStats = (Dictionary<string, Stat>)statsObj;

// Create equipped mods (UUID-keyed)
var equippedMods = new Dictionary<string, Mod>();

// Calculate final stats  
var finalStats = HEL.EvaluateMods(baseStats, equippedMods);
```

## Key Features

- **UUID-based mod instances** - Multiple copies of same mod type
- **Thread-safe evaluation** - Stateless design
- **Complex equations** - Full mathematical expression support
- **Dependency resolution** - Automatic ordering

## Requirements

- .NET 8.0+
- YamlDotNet 16.1.3

## Documentation

- **QUICK-START.md** - 5-minute setup guide
- **docs/HEL-Documentation-Complete.md** - Full API reference
- **examples/** - Working integration code

Version 1.0.0 | 2025-08-16