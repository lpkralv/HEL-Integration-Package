# Essentials Format Guide
Quick reference for creating properly formatted Stats and Mods.

## Stats Schema (5 Fields)

| Field | Type | Rules |
|-------|------|-------|
| `name` | string | UPPERCASE, NO SPACES (e.g., `GUNDAMAGE`, `PLAYERSPEED`) |
| `desc` | string | Sentence case, brief explanation (e.g., "How fast you run") |
| `value` | float | Default/starting value |
| `min` | float | Minimum allowed value (0 for most, -5000 for GRAVITY only) |
| `max` | float | Maximum allowed value (5000 for absolutes, 1 for percentages) |

## Mods Schema (14 Fields)

| Field | Type | Rules |
|-------|------|-------|
| `modid` | int | Unique ID (range determines type: 0-499=passive, 500-599=weapon, 5000-5999=upgrade, 6000-6999=permanent) |
| `uuid` | string | Pattern: `uuid-{modid}-{repeating digits}` (e.g., `uuid-500-500500500500500500`) |
| `val` | float | Primary rolled value (between val1min-val1max) |
| `val2` | float | Secondary rolled value (between val2min-val2max, or 0 if unused) |
| `val1min` | float | Primary range minimum |
| `val1max` | float | Primary range maximum (equal to min = fixed value) |
| `val2min` | float | Secondary range minimum (0 if unused) |
| `val2max` | float | Secondary range maximum (0 if unused) |
| `name` | string | ALL CAPS WITH SPACES (e.g., `FIRE RATE NANITES`, `STANDARD GUN`) |
| `desc` | string | Sentence case, uses "val1" and "val2" as placeholders |
| `modweight` | int | 0=never random, 3-5=rare, 7-10=uncommon, 100-200=common, 600=very common |
| `type` | int | 0=passive, 2=weapon, 4=melee, 10=upgrade, 20=permanent |
| `hasProc` | int | 0 or 1 (use 0 for most mods) |
| `equation` | string | HEL equation with prefixes: `B_STATNAME=val1;M_OTHERSTAT=val2` (empty string for no mods) |
| `modColor` | object | `{r: 0, g: 0, b: 0, a: 0}` (use all zeros unless specific visual need) |
| `armorEffectName` | string | Empty `''` unless visual effect needed |
| `armorMeshName` | string | Empty `''` unless armor mesh needed |

## Naming Conventions

**Stats:**
- Format: `UPPERCASENOСПACES`
- Examples: `PLAYERSPEED`, `HPREGEN`, `MAXSTAMINA`

**Stat Descriptions:**
- Format: Sentence case, no period
- Examples: "How fast you run", "The damage of your projectiles"

**Mods:**
- Format: `ALL CAPS WITH SPACES`
- Patterns: `[EFFECT] NANITES` (passive), `[WEAPON TYPE]` (weapons), `[STAT] NANITES` (upgrades)

**Mod Descriptions:**
- Use "val1" and "val2" as placeholders
- Include units (%, damage, etc.)
- Example: "Lowers gun damage by val1% and increases effective proc rate by val2%"

**Equations:**
- Use lowercase: `val1`, `val2` (never `VAL` or `val`)

## Value Range Guidelines

| Stat Type | Range | Examples |
|-----------|-------|----------|
| Percentages/Probabilities | 0 to 1 | ACCURACY, HPREGEN, IGNITECHANCE |
| Absolute Values | 0 to 5000 | HP, GUNDAMAGE, PLAYERSPEED, BULLETSFIRED |
| Negative-Allowed | -5000 to 5000 | GRAVITY only |

**Typical Defaults:**
- HP: 100 (0-5000)
- Percentages: 0-1 (0.5 = 50%)
- Speeds: 100-500 (0-5000)
- Damage: 5-20 (0-5000)

## Mod Type Codes

| Type | Category | ID Range | Characteristics |
|------|----------|----------|-----------------|
| 0 | Passive Modifiers | 0-499 | Trade-offs, usually "XXX NANITES" |
| 2 | Weapons | 500-599 | Mutually exclusive, base=500 |
| 4 | Melee Weapons | 800-899 | Base=800 |
| 10 | Upgrade Nanites | 5000-5999 | Pure buffs, no trade-offs |
| 20 | Permanent Upgrades | 6000-6999 | Progression/starting bonuses |

## UUID Pattern

**Format:** `uuid-{modid}-{repeating digits}`

**Rules:**
- If modid < 100: repeat to 18 digits (`uuid-42-424242424242424242`)
- If modid >= 100: repeat to 24 digits (`uuid-5000-500050005000500050005000`)
- Must be globally unique

## HEL Equation Prefixes

- `B_` = Base additive (adds before multiplication)
- `M_` = Multiplicative (percentage modifier)
- `A_` = Absolute additive (adds after multiplication)
- `Z_` = Minimum value adjustment
- `U_` = Maximum value override

## Complete Examples

### Stat Example
```yaml
- name: GUNDAMAGE
  desc: The damage of your projectiles
  value: 10
  min: 0
  max: 5000
```

### Mod Example (Upgrade Type)
```yaml
- modid: 5000
  uuid: uuid-5000-500050005000500050005000
  val: 1
  val2: 0
  val1min: 1
  val1max: 1
  val2min: 0
  val2max: 0
  name: FIRE RATE NANITES
  desc: +val1 bullets fired per second
  modweight: 10
  type: 10
  hasProc: 0
  equation: B_SHOTSPERSEC=val1
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: ''
  armorMeshName: ''
```

## Quick Validation

**Stats:** UPPERCASE name, sentence desc, min ≤ value ≤ max
**Mods:** Unique modid/uuid, type matches ID range, val1/val2 in equations (lowercase), ALL CAPS name
**Common Mistakes:** Wrong case, using "val" instead of "val1", mismatched type/modid range, non-unique IDs
