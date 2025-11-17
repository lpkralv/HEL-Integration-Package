# Speed Demon

**Total Mods:** 43 (Weapons: 11, Items: 18, Syringes: 14)

## Archetype Overview

**Identity:** High mobility, hit-and-run tactics

**Core Stats:** PLAYERSPEED 500+, DASHSPEED 200%+, DODGECHANCE 40%+

**Fantasy:** Untouchable speedster

---

## Weapons

### KINETIC ACCELERATOR MATRIX

**Mod ID:** 1000

**Type:** Syringe

**Description:** Standard ballistic assembly using electromagnetic acceleration to propel nanite-compressed projectiles at moderate velocity with balanced fire rate

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC val2 +
```

**Value Range:** 0.1 to 0.3

**Value2 Range:** 0.1 to 0.2

**Rarity Weight:** 200

---

### TACTICAL CARBINE ASSEMBLY

**Mod ID:** 1005

**Type:** Syringe

**Description:** Versatile compact framework increasing mobility with val1% movement speed while firing, but with val2% reduced damage output

**Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +
```

**Value Range:** 0.15 to 0.3

**Value2 Range:** 0.1 to 0.2

**Rarity Weight:** 190

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

### ELECTRIC BURST ORDNANCE

**Mod ID:** 1029

**Type:** Weapon

**Description:** Deploys electrically-charged explosives with val1 radius and val2% charge application chance, but reduces movement speed by 20% due to capacitor weight and fires slowly

**Equation:**
```
B_EXPLOSIONRADIUS=val1;M_CHARGECHANCE=val2;M_PLAYERSPEED=-0.2;M_SHOTSPERSEC=-0.55;B_GUNDAMAGE=8
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

### HEAVY SIEGE PLATFORM

**Mod ID:** 1038

**Type:** Type 4

**Description:** Industrial-grade combat construct deploying val1 siege-class autonomous platforms with val2% increased damage and 50% increased armor, reducing player fire rate by 40% and movement speed by 20%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_MINIONHP = M_MINIONHP 0.5 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.4 +; M_PLAYERSPEED = M_PLAYERSPEED -0.2 +
```

**Value Range:** 1.0 to 2.0

**Value2 Range:** 0.6 to 1.0

**Rarity Weight:** 75

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

### KINETIC BLADE MATRIX

**Mod ID:** 1048

**Type:** Type 4

**Description:** Coherent nanite blade with val1% increased melee damage and val2% improved attack speed for balanced close combat

**Equation:**
```
M_MELEEDAMAGE = M_MELEEDAMAGE val1 +; M_MELEESPEED = M_MELEESPEED val2 +
```

**Value Range:** 0.25 to 0.45

**Value2 Range:** 0.15 to 0.35

**Rarity Weight:** 100

---

### VELOCITY STRIKER ASSEMBLY

**Mod ID:** 1049

**Type:** Type 4

**Description:** Rapid-strike blade system with val1% increased attack speed and val2% movement speed, but reduced damage per hit

**Equation:**
```
M_MELEESPEED = M_MELEESPEED val1 +; M_PLAYERSPEED = M_PLAYERSPEED val2 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.2 +
```

**Value Range:** 0.5 to 0.8

**Value2 Range:** 0.1 to 0.2

**Rarity Weight:** 80

---

### RETRIBUTION BLADE ARRAY

**Mod ID:** 1053

**Type:** Type 4

**Description:** Retaliatory blade system reflecting val1 thorns damage and generating val2 shield on melee kills, but reduces movement speed by 20% and attack speed by 15%

**Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE val1 +; B_SHIELDONKILL = B_SHIELDONKILL val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.2 +; M_MELEESPEED = M_MELEESPEED -0.15 +; M_MELEEDAMAGE = M_MELEEDAMAGE 0.4 +
```

**Value Range:** 35.0 to 55.0

**Value2 Range:** 15.0 to 35.0

**Rarity Weight:** 25

---

## Items

### STRUCTURAL REINFORCEMENT PROTOCOLS

**Mod ID:** 2002

**Type:** Weapon

**Description:** Combined defensive matrix increasing HP by val1% and armor by val2%, but reducing movement speed by 10%

**Equation:**
```
M_HP = M_HP val1 +; M_ARMOR = M_ARMOR val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +
```

**Value Range:** 0.1 to 0.25

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 180

---

### RETRIBUTION FRAMEWORK

**Mod ID:** 2006

**Type:** Weapon

**Description:** Retaliatory combat matrix inflicting val1 base thorns damage plus additional val2 damage per 100 maximum HP, with 30% reduced movement and sprint speed

**Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE val1 +; B_THORNDAMAGE = B_THORNDAMAGE T_HP val2 * 0.01 * +; M_PLAYERSPEED = M_PLAYERSPEED -0.15 +; M_SPRINTSPEED = M_SPRINTSPEED -0.3 +
```

