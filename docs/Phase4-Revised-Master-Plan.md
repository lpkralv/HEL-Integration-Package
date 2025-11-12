# Revised Master Plan for HIOX Stats/Mods System Design
## Based on Phase 4 Review Feedback

**Version**: 2.0 (Revised)
**Date**: 2025-11-10
**Status**: Ready for Execution

---

## Changes from Original Plan

### Critical Revisions Made:

1. ✅ **Added Foundation Stage** - New Stage 4.5 to analyze formats and create templates
2. ✅ **Reduced Scope** - Target 25-35 stats, 40-60 mods (was 30-50 stats, 60-100 mods)
3. ✅ **HEL Equations in Creative Phase** - Moved from asset creation to creative design
4. ✅ **HEL Education Materials** - Explicit constraint guides for all subagents
5. ✅ **Lore Confidentiality Protocol** - Safeguards against leaking classified lore
6. ✅ **Universal Lore Briefing** - All 6 creative subagents get identical lore context
7. ✅ **Clarified HEL vs Game Engine** - Separated equation design from engine features
8. ✅ **Build Archetype Stage** - Explicit stage for designing 5-8 build archetypes
9. ✅ **Sequential Specialized Designers** - Stage 5.2 now follows Stage 5.1
10. ✅ **Validation Checkpoints** - Added mid-process HEL/lore validation

### Resource Reallocation:

- **Original Plan**: 26 subagents (4 plan review + 8 creative + 7 synthesis + 5 doc + 2 asset)
- **Revised Plan**: 25 subagents (3 foundation + 6 creative + 1 archetype + 7 synthesis + 6 doc/asset + 2 validation)
- **Creative Subagents**: Reduced from 8 to 6 (more manageable synthesis)
- **Deliverable Scope**: 25-35 stats, 40-60 mods (achievable quality target)

---

## Project Goal

Design a comprehensive Stats/Mods system for the HIOX game that:
1. Fits the nanomolecular lore with NO confidential lore leaks
2. Creates deep build diversity through 5-8 distinct archetypes
3. Balances power with meaningful trade-offs
4. Leverages HEL's coefficient system within technical constraints
5. Takes inspiration from Path of Exile's acclaimed design principles
6. Produces complete, valid documentation and asset files

## Deliverables

1. **System Philosophy.md** - Overall system design and philosophy
2. **Stats Description.md** - 25-35 stats with full details
3. **Mods Description.md** - 40-60 mods with full details
4. **StatsData.asset** - Valid YAML format stat definitions
5. **ModsData.asset** - Valid YAML format mod definitions with working HEL equations

---

## Stage 4.5: Foundation Preparation (NEW)

**Goal**: Create reference materials that all creative subagents will use to ensure consistency, technical feasibility, and lore compliance.

### Subagent FP1: Format & Schema Analyzer

**Task**: Analyze existing asset files and create format guide

**Inputs**:
- /src/StatsData.asset
- /src/ModsData.asset
- /src/HELAssetDefs.cs

**Deliverable**: Create `/docs/Foundation-Format-Guide.md` containing:
- Complete YAML schema for Stats (name, desc, value, min, max)
- Complete YAML schema for Mods (all 14 fields explained)
- Mod type conventions (0, 2, 4, 10, 20 meanings)
- Value range analysis (HP: 0-5000, ACCURACY: 0-1, etc.)
- UUID generation pattern
- modid assignment strategy
- Example complete Stat entry (annotated)
- Example complete Mod entry (annotated)

### Subagent FP2: HEL Capability Reference Creator

**Task**: Create comprehensive HEL constraint and capability guide

**Inputs**:
- /docs/Phase1-HEL-System-Analysis.md
- /docs/HEL-Documentation-Complete.md
- /src/HEL.cs, HELLexer.cs, HELInterpreter.cs

**Deliverable**: Create `/docs/Foundation-HEL-Guide.md` containing:

**Section 1: Core Concepts**
- SubStat coefficient system (S_, B_, A_, M_, Z_, U_, T_)
- Final computation formula with examples
- VAL/VAL1/VAL2 substitution mechanism

**Section 2: What HEL CAN Do** ✅
- Cross-stat dependencies (B_MELEEDAMAGE = B_MELEEDAMAGE + S_GUNDAMAGE * 0.3)
- Mathematical functions (MIN, MAX, CEIL, FLOOR, RAND)
- Boolean conditionals as math ((T_HP < 100) * 0.5)
- Complex scaling (MIN(0.5, T_MOVESPEED / 200))
- Min/max boundary manipulation (Z_HP, U_HP)
- Trade-off equations (M_DAMAGE = 0.5; M_FIRERATE = 1.5)

