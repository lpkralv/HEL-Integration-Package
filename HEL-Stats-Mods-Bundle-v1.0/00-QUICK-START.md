# Quick Start Guide - 5 Minutes

**HEL Stats/Mods Bundle v1.0**

---

## Step 1: Import Assets (2 minutes)

**Copy to your Unity project:**
```
deliverables/StatsData.asset  → Assets/Data/StatsData.asset
deliverables/ModsData.asset   → Assets/Data/ModsData.asset
```

**Verify in Unity:**
- Check console for YAML parsing errors
- Confirm 27 new stats loaded
- Confirm 155 mods loaded

---

## Step 2: Review Design (2 minutes)

**Read in order:**

1. **DELIVERABLE-System-Philosophy.md** (skim sections 1-3)
   - Understand the 8 build archetypes
   - See rarity tier philosophy
   - Review trade-off requirements

2. **Integration-Validation-Report.md** (section 12: Conclusion)
   - Verify system is validated and ready
   - Check technical compliance summary

---

## Step 3: Technical Overview (1 minute)

**Check Integration-Validation-Report.md section 2 for:**
- HEL equation syntax (postfix notation)
- Coefficient system: `S_`, `B_`, `A_`, `M_`, `Z_`, `U_`, `T_`
- Final calculation formula: `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`

**Key Points:**
- Always ADD to coefficients: `M_GUNDAMAGE = M_GUNDAMAGE + val1`
- Percentages use decimals: `0.5 = 50%`
- Use `T_` prefix for read-only stat references in equations

---

## Next Steps

### For Designers
→ Read `DELIVERABLE-System-Philosophy.md` for complete design vision
→ Browse `reference/` directories for specific mod details

### For Developers
→ Follow `INTEGRATION-CHECKLIST.md` step-by-step
→ See `technical/Foundation-HEL-Guide.md` for equation integration

### For Technical Artists
→ Review modweight values in `DELIVERABLE-Mods-Description.md`
→ Check rarity distribution (45% Standard, 30% Enhanced, 18% Advanced, 7% Prototype)

---

## System Summary

**Stats:** 65 total (38 existing + 27 new)
**Mods:** 155 total (55 weapons + 50 items + 50 syringes)
**Archetypes:** 8 core builds supported
**Status:** ✅ Validated and ready for implementation

---

**For detailed navigation, see: `README-BUNDLE.md`**
