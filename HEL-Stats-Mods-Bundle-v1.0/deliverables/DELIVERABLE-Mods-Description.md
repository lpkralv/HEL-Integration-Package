# HIOX Mods Description - Complete Reference
**Version:** 1.0
**Status:** FINAL DELIVERABLE
**Total Mods:** 155 (55 Weapons + 50 Items + 50 Syringes)

---

## INTRODUCTION

This document provides a comprehensive reference for all 155 mods in the HIOX Stats/Mods system. Mods are organized into three categories (Weapons, Items, Syringes) with detailed class breakdowns.

**Rarity Tiers:**
- **Standard** (modweight 180-200): Common drops, pure bonuses, no penalties
- **Enhanced** (modweight 80-100): Uncommon drops, dual effects, minor trade-offs (8-15%)
- **Advanced** (modweight 35-50): Rare drops, complex mechanics, moderate penalties (15-25%)
- **Prototype** (modweight 5-15): Very rare drops, build-defining, extreme penalties (20-40%)

**Full Design Details:** See individual class design documents (Weapons-*.md, Items-*.md, Syringes-*.md)

---

## WEAPONS (55 mods, IDs 1000-1054)

### BALLISTIC ASSEMBLIES (15 mods, IDs 1000-1014)
*Projectile-based weapons for sustained and burst damage*

**1000 - ASSAULT RIFLE ASSEMBLY** (Standard)
- Type: 2 | Modweight: 200
- Effects: +15-25% gun damage, +10-20% fire rate
- Trade-offs: None
- Build: Glass Cannon, Precision Sniper

**1001 - BURST RIFLE ASSEMBLY** (Standard)
- Type: 2 | Modweight: 195
- Effects: +3-5 bullets per shot, +15-30% burst damage
- Trade-offs: None
- Build: Glass Cannon, Precision Sniper

**1002 - PRECISION SNIPER ASSEMBLY** (Standard)
- Type: 2 | Modweight: 190
- Effects: +30-50% gun damage, +20-35% accuracy
- Trade-offs: -15% fire rate
- Build: Precision Sniper, Glass Cannon

**1003 - HEAVY MACHINE GUN** (Standard)
- Type: 2 | Modweight: 185
- Effects: +40-70% fire rate, +50-100 ammo capacity
- Trade-offs: -10% accuracy
- Build: Glass Cannon, DoT Specialist

**1004 - SHOTGUN SCATTER ASSEMBLY** (Standard)
- Type: 2 | Modweight: 180
- Effects: +5-8 bullets per shot, +25-40% close-range damage
- Trade-offs: -30% accuracy, -20% range
- Build: Hybrid Berserker, Glass Cannon

**1005 - RAPID-FIRE CARBINE** (Enhanced)
- Type: 2 | Modweight: 95
- Effects: +35-50% gun damage, +25-40% fire rate
- Trade-offs: -15% accuracy, -12% HP
- Build: Glass Cannon, Speed Demon

**1006 - CRITICAL MARKSMAN RIFLE** (Enhanced)
- Type: 2 | Modweight: 90
- Effects: +25-40% crit chance, +0.5-1.0 crit damage multiplier
- Trade-offs: -20% fire rate, -10% ammo capacity
- Build: Precision Sniper, Glass Cannon

**1007 - ARMOR-PIERCING RIFLE** (Enhanced)
- Type: 2 | Modweight: 85
- Effects: +50-80% gun damage, +20-35% armor penetration
- Trade-offs: -25% fire rate, -15% accuracy
- Build: Glass Cannon, Precision Sniper

**1008 - SUPPRESSIVE FIRE PLATFORM** (Enhanced)
- Type: 2 | Modweight: 80
- Effects: +60-100% fire rate, +100-200 ammo capacity
- Trade-offs: -20% accuracy, -15% gun damage
- Build: DoT Specialist, Hybrid Berserker

**1009 - ELEMENTAL BALLISTIC CORE** (Enhanced)
- Type: 2 | Modweight: 75
- Effects: +15-25% ignite/charge/corruption chance, +20-35% gun damage
- Trade-offs: -18% fire rate
- Build: Elemental Savant, DoT Specialist

**1010 - BERSERKER SHOTGUN** (Advanced)
- Type: 2 | Modweight: 45
- Effects: +40-70% gun damage when below 50% HP, +6-10 bullets per shot
- Trade-offs: -25% accuracy, -20% range, -15% HP
- Build: Glass Cannon, Hybrid Berserker

