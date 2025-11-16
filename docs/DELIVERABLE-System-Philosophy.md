# HIOX Stats/Mods System Philosophy
**Version:** 1.1
**Status:** FINAL DELIVERABLE (HEL SYNTAX CORRECTED)
**Date:** 2025-11-12
**Last Updated:** 2025-11-16

---

## EXECUTIVE OVERVIEW

The HIOX Stats/Mods system is a comprehensive character customization and progression framework inspired by Path of Exile's acclaimed item modification system, adapted for the nanomolecular world of HIOX. The system enables deep build diversity through 65 total stats and 155 mods across weapons, items, and syringes.

**Core Design Pillars:**
1. **Build Diversity**: Support for 8+ distinct build archetypes
2. **Meaningful Choices**: Trade-offs create tension, no "strictly better" options
3. **Scaling Complexity**: Standard→Enhanced→Advanced→Prototype rarity progression
4. **Synergistic Depth**: Cross-mod combos reward planning
5. **Lore Consistency**: Nanomolecular technology, zero confidentiality leaks

---

## 1. SYSTEM ARCHITECTURE

### 1.1 Three-Pillar Structure

**Weapons (55 mods)** - Offensive foundation
- Define primary damage output and combat style
- 6 classes: Ballistic, Energy, Explosive, Deployables, Hybrid, Melee
- Type codes: 2 (ranged), 4 (melee)
- ID range: 1000-1054

**Items (50 mods)** - Build-defining customization
- Provide defensive, mobility, and specialized capabilities
- 7 classes: Structural, Mobility, Regeneration, Offensive, Resistance, Resource, Tactical
- Type code: 0 (passive)
- ID range: 2000-2049

**Syringes (50 mods)** - Stackable enhancements
- Smaller bonuses that stack for cumulative effect
- 6 classes: Combat, Defensive, Metabolic, Elemental, Tactical, Exotic
- Type code: 10 (upgrade)
- ID range: 3000-3050

### 1.2 Stat System (65 total stats)

**Existing Stats (38):**
- Core combat: GUNDAMAGE, MELEEDAMAGE, HP, ARMOR, etc.
- Movement: PLAYERSPEED, GRAVITY
- Resources: ENERGY, STAMINA
- Weapon characteristics: SHOTSPERSEC, ACCURACY, RANGE

**New Stats (27):**
- **Critical System** (2): CRITCHANCE, CRITDAMAGE
- **Defensive Expansion** (6): LIFESTEAL, DODGECHANCE, THORNDAMAGE, SHIELDCAPACITY, SHIELDREGENRATE, REFLECTDAMAGE
- **Elemental Mechanics** (7): IGNITECHANCE/DAMAGE, CHARGECHANCE/DAMAGE, CORRUPTIONCHANCE/DAMAGE, ELEMENTALPENETRATION
- **Minion System** (5): NUMMINIONS, MINIONDAMAGE, MINIONHP, MINIONATTACKSPEED, MINIONLIFESTEAL
- **Mobility Enhancement** (2): DASHSPEED, DASHCOOLDOWN
- **Resource Optimization** (2): COOLDOWNREDUCTION, RESOURCEEFFICIENCY
- **Combat Mechanics** (3): BULLETSFIRED, MELEERANGE, MELEESPEED

---

## 2. RARITY TIER PHILOSOPHY

### 2.1 Four-Tier Progression (PoE-Inspired)

**Standard Configuration** (Normal/White)
- **Modweight**: 180-200 (very common drops)
- **Philosophy**: Pure bonuses, no penalties
- **Purpose**: Foundation items for all builds
- **Example**: "+12% gun damage" (Combat Stimulant 3000)

**Enhanced Protocol** (Magic/Blue)
- **Modweight**: 80-100 (common drops)
- **Philosophy**: Dual effects with minor trade-offs (8-15% penalties)
- **Purpose**: Build customization with meaningful choices
- **Example**: "+40% gun damage, -10% HP" (Offensive Augment)

**Advanced Matrix** (Rare/Yellow)
- **Modweight**: 35-50 (uncommon drops)
- **Philosophy**: Complex mechanics with moderate penalties (15-25%)
- **Purpose**: Build-enabling scaling, conditionals, cross-stat synergies
- **Example**: "+1% damage per 100 speed, -15% armor" (conversion scaling)

