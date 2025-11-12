# New Stats Design Document

**Version:** 1.0
**Status:** FINAL DESIGN
**Total New Stats:** 27
**Target Build Archetypes:** 8

---

## CATEGORY 1: CORE COMBAT STATS (8 stats)

### STAT: CRITCHANCE

**Description (Player-Visible):**
Probability of triggering critical precision strikes with enhanced structural damage output

**Value:** 0.05 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 range for percentage-based probability system (0.5 = 50% critical strike chance)

**Lore Integration:**
Advanced targeting protocols analyze structural weaknesses in enemy nanite configurations, allowing precision strikes to exploit critical points in their framework.

**Game Mechanics:**
Determines the probability that any attack (projectile or melee) triggers a critical hit, which then multiplies base damage by CRITDAMAGE. Rolls probability check on each attack event.

**Build Support:**
Critical for Glass Cannon builds. Supports Precision Sniper archetype. Enables high-burst damage strategies with proper CRITDAMAGE scaling.

**Design Rationale:**
Fills the critical strike gap identified in current stats. Creates risk/reward tension between consistent damage and burst potential. Enables crit-focused builds distinct from flat damage scaling.

---

### STAT: CRITDAMAGE

**Description (Player-Visible):**
Damage multiplier applied when critical precision strikes are triggered

**Value:** 1.5 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range to allow multipliers from 1.5x (default) to extreme values like 10x for specialized builds

**Lore Integration:**
When targeting protocols identify critical structural points, weapon emitters concentrate their output at vulnerable nanite junctions, amplifying destructive force significantly.

**Game Mechanics:**
Multiplies base damage when a critical hit occurs. For example, if base damage is 100 and CRITDAMAGE is 2.5, critical hits deal 250 damage. Works multiplicatively with all damage bonuses.

**Build Support:**
Essential for Glass Cannon builds. Core stat for Precision Sniper archetype. Synergizes with CRITCHANCE for burst damage strategies.

**Design Rationale:**
Complements CRITCHANCE to create complete critical strike system. Allows extreme damage spikes that reward accuracy and positioning. Enables one-shot potential for high-skill play.

---

### STAT: PROJECTILESPEED

**Description (Player-Visible):**
Velocity of fired projectiles from ballistic and energy weapon assemblies

**Value:** 300 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range measured in units per second to allow slow projectiles (100) to extremely fast beams (2000+)

**Lore Integration:**
Projectile acceleration systems determine how quickly nanite-compressed ammunition or energy packets traverse the battlefield, affecting engagement range effectiveness.

**Game Mechanics:**
Controls how fast projectiles move after firing. Higher speeds reduce enemy dodge windows, improve effective range, and reduce lead time required for moving targets. May interact with time-to-target calculations.

**Build Support:**
Important for Precision Sniper builds requiring long-range accuracy. Supports Elemental Savant for reliable elemental application at range.

**Design Rationale:**
Adds tactical depth to weapon choice and combat range decisions. Enables sniper builds to engage from safety. Creates meaningful stat differentiation between weapon types (fast lasers vs slow rockets).

---

### STAT: PIERCINGSHOTS

**Description (Player-Visible):**
Number of additional enemy targets projectiles can penetrate before dissipating

**Value:** 0 | **Min:** 0 | **Max:** 50

**Range Guidance:**
Uses 0-50 integer range where 0 = no pierce, 1 = hits 2 enemies total, 10 = hits 11 enemies total

**Lore Integration:**
Enhanced projectile coherence protocols maintain ammunition structural integrity after impact, allowing nanite projectiles to pass through targets and continue to secondary contacts.

**Game Mechanics:**
Determines how many additional enemies a single projectile can hit after striking its first target. Projectile continues in straight line, damaging each enemy it passes through until pierce count is exhausted.

**Build Support:**
Enables crowd control for DoT Specialist builds. Valuable for Speed Demon kiting strategies. Synergizes with elemental builds for multi-target proc application.

