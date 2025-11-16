# Elemental Infusion Syringes Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 3030-3038 (9 syringes)
**Class Type:** Elemental Infusions
**Item Type Code:** 10 (syringe/upgrade)

---

## CLASS OVERVIEW

**Elemental Infusions** are elemental damage injection protocols that weaponize nanite systems with thermal (ignite), electrical (charge), and viral (corruption) attack vectors. These stackable injections enable elemental status effect builds by providing ignite/charge/corruption chance and damage bonuses, forming the foundation of Elemental Savant and DoT Specialist archetypes.

**Core Characteristics:**
- Focus on IGNITECHANCE, IGNITEDAMAGE, CHARGECHANCE, CHARGEDAMAGE, CORRUPTIONCHANCE, CORRUPTIONDAMAGE
- Smaller bonuses than items (+5-20% vs +30-60%) but fully stackable
- Enable elemental proc chains and status effect spreading
- Advanced syringes feature dual-element mechanics
- Prototype tier provides tri-element conversion mechanics
- Support both pure elemental builds and hybrid damage dealers

**Build Archetype Support:**
- Elemental Savant (pure elemental damage focus)
- DoT Specialist (status effect stacking and area denial)
- Hybrid Berserker (elemental melee/ranged synergy)
- Glass Cannon (elemental burst damage)

---

## STANDARD INJECTION TIER (4 syringes)

### SYRINGE: THERMAL IGNITION SERUM

**ModID:** 3030
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Thermal dispersion protocol increasing ignite application chance by val1% through heat-signature targeting nanites

**HEL Equation:**
```
M_IGNITECHANCE = M_IGNITECHANCE val1 +
```

**Values:**
- val1: min 0.06, max 0.1 // Ignite chance increase (+6% to +10%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Elemental Savant:** Core ignite application for fire-based builds
- **DoT Specialist:** Foundation for thermal DoT stacking
- **Glass Cannon:** Added fire proc for burst damage
- **Hybrid Berserker:** Ignite chance on melee/ranged attacks

**Trade-offs:**
Pure offensive bonus with no penalties - stackable foundation for elemental builds

**Lore Notes:**
Thermal targeting nanites identify heat-vulnerable structural points in enemy frameworks, increasing probability of successful ignition cascade protocols

---

### SYRINGE: ELECTRIC DISCHARGE SERUM

**ModID:** 3031
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Electrical capacitor protocol increasing charge application chance by val1% through static buildup acceleration nanites

**HEL Equation:**
```
M_CHARGECHANCE = M_CHARGECHANCE val1 +
```

**Values:**
- val1: min 0.06, max 0.1 // Charge chance increase (+6% to +10%)

**Modweight:** 200

**Build Synergies:**
- **Elemental Savant:** Essential charge proc for electric-focused builds
- **DoT Specialist:** Electric DoT stacking foundation
- **Speed Demon:** Added electric proc for hit-and-run tactics
- **Glass Cannon:** Charge chance for shock damage bursts

**Trade-offs:**
Pure offensive bonus with no penalties - stackable foundation for electric builds

**Lore Notes:**
Static accumulation nanites optimize electron transfer protocols, accelerating charge buildup in enemy conductive systems for reliable electrical discharge triggering

---

### SYRINGE: VIRAL CORRUPTION SERUM

**ModID:** 3032
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Malicious code injection protocol increasing corruption application chance by val1% through viral propagation nanites

**HEL Equation:**
```
M_CORRUPTIONCHANCE = M_CORRUPTIONCHANCE val1 +
```

**Values:**
- val1: min 0.06, max 0.1 // Corruption chance increase (+6% to +10%)

**Modweight:** 200

**Build Synergies:**
- **Elemental Savant:** Core corruption proc for viral damage builds
- **DoT Specialist:** Foundation for corruption DoT spreading
- **Summoner Commander:** Corruption chance on minion attacks
- **Hybrid Berserker:** Viral damage on sustained combat

**Trade-offs:**
Pure offensive bonus with no penalties - stackable foundation for corruption builds