**Prototype Assembly** (Unique/Orange)
- **Modweight**: 5-15 (very rare drops)
- **Philosophy**: Build-defining transformations with extreme penalties (20-40%)
- **Purpose**: Enable completely new playstyles
- **Example**: "100% accuracy, -30% damage, -20% fire rate" (Perfect Precision 3046)

### 2.2 Distribution Target

- 45% Standard (70 mods) - Common drops for all players
- 30% Enhanced (46 mods) - Build customization layer
- 18% Advanced (28 mods) - Build-enabling mechanics
- 7% Prototype (11 mods) - Build-defining transformations

---

## 3. BUILD ARCHETYPE PHILOSOPHY

### 3.1 Eight Core Archetypes

**1. Fortress Tank**
- **Identity**: Maximum survivability, thorns/reflect damage
- **Core Stats**: HP 2000+, ARMOR 500+, RESISTANCES 70%+, THORNDAMAGE
- **Supporting Mods**: 52 mods (Structural Plating, Defensive Protocols, Resistance Arrays)
- **Fantasy**: Unkillable wall that punishes attackers

**2. Glass Cannon**
- **Identity**: Extreme offense, minimal defense
- **Core Stats**: GUNDAMAGE 500+, CRITCHANCE 40%+, CRITDAMAGE 300%+, HP 50-100
- **Supporting Mods**: 47 mods (Ballistic Assemblies, Offensive Augments, Combat Stimulants)
- **Fantasy**: One-shot burst damage dealer

**3. Elemental Savant**
- **Identity**: Elemental status effect specialist
- **Core Stats**: IGNITECHANCE/CHARGECHANCE/CORRUPTIONCHANCE 60%+, elemental damage 200+, ELEMENTALPENETRATION
- **Supporting Mods**: 42 mods (Energy Emitters, Elemental Infusions, Offensive Augments)
- **Fantasy**: Multi-element DoT master

**4. Summoner Commander**
- **Identity**: Minion army specialist
- **Core Stats**: NUMMINIONS 5+, MINIONDAMAGE 200%+, MINIONHP 300+
- **Supporting Mods**: 24 mods (Deployable Systems, Tactical Modules)
- **Fantasy**: Overwhelming swarm tactics

**5. Speed Demon**
- **Identity**: High mobility, hit-and-run tactics
- **Core Stats**: PLAYERSPEED 500+, DASHSPEED 200%+, DODGECHANCE 40%+
- **Supporting Mods**: 34 mods (Mobility Enhancements, lightweight weapons)
- **Fantasy**: Untouchable speedster

**6. Hybrid Berserker**
- **Identity**: Melee/ranged switching, lifesteal sustain
- **Core Stats**: GUNDAMAGE 300+, MELEEDAMAGE 400+, LIFESTEAL 20%+, HP 400-600
- **Supporting Mods**: 49 mods (Hybrid Platforms, Combat Stimulants, Berserker Rage)
- **Fantasy**: Aggressive all-range combatant

**7. DoT Specialist**
- **Identity**: Area denial, proc chains, status spreading
- **Core Stats**: PROCRATE high, PROCRANGE 300+, elemental damage 200+
- **Supporting Mods**: 40 mods (Explosive Launchers, Elemental Infusions, Tactical Injections)
- **Fantasy**: Battlefield controller

**8. Precision Sniper**
- **Identity**: Long-range burst precision damage
- **Core Stats**: ACCURACY 95%+, RANGE 500+, CRITDAMAGE 300%+, PROJECTILESPEED high
- **Supporting Mods**: 40 mods (Ballistic Assemblies, Tactical Injections, Precision Protocols)
- **Fantasy**: One-shot-one-kill marksman

### 3.2 New Unique Archetypes (Prototype-Enabled)

1. **Elemental Purist** (3038): 100% damage-to-elemental conversion
2. **Thorn Fortress** (3050): Pure thorns damage, zero direct damage
3. **Speed Destroyer** (3049): Speed-to-damage scaling
4. **Chaos Gambler** (3048): Random damage variance
5. **Glass Berserker** (3047): Low-HP damage scaling
6. **Perfect Marksman** (3046): 100% accuracy transformation
7. **Resistant Savant** (2033): Resistance-to-penetration conversion

---

## 4. TRADE-OFF PHILOSOPHY

### 4.1 Core Principle: Meaningful Choices

