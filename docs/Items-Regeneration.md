# Regeneration Systems Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2015-2020 (6 items)
**Class Type:** Regeneration Systems
**Item Type Code:** 0 (item/passive)

---

## CLASS OVERVIEW

**Regeneration Systems** are passive nanite reconstruction assemblies that continuously restore structural integrity, energy reserves, and defensive barriers during combat and downtime. These systems enable sustain-focused builds through persistent recovery mechanics rather than burst healing.

**Core Characteristics:**
- Passive regeneration (HPREGEN, STAMINAREGEN, SHIELDREGENRATE)
- Sustain and endurance scaling
- Enables aggressive face-tanking strategies
- May scale with maximum capacity stats for percentage-based recovery
- Varieties: Basic reconstruction, hybrid recovery, threshold-triggered emergency protocols

**Build Archetype Support:**
- Fortress Tank (HP sustain, shield regeneration)
- Hybrid Berserker (combat sustain for aggressive playstyles)
- Summoner Commander (passive recovery while minions engage)
- Speed Demon (stamina recovery for continuous mobility)

---

## STANDARD CONFIGURATION TIER (2 items)

### ITEM: NANITE RECONSTRUCTION MATRIX

**ModID:** 2015
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Automated repair protocols continuously reconstruct damaged framework nanites, restoring val1 structural integrity points per second during combat

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +
```

**Values:**
- val1: min 5, max 15 // Flat HP regeneration per second (+5 to +15 HP/sec)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Fortress Tank:** Core sustain item for HP-focused tank builds
- **Hybrid Berserker:** Enables aggressive face-tanking during melee combat
- **Summoner Commander:** Passive recovery while minions absorb damage

**Trade-offs:**
No penalties - baseline sustain item for testing regeneration strategies. Flat regeneration becomes less effective in late-game without percentage scaling

---

### ITEM: STAMINA RECOVERY PROTOCOLS

**ModID:** 2016
**Type:** 0 (item/passive)
**Rarity:** Standard

**Description (Player-Visible):**
Optimized energy reclamation systems accelerate stamina reconstitution, restoring val1 stamina points per second for continuous tactical mobility

**HEL Equation:**
```
B_STAMINAREGEN = B_STAMINAREGEN val1 +
```

**Values:**
- val1: min 8, max 20 // Flat stamina regeneration per second (+8 to +20 stamina/sec)

**Modweight:** 180

**Build Synergies:**
- **Speed Demon:** Essential for continuous dash and mobility ability spam
- **Hybrid Berserker:** Enables frequent melee power attacks and dodges
- **Fortress Tank:** Supports shield bash and block stamina costs

**Trade-offs:**
No penalties - baseline mobility sustain. Diminishing returns if stamina capacity is low or abilities don't consume stamina

---

## ENHANCED PROTOCOL TIER (2 items)

### ITEM: INTEGRATED SELF-REPAIR SYSTEM

**ModID:** 2017
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Dual-layer restoration protocols simultaneously reconstruct structural integrity (val1 HP/sec) and replenish energy reserves (val2 stamina/sec), but reduce maximum structural capacity by 10%

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; M_HP = M_HP -0.1 +
```

**Values:**
- val1: min 10, max 20 // HP regeneration per second (+10 to +20 HP/sec)
- val2: min 12, max 25 // Stamina regeneration per second (+12 to +25 stamina/sec)

**Modweight:** 70

**Build Synergies:**
- **Hybrid Berserker:** Complete combat sustain for extended aggressive engagements
- **Speed Demon:** HP recovery while maintaining high mobility uptime
- **Fortress Tank:** Dual recovery compensates for max HP reduction

**Trade-offs:**
10% max HP reduction affects survivability ceiling. Trade-off is worthwhile for builds emphasizing continuous recovery over burst HP pools. Less effective for one-shot defense strategies

---

### ITEM: ADAPTIVE RESTORATION CORE