**Lore Notes:**
Weaponized viral code packets infiltrate enemy nanite frameworks on contact, increasing probability of successful malware injection and corruption cascade activation

---

### SYRINGE: ELEMENTAL AMPLIFICATION SERUM

**ModID:** 3033
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Universal elemental enhancement increasing ignite, charge, and corruption damage by val1 per second through status effect amplification

**HEL Equation:**
```
B_IGNITEDAMAGE = B_IGNITEDAMAGE val1 +; B_CHARGEDAMAGE = B_CHARGEDAMAGE val1 +; B_CORRUPTIONDAMAGE = B_CORRUPTIONDAMAGE val1 +
```

**Values:**
- val1: min 4, max 8 // Elemental damage increase (+4 to +8 damage per second for all elements)

**Modweight:** 180

**Build Synergies:**
- **Elemental Savant:** Universal damage boost for all elemental types
- **DoT Specialist:** Amplifies all active DoT effects
- **Hybrid Berserker:** Scales all elemental procs equally
- **Glass Cannon:** Flat elemental damage for mixed-element builds

**Trade-offs:**
Pure offensive bonus with no penalties - broad but smaller impact than specialized single-element damage

**Lore Notes:**
Multi-spectrum signal amplification nanites boost all elemental damage protocols simultaneously, enhancing thermal, electrical, and viral cascade intensity across all attack vectors

---

## ENHANCED PROTOCOL TIER (2 syringes)

### SYRINGE: DUAL-ELEMENT FUSION PROTOCOL

**ModID:** 3034
**Type:** 10 (syringe/upgrade)
**Rarity:** Enhanced

**Description (Player-Visible):**
Experimental dual-element injection granting val1% ignite chance and val2% charge chance, with 8% reduced gun damage

**HEL Equation:**
```
M_IGNITECHANCE = M_IGNITECHANCE val1 +; M_CHARGECHANCE = M_CHARGECHANCE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.08 +
```

**Values:**
- val1: min 0.12, max 0.18 // Ignite chance (+12% to +18%)
- val2: min 0.12, max 0.18 // Charge chance (+12% to +18%)

**Modweight:** 90

**Build Synergies:**
- **Elemental Savant:** Enables dual-element proc strategies
- **DoT Specialist:** Multi-element DoT stacking for area control
- **Hybrid Berserker:** Elemental diversity on melee/ranged
- **Glass Cannon:** Dual-element proc for status variety (reduced direct damage trade-off)

**Trade-offs:**
Gun damage reduction (8%) lowers direct damage output. Best for elemental proc builds where status effects outweigh base damage. Less effective for pure direct damage strategies.

**Lore Notes:**
Synchronized thermal and electrical cascade protocols enable simultaneous ignite and charge application, though competing signal pathways reduce direct weapon damage amplification efficiency

---

### SYRINGE: TRI-ELEMENT DAMAGE CATALYST

**ModID:** 3035
**Type:** 10 (syringe/upgrade)
**Rarity:** Enhanced

**Description (Player-Visible):**
Universal catalyst injection boosting ignite damage by val1, charge damage by val1, and corruption damage by val1, with 10% reduced fire rate

**HEL Equation:**
```
B_IGNITEDAMAGE = B_IGNITEDAMAGE val1 +; B_CHARGEDAMAGE = B_CHARGEDAMAGE val1 +; B_CORRUPTIONDAMAGE = B_CORRUPTIONDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.1 +
```

**Values:**
- val1: min 10, max 18 // Universal elemental damage boost (+10 to +18 damage per second for all elements)

**Modweight:** 85

**Build Synergies:**
- **Elemental Savant:** Maximum elemental damage scaling for all elements
- **DoT Specialist:** Extreme DoT amplification across all status types
- **Hybrid Berserker:** Scales all elemental procs for hybrid combat
- **Summoner Commander:** Boosts minion elemental damage (if minions proc elements)

**Trade-offs:**
Fire rate reduction (10%) slows attack speed and reduces proc application frequency. Best for builds with high base elemental chance where damage per proc matters more than proc frequency.

