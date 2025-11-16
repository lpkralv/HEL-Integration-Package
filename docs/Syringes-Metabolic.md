# Metabolic Enhancer Syringes Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 3020-3029 (10 syringes)
**Class Type:** Metabolic Enhancers
**Item Type Code:** 10 (common syringe/upgrade)

---

## CLASS OVERVIEW

**Metabolic Enhancer Syringes** are nanite injections that optimize resource management, regeneration protocols, and sustain mechanics. These syringes enable extended combat engagements through enhanced recovery rates, reduced resource consumption, and accelerated ability cycling.

**Core Characteristics:**
- Focus: Sustain and resource management (HPREGEN, STAMINAREGEN, ENERGYREGEN, RESOURCEEFFICIENCY, COOLDOWNREDUCTION)
- Nanite injections that enhance metabolic processes
- Universal utility supporting all build archetypes
- Enable sustained combat and ability-heavy playstyles
- Varieties: Basic regen boosters, combined resource management, percentage-based scaling, perpetual sustain

**Build Archetype Support:**
- Fortress Tank (HP/stamina sustain for extended tanking)
- Summoner Commander (energy management for minion spam)
- Elemental Savant (energy and cooldown for ability casting)
- Speed Demon (stamina and resource efficiency for mobility)
- Hybrid Berserker (combat sustain for aggressive play)
- All archetypes (universal resource utility)

---

## STANDARD CONFIGURATION TIER (5 syringes)

### SYRINGE: REGENERATIVE NANITE INJECTION

**ModID:** 3020
**Type:** 10 (common syringe)
**Rarity:** Standard

**Description (Player-Visible):**
Metabolic enhancer serum accelerating nanite reconstruction protocols, restoring val1 structural integrity points per second through optimized repair cycles

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +
```

**Values:**
- val1: min 3, max 8 // Flat HP regeneration per second (+3 to +8 HP/sec)
- val2: 0 (not used)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Fortress Tank:** Foundation sustain for HP-focused tank strategies
- **Hybrid Berserker:** Passive recovery during aggressive melee combat
- **Summoner Commander:** Background sustain while minions engage
- **All archetypes:** Universal defensive utility

**Trade-offs:**
No penalties - baseline sustain injection. Flat regeneration provides consistent value across all build stages.

**Lore Notes:**
Standard metabolic enhancer distributed by beacon defense protocols. Increases nanite reconstruction efficiency through optimized molecular assembly sequences.

---

### SYRINGE: ENDURANCE ENHANCEMENT SERUM

**ModID:** 3021
**Type:** 10 (common syringe)
**Rarity:** Standard

**Description (Player-Visible):**
Stamina optimization injection enhancing energy reclamation systems, restoring val1 stamina points per second for continuous tactical mobility and ability execution

**HEL Equation:**
```
B_STAMINAREGEN = B_STAMINAREGEN val1 +
```

**Values:**
- val1: min 5, max 12 // Flat stamina regeneration per second (+5 to +12 stamina/sec)
- val2: 0 (not used)

**Modweight:** 190

**Build Synergies:**
- **Speed Demon:** Essential for continuous dash and sprint uptime
- **Hybrid Berserker:** Enables frequent power attacks and dodge rolls
- **Fortress Tank:** Supports stamina-consuming shield abilities
- **All archetypes:** Universal mobility support

**Trade-offs:**
No penalties - baseline mobility sustain. Stamina recovery supports all movement-dependent playstyles.

**Lore Notes:**
Endurance protocols optimize stamina reconstitution through enhanced metabolic cycling, maintaining operational tempo during extended engagements.

---

### SYRINGE: REACTOR EFFICIENCY BOOSTER

**ModID:** 3022
**Type:** 10 (common syringe)
**Rarity:** Standard

**Description (Player-Visible):**
Energy optimization injection accelerating reactor output cycles, generating val1 additional energy points per second through enhanced conversion protocols

**HEL Equation:**
```
B_ENERGYREGEN = B_ENERGYREGEN val1 +
```

**Values:**
- val1: min 8, max 18 // Flat energy regeneration per second (+8 to +18 energy/sec)
- val2: 0 (not used)

**Modweight:** 185

**Build Synergies:**
- **Elemental Savant:** Sustains continuous ability casting
- **Summoner Commander:** Enables frequent minion deployment
- **Speed Demon:** Supports energy-gated mobility abilities
- **All archetypes:** Universal energy sustain

**Trade-offs:**
No penalties - baseline energy management. Reactor efficiency enhances all ability-dependent strategies.

**Lore Notes:**
Reactor optimization nanites increase energy extraction efficiency from ambient nanite field interactions, maintaining steady power flow to tactical systems.

---

### SYRINGE: RAPID RECALIBRATION SERUM

**ModID:** 3023
**Type:** 10 (common syringe)
**Rarity:** Standard

**Description (Player-Visible):**
System calibration accelerator reducing tactical ability cooldown timers by val1% through streamlined reset cycle algorithms

**HEL Equation:**
```
M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION val1 +
```

**Values:**
- val1: min 0.1, max 0.2 // Cooldown reduction (+10% to +20%)
- val2: 0 (not used)

**Modweight:** 180

**Build Synergies:**
- **Summoner Commander:** More frequent minion deployment cycles
- **Elemental Savant:** Increased ability cast frequency
- **Speed Demon:** Reduced dash cooldown for enhanced mobility
- **All archetypes:** Universal ability frequency improvement

**Trade-offs:**
No penalties - baseline ability management. Cooldown reduction benefits all ability-dependent builds.

**Lore Notes:**
Recalibration nanites accelerate system reset protocols, enabling rapid-succession tactical protocol executions without compromising safety margins.

---

### SYRINGE: RESOURCE CONSERVATION INJECTOR

**ModID:** 3024
**Type:** 10 (common syringe)
**Rarity:** Standard

**Description (Player-Visible):**
Metabolic efficiency enhancer reducing all resource consumption by val1% through optimized power distribution and conservation algorithms

**HEL Equation:**
```
M_RESOURCEEFFICIENCY = M_RESOURCEEFFICIENCY val1 +
```

**Values:**
- val1: min 0.12, max 0.25 // Resource cost reduction (+12% to +25%)
- val2: 0 (not used)

**Modweight:** 175

**Build Synergies:**
- **Summoner Commander:** Cheaper minion deployment costs
- **Elemental Savant:** Reduced ability energy consumption
- **Speed Demon:** Lower stamina drain for mobility actions
- **All archetypes:** Universal resource efficiency

**Trade-offs:**
No penalties - baseline resource optimization. Efficiency gains multiply with high-cost abilities.

**Lore Notes:**
Conservation protocols minimize energy waste during ability activations, reducing total consumption while maintaining full operational output.

---

## ENHANCED PROTOCOL TIER (3 syringes)

### SYRINGE: INTEGRATED RECOVERY MATRIX

**ModID:** 3025
**Type:** 10 (common syringe)
**Rarity:** Enhanced

**Description (Player-Visible):**
Dual-spectrum metabolic enhancer restoring val1 HP per second and val2 stamina per second, but reducing maximum structural integrity by 8% due to accelerated metabolic stress

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; M_HP = M_HP -0.08 +
```

