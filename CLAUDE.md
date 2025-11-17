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

### REQUIRED: Large File Protocol

**CRITICAL RULE**: This repository contains large Stats/Mods files (up to 2,947 lines). You MUST use text processing utilities instead of reading large files directly.

#### File Size Protocol (MANDATORY)

**Before reading any file, check size:**
```bash
wc -l <filepath>
```

**Apply required strategy:**
- **< 200 lines**: Use `Read` tool directly
- **200-500 lines**: Use `findlines.py` + `sniptext.py`
- **500+ lines**: NEVER use Read - ONLY use `findlines.py` + `sniptext.py`

#### Critical Large Files (ALWAYS use protocol)

**Asset Files:**
- `DELIVERABLE-ModsData.asset` (2,947 lines) - 156 mods
- `src/ModsData.asset`, `Assets/ModsData.asset` (1,023 lines)
- Stats asset files (191-213 lines)

**Documentation:**
- `docs/DELIVERABLE-Mods-Description.md` (616 lines)
- `docs/DELIVERABLE-Stats-Description.md` (662 lines)
- `docs/DELIVERABLE-System-Philosophy.md` (617 lines)

#### Text Utilities Quick Reference

```bash
# Find files containing text
python3 findall.py "**/*.asset" "CRIT_CHANCE"

# Find line numbers in a file
python3 findlines.py DELIVERABLE-ModsData.asset "id: 1015"

# Extract specific line range
python3 sniptext.py DELIVERABLE-ModsData.asset 450 475
```

#### Example: Finding a Specific Mod

```bash
# ❌ WRONG: Reading 2,947-line file (wastes ~80,000 tokens)
Read DELIVERABLE-ModsData.asset

# ✅ CORRECT: Targeted extraction (uses ~600 tokens)
python3 findlines.py DELIVERABLE-ModsData.asset "id: 1015"  # Find line
python3 sniptext.py DELIVERABLE-ModsData.asset 450 475      # Extract mod
```

**See `docs/LARGE-FILE-PROTOCOL.md` for detailed examples and workflows.**