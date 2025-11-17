# Zero-Base Multiplicative Mods Fix Plan

**Date:** 2025-11-16
**Status:** PLAN - Ready for Implementation
**Priority:** CRITICAL

---

## Executive Summary

This plan addresses the critical system design flaw where multiplicative (M_) coefficient mods applied to stats with zero base values produce no effect. This issue affects multiple archetypes and renders certain mod combinations completely non-functional.

**Impact:**
- Multiple mod slots wasted across all builds
- Tank archetypes cannot function (0 armor despite armor mods)
- Sustain builds broken (0% lifesteal despite lifesteal mods)
- Defensive builds non-viable

---

## Problem Statement

### Root Cause
The HEL coefficient system calculates final stat values using:
```
Final = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

When `S` (base stat) = 0 and only M_ coefficients are applied:
```
Final = (0 + 0) * (1 + M) = 0
```

### Affected Stats (Base Value = 0)

From StatsData.asset analysis:

| Stat | Base Value | Min | Max | Impact Level |
|------|------------|-----|-----|--------------|
| LIFESTEAL | 0 | 0 | 1 | **CRITICAL** - Breaks sustain builds |
| THORNDAMAGE | 0 | 0 | 5000 | **HIGH** - Breaks tank retaliation |
| CHAINLIGHTNING | 0 | 0 | 20 | **MEDIUM** - Breaks AoE scaling |
| SHIELDCAPACITY | 0 | 0 | 5000 | **HIGH** - Breaks shield builds |
| SHIELDREGENRATE | 0 | 0 | 5000 | **HIGH** - Breaks shield builds |
| DODGECHANCE | 0 | 0 | 1 | **MEDIUM** - Breaks evasion builds |
| DAMAGEABSORPTION | 0 | 0 | 5000 | **MEDIUM** - Breaks flat reduction |
| REFLECTDAMAGE | 0 | 0 | 1 | **MEDIUM** - Breaks reflect builds |
| PIERCINGSHOTS | 0 | 0 | 50 | **LOW** - Has B_ mods available |
| CORRUPTIONCHANCE | 0 | 0 | 1 | **LOW** - Elemental builds |
| CORRUPTIONDAMAGE | 0 | 0 | 5000 | **LOW** - Elemental builds |
| ELEMENTALPENETRATION | 0 | 0 | 1 | **LOW** - Elemental builds |
| IGNITESPREAD | 0 | 0 | 10 | **LOW** - Elemental builds |
| COOLDOWNREDUCTION | 0 | 0 | 1 | **LOW** - Ability builds |
| RESOURCEEFFICIENCY | 0 | 0 | 1 | **LOW** - Resource builds |
| MAXHPPERCENTBONUS | 0 | 0 | 10 | **LOW** - HP scaling |

**Note:** ARMOR base value not explicitly shown in StatsData.asset but confirmed as 0 from mod evaluation report.

### Affected Mods

Mods using M_ coefficients on zero-base stats (preliminary count from grep):

| Stat | Mod Count | Example Mod IDs | Fix Strategy |
|------|-----------|-----------------|--------------|
| M_ARMOR | ~11 instances | 2001, 2002, 3011, 3014, penalties | Convert to B_ARMOR or increase base |
| M_LIFESTEAL | ~7 instances | 2020, 1875, 1947 | Convert to B_LIFESTEAL |
| M_DODGECHANCE | ~3 instances | 1893, 1310, 1965 | Convert to B_DODGECHANCE |
| M_REFLECTDAMAGE | ~2 instances | 1143, 1929 | Convert to B_REFLECTDAMAGE |
| M_THORNDAMAGE | 0 instances (uses B_) | - | Already correct ✓ |

---

## Fix Strategy Options

### Option 1: Convert M_ Coefficients to B_ (Base Additive)
**Recommended for:** LIFESTEAL, DODGECHANCE, REFLECTDAMAGE, ARMOR

**Pros:**
- Immediate fix, no base stat changes needed
- Mods become functional immediately
- Maintains mod balance (convert percentages to flat values)

**Cons:**
- Changes mod scaling behavior
- Requires rebalancing val1/val2 ranges
- May need to adjust min/max stat bounds

**Implementation:**
```
OLD: M_LIFESTEAL = M_LIFESTEAL val1 +     (e.g., +8-15%)
NEW: B_LIFESTEAL = B_LIFESTEAL val1 +     (e.g., +0.08-0.15 flat)
```

### Option 2: Set Non-Zero Base Values
**Recommended for:** ARMOR, SHIELDCAPACITY

**Pros:**
- Preserves multiplicative scaling design
- No mod equation changes needed
- More "RPG-like" progression

**Cons:**
- Changes base game balance (all characters get base armor/shields)
- May require rebalancing all related mods
- Affects every build, not just those using mods

**Implementation:**
```yaml
# StatsData.asset
- name: ARMOR
  value: 50        # Changed from 0
  min: 0
  max: 5000