**Lore Notes:**
Aggressive signal amplification nanites overdrive all elemental damage cascades, but competing processing demands slow weapon cycling rates through resource allocation conflicts

---

## ADVANCED MATRIX TIER (2 syringes)

### SYRINGE: ELEMENTAL PENETRATION INJECTOR

**ModID:** 3036
**Type:** 10 (syringe/upgrade)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental barrier-bypass protocol granting val1% elemental penetration and val2% increased elemental proc chance across all elements, with 15% reduced armor

**HEL Equation:**
```
M_ELEMENTALPENETRATION = M_ELEMENTALPENETRATION val1 +; M_IGNITECHANCE = M_IGNITECHANCE val2 +; M_CHARGECHANCE = M_CHARGECHANCE val2 +; M_CORRUPTIONCHANCE = M_CORRUPTIONCHANCE val2 +; M_ARMOR = M_ARMOR -0.15 +
```

**Values:**
- val1: min 0.15, max 0.25 // Elemental penetration (+15% to +25%)
- val2: min 0.08, max 0.12 // Universal elemental chance (+8% to +12% for all elements)

**Modweight:** 40

**Build Synergies:**
- **Elemental Savant:** Bypass enemy elemental resistances for maximum damage
- **DoT Specialist:** Penetration ensures elemental DoTs deal full damage
- **Glass Cannon:** Penetration enables elemental burst damage against resistant enemies
- **Hybrid Berserker:** Universal elemental chance and penetration for all combat modes

**Trade-offs:**
Armor reduction (15%) lowers physical defense significantly. Creates glass cannon elemental specialist - high offense, low defense. Incompatible with Fortress Tank archetype. Prioritize elemental damage over survivability.

**Lore Notes:**
Barrier-disruption nanites identify and exploit weaknesses in enemy resistance matrices, enabling elemental damage bypass protocols at cost of structural nanite allocation to defensive armor frameworks

---

### SYRINGE: ELEMENTAL CHAIN REACTION PROTOCOL

**ModID:** 3037
**Type:** 10 (syringe/upgrade)
**Rarity:** Advanced

**Description (Player-Visible):**
Cascade amplification injection granting val1% increased elemental damage and val2% elemental chance per active elemental status effect on player, with 12% reduced movement speed

**HEL Equation:**
```
M_IGNITEDAMAGE = M_IGNITEDAMAGE + T_IGNITESTACKS val1 *; M_CHARGEDAMAGE = M_CHARGEDAMAGE + T_CHARGESTACKS val1 *; M_CORRUPTIONDAMAGE = M_CORRUPTIONDAMAGE + T_CORRUPTIONSTACKS val1 *; M_IGNITECHANCE = M_IGNITECHANCE + T_IGNITESTACKS val2 *; M_CHARGECHANCE = M_CHARGECHANCE + T_CHARGESTACKS val2 *; M_CORRUPTIONCHANCE = M_CORRUPTIONCHANCE + T_CORRUPTIONSTACKS val2 *; M_PLAYERSPEED = M_PLAYERSPEED -0.12 +
```

**Values:**
- val1: min 0.03, max 0.06 // Elemental damage scaling (+3% to +6% per stack)
- val2: min 0.02, max 0.04 // Elemental chance scaling (+2% to +4% per stack)

**Modweight:** 35

**Build Synergies:**
- **Elemental Savant:** Rewards stacking multiple elemental status effects for massive scaling
- **DoT Specialist:** Chain reaction mechanic for exponential DoT growth
- **Unique archetype:** "Elemental Cascade" - self-inflicted status effects become offensive scaling
- **Glass Cannon:** High-risk high-reward elemental scaling when player has multiple status effects active

**Trade-offs:**
Movement speed penalty (12%) creates slow-moving elemental caster archetype. Scaling requires player to have active status effects (self-damage or enemy procs), creating high-risk gameplay. Incompatible with Speed Demon builds.

