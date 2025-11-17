# Plan: HEL Equation Combination Analysis
**Version:** 1.0
**Date:** 2025-11-17
**Purpose:** Identify combinations of up to 4 HEL equations that push stats from acceptable ranges into game-breaking territory

---

## EXECUTIVE SUMMARY

This plan outlines the methodology to systematically analyze all possible combinations of 1-4 HEL equations (from 156 total mods) to identify which combinations can push game stats beyond safe thresholds into game-breaking ranges.

**Key Metrics:**
- **156 mods** with HEL equations to analyze
- **57+ stats** with defined safe and game-breaking ranges
- **Combination space:** ~156 + 12,090 + 627,880 + 25,915,665 = ~26.5M combinations
- **Priority:** Focus on combinations that affect the same stat(s) for amplification effects

---

## ANALYSIS APPROACH

### Phase 1: Data Extraction & Parsing
Parse the three analysis files into structured data for computational analysis.

**Input Files:**
- `analysis/good-stat-ranges.md` (1401 lines) - Safe range definitions
- `analysis/game-breakers.md` (1234 lines) - Dangerous range definitions
- `analysis/hel-equations.txt` (785 lines) - 156 mod equations

**Output Data Structures:**
1. **Stat Ranges Database** - For each stat:
   - Viable range (min, max)
   - Extended range (min, max)
   - Absolute range (min, max)
   - Balance-breaking thresholds
   - Crash-risk thresholds

2. **Equation Database** - For each mod:
   - Mod ID
   - Mod name
   - Parsed HEL equation
   - List of stats modified
   - Effect type per stat (B_, M_, A_, Z_, U_)
   - Parameter placeholders (val1, val2)

### Phase 2: Equation Impact Analysis
Analyze individual equations to understand their potential impact on stats.

**For each equation:**
1. Parse to identify which stats are modified
2. Determine modification type (Base, Multiplicative, Absolute, Min/Max)
3. Extract coefficient values or parameter dependencies
4. Calculate potential range impact (min/max possible effect)

**Output:** Impact matrix showing which equations affect which stats and by how much.

### Phase 3: Combination Generation & Filtering
Generate and filter combinations to reduce computational complexity.

**Smart Filtering Strategy:**
1. **Single-stat combinations** - Equations that all modify the same stat (highest risk)
2. **Multi-stat synergy** - Equations with known synergistic relationships (e.g., CRITCHANCE + CRITDAMAGE)
3. **Multiplicative stacking** - Combinations with multiple M_ modifiers on same stat
4. **Conflicting modifiers** - Mixed B_/M_/A_ on same stat (complex interactions)

**Pruning Rules:**
- Skip combinations where equations have no overlapping stats
- Prioritize combinations with multiplicative (M_) effects (compound growth)
- Focus on stats with narrow safe ranges (easier to break)

### Phase 4: Simulation & Evaluation
For each promising combination, simulate the effect on base stats.

**Simulation Process:**
1. Start with default stat values
2. Apply equation combination using HEL coefficient system:
   - Accumulate B_ (base additive)
   - Accumulate M_ (multiplicative)
   - Accumulate A_ (absolute additive)
   - Accumulate Z_ (min adjustment)
   - Accumulate U_ (max adjustment)
3. Calculate final value: `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`
4. Check if final value falls into game-breaking ranges

**Parameter Space Exploration:**
- For equations with `val1`, `val2` placeholders, test multiple values:
  - Conservative: val1=0.1, val2=0.05
  - Moderate: val1=0.5, val2=0.25
  - Aggressive: val1=1.0, val2=0.5
  - Extreme: val1=2.0, val2=1.0

### Phase 5: Classification & Reporting
Classify dangerous combinations by severity and type.

**Classification Criteria:**

**CRITICAL (Crash-Risk):**
- Pushes stat below 0 when negative values cause crashes
- Pushes probability stats > 1.0 or < 0
- Creates integer overflow scenarios
- Enables division by zero

**SEVERE (Balance-Breaking):**
- Exceeds Absolute limits (technical boundaries)
- Creates invulnerability or guaranteed success scenarios
- Enables one-shot kills or infinite resources

