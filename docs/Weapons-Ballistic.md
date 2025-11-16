# Ballistic Assembly Weapons Design
**Version:** 1.1
**Status:** FINAL DESIGN (HEL SYNTAX CORRECTED)
**Mod ID Range:** 1000-1014 (15 weapons)
**Class Type:** Ballistic Assemblies
**Weapon Type Code:** 2

---

## CLASS OVERVIEW

**Ballistic Assemblies** are kinetic projectile weapon systems utilizing nanite-compressed ammunition and electromagnetic acceleration matrices. These weapons excel at sustained fire rates and accuracy-dependent damage delivery, making them ideal for precision combat and rapid target elimination.

**Core Characteristics:**
- High fire rate potential (SHOTSPERSEC scaling)
- Accuracy-dependent performance
- Kinetic/physical damage type
- Magazine and reload mechanics (AMMOCAPACITY, RELOADSPEED)
- Varieties: Assault matrices, SMG projectors, scatter arrays, precision emitters

**Build Archetype Support:**
- Glass Cannon (high DPS, crit synergies)
- Precision Sniper (accuracy, long-range burst)
- Speed Demon (mobility + rapid fire)
- Hybrid Berserker (versatile damage options)

---

## STANDARD CONFIGURATION TIER (6 weapons)

### MOD: KINETIC ACCELERATOR MATRIX

**ModID:** 1000
**Type:** 2 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Standard ballistic assembly using electromagnetic acceleration to propel nanite-compressed projectiles at moderate velocity with balanced fire rate

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC val2 +
```

**Values:**
- val1: min 0.1, max 0.3 // Base damage modifier (+10% to +30%)
- val2: min 0.1, max 0.2 // Fire rate bonus (+10% to +20%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Glass Cannon:** Provides baseline damage scaling
- **Speed Demon:** Fire rate bonus supports hit-and-run tactics
- **Hybrid Berserker:** Versatile ranged option for weapon-swap builds

**Trade-offs:**
Balanced weapon with no significant penalties - standard baseline configuration for testing other mod interactions

---

### MOD: RAPID CYCLE PROJECTOR

**ModID:** 1001
**Type:** 2 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
High-frequency projectile assembly optimized for rapid ammunition cycling, firing val1 additional shots per second but reducing per-shot damage by val2%

**HEL Equation:**
```
B_SHOTSPERSEC = B_SHOTSPERSEC val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +
```

**Values:**
- val1: min 3, max 7 // Flat fire rate increase (+3 to +7 shots/sec)
- val2: min 0.2, max 0.4 // Damage penalty (-20% to -40%)

**Modweight:** 150

**Build Synergies:**
- **Speed Demon:** Extreme fire rate for proc application during kiting
- **DoT Specialist:** More shots = more elemental proc opportunities
- **Glass Cannon:** Can offset damage penalty with crit synergies

**Trade-offs:**
Significant damage reduction per shot - requires proc-based or crit builds to compensate. Lower ammo efficiency (burns through AMMOCAPACITY faster)

---

### MOD: SCATTER ARRAY PROJECTOR

**ModID:** 1002
**Type:** 2 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Dispersed projectile matrix firing val1 simultaneous nanite packets in spread pattern, with val2% reduced accuracy per projectile

**HEL Equation:**
```
B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_ACCURACY = M_ACCURACY val2 +
```

**Values:**
- val1: min 5, max 9 // Additional bullets per shot (+5 to +9)
- val2: min 0.5, max 1.2 // Accuracy penalty (+50% to +120% spread)

**Modweight:** 180

**Build Synergies:**
- **DoT Specialist:** Multiple projectiles for mass proc application
- **Elemental Savant:** Spread fire applies elemental effects to groups
- **Glass Cannon:** High burst potential at close range

**Trade-offs:**
Severe accuracy reduction makes long-range combat ineffective. Burns ammunition rapidly (val1× ammo consumption). Requires close-range positioning (higher risk)

---

### MOD: PRECISION EMITTER ASSEMBLY

**ModID:** 1003
**Type:** 2 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Long-range ballistic framework with enhanced targeting protocols, increasing projectile velocity by val1% and accuracy by val2%, but reducing fire rate by 30%

**HEL Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_ACCURACY = M_ACCURACY -val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.3 +
```

**Values:**
- val1: min 0.4, max 0.8 // Projectile speed boost (+40% to +80%)
- val2: min 0.15, max 0.3 // Accuracy improvement (-15% to -30% spread)

**Modweight:** 160

**Build Synergies:**
- **Precision Sniper:** Core weapon for long-range elimination builds
- **Glass Cannon:** Supports positioning at safe distance for burst damage
- **Hybrid Berserker:** Ranged option before melee engagement

