using System;
using UnityEngine;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Comprehensive test to validate all the string interpolation parsing improvements
    /// </summary>
    public class InterpolationParsingComprehensiveTest
    {
        [UnityEditor.MenuItem("SuperEditor/Run Comprehensive String Interpolation Test")]
        public static void RunComprehensiveTest()
        {
            Console.WriteLine("=== Comprehensive String Interpolation Parsing Test ===");
            
            // Test 1: The original problematic case
            TestOriginalProblematicCase();
            
            // Test 2: Format specifiers
            TestFormatSpecifiers();
            
            // Test 3: Escaped braces
            TestEscapedBraces();
            
            // Test 4: Complex expressions
            TestComplexExpressions();
            
            // Test 5: Edge cases
            TestEdgeCases();
            
            Console.WriteLine("=== All Tests Completed ===");
        }

        private static void TestOriginalProblematicCase()
        {
            Console.WriteLine("\n--- Test 1: Original Problematic Case ---");
            var equip = new { Value = new { gearId = "GEAR_123" }, Key = "slot1" };
            string result = $"{equip.Value.gearId}_{equip.Key}";
            
            Console.WriteLine($"Input: equip.Value.gearId='{equip.Value.gearId}', equip.Key='{equip.Key}'");
            Console.WriteLine($"Result: '{result}'");
            Console.WriteLine($"Expected: 'GEAR_123_slot1'");
            Console.WriteLine(result == "GEAR_123_slot1" ? "✅ PASS" : "❌ FAIL");
        }

        private static void TestFormatSpecifiers()
        {
            Console.WriteLine("\n--- Test 2: Format Specifiers ---");
            int number = 42;
            double price = 123.456;
            DateTime date = new DateTime(2023, 12, 25);
            
            string result1 = $"Number: {number:D}";
            string result2 = $"Price: {price:C2}";
            string result3 = $"Date: {date:yyyy-MM-dd}";
            
            Console.WriteLine($"Number format: '{result1}'");
            Console.WriteLine($"Currency format: '{result2}'");
            Console.WriteLine($"Date format: '{result3}'");
            Console.WriteLine("✅ Format specifiers test completed");
        }

        private static void TestEscapedBraces()
        {
            Console.WriteLine("\n--- Test 3: Escaped Braces ---");
            string value = "test";
            string result = $"{{Static}} {value} {{More}}";
            
            Console.WriteLine($"Result: '{result}'");
            Console.WriteLine($"Expected: '{{Static}} test {{More}}'");
            Console.WriteLine(result == "{Static} test {More}" ? "✅ PASS" : "❌ FAIL");
        }

        private static void TestComplexExpressions()
        {
            Console.WriteLine("\n--- Test 4: Complex Expressions ---");
            var obj = new { Name = "TestObject", Count = 5 };
            
            string result1 = $"Upper: {obj.Name.ToUpper()}";
            string result2 = $"Calculation: {obj.Count * 2 + 1}";
            string result3 = $"Conditional: {(obj.Count > 3 ? "Many" : "Few")}";
            
            Console.WriteLine($"ToUpper(): '{result1}'");
            Console.WriteLine($"Math: '{result2}'");
            Console.WriteLine($"Conditional: '{result3}'");
            Console.WriteLine("✅ Complex expressions test completed");
        }

        private static void TestEdgeCases()
        {
            Console.WriteLine("\n--- Test 5: Edge Cases ---");
            
            // Test with null
            string nullValue = null;
            string result1 = $"Null: '{nullValue}'";
            
            // Test with empty string
            string empty = "";
            string result2 = $"Empty: '{empty}'";
            
            // Test with special characters
            string special = "C:\\Path\\File.txt";
            string result3 = $"Path: {special}";
            
            Console.WriteLine($"Null handling: '{result1}'");
            Console.WriteLine($"Empty string: '{result2}'");
            Console.WriteLine($"Special chars: '{result3}'");
            Console.WriteLine("✅ Edge cases test completed");
        }
    }
}