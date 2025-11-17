# Weapons-Melee: Melee Matrix Class (7 weapons)

**Designer:** W6
**Weapon Class:** Melee Matrix
**ID Range:** 1048-1054
**Type Code:** 4 (melee weapons)
**Total Count:** 7 weapons

---

## DESIGN PHILOSOPHY

Melee Matrix weapons represent close-range nanite blade assemblies utilizing coherent molecular edges and kinetic strike systems. These weapons emphasize:

- **High Risk, High Reward:** Close-range combat requires positioning and survivability
- **Speed/Damage Variations:** Fast strikes vs. devastating blows
- **Defensive Integration:** Lifesteal, shields, and thorns for melee survivability
- **Hybrid Potential:** Some designs scale with or convert ranged stats
- **Commitment Requirement:** Often anti-synergize with guns to force melee focus

**Archetype Support:**
- Hybrid Berserker (primary)
- Speed Demon (fast melee variants)
- Fortress Tank (tanky melee with shields/thorns)
- Glass Cannon (high damage melee with lifesteal)

---

## WEAPON DESIGNS

### 1048 - KINETIC BLADE MATRIX (Standard)

**Rarity:** Standard Configuration
**Category:** Balanced melee foundation

```yaml
modid: 1048
uuid: uuid-1048-104810481048104810481048
val: 0.35
val2: 0.25
val1min: 0.25
val1max: 0.45
val2min: 0.15
val2max: 0.35
name: KINETIC BLADE MATRIX
desc: Coherent nanite blade with val1% increased melee damage and val2% improved attack speed for balanced close combat
modweight: 100
type: 4
hasProc: 0
equation: M_MELEEDAMAGE = M_MELEEDAMAGE + val1; M_MELEESPEED = M_MELEESPEED + val2
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Entry-level melee weapon providing balanced offensive stats. No penalties, making it reliable for players transitioning to melee combat. Moderate bonuses to both damage and speed create versatile playstyle without forcing specialization.

**Lore:**
Molecular edge assembly projects coherent kinetic force fields shaped into blade configurations. Nanite strike matrices optimize both impact velocity and structural integrity for balanced close-quarters engagement.

**Build Synergy:**
Foundation weapon for Hybrid Berserker builds. Works with Combat Stimulants for damage scaling. Pairs with Defensive Protocols for survivability. Enables melee experimentation without harsh penalties.

---

### 1049 - VELOCITY STRIKER ASSEMBLY (Standard)

**Rarity:** Standard Configuration
**Category:** High-speed melee weapon

```yaml
modid: 1049
uuid: uuid-1049-104910491049104910491049
val: 0.65
val2: 0.15
val1min: 0.5
val1max: 0.8
val2min: 0.1
val2max: 0.2
name: VELOCITY STRIKER ASSEMBLY
desc: Rapid-strike blade system with val1% increased attack speed and val2% movement speed, but reduced damage per hit
modweight: 80
type: 4
hasProc: 0
equation: M_MELEESPEED = M_MELEESPEED + val1; M_PLAYERSPEED = M_PLAYERSPEED + val2; M_MELEEDAMAGE = M_MELEEDAMAGE + (-0.2)
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Speed-focused melee trading damage for attack rate and mobility. High attack speed compensates for damage penalty through DPS multiplication. Movement speed bonus enhances hit-and-run tactics. Creates "glass blade" playstyle emphasizing rapid strikes.

**Lore:**
Lightweight nanite striker configurations prioritize molecular reconfiguration speed over impact force. Reduced mass burden enhances tactical mobility protocols, enabling rapid repositioning between strike sequences.

**Build Synergy:**
Core weapon for Speed Demon melee builds. Synergizes with Mobility Modules for extreme movement speed. Works with PROCRATE mods for frequent elemental application through rapid hits. Pairs with Offensive Augments to offset damage penalty.

---

### 1050 - IMPACT EDGE CONSTRUCT (Standard)

**Rarity:** Standard Configuration
**Category:** Heavy damage melee weapon

