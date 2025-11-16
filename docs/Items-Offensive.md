# Offensive Augments Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2021-2028 (8 items)
**Class Type:** Offensive Augments
**Item Type Code:** 0 (item/passive)

---

## CLASS OVERVIEW

**Offensive Augments** are aggressive nanite weapon enhancement systems that maximize damage output through critical strike protocols, damage amplification matrices, and proc rate optimization. These passive modifications prioritize raw offensive capability at the cost of defensive integrity, forming the foundation of glass cannon and burst damage builds.

**Core Characteristics:**
- Focus on CRITCHANCE, CRITDAMAGE, PROCRATE, and damage amplification
- Enable Glass Cannon and Precision Sniper archetypes
- Extreme offensive scaling with significant defensive trade-offs
- Advanced items feature conditional mechanics (full HP bonuses, low HP scaling)
- Prototype tier provides build-defining extreme risk/reward

**Build Archetype Support:**
- Glass Cannon (primary - maximum damage focus)
- Precision Sniper (critical strike burst damage)
- Elemental Savant (proc rate scaling for elemental effects)
- Hybrid Berserker (aggressive damage scaling)

---

## STANDARD CONFIGURATION TIER (3 items)

### ITEM: PRECISION TARGETING MATRIX

**ModID:** 2021
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Advanced targeting protocols analyze enemy structural weaknesses, increasing critical strike probability by val1% through enhanced threat assessment algorithms

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +
```

**Values:**
- val1: min 0.15, max 0.3 // Critical strike chance increase (+15% to +30%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Precision Sniper:** Core foundation for critical strike builds
- **Glass Cannon:** Increases burst damage potential for high-risk playstyles
- **Hybrid Berserker:** Enables crit-based melee burst strategies
- **Elemental Savant:** Critical hits can trigger additional elemental effects

**Trade-offs:**
Pure offensive bonus with no penalties - baseline item for testing critical strike synergies. Requires CRITDAMAGE investment to maximize effectiveness

**Lore Notes:**
Targeting algorithms identify critical structural points in enemy nanite frameworks, allowing precision strikes to exploit vulnerabilities

---

### ITEM: DAMAGE AMPLIFIER CORE

**ModID:** 2022
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Weapon output optimization protocols increasing projectile damage by val1% through enhanced energy conversion efficiency

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +
```

**Values:**
- val1: min 0.2, max 0.4 // Gun damage increase (+20% to +40%)

**Modweight:** 200

**Build Synergies:**
- **Glass Cannon:** Direct damage scaling for maximum output
- **Precision Sniper:** Amplifies per-shot damage for sniper builds
- **Elemental Savant:** Increases base damage before elemental application
- **Hybrid Berserker:** Ranged damage boost for weapon-focused builds

**Trade-offs:**
Pure offensive bonus with no penalties - standard baseline for damage-focused builds. No melee damage scaling limits pure melee builds

**Lore Notes:**
Enhanced energy matrices concentrate weapon emitter output, increasing destructive force of nanite-compressed projectiles

---

### ITEM: PROC ENHANCEMENT PROTOCOLS

**ModID:** 2023
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Optimized effect amplification systems increasing proc trigger frequency by val1% for enhanced status effect application rates

**HEL Equation:**
```
M_PROCRATE = M_PROCRATE val1 +
```

**Values:**
- val1: min 0.25, max 0.5 // Proc rate increase (+25% to +50%)

**Modweight:** 190

**Build Synergies:**
- **Elemental Savant:** Core item for elemental proc builds (ignite, charge, corruption)
- **DoT Specialist:** Increases frequency of damage-over-time application
- **Glass Cannon:** More frequent proc triggers for burst damage windows
- **Hybrid Berserker:** Enhanced melee proc application

**Trade-offs:**
Pure offensive bonus with no penalties - baseline for proc-focused strategies. Value depends on weapon proc effects and elemental chance stats

**Lore Notes:**
Cascading reaction protocols optimize nanite destabilization sequences, increasing probability of triggering secondary effects on impact

---

## ENHANCED PROTOCOL TIER (2 items)

### ITEM: CRITICAL STRIKE ASSEMBLY

