#!/usr/bin/env python3
"""
parse_stat_ranges.py - Parse stat range definitions into structured data

Parses good-stat-ranges.md and game-breakers.md to extract:
- Viable/Extended/Absolute ranges for each stat
- Default values
- Balance-breaking and crash-risk thresholds
- Create reasonable default values based on ranges

Outputs to JSON for further processing.
"""

import re
import json
import argparse
from typing import Dict, Any, Optional, List


def parse_value(value_str: str) -> Optional[float]:
    """
    Parse a value string to float, handling percentages and special cases.

    Examples:
        "0.05 (5%)" -> 0.05
        "1.0 (100%)" -> 1.0
        "Unknown" -> None
    """
    if not value_str or value_str.strip().lower() in ['unknown', 'n/a', '?']:
        return None

    # Remove percentage and parentheses: "0.05 (5%)" -> "0.05"
    value_str = re.sub(r'\s*\(.*?\)\s*', '', value_str).strip()

    try:
        return float(value_str)
    except ValueError:
        return None


def parse_good_ranges(file_path: str) -> Dict[str, Any]:
    """
    Parse good-stat-ranges.md to extract Viable/Extended/Absolute ranges.

    Returns dict mapping stat names to range data.
    """
    stats = {}

    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Split into stat sections (starts with "### ")
    # Pattern: ### <number>. <STATNAME> (<description>)
    stat_pattern = re.compile(
        r'###\s+\d+\.\s+([A-Z_]+)\s+\([^)]+\)\s*\n'  # Stat name
        r'\*\*Current Default:\*\*\s*(.+?)\s*\n'      # Default value
        r'(?:.*?\n)*?'                                 # Other lines
        r'\|\s*\*\*Viable\*\*\s*\|\s*(.+?)\s*\|\s*(.+?)\s*\|',  # Viable range
        re.MULTILINE | re.DOTALL
    )

    for match in stat_pattern.finditer(content):
        stat_name = match.group(1).strip()
        default_str = match.group(2).strip()
        viable_min_str = match.group(3).strip()
        viable_max_str = match.group(4).strip()

        # Find the table rows for this stat
        # Extract the full table section
        section_start = match.start()
        section_end = content.find('\n---\n', section_start)
        if section_end == -1:
            section_end = content.find('\n### ', section_start + 1)
        if section_end == -1:
            section_end = len(content)

        section = content[section_start:section_end]

        # Parse table rows for Extended and Absolute ranges
        table_rows = re.findall(
            r'\|\s*\*\*([A-Za-z]+)\*\*\s*\|\s*(.+?)\s*\|\s*(.+?)\s*\|',
            section
        )

        ranges = {}
        for row_type, min_val, max_val in table_rows:
            row_type = row_type.lower()
            ranges[row_type] = {
                'min': parse_value(min_val),
                'max': parse_value(max_val)
            }

        # Parse default value
        default_value = parse_value(default_str)

        stats[stat_name] = {
            'default': default_value,
            'viable': ranges.get('viable', {}),
            'extended': ranges.get('extended', {}),
            'absolute': ranges.get('absolute', {})
        }

    return stats


def parse_game_breakers(file_path: str) -> Dict[str, Any]:
    """
    Parse game-breakers.md to extract balance-breaking and crash-risk thresholds.

    Returns dict mapping stat names to breaking thresholds.
    """
    stats = {}

    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Pattern: ### <number>. <STATNAME> (<description>)
    stat_sections = re.split(r'###\s+\d+\.\s+([A-Z_]+)\s+\([^)]+\)', content)

    # Process pairs: stat_sections[i] is stat name, stat_sections[i+1] is content
    for i in range(1, len(stat_sections), 2):
        if i + 1 >= len(stat_sections):
            break

        stat_name = stat_sections[i].strip()
        section_content = stat_sections[i + 1]

        # Extract balance-breaking ranges
        balance_breaking = []
        balance_section = re.search(
            r'\*\*Balance-Breaking Ranges:\*\*(.+?)(?:\*\*Crash-Risk Ranges:|\*\*Recommended|$)',
            section_content,
            re.DOTALL
        )
        if balance_section:
            # Find all bullet points
            balance_points = re.findall(r'-\s*`([^`]+)`\s*-\s*(.+?)(?=\n-|\n\*\*|\Z)',
                                       balance_section.group(1), re.DOTALL)
            balance_breaking = [{'threshold': t.strip(), 'reason': r.strip()}
                               for t, r in balance_points]

        # Extract crash-risk ranges
        crash_risk = []
        crash_section = re.search(
            r'\*\*Crash-Risk Ranges:\*\*(.+?)(?:\*\*Recommended|\Z)',
            section_content,
            re.DOTALL
        )
        if crash_section:
            crash_points = re.findall(r'-\s*`([^`]+)`\s*-\s*(.+?)(?=\n-|\n\*\*|\Z)',
                                     crash_section.group(1), re.DOTALL)
            crash_risk = [{'threshold': t.strip(), 'reason': r.strip()}
                         for t, r in crash_points]

        stats[stat_name] = {
            'balance_breaking': balance_breaking,
            'crash_risk': crash_risk
        }

    return stats


