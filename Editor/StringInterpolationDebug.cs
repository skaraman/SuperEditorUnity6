using UnityEngine;
using System.Reflection;

namespace SuperEditor
{
    /// <summary>
    /// Debug class to test the string interpolation parsing issue
    /// </summary>
    public static class StringInterpolationDebug
    {
        /// <summary>
        /// Test the problematic string interpolation pattern
        /// </summary>
        public static void TestProblematicString()
        {
            string gearId = "GEAR_123";
            
            // This is the problematic line that the editor treats as syntax code instead of string:
            Debug.LogWarning($"No parts found for equipped gearId: {gearId}");
            
            // Alternatives that should work:
            Debug.LogWarning($"No parts found for equipped gearId - {gearId}");  // Different punctuation
            Debug.LogWarning($"No parts found for equipped gearId {gearId}");     // No colon
            Debug.LogWarning(string.Format("No parts found for equipped gearId: {0}", gearId)); // string.Format
        }
        
        /// <summary>
        /// Comprehensive test for the string interpolation fix
        /// </summary>
        public static void TestStringInterpolationFix()
        {
            string gearId = "GEAR_123";
            string message = "test";
            int number = 42;
            
            // Test the original problematic pattern
            Debug.LogWarning($"No parts found for equipped gearId: {gearId}");
            
            // Test other patterns with colons before interpolations
            Debug.LogWarning($"Error message: {message}");
            Debug.LogWarning($"Status code: {number}");
            Debug.LogWarning($"Configuration setting: {gearId}");
            Debug.LogWarning($"Database connection: {message}");
            
            // Test patterns with format specifiers (should also work)
            Debug.LogWarning($"Number: {number:D}");
            Debug.LogWarning($"Hex: {number:X}");
            
            // Test multiple interpolations
            Debug.LogWarning($"Error in gear {gearId}: {message}");
            Debug.LogWarning($"Status: {number}, Message: {message}");
            
            // Test complex patterns
            Debug.LogWarning($"Complex pattern with punctuation: value={number}, status=\"{message}\"");
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("SuperEditor/Debug String Interpolation Issue")]
        public static void DebugStringInterpolation()
        {
            Debug.Log("=== Testing String Interpolation Fix ===");
            TestProblematicString();
            TestStringInterpolationFix();
            Debug.Log("=== End String Interpolation Test ===");
        }
#endif
    }
}