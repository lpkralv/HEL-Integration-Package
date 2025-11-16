# HIOX Stats Description - New Stats
**Version:** 1.0
**Status:** FINAL DELIVERABLE
**Total New Stats:** 27
**Total System Stats:** 65 (38 existing + 27 new)

---

## INTRODUCTION

This document describes the 27 new stats added to the HIOX game system to expand build diversity and fill identified gaps in the existing 38-stat framework. These stats enable 8+ distinct build archetypes including critical strike builds, shield tanks, summoner commanders, and elemental specialists.

**Design Principles:**
- Nanomolecular terminology (no biological references)
- Clear mechanical purpose for each stat
- Support for diverse build archetypes
- Integration with existing HEL equation system

---

## CATEGORY 1: CORE COMBAT STATS (8 stats)

### CRITCHANCE
**Type:** Percentage | **Default:** 0.05 | **Range:** 0-1

**Description:**
Probability of triggering critical precision strikes with enhanced structural damage output

**Game Mechanics:**
Determines the probability that any attack (projectile or melee) triggers a critical hit, which then multiplies base damage by CRITDAMAGE. Rolls probability check on each attack event.

**Build Support:**
Critical for Glass Cannon builds. Supports Precision Sniper archetype. Enables high-burst damage strategies with proper CRITDAMAGE scaling.

**Lore:**
Advanced targeting protocols analyze structural weaknesses in enemy nanite configurations, allowing precision strikes to exploit critical points in their framework.

**Code Changes Required:**
- *Game-State:* Attack damage calculation system must implement probability roll on each damage event to check against CRITCHANCE value. If roll succeeds, apply CRITDAMAGE multiplier to base damage before final output.
- *Animation:* Critical hit visual effect (enhanced impact particles, screen shake, damage number highlighting) to distinguish critical hits from normal attacks.

---

### CRITDAMAGE
**Type:** Multiplier | **Default:** 1.5 | **Range:** 0-5000

**Description:**
Damage multiplier applied when critical precision strikes are triggered

**Game Mechanics:**
Multiplies base damage when a critical hit occurs. For example, if base damage is 100 and CRITDAMAGE is 2.5, critical hits deal 250 damage. Works multiplicatively with all damage bonuses.

**Build Support:**
Essential for Glass Cannon builds. Core stat for Precision Sniper archetype. Synergizes with CRITCHANCE for burst damage strategies.

**Lore:**
When targeting protocols identify critical structural points, weapon emitters concentrate their output at vulnerable nanite junctions, amplifying destructive force significantly.

**Code Changes Required:**
- *Game-State:* Damage calculation must apply CRITDAMAGE multiplier when critical hit flag is set. Must work multiplicatively with all other damage bonuses (elemental, weapon mods, etc.).
- *Animation:* Enhanced critical strike visual effects (larger particles, different color scheme, special impact animations) to indicate amplified damage.

---

### PROJECTILESPEED
**Type:** Velocity | **Default:** 300 | **Range:** 0-5000

**Description:**
Velocity of fired projectiles from ballistic and energy weapon assemblies

**Game Mechanics:**
Controls how fast projectiles move after firing. Higher speeds reduce enemy dodge windows, improve effective range, and reduce lead time required for moving targets.

**Build Support:**
Important for Precision Sniper builds requiring long-range accuracy. Supports Elemental Savant for reliable elemental application at range.

**Lore:**
Projectile acceleration systems determine how quickly nanite-compressed ammunition or energy packets traverse the battlefield, affecting engagement range effectiveness.

**Code Changes Required:**
- *Game-State:* Projectile physics system must read PROJECTILESPEED stat and apply velocity to projectile Rigidbody/transform. Update projectile prefabs to use stat-driven velocity instead of hardcoded values.
- *Animation:* Faster projectiles may need motion blur trails or enhanced visual effects to maintain visibility at high speeds.

---

### PIERCINGSHOTS
**Type:** Integer | **Default:** 0 | **Range:** 0-50

**Description:**
Number of additional enemy targets projectiles can penetrate before dissipating

