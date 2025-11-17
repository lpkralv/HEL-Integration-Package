# Fortress Tank

**Total Mods:** 75 (Weapons: 17, Items: 35, Syringes: 23)

## Archetype Overview

**Identity:** Maximum survivability, thorns/reflect damage

**Core Stats:** HP 2000+, ARMOR 500+, RESISTANCES 70%+, THORNDAMAGE

**Fantasy:** Unkillable wall that punishes attackers

---

## Weapons

### ARMOR BREACH PROJECTOR

**Mod ID:** 1006

**Type:** Syringe

**Description:** Armor-penetrating projectile assembly with val1 piercing shots capability and val2% increased damage, but val2% slower reload speed

**Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_RELOADSPEED = M_RELOADSPEED -val2 +
```

**Value Range:** 2.0 to 5.0

**Value2 Range:** 0.25 to 0.5

**Rarity Weight:** 75

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

### DEFENSIVE CONSTRUCT PLATFORM

**Mod ID:** 1035

**Type:** Type 4

**Description:** Reinforced autonomous turret deployment system spawning val1 heavily-armored defensive constructs with val2% increased structural integrity, but reducing personal fire rate by 30%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONHP = M_MINIONHP val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.3 +
```

**Value Range:** 1.0 to 2.0

**Value2 Range:** 0.4 to 0.8

**Rarity Weight:** 180

---

### SCOUT DRONE ARRAY

**Mod ID:** 1036

**Type:** Type 4

**Description:** Lightweight multi-drone fabrication matrix deploying val1 fast-response scout constructs with val2% increased attack cycles, reducing personal structural integrity by 20%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_HP = M_HP -0.2 +
```

**Value Range:** 2.0 to 4.0

**Value2 Range:** 0.3 to 0.6

**Rarity Weight:** 190

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

### SYNCHRONIZED CONSTRUCT ARRAY

**Mod ID:** 1040

**Type:** Type 4

**Description:** Coordinated multi-unit deployment system spawning val1 tactical constructs with val2% balanced combat enhancement to all minion parameters, reducing player damage by 35% and HP by 15%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_MINIONHP = M_MINIONHP val2 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.35 +; M_HP = M_HP -0.15 +
```

**Value Range:** 2.0 to 4.0

**Value2 Range:** 0.25 to 0.45

**Rarity Weight:** 65

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

### AUTONOMOUS COMMAND MATRIX

**Mod ID:** 1042

**Type:** Type 4

**Description:** Hierarchical construct deployment system spawning val1 command-tier units that gain 1% to all stats per additional minion active on field, with val2% base damage increase but reducing player HP by 30% and player damage by 40%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 + T_NUMMINIONS 0.01 * +; M_MINIONHP = M_MINIONHP T_NUMMINIONS 0.01 * +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED T_NUMMINIONS 0.01 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.4 +; M_HP = M_HP -0.3 +
```

**Value Range:** 1.0 to 2.0

**Value2 Range:** 0.5 to 1.0

**Rarity Weight:** 30

---

### SELF-REPLICATING NANITE NEXUS

**Mod ID:** 1043

**Type:** Type 4

**Description:** Experimental self-sustaining fabrication core deploying val1 autonomous constructs that gain val2% damage per 10% HP player is missing, and gain 1% attack speed per 5 energy capacity, but reducing all player damage by 60% and player HP regen by 80%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE (T_HP S_HP /) 1 - val2 * 10 * + +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED T_ENERGYCAPACITY 5 / 0.01 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.6 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.6 +; M_HPREGEN = M_HPREGEN -0.8 +
```

**Value Range:** 2.0 to 4.0

**Value2 Range:** 1.2 to 2.0

**Rarity Weight:** 5

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

### OMNIPHASE DEVASTATOR

**Mod ID:** 1047

**Type:** Weapon

**Description:** EXPERIMENTAL: All-spectrum weapon platform combining ballistic, energy, and explosive systems simultaneously - fires val1 piercing projectiles with ignite/charge chance that explode on impact, but reduces max HP by 20% and caps fire rate at val2 shots per second

**Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; B_EXPLOSIONRADIUS = B_EXPLOSIONRADIUS 2.0 +; B_IGNITECHANCE = B_IGNITECHANCE 0.4 +; B_CHARGECHANCE = B_CHARGECHANCE 0.4 +; M_GUNDAMAGE = M_GUNDAMAGE 0.7 +; U_SHOTSPERSEC = U_SHOTSPERSEC val2 +; M_HP = M_HP -0.2 +; M_AMMOCAPACITY = M_AMMOCAPACITY -0.4 +; B_LIFESTEAL = B_LIFESTEAL 0.15 +
```

**Rarity Weight:** 100

---

### THERMAL EDGE PROJECTOR

**Mod ID:** 1051

**Type:** Type 4

**Description:** Superheated blade edge with val1 ignite chance on melee strikes, granting val2% lifesteal to survive close combat but reducing max HP by 10%

**Equation:**
```
B_IGNITECHANCE = B_IGNITECHANCE val1 +; B_LIFESTEAL = B_LIFESTEAL val2 +; M_HP = M_HP -0.1 +; M_MELEEDAMAGE = M_MELEEDAMAGE 0.3 +
```

**Value Range:** 0.45 to 0.65

**Value2 Range:** 0.1 to 0.2

**Rarity Weight:** 50

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

### REINFORCED NANITE SHELL

**Mod ID:** 2000

**Type:** Weapon

**Description:** Hardened nanite shell increasing maximum structural integrity by val1% through enhanced framework density

**Equation:**
```
M_HP = M_HP val1 +
```

**Value Range:** 0.15 to 0.35

**Rarity Weight:** 200

---

### ABLATIVE PLATING MATRIX

**Mod ID:** 2001

**Type:** Weapon

**Description:** Ablative armor layers increasing damage reduction by val1% through layered nanite dispersion protocols

**Equation:**
```
M_ARMOR = M_ARMOR val1 +
```

**Value Range:** 0.2 to 0.4

**Rarity Weight:** 190

---

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

### HARDPOINT ABSORPTION BARRIER

**Mod ID:** 2003

**Type:** Weapon

**Description:** Advanced barrier system granting val1% HP increase and val2 flat damage absorption per hit, with 15% reduced stamina capacity

**Equation:**
```
M_HP = M_HP val1 +; B_DAMAGEABSORPTION = B_DAMAGEABSORPTION val2 +; M_MAXSTAMINA = M_MAXSTAMINA -0.15 +
```

**Value Range:** 0.2 to 0.4

**Value2 Range:** 15.0 to 35.0

**Rarity Weight:** 75

---

### REACTIVE PLATING ASSEMBLY

**Mod ID:** 2004

**Type:** Weapon

**Description:** Reflective armor matrix increasing armor by val1% and reflecting val2% of received damage, with 20% reduced damage output

**Equation:**
```
M_ARMOR = M_ARMOR val1 +; B_REFLECTDAMAGE = B_REFLECTDAMAGE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.2 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.2 +
```

**Value Range:** 0.3 to 0.6

**Value2 Range:** 0.15 to 0.3

**Rarity Weight:** 70

---

### ADAPTIVE REGENERATION CORE

**Mod ID:** 2005

**Type:** Weapon

**Description:** Experimental regeneration protocols granting val1 HP regen per second, plus additional val2 regen per 100 armor possessed, with 25% reduced maximum stamina

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_HPREGEN = B_HPREGEN T_ARMOR val2 * 0.01 * +; M_MAXSTAMINA = M_MAXSTAMINA -0.25 +
```

**Value Range:** 3.0 to 8.0

**Value2 Range:** 0.5 to 1.5

**Rarity Weight:** 35

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

### NANITE RECONSTRUCTION MATRIX

**Mod ID:** 2015

**Type:** Weapon

