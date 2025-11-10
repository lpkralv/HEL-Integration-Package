using System;
using System.Collections.Generic;
using System.IO;

namespace HELIntegration.Examples
{
    /// <summary>
    /// Basic example showing minimal HEL system integration
    /// This example demonstrates the core workflow for HIOX developers
    /// </summary>
    public class BasicIntegration
    {
        private Dictionary<string, Stat> baseStats;
        private Dictionary<string, Mod> availableMods;
        
        public void Initialize()
        {
            // Load base statistics from asset file
            var (statsObj, _) = HELYAMLFile.LoadAsset("StatsData.asset", "statsList");
            baseStats = (Dictionary<string, Stat>)statsObj;
            
            // Load available mods from asset file  
            var (modsObj, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsList");
            var modsList = (Dictionary<int, Mod>)modsObj;
            
            // Convert to UUID-keyed dictionary for equipped mods
            availableMods = new Dictionary<string, Mod>();
            foreach (var mod in modsList.Values)
            {
                // Generate UUID if not present
                if (string.IsNullOrEmpty(mod.uuid))
                {
                    mod.uuid = $"uuid-{mod.modid}-{Guid.NewGuid().ToString("N")[..6]}";
                }
                availableMods[mod.uuid] = mod;
            }
        }
        
        public Dictionary<string, Stat> CalculatePlayerStats(List<string> equippedModUUIDs)
        {
            // Create equipped mods dictionary
            var equippedMods = new Dictionary<string, Mod>();
            
            foreach (string uuid in equippedModUUIDs)
            {
                if (availableMods.ContainsKey(uuid))
                {
                    equippedMods[uuid] = availableMods[uuid];
                }
            }
            
            // Evaluate mods against base stats
            return HEL.EvaluateMods(baseStats, equippedMods);
        }
        
        public void ExampleUsage()
        {
            // Initialize the system
            Initialize();
            
            // Simulate player having some equipped mods
            var playerEquippedMods = new List<string>();
            
            // Add first available mod to player's equipment
            foreach (var mod in availableMods.Values)
            {
                playerEquippedMods.Add(mod.uuid);
                break; // Just add one for this example
            }
            
            // Calculate final stats
            var finalStats = CalculatePlayerStats(playerEquippedMods);
            
            // Display results
            Console.WriteLine("Final Player Stats:");
            foreach (var stat in finalStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value.value}");
            }
        }
    }
}