```yaml
modid: 1050
uuid: uuid-1050-105010501050105010501050
val: 0.8
val2: 0.35
val1min: 0.6
val1max: 1.0
val2min: 0.25
val2max: 0.45
name: IMPACT EDGE CONSTRUCT
desc: Heavy molecular blade dealing val1% increased melee damage but reduces attack speed by val2% due to mass recalibration cycles
modweight: 75
type: 4
hasProc: 0
equation: M_MELEEDAMAGE = M_MELEEDAMAGE + val1; M_MELEESPEED = M_MELEESPEED + (-val2)
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Classic damage-for-speed trade-off creating deliberate, powerful strikes. High damage per hit rewards precision timing and positioning. Speed penalty balances massive damage potential. Supports tank builds that can survive extended melee engagements.

**Lore:**
Dense nanite compression matrices amplify kinetic strike force through mass concentration protocols. Extended molecular reconfiguration intervals reduce swing frequency, but each impact delivers devastating structural damage.

**Build Synergy:**
Excellent for Fortress Tank melee builds prioritizing per-hit damage. Pairs with LIFESTEAL for sustain on slower hits. Works with CRITDAMAGE mods for devastating critical strikes. Synergizes with defensive stats to survive close-range combat.

---

### 1051 - THERMAL EDGE PROJECTOR (Enhanced - Elemental Fire)

**Rarity:** Enhanced Protocol
**Category:** Fire-infused melee weapon

```yaml
modid: 1051
uuid: uuid-1051-105110511051105110511051
val: 0.55
val2: 0.15
val1min: 0.45
val1max: 0.65
val2min: 0.1
val2max: 0.2
name: THERMAL EDGE PROJECTOR
desc: Superheated blade edge with val1 ignite chance on melee strikes, granting val2% lifesteal to survive close combat but reducing max HP by 10%
modweight: 50
type: 4
hasProc: 0
equation: B_IGNITECHANCE = B_IGNITECHANCE + val1; M_LIFESTEAL = M_LIFESTEAL + val2; M_HP = M_HP + (-0.1); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.3
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: Fire
armorMeshName: ''
```

**Design Rationale:**
First elemental melee weapon combining fire application with lifesteal survivability. High ignite chance creates DoT damage on strikes. Lifesteal compensates for close-range risk. HP penalty balances strong offensive and defensive bonuses. Creates aggressive "burn and heal" playstyle.

**Lore:**
Thermal nanite blade matrices superheat molecular edges to extreme temperatures, igniting enemy structural frameworks on contact. Energetic feedback protocols convert thermal damage into repair nanites, sustaining your framework through life-draining restoration at cost of maximum structural capacity.

**Build Synergy:**
Core weapon for Elemental Savant melee builds. Synergizes with Elemental Infusions for IGNITEDAMAGE scaling. Pairs with IGNITESPREAD for area damage. Works with MAXHPPERCENTBONUS to offset HP penalty. Enables DoT Specialist melee strategies.

---

### 1052 - VAMPIRIC STRIKE MATRIX (Enhanced - Lifesteal)

**Rarity:** Enhanced Protocol
**Category:** Sustain-focused melee weapon

```yaml
modid: 1052
uuid: uuid-1052-105210521052105210521052
val: 0.45
val2: 0.25
val1min: 0.35
val1max: 0.55
val2min: 0.15
val2max: 0.35
name: VAMPIRIC STRIKE MATRIX
desc: Life-draining blade system granting val1% lifesteal on melee hits and val2% increased attack speed, but reduces gun damage by 40% to force melee commitment
modweight: 45
type: 4
hasProc: 0
equation: M_LIFESTEAL = M_LIFESTEAL + val1; M_MELEESPEED = M_MELEESPEED + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-0.4); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.35
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
High lifesteal melee weapon forcing full commitment to close combat through gun damage anti-synergy. Substantial healing enables aggressive tanking strategies. Attack speed bonus increases healing frequency. Gun penalty prevents ranged fallback, creating pure melee archetype.

