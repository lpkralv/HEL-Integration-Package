# HEL Syntax Corrections - Pure Postfix Notation
**Date:** 2025-11-12
**Issue:** All HEL equations incorrectly used infix `+` notation
**Fix:** Convert all equations to pure postfix notation

---

## Core Problem

**❌ INCORRECT (what was written):**
```
M_GUNDAMAGE = M_GUNDAMAGE + val1
```

**✅ CORRECT (pure postfix):**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +
```

---

## Systematic Conversion Rules

### Rule 1: Simple Addition
```
❌ M_X = M_X + val1
✅ M_X = M_X val1 +
```

### Rule 2: Subtraction (Penalties)
```
❌ M_X = M_X + (-0.5)
✅ M_X = M_X -0.5 +
```
OR
```
✅ M_X = M_X 0.5 -
```

### Rule 3: Flat Addition to B_ Coefficients
```
❌ B_HP = B_HP + 100
✅ B_HP = B_HP 100 +
```

### Rule 4: Multiplication Then Add
```
❌ M_X = M_X + val1 0.5 *
✅ M_X = M_X val1 0.5 * +
```

### Rule 5: Cross-Stat Scaling Then Add
```
❌ A_MELEEDAMAGE = A_MELEEDAMAGE + B_GUNDAMAGE val1 *
✅ A_MELEEDAMAGE = A_MELEEDAMAGE B_GUNDAMAGE val1 * +
```

### Rule 6: Complex Conditional
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + (T_HP S_HP 0.5 * <) val1 *
✅ M_GUNDAMAGE = M_GUNDAMAGE T_HP S_HP 0.5 * < val1 * +
```

### Rule 7: Speed-to-Damage Conversion
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + T_PLAYERSPEED 0.01 * val1 *
✅ M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED 0.01 * val1 * +
```

### Rule 8: Armor-to-Thorns Conversion
```
❌ B_THORNDAMAGE = B_THORNDAMAGE + T_ARMOR val1 *
✅ B_THORNDAMAGE = B_THORNDAMAGE T_ARMOR val1 * +
```

### Rule 9: Random Variance
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + RAND val1 * -0.5 +
✅ M_GUNDAMAGE = M_GUNDAMAGE RAND val1 * 0.5 - +
```

### Rule 10: Direct Assignment (No Change Needed)
```
✅ M_X = val1           (Already correct - direct assignment)
✅ B_X = val1           (Already correct - direct assignment)
✅ Z_ACCURACY = 1.0     (Already correct - sets minimum)
```

### Rule 11: Multiple Statements
```
❌ M_X = M_X + val1; M_Y = M_Y + val2
✅ M_X = M_X val1 +; M_Y = M_Y val2 +
```

---

## Common Multi-Statement Patterns

### Pattern A: Two Additions
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + val1; M_SHOTSPERSEC = M_SHOTSPERSEC + val2
✅ M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC val2 +
```

### Pattern B: Addition and Subtraction
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + val1; M_HP = M_HP + (-0.15)
✅ M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_HP = M_HP -0.15 +
```

### Pattern C: Mixed B_ and M_
```
❌ B_HP = B_HP + val1; M_ARMOR = M_ARMOR + val2
✅ B_HP = B_HP val1 +; M_ARMOR = M_ARMOR val2 +
```

### Pattern D: Flat Add to B_, Then Direct Assign
```
❌ B_BULLETSFIRED = B_BULLETSFIRED + 5; M_ACCURACY = -0.5
✅ B_BULLETSFIRED = B_BULLETSFIRED 5 +; M_ACCURACY = -0.5
```

---

## Files Requiring Corrections

### Deliverables (CRITICAL):
1. ✅ `DELIVERABLE-ModsData.asset` - 30 sample mods
2. ✅ `DELIVERABLE-System-Philosophy.md` - Example equations
3. ✅ `docs/Essentials-HEL.md` - Syntax reference

### Design Documents:
4. `docs/Weapons-Ballistic.md` - 15 mods
5. `docs/Weapons-Energy.md` - 10 mods
6. `docs/Weapons-Explosive.md` - 9 mods
7. `docs/Weapons-Deployables.md` - 10 mods
8. `docs/Weapons-Hybrid.md` - 4 mods
9. `docs/Weapons-Melee.md` - 7 mods
10. `docs/Items-Structural.md` - 8 mods
11. `docs/Items-Mobility.md` - 7 mods
12. `docs/Items-Regeneration.md` - 6 mods
13. `docs/Items-Offensive.md` - 8 mods
14. `docs/Items-Resistance.md` - 6 mods
15. `docs/Items-Resource.md` - 8 mods
16. `docs/Items-Tactical.md` - 7 mods
17. `docs/Syringes-Combat.md` - 10 mods
18. `docs/Syringes-Defensive.md` - 10 mods
19. `docs/Syringes-Metabolic.md` - 10 mods
20. `docs/Syringes-Elemental.md` - 9 mods
21. `docs/Syringes-Tactical.md` - 8 mods
22. `docs/Syringes-Exotic.md` - 4 mods

