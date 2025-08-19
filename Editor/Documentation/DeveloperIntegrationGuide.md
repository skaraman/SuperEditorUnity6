# Developer Integration Guide

This guide shows how to integrate the enhanced debugger interface into your Unity projects.

## Quick Start

1. **Open the Debugger**: Use `Window > SuperEditor > Debugger Interface`
2. **Enable Debugging**: Click "Enable Debug" (done automatically when window opens)
3. **Add Breakpoints**: Use the interface or menu items
4. **Enter Play Mode**: Your breakpoints will now work!

## Integration into Existing Code

### Adding Breakpoint Checks to Your Scripts

```csharp
using SuperEditor;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public string playerName = "Player";
    
    void Update()
    {
        // Add this line to enable breakpoint checking at this location
        BreakpointIntegration.CheckBreakpoint("PlayerController.cs", 12, this);
        
        // Your existing game logic continues...
        if (health <= 0)
        {
            // Another breakpoint check
            BreakpointIntegration.CheckBreakpoint("PlayerController.cs", 17, this);
            GameOver();
        }
    }
}
```

### Manual Debugging Controls

```csharp
// Enable/disable debugging programmatically
if (!DebuggerInterface.IsDebuggingEnabled)
{
    DebuggerInterface.EnableDebugging();
}

// Force a break at any time
DebuggerInterface.ForceBreak();

// Pause with custom context
var debugContext = new { playerHealth = health, currentLevel = 3 };
DebuggerInterface.PauseExecution("Custom pause", debugContext);
```

### Adding Conditional Breakpoints Programmatically

```csharp
// Add a breakpoint that only triggers when health is low
BreakpointManager.AddBreakpoint("PlayerController.cs", 25, "health < 20");

// Add a breakpoint for specific player names
BreakpointManager.AddBreakpoint("PlayerController.cs", 30, "playerName == \"TestPlayer\"");
```

## Menu Items Available

- `Window > SuperEditor > Debugger Interface` - Main debugger window
- `SuperEditor > Open Debugger Interface` - Quick access
- `SuperEditor > Add Breakpoint Here` - Add breakpoint to selected script  
- `SuperEditor > Test Breakpoint` - Test functionality
- `SuperEditor > Demo > Run Debugger Demo` - See demo in action
- `SuperEditor > Demo > Show Debug State` - View current state
- `SuperEditor > Demo > Clear Demo Data` - Clean up demo

## Advanced Usage

### Custom Execution Context

```csharp
public class GameManager : MonoBehaviour
{
    void CheckWinCondition()
    {
        var context = new
        {
            playerScore = GetPlayerScore(),
            timeRemaining = GetTimeRemaining(),
            enemiesDefeated = GetEnemiesDefeated(),
            powerUpsCollected = GetPowerUpsCollected()
        };
        
        BreakpointIntegration.CheckBreakpoint("GameManager.cs", 45, context);
        
        // Your win condition logic...
    }
}
```

### Event-Driven Debugging

```csharp
void Start()
{
    // Subscribe to debugging events
    DebuggerInterface.ExecutionPaused += OnExecutionPaused;
    DebuggerInterface.ExecutionResumed += OnExecutionResumed;
}

void OnExecutionPaused(DebugInfo debugInfo)
{
    Debug.Log($"Game paused for debugging: {debugInfo.Reason}");
    // Optionally pause your game logic too
    Time.timeScale = 0;
}

void OnExecutionResumed()
{
    Debug.Log("Game resumed from debugging");
    // Resume your game logic
    Time.timeScale = 1;
}
```

### Expression Evaluation

```csharp
// Set variables in debugging context
DebuggerInterface.SetContextVariable("currentWave", waveNumber);
DebuggerInterface.SetContextVariable("bossHealth", boss.health);

// Evaluate expressions
bool shouldPause = (bool)DebuggerInterface.EvaluateExpression("currentWave == 5");
if (shouldPause)
{
    DebuggerInterface.PauseExecution("Boss wave reached");
}
```

## Best Practices

1. **Remove breakpoint checks in production builds** using preprocessor directives:
```csharp
#if UNITY_EDITOR
BreakpointIntegration.CheckBreakpoint("Script.cs", 10, this);
#endif
```

2. **Use meaningful context objects** that include relevant game state

3. **Set up conditional breakpoints** for specific scenarios you want to debug

4. **Use the demo functionality** to understand how the system works

5. **Subscribe to events** to coordinate debugging with your game logic

## Troubleshooting

- **Breakpoints not triggering**: Make sure debugging is enabled and you're in play mode
- **Variables not showing**: Ensure your context objects have public properties or fields
- **Performance concerns**: Breakpoint checks are lightweight, but remove them in production builds
- **Menu items not visible**: Make sure SuperEditor is properly installed

## Example: Complete Integration

```csharp
using UnityEngine;
#if UNITY_EDITOR
using SuperEditor;
#endif

public class CompleteExample : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 5f;
    
    void Start()
    {
#if UNITY_EDITOR
        // Enable debugging for this component
        if (!DebuggerInterface.IsDebuggingEnabled)
        {
            DebuggerInterface.EnableDebugging();
        }
        
        // Add conditional breakpoints
        BreakpointManager.AddBreakpoint("CompleteExample.cs", 25, "health < 50");
        BreakpointManager.AddBreakpoint("CompleteExample.cs", 30, "speed > 10");
#endif
    }
    
    void Update()
    {
#if UNITY_EDITOR
        // Check for breakpoints with current state
        var context = new { health, speed, position = transform.position };
        BreakpointIntegration.CheckBreakpoint("CompleteExample.cs", 35, context);
#endif
        
        // Your game logic here...
        MovePlayer();
        CheckHealth();
    }
    
    void MovePlayer()
    {
        // Movement logic...
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F1))
        {
            DebuggerInterface.ForceBreak(); // Emergency debug break
        }
#endif
    }
    
    void CheckHealth()
    {
        if (health <= 0)
        {
#if UNITY_EDITOR
            DebuggerInterface.PauseExecution("Player died", this);
#endif
            // Handle player death...
        }
    }
}
```

This integration provides full debugging capabilities while maintaining clean production builds.