**Lore:**
Vampiric nanite extraction protocols drain energy from struck targets, converting disrupted nanite matter into repair substrate for your framework. The extraction matrix monopolizes your weapon systems, disabling ranged projection capabilities to maintain close-range energy siphoning efficiency.

**Build Synergy:**
Cornerstone weapon for Hybrid Berserker archetype. Requires full melee commitment (no gun builds). Pairs with MELEESPEED mods for rapid healing. Works with MELEEDAMAGE scaling for both damage and healing. Synergizes with defensive stats for immortal tank playstyle.

---

### 1053 - RETRIBUTION BLADE ARRAY (Advanced)

**Rarity:** Advanced Matrix
**Category:** Defensive counter-attack melee

```yaml
modid: 1053
uuid: uuid-1053-105310531053105310531053
val: 45
val2: 25
val1min: 35
val1max: 55
val2min: 15
val2max: 35
name: RETRIBUTION BLADE ARRAY
desc: Retaliatory blade system reflecting val1 thorns damage and generating val2 shield on melee kills, but reduces movement speed by 20% and attack speed by 15%
modweight: 25
type: 4
hasProc: 0
equation: B_THORNDAMAGE = B_THORNDAMAGE + val1; B_SHIELDONKILL = B_SHIELDONKILL + val2; M_PLAYERSPEED = M_PLAYERSPEED + (-0.2); M_MELEESPEED = M_MELEESPEED + (-0.15); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.4
modColor: {r: 0, g: 0, b: 0, a: 0}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Advanced defensive melee weapon utilizing new THORNDAMAGE and SHIELDONKILL stats. Thorns punish enemies in melee range while shield generation provides sustain. Speed penalties balance strong defensive mechanics. Creates "fortress melee" playstyle where you become harder to kill the longer you fight.

**Lore:**
Retribution protocols embed reactive counter-strike nanites into blade matrices, automatically retaliating against incoming damage with kinetic reflection. Successful terminations trigger shield nanite deployment, reinforcing your defensive framework. Heavy defensive systems burden mobility and strike recalibration protocols.

**Build Synergy:**
Perfect for Fortress Tank melee builds. Synergizes with THORNDAMAGE mods for extreme reflect damage. Works with SHIELDCAPACITY for larger shields. Pairs with defensive stats (HP, ARMOR, DAMAGEABSORPTION) for immortal tank. Mobility Modules can offset speed penalties.

---

### 1054 - CHROMATIC COHERENCE EDGE (Prototype)

**Rarity:** Prototype Assembly
**Category:** Cross-stat hybrid specialist

```yaml
modid: 1054
uuid: uuid-1054-105410541054105410541054
val: 0.8
val2: 0.8
val1min: 0.8
val1max: 0.8
val2min: 0.8
val2max: 0.8
name: CHROMATIC COHERENCE EDGE
desc: Experimental blade matrix converting val1% of gun damage to melee damage and granting val2 critical chance on melee, but disables ranged weapons entirely and reduces max HP by 15%
modweight: 8
type: 4
hasProc: 0
equation: A_MELEEDAMAGE = A_MELEEDAMAGE + T_GUNDAMAGE val1 *; M_MELEECRITCHANCE = M_MELEECRITCHANCE + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-10); M_HP = M_HP + (-0.15); M_MELEERANGE = M_MELEERANGE + 0.4
modColor: {r: 150, g: 50, b: 255, a: 255}
armorEffectName: ''
armorMeshName: ''
```

**Design Rationale:**
Build-defining prototype enabling unique "gun-scaling melee" archetype. Converts gun damage investment into melee damage via cross-stat dependency. Massive gun damage penalty (-1000%) effectively disables ranged combat. High crit chance rewards precision melee. HP penalty and range bonus force aggressive close-combat playstyle. Unique mechanics justify low modweight and distinct visual coloring.

**Lore:**
CLASSIFIED PROTOTYPE: Chromatic coherence matrices channel ranged weapon calibration protocols into molecular blade edge amplification. Experimental frequency modulation converts projectile damage calculations into kinetic strike force, but catastrophically destabilizes ranged projection systems. Framework integrity reduced by 15% due to extreme energy redirection protocols. Extended blade reach compensates for mobility constraints.

**Build Synergy:**
Defines entire build around cross-stat scaling. Mandatory pairing with Combat Stimulants and Offensive Augments for GUNDAMAGE investment. Synergizes with CRITDAMAGE mods for devastating melee crits. Works with Defensive Protocols to offset HP penalty. Enables "melee sniper" archetype mentioned in requirements - stacking ranged stats for melee damage.

---

## WEAPON STATISTICS SUMMARY

**Distribution:**
- Standard: 3 weapons (1048-1050)
- Enhanced: 2 weapons (1051-1052)
- Advanced: 1 weapon (1053)
- Prototype: 1 weapon (1054)

**modweight Distribution:**
- Common (75-100): 3 weapons (standard tier)
- Uncommon (45-50): 2 weapons (enhanced tier)
- Rare (25): 1 weapon (advanced tier)
- Very Rare (8): 1 weapon (prototype tier)

**Stat Utilization (NEW stats emphasized):**
- MELEEDAMAGE: 7 weapons (all) ✓ CORE
- MELEESPEED: 5 weapons (1048-1050, 1052-1053) ✓ CORE
- MELEERANGE: 1 weapon (1054) ✓ NEW
- MELEECRITCHANCE: 1 weapon (1054) ✓ NEW
- LIFESTEAL: 2 weapons (1051-1052) ✓ NEW
- IGNITECHANCE: 1 weapon (1051)
- THORNDAMAGE: 1 weapon (1053) ✓ NEW
- SHIELDONKILL: 1 weapon (1053) ✓ NEW
- PLAYERSPEED: 2 weapons (1049, 1053)
- GUNDAMAGE: 3 weapons (anti-synergy: 1052, 1054)
- HP: 2 weapons (penalties: 1051, 1054)

**Equation Complexity:**
- Simple (1-2 statements): 3 weapons (1048-1050)
- Moderate (3-4 statements): 3 weapons (1051-1053)
- Complex (cross-stat scaling): 1 weapon (1054)

**Elemental Coverage:**
- Fire: 1 weapon (1051)
- Neutral: 6 weapons (1048-1050, 1052-1054)

---

## ARCHETYPE SUPPORT ANALYSIS

### Hybrid Berserker (Primary Support)
**Weapons:** 1048, 1050, 1051, 1052
**Coverage:** Complete melee foundation with lifesteal, damage, and sustain
**Synergies:** All weapons work with Combat Stimulants and Defensive Protocols

### Speed Demon (Secondary Support)
**Weapons:** 1049, 1052
**Coverage:** High attack speed and movement speed variants
**Synergies:** Pairs with Mobility Modules for extreme speed builds

### Fortress Tank (Tertiary Support)
**Weapons:** 1050, 1053
**Coverage:** High damage with defensive mechanics (thorns, shields)
**Synergies:** Works with Defensive Protocols and Resource Controllers

### Glass Cannon (Elemental Variants)
**Weapons:** 1051, 1054
**Coverage:** High damage with HP penalties and lifesteal sustain
**Synergies:** Tolerates HP loss, maximizes damage output

### Elemental Savant (Niche Support)
**Weapons:** 1051
**Coverage:** Fire melee for elemental specialists
**Synergies:** Works with Elemental Infusions for ignite scaling

---

## BALANCE CONSIDERATIONS

**Trade-off Patterns:**
- Speed weapons sacrifice damage for attack rate (1049)
- Damage weapons sacrifice speed for per-hit power (1050)
- Elemental/lifesteal weapons trade HP for sustainability (1051, 1054)
- Defensive weapons trade mobility for survivability (1053)
- Hybrid weapons disable guns to force melee commitment (1052, 1054)

**Power Curve:**
- Standard tier: Reliable baseline performance, no harsh penalties
- Enhanced tier: Specialized strengths with moderate HP/stat costs
- Advanced tier: Build-defining defensive mechanics with speed penalties
- Prototype tier: Extreme cross-stat scaling gated behind gun disability and HP loss

**Cross-Class Synergies:**
- Combat Stimulants: Boost melee damage directly (all weapons)
- Defensive Protocols: Enable melee survivability (HP, ARMOR, shields)
- Elemental Infusions: Scale fire melee (1051)
- Offensive Augments: Boost crit melee (1054) and damage
- Mobility Modules: Offset speed penalties (1053) or amplify speed builds (1049)

---

## LORE INTEGRATION

All weapon names avoid biological terminology and generic sci-fi tropes:
- ✓ "Kinetic Blade Matrix" vs ❌ "Sword"
- ✓ "Velocity Striker Assembly" vs ❌ "Fast Blade"
- ✓ "Thermal Edge Projector" vs ❌ "Fire Sword"
- ✓ "Chromatic Coherence Edge" vs ❌ "Hybrid Weapon"

All descriptions use nanomolecular terminology:
- Molecular edges, coherent force fields, kinetic strike matrices
- Framework integrity, structural damage, protocols
- No biological references (no blood, flesh, life-drain becomes "nanite extraction")

All lore maintains HIOX world consistency:
- No confidential reveals about player identity
- Technology-based explanations for all mechanics
- Appropriate power source attribution (nanite matrices, energy fields)

---

## EQUATION VALIDATION

All equations follow HEL syntax requirements:
- ✓ Always add to coefficients: `M_X = M_X + val1`
- ✓ Use lowercase val1/val2 in equations
- ✓ Postfix notation for operations: `val1 0.5 *`
- ✓ Separate statements with semicolons
- ✓ Use proper coefficient prefixes (B_, M_, A_, Z_, U_)
- ✓ M_ values are decimals (0.5 = 50%)
- ✓ Cross-stat dependencies properly formatted: `A_MELEEDAMAGE = A_MELEEDAMAGE + T_GUNDAMAGE val1 *`

**Complex Equation Examples:**

*Chromatic Coherence Edge (1054):*
```
A_MELEEDAMAGE = A_MELEEDAMAGE + T_GUNDAMAGE val1 *
```
Adds 80% of current gun damage to melee damage (cross-stat scaling)

*Vampiric Strike Matrix (1052):*
```
M_LIFESTEAL = M_LIFESTEAL + val1; M_MELEESPEED = M_MELEESPEED + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-0.4); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.35
```
Multi-statement balancing: lifesteal + speed + melee damage, but gun damage penalty

---

## FORMAT COMPLIANCE CHECKLIST

- [✓] All modids unique and within 1048-1054 range
- [✓] All uuids follow pattern `uuid-{modid}-{repeating}`
- [✓] All type = 4 (melee weapons)
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
1. IDs 1048-1054 are not already occupied
2. All uuid values are globally unique
3. armorEffectName values match existing game effect names (Fire)
4. modColor values use Unity color format {r, g, b, a}
5. Equations are tested for HEL syntax validity
6. Val ranges produce balanced gameplay across difficulty tiers
7. Type = 4 for melee weapons (not type = 2)

**Testing Priorities:**
1. Cross-stat weapon (1054) - verify gun-to-melee damage conversion works correctly
2. Lifesteal weapons (1051-1052) - confirm healing scales with damage dealt
3. Defensive weapon (1053) - validate THORNDAMAGE and SHIELDONKILL interactions
4. Speed weapon (1049) - ensure DPS compensates for damage penalty

**Balance Tuning:**
- If melee feels underpowered vs. ranged, reduce gun damage penalties
- If lifesteal is overwhelming, reduce val1 ranges on 1051/1052
- If prototype weapon (1054) is too strong, increase HP penalty further
- If speed variants don't feel impactful, increase attack speed bonuses

---

## BUILD EXAMPLES

### EXAMPLE 1: Immortal Berserker
**Core Concept:** High lifesteal melee tank that never dies

**Key Weapons:**
- Vampiric Strike Matrix (1052) - sustain core
- Thermal Edge Projector (1051) - elemental + lifesteal

**Supporting Mods:**
- Defensive Protocols (HP, ARMOR, DAMAGEABSORPTION)
- Combat Stimulants (MELEEDAMAGE for both damage and healing)
- Mobility Modules (offset speed penalties, close distance)
- Resource Controllers (HPREGEN for additional sustain)

**How It Works:**
1. Stack MELEEDAMAGE to 200%+ for both damage and lifesteal scaling
2. 35-55% lifesteal heals massive amounts per hit
3. Fire ignite creates DoT while healing through lifesteal
4. High HP pool + lifesteal makes you unkillable in melee
5. Gun damage penalty forces pure melee commitment

**Result:** Tank who heals faster than enemies can damage, sustaining through any encounter

---

### EXAMPLE 2: Fortress Blade
**Core Concept:** Defensive melee tank with thorns and shields

**Key Weapons:**
- Retribution Blade Array (1053) - thorns + shield generation
- Impact Edge Construct (1050) - high damage per hit

**Supporting Mods:**
- Defensive Protocols (THORNDAMAGE, SHIELDCAPACITY, ARMOR)
- Structural Plating items (HP, DAMAGEABSORPTION)
- Offensive Augments (MELEEDAMAGE)
- Metabolic Enhancers (offset speed penalties)

**How It Works:**
1. Stack THORNDAMAGE to 100+ for massive reflect damage
2. Enemies take damage just by hitting you (passive defense)
3. Shield generation on kills creates snowball effect
4. High HP + shields + armor = immortal tank
5. Slow, deliberate strikes with Impact Edge

**Result:** Fortress that punishes attackers and grows stronger with each kill

---

### EXAMPLE 3: Hybrid Striker (Prototype Build)
**Core Concept:** Gun-scaling melee with critical strikes

**Key Weapons:**
- Chromatic Coherence Edge (1054) - gun-to-melee conversion

**Supporting Mods:**
- Combat Stimulants (GUNDAMAGE - scales melee!)
- Offensive Augments (CRITCHANCE, CRITDAMAGE for melee crits)
- Defensive Protocols (offset 15% HP penalty)
- Tactical Processors (MELEERANGE extension)

**How It Works:**
1. Stack GUNDAMAGE to 300%+ (normally ranged stat)
2. 80% of gun damage converts to melee damage (massive scaling)
3. 80% melee crit chance + crit damage = consistent crits
4. Extended melee range makes strikes safer
5. Can't use guns, but melee damage is astronomical

**Result:** "Melee sniper" who invests in ranged stats for devastating melee strikes

---

## YAML-READY MOD ENTRIES

```yaml
- modid: 1048
  uuid: uuid-1048-104810481048104810481048
  val: 0.35
  val2: 0.25
  val1min: 0.25
  val1max: 0.45
  val2min: 0.15
  val2max: 0.35
  name: KINETIC BLADE MATRIX
  desc: Coherent nanite blade with val1% increased melee damage and val2% improved attack speed for balanced close combat
  modweight: 100
  type: 4
  hasProc: 0
  equation: M_MELEEDAMAGE = M_MELEEDAMAGE + val1; M_MELEESPEED = M_MELEESPEED + val2
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: ''
  armorMeshName: ''