**MODERATE (Extended Range Violations):**
- Exceeds Extended range but stays within Absolute
- Creates very powerful but technically stable builds

**MILD (Viable Range Violations):**
- Exceeds Viable range but stays within Extended
- Enables strong builds but maintains some balance

**Report Structure:**
```
Combination ID: [mod_id1, mod_id2, mod_id3, mod_id4]
Severity: CRITICAL | SEVERE | MODERATE | MILD
Stats Affected: [stat1, stat2, ...]
Breaking Mechanism: [description]

Stat: CRITCHANCE
  Default: 0.05
  After Combo: 1.25
  Viable Range: [0.0, 0.5]
  Extended Range: [0.0, 0.75]
  Absolute Range: [0.0, 0.95]
  Violation: Exceeds Absolute, > 1.0 (crash-risk)

Equations Applied:
  1. Mod 517: M_CRITCHANCE = M_CRITCHANCE val2 +
  2. Mod 521: M_CRITCHANCE = M_CRITCHANCE val1 +
  3. Mod 534: M_CRITCHANCE = M_CRITCHANCE val1 +
  4. Mod 558: M_CRITCHANCE = M_CRITCHANCE val1 +
```

---

## REQUIRED PYTHON SCRIPTS

### Script 1: `parse_stat_ranges.py`
**Purpose:** Parse good-stat-ranges.md and game-breakers.md into JSON database

**Inputs:**
- `analysis/good-stat-ranges.md`
- `analysis/game-breakers.md`

**Outputs:**
- `analysis/parsed/stat_ranges.json` - Structured stat range data

**Key Functions:**
- `parse_good_ranges()` - Extract Viable/Extended/Absolute ranges
- `parse_game_breakers()` - Extract balance-breaking and crash-risk thresholds
- `merge_stat_data()` - Combine both sources into unified structure

**Data Structure:**
```json
{
  "CRITCHANCE": {
    "default": 0.05,
    "type": "percentage",
    "viable": {"min": 0.0, "max": 0.5},
    "extended": {"min": 0.0, "max": 0.75},
    "absolute": {"min": 0.0, "max": 0.95},
    "balance_breaking": ["> 0.95", "> 0.75"],
    "crash_risk": ["< 0", "> 1.0", "NaN/Inf"]
  }
}
```

### Script 2: `parse_hel_equations.py`
**Purpose:** Parse hel-equations.txt into structured equation database

**Inputs:**
- `analysis/hel-equations.txt`

**Outputs:**
- `analysis/parsed/equations.json` - Structured equation data
- `analysis/parsed/stat_to_mods.json` - Index of which mods affect which stats

**Key Functions:**
- `parse_equation()` - Parse HEL syntax into AST or token list
- `extract_modified_stats()` - Identify all stats modified by equation
- `classify_modification_type()` - Determine B_, M_, A_, Z_, U_ types
- `build_stat_index()` - Create reverse mapping: stat -> [mod_ids]

**Data Structure:**
```json
{
  "mods": {
    "517": {
      "name": "PULSE LASER ARRAY",
      "equation": "B_BULLETSFIRED = B_BULLETSFIRED val1 +; M_CRITCHANCE = M_CRITCHANCE val2 +",
      "stats_modified": {
        "BULLETSFIRED": {"prefix": "B_", "operation": "+", "value": "val1"},
        "CRITCHANCE": {"prefix": "M_", "operation": "+", "value": "val2"}
      }
    }
  },
  "stat_index": {
    "CRITCHANCE": [517, 521, 524, 534, ...]
  }
}
```

### Script 3: `generate_combinations.py`
**Purpose:** Generate and filter promising equation combinations

**Inputs:**
- `analysis/parsed/equations.json`
- `analysis/parsed/stat_to_mods.json`
- Command-line args: combination size (1-4), filtering strategy

