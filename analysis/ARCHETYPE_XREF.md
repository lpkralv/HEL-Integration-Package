# ARCHETYPE CROSS-REFERENCE

This document maps each archetype to the mods designed to fit that archetype's playstyle.

**Total Archetypes:** 3

---

## Fortress Tank

**Total Mods:** 17 (Weapons: 2, Items: 9, Syringes: 6)

**Playstyle:** Maximum defensive capability and survivability. Emphasizes armor, shields, HP, and damage mitigation.

### Weapons

#### TRI-PHASE EMITTER ARRAY (ID: 1045)

- **Type:** Weapon
- **Description:** Reconfigurable weapon platform cycling between ballistic (piercing), energy (elemental), and explosive (AoE) phases based on shots fired - every val1 shots triggers phase rotation with corresponding bonuses
- **Equation:** `B_PIERCINGSHOTS = B_PIERCINGSHOTS 2 +; B_IGNITECHANCE = B_IGNITECHANCE 0.3 +; B_EXPLOSIONRADIUS = B_EXPLOSIONRADIUS 1.5 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +; M_RELOADSPEED = M_RELOADSPEED -0.3 +`
- **Rarity Weight:** 100

#### ADAPTIVE SCALAR PLATFORM (ID: 1046)

- **Type:** Weapon
- **Description:** Quantum-adaptive weapon framework gaining val1% damage per 100 player speed, val2% fire rate per 10% current HP, and critical chance scaling with accuracy - true multi-stat hybrid
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED val1 * 0.01 * +; M_SHOTSPERSEC = M_SHOTSPERSEC T_HP val2 * 0.1 * +; M_CRITCHANCE = M_CRITCHANCE T_ACCURACY 0.5 * +; M_PROJECTILESPEED = M_PROJECTILESPEED 0.4 +; M_HP = M_HP -0.1 +`
- **Rarity Weight:** 100

### Items

#### REINFORCED NANITE SHELL (ID: 2000)

- **Type:** Weapon
- **Description:** Hardened nanite shell increasing maximum structural integrity by val1% through enhanced framework density
- **Equation:** `M_HP = M_HP val1 +`
- **Value Range:** 0.15 to 0.35
- **Rarity Weight:** 200

#### ABLATIVE PLATING MATRIX (ID: 2001)

- **Type:** Weapon
- **Description:** Ablative armor layers increasing damage reduction by val1% through layered nanite dispersion protocols
- **Equation:** `M_ARMOR = M_ARMOR val1 +`
- **Value Range:** 0.2 to 0.4
- **Rarity Weight:** 190

#### STRUCTURAL REINFORCEMENT PROTOCOLS (ID: 2002)

- **Type:** Weapon
- **Description:** Combined defensive matrix increasing HP by val1% and armor by val2%, but reducing movement speed by 10%
- **Equation:** `M_HP = M_HP val1 +; M_ARMOR = M_ARMOR val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +`
- **Value Range:** 0.1 to 0.25
- **Value2 Range:** 0.15 to 0.3
- **Rarity Weight:** 180

#### HARDPOINT ABSORPTION BARRIER (ID: 2003)

- **Type:** Weapon
- **Description:** Advanced barrier system granting val1% HP increase and val2 flat damage absorption per hit, with 15% reduced stamina capacity
- **Equation:** `M_HP = M_HP val1 +; B_DAMAGEABSORPTION = B_DAMAGEABSORPTION val2 +; M_MAXSTAMINA = M_MAXSTAMINA -0.15 +`
- **Value Range:** 0.2 to 0.4
- **Value2 Range:** 15.0 to 35.0
- **Rarity Weight:** 75

#### REACTIVE PLATING ASSEMBLY (ID: 2004)

- **Type:** Weapon
- **Description:** Reflective armor matrix increasing armor by val1% and reflecting val2% of received damage, with 20% reduced damage output
- **Equation:** `M_ARMOR = M_ARMOR val1 +; B_REFLECTDAMAGE = B_REFLECTDAMAGE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.2 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.2 +`
- **Value Range:** 0.3 to 0.6
- **Value2 Range:** 0.15 to 0.3
- **Rarity Weight:** 70

#### ADAPTIVE REGENERATION CORE (ID: 2005)

- **Type:** Weapon
- **Description:** Experimental regeneration protocols granting val1 HP regen per second, plus additional val2 regen per 100 armor possessed, with 25% reduced maximum stamina
- **Equation:** `B_HPREGEN = B_HPREGEN val1 +; B_HPREGEN = B_HPREGEN T_ARMOR val2 * 0.01 * +; M_MAXSTAMINA = M_MAXSTAMINA -0.25 +`
- **Value Range:** 3.0 to 8.0
- **Value2 Range:** 0.5 to 1.5
- **Rarity Weight:** 35

#### RETRIBUTION FRAMEWORK (ID: 2006)

- **Type:** Weapon
- **Description:** Retaliatory combat matrix inflicting val1 base thorns damage plus additional val2 damage per 100 maximum HP, with 30% reduced movement and sprint speed
- **Equation:** `B_THORNDAMAGE = B_THORNDAMAGE val1 +; B_THORNDAMAGE = B_THORNDAMAGE T_HP val2 * 0.01 * +; M_PLAYERSPEED = M_PLAYERSPEED -0.15 +; M_SPRINTSPEED = M_SPRINTSPEED -0.3 +`
- **Value Range:** 20.0 to 50.0
- **Value2 Range:** 2.0 to 6.0
- **Rarity Weight:** 30

#### FORTRESS DEVASTATOR CORE (ID: 2007)

- **Type:** Weapon
- **Description:** Experimental protocols granting val1% maximum HP increase and val2% HP-to-damage conversion, gaining 1% gun and melee damage per 50 maximum HP but reducing movement speed by 40% and fire rate by 35%
- **Equation:** `B_MAXHPPERCENTBONUS = B_MAXHPPERCENTBONUS val1 +; M_GUNDAMAGE = M_GUNDAMAGE T_HP val2 * 0.02 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP val2 * 0.02 * +; M_PLAYERSPEED = M_PLAYERSPEED -0.4 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.35 +`
- **Value Range:** 0.6 to 1.2
- **Value2 Range:** 0.8 to 1.5
- **Rarity Weight:** 5

#### KINETIC ACCELERATOR NANITES (ID: 2008)

- **Type:** Weapon
- **Description:** Locomotion enhancement nanites increase base movement speed by val1% through optimized actuator protocols
- **Equation:** `M_PLAYERSPEED = M_PLAYERSPEED val1 +`
- **Value Range:** 0.15 to 0.3
- **Rarity Weight:** 200

### Syringes

#### STRUCTURAL FORTIFICATION SERUM (ID: 3010)

- **Type:** Type 10
- **Description:** Defensive protocol injection increasing maximum structural integrity by val1% through enhanced nanite framework density
- **Equation:** `M_HP = M_HP val1 +`
- **Value Range:** 0.2 to 0.4
- **Rarity Weight:** 200

#### ABLATIVE ARMOR NANITES (ID: 3011)

- **Type:** Type 10
- **Description:** Protective nanite serum coating outer framework with ablative plating, increasing armor effectiveness by val1%
- **Equation:** `M_ARMOR = M_ARMOR val1 +`
- **Value Range:** 0.25 to 0.45
- **Rarity Weight:** 190

#### ENERGY BARRIER AMPLIFIER (ID: 3012)

- **Type:** Type 10
- **Description:** Shield augmentation protocols expanding energy barrier capacity by val1% for enhanced protective layering
- **Equation:** `M_SHIELDCAPACITY = M_SHIELDCAPACITY val1 +`
- **Value Range:** 0.3 to 0.6
- **Rarity Weight:** 185

#### IMPACT DISPERSAL INJECTION (ID: 3013)

- **Type:** Type 10
- **Description:** Defensive nanite layer providing val1 flat damage reduction per impact through kinetic energy dispersal
- **Equation:** `B_DAMAGEABSORPTION = B_DAMAGEABSORPTION val1 +`
- **Value Range:** 10.0 to 25.0
- **Rarity Weight:** 180

#### REINFORCED BATTLE PROTOCOLS (ID: 3014)

- **Type:** Type 10
- **Description:** Combined defensive matrix increasing structural integrity by val1% and armor by val2%, with 10% reduced movement speed due to reinforcement mass
- **Equation:** `M_HP = M_HP val1 +; M_ARMOR = M_ARMOR val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +`
- **Value Range:** 0.15 to 0.3
- **Value2 Range:** 0.15 to 0.3
- **Rarity Weight:** 75

#### ADAPTIVE SHIELD MATRIX (ID: 3015)

- **Type:** Type 10
- **Description:** Shield enhancement protocols increasing energy barrier capacity by val1% and regeneration rate by val2%, with 15% reduced damage output while barrier systems consume power
- **Equation:** `M_SHIELDCAPACITY = M_SHIELDCAPACITY val1 +; M_SHIELDREGENRATE = M_SHIELDREGENRATE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.15 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.15 +`
- **Value Range:** 0.25 to 0.5
- **Value2 Range:** 0.15 to 0.35
- **Rarity Weight:** 70

---

## Glass Cannon

**Total Mods:** 18 (Weapons: 6, Items: 6, Syringes: 6)

**Playstyle:** Maximum offensive power at the cost of survivability. Focuses on critical hits, damage amplification, and precision weaponry.

### Weapons

#### KINETIC ACCELERATOR MATRIX (ID: 1000)

- **Type:** Syringe
- **Description:** Standard ballistic assembly using electromagnetic acceleration to propel nanite-compressed projectiles at moderate velocity with balanced fire rate
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC val2 +`
- **Value Range:** 0.1 to 0.3
- **Value2 Range:** 0.1 to 0.2
- **Rarity Weight:** 200