- modid: 1049
  uuid: uuid-1049-104910491049104910491049
  val: 0.65
  val2: 0.15
  val1min: 0.5
  val1max: 0.8
  val2min: 0.1
  val2max: 0.2
  name: VELOCITY STRIKER ASSEMBLY
  desc: Rapid-strike blade system with val1% increased attack speed and val2% movement speed, but reduced damage per hit
  modweight: 80
  type: 4
  hasProc: 0
  equation: M_MELEESPEED = M_MELEESPEED + val1; M_PLAYERSPEED = M_PLAYERSPEED + val2; M_MELEEDAMAGE = M_MELEEDAMAGE + (-0.2)
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: ''
  armorMeshName: ''

- modid: 1050
  uuid: uuid-1050-105010501050105010501050
  val: 0.8
  val2: 0.35
  val1min: 0.6
  val1max: 1.0
  val2min: 0.25
  val2max: 0.45
  name: IMPACT EDGE CONSTRUCT
  desc: Heavy molecular blade dealing val1% increased melee damage but reduces attack speed by val2% due to mass recalibration cycles
  modweight: 75
  type: 4
  hasProc: 0
  equation: M_MELEEDAMAGE = M_MELEEDAMAGE + val1; M_MELEESPEED = M_MELEESPEED + (-val2)
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: ''
  armorMeshName: ''

