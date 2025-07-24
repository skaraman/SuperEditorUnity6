using System;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200003F RID: 63
    internal class _bc2 : EditorWindow
    {
        // Token: 0x060001B7 RID: 439 RVA: 0x000170E4 File Offset: 0x000152E4
        internal static void CreateWindow(_bh4 symbol, string assetPath)
        {
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            _bc2 window = EditorWindow.GetWindow<_bc2>(true);
            window._AMN = symbol;
            window._AMO = assetPath;
            window._AMP = symbol._AW;
            bool flag = focusedWindow != null;
            if (flag)
            {
                Vector2 center = focusedWindow.position.center;
                window.position = new Rect((float)((int)(center.x - 128f)), (float)((int)(center.y - 50f)), 256f, 100f);
            }
            window.ShowAuxWindow();
        }

        // Token: 0x060001B8 RID: 440 RVA: 0x00017170 File Offset: 0x00015370
        private void OnEnable()
        {
            base.titleContent.text = "Rename";
            base.minSize = new Vector2(265f, 100f);
            base.maxSize = new Vector2(265f, 100f);
            base.Repaint();
        }

        // Token: 0x060001B9 RID: 441 RVA: 0x000171C4 File Offset: 0x000153C4
        private void OnGUI()
        {
            bool flag = this._AMP != "" && this._AMP != this._AMN._AW;
            bool flag2 = flag && Event.current.type == EventType.KeyDown && Event.current.character == '\n';
            if (flag2)
            {
                _bh6.RenameSymbol(this._AMN, this._AMO, this._AMP);
                base.Close();
            }
            else
            {
                bool flag3 = Event.current.type == EventType.KeyDown && (int)Event.current.keyCode == 27;
                if (flag3)
                {
                    base.Close();
                }
                else
                {
                    GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
                    GUILayout.Space(10f);
                    GUILayout.Label("Rename " + this._AMN._AT.ToString() + " to:", Array.Empty<GUILayoutOption>());
                    GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
                    GUILayout.Space(10f);
                    GUI.SetNextControlName("text field");
                    EditorGUI.FocusTextInControl("text field");
                    this._AMP = EditorGUILayout.TextField(this._AMP, Array.Empty<GUILayoutOption>());
                    GUI.FocusControl("text field");
                    GUILayout.Space(10f);
                    GUILayout.EndHorizontal();
                    GUILayout.Space(20f);
                    GUILayout.EndVertical();
                    GUI.enabled = flag;
                    GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
                    GUILayout.FlexibleSpace();
                    bool flag4 = GUILayout.Button("Rename", Array.Empty<GUILayoutOption>());
                    if (flag4)
                    {
                        _bh6.RenameSymbol(this._AMN, this._AMO, this._AMP);
                    }
                    GUILayout.Space(6f);
                    GUI.enabled = true;
                    bool flag5 = GUILayout.Button("Cancel", Array.Empty<GUILayoutOption>());
                    if (flag5)
                    {
                        base.Close();
                    }
                    GUILayout.Space(10f);
                    GUILayout.EndHorizontal();
                }
            }
        }

        // Token: 0x0400020C RID: 524
        private string _AMP;

        // Token: 0x0400020D RID: 525
        private _bh4 _AMN;

        // Token: 0x0400020E RID: 526
        private string _AMO;
    }
}
