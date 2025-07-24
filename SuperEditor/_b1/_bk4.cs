using System;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000003 RID: 3
    internal class _bk4 : EditorWindow
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        [MenuItem("Window/Super Editor/Settings", false, 990)]
        internal static void OpenSettingsWindow()
        {
            _bk4 window = EditorWindow.GetWindow<_bk4>();
            window.minSize = new Vector2(375f, 200f);
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000207A File Offset: 0x0000027A
        internal void OnEnable()
        {
            base.titleContent = new GUIContent("Super Editor Settings", EditorGUIUtility.IconContent("UnityEditor.SceneHierarchyWindow").image);
        }

        // Token: 0x06000003 RID: 3 RVA: 0x000020A0 File Offset: 0x000002A0
        internal void OnGUI()
        {
            EditorGUILayout.Space();
            int num = GUILayout.Toolbar(_bg8._AZS, _bg8._AZT, _bg8._AVA._AZU, Array.Empty<GUILayoutOption>());
            bool flag = num != _bg8._AZS;
            if (flag)
            {
                _bg8._AZS = num;
                EditorPrefs.SetInt("Vik.SuperEditor.SettingsMode", _bg8._AZS);
            }
            EditorGUILayout.Space();
            switch (_bg8._AZS)
            {
                case 0:
                    _bg8.General();
                    break;
                case 1:
                    _bg8.View();
                    break;
                case 2:
                    _bg8.Hierarchy();
                    break;
            }
        }
    }
}
