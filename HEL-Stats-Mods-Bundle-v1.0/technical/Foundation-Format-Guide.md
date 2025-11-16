# Foundation Format Guide
## Comprehensive YAML Schema & Conventions for Stats and Mods

This document provides the complete format specification for creating Stats and Mods in the HEL4Unity system. All creative subagents must follow these conventions to ensure compatibility with the existing data schema.

---

## Section 1: Stats YAML Schema

### Complete Field List

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `name` | string | Yes | Unique identifier for the stat (UPPERCASE) |
| `desc` | string | Yes | Human-readable description of the stat |
| `value` | float | Yes | Default/starting value of the stat |
| `min` | float | Yes | Minimum allowed value (can be negative) |
| `max` | float | Yes | Maximum allowed value |

### Field Details

#### name (string)
- **Format**: UPPERCASE with NO SPACES
- **Examples**: `PLAYERSPEED`, `GUNDAMAGE`, `HP`, `HPREGEN`
- **Purpose**: Used as variable identifier in HEL equations (with prefix like `S_PLAYERSPEED`)
- **Convention**: Descriptive compound words (e.g., `MAXSTAMINA`, `SHOTSPERSEC`)

#### desc (string)
- **Format**: Sentence case, descriptive phrase
- **Examples**:
  - "How fast you run"
  - "The damage of your projectiles"
  - "Percentage of HP regenerated per second"
- **Purpose**: User-facing tooltip/description text
- **Style**: Brief, clear explanations without periods typically

#### value (float)
- **Purpose**: The base/default value of the stat at game start
- **Range**: Varies by stat type (see Section 4)
- **Examples**: `100` (HP), `0.5` (ACCURACY), `130` (PLAYERSPEED)

#### min (float)
- **Purpose**: Lower bound for stat value after all modifications
- **Common Values**:
  - `0` for most stats (non-negative)
  - `-5000` for special cases like GRAVITY
- **Note**: Prevents stats from going negative when inappropriate

#### max (float)
- **Purpose**: Upper bound for stat value after all modifications
- **Common Values**:
  - `5000` for most absolute value stats
  - `1` for percentage/probability stats
- **Note**: Prevents stats from exceeding reasonable limits

### Annotated Example Stat Entry

```yaml
- name: GUNDAMAGE                    # UPPERCASE, no spaces, descriptive identifier
  desc: The damage of your projectiles   # Sentence case, user-friendly explanation
  value: 10                          # Base damage value (moderate starting point)
  min: 0                             # Cannot have negative damage
  max: 5000                          # Upper limit to prevent overflow
```

```yaml
- name: ACCURACY                     # UPPERCASE identifier
  desc: The amount of innacuracy     # User-facing description
  value: 0.5                         # 0-1 range (0.5 = 50% accurate)
  min: 0                             # 0% accuracy minimum
  max: 1                             # 100% accuracy maximum (percentage stat)
```

```yaml
- name: GRAVITY                      # Special case: can be negative
  desc: The force of gravity on the player
  value: -9.81                       # Negative value (downward force)
  min: -5000                         # Can be very negative
  max: 5000                          # Can also be positive (reverse gravity)
```

---

## Section 2: Mods YAML Schema

### Complete Field List (All 14 Fields)

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `modid` | int | Yes | Unique integer identifier for this mod |
| `uuid` | string | Yes | Unique instance identifier (pattern: uuid-{id}-{digits}) |
| `val` | float | Yes | Primary randomized value (between val1min-val1max) |
| `val2` | float | Yes | Secondary randomized value (between val2min-val2max) |
| `val1min` | float | Yes | Minimum for primary value range |
| `val1max` | float | Yes | Maximum for primary value range |
| `val2min` | float | Yes | Minimum for secondary value range |
| `val2max` | float | Yes | Maximum for secondary value range |
| `name` | string | Yes | Display name (ALL CAPS WITH SPACES) |
| `desc` | string | Yes | Description (sentence case, references val1/val2) |
| `modweight` | int | Yes | Selection weight for random generation (0-600) |
| `type` | int | Yes | Mod category (0, 2, 4, 10, 20) |
| `hasProc` | int | Yes | Proc flag (0 = no, 1 = yes) |
| `equation` | string | Yes | HEL equation (can be empty string) |
| `modColor` | object | Yes | RGBA color (r, g, b, a integers, often all 0) |
| `armorEffectName` | string | Yes | Visual effect name (often empty) |
| `armorMeshName` | string | Yes | Mesh asset name (often empty) |

### Field Details

#### modid (int)
- **Purpose**: Unique identifier for the mod type
- **Range**: 0-999 (passive mods), 500-599 (weapons), 800-899 (melee), 5000-5999 (upgrades), 6000-6999 (permanent)
- **Convention**: Group by ranges based on type
- **Example**: `0` (first passive), `500` (standard gun), `5000` (first upgrade)

#### uuid (string)
- **Purpose**: Unique instance identifier for tracking individual mod instances
- **Format**: `uuid-{modid}-{repeating digits}`
- **Pattern**: The digits after the second dash typically repeat the modid or use a pattern
- **Examples**:
  - `uuid-0-123456` (modid 0)
  - `uuid-500-500500500500500500` (modid 500, repeating)
  - `uuid-5001-500150015001500150015001` (modid 5001, repeating)
- **Note**: Must be globally unique

#### val (float)
- **Purpose**: The actual randomized primary value instance (generated from val1min-val1max range)
- **Usage**: This is the "rolled" value that this specific mod instance will use
- **Example**: `0.4349492` when val1min=0.1 and val1max=1.0
- **Note**: In descriptions, reference as "val1" to indicate it uses the first value range

#### val2 (float)
- **Purpose**: The actual randomized secondary value instance (generated from val2min-val2max range)
- **Usage**: For mods that need two random values
- **Example**: `1.8630445` when val2min=1.2 and val2max=2.0
- **Convention**: Set to `0` if not used, with val2min=0 and val2max=0

#### val1min / val1max (float)
- **Purpose**: Define the range for the primary random value
- **Usage**: System generates `val` between these bounds
- **Examples**:
  - val1min: `0.1`, val1max: `1` (10%-100% modifier)
  - val1min: `5`, val1max: `5` (fixed value, no randomization)