```

### Option 3: Hybrid Approach (RECOMMENDED)
**Use both strategies based on stat type:**

| Stat | Strategy | Reasoning |
|------|----------|-----------|
| ARMOR | Option 2 (base > 0) | Core defensive stat, should scale multiplicatively |
| LIFESTEAL | Option 1 (B_) | Percentage-based, flat additive makes sense |
| DODGECHANCE | Option 1 (B_) | Percentage-based, flat additive makes sense |
| REFLECTDAMAGE | Option 1 (B_) | Percentage-based, flat additive makes sense |
| THORNDAMAGE | No change needed | Already uses B_ coefficients ✓ |
| SHIELDCAPACITY | Option 2 (base > 0) | Core defensive stat, should scale multiplicatively |
| SHIELDREGENRATE | Option 2 (base > 0) | Pairs with shield capacity |

---

## Detailed Implementation Plan

### Phase 1: Data Collection & Analysis (COMPLETED)
✓ Identify all stats with base value = 0
✓ Identify all mods using M_ coefficients on those stats
✓ Categorize by impact level (CRITICAL/HIGH/MEDIUM/LOW)

### Phase 2: Mod Equation Conversion (PRIMARY TASK)

#### Step 2.1: Extract All Affected Mods
Create complete inventory of mods needing fixes:
```bash
# Search ModsData.asset for all M_<STAT> patterns where <STAT> has base = 0
grep -n "M_LIFESTEAL\|M_DODGECHANCE\|M_REFLECTDAMAGE\|M_ARMOR" DELIVERABLE-ModsData.asset
```

#### Step 2.2: Convert Equations (LIFESTEAL)
For each mod with M_LIFESTEAL:

**Before:**
```yaml
- modid: 2020
  equation: "M_LIFESTEAL = M_LIFESTEAL val1 +"
  val1min: 0.08
  val1max: 0.15
```

**After:**
```yaml
- modid: 2020
  equation: "B_LIFESTEAL = B_LIFESTEAL val1 +"
  val1min: 0.08
  val1max: 0.15
```

**Affected Mods (estimated 7):**
- Mod 2020 (VAMPIRIC NANITE PROTOCOLS)
- Mod 1875
- Mod 1947
- Others from grep results (lines 470, 488, 917, 994, 1012)

#### Step 2.3: Convert Equations (DODGECHANCE)
For each mod with M_DODGECHANCE:

**Before:**
```yaml
- modid: 1893
  equation: "M_DODGECHANCE = M_DODGECHANCE val1 +"
  val1min: 0.10
  val1max: 0.20
```

**After:**
```yaml
- modid: 1893
  equation: "B_DODGECHANCE = B_DODGECHANCE val1 +"
  val1min: 0.10
  val1max: 0.20
```

**Affected Mods (estimated 3):**
- Mod 1893
- Mod 1310 (conditional)
- Mod 1965 (conditional)

#### Step 2.4: Convert Equations (REFLECTDAMAGE)
For each mod with M_REFLECTDAMAGE:

**Before:**
```yaml
- modid: 1143
  equation: "M_ARMOR = M_ARMOR val1 +; M_REFLECTDAMAGE = M_REFLECTDAMAGE val2 +; ..."
```

**After:**
```yaml
- modid: 1143
  equation: "M_ARMOR = M_ARMOR val1 +; B_REFLECTDAMAGE = B_REFLECTDAMAGE val2 +; ..."
```

**Affected Mods (estimated 2):**
- Mod 1143
- Mod 1929

### Phase 3: Base Stat Adjustments (SECONDARY TASK)

#### Step 3.1: Set ARMOR Base Value
Update StatsData.asset to give all characters base armor:

**Before:**
```yaml
# Currently not in StatsData.asset (implicitly 0 in game code)
```

**After:**
```yaml
- name: ARMOR
  desc: Damage mitigation coefficient reducing incoming structural damage
  value: 50
  min: 0
  max: 5000
