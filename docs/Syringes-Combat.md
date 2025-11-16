# Combat Stimulant Syringes Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 3000-3009 (10 syringes)
**Class Type:** Combat Stimulants
**Item Type Code:** 10 (syringe/upgrade)

---

## CLASS OVERVIEW

**Combat Stimulants** are offensive nanite injection protocols that enhance combat performance through targeted damage amplification, attack speed optimization, and precision targeting enhancements. These stackable injections provide smaller individual bonuses than items but can be layered for cumulative offensive scaling, forming the foundation of aggressive damage-focused builds without visual cosmetic effects.

**Core Characteristics:**
- Focus on GUNDAMAGE, SHOTSPERSEC, MELEESPEED, MELEEDAMAGE, CRITCHANCE
- Smaller bonuses than items (+5-15% vs +20-50%) but fully stackable
- Enable Glass Cannon, Precision Sniper, and Hybrid Berserker archetypes
- Advanced syringes feature stack-scaling and progressive mechanics
- Prototype tier provides unique "permanent berserk" combat enhancement
- Trade-offs required for balance despite smaller effect sizes

**Build Archetype Support:**
- Glass Cannon (sustained damage output focus)
- Precision Sniper (critical strike and precision damage)
- Hybrid Berserker (melee and gun damage synergy)
- Speed Demon (attack speed and fire rate enhancement)

---

## STANDARD INJECTION TIER (5 syringes)

### SYRINGE: DAMAGE ENHANCEMENT SERUM

**ModID:** 3000
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Offensive protocol injection increasing projectile damage output by val1% through weapon emitter optimization nanites

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +
```

**Values:**
- val1: min 0.08, max 0.12 // Gun damage increase (+8% to +12%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Glass Cannon:** Stackable damage foundation for ranged builds
- **Precision Sniper:** Base damage scaling for critical strike synergy
- **Hybrid Berserker:** Ranged damage component for hybrid strategies
- **Speed Demon:** Damage boost for rapid-fire weapons

**Trade-offs:**
Pure offensive bonus with no penalties - baseline stackable damage injection. Smaller than item equivalents but can stack multiple copies. No melee damage scaling limits pure melee builds

**Lore Notes:**
Nanite combat stimulant recalibrates weapon output matrices for enhanced destructive efficiency without compromising core system stability

---

### SYRINGE: FIRE RATE STIMULANT

**ModID:** 3001
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Attack speed protocol injection increasing projectile firing frequency by val1 shots per second through accelerated targeting cycles

**HEL Equation:**
```
B_SHOTSPERSEC = B_SHOTSPERSEC val1 +
```

**Values:**
- val1: min 0.5, max 1.0 // Fire rate increase (+0.5 to +1.0 shots per second)

**Modweight:** 200

**Build Synergies:**
- **Glass Cannon:** Sustained DPS increase for continuous combat
- **Speed Demon:** Core fire rate scaling for rapid-fire strategies
- **Elemental Savant:** More shots = more elemental proc opportunities
- **DoT Specialist:** Frequent attacks apply damage-over-time effects faster

**Trade-offs:**
Pure offensive bonus with no penalties - stackable fire rate foundation. Increases ammo consumption requiring AMMOCAPACITY investment. More frequent reloads without RELOADSPEED scaling

**Lore Notes:**
Targeting acquisition nanites accelerate weapon cycling protocols, enabling rapid-succession projectile deployment at enhanced frequencies

---

### SYRINGE: MELEE ACCELERATION INJECTION

**ModID:** 3002
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Combat reflex enhancement increasing melee attack execution speed by val1% through motor protocol optimization

**HEL Equation:**
```
M_MELEESPEED = M_MELEESPEED val1 +
```

**Values:**
- val1: min 0.1, max 0.15 // Melee speed increase (+10% to +15%)

**Modweight:** 190

**Build Synergies:**
- **Hybrid Berserker:** Core melee attack speed scaling for aggressive combat
- **Speed Demon:** Complements high-mobility melee strategies
- **Glass Cannon:** Fast melee attacks for emergency close-range defense
- **Fortress Tank:** Attack speed for thorns-based counter-attack builds

**Trade-offs:**
Pure offensive bonus with no penalties - stackable melee speed foundation. Only affects melee weapons, providing no ranged benefit. Requires MELEEDAMAGE investment for meaningful DPS scaling

**Lore Notes:**
Reflex optimization nanites accelerate motor control protocols, enabling faster strike execution and reduced weapon recovery cycles

---

### SYRINGE: PRECISION TARGETING STIMULANT

**ModID:** 3003
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Targeting protocol enhancement increasing critical strike probability by val1% through threat assessment algorithm optimization

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +
```

