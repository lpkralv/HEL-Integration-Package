# Acceptable Stat Ranges for Balanced Gameplay
**Version:** 1.0
**Date:** 2025-11-17
**Purpose:** Define safe, balanced value ranges for all game stats based on game-breakers analysis

---

## EXECUTIVE SUMMARY

This document defines **acceptable stat ranges** that maintain:
- **Balanced Gameplay** - No single stat dominates or trivializes content
- **Build Diversity** - Multiple viable strategies at different power levels
- **Technical Stability** - No crashes, overflows, or softlocks
- **Player Agency** - Meaningful choices with clear trade-offs

**Range Categories:**
- **Viable Range** - Core gameplay balance, recommended for normal difficulty
- **Extended Range** - Extreme builds, hard mode, high-risk strategies
- **Absolute Limits** - Technical boundaries, never exceed

---

## RANGE CLASSIFICATION SYSTEM

### Range Tiers

**TIER 1: VIABLE RANGE** (Recommended)
- Supports balanced gameplay across all difficulty modes
- No single build archetype dominates
- Preserves core game mechanics and challenge
- **Use Case:** Normal/Hard difficulty, balanced builds

**TIER 2: EXTENDED RANGE** (High-Power Builds)
- Allows extreme specialization with trade-offs
- May trivialize certain content but retains challenge overall
- Enables "glass cannon" or "immortal tank" fantasies
- **Use Case:** Extreme builds, player mastery, "easy mode"

**TIER 3: ABSOLUTE LIMITS** (Technical Boundaries)
- Hard caps to prevent crashes and softlocks
- Values beyond these cause technical failures
- Should never be reached in normal gameplay
- **Use Case:** Validation bounds, anti-cheat, debug testing

---

## STAT RANGES BY CATEGORY

## CATEGORY 1: CORE COMBAT STATS

### 1. CRITCHANCE (Critical Strike Chance)
**Current Default:** 0.05 (5%)
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.5 (50%) | Balanced crit frequency, skill matters |
| **Extended** | 0.0 | 0.75 (75%) | High-crit builds, still has variance |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents 100% crit invulnerability |

**Recommended Build Ranges:**
- Baseline (no crit build): `0.05 - 0.10` (5-10%)
- Crit-focused build: `0.30 - 0.50` (30-50%)
- Glass Cannon (extreme): `0.60 - 0.75` (60-75%)

**Design Notes:**
- Keep below 95% to preserve damage variance
- Pair high crit chance with CRITDAMAGE for synergy
- Balance by reducing other defensive stats

---

### 2. CRITDAMAGE (Critical Damage Multiplier)
**Current Default:** 1.5 (150%)
**Stat Type:** Multiplier

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 1.5 | 3.0 (300%) | 2-3x damage on crits |
| **Extended** | 1.5 | 5.0 (500%) | Glass cannon builds |
| **Absolute** | 1.0 | 20.0 (2000%) | Prevents integer overflow |

**Recommended Build Ranges:**
- Baseline: `1.5 - 2.0` (150-200%)
- Crit-focused: `2.5 - 3.5` (250-350%)
- Glass Cannon (extreme): `4.0 - 5.0` (400-500%)

**Design Notes:**
- Minimum 1.0 ensures crits never deal LESS damage
- High CRITDAMAGE should trade off survivability
- Synergizes with CRITCHANCE for burst builds

---

### 3. PROJECTILESPEED (Projectile Velocity)
**Current Default:** 300 units/sec
**Stat Type:** Velocity

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 100 | 800 | Balanced dodge mechanics |
| **Extended** | 50 | 2000 | Slow artillery or hitscan-like |
| **Absolute** | 10 | 5000 | Prevents wall clipping |

**Recommended Build Ranges:**
- Slow artillery: `50 - 150`
- Standard projectiles: `200 - 500`
- Fast railgun: `600 - 1200`

**Design Notes:**
- Below 100 requires prediction, enables dodging
- Above 800 becomes hitscan-like, reduces skill
- Balance by adjusting damage inversely

---

### 4. PIERCINGSHOTS (Projectile Penetration Count)
**Current Default:** 0
**Stat Type:** Integer Count

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 5 | Rewards positioning, manageable |
| **Extended** | 0 | 10 | Wave-clear builds |
| **Absolute** | 0 | 50 | Prevents stack overflow |

**Recommended Build Ranges:**
- No pierce: `0`
- Moderate pierce: `2 - 5`
- Wave-clear specialist: `6 - 10`

**Design Notes:**
- High pierce trivializes grouped enemies
- Balance with reduced single-target damage
- Synergizes with CHAINLIGHTNING for AoE builds

---

### 5. RELOADSPEED (Reload Time Modifier)
**Current Default:** 1.0
**Stat Type:** Multiplier

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.5 (2x faster) | 2.0 (2x slower) | Meaningful reload mechanic |
| **Extended** | 0.2 (5x faster) | 5.0 (5x slower) | Extreme builds |
| **Absolute** | 0.1 | 10.0 | Prevents div-by-zero |

**Recommended Build Ranges:**
- Fast reload build: `0.3 - 0.6` (3x - 1.7x faster)
- Baseline: `0.8 - 1.2`
- Heavy weapon (slow reload): `1.5 - 3.0`

**Design Notes:**
- **CRITICAL:** Never allow zero (div-by-zero crash)
- Fast reload enables spray-and-pray builds
- Slow reload forces precision, higher damage per shot

---