**1011 - LIFESTEAL ASSAULT ARRAY** (Advanced)
- Type: 2 | Modweight: 40
- Effects: +12-20% lifesteal, +30-50% gun damage
- Trade-offs: -20% fire rate, -15% HP
- Build: Hybrid Berserker, Glass Cannon

**1012 - CRITICAL DEVASTATION CANNON** (Advanced)
- Type: 2 | Modweight: 35
- Effects: +30-50% crit chance, +1.5-2.5 crit damage multiplier
- Trade-offs: -30% fire rate, -25% ammo capacity
- Build: Precision Sniper, Glass Cannon

**1013 - VELOCITY GATLING ARRAY** (Advanced)
- Type: 2 | Modweight: 30
- Effects: +100-150% fire rate, +8-12 bullets per shot
- Trade-offs: -35% accuracy, -25% gun damage, -20% range
- Build: DoT Specialist (proc spam), Elemental Savant

**1014 - CATACLYSM CANNON** (Prototype)
- Type: 2 | Modweight: 5
- Effects: +5 bullets per shot, +80-120% gun damage, +40-60% spread
- Trade-offs: -40% fire rate, -50% accuracy, -25% range
- Build: Glass Cannon (close-range devastation)

### ENERGY EMITTERS (10 mods, IDs 1015-1024)
*Elemental energy-based weapons for proc application*

**1015 - THERMAL LASER EMITTER** (Standard)
- Type: 2 | Modweight: 195
- Effects: +15-25% ignite chance, +20-35 ignite damage
- Trade-offs: None
- Build: Elemental Savant, DoT Specialist

**1016 - ELECTRIC ARC PROJECTOR** (Standard)
- Type: 2 | Modweight: 195
- Effects: +15-25% charge chance, +20-35 charge damage
- Trade-offs: None
- Build: Elemental Savant, DoT Specialist

**1017 - CORRUPTION BEAM ARRAY** (Standard)
- Type: 2 | Modweight: 190
- Effects: +15-25% corruption chance, +20-35 corruption damage
- Trade-offs: None
- Build: Elemental Savant, DoT Specialist

**1018 - RAPID PULSE LASER** (Standard)
- Type: 2 | Modweight: 185
- Effects: +30-50% fire rate, +40-60% projectile speed
- Trade-offs: -10% gun damage
- Build: Speed Demon, Glass Cannon

**1019 - DUAL-ELEMENT FUSION BEAM** (Enhanced)
- Type: 2 | Modweight: 90
- Effects: +20-35% ignite chance, +20-35% charge chance
- Trade-offs: -15% gun damage
- Build: Elemental Savant, DoT Specialist

**1020 - TRI-ELEMENT DEVASTATOR** (Enhanced)
- Type: 2 | Modweight: 85
- Effects: +15-25% ignite/charge/corruption chance, +30-50 elemental damage (all)
- Trade-offs: -20% fire rate, -12% gun damage
- Build: Elemental Savant, DoT Specialist

**1021 - CHAIN LIGHTNING EMITTER** (Enhanced)
- Type: 2 | Modweight: 80
- Effects: +3-5 chain lightning jumps, +30-50% charge chance
- Trade-offs: -15% gun damage per chain
- Build: Elemental Savant (AoE), DoT Specialist

**1022 - IGNITE SPREAD PROJECTOR** (Advanced)
- Type: 2 | Modweight: 40
- Effects: +4-7 ignite spread range, +40-60% ignite chance, +50-80 ignite damage
- Trade-offs: -25% gun damage, -20% fire rate
- Build: Elemental Savant (fire focus), DoT Specialist

**1023 - ELEMENTAL PENETRATION BEAM** (Advanced)
- Type: 2 | Modweight: 35
- Effects: +25-40% elemental penetration, +30-50% elemental chance (all)
- Trade-offs: -30% gun damage, -15% fire rate
- Build: Elemental Savant (late-game), Glass Cannon

**1024 - ELEMENTAL ANNIHILATOR** (Prototype)
- Type: 2 | Modweight: 10
- Effects: +60-80% ignite/charge/corruption chance, +100-150 elemental damage (all), +5-8 chain/spread
- Trade-offs: -40% gun damage, -30% fire rate, -20% accuracy
- Build: Elemental Savant (pure elemental)

### EXPLOSIVE LAUNCHERS (9 mods, IDs 1025-1033)
*Area-of-effect weapons for crowd control and proc spreading*

**1025 - GRENADE LAUNCHER** (Standard)
- Type: 2 | Modweight: 190
- Effects: +30-50% gun damage, +2-4 AoE radius
- Trade-offs: None
- Build: DoT Specialist, Glass Cannon

