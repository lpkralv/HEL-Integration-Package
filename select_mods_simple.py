#!/usr/bin/env python3
"""
Simple mod selection for archetypes - manually curated based on documentation.
"""
import json
import random

# Set seed for reproducibility
random.seed(42)

# Manually selected mods for each archetype based on documentation review
archetype_selections = {
    'Glass Cannon': [
        {
            'modid': 1006,
            'name': 'CRITICAL MARKSMAN RIFLE',
            'type': 2,
            'rarity': 'Enhanced',
            'desc': '+25-40% crit chance, +0.5-1.0 crit damage multiplier',
            'equation': 'M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +',
            'val1min': 0.25,
            'val1max': 0.40,
            'val2min': 0.5,
            'val2max': 1.0,
            'modweight': 90,
            'trade_offs': '-20% fire rate, -10% ammo capacity'
        },
        {
            'modid': 2024,
            'name': 'CRITICAL AMPLIFICATION CORE',
            'type': 0,
            'rarity': 'Advanced',
            'desc': '+40-60% crit damage, +10-20% crit chance',
            'equation': 'M_CRITDAMAGE = M_CRITDAMAGE val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +',
            'val1min': 0.40,
            'val1max': 0.60,
            'val2min': 0.10,
            'val2max': 0.20,
            'modweight': 45,
            'trade_offs': '-20% HP'
        },
        {
            'modid': 3000,
            'name': 'DAMAGE ENHANCEMENT SERUM',
            'type': 10,
            'rarity': 'Standard',
            'desc': '+8-12% gun damage',
            'equation': 'M_GUNDAMAGE = M_GUNDAMAGE val1 +',
            'val1min': 0.08,
            'val1max': 0.12,
            'val2min': 0,
            'val2max': 0,
            'modweight': 200,
            'trade_offs': 'None'
        },
        {
            'modid': 3001,
            'name': 'RAPID FIRE CATALYST',
            'type': 10,
            'rarity': 'Standard',
            'desc': '+6-10% fire rate',
            'equation': 'M_SHOTSPERSEC = M_SHOTSPERSEC val1 +',
            'val1min': 0.06,
            'val1max': 0.10,
            'val2min': 0,
            'val2max': 0,
            'modweight': 195,
            'trade_offs': 'None'
        }
    ],
    'Fortress Tank': [
        {
            'modid': 2000,
            'name': 'REINFORCED NANITE SHELL',
            'type': 0,
            'rarity': 'Standard',
            'desc': '+15-25% max HP',
            'equation': 'M_HP = M_HP val1 +',
            'val1min': 0.15,
            'val1max': 0.25,
            'val2min': 0,
            'val2max': 0,
            'modweight': 200,
            'trade_offs': 'None'
        },
        {
            'modid': 2001,
            'name': 'ABLATIVE PLATING MATRIX',
            'type': 0,
            'rarity': 'Standard',
            'desc': '+20-35% armor',
            'equation': 'M_ARMOR = M_ARMOR val1 +',
            'val1min': 0.20,
            'val1max': 0.35,
            'val2min': 0,
            'val2max': 0,
            'modweight': 195,
            'trade_offs': 'None'
        },
        {
            'modid': 2006,
            'name': 'REACTIVE DEFENSE PROTOCOLS',
            'type': 0,
            'rarity': 'Enhanced',
            'desc': '+30-50% thorns damage, +100-200 flat thorns',
            'equation': 'M_THORNDAMAGE = M_THORNDAMAGE val1 +; B_THORNDAMAGE = B_THORNDAMAGE val2 +',
            'val1min': 0.30,
            'val1max': 0.50,
            'val2min': 100,
            'val2max': 200,
            'modweight': 85,
            'trade_offs': '-12% movement speed'
        },
        {
            'modid': 3011,
            'name': 'ABLATIVE ARMOR NANITES',
            'type': 10,
            'rarity': 'Standard',
            'desc': '+20-35% armor',
            'equation': 'M_ARMOR = M_ARMOR val1 +',
            'val1min': 0.20,
            'val1max': 0.35,
            'val2min': 0,
            'val2max': 0,
            'modweight': 195,
            'trade_offs': 'None (Parallel to 2001)'
        }
    ],
    'Hybrid Berserker': [
        {
            'modid': 1044,
            'name': 'DUAL-MODE COMBAT PLATFORM',
            'type': 2,
            'rarity': 'Standard',
            'desc': '+12-20% gun damage, +15-25% melee damage',
            'equation': 'M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_MELEEDAMAGE = M_MELEEDAMAGE val2 +',
            'val1min': 0.12,
            'val1max': 0.20,
            'val2min': 0.15,
            'val2max': 0.25,
            'modweight': 190,
            'trade_offs': 'None'
        },
        {
            'modid': 2020,
            'name': 'VAMPIRIC NANITE PROTOCOLS',
            'type': 0,
            'rarity': 'Enhanced',
            'desc': '+8-15% lifesteal on all damage',
            'equation': 'M_LIFESTEAL = M_LIFESTEAL val1 +',
            'val1min': 0.08,
            'val1max': 0.15,
            'val2min': 0,
            'val2max': 0,
            'modweight': 80,
            'trade_offs': '-15% armor'
        },
        {
            'modid': 3006,
            'name': 'BERSERKER RAGE FORMULA',
            'type': 10,
            'rarity': 'Advanced',
            'desc': '+40-70% damage when below 50% HP',
            'equation': 'M_GUNDAMAGE = M_GUNDAMAGE T_HP S_HP 0.5 * < val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP S_HP 0.5 * < val1 * +',
            'val1min': 0.40,
            'val1max': 0.70,
            'val2min': 0,
            'val2max': 0,
            'modweight': 40,
            'trade_offs': 'Conditional (requires <50% HP)'
        },
        {
            'modid': 3047,
            'name': 'LOW-HP DAMAGE AMPLIFIER',
            'type': 10,
            'rarity': 'Prototype',
            'desc': '+0.5-1.0% damage per 1% HP below 50%',
            'equation': 'M_GUNDAMAGE = M_GUNDAMAGE T_HP S_HP 0.5 * - 0.01 / val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP S_HP 0.5 * - 0.01 / val1 * +',
            'val1min': 0.005,
            'val1max': 0.01,
            'val2min': 0,
            'val2max': 0,
            'modweight': 10,
            'trade_offs': '-25% max HP, requires low HP for effectiveness'
        }
    ]
}

# Save to JSON
with open('/home/user/HEL-Integration-Package/selected_mods.json', 'w') as f:
    json.dump(archetype_selections, f, indent=2)

print("ARCHETYPE MOD SELECTIONS")
print("=" * 80)

for archetype, mods in archetype_selections.items():
    print(f"\n{archetype.upper()}")
    print("-" * 80)
    for i, mod in enumerate(mods, 1):
        print(f"\n  {i}. {mod['name']} (ID: {mod['modid']}, {mod['rarity']})")
        print(f"     Type: {mod['type']} | Weight: {mod['modweight']}")
        print(f"     Effects: {mod['desc']}")
        print(f"     Trade-offs: {mod['trade_offs']}")
        print(f"     Equation: {mod['equation']}")

print("\n" + "=" * 80)
print("Selections saved to selected_mods.json")