**Game Mechanics:**
Determines how many additional enemies a single projectile can hit after striking its first target. Projectile continues in straight line, damaging each enemy it passes through until pierce count is exhausted.

**Build Support:**
Enables crowd control for DoT Specialist builds. Valuable for Speed Demon kiting strategies. Synergizes with elemental builds for multi-target proc application.

**Lore:**
Enhanced projectile coherence protocols maintain ammunition structural integrity after impact, allowing nanite projectiles to pass through targets and continue to secondary contacts.

**Code Changes Required:**
- *Game-State:* Projectile collision system must track pierce count and continue through enemies instead of destroying on first hit. Implement pierce counter that decrements on each enemy collision until reaching zero, then destroy projectile.
- *Animation:* Projectile trail effect showing penetration path through multiple enemies. Possibly different impact particles for piercing hits vs final hit.

---

### RELOADSPEED
**Type:** Multiplier | **Default:** 1.0 | **Range:** 0-5000

**Description:**
Time modifier for ammunition assembly and weapon recalibration cycles

**Game Mechanics:**
Multiplies reload time duration. Values above 1.0 reduce reload time (faster), values below 1.0 increase reload time (slower). For example, a 3-second reload with 2.0 RELOADSPEED becomes 1.5 seconds.

**Build Support:**
Critical for Ballistic Assembly weapon users. Supports Glass Cannon sustained DPS strategies. Valuable for Speed Demon builds requiring minimal downtime.

**Lore:**
Optimized nanite fabrication protocols accelerate the reconstruction of ammunition matrices and weapon system recalibration between firing sequences.

**Code Changes Required:**
- *Game-State:* Weapon reload system must apply RELOADSPEED as divider to base reload time (e.g., 3s / RELOADSPEED). Ensure reload timer references this stat dynamically.
- *Animation:* Reload animation speed must scale with RELOADSPEED multiplier. May need animation blending or time-scale adjustments for very high/low values.

---

### AMMOCAPACITY
**Type:** Integer | **Default:** 30 | **Range:** 0-5000

**Description:**
Maximum projectiles stored in weapon assembly magazine before reload required

**Game Mechanics:**
Sets the number of shots available before triggering a reload. Higher capacity allows sustained fire without interruption. Interacts with RELOADSPEED for total uptime calculation.

**Build Support:**
Essential for Glass Cannon sustained damage. Supports DoT Specialist for continuous proc application. Important for Hybrid Berserker weapon-swap strategies.

**Lore:**
Weapon matrix storage capacity determines how many nanite-compressed projectiles can be loaded simultaneously before requiring reconstruction cycles.

**Code Changes Required:**
- *Game-State:* Weapon system must track current ammo count and max capacity using AMMOCAPACITY stat. Ammo counter decrements on fire, triggers reload when reaching zero.
- *Animation:* UI ammo counter display must reflect AMMOCAPACITY value. No special visual effects required.

---

### LIFESTEAL
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Percentage of damage dealt converted to structural integrity restoration

**Game Mechanics:**
On each damage instance, heals the player for damage dealt multiplied by LIFESTEAL percentage. For example, 100 damage with 0.2 LIFESTEAL heals 20 HP. Works with all damage types.

**Build Support:**
Core mechanic for Hybrid Berserker sustain. Critical for Glass Cannon survival. Enables aggressive tank strategies for Fortress Tank builds.

**Lore:**
Integrated nanite recycling protocols extract viable structural components from damaged enemy constructs, repurposing their matter to reinforce your own framework integrity.

**Code Changes Required:**
- *Game-State:* Damage system must track damage dealt and apply healing equal to (damage × LIFESTEAL). Healing event triggers on each damage instance and adds to player HP up to max.
- *Animation:* Lifesteal healing effect showing particle flow from damaged enemy to player (nanite absorption visual). Health gain feedback through UI or visual effect on player character.

---

### CHAINLIGHTNING
**Type:** Integer | **Default:** 0 | **Range:** 0-20

