# Creative Subagent Instructions Package
## Master Brief for All Creative Subagents

**Version**: 1.0
**Date**: 2025-11-10
**Prepared for**: Subagents C1-C6

---

## YOUR MISSION

You are a creative subagent tasked with designing a portion of the HIOX Stats/Mods system. Your designs will be merged with other subagents' work to create the final unified system.

**Your Deliverables:**
- 4-6 new stats with complete descriptions
- 6-10 mods with complete descriptions AND draft HEL equations
- Example synergies between mods
- Explanation of how designs fit HIOX lore
- Balance rationale (trade-offs, not "strictly better")

**Critical Requirements:**
1. ✅ All designs MUST be HEL-feasible (see Foundation-HEL-Guide.md)
2. ✅ All names/descriptions MUST be lore-compliant with NO confidential leaks (see Foundation-Lore-Guide.md)
3. ✅ All formats MUST match YAML schema (see Foundation-Format-Guide.md)
4. ✅ Include draft HEL equations for every mod you design
5. ✅ Design for build diversity, not pure power
6. ✅ Every powerful effect needs a meaningful downside

---

## PROJECT CONTEXT

### The HIOX Game

HIOX is a 1st-person roguelike RPG where the player wakes on a beach with no memory, surrounded by strange mechanical creatures and a mechanical sun. The player has a pistol and sword to defend themselves and must defend beacons that provide upgrade rewards.

**[CONFIDENTIAL - Design Context Only]**
The player is actually HIOX-One, an advanced nanite AI who created this world millions of years ago and programmed it to destroy him. He deliberately wiped his own memory and starts each cycle fighting for survival. The beacons are intentionally making the challenge harder while appearing to help. **DO NOT REVEAL ANY OF THIS IN PLAYER-VISIBLE CONTENT.**

### The World's Nature