- **Convention**: Equal values (min=max) means fixed/constant value

#### val2min / val2max (float)
- **Purpose**: Define the range for the secondary random value
- **Usage**: System generates `val2` between these bounds
- **Convention**: Set both to `0` if secondary value not needed
- **Examples**:
  - val2min: `1.2`, val2max: `2` (120%-200% modifier)
  - val2min: `0`, val2max: `0` (not used)

#### name (string)
- **Format**: ALL CAPS WITH SPACES BETWEEN WORDS
- **Examples**:
  - `LIGHTWEIGHT LUCKYSHOT NANITES`
  - `STANDARD GUN`
  - `THERMITE CORE NANITES`
- **Purpose**: Display name shown to player
- **Convention**: Often ends with "NANITES" for passive mods

#### desc (string)
- **Format**: Sentence case, descriptive explanation
- **Purpose**: Explains what the mod does to the player
- **Variable References**: Use `val1` and `val2` as placeholders
- **Examples**:
  - `"Lowers gun damage by val1% and increases effective proc rate by val2%"`
  - `"Fires group of +val1 bullets in a burst, at -200% accuracy, and -val2% reduced fire rate."`
  - `"val1% chance for bullets to split and shatter into val2 more bullets on hit"`
- **Convention**: References to values use "val1" and "val2", with "%" for percentages
- **Note**: Some descriptions have "val" without number - this is legacy, prefer "val1"

#### modweight (int)
- **Purpose**: Determines selection probability during random mod generation
- **Range**: 0-600
- **Common Values**:
  - `0` = Never randomly selected (base items, test items)
  - `3-5` = Rare (powerful effects)
  - `7-10` = Uncommon (special weapons, strong effects)
  - `100-200` = Common (basic upgrades)
  - `600` = Very common (starter items)
- **Usage**: Higher weight = more likely to be randomly selected

#### type (int)
- **Purpose**: Categorizes the mod into functional groups
- **Values**: See Section 3 for detailed breakdown
- **Examples**: `0` (passive), `2` (weapon), `4` (melee), `10` (upgrade), `20` (permanent)

#### hasProc (int)
- **Purpose**: Flags whether this mod triggers special procedural effects
- **Values**:
  - `0` = No special proc effect
  - `1` = Has special proc effect
- **Convention**: Most mods use `0`, set to `1` for special trigger-based effects
- **Note**: Currently all examples in data use `0`

#### equation (string)
- **Purpose**: HEL equation that modifies game stats
- **Format**: Semicolon-separated assignments using HEL variable prefixes
- **Examples**:
  - `"M_GUNDAMAGE=-val1;M_PROCRATE=val2"` (two modifications)
  - `"B_SHOTSPERSEC=val1"` (single modification)
  - `""` (empty - no stat modifications, visual/behavior only)
- **Variable Prefixes**:
  - `B_` = Base additive modifiers
  - `A_` = Absolute additive modifiers
  - `M_` = Multiplicative modifiers (percentage)
  - `Z_` = Minimum value adjustments
  - `U_` = Maximum value adjustments
- **Value References**: Use `val1` or `val2` (not `val` or `VAL`)
- **Special**: Can use complex expressions, see Section 7 for advanced examples

#### modColor (object)
- **Structure**: RGBA color object with integer components
- **Fields**: `r`, `g`, `b`, `a` (all integers)
- **Common Values**: All zeros `{r: 0, g: 0, b: 0, a: 0}`
- **Purpose**: Visual representation color (currently unused in most mods)
- **Convention**: Unless specific visual requirement, use all zeros

#### armorEffectName (string)
- **Purpose**: Name of visual effect asset to apply
- **Format**: String identifier matching Unity effect prefab
- **Common Values**:
  - `""` (empty - no effect)
  - `"Electric"` (electric visual effect)
- **Convention**: Empty for most mods, specify only for visual effects

#### armorMeshName (string)
- **Purpose**: Name of armor mesh asset to attach
- **Format**: String identifier matching Unity mesh asset
- **Common Values**: Almost always `""` (empty)
- **Convention**: Empty for most mods, specify only for armor visuals

### Annotated Example Mod Entry

```yaml
- modid: 0                           # Unique ID (first passive mod)
  uuid: uuid-0-123456                # Unique instance ID (pattern: uuid-{modid}-{digits})
  val: 0.4349492                     # Rolled primary value (between val1min-val1max)
  val2: 1.8630445                    # Rolled secondary value (between val2min-val2max)
  val1min: 0.1                       # Primary range: 10% minimum
  val1max: 1                         # Primary range: 100% maximum
  val2min: 1.2                       # Secondary range: 120% minimum
  val2max: 2                         # Secondary range: 200% maximum
  name: LIGHTWEIGHT LUCKYSHOT NANITES  # ALL CAPS display name
  desc: Lowers gun damage by val1% and increases effective proc rate by val2%
                                     # Description references val1/val2 as placeholders
  modweight: 10                      # Uncommon drop weight
  type: 0                            # Passive modifier type
  hasProc: 0                         # No special proc effect
  equation: M_GUNDAMAGE=-val1;M_PROCRATE=val2
                                     # HEL equation: multiplicative modifiers
  modColor:                          # Color object (unused)
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''                # No visual effect
  armorMeshName: ''                  # No armor mesh
```

```yaml
- modid: 500                         # Weapon type ID (standard gun)
  uuid: uuid-500-500500500500500500  # UUID with repeating pattern
  val: 1                             # Fixed value (val1min = val1max)
  val2: 0                            # Not used (val2min = val2max = 0)
  val1min: 1
  val1max: 1                         # Fixed value = no randomization
  val2min: 0
  val2max: 0                         # Secondary value not used
  name: STANDARD GUN
  desc: Standard small size assault rifle gun.
  modweight: 0                       # Never randomly selected (base item)
  type: 2                            # Weapon type
  hasProc: 0
  equation: ''                       # Empty = no stat modifications
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''
  armorMeshName: ''
```

