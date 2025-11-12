# Foundation HEL Capability Reference Guide

**Purpose:** This guide defines what HEL can and cannot do, providing creative subagents with the technical boundaries needed to design feasible mods.

**Audience:** Creative subagents designing mods, stats, and game mechanics using HEL.

---

## Section 1: Core HEL Concepts

### 1.1 SubStat Coefficient System

HEL uses a **coefficient-based system** rather than direct stat modification. Each base stat (like HP, GUNDAMAGE, PLAYERSPEED) has multiple SubStat coefficients that control different aspects of modification.

**SubStat Prefixes:**

| Prefix | Name | Purpose | Assignable? |
|--------|------|---------|-------------|
| **S_** | Start | Base stat starting values from StatsData.asset | READ-ONLY |
| **B_** | Base | Additive modifiers applied BEFORE multiplication | YES |
| **A_** | Add | Absolute additive modifiers applied AFTER multiplication | YES |
| **M_** | Mult | Multiplicative percentage modifiers (0.1 = +10%) | YES |
| **Z_** | Min | Minimum value adjustments (extends lower bound) | YES |
| **U_** | Max | Maximum value adjustments (extends upper bound) | YES |
| **T_** | Total | Final computed values after all mods applied | READ-ONLY |

**Key Points:**
- **S_** values are always reset to StatsData.asset values at the start of evaluation
- **T_** values are calculated by the system and represent the final result
- **B_, A_, M_, Z_, U_** are the coefficients you modify in mod equations
- Multiple mods can modify the same coefficient - values are accumulated (added together)

**Example SubStat Variables:**
```
S_HP = 100        // Base HP from StatsData.asset (read-only)
B_HP = 50         // Add 50 to base HP (before multiplication)
M_HP = 0.2        // +20% HP multiplier
A_HP = 25         // Add 25 HP after multiplication
Z_HP = 10         // Raise minimum HP to 10
U_HP = 500        // Raise maximum HP by 500
T_HP = ???        // Final calculated HP (read-only)
```

### 1.2 Final Computation Formula

All coefficients combine using this formula to produce the final stat value:

```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

**Where:**
- `S` = Starting value from StatsData.asset
- `B` = Base additive coefficient (applied before multiplication)
- `M` = Multiplicative coefficient (0.15 = +15%)
- `A` = Absolute additive coefficient (applied after multiplication)
- `min`, `max` = Original stat constraints from StatsData.asset
- `Z` = Minimum adjustment coefficient
- `U` = Maximum adjustment coefficient

**Order of Operations:**
1. Add B to S: `(S + B)`
2. Apply M multiplier: `* Max(0, 1 + M)`
3. Add A: `+ A`
4. Clamp to minimum: `Max(..., min + Z)`
5. Clamp to maximum: `Min(..., max + U)`

### 1.3 Worked Examples

**Example 1: Simple Additive Mod**
```
Base Stat: HP = 100 (min=0, max=1000)
Mod Equation: B_HP = B_HP + 50

Calculation:
S = 100, B = 50, M = 0, A = 0, Z = 0, U = 0
Final = Min(Max((100 + 50) * Max(0, 1 + 0) + 0, 0 + 0), 1000 + 0)
      = Min(Max(150 * 1 + 0, 0), 1000)
      = Min(Max(150, 0), 1000)
      = 150
```

**Example 2: Multiplicative Mod**
```
Base Stat: GUNDAMAGE = 20 (min=0, max=1000)
Mod Equation: M_GUNDAMAGE = M_GUNDAMAGE + 0.25

Calculation:
S = 20, B = 0, M = 0.25, A = 0, Z = 0, U = 0
Final = Min(Max((20 + 0) * Max(0, 1 + 0.25) + 0, 0 + 0), 1000 + 0)
      = Min(Max(20 * 1.25, 0), 1000)
      = 25
```

**Example 3: Combined Coefficients**
```
Base Stat: HP = 100 (min=0, max=1000)
Mod 1: B_HP = B_HP + 50
Mod 2: M_HP = M_HP + 0.2
Mod 3: A_HP = A_HP + 30

Accumulated Coefficients:
S = 100, B = 50, M = 0.2, A = 30, Z = 0, U = 0

Calculation:
Final = Min(Max((100 + 50) * Max(0, 1 + 0.2) + 30, 0 + 0), 1000 + 0)
      = Min(Max(150 * 1.2 + 30, 0), 1000)
      = Min(Max(180 + 30, 0), 1000)
      = 210

Note: The B_ bonus (50) is amplified by M_ (20%), then A_ is added flat.
```

**Example 4: Negative Multiplier**
```
Base Stat: SHOTSPERSEC = 5 (min=0, max=100)
Mod Equation: M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.63)

Calculation:
S = 5, B = 0, M = -0.63, A = 0, Z = 0, U = 0
Final = Min(Max((5 + 0) * Max(0, 1 + (-0.63)) + 0, 0 + 0), 100 + 0)
      = Min(Max(5 * Max(0, 0.37), 0), 100)
      = Min(Max(5 * 0.37, 0), 100)
      = 1.85

Note: Max(0, 1 + M) prevents negative multipliers from making stats negative.
```

**Example 5: Minimum Adjustment**
```
Base Stat: HP = 100 (min=0, max=1000)
Mod Equation: Z_HP = Z_HP + 50

Calculation:
S = 100, B = 0, M = 0, A = 0, Z = 50, U = 0
Final = Min(Max((100 + 0) * 1 + 0, 0 + 50), 1000 + 0)
      = Min(Max(100, 50), 1000)
      = 100

