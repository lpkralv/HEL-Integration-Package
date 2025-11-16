#!/usr/bin/env python3
"""
Analyze ModsData.asset for duplicate equations in three passes:
1. Exact string matches
2. Statement ordering differences
3. Semantic equivalence
"""

import re
from collections import defaultdict

def parse_mods_file(filepath):
    """Parse the ModsData.asset file and extract mods."""
    with open(filepath, 'r') as f:
        content = f.read()

    mods = []
    current_mod = {}

    # Split by lines and parse
    lines = content.split('\n')
    in_mods_section = False

    for line in lines:
        # Check if we're in the mods section
        if line.strip() == 'mods:':
            in_mods_section = True
            continue

        if not in_mods_section:
            continue

        # Check for new mod entry
        if re.match(r'\s*-\s+modid:\s*\d+', line):
            # Save previous mod if exists
            if current_mod:
                mods.append(current_mod)
            # Start new mod
            match = re.search(r'modid:\s*(\d+)', line)
            current_mod = {'modid': int(match.group(1))}

        elif current_mod:
            # Parse name
            name_match = re.match(r'\s*name:\s*(.+)', line)
            if name_match:
                current_mod['name'] = name_match.group(1).strip()

            # Parse equation
            equation_match = re.match(r'\s*equation:\s*"(.+)"', line)
            if equation_match:
                current_mod['equation'] = equation_match.group(1).strip()

    # Don't forget the last mod
    if current_mod:
        mods.append(current_mod)

    return mods

def normalize_statement_order(equation):
    """
    Normalize equation by sorting statements (separated by semicolons).
    Removes leading/trailing whitespace and empty statements.
    """
    if not equation:
        return ""

    # Split by semicolon and filter out empty statements
    statements = [s.strip() for s in equation.split(';') if s.strip()]

    # Sort statements
    statements.sort()

    # Rejoin with semicolons
    return '; '.join(statements)

def normalize_whitespace(text):
    """Normalize whitespace in text."""
    return ' '.join(text.split())

def are_semantically_equivalent(eq1, eq2):
    """
    Check if two equations are semantically equivalent.
    This is a simplified version that checks for:
    - Commutative property: A+B = B+A, A*B = B*A
    """
    if not eq1 or not eq2:
        return False

    # Normalize whitespace
    eq1 = normalize_whitespace(eq1)
    eq2 = normalize_whitespace(eq2)

    # If they're identical after normalization, they're equivalent
    if eq1 == eq2:
        return True

    # Split into statements
    stmts1 = [s.strip() for s in eq1.split(';') if s.strip()]
    stmts2 = [s.strip() for s in eq2.split(';') if s.strip()]

    if len(stmts1) != len(stmts2):
        return False

    # For each statement, try to match with normalized versions
    matched = set()
    for s1 in stmts1:
        found = False
        for i, s2 in enumerate(stmts2):
            if i in matched:
                continue

            # Check if statements are equivalent
            if are_statements_equivalent(s1, s2):
                matched.add(i)
                found = True
                break

        if not found:
            return False

    return len(matched) == len(stmts2)

def are_statements_equivalent(stmt1, stmt2):
    """Check if two statements are semantically equivalent."""
    # Normalize whitespace
    stmt1 = normalize_whitespace(stmt1)
    stmt2 = normalize_whitespace(stmt2)

    if stmt1 == stmt2:
        return True

    # Try to handle commutative cases
    # Parse into LHS = RHS
    if '=' not in stmt1 or '=' not in stmt2:
        return stmt1 == stmt2

    parts1 = stmt1.split('=', 1)
    parts2 = stmt2.split('=', 1)

    if len(parts1) != 2 or len(parts2) != 2:
        return stmt1 == stmt2

    lhs1, rhs1 = parts1[0].strip(), parts1[1].strip()
    lhs2, rhs2 = parts2[0].strip(), parts2[1].strip()

    # LHS must match
    if lhs1 != lhs2:
        return False

    # Check if RHS are equivalent
    return are_expressions_equivalent(rhs1, rhs2)

def are_expressions_equivalent(expr1, expr2):
    """Check if two expressions are equivalent (simplified)."""
    expr1 = expr1.strip()
    expr2 = expr2.strip()

    if expr1 == expr2:
        return True

    # Handle commutative operations
    # For addition: "A + B" vs "B + A"
    if '+' in expr1 and '+' in expr2 and '-' not in expr1 and '-' not in expr2:
        # Simple addition case - split and sort
        terms1 = sorted([t.strip() for t in re.split(r'\+', expr1)])
        terms2 = sorted([t.strip() for t in re.split(r'\+', expr2)])
        if terms1 == terms2:
            return True

    # For multiplication: "A * B" vs "B * A"
    if '*' in expr1 and '*' in expr2 and '/' not in expr1 and '/' not in expr2:
        # Simple multiplication case - split and sort
        factors1 = sorted([f.strip() for f in re.split(r'\*', expr1)])
        factors2 = sorted([f.strip() for f in re.split(r'\*', expr2)])
        if factors1 == factors2:
            return True

    return False

