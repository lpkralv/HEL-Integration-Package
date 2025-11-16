#!/usr/bin/env python3
"""
Select suitable mods for each archetype based on build synergies.
"""

import yaml
import random

# Set seed for reproducibility
random.seed(42)

# Load the ModsData YAML file
with open('/home/user/HEL-Integration-Package/DELIVERABLE-ModsData.asset', 'r') as f:
    content = f.read()
    # Extract just the YAML data part (skip Unity metadata)
    yaml_start = content.find('  mods:')
    if yaml_start != -1:
        yaml_content = content[yaml_start:]
        # Parse YAML
        data = yaml.safe_load(yaml_content)
        mods = data['mods']

# Define archetype-suitable mods based on system design
archetype_mods = {
    'Glass Cannon': {
        'weapons': [1000, 1001, 1002, 1005, 1006, 1007],  # Assault, Burst, Sniper, Carbine, Crit Marksman, Armor-Piercing
        'items': [2021, 2022, 2023, 2024, 2025, 2026],    # Precision Targeting, Damage Amplifier, Crit Amp, etc.
        'syringes': [3000, 3001, 3002, 3003, 3004, 3005]  # Damage Enhancement, Fire Rate, Ammo, Precision, etc.
    },
    'Fortress Tank': {
        'weapons': [1045, 1046],  # Defensive melee weapons
        'items': [2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008],  # Structural plating, armor, shields
        'syringes': [3010, 3011, 3012, 3013, 3014, 3015]  # HP, Armor, Shield, Defensive
    },
    'Hybrid Berserker': {
        'weapons': [1040, 1041, 1042, 1043, 1044],  # Hybrid weapons
        'items': [2020, 2021, 2022, 2015],  # Mixed offensive/defensive
        'syringes': [3000, 3004, 3006, 3007, 3010, 3020]  # Damage, Lifesteal, mixed
    }
}

# Selected archetypes
archetypes = ['Glass Cannon', 'Fortress Tank', 'Hybrid Berserker']

# Select 4 mods for each archetype
selections = {}
for archetype in archetypes:
    print(f"\n{'='*60}")
    print(f"ARCHETYPE: {archetype}")
    print(f"{'='*60}")

    # Get available mod IDs for this archetype
    available_ids = (
        archetype_mods[archetype].get('weapons', []) +
        archetype_mods[archetype].get('items', []) +
        archetype_mods[archetype].get('syringes', [])
    )

    # Find actual mods from the data
    available_mods = [m for m in mods if m.get('modid') in available_ids]

    # If we don't have enough, supplement with mods that fit the archetype by description
    if len(available_mods) < 4:
        # Add mods by keyword matching in name/desc
        if archetype == 'Glass Cannon':
            keywords = ['DAMAGE', 'CRITICAL', 'CRIT', 'PRECISION', 'MARKSMAN', 'ASSAULT']
        elif archetype == 'Fortress Tank':
            keywords = ['ARMOR', 'SHIELD', 'HP', 'STRUCTURAL', 'DEFENSE', 'PLATING', 'FORTIFICATION']
        elif archetype == 'Hybrid Berserker':
            keywords = ['HYBRID', 'LIFESTEAL', 'BERSERKER', 'MELEE', 'COMBAT']

        for mod in mods:
            if mod.get('modid') not in available_ids:
                name = mod.get('name', '')
                desc = mod.get('desc', '')
                if any(kw in name.upper() or kw in desc.upper() for kw in keywords):
                    available_mods.append(mod)

    # Select 4 random mods from available (or all if less than 4)
    selected = random.sample(available_mods, min(4, len(available_mods)))

    selections[archetype] = selected

    # Print selections
    for i, mod in enumerate(selected, 1):
        print(f"\nMod {i}: {mod.get('name', 'UNKNOWN')} (ID: {mod.get('modid')})")
        print(f"  Type: {mod.get('type')}")
        print(f"  Description: {mod.get('desc', 'N/A')}")
        print(f"  Equation: {mod.get('equation', 'N/A')}")
        print(f"  Val Range: {mod.get('val1min', 0)}-{mod.get('val1max', 0)}")
        if mod.get('val2min', 0) != 0 or mod.get('val2max', 0) != 0:
            print(f"  Val2 Range: {mod.get('val2min', 0)}-{mod.get('val2max', 0)}")
        print(f"  Modweight (Rarity): {mod.get('modweight', 0)}")

# Save selections to file for later use
import json
with open('/home/user/HEL-Integration-Package/selected_mods.json', 'w') as f:
    # Convert to JSON-serializable format
    output = {}
    for archetype, mod_list in selections.items():
        output[archetype] = [{k: v for k, v in m.items() if k != 'uuid'} for m in mod_list]
    json.dump(output, f, indent=2)

print(f"\n{'='*60}")
print("Selections saved to selected_mods.json")
