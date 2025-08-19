using System;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Test file to demonstrate that string interpolation patterns are now correctly parsed
    /// in the SuperEditor C# parser. This should not show red squiggle errors.
    /// 
    /// Previously, the parser was treating interpolated strings like $"text: {variable}"
    /// as regular string literals instead of properly parsing them as interpolated strings.
    /// </summary>
    public class StringInterpolationTest
    {
        public void TestBasicInterpolation()
        {
            string gearId = "GEAR_123";
            string message = "test message";
            int statusCode = 404;
            
            // The original problematic pattern that should now work:
            string result1 = $"No parts found for equipped gearId: {gearId}";
            
            // Other patterns with colons before interpolations:
            string result2 = $"Error message: {message}";
            string result3 = $"Status code: {statusCode}";
            string result4 = $"Configuration setting: {gearId}";
            string result5 = $"Database connection: {message}";
        }
        
        public void TestComplexInterpolation()
        {
            string name = "TestUser";
            int count = 42;
            DateTime now = DateTime.Now;
            
            // Multiple interpolations in one string
            string result1 = $"User {name} has {count} items";
            string result2 = $"Time: {now}, User: {name}, Count: {count}";
            
            // Interpolation with format specifiers
            string result3 = $"Number: {count:D}";
            string result4 = $"Hex: {count:X}";
            string result5 = $"Currency: {count:C}";
            
            // Complex patterns with punctuation
            string result6 = $"Complex pattern: value={count}, status=\"{name}\"";
            string result7 = $"JSON-like: {{\"name\":\"{name}\", \"count\":{count}}}";
        }
        
        public void TestEdgeCases()
        {
            string value = "test";
            
            // Edge cases that might cause parsing issues
            string result1 = $"Path: C:\\Users\\{value}\\Documents";
            string result2 = $"URL: https://example.com/api/{value}";
            string result3 = $"SQL: SELECT * FROM table WHERE id = {value}";
            string result4 = $"Regex pattern: ^{value}\\d+$";
        }
        
        public void TestMethodCalls()
        {
            // Test that method calls within interpolations work correctly
            TestBasicInterpolation();
            TestComplexInterpolation();
            TestEdgeCases();
            
            Console.WriteLine("All string interpolation tests completed successfully!");
        }
    }
}