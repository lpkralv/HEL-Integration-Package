# Integration Checklist
**HEL Stats/Mods System - Developer Implementation Guide**

Use this checklist to track your integration progress. Check off items as you complete them.

---

## Pre-Integration Setup

- [ ] Unity project version compatibility verified
- [ ] YamlDotNet package installed/available
- [ ] HEL4Unity package present and functional
- [ ] Current stats/mods data backed up
- [ ] Read `00-QUICK-START.md`
- [ ] Reviewed `DELIVERABLE-System-Philosophy.md` sections 1-3

---

## Phase 1: Asset Import

- [ ] Copy `deliverables/StatsData.asset` to Unity project
- [ ] Copy `deliverables/ModsData.asset` to Unity project
- [ ] Verify YAML parsing (check Unity console for errors)
- [ ] Confirm 27 new stats loaded successfully
- [ ] Confirm all 155 mods loaded successfully
- [ ] Test asset reload/reimport functionality

---

## Phase 2: Stats System Integration

### New Stats Implementation (27 stats)

**Core Combat (8 stats):**
- [ ] CRITCHANCE - Critical hit probability (0-1)
- [ ] CRITDAMAGE - Critical damage multiplier (default 1.5)
- [ ] PROJECTILESPEED - Projectile velocity
- [ ] PIERCINGSHOTS - Enemy penetration count
- [ ] RELOADSPEED - Reload time multiplier
- [ ] AMMOCAPACITY - Magazine size
- [ ] LIFESTEAL - Damage-to-HP conversion (0-1)
- [ ] CHAINLIGHTNING - Electric arc jump count

**Defense/Survival (7 stats):**
- [ ] SHIELDCAPACITY - Shield pool maximum
- [ ] SHIELDREGENRATE - Shield regen per second
- [ ] DODGECHANCE - Evasion probability (0-1)
- [ ] DAMAGEABSORPTION - Flat damage reduction
- [ ] THORNDAMAGE - Retaliatory damage
- [ ] REFLECTDAMAGE - Damage reflection percentage (0-1)
- [ ] MAXHPPERCENTBONUS - HP cap multiplier

**Resource Management (5 stats):**
- [ ] ENERGYCAPACITY - Energy pool maximum
- [ ] ENERGYREGEN - Energy regen per second
- [ ] COOLDOWNREDUCTION - Cooldown multiplier (0-1)
- [ ] RESOURCEEFFICIENCY - Cost reduction (0-1)
- [ ] DASHCOOLDOWN - Dash cooldown duration

**Elemental (4 stats):**
- [ ] CORRUPTIONCHANCE - Corruption DoT probability (0-1)
- [ ] CORRUPTIONDAMAGE - Corruption tick damage
- [ ] ELEMENTALPENETRATION - Resistance bypass (0-1)
- [ ] IGNITESPREAD - Fire propagation range

**Minion/Summoner (3 stats):**
- [ ] MINIONDAMAGE - Minion damage multiplier
- [ ] MINIONHP - Minion health multiplier
- [ ] MINIONATTACKSPEED - Minion attack rate multiplier

### Stats System Tasks

- [ ] Add all 27 stat definitions to game code
- [ ] Update stat coefficient dictionaries (S_, B_, A_, M_, Z_, U_, T_)
- [ ] Implement stat min/max clamping from StatsData.asset
- [ ] Add UI display for new stats (player HUD, character sheet)
- [ ] Test stat modification through HEL equation evaluation

---

## Phase 3: HEL Equation System

- [ ] Review `technical/Foundation-HEL-Guide.md`
- [ ] Verify HELInterpreter.cs coefficient handling
- [ ] Confirm coefficient formula: `Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)`
- [ ] Test basic equations: `M_GUNDAMAGE = M_GUNDAMAGE + 0.5`
- [ ] Test conditional equations: `(T_HP S_HP 0.5 * <) val1 *` (Berserker mechanics)
- [ ] Test cross-stat scaling: `T_PLAYERSPEED 0.01 * val1 *` (speed-to-damage)
- [ ] Test RAND mechanics: `RAND val1 * -0.5 +` (Chaos Variance)
- [ ] Verify VAL/VAL1/VAL2 placeholder substitution

---

## Phase 4: Mod Application System

- [ ] Implement mod type handling (0=passive, 2=ranged, 4=melee, 10=syringe)
- [ ] Create mod rarity tier display system (Standard/Enhanced/Advanced/Prototype)
- [ ] Implement mod inventory/storage
- [ ] Implement mod equipping/unequipping
- [ ] Test mod stacking (particularly syringes)
- [ ] Verify modweight-based drop rates
- [ ] Test mod removal (stats revert correctly)

---

## Phase 5: New Mechanics Implementation

- [ ] **Critical Strike System** - CRITCHANCE triggers, CRITDAMAGE multiplier applied
- [ ] **Shield System** - SHIELDCAPACITY buffer, SHIELDREGENRATE restoration
- [ ] **Dodge System** - DODGECHANCE evasion rolls per attack
- [ ] **Thorns/Reflect** - THORNDAMAGE and REFLECTDAMAGE on hit received
- [ ] **Lifesteal** - LIFESTEAL converts damage to HP restoration
- [ ] **Corruption DoT** - CORRUPTIONCHANCE procs, CORRUPTIONDAMAGE ticks
- [ ] **Elemental Penetration** - ELEMENTALPENETRATION bypasses resistances
- [ ] **Minion System** - MINIONDAMAGE/HP/ATTACKSPEED affect spawned units
- [ ] **Resource Systems** - ENERGYCAPACITY/REGEN, COOLDOWNREDUCTION functional
- [ ] **Chain Lightning** - CHAINLIGHTNING arcs to nearby enemies
- [ ] **Ignite Spread** - IGNITESPREAD propagates fire DoT