**Values:**
- val1: min 6, max 12 // HP regeneration per second (+6 to +12 HP/sec)
- val2: min 8, max 16 // Stamina regeneration per second (+8 to +16 stamina/sec)

**Modweight:** 75

**Build Synergies:**
- **Hybrid Berserker:** Complete combat sustain for extended aggressive engagements
- **Speed Demon:** HP recovery while maintaining high mobility uptime
- **Fortress Tank:** Dual recovery layer for sustained tanking

**Trade-offs:**
8% max HP reduction creates vulnerability to burst damage. Trade-off worthwhile for builds emphasizing continuous recovery over maximum HP pools. Sustained combat strategies benefit most.

**Lore Notes:**
Integrated recovery nanites manage both structural integrity and stamina reconstitution simultaneously, though accelerated metabolic cycling slightly reduces peak structural capacity.

---

### SYRINGE: ABILITY OPTIMIZATION COMPLEX

**ModID:** 3026
**Type:** 10 (common syringe)
**Rarity:** Enhanced

**Description (Player-Visible):**
Dual-system enhancer providing val1 energy per second and reducing cooldowns by val2%, but decreasing movement speed by 10% due to processing resource allocation

**HEL Equation:**
```
B_ENERGYREGEN = B_ENERGYREGEN val1 +; M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +
```

**Values:**
- val1: min 12, max 25 // Energy regeneration per second (+12 to +25 energy/sec)
- val2: min 0.15, max 0.3 // Cooldown reduction (+15% to +30%)

**Modweight:** 70

**Build Synergies:**
- **Summoner Commander:** Complete ability resource management for minion spam
- **Elemental Savant:** Sustained casting with frequent ability cycling
- **Fortress Tank:** Defensive ability uptime despite mobility loss

