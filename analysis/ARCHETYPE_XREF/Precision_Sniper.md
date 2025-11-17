# Precision Sniper

**Total Mods:** 40 (Weapons: 24, Items: 5, Syringes: 11)

## Archetype Overview

**Identity:** Long-range burst precision damage

**Core Stats:** ACCURACY 95%+, RANGE 500+, CRITDAMAGE 300%+, PROJECTILESPEED high

**Fantasy:** One-shot-one-kill marksman

---

## Weapons

### COHERENT LIGHT PROJECTOR

**Mod ID:** 515

**Type:** Syringe

**Description:** Emits focused photonic beam with val1% improved accuracy and instant projectile velocity

**Equation:**
```
M_ACCURACY = M_ACCURACY -val1 +; B_BULLETSPEED = B_BULLETSPEED 9999 +
```

**Value Range:** 0.1 to 0.2

**Rarity Weight:** 100

---

### PULSE LASER ARRAY

**Mod ID:** 517

**Type:** Syringe

**Description:** Fires val1 rapid laser pulses per trigger pull with val2% increased critical strike chance per pulse

**Equation:**
```
B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +
```

**Value Range:** 2.0 to 4.0

**Value2 Range:** 0.15 to 0.25

**Rarity Weight:** 75

---

### PHOTONIC ACCELERATOR RIFLE

**Mod ID:** 521

**Type:** Syringe

**Description:** Ultra-precise photon beam with val1 critical chance bonus and val2 critical damage multiplier when accuracy exceeds 90%

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE T_ACCURACY 0.9 > val2 * +
```

**Value Range:** 0.2 to 0.3

**Value2 Range:** 0.6 to 1.2

**Rarity Weight:** 40

---

### SCATTER ARRAY PROJECTOR

**Mod ID:** 1002

**Type:** Syringe

**Description:** Dispersed projectile matrix firing val1 simultaneous nanite packets in spread pattern, with val2% reduced accuracy per projectile

**Equation:**
```
B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_ACCURACY = M_ACCURACY val2 +
```

**Value Range:** 5.0 to 9.0

**Value2 Range:** 0.5 to 1.2

**Rarity Weight:** 180

---

### PRECISION EMITTER ASSEMBLY

**Mod ID:** 1003

**Type:** Syringe

**Description:** Long-range ballistic framework with enhanced targeting protocols, increasing projectile velocity by val1% and accuracy by val2%, but reducing fire rate by 30%

**Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_ACCURACY = M_ACCURACY -val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.3 +
```

**Value Range:** 0.4 to 0.8

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 160

---

### HYPERKINETIC STRIKER

**Mod ID:** 1007

**Type:** Syringe

**Description:** Extreme velocity accelerator increasing projectile speed by val1%, critical chance by val2%, but reducing magazine capacity by 40%

**Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +; M_AMMOCAPACITY = M_AMMOCAPACITY -0.4 +
```

**Value Range:** 0.6 to 1.2

**Value2 Range:** 0.1 to 0.2

**Rarity Weight:** 65

---

### CRITICAL STRIKE ACCELERATOR

**Mod ID:** 1009

**Type:** Syringe

**Description:** Precision-tuned targeting matrix increasing critical chance by val1% and critical damage multiplier by val2, with val2% reduced fire rate

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -val1 +
```

**Value Range:** 0.15 to 0.3

**Value2 Range:** 0.5 to 1.0

**Rarity Weight:** 60

---

### HYPERVELOCITY IMPACT CANNON

**Mod ID:** 1010

**Type:** Syringe

**Description:** Experimental projectile accelerator achieving val1% increased speed and val2% damage, but with 60% reduced accuracy and 20% slower fire rate

**Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_ACCURACY = M_ACCURACY 0.6 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.2 +
```

**Value Range:** 1.5 to 2.5

**Value2 Range:** 0.6 to 1.0

**Rarity Weight:** 35

---

### OVERCHARGE KINETIC CORE

**Mod ID:** 1012

**Type:** Syringe

**Description:** Adaptive damage protocols scaling with accuracy - gain val1% damage per 10% accuracy possessed, but reduce fire rate by val2%

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_ACCURACY val1 * 10 / +; M_SHOTSPERSEC = M_SHOTSPERSEC -val2 +
```