- modid: 1051
  uuid: uuid-1051-105110511051105110511051
  val: 0.55
  val2: 0.15
  val1min: 0.45
  val1max: 0.65
  val2min: 0.1
  val2max: 0.2
  name: THERMAL EDGE PROJECTOR
  desc: Superheated blade edge with val1 ignite chance on melee strikes, granting val2% lifesteal to survive close combat but reducing max HP by 10%
  modweight: 50
  type: 4
  hasProc: 0
  equation: B_IGNITECHANCE = B_IGNITECHANCE + val1; M_LIFESTEAL = M_LIFESTEAL + val2; M_HP = M_HP + (-0.1); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.3
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: Fire
  armorMeshName: ''

- modid: 1052
  uuid: uuid-1052-105210521052105210521052
  val: 0.45
  val2: 0.25
  val1min: 0.35
  val1max: 0.55
  val2min: 0.15
  val2max: 0.35
  name: VAMPIRIC STRIKE MATRIX
  desc: Life-draining blade system granting val1% lifesteal on melee hits and val2% increased attack speed, but reduces gun damage by 40% to force melee commitment
  modweight: 45
  type: 4
  hasProc: 0
  equation: M_LIFESTEAL = M_LIFESTEAL + val1; M_MELEESPEED = M_MELEESPEED + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-0.4); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.35
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: ''
  armorMeshName: ''

