# Phase 3: Master Plan for HIOX Stats/Mods System Design

## Project Goal

Design a comprehensive Stats/Mods system for the HIOX game that:
1. Fits the nanomolecular lore and setting
2. Creates deep build diversity through synergies
3. Balances power with meaningful trade-offs
4. Leverages HEL's sophisticated coefficient system
5. Takes inspiration from Path of Exile's acclaimed design
6. Produces complete documentation and asset files

## Deliverables

1. **System Philosophy.md** - Overall system design and philosophy
2. **Stats Description.md** - All stats with full details
3. **Mods Description.md** - All mods with full details
4. **StatsData.asset** - JSON format stat definitions
5. **ModsData.asset** - JSON format mod definitions

## Master Plan Structure

### Phase 4: Master Plan Review and Refinement (via Subagents)

**Goal**: Validate and improve the master plan before execution.

**Process**:
1. Launch 3 review subagents in parallel to critique the master plan:
   - Subagent A: Review for completeness and feasibility
   - Subagent B: Review for alignment with HEL capabilities
   - Subagent C: Review for HIOX lore consistency

2. Synthesize feedback and refine plan

3. Launch 2 validation subagents in parallel:
   - Subagent D: Validate revised plan completeness
   - Subagent E: Identify any remaining issues

4. Finalize master plan

### Phase 5: Creative Design Phase (Parallel Subagents)

**Goal**: Generate multiple diverse creative visions for the Stats/Mods system.

#### Stage 5.1: Core System Architecture Design

**Launch 4 parallel subagents** to independently design complete Stats/Mods systems:

**Subagent 1 - "Nanomolecular Architect"**
- Focus: Deep nanite lore integration
- Approach: Every stat/mod reflects nanomolecular nature
- Emphasis: Narrative consistency and immersion
- Deliverable: Complete system design document

**Subagent 2 - "Synergy Engineer"**
- Focus: Complex build interactions and emergent gameplay
- Approach: Design stats/mods that create multiplicative synergies
- Emphasis: Build diversity and player discovery
- Deliverable: Complete system design document

**Subagent 3 - "Balance Master"**
- Focus: Risk/reward and power curve
- Approach: Every powerful effect has meaningful downside
- Emphasis: Game balance and progression
- Deliverable: Complete system design document

**Subagent 4 - "PoE-Inspired Innovator"**
- Focus: Adapting Path of Exile principles to HIOX
- Approach: Implement rarity tiers, crafting, prefix/suffix system
- Emphasis: Proven ARPG design patterns
- Deliverable: Complete system design document

**Each subagent must design**:
- New stat categories and individual stats (30-50 stats)
- Mod categories and individual mods (60-100 mods)
- System mechanics (crafting, rarity, etc.)
- Example synergies and builds
- Lore integration
- Balance philosophy

**Timeline**: Each subagent works independently and thoroughly

#### Stage 5.2: Specialized Enhancement Design

**Launch 4 parallel subagents** to design specialized aspects:

**Subagent 5 - "Elemental Systems Designer"**
- Focus: Fire, Electric, Corruption damage types and interactions
- Design: Expanded elemental mechanics, resistances, conversions
- Deliverable: Elemental system expansion design

**Subagent 6 - "Minion Systems Designer"**
- Focus: Companion AI and minion build archetype
- Design: Multiple minion types, minion stats, minion mods
- Deliverable: Minion system expansion design

**Subagent 7 - "Mobility & Defense Designer"**
- Focus: Movement, dodging, armor, HP, stamina interactions
- Design: Defensive build archetypes, risk/reward movement
- Deliverable: Mobility/defense system design

**Subagent 8 - "Weapon Diversity Designer"**
- Focus: Unique weapon types with distinct playstyles
- Design: 10-15 weapon archetypes with supporting mods
- Deliverable: Weapon system expansion design

**Timeline**: Each subagent works independently

### Phase 6: Review and Synthesis Phase (Pairwise Parallel Subagents)

**Goal**: Merge the best ideas from all creative subagents into unified design.

#### Stage 6.1: First Round Pairwise Reviews

**Launch 4 parallel review subagents**:

**Review Subagent A**: Compare and synthesize Subagent 1 & 2
- Identify best ideas from each
- Find complementary concepts
- Resolve conflicts
- Create merged document A

**Review Subagent B**: Compare and synthesize Subagent 3 & 4
- Identify best ideas from each
- Find complementary concepts
- Resolve conflicts
- Create merged document B

**Review Subagent C**: Compare and synthesize Subagent 5 & 6
- Identify best elemental and minion ideas
- Create integrated specialized systems
- Create merged document C

**Review Subagent D**: Compare and synthesize Subagent 7 & 8
- Identify best mobility and weapon ideas
- Create integrated specialized systems
- Create merged document D

**Output**: 4 merged documents (A, B, C, D)

#### Stage 6.2: Second Round Pairwise Reviews

**Launch 2 parallel review subagents**:

**Review Subagent E**: Synthesize Merged Documents A & B
- Combine core system architectures
- Balance narrative, synergy, balance, and PoE principles
- Create merged document E

**Review Subagent F**: Synthesize Merged Documents C & D
- Combine specialized system designs
- Integrate elemental, minion, mobility, weapon systems
- Create merged document F

**Output**: 2 merged documents (E, F)

#### Stage 6.3: Final Synthesis

