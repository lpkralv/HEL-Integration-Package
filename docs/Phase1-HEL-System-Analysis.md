# Phase 1: HEL System Analysis

## Current HEL Stats/Mods System Overview

### Architecture Summary

The HEL (HIOX Equation Language) system is a sophisticated coefficient-based stat modification engine designed for Unity integration. It provides a mathematical equation evaluator that transforms mod definitions into dynamic stat modifications.

### Core Components

#### 1. **Stat Class** (HELAssetDefs.cs)
Represents player characteristics with:
- `name` - Unique identifier (e.g., "HP", "PLAYERSPEED")
- `desc` - Human-readable description
- `value` - Base numeric value
- `min/max` - Allowable value constraints

**Current Stats (38 total):**
- **Movement**: PLAYERSPEED, SPRINTSPEED, SWIMSPEED, JUMPSTRENGTH, GRAVITY
- **Health/Defense**: HP, HPREGEN, MAXSTAMINA, STAMINAREGEN, ARMOR, PLATES
- **Stamina Costs**: SPRINTCOST, DODGECOST
- **Ranged Combat**: GUNDAMAGE, SHOTSPERSEC, BULLETSPEED, ACCURACY, BULLETSFIRED, PROJECTILEKNOCKBACK
- **Melee Combat**: MELEEDAMAGE, MELEERANGE, MELEESPEED
- **Proc Effects**: PROCRATE, PROCRANGE
- **Elemental Effects**: IGNITECHANCE, IGNITEDAMAGE, CHARGECHANCE, CHARGEDAMAGE, CORRUPTIONSPREADCHANCE
- **Special Effects**: BULLETSPLIT, ADDEDSHATTERBULLETS, EXPLOSIONRADIUS
- **Minions**: NUMMINIONS, MINIONTYPE
- **Resistances**: FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE
- **Misc**: AUTOTURRETON, FREENITES (currency)

#### 2. **Mod Class** (HELAssetDefs.cs)
Represents game modifications/items with:
- `modid` - Unique identifier
- `uuid` - Unique instance identifier
- `name/desc` - Display information
- `val/val2` - Primary/secondary numeric values with min/max ranges
- `equation` - HEL expression string defining stat modifications
- `type` - Mod classification
- `modweight` - Weight for random selection
- `armorEffectName/armorMeshName` - Visual properties

**Current Mod Types:**
- **Type 0**: Nanite injections (passive stat modifiers)
- **Type 2**: Weapons (gun modifications)
- **Type 4**: Melee weapons
- **Type 10**: Common nanite bonuses
- **Type 20**: Starting/base upgrades

**Current Mods (45 total):**
- Passive nanites (11): Trade-off mods (e.g., lower damage for higher proc rate)
- Weapons (12): SHOTGUN, SNIPER, MACHINE GUN, GRENADE LAUNCHER, AUTO-TURRET, SHARD CUBE, CHARGE LASER, CORRUPTING VIRUS, minion beacons, etc.
- Common nanites (11): Simple stat boosts (fire rate, damage, speed, HP, armor)
- Starting upgrades (11): Permanent base stat increases

#### 3. **SubStat Coefficient System**

HEL uses a sophisticated coefficient system rather than direct stat modification. Each stat has multiple SubStat coefficients:

**SubStat Prefixes:**
- **S_** (Start): Base starting values from StatsData.asset
- **B_** (Base): Additive modifiers applied before multiplication
- **A_** (Add): Absolute additive modifiers applied after multiplication
- **M_** (Mult): Multiplicative percentage modifiers (0.1 = +10%)
- **Z_** (Min): Minimum value adjustments
- **U_** (Max): Maximum value adjustments
- **T_** (Total): Final computed values (read-only)