**Values:**
- val1: min 0.05, max 0.1 // Critical chance increase (+5% to +10%)

**Modweight:** 190

**Build Synergies:**
- **Precision Sniper:** Stackable critical strike chance foundation
- **Glass Cannon:** Burst damage enhancement through crit probability
- **Hybrid Berserker:** Critical strike potential for melee and ranged
- **Elemental Savant:** Critical hits amplify elemental proc damage

**Trade-offs:**
Pure offensive bonus with no penalties - stackable crit foundation. Requires CRITDAMAGE investment for maximum effectiveness. Smaller bonus than item equivalents but fully stackable for extreme crit builds

**Lore Notes:**
Advanced targeting nanites analyze enemy structural weaknesses in real-time, identifying critical vulnerabilities for precision strike exploitation

---

### SYRINGE: MELEE POWER INJECTION

**ModID:** 3004
**Type:** 10 (syringe/upgrade)
**Rarity:** Standard

**Description (Player-Visible):**
Combat enhancement injection increasing melee strike damage by val1% through kinetic amplification protocols

**HEL Equation:**
```
M_MELEEDAMAGE = M_MELEEDAMAGE val1 +
```

**Values:**
- val1: min 0.08, max 0.12 // Melee damage increase (+8% to +12%)

**Modweight:** 190

**Build Synergies:**
- **Hybrid Berserker:** Stackable melee damage foundation for aggressive builds
- **Fortress Tank:** Damage scaling for thorns/reflect counter-attack strategies
- **Speed Demon:** Hit-and-run melee damage enhancement
- **Glass Cannon:** Emergency melee damage for close-range encounters

**Trade-offs:**
Pure offensive bonus with no penalties - stackable melee damage foundation. Only affects melee weapons, providing no ranged benefit. Smaller than item equivalents but can stack multiple copies

**Lore Notes:**
Kinetic amplification nanites concentrate structural force transfer at weapon impact points, maximizing strike damage output per engagement

---

## ENHANCED PROTOCOL TIER (3 syringes)

### SYRINGE: AGGRESSIVE COMBAT PROTOCOL

**ModID:** 3005
**Type:** 10 (syringe/upgrade)
**Rarity:** Enhanced