**Description:** Automated repair protocols continuously reconstruct damaged framework nanites, restoring val1 structural integrity points per second during combat

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +
```

**Value Range:** 5.0 to 15.0

**Rarity Weight:** 200

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

### CRITICAL MASS REGENERATOR

**Mod ID:** 2020

**Type:** Weapon

**Description:** Emergency reconstruction protocols activate when structural integrity falls below 30%, providing val1 HP/sec regeneration and converting val2% of total regeneration into bonus damage output

**Equation:**
```
B_HPREGEN = B_HPREGEN T_HP T_HP 0.3 * < val1 * +; M_GUNDAMAGE = M_GUNDAMAGE T_HPREGEN val2 * 0.01 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HPREGEN val2 * 0.01 * +
```

**Value Range:** 80.0 to 150.0

**Value2 Range:** 3.0 to 6.0

**Rarity Weight:** 5

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

### OFFENSIVE OVERLOAD MATRIX

**Mod ID:** 2025

**Type:** Weapon

**Description:** Aggressive weapon calibration increasing gun damage by val1% and proc effectiveness by val2%, but reducing maximum structural integrity by 25% from power distribution compromises

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_PROCRATE = M_PROCRATE val2 +; M_HP = M_HP -0.25 +
```

**Value Range:** 0.3 to 0.5

**Value2 Range:** 0.4 to 0.7

**Rarity Weight:** 70

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

### BERSERKER SURGE CORE

**Mod ID:** 2027

**Type:** Weapon

**Description:** Desperation combat protocols converting structural damage into offensive fury, granting val1% gun and melee damage per 10% HP lost below maximum, with 20% reduced armor

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_HP T_HP / (-1.0) + val1 * 10 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP T_HP / (-1.0) + val1 * 10 * +; M_ARMOR = M_ARMOR -0.2 +
```

**Value Range:** 0.04 to 0.08

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

### THERMAL INSULATION MATRIX

**Mod ID:** 2029

**Type:** Weapon

**Description:** Thermal barrier nanites increasing fire damage resistance by val1% through heat dissipation protocols

**Equation:**
```
M_FIRERESISTANCE = M_FIRERESISTANCE val1 +
```

**Value Range:** 0.25 to 0.5

**Rarity Weight:** 195

---

### ELECTRIC INSULATION GRID

**Mod ID:** 2030

**Type:** Weapon

**Description:** Conductive shielding increasing electric damage resistance by val1% through charge redistribution matrices

**Equation:**
```
M_ELECTRICRESISTANCE = M_ELECTRICRESISTANCE val1 +
```

**Value Range:** 0.25 to 0.5

**Rarity Weight:** 195

---

### CORRUPTION BARRIER PROTOCOL

**Mod ID:** 2031

**Type:** Weapon

**Description:** Viral code resistance increasing corruption damage mitigation by val1% through firewall integrity systems

**Equation:**
```
M_CORRUPTIONRESISTANCE = M_CORRUPTIONRESISTANCE val1 +
```

**Value Range:** 0.25 to 0.5

**Rarity Weight:** 195

---

### TRI-ELEMENT RESISTANCE CORE

**Mod ID:** 2032

**Type:** Weapon

**Description:** Unified elemental barrier granting val1% fire, electric, and corruption resistance, but reducing maximum HP by 15%

**Equation:**
```
M_FIRERESISTANCE = M_FIRERESISTANCE val1 +; M_ELECTRICRESISTANCE = M_ELECTRICRESISTANCE val1 +; M_CORRUPTIONRESISTANCE = M_CORRUPTIONRESISTANCE val1 +; M_HP = M_HP -0.15 +
```

**Value Range:** 0.15 to 0.35

**Rarity Weight:** 80

---

### ELEMENTAL PENETRATION CONVERTER

**Mod ID:** 2033

**Type:** Weapon

**Description:** Experimental protocols converting elemental resistance into offensive penetration, gaining val1% elemental penetration per 100 combined resistance and val2% base penetration, with 25% reduced fire rate

**Equation:**
```
B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION val2 +; B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION T_FIRERESISTANCE T_ELECTRICRESISTANCE + T_CORRUPTIONRESISTANCE + val1 * 0.01 * +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +
```

**Value Range:** 0.005 to 0.015

**Value2 Range:** 0.05 to 0.15

**Rarity Weight:** 40

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

### TEMPORAL ACCELERATION MATRIX

**Mod ID:** 2041

**Type:** Weapon

**Description:** Experimental time-dilation protocols reducing ability cooldowns by val1% and converting cooldown efficiency into increased elemental proc rates, granting additional IGNITECHANCE and CHARGECHANCE equal to val2 times total cooldown reduction percentage, but reducing armor by 25%

**Equation:**
```
B_COOLDOWNREDUCTION = B_COOLDOWNREDUCTION val1 +; M_IGNITECHANCE = M_IGNITECHANCE T_COOLDOWNREDUCTION val2 * +; M_CHARGECHANCE = M_CHARGECHANCE T_COOLDOWNREDUCTION val2 * +; M_ARMOR = M_ARMOR -0.25 +
```

**Value Range:** 0.25 to 0.45

**Value2 Range:** 0.3 to 0.6

**Rarity Weight:** 30

---

### INFINITE ENERGY REACTOR

**Mod ID:** 2042

**Type:** Weapon

**Description:** Prototype perpetual motion reactor reducing all resource costs by val1%, granting val2 energy regeneration per second, and providing 50% cooldown reduction, but decreasing all damage output by 35% and reducing maximum HP by 20%

**Equation:**
```
B_RESOURCEEFFICIENCY = B_RESOURCEEFFICIENCY val1 +; B_ENERGYREGEN = B_ENERGYREGEN val2 +; B_COOLDOWNREDUCTION = B_COOLDOWNREDUCTION 0.5 +; M_GUNDAMAGE = M_GUNDAMAGE -0.35 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.35 +; M_HP = M_HP -0.2 +
```

**Value Range:** 0.7 to 0.9

**Value2 Range:** 40.0 to 80.0

**Rarity Weight:** 5

---

### REACTIVE PLATING ASSEMBLY

**Mod ID:** 2045

**Type:** Weapon

**Description:** Retaliatory defense protocols inflicting val1 structural damage on any attacker, channeling absorbed impact energy back through contact vectors

**Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE val1 +
```