**Trade-offs:**
Fire rate reduction significantly lowers sustained DPS. Requires precise aim and positioning. Poor crowd control capability

---

### MOD: BURST PROTOCOL MATRIX

**ModID:** 1004
**Type:** 2 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Synchronized firing sequence releasing val1-round bursts with val2% increased damage per shot, requiring longer recalibration between bursts

**HEL Equation:**
```
B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +
```

**Values:**
- val1: min 2, max 4 // Bullets per burst (+2 to +4)
- val2: min 0.15, max 0.35 // Damage per shot (+15% to +35%)

**Modweight:** 170

**Build Synergies:**
- **Glass Cannon:** High burst damage windows for aggressive trades
- **Precision Sniper:** Burst damage complements accuracy focus
- **Speed Demon:** Hit-and-run burst trades between dashes

**Trade-offs:**
Reduced overall fire rate creates damage downtime. Requires ammo management (bursts consume multiple shots). Less effective against single tough enemies vs sustained fire

---

### MOD: TACTICAL CARBINE ASSEMBLY

**ModID:** 1005
**Type:** 2 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Versatile compact framework increasing mobility with val1% movement speed while firing, but with val2% reduced damage output

**HEL Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +
```

**Values:**
- val1: min 0.15, max 0.3 // Movement speed bonus while equipped (+15% to +30%)
- val2: min 0.1, max 0.2 // Damage trade-off (-10% to -20%)

**Modweight:** 190

**Build Synergies:**
- **Speed Demon:** Core weapon for maximum mobility builds
- **Hybrid Berserker:** Mobile ranged option for hit-and-run melee combos
- **Precision Sniper:** Maintains mobility for repositioning

**Trade-offs:**
Lower damage output requires longer time-to-kill. Less effective for stationary defensive play. Mobility bonus doesn't affect damage directly

---

## ENHANCED PROTOCOL TIER (4 weapons)

### MOD: ARMOR BREACH PROJECTOR

**ModID:** 1006
**Type:** 2 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
Armor-penetrating projectile assembly with val1 piercing shots capability and val2% increased damage, but val2% slower reload speed

**HEL Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_RELOADSPEED = M_RELOADSPEED -val2 +
```

**Values:**
- val1: min 2, max 5 // Piercing count (+2 to +5 enemies)
- val2: min 0.25, max 0.5 // Damage bonus AND reload penalty (+25-50% / -25-50%)

**Modweight:** 75

**Build Synergies:**
- **DoT Specialist:** Pierce enables multi-target elemental application
- **Glass Cannon:** Penetration damage multiplies with crit strikes
- **Precision Sniper:** Line up shots for maximum pierce value

**Trade-offs:**
Reload speed penalty creates longer downtime windows. Requires enemy positioning for pierce effectiveness. Less effective vs single bosses

---

### MOD: HYPERKINETIC STRIKER

**ModID:** 1007
**Type:** 2 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
Extreme velocity accelerator increasing projectile speed by val1%, critical chance by val2%, but reducing magazine capacity by 40%

**HEL Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +; M_AMMOCAPACITY = M_AMMOCAPACITY -0.4 +
```

**Values:**
- val1: min 0.6, max 1.2 // Projectile speed (+60% to +120%)
- val2: min 0.1, max 0.2 // Critical chance (+10% to +20%)

**Modweight:** 65

**Build Synergies:**
- **Precision Sniper:** Speed + crit synergy for burst elimination
- **Glass Cannon:** Crit scaling with extreme velocity
- **Speed Demon:** Fast projectiles match mobile playstyle

**Trade-offs:**
Severely reduced magazine size (40% capacity reduction) requires frequent reloads. Ammo efficiency suffers. Must leverage crits to justify trade-off

---

### MOD: SUSTAINED BARRAGE PLATFORM

**ModID:** 1008
**Type:** 2 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
High-capacity ammunition matrix increasing magazine size by val1% and reload speed by val2%, but decreasing damage per shot by 25%

**HEL Equation:**
```
M_AMMOCAPACITY = M_AMMOCAPACITY val1 +; M_RELOADSPEED = M_RELOADSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.25 +
```

**Values:**
- val1: min 0.5, max 1.0 // Magazine capacity (+50% to +100%)
- val2: min 0.3, max 0.6 // Reload speed (+30% to +60% faster)

**Modweight:** 70

**Build Synergies:**
- **DoT Specialist:** Extended magazines for continuous proc application
- **Speed Demon:** Less downtime, more uptime shooting while mobile
- **Summoner Commander:** Sustained fire while minions tank

**Trade-offs:**
Significant damage reduction per shot. DPS depends entirely on uptime advantage. Ineffective for burst damage strategies

---

### MOD: CRITICAL STRIKE ACCELERATOR

**ModID:** 1009
**Type:** 2 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
Precision-tuned targeting matrix increasing critical chance by val1% and critical damage multiplier by val2, with val2% reduced fire rate

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -val1 +
```