**1026 - ROCKET ASSEMBLY** (Standard)
- Type: 2 | Modweight: 185
- Effects: +50-80% gun damage, +3-5 AoE radius
- Trade-offs: -20% fire rate, -30% projectile speed
- Build: Glass Cannon, Precision Sniper

**1027 - MINE DEPLOYER** (Standard)
- Type: 2 | Modweight: 180
- Effects: +40-70% gun damage (on trigger), +4-6 AoE radius
- Trade-offs: Delayed activation
- Build: DoT Specialist, Tactical

**1028 - CLUSTER BOMB LAUNCHER** (Enhanced)
- Type: 2 | Modweight: 85
- Effects: +3-5 sub-explosions, +35-60% gun damage each
- Trade-offs: -25% fire rate, -15% accuracy
- Build: DoT Specialist (AoE), Glass Cannon

**1029 - ELEMENTAL WARHEAD** (Enhanced)
- Type: 2 | Modweight: 80
- Effects: +25-40% elemental chance (all), +50-80% gun damage, +3-5 AoE radius
- Trade-offs: -30% fire rate, -20% accuracy
- Build: Elemental Savant (AoE), DoT Specialist

**1030 - NAPALM DISPERSER** (Enhanced)
- Type: 2 | Modweight: 75
- Effects: +40-60% ignite chance, +60-100 ignite damage, +5-8 ignite spread
- Trade-offs: -25% gun damage, -20% fire rate
- Build: Elemental Savant (fire), DoT Specialist

**1031 - SHRAPNEL MORTAR** (Advanced)
- Type: 2 | Modweight: 40
- Effects: +8-12 sub-projectiles, +30-50% gun damage each, +4-7 pierce
- Trade-offs: -35% fire rate, -40% accuracy
- Build: DoT Specialist (multi-hit), Glass Cannon

**1032 - NUCLEAR DEVASTATOR** (Advanced)
- Type: 2 | Modweight: 35
- Effects: +100-150% gun damage, +8-12 AoE radius, +40-60% elemental chance (all)
- Trade-offs: -50% fire rate, -30% accuracy, -20% HP
- Build: Glass Cannon (nuke), Elemental Savant

**1033 - QUANTUM CLUSTER BOMB** (Prototype)
- Type: 2 | Modweight: 5
- Effects: +8 sub-explosions, +80-120% gun damage each, +6-10 AoE radius each
- Trade-offs: -60% fire rate, -50% accuracy, -25% HP
- Build: Glass Cannon (screen-clear)

### DEPLOYABLE SYSTEMS (10 mods, IDs 1034-1043)
*Minion-summoning and tactical deployment weapons*

**1034 - COMBAT DRONE DEPLOYER** (Standard)
- Type: 2 | Modweight: 195
- Effects: +1 minion, +20-35% minion damage
- Trade-offs: None
- Build: Summoner Commander

**1035 - TURRET ASSEMBLY** (Standard)
- Type: 2 | Modweight: 190
- Effects: +1 minion (stationary turret), +30-50% minion damage
- Trade-offs: -15% player gun damage
- Build: Summoner Commander

**1036 - HUNTER DRONE FABRICATOR** (Standard)
- Type: 2 | Modweight: 185
- Effects: +1 minion (fast drone), +25-40% minion attack speed
- Trade-offs: None
- Build: Summoner Commander

**1037 - SHIELD DRONE DEPLOYER** (Standard)
- Type: 2 | Modweight: 180
- Effects: +1 minion (defensive), +50-100 shield capacity (player)
- Trade-offs: -10% player gun damage
- Build: Summoner Commander, Fortress Tank

**1038 - DUAL DRONE FABRICATOR** (Enhanced)
- Type: 2 | Modweight: 90
- Effects: +2 minions, +25-40% minion damage
- Trade-offs: -15% player gun damage, -10% HP
- Build: Summoner Commander

**1039 - ENHANCED TURRET NETWORK** (Enhanced)
- Type: 2 | Modweight: 85
- Effects: +2 minions (turrets), +40-60% minion damage, +30-50% minion HP
- Trade-offs: -20% player gun damage, -15% player speed
- Build: Summoner Commander

**1040 - MINION DAMAGE AMPLIFIER** (Enhanced)
- Type: 2 | Modweight: 80
- Effects: +50-80% minion damage, +40-60% minion attack speed
- Trade-offs: -25% player gun damage
- Build: Summoner Commander