If player takes damage reducing HP below 50, they can't go below 50 HP.
```

### 1.4 VAL/VAL1/VAL2 Substitution

Every mod has two numeric values: `val` (also accessible as `val1`) and `val2`. These are placeholders in equation strings that get substituted with actual values before evaluation.

**In Mod Definition:**
```yaml
modid: 0
name: LIGHTWEIGHT LUCKYSHOT NANITES
val: 0.435     # First value
val2: 1.863    # Second value
equation: M_GUNDAMAGE=-val1;M_PROCRATE=val2
```

**After Substitution (before evaluation):**
```
M_GUNDAMAGE=-0.435;M_PROCRATE=1.863
```

**Substitution Rules:**
- `VAL` and `VAL1` both substitute to the mod's `val` field
- `VAL2` substitutes to the mod's `val2` field
- Substitution happens before tokenization and evaluation
- Case-insensitive: `val`, `VAL`, `Val` all work

**Example:**
```
Equation: B_HP = B_HP + VAL; M_GUNDAMAGE = M_GUNDAMAGE + VAL2
With val=50, val2=0.25
Becomes: B_HP = B_HP + 50; M_GUNDAMAGE = M_GUNDAMAGE + 0.25
```

---

## Section 2: What HEL CAN Do ✅

### 2.1 Cross-Stat Dependencies

HEL can read one stat's coefficient and use it to modify another stat.

**Example 1: Convert Gun Damage to Melee Damage**
```
A_MELEEDAMAGE = B_GUNDAMAGE val1 *
```
- Reads B_GUNDAMAGE (base gun damage coefficient)
- Multiplies it by val1 (e.g., 0.5 for 50% conversion)
- Adds result to A_MELEEDAMAGE (absolute additive melee damage)

**Example 2: HP-Based Damage Boost**
```
M_GUNDAMAGE = M_GUNDAMAGE + (T_HP 200 >) val1 *
```
- If T_HP (current HP) > 200, adds val1 to M_GUNDAMAGE
- If T_HP <= 200, adds 0 to M_GUNDAMAGE
- Creates a high-health damage bonus

**Example 3: Symmetric Synergy**
```
A_MELEEDAMAGE = B_GUNDAMAGE 0.5 *
A_GUNDAMAGE = B_MELEEDAMAGE 0.5 *
```
- 50% of base gun damage added to melee
- 50% of base melee damage added to gun
- Both combat styles benefit from investing in either

### 2.2 Mathematical Functions

**MIN(a, b) - Returns smaller value**
```
// Cap damage bonus at 50%
M_GUNDAMAGE = M_GUNDAMAGE + MIN(0.5, T_PLAYERSPEED 100 /)

Example: If speed is 300
= MIN(0.5, 300/100) = MIN(0.5, 3.0) = 0.5 (capped)
```

**MAX(a, b) - Returns larger value**
```
// Ensure at least 10% fire rate boost
B_SHOTSPERSEC = B_SHOTSPERSEC + MAX(0.1, val1)

Example: If val1 = 0.05
= MAX(0.1, 0.05) = 0.1 (minimum enforced)
```

**CEIL(x) - Rounds up**
```
// Round up fractional bullets
B_BULLETSFIRED = B_BULLETSFIRED + T_GUNDAMAGE 10 / CEIL

Example: If T_GUNDAMAGE = 27
= CEIL(27/10) = CEIL(2.7) = 3
```

**FLOOR(x) - Rounds down**
```
// Round down bonus damage
A_GUNDAMAGE = A_GUNDAMAGE + T_HP 50 / FLOOR

Example: If T_HP = 137
= FLOOR(137/50) = FLOOR(2.74) = 2
```

**RAND - Random 0-1**
```
// Random proc rate bonus between 0-50%
M_PROCRATE = M_PROCRATE + RAND 0.5 *

Note: RAND generates a new random value each time evaluated
```

### 2.3 Boolean Conditionals as Math

Comparison operators return **1.0 if true, 0.0 if false**. Multiply by desired bonus.

**Available Operators:**
- `<` less than
- `<=` less than or equal
- `>` greater than
- `>=` greater than or equal
- `==` equal
- `!=` not equal

**Example 1: Low HP Damage Boost**
```
M_GUNDAMAGE = M_GUNDAMAGE + (T_HP 100 <) 0.5 *

When T_HP < 100:
= M_GUNDAMAGE + (1.0) * 0.5 = M_GUNDAMAGE + 0.5 (+50% damage)

When T_HP >= 100:
= M_GUNDAMAGE + (0.0) * 0.5 = M_GUNDAMAGE + 0 (no bonus)
```

**Example 2: High Stamina Movement Bonus**
```
M_PLAYERSPEED = M_PLAYERSPEED + (T_STAMINA 50 >=) 0.2 *

Result: +20% speed when stamina >= 50
```

**Example 3: Zero Armor Penalty**
```
M_HP = M_HP + (T_ARMOR 0 ==) -0.3 *

Result: -30% HP if armor is exactly 0
```

**Logical Operators:**
- `AND` - Both conditions true (multiplication)
- `OR` - Either condition true (addition, clamped)
- `NOT` - Inverts boolean

**Example 4: Multiple Conditions with AND**
```
M_GUNDAMAGE = M_GUNDAMAGE + (T_HP 100 >) (T_STAMINA 50 >) AND 0.5 *

When HP > 100 AND stamina > 50: +50% damage
Otherwise: no bonus

Note: AND returns 1.0 only if both operands are non-zero
```

**Example 5: Either Condition with OR**
```
M_MOVESPEED = M_MOVESPEED + (T_HP 50 <) (T_ARMOR 0 ==) OR 0.3 *

When HP < 50 OR armor == 0: +30% movement
Otherwise: no bonus

Note: OR returns 1.0 if either operand is non-zero
```

### 2.4 Complex Scaling

**Example 1: Diminishing Returns Scaling**
```
M_CRITCHANCE = M_CRITCHANCE + MIN(0.5, T_MOVESPEED 200 /)

Explanation:
- Gain crit chance based on movement speed
- 200 speed = +100% crit, 400 speed = +200% crit
- But capped at 50% bonus via MIN
```

**Example 2: Progressive Thresholds**
```
A_GUNDAMAGE = A_GUNDAMAGE + (T_HP 200 >) 10 * (T_HP 400 >) 20 * +

Explanation:
- If HP > 200: +10 damage
- If HP > 400: +10 + 20 = +30 damage total
- Creates milestone-based scaling
```

**Example 3: Ratio-Based Conversion**
```
M_MELEEDAMAGE = M_MELEEDAMAGE + T_GUNDAMAGE T_MELEEDAMAGE / 0.1 * 2 MAX

Explanation:
- Calculate gun damage / melee damage ratio
- Multiply by 0.1, ensuring at least 2x via MAX
- Higher gun investment = larger melee multiplier
```

**Example 4: Exponential Growth (Caution)**
```
M_GUNDAMAGE = M_GUNDAMAGE + T_PLAYERSPEED 100 / 2 ^ 0.1 *