**Trade-offs:**
10% movement speed reduction creates positioning challenges. Rewards stationary combat and area control strategies. Anti-synergy with Speed Demon builds. Best for ability-heavy playstyles that prioritize casting over mobility.

**Lore Notes:**
Ability optimization systems prioritize energy generation and cooldown algorithms, diverting computational resources from movement protocol processing.

---

### SYRINGE: PERPETUAL SUSTAIN INJECTION

**ModID:** 3027
**Type:** 10 (common syringe)
**Rarity:** Enhanced

**Description (Player-Visible):**
Tri-spectrum metabolic accelerator restoring val1 HP/sec, val2 stamina/sec, and 15 energy/sec, but reducing shield regeneration rate by 20% and armor effectiveness by 12%

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; B_ENERGYREGEN = B_ENERGYREGEN 15 +; M_SHIELDREGENRATE = M_SHIELDREGENRATE -0.2 +; M_ARMOR = M_ARMOR -0.12 +
```

**Values:**
- val1: min 5, max 10 // HP regeneration per second (+5 to +10 HP/sec)
- val2: min 6, max 12 // Stamina regeneration per second (+6 to +12 stamina/sec)

**Modweight:** 60

**Build Synergies:**
- **Hybrid Berserker:** Complete sustain layer for ultra-aggressive combat
- **Summoner Commander:** All-resource recovery while minions engage
- **Elemental Savant:** Triple sustain enables extended ability casting sessions

**Trade-offs:**
20% shield regen reduction and 12% armor reduction significantly impact defensive layering. Incompatible with shield-focused Fortress Tank builds. Best for offense-oriented archetypes prioritizing sustain over raw defense. Extended combat duration must justify defensive penalties.

**Lore Notes:**
Comprehensive metabolic enhancement manages all regeneration systems simultaneously, though resource strain compromises defensive matrix stability and shield recalibration efficiency.

---

## ADVANCED MATRIX TIER (2 syringes)

### SYRINGE: ADAPTIVE METABOLIC AMPLIFIER

**ModID:** 3028
**Type:** 10 (common syringe)
**Rarity:** Advanced

**Description (Player-Visible):**
Percentage-based regeneration matrix restoring val1% of max HP per second and val2% of max stamina per second, plus converting total regeneration into resource efficiency (1% efficiency per 10 combined regen), but reducing fire rate by 20%

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN + T_HP val1 * 0.01 *; B_STAMINAREGEN = B_STAMINAREGEN + T_MAXSTAMINA val2 * 0.01 *; M_RESOURCEEFFICIENCY = M_RESOURCEEFFICIENCY + T_HPREGEN T_STAMINAREGEN + 10 / 0.01 *; M_SHOTSPERSEC = M_SHOTSPERSEC -0.2 +
```

**Values:**
- val1: min 1.2, max 2.5 // HP regen as % of max HP per second (1.2% to 2.5% max HP/sec)
- val2: min 1.5, max 3.0 // Stamina regen as % of max stamina per second (1.5% to 3.0% max stamina/sec)

**Modweight:** 35

**Build Synergies:**
- **Fortress Tank:** Scales exponentially with HP/stamina stacking (2% of 2000 HP = 40 HP/sec)
- **Hybrid Berserker:** Percentage recovery scales with defensive investment
- **Summoner Commander:** Resource efficiency bonus reduces minion deployment costs

**Trade-offs:**
20% fire rate reduction significantly impacts gun-focused DPS. Requires substantial HP/stamina investment (800+ HP, 150+ stamina) for meaningful regen values. Anti-synergy with rapid-fire weapon builds. Resource efficiency bonus rewards extreme regen stacking (50 combined regen = 5% efficiency).

**Unique Mechanics:**
Build-defining for HP/stamina stacking strategies. Creates "percentage regen tank" archetype. Conversion formula: (HP_REGEN + STAMINA_REGEN) / 10 * 0.01 = efficiency bonus. With 40 HP/sec and 30 stamina/sec, gain +7% resource efficiency on top of percentage scaling. Triple-scaling system: stat investment → percentage regen → efficiency bonus.

**Lore Notes:**
Adaptive nanite systems dynamically scale regeneration to total structural capacity while recycling excess metabolic energy into resource conservation protocols, though rapid cycling reduces weapon system efficiency.

---

### SYRINGE: PERPETUAL MOTION REACTOR (PROTOTYPE)

