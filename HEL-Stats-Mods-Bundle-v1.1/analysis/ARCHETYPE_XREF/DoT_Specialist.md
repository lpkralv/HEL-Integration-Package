# DoT Specialist

**Total Mods:** 26 (Weapons: 16, Items: 3, Syringes: 7)

## Archetype Overview

**Identity:** Area denial, proc chains, status spreading

**Core Stats:** PROCRATE high, PROCRANGE 300+, elemental damage 200+

**Fantasy:** Battlefield controller

---

## Weapons

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

### ARC DISCHARGE ARRAY

**Mod ID:** 520

**Type:** Syringe

**Description:** Electrical discharge with val1 charge chance that chains to val2 additional targets, dealing reduced damage per chain

**Equation:**
```
B_CHARGECHANCE = B_CHARGECHANCE val1 +; B_CHAINLIGHTNING = B_CHAINLIGHTNING val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.15 +
```

**Value Range:** 0.3 to 0.5

**Value2 Range:** 3.0 to 6.0

**Rarity Weight:** 45

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

## Items

### PROC ENHANCEMENT PROTOCOLS

**Mod ID:** 2023

**Type:** Weapon

**Description:** Optimized effect amplification systems increasing proc trigger frequency by val1% for enhanced status effect application rates

**Equation:**
```
M_PROCRATE = M_PROCRATE val1 +
```

**Value Range:** 0.25 to 0.5

**Rarity Weight:** 190

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

## Syringes

### THERMAL IGNITION SERUM

**Mod ID:** 3030

**Type:** Syringe

**Description:** Thermal dispersion protocol increasing ignite application chance by val1% through heat-signature targeting nanites

**Equation:**
```
M_IGNITECHANCE = M_IGNITECHANCE val1 +
```

**Value Range:** 0.06 to 0.1

**Rarity Weight:** 200

---

### ELECTRIC DISCHARGE SERUM

**Mod ID:** 3031

**Type:** Syringe

**Description:** Electrical capacitor protocol increasing charge application chance by val1% through static buildup acceleration nanites

**Equation:**
```
M_CHARGECHANCE = M_CHARGECHANCE val1 +
```

**Value Range:** 0.06 to 0.1

**Rarity Weight:** 200

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
