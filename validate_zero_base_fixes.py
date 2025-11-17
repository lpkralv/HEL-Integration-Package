#!/usr/bin/env python3
"""
Zero-Base Multiplicative Mods Validation Script

This script validates that no M_ (multiplicative) coefficients are used on stats
with zero base values in the HEL Integration Package.

Usage:
    python3 validate_zero_base_fixes.py

Returns:
    Exit code 0 if validation passes
    Exit code 1 if violations found
"""

import re
import sys
from pathlib import Path


def load_yaml_value(file_path, key_pattern):
    """
    Extract values from YAML file using simple pattern matching.
    Returns dict of {name: value}.
    """
    results = {}
    current_name = None

    with open(file_path, 'r', encoding='utf-8') as f:
        for line in f:
            # Match stat name
            name_match = re.search(r'^\s*-?\s*name:\s*(\w+)', line)
            if name_match:
                current_name = name_match.group(1)

            # Match value
            value_match = re.search(r'^\s*value:\s*([0-9.]+)', line)
            if value_match and current_name:
                results[current_name] = float(value_match.group(1))

    return results


def find_m_coefficient_usage(file_path, stats_to_check):
    """
    Find all uses of M_<STAT> coefficients in mod equations.
    Returns list of violations: [(line_number, stat_name, line_content)].
    """
    violations = []

    with open(file_path, 'r', encoding='utf-8') as f:
        for line_num, line in enumerate(f, 1):
            for stat in stats_to_check:
                # Pattern: M_STATNAME (word boundary to avoid partial matches)
                pattern = rf'\bM_{stat}\b'
                if re.search(pattern, line):
                    violations.append((line_num, stat, line.strip()))

    return violations


def validate_zero_base_mods(stats_file, mods_file):
    """
    Main validation function.

    Returns:
        (bool, list): (is_valid, list_of_violations)
    """
    print("=" * 80)
    print("Zero-Base Multiplicative Mods Validation")
    print("=" * 80)
    print()

    # Step 1: Load stats and identify zero-base stats
    print(f"📊 Loading stats from: {stats_file}")
    stat_values = load_yaml_value(stats_file, 'value')

    zero_base_stats = [name for name, value in stat_values.items() if value == 0]

    print(f"   Found {len(stat_values)} total stats")
    print(f"   Found {len(zero_base_stats)} zero-base stats:")
    for stat in sorted(zero_base_stats):
        print(f"      - {stat}")
    print()

    # Step 2: Check mods for M_<zero_base_stat> usage
    print(f"🔍 Checking mods in: {mods_file}")
    violations = find_m_coefficient_usage(mods_file, zero_base_stats)

    print(f"   Scanned mod equations for M_ coefficient usage")
    print()

    # Step 3: Report results
    if violations:
        print("❌ VALIDATION FAILED")
        print(f"   Found {len(violations)} violations of zero-base M_ coefficient usage:")
        print()

        # Group violations by stat
        by_stat = {}
        for line_num, stat, line_content in violations:
            if stat not in by_stat:
                by_stat[stat] = []
            by_stat[stat].append((line_num, line_content))

        for stat in sorted(by_stat.keys()):
            print(f"   ⚠️  M_{stat} (base = 0):")
            for line_num, line_content in by_stat[stat][:5]:  # Show first 5
                print(f"      Line {line_num}: {line_content[:100]}")
            if len(by_stat[stat]) > 5:
                print(f"      ... and {len(by_stat[stat]) - 5} more")
            print()

        return False, violations
    else:
        print("✅ VALIDATION PASSED")
        print("   No M_ coefficients found on zero-base stats")
        print()
        return True, []


def validate_specific_fixes(mods_file):
    """
    Validate specific expected fixes from the plan.
    """
    print("=" * 80)
    print("Specific Fix Validation")
    print("=" * 80)
    print()

    checks = {
        'B_LIFESTEAL': r'\bB_LIFESTEAL\b',
        'B_DODGECHANCE': r'\bB_DODGECHANCE\b',
        'B_REFLECTDAMAGE': r'\bB_REFLECTDAMAGE\b',
    }

    results = {}

    with open(mods_file, 'r', encoding='utf-8') as f:
        content = f.read()

        for name, pattern in checks.items():
            matches = re.findall(pattern, content)
            results[name] = len(matches)

    print("Expected B_ coefficient conversions:")
    for name, count in results.items():
        status = "✓" if count > 0 else "✗"
        print(f"   {status} {name}: {count} occurrences")
    print()

    return all(count > 0 for count in results.values())


def main():
    """Main entry point."""
    # Determine file paths
    base_dir = Path(__file__).parent
    stats_file = base_dir / 'DELIVERABLE-StatsData.asset'
    mods_file = base_dir / 'DELIVERABLE-ModsData.asset'

    # Check file existence
    if not stats_file.exists():
        print(f"❌ ERROR: Stats file not found: {stats_file}")
        return 1

    if not mods_file.exists():
        print(f"❌ ERROR: Mods file not found: {mods_file}")
        return 1

    # Run validation
    is_valid, violations = validate_zero_base_mods(stats_file, mods_file)

    # Run specific fix validation (optional, doesn't affect exit code)
    validate_specific_fixes(mods_file)

    # Summary
    print("=" * 80)
    print("Summary")
    print("=" * 80)
    if is_valid:
        print("✅ All validation checks passed!")
        print("   No M_ coefficients on zero-base stats detected.")
        return 0
    else:
        print(f"❌ Validation failed with {len(violations)} violations.")
        print("   Please fix M_ coefficient usage on zero-base stats.")
        print()
        print("Recommended fixes:")
        print("   1. Convert M_LIFESTEAL → B_LIFESTEAL")
        print("   2. Convert M_DODGECHANCE → B_DODGECHANCE")
        print("   3. Convert M_REFLECTDAMAGE → B_REFLECTDAMAGE")
        print("   4. Set ARMOR base value > 0 in StatsData.asset")
        print()
        print("See ZERO_BASE_MODS_FIX_PLAN.md for detailed fix plan.")
        return 1


if __name__ == '__main__':
    sys.exit(main())