**ModID:** 2024
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Integrated precision systems granting val1% critical strike chance and val2% critical damage multiplier, with 30% reduced armor effectiveness from structural compromises

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_ARMOR = M_ARMOR -0.3 +
```

**Values:**
- val1: min 0.2, max 0.35 // Critical strike chance increase (+20% to +35%)
- val2: min 0.4, max 0.8 // Critical damage increase (+40% to +80%)

**Modweight:** 75

**Build Synergies:**
- **Precision Sniper:** Complete critical strike package for burst damage builds
- **Glass Cannon:** Maximum crit scaling with acceptable defensive trade-off
- **Hybrid Berserker:** High-damage critical strikes for aggressive melee
- **Elemental Savant:** Critical strikes amplify elemental proc damage

**Trade-offs:**
30% armor reduction significantly increases incoming damage vulnerability. Requires commitment to critical strike strategy - wasted if not building around crits. Forces glass cannon playstyle with reduced survivability

**Lore Notes:**
Targeting matrix integration diverts defensive nanite resources to weapon systems, sacrificing protective plating for enhanced strike precision

---

### ITEM: OFFENSIVE OVERLOAD MATRIX

**ModID:** 2025
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Aggressive weapon calibration increasing gun damage by val1% and proc effectiveness by val2%, but reducing maximum structural integrity by 25% from power distribution compromises

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_PROCRATE = M_PROCRATE val2 +; M_HP = M_HP -0.25 +
```

**Values:**
- val1: min 0.3, max 0.5 // Gun damage increase (+30% to +50%)
- val2: min 0.4, max 0.7 // Proc rate increase (+40% to +70%)

**Modweight:** 70

**Build Synergies:**
- **Glass Cannon:** Combined damage and proc scaling for extreme offense
- **Elemental Savant:** Damage boost plus frequent elemental proc triggers
- **Precision Sniper:** Enhanced per-shot damage with proc utility
- **DoT Specialist:** Frequent proc application for continuous damage effects

**Trade-offs:**
25% HP reduction creates extreme fragility requiring careful positioning. Both benefits require ranged combat (no melee damage). Demands skill-based survival through dodging and positioning. Less effective without elemental or proc-based weapons

**Lore Notes:**
Overclocked weapon systems draw excessive power from life support matrices, channeling structural nanite reserves into offensive output

---

## ADVANCED MATRIX TIER (2 items)

### ITEM: FULL INTEGRITY PROTOCOL

