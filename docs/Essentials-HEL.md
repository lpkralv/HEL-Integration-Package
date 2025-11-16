# HEL Essentials Reference

**Quick reference for writing valid HEL equations. See Foundation-HEL-Guide.md for detailed explanations.**

---

## Coefficient System

| Prefix | Purpose | Assignable? |
|--------|---------|-------------|
| **S_** | Base stat values from StatsData.asset | READ-ONLY |
| **B_** | Base additive (applied BEFORE multiplication) | YES |
| **A_** | Absolute additive (applied AFTER multiplication) | YES |
| **M_** | Multiplicative percentage (0.1 = +10%) | YES |
| **Z_** | Minimum value adjustment (extends lower bound) | YES |
| **U_** | Maximum value adjustment (extends upper bound) | YES |
| **T_** | Final computed values (calculated by system) | READ-ONLY |

---

## Final Computation Formula

```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

---

## What HEL CAN Do

- **Cross-Stat Dependencies**: `A_MELEEDAMAGE = B_GUNDAMAGE val1 *`
- **Math Functions**: `M_DAMAGE = M_DAMAGE MIN(0.5, T_SPEED 100 /) +`
- **Boolean Conditionals**: `M_DAMAGE = M_DAMAGE T_HP 100 < 0.5 * +`
- **Comparison Operators**: `<, <=, >, >=, ==, !=` (return 1.0 if true, 0.0 if false)
- **Logical Operators**: `AND, OR, NOT`
- **Min/Max Boundaries**: `Z_HP = Z_HP 50 +; U_HP = U_HP 500 +`
- **Trade-offs**: `M_DAMAGE = M_DAMAGE -0.3 +; M_FIRERATE = M_FIRERATE 0.5 +`
- **Multiple Statements**: `B_HP = B_HP 100 +; M_ARMOR = M_ARMOR 0.2 +; B_HPREGEN = B_HPREGEN 0.5 +`

---

## What HEL CANNOT Do

- **No if/else/loops**: Use boolean multiplication instead: `(T_HP 100 <) 0.5 *`
- **No strings**: Game engine handles text display, HEL only processes numbers
- **No duration/timers**: Game engine manages time, HEL sets values
- **No stack tracking**: Game engine tracks stacks, passes via T_STACKS for HEL to read
- **No item operations**: Game engine handles inventory/crafting
- **Max 2 values per mod**: Only `val` (or `val1`) and `val2` exist

---

## Critical Syntax Rules

1. **Always add to coefficients**: `M_DAMAGE = M_DAMAGE 0.25 +` (not `= 0.25`)
2. **Don't write to read-only**: Never assign to S_ or T_ variables
3. **Postfix notation**: Operators after operands: `val1 0.5 *` (not `0.5 * val1`)
4. **M_ uses decimals**: 0.5 = +50%, 1.0 = +100%, 0.1 = +10% (not 50, 100, 10)
5. **Separate statements**: Use semicolons: `B_HP = B_HP 50 +; M_ARMOR = M_ARMOR 0.2 +`
6. **VAL substitution**: VAL and VAL1 → mod.val, VAL2 → mod.val2 (before evaluation)
7. **Coefficients accumulate**: Multiple mods can modify same coefficient (values add together)

---

## Common Equation Patterns

| Pattern | Equation | Use Case |
|---------|----------|----------|
| **Simple % Boost** | `M_GUNDAMAGE = M_GUNDAMAGE val1 +` | Basic percentage increase |
| **Flat Addition** | `B_HP = B_HP val1 +` | Base additive (scales with multipliers) |
| **Conditional Bonus** | `M_DAMAGE = M_DAMAGE T_HP 100 < val1 * +` | Bonus when condition met |
| **Cross-Stat Synergy** | `A_MELEEDAMAGE = A_MELEEDAMAGE B_GUNDAMAGE val1 * +` | Convert one stat to another |
| **Trade-off** | `M_DAMAGE = M_DAMAGE -val1 +; M_FIRERATE = M_FIRERATE val2 +` | Decrease one, increase another |

---

## Quick Math Reference

**Operators**: `+, -, *, /, ^` (postfix notation)
**Functions**: `MIN(a,b), MAX(a,b), CEIL(x), FLOOR(x), RAND`
**Comparisons**: `<, <=, >, >=, ==, !=` (return 1.0 or 0.0)
**Logic**: `AND, OR, NOT`

---

## Common Anti-Patterns

| ❌ Wrong | ✅ Correct | Issue |
|----------|-----------|-------|
| `M_DAMAGE = 0.5` | `M_DAMAGE = M_DAMAGE 0.5 +` | Overwrites instead of adding |
| `T_HP = 100` | `B_HP = 100` | T_ is read-only |
| `M_DAMAGE = M_DAMAGE 50 +` | `M_DAMAGE = M_DAMAGE 0.5 +` | 50 = +5000%, not +50% |
| `M_DAMAGE = M_DAMAGE + 0.5 * val1` | `M_DAMAGE = M_DAMAGE val1 0.5 * +` | Wrong operator order (infix not postfix) |
| `DAMAGE = DAMAGE 10 +` | `B_DAMAGE = B_DAMAGE 10 +` | Missing coefficient prefix |

---

## Decision Tree: B_ vs A_

- **Use B_**: When bonus should scale with M_ multipliers
  Example: `B_HP = B_HP 50 +` → Affected by M_HP percentage bonuses

- **Use A_**: When bonus should be flat (no scaling)
  Example: `A_HP = A_HP 50 +` → Always exactly +50 HP regardless of multipliers

---

## Example Mod Structure

```yaml
modid: 42
name: BLOOD MAGE NANITES
val: 0.25          # HP sacrifice %
val2: 1.5          # Damage boost %
equation: M_HP = M_HP -val1 +; M_GUNDAMAGE = M_GUNDAMAGE val2 +
```

**Result**: -25% max HP, +150% gun damage