**No Strictly Better Options:**
Every powerful effect requires a sacrifice. Players must choose between competing priorities:
- Offense vs Defense
- Mobility vs Damage
- Consistency vs Burst
- Safety vs Risk

### 4.2 Penalty Scaling by Rarity

**Standard Tier**: Zero penalties
- Philosophy: Foundation items should feel good to use
- Purpose: New players learn mechanics without punishment
- Example: "+10% gun damage" (no downside)

**Enhanced Tier**: 8-15% penalties
- Philosophy: Introduce trade-off concept gently
- Purpose: Teach players to evaluate pros vs cons
- Example: "+40% gun damage, -10% HP"

**Advanced Tier**: 15-25% penalties
- Philosophy: Significant sacrifices for powerful effects
- Purpose: Create build-defining choices
- Example: "+80% damage, -20% armor, -15% speed"

**Prototype Tier**: 20-40% penalties
- Philosophy: Extreme transformations require extreme costs
- Purpose: Enable radical playstyle shifts
- Example: "100% accuracy, -30% damage, -20% fire rate"

### 4.3 Penalty Categories

**Offensive Penalties:**
- Reduced damage output (GUNDAMAGE, MELEEDAMAGE)
- Lower fire rate (SHOTSPERSEC)
- Decreased accuracy
- Reduced range

**Defensive Penalties:**
- Lower HP maximum
- Reduced armor
- Decreased resistances
- Slower regeneration

**Mobility Penalties:**
- Reduced movement speed (PLAYERSPEED)
- Slower dash speed
- Increased cooldowns
- Lower stamina

---

## 5. SCALING MECHANICS PHILOSOPHY

### 5.1 Simple Scaling (Standard/Enhanced)

**Direct Percentage Bonuses:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +
```
- Clean, predictable
- Easy to understand
- Foundation of most mods

### 5.2 Conditional Scaling (Advanced)

**Situational Bonuses:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_HP S_HP 0.5 * < val1 * +
```
- Activates under specific conditions
- Creates risk/reward gameplay
- Example: Berserker Rage (3047) - damage when below 50% HP

### 5.3 Cross-Stat Conversion (Prototype)

**Build-Defining Transformations:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED 0.01 * val1 * +
```
- Converts one stat into another
- Enables unique build paths
- Examples:
  - Speed→Damage (3049)
  - Armor→Thorns (3050)
  - Resistance→Penetration (2033)

### 5.4 Random Variance (Exotic)

**Chaos Mechanics:**
```
M_GUNDAMAGE = M_GUNDAMAGE RAND val1 * 0.5 - +
```
- Introduces controlled randomness
- High-risk, high-reward
- Example: Chaos Variance (3048) - damage ranges from 10% to 190%

---

## 6. SYNERGY DESIGN PHILOSOPHY

### 6.1 Horizontal Synergies (Same Archetype)

**Within-Build Combos:**
- Glass Cannon: Crit Chance + Crit Damage + High Base Damage
- Fortress Tank: HP + Armor + Resistances + Thorns
- Elemental Savant: Elemental Chance + Elemental Damage + Penetration

**Purpose**: Reward focused build investment

### 6.2 Vertical Synergies (Cross-Category)

**Weapon + Item + Syringe Combos:**
- Sniper Rifle (1002) + Critical Amplification (2024) + Precision Protocol (3005)
- Energy Emitter (1015) + Elemental Penetration (2033) + Elemental Infusion (3030)
- Swarm Fabricator (1043) + Minion Damage Catalyst (2028) + Summon Capacity (3023)

**Purpose**: Reward strategic planning across all three mod categories

### 6.3 Conversion Synergies (Unique Interactions)

**Transformation Stacking:**
- Speed Destroyer (3049: speed→damage) + Dash Momentum (2009: +dash speed) + Lightweight Frame (2011: +player speed)
- Thorn Fortress (3050: armor→thorns) + Ablative Armor (2001: +armor) + Reactive Defense (2006: +thorns%)

**Purpose**: Enable creative stat-stacking strategies that transform defensive stats into offense

### 6.4 Anti-Synergies (Intentional Conflicts)

**Mutually Exclusive Builds:**
- Fortress Tank items (HP bonuses) vs Glass Cannon items (HP penalties)
- Speed Demon mobility vs Heavy Tank speed penalties
- Perfect Precision (3046: -30% damage) vs pure damage builds

**Purpose**: Create meaningful build choices, prevent "everything" builds

---

## 7. HEL EQUATION PHILOSOPHY

### 7.1 Coefficient System

**Seven Coefficient Types:**
- `S_` - Start (base stat values, read-only)
- `B_` - Base additive (flat additions before multiplication)
- `A_` - Absolute additive (flat additions after multiplication)
- `M_` - Multiplicative (percentage modifiers)
- `Z_` - Minimum adjustment (raise floor values)
- `U_` - Maximum adjustment (raise ceiling values)
- `T_` - Total (read-only, current calculated value)

**Final Calculation:**
```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