**Description:**
Maximum number of additional targets electric discharge effects can arc to from initial contact

**Game Mechanics:**
When electric damage is dealt or CHARGECHANCE procs, the effect chains to nearby enemies within PROCRANGE. Each chain may trigger additional elemental effects. Damage may reduce with each chain.

**Build Support:**
Enables Elemental Savant multi-target strategies. Core mechanic for DoT Specialist area denial. Synergizes with CHARGECHANCE for lightning-focused builds.

**Lore:**
Electrical discharge protocols identify conductive pathways between nearby enemy nanite constructs, allowing charge effects to propagate across multiple targets in rapid succession.

**Code Changes Required:**
- *Game-State:* Electric damage system must implement chaining logic: find nearest enemy within PROCRANGE, apply damage/effect, repeat up to CHAINLIGHTNING times. Track already-hit enemies to prevent loops. Damage may reduce per chain (e.g., 70% per jump).
- *Animation:* Lightning arc visual effects (line renderer or particle system) connecting from initial target to each subsequent chain target. Electric discharge particles at each impact point. Audio feedback for each chain jump.

---

## CATEGORY 2: DEFENSE/SURVIVAL STATS (7 stats)

### SHIELDCAPACITY
**Type:** Integer | **Default:** 0 | **Range:** 0-5000

**Description:**
Maximum structural energy barrier strength protecting outer framework layer

**Game Mechanics:**
Provides a regenerating damage buffer that must be depleted before HP takes damage. Shields regenerate at SHIELDREGENRATE when not taking damage.

**Build Support:**
Enables shield-tank variant of Fortress Tank builds. Supports Elemental Savant for defensive layering. Creates alternative defense path to HP/ARMOR stacking.

**Lore:**
Projected energy fields create a secondary defensive layer around your nanite framework, absorbing incoming damage before core structural integrity is compromised.

**Code Changes Required:**
- *Game-State:* Implement shield system with separate HP pool tracking current/max shield using SHIELDCAPACITY. Damage system must deplete shield before HP. Shield persists between combat encounters.
- *Animation:* Shield visual overlay around player character (energy barrier effect). Shield impact animations when taking damage. Shield depletion visual feedback when shield breaks.

---

### SHIELDREGENRATE
**Type:** Integer | **Default:** 0 | **Range:** 0-5000

**Description:**
Energy barrier reconstruction speed in shield points restored per second

**Game Mechanics:**
Restores SHIELDCAPACITY points per second when player hasn't taken damage recently (typically 2-3 second delay).

**Build Support:**
Critical for shield-tank Fortress Tank builds. Supports Speed Demon hit-and-run tactics. Enables defensive recovery for Glass Cannon between encounters.

**Lore:**
Continuous energy field recalibration systems restore barrier strength during combat lulls, maintaining defensive coverage through sustained engagements.

**Code Changes Required:**
- *Game-State:* Shield system must implement regeneration timer that restores SHIELDREGENRATE points per second. Timer starts after delay period (e.g., 2-3s) since last damage taken. Regeneration continues until shield reaches SHIELDCAPACITY or player takes damage.
- *Animation:* Shield recharge visual effect (pulsing energy, particle buildup). UI feedback showing shield regenerating. Possibly audio cue when regeneration begins.

---

### DODGECHANCE
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Probability of evasion protocols completely negating incoming attack damage

**Game Mechanics:**
On each enemy attack, rolls probability to completely negate all damage from that attack. Does not prevent status effects unless specified.

**Build Support:**
Enables evasion-tank variant of Fortress Tank. Core mechanic for Speed Demon survival. Supports Glass Cannon defensive layering.

**Lore:**
Predictive combat algorithms analyze enemy attack vectors and execute micro-corrections to your trajectory, allowing complete evasion of incoming strikes.

**Code Changes Required:**
- *Game-State:* Incoming damage system must implement probability roll against DODGECHANCE on each enemy attack. If roll succeeds, set damage to zero and trigger dodge event. Must occur before shield/HP damage calculation.
- *Animation:* Dodge visual effect (afterimage, blur, quick dash animation). "Miss" or "Dodge" floating text. Possibly brief invulnerability flash or particle effect.