#### RAPID CYCLE PROJECTOR (ID: 1001)

- **Type:** Syringe
- **Description:** High-frequency projectile assembly optimized for rapid ammunition cycling, firing val1 additional shots per second but reducing per-shot damage by val2%
- **Equation:** `B_SHOTSPERSEC = B_SHOTSPERSEC val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +`
- **Value Range:** 3.0 to 7.0
- **Value2 Range:** 0.2 to 0.4
- **Rarity Weight:** 150

#### SCATTER ARRAY PROJECTOR (ID: 1002)

- **Type:** Syringe
- **Description:** Dispersed projectile matrix firing val1 simultaneous nanite packets in spread pattern, with val2% reduced accuracy per projectile
- **Equation:** `B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_ACCURACY = M_ACCURACY val2 +`
- **Value Range:** 5.0 to 9.0
- **Value2 Range:** 0.5 to 1.2
- **Rarity Weight:** 180

#### TACTICAL CARBINE ASSEMBLY (ID: 1005)

- **Type:** Syringe
- **Description:** Versatile compact framework increasing mobility with val1% movement speed while firing, but with val2% reduced damage output
- **Equation:** `M_PLAYERSPEED = M_PLAYERSPEED val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +`
- **Value Range:** 0.15 to 0.3
- **Value2 Range:** 0.1 to 0.2
- **Rarity Weight:** 190

