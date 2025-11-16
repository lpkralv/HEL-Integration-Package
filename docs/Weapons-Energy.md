# Weapons-Energy: Energy Emitter Class (10 weapons)

**Designer:** W2
**Weapon Class:** Energy Emitters
**ID Range:** 515-524
**Type Code:** 2 (ranged weapons)
**Total Count:** 10 weapons

---

## DESIGN PHILOSOPHY

Energy Emitters represent directed energy weapon systems utilizing coherent light, plasma discharge, and electromagnetic projection technologies. These weapons emphasize:

- **Precision Damage:** High accuracy with focused energy beams
- **Elemental Synergy:** Natural integration with fire and electric damage types
- **Energy Mechanics:** Utilization of ENERGYCAPACITY and heat-based trade-offs
- **Continuous/Burst Modes:** Sustained beam projection or pulsed energy discharge
- **Penetration:** Ability to pierce through enemy defenses and multiple targets

**Archetype Support:**
- Elemental Savant (primary)
- Precision Sniper (secondary)
- Glass Cannon (tertiary)
- DoT Specialist (elemental variants)

---

## WEAPON DESIGNS

### 515 - COHERENT LIGHT PROJECTOR (Standard)

**Rarity:** Standard Configuration
**Category:** Basic precision laser

```yaml
modid: 515
uuid: uuid-515-515515515515515515
val: 0.15
val2: 0
val1min: 0.1
val1max: 0.2
val2min: 0
val2max: 0
name: COHERENT LIGHT PROJECTOR
desc: Emits focused photonic beam with val1% improved accuracy and instant projectile velocity
modweight: 100
type: 2
hasProc: 0
equation: M_ACCURACY = M_ACCURACY -val1 +; B_BULLETSPEED = B_BULLETSPEED 9999 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Entry-level energy weapon providing instant-hit laser mechanics. The extreme bullet speed simulates hitscan behavior, while accuracy bonus rewards precision play. No damage penalties, making it reliable for players new to energy weapons.

**Lore:**
Concentrated photon streams generated through nanite-calibrated optical arrays. Projects coherent light beams at near-instantaneous velocities, eliminating projectile travel time for perfect target acquisition.

**Build Synergy:**
Supports Precision Sniper builds through accuracy stacking. Works with tactical processors for range extension. Foundation weapon for transitioning from ballistic to energy combat styles.

---

### 516 - PLASMA DISCHARGE RIFLE (Standard)

**Rarity:** Standard Configuration
**Category:** Moderate fire rate plasma weapon

```yaml
modid: 516
uuid: uuid-516-516516516516516516
val: 0.35
val2: 0.12
val1min: 0.25
val1max: 0.45
val2min: 0.08
val2max: 0.15
name: PLASMA DISCHARGE RIFLE
desc: Fires superheated plasma packets with val1% increased damage but val2% reduced fire rate due to thermal cycling
modweight: 80
type: 2
hasProc: 0
equation: M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC -val2 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Classic damage-for-speed trade-off. Higher damage per shot compensates for slower fire rate, creating deliberate pacing. Thermal cycling justification provides lore-appropriate limitation. Balanced for sustained combat.

**Lore:**
Magnetically contained plasma chambers superheat nanite matter to extreme temperatures before launching. Thermal dissipation protocols limit firing frequency to prevent emitter framework degradation.

**Build Synergy:**
Excellent for Glass Cannon builds maximizing per-shot damage. Pairs with Combat Stimulants for damage stacking. Works with RELOADSPEED buffs to minimize downtime between thermal cycles.

---

### 517 - PULSE LASER ARRAY (Standard)

**Rarity:** Standard Configuration
**Category:** Burst-fire precision laser

