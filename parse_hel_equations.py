#!/usr/bin/env python3
"""
parse_hel_equations.py - Parse HEL equations into structured database

Parses hel-equations.txt to extract:
- Mod IDs and names
- HEL equations for each mod
- Stats modified by each equation
- Modification types (B_, M_, A_, Z_, U_)
- Parameter dependencies (val1, val2)

Creates reverse index mapping stats to mods.
Outputs to JSON for further processing.
"""

import re
import json
import argparse
from typing import Dict, Any, List, Tuple, Set
from collections import defaultdict


def parse_hel_statement(statement: str) -> Dict[str, Any]:
    """
    Parse a single HEL statement into structured components.

    Example: "M_CRITCHANCE = M_CRITCHANCE val2 +"
    Returns: {
        'lhs': 'M_CRITCHANCE',
        'rhs': 'M_CRITCHANCE val2 +',
        'prefix': 'M_',
        'stat': 'CRITCHANCE',
        'operation': '+',
        'value': 'val2',
        'is_parameter': True
    }
    """
    statement = statement.strip()
    if not statement:
        return None

    # Pattern: LHS = RHS
    parts = statement.split('=', 1)
    if len(parts) != 2:
        return None

    lhs = parts[0].strip()
    rhs = parts[1].strip()

    # Extract prefix and stat from LHS
    # Pattern: PREFIX_STATNAME
    match = re.match(r'([BMAZTUS]_)([A-Z_]+)', lhs)
    if not match:
        return None

    prefix = match.group(1)
    stat = match.group(2)

    # Parse RHS: typically "PREFIX_STATNAME value operation"
    # Examples:
    #   "M_CRITCHANCE val2 +"
    #   "M_GUNDAMAGE 0.2 +"
    #   "B_BULLETSFIRED val1 +"
    #   "B_ENERGYCAPACITY -50 +"

    # Extract operation (last token, usually +, -, *, /)
    tokens = rhs.split()
    if not tokens:
        return None

    operation = tokens[-1] if len(tokens) > 0 else '+'

    # Extract value (second-to-last token before operation)
    value = None
    is_parameter = False
    if len(tokens) >= 2:
        value = tokens[-2]
        # Check if it's a parameter (val1, val2) or a number
        if value.lower().startswith('val'):
            is_parameter = True
        else:
            # Try to parse as number
            try:
                value = float(value)
            except ValueError:
                pass

    return {
        'lhs': lhs,
        'rhs': rhs,
        'prefix': prefix,
        'stat': stat,
        'operation': operation,
        'value': value,
        'is_parameter': is_parameter
    }


def parse_equation(equation: str) -> List[Dict[str, Any]]:
    """
    Parse a full HEL equation into list of statement structures.

    Example: "M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC -val2 +"
    Returns list of parsed statements.
    """
    if not equation:
        return []

    # Split by semicolon
    statements = equation.split(';')

    parsed_statements = []
    for statement in statements:
        parsed = parse_hel_statement(statement)
        if parsed:
            parsed_statements.append(parsed)

    return parsed_statements


def extract_modified_stats(parsed_statements: List[Dict[str, Any]]) -> Dict[str, List[Dict[str, Any]]]:
    """
    Extract all stats modified by the equation.

    Returns dict mapping stat name to list of modifications.
    """
    stats_modified = defaultdict(list)

    for statement in parsed_statements:
        stat = statement['stat']
        stats_modified[stat].append({
            'prefix': statement['prefix'],
            'operation': statement['operation'],
            'value': statement['value'],
            'is_parameter': statement.get('is_parameter', False)
        })

    return dict(stats_modified)