### 6. AMMOCAPACITY (Magazine Size)
**Current Default:** 30
**Stat Type:** Integer Count

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 10 | 100 | Regular reload cycles |
| **Extended** | 5 | 300 | Tiny mags or never reload |
| **Absolute** | 1 | 500 | Prevents UI overflow |

**Recommended Build Ranges:**
- Sniper/precision: `5 - 15`
- Standard rifle: `20 - 50`
- LMG/spray build: `75 - 150`

**Design Notes:**
- Minimum 1 to allow firing
- High capacity trades reload downtime for lower burst
- Balance with RELOADSPEED and fire rate

---

### 7. LIFESTEAL (Damage-to-Health Conversion %)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.20 (20%) | Sustain without invulnerability |
| **Extended** | 0.0 | 0.40 (40%) | High sustain, vampire builds |
| **Absolute** | 0.0 | 0.75 (75%) | Prevents functional immortality |

**Recommended Build Ranges:**
- No sustain: `0.0`
- Light sustain: `0.05 - 0.15` (5-15%)
- Vampire build: `0.25 - 0.40` (25-40%)

**Design Notes:**
- Above 50% creates near-invulnerability
- Balance by reducing max HP or armor
- Synergizes with high attack speed

---

### 8. CHAINLIGHTNING (Electric Arc Target Count)
**Current Default:** 0
**Stat Type:** Integer Count

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 5 | Manageable AoE clear |
| **Extended** | 0 | 10 | Wave-clear specialist |
| **Absolute** | 0 | 20 | Prevents stack overflow |

**Recommended Build Ranges:**
- No chain: `0`
- Light AoE: `2 - 4`
- AoE specialist: `6 - 10`

**Design Notes:**
- High chain count trivializes grouped enemies
- Balance with reduced single-target damage
- Synergizes with PIERCINGSHOTS for AoE builds

---

## CATEGORY 2: DEFENSE/SURVIVAL STATS

### 9. ARMOR (Damage Mitigation)
**Current Default:** 50
**Stat Type:** Integer (formula-dependent)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 200 | Assuming `damage * (100/(100+armor))` formula |
| **Extended** | 0 | 500 | High mitigation, tank builds |
| **Absolute** | 0 | 2000 | Prevents near-invulnerability |

**Recommended Build Ranges:**
- Glass cannon (no armor): `0 - 30`
- Balanced: `50 - 150`
- Tank build: `200 - 400`

**Design Notes:**
- Formula matters: `damage/(1+armor/100)` vs `damage*(1-armor/(armor+K))`
- High armor should reduce mobility or damage
- Synergizes with HP and resistances

---

### 10. SHIELDCAPACITY (Shield HP Pool)
**Current Default:** 50
**Stat Type:** Integer

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 200 | Moderate extra HP layer |
| **Extended** | 0 | 1000 | Shield-focused builds |
| **Absolute** | 0 | 10000 | Prevents excessive tankiness |

**Recommended Build Ranges:**
- No shield: `0`
- Balanced: `50 - 150`
- Shield tank: `300 - 800`

**Design Notes:**
- Shield as second HP bar
- Balance regen rate with capacity
- Synergizes with SHIELDREGENRATE

---

### 11. SHIELDREGENRATE (Shield Regeneration/sec)
**Current Default:** 5
**Stat Type:** Numeric (HP/sec)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 20 | Regenerates over 2.5-10 seconds |
| **Extended** | 0 | 100 | Fast regen, vulnerability windows |
| **Absolute** | 0 | 500 | Prevents instant regen |

**Recommended Build Ranges:**
- No regen: `0`
- Slow regen: `5 - 15`
- Fast regen: `30 - 80`

**Design Notes:**
- High regen requires low capacity for balance
- Preserve vulnerability window (time to break shield)
- Synergizes with SHIELDCAPACITY

---

### 12. DODGECHANCE (Evasion Probability)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.30 (30%) | Noticeable but not reliable |
| **Extended** | 0.0 | 0.60 (60%) | High evasion builds |
| **Absolute** | 0.0 | 0.85 (85%) | Prevents functional invulnerability |

**Recommended Build Ranges:**
- No evasion: `0.0`
- Light evasion: `0.10 - 0.25` (10-25%)
- Evasion specialist: `0.40 - 0.60` (40-60%)

**Design Notes:**
- Above 85% becomes too reliable
- Balance by reducing armor/HP
- RNG-based, frustrating at extreme values

---

### 13. DAMAGEABSORPTION (Flat Damage Reduction)
**Current Default:** 0
**Stat Type:** Integer (flat reduction)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 20 | Reduces chip damage |
| **Extended** | 0 | 50 | Significant reduction |
| **Absolute** | 0 | 500 | Prevents negating all small hits |

**Recommended Build Ranges:**
- No absorption: `0`
- Anti-chip damage: `5 - 15`
- Tank absorption: `25 - 50`

**Design Notes:**
- More effective against many small hits
- Less effective against boss burst damage
- Synergizes with high armor for double mitigation

---

### 14. THORNDAMAGE (Reflect Flat Damage)
**Current Default:** 0
**Stat Type:** Integer (flat damage)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 20 | Punishes attackers moderately |
| **Extended** | 0 | 100 | Reflects kill weak enemies |
| **Absolute** | 0 | 500 | Prevents instakilling melee enemies |

**Recommended Build Ranges:**
- No thorns: `0`
- Light thorns: `5 - 20`
- Thorn tank: `40 - 100`

**Design Notes:**
- High thorn damage trivializes melee enemies
- Balance by reducing direct damage output
- Synergizes with REFLECTDAMAGE

---