```

**Rationale:**
- Base armor = 50 allows multiplicative mods to function
- 50 base × 1.35 (35% mod) = 67.5 armor (meaningful increase)
- Preserves multiplicative scaling design intent

#### Step 3.2: Set SHIELDCAPACITY Base Value (Optional)
```yaml
- name: SHIELDCAPACITY
  value: 50     # Changed from 0
  min: 0
  max: 5000
```

**Rationale:**
- Enables shield-based builds
- Pairs with SHIELDREGENRATE
- Optional: can remain 0 if shields are meant to be mod-only

### Phase 4: Validation & Testing

#### Step 4.1: Automated Validation
Create validation script to verify fixes:

```python
# validate_zero_base_fixes.py
import re

def validate_mods_data(mods_file, stats_file):
    """
    Validates that no M_ coefficients are used on zero-base stats.
    """
    # Load stats, identify zero-base stats
    zero_base_stats = []
    with open(stats_file) as f:
        current_stat = None
        for line in f:
            if 'name:' in line:
                current_stat = line.split(':')[1].strip()
            if 'value: 0' in line and current_stat:
                zero_base_stats.append(current_stat)

    # Check mods for M_<zero_base_stat> patterns
    violations = []
    with open(mods_file) as f:
        for i, line in enumerate(f, 1):
            for stat in zero_base_stats:
                if f'M_{stat}' in line:
                    violations.append(f"Line {i}: M_{stat} used on zero-base stat")

    return violations

# Run validation
violations = validate_mods_data('DELIVERABLE-ModsData.asset', 'DELIVERABLE-StatsData.asset')
if violations:
    print(f"❌ VALIDATION FAILED: {len(violations)} violations")
    for v in violations:
        print(f"  - {v}")
else:
    print("✅ VALIDATION PASSED: No M_ coefficients on zero-base stats")
```

#### Step 4.2: Re-evaluate Archetypes
Re-run mod combination evaluation for the three test archetypes:

**Success Criteria:**
1. **Fortress Tank:**
   - ARMOR > 0 (currently 0) ✓
   - HP > 125 (needs more mods, but armor should work)
   - No wasted mod slots ✓

2. **Hybrid Berserker:**
   - LIFESTEAL > 0% (currently 0%) ✓
   - Sustain mechanic functional ✓
   - No death spiral ✓

3. **Glass Cannon:**
   - No changes needed (no zero-base stat issues)
   - Verify no regressions ✓

#### Step 4.3: HEL Equation Testing
Test HEL evaluation with fixed equations:

```python
# test_fixed_mods.py
from HEL import EvaluateMods

# Test LIFESTEAL mod (converted to B_)
stats = {'LIFESTEAL': 0}
mods = {2020: {'equation': 'B_LIFESTEAL = B_LIFESTEAL 0.10 +', 'val1': 0.10}}
result = EvaluateMods(stats, mods)
assert result['LIFESTEAL'] > 0, "LIFESTEAL should be > 0 after applying B_ mod"

# Test ARMOR with base value = 50
stats = {'ARMOR': 50}
mods = {2001: {'equation': 'M_ARMOR = M_ARMOR 0.30 +', 'val1': 0.30}}
result = EvaluateMods(stats, mods)
assert result['ARMOR'] == 65, "ARMOR should be 50 * 1.30 = 65"

print("✅ All HEL equation tests passed")
```

### Phase 5: Documentation Updates

#### Step 5.1: Update CLAUDE.md
Document the zero-base stat policy:

```markdown
### Zero-Base Stats and Coefficient Usage

**Important Design Rule:** Stats with base value = 0 MUST NOT use M_ (multiplicative) coefficients alone.

**Stats with base = 0:**
- LIFESTEAL, DODGECHANCE, REFLECTDAMAGE: Use B_ (base additive) coefficients
- ARMOR, SHIELDCAPACITY: Set non-zero base values to enable M_ coefficients

**Rationale:** M_ coefficients multiply (S + B), so if S=0 and B=0, result is always 0.
```

#### Step 5.2: Create Mod Conversion Log
Document all changed mods for reference:

```markdown
# Mod Equation Conversion Log

## LIFESTEAL Conversions (M_ → B_)
- Mod 2020: M_LIFESTEAL → B_LIFESTEAL
- Mod 1875: M_LIFESTEAL → B_LIFESTEAL
- [Full list...]

