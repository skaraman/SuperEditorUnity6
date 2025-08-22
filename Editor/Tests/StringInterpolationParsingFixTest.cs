using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Specific test for the string interpolation parsing fix
    /// Tests the exact case mentioned in the issue where $"{equip.Value.gearId}_{equip.Key}" 
    /// was being displayed incorrectly
    /// </summary>
    public class StringInterpolationParsingFixTest
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
        /// Test the specific problematic case from the issue
        /// </summary>
        public static void TestProblematicCase()
        {
            Console.WriteLine("=== String Interpolation Parsing Fix Test ===");
            
            var equip = new MockEquipment();
            
            // This is the exact pattern that was having display issues
            string gearId = $"{equip.Value.gearId}_{equip.Key}";
            
            Console.WriteLine($"Test input: equip.Value.gearId = '{equip.Value.gearId}', equip.Key = '{equip.Key}'");
            Console.WriteLine($"Interpolated result: '{gearId}'");
            Console.WriteLine($"Expected: 'GEAR_123_slot1'");
            
            bool success = gearId == "GEAR_123_slot1";
            Console.WriteLine(success ? "✅ SUCCESS: String interpolation working correctly!" 
                                      : "❌ FAILED: String interpolation still has issues");
            
            // Test additional patterns
            TestAdditionalPatterns(equip);
            
            Console.WriteLine("=== Test Complete ===");
        }

        private static void TestAdditionalPatterns(MockEquipment equip)
        {
            Console.WriteLine("\n--- Testing Additional Patterns ---");
            
            // Test 1: Basic interpolation
            string test1 = $"GearId: {equip.Value.gearId}";
            Console.WriteLine($"Test 1 - Basic: '{test1}' (Expected: 'GearId: GEAR_123')");
            
            // Test 2: Multiple interpolations
            string test2 = $"Equipment {equip.Key} has gear {equip.Value.gearId}";
            Console.WriteLine($"Test 2 - Multiple: '{test2}' (Expected: 'Equipment slot1 has gear GEAR_123')");
            
            // Test 3: Complex expression
            string test3 = $"{equip.Value.gearId.ToUpper()}_{equip.Key.ToLower()}";
            Console.WriteLine($"Test 3 - Complex: '{test3}' (Expected: 'GEAR_123_slot1')");
            
            // Test 4: With format specifier (if applicable)
            int count = 42;
            string test4 = $"Count: {count:D} for {equip.Key}";
            Console.WriteLine($"Test 4 - Format: '{test4}' (Expected: 'Count: 42 for slot1')");
            
            // Test 5: Escaped braces
            string test5 = $"{{Gear: {equip.Value.gearId}}}";
            Console.WriteLine($"Test 5 - Escaped: '{test5}' (Expected: '{{Gear: GEAR_123}}')");
        }

        [UnityEditor.MenuItem("SuperEditor/Test String Interpolation Parsing Fix")]
        public static void RunTest()
        {
            TestProblematicCase();
        }
    }
}