# HEL Equation Combination Analysis Report

**Date:** 2025-11-17
**Analysis Version:** 1.0
**Parameter Set:** val1=1.0, val2=0.5 (Aggressive)

---

## EXECUTIVE SUMMARY

This report presents the results of systematic analysis of **1,780,064 mod combinations** (1-4 mods)
to identify which combinations push game stats beyond safe ranges.

### Key Findings

**Violation Statistics:**
- **Total Combinations Tested:** 1,780,064
- **Combinations with Violations:** 1,305,386 (73.33%)
- **Critical Violations (Crash-Risk):** 0
- **Severe Violations (Balance-Breaking):** 0
- **Moderate Violations (Extended Range):** 670,840
- **Mild Violations (Viable Range):** 634,546

**Overall Assessment:**
✓ **ACCEPTABLE:** No crash-risk or severe balance issues found. 670,840 combinations exceed extended ranges but remain technically stable.

---

## CRITICAL FINDINGS

✓ **No critical violations found.** All combinations avoid crash-risk scenarios.

✓ **No severe violations found.** All combinations stay within absolute limits.

---

## PATTERN ANALYSIS

### Most Problematic Mods

Mods that appear most frequently in violation combinations:

| Rank | Mod ID | Mod Name | Total Violations | Critical | Severe | Moderate | Mild |
|------|--------|----------|------------------|----------|--------|----------|------|
| 1 | 2042 | INFINITE ENERGY REACTOR | 100,050 | 0 | 0 | 100,050 | 0 |
| 2 | 3029 | PERPETUAL MOTION REACTOR (PROTOTYPE) | 100,050 | 0 | 0 | 100,050 | 0 |
| 3 | 1054 | CHROMATIC COHERENCE EDGE | 99,801 | 0 | 0 | 99,801 | 0 |
| 4 | 2004 | REACTIVE PLATING ASSEMBLY | 94,515 | 0 | 0 | 30,610 | 63,905 |
| 5 | 3009 | PERMANENT BERSERKER MODE | 85,245 | 0 | 0 | 30,688 | 54,557 |
| 6 | 2025 | OFFENSIVE OVERLOAD MATRIX | 82,922 | 0 | 0 | 29,596 | 53,326 |
| 7 | 3005 | AGGRESSIVE COMBAT PROTOCOL | 78,763 | 0 | 0 | 28,008 | 50,755 |
| 8 | 1052 | VAMPIRIC STRIKE MATRIX | 77,571 | 0 | 0 | 77,571 | 0 |
| 9 | 3043 | MULTI-RANGE OPTIMIZATION PROTOCOL | 77,520 | 0 | 0 | 22,241 | 55,279 |
| 10 | 524 | CHROMATIC MATRIX CONVERTER | 75,503 | 0 | 0 | 75,470 | 33 |
| 11 | 3046 | PERFECT PRECISION CORE | 75,229 | 0 | 0 | 22,093 | 53,136 |
| 12 | 1003 | PRECISION EMITTER ASSEMBLY | 75,225 | 0 | 0 | 21,243 | 53,982 |
| 13 | 1010 | HYPERVELOCITY IMPACT CANNON | 75,225 | 0 | 0 | 20,813 | 54,412 |
| 14 | 1005 | TACTICAL CARBINE ASSEMBLY | 75,174 | 0 | 0 | 21,611 | 53,563 |
| 15 | 1014 | NANITE RECYCLER DEVASTATOR | 75,051 | 0 | 0 | 75,051 | 0 |
| 16 | 522 | PENETRATING BEAM PROJECTOR | 74,990 | 0 | 0 | 22,943 | 52,047 |
| 17 | 1047 | OMNIPHASE DEVASTATOR | 69,256 | 0 | 0 | 29,821 | 39,435 |
| 18 | 3038 | OMNI-ELEMENTAL CONVERSION CORE | 67,308 | 0 | 0 | 67,308 | 0 |
| 19 | 2033 | ELEMENTAL PENETRATION CONVERTER | 64,900 | 0 | 0 | 19,558 | 45,342 |
| 20 | 3047 | BERSERKER RAGE PROTOCOL | 64,578 | 0 | 0 | 30,514 | 34,064 |

### Most Vulnerable Stats

Stats that most frequently exceed safe ranges:

| Rank | Stat | Total Violations | Critical | Severe | Moderate | Mild |
|------|------|------------------|----------|--------|----------|------|
| 1 | GUNDAMAGE | 458,493 | 0 | 0 | 202,562 | 255,931 |
| 2 | LIFESTEAL | 217,678 | 0 | 0 | 217,678 | 0 |
| 3 | COOLDOWNREDUCTION | 216,494 | 0 | 0 | 215,086 | 1,408 |
| 4 | RESOURCEEFFICIENCY | 197,831 | 0 | 0 | 197,831 | 0 |
| 5 | ELEMENTALPENETRATION | 156,211 | 0 | 0 | 58,822 | 97,389 |
| 6 | PROJECTILESPEED | 150,799 | 0 | 0 | 42,101 | 108,698 |
| 7 | RANGE | 149,805 | 0 | 0 | 43,681 | 106,124 |
| 8 | PLAYERSPEED | 121,713 | 0 | 0 | 40,133 | 81,580 |
| 9 | REFLECTDAMAGE | 117,984 | 0 | 0 | 39,828 | 78,156 |
| 10 | CORRUPTIONCHANCE | 86,156 | 0 | 0 | 86,156 | 0 |
| 11 | ENERGYCAPACITY | 78,412 | 0 | 0 | 78,363 | 49 |
| 12 | HP | 67,751 | 0 | 0 | 27,661 | 40,090 |
| 13 | BULLETSPEED | 48,126 | 0 | 0 | 48,126 | 0 |
| 14 | MELEEDAMAGE | 29,090 | 0 | 0 | 14,476 | 14,614 |
| 15 | DODGECHANCE | 24,599 | 0 | 0 | 9,323 | 15,276 |
| 16 | SPRINTSPEED | 3,855 | 0 | 0 | 2,356 | 1,499 |
| 17 | SHOTSPERSEC | 3,158 | 0 | 0 | 1,877 | 1,281 |
| 18 | CRITDAMAGE | 150 | 0 | 0 | 109 | 41 |
| 19 | ARMOR | 13 | 0 | 0 | 0 | 13 |
| 20 | RELOADSPEED | 2 | 0 | 0 | 0 | 2 |

### Most Common Violation Combinations

Specific mod combinations that frequently cause violations:

#### 1. COHERENT LIGHT PROJECTOR
- **Mod IDs:** 515
- **Violation Count:** 1
- **Max Severity:** moderate

#### 2. CHROMATIC MATRIX CONVERTER
- **Mod IDs:** 524
- **Violation Count:** 1
- **Max Severity:** moderate

#### 3. NANITE RECYCLER DEVASTATOR
- **Mod IDs:** 1014
- **Violation Count:** 1
- **Max Severity:** moderate

#### 4. VAMPIRIC STRIKE MATRIX
- **Mod IDs:** 1052
- **Violation Count:** 1
- **Max Severity:** moderate

#### 5. CHROMATIC COHERENCE EDGE
- **Mod IDs:** 1054
- **Violation Count:** 1
- **Max Severity:** moderate

#### 6. INFINITE ENERGY REACTOR
- **Mod IDs:** 2042
- **Violation Count:** 1
- **Max Severity:** moderate

#### 7. PERPETUAL MOTION REACTOR (PROTOTYPE)
- **Mod IDs:** 3029
- **Violation Count:** 1
- **Max Severity:** moderate

#### 8. OMNI-ELEMENTAL CONVERSION CORE
- **Mod IDs:** 3038
- **Violation Count:** 1
- **Max Severity:** moderate

#### 9. THERMAL EDGE PROJECTOR
- **Mod IDs:** 1051
- **Violation Count:** 1
- **Max Severity:** moderate

#### 10. TEMPORAL ACCELERATION MATRIX
- **Mod IDs:** 2041
- **Violation Count:** 1
- **Max Severity:** moderate

### Prefix Type Analysis

Analysis of which modification types (B_, M_, A_, Z_, U_) are most dangerous:

| Prefix | Total Usage | Violations | Violation Rate |
|--------|-------------|------------|----------------|
| A_ | 1 | 99,801 | 9980100.00% |
| B_ | 141 | 5,553,709 | 3938800.71% |
| M_ | 333 | 14,187,388 | 4260476.88% |
| U_ | 4 | 173,152 | 4328800.00% |
| Z_ | 1 | 75,229 | 7522900.00% |

**Interpretation:**
- **M_** (Multiplicative) modifiers typically have highest violation rates due to compounding effects
- **B_** (Base additive) modifiers are generally safer but can stack in large combinations
- **A_** (Absolute additive) modifiers bypass multiplication, creating predictable effects

---

## RECOMMENDATIONS

Based on this analysis, we recommend:

### Moderate Priority

1. **670,840 combinations** exceed extended ranges - review for extreme builds
2. Consider if extended ranges should be tightened
3. Document intended extreme build scenarios

### Specific Mod Adjustments

1. **INFINITE ENERGY REACTOR (ID: 2042)** appears in 100,050 violations - review parameter values
2. **PERPETUAL MOTION REACTOR (PROTOTYPE) (ID: 3029)** - 100,050 violations
2. **CHROMATIC COHERENCE EDGE (ID: 1054)** - 99,801 violations
2. **REACTIVE PLATING ASSEMBLY (ID: 2004)** - 94,515 violations
2. **PERMANENT BERSERKER MODE (ID: 3009)** - 85,245 violations
2. **OFFENSIVE OVERLOAD MATRIX (ID: 2025)** - 82,922 violations

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

The HEL mod system demonstrates **robust design** with no crash-risk or severe balance-breaking scenarios detected across 1,780,064 combinations. 

While 670,840 combinations (37.7%) exceed extended ranges, these represent extreme build scenarios that remain technically stable. 

The mod system successfully balances player freedom with gameplay integrity.

---

*End of Report*