Explanation:
- speed/100 raised to power of 2
- Multiplied by 0.1
- 200 speed = (2^2)*0.1 = 0.4 (+40%)
- 300 speed = (3^2)*0.1 = 0.9 (+90%)
- Grows quadratically
```

### 2.5 Min/Max Boundary Manipulation

**Z_ Coefficients - Adjust Minimum Values**
```
Z_HP = Z_HP + 50

Effect: Player HP cannot drop below 50, regardless of damage
Use Case: "Immortality" mechanics, protected HP thresholds
```

```
Z_ARMOR = Z_ARMOR + 10

Effect: Armor value always at least 10
Use Case: Ensure baseline damage reduction
```

**U_ Coefficients - Adjust Maximum Values**
```
U_HP = U_HP + 500

Effect: Max HP cap increased by 500
Use Case: Allow "glass cannon" builds to exceed normal HP limits
```

```
U_SHOTSPERSEC = U_SHOTSPERSEC + 10

Effect: Fire rate cap increased by 10
Use Case: Remove ceiling for fire rate builds
```

**Important Notes:**
- Z_ and U_ adjust the stat's min/max constraints, not the value directly
- Original min/max come from StatsData.asset
- Multiple mods can stack Z_ and U_ adjustments
- Final value is still clamped: `Min(Max(computed_value, min+Z), max+U)`

### 2.6 Trade-off Equations

Creating interesting choices by boosting one stat while reducing another.

**Example 1: Damage vs Fire Rate**
```
M_GUNDAMAGE = M_GUNDAMAGE + (-0.3); M_SHOTSPERSEC = M_SHOTSPERSEC + 0.5

Effect: -30% gun damage, +50% fire rate
Design: Lower per-shot damage, but more shots per second
```

**Example 2: Proc vs Damage**
```
M_GUNDAMAGE = M_GUNDAMAGE + (-0.4); M_PROCRATE = M_PROCRATE + 1.8

Effect: -40% damage, +180% proc rate
Design: Build-defining choice for proc-focused builds
```

**Example 3: Accuracy vs Speed**
```
M_ACCURACY = M_ACCURACY + (-2.0); M_SHOTSPERSEC = M_SHOTSPERSEC + 1.2

Effect: -200% accuracy (very inaccurate), +120% fire rate
Design: Spray-and-pray playstyle
```

**Example 4: HP vs Movement**
```
M_HP = M_HP + (-0.2); M_PLAYERSPEED = M_PLAYERSPEED + 0.5

Effect: -20% max HP, +50% movement speed
Design: Glass cannon mobility build
```

**Example 5: Symmetric Cross-Stat Trade**
```
M_GUNDAMAGE = M_GUNDAMAGE + (-0.5); A_MELEEDAMAGE = B_GUNDAMAGE 2.0 *

Effect: -50% gun damage, but gain melee damage equal to 2x base gun damage
Design: Converts ranged character to melee
```

### 2.7 Multiple Statement Equations

A single mod can modify multiple stats by separating statements with semicolons.

**Example 1: Multi-Stat Buff**
```
B_HP = B_HP + 100; M_ARMOR = M_ARMOR + 0.2; B_HPREGEN = B_HPREGEN + 0.5

Effect:
- +100 base HP
- +20% armor
- +0.5 HP regen per second
Design: "Tank" mod that boosts multiple survivability stats
```

**Example 2: Weapon Transformation**
```
B_BULLETSFIRED = val1; M_ACCURACY = -3; M_SHOTSPERSEC = -val2

Effect:
- +val1 bullets per shot (e.g., +7.8 for shotgun)
- -300% accuracy (wide spread)
- -val2% fire rate (slower between shots)
Design: Transforms gun into shotgun
```

**Example 3: Elemental Effect Setup**
```
B_IGNITECHANCE = val1; B_IGNITEDAMAGE = B_GUNDAMAGE val2 *

Effect:
- Set ignite chance to val1 (e.g., 0.1 = 10%)
- Set ignite damage to val2% of base gun damage (e.g., 2.18 = 218%)
Design: Complete fire damage proc setup
```

**Example 4: Synergistic Build Enabler**
```
A_MELEEDAMAGE = B_GUNDAMAGE 0.5 *; M_MELEESPEED = M_MELEESPEED + 0.3; M_MELEERANGE = M_MELEERANGE + 0.2

Effect:
- Add 50% of base gun damage to melee
- +30% melee speed
- +20% melee range
Design: Hybrid combat style enabler
```

**Example 5: Complex Minion Mod**
```
B_NUMMINIONS = val1; B_MINIONTYPE = 1; M_GUNDAMAGE = -0.3

Effect:
- Spawn val1 minions
- Set minion type to 1 (HIOX-029)
- -30% gun damage (balance cost)
Design: Minion-based playstyle with trade-off
```

---

## Section 3: What HEL CANNOT Do ❌

### 3.1 No Procedural Logic

**❌ IMPOSSIBLE: If/Else Statements**
```
// This syntax DOES NOT EXIST in HEL:
if (T_HP < 100) {
    M_GUNDAMAGE = M_GUNDAMAGE + 0.5;
} else {
    M_GUNDAMAGE = M_GUNDAMAGE + 0.1;
}
```

**✅ USE INSTEAD: Boolean Multiplication**
```
// Add 0.5 when HP < 100, otherwise add 0.1
M_GUNDAMAGE = M_GUNDAMAGE + (T_HP 100 <) 0.5 * (T_HP 100 >=) 0.1 * +