**Outputs:**
- `analysis/combinations/combo_1.json` - Single equation combinations
- `analysis/combinations/combo_2.json` - 2-equation combinations
- `analysis/combinations/combo_3.json` - 3-equation combinations
- `analysis/combinations/combo_4.json` - 4-equation combinations

**Filtering Strategies:**
- `--strategy=same-stat` - Only combinations affecting same stat
- `--strategy=synergy` - Known synergistic stat pairs (CRIT+CRITDMG, etc.)
- `--strategy=multiplicative` - Prioritize M_ prefix stacking
- `--strategy=all` - Generate all combinations (warning: 26.5M combos)

**Key Functions:**
- `generate_filtered_combinations(n, strategy)` - Smart combination generation
- `estimate_combination_count()` - Pre-calculate combo space size
- `prioritize_by_risk()` - Sort by likelihood of breaking ranges

### Script 4: `simulate_equation_combos.py`
**Purpose:** Simulate HEL equation combinations and check for range violations

**Inputs:**
- `analysis/parsed/stat_ranges.json`
- `analysis/parsed/equations.json`
- `analysis/combinations/combo_N.json`
- Command-line args: parameter values (val1, val2), base stats file

**Outputs:**
- `analysis/results/violations_critical.json` - Crash-risk violations
- `analysis/results/violations_severe.json` - Balance-breaking violations
- `analysis/results/violations_moderate.json` - Extended range violations
- `analysis/results/violations_mild.json` - Viable range violations
- `analysis/results/summary_report.md` - Human-readable summary

**Key Functions:**
- `load_base_stats()` - Load default stat values
- `apply_hel_combination(stats, combo, params)` - Simulate coefficient system
- `check_range_violations(stat, value, ranges)` - Classify violations
- `generate_violation_report(combos, violations)` - Format results

**Simulation Logic:**
```python
def apply_hel_combination(base_stats, equations, params):
    coeffs = initialize_coefficients()

    for equation in equations:
        # Parse and accumulate coefficients
        for statement in parse_equation(equation):
            target_stat = statement.lhs
            prefix = statement.prefix  # B_, M_, A_, Z_, U_
            value = substitute_params(statement.value, params)

            coeffs[target_stat][prefix] += value

    # Apply HEL formula
    final_stats = {}
    for stat in coeffs:
        S = base_stats[stat]
        B = coeffs[stat]['B_']
        M = coeffs[stat]['M_']
        A = coeffs[stat]['A_']
        Z = coeffs[stat]['Z_']
        U = coeffs[stat]['U_']

        stat_min = base_stats[f"{stat}_min"]
        stat_max = base_stats[f"{stat}_max"]

        final_stats[stat] = min(
            max((S + B) * max(0, 1 + M) + A, stat_min + Z),
            stat_max + U
        )

    return final_stats
```

### Script 5: `analyze_violation_patterns.py`
**Purpose:** Analyze patterns in violations to identify systemic risks

**Inputs:**
- `analysis/results/violations_*.json`

**Outputs:**
- `analysis/results/pattern_analysis.md` - Pattern insights
- `analysis/results/high_risk_mods.json` - Mods frequently in violations
- `analysis/results/high_risk_stats.json` - Stats most vulnerable to violations

**Key Functions:**
- `find_common_mods(violations)` - Identify mods appearing in most violations
- `find_vulnerable_stats(violations)` - Stats most often pushed out of range
- `analyze_synergies(violations)` - Common 2-3 mod combinations
- `suggest_balance_changes()` - Recommend mod value adjustments

**Pattern Analysis:**
- Mod frequency in violations (which mods are most dangerous?)
- Stat vulnerability (which stats are easiest to break?)
- Synergy detection (which mod pairs/triples amplify each other?)
- Coefficient type analysis (are M_ mods more dangerous than B_?)

### Script 6: `visualize_violations.py` (Optional)
**Purpose:** Generate visual charts of violations

**Outputs:**
- `analysis/results/charts/violations_by_severity.png`
- `analysis/results/charts/violations_by_stat.png`
- `analysis/results/charts/high_risk_mods.png`

