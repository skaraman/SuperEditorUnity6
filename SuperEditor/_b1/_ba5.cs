using System;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000056 RID: 86
    [CustomEditor(typeof(MonoScript))]
    internal class _ba5 : _bh3
    {
        // Token: 0x06000274 RID: 628 RVA: 0x00021900 File Offset: 0x0001FB00
        public override void OnInspectorGUI()
        {
            bool flag = base.targets.Length == 1;
            bool flag2 = false;
            bool flag3 = flag;
            if (flag3)
            {
                string assetPath = AssetDatabase.GetAssetPath(base.target);
                string assemblyNameFromScriptPath = CompilationPipeline.GetAssemblyNameFromScriptPath(assetPath);
                bool flag4 = assemblyNameFromScriptPath != null;
                bool flag5 = flag4;
                if (flag5)
                {
                    GUILayout.Label("Assembly Information", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
                    EditorGUILayout.LabelField("Filename", assemblyNameFromScriptPath, Array.Empty<GUILayoutOption>());
                    string assemblyDefinitionFilePathFromScriptPath = CompilationPipeline.GetAssemblyDefinitionFilePathFromScriptPath(assetPath);
                    flag2 = assemblyDefinitionFilePathFromScriptPath != null;
                    bool flag6 = flag2;
                    if (flag6)
                    {
                        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(assemblyDefinitionFilePathFromScriptPath);
                        EditorGUI.DisabledScope disabledScope = new EditorGUI.DisabledScope(true);
                        
                        try
                        {
                            EditorGUILayout.ObjectField("Definition File", textAsset, typeof(TextAsset), false, Array.Empty<GUILayoutOption>());
                        }
                        finally
                        {
                            disabledScope.Dispose();
                        }
                    }
                    EditorGUILayout.Space();
                }
            }
            bool flag7 = !_bg8._AGA;
            if (flag7)
            {
                base.OnInspectorGUI();
            }
            else
            {
                EditorWindow currentInspector = _bh3.GetCurrentInspector();
                bool flag8 = this._AEK == null;
                if (!flag8)
                {
                    bool _AGB = this._AGC;
                    if (_AGB)
                    {
                        this._AEK._AGD = new _bi2._AGE(this.Repaint);
                        this._AEK.OnEnable(base.target);
                        this._AGC = false;
                    }
                    this._AEK.OnInspectorGUI(flag2 ? 65f : 45f, currentInspector, flag2);
                }
            }
        }
    }
}