**Value Range:** 0.8 to 1.5

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 25

---

### ADAPTIVE BALLISTIC NEXUS

**Mod ID:** 1013

**Type:** Syringe

**Description:** Experimental assembly that converts val1% of critical damage multiplier into fire rate, and gains val2% lifesteal per 100 shots fired per second

**Equation:**
```
M_SHOTSPERSEC = M_SHOTSPERSEC T_CRITDAMAGE val1 * 0.1 * +; B_LIFESTEAL = B_LIFESTEAL T_SHOTSPERSEC val2 * 0.01 * +
```

**Value Range:** 0.3 to 0.6

**Value2 Range:** 0.05 to 0.15

**Rarity Weight:** 5

---

### FRAGMENTATION LAUNCHER

**Mod ID:** 1025

**Type:** Weapon

**Description:** Deploys fragmentation warheads with val1 explosion radius, but fires at drastically reduced speed and projectiles move slowly, requiring careful positioning

**Equation:**
```
B_EXPLOSIONRADIUS=val1;M_SHOTSPERSEC=-0.6;M_PROJECTILESPEED=-0.5
```

**Rarity Weight:** 100

---

### IMPACT CHARGES

**Mod ID:** 1026

**Type:** Weapon

**Description:** Fires contact-detonation charges dealing val1% increased damage with moderate blast radius, but at cost of val2% accuracy and reduced fire rate

**Equation:**
```
M_GUNDAMAGE=val1;B_EXPLOSIONRADIUS=1.2;M_ACCURACY=-val2;M_SHOTSPERSEC=-0.4
```

**Rarity Weight:** 100

---

### PROXIMITY MINE DEPLOYER

**Mod ID:** 1027

**Type:** Weapon

**Description:** Deploys proximity-triggered mines with val1 blast radius that arm after brief delay, fires slowly but denies area effectively

**Equation:**
```
B_EXPLOSIONRADIUS=val1;M_SHOTSPERSEC=-0.7;M_PROJECTILESPEED=-0.8;B_GUNDAMAGE=15
```

**Rarity Weight:** 100

---

### THERMAL WARHEAD ARRAY

**Mod ID:** 1028

**Type:** Weapon

**Description:** Fires incendiary warheads with val1 blast radius that ignite targets with val2% chance, but drains structural integrity by 0.15% max HP and reduces fire rate severely

**Equation:**
```
B_EXPLOSIONRADIUS=val1;M_IGNITECHANCE=val2;M_HP=-0.15;M_SHOTSPERSEC=-0.5;M_PROJECTILESPEED=-0.4
```

**Rarity Weight:** 100

---

### CORRUPTION PAYLOAD LAUNCHER

**Mod ID:** 1030

**Type:** Weapon

**Description:** Fires viral corruption charges with val1 blast radius applying corruption to all targets, but reduces accuracy by val2% and fires extremely slowly with self-corruption risk

**Equation:**
```
B_EXPLOSIONRADIUS=val1;B_CORRUPTIONCHANCE=0.6;M_ACCURACY=-val2;M_SHOTSPERSEC=-0.65;M_HPREGEN=-0.1
```

**Rarity Weight:** 100

---

### CLUSTER STORM PROJECTOR

**Mod ID:** 1031

**Type:** Weapon

**Description:** Launches primary charge that splits into val1 submunitions each with val2 blast radius, but drastically reduces fire rate, accuracy, and max HP by 20%

**Equation:**
```
B_BULLETSFIRED=val1;B_EXPLOSIONRADIUS=val2;M_SHOTSPERSEC=-0.75;M_ACCURACY=-0.5;M_HP=-0.2;B_GUNDAMAGE=20
```

**Rarity Weight:** 100

---

### CHAIN REACTION MATRIX

**Mod ID:** 1032

**Type:** Weapon

**Description:** Deploys reactive charges with val1 radius that chain-detonate nearby enemies, dealing bonus damage per chain, but reduces fire rate by 70% and movement speed by val2%

