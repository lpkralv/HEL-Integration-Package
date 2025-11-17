# Hybrid Berserker

**Total Mods:** 73 (Weapons: 39, Items: 16, Syringes: 18)

## Archetype Overview

**Identity:** Melee/ranged switching, lifesteal sustain

**Core Stats:** GUNDAMAGE 300+, MELEEDAMAGE 400+, LIFESTEAL 20%+, HP 400-600

**Fantasy:** Aggressive all-range combatant

---

## Weapons

### PLASMA DISCHARGE RIFLE

**Mod ID:** 516

**Type:** Syringe

**Description:** Fires superheated plasma packets with val1% increased damage but val2% reduced fire rate due to thermal cycling

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC -val2 +
```

**Value Range:** 0.25 to 0.45

**Value2 Range:** 0.08 to 0.15

**Rarity Weight:** 80

---

### DIRECTED ENERGY BEAM

**Mod ID:** 518

**Type:** Syringe

**Description:** Projects continuous energy beam dealing val1% increased damage but consuming val2 energy per second during sustained fire

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; B_ENERGYCAPACITY = B_ENERGYCAPACITY -50 +; M_ENERGYREGEN = M_ENERGYREGEN -val2 +
```

**Value Range:** 0.4 to 0.7

**Value2 Range:** 0.05 to 0.12

**Rarity Weight:** 65

---

### THERMAL LANCE EMITTER

**Mod ID:** 519

**Type:** Syringe

**Description:** Superheated beam with val1 ignite chance, causing fires to spread to val2 nearby targets within effective range

**Equation:**
```
B_IGNITECHANCE = B_IGNITECHANCE val1 +; B_IGNITESPREAD = B_IGNITESPREAD val2 +; M_GUNDAMAGE = M_GUNDAMAGE 0.2 +
```

**Value Range:** 0.35 to 0.55

**Value2 Range:** 2.0 to 5.0

**Rarity Weight:** 50

---

### PENETRATING BEAM PROJECTOR

**Mod ID:** 522

**Type:** Syringe

**Description:** Coherent beam pierces val1 enemies and ignores val2% of elemental resistances, dealing val2% more damage per enemy pierced

**Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; B_ELEMENTALPENETRATION = B_ELEMENTALPENETRATION val2 +; M_GUNDAMAGE = M_GUNDAMAGE T_PIERCINGSHOTS val2 0.1 * * +
```

**Value Range:** 3.0 to 6.0

**Value2 Range:** 0.25 to 0.45

**Rarity Weight:** 25

---

### STORM CALLER ARRAY

**Mod ID:** 523

**Type:** Syringe

**Description:** Cascading lightning emission chains to val1 targets with val2 charge chance, consuming 0.15 energy per chain event

**Equation:**
```
B_CHAINLIGHTNING = B_CHAINLIGHTNING val1 +; B_CHARGECHANCE = B_CHARGECHANCE val2 +; B_ENERGYCAPACITY = B_ENERGYCAPACITY -30 +; M_GUNDAMAGE = M_GUNDAMAGE 0.15 +
```

**Value Range:** 5.0 to 8.0

**Value2 Range:** 0.45 to 0.7

**Rarity Weight:** 20

---

### CHROMATIC MATRIX CONVERTER

**Mod ID:** 524

**Type:** Syringe

**Description:** Experimental system converts all damage to thermal energy with fixed val1 ignite chance, spreading to val2 targets but consuming massive energy reserves

**Equation:**
```
B_IGNITECHANCE = B_IGNITECHANCE val1 +; B_IGNITESPREAD = B_IGNITESPREAD val2 +; M_GUNDAMAGE = M_GUNDAMAGE 0.5 +; B_ENERGYCAPACITY = B_ENERGYCAPACITY -80 +; M_ENERGYREGEN = M_ENERGYREGEN -0.25 +
```

**Value Range:** 0.8 to 0.8

**Value2 Range:** 5.0 to 5.0

**Rarity Weight:** 8

---

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

### RAPID CYCLE PROJECTOR

**Mod ID:** 1001

**Type:** Syringe

**Description:** High-frequency projectile assembly optimized for rapid ammunition cycling, firing val1 additional shots per second but reducing per-shot damage by val2%

**Equation:**
```
B_SHOTSPERSEC = B_SHOTSPERSEC val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +
```

**Value Range:** 3.0 to 7.0

**Value2 Range:** 0.2 to 0.4

**Rarity Weight:** 150

---

### BURST PROTOCOL MATRIX

**Mod ID:** 1004

**Type:** Syringe

**Description:** Synchronized firing sequence releasing val1-round bursts with val2% increased damage per shot, requiring longer recalibration between bursts

**Equation:**
```
B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +
```

**Value Range:** 2.0 to 4.0

**Value2 Range:** 0.15 to 0.35

**Rarity Weight:** 170

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

### SUSTAINED BARRAGE PLATFORM

**Mod ID:** 1008

**Type:** Syringe

**Description:** High-capacity ammunition matrix increasing magazine size by val1% and reload speed by val2%, but decreasing damage per shot by 25%

**Equation:**
```
M_AMMOCAPACITY = M_AMMOCAPACITY val1 +; M_RELOADSPEED = M_RELOADSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.25 +
```

**Value Range:** 0.5 to 1.0

**Value2 Range:** 0.3 to 0.6

**Rarity Weight:** 70

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

### FRAGMENTATION PROJECTOR ARRAY

**Mod ID:** 1011

**Type:** Syringe

**Description:** Unstable projectile matrix causing shots to pierce val1 enemies and split into val2 additional projectiles on hit, with 30% damage reduction

**Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS val1 +; B_BULLETSFIRED = B_BULLETSFIRED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +
```

**Value Range:** 3.0 to 6.0

**Value2 Range:** 2.0 to 4.0

**Rarity Weight:** 30

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

### NANITE RECYCLER DEVASTATOR

**Mod ID:** 1014

**Type:** Syringe

**Description:** Experimental ammunition reclamation system granting val1% lifesteal and reducing reload time by val2%, with damage scaling based on current magazine percentage (gain 1% damage per 10% magazine remaining)

**Equation:**
```
B_LIFESTEAL = B_LIFESTEAL val1 +; M_RELOADSPEED = M_RELOADSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE T_AMMOCAPACITY 10 / 0.01 * +
```

**Value Range:** 0.15 to 0.3

**Value2 Range:** 0.4 to 0.8

**Rarity Weight:** 4

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

### BASIC COMBAT DRONE ASSEMBLY

**Mod ID:** 1034

**Type:** Type 4

**Description:** Fundamental autonomous combat drone fabricator deploying val1 tactical constructs with balanced combat parameters, reducing personal weapon damage by val2%

**Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +
```

**Value Range:** 1.0 to 3.0

**Value2 Range:** 0.15 to 0.25

**Rarity Weight:** 200

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

### TRI-PHASE EMITTER ARRAY

**Mod ID:** 1045

**Type:** Weapon

**Description:** Reconfigurable weapon platform cycling between ballistic (piercing), energy (elemental), and explosive (AoE) phases based on shots fired - every val1 shots triggers phase rotation with corresponding bonuses

**Equation:**
```
B_PIERCINGSHOTS = B_PIERCINGSHOTS 2 +; B_IGNITECHANCE = B_IGNITECHANCE 0.3 +; B_EXPLOSIONRADIUS = B_EXPLOSIONRADIUS 1.5 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.25 +; M_RELOADSPEED = M_RELOADSPEED -0.3 +
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

### IMPACT EDGE CONSTRUCT

**Mod ID:** 1050

**Type:** Type 4

**Description:** Heavy molecular blade dealing val1% increased melee damage but reduces attack speed by val2% due to mass recalibration cycles

