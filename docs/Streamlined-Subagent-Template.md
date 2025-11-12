# Streamlined Creative Subagent Template
## For Small-Scope Design Tasks

**Version**: 2.0 - Minimal Context
**Purpose**: Each subagent designs 2-3 stats and 3-5 mods without overwhelming file reads

---

## ESSENTIAL INFORMATION (Embedded in Prompt)

### HEL Equation Essentials

**Coefficient System:**
- `S_STATNAME` = Starting value (read-only from assets)
- `B_STATNAME` = Base additive (before multiplication)
- `A_STATNAME` = Absolute additive (after multiplication)
- `M_STATNAME` = Multiplicative (0.1 = +10%, -0.3 = -30%)
- `Z_STATNAME` = Minimum value adjustment
- `U_STATNAME` = Maximum value adjustment
- `T_STATNAME` = Final computed value (READ-ONLY, cannot set)

**Formula**: `Final = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`

**What HEL CAN Do:**
```
✅ B_HP = val1                           // Flat addition
✅ M_DAMAGE = M_DAMAGE + val1            // Percentage boost
✅ A_DAMAGE = S_HP * 0.1                 // Cross-stat dependency
✅ M_SPEED = M_SPEED + (T_HP < 100) * 0.5  // Conditional
✅ Z_HP = 50                             // Set minimum to 50
```

**What HEL CANNOT Do:**
```
❌ if (T_HP < 100) { M_DAMAGE = 0.5; }   // No if/then syntax
❌ T_HP = 100                            // Can't set T_ (read-only)
❌ name = "Fire " + name                 // No string manipulation
❌ Apply for 5 seconds                   // No temporal tracking
```

**Key Rule**: Always ADD to coefficients, never overwrite
```
✅ M_DAMAGE = M_DAMAGE + 0.5
❌ M_DAMAGE = 0.5
```

### Format Requirements

**Stats (5 fields):**
```yaml
- name: STATNAME          # UPPERCASE
  desc: Description text  # Sentence case
  value: 100             # Base value
  min: 0                 # Minimum allowed
  max: 5000              # Maximum allowed
```

**Mods (14 fields, key ones):**
```yaml
- modid: 1000                    # Unique number
  uuid: uuid-1000-100010001000   # Pattern: uuid-{id}-{repeating}
  val: 0.5                       # Rolled value
  val2: 1.2                      # Second rolled value
  val1min: 0.1                   # Min for val
  val1max: 1.0                   # Max for val
  val2min: 1.0                   # Min for val2
  val2max: 2.0                   # Max for val2
  name: MOD NAME IN CAPS         # ALL CAPS
  desc: Description with val1/val2 references  # Sentence case
  modweight: 10                  # 0-600, higher = more common
  type: 0                        # 0=passive, 2=weapon, 4=melee, 10=common, 20=starting
  hasProc: 0                     # 0 or 1
  equation: M_DAMAGE=val1;M_SPEED=-val2  # HEL equation
  modColor: {r: 0, g: 0, b: 0, a: 0}     # Usually unused
  armorEffectName: ''            # Usually empty
  armorMeshName: ''              # Usually empty
```

### Lore Requirements

**🔒 CONFIDENTIAL - NEVER MENTION IN PLAYER-VISIBLE TEXT:**
- ❌ HIOX-One's identity or that player is HIOX-One
- ❌ HIOX-Estel or the grand ruse
- ❌ HIOX-One's suicidal mission or desire to die
- ❌ That beacons increase difficulty (not help)
- ❌ Reset cycles or "test" nature
- ❌ Human/Earth origin of nanites

**Nanomolecular Theming (REQUIRED):**
- ✅ Everything is nanomachines (no biological matter)
- ✅ "Healing" = nanite repair/reconstruction
- ✅ "Fire damage" = thermal disruption of nanites
- ✅ "Poison" = nanite corruption/viral code
- ✅ "Minions" = fabricated constructs/drones
- ✅ "Weapons" = nanite assemblies/configurations