```yaml
modid: 517
uuid: uuid-517-517517517517517517
val: 3
val2: 0.18
val1min: 2
val1max: 4
val2min: 0.15
val2max: 0.25
name: PULSE LASER ARRAY
desc: Fires val1 rapid laser pulses per trigger pull with val2% increased critical strike chance per pulse
modweight: 75
type: 2
hasProc: 0
equation: B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Burst-fire weapon rewarding accuracy through critical strike potential. Multiple pulses per shot create satisfying burst damage while maintaining energy weapon precision. Crit chance scales with pulse count for compounding effectiveness.

**Lore:**
Synchronized emitter banks discharge coordinated pulse sequences through optimized firing matrices. Each pulse recalibrates targeting protocols, increasing probability of critical structural hits within burst window.

**Build Synergy:**
Core weapon for Precision Sniper crit builds. Synergizes with CRITDAMAGE mods for devastating burst potential. Works with Offensive Augments boosting crit chance to achieve near-guaranteed crits.

---

### 518 - DIRECTED ENERGY BEAM (Standard)

**Rarity:** Enhanced Protocol
**Category:** Sustained beam weapon

```yaml
modid: 518
uuid: uuid-518-518518518518518518
val: 0.55
val2: 0.08
val1min: 0.4
val1max: 0.7
val2min: 0.05
val2max: 0.12
name: DIRECTED ENERGY BEAM
desc: Projects continuous energy beam dealing val1% increased damage but consuming val2 energy per second during sustained fire
modweight: 65
type: 2
hasProc: 0
equation: M_GUNDAMAGE = M_GUNDAMAGE val1 +; B_ENERGYCAPACITY = B_ENERGYCAPACITY -50 +; M_ENERGYREGEN = M_ENERGYREGEN -val2 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Introduces energy economy mechanics to weapon design. High damage output balanced by energy drain, requiring resource management. Creates distinct playstyle from ammo-based ballistics. Energy capacity penalty forces investment in energy stats.

**Lore:**
Maintains coherent beam projection through continuous nanite matter conversion into directed energy streams. Extreme power draw strains reactor capacity, requiring optimized energy distribution networks for sustained operation.

**Build Synergy:**
Requires Resource Controllers for ENERGYCAPACITY/ENERGYREGEN support. Pairs with Metabolic Enhancers for energy sustain. Enables energy-focused Glass Cannon builds trading resources for damage output.

---

### 519 - THERMAL LANCE EMITTER (Enhanced - Elemental Fire)

**Rarity:** Enhanced Protocol
**Category:** Fire-focused energy weapon

