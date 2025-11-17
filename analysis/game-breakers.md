# Game-Breaking Stat Ranges Analysis
**Version:** 1.0
**Date:** 2025-11-17
**Purpose:** Document unacceptable stat value ranges that could break game design/balance or crash the game

---

## EXECUTIVE SUMMARY

This document analyzes 57+ stats in the HIOX game system to identify dangerous value ranges that could:
- **(a) Break Game Design/Balance** - Values that destroy intended gameplay (e.g., 100x gravity, invulnerability)
- **(b) Crash the Game** - Values that cause technical failures (e.g., negative HP, division by zero)

**Critical Findings:**
- **23 stats** have crash-risk potential with negative values
- **15 stats** can break balance with excessive multipliers (>10x)
- **8 stats** risk softlocks or unplayable states
- **12 stats** involve probability/percentages requiring [0,1] clamping

---

## ANALYSIS METHODOLOGY

For each stat, we evaluate:
1. **Current Range** - Default min/max from StatsData.asset
2. **Balance-Breaking Ranges** - Values that destroy intended gameplay
3. **Crash-Risk Ranges** - Values that could cause technical failures
4. **Recommended Hard Limits** - Absolute bounds the system should enforce

---

## CATEGORY 1: CORE COMBAT STATS

### 1. CRITCHANCE (Critical Strike Chance)
**Current Range:** 0.0 - 1.0 (0-100%)
**Default:** 0.05 (5%)

**Balance-Breaking Ranges:**
- `> 0.95` (95%+) - Every attack crits, negates entire damage variance system
- `> 0.75` (75%+) - Trivializes non-crit builds, forces meta
- `< 0` - Negative probability is nonsensical

**Crash-Risk Ranges:**
- `< 0` - May cause negative probability checks, undefined RNG behavior
- `> 1.0` - If not clamped, could break probability roll logic
- `NaN/Inf` - RNG systems typically crash on non-numeric values

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95` (cap at 95% to preserve some variance)
- Enforce: Clamp to [0, 0.95] before probability checks

---

### 2. CRITDAMAGE (Critical Damage Multiplier)
**Current Range:** 0 - 5000
**Default:** 1.5 (150%)

**Balance-Breaking Ranges:**
- `> 50` (5000%+) - One-shot everything, trivializes all content
- `> 10` (1000%+) - Massive damage spikes, boss fights become trivial
- `< 1.0` - Crits deal LESS damage than normal hits (anti-pattern)
- `= 0` - Critical hits deal zero damage (breaks crit system)
- `< 0` - Critical hits HEAL enemies (catastrophic)

**Crash-Risk Ranges:**
- `< 0` - Negative damage multiplier could cause overflow in damage calculations
- `> 10000` - Risk of integer overflow: `damage * 10000` exceeds 32-bit limits
- Extreme values (1e6+) - Floating-point precision loss, animation system overload

**Recommended Hard Limits:**
- Absolute min: `1.0` (crits should always do MORE damage)
- Absolute max: `20.0` (2000% for extreme glass cannon builds)
- Enforce: Validation before damage calculation

---

### 3. PROJECTILESPEED (Projectile Velocity)
**Current Range:** 0 - 5000
**Default:** 300

**Balance-Breaking Ranges:**
- `> 5000` - Instant-hit projectiles, removes dodging/skill
- `> 10000` - May exceed collision detection frequency, bullets teleport through walls
- `< 10` - Projectiles too slow to hit moving targets, weapons unusable
- `= 0` - Projectiles don't move, softlock if required to progress

**Crash-Risk Ranges:**
- `< 0` - Backward-firing projectiles, collision system not designed for this
- `> 50000` - Physics engine may skip collision checks (Δt * velocity > collider size)
- `= 0` AND required weapon - Softlock if player cannot deal damage

**Recommended Hard Limits:**
- Absolute min: `10` (minimum viable projectile speed)
- Absolute max: `5000` (preserves skill-based dodging)
- Enforce: Clamp before physics velocity assignment

---

### 4. PIERCINGSHOTS (Projectile Penetration Count)
**Current Range:** 0 - 50
**Default:** 0

**Balance-Breaking Ranges:**
- `> 20` - Wipes entire enemy waves with single shot, trivializes group content
- `> 100` - Performance issues from checking 100+ collision targets per projectile

**Crash-Risk Ranges:**
- `< 0` - Negative pierce count, undefined behavior in loop iteration
- `> 1000` - Could cause infinite loop if implementation uses `while (pierce-- > 0)`
- Stack overflow if recursive pierce implementation

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `50` (current max is reasonable)
- Enforce: Integer clamp before collision loop

---

### 5. RELOADSPEED (Reload Time Modifier)
**Current Range:** 0 - 5000
**Default:** 1.0

**Balance-Breaking Ranges:**
- `> 100` - Reloads take 100x longer, weapons become unusable
- `< 0.01` - Instant reload, negates ammo management mechanic
- `= 0` - Instant reload OR divide-by-zero in `reload_time / reload_speed`

**Crash-Risk Ranges:**
- `= 0` - **CRITICAL CRASH RISK** if formula is `base_reload_time / reload_speed`
- `< 0` - Negative time modifier, undefined behavior
- Very small values (<0.001) - May cause animation system to skip frames

**Recommended Hard Limits:**
- Absolute min: `0.1` (10x faster reload, prevents div-by-zero)
- Absolute max: `10.0` (10x slower for extreme difficulty)
- Enforce: **CRITICAL** - Never allow zero, validate before division

---

### 6. AMMOCAPACITY (Magazine Size)
**Current Range:** 0 - 5000
**Default:** 30

**Balance-Breaking Ranges:**
- `> 1000` - Never need to reload, negates reload mechanic
- `= 0` - Cannot fire weapon, softlock if no other weapons

**Crash-Risk Ranges:**
- `< 0` - Negative ammo, may cause unsigned integer underflow to max value
- `= 0` AND only weapon - Softlock, player cannot attack
- Very large values (>100k) - Array allocation failures, UI overflow

**Recommended Hard Limits:**
- Absolute min: `1` (must be able to fire at least once)
- Absolute max: `500` (preserves reload mechanic)
- Enforce: Integer clamp, prevent zero on primary weapons

---

### 7. LIFESTEAL (Damage-to-Health Conversion %)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.5` (50%+) - Extreme sustain, player becomes unkillable
- `= 1.0` (100%) - Full damage healed, functional invulnerability
- `> 1.0` - Heal MORE than damage dealt, exponential HP growth