---

### DAMAGEABSORPTION
**Type:** Integer | **Default:** 0 | **Range:** 0-5000

**Description:**
Flat damage reduction applied to all incoming attacks before percentage mitigation

**Game Mechanics:**
Subtracts flat value from each damage instance before applying percentage-based defenses like ARMOR. For example, 100 damage with 20 DAMAGEABSORPTION becomes 80 damage before armor calculation.

**Build Support:**
Core mechanic for Fortress Tank builds. Synergizes with high ARMOR for multiplicative defense. Particularly effective against many small hits versus few large hits.

**Lore:**
Reinforced outer nanite layers ablate and dissipate incoming kinetic and energy attacks, reducing effective damage transfer to core systems.

**Code Changes Required:**
- *Game-State:* Damage mitigation system must subtract DAMAGEABSORPTION value from incoming damage before applying percentage-based defenses (ARMOR). Final damage = Max(0, (incoming - DAMAGEABSORPTION) × armor_multiplier).
- *Animation:* No specific visual effect required. Could add subtle damage absorption particle effect at impact point showing flat reduction.

---

### THORNDAMAGE
**Type:** Integer | **Default:** 0 | **Range:** 0-5000

**Description:**
Retaliatory damage inflicted on attackers when your systems receive structural damage

**Game Mechanics:**
Deals flat damage to any enemy that damages the player. Triggers on each hit received, regardless of damage amount. May scale with other stats like ARMOR or HP through mods.

**Build Support:**
Enables thorns-tank variant of Fortress Tank archetype. Supports passive damage for Summoner Commander. Creates AFK farming potential with extreme values.

**Lore:**
Reactive defense protocols channel absorbed attack energy back through point-of-contact vectors, damaging enemy weapon emitters and structural frameworks during their assault.

**Code Changes Required:**
- *Game-State:* When player takes damage, deal THORNDAMAGE flat damage back to the attacking enemy. Trigger on every hit received regardless of damage amount. Track attacker reference to apply retaliation damage.
- *Animation:* Thorn/spike visual effect emanating from player toward attacker. Electric discharge or energy pulse on retaliation. Damage numbers appearing on enemy showing thorn damage.

---

### REFLECTDAMAGE
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Percentage of received damage returned to attackers through energy feedback loops

**Game Mechanics:**
Returns percentage of damage taken to the attacker. For example, taking 100 damage with 0.3 REFLECTDAMAGE deals 30 damage to the enemy. Works alongside THORNDAMAGE for combined reflect builds.

**Build Support:**
Core mechanic for reflect-focused Fortress Tank builds. Synergizes with high HP pools to maximize reflected damage. Enables counterattack strategies.

**Lore:**
Defensive energy matrices capture and redirect portions of incoming attack force, creating feedback pulses that damage enemy weapon systems and structural integrity.

**Code Changes Required:**
- *Game-State:* When player takes damage, calculate reflected damage as (damage_taken × REFLECTDAMAGE) and apply to attacking enemy. Works alongside THORNDAMAGE for combined reflect builds. Track attacker reference.
- *Animation:* Energy reflection visual effect (projectile/wave returning to attacker). Different visual from THORNDAMAGE to distinguish percentage-based vs flat reflection. Impact particles on enemy.

---

### MAXHPPERCENTBONUS
**Type:** Multiplier | **Default:** 0 | **Range:** 0-10

**Description:**
Multiplicative modifier extending maximum structural integrity capacity beyond base limits

**Game Mechanics:**
Multiplies maximum HP cap using U_HP coefficient. For example, 0.5 MAXHPPERCENTBONUS with 100 base HP and +200 HP from mods becomes (100+200) * 1.5 = 450 max HP.

**Build Support:**
Essential for Fortress Tank extreme HP builds. Enables HP-scaling strategies that use T_HP in mod equations. Creates HP stacking as viable end-game strategy.