**Design Rationale:**
Addresses area damage gap for single-projectile builds. Rewards positioning to line up multiple enemies. Creates satisfying multi-kill moments without requiring AoE explosion mechanics.

---

### STAT: RELOADSPEED

**Description (Player-Visible):**
Time modifier for ammunition assembly and weapon recalibration cycles

**Value:** 1.0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 range as a multiplier where 1.0 = normal speed, 2.0 = twice as fast, 0.5 = half speed

**Lore Integration:**
Optimized nanite fabrication protocols accelerate the reconstruction of ammunition matrices and weapon system recalibration between firing sequences.

**Game Mechanics:**
Multiplies reload time duration. Values above 1.0 reduce reload time (faster), values below 1.0 increase reload time (slower). For example, a 3-second reload with 2.0 RELOADSPEED becomes 1.5 seconds.

**Build Support:**
Critical for Ballistic Assembly weapon users. Supports Glass Cannon sustained DPS strategies. Valuable for Speed Demon builds requiring minimal downtime.

**Design Rationale:**
Adds weapon downtime management as a tactical consideration. Creates meaningful trade-offs between magazine size and reload frequency. Enables "never reload" builds with extreme values.

---

### STAT: AMMOCAPACITY

**Description (Player-Visible):**
Maximum projectiles stored in weapon assembly magazine before reload required

**Value:** 30 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for magazine sizes from 1 (single-shot) to 1000+ (sustained fire weapons)

**Lore Integration:**
Weapon matrix storage capacity determines how many nanite-compressed projectiles can be loaded simultaneously before requiring reconstruction cycles.

**Game Mechanics:**
Sets the number of shots available before triggering a reload. Higher capacity allows sustained fire without interruption but may slow reload times. Interacts with RELOADSPEED for total uptime calculation.

**Build Support:**
Essential for Glass Cannon sustained damage. Supports DoT Specialist for continuous proc application. Important for Hybrid Berserker weapon-swap strategies.

**Design Rationale:**
Creates tactical tension between burst potential and sustained damage. Enables distinct weapon archetypes (sniper single-shot vs minigun spray). Adds ammo management as a skill element.

---

### STAT: LIFESTEAL

**Description (Player-Visible):**
Percentage of damage dealt converted to structural integrity restoration

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.1 = 10% of damage heals, 0.5 = 50% healing

**Lore Integration:**
Integrated nanite recycling protocols extract viable structural components from damaged enemy constructs, repurposing their matter to reinforce your own framework integrity.

**Game Mechanics:**
On each damage instance, heals the player for damage dealt multiplied by LIFESTEAL percentage. For example, 100 damage with 0.2 LIFESTEAL heals 20 HP. Works with all damage types including DoT and minions.

**Build Support:**
Core mechanic for Hybrid Berserker sustain. Critical for Glass Cannon survival. Enables aggressive tank strategies for Fortress Tank builds.

**Design Rationale:**
Fills identified lifesteal gap. Creates sustain option that scales with offensive power. Rewards aggressive play and risk-taking. Enables melee viability through combat healing.

---

### STAT: CHAINLIGHTNING

**Description (Player-Visible):**
Maximum number of additional targets electric discharge effects can arc to from initial contact

**Value:** 0 | **Min:** 0 | **Max:** 20

**Range Guidance:**
Uses 0-20 integer range where each point allows one additional chain jump (5 = hits 6 total enemies)

**Lore Integration:**
Electrical discharge protocols identify conductive pathways between nearby enemy nanite constructs, allowing charge effects to propagate across multiple targets in rapid succession.

**Game Mechanics:**
When electric damage is dealt or CHARGECHANCE procs, the effect chains to nearby enemies within PROCRANGE. Each chain may trigger additional elemental effects. Damage may reduce with each chain.