## ARMOR Base Value Change
- StatsData.asset: ARMOR base 0 → 50
```

---

## Evaluation Criteria for Success

### Critical Success Metrics

#### 1. Zero Wasted Mod Slots ✓
**Test:** Apply all armor/lifesteal/dodge mods to base stats
**Expected:** All mods produce non-zero stat increases
**Current State:** FAIL (armor/lifesteal mods produce 0)
**Target State:** PASS (all mods functional)

#### 2. Fortress Tank Archetype Viable ✓
**Test:** Equip 4 armor/HP/thorns mods
**Expected:**
- ARMOR > 100 (with base 50 + mods)
- HP > 150
- THORNDAMAGE > 100

**Current State:** FAIL (ARMOR = 0, HP = 125, THORNDAMAGE = 40)
**Target State:** PARTIAL PASS (armor functional, HP/thorns need more mods)

#### 3. Hybrid Berserker Sustain Works ✓
**Test:** Equip lifesteal mod, deal damage, measure HP recovery
**Expected:** LIFESTEAL > 0%, HP recovery proportional to damage
**Current State:** FAIL (LIFESTEAL = 0%, no recovery)
**Target State:** PASS (LIFESTEAL ≥ 0.10, recovery functional)

#### 4. No Regressions in Working Builds ✓
**Test:** Re-evaluate Glass Cannon archetype
**Expected:** Same or better results as current
**Current State:** Baseline (CRITDAMAGE works, GUNDAMAGE low)
**Target State:** PASS (no changes, maintains baseline)

### Validation Checks

#### Automated Validation (Must Pass)
- [ ] No M_ coefficients on zero-base stats in ModsData.asset
- [ ] All lifesteal mods use B_LIFESTEAL
- [ ] All dodge mods use B_DODGECHANCE
- [ ] All reflect mods use B_REFLECTDAMAGE
- [ ] ARMOR base value > 0 in StatsData.asset
- [ ] SHIELDCAPACITY base value > 0 (if shield builds enabled)

#### Manual Testing (Must Pass)
- [ ] Mod 2020 (VAMPIRIC NANITE) grants lifesteal > 0%
- [ ] Mod 2001 (ABLATIVE PLATING) grants armor > 0
- [ ] Mod 3011 (ABLATIVE ARMOR NANITES) grants armor > 0
- [ ] Fortress Tank build achieves armor > 0
- [ ] Berserker build achieves lifesteal > 0%
- [ ] No existing builds broken by changes

#### HEL System Tests (Must Pass)
- [ ] B_LIFESTEAL equations evaluate correctly
- [ ] B_DODGECHANCE equations evaluate correctly
- [ ] B_REFLECTDAMAGE equations evaluate correctly
- [ ] M_ARMOR equations work with new base value
- [ ] Coefficient stacking works (multiple B_ mods additive)
- [ ] No syntax errors in modified equations

---

## Implementation Checklist

### Preparation
- [x] Analyze zero-base stats in StatsData.asset
- [x] Identify all M_ coefficient mods on zero-base stats
- [x] Categorize fixes by strategy (M_→B_ vs base value increase)
- [ ] Create backup of DELIVERABLE-ModsData.asset
- [ ] Create backup of DELIVERABLE-StatsData.asset

### Mod Equation Conversions
- [ ] Convert all M_LIFESTEAL → B_LIFESTEAL (estimated 7 mods)
- [ ] Convert all M_DODGECHANCE → B_DODGECHANCE (estimated 3 mods)
- [ ] Convert all M_REFLECTDAMAGE → B_REFLECTDAMAGE (estimated 2 mods)
- [ ] Verify equation syntax (no typos, valid HEL)
- [ ] Update mod descriptions if needed (e.g., "8-15% lifesteal" → "0.08-0.15 lifesteal")

### Base Stat Adjustments
- [ ] Add ARMOR stat to StatsData.asset (if not present)
- [ ] Set ARMOR base value = 50
- [ ] Verify ARMOR min/max bounds (0-5000)
- [ ] Optional: Set SHIELDCAPACITY base = 50

### Validation
- [ ] Run automated validation script
- [ ] Test mod 2020 (lifesteal)
- [ ] Test mod 2001 (armor)
- [ ] Test mod 1893 (dodge chance)
- [ ] Re-evaluate Fortress Tank build
- [ ] Re-evaluate Hybrid Berserker build
- [ ] Re-evaluate Glass Cannon build (regression test)

### Documentation
- [ ] Update CLAUDE.md with zero-base stat policy
- [ ] Create mod conversion log
- [ ] Update mod evaluation report with fix results
- [ ] Document any design decisions or trade-offs

### Finalization
- [ ] Copy fixed files to final deliverable locations
- [ ] Commit changes with descriptive message
- [ ] Push to branch
- [ ] Create summary report of all changes

---

## Risk Assessment

### Low Risk Changes ✓
- Converting M_LIFESTEAL → B_LIFESTEAL (isolated, well-understood)
- Converting M_DODGECHANCE → B_DODGECHANCE (isolated, well-understood)
- Converting M_REFLECTDAMAGE → B_REFLECTDAMAGE (isolated, well-understood)

### Medium Risk Changes ⚠️
- Setting ARMOR base = 50 (affects ALL builds, even those without armor mods)
  - Mitigation: 50 armor is ~5% damage reduction (minimal impact)
  - Test thoroughly across archetypes

### Potential Issues
1. **Value Range Mismatches:** B_ coefficients may need different val1/val2 ranges than M_
   - Mitigation: Review and adjust ranges during conversion

2. **Stat Bound Violations:** B_ additive may exceed max bounds more easily than M_
   - Mitigation: Verify min/max bounds for LIFESTEAL (0-1), DODGECHANCE (0-1)

3. **Unintended Interactions:** Changing base armor affects ALL conditional equations using T_ARMOR
   - Mitigation: Grep for T_ARMOR references, verify no broken conditionals

---

## Timeline Estimate

| Phase | Time Estimate | Dependencies |
|-------|---------------|--------------|
| Phase 1: Analysis | COMPLETE | - |
| Phase 2: Mod Conversions | 2-3 hours | Phase 1 |
| Phase 3: Base Stats | 30 min | Phase 1 |
| Phase 4: Validation | 1-2 hours | Phases 2, 3 |
| Phase 5: Documentation | 1 hour | Phase 4 |
| **Total** | **4-6 hours** | - |

---

## Next Steps

1. **Approve Plan:** Review this document, approve strategy
2. **Execute Phase 2:** Begin mod equation conversions
3. **Execute Phase 3:** Adjust base stat values
4. **Validate:** Run all tests and validation checks
5. **Document:** Update all relevant documentation
6. **Commit & Push:** Deliver fixed assets

---

## Appendix A: Full List of Zero-Base Stats

```yaml
# From StatsData.asset
PIERCINGSHOTS: 0        # Has B_ mods ✓
LIFESTEAL: 0            # CRITICAL - needs B_ conversion
CHAINLIGHTNING: 0       # Check for M_ usage
SHIELDCAPACITY: 0       # Consider base value or B_ conversion
SHIELDREGENRATE: 0      # Pairs with SHIELDCAPACITY
DODGECHANCE: 0          # CRITICAL - needs B_ conversion
DAMAGEABSORPTION: 0     # Check for M_ usage
THORNDAMAGE: 0          # Already uses B_ ✓
REFLECTDAMAGE: 0        # CRITICAL - needs B_ conversion
MAXHPPERCENTBONUS: 0    # Check for M_ usage
COOLDOWNREDUCTION: 0    # Check for M_ usage
RESOURCEEFFICIENCY: 0   # Check for M_ usage
CORRUPTIONCHANCE: 0     # Check for M_ usage
CORRUPTIONDAMAGE: 0     # Check for M_ usage
ELEMENTALPENETRATION: 0 # Check for M_ usage
IGNITESPREAD: 0         # Check for M_ usage
```

## Appendix B: Example Fixed Mod

**Before (Broken):**
```yaml
- modid: 2020
  name: VAMPIRIC NANITE PROTOCOLS
  type: 0
  rarity: Enhanced
  desc: "+8-15% lifesteal on all damage"
  equation: "M_LIFESTEAL = M_LIFESTEAL val1 +"
  val1min: 0.08
  val1max: 0.15
  val2min: 0
  val2max: 0
  modweight: 80
```

**After (Fixed):**
```yaml
- modid: 2020
  name: VAMPIRIC NANITE PROTOCOLS
  type: 0
  rarity: Enhanced
  desc: "+8-15% lifesteal on all damage"
  equation: "B_LIFESTEAL = B_LIFESTEAL val1 +"  # Changed M_ → B_
  val1min: 0.08
  val1max: 0.15
  val2min: 0
  val2max: 0
  modweight: 80
```

**Impact:**
- Before: `LIFESTEAL = (0 + 0) × 1.10 = 0%` ✗
- After: `LIFESTEAL = (0 + 0.10) × 1 = 0.10 = 10%` ✓

---

**END OF PLAN**
