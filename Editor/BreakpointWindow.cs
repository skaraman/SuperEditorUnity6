using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace SuperEditor
{
    /// <summary>
    /// Editor window for managing breakpoints and viewing variable state during debugging
    /// </summary>
    public class BreakpointWindow : EditorWindow
    {
        private Vector2 breakpointScrollPosition;
        private Vector2 variableScrollPosition;
        private string newBreakpointFile = "";
        private int newBreakpointLine = 1;
        private string newBreakpointCondition = "";
        private bool showVariables = true;
        private bool autoRefreshVariables = true;
        private float lastVariableRefresh = 0f;
        private const float VARIABLE_REFRESH_INTERVAL = 0.5f; // Refresh every 0.5 seconds

        [MenuItem("Window/SuperEditor/Breakpoint Debugger")]
        public static void ShowWindow()
        {
            var window = GetWindow<BreakpointWindow>("Breakpoint Debugger");
            window.minSize = new Vector2(400, 300);
            window.Show();
        }

        private void OnEnable()
        {
            // Subscribe to breakpoint events
            BreakpointManager.BreakpointHit += OnBreakpointHit;
            BreakpointManager.PauseStateChanged += OnPauseStateChanged;
        }

        private void OnDisable()
        {
            // Unsubscribe from events
            BreakpointManager.BreakpointHit -= OnBreakpointHit;
            BreakpointManager.PauseStateChanged -= OnPauseStateChanged;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            DrawToolbar();
            EditorGUILayout.Space();
            
            DrawBreakpointSection();
            EditorGUILayout.Space();
            
            if (showVariables)
            {
                DrawVariableSection();
            }

            EditorGUILayout.EndVertical();
        }

        private void DrawToolbar()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

            // Play mode controls
            GUI.enabled = EditorApplication.isPlaying;
            
            if (EditorApplication.isPaused)
            {
                if (GUILayout.Button("Resume", EditorStyles.toolbarButton))
                {
                    BreakpointManager.Resume();
                }
                
                if (GUILayout.Button("Step", EditorStyles.toolbarButton))
                {
                    BreakpointManager.StepNext();
                }
            }
            else
            {
                if (GUILayout.Button("Pause", EditorStyles.toolbarButton))
                {
                    EditorApplication.isPaused = true;
                }
            }

            GUI.enabled = true;
            
            GUILayout.FlexibleSpace();

            // Force break button
            if (GUILayout.Button("Force Break", EditorStyles.toolbarButton))
            {
                BreakpointManager.ForceBreak();
            }

            // Show/hide variables toggle
            showVariables = GUILayout.Toggle(showVariables, "Variables", EditorStyles.toolbarButton);

            EditorGUILayout.EndHorizontal();
        }

        private void DrawBreakpointSection()
        {
            EditorGUILayout.LabelField("Breakpoints", EditorStyles.boldLabel);

            // Add new breakpoint section
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Add Breakpoint:", GUILayout.Width(100));
            newBreakpointFile = EditorGUILayout.TextField("File:", newBreakpointFile);
            newBreakpointLine = EditorGUILayout.IntField("Line:", newBreakpointLine, GUILayout.Width(80));
            
            if (GUILayout.Button("Add", GUILayout.Width(50)))
            {
                if (!string.IsNullOrEmpty(newBreakpointFile) && newBreakpointLine > 0)
                {
                    BreakpointManager.AddBreakpoint(newBreakpointFile, newBreakpointLine, 
                        string.IsNullOrEmpty(newBreakpointCondition) ? null : newBreakpointCondition);
                    newBreakpointFile = "";
                    newBreakpointLine = 1;
                    newBreakpointCondition = "";
                }
            }
            EditorGUILayout.EndHorizontal();

            // Optional condition
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Condition:", GUILayout.Width(100));
            newBreakpointCondition = EditorGUILayout.TextField(newBreakpointCondition);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            // Existing breakpoints list
            var breakpoints = BreakpointManager.GetBreakpoints();
            
            if (breakpoints.Count == 0)
            {
                EditorGUILayout.HelpBox("No breakpoints set. Add a breakpoint above to start debugging.", MessageType.Info);
            }
            else
            {
                breakpointScrollPosition = EditorGUILayout.BeginScrollView(breakpointScrollPosition, GUILayout.Height(150));

                for (int i = 0; i < breakpoints.Count; i++)
                {
                    var breakpoint = breakpoints[i];
                    
                    EditorGUILayout.BeginHorizontal();
                    
                    // Enable/disable toggle
                    bool wasEnabled = breakpoint.IsEnabled;
                    breakpoint.IsEnabled = EditorGUILayout.Toggle(breakpoint.IsEnabled, GUILayout.Width(20));
                    
                    // Breakpoint info
                    string displayText = $"{System.IO.Path.GetFileName(breakpoint.FilePath)}:{breakpoint.LineNumber}";
                    if (breakpoint.HitCount > 0)
                        displayText += $" (Hits: {breakpoint.HitCount})";
                    
                    EditorGUILayout.LabelField(displayText);
                    
                    // Condition display
                    if (!string.IsNullOrEmpty(breakpoint.Condition))
                    {
                        EditorGUILayout.LabelField($"if {breakpoint.Condition}", EditorStyles.miniLabel, GUILayout.Width(100));
                    }
                    
                    GUILayout.FlexibleSpace();
                    
                    // Remove button
                    if (GUILayout.Button("×", EditorStyles.miniButton, GUILayout.Width(20)))
                    {
                        BreakpointManager.RemoveBreakpoint(breakpoint.Id);
                        break; // Exit loop since we modified the collection
                    }
                    
                    EditorGUILayout.EndHorizontal();
                    
                    // Show condition details
                    if (!string.IsNullOrEmpty(breakpoint.Condition))
                    {
                        EditorGUI.indentLevel++;
                        EditorGUILayout.LabelField($"Condition: {breakpoint.Condition}", EditorStyles.helpBox);
                        EditorGUI.indentLevel--;
                    }
                }

                EditorGUILayout.EndScrollView();

                // Clear all button
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Clear All Breakpoints", GUILayout.Width(150)))
                {
                    foreach (var bp in breakpoints.ToList())
                    {
                        BreakpointManager.RemoveBreakpoint(bp.Id);
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawVariableSection()
        {
            EditorGUILayout.LabelField("Variables", EditorStyles.boldLabel);

            // Auto-refresh toggle
            EditorGUILayout.BeginHorizontal();
            autoRefreshVariables = EditorGUILayout.Toggle("Auto Refresh", autoRefreshVariables);
            
            if (!autoRefreshVariables && GUILayout.Button("Refresh Now", GUILayout.Width(100)))
            {
                // Manual refresh - in a real implementation this would capture current context
                Repaint();
            }
            EditorGUILayout.EndHorizontal();

            var variables = BreakpointManager.GetVariableState();
            
            if (variables.Count == 0)
            {
                EditorGUILayout.HelpBox("No variables captured. Variables will appear when execution is paused at a breakpoint.", MessageType.Info);
            }
            else
            {
                variableScrollPosition = EditorGUILayout.BeginScrollView(variableScrollPosition, GUILayout.MinHeight(100));

                foreach (var kvp in variables)
                {
                    EditorGUILayout.BeginHorizontal();
                    
                    EditorGUILayout.LabelField(kvp.Key, GUILayout.Width(120));
                    
                    string valueText = FormatVariableValue(kvp.Value);
                    EditorGUILayout.SelectableLabel(valueText, EditorStyles.textField);
                    
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndScrollView();
            }
        }

        private string FormatVariableValue(object value)
        {
            if (value == null)
                return "null";
            
            if (value is string str)
                return $"\"{str}\"";
            
            if (value is bool || value is int || value is float || value is double)
                return value.ToString();
            
            // For complex objects, show type and basic info
            var type = value.GetType();
            if (type.IsArray)
            {
                var array = value as Array;
                return $"{type.GetElementType().Name}[{array.Length}]";
            }
            
            return $"{type.Name}: {value}";
        }

        private void OnBreakpointHit(BreakpointInfo breakpoint)
        {
            // Bring window to front when breakpoint is hit
            Focus();
            Repaint();
            
            Debug.Log($"Breakpoint hit in window: {breakpoint.FilePath}:{breakpoint.LineNumber}");
        }

        private void OnPauseStateChanged(bool isPaused)
        {
            Repaint();
        }

        private void Update()
        {
            // Auto-refresh variables when paused
            if (autoRefreshVariables && EditorApplication.isPaused && Time.realtimeSinceStartup - lastVariableRefresh > VARIABLE_REFRESH_INTERVAL)
            {
                lastVariableRefresh = Time.realtimeSinceStartup;
                Repaint();
            }
        }
    }
}