Explanation:
- (T_HP 100 <) returns 1 if true, 0 if false
- Multiply each branch by its condition
- Add both branches together (only one will be non-zero)
```

**❌ IMPOSSIBLE: While/For Loops**
```
// HEL has NO looping constructs:
for (int i = 0; i < 10; i++) {
    M_DAMAGE = M_DAMAGE + 0.1;
}
```

**✅ USE INSTEAD: Direct Multiplication**
```
// Just multiply directly
M_DAMAGE = M_DAMAGE + 0.1 10 *  // Same as adding 0.1 ten times
```

**❌ IMPOSSIBLE: Switch/Case Statements**
```
// HEL has NO switch statement:
switch (T_ARMOR) {
    case 0: M_HP = -0.5; break;
    case 10: M_HP = 0; break;
    case 20: M_HP = 0.5; break;
}
```

**✅ USE INSTEAD: Conditional Addition**
```
// Use equality checks
M_HP = M_HP + (T_ARMOR 0 ==) -0.5 * (T_ARMOR 10 ==) 0 * + (T_ARMOR 20 ==) 0.5 * +
```

### 3.2 No String Manipulation

**❌ IMPOSSIBLE: String Concatenation**
```
// HEL operates ONLY on numbers, not strings:
name = "Corrupted " + name
desc = desc + " (Enhanced)"
```

**✅ GAME ENGINE RESPONSIBILITY:**
The game engine handles text display. HEL just sets numeric stat values that the game interprets.

**Example:**
```
// Mod sets numeric flag
B_CORRUPTED = 1

// Game engine checks this flag and displays:
if (mod.B_CORRUPTED > 0) {
    displayName = "Corrupted " + mod.originalName;
}
```

**❌ IMPOSSIBLE: Text Formatting**
```
// NO string operations exist in HEL:
description = FORMAT("Damage: %.2f", T_GUNDAMAGE)
tooltip = UPPERCASE(name)
```

**✅ GAME ENGINE RESPONSIBILITY:**
UI, tooltips, and text formatting are handled by the game, not HEL.

### 3.3 No Temporal Effects

**❌ IMPOSSIBLE: Duration-Based Effects**
```
// HEL has NO concept of time or duration:
ApplyBuff(M_GUNDAMAGE, +0.5, duration=5.0)  // for 5 seconds
```

**✅ WORKAROUND: Game Engine Manages Time**
```
// Create stats for the game engine to read:
B_BUFFSTRENGTH = 0.5
B_BUFFDURATION = 5.0

// Game engine applies buff temporarily:
void Update() {
    if (buffTimer > 0) {
        currentDamage *= (1 + mod.B_BUFFSTRENGTH);
        buffTimer -= Time.deltaTime;
    }
}
```

**❌ IMPOSSIBLE: Timers and Cooldowns**
```
// HEL cannot manage cooldowns:
if (cooldown <= 0) {
    ActivateAbility();
    cooldown = 10.0;
}
```

**✅ WORKAROUND: Game Engine Tracks Cooldowns**
```
// Mod sets cooldown values
B_ABILITYCOOLDOWN = 10.0

// Game engine manages the countdown
void Update() {
    if (abilityTimer > 0) {
        abilityTimer -= Time.deltaTime;
    }
}
```

**❌ IMPOSSIBLE: Delayed Effects**
```
// HEL evaluates instantly, no delays:
DelayedEffect(() => { M_HP = M_HP + 0.5; }, 3.0)  // after 3 seconds
```

**✅ WORKAROUND: Game Engine Delays**
The game engine schedules delayed actions. HEL just provides the values.

### 3.4 No Stacking Mechanics

**❌ IMPOSSIBLE: Stack Counting**
```
// HEL cannot track how many times something happened:
stacks = 0;
OnHit() {
    stacks = stacks + 1;
    if (stacks > 5) stacks = 5;  // Cap at 5
    M_DAMAGE = 0.02 * stacks;     // +2% per stack
}
```

**✅ WORKAROUND: Game Engine Tracks, HEL Calculates**
```
// Game engine tracks stacks and passes as T_STACKS
int stacks = 0;
void OnHit() {
    stacks = Mathf.Min(stacks + 1, 5);
    UpdateTemporaryStats("STACKS", stacks);
}

// HEL reads T_STACKS and calculates bonus
M_DAMAGE = M_DAMAGE + T_STACKS 0.02 *

Result: +2% damage per stack (up to 5 stacks = +10%)
```

**❌ IMPOSSIBLE: Stack Decay**
```
// HEL has no event system:
OnStackGained() { lastStackTime = Time.now; }
Update() {
    if (Time.now - lastStackTime > 5.0) {
        stacks = 0;
    }
}
```

**✅ WORKAROUND: Game Engine Manages Decay**
Game engine handles stack decay logic, then updates T_ stats that HEL reads.

### 3.5 No Item Combining/Crafting

**❌ NOT HEL'S JOB: Rerolling Mods**
```
// HEL does NOT manage inventory operations:
RerollModValues(mod);
```

**✅ GAME ENGINE: Inventory Management**
The game engine creates new mod instances with different val/val2 values.

**❌ NOT HEL'S JOB: Combining Items**
```
// HEL does NOT handle item operations:
newMod = CombineMods(mod1, mod2);
```

**✅ GAME ENGINE: Crafting System**
Game engine creates new mod definitions, HEL evaluates their equations.

**❌ NOT HEL'S JOB: Adding Affixes**
```
// HEL does NOT modify mod definitions:
mod.AddAffix("Fire Damage");
```

**✅ GAME ENGINE: Mod Generation**
Game engine generates mods with different equations, HEL evaluates them.

**What HEL DOES:**
- Evaluates equations for a given set of mods
- Calculates final stat values
- Resolves dependencies between equations

**What Game Engine DOES:**
- Create/destroy mod instances
- Manage player inventory
- Randomize mod values (val, val2)
- Handle crafting UI and logic
- Save/load mod data

### 3.6 Two Values Per Mod Maximum

**❌ LIMITATION: Multiple Values in One Mod**
```
// Each mod has ONLY val and val2:
modid: 100
val: 10
val2: 0.5
val3: 25        // ← DOES NOT EXIST
val4: 0.3       // ← DOES NOT EXIST
val5: 100       // ← DOES NOT EXIST
```

**✅ WORKAROUND 1: Derive Values Mathematically**
```
// Use val and val2 to derive additional values in equation
equation: B_HP = val1; M_ARMOR = val2; A_STAMINA = val1 val2 * 10 *

Result:
- B_HP = val1 (first value)
- M_ARMOR = val2 (second value)
- A_STAMINA = val1 * val2 * 10 (derived third value)
```

**✅ WORKAROUND 2: Split Into Multiple Mods**
```
// Instead of one mod with 5 values, create 2-3 mods

Mod 1:
val: 10, val2: 0.5
equation: B_HP = val1; M_ARMOR = val2

Mod 2:
val: 25, val2: 0.3
equation: A_STAMINA = val1; M_MOVESPEED = val2

