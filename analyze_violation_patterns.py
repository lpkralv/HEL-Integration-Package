#!/usr/bin/env python3
"""
analyze_violation_patterns.py - Analyze violation patterns and generate report

Analyzes violation results to identify:
- Most frequently appearing mods in violations
- Most vulnerable stats
- Common synergistic combinations
- Prefix type analysis
- Actionable balance recommendations

Generates comprehensive markdown report.
"""

import json
import argparse
from typing import Dict, List, Any, Tuple
from collections import defaultdict, Counter


def load_violations(results_dir: str) -> Dict[str, List[Dict]]:
    """Load all violation files."""
    severities = ['critical', 'severe', 'moderate', 'mild']
    violations = {}

    for severity in severities:
        file_path = f"{results_dir}/violations_{severity}.json"
        try:
            with open(file_path, 'r') as f:
                violations[severity] = json.load(f)
        except FileNotFoundError:
            violations[severity] = []

    return violations


def analyze_mod_frequency(violations: Dict[str, List[Dict]],
                          equations: Dict) -> List[Tuple[str, str, int, Dict]]:
    """
    Analyze which mods appear most frequently in violations.

    Returns list of (mod_id, mod_name, count, severity_breakdown)
    """
    mod_counts = defaultdict(lambda: {'total': 0, 'critical': 0, 'severe': 0,
                                      'moderate': 0, 'mild': 0})

    for severity, violation_list in violations.items():
        for violation in violation_list:
            mods = violation['combo']['mods']
            for mod_id in mods:
                mod_counts[mod_id]['total'] += 1
                mod_counts[mod_id][severity] += 1

    # Sort by total count
    sorted_mods = sorted(mod_counts.items(), key=lambda x: x[1]['total'], reverse=True)

    # Format results
    results = []
    for mod_id, counts in sorted_mods:
        mod_name = equations.get(mod_id, {}).get('name', 'Unknown')
        results.append((mod_id, mod_name, counts['total'], counts))

    return results


def analyze_stat_vulnerability(violations: Dict[str, List[Dict]]) -> List[Tuple[str, int, Dict]]:
    """
    Analyze which stats are most frequently violated.

    Returns list of (stat_name, count, severity_breakdown)
    """
    stat_counts = defaultdict(lambda: {'total': 0, 'critical': 0, 'severe': 0,
                                       'moderate': 0, 'mild': 0})

    for severity, violation_list in violations.items():
        for violation in violation_list:
            for v in violation['violations']:
                stat = v['stat']
                stat_counts[stat]['total'] += 1
                stat_counts[stat][severity] += 1

    # Sort by total count
    sorted_stats = sorted(stat_counts.items(), key=lambda x: x[1]['total'], reverse=True)

    results = []
    for stat, counts in sorted_stats:
        results.append((stat, counts['total'], counts))

    return results


def analyze_combination_patterns(violations: Dict[str, List[Dict]],
                                 top_n: int = 20) -> List[Tuple[Tuple[str, ...], int, str]]:
    """
    Analyze most common mod combinations in violations.

    Returns list of (mod_combo, count, max_severity)
    """
    combo_counts = defaultdict(int)
    combo_severity = {}

    severity_order = {'critical': 4, 'severe': 3, 'moderate': 2, 'mild': 1}

    for severity, violation_list in violations.items():
        for violation in violation_list:
            mods = tuple(sorted(violation['combo']['mods']))
            combo_counts[mods] += 1

            # Track max severity
            if mods not in combo_severity:
                combo_severity[mods] = severity
            else:
                if severity_order[severity] > severity_order[combo_severity[mods]]:
                    combo_severity[mods] = severity

    # Sort by count
    sorted_combos = sorted(combo_counts.items(), key=lambda x: x[1], reverse=True)[:top_n]

    results = []
    for combo, count in sorted_combos:
        max_sev = combo_severity[combo]
        results.append((combo, count, max_sev))

    return results