**Lore:**
Optimized nanite density protocols increase total framework structural capacity, allowing more extensive damage buffering before critical system failure.

**Code Changes Required:**
- *Game-State:* HP system max value calculation must apply MAXHPPERCENTBONUS as multiplier using U_HP coefficient in HEL equation: final_max_hp = (base_hp + bonuses) × (1 + MAXHPPERCENTBONUS). Update max HP dynamically when stat changes.
- *Animation:* No specific visual effect required. Could add UI feedback or character size/glow scaling to indicate massive HP pools.

---

## CATEGORY 3: RESOURCE MANAGEMENT STATS (5 stats)

### ENERGYCAPACITY
**Type:** Integer | **Default:** 100 | **Range:** 0-5000

**Description:**
Maximum energy reserves available for powering special abilities and weapon systems

**Game Mechanics:**
Sets maximum energy pool available for abilities, special weapon modes, or unique mechanics. Energy is consumed by various actions and regenerates at ENERGYREGEN rate.

**Build Support:**
Critical for ability-heavy builds across all archetypes. Enables Summoner Commander minion spam. Supports Elemental Savant for frequent elemental abilities.

**Lore:**
Integrated power cells store excess energy generated by your core reactor, providing reserves for high-demand weapon discharges and tactical protocol activations.

**Code Changes Required:**
- *Game-State:* Implement energy resource system with current/max energy pools using ENERGYCAPACITY. Track energy consumption for abilities and regeneration. Display in UI alongside HP/shields.
- *Animation:* Energy bar UI element displaying current/max energy. Energy depletion animation when abilities are used. Possibly character glow or visual indicator scaling with energy level.

---

### ENERGYREGEN
**Type:** Integer | **Default:** 10 | **Range:** 0-5000

**Description:**
Energy reconstitution rate from core reactor systems in points per second

**Game Mechanics:**
Restores ENERGYCAPACITY points per second continuously or during non-combat states. Higher regeneration enables more frequent ability usage.

**Build Support:**
Essential for Elemental Savant continuous casting. Supports Summoner Commander for frequent minion deployment. Enables ability-focused variants of all archetypes.

**Lore:**
Optimized reactor efficiency protocols maximize energy conversion from ambient nanite field interactions, maintaining steady power flow to ability systems.

**Code Changes Required:**
- *Game-State:* Energy system must regenerate ENERGYREGEN points per second continuously or during specific states. Add energy to current pool until reaching ENERGYCAPACITY max. May pause during certain actions.
- *Animation:* Energy bar filling animation during regeneration. Possibly pulsing glow or particle effect on character during energy regen. UI feedback showing regen rate.

---

### COOLDOWNREDUCTION
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Acceleration modifier for ability recalibration and tactical protocol reset timers

**Game Mechanics:**
Reduces all ability cooldown timers by percentage. For example, 0.3 COOLDOWNREDUCTION makes a 10-second cooldown become 7 seconds. May have diminishing returns or caps.

**Build Support:**
Core stat for ability-spam builds across archetypes. Critical for Speed Demon dash management. Enables Summoner Commander frequent deployments.

**Lore:**
Streamlined system recalibration algorithms reduce downtime between tactical protocol executions, enabling rapid-succession ability deployments.

**Code Changes Required:**
- *Game-State:* Ability cooldown system must apply COOLDOWNREDUCTION as multiplier to all cooldown timers: actual_cooldown = base_cooldown × (1 - COOLDOWNREDUCTION). Update cooldown timers dynamically when stat changes.
- *Animation:* UI feedback showing reduced cooldown timers. Possibly accelerated cooldown UI animation/effects. No character animation required.

---

### RESOURCEEFFICIENCY
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Cost reduction modifier for energy consumption and stamina expenditure protocols

**Game Mechanics:**
Reduces all resource costs (energy, stamina, special currencies) by percentage. Enables more frequent ability usage without increasing regeneration rates.

**Build Support:**
Valuable for Speed Demon stamina management. Supports Summoner Commander minion deployment efficiency. Enables resource-intensive playstyles across archetypes.