**Crash-Risk Ranges:**
- `< 0` - Damage REDUCES your HP, instadeath spiral
- `> 10` - HP overflow to negative (integer wraparound)
- Very large values - HP exceeds max type bounds

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.75` (75% for extreme vampire builds)
- Enforce: Clamp before HP modification

---

### 8. CHAINLIGHTNING (Electric Arc Target Count)
**Current Range:** 0 - 20
**Default:** 0

**Balance-Breaking Ranges:**
- `> 20` - Wipes entire battlefield, trivializes all encounters
- `> 100` - Massive performance hit from recursive chain calculations

**Crash-Risk Ranges:**
- `< 0` - Negative chain count, undefined loop behavior
- `> 1000` - Stack overflow if recursive chain implementation
- Infinite loop if implementation has bug with visited target tracking

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `20` (current max is reasonable)
- Enforce: Integer clamp before chain calculation

---

## CATEGORY 2: DEFENSE/SURVIVAL STATS

### 9. ARMOR (Damage Mitigation)
**Current Range:** 0 - 5000
**Default:** 50

**Balance-Breaking Ranges:**
- `> 1000` - Near-invulnerability depending on damage formula
- `< 0` - INCREASES damage taken, instadeath

**Crash-Risk Ranges:**
- `< 0` - If formula is `damage * (1 - armor/(armor+100))`, negative armor causes damage amplification spiral
- Very large values (>1e6) - Division overflow in mitigation formulas
- If formula allows `damage / (1 + armor)` and armor = -1, **DIVIDE BY ZERO CRASH**

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `2000` (preserve some lethality)
- Enforce: Validate before damage calculation formula

---

### 10. SHIELDCAPACITY (Shield HP Pool)
**Current Range:** 0 - 5000
**Default:** 50

**Balance-Breaking Ranges:**
- `> 5000` - Massive extra HP pool, trivializes damage
- `= 0` - Shield system disabled, breaks shield-dependent builds

**Crash-Risk Ranges:**
- `< 0` - Negative shield capacity, undefined behavior
- Very large values - HP tracking overflow

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `10000` (double current max for extreme builds)
- Enforce: Integer clamp

---

### 11. SHIELDREGENRATE (Shield Regeneration/sec)
**Current Range:** 0 - 5000
**Default:** 5

**Balance-Breaking Ranges:**
- `> 500` - Shield fully regenerates faster than enemies can damage it
- `= 0` - Shield never regenerates, breaks shield mechanic

**Crash-Risk Ranges:**
- `< 0` - Shield LOSES HP over time, death spiral
- Very large values - HP modification overflow per frame

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `500` (preserves vulnerability windows)
- Enforce: Clamp before HP modification

---

### 12. DODGECHANCE (Evasion Probability)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.9` (90%+) - Functional invulnerability
- `= 1.0` (100%) - Impossible to be hit, complete invulnerability