#### ARMOR BREACH PROJECTOR (ID: 1006)

- **Type:** Syringe
- **Description:** Armor-penetrating projectile assembly with val1 piercing shots capability and val2% increased damage, but val2% slower reload speed
- **Equation:** `B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_RELOADSPEED = M_RELOADSPEED -val2 +`
- **Value Range:** 2.0 to 5.0
- **Value2 Range:** 0.25 to 0.5
- **Rarity Weight:** 75

#### HYPERKINETIC STRIKER (ID: 1007)

- **Type:** Syringe
- **Description:** Extreme velocity accelerator increasing projectile speed by val1%, critical chance by val2%, but reducing magazine capacity by 40%
- **Equation:** `M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +; M_AMMOCAPACITY = M_AMMOCAPACITY -0.4 +`
- **Value Range:** 0.6 to 1.2
- **Value2 Range:** 0.1 to 0.2
- **Rarity Weight:** 65

### Items

#### PRECISION TARGETING MATRIX (ID: 2021)

- **Type:** Weapon
- **Description:** Advanced targeting protocols analyze enemy structural weaknesses, increasing critical strike probability by val1% through enhanced threat assessment algorithms
- **Equation:** `M_CRITCHANCE = M_CRITCHANCE val1 +`
- **Value Range:** 0.15 to 0.3
- **Rarity Weight:** 200

#### DAMAGE AMPLIFIER CORE (ID: 2022)

