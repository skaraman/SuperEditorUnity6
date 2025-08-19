using System;
using System.Collections.Generic;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Test file to demonstrate that target-typed new() expressions are now supported
    /// in the SuperEditor C# parser. This should not show red squiggle errors.
    /// 
    /// Target-typed new() was introduced in C# 9.0 and allows omitting the type
    /// when it can be inferred from the context.
    /// </summary>
    public class TargetTypedNewTestClass
    {
        // Field declarations with target-typed new()
        private List<Action> actions = new();
        private Dictionary<string, int> dictionary = new();
        private HashSet<string> stringSet = new();
        
        // With collection initializers
        private List<int> numbers = new() { 1, 2, 3, 4, 5 };
        private Dictionary<string, int> keyValuePairs = new() 
        { 
            ["first"] = 1,
            ["second"] = 2 
        };
        
        // Property with target-typed new()
        public List<object> Items { get; set; } = new();
        
        public void TestMethod()
        {
            // Assignment to existing variable
            List<string> stringList;
            stringList = new();
            
            // Method parameter
            ProcessList(new());
            
            // Return value
            List<int> result = CreateList();
        }
        
        private void ProcessList(List<string> list)
        {
            // Implementation
        }
        
        private List<int> CreateList()
        {
            // Return with target-typed new()
            return new();
        }
    }
}