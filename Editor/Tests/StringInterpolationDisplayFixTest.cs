using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Test to verify the string interpolation display fix where $"" should show the complete string
    /// </summary>
    public class StringInterpolationDisplayFixTest
    {
        [UnityEditor.MenuItem("SuperEditor/Test String Interpolation Display Fix")]
        public static void TestStringInterpolationDisplayFix()
        {
            Debug.Log("=== Testing String Interpolation Display Fix ===");
            
            // Test the specific issue: empty interpolated string
            string empty = $"";
            Debug.Log($"Empty interpolated string should show '$\"\"': {empty}");
            
            // Test other patterns to ensure they still work
            string simple = $"hello";
            Debug.Log($"Simple interpolated string should show '$\"hello\"': {simple}");
            
            int value = 42;
            string withValue = $"{value}";
            Debug.Log($"Interpolated string with value should show '$\"{{{value}}}\"': {withValue}");
            
            string complex = $"Value: {value}";
            Debug.Log($"Complex interpolated string should show '$\"Value: {{{value}}}\"': {complex}");
            
            Debug.Log("=== String Interpolation Display Fix Test Complete ===");
        }
    }
}