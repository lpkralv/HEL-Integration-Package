# Tactical Deployables Weapons Design
**Version:** 1.0
**Status:** FINAL DESIGN
**Mod ID Range:** 1034-1043 (10 weapons)
**Class Type:** Tactical Deployables
**Weapon Type Code:** 4

---

## CLASS OVERVIEW

**Tactical Deployables** are autonomous combat construct deployment systems utilizing fabrication protocols to manifest independent fighting units. These weapons enable indirect combat strategies through minion-based warfare, trading personal offensive capability for force multiplication through deployed constructs.

**Core Characteristics:**
- Minion-based combat (NUMMINIONS scaling)
- Autonomous construct deployment
- Indirect damage delivery
- Player trade-offs (reduced direct combat stats)
- Minion stat scaling (MINIONDAMAGE, MINIONHP, MINIONATTACKSPEED)

**Build Archetype Support:**
- Summoner Commander (primary archetype)
- Fortress Tank (minion tanking variants)
- Hybrid Berserker (minion + player damage mix)
- DoT Specialist (minion proc application)

---

## STANDARD CONFIGURATION TIER (4 weapons)

### MOD: BASIC COMBAT DRONE ASSEMBLY

**ModID:** 1034
**Type:** 4 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Fundamental autonomous combat drone fabricator deploying val1 tactical constructs with balanced combat parameters, reducing personal weapon damage by val2%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_GUNDAMAGE = M_GUNDAMAGE -val2 +
```

**Values:**
- val1: min 1, max 3 // Minion count (+1 to +3 drones)
- val2: min 0.15, max 0.25 // Player damage penalty (-15% to -25%)

**Modweight:** 200 (common drop)

**Build Synergies:**
- **Summoner Commander:** Foundation weapon for minion-focused builds
- **Hybrid Berserker:** Maintain some personal damage while gaining minion support
- **DoT Specialist:** Minions apply elemental procs alongside player

**Trade-offs:**
Moderate personal damage reduction. Baseline deployable weapon with balanced minion output. Requires minion stat investment to maximize effectiveness

---

### MOD: DEFENSIVE CONSTRUCT PLATFORM

**ModID:** 1035
**Type:** 4 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Reinforced autonomous turret deployment system spawning val1 heavily-armored defensive constructs with val2% increased structural integrity, but reducing personal fire rate by 30%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONHP = M_MINIONHP val2 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.3 +
```

**Values:**
- val1: min 1, max 2 // Minion count (+1 to +2 turrets)
- val2: min 0.4, max 0.8 // Minion HP bonus (+40% to +80%)

**Modweight:** 180

**Build Synergies:**
- **Summoner Commander:** Tanky minions that absorb damage while player repositions
- **Fortress Tank:** Minions act as secondary defensive layer
- **Precision Sniper:** Minions tank while player snipes from safety

**Trade-offs:**
Significant fire rate reduction limits personal DPS. Fewer minions than other options but much tankier. Requires positioning to maximize minion tanking effectiveness

---

### MOD: SCOUT DRONE ARRAY

**ModID:** 1036
**Type:** 4 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Lightweight multi-drone fabrication matrix deploying val1 fast-response scout constructs with val2% increased attack cycles, reducing personal structural integrity by 20%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_HP = M_HP -0.2 +
```

**Values:**
- val1: min 2, max 4 // Minion count (+2 to +4 scouts)
- val2: min 0.3, max 0.6 // Minion attack speed (+30% to +60%)

**Modweight:** 190

**Build Synergies:**
- **Summoner Commander:** High minion count for swarm strategies
- **DoT Specialist:** Multiple fast-attacking minions for proc application
- **Speed Demon:** Mobile minion swarm complements hit-and-run tactics

**Trade-offs:**
Player HP reduction creates vulnerability. Individual minions are weaker but numerous and fast. Requires healing or defense investment to offset HP penalty

---

### MOD: ASSAULT CONSTRUCTOR FRAMEWORK

**ModID:** 1037
**Type:** 4 (weapon)
**Rarity:** Standard

**Description (Player-Visible):**
Rapid-deployment combat fabricator spawning val1 aggressive constructs with val2% increased damage output, but reducing personal accuracy by 40% due to targeting protocol conflicts

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_ACCURACY = M_ACCURACY 0.4 +
```

**Values:**
- val1: min 1, max 2 // Minion count (+1 to +2 assault units)
- val2: min 0.4, max 0.7 // Minion damage (+40% to +70%)

