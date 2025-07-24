using System;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000150 RID: 336
    [CustomEditor(typeof(_fb5))]
    internal class _f9 : Editor
    {
        // Token: 0x060009BE RID: 2494 RVA: 0x001039E4 File Offset: 0x00101BE4
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("\nThis is an auto created GameObject that managed by Super Hierarchy.\n\nIt stores references to some GameObjects in the current scene. This object will not be included in the application build.\n\nYou can safely remove it, but lock / unlock / visible / etc. states will be reset. Delete this object if you want to remove Super Hierarchy.\n\nThis object can be hidden if you uncheck \"Show Super Hierarchy GameObject\" in the settings of Super Hierarchy.\n", MessageType.Info, true);
            bool flag = _f5.GetInstance().Get<bool>(HierarchySetting.ShowObjectListContent);
            if (flag)
            {
                bool flag2 = GUI.Button(EditorGUILayout.GetControlRect(new GUILayoutOption[]
                {
                    GUILayout.ExpandWidth(true),
                    GUILayout.Height(20f)
                }), "Hide content");
                if (flag2)
                {
                    _f5.GetInstance().Set<bool>(HierarchySetting.ShowObjectListContent, false);
                }
                base.OnInspectorGUI();
            }
            else
            {
                bool flag3 = GUI.Button(EditorGUILayout.GetControlRect(new GUILayoutOption[]
                {
                    GUILayout.ExpandWidth(true),
                    GUILayout.Height(20f)
                }), "Show content");
                if (flag3)
                {
                    _f5.GetInstance().Set<bool>(HierarchySetting.ShowObjectListContent, true);
                }
            }
        }
    }
}
