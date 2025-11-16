# System Gaps & Opportunities

## Current Stats Summary (38 total)

| Category | Count | Examples |
|----------|-------|----------|
| Movement | 5 | PLAYERSPEED, SPRINTSPEED, JUMPSTRENGTH |
| Health/Defense | 6 | HP, ARMOR, STAMINA |
| Ranged Combat | 6 | GUNDAMAGE, SHOTSPERSEC, ACCURACY |
| Melee Combat | 3 | MELEEDAMAGE, MELEERANGE, MELEESPEED |
| Proc Effects | 2 | PROCRATE, PROCRANGE |
| Elemental | 5 | IGNITECHANCE/DAMAGE, CHARGECHANCE/DAMAGE |
| Resistances | 3 | FIRERESISTANCE, ELECTRICRESISTANCE, CORRUPTIONRESISTANCE |
| Minions | 2 | NUMMINIONS, MINIONTYPE |
| Special/Misc | 6 | BULLETSPLIT, EXPLOSIONRADIUS, AUTOTURRETON |

## Current Mods Summary (45 total)

- **Passive Nanites (11)**: Trade-off mods (damage for proc rate, etc.)
- **Weapons (12)**: SHOTGUN, SNIPER, GRENADE LAUNCHER, minion beacons
- **Common Nanites (11)**: Simple stat boosts (fire rate, damage, speed)
- **Starting Upgrades (11)**: Permanent base stat increases

## Key Gaps

1. **No crafting/modification system** - Mods are static, no player customization
2. **No rarity tiers** - All 45 mods treated equally, no progression framework
3. **Small mod pool** - Only 45 total mods limits build variety
4. **No mod scaling** - Fixed value ranges, no level/difficulty scaling
5. **Limited conditional mechanics** - Few mods use complex IF/THEN logic
6. **Single minion type** - System supports multiple but only 1 implemented
7. **No resistance synergies** - Resistance stats exist but almost no mods interact with them
8. **Limited visual variety** - Most mods are generic "nanite injections"

## Underutilized Mechanics

- **Min/Max Coefficients (Z_/U_)**: Rarely used, could enable stat cap modifications
- **Resistance System**: 3 resistance stats, but minimal mod interaction
- **Minion System**: Infrastructure exists, only 1 minion type active
- **Conditional Logic**: HEL supports IF/THEN/ELSE, but rarely used in mods
- **Random Functions**: RAND() available but underutilized for dynamic effects

## Opportunities: Target Build Archetypes

New mods should enable these specialized builds:

1. **Tank/Resistance Builds**: Stack resistances, modify HP/armor caps, damage reduction
2. **Summoner Builds**: Multiple minion types, minion stat scaling, minion synergies
3. **Glass Cannon Builds**: Extreme damage, severe defense penalties, high-risk gameplay
4. **Hybrid Melee/Ranged**: More cross-stat dependencies beyond current 2 mods
5. **Elemental Specialist**: Deep elemental effect chains (ignite spreading, shock chains)

## Design Direction

Focus new mods on:
- Utilizing resistance mechanics
- Expanding minion variety and synergies
- Creating rarity tiers for progression
- Adding conditional/dynamic effects
- Enabling extreme build specialization through meaningful trade-offs
