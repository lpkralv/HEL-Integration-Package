# HEL (HIOX Equation Language) Documentation
## Table of Contents

---

## 1. HEL Language Reference

### 1.1 Overview & Core Concepts
**File:** `1-1-Overview-Core-Concepts.md`
- 1.1.1 Introduction
- 1.1.2 HEL Purpose and Design Philosophy
- 1.1.3 Core Concepts
- 1.1.4 Data Flow Overview

### 1.2 Stats and SubStat System  
**File:** `1-2-Stats-SubStat-System.md`
- 1.2.1 Base Stats vs SubStats
- 1.2.2 SubStat Prefix System
- 1.2.3 Coefficient Types Explained
- 1.2.4 Relationship to Final Computation
- 1.2.5 Example: Multi-Coefficient Mod

### 1.3 HEL Syntax
**File:** `1-3-HEL-Syntax.md`
- 1.3.1 Token Types and Lexical Elements
- 1.3.2 Variables and Naming Conventions
- 1.3.3 Mathematical Operators
- 1.3.4 Comparison Operators
- 1.3.5 Logical Operators
- 1.3.6 Built-in Functions
- 1.3.7 Assignment Statements
- 1.3.8 Comments and Annotations

### 1.4 HEL Semantics
**File:** `1-4-HEL-Semantics.md`
- 1.4.1 Statement Evaluation Order
- 1.4.2 Variable Resolution and Scoping
- 1.4.3 Assignment Semantics
- 1.4.4 Expression Evaluation
- 1.4.5 Error Handling and Validation

### 1.5 Stat Value Computation
**File:** `1-5-Stat-Value-Computation.md`
- 1.5.1 The Core Computation Formula
- 1.5.2 Step-by-Step Computation Process
- 1.5.3 Range Clamping with Z and U Coefficients
- 1.5.4 Examples with Different Coefficient Combinations

### 1.6 Dependency Resolution & Ordering
**File:** `1-6-Dependency-Resolution-Ordering.md`
- 1.6.1 Understanding Dependencies in HEL
- 1.6.2 Dependency Analysis Process  
- 1.6.3 Cycle Detection Algorithm
- 1.6.4 Cycle Resolution Strategies
- 1.6.5 Statement Execution Ordering
- 1.6.6 Performance Implications

### 1.7 Language Examples
**File:** `1-7-Language-Examples.md`
- 1.7.1 Simple Stat Modifications
- 1.7.2 Multi-Stat Interdependencies
- 1.7.3 Complex Dependency Cycles
- 1.7.4 Advanced Mathematical Expressions
- 1.7.5 Error Cases and Troubleshooting

---

## 2. Class Usage Guide

### 2.1 Integration Overview
**File:** `2-1-Integration-Overview.md`
- 2.1.1 Introduction
- 2.1.2 Typical Integration Workflow
- 2.1.3 Key Classes and Their Roles
- 2.1.4 Performance Considerations
- 2.1.5 Best Practices Summary

### 2.2 HEL Class Usage
**File:** `2-2-HEL-Class-Usage.md`
- 2.2.1 Primary Interface Overview
- 2.2.2 EvaluateMods() Method Usage
- 2.2.3 Error Handling Strategies
- 2.2.4 Common Usage Patterns
- 2.2.5 Performance Optimization

### 2.3 Asset Management
**File:** `2-3-Asset-Management.md`
- 2.3.1 File Format Overview
- 2.3.2 Loading Asset Files
- 2.3.3 Writing Asset Files  
- 2.3.4 Data Validation and Error Recovery
- 2.3.5 Format Conversion Utilities

### 2.4 HELPicker Usage
**File:** `2-4-HELPicker-Usage.md`
- 2.4.1 Overview of Weighted Random Selection
- 2.4.2 Alias Method Algorithm Benefits
- 2.4.3 Constructor and Setup
- 2.4.4 Sampling Operations
- 2.4.5 Integration Patterns

### 2.5 Common Integration Patterns
**File:** `2-5-Common-Integration-Patterns.md`
- 2.5.1 Application Initialization and Asset Loading
- 2.5.2 Player Mod Inventory Management
- 2.5.3 Real-time Stat Calculation During Gameplay
- 2.5.4 Mod Effect Previewing and Analysis
- 2.5.5 Integration with Existing Game Systems

---

## 3. Class/Method Reference

### 3.1 HEL Class Reference
**File:** `3-1-HEL-Class-Reference.md`
- 3.1.1 Overview
- 3.1.2 Primary Interface
- 3.1.3 Equation Processing Methods
- 3.1.4 Direct Evaluation Method
- 3.1.5 Integration Guidelines
- 3.1.6 Thread Safety and Concurrency
- 3.1.7 Memory Management

### 3.2 File I/O Classes Reference
**File:** `3-2-File-IO-Classes-Reference.md`
- 3.2.1 Overview
- 3.2.2 HELYAMLFile Class
- 3.2.3 HELCSVFile Class
- 3.2.4 Usage Examples and Integration Patterns
- 3.2.5 Error Handling and Validation

### 3.3 HELPicker Class Reference
**File:** `3-3-HELPicker-Class-Reference.md`
- 3.3.1 Overview
- 3.3.2 Constructor and Initialization
- 3.3.3 Sample() Method
- 3.3.4 Alias Method Algorithm
- 3.3.5 Performance Characteristics
- 3.3.6 Usage Examples

### 3.4 Data Classes Reference
**File:** `3-4-Data-Classes-Reference.md`
- 3.4.1 Overview
- 3.4.2 Mod Class
- 3.4.3 Stat Class
- 3.4.4 ModColor Class
- 3.4.5 Container Classes
- 3.4.6 Usage Patterns and Best Practices

### 3.5 Internal Classes Reference
**File:** `3-5-Internal-Classes-Reference.md`
- 3.5.1 Overview
- 3.5.2 Token Class
- 3.5.3 Statement Class
- 3.5.4 Coefficient Class
- 3.5.5 CoefDict Class
- 3.5.6 HELLexer Class
- 3.5.7 HELInterpreter Class

---

## Index
**File:** `Index.md`
- Alphabetical index of concepts, terms, classes, and methods
- Cross-references to section and paragraph numbers
- Quick reference for specific functionality

---

## Appendix
**File:** `Appendix.md`
- Implementation differences between original HIOX and enhanced HEL systems
- M_ coefficient design decision rationale and migration guidance
- Historical context and compatibility considerations

---

## Document Conventions

- **File Naming:** Section number + descriptive name (e.g., `1-3-HEL-Syntax.md`)
- **Cross-References:** `[Section X.Y](X-Y-Section-Name.md)` format
- **Code Examples:** Properly formatted with language hints
- **Warnings:** ⚠️ for important considerations, limitations, or required actions
- **Notes:** 📝 for additional context or tips
- **Internal vs Public:** Clear distinction between developer-facing APIs and internal implementation details

---

**Document Version:** 1.0  
**Target Audience:** HIOX Game Developers  
**Prerequisites:** Basic understanding of C#/.NET, familiarity with HIOX game architecture  
**Last Updated:** [Generated Date]

---

# 1. HEL Language Reference

# 1.1 Overview & Core Concepts

## 1.1.1 Introduction

The HEL (HIOX Equation Language) system is a sophisticated mathematical expression evaluator designed for processing mod equations that dynamically modify game statistics. HEL enables complex mathematical relationships between game elements through flexible equation processing.

## 1.1.2 HEL Purpose and Design Philosophy

HEL serves as the computational engine that transforms static mod definitions into dynamic stat modifications. Rather than using simple additive or multiplicative bonuses, HEL allows mod designers to create sophisticated mathematical relationships that can:

- Reference and modify multiple player statistics simultaneously
- Create complex interdependencies between different game mechanics
- Implement percentage-based modifications with proper mathematical precision  
- Support conditional logic and mathematical functions
- Maintain consistent evaluation order through dependency resolution

The language is designed to be both powerful enough for complex game mechanics and safe enough to prevent infinite loops or mathematical instabilities that could crash the game.

## Relationship to HIOX Game

This HEL implementation serves as a **development and testing tool** for HIOX game developers. The relationship follows this integration model:

```
HIOX Game (Unity) ← Integration ← HEL Classes ← This Development Tool
```

### 1.1.2.1 Development and Integration Context
- **Purpose**: HEL classes provide equation evaluation capabilities for game stat modification systems
- **Usage**: Both standalone development tools and integrated game environments can utilize HEL classes
- **Integration**: The HEL system is designed for easy integration into Unity-based game architectures

⚠️ **Important**: The HEL classes are designed as reusable components that can be integrated into various game development workflows.

## 1.1.3 Core Concepts

### 1.1.3.1 Mods
**Mods** are game modifications that alter player abilities and statistics. Each mod contains:

- **Identification**: Unique `modid` and descriptive `name`
- **Values**: Primary (`val`) and secondary (`val2`) numeric values with min/max ranges
- **Equation**: HEL expression string defining how the mod affects stats
- **Metadata**: Description, weight, type classification, visual properties

**Example Mod**:
```yaml
modid: 0
name: LIGHTWEIGHT LUCKYSHOT NANITES  
val: 0.43
val2: 1.86
equation: M_GUNDAMAGE=-val1;M_PROCRATE=val2
desc: Lowers gun damage by val1% and increases effective proc rate by val2%
```

### 1.1.3.2 Stats
**Stats** represent player characteristics that can be modified by mods. Each stat includes:

- **Base Value**: Starting numeric value (`value`)
- **Range Constraints**: Minimum and maximum allowable values (`min`, `max`)
- **Metadata**: Human-readable name and description

**Example Stat**:
```yaml
name: PLAYERSPEED
desc: How fast you run
value: 130
min: 0
max: 5000
```

### 1.1.3.3 SubStats and Coefficient System
HEL uses a **SubStat coefficient system** to provide granular control over how modifications are applied. Rather than directly modifying base stats, equations modify coefficient values that are then mathematically combined to produce final stat values.

**SubStat Prefixes**:
- **S_** (Start): Base starting values for stats
- **B_** (Base): Additive base modifications applied before multiplication
- **A_** (Add): Absolute additive modifications applied after multiplication  
- **M_** (Mult): Multiplicative percentage modifications (0.1 = +10%)
- **Z_** (Min): Adjustments to minimum value constraints
- **U_** (Max): Adjustments to maximum value constraints
- **T_** (Total): Final computed values (read-only, calculated by system)

**Example SubStat Variables**:
```
S_PLAYERSPEED = 130    // Base starting speed
B_PLAYERSPEED = 0      // Base additive modifier
M_PLAYERSPEED = 0.2    // +20% multiplicative bonus
A_PLAYERSPEED = 15     // +15 absolute bonus after multiplication
T_PLAYERSPEED = ?      // Final computed value
```

### Equations
**Equations** are HEL expressions that define how mods modify SubStat coefficients. They support:

- **Variable References**: Access to SubStat coefficients and mod values
- **Mathematical Operations**: Standard arithmetic (`+`, `-`, `*`, `/`, `^`)
- **Comparison Operators**: Equality and relational tests (`==`, `!=`, `<`, `<=`, `>`, `>=`)
- **Logical Operations**: Boolean logic (`AND`, `OR`, `NOT`)
- **Mathematical Functions**: `MIN`, `MAX`, `CEIL`, `FLOOR`, `RAND`
- **Assignment Statements**: Modify SubStat coefficient values

**Example Equations**:
```
// Simple additive bonus
B_PLAYERSPEED = B_PLAYERSPEED 25 +

// Percentage-based modification  
M_GUNDAMAGE = M_GUNDAMAGE 0.15 +

// Complex interdependency
B_HP = B_HP T_PLAYERSPEED 0.1 * +

// Conditional logic
M_PROCRATE = M_PROCRATE T_HP 200 > 0.05 0.02 OR AND +
```

### Evaluation Philosophy
HEL is designed with specific principles that ensure reliable game integration:
- **Deterministic evaluation** to ensure consistent results
- **Session-based calculations** that can be applied to base stats as needed
- **Complex synergies** support through interdependent equation processing
- **Mathematical stability** to prevent calculation errors that could affect gameplay

## Data Flow Overview

The HEL system processes game data through the following pipeline:

```
Asset Files → Data Loading → Equation Processing → SubStat Calculation → Final Stats
```

### 1. Asset File Loading
```
ModsData.asset + StatsData.asset → HELYAMLFile.LoadAsset() → ModsList + StatsList
```

### 2. Mod Selection and Inventory
```
Available Mods + Player Inventory → Dictionary<int, int> (ModID → Count)
```

### 3. Equation Processing  
```
Mod Equations → HEL.PrepareEquation() → Variable Substitution → Tokenization → Parsing
```

### 4. Dependency Resolution
```
Parsed Statements → HELOrdering → Dependency Analysis → Execution Order
```

### 5. SubStat Coefficient Calculation
```
Ordered Statements → HELInterpreter.Execute() → Updated SubStat Coefficients
```

### 6. Final Stat Computation
```
SubStat Coefficients → Stat Formula Application → Final Stat Values
```

The **Stat Formula** combines coefficients using:
```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

Where:
- `S` = Starting value, `B` = Base additive, `M` = Multiplicative percentage
- `A` = Absolute additive, `Z` = Min adjustment, `U` = Max adjustment
- `min`/`max` = Original stat constraints

## Key Terminology Summary

| Term | Definition | Example |
|------|------------|---------|
| **Mod** | Game modification containing equation and values | Lightweight Nanites mod |
| **Stat** | Player characteristic with base value and range | PLAYERSPEED stat |
| **SubStat** | Coefficient variable with prefix indicating modification type | `M_PLAYERSPEED` (multiplicative) |
| **Equation** | HEL expression string defining stat modifications | `M_GUNDAMAGE=-val1` |
| **Coefficient** | Numeric multiplier applied during stat calculation | 0.15 for +15% bonus |
| **VAL/VAL1/VAL2** | Mod value placeholders replaced during processing | `val1` → `0.43` |
| **HEL** | HIOX Equation Language - the mathematical expression system | Overall system name |

## Advanced Features Note

📝 **Development Enhancement**: The HEL language and supporting systems in this development tool include advanced features beyond what currently exists in the HIOX game:

- **Enhanced mathematical precision** with proper floating-point handling
- **Improved dependency resolution** algorithm with cycle detection  
- **Extended operator support** including logical operations and comparison operators
- **Robust error handling** with detailed diagnostic information
- **Performance optimizations** for large mod inventories

Game developers integrating these classes will gain access to these enhanced capabilities, enabling more sophisticated mod designs and better gameplay experiences.

---

## Next Steps

- **[Section 1.2](1-2-Stats-SubStat-System.md)**: Detailed explanation of the Stats and SubStat coefficient system
- **[Section 1.3](1-3-HEL-Syntax.md)**: Complete HEL language syntax reference  
- **[Section 2.1](2-1-Integration-Overview.md)**: Integration workflow for HIOX developers
- **[Section 3.1](3-1-HEL-Class-Reference.md)**: Complete API reference for the HEL class

---

**Document Version:** 1.0  
**Target Audience:** HIOX Game Developers  
**Prerequisites:** Basic understanding of C#/.NET, familiarity with HIOX game architecture  
**Last Updated:** August 1, 2025

---

# 1.2 Stats and SubStat System

The HEL system uses a sophisticated coefficient-based approach to modify game statistics. Understanding the distinction between **Base Stats** and **SubStats** is fundamental to working with HEL equations effectively.

## 1.2.1 Base Stats vs SubStats

**Base Stats** are the fundamental game statistics that directly affect gameplay mechanics. These represent the core attributes that the HIOX game uses to determine player capabilities, such as:

- `HP` - Player's maximum health points
- `PLAYERSPEED` - How fast the player moves
- `GUNDAMAGE` - Damage dealt by projectiles
- `MAXSTAMINA` - Player's maximum stamina points

**SubStats** are coefficient variants of Base Stats that control how modifications are applied. Each Base Stat has multiple associated SubStats that represent different types of modifications. SubStats follow the naming pattern: `<PREFIX>_<STATNAME>`

For example, the Base Stat `HP` has these associated SubStats:
- `S_HP` - Starting HP value coefficient
- `B_HP` - Base additive HP modifier coefficient  
- `A_HP` - Absolute additive HP modifier coefficient
- `M_HP` - Multiplicative HP modifier coefficient
- `Z_HP` - Minimum HP adjustment coefficient
- `U_HP` - Maximum HP adjustment coefficient
- `T_HP` - Final computed HP value (read-only)

## 1.2.2 SubStat Prefix System

Each prefix in the SubStat naming convention represents a specific type of modification coefficient:

| Prefix | Name | Purpose |
|--------|------|---------|
| **S_** | Start | Base stat starting values |
| **B_** | Base | Base additive modifiers applied before multiplication |
| **A_** | Add | Absolute additive modifiers applied after multiplication |
| **M_** | Mult | Multiplicative modifiers (percentage-based) |
| **Z_** | Min | Minimum value adjustments (extends lower bound) |
| **U_** | Max | Maximum value adjustments (extends upper bound) |
| **T_** | Total | Final computed values (READ-ONLY) |

## 1.2.3 Coefficient Types Explained

### 1.2.3.1 S_ (Start) - Starting Values from StatsData.asset
The **S_** coefficients represent the fundamental starting values for each stat before any mod effects are applied. These values are **always derived from the initial Stat definitions in StatsData.asset** and serve as the foundation for all calculations.

```csharp
// S_HP = 100 (taken directly from StatsData.asset HP stat value)
// This represents the original stat value before any mod processing
```

⚠️ **Important**: S_ values are **reset to their StatsData.asset values** each time `HEL.EvaluateMods()` is called. The current game state stat values are ignored - HEL always starts from the original asset definitions.

### 1.2.3.2 B_ (Base) - Base Additive Modifiers from Mod Equations  
The **B_** coefficients are additive modifiers **defined entirely by mod equations**. These represent foundational changes to a stat that should be amplified by any multiplicative effects.

```csharp
// Example: B_HP = B_HP 25 +
// Adds 25 to the base HP, which will be affected by multiplicative modifiers
```

### 1.2.3.3 Terminology Note: "Base" Overloading
⚠️ **Important**: The term "base" is used in two different contexts throughout the HEL system:
- **Base Stats**: Refers to the original stat definitions from StatsData.asset (used to initialize S_ coefficients)
- **Base Substats**: Refers specifically to the B_ coefficient type defined by mod equations

Context usually clarifies the meaning - "baseStats dictionary" typically refers to original stat values, while "base substat" or "B_" refers to the coefficient type.

### 1.2.3.4 A_ (Add) - Absolute Additive Modifiers  
The **A_** coefficients are absolute additive modifiers applied after multiplication. These represent flat bonuses that are not affected by multiplicative modifiers.

```csharp
// Example: A_HP = A_HP 50 +  
// Adds 50 HP as a flat bonus after all multiplicative effects
```

### 1.2.3.5 M_ (Mult) - Multiplicative Modifiers
The **M_** coefficients are multiplicative modifiers expressed as decimal values. A value of 0.1 represents a 10% increase, while -0.2 represents a 20% decrease.

```csharp
// Example: M_DAMAGE = M_DAMAGE 0.15 +
// Increases damage by 15% (multiplies by 1.15)
// Example: M_SPRINTCOST = M_SPRINTCOST 0.50 +  
// Increases sprint cost by 50% (multiplies by 1.50)
```

### 1.2.3.6 Z_ (Min) - Minimum Value Adjustments
The **Z_** coefficients adjust the minimum allowable value for a stat, extending the lower bound beyond the Base Stat's defined minimum.

```csharp
// Example: Z_HP = Z_HP 10 +
// Raises the minimum HP from 0 to 10, preventing HP from dropping below 10
```

### 1.2.3.7 U_ (Max) - Maximum Value Adjustments  
The **U_** coefficients adjust the maximum allowable value for a stat, extending the upper bound beyond the Base Stat's defined maximum.

```csharp
// Example: U_MAXSTAMINA = U_MAXSTAMINA 500 +
// Raises the maximum stamina cap by 500 points
```

### 1.2.3.8 T_ (Total) - Final Computed Values (READ-ONLY)
The **T_** coefficients contain the final computed values after all modifications have been applied. These are read-only and cannot be assigned to in mod equations.

⚠️ **Important Restriction:** T_ prefixed stats are READ-ONLY and will throw an exception if used on the left-hand side of an assignment.

```csharp
// VALID: Check the final computed value
// if T_HP > 50 then ...

// INVALID: Cannot assign to T_ stats  
// T_HP = T_HP 10 +  // This will throw an exception
```

## 1.2.4 Relationship to Final Computation

These coefficients work together in the final stat computation formula (detailed in [Section 1.5](1-5-Stat-Value-Computation.md)):

```
Final Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

### 1.2.4.1 Important: Coefficient Accumulation Behavior
⚠️ **Critical Understanding**: Multiple mod equations may assign values to the same SubStat coefficient. Before the final stat computation occurs, **all values assigned to a given SubStat are accumulated (added together)** by the Coefficient system.

**Example:**
```csharp
// Mod 1: M_DAMAGE = M_DAMAGE 0.10 +  (adds 0.10 to M_DAMAGE)
// Mod 2: M_DAMAGE = M_DAMAGE 0.15 +  (adds 0.15 to M_DAMAGE)  
// Result: M_DAMAGE = 0.25 total before final computation
```

The coefficient types are applied in this specific order:
1. **Accumulation**: All mod equations execute, accumulating values for each coefficient type
2. **S_** and **B_** coefficients are added together to form the base value
3. **M_** coefficients create a multiplication factor applied to the base
4. **A_** coefficients are added as flat bonuses after multiplication  
5. **Z_** coefficients extend the minimum allowable value
6. **U_** coefficients extend the maximum allowable value
7. The result is clamped between the adjusted min/max bounds

## 1.2.5 Example: Multi-Coefficient Mod

Consider a health-boosting mod with this equation:
```
B_HP = B_HP 50 +; M_HP = M_HP 0.15 +
```

This mod affects HP through two coefficient types:
- **B_HP + 50**: Adds 50 to the base HP (applied before multiplication)
- **M_HP + 0.15**: Increases HP by 15% (multiplicative bonus)

If the player starts with 100 HP (S_HP = 100):
1. Base calculation: (100 + 50) = 150
2. Multiplicative effect: 150 * (1 + 0.15) = 150 * 1.15 = 172.5
3. Final HP: 172.5 (assuming no A_, Z_, or U_ modifiers)

The combination of **B_** and **M_** coefficients creates a compounding effect where the flat 50 HP bonus is also amplified by the 15% multiplier.

## 1.2.6 Cross-References

- **[Section 1.5 - Stat Value Computation](1-5-Stat-Value-Computation.md)**: Detailed explanation of how coefficients are applied in the computation formula
- **[Section 1.3 - HEL Syntax](1-3-HEL-Syntax.md)**: Variable naming conventions and assignment syntax
- **[Section 1.4 - HEL Semantics](1-4-HEL-Semantics.md)**: Assignment semantics and LHS restrictions

---

**Next Section:** [1.3 HEL Syntax](1-3-HEL-Syntax.md)  
**Previous Section:** [1.1 Overview & Core Concepts](1-1-Overview-Core-Concepts.md)

---

# 1.3 HEL Language Syntax

This section covers the syntax rules and language elements of the HEL (HIOX Equation Language) used to define mod equations that modify game statistics.

## 1.3.1 Token Types

The HEL lexer recognizes the following token types:

### 1.3.1.1 Numbers
- **Integers**: `42`, `0`, `100`
- **Decimals**: `3.14`, `0.5`, `42.0`
- **Negative Numbers**: `-10`, `-3.14`

### 1.3.1.2 Variables
Variables follow the SubStat format: `<PREFIX>_<STATNAME>`

#### 1.3.1.2.1 Left-Hand Side (LHS) Variables - Assignable
Can be assigned values in assignment statements. Valid prefixes (case insensitive):
- **B**: Buff variables (e.g., `B_HEALTH`, `B_DAMAGE`)
- **A**: Additional variables (e.g., `A_SPEED`, `A_ARMOR`)
- **M**: Mod variables (e.g., `M_CRITICAL`, `M_RANGE`)
- **Z**: Zone variables (e.g., `Z_TEMPERATURE`, `Z_GRAVITY`)
- **U**: User variables (e.g., `U_CUSTOM`, `U_SPECIAL`)

**Valid LHS Examples**:
```hel
B_HEALTH = 100;
M_DAMAGE = S_STRENGTH 2 *;
a_speed = 50;  // Case insensitive
```

#### 1.3.1.2.2 Right-Hand Side (RHS) Variables - Readable
Can be read from in expressions. Valid prefixes (case insensitive):
- **S**: Stat variables (e.g., `S_HEALTH`, `S_DAMAGE`)
- **T**: Temporary variables (e.g., `T_MODIFIER`, `T_BONUS`) - Read-only
- **Z**: Zone variables (e.g., `Z_LEVEL`, `Z_DIFFICULTY`)
- **U**: User variables (e.g., `U_SCORE`, `U_LEVEL`)
- **B**: Buff variables (readable when on RHS)
- **A**: Additional variables (readable when on RHS)
- **M**: Mod variables (readable when on RHS)

**Valid RHS Examples**:
```hel
B_HEALTH = S_MAXHEALTH T_BONUS +;
M_DAMAGE = S_STRENGTH A_WEAPON +;
```

**Important Notes**:
- T_ variables are read-only and cannot appear on the left side of assignments
- Variable names after the underscore must contain only letters
- Case insensitive throughout: `s_health` equals `S_HEALTH`
- VAL and VAL2 constants are replaced with actual mod values before parsing

### 1.3.1.3 Operators

#### 1.3.1.3.1 Arithmetic Operators
- **Addition**: `+`
- **Subtraction**: `-`  
- **Multiplication**: `*`
- **Division**: `/`
- **Exponentiation**: `^` (power)

#### 1.3.1.3.2 Comparison Operators
- **Equal**: `==`
- **Not Equal**: `!=`
- **Less Than**: `<`
- **Less Than or Equal**: `<=`
- **Greater Than**: `>`
- **Greater Than or Equal**: `>=`

#### 1.3.1.3.3 Logical Operators
- **AND**: Logical conjunction
- **OR**: Logical disjunction  
- **NOT**: Logical negation

**Operator Examples**:
```hel
B_DAMAGE = S_STRENGTH 2 * 10 +;
B_HEALTH = S_CONSTITUTION 1.5 ^;
B_ACTIVE = S_LEVEL 5 >= S_HEALTH 0 > AND;
```

### 1.3.1.4 Functions
Built-in mathematical functions:
- **MIN(a, b)**: Returns the smaller of two values
- **MAX(a, b)**: Returns the larger of two values  
- **CEIL(x)**: Rounds up to the nearest integer
- **FLOOR(x)**: Rounds down to the nearest integer
- **RAND()**: Returns a random floating-point value (implementation dependent)

**Function Examples**:
```hel
B_DAMAGE = S_STRENGTH 1 MAX 5 *;
B_HEALTH = S_CONSTITUTION 1.5 * CEIL;
B_CHANCE = RAND 100 * 95 MIN;
```

### 1.3.1.5 Constants
- **TRUE**: Boolean true value
- **FALSE**: Boolean false value

### 1.3.1.6 Assignment Operator
- **Assignment**: `=` - Assigns the result of an expression to a variable

### 1.3.1.7 Statement Terminators
- **Semicolon**: `;` - Explicitly terminates a statement
- **Newline**: Implicitly terminates a statement
- Multiple statements can be chained with semicolons on one line

### 1.3.1.8 Comments
- **Line Comments**: `--` - Everything after `--` on a line is ignored
- Comments automatically add a semicolon to terminate any preceding statement

**Comment Example**:
```hel
B_HEALTH = S_MAXHEALTH;  -- Set health to maximum
-- This is a full line comment
B_DAMAGE = S_STRENGTH;   -- Calculate base damage
```

### 1.3.1.9 Embedded Content
- **Embed Token**: `#!<number>` - References mod IDs for internal processing
- Used internally by the system for mod dependency tracking

**Embed Example**:
```hel
#!42  -- References mod with ID 42
```

## 1.3.2 Assignment Statements

All HEL statements are assignment statements with the format:
```
<LHS_VARIABLE> = <EXPRESSION>;
```

**Valid Statement Examples**:
```hel
B_HEALTH = 100;
M_DAMAGE = S_STRENGTH S_WEAPON_DAMAGE +;
A_SPEED = S_AGILITY 2 * 10 MAX;
B_CRITICAL = S_LUCK 50 >= S_LEVEL 5 > AND;
```

**Invalid Statement Examples**:
```hel
T_READONLY = 50;        -- Error: T_ variables cannot be assigned
S_HEALTH + 10;          -- Error: Missing assignment
= B_HEALTH 10 +;        -- Error: Missing LHS variable
B_HEALTH ;              -- Error: Incomplete expression
```

## 1.3.3 Statement Chaining

Multiple statements can be written on one line separated by semicolons:
```hel
B_HEALTH = 100; B_DAMAGE = 50; B_SPEED = 25;
```

Or on separate lines:
```hel
B_HEALTH = 100;
B_DAMAGE = 50;
B_SPEED = 25;
```

## 1.3.4 Expression Evaluation

- Uses postfix (Reverse Polish Notation) stack-based evaluation
- Operators are written after their operands (e.g., `A B +` instead of `A + B`)
- No need for parentheses as postfix notation eliminates precedence ambiguity

## 1.3.5 Case Sensitivity

HEL is **case insensitive** throughout:
- `B_HEALTH` equals `b_health` equals `B_Health`
- `MAX` equals `max` equals `Max`
- `TRUE` equals `true` equals `True`

## 1.3.6 Syntax Validation

The lexer validates:
- Variable name format (`PREFIX_LETTERS` only)
- Valid prefixes for LHS/RHS context
- Numeric literal format
- Operator recognition
- Keyword recognition

**Common Syntax Errors**:
- Invalid variable prefixes: `X_HEALTH` (X not a valid prefix)
- Invalid variable names: `S_HEALTH123` (numbers not allowed after underscore)
- Multiple underscores: `S_MAX_HEALTH` (only one underscore allowed)
- Assignment to read-only: `T_BONUS = 50` (T_ variables are read-only)

## 1.3.7 Cross-References

- See **Section 1.2** for detailed SubStat variable definitions and categories
- See **Section 1.4** for HEL semantic rules and expression evaluation
- See **Section 2.1** for practical examples of mod equation syntax

---

*For more information about the HIOX game ecosystem and HEL system architecture, refer to the main project documentation.*

---

# 1.4 HEL Language Semantics

This section describes the evaluation semantics of the HEL (HIOX Equation Language) system, covering how statements are ordered, variables are resolved, assignments are performed, and expressions are evaluated.

## 1.4.1 Statement Evaluation Order

The HEL interpreter uses a sophisticated dependency analysis system to determine the optimal execution order for statements across all mods.

### 1.4.1.1 Parsing and Dependency Analysis

1. **Token Parsing**: All equation tokens are first parsed into `Statement` objects using `SplitStatements()`. Each statement contains:
   - A list of tokens representing the assignment expression
   - The original index in the input sequence
   - Mod ID and position within that mod
   - Identified LHS (left-hand side) and RHS (right-hand side) variables

2. **Dependency Graph Construction**: The `Orderer.AnalyzeStatementCycles()` method builds a dependency graph where:
   - Nodes represent statements
   - Edges represent dependencies (statement A assigns to a variable that statement B uses)
   - Variable mappings track which statements assign to and use each SubStat

3. **Cycle Detection**: The system uses depth-first search to identify all simple cycles in the dependency graph:
   - Cycles are normalized to ensure consistent representation
   - Each statement's cycle membership count is tracked
   - Statements with cycle count 0 have no circular dependencies

### 1.4.1.2 Execution Ordering Rules

Statements are executed in the following priority order:

1. **By Cycle Count**: Statements with fewer dependency cycles execute first
   - Cycle count 0: No circular dependencies, can execute safely
   - Cycle count 1+: Involved in circular dependencies, executed later

2. **By Original Index**: Within the same cycle count, statements execute in their original mod order
   - This preserves the intended mod priority from the input sequence
   - Ensures deterministic behavior when multiple execution orders are valid

```csharp
// From HELInterpreter.cs - Interpret() method
for (int cycle = 0; cycle <= max_cycle_count; cycle++) {
    if (ordered_stmts.TryGetValue(cycle, out List<Statement>? stmt_list)) {
        // Sort by original index within each cycle level
        stmt_list.Sort((a, b) => a.Index.CompareTo(b.Index));
        
        foreach (var stmt in stmt_list) {
            // Execute statement
        }
    }
}
```

## 1.4.2 Variable Resolution and Scoping

The HEL system uses a global variable scoping model with coefficient-based storage.

### 1.4.2.1 Global Variable Space

- **All variables are global** across the entire equation evaluation session
- Variables persist between statements and mod evaluations
- No local scoping or function-local variables exist

### 1.4.2.2 SubStat Variable Resolution

SubStat variables (format: `PREFIX_STATNAME`) are resolved through the `CoefDict` coefficient dictionary:

1. **Variable Parsing**: Variable names are split into prefix and stat name components
   - `S_HEALTH` → prefix='S', statname='HEALTH'
   - Case-insensitive matching for stat names

2. **Coefficient Lookup**: The `GetCoefficient()` method retrieves values from the appropriate coefficient:
   ```csharp
   switch (prefix) {
       case 'B': return dict[name].b;  // Base additive
       case 'A': return dict[name].a;  // Absolute additive  
       case 'M': return dict[name].m;  // Multiplicative
       case 'Z': return dict[name].z;  // Minimum adjustment
       case 'U': return dict[name].u;  // Maximum adjustment
       case 'S': return dict[name].s;  // Base stat value
       case 'T': return dict[name].t;  // Temporary modifier
   }
   ```

3. **Error Handling**: Invalid variable names or missing coefficients throw exceptions:
   - `KeyNotFoundException` for undefined stat names
   - `Exception` for invalid prefixes

### 1.4.2.3 Variable Usage Context

- **LHS Variables**: Represent assignment targets (coefficient setters)
  - Only appear on the left side of assignment operators
  - Must use writable prefixes (B_, A_, M_, Z_, U_)

- **RHS Variables**: Represent value sources (coefficient getters)  
  - Can appear anywhere in expressions
  - Can use any valid prefix including read-only (S_, T_)

## 1.4.3 Assignment Semantics

HEL assignments follow the pattern: `LHS_VARIABLE = EXPRESSION`

### 1.4.3.1 LHS Restrictions

The left-hand side has strict prefix restrictions enforced by `SetCoefficient()`:

- **Allowed Prefixes**: B_, A_, M_, Z_, U_ (writable coefficients)
- **Forbidden Prefixes**: S_, T_ (read-only coefficients)
  - S_ prefixes represent base stat values (immutable)
  - T_ prefixes represent temporary modifiers (system-managed)

```csharp
// From SetCoefficient() method
if (prefix == 'S' || prefix == 'T')
    throw new Exception($"S_ and T_ prefixed stats are READ ONLY.");
```

### 1.4.3.2 Assignment Process

1. **LHS Parsing**: The variable token is parsed and validated as a writable SubStat
2. **RHS Evaluation**: The expression is evaluated to a single float value
3. **Coefficient Storage**: The result is stored in the appropriate coefficient slot
4. **Accumulation**: Multiple assignments to the same coefficient are accumulated additively

### 1.4.3.3 Example Assignment Flow

```
B_HEALTH = S_HEALTH 10.0 +    // Add 10 to health base modifier
M_DAMAGE = M_DAMAGE 0.25 +    // Increase damage multiplier by 25%
```

## 1.4.4 Expression Evaluation

HEL uses a postfix (Reverse Polish Notation) stack-based evaluation model.

### 1.4.4.1 Stack-Based Evaluation

The expression evaluator uses a `Stack<float>` to process tokens:

1. **Operand Processing**: Numbers and RHS variables are pushed onto the stack
2. **Operator Processing**: Operators pop required operands and push results
3. **Final Result**: A single value remains on the stack after evaluation

### 1.4.4.2 Expression Parsing Flow

```csharp
// From ParseExpression() method
stmt.Values.Clear();                    // Clear evaluation stack
ParseOperand(stmt, coefs);              // Push first operand
while (!IsExprEnd(NextToken(stmt)))
    ParseExpressionTail(stmt, coefs);   // Process operators and operands
```

### 1.4.4.3 Operator Precedence and Evaluation

Operators are processed in postfix order with stack-based semantics:

#### 1.4.4.3.1 Mathematical Operations
- **Addition (+)**: `b + a` → `stmt.Values.Push(a + b)`
- **Subtraction (-)**: `b - a` → `stmt.Values.Push(b - a)` 
- **Multiplication (*)**: `b * a` → `stmt.Values.Push(a * b)`
- **Division (/)**: `b / a` → `stmt.Values.Push(b / a)` (NaN if a=0)
- **Exponentiation (^)**: `b ^ a` → `stmt.Values.Push(MathF.Pow(b, a))`

#### 1.4.4.3.2 Comparison Operations
- **Equality (==)**: `stmt.Values.Push(MathF.Equals(a, b) ? 1.0f : 0.0f)`
- **Inequality (!=, <>)**: `stmt.Values.Push(MathF.Equals(a, b) ? 0.0f : 1.0f)`
- **Less Than (<)**: `stmt.Values.Push(b < a ? 1.0f : 0.0f)`
- **Greater Than (>)**: `stmt.Values.Push(b > a ? 1.0f : 0.0f)`

#### 1.4.4.3.3 Logical Operations
Logical operations treat 0.0 as false and any non-zero value as true:

- **AND**: `stmt.Values.Push(a * b == 0.0f ? 0.0f : 1.0f)`
- **OR**: `stmt.Values.Push(a + b == 0.0f ? 0.0f : 1.0f)`
- **NOT**: `stmt.Values.Push(a == 0.0f ? 1.0f : 0.0f)` (unary)

#### 1.4.4.3.4 Function Calls
- **Unary Functions**: MAX, MIN, CEIL, FLOOR, NOT (operate on 1 stack value)
- **Binary Functions**: Mathematical and comparison operators (operate on 2 stack values)
- **Nullary Functions**: RAND, TRUE, FALSE (push constant values)

### 1.4.4.4 Expression Evaluation Examples

```
// Expression: S_HEALTH 10.0 2.0 * +  (postfix form)
// Postfix evaluation:
1. Push S_HEALTH value (e.g., 100.0)     → Stack: [100.0]
2. Push 10.0                             → Stack: [100.0, 10.0]  
3. Push 2.0                              → Stack: [100.0, 10.0, 2.0]
4. Execute * (10.0 * 2.0 = 20.0)         → Stack: [100.0, 20.0]
5. Execute + (100.0 + 20.0 = 120.0)      → Stack: [120.0]
// Result: 120.0
```

## 1.4.5 Error Handling

The HEL interpreter implements comprehensive error handling:

### 1.4.5.1 Division by Zero
- Division by zero results in `float.NaN` rather than throwing an exception
- NaN values propagate through subsequent calculations

### 1.4.5.2 Variable Errors  
- **Invalid Variable Names**: Throw `Exception` for malformed or undefined variables
- **Missing Coefficients**: Throw `KeyNotFoundException` for undefined stat names
- **Read-Only Assignment**: Throw `Exception` when attempting to assign to S_ or T_ variables

