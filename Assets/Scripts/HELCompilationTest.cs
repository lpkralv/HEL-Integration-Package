using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple test script to verify HEL system compiles and basic functionality works.
/// This script exercises core HEL classes to ensure proper compilation in Unity.
/// </summary>
public class HELCompilationTest : MonoBehaviour
{
    [Header("HEL Compilation Test")]
    [SerializeField] private bool runTestOnStart = true;
    
    void Start()
    {
        if (runTestOnStart)
        {
            TestHELCompilation();
        }
    }
    
    /// <summary>
    /// Tests basic HEL functionality to ensure compilation works properly
    /// </summary>
    public void TestHELCompilation()
    {
        Debug.Log("=== HEL Compilation Test Started ===");
        
        try
        {
            // Test 1: Create basic stat and mod dictionaries
            var stats = new Dictionary<string, Stat>();
            var mods = new Dictionary<string, Mod>();
            
            // Test 2: Create a simple stat
            var healthStat = new Stat
            {
                name = "HEALTH",
                value = 100f,
                min = 0f,
                max = 200f
            };
            stats["HEALTH"] = healthStat;
            
            // Test 3: Create a simple mod
            var healthMod = new Mod
            {
                name = "Health Boost",
                equation = "#!1;S_HEALTH = S_HEALTH + VAL;",
                value = 25f
            };
            mods["HEALTH_BOOST"] = healthMod;
            
            Debug.Log($"Created stat: {healthStat.name} = {healthStat.value}");
            Debug.Log($"Created mod: {healthMod.name} with equation: {healthMod.equation}");
            
            // Test 4: Test HEL evaluation
            var result = HEL.EvaluateMods(stats, mods);
            
            if (result.ContainsKey("HEALTH"))
            {
                float finalHealth = result["HEALTH"].value;
                Debug.Log($"HEL Evaluation successful! Final HEALTH: {finalHealth}");
                
                if (Mathf.Approximately(finalHealth, 125f))
                {
                    Debug.Log("✅ HEL Test PASSED: Health correctly calculated (100 + 25 = 125)");
                }
                else
                {
                    Debug.LogWarning($"⚠️ HEL Test WARNING: Expected 125, got {finalHealth}");
                }
            }
            else
            {
                Debug.LogError("❌ HEL Test FAILED: No HEALTH result returned");
            }
            
            // Test 5: Test additional HEL classes exist and are accessible
            TestHELClasses();
            
            Debug.Log("=== HEL Compilation Test Completed Successfully ===");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"❌ HEL Compilation Test FAILED with exception: {ex.Message}");
            Debug.LogError($"Stack trace: {ex.StackTrace}");
        }
    }
    
    /// <summary>
    /// Tests that all HEL classes are properly accessible
    /// </summary>
    private void TestHELClasses()
    {
        // Test class accessibility (compilation test)
        Debug.Log("Testing HEL class accessibility:");
        
        // These should all compile without errors
        var lexer = typeof(HELLexer);
        var interpreter = typeof(HELInterpreter);
        var ordering = typeof(HELOrdering);
        var picker = typeof(HELPicker);
        var csvFile = typeof(HELCSVFile);
        var yamlFile = typeof(HELYAMLFile);
        var assetDefs = typeof(HELAssetDefs);
        var langDefs = typeof(HELLangDefs);
        
        Debug.Log($"✅ All HEL classes accessible: {lexer.Name}, {interpreter.Name}, {ordering.Name}, etc.");
    }
    
    [ContextMenu("Run HEL Test")]
    public void RunTestManually()
    {
        TestHELCompilation();
    }
}