### 15. REFLECTDAMAGE (Reflect Percentage)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.20 (20%) | Modest reflection |
| **Extended** | 0.0 | 0.50 (50%) | Significant reflection |
| **Absolute** | 0.0 | 0.75 (75%) | Prevents enemies suiciding |

**Recommended Build Ranges:**
- No reflect: `0.0`
- Light reflect: `0.10 - 0.25` (10-25%)
- Reflect tank: `0.35 - 0.50` (35-50%)

**Design Notes:**
- Above 50% enemies kill themselves quickly
- Balance by reducing direct damage
- Synergizes with THORNDAMAGE

---

### 16. MAXHPPERCENTBONUS (Max HP Multiplier)
**Current Default:** 0 (100% base HP)
**Stat Type:** Percentage bonus

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | -0.20 (-20%) | 1.0 (+100%, 2x HP) | Meaningful HP variation |
| **Extended** | -0.40 (-40%) | 3.0 (+300%, 4x HP) | Glass cannon or super tank |
| **Absolute** | -0.50 (-50%) | 10.0 (+1000%, 11x HP) | Prevents zero HP or extreme values |

**Recommended Build Ranges:**
- Glass cannon: `-0.30 to -0.10` (70-90% HP)
- Balanced: `0.0 to 0.5` (100-150% HP)
- Tank: `1.0 to 2.0` (200-300% HP)

**Design Notes:**
- **CRITICAL:** Ensure final HP never reaches zero
- High HP should reduce damage or mobility
- Synergizes with HPREGEN for sustain

---

## CATEGORY 3: RESOURCE MANAGEMENT STATS

### 17. ENERGYCAPACITY (Max Energy Pool)
**Current Default:** 100
**Stat Type:** Integer

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 50 | 300 | 2-6 ability casts |
| **Extended** | 30 | 1000 | Tiny pool or massive reserves |
| **Absolute** | 10 | 5000 | Prevents ability lock/spam |

**Recommended Build Ranges:**
- Low capacity, fast regen: `50 - 100`
- Balanced: `100 - 200`
- High capacity, slow regen: `300 - 600`

**Design Notes:**
- Balance capacity with ENERGYREGEN
- Low capacity forces resource management
- High capacity enables burst ability rotations

---

### 18. ENERGYREGEN (Energy Regeneration/sec)
**Current Default:** 10
**Stat Type:** Numeric (energy/sec)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 5 | 30 | 3-20 second full recharge |
| **Extended** | 2 | 100 | Slow regen or near-instant |
| **Absolute** | 0 | 1000 | Prevents ability spam |

**Recommended Build Ranges:**
- Slow regen, high capacity: `5 - 10`
- Balanced: `10 - 25`
- Fast regen, low capacity: `40 - 80`

**Design Notes:**
- Balance with ENERGYCAPACITY
- High regen enables ability-focused builds
- Synergizes with RESOURCEEFFICIENCY

---

### 19. COOLDOWNREDUCTION (Ability CD Reduction %)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.40 (40%) | Meaningful CD reduction |
| **Extended** | 0.0 | 0.70 (70%) | Low cooldown builds |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents div-by-zero at 100% |

**Recommended Build Ranges:**
- No CDR: `0.0`
- Moderate CDR: `0.20 - 0.40` (20-40%)
- CDR specialist: `0.50 - 0.70` (50-70%)

**Design Notes:**
- **CRITICAL:** Never allow 100% (div-by-zero risk)
- Use formula `base_cd * (1 - reduction)` NOT division
- Balance by reducing direct damage stats

---

### 20. RESOURCEEFFICIENCY (Resource Cost Reduction %)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.40 (40%) | Meaningful cost reduction |
| **Extended** | 0.0 | 0.70 (70%) | Low-cost builds |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents free abilities at 100% |

**Recommended Build Ranges:**
- No efficiency: `0.0`
- Moderate efficiency: `0.20 - 0.40` (20-40%)
- Efficiency specialist: `0.50 - 0.70` (50-70%)

**Design Notes:**
- Never allow 100% (free abilities)
- Balance by reducing damage or survivability
- Synergizes with ENERGYREGEN and COOLDOWNREDUCTION

---

### 21. DASHCOOLDOWN (Dash Ability Cooldown)
**Current Default:** 3.0 seconds
**Stat Type:** Numeric (seconds)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 1.0 | 10.0 | Frequent mobility option |
| **Extended** | 0.5 | 20.0 | Near-flight or restricted |
| **Absolute** | 0.1 | 30.0 | Prevents infinite dash/never dash |

**Recommended Build Ranges:**
- Mobility specialist: `0.5 - 1.5`
- Balanced: `2.0 - 5.0`
- Heavy/slow build: `7.0 - 15.0`

**Design Notes:**
- Below 0.5s enables effective flight
- Balance with movement speed and dash distance
- Synergizes with COOLDOWNREDUCTION

---

## CATEGORY 4: ELEMENTAL STATS

### 22. CORRUPTIONCHANCE (Corruption DoT Application %)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.40 (40%) | Frequent but not guaranteed |
| **Extended** | 0.0 | 0.70 (70%) | DoT specialist |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents 100% application |

**Recommended Build Ranges:**
- No corruption: `0.0`
- Light DoT: `0.15 - 0.35` (15-35%)
- DoT specialist: `0.50 - 0.70` (50-70%)

**Design Notes:**
- High application requires low base damage for balance
- Synergizes with CORRUPTIONDAMAGE
- Balance with proc frequency (attack speed)

---

