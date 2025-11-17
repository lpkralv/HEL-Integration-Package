#!/usr/bin/env python3
"""
Apply coefficient fixes to convert M_ → B_ for zero-base stats.

This script updates ModsData.asset to fix multiplicative coefficients
on stats with zero base values.
"""

import re
import sys
from pathlib import Path


def apply_fixes(file_path):
    """
    Apply all M_ → B_ conversions for zero-base stats.

    Conversions:
    - M_LIFESTEAL → B_LIFESTEAL (8 instances)
    - M_DODGECHANCE → B_DODGECHANCE (4 instances)
    - M_REFLECTDAMAGE → B_REFLECTDAMAGE (2 instances)
    """
    print(f"Reading {file_path}...")

    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    original_content = content
    changes = {}

    # Track changes for each conversion
    conversions = [
        ('M_LIFESTEAL', 'B_LIFESTEAL'),
        ('M_DODGECHANCE', 'B_DODGECHANCE'),
        ('M_REFLECTDAMAGE', 'B_REFLECTDAMAGE'),
    ]

    for old_coef, new_coef in conversions:
        # Use word boundaries to avoid partial matches
        pattern = rf'\b{old_coef}\b'
        matches = re.findall(pattern, content)
        count_before = len(matches)

        # Replace all occurrences
        content = re.sub(pattern, new_coef, content)

        # Verify replacement
        matches_after = re.findall(rf'\b{old_coef}\b', content)
        count_after = len(matches_after)

        changes[old_coef] = {
            'before': count_before,
            'after': count_after,
            'converted': count_before - count_after
        }

    # Write back to file
    if content != original_content:
        print(f"\nWriting changes to {file_path}...")
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(content)
        print("✅ File updated successfully")
    else:
        print("⚠️  No changes needed")
        return False

    # Report changes
    print("\n" + "=" * 60)
    print("Coefficient Conversion Summary")
    print("=" * 60)

    total_converted = 0
    for old_coef, stats in changes.items():
        new_coef = old_coef.replace('M_', 'B_')
        print(f"\n{old_coef} → {new_coef}:")
        print(f"  Occurrences before: {stats['before']}")
        print(f"  Occurrences after:  {stats['after']}")
        print(f"  Converted:          {stats['converted']}")

        if stats['after'] > 0:
            print(f"  ⚠️  WARNING: {stats['after']} instances remain!")
        else:
            print(f"  ✅ All instances converted")

        total_converted += stats['converted']

    print("\n" + "=" * 60)
    print(f"Total conversions: {total_converted}")
    print("=" * 60)

    return True


def main():
    """Main entry point."""
    file_path = Path(__file__).parent / 'DELIVERABLE-ModsData.asset'

    if not file_path.exists():
        print(f"❌ ERROR: File not found: {file_path}")
        return 1

    success = apply_fixes(file_path)

    if success:
        print("\n✅ Coefficient fixes applied successfully!")
        print("\nNext steps:")
        print("  1. Update base stat values in StatsData.asset")
        print("  2. Run validation: python3 validate_zero_base_fixes.py")
        return 0
    else:
        return 1


if __name__ == '__main__':
    sys.exit(main())