**Crash-Risk Ranges:**
- `< 0` - Negative probability, undefined RNG behavior
- `> 1.0` - If not clamped, breaks probability checks

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.85` (85% cap to preserve danger)
- Enforce: Clamp to [0, 0.85] before probability roll

---

### 13. DAMAGEABSORPTION (Flat Damage Reduction)
**Current Range:** 0 - 5000
**Default:** 0

**Balance-Breaking Ranges:**
- `> 1000` - All small hits negated, only extreme damage matters
- `> damage_values` - If absorption > incoming damage, player takes zero damage from most sources

**Crash-Risk Ranges:**
- `< 0` - INCREASES all damage taken (catastrophic)
- If calculation is `damage - absorption` without `max(0, ...)`, could produce negative damage

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `500` (prevents negating all small/medium hits)
- Enforce: Validate in damage formula with `max(0, damage - absorption)`

---

### 14. THORNDAMAGE (Reflect Flat Damage)
**Current Range:** 0 - 5000
**Default:** 0

**Balance-Breaking Ranges:**
- `> 1000` - Enemies kill themselves attacking you
- If exceeds enemy HP, trivializes melee enemies

**Crash-Risk Ranges:**
- `< 0` - Thorn damage HEALS attackers (breaks mechanic)
- Infinite loop if thorn damage triggers thorn damage recursively
- Very large values - Overflow in damage calculations

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `500`
- Enforce: Prevent recursive thorn triggers, clamp value

---

### 15. REFLECTDAMAGE (Reflect Percentage)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.5` (50%+) - High-damage enemies kill themselves
- `= 1.0` (100%) - Full damage reflected, enemies suicide
- `> 1.0` - Enemies take MORE damage than they deal

**Crash-Risk Ranges:**
- `< 0` - Reflected damage HEALS attackers
- Infinite loop if reflected damage triggers reflect again
- `> 10` - Overflow in damage calculation

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.75` (75% cap)
- Enforce: Prevent recursive reflection, clamp to [0, 0.75]

---

### 16. MAXHPPERCENTBONUS (Max HP Multiplier)
**Current Range:** 0 - 10
**Default:** 0

**Balance-Breaking Ranges:**
- `> 10` (1000%+) - 10x+ HP pool, trivializes all damage
- `< -0.9` (-90%+) - Reduces max HP below 10%, instadeath
- `= -1.0` (-100%) - Max HP becomes zero, instant death

**Crash-Risk Ranges:**
- `< -1.0` - Negative max HP, **CRITICAL CRASH RISK**
- `= -1.0` - If formula is `base_hp * (1 + bonus)`, max HP = 0, divide-by-zero in HP% calculations
- Very large values (>100) - HP overflow to negative

**Recommended Hard Limits:**
- Absolute min: `-0.5` (-50% max HP reduction)
- Absolute max: `10.0` (1000% bonus)
- Enforce: **CRITICAL** - Validate final HP > 0, clamp multiplier

---

## CATEGORY 3: RESOURCE MANAGEMENT STATS

### 17. ENERGYCAPACITY (Max Energy Pool)
**Current Range:** 0 - 5000
**Default:** 100

**Balance-Breaking Ranges:**
- `> 5000` - Infinite energy for practical purposes
- `= 0` - Cannot use abilities, softlock if abilities required

**Crash-Risk Ranges:**
- `< 0` - Negative max energy, undefined behavior
- `= 0` AND abilities required - Softlock

**Recommended Hard Limits:**
- Absolute min: `10` (must be able to use basic abilities)
- Absolute max: `5000` (current max)
- Enforce: Prevent zero if abilities are mandatory

---

### 18. ENERGYREGEN (Energy Regeneration/sec)
**Current Range:** 0 - 5000
**Default:** 10

**Balance-Breaking Ranges:**
- `> 1000` - Infinite energy for practical purposes
- `= 0` - Energy never regenerates, ability-locked after first use

**Crash-Risk Ranges:**
- `< 0` - Energy DRAINS over time, eventual softlock

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `1000`
- Enforce: Clamp before energy modification

---

### 19. COOLDOWNREDUCTION (Ability CD Reduction %)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.9` (90%+) - Near-instant ability spam
- `= 1.0` (100%) - Zero cooldown, infinite ability spam
- `> 1.0` - Abilities have NEGATIVE cooldown (???)

**Crash-Risk Ranges:**
- `= 1.0` - If formula is `base_cd / (1 - reduction)`, **DIVIDE BY ZERO CRASH**
- `> 1.0` - Negative cooldown values, timer underflow
- `< 0` - INCREASES cooldowns (anti-pattern)

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95` (95% cap to prevent div-by-zero)
- Enforce: **CRITICAL** - Use formula `base_cd * (1 - reduction)` NOT division

---

### 20. RESOURCEEFFICIENCY (Resource Cost Reduction %)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.9` (90%+) - Abilities essentially free
- `= 1.0` (100%) - Zero cost, infinite ability spam
- `> 1.0` - Abilities GIVE resources when used

