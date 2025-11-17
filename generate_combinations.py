#!/usr/bin/env python3
"""
generate_combinations.py - Generate smart filtered equation combinations

Generates combinations of 1-4 mods using intelligent filtering:
- Same-stat targeting (highest risk)
- Synergistic stat pairs (known interactions)
- Multiplicative stacking (M_ prefix accumulation)
- Mixed prefix combinations (B_/M_/A_ interactions)

Reduces 26.5M total combinations to testable subset (~10,000-50,000).
"""

import json
import argparse
from itertools import combinations
from typing import Dict, List, Set, Tuple, Any
from collections import defaultdict


# Define known synergistic stat pairs
SYNERGY_PAIRS = [
    ('CRITCHANCE', 'CRITDAMAGE'),
    ('GUNDAMAGE', 'SHOTSPERSEC'),
    ('MELEEDAMAGE', 'MELEESPEED'),
    ('HP', 'ARMOR'),
    ('HP', 'HPREGEN'),
    ('PLAYERSPEED', 'DASHCOOLDOWN'),
    ('IGNITECHANCE', 'IGNITEDAMAGE'),
    ('IGNITECHANCE', 'IGNITESPREAD'),
    ('ACCURACY', 'GUNDAMAGE'),
    ('BULLETSFIRED', 'ACCURACY'),
    ('MINIONCOUNT', 'MINIONHP'),
    ('MINIONCOUNT', 'MINIONATTACKSPEED'),
    ('ENERGYCAPACITY', 'ENERGYREGEN'),
]


def load_data(equations_path: str, stat_index_path: str) -> Tuple[Dict, Dict]:
    """Load parsed equation and stat index data."""
    with open(equations_path, 'r') as f:
        equations = json.load(f)
    with open(stat_index_path, 'r') as f:
        stat_index = json.load(f)
    return equations, stat_index


def get_mod_stats(mod_data: Dict[str, Any]) -> Set[str]:
    """Get set of stats modified by a mod."""
    return set(mod_data['stats_modified'].keys())


def get_mod_prefixes(mod_data: Dict[str, Any], stat: str) -> Set[str]:
    """Get set of prefixes used for a specific stat in a mod."""
    prefixes = set()
    if stat in mod_data['stats_modified']:
        for modification in mod_data['stats_modified'][stat]:
            prefixes.add(modification['prefix'])
    return prefixes


def has_multiplicative_modifier(mod_data: Dict[str, Any], stat: str) -> bool:
    """Check if mod has multiplicative (M_) modifier for a stat."""
    prefixes = get_mod_prefixes(mod_data, stat)
    return 'M_' in prefixes


def generate_same_stat_combinations(equations: Dict, stat_index: Dict,
                                   combo_size: int) -> List[Tuple[str, ...]]:
    """
    Generate combinations where all mods affect the same stat.
    Highest risk for pushing stats out of range.
    """
    combinations_list = []

    for stat, mod_ids in stat_index.items():
        # Only consider stats with enough mods
        if len(mod_ids) >= combo_size:
            mod_ids_str = [str(mid) for mid in mod_ids]

            # Generate all combinations of this size
            for combo in combinations(mod_ids_str, combo_size):
                # Add metadata about what stat this combo targets
                combinations_list.append({
                    'mods': combo,
                    'strategy': 'same_stat',
                    'target_stat': stat,
                    'combo_size': combo_size
                })

    return combinations_list


def generate_synergy_combinations(equations: Dict, stat_index: Dict,
                                  combo_size: int) -> List[Dict[str, Any]]:
    """
    Generate combinations targeting synergistic stat pairs.
    Examples: CRITCHANCE + CRITDAMAGE, GUNDAMAGE + SHOTSPERSEC
    """
    combinations_list = []

    for stat1, stat2 in SYNERGY_PAIRS:
        # Get mods affecting each stat
        mods1 = set(str(m) for m in stat_index.get(stat1, []))
        mods2 = set(str(m) for m in stat_index.get(stat2, []))

        # Combine mod pools
        all_mods = mods1 | mods2

        if len(all_mods) >= combo_size:
            # Generate combinations
            for combo in combinations(sorted(all_mods), combo_size):
                # Check that combo includes mods from both stats
                combo_stats = set()
                for mod_id in combo:
                    combo_stats.update(get_mod_stats(equations[mod_id]))

                # Only include if both synergy stats are affected
                if stat1 in combo_stats and stat2 in combo_stats:
                    combinations_list.append({
                        'mods': combo,
                        'strategy': 'synergy',
                        'synergy_pair': [stat1, stat2],
                        'combo_size': combo_size
                    })

    return combinations_list


def generate_multiplicative_stacking(equations: Dict, stat_index: Dict,
                                     combo_size: int) -> List[Dict[str, Any]]:
    """
    Generate combinations with multiple M_ (multiplicative) modifiers on same stat.
    Multiplicative effects compound exponentially - highest danger.
    """
    combinations_list = []

    for stat, mod_ids in stat_index.items():
        # Find mods with M_ prefix for this stat
        mult_mods = []
        for mod_id in mod_ids:
            mod_id_str = str(mod_id)
            if has_multiplicative_modifier(equations[mod_id_str], stat):
                mult_mods.append(mod_id_str)

        # Need at least 2 multiplicative mods to have stacking
        if len(mult_mods) >= max(2, combo_size):
            for combo in combinations(mult_mods, combo_size):
                combinations_list.append({
                    'mods': combo,
                    'strategy': 'multiplicative_stacking',
                    'target_stat': stat,
                    'combo_size': combo_size
                })

    return combinations_list