```yaml
- modid: 5000                        # Upgrade type ID
  uuid: uuid-5000-500050005000500050005000
  val: 1
  val2: 0
  val1min: 1
  val1max: 1
  val2min: 0
  val2max: 0
  name: FIRE RATE NANITES
  desc: +val1 bullets fired per second
  modweight: 10                      # Can be randomly selected
  type: 10                           # Upgrade type
  hasProc: 0
  equation: B_SHOTSPERSEC=val1       # Base additive modifier
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''
  armorMeshName: ''
```

---

## Section 3: Mod Type Conventions

The `type` field categorizes mods into functional groups that determine their behavior and usage in the game.

### Type 0: Passive Modifiers (Trade-off Nanites)

**Purpose**: Passive stat modifications with trade-offs (buff one stat, nerf another)

**Characteristics**:
- Usually have both positive and negative effects
- Often named "XXX NANITES"
- Can have complex equations with multiple stat modifications
- modweight: Typically 3-10 (uncommon to common)

**ID Range**: 0-499

**Examples**:
```yaml
modid: 0
name: LIGHTWEIGHT LUCKYSHOT NANITES
desc: Lowers gun damage by val1% and increases effective proc rate by val2%
equation: M_GUNDAMAGE=-val1;M_PROCRATE=val2
```

```yaml
modid: 5
name: SHATTERSHOT NANITES
desc: val1% chance for bullets to split and shatter into val2 more bullets on hit
equation: B_BULLETSPLIT=val1;A_ADDEDSHATTERBULLETS=val2
```

### Type 2: Weapon Types

**Purpose**: Primary weapon selection that defines shooting behavior

**Characteristics**:
- Mutually exclusive (can only equip one weapon)
- Often no randomization (val1min = val1max)
- Base weapon (modid 500) has empty equation
- Variants modify fire rate, damage, spread, etc.
- modweight: 0 for base, 7-10 for variants

**ID Range**: 500-599

**Examples**:
```yaml
modid: 500
name: STANDARD GUN
desc: Standard small size assault rifle gun.
equation: ''                         # No modifications (base weapon)
modweight: 0                         # Never randomly selected
```

```yaml
modid: 501
name: SHOTGUN
desc: Fires group of +val1 bullets in a burst, at -200% accuracy, and -val2% reduced fire rate.
equation: B_BULLETSFIRED=val1;M_ACCURACY=-3;M_SHOTSPERSEC=-val2
modweight: 10
```

```yaml
modid: 502
name: SNIPER
desc: Fires fast moving bullets with val1% increased damage, perfect accuracy, but -val2% less shots per second. Pierces enemies.
equation: M_GUNDAMAGE=val1;U_ACCURACY=0.01;M_SHOTSPERSEC=-val2
modweight: 8
```

### Type 4: Melee Weapons

**Purpose**: Melee weapon selection

**Characteristics**:
- Similar to weapon types but for melee combat
- Base melee (modid 800) is standard sword
- modweight: 0 for base items

**ID Range**: 800-899

**Examples**:
```yaml
modid: 800
name: STANDARD SWORD
desc: Standard sword with short range and medium damage.
equation: ''
modweight: 0
```

### Type 10: Upgrade Nanites (Direct Buffs)

**Purpose**: Pure upgrade items with no trade-offs

**Characteristics**:
- Only positive effects (no nerfs)
- Fixed values (no randomization typically)
- Use base additive modifiers (B_) or multiplicative (M_)
- Named "XXX NANITES"
- modweight: Typically 10 (common drops)

**ID Range**: 5000-5999

**Examples**:
```yaml
modid: 5000
name: FIRE RATE NANITES
desc: +val1 bullets fired per second
equation: B_SHOTSPERSEC=val1
val1min: 1
val1max: 1                           # Fixed value
```

```yaml
modid: 5001
name: BULLET DAMAGE NANITES
desc: +val1 damage added to bullets
equation: B_GUNDAMAGE=val1
val1min: 5
val1max: 5
```

```yaml
modid: 5002
name: BULLET ACCURACY NANITES
desc: Reduces bullet angle drift by val1%
equation: M_ACCURACY=-val1           # Negative = improvement (less inaccuracy)
val1min: 0.2
val1max: 0.2
```

### Type 20: Starting/Permanent Upgrades

**Purpose**: Character progression, permanent stat increases, starting bonuses

**Characteristics**:
- Fixed values (no randomization)
- Higher modweight (100-600) for progression systems
- Use base additive modifiers (B_)
- Similar to Type 10 but for persistent progression

**ID Range**: 6000-6999

**Examples**:
```yaml
modid: 6000
name: STARTING HP
desc: Increases starting Base HP by +val1
equation: B_HP=val1
val1min: 5
val1max: 5
modweight: 100
```

```yaml
modid: 6010
name: PLATES
desc: Increases plate by +val1, decreasing physical damage taken by val1 each
equation: B_PLATES=val1
val1min: 1
val1max: 1
modweight: 600                       # Very common (important defensive stat)
```

### Type Summary Table

| Type | Category | ID Range | Trade-offs | Randomization | Example Name |
|------|----------|----------|------------|---------------|--------------|
| 0 | Passive Modifiers | 0-499 | Yes | Common | LIGHTWEIGHT LUCKYSHOT NANITES |
| 2 | Weapons | 500-599 | Situational | Rare | SHOTGUN, SNIPER |
| 4 | Melee Weapons | 800-899 | No | No | STANDARD SWORD |
| 10 | Upgrade Nanites | 5000-5999 | No | Rare | FIRE RATE NANITES |
| 20 | Permanent Upgrades | 6000-6999 | No | No | STARTING HP, PLATES |

---

## Section 4: Value Range Analysis

### Movement Stats

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| PLAYERSPEED | 130 | 0 | 5000 | units/sec | Base run speed |
| SPRINTSPEED | 100 | 0 | 5000 | units/sec | Added to PLAYERSPEED when sprinting |
| SWIMSPEED | 30 | 0 | 5000 | % of run | Percentage-based but stored as 30 not 0.3 |
| JUMPSTRENGTH | 750 | 0 | 5000 | force units | Jump force magnitude |
| GRAVITY | -9.81 | -5000 | 5000 | force units | **ONLY negative-allowed stat** |