**ModID:** 2018
**Type:** 0 (item/passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Tri-spectrum regeneration matrix restoring structural integrity (val1 HP/sec), stamina (val2/sec), and energy barriers (25% shield regen rate), with 15% reduced damage output

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; M_SHIELDREGENRATE = M_SHIELDREGENRATE 0.25 +; M_GUNDAMAGE = M_GUNDAMAGE -0.15 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.15 +
```

**Values:**
- val1: min 8, max 15 // HP regeneration per second (+8 to +15 HP/sec)
- val2: min 10, max 20 // Stamina regeneration per second (+10 to +20 stamina/sec)

**Modweight:** 65

**Build Synergies:**
- **Fortress Tank:** Complete defensive sustain for shield-tank variants
- **Summoner Commander:** Passive recovery while minions provide damage
- **Hybrid Berserker:** Triple sustain enables ultra-aggressive playstyle despite damage penalty

**Trade-offs:**
15% damage reduction to both gun and melee attacks. Only viable for sustain-focused builds where minions or DoT effects provide primary damage. Requires extended combat duration to leverage regeneration advantage

---

## ADVANCED MATRIX TIER (1 item)

### ITEM: PERCENTAGE-BASED RECONSTRUCTION FIELD

**ModID:** 2019
**Type:** 0 (item/passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Adaptive nanite protocols restore val1% of maximum structural integrity per second and val2% of max stamina per second, but reduce base armor effectiveness by 25%

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN + T_HP val1 * 0.01 *; B_STAMINAREGEN = B_STAMINAREGEN + T_MAXSTAMINA val2 * 0.01 *; M_ARMOR = M_ARMOR -0.25 +
```

**Values:**
- val1: min 1.5, max 3.0 // HP regen as % of max HP per second (1.5% to 3.0% max HP/sec)
- val2: min 2.0, max 4.0 // Stamina regen as % of max stamina per second (2.0% to 4.0% max stamina/sec)

**Modweight:** 30

**Build Synergies:**
- **Fortress Tank:** Scales exponentially with HP stacking strategies (3% of 3000 HP = 90 HP/sec)
- **Hybrid Berserker:** Percentage-based recovery scales with defensive investment
- **Summoner Commander:** Benefits from HP stacking without sacrificing sustain efficiency

**Trade-offs:**
25% armor reduction significantly increases incoming damage. Requires massive HP pools (1000+ HP) to generate meaningful regen values. Anti-synergy with armor-stacking builds. Must invest in HP to justify armor sacrifice

**Unique Mechanics:**
Build-defining for HP-stacking strategies. Creates "regen tank" archetype distinct from armor tanks. Rewards MAXHPPERCENTBONUS investment. The higher your max HP, the more valuable this item becomes (exponential scaling)

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### ITEM: CRITICAL MASS REGENERATOR

**ModID:** 2020
**Type:** 0 (item/passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Emergency reconstruction protocols activate when structural integrity falls below 30%, providing val1 HP/sec regeneration and converting val2% of total regeneration into bonus damage output

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN T_HP T_HP 0.3 * < val1 * +; M_GUNDAMAGE = M_GUNDAMAGE T_HPREGEN val2 * 0.01 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HPREGEN val2 * 0.01 * +
```

**Values:**
- val1: min 80, max 150 // Emergency HP regen when below 30% HP (+80 to +150 HP/sec)
- val2: min 3, max 6 // Damage conversion from total regen (+3% to +6% damage per point of HPREGEN)

**Modweight:** 5

**Build Synergies:**
- **Hybrid Berserker:** Creates "low HP berserker" archetype with extreme damage when injured
- **Glass Cannon:** Converts defensive stat into offensive scaling (regen → damage)
- **Fortress Tank:** Emergency safety net for critical moments + damage scaling

**Trade-offs:**
Emergency regen only triggers below 30% HP (high-risk threshold). Requires other regen sources to maximize damage conversion. Creates tension between staying injured for damage vs recovering for safety. No inherent penalties, but conditional activation

**Unique Mechanics:**
Build-defining "low-health berserker" playstyle. Incentivizes stacking HPREGEN for damage conversion (even if you don't need healing). Creates strategic decisions: "Do I recover or stay low for damage?" Combines defensive and offensive scaling in one item. Synergizes with LIFESTEAL to maintain dangerous HP threshold

---

## DESIGN SUMMARY

**Total Items:** 6
**ID Range:** 2015-2020

**Rarity Distribution:**
- Standard: 2 items (2015-2016) | modweight 180-200
- Enhanced: 2 items (2017-2018) | modweight 65-70
- Advanced: 1 item (2019) | modweight 30
- Prototype: 1 item (2020) | modweight 5

**Stat Coverage:**
- HPREGEN: 6 items (all items provide HP regeneration)
- STAMINAREGEN: 4 items (2016, 2017, 2018, 2019)
- SHIELDREGENRATE: 1 item (2018)
- ARMOR: 1 item (2019 - penalty)
- HP: 1 item (2017 - penalty)
- GUNDAMAGE: 2 items (2018 - penalty, 2020 - bonus)
- MELEEDAMAGE: 2 items (2018 - penalty, 2020 - bonus)

**Build Archetype Support:**
- Fortress Tank: 6 items (primary sustain archetype)
- Hybrid Berserker: 5 items (aggressive sustain builds)
- Summoner Commander: 4 items (passive recovery while minions engage)
- Speed Demon: 3 items (stamina recovery for mobility)
- Glass Cannon: 1 item (damage conversion strategy)

**Regeneration Philosophy:**
- Standard tier provides baseline flat regeneration
- Enhanced tier combines multiple regen types with moderate trade-offs
- Advanced tier creates percentage-based scaling (rewards stat investment)
- Prototype tier enables unique "regen-to-damage" conversion and emergency triggers

**Trade-off Philosophy:**
- Standard items: No penalties (baseline testing)
- Enhanced items: 10-15% reduction to HP, damage, or capacity
- Advanced item: 25% armor reduction (forces HP-stacking strategy)
- Prototype item: No direct penalty, but conditional activation + risk/reward design

**Lore Compliance:**
- All terminology uses nanomolecular language (reconstruction, protocols, nanites, framework)
- No biological references (no "healing", uses "reconstruction" and "repair")
- Consistent with HIOX world lore (nanite-based world)
- Player-visible descriptions avoid confidential lore elements

**HEL Equation Validation:**
- All equations add to coefficients (B_X = B_X + val)
- Proper coefficient prefixes (B_ for base additive, M_ for multiplicative, T_ for read-only)
- M_ values use decimals (0.25 = 25%, -0.15 = -15%)
- Postfix notation for operations (T_HP val1 * 0.01 *)
- Boolean conditionals for threshold triggers (T_HP T_HP 0.3 * <)
- Cross-stat dependencies in Prototype tier (T_HPREGEN → damage conversion)

**Sustain Build Strategy:**
- Items 2015-2016: Foundation for any sustain build
- Items 2017-2018: Mid-game multi-layered recovery with damage trade-offs
- Item 2019: End-game percentage scaling for HP stackers
- Item 2020: Build-defining regen-damage hybrid for berserker archetypes

**Synergy Opportunities:**
- Combine 2015 + 2019 for massive percentage-based HP regen on tank builds
- Stack 2016 + 2017 for extreme stamina sustain on Speed Demon
- Use 2020 with multiple regen sources for maximum damage conversion
- Pair 2018 with shield-tank builds for triple-layer sustain
- Combine 2019 with MAXHPPERCENTBONUS stat for exponential regen scaling

---

**END OF REGENERATION SYSTEMS ITEMS DESIGN**