### 23. CORRUPTIONDAMAGE (Corruption DoT Damage/tick)
**Current Default:** 0
**Stat Type:** Integer (damage/tick)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 50 | Meaningful but not overwhelming |
| **Extended** | 0 | 150 | High DoT builds |
| **Absolute** | 0 | 500 | Prevents instant death |

**Recommended Build Ranges:**
- No DoT: `0`
- Light DoT: `10 - 30`
- DoT specialist: `60 - 120`

**Design Notes:**
- Balance damage with tick rate (DPS = damage * ticks/sec)
- Synergizes with CORRUPTIONCHANCE
- High DoT should reduce direct damage

---

### 24. ELEMENTALPENETRATION (Elemental Resistance Bypass %)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.40 (40%) | Meaningful penetration |
| **Extended** | 0.0 | 0.65 (65%) | High penetration builds |
| **Absolute** | 0.0 | 0.85 (85%) | Prevents full resistance bypass |

**Recommended Build Ranges:**
- No penetration: `0.0`
- Moderate penetration: `0.20 - 0.40` (20-40%)
- Penetration specialist: `0.50 - 0.65` (50-65%)

**Design Notes:**
- Effectiveness depends on enemy resistance values
- Synergizes with elemental damage builds
- Balance by reducing raw damage output

---

### 25. IGNITESPREAD (Ignite Chain Range)
**Current Default:** 0
**Stat Type:** Numeric (units)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 5 | Close-range spread |
| **Extended** | 0 | 10 | Medium-range spread |
| **Absolute** | 0 | 15 | Prevents screen-wide spread |

**Recommended Build Ranges:**
- No spread: `0`
- Light spread: `3 - 6`
- Spread specialist: `8 - 12`

**Design Notes:**
- High spread trivializes grouped enemies
- Balance with direct damage reduction
- Synergizes with IGNITECHANCE and IGNITEDAMAGE

---

### 26-27. IGNITECHANCE, CHARGECHANCE (Elemental Status %)
**Current Default:** 0
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.40 (40%) | Frequent but not guaranteed |
| **Extended** | 0.0 | 0.70 (70%) | Status specialist |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents 100% application |

**Recommended Build Ranges:**
- No status: `0.0`
- Light status: `0.15 - 0.35` (15-35%)
- Status specialist: `0.50 - 0.70` (50-70%)

**Design Notes:**
- Balance with corresponding damage stats
- High proc chance requires low base damage
- Synergizes with attack speed

---

### 28-29. IGNITEDAMAGE, CHARGEDAMAGE (Elemental DoT Damage)
**Current Default:** 0
**Stat Type:** Integer (damage/tick)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 50 | Meaningful DoT |
| **Extended** | 0 | 150 | High DoT builds |
| **Absolute** | 0 | 500 | Prevents instant death |

**Recommended Build Ranges:**
- No DoT: `0`
- Light DoT: `10 - 30`
- DoT specialist: `60 - 120`

**Design Notes:**
- Balance with tick rate and proc chance
- Synergizes with corresponding chance stats
- High DoT trades off direct damage

---

## CATEGORY 5: MINION/SUMMONER STATS

### 30. MINIONDAMAGE (Minion Damage Multiplier)
**Current Default:** 1.0 (100%)
**Stat Type:** Multiplier

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.5 (50%) | 3.0 (300%) | Balanced minion power |
| **Extended** | 0.25 (25%) | 7.0 (700%) | Weak or powerful minions |
| **Absolute** | 0.1 (10%) | 20.0 (2000%) | Prevents useless/godlike minions |

**Recommended Build Ranges:**
- Weak minions: `0.5 - 0.8`
- Balanced: `1.0 - 2.0`
- Summoner specialist: `3.0 - 6.0`

**Design Notes:**
- Balance with player damage (summoner vs hybrid)
- Synergizes with NUMMINIONS
- High minion damage trades off personal damage

---

### 31. MINIONHP (Minion HP Multiplier)
**Current Default:** 1.0 (100%)
**Stat Type:** Multiplier

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.5 (50%) | 3.0 (300%) | Balanced minion survivability |
| **Extended** | 0.25 (25%) | 7.0 (700%) | Glass or tanky minions |
| **Absolute** | 0.1 (10%) | 20.0 (2000%) | Prevents instadeath/unkillable minions |

**Recommended Build Ranges:**
- Glass minions: `0.5 - 0.8`
- Balanced: `1.0 - 2.0`
- Tank minions: `3.0 - 6.0`

**Design Notes:**
- **CRITICAL:** Ensure final minion HP > 0
- Balance with minion count and damage
- Synergizes with MINIONATTACKSPEED for tanky DPS

---

### 32. MINIONATTACKSPEED (Minion Attack Speed Multiplier)
**Current Default:** 1.0 (100%)
**Stat Type:** Multiplier

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.5 (50%) | 2.5 (250%) | Balanced minion DPS |
| **Extended** | 0.25 (25%) | 5.0 (500%) | Slow or rapid minions |
| **Absolute** | 0.1 (10%) | 10.0 (1000%) | Prevents div-by-zero/animation overload |

**Recommended Build Ranges:**
- Slow heavy minions: `0.5 - 0.8`
- Balanced: `1.0 - 2.0`
- Rapid attack minions: `3.0 - 5.0`

**Design Notes:**
- **CRITICAL:** Never allow zero (div-by-zero risk)
- Balance with minion damage (DPS = damage * speed)
- High speed may lag game with many minions

---

