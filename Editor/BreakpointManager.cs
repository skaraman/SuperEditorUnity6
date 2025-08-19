using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace SuperEditor
{
    /// <summary>
    /// Manages breakpoints and provides debugging capabilities for SuperEditor.
    /// Allows pausing Unity execution at specific code locations and inspecting variables.
    /// </summary>
    [InitializeOnLoad]
    public static class BreakpointManager
    {
        private static readonly List<BreakpointInfo> activeBreakpoints = new List<BreakpointInfo>();
        private static readonly Dictionary<string, object> lastKnownVariables = new Dictionary<string, object>();
        private static bool isInitialized = false;

        // Events
        public static event Action<BreakpointInfo> BreakpointHit;
        public static event Action<bool> PauseStateChanged;

        static BreakpointManager()
        {
            Initialize();
        }

        private static void Initialize()
        {
            if (isInitialized) return;
            
            // Subscribe to editor events
            EditorApplication.pauseStateChanged += OnPauseStateChanged;
            
            // Subscribe to the enhanced debugger interface
            DebuggerInterface.ExecutionPaused += OnDebuggerPaused;
            DebuggerInterface.ExecutionResumed += OnDebuggerResumed;
            
            isInitialized = true;
        }

        /// <summary>
        /// Adds a breakpoint at the specified file and line
        /// </summary>
        public static void AddBreakpoint(string filePath, int lineNumber, string condition = null)
        {
            var breakpoint = new BreakpointInfo
            {
                FilePath = filePath,
                LineNumber = lineNumber,
                Condition = condition,
                IsEnabled = true,
                Id = Guid.NewGuid().ToString()
            };

            activeBreakpoints.Add(breakpoint);
            UnityEngine.Debug.Log($"Breakpoint added at {filePath}:{lineNumber}");
        }

        /// <summary>
        /// Removes a breakpoint by ID
        /// </summary>
        public static void RemoveBreakpoint(string breakpointId)
        {
            var breakpoint = activeBreakpoints.FirstOrDefault(bp => bp.Id == breakpointId);
            if (breakpoint != null)
            {
                activeBreakpoints.Remove(breakpoint);
                UnityEngine.Debug.Log($"Breakpoint removed from {breakpoint.FilePath}:{breakpoint.LineNumber}");
            }
        }

        /// <summary>
        /// Removes all breakpoints for a specific file
        /// </summary>
        public static void RemoveBreakpointsForFile(string filePath)
        {
            activeBreakpoints.RemoveAll(bp => bp.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets all active breakpoints
        /// </summary>
        public static IReadOnlyList<BreakpointInfo> GetBreakpoints()
        {
            return activeBreakpoints.AsReadOnly();
        }

        /// <summary>
        /// Checks if execution should pause at a specific location
        /// This method should be called from code analysis/execution points
        /// </summary>
        public static bool ShouldPauseAtLocation(string filePath, int lineNumber, object context = null)
        {
            var breakpoint = activeBreakpoints.FirstOrDefault(bp => 
                bp.IsEnabled && 
                bp.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase) && 
                bp.LineNumber == lineNumber);

            if (breakpoint == null) return false;

            // Check condition if specified
            if (!string.IsNullOrEmpty(breakpoint.Condition))
            {
                try
                {
                    // Simple condition evaluation - in a real implementation this would be more sophisticated
                    if (!EvaluateCondition(breakpoint.Condition, context))
                        return false;
                }
                catch (Exception ex)
                {
                    UnityEngine.Debug.LogWarning($"Breakpoint condition evaluation failed: {ex.Message}");
                }
            }

            return true;
        }

        /// <summary>
        /// Pauses execution at a breakpoint using the enhanced debugger interface
        /// </summary>
        public static void PauseAtBreakpoint(string filePath, int lineNumber, object context = null)
        {
            var breakpoint = activeBreakpoints.FirstOrDefault(bp => 
                bp.FilePath.Equals(filePath, StringComparison.OrdinalIgnoreCase) && 
                bp.LineNumber == lineNumber);

            if (breakpoint != null)
            {
                breakpoint.HitCount++;
                breakpoint.LastHit = DateTime.Now;
                
                // Use the enhanced debugger interface for better integration
                var reason = $"Breakpoint hit: {System.IO.Path.GetFileName(filePath)}:{lineNumber}";
                DebuggerInterface.PauseExecution(reason, context);
                
                // Trigger breakpoint hit event
                BreakpointHit?.Invoke(breakpoint);
            }
        }

        /// <summary>
        /// Resumes execution from a paused state using enhanced debugger interface
        /// </summary>
        public static void Resume()
        {
            DebuggerInterface.ResumeExecution();
        }

        /// <summary>
        /// Steps to the next line of execution using enhanced debugger interface
        /// </summary>
        public static void StepNext()
        {
            DebuggerInterface.StepNext();
        }

        /// <summary>
        /// Gets the current variable state from the enhanced debugger interface
        /// </summary>
        public static Dictionary<string, object> GetVariableState()
        {
            var debuggerContext = DebuggerInterface.GetExecutionContext();
            var combined = new Dictionary<string, object>(lastKnownVariables);
            
            // Add variables from the enhanced debugger interface
            foreach (var kvp in debuggerContext)
            {
                combined[kvp.Key] = kvp.Value;
            }
            
            return combined;
        }

        /// <summary>
        /// Forces a debug break using enhanced debugger interface
        /// </summary>
        public static void ForceBreak()
        {
            DebuggerInterface.ForceBreak();
        }

        private static void OnDebuggerPaused(DebugInfo debugInfo)
        {
            // Update our variable state when the debugger pauses
            foreach (var kvp in debugInfo.Variables)
            {
                lastKnownVariables[kvp.Key] = kvp.Value;
            }
            
            UnityEngine.Debug.Log($"Debugger paused: {debugInfo.Reason}");
        }

        private static void OnDebuggerResumed()
        {
            UnityEngine.Debug.Log("Debugger resumed");
        }

        private static void OnPauseStateChanged(PauseState pauseState)
        {
            bool isPaused = pauseState == PauseState.Paused;
            PauseStateChanged?.Invoke(isPaused);
            
            if (isPaused)
            {
                UnityEngine.Debug.Log("Editor paused - debugging mode active");
            }
            else
            {
                UnityEngine.Debug.Log("Editor resumed");
            }
        }

        private static bool EvaluateCondition(string condition, object context)
        {
            // Simple condition evaluation - could be enhanced with a proper expression evaluator
            // For now, just check simple equality conditions
            if (condition.Contains("=="))
            {
                var parts = condition.Split(new[] { "==" }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    var left = parts[0].Trim();
                    var right = parts[1].Trim().Trim('"', '\'');
                    
                    if (context != null)
                    {
                        var value = GetVariableValue(left, context);
                        return value?.ToString() == right;
                    }
                }
            }
            
            return true; // Default to true if condition can't be evaluated
        }

        private static void CaptureVariableState(object context)
        {
            lastKnownVariables.Clear();
            
            if (context == null) return;

            try
            {
                var type = context.GetType();
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var field in fields)
                {
                    try
                    {
                        if (IsDebuggerBrowsable(field))
                        {
                            var value = field.GetValue(context);
                            lastKnownVariables[field.Name] = value;
                        }
                    }
                    catch (Exception ex)
                    {
                        lastKnownVariables[field.Name] = $"Error: {ex.Message}";
                    }
                }

                foreach (var property in properties)
                {
                    try
                    {
                        if (property.CanRead && IsDebuggerBrowsable(property))
                        {
                            var value = property.GetValue(context);
                            lastKnownVariables[property.Name] = value;
                        }
                    }
                    catch (Exception ex)
                    {
                        lastKnownVariables[property.Name] = $"Error: {ex.Message}";
                    }
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning($"Failed to capture variable state: {ex.Message}");
            }
        }

        private static object GetVariableValue(string variableName, object context)
        {
            if (lastKnownVariables.TryGetValue(variableName, out var value))
                return value;

            try
            {
                var type = context.GetType();
                var field = type.GetField(variableName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null)
                    return field.GetValue(context);

                var property = type.GetProperty(variableName, BindingFlags.Public | BindingFlags.Instance);
                if (property != null && property.CanRead)
                    return property.GetValue(context);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning($"Failed to get variable value for '{variableName}': {ex.Message}");
            }

            return null;
        }

        private static bool IsDebuggerBrowsable(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<DebuggerBrowsableAttribute>();
            return attribute == null || attribute.State != DebuggerBrowsableState.Never;
        }
    }

    /// <summary>
    /// Information about a breakpoint
    /// </summary>
    [Serializable]
    public class BreakpointInfo
    {
        public string Id { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
        public string Condition { get; set; }
        public bool IsEnabled { get; set; }
        public int HitCount { get; set; }
        public DateTime LastHit { get; set; }

        public override string ToString()
        {
            return $"{FilePath}:{LineNumber} (Hits: {HitCount})";
        }
    }
}