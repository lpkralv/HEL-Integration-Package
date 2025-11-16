# Tactical Processor Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2043-2049 (7 items)
**Class Type:** Tactical Processors
**Item Type Code:** 0 (item/passive)

---

## CLASS OVERVIEW

**Tactical Processors** are adaptive combat response systems that enable defensive counterattack strategies, survivability mechanics, and unique build-defining tactical behaviors. These passive modifications focus on lifesteal, thorns, reflection, evasion, and special conversion mechanics that create entirely new playstyle archetypes.

**Core Characteristics:**
- Focus on LIFESTEAL, THORNDAMAGE, REFLECTDAMAGE, DODGECHANCE
- Enable counterattack and survival-through-combat strategies
- Create build-defining tactical response mechanics
- Advanced items feature conditional or scaling behaviors
- Prototype tier provides extreme build-redefining inversion mechanics

**Build Archetype Support:**
- Hybrid Berserker (lifesteal aggression and sustain)
- Fortress Tank (thorns/reflect counterattack)
- Speed Demon (dodge-based survival)
- Glass Cannon (lifesteal-based survival layer)
- DoT Specialist (lifesteal from continuous damage)

---

## STANDARD CONFIGURATION TIER (3 items)

### ITEM: NANITE RECYCLER MATRIX

**ModID:** 2043
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Combat nanite extraction protocols converting val1% of inflicted structural damage into self-repair sequences, restoring your framework integrity through enemy destruction

**HEL Equation:**
```
M_LIFESTEAL = M_LIFESTEAL val1 +
```

**Values:**
- val1: min 0.15, max 0.3 // Lifesteal increase (+15% to +30%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Hybrid Berserker:** Core sustain for aggressive melee combat strategies
- **Glass Cannon:** Offensive-scaling survival through damage-based healing
- **DoT Specialist:** Continuous healing from damage-over-time effects
- **Precision Sniper:** Sustain from high-damage critical strikes
- **Summoner Commander:** Healing from minion damage output

**Trade-offs:**
Pure utility bonus with no penalties - baseline lifesteal for testing sustain strategies. Requires high damage output to maximize healing effectiveness. Zero benefit if not dealing damage (defensive/tank-only builds)

**Lore Notes:**
Integrated extraction systems harvest viable nanite components from damaged enemy constructs, repurposing their structural material to patch your own framework breaches in real-time

---

### ITEM: PREDICTIVE EVASION CORE

**ModID:** 2044
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Advanced threat assessment algorithms granting val1% probability of complete attack negation through predictive trajectory micro-adjustments

**HEL Equation:**
```
M_DODGECHANCE = M_DODGECHANCE val1 +
```

**Values:**
- val1: min 0.15, max 0.3 // Dodge chance increase (+15% to +30%)

**Modweight:** 195

**Build Synergies:**
- **Speed Demon:** Core evasion mechanic for high-mobility survival
- **Glass Cannon:** RNG-based defense layer for fragile builds
- **Hybrid Berserker:** Reduces incoming damage during aggressive engagement
- **Fortress Tank:** Evasion-tank hybrid strategy
- **Precision Sniper:** Survival tool for long-range positioning mistakes

**Trade-offs:**
Pure defensive bonus with no penalties - baseline dodge for testing evasion strategies. RNG-dependent (unreliable compared to flat reduction). No benefit against unavoidable AoE or DoT effects

**Lore Notes:**
Combat prediction matrices analyze enemy weapon trajectories and execute micro-corrections to your movement vector, allowing complete evasion of incoming projectiles and melee strikes

---

### ITEM: REACTIVE PLATING ASSEMBLY

**ModID:** 2045
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Retaliatory defense protocols inflicting val1 structural damage on any attacker, channeling absorbed impact energy back through contact vectors

**HEL Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE val1 +
```

**Values:**
- val1: min 50, max 100 // Flat thorns damage (50-100 damage per hit received)

**Modweight:** 190

**Build Synergies:**
- **Fortress Tank:** Passive counterattack damage for face-tank strategies
- **Hybrid Berserker:** Additional damage output during aggressive melee
- **DoT Specialist:** Supplemental damage while focusing on DoT application
- **Summoner Commander:** Passive damage while minions engage
- **Glass Cannon:** Minimal benefit (requires taking damage)

**Trade-offs:**
Pure utility bonus with no penalties - baseline thorns for testing counterattack strategies. Requires taking damage to generate value (anti-synergy with perfect dodge/shield builds). Fixed flat damage (doesn't scale with player stats without additional mods)

**Lore Notes:**
Reactive nanite layers detect incoming kinetic impact and channel absorbed energy through point-of-contact feedback loops, damaging enemy weapon emitters and structural frameworks

---

## ENHANCED PROTOCOL TIER (2 items)

### ITEM: FEEDBACK AMPLIFIER CORE

**ModID:** 2046
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Integrated counterattack systems dealing val1 thorns damage plus reflecting val2% of received damage back to attackers, but reducing max HP by 20% from power distribution strain

**HEL Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE val1 +; M_REFLECTDAMAGE = M_REFLECTDAMAGE val2 +; M_HP = M_HP -0.2 +
```

