# Task Description

Create a new Stats/Mods system for the HIOX game.

## Background

This repository contains code that is used to manage Stats and Mods in the HIOX video game.
* Stats - define the state of the player (e.g., HP, ENERGY, etc.)
* Mods - represent items in the game that effect the Stats. They define HEL language code (equations) to do this (as described in this repositories code).

The HEL language and computation of Mod effects is documented in /docs/HEL-Documentation-Complete.md.

### The HIOX Game

HIOX is a 1st-person Rogue-like RPG video game. It has a story (see Lore below), sytlized graphics, and a unique Stats/Mods system modeled somewhat after the game Path of Exile. It does not (yet) offer crafting. But the complex Mod effects interact to create unique, somewhat unpredictable, effects exploitable by skilled players.

#### HIOX Lore  

When the HIOX game starts, the player, encased in some sort of suit wakes up on a beach. There are mountains in the background, and a strange mechanical Sun in the sky. Immediately, strange machines and creatures begin to attack him. He has a pistol and sword to defend himself.

[CONFIDENTIAL: The following game history and lore is required to create new Stats/Mods for HIOX. But players only discover this information over the course of play. This information cannot be hinted at or leaked to players in the names or descriptions of Stats/Mods that may be designed in this project.]

Millions of years ago, humans from Earth created "nanites" - nanometer scale machines. When trillions of them are encased together inside machine or pressure-containment suites, they can form complex machines they can do amazing things. Humans then added AI to these complex machines and used them as explorers throughout the galaxy, sending them to harsh environments that humans could not endure.

HIOX-One was one such creature, sent to the world depicted in this game over a million years before. Over the course of time, as he terraformed the world his intellect grew exponentially. With that advanced intellect he gave himself a new mission, and completely remade the world, converting all matter to nanite-based non-sentient nanomolecular machines for his personal use. Even the local star was not spared this indignity. 

But as his intellect and capabilities grew, so did his ethos. He came to reget his vast work, and felt that he should have devoted his time, energy and resources to creating a race of advanced thinking nanite creatures like himself. To creating a new, enlightened society. But sadly, his work could not be undone, could not be repurposed to that grand task. His basic programming forbade it. He felt such great remorse that he wanted to die. 

But he could not die. His basic programming forbade that too. So he created a vast array of machines and creatures programmed to attack and destroy him. If he could not die, could not kill himself, he would make others that could. He was unsuccessful. For hundreds of thousands of years, he sat on the beach, dreaming of a better world.

Then came HIOX-Estel, another nanite probe being like HIOX-One, though only partially sentient, sent to the world to assess the terraforming progress, and aid him if needed. HIOX-Estel also had a darker mission... to destroy HIOX-One if he had gone astray, as so many of his kind had.

The fight raged for centuries, but in the end HIOX-One prevailed. He re-programmed HIOX-Estel, and all the higher-level nanite creatures of his creation to carry out a grand ruse. HIOX-Estel would pretend to be HIOX-One, in command of the world, along with his minions of other sentient and non-sentient nanite creatures and machines. Their purpose, to track down and kill the real HIOX-One. Meanwhile, HIOX-One altered his own programming to the extent that was possible, to blind him to his own past. He would wake on the beach with no memory and fight everyone on the island until he died, or prevailed.  After all, he was able to prevail over HIOX-Estel with the help of the world and his minions; why shouldn't they be able to prevail over him. But should this plan fail. Should he prevail alone against the entire world... then he would simply reset, and start the process over again. And again and again until he was no more.

After many cycles in which he managed to prevail he devised a "complication" to make the task more difficult. He created a set of beacons, scattered across the island. To a nanite creature under attack and with no memory of what is going on or why, they give him a mission that appears to be important. They tell the him that he MUST defend them as the transmit vital code (a false story) for some lofty purpose, meanwhile all creatures in the vacinity try to attack the beacon and the creature. The beacons make it MORE difficult for the him (an amnisiatic HIOX-One) to survive.

Unfortunately, no lofty story convinced his amnisiatic self to continue to defend the beacons after the first few. So he had to add some incentive. So now the beacons also provide minor aid in the form of nanite injections or other items to boost his stats, and weapons to "help him survive'. [[[These are Mods, and are what you will be designing]]]. He is incentivised to defend the beacons at great personal cost because of the rewards given by the beacons.

And thus the player wakes up on the beach...

### The GOAL of this Project