Mod 3:
val: 100
equation: B_MAXSTAMINA = val1
```

**✅ WORKAROUND 3: Use Constants**
```
// Hardcode additional values in equation
equation: B_HP = val1; M_ARMOR = val2; B_STAMINA = 25

Result: val1 and val2 are dynamic, 25 is always 25
```

---

## Section 4: Example Equation Patterns

### Pattern 1: Simple Percentage Boost
```
M_GUNDAMAGE = M_GUNDAMAGE + val1

Example: val1 = 0.25
Effect: +25% gun damage
Use: Basic damage increases
```

### Pattern 2: Flat Addition
```
B_HP = B_HP + val1

Example: val1 = 50
Effect: +50 HP (base additive, affected by multipliers)
Use: Raw HP increases
```

### Pattern 3: Absolute Addition
```
A_GUNDAMAGE = A_GUNDAMAGE + val1

Example: val1 = 10
Effect: +10 gun damage (after all multipliers)
Use: Flat damage that doesn't scale with percentages
```

### Pattern 4: Conditional Bonus
```
M_FIRERATE = M_FIRERATE + (T_STAMINA 50 >) val1 *

Example: val1 = 0.3
Effect: +30% fire rate when stamina > 50, otherwise +0%
Use: Conditional stat boosts based on other stats
```

### Pattern 5: Cross-Stat Synergy
```
A_MELEEDAMAGE = A_MELEEDAMAGE + B_GUNDAMAGE val1 *

Example: val1 = 0.5
Effect: Gain +50% of base gun damage as flat melee damage
Use: Synergize builds across damage types
```

### Pattern 6: Scaled Conversion
```
A_GUNDAMAGE = A_GUNDAMAGE + T_PLAYERSPEED val1 *

Example: val1 = 0.1, T_PLAYERSPEED = 200
Effect: +20 gun damage (200 * 0.1)
Use: Convert one stat into another with scaling
```

### Pattern 7: Capped Scaling
```
M_CRITCHANCE = M_CRITCHANCE + MIN(val1, T_MOVESPEED 100 /)

Example: val1 = 0.5, T_MOVESPEED = 300
Effect: MIN(0.5, 3.0) = +0.5 (+50% crit, capped)
Use: Prevent infinite scaling
```

### Pattern 8: Threshold Bonus
```
M_ARMOR = M_ARMOR + (T_HP 200 >=) val1 *

Example: val1 = 0.4, T_HP = 250
Effect: +40% armor (threshold met)
Use: Milestone-based bonuses
```

### Pattern 9: Multi-Condition
```
M_DAMAGE = M_DAMAGE + (T_HP 100 >) (T_STAMINA 50 >) AND val1 *

Example: val1 = 0.6, both conditions true
Effect: +60% damage (only when both conditions met)
Use: Complex activation requirements
```

### Pattern 10: Progressive Brackets
```
A_DAMAGE = A_DAMAGE + (T_HP 100 >) val1 * (T_HP 200 >) val2 * +

Example: val1 = 10, val2 = 20, T_HP = 250
Effect: +30 damage total (10 for >100, plus 20 for >200)
Use: Tiered scaling
```

### Pattern 11: Ratio-Based Boost
```
M_GUNDAMAGE = M_GUNDAMAGE + T_MELEEDAMAGE T_GUNDAMAGE / val1 *

Example: val1 = 0.1, melee=50, gun=25
Effect: (50/25) * 0.1 = +0.2 (+20% gun damage)
Use: Boost based on stat ratios
```

### Pattern 12: Exponential Scaling
```
M_ARMOR = M_ARMOR + T_PLAYERSPEED 100 / 2 ^ val1 *

Example: val1 = 0.05, speed = 200
Effect: (2^2) * 0.05 = 0.2 (+20% armor)
Use: Quadratic/exponential growth
```

### Pattern 13: Minimum Enforcement
```
B_HP = B_HP + MAX(val1, 10)

Example: val1 = 5
Effect: +10 HP (minimum enforced)
Use: Ensure minimum bonus values
```

### Pattern 14: Diminishing Returns
```
M_MOVESPEED = M_MOVESPEED + T_GUNDAMAGE val1 * 100 /

Example: val1 = 50, T_GUNDAMAGE = 200
Effect: (200 * 50) / 100 = +100% movement
But as damage grows, each point matters less
Use: Prevent runaway scaling
```

### Pattern 15: Inverted Scaling
```
M_HP = M_HP + (T_ARMOR 0 ==) val1 *

Example: val1 = 0.5, T_ARMOR = 0
Effect: +50% HP when armor is zero
Use: Compensate for weaknesses
```

### Pattern 16: Two-Value Trade-off
```
M_GUNDAMAGE = M_GUNDAMAGE + (-val1); M_PROCRATE = M_PROCRATE + val2

Example: val1 = 0.3, val2 = 1.5
Effect: -30% gun damage, +150% proc rate
Use: Build-defining trade-offs
```

### Pattern 17: Elemental Setup
```
B_IGNITECHANCE = val1; B_IGNITEDAMAGE = B_GUNDAMAGE val2 *

Example: val1 = 0.1, val2 = 2.0, B_GUNDAMAGE = 20
Effect: 10% ignite chance, 40 ignite damage per second
Use: Complete proc effect configuration
```

### Pattern 18: Weapon Transformation
```
B_BULLETSFIRED = val1; M_ACCURACY = -3; M_SHOTSPERSEC = -val2

Example: val1 = 8, val2 = 0.5
Effect: +8 bullets, -300% accuracy, -50% fire rate
Use: Completely change weapon behavior (shotgun)
```

### Pattern 19: Min/Max Adjustment
```
Z_HP = Z_HP + val1; U_HP = U_HP + val2

Example: val1 = 50, val2 = 500
Effect: HP cannot drop below 50, max HP cap increased by 500
Use: Adjust stat boundaries
```

### Pattern 20: Random Variation
```
M_GUNDAMAGE = M_GUNDAMAGE + RAND val1 *

Example: val1 = 0.5
Effect: +0% to +50% gun damage (random each evaluation)
Use: Unpredictable bonuses (use sparingly)
```

---

## Section 5: Anti-Patterns (What NOT to Do)

### Anti-Pattern 1: Overwriting Instead of Adding
```
❌ M_DAMAGE = 0.5
Problem: Overwrites any previous M_DAMAGE modifications from other mods

