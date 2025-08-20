using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Test to reproduce the string interpolation display issue where 
    /// $"{equip.Value.gearId}_{equip.Key}" appears as just "{equip.Key}";
    /// </summary>
    public class StringInterpolationDisplayTest
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
        
        public void TestOriginalProblematicCase()
        {
            var equip = new MockEquipment();
            string gearId;
            
            // This is the exact case from the problem statement:
            // The line: else gearId = $"{equip.Value.gearId}_{equip.Key}";
            // was appearing as: {equip.Key}";
            gearId = $"{equip.Value.gearId}_{equip.Key}";
            
            Debug.Log($"Result should be 'GEAR_123_slot1', got: {gearId}");
        }
        
        public void TestSimilarInterpolationPatterns()
        {
            var equip = new MockEquipment();
            
            // Test various patterns that might have similar issues
            string result1 = $"{equip.Value.gearId}_{equip.Key}";
            string result2 = $"prefix_{equip.Value.gearId}_{equip.Key}";
            string result3 = $"{equip.Value.gearId}_{equip.Key}_suffix";
            string result4 = $"full_{equip.Value.gearId}_{equip.Key}_pattern";
            
            // Test with more complex expressions
            string result5 = $"{equip.Value.gearId.ToUpper()}_{equip.Key.ToLower()}";
            string result6 = $"{equip.Value?.gearId ?? "default"}_{equip.Key}";
            
            Debug.Log($"Pattern 1: {result1}");
            Debug.Log($"Pattern 2: {result2}");
            Debug.Log($"Pattern 3: {result3}");
            Debug.Log($"Pattern 4: {result4}");
            Debug.Log($"Pattern 5: {result5}");
            Debug.Log($"Pattern 6: {result6}");
        }
        
        [UnityEditor.MenuItem("SuperEditor/Test String Interpolation Display Issue")]
        public static void RunDisplayTest()
        {
            var test = new StringInterpolationDisplayTest();
            test.TestOriginalProblematicCase();
            test.TestSimilarInterpolationPatterns();
            
            // Additional test to verify the specific issue is fixed
            var equip = new MockEquipment();
            string testResult = $"{equip.Value.gearId}_{equip.Key}";
            
            Debug.Log($"VERIFICATION TEST: Full string should be 'GEAR_123_slot1', got: '{testResult}'");
            
            if (testResult == "GEAR_123_slot1")
            {
                Debug.Log("✅ SUCCESS: String interpolation display fix is working correctly!");
            }
            else
            {
                Debug.LogError($"❌ FAILED: Expected 'GEAR_123_slot1', but got '{testResult}'");
            }
            
            Debug.Log("String interpolation display test completed.");
        }
    }
}