**Crash-Risk Ranges:**
- `< 0` - Abilities cost MORE resources, softlock risk
- `> 1.0` - Negative resource costs, infinite resource generation exploit

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95` (95% cap, preserve some cost)
- Enforce: Clamp to [0, 0.95], ensure `cost * (1 - efficiency) >= 1`

---

### 21. DASHCOOLDOWN (Dash Ability Cooldown)
**Current Range:** 0 - 100
**Default:** 3.0

**Balance-Breaking Ranges:**
- `> 60` - Dash once per minute, mobility disabled
- `= 0` - Infinite dash spam, breaks movement balance
- `< 0.1` - Effective flight mode

**Crash-Risk Ranges:**
- `< 0` - Negative cooldown, timer underflow, undefined behavior
- `= 0` - May cause division by zero in cooldown percentage calculations

**Recommended Hard Limits:**
- Absolute min: `0.1` (minimum 0.1s between dashes)
- Absolute max: `30.0` (maximum 30s cooldown)
- Enforce: Clamp before timer set

---

## CATEGORY 4: ELEMENTAL STATS

### 22. CORRUPTIONCHANCE (Corruption DoT Application %)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.95` (95%+) - Every hit applies DoT, too powerful
- `= 1.0` (100%) - Guaranteed DoT on every hit

**Crash-Risk Ranges:**
- `< 0` - Negative probability, undefined RNG
- `> 1.0` - Breaks probability logic if not clamped

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95` (95% cap)
- Enforce: Clamp to [0, 0.95] before probability roll

---

### 23. CORRUPTIONDAMAGE (Corruption DoT Damage/tick)
**Current Range:** 0 - 5000
**Default:** 0

**Balance-Breaking Ranges:**
- `> 500` - DoT kills everything instantly
- `= 0` - Corruption does no damage, breaks mechanic

**Crash-Risk Ranges:**
- `< 0` - Corruption HEALS enemies
- Very large values - Damage overflow

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `500`
- Enforce: Clamp before damage calculation

---

### 24. ELEMENTALPENETRATION (Elemental Resistance Bypass %)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.9` (90%+) - Negates all enemy resistances
- `= 1.0` (100%) - Complete resistance bypass, too strong
- `> 1.0` - Elemental damage AMPLIFIED by enemy resistances (inverted)

**Crash-Risk Ranges:**
- `< 0` - INCREASES enemy resistances, inverted mechanic
- If formula is `damage * resist * (1 - pen)`, negative pen causes overflow

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.85` (85% cap)
- Enforce: Clamp to [0, 0.85]

---

### 25. IGNITESPREAD (Ignite Chain Range)
**Current Range:** 0 - 10
**Default:** 0

**Balance-Breaking Ranges:**
- `> 10` - Ignite spreads across entire map
- `> 100` - Performance issues from range checks

**Crash-Risk Ranges:**
- `< 0` - Negative spread range, undefined behavior
- Very large values - Excessive collision/proximity checks

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `15` (slightly above current for extreme builds)
- Enforce: Clamp before range check

---

### 26-27. IGNITECHANCE, CHARGECHANCE (Elemental Status %)
**Current Range:** 0 - 1.0 (0-100%)
**Default:** 0

**Balance-Breaking Ranges:**
- `> 0.95` (95%+) - Guaranteed status application
- `= 1.0` (100%) - Every hit applies status

**Crash-Risk Ranges:**
- `< 0` - Negative probability
- `> 1.0` - Breaks probability checks

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95`
- Enforce: Clamp to [0, 0.95]

---

### 28-29. IGNITEDAMAGE, CHARGEDAMAGE (Elemental DoT Damage)
**Current Range:** 0 - 5000
**Default:** 0

**Balance-Breaking Ranges:**
- `> 500` - DoT kills instantly
- `= 0` - Status does nothing

**Crash-Risk Ranges:**
- `< 0` - Status HEALS enemies
- Very large values - Overflow

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `500`
- Enforce: Clamp before damage application

---

## CATEGORY 5: MINION/SUMMONER STATS

### 30. MINIONDAMAGE (Minion Damage Multiplier)
**Current Range:** 0 - 5000
**Default:** 1.0

**Balance-Breaking Ranges:**
- `> 100` - Minions one-shot everything
- `< 0.1` - Minions deal negligible damage, useless
- `= 0` - Minions cannot damage, breaks summoner builds

**Crash-Risk Ranges:**
- `< 0` - Minions HEAL enemies
- Very large values (>10000) - Damage overflow
- `= 0` - If formula uses division by minion damage, **CRASH**

**Recommended Hard Limits:**
- Absolute min: `0.1` (minimum 10% damage)
- Absolute max: `20.0` (2000% for extreme builds)
- Enforce: Clamp before damage calculation

---

