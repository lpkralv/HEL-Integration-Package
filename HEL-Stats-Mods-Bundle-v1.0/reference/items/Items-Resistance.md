# Resistance Array Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2029-2034 (6 items)
**Class Type:** Resistance Arrays
**Item Type Code:** 0 (passive)

---

## CLASS OVERVIEW

**Resistance Arrays** are elemental defense systems that provide specialized protection against fire, electric, and corruption damage types. These passive modifications enable defensive builds to mitigate elemental threats while some advanced variants convert defensive capabilities into offensive penetration or damage output.

**Core Characteristics:**
- Focus on FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE, and ELEMENTALPENETRATION
- Enable elemental defense specialization
- Advanced items convert resistance to offensive stats
- Support both pure defensive tanks and elemental damage dealers

**Build Archetype Support:**
- Fortress Tank (elemental defense variants)
- Elemental Savant (penetration scaling for damage)
- DoT Specialist (resistance for sustain, penetration for damage)
- Hybrid Berserker (elemental sustain during melee)

---

## STANDARD CONFIGURATION TIER (3 items)

### MOD: THERMAL INSULATION MATRIX

**ModID:** 2029
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Thermal barrier nanites increasing fire damage resistance by val1% through heat dissipation protocols

**HEL Equation:**
```
M_FIRERESISTANCE = M_FIRERESISTANCE + val1
```

**Values:**
- val1: min 0.25, max 0.5 // Fire resistance boost (+25% to +50%)
- val2: 0 (unused)

**Modweight:** 195 (common drop)

**Build Synergies:**
- **Fortress Tank:** Core fire defense for elemental threat zones
- **Hybrid Berserker:** Sustain against fire enemies during melee
- **Elemental Savant:** Defensive layer for high-fire environments
- **DoT Specialist:** Survival in fire-heavy encounters

**Trade-offs:**
Pure defensive bonus with no penalties - specialized baseline for fire-focused encounters

**Lore Notes:**
Ablative thermal dispersion nanites absorb and redistribute heat energy across outer framework surfaces, preventing ignite damage from penetrating core systems

---

### MOD: ELECTRIC INSULATION GRID

**ModID:** 2030
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Conductive shielding increasing electric damage resistance by val1% through charge redistribution matrices

**HEL Equation:**
```
M_ELECTRICRESISTANCE = M_ELECTRICRESISTANCE + val1
```

**Values:**
- val1: min 0.25, max 0.5 // Electric resistance boost (+25% to +50%)
- val2: 0 (unused)

**Modweight:** 195

**Build Synergies:**
- **Fortress Tank:** Essential electric defense against shock damage
- **Hybrid Berserker:** Protection during close-range combat with electric enemies
- **Elemental Savant:** Defensive foundation for lightning-heavy zones
- **Speed Demon:** Sustain during high-mobility encounters with electric threats

**Trade-offs:**
Pure defensive bonus with no penalties - specialized baseline for electric-focused encounters

**Lore Notes:**
Faraday cage nanite networks redirect electric discharge around critical systems, grounding charge buildup through framework dispersion channels

---

### MOD: CORRUPTION BARRIER PROTOCOL

**ModID:** 2031
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Viral code resistance increasing corruption damage mitigation by val1% through firewall integrity systems

**HEL Equation:**
```
M_CORRUPTIONRESISTANCE = M_CORRUPTIONRESISTANCE + val1
```

**Values:**
- val1: min 0.25, max 0.5 // Corruption resistance boost (+25% to +50%)
- val2: 0 (unused)

**Modweight:** 195

**Build Synergies:**
- **Fortress Tank:** Critical defense against corruption DoT effects
- **DoT Specialist:** Counter-resistance for corruption-heavy zones
- **Elemental Savant:** Defensive layer when facing corrupted constructs
- **Summoner Commander:** Survivability against viral spread mechanics

**Trade-offs:**
Pure defensive bonus with no penalties - specialized baseline for corruption-focused encounters

**Lore Notes:**
Anti-viral quarantine protocols isolate and purge malicious code attempts, preventing corruption from cascading through nanite framework systems

---

## ENHANCED PROTOCOL TIER (1 item)

### MOD: TRI-ELEMENT RESISTANCE CORE