def create_default_values(stat_ranges: Dict[str, Any]) -> Dict[str, float]:
    """
    Create reasonable default stat values based on ranges.

    Strategy:
    - Use specified default if available
    - Otherwise use midpoint of viable range
    - For percentage stats, use 0.05 (5%) if no default
    - For multiplier stats (default ~1.0), use 1.0
    """
    defaults = {}

    for stat_name, data in stat_ranges.items():
        # First try to use specified default
        if data.get('default') is not None:
            defaults[stat_name] = data['default']
            continue

        # Try midpoint of viable range
        viable = data.get('viable', {})
        if viable.get('min') is not None and viable.get('max') is not None:
            defaults[stat_name] = (viable['min'] + viable['max']) / 2
            continue

        # Try extended range midpoint
        extended = data.get('extended', {})
        if extended.get('min') is not None and extended.get('max') is not None:
            defaults[stat_name] = (extended['min'] + extended['max']) / 2
            continue

        # Fallback heuristics based on stat name patterns
        stat_lower = stat_name.lower()
        if any(x in stat_lower for x in ['chance', 'rate', 'probability']):
            defaults[stat_name] = 0.05  # 5% default for probabilities
        elif any(x in stat_lower for x in ['multiplier', 'speed', 'scale']):
            defaults[stat_name] = 1.0  # 1.0 default for multipliers
        elif 'damage' in stat_lower:
            defaults[stat_name] = 10.0  # 10 damage default
        elif 'health' in stat_lower or 'hp' in stat_lower:
            defaults[stat_name] = 100.0  # 100 HP default
        else:
            defaults[stat_name] = 0.0  # Safest fallback

    return defaults


def merge_stat_data(good_ranges: Dict[str, Any], game_breakers: Dict[str, Any]) -> Dict[str, Any]:
    """
    Merge good ranges and game breaker data into unified structure.
    """
    merged = {}

    # Start with all stats from good_ranges
    all_stats = set(good_ranges.keys()) | set(game_breakers.keys())

    for stat_name in all_stats:
        merged[stat_name] = {
            'default': good_ranges.get(stat_name, {}).get('default'),
            'viable': good_ranges.get(stat_name, {}).get('viable', {}),
            'extended': good_ranges.get(stat_name, {}).get('extended', {}),
            'absolute': good_ranges.get(stat_name, {}).get('absolute', {}),
            'balance_breaking': game_breakers.get(stat_name, {}).get('balance_breaking', []),
            'crash_risk': game_breakers.get(stat_name, {}).get('crash_risk', [])
        }

    return merged


def main():
    parser = argparse.ArgumentParser(
        description='Parse stat range definitions from markdown files'
    )
    parser.add_argument('--good-ranges', default='analysis/good-stat-ranges.md',
                       help='Path to good-stat-ranges.md')
    parser.add_argument('--game-breakers', default='analysis/game-breakers.md',
                       help='Path to game-breakers.md')
    parser.add_argument('--output', default='analysis/parsed/stat_ranges.json',
                       help='Output JSON file path')
    parser.add_argument('--defaults-output', default='analysis/parsed/default_stats.json',
                       help='Output file for default stat values')

    args = parser.parse_args()

    print("Parsing good stat ranges...")
    good_ranges = parse_good_ranges(args.good_ranges)
    print(f"  Found {len(good_ranges)} stats with range definitions")

    print("Parsing game-breaking thresholds...")
    game_breakers = parse_game_breakers(args.game_breakers)
    print(f"  Found {len(game_breakers)} stats with breaking thresholds")

    print("Merging stat data...")
    merged_data = merge_stat_data(good_ranges, game_breakers)
    print(f"  Total stats in database: {len(merged_data)}")

    print("Creating default stat values...")
    default_values = create_default_values(merged_data)
    print(f"  Generated {len(default_values)} default values")

    # Save merged stat ranges
    with open(args.output, 'w', encoding='utf-8') as f:
        json.dump(merged_data, f, indent=2)
    print(f"Saved stat ranges to {args.output}")

    # Save default values
    with open(args.defaults_output, 'w', encoding='utf-8') as f:
        json.dump(default_values, f, indent=2)
    print(f"Saved default values to {args.defaults_output}")

    # Print summary
    print("\n=== SUMMARY ===")
    print(f"Stats with viable ranges: {sum(1 for s in merged_data.values() if s['viable'])}")
    print(f"Stats with extended ranges: {sum(1 for s in merged_data.values() if s['extended'])}")
    print(f"Stats with absolute limits: {sum(1 for s in merged_data.values() if s['absolute'])}")
    print(f"Stats with balance-breaking thresholds: {sum(1 for s in merged_data.values() if s['balance_breaking'])}")
    print(f"Stats with crash-risk thresholds: {sum(1 for s in merged_data.values() if s['crash_risk'])}")


if __name__ == '__main__':
    main()