**Lore:**
Optimized power distribution systems reduce wasted energy during ability activations, lowering total consumption while maintaining full operational output.

**Code Changes Required:**
- *Game-State:* Resource consumption system must apply RESOURCEEFFICIENCY to all costs: actual_cost = base_cost × (1 - RESOURCEEFFICIENCY). Applies to energy, stamina, and any special currencies. Calculate before deducting resources.
- *Animation:* No specific visual effect required. Could add efficient energy use visual (cleaner particles, reduced waste effects) when abilities are activated.

---

### DASHCOOLDOWN
**Type:** Float | **Default:** 3.0 | **Range:** 0-100

**Description:**
Reset timer duration for emergency evasion protocol between tactical displacement activations

**Game Mechanics:**
Sets the cooldown timer between dash ability uses. Lower values enable more frequent dashing for mobility and evasion. May interact with COOLDOWNREDUCTION.

**Build Support:**
Core mechanic for Speed Demon archetype. Critical for Glass Cannon survival through positioning. Supports hit-and-run tactics for Hybrid Berserker.

**Lore:**
System recalibration requirements limit rapid-succession activation of high-intensity movement protocols, governing the frequency of emergency displacement maneuvers.

**Code Changes Required:**
- *Game-State:* Dash ability system must use DASHCOOLDOWN as base cooldown timer. After dash activation, start cooldown timer that counts down from DASHCOOLDOWN value. May interact with COOLDOWNREDUCTION stat.
- *Animation:* Dash movement animation (rapid displacement with trail/blur effect). Cooldown UI indicator showing time remaining. Ready-state visual feedback when dash becomes available.

---

## CATEGORY 4: ELEMENTAL STATS (4 stats)

### CORRUPTIONCHANCE
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Probability of inflicting viral code corruption damage-over-time on enemy constructs

**Game Mechanics:**
On attack or proc event, rolls probability to apply corruption DoT effect that deals CORRUPTIONDAMAGE per tick. May stack multiple instances or refresh duration.

**Build Support:**
Enables corruption-focused Elemental Savant builds. Core mechanic for DoT Specialist archetype. Creates third elemental damage type alongside fire/electric.

**Lore:**
Weaponized viral protocols inject malicious code into enemy nanite systems, causing cascading structural degradation and system malfunctions over extended duration.

**Code Changes Required:**
- *Game-State:* Implement corruption proc system: on attack or proc event, roll probability against CORRUPTIONCHANCE. If successful, apply corruption DoT debuff to enemy that deals CORRUPTIONDAMAGE per tick at fixed intervals.
- *Animation:* Corruption application visual effect (viral/glitch particles, screen distortion on enemy). Corruption DoT tick effect showing ongoing damage (pulsing corruption aura, deteriorating visual on enemy). Corrupted enemy visual state (color shift, particle effects).

---

### CORRUPTIONDAMAGE
**Type:** Integer | **Default:** 0 | **Range:** 0-5000

**Description:**
Structural degradation intensity from viral code corruption effects per damage tick

**Game Mechanics:**
Sets damage per tick for corruption DoT effects. Ticks occur at fixed intervals (e.g., every 0.5 seconds). Total DoT damage depends on duration, tick rate, and this damage value.

**Build Support:**
Essential for DoT Specialist archetype. Supports Elemental Savant corruption builds. Enables area denial through corruption spread mechanics.

**Lore:**
Corrupted nanite systems suffer progressive structural failure as viral code propagates through their framework, dealing continuous damage until purge protocols complete.

**Code Changes Required:**
- *Game-State:* Corruption DoT system must deal CORRUPTIONDAMAGE per tick. Track DoT duration, tick rate (e.g., every 0.5s), and apply damage to corrupted enemies each tick. Handle stacking/refresh mechanics.
- *Animation:* Corruption damage tick visual effects (pulsing aura, deterioration particles each tick). Damage numbers appearing on enemy showing corruption damage. Ongoing corruption visual state persists through DoT duration.

---