### 33. NUMMINIONS (Maximum Minion Count)
**Current Default:** Unknown
**Stat Type:** Integer Count

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 1 | 10 | Manageable army |
| **Extended** | 1 | 25 | Large minion swarm |
| **Absolute** | 0 | 50 | Prevents performance crash |

**Recommended Build Ranges:**
- Few strong minions: `1 - 3`
- Balanced: `4 - 8`
- Swarm army: `12 - 20`

**Design Notes:**
- High count trades off minion quality (HP/damage)
- Performance concerns with 20+ AI agents
- Synergizes with minion stat multipliers

---

## CATEGORY 6: MOVEMENT STATS

### 34. PLAYERSPEED (Movement Speed)
**Current Default:** Unknown (~5-10 units/sec)
**Stat Type:** Numeric (units/sec)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 3.0 | 15.0 | Controllable movement |
| **Extended** | 2.0 | 30.0 | Slow tank or speed demon |
| **Absolute** | 1.0 | 50.0 | Prevents softlock/wall clip |

**Recommended Build Ranges:**
- Tank (slow): `3.0 - 5.0`
- Balanced: `6.0 - 12.0`
- Speed demon: `18.0 - 30.0`

**Design Notes:**
- **CRITICAL:** Never allow zero (softlock)
- High speed trades off armor/HP
- Balance with dash cooldown and sprint

---

### 35. SPRINTSPEED (Sprint Speed Multiplier)
**Current Default:** Unknown (~1.5-2.0x)
**Stat Type:** Multiplier

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 1.2 (120%) | 2.0 (200%) | Meaningful sprint |
| **Extended** | 1.1 (110%) | 3.0 (300%) | Slight or major sprint boost |
| **Absolute** | 1.0 (100%) | 5.0 (500%) | Sprint at least as fast as walk |

**Recommended Build Ranges:**
- Low sprint boost: `1.2 - 1.5`
- Balanced: `1.5 - 2.0`
- High sprint boost: `2.5 - 3.0`

**Design Notes:**
- Minimum 1.0 (sprint >= walk speed)
- Balance with stamina drain rate
- Synergizes with STAMINAREGEN

---

### 36. JUMPSTRENGTH (Jump Force)
**Current Default:** Unknown
**Stat Type:** Numeric (force/velocity)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.8 (80% base) | 2.0 (200% base) | Moderate jump variation |
| **Extended** | 0.5 (50% base) | 5.0 (500% base) | Low or super jump |
| **Absolute** | 0.5 | 20.0 | Prevents softlock/out of bounds |

**Recommended Build Ranges:**
- Low jump (heavy): `0.6 - 0.9`
- Balanced: `1.0 - 1.5`
- High jump (mobility): `2.0 - 4.0`

**Design Notes:**
- **CRITICAL:** Ensure can jump over required obstacles
- High jump enables sequence breaks
- Balance with PLAYERSPEED for mobility builds

---

### 37. DASHSPEED (Dash Velocity)
**Current Default:** Unknown
**Stat Type:** Numeric (velocity)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 10 | 40 | Meaningful dash distance |
| **Extended** | 5 | 80 | Short hop or long dash |
| **Absolute** | 5 | 100 | Prevents useless dash/wall clip |

**Recommended Build Ranges:**
- Short dash: `10 - 20`
- Balanced: `25 - 45`
- Long dash: `55 - 80`

**Design Notes:**
- Balance with DASHCOOLDOWN (distance vs frequency)
- High dash speed may clip through thin walls
- Synergizes with mobility builds

---

## CATEGORY 7: WEAPON STATS

### 38. GUNDAMAGE (Ranged Weapon Damage)
**Current Default:** Unknown
**Stat Type:** Integer

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 5 | 200 | Balanced TTK (time to kill) |
| **Extended** | 2 | 1000 | Low DPS or burst build |
| **Absolute** | 1 | 10000 | Prevents softlock/one-shot all |

**Recommended Build Ranges:**
- Rapid fire, low damage: `5 - 20`
- Balanced: `30 - 80`
- Slow burst, high damage: `100 - 300`

**Design Notes:**
- Balance with fire rate (DPS = damage * fire_rate)
- **CRITICAL:** Ensure > 0 on required weapons
- Synergizes with CRITDAMAGE for burst builds

---

### 39. MELEEDAMAGE (Melee Weapon Damage)
**Current Default:** Unknown
**Stat Type:** Integer

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 10 | 300 | Higher than gun for risk/reward |
| **Extended** | 5 | 1500 | Low or extreme melee damage |
| **Absolute** | 1 | 10000 | Prevents softlock/one-shot all |

**Recommended Build Ranges:**
- Fast swipe, low damage: `10 - 40`
- Balanced: `50 - 150`
- Heavy slam: `200 - 600`

**Design Notes:**
- Higher than gun damage (melee risk/reward)
- Balance with MELEESPEED (DPS = damage * speed)
- Synergizes with MELEECRITCHANCE

---

### 40. SHOTSPERSEC (Fire Rate)
**Current Default:** Unknown
**Stat Type:** Numeric (shots/sec)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.5 | 10.0 | Slow to fast fire |
| **Extended** | 0.2 | 25.0 | Very slow or machine gun |
| **Absolute** | 0.1 | 50.0 | Prevents div-by-zero/animation overload |

**Recommended Build Ranges:**
- Slow sniper: `0.5 - 2.0`
- Balanced rifle: `3.0 - 8.0`
- Machine gun: `12.0 - 25.0`

**Design Notes:**
- **CRITICAL:** Never allow zero (div-by-zero crash)
- Balance with damage (DPS = damage * fire_rate)
- High fire rate requires low damage

---