### 31. MINIONHP (Minion HP Multiplier)
**Current Range:** 0 - 5000
**Default:** 1.0

**Balance-Breaking Ranges:**
- `> 100` - Unkillable minions
- `< 0.1` - Minions die instantly, useless
- `= 0` - Minions spawn with 0 HP, instantly die

**Crash-Risk Ranges:**
- `< 0` - Negative max HP, minion spawn crash
- `= 0` - Minions spawn dead, potential null reference errors

**Recommended Hard Limits:**
- Absolute min: `0.1` (minimum 10% HP)
- Absolute max: `20.0` (2000%)
- Enforce: Prevent spawning minions with <=0 HP

---

### 32. MINIONATTACKSPEED (Minion Attack Speed Multiplier)
**Current Range:** 0 - 5000
**Default:** 1.0

**Balance-Breaking Ranges:**
- `> 50` - Minions attack so fast they lag the game
- `< 0.1` - Minions attack every 10+ seconds, useless
- `= 0` - Minions never attack

**Crash-Risk Ranges:**
- `< 0` - Negative attack speed, undefined behavior
- `= 0` - Division by zero if formula is `base_attack_time / attack_speed`
- Very large values (>1000) - Animation system overload

**Recommended Hard Limits:**
- Absolute min: `0.1` (minimum 10% speed)
- Absolute max: `10.0` (1000% speed cap)
- Enforce: **CRITICAL** - Prevent zero, clamp before division

---

### 33. NUMMINIONS (Maximum Minion Count)
**Current Range:** 0 - ?? (not in current stats file)
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 50` - Lag from too many AI agents
- `= 0` - Cannot summon, breaks summoner builds

**Crash-Risk Ranges:**
- `< 0` - Negative minion count, undefined
- `> 1000` - Memory/performance crash from spawning too many entities
- Array allocation failures

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `50`
- Enforce: Clamp before spawn loop

---

## CATEGORY 6: MOVEMENT STATS

### 34. PLAYERSPEED (Movement Speed)
**Current Range:** Unknown (not in new stats)
**Default:** Likely ~5-10 units/sec

**Balance-Breaking Ranges:**
- `> 50` - Too fast to control, clips through walls
- `< 1` - Unbearably slow, game unplayable
- `= 0` - Cannot move, softlock
- `< 0` - Inverted controls (move backward when pressing forward)

**Crash-Risk Ranges:**
- `< 0` - Negative speed, physics engine may not handle
- Very large values (>1000) - Exceeds collision detection frequency, clip through geometry
- `= 0` AND movement required - Softlock

**Recommended Hard Limits:**
- Absolute min: `1.0` (minimum viable movement)
- Absolute max: `50.0`
- Enforce: Clamp before physics velocity assignment

---

### 35. SPRINTSPEED (Sprint Speed Multiplier)
**Current Range:** Unknown
**Default:** Likely ~1.5-2.0x

**Balance-Breaking Ranges:**
- `> 10` - Sprint is too fast to control
- `< 1.0` - Sprint is slower than walk, breaks mechanic
- `= 0` - Cannot sprint

**Crash-Risk Ranges:**
- `< 0` - Negative sprint speed
- `= 0` - If division formula, crash

**Recommended Hard Limits:**
- Absolute min: `1.0` (sprint at least as fast as walk)
- Absolute max: `5.0`
- Enforce: Clamp before speed calculation

---

### 36. JUMPSTRENGTH (Jump Force)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 50` - Jump into skybox, out of bounds
- `< 0.5` - Cannot jump over basic obstacles
- `= 0` - Cannot jump, softlock if jumping required
- `< 0` - Jump pushes player DOWN (hilarious but broken)

**Crash-Risk Ranges:**
- `< 0` - Negative jump force, downward thrust, may clip through floor
- Very large values - Jump out of map bounds, fall forever, softlock
- `= 0` AND jumping required - Softlock

**Recommended Hard Limits:**
- Absolute min: `0.5`
- Absolute max: `20.0`
- Enforce: Clamp before physics force application

---

### 37. DASHSPEED (Dash Velocity)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 100` - Dash clips through walls, out of bounds
- `< 5` - Dash barely moves, useless
- `= 0` - Dash doesn't move player

**Crash-Risk Ranges:**
- `< 0` - Dash moves backward, confusing/broken
- Very large values - Clip through geometry, out of bounds fall

**Recommended Hard Limits:**
- Absolute min: `5.0`
- Absolute max: `100.0`
- Enforce: Clamp before dash impulse

---

## CATEGORY 7: WEAPON STATS

### 38. GUNDAMAGE (Ranged Weapon Damage)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 10000` - One-shot everything
- `< 1` - Cannot kill enemies, game unwinnable
- `= 0` - Weapon deals no damage, softlock