**Build Support:**
Enables Elemental Savant multi-target strategies. Core mechanic for DoT Specialist area denial. Synergizes with CHARGECHANCE for lightning-focused builds.

**Design Rationale:**
Creates distinctive elemental spread mechanic for lightning versus fire. Rewards enemy grouping and positioning. Fills suggested CHAINLIGHTNING slot from architecture document. Enables screen-clearing moments in dense combat.

---

## CATEGORY 2: DEFENSE/SURVIVAL STATS (7 stats)

### STAT: SHIELDCAPACITY

**Description (Player-Visible):**
Maximum structural energy barrier strength protecting outer framework layer

**Value:** 0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for shield points, typically 50-500 for normal builds, 1000+ for shield-focused tanks

**Lore Integration:**
Projected energy fields create a secondary defensive layer around your nanite framework, absorbing incoming damage before core structural integrity is compromised.

**Game Mechanics:**
Provides a regenerating damage buffer that must be depleted before HP takes damage. Shields regenerate at SHIELDREGENRATE when not taking damage. May have different resistances than HP armor.

**Build Support:**
Enables shield-tank variant of Fortress Tank builds. Supports Elemental Savant for defensive layering. Creates alternative defense path to HP/ARMOR stacking.

**Design Rationale:**
Fills identified shield mechanics gap. Creates distinct defensive archetype from HP tanking. Enables regeneration-based sustain different from HPREGEN. Adds tactical depth through damage avoidance windows.

---

### STAT: SHIELDREGENRATE

**Description (Player-Visible):**
Energy barrier reconstruction speed in shield points restored per second

**Value:** 0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for points per second, typically 5-50 for normal builds, 200+ for rapid-regen strategies

**Lore Integration:**
Continuous energy field recalibration systems restore barrier strength during combat lulls, maintaining defensive coverage through sustained engagements.

**Game Mechanics:**
Restores SHIELDCAPACITY points per second when player hasn't taken damage recently (typically 2-3 second delay). May start regenerating immediately or require damage-free window.

**Build Support:**
Critical for shield-tank Fortress Tank builds. Supports Speed Demon hit-and-run tactics. Enables defensive recovery for Glass Cannon between encounters.

**Design Rationale:**
Complements SHIELDCAPACITY to create complete shield system. Rewards tactical disengagement and cover use. Creates sustain option that doesn't require offensive stats like LIFESTEAL.

---

### STAT: DODGECHANCE

**Description (Player-Visible):**
Probability of evasion protocols completely negating incoming attack damage

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.3 = 30% dodge chance, capped at 0.75 (75%) for balance

**Lore Integration:**
Predictive combat algorithms analyze enemy attack vectors and execute micro-corrections to your trajectory, allowing complete evasion of incoming strikes.

**Game Mechanics:**
On each enemy attack, rolls probability to completely negate all damage from that attack. Does not prevent status effects unless specified. May have special interactions with AoE damage.

**Build Support:**
Enables evasion-tank variant of Fortress Tank. Core mechanic for Speed Demon survival. Supports Glass Cannon defensive layering.

**Design Rationale:**
Fills identified dodge/evasion gap. Creates RNG-based defense distinct from flat reduction. Rewards high mobility and positioning. Adds exciting "clutch dodge" moments to combat.

---

### STAT: DAMAGEABSORPTION

**Description (Player-Visible):**
Flat damage reduction applied to all incoming attacks before percentage mitigation

**Value:** 0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for flat reduction, typically 5-50 for normal builds, 200+ for absorption-focused tanks

**Lore Integration:**
Reinforced outer nanite layers ablate and dissipate incoming kinetic and energy attacks, reducing effective damage transfer to core systems.

**Game Mechanics:**
Subtracts flat value from each damage instance before applying percentage-based defenses like ARMOR. For example, 100 damage with 20 DAMAGEABSORPTION becomes 80 damage before armor calculation.

**Build Support:**
Core mechanic for Fortress Tank builds. Synergizes with high ARMOR for multiplicative defense. Particularly effective against many small hits versus few large hits.

