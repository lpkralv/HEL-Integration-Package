# Resource Controllers Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2035-2042 (8 items)
**Class Type:** Resource Controllers
**Item Type Code:** 0 (item/passive)

---

## CLASS OVERVIEW

**Resource Controllers** are passive energy management and optimization systems that enhance ability usage, cooldown management, and resource efficiency. These assemblies enable high-intensity playstyles through expanded energy reserves, accelerated cooldown cycles, and reduced resource consumption protocols.

**Core Characteristics:**
- Focus on ENERGYCAPACITY, ENERGYREGEN, COOLDOWNREDUCTION, RESOURCEEFFICIENCY
- Enable ability-spam and high-frequency tactical protocol usage
- Universal utility for all archetypes requiring resource management
- Advanced variants convert resources into offensive scaling
- Varieties: Basic capacity/regen, efficiency optimizers, energy-to-damage converters

**Build Archetype Support:**
- Summoner Commander (energy for frequent minion deployment)
- Elemental Savant (energy for continuous elemental ability casting)
- Speed Demon (cooldown reduction for mobility abilities)
- All archetypes (resource management is universally valuable)

---

## STANDARD CONFIGURATION TIER (3 items)

### ITEM: ENERGY MATRIX AMPLIFIER

**ModID:** 2035
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Enhanced power cell assembly increasing maximum energy storage capacity by val1%, enabling extended tactical protocol deployment sequences

**HEL Equation:**
```
M_ENERGYCAPACITY = M_ENERGYCAPACITY + val1
```

**Values:**
- val1: min 0.3, max 0.6 // Energy capacity boost (+30% to +60%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Summoner Commander:** Larger energy pool for minion spam strategies
- **Elemental Savant:** Extended ability usage before energy depletion
- **Speed Demon:** Support for energy-gated mobility abilities
- **All archetypes:** Universal energy capacity foundation

**Trade-offs:**
Pure capacity increase with no penalties - baseline resource management item. Diminishing returns without matching energy regeneration investment

**Lore Notes:**
Advanced nanite power cells utilize high-density energy matrices to store significantly more charge than standard reactor configurations

---

### ITEM: REACTOR OPTIMIZATION CORE

**ModID:** 2036
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Optimized reactor protocols accelerating energy reconstitution cycles, restoring val1 additional energy points per second through enhanced conversion efficiency

**HEL Equation:**
```
B_ENERGYREGEN = B_ENERGYREGEN + val1
```

**Values:**
- val1: min 10, max 25 // Flat energy regeneration per second (+10 to +25 energy/sec)

**Modweight:** 195

**Build Synergies:**
- **Elemental Savant:** Sustains continuous ability casting strategies
- **Summoner Commander:** Enables frequent minion redeployment
- **Hybrid Berserker:** Supports energy-consuming weapon modes
- **All archetypes:** Universal energy sustain foundation

**Trade-offs:**
Pure regeneration with no penalties - baseline sustain item. Less effective without sufficient energy capacity to leverage regen rate

**Lore Notes:**
Reactor efficiency algorithms extract maximum energy output from ambient nanite field interactions, maintaining continuous power flow to tactical systems

---

### ITEM: COOLDOWN CALIBRATOR

**ModID:** 2037
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
System recalibration protocols reducing all tactical ability cooldown timers by val1% through optimized reset cycle algorithms

**HEL Equation:**
```
M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION + val1
```

**Values:**
- val1: min 0.15, max 0.3 // Cooldown reduction (+15% to +30%)

**Modweight:** 190

**Build Synergies:**
- **Speed Demon:** Reduces dash and mobility ability downtime
- **Summoner Commander:** Enables more frequent minion deployment
- **Elemental Savant:** Increases elemental ability cast frequency
- **All archetypes:** Universal ability frequency improvement

**Trade-offs:**
Pure cooldown reduction with no penalties - baseline ability management item. Maximum value requires abilities with meaningful cooldowns to reduce

**Lore Notes:**
Accelerated system recalibration algorithms bypass standard cooldown safety protocols, enabling rapid-succession tactical protocol executions

---

## ENHANCED PROTOCOL TIER (2 items)

### ITEM: INTEGRATED RESOURCE MANAGER

**ModID:** 2038
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Unified power management system increasing energy capacity by val1% and energy regeneration by val2 points per second, but reducing maximum stamina by 20%

**HEL Equation:**
```
M_ENERGYCAPACITY = M_ENERGYCAPACITY + val1; B_ENERGYREGEN = B_ENERGYREGEN + val2; M_MAXSTAMINA = M_MAXSTAMINA + (-0.2)
```