**Values:**
- val1: min 100, max 200 // Thorns damage (100-200 flat damage)
- val2: min 0.2, max 0.4 // Reflect damage percentage (+20% to +40% damage reflection)

**Modweight:** 75

**Build Synergies:**
- **Fortress Tank:** Build-defining counterattack item combining flat and percentage reflection
- **Hybrid Berserker:** Passive damage scaling during aggressive face-tank combat
- **DoT Specialist:** Supplemental damage layer while applying DoT effects
- **Summoner Commander:** Player survives through counterattack while minions deal primary damage
- **Glass Cannon:** Anti-synergy (HP penalty compounds fragility)

**Trade-offs:**
20% HP reduction creates vulnerability requiring defensive investment. Both benefits require taking damage (zero value for perfect dodge/shield builds). Rewards face-tanking and aggressive positioning. Scales better against high-damage enemies (reflection percentage) versus swarms (flat thorns)

**Lore Notes:**
Dual-matrix defense systems combine flat reactive plating with percentage-based energy redirection, creating layered counterattack protocols at the cost of structural integrity reserves

---

### ITEM: VAMPIRIC TARGETING ASSEMBLY

**ModID:** 2047
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Predatory strike protocols granting val1% lifesteal and val2% critical damage amplification, but reducing armor by 25% from offensive optimization compromises

**HEL Equation:**
```
M_LIFESTEAL = M_LIFESTEAL val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_ARMOR = M_ARMOR -0.25 +
```

**Values:**
- val1: min 0.2, max 0.35 // Lifesteal increase (+20% to +35%)
- val2: min 0.5, max 1.0 // Critical damage increase (+50% to +100%)

**Modweight:** 70

**Build Synergies:**
- **Hybrid Berserker:** Perfect combination of sustain and burst damage for aggressive melee
- **Glass Cannon:** Sustain layer with additional crit scaling for extreme damage
- **Precision Sniper:** High-damage crits provide massive healing bursts
- **Elemental Savant:** Critical hits heal while triggering elemental effects
- **DoT Specialist:** Minimal crit synergy but lifesteal from DoT effects

**Trade-offs:**
25% armor reduction increases incoming damage vulnerability. Requires both high damage output AND critical strike investment to maximize value. Forces aggressive "kill them before they kill you" playstyle. Anti-synergy with tank builds (armor penalty too punishing)

**Lore Notes:**
Aggressive nanite extraction systems integrate with precision targeting matrices, enabling massive healing from critical strikes at the cost of defensive plating integrity

---

## ADVANCED MATRIX TIER (1 item)

### ITEM: DESPERATION PHASING PROTOCOL