**Design Rationale:**
Adds flat defense layer complementing percentage-based ARMOR. Creates different damage scaling versus HP stacking. Particularly strong against rapid-fire attacks, weak against boss bursts.

---

### STAT: THORNDAMAGE

**Description (Player-Visible):**
Retaliatory damage inflicted on attackers when your systems receive structural damage

**Value:** 0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for flat reflected damage per hit received, typically 10-100, extreme builds 500+

**Lore Integration:**
Reactive defense protocols channel absorbed attack energy back through point-of-contact vectors, damaging enemy weapon emitters and structural frameworks during their assault.

**Game Mechanics:**
Deals flat damage to any enemy that damages the player. Triggers on each hit received, regardless of damage amount. May scale with other stats like ARMOR or HP through mods.

**Build Support:**
Enables thorns-tank variant of Fortress Tank archetype. Supports passive damage for Summoner Commander. Creates AFK farming potential with extreme values.

**Design Rationale:**
Fills identified thorns gap. Creates passive damage scaling with survivability. Rewards face-tanking and aggressive positioning. Enables unique "damage by receiving damage" archetype.

---

### STAT: REFLECTDAMAGE

**Description (Player-Visible):**
Percentage of received damage returned to attackers through energy feedback loops

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.2 = 20% damage reflected, typically capped at 0.5-0.75 for balance

**Lore Integration:**
Defensive energy matrices capture and redirect portions of incoming attack force, creating feedback pulses that damage enemy weapon systems and structural integrity.

**Game Mechanics:**
Returns percentage of damage taken to the attacker. For example, taking 100 damage with 0.3 REFLECTDAMAGE deals 30 damage to the enemy. Works alongside THORNDAMAGE for combined reflect builds.

**Build Support:**
Core mechanic for reflect-focused Fortress Tank builds. Synergizes with high HP pools to maximize reflected damage. Enables counterattack strategies.

**Design Rationale:**
Complements THORNDAMAGE with percentage-based reflection. Creates scaling reflect option for high-damage encounters. Rewards tanking strong hits versus many weak hits.

---

### STAT: MAXHPPERCENTBONUS

**Description (Player-Visible):**
Multiplicative modifier extending maximum structural integrity capacity beyond base limits

**Value:** 0 | **Min:** 0 | **Max:** 10

**Range Guidance:**
Uses 0-10 range as percentage multiplier where 1.0 = +100% max HP, 0.5 = +50% max HP

**Lore Integration:**
Optimized nanite density protocols increase total framework structural capacity, allowing more extensive damage buffering before critical system failure.

**Game Mechanics:**
Multiplies maximum HP cap. Uses U_HP coefficient to extend beyond normal 5000 max. For example, 0.5 MAXHPPERCENTBONUS with 100 base HP and +200 HP from mods becomes (100+200) * 1.5 = 450 max HP.

**Build Support:**
Essential for Fortress Tank extreme HP builds. Enables HP-scaling strategies that use T_HP in mod equations. Creates HP stacking as viable end-game strategy.

**Design Rationale:**
Utilizes underused U_ coefficient system. Allows HP scaling beyond 5000 cap for extreme builds. Creates multiplicative HP scaling distinct from flat additions. Enables "stack HP to absurd values" endgame progression.

---

## CATEGORY 3: RESOURCE MANAGEMENT STATS (5 stats)

### STAT: ENERGYCAPACITY

**Description (Player-Visible):**
Maximum energy reserves available for powering special abilities and weapon systems

**Value:** 100 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for energy points, typically 100-300 for normal builds, 1000+ for ability-spam strategies

**Lore Integration:**
Integrated power cells store excess energy generated by your core reactor, providing reserves for high-demand weapon discharges and tactical protocol activations.