✅ M_DAMAGE = M_DAMAGE + 0.5
Solution: Adds to existing M_DAMAGE, stacking with other mods
```

### Anti-Pattern 2: Assigning to Read-Only Stats
```
❌ T_HP = 100
Problem: T_ stats are read-only, calculated by system

✅ B_HP = 100
Solution: Modify B_ coefficient, system calculates T_HP
```

```
❌ S_GUNDAMAGE = 50
Problem: S_ stats are base values from StatsData.asset, read-only

✅ B_GUNDAMAGE = 50
Solution: Add to B_ coefficient to increase damage
```

### Anti-Pattern 3: Using Procedural Syntax
```
❌ if (T_HP < 100) { M_DAMAGE = M_DAMAGE + 0.5; }
Problem: HEL has no if statements

✅ M_DAMAGE = M_DAMAGE + (T_HP 100 <) 0.5 *
Solution: Use boolean multiplication
```

### Anti-Pattern 4: Forgetting Operator Order (Postfix)
```
❌ M_DAMAGE = M_DAMAGE + 0.5 * val1
Problem: Postfix notation: operators come AFTER operands
Reads as: (M_DAMAGE + 0.5) * val1

✅ M_DAMAGE = M_DAMAGE + val1 0.5 *
Solution: Correct postfix order: val1 0.5 * then add to M_DAMAGE
```

### Anti-Pattern 5: Confusing Percentage Format
```
❌ M_DAMAGE = M_DAMAGE + 50
Problem: M_ coefficients use decimals: 50 = +5000% damage

✅ M_DAMAGE = M_DAMAGE + 0.5
Solution: 0.5 = +50%, 0.1 = +10%, 1.0 = +100%
```

### Anti-Pattern 6: Missing Coefficient Prefix
```
❌ DAMAGE = DAMAGE + 10
Problem: Must use coefficient prefixes (B_, M_, A_, etc.)

✅ B_DAMAGE = B_DAMAGE + 10
Solution: Use B_ for base additive damage
```

### Anti-Pattern 7: Trying to Access Non-Existent Values
```
❌ M_DAMAGE = M_DAMAGE + val3
Problem: Only val (val1) and val2 exist

✅ M_DAMAGE = M_DAMAGE + val1 val2 *
Solution: Derive additional values mathematically
```

### Anti-Pattern 8: Forgetting MAX(0, 1+M) Clamp
```
❌ Expecting M_DAMAGE = -2 to double reverse damage
Problem: M coefficient is clamped: Max(0, 1 + M)
M = -2 becomes Max(0, 1 + (-2)) = Max(0, -1) = 0

✅ Understanding: M_DAMAGE = -1 or less results in 0 damage
Solution: Use M values between -1 and 0 for reductions
```

### Anti-Pattern 9: Not Stacking Coefficients
```
❌ Creating separate M_DAMAGE coefficients
Problem: You can't create new coefficient types

✅ Multiple mods modify same M_DAMAGE
Solution: M_DAMAGE accumulates across all mods:
Mod 1: M_DAMAGE = M_DAMAGE + 0.2
Mod 2: M_DAMAGE = M_DAMAGE + 0.3
Result: M_DAMAGE = 0.5 total
```

### Anti-Pattern 10: Missing Semicolons
```
❌ B_HP = B_HP + 50 M_ARMOR = M_ARMOR + 0.2
Problem: Without semicolon, parser treats as one statement

✅ B_HP = B_HP + 50; M_ARMOR = M_ARMOR + 0.2
Solution: Separate statements with semicolons
```

### Anti-Pattern 11: Using Infix Notation
```
❌ B_HP = (100 + 50) * 2
Problem: HEL uses postfix (Reverse Polish Notation)

✅ B_HP = 100 50 + 2 *
Solution: Operands first, then operators
```

### Anti-Pattern 12: Circular Dependencies Without Care
```
⚠️ A_GUNDAMAGE = B_MELEEDAMAGE 0.5 *
    A_MELEEDAMAGE = B_GUNDAMAGE 0.5 *
Warning: Circular dependency - order matters

✅ System handles cycles, but may average or iterate
Better: Use S_ or B_ for cross-references when possible
```

### Anti-Pattern 13: Assuming Immediate T_ Updates
```
❌ B_HP = B_HP + 50; M_ARMOR = M_ARMOR + T_HP 100 /
Problem: T_HP not updated until AFTER all equations evaluate

✅ M_ARMOR = M_ARMOR + S_HP 100 /
Solution: Use S_ (base value) or understand T_ reads previous cycle
```

### Anti-Pattern 14: Ignoring Case Sensitivity
```
⚠️ Actually NOT an anti-pattern!
m_damage = M_DAMAGE = M_Damage
Info: HEL is case-insensitive, all work

✅ But for readability, use consistent casing
Recommendation: Use UPPERCASE for stat names
```

### Anti-Pattern 15: Complex Equations Without Testing
```
❌ M_DAMAGE = T_HP T_ARMOR + T_STAMINA * 100 / CEIL RAND *
Problem: Hard to debug, unclear intent

✅ Break into multiple statements or simplify:
A_DAMAGEBONUS = T_HP T_ARMOR + T_STAMINA * 100 / CEIL
M_DAMAGE = M_DAMAGE + A_DAMAGEBONUS 0.01 *
Better: Clear, testable steps
```

---

## Section 6: Best Practices

### 6.1 Always Add to Coefficients, Don't Overwrite

**DO:**
```
M_GUNDAMAGE = M_GUNDAMAGE + 0.25
B_HP = B_HP + 50
A_ARMOR = A_ARMOR + 10
```

**DON'T:**
```
M_GUNDAMAGE = 0.25        // Overwrites previous mods!
B_HP = 50                 // Doesn't stack!
A_ARMOR = 10              // Only this mod's value applies!
```

**Why:** Multiple mods need to stack their effects. Always read the current value and add to it.

### 6.2 Use S_ and T_ for Reading, B_/A_/M_/Z_/U_ for Modifying

**Reading Values:**
- `S_` - Base stat values (from StatsData.asset)
- `T_` - Final computed values (from previous evaluation)

**Writing Values:**
- `B_` - Base additive (affected by multipliers)
- `A_` - Absolute additive (after multipliers)
- `M_` - Multiplicative percentage
- `Z_` - Minimum boundary adjustment
- `U_` - Maximum boundary adjustment

**Example:**
```
// Read S_ to create synergy based on base stats
A_MELEEDAMAGE = A_MELEEDAMAGE + S_GUNDAMAGE 0.5 *

