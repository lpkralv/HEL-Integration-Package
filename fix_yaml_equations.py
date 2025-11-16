#!/usr/bin/env python3
"""
Fix any remaining infix notation in the YAML equations.
Converts patterns like "A = A + B" to "A = A B +"
"""

import re

def convert_infix_to_postfix(equation):
    """Convert infix addition/subtraction in equations to postfix."""
    original = equation

    # Pattern: "VAR = VAR + EXPR" → "VAR = VAR EXPR +"
    # This handles cases like "M_X = M_X + val1" or "M_X = M_X + T_Y val1 *"
    equation = re.sub(
        r'([A-Z_]+)\s*=\s*\1\s*\+\s*([^;]+)',
        r'\1 = \1 \2 +',
        equation
    )

    # Pattern: "VAR = VAR - EXPR" → "VAR = VAR -EXPR +" (for negative values)
    # But only if EXPR is a simple number
    equation = re.sub(
        r'([A-Z_]+)\s*=\s*\1\s*-\s*(\d+\.?\d*)\s*([;$])',
        r'\1 = \1 -\2 +\3',
        equation
    )

    if equation != original:
        print(f"  Fixed: {original}")
        print(f"      → {equation}")

    return equation


def fix_yaml_file(filepath='DELIVERABLE-ModsData.asset'):
    """Fix all equations in the YAML file."""
    print(f"Reading {filepath}...")

    with open(filepath, 'r', encoding='utf-8') as f:
        lines = f.readlines()

    fixed_count = 0
    new_lines = []

    for line in lines:
        if line.strip().startswith('equation:'):
            # Extract the equation content
            match = re.match(r'(\s+equation:\s*")(.*?)(")', line)
            if match:
                prefix, equation, suffix = match.groups()
                new_equation = convert_infix_to_postfix(equation)
                if new_equation != equation:
                    fixed_count += 1
                new_lines.append(f'{prefix}{new_equation}{suffix}\n')
            else:
                new_lines.append(line)
        else:
            new_lines.append(line)

    print(f"\nWriting corrected YAML...")
    with open(filepath, 'w', encoding='utf-8') as f:
        f.writelines(new_lines)

    print(f"\nFixed {fixed_count} equations")
    return fixed_count


if __name__ == '__main__':
    fix_yaml_file('/home/user/HEL-Integration-Package/DELIVERABLE-ModsData.asset')
    print("\nDone!")