**Section 3: What HEL CANNOT Do** ❌
- No procedural logic (if/then/else statements)
- No string manipulation
- No temporal effects (durations, stacks tracked outside HEL)
- No item combining/crafting (game engine responsibility)
- Max 2 values per mod (val, val2)
- No loops or recursion

**Section 4: Example Equation Patterns**
- 15 working example equations with explanations
- Common patterns (percentage boost, flat bonus, conditional, cross-stat synergy)
- Anti-patterns (things that won't work)

### Subagent FP3: Lore Constraint Documenter

**Task**: Create comprehensive lore guide with confidentiality protocols

**Inputs**:
- /docs/New Stats/Mods Definition.md (INCLUDING confidential section)
- /docs/Phase1-HEL-System-Analysis.md

**Deliverable**: Create `/docs/Foundation-Lore-Guide.md` containing:

**Section 1: CONFIDENTIALITY PROTOCOL** 🔒
- List of classified information that must NOT appear in player-visible content:
  - HIOX-One's identity
  - Player being HIOX-One
  - HIOX-Estel and the ruse
  - HIOX-One's suicidal mission
  - Beacons designed to increase difficulty
  - Reset cycle mechanism
  - Human origin of nanites
- Examples of SAFE vs UNSAFE naming/descriptions
- Validation checklist for each mod/stat description

**Section 2: Foundational Lore Constraints**
- NO biological matter (no blood, flesh, bones, plants, animals, food)
- EVERYTHING is programmable nanomachines
- Player is advanced nanite being (but doesn't know it - confidential)
- Beacons dispense mods as rewards for defense
- World is mechanical sun, nanite creatures, converted terrain

**Section 3: Nanomolecular Theming Guide**
- How to describe damage types (fire = thermal nanite disruption, not combustion)
- How to describe healing (nanite repair, not regeneration)
- How to describe minions (fabricated constructs, not summoned creatures)
- How to describe weapons (configured nanite assemblies, not forged metal)
- Appropriate terminology: protocols, configurations, cores, assemblies, injections, modules

**Section 4: Lore-Appropriate Concepts**
- ✅ Nanite injections modifying player capabilities
- ✅ Thermal/electric/corruption disruption of enemy nanites
- ✅ Fabricated minion constructs
- ✅ Hardened nanite shells (armor)
- ✅ Beacon-transmitted protocols
- ❌ Blood magic
- ❌ Poison/toxins (unless as nanite corruption)
- ❌ Necromancy/souls
- ❌ Biological themes

### Consolidation: Creative Instruction Package

After FP1-3 complete, create master brief for all creative subagents:
`/docs/Creative-Subagent-Instructions.md`

**Contains**:
1. Project goals and deliverables
2. Format guide (from FP1)
3. HEL capability guide (from FP2)
4. Lore constraint guide (from FP3)
5. Scope target (4-6 stats, 6-10 mods per subagent)
6. Deliverable template

**Timeline**: Foundation stage completes before Stage 5 begins

---

## Stage 5: Creative Design Phase

**Goal**: Generate multiple diverse creative visions for Stats/Mods system

**Revised Scope**: 6 creative subagents (was 8) producing 25-35 stats, 40-60 mods total

### Stage 5.1: Core System Architecture (3 Subagents in Parallel)

Each subagent receives:
- `/docs/Creative-Subagent-Instructions.md` (Foundation package)
- `/docs/Phase1-HEL-System-Analysis.md` (current system)
- `/docs/Phase2-PoE-Research.md` (PoE inspiration)

Each subagent must deliver:
- 8-12 new stats with descriptions
- 12-20 mods with descriptions AND draft HEL equations
- Example synergies between mods
- How designs fit lore (confidentiality check)
- Balance rationale

**Subagent C1 - "Nanomolecular Systems Architect"**
- **Focus**: Deep nanite lore integration + synergy design
- **Approach**: Every stat/mod reflects nanomolecular nature with cross-stat interactions
- **Emphasis**: Narrative consistency, thematic immersion, emergent build synergies
- **Deliverable**: `/docs/Creative-C1-Nanomolecular-Systems.md`

**Subagent C2 - "Risk/Reward Balance Designer"**
- **Focus**: Powerful effects with meaningful downsides + progression curve
- **Approach**: No "strictly better" mods - all power comes with cost
- **Emphasis**: Game balance, difficult choices, trade-off mechanics
- **Deliverable**: `/docs/Creative-C2-Risk-Reward-Balance.md`

**Subagent C3 - "PoE-Inspired Depth Architect"**
- **Focus**: Layered complexity, build enabling effects, archetype definition
- **Approach**: Adapt PoE principles (synergies, build-defining items, scaling)
- **Note**: Remember PoE's crafting/rarity is game engine, focus on HEL-implementable stat interactions
- **Emphasis**: Proven ARPG patterns adapted to HIOX
- **Deliverable**: `/docs/Creative-C3-PoE-Inspired-Depth.md`

**Output**: 3 complete creative visions (24-36 stats, 36-60 mods total in aggregate)

### Stage 5.2: Build Archetype Design (1 Subagent, Sequential after 5.1)

**Subagent C4 - "Build Archetype Designer"**

**Task**: Using outputs from C1-C3, design 5-8 distinct build archetypes

**Inputs**: Creative-C1, C2, C3 outputs

**Must design**:
1. **Archetype Name** (e.g., "Thermal Disruptor", "Minion Commander", "High Mobility Assassin")
2. **Core Concept**: 2-3 sentence description
3. **Key Stats**: Which stats this build prioritizes
4. **Core Mods**: Which 3-5 mods enable this archetype
5. **Synergies**: How mods/stats interact multiplicatively
6. **Playstyle**: How this feels different from other builds
7. **Trade-offs**: What this build sacrifices
8. **Lore Fit**: How this reflects nanite capabilities

**Deliverable**: `/docs/Creative-C4-Build-Archetypes.md`

### Stage 5.3: Specialized System Expansion (2 Subagents in Parallel, Sequential after 5.2)

These subagents expand specific systems based on C1-C4 foundations

**Subagent C5 - "Elemental & Proc Systems Specialist"**

**Task**: Expand Fire/Electric/Corruption damage systems

**Receives**: C1-C4 outputs to understand established patterns

**Must deliver**:
- 3-5 new stats for elemental mechanics (if needed beyond existing)
- 8-12 mods focused on elemental damage, procs, resistance interactions
- Draft HEL equations for all mods
- Nanomolecular explanations (fire = plasma disruption, electric = EM interference)
- **Deliverable**: `/docs/Creative-C5-Elemental-Proc-Systems.md`

**Subagent C6 - "Mobility, Defense & Weapon Diversity Specialist"**

**Task**: Expand movement, tanking, and weapon variety

**Receives**: C1-C4 outputs to understand established patterns

**Must deliver**:
- 3-5 new stats for mobility/defense (if needed)
- 8-12 mods for movement builds, defensive builds, unique weapons
- Draft HEL equations for all mods
- Nanomolecular weapon concepts (hardened shells, projected fields)
- **Deliverable**: `/docs/Creative-C6-Mobility-Defense-Weapons.md`

**Output**: 6 creative documents with 25-35 total stats, 40-60 total mods (with draft equations)

**Timeline**: C1-C3 parallel → C4 sequential → C5-C6 parallel

---

## Stage 6: Synthesis & Validation Phase

**Goal**: Merge best ideas into unified, validated design

### Stage 6.1: HEL Equation Validation Checkpoint (NEW)

**Validation Subagent V1**: Review all draft HEL equations from Stage 5

**Task**:
- Check every equation for HEL syntax validity
- Identify impossible equations (procedural logic, etc.)
- Flag equations needing game engine support (temporal effects)
- Suggest corrections for fixable issues
- Rate each mod: ✅ Valid, ⚠️ Needs Revision, ❌ Impossible

**Deliverable**: `/docs/Validation-V1-HEL-Equations.md`

**Critical**: If >20% of mods are ❌ Impossible, STOP and revise creative stage instructions

### Stage 6.2: First Round Pairwise Synthesis (3 Subagents in Parallel)

**Synthesis Subagent S1**: Merge C1 (Nanomolecular) + C2 (Risk/Reward)
- Identify complementary stats/mods
- Resolve conflicts (prefer better-designed option)
- Integrate lore + balance perspectives
- **Output**: `/docs/Synthesis-S1-Lore-Balance-Merge.md`

**Synthesis Subagent S2**: Merge C3 (PoE-Inspired) + C4 (Build Archetypes)
- Integrate depth mechanics with archetype definitions
- Ensure each archetype has sufficient mod support
- **Output**: `/docs/Synthesis-S2-Depth-Archetypes-Merge.md`

**Synthesis Subagent S3**: Merge C5 (Elemental) + C6 (Mobility/Defense/Weapons)
- Integrate specialized systems
- Ensure compatibility
- **Output**: `/docs/Synthesis-S3-Specialized-Systems-Merge.md`

### Stage 6.3: Second Round Synthesis (2 Subagents in Parallel)

**Synthesis Subagent S4**: Merge S1 + S2
- Combine core architecture (lore, balance, depth, archetypes)
- **Output**: `/docs/Synthesis-S4-Core-Architecture.md`

**Synthesis Subagent S5**: Integrate S3 (specialized) into S4 (core)
- Ensure specialized systems work with core architecture
- Check that build archetypes utilize specialized systems
- **Output**: `/docs/Synthesis-S5-Integrated-System.md`

### Stage 6.4: Lore Audit Checkpoint (NEW)

**Validation Subagent V2**: Audit S5 for confidentiality leaks

**Task**:
- Review every stat/mod name and description
- Flag any mentions of classified lore
- Check nanomolecular theming consistency
- Verify lore-appropriate terminology usage

**Deliverable**: `/docs/Validation-V2-Lore-Audit.md`

**Critical**: If lore leaks found, revise S5 before proceeding

### Stage 6.5: Final Synthesis

**Synthesis Subagent S6**: Create final unified design

**Inputs**: S5 (integrated system) + V1 (HEL validation) + V2 (lore audit)

**Task**:
- Apply fixes from validation checkpoints
- Finalize stat list (25-35 stats)
- Finalize mod list (40-60 mods)
- Ensure HEL equation validity
- Confirm lore compliance
- Validate build archetypes have proper support

**Deliverable**: `/docs/Final-Unified-Design.md` (master design document)

---

## Stage 7: Documentation & Asset Creation

**Goal**: Transform final design into deliverables

### Stage 7.1: Documentation Creation (3 Parallel Subagents)

**Doc Subagent D1**: Create `System Philosophy.md`

**Inputs**: Final-Unified-Design.md

**Must include**:
- System components overview
- How components work together
- Lore integration explanation
- PoE inspiration adapted to HIOX
- Balance philosophy
- Build archetype summary
- HEL coefficient system utilization

**Doc Subagent D2**: Create `Stats Description.md`

**Inputs**: Final-Unified-Design.md, Foundation-Format-Guide.md

**For each stat**:
- Name
- Description (player-visible, lore-compliant)
- How it fits lore (design notes)
- Game mechanics requirements (what engine must do)
- How it improves the game
- Balance considerations

**Doc Subagent D3**: Create `Mods Description.md`

**Inputs**: Final-Unified-Design.md, Foundation-Format-Guide.md

**For each mod**:
- Name
- Description (player-visible, lore-compliant)
- HEL equation (documented)
- How it fits lore
- Synergies with other mods
- Visual description (if physical object like weapon)
- Game mechanics requirements
- How it improves the game
- Balance considerations

### Stage 7.2: Asset File Creation (2 Parallel Subagents)

**Asset Subagent A1**: Create `StatsData.asset`

**Inputs**: Final-Unified-Design.md, Stats Description.md, Foundation-Format-Guide.md

**Task**:
- Convert stats to YAML format matching existing schema
- Set appropriate value/min/max ranges
- Validate YAML syntax
- Ensure naming consistency (UPPERCASE)

**Asset Subagent A2**: Create `ModsData.asset`

**Inputs**: Final-Unified-Design.md, Mods Description.md, Foundation-Format-Guide.md, Foundation-HEL-Guide.md

**Task**:
- Convert mods to YAML format matching existing schema
- Format HEL equations (already written in creative phase, just formatting)
- Assign modid sequentially
- Generate UUID for each mod
- Set val/val2 ranges (val1min/max, val2min/max)
- Assign mod types (0=passive, 2=weapon, 4=melee, 10=common, 20=starting)
- Set modweight for rarity
- Validate YAML syntax
- Ensure naming consistency (UPPERCASE)

### Stage 7.3: Final Validation

**Validation Subagent V3**: Comprehensive deliverables review

**Task**:
- Verify all 5 deliverables exist and are complete
- Check YAML syntax validity (can use parser if available)
- Cross-reference consistency (stats mentioned in mods exist)
- Verify HEL equations match documented equations
- Confirm lore compliance in all player-visible text
- Check that 5-8 build archetypes are well-supported by mods
- Validate scope achieved (25-35 stats, 40-60 mods)

**Deliverable**: `/docs/Validation-V3-Final-Report.md` + any required fixes

---

## Execution Timeline

### Sequential Flow:
```
Stage 4.5: Foundation Preparation
  ├─> FP1, FP2, FP3 (parallel) → Consolidate

Stage 5: Creative Design
  ├─> Stage 5.1: C1, C2, C3 (parallel)
  ├─> Stage 5.2: C4 (sequential, uses 5.1 outputs)
  └─> Stage 5.3: C5, C6 (parallel, use 5.1-5.2 outputs)

Stage 6: Synthesis & Validation
  ├─> Stage 6.1: V1 validates HEL equations
  ├─> Stage 6.2: S1, S2, S3 (parallel pairwise synthesis)
  ├─> Stage 6.3: S4, S5 (sequential synthesis)
  ├─> Stage 6.4: V2 validates lore compliance
  └─> Stage 6.5: S6 final synthesis (integrates V1, V2 feedback)

Stage 7: Documentation & Assets
  ├─> Stage 7.1: D1, D2, D3 (parallel documentation)
  ├─> Stage 7.2: A1, A2 (parallel asset creation)
  └─> Stage 7.3: V3 final validation
```

### Total Subagents: 25
- Foundation: 3 (FP1, FP2, FP3)
- Creative: 6 (C1-C6)
- Validation: 3 (V1, V2, V3)
- Synthesis: 6 (S1-S6)
- Documentation: 3 (D1, D2, D3)
- Assets: 2 (A1, A2)

### Parallelism Strategy:
- Foundation: 3 parallel
- Creative 5.1: 3 parallel
- Creative 5.3: 2 parallel
- Validation V1: 1 (gates synthesis)
- Synthesis 6.2: 3 parallel
- Synthesis 6.3: 2 sequential
- Validation V2: 1 (gates final synthesis)
- Synthesis 6.5: 1 final
- Documentation: 3 parallel
- Assets: 2 parallel
- Validation V3: 1 final

---

## Success Criteria

✅ All 5 deliverables complete and valid
✅ 25-35 well-designed stats with proper YAML
✅ 40-60 well-designed mods with working HEL equations in YAML
✅ Deep lore integration with NO confidential leaks
✅ 5-8 distinct build archetypes well-supported by mods
✅ Balance through meaningful trade-offs (no strictly better options)
✅ PoE-inspired mechanics adapted to HIOX context
✅ All HEL equations validated as technically feasible
✅ All player-visible content uses nanomolecular theming

---

## Risk Mitigation

| Risk | Mitigation |
|------|-----------|
| HEL equations too complex | V1 validation checkpoint catches issues mid-process |
| Lore leaks | V2 audit checkpoint + confidentiality protocol in foundation |
| Incompatible creative visions | Reduced from 8 to 6 subagents, pairwise synthesis methodology |
| Scope creep | Hard target: 25-35 stats, 40-60 mods (vs original 30-50, 60-100) |
| Context overload | Smaller outputs per subagent (4-6 stats, 6-10 mods each) |
| Format errors | Foundation stage creates format guide, V3 validation |
| Missing archetypes | Explicit C4 subagent for archetype design |

---

## Differences from PoE (Explicit Boundaries)

**HEL Implements** (stat modification via equations):
- ✅ Cross-stat synergies
- ✅ Multiplicative scaling
- ✅ Conditional bonuses (via math)
- ✅ Trade-off mechanics
- ✅ Min/max boundary manipulation

**Game Engine Must Implement** (outside HEL scope):
- 🎮 Item rarity tiers (Normal/Magic/Rare/Unique) - requires drop logic
- 🎮 Prefix/Suffix system - requires item affixType field + crafting UI
- 🎮 Crafting currency operations - requires inventory + UI + reroll logic
- 🎮 Temporal effects - requires duration tracking + effect ticks
- 🎮 Stacking mechanics - requires stack counter + conditional logic

**This Design Focuses On**: Creating compelling stats and mods with HEL equations that enable diverse builds, leaving game engine features for future development.

---

## Next Steps

1. Execute Stage 4.5 (Foundation Preparation) with 3 parallel subagents
2. Wait for consolidation of Creative Instruction Package
3. Execute Stage 5 (Creative Design) in sequential batches
4. Execute Stage 6 (Synthesis & Validation) with checkpoints
5. Execute Stage 7 (Documentation & Assets)
6. Review final deliverables
7. Commit and push to branch

**Ready to begin Stage 4.5!**