### 1.4.5.3 Expression Errors
- **Multiple Values**: Throw `Exception` when multiple values remain on stack without operators
- **Missing Values**: Throw `Exception` when expression evaluates to empty stack
- **Invalid Tokens**: Throw `Exception` for unexpected symbols during parsing

### 1.4.5.4 Example Error Scenarios

```csharp
// These will throw exceptions:
S_HEALTH = 100.0        // S_ is read-only
B_INVALID = 50.0        // INVALID stat doesn't exist  
B_HEALTH = 10.0 20.0    // Multiple values without operator
B_HEALTH =              // Missing RHS expression
```

## 1.4.6 Integration with Coefficient System

The HEL semantics work closely with the coefficient-based stat calculation system (see [Section 1.2](1-2-Stats-SubStat-System.md)):

### 1.4.6.1 Coefficient Management
- Each statement evaluation creates a temporary `CoefDict` to store its modifications
- Statement results are accumulated into a master `CoefDict` using the `Add()` method
- Final stat values are computed using the accumulated coefficients

### 1.4.6.2 Final Calculation Integration
The final stat calculation formula integrates all coefficient types:
```
result = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

Where each coefficient (B, A, M, Z, U) is the accumulated result of all HEL assignments to that SubStat.

---

**Cross-References:**
- [Section 1.2: Stats and SubStats System](1-2-Stats-SubStat-System.md) - Coefficient types and final calculation
- [Section 1.3: HEL Syntax](1-3-HEL-Syntax.md) - Token types and grammar rules  
- [Section 1.5: HEL Computation](1-5-HEL-Computation.md) - Mathematical evaluation details
- [Section 1.6: HEL Ordering](1-6-HEL-Ordering.md) - Advanced dependency resolution

---

# 1.5 Stat Value Computation

This section details the core formula used by the HEL interpreter to compute final stat values from coefficient modifications. Understanding this computation process is essential for predicting how mods will affect player statistics in the HIOX game.

## 1.5.1 The Core Formula

The HEL system applies all coefficient modifications using a single, well-defined formula implemented in the `CoefDict.Apply()` method:

```
result = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

This formula ensures a predictable order of operations and handles edge cases like negative multipliers and range constraints systematically.

## 1.5.2 Step-by-Step Computation Process

The formula executes in five distinct steps, each serving a specific purpose:

### 1.5.2.1 Step 1: Calculate Base Value
```
base_value = S + B
```
- Combines the original stat value (S) with base additive modifications (B)
- This happens **before** multiplication, making B coefficients more powerful than A coefficients
- Example: If `S_HEALTH = 100` and `B_HEALTH = 20`, then `base_value = 120`

### 1.5.2.2 Step 2: Apply Multiplier
```
multiplied_value = base_value * Max(0, 1 + M)
```
- Applies percentage-based modifications using the M coefficient
- The `Max(0, ...)` prevents negative multipliers from creating negative stat values
- A multiplier of 0.25 represents a 25% increase (not 25% of original)
- Example: With `M_HEALTH = 0.1` and `base_value = 120`: `multiplied_value = 120 * 1.1 = 132`

### 1.5.2.3 Step 3: Add Absolute Modifier
```
modified_value = multiplied_value + A
```
- Applies flat bonuses after multiplication has been calculated
- A coefficients are less powerful than B coefficients for the same numeric value
- Example: With `A_HEALTH = 15` and `multiplied_value = 132`: `modified_value = 147`

### 1.5.2.4 Step 4: Apply Minimum Constraint
```
constrained_min = Max(modified_value, min + Z)
```
- Ensures the result doesn't fall below the adjusted minimum bound
- Z coefficients can extend the minimum downward (negative Z) or upward (positive Z)
- Example: If stat minimum is 10 and `Z_HEALTH = -5`: effective minimum becomes 5

### 1.5.2.5 Step 5: Apply Maximum Constraint
```
final_result = Min(constrained_min, max + U)
```
- Ensures the result doesn't exceed the adjusted maximum bound
- U coefficients can extend the maximum upward (positive U) or downward (negative U)
- Example: If stat maximum is 200 and `U_HEALTH = 50`: effective maximum becomes 250

## 1.5.3 Coefficient Roles

Each coefficient type serves a distinct purpose in the computation:

### 1.5.3.1 S (Start) - Original Base Stat Value
- **Source**: Loaded from the base Stats asset file (`StatsData.asset`)
- **Purpose**: Represents the unmodified stat value before any mods are applied
- **Access**: Read-only in HEL equations; cannot be modified by mod equations
- **Usage**: `S_HEALTH` returns the original health value defined in the stats file

### 1.5.3.2 B (Base) - Additive Base Modifiers
- **Purpose**: Flat bonuses applied before multiplication
- **Power**: More impactful than A coefficients due to order of operations
- **Usage**: `B_HEALTH = 50` adds 50 to base health before any multipliers are applied
- **Example**: If base health is 100 and multiplier is 20%, B=50 results in (100+50)*1.2=180, while A=50 results in 100*1.2+50=170

### 1.5.3.3 M (Mult) - Multiplicative Modifiers
- **Purpose**: Percentage-based modifications to the base value
- **Format**: Decimal values where 0.1 = 10% increase, -0.5 = 50% reduction
- **Safety**: Negative multipliers are clamped to 0 to prevent negative stat values
- **Usage**: `M_DAMAGE = 0.25` increases damage by 25%
- **Stacking**: Multiple M coefficients from different mods are additive (M=0.1 + M=0.2 = 30% total increase)

### 1.5.3.4 A (Add) - Absolute Additive Modifiers
- **Purpose**: Flat bonuses applied after multiplication
- **Timing**: Applied as the final modification step before range clamping
- **Usage**: `A_SPEED = 10` adds 10 to final speed value
- **Note**: Less powerful than B coefficients for equivalent numeric values

### 1.5.3.5 Z (Min) - Minimum Value Adjustments
- **Purpose**: Modifies the lower bound constraint for the stat
- **Effect**: Positive Z raises the minimum, negative Z lowers it
- **Usage**: `Z_HEALTH = -20` allows health to go 20 points below its normal minimum
- **Application**: Only affects clamping; doesn't directly modify the computed value

### 1.5.3.6 U (Max) - Maximum Value Adjustments  
- **Purpose**: Modifies the upper bound constraint for the stat
- **Effect**: Positive U raises the maximum, negative U lowers it
- **Usage**: `U_MANA = 100` allows mana to exceed its normal maximum by 100 points
- **Application**: Only affects clamping; doesn't directly modify the computed value

## 1.5.4 Range Clamping with Z and U

The Z and U coefficients provide fine-grained control over stat bounds:

### 1.5.4.1 Extending Minimums with Z
```csharp
// If HEALTH has min=0 and Z_HEALTH=-10
effective_minimum = 0 + (-10) = -10
// Now health can go negative (unusual but possible)
```

### 1.5.4.2 Extending Maximums with U  
```csharp
// If MANA has max=100 and U_MANA=50
effective_maximum = 100 + 50 = 150
// Now mana can exceed its normal cap
```

### 1.5.4.3 Combined Range Adjustments
```csharp
// Original stat: min=10, max=100
// With Z_STAT=-5 and U_STAT=25
// New effective range: min=5, max=125
```

## 1.5.5 Worked Examples

### 1.5.5.1 Example 1: Simple Additive Modification
```
Base stat: HEALTH = 100 (min=0, max=200)
Mod equation: B_HEALTH = 50

Step 1: base_value = 100 + 50 = 150
Step 2: multiplied_value = 150 * Max(0, 1 + 0) = 150 * 1 = 150  
Step 3: modified_value = 150 + 0 = 150
Step 4: constrained_min = Max(150, 0 + 0) = 150
Step 5: final_result = Min(150, 200 + 0) = 150

Final HEALTH = 150
```

### 1.5.5.2 Example 2: Multiplicative Modification
```
Base stat: DAMAGE = 50 (min=1, max=999)
Mod equation: M_DAMAGE = 0.25

Step 1: base_value = 50 + 0 = 50
Step 2: multiplied_value = 50 * Max(0, 1 + 0.25) = 50 * 1.25 = 62.5
Step 3: modified_value = 62.5 + 0 = 62.5  
Step 4: constrained_min = Max(62.5, 1 + 0) = 62.5
Step 5: final_result = Min(62.5, 999 + 0) = 62.5

Final DAMAGE = 62.5
```

### 1.5.5.3 Example 3: Combined Coefficient Types
```
Base stat: SPEED = 100 (min=10, max=300)
Mod equations: B_SPEED = 20; M_SPEED = 0.1; A_SPEED = 5

Step 1: base_value = 100 + 20 = 120
Step 2: multiplied_value = 120 * Max(0, 1 + 0.1) = 120 * 1.1 = 132
Step 3: modified_value = 132 + 5 = 137
Step 4: constrained_min = Max(137, 10 + 0) = 137  
Step 5: final_result = Min(137, 300 + 0) = 137

Final SPEED = 137
```

### 1.5.5.4 Example 4: Range Modifications
```
Base stat: HEALTH = 80 (min=0, max=100)  
Mod equations: B_HEALTH = 50; Z_HEALTH = -10; U_HEALTH = 100

Step 1: base_value = 80 + 50 = 130
Step 2: multiplied_value = 130 * Max(0, 1 + 0) = 130
Step 3: modified_value = 130 + 0 = 130
Step 4: constrained_min = Max(130, 0 + (-10)) = Max(130, -10) = 130
Step 5: final_result = Min(130, 100 + 100) = Min(130, 200) = 130

Final HEALTH = 130 (exceeded original max of 100 due to U_HEALTH)
```

### 1.5.5.5 Example 5: Complex Multi-Coefficient Calculation
```
Base stat: MANA = 50 (min=0, max=200)
Mod equations: B_MANA = 30; M_MANA = 0.4; A_MANA = 15; Z_MANA = -5; U_MANA = 50

Step 1: base_value = 50 + 30 = 80
Step 2: multiplied_value = 80 * Max(0, 1 + 0.4) = 80 * 1.4 = 112
Step 3: modified_value = 112 + 15 = 127
Step 4: constrained_min = Max(127, 0 + (-5)) = Max(127, -5) = 127
Step 5: final_result = Min(127, 200 + 50) = Min(127, 250) = 127

Final MANA = 127
```

### 1.5.5.6 Example 6: Negative Multiplier Clamping
```
Base stat: ARMOR = 25 (min=0, max=100)
Mod equation: M_ARMOR = -1.5  // Extreme negative multiplier

Step 1: base_value = 25 + 0 = 25
Step 2: multiplied_value = 25 * Max(0, 1 + (-1.5)) = 25 * Max(0, -0.5) = 25 * 0 = 0
Step 3: modified_value = 0 + 0 = 0
Step 4: constrained_min = Max(0, 0 + 0) = 0
Step 5: final_result = Min(0, 100 + 0) = 0

Final ARMOR = 0 (multiplier clamped to prevent negative result)
```

## 1.5.6 Important Notes

### 1.5.6.1 Negative Multiplier Protection
The formula includes `Max(0, 1 + M)` specifically to prevent negative stat values from multiplication. Even extreme negative multipliers (like M = -2.0) will result in a multiplier of 0, not negative values.

### 1.5.6.2 Order of Operations Significance  
The distinction between B and A coefficients is crucial:
- **B coefficients** are applied before multiplication, making them more powerful
- **A coefficients** are applied after multiplication, providing flat bonuses

For equivalent numeric values, B coefficients will always produce larger final results when positive multipliers are present.

### 1.5.6.3 Range Adjustments vs. Direct Modification
Z and U coefficients **only** affect the final clamping bounds. They do not directly participate in the mathematical computation of the stat value. This design allows mods to adjust what values are considered "valid" without interfering with the core calculation.

### 1.5.6.4 Coefficient Accumulation
When multiple mods affect the same SubStat, their coefficient values are **added together** before applying the formula. This means:
- Two mods with `B_HEALTH = 20` each result in a total `B_HEALTH = 40`
- Two mods with `M_DAMAGE = 0.1` each result in a total `M_DAMAGE = 0.2` (20% increase, not 10% then another 10%)

## 1.5.7 Cross-References

- **[Section 1.2: Stats and SubStat System](1-2-Stats-SubStat-System.md)** - Detailed explanation of coefficient types and SubStat naming conventions
- **[Section 1.4: HEL Semantics](1-4-HEL-Semantics.md)** - Statement evaluation order and assignment semantics that feed into this computation
- **[Section 1.6: Dependency Resolution & Ordering](1-6-Dependency-Resolution-Ordering.md)** - How statement execution order affects coefficient accumulation

## 1.5.8 Implementation Reference

The computation formula is implemented in the `CoefDict.Apply()` method in `HELInterpreter.cs` (lines 147-158). The individual coefficient values are managed by the `Coefficient` class (lines 35-87) and accessed through the `CoefDict.GetCoefficient()` and `CoefDict.SetCoefficient()` methods.

---

# 1.6 Dependency Resolution and Ordering

This section describes the HEL system's sophisticated dependency resolution algorithm implemented in `HELOrdering.cs`. The system analyzes variable dependencies between statements, detects circular dependencies, and determines optimal execution order to minimize unresolved dependencies during mod evaluation.

## 1.6.1 Overview

When multiple mods contain equations that reference each other's variables, the order of execution becomes critical. The HEL ordering system solves this challenge by:

1. **Building a dependency graph** from variable assignments and usages
2. **Detecting circular dependencies** using depth-first search algorithms  
3. **Grouping statements** by their involvement in dependency cycles
4. **Ordering execution** to minimize unresolved dependencies

The system is implemented primarily in the `Orderer.AnalyzeStatementCycles()` method, which returns statements grouped by their cycle membership count.

## 1.6.2 Statement Dependency Analysis

### 1.6.2.1 LHS and RHS Variable Identification

The dependency analysis begins by identifying how each statement interacts with variables:

```csharp
// Example statements showing dependency relationships
B_HEALTH = S_HEALTH 10.0 +     // Assigns to B_HEALTH, reads from S_HEALTH
M_DAMAGE = B_HEALTH 0.1 *      // Assigns to M_DAMAGE, reads from B_HEALTH  
A_HEALTH = M_DAMAGE 5.0 +      // Assigns to A_HEALTH, reads from M_DAMAGE
```

**Left-Hand Side (LHS) Variables:**
- Represent assignment targets (what the statement modifies)
- Identified by `TokenType.LHSVariable` tokens before assignment operators
- Stored in `Statement.LHSVariable` property
- Create outgoing dependencies to statements that use this variable

**Right-Hand Side (RHS) Variables:**
- Represent value sources (what the statement reads)
- Identified by `TokenType.RHSVariable` tokens in expressions
- Stored in `Statement.RHSVariables` list
- Create incoming dependencies from statements that assign to these variables

### 1.6.2.2 Dependency Graph Construction

The algorithm builds a directed graph where:
- **Nodes** represent individual statements
- **Edges** represent dependencies: "Statement A assigns to a variable that Statement B uses"

```csharp
// Step 1: Initialize empty graph
var graph = new Dictionary<Statement, List<Statement>>();

// Step 2: Map variables to their assignment and usage statements
var variableAssignments = new Dictionary<string, List<Statement>>();
var variableUsages = new Dictionary<string, List<Statement>>();

// Step 3: Add edges for each variable
foreach (var varName in variableAssignments.Keys)
{
    foreach (var assign in variableAssignments[varName])
    {
        foreach (var use in variableUsages[varName])
        {
            if (assign != use)
                graph[assign].Add(use);  // assign → use dependency
        }
    }
}
```

### 1.6.2.3 Variable-to-Statement Mapping

The system uses case-insensitive dictionaries to map variable names to the statements that interact with them:

**Assignment Mapping:**
```csharp
if (stmt.LHSVariable != null)
{
    var varName = stmt.LHSVariable.Value;
    variableAssignments[varName].Add(stmt);
}
```

**Usage Mapping:**
```csharp
foreach (var rhs in stmt.RHSVariables)
{
    var varName = rhs.Value;
    variableUsages[varName].Add(stmt);
}
```

This creates bidirectional variable tracking that enables comprehensive dependency analysis across all statements.

## 1.6.3 Cycle Detection Algorithm

### 1.6.3.1 Depth-First Search Implementation

The cycle detection uses a sophisticated DFS algorithm that identifies all simple cycles in the dependency graph:

```csharp
void DFS(Statement current, HashSet<Statement> recStack)
{
    visited.Add(current);
    recStack.Add(current);
    stack.Push(current);

    foreach (var neighbor in graph[current])
    {
        if (!recStack.Contains(neighbor))
        {
            if (!visited.Contains(neighbor))
                DFS(neighbor, recStack);
        }
        else
        {
            // Found a cycle: current → ... → neighbor
            var cycle = stack.Reverse().SkipWhile(s => s != neighbor).ToList();
            // Process cycle...
        }
    }

    recStack.Remove(current);
    stack.Pop();
}
```

**Key Components:**
- **`visited`**: Tracks globally visited statements to avoid redundant searches
- **`recStack`**: Tracks statements in the current recursion path to detect back edges
- **`stack`**: Maintains the current path for cycle reconstruction

### 1.6.3.2 Cycle Detection Process

1. **Back Edge Identification**: When DFS encounters a statement already in the recursion stack, a cycle is detected
2. **Cycle Reconstruction**: The cycle is extracted from the path stack starting from the target statement
3. **Cycle Validation**: Only cycles with more than one statement are considered valid
4. **Duplicate Prevention**: Cycle signatures prevent counting the same cycle multiple times

### 1.6.3.3 Cycle Signature Normalization

To avoid counting the same cycle multiple times when starting DFS from different nodes, the system normalizes cycle representations:

```csharp
List<Statement> NormalizeCycle(List<Statement> cycle)
{
    int minIndex = cycle.Select((stmt, i) => (stmt.Index, i)).Min().i;
    return cycle.Skip(minIndex).Concat(cycle.Take(minIndex)).ToList();
}

string GetCycleSignature(List<Statement> cycle)
{
    var norm = NormalizeCycle(cycle);
    return string.Join("->", norm.Select(s => s.Index));
}
```

**Normalization Rules:**
- Cycles are rotated so the statement with the minimum index appears first
- This ensures cycles like `[A→B→C→A]` and `[B→C→A→B]` have identical signatures
- Signatures use statement indices joined by arrows (e.g., "5->12->23->5")

### 1.6.3.4 Cycle Counting and Membership

Each statement's involvement in cycles is tracked using a membership count:

```csharp
var cycleMembershipCount = new Dictionary<Statement, int>();

// When a unique cycle is found:
foreach (var s in cycle)
    cycleMembershipCount[s]++;
```

**Membership Count Meanings:**
- **Count = 0**: Statement participates in no cycles (no circular dependencies)
- **Count = 1**: Statement participates in exactly one cycle
- **Count > 1**: Statement participates in multiple overlapping cycles (complex dependencies)

## 1.6.4 HELOrdering Algorithm

### 1.6.4.1 Grouping by Cycle Membership

After cycle detection, statements are grouped by their cycle membership count:

```csharp
var grouped = new Dictionary<int, List<Statement>>();
foreach (var kvp in cycleMembershipCount)
{
    int count = kvp.Value;
    if (!grouped.ContainsKey(count))
        grouped[count] = new List<Statement>();
    grouped[count].Add(kvp.Key);
}
```

This grouping enables the execution ordering strategy that minimizes dependency conflicts.

### 1.6.4.2 Execution Order Strategy

The HEL interpreter executes statement groups in ascending order of cycle membership count:

```csharp
// From HELInterpreter.cs
for (int cycle = 0; cycle <= max_cycle_count; cycle++) {
    if (ordered_stmts.TryGetValue(cycle, out List<Statement>? stmt_list)) {
        // Sort by original index within each cycle level
        stmt_list.Sort((a, b) => a.Index.CompareTo(b.Index));
        
        foreach (var stmt in stmt_list) {
            // Execute statement
        }
    }
}
```

**Ordering Rationale:**
1. **Cycle Count 0 First**: Statements with no circular dependencies can execute safely
2. **Fewer Cycles Next**: Statements with minimal cycle involvement have fewer potential conflicts
3. **Complex Cycles Last**: Statements in multiple cycles face the most dependency conflicts

### 1.6.4.3 Within-Group Ordering

Within each cycle membership group, statements execute in their original order (by `Statement.Index`):
- Preserves intended mod priority from the input sequence
- Ensures deterministic behavior when multiple execution orders would be valid
- Maintains consistency with user expectations about mod loading order

## 1.6.5 Cycle Breaking Strategy

### 1.6.5.1 No Explicit Cycle Breaking

The HEL ordering system does **not** explicitly break cycles by removing dependencies. Instead, it relies on execution order to minimize the impact of unresolved dependencies:

```csharp
// The system does NOT do this:
// if (cycleDetected) RemoveDependency(weakestEdge);

// Instead, it does this:
// Execute statements with fewer cycle involvements first
```

**Why No Explicit Breaking:**
- Preserves the mathematical integrity of all equations
- Avoids making arbitrary decisions about which dependencies to ignore
- Allows equations to converge through iterative execution if needed

### 1.6.5.2 Execution Order as Cycle Mitigation

The ordering strategy minimizes but does not eliminate cycle effects:

1. **Statements with 0 cycles** execute first and establish baseline values
2. **Statements with 1 cycle** execute next with most dependencies already resolved
3. **Statements with multiple cycles** execute last, potentially seeing incomplete dependencies

## 1.6.6 Impact on Final Stat Values

### 1.6.6.1 Convergence Characteristics

The cycle handling approach affects how final stat values are computed:

**Complete Resolution (Cycle Count 0):**
```csharp
// These statements will see all dependencies resolved:
B_HEALTH = S_HEALTH 10.0 +        // No dependencies on other mod outputs
M_DAMAGE = S_STRENGTH 0.5 *       // Only depends on base stats
```

**Partial Resolution (Cycle Count > 0):**
```csharp
// These statements may not see all dependencies on first execution:
B_HEALTH = M_DAMAGE 10.0 +        // May execute before M_DAMAGE is fully computed
M_DAMAGE = B_HEALTH 0.1 *         // Creates circular dependency with above
```

### 1.6.6.2 Dependency Incompleteness Effects

When statements in cycles execute, some dependencies may not be fully resolved:

1. **First Pass Execution**: Some RHS variables may have default/incomplete values
2. **Accumulative Effects**: Multiple assignments to the same coefficient accumulate additively
3. **Final Calculation**: The final stat computation uses accumulated coefficient values

**Example Scenario:**
```csharp
// Cycle: B_HEALTH ↔ M_DAMAGE
B_HEALTH = M_DAMAGE 10.0 +    // M_DAMAGE might be 0 on first execution
M_DAMAGE = B_HEALTH 0.1 *     // B_HEALTH includes the +10 from above

// Execution order affects convergence:
// Order 1: B_HEALTH=10, then M_DAMAGE=1
// Order 2: M_DAMAGE=0, then B_HEALTH=10
```

### 1.6.6.3 Predictability and Determinism

The ordering system ensures predictable results:
- **Deterministic Order**: Same input always produces same execution sequence
- **Consistent Grouping**: Cycle analysis produces consistent membership counts
- **Stable Convergence**: While some cycles may not fully resolve, results remain stable

## 1.6.7 Execution Order Optimization

### 1.6.7.1 Priority-Based Execution

The multi-level execution approach optimizes dependency resolution:

```csharp
// Level 0: No cycles (optimal execution)
B_HEALTH = S_HEALTH 10.0 +
M_STRENGTH = S_STRENGTH 1.2 *

// Level 1: Simple cycles (mostly resolved dependencies)  
A_DAMAGE = B_HEALTH M_STRENGTH +
B_DEFENSE = A_DAMAGE 0.5 *

// Level 2+: Complex cycles (potentially incomplete dependencies)
B_HEALTH = A_DAMAGE B_DEFENSE +
A_DAMAGE = B_HEALTH 0.3 *
B_DEFENSE = B_HEALTH A_DAMAGE +
```

### 1.6.7.2 Optimization Benefits

1. **Maximized Resolution**: Most statements execute with complete dependency information
2. **Minimized Conflicts**: Complex cycles are deferred until simpler dependencies are resolved
3. **Preserved Intent**: Original mod order is maintained within each complexity level

## 1.6.8 Example Dependency Scenarios

### 1.6.8.1 Simple Linear Dependencies

```csharp
// Statements:
[0] B_HEALTH = S_HEALTH 10.0 +      // LHS: B_HEALTH, RHS: S_HEALTH
[1] M_DAMAGE = B_HEALTH 0.1 *       // LHS: M_DAMAGE, RHS: B_HEALTH
[2] A_ARMOR = M_DAMAGE 5.0 +        // LHS: A_ARMOR, RHS: M_DAMAGE

// Dependency Graph:
// [0] → [1] → [2]  (linear chain)

// Cycle Analysis:
// No cycles detected, all statements have cycle count 0

// Execution Order:
// Level 0: [0], [1], [2] (in original order)
```

### 1.6.8.2 Simple Cycle Example

```csharp
// Statements:
[0] B_HEALTH = M_DAMAGE 10.0 +      // LHS: B_HEALTH, RHS: M_DAMAGE
[1] M_DAMAGE = B_HEALTH 0.1 *       // LHS: M_DAMAGE, RHS: B_HEALTH

// Dependency Graph:
// [0] → [1] → [0]  (simple cycle)

// Cycle Detection:
// Cycle found: [0] → [1] → [0]
// Both statements have cycle count 1

// Execution Order:
// Level 1: [0], [1] (in original order, dependencies may be incomplete)
```

### 1.6.8.3 Complex Multi-Cycle Example

```csharp
// Statements:
[0] B_HEALTH = S_HEALTH 10.0 +      // No cycles
[1] M_DAMAGE = B_HEALTH 0.2 *       // No cycles  
[2] A_ARMOR = M_DAMAGE B_DEFENSE +  // Cycle 1: involves B_DEFENSE
[3] B_DEFENSE = A_ARMOR 0.5 *       // Cycle 1: involves A_ARMOR
[4] Z_HEALTH = A_ARMOR B_DEFENSE +  // Cycle 1: involves both A_ARMOR and B_DEFENSE
[5] U_DAMAGE = Z_HEALTH A_ARMOR +   // Cycle 1 + potential others

// Cycle Analysis:
// Cycle 1: [2] → [3] → [2] (A_ARMOR ↔ B_DEFENSE)
// [2], [3]: cycle count 1
// [4]: cycle count 1 (uses cycle 1 variables)
// [5]: cycle count 1 (uses cycle 1 variables)

// Execution Order:
// Level 0: [0], [1] (no dependencies on cycles)
// Level 1: [2], [3], [4], [5] (all in original order)
```

## 1.6.9 Integration with HEL Interpreter

The ordering system integrates seamlessly with the main HEL interpreter:

```csharp
// From HELInterpreter.cs - Interpret() method
var ordered_stmts = Orderer.AnalyzeStatementCycles(all_statements);
int max_cycle_count = ordered_stmts.Keys.Count > 0 ? ordered_stmts.Keys.Max() : -1;

for (int cycle = 0; cycle <= max_cycle_count; cycle++) {
    if (ordered_stmts.TryGetValue(cycle, out List<Statement>? stmt_list)) {
        stmt_list.Sort((a, b) => a.Index.CompareTo(b.Index));
        
        foreach (var stmt in stmt_list) {
            try {
                ParseStatement(stmt, main_coefs);
            } catch (Exception ex) {
                // Handle execution errors
            }
        }
    }
}
```

This integration ensures that:
- All statements are executed in optimal dependency order
- Error handling preserves execution of remaining statements
- Coefficient accumulation works correctly across execution levels

## 1.6.10 Vertex Tuple System

The HEL system uses `Vertex` tuples to represent statement coordinates:

```csharp
using Vertex = System.Tuple<int, int>;

public Vertex GetVertex()
{
    return new Vertex(ModID, ModPos);
}
```

**Vertex Components:**
- **ModID**: Identifies which mod contains the statement
- **ModPos**: Position within that mod's equation sequence

This coordinate system enables:
- Precise identification of statements during dependency analysis
- Debugging support for tracking statement origins
- Cross-referencing between dependency graphs and mod definitions

---

**Cross-References:**
- [Section 1.4: HEL Semantics](1-4-HEL-Semantics.md) - Statement evaluation and execution flow
- [Section 1.7: HEL Examples](1-7-HEL-Examples.md) - Practical examples of dependency scenarios
- [Section 1.5: Stat Value Computation](1-5-Stat-Value-Computation.md) - How resolved dependencies affect final calculations

---

# 1.7 HEL Language Examples

This section provides comprehensive examples of HEL (HIOX Equation Language) equations, demonstrating various modification patterns, complex interactions, and edge cases that HIOX game developers may encounter when creating mods.

## 1.7.1 Simple Mod Equations

### 1.7.1.1 Single-Stat Modifications

The most basic mod equations modify a single stat using one coefficient type.

#### 1.7.1.1.1 Base Additive Modification
```hel
B_HEALTH = B_HEALTH 50 +
```
**Before processing**: Base health = 100  
**Coefficient changes**: B_HEALTH = 0 → 50  
**Final calculation**: Min(Max((100 + 50) * 1 + 0, 0), 200) = 150  
**Result**: HEALTH increases from 100 to 150

#### 1.7.1.1.2 Multiplicative Modification
```hel  
M_DAMAGE = 0.25
```
**Before processing**: Base damage = 40  
**Coefficient changes**: M_DAMAGE = 0 → 0.25  
**Final calculation**: Min(Max((40 + 0) * 1.25 + 0, 1), 999) = 50  
**Result**: DAMAGE increases from 40 to 50 (25% increase)

#### 1.7.1.1.3 Range Extension
```hel
U_HEALTH = 100
```
**Before processing**: HEALTH max = 200  
**Coefficient changes**: U_HEALTH = 0 → 100  
**Final calculation**: Effective max becomes 200 + 100 = 300  
**Result**: HEALTH can now exceed 200, up to 300

### 1.7.1.2 Multiple Coefficient Types

Mods commonly affect the same stat through different coefficient types simultaneously.

#### 1.7.1.2.1 Example: Damage Boost Mod
```hel
B_DAMAGE = 20; M_DAMAGE = 0.15; A_DAMAGE = 5
```

**VAL Substitution** (assuming mod.val = 30, mod.val2 = 0.75):
```hel
B_DAMAGE = 20; M_DAMAGE = 0.15; A_DAMAGE = 5
```

**Step-by-step evaluation**:
- Base DAMAGE = 50 (min=1, max=999)
- B_DAMAGE: 0 → 20
- M_DAMAGE: 0 → 0.15  
- A_DAMAGE: 0 → 5

**Final calculation**:
```
Step 1: base_value = 50 + 20 = 70
Step 2: multiplied_value = 70 * (1 + 0.15) = 70 * 1.15 = 80.5
Step 3: modified_value = 80.5 + 5 = 85.5
Step 4: constrained_min = Max(85.5, 1) = 85.5
Step 5: final_result = Min(85.5, 999) = 85.5
```
**Result**: DAMAGE = 85.5 (was 50)

### 1.7.1.3 Using VAL Substitution

Mods frequently use VAL, VAL1, and VAL2 placeholders that get replaced during processing.

#### 1.7.1.3.1 VAL Substitution Example
**Original mod equation**: 
```hel
B_HEALTH = B_HEALTH VAL +; M_SPEED = VAL2
```

**Mod values**: val = 25.5, val2 = 0.1

**After VAL substitution**:
```hel
B_HEALTH = B_HEALTH 25.5 +; M_SPEED = 0.1
```

**Processing**:
- B_HEALTH increases by 25.5
- M_SPEED set to 0.1 (10% speed increase)

#### 1.7.1.3.2 Complex VAL Usage
**Original mod equation**:
```hel
M_GUNDAMAGE = -VAL1; M_PROCRATE = VAL2
```

**Mod values**: val = 0.2, val2 = 1.5

**After substitution**:
```hel
M_GUNDAMAGE = -0.2; M_PROCRATE = 1.5
```

**Result**: 20% reduction in gun damage, 150% increase in proc rate

### 1.7.1.4 Range Modifications

Range coefficient modifications allow stats to exceed their normal bounds.

#### 1.7.1.4.1 Extending Minimums and Maximums
```hel
Z_HEALTH = -10; U_HEALTH = 100
```

**Original HEALTH**: value=80, min=0, max=100

**After processing**:
- Effective minimum: 0 + (-10) = -10 (health can go negative)
- Effective maximum: 100 + 100 = 200 (health can exceed normal cap)

**Use case**: Allows temporary health penalties below 0, and bonus health above 100

## 1.7.2 Multi-Stat Interdependencies (No Cycles)

More complex mods create relationships between different stats without forming dependency cycles.

### 1.7.2.1 Stats Referencing Other Stats

#### 1.7.2.1.1 Strength-Based Health Scaling
```hel
B_MAXHEALTH = S_STRENGTH 2 *
```

**Processing**:
- If S_STRENGTH = 15, then B_MAXHEALTH = 30
- Final MAXHEALTH calculation includes this base bonus
- Creates scaling where stronger characters have more health

#### 1.7.2.1.2 Level-Based Damage Calculation  
```hel
B_DAMAGE = S_LEVEL 3 *; A_ACCURACY = S_LEVEL
```

**For S_LEVEL = 8**:
- B_DAMAGE = 24 (base damage bonus)
- A_ACCURACY = 8 (flat accuracy bonus)
- Higher level characters deal more damage and have better accuracy

### 1.7.2.2 Conditional Modifications

HEL supports conditional logic using AND/OR operators and comparison functions.

#### 1.7.2.2.1 Armor-Speed Tradeoff
```hel
B_SPEED = S_ARMOR 50 < 10 0 OR AND
```

**Evaluation**:
- If S_ARMOR = 30: condition is true, B_SPEED = 10
- If S_ARMOR = 75: condition is false, B_SPEED = 0
- Light armor characters get speed bonus, heavy armor characters don't

#### 1.7.2.2.2 Damage Cap Based on Level
```hel
A_DAMAGE = S_LEVEL 10 > S_LEVEL 5 * 100 MIN S_LEVEL 2 * OR AND
```

**For different levels**:
- S_LEVEL = 5: A_DAMAGE = 5 * 2 = 10
- S_LEVEL = 15: A_DAMAGE = MIN(75, 100) = 75  
- S_LEVEL = 25: A_DAMAGE = MIN(125, 100) = 100

### 1.7.2.3 Mathematical Functions

HEL provides various mathematical functions for complex calculations.

#### 1.7.2.3.1 Damage Scaling with Diminishing Returns
```hel
A_DAMAGE = S_LEVEL 3 * 100 MIN
```

**Result**: Damage bonus increases with level but caps at 100

#### 1.7.2.3.2 Dynamic Range Calculation
```hel
B_RANGE = S_ACCURACY 10 / 5 MAX
```

**Result**: Range scales with accuracy but has minimum value of 5

#### 1.7.2.3.3 Complex Stat Interaction
```hel
M_CRITCHANCE = S_LUCK 0.02 * 0.5 MIN; B_CRITDAMAGE = S_STRENGTH
```

**For S_LUCK = 30, S_STRENGTH = 12**:
- M_CRITCHANCE = MIN(0.6, 0.5) = 0.5 (50% crit chance cap)
- B_CRITDAMAGE = 12 (strength-based crit damage)

## 1.7.3 Complex Dependency Cycles

When mod equations create circular dependencies, the HEL interpreter must resolve them through iterative processing.

### 1.7.3.1 Simple 2-Stat Cycle

#### 1.7.3.1.1 Mutual Enhancement Cycle
```hel
B_OFFENSE = S_DEFENSE 0.1 *; B_DEFENSE = S_OFFENSE 0.1 *
```

**Initial state**:
- S_OFFENSE = 50, S_DEFENSE = 40
- B_OFFENSE = 0, B_DEFENSE = 0

**Cycle resolution**:

**Iteration 1**:
- B_OFFENSE = 40 * 0.1 = 4
- B_DEFENSE = 50 * 0.1 = 5
- T_OFFENSE = 54, T_DEFENSE = 45

**Iteration 2**:
- B_OFFENSE = 45 * 0.1 = 4.5
- B_DEFENSE = 54 * 0.1 = 5.4  
- T_OFFENSE = 54.5, T_DEFENSE = 45.4

**Continues until convergence...**

**Final stable result**:
- T_OFFENSE ≈ 55, T_DEFENSE ≈ 45.5

### 1.7.3.2 Multi-Stat Cycle (3+ Stats)

#### 1.7.3.2.1 Complex Attribute Interaction
```hel
B_STRENGTH = S_AGILITY 0.2 *; 
B_AGILITY = S_INTELLIGENCE 0.15 *;
B_INTELLIGENCE = S_STRENGTH 0.1 *
```

**Initial values**: S_STRENGTH = 20, S_AGILITY = 15, S_INTELLIGENCE = 25

**Iterative resolution**:

**Iteration 1**:
- B_STRENGTH = 15 * 0.2 = 3 → T_STRENGTH = 23
- B_AGILITY = 25 * 0.15 = 3.75 → T_AGILITY = 18.75  
- B_INTELLIGENCE = 20 * 0.1 = 2 → T_INTELLIGENCE = 27

**Iteration 2**:
- B_STRENGTH = 18.75 * 0.2 = 3.75 → T_STRENGTH = 23.75
- B_AGILITY = 27 * 0.15 = 4.05 → T_AGILITY = 19.05
- B_INTELLIGENCE = 23 * 0.1 = 2.3 → T_INTELLIGENCE = 27.3

**Converges to final stable values after several iterations**

### 1.7.3.3 Self-Referential Statements

#### 1.7.3.3.1 Compound Interest Style Growth
```hel
M_HEALTH = M_HEALTH 0.05 +
```

**Processing**:
- Initial M_HEALTH = 0
- After statement: M_HEALTH = 0 + 0.05 = 0.05
- This creates a 5% health increase that compounds with other M_HEALTH modifications

#### 1.7.3.3.2 Recursive Stat Building
```hel
B_DAMAGE = B_DAMAGE 1.1 * S_LEVEL +
```

**For S_LEVEL = 10**:
- Iteration 1: B_DAMAGE = 0 * 1.1 + 10 = 10
- Iteration 2: B_DAMAGE = 10 * 1.1 + 10 = 21  
- Iteration 3: B_DAMAGE = 21 * 1.1 + 10 = 33.1
- Continues until convergence...

## 1.7.4 Edge Cases and Troubleshooting

### 1.7.4.1 Division by Zero Handling

#### 1.7.4.1.1 Safe Division Implementation
```hel
M_DAMAGE = S_ARMOR 0 > S_STRENGTH S_ARMOR / 0 OR AND
```

**Protection**: Only performs division when S_ARMOR > 0, otherwise defaults to 0

#### 1.7.4.1.2 Alternative Safe Division
```hel
A_BONUS = S_LEVEL S_DIFFICULTY 1 MAX /
```

**Protection**: Ensures denominator is at least 1, preventing division by zero

### 1.7.4.2 Invalid Variable References

#### 1.7.4.2.1 Undefined Stat Reference
```hel
B_HEALTH = S_NONEXISTENT 50 +
```

**Error**: HEL interpreter will throw an exception for undefined variable S_NONEXISTENT

**Debugging**: Check that all referenced stats exist in StatsData.asset

#### 1.7.4.2.2 Typo in Stat Name
```hel  
B_HEALT = 100  // Missing 'H' in HEALTH
```

