#!/usr/bin/env python3
"""
simulate_equation_combos.py - Simulate HEL equation combinations

Applies HEL coefficient system to evaluate stat values after mod combinations.
Detects range violations and classifies by severity.

Uses HEL formula: Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
where:
- S = base stat value
- B = base additive coefficient
- M = multiplicative coefficient (percentage)
- A = absolute additive coefficient
- Z = minimum adjustment
- U = maximum adjustment
"""

import json
import argparse
import sys
from typing import Dict, List, Any, Tuple
from collections import defaultdict


class HELSimulator:
    """Simulates HEL equation combinations and detects violations."""

    def __init__(self, stat_ranges: Dict, default_stats: Dict, equations: Dict):
        self.stat_ranges = stat_ranges
        self.default_stats = default_stats
        self.equations = equations

    def initialize_coefficients(self) -> Dict[str, Dict[str, float]]:
        """Initialize coefficient dictionary for all stats."""
        coeffs = defaultdict(lambda: {
            'B_': 0.0,  # Base additive
            'M_': 0.0,  # Multiplicative
            'A_': 0.0,  # Absolute additive
            'Z_': 0.0,  # Min adjustment
            'U_': 0.0,  # Max adjustment
        })
        return coeffs

    def substitute_parameters(self, value: Any, params: Dict[str, float]) -> float:
        """
        Substitute parameter placeholders with actual values.

        Args:
            value: Can be a number or parameter name (val1, val2)
            params: Dict mapping parameter names to values

        Returns:
            Numeric value
        """
        if isinstance(value, (int, float)):
            return float(value)

        if isinstance(value, str):
            # Check if it's a parameter
            if value.lower() in params:
                return params[value.lower()]
            # Try to parse as number
            try:
                return float(value)
            except ValueError:
                # Default to 0 if can't parse
                return 0.0

        return 0.0

    def apply_equation_combination(self, mod_ids: List[str],
                                   params: Dict[str, float]) -> Dict[str, float]:
        """
        Apply a combination of mod equations to base stats.

        Args:
            mod_ids: List of mod IDs to apply
            params: Parameter values (val1, val2)

        Returns:
            Dict mapping stat names to final values
        """
        coeffs = self.initialize_coefficients()

        # Accumulate coefficients from all mods
        for mod_id in mod_ids:
            mod_data = self.equations[mod_id]

            # Process each statement in the equation
            for statement in mod_data['parsed_statements']:
                stat = statement['stat']
                prefix = statement['prefix']
                value = self.substitute_parameters(statement['value'], params)

                # Handle negative values in the equation
                # Example: "B_ENERGYCAPACITY = B_ENERGYCAPACITY -50 +"
                # The -50 is stored as value, operation is +
                # We need to check the RHS for negative signs
                rhs = statement.get('rhs', '')
                if '-' in rhs and value > 0:
                    # Check if the minus is before the value in RHS
                    tokens = rhs.split()
                    for i, token in enumerate(tokens):
                        if token.startswith('-') and len(tokens) > i:
                            # This is a negative value
                            if statement['value'] == token.lstrip('-'):
                                value = -abs(value)
                                break

                # Accumulate coefficient
                coeffs[stat][prefix] += value

        # Apply HEL formula to compute final stat values
        final_stats = {}

        for stat in coeffs:
            # Get base stat value
            S = self.default_stats.get(stat, 0.0)

            # Get coefficients
            B = coeffs[stat]['B_']
            M = coeffs[stat]['M_']
            A = coeffs[stat]['A_']
            Z = coeffs[stat]['Z_']
            U = coeffs[stat]['U_']

            # Get stat range for min/max bounds
            stat_range = self.stat_ranges.get(stat, {})
            absolute_range = stat_range.get('absolute', {})
            stat_min = absolute_range.get('min', 0.0) if absolute_range.get('min') is not None else 0.0
            stat_max = absolute_range.get('max', 999999.0) if absolute_range.get('max') is not None else 999999.0

            # Apply HEL formula: Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
            value = (S + B) * max(0, 1 + M) + A
            value = max(value, stat_min + Z)
            value = min(value, stat_max + U)

            final_stats[stat] = value

        return final_stats

    def check_violation(self, stat: str, value: float) -> Dict[str, Any]:
        """
        Check if a stat value violates any range constraints.

        Returns dict with violation info:
        - severity: 'critical', 'severe', 'moderate', 'mild', or None
        - range_violated: which range was exceeded
        - details: description of violation
        """
        if stat not in self.stat_ranges:
            return {'severity': None}

        stat_range = self.stat_ranges[stat]
        viable = stat_range.get('viable', {})
        extended = stat_range.get('extended', {})
        absolute = stat_range.get('absolute', {})

        # Check for crash-risk conditions
        crash_risks = stat_range.get('crash_risk', [])
        for risk in crash_risks:
            threshold = risk['threshold']
            # Parse threshold conditions
            if '< 0' in threshold and value < 0:
                return {
                    'severity': 'critical',
                    'range_violated': 'crash_risk',
                    'details': f'Negative value ({value:.4f}) - {risk["reason"]}',
                    'threshold': threshold
                }
            if '> 1.0' in threshold and value > 1.0:
                # Check if this is a percentage stat (default near 0-1 range)
                default_val = stat_range.get('default', 0)
                if default_val is not None and 0 <= default_val <= 1:
                    return {
                        'severity': 'critical',
                        'range_violated': 'crash_risk',
                        'details': f'Value > 1.0 ({value:.4f}) for probability stat - {risk["reason"]}',
                        'threshold': threshold
                    }

        # Check absolute limits
        if absolute:
            abs_min = absolute.get('min')
            abs_max = absolute.get('max')
            if abs_min is not None and value < abs_min:
                return {
                    'severity': 'severe',
                    'range_violated': 'absolute',
                    'details': f'Below absolute minimum ({value:.4f} < {abs_min})',
                    'limit': abs_min,
                    'direction': 'below'
                }
            if abs_max is not None and value > abs_max:
                return {
                    'severity': 'severe',
                    'range_violated': 'absolute',
                    'details': f'Above absolute maximum ({value:.4f} > {abs_max})',
                    'limit': abs_max,
                    'direction': 'above'
                }

        # Check extended range
        if extended:
            ext_min = extended.get('min')
            ext_max = extended.get('max')
            if ext_min is not None and value < ext_min:
                return {
                    'severity': 'moderate',
                    'range_violated': 'extended',
                    'details': f'Below extended minimum ({value:.4f} < {ext_min})',
                    'limit': ext_min,
                    'direction': 'below'
                }
            if ext_max is not None and value > ext_max:
                return {
                    'severity': 'moderate',
                    'range_violated': 'extended',
                    'details': f'Above extended maximum ({value:.4f} > {ext_max})',
                    'limit': ext_max,
                    'direction': 'above'
                }

        # Check viable range
        if viable:
            viable_min = viable.get('min')
            viable_max = viable.get('max')
            if viable_min is not None and value < viable_min:
                return {
                    'severity': 'mild',
                    'range_violated': 'viable',
                    'details': f'Below viable minimum ({value:.4f} < {viable_min})',
                    'limit': viable_min,
                    'direction': 'below'
                }
            if viable_max is not None and value > viable_max:
                return {
                    'severity': 'mild',
                    'range_violated': 'viable',
                    'details': f'Above viable maximum ({value:.4f} > {viable_max})',
                    'limit': viable_max,
                    'direction': 'above'
                }

        return {'severity': None}

    def simulate_combination(self, combo_data: Dict[str, Any],
                           params: Dict[str, float]) -> Dict[str, Any]:
        """
        Simulate a single combination and check for violations.

        Returns dict with:
        - combo_data: original combination info
        - final_stats: computed stat values
        - violations: list of violations found
        - max_severity: highest severity level
        """
        mod_ids = combo_data['mods']

        # Apply combination
        final_stats = self.apply_equation_combination(mod_ids, params)

        # Check for violations
        violations = []
        severity_order = {'critical': 4, 'severe': 3, 'moderate': 2, 'mild': 1, None: 0}
        max_severity = None

        for stat, value in final_stats.items():
            violation = self.check_violation(stat, value)

            if violation['severity']:
                violations.append({
                    'stat': stat,
                    'value': value,
                    'default': self.default_stats.get(stat, 0),
                    **violation
                })

                # Track max severity
                if severity_order[violation['severity']] > severity_order[max_severity]:
                    max_severity = violation['severity']

        return {
            'combo': combo_data,
            'final_stats': final_stats,
            'violations': violations,
            'max_severity': max_severity,
            'params': params
        }


