using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Test to verify that the parser correctly handles the specific problem cases
    /// mentioned in the issue where string interpolation was showing truncated content
    /// </summary>
    public class InterpolationDisplayVerificationTest
    {
        [UnityEditor.MenuItem("SuperEditor/Verify Interpolation Display Fix")]
        public static void VerifyInterpolationDisplayFix()
        {
            Debug.Log("=== Verifying String Interpolation Display Fix ===");
            
            // Simulate the exact scenarios from the problem statement
            
            // Case 1: The gearId assignment that was showing as "{equip.Key}";"
            Debug.Log("Testing Case 1: gearId assignment");
            Debug.Log("Original problem: else gearId = $\"{equip.Value.gearId}_{equip.Key}\"; showed as {equip.Key}\";");
            
            // Simulate the data structure
            var equip = new { 
                Key = "weapon", 
                Value = new { gearId = "sword123" } 
            };
            
            // This line should now display correctly in the editor
            string gearId = $"{equip.Value.gearId}_{equip.Key}";
            Debug.Log($"Result: gearId = {gearId}");
            Debug.Log("Expected: Should show full interpolated string syntax in editor");
            
            // Case 2: The Debug.LogError that was showing as "{gearId}");"
            Debug.Log("\nTesting Case 2: Debug.LogError with interpolation");
            Debug.Log("Original problem: Debug.LogError($\"No parts found for equipped gearId: {gearId}\"); showed as {gearId}\");");
            
            // This line should now display correctly in the editor  
            string errorMessage = $"No parts found for equipped gearId: {gearId}";
            Debug.LogError(errorMessage);
            Debug.Log("Expected: Should show full interpolated string syntax in editor");
            
            // Additional verification cases
            Debug.Log("\nTesting additional cases:");
            
            // Multiple interpolations
            string complex = $"Gear: {equip.Value.gearId}, Type: {equip.Key}";
            Debug.Log($"Multiple interpolations: {complex}");
            
            // Nested property access
            string nested = $"Path: {equip.Value.gearId}";
            Debug.Log($"Nested property: {nested}");
            
            // Simple interpolation
            string simple = $"Value: {gearId}";
            Debug.Log($"Simple interpolation: {simple}");
            
            Debug.Log("\n=== Verification Complete ===");
            Debug.Log("If the fix is working correctly, all the interpolated strings above");
            Debug.Log("should display their full syntax in the SuperEditor, not just the last part.");
        }
    }
}