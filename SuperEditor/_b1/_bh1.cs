using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000027 RID: 39
    internal class _bh1 : _bm5
    {
        // Token: 0x06000121 RID: 289 RVA: 0x0000FC6C File Offset: 0x0000DE6C
        internal static _bh1 Create(bool selectNext)
        {
            _bh1._ABD = _bb6.GetGuidHistory();
            bool flag = _bh1._ABD.Count == 0;
            _bh1 _BCJ;
            if (flag)
            {
                _BCJ = null;
            }
            else
            {
                _bh1._BCK = new GUIContent[_bh1._ABD.Count];
                for (int i = 0; i < _bh1._BCK.Length; i++)
                {
                    string text = AssetDatabase.GUIDToAssetPath(_bh1._ABD[i]);
                    GCE _AMX = _bc5.TryGetBuffer(text);
                    string fileName = Path.GetFileName(text);
                    string text2 = ((_AMX != null && _AMX._ALW()) ? ("*" + fileName) : fileName);
                    text2 = Path.GetFileNameWithoutExtension(text2);
                    _bh1._BCK[i] = new GUIContent(text2, AssetDatabase.GetCachedIcon(text), text);
                }
                _bh1._BCL = (selectNext ? ((_bh1._BCK.Length > 1) ? 1 : 0) : 0);
                bool flag2 = !(EditorWindow.focusedWindow is _bb6);
                if (flag2)
                {
                    _bh1._BCL = 0;
                }
                int num = Mathf.Min(_bh1._BCK.Length, 10);
                float num2 = 16f * (float)num;
                float _BCM = _bh1._BCQ;
                _bh1._AEX = EditorWindow.focusedWindow;
                bool flag3 = _bh1._AEX == null;
                if (flag3)
                {
                    foreach (_bb6 _AKB in _bb6._AJZ())
                    {
                        _bh1._AEX = _AKB;
                    }
                }
                Vector2 center = _bh1._AEX.position.center;
                Rect rect = new Rect((float)((int)(center.x - 0.5f * _BCM)), (float)((int)(center.y - num2 * 0.5f)), _BCM, num2);
                _bh1 _BCJ2 = _bm5.CreatePopup<_bh1>();
                _BCJ2.hideFlags = (HideFlags)61;
                _BCJ2.minSize = Vector2.one;
                _BCJ2.position = rect;
                _BCJ2.wantsMouseMove = false;
                _BCJ2.ShowPopup();
                EditorApplication.modifierKeysChanged = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.modifierKeysChanged, new EditorApplication.CallbackFunction(_BCJ2.OnModifierKeysChanged));
                _BCJ = _BCJ2;
            }
            return _BCJ;
        }

        // Token: 0x06000122 RID: 290 RVA: 0x0000FE98 File Offset: 0x0000E098
        internal static void MenuCreate()
        {
            _bh1._AA = _bh1.Create(false);
            _bh1._BCN = true;
        }

        // Token: 0x06000123 RID: 291 RVA: 0x0000FEAC File Offset: 0x0000E0AC
        private void OnModifierKeysChanged()
        {
            bool flag = !this;
            if (!flag)
            {
                base.Repaint();
            }
        }

        // Token: 0x06000124 RID: 292 RVA: 0x0000FED0 File Offset: 0x0000E0D0
        protected override void OnEnable()
        {
            base.OnEnable();
            this._BCO.normal.background = _bi2.FlatColorTexture(EditorGUIUtility.isProSkin ? new Color32(56, 56, 56, byte.MaxValue) : new Color32(200, 200, 200, byte.MaxValue));
            this._BCP.normal.background = _bi2.FlatColorTexture(EditorGUIUtility.isProSkin ? new Color32(102, 102, 102, byte.MaxValue) : new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
        }

        // Token: 0x06000125 RID: 293 RVA: 0x0000FF7F File Offset: 0x0000E17F
        private void OnDisable()
        {
            EditorApplication.modifierKeysChanged = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.modifierKeysChanged, new EditorApplication.CallbackFunction(this.OnModifierKeysChanged));
        }

        // Token: 0x06000126 RID: 294 RVA: 0x0000FFA2 File Offset: 0x0000E1A2
        private void OnLostFocus()
        {
            this.CloseOnly();
        }

        // Token: 0x06000127 RID: 295 RVA: 0x0000FF7F File Offset: 0x0000E17F
        private void OnDestroy()
        {
            EditorApplication.modifierKeysChanged = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.modifierKeysChanged, new EditorApplication.CallbackFunction(this.OnModifierKeysChanged));
        }

        // Token: 0x06000128 RID: 296 RVA: 0x0000FFAC File Offset: 0x0000E1AC
        private new void SetSize(float width, float height)
        {
            _bh1._BCQ = width;
            Vector2 center = base.position.center;
            int num = (int)(center.x - 0.5f * width);
            int num2 = (int)(center.y - 0.5f * height);
            Rect rect = new Rect((float)num, (float)num2, width, height);
            Rect rect2 = _bm5.FitRectToScreen(rect, this);
            base.minSize = Vector2.one;
            base.maxSize = new Vector2(4000f, 4000f);
            base.position = rect2;
            Vector2 vector = new Vector2(width, height);
            base.minSize = vector;
            base.maxSize = vector;
            bool flag = Application.platform == 0;
            if (flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(base.Focus));
            }
        }

        // Token: 0x06000129 RID: 297 RVA: 0x0001007C File Offset: 0x0000E27C
        internal static string GetSelectedGUID()
        {
            return _bh1._ABD[_bh1._BCL];
        }

        // Token: 0x0600012A RID: 298 RVA: 0x000100A0 File Offset: 0x0000E2A0
        public void CloseAndSwitch()
        {
            bool flag = !_bh1._AA;
            if (!flag)
            {
                GUIUtility.hotControl = 0;
                string selectedGUID = _bh1.GetSelectedGUID();
                base.Close();
                Object.DestroyImmediate(this);
                try
                {
                    foreach (_bb6 _AKB in _bb6._AJZ())
                    {
                        bool flag2 = _AKB && _AKB._AJY()._AKQ() == selectedGUID;
                        if (flag2)
                        {
                            bool _BCR = _AKB._AKC;
                            if (_BCR)
                            {
                                _bb6.OpenAssetInTab(selectedGUID);
                            }
                            else
                            {
                                _bb6.OpenAssetInTab(selectedGUID, false);
                            }
                        }
                    }
                }
                catch
                {
                }
                _bh1._AA = null;
                _bh1._BCN = false;
            }
        }

        // Token: 0x0600012B RID: 299 RVA: 0x00010184 File Offset: 0x0000E384
        public void CloseOnly()
        {
            base.Close();
            Object.DestroyImmediate(this);
            _bh1._BCN = false;
        }

        // Token: 0x0600012C RID: 300 RVA: 0x0001019C File Offset: 0x0000E39C
        internal static bool OnGUIGlobal()
        {
            bool flag = _bh1._AA;
            bool flag2;
            if (flag)
            {
                _bh1._AA.OnGUI();
                flag2 = true;
            }
            else
            {
                bool flag3 = (int)Event.current.type == 4 && (int)Event.current.keyCode == 9;
                if (flag3)
                {
                    bool flag4 = Application.platform == 0;
                    bool flag5 = flag4;
                    if (flag5)
                    {
                        bool flag6 = Event.current.alt && !EditorGUI.actionKey;
                        if (flag6)
                        {
                            _bh1._AA = _bh1.Create(!Event.current.shift);
                        }
                        return true;
                    }
                    bool flag7 = !Event.current.alt && EditorGUI.actionKey;
                    if (flag7)
                    {
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bh1.DelayedCreateWithShiftKey));
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bh1.DelayedCreateNoShiftKey));
                        bool shift = Event.current.shift;
                        bool flag8 = shift;
                        if (flag8)
                        {
                            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bh1.DelayedCreateWithShiftKey));
                        }
                        else
                        {
                            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bh1.DelayedCreateNoShiftKey));
                        }
                        return true;
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x0600012D RID: 301 RVA: 0x000102FB File Offset: 0x0000E4FB
        private static void DelayedCreateWithShiftKey()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bh1.DelayedCreateWithShiftKey));
            _bh1._AA = _bh1.Create(false);
        }

        // Token: 0x0600012E RID: 302 RVA: 0x00010329 File Offset: 0x0000E529
        private static void DelayedCreateNoShiftKey()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bh1.DelayedCreateNoShiftKey));
            _bh1._AA = _bh1.Create(true);
        }

        // Token: 0x0600012F RID: 303 RVA: 0x00010358 File Offset: 0x0000E558
        public void OnGUI()
        {
            GUI.Label(new Rect(0f, 0f, base.position.width, base.position.height), GUIContent.none, this._BCP);
            GUI.Label(new Rect(2f, 2f, base.position.width - 4f, base.position.height - 4f), GUIContent.none, this._BCO);
            bool flag = (int)Event.current.keyCode == 27 && _bh1._ABD != null;
            if (flag)
            {
                this.CloseOnly();
                _bb6.OpenAssetInTab(_bh1._ABD[0]);
            }
            bool flag2 = (int)Event.current.keyCode == 13;
            if (flag2)
            {
                Event.current.Use();
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
            }
            EventModifiers eventModifiers = (EventModifiers)((int)Event.current.modifiers & -113);
            bool flag3 = Application.platform == 0;
            bool flag4 = flag3;
            if (flag4)
            {
                bool flag5 = !_bh1._BCN;
                if (flag5)
                {
                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                }
            }
            else
            {
                bool flag6 = !_bh1._BCN;
                if (flag6)
                {
                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                }
            }
            bool flag7 = _bh1._BCS == null;
            if (flag7)
            {
                _bh1._BCS = new GUIStyle("PR Label");
                _bh1._BCS.padding.left = 2;
                _bh1._BCS.padding.right = 4;
                _bh1._BCS.border = new RectOffset();
                _bh1._BCS.margin = new RectOffset();
                _bh1._BCS.fixedWidth = 0f;
                _bh1._BCT = new GUIStyle(EditorStyles.largeLabel);
                _bh1._BCT.fontStyle = (FontStyle)1;
                _bh1._BCT.fontSize = 18;
                _bh1._BCT.padding = new RectOffset(6, 10, 10, 10);
                _bh1._BCT.normal.textColor = (EditorGUIUtility.isProSkin ? new Color(0.7f, 0.7f, 0.7f, 1f) : new Color(0.4f, 0.4f, 0.4f, 1f));
            }
            bool flag8 = _bh1._BCK == null;
            if (flag8)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(base.Close));
            }
            else
            {
                bool flag9 = (int)Event.current.type == 4;
                if (flag9)
                {
                    int num = _bh1._BCL;
                    bool flag10 = (int)Event.current.keyCode == 9;
                    bool flag11 = (int)Event.current.keyCode == 274 || (flag10 && !Event.current.shift);
                    if (flag11)
                    {
                        bool flag12 = ++num == _bh1._BCK.Length;
                        if (flag12)
                        {
                            num = 0;
                        }
                    }
                    else
                    {
                        bool flag13 = (int)Event.current.keyCode == 273 || (flag10 && Event.current.shift);
                        if (flag13)
                        {
                            bool flag14 = --num < 0;
                            if (flag14)
                            {
                                num = _bh1._BCK.Length - 1;
                            }
                        }
                        else
                        {
                            bool flag15 = _bh1._BCK.Length > 10 && ((int)Event.current.keyCode == 275 || (int)Event.current.keyCode == 276);
                            if (flag15)
                            {
                                num += (((int)Event.current.keyCode == 275) ? 10 : (-10));
                                bool flag16 = num < 0;
                                if (flag16)
                                {
                                    num += (_bh1._BCK.Length + 9) / 10 * 10;
                                }
                                bool flag17 = num >= _bh1._BCK.Length;
                                if (flag17)
                                {
                                    bool flag18 = num / 10 == _bh1._BCK.Length / 10;
                                    if (flag18)
                                    {
                                        num = _bh1._BCK.Length - 1;
                                    }
                                    else
                                    {
                                        num %= 10;
                                    }
                                }
                            }
                        }
                    }
                    bool flag19 = num != _bh1._BCL;
                    if (flag19)
                    {
                        _bh1._BCL = num;
                        base.Repaint();
                        Event.current.Use();
                    }
                }
                else
                {
                    bool flag20 = (int)Event.current.type == 8;
                    if (flag20)
                    {
                        EditorGUIUtility.SetIconSize(new Vector2(16f, 16f));
                        bool flag21 = this._BCU == 0f;
                        if (flag21)
                        {
                            EditorGUIUtility.SetIconSize(new Vector2(32f, 32f));
                            for (int i = 0; i < _bh1._BCK.Length; i++)
                            {
                                Vector2 vector = _bh1._BCS.CalcSize(_bh1._BCK[i]);
                                this._BCU = Mathf.Max(this._BCU, vector.x);
                                vector = _bh1._BCT.CalcSize(_bh1._BCK[i]);
                                this._BCV = Mathf.Max(this._BCV, vector.x);
                            }
                            this._BCW = 54f;
                            float num2 = Mathf.Max(this._BCV, 8f + this._BCU * (float)((_bh1._BCK.Length + 9) / 10));
                            float num3 = 4f + 16f * (float)Mathf.Min(_bh1._BCK.Length, 10) + this._BCW;
                            this.SetSize(num2, num3);
                            base.Repaint();
                            bool flag22 = _bh1._BCK.Length <= 10;
                            if (flag22)
                            {
                                this._BCU = base.position.size.x - 8f;
                            }
                        }
                        EditorGUIUtility.SetIconSize(Vector2.zero);
                    }
                }
                EditorGUIUtility.SetIconSize(new Vector2(32f, 32f));
                bool flag23 = _bh1._BCT != null;
                if (flag23)
                {
                    GUI.Label(new Rect(0f, 0f, this._BCV, this._BCW), _bh1._BCK[_bh1._BCL], _bh1._BCT);
                }
                bool flag24 = (int)Event.current.type == 7;
                if (flag24)
                {
                    EditorGUIUtility.SetIconSize(new Vector2(16f, 16f));
                    for (int j = 0; j < _bh1._BCK.Length; j++)
                    {
                        Rect rect = new Rect(4f + this._BCU * (float)(j / 10), this._BCW + 16f * (float)(j % 10), this._BCU, 16f);
                        _bh1._BCS.Draw(rect, _bh1._BCK[j], false, false, j == _bh1._BCL, true);
                    }
                }
                else
                {
                    bool flag25 = Event.current.type == 0;
                    if (flag25)
                    {
                        Event.current.Use();
                        Vector2 vector2 = Event.current.mousePosition - new Vector2(4f, this._BCW);
                        bool flag26 = vector2.x >= 0f && vector2.y >= 0f && vector2.y < 160f;
                        if (flag26)
                        {
                            int num4 = (int)(vector2.y / 16f) + 10 * (int)(vector2.x / this._BCU);
                            bool flag27 = num4 != _bh1._BCL && num4 < _bh1._ABD.Count;
                            if (flag27)
                            {
                                _bh1._BCL = num4;
                                base.Repaint();
                            }
                        }
                    }
                    else
                    {
                        bool flag28 = (int)Event.current.type == 1;
                        if (flag28)                        
                        {
                            Event.current.Use();
                            Vector2 vector3 = Event.current.mousePosition - new Vector2(4f, this._BCW);
                            bool flag29 = vector3.x >= 0f && vector3.y >= 0f && vector3.y < 160f;
                            if (flag29)
                            {
                                int num5 = (int)(vector3.y / 16f) + 10 * (int)(vector3.x / this._BCU);
                                bool flag30 = num5 == _bh1._BCL && num5 < _bh1._ABD.Count;
                                if (flag30)
                                {
                                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.CloseAndSwitch));
                                    return;
                                }
                            }
                        }
                    }
                }
                EditorGUIUtility.SetIconSize(Vector2.zero);
            }
        }

        // Token: 0x0400013E RID: 318
        internal static _bh1 _AA;

        // Token: 0x0400013F RID: 319
        internal static bool _BCN = false;

        // Token: 0x04000140 RID: 320
        private static GUIContent[] _BCK;

        // Token: 0x04000141 RID: 321
        private static List<string> _ABD;

        // Token: 0x04000142 RID: 322
        private static int _BCL = 0;

        // Token: 0x04000143 RID: 323
        private static GUIStyle _BCS;

        // Token: 0x04000144 RID: 324
        private static GUIStyle _BCT;

        // Token: 0x04000145 RID: 325
        private new static EditorWindow _AEX;

        // Token: 0x04000146 RID: 326
        private static float _BCQ = 200f;

        // Token: 0x04000147 RID: 327
        private float _BCU = 0f;

        // Token: 0x04000148 RID: 328
        private float _BCV = 0f;

        // Token: 0x04000149 RID: 329
        private float _BCW = 0f;

        // Token: 0x0400014A RID: 330
        private GUIStyle _BCO = new GUIStyle();

        // Token: 0x0400014B RID: 331
        private GUIStyle _BCP = new GUIStyle();
    }
}