### Health & Stamina Stats

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| HP | 100 | 0 | 5000 | points | Max health |
| HPREGEN | 0.002 | 0 | 1 | % per sec | 0.002 = 0.2% per second |
| MAXSTAMINA | 100 | 0 | 5000 | points | Max stamina |
| STAMINAREGEN | 12 | 0 | 5000 | points/sec | Absolute regen rate |
| SPRINTCOST | 40 | 0 | 5000 | points/sec | Stamina drain rate |
| DODGECOST | 70 | 0 | 5000 | points | One-time cost |

### Combat Stats (Ranged)

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| BULLETSPEED | 400 | 0 | 5000 | units/sec | Projectile velocity |
| GUNDAMAGE | 10 | 0 | 5000 | damage | Base bullet damage |
| SHOTSPERSEC | 2 | 0 | 5000 | shots/sec | Fire rate |
| ACCURACY | 0.5 | 0 | 1 | inaccuracy | **0-1 range: 0=perfect, 1=worst** |
| BULLETSPLIT | 0 | 0 | 1 | probability | **0-1 range: chance to split** |
| ADDEDSHATTERBULLETS | 0 | 0 | 5000 | count | Number of split bullets |
| BULLETSFIRED | 1 | 0 | 5000 | count | Bullets per shot |
| PROJECTILEKNOCKBACK | 100 | 0 | 5000 | force | Pushback force |

### Combat Stats (Melee)

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| MELEERANGE | 9 | 0 | 5000 | units | Attack range |
| MELEEDAMAGE | 100 | 0 | 5000 | damage | Base melee damage |
| MELEESPEED | 1 | 0 | 5000 | attacks/sec | Attack rate |

### Proc & Effect Stats

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| PROCRATE | 1 | 0 | 5000 | multiplier | Global proc rate modifier |
| PROCRANGE | 50 | 0 | 5000 | units | Range for proc effects |
| IGNITECHANCE | 0 | 0 | 1 | probability | **0-1 range** |
| IGNITEDAMAGE | 0 | 0 | 5000 | damage/sec | Fire DoT |
| CHARGECHANCE | 0 | 0 | 1 | probability | **0-1 range** |
| CHARGEDAMAGE | 0 | 0 | 5000 | damage | Electric damage |
| CORRUPTIONSPREADCHANCE | 0 | 0 | 1 | probability | **0-1 range** |

### Defense Stats

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| ARMOR | 0 | 0 | 5000 | points | Diminishing returns formula |
| PLATES | 0 | 0 | 5000 | count | Flat damage reduction |
| FIRERESISTANCE | 0 | 0 | 5000 | points | Fire damage reduction |
| ELECTRICRESISTANCE | 0 | 0 | 5000 | points | Electric damage reduction |
| CORRUPTIONRESISTANCE | 0 | 0 | 5000 | points | Corruption reduction |

### Special/Misc Stats

| Stat Name | Default Value | Min | Max | Unit | Notes |
|-----------|---------------|-----|-----|------|-------|
| EXPLOSIONRADIUS | 5 | 0 | 5000 | units | AoE explosion size |
| NUMMINIONS | 0 | 0 | 5000 | count | Number of summoned allies |
| MINIONTYPE | 0 | 0 | 5000 | type ID | Which minion type |
| AUTOTURRETON | 0 | 0 | 1 | boolean | **0-1: binary flag** |
| FREENITES | 0 | 0 | 5000 | currency | In-game currency |

### Value Range Patterns

#### Pattern 1: Percentage/Probability Stats (0-1 range)
Use when representing:
- Probabilities (IGNITECHANCE, BULLETSPLIT)
- Percentages (ACCURACY, HPREGEN)
- Boolean flags (AUTOTURRETON)

**Convention**: 0.5 = 50%, 1.0 = 100%

#### Pattern 2: Absolute Value Stats (0-5000 range)
Use when representing:
- Damage values (GUNDAMAGE, MELEEDAMAGE)
- Speed/velocity (PLAYERSPEED, BULLETSPEED)
- Counts (BULLETSFIRED, NUMMINIONS)
- Resource pools (HP, MAXSTAMINA)

**Convention**: Wide range allows for extreme modifiers

#### Pattern 3: Negative-Allowed Stats (-5000 to 5000 range)
Currently only GRAVITY uses this pattern.

**Convention**: Use only for stats that can meaningfully be negative

### Recommended Ranges for New Stats

When creating new stats, follow these guidelines:

- **Damage stats**: Start 5-20, max 5000
- **Health/Resource pools**: Start 50-200, max 5000
- **Speed stats**: Start 50-500, max 5000
- **Rate stats (per second)**: Start 1-10, max 5000
- **Percentage stats**: Start 0-1, max 1
- **Probability stats**: Start 0-0.5, max 1
- **Boolean flags**: min 0, max 1, value 0 or 1
- **Count stats**: Start 0-3, max 5000

---

## Section 5: Naming Conventions

### Stat Names

**Format**: UPPERCASE, NO SPACES, compound words

**Patterns**:
- Movement: `PLAYERSPEED`, `SPRINTSPEED`, `JUMPSTRENGTH`
- Resources: `HP`, `MAXSTAMINA`, `HPREGEN`, `STAMINAREGEN`
- Combat: `GUNDAMAGE`, `MELEEDAMAGE`, `SHOTSPERSEC`
- Effects: `IGNITECHANCE`, `CHARGECHANCE`, `PROCRATE`

**Guidelines**:
- Use descriptive compound words
- Prefer specificity: `SPRINTSPEED` not `SPEED2`
- Use standard suffixes:
  - `DAMAGE` for damage values
  - `SPEED` for velocity/rate
  - `REGEN` for regeneration
  - `COST` for resource consumption
  - `CHANCE` for probabilities
  - `RANGE` for distance
  - `RESISTANCE` for defense

### Stat Descriptions

**Format**: Sentence case, brief explanation

