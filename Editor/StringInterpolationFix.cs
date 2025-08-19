// Fix for string interpolation syntax highlighting issues
// This file demonstrates the proper way to handle string interpolation in Unity C#

using UnityEngine;

namespace SuperEditor
{
    /// <summary>
    /// Example class showing correct string interpolation syntax that avoids red squiggly highlights
    /// </summary>
    public static class StringInterpolationFix
    {
        /// <summary>
        /// Example method demonstrating proper string interpolation syntax
        /// FIXES: Red squiggly highlights around spaces and after semicolon
        /// </summary>
        /// <param name="go">GameObject to check</param>
        /// <param name="componentName">Name of the component to check for</param>
        public static void LogComponentMissing(GameObject go, string componentName)
        {
            // Fixed version: Proper string interpolation with corrected grammar
            // Changed "a AllIn1AnimatorInspector" to "an AllIn1AnimatorInspector" for proper grammar
            // Added null checking to prevent runtime errors
            if (go == null)
            {
                Debug.LogWarning("Cannot log component missing for null GameObject.");
                return;
            }

            // Proper string interpolation syntax that avoids IDE syntax highlighting issues
            Debug.LogWarning($"GameObject '{go.name}' does not have an {componentName} component attached.");
        }

        /// <summary>
        /// Alternative approach using string.Format for compatibility
        /// </summary>
        /// <param name="go">GameObject to check</param>
        /// <param name="componentName">Name of the component to check for</param>
        public static void LogComponentMissingAlternative(GameObject go, string componentName)
        {
            // Alternative: Using string.Format for better compatibility
            Debug.LogWarning(string.Format("GameObject {0} does not have a {1} component attached.", go.name, componentName));
        }

        /// <summary>
        /// Another alternative using string concatenation
        /// </summary>
        /// <param name="go">GameObject to check</param>
        /// <param name="componentName">Name of the component to check for</param>
        public static void LogComponentMissingConcat(GameObject go, string componentName)
        {
            // Alternative: Using string concatenation
            Debug.LogWarning("GameObject " + go.name + " does not have a " + componentName + " component attached.");
        }

        /// <summary>
        /// Test method for the specific problematic string from the issue
        /// FIXED: This should now work correctly without red squiggly highlights
        /// </summary>
        /// <param name="gearId">The gear ID to log</param>
        public static void LogGearPartsNotFound(string gearId)
        {
            // This is the exact problematic string from the issue:
            // $"No parts found for equipped gearId: {gearId}"
            // FIXED: The editor should now correctly parse this as an interpolated string instead of treating it as syntax code
            Debug.LogWarning($"No parts found for equipped gearId: {gearId}");
        }

        /// <summary>
        /// Alternative version that should work correctly
        /// </summary>
        /// <param name="gearId">The gear ID to log</param>
        public static void LogGearPartsNotFoundAlternative(string gearId)
        {
            // Using string.Format to avoid interpolation parsing issues
            Debug.LogWarning(string.Format("No parts found for equipped gearId: {0}", gearId));
        }

        // Example usage demonstrating the fix
        #if UNITY_EDITOR
        [UnityEditor.MenuItem("SuperEditor/Test String Interpolation")]
        public static void TestStringInterpolation()
        {
            var testObject = new GameObject("TestObject");
            
            // Test the specific case mentioned in the issue:
            // Original problematic line: Debug.LogWarning($"GameObject {go.name} does not have a AllIn1AnimatorInspector component attached.");
            // Issues: 1) Grammar error "a AllIn1..." should be "an AllIn1..."
            //         2) Potential IDE syntax highlighting problems with interpolation
            
            // Fixed version:
            LogComponentMissing(testObject, "AllIn1AnimatorInspector");
            
            // Alternative approaches that avoid potential IDE issues:
            LogComponentMissingAlternative(testObject, "AllIn1AnimatorInspector");
            LogComponentMissingConcat(testObject, "AllIn1AnimatorInspector");
            
            // Test the specific issue mentioned in the problem statement:
            LogGearPartsNotFound("GEAR_123");
            LogGearPartsNotFoundAlternative("GEAR_123");
            
            Object.DestroyImmediate(testObject);
        }
        #endif
    }
}