**Final Computation Formula:**
```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

#### 4. **HEL Language** (HEL.cs, HELLexer.cs, HELInterpreter.cs)

**Equation Format:**
```
M_GUNDAMAGE=-val1;M_PROCRATE=val2
```

**Features:**
- Variable substitution (VAL, VAL1, VAL2 → actual mod values)
- Mathematical operators: `+`, `-`, `*`, `/`, `^`
- Comparison operators: `==`, `!=`, `<`, `<=`, `>`, `>=`
- Logical operators: `AND`, `OR`, `NOT`
- Functions: `MIN`, `MAX`, `CEIL`, `FLOOR`, `RAND`
- Dependency resolution with cycle detection

**Evaluation Pipeline:**
1. PrepareEquation() - Substitute VAL/VAL1/VAL2 with actual values
2. HELLexer.Tokenize() - Parse equation into tokens
3. HELOrdering - Analyze dependencies and resolve execution order
4. HELInterpreter.Interpret() - Execute statements, update coefficients
5. Apply final computation formula to get stat values

#### 5. **HELOrdering.cs** - Dependency Resolution
- Uses DFS algorithm for cycle detection
- Groups statements by cycle membership count
- Enables proper execution order for complex mod interactions

### Design Patterns

1. **Stateless Evaluation**: All methods are static, no state retained between calls
2. **Coefficient Accumulation**: Modifications accumulate in coefficient objects before final application
3. **Dependency Resolution**: Complex mod interactions resolved through cycle analysis
4. **Type Safety**: Strong typing with dictionaries keyed by stat/mod names

### Current Mod Design Patterns

#### Trade-off Mods
Mods that boost one stat while reducing another:
- LIGHTWEIGHT LUCKYSHOT NANITES: -43% gun damage, +186% proc rate
- HEAVY LUCKYSHOT NANITES: -59% fire rate, +99% proc rate
- QUICKSHOT NANITES: -50% proc rate, +123% fire rate

#### Special Effect Mods
- SHATTERSHOT NANITES: 39% chance bullets split into 1.26 more bullets
- THERMITE CORE: 10% ignite chance, 218% bullet damage as fire DoT
- TESLA CORE: 100% charge chance, 18% bullet damage as electric DoT

#### Cross-stat Dependencies
- KINETIKCELL NANITES: 297% of gun base damage added to melee
- SHARPCELL NANITES: 75% of melee base damage added to gun

#### Weapon Transformations
Complete weapon replacements with complex stat modifications:
- SHOTGUN: +7.8 bullets, -200% accuracy, -2% fire rate
- SNIPER: +142% damage, perfect accuracy, -63% fire rate, piercing
- CORRUPTING VIRUS: Slow virus cloud with spread mechanics

### Key Insights for New Design

1. **Flexibility**: The coefficient system allows for extremely flexible stat modifications
2. **Complex Synergies**: Mods can reference other stats, creating build synergies
3. **Balance through Trade-offs**: Best mods have significant downsides
4. **Build Diversity**: Different weapon types encourage different playstyles
5. **Nanite Theme**: All items are nanite-based (injections, cores, etc.)
6. **Limited Crafting**: No crafting system currently exists
7. **Simple Rarity**: No explicit rarity tiers in mod definitions
8. **Proc System**: Central mechanic for special effects (ignite, charge, corruption)
9. **Minion Support**: System exists but limited (1 minion type)
10. **Resistance System**: Basic elemental resistance stats exist but underutilized

### Gaps and Opportunities

1. **No crafting system** - Unlike PoE
2. **No rarity tiers** - All mods are essentially "unique"
3. **Limited mod pools** - Only 45 mods total
4. **Underutilized mechanics**:
   - Resistance system exists but few mods interact with it
   - Minion system exists but only 1 minion type
   - Z_/U_ (min/max) coefficients rarely used
5. **Limited build archetypes** - Few mods support specialized builds
6. **No mod scaling** - Mods have fixed value ranges
7. **No conditional effects** - Few mods with complex conditions
8. **Limited visual variety** - Most mods are nanite injections

### Technical Capabilities Available

The HEL system can support:
- Multi-stat dependencies
- Conditional logic in equations
- Mathematical functions
- Complex proc mechanics
- Min/max constraint modifications
- Coefficient-based scaling
- Random value generation
- Cycle-safe dependency resolution

This provides a powerful foundation for creating sophisticated mod interactions and build diversity.