**Style**:
- Start with capital letter
- No period at end typically
- Be concise but clear
- Explain the mechanical effect

**Good Examples**:
- "How fast you run"
- "The damage of your projectiles"
- "Chance that an enemy is set on fire from proc event"

**Avoid**:
- ALL CAPS descriptions
- Overly technical jargon
- Ambiguous language

### Mod Names

**Format**: ALL CAPS WITH SPACES

**Patterns**:
- Passive mods: `[EFFECT] [TYPE] NANITES`
  - "LIGHTWEIGHT LUCKYSHOT NANITES"
  - "THERMITE CORE NANITES"
  - "TESLA CORE NANITES"

- Weapon mods: `[WEAPON TYPE]`
  - "SHOTGUN"
  - "SNIPER"
  - "GRENADE LAUNCHER"

- Upgrade mods: `[STAT] NANITES`
  - "FIRE RATE NANITES"
  - "BULLET DAMAGE NANITES"
  - "RUN SPEED NANITES"

- Permanent upgrades: `[CONTEXT] [STAT]` or `[STAT]`
  - "STARTING HP"
  - "HP REGEN"
  - "ARMOR"

**Guidelines**:
- Use descriptive, evocative names
- Include "NANITES" for nano-tech mods
- Keep weapon names simple and clear
- Use consistent terminology

### Mod Descriptions

**Format**: Sentence case, explains effect using val1/val2 placeholders

**Style**:
- Use "val1" and "val2" to reference random values
- Include units (%, damage, etc.)
- Explain trade-offs clearly
- Be specific about mechanics

**Good Examples**:
- "Lowers gun damage by val1% and increases effective proc rate by val2%"
- "val1% chance for bullets to split and shatter into val2 more bullets on hit"
- "Fires fast moving bullets with val1% increased damage, perfect accuracy, but -val2% less shots per second. Pierces enemies."

**Patterns**:
- Percentages: "by val1%" or "val1% chance"
- Additive: "+val1 damage" or "by +val1"
- Negative: "-val1%" or "decreases by val1"
- Fixed: "val1 grenades per second" (when val1min=val1max)

**Avoid**:
- Using "val" without number (prefer "val1")
- Ambiguous language ("more powerful", "better")
- Missing units

### Variable References in Equations

**Format**: Lowercase with number

**Convention**:
- Use `val1` for primary value (references val/val1min/val1max)
- Use `val2` for secondary value (references val2/val2min/val2max)
- **Never use**: `VAL`, `val`, `Value1`, etc.

**Examples**:
```yaml
equation: M_GUNDAMAGE=-val1;M_PROCRATE=val2
equation: B_BULLETSPLIT=val1;A_ADDEDSHATTERBULLETS=val2
equation: B_SHOTSPERSEC=val1
```

### Consistency Rules

1. **Stat names** = UPPERCASE_NO_SPACES
2. **Stat descriptions** = Sentence case, brief
3. **Mod names** = ALL CAPS WITH SPACES
4. **Mod descriptions** = Sentence case, uses val1/val2
5. **Equation variables** = lowercase with number (val1, val2)
6. **HEL prefixes** = UPPERCASE with underscore (B_, M_, A_)

---

## Section 6: UUID and ModID Assignment Strategy

### ModID Sequencing

**Purpose**: ModID serves as the primary type identifier and determines mod category

**Ranges**:
```
0-499:     Passive Modifier Nanites (type 0)
500-599:   Weapon Types (type 2)
800-899:   Melee Weapons (type 4)
5000-5999: Upgrade Nanites (type 10)
6000-6999: Permanent/Starting Upgrades (type 20)
```

**Assignment Strategy**:

1. **Sequential within range**: Assign IDs sequentially within each category
   - First passive mod: 0
   - Second passive mod: 1
   - Third passive mod: 2

2. **Base items use round numbers**:
   - Base weapon: 500
   - First weapon variant: 501, 502, 503...
   - Base melee: 800
   - First upgrade: 5000, 5001, 5002...
   - First permanent: 6000, 6001, 6002...

3. **Gap strategy**: Leave gaps for related mods
   - Fire-related mods: 10-19
   - Electric mods: 20-29
   - Movement mods: 30-39

4. **Test/Debug IDs**: Use high numbers in range
   - Test mod: 999

**Example Sequence**:
```yaml
modid: 0    # First passive
modid: 1    # Second passive
modid: 2    # Third passive
...
modid: 500  # Base weapon
modid: 501  # Weapon variant 1
modid: 502  # Weapon variant 2
...
modid: 5000 # First upgrade
modid: 5001 # Second upgrade
```

### UUID Pattern

**Purpose**: Globally unique identifier for each mod instance (even if same modid)

**Format**: `uuid-{modid}-{suffix}`

Where:
- `{modid}` = The mod's ID number
- `{suffix}` = A repeating or sequential pattern for uniqueness

**Pattern Types**:

#### Type 1: Sequential Suffix (Simple)
Used for early/simple mods
```
uuid-0-123456
uuid-1-111111
uuid-2-222222
uuid-3-333333
```
**Pattern**: Simple repeating digits or sequential numbers

#### Type 2: Repeating ModID (Clear)
Used for most mods, especially later ones
```
uuid-500-500500500500500500
uuid-5001-500150015001500150015001
uuid-6000-600060006000600060006000
```
**Pattern**: Repeat the modid multiple times to fill the suffix

#### Type 3: Mixed/Custom
```
uuid-10-101010101010
uuid-999-999999999999999999
```
**Pattern**: Custom patterns for specific needs

**Recommended Approach**:

For new mods, use **Type 2 (Repeating ModID)**:

1. Take the modid
2. Repeat it until you have sufficient length (18-24 characters total in suffix)
3. Ensures uniqueness and easy identification

**Examples**:
```
modid: 7000
uuid: uuid-7000-700070007000700070007000

modid: 42
uuid: uuid-42-424242424242424242

modid: 5555
uuid: uuid-5555-555555555555555555555555
```

**UUID Generation Formula**:
```
If modid < 100:
  suffix = repeat modid to 18 digits (e.g., 42 → 424242424242424242)

If modid >= 100:
  suffix = repeat modid to 24 digits (e.g., 5000 → 500050005000500050005000)
```