### 41. ACCURACY (Weapon Accuracy)
**Current Default:** Unknown (0-1 or angle)
**Stat Type:** Percentage [0-1] or Angle (degrees)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.6 (60%) | 1.0 (100%) | Usable to perfect accuracy |
| **Extended** | 0.3 (30%) | 1.0 (100%) | High spread to perfect |
| **Absolute** | 0.0 | 1.0 | Full range if percentage |

**If angle-based (spread in degrees):**

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0° | 10° | Tight to moderate spread |
| **Extended** | 0° | 25° | Shotgun-like spread |
| **Absolute** | 0° | 30° | Prevents unusable weapons |

**Recommended Build Ranges:**
- Sniper (high accuracy): 0.9-1.0 or 0-2°
- Rifle (moderate): 0.7-0.85 or 5-10°
- Shotgun (low): 0.3-0.6 or 15-25°

**Design Notes:**
- Perfect accuracy enables long-range dominance
- Low accuracy requires close range, higher damage
- Balance inversely with range

---

### 42. RANGE (Weapon Range)
**Current Default:** Unknown
**Stat Type:** Numeric (units)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 15 | 500 | Close to long range |
| **Extended** | 10 | 2000 | Melee-gun to sniper |
| **Absolute** | 10 | 5000 | Prevents useless/map-wide weapons |

**Recommended Build Ranges:**
- Close-range: `15 - 50`
- Medium-range: `75 - 200`
- Sniper: `300 - 1000`

**Design Notes:**
- Balance with damage (high range = lower damage)
- Long range requires good accuracy
- Short range enables higher DPS

---

### 43. BULLETSFIRED (Projectiles Per Shot)
**Current Default:** 1
**Stat Type:** Integer Count

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 1 | 5 | Single shot to shotgun |
| **Extended** | 1 | 12 | Large shotgun spread |
| **Absolute** | 1 | 20 | Prevents entity spawn crash |

**Recommended Build Ranges:**
- Single shot: `1`
- Light shotgun: `3 - 5`
- Heavy shotgun: `7 - 12`

**Design Notes:**
- **CRITICAL:** Never allow zero (softlock)
- Multiple bullets trade accuracy for coverage
- Balance with damage per bullet

---

### 44. BULLETSPEED (Projectile Velocity)
**Current Default:** Unknown
**Stat Type:** Numeric (velocity)

