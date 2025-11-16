# HIOX Stats/Mods System Architecture

**Version:** 1.0
**Status:** PRIMARY DESIGN DOCUMENT
**Target:** ~150 total mods, 25-35 new stats, 5-8 build archetypes

---

## TABLE OF CONTENTS

1. [Mod Class System](#1-mod-class-system)
2. [Rarity/Tier System](#2-raritytier-system)
3. [Stat Categories](#3-stat-categories)
4. [Build Archetypes](#4-build-archetypes)
5. [Mod Distribution Strategy](#5-mod-distribution-strategy)
6. [Lore Integration](#6-lore-integration)
7. [Coordination Framework](#7-coordination-framework)

---

## 1. MOD CLASS SYSTEM

### 1.1 Weapon Classes (~50 mods total)

**Type Code:** `2` (weapons), `4` (melee)
**ID Ranges:** 500-599 (ranged), 700-799 (extended ranged), 800-899 (melee)

| Weapon Class | Count | ID Range | Distinguishing Characteristics |
|--------------|-------|----------|-------------------------------|
| **Ballistic Assemblies** | 15 | 500-514 | Projectile weapons, high fire rate, physical damage, accuracy-dependent |
| **Energy Emitters** | 10 | 515-524 | Beam/pulse weapons, energy-based damage, heat mechanics, precision |
| **Explosive Constructs** | 8 | 525-532 | Area damage, radius effects, self-damage risk, slow fire rate |
| **Tactical Deployables** | 10 | 533-542 | Minion spawners, turrets, drones, indirect damage |
| **Hybrid Systems** | 4 | 700-703 | Multi-mode weapons, adaptive damage types, versatile |
| **Melee Matrices** | 7 | 800-806 | Close-range, high damage, attack speed variations, range-limited |

**Weapon Class Details:**

- **Ballistic Assemblies**: Rifles, SMGs, shotguns, pistols
  - High SHOTSPERSEC, moderate GUNDAMAGE
  - Affected by ACCURACY, BULLETSFIRED, PROJECTILESPEED
  - Examples: Assault Matrix, Precision Rifle, Scatter Cannon

- **Energy Emitters**: Lasers, plasma, charged beams
  - Continuous or burst damage, CHARGECHANCE synergies
  - Often trade damage for elemental effects
  - Examples: Beam Projector, Plasma Discharger, Arc Emitter

- **Explosive Constructs**: Grenades, rockets, mines
  - Large EXPLOSIONRADIUS, high base damage
  - Self-damage mechanics, slow fire rate
  - Examples: Fragmentation Launcher, Nanite Mines, Cluster Missiles

- **Tactical Deployables**: Summon-based weapons
  - Use NUMMINIONS, MINIONTYPE stats
  - Indirect combat, positioning-based
  - Examples: Drone Beacon, Turret Deployer, Swarm Catalyst

- **Hybrid Systems**: Adaptive multi-function
  - Switch between damage types or modes
  - Complex equations with conditionals
  - Examples: Adaptive Array, Dual-Mode Projector

- **Melee Matrices**: Close-combat nanite constructs
  - MELEEDAMAGE, MELEERANGE, MELEESPEED
  - Often synergize with movement stats
  - Examples: Nano-Blade, Impact Gauntlet, Whip Array

---

### 1.2 Item Classes (~50 mods total)

**Type Code:** `0` (passive modifiers)
**ID Range:** 0-499

| Item Class | Count | ID Range | Provides |
|------------|-------|----------|----------|
| **Structural Plating** | 8 | 0-7 | HP, ARMOR, physical defense, damage absorption |
| **Mobility Modules** | 7 | 8-14 | PLAYERSPEED, SPRINTSPEED, JUMPSTRENGTH, dash mechanics |
| **Regeneration Systems** | 6 | 15-20 | HPREGEN, STAMINAREGEN, passive recovery |
| **Offensive Augments** | 8 | 21-28 | CRITCHANCE, CRITDAMAGE, PROCRATE, damage amplification |
| **Resistance Arrays** | 6 | 29-34 | FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE |
| **Resource Controllers** | 8 | 35-42 | Energy capacity, cooldown reduction, stamina efficiency |
| **Tactical Processors** | 7 | 43-49 | Range, accuracy, special mechanics (thorns, lifesteal, reflect) |

**Item Class Details:**

- **Structural Plating**: Defensive core mods
  - Boost HP via B_HP or M_HP
  - Add ARMOR, SHIELDCAPACITY
  - Often use Z_/U_ to extend stat caps
  - Trade-off: Reduce speed/damage for survivability

- **Mobility Modules**: Movement-focused
  - PLAYERSPEED, SPRINTSPEED increases
  - DASHCOOLDOWN, DASHSPEED additions
  - Enable hit-and-run, kiting builds
  - Trade-off: Lower defense stats

- **Regeneration Systems**: Sustain mods
  - HPREGEN, STAMINAREGEN flat or percentage
  - Conditional regen (while moving, stationary, etc.)
  - Synergize with tank builds

- **Offensive Augments**: Damage amplifiers
  - CRITCHANCE, CRITDAMAGE boosts
  - PROCRATE increases, proc synergies
  - Cross-stat dependencies (damage = % of HP)
  - Trade-off: Glass cannon penalties

- **Resistance Arrays**: Elemental defense
  - FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE
  - Enable elemental tank builds
  - Counter specific enemy types

- **Resource Controllers**: Economy stats
  - ENERGYCAPACITY, ENERGYREGEN
  - COOLDOWNREDUCTION for abilities
  - STAMINA management

- **Tactical Processors**: Special mechanics
  - LIFESTEAL, THORNDAMAGE, REFLECTDAMAGE
  - AREADAMAGE, PIERCINGSHOTS
  - Unique build-enabling effects

---

### 1.3 Syringe Classes (~50 mods total)

**Type Code:** `10` (upgrade nanites)
**ID Range:** 5000-5999

| Syringe Class | Count | ID Range | Effects |
|---------------|-------|----------|---------|
| **Combat Stimulants** | 8 | 5000-5007 | Damage, attack speed, fire rate, burst power |
| **Defensive Protocols** | 8 | 5008-5015 | HP, armor, resistances, shields |
| **Metabolic Enhancers** | 7 | 5016-5022 | Regeneration, stamina, resource efficiency |
| **Elemental Infusions** | 9 | 5023-5031 | Ignite, charge, corruption chance/damage |
| **Tactical Injections** | 8 | 5032-5039 | Accuracy, range, speed, projectile mods |
| **Minion Protocols** | 6 | 5040-5045 | Minion stats, summon capacity, minion synergies |
| **Exotic Formulas** | 4 | 5046-5049 | Unique mechanics, build-transforming effects |

**Syringe Class Details:**

- **Combat Stimulants**: Pure offensive buffs
  - Increase GUNDAMAGE, MELEEDAMAGE
  - Boost SHOTSPERSEC, MELEESPEED
  - Typically no trade-offs (upgrade nanites = pure buffs)

- **Defensive Protocols**: Pure defensive buffs
  - Increase HP, ARMOR
  - Add resistance percentages
  - Boost SHIELDCAPACITY, SHIELDREGENRATE

- **Metabolic Enhancers**: Sustain and efficiency
  - HPREGEN, STAMINAREGEN increases
  - ENERGYREGEN boosts
  - Resource cost reductions

- **Elemental Infusions**: Add elemental damage
  - IGNITECHANCE, IGNITEDAMAGE
  - CHARGECHANCE, CHARGEDAMAGE
  - CORRUPTIONCHANCE, CORRUPTIONDAMAGE
  - Enable elemental specialist builds

- **Tactical Injections**: Precision and control
  - ACCURACY improvements
  - RANGE extensions (PROCRANGE, MELEERANGE)
  - PROJECTILESPEED, BULLETSFIRED

- **Minion Protocols**: Summoner enhancements
  - NUMMINIONS capacity increases
  - MINIONDAMAGE, MINIONHP scaling
  - MINIONATTACKSPEED, MINIONLIFESTEAL

- **Exotic Formulas**: Build-enabling mechanics
  - Conditional effects (damage when low HP)
  - Cross-stat conversions (armor = % of speed)
  - Unique proc mechanics (RAND-based)

---

## 2. RARITY/TIER SYSTEM

### 2.1 Rarity Tiers (PoE-Inspired, Nanite-Themed)

| Rarity | Nanite Name | Mod Count | Power Level | modweight Range | Visual Indicator |
|--------|-------------|-----------|-------------|-----------------|------------------|
| **Normal** | Standard Configuration | 1 effect | Low (val1: 0.1-0.3) | 100-600 | White/Gray |
| **Magic** | Enhanced Protocol | 2 effects | Moderate (val1: 0.3-0.6) | 50-100 | Blue |
| **Rare** | Advanced Matrix | 4-6 effects | High (val1: 0.6-1.2) | 10-50 | Yellow/Gold |
| **Unique** | Prototype Assembly | Fixed 3-5 effects | Build-Defining | 3-5 | Orange/Exotic |

### 2.2 Tier Characteristics

**Standard Configuration (Normal):**
- Single stat modification
- Clean, straightforward effect
- Common drops (modweight: 100-600)
- Example: "+0.2 to M_GUNDAMAGE" (Standard Combat Stimulant)

**Enhanced Protocol (Magic):**
- Two complementary effects
- Often includes minor trade-off
- Uncommon drops (modweight: 50-100)
- Example: "+0.4 to M_GUNDAMAGE, -0.1 to M_HP" (Enhanced Offensive Augment)

**Advanced Matrix (Rare):**
- 4-6 synergistic effects
- Complex equations with conditionals
- Rare drops (modweight: 10-50)
- Example: "+0.8 M_GUNDAMAGE, +0.3 M_CRITCHANCE, +50 B_HP, -0.2 M_PLAYERSPEED" (Advanced Hybrid System)

**Prototype Assembly (Unique):**
- Fixed, build-defining mechanics
- Cannot be randomly rolled (modweight: 3-5, controlled drops)
- Named items with lore
- Example: "CORE OVERDRIVER" - "Gain M_GUNDAMAGE = T_HP 100 / (damage scales with missing HP)"

### 2.3 Tier-to-Type Mapping

| Mod Type | Rarity Distribution |
|----------|---------------------|
| 0 (Passive Items) | All rarities, mostly Magic/Rare for trade-offs |
| 2/4 (Weapons) | Mostly Enhanced/Advanced, few Unique |
| 10 (Upgrade Syringes) | Mostly Standard/Enhanced (pure buffs) |
| 20 (Permanent) | N/A (progression system, not rarity-based) |

### 2.4 Progression Access

- **Early Game (Beacon Tier 1-2)**: Standard + occasional Enhanced
- **Mid Game (Beacon Tier 3-4)**: Enhanced + occasional Advanced
- **Late Game (Beacon Tier 5+)**: Advanced + Unique boss/challenge drops
- **Endgame**: Crafting system to upgrade Standard → Enhanced → Advanced

---

## 3. STAT CATEGORIES

### 3.1 Required New Stats (25-35 total)

**Current Stats:** 38 (see Essentials-Gaps.md)
**New Stats Needed:** 27 (total: 65 stats)

### 3.2 Core Combat Stats (8 new)

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **CRITCHANCE** | Chance to deal critical hit | 0.05 | 0 | 1 | Glass cannon builds |
| **CRITDAMAGE** | Critical hit damage multiplier | 1.5 | 0 | 5000 | Crit-focused builds |
| **PROJECTILESPEED** | Speed of fired projectiles | 300 | 0 | 5000 | Range/accuracy synergy |
| **PIERCINGSHOTS** | Number of enemies pierced | 0 | 0 | 50 | Area control |
| **BULLETSFIRED** | Projectiles per shot (existing but underused) | 1 | 0 | 100 | Multi-shot builds |
| **RELOADSPEED** | Reload time modifier | 1.0 | 0 | 5000 | Ballistic weapon synergy |
| **AMMOCAPACITY** | Magazine size | 30 | 0 | 5000 | Sustained fire builds |
| **LIFESTEAL** | Damage converted to HP | 0 | 0 | 1 | Sustain builds |

### 3.3 Defense/Survival Stats (7 new)

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **SHIELDCAPACITY** | Maximum shield points | 0 | 0 | 5000 | Shield-based tank |
| **SHIELDREGENRATE** | Shield regeneration per second | 0 | 0 | 5000 | Shield sustain |
| **DODGECHANCE** | Chance to evade attacks | 0 | 0 | 1 | Evasion tank |
| **DAMAGEABSORPTION** | Flat damage reduction | 0 | 0 | 5000 | Tank builds |
| **THORNDAMAGE** | Damage reflected to attackers | 0 | 0 | 5000 | Thorns tank |
| **REFLECTDAMAGE** | Percentage damage reflection | 0 | 0 | 1 | Reflect builds |
| **MAXHPPERCENTBONUS** | % increase to HP cap (uses U_HP) | 0 | 0 | 10 | HP scaling |

### 3.4 Resource Management Stats (5 new)

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **ENERGYCAPACITY** | Maximum energy pool | 100 | 0 | 5000 | Ability-heavy builds |
| **ENERGYREGEN** | Energy regeneration per second | 10 | 0 | 5000 | Energy economy |
| **COOLDOWNREDUCTION** | Ability cooldown modifier | 0 | 0 | 1 | Spam builds (0.5 = 50% CDR) |
| **STAMINAREGEN** | Stamina regen rate (existing but expand) | 0.5 | 0 | 5000 | Mobility sustain |
| **RESOURCEEFFICIENCY** | Cost reduction modifier | 0 | 0 | 1 | Economy builds |

### 3.5 Elemental Stats (Expand Existing + 4 new)

**Existing:** IGNITECHANCE, IGNITEDAMAGE, CHARGECHANCE, CHARGEDAMAGE, FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **CORRUPTIONCHANCE** | Chance to apply corruption DoT | 0 | 0 | 1 | Corruption builds |
| **CORRUPTIONDAMAGE** | Corruption damage per tick | 0 | 0 | 5000 | DoT specialist |
| **ELEMENTALPENETRATION** | Ignore % of resistance | 0 | 0 | 1 | Counter resistance |
| **IGNITESPREAD** | Ignite chains to nearby enemies | 0 | 0 | 10 | AoE elemental |

### 3.6 Minion/Summoner Stats (Expand Existing + 3 new)

**Existing:** NUMMINIONS, MINIONTYPE

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **MINIONDAMAGE** | Minion damage multiplier | 1.0 | 0 | 5000 | Summoner builds |
| **MINIONHP** | Minion health multiplier | 1.0 | 0 | 5000 | Minion survivability |
| **MINIONATTACKSPEED** | Minion attack speed multiplier | 1.0 | 0 | 5000 | Minion DPS |

### 3.7 Movement Stats (Expand Existing + 2 new)

**Existing:** PLAYERSPEED, SPRINTSPEED, JUMPSTRENGTH

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **DASHCOOLDOWN** | Dash ability cooldown | 3.0 | 0 | 100 | Mobility builds |
| **DASHSPEED** | Dash velocity multiplier | 1.0 | 0 | 5000 | Evasion/positioning |

### 3.8 Special Mechanics Stats (Existing + Expand)

**Existing:** PROCRATE, PROCRANGE, EXPLOSIONRADIUS, AUTOTURRETON, BULLETSPLIT

| Stat Name | Description | Default | Min | Max | Purpose |
|-----------|-------------|---------|-----|-----|---------|
| **AREADAMAGE** | Area damage multiplier | 1.0 | 0 | 5000 | AoE builds |
| **CHAINLIGHTNING** | Lightning chains to N enemies | 0 | 0 | 20 | Chain builds |
| **LUCKFACTOR** | Affects random roll outcomes | 0 | 0 | 1 | RNG manipulation |

---

## 4. BUILD ARCHETYPES

### 4.1 Archetype Overview

| Archetype | Core Stats | Weapon Classes | Item Classes | Syringe Classes | Playstyle |
|-----------|------------|----------------|--------------|-----------------|-----------|
| **Fortress Tank** | HP, ARMOR, Resistances, THORNDAMAGE | Melee Matrices, Explosive Constructs | Structural Plating, Resistance Arrays | Defensive Protocols, Exotic Formulas | Face-tank, reflect damage, extreme survivability |
| **Glass Cannon** | CRITCHANCE, CRITDAMAGE, GUNDAMAGE | Ballistic Assemblies, Energy Emitters | Offensive Augments, Tactical Processors | Combat Stimulants, Tactical Injections | High burst, low defense, positioning-critical |
| **Elemental Savant** | Elemental chances/damage, ELEMENTALPENETRATION | Energy Emitters, Explosive Constructs | Resistance Arrays (offense), Offensive Augments | Elemental Infusions | Ignite chains, shock stacks, corruption DoT |
| **Summoner Commander** | NUMMINIONS, MINIONDAMAGE, MINIONHP | Tactical Deployables | Resource Controllers, Tactical Processors | Minion Protocols, Metabolic Enhancers | Indirect combat, minion army |
| **Speed Demon** | PLAYERSPEED, DASHSPEED, ATTACKSPEED | Ballistic Assemblies (SMG-type), Melee Matrices | Mobility Modules, Resource Controllers | Tactical Injections, Metabolic Enhancers | Hit-and-run, kiting, evasion |
| **Hybrid Berserker** | MELEEDAMAGE, GUNDAMAGE, LIFESTEAL | Hybrid Systems, Melee + Ballistic | Offensive Augments, Regeneration Systems | Combat Stimulants, Exotic Formulas | Switch between melee/ranged, aggressive sustain |
| **DoT Specialist** | PROCRATE, CORRUPTIONDAMAGE, AREADAMAGE | Explosive Constructs, Energy Emitters | Offensive Augments, Tactical Processors | Elemental Infusions, Combat Stimulants | Area denial, damage over time, proc chains |
| **Precision Sniper** | ACCURACY, CRITDAMAGE, PROJECTILESPEED | Ballistic Assemblies (precision), Energy Emitters | Tactical Processors, Offensive Augments | Tactical Injections, Combat Stimulants | Long-range burst, positioning, single-target |

### 4.2 Archetype Details

#### **Fortress Tank**
- **Core Concept:** Maximum survivability through HP, armor, resistances, and damage reflection
- **Key Stats:** HP (2000+), ARMOR (500+), all resistances (0.7+), THORNDAMAGE (100+)
- **Key Mechanics:**
  - Use Z_HP/U_HP to extend HP caps beyond 5000
  - Stack DAMAGEABSORPTION, SHIELDCAPACITY
  - THORNDAMAGE and REFLECTDAMAGE kill enemies passively
  - Trade-off: Low damage output, slow movement
- **Supporting Mods (10-12):**
  - 3 Structural Plating items (HP, armor scaling)
  - 2 Resistance Arrays (all-resist, fire/electric/corruption)
  - 2 Defensive Protocols syringes
  - 2 Melee Matrices weapons (close-range tanking)
  - 1-2 Exotic Formulas (thorns scaling, reflect mechanics)

#### **Glass Cannon**
- **Core Concept:** Extreme damage output, minimal defense, high skill ceiling
- **Key Stats:** CRITCHANCE (0.5+), CRITDAMAGE (3.0+), GUNDAMAGE (high M_ multipliers)
- **Key Mechanics:**
  - Stack M_GUNDAMAGE, CRITCHANCE, CRITDAMAGE
  - Trade HP/ARMOR for damage (negative M_HP)
  - Conditional damage (bonus when full HP)
  - One-shot potential, dies easily
- **Supporting Mods (10-12):**
  - 3 Offensive Augments (crit, damage, proc)
  - 3 Combat Stimulants (pure damage buffs)
  - 2 Ballistic Assemblies (high DPS weapons)
  - 2 Tactical Processors (lifesteal for sustain)
  - 1-2 Energy Emitters (burst damage)

#### **Elemental Savant**
- **Core Concept:** Elemental status effects, AoE chains, elemental penetration
- **Key Stats:** IGNITECHANCE, CHARGECHANCE, CORRUPTIONCHANCE (all 0.5+), ELEMENTALPENETRATION
- **Key Mechanics:**
  - IGNITESPREAD chains to nearby enemies
  - CHAINLIGHTNING for shock effects
  - Stack ELEMENTALPENETRATION to ignore resistances
  - Combine multiple elements for layered DoT
- **Supporting Mods (10-12):**
  - 3 Elemental Infusions (ignite, charge, corruption)
  - 2 Energy Emitters (elemental damage weapons)
  - 2 Explosive Constructs (AoE application)
  - 2 Offensive Augments (elemental synergies)
  - 1-2 Resistance Arrays (self-resistance for survivability)

#### **Summoner Commander**
- **Core Concept:** Minion army, indirect damage, minion stat scaling
- **Key Stats:** NUMMINIONS (5+), MINIONDAMAGE (2.0+), MINIONHP (2.0+)
- **Key Mechanics:**
  - Deploy multiple minion types (MINIONTYPE)
  - Scale minion stats via multipliers
  - Player focuses on support/positioning
  - Minions inherit some player stats
- **Supporting Mods (8-10):**
  - 3 Minion Protocols (minion stats)
  - 3 Tactical Deployables (minion spawner weapons)
  - 2 Resource Controllers (energy for summons)
  - 1-2 Metabolic Enhancers (sustain for long fights)

#### **Speed Demon**
- **Core Concept:** Maximum mobility, hit-and-run tactics, evasion
- **Key Stats:** PLAYERSPEED (500+), DASHSPEED (2.0+), DODGECHANCE (0.4+)
- **Key Mechanics:**
  - DASHCOOLDOWN reduction for constant dashing
  - High SHOTSPERSEC for quick bursts
  - DODGECHANCE to avoid damage
  - Trade damage for speed/survivability
- **Supporting Mods (8-10):**
  - 3 Mobility Modules (speed, dash, jump)
  - 2 Tactical Injections (attack speed)
  - 2 Ballistic Assemblies (SMG-type, high fire rate)
  - 1-2 Metabolic Enhancers (stamina sustain)

#### **Hybrid Berserker**
- **Core Concept:** Switch between melee and ranged, lifesteal sustain, aggressive
- **Key Stats:** MELEEDAMAGE, GUNDAMAGE (both high), LIFESTEAL (0.2+)
- **Key Mechanics:**
  - Cross-stat dependencies (melee damage = % of gun damage)
  - LIFESTEAL for sustain during combat
  - Hybrid Systems weapons with mode switching
  - Balance between close/mid-range
- **Supporting Mods (8-10):**
  - 2 Hybrid Systems (multi-mode weapons)
  - 2 Offensive Augments (damage scaling)
  - 2 Combat Stimulants (damage buffs)
  - 1-2 Regeneration Systems (sustain)
  - 1 Melee Matrix + 1 Ballistic Assembly

#### **DoT Specialist**
- **Core Concept:** Damage over time, area denial, proc chains
- **Key Stats:** PROCRATE, CORRUPTIONDAMAGE, IGNITEDAMAGE, AREADAMAGE
- **Key Mechanics:**
  - Stack PROCRATE for frequent DoT application
  - CORRUPTIONDAMAGE, IGNITEDAMAGE for layered DoT
  - EXPLOSIONRADIUS, AREADAMAGE for AoE coverage
  - Focus on proc chains and area control
- **Supporting Mods (8-10):**
  - 3 Elemental Infusions (DoT effects)
  - 2 Explosive Constructs (AoE weapons)
  - 2 Offensive Augments (proc rate)
  - 1-2 Tactical Processors (range, area)

#### **Precision Sniper**
- **Core Concept:** Long-range burst, positioning, single-target elimination
- **Key Stats:** ACCURACY (0.95+), CRITDAMAGE (3.0+), PROJECTILESPEED
- **Key Mechanics:**
  - High ACCURACY for guaranteed hits
  - CRITDAMAGE for one-shot potential
  - PROJECTILESPEED for long-range effectiveness
  - Conditional bonuses (damage when stationary)
- **Supporting Mods (8-10):**
  - 2 Ballistic Assemblies (precision rifles)
  - 2 Tactical Injections (accuracy, range)
  - 2 Combat Stimulants (damage)
  - 2 Offensive Augments (crit)
  - 1-2 Tactical Processors (special mechanics)

---

## 5. MOD DISTRIBUTION STRATEGY

### 5.1 Total Breakdown (~150 mods)

| Category | Total | Breakdown |
|----------|-------|-----------|
| **Weapons** | 50 | Ballistic (15), Energy (10), Explosive (8), Tactical (10), Hybrid (4), Melee (7) |
| **Items** | 50 | Structural (8), Mobility (7), Regen (6), Offensive (8), Resistance (6), Resource (8), Tactical (7) |
| **Syringes** | 50 | Combat (8), Defensive (8), Metabolic (7), Elemental (9), Tactical (8), Minion (6), Exotic (4) |

### 5.2 Archetype Support Matrix

| Archetype | Supporting Mods | Primary Classes |
|-----------|-----------------|-----------------|
| **Fortress Tank** | 10-12 | Structural Plating (3), Resistance Arrays (2), Defensive Protocols (2), Melee Matrices (2), Exotic Formulas (2) |
| **Glass Cannon** | 10-12 | Offensive Augments (3), Combat Stimulants (3), Ballistic Assemblies (2), Tactical Processors (2), Energy Emitters (2) |
| **Elemental Savant** | 10-12 | Elemental Infusions (3), Energy Emitters (2), Explosive Constructs (2), Offensive Augments (2), Resistance Arrays (2) |
| **Summoner Commander** | 8-10 | Minion Protocols (3), Tactical Deployables (3), Resource Controllers (2), Metabolic Enhancers (1-2) |
| **Speed Demon** | 8-10 | Mobility Modules (3), Tactical Injections (2), Ballistic Assemblies (2), Metabolic Enhancers (1-2) |
| **Hybrid Berserker** | 8-10 | Hybrid Systems (2), Offensive Augments (2), Combat Stimulants (2), Regeneration Systems (2), Melee/Ballistic (1 each) |
| **DoT Specialist** | 8-10 | Elemental Infusions (3), Explosive Constructs (2), Offensive Augments (2), Tactical Processors (1-2) |
| **Precision Sniper** | 8-10 | Ballistic Assemblies (2), Tactical Injections (2), Combat Stimulants (2), Offensive Augments (2), Tactical Processors (1-2) |

### 5.3 Design Coverage Requirements

**Each mod class must:**
1. Support at least 2 archetypes
2. Have clear synergies with other classes
3. Provide both common and rare variants
4. Fit nanomolecular lore
5. Use unique HEL equations (avoid copy-paste)

**Synergy Examples:**
- Offensive Augments + Combat Stimulants = Glass Cannon core
- Structural Plating + Resistance Arrays = Tank core
- Elemental Infusions + Energy Emitters = Elemental Savant core
- Minion Protocols + Tactical Deployables = Summoner core

---

## 6. LORE INTEGRATION

### 6.1 Nanomolecular Terminology

All mod names and descriptions must use nanite-appropriate language:

| Category | Lore Names | Forbidden Terms | Approved Terms |
|----------|------------|-----------------|----------------|
| **Weapons** | Assemblies, Emitters, Constructs, Matrices, Projectors | Guns, Rifles, Blades | Ballistic Assembly, Energy Emitter, Nano-Blade Matrix |
| **Items** | Plating, Modules, Systems, Arrays, Controllers, Processors | Armor, Boots, Gloves | Structural Plating, Mobility Module, Resistance Array |
| **Syringes** | Stimulants, Protocols, Enhancers, Infusions, Injections, Formulas | Potions, Elixirs, Blood | Combat Stimulant, Defensive Protocol, Elemental Infusion |
| **Effects** | Reconstruction, Corruption, Core Breach, Structural Damage | Healing, Poison, Bleeding, Wounds | Repair Rate, Viral Code, Coolant Leak, Integrity Loss |

### 6.2 Beacon Dispensing System

**Beacon Tiers Dispense Different Mod Types:**

| Beacon Tier | Mod Types Available | Rarity Distribution |
|-------------|---------------------|---------------------|
| **Tier 1 (Early)** | Standard Configs, low-power syringes | 80% Standard, 20% Enhanced |
| **Tier 2 (Mid-Early)** | Enhanced Protocols, basic weapons | 60% Standard, 35% Enhanced, 5% Advanced |
| **Tier 3 (Mid)** | Advanced Matrices, tactical weapons | 40% Enhanced, 50% Advanced, 10% Rare/Unique |
| **Tier 4 (Mid-Late)** | Rare assemblies, exotic syringes | 20% Enhanced, 60% Advanced, 20% Unique |
| **Tier 5+ (Endgame)** | Prototype assemblies, build-defining | 10% Advanced, 70% Unique, 20% Boss-specific |

**Beacon Types:**
- **Combat Beacons**: Weapons + Offensive mods (higher enemy density)
- **Support Beacons**: Defensive items + Regeneration syringes
- **Tactical Beacons**: Utility items + Resource controllers
- **Experimental Beacons**: Exotic formulas + Unique prototypes (rare, high difficulty)

### 6.3 Nanite Lore Naming Patterns

**Weapon Naming:**
- `[Function] [Tech Type]`: Assault Matrix, Precision Emitter, Scatter Projector
- `[Element] [Output Type]`: Plasma Discharger, Arc Projector, Flame Launcher
- `[Tactical Role] [System]`: Siege Cannon, Infiltrator Rifle, Guardian Array

**Item Naming:**
- `[Stat] [Component]`: Velocity Module, Integrity Plating, Resistance Array
- `[Effect] [System]`: Regeneration Core, Absorption Field, Reflection Matrix

**Syringe Naming:**
- `[Effect] [Type]`: Combat Stimulant, Repair Protocol, Corruption Infusion
- `[Stat] Nanites`: Fire Rate Nanites, Damage Nanites, Armor Nanites

### 6.4 Description Writing Guidelines

**Example Descriptions:**

❌ **BAD** (biological): "Injects blood with fire magic, burning enemies from within"
✅ **GOOD** (nanite): "Infuses core systems with thermal protocols, igniting targets on contact"

❌ **BAD** (generic): "Increases damage by val1%"
✅ **GOOD** (specific): "Overclocks projectile emitters, boosting damage output by val1%"

**Template:**
```
[Action verb] [nanite system], [mechanical effect] by val1[unit]
```

Examples:
- "Reinforces structural nanites, increasing maximum integrity by val1 points"
- "Optimizes energy distribution, reducing ability cooldowns by val1%"
- "Channels corruption protocols, inflicting val1 viral damage per second"

---

## 7. COORDINATION FRAMEWORK

### 7.1 Designer Agent Templates

Each designer agent will receive:

1. **Class Assignment**: Specific mod class (e.g., "Design 15 Ballistic Assemblies")
2. **ID Range**: Assigned modid range to prevent conflicts
3. **Archetype Requirements**: Which archetypes this class must support
4. **Synergy Map**: Related classes that must combo well
5. **Balance Constraints**: Damage ranges, multiplier limits, trade-off requirements
6. **Naming Convention**: Class-specific naming patterns
7. **Equation Patterns**: Common HEL templates for this class

### 7.2 Stat Dependency Matrix

**Cross-Stat Dependencies (for complex mods):**

| Primary Stat | Can Scale With | Example Equation |
|--------------|----------------|------------------|
| MELEEDAMAGE | GUNDAMAGE, PLAYERSPEED | `A_MELEEDAMAGE = A_MELEEDAMAGE + B_GUNDAMAGE val1 *` |
| GUNDAMAGE | HP, ARMOR, CRITCHANCE | `M_GUNDAMAGE = M_GUNDAMAGE + (T_HP 100 <) val1 *` |
| MINIONDAMAGE | NUMMINIONS, PLAYERSPEED | `M_MINIONDAMAGE = M_MINIONDAMAGE + T_NUMMINIONS val1 *` |
| THORNDAMAGE | ARMOR, HP | `B_THORNDAMAGE = B_THORNDAMAGE + B_ARMOR val1 *` |
| LIFESTEAL | CRITDAMAGE, GUNDAMAGE | `M_LIFESTEAL = M_LIFESTEAL + T_CRITCHANCE val1 *` |

### 7.3 Balance Constraints

**Multiplier Limits:**
- M_ percentage boosts: -0.9 to +3.0 (negative 90% to +300%)
- B_ flat additions: 0 to 1000 (stat-dependent)
- Trade-offs: At least 20% penalty for 100%+ bonus
- Crit damage: Max 5.0 (500% damage)
- Resistances: Max 0.9 (90% reduction, never 100%)

**Value Ranges by Stat Type:**

| Stat Type | val1min | val1max | val2 Usage |
|-----------|---------|---------|------------|
| % Damage Boost (M_) | 0.1 | 1.5 | Trade-off penalty |
| Flat HP Boost (B_) | 20 | 500 | Secondary stat |
| Crit Chance (M_) | 0.05 | 0.4 | Crit damage |
| Resistance (M_) | 0.1 | 0.7 | Secondary resist |
| Elemental Chance | 0.1 | 0.8 | Elemental damage |

### 7.4 Synergy Requirements

**Mandatory Synergy Pairs:**

1. **Crit Synergy**: Mods that boost CRITCHANCE must have corresponding CRITDAMAGE mods
2. **Elemental Chains**: Each element (ignite, charge, corruption) needs 3+ supporting mods
3. **Minion Ecosystem**: NUMMINIONS + MINIONDAMAGE + MINIONHP all supported
4. **Tank Trinity**: HP + ARMOR + Resistance mods must exist in balance
5. **Speed Package**: PLAYERSPEED + DASHSPEED + STAMINAREGEN synergies

**Cross-Class Combos:**
- Offensive Augment (crit chance) + Combat Stimulant (crit damage) + Ballistic Assembly (high DPS weapon)
- Structural Plating (HP) + Resistance Array (resistances) + Defensive Protocol (armor) + Exotic Formula (thorns)
- Elemental Infusion (ignite chance) + Energy Emitter (elemental weapon) + Offensive Augment (proc rate)

### 7.5 Equation Pattern Library

**Common HEL Patterns for Designer Agents:**

```yaml
# Simple Percentage Boost
equation: M_GUNDAMAGE = M_GUNDAMAGE + val1

# Trade-off (Damage for Defense)
equation: M_GUNDAMAGE = M_GUNDAMAGE + val1; M_HP = M_HP + (-val2)

# Conditional Damage (Low HP Bonus)
equation: M_GUNDAMAGE = M_GUNDAMAGE + (T_HP 100 <) val1 *

# Cross-Stat Scaling (Melee from Gun Damage)
equation: A_MELEEDAMAGE = A_MELEEDAMAGE + B_GUNDAMAGE val1 *

# Cap Extension (Increase Max HP)
equation: B_HP = B_HP + val1; U_HP = U_HP + val2

# Minion Scaling (Damage per Minion)
equation: M_MINIONDAMAGE = M_MINIONDAMAGE + T_NUMMINIONS val1 *

# Elemental Combo (Ignite Chance + Damage)
equation: M_IGNITECHANCE = M_IGNITECHANCE + val1; B_IGNITEDAMAGE = B_IGNITEDAMAGE + val2

# Random Proc Effect
equation: M_PROCRATE = M_PROCRATE + RAND val1 *

# Complex Conditional (Speed-based Damage)
equation: M_GUNDAMAGE = M_GUNDAMAGE + (T_PLAYERSPEED 200 >) val1 *; M_PLAYERSPEED = M_PLAYERSPEED + val2
```

### 7.6 Quality Checklist for Designer Agents

Before submitting mod designs, verify:

- [ ] modid is unique and in assigned range
- [ ] uuid follows pattern `uuid-{modid}-{repeating}`
- [ ] type matches modid range (0=0-499, 2=500-599, 10=5000-5999)
- [ ] name is ALL CAPS WITH SPACES
- [ ] desc uses "val1" and "val2" placeholders (lowercase)
- [ ] equation uses correct prefixes (B_, M_, A_, Z_, U_)
- [ ] equation adds to coefficients (`= X + val1`, not `= val1`)
- [ ] M_ values are decimals (0.5 = 50%, not 50)
- [ ] Trade-offs are meaningful (20%+ penalty for 100%+ bonus)
- [ ] Lore is nanomolecular (no biological terms)
- [ ] Synergizes with at least 2 other mod classes
- [ ] Supports at least 1 archetype clearly
- [ ] modweight is appropriate for rarity tier
- [ ] val1min/max and val2min/max are balanced

### 7.7 Coordination Workflow

**Phase 1: Foundation (Complete)**
- System architecture designed ✓
- Stat categories defined ✓
- Archetypes outlined ✓

**Phase 2: Stat Creation (Next)**
- 27 new stats designed and validated
- StatsData.asset updated

**Phase 3: Mod Design (Parallel)**
- 20+ designer agents work simultaneously
- Each agent: 1 mod class (5-15 mods)
- Templates provided for each class
- Cross-reference synergy map

**Phase 4: Integration**
- Combine all mod designs
- Validate ID uniqueness
- Test archetype viability
- Balance pass

**Phase 5: Implementation**
- ModsData.asset updated
- Playtesting and iteration

---

## APPENDIX A: Quick Reference Tables

### A.1 Mod Type ID Ranges

| Type | Category | ID Range | Count Target |
|------|----------|----------|--------------|
| 0 | Passive Items | 0-499 | 50 |
| 2 | Ranged Weapons | 500-599, 700-799 | 43 |
| 4 | Melee Weapons | 800-899 | 7 |
| 10 | Upgrade Syringes | 5000-5999 | 50 |
| 20 | Permanent Upgrades | 6000-6999 | N/A (existing) |

### A.2 Rarity modweight Ranges

| Rarity | modweight | Drop Rate |
|--------|-----------|-----------|
| Standard | 100-600 | Very Common |
| Enhanced | 50-100 | Common |
| Advanced | 10-50 | Uncommon |
| Unique | 3-5 | Rare |

### A.3 Stat Value Ranges

| Stat Type | Default Range | Max Recommended |
|-----------|---------------|-----------------|
| Percentages (chance, accuracy) | 0-1 | 1 (100%) |
| HP/Damage | 0-5000 | 5000 |
| Speed | 0-5000 | 1000 |
| Multipliers (crit damage) | 0-5000 | 5.0 |
| Resistances | 0-1 | 0.9 (90%) |

---

## APPENDIX B: Archetype Stat Targets

| Archetype | HP Target | Damage Target | Defense Target | Special Target |
|-----------|-----------|---------------|----------------|----------------|
| Fortress Tank | 2000+ | 50-100 | ARMOR 500+, Resist 0.7+ | THORNDAMAGE 100+ |
| Glass Cannon | 50-100 | 500+ | ARMOR 0-50 | CRITDAMAGE 3.0+ |
| Elemental Savant | 200-400 | 200-300 | Resist 0.5+ | Elemental Chance 0.6+ |
| Summoner | 300-500 | 50-100 (player) | ARMOR 200+ | NUMMINIONS 5+, MINIONDAMAGE 2.0+ |
| Speed Demon | 150-300 | 150-250 | DODGECHANCE 0.4+ | PLAYERSPEED 500+, DASHSPEED 2.0+ |
| Hybrid Berserker | 400-600 | 300-400 (combined) | LIFESTEAL 0.2+ | Both melee/ranged high |
| DoT Specialist | 200-400 | 50-100 (direct) | Resist 0.4+ | PROCRATE high, Elemental Damage 200+ |
| Precision Sniper | 150-250 | 400+ (burst) | DODGECHANCE 0.3+ | ACCURACY 0.95+, CRITDAMAGE 3.0+ |

---

**END OF ARCHITECTURE DOCUMENT**

**Next Steps for Coordination:**
1. Stat Creation Agent: Design 27 new stats
2. Weapon Designer Agents: 6 agents (Ballistic, Energy, Explosive, Tactical, Hybrid, Melee)
3. Item Designer Agents: 7 agents (Structural, Mobility, Regen, Offensive, Resistance, Resource, Tactical)
4. Syringe Designer Agents: 7 agents (Combat, Defensive, Metabolic, Elemental, Tactical, Minion, Exotic)

**Total Agents Needed:** 21 designer agents + 1 integration agent

**Timeline:** Each designer agent creates 5-15 mods, parallel execution, ~2-3 iterations per agent for balance.