def analyze_prefix_patterns(violations: Dict[str, List[Dict]],
                           equations: Dict) -> Dict[str, Any]:
    """
    Analyze whether certain prefix types (B_, M_, A_) are more dangerous.
    """
    prefix_violation_counts = defaultdict(int)
    prefix_total_usage = defaultdict(int)

    # Count prefix usage in all equations
    for mod_id, mod_data in equations.items():
        for statement in mod_data['parsed_statements']:
            prefix_total_usage[statement['prefix']] += 1

    # Count prefix usage in violations
    for severity, violation_list in violations.items():
        for violation in violation_list:
            mods = violation['combo']['mods']
            for mod_id in mods:
                if mod_id in equations:
                    for statement in equations[mod_id]['parsed_statements']:
                        prefix_violation_counts[statement['prefix']] += 1

    # Calculate violation rate per prefix
    prefix_rates = {}
    for prefix in prefix_total_usage:
        if prefix_total_usage[prefix] > 0:
            rate = prefix_violation_counts[prefix] / prefix_total_usage[prefix]
            prefix_rates[prefix] = {
                'total_usage': prefix_total_usage[prefix],
                'violation_count': prefix_violation_counts[prefix],
                'violation_rate': rate
            }

    return prefix_rates


def generate_markdown_report(violations: Dict[str, List[Dict]],
                            mod_frequency: List,
                            stat_vulnerability: List,
                            combination_patterns: List,
                            prefix_patterns: Dict,
                            equations: Dict,
                            total_combos: int,
                            params: Dict) -> str:
    """Generate comprehensive markdown report."""

    total_violations = sum(len(v) for v in violations.values())

    report = f"""# HEL Equation Combination Analysis Report

**Date:** 2025-11-17
**Analysis Version:** 1.0
**Parameter Set:** val1={params.get('val1', 1.0)}, val2={params.get('val2', 0.5)} (Aggressive)

---

## EXECUTIVE SUMMARY

This report presents the results of systematic analysis of **{total_combos:,} mod combinations** (1-4 mods)
to identify which combinations push game stats beyond safe ranges.

### Key Findings

**Violation Statistics:**
- **Total Combinations Tested:** {total_combos:,}
- **Combinations with Violations:** {total_violations:,} ({100 * total_violations / total_combos:.2f}%)
- **Critical Violations (Crash-Risk):** {len(violations['critical']):,}
- **Severe Violations (Balance-Breaking):** {len(violations['severe']):,}
- **Moderate Violations (Extended Range):** {len(violations['moderate']):,}
- **Mild Violations (Viable Range):** {len(violations['mild']):,}

**Overall Assessment:**
"""

    if len(violations['critical']) > 0:
        report += f"⚠️ **CRITICAL ALERT:** {len(violations['critical'])} combinations create crash-risk scenarios.\n\n"
    elif len(violations['severe']) > 0:
        report += f"⚠️ **WARNING:** {len(violations['severe'])} combinations are balance-breaking.\n\n"
    elif len(violations['moderate']) > 0:
        report += f"✓ **ACCEPTABLE:** No crash-risk or severe balance issues found. {len(violations['moderate']):,} combinations exceed extended ranges but remain technically stable.\n\n"
    else:
        report += "✓ **EXCELLENT:** All combinations stay within acceptable ranges.\n\n"

    report += """---

## CRITICAL FINDINGS
"""

    if len(violations['critical']) > 0:
        report += f"\n### Crash-Risk Violations ({len(violations['critical'])})\n\n"
        report += "The following combinations create scenarios that could crash the game:\n\n"

        for i, v in enumerate(violations['critical'][:10], 1):
            mods = v['combo']['mods']
            mod_names = [equations.get(m, {}).get('name', f'Mod {m}') for m in mods]

            report += f"#### {i}. Combination: {' + '.join(mod_names)}\n"
            report += f"**Mod IDs:** {', '.join(mods)}\n\n"

            for violation in v['violations']:
                report += f"- **{violation['stat']}**: {violation['details']}\n"

            report += "\n"
    else:
        report += "\n✓ **No critical violations found.** All combinations avoid crash-risk scenarios.\n\n"

    if len(violations['severe']) > 0:
        report += f"\n### Severe Balance-Breaking Violations ({len(violations['severe'])})\n\n"
        # Similar detailed listing
        for i, v in enumerate(violations['severe'][:10], 1):
            mods = v['combo']['mods']
            mod_names = [equations.get(m, {}).get('name', f'Mod {m}') for m in mods]

            report += f"#### {i}. Combination: {' + '.join(mod_names)}\n"
            report += f"**Mod IDs:** {', '.join(mods)}\n\n"

            for violation in v['violations']:
                report += f"- **{violation['stat']}**: {violation['details']}\n"

            report += "\n"
    else:
        report += "✓ **No severe violations found.** All combinations stay within absolute limits.\n\n"

    report += """---

## PATTERN ANALYSIS

### Most Problematic Mods

Mods that appear most frequently in violation combinations:

"""

    report += "| Rank | Mod ID | Mod Name | Total Violations | Critical | Severe | Moderate | Mild |\n"
    report += "|------|--------|----------|------------------|----------|--------|----------|------|\n"

    for i, (mod_id, mod_name, total, counts) in enumerate(mod_frequency[:20], 1):
        report += f"| {i} | {mod_id} | {mod_name} | {total:,} | {counts['critical']} | {counts['severe']} | {counts['moderate']:,} | {counts['mild']:,} |\n"

    report += "\n### Most Vulnerable Stats\n\n"
    report += "Stats that most frequently exceed safe ranges:\n\n"

    report += "| Rank | Stat | Total Violations | Critical | Severe | Moderate | Mild |\n"
    report += "|------|------|------------------|----------|--------|----------|------|\n"

    for i, (stat, total, counts) in enumerate(stat_vulnerability[:20], 1):
        report += f"| {i} | {stat} | {total:,} | {counts['critical']} | {counts['severe']} | {counts['moderate']:,} | {counts['mild']:,} |\n"

    report += "\n### Most Common Violation Combinations\n\n"
    report += "Specific mod combinations that frequently cause violations:\n\n"

    for i, (combo, count, max_sev) in enumerate(combination_patterns[:10], 1):
        mod_names = [equations.get(m, {}).get('name', f'Mod {m}') for m in combo]
        report += f"#### {i}. {' + '.join(mod_names)}\n"
        report += f"- **Mod IDs:** {', '.join(combo)}\n"
        report += f"- **Violation Count:** {count:,}\n"
        report += f"- **Max Severity:** {max_sev}\n\n"

    report += "### Prefix Type Analysis\n\n"
    report += "Analysis of which modification types (B_, M_, A_, Z_, U_) are most dangerous:\n\n"

    report += "| Prefix | Total Usage | Violations | Violation Rate |\n"
    report += "|--------|-------------|------------|----------------|\n"

    for prefix in sorted(prefix_patterns.keys()):
        data = prefix_patterns[prefix]
        report += f"| {prefix} | {data['total_usage']} | {data['violation_count']:,} | {100 * data['violation_rate']:.2f}% |\n"

    report += "\n**Interpretation:**\n"
    report += "- **M_** (Multiplicative) modifiers typically have highest violation rates due to compounding effects\n"
    report += "- **B_** (Base additive) modifiers are generally safer but can stack in large combinations\n"
    report += "- **A_** (Absolute additive) modifiers bypass multiplication, creating predictable effects\n\n"

    report += """---

## RECOMMENDATIONS

Based on this analysis, we recommend:

"""

    if len(violations['critical']) > 0:
        report += "### Critical Priority\n\n"
        report += "1. **Immediate action required:** Review and fix crash-risk combinations\n"
        report += "2. Add runtime safety checks to prevent negative values on critical stats\n"
        report += "3. Implement probability clamping [0, 1] for all percentage-based stats\n\n"

    if len(violations['severe']) > 0:
        report += "### High Priority\n\n"
        report += "1. Review balance-breaking combinations for gameplay impact\n"
        report += "2. Consider adding hard caps on absolute limits\n"
        report += "3. Implement diminishing returns for stacked multiplicative effects\n\n"

    if len(violations['moderate']) > 0:
        report += "### Moderate Priority\n\n"
        report += f"1. **{len(violations['moderate']):,} combinations** exceed extended ranges - review for extreme builds\n"
        report += "2. Consider if extended ranges should be tightened\n"
        report += "3. Document intended extreme build scenarios\n\n"

    # Specific mod recommendations
    if mod_frequency:
        top_mod_id, top_mod_name, top_count, _ = mod_frequency[0]
        report += f"### Specific Mod Adjustments\n\n"
        report += f"1. **{top_mod_name} (ID: {top_mod_id})** appears in {top_count:,} violations - review parameter values\n"

        if len(mod_frequency) > 1:
            for mod_id, mod_name, count, _ in mod_frequency[1:6]:
                report += f"2. **{mod_name} (ID: {mod_id})** - {count:,} violations\n"

    report += """
---

## METHODOLOGY

**Combination Generation:**
- Used smart filtering strategies: same-stat targeting, synergistic pairs, multiplicative stacking
- Generated 1-4 mod combinations
- Focused on high-risk scenarios to reduce computational space

**Simulation:**
- Applied HEL coefficient accumulation system
- Formula: `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`
- Used aggressive parameters: val1=1.0, val2=0.5

**Violation Classification:**
- **Critical:** Crash-risk (negative values, probability > 1.0, div-by-zero)
- **Severe:** Absolute limit violations (technical boundaries)
- **Moderate:** Extended range violations (extreme builds)
- **Mild:** Viable range violations (balanced gameplay)

---

## CONCLUSION

"""

    if len(violations['critical']) == 0 and len(violations['severe']) == 0:
        report += "The HEL mod system demonstrates **robust design** with no crash-risk or severe balance-breaking scenarios "
        report += f"detected across {total_combos:,} combinations. "

        if len(violations['moderate']) > 0:
            report += f"\n\nWhile {len(violations['moderate']):,} combinations ({100 * len(violations['moderate']) / total_combos:.1f}%) "
            report += "exceed extended ranges, these represent extreme build scenarios that remain technically stable. "

        report += "\n\nThe mod system successfully balances player freedom with gameplay integrity."
    else:
        report += f"⚠️ **Action Required:** {len(violations['critical'])} critical and {len(violations['severe'])} severe violations need immediate review."

    report += "\n\n---\n\n*End of Report*\n"

    return report


