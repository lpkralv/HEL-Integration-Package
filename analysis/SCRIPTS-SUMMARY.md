# Required Python Scripts Summary
**Purpose:** Brief descriptions of custom Python scripts needed for equation combination analysis

---

## Core Analysis Scripts (Required)

### 1. `parse_stat_ranges.py`
Parse good-stat-ranges.md and game-breakers.md into structured JSON database containing Viable/Extended/Absolute ranges and balance-breaking/crash-risk thresholds for all stats.

### 2. `parse_hel_equations.py`
Parse hel-equations.txt into structured equation database, extracting mod IDs, names, HEL equations, modified stats, coefficient prefixes (B_/M_/A_/Z_/U_), and create reverse index mapping stats to mods.

### 3. `generate_combinations.py`
Generate and filter promising equation combinations (1-4 mods) using smart strategies: same-stat targeting, synergistic stat pairs, multiplicative stacking, and conflict detection to reduce 26.5M possible combinations to testable subsets.

### 4. `simulate_equation_combos.py`
Simulate HEL equation combinations using coefficient accumulation system, apply the formula `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`, test multiple parameter values (val1/val2), and classify range violations by severity (Critical/Severe/Moderate/Mild).

### 5. `analyze_violation_patterns.py`
Analyze violation results to identify systemic risks: which mods appear most frequently in violations, which stats are most vulnerable, common synergistic combinations, and generate actionable balance recommendations.

---

## Optional Enhancement Scripts

### 6. `visualize_violations.py`
Generate visual charts (bar charts, network graphs) showing violation distributions by severity, stat, and mod combinations for easier insight communication.

### 7. `compile_final_report.py`
Aggregate all analysis results into a comprehensive markdown report with executive summary, critical findings, detailed violation listings, pattern insights, and balance recommendations.

---

## Supporting Utility Scripts

### 8. `validate_hel_syntax.py`
Validate that all 156 HEL equations parse correctly before analysis, catching syntax errors, missing operators, or malformed statements early in the pipeline.

### 9. `export_high_risk_combos.py`
Export high-risk combinations to CSV format for sharing with game designers or importing into spreadsheet tools for further analysis.

---

## Script Interdependencies

```
parse_stat_ranges.py ──┐
                       ├──> generate_combinations.py ──> simulate_equation_combos.py ──> analyze_violation_patterns.py ──> compile_final_report.py
parse_hel_equations.py ┘                                                   │
                                                                            └──> visualize_violations.py
```

---

## Estimated Script Sizes

| Script | Est. Lines of Code | Complexity |
|--------|-------------------|------------|
| parse_stat_ranges.py | ~200-300 | Medium (regex parsing, JSON export) |
| parse_hel_equations.py | ~250-400 | High (HEL syntax parsing, AST building) |
| generate_combinations.py | ~150-250 | Medium (combinatorics, filtering logic) |
| simulate_equation_combos.py | ~300-450 | High (HEL evaluation, coefficient system) |
| analyze_violation_patterns.py | ~200-300 | Medium (statistical analysis, reporting) |
| visualize_violations.py | ~150-200 | Low-Medium (matplotlib/plotly charts) |
| compile_final_report.py | ~100-150 | Low (markdown templating) |

**Total Estimated LOC:** ~1,350-2,050 lines across all scripts

---

## Key Technologies/Libraries

**Core Python Libraries:**
- `json` - Data serialization
- `re` - Regex parsing for markdown/HEL syntax
- `itertools.combinations` - Combination generation
- `collections.defaultdict` - Coefficient accumulation
- `argparse` - Command-line interfaces

**Optional Libraries:**
- `matplotlib`/`plotly` - Visualizations
- `pandas` - Data manipulation (if needed for large datasets)
- `multiprocessing` - Parallel simulation
- `tqdm` - Progress bars for long-running simulations

---

## Expected Runtime Performance

**With Smart Filtering (Recommended):**
- Parsing: ~1-2 minutes
- Combination generation: ~5-10 minutes (targeting ~10,000 combos)
- Simulation: ~30-60 minutes (10,000 combos × 4 parameter scenarios)
- Pattern analysis: ~2-5 minutes
- **Total: ~45-90 minutes**

**Without Filtering (Full 26.5M combinations):**
- Combination generation: ~2-4 hours
- Simulation: ~50-100 hours (parallelization required)
- **Total: ~52-104 hours** (not recommended)

**Recommendation:** Use smart filtering strategies to keep runtime under 2 hours.