**Value Range:** 20.0 to 50.0

**Value2 Range:** 2.0 to 6.0

**Rarity Weight:** 30

---

### FORTRESS DEVASTATOR CORE

**Mod ID:** 2007

**Type:** Weapon

**Description:** Experimental protocols granting val1% maximum HP increase and val2% HP-to-damage conversion, gaining 1% gun and melee damage per 50 maximum HP but reducing movement speed by 40% and fire rate by 35%

**Equation:**
```
B_MAXHPPERCENTBONUS = B_MAXHPPERCENTBONUS val1 +; M_GUNDAMAGE = M_GUNDAMAGE T_HP val2 * 0.02 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP val2 * 0.02 * +; M_PLAYERSPEED = M_PLAYERSPEED -0.4 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.35 +
```

**Value Range:** 0.6 to 1.2

**Value2 Range:** 0.8 to 1.5

**Rarity Weight:** 5

---

### KINETIC ACCELERATOR NANITES

**Mod ID:** 2008

**Type:** Weapon

**Description:** Locomotion enhancement nanites increase base movement speed by val1% through optimized actuator protocols

**Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +
```

**Value Range:** 0.15 to 0.3

**Rarity Weight:** 200

---

### SPRINT EFFICIENCY MATRIX

**Mod ID:** 2009

**Type:** Weapon

**Description:** Enhanced sprint calibration systems increasing sprint speed by val1% but reducing base movement by val2%

**Equation:**
```
M_SPRINTSPEED = M_SPRINTSPEED val1 +; M_PLAYERSPEED = M_PLAYERSPEED -val2 +
```

**Value Range:** 0.4 to 0.7

**Value2 Range:** 0.1 to 0.15

**Rarity Weight:** 180

---

### RAPID DISPLACEMENT ACCELERATOR

**Mod ID:** 2011

**Type:** Weapon

**Description:** Emergency evasion protocols reducing dash cooldown by val1 seconds and increasing dash velocity by val2%, with val2% reduced maximum structural integrity

**Equation:**
```
B_DASHCOOLDOWN = B_DASHCOOLDOWN -val1 +; M_DASHSPEED = M_DASHSPEED val2 +; M_HP = M_HP -val2 +
```

**Value Range:** 1.0 to 2.0

**Value2 Range:** 0.3 to 0.6

**Rarity Weight:** 70

---

### MOMENTUM CONVERSION MATRIX

**Mod ID:** 2012

**Type:** Weapon

**Description:** Kinetic energy recapture systems increasing movement speed by val1% and stamina regeneration by val2%, but reducing armor effectiveness by 30%

**Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +; M_STAMINAREGEN = M_STAMINAREGEN val2 +; M_ARMOR = M_ARMOR -0.3 +
```

**Value Range:** 0.25 to 0.45

**Value2 Range:** 0.4 to 0.8

**Rarity Weight:** 65

---

### VELOCITY DAMAGE AMPLIFIER

**Mod ID:** 2013

**Type:** Weapon

**Description:** Experimental kinetic conversion protocols granting val1% weapon damage per 100 movement speed possessed, and val2% dodge chance per 200 movement speed, but reducing base HP by 25%

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED 100 / val1 * +; B_DODGECHANCE = B_DODGECHANCE T_PLAYERSPEED 200 / val2 * +; M_HP = M_HP -0.25 +
```

**Value Range:** 0.08 to 0.15

**Value2 Range:** 0.03 to 0.06

**Rarity Weight:** 30

---

### UNSTABLE PROPULSION CORE

**Mod ID:** 2014

**Type:** Weapon

**Description:** Experimental overclocked locomotion system granting val1% movement speed and reducing dash cooldown by val2 seconds, but draining val1% maximum HP and disabling natural HP regeneration

**Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +; B_DASHCOOLDOWN = B_DASHCOOLDOWN -val2 +; M_HP = M_HP -val1 +; M_HPREGEN = M_HPREGEN -1.0 +
```

