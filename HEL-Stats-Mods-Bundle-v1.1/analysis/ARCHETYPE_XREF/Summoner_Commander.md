# Summoner Commander

**Total Mods:** 10 (Weapons: 10, Items: 0, Syringes: 0)

## Archetype Overview

**Identity:** Minion army specialist

**Core Stats:** NUMMINIONS 5+, MINIONDAMAGE 200%+, MINIONHP 300+

**Fantasy:** Overwhelming swarm tactics

---

## Weapons

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