**Charts:**
- Bar chart: Violation count by severity (Critical/Severe/Moderate/Mild)
- Bar chart: Violation count by stat
- Network graph: Mod combinations and their stat impacts

---

## EXECUTION WORKFLOW

### Stage 1: Setup & Parsing (Estimated: 30 min)
```bash
# Create output directories
mkdir -p analysis/parsed analysis/combinations analysis/results

# Parse stat ranges
python3 parse_stat_ranges.py \
  --good-ranges analysis/good-stat-ranges.md \
  --game-breakers analysis/game-breakers.md \
  --output analysis/parsed/stat_ranges.json

# Parse equations
python3 parse_hel_equations.py \
  --input analysis/hel-equations.txt \
  --output analysis/parsed/equations.json \
  --stat-index analysis/parsed/stat_to_mods.json
```

### Stage 2: Combination Generation (Estimated: 1-2 hours)
```bash
# Generate combinations with smart filtering
# Start with same-stat combinations (highest risk)
python3 generate_combinations.py \
  --equations analysis/parsed/equations.json \
  --stat-index analysis/parsed/stat_to_mods.json \
  --size 2 \
  --strategy same-stat \
  --output analysis/combinations/combo_2_same_stat.json

python3 generate_combinations.py \
  --equations analysis/parsed/equations.json \
  --stat-index analysis/parsed/stat_to_mods.json \
  --size 3 \
  --strategy same-stat \
  --output analysis/combinations/combo_3_same_stat.json

python3 generate_combinations.py \
  --equations analysis/parsed/equations.json \
  --stat-index analysis/parsed/stat_to_mods.json \
  --size 4 \
  --strategy same-stat \
  --output analysis/combinations/combo_4_same_stat.json

# Generate synergy combinations (e.g., CRITCHANCE + CRITDAMAGE)
python3 generate_combinations.py \
  --equations analysis/parsed/equations.json \
  --stat-index analysis/parsed/stat_to_mods.json \
  --size 2-4 \
  --strategy synergy \
  --output analysis/combinations/combo_synergy.json
```

### Stage 3: Simulation & Violation Detection (Estimated: 2-4 hours)
```bash
# Run simulations with multiple parameter scenarios
# Conservative parameters (val1=0.1, val2=0.05)
python3 simulate_equation_combos.py \
  --stat-ranges analysis/parsed/stat_ranges.json \
  --equations analysis/parsed/equations.json \
  --combinations analysis/combinations/combo_*_same_stat.json \
  --params val1=0.1,val2=0.05 \
  --output-dir analysis/results/conservative/

# Aggressive parameters (val1=1.0, val2=0.5)
python3 simulate_equation_combos.py \
  --stat-ranges analysis/parsed/stat_ranges.json \
  --equations analysis/parsed/equations.json \
  --combinations analysis/combinations/combo_*_same_stat.json \
  --params val1=1.0,val2=0.5 \
  --output-dir analysis/results/aggressive/

# Extreme parameters (val1=2.0, val2=1.0)
python3 simulate_equation_combos.py \
  --stat-ranges analysis/parsed/stat_ranges.json \
  --equations analysis/parsed/equations.json \
  --combinations analysis/combinations/combo_*_same_stat.json \
  --params val1=2.0,val2=1.0 \
  --output-dir analysis/results/extreme/
```

### Stage 4: Pattern Analysis (Estimated: 30 min)
```bash
# Analyze violations for patterns
python3 analyze_violation_patterns.py \
  --violations analysis/results/*/violations_*.json \
  --output-patterns analysis/results/pattern_analysis.md \
  --output-high-risk-mods analysis/results/high_risk_mods.json \
  --output-high-risk-stats analysis/results/high_risk_stats.json
```

### Stage 5: Reporting (Estimated: 30 min)
```bash
# Generate visualizations (optional)
python3 visualize_violations.py \
  --violations analysis/results/*/violations_*.json \
  --output-dir analysis/results/charts/

# Compile final report
python3 compile_final_report.py \
  --results-dir analysis/results/ \
  --output analysis/FINAL-REPORT-equation-combinations.md
```

---

## OPTIMIZATION STRATEGIES

