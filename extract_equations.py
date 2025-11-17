#!/usr/bin/env python3
"""
Extract all HEL equations from ModsData.asset file.
Outputs mod ID, name, and equation for all 156 mods.
"""

import re

def extract_equations(filepath):
    """Extract all equations from the ModsData.asset file."""
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    # Find all mod entries
    # Each mod starts with "- modid:" and contains name and equation fields
    mod_pattern = r'- modid:\s*(\d+).*?name:\s*(.+?)(?:\n.*?)*?equation:\s*"(.+?)"'

    matches = re.findall(mod_pattern, content, re.DOTALL)

    equations = []
    for modid, name, equation in matches:
        equations.append({
            'modid': modid.strip(),
            'name': name.strip(),
            'equation': equation.strip()
        })

    return equations

def main():
    filepath = '/home/user/HEL-Integration-Package/DELIVERABLE-ModsData.asset'
    output_file = '/home/user/HEL-Integration-Package/analysis/hel-equations.txt'

    print(f"Extracting equations from {filepath}...")
    equations = extract_equations(filepath)

    print(f"Found {len(equations)} mods with equations")

    # Write to output file
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("# HEL Equations Extracted from DELIVERABLE-ModsData.asset\n")
        f.write(f"# Total Mods: {len(equations)}\n")
        f.write("# Format: Mod ID | Mod Name | HEL Equation\n")
        f.write("=" * 100 + "\n\n")

        for eq in equations:
            f.write(f"Mod ID: {eq['modid']}\n")
            f.write(f"Name: {eq['name']}\n")
            f.write(f"Equation: {eq['equation']}\n")
            f.write("-" * 100 + "\n\n")

    print(f"\nEquations written to: {output_file}")

    # Display first few for verification
    print("\nFirst 3 mods:")
    for i, eq in enumerate(equations[:3]):
        print(f"\nMod {eq['modid']}: {eq['name']}")
        print(f"  Equation: {eq['equation']}")

    return equations

if __name__ == '__main__':
    equations = main()
