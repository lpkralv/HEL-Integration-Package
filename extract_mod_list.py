#!/usr/bin/env python3
"""Extract all mod IDs, names, and types from DELIVERABLE-ModsData.asset"""

import re
import sys

def extract_mods(filename):
    """Extract mod information from asset file."""
    mods = []

    with open(filename, 'r', encoding='utf-8') as f:
        lines = f.readlines()

    current_mod = {}

    for line in lines:
        line = line.rstrip()

        # New mod entry
        if line.strip().startswith('- modid:'):
            if current_mod and 'id' in current_mod:
                mods.append(current_mod)
            current_mod = {}
            modid = line.split(':', 1)[1].strip()
            current_mod['id'] = int(modid)

        # Name field
        elif 'name:' in line and 'uuid' not in line and 'armor' not in line.lower():
            match = re.search(r'name:\s*(.+)', line)
            if match:
                current_mod['name'] = match.group(1).strip()

        # Type field
        elif line.strip().startswith('type:'):
            mod_type = line.split(':', 1)[1].strip()
            current_mod['type'] = int(mod_type)

    # Add last mod
    if current_mod and 'id' in current_mod:
        mods.append(current_mod)

    return mods

def categorize_mods(mods):
    """Categorize mods by type."""
    categories = {}

    for mod in mods:
        mod_type = mod['type']
        if mod_type not in categories:
            categories[mod_type] = []
        categories[mod_type].append(mod)

    return categories

if __name__ == '__main__':
    filename = sys.argv[1] if len(sys.argv) > 1 else 'DELIVERABLE-ModsData.asset'

    mods = extract_mods(filename)
    categories = categorize_mods(mods)

    print(f"Total mods: {len(mods)}\n")

    type_names = {
        0: "Nanites",
        2: "Weapons",
        3: "Items/Equipment",
        4: "Melee",
        10: "Upgrade Nanites",
        20: "Starting Perks",
        30: "Syringes",
    }

    for mod_type in sorted(categories.keys()):
        type_name = type_names.get(mod_type, f"Type {mod_type}")
        print(f"\n{type_name} (Type {mod_type}): {len(categories[mod_type])} items")
        print("=" * 70)

        for mod in sorted(categories[mod_type], key=lambda x: x['id']):
            name = mod.get('name', f'UNNAMED_{mod["id"]}')
            print(f"  {mod['id']:4d}: {name}")

    # Output CSV for image generation
    print("\n\nGenerating mod_list.csv...")
    with open('mod_list.csv', 'w') as f:
        f.write("modid,name,type\n")
        for mod in sorted(mods, key=lambda x: x['id']):
            name = mod.get('name', f'UNNAMED_{mod["id"]}')
            mod_type = mod.get('type', 0)
            f.write(f"{mod['id']},{name},{mod_type}\n")

    print(f"✓ Written {len(mods)} mods to mod_list.csv")