**Error**: Creates unintended SubStat B_HEALT instead of B_HEALTH

**Prevention**: Use consistent naming and validate against stat definitions

### 1.7.4.3 Assignment to Read-Only Variables

#### 1.7.4.3.1 Attempting to Modify S_ Variables
```hel
S_HEALTH = 200  // ERROR: S_ variables are read-only
```

**Error**: HEL interpreter rejects attempts to assign to S_ prefixed variables

**Correct approach**: Use B_, A_, M_, Z_, or U_ coefficients instead

#### 1.7.4.3.2 Attempting to Modify T_ Variables  
```hel
T_DAMAGE = 150  // ERROR: T_ variables are computed values
```

**Error**: T_ variables represent final computed values and cannot be directly assigned

### 1.7.4.4 Negative Multiplier Clamping

#### 1.7.4.4.1 Extreme Negative Multiplier
```hel
M_HEALTH = -2.0
```

**Processing**:
- Final multiplier = Max(0, 1 + (-2.0)) = Max(0, -1.0) = 0
- Health effectively becomes 0 after multiplication
- Prevents negative health values from multiplication

#### 1.7.4.4.2 Boundary Case Testing
```hel
M_SPEED = -0.99  // Just under complete negation
```

**Result**: Multiplier = Max(0, 1 + (-0.99)) = 0.01 (1% of original speed)

### 1.7.4.5 Complex Expression Evaluation

#### 1.7.4.5.1 Order of Operations Verification
```hel
B_DAMAGE = S_STRENGTH 2 * S_LEVEL 5 / +
```

**For S_STRENGTH = 15, S_LEVEL = 20**:
- Evaluation: 15 2 * 20 5 / + = 30 4 + = 34
- Standard mathematical precedence applies

#### 1.7.4.5.2 Parentheses for Clarity
```hel
M_ACCURACY = S_INTELLIGENCE S_PERCEPTION + S_MAXLEVEL /
```

**Clearer expression**: Ensures addition happens before division

## 1.7.5 Complete Mod Examples

### 1.7.5.1 Lightweight Luckyshot Nanites (Mod ID 0)

**From ModsData.asset**:
```yaml
val: 0.4349492
val2: 1.8630445  
equation: M_GUNDAMAGE=-val1;M_PROCRATE=val2
```

**After VAL substitution**:
```hel
M_GUNDAMAGE = -0.4349492; M_PROCRATE = 1.8630445
```

**Effects**:
- Gun damage reduced by ~43.5%
- Proc rate increased by ~186.3%
- Tradeoff: Lower damage for much higher special effect triggers

**Before/After Stats** (assuming base values):
- GUNDAMAGE: 50 → 50 * (1 + (-0.435)) = 50 * 0.565 = 28.25
- PROCRATE: 0.1 → 0.1 * (1 + 1.863) = 0.1 * 2.863 = 0.286

### 1.7.5.2 Multi-Bullet Explosive Mod (Mod ID 15)

**From ModsData.asset**:
```yaml
val: 2.5
val2: 1.8
equation: B_BULLETSFIRED=val2;B_EXPLOSIONRADIUS=val1
```

**After VAL substitution**:
```hel
B_BULLETSFIRED = 1.8; B_EXPLOSIONRADIUS = 2.5
```

**Effects**:
- Fires 1.8 additional bullets per shot
- Increases explosion radius by 2.5 units
- Transforms single-shot weapons into multi-projectile explosives

**Stat Changes**:
- BULLETSFIRED: 1 → 1 + 1.8 = 2.8 bullets per shot
- EXPLOSIONRADIUS: 3 → 3 + 2.5 = 5.5 radius units

### 1.7.5.3 Complex Weapon Transformation (Mod ID 16)

**From ModsData.asset**:
```yaml
val: -0.6
val2: 0.3
equation: M_GUNDAMAGE=-val1;M_BULLETSPEED=0.8;M_SHOTSPERSEC=0.666;B_PROJECTILEKNOCKBACK=0;B_AUTOTURRETON=1
```

**After VAL substitution**:
```hel
M_GUNDAMAGE = 0.6; M_BULLETSPEED = 0.8; M_SHOTSPERSEC = 0.666; B_PROJECTILEKNOCKBACK = 0; B_AUTOTURRETON = 1
```

**Effects**:
- Gun damage increased by 60%
- Bullet speed increased by 80%  
- Fire rate increased by 66.6%
- Projectile knockback disabled
- Auto-turret mode enabled

**Complete transformation**: Regular weapon becomes high-speed auto-turret

### 1.7.5.4 VAL-Based Scaling Mod

**Example mod design**:
```yaml
val: 10.0  # Base bonus per level
val2: 0.05 # Percentage bonus per level
equation: B_HEALTH=VAL*S_LEVEL;M_DAMAGE=VAL2*S_LEVEL
```

**For S_LEVEL = 8**:
```hel
B_HEALTH = 10.0 8 *; M_DAMAGE = 0.05 8 *
```
**Result**:
```hel
B_HEALTH = 80; M_DAMAGE = 0.4
```

**Effects at level 8**:
- +80 base health
- +40% damage multiplier
- Mod scales with character level

## 1.7.6 Performance and Optimization Examples

### 1.7.6.1 Efficient Equation Writing

#### 1.7.6.1.1 Good: Direct Coefficient Assignment
```hel
B_DAMAGE = 50; M_SPEED = 0.2
```
**Performance**: Optimal - direct assignments execute quickly

#### 1.7.6.1.2 Avoid: Unnecessary Self-Reference  
```hel
B_DAMAGE = B_DAMAGE 50 +  // Slower than direct assignment
```
**Better**: Use direct assignment when no existing value matters

#### 1.7.6.1.3 Good: Minimal Calculations
```hel
A_HEALTH = S_LEVEL 5 *
```
**Performance**: Single multiplication per evaluation

#### 1.7.6.1.4 Avoid: Complex Nested Expressions
```hel
A_HEALTH = S_LEVEL S_STRENGTH * S_DIFFICULTY / 100 MIN S_LEVEL MAX
```
**Impact**: Multiple function calls and operations per evaluation

### 1.7.6.2 Avoiding Unnecessary Cycles

#### 1.7.6.2.1 Problem: Unintended Cycle Creation
```hel
B_ATTACK = S_DEFENSE; B_DEFENSE = S_ATTACK
```
**Issue**: Creates cycle requiring iterative resolution

#### 1.7.6.2.2 Solution: Use Base Stats Only
```hel
B_ATTACK = S_DEFENSE; B_DEFENSE = S_BASEATTACK  
```
**Result**: No cycle, faster processing

#### 1.7.6.2.3 Problem: Self-Reference When Not Needed
```hel
M_DAMAGE = M_DAMAGE 0.1 +  // Creates self-cycle
```

#### 1.7.6.2.4 Solution: Direct Assignment
```hel
M_DAMAGE = 0.1  // Simple, fast assignment
```

### 1.7.6.3 Best Practices for Complex Mods

#### 1.7.6.3.1 Modular Stat Design
```hel
// Good: Each stat has clear purpose
B_PRIMARYDAMAGE = VAL;
M_CRITCHANCE = VAL2;  
A_ACCURACY = VAL 2 *
```

#### 1.7.6.3.2 Avoid Coefficient Mixing
```hel
// Avoid: Mixing different coefficient types unnecessarily
B_DAMAGE = M_SPEED A_HEALTH +  // Unclear relationships
```

#### 1.7.6.3.3 Use Appropriate Coefficient Types
```hel
// Good: Percentage bonuses use M_, flat bonuses use B_/A_
M_DAMAGE = 0.25;  // 25% increase
B_HEALTH = 50;    // +50 health points
```

#### 1.7.6.3.4 Document Complex Logic
```hel
// Complex conditional logic benefits from clear variable names
B_SPEEDBONUS = S_ARMOR 25 < VAL 0 OR AND;  // Light armor speed bonus
M_DAMAGEPEN = S_ENCUMBRANCE 50 > -0.1 0 OR AND;  // Heavy load penalty
```

## 1.7.7 Cross-References

- **[Section 1.2: Stats and SubStat System](1-2-Stats-SubStat-System.md)** - Understanding coefficient types and SubStat naming conventions used in these examples
- **[Section 1.3: HEL Syntax](1-3-HEL-Syntax.md)** - Syntax rules for operators, functions, and expressions demonstrated here
- **[Section 1.4: HEL Semantics](1-4-HEL-Semantics.md)** - Statement evaluation order and assignment semantics that affect example outcomes
- **[Section 1.5: Stat Value Computation](1-5-Stat-Value-Computation.md)** - The core formula used to calculate final stat values from coefficient modifications
- **[Section 1.6: Dependency Resolution & Ordering](1-6-Dependency-Resolution-Ordering.md)** - How the interpreter handles dependency cycles shown in complex examples

## 1.7.8 Implementation Notes

All examples in this section can be tested using the HEL interpreter's static methods:

```csharp
// Load base stats and mods
var stats = HELYAMLFile.LoadStatsFromAsset("StatsData.asset");  
var mods = HELYAMLFile.LoadModsFromAsset("ModsData.asset");

// Test a specific mod combination
var equippedMods = new Dictionary<string, Mod> { 
    {"uuid-0-abc123", mods["uuid-0-abc123"]}, 
    {"uuid-15-def456", mods["uuid-15-def456"]} 
};
var result = HEL.EvaluateMods(stats, equippedMods);
```

For debugging complex equations, enable the MYDEBUG flag in HEL.cs to see step-by-step coefficient modifications and final stat calculations.

---

# 2. Class Usage Guide



---

# 2.1 Integration Overview

## 2.1.1 Introduction

This section provides game developers with a comprehensive workflow for integrating the HEL (HIOX Equation Language) system into Unity-based games. The HEL classes provide sophisticated mathematical expression evaluation capabilities for mod systems and dynamic stat modification.

⚠️ **Important**: This documentation covers the complete HEL system with advanced mathematical expression processing and flexible stat modification capabilities.

## 2.1.2 Typical HIOX Integration Workflow

### 2.1.2.1 Phase 1: Asset Loading at Game Startup

The integration begins by loading mod and stat definitions from asset files during game initialization:

```csharp
// Unity Game Startup - Load Assets Once
public class GameManager : MonoBehaviour 
{
    private Dictionary<string, Stat> gameStats;
    private Dictionary<int, Mod> availableMods;
    
    void Start() 
    {
        // Load base game statistics
        var (statsObj, statsOrder) = HELYAMLFile.LoadAsset(
            Application.streamingAssetsPath + "/StatsData.asset", 
            "statsList"
        );
        gameStats = (Dictionary<string, Stat>)statsObj;
        
        // Load available mod definitions  
        var (modsObj, _) = HELYAMLFile.LoadAsset(
            Application.streamingAssetsPath + "/ModsData.asset",
            "modsList"
        );
        availableMods = (Dictionary<int, Mod>)modsObj;
        
        // Initialize mod picker for random generation
        var weights = availableMods.Values.Select(m => m.weight).ToList();
        modPicker = new HELPicker(weights);
    }
}
```

### 2.1.2.2 Phase 2: Player Mod Inventory Management

During gameplay, maintain player's mod inventory as they acquire new mods:

```csharp
public class PlayerModInventory 
{
    // Key: ModID, Value: Count of that mod
    private Dictionary<int, int> playerMods = new Dictionary<int, int>();
    
    public void AddMod(int modId) 
    {
        if (playerMods.ContainsKey(modId))
            playerMods[modId]++;
        else
            playerMods[modId] = 1;
            
        // Trigger stat recalculation
        RecalculatePlayerStats();
    }
    
    public void RemoveMod(int modId) 
    {
        if (playerMods.ContainsKey(modId)) 
        {
            playerMods[modId]--;
            if (playerMods[modId] <= 0)
                playerMods.Remove(modId);
                
            RecalculatePlayerStats();
        }
    }
}
```

### 2.1.2.3 Phase 3: Real-time Stat Calculation

Recalculate player stats whenever mod inventory changes:

```csharp
public class PlayerStats 
{
    private Dictionary<string, Stat> currentStats;
    
    public void RecalculatePlayerStats() 
    {
        try 
        {
            // Evaluate mods against base stats
            currentStats = HEL.EvaluateMods(
                gameStats,           // Base game statistics
                equippedMods         // Player's equipped mods
            );
            
            // Apply updated stats to Unity game systems
            UpdateUnityComponents();
        }
        catch (Exception ex) 
        {
            Debug.LogError($"Stat calculation failed: {ex.Message}");
            // Fallback to base stats if evaluation fails
            currentStats = new Dictionary<string, Stat>(gameStats);
        }
    }
    
    private void UpdateUnityComponents() 
    {
        // Apply calculated stats to game components
        playerController.speed = currentStats["PLAYERSPEED"].value;
        weaponSystem.damage = currentStats["GUNDAMAGE"].value;
        healthSystem.maxHealth = currentStats["HP"].value;
        // ... etc for all game systems
    }
}
```

### 2.1.2.4 Phase 4: Integration with Unity Systems

Connect HEL-calculated stats to existing Unity game components:

```csharp
public class PlayerController : MonoBehaviour 
{
    [SerializeField] private float baseSpeed = 130f;
    private PlayerStats playerStats;
    
    void Update() 
    {
        // Use HEL-calculated speed instead of base value
        float currentSpeed = playerStats.GetStat("PLAYERSPEED");
        // Apply to movement system...
    }
}
```

## 2.1.3 Key Classes and Their Roles

### 2.1.3.1 HEL - Core Equation Evaluation Engine

**Role**: Primary interface for processing mod equations and calculating stat modifications.

**Key Features**:
- **Stateless Design**: All methods are static, no persistent state between calls
- **Thread-Safe**: Can be called from any thread without synchronization
- **Error Handling**: Comprehensive exception handling with detailed error messages

**Primary Method**:
```csharp
public static Dictionary<string, Stat> EvaluateMods(
    Dictionary<string, Stat> statsDict,     // Base game statistics
    Dictionary<string, Mod> modsDict          // Equipped mods keyed by UUID
);
```

**Integration Pattern**:
```csharp
// Cache dictionaries at startup, call EvaluateMods() with equipped mods
var updatedStats = HEL.EvaluateMods(baseStats, equippedMods);
```

### 2.1.3.2 HELYAMLFile - Unity Asset File Loading/Saving

**Role**: Handles serialization/deserialization of asset files in Unity-compatible YAML format.

**Key Features**:
- **Unity Integration**: Reads/writes .asset files with proper Unity headers
- **Dual Format Support**: Handles both ModsData.asset and StatsData.asset
- **Robust Parsing**: Error handling for malformed YAML data

**Usage Pattern**:
```csharp
// Load at game startup
var (statsData, statsOrder) = HELYAMLFile.LoadAsset("StatsData.asset", "statsList");
var (modsData, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsList");

// Save during development (Editor use)
HELYAMLFile.WriteAsset("ModsData.asset", modsList, "modsList");
```

### 2.1.3.3 HELCSVFile - Alternative CSV File Loading/Saving

**Role**: Provides CSV format support for development workflows and non-Unity environments.

**Key Features**:
- **Development Friendly**: Human-readable format for editing
- **Excel Compatible**: Can be opened/edited in spreadsheet applications
- **Robust CSV Parsing**: Handles quoted fields, embedded commas, special characters

**Usage Pattern**:
```csharp
// Development workflow - load from CSV
var (modsData, _) = HELCSVFile.LoadAsset("ModsData.csv", "modsList");

// Convert between formats
HELYAMLFile.WriteAsset("ModsData.asset", modsList, "modsList");
```

### 2.1.3.4 HELPicker - Weighted Random Mod Selection

**Role**: Efficient O(1) weighted random selection using the Alias method algorithm.

**Key Features**:
- **O(1) Performance**: Constant-time sampling regardless of mod count
- **Weighted Distribution**: Respects mod weight values for balanced gameplay
- **High Performance**: Suitable for real-time mod generation

**Usage Pattern**:
```csharp
// Initialize once with mod weights
var weights = availableMods.Values.Select(m => m.weight).ToList();
var picker = new HELPicker(weights);

// Sample random mods during gameplay
int selectedModIndex = picker.Sample();
int selectedModId = availableMods.Keys.ElementAt(selectedModIndex);
```

### 2.1.3.5 Data Structures - Asset Management

**Mod Class**: Complete mod definition with values, equations, and metadata
```csharp
public class Mod {
    public int modid;           // Unique mod type identifier
    public string uuid;         // Unique instance identifier
    public float val, val2;     // Primary and secondary values
    public string equation;     // HEL expression string
    public string name, desc;   // Display information
    public int weight;          // Random selection weight
    // ... additional properties
}
```

**Stat Class**: Game statistic with value and constraints
```csharp
public class Stat {
    public string name;         // Stat identifier
    public float value;         // Current/base value
    public float min, max;      // Valid range constraints
    public string desc;         // Description for UI
}
```

## 2.1.4 Data Flow Architecture

### 2.1.4.1 Startup Flow
```
Unity Startup → Asset Loading → Dictionary Creation → Cache for Runtime
     ↓               ↓              ↓                    ↓
StreamingAssets → HELYAMLFile → ModsDict + StatsDict → GameManager
```

### 2.1.4.2 Runtime Flow  
```
Mod Acquisition → Inventory Update → Stat Recalculation → Unity Component Update
      ↓                ↓                   ↓                      ↓
Player Action → Dictionary<int,int> → HEL.EvaluateMods() → Apply to Game Systems
```

### 2.1.4.3 Detailed Processing Pipeline
```
1. Player Mod Inventory (Dictionary<int, int>)
   ↓
2. HEL.EvaluateMods() - Main Processing
   ├─ Equation Preparation (VAL substitution)
   ├─ Tokenization (HELLexer)  
   ├─ Parsing (Statement generation)
   ├─ Dependency Resolution (HELOrdering)
   ├─ Execution (HELInterpreter)
   └─ Coefficient Application (Final stat calculation)
   ↓
3. Updated Stats Dictionary
   ↓
4. Unity Component Updates
```

## 2.1.5 Performance Considerations

### 2.1.5.1 Stateless Evaluation Benefits
- **No Memory Leaks**: No persistent state between evaluation calls
- **Thread Safety**: Multiple threads can evaluate simultaneously  
- **Predictable Performance**: Memory allocation patterns are consistent
- **Easy Testing**: Pure functions with no side effects

### 2.1.5.2 O(1) Mod Selection with HELPicker
```csharp
// Traditional approach: O(N) per sample
// HELPicker approach: O(N) setup, O(1) per sample

var picker = new HELPicker(weights);    // O(N) - once at startup
for (int i = 0; i < 1000; i++) {
    int modIndex = picker.Sample();     // O(1) - constant time
}
```

### 2.1.5.3 Dependency Analysis Overhead
- **Complex Equations**: More interdependencies = longer processing time
- **Cycle Detection**: Additional overhead for cycle resolution
- **Optimization**: Cache parsed equations when possible (future enhancement)

### 2.1.5.4 Memory Allocation Patterns
```csharp
// Efficient: Reuse dictionaries when possible
var baseStats = new Dictionary<string, Stat>(gameStats);  // Copy base stats
var result = HEL.EvaluateMods(baseStats, equippedMods); // Process

// Avoid: Creating new objects every frame
// Use object pooling for frequently allocated temporary objects
```

## 2.1.6 Best Practices for Integration

### 2.1.6.1 1. Load Assets Once at Startup
```csharp
// ✅ Good: Cache at startup
private static Dictionary<string, Stat> cachedBaseStats;
private static Dictionary<int, Mod> cachedMods;

// ❌ Bad: Load every time stats are calculated
var stats = HELYAMLFile.LoadAsset("StatsData.asset", "statsList");
```

### 2.1.6.2 2. Use HELPicker for Efficient Random Generation
```csharp
// ✅ Good: O(1) weighted selection
var picker = new HELPicker(modWeights);
int randomMod = picker.Sample();

// ❌ Bad: O(N) selection every time
// Manual weight calculation and selection
```

### 2.1.6.3 3. Handle Exceptions Gracefully
```csharp
public Dictionary<string, Stat> SafeEvaluateMods() 
{
    try 
    {
        return HEL.EvaluateMods(baseStats, equippedMods);
    }
    catch (KeyNotFoundException ex) 
    {
        Debug.LogError($"Missing mod: {ex.Message}");
        return new Dictionary<string, Stat>(baseStats); // Fallback
    }
    catch (ArgumentException ex) 
    {
        Debug.LogError($"Invalid equation: {ex.Message}");
        return new Dictionary<string, Stat>(baseStats); // Fallback
    }
}
```

### 2.1.6.4 4. Consider Performance Impact of Frequent Recalculation
```csharp
// ✅ Good: Batch inventory changes
public void AddMultipleMods(List<int> modIds) 
{
    foreach (int id in modIds) 
    {
        // Update inventory without recalculating
        if (inventory.ContainsKey(id)) inventory[id]++;
        else inventory[id] = 1;
    }
    // Recalculate once after all changes
    RecalculateStats();
}

// ❌ Bad: Recalculate after each mod
public void AddMod(int modId) 
{
    inventory[modId]++;
    RecalculateStats(); // Expensive if called frequently
}
```

### 2.1.6.5 5. Validate Mod Inventory Before Evaluation
```csharp
private bool ValidateInventory(Dictionary<int, int> inventory) 
{
    foreach (var kvp in inventory) 
    {
        if (!availableMods.ContainsKey(kvp.Key)) 
        {
            Debug.LogWarning($"Unknown mod ID: {kvp.Key}");
            return false;
        }
        if (kvp.Value <= 0) 
        {
            Debug.LogWarning($"Invalid mod count: {kvp.Value}");
            return false;
        }
    }
    return true;
}
```

## 2.1.7 Differences from Current HIOX

### 2.1.7.1 Enhanced Equation Language
**Current HIOX**: Limited mod system with basic additive/multiplicative bonuses
**Enhanced HEL**: Full mathematical expression language with:
- Complex interdependencies between stats
- Conditional logic (AND, OR, NOT operators)
- Mathematical functions (MIN, MAX, CEIL, FLOOR, RAND)
- Comparison operators for sophisticated game mechanics

### 2.1.7.2 Improved Asset Loading
**Current HIOX**: Rudimentary asset loader with limited error handling  
**Enhanced HEL**: Robust YAML/CSV loading with:
- Comprehensive error reporting
- Format validation and recovery
- Development-friendly CSV support for easy editing

### 2.1.7.3 Better Mod Selection Algorithm
**Current HIOX**: Simple random selection without proper weight distribution
**Enhanced HEL**: O(1) weighted selection using Alias method:
- Mathematically correct weight distribution
- Constant-time performance regardless of mod count  
- Suitable for real-time mod generation

### 2.1.7.4 Dependency Ordering
**Current HIOX**: No statement ordering, potential for inconsistent results
**Enhanced HEL**: Sophisticated dependency resolution:
- Automatic detection of variable dependencies  
- Cycle detection and resolution
- Deterministic evaluation order for consistent gameplay

### 2.1.7.5 CSV Support for Development
**Current HIOX**: YAML-only workflow, difficult for non-programmers to edit
**Enhanced HEL**: Dual format support:
- CSV files for easy editing in Excel/spreadsheet applications
- Seamless conversion between YAML and CSV formats
- Better collaboration between programmers and game designers

## 2.1.8 Integration Workflow Diagram

```
[Game Startup]
       ↓
[Load StatsData.asset] → [Cache Base Stats Dictionary]
       ↓
[Load ModsData.asset] → [Cache Available Mods Dictionary]  
       ↓
[Initialize HELPicker] → [Ready for Runtime]
       ↓
[Gameplay Loop]
       ↓
[Mod Acquisition Event] → [Update Player Inventory]
       ↓                         ↓
[HEL.EvaluateMods()] ← [Validate Inventory]
       ↓
[Updated Stats Dictionary] → [Apply to Unity Components]
       ↓
[Player Sees Effect in Game]
```

## 2.1.9 Code Integration Example

Complete integration example showing all key components:

```csharp
public class HIOXModIntegration : MonoBehaviour 
{
    // Asset data cached at startup
    private Dictionary<string, Stat> baseGameStats;
    private Dictionary<int, Mod> availableMods;
    private HELPicker modPicker;
    
    // Runtime player state
    private Dictionary<int, int> playerModInventory = new Dictionary<int, int>();
    private Dictionary<string, Stat> currentPlayerStats;
    
    void Start() 
    {
        LoadAssets();
        InitializePlayer();
    }
    
    private void LoadAssets() 
    {
        // Load base statistics
        var (statsObj, _) = HELYAMLFile.LoadAsset(
            Path.Combine(Application.streamingAssetsPath, "StatsData.asset"), 
            "statsList"
        );
        baseGameStats = (Dictionary<string, Stat>)statsObj;
        
        // Load available mods
        var (modsObj, _) = HELYAMLFile.LoadAsset(
            Path.Combine(Application.streamingAssetsPath, "ModsData.asset"),
            "modsList"
        );
        availableMods = (Dictionary<int, Mod>)modsObj;
        
        // Initialize weighted mod picker
        var weights = availableMods.Values.Select(m => m.weight).ToList();
        modPicker = new HELPicker(weights);
        
        Debug.Log($"Loaded {baseGameStats.Count} stats and {availableMods.Count} mods");
    }
    
    private void InitializePlayer() 
    {
        // Start with base stats (no mods)
        RecalculatePlayerStats();
    }
    
    public void AddRandomMod() 
    {
        // Generate random mod using weighted selection
        int modIndex = modPicker.Sample();
        int modId = availableMods.Keys.ElementAt(modIndex);
        
        AddMod(modId);
    }
    
    public void AddMod(int modId) 
    {
        if (!availableMods.ContainsKey(modId)) 
        {
            Debug.LogError($"Unknown mod ID: {modId}");
            return;
        }
        
        // Update inventory
        if (playerModInventory.ContainsKey(modId))
            playerModInventory[modId]++;
        else
            playerModInventory[modId] = 1;
            
        // Recalculate stats
        RecalculatePlayerStats();
        
        Debug.Log($"Added mod: {availableMods[modId].name}");
    }
    
    private void RecalculatePlayerStats() 
    {
        try 
        {
            currentPlayerStats = HEL.EvaluateMods(
                baseGameStats, 
                availableMods, 
                playerModInventory
            );
            
            ApplyStatsToGameSystems();
        }
        catch (Exception ex) 
        {
            Debug.LogError($"Failed to calculate stats: {ex.Message}");
            // Fallback to base stats
            currentPlayerStats = new Dictionary<string, Stat>(baseGameStats);
        }
    }
    
    private void ApplyStatsToGameSystems() 
    {
        // Apply calculated stats to game components
        var playerController = GetComponent<CharacterController>();
        if (playerController && currentPlayerStats.ContainsKey("PLAYERSPEED")) 
        {
            // Update movement speed
            float newSpeed = currentPlayerStats["PLAYERSPEED"].value;
            // Apply to character controller...
        }
        
        // Apply to other systems (health, damage, etc.)
        // ...
    }
    
    public float GetStatValue(string statName) 
    {
        if (currentPlayerStats?.ContainsKey(statName.ToUpper()) == true)
            return currentPlayerStats[statName.ToUpper()].value;
        return 0f;
    }
}
```

---

## 2.1.10 Next Steps

- **[Section 2.2](2-2-HEL-Class-Usage.md)**: Detailed HEL class usage patterns and advanced features
- **[Section 2.3](2-3-Asset-Management.md)**: Comprehensive asset loading and file format management  
- **[Section 2.4](2-4-HELPicker-Usage.md)**: Advanced HELPicker configuration and optimization techniques
- **[Section 2.5](2-5-Common-Integration-Patterns.md)**: Additional integration patterns and advanced use cases

Cross-references:
- **[Section 1.1](1-1-Overview-Core-Concepts.md)**: Core HEL concepts and terminology
- **[Section 3.1](3-1-HEL-Class-Reference.md)**: Complete HEL class API reference

---

**Document Version:** 1.0  
**Target Audience:** HIOX Game Developers  
**Prerequisites:** Unity development experience, basic understanding of C#/.NET  
**Last Updated:** August 1, 2025

---

# 2.2 HEL Class Usage

This section provides practical guidance for integrating the HEL class into HIOX game systems. The HEL class provides static methods for evaluating mod equations against game statistics, making it thread-safe and efficient for real-time game scenarios.

## 2.2.1 Primary Interface: EvaluateMods() Method

The `EvaluateMods()` method is the main entry point for applying mod effects to game statistics.

### Method Signature

```csharp
public static statsDictionary EvaluateMods(
    statsDictionary statsDict, 
    modsDictionary modsDict)
```

### Parameters

- **`statsDict`**: Dictionary of base statistics keyed by stat name (case-insensitive, converted to uppercase internally)
- **`modsDict`**: Dictionary of all available mods keyed by mod ID 
- **`playerModInventory`**: Optional dictionary mapping mod ID → count. If null or default, no mods are evaluated

### Return Value

Returns a new `statsDictionary` containing updated stat values after applying all specified mod effects. The original dictionaries are not modified.

### Null/Default Handling

```csharp
// No mods applied - returns base stats
var emptyMods = new Dictionary<string, Mod>();
var baseStats = HEL.EvaluateMods(statsDict, emptyMods);
```

## 2.2.2 Parameter Setup Patterns

### Stats Dictionary Setup

Load base statistics from your StatsData.asset file:

```csharp
// Load stats from YAML asset file
var (statsDict, _) = HELYAMLFile.LoadAsset("StatsData.asset", "stats:");
var typedStatsDict = (statsDictionary)statsDict;

// Cache for repeated use
private static statsDictionary? _cachedBaseStats;
public static statsDictionary GetBaseStats()
{
    if (_cachedBaseStats == null)
    {
        var (stats, _) = HELYAMLFile.LoadAsset("StatsData.asset", "stats:");
        _cachedBaseStats = (statsDictionary)stats;
    }
    return _cachedBaseStats;
}
```

### Mods Dictionary Setup

Load all available mods from your ModsData.asset file:

```csharp
// Load mods from YAML asset file
var (modsDict, _) = HELYAMLFile.LoadAsset("ModsData.asset", "mods:");
var typedModsDict = (modsDictionary)modsDict;

// Cache for repeated use
private static modsDictionary? _cachedMods;
public static modsDictionary GetAllMods()
{
    if (_cachedMods == null)
    {
        var (mods, _) = HELYAMLFile.LoadAsset("ModsData.asset", "mods:");
        _cachedMods = (modsDictionary)mods;
    }
    return _cachedMods;
}
```

### Player Mod Inventory Setup

The player inventory tracks which mods the player has and how many copies:

```csharp
// Player has 2 copies of mod 101, 1 copy of mod 205
var playerInventory = new Dictionary<int, int>
{
    { 101, 2 },  // Mod ID 101: 2 copies
    { 205, 1 }   // Mod ID 205: 1 copy
};

// Dynamic inventory management
public class PlayerModManager
{
    private Dictionary<int, int> inventory = new();
    
    public void AddMod(int modId)
    {
        inventory[modId] = inventory.GetValueOrDefault(modId, 0) + 1;
    }
    
    public void RemoveMod(int modId)
    {
        if (inventory.ContainsKey(modId))
        {
            inventory[modId]--;
            if (inventory[modId] <= 0)
                inventory.Remove(modId);
        }
    }
    
    public Dictionary<int, int> GetInventory() => new(inventory);
}
```

### Dictionary Key Requirements

- **Stat names**: Case-insensitive (converted to uppercase internally)
- **Mod IDs**: Must match exactly as integers
- **Player inventory**: Mod IDs must exist in the mods dictionary

## 2.2.3 Error Handling and Exception Management

### Exception Types

The HEL system can throw several types of exceptions:

```csharp
public static class HELEvaluator
{
    public static statsDictionary SafeEvaluateMods(
        statsDictionary statsDict,
        modsDictionary modsDict,
        Dictionary<int, int>? playerInventory)
    {
        try
        {
            return HEL.EvaluateMods(statsDict, modsDict, playerInventory);
        }
        catch (KeyNotFoundException ex)
        {
            // Mod ID not found in modsDict
            Console.WriteLine($"Mod not found: {ex.Message}");
            // Return base stats or handle gracefully
            return new statsDictionary(statsDict);
        }
        catch (ArgumentException ex)
        {
            // Syntax error in mod equation
            Console.WriteLine($"Equation syntax error: {ex.Message}");
            // Log problematic mod and continue with base stats
            return new statsDictionary(statsDict);
        }
        catch (InvalidOperationException ex)
        {
            // Runtime evaluation error
            Console.WriteLine($"Evaluation error: {ex.Message}");
            // Handle division by zero, undefined variables, etc.
            return new statsDictionary(statsDict);
        }
    }
}
```

### Error Recovery Strategies

```csharp
public class RobustModEvaluator
{
    public static statsDictionary EvaluateWithFallback(
        statsDictionary baseStats,
        modsDictionary allMods,
        Dictionary<int, int> playerInventory)
    {
        // Validate inventory before evaluation
        var validInventory = new Dictionary<int, int>();
        foreach (var kvp in playerInventory)
        {
            if (allMods.ContainsKey(kvp.Key) && kvp.Value > 0)
            {
                validInventory[kvp.Key] = kvp.Value;
            }
            else
            {
                Console.WriteLine($"Warning: Skipping invalid mod {kvp.Key}");
            }
        }
        
        try
        {
            return HEL.EvaluateMods(baseStats, allMods, validInventory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Evaluation failed: {ex.Message}");
            // Return base stats as fallback
            return new statsDictionary(baseStats);
        }
    }
}
```

## 2.2.4 Common Usage Patterns

### Game Startup: Asset Loading and Caching

```csharp
public class GameStatsManager
{
    private static statsDictionary _baseStats;
    private static modsDictionary _allMods;
    private static bool _initialized = false;
    
    public static void Initialize()
    {
        if (_initialized) return;
        
        try
        {
            // Load base statistics
            var (stats, _) = HELYAMLFile.LoadAsset("StatsData.asset", "stats:");
            _baseStats = (statsDictionary)stats;
            
            // Load all mods
            var (mods, _) = HELYAMLFile.LoadAsset("ModsData.asset", "mods:");
            _allMods = (modsDictionary)mods;
            
            _initialized = true;
            Console.WriteLine($"Loaded {_baseStats.Count} stats and {_allMods.Count} mods");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to initialize game stats: {ex.Message}");
        }
    }
    
    public static statsDictionary GetPlayerStats(Dictionary<int, int>? playerMods = null)
    {
        if (!_initialized) Initialize();
        return HEL.EvaluateMods(_baseStats, equippedMods);
    }
}
```

### Player Mod Acquisition: Dynamic Recalculation

```csharp
public class Player
{
    private Dictionary<int, int> modInventory = new();
    private statsDictionary currentStats;
    
    public void AcquireMod(int modId)
    {
        modInventory[modId] = modInventory.GetValueOrDefault(modId, 0) + 1;
        RecalculateStats();
        
        Console.WriteLine($"Acquired mod {modId}. Now have {modInventory[modId]} copies.");
    }
    
    public void LoseMod(int modId)
    {
        if (modInventory.ContainsKey(modId))
        {
            modInventory[modId]--;
            if (modInventory[modId] <= 0)
                modInventory.Remove(modId);
            
            RecalculateStats();
            Console.WriteLine($"Lost mod {modId}");
        }
    }
    
    private void RecalculateStats()
    {
        currentStats = GameStatsManager.GetPlayerStats(modInventory);
    }
    
    public float GetStatValue(string statName)
    {
        return currentStats.ContainsKey(statName.ToUpper()) 
            ? currentStats[statName.ToUpper()].value 
            : 0f;
    }
}
```

### Real-time Preview: Showing Changes Before Application

```csharp
public class ModPreviewSystem
{
    public static StatComparison PreviewModEffect(
        statsDictionary currentStats,
        modsDictionary allMods,
        Dictionary<int, int> currentInventory,
        int modToAdd)
    {
        // Calculate stats with proposed mod
        var previewInventory = new Dictionary<int, int>(currentInventory);
        previewInventory[modToAdd] = previewInventory.GetValueOrDefault(modToAdd, 0) + 1;
        
        var previewStats = HEL.EvaluateMods(currentStats, allMods, previewInventory);
        
        return new StatComparison
        {
            Before = currentStats,
            After = previewStats,
            Changes = CalculateChanges(currentStats, previewStats)
        };
    }
    
    private static Dictionary<string, float> CalculateChanges(
        statsDictionary before,
        statsDictionary after)
    {
        var changes = new Dictionary<string, float>();
        foreach (var kvp in after)
        {
            var beforeValue = before.ContainsKey(kvp.Key) ? before[kvp.Key].value : 0f;
            var afterValue = kvp.Value.value;
            if (Math.Abs(beforeValue - afterValue) > 1e-6f)
            {
                changes[kvp.Key] = afterValue - beforeValue;
            }
        }
        return changes;
    }
}

public class StatComparison
{
    public statsDictionary Before { get; set; }
    public statsDictionary After { get; set; }
    public Dictionary<string, float> Changes { get; set; }
}
```

### Batch Processing: Multiple Mod Combinations

```csharp
public class ModCombinationAnalyzer
{
    public static Dictionary<string, statsDictionary> AnalyzeCombinations(
        statsDictionary baseStats,
        modsDictionary allMods,
        List<List<int>> combinations)
    {
        var results = new Dictionary<string, statsDictionary>();
        
        foreach (var combination in combinations)
        {
            var inventory = combination
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
            
            var stats = HEL.EvaluateMods(baseStats, equippedMods);
            var key = string.Join(",", combination.OrderBy(x => x));
            results[key] = stats;
        }
        
        return results;
    }
    
    public static void FindOptimalCombination(
        statsDictionary baseStats,
        modsDictionary allMods,
        List<int> availableMods,
        string targetStat)
    {
        float bestValue = float.MinValue;
        List<int> bestCombination = null;
        
        // Test all possible combinations (simplified example)
        for (int i = 0; i < availableMods.Count; i++)
        {
            for (int j = i; j < availableMods.Count; j++)
            {
                var inventory = new Dictionary<int, int>
                {
                    { availableMods[i], 1 },
                    { availableMods[j], 1 }
                };
                
                var result = HEL.EvaluateMods(baseStats, equippedMods);
                if (result.ContainsKey(targetStat.ToUpper()))
                {
                    var value = result[targetStat.ToUpper()].value;
                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestCombination = new List<int> { availableMods[i], availableMods[j] };
                    }
                }
            }
        }
        
        Console.WriteLine($"Best combination for {targetStat}: {string.Join(",", bestCombination)} = {bestValue}");
    }
}
```

## 2.2.5 Performance Optimization Strategies

### Cache Management

```csharp
public class OptimizedStatsManager
{
    private static readonly Dictionary<string, statsDictionary> _resultCache = new();
    private static statsDictionary _baseStats;
    private static modsDictionary _allMods;
    
    public static statsDictionary GetStatsWithCaching(Dictionary<int, int>? inventory)
    {
        // Create cache key from inventory
        var cacheKey = inventory == null ? "base" : 
            string.Join(",", inventory.OrderBy(kvp => kvp.Key).Select(kvp => $"{kvp.Key}:{kvp.Value}"));
        
        if (_resultCache.ContainsKey(cacheKey))
        {
            return _resultCache[cacheKey];
        }
        
        // Calculate and cache result
        var result = HEL.EvaluateMods(_baseStats, _allMods, inventory);
        _resultCache[cacheKey] = result;
        
        // Limit cache size
        if (_resultCache.Count > 1000)
        {
            var oldestKey = _resultCache.Keys.First();
            _resultCache.Remove(oldestKey);
        }
        
        return result;
    }
}
```