**Value Range:** 50.0 to 100.0

**Rarity Weight:** 190

---

### FEEDBACK AMPLIFIER CORE

**Mod ID:** 2046

**Type:** Weapon

**Description:** Integrated counterattack systems dealing val1 thorns damage plus reflecting val2% of received damage back to attackers, but reducing max HP by 20% from power distribution strain

**Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE val1 +; B_REFLECTDAMAGE = B_REFLECTDAMAGE val2 +; M_HP = M_HP -0.2 +
```

**Value Range:** 100.0 to 200.0

**Value2 Range:** 0.2 to 0.4

**Rarity Weight:** 75

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

### ENTROPY INVERSION MATRIX

**Mod ID:** 2049

**Type:** Weapon

**Description:** Experimental reality-inversion protocols converting val1% of all received damage into structural restoration instead of degradation, but reducing max HP by 40%, armor by 50%, and disabling all shield systems (SHIELDCAPACITY reduced to 0)

**Equation:**
```
B_LIFESTEAL = B_LIFESTEAL val1 +; M_HP = M_HP -0.4 +; M_ARMOR = M_ARMOR -0.5 +; U_SHIELDCAPACITY = U_SHIELDCAPACITY -5000 +
```

**Value Range:** 0.3 to 0.6

**Rarity Weight:** 5

---

## Syringes

### AGGRESSIVE COMBAT PROTOCOL

**Mod ID:** 3005

**Type:** Syringe

**Description:** Dual-system injection increasing gun damage by val1% and fire rate by val2 shots per second, with 15% reduced armor from power distribution compromises

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; B_SHOTSPERSEC = B_SHOTSPERSEC val2 +; M_ARMOR = M_ARMOR -0.15 +
```

**Value Range:** 0.1 to 0.15

**Value2 Range:** 0.5 to 1.0

**Rarity Weight:** 80