- **Type:** Weapon
- **Description:** Weapon output optimization protocols increasing projectile damage by val1% through enhanced energy conversion efficiency
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +`
- **Value Range:** 0.2 to 0.4
- **Rarity Weight:** 200

#### PROC ENHANCEMENT PROTOCOLS (ID: 2023)

- **Type:** Weapon
- **Description:** Optimized effect amplification systems increasing proc trigger frequency by val1% for enhanced status effect application rates
- **Equation:** `M_PROCRATE = M_PROCRATE val1 +`
- **Value Range:** 0.25 to 0.5
- **Rarity Weight:** 190

#### CRITICAL STRIKE ASSEMBLY (ID: 2024)

- **Type:** Weapon
- **Description:** Integrated precision systems granting val1% critical strike chance and val2% critical damage multiplier, with 30% reduced armor effectiveness from structural compromises
- **Equation:** `M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_ARMOR = M_ARMOR -0.3 +`
- **Value Range:** 0.2 to 0.35
- **Value2 Range:** 0.4 to 0.8
- **Rarity Weight:** 75

#### OFFENSIVE OVERLOAD MATRIX (ID: 2025)

- **Type:** Weapon
- **Description:** Aggressive weapon calibration increasing gun damage by val1% and proc effectiveness by val2%, but reducing maximum structural integrity by 25% from power distribution compromises
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_PROCRATE = M_PROCRATE val2 +; M_HP = M_HP -0.25 +`
- **Value Range:** 0.3 to 0.5
- **Value2 Range:** 0.4 to 0.7
- **Rarity Weight:** 70

#### FULL INTEGRITY PROTOCOL (ID: 2026)

- **Type:** Weapon
- **Description:** Perfection-optimized targeting systems granting val1% critical chance and val2% damage when at maximum structural integrity, but providing no benefits when damaged
- **Equation:** `M_CRITCHANCE = M_CRITCHANCE T_HP T_HP < -1.0 * val1 * +; M_GUNDAMAGE = M_GUNDAMAGE T_HP T_HP < -1.0 * val2 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP T_HP < -1.0 * val2 * +`
- **Value Range:** 0.5 to 0.8
- **Value2 Range:** 0.4 to 0.7
- **Rarity Weight:** 35

### Syringes

#### DAMAGE ENHANCEMENT SERUM (ID: 3000)

- **Type:** Type 10
- **Description:** Offensive protocol injection increasing projectile damage output by val1% through weapon emitter optimization nanites
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +`
- **Value Range:** 0.08 to 0.12
- **Rarity Weight:** 200

#### FIRE RATE STIMULANT (ID: 3001)

- **Type:** Type 10
- **Description:** Attack speed protocol injection increasing projectile firing frequency by val1 shots per second through accelerated targeting cycles
- **Equation:** `B_SHOTSPERSEC = B_SHOTSPERSEC val1 +`
- **Value Range:** 0.5 to 1.0
- **Rarity Weight:** 200

#### MELEE ACCELERATION INJECTION (ID: 3002)

- **Type:** Type 10
- **Description:** Combat reflex enhancement increasing melee attack execution speed by val1% through motor protocol optimization
- **Equation:** `M_MELEESPEED = M_MELEESPEED val1 +`
- **Value Range:** 0.1 to 0.15
- **Rarity Weight:** 190

#### PRECISION TARGETING STIMULANT (ID: 3003)

- **Type:** Type 10
- **Description:** Targeting protocol enhancement increasing critical strike probability by val1% through threat assessment algorithm optimization
- **Equation:** `M_CRITCHANCE = M_CRITCHANCE val1 +`
- **Value Range:** 0.05 to 0.1
- **Rarity Weight:** 190

#### MELEE POWER INJECTION (ID: 3004)

- **Type:** Type 10
- **Description:** Combat enhancement injection increasing melee strike damage by val1% through kinetic amplification protocols
- **Equation:** `M_MELEEDAMAGE = M_MELEEDAMAGE val1 +`
- **Value Range:** 0.08 to 0.12
- **Rarity Weight:** 190

#### AGGRESSIVE COMBAT PROTOCOL (ID: 3005)

- **Type:** Type 10
- **Description:** Dual-system injection increasing gun damage by val1% and fire rate by val2 shots per second, with 15% reduced armor from power distribution compromises
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +; B_SHOTSPERSEC = B_SHOTSPERSEC val2 +; M_ARMOR = M_ARMOR -0.15 +`
- **Value Range:** 0.1 to 0.15
- **Value2 Range:** 0.5 to 1.0
- **Rarity Weight:** 80