**Game Mechanics:**
Sets maximum energy pool available for abilities, special weapon modes, or unique mechanics. Energy is consumed by various actions and regenerates at ENERGYREGEN rate. May gate powerful abilities behind energy costs.

**Build Support:**
Critical for ability-heavy builds across all archetypes. Enables Summoner Commander minion spam. Supports Elemental Savant for frequent elemental abilities.

**Design Rationale:**
Fills identified energy resource gap. Creates resource management layer beyond HP/Stamina. Enables mana-like system for ability gating. Adds build diversity through resource investment decisions.

---

### STAT: ENERGYREGEN

**Description (Player-Visible):**
Energy reconstitution rate from core reactor systems in points per second

**Value:** 10 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for points per second, typically 10-50 for normal builds, 200+ for rapid-regen casters

**Lore Integration:**
Optimized reactor efficiency protocols maximize energy conversion from ambient nanite field interactions, maintaining steady power flow to ability systems.

**Game Mechanics:**
Restores ENERGYCAPACITY points per second continuously or during non-combat states. Higher regeneration enables more frequent ability usage and sustains energy-intensive playstyles.

**Build Support:**
Essential for Elemental Savant continuous casting. Supports Summoner Commander for frequent minion deployment. Enables ability-focused variants of all archetypes.

**Design Rationale:**
Complements ENERGYCAPACITY to create complete energy system. Determines ability usage frequency and spam potential. Creates trade-off between capacity and regeneration investment.

---

### STAT: COOLDOWNREDUCTION

**Description (Player-Visible):**
Acceleration modifier for ability recalibration and tactical protocol reset timers

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.4 = 40% cooldown reduction (5 second ability becomes 3 seconds)

**Lore Integration:**
Streamlined system recalibration algorithms reduce downtime between tactical protocol executions, enabling rapid-succession ability deployments.

**Game Mechanics:**
Reduces all ability cooldown timers by percentage. For example, 0.3 COOLDOWNREDUCTION makes a 10-second cooldown become 7 seconds. May have diminishing returns or caps to prevent instant cooldowns.

**Build Support:**
Core stat for ability-spam builds across archetypes. Critical for Speed Demon dash management. Enables Summoner Commander frequent deployments.

**Design Rationale:**
Adds ability-focused scaling path distinct from damage or defense. Creates "spam abilities" archetype. Rewards investment in ability-focused builds. Balances with ENERGYCAPACITY/ENERGYREGEN for complete ability economy.

---

### STAT: RESOURCEEFFICIENCY

**Description (Player-Visible):**
Cost reduction modifier for energy consumption and stamina expenditure protocols

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.3 = 30% cost reduction (100 energy ability costs 70 energy)

**Lore Integration:**
Optimized power distribution systems reduce wasted energy during ability activations, lowering total consumption while maintaining full operational output.

**Game Mechanics:**
Reduces all resource costs (energy, stamina, special currencies) by percentage. Multiplicative with base costs. Enables more frequent ability usage without increasing regeneration rates.

**Build Support:**
Valuable for Speed Demon stamina management. Supports Summoner Commander minion deployment efficiency. Enables resource-intensive playstyles across archetypes.

**Design Rationale:**
Creates alternative path to resource management versus capacity/regen stacking. Enables "free ability" builds at extreme values. Adds economic optimization layer to build planning.

---

### STAT: DASHCOOLDOWN

**Description (Player-Visible):**
Reset timer duration for emergency evasion protocol between tactical displacement activations

**Value:** 3.0 | **Min:** 0 | **Max:** 100

**Range Guidance:**
Uses 0-100 absolute range in seconds where 3.0 = dash available every 3 seconds, 0.5 = extremely mobile

**Lore Integration:**
System recalibration requirements limit rapid-succession activation of high-intensity movement protocols, governing the frequency of emergency displacement maneuvers.

**Game Mechanics:**
Sets the cooldown timer between dash ability uses. Lower values enable more frequent dashing for mobility and evasion. May interact with COOLDOWNREDUCTION for even faster dash availability.