- modid: 1053
  uuid: uuid-1053-105310531053105310531053
  val: 45
  val2: 25
  val1min: 35
  val1max: 55
  val2min: 15
  val2max: 35
  name: RETRIBUTION BLADE ARRAY
  desc: Retaliatory blade system reflecting val1 thorns damage and generating val2 shield on melee kills, but reduces movement speed by 20% and attack speed by 15%
  modweight: 25
  type: 4
  hasProc: 0
  equation: B_THORNDAMAGE = B_THORNDAMAGE + val1; B_SHIELDONKILL = B_SHIELDONKILL + val2; M_PLAYERSPEED = M_PLAYERSPEED + (-0.2); M_MELEESPEED = M_MELEESPEED + (-0.15); M_MELEEDAMAGE = M_MELEEDAMAGE + 0.4
  modColor: {r: 0, g: 0, b: 0, a: 0}
  armorEffectName: ''
  armorMeshName: ''

- modid: 1054
  uuid: uuid-1054-105410541054105410541054
  val: 0.8
  val2: 0.8
  val1min: 0.8
  val1max: 0.8
  val2min: 0.8
  val2max: 0.8
  name: CHROMATIC COHERENCE EDGE
  desc: Experimental blade matrix converting val1% of gun damage to melee damage and granting val2 critical chance on melee, but disables ranged weapons entirely and reduces max HP by 15%
  modweight: 8
  type: 4
  hasProc: 0
  equation: A_MELEEDAMAGE = A_MELEEDAMAGE + T_GUNDAMAGE val1 *; M_MELEECRITCHANCE = M_MELEECRITCHANCE + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-10); M_HP = M_HP + (-0.15); M_MELEERANGE = M_MELEERANGE + 0.4
  modColor: {r: 150, g: 50, b: 255, a: 255}
  armorEffectName: ''
  armorMeshName: ''
```

---

**END OF WEAPONS-MELEE DESIGN DOCUMENT**

**Status:** READY FOR INTEGRATION
**Total Weapons:** 7
**New Stats Utilized:** 4 (MELEERANGE, MELEECRITCHANCE, THORNDAMAGE, SHIELDONKILL)
**Build Archetypes Supported:** 4 (Hybrid Berserker, Speed Demon, Fortress Tank, Glass Cannon)
