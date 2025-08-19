# Fix for Target-Typed new() Expressions

## Problem
The SuperEditor was showing red squiggle errors around the target-typed `new()` syntax, which is valid C# 9.0+ syntax. For example:

```csharp
private List<Action> actions = new(); // This was showing error
```

## Root Cause
The C# parser in SuperEditor has a custom grammar that expected a type name after the `new` keyword. The parser rule was:

```
"new" - (type - objectCreationExpression)
```

But target-typed `new()` expressions don't have an explicit type - the type is inferred from the context.

## Solution
Modified the `primaryExpression` grammar rule in `Editor/_b1/_bm2.cs` (line 1109) to support target-typed `new()` expressions by adding an alternative pattern:

**Before:**
```csharp
((_AJU47 | ".EXPECTEDTYPE") - (_AJU205 | _AJU24)) | _AJU25 | _AJU206
```

**After:**
```csharp
((_AJU47 | ".EXPECTEDTYPE") - (_AJU205 | _AJU24)) | _AJU25 | _AJU206 | (_AJU74 - new _bh2._BDU(_AJU232))
```

Where:
- `_AJU74` = arguments (like `()` or `(param1, param2)`)
- `_AJU232` = objectOrCollectionInitializer (like `{ }` or `{ prop = value }`)

This allows the parser to recognize patterns like:
- `new()` 
- `new(args)`
- `new() { prop = value }`
- `new(args) { prop = value }`

## Testing
1. **Compilation Test**: The fix allows C# code with target-typed `new()` to compile successfully
2. **Functionality Test**: All existing `new TypeName()` expressions continue to work
3. **Language Version Test**: Feature works with `<LangVersion>latest</LangVersion>` as configured in the project

## Examples Now Supported
```csharp
// Field declarations
private List<Action> actions = new();
private Dictionary<string, int> dict = new();

// With initializers
private List<int> numbers = new() { 1, 2, 3 };

// Assignment
List<string> items;
items = new();

// Method parameters
ProcessList(new());

// Return statements
return new();
```

The change is minimal, surgical, and preserves all existing functionality while adding support for the modern C# syntax.