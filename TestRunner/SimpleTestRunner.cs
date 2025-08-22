using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Simple test runner to execute test methods and report results
    /// </summary>
    public class SimpleTestRunner
    {
        private static int passedTests = 0;
        private static int failedTests = 0;
        private static List<string> failedTestDetails = new List<string>();

        public static void Main(string[] args)
        {
            Console.WriteLine("=== SuperEditor Test Runner ===");
            Console.WriteLine($"Running tests at: {DateTime.Now}");
            Console.WriteLine();

            // Run different types of tests
            RunStringInterpolationTests();
            RunBasicFunctionalityTests();

            // Report results
            Console.WriteLine();
            Console.WriteLine("=== Test Results ===");
            Console.WriteLine($"Passed: {passedTests}");
            Console.WriteLine($"Failed: {failedTests}");
            Console.WriteLine($"Total: {passedTests + failedTests}");
            
            if (failedTests > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Failed test details:");
                foreach (var failure in failedTestDetails)
                {
                    Console.WriteLine($"  - {failure}");
                }
            }

            Environment.Exit(failedTests > 0 ? 1 : 0);
        }

        private static void RunStringInterpolationTests()
        {
            Console.WriteLine("--- String Interpolation Tests ---");

            // Test basic string interpolation
            TestStringInterpolation("Basic interpolation", () =>
            {
                string name = "World";
                string result = $"Hello {name}";
                Assert(result == "Hello World", "Basic interpolation should work");
            });

            // Test complex interpolation patterns
            TestStringInterpolation("Complex interpolation", () =>
            {
                var equip = new { Key = "slot1", Value = new { gearId = "GEAR_123" } };
                string result = $"{equip.Value.gearId}_{equip.Key}";
                Assert(result == "GEAR_123_slot1", "Complex interpolation should work");
            });

            // Test interpolation with colon
            TestStringInterpolation("Interpolation with colon", () =>
            {
                string gearId = "GEAR_123";
                string result = $"No parts found for equipped gearId: {gearId}";
                Assert(result == "No parts found for equipped gearId: GEAR_123", "Interpolation with colon should work");
            });

            // Test empty interpolation
            TestStringInterpolation("Empty interpolation", () =>
            {
                string result = $"";
                Assert(result == "", "Empty interpolation should work");
            });

            // Test target-typed new
            TestStringInterpolation("Target-typed new", () =>
            {
                List<int> numbers = new() { 1, 2, 3 };
                Assert(numbers.Count == 3, "Target-typed new should work");
            });
        }

        private static void RunBasicFunctionalityTests()
        {
            Console.WriteLine();
            Console.WriteLine("--- Basic Functionality Tests ---");

            // Test that basic .NET features work
            TestBasicFunctionality("List operations", () =>
            {
                var list = new List<string> { "a", "b", "c" };
                Assert(list.Count == 3, "List should have 3 items");
                Assert(list[0] == "a", "First item should be 'a'");
            });

            // Test that LINQ works
            TestBasicFunctionality("LINQ operations", () =>
            {
                var numbers = new[] { 1, 2, 3, 4, 5 };
                var evens = numbers.Where(n => n % 2 == 0).ToArray();
                Assert(evens.Length == 2, "Should find 2 even numbers");
                Assert(evens[0] == 2 && evens[1] == 4, "Even numbers should be 2 and 4");
            });

            // Test reflection
            TestBasicFunctionality("Reflection", () =>
            {
                var type = typeof(SimpleTestRunner);
                var methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                Assert(methods.Length > 0, "Should find methods via reflection");
            });
        }

        private static void TestStringInterpolation(string testName, Action testAction)
        {
            RunTest($"StringInterpolation: {testName}", testAction);
        }

        private static void TestBasicFunctionality(string testName, Action testAction)
        {
            RunTest($"BasicFunctionality: {testName}", testAction);
        }

        private static void RunTest(string testName, Action testAction)
        {
            try
            {
                testAction();
                Console.WriteLine($"✅ PASS: {testName}");
                passedTests++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ FAIL: {testName}");
                Console.WriteLine($"   Error: {ex.Message}");
                failedTests++;
                failedTestDetails.Add($"{testName}: {ex.Message}");
            }
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }
    }
}