**ModID:** 2026
**Type:** 0 (item/passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Perfection-optimized targeting systems granting val1% critical chance and val2% damage when at maximum structural integrity, but providing no benefits when damaged

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE + (T_HP T_HP <) (-1.0) * val1 *; M_GUNDAMAGE = M_GUNDAMAGE + (T_HP T_HP <) (-1.0) * val2 *; M_MELEEDAMAGE = M_MELEEDAMAGE + (T_HP T_HP <) (-1.0) * val2 *
```

**Values:**
- val1: min 0.5, max 0.8 // Critical chance at full HP (+50% to +80%)
- val2: min 0.4, max 0.7 // Gun and melee damage at full HP (+40% to +70%)

**Modweight:** 35

**Build Synergies:**
- **Glass Cannon:** Extreme first-strike burst damage potential
- **Precision Sniper:** Massive opening shot damage from safe positions
- **Hybrid Berserker:** Incentivizes aggressive full-HP engagement openers
- **Elemental Savant:** Maximum damage for ability-based burst windows

**Trade-offs:**
Zero benefits when damaged - requires maintaining full HP for value. Extremely punishing for face-tank strategies or sustained combat. Rewards perfect execution and first-strike tactics. Anti-synergy with berserker low-HP builds. Requires HPREGEN, LIFESTEAL, or shield investment to reset HP for benefit re-activation

**Unique Mechanics:**
Build-defining conditional damage system. Creates "alpha strike" archetype - massive opening damage disappears when damaged. Rewards positioning, kiting, and burst windows. Synergizes with SHIELDCAPACITY (shields absorb damage before HP). Forces binary playstyle: full HP = godmode offense, damaged = standard build. Enables one-shot strategies from full HP state

**Lore Notes:**
Precision targeting matrices achieve perfect calibration only when all systems operate at peak structural integrity, degrading immediately upon framework compromise

---

### ITEM: BERSERKER SURGE CORE

**ModID:** 2027
**Type:** 0 (item/passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Desperation combat protocols converting structural damage into offensive fury, granting val1% gun and melee damage per 10% HP lost below maximum, with 20% reduced armor

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE + T_HP T_HP / (-1.0) + val1 * 10 *; M_MELEEDAMAGE = M_MELEEDAMAGE + T_HP T_HP / (-1.0) + val1 * 10 *; M_ARMOR = M_ARMOR -0.2 +
```

**Values:**
- val1: min 0.04, max 0.08 // Damage per 10% missing HP (+4% to +8% per 10% HP lost)
- val2: 0 (unused)

**Modweight:** 30

**Build Synergies:**
- **Hybrid Berserker:** Build-defining low-HP aggressive damage scaling
- **Glass Cannon:** Converts vulnerability into extreme damage output
- **Precision Sniper:** Increases damage as combat progresses
- **Hybrid Berserker:** Creates "dying warrior" playstyle - more dangerous when injured

**Trade-offs:**
Armor reduction (20%) compounds with incentive to stay at low HP. Extremely risky playstyle requiring precise HP management. Zero benefit at full HP. Maximum benefit requires operating at critical HP thresholds (90% HP lost = +36-72% damage). Demands LIFESTEAL investment to maintain dangerous HP range without dying

**Unique Mechanics:**
Build-defining inverse HP damage scaling. Creates "low HP berserker" archetype opposite to Full Integrity Protocol. Maximum damage at 10% HP remaining. Synergizes with LIFESTEAL to maintain low HP threshold. With 90% HP missing and 0.08 val1: +72% damage to both gun and melee. Rewards aggressive risk-taking and precise HP management. Anti-synergy with tank builds and high HP pools (harder to maintain low percentages)

**Lore Notes:**
Emergency combat subroutines detect critical structural damage and override safety limiters, channeling all available power to weapon systems in desperate survival protocols

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### ITEM: ABSOLUTE DESTRUCTION CORE

**ModID:** 2028
**Type:** 0 (item/passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental targeting override guaranteeing all attacks strike critical weakpoints (+val1% crit chance) with val2x critical damage multiplier, but reducing max HP by 50%, armor by 60%, and movement speed by 25%

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_HP = M_HP -0.5 +; M_ARMOR = M_ARMOR -0.6 +; M_PLAYERSPEED = M_PLAYERSPEED -0.25 +
```

**Values:**
- val1: min 0.7, max 0.95 // Near-guaranteed critical strikes (+70% to +95% crit chance)
- val2: min 1.5, max 3.0 // Extreme critical damage (+150% to +300% crit damage)

**Modweight:** 5

**Build Synergies:**
- **Glass Cannon:** Ultimate glass cannon item - maximum damage at catastrophic defense cost
- **Precision Sniper:** Near-guaranteed critical strikes for one-shot potential
- **Hybrid Berserker:** Extreme melee burst damage for high-risk aggressive play
- **Elemental Savant:** Critical strikes amplify elemental damage to extreme levels

**Trade-offs:**
Catastrophic defensive penalties: 50% HP loss, 60% armor reduction, 25% movement penalty. Requires perfect positioning and execution - single hit often fatal. Movement penalty prevents effective kiting. Demands LIFESTEAL, DODGECHANCE, or SHIELDCAPACITY investment for survival. Completely incompatible with tank builds. "One-shot or be one-shot" philosophy

**Unique Mechanics:**
Build-defining extreme critical strike system. Near-100% crit chance with extreme crit damage creates consistent massive damage output. With 95% crit chance and 3.0 crit damage: nearly every attack deals 4-5x base damage (1.5 base crit damage + 3.0 bonus = 4.5x multiplier). Single shots can eliminate tough enemies. Creates "delete enemies before they touch you" archetype. Synergizes with AMMOCAPACITY and RELOADSPEED for sustained burst. Requires DODGECHANCE, dash mechanics, or shield builds for survival. Ultimate risk/reward item - highest damage potential with lowest survivability

**Lore Implications:**
Player becomes fragile but devastating damage dealer. Must prioritize range, positioning, and first-strike elimination. Every engagement is life-or-death. Rewards mechanical mastery and precision. Enables speed-running through damage overwhelming

**Lore Notes:**
Prototype override systems eliminate all safety protocols and divert critical life support nanites to weapon targeting matrices, achieving perfect strike precision at catastrophic cost to defensive integrity and mobility

---

## DESIGN SUMMARY

**Total Items:** 8
**ID Range:** 2021-2028

**Rarity Distribution:**
- Standard: 3 items (2021-2023) | modweight 190-200
- Enhanced: 2 items (2024-2025) | modweight 70-75
- Advanced: 2 items (2026-2027) | modweight 30-35
- Prototype: 1 item (2028) | modweight 5

**Stat Coverage:**
- CRITCHANCE: 3 items (2021, 2024, 2026, 2028)
- CRITDAMAGE: 2 items (2024, 2028)
- GUNDAMAGE: 6 items (2022, 2025, 2026, 2027, scaling)
- MELEEDAMAGE: 2 items (2026, 2027, scaling)
- PROCRATE: 2 items (2023, 2025)
- HP: 3 items (penalties: 2025, 2028)
- ARMOR: 3 items (penalties: 2024, 2027, 2028)
- PLAYERSPEED: 1 item (penalty: 2028)

**Build Archetype Support:**
- Glass Cannon: 8 items (all items support primary offensive archetype)
- Precision Sniper: 7 items (critical strike and burst damage focus)
- Elemental Savant: 5 items (proc rate and damage scaling)
- Hybrid Berserker: 5 items (aggressive damage with melee synergies)
- DoT Specialist: 2 items (proc rate enhancement)

**Offensive Philosophy:**
- Standard tier provides baseline offensive stats with no penalties
- Enhanced tier combines multiple offensive stats with moderate defensive trade-offs
- Advanced tier creates conditional mechanics (full HP vs low HP)
- Prototype tier enables extreme damage with catastrophic defensive penalties

**Trade-off Philosophy:**
- Standard items: No penalties (baseline offensive testing)
- Enhanced items: 25-30% reduction to HP or armor
- Advanced item: 20% armor reduction + conditional mechanics
- Prototype item: 50% HP, 60% armor, 25% speed reduction (extreme glass cannon)

**Conditional Mechanics:**
- **Full Integrity Protocol (2026):** Maximum damage only at full HP - rewards alpha strikes
- **Berserker Surge Core (2027):** Scaling damage as HP decreases - rewards low HP risk-taking
- Opposite design philosophies create distinct playstyles within offensive category

**Lore Compliance:**
- All terminology uses nanomolecular language (targeting matrix, damage amplifier, offensive protocol)
- No biological references (structural integrity, not health)
- Consistent with HIOX offensive technology theme
- Player-visible descriptions avoid confidential lore
- Focus on "targeting protocols", "damage amplifiers", "offensive matrices" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val)
- Proper coefficient prefixes (M_ for multiplicative percentages)
- M_ values use decimals (0.3 = 30%, 1.5 = 150%)
- Postfix notation for operations
- Cross-stat dependencies in Advanced/Prototype tiers (T_HP for conditionals)
- Conditional mechanics use comparison operators: (T_HP T_HP <) for "at full HP" detection
- Berserker formula: T_HP T_HP / (-1.0) + calculates HP percentage lost

**Critical Strike System:**
- Baseline CRITCHANCE: 0.05 (5%)
- Standard boost: +15-30% (total 20-35%)
- Enhanced boost: +20-35% with crit damage (total 25-40% + 40-80% damage)
- Advanced boost: +50-80% conditional (total 55-85% when active)
- Prototype boost: +70-95% near-guaranteed (total 75-100%)
- CRITDAMAGE baseline: 1.5x
- Enhanced: +40-80% (1.9x - 2.3x total)
- Prototype: +150-300% (3.0x - 4.5x total)

**Damage Scaling:**
- Standard gun damage: +20-40%
- Enhanced gun damage: +30-50% (with proc synergy)
- Advanced conditional damage: +40-70% at full HP or up to +72% at 10% HP
- Prototype: Near-guaranteed 4-5x damage crits every hit

**Build-Defining Items:**
- **CRITICAL STRIKE ASSEMBLY (2024):** Complete crit package for Precision Sniper builds
- **FULL INTEGRITY PROTOCOL (2026):** Enables alpha strike burst from full HP
- **BERSERKER SURGE CORE (2027):** Creates low-HP aggressive berserker archetype
- **ABSOLUTE DESTRUCTION CORE (2028):** Ultimate glass cannon - maximum damage with extreme fragility

**Synergy Opportunities:**
- Combine 2021 + 2024 for extreme crit chance (55-65% total)
- Stack 2022 + 2025 for layered gun damage (+50-90% total)
- Use 2026 with SHIELDCAPACITY for "full HP" maintenance via shields
- Pair 2027 with LIFESTEAL to maintain dangerous low HP threshold
- Combine 2028 with DODGECHANCE, DASHCOOLDOWN, or SHIELDCAPACITY for survival
- Synergize 2023 + 2025 for extreme proc rate (+65-120% total)

**Anti-Synergies:**
- 2026 (full HP bonus) + 2027 (low HP bonus) conflict mechanically
- Tank items conflict with HP/armor penalties across Enhanced/Prototype tiers
- Mobility penalties on 2028 conflict with Speed Demon builds
- Pure offense focus requires external defensive investment (shields, dodge, lifesteal)

**Balance Considerations:**
- Standard items provide offensive foundation without breaking defensive builds
- Enhanced items have meaningful 25-30% defensive trade-offs
- Advanced items create skill-testing conditional mechanics
- Prototype creates ultimate risk/reward with 50-60% penalties
- No HP regeneration penalties (unlike mobility prototype) - maintains offensive identity
- Movement penalty only on prototype to prevent extreme mobility + offense stacking
- Conditional mechanics reward skillful play (full HP maintenance vs low HP dancing)

---

**END OF OFFENSIVE AUGMENTS ITEMS DESIGN**