**ModID:** 2032
**Type:** 0 (passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Unified elemental barrier granting val1% fire, electric, and corruption resistance, but reducing maximum HP by 15%

**HEL Equation:**
```
M_FIRERESISTANCE = M_FIRERESISTANCE + val1; M_ELECTRICRESISTANCE = M_ELECTRICRESISTANCE + val1; M_CORRUPTIONRESISTANCE = M_CORRUPTIONRESISTANCE + val1; M_HP = M_HP + (-0.15)
```

**Values:**
- val1: min 0.15, max 0.35 // Universal resistance boost (+15% to +35% each element)
- val2: 0 (unused)

**Modweight:** 80

**Build Synergies:**
- **Fortress Tank:** Broad elemental defense against mixed damage types
- **Hybrid Berserker:** General purpose elemental sustain for varied encounters
- **Elemental Savant:** Foundation defense across all elemental threat types
- **DoT Specialist:** Universal DoT mitigation across damage types

**Trade-offs:**
HP reduction (15%) lowers total health pool, creating vulnerability to physical damage. Most effective in elemental-heavy encounters, less efficient against pure physical damage. Broad coverage versus specialized single-element protection.

**Lore Notes:**
Integrated multi-spectrum barrier systems provide comprehensive elemental coverage through unified resistance protocols, at cost of reduced structural mass allocation to base HP framework

---

## ADVANCED MATRIX TIER (1 item)

### MOD: ELEMENTAL PENETRATION CONVERTER

**ModID:** 2033
**Type:** 0 (passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental protocols converting elemental resistance into offensive penetration, gaining val1% elemental penetration per 100 combined resistance and val2% base penetration, with 25% reduced fire rate

**HEL Equation:**
```
B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION + val2; B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION + T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + val1 * 0.01 *; M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.25)
```

**Values:**
- val1: min 0.005, max 0.015 // Resistance-to-penetration scaling (0.5%-1.5% penetration per 100 combined resistance)
- val2: min 0.05, max 0.15 // Base penetration boost (+5% to +15%)

**Modweight:** 40

**Build Synergies:**
- **Elemental Savant:** Converts defensive stats into offensive penetration scaling
- **DoT Specialist:** Enables resistance stacking for penetration-focused DoT builds
- **Fortress Tank:** Transforms tank build into elemental damage dealer
- **Unique archetype:** "Resistant Savant" - stack resistance for both defense and penetration

**Trade-offs:**
Severe fire rate reduction (25%) impacts sustained DPS output. Requires heavy resistance investment for penetration scaling to compensate. Less effective for pure glass cannon builds. Fire rate loss conflicts with rapid-fire weapon strategies.

**Unique Mechanics:**
Build-defining resistance-to-penetration conversion system. Incentivizes stacking all resistance types beyond defensive benefit. Creates "resistance = offense" synergy. With 300 combined resistance (100 each element) and 1.0 val1, grants +3% additional penetration (total 8-18% penetration).

**Lore Notes:**
Adaptive frequency modulation systems analyze absorbed elemental energy signatures, repurposing resistance calibration data to attune offensive elemental attacks for maximum enemy barrier bypass

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### MOD: ELEMENTAL ABSORPTION DEVASTATOR

**ModID:** 2034
**Type:** 0 (passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental absorption core granting val1% resistance to all elements and converting absorbed elemental damage into gun and melee damage, gaining 1% damage per 50 resistance across all elements, with 30% reduced movement speed and 20% reduced fire rate

**HEL Equation:**
```
M_FIRERESISTANCE = M_FIRERESISTANCE + val1; M_ELECTRICRESISTANCE = M_ELECTRICRESISTANCE + val1; M_CORRUPTIONRESISTANCE = M_CORRUPTIONRESISTANCE + val1; M_GUNDAMAGE = M_GUNDAMAGE + T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + 0.02 *; M_MELEEDAMAGE = M_MELEEDAMAGE + T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + 0.02 *; M_PLAYERSPEED = M_PLAYERSPEED + (-0.3); M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.2)
```

**Values:**
- val1: min 0.4, max 0.8 // Universal resistance boost (+40% to +80% each element)
- val2: 0 (unused)

**Modweight:** 10

**Build Synergies:**
- **Fortress Tank:** Extreme elemental defense with offensive scaling
- **Elemental Savant:** Converts resistance into damage for hybrid tank-damage build
- **Hybrid Berserker:** Enables aggressive tank playstyle with damage scaling from defense
- **Unique archetype:** "Elemental Juggernaut" - extreme resistance and damage, minimal mobility

**Trade-offs:**
Extreme mobility penalty (30% move speed) creates slow-moving tank archetype. Fire rate reduction (20%) impacts sustained gun DPS. Requires heavy resistance investment for damage scaling to compensate penalties. Completely incompatible with Speed Demon builds.

**Unique Mechanics:**
Build-defining resistance-to-damage conversion system. Rewards stacking all three resistance types for maximum offensive benefit. Creates "absorb elements to deal damage" fantasy. With 300 combined resistance (100 each) and high val1, grants +6% gun/melee damage while maintaining 40-80% resistance to all elements. Enables extreme resistance values (200+ per element) for massive damage scaling.

**Lore Implications:**
Player becomes elemental fortress - prioritizes positioning in elemental damage zones. Thrives in fire/electric/corruption heavy encounters. Absorbs elemental damage through resistance and converts it to offensive power. Ultimate "elemental tank" item.

**Lore Notes:**
Prototype energy recycling core captures elemental damage absorbed by resistance systems, channeling captured fire, electric, and corruption energy directly into weapon power matrices for devastating offensive output

---

## DESIGN SUMMARY

**Total Items:** 6
**ID Range:** 2029-2034

**Rarity Distribution:**
- Standard: 3 items (2029-2031) | modweight 195
- Enhanced: 1 item (2032) | modweight 80
- Advanced: 1 item (2033) | modweight 40
- Prototype: 1 item (2034) | modweight 10

**Stat Coverage:**
- FIRERESISTANCE (M_FIRERESISTANCE): 3 items (2029, 2032, 2034)
- ELECTRICRESISTANCE (M_ELECTRICRESISTANCE): 3 items (2030, 2032, 2034)
- CORRUPTIONRESISTANCE (M_CORRUPTIONRESISTANCE): 3 items (2031, 2032, 2034)
- ELEMENTALPENETRATION (B_ELEMENTALPENETRATION): 1 item (2033)
- HP (M_HP): 1 item (2032 penalty)
- PLAYERSPEED (M_PLAYERSPEED): 1 item (2034 penalty)
- SHOTSPERSEC (M_SHOTSPERSEC): 2 items (2033, 2034 penalties)
- GUNDAMAGE (M_GUNDAMAGE): 1 item (2034 scaling bonus)
- MELEEDAMAGE (M_MELEEDAMAGE): 1 item (2034 scaling bonus)

**Build Archetype Support:**
- Fortress Tank: 6 items (all items support elemental tank variants)
- Elemental Savant: 3 items (2032, 2033, 2034 - penetration and resistance synergies)
- DoT Specialist: 5 items (2029-2033 - sustain and penetration for DoT builds)
- Hybrid Berserker: 5 items (2029-2032, 2034 - elemental sustain during melee)
- Speed Demon: 3 items (2029-2031 - selective resistance without mobility loss)
- Summoner Commander: 4 items (2029-2032 - survivability against elemental threats)

**Trade-off Philosophy:**
- Standard items: Pure resistance, no penalties (foundation items)
- Enhanced items: Moderate penalties (15% to HP)
- Advanced items: Severe penalties (25% to fire rate) + scaling mechanics
- Prototype: Extreme penalties (20-30% to mobility/fire rate) + build-defining conversion

**Scaling Mechanics:**
- **Resistance-to-Penetration** (2033): Incentivizes resistance stacking for offensive penetration
- **Resistance-to-Damage** (2034): Converts elemental defense into gun/melee damage output

**Lore Compliance:**
- All terminology uses nanomolecular language (thermal nanites, insulation grid, barrier protocol)
- No biological references
- Consistent with HIOX defensive technology theme
- Player-visible descriptions avoid confidential lore
- Focus on "resistance matrix", "insulation protocol", "elemental barrier" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val1)
- Proper coefficient prefixes (B_ for flat adds, M_ for percentages)
- M_ values use decimals (0.4 = 40%)
- Postfix notation for operations (T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + val1 * 0.01 *)
- Cross-stat dependencies in Advanced/Prototype tiers
- Scaling formulas use division for "per 100" effects: T_STAT val * 0.01 *

**Unique Design Elements:**
1. **Universal Resistance** (2032): Broad elemental coverage with HP trade-off
2. **Resistance-to-Penetration** (2033): Defensive stat scaling into offense for Elemental Savant
3. **Resistance-to-Damage** (2034): Extreme resistance values converted to damage output

**Balance Considerations:**
- Standard items provide specialized single-element defense without penalties
- Enhanced item offers broad coverage with 15% HP trade-off
- Advanced item enables resistance-to-penetration scaling with 25% fire rate penalty
- Prototype creates unique "elemental juggernaut" archetype with 20-30% mobility/fire rate penalties
- Mobility penalties prevent resistance items from enabling Speed Demon builds
- Fire rate penalties balance offensive scaling variants (Advanced and Prototype)
- Resistance scaling rewards stacking multiple resistance items for synergy
- Penetration conversion enables Elemental Savant to invest in resistance for offense

**Modweight Note:**
Item 2034 (Prototype) has modweight 10 instead of standard 5 because it's a powerful but not game-breaking item that should be more accessible than ultra-rare prototypes. This creates build diversity by allowing more players to experiment with resistance-to-damage conversion strategies.

---

**END OF RESISTANCE ARRAY ITEMS DESIGN**