// Read T_ to create conditional based on current state
M_ARMOR = M_ARMOR + (T_HP 100 <) 0.3 *

// Write to B_/A_/M_ to modify stats
B_HP = B_HP + 50
M_GUNDAMAGE = M_GUNDAMAGE + 0.25
```

### 6.3 Keep Equations Readable

**Use Clear Variable Names:**
```
// Stat names are predefined, use descriptive ones
✅ B_GUNDAMAGE, T_PLAYERSPEED, M_PROCRATE
❌ B_X, T_Y, M_Z (not valid anyway)
```

**Break Complex Logic Into Steps:**
```
// Instead of one massive equation:
❌ M_DAMAGE = M_DAMAGE + T_HP 200 / T_ARMOR 50 / + CEIL T_STAMINA 100 > 0.5 0.2 OR * +

// Use multiple statements:
✅ A_HPBONUS = T_HP 200 / CEIL
   A_ARMORBONUS = T_ARMOR 50 / CEIL
   M_DAMAGE = M_DAMAGE + A_HPBONUS A_ARMORBONUS + 0.01 *
   M_DAMAGE = M_DAMAGE + (T_STAMINA 100 >) 0.5 *
```

**Add Comments (After --):**
```
B_HP = B_HP + val1; -- Increases base HP before multipliers
M_GUNDAMAGE = M_GUNDAMAGE + val2; -- Percentage damage boost
A_ARMOR = A_ARMOR + T_HP 10 /; -- Gain 1 armor per 10 HP
```

### 6.4 Test Complex Equations With Simple Values

**Start with obvious test values:**
```
Equation: M_DAMAGE = M_DAMAGE + T_HP 100 / val1 *

Test 1: T_HP = 100, val1 = 0.1
Expected: (100/100) * 0.1 = 0.1 = +10% damage ✓

Test 2: T_HP = 200, val1 = 0.1
Expected: (200/100) * 0.1 = 0.2 = +20% damage ✓

Test 3: T_HP = 0, val1 = 0.1
Expected: (0/100) * 0.1 = 0 = +0% damage ✓
```

**Test edge cases:**
```
Equation: M_SPEED = M_SPEED + (T_STAMINA 50 >) val1 *

Test 1: T_STAMINA = 51 (just above threshold)
Expected: 1 * val1 = bonus applied ✓

Test 2: T_STAMINA = 50 (at threshold)
Expected: 0 * val1 = no bonus ✓

Test 3: T_STAMINA = 0 (minimum)
Expected: 0 * val1 = no bonus ✓
```

### 6.5 Use MIN/MAX to Cap Scaling

**Prevent runaway scaling:**
```
// Without cap (dangerous):
❌ M_DAMAGE = M_DAMAGE + T_GUNDAMAGE 10 /
   Problem: If GUNDAMAGE reaches 1000, this adds +100 (+10000% damage!)

// With cap (safe):
✅ M_DAMAGE = M_DAMAGE + MIN(0.5, T_GUNDAMAGE 10 /)
   Result: Capped at +50% damage bonus regardless of gun damage
```

**Ensure minimum values:**
```
// Prevent useless bonuses:
❌ B_DAMAGE = val1
   Problem: If val1 rolls 0.1, gain only +0.1 damage

// Enforce minimum:
✅ B_DAMAGE = MAX(5, val1)
   Result: Always gain at least +5 damage
```

### 6.6 Remember Percentages Are Decimals

**M_ Coefficient Format:**
```
✅ 0.1 = +10%
✅ 0.25 = +25%
✅ 0.5 = +50%
✅ 1.0 = +100% (doubles the stat)
✅ -0.3 = -30%

❌ 10 = +1000% (not +10%!)
❌ 25 = +2500% (not +25%!)
```

**Common Values:**
```
M_GUNDAMAGE = M_GUNDAMAGE + 0.15    // +15% damage
M_GUNDAMAGE = M_GUNDAMAGE + 0.50    // +50% damage
M_GUNDAMAGE = M_GUNDAMAGE + (-0.2)  // -20% damage
```

### 6.7 Understand B_ vs A_ for Balance

**B_ (Base Additive) - Affected by Multipliers:**
```
B_HP = B_HP + 50
If player has M_HP = 0.2 (+20%), this becomes:
Final = (S_HP + 50) * 1.2 = scales with multipliers
```
Use for: Stats that should scale with percentage bonuses

**A_ (Absolute Additive) - NOT Affected by Multipliers:**
```
A_HP = A_HP + 50
Regardless of M_HP value:
Final = (S_HP + B_HP) * (1 + M_HP) + 50 = always +50
```
Use for: Flat bonuses that shouldn't scale

**Example Comparison:**
```
Base: S_HP = 100, M_HP = 0.5 (+50%)

Mod 1: B_HP = B_HP + 50
Result: (100 + 50) * 1.5 = 225 HP (B_ is scaled)

Mod 2: A_HP = A_HP + 50
Result: (100) * 1.5 + 50 = 200 HP (A_ is flat)
```

### 6.8 Document Intended Behavior

**For each mod, clearly state:**
1. What stats it modifies
2. Expected value ranges for val/val2
3. Intended playstyle or build
4. Balance trade-offs

**Example:**
```
modid: 42
name: BLOOD MAGE NANITES
val: 0.25 (0.1 to 0.5)     // HP sacrifice percentage
val2: 1.5 (1.0 to 2.0)     // Damage multiplier
equation: M_HP = M_HP + (-val1); M_GUNDAMAGE = M_GUNDAMAGE + val2
desc: Sacrifice val1% max HP to gain val2% gun damage

Intended: High-risk, high-reward damage build
Trade-off: Less survivability for more damage
Synergy: Works with HP regen mods to offset cost
```

### 6.9 Test Cross-Stat Dependencies

**When creating synergies, verify:**
1. Base case (stat at normal value)
2. Zero case (stat at 0)
3. Maximum case (stat at cap)

**Example:**
```
Equation: A_MELEEDAMAGE = A_MELEEDAMAGE + B_GUNDAMAGE val1 *