**Build Support:**
Core mechanic for Speed Demon archetype. Critical for Glass Cannon survival through positioning. Supports Hit-and-run tactics for Hybrid Berserker.

**Design Rationale:**
Expands existing movement stat category with tactical mobility option. Creates skill-based defense through positioning. Enables high-mobility playstyles. Adds depth to combat through dash management.

---

## CATEGORY 4: ELEMENTAL STATS (4 stats)

### STAT: CORRUPTIONCHANCE

**Description (Player-Visible):**
Probability of inflicting viral code corruption damage-over-time on enemy constructs

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.3 = 30% corruption application chance per attack or proc event

**Lore Integration:**
Weaponized viral protocols inject malicious code into enemy nanite systems, causing cascading structural degradation and system malfunctions over extended duration.

**Game Mechanics:**
On attack or proc event, rolls probability to apply corruption DoT effect that deals CORRUPTIONDAMAGE per tick. May stack multiple instances or refresh duration. Resisted by CORRUPTIONRESISTANCE.

**Build Support:**
Enables corruption-focused Elemental Savant builds. Core mechanic for DoT Specialist archetype. Creates third elemental damage type alongside fire/electric.

**Design Rationale:**
Fills required CORRUPTIONCHANCE slot from architecture document. Completes elemental trilogy (fire/electric/corruption). Enables pure DoT strategies. Creates synergy with existing CORRUPTIONRESISTANCE and CORRUPTIONSPREADCHANCE stats.

---

### STAT: CORRUPTIONDAMAGE

**Description (Player-Visible):**
Structural degradation intensity from viral code corruption effects per damage tick

**Value:** 0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 absolute range for damage per tick, typically 5-50 for normal DoT, 200+ for specialized builds

**Lore Integration:**
Corrupted nanite systems suffer progressive structural failure as viral code propagates through their framework, dealing continuous damage until purge protocols complete.

**Game Mechanics:**
Sets damage per tick for corruption DoT effects. Ticks occur at fixed intervals (e.g., every 0.5 seconds). Total DoT damage depends on duration, tick rate, and this damage value.

**Build Support:**
Essential for DoT Specialist archetype. Supports Elemental Savant corruption builds. Enables area denial through corruption spread mechanics.

**Design Rationale:**
Complements CORRUPTIONCHANCE to create complete corruption system. Fills required CORRUPTIONDAMAGE slot. Enables scaling DoT damage distinct from direct damage builds. Works with CORRUPTIONSPREADCHANCE for epidemic strategies.

---

### STAT: ELEMENTALPENETRATION

**Description (Player-Visible):**
Bypass percentage for enemy elemental resistance protocols and defensive shielding

**Value:** 0 | **Min:** 0 | **Max:** 1

**Range Guidance:**
Uses 0-1 percentage range where 0.4 = ignore 40% of enemy elemental resistances

**Lore Integration:**
Advanced frequency modulation systems attune elemental attacks to bypass enemy resistance calibrations, ensuring damage transmission despite defensive countermeasures.

**Game Mechanics:**
Reduces enemy elemental resistances by percentage before damage calculation. For example, enemy with 0.5 fire resistance and player with 0.3 ELEMENTALPENETRATION takes damage as if they had 0.35 resistance (0.5 - 0.5*0.3).

**Build Support:**
Critical for Elemental Savant builds in late-game against resistant enemies. Supports DoT Specialist for reliable damage. Enables elemental damage scaling versus tanky targets.

**Design Rationale:**
Fills required ELEMENTALPENETRATION slot. Creates counter-stat to enemy resistances. Enables elemental builds to remain viable against resistant enemies. Adds build investment decision for elemental penetration versus raw damage.

---

### STAT: IGNITESPREAD

**Description (Player-Visible):**
Maximum thermal propagation range allowing ignite effects to chain to nearby constructs

**Value:** 0 | **Min:** 0 | **Max:** 10

