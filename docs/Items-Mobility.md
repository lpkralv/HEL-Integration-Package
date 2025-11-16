# Mobility Module Items Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 2008-2014 (7 items)
**Class Type:** Mobility Modules
**Item Type Code:** 0 (passive)

---

## CLASS OVERVIEW

**Mobility Modules** are locomotion enhancement systems utilizing kinetic accelerator matrices and propulsion protocols to augment player movement capabilities. These passive modifications excel at speed scaling, evasion mechanics, and tactical positioning, making them essential for hit-and-run combat and high-mobility playstyles.

**Core Characteristics:**
- Movement speed scaling (PLAYERSPEED, SPRINTSPEED)
- Dash mechanics optimization (DASHSPEED, DASHCOOLDOWN)
- Vertical mobility (JUMPSTRENGTH)
- Often trade defense/damage for mobility
- Synergies with DODGECHANCE and positioning-based damage

**Build Archetype Support:**
- Speed Demon (primary archetype, maximum mobility focus)
- Hybrid Berserker (hit-and-run melee combos)
- Glass Cannon (positioning for burst windows)
- Precision Sniper (repositioning and kiting)

---

## STANDARD CONFIGURATION TIER (3 items)

### MOD: KINETIC ACCELERATOR NANITES

**ModID:** 2008
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Locomotion enhancement nanites increase base movement speed by val1% through optimized actuator protocols

**HEL Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +
```

**Values:**
- val1: min 0.15, max 0.3 // Movement speed bonus (+15% to +30%)
- val2: 0 (unused)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Speed Demon:** Core foundation for maximum mobility builds
- **Hybrid Berserker:** Base mobility for melee engagement positioning
- **Glass Cannon:** Positioning safety for burst damage windows
- **Precision Sniper:** Repositioning between shots for kiting

**Trade-offs:**
Pure mobility buff with no penalties - baseline passive for all movement-focused builds. No defensive or offensive scaling.

---

### MOD: SPRINT EFFICIENCY MATRIX

**ModID:** 2009
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Enhanced sprint calibration systems increasing sprint speed by val1% but reducing base movement by val2%

**HEL Equation:**
```
M_SPRINTSPEED = M_SPRINTSPEED val1 +; M_PLAYERSPEED = M_PLAYERSPEED -val2 +
```

**Values:**
- val1: min 0.4, max 0.7 // Sprint speed bonus (+40% to +70%)
- val2: min 0.1, max 0.15 // Base speed penalty (-10% to -15%)

**Modweight:** 180

**Build Synergies:**
- **Speed Demon:** Extreme sprint speed for chase/escape scenarios
- **Hybrid Berserker:** Rapid melee engagement closing
- **Precision Sniper:** Long-range repositioning between encounters
- **Glass Cannon:** Quick escape from dangerous situations

**Trade-offs:**
Base movement speed reduction affects combat mobility. Requires sprint state activation (may consume stamina). Less effective in sustained combat where sprint unavailable.

---

### MOD: VERTICAL PROPULSION NANITES

**ModID:** 2010
**Type:** 0 (passive)
**Rarity:** Standard

**Description (Player-Visible):**
Gravitational displacement systems enhancing jump force by val1%, enabling superior vertical mobility and tactical positioning

**HEL Equation:**
```
M_JUMPSTRENGTH = M_JUMPSTRENGTH val1 +
```

**Values:**
- val1: min 0.3, max 0.6 // Jump strength bonus (+30% to +60%)
- val2: 0 (unused)

**Modweight:** 160

**Build Synergies:**
- **Speed Demon:** Vertical evasion complements horizontal mobility
- **Hybrid Berserker:** Aerial melee positioning and slam attacks
- **Precision Sniper:** High-ground access for sightline advantage
- **Glass Cannon:** Vertical escape from ground-based threats

**Trade-offs:**
No direct speed enhancement - utility-focused mobility. Requires terrain/verticality to leverage effectively. No benefit in flat environments.

---

## ENHANCED PROTOCOL TIER (2 items)

### MOD: RAPID DISPLACEMENT ACCELERATOR

**ModID:** 2011
**Type:** 0 (passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Emergency evasion protocols reducing dash cooldown by val1 seconds and increasing dash velocity by val2%, with val2% reduced maximum structural integrity

**HEL Equation:**
```
B_DASHCOOLDOWN = B_DASHCOOLDOWN -val1 +; M_DASHSPEED = M_DASHSPEED val2 +; M_HP = M_HP -val2 +
```

**Values:**
- val1: min 1.0, max 2.0 // Dash cooldown reduction (-1.0 to -2.0 seconds)
- val2: min 0.3, max 0.6 // Dash speed bonus AND HP penalty (+30-60% / -30-60%)

**Modweight:** 70

**Build Synergies:**
- **Speed Demon:** Core dash spam capability for constant repositioning
- **Glass Cannon:** Frequent dodge windows compensate for HP loss
- **Hybrid Berserker:** Aggressive dash-in-attack-dash-out combos
- **Precision Sniper:** High-frequency evasion during reload windows

**Trade-offs:**
Significant HP reduction (30-60%) creates extreme glass cannon risk. Requires skill to leverage dashes effectively. Less value if dashes are wasted or poorly timed.

---

### MOD: MOMENTUM CONVERSION MATRIX

**ModID:** 2012
**Type:** 0 (passive)
**Rarity:** Enhanced

**Description (Player-Visible):**
Kinetic energy recapture systems increasing movement speed by val1% and stamina regeneration by val2%, but reducing armor effectiveness by 30%

**HEL Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +; M_STAMINAREGEN = M_STAMINAREGEN val2 +; M_ARMOR = M_ARMOR -0.3 +
```

