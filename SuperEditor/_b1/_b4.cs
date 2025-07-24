using System;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000048 RID: 72
    internal class _b4 : EditorWindow
    {
        // Token: 0x060001EF RID: 495 RVA: 0x000192F4 File Offset: 0x000174F4
        internal static _b4 Create(_bi2 editor)
        {
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            _b4 window = EditorWindow.GetWindow<_b4>(true);
            window._ABF = editor;
            window._ABG = (editor._ABH._ABI + 1).ToString();
            bool flag = focusedWindow != null;
            if (flag)
            {
                Vector2 center = focusedWindow.position.center;
                window.position = new Rect((float)((int)(center.x - 128f)), (float)((int)(center.y - 45f)), 256f, 90f);
            }
            window.ShowAuxWindow();
            return window;
        }

        // Token: 0x060001F0 RID: 496 RVA: 0x00019394 File Offset: 0x00017594
        private void OnEnable()
        {
            base.titleContent.text = "Go To Line";
            base.minSize = new Vector2(256f, 90f);
            base.maxSize = new Vector2(256f, 90f);
            base.Repaint();
        }

        // Token: 0x060001F1 RID: 497 RVA: 0x000193E6 File Offset: 0x000175E6
        private void OnDisable()
        {
            this._ABF._ABJ().Focus();
        }

        // Token: 0x060001F2 RID: 498 RVA: 0x000193FC File Offset: 0x000175FC
        private void OnGUI()
        {
            bool flag = this._ABG == string.Empty;
            bool flag2;
            int num;
            if (flag)
            {
                flag2 = true;
                num = 1;
            }
            else
            {
                flag2 = int.TryParse(this._ABG, out num);
            }
            bool flag3 = flag2 && (int)Event.current.type == 4 && Event.current.character == '\n';
            if (flag3)
            {
                bool flag4 = num < 1;
                if (flag4)
                {
                    num = 1;
                }
                bool flag5 = num > this._ABF._ABK().FLOg.Count;
                if (flag5)
                {
                    num = this._ABF._ABK().FLOg.Count;
                }
                this._ABF.SetCursorPosition(num - 1, 0);
                base.Close();
                this._ABF._ABJ().Focus();
            }
            else
            {
                bool flag6 = (int)Event.current.type == 4 && (int)Event.current.keyCode == 27;
                if (flag6)
                {
                    base.Close();
                    this._ABF._ABJ().Focus();
                }
                else
                {
                    GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
                    GUILayout.Space(10f);
                    GUILayout.Label(" Line number(1-" + this._ABF._ABK().FLOg.Count.ToString() + "):", Array.Empty<GUILayoutOption>());
                    GUILayout.Space(5f);
                    GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
                    GUILayout.Space(10f);
                    GUI.SetNextControlName("text field");
                    EditorGUI.FocusTextInControl("text field");
                    this._ABG = EditorGUILayout.TextField(this._ABG, Array.Empty<GUILayoutOption>());
                    GUI.FocusControl("text field");
                    GUILayout.Space(10f);
                    GUILayout.EndHorizontal();
                    GUILayout.Space(10f);
                    GUI.enabled = flag2;
                    GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
                    GUILayout.FlexibleSpace();
                    bool flag7 = GUILayout.Button("OK", Array.Empty<GUILayoutOption>());
                    if (flag7)
                    {
                        this._ABF.SetCursorPosition(num - 1, 0);
                        base.Close();
                        this._ABF._ABJ().Focus();
                    }
                    GUILayout.Space(6f);
                    GUI.enabled = true;
                    bool flag8 = GUILayout.Button("Cancel", Array.Empty<GUILayoutOption>());
                    if (flag8)
                    {
                        base.Close();
                        this._ABF._ABJ().Focus();
                    }
                    GUILayout.Space(10f);
                    GUILayout.EndHorizontal();
                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                }
            }
        }

        // Token: 0x04000240 RID: 576
        private string _ABG;

        // Token: 0x04000241 RID: 577
        private _bi2 _ABF;
    }
}
