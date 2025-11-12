# Structural Plating Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2000-2007 (8 items)
**Class Type:** Structural Plating
**Item Type Code:** 0 (passive)

---

## CLASS OVERVIEW

**Structural Plating** items are defensive nanite reinforcement systems that enhance player survivability through HP augmentation, armor hardening, and damage mitigation protocols. These passive modifications form the foundation of defensive builds by providing structural integrity boosts and reactive defense mechanisms.

**Core Characteristics:**
- Focus on HP, ARMOR, DAMAGEABSORPTION, and defensive synergies
- Enable Fortress Tank archetype through layered defenses
- Some items trade offensive capability for extreme survivability
- Advanced items feature scaling mechanics (regen-from-armor, thorns-from-HP)

**Build Archetype Support:**
- Fortress Tank (primary - all items support this)
- Hybrid Berserker (HP sustain for aggressive melee)
- Summoner Commander (survivability while minions engage)
- Glass Cannon (selective HP investment for burst survivability)

---

## STANDARD CONFIGURATION TIER (3 items)

### MOD: REINFORCED NANITE SHELL

**ModID:** 2000
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Hardened nanite shell increasing maximum structural integrity by val1% through enhanced framework density

**HEL Equation:**
```
M_HP = M_HP + val1
```

**Values:**
- val1: min 0.15, max 0.35 // HP boost (+15% to +35%)
- val2: 0 (unused)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Fortress Tank:** Core HP stacking foundation
- **Hybrid Berserker:** HP pool for aggressive sustain
- **Summoner Commander:** Survivability while minions fight
- **Glass Cannon:** Selective HP investment without damage penalty

**Trade-offs:**
Pure defensive bonus with no penalties - standard baseline for testing synergies with damage-focused mods

**Lore Notes:**
Basic structural reinforcement using compressed nanite matrices to increase total framework integrity capacity

---

### MOD: ABLATIVE PLATING MATRIX

**ModID:** 2001
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Ablative armor layers increasing damage reduction by val1% through layered nanite dispersion protocols

**HEL Equation:**
```
M_ARMOR = M_ARMOR + val1
```

**Values:**
- val1: min 0.2, max 0.4 // Armor boost (+20% to +40%)
- val2: 0 (unused)

**Modweight:** 190

**Build Synergies:**
- **Fortress Tank:** Foundation for percentage-based damage reduction
- **Hybrid Berserker:** Enables face-tanking during melee engagement
- **Summoner Commander:** Reduces damage taken while managing minions
- **Thorns builds:** More armor = survive longer = more reflected damage

**Trade-offs:**
Pure defensive bonus with no penalties - standard baseline for armor-focused strategies

**Lore Notes:**
Multi-layered ablative nanite plates disperse incoming kinetic and energy attacks across structural surface area

---

### MOD: STRUCTURAL REINFORCEMENT PROTOCOLS

**ModID:** 2002
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Combined defensive matrix increasing HP by val1% and armor by val2%, but reducing movement speed by 10%

**HEL Equation:**
```
M_HP = M_HP + val1; M_ARMOR = M_ARMOR + val2; M_PLAYERSPEED = M_PLAYERSPEED + (-0.1)
```

**Values:**
- val1: min 0.1, max 0.25 // HP boost (+10% to +25%)
- val2: min 0.15, max 0.3 // Armor boost (+15% to +30%)

**Modweight:** 180

**Build Synergies:**
- **Fortress Tank:** Balanced HP/armor investment with acceptable mobility trade-off
- **Hybrid Berserker:** Defensive foundation for aggressive play (mobility loss hurts less)
- **Summoner Commander:** Survivability boost while stationary
- **Thorns builds:** Combined defenses extend life for more reflected damage

**Trade-offs:**
10% movement speed reduction creates positioning challenges. Less effective for Speed Demon builds. Rewards stationary combat and defensive positioning.

**Lore Notes:**
Integrated reinforcement matrix combines dense nanite plating with structural framework hardening, at cost of increased mass

---

## ENHANCED PROTOCOL TIER (2 items)

### MOD: HARDPOINT ABSORPTION BARRIER