### 7.2 Design Principles

**Always Add to Coefficients:**
```
✅ GOOD: M_GUNDAMAGE = M_GUNDAMAGE val1 +
❌ BAD:  M_GUNDAMAGE = val1
```
- Enables stacking multiple mods
- Prevents overwrite conflicts

**Use Decimals for Percentages:**
```
✅ GOOD: M_GUNDAMAGE = M_GUNDAMAGE 0.5 +  // 50% bonus
❌ BAD:  M_GUNDAMAGE = M_GUNDAMAGE 50 +    // Would be 5000% bonus
```

**Postfix Notation:**
```
✅ GOOD: T_PLAYERSPEED 0.01 * val1 *
❌ BAD:  val1 * T_PLAYERSPEED * 0.01
```

**Read-Only Stats (T_):**
- Use T_ to reference current values in calculations
- Example: `T_HP` in conditionals `(T_HP 100 <)`
- Never modify T_ directly (read-only)

---

## 8. LORE INTEGRATION PHILOSOPHY

### 8.1 Nanomolecular Consistency

**Forbidden Terms (Biological):**
❌ Blood → ✅ Nanite fluid / structural fluid
❌ Healing → ✅ Reconstruction / repair
❌ Flesh → ✅ Framework / plating
❌ Poison → ✅ Corruption / viral code
❌ Organic → ✅ Assembled / fabricated
❌ Soul → ✅ Core protocol / matrix
❌ Magic → ✅ Protocol / algorithm

**Approved Terminology:**
- Nanites, nanomolecular, nanite frameworks
- Protocols, algorithms, matrices
- Thermal/electrical/viral damage (not fire/lightning/poison)
- Assemblies, constructs, fabrications
- Structural integrity, framework cohesion

### 8.2 Confidentiality Protocol

**Forbidden Lore (NEVER mention):**
1. HIOX-One identity (player is the creator)
2. Reset cycles (world resets when player dies)
3. HIOX-Estel (companion/guide)
4. "Ascended" faction details
5. Fabrication engine mechanics
6. Player amnesia backstory
7. True nature of the world

**Player-Visible Lore:**
- Generic nanite technology
- Weapon/item functionality
- Combat protocols
- Structural engineering
- NO backstory, NO world lore, NO character history

---

## 9. BALANCE PHILOSOPHY

### 9.1 Power Budget System

**Damage Scaling Limits:**
- Single-mod max: +150% (Prototype only)
- Standard tier max: +30%
- Enhanced tier max: +60%
- Advanced tier max: +100%
- Crit damage cap: 500%

**Defensive Scaling Limits:**
- HP bonuses: 20-500 points (no percentages >100%)
- Armor bonuses: 50-800 points
- Resistances: Max 90% per element (never 100%)

**Penalty Minimums:**
- For +100% damage bonus: Minimum -20% penalty
- For build transformation: Minimum -25% penalty
- For guaranteed effects (100% accuracy): Minimum -30% penalty

### 9.2 Rarity Power Curve

**Standard → Enhanced**: +2x power
- Standard: +15% damage
- Enhanced: +30-40% damage

**Enhanced → Advanced**: +2x power, add mechanics
- Enhanced: +40% damage, -10% HP
- Advanced: +80% damage, -20% HP, conditional scaling

**Advanced → Prototype**: +2x power, transformation
- Advanced: +80% damage with condition
- Prototype: +150% damage or build-defining effect, -30% penalties

### 9.3 Archetype Parity

**Goal**: All 8 archetypes equally viable

**Validation Metrics:**
- Each archetype has 24+ supporting mods ✅
- Each archetype has 1+ Prototype-tier build-defining mod ✅
- Each archetype has clear strengths and weaknesses ✅
- No archetype is strictly better than others ✅

---

## 10. PLAYER EXPERIENCE PHILOSOPHY