**1041 - SWARM DRONE ARRAY** (Advanced)
- Type: 2 | Modweight: 40
- Effects: +2 minions, +35-60% minion damage, +50-80% minion attack speed
- Trade-offs: -30% player gun damage, -15% HP, -50% minion HP
- Build: Summoner Commander (glass cannon minions)

**1042 - TANK DRONE FABRICATOR** (Advanced)
- Type: 2 | Modweight: 35
- Effects: +2 minions, +100-150% minion HP, +15-25% minion lifesteal
- Trade-offs: -35% player gun damage, -20% player speed
- Build: Summoner Commander (tank minions)

**1043 - SWARM FABRICATOR** (Prototype)
- Type: 2 | Modweight: 10
- Effects: +3 minions, +60-100% minion damage, +70-120% minion attack speed
- Trade-offs: -40% player gun damage, -20% HP, -60% minion HP
- Build: Summoner Commander (swarm army)

### HYBRID PLATFORMS (4 mods, IDs 1044-1047)
*Multi-mode weapons for versatile combat*

**1044 - DUAL-MODE RIFLE** (Enhanced)
- Type: 2 | Modweight: 90
- Effects: Switch between precision (+40% gun damage, +30% accuracy) and spray (+60% fire rate, +50 ammo capacity)
- Trade-offs: -15% gun damage (both modes), -10% HP
- Build: Hybrid Berserker, Precision Sniper

**1045 - ADAPTIVE COMBAT ARRAY** (Enhanced)
- Type: 2 | Modweight: 85
- Effects: Switch between ranged (+35% gun damage, +25% range) and melee (+50% melee damage, +30% melee speed)
- Trade-offs: -12% gun damage, -12% melee damage
- Build: Hybrid Berserker

**1046 - TRI-MODE PLATFORM** (Advanced)
- Type: 2 | Modweight: 40
- Effects: Switch between burst (+60% gun damage, +4 bullets), sustained (+80% fire rate), and elemental (+40% elemental chance)
- Trade-offs: -20% gun damage (all modes), -15% HP
- Build: Hybrid Berserker, Elemental Savant

**1047 - OMNI-WEAPON CORE** (Prototype)
- Type: 2 | Modweight: 10
- Effects: Switch between 5 modes (precision, spray, explosive, elemental, minion), each with specialized bonuses
- Trade-offs: -30% gun damage (all modes), -20% HP, -15% fire rate (all modes)
- Build: Hybrid Berserker (ultimate versatility)

### MELEE IMPLEMENTS (7 mods, IDs 1048-1054)
*Close-range melee weapons*

**1048 - NANOBLADE ASSEMBLY** (Standard)
- Type: 4 | Modweight: 195
- Effects: +25-40% melee damage, +15-25% melee speed
- Trade-offs: None
- Build: Hybrid Berserker

**1049 - HEAVY IMPACT HAMMER** (Standard)
- Type: 4 | Modweight: 190
- Effects: +50-80% melee damage, +2-4 AoE radius
- Trade-offs: -20% melee speed
- Build: Hybrid Berserker, Fortress Tank

**1050 - RAPID STRIKE BLADE** (Enhanced)
- Type: 4 | Modweight: 85
- Effects: +40-70% melee speed, +30-50% melee damage
- Trade-offs: -15% HP
- Build: Hybrid Berserker, Speed Demon

**1051 - LIFESTEAL SCYTHE** (Enhanced)
- Type: 4 | Modweight: 80
- Effects: +18-30% lifesteal (melee), +40-70% melee damage
- Trade-offs: -12% HP, -20% melee range
- Build: Hybrid Berserker (sustain)

**1052 - CRITICAL STRIKE KATANA** (Advanced)
- Type: 4 | Modweight: 40
- Effects: +35-55% crit chance (melee), +1.5-2.5 crit damage, +50-80% melee damage
- Trade-offs: -25% HP, -15% armor
- Build: Hybrid Berserker, Glass Cannon (melee)

**1053 - BERSERKER WAR AXE** (Advanced)
- Type: 4 | Modweight: 35
- Effects: +50-90% melee damage when below 50% HP, +35-60% melee speed
- Trade-offs: -20% HP, -20% armor
- Build: Hybrid Berserker (low-HP)

**1054 - NANITE STORM BLADE** (Prototype)
- Type: 4 | Modweight: 10
- Effects: +100-150% melee damage, +5-8 AoE radius, +40-60% proc rate (all procs)
- Trade-offs: -30% HP, -25% armor, -20% melee range
- Build: Hybrid Berserker (AoE melee), DoT Specialist

