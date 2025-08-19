# Breakpoint Debugging in SuperEditor Unity6

SuperEditor Unity6 now includes breakpoint debugging functionality that allows you to pause Unity execution at specific code locations and inspect variables, similar to Unity for Visual Studio Code.

## Features

- **Set Breakpoints**: Add breakpoints at specific file locations and line numbers
- **Conditional Breakpoints**: Set conditions that must be met for the breakpoint to trigger
- **Variable Inspection**: View local variables and their values when execution is paused
- **Execution Control**: Resume, step through code, or force breaks during debugging
- **Integration with Unity**: Seamlessly works with Unity's play mode and editor systems

## How to Use

### Opening the Breakpoint Debugger Window

1. In Unity, go to `Window > SuperEditor > Breakpoint Debugger`
2. The Breakpoint Debugger window will open, showing breakpoint management and variable inspection

### Setting Breakpoints

#### Method 1: Using the Breakpoint Window
1. Open the Breakpoint Debugger window
2. In the "Add Breakpoint" section:
   - Enter the file path (e.g., `Assets/Scripts/MyScript.cs`)
   - Enter the line number
   - Optionally add a condition (e.g., `x == 5`)
3. Click "Add" to create the breakpoint

#### Method 2: Using the Menu
1. Select a script file in the Project window
2. Right-click and choose `SuperEditor > Add Breakpoint Here`
3. A breakpoint will be added to line 1 of the selected script

### Managing Breakpoints

- **Enable/Disable**: Use the checkbox next to each breakpoint
- **Remove Individual**: Click the "×" button next to a breakpoint
- **Remove All**: Click "Clear All Breakpoints" at the bottom of the list

### Debugging Process

1. **Set Breakpoints**: Add breakpoints where you want to pause execution
2. **Enter Play Mode**: Start Unity's play mode
3. **Trigger Breakpoint**: When code execution reaches a breakpoint, Unity will pause
4. **Inspect Variables**: View captured variable values in the Variables section
5. **Control Execution**:
   - **Resume**: Continue normal execution
   - **Step**: Execute one step and pause again
   - **Force Break**: Pause execution immediately

### Conditional Breakpoints

Set conditions to control when breakpoints trigger:

- `x == 5` - Pause when variable x equals 5
- `playerHealth < 50` - Pause when player health is low
- `isGameOver == true` - Pause when game over condition is met

## API Reference

### BreakpointManager

Static class that manages all breakpoint functionality:

```csharp
// Add a breakpoint
BreakpointManager.AddBreakpoint("Assets/Scripts/Player.cs", 45);

// Add a conditional breakpoint  
BreakpointManager.AddBreakpoint("Assets/Scripts/Player.cs", 45, "health < 50");

// Remove a breakpoint
BreakpointManager.RemoveBreakpoint(breakpointId);

// Check if execution should pause
bool shouldPause = BreakpointManager.ShouldPauseAtLocation(filePath, lineNumber);

// Pause at a breakpoint with context
BreakpointManager.PauseAtBreakpoint(filePath, lineNumber, executionContext);

// Resume execution
BreakpointManager.Resume();

// Step to next line
BreakpointManager.StepNext();

// Force a debug break
BreakpointManager.ForceBreak();
```

### BreakpointIntegration

Provides integration with existing code analysis:

```csharp
// Check for breakpoints in code execution
BreakpointIntegration.CheckBreakpoint(filePath, lineNumber, context);

// Inject breakpoint checks into source code
string modifiedCode = BreakpointIntegration.InjectBreakpointCheck(sourceCode, filePath, lineNumber);
```

## Integration with SuperEditor

The breakpoint system integrates with SuperEditor's existing code analysis and execution monitoring:

1. **Automatic Detection**: Breakpoints are automatically checked during code execution
2. **Variable Capture**: Uses existing debugging infrastructure to capture variable states
3. **Editor Integration**: Works seamlessly with Unity's editor play mode system
4. **Code Analysis**: Leverages SuperEditor's parsing and analysis capabilities

## Technical Details

### How It Works

1. **Breakpoint Storage**: Breakpoints are stored in memory and persist during editor sessions
2. **Execution Monitoring**: The system hooks into Unity's update loop and play mode changes
3. **Variable Inspection**: Uses reflection to capture and display variable values
4. **Unity Integration**: Leverages Unity's `EditorApplication.isPaused` for pause control

### Limitations

- Variables are captured when breakpoints are hit, not continuously
- Complex object inspection is simplified for display
- Conditional breakpoint evaluation uses basic string parsing
- Integration with actual script execution requires additional setup

### Future Enhancements

- Real-time variable watching
- Advanced conditional expression evaluation
- Call stack inspection
- Memory and performance profiling
- Integration with external debuggers

## Troubleshooting

### Breakpoints Not Triggering

1. Ensure Unity is in play mode
2. Check that breakpoints are enabled (checkbox checked)
3. Verify the file path is correct
4. Make sure the line number corresponds to executable code

### Variables Not Showing

1. Variables appear when execution is paused at a breakpoint
2. Only accessible fields and properties are captured
3. Static variables may require special handling

### Performance Impact

The breakpoint system is designed to have minimal performance impact:
- Only active when breakpoints are set
- Efficient checking using hash maps and indexes
- Variables captured only when paused, not continuously

## Support

For issues or questions about the breakpoint debugging system:

1. Check the Unity console for error messages
2. Ensure SuperEditor is properly installed
3. Verify Unity 6 compatibility
4. Report issues on the SuperEditor GitHub repository