**Description (Player-Visible):**
Dual-system injection increasing gun damage by val1% and fire rate by val2 shots per second, with 15% reduced armor from power distribution compromises

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; B_SHOTSPERSEC = B_SHOTSPERSEC val2 +; M_ARMOR = M_ARMOR -0.15 +
```

**Values:**
- val1: min 0.1, max 0.15 // Gun damage increase (+10% to +15%)
- val2: min 0.5, max 1.0 // Fire rate increase (+0.5 to +1.0 shots/sec)

**Modweight:** 80

**Build Synergies:**
- **Glass Cannon:** Combined damage and fire rate for sustained DPS scaling
- **Precision Sniper:** Enhanced per-shot damage with follow-up speed
- **Speed Demon:** Damage boost with attack speed synergy
- **Elemental Savant:** More frequent attacks with enhanced damage per hit

**Trade-offs:**
15% armor reduction increases vulnerability to incoming damage. Requires defensive investment (shields, dodge, lifesteal) for survival. Increased fire rate drains ammo reserves faster. Both benefits limited to ranged combat only

**Lore Notes:**
Aggressive nanite protocols divert defensive matrix resources to weapon systems, sacrificing armor integrity for enhanced offensive output and firing cycle acceleration

---

### SYRINGE: BERSERKER COMBAT STIMULANT

**ModID:** 3006
**Type:** 10 (syringe/upgrade)
**Rarity:** Enhanced

**Description (Player-Visible):**
Hybrid offensive injection increasing melee damage by val1% and attack speed by val2%, with 10% reduced maximum structural integrity

**HEL Equation:**
```
M_MELEEDAMAGE = M_MELEEDAMAGE val1 +; M_MELEESPEED = M_MELEESPEED val2 +; M_HP = M_HP -0.1 +
```

**Values:**
- val1: min 0.1, max 0.15 // Melee damage increase (+10% to +15%)
- val2: min 0.1, max 0.15 // Melee speed increase (+10% to +15%)

**Modweight:** 75

**Build Synergies:**
- **Hybrid Berserker:** Complete melee combat package for aggressive playstyles
- **Speed Demon:** Fast, hard-hitting melee for hit-and-run tactics
- **Glass Cannon:** Emergency melee enhancement with damage and speed
- **Fortress Tank:** Counter-attack damage and speed for thorns builds

**Trade-offs:**
10% HP reduction creates moderate fragility requiring careful engagement. Only affects melee combat, providing no ranged benefit. Encourages aggressive close-range tactics despite reduced survivability. Stacks with other HP penalties for extreme glass cannon risk

**Lore Notes:**
Combat stimulant redirects life support nanites to motor and kinetic systems, sacrificing structural capacity for enhanced melee combat efficiency

---

### SYRINGE: CRITICAL PRECISION SERUM

**ModID:** 3007
**Type:** 10 (syringe/upgrade)
**Rarity:** Enhanced

**Description (Player-Visible):**
Precision enhancement injection increasing critical strike chance by val1% and critical damage multiplier by val2%, with 10% reduced movement speed from targeting system overhead

**HEL Equation:**
```
M_CRITCHANCE = M_CRITCHANCE val1 +; M_CRITDAMAGE = M_CRITDAMAGE val2 +; M_PLAYERSPEED = M_PLAYERSPEED -0.1 +
```

**Values:**
- val1: min 0.08, max 0.12 // Critical chance increase (+8% to +12%)
- val2: min 0.15, max 0.25 // Critical damage increase (+15% to +25%)

**Modweight:** 70

**Build Synergies:**
- **Precision Sniper:** Complete critical strike package for burst damage
- **Glass Cannon:** Stackable critical scaling for extreme damage output
- **Hybrid Berserker:** Critical strikes for both melee and ranged combat
- **Elemental Savant:** Critical hits amplify elemental damage effects

**Trade-offs:**
10% movement speed reduction impairs kiting and positioning mobility. Requires commitment to critical strike strategy for value. Movement penalty accumulates if stacking multiple copies. Conflicts with Speed Demon mobility focus. Demands CRITDAMAGE investment for crit scaling

**Lore Notes:**
Advanced targeting matrix integration consumes processing resources from motor control, slowing movement while enhancing strike precision and damage output

---

## ADVANCED MATRIX TIER (1 syringe)

### SYRINGE: ESCALATING FURY PROTOCOL

**ModID:** 3008
**Type:** 10 (syringe/upgrade)
**Rarity:** Advanced

**Description (Player-Visible):**
Progressive combat enhancement granting val1% gun and melee damage per unique combat stimulant syringe active, with 15% reduced armor effectiveness

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE + T_STACKS val1 *; M_MELEEDAMAGE = M_MELEEDAMAGE + T_STACKS val1 *; M_ARMOR = M_ARMOR -0.15 +
```

**Values:**
- val1: min 0.03, max 0.05 // Damage per syringe stack (+3% to +5% per stack)

**Modweight:** 40