---

## ITEMS (50 mods, IDs 2000-2049)

### STRUCTURAL PLATING (8 mods, IDs 2000-2007)
*HP, armor, and defensive foundations*

**2000 - REINFORCED FRAME** (Standard) - +150-300 HP
**2001 - ABLATIVE ARMOR PLATING** (Standard) - +100-200 armor
**2002 - ADAPTIVE ARMOR PROTOCOL** (Enhanced) - +300-500 armor scaling with damage taken, -10% speed
**2003 - REACTIVE PLATING** (Enhanced) - +200-400 HP, +30-60 thorns damage, -10% speed
**2004 - FORTIFIED BULWARK** (Advanced) - +400-700 HP, +200-400 armor, -20% speed, -15% fire rate
**2005 - HP SCALING MATRIX** (Advanced) - +1% gun/melee damage per 100 HP, +300-500 HP, -15% speed
**2006 - REACTIVE DEFENSE CORE** (Advanced) - +40-70% thorns damage, +200-400 armor, -15% gun damage
**2007 - ABLATIVE REGENERATION CORE** (Prototype) - HP regen scales with max HP (1-2% per second), +500-800 HP, -25% speed, -20% armor

*For full details, see docs/Items-Structural.md*

### MOBILITY ENHANCEMENTS (7 mods, IDs 2008-2014)
*Speed, dash, and evasion systems*

**2008 - LIGHTWEIGHT FRAME** (Standard) - +25-40% player speed
**2009 - DASH MOMENTUM CAPACITOR** (Standard) - +40-70% dash speed, -0.5-1.0s dash cooldown
**2010 - EVASION MATRIX** (Standard) - +15-25% dodge chance
**2011 - SPRINT PROTOCOL** (Enhanced) - +40-65% player speed, +30-50% dash speed, -10% HP
**2012 - GHOST STEP SYSTEM** (Enhanced) - +25-40% dodge chance, +30-50% player speed, -12% armor
**2013 - KINETIC ACCELERATOR** (Advanced) - +3-5% speed per kill (stacking), +40-70% base speed, -15% HP
**2014 - PERPETUAL MOTION CORE** (Prototype) - +80-120% player speed, +100-150% dash speed, -35% gun damage, -30% HP

*For full details, see docs/Items-Mobility.md*

### REGENERATION SYSTEMS (6 mods, IDs 2015-2020)
*HP regen, energy regen, shield regen*

**2015 - NANITE REPAIR PROTOCOL** (Standard) - +15-30 HP regen/sec
**2016 - ENERGY REACTOR CORE** (Standard) - +20-40 energy regen/sec, +100-200 energy capacity
**2017 - SHIELD REGENERATOR** (Standard) - +20-40 shield regen/sec, +100-200 shield capacity
**2018 - RAPID RECONSTRUCTION** (Enhanced) - +35-60 HP regen/sec, +30-50 energy regen/sec, -10% max HP
**2019 - PERPETUAL SHIELD MATRIX** (Advanced) - +60-100 shield regen/sec, +300-500 shield capacity, -20% HP, -15% armor
**2020 - ABLATIVE REGENERATION CORE** (Prototype) - See Structural (duplicate ID removed in final version)

*For full details, see docs/Items-Regeneration.md*

### OFFENSIVE AUGMENTS (8 mods, IDs 2021-2028)
*Crit, damage, and offensive scaling*

**2021 - PRECISION TARGETING CORE** (Standard) - +15-25% crit chance
**2022 - DAMAGE AMPLIFIER** (Standard) - +20-35% gun damage, +20-35% melee damage
**2023 - BURST DAMAGE CORE** (Enhanced) - +40-65% gun damage, +35-60% melee damage, -15% HP
**2024 - CRITICAL AMPLIFICATION CORE** (Enhanced) - +25-40% crit chance, +1.0-2.0 crit damage, -12% fire rate
**2025 - ELEMENTAL DAMAGE CATALYST** (Enhanced) - +35-60 ignite/charge/corruption damage, +20-35% elemental chance (all), -15% gun damage
**2026 - PROC RATE OPTIMIZER** (Advanced) - +50-80% proc rate, +40-70% proc range, -20% gun damage
**2027 - CRITICAL LIFESTEAL MATRIX** (Advanced) - +15-25% lifesteal on crits, +30-50% crit chance, -20% HP
**2028 - MINION DAMAGE CATALYST** (Advanced) - +80-130% minion damage, +60-100% minion attack speed, -30% player gun damage