**Values:**
- val1: min 0.4, max 0.8 // Energy capacity boost (+40% to +80%)
- val2: min 15, max 35 // Energy regeneration per second (+15 to +35 energy/sec)

**Modweight:** 75

**Build Synergies:**
- **Elemental Savant:** Complete energy management for continuous casting
- **Summoner Commander:** Sustained minion deployment capability
- **Hybrid Berserker:** Energy pool for ability-augmented combat
- **Fortress Tank:** Energy sustain for shield abilities despite stamina loss

**Trade-offs:**
20% stamina reduction limits dodge frequency and sprint duration. Prioritizes ability usage over physical mobility. Less effective for Speed Demon builds relying on stamina for dashes. Energy investment must justify stamina sacrifice

**Lore Notes:**
Power distribution matrix prioritizes energy system capacity, diverting nanite processing resources from stamina generation protocols

---

### ITEM: EFFICIENCY OPTIMIZATION PROTOCOL

**ModID:** 2039
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Advanced resource conservation algorithms reducing ability cooldowns by val1% and all resource costs by val2%, but decreasing movement speed by 15%

**HEL Equation:**
```
M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION + val1; M_RESOURCEEFFICIENCY = M_RESOURCEEFFICIENCY + val2; M_PLAYERSPEED = M_PLAYERSPEED + (-0.15)
```

**Values:**
- val1: min 0.2, max 0.4 // Cooldown reduction (+20% to +40%)
- val2: min 0.15, max 0.3 // Resource cost reduction (+15% to +30%)

**Modweight:** 70

**Build Synergies:**
- **Summoner Commander:** Frequent, cheap minion deployments
- **Elemental Savant:** Spam abilities with reduced cost and cooldown
- **Fortress Tank:** More shield/defensive abilities with lower cost
- **Glass Cannon:** Offensive ability spam despite mobility loss

**Trade-offs:**
15% movement speed reduction creates positioning challenges. Rewards stationary combat and area control strategies. Anti-synergy with Speed Demon mobility builds. Requires ability-heavy playstyle to maximize efficiency benefits

**Lore Notes:**
Computational resource allocation prioritizes ability system optimization, reducing processing power available for mobility protocol calculations

---

## ADVANCED MATRIX TIER (2 items)

### ITEM: ENERGY CONVERSION AMPLIFIER