---

## Phase 6: Mod Class Testing

### Weapons (55 mods)
- [ ] Ballistic Assemblies (15 mods, IDs 1000-1014)
- [ ] Energy Emitters (10 mods, IDs 1015-1024)
- [ ] Explosive Launchers (9 mods, IDs 1025-1033)
- [ ] Deployable Systems (10 mods, IDs 1034-1043)
- [ ] Hybrid Platforms (4 mods, IDs 1044-1047)
- [ ] Melee Implements (7 mods, IDs 1048-1054)

### Items (50 mods)
- [ ] Structural Plating (8 mods, IDs 2000-2007)
- [ ] Mobility Enhancements (7 mods, IDs 2008-2014)
- [ ] Regeneration Systems (6 mods, IDs 2015-2020)
- [ ] Offensive Augments (8 mods, IDs 2021-2028)
- [ ] Resistance Arrays (6 mods, IDs 2029-2034)
- [ ] Resource Optimizers (8 mods, IDs 2035-2042)
- [ ] Tactical Modules (7 mods, IDs 2043-2049)

### Syringes (50 mods)
- [ ] Combat Stimulants (10 mods, IDs 3000-3009)
- [ ] Defensive Protocols (10 mods, IDs 3010-3019)
- [ ] Metabolic Enhancers (10 mods, IDs 3020-3029)
- [ ] Elemental Infusions (9 mods, IDs 3030-3038)
- [ ] Tactical Injections (8 mods, IDs 3039-3046)
- [ ] Exotic Formulas (4 mods, IDs 3047-3050)

---

## Phase 7: Build Archetype Validation

Test each archetype with representative mods:

- [ ] **Fortress Tank** - HP/Armor stacking, thorns damage, resistances
- [ ] **Glass Cannon** - Crit chance/damage, high gun damage, low HP
- [ ] **Elemental Savant** - Elemental chance/damage, penetration, multi-element
- [ ] **Summoner Commander** - Minion count/damage/HP, deployables
- [ ] **Speed Demon** - Player speed, dash mechanics, dodge chance
- [ ] **Hybrid Berserker** - Gun+melee damage, lifesteal, weapon switching
- [ ] **DoT Specialist** - Proc rate, elemental spreading, AoE
- [ ] **Precision Sniper** - Accuracy, range, crit damage, long-range

### Unique Transformations
- [ ] Elemental Purist (3038) - 100% elemental damage conversion
- [ ] Thorn Fortress (3050) - Armor-to-thorns scaling
- [ ] Speed Destroyer (3049) - Speed-to-damage conversion
- [ ] Chaos Gambler (3048) - Random damage variance (10%-190%)
- [ ] Glass Berserker (3047) - Low-HP damage scaling
- [ ] Perfect Marksman (3046) - 100% accuracy guarantee
- [ ] Resistant Savant (2033) - Resistance-to-penetration conversion

---

## Phase 8: Balance & Trade-offs Validation

- [ ] Standard tier mods have zero penalties
- [ ] Enhanced tier penalties are 8-15%
- [ ] Advanced tier penalties are 15-25%
- [ ] Prototype tier penalties are 20-40%
- [ ] Trade-offs apply correctly (negative values in equations)
- [ ] Damage scaling limits enforced (max +150% from single mod)
- [ ] Resistance caps at 90% (never 100%)
- [ ] Crit damage caps appropriately

---

## Phase 9: Lore Compliance

- [ ] All player-visible descriptions use nanomolecular terminology
- [ ] No biological terms (blood, flesh, poison, etc.) in UI
- [ ] No confidential lore references (HIOX-One, reset cycles, etc.)
- [ ] Mod names appropriate for nanomolecular theme

---

## Phase 10: Performance & Polish

- [ ] HEL equation evaluation performance acceptable (profile if needed)
- [ ] Mod tooltips display correctly
- [ ] Stat UI updates in real-time
- [ ] Drop rates feel appropriate for rarity tiers
- [ ] Audio/visual feedback for new mechanics (crits, shields, thorns, etc.)
- [ ] Save/load system handles new stats and mods

---

## Phase 11: Playtesting

- [ ] Internal playtesting session completed
- [ ] All 8 archetypes playable and fun
- [ ] Build diversity validated (players find different combinations)
- [ ] Balance issues documented
- [ ] Bug reports collected
- [ ] Iteration plan created

---

## Phase 12: Documentation

- [ ] Internal wiki updated with new stats
- [ ] Designer guide for creating new mods
- [ ] Player-facing documentation (if applicable)
- [ ] Troubleshooting guide for common issues
- [ ] Balance tuning notes documented

---

## Completion Criteria

✅ **Integration is complete when:**
- All 27 new stats functional in-game
- All 155 mods can be equipped and work correctly
- All 8 build archetypes are viable
- Trade-offs function as designed
- Performance is acceptable
- Playtesting validates fun and balance

---

## Common Issues & Solutions

**Issue:** YAML parsing errors on asset import
- **Solution:** Check YamlDotNet version, verify YAML syntax in .asset files

**Issue:** HEL equations not evaluating correctly
- **Solution:** Review `technical/Foundation-HEL-Guide.md`, check postfix notation

**Issue:** Trade-offs not applying
- **Solution:** Verify negative values in equations (e.g., `+ (-0.15)`)

**Issue:** Stats not clamping to min/max
- **Solution:** Ensure coefficient formula includes Min/Max clamping

**Issue:** Mods not stacking
- **Solution:** Confirm equations use `+=` pattern: `M_X = M_X + val1`

---

**For reference materials, see `reference/` directories and `technical/` guides.**
