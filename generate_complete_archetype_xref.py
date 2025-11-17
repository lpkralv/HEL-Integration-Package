#!/usr/bin/env python3
"""
Generate comprehensive ARCHETYPE_XREF.md - Maps ALL 8 archetypes to their associated mods.
Uses automated analysis of mod stats and descriptions to determine archetype associations.
"""

import re
import subprocess
import sys
from collections import defaultdict

# Define the 8 core archetypes with their key stat patterns and keywords
ARCHETYPES = {
    'Fortress Tank': {
        'stats': ['HP', 'ARMOR', 'SHIELD', 'RESISTANCE', 'THORNDAMAGE', 'REFLECTDAMAGE', 'DAMAGEABSORPTION', 'HPREGEN'],
        'keywords': ['STRUCTURAL', 'DEFENSIVE', 'FORTIFICATION', 'PLATING', 'ARMOR', 'SHIELD', 'HP', 'TANK', 'FORTRESS', 'PROTECTION', 'REGEN', 'THORNS'],
        'identity': 'Maximum survivability, thorns/reflect damage',
        'core_stats': 'HP 2000+, ARMOR 500+, RESISTANCES 70%+, THORNDAMAGE',
        'fantasy': 'Unkillable wall that punishes attackers'
    },
    'Glass Cannon': {
        'stats': ['GUNDAMAGE', 'CRITCHANCE', 'CRITDAMAGE', 'SHOTSPERSEC', 'ACCURACY', 'PIERCINGSHOTS'],
        'keywords': ['DAMAGE', 'CRITICAL', 'CRIT', 'ASSAULT', 'MARKSMAN', 'PRECISION', 'BURST', 'BALLISTIC', 'OFFENSIVE'],
        'identity': 'Extreme offense, minimal defense',
        'core_stats': 'GUNDAMAGE 500+, CRITCHANCE 40%+, CRITDAMAGE 300%+, HP 50-100',
        'fantasy': 'One-shot burst damage dealer'
    },
    'Elemental Savant': {
        'stats': ['IGNITECHANCE', 'CHARGECHANCE', 'CORRUPTIONCHANCE', 'IGNITEDAMAGE', 'CHARGEDAMAGE', 'CORRUPTIONDAMAGE', 'ELEMENTALPENETRATION'],
        'keywords': ['ELEMENTAL', 'IGNITE', 'CHARGE', 'CORRUPTION', 'FIRE', 'ENERGY', 'INFUSION', 'PLASMA', 'QUANTUM'],
        'identity': 'Elemental status effect specialist',
        'core_stats': 'Elemental chances 60%+, elemental damage 200+, ELEMENTALPENETRATION',
        'fantasy': 'Multi-element DoT master'
    },
    'Summoner Commander': {
        'stats': ['NUMMINIONS', 'MINIONDAMAGE', 'MINIONHP', 'MINIONSPEED', 'MINIONARMOR'],
        'keywords': ['MINION', 'DEPLOYABLE', 'SWARM', 'COMMANDER', 'DRONE', 'TURRET', 'FABRICATOR', 'SUMMON'],
        'identity': 'Minion army specialist',
        'core_stats': 'NUMMINIONS 5+, MINIONDAMAGE 200%+, MINIONHP 300+',
        'fantasy': 'Overwhelming swarm tactics'
    },
    'Speed Demon': {
        'stats': ['PLAYERSPEED', 'DASHSPEED', 'SPRINTSPEED', 'DODGECHANCE', 'STAMINACOST', 'STAMINAREGEN'],
        'keywords': ['SPEED', 'MOBILITY', 'DASH', 'DODGE', 'SPRINT', 'AGILITY', 'KINETIC', 'VELOCITY', 'LIGHTWEIGHT'],
        'identity': 'High mobility, hit-and-run tactics',
        'core_stats': 'PLAYERSPEED 500+, DASHSPEED 200%+, DODGECHANCE 40%+',
        'fantasy': 'Untouchable speedster'
    },
    'Hybrid Berserker': {
        'stats': ['MELEEDAMAGE', 'MELEESPEED', 'LIFESTEAL', 'GUNDAMAGE'],
        'keywords': ['BERSERKER', 'MELEE', 'LIFESTEAL', 'HYBRID', 'COMBAT', 'RAGE', 'STRIKE', 'VAMPIRIC'],
        'identity': 'Melee/ranged switching, lifesteal sustain',
        'core_stats': 'GUNDAMAGE 300+, MELEEDAMAGE 400+, LIFESTEAL 20%+, HP 400-600',
        'fantasy': 'Aggressive all-range combatant'
    },
    'DoT Specialist': {
        'stats': ['PROCRATE', 'PROCRANGE', 'EXPLOSIONRADIUS', 'CORRUPTIONSPREADCHANCE', 'IGNITECHANCE', 'CHARGECHANCE'],
        'keywords': ['EXPLOSION', 'SPREAD', 'PROC', 'DOT', 'CHAIN', 'CASCADE', 'RADIUS', 'AOE', 'DENIAL'],
        'identity': 'Area denial, proc chains, status spreading',
        'core_stats': 'PROCRATE high, PROCRANGE 300+, elemental damage 200+',
        'fantasy': 'Battlefield controller'
    },
    'Precision Sniper': {
        'stats': ['ACCURACY', 'RANGE', 'CRITDAMAGE', 'PROJECTILESPEED', 'CRITCHANCE'],
        'keywords': ['PRECISION', 'ACCURACY', 'SNIPER', 'RANGE', 'MARKSMAN', 'SCOPE', 'TARGETING', 'PROJECTILE'],
        'identity': 'Long-range burst precision damage',
        'core_stats': 'ACCURACY 95%+, RANGE 500+, CRITDAMAGE 300%+, PROJECTILESPEED high',
        'fantasy': 'One-shot-one-kill marksman'
    }
}