---

## Hybrid Berserker

**Total Mods:** 15 (Weapons: 5, Items: 4, Syringes: 6)

**Playstyle:** Balanced offense and defense with lifesteal and hybrid combat bonuses. Sustains through dealing damage.

### Weapons

#### SYNCHRONIZED CONSTRUCT ARRAY (ID: 1040)

- **Type:** Type 4
- **Description:** Coordinated multi-unit deployment system spawning val1 tactical constructs with val2% balanced combat enhancement to all minion parameters, reducing player damage by 35% and HP by 15%
- **Equation:** `B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_MINIONHP = M_MINIONHP val2 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.35 +; M_HP = M_HP -0.15 +`
- **Value Range:** 2.0 to 4.0
- **Value2 Range:** 0.25 to 0.45
- **Rarity Weight:** 65

#### ADAPTIVE SWARM NEXUS (ID: 1041)

- **Type:** Type 4
- **Description:** Experimental swarm intelligence framework deploying val1 adaptive constructs that gain val2% damage per 100 player gun damage and 0.5% HP per point of player armor, reducing player damage by 50% and accuracy by 60%
- **Equation:** `B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE T_GUNDAMAGE 100 / val2 * +; M_MINIONHP = M_MINIONHP T_ARMOR 0.005 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.5 +; M_ACCURACY = M_ACCURACY 0.6 +`
- **Value Range:** 2.0 to 4.0
- **Value2 Range:** 0.8 to 1.5
- **Rarity Weight:** 35

#### AUTONOMOUS COMMAND MATRIX (ID: 1042)

- **Type:** Type 4
- **Description:** Hierarchical construct deployment system spawning val1 command-tier units that gain 1% to all stats per additional minion active on field, with val2% base damage increase but reducing player HP by 30% and player damage by 40%
- **Equation:** `B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 + T_NUMMINIONS 0.01 * +; M_MINIONHP = M_MINIONHP T_NUMMINIONS 0.01 * +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED T_NUMMINIONS 0.01 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.4 +; M_HP = M_HP -0.3 +`
- **Value Range:** 1.0 to 2.0
- **Value2 Range:** 0.5 to 1.0
- **Rarity Weight:** 30

#### SELF-REPLICATING NANITE NEXUS (ID: 1043)

- **Type:** Type 4
- **Description:** Experimental self-sustaining fabrication core deploying val1 autonomous constructs that gain val2% damage per 10% HP player is missing, and gain 1% attack speed per 5 energy capacity, but reducing all player damage by 60% and player HP regen by 80%
- **Equation:** `B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE (T_HP S_HP /) 1 - val2 * 10 * + +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED T_ENERGYCAPACITY 5 / 0.01 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.6 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.6 +; M_HPREGEN = M_HPREGEN -0.8 +`
- **Value Range:** 2.0 to 4.0
- **Value2 Range:** 1.2 to 2.0
- **Rarity Weight:** 5

#### DUAL-MODE COMBAT MATRIX (ID: 1044)

