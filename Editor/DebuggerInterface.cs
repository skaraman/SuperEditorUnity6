using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace SuperEditor
{
    /// <summary>
    /// Unified debugger interface that provides comprehensive access to Unity's debugging capabilities
    /// and integrates with SuperEditor's breakpoint system to solve accessibility and functionality issues.
    /// </summary>
    [InitializeOnLoad]
    public static class DebuggerInterface
    {
        private static bool isInitialized = false;
        private static bool isDebuggingEnabled = false;
        private static readonly Dictionary<string, object> currentExecutionContext = new Dictionary<string, object>();
        
        // Events for debugging state changes
        public static event Action<bool> DebuggingStateChanged;
        public static event Action<DebugInfo> ExecutionPaused;
        public static event Action ExecutionResumed;

        static DebuggerInterface()
        {
            Initialize();
        }

        private static void Initialize()
        {
            if (isInitialized) return;

            // Subscribe to Unity's debugging events
            EditorApplication.pauseStateChanged += OnUnityPauseStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
            
            // Initialize debugging capabilities
            InitializeDebugHooks();
            
            isInitialized = true;
            Debug.Log("SuperEditor Debugger Interface initialized");
        }

        /// <summary>
        /// Enables debugging mode with enhanced Unity integration
        /// </summary>
        public static void EnableDebugging()
        {
            if (isDebuggingEnabled) return;
            
            isDebuggingEnabled = true;
            
            // Set up enhanced debugging hooks
            SetupDebugHooks();
            
            DebuggingStateChanged?.Invoke(true);
            Debug.Log("SuperEditor Debugging Enabled - Enhanced Unity integration active");
        }

        /// <summary>
        /// Disables debugging mode and cleans up resources
        /// </summary>
        public static void DisableDebugging()
        {
            if (!isDebuggingEnabled) return;
            
            isDebuggingEnabled = false;
            CleanupDebugHooks();
            currentExecutionContext.Clear();
            
            DebuggingStateChanged?.Invoke(false);
            Debug.Log("SuperEditor Debugging Disabled");
        }

        /// <summary>
        /// Gets the current debugging state
        /// </summary>
        public static bool IsDebuggingEnabled => isDebuggingEnabled;

        /// <summary>
        /// Pauses Unity execution with detailed context information
        /// </summary>
        public static void PauseExecution(string reason = "Manual pause", object context = null)
        {
            if (!EditorApplication.isPlaying) return;

            EditorApplication.isPaused = true;
            
            var debugInfo = CaptureDebugInfo(reason, context);
            ExecutionPaused?.Invoke(debugInfo);
            
            Debug.Log($"Execution paused: {reason}");
        }

        /// <summary>
        /// Resumes Unity execution
        /// </summary>
        public static void ResumeExecution()
        {
            if (!EditorApplication.isPaused) return;

            EditorApplication.isPaused = false;
            currentExecutionContext.Clear();
            
            ExecutionResumed?.Invoke();
            Debug.Log("Execution resumed");
        }

        /// <summary>
        /// Steps to the next line of execution
        /// </summary>
        public static void StepNext()
        {
            if (!EditorApplication.isPaused) return;

            EditorApplication.Step();
            Debug.Log("Stepped to next execution point");
        }

        /// <summary>
        /// Forces an immediate debug break
        /// </summary>
        public static void ForceBreak()
        {
            UnityEngine.Debug.Break();
            PauseExecution("Force break", null);
        }

        /// <summary>
        /// Evaluates an expression in the current debugging context
        /// </summary>
        public static object EvaluateExpression(string expression)
        {
            try
            {
                // Simple expression evaluation - can be enhanced with a proper parser
                if (currentExecutionContext.TryGetValue(expression, out var value))
                {
                    return value;
                }

                // Try to evaluate as a simple comparison
                if (expression.Contains("=="))
                {
                    var parts = expression.Split(new[] { "==" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        var left = GetValueFromContext(parts[0].Trim());
                        var right = parts[1].Trim().Trim('"', '\'');
                        return object.Equals(left?.ToString(), right);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to evaluate expression '{expression}': {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets current execution context variables
        /// </summary>
        public static IReadOnlyDictionary<string, object> GetExecutionContext()
        {
            return currentExecutionContext;
        }

        /// <summary>
        /// Sets a variable in the current execution context
        /// </summary>
        public static void SetContextVariable(string name, object value)
        {
            currentExecutionContext[name] = value;
        }

        /// <summary>
        /// Gets detailed information about the current debugging state
        /// </summary>
        public static DebugInfo GetCurrentDebugInfo()
        {
            return new DebugInfo
            {
                IsDebugging = isDebuggingEnabled,
                IsPaused = EditorApplication.isPaused,
                IsPlaying = EditorApplication.isPlaying,
                Variables = new Dictionary<string, object>(currentExecutionContext),
                Timestamp = DateTime.Now
            };
        }

        private static void InitializeDebugHooks()
        {
            // Set up initial hooks for debugging
            EditorApplication.update += DebugUpdate;
        }

        private static void SetupDebugHooks()
        {
            // Enhanced debug hooks when debugging is enabled
            // This would integrate with actual code execution in a full implementation
        }

        private static void CleanupDebugHooks()
        {
            // Clean up debugging hooks when disabled
            if (EditorApplication.isPaused)
            {
                EditorApplication.isPaused = false;
            }
        }

        private static void DebugUpdate()
        {
            if (!isDebuggingEnabled || !EditorApplication.isPlaying) return;

            // Check for any pending debug operations
            // In a full implementation, this would monitor execution state
        }

        private static void OnUnityPauseStateChanged(PauseState pauseState)
        {
            bool isPaused = pauseState == PauseState.Paused;
            
            if (isPaused && isDebuggingEnabled)
            {
                var debugInfo = CaptureDebugInfo("Unity paused", null);
                ExecutionPaused?.Invoke(debugInfo);
            }
            else if (!isPaused)
            {
                ExecutionResumed?.Invoke();
            }
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    if (isDebuggingEnabled)
                    {
                        Debug.Log("Play mode entered - Debugging active");
                    }
                    break;
                    
                case PlayModeStateChange.ExitingPlayMode:
                    if (isDebuggingEnabled)
                    {
                        currentExecutionContext.Clear();
                        Debug.Log("Play mode exiting - Debugging context cleared");
                    }
                    break;
            }
        }

        private static DebugInfo CaptureDebugInfo(string reason, object context)
        {
            var debugInfo = new DebugInfo
            {
                Reason = reason,
                IsDebugging = isDebuggingEnabled,
                IsPaused = EditorApplication.isPaused,
                IsPlaying = EditorApplication.isPlaying,
                Variables = new Dictionary<string, object>(),
                Timestamp = DateTime.Now
            };

            // Capture context variables if provided
            if (context != null)
            {
                CaptureContextVariables(context, debugInfo.Variables);
            }

            // Include current execution context
            foreach (var kvp in currentExecutionContext)
            {
                debugInfo.Variables[kvp.Key] = kvp.Value;
            }

            return debugInfo;
        }

        private static void CaptureContextVariables(object context, Dictionary<string, object> variables)
        {
            try
            {
                var type = context.GetType();
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var field in fields)
                {
                    try
                    {
                        var value = field.GetValue(context);
                        variables[field.Name] = value;
                        currentExecutionContext[field.Name] = value;
                    }
                    catch (Exception ex)
                    {
                        variables[field.Name] = $"Error: {ex.Message}";
                    }
                }

                foreach (var property in properties)
                {
                    try
                    {
                        if (property.CanRead)
                        {
                            var value = property.GetValue(context);
                            variables[property.Name] = value;
                            currentExecutionContext[property.Name] = value;
                        }
                    }
                    catch (Exception ex)
                    {
                        variables[property.Name] = $"Error: {ex.Message}";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to capture context variables: {ex.Message}");
            }
        }

        private static object GetValueFromContext(string variableName)
        {
            return currentExecutionContext.TryGetValue(variableName, out var value) ? value : null;
        }
    }

    /// <summary>
    /// Contains comprehensive debugging information
    /// </summary>
    public class DebugInfo
    {
        public string Reason { get; set; }
        public bool IsDebugging { get; set; }
        public bool IsPaused { get; set; }
        public bool IsPlaying { get; set; }
        public Dictionary<string, object> Variables { get; set; }
        public DateTime Timestamp { get; set; }

        public DebugInfo()
        {
            Variables = new Dictionary<string, object>();
        }

        public override string ToString()
        {
            return $"Debug Info: {Reason} - Playing: {IsPlaying}, Paused: {IsPaused}, Variables: {Variables.Count}";
        }
    }
}