Test 1: B_GUNDAMAGE = 20, val1 = 0.5
Expected: +10 melee damage ✓

Test 2: B_GUNDAMAGE = 0, val1 = 0.5
Expected: +0 melee damage (no gun damage to convert) ✓

Test 3: B_GUNDAMAGE = 100, val1 = 0.5
Expected: +50 melee damage (high synergy) ✓
```

### 6.10 Be Cautious With RAND

**RAND generates a new random value each evaluation:**
```
M_DAMAGE = M_DAMAGE + RAND 0.5 *
Problem: Value changes every time stats are recalculated!
```

**Better uses for RAND:**
1. Initial mod value randomization (use val/val2 instead)
2. Proc chance calculations (game engine handles)
3. Unpredictable effects (if intentional)

**Generally avoid RAND in mod equations unless:**
- The design specifically wants unpredictability
- You understand it re-rolls every evaluation

### 6.11 Validate Stat Names Match StatsData.asset

**All stat names must exist in StatsData.asset:**
```
❌ B_COOLDAMAGE = B_COOLDAMAGE + 50
Error: COOLDAMAGE stat doesn't exist

✅ B_GUNDAMAGE = B_GUNDAMAGE + 50
Success: GUNDAMAGE is a valid stat
```

**Common valid stats:**
- HP, HPREGEN, MAXSTAMINA, STAMINAREGEN
- PLAYERSPEED, SPRINTSPEED, SWIMSPEED
- GUNDAMAGE, SHOTSPERSEC, ACCURACY, BULLETSFIRED
- MELEEDAMAGE, MELEERANGE, MELEESPEED
- PROCRATE, PROCRANGE
- ARMOR, PLATES
- etc.

**Check the StatsData.asset file for the complete list!**

### 6.12 Consider Evaluation Order for Dependencies

**HEL resolves dependencies automatically, but:**
```
Mod 1: A_GUNDAMAGE = B_MELEEDAMAGE 0.5 *
Mod 2: A_MELEEDAMAGE = B_GUNDAMAGE 0.5 *

This creates a circular dependency!
```

**System handles cycles by:**
1. Detecting circular dependencies
2. Grouping them
3. Executing in optimal order (or averaging iterations)

**Best practice:** Minimize circular dependencies
- Use S_ (base values) when possible
- Create one-way conversions instead of two-way
- Document when circular dependencies are intentional

---

## Quick Reference Tables

### Coefficient Type Quick Reference

| Coefficient | Description | When To Use | Example |
|-------------|-------------|-------------|---------|
| **B_** | Base additive (before multiplier) | Bonuses that should scale with % mods | `B_HP = B_HP + 50` |
| **A_** | Absolute additive (after multiplier) | Flat bonuses that don't scale | `A_GUNDAMAGE = A_GUNDAMAGE + 10` |
| **M_** | Multiplicative percentage | Percentage increases/decreases | `M_GUNDAMAGE = M_GUNDAMAGE + 0.25` |
| **Z_** | Minimum boundary | Raise floor for stat | `Z_HP = Z_HP + 50` |
| **U_** | Maximum boundary | Raise ceiling for stat | `U_HP = U_HP + 500` |
| **S_** | Start value (read-only) | Reference base stats | `S_GUNDAMAGE 0.5 *` |
| **T_** | Total value (read-only) | Conditionals on current state | `(T_HP 100 <)` |

### Mathematical Operators

| Operator | Name | Usage | Example |
|----------|------|-------|---------|
| `+` | Addition | `a b +` | `5 3 +` = 8 |
| `-` | Subtraction | `a b -` | `5 3 -` = 2 |
| `*` | Multiplication | `a b *` | `5 3 *` = 15 |
| `/` | Division | `a b /` | `6 3 /` = 2 |
| `^` | Exponentiation | `a b ^` | `2 3 ^` = 8 |

### Comparison Operators

| Operator | Name | Returns | Example |
|----------|------|---------|---------|
| `<` | Less than | 1.0 if true, 0.0 if false | `T_HP 100 <` |
| `<=` | Less than or equal | 1.0 if true, 0.0 if false | `T_HP 100 <=` |
| `>` | Greater than | 1.0 if true, 0.0 if false | `T_HP 100 >` |
| `>=` | Greater than or equal | 1.0 if true, 0.0 if false | `T_HP 100 >=` |
| `==` | Equal | 1.0 if true, 0.0 if false | `T_ARMOR 0 ==` |
| `!=` | Not equal | 1.0 if true, 0.0 if false | `T_ARMOR 0 !=` |

### Functions

| Function | Parameters | Returns | Example |
|----------|------------|---------|---------|
| `MIN` | 2 values | Smaller value | `MIN(0.5, val1)` |
| `MAX` | 2 values | Larger value | `MAX(10, val1)` |
| `CEIL` | 1 value | Rounded up | `CEIL(2.3)` = 3 |
| `FLOOR` | 1 value | Rounded down | `FLOOR(2.7)` = 2 |
| `RAND` | None | Random 0-1 | `RAND` |
| `AND` | 2 values | 1 if both non-zero | `a b AND` |
| `OR` | 2 values | 1 if either non-zero | `a b OR` |
| `NOT` | 1 value | 1 if zero, 0 if non-zero | `a NOT` |

---

## Conclusion

This guide defines the technical boundaries of HEL. Creative subagents should:

**✅ Design mods using:**
- Coefficient system (B_, A_, M_, Z_, U_)
- Mathematical functions and operators
- Cross-stat dependencies
- Boolean conditionals as math
- Multiple statements per mod
- Trade-offs for balance

**❌ Avoid designing mods that require:**
- Procedural if/else/loops
- String manipulation
- Temporal effects (durations, timers)
- Stack counting
- Item combining/crafting
- More than 2 values per mod

**When in doubt:**
- HEL calculates numbers
- Game engine handles everything else (UI, time, inventory, events)
- Use T_ stats to pass game state to HEL
- Use B_/A_/M_/Z_/U_ stats to pass HEL results to game

This guide should enable creative subagents to design technically feasible mods that leverage HEL's strengths while respecting its limitations.