---

### BERSERKER COMBAT STIMULANT

**Mod ID:** 3006

**Type:** Syringe

**Description:** Hybrid offensive injection increasing melee damage by val1% and attack speed by val2%, with 10% reduced maximum structural integrity

**Equation:**
```
M_MELEEDAMAGE = M_MELEEDAMAGE val1 +; M_MELEESPEED = M_MELEESPEED val2 +; M_HP = M_HP -0.1 +
```

**Value Range:** 0.1 to 0.15

**Value2 Range:** 0.1 to 0.15

**Rarity Weight:** 75

---

### ESCALATING FURY PROTOCOL

**Mod ID:** 3008

**Type:** Syringe

**Description:** Progressive combat enhancement granting val1% gun and melee damage per unique combat stimulant syringe active, with 15% reduced armor effectiveness

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_STACKS val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_STACKS val1 * +; M_ARMOR = M_ARMOR -0.15 +
```

**Value Range:** 0.03 to 0.05

**Rarity Weight:** 40

---

### PERMANENT BERSERKER MODE

**Mod ID:** 3009

**Type:** Syringe

**Description:** Experimental combat override granting val1% gun damage, val2% melee damage, and +val1 shots per second permanently, but reducing max HP by 30%, armor by 40%, and HP regeneration by 60%

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_MELEEDAMAGE = M_MELEEDAMAGE val2 +; B_SHOTSPERSEC = B_SHOTSPERSEC val1 +; M_HP = M_HP -0.3 +; M_ARMOR = M_ARMOR -0.4 +; M_HPREGEN = M_HPREGEN -0.6 +
```

**Value Range:** 0.2 to 0.3

**Value2 Range:** 0.25 to 0.35

**Rarity Weight:** 8

---

### STRUCTURAL FORTIFICATION SERUM

**Mod ID:** 3010

**Type:** Syringe

**Description:** Defensive protocol injection increasing maximum structural integrity by val1% through enhanced nanite framework density

**Equation:**
```
M_HP = M_HP val1 +
```

**Value Range:** 0.2 to 0.4

**Rarity Weight:** 200

---

### ABLATIVE ARMOR NANITES

**Mod ID:** 3011

**Type:** Syringe

**Description:** Protective nanite serum coating outer framework with ablative plating, increasing armor effectiveness by val1%

**Equation:**
```
M_ARMOR = M_ARMOR val1 +
```

**Value Range:** 0.25 to 0.45

**Rarity Weight:** 190

---

### ENERGY BARRIER AMPLIFIER

**Mod ID:** 3012

**Type:** Syringe

**Description:** Shield augmentation protocols expanding energy barrier capacity by val1% for enhanced protective layering

**Equation:**
```
M_SHIELDCAPACITY = M_SHIELDCAPACITY val1 +
```

**Value Range:** 0.3 to 0.6

**Rarity Weight:** 185

---

### IMPACT DISPERSAL INJECTION

**Mod ID:** 3013

**Type:** Syringe

**Description:** Defensive nanite layer providing val1 flat damage reduction per impact through kinetic energy dispersal

**Equation:**
```
B_DAMAGEABSORPTION = B_DAMAGEABSORPTION val1 +
```

**Value Range:** 10.0 to 25.0

**Rarity Weight:** 180

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

### ADAPTIVE SHIELD MATRIX

**Mod ID:** 3015

**Type:** Syringe

**Description:** Shield enhancement protocols increasing energy barrier capacity by val1% and regeneration rate by val2%, with 15% reduced damage output while barrier systems consume power

**Equation:**
```
M_SHIELDCAPACITY = M_SHIELDCAPACITY val1 +; M_SHIELDREGENRATE = M_SHIELDREGENRATE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.15 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.15 +
```

**Value Range:** 0.25 to 0.5

**Value2 Range:** 0.15 to 0.35

**Rarity Weight:** 70

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

### ADAPTIVE RESISTANCE PROTOCOLS

**Mod ID:** 3017

**Type:** Syringe