### ELEMENTALPENETRATION
**Type:** Percentage | **Default:** 0 | **Range:** 0-1

**Description:**
Bypass percentage for enemy elemental resistance protocols and defensive shielding

**Game Mechanics:**
Reduces enemy elemental resistances by percentage before damage calculation. For example, enemy with 0.5 fire resistance and player with 0.3 ELEMENTALPENETRATION takes damage as if they had 0.35 resistance.

**Build Support:**
Critical for Elemental Savant builds in late-game against resistant enemies. Supports DoT Specialist for reliable damage. Enables elemental damage scaling versus tanky targets.

**Lore:**
Advanced frequency modulation systems attune elemental attacks to bypass enemy resistance calibrations, ensuring damage transmission despite defensive countermeasures.

**Code Changes Required:**
- *Game-State:* Elemental damage calculation must reduce enemy resistances by ELEMENTALPENETRATION percentage before applying damage: effective_resistance = enemy_resistance × (1 - ELEMENTALPENETRATION). Applies to fire, electric, and corruption damage types.
- *Animation:* No specific visual effect required. Could add penetrating visual effect (enhanced particles bypassing defenses) when ELEMENTALPENETRATION is high.

---

### IGNITESPREAD
**Type:** Integer | **Default:** 0 | **Range:** 0-10

**Description:**
Maximum thermal propagation range allowing ignite effects to chain to nearby constructs

**Game Mechanics:**
When ignite DoT is active on an enemy, it can spread to enemies within IGNITESPREAD radius. Creates fire chain reactions in grouped enemies.

**Build Support:**
Enables AoE-focused Elemental Savant fire builds. Core mechanic for DoT Specialist area denial. Creates crowd control option through damage spreading.

**Lore:**
Thermal cascade protocols detect nearby heat-vulnerable targets within effective range, allowing ignite effects to propagate through enemy formations via radiant energy transfer.

**Code Changes Required:**
- *Game-State:* Fire DoT (ignite) system must check for enemies within IGNITESPREAD radius of burning enemy. Spread ignite effect to nearby enemies, creating chain reactions. Track already-ignited enemies to prevent infinite loops.
- *Animation:* Fire spread visual effects showing flames jumping between enemies. Thermal wave or fire particles propagating from burning enemy to nearby targets. Enhanced fire visuals when spread occurs (cascading flames, heat distortion).

---

## CATEGORY 5: MINION/SUMMONER STATS (3 stats)

### MINIONDAMAGE
**Type:** Multiplier | **Default:** 1.0 | **Range:** 0-5000

**Description:**
Damage output multiplier for all deployed autonomous combat constructs and tactical drones

**Game Mechanics:**
Multiplies all damage dealt by player minions. For example, a minion with 20 base damage and 2.5 MINIONDAMAGE deals 50 damage per attack. Applies to all minion types globally.

**Build Support:**
Core scaling stat for Summoner Commander archetype. Essential for minion-focused builds. Enables transition from utility minions to primary damage source.

**Lore:**
Enhanced targeting protocols and weapon system optimizations uploaded to minion AI cores, increasing their combat effectiveness and damage output.

**Code Changes Required:**
- *Game-State:* Minion damage calculation system must apply MINIONDAMAGE as multiplier to all minion attack damage: final_damage = base_minion_damage × MINIONDAMAGE. Applies globally to all minion types.
- *Animation:* No specific visual effect required. Could add enhanced attack visual effects on minions when MINIONDAMAGE is high (larger projectiles, brighter effects).

---

### MINIONHP
**Type:** Multiplier | **Default:** 1.0 | **Range:** 0-5000

**Description:**
Structural integrity multiplier for deployed minion frameworks and autonomous constructs

**Game Mechanics:**
Multiplies all minion HP values. For example, a minion with 100 base HP and 3.0 MINIONHP has 300 effective HP. Determines minion survivability in sustained combat.

**Build Support:**
Critical for Summoner Commander minion survivability. Enables minions to tank for player. Supports long-duration minion deployments.

