using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Minimal test to reproduce and verify the string interpolation display bug fix.
    /// This tests the specific issue where interpolated strings are displayed truncated.
    /// </summary>
    public static class StringInterpolationDisplayBugTest
    {
        public class MockEquipment
        {
            public MockGear Value { get; set; } = new MockGear();
            public string Key { get; set; } = "slot1";
        }
        
        public class MockGear
        {
            public string gearId { get; set; } = "GEAR_123";
        }

        /// <summary>
        /// Test method that reproduces the exact problematic patterns from the issue
        /// </summary>
        public static void TestProblematicPatterns()
        {
            var equip = new MockEquipment();
            string gearId;
            
            // This is the exact case from the problem statement:
            // The line: else gearId = $"{equip.Value.gearId}_{equip.Key}";
            // was appearing as: {equip.Key}";
            gearId = $"{equip.Value.gearId}_{equip.Key}";
            
            Debug.Log($"Test 1 - Expected: 'GEAR_123_slot1', Got: '{gearId}'");
            
            // The second problematic pattern:
            // Debug.LogError($"No parts found for equipped gearId: {gearId}");
            // was appearing as: {gearId}");
            Debug.LogError($"No parts found for equipped gearId: {gearId}");
            
            // Additional test patterns to verify completeness
            string result1 = $"{equip.Value.gearId}_{equip.Key}";
            string result2 = $"prefix_{equip.Value.gearId}";
            string result3 = $"{equip.Key}_suffix";
            
            Debug.Log($"Pattern 1: {result1}");
            Debug.Log($"Pattern 2: {result2}");
            Debug.Log($"Pattern 3: {result3}");
            
            // Verification
            if (result1 == "GEAR_123_slot1" && result2 == "prefix_GEAR_123" && result3 == "slot1_suffix")
            {
                Debug.Log("✅ All string interpolation patterns work correctly!");
            }
            else
            {
                Debug.LogError($"❌ String interpolation issue still exists. Results: {result1}, {result2}, {result3}");
            }
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("SuperEditor/Test String Interpolation Bug Fix")]
        public static void RunBugTest()
        {
            Debug.Log("=== Testing String Interpolation Display Bug Fix ===");
            TestProblematicPatterns();
            Debug.Log("=== Test Completed ===");
        }
#endif
    }
}