def load_combinations(combo_files: List[str]) -> List[Dict[str, Any]]:
    """Load all combination files."""
    all_combos = []
    for file_path in combo_files:
        try:
            with open(file_path, 'r') as f:
                combos = json.load(f)
                all_combos.extend(combos)
        except FileNotFoundError:
            print(f"Warning: {file_path} not found, skipping...")
    return all_combos


def main():
    parser = argparse.ArgumentParser(
        description='Simulate HEL equation combinations and detect violations'
    )
    parser.add_argument('--stat-ranges', default='analysis/parsed/stat_ranges.json',
                       help='Path to stat_ranges.json')
    parser.add_argument('--default-stats', default='analysis/parsed/default_stats.json',
                       help='Path to default_stats.json')
    parser.add_argument('--equations', default='analysis/parsed/equations.json',
                       help='Path to equations.json')
    parser.add_argument('--combos', nargs='+',
                       default=['analysis/combinations/combo_1.json',
                               'analysis/combinations/combo_2.json',
                               'analysis/combinations/combo_3.json',
                               'analysis/combinations/combo_4.json'],
                       help='Combination files to process')
    parser.add_argument('--output-dir', default='analysis/results',
                       help='Output directory for results')
    parser.add_argument('--val1', type=float, default=1.0,
                       help='Parameter value for val1 (default: 1.0 for aggressive)')
    parser.add_argument('--val2', type=float, default=0.5,
                       help='Parameter value for val2 (default: 0.5 for aggressive)')
    parser.add_argument('--limit', type=int, default=None,
                       help='Limit number of combinations to process (for testing)')

    args = parser.parse_args()

    # Load data
    print("Loading data...")
    with open(args.stat_ranges, 'r') as f:
        stat_ranges = json.load(f)
    with open(args.default_stats, 'r') as f:
        default_stats = json.load(f)
    with open(args.equations, 'r') as f:
        equations = json.load(f)

    print(f"  Loaded {len(stat_ranges)} stat ranges")
    print(f"  Loaded {len(default_stats)} default stats")
    print(f"  Loaded {len(equations)} equations")

    # Load combinations
    print("Loading combinations...")
    all_combos = load_combinations(args.combos)
    print(f"  Loaded {len(all_combos)} combinations")

    if args.limit:
        all_combos = all_combos[:args.limit]
        print(f"  Limited to {len(all_combos)} combinations for testing")

    # Initialize simulator
    simulator = HELSimulator(stat_ranges, default_stats, equations)

    # Parameter set
    params = {'val1': args.val1, 'val2': args.val2}
    print(f"\nUsing parameters: val1={params['val1']}, val2={params['val2']}")

    # Simulate all combinations
    print(f"\nSimulating {len(all_combos)} combinations...")
    results_by_severity = {
        'critical': [],
        'severe': [],
        'moderate': [],
        'mild': []
    }

    for i, combo in enumerate(all_combos):
        if (i + 1) % 10000 == 0:
            print(f"  Processed {i + 1}/{len(all_combos)} combinations...")

        result = simulator.simulate_combination(combo, params)

        # Store results by max severity
        if result['max_severity']:
            results_by_severity[result['max_severity']].append(result)

    # Save results
    print("\nSaving results...")
    for severity, results in results_by_severity.items():
        output_file = f"{args.output_dir}/violations_{severity}.json"
        with open(output_file, 'w') as f:
            json.dump(results, f, indent=2)
        print(f"  {severity.upper()}: {len(results)} violations -> {output_file}")

    # Print summary
    print("\n=== SUMMARY ===")
    total_violations = sum(len(v) for v in results_by_severity.values())
    print(f"Total combinations tested: {len(all_combos)}")
    print(f"Combinations with violations: {total_violations}")
    print(f"  Critical (crash-risk): {len(results_by_severity['critical'])}")
    print(f"  Severe (balance-breaking): {len(results_by_severity['severe'])}")
    print(f"  Moderate (extended range): {len(results_by_severity['moderate'])}")
    print(f"  Mild (viable range): {len(results_by_severity['mild'])}")
    print(f"Violation rate: {100 * total_violations / len(all_combos):.2f}%")


if __name__ == '__main__':
    main()