**Value Range:** 0.6 to 1.2

**Value2 Range:** 1.5 to 2.5

**Rarity Weight:** 4

---

### STAMINA RECOVERY PROTOCOLS

**Mod ID:** 2016

**Type:** Weapon

**Description:** Optimized energy reclamation systems accelerate stamina reconstitution, restoring val1 stamina points per second for continuous tactical mobility

**Equation:**
```
B_STAMINAREGEN = B_STAMINAREGEN val1 +
```

**Value Range:** 8.0 to 20.0

**Rarity Weight:** 180

---

### INTEGRATED SELF-REPAIR SYSTEM

**Mod ID:** 2017

**Type:** Weapon

**Description:** Dual-layer restoration protocols simultaneously reconstruct structural integrity (val1 HP/sec) and replenish energy reserves (val2 stamina/sec), but reduce maximum structural capacity by 10%

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; M_HP = M_HP -0.1 +
```

**Value Range:** 10.0 to 20.0

**Value2 Range:** 12.0 to 25.0

**Rarity Weight:** 70

---

### ADAPTIVE RESTORATION CORE

**Mod ID:** 2018

**Type:** Weapon

**Description:** Tri-spectrum regeneration matrix restoring structural integrity (val1 HP/sec), stamina (val2/sec), and energy barriers (25% shield regen rate), with 15% reduced damage output

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; M_SHIELDREGENRATE = M_SHIELDREGENRATE 0.25 +; M_GUNDAMAGE = M_GUNDAMAGE -0.15 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.15 +
```

**Value Range:** 8.0 to 15.0

**Value2 Range:** 10.0 to 20.0

**Rarity Weight:** 65

---

### PERCENTAGE-BASED RECONSTRUCTION FIELD

**Mod ID:** 2019

**Type:** Weapon

**Description:** Adaptive nanite protocols restore val1% of maximum structural integrity per second and val2% of max stamina per second, but reduce base armor effectiveness by 25%

**Equation:**
```
B_HPREGEN = B_HPREGEN T_HP val1 * 0.01 * +; B_STAMINAREGEN = B_STAMINAREGEN T_MAXSTAMINA val2 * 0.01 * +; M_ARMOR = M_ARMOR -0.25 +
```

**Value Range:** 1.5 to 3.0

**Value2 Range:** 2.0 to 4.0

**Rarity Weight:** 30

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

### ELEMENTAL ABSORPTION DEVASTATOR

**Mod ID:** 2034

**Type:** Weapon

**Description:** Experimental absorption core granting val1% resistance to all elements and converting absorbed elemental damage into gun and melee damage, gaining 1% damage per 50 resistance across all elements, with 30% reduced movement speed and 20% reduced fire rate

**Equation:**
```
M_FIRERESISTANCE = M_FIRERESISTANCE val1 +; M_ELECTRICRESISTANCE = M_ELECTRICRESISTANCE val1 +; M_CORRUPTIONRESISTANCE = M_CORRUPTIONRESISTANCE val1 +; M_GUNDAMAGE = M_GUNDAMAGE T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + 0.02 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + 0.02 * +; M_PLAYERSPEED = M_PLAYERSPEED -0.3 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.2 +
```

**Value Range:** 0.4 to 0.8

**Rarity Weight:** 10

---

### EFFICIENCY OPTIMIZATION PROTOCOL

**Mod ID:** 2039

**Type:** Weapon

**Description:** Advanced resource conservation algorithms reducing ability cooldowns by val1% and all resource costs by val2%, but decreasing movement speed by 15%

**Equation:**
```
B_COOLDOWNREDUCTION = B_COOLDOWNREDUCTION val1 +; B_RESOURCEEFFICIENCY = B_RESOURCEEFFICIENCY val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.15 +
```

**Value Range:** 0.2 to 0.4

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 70

---

### PREDICTIVE EVASION CORE

**Mod ID:** 2044

**Type:** Weapon

**Description:** Advanced threat assessment algorithms granting val1% probability of complete attack negation through predictive trajectory micro-adjustments

