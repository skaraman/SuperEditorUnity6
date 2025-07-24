using System;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000016 RID: 22
    internal class _be2 : EditorWindow
    {
        // Token: 0x060000BA RID: 186 RVA: 0x00009914 File Offset: 0x00007B14
        internal static void ShowBuyWindow()
        {
            bool flag = _be2._AA != null;
            if (!flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                {
                    bool flag2 = _be2._AA != null;
                    if (flag2)
                    {
                        _be2._AA.Repaint();
                    }
                    else
                    {
                        _be2.Create();
                    }
                }));
            }
        }

        // Token: 0x060000BB RID: 187 RVA: 0x00009968 File Offset: 0x00007B68
        internal static void Create()
        {
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            _be2 window = EditorWindow.GetWindow<_be2>(true);
            window._AVP = focusedWindow;
            _bi2 _AVQ = GCE._ALU;
            window._ABF = _AVQ;
            bool flag = focusedWindow != null;
            if (flag)
            {
                Vector2 center = focusedWindow.position.center;
                window.position = new Rect((float)((int)(center.x - 180f)), (float)((int)(center.y - 130f)), 360f, 260f);
            }
            bool flag2 = Application.platform == RuntimePlatform.WindowsEditor;
            if (flag2)
            {
                typeof(EditorWindow).GetMethod("ShowModal").Invoke(window, new object[0]);
            }
            else
            {
                window.Show();
            }
        }

        // Token: 0x060000BC RID: 188 RVA: 0x00009A30 File Offset: 0x00007C30
        private void OnEnable()
        {
            _be2._AA = this;
            base.titleContent.text = "Buy Pro Version";
            base.minSize = new Vector2(360f, 260f);
            base.maxSize = new Vector2(360f, 260f);
            base.Repaint();
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00009A88 File Offset: 0x00007C88
        private void OnDisable()
        {
            _be2._AA = null;
            bool flag = this._ABF != null && this._ABF._ABJ();
            if (flag)
            {
                this._ABF._ABJ().Focus();
            }
            else
            {
                bool flag2 = this._AVP;
                if (flag2)
                {
                    this._AVP.Focus();
                }
            }
        }

        // Token: 0x060000BE RID: 190 RVA: 0x00009AEC File Offset: 0x00007CEC
        private void Initialize()
        {
            this._AVR = new GUIStyle(EditorStyles.boldLabel);
            this._AVR.fontSize = 24;
            this._AVR.alignment = 1;
            this._AVS = new GUIStyle(EditorStyles.miniLabel);
            this._AVS.alignment = 0;
            this._AVS.wordWrap = true;
            this._AVS.padding.left = 20;
            this._AVT = new GUIStyle(EditorStyles.label);
            this._AVT.alignment = 0;
            this._AVT.normal.textColor = this._AVS.normal.textColor;
            this._AVT.wordWrap = true;
            this._AVT.padding.left = 10;
            this._AVT.padding.right = 10;
        }

        // Token: 0x060000BF RID: 191 RVA: 0x00009BD4 File Offset: 0x00007DD4
        private void OnGUI()
        {
            bool flag = this._AVT == null;
            if (flag)
            {
                this.Initialize();
            }
            GUILayout.Box("Super Editor", this._AVR, Array.Empty<GUILayoutOption>());
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("If you want to use a more powerful version and support the development of Super Editor, you can buy Super Editor Pro from Unity Asset Store, Advantages of using the Pro version:", this._AVT, Array.Empty<GUILayoutOption>());
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("● The interface is more free and flexible, more suitable for professional programmers.", this._AVS, Array.Empty<GUILayoutOption>());
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("● Contains 16 professional themes and customized themes.", this._AVS, Array.Empty<GUILayoutOption>());
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("● More customization and professional features for Hierarchy.", this._AVS, Array.Empty<GUILayoutOption>());
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("● Lifetime technical and service support.", this._AVS, Array.Empty<GUILayoutOption>());
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
            bool flag2 = GUILayout.Button("Buy from Asset Store", Array.Empty<GUILayoutOption>());
            if (flag2)
            {
                Application.OpenURL("https://assetstore.unity.com/packages/tools/utilities/super-editor-pro-192174");
            }
            EditorGUILayout.EndVertical();
            bool flag3 = Event.current.isKey && Event.current.keyCode == 27;
            if (flag3)
            {
                base.Close();
            }
        }

        // Token: 0x040000AF RID: 175
        private GUIStyle _AVT;

        // Token: 0x040000B0 RID: 176
        private GUIStyle _AVR;

        // Token: 0x040000B1 RID: 177
        private GUIStyle _AVS;

        // Token: 0x040000B2 RID: 178
        private static _be2 _AA;

        // Token: 0x040000B3 RID: 179
        private string _AVU;

        // Token: 0x040000B4 RID: 180
        private string _AVV;

        // Token: 0x040000B5 RID: 181
        private string _AVW;

        // Token: 0x040000B6 RID: 182
        [NonSerialized]
        private EditorWindow _AVP;

        // Token: 0x040000B7 RID: 183
        private _bi2 _ABF;
    }
}