**ModID:** 2003
**Type:** 0 (passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Advanced barrier system granting val1% HP increase and val2 flat damage absorption per hit, with 15% reduced stamina capacity

**HEL Equation:**
```
M_HP = M_HP + val1; B_DAMAGEABSORPTION = B_DAMAGEABSORPTION + val2; M_MAXSTAMINA = M_MAXSTAMINA + (-0.15)
```

**Values:**
- val1: min 0.2, max 0.4 // HP boost (+20% to +40%)
- val2: min 15, max 35 // Flat damage absorption (15-35 per hit)

**Modweight:** 75

**Build Synergies:**
- **Fortress Tank:** Powerful layered defense (HP + flat reduction)
- **Hybrid Berserker:** Excellent for melee - absorbs many small hits
- **Thorns builds:** Survive longer under sustained attack
- **Anti-swarm:** Flat absorption exceptional against rapid weak attacks

**Trade-offs:**
Stamina reduction (15%) limits sprint duration and dodge frequency. Less effective for Speed Demon kiting strategies. Absorption stronger against many weak hits versus few strong hits.

**Lore Notes:**
Reactive barrier nanites form dynamic hardpoints at impact locations, dispersing attack energy before structural penetration

---

### MOD: REACTIVE PLATING ASSEMBLY

**ModID:** 2004
**Type:** 0 (passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Reflective armor matrix increasing armor by val1% and reflecting val2% of received damage, with 20% reduced damage output

**HEL Equation:**
```
M_ARMOR = M_ARMOR + val1; M_REFLECTDAMAGE = M_REFLECTDAMAGE + val2; M_GUNDAMAGE = M_GUNDAMAGE + (-0.2); M_MELEEDAMAGE = M_MELEEDAMAGE + (-0.2)
```

**Values:**
- val1: min 0.3, max 0.6 // Armor boost (+30% to +60%)
- val2: min 0.15, max 0.3 // Reflect percentage (15%-30%)

**Modweight:** 70

**Build Synergies:**
- **Fortress Tank:** Core reflect-tank build enabler
- **Passive damage builds:** Armor + reflect = damage without attacking
- **Summoner Commander:** Survive while minions deal primary damage
- **AFK strategies:** Extreme reflect values enable passive enemy elimination

**Trade-offs:**
Significant damage penalty (20% to both gun and melee) shifts role to tank/support. Requires high HP pool to maximize reflected damage. Ineffective for Glass Cannon or damage-focused builds. Reflect scales with damage taken (more dangerous enemies = more reflect).

**Lore Notes:**
Energy feedback matrices capture kinetic and thermal attack energy, redirecting it through reflective channels back to attackers

---

## ADVANCED MATRIX TIER (2 items)

### MOD: ADAPTIVE REGENERATION CORE

**ModID:** 2005
**Type:** 0 (passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental regeneration protocols granting val1 HP regen per second, plus additional val2 regen per 100 armor possessed, with 25% reduced maximum stamina

**HEL Equation:**
```
B_HPREGEN = B_HPREGEN + val1; B_HPREGEN = B_HPREGEN + T_ARMOR val2 * 0.01 *; M_MAXSTAMINA = M_MAXSTAMINA + (-0.25)
```

**Values:**
- val1: min 3, max 8 // Base HP regen (+3 to +8 HP/sec)
- val2: min 0.5, max 1.5 // Armor scaling (0.5-1.5 regen per 100 armor)

**Modweight:** 35

**Build Synergies:**
- **Fortress Tank:** Regen-tank variant scaling with armor investment
- **Armor-stacking builds:** Incentivizes heavy armor investment
- **Sustained combat:** Continuous regeneration enables extended engagements
- **Hybrid Berserker:** Passive healing between aggressive trades

**Trade-offs:**
Severe stamina reduction (25%) limits mobility and dodge capability. Requires armor investment to maximize scaling benefit. Less effective for burst-damage survival versus sustained combat. Stamina loss conflicts with Speed Demon playstyle.

**Unique Mechanics:**
Build-defining armor-to-regen conversion. Rewards stacking armor mods beyond defensive benefit. Creates "armor = healing" synergy. With 300 armor and 1.0 val2, grants +3 additional regen (total 6-11 HP/sec).

**Lore Notes:**
Nanite recycling protocols harvest excess structural mass from armor layers to fuel continuous framework reconstruction

---

### MOD: RETRIBUTION FRAMEWORK

**ModID:** 2006
**Type:** 0 (passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Retaliatory combat matrix inflicting val1 base thorns damage plus additional val2 damage per 100 maximum HP, with 30% reduced movement and sprint speed

**HEL Equation:**
```
B_THORNDAMAGE = B_THORNDAMAGE + val1; B_THORNDAMAGE = B_THORNDAMAGE + T_HP val2 * 0.01 *; M_PLAYERSPEED = M_PLAYERSPEED + (-0.15); M_SPRINTSPEED = M_SPRINTSPEED + (-0.3)
```

**Values:**
- val1: min 20, max 50 // Base thorns damage (20-50 per hit received)
- val2: min 2, max 6 // HP scaling (2-6 damage per 100 HP)

**Modweight:** 30

**Build Synergies:**
- **Fortress Tank:** Thorns-tank variant scaling with HP investment
- **HP-stacking builds:** Converts HP into offensive capability
- **Passive damage:** Retribution without active attacks
- **Anti-swarm:** Excellent against many weak attackers

**Trade-offs:**
Massive mobility penalties (15% move speed, 30% sprint speed) create immobile tank archetype. Requires HP investment for thorns scaling. Damage scales with hits received (suicidal without high HP/armor). Completely conflicts with Speed Demon builds.

**Unique Mechanics:**
Build-defining HP-to-thorns conversion. Rewards stacking HP beyond survivability benefit. Creates "face-tank and reflect" playstyle. With 500 HP and 4.0 val2, grants +20 additional thorns (total 40-70 per hit received).

**Lore Notes:**
Reactive nanite clusters detect incoming damage vectors and launch retaliatory structural spikes, converting absorbed kinetic energy into counterattack force

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### MOD: FORTRESS DEVASTATOR CORE

**ModID:** 2007
**Type:** 0 (passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental protocols granting val1% maximum HP increase and val2% HP-to-damage conversion, gaining 1% gun and melee damage per 50 maximum HP but reducing movement speed by 40% and fire rate by 35%

**HEL Equation:**
```
M_MAXHPPERCENTBONUS = M_MAXHPPERCENTBONUS + val1; M_GUNDAMAGE = M_GUNDAMAGE + T_HP val2 * 0.02 *; M_MELEEDAMAGE = M_MELEEDAMAGE + T_HP val2 * 0.02 *; M_PLAYERSPEED = M_PLAYERSPEED + (-0.4); M_SHOTSPERSEC = M_SHOTSPERSEC + (-0.35)
```

**Values:**
- val1: min 0.6, max 1.2 // Max HP percentage bonus (+60% to +120% max HP cap)
- val2: min 0.8, max 1.5 // HP-to-damage conversion (0.8%-1.5% damage per 50 HP)

**Modweight:** 5

**Build Synergies:**
- **Fortress Tank:** Converts extreme HP into offensive capability
- **HP-stacking builds:** Transforms defense into damage
- **Hybrid Berserker:** Enables aggressive tank playstyle with damage scaling
- **Unique archetype:** "Immobile fortress" - massive HP and damage, zero mobility

**Trade-offs:**
Extreme mobility penalty (40% move speed reduction) creates nearly stationary playstyle. Fire rate reduction (35%) severely impacts sustained gun DPS. Requires heavy HP investment for damage scaling to compensate penalties. Completely incompatible with Speed Demon or mobility builds.

**Unique Mechanics:**
Build-defining HP-to-damage conversion system. Uses MAXHPPERCENTBONUS to extend HP cap beyond 5000. Creates "stack HP to absurd values for damage" archetype. With 1000 HP and 1.2 val2, grants +24% gun/melee damage. Enables extreme HP values (300 base HP * 2.2 MAXHPPERCENTBONUS + flat bonuses = 1000+ HP potential).

**Lore Implications:**
Player becomes immobile fortress platform - prioritize positioning and area control over mobility. Requires defensive synergies (armor, absorption, thorns, reflect) to survive without dodging. Ultimate "stand and deliver" item.

**Lore Notes:**
Prototype density core massively increases nanite framework capacity while repurposing structural mass into weapon power amplification, at catastrophic cost to mobility systems

---

## DESIGN SUMMARY

**Total Items:** 8
**ID Range:** 2000-2007

**Rarity Distribution:**
- Standard: 3 items (2000-2002) | modweight 180-200
- Enhanced: 2 items (2003-2004) | modweight 70-75
- Advanced: 2 items (2005-2006) | modweight 30-35
- Prototype: 1 item (2007) | modweight 5

**Stat Coverage:**
- HP (M_HP): 4 items
- ARMOR (M_ARMOR): 3 items
- DAMAGEABSORPTION: 1 item
- REFLECTDAMAGE: 1 item
- HPREGEN: 1 item
- THORNDAMAGE: 1 item
- MAXHPPERCENTBONUS: 1 item
- PLAYERSPEED: 3 items (penalties)
- MAXSTAMINA: 2 items (penalties)
- GUNDAMAGE: 2 items (1 penalty, 1 scaling bonus)
- MELEEDAMAGE: 2 items (1 penalty, 1 scaling bonus)
- SHOTSPERSEC: 1 item (penalty)

**Build Archetype Support:**
- Fortress Tank: 8 items (all items support primary archetype)
- Hybrid Berserker: 6 items (HP sustain + damage scaling)
- Summoner Commander: 4 items (survivability while minions fight)
- Glass Cannon: 2 items (selective HP without damage loss)
- Thorns/Reflect builds: 3 items (passive damage strategies)
- HP-stacking builds: 3 items (HP scaling mechanics)
- Armor-stacking builds: 2 items (armor scaling mechanics)

**Trade-off Philosophy:**
- Standard items: Pure defense, no penalties (foundation items)
- Enhanced items: Moderate penalties (15-20% to secondary stats)
- Advanced items: Severe penalties (25-30% to mobility/resources) + scaling mechanics
- Prototype: Extreme penalties (35-40% to multiple systems) + build-defining conversion

**Scaling Mechanics:**
- **Armor-to-Regen** (2005): Incentivizes armor stacking beyond defense
- **HP-to-Thorns** (2006): Converts HP into passive damage
- **HP-to-Damage** (2007): Transforms survivability into offense

**Lore Compliance:**
- All terminology uses nanomolecular language (nanite shell, ablative plating, structural framework)
- No biological references
- Consistent with HIOX defensive technology theme
- Player-visible descriptions avoid confidential lore
- Focus on "hardened nanite", "structural reinforcement", "ablative plating" per requirements

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val1)
- Proper coefficient prefixes (B_ for flat adds, M_ for percentages)
- M_ values use decimals (0.4 = 40%)
- Postfix notation for operations (T_ARMOR val2 * 0.01 *)
- Cross-stat dependencies in Advanced/Prototype tiers
- Scaling formulas use division for "per 100" effects: T_STAT val * 0.01 *

**Unique Design Elements:**
1. **Flat Absorption** (2003): Strong anti-swarm, weak anti-boss mechanic
2. **Reflect Tank** (2004): Passive damage scaling with survivability
3. **Regen Scaling** (2005): Armor investment creates healing feedback loop
4. **Thorns Scaling** (2006): HP investment creates damage feedback loop
5. **HP Conversion** (2007): Extreme HP stacking becomes damage source via MAXHPPERCENTBONUS

**Balance Considerations:**
- Standard items provide foundation without breaking other builds
- Enhanced items have meaningful 15-20% trade-offs
- Advanced items have severe 25-35% penalties justified by scaling
- Prototype creates unique "immobile fortress" archetype with 35-40% penalties
- Mobility penalties prevent defensive items from enabling Speed Demon
- Damage penalties on reflect items prevent Glass Cannon + tank hybrids
- Stamina penalties create resource management challenges

---

**END OF STRUCTURAL PLATING ITEMS DESIGN**
