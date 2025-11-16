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

### Text File Processing Utilities

Three Python utilities are available for efficiently working with large text files in this repository:

#### findall.py - Find Files Containing Text
Searches for files matching a glob pattern that contain a target string.

**Usage:**
```bash
# CLI usage
python3 findall.py "**/*.cs" "HEL"          # Find all C# files containing "HEL"
python3 findall.py "docs/*.md" "Architecture"  # Find docs with "Architecture"

# Module usage
from findall import findall
files = findall("src/*.cs", "class")
```

**When to use:**
- Searching for files that contain specific terms across multiple directories
- Quickly narrowing down which files to examine for code patterns
- Finding all files that reference a particular variable, class, or concept

#### findlines.py - Find Line Numbers
Returns 1-indexed line numbers where a target string appears in a file.

**Usage:**
```bash
# CLI usage
python3 findlines.py src/HEL.cs "EvaluateMods"
python3 findlines.py CLAUDE.md "Variable Prefix"

# Module usage
from findlines import findlines
lines = findlines("src/HELInterpreter.cs", "S_")
```

**When to use:**
- Locating specific code patterns within a known file
- Finding all occurrences of a variable or function name
- Identifying where documentation mentions specific topics
- Preparing to extract relevant code sections

#### sniptext.py - Extract Text Snippets
Extracts a snippet from a file by line range (1-indexed, inclusive).

**Usage:**
```bash
# CLI usage
python3 sniptext.py src/HEL.cs 15 25        # Lines 15-25
python3 sniptext.py README.md 1 10          # First 10 lines

# Module usage
from sniptext import sniptext
snippet = sniptext("src/HELLexer.cs", 100, 150)
```

**When to use:**
- Extracting specific code sections for analysis or documentation
- Reading portions of large files without loading the entire file
- Focusing on specific line ranges identified by findlines.py
- Creating code examples or documentation snippets

#### Workflow Example
```bash
# 1. Find files containing "CoefDict"
python3 findall.py "**/*.cs" "CoefDict"
# Result: src/HELInterpreter.cs

# 2. Find line numbers where it's used
python3 findlines.py src/HELInterpreter.cs "CoefDict"
# Result: [12, 45, 89, 134]

# 3. Extract relevant code section
python3 sniptext.py src/HELInterpreter.cs 45 60
```

**Notes:**
- All utilities support both CLI and module import patterns
- Searches are case-sensitive
- Encoding errors are handled gracefully (UTF-8, UTF-16, Latin-1)
- Use these tools to efficiently navigate the codebase without reading entire files