### Computational Complexity Reduction

**Challenge:** 26.5M total combinations is computationally expensive.

**Solutions:**
1. **Prioritized Filtering:**
   - Start with same-stat combinations (~10-50 combos per stat, ~2,000 total)
   - Move to 2-stat synergies (~10,000 combos)
   - Only explore full space if high-risk patterns emerge

2. **Early Termination:**
   - If single equation already breaks range, don't test with others
   - Cache intermediate coefficient calculations

3. **Parallel Processing:**
   - Simulate combinations in parallel (multiprocessing)
   - Batch simulations by stat to reuse base values

4. **Incremental Analysis:**
   - Analyze 2-equation combos first
   - Only add 3rd/4th equations if 2-combos show promise

### Parameter Space Reduction

**Challenge:** val1/val2 can take many values.

**Solution:** Test 4 representative scenarios:
- Conservative: 10% of typical values
- Moderate: 50% of typical values
- Aggressive: 100% of typical values (common max)
- Extreme: 200% of typical values (edge case)

---

## DELIVERABLES

### Primary Deliverables
1. **FINAL-REPORT-equation-combinations.md** - Comprehensive violation report
   - Executive summary of findings
   - Critical violations (crash-risk)
   - Severe violations (balance-breaking)
   - Pattern analysis insights
   - Recommended balance changes

2. **violations_critical.json** - Machine-readable critical violations
3. **violations_severe.json** - Machine-readable severe violations
4. **high_risk_mods.json** - Mods frequently causing violations
5. **high_risk_stats.json** - Stats most vulnerable to violations

### Supporting Deliverables
6. All parsed data files (stat_ranges.json, equations.json, etc.)
7. All combination files (combo_*.json)
8. Pattern analysis report (pattern_analysis.md)
9. Visualization charts (optional)

---

## SUCCESS CRITERIA

**The analysis is successful if:**
1. ✅ All 156 mod equations are parsed correctly
2. ✅ All 57+ stats have range definitions loaded
3. ✅ At least 10,000 meaningful combinations are tested
4. ✅ Critical violations (crash-risk) are identified and documented
5. ✅ Severe violations (balance-breaking) are identified and documented
6. ✅ Pattern analysis reveals systemic risks (e.g., "M_CRITCHANCE stacking")
7. ✅ Final report includes actionable balance recommendations

---

## TIMELINE ESTIMATE

| Stage | Duration | Cumulative |
|-------|----------|------------|
| Setup & Parsing | 30 min | 30 min |
| Combination Generation | 1-2 hours | 2.5 hours |
| Simulation & Violation Detection | 2-4 hours | 6.5 hours |
| Pattern Analysis | 30 min | 7 hours |
| Reporting & Visualization | 30 min | 7.5 hours |
| **Total** | **~7.5 hours** | - |

**Note:** Timeline assumes sequential execution. Parallel processing could reduce to ~4-5 hours.

---

## RISK ASSESSMENT

### Technical Risks
1. **HEL Parsing Complexity** - Equations may have edge cases not covered
   - Mitigation: Validate parsing against known equation structures

2. **Computational Limits** - 26M combinations may be too large
   - Mitigation: Use smart filtering, start with high-risk subsets

3. **Parameter Uncertainty** - val1/val2 values are mod-specific
   - Mitigation: Test multiple parameter scenarios

### Analytical Risks
1. **False Positives** - Some violations may be theoretical, not practical
   - Mitigation: Consider mod availability and real-world stacking likelihood

2. **Missing Interactions** - Some violations may require 5+ mods
   - Mitigation: Document as limitation, suggest future 5-6 combo analysis if needed

---

## NEXT STEPS

1. **Review this plan** with stakeholders for approval
2. **Implement Python scripts** (Scripts 1-5 minimum, Script 6 optional)
3. **Execute Stage 1** (parsing) and validate data structures
4. **Execute Stage 2-3** (combination generation and simulation)
5. **Execute Stage 4-5** (pattern analysis and reporting)
6. **Deliver final report** with findings and recommendations