**Total:** 155 mod equations across 22 files

---

## Priority Order for Fixes

1. **DELIVERABLE-ModsData.asset** (most critical - actual YAML asset)
2. **Essentials-HEL.md** (reference documentation)
3. **DELIVERABLE-System-Philosophy.md** (example equations)
4. All design documents (Weapons/Items/Syringes)

---

## Example Corrections from Actual Mods

### Mod 1000: ASSAULT RIFLE ASSEMBLY
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + val1; M_SHOTSPERSEC = M_SHOTSPERSEC + val2
✅ M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC val2 +
```

### Mod 1002: PRECISION SNIPER ASSEMBLY
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + val1; M_ACCURACY = M_ACCURACY + val2; M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.15)
✅ M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_ACCURACY = M_ACCURACY val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.15 +
```

### Mod 1014: CATACLYSM CANNON
```
❌ B_BULLETSFIRED = B_BULLETSFIRED + 5; M_GUNDAMAGE = M_GUNDAMAGE + val1; M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.4); M_ACCURACY = M_ACCURACY + (-0.5); M_RANGE = M_RANGE + (-0.25)
✅ B_BULLETSFIRED = B_BULLETSFIRED 5 +; M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.4 +; M_ACCURACY = M_ACCURACY -0.5 +; M_RANGE = M_RANGE -0.25 +
```

### Mod 1015: THERMAL LASER EMITTER
```
❌ M_IGNITECHANCE = M_IGNITECHANCE + val1; B_IGNITEDAMAGE = B_IGNITEDAMAGE + val2
✅ M_IGNITECHANCE = M_IGNITECHANCE val1 +; B_IGNITEDAMAGE = B_IGNITEDAMAGE val2 +
```

### Mod 3047: BERSERKER RAGE PROTOCOL
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + (T_HP S_HP 0.5 * <) val1 *; M_MELEEDAMAGE = M_MELEEDAMAGE + (T_HP S_HP 0.5 * <) val2 *; M_HP = M_HP + (-0.15)
✅ M_GUNDAMAGE = M_GUNDAMAGE T_HP S_HP 0.5 * < val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_HP S_HP 0.5 * < val2 * +; M_HP = M_HP -0.15 +
```

### Mod 3048: CHAOS VARIANCE INJECTOR
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + RAND val1 * -0.5 +; M_MELEEDAMAGE = M_MELEEDAMAGE + RAND val1 * -0.5 +; M_CRITCHANCE = M_CRITCHANCE + val2; M_ACCURACY = M_ACCURACY + (-0.2)
✅ M_GUNDAMAGE = M_GUNDAMAGE RAND val1 * 0.5 - +; M_MELEEDAMAGE = M_MELEEDAMAGE RAND val1 * 0.5 - +; M_CRITCHANCE = M_CRITCHANCE val2 +; M_ACCURACY = M_ACCURACY -0.2 +
```

### Mod 3049: VELOCITY DAMAGE CONVERTER
```
❌ M_GUNDAMAGE = M_GUNDAMAGE + T_PLAYERSPEED 0.01 * val1 *; M_MELEEDAMAGE = M_MELEEDAMAGE + T_PLAYERSPEED 0.01 * val1 *; M_GUNDAMAGE = M_GUNDAMAGE + (-0.25); M_MELEEDAMAGE = M_MELEEDAMAGE + (-0.25); M_HP = M_HP + (-0.2)
✅ M_GUNDAMAGE = M_GUNDAMAGE T_PLAYERSPEED 0.01 * val1 * +; M_MELEEDAMAGE = M_MELEEDAMAGE T_PLAYERSPEED 0.01 * val1 * +; M_GUNDAMAGE = M_GUNDAMAGE -0.25 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.25 +; M_HP = M_HP -0.2 +
```

### Mod 3050: ARMOR THORNS AMPLIFIER
```
❌ B_THORNDAMAGE = B_THORNDAMAGE + T_ARMOR val1 *; M_ARMOR = M_ARMOR + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-0.3); M_MELEEDAMAGE = M_MELEEDAMAGE + (-0.25)
✅ B_THORNDAMAGE = B_THORNDAMAGE T_ARMOR val1 * +; M_ARMOR = M_ARMOR val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.3 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.25 +
```

---

## Status

**Created:** 2025-11-12
**Files Corrected:** 0/22
**Next Action:** Systematically update all files with corrected pure postfix syntax

---

**END OF CORRECTION REFERENCE**