**Values:**
- val1: min 0.15, max 0.3 // Critical chance (+15% to +30%)
- val2: min 0.5, max 1.0 // Critical damage multiplier (+0.5 to +1.0 multiplier)

**Modweight:** 60

**Build Synergies:**
- **Glass Cannon:** Core weapon for crit-focused builds
- **Precision Sniper:** Crit synergy for one-shot potential
- **Hybrid Berserker:** Burst damage option for aggressive plays

**Trade-offs:**
Fire rate reduction (tied to crit chance value). Requires crit damage investment to maximize value. RNG-dependent damage output

---

## ADVANCED MATRIX TIER (3 weapons)

### MOD: HYPERVELOCITY IMPACT CANNON

**ModID:** 1010
**Type:** 2 (weapon)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental projectile accelerator achieving val1% increased speed and val2% damage, but with 60% reduced accuracy and 20% slower fire rate

**HEL Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_ACCURACY = M_ACCURACY 0.6 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.2 +
```

**Values:**
- val1: min 1.5, max 2.5 // Extreme projectile speed (+150% to +250%)
- val2: min 0.6, max 1.0 // High damage bonus (+60% to +100%)

**Modweight:** 35

**Build Synergies:**
- **Glass Cannon:** Extreme damage potential for high-skill players
- **Precision Sniper:** Speed compensates for accuracy loss at range
- **Hybrid Berserker:** High-impact ranged burst before melee

**Trade-offs:**
Massive accuracy penalty (60% spread increase) requires close-range use or accuracy mods. Fire rate reduction limits sustained DPS. High risk, high reward weapon

---

### MOD: FRAGMENTATION PROJECTOR ARRAY

**ModID:** 1011
**Type:** 2 (weapon)
**Rarity:** Advanced

**Description (Player-Visible):**
Unstable projectile matrix causing shots to pierce val1 enemies and split into val2 additional projectiles on hit, with 30% damage reduction

**HEL Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; B_BULLETSFIRED = B_BULLETSFIRED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +
```

**Values:**
- val1: min 3, max 6 // Piercing count (+3 to +6 enemies)
- val2: min 2, max 4 // Bullet split (+2 to +4 projectiles on hit)

**Modweight:** 30

**Build Synergies:**
- **DoT Specialist:** Extreme multi-target proc application
- **Elemental Savant:** Spread piercing + splitting for area coverage
- **Glass Cannon:** Multiplication effect amplifies crit chains

**Trade-offs:**
30% base damage reduction affects all projectiles. Complex damage calculation (pierce + split). Effectiveness varies dramatically based on enemy density

---

### MOD: OVERCHARGE KINETIC CORE

**ModID:** 1012
**Type:** 2 (weapon)
**Rarity:** Advanced

