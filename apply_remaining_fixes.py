#!/usr/bin/env python3
"""
Apply remaining coefficient fixes for all zero-base stats.

This handles the secondary conversions for elemental and resource stats.
"""

import re
import sys
from pathlib import Path


def apply_remaining_fixes(file_path):
    """
    Apply M_ → B_ conversions for remaining zero-base stats.

    Conversions:
    - M_COOLDOWNREDUCTION → B_COOLDOWNREDUCTION (7 instances)
    - M_RESOURCEEFFICIENCY → B_RESOURCEEFFICIENCY (5 instances)
    - M_CORRUPTIONCHANCE → B_CORRUPTIONCHANCE (5 instances)
    - M_CORRUPTIONDAMAGE → B_CORRUPTIONDAMAGE (2 instances)
    - M_ELEMENTALPENETRATION → B_ELEMENTALPENETRATION (1 instance)
    - M_DAMAGEABSORPTION → B_DAMAGEABSORPTION (1 instance)
    - M_MAXHPPERCENTBONUS → B_MAXHPPERCENTBONUS (1 instance)
    """
    print(f"Reading {file_path}...")

    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    original_content = content
    changes = {}

    # Secondary conversions for completeness
    conversions = [
        ('M_COOLDOWNREDUCTION', 'B_COOLDOWNREDUCTION'),
        ('M_RESOURCEEFFICIENCY', 'B_RESOURCEEFFICIENCY'),
        ('M_CORRUPTIONCHANCE', 'B_CORRUPTIONCHANCE'),
        ('M_CORRUPTIONDAMAGE', 'B_CORRUPTIONDAMAGE'),
        ('M_ELEMENTALPENETRATION', 'B_ELEMENTALPENETRATION'),
        ('M_DAMAGEABSORPTION', 'B_DAMAGEABSORPTION'),
        ('M_MAXHPPERCENTBONUS', 'B_MAXHPPERCENTBONUS'),
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
    print("Secondary Coefficient Conversion Summary")
    print("=" * 60)

    total_converted = 0
    for old_coef, stats in changes.items():
        new_coef = old_coef.replace('M_', 'B_')
        if stats['converted'] > 0:
            print(f"\n{old_coef} → {new_coef}:")
            print(f"  Converted: {stats['converted']}")
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

    success = apply_remaining_fixes(file_path)

    if success:
        print("\n✅ All remaining coefficient fixes applied!")
        print("\nNext step:")
        print("  Run validation: python3 validate_zero_base_fixes.py")
        return 0
    else:
        return 1


if __name__ == '__main__':
    sys.exit(main())