**Description:** Experimental defense nanites granting val1% base armor, plus additional val2% armor per 10% structural integrity lost, with 20% reduced HP regeneration efficiency

**Equation:**
```
M_ARMOR = M_ARMOR val1 +; M_ARMOR = M_ARMOR T_HP T_HP / 1 - val2 * +; M_HPREGEN = M_HPREGEN -0.2 +
```

**Value Range:** 0.2 to 0.4

**Value2 Range:** 0.03 to 0.06

**Rarity Weight:** 35

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

### CRITICAL THRESHOLD NANITES

**Mod ID:** 3019

**Type:** Syringe

**Description:** Emergency defense protocols activate when structural integrity falls below 20%, reducing all incoming damage by val1% through invulnerability threshold systems, with 35% reduced maximum HP and 30% reduced damage output

**Equation:**
```
B_DAMAGEABSORPTION = B_DAMAGEABSORPTION T_HP T_HP 0.2 * < val1 * +; M_HP = M_HP -0.35 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.3 +
```

**Value Range:** 0.8 to 0.95

**Rarity Weight:** 5

---

### REGENERATIVE NANITE INJECTION

**Mod ID:** 3020

**Type:** Syringe

**Description:** Metabolic enhancer serum accelerating nanite reconstruction protocols, restoring val1 structural integrity points per second through optimized repair cycles

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +
```

**Value Range:** 3.0 to 8.0

**Rarity Weight:** 200

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

### PERPETUAL MOTION REACTOR (PROTOTYPE)

**Mod ID:** 3029

**Type:** Syringe

**Description:** Experimental infinite-sustain reactor providing val1 HP/sec, val2 energy/sec, 80% resource cost reduction, and 45% cooldown reduction, but reducing all damage output by 30% and maximum HP by 15%

**Equation:**
```
B_HPREGEN = B_HPREGEN val1 +; B_ENERGYREGEN = B_ENERGYREGEN val2 +; B_RESOURCEEFFICIENCY = B_RESOURCEEFFICIENCY 0.8 +; B_COOLDOWNREDUCTION = B_COOLDOWNREDUCTION 0.45 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.3 +; M_HP = M_HP -0.15 +
```

**Value Range:** 30.0 to 60.0

**Value2 Range:** 35.0 to 70.0

**Rarity Weight:** 5

---

### ELEMENTAL PENETRATION INJECTOR

**Mod ID:** 3036

**Type:** Syringe

**Description:** Experimental barrier-bypass protocol granting val1% elemental penetration and val2% increased elemental proc chance across all elements, with 15% reduced armor

**Equation:**
```
B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION val1 +; M_IGNITECHANCE = M_IGNITECHANCE val2 +; M_CHARGECHANCE = M_CHARGECHANCE val2 +; B_CORRUPTIONCHANCE = B_CORRUPTIONCHANCE val2 +; M_ARMOR = M_ARMOR -0.15 +
```

**Value Range:** 0.15 to 0.25

**Value2 Range:** 0.08 to 0.12

**Rarity Weight:** 40

---

### BERSERKER RAGE PROTOCOL

**Mod ID:** 3047

**Type:** Syringe

**Description:** Experimental fury injection granting val1% gun damage and val2% melee damage when below 50% HP, with 15% reduced maximum HP

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE T_HP S_HP 0.5 * < val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP S_HP 0.5 * < val2 * +; M_HP = M_HP -0.15 +
```

**Value Range:** 0.4 to 0.7

**Value2 Range:** 0.5 to 0.8

**Rarity Weight:** 35

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

### ARMOR THORNS AMPLIFIER

**Mod ID:** 3050

**Type:** Syringe

**Description:** Ultimate defensive transformation converting armor into thorns damage, granting val1 thorns damage per point of armor and val2% increased armor, with 30% reduced gun damage and 25% reduced melee damage

**Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE T_ARMOR val1 * +; M_ARMOR = M_ARMOR val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.25 +
```

**Value Range:** 0.8 to 1.5

**Value2 Range:** 0.4 to 0.7

**Rarity Weight:** 10

---