**Description (Player-Visible):**
Adaptive damage protocols scaling with accuracy - gain val1% damage per 10% accuracy possessed, but reduce fire rate by val2%

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_ACCURACY val1 * 10 / +; M_SHOTSPERSEC = M_SHOTSPERSEC -val2 +
```

**Values:**
- val1: min 0.8, max 1.5 // Damage scaling per 10% accuracy (+80% to +150% per 10% accuracy)
- val2: min 0.15, max 0.3 // Fire rate penalty (-15% to -30%)

**Modweight:** 25

**Build Synergies:**
- **Precision Sniper:** Accuracy stacking directly translates to damage
- **Glass Cannon:** Conditional damage scaling for optimization builds
- **Hybrid Berserker:** Rewards accuracy investment for ranged phase

**Trade-offs:**
Requires heavy accuracy investment (mods, syringes) to maximize damage. Fire rate reduction affects sustained DPS. Scales poorly with scatter/shotgun accuracy penalties

---

## PROTOTYPE ASSEMBLY TIER (2 weapons)

### MOD: ADAPTIVE BALLISTIC NEXUS

**ModID:** 1013
**Type:** 2 (weapon)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental assembly that converts val1% of critical damage multiplier into fire rate, and gains val2% lifesteal per 100 shots fired per second

**HEL Equation:**
```
M_SHOTSPERSEC = M_SHOTSPERSEC T_CRITDAMAGE val1 * 0.1 * +; M_LIFESTEAL = M_LIFESTEAL T_SHOTSPERSEC val2 * 0.01 * +
```

**Values:**
- val1: min 0.3, max 0.6 // Critdamage-to-firerate conversion (+30% to +60% of CRITDAMAGE → fire rate)
- val2: min 0.05, max 0.15 // Lifesteal scaling per fire rate (+0.05% to +0.15% per 100 fire rate)

**Modweight:** 5

**Build Synergies:**
- **Glass Cannon:** Converts crit scaling into sustain and fire rate
- **Hybrid Berserker:** Lifesteal enables aggressive melee-ranged hybrid play
- **Speed Demon:** Fire rate scaling matches mobile playstyle

**Trade-offs:**
Anti-synergy with pure crit damage builds (converts away crit multiplier). Requires high fire rate investment for meaningful lifesteal. Complex optimization - must balance crit vs fire rate vs sustain

**Unique Mechanics:**
Build-defining weapon that fundamentally changes stat priorities. Creates unique "crit-to-speed" archetype. Rewards hybrid stat investment over pure damage stacking

---

### MOD: NANITE RECYCLER DEVASTATOR

**ModID:** 1014
**Type:** 2 (weapon)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental ammunition reclamation system granting val1% lifesteal and reducing reload time by val2%, with damage scaling based on current magazine percentage (gain 1% damage per 10% magazine remaining)

**HEL Equation:**
```
M_LIFESTEAL = M_LIFESTEAL val1 +; M_RELOADSPEED = M_RELOADSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE T_AMMOCAPACITY 10 / 0.01 * +
```

**Values:**
- val1: min 0.15, max 0.3 // Base lifesteal (+15% to +30%)
- val2: min 0.4, max 0.8 // Reload speed improvement (+40% to +80% faster)

**Modweight:** 4

**Build Synergies:**
- **Glass Cannon:** Lifesteal sustain enables aggressive glass builds
- **Hybrid Berserker:** Core sustain weapon for berserker strategies
- **Precision Sniper:** Rewards careful ammo management

**Trade-offs:**
Damage scales inversely with ammo expenditure (highest at full mag, lowest at empty). Creates tension between shooting and reloading for damage optimization. Requires AMMOCAPACITY investment for scaling

**Unique Mechanics:**
Build-defining ammo management system. Incentivizes frequent reloads (faster reload = less DPS loss). Creates "reload-between-fights" playstyle for damage optimization

---

## DESIGN SUMMARY

**Total Weapons:** 15
**ID Range:** 1000-1014

**Rarity Distribution:**
- Standard: 6 weapons (1000-1005) | modweight 150-200
- Enhanced: 4 weapons (1006-1009) | modweight 60-75
- Advanced: 3 weapons (1010-1012) | modweight 25-35
- Prototype: 2 weapons (1013-1014) | modweight 4-5

**Stat Coverage:**
- GUNDAMAGE: 11 weapons
- SHOTSPERSEC: 10 weapons
- ACCURACY: 4 weapons
- CRITCHANCE: 3 weapons
- CRITDAMAGE: 2 weapons
- AMMOCAPACITY: 3 weapons
- RELOADSPEED: 3 weapons
- PROJECTILESPEED: 4 weapons
- PIERCINGSHOTS: 2 weapons
- BULLETSFIRED: 4 weapons
- LIFESTEAL: 2 weapons
- PLAYERSPEED: 1 weapon

**Build Archetype Support:**
- Glass Cannon: 11 weapons (primary damage scaling)
- Precision Sniper: 7 weapons (accuracy/range focus)
- Speed Demon: 6 weapons (mobility/fire rate)
- DoT Specialist: 5 weapons (proc application)
- Hybrid Berserker: 5 weapons (versatility/lifesteal)
- Elemental Savant: 3 weapons (proc/multi-target)

**Trade-off Philosophy:**
- All Enhanced+ weapons include meaningful trade-offs
- Standard weapons provide baseline performance
- Trade-offs scale with power (20-40% penalties for significant bonuses)
- Prototype weapons create build-defining decisions

**Lore Compliance:**
- All terminology uses nanomolecular language (matrix, assembly, projector, accelerator)
- No biological references
- Consistent with HIOX nanite world
- Player-visible descriptions avoid confidential lore

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X val +)
- Proper coefficient prefixes (B_, M_, A_)
- M_ values use decimals (0.5 = 50%)
- Pure postfix notation for all operations (T_ACCURACY val1 * 10 / +)
- Cross-stat dependencies in Prototype tier

---

**END OF BALLISTIC ASSEMBLY WEAPONS DESIGN**
