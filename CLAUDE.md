# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

HEL4Unity is a C# implementation of the HIOX Equation Language (HEL), designed for Unity integration. This system processes mathematical equations that modify game statistics through mods (modifications).

## Core Architecture

### HEL System Components

The HEL system operates as a stateless equation evaluator with these key components:

1. **HEL.cs** - Main entry point providing static evaluation methods
   - `EvaluateMods()` - Processes mod dictionaries against base stats
   - `PrepareEquation()` - Substitutes VAL/VAL1/VAL2 placeholders
   - `EvaluateEquation()` - Core equation evaluation pipeline

2. **HELLexer.cs** - Tokenizes equation strings into structured tokens
   - Handles variable prefixes (S_, T_, B_, A_, M_, Z_, U_)
   - Supports mathematical operators and keywords
   - Manages LHS vs RHS variable contexts

3. **HELInterpreter.cs** - Executes parsed statements using coefficient system
   - Uses CoefDict class for stat modification tracking
   - Implements coefficient-based calculation: `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`
   - Handles dependency ordering and cycle resolution

4. **HELOrdering.cs** - Analyzes statement dependencies and cycle detection
   - Uses DFS algorithm to find circular dependencies
   - Groups statements by cycle membership count
   - Enables proper execution order for complex mod interactions

### Data Models

- **Mod** (HELAssetDefs.cs) - Represents game modifications with equations
- **Stat** (HELAssetDefs.cs) - Represents game statistics with value ranges
- **Token/Statement** (HELLangDefs.cs) - Language parsing structures

### Variable Prefix System

HEL uses prefixed variables to categorize different types of stat modifications:
- `S_` - Base stat values (read-only)
- `B_` - Base additive modifiers
- `A_` - Absolute additive modifiers  
- `M_` - Multiplicative modifiers (percentage-based)
- `Z_` - Minimum value adjustments
- `U_` - Maximum value adjustments
- `T_` - Temporary modifiers (read-only)

### Utility Classes

- **HELYAMLFile.cs** - YAML asset serialization (uses YamlDotNet)
- **HELCSVFile.cs** - CSV asset serialization
- **HELPicker.cs** - Weighted random selection using Alias method (editor-only)

## Development Notes

### Build and Testing
This is a Unity package with no standalone build system. No test framework is currently configured.

### Debugging
Enable debugging by uncommenting `#define MYDEBUG` in relevant files. This outputs detailed tokenization, parsing, and evaluation information to console.

### Key Design Patterns

1. **Stateless Evaluation** - All methods are static, no state retained between calls
2. **Coefficient Accumulation** - Modifications are accumulated in coefficient objects before final application
3. **Dependency Resolution** - Complex mod interactions are resolved through cycle analysis
4. **Type Safety** - Strong typing with dictionaries: `statsDictionary`, `modsDictionary`

### Common Equation Format
```
#!123;S_HEALTH = S_HEALTH + VAL;
```
- `#!123` - Embedded mod ID comment
- `S_HEALTH` - Target stat variable
- `VAL` - Placeholder replaced with mod value during preparation