**Unique Mechanics:**
Build-defining self-damage scaling system. Encourages intentionally taking elemental damage to gain offensive power. With 5 total stacks (e.g., 2 ignite, 2 charge, 1 corruption) and max val1, gains +30% elemental damage and +20% elemental chance. Creates "absorb elements to deal damage" fantasy similar to certain RPG builds.

**Lore Notes:**
Experimental feedback loop nanites analyze active status effects on player framework, repurposing elemental damage signatures to calibrate and amplify outgoing elemental attack protocols for cascade multiplication

---

## PROTOTYPE ASSEMBLY TIER (1 syringe)

### SYRINGE: OMNI-ELEMENTAL CONVERSION CORE

**ModID:** 3038
**Type:** 10 (syringe/upgrade)
**Rarity:** Prototype

**Description (Player-Visible):**
Ultimate elemental transformation converting all weapon damage to elemental damage types, granting val1% ignite, charge, and corruption chance and converting 100% of gun/melee damage to elemental damage, with 25% reduced fire rate and 20% reduced movement speed

**HEL Equation:**
```
M_IGNITECHANCE = M_IGNITECHANCE val1 +; M_CHARGECHANCE = M_CHARGECHANCE val1 +; M_CORRUPTIONCHANCE = M_CORRUPTIONCHANCE val1 +; M_IGNITEDAMAGE = M_IGNITEDAMAGE + T_GUNDAMAGE T_MELEEDAMAGE + 1.0 *; M_CHARGEDAMAGE = M_CHARGEDAMAGE + T_GUNDAMAGE T_MELEEDAMAGE + 1.0 *; M_CORRUPTIONDAMAGE = M_CORRUPTIONDAMAGE + T_GUNDAMAGE T_MELEEDAMAGE + 1.0 *; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +; M_PLAYERSPEED = M_PLAYERSPEED -0.2 +
```

**Values:**
- val1: min 0.5, max 0.8 // Universal elemental chance (+50% to +80% for all elements)

**Modweight:** 10

**Build Synergies:**
- **Elemental Savant:** Complete transformation into pure elemental damage dealer
- **DoT Specialist:** Converts all damage into DoT application vectors
- **Unique archetype:** "Elemental Purist" - 100% elemental damage, zero direct damage
- **Hybrid Berserker:** Transforms both melee and gun damage to elemental procs

**Trade-offs:**
Extreme mobility (20%) and fire rate (25%) penalties create very slow, methodical elemental caster. Converts ALL weapon damage to elemental damage types - player becomes 100% dependent on elemental damage and penetration. Completely ineffective against elemental-immune enemies. Massive shift in playstyle.

**Unique Mechanics:**
Build-defining damage conversion system. Transforms player into pure elemental damage dealer by converting gun/melee damage to ignite/charge/corruption damage. With 200 total gun+melee damage and max val1, each attack has 80% chance to apply 200 ignite, 200 charge, and 200 corruption damage. Enables "no direct damage, only DoT" archetype.

**Lore Implications:**
Player becomes walking elemental weapon - every attack is converted to elemental status applications. Prioritizes elemental penetration and elemental damage mods. Requires heavy investment in IGNITEDAMAGE, CHARGEDAMAGE, CORRUPTIONDAMAGE scaling. Synergizes with "Elemental Penetration Converter" item (ModID 2033) for resistance-to-penetration conversion.

**Lore Notes:**
Prototype total conversion nanites intercept all outgoing weapon damage protocols and reroute 100% of energy to elemental cascade generation matrices, transforming every attack into simultaneous thermal, electrical, and viral status application vectors at cost of direct damage output

---

## DESIGN SUMMARY

**Total Syringes:** 9
**ID Range:** 3030-3038

**Rarity Distribution:**
- Standard: 4 syringes (3030-3033) | modweight 180-200
- Enhanced: 2 syringes (3034-3035) | modweight 85-90
- Advanced: 2 syringes (3036-3037) | modweight 35-40
- Prototype: 1 syringe (3038) | modweight 10