**ModID:** 2040
**Type:** 0 (item/passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental power routing system granting val1 base energy capacity and converting current energy reserves into weapon damage, gaining val2% gun and melee damage per 100 energy capacity, but reducing fire rate by 30%

**HEL Equation:**
```
B_ENERGYCAPACITY = B_ENERGYCAPACITY + val1; M_GUNDAMAGE = M_GUNDAMAGE + T_ENERGYCAPACITY val2 * 0.001 *; M_MELEEDAMAGE = M_MELEEDAMAGE + T_ENERGYCAPACITY val2 * 0.001 *; M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.3)
```

**Values:**
- val1: min 100, max 200 // Flat energy capacity bonus (+100 to +200 energy)
- val2: min 0.8, max 1.5 // Damage scaling per 100 energy capacity (0.8% to 1.5% damage per 100 energy)

**Modweight:** 35

**Build Synergies:**
- **Glass Cannon:** Converts energy investment into direct damage output
- **Elemental Savant:** Synergizes with high energy capacity builds
- **Hybrid Berserker:** Creates energy-scaling melee damage variant
- **Energy-stacking builds:** Transforms resource stat into offensive capability

**Trade-offs:**
Severe fire rate reduction (30%) significantly impacts sustained gun DPS. Requires heavy energy capacity investment for damage scaling to compensate penalty. Creates tension: use energy for abilities or maintain high capacity for damage? Anti-synergy with rapid-fire weapon builds

**Unique Mechanics:**
Build-defining energy-to-damage conversion system. Incentivizes maxing ENERGYCAPACITY beyond ability usage needs. Creates "high energy = high damage" archetype. With 500 energy capacity and 1.2 val2, grants +6% gun/melee damage. Full energy provides maximum damage output, creating risk/reward for ability usage

**Lore Notes:**
Overcharged power cells route excess energy reserves directly into weapon emitter arrays, amplifying output at cost of firing cycle efficiency

---

### ITEM: TEMPORAL ACCELERATION MATRIX

**ModID:** 2041
**Type:** 0 (item/passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental time-dilation protocols reducing ability cooldowns by val1% and converting cooldown efficiency into increased elemental proc rates, granting additional IGNITECHANCE and CHARGECHANCE equal to val2 times total cooldown reduction percentage, but reducing armor by 25%

**HEL Equation:**
```
M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION + val1; M_IGNITECHANCE = M_IGNITECHANCE + T_COOLDOWNREDUCTION val2 *; M_CHARGECHANCE = M_CHARGECHANCE + T_COOLDOWNREDUCTION val2 *; M_ARMOR = M_ARMOR + (-0.25)
```

**Values:**
- val1: min 0.25, max 0.45 // Cooldown reduction (+25% to +45%)
- val2: min 0.3, max 0.6 // Proc chance conversion multiplier (30% to 60% of CDR → proc chance)

**Modweight:** 30

**Build Synergies:**
- **Elemental Savant:** Combines cooldown reduction with elemental proc scaling
- **DoT Specialist:** More frequent abilities plus higher ignite/charge application
- **Hybrid builds:** Converts ability-focused stat into elemental damage benefit
- **Cooldown-stacking builds:** Transforms CDR into multi-dimensional scaling

**Trade-offs:**
Severe armor reduction (25%) significantly increases incoming damage. Requires elemental build focus to leverage proc chance bonuses. Anti-synergy with armor-stacking Fortress Tank builds. Must invest in cooldown reduction beyond this item for proc scaling to matter

**Unique Mechanics:**
Build-defining cooldown-to-proc conversion system. Incentivizes stacking COOLDOWNREDUCTION for both ability frequency and elemental application. Creates "fast abilities + high procs" archetype. With 0.5 total CDR and 0.5 val2, grants +0.25 (25%) to both IGNITECHANCE and CHARGECHANCE. Synergizes with elemental damage and DoT builds

**Lore Notes:**
Temporal manipulation nanites accelerate both ability recalibration cycles and elemental effect propagation rates, at cost of defensive matrix coherence

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### ITEM: INFINITE ENERGY REACTOR

**ModID:** 2042
**Type:** 0 (item/passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Prototype perpetual motion reactor reducing all resource costs by val1%, granting val2 energy regeneration per second, and providing 50% cooldown reduction, but decreasing all damage output by 35% and reducing maximum HP by 20%

**HEL Equation:**
```
M_RESOURCEEFFICIENCY = M_RESOURCEEFFICIENCY + val1; B_ENERGYREGEN = B_ENERGYREGEN + val2; M_COOLDOWNREDUCTION = M_COOLDOWNREDUCTION + 0.5; M_GUNDAMAGE = M_GUNDAMAGE + (-0.35); M_MELEEDAMAGE = M_MELEEDAMAGE + (-0.35); M_HP = M_HP + (-0.2)
```

**Values:**
- val1: min 0.7, max 0.9 // Resource cost reduction (+70% to +90%)
- val2: min 40, max 80 // Flat energy regeneration per second (+40 to +80 energy/sec)

**Modweight:** 5

**Build Synergies:**
- **Summoner Commander:** Near-infinite minion deployment capability (minions provide damage)
- **Elemental Savant:** Continuous ability spam with minimal resource constraints
- **DoT Specialist:** Constant DoT application through frequent abilities
- **Support builds:** Enables utility spam role despite damage penalties

**Trade-offs:**
Extreme damage penalty (35% to gun and melee) eliminates direct combat viability. Significant HP reduction (20%) reduces survivability. Forces complete build pivot to minion/DoT/utility focus. Completely incompatible with Glass Cannon or direct damage archetypes. Must rely on alternative damage sources (minions, DoT, environmental)

**Unique Mechanics:**
Build-defining "infinite resource" archetype. 70-90% resource efficiency means most abilities cost 10-30% of normal. Combined with 50% CDR and massive regen, enables near-unlimited ability usage. Creates "ability spammer" playstyle where energy/cooldowns effectively don't exist. Requires build commitment to non-direct-damage strategies. Ultimate summoner/caster enabler

**Lore Implications:**
Player becomes tactical commander rather than combatant. Prioritize minion deployment, area control abilities, and support protocols over direct engagement. Synergizes with MINIONDAMAGE, elemental DoT builds, and utility-focused strategies

**Lore Notes:**
Experimental perpetual energy reactor achieves near-infinite power generation through nanite zero-point extraction, but massive power draw destabilizes weapon systems and structural integrity matrices

---

## DESIGN SUMMARY

**Total Items:** 8
**ID Range:** 2035-2042

**Rarity Distribution:**
- Standard: 3 items (2035-2037) | modweight 190-200
- Enhanced: 2 items (2038-2039) | modweight 70-75
- Advanced: 2 items (2040-2041) | modweight 30-35
- Prototype: 1 item (2042) | modweight 5

**Stat Coverage:**
- ENERGYCAPACITY: 3 items (2035, 2038, 2040)
- ENERGYREGEN: 3 items (2036, 2038, 2042)
- COOLDOWNREDUCTION: 4 items (2037, 2039, 2041, 2042)
- RESOURCEEFFICIENCY: 2 items (2039, 2042)
- GUNDAMAGE: 2 items (2040 - scaling bonus, 2042 - penalty)
- MELEEDAMAGE: 2 items (2040 - scaling bonus, 2042 - penalty)
- SHOTSPERSEC: 1 item (2040 - penalty)
- MAXSTAMINA: 1 item (2038 - penalty)
- PLAYERSPEED: 1 item (2039 - penalty)
- ARMOR: 1 item (2041 - penalty)
- HP: 1 item (2042 - penalty)
- IGNITECHANCE: 1 item (2041 - scaling bonus)
- CHARGECHANCE: 1 item (2041 - scaling bonus)

**Build Archetype Support:**
- Summoner Commander: 8 items (all provide resource management for minion spam)
- Elemental Savant: 8 items (all enable ability-heavy casting builds)
- Speed Demon: 6 items (cooldown reduction for mobility abilities)
- Glass Cannon: 5 items (energy for burst abilities, energy-to-damage scaling)
- Fortress Tank: 4 items (energy for defensive abilities)
- DoT Specialist: 4 items (cooldown reduction + elemental proc scaling)
- Hybrid Berserker: 4 items (energy for ability-augmented combat)

**Trade-off Philosophy:**
- Standard items: Pure resource stats, no penalties (foundation items)
- Enhanced items: 15-20% penalties to secondary systems (stamina, movement)
- Advanced items: 25-30% penalties to primary systems (armor, fire rate) + scaling mechanics
- Prototype: Extreme penalties (35% damage, 20% HP) + build-defining resource elimination

**Scaling Mechanics:**
- **Energy-to-Damage** (2040): Converts ENERGYCAPACITY into offensive power
- **Cooldown-to-Procs** (2041): Transforms COOLDOWNREDUCTION into elemental proc rates
- **Near-Infinite Resources** (2042): Eliminates resource constraints for ability spam

**Resource Management Philosophy:**
- Items 2035-2037: Foundation for any resource-dependent build
- Items 2038-2039: Mid-game combined resource optimization with mobility trade-offs
- Items 2040-2041: End-game conversion of resources into other scaling dimensions
- Item 2042: Ultimate ability-spam enabler for minion/DoT/utility-focused strategies

**Lore Compliance:**
- All terminology uses nanomolecular language (reactor, protocols, matrix, energy reserves)
- No biological references
- Consistent with HIOX energy technology theme
- Player-visible descriptions avoid confidential lore
- Focus on "energy matrix", "resource optimization", "efficiency core" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val, B_X = B_X + val)
- Proper coefficient prefixes (B_ for flat adds, M_ for multiplicative percentages, T_ for read-only)
- M_ values use decimals (0.3 = 30%, -0.15 = -15%)
- Postfix notation for operations (T_ENERGYCAPACITY val2 * 0.001 *)
- Cross-stat dependencies in Advanced/Prototype tiers
- Scaling formulas use appropriate divisors for "per 100" effects

**Unique Design Elements:**
1. **Energy-Damage Scaling** (2040): Creates tension between using energy for abilities vs maintaining capacity for damage
2. **Cooldown-Proc Conversion** (2041): Makes CDR valuable for elemental builds beyond ability frequency
3. **Resource Elimination** (2042): Enables "unlimited abilities" archetype at cost of direct combat capability
4. **Universal Utility**: All items support ability-heavy playstyles across archetypes
5. **Synergy Chains**: Energy capacity → energy damage scaling, cooldown reduction → proc scaling

**Balance Considerations:**
- Standard items provide foundation without breaking resource economy
- Enhanced items have meaningful 15-20% trade-offs to mobility/stamina systems
- Advanced items have severe 25-35% penalties justified by unique scaling mechanics
- Prototype eliminates resource constraints but forces non-direct-damage build commitment
- Fire rate penalty on energy-damage item prevents it from being pure upgrade
- Armor penalty on cooldown-proc item prevents defensive stacking with elemental builds
- Damage penalties on infinite energy item ensure it doesn't create overpowered caster builds

**Synergy Opportunities:**
- Combine 2035 + 2040 for maximum energy-to-damage scaling
- Stack 2037 + 2041 for extreme cooldown reduction + elemental proc rates
- Use 2042 with MINIONDAMAGE items for ultimate summoner build
- Pair 2038 with Elemental Savant for sustained ability casting
- Combine 2039 + 2042 for near-zero ability costs with rapid cooldowns
- Use 2041 with elemental damage items for combined proc + damage scaling

---

**END OF RESOURCE CONTROLLERS ITEMS DESIGN**
