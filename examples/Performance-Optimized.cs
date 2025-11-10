using System;
using System.Collections.Generic;
using System.Linq;

namespace HELIntegration.Examples
{
    /// <summary>
    /// Performance-optimized HEL integration example
    /// Demonstrates best practices for high-performance scenarios
    /// </summary>
    public class PerformanceOptimized
    {
        // Cache dictionaries at startup
        private static Dictionary<string, Stat> _cachedBaseStats;
        private static Dictionary<string, Mod> _cachedAvailableMods;
        private static bool _initialized = false;
        
        // Result caching for expensive calculations
        private static readonly Dictionary<string, Dictionary<string, Stat>> _resultCache = 
            new Dictionary<string, Dictionary<string, Stat>>();
        private const int MAX_CACHE_SIZE = 1000;
        
        public static void Initialize()
        {
            if (_initialized) return;
            
            try
            {
                // Load and cache base statistics once
                var (statsObj, _) = HELYAMLFile.LoadAsset("StatsData.asset", "statsList");
                _cachedBaseStats = (Dictionary<string, Stat>)statsObj;
                
                // Load and cache available mods once
                var (modsObj, _) = HELYAMLFile.LoadAsset("ModsData.asset", "modsList");
                var modsList = (Dictionary<int, Mod>)modsObj;
                
                // Convert to UUID-keyed dictionary
                _cachedAvailableMods = new Dictionary<string, Mod>();
                foreach (var mod in modsList.Values)
                {
                    if (string.IsNullOrEmpty(mod.uuid))
                    {
                        mod.uuid = $"uuid-{mod.modid}-{Guid.NewGuid().ToString("N")[..6]}";
                    }
                    _cachedAvailableMods[mod.uuid] = mod;
                }
                
                _initialized = true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to initialize HEL system: {ex.Message}", ex);
            }
        }
        
        public static Dictionary<string, Stat> GetPlayerStats(List<string> equippedModUUIDs)
        {
            if (!_initialized) Initialize();
            
            // Create cache key for this mod combination
            var cacheKey = string.Join(",", equippedModUUIDs.OrderBy(x => x));
            
            // Check cache first
            if (_resultCache.TryGetValue(cacheKey, out var cachedResult))
            {
                return new Dictionary<string, Stat>(cachedResult);
            }
            
            // Create equipped mods dictionary efficiently
            var equippedMods = new Dictionary<string, Mod>();
            foreach (string uuid in equippedModUUIDs)
            {
                if (_cachedAvailableMods.TryGetValue(uuid, out var mod))
                {
                    equippedMods[uuid] = mod;
                }
            }
            
            // Calculate stats
            var result = HEL.EvaluateMods(_cachedBaseStats, equippedMods);
            
            // Cache result (with size limit)
            if (_resultCache.Count < MAX_CACHE_SIZE)
            {
                _resultCache[cacheKey] = new Dictionary<string, Stat>(result);
            }
            else
            {
                // Simple cache eviction: clear oldest entries
                var oldestKeys = _resultCache.Keys.Take(_resultCache.Count / 2).ToList();
                foreach (var key in oldestKeys)
                {
                    _resultCache.Remove(key);
                }
                _resultCache[cacheKey] = new Dictionary<string, Stat>(result);
            }
            
            return result;
        }
        
        // Batch processing for multiple players/scenarios
        public static List<Dictionary<string, Stat>> BatchCalculateStats(
            List<List<string>> playerLoadouts)
        {
            if (!_initialized) Initialize();
            
            var results = new List<Dictionary<string, Stat>>();
            
            foreach (var loadout in playerLoadouts)
            {
                results.Add(GetPlayerStats(loadout));
            }
            
            return results;
        }
        
        // Async version for background processing
        public static async Task<Dictionary<string, Stat>> GetPlayerStatsAsync(
            List<string> equippedModUUIDs)
        {
            return await Task.Run(() => GetPlayerStats(equippedModUUIDs));
        }
        
        // Performance monitoring utilities
        public static (Dictionary<string, Stat> result, long elapsedMs) GetPlayerStatsWithTiming(
            List<string> equippedModUUIDs)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = GetPlayerStats(equippedModUUIDs);
            stopwatch.Stop();
            
            return (result, stopwatch.ElapsedMilliseconds);
        }
        
        // Validation with performance considerations
        public static (bool isValid, Dictionary<string, Stat> result, string error) 
            TryGetPlayerStats(List<string> equippedModUUIDs)
        {
            try
            {
                // Quick validation without expensive operations
                if (equippedModUUIDs == null)
                    return (false, null, "Equipment list is null");
                
                if (!_initialized)
                    Initialize();
                
                // Validate UUIDs exist before expensive calculation
                var invalidUUIDs = equippedModUUIDs.Where(uuid => 
                    !_cachedAvailableMods.ContainsKey(uuid)).ToList();
                
                if (invalidUUIDs.Any())
                    return (false, null, $"Invalid mod UUIDs: {string.Join(", ", invalidUUIDs)}");
                
                var result = GetPlayerStats(equippedModUUIDs);
                return (true, result, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
        
        // Memory management
        public static void ClearCache()
        {
            _resultCache.Clear();
        }
        
        public static int GetCacheSize()
        {
            return _resultCache.Count;
        }
        
        // Example usage with performance monitoring
        public static void ExampleUsage()
        {
            // Initialize once at application startup
            Initialize();
            
            var playerMods = new List<string>();
            // Add some mod UUIDs...
            
            // Fast cached lookup
            var (result, elapsedMs) = GetPlayerStatsWithTiming(playerMods);
            
            Console.WriteLine($"Calculation completed in {elapsedMs}ms");
            Console.WriteLine($"Cache size: {GetCacheSize()} entries");
            
            // Batch processing example
            var multipleLoadouts = new List<List<string>>
            {
                playerMods,
                new List<string>(), // Empty loadout
                // Add more loadouts...
            };
            
            var batchResults = BatchCalculateStats(multipleLoadouts);
            Console.WriteLine($"Processed {batchResults.Count} loadouts");
        }
    }
}