**Equation:**
```
B_EXPLOSIONRADIUS=val1;M_GUNDAMAGE=0.4;M_SHOTSPERSEC=-0.7;M_PLAYERSPEED=-val2;M_PROJECTILESPEED=-0.6;B_PIERCINGSHOTS=2
```

**Rarity Weight:** 100

---

### NANITE CASCADE BOMB

**Mod ID:** 1033

**Type:** Weapon

**Description:** Deploys experimental nanite cascade charge with exponential spread: initial val1 radius explosion triggers secondary detonations on affected enemies, each spreading further. Fires once per val2 seconds and reduces max HP by 25%

**Equation:**
```
B_EXPLOSIONRADIUS=val1;U_SHOTSPERSEC=val2;M_HP=-0.25;M_GUNDAMAGE=0.8;B_PIERCINGSHOTS=5;M_ACCURACY=-0.7;M_PROJECTILESPEED=-0.9
```

**Rarity Weight:** 100

---

### ASSAULT CONSTRUCTOR FRAMEWORK

**Mod ID:** 1037

**Type:** Type 4

**Description:** Rapid-deployment combat fabricator spawning val1 aggressive constructs with val2% increased damage output, but reducing personal accuracy by 40% due to targeting protocol conflicts

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_ACCURACY = M_ACCURACY 0.4 +
```

**Value Range:** 1.0 to 2.0

**Value2 Range:** 0.4 to 0.7

**Rarity Weight:** 170

---

### RAPID FABRICATOR NETWORK

**Mod ID:** 1039

**Type:** Type 4

**Description:** Advanced nanite assembly matrix deploying val1 rapid-cycle combat drones with val2% attack speed, but destabilizing personal weapon systems reducing critical chance by 50% and reload speed by 30%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_CRITCHANCE = M_CRITCHANCE -0.5 +; M_RELOADSPEED = M_RELOADSPEED -0.3 +
```

**Value Range:** 2.0 to 3.0

**Value2 Range:** 0.8 to 1.4

**Rarity Weight:** 70

---

### ADAPTIVE SWARM NEXUS

**Mod ID:** 1041

**Type:** Type 4

**Description:** Experimental swarm intelligence framework deploying val1 adaptive constructs that gain val2% damage per 100 player gun damage and 0.5% HP per point of player armor, reducing player damage by 50% and accuracy by 60%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE T_GUNDAMAGE 100 / val2 * +; M_MINIONHP = M_MINIONHP T_ARMOR 0.005 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.5 +; M_ACCURACY = M_ACCURACY 0.6 +
```

**Value Range:** 2.0 to 4.0

**Value2 Range:** 0.8 to 1.5

**Rarity Weight:** 35

---

### DUAL-MODE COMBAT MATRIX

**Mod ID:** 1044

**Type:** Weapon

**Description:** Adaptive weapon platform switching between precision mode (high damage, slow fire) when accuracy exceeds 70%, or suppression mode (high fire rate, lower damage) below that threshold

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_ACCURACY 0.7 > val1 * +; M_SHOTSPERSEC = M_SHOTSPERSEC T_ACCURACY 0.7 < val2 * +; M_ACCURACY = M_ACCURACY -0.15 +
```

**Rarity Weight:** 100

---

### ADAPTIVE SCALAR PLATFORM

**Mod ID:** 1046

**Type:** Weapon

