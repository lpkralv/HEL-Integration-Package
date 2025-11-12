# HEL System Analysis
## Understanding the Current HIOX Stats and Mods System

### Executive Summary

The HEL (HIOX Equation Language) system is a sophisticated coefficient-based stat modification engine that enables complex, interdependent mod effects in the HIOX game. This document captures key learnings about the system's architecture, design patterns, and capabilities that are essential for creating new Stats and Mods.

---

## 1. Core Architecture

### 1.1 System Components

The HEL system consists of four primary components:

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
   - Implements coefficient-based calculation
   - Handles dependency ordering and cycle resolution

4. **HELOrdering.cs** - Analyzes statement dependencies and cycle detection
   - Uses DFS algorithm to find circular dependencies
   - Groups statements by cycle membership count
   - Enables proper execution order for complex mod interactions

### 1.2 Data Models

#### Mod Class
Represents game modifications with the following key properties:
- `modid` (int) - Unique identifier
- `uuid` (string) - Unique instance identifier
- `val` / `val2` (float) - Primary and secondary values
- `val1min`, `val1max`, `val2min`, `val2max` (float) - Value ranges
- `name` (string) - Display name
- `desc` (string) - Description
- `modweight` (int) - Weight/priority for ordering
- `type` (int) - Type identifier (0=nanite injection, 2=weapon, 4=melee, 10=nanite, 20=base)
- `hasProc` (int) - Whether mod has special process
- `equation` (string) - HEL equation string
- `modColor` (ModColor) - Visual representation
- `armorEffectName` (string) - Armor effect name
- `armorMeshName` (string) - Armor mesh name

#### Stat Class
Represents game statistics with:
- `name` (string) - Stat identifier
- `desc` (string) - Description
- `value` (float) - Current value
- `min` (float) - Minimum allowable value
- `max` (float) - Maximum allowable value

---

## 2. The SubStat Coefficient System

### 2.1 Coefficient Types

HEL uses a prefix-based system to categorize different types of stat modifications:

| Prefix | Name | Purpose | Read/Write |
|--------|------|---------|------------|
| **S_** | Start | Base stat starting values from StatsData.asset | Read-only |
| **B_** | Base | Base additive modifiers (applied before multiplication) | Read/Write |
| **A_** | Add | Absolute additive modifiers (applied after multiplication) | Read/Write |
| **M_** | Mult | Multiplicative modifiers (percentage-based, 0.1 = +10%) | Read/Write |
| **Z_** | Min | Minimum value adjustments | Read/Write |
| **U_** | Max | Maximum value adjustments | Read/Write |
| **T_** | Total | Final computed values (calculated by system) | Read-only |

### 2.2 The Core Computation Formula

All coefficient modifications are combined using this formula:

```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

**Step-by-step process:**
1. **Base Value**: `S + B` (original + base additive)
2. **Apply Multiplier**: `base_value * Max(0, 1 + M)` (percentage modification)
3. **Add Absolute**: `multiplied_value + A` (flat bonus after multiplication)
4. **Apply Min Constraint**: `Max(modified_value, min + Z)` (enforce lower bound)
5. **Apply Max Constraint**: `Min(constrained_min, max + U)` (enforce upper bound)

### 2.3 Key Insights

**B_ vs A_ Power Differential:**
- B_ modifiers are more powerful than A_ modifiers because they're multiplied
- Example: Base=100, Multiplier=20%
  - B_=50 → (100+50)×1.2 = 180
  - A_=50 → 100×1.2+50 = 170

**Multiplicative Stacking:**
- Multiple M_ coefficients from different mods are additive
- M_=0.1 + M_=0.2 = 30% total increase (not 1.1 × 1.2)

**Safety Features:**
- Negative multipliers are clamped to 0 to prevent negative stats
- Z_ and U_ allow extending stat ranges beyond default min/max

---

## 3. HEL Language Features

### 3.1 Supported Operations

**Mathematical Operators:**
- `+` Addition
- `-` Subtraction
- `*` Multiplication
- `/` Division
- `^` Exponentiation

**Comparison Operators:**
- `==` Equal
- `!=` Not equal
- `<` Less than
- `<=` Less than or equal
- `>` Greater than
- `>=` Greater than or equal

**Logical Operators:**
- `AND` Logical and
- `OR` Logical or
- `NOT` Logical not

**Built-in Functions:**
- `MIN(a, b)` Minimum of two values
- `MAX(a, b)` Maximum of two values
- `CEIL(x)` Ceiling function
- `FLOOR(x)` Floor function
- `RAND()` Random value

### 3.2 Variable Substitution

Mod equations can reference placeholders:
- `VAL` or `VAL1` - Replaced with `mod.val`
- `VAL2` - Replaced with `mod.val2`

Example equation: `M_GUNDAMAGE=-val1;M_PROCRATE=val2`
With val=0.43, val2=1.86 becomes: `M_GUNDAMAGE=-0.43;M_PROCRATE=1.86`

### 3.3 Dependency Resolution

**Key Features:**
- Automatic detection of circular dependencies
- DFS-based cycle detection algorithm
- Proper execution ordering for interdependent equations
- Prevents infinite loops and calculation errors

---

## 4. Current Stats Analysis

### 4.1 Existing Stats Categories

**Movement Stats:**
- PLAYERSPEED (130 base)
- SPRINTSPEED (100 base)
- SWIMSPEED (30 base)
- JUMPSTRENGTH (750 base)
- GRAVITY (-9.81 base)

**Survival Stats:**
- HP (100 base, min 0, max 5000)
- HPREGEN (0.002 base)
- MAXSTAMINA (100 base)
- STAMINAREGEN (12 base)
- SPRINTCOST (40 base)
- DODGECOST (70 base)
- ARMOR (0 base)
- PLATES (0 base)

**Combat Stats - Ranged:**
- GUNDAMAGE (10 base)
- SHOTSPERSEC (2 base)
- BULLETSPEED (400 base)
- ACCURACY (0.5 base, max 1)
- BULLETSFIRED (1 base)
- PROJECTILEKNOCKBACK (100 base)

**Combat Stats - Melee:**
- MELEEDAMAGE (100 base)
- MELEERANGE (9 base)
- MELEESPEED (1 base)

**Proc/Effect Stats:**
- PROCRATE (1 base)
- PROCRANGE (50 base)
- BULLETSPLIT (0 base)
- ADDEDSHATTERBULLETS (0 base)
- IGNITECHANCE (0 base)
- IGNITEDAMAGE (0 base)
- CHARGECHANCE (0 base)
- CHARGEDAMAGE (0 base)
- CORRUPTIONSPREADCHANCE (0 base)

**Resistance Stats:**
- FIRERESISTANCE (0 base)
- ELECTRICRESISTANCE (0 base)
- CORRUPTIONRESISTANCE (0 base)

**Special Stats:**
- NUMMINIONS (0 base)
- MINIONTYPE (0 base)
- AUTOTURRETON (0 base)
- EXPLOSIONRADIUS (5 base)
- FREENITES (0 base - currency)

**Total: 39 base stats**

### 4.2 Stat Design Patterns

1. **Range Flexibility**: Most stats have min=0, max=5000 for flexibility
2. **Percentage Values**: Some stats (ACCURACY, HPREGEN) use 0-1 range for percentages
3. **Binary Flags**: AUTOTURRETON uses 0/1 for boolean states
4. **Negative Values**: GRAVITY allows negative values (min=-5000)

---

## 5. Current Mods Analysis

### 5.1 Mod Types

Based on `type` field:
- **Type 0**: Nanite Injections (stat modifiers)
- **Type 2**: Weapons (gun modifications)
- **Type 4**: Melee weapons
- **Type 10**: Basic nanite upgrades
- **Type 20**: Starting/base stats

### 5.2 Mod Categories

**Trade-off Mods** (reduce one stat, increase another):
- LIGHTWEIGHT LUCKYSHOT NANITES: -gun damage, +proc rate
- HEAVY LUCKYSHOT NANITES: -fire rate, +proc rate
- QUICKSHOT NANITES: -proc rate, +fire rate
- STEELSHOT NANITES: -proc rate, +gun damage
- TRUESHOT NANITES: -proc rate, +accuracy

**Pure Benefit Mods:**
- MOON ATTUNED NANITES: Decrease gravity effects
- STEELSTRETCH NANITES: Increase melee range
- Various basic stat nanites (Type 10)

**Complex Effect Mods:**
- SHATTERSHOT NANITES: Bullet splitting mechanic
- THERMITE CORE NANITES: Fire DoT effect
- TESLA CORE NANITES: Electric chain damage
- KINETIKCELL NANITES: Transfer gun damage to melee
- SHARPCELL NANITES: Transfer melee damage to gun

**Weapon Mods** (Type 2):
- STANDARD GUN (base weapon)
- SHOTGUN (multi-projectile burst)
- SNIPER (high damage, perfect accuracy, slow fire rate)
- MACHINE GUN (high fire rate, reduced damage)
- GRENADE LAUNCHER (explosive radius)
- AUTO-TURRET (shoulder mounted)
- SHARD CUBE (random projectiles)
- CHARGE LASER (charge mechanic)
- ENERGY BUBBLER (bubble explosions)
- CORRUPTING VIRUS (DoT spread mechanic)
- HIOX-029 HOME BEACON (minions)
- ETCHING LASER (instant hit)

### 5.3 Mod Design Patterns

**Balance Through Trade-offs:**
- Most powerful effects have negative modifiers
- Creates strategic choices for players
- Example: CORRUPTING VIRUS has high proc rate but reduced damage

**Value Ranges:**
- `val1min` to `val1max` defines randomization range
- Allows same mod to have different roll quality
- Creates item hunting/loot excitement

**Equation Complexity:**
- Simple mods: Single coefficient modification
- Complex mods: Multiple interdependent modifications
- Advanced mods: Cross-stat calculations

**Weight System:**
- `modweight` determines drop rarity
- Lower weight = rarer drops
- Balance between power and accessibility

---

## 6. Key Design Principles

### 6.1 Stateless Evaluation
- All methods are static
- No state retained between calls
- Enables thread safety and performance

### 6.2 Coefficient Accumulation
- Modifications accumulate in coefficient objects
- Final application happens after all mods processed
- Prevents order-dependent calculations

### 6.3 Dependency Resolution
- Complex mod interactions resolved through cycle analysis
- Ensures consistent evaluation regardless of mod order
- Prevents infinite loops

### 6.4 Type Safety
- Strong typing with dictionaries
- `statsDictionary` and `modsDictionary` type aliases
- Clear data contracts between components

---

## 7. Opportunities for New Design

### 7.1 Underutilized Features

**Z_ and U_ Coefficients:**
- Current mods rarely use min/max adjustments
- Could enable "break the limits" type effects
- Example: "Removes HP cap" (U_HP = 9999)

**Cross-Stat Dependencies:**
- Few mods currently reference other stats
- Opportunity for synergistic builds
- Example: "Gain damage based on speed"

**Conditional Logic:**
- Comparison and logical operators available but underused
- Could create threshold-based effects
- Example: "If HP > 50%, gain attack speed"

**Mathematical Functions:**
- MIN, MAX, CEIL, FLOOR, RAND available
- Could create unique mechanical effects
- Example: "Random buff on attack"

### 7.2 Missing Stat Categories

**Temporal Effects:**
- No duration-based stats
- No cooldown reduction stats
- No time manipulation

**Resource Management:**
- Only stamina and HP exist
- Could add energy, mana, charges

**Advanced Combat:**
- No crit chance/damage
- No armor penetration
- No lifesteal/leech

**Utility:**
- No detection range
- No pickup radius
- No luck/rarity stats

### 7.3 Potential New Mod Types

Based on lore and game mechanics:
- Nanite enhancement levels
- Beacon-specific upgrades
- Environmental adaptation
- Enemy-type specific bonuses
- Combo/chain mechanics
- Resource conversion systems

---

## 8. Technical Constraints

### 8.1 File Formats
- YAML format for Unity asset files
- Specific structure required for ModsData.asset and StatsData.asset
- Must maintain compatibility with Unity serialization

### 8.2 Equation Limitations
- Equations must be valid HEL syntax
- Cannot reference non-existent stats
- S_ and T_ variables are read-only
- Must avoid circular dependencies (or handle them properly)

### 8.3 Performance Considerations
- Large numbers of mods can impact evaluation time
- Complex dependency chains increase computation
- Should balance power with calculation efficiency

---

## 9. Conclusions

### 9.1 System Strengths
- Highly flexible coefficient-based design
- Strong mathematical foundation
- Supports complex interactions
- Safe from infinite loops and errors
- Extensible architecture

### 9.2 Design Space
The current system has significant room for expansion:
- Only 39 base stats (could easily add 50-100+ more)
- Many HEL language features underutilized
- Coefficient system enables sophisticated effects
- Lore provides rich context for new additions

### 9.3 Next Steps
1. Research Path of Exile's mod system for inspiration
2. Design new stat categories aligned with HIOX lore
3. Create balanced mod progressions
4. Implement synergistic combinations
5. Test for mathematical stability and game balance

---

**Document Version:** 1.0
**Created:** 2025-11-12
**Purpose:** Foundation for new Stats/Mods design project