def extract_mod_info(mod_id, filepath='DELIVERABLE-ModsData.asset'):
    """Extract mod information using findlines.py and sniptext.py"""
    try:
        result = subprocess.run(
            ['python3', 'findlines.py', filepath, f'modid: {mod_id}'],
            capture_output=True,
            text=True,
            check=False
        )

        output = result.stdout
        if 'on 1 line(s):' not in output:
            return None

        match = re.search(r'\[(\d+)\]', output)
        if not match:
            return None

        line_num = int(match.group(1))

        result = subprocess.run(
            ['python3', 'sniptext.py', filepath, str(line_num), str(line_num + 20)],
            capture_output=True,
            text=True,
            check=True
        )

        text = result.stdout
        mod_info = {'modid': mod_id}

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
                if value.startswith('"') and value.endswith('"'):
                    value = value[1:-1]
                mod_info[key] = value

        return mod_info

    except Exception as e:
        print(f"Error extracting mod {mod_id}: {e}", file=sys.stderr)
        return None

def analyze_archetype_fit(mod):
    """Analyze which archetypes a mod supports based on stats and keywords"""
    archetypes = []

    name = mod.get('name', '').upper()
    desc = mod.get('desc', '').upper()
    equation = mod.get('equation', '').upper()

    for archetype_name, archetype_def in ARCHETYPES.items():
        score = 0

        # Check for stat modifications in equation
        for stat in archetype_def['stats']:
            if stat in equation:
                score += 3

        # Check for keywords in name/description
        for keyword in archetype_def['keywords']:
            if keyword in name:
                score += 2
            if keyword in desc:
                score += 1

        # Threshold: need at least score 3 to be considered supporting this archetype
        if score >= 3:
            archetypes.append(archetype_name)

    return archetypes

def get_all_mod_ids():
    """Extract all mod IDs from the ModsData file"""
    try:
        result = subprocess.run(
            ['python3', 'findlines.py', 'DELIVERABLE-ModsData.asset', 'modid:'],
            capture_output=True,
            text=True,
            check=True
        )

        mod_ids = []
        for match in re.finditer(r'\[(\d+)\]', result.stdout):
            mod_ids.append(int(match.group(1)))

        return mod_ids
    except Exception as e:
        print(f"Error getting mod IDs: {e}", file=sys.stderr)
        return []

# Get all mod IDs by reading the file directly
print("Finding all mods in DELIVERABLE-ModsData.asset...", file=sys.stderr)

mod_id_pattern = re.compile(r'^\s*-\s*modid:\s*(\d+)', re.MULTILINE)
all_mods_info = []

with open('DELIVERABLE-ModsData.asset', 'r') as f:
    content = f.read()
    for match in mod_id_pattern.finditer(content):
        mod_id = int(match.group(1))
        all_mods_info.append(mod_id)

print(f"Found {len(all_mods_info)} mods", file=sys.stderr)

# Extract all mods and categorize by archetype
print("Analyzing all mods for archetype associations...", file=sys.stderr)
archetype_to_mods = defaultdict(lambda: {'weapons': [], 'items': [], 'syringes': []})