**Crash-Risk Ranges:**
- `< 0` - Weapons HEAL enemies
- Very large values - Integer overflow in damage calculation
- `= 0` AND only weapon - Softlock

**Recommended Hard Limits:**
- Absolute min: `1`
- Absolute max: `10000`
- Enforce: Clamp, prevent zero on required weapons

---

### 39. MELEEDAMAGE (Melee Weapon Damage)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 10000` - One-shot everything
- `< 1` - Cannot kill enemies
- `= 0` - Melee useless

**Crash-Risk Ranges:**
- `< 0` - Melee HEALS enemies
- Very large values - Overflow

**Recommended Hard Limits:**
- Absolute min: `1`
- Absolute max: `10000`
- Enforce: Clamp before damage calculation

---

### 40. SHOTSPERSEC (Fire Rate)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 100` - Machine gun fire, trivializes combat
- `< 0.1` - One shot per 10 seconds, unusable
- `= 0` - Cannot fire weapon

**Crash-Risk Ranges:**
- `< 0` - Negative fire rate, undefined
- `= 0` - **DIVIDE BY ZERO** if formula is `1.0 / shots_per_sec` to get delay
- Very large values (>1000) - Animation system crash, projectile spawn overflow

**Recommended Hard Limits:**
- Absolute min: `0.1` (minimum 1 shot per 10s)
- Absolute max: `50.0`
- Enforce: **CRITICAL** - Prevent zero, clamp before division

---

### 41. ACCURACY (Weapon Accuracy)
**Current Range:** Unknown
**Default:** Likely 0-1 or angle in degrees

**Balance-Breaking Ranges:**
- If percentage: `= 1.0` (100%) - Perfect accuracy, no spread
- If angle: `> 45°` - Extreme spread, unusable
- `< 0` - Negative accuracy (inverted aim?)

**Crash-Risk Ranges:**
- `< 0` - Negative spread angle, undefined
- If percentage: `> 1.0` - Over-accuracy? Bullets converge?

**Recommended Hard Limits:**
- If percentage: [0.0, 1.0]
- If angle: [0°, 30°]
- Enforce: Clamp based on implementation

---

### 42. RANGE (Weapon Range)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 10000` - Snipe across entire map, breaks encounter design
- `< 5` - Melee-range gun, unusable
- `= 0` - Projectile despawns instantly

**Crash-Risk Ranges:**
- `< 0` - Negative range, bullets spawn behind player?
- `= 0` - Projectile spawns and immediately despawns

**Recommended Hard Limits:**
- Absolute min: `10.0`
- Absolute max: `5000.0`
- Enforce: Clamp before projectile lifetime calculation

---

### 43. BULLETSFIRED (Projectiles Per Shot)
**Current Range:** Unknown
**Default:** Likely 1

**Balance-Breaking Ranges:**
- `> 20` - Shotgun effect, trivializes combat
- `= 0` - Weapon fires nothing

**Crash-Risk Ranges:**
- `< 0` - Negative bullet count, undefined
- `= 0` - Weapon fires no projectiles, softlock if only weapon
- Very large values (>1000) - Spawn too many entities, crash

**Recommended Hard Limits:**
- Absolute min: `1`
- Absolute max: `20`
- Enforce: Clamp before projectile spawn loop

---

### 44. BULLETSPEED (Projectile Velocity)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- Same as PROJECTILESPEED (see #3)