**ModID:** 2048
**Type:** 0 (item/passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Emergency evasion systems granting val1% dodge chance per 10% HP lost below maximum, creating escalating evasion probability as structural damage accumulates (max +val2% dodge)

**HEL Equation:**
```
M_DODGECHANCE = M_DODGECHANCE + T_HP T_HP / (-1.0) + val1 * 10 * val2 MIN
```

**Values:**
- val1: min 0.05, max 0.08 // Dodge per 10% HP lost (+5% to +8% per 10% missing HP)
- val2: min 0.5, max 0.75 // Maximum dodge cap (+50% to +75% maximum dodge bonus)

**Modweight:** 35

**Build Synergies:**
- **Hybrid Berserker:** Build-defining low-HP evasion for aggressive risk-taking
- **Glass Cannon:** Escalating defense as HP drops compensates for fragility
- **Speed Demon:** Extreme dodge stacking for near-untouchable low-HP gameplay
- **Fortress Tank:** Evasion layer for desperate survival moments
- **Precision Sniper:** Emergency defense when positioning fails

**Trade-offs:**
Zero benefit at full HP - requires operating at low health for value. Maximum benefit at 10% HP remaining (potentially 40-80% dodge chance total). Extremely risky playstyle requiring precise HP management. Demands LIFESTEAL, HPREGEN, or SHIELDCAPACITY to control HP threshold. Anti-synergy with full-HP conditional items (Full Integrity Protocol)

**Unique Mechanics:**
Build-defining scaling evasion system. Creates "low-HP invincibility" archetype through extreme dodge chance. At 90% HP lost with 0.08 val1 and 0.75 cap: +72% dodge chance (capped at +75%). Synergizes with Berserker Surge Core for simultaneous damage and defense scaling. With base 5% dodge, can reach 80%+ total dodge at critical HP. Rewards aggressive risk-taking and precise HP dancing. Can create "clutch survival" moments where near-death = near-invincible

**Lore Notes:**
Critical damage sensors trigger emergency phasing protocols that probabilistically shift your framework between dimensional states, achieving near-perfect evasion as structural integrity approaches failure thresholds

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### ITEM: ENTROPY INVERSION MATRIX

**ModID:** 2049
**Type:** 0 (item/passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental reality-inversion protocols converting val1% of all received damage into structural restoration instead of degradation, but reducing max HP by 40%, armor by 50%, and disabling all shield systems (SHIELDCAPACITY reduced to 0)

**HEL Equation:**
```
M_LIFESTEAL = M_LIFESTEAL val1 +; M_HP = M_HP -0.4 +; M_ARMOR = M_ARMOR -0.5 +; U_SHIELDCAPACITY = U_SHIELDCAPACITY -5000 +
```

**Values:**
- val1: min 0.3, max 0.6 // Lifesteal from ALL sources including damage taken (+30% to +60%)

**Modweight:** 5

**Build Synergies:**
- **Hybrid Berserker:** Build-defining sustain that heals from both dealing AND receiving damage
- **Fortress Tank:** Converts counterattack strategy into healing-through-damage strategy
- **DoT Specialist:** Healing from DoT effects plus healing from taking damage
- **Glass Cannon:** Partial damage negation through healing (but extreme fragility)
- **Speed Demon:** Anti-synergy (shields disabled, low HP pool)

**Trade-offs:**
Catastrophic defensive penalties: 40% HP loss, 50% armor reduction, shields completely disabled (U_SHIELDCAPACITY -5000 = 0 shields). Transforms all combat damage into potential healing. Requires extreme offensive focus to maximize healing output. Must stack THORNDAMAGE, REFLECTDAMAGE, or high DPS for healing-through-combat. Shield builds completely incompatible. Movement and positioning critical for survival

**Unique Mechanics:**
Build-defining "heal from everything" system. Converts standard lifesteal into omnidirectional healing: damage dealt heals you (normal), but the inversion matrix also means taking damage can heal you through the extreme lifesteal bonus. With 0.6 LIFESTEAL: dealing 1000 damage heals 600 HP, AND thorns/reflect damage ALSO heals you. Creates "tanking through healing" archetype where more enemies = more damage taken = more thorns triggered = more healing. Synergizes with THORNDAMAGE + REFLECTDAMAGE for massive healing when surrounded. With Feedback Amplifier Core (2046): taking damage triggers 100-200 thorns + 20-40% reflect, which with 60% lifesteal = 60-120 healing from thorns alone. Enables "stand in enemy crowd and heal from counterattack" playstyle. Anti-synergy with dodge/shield builds (prevents damage = prevents healing)

**Lore Implications:**
Player becomes a berserker tank that heals through combat intensity. Must seek out damage to maximize healing. Surrounded by enemies becomes ideal state (more attacks = more counterattack = more healing). Rewards aggressive positioning and face-tanking. Requires mechanical mastery of HP threshold management. Completely redefines "defensive" as "offensive sustain"

**Lore Notes:**
Prototype entropy field generators reverse local causality flow within your framework, inverting damage vectors into structural reinforcement sequences. Catastrophic power requirements disable all secondary systems including shield projection, but combat becomes a healing feedback loop where destruction creates restoration

---

## DESIGN SUMMARY

**Total Items:** 7
**ID Range:** 2043-2049

**Rarity Distribution:**
- Standard: 3 items (2043-2045) | modweight 190-200
- Enhanced: 2 items (2046-2047) | modweight 70-75
- Advanced: 1 item (2048) | modweight 35
- Prototype: 1 item (2049) | modweight 5

**Stat Coverage:**
- LIFESTEAL: 3 items (2043, 2047, 2049)
- DODGECHANCE: 2 items (2044, 2048 conditional scaling)
- THORNDAMAGE: 2 items (2045, 2046)
- REFLECTDAMAGE: 1 item (2046)
- CRITDAMAGE: 1 item (2047, synergy bonus)
- HP: 3 items (penalties: 2046, 2049)
- ARMOR: 2 items (penalties: 2047, 2049)
- SHIELDCAPACITY: 1 item (complete disable: 2049)

**Build Archetype Support:**
- Fortress Tank: 5 items (thorns, reflect, counterattack healing)
- Hybrid Berserker: 6 items (lifesteal, aggression, low-HP scaling)
- Speed Demon: 3 items (dodge mechanics)
- Glass Cannon: 5 items (lifesteal survival, dodge layers)
- DoT Specialist: 4 items (lifesteal from DoT, thorns supplemental)
- Precision Sniper: 3 items (lifesteal, dodge, crit synergy)
- Summoner Commander: 3 items (lifesteal from minions, thorns while minions fight)

**Tactical Philosophy:**
- Standard tier provides baseline tactical stats with no penalties
- Enhanced tier combines multiple tactical effects with moderate defensive trade-offs
- Advanced tier creates conditional scaling mechanics (low HP dodge)
- Prototype tier inverts combat logic entirely (damage = healing)

**Trade-off Philosophy:**
- Standard items: No penalties (baseline tactical testing)
- Enhanced items: 20-25% reduction to HP or armor
- Advanced item: Conditional activation only (high-risk operation)
- Prototype item: 40% HP, 50% armor, shields disabled (extreme tactical transformation)

**Conditional Mechanics:**
- **Desperation Phasing Protocol (2048):** Dodge scales with missing HP - maximum evasion at critical health
- **Entropy Inversion Matrix (2049):** All combat damage becomes healing vector - complete playstyle inversion

**Lore Compliance:**
- All terminology uses nanomolecular language (tactical processor, feedback loop, matrix, protocols)
- No biological references (structural integrity, framework, nanite extraction)
- Consistent with HIOX tactical technology theme
- Player-visible descriptions avoid confidential lore
- Focus on "adaptive response", "feedback systems", "tactical processors" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val, B_X = B_X + val)
- Proper coefficient prefixes (M_ for multiplicative percentages, B_ for base additive, U_ for max adjustments)
- M_ values use decimals (0.3 = 30%, 1.0 = 100%)
- B_ values use absolute numbers (50 = 50 flat damage)
- U_SHIELDCAPACITY = -5000 to completely disable shields
- Conditional mechanics use comparison operators and calculations
- Desperation Phasing formula: T_HP T_HP / (-1.0) + val1 * 10 * val2 MIN
  - T_HP T_HP / = current HP percentage (e.g., 0.4 = 40% HP)
  - (-1.0) + = inverts to missing HP percentage (0.4 becomes 0.6 = 60% missing)
  - val1 * 10 * = multiplies per-10% value
  - val2 MIN = caps at maximum value

**Lifesteal System:**
- Baseline LIFESTEAL: 0 (no inherent lifesteal)
- Standard boost: +15-30% (total 15-30%)
- Enhanced boost: +20-35% with crit damage synergy (total 20-35%)
- Prototype boost: +30-60% extreme (total 30-60% from ALL damage)
- Prototype lifesteal heals from: player damage, minion damage, thorns damage, reflect damage

**Dodge System:**
- Baseline DODGECHANCE: 0 (no inherent dodge)
- Standard boost: +15-30% (total 15-30%)
- Advanced boost: +5-8% per 10% missing HP, capped at +50-75% (total up to 50-75% at low HP)
- Maximum achievable dodge with stacking: ~80-90% at critical HP thresholds

**Thorns/Reflect System:**
- Standard thorns: +50-100 flat damage
- Enhanced thorns: +100-200 flat damage
- Enhanced reflect: +20-40% damage reflection
- Combined: Can deal 100-200 flat + 20-40% of damage received per hit taken
- Synergizes with high HP pool (more hits survived = more counterattack triggers)

**Build-Defining Items:**
- **VAMPIRIC TARGETING ASSEMBLY (2047):** Complete lifesteal + crit package for aggressive berserker builds
- **DESPERATION PHASING PROTOCOL (2048):** Enables low-HP evasion tank archetype
- **ENTROPY INVERSION MATRIX (2049):** Complete combat inversion - damage becomes healing, tanking through offense

**Synergy Opportunities:**
- Combine 2043 + 2047 for extreme lifesteal (35-65% total)
- Stack 2044 + 2048 for adaptive dodge (baseline + low HP scaling = 65-105% at 10% HP)
- Use 2045 + 2046 for layered counterattack (150-300 thorns + 20-40% reflect)
- Pair 2046 with high HP builds to offset -20% HP penalty
- Combine 2047 with CRITCHANCE items for burst damage + healing
- Use 2048 with LIFESTEAL to maintain dangerous low HP threshold safely
- Pair 2049 with THORNDAMAGE + REFLECTDAMAGE for "heal by being attacked" strategy

**Anti-Synergies:**
- 2048 (low HP bonus) + Full Integrity Protocol (full HP bonus) conflict mechanically
- 2049 disables shields completely (anti-synergy with all shield items)
- Dodge items provide zero value if dodging prevents thorns/reflect triggers
- HP/armor penalties on Enhanced/Prototype tiers conflict with pure tank builds
- Lifesteal requires damage output (zero value for pure defensive tank builds)

**Balance Considerations:**
- Standard items provide tactical foundation without breaking defensive builds
- Enhanced items have meaningful 20-25% defensive trade-offs
- Advanced item creates skill-testing low-HP mechanics
- Prototype creates ultimate risk/reward with shield disabling and massive penalties
- Lifesteal scales with offensive power (self-balancing - more damage = more healing)
- Dodge is RNG-based (unreliable compared to flat reduction)
- Thorns/reflect require taking damage (self-limiting for dodge/shield builds)
- Conditional mechanics reward skillful play (HP management, positioning)

**Unique Tactical Mechanics:**

1. **Scaling Lifesteal:**
   - Standard: Fixed percentage (15-30%)
   - Enhanced: Higher fixed with crit bonus (20-35% + 50-100% crit damage)
   - Prototype: Extreme percentage from ALL damage sources (30-60%)

2. **Adaptive Dodge:**
   - Standard: Fixed percentage (15-30%)
   - Advanced: Scales inversely with HP (more dodge as HP drops)
   - Creates "last stand" archetype - near death = near invincible

3. **Counterattack Layers:**
   - Flat thorns (50-200 damage per hit)
   - Percentage reflect (20-40% of damage received)
   - Can combine for massive counterattack damage against strong enemies

4. **Combat Inversion:**
   - Prototype item reverses damage logic entirely
   - Taking damage + high lifesteal = healing from counterattacks
   - Creates "berserker tank" that heals through combat intensity
   - More enemies = more damage taken = more thorns/reflect = more healing

**Creative Build Paths:**

1. **Berserker Sustain:**
   - 2043 + 2047 for 35-65% lifesteal total
   - Add CRITCHANCE + CRITDAMAGE items for burst healing
   - Berserker Surge Core for low-HP damage scaling
   - Result: Aggressive melee with massive healing from crits

2. **Evasion Tank:**
   - 2044 + 2048 for baseline + scaling dodge
   - Add DASHCOOLDOWN reduction for mobility
   - Result: Near-untouchable at low HP with frequent dashing

3. **Counterattack Tank:**
   - 2045 + 2046 for thorns + reflect combo
   - Add high HP and ARMOR items
   - 2049 for healing from counterattack damage
   - Result: Stand in enemy crowds, heal from their attacks via thorns

4. **Glass Cannon Survival:**
   - 2043 or 2047 for lifesteal sustain
   - 2044 for dodge layer
   - Offensive items for maximum damage
   - Result: Fragile but heals through extreme damage output

5. **Entropy Berserker:**
   - 2049 (Entropy Inversion Matrix)
   - 2046 (Feedback Amplifier Core)
   - High damage output weapons
   - Result: Taking damage heals you via extreme lifesteal + thorns/reflect healing

**Final Item Notes:**

This Tactical Processor class completes the 50-item goal by providing the final missing pieces for tactical/survival gameplay:

- **Lifesteal** enables offensive sustain strategies
- **Dodge** creates evasion-based survival
- **Thorns/Reflect** enables counterattack tanks
- **Conditional scaling** rewards skillful HP management
- **Combat inversion** creates build-defining unique archetype

The Prototype item (Entropy Inversion Matrix) is intentionally extreme and build-defining, creating a completely unique playstyle where damage becomes healing, shields are disabled, and combat intensity equals survival. This is the "finale" item that completes the 50-item roster with something truly memorable and unique.

---

**END OF TACTICAL PROCESSOR ITEMS DESIGN**