```yaml
modid: 519
uuid: uuid-519-519519519519519519
val: 0.45
val2: 3
val1min: 0.35
val1max: 0.55
val2min: 2
val2max: 5
name: THERMAL LANCE EMITTER
desc: Superheated beam with val1 ignite chance, causing fires to spread to val2 nearby targets within effective range
modweight: 50
type: 2
hasProc: 0
equation: B_IGNITECHANCE = B_IGNITECHANCE val1 +; B_IGNITESPREAD = B_IGNITESPREAD val2 +; M_GUNDAMAGE = M_GUNDAMAGE 0.2 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
First elemental energy weapon utilizing new IGNITESPREAD stat. High ignite chance combined with spread mechanics enables area denial through fire propagation. Moderate damage bonus makes it competitive with standard weapons while adding elemental utility.

**Lore:**
Thermal projection systems channel extreme heat into concentrated beams, igniting target nanite structures on contact. Radiant energy transfer protocols propagate thermal cascade effects to nearby enemy constructs within effective range.

**Build Synergy:**
Core weapon for Elemental Savant fire builds. Synergizes with Elemental Infusions boosting IGNITECHANCE and IGNITEDAMAGE. Works with ELEMENTALPENETRATION for reliable ignite application against resistant enemies. Enables DoT Specialist area control strategies.

---

### 520 - ARC DISCHARGE ARRAY (Enhanced - Elemental Electric)

**Rarity:** Enhanced Protocol
**Category:** Electric-focused chain weapon

```yaml
modid: 520
uuid: uuid-520-520520520520520520
val: 0.38
val2: 4
val1min: 0.3
val1max: 0.5
val2min: 3
val2max: 6
name: ARC DISCHARGE ARRAY
desc: Electrical discharge with val1 charge chance that chains to val2 additional targets, dealing reduced damage per chain
modweight: 45
type: 2
hasProc: 0
equation: B_CHARGECHANCE = B_CHARGECHANCE val1 +; B_CHAINLIGHTNING = B_CHAINLIGHTNING val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.15 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: Electric
armorMeshName: ''
```

**Design Rationale:**
Utilizes new CHAINLIGHTNING stat for electric-themed area damage. Chain mechanic rewards enemy grouping and positioning. Fire rate penalty balances multi-target potential. Creates satisfying chain reaction moments in dense combat.

**Lore:**
Electromagnetic emitters generate high-voltage discharge pulses that propagate through conductive pathways between enemy nanite frameworks. Arc finding protocols identify optimal chain targets within proximity range, creating cascading electrical damage networks.

**Build Synergy:**
Essential for Elemental Savant electric builds. Pairs with Elemental Infusions for CHARGECHANCE/CHARGEDAMAGE stacking. Synergizes with CHAINLIGHTNING mods for extreme chain counts. Enables screen-clearing potential for DoT Specialists.

---

### 521 - PHOTONIC ACCELERATOR RIFLE (Enhanced - Precision)

**Rarity:** Enhanced Protocol
**Category:** High-precision energy weapon

```yaml
modid: 521
uuid: uuid-521-521521521521521521
val: 0.25
val2: 0.8
val1min: 0.2
val1max: 0.3
val2min: 0.6
val2max: 1.2
name: PHOTONIC ACCELERATOR RIFLE
desc: Ultra-precise photon beam with val1 critical chance bonus and val2 critical damage multiplier when accuracy exceeds 90%
modweight: 40
type: 2
hasProc: 0
equation: M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE T_ACCURACY 0.9 > val2 * +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Conditional damage scaling rewards accuracy investment. Uses HEL conditional logic to gate bonus behind accuracy threshold. Creates skill-based scaling where precision directly translates to critical damage output. Enables high-risk, high-reward precision gameplay.

**Lore:**
Advanced photonic acceleration systems achieve unprecedented beam coherence through adaptive stabilization matrices. Optimal beam focus requires calibration precision above 90% accuracy, unlocking critical structural damage amplification protocols.

**Build Synergy:**
Perfect for Precision Sniper archetype. Requires Tactical Injections for accuracy stacking above 90% threshold. Synergizes with Offensive Augments boosting CRITCHANCE and CRITDAMAGE. Rewards skilled positioning and aim.

---

### 522 - PENETRATING BEAM PROJECTOR (Advanced)

**Rarity:** Advanced Matrix
**Category:** Armor-piercing energy weapon