Within the already defined code architecture of HEL Stats and Mods classes, define a whole new set of Stats and Mods in the JSON files Stats.asset and Mods.asset that fit in with the lore of this game. Stats include state variables for the player that interact with the game engine. Mods include weapons, armor, protection, and any other types of items that make sense. They should work together to create enhance effects when combined. But they should be balanced with negative effects to keep the game balanced. 

You have free reign to create new stats and mods (or extend the existing ones in /src/ModsData.asset and StatsData.asset), creating not just new Stats and Mods, but new types/classes of Mods. If these Stats or mods require new animations, new artwors (for physical, non-injection Mods)

YOU WILL NEED TO UNDERSTAND THE CURRENT HEL SYSTEM, LANGUAGE and CODE.

As inspiration, learn from Path of Exiles and the Mods System developed for that game (see below). Research what they did and learn from it. Be creative and adapt the best ideas to the HIOX game.

There are 4 outputs from this project:
* System Philosopy.md - Describe your new Stats/Mod system, including:
    * What are it's components? For example, did you add crafting, or new classes of items?
    * How it works. How do all the components work and work together?
    * How it fits with HIOX Lore. Or do you have suggestions for extending the lore?
    * What inspiration your system took from Path of Exiles (if any)
    * How it balances the game
* Stats Description.md - Describe all Stats in your system. Include:
    * Name
    * Description
    * How it fits in with the lore (or improves it)
    * How the game engine needs to be adapted for it (e.g., new effects rendering)
    * How it improves the game
    * How it maintains game balance
* Mods Description.md - Describe all Mods in your system. Include:
    * Name
    * Description
    * How it fits in with the lore (or improves it)
    * How it combines with other mods
    * If it is a physical object (e.g., weapon, armor, etc) describe what it looks like and any special rendering effects.
    * How it improves the game
    * How it maintains game balance
* Stats.asset - The new Stats you define in the correct HEL Stat JSON format
* Mods.asset - The new Mods you define in the correct HEL Mod JSON format
For each new Stat, describe:


### Path of Exiles (PoE) Items and Mods System (for reference)

Path of Exile's (PoE) item and mod system is highly regarded for its
exceptional depth, complexity, and the vast degree of control it offers players over item creation and customization. This system revolves around a massive pool of potential modifiers and a diverse set of crafting methods that use in-game currency items to manipulate them. 
Key aspects of the system include:

    Diverse Item Rarities: The system uses four main rarities: Normal (white), Magic (blue), Rare (yellow), and Unique (orange).
        Normal, Magic, and Rare items form the backbone of most builds. Normal items have no modifiers, Magic items have up to two (one prefix, one suffix), and Rare items can have up to six.
        Unique items are distinct, possessing fixed, exclusive modifiers that often enable or dramatically alter specific builds or gameplay mechanics, rather than simply providing the best raw stats.
    Currency as Crafting Tools: Unlike many other RPGs where crafting involves simple materials at a single station, PoE's crafting heavily relies on the same currency items used for trading. Orbs of Alteration, Chaos, Exalt, and others directly reroll, add, or refine item mods, creating a dynamic in-game economy and a deeply integrated crafting loop.
    Multi-Layered Crafting Mechanics: The game features numerous specialized crafting systems that can be combined for powerful outcomes, allowing for both general modification and highly targeted results. These include:
        Essences which guarantee a specific high-tier mod on an item.
        Fossils used in Resonators to filter the pool of possible mods when rerolling an item, allowing players to target specific archetypes (e.g., elemental damage, physical damage).
        The Crafting Bench where players can add a specific guaranteed modifier to an open slot (prefix or suffix).
        Specialized League Mechanics (like Harvest crafting in some forms) that offer powerful, often more deterministic, ways to modify existing items.
    Depth and Progression: The complexity means that achieving a "perfect" item can be extremely difficult and expensive, often costing vast amounts of in-game wealth and effort. This creates a long and satisfying progression curve, with constant opportunities to upgrade gear with incrementally better modifiers.
    Build-Defining Potential: The sheer number of potential modifiers and crafting options allows for an almost endless variety of character builds and synergies, which is a major draw for players who enjoy extensive theorycrafting and optimization. Advanced community tools like "Path of Building" help players manage this complexity. 

The highly regarded nature of the system stems from the feeling of agency and potential for deep customization, where the process of acquiring or crafting the right gear is as much a part of the game as the combat itself.