*For full details, see docs/Items-Offensive.md*

### RESISTANCE ARRAYS (6 mods, IDs 2029-2034)
*Elemental resistances and conversions*

**2029 - THERMAL INSULATION MATRIX** (Standard) - +25-50% fire resistance
**2030 - ELECTRIC INSULATION GRID** (Standard) - +25-50% electric resistance
**2031 - CORRUPTION BARRIER PROTOCOL** (Standard) - +25-50% corruption resistance
**2032 - TRI-ELEMENT RESISTANCE CORE** (Enhanced) - +15-35% fire/electric/corruption resistance, -15% HP
**2033 - ELEMENTAL PENETRATION CONVERTER** (Advanced) - Converts resistance to penetration (0.5-1.5% penetration per 100 combined resistance), +5-15% base penetration, -25% fire rate
**2034 - ELEMENTAL ABSORPTION DEVASTATOR** (Prototype) - +40-80% all resistances, converts resistance to gun/melee damage (1% damage per 50 combined resistance), -30% speed, -20% fire rate

*For full details, see docs/Items-Resistance.md*

### RESOURCE OPTIMIZERS (8 mods, IDs 2035-2042)
*Energy, cooldowns, resource efficiency*

**2035 - ENERGY CELL EXPANSION** (Standard) - +200-400 energy capacity
**2036 - REACTOR EFFICIENCY CORE** (Standard) - +30-60% resource efficiency
**2037 - COOLDOWN ACCELERATOR** (Standard) - +20-35% cooldown reduction
**2038 - STAMINA OPTIMIZER** (Enhanced) - +40-70 stamina regen/sec, +30-50% resource efficiency, -10% energy capacity
**2039 - ABILITY SPAM CORE** (Enhanced) - +35-60% cooldown reduction, +40-70% resource efficiency, -15% gun damage
**2040 - ENERGY REACTOR OVERCHARGE** (Advanced) - +500-800 energy capacity, +60-100 energy regen/sec, -20% HP
**2041 - INFINITE ABILITY MATRIX** (Advanced) - +60-85% cooldown reduction, +60-90% resource efficiency, -25% gun damage, -15% HP
**2042 - PERPETUAL MOTION REACTOR** (Prototype) - +80% resource efficiency, +45% cooldown reduction, +35-60 HP/energy regen, -30% gun/melee damage, -15% HP

*For full details, see docs/Items-Resource.md*

### TACTICAL MODULES (7 mods, IDs 2043-2049)
*Ammo, accuracy, range, utility*

**2043 - EXTENDED MAGAZINE** (Standard) - +50-100 ammo capacity
**2044 - ACCURACY CALIBRATOR** (Standard) - +20-35% accuracy
**2045 - RANGE EXTENDER** (Standard) - +25-40% range
**2046 - RAPID RELOAD SYSTEM** (Enhanced) - +60-100% reload speed, +40-70 ammo capacity, -10% gun damage
**2047 - PERFECT AIM CORE** (Enhanced) - +35-60% accuracy, +30-50% range, -15% fire rate
**2048 - AMMO FABRICATOR** (Advanced) - +150-250 ammo capacity, +80-130% reload speed, -20% gun damage
**2049 - TACTICAL SUPREMACY MODULE** (Prototype) - +50-80% accuracy, +60-100% range, +3-5 pierce, +100-200 ammo capacity, -30% gun damage, -25% fire rate

*For full details, see docs/Items-Tactical.md*

---

## SYRINGES (50 mods, IDs 3000-3050)

### COMBAT STIMULANTS (10 mods, IDs 3000-3009)
*Damage, attack speed, fire rate, crit*

**3000 - DAMAGE ENHANCEMENT SERUM** (Standard) - +8-12% gun damage
**3001 - FIRE RATE ACCELERATOR** (Standard) - +10-15% fire rate
**3002 - MELEE POWER INJECTION** (Standard) - +10-15% melee damage, +8-12% melee speed
**3003 - ATTACK SPEED CATALYST** (Standard) - +12-18% fire rate, +10-15% melee speed
**3004 - DUAL DAMAGE PROTOCOL** (Enhanced) - +15-25% gun damage, +15-25% melee damage, -8% HP
**3005 - PRECISION PROTOCOL** (Enhanced) - +18-28% crit chance, +0.3-0.6 crit damage, -10% fire rate
**3006 - BURST DAMAGE SERUM** (Enhanced) - +25-40% gun damage, +20-35% melee damage, -12% HP
**3007 - RAPID STRIKE FORMULA** (Advanced) - +30-50% fire rate, +25-40% melee speed, -15% accuracy
**3008 - ESCALATING FURY PROTOCOL** (Advanced) - +3-5% damage per active syringe (stacks with all syringes), -18% HP
**3009 - PERMANENT BERSERK CORE** (Prototype) - +60-100% gun/melee damage, +40-70% fire/melee rate, -25% HP, -20% armor