**Equation:**
```
M_MELEEDAMAGE = M_MELEEDAMAGE val1 +; M_MELEESPEED = M_MELEESPEED -val2 +
```

**Value Range:** 0.6 to 1.0

**Value2 Range:** 0.25 to 0.45

**Rarity Weight:** 75

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

### VAMPIRIC STRIKE MATRIX

**Mod ID:** 1052

**Type:** Type 4

**Description:** Life-draining blade system granting val1% lifesteal on melee hits and val2% increased attack speed, but reduces gun damage by 40% to force melee commitment

**Equation:**
```
B_LIFESTEAL = B_LIFESTEAL val1 +; M_MELEESPEED = M_MELEESPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.4 +; M_MELEEDAMAGE = M_MELEEDAMAGE 0.35 +
```

**Value Range:** 0.35 to 0.55

**Value2 Range:** 0.15 to 0.35

**Rarity Weight:** 45

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

### DAMAGE AMPLIFIER CORE

**Mod ID:** 2022

**Type:** Weapon

**Description:** Weapon output optimization protocols increasing projectile damage by val1% through enhanced energy conversion efficiency

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +
```

**Value Range:** 0.2 to 0.4

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

### ENERGY CONVERSION AMPLIFIER

**Mod ID:** 2040

**Type:** Weapon

**Description:** Experimental power routing system granting val1 base energy capacity and converting current energy reserves into weapon damage, gaining val2% gun and melee damage per 100 energy capacity, but reducing fire rate by 30%

**Equation:**
```
B_ENERGYCAPACITY = B_ENERGYCAPACITY val1 +; M_GUNDAMAGE = M_GUNDAMAGE T_ENERGYCAPACITY val2 * 0.001 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_ENERGYCAPACITY val2 * 0.001 * +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.3 +
```

**Value Range:** 100.0 to 200.0

**Value2 Range:** 0.8 to 1.5

**Rarity Weight:** 35

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

### NANITE RECYCLER MATRIX

**Mod ID:** 2043

**Type:** Weapon

**Description:** Combat nanite extraction protocols converting val1% of inflicted structural damage into self-repair sequences, restoring your framework integrity through enemy destruction

**Equation:**
```
B_LIFESTEAL = B_LIFESTEAL val1 +
```

**Value Range:** 0.15 to 0.3

**Rarity Weight:** 200

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

### DAMAGE ENHANCEMENT SERUM

**Mod ID:** 3000

**Type:** Syringe

**Description:** Offensive protocol injection increasing projectile damage output by val1% through weapon emitter optimization nanites

**Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +
```

**Value Range:** 0.08 to 0.12

**Rarity Weight:** 200

---

### MELEE ACCELERATION INJECTION

**Mod ID:** 3002

**Type:** Syringe

**Description:** Combat reflex enhancement increasing melee attack execution speed by val1% through motor protocol optimization

**Equation:**
```
M_MELEESPEED = M_MELEESPEED val1 +
```

**Value Range:** 0.1 to 0.15

**Rarity Weight:** 190

---

### MELEE POWER INJECTION

**Mod ID:** 3004

**Type:** Syringe

**Description:** Combat enhancement injection increasing melee strike damage by val1% through kinetic amplification protocols

**Equation:**
```
M_MELEEDAMAGE = M_MELEEDAMAGE val1 +
```

**Value Range:** 0.08 to 0.12

**Rarity Weight:** 190

---

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

### DUAL-ELEMENT FUSION PROTOCOL

**Mod ID:** 3034

**Type:** Syringe

**Description:** Experimental dual-element injection granting val1% ignite chance and val2% charge chance, with 8% reduced gun damage

**Equation:**
```
M_IGNITECHANCE = M_IGNITECHANCE val1 +; M_CHARGECHANCE = M_CHARGECHANCE val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.08 +
```

**Value Range:** 0.12 to 0.18

**Value2 Range:** 0.12 to 0.18

**Rarity Weight:** 90

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