### Performance Monitoring

```csharp
public class PerformanceMonitor
{
    public static statsDictionary MeasuredEvaluate(
        statsDictionary baseStats,
        modsDictionary allMods,
        Dictionary<int, int>? inventory)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        var result = HEL.EvaluateMods(baseStats, equippedMods);
        
        stopwatch.Stop();
        var modCount = inventory?.Values.Sum() ?? 0;
        
        if (stopwatch.ElapsedMilliseconds > 10) // Log slow evaluations
        {
            Console.WriteLine($"Slow evaluation: {modCount} mods took {stopwatch.ElapsedMilliseconds}ms");
        }
        
        return result;
    }
}
```

### Inventory Size Impact

```csharp
public class InventoryOptimizer
{
    public static Dictionary<int, int> OptimizeInventory(Dictionary<int, int> inventory)
    {
        // Remove zero-count entries
        return inventory
            .Where(kvp => kvp.Value > 0)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
    
    public static void ProfileInventorySize()
    {
        var baseStats = GameStatsManager.GetBaseStats();
        var allMods = GameStatsManager.GetAllMods();
        
        for (int modCount = 1; modCount <= 20; modCount++)
        {
            // Create inventory with modCount random mods
            var inventory = new Dictionary<int, int>();
            var modIds = allMods.Keys.Take(modCount).ToList();
            foreach (var id in modIds)
            {
                inventory[id] = 1;
            }
            
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            HEL.EvaluateMods(baseStats, equippedMods);
            stopwatch.Stop();
            
            Console.WriteLine($"{modCount} mods: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
```

## 2.2.6 Integration Examples

### Basic Setup and Usage

```csharp
public class BasicHELIntegration
{
    public static void Main()
    {
        // 1. Load asset data
        var (statsData, _) = HELYAMLFile.LoadAsset("StatsData.asset", "stats:");
        var (modsData, _) = HELYAMLFile.LoadAsset("ModsData.asset", "mods:");
        
        var baseStats = (statsDictionary)statsData;
        var allMods = (modsDictionary)modsData;
        
        // 2. Create player inventory
        var playerMods = new Dictionary<int, int>
        {
            { 101, 1 },  // One copy of mod 101
            { 205, 2 }   // Two copies of mod 205  
        };
        
        // 3. Evaluate mods
        var finalStats = HEL.EvaluateMods(baseStats, allMods, playerMods);
        
        // 4. Use results
        foreach (var stat in finalStats.Values)
        {
            Console.WriteLine($"{stat.name}: {stat.value}");
        }
    }
}
```

### Error Handling Wrapper

```csharp
public static class SafeHEL
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    
    public static (statsDictionary stats, bool success, string error) TryEvaluateMods(
        statsDictionary baseStats,
        modsDictionary allMods,
        Dictionary<int, int>? inventory)
    {
        try
        {
            var result = HEL.EvaluateMods(baseStats, equippedMods);
            return (result, true, string.Empty);
        }
        catch (KeyNotFoundException ex)
        {
            var error = $"Missing mod in inventory: {ex.Message}";
            Logger.Error(error);
            return (new statsDictionary(baseStats), false, error);
        }
        catch (ArgumentException ex)
        {
            var error = $"Invalid mod equation: {ex.Message}";
            Logger.Error(error);
            return (new statsDictionary(baseStats), false, error);
        }
        catch (InvalidOperationException ex)
        {
            var error = $"Evaluation failed: {ex.Message}";
            Logger.Error(error);
            return (new statsDictionary(baseStats), false, error);
        }
        catch (Exception ex)
        {
            var error = $"Unexpected error: {ex.Message}";
            Logger.Fatal(error);
            return (new statsDictionary(baseStats), false, error);
        }
    }
}
```

## 2.2.7 Advanced Usage

### Using PrepareEquation() for Custom Processing

```csharp
public class CustomModProcessor
{
    public static string PreviewModEquation(Mod mod)
    {
        // Get the prepared equation without evaluating it
        return HEL.PrepareEquation(mod);
    }
    
    public static List<string> GetAllModEquations(Dictionary<int, int> inventory, modsDictionary allMods)
    {
        var equations = new List<string>();
        
        foreach (var kvp in inventory)
        {
            var mod = allMods[kvp.Key];
            var preparedEqn = HEL.PrepareEquation(mod);
            
            // Add one equation per mod copy
            for (int i = 0; i < kvp.Value; i++)
            {
                equations.Add(preparedEqn);
            }
        }
        
        return equations;
    }
}
```

### Direct EvaluateEquation() for Testing

```csharp
public class EquationTester
{
    public static bool TestEquation(string equation, statsDictionary testStats)
    {
        try
        {
            // Add EOF token as required by EvaluateEquation
            var testEquation = equation + "\n$";
            var result = HEL.EvaluateEquation(testEquation, testStats);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public static void ValidateAllModEquations(modsDictionary allMods, statsDictionary baseStats)
    {
        var invalidMods = new List<int>();
        
        foreach (var kvp in allMods)
        {
            var mod = kvp.Value;
            var preparedEqn = HEL.PrepareEquation(mod) + "\n$";
            
            try
            {
                HEL.EvaluateEquation(preparedEqn, baseStats);
            }
            catch (Exception ex)
            {
                invalidMods.Add(kvp.Key);
                Console.WriteLine($"Mod {kvp.Key} ({mod.name}) has invalid equation: {ex.Message}");
            }
        }
        
        Console.WriteLine($"Found {invalidMods.Count} invalid mod equations out of {allMods.Count} total mods");
    }
}
```

### FormatFloat() for Consistent Value Display

```csharp
public class ValueFormatter
{
    public static string FormatStatValue(float value)
    {
        // Use HEL's formatting for consistency with equation evaluation
        return HEL.FormatFloat(value);
    }
    
    public static void DisplayModValues(Mod mod)
    {
        Console.WriteLine($"Mod {mod.name}:");
        Console.WriteLine($"  VAL: {HEL.FormatFloat(mod.val)}");
        Console.WriteLine($"  VAL2: {HEL.FormatFloat(mod.val2)}");
        
        // Show how values appear in equations
        var preparedEqn = HEL.PrepareEquation(mod);
        Console.WriteLine($"  Equation: {preparedEqn}");
    }
}
```

## 2.2.8 Key Points to Remember

1. **Static Methods**: All HEL methods are static - no instance creation required
2. **Thread Safety**: Stateless design makes HEL safe for concurrent use
3. **Dictionary Copying**: EvaluateMods() creates new dictionaries, never modifies inputs
4. **Case Handling**: Stat names are converted to uppercase internally
5. **Mod Ordering**: Mods are evaluated in ID order for consistent results
6. **Error Isolation**: Exceptions don't corrupt internal state since there is none

## 2.2.9 Cross-References

- **Section 2.1**: HEL System Overview - architectural context
- **Section 2.3**: Asset Management - loading ModsData.asset and StatsData.asset files  
- **Section 3.1**: API Reference - complete method documentation
- **Section 1.3**: HEL Syntax - equation format and structure
- **Section 1.6**: Dependency Resolution - how equation ordering works

---

# 2.3 Asset Management

The HEL system supports two asset file formats for storing mod and stat data: YAML (Unity-native format) and CSV (development-friendly format). This section covers file format considerations, loading and saving operations, data validation, and best practices for asset management.

## 2.3.1 YAML vs CSV File Format Considerations

### YAML Format (HELYAMLFile.cs)
- **Unity-native format** with complete metadata headers and GUIDs
- **Production-ready** with proper Unity asset serialization
- **Structured data** with hierarchical organization and type safety
- **Larger file size** due to metadata overhead and formatting
- **Less human-readable** for bulk editing operations
- **Robust parsing** with YamlDotNet library handling complex scenarios

### CSV Format (HELCSVFile.cs)
- **Development-friendly** format optimized for spreadsheet editing
- **Compact file size** with minimal overhead
- **Easy bulk operations** for mass data updates and analysis
- **Human-readable** structure suitable for version control diffs
- **Limited metadata** - no Unity-specific information
- **Simple parsing** with custom CSV handling for quoted fields

### Performance Comparison
```csharp
// YAML loading uses YamlDotNet deserializer
var deserializer = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .IgnoreUnmatchedProperties()
    .Build();

// CSV loading uses direct string parsing
string[] fields = ParseCsvLine(line);  // Custom parser
```

**Performance characteristics:**
- **YAML**: Slower loading due to full deserialization, better error reporting
- **CSV**: Faster loading with direct parsing, minimal memory overhead
- **Memory usage**: CSV ~50% smaller file size than equivalent YAML

### Use Case Recommendations
- **YAML**: Production builds, Unity integration, final asset delivery
- **CSV**: Development, content creation, bulk data operations, testing

## 2.3.2 Loading Asset Files

### HELYAMLFile.LoadAsset()
Loads Unity YAML format asset files with complete metadata processing.

```csharp
public static (object, object?) LoadAsset(string path, string root)
```

**Parameters:**
- `path`: File path to the YAML asset file
- `root`: Name of the root node in the YAML file

**Return Value:**
- Tuple containing either `modsDictionary` or `statsDictionary` as first element
- Second element is `null` for mods or `List<string> statsOrder` for stats

**Asset Type Detection:**
```csharp
// Determines asset type based on root parameter first character
if (root[0] == 'm') {
    // Load as mods data
    modsData = deserializer.Deserialize<ModsList>(yaml);
    return (modsData.mods.ToDictionary(mod => mod.modid), null);
} else {
    // Load as stats data  
    statsData = deserializer.Deserialize<StatsList>(yaml);
    List<string> statsOrder = statsData.stats.Select(stat => stat.name).ToList();
    return (statsData.stats.ToDictionary(stat => stat.name), statsOrder);
}
```

**Example Usage:**
```csharp
try {
    var (modsDict, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsData");
    var modsDictionary = (Dictionary<int, Mod>)modsDict;
    
    var (statsDict, statsOrder) = HELYAMLFile.LoadAsset("StatsData.asset", "statsData");
    var statsDictionary = (Dictionary<string, Stat>)statsDict;
    var loadOrder = (List<string>)statsOrder;
} catch (FileNotFoundException ex) {
    Console.WriteLine($"Asset file not found: {ex.FileName}");
} catch (YamlException ex) {
    Console.WriteLine($"YAML parsing error: {ex.Message}");
}
```

### HELCSVFile.LoadAsset()
Loads simple CSV format asset files optimized for development workflows.

```csharp
public static (object, object?) LoadAsset(string filePath, string assetType)
```

**Parameters:**
- `filePath`: Path to the CSV file to load
- `assetType`: Asset type identifier ("m" prefix for mods, otherwise stats)

**CSV Format Specifications:**

**Mods CSV Header:**
```
modid,val,val2,val1min,val1max,val2min,val2max,modweight,name,desc,type,hasProc,equation,modColor_r,modColor_g,modColor_b,modColor_a,armorEffectName,armorMeshName
```

**Stats CSV Header:**
```
name,desc,value,min,max
```

**Example Usage:**
```csharp
try {
    var (modsDict, _) = HELCSVFile.LoadAsset("ModsData.csv", "mods");
    var modsDictionary = (Dictionary<int, Mod>)modsDict;
    
    var (statsDict, statsOrder) = HELCSVFile.LoadAsset("StatsData.csv", "stats");
    var statsDictionary = (Dictionary<string, Stat>)statsDict;
} catch (FileNotFoundException ex) {
    Console.WriteLine($"CSV file not found: {ex.FileName}");
} catch (FormatException ex) {
    Console.WriteLine($"Data parsing error: {ex.Message}");
}
```

## 2.3.3 Error Handling

### Common Exception Types

**FileNotFoundException:**
```csharp
if (!File.Exists(path)) {
    throw new FileNotFoundException("The specified file was not found.", path);
}
```

**YamlException (YAML files):**
- Malformed YAML syntax
- Invalid node structure
- Type conversion failures

**FormatException (CSV files):**
```csharp
mod.modid = int.Parse(fields[0]);  // Can throw FormatException
mod.val = float.Parse(fields[1]);  // Can throw FormatException
```

**IndexOutOfRangeException (CSV files):**
- Missing CSV fields
- Incomplete data rows

### Error Recovery Strategies

**File Validation:**
```csharp
// Check file existence before loading
if (!File.Exists(filePath)) {
    // Try backup file or default data
    string backupPath = filePath.Replace(".asset", ".backup.asset");
    if (File.Exists(backupPath)) {
        return LoadAsset(backupPath, root);
    }
}
```

**Data Validation:**
```csharp
// Validate CSV data completeness
string[] lines = File.ReadAllLines(filePath);
if (lines.Length < 2) {
    throw new Exception("CSV file is empty or missing data.");
}

// Skip empty/invalid lines
if (string.IsNullOrWhiteSpace(line))
    continue;
```

## 2.3.4 Saving Modified Data

### HELYAMLFile.WriteAsset()
Serializes data to Unity YAML format with proper headers and GUIDs.

```csharp
public static void WriteAsset(string filePath, object assetObj)
```

**Unity YAML Header Format:**
```yaml
%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!114 &11400000
MonoBehaviour:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 11500000, guid: XXX, type: 3}
  m_Name: ModsData
  m_EditorClassIdentifier: 
```

**GUID Assignment:**
- Mods: `2089455f10e0bb044bfbd1dbcca6bb00`
- Stats: `09dbea449d423d24c9e3cc308f3a5c62`

### HELCSVFile.WriteAsset()
Serializes data to CSV format with proper field escaping.

```csharp
public static void WriteAsset(string filePath, object assetObj)
```

**CSV Field Escaping:**
```csharp
private static string? EscapeCsvField(string field) {
    if (field is not null && (field.Contains(',') || field.Contains('"') || field.Contains('\n'))) {
        field = field.Replace("\"", "\"\"");  // Escape quotes
        return $"\"{field}\"";  // Wrap in quotes
    }
    return field;
}
```

**Example Saving:**
```csharp
// Save as YAML
HELYAMLFile.WriteAsset("ModsData.asset", modsDictionary);

// Save as CSV
HELCSVFile.WriteAsset("ModsData.csv", modsDictionary);
```

## 2.3.5 Data Validation and Error Recovery

### Pre-Save Validation
```csharp
// Validate dictionary before saving
if (assetObj is modsDictionary modsDict) {
    foreach (var mod in modsDict.Values) {
        if (string.IsNullOrEmpty(mod.name)) {
            throw new ArgumentException($"Mod {mod.modid} has empty name");
        }
        if (string.IsNullOrEmpty(mod.equation)) {
            Console.WriteLine($"Warning: Mod {mod.modid} has empty equation");
        }
    }
}
```

### Backup Strategies
```csharp
// Create backup before overwriting
string backupPath = filePath.Replace(".asset", ".backup.asset");
if (File.Exists(filePath)) {
    File.Copy(filePath, backupPath, true);
}
```

### Directory Creation
```csharp
// Ensure directory exists before writing
string directory = Path.GetDirectoryName(filePath);
if (!Directory.Exists(directory)) {
    Directory.CreateDirectory(directory);
}
```

## 2.3.6 File Format Conversion

### YAML to CSV Conversion
```csharp
public static void ConvertYamlToCsv(string yamlPath, string csvPath, string rootNode) {
    var (data, order) = HELYAMLFile.LoadAsset(yamlPath, rootNode);
    HELCSVFile.WriteAsset(csvPath, data);
}
```

### CSV to YAML Conversion
```csharp
public static void ConvertCsvToYaml(string csvPath, string yamlPath, string assetType) {
    var (data, order) = HELCSVFile.LoadAsset(csvPath, assetType);
    HELYAMLFile.WriteAsset(yamlPath, data);
}
```

### Data Integrity During Conversion
- **Field mapping validation**: Ensure all required fields are preserved
- **Type conversion safety**: Handle numeric precision differences
- **Special character handling**: Proper escaping in both formats
- **Order preservation**: Maintain load order for stats data

## 2.3.7 Best Practices

### Asset Loading Patterns at Game Startup
```csharp
public class AssetManager {
    private static Dictionary<int, Mod> _modsCache;
    private static Dictionary<string, Stat> _statsCache;
    
    public static void LoadGameAssets(string assetPath) {
        try {
            // Load mods
            var (modsData, _) = HELYAMLFile.LoadAsset(
                Path.Combine(assetPath, "ModsData.asset"), "modsData");
            _modsCache = (Dictionary<int, Mod>)modsData;
            
            // Load stats
            var (statsData, statsOrder) = HELYAMLFile.LoadAsset(
                Path.Combine(assetPath, "StatsData.asset"), "statsData");
            _statsCache = (Dictionary<string, Stat>)statsData;
            
        } catch (Exception ex) {
            Console.WriteLine($"Failed to load assets: {ex.Message}");
            LoadDefaultAssets();
        }
    }
}
```

### Caching Loaded Dictionaries for Performance
```csharp
// Cache frequently accessed data
private static readonly object _cacheLock = new object();
private static Dictionary<int, Mod> _modCache;

public static Dictionary<int, Mod> GetMods(string assetPath) {
    lock (_cacheLock) {
        if (_modCache == null) {
            var (data, _) = HELYAMLFile.LoadAsset(assetPath, "modsData");
            _modCache = (Dictionary<int, Mod>)data;
        }
        return _modCache;
    }
}
```

### File Watching for Development Workflows
```csharp
public static void SetupFileWatcher(string assetDirectory) {
    var watcher = new FileSystemWatcher(assetDirectory, "*.csv");
    watcher.Changed += (sender, e) => {
        Console.WriteLine($"Asset file changed: {e.Name}");
        // Reload affected assets
        InvalidateCache(e.Name);
    };
    watcher.EnableRaisingEvents = true;
}
```

### Version Control Considerations
- **CSV files**: Excellent diff visibility, easy merge conflict resolution
- **YAML files**: Binary-like diffs, avoid direct editing in version control
- **Asset strategies**: Keep CSV as source of truth, generate YAML for builds
- **Ignore patterns**: Add `.backup.asset` files to `.gitignore`

### Backup Strategies for Production Data
```csharp
public static void CreateTimestampedBackup(string assetPath) {
    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
    string backupPath = assetPath.Replace(".asset", $".{timestamp}.backup.asset");
    File.Copy(assetPath, backupPath);
    
    // Clean old backups (keep last 10)
    CleanOldBackups(Path.GetDirectoryName(assetPath));
}
```

## 2.3.8 Development Workflow Integration

### Using CSV for Spreadsheet Editing
1. **Export to CSV**: Convert YAML assets to CSV for editing
2. **Spreadsheet editing**: Use Excel/Google Sheets for bulk operations
3. **Data validation**: Apply spreadsheet formulas for consistency checks
4. **Import from CSV**: Convert back to YAML for Unity integration

### Converting CSV to YAML for Unity Builds
```csharp
// Build pipeline integration
public static void PrepareAssetsForBuild(string projectPath) {
    string[] csvFiles = Directory.GetFiles(projectPath, "*.csv");
    
    foreach (string csvFile in csvFiles) {
        string yamlFile = csvFile.Replace(".csv", ".asset");
        string assetType = Path.GetFileNameWithoutExtension(csvFile).ToLower();
        
        ConvertCsvToYaml(csvFile, yamlFile, assetType);
        Console.WriteLine($"Converted {csvFile} -> {yamlFile}");
    }
}
```

### Validation Tools for Asset Data
```csharp
public static bool ValidateAssetIntegrity(string assetPath) {
    try {
        var (data, order) = HELYAMLFile.LoadAsset(assetPath, "modsData");
        var mods = (Dictionary<int, Mod>)data;
        
        foreach (var mod in mods.Values) {
            // Validate required fields
            if (string.IsNullOrEmpty(mod.name)) return false;
            if (string.IsNullOrEmpty(mod.equation)) return false;
            
            // Validate ranges
            if (mod.val1min > mod.val1max) return false;
            if (mod.val2min > mod.val2max) return false;
        }
        
        return true;
    } catch {
        return false;
    }
}
```

### Integration with Content Creation Pipelines
- **Automated conversion**: Set up build scripts to convert CSV to YAML
- **Validation hooks**: Run integrity checks before asset deployment
- **Change tracking**: Monitor asset modifications for content team workflows
- **Asset bundling**: Package converted assets for game distribution

## 2.3.9 Cross-References

See also:
- **Section 2.1**: Integration Overview - Complete workflow context
- **Section 2.2**: HEL Class Usage - Using loaded assets with HEL evaluation
- **Section 3.2**: File I/O Reference - Technical API documentation
- **Section 1.2**: Stats/SubStat System - Understanding data structure relationships

---

# 2.4 HELPicker Usage Guide

## 2.4.1 Weighted Random Mod Selection Overview

The **HELPicker** class provides efficient weighted random mod selection for HIOX game systems using the mathematically optimal Alias method algorithm. This enables O(1) constant-time sampling from any discrete probability distribution based on mod weights.

### Purpose and Benefits

- **Efficient Selection**: Random mod selection based on configurable mod weights
- **Optimal Performance**: O(1) sampling time regardless of distribution size or skew
- **Mathematical Precision**: Exact probability matching using the Alias method
- **Game Balance**: Enables sophisticated mod rarity and drop rate systems

### Alias Method Implementation

HELPicker implements the Alias method, which:
- Performs O(N) preprocessing during construction to build lookup tables
- Enables O(1) sampling operations with mathematical correctness
- Maintains consistent performance regardless of weight distribution characteristics
- Provides significant advantages over naive weighted random approaches that require O(N) time per sample

### Use Cases in HIOX Mod Generation

- **Loot Drop Systems**: Weighted mod selection for player rewards
- **Procedural Generation**: Balanced mod distribution for level generation  
- **Testing and Analysis**: Batch mod generation for balance validation
- **Dynamic Difficulty**: Adaptive mod selection based on player progression

## 2.4.2 Constructor Setup with Weight Distributions

### Basic Constructor Usage

```csharp
// Create weight list corresponding to mod indices
List<int> modWeights = new List<int> { 100, 50, 25, 10, 5 };
HELPicker picker = new HELPicker(modWeights);
```

### Weight List Structure

The weight list corresponds directly to mod indices:
- `weights[0]` = weight for mod at index 0
- `weights[1]` = weight for mod at index 1  
- `weights[n]` = weight for mod at index n

### Weight Preprocessing and Normalization

During construction, HELPicker:

1. **Converts to Doubles**: Integer weights converted to double precision for algorithm
2. **Calculates Total**: Sums all weights to determine total probability mass
3. **Normalizes**: Each weight multiplied by N and divided by sum (average = 1.0)
4. **Builds Tables**: Creates alias and probability lookup tables

```csharp
// Example: weights [100, 50, 25] become normalized [2.0, 1.0, 0.5]
// This enables the alias method's bucket balancing approach
```

### Setup Cost Analysis

- **Time Complexity**: O(N) one-time setup cost during construction
- **Space Complexity**: O(N) for two lookup tables (alias + probability)
- **Benefit**: Amortized over potentially thousands of O(1) sample operations

## 2.4.3 Sampling Performance Characteristics

### Sample Method Performance

```csharp
// O(1) constant time selection
int selectedModIndex = picker.Sample();
```

The `Sample()` method provides:
- **Constant Time**: O(1) regardless of weight list size
- **Two Random Numbers**: One for index selection, one for alias decision
- **Exact Probabilities**: Mathematical guarantee of correct distribution

### Performance Comparison

| Method | Setup Time | Sample Time | Memory Usage |
|--------|------------|-------------|--------------|
| Naive Weighted | O(1) | O(N) | O(N) |
| Alias Method | O(N) | O(1) | O(N) |
| **Advantage** | One-time cost | Constant time | Same |

### Thread Safety Considerations

**Important**: HELPicker is **not thread-safe** due to the internal `Random` instance.

For multi-threaded scenarios:
```csharp
// Option 1: Separate instance per thread
[ThreadStatic]
static HELPicker threadLocalPicker;

// Option 2: External synchronization
lock (pickerLock) 
{
    int result = picker.Sample();
}
```

### Memory Usage Profile

- **Alias Table**: `int[N]` - 4 bytes per mod
- **Probability Table**: `double[N]` - 8 bytes per mod  
- **Total**: 12 bytes per mod + object overhead
- **Example**: 1000 mods = ~12KB memory footprint

## 2.4.4 Alias Method Implementation Benefits

### Algorithm Advantages

The Alias method provides several key benefits over alternative approaches:

1. **Skew Independence**: Performance unaffected by weight distribution characteristics
2. **Large Scale Efficiency**: Consistent O(1) performance with thousands of items
3. **Mathematical Correctness**: Provably exact probability matching
4. **No Recalculation**: No need to rebuild on each sample operation

### Preprocessing Algorithm Details

The constructor implements the classic Alias method:

```csharp
// Normalization: each weight * N / sum
double[] normalized = weights.Select(w => w * n / sum).ToArray();

// Partition into small (< 1.0) and large (>= 1.0) buckets
Queue<int> small = new Queue<int>();
Queue<int> large = new Queue<int>();

// Balance buckets by pairing small with large items
// Small items get aliases from large items
// Large items donate probability mass to balance
```

### Sampling Algorithm Efficiency

```csharp
public int Sample()
{
    int i = rand.Next(n);  // Random index [0, N-1]
    // Decide between index or its alias based on probability
    return rand.NextDouble() < probability[i] ? i : alias[i];
}
```

This two-step process ensures exact probability distribution while maintaining constant time complexity.

## 2.4.5 Integration with Mod Generation Systems

### Building Weight Lists from ModsData

```csharp
// Load mods from data files
ModsList allMods = HELYAMLFile.LoadMods("ModsData.asset");

// Extract weights (assuming mods have weight property)
List<int> weights = allMods.mods
    .Select(mod => mod.Weight ?? 1)  // Default weight 1 if not specified
    .ToList();

// Create picker for weighted selection
HELPicker modPicker = new HELPicker(weights);
```

### Handling Mod Rarity and Balancing

```csharp
// Define rarity-based weights
Dictionary<ModRarity, int> rarityWeights = new Dictionary<ModRarity, int>
{
    { ModRarity.Common, 1000 },
    { ModRarity.Uncommon, 300 },
    { ModRarity.Rare, 100 },
    { ModRarity.Epic, 30 },
    { ModRarity.Legendary, 10 }
};

// Build weight list based on mod rarities
List<int> weights = allMods.mods
    .Select(mod => rarityWeights[mod.Rarity])
    .ToList();
```

### Integration with Loot Drop Systems

```csharp
public class LootDropManager
{
    private HELPicker modPicker;
    private ModsList availableMods;
    
    public void InitializeDropTable(ModsList mods, List<int> dropWeights)
    {
        availableMods = mods;
        modPicker = new HELPicker(dropWeights);
    }
    
    public Mod GenerateLootDrop()
    {
        int selectedIndex = modPicker.Sample();
        return availableMods.mods[selectedIndex];
    }
    
    public List<Mod> GenerateMultipleDrops(int count)
    {
        return Enumerable.Range(0, count)
            .Select(_ => GenerateLootDrop())
            .ToList();
    }
}
```

### Player Progression Integration

```csharp
// Adjust weights based on player level/progression
public List<int> CalculateProgressionWeights(ModsList mods, int playerLevel)
{
    return mods.mods.Select(mod => {
        int baseWeight = mod.BaseWeight;
        
        // Increase weight for appropriate level mods
        if (mod.MinLevel <= playerLevel && mod.MaxLevel >= playerLevel)
            return baseWeight * 2;
        
        // Reduce weight for out-of-level mods
        if (mod.MinLevel > playerLevel)
            return Math.Max(1, baseWeight / 4);
            
        return baseWeight;
    }).ToList();
}
```

## 2.4.6 Usage Patterns and Examples

### Basic Setup and Sampling Example

```csharp
// Define mod weights (higher = more likely)
List<int> modWeights = new List<int> 
{
    100,  // Mod 0: Common (weight 100)
    50,   // Mod 1: Uncommon (weight 50)  
    25,   // Mod 2: Rare (weight 25)
    10,   // Mod 3: Epic (weight 10)
    5     // Mod 4: Legendary (weight 5)
};

// Create picker with O(N) preprocessing
HELPicker picker = new HELPicker(modWeights);

// Sample mods with O(1) operations
for (int i = 0; i < 1000; i++)
{
    int selectedMod = picker.Sample();
    Console.WriteLine($"Selected mod index: {selectedMod}");
}
```

### Integration with Mod Inventory Systems

```csharp
public class ModInventoryManager
{
    private HELPicker commonPicker;
    private HELPicker rarePicker;
    private ModsList allMods;
    
    public void Initialize(ModsList mods)
    {
        allMods = mods;
        
        // Separate pickers for different rarity tiers
        var commonMods = mods.mods.Where(m => m.Rarity <= ModRarity.Uncommon).ToList();
        var rareMods = mods.mods.Where(m => m.Rarity >= ModRarity.Rare).ToList();
        
        commonPicker = new HELPicker(commonMods.Select(m => m.Weight).ToList());
        rarePicker = new HELPicker(rareMods.Select(m => m.Weight).ToList());
    }
    
    public Mod SelectModForReward(RewardType type)
    {
        return type switch
        {
            RewardType.Common => GetCommonMod(),
            RewardType.Rare => GetRareMod(),
            _ => GetCommonMod()
        };
    }
    
    private Mod GetCommonMod()
    {
        int index = commonPicker.Sample();
        return allMods.mods.Where(m => m.Rarity <= ModRarity.Uncommon).ElementAt(index);
    }
    
    private Mod GetRareMod()
    {
        int index = rarePicker.Sample();
        return allMods.mods.Where(m => m.Rarity >= ModRarity.Rare).ElementAt(index);
    }
}
```

### Batch Mod Generation for Testing

```csharp
// Generate large batches for statistical analysis
public static Dictionary<int, int> GenerateModDistribution(
    HELPicker picker, int sampleCount = 100000)
{
    var distribution = new Dictionary<int, int>();
    
    for (int i = 0; i < sampleCount; i++)
    {
        int modIndex = picker.Sample();
        distribution[modIndex] = distribution.GetValueOrDefault(modIndex, 0) + 1;
    }
    
    return distribution;
}

// Validate distribution matches expected probabilities
public static void ValidateDistribution(List<int> weights, Dictionary<int, int> results)
{
    int totalSamples = results.Values.Sum();
    double totalWeight = weights.Sum();
    
    for (int i = 0; i < weights.Count; i++)
    {
        double expectedProbability = weights[i] / totalWeight;
        double actualProbability = results.GetValueOrDefault(i, 0) / (double)totalSamples;
        double error = Math.Abs(expectedProbability - actualProbability);
        
        Console.WriteLine($"Mod {i}: Expected {expectedProbability:P2}, " +
                         $"Actual {actualProbability:P2}, Error {error:P3}");
    }
}
```

### Weight Adjustment Strategies

```csharp
// Dynamic weight calculation based on game state
public class AdaptiveModPicker
{
    private ModsList allMods;
    private HELPicker currentPicker;
    
    public void UpdateWeights(PlayerState player, GameDifficulty difficulty)
    {
        List<int> adjustedWeights = allMods.mods.Select(mod => {
            int baseWeight = mod.BaseWeight;
            
            // Difficulty scaling
            if (difficulty == GameDifficulty.Hard && mod.PowerLevel > 5)
                baseWeight *= 2;  // More powerful mods in hard mode
            
            // Player stat considerations
            if (HasSynergy(mod, player.CurrentMods))
                baseWeight = (int)(baseWeight * 1.5);  // Boost synergistic mods
            
            // Prevent duplicate types
            if (player.HasModType(mod.Type))
                baseWeight /= 3;  // Reduce weight for owned types
                
            return Math.Max(1, baseWeight);  // Minimum weight of 1
        }).ToList();
        
        // Create new picker with updated weights
        currentPicker = new HELPicker(adjustedWeights);
    }
    
    public Mod SelectMod() => allMods.mods[currentPicker.Sample()];
}
```

## 2.4.7 Advanced Usage Scenarios

### Dynamic Weight Adjustment

Since HELPicker preprocesses weights during construction, dynamic weight changes require creating a new instance:

```csharp
public class DynamicModSelector
{
    private List<int> baseWeights;
    private ModsList mods;
    private HELPicker currentPicker;
    
    public void UpdateWeightMultipliers(Dictionary<int, double> multipliers)
    {
        List<int> newWeights = baseWeights.Select((weight, index) => {
            double multiplier = multipliers.GetValueOrDefault(index, 1.0);
            return Math.Max(1, (int)(weight * multiplier));
        }).ToList();
        
        // Recreate picker with new weights
        currentPicker = new HELPicker(newWeights);
    }
}
```

### Multi-Tier Mod Selection

```csharp
// Separate pickers for different mod categories
public class TieredModSystem
{
    private Dictionary<ModTier, HELPicker> tierPickers;
    private Dictionary<ModTier, List<Mod>> tierMods;
    
    public void InitializeTiers(ModsList allMods)
    {
        tierPickers = new Dictionary<ModTier, HELPicker>();
        tierMods = new Dictionary<ModTier, List<Mod>>();
        
        foreach (ModTier tier in Enum.GetValues<ModTier>())
        {
            var modsInTier = allMods.mods.Where(m => m.Tier == tier).ToList();
            var weights = modsInTier.Select(m => m.Weight).ToList();
            
            tierMods[tier] = modsInTier;
            tierPickers[tier] = new HELPicker(weights);
        }
    }
    
    public Mod SelectFromTier(ModTier tier)
    {
        int index = tierPickers[tier].Sample();
        return tierMods[tier][index];
    }
}
```

### Conditional Mod Selection

```csharp
// Select mods based on complex game state conditions
public class ConditionalModPicker
{
    public Mod SelectConditionalMod(PlayerState player, GameContext context)
    {
        // Filter available mods based on conditions
        var availableMods = allMods.Where(mod => 
            mod.IsAvailable(player, context) && 
            !mod.IsBlocked(player.CurrentMods)).ToList();
        
        if (!availableMods.Any())
            return GetFallbackMod();
        
        // Create temporary picker for filtered set
        var weights = availableMods.Select(m => 
            CalculateContextualWeight(m, player, context)).ToList();
        var picker = new HELPicker(weights);
        
        int selectedIndex = picker.Sample();
        return availableMods[selectedIndex];
    }
    
    private int CalculateContextualWeight(Mod mod, PlayerState player, GameContext context)
    {
        int weight = mod.BaseWeight;
        
        // Apply contextual modifiers
        if (context.NeedsDefensive && mod.HasDefensiveStats())
            weight *= 3;
        if (context.NeedsOffensive && mod.HasOffensiveStats())
            weight *= 3;
        if (player.HasSynergy(mod))
            weight = (int)(weight * 1.8);
            
        return weight;
    }
}
```

### Performance Monitoring and Profiling

```csharp
// Monitor picker performance characteristics
public class PickerProfiler
{
    public static void ProfilePerformance(List<int> weights, int iterations = 1000000)
    {
        var stopwatch = Stopwatch.StartNew();
        
        // Measure construction time
        var picker = new HELPicker(weights);
        stopwatch.Stop();
        Console.WriteLine($"Construction time: {stopwatch.ElapsedMilliseconds}ms");
        
        // Measure sampling performance
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            picker.Sample();
        }
        stopwatch.Stop();
        
        double samplesPerSecond = iterations / stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Sampling rate: {samplesPerSecond:N0} samples/second");
        Console.WriteLine($"Average time per sample: {stopwatch.Elapsed.TotalNanoseconds / iterations:F2} nanoseconds");
    }
    
    public static void CompareWithNaiveMethod(List<int> weights, int iterations = 100000)
    {
        // Alias method
        var aliasStopwatch = Stopwatch.StartNew();
        var picker = new HELPicker(weights);
        for (int i = 0; i < iterations; i++)
            picker.Sample();
        aliasStopwatch.Stop();
        
        // Naive weighted selection
        var naiveStopwatch = Stopwatch.StartNew();
        var random = new Random();
        int totalWeight = weights.Sum();
        for (int i = 0; i < iterations; i++)
        {
            int target = random.Next(totalWeight);
            int sum = 0;
            for (int j = 0; j < weights.Count; j++)
            {
                sum += weights[j];
                if (sum > target) break;
            }
        }
        naiveStopwatch.Stop();
        
        Console.WriteLine($"Alias method: {aliasStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Naive method: {naiveStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Speedup: {(double)naiveStopwatch.ElapsedMilliseconds / aliasStopwatch.ElapsedMilliseconds:F2}x");
    }
}
```

## 2.4.8 Comparison with Current HIOX

### Current Implementation Limitations

The current HIOX game system likely uses simple uniform random selection without considering mod weights:

```csharp
// Current: Simple uniform selection
int randomModIndex = random.Next(availableMods.Count);
Mod selectedMod = availableMods[randomModIndex];
```

### Enhanced Weight-Based Selection

HELPicker enables sophisticated weight-based selection:

```csharp
// Enhanced: Proper weight distribution
HELPicker picker = new HELPicker(modWeights);
int weightedModIndex = picker.Sample();  // O(1) with correct probabilities
```

### Benefits for Game Balance and Player Experience

1. **Improved Balance**: Rare mods remain rare, common mods appear frequently
2. **Player Progression**: Weights can adapt to player advancement
3. **Dynamic Difficulty**: Mod selection can respond to game state
4. **Performance**: O(1) selection enables real-time generation without lag
5. **Flexibility**: Easy weight adjustments for balance patches

### Integration Strategy

To integrate HELPicker into HIOX:

1. **Add Weight Properties**: Extend mod definitions with weight values
2. **Create Pickers**: Initialize HELPicker instances for different mod categories  
3. **Replace Selection Logic**: Update loot generation to use weighted selection
4. **Balance Testing**: Use HELPicker's efficiency for extensive balance validation
5. **Dynamic Systems**: Implement adaptive weighting based on player progression

## 2.4.9 Cross-References

- **Section 2.1**: [Integration Overview](2-1-Integration-Overview.md) - Setting up HEL system integration
- **Section 2.5**: [Integration Patterns](2-5-Integration-Patterns.md) - Common integration patterns and best practices  
- **Section 3.3**: [HELPicker Reference](3-3-HELPicker-Reference.md) - Complete API reference and technical details

---

*This documentation covers HELPicker usage patterns for HIOX game developers. The Alias method implementation provides mathematically optimal weighted selection with O(1) sampling performance.*

---

# 2.5 Common Integration Patterns

This section provides practical, production-ready integration patterns for HIOX game developers implementing the HEL system.

## 2.5.1 Application Initialization and Asset Loading

### Singleton Asset Manager Pattern