### 10.1 Progression Fantasy

**Early Game (Standard Tier):**
- Simple, clean bonuses
- No penalties, feel-good drops
- Learn basic stat interactions
- Example: "I want more damage" → find +damage syringe

**Mid Game (Enhanced Tier):**
- Introduce trade-offs
- Teach build prioritization
- Start forming archetype identity
- Example: "I'll sacrifice HP for damage because I'm building Glass Cannon"

**Late Game (Advanced Tier):**
- Complex mechanics
- Cross-stat synergies
- Build optimization
- Example: "If I stack speed, this converts it to damage"

**End Game (Prototype Tier):**
- Build-defining transformations
- Radical playstyle shifts
- Mastery of systems
- Example: "This item lets me convert all damage to elemental and I become pure DoT specialist"

### 10.2 Build Discovery

**Intended Player Journey:**
1. **Experimentation**: Try different weapons and items
2. **Specialization**: Focus on 1-2 archetypes
3. **Optimization**: Stack synergies, manage trade-offs
4. **Innovation**: Discover unique combos (Speed Destroyer, Thorn Fortress, etc.)

### 10.3 Meaningful Drops

**Every Rarity Matters:**
- Standard: Always useful for any build (pure bonuses)
- Enhanced: Build customization choices (small trade-offs)
- Advanced: Build-enabling finds (complex mechanics)
- Prototype: Build-defining moments (transformations)

**No Vendor Trash:**
- Even Standard tier items have value
- All tiers scale with val1/val2 ranges (better rolls matter)
- Stackable syringes make multiples useful

---

## 11. TECHNICAL INTEGRATION

### 11.1 Asset File Format

**StatsData.asset (YAML):**
```yaml
stats:
  - name: CRITCHANCE
    desc: Probability of critical precision strikes
    value: 0.05
    min: 0
    max: 1
```

**ModsData.asset (YAML):**
```yaml
mods:
  - modid: 3000
    uuid: uuid-3000-3000-3000-3000
    type: 10
    val: 0
    val2: 0
    val1min: 0.08
    val1max: 0.12
    val2min: 0
    val2max: 0
    name: DAMAGE ENHANCEMENT SERUM
    desc: Offensive protocol injection increasing projectile damage output by val1% through weapon emitter optimization nanites
    modweight: 200
    equation: "M_GUNDAMAGE = M_GUNDAMAGE val1 +"
```

### 11.2 HEL Integration

**Stateless Evaluation:**
- All mods evaluate through HEL.EvaluateMods()
- No persistent state between evaluations
- Coefficient accumulation per evaluation cycle

**Execution Order:**
- Gather all active mods
- Substitute VAL/VAL1/VAL2 placeholders
- Parse equations into statements
- Resolve dependencies and cycles
- Execute in correct order
- Apply final coefficient formula

---

## 12. DESIGN VALIDATION

**System Completeness:**
- ✅ 65 total stats (38 existing + 27 new)
- ✅ 155 total mods (55 weapons + 50 items + 50 syringes)
- ✅ 8 core archetypes supported
- ✅ 7 unique new archetypes created
- ✅ 4 rarity tiers with healthy distribution

**Technical Validity:**
- ✅ All mod IDs unique (1000-1054, 2000-2049, 3000-3050)
- ✅ All HEL equations syntactically correct (pure postfix notation)
- ✅ All type codes properly assigned (0, 2, 4, 10)
- ✅ All value ranges appropriate for stat types

**Balance Verification:**
- ✅ Trade-offs proportional to power
- ✅ No strictly better options
- ✅ Archetype parity maintained
- ✅ Rarity power curve appropriate

**Lore Compliance:**
- ✅ Zero confidential leaks
- ✅ All terminology nanomolecular
- ✅ No biological terms used
- ✅ Player-visible descriptions safe

---

## 13. CONCLUSION

The HIOX Stats/Mods system delivers on its core design goals:

**Build Diversity**: 8+ archetypes with 24-52 supporting mods each
**Meaningful Choices**: All powerful effects have proportional trade-offs
**Scaling Complexity**: Four-tier rarity system with appropriate power curve
**Synergistic Depth**: Cross-mod combos reward planning
**Lore Consistency**: Nanomolecular terminology, zero confidentiality breaches

The system is **ready for implementation** and **playtesting**.

---

**END OF SYSTEM PHILOSOPHY DOCUMENT**
