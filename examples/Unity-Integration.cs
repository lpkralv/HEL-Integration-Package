using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HELIntegration.Examples
{
    /// <summary>
    /// Unity-specific HEL integration example
    /// Shows how to integrate HEL with Unity game systems
    /// </summary>
    public class UnityIntegration : MonoBehaviour
    {
        [Header("Asset Paths")]
        [SerializeField] private string statsAssetPath = "StatsData.asset";
        [SerializeField] private string modsAssetPath = "ModsData.asset";
        
        [Header("Player Stats")]
        [SerializeField] private float playerHealth = 100f;
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private float playerDamage = 10f;
        
        private Dictionary<string, Stat> baseStats;
        private Dictionary<string, Mod> availableMods;
        private Dictionary<string, Stat> currentPlayerStats;
        private List<string> equippedModUUIDs = new List<string>();
        
        void Start()
        {
            InitializeHELSystem();
            RecalculatePlayerStats();
        }
        
        private void InitializeHELSystem()
        {
            try
            {
                // Load from StreamingAssets folder
                string statsPath = Path.Combine(Application.streamingAssetsPath, statsAssetPath);
                string modsPath = Path.Combine(Application.streamingAssetsPath, modsAssetPath);
                
                // Load base statistics
                var (statsObj, _) = HELYAMLFile.LoadAsset(statsPath, "statsList");
                baseStats = (Dictionary<string, Stat>)statsObj;
                
                // Load available mods
                var (modsObj, _) = HELYAMLFile.LoadAsset(modsPath, "modsList");
                var modsList = (Dictionary<int, Mod>)modsObj;
                
                // Convert to UUID-keyed dictionary
                availableMods = new Dictionary<string, Mod>();
                foreach (var mod in modsList.Values)
                {
                    if (string.IsNullOrEmpty(mod.uuid))
                    {
                        mod.uuid = $"uuid-{mod.modid}-{Guid.NewGuid().ToString("N")[..6]}";
                    }
                    availableMods[mod.uuid] = mod;
                }
                
                Debug.Log($"HEL System initialized: {baseStats.Count} stats, {availableMods.Count} mods");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to initialize HEL system: {ex.Message}");
            }
        }
        
        public void EquipMod(string modUUID)
        {
            if (availableMods.ContainsKey(modUUID) && !equippedModUUIDs.Contains(modUUID))
            {
                equippedModUUIDs.Add(modUUID);
                RecalculatePlayerStats();
                
                Debug.Log($"Equipped mod: {availableMods[modUUID].name}");
            }
        }
        
        public void UnequipMod(string modUUID)
        {
            if (equippedModUUIDs.Remove(modUUID))
            {
                RecalculatePlayerStats();
                
                Debug.Log($"Unequipped mod: {availableMods[modUUID].name}");
            }
        }
        
        private void RecalculatePlayerStats()
        {
            try
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
                
                // Calculate final stats
                currentPlayerStats = HEL.EvaluateMods(baseStats, equippedMods);
                
                // Apply to Unity game systems
                ApplyStatsToGameSystems();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to calculate player stats: {ex.Message}");
                // Fallback to base stats
                currentPlayerStats = new Dictionary<string, Stat>(baseStats);
            }
        }
        
        private void ApplyStatsToGameSystems()
        {
            // Apply calculated stats to Unity components
            if (currentPlayerStats.ContainsKey("HP"))
            {
                playerHealth = currentPlayerStats["HP"].value;
            }
            
            if (currentPlayerStats.ContainsKey("PLAYERSPEED"))
            {
                playerSpeed = currentPlayerStats["PLAYERSPEED"].value;
            }
            
            if (currentPlayerStats.ContainsKey("GUNDAMAGE"))
            {
                playerDamage = currentPlayerStats["GUNDAMAGE"].value;
            }
            
            // Notify other systems of stat changes
            OnStatsChanged();
        }
        
        private void OnStatsChanged()
        {
            // Send Unity events or update UI
            // Example: Update health bar, speed indicators, etc.
        }
        
        public float GetStatValue(string statName)
        {
            if (currentPlayerStats?.ContainsKey(statName.ToUpper()) == true)
            {
                return currentPlayerStats[statName.ToUpper()].value;
            }
            return 0f;
        }
        
        // Example: Get available mods for UI display
        public List<Mod> GetAvailableMods()
        {
            return new List<Mod>(availableMods.Values);
        }
        
        // Example: Check if mod is equipped
        public bool IsModEquipped(string modUUID)
        {
            return equippedModUUIDs.Contains(modUUID);
        }
    }
}