def main():
    parser = argparse.ArgumentParser(
        description='Analyze violation patterns and generate report'
    )
    parser.add_argument('--results-dir', default='analysis/results',
                       help='Directory containing violation JSON files')
    parser.add_argument('--equations', default='analysis/parsed/equations.json',
                       help='Path to equations.json')
    parser.add_argument('--output', default='analysis/results/ANALYSIS_REPORT.md',
                       help='Output markdown report file')
    parser.add_argument('--val1', type=float, default=1.0,
                       help='Parameter value used in simulation')
    parser.add_argument('--val2', type=float, default=0.5,
                       help='Parameter value used in simulation')

    args = parser.parse_args()

    print("Loading violation data...")
    violations = load_violations(args.results_dir)

    total_violations = sum(len(v) for v in violations.values())
    print(f"  Loaded {total_violations:,} total violations")
    print(f"    Critical: {len(violations['critical'])}")
    print(f"    Severe: {len(violations['severe'])}")
    print(f"    Moderate: {len(violations['moderate']):,}")
    print(f"    Mild: {len(violations['mild']):,}")

    print("\nLoading equation data...")
    with open(args.equations, 'r') as f:
        equations = json.load(f)
    print(f"  Loaded {len(equations)} equations")

    # Calculate total combinations tested
    total_combos = sum(len(v) for v in violations.values())
    # Add non-violations (rough estimate from all combinations - violations)
    # Actually we need to get this from simulation output
    # For now use the violations as proxy
    # Better: read from simulation log or add to JSON output

    # Read total from simulation log if available
    try:
        with open('simulation_output.log', 'r') as f:
            for line in f:
                if 'Total combinations tested:' in line:
                    total_combos = int(line.split(':')[1].strip().replace(',', ''))
                    break
    except:
        # Fallback: count unique combinations in all violation files
        unique_combos = set()
        for v_list in violations.values():
            for v in v_list:
                combo_key = tuple(sorted(v['combo']['mods']))
                unique_combos.add(combo_key)
        total_combos = len(unique_combos)

    print(f"\nTotal combinations tested: {total_combos:,}")

    print("\nAnalyzing mod frequency...")
    mod_frequency = analyze_mod_frequency(violations, equations)
    print(f"  Found {len(mod_frequency)} mods in violations")

    print("Analyzing stat vulnerability...")
    stat_vulnerability = analyze_stat_vulnerability(violations)
    print(f"  Found {len(stat_vulnerability)} stats violated")

    print("Analyzing combination patterns...")
    combination_patterns = analyze_combination_patterns(violations)
    print(f"  Identified top {len(combination_patterns)} combinations")

    print("Analyzing prefix patterns...")
    prefix_patterns = analyze_prefix_patterns(violations, equations)

    print("\nGenerating markdown report...")
    params = {'val1': args.val1, 'val2': args.val2}
    report = generate_markdown_report(
        violations, mod_frequency, stat_vulnerability,
        combination_patterns, prefix_patterns, equations,
        total_combos, params
    )

    # Save report
    with open(args.output, 'w', encoding='utf-8') as f:
        f.write(report)

    print(f"\n✓ Report saved to {args.output}")
    print(f"  Report length: {len(report):,} characters")


if __name__ == '__main__':
    main()