**Lore:**
Reinforced construction protocols increase minion nanite density and structural resilience, allowing them to withstand significantly more combat damage before decoherence.

**Code Changes Required:**
- *Game-State:* Minion HP system must apply MINIONHP as multiplier to all minion maximum HP: final_hp = base_minion_hp × MINIONHP. Update minion HP pools when stat changes. Applies globally to all minion types.
- *Animation:* Visual feedback for tankier minions (larger size, enhanced armor/shield effects, reinforced appearance). No specific animation required but minions could appear more robust.

---

### MINIONATTACKSPEED
**Type:** Multiplier | **Default:** 1.0 | **Range:** 0-5000

**Description:**
Attack cycle frequency multiplier for minion weapon systems and combat protocols

**Game Mechanics:**
Multiplies minion attack rate. For example, a minion attacking once per second with 2.0 MINIONATTACKSPEED attacks twice per second. Directly increases minion DPS alongside MINIONDAMAGE.

**Build Support:**
Core DPS stat for Summoner Commander builds. Synergizes with MINIONDAMAGE for total damage output. Enables rapid-fire minion strategies.

**Lore:**
Optimized combat algorithm processing increases minion targeting acquisition speed and weapon cycling efficiency, enabling more frequent attack executions.

**Code Changes Required:**
- *Game-State:* Minion attack system must apply MINIONATTACKSPEED as multiplier to attack rate: attacks_per_second = base_attack_rate × MINIONATTACKSPEED. Reduce time between minion attacks or increase animation speed. Applies globally to all minion types.
- *Animation:* Faster minion attack animations when MINIONATTACKSPEED is high (animation speed scaling, faster projectile firing rate). Visual feedback showing increased attack frequency.

---

## STAT SUMMARY BY BUILD ARCHETYPE

### Fortress Tank
- SHIELDCAPACITY, SHIELDREGENRATE
- DODGECHANCE, DAMAGEABSORPTION
- THORNDAMAGE, REFLECTDAMAGE
- MAXHPPERCENTBONUS

### Glass Cannon
- CRITCHANCE, CRITDAMAGE
- AMMOCAPACITY, RELOADSPEED
- LIFESTEAL

### Elemental Savant
- CORRUPTIONCHANCE, CORRUPTIONDAMAGE
- ELEMENTALPENETRATION
- IGNITESPREAD, CHAINLIGHTNING

### Summoner Commander
- MINIONDAMAGE, MINIONHP, MINIONATTACKSPEED
- ENERGYCAPACITY, ENERGYREGEN
- RESOURCEEFFICIENCY

### Speed Demon
- DASHCOOLDOWN, DODGECHANCE
- PROJECTILESPEED
- RESOURCEEFFICIENCY

### Hybrid Berserker
- LIFESTEAL
- CRITCHANCE, CRITDAMAGE

### DoT Specialist
- CORRUPTIONCHANCE, CORRUPTIONDAMAGE
- PIERCINGSHOTS
- IGNITESPREAD, ELEMENTALPENETRATION

### Precision Sniper
- CRITCHANCE, CRITDAMAGE
- PROJECTILESPEED
- RELOADSPEED, AMMOCAPACITY

---

## TECHNICAL INTEGRATION NOTES

**HEL Coefficient Usage:**
- Percentage stats (0-1 range): Use M_ coefficient (multiplicative)
- Integer stats (damage, HP, capacity): Use B_ coefficient (base additive)
- Multiplier stats (MINIONDAMAGE, MINIONHP): Use M_ coefficient
- Maximum extensions: Use U_ coefficient (MAXHPPERCENTBONUS)

**Value Formats:**
- Percentages stored as decimals (0.5 = 50%)
- Multipliers stored as decimals (2.0 = 200%)
- Integers stored as whole numbers

**Read-Only Access:**
All stats have T_ (Total) read-only variants for use in cross-stat equations:
- T_CRITCHANCE, T_HP, T_ARMOR, etc.
- Used in conditional equations: `(T_HP 100 <) val1 *`

---

**END OF STATS DESCRIPTION DOCUMENT**
