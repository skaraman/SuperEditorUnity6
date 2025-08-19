using System;
using UnityEngine;
using UnityEditor;

namespace SuperEditor
{
    /// <summary>
    /// Demonstration script showing how to use the enhanced debugger interface
    /// in real Unity projects. This can be used as a reference for integrating
    /// debugging capabilities into existing code.
    /// </summary>
    public static class DebuggerDemo
    {
        /// <summary>
        /// Menu item to demonstrate the enhanced debugger interface functionality
        /// </summary>
        [MenuItem("SuperEditor/Demo/Run Debugger Demo")]
        public static void RunDebuggerDemo()
        {
            // Enable debugging if not already enabled
            if (!DebuggerInterface.IsDebuggingEnabled)
            {
                DebuggerInterface.EnableDebugging();
                Debug.Log("Debugging enabled for demo");
            }

            // Create a demo execution context
            var demoContext = new DemoExecutionContext
            {
                PlayerName = "TestPlayer",
                Health = 100,
                Score = 1500,
                IsGameActive = true,
                Position = new Vector3(10, 5, 20)
            };

            // Set up some context variables
            DebuggerInterface.SetContextVariable("demoStartTime", DateTime.Now);
            DebuggerInterface.SetContextVariable("demoVersion", "1.0");

            // Add a demo breakpoint
            string demoFile = "DemoScript.cs";
            int demoLine = 25;
            
            BreakpointManager.AddBreakpoint(demoFile, demoLine, "Health < 80");
            Debug.Log($"Demo breakpoint added at {demoFile}:{demoLine} with condition 'Health < 80'");

            // Simulate some execution states
            SimulateExecutionStates(demoContext, demoFile, demoLine);
        }

        /// <summary>
        /// Menu item to clear demo breakpoints and reset state
        /// </summary>
        [MenuItem("SuperEditor/Demo/Clear Demo Data")]
        public static void ClearDemoData()
        {
            // Remove all breakpoints
            var breakpoints = BreakpointManager.GetBreakpoints();
            foreach (var bp in breakpoints)
            {
                BreakpointManager.RemoveBreakpoint(bp.Id);
            }

            // Disable debugging
            if (DebuggerInterface.IsDebuggingEnabled)
            {
                DebuggerInterface.DisableDebugging();
            }

            Debug.Log("Demo data cleared and debugging disabled");
        }

        /// <summary>
        /// Menu item to show current debugging state
        /// </summary>
        [MenuItem("SuperEditor/Demo/Show Debug State")]
        public static void ShowDebugState()
        {
            var debugInfo = DebuggerInterface.GetCurrentDebugInfo();
            var context = DebuggerInterface.GetExecutionContext();
            var breakpoints = BreakpointManager.GetBreakpoints();

            Debug.Log("=== Current Debug State ===");
            Debug.Log($"Debugging Enabled: {debugInfo.IsDebugging}");
            Debug.Log($"Unity Playing: {debugInfo.IsPlaying}");
            Debug.Log($"Unity Paused: {debugInfo.IsPaused}");
            Debug.Log($"Context Variables: {context.Count}");
            Debug.Log($"Active Breakpoints: {breakpoints.Count}");

            if (context.Count > 0)
            {
                Debug.Log("--- Context Variables ---");
                foreach (var kvp in context)
                {
                    Debug.Log($"  {kvp.Key}: {kvp.Value}");
                }
            }

            if (breakpoints.Count > 0)
            {
                Debug.Log("--- Active Breakpoints ---");
                foreach (var bp in breakpoints)
                {
                    Debug.Log($"  {bp.FilePath}:{bp.LineNumber} (Enabled: {bp.IsEnabled}, Hits: {bp.HitCount})");
                    if (!string.IsNullOrEmpty(bp.Condition))
                    {
                        Debug.Log($"    Condition: {bp.Condition}");
                    }
                }
            }

            Debug.Log("=== End Debug State ===");
        }

        private static void SimulateExecutionStates(DemoExecutionContext context, string filePath, int lineNumber)
        {
            Debug.Log("Starting execution simulation...");

            // Simulate player taking damage
            context.Health = 90;
            DebuggerInterface.SetContextVariable("currentHealth", context.Health);
            
            // Check if we should pause (Health is still > 80, so condition not met)
            if (BreakpointManager.ShouldPauseAtLocation(filePath, lineNumber, context))
            {
                Debug.Log("Breakpoint condition met at Health = 90 (unexpected)");
            }
            else
            {
                Debug.Log("Breakpoint condition not met at Health = 90 (expected)");
            }

            // Simulate more damage
            context.Health = 70;
            DebuggerInterface.SetContextVariable("currentHealth", context.Health);

            // Now the condition should be met
            if (BreakpointManager.ShouldPauseAtLocation(filePath, lineNumber, context))
            {
                Debug.Log("Breakpoint condition met at Health = 70 - pausing execution");
                BreakpointManager.PauseAtBreakpoint(filePath, lineNumber, context);
            }

            // Demonstrate expression evaluation
            DebuggerInterface.SetContextVariable("x", "5");
            var result = DebuggerInterface.EvaluateExpression("x == 5");
            Debug.Log($"Expression 'x == 5' evaluated to: {result}");

            // Demonstrate force break
            EditorApplication.delayCall += () =>
            {
                Debug.Log("Demonstrating force break in 1 second...");
                DebuggerInterface.ForceBreak();
            };
        }

        /// <summary>
        /// Example of how to integrate debugging checks into actual game code
        /// </summary>
        public static void ExampleGameMethod(string fileName, int lineNumber)
        {
            // This is how you would integrate breakpoint checking into real game code
            var gameContext = new
            {
                playerName = "John",
                currentLevel = 3,
                score = 2500,
                isInCombat = true
            };

            // Check for breakpoints at this location
            BreakpointIntegration.CheckBreakpoint(fileName, lineNumber, gameContext);

            // Your actual game logic would continue here...
            Debug.Log("Game method executed");
        }

        /// <summary>
        /// Demo execution context for testing purposes
        /// </summary>
        private class DemoExecutionContext
        {
            public string PlayerName { get; set; }
            public int Health { get; set; }
            public int Score { get; set; }
            public bool IsGameActive { get; set; }
            public Vector3 Position { get; set; }
            public DateTime LastAction { get; set; } = DateTime.Now;
        }
    }
}