**Uniqueness Guarantee**:
- UUID must be unique across ALL mods in the system
- Even duplicate modids (shouldn't happen) must have different UUIDs
- Check existing UUIDs before assigning new ones

### Summary Table

| ID Range | Type | UUID Pattern | Example |
|----------|------|--------------|---------|
| 0-499 | Passive | uuid-{id}-{repeat} | uuid-42-424242424242424242 |
| 500-599 | Weapon | uuid-{id}-{repeat} | uuid-501-501501501501501501 |
| 800-899 | Melee | uuid-{id}-{repeat} | uuid-800-800800800800800800 |
| 5000-5999 | Upgrade | uuid-{id}-{repeat} | uuid-5001-500150015001500150015001 |
| 6000-6999 | Permanent | uuid-{id}-{repeat} | uuid-6001-600160016001600160016001 |

---

## Section 7: Complete Annotated Examples

### Example 1: Trade-off Passive Mod (Type 0)

```yaml
- modid: 10                          # ID: Passive modifier range (0-499)
  uuid: uuid-10-101010101010         # Unique ID: repeating pattern
  val: 0.10812678                    # RANDOMIZED primary value (rolled between val1min-val1max)
                                     # This is the actual instance value for THIS specific mod
  val2: 2.1837018                    # RANDOMIZED secondary value (rolled between val2min-val2max)
  val1min: 0.01                      # PRIMARY VALUE RANGE: 1% minimum
  val1max: 0.6                       # PRIMARY VALUE RANGE: 60% maximum
                                     # The system will generate 'val' between these bounds
  val2min: 0.1                       # SECONDARY VALUE RANGE: 10% minimum
  val2max: 3                         # SECONDARY VALUE RANGE: 300% maximum
                                     # The system will generate 'val2' between these bounds
  name: THERMITE CORE NANITES        # ALL CAPS WITH SPACES - display name
                                     # Convention: ends with "NANITES" for passive mods
  desc: Bullets have a val1% chance to set the enemy on fire for val2% of bullet damage per second
                                     # Sentence case description
                                     # References val1 and val2 as placeholders
                                     # These will be replaced with actual values in UI
  modweight: 5                       # SELECTION WEIGHT: 5 = rare drop
                                     # Lower than common (10) because it's powerful
  type: 0                            # TYPE: 0 = Passive Modifier
                                     # Trade-off mod that adds special proc effect
  hasProc: 0                         # PROC FLAG: 0 = no special proc handling
                                     # Despite the name, uses normal equation system
  equation: B_IGNITECHANCE = val1; B_IGNITEDAMAGE = B_GUNDAMAGE val2 * --B_IGNITECHANCE=val1;V_IGNITEDAMAGE=T_GUNDAMAGE;X_IGNITEDAMAGE=B_IGNITEDAMAGE;Y_IGNITEDAMAGE=val2
                                     # COMPLEX EQUATION with multiple parts:
                                     # B_IGNITECHANCE=val1: Set ignite chance to primary value
                                     # B_IGNITEDAMAGE = B_GUNDAMAGE val2 *: Calculate ignite damage
                                     # Note: Uses B_ (base additive) prefix
  modColor:                          # COLOR: RGBA values (integers)
    r: 0                             # Red: 0 (unused)
    g: 0                             # Green: 0 (unused)
    b: 0                             # Blue: 0 (unused)
    a: 0                             # Alpha: 0 (unused)
                                     # Convention: Leave at 0,0,0,0 unless specific visual need
  armorEffectName: ''                # VISUAL EFFECT: Empty (no special effect)
  armorMeshName: ''                  # ARMOR MESH: Empty (no visual armor)
```

**Key Takeaways**:
- `val` and `val2` are pre-rolled instances
- Descriptions use "val1" and "val2" as placeholders
- Type 0 = passive modifier with trade-offs
- Equations can be complex with multiple statements
- Most visual fields (color, effect, mesh) are empty

---

### Example 2: Weapon Mod (Type 2)

```yaml
- modid: 502                         # ID: Weapon type range (500-599)
  uuid: uuid-502-502502502502502502  # UUID: repeating modid pattern
  val: 1.428995                      # PRIMARY VALUE: damage multiplier
                                     # Rolled between 1.01-2.99 (101%-299% damage)
  val2: 0.6370828                    # SECONDARY VALUE: fire rate reduction
                                     # Rolled between 0.5-0.8 (50%-80% reduction)
  val1min: 1.01                      # PRIMARY RANGE: 101% minimum
  val1max: 2.99                      # PRIMARY RANGE: 299% maximum
                                     # Provides significant damage variance
  val2min: 0.5                       # SECONDARY RANGE: 50% minimum reduction
  val2max: 0.8                       # SECONDARY RANGE: 80% maximum reduction
                                     # Trade-off for high damage: slower fire rate
  name: SNIPER                       # ALL CAPS - simple weapon name
                                     # Convention: Clear, concise weapon type name
  desc: Fires fast moving bullets with val1% increased damage, perfect accuracy, but -val2% less shots per second. Pierces enemies.
                                     # Detailed description with multiple effects
                                     # "+ val1%" = buff, "- val2%" = nerf
                                     # Includes special behavior: "Pierces enemies"
  modweight: 8                       # WEIGHT: 8 = uncommon weapon
                                     # Slightly rarer than common (10)
  type: 2                            # TYPE: 2 = Weapon Type
                                     # Mutually exclusive with other weapons
  hasProc: 0                         # No special proc
  equation: M_GUNDAMAGE=val1;U_ACCURACY=0.01;M_SHOTSPERSEC=-val2
                                     # WEAPON EQUATION with multiple modifications:
                                     # M_GUNDAMAGE=val1: Multiplicative damage increase
                                     # U_ACCURACY=0.01: Max accuracy override (perfect)
                                     # M_SHOTSPERSEC=-val2: Multiplicative fire rate decrease (negative)
                                     # Note: Uses M_ (multiplicative) and U_ (max override) prefixes
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''
  armorMeshName: ''
```

**Key Takeaways**:
- Weapons use type 2
- Often have val1 and val2 for primary/secondary trade-offs
- Equations use M_ for percentage modifiers
- U_ prefix can override max values (like accuracy)
- modweight 0 = never random (base), 7-10 = uncommon variants

---

### Example 3: Direct Upgrade Mod (Type 10)

```yaml
- modid: 5002                        # ID: Upgrade range (5000-5999)
  uuid: uuid-5002-500250025002500250025002
                                     # UUID: repeating pattern, longer for 4-digit ID
  val: 0.2                           # FIXED VALUE: Exactly 0.2 (20% reduction)
                                     # Not random because val1min = val1max
  val2: 0                            # NOT USED: Secondary value not needed
  val1min: 0.2                       # FIXED: min = max = no randomization
  val1max: 0.2                       # FIXED: Same as min = constant value
                                     # Convention: Use equal min/max for fixed effects
  val2min: 0                         # NOT USED: Set to 0 when not needed
  val2max: 0                         # NOT USED: Set to 0 when not needed
  name: BULLET ACCURACY NANITES      # Format: [STAT] NANITES
                                     # Convention: Upgrade mods name the stat they affect
  desc: Reduces bullet angle drift by val1%
                                     # Simple description for direct upgrade
                                     # "Reduces drift" = improves accuracy
  modweight: 10                      # WEIGHT: 10 = common upgrade
                                     # Direct upgrades usually common (10)
  type: 10                           # TYPE: 10 = Upgrade Nanite
                                     # Pure buff, no trade-off
  hasProc: 0                         # No special proc
  equation: M_ACCURACY=-val1         # SIMPLE EQUATION: Single modification
                                     # M_ACCURACY=-val1: Reduce inaccuracy by 20%
                                     # Negative M_ modifier = improvement for "bad" stats
                                     # (ACCURACY stat represents INaccuracy)
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''
  armorMeshName: ''
```

**Key Takeaways**:
- Type 10 = pure upgrades, no trade-offs
- Fixed values: set val1min = val1max
- val2 not used: set all val2 fields to 0
- Simple equations with single modification
- Usually modweight 10 (common)
- Negative M_ can be buff when stat is "bad" (like inaccuracy)

---

### Example 4: Permanent Upgrade Mod (Type 20)

```yaml
- modid: 6010                        # ID: Permanent upgrade range (6000-6999)
  uuid: uuid-6010-601060106010601060106010
                                     # UUID: repeating pattern for 4-digit ID
  val: 1                             # FIXED: Exactly 1 plate
  val2: 0                            # NOT USED
  val1min: 1                         # FIXED: no randomization
  val1max: 1                         # FIXED: always gives exactly 1
  val2min: 0                         # NOT USED
  val2max: 0                         # NOT USED
  name: PLATES                       # Simple name: just the stat
                                     # Convention: Permanent upgrades use direct stat names
                                     # or "STARTING [STAT]" format
  desc: Increases plate by +val1, decreasing physical damage taken by val1 each
                                     # Explains both the stat effect AND game mechanic
                                     # "by +val1" = additive increase
                                     # Includes what plates do: "decreasing physical damage"
  modweight: 600                     # WEIGHT: 600 = VERY COMMON
                                     # Highest weight in the system
                                     # Used for critical/important progression items
  type: 20                           # TYPE: 20 = Permanent/Starting Upgrade
                                     # Used for character progression systems
  hasProc: 0
  equation: B_PLATES=val1            # SIMPLE BASE ADDITIVE: B_ prefix
                                     # B_PLATES=val1: Add 1 to base plates
                                     # Pure additive, no multiplication
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''
  armorMeshName: ''
```

**Key Takeaways**:
- Type 20 = permanent/starting upgrades for progression
- Fixed values (no randomization)
- Very high modweight (100-600) for progression importance
- Use B_ (base additive) prefix
- Similar to Type 10 but for persistent systems

---

### Example 5: Base/Default Item (Type 2, No Equation)

```yaml
- modid: 500                         # ID: Base weapon (round number)
  uuid: uuid-500-500500500500500500  # UUID: clean repeating pattern
  val: 1                             # FIXED: 1 (no modification)
  val2: 0                            # NOT USED
  val1min: 1                         # FIXED: base has no variance
  val1max: 1                         # FIXED: always exactly 1
  val2min: 0                         # NOT USED
  val2max: 0                         # NOT USED
  name: STANDARD GUN                 # Base item name with "STANDARD"
                                     # Convention: Base items use "STANDARD" prefix
  desc: Standard small size assault rifle gun.
                                     # Simple description, no val references
                                     # Describes the base item characteristics
  modweight: 0                       # WEIGHT: 0 = NEVER RANDOMLY SELECTED
                                     # Base items are defaults, not drops
                                     # Player starts with or manually selects
  type: 2                            # TYPE: 2 = Weapon
  hasProc: 0
  equation: ''                       # EMPTY EQUATION: no stat modifications
                                     # Base items provide no bonuses
                                     # They represent the "neutral" state
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: ''                # No effects for base items
  armorMeshName: ''                  # No special meshes
```

**Key Takeaways**:
- Base items use round modid (500, 800)
- modweight 0 = never random drops
- Empty equation = no modifications
- Fixed val=1, val2=0
- Name includes "STANDARD"
- Type matches category (2=weapon, 4=melee)

---

### Example 6: Advanced Equation with Multiple Prefixes

```yaml
- modid: 11                          # ID: Passive mod
  uuid: uuid-11-111111111111         # UUID: repeating pattern
  val: 1                             # FIXED: 100% chance (always procs)
  val2: 0.18435782                   # RANDOM: 5%-150% damage
  val1min: 1                         # FIXED: guaranteed proc
  val1max: 1
  val2min: 0.05                      # Variable damage range
  val2max: 1.5
  name: TESLA CORE NANITES
  desc: Bullets have a val1% chance become statically charged, damaging itself and nearby enemies for val2% bullet damage every 3 seconds.
  modweight: 5                       # Rare (powerful effect)
  type: 0
  hasProc: 0
  equation: B_CHARGECHANCE = val1; B_CHARGEDAMAGE = B_GUNDAMAGE val2 * --B_CHARGECHANCE=val1;V_CHARGEDAMAGE=T_GUNDAMAGE;X_CHARGEDAMAGE=B_CHARGEDAMAGE;Y_CHARGEDAMAGE=val2
                                     # COMPLEX EQUATION BREAKDOWN:
                                     # Statement 1: B_CHARGECHANCE = val1
                                     #   - Base additive assignment
                                     #   - Sets charge chance to 100% (val1=1)
                                     #
                                     # Statement 2: B_CHARGEDAMAGE = B_GUNDAMAGE val2 *
                                     #   - Base additive assignment with calculation
                                     #   - Takes base gun damage (B_GUNDAMAGE)
                                     #   - Multiplies by val2 (5%-150%)
                                     #   - Assigns result to base charge damage
                                     #
                                     # Double dash (--) separates display from actual equation
                                     # After -- is the full HEL implementation with:
                                     #   V_ (temporary variables)
                                     #   X_ (intermediate calculations)
                                     #   Y_ (parameter storage)
                                     #
                                     # Multiple statements separated by semicolons
  modColor:
    r: 0
    g: 0
    b: 0
    a: 0
  armorEffectName: Electric          # VISUAL EFFECT: "Electric" effect name
                                     # This is a rare example of using the effect field
                                     # References a Unity effect prefab/asset
  armorMeshName: ''                  # No special mesh
```

**Key Takeaways**:
- Equations can reference other stats (B_GUNDAMAGE)
- Can perform calculations (val2 *)
- Multiple statements separated by semicolons
- Double dash (--) can separate simplified from full equation
- armorEffectName used for visual effects
- Complex mods often have lower modweight (rarer)

---

## Quick Reference Cheatsheet

### Stats Format
```yaml
- name: STATNAME              # UPPERCASE, no spaces
  desc: Brief description     # Sentence case
  value: 100                  # Default value
  min: 0                      # Lower bound
  max: 5000                   # Upper bound (or 1 for percentages)
```

### Mods Format (Simplified)
```yaml
- modid: 1000                            # Unique ID (range determines type)
  uuid: uuid-1000-100010001000100010001000  # uuid-{id}-{repeat}
  val: 0.5                               # Primary rolled value
  val2: 1.2                              # Secondary rolled value
  val1min: 0.1                           # Primary range min
  val1max: 1.0                           # Primary range max
  val2min: 1.0                           # Secondary range min
  val2max: 2.0                           # Secondary range max
  name: MOD NAME IN ALL CAPS
  desc: Description using val1 and val2 placeholders
  modweight: 10                          # 0=never, 3-5=rare, 10=common, 100+=progression
  type: 0                                # 0=passive, 2=weapon, 4=melee, 10=upgrade, 20=permanent
  hasProc: 0                             # Usually 0
  equation: M_STATNAME=val1;B_OTHERSTAT=val2  # HEL equation
  modColor: {r: 0, g: 0, b: 0, a: 0}     # Usually all zeros
  armorEffectName: ''                    # Usually empty
  armorMeshName: ''                      # Usually empty
```

### HEL Equation Prefixes
- `B_` = Base additive (adds to base before multiplication)
- `M_` = Multiplicative (percentage modifier)
- `A_` = Absolute additive (adds after multiplication)
- `Z_` = Minimum value adjustment
- `U_` = Maximum value override

### Type Quick Reference
- **0**: Passive modifiers (trade-offs)
- **2**: Weapons (mutually exclusive)
- **4**: Melee weapons
- **10**: Direct upgrades (pure buffs)
- **20**: Permanent/starting upgrades

### ModID Ranges
- **0-499**: Type 0 (passive)
- **500-599**: Type 2 (weapons)
- **800-899**: Type 4 (melee)
- **5000-5999**: Type 10 (upgrades)
- **6000-6999**: Type 20 (permanent)

---

## Validation Checklist

Before submitting a new Stat or Mod, verify:

### For Stats:
- [ ] Name is UPPERCASE with no spaces
- [ ] Description is sentence case and clear
- [ ] Value is within min-max range
- [ ] Min ≤ Value ≤ Max
- [ ] Range follows pattern (0-1 for percentages, 0-5000 for absolutes)
- [ ] Name doesn't conflict with existing stats

### For Mods:
- [ ] modid is unique and in correct range for type
- [ ] uuid follows pattern: uuid-{modid}-{repeating}
- [ ] uuid is globally unique
- [ ] val is between val1min and val1max
- [ ] val2 is between val2min and val2max
- [ ] name is ALL CAPS WITH SPACES
- [ ] desc references val1/val2 (not val/VAL)
- [ ] modweight is appropriate (0=base, 3-10=normal, 100+=permanent)
- [ ] type matches modid range
- [ ] equation uses lowercase val1/val2
- [ ] equation uses correct prefixes (B_, M_, A_, Z_, U_)
- [ ] modColor is all zeros unless specific visual need
- [ ] armorEffectName/armorMeshName are empty unless needed

---

## Common Mistakes to Avoid

1. **Wrong case in names**: Stats must be UPPERCASE_NO_SPACES, mods must be ALL CAPS WITH SPACES
2. **Using "val" in equations**: Use `val1` or `val2`, not `val` or `VAL`
3. **Mismatched ranges**: Ensure val is between val1min-val1max
4. **Wrong type for modid range**: Type must match modid range (0-499=type 0, etc.)
5. **Non-unique modid/uuid**: Always check for conflicts
6. **Incorrect prefix usage**: M_ for percentages, B_ for base additions
7. **Missing val2 setup**: If not using val2, set val2=0, val2min=0, val2max=0
8. **Wrong stat ranges**: Percentages use 0-1, absolutes use 0-5000
9. **Negative values for wrong stats**: Only GRAVITY should have negative min
10. **Description doesn't match equation**: Ensure desc accurately reflects what equation does

---

**END OF FORMAT GUIDE**

This document should be referenced by all creative subagents when designing new Stats and Mods.
