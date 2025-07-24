// This file is included when Unity is not available in the build environment
// SuperEditor requires Unity 6000.1.9f1 to build and run properly

using System;
using System.Reflection;

// Assembly attributes moved to Properties/AssemblyInfo.cs to avoid duplicates
// [assembly: AssemblyTitle("SuperEditor")]
// [assembly: AssemblyDescription("Super Editor for Unity 6 - Enhanced Unity Editor functionality")]
// [assembly: AssemblyVersion("1.0.0.0")]
// [assembly: AssemblyFileVersion("1.0.0.0")]

namespace SuperEditor
{
    /// <summary>
    /// Placeholder class when Unity is not available.
    /// This assembly is not functional without Unity 6000.1.9f1 installed.
    /// 
    /// To use SuperEditor:
    /// 1. Install Unity 6000.1.9f1 or later
    /// 2. Import this package into a Unity project using the Package Manager
    /// 3. Use the .asmdef file for proper Unity integration
    /// 
    /// For Unity Package usage, this .csproj build is not required.
    /// </summary>
    public static class SuperEditorInfo
    {
        public const string RequiredUnityVersion = "6000.1.9f1";
        public const string PackageName = "com.supereditor.unity6";
        public const string Version = "1.0.0";
        
        public static string GetUsageInstructions()
        {
            return $@"
SuperEditor for Unity 6 (v{Version})

This package requires Unity {RequiredUnityVersion} or later to function.

USAGE:
1. Install Unity {RequiredUnityVersion}+
2. Open Unity and create/open a project
3. Import this package via Package Manager:
   - Window → Package Manager
   - + → Add package from disk
   - Select the package.json file from this folder

The .asmdef file (SuperEditor.asmdef) handles Unity integration automatically.
This standalone .csproj build is only for development/CI purposes.

For more information, see README.md
";
        }
    }
}

#if NO_UNITY
// Conditional compilation message - this code only compiles when Unity is not available
namespace SuperEditor.Build
{
    internal static class BuildInfo
    {
        // This message will appear in the compiled assembly
        public const string Message = "Built without Unity - Package is not functional. Use Unity Package Manager integration instead.";
    }
}
#endif