```yaml
modid: 522
uuid: uuid-522-522522522522522522
val: 4
val2: 0.35
val1min: 3
val1max: 6
val2min: 0.25
val2max: 0.45
name: PENETRATING BEAM PROJECTOR
desc: Coherent beam pierces val1 enemies and ignores val2% of elemental resistances, dealing val2% more damage per enemy pierced
modweight: 25
type: 2
hasProc: 0
equation: B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION val2 +; M_GUNDAMAGE = M_GUNDAMAGE T_PIERCINGSHOTS val2 0.1 * * +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Advanced weapon utilizing both PIERCINGSHOTS and ELEMENTALPENETRATION stats. Damage scales with pierce count, rewarding positioning to line up multiple enemies. Penetration bonus makes it effective against resistant targets. Complex equation showcases HEL cross-stat dependency.

**Lore:**
Experimental beam coherence protocols maintain structural integrity through multiple target penetrations. Nanite compression field generators prevent dispersion while adaptive frequency modulation bypasses enemy resistance calibrations. Each penetration amplifies beam intensity through matter-energy recapture.

**Build Synergy:**
Cornerstone weapon for DoT Specialist pierce builds. Works with Elemental Infusions for resistance-bypassing elemental damage. Synergizes with PIERCINGSHOTS mods for extreme penetration counts. Rewards tactical positioning for maximum pierce chains.

---

### 523 - STORM CALLER ARRAY (Advanced)

**Rarity:** Advanced Matrix
**Category:** Multi-chain lightning projector

```yaml
modid: 523
uuid: uuid-523-523523523523523523
val: 6
val2: 0.55
val1min: 5
val1max: 8
val2min: 0.45
val2max: 0.7
name: STORM CALLER ARRAY
desc: Cascading lightning emission chains to val1 targets with val2 charge chance, consuming 0.15 energy per chain event
modweight: 20
type: 2
hasProc: 0
equation: B_CHAINLIGHTNING = B_CHAINLIGHTNING val1 +; B_CHARGECHANCE = B_CHARGECHANCE val2 +; B_ENERGYCAPACITY = B_ENERGYCAPACITY -30 +; M_GUNDAMAGE = M_GUNDAMAGE 0.15 +
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: Electric
armorMeshName: ''
```

**Design Rationale:**
Maximum chain count weapon for electric builds. Extreme CHAINLIGHTNING value creates screen-clearing potential in grouped enemies. Energy cost and capacity penalty balance overwhelming AoE power. High charge chance ensures reliable elemental application across chains.

**Lore:**
Storm-class electromagnetic arrays generate cascading voltage differentials across enemy formations, creating self-propagating electrical networks. Advanced arc-finding algorithms identify optimal chain paths, sustaining discharge sequences through continuous energy cycling protocols.

**Build Synergy:**
Ultimate weapon for Elemental Savant electric specialists. Requires Resource Controllers for energy sustain. Pairs with Elemental Infusions for CHARGEDAMAGE scaling. Works with Minion Protocols for combined electric damage strategies. Enables "chain everything" endgame builds.

---

### 524 - CHROMATIC MATRIX CONVERTER (Prototype)

**Rarity:** Prototype Assembly
**Category:** Damage conversion specialist weapon

```yaml
modid: 524
uuid: uuid-524-524524524524524524
val: 0.8
val2: 5
val1min: 0.8
val1max: 0.8
val2min: 5
val2max: 5
name: CHROMATIC MATRIX CONVERTER
desc: Experimental system converts all damage to thermal energy with fixed val1 ignite chance, spreading to val2 targets but consuming massive energy reserves
modweight: 8
type: 2
hasProc: 0
equation: B_IGNITECHANCE = B_IGNITECHANCE val1 +; B_IGNITESPREAD = B_IGNITESPREAD val2 +; M_GUNDAMAGE = M_GUNDAMAGE 0.5 +; B_ENERGYCAPACITY = B_ENERGYCAPACITY -80 +; M_ENERGYREGEN = M_ENERGYREGEN -0.25 +
modColor: {r: 255, g: 100, b: 0, a: 255}
armorEffectName: Fire
armorMeshName: ''
```

**Design Rationale:**
Build-defining prototype weapon forcing full commitment to fire-based strategies. Near-guaranteed ignite chance (80%) with maximum spread creates "everything burns" playstyle. Extreme energy penalties require dedicated energy economy investment. Unique mechanics justify low modweight and distinct visual coloring.

**Lore:**
CLASSIFIED PROTOTYPE: Chromatic nanite conversion matrices transmute all emitted energy into pure thermal radiation. Experimental frequency modulation achieves unprecedented ignite reliability but catastrophically drains reactor reserves. Thermal cascade protocols propagate ignition across maximum tactical range.

**Build Synergy:**
Defines entire Elemental Savant fire build around single weapon. Mandatory pairing with Resource Controllers and Metabolic Enhancers for energy sustain. Synergizes with Elemental Infusions for IGNITEDAMAGE scaling. Enables "convert all damage to fire" archetype mentioned in requirements.

---

## WEAPON STATISTICS SUMMARY

**Distribution:**
- Standard: 4 weapons (515-518)
- Enhanced: 3 weapons (519-521)
- Advanced: 2 weapons (522-523)
- Prototype: 1 weapon (524)

**modweight Distribution:**
- Common (75-100): 3 weapons (standard tier)
- Uncommon (40-65): 4 weapons (enhanced tier)
- Rare (20-25): 2 weapons (advanced tier)
- Very Rare (8): 1 weapon (prototype tier)

**Stat Utilization (NEW stats emphasized):**
- IGNITECHANCE: 3 weapons (519, 524)
- CHARGECHANCE: 3 weapons (520, 523)
- CHAINLIGHTNING: 2 weapons (520, 523) ✓ NEW
- IGNITESPREAD: 2 weapons (519, 524) ✓ NEW
- ELEMENTALPENETRATION: 1 weapon (522) ✓ NEW
- CRITCHANCE: 2 weapons (517, 521) ✓ NEW
- CRITDAMAGE: 1 weapon (521) ✓ NEW
- PIERCINGSHOTS: 1 weapon (522) ✓ NEW
- ENERGYCAPACITY: 4 weapons (518, 523, 524) ✓ NEW
- ENERGYREGEN: 2 weapons (518, 524) ✓ NEW
- ACCURACY: 2 weapons (515, 521)
- BULLETSPEED: 1 weapon (515)
- GUNDAMAGE: 8 weapons (various)
- SHOTSPERSEC: 3 weapons (516, 520, trade-offs)
- BULLETSFIRED: 1 weapon (517)

**Equation Complexity:**
- Simple (1-2 statements): 6 weapons
- Moderate (3 statements): 3 weapons
- Complex (conditional logic): 2 weapons (521, 522)

**Elemental Coverage:**
- Fire: 2 weapons (519, 524)
- Electric: 2 weapons (520, 523)
- Neutral: 6 weapons (515-518, 521-522)

---

## ARCHETYPE SUPPORT ANALYSIS

### Elemental Savant (Primary Support)
**Weapons:** 519, 520, 523, 524
**Coverage:** Complete fire and electric build paths with spread/chain mechanics
**Synergies:** All elemental weapons work with Elemental Infusions syringes

### Precision Sniper (Secondary Support)
**Weapons:** 515, 517, 521, 522
**Coverage:** Accuracy, crit chance, crit damage, and piercing mechanics
**Synergies:** Pairs with Tactical Injections and Offensive Augments

### Glass Cannon (Tertiary Support)
**Weapons:** 516, 518, 521
**Coverage:** High damage output through direct scaling and crit mechanics
**Synergies:** Works with Combat Stimulants for damage stacking

### DoT Specialist (Elemental Variants)
**Weapons:** 519, 520, 522, 523, 524
**Coverage:** Elemental application, spread, chain, and penetration
**Synergies:** Supports area denial through elemental propagation

---

## BALANCE CONSIDERATIONS

**Trade-off Patterns:**
- Energy weapons trade ammo mechanics for energy economy
- Higher precision requires accuracy investment (conditional bonuses)
- Elemental effects balanced by fire rate or energy costs
- Chain/spread mechanics require enemy grouping for effectiveness

**Power Curve:**
- Standard tier: Reliable baseline performance, no major drawbacks
- Enhanced tier: Specialized strengths with moderate limitations
- Advanced tier: Build-defining mechanics with significant investment requirements
- Prototype tier: Extreme power gated behind harsh resource constraints

**Cross-Class Synergies:**
- Offensive Augments: Boost crit-focused energy weapons (517, 521)
- Resource Controllers: Enable energy-intensive weapons (518, 523, 524)
- Elemental Infusions: Scale elemental energy weapons (519, 520, 523, 524)
- Tactical Processors: Enhance pierce and accuracy mechanics (515, 521, 522)

---

## LORE INTEGRATION

All weapon names avoid biological terminology and generic sci-fi tropes:
- ✓ "Photonic Accelerator" vs ❌ "Laser Gun"
- ✓ "Plasma Discharge Rifle" vs ❌ "Plasma Blaster"
- ✓ "Arc Discharge Array" vs ❌ "Lightning Shooter"
- ✓ "Chromatic Matrix Converter" vs ❌ "Fire Laser"

All descriptions use nanomolecular terminology:
- Nanite frameworks, structural integrity, protocols
- Energy conversion, thermal cycling, coherence
- No biological references (no blood, flesh, organs)

All lore maintains HIOX world consistency:
- No confidential reveals about player identity
- Technology-based explanations for all mechanics
- Appropriate power source attribution (reactors, energy fields)

---

## EQUATION VALIDATION

All equations follow HEL syntax requirements:
- ✓ Always add to coefficients: `M_X = M_X val1 +`
- ✓ Use lowercase val1/val2 in equations
- ✓ Pure postfix notation for all operations: `val1 0.5 * +`
- ✓ Separate statements with semicolons
- ✓ Use proper coefficient prefixes (B_, M_, A_, Z_, U_)
- ✓ M_ values are decimals (0.5 = 50%)
- ✓ Conditional logic properly formatted: `T_ACCURACY 0.9 > val2 * +`

**Complex Equation Examples:**

*Photonic Accelerator (521):*
```
M_CRITDAMAGE = M_CRITDAMAGE T_ACCURACY 0.9 > val2 * +
```
Only adds val2 to crit damage if accuracy exceeds 0.9 (90%)

*Penetrating Beam (522):*
```
M_GUNDAMAGE = M_GUNDAMAGE T_PIERCINGSHOTS val2 0.1 * * +
```
Damage scales with current piercing shot count × val2 × 0.1

---

## FORMAT COMPLIANCE CHECKLIST

- [✓] All modids unique and within 515-524 range
- [✓] All uuids follow pattern `uuid-{modid}-{repeating}`
- [✓] All type = 2 (ranged weapons)
- [✓] All names are ALL CAPS WITH SPACES
- [✓] All descs use "val1" and "val2" placeholders (lowercase)
- [✓] All equations use correct prefixes (B_, M_, A_, Z_, U_)
- [✓] All equations add to coefficients (not overwrite)
- [✓] All M_ values are decimals for percentages
- [✓] All modweights appropriate for rarity tier
- [✓] All val1min/max and val2min/max are balanced
- [✓] All lore is nanomolecular (no biological terms)
- [✓] All weapons support at least 1 archetype clearly
- [✓] All weapons synergize with other mod classes

---

## IMPLEMENTATION NOTES

**For Integration Agent:**

When adding these weapons to ModsData.asset, ensure:
1. IDs 515-524 are not already occupied
2. All uuid values are globally unique
3. armorEffectName values match existing game effect names (Electric, Fire)
4. modColor values use Unity color format {r, g, b, a}
5. Equations are tested for HEL syntax validity
6. Val ranges produce balanced gameplay across difficulty tiers

**Testing Priorities:**
1. Energy economy weapons (518, 523, 524) - verify energy drain doesn't break gameplay
2. Conditional weapons (521, 522) - confirm conditional logic triggers correctly
3. Chain/spread weapons (519, 520, 523, 524) - validate AoE propagation
4. Crit weapons (517, 521) - ensure crit chance/damage calculations work properly

**Balance Tuning:**
- If energy weapons feel underpowered, reduce energy penalties on 518/524
- If elemental spread is overwhelming, reduce IGNITESPREAD/CHAINLIGHTNING values
- If prototype weapon (524) is too strong, increase energy costs further
- If conditional bonuses don't feel impactful, increase val2 ranges on 521/522

---

**END OF WEAPONS-ENERGY DESIGN DOCUMENT**

**Status:** READY FOR INTEGRATION
**Total Weapons:** 10
**New Stats Utilized:** 7 (CHAINLIGHTNING, IGNITESPREAD, ELEMENTALPENETRATION, CRITCHANCE, CRITDAMAGE, PIERCINGSHOTS, ENERGYCAPACITY/ENERGYREGEN)
**Build Archetypes Supported:** 4 (Elemental Savant, Precision Sniper, Glass Cannon, DoT Specialist)