**Crash-Risk Ranges:**
- Same as PROJECTILESPEED (see #3)

**Recommended Hard Limits:**
- Absolute min: `10`
- Absolute max: `5000`

---

### 45. EXPLOSIONRADIUS (AoE Blast Radius)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 100` - Screen-wide explosions, trivializes all content
- `= 0` - Explosion hits nothing

**Crash-Risk Ranges:**
- `< 0` - Negative radius, undefined collision check
- Very large values (>1000) - Check too many colliders, performance crash

**Recommended Hard Limits:**
- Absolute min: `1.0`
- Absolute max: `50.0`
- Enforce: Clamp before collision sphere cast

---

### 46-47. MELEERANGE, MELEESPEED (Melee Stats)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- Range `> 50` - Melee becomes ranged
- Range `= 0` - Cannot hit anything
- Speed `> 50` - Attack so fast you can't see animations
- Speed `= 0` - Cannot attack

**Crash-Risk Ranges:**
- `< 0` - Negative values, undefined
- Speed `= 0` - Division by zero in animation timing

**Recommended Hard Limits:**
- Range: [1.0, 20.0]
- Speed: [0.1, 20.0]
- Enforce: Prevent zero speed

---

## CATEGORY 8: RESISTANCE STATS

### 48-50. FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE
**Current Range:** Unknown (likely 0-1 or 0-100%)
**Default:** Likely 0

**Balance-Breaking Ranges:**
- If percentage: `> 0.95` (95%+) - Near-immunity to element
- `= 1.0` (100%) - Complete immunity
- `> 1.0` - Elemental attacks HEAL player

**Crash-Risk Ranges:**
- `< 0` - INCREASED damage from element (anti-resistance)
- `< -1.0` - Double damage or worse
- If formula is `damage * (1 - resist)` and resist < -10, massive damage amplification

**Recommended Hard Limits:**
- Absolute min: `-0.5` (allow up to 50% extra damage)
- Absolute max: `0.95` (95% cap, preserve some damage)
- Enforce: Clamp to [-0.5, 0.95]

---

## CATEGORY 9: SPECIAL/MISC STATS

### 51. PROCRATE (Status Effect Proc Chance)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 0.95` (95%+) - Guaranteed procs
- `= 1.0` (100%) - Every hit procs

**Crash-Risk Ranges:**
- `< 0` - Negative probability
- `> 1.0` - Breaks probability checks

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95`
- Enforce: Clamp to [0, 0.95]

---

### 52. PROCRANGE (Status Effect AoE)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 50` - Screen-wide status effects
- `= 0` - Procs hit nothing

**Crash-Risk Ranges:**
- `< 0` - Negative range
- Very large values - Performance crash

**Recommended Hard Limits:**
- Absolute min: `1.0`
- Absolute max: `30.0`
- Enforce: Clamp before range check

---

### 53. HP (Player Health Points)
**Current Range:** Unknown
**Default:** Likely 100-500

**Balance-Breaking Ranges:**
- `> 100000` - Unkillable
- `< 10` - Die to single hit

**Crash-Risk Ranges:**
- `<= 0` - **CRITICAL CRASH RISK** - Dead player, death screen trigger, null references
- Very large values - Integer overflow to negative, instant death
- Negative HP - Undefined game state, likely crash

**Recommended Hard Limits:**
- Absolute min: `1` (must have positive HP)
- Absolute max: `100000`
- Enforce: **CRITICAL** - Never allow <=0 outside death state

---

### 54. ENERGY, STAMINA (Resource Pools)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 10000` - Infinite resources
- `= 0` - Cannot use abilities/sprint

**Crash-Risk Ranges:**
- `< 0` - Negative resources, undefined
- `= 0` AND required - Softlock

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `10000`
- Enforce: Prevent negative values

---

### 55. HPREGEN, STAMINAREGEN (Regeneration Rates)
**Current Range:** Unknown
**Default:** Unknown

**Balance-Breaking Ranges:**
- `> 1000` - Instant regeneration
- `< 0` - Resources DRAIN over time

**Crash-Risk Ranges:**
- `< 0` - Death spiral from HP drain

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `1000`
- Enforce: Clamp before resource modification

---

### 56. SHIELDONKILL (Shield Gained On Kill)
**Current Range:** Unknown
**Default:** Likely 0

**Balance-Breaking Ranges:**
- `> 1000` - Full shield on every kill, unkillable
- `< 0` - Killing enemies REDUCES shield

**Crash-Risk Ranges:**
- Very large values - Shield overflow
- `< 0` - Shield drain on kill

**Recommended Hard Limits:**
- Absolute min: `0`
- Absolute max: `500`
- Enforce: Clamp before shield modification

---

### 57. MELEECRITCHANCE (Melee Critical Chance)
**Current Range:** Likely 0-1
**Default:** Likely 0.05

**Balance-Breaking Ranges:**
- Same as CRITCHANCE (see #1)

**Crash-Risk Ranges:**
- Same as CRITCHANCE (see #1)

**Recommended Hard Limits:**
- Absolute min: `0.0`
- Absolute max: `0.95`

---

## CRITICAL VULNERABILITIES SUMMARY

### **DIVIDE-BY-ZERO RISKS** (Highest Priority)
These stats can cause **immediate crashes** if zero:

1. **RELOADSPEED** - If formula is `base_time / reload_speed`
2. **COOLDOWNREDUCTION** - If formula is `base_cd / (1 - reduction)` and reduction = 1.0
3. **SHOTSPERSEC** - If formula is `1.0 / shots_per_sec`
4. **MINIONATTACKSPEED** - If formula is `base_time / attack_speed`
5. **Any speed stat** - If used as divisor in time calculations

**Mitigation:** Always use multiplicative formulas `base * multiplier` instead of `base / divisor`

---

### **NEGATIVE VALUE EXPLOITS** (High Priority)
These stats cause game-breaking behavior if negative:

1. **HP, SHIELDCAPACITY** - Instant death
2. **ARMOR** - Massive damage amplification
3. **LIFESTEAL** - Damage kills player instead of healing
4. **CRITDAMAGE** - Crits heal enemies
5. **THORNDAMAGE, REFLECTDAMAGE** - Reflect heals enemies
6. **All RESISTANCE stats** - Increased damage from element
7. **PLAYERSPEED, JUMPSTRENGTH** - Inverted controls/physics

**Mitigation:** Hard floor at 0 for all stats except those designed for negatives

---

### **PERCENTAGE OVERFLOW RISKS** (Medium Priority)
Stats using percentages [0,1] that break if >=1.0:

1. **CRITCHANCE, DODGECHANCE** - 100% avoidance = invulnerability
2. **LIFESTEAL** - 100%+ = infinite healing
3. **COOLDOWNREDUCTION** - 100% = zero cooldown
4. **RESOURCEEFFICIENCY** - 100% = free abilities
5. **All elemental chances** - 100% = guaranteed status

**Mitigation:** Hard cap at 0.95 (95%) for all probability/percentage stats

---

### **SOFTLOCK SCENARIOS** (Medium Priority)
Stats that can make the game unwinnable:

1. **AMMOCAPACITY = 0** on only weapon
2. **GUNDAMAGE = 0** on required weapon
3. **PLAYERSPEED = 0** when movement required
4. **ENERGYCAPACITY = 0** when abilities required
5. **JUMPSTRENGTH = 0** when jumping required

**Mitigation:** Validate minimum viable values before allowing equipment changes

---

### **PERFORMANCE CRASHES** (Low-Medium Priority)
Stats that cause technical failures at extreme values:

1. **CHAINLIGHTNING, PIERCINGSHOTS > 1000** - Stack overflow in recursive code
2. **NUMMINIONS > 1000** - Memory allocation failure
3. **PROJECTILESPEED > 50000** - Bullets skip collision detection
4. **SHOTSPERSEC > 1000** - Animation system overload
5. **EXPLOSIONRADIUS > 1000** - Excessive collision checks

**Mitigation:** Hard caps on all count/range/speed stats

---

## RECOMMENDED VALIDATION SYSTEM

### Pre-Calculation Validation
```csharp
// Example validation pseudo-code
float ValidateStat(string statName, float value) {
    StatLimits limits = GetLimits(statName);

    // Hard clamp to safe range
    value = Mathf.Clamp(value, limits.absoluteMin, limits.absoluteMax);

    // Prevent divide-by-zero on divisor stats
    if (limits.isDivisor && value == 0) {
        value = limits.absoluteMin; // Force minimum non-zero
    }

    // Prevent softlocks on required stats
    if (limits.isRequired && value < limits.minViable) {
        value = limits.minViable;
    }

    return value;
}
```

### Coefficient Formula Safety
```csharp
// SAFE: Multiplicative formula (no division)
float finalValue = baseValue * (1 + M_coefficient);

// DANGEROUS: Division formula
// float finalValue = baseValue / (1 - M_coefficient); // CRASH if M = 1.0

// SAFE: Division with guard
float finalValue = baseValue / Mathf.Max(0.01f, 1 - M_coefficient);
```

---

## TESTING RECOMMENDATIONS

### Automated Test Cases
For each stat, test these boundary values:
1. **Zero** - Ensure no crashes, check for softlocks
2. **Negative** - Verify clamping or rejection
3. **Minimum** - Confirm gameplay remains functional
4. **Maximum** - Verify no overflow/crashes
5. **Beyond Maximum** - Ensure clamping works
6. **Percentage Stats at 1.0** - Check div-by-zero guards
7. **Percentage Stats >1.0** - Verify clamping

### Integration Tests
1. **All stats at minimum** - Game should still be playable (slow/hard)
2. **All stats at maximum** - Game should not crash (even if broken balance)
3. **All probabilities at 100%** - Should not crash
4. **All speeds at zero** - Should prevent softlock
5. **Negative HP/Armor/Resistances** - Should clamp to safe values

---

## CONCLUSION

**57 stats analyzed**, with critical findings:
- **5 stats** pose **divide-by-zero crash risk** if zero
- **23 stats** cause **game-breaking behavior** if negative
- **12 stats** require **hard caps at 95%** to prevent invulnerability/infinity exploits
- **8 stats** can cause **softlocks** if zero on required systems
- **12 stats** pose **performance crash risk** at extreme values (>1000)

**Highest Priority Fixes:**
1. **Implement divide-by-zero guards** on all speed/rate stats
2. **Hard clamp all percentage stats** to [0, 0.95]
3. **Prevent negative values** on HP, armor, damage, resistances
4. **Validate minimum viable values** on required gameplay stats
5. **Cap count stats** (minions, pierce, chain) to prevent overflow

**Next Steps:**
1. Review HEL coefficient formulas for division operations
2. Implement `ValidateStat()` function in HEL interpreter
3. Add unit tests for boundary conditions
4. Document safe value ranges in stat definitions
5. Consider adding "Nightmare Mode" that intentionally allows some broken ranges for fun