**Modweight:** 170

**Build Synergies:**
- **Summoner Commander:** High-damage minions as primary DPS source
- **Fortress Tank:** Minions deal damage while player focuses on survival
- **Hybrid Berserker:** Minion DPS complements melee damage

**Trade-offs:**
Severe accuracy penalty makes personal ranged combat ineffective. Encourages pure minion damage focus or melee hybrid. Close-range combat becomes necessary if using personal weapons

---

## ENHANCED PROTOCOL TIER (3 weapons)

### MOD: HEAVY SIEGE PLATFORM

**ModID:** 1038
**Type:** 4 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
Industrial-grade combat construct deploying val1 siege-class autonomous platforms with val2% increased damage and 50% increased armor, reducing player fire rate by 40% and movement speed by 20%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_MINIONHP = M_MINIONHP 0.5 +; M_SHOTSPERSEC = M_SHOTSPERSEC -0.4 +; M_PLAYERSPEED = M_PLAYERSPEED -0.2 +
```

**Values:**
- val1: min 1, max 2 // Minion count (+1 to +2 siege units)
- val2: min 0.6, max 1.0 // Minion damage (+60% to +100%)

**Modweight:** 75

**Build Synergies:**
- **Summoner Commander:** Elite minions as primary combat force
- **Fortress Tank:** Extremely tanky minions complement tank playstyle
- **Hybrid Berserker:** Minions DPS while player melees (movement penalty less impactful)

**Trade-offs:**
Multiple severe penalties (fire rate, movement) force pure summoner playstyle. Minions become primary combat method. Requires heavy investment in minion survivability to justify trade-offs

---

### MOD: RAPID FABRICATOR NETWORK

**ModID:** 1039
**Type:** 4 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
Advanced nanite assembly matrix deploying val1 rapid-cycle combat drones with val2% attack speed, but destabilizing personal weapon systems reducing critical chance by 50% and reload speed by 30%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_CRITCHANCE = M_CRITCHANCE -0.5 +; M_RELOADSPEED = M_RELOADSPEED -0.3 +
```

**Values:**
- val1: min 2, max 3 // Minion count (+2 to +3 drones)
- val2: min 0.8, max 1.4 // Minion attack speed (+80% to +140%)

**Modweight:** 70

**Build Synergies:**
- **Summoner Commander:** Extremely fast minion attacks for DPS
- **DoT Specialist:** Rapid minion attacks maximize proc rate
- **Elemental Savant:** Fast minions apply elemental effects frequently

**Trade-offs:**
Cripples personal crit-based builds and ammo sustainability. Forces focus on minion DPS over player damage. Extremely fast minions compensate if properly scaled

---

### MOD: SYNCHRONIZED CONSTRUCT ARRAY

**ModID:** 1040
**Type:** 4 (weapon)
**Rarity:** Enhanced

**Description (Player-Visible):**
Coordinated multi-unit deployment system spawning val1 tactical constructs with val2% balanced combat enhancement to all minion parameters, reducing player damage by 35% and HP by 15%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 +; M_MINIONHP = M_MINIONHP val2 +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED val2 +; M_GUNDAMAGE = M_GUNDAMAGE -0.35 +; M_HP = M_HP -0.15 +
```

**Values:**
- val1: min 2, max 4 // Minion count (+2 to +4 constructs)
- val2: min 0.25, max 0.45 // All minion stats (+25% to +45%)

**Modweight:** 65

**Build Synergies:**
- **Summoner Commander:** All-around minion enhancement for balanced builds
- **Hybrid Berserker:** Versatile minions support varied playstyles
- **Fortress Tank:** Well-rounded minions provide offense and defense

**Trade-offs:**
Player becomes significantly weaker in both damage and survivability. Minions must carry combat effectiveness. Balanced minion scaling rewards holistic summoner investment

---

## ADVANCED MATRIX TIER (2 weapons)

### MOD: ADAPTIVE SWARM NEXUS

**ModID:** 1041
**Type:** 4 (weapon)
**Rarity:** Advanced

**Description (Player-Visible):**
Experimental swarm intelligence framework deploying val1 adaptive constructs that gain val2% damage per 100 player gun damage and 0.5% HP per point of player armor, reducing player damage by 50% and accuracy by 60%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE + T_GUNDAMAGE 100 / val2 *; M_MINIONHP = M_MINIONHP + T_ARMOR 0.005 *; M_GUNDAMAGE = M_GUNDAMAGE -0.5 +; M_ACCURACY = M_ACCURACY 0.6 +
```