- **Type:** Weapon
- **Description:** Adaptive weapon platform switching between precision mode (high damage, slow fire) when accuracy exceeds 70%, or suppression mode (high fire rate, lower damage) below that threshold
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE T_ACCURACY 0.7 > val1 * +; M_SHOTSPERSEC = M_SHOTSPERSEC T_ACCURACY 0.7 < val2 * +; M_ACCURACY = M_ACCURACY -0.15 +`
- **Rarity Weight:** 100

### Items

#### NANITE RECONSTRUCTION MATRIX (ID: 2015)

- **Type:** Weapon
- **Description:** Automated repair protocols continuously reconstruct damaged framework nanites, restoring val1 structural integrity points per second during combat
- **Equation:** `B_HPREGEN = B_HPREGEN val1 +`
- **Value Range:** 5.0 to 15.0
- **Rarity Weight:** 200

#### CRITICAL MASS REGENERATOR (ID: 2020)

- **Type:** Weapon
- **Description:** Emergency reconstruction protocols activate when structural integrity falls below 30%, providing val1 HP/sec regeneration and converting val2% of total regeneration into bonus damage output
- **Equation:** `B_HPREGEN = B_HPREGEN T_HP T_HP 0.3 * < val1 * +; M_GUNDAMAGE = M_GUNDAMAGE T_HPREGEN val2 * 0.01 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HPREGEN val2 * 0.01 * +`
- **Value Range:** 80.0 to 150.0
- **Value2 Range:** 3.0 to 6.0
- **Rarity Weight:** 5

#### PRECISION TARGETING MATRIX (ID: 2021)

- **Type:** Weapon
- **Description:** Advanced targeting protocols analyze enemy structural weaknesses, increasing critical strike probability by val1% through enhanced threat assessment algorithms
- **Equation:** `M_CRITCHANCE = M_CRITCHANCE val1 +`
- **Value Range:** 0.15 to 0.3
- **Rarity Weight:** 200

#### DAMAGE AMPLIFIER CORE (ID: 2022)

- **Type:** Weapon
- **Description:** Weapon output optimization protocols increasing projectile damage by val1% through enhanced energy conversion efficiency
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +`
- **Value Range:** 0.2 to 0.4
- **Rarity Weight:** 200

### Syringes

#### DAMAGE ENHANCEMENT SERUM (ID: 3000)

- **Type:** Type 10
- **Description:** Offensive protocol injection increasing projectile damage output by val1% through weapon emitter optimization nanites
- **Equation:** `M_GUNDAMAGE = M_GUNDAMAGE val1 +`
- **Value Range:** 0.08 to 0.12
- **Rarity Weight:** 200

#### MELEE POWER INJECTION (ID: 3004)

- **Type:** Type 10
- **Description:** Combat enhancement injection increasing melee strike damage by val1% through kinetic amplification protocols
- **Equation:** `M_MELEEDAMAGE = M_MELEEDAMAGE val1 +`
- **Value Range:** 0.08 to 0.12
- **Rarity Weight:** 190

#### BERSERKER COMBAT STIMULANT (ID: 3006)

- **Type:** Type 10
- **Description:** Hybrid offensive injection increasing melee damage by val1% and attack speed by val2%, with 10% reduced maximum structural integrity
- **Equation:** `M_MELEEDAMAGE = M_MELEEDAMAGE val1 +; M_MELEESPEED = M_MELEESPEED val2 +; M_HP = M_HP -0.1 +`
- **Value Range:** 0.1 to 0.15
- **Value2 Range:** 0.1 to 0.15
- **Rarity Weight:** 75

#### CRITICAL PRECISION SERUM (ID: 3007)

- **Type:** Type 10
- **Description:** Precision enhancement injection increasing critical strike chance by val1% and critical damage multiplier by val2%, with 10% reduced movement speed from targeting system overhead
- **Equation:** `M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +`
- **Value Range:** 0.08 to 0.12
- **Value2 Range:** 0.15 to 0.25
- **Rarity Weight:** 70

#### STRUCTURAL FORTIFICATION SERUM (ID: 3010)

- **Type:** Type 10
- **Description:** Defensive protocol injection increasing maximum structural integrity by val1% through enhanced nanite framework density
- **Equation:** `M_HP = M_HP val1 +`
- **Value Range:** 0.2 to 0.4
- **Rarity Weight:** 200

#### REGENERATIVE NANITE INJECTION (ID: 3020)

- **Type:** Type 10
- **Description:** Metabolic enhancer serum accelerating nanite reconstruction protocols, restoring val1 structural integrity points per second through optimized repair cycles
- **Equation:** `B_HPREGEN = B_HPREGEN val1 +`
- **Value Range:** 3.0 to 8.0
- **Rarity Weight:** 200

---

## Summary

### Mod Distribution by Archetype

| Archetype | Weapons | Items | Syringes | Total |
|-----------|---------|-------|----------|-------|
| Fortress Tank | 2 | 9 | 6 | 17 |
| Glass Cannon | 6 | 6 | 6 | 18 |
| Hybrid Berserker | 5 | 4 | 6 | 15 |