*For full details, see docs/Syringes-Combat.md*

### DEFENSIVE PROTOCOLS (10 mods, IDs 3010-3019)
*HP, armor, shields, resistances*

**3010 - STRUCTURAL INTEGRITY BOOST** (Standard) - +60-100 HP
**3011 - ARMOR ENHANCEMENT** (Standard) - +50-90 armor
**3012 - SHIELD BOOSTER** (Standard) - +60-100 shield capacity, +10-20 shield regen
**3013 - RESISTANCE INJECTION** (Standard) - +8-12% fire/electric/corruption resistance (all)
**3014 - FORTIFICATION PROTOCOL** (Enhanced) - +120-200 HP, +80-140 armor, -10% speed
**3015 - SHIELD OVERCHARGE** (Enhanced) - +150-250 shield capacity, +30-50 shield regen, -12% HP
**3016 - DAMAGE ABSORPTION SERUM** (Enhanced) - +30-60 damage absorption, +100-180 HP, -10% speed
**3017 - INVULNERABILITY THRESHOLD** (Advanced) - Immune to damage when above 90% HP, +200-350 HP, -15% gun/melee damage
**3018 - REACTIVE THORNS FORMULA** (Advanced) - +50-90 thorns damage, +40-70% reflect damage, -15% gun damage
**3019 - ULTIMATE FORTRESS CORE** (Prototype) - +400-700 HP, +300-500 armor, +40-70% all resistances, -30% speed, -25% gun/melee damage

*For full details, see docs/Syringes-Defensive.md*

### METABOLIC ENHANCERS (10 mods, IDs 3020-3029)
*Regen, stamina, resources, efficiency*

**3020 - REGENERATION ACCELERATOR** (Standard) - +10-18 HP regen/sec
**3021 - ENERGY METABOLISM BOOST** (Standard) - +15-28 energy regen/sec
**3022 - STAMINA OPTIMIZER** (Standard) - +20-35 stamina regen/sec
**3023 - RESOURCE RECLAIMER** (Enhanced) - +15-25% resource efficiency, +12-22 HP/energy regen
**3024 - RAPID RECOVERY FORMULA** (Enhanced) - +25-42 HP regen/sec, +20-38 energy regen/sec, -10% max HP
**3025 - COOLDOWN OPTIMIZER** (Enhanced) - +25-40% cooldown reduction, +20-35% resource efficiency, -12% gun damage
**3026 - PERPETUAL ENERGY CORE** (Advanced) - +40-70 energy regen/sec, +300-500 energy capacity, -15% HP
**3027 - METABOLIC OVERDRIVE** (Advanced) - +35-60 HP/energy/stamina regen, +30-50% cooldown reduction, -18% gun/melee damage
**3028 - LIFESTEAL METABOLISM** (Advanced) - +12-20% lifesteal, +25-45 HP regen/sec, -15% max HP
**3029 - PERPETUAL MOTION REACTOR** (Prototype) - +80% resource efficiency, +45% cooldown reduction, +35-60 HP/energy regen, -30% gun/melee damage, -15% HP

*For full details, see docs/Syringes-Metabolic.md*

### ELEMENTAL INFUSIONS (9 mods, IDs 3030-3038)
*Elemental chance, damage, penetration*

**3030 - THERMAL IGNITION SERUM** (Standard) - +6-10% ignite chance
**3031 - ELECTRIC DISCHARGE SERUM** (Standard) - +6-10% charge chance
**3032 - VIRAL CORRUPTION SERUM** (Standard) - +6-10% corruption chance
**3033 - ELEMENTAL AMPLIFICATION SERUM** (Standard) - +4-8 ignite/charge/corruption damage (all)
**3034 - DUAL-ELEMENT FUSION PROTOCOL** (Enhanced) - +12-18% ignite chance, +12-18% charge chance, -8% gun damage
**3035 - TRI-ELEMENT DAMAGE CATALYST** (Enhanced) - +10-18 ignite/charge/corruption damage (all), -10% fire rate
**3036 - ELEMENTAL PENETRATION INJECTOR** (Advanced) - +15-25% elemental penetration, +8-12% elemental chance (all), -15% armor
**3037 - ELEMENTAL CHAIN REACTION PROTOCOL** (Advanced) - +3-6% elemental damage per active status on player, +2-4% elemental chance per stack, -12% speed
**3038 - OMNI-ELEMENTAL CONVERSION CORE** (Prototype) - +50-80% elemental chance (all), converts 100% gun/melee damage to elemental, -25% fire rate, -20% speed