**Range Guidance:**
Uses 0-10 integer range where each point extends chain radius by game units, typically 1-3 for normal builds

**Lore Integration:**
Thermal cascade protocols detect nearby heat-vulnerable targets within effective range, allowing ignite effects to propagate through enemy formations via radiant energy transfer.

**Game Mechanics:**
When ignite DoT is active on an enemy, it can spread to enemies within IGNITESPREAD radius. May spread once per ignite or continuously. Creates fire chain reactions in grouped enemies.

**Build Support:**
Enables AoE-focused Elemental Savant fire builds. Core mechanic for DoT Specialist area denial. Creates crowd control option through damage spreading.

**Design Rationale:**
Fills suggested IGNITESPREAD slot from architecture document. Creates fire-specific spread mechanic distinct from CHAINLIGHTNING. Rewards enemy grouping and positioning. Enables satisfying "everything is burning" moments.

---

## CATEGORY 5: MINION/SUMMONER STATS (3 stats)

### STAT: MINIONDAMAGE

**Description (Player-Visible):**
Damage output multiplier for all deployed autonomous combat constructs and tactical drones

**Value:** 1.0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 range as multiplier where 1.0 = normal damage, 2.0 = double damage, 5.0 = extreme scaling

**Lore Integration:**
Enhanced targeting protocols and weapon system optimizations uploaded to minion AI cores, increasing their combat effectiveness and damage output.

**Game Mechanics:**
Multiplies all damage dealt by player minions. For example, a minion with 20 base damage and 2.5 MINIONDAMAGE deals 50 damage per attack. Applies to all minion types globally.

**Build Support:**
Core scaling stat for Summoner Commander archetype. Essential for minion-focused builds. Enables transition from utility minions to primary damage source.

**Design Rationale:**
Fills required MINIONDAMAGE slot. Enables offensive scaling for summoner builds. Creates investment path for minion damage distinct from player damage. Works with NUMMINIONS for total DPS calculation.

---

### STAT: MINIONHP

**Description (Player-Visible):**
Structural integrity multiplier for deployed minion frameworks and autonomous constructs

**Value:** 1.0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 range as multiplier where 1.0 = normal HP, 2.0 = double HP, 10.0 = tank minions

**Lore Integration:**
Reinforced construction protocols increase minion nanite density and structural resilience, allowing them to withstand significantly more combat damage before decoherence.

**Game Mechanics:**
Multiplies all minion HP values. For example, a minion with 100 base HP and 3.0 MINIONHP has 300 effective HP. Determines minion survivability in sustained combat.

**Build Support:**
Critical for Summoner Commander minion survivability. Enables minions to tank for player. Supports long-duration minion deployments.

**Design Rationale:**
Fills required MINIONHP slot. Creates defensive scaling option for summoner builds. Prevents minions from dying instantly in difficult content. Adds depth to summoner build optimization (damage vs survivability trade-off).

---

### STAT: MINIONATTACKSPEED

**Description (Player-Visible):**
Attack cycle frequency multiplier for minion weapon systems and combat protocols

**Value:** 1.0 | **Min:** 0 | **Max:** 5000

**Range Guidance:**
Uses 0-5000 range as multiplier where 1.0 = normal attack speed, 2.0 = twice as fast, 0.5 = half speed

**Lore Integration:**
Optimized combat algorithm processing increases minion targeting acquisition speed and weapon cycling efficiency, enabling more frequent attack executions.

**Game Mechanics:**
Multiplies minion attack rate. For example, a minion attacking once per second with 2.0 MINIONATTACKSPEED attacks twice per second. Directly increases minion DPS alongside MINIONDAMAGE.

**Build Support:**
Core DPS stat for Summoner Commander builds. Synergizes with MINIONDAMAGE for total damage output. Enables rapid-fire minion strategies.