**Equation:**
```
B_DODGECHANCE = B_DODGECHANCE val1 +
```

**Value Range:** 0.15 to 0.3

**Rarity Weight:** 195

---

### DESPERATION PHASING PROTOCOL

**Mod ID:** 2048

**Type:** Weapon

**Description:** Emergency evasion systems granting val1% dodge chance per 10% HP lost below maximum, creating escalating evasion probability as structural damage accumulates (max +val2% dodge)

**Equation:**
```
B_DODGECHANCE = B_DODGECHANCE T_HP T_HP / (-1.0) + val1 * 10 * val2 MIN +
```

**Value Range:** 0.05 to 0.08

**Value2 Range:** 0.5 to 0.75

**Rarity Weight:** 35

---

## Syringes

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

### REINFORCED BATTLE PROTOCOLS

**Mod ID:** 3014

**Type:** Syringe

**Description:** Combined defensive matrix increasing structural integrity by val1% and armor by val2%, with 10% reduced movement speed due to reinforcement mass

**Equation:**
```
M_HP = M_HP val1 +; M_ARMOR = M_ARMOR val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +
```

**Value Range:** 0.15 to 0.3

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 75

---

### EVASIVE FORTIFICATION SERUM

**Mod ID:** 3016

**Type:** Syringe

**Description:** Dual-layer defense protocols granting val1% HP increase and val2% dodge chance through predictive evasion systems, with 15% reduced stamina reserves

**Equation:**
```
M_HP = M_HP val1 +; B_DODGECHANCE = B_DODGECHANCE val2 +; M_MAXSTAMINA = M_MAXSTAMINA -0.15 +
```

**Value Range:** 0.2 to 0.35

**Value2 Range:** 0.08 to 0.15

**Rarity Weight:** 65

---

### SHIELD OVERCHARGE MATRIX

**Mod ID:** 3018

**Type:** Syringe

**Description:** Prototype barrier protocols extending shield capacity limit by val1% and granting val2% shield capacity increase, with 25% reduced armor and 20% reduced movement speed

**Equation:**
```
U_SHIELDCAPACITY = U_SHIELDCAPACITY T_SHIELDCAPACITY val1 * +; M_SHIELDCAPACITY = M_SHIELDCAPACITY val2 +; M_ARMOR = M_ARMOR -0.25 +; M_PLAYERSPEED = M_PLAYERSPEED -0.2 +
```

**Value Range:** 0.3 to 0.6

**Value2 Range:** 0.5 to 1.0

**Rarity Weight:** 30

---

### ENDURANCE ENHANCEMENT SERUM

**Mod ID:** 3021

**Type:** Syringe

**Description:** Stamina optimization injection enhancing energy reclamation systems, restoring val1 stamina points per second for continuous tactical mobility and ability execution

**Equation:**
```
B_STAMINAREGEN = B_STAMINAREGEN val1 +
```

**Value Range:** 5.0 to 12.0

**Rarity Weight:** 190

---

### INTEGRATED RECOVERY MATRIX

**Mod ID:** 3025

**Type:** Syringe

**Description:** Dual-spectrum metabolic enhancer restoring val1 HP per second and val2 stamina per second, but reducing maximum structural integrity by 8% due to accelerated metabolic stress

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; M_HP = M_HP -0.08 +
```

**Value Range:** 6.0 to 12.0

**Value2 Range:** 8.0 to 16.0

**Rarity Weight:** 75

---

### ABILITY OPTIMIZATION COMPLEX

**Mod ID:** 3026

**Type:** Syringe

**Description:** Dual-system enhancer providing val1 energy per second and reducing cooldowns by val2%, but decreasing movement speed by 10% due to processing resource allocation

**Equation:**
```
B_ENERGYREGEN = B_ENERGYREGEN val1 +; B_COOLDOWNREDUCTION = B_COOLDOWNREDUCTION val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +
```

**Value Range:** 12.0 to 25.0

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 70

---

### PERPETUAL SUSTAIN INJECTION

**Mod ID:** 3027

**Type:** Syringe

**Description:** Tri-spectrum metabolic accelerator restoring val1 HP/sec, val2 stamina/sec, and 15 energy/sec, but reducing shield regeneration rate by 20% and armor effectiveness by 12%

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_STAMINAREGEN = B_STAMINAREGEN val2 +; B_ENERGYREGEN = B_ENERGYREGEN 15 +; M_SHIELDREGENRATE = M_SHIELDREGENRATE -0.2 +; M_ARMOR = M_ARMOR -0.12 +
```