**Values:**
- val1: min 0.25, max 0.45 // Movement speed bonus (+25% to +45%)
- val2: min 0.4, max 0.8 // Stamina regen bonus (+40% to +80%)

**Modweight:** 65

**Build Synergies:**
- **Speed Demon:** High uptime for sprint and dash mechanics
- **Hybrid Berserker:** Sustained mobility for melee kiting
- **Precision Sniper:** Extended mobility windows for repositioning
- **DoT Specialist:** Kiting sustain for continuous damage application

**Trade-offs:**
Armor reduction (30%) makes player significantly squishier. Requires evasion playstyle and DODGECHANCE investment. Defense-by-offense approach - must avoid hits entirely.

---

## ADVANCED MATRIX TIER (1 item)

### MOD: VELOCITY DAMAGE AMPLIFIER

**ModID:** 2013
**Type:** 0 (passive)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental kinetic conversion protocols granting val1% weapon damage per 100 movement speed possessed, and val2% dodge chance per 200 movement speed, but reducing base HP by 25%

**HEL Equation:**
```
M_GUNDAMAGE = M_GUNDAMAGE + T_PLAYERSPEED 100 / val1 *; M_DODGECHANCE = M_DODGECHANCE + T_PLAYERSPEED 200 / val2 *; M_HP = M_HP -0.25 +
```

**Values:**
- val1: min 0.08, max 0.15 // Damage scaling per 100 speed (+8% to +15% per 100 speed)
- val2: min 0.03, max 0.06 // Dodge scaling per 200 speed (+3% to +6% per 200 speed)

**Modweight:** 30

**Build Synergies:**
- **Speed Demon:** Build-defining mod converting mobility into offense and defense
- **Glass Cannon:** Speed investment provides both damage and dodge synergy
- **Hybrid Berserker:** Mobility scaling for hit-and-run damage
- **Precision Sniper:** Damage bonus while maintaining kiting distance

**Trade-offs:**
HP reduction (25%) requires full commitment to mobility stacking. Requires heavy PLAYERSPEED investment to scale meaningfully (500+ speed = 40-75% damage). RNG dodge chance creates inconsistent defense.

**Unique Mechanics:**
Converts movement stat into multiplicative damage and survival scaling. Rewards extreme speed stacking builds. Creates "speed = power" archetype. Synergizes with all speed-boosting mods and syringes.

---

## PROTOTYPE ASSEMBLY TIER (1 item)

### MOD: UNSTABLE PROPULSION CORE

**ModID:** 2014
**Type:** 0 (passive)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental overclocked locomotion system granting val1% movement speed and reducing dash cooldown by val2 seconds, but draining val1% maximum HP and disabling natural HP regeneration

**HEL Equation:**
```
M_PLAYERSPEED = M_PLAYERSPEED val1 +; B_DASHCOOLDOWN = B_DASHCOOLDOWN -val2 +; M_HP = M_HP -val1 +; M_HPREGEN = M_HPREGEN -1.0 +
```

**Values:**
- val1: min 0.6, max 1.2 // Movement speed bonus AND HP penalty (+60-120% speed / -60-120% HP)
- val2: min 1.5, max 2.5 // Dash cooldown reduction (-1.5 to -2.5 seconds)

**Modweight:** 4

**Build Synergies:**
- **Speed Demon:** Extreme mobility at catastrophic defense cost
- **Glass Cannon:** Ultimate glass cannon - speed or death philosophy
- **Hybrid Berserker:** Lifesteal dependency for survival (requires LIFESTEAL investment)
- **Precision Sniper:** Never-get-hit sniper playstyle with extreme positioning

