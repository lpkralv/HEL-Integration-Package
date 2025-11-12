# Phase 2: Path of Exile Mods System Research

## Overview

Path of Exile (PoE) is widely regarded as having one of the most sophisticated and engaging item/mod systems in ARPG gaming. This document summarizes key aspects relevant to designing HIOX's new Stats/Mods system.

## Core PoE Mod System Architecture

### Item Rarity Tiers

PoE uses four distinct rarity tiers that determine item power and modification potential:

1. **Normal (White)**: No modifiers, blank slate
2. **Magic (Blue)**: Up to 1 prefix + 1 suffix (2 mods total)
3. **Rare (Yellow)**: Up to 3 prefixes + 3 suffixes (6 mods total)
4. **Unique (Orange)**: Fixed, predetermined modifiers with specific names and artwork

### Prefix/Suffix System

**Key Concept**: Modifiers are categorized as either Prefixes or Suffixes, limiting item power through structural constraints.

**Typical Distribution:**
- **Prefixes**: Life, Movement Speed, Armor, Evasion, Energy Shield, Physical Damage
- **Suffixes**: Resistances, Attributes (STR/DEX/INT), Attack/Cast Speed, Elemental Damage

**Design Benefit**: Prevents items from stacking too many powerful mods of the same type, forcing meaningful trade-offs.

### Modifier Tier System

**Core Mechanic**: Each modifier exists in multiple tiers of increasing power, gated by Item Level.

**Example - Elemental Resistance:**
- Tier 1 (ilvl 2+): +6-11% resistance
- Tier 3 (ilvl 24+): +18-23% resistance
- Tier 7 (ilvl 60+): +35-40% resistance
- Tier 9 (ilvl 82+): +41-45% resistance (highest)

**Design Principle**: Higher-level content rewards players with access to more powerful modifier tiers, creating natural progression.

### Weighting System

**Mechanism**: Each modifier has an assigned weight that determines roll probability.

**Example**: If a mod has weight 1000 in a total pool of 40,000, it has 2.5% chance to roll.

**Design Benefit**:
- Controls rarity of powerful modifiers
- Creates "chase" mods that are highly desirable but hard to obtain
- Enables economy through scarcity

## Crafting System Depth

### Currency-Based Crafting

Unlike traditional crafting with materials, PoE uses **currency orbs** that directly modify items:

1. **Orb of Transmutation**: Normal → Magic (adds 1-2 mods)
2. **Orb of Alteration**: Rerolls Magic item (new random mods)
3. **Orb of Alchemy**: Normal → Rare (adds up to 6 mods)
4. **Chaos Orb**: Rerolls Rare item (all new mods)
5. **Exalted Orb**: Adds 1 random mod to Rare (if space available)
6. **Regal Orb**: Magic → Rare (adds 1 mod, preserves existing)

**Key Insight**: Currency serves dual purpose as crafting tools AND trade currency, creating integrated economy.

### Advanced Crafting Methods

1. **Essences**: Guarantee specific modifier when applied
   - Provides deterministic crafting path
   - "I need +Life, use Essence of Greed"

2. **Fossils** (PoE1): Influence mod pool when used with Resonators
   - Block certain mod types from rolling
   - Increase weight of desired mod types
   - Create specialized crafting strategies

3. **Harvest Crafting** (PoE1): Most targeted crafting
   - Specific reforge options (e.g., "reforge with life mod guaranteed")
   - Respects metacrafting mods
   - Enables high-end deterministic crafting

4. **Metacrafting**: Bench crafts that protect mods
   - "Prefixes Cannot Be Changed" (costs 2 Divine Orbs)
   - "Suffixes Cannot Be Changed"
   - Enables "lock and reroll" strategies

### Crafting Philosophy

**Layered Complexity**:
- Beginners can use simple currency (Alchemy, Chaos)
- Intermediate players learn Essences and basic bench crafting
- Advanced players master Fossil combinations, Harvest, metacrafting
- Economy emerges from scarcity of currency and perfect items

**Progression Path**: Even "perfect" items are extremely difficult and expensive to create, providing endless gear improvement opportunities.

## Build-Enabling Design

### Unique Items as Build Enablers

Rather than being "best in slot" stat-sticks, PoE Uniques often **enable entirely new playstyles**:

**Examples:**

1. **Headhunter** (belt)
   - Gain slain rare monsters' modifiers for 60 seconds
   - Transforms mapping into power fantasy
   - Creates unique risk/reward dynamic

2. **Bringer of Rain** (helmet)
   - Wield two-handed weapons as one-handed
   - Opens impossible build combinations
   - Fundamentally changes equipment possibilities

3. **Hand of Wisdom and Action** (mace)
   - Gain lightning damage from intelligence attribute
   - Enables "attribute stacking" archetype
   - Synergizes with defensive intelligence benefits

**Design Principle**: Uniques that change HOW you play, not just make numbers bigger.

