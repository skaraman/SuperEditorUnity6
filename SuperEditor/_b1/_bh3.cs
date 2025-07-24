using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000055 RID: 85
    internal class _bh3 : Editor
    {
        // Token: 0x0600026D RID: 621 RVA: 0x00021498 File Offset: 0x0001F698
        public virtual void OnEnable()
        {
            typeof(Editor).GetProperty("alwaysAllowExpansion", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
            this._BDT = base.target as TextAsset;
            this._BDU = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this._BDT));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(delegate
            {
                bool flag = this._BDV != _bg8._AGA;
                if (flag)
                {
                    base.Repaint();
                    this._BDV = _bg8._AGA;
                }
                bool flag2 = this._BDW != _bg8._BAY;
                if (flag2)
                {
                    base.Repaint();
                    this._BDW = _bg8._BAY;
                }
            }));
        }

        // Token: 0x0600026E RID: 622 RVA: 0x00021511 File Offset: 0x0001F711
        public void OnDisable()
        {
            this._AEK._AGD = null;
            this._AEK.OnDisable();
        }

        // Token: 0x0600026F RID: 623 RVA: 0x0002152C File Offset: 0x0001F72C
        public static bool IsFocused()
        {
            Type type = EditorWindow.focusedWindow.GetType();
            return type.ToString() == "UnityEditor.InspectorWindow" || (_bh3._BDX != null && type == _bh3._BDX);
        }

        // Token: 0x06000270 RID: 624 RVA: 0x0002157C File Offset: 0x0001F77C
        internal static EditorWindow GetCurrentInspector()
        {
            bool flag = _bh3._BDY == null;
            if (flag)
            {
                _bh3._BDY = typeof(EditorWindow).Assembly.GetType("UnityEditor.GUIView");
                _bh3._BDZ = _bh3._BDY.GetProperty("current");
            }
            bool flag2 = _bh3._BEA == null;
            if (flag2)
            {
                _bh3._BEA = typeof(EditorWindow).Assembly.GetType("UnityEditor.HostView");
                _bh3._BEB = _bh3._BEA.GetProperty("actualView", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            }
            bool flag3 = _bh3._BDZ != null;
            if (flag3)
            {
                object value = _bh3._BDZ.GetValue(null, null);
                bool flag4 = value != null && value.GetType().IsSubclassOf(_bh3._BEA) && _bh3._BEB != null;
                if (flag4)
                {
                    return _bh3._BEB.GetValue(value, null) as EditorWindow;
                }
            }
            return null;
        }

        // Token: 0x06000271 RID: 625 RVA: 0x0002167C File Offset: 0x0001F87C
        public override void OnInspectorGUI()
        {
            bool flag = this._BEC == null;
            bool flag2 = flag;
            if (flag2)
            {
                this._BEC = "ScriptText";
            }
            bool enabled = GUI.enabled;
            GUI.enabled = true;
            TextAsset textAsset = base.target as TextAsset;
            bool flag3 = textAsset != null;
            bool flag4 = flag3;
            if (flag4)
            {
                bool flag5 = base.targets.Length > 1;
                bool flag6 = flag5;
                string text;
                if (flag6)
                {
                    text = typeof(Editor).GetProperty("targetTitle", BindingFlags.NonPublic).GetValue(this, null).ToString();
                }
                else
                {
                    text = textAsset.ToString();
                    bool flag7 = text.Length > 7000;
                    bool flag8 = flag7;
                    if (flag8)
                    {
                        text = text.Substring(0, 7000) + "...\n\n<...etc...>";
                    }
                }
                Rect rect = GUILayoutUtility.GetRect((GUIContent)typeof(EditorGUIUtility).GetMethod("TempContent", BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null).Invoke(null, new object[] { text }), this._BEC);
                rect.x = 0f;
                rect.y -= 3f;
                bool flag9 = this._BED == null;
                if (flag9)
                {
                    this._BED = typeof(GUI).Assembly.GetType("UnityEngine.GUIClip");
                }
                bool flag10 = this._BEE == null;
                if (flag10)
                {
                    this._BEE = this._BED.GetProperty("visibleRect", BindingFlags.Static | BindingFlags.NonPublic);
                }
                rect.width = ((Rect)this._BEE.GetValue(null, null)).width + 1f;
                GUI.Box(rect, text, this._BEC);
            }
            GUI.enabled = enabled;
        }

        // Token: 0x04000292 RID: 658
        [NonSerialized]
        private GUIStyle _BEC;

        // Token: 0x04000293 RID: 659
        private TextAsset _BDT;

        // Token: 0x04000294 RID: 660
        private GUIContent _BEF;

        // Token: 0x04000295 RID: 661
        private string _BDU;

        // Token: 0x04000296 RID: 662
        private Hash128 _BEG;

        // Token: 0x04000297 RID: 663
        private Type _BED;

        // Token: 0x04000298 RID: 664
        private PropertyInfo _BEE;

        // Token: 0x04000299 RID: 665
        private bool _BDV = false;

        // Token: 0x0400029A RID: 666
        private bool _BDW = true;

        // Token: 0x0400029B RID: 667
        [HideInInspector]
        [SerializeField]
        protected _bi2 _AEK = new _bi2();

        // Token: 0x0400029C RID: 668
        [NonSerialized]
        protected bool _AGC = true;

        // Token: 0x0400029D RID: 669
        protected static Type _BDX;

        // Token: 0x0400029E RID: 670
        protected static Type _BEH;

        // Token: 0x0400029F RID: 671
        protected static Type _BDY;

        // Token: 0x040002A0 RID: 672
        protected static Type _BEA;

        // Token: 0x040002A1 RID: 673
        protected static FieldInfo _BEI;

        // Token: 0x040002A2 RID: 674
        protected static PropertyInfo _BDZ;

        // Token: 0x040002A3 RID: 675
        protected static PropertyInfo _BEB;
    }
}