**Stat Coverage:**
- IGNITECHANCE (M_IGNITECHANCE): 6 syringes (3030, 3034, 3036, 3037, 3038)
- IGNITEDAMAGE (M/B_IGNITEDAMAGE): 4 syringes (3033, 3035, 3037, 3038)
- CHARGECHANCE (M_CHARGECHANCE): 6 syringes (3031, 3034, 3036, 3037, 3038)
- CHARGEDAMAGE (M/B_CHARGEDAMAGE): 4 syringes (3033, 3035, 3037, 3038)
- CORRUPTIONCHANCE (M_CORRUPTIONCHANCE): 5 syringes (3032, 3036, 3037, 3038)
- CORRUPTIONDAMAGE (M/B_CORRUPTIONDAMAGE): 4 syringes (3033, 3035, 3037, 3038)
- ELEMENTALPENETRATION (M_ELEMENTALPENETRATION): 1 syringe (3036)
- GUNDAMAGE (M_GUNDAMAGE): 1 syringe (3034 penalty)
- SHOTSPERSEC (M_SHOTSPERSEC): 2 syringes (3035, 3038 penalties)
- ARMOR (M_ARMOR): 1 syringe (3036 penalty)
- PLAYERSPEED (M_PLAYERSPEED): 2 syringes (3037, 3038 penalties)

**Build Archetype Support:**
- Elemental Savant: 9 syringes (all items support elemental damage builds)
- DoT Specialist: 9 syringes (all items enable status effect stacking)
- Glass Cannon: 5 syringes (3030-3034, 3036 - elemental burst damage)
- Hybrid Berserker: 6 syringes (3030-3034, 3038 - elemental melee/ranged)
- Summoner Commander: 2 syringes (3032, 3035 - corruption and universal damage)
- Speed Demon: 2 syringes (3030-3031 - no mobility penalties)

**Trade-off Philosophy:**
- Standard syringes: Pure elemental bonuses, no penalties (foundation)
- Enhanced syringes: Moderate penalties (8-10% to damage/fire rate)
- Advanced syringes: Severe penalties (12-15% to armor/mobility) + scaling mechanics
- Prototype: Extreme penalties (20-25% to mobility/fire rate) + build-defining conversion

**Scaling Mechanics:**
- **Stack-Scaling** (3037): Elemental damage/chance scales with active status effects on player
- **Damage Conversion** (3038): Converts all weapon damage to elemental damage types

**Lore Compliance:**
- All terminology uses nanomolecular language (thermal nanites, viral code, electrical discharge)
- No biological references
- Consistent with HIOX elemental technology theme
- Player-visible descriptions avoid confidential lore
- Focus on "thermal/electrical/viral protocols" and "cascade mechanics"

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val1)
- Proper coefficient prefixes (B_ for flat damage, M_ for percentages/chances)
- M_ values use decimals (0.5 = 50%, not 50)
- Complex scaling uses T_ read-only stats (T_IGNITESTACKS, T_GUNDAMAGE)
- Postfix notation for operations (T_GUNDAMAGE T_MELEEDAMAGE + 1.0 *)

**Unique Design Elements:**
1. **Dual-Element Fusion** (3034): Two elemental chances with damage trade-off
2. **Tri-Element Catalyst** (3035): Universal elemental damage with fire rate penalty
3. **Elemental Chain Reaction** (3037): Self-damage scaling for offensive boost
4. **Omni-Elemental Conversion** (3038): 100% damage-to-elemental conversion system

**Balance Considerations:**
- Standard syringes provide single-element chance or universal damage without penalties
- Enhanced syringes offer dual/tri-element effects with 8-10% damage/fire rate penalties
- Advanced syringes enable penetration and scaling mechanics with 12-15% defense/mobility penalties
- Prototype creates unique "pure elemental damage" archetype with 20-25% mobility/fire rate penalties
- Conversion mechanics (3038) enable complete build transformation
- Stack-scaling (3037) rewards high-risk self-damage gameplay
- Elemental penetration (3036) ensures effectiveness against resistant enemies

---

**END OF ELEMENTAL INFUSION SYRINGES DESIGN**