### Synergies and Build Archetypes

**What Makes PoE Builds Compelling:**

1. **Cross-System Synergies**: Items interact with passive tree, skills, and other items in multiplicative ways

2. **Archetype Definition**: Clear build identities emerge:
   - Attribute stackers
   - Critical strike builds
   - Damage-over-time specialists
   - Minion commanders
   - Cast-on-crit trigger builds

3. **Discovery and Innovation**: Players constantly find new interactions between items/skills/mechanics

4. **Trade-offs**: Powerful effects come with significant downsides, forcing build decisions

## Key Lessons for HIOX

### What Makes PoE's System Highly Regarded

1. **Agency**: Players feel in control of item creation through layered crafting options

2. **Depth Without Overwhelming**:
   - Simple at surface (use Alchemy orb, get rare item)
   - Endless depth for those who want to optimize
   - Natural learning curve through gameplay

3. **Economy Integration**: Crafting currency doubles as trade medium, creating vibrant economy

4. **Build Diversity**: Thousands of viable builds through item/skill interactions

5. **Progression Satisfaction**:
   - Incremental improvements always possible
   - "Perfect" gear is aspirational, not achievable for most
   - Each upgrade feels meaningful

6. **Risk/Reward**: Crafting involves gambling and strategy, creating excitement

### Applicable to HIOX

1. **Rarity Tiers**: Could implement Normal/Magic/Rare/Unique system for mod drops
   - Magic: 2 mods (simpler items early game)
   - Rare: Up to 6 mods (complex late game items)
   - Unique: Build-enabling special items

2. **Prefix/Suffix Structure**: Categorize mods to prevent over-stacking
   - Offensive Prefixes: Damage, Fire Rate, Crit
   - Offensive Suffixes: Elemental Effects, Procs, Penetration
   - Defensive Prefixes: HP, Armor, Regen
   - Defensive Suffixes: Resistances, Dodge, Stamina

3. **Tier System**: Mods scale with player progression
   - Early game: +10% damage
   - Mid game: +25% damage
   - Late game: +50% damage
   - Gated by beacon level or area difficulty

4. **Currency Crafting**: Nanite canisters that modify items
   - Transmutation Nanites: Normal → Magic
   - Chaos Nanites: Reroll rare item
   - Exalted Nanites: Add one mod
   - Essence Nanites: Guarantee specific mod type

5. **Build-Enabling Uniques**: Special items that fundamentally change gameplay
   - Not just "better stats"
   - Enable new strategies impossible with rares
   - Create memorable "signature" builds

6. **Synergy Design**: Mods that interact with stats in multiplicative ways
   - "Gain melee damage equal to 1% of max HP"
   - "Proc effects trigger twice but cost stamina"
   - "Convert gun damage to fire damage, ignite chance +100%"

## Constraints for HIOX Adaptation

**HIOX is NOT Path of Exile:**

1. **First-Person vs Isometric**: Different visibility of character/gear
2. **Roguelike Elements**: Runs reset, different permanence model
3. **Simpler Base**: Fewer systems to integrate with
4. **Nanite Lore**: All items must fit nanomolecular theme
5. **No Trade Economy**: Single-player focused (based on task description)
6. **Beacon Reward System**: Items come from defending beacons, not general drops
7. **Smaller Scope**: Can't match PoE's 10+ years of content

**Design Constraints:**

- Keep crafting simpler than PoE (no need for 20+ currency types)
- Focus on build diversity through clever mod interactions
- Ensure all systems fit HIOX lore (nanites, mechanical world, HIOX-One's creation)
- Balance for single-player experience
- Make system discoverable without external tools (PoE needs Path of Building)

## Inspiration Synthesis

**What to Take from PoE:**

1. ✅ Rarity tier system (Normal/Magic/Rare/Unique)
2. ✅ Prefix/Suffix structure for balance
3. ✅ Modifier tiers that scale with progression
4. ✅ Build-enabling unique effects
5. ✅ Synergistic mod design
6. ✅ Meaningful trade-offs (powerful effects with downsides)
7. ✅ Crafting options (simpler subset)

**What to Leave Behind:**

1. ❌ Extreme crafting complexity (too much for HIOX scope)
2. ❌ Trade economy focus (HIOX is single-player)
3. ❌ Infinite mod pool (keep manageable)
4. ❌ League mechanics complexity
5. ❌ Socket/link system (different gear paradigm)

## Conclusion

Path of Exile's mod system succeeds through:
- **Structural constraints** (prefix/suffix, rarity tiers) that force meaningful choices
- **Layered progression** (tier system) that rewards advancement
- **Player agency** (crafting) that creates engagement
- **Build diversity** (synergies, uniques) that encourages experimentation
- **Risk/reward** (gambling) that creates excitement

These principles can be adapted to HIOX while respecting its unique lore, mechanics, and scope.