def analyze_duplicates(mods):
    """Analyze mods for duplicates in three passes."""

    # Pass 1: Exact string matches
    print("=" * 80)
    print("PASS 1: EXACT STRING MATCHES")
    print("=" * 80)

    exact_matches = defaultdict(list)
    for mod in mods:
        equation = mod.get('equation', '').strip()
        modid = mod.get('modid', 'N/A')
        name = mod.get('name', 'N/A')

        if equation:
            exact_matches[equation].append({
                'modid': modid,
                'name': name
            })

    # Filter to only duplicates
    exact_duplicates = {eq: mods_list for eq, mods_list in exact_matches.items() if len(mods_list) > 1}

    print(f"\nFound {len(exact_duplicates)} duplicate groups with exact string matches\n")

    for i, (equation, mods_list) in enumerate(sorted(exact_duplicates.items()), 1):
        print(f"\nDuplicate Group {i}:")
        print(f"Equation: {equation}")
        print(f"Mod IDs and Names ({len(mods_list)} mods):")
        for mod in sorted(mods_list, key=lambda x: x['modid']):
            print(f"  - ID {mod['modid']}: {mod['name']}")

    # Pass 2: Statement ordering differences
    print("\n" + "=" * 80)
    print("PASS 2: STATEMENT ORDERING DIFFERENCES")
    print("=" * 80)

    normalized_matches = defaultdict(list)
    for mod in mods:
        equation = mod.get('equation', '').strip()
        modid = mod.get('modid', 'N/A')
        name = mod.get('name', 'N/A')

        if equation:
            normalized = normalize_statement_order(equation)
            normalized_matches[normalized].append({
                'modid': modid,
                'name': name,
                'original': equation
            })

    # Filter to only duplicates (and exclude ones already found in Pass 1)
    normalized_duplicates = {}
    for norm_eq, mods_list in normalized_matches.items():
        if len(mods_list) > 1:
            # Check if all originals are the same (already caught in Pass 1)
            originals = set(mod['original'] for mod in mods_list)
            if len(originals) > 1:
                normalized_duplicates[norm_eq] = mods_list

    print(f"\nFound {len(normalized_duplicates)} duplicate groups with statement ordering differences")
    print("(excluding exact matches from Pass 1)\n")

    for i, (norm_equation, mods_list) in enumerate(sorted(normalized_duplicates.items()), 1):
        print(f"\nDuplicate Group {i}:")
        print(f"Normalized: {norm_equation}")
        print(f"Mod IDs and Names ({len(mods_list)} mods):")
        for mod in sorted(mods_list, key=lambda x: x['modid']):
            print(f"  - ID {mod['modid']}: {mod['name']}")
            print(f"    Original: {mod['original']}")

    # Pass 3: Semantic equivalence
    print("\n" + "=" * 80)
    print("PASS 3: SEMANTIC EQUIVALENCE")
    print("=" * 80)

    # Build a list of all unique equations (by normalized statement order)
    unique_equations = []
    equation_to_mods = {}

    for mod in mods:
        equation = mod.get('equation', '').strip()
        modid = mod.get('modid', 'N/A')
        name = mod.get('name', 'N/A')

        if equation:
            normalized = normalize_statement_order(equation)
            if normalized not in equation_to_mods:
                unique_equations.append(normalized)
                equation_to_mods[normalized] = []

            equation_to_mods[normalized].append({
                'modid': modid,
                'name': name,
                'original': equation
            })

    # Find semantic equivalences
    semantic_groups = []
    processed = set()

    for i, eq1 in enumerate(unique_equations):
        if eq1 in processed:
            continue

        group = [eq1]
        for j, eq2 in enumerate(unique_equations[i+1:], i+1):
            if eq2 in processed:
                continue

            if are_semantically_equivalent(eq1, eq2):
                group.append(eq2)
                processed.add(eq2)

        if len(group) > 1:
            semantic_groups.append(group)
            processed.add(eq1)

    print(f"\nFound {len(semantic_groups)} groups with semantic equivalence")
    print("(excluding exact matches and statement ordering differences)\n")

    for i, group in enumerate(semantic_groups, 1):
        print(f"\nSemantic Group {i}:")
        for eq in group:
            mods_list = equation_to_mods[eq]
            print(f"\n  Normalized equation: {eq}")
            print(f"  Mods using this form ({len(mods_list)}):")
            for mod in sorted(mods_list, key=lambda x: x['modid']):
                print(f"    - ID {mod['modid']}: {mod['name']}")
                if mod['original'] != eq:
                    print(f"      Original: {mod['original']}")

    # Summary
    print("\n" + "=" * 80)
    print("SUMMARY")
    print("=" * 80)
    print(f"\nPass 1 (Exact matches): {len(exact_duplicates)} duplicate groups")
    print(f"Pass 2 (Statement ordering): {len(normalized_duplicates)} duplicate groups")
    print(f"Pass 3 (Semantic equivalence): {len(semantic_groups)} duplicate groups")

    total_duplicated_mods_pass1 = sum(len(mods_list) for mods_list in exact_duplicates.values())
    total_duplicated_mods_pass2 = sum(len(mods_list) for mods_list in normalized_duplicates.values())
    total_duplicated_mods_pass3 = sum(sum(len(equation_to_mods[eq]) for eq in group) for group in semantic_groups)

    print(f"\nTotal mods analyzed: {len(mods)}")
    print(f"Mods involved in Pass 1 duplicates: {total_duplicated_mods_pass1}")
    print(f"Mods involved in Pass 2 duplicates: {total_duplicated_mods_pass2}")
    print(f"Mods involved in Pass 3 duplicates: {total_duplicated_mods_pass3}")

if __name__ == '__main__':
    filepath = '/home/user/HEL-Integration-Package/DELIVERABLE-ModsData.asset'
    mods = parse_mods_file(filepath)
    print(f"Parsed {len(mods)} mods from file\n")
    analyze_duplicates(mods)