**Build Synergies:**
- **Glass Cannon:** Scales with multiple syringe investment for extreme damage
- **Precision Sniper:** Rewards syringe stacking for massive burst potential
- **Hybrid Berserker:** Both melee and gun damage scale together
- **Speed Demon:** Damage amplification for multi-syringe combat builds

**Trade-offs:**
Zero damage without other syringes active - requires heavy syringe investment. 15% armor reduction compounds vulnerability. Maximum effectiveness requires 5-10 syringe stacks. Incentivizes diverse syringe collection but limits other mod slot usage. With 10 syringes at 0.05 val1: +50% damage to both gun and melee

**Unique Mechanics:**
Build-defining syringe scaling system. Uses T_STACKS to count active syringe mods (type 10). Creates "syringe collector" archetype - rewards investing heavily in combat stimulants. With 5 syringes and 0.05 val1: +25% damage. With 10 syringes: +50% damage. Incentivizes using Escalating Fury Protocol as late-game capstone after collecting multiple standard syringes. Synergizes with all combat stimulants creating multiplicative scaling

**Lore Implications:**
Syringe investment becomes a core build strategy. Players stack multiple combat stimulants to maximize Escalating Fury scaling. Creates exponential offensive scaling as syringe collection grows. Late-game power spike as more syringes become available. Requires dedicating many mod slots to syringes rather than items

**Lore Notes:**
Cascading nanite protocols create synergistic enhancement loops when multiple combat stimulants interact, amplifying offensive output exponentially with each additional injection

---

## PROTOTYPE ASSEMBLY TIER (1 syringe)

### SYRINGE: PERMANENT BERSERKER MODE