**Launch 1 synthesis subagent**:

**Final Synthesis Subagent G**: Integrate Merged Documents E & F
- Combine core architecture with specialized systems
- Ensure consistency across all systems
- Validate against HEL capabilities
- Check lore integration
- Verify balance philosophy
- Create final unified system design

**Output**: Final comprehensive system design document

### Phase 7: Documentation and Asset Creation

**Goal**: Transform final design into deliverable documentation and asset files.

#### Stage 7.1: Documentation Creation

**Launch 3 parallel documentation subagents**:

**Doc Subagent 1**: Create System Philosophy.md
- Extract and document system philosophy
- Describe components and how they work
- Explain lore integration
- Detail PoE inspiration
- Describe balance approach

**Doc Subagent 2**: Create Stats Description.md
- Document each stat with full details:
  - Name and description
  - Lore integration
  - Game mechanics requirements
  - Game improvement rationale
  - Balance considerations

**Doc Subagent 3**: Create Mods Description.md
- Document each mod with full details:
  - Name and description
  - Lore integration
  - Synergy descriptions
  - Visual descriptions (if physical object)
  - Game mechanics requirements
  - Game improvement rationale
  - Balance considerations

#### Stage 7.2: Asset File Creation

**Launch 2 parallel asset creation subagents**:

**Asset Subagent 1**: Create StatsData.asset
- Convert Stats Description to proper YAML format
- Validate HEL compatibility
- Set appropriate value/min/max ranges
- Ensure naming consistency

**Asset Subagent 2**: Create ModsData.asset
- Convert Mods Description to proper YAML format
- Write HEL equations for each mod
- Set val/val2 ranges appropriately
- Assign mod types and weights
- Ensure naming consistency

#### Stage 7.3: Final Validation

**Launch 1 validation subagent**:

**Validation Subagent**: Review all deliverables
- Check completeness of all documents
- Validate YAML syntax
- Test HEL equations (if possible)
- Check consistency between documents
- Verify lore integration throughout
- Confirm balance philosophy is maintained

## Parallel Execution Strategy

### Critical Path
```
Phase 4: Plan Review (3 parallel → 2 parallel → finalize)
Phase 5: Creative Design (4 parallel Stage 5.1 + 4 parallel Stage 5.2)
Phase 6: Synthesis (4 parallel → 2 parallel → 1 final)
Phase 7: Documentation (3 parallel + 2 parallel + 1 validation)
```

### Maximizing Parallelism

1. **Within each stage**: All subagents run in parallel
2. **Independent work**: Each subagent receives complete context and works autonomously
3. **No sequential dependencies within stages**: All Stage 5.1 subagents can run simultaneously
4. **Clear handoffs between stages**: Stage outputs become next stage inputs

## Subagent Instruction Template

Each subagent will receive:
1. **Full Context**: Lore, HEL system details, PoE research, task requirements
2. **Specific Focus**: Their unique design emphasis
3. **Clear Deliverables**: Exactly what to produce
4. **Creative Freedom**: Encourage bold, innovative ideas
5. **Thoroughness Requirement**: THINK HARD, be comprehensive
6. **Documentation Standards**: Clear formatting for synthesis

## Quality Assurance

### Built-in Quality Mechanisms

1. **Multiple Perspectives**: 4 core + 4 specialized = 8 independent creative visions
2. **Iterative Refinement**: 3 rounds of synthesis (4 pairs → 2 pairs → 1 final)
3. **Explicit Validation**: Dedicated validation subagents at plan and delivery stages
4. **Lore Consistency Checks**: Repeated at multiple stages
5. **Balance Validation**: Baked into synthesis process
6. **HEL Compatibility**: Verified during asset creation

### Success Criteria

✅ Complete deliverables (5 documents/files)
✅ 30-50 well-designed stats
✅ 60-100 well-designed mods with proper HEL equations
✅ Deep lore integration throughout
✅ Clear synergies enabling 5-10 distinct build archetypes
✅ Balance through meaningful trade-offs
✅ PoE-inspired mechanics adapted to HIOX
✅ Valid YAML syntax in asset files
✅ Working HEL equations

## Risk Mitigation

**Risk**: Subagents produce incompatible designs
**Mitigation**: Explicit synthesis stages with conflict resolution

**Risk**: HEL equation complexity too high
**Mitigation**: Asset creation subagents validate against HEL capabilities

**Risk**: Lore inconsistency
**Mitigation**: Multiple lore validation checkpoints

**Risk**: Balance issues
**Mitigation**: Dedicated balance-focused subagent + validation stages

**Risk**: Deliverable format errors
**Mitigation**: Template provision + final validation subagent

## Resource Requirements

- **Total Subagents**: 26 (4 plan review + 8 creative + 7 synthesis + 5 documentation + 2 asset creation + 1 validation)
- **Parallelism**: Up to 8 subagents running simultaneously
- **Documentation**: ~10-15 pages per creative subagent, ~50-100 pages final
- **Time**: Multiple hours given creative and synthesis depth

## Execution Notes

1. Launch subagents in batches per stage
2. Wait for all subagents in stage to complete before advancing
3. Provide complete prior-stage outputs to next-stage subagents
4. Maintain audit trail of all subagent outputs for transparency
5. User receives progress updates between stages

## Next Step

Proceed to Phase 4: Master Plan Review and Refinement with 3 parallel review subagents.