def generate_mixed_prefix_combinations(equations: Dict, stat_index: Dict,
                                       combo_size: int) -> List[Dict[str, Any]]:
    """
    Generate combinations with mixed B_/M_/A_ prefixes on same stat.
    Complex interactions between additive and multiplicative effects.
    """
    combinations_list = []

    # Only for combos of size 2+
    if combo_size < 2:
        return combinations_list

    for stat, mod_ids in stat_index.items():
        if len(mod_ids) < combo_size:
            continue

        # Categorize mods by prefix type
        by_prefix = defaultdict(list)
        for mod_id in mod_ids:
            mod_id_str = str(mod_id)
            prefixes = get_mod_prefixes(equations[mod_id_str], stat)
            for prefix in prefixes:
                by_prefix[prefix].append(mod_id_str)

        # Only interesting if we have multiple prefix types
        if len(by_prefix) < 2:
            continue

        # Try to get mods from different prefix types
        # For size 2: 1 from each type
        # For size 3+: mix of different types
        all_mods = [str(m) for m in mod_ids]

        for combo in combinations(all_mods, combo_size):
            # Check that combo has mixed prefixes
            combo_prefixes = set()
            for mod_id in combo:
                combo_prefixes.update(get_mod_prefixes(equations[mod_id], stat))

            # Only include if we have at least 2 different prefix types
            if len(combo_prefixes) >= 2:
                combinations_list.append({
                    'mods': combo,
                    'strategy': 'mixed_prefix',
                    'target_stat': stat,
                    'prefix_types': list(combo_prefixes),
                    'combo_size': combo_size
                })

    return combinations_list


def deduplicate_combinations(all_combinations: List[Dict[str, Any]]) -> List[Dict[str, Any]]:
    """
    Remove duplicate combinations (same set of mods).
    Keep the one with highest priority strategy.
    """
    # Strategy priority (higher = more important)
    strategy_priority = {
        'multiplicative_stacking': 4,
        'same_stat': 3,
        'synergy': 2,
        'mixed_prefix': 1
    }

    # Group by mod combination
    combo_map = {}
    for combo_data in all_combinations:
        mods_key = tuple(sorted(combo_data['mods']))

        if mods_key not in combo_map:
            combo_map[mods_key] = combo_data
        else:
            # Keep higher priority strategy
            existing_priority = strategy_priority.get(combo_map[mods_key]['strategy'], 0)
            new_priority = strategy_priority.get(combo_data['strategy'], 0)
            if new_priority > existing_priority:
                combo_map[mods_key] = combo_data

    return list(combo_map.values())


def generate_combinations_for_size(equations: Dict, stat_index: Dict,
                                   combo_size: int, strategies: List[str]) -> List[Dict[str, Any]]:
    """Generate all combinations for a specific size using selected strategies."""
    all_combos = []

    if 'same_stat' in strategies:
        print(f"    Generating same-stat combinations...")
        same_stat = generate_same_stat_combinations(equations, stat_index, combo_size)
        all_combos.extend(same_stat)
        print(f"      Found {len(same_stat)} combinations")

    if 'synergy' in strategies:
        print(f"    Generating synergy combinations...")
        synergy = generate_synergy_combinations(equations, stat_index, combo_size)
        all_combos.extend(synergy)
        print(f"      Found {len(synergy)} combinations")

    if 'multiplicative_stacking' in strategies:
        print(f"    Generating multiplicative stacking combinations...")
        mult_stack = generate_multiplicative_stacking(equations, stat_index, combo_size)
        all_combos.extend(mult_stack)
        print(f"      Found {len(mult_stack)} combinations")

    if 'mixed_prefix' in strategies:
        print(f"    Generating mixed prefix combinations...")
        mixed = generate_mixed_prefix_combinations(equations, stat_index, combo_size)
        all_combos.extend(mixed)
        print(f"      Found {len(mixed)} combinations")

    # Deduplicate
    print(f"    Deduplicating...")
    deduplicated = deduplicate_combinations(all_combos)
    print(f"      Unique combinations: {len(deduplicated)}")

    return deduplicated


def main():
    parser = argparse.ArgumentParser(
        description='Generate smart filtered equation combinations'
    )
    parser.add_argument('--equations', default='analysis/parsed/equations.json',
                       help='Path to equations.json')
    parser.add_argument('--stat-index', default='analysis/parsed/stat_to_mods.json',
                       help='Path to stat_to_mods.json')
    parser.add_argument('--output-dir', default='analysis/combinations',
                       help='Output directory for combination files')
    parser.add_argument('--max-size', type=int, default=4,
                       help='Maximum combination size (default: 4)')
    parser.add_argument('--strategies', nargs='+',
                       default=['same_stat', 'synergy', 'multiplicative_stacking', 'mixed_prefix'],
                       help='Filtering strategies to use')

    args = parser.parse_args()

    print("Loading data...")
    equations, stat_index = load_data(args.equations, args.stat_index)
    print(f"  Loaded {len(equations)} mods")
    print(f"  Loaded {len(stat_index)} stats")

    total_combinations = 0

    for size in range(1, args.max_size + 1):
        print(f"\nGenerating combinations of size {size}...")
        combos = generate_combinations_for_size(equations, stat_index, size, args.strategies)

        # Save to file
        output_file = f"{args.output_dir}/combo_{size}.json"
        with open(output_file, 'w') as f:
            json.dump(combos, f, indent=2)

        print(f"  Saved {len(combos)} combinations to {output_file}")
        total_combinations += len(combos)

    print(f"\n=== SUMMARY ===")
    print(f"Total combinations generated: {total_combinations}")
    print(f"Strategies used: {', '.join(args.strategies)}")


if __name__ == '__main__':
    main()
