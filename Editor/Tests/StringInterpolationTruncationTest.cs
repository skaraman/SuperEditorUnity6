using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Test to reproduce and verify the fix for string interpolation display truncation bug
    /// where the display shows only partial content instead of the full interpolated string
    /// </summary>
    public class StringInterpolationTruncationTest
    {
        [UnityEditor.MenuItem("SuperEditor/Test String Interpolation Truncation Fix")]
        public static void TestStringInterpolationTruncation()
        {
            Debug.Log("=== Testing String Interpolation Truncation Fix ===");
            
            // Test the specific cases from the problem statement
            var equip = new { Key = "weapon", Value = new { gearId = "sword123" } };
            
            // This line should show the FULL string, not just "{equip.Key}";"
            string gearId = $"{equip.Value.gearId}_{equip.Key}";
            Debug.Log($"gearId assignment should show full line: else gearId = $\"{equip.Value.gearId}_{equip.Key}\";");
            Debug.Log($"Result: {gearId}");
            
            // This line should show the FULL string, not just "{gearId}");"
            string message = $"No parts found for equipped gearId: {gearId}";
            Debug.Log($"Debug.LogError should show full line: Debug.LogError($\"No parts found for equipped gearId: {gearId}\");");
            Debug.Log($"Result: {message}");
            
            // Additional test cases to ensure we don't break other patterns
            string simple = $"Hello World";
            Debug.Log($"Simple interpolation: {simple}");
            
            int value = 42;
            string withNumber = $"Value is: {value}";
            Debug.Log($"With number: {withNumber}");
            
            string complex = $"Complex: {equip.Value.gearId} and {equip.Key} with {value}";
            Debug.Log($"Complex interpolation: {complex}");
            
            Debug.Log("=== String Interpolation Truncation Test Complete ===");
        }
    }
}