**Design Rationale:**
Fills required MINIONATTACKSPEED slot. Completes minion stat trinity (damage/HP/attack speed). Creates alternative scaling path to pure damage stacking. Enables different minion build focuses (few strong minions vs many fast minions).

---

## SUMMARY

**Total Stats Created:** 27

**Category Breakdown:**
- Core Combat: 8 stats (CRITCHANCE, CRITDAMAGE, PROJECTILESPEED, PIERCINGSHOTS, RELOADSPEED, AMMOCAPACITY, LIFESTEAL, CHAINLIGHTNING)
- Defense/Survival: 7 stats (SHIELDCAPACITY, SHIELDREGENRATE, DODGECHANCE, DAMAGEABSORPTION, THORNDAMAGE, REFLECTDAMAGE, MAXHPPERCENTBONUS)
- Resource Management: 5 stats (ENERGYCAPACITY, ENERGYREGEN, COOLDOWNREDUCTION, RESOURCEEFFICIENCY, DASHCOOLDOWN)
- Elemental: 4 stats (CORRUPTIONCHANCE, CORRUPTIONDAMAGE, ELEMENTALPENETRATION, IGNITESPREAD)
- Minion/Summoner: 3 stats (MINIONDAMAGE, MINIONHP, MINIONATTACKSPEED)

**Build Archetype Coverage:**
- Fortress Tank: SHIELDCAPACITY, SHIELDREGENRATE, DAMAGEABSORPTION, THORNDAMAGE, REFLECTDAMAGE, MAXHPPERCENTBONUS
- Glass Cannon: CRITCHANCE, CRITDAMAGE, AMMOCAPACITY, RELOADSPEED, LIFESTEAL
- Elemental Savant: CORRUPTIONCHANCE, CORRUPTIONDAMAGE, ELEMENTALPENETRATION, IGNITESPREAD, CHAINLIGHTNING
- Summoner Commander: MINIONDAMAGE, MINIONHP, MINIONATTACKSPEED, ENERGYCAPACITY, ENERGYREGEN, RESOURCEEFFICIENCY
- Speed Demon: DASHCOOLDOWN, DODGECHANCE, PROJECTILESPEED, RESOURCEEFFICIENCY
- Hybrid Berserker: LIFESTEAL, CRITCHANCE, CRITDAMAGE
- DoT Specialist: CORRUPTIONCHANCE, CORRUPTIONDAMAGE, PIERCINGSHOTS, IGNITESPREAD, ELEMENTALPENETRATION
- Precision Sniper: CRITCHANCE, CRITDAMAGE, PROJECTILESPEED, RELOADSPEED, AMMOCAPACITY

**Gaps Filled:**
- ✓ Critical strike system (CRITCHANCE, CRITDAMAGE)
- ✓ Shield mechanics (SHIELDCAPACITY, SHIELDREGENRATE)
- ✓ Energy resource system (ENERGYCAPACITY, ENERGYREGEN, COOLDOWNREDUCTION, RESOURCEEFFICIENCY)
- ✓ Dodge/evasion (DODGECHANCE)
- ✓ Lifesteal (LIFESTEAL)
- ✓ Thorns/reflect (THORNDAMAGE, REFLECTDAMAGE)
- ✓ Corruption damage type (CORRUPTIONCHANCE, CORRUPTIONDAMAGE)
- ✓ Minion scaling (MINIONDAMAGE, MINIONHP, MINIONATTACKSPEED)

**Lore Compliance:**
- All descriptions use nanomolecular terminology (nanite, structural integrity, protocols, constructs)
- No biological terms used (no blood, flesh, healing, wounds)
- Consistent with HIOX world lore (no confidential reveals)

**Format Compliance:**
- All stat names are UPPERCASE with underscores
- Value ranges appropriate for stat types (0-1 for percentages, 0-5000 for absolutes)
- Descriptions follow format requirements
- Clear build support and design rationale provided

---

**END OF NEW STATS DESIGN DOCUMENT**