**Preferred Terms:**
- Protocols, configurations, assemblies, constructs, cores, modules
- Nanites, nanomolecular, disruption, corruption
- Repair, reconstruction, fabrication
- EM, thermal, kinetic, plasma

**Forbidden Terms:**
- Blood, flesh, bone, organic, biological
- Magic, spells, souls, life essence
- Traditional fantasy terms (unless reframed)

**Safety Check Before Submission:**
□ Does this mention HIOX-One by name? → REJECT
□ Does this hint player's true identity? → REJECT
□ Does this reveal beacon's true purpose? → REJECT
□ Does this use biological terms? → REFRAME
□ Does this use nanomolecular terminology? → REQUIRED

### Design Principles

**1. Trade-offs Required:**
```
❌ BAD: +50% damage (no downside)
✅ GOOD: +50% damage, -30% fire rate
```

**2. Cross-Stat Synergies:**
```
✅ B_MELEEDAMAGE = S_GUNDAMAGE * 0.3
// Creates hybrid gun/melee builds
```

**3. Conditional Bonuses:**
```
✅ M_DAMAGE = M_DAMAGE + (T_HP < 50) * 0.5
// Berserker mechanic - more damage when wounded
```

**4. Build-Enabling:**
```
✅ "Convert 100% of gun damage to fire damage"
// Enables elemental gun builds
```

---

## SUBAGENT PROMPT TEMPLATE

```
You are Creative Subagent [ID]: [Focus Name]

YOUR TASK: Design 2-3 new stats and 3-5 new mods for HIOX.

YOUR FOCUS: [Specific emphasis - e.g., "Elemental damage systems", "Mobility mechanics", "Minion builds"]

ESSENTIAL INFO PROVIDED ABOVE - You have everything you need in this prompt.

DELIVERABLE FORMAT:

## STAT 1: [UPPERCASE_NAME]
**Description (Player-Visible):** [Lore-compliant, nanomolecular terminology]
**Value:** [number] | **Min:** [number] | **Max:** [number]
**Game Mechanics:** [What engine does with this stat]
**Design Rationale:** [Why this improves game]

## MOD 1: [ALL CAPS NAME]
**Type:** [0/2/4/10/20]
**Description (Player-Visible):** [Lore-compliant, uses val1/val2, NO confidential info]
**Equation:** `[HEL equation]`
**Values:** val1: [min]-[max] ([what it controls]), val2: [min]-[max] ([what it controls])
**Modweight:** [0-600]
**Synergies:** [Which stats/mods this works with]
**Balance:** [Trade-offs, downsides]

[Repeat for all stats/mods]

## SYNERGY EXAMPLE
**Build Concept:** [Name]
**How It Works:** [Explain interaction]
**Result:** [Emergent gameplay]

QUALITY CHECKS:
✅ HEL equations are valid (no if/then, add to coefficients, etc.)
✅ NO confidential lore (HIOX-One, Estel, resets, beacon truth)
✅ Nanomolecular terminology (no biological terms)
✅ Trade-offs present (no free power)
✅ Format matches schema above

Save to: /home/user/HEL-Integration-Package/docs/Creative-[ID]-[FocusName].md
```

---

## REVISED EXECUTION PLAN

**Instead of 3 large subagents (8-12 stats, 12-20 mods each):**

Run **10 small subagents** (2-3 stats, 3-5 mods each):
1. Nanite Density & Cohesion systems
2. Thermal disruption mechanics
3. EM interference systems
4. Corruption & viral protocols
5. Structural integrity & armor
6. Mobility & kinetic systems
7. Minion fabrication mechanics
8. Weapon configuration systems
9. Energy & resource management
10. Conditional/threshold mechanics

**Total Output**: 20-30 stats, 30-50 mods (same target, smaller chunks)

**Advantages:**
- ✅ No overwhelming file reads
- ✅ Focused, manageable tasks
- ✅ All essential info in prompt
- ✅ Faster per-subagent execution
- ✅ Easier to validate incrementally

---

This template includes ALL essential information directly in the prompt, eliminating the need for subagents to read large foundation documents.