**ModID:** 3009
**Type:** 10 (syringe/upgrade)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental combat override granting val1% gun damage, val2% melee damage, and +val1 shots per second permanently, but reducing max HP by 30%, armor by 40%, and HP regeneration by 60%

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE val1 +; M_MELEEDAMAGE = M_MELEEDAMAGE val2 +; B_SHOTSPERSEC = B_SHOTSPERSEC val1 +; M_HP = M_HP -0.3 +; M_ARMOR = M_ARMOR -0.4 +; M_HPREGEN = M_HPREGEN -0.6 +
```

**Values:**
- val1: min 0.2, max 0.3 // Gun damage increase (+20% to +30%)
- val2: min 0.25, max 0.35 // Melee damage increase (+25% to +35%)

**Modweight:** 8

**Build Synergies:**
- **Glass Cannon:** Ultimate offensive injection for maximum damage output
- **Hybrid Berserker:** Build-defining item enabling true berserker playstyle
- **Precision Sniper:** Massive damage boost with fire rate enhancement
- **Speed Demon:** Fire rate and damage for aggressive rapid-fire tactics

**Trade-offs:**
Catastrophic defensive penalties: 30% HP reduction, 40% armor loss, 60% regeneration penalty. Creates extreme fragility requiring perfect positioning. HP regeneration penalty forces reliance on LIFESTEAL or shield regeneration for sustain. Incompatible with tank builds or defensive strategies. "Kill fast or die fast" philosophy. Requires DODGECHANCE, SHIELDCAPACITY, or LIFESTEAL investment for survival

**Unique Mechanics:**
Build-defining permanent aggressive combat mode. Strongest combat stimulant offensive bonus but catastrophic defensive trade-offs. Affects both gun and melee damage making it versatile for hybrid builds. Fire rate bonus (uses val1 as shots/sec) adds +1.5-2.0 shots per second on top of damage boosts. With 0.3 gun damage, 0.35 melee damage, and +2.0 fire rate: massive DPS increase across all weapon types. Creates "glass cannon berserker" archetype - maximum aggression, minimum defense. Synergizes with LIFESTEAL to convert extreme damage into sustain. Rewards aggressive positioning and mechanical skill. Ultimate risk/reward syringe - highest offensive potential with severe survival challenge

**Lore Implications:**
Player becomes pure offensive engine with paper defenses. Must eliminate enemies before taking damage. Every engagement is life-or-death. Rewards mastery of positioning, dodging, and burst damage. Enables speed-running through overwhelming offense. Forces reliance on shields or lifesteal for sustain

**Lore Notes:**
Experimental berserker protocol permanently overrides safety limiters and diverts critical life support systems to weapons, creating unmatched offensive capacity at catastrophic cost to defensive integrity and regeneration capability

---

## DESIGN SUMMARY

**Total Syringes:** 10
**ID Range:** 3000-3009

**Rarity Distribution:**
- Standard: 5 syringes (3000-3004) | modweight 190-200
- Enhanced: 3 syringes (3005-3007) | modweight 70-80
- Advanced: 1 syringe (3008) | modweight 40
- Prototype: 1 syringe (3009) | modweight 8

**Stat Coverage:**
- GUNDAMAGE: 4 syringes (3000, 3005, 3008, 3009)
- SHOTSPERSEC: 2 syringes (3001, 3005, 3009 fire rate bonus)
- MELEESPEED: 2 syringes (3002, 3006)
- MELEEDAMAGE: 4 syringes (3004, 3006, 3008, 3009)
- CRITCHANCE: 2 syringes (3003, 3007)
- CRITDAMAGE: 1 syringe (3007)
- HP: 2 syringes (penalties: 3006, 3009)
- ARMOR: 3 syringes (penalties: 3005, 3008, 3009)
- PLAYERSPEED: 1 syringe (penalty: 3007)
- HPREGEN: 1 syringe (penalty: 3009)

**Build Archetype Support:**
- Glass Cannon: 10 syringes (all syringes support offensive damage focus)
- Precision Sniper: 6 syringes (damage, crit, fire rate scaling)
- Hybrid Berserker: 7 syringes (melee, gun, hybrid damage)
- Speed Demon: 6 syringes (fire rate, melee speed, attack speed)
- Elemental Savant: 3 syringes (damage and fire rate for proc application)
- DoT Specialist: 2 syringes (fire rate for frequent DoT application)

**Syringe Philosophy:**
- Smaller individual effects than items (+5-15% vs +20-50%)
- Fully stackable for cumulative effect (multiple copies allowed)
- Trade-offs still required for balance despite smaller bonuses
- Standard tier: Pure offensive bonuses with no penalties
- Enhanced tier: Combined effects with 10-15% defensive penalties
- Advanced tier: Stack-scaling mechanics rewarding syringe collection
- Prototype tier: Extreme offensive bonus with catastrophic defensive penalties

**Trade-off Philosophy:**
- Standard syringes: No penalties (stackable offensive foundation)
- Enhanced syringes: 10-15% reduction to HP, armor, or movement speed
- Advanced syringe: 15% armor reduction + requires syringe stacks for value
- Prototype syringe: 30% HP, 40% armor, 60% HP regen reduction (extreme berserker mode)

**Stack Scaling Mechanics:**
- **Escalating Fury Protocol (3008):** Uses T_STACKS to count active syringes, rewarding heavy syringe investment with +3-5% damage per syringe. With 10 syringes: +50% gun and melee damage
- Enables "syringe collector" archetype focused on stacking multiple combat stimulants
- Creates late-game power scaling as more syringes are acquired
- Synergizes with all combat stimulants for multiplicative effect

**Lore Compliance:**
- All terminology uses nanomolecular language (combat stimulant, injection protocol, nanite enhancement)
- No biological references (structural integrity, not health)
- Consistent with HIOX offensive nanite injection theme
- Player-visible descriptions avoid confidential lore
- Focus on "combat protocol", "targeting enhancement", "offensive injection" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val, B_X = B_X + val)
- Proper coefficient prefixes (M_ for multiplicative, B_ for base additive)
- M_ values use decimals (0.1 = 10%, 0.3 = 30%)
- B_SHOTSPERSEC uses absolute values (+0.5 to +1.0 shots per second)
- Postfix notation for operations in stack-scaling mechanics
- Stack scaling uses T_STACKS: `M_GUNDAMAGE = M_GUNDAMAGE + T_STACKS val1 *`
- All equations follow HEL syntax rules

**Damage Scaling Comparison (Syringe vs Item):**
- **Syringe gun damage:** +8-12% standard vs **Item gun damage:** +20-40% standard
- **Syringe melee damage:** +8-12% standard vs **Item melee damage:** comparable
- **Syringe crit chance:** +5-10% standard vs **Item crit chance:** +15-30% standard
- **Syringe fire rate:** +0.5-1.0 shots/sec vs Items: typically combined bonuses
- Syringes trade individual power for stackability and build flexibility

**Build-Defining Syringes:**
- **AGGRESSIVE COMBAT PROTOCOL (3005):** Combined gun damage and fire rate for sustained DPS
- **BERSERKER COMBAT STIMULANT (3006):** Complete melee package (damage + speed)
- **CRITICAL PRECISION SERUM (3007):** Complete crit package for Precision Sniper
- **ESCALATING FURY PROTOCOL (3008):** Syringe-scaling mechanic rewarding collection
- **PERMANENT BERSERKER MODE (3009):** Ultimate glass cannon syringe with extreme offense and fragility

**Synergy Opportunities:**
- Stack 3000 + 3005 for layered gun damage (+18-27% total)
- Combine 3001 + 3005 for extreme fire rate (+1.0-2.0 shots/sec total)
- Use 3002 + 3006 for maximum melee speed (+20-30% total)
- Pair 3003 + 3007 for stacked crit chance (+13-22% total)
- Combine 3004 + 3006 for layered melee damage (+18-27% total)
- Use 3008 as capstone with 5-10 other syringes for massive damage scaling
- Stack multiple standard syringes (3000-3004) with 3008 for exponential scaling
- Combine 3009 with LIFESTEAL items for "convert damage to healing" sustain

**Anti-Synergies:**
- Multiple copies of 3007 stack movement penalties (-10% each) conflicting with Speed Demon
- 3008 requires many syringe slots, limiting item diversity
- 3009 HP/armor penalties conflict with Fortress Tank builds
- 3009 HP regen penalty forces reliance on LIFESTEAL or shields, not regeneration
- Stacking Enhanced/Prototype syringes creates extreme defensive fragility

**Balance Considerations:**
- Smaller individual effects than items prevent single-syringe dominance
- Stackability creates scaling potential through multiple copies
- Trade-offs on Enhanced/Prototype tiers prevent pure offensive stacking without risk
- Standard syringes provide safe baseline offensive scaling
- Advanced syringe (3008) rewards syringe collection with damage scaling
- Prototype syringe (3009) creates ultimate glass cannon at extreme defensive cost
- Movement penalty only on one syringe (3007) to limit mobility impact
- HP regen penalty on prototype forces alternative sustain strategies (lifesteal/shields)
- Armor penalties on 3 syringes (3005, 3008, 3009) prevent pure offensive + tank hybrid

**Stackability Examples:**
- 5x DAMAGE ENHANCEMENT SERUM (3000): +40-60% gun damage total
- 3x FIRE RATE STIMULANT (3001): +1.5-3.0 shots per second total
- 4x PRECISION TARGETING STIMULANT (3003): +20-40% crit chance total
- 2x AGGRESSIVE COMBAT PROTOCOL (3005): +20-30% gun damage, +1.0-2.0 fire rate, -30% armor total
- 1x ESCALATING FURY PROTOCOL (3008) + 9 other syringes: +27-45% gun/melee damage from scaling alone

**Comparison to Items:**
- **Items:** Larger individual effects (+20-50%), cannot stack duplicates, typically limited slots
- **Syringes:** Smaller effects (+5-15%), fully stackable, more flexible build options
- **Trade-off:** Items provide concentrated power, syringes provide distributed scaling
- **Build Strategy:** Mix items for build-defining effects with syringes for stackable bonuses

---

**END OF COMBAT STIMULANT SYRINGES DESIGN**