**Values:**
- val1: min 2, max 4 // Minion count (+2 to +4 adaptive units)
- val2: min 0.8, max 1.5 // Damage scaling per 100 gun damage (+80% to +150%)

**Modweight:** 35

**Build Synergies:**
- **Summoner Commander:** Minions scale with gun damage investment
- **Hybrid Berserker:** Invest in gun damage/armor, minions benefit
- **Glass Cannon:** Gun damage scaling transfers to minions despite penalty

**Trade-offs:**
Massive player combat penalties force pure summoner focus. Requires specific stat investment (gun damage and armor) to maximize minion effectiveness. Complex build optimization

**Unique Mechanics:**
Minions dynamically scale with player stats despite player not using those stats directly. Creates synergy between traditional gun builds and summoner playstyle. Rewards hybrid stat investment

---

### MOD: AUTONOMOUS COMMAND MATRIX

**ModID:** 1042
**Type:** 4 (weapon)
**Rarity:** Advanced

**Description (Player-Visible):**
Hierarchical construct deployment system spawning val1 command-tier units that gain 1% to all stats per additional minion active on field, with val2% base damage increase but reducing player HP by 30% and player damage by 40%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE val2 + T_NUMMINIONS 0.01 * +; M_MINIONHP = M_MINIONHP + T_NUMMINIONS 0.01 *; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED + T_NUMMINIONS 0.01 *; M_GUNDAMAGE = M_GUNDAMAGE -0.4 +; M_HP = M_HP -0.3 +
```

**Values:**
- val1: min 1, max 2 // Minion count (+1 to +2 command units)
- val2: min 0.5, max 1.0 // Base minion damage (+50% to +100%)

**Modweight:** 30

**Build Synergies:**
- **Summoner Commander:** Scales exponentially with other minion sources
- **Hybrid Berserker:** Command units amplify existing minion army
- **Fortress Tank:** Minion army becomes extremely powerful with numbers

**Trade-offs:**
Severe player penalties to both offense and defense. Requires multiple minion sources to maximize scaling. Early game weak, late game (with many minions) extremely powerful

**Unique Mechanics:**
Minions buff each other based on total minion count. Synergizes with other minion weapons for multiplicative scaling. Creates "minion army" build archetype

---

## PROTOTYPE ASSEMBLY TIER (1 weapon)

### MOD: SELF-REPLICATING NANITE NEXUS

**ModID:** 1043
**Type:** 4 (weapon)
**Rarity:** Prototype

**Description (Player-Visible):**
Experimental self-sustaining fabrication core deploying val1 autonomous constructs that gain val2% damage per 10% HP player is missing, and gain 1% attack speed per 5 energy capacity, but reducing all player damage by 60% and player HP regen by 80%

**HEL Equation:**
```
B_NUMMINIONS = B_NUMMINIONS val1 +; M_MINIONDAMAGE = M_MINIONDAMAGE + (T_HP S_HP /) 1 - val2 * 10 * +; M_MINIONATTACKSPEED = M_MINIONATTACKSPEED + T_ENERGYCAPACITY 5 / 0.01 *; M_GUNDAMAGE = M_GUNDAMAGE -0.6 +; M_MELEEDAMAGE = M_MELEEDAMAGE -0.6 +; M_HPREGEN = M_HPREGEN -0.8 +
```

**Values:**
- val1: min 2, max 4 // Minion count (+2 to +4 replicator units)
- val2: min 1.2, max 2.0 // Damage scaling per 10% missing HP (+120% to +200% per 10%)

**Modweight:** 5

**Build Synergies:**
- **Summoner Commander:** Pure summoner build with minion scaling mechanics
- **Glass Cannon:** Low HP state amplifies minion damage dramatically
- **Hybrid Berserker:** Risk/reward playstyle with powerful low-HP minions

**Trade-offs:**
Crippling penalties to ALL player combat (gun, melee) and regeneration. Forces extreme glass cannon summoner playstyle. Rewards staying at low HP for maximum minion damage. Anti-synergy with HP regen builds

**Unique Mechanics:**
Build-defining weapon that creates "low HP summoner" archetype. Minions become exponentially stronger as player becomes weaker. Scales with energy capacity for hybrid ability/summoner builds. Extremely high risk, extremely high reward

**Complex Interaction:**
Equation calculates percentage of HP missing: (T_HP / S_HP) gives current HP ratio (e.g., 0.5 at 50% HP), subtract from 1 to get missing percentage (0.5 = 50% missing), multiply by val2 and scale by 10 for final damage bonus. At 50% HP with val2=2.0: (1-0.5) * 2.0 * 10 = +1000% minion damage

---

## DESIGN SUMMARY

**Total Weapons:** 10
**ID Range:** 1034-1043

**Rarity Distribution:**
- Standard: 4 weapons (1034-1037) | modweight 170-200
- Enhanced: 3 weapons (1038-1040) | modweight 65-75
- Advanced: 2 weapons (1041-1042) | modweight 30-35
- Prototype: 1 weapon (1043) | modweight 5

**Stat Coverage:**
- NUMMINIONS: 10 weapons (all add minions)
- MINIONDAMAGE: 8 weapons
- MINIONHP: 4 weapons
- MINIONATTACKSPEED: 5 weapons
- GUNDAMAGE: 8 weapons (penalties)
- HP: 3 weapons (penalties)
- SHOTSPERSEC: 2 weapons (penalties)
- ACCURACY: 2 weapons (penalties)
- PLAYERSPEED: 1 weapon (penalty)
- CRITCHANCE: 1 weapon (penalty)
- RELOADSPEED: 1 weapon (penalty)
- MELEEDAMAGE: 1 weapon (penalty)
- HPREGEN: 1 weapon (penalty)

**Build Archetype Support:**
- Summoner Commander: 10 weapons (primary archetype)
- Fortress Tank: 4 weapons (minion tanking variants)
- Hybrid Berserker: 4 weapons (minion + player combat)
- DoT Specialist: 3 weapons (minion proc application)
- Elemental Savant: 1 weapon (rapid elemental procs)
- Glass Cannon: 2 weapons (minion damage focus)
- Precision Sniper: 1 weapon (minions tank while sniping)
- Speed Demon: 1 weapon (mobile minion swarm)

**Trade-off Philosophy:**
- ALL weapons include player combat penalties
- Standard tier: 15-30% single-stat penalties
- Enhanced tier: 30-50% penalties plus secondary penalties
- Advanced tier: 50%+ penalties plus complex conditions
- Prototype tier: 60-80% penalties across multiple stats
- Penalties force commitment to summoner playstyle
- Higher tiers = stronger minions, weaker player

**Minion Scaling Patterns:**
- Flat minion additions (B_NUMMINIONS + val1)
- Percentage minion stat boosts (M_MINIONDAMAGE + val2)
- Cross-stat scaling (minions benefit from player stats)
- Minion army synergy (minions buff each other)
- Conditional scaling (low HP, energy capacity)

**Lore Compliance:**
- All terminology uses nanomolecular language (construct, fabricator, assembly, deploy, autonomous)
- No biological references (no "summon", "pet", "spawn", "familiar")
- Consistent with HIOX nanite world (drones, platforms, units, frameworks)
- Player-visible descriptions avoid confidential lore
- Emphasizes technological fabrication over magical summoning

**HEL Equation Validation:**
- All equations add to coefficients properly (M_X = M_X + val)
- Proper coefficient prefixes (B_NUMMINIONS, M_MINIONDAMAGE, etc.)
- M_ values use decimals (0.5 = 50%)
- Negative values properly formatted (-0.3 for -30%)
- Cross-stat dependencies use T_ prefix (T_GUNDAMAGE, T_HP, T_ARMOR)
- Complex calculations use proper postfix notation
- Advanced equations include conditionals and scaling

**Balance Considerations:**
- Player becomes significantly weaker in direct combat
- Minions must compensate for player weakness
- Requires investment in minion stats to be viable
- Early game weaker, scales with minion stat investment
- Advanced/Prototype tiers create extreme specialists
- Synergy with other minion sources creates multiplicative power
- Trade-offs prevent summoner + full damage hybrid abuse

**Unique Design Elements:**
1. **Scaling Variety:** Minions scale via flat stats, percentages, player stats, minion count, and conditional triggers
2. **Army Building:** Multiple weapons stack to create large minion armies
3. **Risk/Reward:** Low HP and stat sacrifice mechanics reward dangerous play
4. **Hybrid Builds:** Some weapons enable minion + player combat despite penalties
5. **Specialization:** Tank minions, DPS minions, fast minions, balanced minions
6. **Exponential Scaling:** Command matrix and energy scaling enable extreme late-game power

---

**END OF TACTICAL DEPLOYABLES WEAPONS DESIGN**