```csharp
public class HELAssetManager : MonoBehaviour
{
    private static HELAssetManager _instance;
    public static HELAssetManager Instance => _instance;
    
    private statsDictionary baseStats;
    private modsDictionary allMods;
    private bool isInitialized = false;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAssets();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void InitializeAssets()
    {
        try
        {
            // Load stats and mods from YAML assets
            var statsResult = HELYAMLFile.LoadAsset("Assets/Data/StatsData.asset", "stats:");
            baseStats = (statsDictionary)statsResult.Item1;
            
            var modsResult = HELYAMLFile.LoadAsset("Assets/Data/ModsData.asset", "mods:");
            allMods = (modsDictionary)modsResult.Item1;
            
            isInitialized = true;
            Debug.Log($"HEL Assets loaded: {baseStats.Count} stats, {allMods.Count} mods");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to initialize HEL assets: {ex.Message}");
            LoadFallbackAssets();
        }
    }
    
    private void LoadFallbackAssets()
    {
        // Minimal fallback stats for emergency operation
        baseStats = new statsDictionary
        {
            ["HEALTH"] = new Stat { name = "HEALTH", value = 100, min = 1, max = 1000 },
            ["DAMAGE"] = new Stat { name = "DAMAGE", value = 10, min = 1, max = 100 }
        };
        allMods = new modsDictionary();
        isInitialized = true;
    }
    
    public statsDictionary GetBaseStats() => 
        isInitialized ? new statsDictionary(baseStats) : new statsDictionary();
    
    public modsDictionary GetAllMods() => 
        isInitialized ? allMods : new modsDictionary();
}
```

### Lazy Loading Strategy

```csharp
public class LazyHELManager
{
    private static readonly Lazy<LazyHELManager> _instance = 
        new Lazy<LazyHELManager>(() => new LazyHELManager());
    public static LazyHELManager Instance => _instance.Value;
    
    private readonly Lazy<statsDictionary> _baseStats;
    private readonly Lazy<modsDictionary> _allMods;
    
    private LazyHELManager()
    {
        _baseStats = new Lazy<statsDictionary>(LoadStats);
        _allMods = new Lazy<modsDictionary>(LoadMods);
    }
    
    public statsDictionary BaseStats => _baseStats.Value;
    public modsDictionary AllMods => _allMods.Value;
    
    private statsDictionary LoadStats()
    {
        var result = HELYAMLFile.LoadAsset("Assets/Data/StatsData.asset", "stats:");
        return (statsDictionary)result.Item1;
    }
    
    private modsDictionary LoadMods()
    {
        var result = HELYAMLFile.LoadAsset("Assets/Data/ModsData.asset", "mods:");
        return (modsDictionary)result.Item1;
    }
}
```

## 2.5.2 Player Mod Inventory Management

### Mod Inventory Controller

```csharp
public class PlayerModInventory : MonoBehaviour
{
    private Dictionary<int, int> modInventory = new Dictionary<int, int>();
    private statsDictionary currentStats;
    
    // Events for UI updates
    public event Action<int, int> OnModAdded;
    public event Action<int> OnModRemoved;
    public event Action<statsDictionary> OnStatsUpdated;
    
    public void AddMod(int modId, int count = 1)
    {
        if (!HELAssetManager.Instance.GetAllMods().ContainsKey(modId))
        {
            Debug.LogWarning($"Attempted to add unknown mod ID: {modId}");
            return;
        }
        
        if (modInventory.ContainsKey(modId))
            modInventory[modId] += count;
        else
            modInventory[modId] = count;
        
        OnModAdded?.Invoke(modId, count);
        RecalculateStats();
    }
    
    public bool RemoveMod(int modId, int count = 1)
    {
        if (!modInventory.ContainsKey(modId) || modInventory[modId] < count)
            return false;
        
        modInventory[modId] -= count;
        if (modInventory[modId] <= 0)
        {
            modInventory.Remove(modId);
            OnModRemoved?.Invoke(modId);
        }
        
        RecalculateStats();
        return true;
    }
    
    public void ClearAllMods()
    {
        modInventory.Clear();
        RecalculateStats();
    }
    
    public Dictionary<int, int> GetModInventory() => 
        new Dictionary<int, int>(modInventory);
    
    private void RecalculateStats()
    {
        try
        {
            currentStats = HEL.EvaluateMods(
                HELAssetManager.Instance.GetBaseStats(),
                HELAssetManager.Instance.GetAllMods(),
                modInventory
            );
            OnStatsUpdated?.Invoke(currentStats);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to recalculate stats: {ex.Message}");
            currentStats = HELAssetManager.Instance.GetBaseStats();
        }
    }
    
    public statsDictionary GetCurrentStats() => 
        currentStats ?? HELAssetManager.Instance.GetBaseStats();
}
```

## 2.5.3 Real-Time Stat Calculation During Gameplay

### Performance-Optimized Stat Calculator

```csharp
public class OptimizedStatCalculator : MonoBehaviour
{
    private statsDictionary cachedStats;
    private Dictionary<int, int> lastModInventory;
    private DateTime lastCalculation;
    private readonly TimeSpan cacheTimeout = TimeSpan.FromSeconds(0.1f); // 100ms cache
    
    public statsDictionary GetCurrentStats(Dictionary<int, int> modInventory)
    {
        // Check if we can use cached result
        if (cachedStats != null && 
            DateTime.Now - lastCalculation < cacheTimeout &&
            InventoryEquals(modInventory, lastModInventory))
        {
            return cachedStats;
        }
        
        // Recalculate and cache
        var startTime = DateTime.Now;
        
        try
        {
            cachedStats = HEL.EvaluateMods(
                HELAssetManager.Instance.GetBaseStats(),
                HELAssetManager.Instance.GetAllMods(),
                modInventory
            );
            
            lastModInventory = new Dictionary<int, int>(modInventory ?? new Dictionary<int, int>());
            lastCalculation = DateTime.Now;
            
            var duration = DateTime.Now - startTime;
            if (duration.TotalMilliseconds > 10) // Log slow calculations
            {
                Debug.LogWarning($"Slow stat calculation: {duration.TotalMilliseconds:F2}ms for {modInventory?.Count ?? 0} mods");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Stat calculation failed: {ex.Message}");
            cachedStats = HELAssetManager.Instance.GetBaseStats();
        }
        
        return cachedStats;
    }
    
    private bool InventoryEquals(Dictionary<int, int> a, Dictionary<int, int> b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;
        if (a.Count != b.Count) return false;
        
        foreach (var kvp in a)
        {
            if (!b.TryGetValue(kvp.Key, out int value) || value != kvp.Value)
                return false;
        }
        return true;
    }
}
```

### Unity Component Integration

```csharp
public class PlayerStatsComponent : MonoBehaviour
{
    [SerializeField] private PlayerModInventory modInventory;
    [SerializeField] private OptimizedStatCalculator statCalculator;
    
    // Unity-friendly stat properties
    public float Health => GetStatValue("HEALTH");
    public float MaxHealth => GetStatValue("MAXHEALTH");
    public float Damage => GetStatValue("DAMAGE");
    public float Speed => GetStatValue("PLAYERSPEED");
    
    private statsDictionary currentStats;
    
    private void Start()
    {
        if (modInventory != null)
            modInventory.OnStatsUpdated += OnStatsChanged;
        
        RefreshStats();
    }
    
    private void OnStatsChanged(statsDictionary newStats)
    {
        currentStats = newStats;
        
        // Update Unity components based on new stats
        UpdateMovementSpeed();
        UpdateHealthSystem();
        UpdateWeaponDamage();
    }
    
    private float GetStatValue(string statName)
    {
        if (currentStats != null && currentStats.TryGetValue(statName.ToUpper(), out Stat stat))
            return stat.value;
        return 0f;
    }
    
    private void RefreshStats()
    {
        if (modInventory != null && statCalculator != null)
        {
            currentStats = statCalculator.GetCurrentStats(modInventory.GetModInventory());
            OnStatsChanged(currentStats);
        }
    }
    
    private void UpdateMovementSpeed()
    {
        var movement = GetComponent<CharacterController>();
        if (movement != null)
        {
            // Apply speed stat to character controller
            var speedMultiplier = Speed / 100f; // Normalize speed stat
            // Update movement component with new speed
        }
    }
    
    private void UpdateHealthSystem()
    {
        var healthComponent = GetComponent<HealthSystem>();
        if (healthComponent != null)
        {
            healthComponent.SetMaxHealth(MaxHealth);
            // Adjust current health proportionally if needed
        }
    }
    
    private void UpdateWeaponDamage()
    {
        var weapon = GetComponent<WeaponSystem>();
        if (weapon != null)
        {
            weapon.SetBaseDamage(Damage);
        }
    }
}
```

## 2.5.4 Mod Effect Previewing and Analysis

### Mod Preview System

```csharp
public class ModPreviewSystem : MonoBehaviour
{
    public struct StatComparison
    {
        public string statName;
        public float currentValue;
        public float previewValue;
        public float difference;
        public float percentChange;
    }
    
    public List<StatComparison> PreviewModAddition(int modId, int count = 1)
    {
        var currentInventory = GetCurrentModInventory();
        var previewInventory = new Dictionary<int, int>(currentInventory);
        
        // Add the preview mod
        if (previewInventory.ContainsKey(modId))
            previewInventory[modId] += count;
        else
            previewInventory[modId] = count;
        
        return CompareStats(currentInventory, previewInventory);
    }
    
    public List<StatComparison> PreviewModRemoval(int modId, int count = 1)
    {
        var currentInventory = GetCurrentModInventory();
        var previewInventory = new Dictionary<int, int>(currentInventory);
        
        // Remove the preview mod
        if (previewInventory.ContainsKey(modId))
        {
            previewInventory[modId] -= count;
            if (previewInventory[modId] <= 0)
                previewInventory.Remove(modId);
        }
        
        return CompareStats(currentInventory, previewInventory);
    }
    
    private List<StatComparison> CompareStats(Dictionary<int, int> currentInventory, Dictionary<int, int> previewInventory)
    {
        var baseStats = HELAssetManager.Instance.GetBaseStats();
        var allMods = HELAssetManager.Instance.GetAllMods();
        
        var currentStats = HEL.EvaluateMods(baseStats, allMods, currentInventory);
        var previewStats = HEL.EvaluateMods(baseStats, allMods, previewInventory);
        
        var comparisons = new List<StatComparison>();
        
        foreach (var statName in baseStats.Keys)
        {
            var current = currentStats[statName].value;
            var preview = previewStats[statName].value;
            var difference = preview - current;
            var percentChange = current != 0 ? (difference / current) * 100 : 0;
            
            if (Math.Abs(difference) > 0.001f) // Only include changed stats
            {
                comparisons.Add(new StatComparison
                {
                    statName = statName,
                    currentValue = current,
                    previewValue = preview,
                    difference = difference,
                    percentChange = percentChange
                });
            }
        }
        
        return comparisons;
    }
    
    private Dictionary<int, int> GetCurrentModInventory()
    {
        var inventory = FindObjectOfType<PlayerModInventory>();
        return inventory?.GetModInventory() ?? new Dictionary<int, int>();
    }
}
```

## 2.5.5 Integration with Existing HIOX Systems

### Event-Driven Stat System

```csharp
public class HIOXStatEventSystem : MonoBehaviour
{
    // Events for different stat change types
    public static event Action<string, float, float> OnStatChanged; // statName, oldValue, newValue
    public static event Action<Dictionary<int, int>> OnModInventoryChanged;
    public static event Action<int, int> OnModAcquired; // modId, newCount
    
    private PlayerModInventory modInventory;
    private statsDictionary previousStats = new statsDictionary();
    
    private void Start()
    {
        modInventory = GetComponent<PlayerModInventory>();
        if (modInventory != null)
        {
            modInventory.OnStatsUpdated += HandleStatsUpdated;
            modInventory.OnModAdded += HandleModAdded;
        }
    }
    
    private void HandleStatsUpdated(statsDictionary newStats)
    {
        // Compare with previous stats and fire events for changes
        foreach (var kvp in newStats)
        {
            var statName = kvp.Key;
            var newValue = kvp.Value.value;
            
            if (previousStats.TryGetValue(statName, out Stat oldStat))
            {
                var oldValue = oldStat.value;
                if (Math.Abs(newValue - oldValue) > 0.001f)
                {
                    OnStatChanged?.Invoke(statName, oldValue, newValue);
                }
            }
            else
            {
                OnStatChanged?.Invoke(statName, 0f, newValue);
            }
        }
        
        previousStats = new statsDictionary(newStats);
    }
    
    private void HandleModAdded(int modId, int count)
    {
        OnModAcquired?.Invoke(modId, count);
        OnModInventoryChanged?.Invoke(modInventory.GetModInventory());
    }
}
```

### Save System Integration (Session Data)

```csharp
public class HIOXSessionData : MonoBehaviour
{
    [System.Serializable]
    public class SessionModData
    {
        public List<int> modIds = new List<int>();
        public List<int> modCounts = new List<int>();
        
        public Dictionary<int, int> ToInventory()
        {
            var inventory = new Dictionary<int, int>();
            for (int i = 0; i < modIds.Count && i < modCounts.Count; i++)
            {
                inventory[modIds[i]] = modCounts[i];
            }
            return inventory;
        }
        
        public void FromInventory(Dictionary<int, int> inventory)
        {
            modIds.Clear();
            modCounts.Clear();
            foreach (var kvp in inventory)
            {
                modIds.Add(kvp.Key);
                modCounts.Add(kvp.Value);
            }
        }
    }
    
    [SerializeField] private SessionModData sessionMods = new SessionModData();
    
    public void SaveCurrentSession()
    {
        var inventory = FindObjectOfType<PlayerModInventory>();
        if (inventory != null)
        {
            sessionMods.FromInventory(inventory.GetModInventory());
            
            // Save to PlayerPrefs for session persistence
            var json = JsonUtility.ToJson(sessionMods);
            PlayerPrefs.SetString("HIOXSessionMods", json);
            PlayerPrefs.Save();
        }
    }
    
    public void LoadSession()
    {
        if (PlayerPrefs.HasKey("HIOXSessionMods"))
        {
            var json = PlayerPrefs.GetString("HIOXSessionMods");
            sessionMods = JsonUtility.FromJson<SessionModData>(json);
            
            var inventory = FindObjectOfType<PlayerModInventory>();
            if (inventory != null)
            {
                inventory.ClearAllMods();
                var loadedInventory = sessionMods.ToInventory();
                foreach (var kvp in loadedInventory)
                {
                    inventory.AddMod(kvp.Key, kvp.Value);
                }
            }
        }
    }
    
    public void ClearSession()
    {
        PlayerPrefs.DeleteKey("HIOXSessionMods");
        sessionMods = new SessionModData();
    }
}
```

## 2.5.6 Error Handling and Robustness Patterns

### Comprehensive Error Handler

```csharp
public class HELErrorHandler : MonoBehaviour
{
    public enum ErrorSeverity { Info, Warning, Error, Critical }
    
    public static event Action<string, ErrorSeverity> OnErrorLogged;
    
    public static T SafeExecute<T>(Func<T> operation, T fallbackValue, string operationName)
    {
        try
        {
            return operation();
        }
        catch (KeyNotFoundException ex)
        {
            LogError($"Missing data in {operationName}: {ex.Message}", ErrorSeverity.Error);
            return fallbackValue;
        }
        catch (ArgumentException ex)
        {
            LogError($"Invalid argument in {operationName}: {ex.Message}", ErrorSeverity.Error);
            return fallbackValue;
        }
        catch (Exception ex)
        {
            LogError($"Unexpected error in {operationName}: {ex.Message}", ErrorSeverity.Critical);
            return fallbackValue;
        }
    }
    
    public static void SafeExecute(Action operation, string operationName)
    {
        try
        {
            operation();
        }
        catch (Exception ex)
        {
            LogError($"Error in {operationName}: {ex.Message}", ErrorSeverity.Error);
        }
    }
    
    private static void LogError(string message, ErrorSeverity severity)
    {
        switch (severity)
        {
            case ErrorSeverity.Info:
                Debug.Log($"[HEL] {message}");
                break;
            case ErrorSeverity.Warning:
                Debug.LogWarning($"[HEL] {message}");
                break;
            case ErrorSeverity.Error:
                Debug.LogError($"[HEL] {message}");
                break;
            case ErrorSeverity.Critical:
                Debug.LogError($"[HEL CRITICAL] {message}");
                break;
        }
        
        OnErrorLogged?.Invoke(message, severity);
    }
}
```

## 2.5.7 Development and Testing Patterns

### Mod Testing Framework

```cshrap
public class ModTestingFramework : MonoBehaviour
{
    [System.Serializable]
    public class ModTestCase
    {
        public string testName;
        public List<int> modIds;
        public List<int> modCounts;
        public Dictionary<string, float> expectedStats;
        public float tolerance = 0.001f;
    }
    
    public List<ModTestCase> testCases = new List<ModTestCase>();
    
    [ContextMenu("Run All Tests")]
    public void RunAllTests()
    {
        int passed = 0;
        int failed = 0;
        
        foreach (var testCase in testCases)
        {
            if (RunSingleTest(testCase))
                passed++;
            else
                failed++;
        }
        
        Debug.Log($"Mod Tests Complete: {passed} passed, {failed} failed");
    }
    
    private bool RunSingleTest(ModTestCase testCase)
    {
        try
        {
            // Build mod inventory
            var inventory = new Dictionary<int, int>();
            for (int i = 0; i < testCase.modIds.Count && i < testCase.modCounts.Count; i++)
            {
                inventory[testCase.modIds[i]] = testCase.modCounts[i];
            }
            
            // Calculate stats
            var result = HEL.EvaluateMods(
                HELAssetManager.Instance.GetBaseStats(),
                HELAssetManager.Instance.GetAllMods(),
                inventory
            );
            
            // Verify expected results
            bool testPassed = true;
            foreach (var expected in testCase.expectedStats)
            {
                if (result.TryGetValue(expected.Key.ToUpper(), out Stat actualStat))
                {
                    if (Math.Abs(actualStat.value - expected.Value) > testCase.tolerance)
                    {
                        Debug.LogError($"Test '{testCase.testName}' failed: {expected.Key} expected {expected.Value}, got {actualStat.value}");
                        testPassed = false;
                    }
                }
                else
                {
                    Debug.LogError($"Test '{testCase.testName}' failed: Stat {expected.Key} not found in results");
                    testPassed = false;
                }
            }
            
            if (testPassed)
                Debug.Log($"Test '{testCase.testName}' passed");
            
            return testPassed;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Test '{testCase.testName}' threw exception: {ex.Message}");
            return false;
        }
    }
}
```

## 2.5.8 Cross-References

- [Section 2.1 - Integration Overview](2-1-Integration-Overview.md) - Foundational integration concepts
- [Section 2.2 - HEL Class Usage](2-2-HEL-Class-Usage.md) - Core HEL.EvaluateMods() usage patterns  
- [Section 2.3 - Asset Management](2-3-Asset-Management.md) - File loading and data management
- [Section 2.4 - HELPicker Usage](2-4-HELPicker-Usage.md) - Weighted random mod selection
- [Section 3.1 - HEL Class Reference](3-1-HEL-Class-Reference.md) - Complete API documentation

These patterns provide production-ready code for integrating the HEL system into HIOX game projects, covering initialization, inventory management, real-time calculations, previewing, and robust error handling.

---

# 3. Class/Method Reference



---

# 3.1 HEL Class API Reference

## 3.1.1 Overview

The `HEL` class is the core entry point for the HIOX Equation Language system, providing static methods for evaluating mod equations and calculating stat modifications. This class is designed for maximum performance and thread safety through a stateless architecture.

### Key Characteristics

- **Stateless Design**: All methods are static with no internal state, enabling safe concurrent usage
- **Thread Safety**: Multiple threads can safely call HEL methods simultaneously 
- **Performance Optimized**: Minimal memory allocation and efficient processing pipelines
- **Exception Safe**: Well-defined error conditions with appropriate exception types

### Architecture Integration

The HEL class orchestrates the complete equation evaluation pipeline:
- **HELLexer**: Tokenizes equation strings
- **HELInterpreter**: Executes parsed tokens against statistics  
- **HELOrdering**: Handles dependency resolution and evaluation ordering

## 3.1.2 Primary Interface

### EvaluateMods() Method

The main interface for evaluating mod collections against game statistics.

#### Signature
```csharp
public static statsDictionary EvaluateMods(
    statsDictionary statsDict, 
    modsDictionary modsDict
)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `statsDict` | `Dictionary<string, Stat>` | Base statistics dictionary keyed by stat name (case-insensitive) |
| `modsDict` | `Dictionary<string, Mod>` | Equipped mods dictionary keyed by UUID |

#### Returns
- **Type**: `statsDictionary` (Dictionary<string, Stat>)
- **Description**: New statistics dictionary containing updated values after applying all mod equations

#### Exceptions

| Exception Type | Condition |
|----------------|-----------|
| `KeyNotFoundException` | Thrown when a mod ID in playerModInventory is not found in modsDict |
| `ArgumentException` | Thrown when mod equations contain syntax errors |

#### Processing Flow

1. **Input Sanitization**: Creates defensive copies of input dictionaries with uppercase stat names
2. **Mod Sorting**: Sorts mod IDs to ensure consistent evaluation order
3. **Equation Assembly**: Concatenates all applicable mod equations with proper delimiters
4. **Variable Substitution**: Replaces VAL, VAL1, VAL2 references with actual mod values
5. **Evaluation**: Processes assembled equation string through tokenizer and interpreter

#### Performance Characteristics

- **Time Complexity**: O(n*m + k*log k) where n=active mods, m=equations per mod, k=mod count
- **Space Complexity**: O(s + m) where s=stat count, m=total equation length
- **Memory Allocation**: Creates new stat dictionary copy for thread safety

#### Usage Examples

##### Basic Mod Evaluation
```csharp
// Load base game data
var stats = LoadStatsFromAsset("StatsData.asset");
var mods = LoadModsFromAsset("ModsData.asset");

// Player has 2 copies of mod 101 and 1 copy of mod 205
var playerMods = new Dictionary<int, int> {
    { 101, 2 },  // Health boost mod x2
    { 205, 1 }   // Speed enhancement mod x1
};

try {
    var resultStats = HEL.EvaluateMods(stats, mods, playerMods);
    
    // Access modified stats
    float newHealth = resultStats["HEALTH"].value;
    float newSpeed = resultStats["SPEED"].value;
    
    Console.WriteLine($"Health: {newHealth}, Speed: {newSpeed}");
} 
catch (KeyNotFoundException ex) {
    Console.WriteLine($"Mod not found: {ex.Message}");
}
catch (ArgumentException ex) {
    Console.WriteLine($"Equation error: {ex.Message}");
}
```

##### Error Handling Wrapper
```csharp
public static class SafeHELEvaluator 
{
    public static (bool success, statsDictionary? results, string? error) 
        TryEvaluateMods(statsDictionary stats, modsDictionary mods, 
                       Dictionary<int, int>? playerMods = null)
    {
        try {
            var results = HEL.EvaluateMods(stats, mods, playerMods);
            return (true, results, null);
        }
        catch (KeyNotFoundException ex) {
            return (false, null, $"Missing mod: {ex.Message}");
        }
        catch (ArgumentException ex) {
            return (false, null, $"Syntax error: {ex.Message}");
        }
        catch (Exception ex) {
            return (false, null, $"Unexpected error: {ex.Message}");
        }
    }
}
```

##### Performance Monitoring
```csharp
using System.Diagnostics;

public static statsDictionary EvaluateWithTiming(
    statsDictionary stats, modsDictionary mods, Dictionary<int, int> playerMods)
{
    var sw = Stopwatch.StartNew();
    
    var results = HEL.EvaluateMods(stats, mods, playerMods);
    
    sw.Stop();
    Console.WriteLine($"Evaluation completed in {sw.ElapsedMilliseconds}ms");
    
    return results;
}
```

## 3.1.3 Equation Processing Methods

### PrepareEquation() Method

Preprocesses individual mod equations for evaluation by performing variable substitutions.

#### Signature
```csharp
public static string PrepareEquation(Mod mod)
```

#### Parameters
- **mod**: `Mod` object containing equation string and val/val2 properties

#### Returns
- **Type**: `string`
- **Description**: Formatted equation string with VAL substitutions and proper delimiters

#### Processing Details

1. **Comment Encoding**: Adds mod ID as encoded comment for debugging/tracking
2. **Case Normalization**: Converts equation to uppercase for consistency
3. **Variable Substitution**: Replaces placeholders with actual values:
   - `VAL1` → `mod.val` (formatted)
   - `VAL2` → `mod.val2` (formatted)  
   - `VAL` → `mod.val` (formatted, processed after VAL1/VAL2)
4. **Delimiter Addition**: Adds semicolons for proper tokenization

#### Usage Examples

##### Basic Equation Preparation
```csharp
var healthMod = new Mod {
    modid = 101,
    equation = "S_HEALTH = S_HEALTH VAL +",
    val = 25.5f,
    val2 = 0f
};

string prepared = HEL.PrepareEquation(healthMod);
// Result: "#!101;S_HEALTH = S_HEALTH 25.5 +;"
```

##### Complex Multi-Value Equation
```csharp
var combatMod = new Mod {
    modid = 205,
    equation = "M_DAMAGE = M_DAMAGE VAL1 +; A_SPEED = A_SPEED VAL2 +",
    val = 1.25f,    // VAL1 value
    val2 = 10.0f    // VAL2 value
};

string prepared = HEL.PrepareEquation(combatMod);
// Result: "#!205;M_DAMAGE = M_DAMAGE 1.25 +; A_SPEED = A_SPEED 10 +;"
```

### FormatFloat() Method

Formats floating-point values for consistent use in HEL equations.

#### Signature
```csharp
public static string FormatFloat(float f)
```

#### Parameters
- **f**: `float` value to format

#### Returns
- **Type**: `string`
- **Description**: String representation suitable for equation substitution

#### Formatting Rules

1. **Precision**: Rounds to 7 decimal places using banker's rounding
2. **Zero Threshold**: Values with absolute value < 1e-7 become "0"
3. **Format String**: Uses "0.#######" to suppress trailing zeros
4. **Culture Invariant**: Uses standard numeric formatting (decimal point, not comma)

#### Usage Examples

##### Precision Handling
```csharp
string result1 = HEL.FormatFloat(3.1415926535f);
// Result: "3.1415927" (rounded to 7 decimal places)

string result2 = HEL.FormatFloat(1.23000000f);
// Result: "1.23" (trailing zeros suppressed)

string result3 = HEL.FormatFloat(0.0000001f);
// Result: "0" (below threshold)

string result4 = HEL.FormatFloat(-5.0f);
// Result: "-5" (integer values display without decimal)
```

##### Integration with Equation Building
```csharp
public static string BuildDynamicEquation(string statName, float baseValue, float modifier)
{
    return $"{statName} = {HEL.FormatFloat(baseValue)} {HEL.FormatFloat(modifier)} +";
}

// Usage
string equation = BuildDynamicEquation("S_HEALTH", 100.0f, 25.333333f);
// Result: "S_HEALTH = 100 25.3333333 +"
```

## 3.1.4 Direct Evaluation Method

### EvaluateEquation() Method

Directly evaluates a HEL equation string against statistics without mod processing.

#### Signature
```csharp
public static statsDictionary EvaluateEquation(string input, statsDictionary stats)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `input` | `string` | HEL equation string (can contain multiple statements separated by newlines) |
| `stats` | `statsDictionary` | Base statistics dictionary to operate against |

#### Returns
- **Type**: `statsDictionary`
- **Description**: New statistics dictionary with updated values after equation evaluation

#### Exceptions

| Exception Type | Condition |
|----------------|-----------|
| `ArgumentException` | Equation string contains syntax errors |
| `InvalidOperationException` | Evaluation encounters runtime errors (division by zero, undefined variables) |

#### Processing Pipeline

1. **Tokenization**: Breaks equation string into tokens using HELLexer
2. **Interpretation**: Executes tokens against stats using HELInterpreter
3. **Result Generation**: Returns new stats dictionary with modifications applied

#### Usage Examples

##### Simple Equation Testing
```csharp
var baseStats = new Dictionary<string, Stat> {
    { "HEALTH", new Stat { name = "HEALTH", value = 100f } },
    { "DAMAGE", new Stat { name = "DAMAGE", value = 10f } }
};

string equation = "S_HEALTH = S_HEALTH 50 +; M_DAMAGE = M_DAMAGE 0.25 +";

try {
    var results = HEL.EvaluateEquation(equation, baseStats);
    
    Console.WriteLine($"New Health: {results["HEALTH"].value}");    // 150
    Console.WriteLine($"New Damage: {results["DAMAGE"].value}");    // 12.5
}
catch (ArgumentException ex) {
    Console.WriteLine($"Syntax error: {ex.Message}");
}
```

##### Debugging Mod Equations
```csharp
public static void TestModEquation(Mod mod, statsDictionary testStats)
{
    try {
        // Prepare the equation as it would be processed
        string preparedEquation = HEL.PrepareEquation(mod);
        Console.WriteLine($"Testing equation: {preparedEquation}");
        
        // Evaluate against test stats
        var results = HEL.EvaluateEquation(preparedEquation, testStats);
        
        // Display changes
        foreach (var kvp in results) {
            var originalValue = testStats.ContainsKey(kvp.Key) ? 
                               testStats[kvp.Key].value : 0f;
            Console.WriteLine($"{kvp.Key}: {originalValue} → {kvp.Value.value}");
        }
    }
    catch (Exception ex) {
        Console.WriteLine($"Equation test failed: {ex.Message}");
    }
}
```

##### Multi-Statement Equation Processing
```csharp
public static statsDictionary ProcessEquationBatch(List<string> equations, 
                                                  statsDictionary baseStats)
{
    // Combine multiple equations into single input
    string combinedInput = string.Join("\n", equations) + "\n$";  // EOF marker
    
    return HEL.EvaluateEquation(combinedInput, baseStats);
}

// Usage
var equations = new List<string> {
    "S_HEALTH = S_HEALTH 1.1 *",      // 10% health boost
    "A_ARMOR = A_ARMOR 5 +",          // +5 armor
    "M_SPEED = M_SPEED 0.15 +"        // 15% speed increase
};

var results = ProcessEquationBatch(equations, baseStats);
```

## 3.1.5 Integration Guidelines

### Asset Loading Integration
```csharp
public class GameStatsManager 
{
    private readonly statsDictionary _baseStats;
    private readonly modsDictionary _allMods;
    
    public GameStatsManager(string statsPath, string modsPath) {
        _baseStats = HELYAMLFile.LoadStatsFromAsset(statsPath);
        _allMods = HELYAMLFile.LoadModsFromAsset(modsPath);
    }
    
    public statsDictionary CalculatePlayerStats(Dictionary<int, int> playerMods) {
        return HEL.EvaluateMods(_baseStats, equippedMods);  
    }
}
```

### Performance Optimization
```csharp
public class OptimizedHELProcessor
{
    // Cache prepared equations to avoid repeated string processing
    private static readonly ConcurrentDictionary<int, string> _equationCache 
        = new ConcurrentDictionary<int, string>();
    
    public static string GetPreparedEquation(Mod mod) {
        return _equationCache.GetOrAdd(mod.modid, _ => HEL.PrepareEquation(mod));
    }
    
    // Batch processing for multiple evaluations
    public static List<statsDictionary> EvaluateMultipleLoadouts(
        statsDictionary baseStats, 
        modsDictionary mods,
        List<Dictionary<int, int>> loadouts)
    {
        return loadouts.AsParallel()
                      .Select(loadout => HEL.EvaluateMods(baseStats, mods, loadout))
                      .ToList();
    }
}
```

### Error Recovery Patterns
```csharp
public static class RobustEvaluator
{
    public static statsDictionary EvaluateWithFallback(
        statsDictionary stats, 
        modsDictionary mods, 
        Dictionary<int, int> playerMods)
    {
        try {
            return HEL.EvaluateMods(stats, mods, playerMods);
        }
        catch (KeyNotFoundException ex) {
            // Log the error and retry with valid mods only
            var validMods = playerMods.Where(kvp => mods.ContainsKey(kvp.Key))
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            
            Console.WriteLine($"Removed invalid mods, retrying with {validMods.Count} mods");
            return HEL.EvaluateMods(stats, mods, validMods);
        }
        catch (ArgumentException ex) {
            // Return base stats if equations are malformed
            Console.WriteLine($"Equation error, returning base stats: {ex.Message}");
            return new Dictionary<string, Stat>(stats);
        }
    }
}
```

## 3.1.6 Thread Safety and Concurrency

The HEL class is fully thread-safe due to its stateless design:

- **Static Methods**: No instance state to corrupt
- **Immutable Inputs**: Input dictionaries are copied, not modified
- **Local Variables**: All processing uses local stack variables
- **No Shared State**: Each method call operates independently

### Concurrent Usage Example
```csharp
public static async Task<List<statsDictionary>> EvaluateAsync(
    statsDictionary baseStats,
    modsDictionary mods, 
    List<Dictionary<int, int>> playerLoadouts)
{
    var tasks = playerLoadouts.Select(async loadout => 
        await Task.Run(() => HEL.EvaluateMods(baseStats, mods, loadout))
    );
    
    return (await Task.WhenAll(tasks)).ToList();
}
```

## 3.1.7 Memory Management

### Allocation Patterns
- **Input Copying**: Creates defensive copies of all input dictionaries
- **String Building**: Uses StringBuilder for equation assembly to minimize allocations
- **Result Creation**: Returns new stat dictionary to maintain immutability

### Memory Optimization Tips
```csharp
// Reuse base stat/mod dictionaries across evaluations
private static readonly statsDictionary _cachedStats = LoadStatsOnce();
private static readonly modsDictionary _cachedMods = LoadModsOnce();

public static statsDictionary FastEvaluate(Dictionary<int, int> playerMods) {
    return HEL.EvaluateMods(_cachedStats, _cachedMods, playerMods);
}
```

## 3.1.8 Cross-References

- **Section 2.2**: [HEL Class Usage Patterns](2-2-HEL-Class-Usage.md) - Practical usage examples and integration patterns
- **Section 3.2**: [HELInterpreter API Reference](3-2-HELInterpreter-Reference.md) - Lower-level interpretation details
- **Section 3.3**: [HELLexer API Reference](3-3-HELLexer-Reference.md) - Tokenization process documentation
- **Section 1.3**: [HEL Syntax Reference](1-3-HEL-Syntax.md) - Equation syntax and language features
- **Section 1.5**: [Stat Value Computation](1-5-Stat-Value-Computation.md) - How final stat values are calculated

---

# 3.2 File I/O Classes Reference

This section provides complete API documentation for the HEL file I/O classes that handle loading and saving asset data in both YAML and CSV formats.

## 3.2.1 Table of Contents