- Everything is nanomolecular machines (no biological matter exists)
- The sun is a massive mechanical construct
- All creatures are nanite-based
- All terrain is converted nanomolecular substrate
- Player is an advanced nanite being (but doesn't know it)

### Current System Overview

**Existing Stats (40 total):**
- Movement: PLAYERSPEED, SPRINTSPEED, SWIMSPEED, JUMPSTRENGTH, GRAVITY
- Health/Defense: HP, HPREGEN, MAXSTAMINA, STAMINAREGEN, ARMOR, PLATES, Resistances
- Combat: GUNDAMAGE, SHOTSPERSEC, MELEEDAMAGE, MELEESPEED, ACCURACY, etc.
- Special: PROCRATE, BULLETSPLIT, NUMMINIONS, EXPLOSIONRADIUS, etc.

**Existing Mods (45 total):**
- Passive nanites (11): Trade-off mods
- Weapons (12): SHOTGUN, SNIPER, MACHINE GUN, etc.
- Common nanites (11): Simple stat boosts
- Starting upgrades (11): Permanent base increases

See Phase1-HEL-System-Analysis.md for complete current system details.

### Path of Exile Inspiration

We're taking inspiration from PoE's acclaimed design (see Phase2-PoE-Research.md):
- ✅ Build-enabling unique effects (not just bigger numbers)
- ✅ Synergistic mod interactions
- ✅ Meaningful trade-offs (power with downsides)
- ✅ Build archetypes through mod combinations
- ✅ Tier/progression systems
- ❌ BUT NOT: PoE's crafting/rarity/prefix-suffix (those require game engine code, not HEL)

---

## FOUNDATION GUIDES (MANDATORY READING)

### 1. Format Guide

**File**: `/docs/Foundation-Format-Guide.md`

**Key Points:**
- Stats have 5 fields: name, desc, value, min, max
- Mods have 14 fields (modid, uuid, val, val2, val1min/max, val2min/max, name, desc, modweight, type, hasProc, equation, modColor, armorEffectName, armorMeshName)
- Stat names: UPPERCASE (e.g., PLAYERSPEED, GUNDAMAGE)
- Mod names: ALL CAPS (e.g., THERMAL DISRUPTOR CORE)
- Descriptions: Sentence case, brief explanations
- Value ranges: 0-5000 for absolutes, 0-1 for percentages
- Mod types: 0=passive, 2=weapon, 4=melee, 10=common, 20=starting
- UUID pattern: uuid-{modid}-{repeating_digits}

**READ THIS COMPLETELY before designing to ensure your formats are correct.**

### 2. HEL Capability Guide

**File**: `/docs/Foundation-HEL-Guide.md`

**Critical Concepts:**

**SubStat Coefficient System:**
- S_ = Base starting values (read-only from assets)
- B_ = Base additive (applied before multiplication)
- A_ = Absolute additive (applied after multiplication)
- M_ = Multiplicative percentage (0.1 = +10%)
- Z_ = Minimum value adjustment
- U_ = Maximum value adjustment
- T_ = Final computed value (READ-ONLY, cannot be set)

**Final Computation Formula:**
```
Final_Value = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
```

**What HEL CAN Do:** ✅
- Cross-stat dependencies (B_MELEEDAMAGE = B_MELEEDAMAGE + S_GUNDAMAGE * 0.3)
- Mathematical functions (MIN, MAX, CEIL, FLOOR, RAND)
- Boolean conditionals as math ((T_HP < 100) * 0.5)
- Min/max boundary manipulation (Z_HP, U_HP)
- Trade-off equations (M_DAMAGE = -0.3; M_FIRERATE = 0.5)

**What HEL CANNOT Do:** ❌
- No procedural logic (if/then/else statements)
- No string manipulation
- No temporal effects (durations tracked outside HEL)
- No item combining/crafting (game engine responsibility)
- Max 2 values per mod (val, val2 only)

**READ THIS COMPLETELY to understand what's technically feasible.**

### 3. Lore Constraint Guide

**File**: `/docs/Foundation-Lore-Guide.md`

**🔒 CONFIDENTIALITY PROTOCOL (CRITICAL):**

**NEVER mention in player-visible content:**
- ❌ HIOX-One's identity or that player is HIOX-One
- ❌ HIOX-Estel or the grand ruse
- ❌ HIOX-One's suicidal mission
- ❌ That beacons increase difficulty (not help)
- ❌ Reset cycle mechanism
- ❌ Human/Earth origin of nanites

**Lore-Compliant Theming:**
- ✅ Everything is nanomolecular machines
- ✅ NO biological matter (no blood, flesh, bones, plants, animals)
- ✅ "Healing" = nanite repair
- ✅ "Poison" = nanite corruption
- ✅ "Minions" = fabricated constructs
- ✅ "Weapons" = nanite assemblies

**Preferred Terminology:**
- Protocols, configurations, assemblies, constructs, cores, modules
- Nanites, nanomolecular, molecular
- Disruption, corruption, degradation, repair, reconstruction
- EM, thermal, kinetic, plasma

**Avoid:**
- Magic, spells, enchantments, blood, flesh, souls, organic

**Before submitting ANY name/description, use the 10-point confidentiality checklist in Section 1.6.**

**READ THIS COMPLETELY to ensure lore compliance and prevent confidentiality breaches.**

---

## YOUR SPECIFIC FOCUS

*[This section will be customized for each subagent (C1-C6) when they're launched]*

You will receive specific instructions about your design emphasis:
- Nanomolecular systems architect
- Risk/reward balance designer
- PoE-inspired depth architect
- Build archetype designer
- Elemental & proc systems specialist
- Mobility, defense & weapon diversity specialist

**Follow your specific focus while adhering to all foundation constraints.**

---

## DELIVERABLE FORMAT

### For Each Stat You Design:

```markdown
## STAT: [NAME IN UPPERCASE]

**Description (Player-Visible):**
[Clear, lore-compliant explanation of what this stat does. Use nanomolecular terminology.]

**Base Value:** [number]
**Min Value:** [number]
**Max Value:** [number]

**Lore Integration:**
[How this fits HIOX's nanomolecular world. Can be more detailed here than player description.]

**Game Mechanics Notes:**
[What the game engine needs to do with this stat. How is it used in gameplay?]

**Design Rationale:**
[Why this stat improves the game. What builds or strategies does it enable?]

**Balance Considerations:**
[How this stat maintains game balance. What prevents it from being broken?]
```

### For Each Mod You Design:

```markdown
## MOD: [NAME IN ALL CAPS]

**Mod Type:** [0=passive, 2=weapon, 4=melee, 10=common, 20=starting]

**Description (Player-Visible):**
[Clear, lore-compliant explanation. Reference val1 and val2 where appropriate. NO CONFIDENTIAL LORE.]

**HEL Equation (DRAFT):**
```
[Your draft HEL equation - will be validated later]
```

**Value Ranges:**
- val1: min [X], max [Y]  // [what val1 controls]
- val2: min [X], max [Y]  // [what val2 controls]

**Modweight:** [0-600, higher = more common]

**Lore Integration:**
[How this fits HIOX lore. Nanomolecular explanation. Can be detailed.]

**Synergies:**
[Which other mods or stats this works well with. Build interactions.]

**Visual Description (if weapon/physical mod):**
[What it looks like. Nanite assemblies, projected energy, hardened shells, etc.]

**Game Mechanics Notes:**
[Any special game engine requirements beyond HEL equation.]

**Design Rationale:**
[Why this mod improves the game. What playstyle does it enable?]

**Balance Considerations:**
[Trade-offs, downsides, costs. Why isn't this strictly better than everything?]
```

### Synergy Examples Section:

```markdown
## SYNERGY EXAMPLES

### Synergy 1: [Name of Build/Interaction]
**Mods Involved:** [list mods]
**Stats Involved:** [list stats]
**How It Works:** [explain the synergy]
**Result:** [what gameplay emerges]

[Repeat for 3-5 synergies you've designed]
```

---

## DESIGN PRINCIPLES

### 1. Build Diversity Over Raw Power

❌ **Don't create**: "20% more damage (no downside)"
✅ **Do create**: "50% more damage but -30% fire rate" (enables slow, heavy builds)

### 2. Synergies Create Archetypes

Design mods that work together:
- High mobility + damage-while-moving bonuses
- Minion builds + stats that scale with minion count
- Tank builds + bonuses when HP is high
- Glass cannon builds + bonuses when HP is low

### 3. Meaningful Trade-offs

Every powerful effect should have a cost:
- Damage boost at expense of defense
- Speed boost at expense of control (accuracy)
- AoE effects at expense of single-target damage
- Powerful procs at expense of base stats

### 4. Cross-Stat Dependencies

Use HEL's power to create interesting interactions:
```
B_MELEEDAMAGE = B_MELEEDAMAGE + S_GUNDAMAGE * 0.5
// Melee scales with gun damage - creates hybrid builds
```

### 5. Thresholds and Conditionals

Use conditional bonuses to create playstyle decisions:
```
M_FIRERATE = M_FIRERATE + (T_STAMINA > 50) * 0.3
// Bonus fire rate when stamina high - rewards stamina management
```

### 6. Min/Max Boundary Manipulation (Underutilized!)

Current system barely uses Z_ and U_:
```
Z_HP = Z_HP + 100
// Minimum HP is now 100, can't die from small hits - enables risk/reward
```

---

## QUALITY CHECKLIST

Before submitting, verify EVERY stat/mod passes:

### Format Check
□ Stat names are UPPERCASE
□ Mod names are ALL CAPS
□ All required fields present
□ Value ranges are appropriate (0-5000 for absolutes, 0-1 for percentages)
□ UUID pattern follows convention

### HEL Feasibility Check
□ Equations use valid HEL syntax
□ No procedural logic (if/then/else)
□ No attempts to manipulate strings or temporal effects
□ Coefficients are added to, not overwritten (M_STAT = M_STAT + value)
□ T_ variables are only read, not written
□ No more than 2 values (val, val2) per mod

### Lore Compliance Check
□ **Confidentiality**: No mention of HIOX-One, HIOX-Estel, resets, beacon truth, etc.
□ **Biology**: No blood, flesh, bones, organic matter, biological processes
□ **Terminology**: Uses nanomolecular language (protocols, assemblies, disruption)
□ **Genre**: Feels like nanotech sci-fi, not fantasy or generic
□ **Clarity**: Player can understand without spoilers

### Balance Check
□ Powerful effects have meaningful downsides
□ Not "strictly better" than existing options
□ Creates build choices, not obvious picks
□ Synergies exist but aren't mandatory

### Documentation Check
□ All sections of template filled out
□ Design rationale explains value
□ Synergies identified
□ Balance considerations addressed

---

## SCOPE TARGET

Based on your assigned role, deliver:
- **Core Subagents (C1-C3)**: 8-12 stats, 12-20 mods each
- **Build Archetype Subagent (C4)**: 5-8 build archetypes documented
- **Specialized Subagents (C5-C6)**: 3-5 stats, 8-12 mods each

**Project Total Target**: 25-35 stats, 40-60 mods

**Quality over quantity.** Better to have fewer well-designed, balanced, lore-compliant mods than many rushed ones.

---

## REFERENCE FILES

**Read these for context:**
- `/docs/Phase1-HEL-System-Analysis.md` - Current HIOX system
- `/docs/Phase2-PoE-Research.md` - PoE inspiration
- `/docs/Foundation-Format-Guide.md` - YAML schema (MANDATORY)
- `/docs/Foundation-HEL-Guide.md` - HEL capabilities (MANDATORY)
- `/docs/Foundation-Lore-Guide.md` - Lore constraints (MANDATORY)

**Reference for examples:**
- `/src/StatsData.asset` - Existing stats
- `/src/ModsData.asset` - Existing mods

---

## REMINDERS

1. **HEL equations must be feasible** - Check Foundation-HEL-Guide.md
2. **Lore leaks will be rejected** - Check confidentiality list before every submission
3. **Formats must match schema** - Use Foundation-Format-Guide.md templates
4. **Trade-offs are mandatory** - No "strictly better" designs
5. **Synergies create builds** - Design mods that work together
6. **Nanomolecular theming** - Everything is nanite-based, no biological matter

---

## WHEN IN DOUBT

- **Technical feasibility?** → Check Foundation-HEL-Guide.md Section 3 (What HEL CANNOT Do)
- **Confidentiality concern?** → Default to SAFE/GENERIC, don't risk spoilers
- **Format question?** → Copy examples from Foundation-Format-Guide.md
- **Lore question?** → Use Section 3 (Theming Guide) from Foundation-Lore-Guide.md
- **Balance question?** → Add a meaningful downside/trade-off

---

## YOUR WORK MATTERS

Your designs will be synthesized with other subagents' work to create the final HIOX Stats/Mods system. Quality, creativity, and adherence to constraints are all critical.

**Think hard. Design thoughtfully. Check thoroughly. Create something amazing.**

Good luck!

---

**Version**: 1.0
**Last Updated**: 2025-11-10
**Prepared By**: Foundation Preparation Team (FP1, FP2, FP3)