**Trade-offs:**
Massive HP reduction (60-120%) AND complete HPREGEN disable creates extreme fragility. Death sentence without LIFESTEAL or external healing. Requires perfect execution - single mistake = death.

**Unique Mechanics:**
Build-defining high-risk/high-reward mobility system. Forces LIFESTEAL or healing item dependency. Creates "one hit = death" glass cannon archetype. Rewards mastery and perfect evasion play.

---

## DESIGN SUMMARY

**Total Items:** 7
**ID Range:** 2008-2014

**Rarity Distribution:**
- Standard: 3 items (2008-2010) | modweight 160-200
- Enhanced: 2 items (2011-2012) | modweight 65-70
- Advanced: 1 item (2013) | modweight 30
- Prototype: 1 item (2014) | modweight 4

**Stat Coverage:**
- PLAYERSPEED: 5 items (all except jump-only and dash-focused)
- SPRINTSPEED: 1 item
- JUMPSTRENGTH: 1 item
- DASHSPEED: 1 item
- DASHCOOLDOWN: 2 items
- STAMINAREGEN: 1 item
- GUNDAMAGE: 1 item (scaling)
- DODGECHANCE: 1 item (scaling)
- HP: 4 items (penalties)
- ARMOR: 1 item (penalty)
- HPREGEN: 1 item (penalty)

**Build Archetype Support:**
- Speed Demon: 7 items (all mobility modules core to archetype)
- Hybrid Berserker: 6 items (mobility for melee positioning)
- Glass Cannon: 5 items (positioning and burst windows)
- Precision Sniper: 5 items (kiting and repositioning)
- DoT Specialist: 2 items (kiting for continuous damage application)

**Trade-off Philosophy:**
- Standard tier provides baseline mobility with minimal penalties
- Enhanced tier introduces meaningful HP/ARMOR trade-offs (25-60%)
- Advanced tier creates conditional scaling requiring stat investment
- Prototype tier demands extreme defensive sacrifice for ultimate mobility

**Movement Speed Scaling:**
- Standard: +15-30% base speed (safe mobility)
- Enhanced: +25-45% with defense penalties (aggressive mobility)
- Prototype: +60-120% with catastrophic HP loss (extreme glass cannon)

**Dash Mechanics:**
- Baseline DASHCOOLDOWN: 3.0 seconds
- Enhanced reduction: -1.0 to -2.0 seconds (1.0-2.0s final cooldown)
- Prototype reduction: -1.5 to -2.5 seconds (0.5-1.5s final cooldown)
- Combined potential: ~0.5s dash cooldown (near-constant dashing)

**Lore Compliance:**
- All terminology uses nanomolecular language (locomotion, propulsion, kinetic, actuator)
- Avoids biological references (no "boots", "legs", "muscles")
- Consistent with HIOX nanite world (matrix, protocols, systems)
- No confidential lore revelations in player-visible descriptions

**HEL Equation Validation:**
- All equations add to coefficients (M_X = M_X + val)
- Proper coefficient prefixes (B_, M_)
- M_ values use decimals (0.5 = 50%)
- Cross-stat dependencies in Advanced/Prototype tiers use T_ prefix
- Negative values for penalties (M_HP = M_HP + (-val1))
- Scaling formulas use postfix notation (T_PLAYERSPEED 100 / val1 *)

**Build-Defining Items:**
- **VELOCITY DAMAGE AMPLIFIER (2013):** Converts speed into damage and dodge (Speed Demon core)
- **UNSTABLE PROPULSION CORE (2014):** Extreme speed with no regen (ultimate glass cannon)

**Synergy Notes:**
- Stacking multiple mobility modules enables extreme speed builds (500+ PLAYERSPEED)
- VELOCITY DAMAGE AMPLIFIER rewards speed stacking with damage scaling
- UNSTABLE PROPULSION CORE requires LIFESTEAL investment from weapons/items
- Dash-focused builds can achieve near-instant dash cooldowns (< 1 second)
- Sprint mechanics synergize with stamina investment for sustained mobility

**Balance Considerations:**
- Movement speed provides indirect defense through positioning
- HP penalties scale with benefits (higher mobility = higher HP cost)
- No direct offensive stats except conditional scaling (maintains passive item identity)
- Prototype tier creates extreme fragility requiring perfect execution
- Dash spam potential balanced by skill requirements and HP penalties

---

**END OF MOBILITY MODULE ITEMS DESIGN**