**Value Range:** 5.0 to 10.0

**Value2 Range:** 6.0 to 12.0

**Rarity Weight:** 60

---

### ADAPTIVE METABOLIC AMPLIFIER

**Mod ID:** 3028

**Type:** Syringe

**Description:** Percentage-based regeneration matrix restoring val1% of max HP per second and val2% of max stamina per second, plus converting total regeneration into resource efficiency (1% efficiency per 10 combined regen), but reducing fire rate by 20%

**Equation:**
```
B_HPREGEN = B_HPREGEN T_HP val1 * 0.01 * +; B_STAMINAREGEN = B_STAMINAREGEN T_MAXSTAMINA val2 * 0.01 * +; B_RESOURCEEFFICIENCY = B_RESOURCEEFFICIENCY T_HPREGEN T_STAMINAREGEN + 10 / 0.01 * +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.2 +
```

**Value Range:** 1.2 to 2.5

**Value2 Range:** 1.5 to 3.0

**Rarity Weight:** 35

---

### ELEMENTAL CHAIN REACTION PROTOCOL

**Mod ID:** 3037

**Type:** Syringe

**Description:** Cascade amplification injection granting val1% increased elemental damage and val2% elemental chance per active elemental status effect on player, with 12% reduced movement speed

**Equation:**
```
M_IGNITEDAMAGE = M_IGNITEDAMAGE T_IGNITESTACKS val1 * +; M_CHARGEDAMAGE = M_CHARGEDAMAGE T_CHARGESTACKS val1 * +; B_CORRUPTIONDAMAGE = B_CORRUPTIONDAMAGE T_CORRUPTIONSTACKS val1 * +; M_IGNITECHANCE = M_IGNITECHANCE T_IGNITESTACKS val2 * +; M_CHARGECHANCE = M_CHARGECHANCE T_CHARGESTACKS val2 * +; B_CORRUPTIONCHANCE = B_CORRUPTIONCHANCE T_CORRUPTIONSTACKS val2 * +; M_PLAYERSPEED = M_PLAYERSPEED -0.12 +
```

**Value Range:** 0.03 to 0.06

**Value2 Range:** 0.02 to 0.04

**Rarity Weight:** 35

---

### OMNI-ELEMENTAL CONVERSION CORE

**Mod ID:** 3038

**Type:** Syringe

**Description:** Ultimate elemental transformation converting all weapon damage to elemental damage types, granting val1% ignite, charge, and corruption chance and converting 100% of gun/melee damage to elemental damage, with 25% reduced fire rate and 20% reduced movement speed

**Equation:**
```
M_IGNITECHANCE = M_IGNITECHANCE val1 +; M_CHARGECHANCE = M_CHARGECHANCE val1 +; B_CORRUPTIONCHANCE = B_CORRUPTIONCHANCE val1 +; M_IGNITEDAMAGE = M_IGNITEDAMAGE T_GUNDAMAGE T_MELEEDAMAGE + 1.0 * +; M_CHARGEDAMAGE = M_CHARGEDAMAGE T_GUNDAMAGE T_MELEEDAMAGE + 1.0 * +; B_CORRUPTIONDAMAGE = B_CORRUPTIONDAMAGE T_GUNDAMAGE T_MELEEDAMAGE + 1.0 * +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +; M_PLAYERSPEED = M_PLAYERSPEED -0.2 +
```

**Value Range:** 0.5 to 0.8

**Rarity Weight:** 10

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

### VELOCITY DAMAGE CONVERTER

**Mod ID:** 3049

**Type:** Syringe

**Description:** Ultimate mobility transformation converting movement speed into weapon damage, granting val1% gun and melee damage per 100 player speed, with 25% reduced base damage and 20% reduced HP

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED 0.01 * val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_PLAYERSPEED 0.01 * val1 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.25 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.25 +; M_HP = M_HP -0.2 +
```

**Value Range:** 0.015 to 0.025

**Rarity Weight:** 10

---
