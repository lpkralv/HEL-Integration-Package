#!/usr/bin/env python3
"""
Generate ARCHETYPE_XREF.md - Cross-reference document mapping archetypes to their associated mods.
Uses manual text extraction instead of YAML parsing to handle format issues.
"""

import re
import subprocess
import sys

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

def extract_mod_info(mod_id, filepath='DELIVERABLE-ModsData.asset'):
    """Extract mod information using findlines.py and sniptext.py"""
    try:
        # Find the line with this mod ID
        result = subprocess.run(
            ['python3', 'findlines.py', filepath, f'modid: {mod_id}'],
            capture_output=True,
            text=True,
            check=False
        )

        # Parse line numbers from output
        output = result.stdout
        if 'on 1 line(s):' not in output:
            return None

        # Extract line number
        match = re.search(r'\[(\d+)\]', output)
        if not match:
            return None

        line_num = int(match.group(1))

        # Extract ~20 lines starting from that line (enough to get full mod entry)
        result = subprocess.run(
            ['python3', 'sniptext.py', filepath, str(line_num), str(line_num + 20)],
            capture_output=True,
            text=True,
            check=True
        )

        # Parse the extracted text
        text = result.stdout
        mod_info = {'modid': mod_id}

        # Extract fields using regex
        patterns = {
            'name': r'name:\s*(.+)',
            'desc': r'desc:\s*(.+)',
            'equation': r'equation:\s*["\']?(.+?)["\']?\s*$',
            'type': r'type:\s*(\d+)',
            'val1min': r'val1min:\s*(-?\d+\.?\d*)',
            'val1max': r'val1max:\s*(-?\d+\.?\d*)',
            'val2min': r'val2min:\s*(-?\d+\.?\d*)',
            'val2max': r'val2max:\s*(-?\d+\.?\d*)',
            'modweight': r'modweight:\s*(\d+)'
        }

        for key, pattern in patterns.items():
            match = re.search(pattern, text, re.MULTILINE)
            if match:
                value = match.group(1).strip()
                # Remove quotes if present
                if value.startswith('"') and value.endswith('"'):
                    value = value[1:-1]
                mod_info[key] = value

        return mod_info

    except Exception as e:
        print(f"Error extracting mod {mod_id}: {e}", file=sys.stderr)
        return None

# Generate markdown document
print("Generating ARCHETYPE_XREF.md...", file=sys.stderr)
output = []
output.append("# ARCHETYPE CROSS-REFERENCE")
output.append("")
output.append("This document maps each archetype to the mods designed to fit that archetype's playstyle.")
output.append("")
output.append(f"**Total Archetypes:** {len(archetype_mods)}")
output.append("")
output.append("---")
output.append("")

# Process each archetype
for archetype_name in sorted(archetype_mods.keys()):
    print(f"Processing archetype: {archetype_name}", file=sys.stderr)
    archetype = archetype_mods[archetype_name]
    output.append(f"## {archetype_name}")
    output.append("")

    # Collect all mod IDs for this archetype
    all_mod_ids = []
    for category in ['weapons', 'items', 'syringes']:
        if category in archetype:
            all_mod_ids.extend(archetype[category])

    # Count by category
    weapon_count = len(archetype.get('weapons', []))
    item_count = len(archetype.get('items', []))
    syringe_count = len(archetype.get('syringes', []))

    output.append(f"**Total Mods:** {len(all_mod_ids)} (Weapons: {weapon_count}, Items: {item_count}, Syringes: {syringe_count})")
    output.append("")

    # Add archetype description
    if archetype_name == 'Glass Cannon':
        output.append("**Playstyle:** Maximum offensive power at the cost of survivability. Focuses on critical hits, damage amplification, and precision weaponry.")
    elif archetype_name == 'Fortress Tank':
        output.append("**Playstyle:** Maximum defensive capability and survivability. Emphasizes armor, shields, HP, and damage mitigation.")
    elif archetype_name == 'Hybrid Berserker':
        output.append("**Playstyle:** Balanced offense and defense with lifesteal and hybrid combat bonuses. Sustains through dealing damage.")
    output.append("")

    # Process each category
    for category in ['weapons', 'items', 'syringes']:
        if category not in archetype:
            continue

        mod_ids = archetype[category]
        if not mod_ids:
            continue

        output.append(f"### {category.capitalize()}")
        output.append("")

        # List each mod with details
        for mod_id in sorted(mod_ids):
            print(f"  Extracting mod {mod_id}...", file=sys.stderr)
            mod = extract_mod_info(mod_id)

            if mod:
                # Basic info
                output.append(f"#### {mod.get('name', 'UNKNOWN')} (ID: {mod_id})")
                output.append("")

                mod_type = mod.get('type', 'N/A')
                type_name = {
                    '0': 'Weapon',
                    '1': 'Item',
                    '2': 'Syringe'
                }.get(mod_type, f'Type {mod_type}')

                output.append(f"- **Type:** {type_name}")
                output.append(f"- **Description:** {mod.get('desc', 'N/A')}")
                output.append(f"- **Equation:** `{mod.get('equation', 'N/A')}`")

                # Value ranges
                val1min = float(mod.get('val1min', 0))
                val1max = float(mod.get('val1max', 0))
                if val1min != 0 or val1max != 0:
                    output.append(f"- **Value Range:** {val1min} to {val1max}")

                val2min = float(mod.get('val2min', 0))
                val2max = float(mod.get('val2max', 0))
                if val2min != 0 or val2max != 0:
                    output.append(f"- **Value2 Range:** {val2min} to {val2max}")

                # Rarity
                modweight = mod.get('modweight', 'N/A')
                output.append(f"- **Rarity Weight:** {modweight}")

                output.append("")
            else:
                output.append(f"#### MOD ID {mod_id} - NOT FOUND")
                output.append("")
                output.append("- **Status:** Mod definition missing or could not be extracted from ModsData.asset")
                output.append("")

    output.append("---")
    output.append("")

# Add summary section
output.append("## Summary")
output.append("")
output.append("### Mod Distribution by Archetype")
output.append("")
output.append("| Archetype | Weapons | Items | Syringes | Total |")
output.append("|-----------|---------|-------|----------|-------|")
for archetype_name in sorted(archetype_mods.keys()):
    archetype = archetype_mods[archetype_name]
    weapon_count = len(archetype.get('weapons', []))
    item_count = len(archetype.get('items', []))
    syringe_count = len(archetype.get('syringes', []))
    total = weapon_count + item_count + syringe_count
    output.append(f"| {archetype_name} | {weapon_count} | {item_count} | {syringe_count} | {total} |")
output.append("")

# Write output to file
output_path = '/home/user/HEL-Integration-Package/analysis/ARCHETYPE_XREF.md'
with open(output_path, 'w') as f:
    f.write('\n'.join(output))

print(f"\nGenerated {output_path}", file=sys.stderr)
print(f"Total lines: {len(output)}", file=sys.stderr)