for i, mod_id in enumerate(all_mods_info):
    if i % 10 == 0:
        print(f"  Processing mod {i+1}/{len(all_mods_info)}...", file=sys.stderr)

    mod = extract_mod_info(mod_id)
    if not mod:
        continue

    # Determine mod category based on modid ranges
    # Weapons: 515-524, 1000-1054
    # Items: 2000-2049
    # Syringes: 3000+
    if (515 <= mod_id <= 524) or (1000 <= mod_id <= 1054):
        category = 'weapons'
    elif 2000 <= mod_id <= 2049:
        category = 'items'
    else:
        category = 'syringes'

    # Analyze which archetypes it fits
    fitting_archetypes = analyze_archetype_fit(mod)

    for archetype in fitting_archetypes:
        archetype_to_mods[archetype][category].append(mod)

print("Generating ARCHETYPE_XREF.md...", file=sys.stderr)

# Generate markdown document
output = []
output.append("# ARCHETYPE CROSS-REFERENCE")
output.append("")
output.append("This document maps each of the 8 core archetypes to the mods designed to fit that archetype's playstyle.")
output.append("")
output.append(f"**Total Archetypes:** {len(ARCHETYPES)}")
output.append("")
output.append("**Source:** Analyzed all {0} mods from DELIVERABLE-ModsData.asset".format(len(all_mods_info)))
output.append("")
output.append("---")
output.append("")

# Process each archetype
for archetype_name in sorted(ARCHETYPES.keys()):
    archetype_def = ARCHETYPES[archetype_name]
    archetype_mods = archetype_to_mods[archetype_name]

    output.append(f"## {archetype_name}")
    output.append("")

    # Count by category
    weapon_count = len(archetype_mods['weapons'])
    item_count = len(archetype_mods['items'])
    syringe_count = len(archetype_mods['syringes'])
    total_count = weapon_count + item_count + syringe_count

    output.append(f"**Total Mods:** {total_count} (Weapons: {weapon_count}, Items: {item_count}, Syringes: {syringe_count})")
    output.append("")

    # Add archetype description
    output.append(f"**Identity:** {archetype_def['identity']}")
    output.append(f"**Core Stats:** {archetype_def['core_stats']}")
    output.append(f"**Fantasy:** {archetype_def['fantasy']}")
    output.append("")

    # Process each category
    for category in ['weapons', 'items', 'syringes']:
        mods = archetype_mods[category]
        if not mods:
            continue

        output.append(f"### {category.capitalize()}")
        output.append("")

        # Sort by mod ID
        mods.sort(key=lambda x: x.get('modid', 0))

        # List each mod with details
        for mod in mods:
            mod_id = mod.get('modid', 'UNKNOWN')
            name = mod.get('name', 'UNKNOWN')

            output.append(f"#### {name} (ID: {mod_id})")
            output.append("")

            mod_type = mod.get('type', 'N/A')
            type_name = {
                '0': 'Weapon',
                '1': 'Item',
                '2': 'Syringe',
                '10': 'Syringe'
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

    output.append("---")
    output.append("")

# Add summary section
output.append("## Summary")
output.append("")
output.append("### Mod Distribution by Archetype")
output.append("")
output.append("| Archetype | Weapons | Items | Syringes | Total |")
output.append("|-----------|---------|-------|----------|-------|")
for archetype_name in sorted(ARCHETYPES.keys()):
    archetype_mods = archetype_to_mods[archetype_name]
    weapon_count = len(archetype_mods['weapons'])
    item_count = len(archetype_mods['items'])
    syringe_count = len(archetype_mods['syringes'])
    total = weapon_count + item_count + syringe_count
    output.append(f"| {archetype_name} | {weapon_count} | {item_count} | {syringe_count} | {total} |")
output.append("")

output.append("### Analysis Methodology")
output.append("")
output.append("Each mod was analyzed for archetype compatibility based on:")
output.append("- **Stat Modifications:** Which stats the mod's HEL equation affects")
output.append("- **Keywords:** Relevant terms in the mod's name and description")
output.append("- **Scoring System:** Mods need a minimum score threshold to be associated with an archetype")
output.append("")
output.append("Note: Many mods support multiple archetypes due to cross-archetype synergies.")
output.append("")

# Write output to file
output_path = '/home/user/HEL-Integration-Package/analysis/ARCHETYPE_XREF.md'
with open(output_path, 'w') as f:
    f.write('\n'.join(output))

print(f"\nGenerated {output_path}", file=sys.stderr)
print(f"Total lines: {len(output)}", file=sys.stderr)