**Description:** Quantum-adaptive weapon framework gaining val1% damage per 100 player speed, val2% fire rate per 10% current HP, and critical chance scaling with accuracy - true multi-stat hybrid

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED val1 * 0.01 * +; M_SHOTSPERSEC = M_SHOTSPERSEC T_HP val2 * 0.1 * +; M_CRITCHANCE = M_CRITCHANCE T_ACCURACY 0.5 * +; M_PROJECTILESPEED = M_PROJECTILESPEED 0.4 +; M_HP = M_HP -0.1 +
```

**Rarity Weight:** 100

---

### CHROMATIC COHERENCE EDGE

**Mod ID:** 1054

**Type:** Type 4

**Description:** Experimental blade matrix converting val1% of gun damage to melee damage and granting val2 critical chance on melee, but disables ranged weapons entirely and reduces max HP by 15%

**Equation:**
```
A_MELEEDAMAGE = A_MELEEDAMAGE T_GUNDAMAGE val1 * +; M_MELEECRITCHANCE = M_MELEECRITCHANCE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -10 +; M_HP = M_HP -0.15 +; M_MELEERANGE = M_MELEERANGE 0.4 +
```

**Value Range:** 0.8 to 0.8

**Value2 Range:** 0.8 to 0.8

**Rarity Weight:** 8

---

## Items

### PRECISION TARGETING MATRIX

**Mod ID:** 2021

**Type:** Weapon

**Description:** Advanced targeting protocols analyze enemy structural weaknesses, increasing critical strike probability by val1% through enhanced threat assessment algorithms

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +
```

**Value Range:** 0.15 to 0.3

**Rarity Weight:** 200

---

### CRITICAL STRIKE ASSEMBLY

**Mod ID:** 2024

**Type:** Weapon

**Description:** Integrated precision systems granting val1% critical strike chance and val2% critical damage multiplier, with 30% reduced armor effectiveness from structural compromises

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_ARMOR = M_ARMOR -0.3 +
```

**Value Range:** 0.2 to 0.35

**Value2 Range:** 0.4 to 0.8

**Rarity Weight:** 75

---

### FULL INTEGRITY PROTOCOL

**Mod ID:** 2026

**Type:** Weapon

**Description:** Perfection-optimized targeting systems granting val1% critical chance and val2% damage when at maximum structural integrity, but providing no benefits when damaged

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE T_HP T_HP < -1.0 * val1 * +; M_GUNDAMAGE = M_GUNDAMAGE T_HP T_HP < -1.0 * val2 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP T_HP < -1.0 * val2 * +
```

**Value Range:** 0.5 to 0.8

**Value2 Range:** 0.4 to 0.7

**Rarity Weight:** 35

---

### ABSOLUTE DESTRUCTION CORE

**Mod ID:** 2028

**Type:** Weapon

**Description:** Experimental targeting override guaranteeing all attacks strike critical weakpoints (+val1% crit chance) with val2x critical damage multiplier, but reducing max HP by 50%, armor by 60%, and movement speed by 25%

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_HP = M_HP -0.5 +; M_ARMOR = M_ARMOR -0.6 +; M_PLAYERSPEED = M_PLAYERSPEED -0.25 +
```

**Value Range:** 0.7 to 0.95

**Value2 Range:** 1.5 to 3.0

**Rarity Weight:** 5

---

### VAMPIRIC TARGETING ASSEMBLY

**Mod ID:** 2047

**Type:** Weapon

**Description:** Predatory strike protocols granting val1% lifesteal and val2% critical damage amplification, but reducing armor by 25% from offensive optimization compromises

**Equation:**
```
B_LIFESTEAL = B_LIFESTEAL val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_ARMOR = M_ARMOR -0.25 +
```

**Value Range:** 0.2 to 0.35

**Value2 Range:** 0.5 to 1.0

**Rarity Weight:** 70

---

## Syringes

### PRECISION TARGETING STIMULANT

**Mod ID:** 3003

**Type:** Syringe

**Description:** Targeting protocol enhancement increasing critical strike probability by val1% through threat assessment algorithm optimization

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +
```

**Value Range:** 0.05 to 0.1

**Rarity Weight:** 190

---

### CRITICAL PRECISION SERUM

**Mod ID:** 3007

**Type:** Syringe

**Description:** Precision enhancement injection increasing critical strike chance by val1% and critical damage multiplier by val2%, with 10% reduced movement speed from targeting system overhead

**Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +
```

**Value Range:** 0.08 to 0.12

**Value2 Range:** 0.15 to 0.25

**Rarity Weight:** 70

---

### TARGETING OPTIMIZATION SERUM

**Mod ID:** 3039

**Type:** Syringe

**Description:** Precision calibration protocol increasing weapon accuracy by val1% through predictive targeting algorithms

**Equation:**
```
M_ACCURACY = M_ACCURACY val1 +
```

**Value Range:** 0.05 to 0.08

**Rarity Weight:** 200

---

### RANGE EXTENSION SERUM

**Mod ID:** 3040

**Type:** Syringe

**Description:** Effective distance protocol increasing weapon range by val1% through enhanced projectile stability systems

**Equation:**
```
M_RANGE = M_RANGE val1 +
```

**Value Range:** 0.08 to 0.12

**Rarity Weight:** 195

---

### PROC ZONE EXPANSION SERUM

**Mod ID:** 3041

**Type:** Syringe

**Description:** Area effect protocol increasing proc and AoE range by val1% through blast radius optimization nanites

**Equation:**
```
M_PROCRANGE = M_PROCRANGE val1 +
```

**Value Range:** 0.1 to 0.15

**Rarity Weight:** 190

---

### PROJECTILE VELOCITY SERUM

**Mod ID:** 3042

**Type:** Syringe

**Description:** Acceleration enhancement protocol increasing projectile speed by val1% through velocity amplification nanites

**Equation:**
```
M_PROJECTILESPEED = M_PROJECTILESPEED val1 +
```

**Value Range:** 0.12 to 0.18

**Rarity Weight:** 185

---

### MULTI-RANGE OPTIMIZATION PROTOCOL

**Mod ID:** 3043

**Type:** Syringe

**Description:** Dual-range injection granting val1% weapon range and val2% melee range, with 10% reduced damage output

**Equation:**
```
M_RANGE = M_RANGE val1 +; M_MELEERANGE = M_MELEERANGE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.1 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.1 +
```

**Value Range:** 0.15 to 0.25

**Value2 Range:** 0.2 to 0.3

**Rarity Weight:** 85

---

### PRECISION BARRAGE PROTOCOL

**Mod ID:** 3044

**Type:** Syringe

**Description:** Multi-projectile injection granting val1 additional bullets per shot and val2% increased accuracy, with 15% reduced fire rate

**Equation:**
```
B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_ACCURACY = M_ACCURACY val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.15 +
```

**Value Range:** 1.0 to 2.0

**Value2 Range:** 0.12 to 0.18

**Rarity Weight:** 80

---

### ADAPTIVE TARGETING MATRIX

**Mod ID:** 3045

**Type:** Syringe

**Description:** Experimental adaptive targeting granting val1% accuracy, val2% range, and gaining 1% additional accuracy per 10% missing accuracy (scales with low accuracy), with 12% reduced movement speed

**Equation:**
```
M_ACCURACY = M_ACCURACY val1 +; M_RANGE = M_RANGE val2 +; M_ACCURACY = M_ACCURACY 1 + T_ACCURACY - 0.1 *; M_PLAYERSPEED = M_PLAYERSPEED -0.12 +
```

**Value Range:** 0.15 to 0.25

**Value2 Range:** 0.15 to 0.25

**Rarity Weight:** 40

---

### PERFECT PRECISION CORE

**Mod ID:** 3046

**Type:** Syringe

**Description:** Ultimate precision transformation setting accuracy to 100% (never miss), granting val1% range and val2% projectile speed, with 30% reduced gun damage and 20% reduced fire rate

**Equation:**
```
Z_ACCURACY = 1.0; M_RANGE = M_RANGE val1 +; M_PROJECTILESPEED = M_PROJECTILESPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.2 +
```

**Value Range:** 0.4 to 0.6

**Value2 Range:** 0.5 to 0.8

**Rarity Weight:** 10

---

### CHAOS VARIANCE INJECTOR

**Mod ID:** 3048

**Type:** Syringe

**Description:** Experimental randomization protocol granting val1% damage variance (random damage between 50% to 150%) and val2% increased crit chance, with 20% reduced accuracy

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE RAND val1 * -0.5 + +; M_MELEEDAMAGE = M_MELEEDAMAGE RAND val1 * -0.5 + +; M_CRITCHANCE = M_CRITCHANCE val2 +; M_ACCURACY = M_ACCURACY -0.2 +
```

**Value Range:** 0.8 to 1.2

**Value2 Range:** 0.15 to 0.25

**Rarity Weight:** 30

---