1. [HELYAMLFile Class](#helyamlfile-class)
2. [HELCSVFile Class](#helcsvfile-class) 
3. [Common Patterns](#common-patterns)
4. [Integration Examples](#integration-examples)

---

## 3.2.2 HELYAMLFile Class

### 3.2.2.1 Class Overview

The `HELYAMLFile` class handles Unity YAML asset file loading and saving operations for the HEL system. It provides serialization and deserialization capabilities for both mod and stat data using the YamlDotNet library.

**Key Features:**
- Unity YAML asset file support with proper headers and metadata
- Automatic asset type detection based on root node names
- YamlDotNet integration with camelCase naming conventions
- Support for both ModsData and StatsData asset types
- Robust error handling for file operations

**Dependencies:**
- YamlDotNet 16.1.3 for YAML parsing
- System.IO for file operations
- HELAssetDefs for data structures (Mod, Stat, ModsList, StatsList)

**Usage Context:**
Used primarily by the Editor application but can also be integrated with the HEL class for asset loading operations in production scenarios.

### 3.2.2.2 LoadAsset() Method

Loads a YAML asset file and returns the appropriate data structure based on the root node type.

```csharp
public static (object, object?) LoadAsset(string path, string root)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `path` | `string` | The absolute or relative file path to the YAML asset file |
| `root` | `string` | The name of the root node in the YAML file used for parsing and asset type detection |

#### Return Value

Returns a tuple `(object, object?)` where:
- **First Element**: Either a `Dictionary<int, Mod>` (modsDictionary) or `Dictionary<string, Stat>` (statsDictionary)
- **Second Element**: `null` for mods data, or `List<string>` statsOrder for stats data containing the original load order

#### Asset Type Detection Logic

The method determines asset type based on the first character of the `root` parameter:
- If `root[0] == 'm'`: Loads as mods data (ModsList)
- Otherwise: Loads as stats data (StatsList)

#### Exceptions

| Exception | Condition |
|-----------|-----------|
| `FileNotFoundException` | Thrown when the specified file does not exist |
| `YamlException` | Thrown when YAML parsing fails due to malformed content |
| `ArgumentException` | Thrown when the specified root node name is not found in the file |

#### Example Usage

**Loading Mods Data:**
```csharp
try 
{
    var (modsData, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsData");
    var modsDict = (Dictionary<int, Mod>)modsData;
    
    Console.WriteLine($"Loaded {modsDict.Count} mods");
    foreach (var mod in modsDict.Values)
    {
        Console.WriteLine($"Mod {mod.modid}: {mod.name}");
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Asset file not found: {ex.FileName}");
}
catch (YamlException ex)
{
    Console.WriteLine($"YAML parsing error: {ex.Message}");
}
```

**Loading Stats Data:**
```csharp
try 
{
    var (statsData, statsOrder) = HELYAMLFile.LoadAsset("StatsData.asset", "statsData");
    var statsDict = (Dictionary<string, Stat>)statsData;
    var loadOrder = (List<string>)statsOrder;
    
    Console.WriteLine($"Loaded {statsDict.Count} stats in order:");
    foreach (string statName in loadOrder)
    {
        var stat = statsDict[statName];
        Console.WriteLine($"  {stat.name}: {stat.value} ({stat.min}-{stat.max})");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading stats: {ex.Message}");
}
```

### WriteAsset() Method

Serializes a dictionary of ModsData or StatsData back into YAML format and writes it to the specified file with Unity-specific headers.

```csharp
public static void WriteAsset(string filePath, object assetObj)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `filePath` | `string` | The absolute or relative file path where the YAML asset will be written |
| `assetObj` | `object` | Either a `Dictionary<int, Mod>` (modsDictionary) or `Dictionary<string, Stat>` (statsDictionary) to serialize |

#### Unity YAML Header Generation

The method automatically generates proper Unity YAML headers including:
- YAML version declarations (`%YAML 1.1`)
- Unity tag specifications (`%TAG !u! tag:unity3d.com,2011:`)
- MonoBehaviour metadata with appropriate GUIDs:
  - Mods: `2089455f10e0bb044bfbd1dbcca6bb00`
  - Stats: `09dbea449d423d24c9e3cc308f3a5c62`

#### Serialization Configuration

- Uses YamlDotNet with `CamelCaseNamingConvention` for consistent field naming
- Maintains compatibility with Unity's YAML format requirements
- Preserves object relationships and nested structures (ModColor, etc.)

#### Exceptions

| Exception | Condition |
|-----------|-----------|
| `DirectoryNotFoundException` | Thrown when the directory path does not exist |
| `UnauthorizedAccessException` | Thrown when access to the file path is denied |
| `IOException` | Thrown when an I/O error occurs during file writing |

#### Example Usage

**Writing Mods Data:**
```csharp
var modsDict = new Dictionary<int, Mod>
{
    [100] = new Mod 
    { 
        modid = 100, 
        name = "Fire Damage", 
        equation = "fireDamage += val",
        val = 25.0f,
        modColor = new ModColor { r = 255, g = 100, b = 0, a = 255 }
    },
    [101] = new Mod 
    { 
        modid = 101, 
        name = "Ice Shield", 
        equation = "iceResist += val * 0.5",
        val = 50.0f 
    }
};

try 
{
    HELYAMLFile.WriteAsset("NewModsData.asset", modsDict);
    Console.WriteLine("Mods data saved successfully");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Permission denied - check file permissions");
}
catch (IOException ex)
{
    Console.WriteLine($"I/O error during save: {ex.Message}");
}
```

**Writing Stats Data:**
```csharp
var statsDict = new Dictionary<string, Stat>
{
    ["health"] = new Stat 
    { 
        name = "health", 
        desc = "Player health points",
        value = 100.0f, 
        min = 1.0f, 
        max = 1000.0f 
    },
    ["mana"] = new Stat 
    { 
        name = "mana", 
        desc = "Magical energy",
        value = 50.0f, 
        min = 0.0f, 
        max = 500.0f 
    }
};

HELYAMLFile.WriteAsset("NewStatsData.asset", statsDict);
```

### GetYAMLContent() Private Method

Internal method that extracts YAML content from an asset file starting at the specified node name.

```csharp
private static string GetYAMLContent(string filePath, string nodename)
```

#### Process Overview

1. **File Reading**: Reads all lines from the specified file path
2. **Content Filtering**: Processes lines to remove Unity headers and metadata
3. **Node Identification**: Locates the specified node name within the content
4. **Content Extraction**: Returns the YAML content starting from the specified node

#### Internal Logic

- Reconstructs YAML content by joining lines that contain colons
- Handles Unity's multi-line YAML formatting
- Locates the target node using `IndexOf()` and extracts subsequent content
- Returns properly formatted YAML string for deserialization

---

## 3.2.3 HELCSVFile Class

### 3.2.3.1 Class Overview

The `HELCSVFile` class provides CSV format asset file handling capabilities as an alternative to YAML format. It offers simplified data exchange and editing workflows, particularly useful during development phases.

**Key Features:**
- Simple CSV format for easy external editing
- Robust parsing with quoted field support
- Automatic field escaping for special characters
- Compatible return types with HELYAMLFile
- Development-friendly format for bulk operations

**Advantages:**
- Human-readable and editable in spreadsheet applications
- Faster parsing compared to YAML for large datasets
- Better version control diff visibility
- Easy bulk import/export capabilities

### 3.2.3.2 LoadAsset() Method

Loads a CSV asset file and returns a tuple containing either ModsData or StatsData dictionary with the same structure as the YAML loader.

```csharp
public static (object, object?) LoadAsset(string filePath, string assetType)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `filePath` | `string` | The absolute or relative path to the CSV file to load |
| `assetType` | `string` | Asset type identifier - should start with "m" for mods, otherwise treated as stats |

#### Return Value

Returns a tuple `(object, object?)` matching the YAML loader format:
- **First Element**: Either a `Dictionary<int, Mod>` or `Dictionary<string, Stat>`
- **Second Element**: `null` for mods, or `List<string>` statsOrder for stats

#### CSV Format Specifications

**Mods CSV Header:**
```
modid,val,val2,val1min,val1max,val2min,val2max,modweight,name,desc,type,hasProc,equation,modColor_r,modColor_g,modColor_b,modColor_a,armorEffectName,armorMeshName
```

**Stats CSV Header:**
```
name,desc,value,min,max
```

#### Field Validation and Type Conversion

- **Numeric Fields**: Parsed using `int.Parse()` and `float.Parse()` with exception handling
- **String Fields**: Processed through robust CSV parsing to handle quoted content
- **Color Fields**: Parsed as individual RGBA integer components
- **Empty Lines**: Automatically skipped during processing

#### Exceptions

| Exception | Condition |
|-----------|-----------|
| `FileNotFoundException` | Thrown when the specified file does not exist |
| `Exception` | Thrown when the CSV file is empty or missing data |
| `FormatException` | Thrown when parsing numeric values fails |
| `IndexOutOfRangeException` | Thrown when required CSV fields are missing |

#### Example Usage

**Loading Mods from CSV:**
```csharp
try 
{
    var (modsData, _) = HELCSVFile.LoadAsset("ModsData.csv", "mods");
    var modsDict = (Dictionary<int, Mod>)modsData;
    
    foreach (var mod in modsDict.Values)
    {
        Console.WriteLine($"Loaded mod {mod.modid}: {mod.name}");
        Console.WriteLine($"  Equation: {mod.equation}");
        Console.WriteLine($"  Values: {mod.val}/{mod.val2}");
        Console.WriteLine($"  Color: R{mod.modColor.r} G{mod.modColor.g} B{mod.modColor.b}");
    }
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid numeric format in CSV: {ex.Message}");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("CSV file missing required columns");
}
```

**Loading Stats from CSV:**
```csharp
var (statsData, statsOrder) = HELCSVFile.LoadAsset("StatsData.csv", "stats");
var statsDict = (Dictionary<string, Stat>)statsData;
var loadOrder = (List<string>)statsOrder;

Console.WriteLine("Stats loaded from CSV:");
foreach (string statName in loadOrder)
{
    var stat = statsDict[statName];
    Console.WriteLine($"  {stat.name}: {stat.value} (range: {stat.min}-{stat.max})");
}
```

### WriteAsset() Method

Serializes a dictionary of ModsData or StatsData into CSV format and writes it to a file with proper field escaping.

```csharp
public static void WriteAsset(string filePath, object assetObj)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `filePath` | `string` | The path where the CSV file will be written |
| `assetObj` | `object` | Either a `Dictionary<int, Mod>` or `Dictionary<string, Stat>` to serialize |

#### CSV Header Generation

**For Mods Data:**
Generates a comprehensive header covering all mod properties including color components and armor effects.

**For Stats Data:**
Creates a simple 5-column header for basic stat properties.

#### Field Escaping Strategy

- String fields are processed through `EscapeCsvField()` to handle special characters
- Numeric fields are converted directly using `ToString()`
- Maintains data integrity for complex content like equations and descriptions

#### Exceptions

| Exception | Condition |
|-----------|-----------|
| `DirectoryNotFoundException` | Thrown when the directory path does not exist |
| `UnauthorizedAccessException` | Thrown when access to the file path is denied |
| `IOException` | Thrown when an I/O error occurs during file writing |

#### Example Usage

**Writing Mods to CSV:**
```csharp
var modsDict = new Dictionary<int, Mod>
{
    [200] = new Mod 
    { 
        modid = 200,
        name = "Lightning Strike",
        desc = "Adds electrical damage with a \"shocking\" effect",  // Contains quotes
        equation = "if (random() < 0.3) { electricDamage += val * 2 }",  // Complex equation
        val = 15.0f,
        modColor = new ModColor { r = 255, g = 255, b = 0, a = 200 }
    }
};

HELCSVFile.WriteAsset("ExportedMods.csv", modsDict);
```

The resulting CSV will properly escape the quotes in the description and handle the complex equation syntax.

### EscapeCsvField() Private Method

Escapes special characters in CSV fields by wrapping them in quotes and escaping internal quotes.

```csharp
private static string? EscapeCsvField(string field)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `field` | `string` | The field value to escape, can be null |

#### Return Value

Returns the escaped field value, or the original value if no escaping is needed.

#### Escaping Rules

1. **Triggering Conditions**: Fields containing commas, quotes, or newlines are escaped
2. **Quote Doubling**: Internal double quotes are escaped by doubling them (`"` becomes `""`)
3. **Field Wrapping**: Problematic fields are wrapped in double quotes
4. **Null Handling**: Null values are returned as-is

#### Examples

```csharp
// Simple field - no escaping needed
EscapeCsvField("normal text") → "normal text"

// Field with comma - requires escaping
EscapeCsvField("text, with comma") → "\"text, with comma\""

// Field with quotes - requires escaping and quote doubling
EscapeCsvField("text with \"quotes\"") → "\"text with \"\"quotes\"\"\""

// Field with newline - requires escaping
EscapeCsvField("line1\nline2") → "\"line1\nline2\""

// Null field - no change
EscapeCsvField(null) → null
```

### ParseCsvLine() Private Method

Parses a CSV line handling quoted fields that may contain commas, quotes, or newlines.

```csharp
private static string[] ParseCsvLine(string line)
```

#### Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `line` | `string` | The CSV line to parse |

#### Return Value

Returns an array of field values extracted from the CSV line.

#### Parsing Logic

1. **Quote State Tracking**: Maintains `insideQuotes` boolean to track parsing context
2. **Field Separation**: Commas only separate fields when outside quoted sections
3. **Quote Processing**: Handles quote characters by toggling the quoted state
4. **Field Assembly**: Builds current field character by character
5. **Post-Processing**: Removes surrounding quotes and unescapes internal quotes

#### Advanced Features

- **Nested Quotes**: Properly handles `""` escape sequences within quoted fields
- **Mixed Content**: Handles fields that mix quoted and unquoted sections
- **Edge Cases**: Correctly processes empty fields and trailing commas

#### Example Processing

```csharp
// Simple CSV line
ParseCsvLine("field1,field2,field3") 
→ ["field1", "field2", "field3"]

// Line with quoted field containing comma
ParseCsvLine("field1,\"field2, with comma\",field3") 
→ ["field1", "field2, with comma", "field3"]

// Line with escaped quotes
ParseCsvLine("field1,\"field with \"\"quotes\"\"\",field3") 
→ ["field1", "field with \"quotes\"", "field3"]

// Complex equation field
ParseCsvLine("100,\"if (val > 10) { damage += val * 2; }\",25.5") 
→ ["100", "if (val > 10) { damage += val * 2; }", "25.5"]
```

---

## 3.2.4 Common Patterns

### Asset Type Detection Strategies

Both classes use consistent strategies for determining asset types:

**YAML Approach:**
```csharp
if (root[0] == 'm') {
    // Load as mods data
} else {
    // Load as stats data
}
```

**CSV Approach:**
```csharp
if (assetType.ToLower().StartsWith("m")) {
    // Load as mods data
} else {
    // Load as stats data
}
```

### Error Handling and Recovery

**Consistent Exception Patterns:**
```csharp
try 
{
    var (data, order) = HELYAMLFile.LoadAsset(path, root);
    // Process data...
}
catch (FileNotFoundException)
{
    // Handle missing file - possibly create default
}
catch (YamlException ex)
{
    // Handle parsing errors - log details
    Console.WriteLine($"YAML parsing failed: {ex.Message}");
}
catch (Exception ex)
{
    // Handle unexpected errors
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

**Recovery Strategies:**
- Create default asset structures when files are missing
- Validate data integrity after loading
- Provide fallback mechanisms for corrupted data
- Log detailed error information for debugging

### Performance Considerations

**YAML Performance:**
- Better for complex nested structures
- Slower parsing due to structural complexity
- More memory usage during deserialization
- Better for infrequent large-scale operations

**CSV Performance:**
- Faster parsing for simple tabular data
- Lower memory overhead
- Better for frequent save/load operations
- More efficient for bulk data operations

**Optimization Strategies:**
```csharp
// Cache loaded assets to avoid repeated I/O
private static Dictionary<string, (object, object?)> _assetCache = new();

public static (object, object?) LoadAssetCached(string path, string identifier)
{
    string cacheKey = $"{path}:{identifier}";
    if (_assetCache.ContainsKey(cacheKey))
    {
        return _assetCache[cacheKey];
    }
    
    var result = HELYAMLFile.LoadAsset(path, identifier);
    _assetCache[cacheKey] = result;
    return result;
}
```

### Integration with Asset Loading Workflows

**Standard Loading Pattern:**
```csharp
public class AssetManager
{
    private Dictionary<int, Mod> _mods;
    private Dictionary<string, Stat> _stats;
    private List<string> _statsOrder;
    
    public void LoadAssets(string modsPath, string statsPath, bool useCSV = false)
    {
        try 
        {
            if (useCSV)
            {
                var (modsData, _) = HELCSVFile.LoadAsset(modsPath, "mods");
                var (statsData, statsOrder) = HELCSVFile.LoadAsset(statsPath, "stats");
                
                _mods = (Dictionary<int, Mod>)modsData;
                _stats = (Dictionary<string, Stat>)statsData;
                _statsOrder = (List<string>)statsOrder;
            }
            else
            {
                var (modsData, _) = HELYAMLFile.LoadAsset(modsPath, "modsData");
                var (statsData, statsOrder) = HELYAMLFile.LoadAsset(statsPath, "statsData");
                
                _mods = (Dictionary<int, Mod>)modsData;
                _stats = (Dictionary<string, Stat>)statsData;
                _statsOrder = (List<string>)statsOrder;
            }
            
            ValidateAssetIntegrity();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to load assets: {ex.Message}", ex);
        }
    }
    
    private void ValidateAssetIntegrity()
    {
        // Verify mod IDs are unique
        if (_mods.Keys.Count != _mods.Keys.Distinct().Count())
        {
            throw new InvalidDataException("Duplicate mod IDs detected");
        }
        
        // Verify stat names are valid
        foreach (var stat in _stats.Values)
        {
            if (string.IsNullOrWhiteSpace(stat.name))
            {
                throw new InvalidDataException("Empty stat name detected");
            }
        }
    }
}
```

### Development vs Production Usage Scenarios

**Development Workflow:**
- Use CSV format for rapid iteration and external editing
- Implement auto-reload mechanisms for file changes
- Provide data validation and error reporting
- Support incremental saves and backups

**Production Deployment:**
- Use YAML format for Unity integration
- Implement asset bundling and compression
- Add digital signing for asset integrity
- Optimize loading performance with caching

```csharp
#if DEBUG
    // Development: Use CSV for easy editing
    var (mods, _) = HELCSVFile.LoadAsset("ModsData.csv", "mods");
#else
    // Production: Use YAML for Unity compatibility
    var (mods, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsData");
#endif
```

---

## 3.2.5 Integration Examples

### Cross-Reference with Section 2.3 (Asset Management)

The file I/O classes integrate seamlessly with the asset management patterns described in section 2.3:

```csharp
// Integration with HEL class asset loading
public static class HELAssetLoader
{
    public static void ConfigureAssetLoading(bool useYAML = true)
    {
        if (useYAML)
        {
            // Configure HEL to use YAML loading
            HEL.SetAssetLoader((path, root) => HELYAMLFile.LoadAsset(path, root));
        }
        else
        {
            // Configure HEL to use CSV loading
            HEL.SetAssetLoader((path, type) => HELCSVFile.LoadAsset(path, type));
        }
    }
}
```

### Integration Patterns

**Pattern 1: Dual Format Support**
```csharp
public class FlexibleAssetLoader
{
    public static (object, object?) LoadAssetAuto(string basePath, string identifier)
    {
        string yamlPath = basePath + ".asset";
        string csvPath = basePath + ".csv";
        
        if (File.Exists(yamlPath) && File.Exists(csvPath))
        {
            // Use most recently modified
            var yamlInfo = new FileInfo(yamlPath);
            var csvInfo = new FileInfo(csvPath);
            
            if (yamlInfo.LastWriteTime > csvInfo.LastWriteTime)
            {
                return HELYAMLFile.LoadAsset(yamlPath, identifier);
            }
            else
            {
                return HELCSVFile.LoadAsset(csvPath, identifier.StartsWith("m") ? "mods" : "stats");
            }
        }
        else if (File.Exists(yamlPath))
        {
            return HELYAMLFile.LoadAsset(yamlPath, identifier);
        }
        else if (File.Exists(csvPath))
        {
            return HELCSVFile.LoadAsset(csvPath, identifier.StartsWith("m") ? "mods" : "stats");
        }
        else
        {
            throw new FileNotFoundException($"No asset file found for: {basePath}");
        }
    }
}
```

**Pattern 2: Format Conversion**
```csharp
public static class AssetConverter
{
    public static void ConvertYAMLToCSV(string yamlPath, string csvPath, string rootNode)
    {
        var (data, order) = HELYAMLFile.LoadAsset(yamlPath, rootNode);
        HELCSVFile.WriteAsset(csvPath, data);
    }
    
    public static void ConvertCSVToYAML(string csvPath, string yamlPath, string assetType)
    {
        var (data, order) = HELCSVFile.LoadAsset(csvPath, assetType);
        HELYAMLFile.WriteAsset(yamlPath, data);
    }
}
```

This completes the comprehensive API reference for the HEL file I/O classes. These classes provide robust, flexible asset loading and saving capabilities that support both development and production workflows while maintaining compatibility with Unity's asset management system.

---

# 3.3 HELPicker Class Reference

## 3.3.1 Class Overview

### Purpose and Design Philosophy

The **HELPicker** class implements mathematically optimal O(1) weighted random selection using the Alias method algorithm. This class enables efficient sampling from discrete probability distributions with arbitrary weights, making it ideal for weighted mod selection in HIOX game systems.

### Algorithm Advantages Over Naive Approaches

The Alias method provides significant advantages over traditional weighted selection approaches:

- **Constant Time Sampling**: O(1) selection regardless of distribution size or weight skew
- **Mathematical Precision**: Exact probability matching with no approximation errors
- **Skew Independence**: Performance unaffected by highly skewed weight distributions
- **Scalability**: Maintains efficiency with thousands of items in the distribution

### Performance Characteristics

| Operation | Time Complexity | Space Complexity | Notes |
|-----------|----------------|------------------|-------|
| Construction | O(N) | O(N) | One-time preprocessing cost |
| Sample() | O(1) | O(1) | Constant time regardless of N |
| Memory Usage | - | 12 bytes per item | Two arrays: int[] + double[] |

### Thread Safety Considerations

**Important**: HELPicker is **not thread-safe** due to the internal `Random` instance used for number generation.

For multi-threaded scenarios:
```csharp
// Option 1: Thread-local instances
[ThreadStatic]
static HELPicker threadLocalPicker;

// Option 2: External synchronization
private readonly object pickerLock = new object();
lock (pickerLock) 
{
    int result = picker.Sample();
}

// Option 3: Separate instances per thread
var picker = new HELPicker(weights); // Create per thread
```

## 3.3.2 Constructor: HELPicker(List<int> inWeights)

### Method Signature

```csharp
public HELPicker(List<int> inWeights)
```

### Parameter Description

**inWeights**: The ordered list of mod weights where index corresponds to mod position
- **Type**: `List<int>`
- **Requirements**: Positive integers recommended (negative values converted to positive)
- **Index Mapping**: `weights[i]` represents the selection weight for item at index `i`
- **Normalization**: Weights are internally normalized to probabilities during construction

### Weight Processing and Requirements

#### Weight Conversion and Validation
```csharp
// Example weight list
List<int> modWeights = new List<int> 
{
    100,  // Index 0: High probability (weight 100)
    50,   // Index 1: Medium probability (weight 50)
    25,   // Index 2: Lower probability (weight 25)
    10,   // Index 3: Low probability (weight 10)
    5     // Index 4: Very low probability (weight 5)
};

HELPicker picker = new HELPicker(modWeights);
```

#### Internal Processing Steps

1. **Conversion to Doubles**: Integer weights converted to double precision for algorithm calculations
2. **Sum Calculation**: Total weight computed for normalization (`sum = weights.Sum()`)
3. **Normalization**: Each weight multiplied by N and divided by sum: `normalized[i] = weight[i] * N / sum`
4. **Table Construction**: Alias and probability lookup tables built using bucket balancing

### Time Complexity: O(N) During Construction

The constructor performs O(N) preprocessing to enable O(1) sampling:

```csharp
// Construction time scales linearly with weight list size
var weights1000 = Enumerable.Repeat(1, 1000).ToList();
var picker1000 = new HELPicker(weights1000);  // ~1ms construction

var weights10000 = Enumerable.Repeat(1, 10000).ToList(); 
var picker10000 = new HELPicker(weights10000); // ~10ms construction
```

### Memory Requirements

**Memory Usage**: Two arrays of size N plus object overhead
- **Alias Table**: `int[N]` storing alternative indices (4 bytes per item)
- **Probability Table**: `double[N]` storing adjusted probabilities (8 bytes per item)
- **Total**: Approximately 12 bytes per weight + .NET object overhead

```csharp
// Memory calculation example
int itemCount = 1000;
int memoryUsage = itemCount * (sizeof(int) + sizeof(double)); // 12,000 bytes
Console.WriteLine($"Estimated memory: {memoryUsage / 1024.0:F1} KB");
```

### Construction Examples with Different Weight Distributions

#### Uniform Distribution
```csharp
// Equal weights - uniform probability
List<int> uniformWeights = new List<int> { 10, 10, 10, 10, 10 };
HELPicker uniformPicker = new HELPicker(uniformWeights);
// Each item has 20% probability
```

#### Skewed Distribution
```csharp
// Highly skewed weights
List<int> skewedWeights = new List<int> { 1000, 10, 5, 3, 2 };
HELPicker skewedPicker = new HELPicker(skewedWeights);
// Item 0: ~98% probability, others: <2% each
```

#### Rarity-Based Distribution
```csharp
// Game-realistic rarity distribution
List<int> rarityWeights = new List<int> 
{
    1000,  // Common items
    300,   // Uncommon items  
    100,   // Rare items
    30,    // Epic items
    10,    // Legendary items
    1      // Mythic items
};
HELPicker rarityPicker = new HELPicker(rarityWeights);
```

#### Large Scale Distribution
```csharp
// Performance test with large distribution
var random = new Random(42);
List<int> largeWeights = Enumerable.Range(0, 10000)
    .Select(_ => random.Next(1, 1000))
    .ToList();

var stopwatch = Stopwatch.StartNew();
HELPicker largePicker = new HELPicker(largeWeights);
stopwatch.Stop();
Console.WriteLine($"Construction time for 10,000 items: {stopwatch.ElapsedMilliseconds}ms");
```

## 3.3.3 Sample() Method

### Method Signature and Return Value

```csharp
public int Sample()
```

**Returns**: `int` - The zero-based index of the selected item from the weight distribution

### Performance: O(1) Constant Time Selection

The Sample() method provides true constant-time selection regardless of distribution characteristics:

```csharp
// Performance is identical regardless of distribution size
var smallPicker = new HELPicker(new List<int> { 1, 2, 3 });
var largePicker = new HELPicker(Enumerable.Repeat(1, 100000).ToList());

// Both calls take the same O(1) time
int smallResult = smallPicker.Sample();  // ~10 nanoseconds
int largeResult = largePicker.Sample();  // ~10 nanoseconds
```

### Selection Probability Proportional to Original Weights

Each index is selected with probability exactly proportional to its original weight:

```csharp
List<int> weights = new List<int> { 60, 30, 10 };  // Total: 100
HELPicker picker = new HELPicker(weights);

// Theoretical probabilities:
// Index 0: 60/100 = 60%
// Index 1: 30/100 = 30%  
// Index 2: 10/100 = 10%

// Empirical verification
var results = new Dictionary<int, int>();
for (int i = 0; i < 100000; i++)
{
    int selected = picker.Sample();
    results[selected] = results.GetValueOrDefault(selected, 0) + 1;
}

// Results will closely match theoretical probabilities
Console.WriteLine($"Index 0: {results[0] / 1000.0:F1}% (expected 60%)");
Console.WriteLine($"Index 1: {results[1] / 1000.0:F1}% (expected 30%)");
Console.WriteLine($"Index 2: {results[2] / 1000.0:F1}% (expected 10%)");
```

### Random Number Generation: Uniform Distribution Conversion

The Sample() method uses two uniform random numbers to achieve weighted selection:

```csharp
public int Sample()
{
    int i = rand.Next(n);  // Uniform selection from [0, N-1]
    // Uniform random [0.0, 1.0) compared to adjusted probability
    return rand.NextDouble() < probability[i] ? i : alias[i];
}
```

This approach ensures:
- **Mathematical Correctness**: Exact probability matching
- **Uniform Random Source**: Uses .NET's standard Random class
- **Efficient Conversion**: Two random numbers converted to weighted selection

### Thread Safety Warnings

**Critical**: Sample() is not thread-safe due to shared Random instance:

```csharp
// UNSAFE: Multiple threads accessing same picker
HELPicker sharedPicker = new HELPicker(weights);
Task.Run(() => sharedPicker.Sample()); // ❌ Race condition
Task.Run(() => sharedPicker.Sample()); // ❌ Race condition

// SAFE: Thread-local instances
ThreadLocal<HELPicker> tlsPicker = new ThreadLocal<HELPicker>(
    () => new HELPicker(weights));
Task.Run(() => tlsPicker.Value.Sample()); // ✅ Safe
Task.Run(() => tlsPicker.Value.Sample()); // ✅ Safe
```

### Usage Examples with Statistics Verification

#### Basic Sampling Example
```csharp
public static void BasicSamplingExample()
{
    List<int> weights = new List<int> { 70, 20, 10 };
    HELPicker picker = new HELPicker(weights);
    
    Console.WriteLine("Sample results:");
    for (int i = 0; i < 10; i++)
    {
        int result = picker.Sample();
        Console.WriteLine($"Sample {i + 1}: Index {result}");
    }
}
```

#### Statistical Verification Example
```csharp
public static void VerifyDistribution(List<int> weights, int sampleCount = 1000000)
{
    HELPicker picker = new HELPicker(weights);
    var results = new Dictionary<int, int>();
    double totalWeight = weights.Sum();
    
    // Generate samples
    for (int i = 0; i < sampleCount; i++)
    {
        int selected = picker.Sample();
        results[selected] = results.GetValueOrDefault(selected, 0) + 1;
    }
    
    // Verify against expected probabilities
    Console.WriteLine("Distribution Verification:");
    Console.WriteLine("Index | Expected% | Actual% | Error%");
    Console.WriteLine("------|-----------|---------|-------");
    
    for (int i = 0; i < weights.Count; i++)
    {
        double expectedPercent = (weights[i] / totalWeight) * 100;
        double actualPercent = (results.GetValueOrDefault(i, 0) / (double)sampleCount) * 100;
        double errorPercent = Math.Abs(expectedPercent - actualPercent);
        
        Console.WriteLine($"{i,5} | {expectedPercent,8:F2}% | {actualPercent,7:F2}% | {errorPercent,5:F2}%");
    }
}
```

#### Performance Benchmarking Example
```csharp
public static void BenchmarkSampling(List<int> weights, int iterations = 10000000)
{
    HELPicker picker = new HELPicker(weights);
    
    var stopwatch = Stopwatch.StartNew();
    for (int i = 0; i < iterations; i++)
    {
        picker.Sample();
    }
    stopwatch.Stop();
    
    double samplesPerSecond = iterations / stopwatch.Elapsed.TotalSeconds;
    double nanosPerSample = (stopwatch.Elapsed.TotalNanoseconds / iterations);
    
    Console.WriteLine($"Performance Results:");
    Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds:N0}ms");
    Console.WriteLine($"Samples per second: {samplesPerSecond:N0}");
    Console.WriteLine($"Nanoseconds per sample: {nanosPerSample:F1}ns");
}
```

## 3.3.4 Internal Data Structures

### alias Array: Mapping Indices to Alternative Indices

```csharp
private readonly int[] alias;
```

The alias array implements the core of the Alias method by storing alternative indices for probability balancing:

- **Purpose**: Maps each index to its "alias" index for probability redistribution
- **Size**: N elements (same as weight list size)
- **Values**: Each `alias[i]` contains the index that should be selected when the random probability exceeds `probability[i]`
- **Construction**: Built during preprocessing to balance probability buckets

#### Alias Array Example
```csharp
// Example: weights [60, 30, 10] create alias relationships
// alias[0] might be 0 (self-reference for high probability)
// alias[1] might be 0 (redirect to index 0)  
// alias[2] might be 0 (redirect to index 0)
```

### probability Array: Adjusted Probabilities for Each Index

```csharp
private readonly double[] probability;
```

The probability array stores the adjusted probabilities used in the two-step sampling process:

- **Purpose**: Stores the probability threshold for each index in the alias decision
- **Size**: N elements (same as weight list size)
- **Values**: Each `probability[i]` is a double in range [0.0, 1.0] representing the adjusted probability
- **Usage**: Compared against uniform random number to decide between index i and `alias[i]`

#### Probability Array Example
```csharp
// For weights [60, 30, 10], normalized values might be:
// probability[0] = 0.8  (high probability, often self-selected)
// probability[1] = 0.9  (adjusted probability after balancing)
// probability[2] = 1.0  (always redirect to alias)
```

### n Field: Number of Items in Distribution

```csharp
private readonly int n;
```

Simple integer storing the count of items in the distribution:

- **Purpose**: Caches the distribution size for efficient random index generation
- **Usage**: Used in `rand.Next(n)` to generate uniform random indices
- **Immutable**: Set once during construction and never modified

### rand Field: Random Instance for Number Generation

```csharp
private readonly Random rand = new Random();
```

Internal Random instance used for all random number generation:

- **Purpose**: Provides uniform random numbers for the sampling algorithm
- **Thread Safety**: **Not thread-safe** - source of concurrency issues
- **Usage**: Generates both random indices (`rand.Next(n)`) and probabilities (`rand.NextDouble()`)
- **Initialization**: Uses default Random constructor with time-based seed

#### Random Field Considerations
```csharp
// Potential improvement: Allow custom Random instance
public HELPicker(List<int> weights, Random customRandom = null)
{
    rand = customRandom ?? new Random();
    // ... rest of constructor
}

// Thread-safe wrapper approach
public class ThreadSafeHELPicker
{
    private readonly HELPicker picker;
    private readonly object lockObject = new object();
    
    public int Sample()
    {
        lock (lockObject)
        {
            return picker.Sample();
        }
    }
}
```

## 3.3.5 Alias Method Algorithm Explanation

### Mathematical Foundation

The Alias method is a preprocessing algorithm that enables O(1) sampling from discrete probability distributions. It works by restructuring the distribution into a set of uniform "buckets" where each bucket represents exactly 1/N of the total probability mass.

### Preprocessing Stage: Normalization, Bucketing, Table Construction

#### Step 1: Weight Normalization
```csharp
// Convert weights to normalized probabilities
double sum = weights.Sum();
double[] normalized = weights.Select(w => w * n / sum).ToArray();

// After normalization, the average value equals 1.0
// Values < 1.0 are "small" (probability deficit)
// Values >= 1.0 are "large" (probability surplus)
```

#### Step 2: Bucket Partitioning
```csharp
Queue<int> small = new Queue<int>();  // Indices with normalized probability < 1.0
Queue<int> large = new Queue<int>();  // Indices with normalized probability >= 1.0

for (int i = 0; i < n; i++)
{
    if (normalized[i] < 1.0)
        small.Enqueue(i);      // Needs probability from others
    else
        large.Enqueue(i);      // Can donate probability
}
```

#### Step 3: Alias Table Construction
```csharp
while (small.Count > 0 && large.Count > 0)
{
    int less = small.Dequeue();  // Index needing probability
    int more = large.Dequeue();  // Index with excess probability
    
    // Set probability and alias for the "small" index
    probability[less] = normalized[less];  // Use original probability
    alias[less] = more;                    // Redirect remainder to "large" index
    
    // Reduce the "large" index probability by the amount given
    normalized[more] = normalized[more] - (1.0 - normalized[less]);
    
    // Re-categorize the "large" index based on remaining probability
    if (normalized[more] < 1.0)
        small.Enqueue(more);
    else
        large.Enqueue(more);
}

// Handle remaining indices (set to probability 1.0)
while (large.Count > 0)
    probability[large.Dequeue()] = 1.0;
while (small.Count > 0)
    probability[small.Dequeue()] = 1.0;
```

### Sampling Stage: Index Selection, Probability Decision

The sampling algorithm uses the preprocessed tables for O(1) selection:

```csharp
public int Sample()
{
    // Step 1: Select a random bucket uniformly
    int i = rand.Next(n);
    
    // Step 2: Decide between the bucket's primary index or its alias
    // Generate uniform random [0.0, 1.0) and compare to stored probability
    return rand.NextDouble() < probability[i] ? i : alias[i];
}
```

### Mathematical Correctness and Distribution Preservation

#### Probability Preservation Proof

Each index i is selected with the correct probability through two pathways:

1. **Direct Selection**: Selected when random bucket equals i AND random probability < probability[i]
   - Probability = (1/N) × probability[i]

2. **Alias Selection**: Selected when random bucket equals j (where alias[j] = i) AND random probability >= probability[j]
   - Probability = (1/N) × (1.0 - probability[j]) for each j where alias[j] = i

The sum of these probabilities equals the original normalized weight for index i.

#### Example Walkthrough

```csharp
// Original weights: [60, 30, 10] with total = 100
// Normalized (×3): [1.8, 0.9, 0.3]

// Construction process:
// small = [1, 2] (indices with normalized < 1.0)
// large = [0]     (indices with normalized >= 1.0)

// Iteration 1: Pair index 1 (0.9) with index 0 (1.8)
// probability[1] = 0.9, alias[1] = 0
// normalized[0] = 1.8 - (1.0 - 0.9) = 1.7 (still large)

// Iteration 2: Pair index 2 (0.3) with index 0 (1.7)  
// probability[2] = 0.3, alias[2] = 0
// normalized[0] = 1.7 - (1.0 - 0.3) = 1.0 (now balanced)

// Final: probability[0] = 1.0 (no alias needed)

// Sampling verification:
// Index 0 selected when: bucket=0 OR (bucket=1 AND rand>=0.9) OR (bucket=2 AND rand>=0.3)
// Probability = 1/3 + 1/3×0.1 + 1/3×0.7 = 1/3 + 1/30 + 7/30 = 18/30 = 0.6 ✓
```

### Visual Representation

```
Original Distribution:
Index 0: ████████████████████████████████████████████████████████████ (60%)
Index 1: ██████████████████████████████ (30%)
Index 2: ██████████ (10%)

After Alias Method Preprocessing:
Bucket 0: ████████████████████████████████████████████████████████████ (Index 0, 100%)
Bucket 1: ███████████████████████████ + █████████ (Index 1 27% + Index 0 6%)
Bucket 2: ██████ + ████████████████████████████████████████████ (Index 2 10% + Index 0 23%)

Each bucket represents exactly 1/3 of total probability
Sampling: Pick bucket uniformly, then decide based on stored probability
```

## 3.3.6 Advanced Usage Scenarios

### Large Weight Distributions (Thousands of Items)

HELPicker scales efficiently to large distributions while maintaining O(1) sampling performance:

```csharp
public static void LargeScaleExample()
{
    // Generate 50,000 item distribution
    var random = new Random(12345);
    List<int> largeWeights = new List<int>();
    
    for (int i = 0; i < 50000; i++)
    {
        // Simulate realistic weight distribution
        int weight = random.Next(1, 1000);
        if (random.NextDouble() < 0.1) weight *= 10;  // 10% rare items
        largeWeights.Add(weight);
    }
    
    // Construction time: O(N) but still fast
    var stopwatch = Stopwatch.StartNew();
    HELPicker largePicker = new HELPicker(largeWeights);
    stopwatch.Stop();
    Console.WriteLine($"Construction time for 50,000 items: {stopwatch.ElapsedMilliseconds}ms");
    
    // Sampling time: O(1) regardless of size
    stopwatch.Restart();
    for (int i = 0; i < 1000000; i++)
    {
        largePicker.Sample();
    }
    stopwatch.Stop();
    Console.WriteLine($"1M samples time: {stopwatch.ElapsedMilliseconds}ms");
    Console.WriteLine($"Samples per second: {1000000.0 / stopwatch.Elapsed.TotalSeconds:N0}");
}
```

### Skewed Weight Distributions (Few High-Weight Items)

The Alias method handles highly skewed distributions without performance degradation:

```csharp
public static void SkewedDistributionExample()
{
    // Extreme skew: one item dominates the distribution
    List<int> skewedWeights = new List<int>();
    skewedWeights.Add(999000);  // One dominant item (99.9%)
    
    // Add many low-weight items
    for (int i = 0; i < 1000; i++)
    {
        skewedWeights.Add(1);   // Each represents 0.0001%
    }
    
    HELPicker skewedPicker = new HELPicker(skewedWeights);
    
    // Verify distribution maintains correctness
    var results = new Dictionary<int, int>();
    int sampleCount = 1000000;
    
    for (int i = 0; i < sampleCount; i++)
    {
        int selected = skewedPicker.Sample();
        results[selected] = results.GetValueOrDefault(selected, 0) + 1;
    }
    
    double dominantItemPercent = (results.GetValueOrDefault(0, 0) / (double)sampleCount) * 100;
    Console.WriteLine($"Dominant item selected: {dominantItemPercent:F3}% (expected ~99.9%)");
    
    int otherItemsSelected = results.Where(kvp => kvp.Key != 0).Sum(kvp => kvp.Value);
    double otherItemsPercent = (otherItemsSelected / (double)sampleCount) * 100;
    Console.WriteLine($"Other items selected: {otherItemsPercent:F3}% (expected ~0.1%)");
}
```

### Dynamic Weight Updates (Requires New Instance)

Since preprocessing is expensive, dynamic updates require careful consideration:

```csharp
public class AdaptiveModPicker
{
    private List<int> baseWeights;
    private HELPicker currentPicker;
    private Dictionary<string, double> activeMultipliers;
    
    public AdaptiveModPicker(List<int> initialWeights)
    {
        baseWeights = new List<int>(initialWeights);
        activeMultipliers = new Dictionary<string, double>();
        currentPicker = new HELPicker(initialWeights);
    }
    
    public void SetMultiplier(string category, double multiplier)
    {
        activeMultipliers[category] = multiplier;
        RebuildPicker();
    }
    
    public void RemoveMultiplier(string category)
    {
        activeMultipliers.Remove(category);
        RebuildPicker();
    }
    
    private void RebuildPicker()
    {
        // Apply all active multipliers
        List<int> adjustedWeights = baseWeights.Select((weight, index) => {
            double finalWeight = weight;
            
            // Apply category-specific multipliers
            foreach (var multiplier in activeMultipliers.Values)
            {
                finalWeight *= multiplier;
            }
            
            return Math.Max(1, (int)Math.Round(finalWeight));
        }).ToList();
        
        // Create new picker with adjusted weights
        currentPicker = new HELPicker(adjustedWeights);
    }
    
    public int Sample() => currentPicker.Sample();
    
    // Optimization: Batch multiple multiplier changes
    public void SetMultipliers(Dictionary<string, double> multipliers)
    {
        activeMultipliers.Clear();
        foreach (var kvp in multipliers)
        {
            activeMultipliers[kvp.Key] = kvp.Value;
        }
        RebuildPicker(); // Only rebuild once
    }
}
```

### Performance Profiling and Optimization

```csharp
public static class HELPickerProfiler
{
    public static void ProfileConstruction(List<int> testSizes)
    {
        Console.WriteLine("Construction Performance Profile:");
        Console.WriteLine("Size | Time (ms) | Memory (KB) | Time/Item (μs)");
        Console.WriteLine("-----|-----------|-------------|---------------");
        
        foreach (int size in testSizes)
        {
            var weights = Enumerable.Repeat(100, size).ToList();
            
            long memoryBefore = GC.GetTotalMemory(true);
            var stopwatch = Stopwatch.StartNew();
            var picker = new HELPicker(weights);
            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);
            
            double timeMs = stopwatch.Elapsed.TotalMilliseconds;
            double memoryKB = (memoryAfter - memoryBefore) / 1024.0;
            double timePerItemMicros = (stopwatch.Elapsed.TotalMicroseconds) / size;
            
            Console.WriteLine($"{size,4} | {timeMs,8:F2} | {memoryKB,10:F1} | {timePerItemMicros,12:F2}");
        }
    }
    
    public static void ProfileSampling(HELPicker picker, List<int> testIterations)
    {
        Console.WriteLine("\nSampling Performance Profile:");
        Console.WriteLine("Iterations | Time (ms) | Samples/sec | ns/sample");
        Console.WriteLine("-----------|-----------|-------------|----------");
        
        foreach (int iterations in testIterations)
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                picker.Sample();
            }
            stopwatch.Stop();
            
            double timeMs = stopwatch.Elapsed.TotalMilliseconds;
            double samplesPerSec = iterations / stopwatch.Elapsed.TotalSeconds;
            double nsPerSample = stopwatch.Elapsed.TotalNanoseconds / iterations;
            
            Console.WriteLine($"{iterations,9} | {timeMs,8:F2} | {samplesPerSec,10:N0} | {nsPerSample,8:F1}");
        }
    }
    
    public static void CompareAlgorithms(List<int> weights, int iterations = 1000000)
    {
        Console.WriteLine("\nAlgorithm Comparison:");
        
        // Alias method (HELPicker)
        var aliasStopwatch = Stopwatch.StartNew();
        var picker = new HELPicker(weights);
        var aliasConstructionTime = aliasStopwatch.ElapsedMilliseconds;
        
        aliasStopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            picker.Sample();
        }
        aliasStopwatch.Stop();
        
        // Naive weighted selection
        var naiveStopwatch = Stopwatch.StartNew();
        var random = new Random(42);
        int totalWeight = weights.Sum();
        for (int i = 0; i < iterations; i++)
        {
            int target = random.Next(totalWeight);
            int sum = 0;
            for (int j = 0; j < weights.Count; j++)
            {
                sum += weights[j];
                if (sum > target) break;
            }
        }
        naiveStopwatch.Stop();
        
        // Binary search approach
        var binaryStopwatch = Stopwatch.StartNew();
        var cumulativeWeights = new int[weights.Count];
        cumulativeWeights[0] = weights[0];
        for (int i = 1; i < weights.Count; i++)
        {
            cumulativeWeights[i] = cumulativeWeights[i-1] + weights[i];
        }
        
        for (int i = 0; i < iterations; i++)
        {
            int target = random.Next(totalWeight);
            int index = Array.BinarySearch(cumulativeWeights, target);
            if (index < 0) index = ~index;
        }
        binaryStopwatch.Stop();
        
        Console.WriteLine($"Alias Method:");
        Console.WriteLine($"  Construction: {aliasConstructionTime}ms");
        Console.WriteLine($"  Sampling: {aliasStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"  Total: {aliasConstructionTime + aliasStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine();
        Console.WriteLine($"Naive Method: {naiveStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Binary Search: {binaryStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine();
        Console.WriteLine($"Alias vs Naive speedup: {(double)naiveStopwatch.ElapsedMilliseconds / aliasStopwatch.ElapsedMilliseconds:F2}x");
        Console.WriteLine($"Alias vs Binary speedup: {(double)binaryStopwatch.ElapsedMilliseconds / aliasStopwatch.ElapsedMilliseconds:F2}x");
    }
}
```

### Integration with Mod Generation Systems

```csharp
public class ModGenerationSystem
{
    private readonly Dictionary<ModTier, HELPicker> tierPickers;
    private readonly Dictionary<ModTier, List<Mod>> tierMods;
    private readonly ModsList allMods;
    
    public ModGenerationSystem(ModsList mods)
    {
        allMods = mods;
        tierPickers = new Dictionary<ModTier, HELPicker>();
        tierMods = new Dictionary<ModTier, List<Mod>>();
        
        InitializeTierPickers();
    }
    
    private void InitializeTierPickers()
    {
        // Group mods by tier
        var modsByTier = allMods.mods.GroupBy(m => m.Tier).ToDictionary(g => g.Key, g => g.ToList());
        
        foreach (var tierGroup in modsByTier)
        {
            ModTier tier = tierGroup.Key;
            List<Mod> modsInTier = tierGroup.Value;
            
            // Extract weights from mod definitions
            List<int> weights = modsInTier.Select(mod => {
                // Use mod-specific weight if available, otherwise use tier-based default
                return mod.Weight ?? GetDefaultWeightForTier(tier);
            }).ToList();
            
            tierMods[tier] = modsInTier;
            tierPickers[tier] = new HELPicker(weights);
        }
    }
    
    private int GetDefaultWeightForTier(ModTier tier)
    {
        return tier switch
        {
            ModTier.Common => 1000,
            ModTier.Uncommon => 400,
            ModTier.Rare => 150,
            ModTier.Epic => 50,
            ModTier.Legendary => 15,
            ModTier.Mythic => 3,
            _ => 100
        };
    }
    
    public Mod GenerateModForTier(ModTier tier)
    {
        if (!tierPickers.ContainsKey(tier))
            throw new ArgumentException($"No mods available for tier: {tier}");
        
        int selectedIndex = tierPickers[tier].Sample();
        return tierMods[tier][selectedIndex];
    }
    
    public List<Mod> GenerateModPack(Dictionary<ModTier, int> tierCounts)
    {
        var result = new List<Mod>();
        
        foreach (var tierCount in tierCounts)
        {
            ModTier tier = tierCount.Key;
            int count = tierCount.Value;
            
            for (int i = 0; i < count; i++)
            {
                result.Add(GenerateModForTier(tier));
            }
        }
        
        return result;
    }
    
    // Advanced: Context-aware mod generation
    public Mod GenerateContextualMod(PlayerState player, GameContext context)
    {
        // Calculate dynamic weights based on context
        var adjustedWeights = allMods.mods.Select(mod => {
            int baseWeight = mod.Weight ?? 100;
            double contextMultiplier = 1.0;
            
            // Boost mods that synergize with current player mods
            if (HasSynergy(mod, player.CurrentMods))
                contextMultiplier *= 2.0;
            
            // Boost mods appropriate for current challenge
            if (context.NeedsDefensive && mod.HasDefensiveStats())
                contextMultiplier *= 1.5;
            if (context.NeedsOffensive && mod.HasOffensiveStats())
                contextMultiplier *= 1.5;
            
            // Reduce weight for duplicate mod types
            if (player.HasModOfType(mod.Type))
                contextMultiplier *= 0.3;
            
            return Math.Max(1, (int)(baseWeight * contextMultiplier));
        }).ToList();
        
        // Create temporary picker for this context
        var contextPicker = new HELPicker(adjustedWeights);
        int selectedIndex = contextPicker.Sample();
        return allMods.mods[selectedIndex];
    }
    
    private bool HasSynergy(Mod newMod, List<Mod> existingMods)
    {
        // Implementation depends on mod synergy rules
        return existingMods.Any(existing => 
            newMod.Tags.Intersect(existing.Tags).Any() ||
            newMod.StatCategory == existing.StatCategory);
    }
}
```

## 3.3.7 Comparison with Alternative Approaches

### Naive Weighted Selection: O(N) Per Sample

Traditional weighted selection requires linear search for each sample:

```csharp
public class NaiveWeightedSelector
{
    private readonly List<int> weights;
    private readonly int totalWeight;
    private readonly Random random;
    
    public NaiveWeightedSelector(List<int> weights)
    {
        this.weights = new List<int>(weights);
        this.totalWeight = weights.Sum();
        this.random = new Random();
    }
    
    public int Sample()  // O(N) time per sample
    {
        int target = random.Next(totalWeight);
        int currentSum = 0;
        
        for (int i = 0; i < weights.Count; i++)
        {
            currentSum += weights[i];
            if (currentSum > target)
                return i;
        }
        
        return weights.Count - 1; // Fallback
    }
}
```

**Performance Characteristics:**
- Construction: O(1) - just store weights
- Sampling: O(N) - linear search through weights
- Memory: O(N) - single weight array

### Binary Search Approach: O(log N) Per Sample

Improved approach using cumulative weights and binary search:

```csharp
public class BinarySearchWeightedSelector
{
    private readonly int[] cumulativeWeights;
    private readonly int totalWeight;
    private readonly Random random;
    
    public BinarySearchWeightedSelector(List<int> weights)
    {
        cumulativeWeights = new int[weights.Count];
        cumulativeWeights[0] = weights[0];
        
        for (int i = 1; i < weights.Count; i++)
        {
            cumulativeWeights[i] = cumulativeWeights[i-1] + weights[i];
        }
        
        totalWeight = cumulativeWeights[cumulativeWeights.Length - 1];
        random = new Random();
    }
    
    public int Sample()  // O(log N) time per sample
    {
        int target = random.Next(totalWeight);
        int index = Array.BinarySearch(cumulativeWeights, target);
        
        if (index < 0)
            index = ~index; // Convert to insertion point
        
        return Math.Min(index, cumulativeWeights.Length - 1);
    }
}
```

**Performance Characteristics:**
- Construction: O(N) - build cumulative array
- Sampling: O(log N) - binary search
- Memory: O(N) - cumulative weight array

### Alias Method: O(1) Per Sample After O(N) Setup

HELPicker provides optimal sampling performance:

```csharp
// Already implemented in HELPicker class
// Construction: O(N) - build alias and probability tables
// Sampling: O(1) - constant time lookup
// Memory: O(N) - two arrays (alias + probability)
```

### Performance Comparison Analysis

```csharp
public static void CompareAllMethods(List<int> weights, int sampleCount = 1000000)
{
    Console.WriteLine("Comprehensive Performance Comparison");
    Console.WriteLine($"Testing with {weights.Count} items, {sampleCount:N0} samples");
    Console.WriteLine();
    
    // Test Naive Method
    var naiveStopwatch = Stopwatch.StartNew();
    var naiveSelector = new NaiveWeightedSelector(weights);
    var naiveConstructionTime = naiveStopwatch.ElapsedMilliseconds;
    
    naiveStopwatch.Restart();
    for (int i = 0; i < sampleCount; i++)
    {
        naiveSelector.Sample();
    }
    naiveStopwatch.Stop();
    var naiveSamplingTime = naiveStopwatch.ElapsedMilliseconds;
    
    // Test Binary Search Method
    var binaryStopwatch = Stopwatch.StartNew();
    var binarySelector = new BinarySearchWeightedSelector(weights);
    var binaryConstructionTime = binaryStopwatch.ElapsedMilliseconds;
    
    binaryStopwatch.Restart();
    for (int i = 0; i < sampleCount; i++)
    {
        binarySelector.Sample();
    }
    binaryStopwatch.Stop();
    var binarySamplingTime = binaryStopwatch.ElapsedMilliseconds;
    
    // Test Alias Method
    var aliasStopwatch = Stopwatch.StartNew();
    var aliasSelector = new HELPicker(weights);
    var aliasConstructionTime = aliasStopwatch.ElapsedMilliseconds;
    
    aliasStopwatch.Restart();
    for (int i = 0; i < sampleCount; i++)
    {
        aliasSelector.Sample();
    }
    aliasStopwatch.Stop();
    var aliasSamplingTime = aliasStopwatch.ElapsedMilliseconds;
    
    // Results Summary
    Console.WriteLine("Method        | Setup (ms) | Sampling (ms) | Total (ms) | Samples/sec");
    Console.WriteLine("--------------|------------|---------------|------------|------------");
    Console.WriteLine($"Naive         | {naiveConstructionTime,9} | {naiveSamplingTime,12} | {naiveConstructionTime + naiveSamplingTime,9} | {sampleCount * 1000.0 / naiveSamplingTime,10:N0}");
    Console.WriteLine($"Binary Search | {binaryConstructionTime,9} | {binarySamplingTime,12} | {binaryConstructionTime + binarySamplingTime,9} | {sampleCount * 1000.0 / binarySamplingTime,10:N0}");
    Console.WriteLine($"Alias Method  | {aliasConstructionTime,9} | {aliasSamplingTime,12} | {aliasConstructionTime + aliasSamplingTime,9} | {sampleCount * 1000.0 / aliasSamplingTime,10:N0}");
    
    Console.WriteLine();
    Console.WriteLine("Speedup vs Naive:");
    Console.WriteLine($"Binary Search: {(double)naiveSamplingTime / binarySamplingTime:F2}x faster");
    Console.WriteLine($"Alias Method:  {(double)naiveSamplingTime / aliasSamplingTime:F2}x faster");
}
```

### Memory Usage Comparisons

| Method | Arrays | Size per Item | Total Memory | Notes |
|--------|--------|---------------|--------------|-------|
| Naive | 1 (weights) | 4 bytes | 4N bytes | Simplest storage |
| Binary Search | 1 (cumulative) | 4 bytes | 4N bytes | Same as naive |
| **Alias Method** | 2 (alias + prob) | 12 bytes | 12N bytes | 3x memory, O(1) sampling |

### When to Use Each Approach

#### Use Naive Method When:
- Very small distributions (N < 20)
- Infrequent sampling (< 1000 samples total)
- Memory is extremely constrained
- Simple implementation is prioritized over performance

#### Use Binary Search When:
- Medium distributions (20 < N < 1000)
- Moderate sampling frequency (1000-100K samples)
- Balance between memory usage and performance
- O(log N) complexity is acceptable

#### Use Alias Method (HELPicker) When:
- Large distributions (N > 100)
- High sampling frequency (>100K samples)
- O(1) sampling performance is required
- 3x memory overhead is acceptable
- Maximum performance is prioritized

#### HIOX Game Recommendations:
For HIOX mod generation systems, **use HELPicker** because:
- Mod catalogs typically contain hundreds to thousands of items
- Loot generation requires frequent sampling (multiple times per second)
- Player experience depends on responsive generation
- Memory overhead is negligible for modern systems

## 3.3.8 Complete Usage Examples

### Basic Setup and Sampling

```csharp
public static void BasicUsageExample()
{
    Console.WriteLine("HELPicker Basic Usage Example");
    Console.WriteLine("=============================");
    
    // Define mod weights (representing drop rates)
    List<int> modWeights = new List<int> 
    {
        1000,  // Index 0: Common Sword Mod (1000 weight)
        500,   // Index 1: Shield Boost Mod (500 weight)
        200,   // Index 2: Speed Enhancement (200 weight)
        75,    // Index 3: Critical Strike Mod (75 weight)
        25,    // Index 4: Legendary Fire Mod (25 weight)
        5      // Index 5: Mythic Void Mod (5 weight)
    };
    
    // Create picker - this does O(N) preprocessing
    Console.WriteLine("Creating HELPicker...");
    var stopwatch = Stopwatch.StartNew();
    HELPicker picker = new HELPicker(modWeights);
    stopwatch.Stop();
    Console.WriteLine($"Construction completed in {stopwatch.ElapsedMicroseconds} microseconds");
    Console.WriteLine();
    
    // Display theoretical probabilities
    int totalWeight = modWeights.Sum();
    Console.WriteLine("Theoretical Probabilities:");
    string[] modNames = { "Common Sword", "Shield Boost", "Speed Enhancement", 
                         "Critical Strike", "Legendary Fire", "Mythic Void" };
    
    for (int i = 0; i < modWeights.Count; i++)
    {
        double probability = (modWeights[i] / (double)totalWeight) * 100;
        Console.WriteLine($"  {modNames[i],-18}: {probability,6:F2}% (weight: {modWeights[i]})");
    }
    Console.WriteLine();
    
    // Generate samples and display results
    Console.WriteLine("Sample Results (first 20 selections):");
    for (int i = 0; i < 20; i++)
    {
        int selectedIndex = picker.Sample();
        Console.WriteLine($"  Sample {i+1,2}: {modNames[selectedIndex]}");
    }
}
```

### Performance Benchmarking

```csharp
public static void PerformanceBenchmarkExample()
{
    Console.WriteLine("HELPicker Performance Benchmark");
    Console.WriteLine("===============================");
    
    // Test different distribution sizes
    int[] testSizes = { 10, 100, 1000, 10000, 50000 };
    int samplesPerTest = 1000000;
    
    Console.WriteLine($"Testing {samplesPerTest:N0} samples for each distribution size:");
    Console.WriteLine();
    Console.WriteLine("Size   | Construction | Sampling  | Total     | Samples/sec | Memory");
    Console.WriteLine("-------|--------------|-----------|-----------|-------------|--------");
    
    foreach (int size in testSizes)
    {
        // Generate test distribution
        var random = new Random(42); // Fixed seed for reproducibility
        List<int> weights = new List<int>();
        for (int i = 0; i < size; i++)
        {
            weights.Add(random.Next(1, 1000));
        }
        
        // Measure construction time
        long memoryBefore = GC.GetTotalMemory(true);
        var constructionTimer = Stopwatch.StartNew();
        HELPicker picker = new HELPicker(weights);
        constructionTimer.Stop();
        long memoryAfter = GC.GetTotalMemory(false);
        
        // Measure sampling time
        var samplingTimer = Stopwatch.StartNew();
        for (int i = 0; i < samplesPerTest; i++)
        {
            picker.Sample();
        }
        samplingTimer.Stop();
        
        // Calculate metrics
        double constructionMs = constructionTimer.Elapsed.TotalMilliseconds;
        double samplingMs = samplingTimer.Elapsed.TotalMilliseconds;
        double totalMs = constructionMs + samplingMs;
        double samplesPerSecond = samplesPerTest / samplingTimer.Elapsed.TotalSeconds;
        double memoryKB = (memoryAfter - memoryBefore) / 1024.0;
        
        Console.WriteLine($"{size,6} | {constructionMs,11:F2}ms | {samplingMs,8:F2}ms | {totalMs,8:F2}ms | {samplesPerSecond,10:N0} | {memoryKB,5:F1}KB");
    }
    
    Console.WriteLine();
    Console.WriteLine("Key Observations:");
    Console.WriteLine("- Construction time scales linearly with distribution size (O(N))");
    Console.WriteLine("- Sampling time remains constant regardless of size (O(1))");
    Console.WriteLine("- Memory usage is approximately 12 bytes per item");
    Console.WriteLine("- Performance typically exceeds 10 million samples per second");
}
```

### Integration with ModsData Weights

```csharp
public static void ModsDataIntegrationExample()
{
    Console.WriteLine("ModsData Integration Example");
    Console.WriteLine("============================");
    
    try
    {
        // Load mods from YAML file
        Console.WriteLine("Loading mods from ModsData.asset...");
        ModsList modsData = HELYAMLFile.LoadMods("ModsData.asset");
        Console.WriteLine($"Loaded {modsData.mods.Count} mods");
        Console.WriteLine();
        
        // Extract weights from mod definitions
        List<int> weights = new List<int>();
        Dictionary<int, string> indexToModName = new Dictionary<int, string>();
        
        for (int i = 0; i < modsData.mods.Count; i++)
        {
            Mod mod = modsData.mods[i];
            
            // Use mod weight if specified, otherwise calculate based on color/rarity
            int weight = mod.Weight ?? CalculateWeightFromColor(mod.color);
            weights.Add(weight);
            indexToModName[i] = mod.name;
        }
        
        // Create picker with extracted weights
        Console.WriteLine("Creating HELPicker with extracted weights...");
        HELPicker modPicker = new HELPicker(weights);
        Console.WriteLine("HELPicker ready for mod selection");
        Console.WriteLine();
        
        // Demonstrate weighted mod selection
        Console.WriteLine("Sample Mod Selections:");
        var selectionCounts = new Dictionary<ModColor, int>();
        
        for (int i = 0; i < 100; i++)
        {
            int selectedIndex = modPicker.Sample();
            Mod selectedMod = modsData.mods[selectedIndex];
            
            // Count selections by color/rarity
            selectionCounts[selectedMod.color] = selectionCounts.GetValueOrDefault(selectedMod.color, 0) + 1;
            
            if (i < 10) // Show first 10 selections
            {
                Console.WriteLine($"  {i+1,2}: {selectedMod.name} ({selectedMod.color})");
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("Selection Distribution (100 samples):");
        foreach (var colorCount in selectionCounts.OrderByDescending(kvp => kvp.Value))
        {
            Console.WriteLine($"  {colorCount.Key,-10}: {colorCount.Value,3} selections ({colorCount.Value}%)");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading ModsData: {ex.Message}");
        Console.WriteLine("Make sure ModsData.asset exists in the current directory");
    }
}

private static int CalculateWeightFromColor(ModColor color)
{
    return color switch
    {
        ModColor.White => 1000,    // Common - high weight
        ModColor.Green => 400,     // Uncommon - medium weight
        ModColor.Blue => 150,      // Rare - lower weight
        ModColor.Purple => 50,     // Epic - low weight
        ModColor.Orange => 15,     // Legendary - very low weight
        ModColor.Red => 3,         // Mythic - extremely low weight
        _ => 100                   // Default weight
    };
}
```

### Statistical Distribution Verification

```csharp
public static void StatisticalVerificationExample()
{
    Console.WriteLine("Statistical Distribution Verification");
    Console.WriteLine("====================================");
    
    // Define test distribution with known probabilities
    List<int> testWeights = new List<int> { 500, 300, 150, 40, 10 };
    string[] itemNames = { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
    
    HELPicker picker = new HELPicker(testWeights);
    
    // Calculate theoretical probabilities
    double totalWeight = testWeights.Sum();
    double[] expectedProbabilities = testWeights.Select(w => w / totalWeight).ToArray();
    
    Console.WriteLine("Theoretical Distribution:");
    for (int i = 0; i < testWeights.Count; i++)
    {
        Console.WriteLine($"  {itemNames[i],-10}: {expectedProbabilities[i] * 100,6:F2}% (weight: {testWeights[i]})");
    }
    Console.WriteLine();
    
    // Run multiple test batches with different sample sizes
    int[] sampleSizes = { 1000, 10000, 100000, 1000000 };
    
    foreach (int sampleSize in sampleSizes)
    {
        Console.WriteLine($"Verification with {sampleSize:N0} samples:");
        
        // Generate samples
        var results = new Dictionary<int, int>();
        for (int i = 0; i < sampleSize; i++)
        {
            int selected = picker.Sample();
            results[selected] = results.GetValueOrDefault(selected, 0) + 1;
        }
        
        // Calculate actual probabilities and errors
        Console.WriteLine("Item       | Expected% | Actual% | Error% | Chi-Square");
        Console.WriteLine("-----------|-----------|---------|--------|-----------");
        
        double chiSquare = 0.0;
        for (int i = 0; i < testWeights.Count; i++)
        {
            double expectedPercent = expectedProbabilities[i] * 100;
            int actualCount = results.GetValueOrDefault(i, 0);
            double actualPercent = (actualCount / (double)sampleSize) * 100;
            double errorPercent = Math.Abs(expectedPercent - actualPercent);
            
            // Calculate chi-square contribution
            double expectedCount = expectedProbabilities[i] * sampleSize;
            double chiSquareContribution = Math.Pow(actualCount - expectedCount, 2) / expectedCount;
            chiSquare += chiSquareContribution;
            
            Console.WriteLine($"{itemNames[i],-10} | {expectedPercent,8:F2}% | {actualPercent,6:F2}% | {errorPercent,5:F2}% | {chiSquareContribution,9:F4}");
        }
        
        Console.WriteLine($"Total Chi-Square: {chiSquare:F4}");
        
        // Interpret chi-square result (degrees of freedom = categories - 1)
        int degreesOfFreedom = testWeights.Count - 1;
        string interpretation = chiSquare < (degreesOfFreedom * 2) ? "GOOD" : "CHECK";
        Console.WriteLine($"Distribution Quality: {interpretation} (χ² = {chiSquare:F2}, df = {degreesOfFreedom})");
        Console.WriteLine();
    }
    
    Console.WriteLine("Notes:");
    Console.WriteLine("- Error percentages should decrease as sample size increases");
    Console.WriteLine("- Chi-square values should be reasonable relative to degrees of freedom");
    Console.WriteLine("- 'GOOD' indicates distribution matches expectations well");
}
```

### Error Handling for Edge Cases

```csharp
public static void ErrorHandlingExample()
{
    Console.WriteLine("Error Handling and Edge Cases");
    Console.WriteLine("=============================");
    
    // Test Case 1: Empty weight list
    Console.WriteLine("Test 1: Empty weight list");
    try
    {
        var emptyWeights = new List<int>();
        var picker1 = new HELPicker(emptyWeights);
        Console.WriteLine("❌ Should have thrown exception for empty weights");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"✅ Correctly handled: {ex.GetType().Name}");
    }
    
    // Test Case 2: Single item
    Console.WriteLine("\nTest 2: Single item distribution");
    try
    {
        var singleWeight = new List<int> { 100 };
        var picker2 = new HELPicker(singleWeight);
        
        // Sample multiple times - should always return 0
        var results = new HashSet<int>();
        for (int i = 0; i < 100; i++)
        {
            results.Add(picker2.Sample());
        }
        
        if (results.Count == 1 && results.Contains(0))
        {
            Console.WriteLine("✅ Single item correctly returns index 0");
        }
        else
        {
            Console.WriteLine($"❌ Single item returned indices: {string.Join(", ", results)}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Unexpected error: {ex.Message}");
    }
    
    // Test Case 3: Zero weights
    Console.WriteLine("\nTest 3: Zero and negative weights");
    try
    {
        var problematicWeights = new List<int> { 0, -5, 10, 0, 20 };
        var picker3 = new HELPicker(problematicWeights);
        
        // Sample and check distribution
        var results = new Dictionary<int, int>();
        for (int i = 0; i < 10000; i++)
        {
            int selected = picker3.Sample();
            results[selected] = results.GetValueOrDefault(selected, 0) + 1;
        }
        
        Console.WriteLine("Results with zero/negative weights:");
        foreach (var kvp in results.OrderBy(kvp => kvp.Key))
        {
            double percent = (kvp.Value / 10000.0) * 100;
            Console.WriteLine($"  Index {kvp.Key}: {percent:F1}% (original weight: {problematicWeights[kvp.Key]})");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error with problematic weights: {ex.Message}");
    }
    
    // Test Case 4: Very large weights
    Console.WriteLine("\nTest 4: Very large weights");
    try
    {
        var largeWeights = new List<int> { int.MaxValue, int.MaxValue / 2, 1000000 };
        var picker4 = new HELPicker(largeWeights);
        
        Console.WriteLine("✅ Successfully handled very large weights");
        
        // Test sampling
        int sample = picker4.Sample();
        Console.WriteLine($"Sample result: {sample} (valid range: 0-{largeWeights.Count - 1})");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Failed with large weights: {ex.Message}");
    }
    
    // Test Case 5: Performance with extreme skew
    Console.WriteLine("\nTest 5: Extreme weight skew");
    try
    {
        var skewedWeights = new List<int> { 1000000, 1, 1, 1, 1 };
        var picker5 = new HELPicker(skewedWeights);
        
        var results = new Dictionary<int, int>();
        for (int i = 0; i < 100000; i++)
        {
            int selected = picker5.Sample();
            results[selected] = results.GetValueOrDefault(selected, 0) + 1;
        }
        
        double dominantPercent = (results.GetValueOrDefault(0, 0) / 100000.0) * 100;
        Console.WriteLine($"Dominant item selected: {dominantPercent:F2}% (expected ~99.9%)");
        
        if (dominantPercent > 99.0 && dominantPercent < 100.0)
        {
            Console.WriteLine("✅ Extreme skew handled correctly");
        }
        else
        {
            Console.WriteLine("❌ Extreme skew distribution incorrect");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Failed with extreme skew: {ex.Message}");
    }
    
    Console.WriteLine("\nRecommendations:");
    Console.WriteLine("- Always validate weight lists before creating HELPicker");
    Console.WriteLine("- Use positive integer weights for best results");
    Console.WriteLine("- Consider weight normalization for very large values");
    Console.WriteLine("- Test edge cases in your specific integration");
}
```

## 3.3.9 Cross-References

### Related Documentation Sections

- **Section 1.1**: [Overview and Core Concepts](1-1-Overview-Core-Concepts.md) - Understanding the HEL system architecture
- **Section 2.1**: [Integration Overview](2-1-Integration-Overview.md) - Setting up HEL system integration
- **Section 2.4**: [HELPicker Usage Guide](2-4-HELPicker-Usage.md) - Practical usage patterns and examples
- **Section 2.5**: [Common Integration Patterns](2-5-Common-Integration-Patterns.md) - Best practices for HEL integration
- **Section 3.1**: [HEL Class Reference](3-1-HEL-Class-Reference.md) - Core equation evaluation engine
- **Section 3.2**: [File I/O Classes Reference](3-2-File-IO-Classes-Reference.md) - Working with mod and stat data files

### Integration Examples Cross-References

- **ModsData Integration**: See examples in Section 2.4 for loading weights from YAML/CSV files
- **Performance Optimization**: Refer to Section 2.5 for advanced performance patterns
- **Thread Safety**: Detailed patterns available in Section 2.5 Common Integration Patterns
- **Dynamic Weight Updates**: Advanced scenarios covered in Section 2.4 Usage Guide

### Algorithm References

The Alias method implementation is based on the classic algorithm described by:
- Walker, A. J. (1977). "An efficient method for generating discrete random variables with general distributions"
- Vose, M. D. (1991). "A linear algorithm for generating random numbers with a given distribution"

### Mathematical Background

For deeper understanding of the mathematical foundations:
- **Discrete Probability Distributions**: Standard probability theory texts
- **Random Number Generation**: Knuth's "The Art of Computer Programming" Volume 2
- **Algorithm Analysis**: Cormen et al. "Introduction to Algorithms" for complexity analysis

---

*This API reference provides complete technical documentation for the HELPicker class implementation. The Alias method offers mathematically optimal O(1) weighted selection for HIOX mod generation systems.*

---

# 3.4 Data Classes Reference

This section provides complete API reference documentation for the data structure classes defined in `HELAssetDefs.cs`. These classes represent the core data objects used throughout the HEL system for mods, stats, and serialization.

## 3.4.1 Mod Class

### Class Overview

The `Mod` class represents a game modification with all its properties including values, ranges, colors, and equations. It serves as the primary data structure for mod definitions and is designed for serialization/deserialization with asset files.

**Purpose**: Encapsulates all properties needed to define a game modification that can alter player statistics through HEL equations.

**Key Features**:
- Support for dual values (`val` and `val2`) with configurable ranges
- HEL equation string integration for stat modifications
- Visual representation through color properties
- Unity asset references for armor effects and meshes
- Deep copy semantics through copy constructor

### Properties

#### Core Identification
- **`modid` (int)**: Unique identifier for the mod type
  - Must be unique across all mod types in the system
  - Used for referencing and dependency resolution
  - Required for proper asset management

- **`uuid` (string)**: Unique identifier for individual mod instances
  - Default: `string.Empty`
  - Format: `"uuid-{modid}-{6-character-guid}"` (e.g., `"uuid-0-123456"`)
  - Enables multiple instances of the same mod type (same modid)
  - Used as primary key in mod dictionaries

#### Value Properties
- **`val` (float)**: Primary mod value used in HEL equations
  - Often referenced as `@val` in equation strings
  - Should fall within the range defined by `val1min` and `val1max`
  - Core parameter for stat modification calculations

- **`val2` (float)**: Secondary mod value used in HEL equations
  - Often referenced as `@val2` in equation strings
  - Should fall within the range defined by `val2min` and `val2max`
  - Provides additional parameterization for complex mods

#### Range Constraints
- **`val1min` (float)**: Minimum value for the primary mod value range
  - Defines lower bound for `val` during mod generation
  - Used for validation and random value generation

- **`val1max` (float)**: Maximum value for the primary mod value range
  - Defines upper bound for `val` during mod generation
  - Must be greater than or equal to `val1min`

- **`val2min` (float)**: Minimum value for the secondary mod value range
  - Defines lower bound for `val2` during mod generation
  - Used for validation and random value generation

- **`val2max` (float)**: Maximum value for the secondary mod value range
  - Defines upper bound for `val2` during mod generation
  - Must be greater than or equal to `val2min`

#### Display Properties
- **`name` (string)**: Display name of the mod
  - Default: `string.Empty`
  - Used in UI displays and mod identification
  - Should be human-readable and descriptive

- **`desc` (string)**: Description of the mod
  - Default: `string.Empty`
  - Provides detailed explanation of mod effects
  - Used in tooltips and detailed views

#### Behavior Properties
- **`modweight` (int)**: Weight/priority of the mod for ordering purposes
  - Used in dependency resolution and evaluation order
  - Higher values may indicate higher priority
  - See section 1.6 for dependency resolution details

- **`type` (int)**: Type identifier of the mod
  - Categorizes mods into different types
  - May affect processing behavior
  - Used for filtering and organization

- **`hasProc` (int)**: Special process flag (0 = no, 1 = yes)
  - Indicates whether the mod requires special processing
  - May trigger additional validation or handling
  - Boolean-like integer field

#### Equation Properties
- **`equation` (string)**: HEL equation string defining stat modifications
  - Default: `string.Empty`
  - Contains the core logic for how the mod affects stats
  - Must follow HEL syntax rules (see section 1.3)
  - Evaluated by the HEL interpreter

#### Visual Properties
- **`modColor` (ModColor)**: Visual representation properties
  - Default: `new ModColor()`
  - Defines RGBA color values for UI display
  - See ModColor class documentation below

#### Unity Integration
- **`armorEffectName` (string)**: Unity asset reference for armor effects
  - Default: `string.Empty`
  - References Unity asset names for visual effects
  - Used in the main HIOX game for rendering

- **`armorMeshName` (string)**: Unity asset reference for armor meshes
  - Default: `string.Empty`
  - References Unity asset names for 3D meshes
  - Used in the main HIOX game for rendering

### Constructors

#### Default Constructor
```csharp
public Mod()
```
Creates a new Mod instance with default values for all properties.

#### Copy Constructor
```csharp
public Mod(Mod other)
```
Creates a deep copy of another Mod instance.

**Parameters**:
- `other`: The Mod instance to copy from

**Copy Behavior**:
- **Value types**: Direct copy (int, float properties)
- **Strings**: Direct assignment (safe due to immutability)
- **ModColor**: Shallow copy (sufficient for current usage)
- **Deep copy semantics**: Creates independent instance

## 3.4.2 Stat Class

### Class Overview

The `Stat` class represents a game statistic with its current value and allowable range constraints. It provides the foundation for the statistical system that mods modify through HEL equations.

**Purpose**: Encapsulates a single statistic with value bounds and metadata for use in stat calculations and validation.

### Properties

#### Identification
- **`name` (string)**: Stat identifier
  - Default: `string.Empty`
  - Used as the key in stat lookups and equation references
  - Must be unique within a stat collection
  - Case-sensitive in HEL equations

- **`desc` (string)**: Description of the stat
  - Default: `string.Empty`
  - Human-readable explanation of the stat's purpose
  - Used in UI displays and documentation

#### Value Management
- **`value` (float)**: Current value of the stat
  - The active value used in calculations
  - Should be within the range defined by `min` and `max`
  - Modified by HEL equation evaluation

- **`min` (float)**: Minimum allowable value for the stat
  - Lower bound constraint for validation
  - Values below this threshold may be clamped
  - Used in range validation

- **`max` (float)**: Maximum allowable value for the stat
  - Upper bound constraint for validation
  - Values above this threshold may be clamped
  - Used in range validation

### Constructors

#### Default Constructor
```csharp
public Stat()
```
Creates a new Stat instance with default values.

#### Copy Constructor
```csharp
public Stat(Stat other)
```
Creates a deep copy of another Stat instance.

**Parameters**:
- `other`: The Stat instance to copy from

**Copy Behavior**:
- **Strings**: Direct assignment (immutable)
- **Value types**: Direct copy
- **Deep copy semantics**: Creates independent instance

## 3.4.3 ModColor Class

### Class Overview

The `ModColor` class provides RGBA color representation for mod visual display using integer-based color components.

**Purpose**: Encapsulates color information for UI rendering and visual mod identification.

### Properties

- **`r` (int)**: Red color component
  - Integer value representing red intensity
  - Typical range: 0-255

- **`g` (int)**: Green color component
  - Integer value representing green intensity
  - Typical range: 0-255

- **`b` (int)**: Blue color component
  - Integer value representing blue intensity
  - Typical range: 0-255

- **`a` (int)**: Alpha (transparency) component
  - Integer value representing opacity
  - Typical range: 0-255 (0 = transparent, 255 = opaque)

## 3.4.4 Container Classes

### ModsList Class

Container class for serializing collections of Mod objects with YAML/JSON formats.

#### Properties
- **`mods` (List&lt;Mod&gt;)**: Collection of mods
  - Default: `new List<Mod>()`
  - Used as root property in YAML/JSON serialization
  - Provides list-based access to mod collections

#### Usage with Serialization
```csharp
// Loading mods from YAML
ModsList modsList = yamlDeserializer.Deserialize<ModsList>(yamlContent);
List<Mod> mods = modsList.mods;

// Saving mods to YAML
ModsList container = new ModsList { mods = modCollection };
string yamlOutput = yamlSerializer.Serialize(container);
```

### StatsList Class

Container class for serializing collections of Stat objects with YAML/JSON formats.

#### Properties
- **`stats` (List&lt;Stat&gt;)**: Collection of stats
  - Default: `new List<Stat>()`
  - Used as root property in YAML/JSON serialization
  - Provides list-based access to stat collections

#### Usage with Serialization
```csharp
// Loading stats from YAML
StatsList statsList = yamlDeserializer.Deserialize<StatsList>(yamlContent);
List<Stat> stats = statsList.stats;

// Saving stats to YAML
StatsList container = new StatsList { stats = statCollection };
string yamlOutput = yamlSerializer.Serialize(container);
```

## 3.4.5 Usage Patterns and Validation

### Data Validation

#### Required Field Validation
- **Mod.modid**: Must be unique and non-zero
- **Mod.name**: Should not be empty for user-facing mods
- **Mod.equation**: Required for functional mods
- **Stat.name**: Must be unique and non-empty

#### Range Constraint Checking
```csharp
// Validate mod value ranges
if (mod.val < mod.val1min || mod.val > mod.val1max)
{
    // Handle range violation
}

// Validate stat bounds
if (stat.value < stat.min || stat.value > stat.max)
{
    stat.value = Math.Max(stat.min, Math.Min(stat.max, stat.value));
}
```

#### Equation Syntax Validation
```csharp
// Validate HEL equation syntax
try 
{
    HELLexer lexer = new HELLexer();
    var tokens = lexer.Tokenize(mod.equation);
    // Additional validation logic
}
catch (Exception ex)
{
    // Handle syntax errors
}
```

### Copy Semantics

#### Deep vs Shallow Copy Considerations
- **Mod copy constructor**: Creates deep copy with independent values
- **ModColor copying**: Shallow copy is sufficient (simple value types)
- **String handling**: Immutability makes direct assignment safe
- **List copying**: Container classes require manual list copying

```csharp
// Deep copy a mod
Mod originalMod = LoadMod();
Mod modCopy = new Mod(originalMod); // Independent copy

// Copy mod collections
List<Mod> originalMods = LoadMods();
List<Mod> copiedMods = originalMods.Select(m => new Mod(m)).ToList();
```

### Serialization Integration

#### YamlDotNet Compatibility
The data classes are designed to work seamlessly with YamlDotNet serialization:

```csharp
// YAML serialization example
var yamlSerializer = new SerializerBuilder().Build();
var yamlDeserializer = new DeserializerBuilder().Build();

// Serialize mods
ModsList modsContainer = new ModsList { mods = modCollection };
string yamlContent = yamlSerializer.Serialize(modsContainer);

// Deserialize mods
ModsList loadedMods = yamlDeserializer.Deserialize<ModsList>(yamlContent);
```

#### CSV Field Mapping
For CSV integration, see `HELCSVFile.cs` for field mapping details (section 3.2).

#### Asset File Structure Requirements
- **ModsData.asset**: Uses ModsList as root container
- **StatsData.asset**: Uses StatsList as root container
- YAML structure must match class property names exactly
- Field order in CSV must match expected column layout

### Common Operations

#### Mod Creation and Modification
```csharp
// Create new mod
Mod newMod = new Mod
{
    modid = GetNextModId(),
    name = "Power Boost",
    val = 15.0f,
    val1min = 10.0f,
    val1max = 20.0f,
    equation = "strength += @val",
    modColor = new ModColor { r = 255, g = 0, b = 0, a = 255 }
};

// Modify existing mod
mod.val = GenerateRandomValue(mod.val1min, mod.val1max);
mod.val2 = GenerateRandomValue(mod.val2min, mod.val2max);
```

#### Stat Range Validation and Clamping
```csharp
// Clamp stat to valid range
public void ClampStatValue(Stat stat)
{
    stat.value = Math.Max(stat.min, Math.Min(stat.max, stat.value));
}

// Validate stat ranges
public bool IsStatValueValid(Stat stat)
{
    return stat.value >= stat.min && stat.value <= stat.max;
}
```

#### Color Component Manipulation
```csharp
// Create color from components
ModColor red = new ModColor { r = 255, g = 0, b = 0, a = 255 };

// Modify color transparency
color.a = 128; // 50% transparency

// Color interpolation
ModColor InterpolateColors(ModColor a, ModColor b, float t)
{
    return new ModColor
    {
        r = (int)(a.r + (b.r - a.r) * t),
        g = (int)(a.g + (b.g - a.g) * t),
        b = (int)(a.b + (b.b - a.b) * t),
        a = (int)(a.a + (b.a - a.a) * t)
    };
}
```

#### Collection Management Patterns
```csharp
// Find mod by ID
Mod FindModById(List<Mod> mods, int modId)
{
    return mods.FirstOrDefault(m => m.modid == modId);
}

// Filter mods by type
List<Mod> GetModsByType(List<Mod> mods, int type)
{
    return mods.Where(m => m.type == type).ToList();
}

// Sort mods by weight
List<Mod> SortModsByWeight(List<Mod> mods)
{
    return mods.OrderBy(m => m.modweight).ToList();
}
```

### Integration Examples

#### Loading from Asset Files
```csharp
// Load mods from YAML asset file
string yamlContent = File.ReadAllText("ModsData.asset");
var deserializer = new DeserializerBuilder().Build();
ModsList modsList = deserializer.Deserialize<ModsList>(yamlContent);
List<Mod> loadedMods = modsList.mods;

// Load stats from YAML asset file
string statsYaml = File.ReadAllText("StatsData.asset");
StatsList statsList = deserializer.Deserialize<StatsList>(statsYaml);
Dictionary<string, Stat> statsDict = statsList.stats.ToDictionary(s => s.name);
```

#### Runtime Mod Generation
```csharp
// Generate random mod values within constraints
public void RandomizeModValues(Mod mod)
{
    Random rand = new Random();
    
    if (mod.val1max > mod.val1min)
    {
        mod.val = (float)(rand.NextDouble() * (mod.val1max - mod.val1min) + mod.val1min);
    }
    
    if (mod.val2max > mod.val2min)
    {
        mod.val2 = (float)(rand.NextDouble() * (mod.val2max - mod.val2min) + mod.val2min);
    }
}
```

#### Stat Calculation Integration
```csharp
// Apply mod effects to stats using HEL evaluation
public Dictionary<string, float> ApplyModToStats(Mod mod, Dictionary<string, float> currentStats)
{
    // Create working copy
    var workingStats = new Dictionary<string, float>(currentStats);
    
    // Set up evaluation context
    var variableValues = new Dictionary<string, float>
    {
        ["@val"] = mod.val,
        ["@val2"] = mod.val2
    };
    
    // Evaluate equation
    HEL.EvaluateEquation(mod.equation, workingStats, variableValues);
    
    return workingStats;
}
```

#### UI Display Preparation
```csharp
// Prepare mod for UI display
public class ModDisplayInfo
{
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string FormattedValues { get; set; }
    public Color DisplayColor { get; set; }
}

public ModDisplayInfo PrepareModForDisplay(Mod mod)
{
    return new ModDisplayInfo
    {
        DisplayName = mod.name,
        Description = mod.desc,
        FormattedValues = $"Primary: {mod.val:F1}, Secondary: {mod.val2:F1}",
        DisplayColor = Color.FromArgb(mod.modColor.a, mod.modColor.r, mod.modColor.g, mod.modColor.b)
    };
}
```

## 3.4.6 Cross-References

- **Section 2.3 (Asset Management)**: File loading and saving operations using these data classes
- **Section 3.2 (File I/O Classes Reference)**: HELYAMLFile and HELCSVFile implementations that work with these classes
- **Section 1.3 (HEL Syntax)**: Equation string format used in Mod.equation property
- **Section 1.6 (Dependency Resolution)**: How Mod.modweight affects evaluation order

---

# 3.5 Internal Classes Reference

**⚠️ IMPORTANT NOTICE**: The classes documented in this section are internal implementation details of the HEL system. They are **NOT part of the public API** and should **NOT be used directly** by HIOX game developers. This documentation is provided for understanding system internals, debugging complex mod equations, and architectural comprehension only.

For mod equation development and integration, use the public HEL class methods documented in [Section 3.1 - HEL Class Reference](3-1-HEL-Class-Reference.md).

---

## 3.5.1 Token Class (HELLangDefs.cs)

### Overview
The `Token` class represents a single lexical token after HEL equation parsing. Tokens are the atomic units created by the HELLexer from raw equation strings and consumed by the HELInterpreter during evaluation.

**⚠️ Internal Use Only**: Developers should never create Token objects directly. Tokens are automatically generated during the lexical analysis phase of equation processing.

### TokenType Enumeration
The `TokenType` enum defines all possible token classifications in HEL equations:

```csharp
public enum TokenType
{
    Number,        // Numeric literals: "3.14", "42", "-1.5"
    LHSVariable,   // Left-hand assignment targets: "B_STRENGTH", "M_HEALTH" 
    RHSVariable,   // Right-hand expression variables: "S_MANA", "A_DAMAGE"
    Operator,      // Mathematical operators: "+", "-", "*", "/", "^"
    Keyword,       // Language keywords: "MAX", "MIN", "AND", "OR", "IF"
    Assign,        // Assignment operator: "="
    Semicolon,     // Statement terminator: ";"
    EndOfLine,     // Line ending marker
    EOF,           // End of input marker
    Embed,         // Embedded content (mod ID comments)
    Unknown        // Unrecognized token type
}
```

**Usage Context by Type**:
- **Number**: Numeric constants in calculations
- **LHSVariable**: Target variables being assigned values (left side of "=")
- **RHSVariable**: Source variables providing values (right side of "=")
- **Operator/Keyword**: Mathematical operations and functions
- **Assign**: Separates LHS from RHS in assignment statements
- **Semicolon/EndOfLine**: Statement boundaries for parsing
- **Embed**: Special mod ID tracking comments (format: "#!{modid}")

### Properties

```csharp
public class Token
{
    public TokenType Type { get; set; }     // Token classification
    public string Value { get; set; }       // Raw token string (uppercase)
    public char Prefix { get; set; }        // Variable prefix ('S', 'B', 'M', etc.)
    public string Variable { get; set; }    // Variable name after underscore
    public float NumVal { get; set; }       // Numeric value for Number tokens
    public int Position { get; set; }       // Source position for error reporting
}
```

**Property Details**:
- **Type**: Classifies the token for parser decision-making
- **Value**: The original token text, normalized to uppercase
- **Prefix/Variable**: For variables like "B_STRENGTH", Prefix='B', Variable="STRENGTH"
- **NumVal**: Pre-parsed numeric value to avoid repeated parsing
- **Position**: Character offset in source equation for error messages

### Constructor and Methods

```csharp
// Constructor with automatic parsing
public Token(TokenType type, string value, int position)

// Mod ID comment encoding/decoding
public static string EncodeComment(int modid)
public static int DecodeComment(string s)

// Debug output
public void dump()
```

**Constructor Logic**:
- Automatically converts value to uppercase
- Parses numeric values for Number tokens
- Extracts prefix and variable components from underscore-separated identifiers
- Validates variable format (max one underscore allowed)

**Comment Methods**:
- `EncodeComment()`: Creates mod tracking comments like "#!123"
- `DecodeComment()`: Extracts mod ID from comment tokens
- Used internally to associate statements with their source mods

---

## 3.5.2 Statement Class (HELLangDefs.cs)

### Overview
The `Statement` class represents a complete parsed HEL statement ready for evaluation. Statements contain tokenized expressions along with dependency information needed for proper execution ordering.

**⚠️ Internal Use Only**: Statement objects are created automatically during parsing. Use `HEL.EvaluateMods()` instead of manipulating statements directly.

### Properties

```csharp
public class Statement
{
    public int Index { get; set; }              // Original statement position
    public List<Token> Tokens { get; set; }     // Tokens comprising statement
    public Stack<float> Values;                 // Evaluation stack
    public int ModID;                           // Source mod ID
    public int ModPos;                          // Position within mod
    public int pos;                             // Current parsing position
    public Token? LHSVariable { get; set; }     // Assignment target
    public List<Token> RHSVariables { get; set; } // Referenced variables
}
```

**Property Details**:
- **Index**: Sequential position in original statement list (for ordering)
- **Tokens**: The parsed token sequence ready for evaluation
- **Values**: Runtime stack for intermediate expression results
- **ModID/ModPos**: Source mod identification for dependency tracking
- **pos**: Parser cursor position during evaluation
- **LHSVariable**: The variable being assigned to (left side of "=")
- **RHSVariables**: All variables referenced in the expression (right side)

### Constructor and Dependency Analysis

```csharp
public Statement(int index, List<Token> tokens, int modid, int modpos)
```

**Automatic Dependency Extraction**:
The constructor automatically identifies statement dependencies:

1. **Assignment Statements**: Pattern `LHSVariable = Expression`
   - Extracts LHS target variable
   - Identifies all RHS variables containing underscores
   - Builds dependency list for ordering analysis

2. **Embed Statements**: Single embedded token (mod ID comments)
   - Treats embed token as both LHS and RHS for processing
   - Special case handling for mod tracking

**Validation**: Throws exception for invalid statement formats

### Vertex Methods (Dependency Graph)

```csharp
public Vertex GetVertex()                           // Returns (ModID, ModPos) tuple
public string dumpVertex()                          // Current vertex as string
public static string dumpVertex(int modid, int modpos) // Specific vertex as string
```

**Dependency Graph Coordinates**:
- Each statement has a unique vertex position `(ModID, ModPos)`
- Used by HELOrdering for cycle detection and resolution
- Critical for proper execution sequencing in complex mod interactions

### Debug Methods

```csharp
public string dumpStr()  // Concatenated token values
public void dump()       // Console output of statement
```

---

## 3.5.3 Coefficient Class (HELInterpreter.cs)

### Overview
The `Coefficient` class stores internal coefficient values for a single stat across all modification types. Each coefficient represents a different way mods can affect the final stat value.

**⚠️ Internal Use Only**: Coefficient objects are managed internally by the interpreter. Use `HEL.EvaluateMods()` for stat calculations rather than accessing coefficients directly.

### Coefficient Properties

```csharp
protected class Coefficient
{
    public float b { get; set; }  // B_ - Base additive modifier
    public float a { get; set; }  // A_ - Absolute additive modifier  
    public float m { get; set; }  // M_ - Multiplicative modifier
    public float z { get; set; }  // Z_ - Minimum value adjustment
    public float u { get; set; }  // U_ - Maximum value adjustment
    public float s { get; set; }  // S_ - Base stat value
    public float t { get; set; }  // T_ - Temporary modifier
}
```

**Coefficient Type Meanings**:
- **s (S_)**: Original base stat value from StatsData
- **b (B_)**: Base additive changes applied before multiplication
- **a (A_)**: Absolute additive changes applied after multiplication
- **m (M_)**: Multiplicative percentage modifications
- **z (Z_)**: Adjustments to minimum allowable value
- **u (U_)**: Adjustments to maximum allowable value
- **t (T_)**: Temporary modifications (reserved for future use)

### Constructors

```csharp
public Coefficient(float sValue = 0.0f)  // Initialize with base stat value
public Coefficient(Coefficient other)    // Copy constructor
```

**Initialization**:
- Primary constructor sets `s` to the base stat value, zeros all modifiers
- Copy constructor creates deep copy for coefficient accumulation
- All modification coefficients start at zero (additive identity)

### Final Calculation Formula
The coefficients are applied using this formula:
```
result = Min(Max((s + b) * Max(0, 1 + m) + a, min + z), max + u)
```

Where:
- `(s + b)`: Base value plus base modifications
- `Max(0, 1 + m)`: Multiplicative factor (prevents negative multipliers)
- `+ a`: Absolute additions after multiplication
- `min + z`, `max + u`: Adjusted minimum and maximum bounds

---

## 3.5.4 CoefDict Class (HELInterpreter.cs)

### Overview
The `CoefDict` class manages coefficient dictionaries for all stats simultaneously. It handles coefficient accumulation from multiple mods and applies the final calculation to produce modified stat values.

**⚠️ Internal Use Only**: CoefDict objects are used internally for coefficient management. Use `HEL.EvaluateMods()` rather than accessing coefficient dictionaries directly.

### Properties

```csharp
protected class CoefDict
{
    public Dictionary<string, Coefficient> dict;  // Stat name -> coefficients mapping
}
```

### Constructor

```csharp
public CoefDict(statsDictionary inBaseStats)
```

**Initialization Process**:
- Creates coefficient entry for each stat in the base stats dictionary
- Initializes each coefficient's `s` value from the corresponding stat's base value
- Sets all modification coefficients to zero (neutral state)

### Coefficient Accumulation

```csharp
public void Add(CoefDict coef)  // Accumulate coefficients from another CoefDict
public void Div(int N)          // Scale all coefficients by division
```

**Add Method**:
- Accumulates coefficients across all stats
- Adds corresponding coefficient values: `b += other.b`, `a += other.a`, etc.
- Enables combining effects from multiple mods

**Div Method**:
- Scales all coefficients by division (used for averaging)
- May be used for special coefficient normalization cases

### Final Application

```csharp
public statsDictionary Apply(statsDictionary inStats)
```

**Application Process**:
1. Creates a copy of the input stats dictionary
2. For each stat, applies the coefficient formula:
   ```csharp
   result = Min(Max((s + b) * Max(0, 1 + m) + a, min + z), max + u)
   ```
3. Updates the stat's value with the calculated result
4. Returns the modified stats dictionary

### Coefficient Access Methods

```csharp
public float GetCoefficient(string prefix_names)         // "B_STRENGTH" format
public float GetCoefficient(char prefix, string name)    // Separate prefix and name
public void SetCoefficient(string prefix_name, float val) // Update coefficient value
```

**GetCoefficient Methods**:
- Retrieve current coefficient values for specific stat/prefix combinations
- Used during expression evaluation to read variable values
- Supports both combined ("B_STRENGTH") and separated ('B', "STRENGTH") formats

**SetCoefficient Method**:
- Updates coefficient values during statement execution
- Validates prefix and stat name existence
- Enforces read-only restrictions on S_ and T_ prefixed stats
- Provides debug output when MYDEBUG is enabled

---

## 3.5.5 Internal Processing Flow

Understanding how these classes work together in the HEL evaluation pipeline:

### 1. Tokenization Phase
```
Raw Equation String → HELLexer → List<Token>
```
- HELLexer breaks equation strings into Token objects
- Each Token contains type classification and parsed components
- Position information preserved for error reporting

### 2. Statement Parsing Phase
```
List<Token> → SplitStatements() → List<Statement>
```
- Tokens grouped into Statement objects at semicolon/line boundaries
- Dependency analysis extracts LHS and RHS variables
- Mod ID comments associate statements with source mods

### 3. Dependency Ordering Phase
```
List<Statement> → HELOrdering → Ordered execution groups
```
- Statements analyzed for circular dependencies
- Execution order determined to minimize dependency conflicts
- Statements grouped by cycle count for phased execution

### 4. Coefficient Evaluation Phase
```
Statement + CoefDict → ParseStatement() → Updated coefficients
```
- Each statement evaluated against current coefficient state
- Expression parsing uses coefficient values for variable resolution
- Assignment results update appropriate coefficient values

### 5. Final Application Phase
```
CoefDict → Apply() → Final modified statistics
```
- Accumulated coefficients applied to base stats
- Formula calculation produces final stat values
- Result statistics ready for game use

---

## 3.5.6 Debugging and Diagnostics

### Token Analysis
Use Token debug methods to understand lexical analysis:

```csharp
// Debug output shows: Type, Value, NumVal, Position
token.dump();
```

**Common Token Issues**:
- Unknown type for unrecognized syntax
- Incorrect prefix/variable parsing for malformed identifiers
- Position information helps locate problematic equation text

### Statement Inspection
Statement debug methods reveal parsing and dependency information:

```csharp
// Shows concatenated token values
string statementText = statement.dumpStr();

// Shows vertex coordinates for dependency tracking
string vertex = statement.dumpVertex();
```

**Statement Debugging**:
- Verify LHS and RHS variable extraction
- Check mod ID and position tracking
- Analyze dependency relationships for ordering issues

### Coefficient Monitoring
Monitor coefficient accumulation during evaluation:

```csharp
// Access current coefficient values
float currentValue = coefDict.GetCoefficient('B', "STRENGTH");

// Track coefficient changes (when MYDEBUG enabled)
coefDict.SetCoefficient("B_STRENGTH", newValue);
```

**Coefficient Diagnostics**:
- Verify coefficient accumulation across multiple mods
- Check final calculation inputs before Apply()
- Monitor intermediate values during complex evaluations

---

## 3.5.7 Integration Notes

**For HIOX Game Developers**:
- These internal classes are implementation details
- Use the public HEL class methods documented in [Section 3.1](3-1-HEL-Class-Reference.md)
- Internal class behavior may change between versions
- This documentation helps understand error messages and debug complex mod interactions

**Cross-Reference Sections**:
- [1.3 HEL Syntax](1-3-HEL-Syntax.md) - Token types and language structure
- [1.4 HEL Semantics](1-4-HEL-Semantics.md) - Statement evaluation rules
- [1.6 Dependency Resolution](1-6-Dependency-Resolution-Ordering.md) - Statement ordering logic
- [3.1 HEL Class Reference](3-1-HEL-Class-Reference.md) - Public API methods

**System Architecture**:
Understanding these internal classes provides insight into:
- How HEL equations are tokenized and parsed
- The coefficient-based stat modification system
- Dependency analysis and cycle resolution mechanisms
- Expression evaluation and stack-based computation
- Error handling and diagnostic information flow

---

# HEL Documentation Index

This index provides alphabetical access to concepts, terms, classes, and methods throughout the HEL documentation. References are provided as section numbers and paragraph indicators.

---

## A

**Add Coefficient (A_)** - Absolute additive modifiers applied after multiplication  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.5.2](1-5-Stat-Value-Computation.md) (Step-by-Step Process)  

**Alias Method** - O(1) weighted random selection algorithm  
→ [Section 2.4.3](2-4-HELPicker-Usage.md) (HELPicker Implementation)  
→ [Section 3.3.3](3-3-HELPicker-Class-Reference.md) (Algorithm Details)  

**ArgumentException** - Exception thrown for invalid mod equations  
→ [Section 2.2.4](2-2-HEL-Class-Usage.md) (Error Handling)  
→ [Section 3.1.5](3-1-HEL-Class-Reference.md) (Integration Guidelines)  

**Asset Files** - YAML and CSV data files containing mods and stats  
→ [Section 2.1.2.1](2-1-Integration-Overview.md) (Phase 1: Asset Loading at Game Startup)  
→ [Section 2.3.1](2-3-Asset-Management.md) (File Format Management)  
→ [Section 3.2.1](3-2-File-IO-Classes-Reference.md) (File I/O API)  

**Assignment Operators** - LHS variable assignment in HEL equations  
→ [Section 1.3.7](1-3-HEL-Syntax.md) (Assignment)  
→ [Section 1.4.3](1-4-HEL-Semantics.md) (Assignment Semantics)  

---

## B

**Base Coefficient (B_)** - Base additive modifiers applied before multiplication  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.5.2](1-5-Stat-Value-Computation.md) (Step-by-Step Process)  

**Base Stats** - Fundamental game statistics before modification  
→ [Section 1.1.3](1-1-Overview-Core-Concepts.md) (Core Concepts)  
→ [Section 1.2.1](1-2-Stats-SubStat-System.md) (Base Stats vs SubStats)  

---

## C

**Coefficient Application Formula** - `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`  
→ [Section 1.5.1](1-5-Stat-Value-Computation.md) (Core Formula)  
→ [Section 1.7.4](1-7-Language-Examples.md) (Advanced Math)  

**Coefficient Class** - Internal coefficient storage for stat modifications  
→ [Section 3.5.1](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**CoefDict Class** - Internal coefficient dictionary management  
→ [Section 3.5.1](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**CSV File Format** - Development-friendly asset file format  
→ [Section 2.3.2](2-3-Asset-Management.md) (Format Comparison)  
→ [Section 3.2.1](3-2-File-IO-Classes-Reference.md) (HELCSVFile API)  

**Cycle Detection** - Algorithm for identifying circular dependencies  
→ [Section 1.6.3](1-6-Dependency-Resolution-Ordering.md) (Cycle Detection)  
→ [Section 1.7.3](1-7-Language-Examples.md) (Dependency Cycles)  

---

## D

**Data Validation** - Asset file and parameter validation  
→ [Section 2.3.3](2-3-Asset-Management.md) (Validation Patterns)  
→ [Section 3.4.3](3-4-Data-Classes-Reference.md) (Data Validation)  

**Dependency Resolution** - Statement ordering for cycle resolution  
→ [Section 1.6.4](1-6-Dependency-Resolution-Ordering.md) (Resolution Strategies)  
→ [Section 1.4.1](1-4-HEL-Semantics.md) (Statement Evaluation)  

---

## E

**Error Handling** - Exception management and recovery strategies  
→ [Section 2.2.4](2-2-HEL-Class-Usage.md) (Error Handling Patterns)  
→ [Section 2.5.3](2-5-Common-Integration-Patterns.md) (Robustness Patterns)  
→ [Section 3.1.5](3-1-HEL-Class-Reference.md) (Integration Guidelines)  

**EvaluateEquation() Method** - Direct equation evaluation interface  
→ [Section 3.1.4](3-1-HEL-Class-Reference.md) (Direct Evaluation Method)  

**EvaluateMods() Method** - Primary HEL interface for mod evaluation  
→ [Section 2.2.1](2-2-HEL-Class-Usage.md) (Usage Patterns)  
→ [Section 3.1.2](3-1-HEL-Class-Reference.md) (Primary Interface)  

**Expression Evaluation** - Mathematical expression processing  
→ [Section 1.4.4](1-4-HEL-Semantics.md) (Expression Evaluation)  
→ [Section 1.7.4](1-7-Language-Examples.md) (Advanced Math)  

---

## F

**FormatFloat() Method** - Precision handling for float values  
→ [Section 3.1.2](3-1-HEL-Class-Reference.md) (Primary Interface)  

**Functions** - Built-in HEL functions (MIN, MAX, CEIL, FLOOR, RAND)  
→ [Section 1.3.6](1-3-HEL-Syntax.md) (Functions)  
→ [Section 1.4.4](1-4-HEL-Semantics.md) (Expression Evaluation)  

---

## H

**HEL Class** - Core equation evaluation engine  
→ [Section 2.2.1](2-2-HEL-Class-Usage.md) (Usage Guide)  
→ [Section 3.1.1](3-1-HEL-Class-Reference.md) (Overview)  

**HELCSVFile Class** - CSV file I/O operations  
→ [Section 2.3.2](2-3-Asset-Management.md) (Asset Management)  
→ [Section 3.2.1](3-2-File-IO-Classes-Reference.md) (API Reference)  

**HIOX Game Integration** - Unity game integration patterns  
→ [Section 2.1.2](2-1-Integration-Overview.md) (Typical HIOX Integration Workflow)  
→ [Section 2.5.1](2-5-Common-Integration-Patterns.md) (Integration Patterns)  

**HELInterpreter** - Internal equation interpreter  
→ [Section 3.5.2](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**HELLexer** - Internal tokenization engine  
→ [Section 3.5.2](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**HELOrdering** - Dependency analysis and cycle detection  
→ [Section 1.6.5](1-6-Dependency-Resolution-Ordering.md) (Execution Ordering)  
→ [Section 3.5](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**HELPicker Class** - Weighted random mod selection  
→ [Section 2.4.1](2-4-HELPicker-Usage.md) (Usage Guide)  
→ [Section 3.3.1](3-3-HELPicker-Class-Reference.md) (Complete API Reference)  

**HELYAMLFile Class** - Unity YAML file I/O operations  
→ [Section 2.3.1](2-3-Asset-Management.md) (Asset Management)  
→ [Section 3.2.1](3-2-File-IO-Classes-Reference.md) (API Reference)  

---

## I

**Integration Patterns** - Common integration scenarios and solutions  
→ [Section 2.5.1](2-5-Common-Integration-Patterns.md) (Complete Pattern Guide)  

**Internal Classes** - Implementation classes not for direct developer use  
→ [Section 3.5.1](3-5-Internal-Classes-Reference.md) (Internal Reference)  

**InvalidOperationException** - Runtime evaluation errors  
→ [Section 2.2.4](2-2-HEL-Class-Usage.md) (Error Handling)  
→ [Section 3.1.5](3-1-HEL-Class-Reference.md) (Integration Guidelines)  

---

## K

**KeyNotFoundException** - Exception for missing mod or stat references  
→ [Section 2.2.4](2-2-HEL-Class-Usage.md) (Error Handling)  
→ [Section 3.1.5](3-1-HEL-Class-Reference.md) (Integration Guidelines)  

**Keywords** - Reserved words in HEL language (AND, OR, NOT, TRUE, FALSE)  
→ [Section 1.3.5](1-3-HEL-Syntax.md) (Logical Operators)  

---

## L

**Language Examples** - Comprehensive HEL equation examples  
→ [Section 1.7.1](1-7-Language-Examples.md) (Simple Modifications)  

**LoadAsset() Method** - Asset file loading for both YAML and CSV  
→ [Section 3.2.2](3-2-File-IO-Classes-Reference.md) (File I/O Methods)  

**LHS Variables** - Left-hand side assignment targets in equations  
→ [Section 1.3.2](1-3-HEL-Syntax.md) (Variables)  
→ [Section 1.4.3](1-4-HEL-Semantics.md) (Assignment Semantics)  

---

## M

**Max Coefficient (U_)** - Maximum value adjustments  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.5.3](1-5-Stat-Value-Computation.md) (Range Clamping)  

**Min Coefficient (Z_)** - Minimum value adjustments  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.5.3](1-5-Stat-Value-Computation.md) (Range Clamping)  

**Mod Class** - Data structure representing game modifications  
→ [Section 3.4.1](3-4-Data-Classes-Reference.md) (Data Class Reference)  

**ModColor Class** - RGBA color representation for mods  
→ [Section 3.4.1](3-4-Data-Classes-Reference.md) (Data Class Reference)  

**Mod Inventory Management** - Player mod inventory patterns  
→ [Section 2.5.2](2-5-Common-Integration-Patterns.md) (Inventory Patterns)  

**ModsList Class** - Container for mod collections  
→ [Section 3.4.2](3-4-Data-Classes-Reference.md) (Container Classes)  

**Mult Coefficient (M_)** - Multiplicative modifiers (percentage-based)  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.5.2](1-5-Stat-Value-Computation.md) (Step-by-Step Process)  

---

## O

**Operators** - Mathematical, comparison, and logical operators  
→ [Section 1.3.3](1-3-HEL-Syntax.md) (Math Operators)  
→ [Section 1.4.4](1-4-HEL-Semantics.md) (Expression Evaluation)  

---

## P

**Performance Optimization** - Strategies for efficient HEL integration  
→ [Section 2.2.3](2-2-HEL-Class-Usage.md) (Performance Strategies)  
→ [Section 2.5.4](2-5-Common-Integration-Patterns.md) (Optimization Patterns)  

**Player Stats Component** - Unity component integration  
→ [Section 2.5.1](2-5-Common-Integration-Patterns.md) (Unity Integration)  

**PrepareEquation() Method** - Mod equation preprocessing  
→ [Section 3.1.3](3-1-HEL-Class-Reference.md) (Equation Processing Methods)  

---

## R

**Range Clamping** - Min/max value constraint application  
→ [Section 1.5.3](1-5-Stat-Value-Computation.md) (Range Clamping)  

**RHS Variables** - Right-hand side expression variables  
→ [Section 1.3.2](1-3-HEL-Syntax.md) (Variables)  
→ [Section 1.4.2](1-4-HEL-Semantics.md) (Variable Resolution)  

---

## S

**Sample() Method** - O(1) weighted random selection  
→ [Section 3.3.2](3-3-HELPicker-Class-Reference.md) (Sampling Method)  

**Start Coefficient (S_)** - Base stat starting values  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.5.2](1-5-Stat-Value-Computation.md) (Step-by-Step Process)  

**Stat Class** - Data structure representing game statistics  
→ [Section 3.4.1](3-4-Data-Classes-Reference.md) (Data Class Reference)  

**Statement Class** - Internal parsed statement representation  
→ [Section 3.5.3](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**StatsList Class** - Container for stat collections  
→ [Section 3.4.2](3-4-Data-Classes-Reference.md) (Container Classes)  

**SubStats** - Coefficient variants of base stats with prefixes  
→ [Section 1.1.3](1-1-Overview-Core-Concepts.md) (Core Concepts)  
→ [Section 1.2.2](1-2-Stats-SubStat-System.md) (SubStat Prefix System)  

**Syntax Reference** - Complete HEL language syntax  
→ [Section 1.3.1](1-3-HEL-Syntax.md) (Token Types)  

---

## T

**Token Class** - Internal lexical analysis tokens  
→ [Section 3.5.4](3-5-Internal-Classes-Reference.md) (Internal Classes)  

**TokenType Enum** - Classification of HEL tokens  
→ [Section 3.5.4](3-5-Internal-Classes-Reference.md) (Token Types)  

**Total Coefficient (T_)** - Final computed values (READ-ONLY)  
→ [Section 1.2.3](1-2-Stats-SubStat-System.md) (Coefficient Types Explained)  
→ [Section 1.3.2](1-3-HEL-Syntax.md) (Variables)  

---

## U

**Unity Integration** - HIOX Unity game integration patterns  
→ [Section 2.1.2](2-1-Integration-Overview.md) (Typical HIOX Integration Workflow)  
→ [Section 2.5.1](2-5-Common-Integration-Patterns.md) (Unity Components)  

---

## V

**VAL and VAL2 Substitution** - Mod value replacement in equations  
→ [Section 1.7.1](1-7-Language-Examples.md) (Simple Modifications)  
→ [Section 3.1](3-1-HEL-Class-Reference.md) (PrepareEquation Method)  

**Variable Resolution** - How variables are resolved during evaluation  
→ [Section 1.4.2](1-4-HEL-Semantics.md) (Variable Resolution)  

---

## W

**Weighted Random Selection** - Probability-based mod selection  
→ [Section 2.4.2](2-4-HELPicker-Usage.md) (Selection Algorithms)  
→ [Section 3.3.3](3-3-HELPicker-Class-Reference.md) (Alias Method)  

**WriteAsset() Method** - Asset file saving for both YAML and CSV  
→ [Section 3.2.3](3-2-File-IO-Classes-Reference.md) (File Writing Methods)  

---

## Y

**YAML File Format** - Unity-native asset file format  
→ [Section 2.3.1](2-3-Asset-Management.md) (Format Comparison)  
→ [Section 3.2.1](3-2-File-IO-Classes-Reference.md) (HELYAMLFile API)  

---

## Quick Reference

### Core Classes (Public API)
- **HEL** → [Section 3.1.1](3-1-HEL-Class-Reference.md)
- **HELPicker** → [Section 3.3.1](3-3-HELPicker-Class-Reference.md)  
- **HELYAMLFile** → [Section 3.2.1](3-2-File-IO-Classes-Reference.md)
- **HELCSVFile** → [Section 3.2.1](3-2-File-IO-Classes-Reference.md)

### Data Structures
- **Mod, Stat, ModColor** → [Section 3.4.1](3-4-Data-Classes-Reference.md)

### SubStat Prefixes
- **S_, B_, A_, M_, Z_, U_, T_** → [Section 1.2.3](1-2-Stats-SubStat-System.md)

### Integration Guides
- **Basic Integration** → [Section 2.1.1](2-1-Integration-Overview.md) & [Section 2.2.1](2-2-HEL-Class-Usage.md)
- **Advanced Patterns** → [Section 2.5.1](2-5-Common-Integration-Patterns.md)

### Language Reference
- **Syntax** → [Section 1.3.1](1-3-HEL-Syntax.md)
- **Examples** → [Section 1.7.1](1-7-Language-Examples.md)

### Additional Resources
- **Implementation Differences** → [Appendix](Appendix.md)
- **Migration Guidelines** → [Appendix](Appendix.md)

---

*This index covers all major concepts, classes, and methods in the HEL documentation suite. For additional detail on any topic, follow the section references provided.*

---

# Appendix: Implementation Differences and Design Decisions

This appendix documents key implementation differences between the original HIOX mod evaluation system and the enhanced HEL system, providing context for design decisions and migration considerations.

---

## A.1.1 Multiplicative Coefficient (M_) Implementation Change

### Background

A significant implementation difference exists between the original HIOX mod evaluation system and the current HEL interpreter regarding how multiplicative coefficients (M_ substats) are applied to stat calculations.

### Original HIOX Implementation

The original HIOX system used direct multiplication of accumulated M_ values:

```csharp
finalValue = (S + B) * M + A
```

**Behavior:**
- `M = 0.0` → multiplier = 0.0 → stat becomes 0 (complete nullification)
- `M = 0.5` → multiplier = 0.5 → stat reduced by 50%
- `M = 1.0` → multiplier = 1.0 → no change (baseline)
- `M = 1.5` → multiplier = 1.5 → stat increased by 50%

### Current HEL Implementation

The enhanced HEL system adds 1 to the accumulated M_ value before multiplication:

```csharp
finalValue = (S + B) * Max(0, 1 + M) + A
```

**Behavior:**
- `M = 0.0` → multiplier = 1.0 → no change (baseline)
- `M = 0.5` → multiplier = 1.5 → stat increased by 50%
- `M = 1.0` → multiplier = 2.0 → stat doubled
- `M = -0.5` → multiplier = 0.5 → stat reduced by 50%
- `M = -1.0` → multiplier = 0.0 → stat becomes 0 (complete nullification)

### Comparative Analysis

#### Semantic Clarity

**Original System Issues:**
- Counter-intuitive: `M = 0.1` appears to mean "+10%" but actually results in 90% stat reduction
- Baseline confusion: `M = 1.0` required for "no change" rather than `M = 0.0`
- Negative effects require fractional values between 0 and 1

**HEL System Advantages:**
- Intuitive: `M = 0.15` clearly means "+15% increase"
- Natural baseline: `M = 0.0` means "no change"
- Negative effects use negative values: `M = -0.2` means "-20% reduction"

#### Accumulation Behavior

When multiple mods affect the same M_ substat, values are accumulated before multiplication:

**Example: Two "+20%" damage mods**

*Original System:*
```
Mod 1: M_DAMAGE = M_DAMAGE 1.2 +
Mod 2: M_DAMAGE = M_DAMAGE 1.2 +
Total: M_DAMAGE = 2.4 → 140% increase (unintuitive)
```

*HEL System:*
```
Mod 1: M_DAMAGE = M_DAMAGE 0.2 +
Mod 2: M_DAMAGE = M_DAMAGE 0.2 +  
Total: M_DAMAGE = 0.4 → 40% increase (intuitive)
```

#### Edge Case Handling

**Original System Problems:**
1. **Accidental nullification**: Small M_ values can accidentally multiply to near-zero
2. **No negative protection**: Nothing prevents negative multipliers
3. **Unintuitive compounding**: Multiple percentage mods don't behave as expected

**HEL System Solutions:**
1. **Negative protection**: `Max(0, 1 + M)` prevents negative multipliers
2. **Clear boundaries**: `M = -1` creates complete nullification, no accidental zeros
3. **Natural accumulation**: Multiple percentage mods add linearly before application

### Migration Considerations

#### Converting Existing Mod Equations

Mods designed for the original system require equation updates:

```csharp
// Conversion formula: originalM → newM
float ConvertMValue(float originalM) 
{
    return originalM - 1.0f;
}

// Example conversions:
// Original: M_DAMAGE = M_DAMAGE 1.25 +  (25% increase)
// New:      M_DAMAGE = M_DAMAGE 0.25 +  (25% increase)

// Original: M_DEFENSE = M_DEFENSE 0.8 +  (20% decrease)  
// New:      M_DEFENSE = M_DEFENSE -0.2 + (20% decrease)
```

#### Equation Pattern Changes

**Original Patterns:**
```
// +50% health boost
M_HEALTH = M_HEALTH 1.5 +

// -30% speed penalty  
M_SPEED = M_SPEED 0.7 +
```

**HEL Patterns:**
```
// +50% health boost
M_HEALTH = M_HEALTH 0.5 +

// -30% speed penalty
M_SPEED = M_SPEED -0.3 +
```

### Design Decision Rationale

#### Why the HEL System is Superior

1. **Industry Standard**: Modern games universally use additive percentage systems
2. **Intuitive Design**: Mod creators can easily understand and predict effects
3. **Robust Behavior**: Edge cases are handled gracefully with clear boundaries
4. **Maintainable**: Equations are self-documenting and less error-prone
5. **Flexible**: Both positive and negative effects use natural value ranges

#### Recommendation

**The current HEL implementation should be retained.** The `(1 + M)` formula provides:

- **Clearer semantics** for mod designers
- **More predictable behavior** for complex mod combinations  
- **Better edge case handling** with built-in safety mechanisms
- **Alignment with industry standards** and player expectations

While this creates a breaking change from the original HIOX system, the long-term benefits of intuitive, robust multiplicative coefficient handling significantly outweigh the migration costs.

#### Implementation Note

The `Max(0, 1 + M)` formulation in the current system also prevents negative multipliers, ensuring that extreme negative M_ values cannot create nonsensical negative stat results. This fail-safe behavior is crucial for maintaining game balance even when mod equations contain errors or extreme values.

---

## A.1.2 Cross-References

- **[Section 1.2 - Stats and SubStat System](1-2-Stats-SubStat-System.md)**: SubStat prefix definitions and M_ coefficient explanation
- **[Section 1.5 - Stat Value Computation](1-5-Stat-Value-Computation.md)**: Complete coefficient application formula
- **[Section 2.2 - HEL Class Usage](2-2-HEL-Class-Usage.md)**: Practical mod evaluation examples
- **[Section 3.1 - HEL Class Reference](3-1-HEL-Class-Reference.md)**: EvaluateMods() method documentation

---

**Next Section:** [Table of Contents](Table-of-Contents.md)  
**Previous Section:** [Index](Index.md)