**ModID:** 3029
**Type:** 10 (common syringe)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental infinite-sustain reactor providing val1 HP/sec, val2 energy/sec, 80% resource cost reduction, and 45% cooldown reduction, but reducing all damage output by 30% and maximum HP by 15%

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_ENERGYREGEN = B_ENERGYREGEN val2 +; M_RESOURCEEFFICIENCY = M_RESOURCEEFFICIENCY 0.8 +; M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION 0.45 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.3 +; M_HP = M_HP -0.15 +
```

**Values:**
- val1: min 30, max 60 // HP regeneration per second (+30 to +60 HP/sec)
- val2: min 35, max 70 // Energy regeneration per second (+35 to +70 energy/sec)

**Modweight:** 5

**Build Synergies:**
- **Summoner Commander:** Near-infinite minion deployment (minions provide damage)
- **Elemental Savant:** Unlimited ability spam with minimal resource constraints
- **DoT Specialist:** Constant elemental application through rapid ability cycling
- **Support/Utility builds:** Enables pure support role prioritizing sustain and utility

**Trade-offs:**
Extreme damage penalty (30% to gun/melee) eliminates direct combat viability. Significant HP reduction (15%) reduces survivability ceiling. Forces complete build pivot to minion/DoT/utility focus. Completely incompatible with Glass Cannon, Hybrid Berserker, or any direct damage archetype. Must rely on alternative damage sources (minions, DoT, environmental, elemental procs).

**Unique Mechanics:**
Build-defining "infinite sustain" archetype. 80% resource efficiency makes most abilities cost only 20% of normal. Combined with 45% CDR and massive regen, enables near-unlimited ability usage. Creates "perpetual caster" playstyle where resource constraints effectively don't exist. Absolute highest sustain in the game at cost of offensive capability. Transforms player into tactical commander/support rather than combatant.

**Strategic Implications:**
Player becomes zone controller rather than damage dealer. Prioritize minion deployment frequency, area control abilities, and DoT application over direct engagement. Synergizes with MINIONDAMAGE mods, elemental DoT builds, CORRUPTIONSPREADCHANCE, and support-focused strategies. Ultimate enabler for pure summoner/caster archetypes.

**Lore Notes:**
Experimental perpetual motion reactor achieves near-infinite metabolic efficiency through nanite zero-point energy extraction and recursive power cycling, but extreme power draw destabilizes weapon systems and compromises maximum structural integrity.

---

## DESIGN SUMMARY

**Total Syringes:** 10
**ID Range:** 3020-3029

**Rarity Distribution:**
- Standard: 5 syringes (3020-3024) | modweight 175-200
- Enhanced: 3 syringes (3025-3027) | modweight 60-75
- Advanced: 1 syringe (3028) | modweight 35
- Prototype: 1 syringe (3029) | modweight 5

**Stat Coverage:**
- HPREGEN: 5 syringes (3020, 3025, 3027, 3028, 3029)
- STAMINAREGEN: 3 syringes (3021, 3025, 3027, 3028)
- ENERGYREGEN: 4 syringes (3022, 3026, 3027, 3029)
- COOLDOWNREDUCTION: 3 syringes (3023, 3026, 3029)
- RESOURCEEFFICIENCY: 3 syringes (3024, 3028, 3029)
- SHIELDREGENRATE: 1 syringe (3027 - penalty)
- HP: 2 syringes (3025, 3029 - penalties)
- PLAYERSPEED: 1 syringe (3026 - penalty)
- ARMOR: 1 syringe (3027 - penalty)
- SHOTSPERSEC: 1 syringe (3028 - penalty)
- GUNDAMAGE: 1 syringe (3029 - penalty)
- MELEEDAMAGE: 1 syringe (3029 - penalty)

**Build Archetype Support:**
- Summoner Commander: 10 syringes (all provide resource management for minion/ability spam)
- Elemental Savant: 10 syringes (all enable ability-heavy casting builds)
- Fortress Tank: 8 syringes (HP/stamina sustain for extended tanking)
- Hybrid Berserker: 7 syringes (combat sustain for aggressive playstyles)
- Speed Demon: 7 syringes (stamina/energy/efficiency for mobility)
- DoT Specialist: 6 syringes (energy/cooldown for constant DoT application)
- Glass Cannon: 4 syringes (energy/regen for burst ability usage)

**Regeneration Philosophy:**
- Standard tier provides baseline flat regeneration across all resource types
- Enhanced tier combines multiple regen types with moderate defensive trade-offs
- Advanced tier creates percentage-based scaling that rewards stat investment plus unique conversion mechanics
- Prototype tier eliminates resource constraints entirely for pure support/summoner builds

**Trade-off Philosophy:**
- Standard syringes: No penalties (baseline utility items)
- Enhanced syringes: 8-12% penalties to secondary systems (HP, speed, armor, shields)
- Advanced syringe: 20% fire rate penalty + complex scaling mechanic
- Prototype: Extreme penalties (30% damage, 15% HP) + build-defining sustain

**Scaling Mechanics:**
- **Percentage-Based Regen** (3028): Scales with max HP/stamina investment
- **Regen-to-Efficiency Conversion** (3028): Transforms regeneration into resource cost reduction
- **Near-Infinite Resources** (3029): Eliminates resource management for ability-spam builds

**Metabolic Sustain Philosophy:**
- Syringes 3020-3024: Foundation for any sustain-dependent build
- Syringes 3025-3027: Mid-game multi-resource optimization with mobility/defense trade-offs
- Syringe 3028: End-game percentage scaling for HP/stamina stackers with efficiency bonus
- Syringe 3029: Ultimate ability-spam enabler for minion/DoT/utility-focused strategies

**Lore Compliance:**
- All terminology uses nanomolecular language (metabolic enhancers, regenerative nanites, reactor optimization, protocols)
- No biological references (no healing/metabolism in biological sense, uses "reconstruction" and "reconstitution")
- Consistent with HIOX world lore (nanite-based enhancements, metabolic = resource processing)
- Player-visible descriptions avoid confidential lore elements
- Focus on "metabolic enhancer serum", "regenerative nanites", "resource optimization injection" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (B_X = B_X + val, M_X = M_X + val)
- Proper coefficient prefixes (B_ for flat additions, M_ for multiplicative percentages, T_ for read-only)
- M_ values use decimals (0.2 = 20%, -0.15 = -15%)
- Postfix notation for operations (T_HP val1 * 0.01 *)
- Complex formulas use proper order (T_HPREGEN T_STAMINAREGEN + 10 / 0.01 *)
- Cross-stat dependencies in Advanced/Prototype tiers

**Unique Design Elements:**
1. **Universal Utility** (Standard): All builds benefit from baseline sustain boosts
2. **Multi-Resource Combinations** (Enhanced): Dual/triple regeneration systems with defensive trade-offs
3. **Percentage Scaling + Conversion** (3028): Triple-benefit system (HP% regen + stamina% regen + efficiency bonus)
4. **Infinite Sustain** (3029): Eliminates resource management for pure support/summoner role
5. **No Direct Offensive Syringes**: All focus on sustain/resource management (defensive/utility orientation)

**Balance Considerations:**
- Standard syringes provide meaningful sustain without breaking game balance
- Enhanced syringes have 8-12% defensive penalties balanced against dual-resource benefits
- Advanced syringe has 20% fire rate penalty justified by percentage scaling + efficiency conversion
- Prototype has extreme penalties (30% damage, 15% HP) forcing non-damage build commitment
- Percentage scaling requires significant stat investment (800+ HP) to outperform flat values
- Efficiency conversion rewards extreme regen stacking (50+ combined regen = 5% efficiency)
- Infinite sustain (3029) compensated by making direct combat non-viable

**Synergy Opportunities:**
- Combine 3020 + 3028 for massive percentage HP regen on tank builds
- Stack 3021 + 3025 for extreme stamina sustain on Speed Demon
- Use 3029 with MINIONDAMAGE/MINIONDAMAGE items for ultimate summoner
- Pair 3026 with ability-heavy Elemental Savant for sustained casting
- Combine 3024 + 3029 for 100% resource efficiency (free abilities)
- Use 3028 with HP/stamina stacking items for triple scaling benefits
- Pair 3027 with non-shield builds for complete resource recovery

**Archetype Enablers:**
- **Pure Summoner**: 3029 (infinite minion deployment)
- **Regen Tank**: 3028 (percentage scaling) + 3020 (flat boost)
- **Ability Spammer**: 3026 (energy + CDR) + 3023 (more CDR)
- **Sustained Combat**: 3027 (triple regen) or 3025 (dual regen)
- **Resource Optimizer**: 3024 (efficiency) + 3028 (efficiency conversion)

---

**END OF METABOLIC ENHANCER SYRINGES DESIGN**
