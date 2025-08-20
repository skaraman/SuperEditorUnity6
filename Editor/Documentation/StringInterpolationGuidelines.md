# String Interpolation Guidelines for SuperEditor Unity6

## Common String Interpolation Issues and Solutions

This document addresses common issues with string interpolation that can cause "red squiggly highlights" in IDE/editor environments when working with Unity C# code.

### Problem: Red Squiggly Highlights in String Interpolation

#### Symptoms
- Red underlines appear around spaces in interpolated strings
- Syntax highlighting errors after semicolons
- IDE shows warnings or errors that don't appear during compilation

#### Common Causes and Solutions

##### 1. Missing Using Directives
**Problem:** IDE can't resolve Unity types
```csharp
// ❌ This might cause syntax highlighting issues
Debug.LogWarning($"GameObject {go.name} does not have a component attached.");
```

**Solution:** Ensure proper using directives
```csharp
using UnityEngine;

// ✅ Correct - with proper using directive
Debug.LogWarning($"GameObject {go.name} does not have a component attached.");
```

##### 2. C# Language Version Compatibility
**Problem:** Older C# language versions don't support string interpolation
**Solution:** Ensure project uses C# 6.0 or later (current project uses `<LangVersion>latest</LangVersion>`)

##### 3. Parser Bug with String Interpolation Display Truncation
**Problem:** SuperEditor's custom C# parser was incorrectly displaying interpolated strings, showing only partial content
```csharp
// ❌ This line: else gearId = $"{equip.Value.gearId}_{equip.Key}";
// Was displayed as: {equip.Key}";
// Missing the first part of the interpolated string
```

**Root Cause:** The `ScanInterpolatedStringLiteral` method was using the wrong starting position when creating the final token. It used the position after the last interpolation instead of the original starting position of the entire interpolated string.

**Solution:** Modified the `ScanInterpolatedStringLiteral` method in `Editor/_b1/_bd5.cs` to preserve the original starting position and use it for the final token creation.

```csharp
// ✅ Now correctly displays full interpolated string
else gearId = $"{equip.Value.gearId}_{equip.Key}";
// Properly shows: $"{equip.Value.gearId}_{equip.Key}"
Debug.LogWarning($"Error message: {ex.Message}");
Debug.LogWarning($"Status code: {statusCode}");
```

##### 4. Parser Bug with String Interpolation Display Truncation
**Problem:** SuperEditor's custom C# parser was incorrectly displaying interpolated strings, showing only partial content
```csharp
// ❌ This line: else gearId = $"{equip.Value.gearId}_{equip.Key}";
// Was displayed as: {equip.Key}";
// Missing the first part of the interpolated string
```

**Root Cause:** The `ScanInterpolatedStringLiteral` method was using the wrong starting position when creating the final token. It used the position after the last interpolation instead of the original starting position of the entire interpolated string.

**Solution:** Modified the `ScanInterpolatedStringLiteral` method in `Editor/_b1/_bd5.cs` to preserve the original starting position and use it for the final token creation.

```csharp
// ✅ Now correctly displays full interpolated string
else gearId = $"{equip.Value.gearId}_{equip.Key}";
// Properly shows: $"{equip.Value.gearId}_{equip.Key}"
```

##### 5. Special Characters in Interpolated Strings
**Problem:** Certain characters can cause parsing issues
```csharp
// ❌ Potential issue with article "a" before component name
Debug.LogWarning($"GameObject {go.name} does not have a AllIn1AnimatorInspector component attached.");
```

**Solution:** Use proper article grammar or escape characters
```csharp
// ✅ Corrected grammar
Debug.LogWarning($"GameObject {go.name} does not have an AllIn1AnimatorInspector component attached.");

// ✅ Alternative: More explicit formatting
Debug.LogWarning($"GameObject '{go.name}' does not have a AllIn1AnimatorInspector component attached.");
```

##### 6. Alternative Approaches for Compatibility

If string interpolation continues to cause issues, use these alternatives:

```csharp
// Alternative 1: string.Format (most compatible)
Debug.LogWarning(string.Format("GameObject {0} does not have a {1} component attached.", go.name, "AllIn1AnimatorInspector"));

// Alternative 2: String concatenation
Debug.LogWarning("GameObject " + go.name + " does not have a AllIn1AnimatorInspector component attached.");

// Alternative 3: StringBuilder for complex cases
var sb = new System.Text.StringBuilder();
sb.Append("GameObject ");
sb.Append(go.name);
sb.Append(" does not have a AllIn1AnimatorInspector component attached.");
Debug.LogWarning(sb.ToString());
```

### Best Practices

1. **Always include proper using directives**
2. **Use latest C# language version when possible**
3. **Test string interpolation in actual Unity environment**
4. **Use string.Format as fallback for compatibility**
5. **Validate grammar and article usage (a vs an)**

### Unity-Specific Considerations

- String interpolation works in Unity 2018.2+ with .NET Standard 2.0
- SuperEditor Unity6 targets .NET Standard 2.1 with latest C# features
- IDE syntax highlighting may lag behind actual compilation capabilities

### Troubleshooting Steps

1. Clean and rebuild the project
2. Restart the IDE/editor
3. Check Unity version compatibility
4. Verify C# language version in project settings
5. Test with alternative string formatting approaches