**Same as PROJECTILESPEED (#3)**

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 100 | 800 | Balanced dodge mechanics |
| **Extended** | 50 | 2000 | Slow artillery or hitscan |
| **Absolute** | 10 | 5000 | Prevents wall clipping |

---

### 45. EXPLOSIONRADIUS (AoE Blast Radius)
**Current Default:** Unknown
**Stat Type:** Numeric (units)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 2 | 15 | Small to medium AoE |
| **Extended** | 1 | 35 | Tiny or large blast |
| **Absolute** | 1 | 50 | Prevents screen-wide explosions |

**Recommended Build Ranges:**
- Small grenade: `3 - 8`
- Standard explosive: `10 - 18`
- Large bomb: `22 - 35`

**Design Notes:**
- Large radius trivializes grouped enemies
- Balance with damage and reload time
- Synergizes with AoE-focused builds

---

### 46-47. MELEERANGE, MELEESPEED (Melee Stats)
**Current Default:** Unknown
**Stat Type:** Numeric

**MELEERANGE (attack reach in units):**

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 2 | 8 | Fist to polearm |
| **Extended** | 1.5 | 15 | Very short or long reach |
| **Absolute** | 1 | 20 | Prevents useless/ranged melee |

**Recommended Build Ranges:**
- Fist/dagger: `2 - 4`
- Sword: `4 - 7`
- Polearm: `8 - 15`

**MELEESPEED (attacks per second):**

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.5 | 5.0 | Slow to rapid swings |
| **Extended** | 0.3 | 10.0 | Very slow or blur-fast |
| **Absolute** | 0.1 | 20.0 | Prevents div-by-zero/animation overload |

**Recommended Build Ranges:**
- Heavy slam: `0.5 - 1.5`
- Balanced: `2.0 - 4.0`
- Rapid slash: `5.0 - 10.0`

**Design Notes:**
- **CRITICAL:** Never allow zero speed (div-by-zero)
- Balance range and speed inversely (long reach = slow)
- Balance speed with damage (DPS = damage * speed)

---

## CATEGORY 8: RESISTANCE STATS

### 48-50. FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE
**Current Default:** 0
**Stat Type:** Percentage [0-1] (0-100%)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | -0.20 (-20%) | 0.60 (60%) | Weakness to strong resist |
| **Extended** | -0.50 (-50%) | 0.85 (85%) | Extreme weakness or near-immunity |
| **Absolute** | -0.50 (-50%) | 0.95 (95%) | Prevents full immunity/death spiral |

**Recommended Build Ranges:**
- Elemental weakness: `-0.30 to -0.10` (take 10-30% extra damage)
- Baseline: `0.0 to 0.20` (0-20% resist)
- Elemental specialist: `0.40 to 0.70` (40-70% resist)

**Design Notes:**
- Allow negative for build trade-offs (damage for weakness)
- Cap below 100% to preserve threat from element
- Balance resistances across elements (don't stack all)

---

## CATEGORY 9: SPECIAL/MISC STATS

### 51. PROCRATE (Status Effect Proc Chance)
**Current Default:** Unknown
**Stat Type:** Percentage [0-1]

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.40 (40%) | Frequent but not guaranteed |
| **Extended** | 0.0 | 0.70 (70%) | High proc builds |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents 100% proc |

**Recommended Build Ranges:**
- No proc: `0.0`
- Light proc: `0.15 - 0.35` (15-35%)
- Proc specialist: `0.50 - 0.70` (50-70%)

---

### 52. PROCRANGE (Status Effect AoE)
**Current Default:** Unknown
**Stat Type:** Numeric (units)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 10 | Close to medium range |
| **Extended** | 0 | 20 | Large AoE procs |
| **Absolute** | 0 | 30 | Prevents screen-wide procs |

**Recommended Build Ranges:**
- No AoE: `0`
- Small AoE: `3 - 8`
- Large AoE: `12 - 20`

---

### 53. HP (Player Health Points)
**Current Default:** Unknown (~100-500)
**Stat Type:** Integer

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 50 | 500 | Glass to tanky |
| **Extended** | 25 | 2000 | Extreme glass or super tank |
| **Absolute** | 1 | 100000 | Prevents death/unkillable |

**Recommended Build Ranges:**
- Glass cannon: `50 - 100`
- Balanced: `150 - 300`
- Tank: `400 - 1000`

**Design Notes:**
- **CRITICAL:** Never allow <=0 outside death state
- Balance with armor and resistances
- Synergizes with HPREGEN and LIFESTEAL

---

### 54. ENERGY, STAMINA (Resource Pools)
**Current Default:** Unknown
**Stat Type:** Integer

**Same principles as ENERGYCAPACITY:**

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 50 | 300 | Moderate pool |
| **Extended** | 30 | 1000 | Small or large pool |
| **Absolute** | 10 | 10000 | Prevents softlock/infinite resources |

---

### 55. HPREGEN (HP Regeneration/sec)
**Current Default:** Unknown
**Stat Type:** Numeric (HP/sec)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 10 | Slow to moderate regen |
| **Extended** | 0 | 50 | Fast regen |
| **Absolute** | 0 | 1000 | Prevents instant regen |

**Recommended Build Ranges:**
- No regen: `0`
- Slow regen: `2 - 8`
- Moderate regen: `10 - 30`
- Fast regen (trade-off build): `40 - 80`

**Design Notes:**
- High regen trades off max HP or armor
- Synergizes with LIFESTEAL for sustain builds
- Balance with combat intensity

---

### 56. STAMINAREGEN (Stamina Regeneration/sec)
**Current Default:** Unknown
**Stat Type:** Numeric (stamina/sec)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 5 | 30 | Moderate to fast regen |
| **Extended** | 2 | 100 | Slow or very fast regen |
| **Absolute** | 0 | 1000 | Prevents stamina lock/infinite stamina |

**Recommended Build Ranges:**
- Slow regen: `5 - 12`
- Balanced: `15 - 35`
- Fast regen: `45 - 80`

**Design Notes:**
- Balance with sprint cost and dash cost
- Synergizes with SPRINTSPEED
- Low regen forces stamina management

---

### 57. SHIELDONKILL (Shield Gained On Kill)
**Current Default:** 0
**Stat Type:** Integer (flat shield gained)

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0 | 20 | Modest sustain |
| **Extended** | 0 | 100 | Significant shield gain |
| **Absolute** | 0 | 500 | Prevents full shield on every kill |

**Recommended Build Ranges:**
- No on-kill: `0`
- Light sustain: `5 - 15`
- Aggressive sustain: `25 - 80`

**Design Notes:**
- Rewards aggressive play
- Synergizes with SHIELDCAPACITY
- Balance by reducing base regen

---

### 58. MELEECRITCHANCE (Melee Critical Chance)
**Current Default:** ~0.05 (5%)
**Stat Type:** Percentage [0-1]

**Same as CRITCHANCE (#1):**

| Range Type | Minimum | Maximum | Notes |
|------------|---------|---------|-------|
| **Viable** | 0.0 | 0.50 (50%) | Balanced crit frequency |
| **Extended** | 0.0 | 0.75 (75%) | High-crit melee |
| **Absolute** | 0.0 | 0.95 (95%) | Prevents 100% crit |

---

## BUILD ARCHETYPE RECOMMENDATIONS

### Glass Cannon (High Damage, Low Survivability)
**Core Stats:**
- CRITCHANCE: 0.50-0.75 (50-75%)
- CRITDAMAGE: 4.0-5.0 (400-500%)
- GUNDAMAGE: 100-300
- HP: 50-100 (-50% MAXHPPERCENTBONUS)
- ARMOR: 0-30

**Extended Stats:**
- LIFESTEAL: 0.15-0.30 (only sustain)
- DODGECHANCE: 0.20-0.40 (backup defense)
- PLAYERSPEED: 12-20 (mobility over tank)

---

### Fortress Tank (High Survivability, Low Damage)
**Core Stats:**
- HP: 400-1000 (+200-300% MAXHPPERCENTBONUS)
- ARMOR: 200-500
- SHIELDCAPACITY: 300-800
- SHIELDREGENRATE: 30-80
- DAMAGEABSORPTION: 25-50

**Extended Stats:**
- THORNDAMAGE: 40-100
- REFLECTDAMAGE: 0.35-0.50 (35-50%)
- GUNDAMAGE: 30-60 (reduced damage)
- PLAYERSPEED: 3-5 (slow heavy tank)

---

### Summoner Commander (Minion Focus)
**Core Stats:**
- NUMMINIONS: 12-20
- MINIONDAMAGE: 3.0-6.0 (300-600%)
- MINIONHP: 3.0-6.0 (300-600%)
- MINIONATTACKSPEED: 3.0-5.0 (300-500%)
- ENERGYCAPACITY: 300-600

**Extended Stats:**
- ENERGYREGEN: 40-80 (sustain minions)
- RESOURCEEFFICIENCY: 0.40-0.70 (lower ability costs)
- GUNDAMAGE: 20-50 (reduced personal damage)

---

### Elemental Savant (DoT Specialist)
**Core Stats:**
- IGNITECHANCE: 0.50-0.70 (50-70%)
- IGNITEDAMAGE: 60-120
- IGNITESPREAD: 8-12
- CHARGECHANCE: 0.50-0.70
- CHARGEDAMAGE: 60-120
- ELEMENTALPENETRATION: 0.50-0.65 (50-65%)

**Extended Stats:**
- CHAINLIGHTNING: 6-10
- SHOTSPERSEC: 8-15 (apply DoTs quickly)
- GUNDAMAGE: 20-50 (low direct, high DoT)

---

### Speed Demon (Mobility Build)
**Core Stats:**
- PLAYERSPEED: 18-30
- DASHSPEED: 55-80
- DASHCOOLDOWN: 0.5-1.5
- JUMPSTRENGTH: 2.0-4.0
- SPRINTSPEED: 2.5-3.0 (250-300%)

**Extended Stats:**
- DODGECHANCE: 0.40-0.60 (evasion over armor)
- PROJECTILESPEED: 600-1200 (hit fast targets)
- COOLDOWNREDUCTION: 0.50-0.70 (spam mobility)

---

### Precision Sniper (Long-Range Burst)
**Core Stats:**
- CRITCHANCE: 0.30-0.50
- CRITDAMAGE: 2.5-4.0
- ACCURACY: 0.9-1.0 or 0-2° spread
- RANGE: 300-1000
- GUNDAMAGE: 100-300

**Extended Stats:**
- PROJECTILESPEED: 600-1200 (fast bullets)
- SHOTSPERSEC: 0.5-2.0 (slow, powerful shots)
- RELOADSPEED: 1.5-3.0 (slow reload trade-off)
- AMMOCAPACITY: 5-15 (small magazine)

---

### Hybrid Berserker (Melee + Lifesteal)
**Core Stats:**
- MELEEDAMAGE: 200-600
- MELEESPEED: 5.0-10.0
- LIFESTEAL: 0.25-0.40 (25-40%)
- MELEECRITCHANCE: 0.40-0.60
- CRITDAMAGE: 3.0-4.0

**Extended Stats:**
- HP: 200-400 (moderate, sustain through lifesteal)
- PLAYERSPEED: 12-20 (need to close gaps)
- DASHCOOLDOWN: 1.0-2.0 (engage/disengage)

---

### DoT Specialist (Damage Over Time)
**Core Stats:**
- CORRUPTIONCHANCE: 0.50-0.70 (50-70%)
- CORRUPTIONDAMAGE: 60-120
- IGNITECHANCE: 0.50-0.70
- IGNITEDAMAGE: 60-120
- PIERCINGSHOTS: 6-10

**Extended Stats:**
- IGNITESPREAD: 8-12 (spread DoTs)
- ELEMENTALPENETRATION: 0.50-0.65
- SHOTSPERSEC: 8-15 (apply stacks quickly)
- GUNDAMAGE: 10-30 (low direct damage)

---

## VALIDATION GUIDELINES

### Pre-Equipment Validation
Before allowing a player to equip an item/mod:
1. **Calculate final stat values** with all modifiers
2. **Check absolute limits** - Clamp to absolute min/max
3. **Validate required stats** - Ensure movement speed, HP, damage > minimum viable
4. **Warn on extended ranges** - Alert player if entering high-power territory
5. **Block game-breaking combos** - Prevent softlock scenarios

### Runtime Validation
During gameplay calculations:
1. **Clamp all percentages** to [0, 0.95] before probability rolls
2. **Guard division operations** - Ensure denominators never reach zero
3. **Prevent negative HP/resources** - Clamp to 0 or 1 minimum
4. **Cap iteration counts** - Limit pierce, chain, minion spawns
5. **Overflow checks** - Validate damage calculations don't exceed type bounds

### Debug Testing Ranges
For testing extreme scenarios:
- **Minimum viable**: All stats at viable minimum
- **Maximum viable**: All stats at viable maximum
- **Glass cannon extreme**: Max damage, min survivability
- **Immortal tank**: Max survivability, min damage
- **Boundary stress test**: All stats at absolute limits

---

## CONCLUSION

This document defines **acceptable ranges** across 3 tiers for 57+ game stats, organized to:
- **Maintain balance** within viable ranges
- **Enable creativity** through extended ranges
- **Prevent crashes** with absolute limits

**Key Principles:**
1. **Viable ranges** support balanced, challenging gameplay
2. **Extended ranges** enable extreme specialization with trade-offs
3. **Absolute limits** prevent technical failures and softlocks
4. **Build archetypes** demonstrate synergistic stat combinations
5. **Validation systems** enforce limits at equipment and runtime

**Next Steps:**
1. Implement validation system in HEL interpreter
2. Add range metadata to StatsData.asset
3. Create UI warnings for extended ranges
4. Test all build archetypes for balance
5. Gather player feedback on range "feel"

**Related Documents:**
- `/analysis/game-breakers.md` - Dangerous ranges to avoid
- `DELIVERABLE-StatsData.asset` - Current stat definitions
- `docs/DELIVERABLE-Stats-Description.md` - Stat descriptions and mechanics