def parse_hel_equations(file_path: str) -> Tuple[Dict[str, Any], Dict[str, List[int]]]:
    """
    Parse hel-equations.txt into structured equation database.

    Returns:
        - mods_db: Dict mapping mod_id -> {name, equation, stats_modified}
        - stat_index: Dict mapping stat_name -> [mod_ids]
    """
    mods_db = {}
    stat_index = defaultdict(set)

    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Split into mod sections
    # Pattern:
    # Mod ID: <id>
    # Name: <name>
    # Equation: <equation>
    # ----...
    mod_pattern = re.compile(
        r'Mod ID:\s*(\d+)\s*\n'
        r'Name:\s*(.+?)\s*\n'
        r'Equation:\s*(.+?)\s*\n',
        re.MULTILINE
    )

    for match in mod_pattern.finditer(content):
        mod_id = match.group(1).strip()
        mod_name = match.group(2).strip()
        equation = match.group(3).strip()

        # Parse equation
        parsed_statements = parse_equation(equation)

        # Extract modified stats
        stats_modified = extract_modified_stats(parsed_statements)

        # Store in mods database
        mods_db[mod_id] = {
            'id': mod_id,
            'name': mod_name,
            'equation': equation,
            'parsed_statements': parsed_statements,
            'stats_modified': stats_modified
        }

        # Update stat index (reverse mapping)
        for stat in stats_modified.keys():
            stat_index[stat].add(int(mod_id))

    # Convert sets to sorted lists for JSON serialization
    stat_index = {stat: sorted(list(mod_ids)) for stat, mod_ids in stat_index.items()}

    return mods_db, stat_index


def generate_summary_stats(mods_db: Dict[str, Any], stat_index: Dict[str, List[int]]) -> Dict[str, Any]:
    """
    Generate summary statistics about the parsed equations.
    """
    total_mods = len(mods_db)
    total_stats = len(stat_index)

    # Count modification types
    prefix_counts = defaultdict(int)
    parameter_usage = defaultdict(int)

    for mod_id, mod_data in mods_db.items():
        for statement in mod_data['parsed_statements']:
            prefix_counts[statement['prefix']] += 1
            if statement.get('is_parameter'):
                param = statement['value']
                parameter_usage[param] += 1

    # Find most modified stats
    most_modified = sorted(stat_index.items(), key=lambda x: len(x[1]), reverse=True)[:10]

    return {
        'total_mods': total_mods,
        'total_stats_modified': total_stats,
        'prefix_usage': dict(prefix_counts),
        'parameter_usage': dict(parameter_usage),
        'most_modified_stats': [{'stat': s, 'mod_count': len(m)} for s, m in most_modified]
    }


def main():
    parser = argparse.ArgumentParser(
        description='Parse HEL equations from text file'
    )
    parser.add_argument('--input', default='analysis/hel-equations.txt',
                       help='Path to hel-equations.txt')
    parser.add_argument('--output', default='analysis/parsed/equations.json',
                       help='Output JSON file for equation database')
    parser.add_argument('--stat-index', default='analysis/parsed/stat_to_mods.json',
                       help='Output JSON file for stat->mods index')
    parser.add_argument('--summary', default='analysis/parsed/equation_summary.json',
                       help='Output JSON file for summary statistics')

    args = parser.parse_args()

    print("Parsing HEL equations...")
    mods_db, stat_index = parse_hel_equations(args.input)
    print(f"  Parsed {len(mods_db)} mods")
    print(f"  Found {len(stat_index)} unique stats modified")

    print("Generating summary statistics...")
    summary = generate_summary_stats(mods_db, stat_index)

    # Save equation database
    with open(args.output, 'w', encoding='utf-8') as f:
        json.dump(mods_db, f, indent=2)
    print(f"Saved equation database to {args.output}")

    # Save stat index
    with open(args.stat_index, 'w', encoding='utf-8') as f:
        json.dump(stat_index, f, indent=2)
    print(f"Saved stat->mods index to {args.stat_index}")

    # Save summary
    with open(args.summary, 'w', encoding='utf-8') as f:
        json.dump(summary, f, indent=2)
    print(f"Saved summary statistics to {args.summary}")

    # Print summary
    print("\n=== SUMMARY ===")
    print(f"Total mods: {summary['total_mods']}")
    print(f"Total stats modified: {summary['total_stats_modified']}")
    print(f"\nPrefix usage:")
    for prefix, count in sorted(summary['prefix_usage'].items()):
        print(f"  {prefix}: {count}")
    print(f"\nParameter usage:")
    for param, count in sorted(summary['parameter_usage'].items()):
        print(f"  {param}: {count}")
    print(f"\nTop 10 most modified stats:")
    for item in summary['most_modified_stats']:
        print(f"  {item['stat']}: {item['mod_count']} mods")


if __name__ == '__main__':
    main()