*For full details, see docs/Syringes-Elemental.md*

### TACTICAL INJECTIONS (8 mods, IDs 3039-3046)
*Accuracy, range, projectile speed, precision*

**3039 - TARGETING OPTIMIZATION SERUM** (Standard) - +5-8% accuracy
**3040 - RANGE EXTENSION SERUM** (Standard) - +8-12% range
**3041 - PROC ZONE EXPANSION SERUM** (Standard) - +10-15% proc range
**3042 - PROJECTILE VELOCITY SERUM** (Standard) - +12-18% projectile speed
**3043 - MULTI-RANGE OPTIMIZATION PROTOCOL** (Enhanced) - +15-25% weapon range, +20-30% melee range, -10% gun/melee damage
**3044 - PRECISION BARRAGE PROTOCOL** (Enhanced) - +1-2 bullets per shot, +12-18% accuracy, -15% fire rate
**3045 - ADAPTIVE TARGETING MATRIX** (Advanced) - +15-25% accuracy, +15-25% range, gains accuracy based on missing accuracy (scales with low accuracy), -12% speed
**3046 - PERFECT PRECISION CORE** (Prototype) - 100% accuracy (never miss), +40-60% range, +50-80% projectile speed, -30% gun damage, -20% fire rate

*For full details, see docs/Syringes-Tactical.md*

### EXOTIC FORMULAS (4 mods, IDs 3047-3050)
*Build-transforming unique mechanics*

**3047 - BERSERKER RAGE PROTOCOL** (Advanced) - +40-70% gun damage when below 50% HP, +50-80% melee damage when below 50% HP, -15% max HP
**3048 - CHAOS VARIANCE INJECTOR** (Advanced) - Random damage variance (10%-190%), +15-25% crit chance, -20% accuracy
**3049 - VELOCITY DAMAGE CONVERTER** (Prototype) - Converts speed to damage (1.5-2.5% damage per 100 speed), -25% base gun/melee damage, -20% HP
**3050 - ARMOR THORNS AMPLIFIER** (Prototype) - Converts armor to thorns (0.8-1.5 thorns per armor point), +40-70% armor, -30% gun damage, -25% melee damage

*For full details, see docs/Syringes-Exotic.md*

---

## MOD DISTRIBUTION SUMMARY

**By Category:**
- Weapons: 55 mods (35%)
- Items: 50 mods (32%)
- Syringes: 50 mods (32%)

**By Rarity:**
- Standard: 70 mods (45%)
- Enhanced: 46 mods (30%)
- Advanced: 28 mods (18%)
- Prototype: 11 mods (7%)

**By Build Archetype (Mods Supporting):**
- Fortress Tank: 52 mods
- Glass Cannon: 47 mods
- Hybrid Berserker: 49 mods
- Elemental Savant: 42 mods
- DoT Specialist: 40 mods
- Precision Sniper: 40 mods
- Speed Demon: 34 mods
- Summoner Commander: 24 mods

**Unique Mechanics:**
- Stack-scaling (Combat Stimulants, Kinetic Accelerator)
- Conditional damage (Berserker items, low-HP bonuses)
- Cross-stat conversion (Speed→Damage, Armor→Thorns, Resistance→Penetration)
- Random variance (Chaos Injector)
- Build transformations (Perfect Precision, Omni-Elemental, Swarm Fabricator)

---

**For complete mod details including exact HEL equations, value ranges, lore notes, and build synergies, see individual class design documents:**
- Weapons-Ballistic.md, Weapons-Energy.md, Weapons-Explosive.md, Weapons-Deployables.md, Weapons-Hybrid.md, Weapons-Melee.md
- Items-Structural.md, Items-Mobility.md, Items-Regeneration.md, Items-Offensive.md, Items-Resistance.md, Items-Resource.md, Items-Tactical.md
- Syringes-Combat.md, Syringes-Defensive.md, Syringes-Metabolic.md, Syringes-Elemental.md, Syringes-Tactical.md, Syringes-Exotic.md

---

**END OF MODS DESCRIPTION DOCUMENT**
