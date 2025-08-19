using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ACGG;
using SuperEditor;
using SuperEditor.IDE;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200001E RID: 30
    internal class _bk5 : EditorWindow, IHasCustomMenu
    {
        // Token: 0x060000E3 RID: 227 RVA: 0x0000B9D4 File Offset: 0x00009BD4
        public bool _zn1()
        {
            return this._zn2;
        }

        // Token: 0x060000E4 RID: 228 RVA: 0x0000B9EC File Offset: 0x00009BEC
        private bool _zn3()
        {
            return this._zn4;
        }

        // Token: 0x060000E5 RID: 229 RVA: 0x0000BA04 File Offset: 0x00009C04
        private void _zn5(bool value)
        {
            _bf5 _zn6 = _bg8._BCH;
            this._zn4 = value;
            _zn6._AIF(value);
        }

        // Token: 0x060000E6 RID: 230 RVA: 0x0000BA28 File Offset: 0x00009C28
        internal static HashSet<_bk5> _zn7()
        {
            return _bk5._zn8;
        }

        // Token: 0x060000E7 RID: 231 RVA: 0x0000BA40 File Offset: 0x00009C40
        public void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(new GUIContent("Lock"), this._zn2, delegate
            {
                this._zn2 = !this._zn2;
            });
            menu.AddItem("Maximize", "&\n", "Maximize", "&enter", base.maximized, delegate
            {
                base.maximized = !base.maximized;
            });
            menu.AddItem("Close", "%w", "Close", "%w", false, delegate
            {
                base.Close();
            });
            menu.ShowAsContext();
            GUIUtility.ExitGUI();
        }

        // Token: 0x060000E8 RID: 232 RVA: 0x0000BAD4 File Offset: 0x00009CD4
        internal static _bk5 Create(string description, Action<Action<string, string, TextPosition, int>, string, _bk5._AZL> searchFunction, string[] assetGuids, _bk5._AZL searchOptions, string reuseWindowByTitle)
        {
            _bk5[] array = (_bk5[])Resources.FindObjectsOfTypeAll(typeof(_bk5));
            _bk5 _AZF = array.FirstOrDefault((_bk5 w) => !w._zn1() && w.titleContent.text.Contains(reuseWindowByTitle));
            _bk5 _AZF2 = _AZF ?? ScriptableObject.CreateInstance<_bk5>();
            bool flag = !_AZF && array.Length == 0;
            if (flag)
            {
                Assembly assembly = typeof(EditorWindow).Assembly;
                _bb6.DockNextTo(_AZF2, EditorWindow.GetWindow(assembly.GetType("UnityEditor.ConsoleWindow")));
            }
            _AZF2._zn9 = description;
            _AZF2._zo1 = searchFunction;
            _AZF2._zo2 = new List<string>(assetGuids);
            _AZF2._zo3 = searchOptions;
            _AZF2._zo4 = new _bk5._zo5
            {
                _zo6 = true,
                _zo7 = true,
                _zm3 = true,
                _zo8 = true,
                _zo9 = true,
                _zp1 = true,
                _zp2 = true,
                _zp3 = false,
                _zp4 = true,
                _zp5 = true,
                _zp6 = true,
                _zp7 = true,
                _AIC = true
            };
            _AZF2._zn4 = _bg8._BCH;
            bool flag2 = !_AZF;
            if (flag2)
            {
                _bk5[] array2 = array;
                int i = 0;
                while (i < array2.Length)
                {
                    _bk5 _AZF3 = array2[i];
                    bool flag3 = _AZF3 != _AZF2 && _AZF3;
                    if (flag3)
                    {
                        bool flag4 = _bb6.DestroyWindowIfOrphaned(_AZF3);
                        if (!flag4)
                        {
                            bool flag5 = _bb6.DockNextTo(_AZF2, _AZF3);
                            bool flag6 = flag5;
                            if (flag6)
                            {
                                break;
                            }
                        }
                    }
                    i++;
                }
            }
            bool flag7 = !_AZF && reuseWindowByTitle == "References";
            if (flag7)
            {
                _bk5._zp8++;
                _AZF2.titleContent.text = "References";
                bool flag8 = _bk5._zp8 > 1;
                if (flag8)
                {
                    int num = 0;
                    foreach (_bk5 _AZF4 in _bk5._zn8)
                    {
                        bool flag9 = _AZF4.titleContent.text.Contains("References");
                        if (flag9)
                        {
                            string text = Regex.Replace(_AZF4.titleContent.text, "[^0-9]+", "");
                            bool flag10 = text != "";
                            if (flag10)
                            {
                                int num2 = int.Parse(text);
                                bool flag11 = num2 > num;
                                if (flag11)
                                {
                                    num = num2;
                                }
                            }
                        }
                    }
                    num++;
                    bool flag12 = num > 0;
                    if (flag12)
                    {
                        _AZF2.titleContent.text = "References(" + num.ToString() + ")";
                    }
                }
            }
            bool flag13 = !_AZF && reuseWindowByTitle == "Find Results";
            if (flag13)
            {
                _bk5._zp9++;
                _AZF2.titleContent.text = "Find Results";
                bool flag14 = _bk5._zp9 > 1;
                if (flag14)
                {
                    int num3 = 0;
                    foreach (_bk5 _AZF5 in _bk5._zn8)
                    {
                        bool flag15 = _AZF5.titleContent.text.Contains("Find Results");
                        if (flag15)
                        {
                            string text2 = Regex.Replace(_AZF5.titleContent.text, "[^0-9]+", "");
                            bool flag16 = text2 != "";
                            if (flag16)
                            {
                                int num4 = int.Parse(text2);
                                bool flag17 = num4 > num3;
                                if (flag17)
                                {
                                    num3 = num4;
                                }
                            }
                        }
                    }
                    num3++;
                    bool flag18 = num3 > 0;
                    if (flag18)
                    {
                        _AZF2.titleContent.text = "Find Results(" + num3.ToString() + ")";
                    }
                }
            }
            _AZF2.ClearResults();
            _AZF2.ShowUtility();
            _AZF2.Focus();
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_AZF2.BackgroundSearch));
            _AZF2._zq1 = 0f;
            return _AZF2;
        }

        // Token: 0x060000E9 RID: 233 RVA: 0x0000BF34 File Offset: 0x0000A134
        internal void BackgroundSearch()
        {
            bool flag = this._zq2 && !_bg8._BBD;
            if (!flag)
            {
                bool flag2 = this._zo1 != null && this._zq3 < this._zo2.Count;
                if (flag2)
                {
                    List<string> _zq4 = this._zo2;
                    int num = this._zq3;
                    this._zq3 = num + 1;
                    string text = _zq4[num];
                    bool flag3 = this._zq5 != null;
                    if (flag3)
                    {
                        while (text != null && !this._zq5(text, this._zo4))
                        {
                            this._zq6.Add(text);
                            bool flag4 = this._zq3 < this._zo2.Count;
                            if (flag4)
                            {
                                List<string> _zq7 = this._zo2;
                                num = this._zq3;
                                this._zq3 = num + 1;
                                text = _zq7[num];
                            }
                            else
                            {
                                text = null;
                            }
                        }
                    }
                    bool flag5 = text != null;
                    if (flag5)
                    {
                        this._zo1(new Action<string, string, TextPosition, int>(this.AddResult), text, this._zo3);
                    }
                }
                else
                {
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.BackgroundSearch));
                }
            }
        }

        // Token: 0x060000EA RID: 234 RVA: 0x0000C074 File Offset: 0x0000A274
        public void SetFilesValidator(_bk5._zq8 validateFileFunction)
        {
            this._zq5 = validateFileFunction;
        }

        // Token: 0x060000EB RID: 235 RVA: 0x0000C080 File Offset: 0x0000A280
        public void SetResultsValidator(_bk5._zq9 validateResultFunction, _bh4 referencedSymbol)
        {
            this._zr1 = validateResultFunction;
            this._zr2 = referencedSymbol;
            this._zr3 = referencedSymbol is _bn3;
            this._zr4 = referencedSymbol is _b2;
            this._zr5 = referencedSymbol._AT;
            base.Repaint();
        }

        // Token: 0x060000EC RID: 236 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
        public void SetReplaceText(string replaceText)
        {
            GCE._AUL = (GCE._AVJ)Delegate.Remove(GCE._AUL, new GCE._AVJ(this.OnBufferModified));
            GCE._AUL = (GCE._AVJ)Delegate.Combine(GCE._AUL, new GCE._AVJ(this.OnBufferModified));
            GCE._AUP = (GCE._AVN)Delegate.Remove(GCE._AUP, new GCE._AVN(this.OnBufferModified));
            GCE._AUP = (GCE._AVN)Delegate.Combine(GCE._AUP, new GCE._AVN(this.OnBufferModified));
            this._AVV = replaceText;
            base.titleContent.text = ((this._zr1 != null) ? "Rename" : "Replace");
            base.Repaint();
        }

        // Token: 0x060000ED RID: 237 RVA: 0x0000C18C File Offset: 0x0000A38C
        public void ReplaceAllAfterSearchAndSetFocus(EditorWindow toWindow)
        {
            this._zr6 = true;
            this._zr7 = toWindow;
        }

        // Token: 0x060000EE RID: 238 RVA: 0x0000C1A0 File Offset: 0x0000A3A0
        private void ClearResults()
        {
            this._zr8 = "Found 0 result.";
            this._zr9 = true;
            this._zq3 = 0;
            this._AFS = Vector2.zero;
            this._ADS = 0;
            this._zs1 = 0f;
            this._zq6.Clear();
            this._zs2.Clear();
            this._zs3.Clear();
            this._zs4 = 0;
            this._zs5 = 0;
            this._zs6.Clear();
        }

        // Token: 0x060000EF RID: 239 RVA: 0x0000C224 File Offset: 0x0000A424
        private void OnEnable()
        {
            _bk5._zn8.Add(this);
            base.titleContent.image = EditorGUIUtility.IconContent("UnityEditor.ConsoleWindow").image;
            bool flag = _bk5._zn8.Count > 0;
            if (flag)
            {
                bool flag2 = base.titleContent.text.Contains("References");
                if (flag2)
                {
                    _bk5._zp8++;
                }
                bool flag3 = base.titleContent.text.Contains("Find Results");
                if (flag3)
                {
                    _bk5._zp9++;
                }
            }
            this.UpdateFilters();
            base.Repaint();
            GCE._AUJ = (GCE._AVH)Delegate.Remove(GCE._AUJ, new GCE._AVH(this.OnInsertedLines));
            GCE._AUJ = (GCE._AVH)Delegate.Combine(GCE._AUJ, new GCE._AVH(this.OnInsertedLines));
            GCE._AUN = (GCE._AVL)Delegate.Remove(GCE._AUN, new GCE._AVL(this.OnRemovedLines));
            GCE._AUN = (GCE._AVL)Delegate.Combine(GCE._AUN, new GCE._AVL(this.OnRemovedLines));
            _bk5.LoadIcons();
        }

        // Token: 0x060000F0 RID: 240 RVA: 0x0000C350 File Offset: 0x0000A550
        internal static void LoadIcons()
        {
            _bk5._zs7 = _a2.GetInstance().GetTexture(Base64Texture.Filter);
            _bk5._zs8 = _a2.GetInstance().GetTexture(Base64Texture.SortingGrouping);
            _bk5._zs9 = _a2.GetInstance().GetTexture(Base64Texture.ReplaceAll);
            _bk5._zt1 = _a2.GetInstance().GetTexture(Base64Texture.Pin);
            _bk5._zt2 = _a2.GetInstance().GetTexture(Base64Texture.Stop);
            _bk5._zt3 = _a2.GetInstance().GetTexture(Base64Texture.ExpandAll);
            _bk5._zt4 = _a2.GetInstance().GetTexture(Base64Texture.CollapseAll);
            _bk5._CEH = _a2.GetInstance().GetTexture(Base64Texture.WhitePing);
        }

        // Token: 0x060000F1 RID: 241 RVA: 0x0000C3E4 File Offset: 0x0000A5E4
        private void Unsubscribe()
        {
            this._zo2.Clear();
            this._zq6.Clear();
            this._zq3 = 0;
            this._zo1 = null;
            GCE._AUJ = (GCE._AVH)Delegate.Remove(GCE._AUJ, new GCE._AVH(this.OnInsertedLines));
            GCE._AUN = (GCE._AVL)Delegate.Remove(GCE._AUN, new GCE._AVL(this.OnRemovedLines));
            GCE._AUL = (GCE._AVJ)Delegate.Remove(GCE._AUL, new GCE._AVJ(this.OnBufferModified));
            GCE._AUP = (GCE._AVN)Delegate.Remove(GCE._AUP, new GCE._AVN(this.OnBufferModified));
        }

        // Token: 0x060000F2 RID: 242 RVA: 0x0000C498 File Offset: 0x0000A698
        private void OnDisable()
        {
            _bk5._zn8.Remove(this);
            this.Unsubscribe();
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x0000C4B0 File Offset: 0x0000A6B0
        private void OnDestroy()
        {
            this.Unsubscribe();
            bool flag = base.titleContent.text.Contains("References");
            if (flag)
            {
                _bk5._zp8--;
            }
            bool flag2 = base.titleContent.text.Contains("Find Results");
            if (flag2)
            {
                _bk5._zp9--;
            }
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x0000C510 File Offset: 0x0000A710
        private void OnBufferModified(string guid, GCE._AFA from, GCE._AFA to)
        {
            for (int i = 0; i < this._zs3.Count; i++)
            {
                _bk5._zt5 _zt6 = this._zs3[i];
                bool flag = _zt6._zt7 != null && guid == _zt6._ADF;
                if (flag)
                {
                    this.Unsubscribe();
                    base.Close();
                    break;
                }
            }
        }

        // Token: 0x060000F5 RID: 245 RVA: 0x0000C574 File Offset: 0x0000A774
        private void OnInsertedLines(string guid, int lineIndex, int numLines)
        {
            for (int i = 0; i < this._zs3.Count; i++)
            {
                _bk5._zt5 _zt6 = this._zs3[i];
                bool flag = _zt6._zt7 != null && guid == _zt6._ADF;
                if (flag)
                {
                    bool flag2 = lineIndex <= _zt6._ABI;
                    if (flag2)
                    {
                        _zt6._ABI += numLines;
                        this._zt8 = true;
                    }
                }
            }
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x0000C5F4 File Offset: 0x0000A7F4
        private void OnRemovedLines(string guid, int lineIndex, int numLines)
        {
            for (int i = 0; i < this._zs3.Count; i++)
            {
                _bk5._zt5 _zt6 = this._zs3[i];
                bool flag = _zt6._zt7 != null && guid == _zt6._ADF;
                if (flag)
                {
                    bool flag2 = lineIndex <= _zt6._ABI;
                    if (flag2)
                    {
                        bool flag3 = lineIndex + numLines <= _zt6._ABI;
                        if (flag3)
                        {
                            _zt6._ABI -= numLines;
                        }
                        else
                        {
                            _zt6._ABI = lineIndex;
                        }
                        this._zt8 = true;
                    }
                }
            }
        }

        // Token: 0x060000F7 RID: 247 RVA: 0x0000C691 File Offset: 0x0000A891
        protected void OnLostFocus()
        {
            this._zq2 = false;
        }

        // Token: 0x060000F8 RID: 248 RVA: 0x0000C69C File Offset: 0x0000A89C
        private void Update()
        {
            this._zq2 = true;
            bool flag = base.titleContent.tooltip != this._zn9;
            if (flag)
            {
                this._zn9 = _bb6.StringCheck(this._zn9);
                base.titleContent.tooltip = this._zn9;
            }
            bool _zt9 = this._zt8;
            if (_zt9)
            {
                this._zt8 = false;
                base.Repaint();
            }
            else
            {
                bool flag2 = this._zo1 != null && this._zq3 < this._zo2.Count;
                if (flag2)
                {
                    List<string> _zq4 = this._zo2;
                    int num = this._zq3;
                    this._zq3 = num + 1;
                    string text = _zq4[num];
                    bool flag3 = this._zq5 != null;
                    if (flag3)
                    {
                        while (text != null && !this._zq5(text, this._zo4))
                        {
                            this._zq6.Add(text);
                            bool flag4 = this._zq3 < this._zo2.Count;
                            if (flag4)
                            {
                                List<string> _zq7 = this._zo2;
                                num = this._zq3;
                                this._zq3 = num + 1;
                                text = _zq7[num];
                            }
                            else
                            {
                                text = null;
                            }
                        }
                    }
                    bool flag5 = text != null;
                    if (flag5)
                    {
                        this._zo1(new Action<string, string, TextPosition, int>(this.AddResult), text, this._zo3);
                        return;
                    }
                }
                bool flag6 = this._zo1 != null && this._zq3 == this._zo2.Count;
                if (flag6)
                {
                    this._zo2.Clear();
                    this._zq3 = 1;
                    bool flag7 = this._zr2 != null && base.titleContent.text != "Rename";
                    if (flag7)
                    {
                        this._zn9 = "References to " + this._zr2._AYM();
                        this._zu1 = "References to " + this._zr2._AYM();
                    }
                    else
                    {
                        bool flag8 = this._zu1 != "";
                        if (flag8)
                        {
                            this._zn9 = this._zu1;
                        }
                        else
                        {
                            bool flag9 = base.titleContent.text.Contains("Find Results");
                            if (flag9)
                            {
                                this._zn9 = "Find results for '" + this._zo3._ABG + "'";
                            }
                            else
                            {
                                bool flag10 = base.titleContent.text == "Replace";
                                if (flag10)
                                {
                                    this._zn9 = string.Concat(new string[]
                                    {
                                        "Replace '",
                                        this._zo3._ABG,
                                        "' to '",
                                        this._AVV,
                                        "'"
                                    });
                                }
                                else
                                {
                                    bool flag11 = base.titleContent.text == "Rename";
                                    if (flag11)
                                    {
                                        this._zn9 = string.Concat(new string[]
                                        {
                                            "Rename '",
                                            this._zo3._ABG,
                                            "' to '",
                                            this._AVV,
                                            "'"
                                        });
                                    }
                                }
                            }
                        }
                    }
                    this._zr9 = this._zs4 > 0;
                    bool _zu2 = this._zr6;
                    if (_zu2)
                    {
                        this._zr6 = false;
                        this.ReplaceAll(false);
                        bool flag12 = this._zr7;
                        if (flag12)
                        {
                            this._zr7.Focus();
                        }
                        this._zr7 = null;
                    }
                    else
                    {
                        base.Repaint();
                    }
                }
            }
        }

        // Token: 0x060000F9 RID: 249 RVA: 0x0000CA20 File Offset: 0x0000AC20
        private void ReplaceAll(bool isRename = false)
        {
            this.Unsubscribe();
            GCE _AMX = null;
            string guid = null;
            bool flag = true;
            HashSet<GCE> hashSet = new HashSet<GCE>();
            List<_bk5._zt5> list;
            if (isRename)
            {
                list = new List<_bk5._zt5>();
                foreach (_bk5._zt5 _zt6 in this._zs2)
                {
                    bool flag2 = _zt6._ABI != 0;
                    if (flag2)
                    {
                        list.Add(_zt6);
                    }
                }
            }
            else
            {
                list = this._zs3;
            }
            int count = list.Count;
            Func<_bb6, bool> tempBool3 = null;
            while (count-- > 0)
            {
                _bk5._zt5 _zu3 = list[count];
                bool flag3 = !_zu3._BCL;
                if (!flag3)
                {
                    bool flag4 = _zu3._ADF != guid;
                    if (flag4)
                    {
                        guid = _zu3._ADF;
                        _AMX = _bc5.GetBuffer(guid);
                        bool flag5 = _AMX._ARV();
                        if (flag5)
                        {
                            _AMX.LoadImmediately();
                        }
                        IEnumerable<_bb6> enumerable = _bb6._AJZ();
                        Func<_bb6, bool> func = tempBool3;
                        if ((func) == null)
                        {
                            func = (tempBool3 = (_bb6 x) => x.LPDN() != guid);
                        }
                        bool flag6 = enumerable.All(func);
                        if (flag6)
                        {
                            _bb6 _AKB = _bb6.OpenAssetInTab(guid, !_bg8.EAIK.GNIO());
                            bool flag7 = _AKB;
                            if (flag7)
                            {
                                _AKB.OnFirstUpdate();
                            }
                        }
                        bool flag8 = !_AMX.TryEdit();
                        if (flag8)
                        {
                            flag = false;
                        }
                        else
                        {
                            hashSet.Add(_AMX);
                        }
                    }
                }
            }
            bool flag9 = !flag;
            if (flag9)
            {
                bool flag10 = !EditorUtility.DisplayDialog("Replace", "Some assets are locked and cannot be edited!", "Continue Anyway", "Cancel");
                if (flag10)
                {
                    base.Close();
                    return;
                }
            }
            _AMX = null;
            guid = null;
            HashSet<int> hashSet2 = new HashSet<int>();
            int count2 = list.Count;
            while (count2-- > 0)
            {
                _bk5._zt5 _zu4 = list[count2];
                bool flag11 = !_zu4._BCL;
                if (!flag11)
                {
                    bool flag12 = _zu4._ADF != guid;
                    if (flag12)
                    {
                        bool flag13 = _AMX != null;
                        if (flag13)
                        {
                            foreach (int num in hashSet2)
                            {
                                _AMX.UpdateHighlighting(num, num, false);
                            }
                            _AMX.EndEdit();
                            _bc5.AddBufferToGlobalUndo(_AMX);
                            hashSet2.Clear();
                        }
                        guid = _zu4._ADF;
                        _AMX = _bc5.GetBuffer(guid);
                        bool flag14 = _AMX != null;
                        if (flag14)
                        {
                            bool flag15 = hashSet.Contains(_AMX);
                            if (flag15)
                            {
                                _AMX.BeginEdit("*Replace All");
                            }
                            else
                            {
                                _AMX = null;
                            }
                        }
                    }
                    bool flag16 = _AMX != null;
                    if (flag16)
                    {
                        GCE._AFA _ATD = new GCE._AFA
                        {
                            _ABI = _zu4._ABI,
                            _AEU = _zu4._AEU
                        };
                        GCE._AFA _ATD2 = new GCE._AFA
                        {
                            _ABI = _zu4._ABI,
                            _AEU = _zu4._AEU + _zu4._zu5
                        };
                        GCE._AFA _ATD3 = _AMX.DeleteText(_ATD, _ATD2);
                        bool flag17 = base.titleContent.text == "Replace" || base.titleContent.text == "Rename";
                        if (flag17)
                        {
                            _AMX.InsertText(_ATD3, this._AVV);
                        }
                        hashSet2.Add(_zu4._ABI);
                    }
                }
            }
            bool flag18 = _AMX != null;
            if (flag18)
            {
                foreach (int num2 in hashSet2)
                {
                    _AMX.UpdateHighlighting(num2, num2, false);
                }
                _AMX.EndEdit();
                _bc5.AddBufferToGlobalUndo(_AMX);
            }
            _bc5.RecordGlobalUndo();
            base.Close();
        }

        // Token: 0x060000FA RID: 250 RVA: 0x0000CE58 File Offset: 0x0000B058
        private bool CheckFiltering(_bk5._zu6 resultType)
        {
            bool flag;
            switch (resultType)
            {
                case (_bk5._zu6)2:
                    flag = this._zo4._zo7;
                    break;
                case (_bk5._zu6)3:
                    flag = this._zo4._zo6;
                    break;
                case (_bk5._zu6)4:
                    flag = this._zo4._zo6 || this._zo4._zo7;
                    break;
                case (_bk5._zu6)5:
                    flag = this._zo4._zm3;
                    break;
                case (_bk5._zu6)6:
                    flag = this._zo4._zo8;
                    break;
                case (_bk5._zu6)7:
                    flag = this._zo4._zo9;
                    break;
                case (_bk5._zu6)8:
                    flag = this._zo4._zp1;
                    break;
                case (_bk5._zu6)9:
                    flag = this._zo4._zp2;
                    break;
                case (_bk5._zu6)10:
                    flag = this._zo4._zp3;
                    break;
                case (_bk5._zu6)11:
                    flag = this._zo4._zp3 && (this._zo4._zp1 || this._zo4._zp2);
                    break;
                case (_bk5._zu6)12:
                    flag = this._zo4._zp4;
                    break;
                case (_bk5._zu6)13:
                    flag = this._zo4._zu7;
                    break;
                case (_bk5._zu6)14:
                    flag = this._zo4._zu8;
                    break;
                default:
                    flag = true;
                    break;
            }
            return flag;
        }

        // Token: 0x060000FB RID: 251 RVA: 0x0000CFA8 File Offset: 0x0000B1A8
        private void UpdateFilters()
        {
            bool flag = this._zs3.Count > 0;
            if (flag)
            {
                this._zs2.Clear();
                this._zs4 = 0;
                this._zs5 = 0;
                for (int i = 0; i < this._zs3.Count; i++)
                {
                    _bk5._zt5 _zt6 = this._zs3[i];
                    _zt6._zu9 = default(Rect);
                    _bk5._zu6 _zv1 = _zt6._zv2;
                    bool flag2 = _zv1 == (_bk5._zu6)1;
                    if (!flag2)
                    {
                        bool flag3 = !this.CheckFiltering(_zv1);
                        if (!flag3)
                        {
                            string text = ((this._zs2.Count > 0) ? this._zs2[this._zs2.Count - 1]._ADF : null);
                            bool flag4 = _zt6._ADF != text;
                            if (flag4)
                            {
                                this._zs5++;
                                bool flag5 = this._zn3();
                                if (flag5)
                                {
                                    this._zs2.Add(new _bk5._zt5
                                    {
                                        _ADF = _zt6._ADF,
                                        _AMO = AssetDatabase.GUIDToAssetPath(_zt6._ADF),
                                        _BCL = true
                                    });
                                }
                            }
                            else
                            {
                                bool flag6 = text == null;
                                if (flag6)
                                {
                                    this._zs5++;
                                }
                            }
                            this._zs2.Add(_zt6);
                            this._zs4++;
                            bool flag7 = this._zs4 <= 1 && this._zs5 <= 1;
                            if (flag7)
                            {
                                this._zr8 = string.Concat(new string[]
                                {
                                    "Found ",
                                    this._zs4.ToString(),
                                    " result in ",
                                    this._zs5.ToString(),
                                    " file."
                                });
                            }
                            else
                            {
                                bool flag8 = this._zs4 > 1 && this._zs5 < 2;
                                if (flag8)
                                {
                                    this._zr8 = string.Concat(new string[]
                                    {
                                        "Found ",
                                        this._zs4.ToString(),
                                        " results in ",
                                        this._zs5.ToString(),
                                        " file."
                                    });
                                }
                                else
                                {
                                    this._zr8 = string.Concat(new string[]
                                    {
                                        "Found ",
                                        this._zs4.ToString(),
                                        " results in ",
                                        this._zs5.ToString(),
                                        " files."
                                    });
                                }
                            }
                        }
                    }
                }
                bool flag9 = this._zr2 != null && base.titleContent.text != "Rename";
                if (flag9)
                {
                    this._zn9 = "References to " + this._zr2._AYM();
                    this._zu1 = "References to " + this._zr2._AYM();
                }
                else
                {
                    bool flag10 = this._zu1 != "";
                    if (flag10)
                    {
                        this._zn9 = this._zu1;
                    }
                    else
                    {
                        bool flag11 = base.titleContent.text.Contains("Find Results");
                        if (flag11)
                        {
                            this._zn9 = "Find results for '" + this._zo3._ABG + "'";
                        }
                        else
                        {
                            bool flag12 = base.titleContent.text == "Replace";
                            if (flag12)
                            {
                                this._zn9 = string.Concat(new string[]
                                {
                                    "Replace '",
                                    this._zo3._ABG,
                                    "' to '",
                                    this._AVV,
                                    "'"
                                });
                            }
                            else
                            {
                                bool flag13 = base.titleContent.text == "Rename";
                                if (flag13)
                                {
                                    this._zn9 = string.Concat(new string[]
                                    {
                                        "Rename '",
                                        this._zo3._ABG,
                                        "' to '",
                                        this._AVV,
                                        "'"
                                    });
                                }
                            }
                        }
                    }
                }
                this._zr9 = this._zs4 > 0;
            }
            bool flag14 = this._zq6.Count > 0;
            if (flag14)
            {
                bool flag15 = this._zq3 > this._zo2.Count;
                if (flag15)
                {
                    this._zq3 = this._zo2.Count;
                }
                this._zo2.AddRange(this._zq6);
                this._zq6.Clear();
                this._zr9 = true;
            }
            this._zq1 = 0f;
        }

        // Token: 0x060000FC RID: 252 RVA: 0x0000D434 File Offset: 0x0000B634
        private void AddResult(string text, string guid, TextPosition location, int length)
        {
            try
            {
                _bk5._zu6 _zv3 = (_bk5._zu6)0;
                bool flag = this._zr1 != null;
                if (flag)
                {
                    _zv3 = this._zr1(guid, location, length, ref this._zr2);
                    bool flag2 = _zv3 == (_bk5._zu6)1;
                    if (flag2)
                    {
                        return;
                    }
                }
                bool flag3 = this.CheckFiltering(_zv3);
                bool flag4 = !char.IsWhiteSpace(text, location.index) && !char.IsWhiteSpace(text, location.index + length - 1);
                bool flag5 = flag3;
                if (flag5)
                {
                    string text2 = ((this._zs2.Count > 0) ? this._zs2[this._zs2.Count - 1]._ADF : null);
                    bool flag6 = guid != text2;
                    if (flag6)
                    {
                        this._zs5++;
                        bool flag7 = this._zn3();
                        if (flag7)
                        {
                            this._zs2.Add(new _bk5._zt5
                            {
                                _ADF = guid,
                                _AMO = AssetDatabase.GUIDToAssetPath(guid),
                                _BCL = true
                            });
                        }
                    }
                    else
                    {
                        bool flag8 = text2 == null;
                        if (flag8)
                        {
                            this._zs5++;
                        }
                    }
                }
                string text3 = (flag4 ? text.TrimStart(Array.Empty<char>()) : text);
                int num = text.Length - text3.Length;
                text3 = (flag4 ? text3.TrimEnd(Array.Empty<char>()) : text);
                string text4 = AssetDatabase.GUIDToAssetPath(guid);
                _bk5._zt5 _zt6 = new _bk5._zt5
                {
                    _zt7 = text3,
                    _ADF = guid,
                    _AMO = text4,
                    _BDK = Path.GetFileName(text4),
                    _ABI = location.line,
                    _AEU = location.index,
                    _zu5 = length,
                    _zv4 = num,
                    _zv2 = _zv3,
                    _BCL = true,
                    _zr5 = this._zr5,
                    _zr3 = this._zr3,
                    _zr4 = this._zr4
                };
                bool flag9 = flag3;
                if (flag9)
                {
                    this._zs2.Add(_zt6);
                    this._zs4++;
                    bool flag10 = this._zs4 <= 1 && this._zs5 <= 1;
                    if (flag10)
                    {
                        this._zr8 = string.Concat(new string[]
                        {
                            "Found ",
                            this._zs4.ToString(),
                            " result in ",
                            this._zs5.ToString(),
                            " file."
                        });
                    }
                    else
                    {
                        bool flag11 = this._zs4 > 1 && this._zs5 < 2;
                        if (flag11)
                        {
                            this._zr8 = string.Concat(new string[]
                            {
                                "Found ",
                                this._zs4.ToString(),
                                " results in ",
                                this._zs5.ToString(),
                                " file."
                            });
                        }
                        else
                        {
                            this._zr8 = string.Concat(new string[]
                            {
                                "Found ",
                                this._zs4.ToString(),
                                " results in ",
                                this._zs5.ToString(),
                                " files."
                            });
                        }
                    }
                }
                this._zs3.Add(_zt6);
            }
            finally
            {
            }
            this._zt8 = true;
        }

        // Token: 0x060000FD RID: 253 RVA: 0x0000D788 File Offset: 0x0000B988
        private void GoToResult(int index)
        {
            bool flag = index >= this._zs2.Count;
            if (!flag)
            {
                _bk5._zt5 _zt6 = this._zs2[index];
                _bb6.OpenAssetInTab(_zt6._ADF, _zt6._ABI, _zt6._AEU, _zt6._zu5, !_bg8.EAIK.GNIO());
            }
        }

        // Token: 0x060000FE RID: 254 RVA: 0x0000D7E8 File Offset: 0x0000B9E8
        private void OnGUIKey()
        {
            bool flag = Event.current.type == EventType.KeyDown;
            if (flag)
            {
                bool flag2 = !Event.current.alt && !Event.current.shift && !EditorGUI.actionKey;
                if (flag2)
                {
                    bool flag3 = (int)Event.current.keyCode == 27;
                    if (flag3)
                    {
                        string text = _bb6.GetGuidHistory().FirstOrDefault<string>();
                        bool flag4 = !string.IsNullOrEmpty(text);
                        if (flag4)
                        {
                            _bb6.OpenAssetInTab(text, !_bg8.EAIK.GNIO());
                        }
                    }
                }
                bool flag5 = EditorGUI.actionKey && (int)Event.current.keyCode == 119;
                if (flag5)
                {
                    Event.current.Use();
                    base.Close();
                }
                bool flag6 = Event.current.alt && (int)Event.current.keyCode == 13;
                if (flag6)
                {
                    Event.current.Use();
                    base.maximized = !base.maximized;
                    GUIUtility.ExitGUI();
                }
                int num = this._ADS;
                bool flag7 = (int)Event.current.keyCode == 274;
                if (flag7)
                {
                    num++;
                    bool flag8 = this._zn3();
                    if (flag8)
                    {
                        while (num < this._zs2.Count && this._zs2[num]._zt7 != null && this._zs6.Contains(this._zs2[num]._AMO))
                        {
                            num++;
                        }
                    }
                    bool flag9 = num == this._zs2.Count;
                    if (flag9)
                    {
                        num = this._ADS;
                    }
                    bool flag10 = num >= 0 && this._zs2[num]._zt7 != null;
                    if (flag10)
                    {
                        this.GoToResult(num);
                        base.Focus();
                    }
                }
                else
                {
                    bool flag11 = (int)Event.current.keyCode == 275 && this._ADS < this._zs2.Count;
                    if (flag11)
                    {
                        bool flag12 = this._zs2[this._ADS]._zt7 == null && this._zs6.Contains(this._zs2[this._ADS]._AMO);
                        if (flag12)
                        {
                            this._zs6.Remove(this._zs2[this._ADS]._AMO);
                            this._CIL = true;
                            this._zq1 = 0f;
                        }
                        else
                        {
                            num++;
                        }
                    }
                    else
                    {
                        bool flag13 = (int)Event.current.keyCode == 273;
                        if (flag13)
                        {
                            num--;
                            bool flag14 = this._zn3();
                            if (flag14)
                            {
                                while (num > 0 && this._zs2[num]._zt7 != null && this._zs6.Contains(this._zs2[num]._AMO))
                                {
                                    num--;
                                }
                            }
                            bool flag15 = num >= 0 && this._zs2[num]._zt7 != null;
                            if (flag15)
                            {
                                this.GoToResult(num);
                                base.Focus();
                            }
                        }
                        else
                        {
                            bool flag16 = (int)Event.current.keyCode == 276 && this._ADS < this._zs2.Count;
                            if (flag16)
                            {
                                bool flag17 = this._zs2[this._ADS]._zt7 == null;
                                if (flag17)
                                {
                                    bool flag18 = !this._zs6.Contains(this._zs2[this._ADS]._AMO);
                                    if (flag18)
                                    {
                                        this._zs6.Add(this._zs2[this._ADS]._AMO);
                                    }
                                    this._CIL = true;
                                    this._zq1 = 0f;
                                }
                                else
                                {
                                    bool flag19 = this._zn3();
                                    if (flag19)
                                    {
                                        while (this._zs2[num]._zt7 != null)
                                        {
                                            num--;
                                        }
                                    }
                                    else
                                    {
                                        num--;
                                    }
                                }
                            }
                            else
                            {
                                bool flag20 = (int)Event.current.keyCode == 278;
                                if (flag20)
                                {
                                    num = 0;
                                }
                                else
                                {
                                    bool flag21 = (int)Event.current.keyCode == 279;
                                    if (flag21)
                                    {
                                        num = this._zs2.Count - 1;
                                        bool flag22 = this._zn3();
                                        if (flag22)
                                        {
                                            while (num > 0 && this._zs2[num]._zt7 != null && this._zs6.Contains(this._zs2[num]._AMO))
                                            {
                                                num--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                num = Mathf.Max(0, Mathf.Min(num, this._zs2.Count - 1));
                this._zv5 = this._zv5 || this._CIL || num != this._ADS;
                this._CIL = this._CIL || num != this._ADS;
                this._ADS = num;
                bool flag23 = (int)Event.current.keyCode == 13 || (int)Event.current.keyCode == 271 || (int)Event.current.keyCode == 32;
                if (flag23)
                {
                    bool flag24 = this._ADS < this._zs2.Count;
                    if (flag24)
                    {
                        Event.current.Use();
                        bool flag25 = this._zs2[this._ADS]._zt7 != null;
                        if (flag25)
                        {
                            bool flag26 = this._AVV == "" || (int)Event.current.keyCode != 32;
                            if (flag26)
                            {
                                this.GoToResult(this._ADS);
                            }
                            else
                            {
                                this._zs2[this._ADS]._BCL = !this._zs2[this._ADS]._BCL;
                                this._CIL = true;
                            }
                        }
                        else
                        {
                            string _zv6 = this._zs2[this._ADS]._AMO;
                            bool flag27 = this._zs6.Contains(_zv6);
                            if (flag27)
                            {
                                this._zs6.Remove(_zv6);
                            }
                            else
                            {
                                bool flag28 = !this._zs6.Contains(_zv6);
                                if (flag28)
                                {
                                    this._zs6.Add(_zv6);
                                }
                            }
                            this._CIL = true;
                            this._zq1 = 0f;
                        }
                    }
                }
                else
                {
                    bool _CKJ = this._CIL;
                    if (_CKJ)
                    {
                        Event.current.Use();
                    }
                }
            }
        }

        // Token: 0x060000FF RID: 255 RVA: 0x0000DE98 File Offset: 0x0000C098
        private void OnGUIToolbar()
        {
            bool flag = _bk5._zv7 == null;
            if (flag)
            {
                _bk5._zv7 = new GUIStyle("PR Label");
                _bk5._zv7.padding.top = 2;
                _bk5._zv7.padding.bottom = 2;
                _bk5._zv7.padding.left = 2;
                _bk5._zv7.margin.right = 0;
                _bk5._zv7.fixedHeight = 0f;
                _bk5._zv7.richText = false;
                _bk5._zv7.stretchWidth = true;
                _bk5._zv7.wordWrap = false;
                _bk5._zv8 = new GUIStyle(_bk5._zv7);
                GUIStyle guistyle = "CN EntryBackEven";
                GUIStyle guistyle2 = "CN EntryBackodd";
                _bk5._zv7.normal.background = guistyle.normal.background;
                _bk5._zv7.focused.background = guistyle.normal.background;
                _bk5._zv8.normal.background = guistyle2.normal.background;
                _bk5._zv8.focused.background = guistyle2.normal.background;
                _bk5._zv9 = "PR Ping";
                _bk5._zw1 = new GUIStyle(_bk5._zv9);
                _bk5._zw1.normal.background = _bk5._CEH;
                _bk5._zw2 = "ToggleMixed";
                _bk5._zw3 = new GUIStyle(EditorStyles.toolbarButton);
                _bk5._zw3.fontStyle = (FontStyle)1;
            }
            float num = 26f;
            Rect rect = new Rect(0f, 20f, EditorGUIUtility.currentViewWidth, 1f);
            GUILayout.Space(1f);
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag2 = this._zo2.Count > 0;
            if (flag2)
            {
                rect.width = num;
                rect.x = 0f;
                bool flag3 = GUI.Toggle(rect, false, new GUIContent(_bk5._zt2, "Stop"), _bk5._zw3);
                if (flag3)
                {
                    this._zo1 = null;
                    this._zq3 = 1;
                    this._zo2.Clear();
                    this._zq6.Clear();
                    this._zr6 = false;
                    this._zr7 = null;
                    bool flag4 = this._zr2 != null;
                    if (flag4)
                    {
                        this._zn9 = "Incomplete references to " + this._zr2._AYM();
                    }
                    else
                    {
                        bool flag5 = base.titleContent.text != "Replace";
                        if (flag5)
                        {
                            this._zn9 = "Incomplete find results for '" + this._zo3._ABG + "'";
                        }
                        else
                        {
                            bool flag6 = base.titleContent.text != "Rename";
                            if (flag6)
                            {
                                this._zn9 = string.Concat(new string[]
                                {
                                    "Incomplete search for Replace '",
                                    this._zo3._ABG,
                                    "' to '",
                                    this._AVV,
                                    "'"
                                });
                            }
                            else
                            {
                                this._zn9 = string.Concat(new string[]
                                {
                                    "Incomplete search for Rename '",
                                    this._zo3._ABG,
                                    "' to '",
                                    this._AVV,
                                    "'"
                                });
                            }
                        }
                    }
                    this._zr9 = this._zs4 > 0;
                }
                rect.x = 46f;
                rect.width = base.position.width;
            }
            else
            {
                rect.x = 10f;
                rect.width = base.position.width;
            }
            GUI.Label(rect, this._zr8);
            rect.y = 0f;
            GUI.enabled = this._zr9;
            bool flag7 = this._zn3();
            if (flag7)
            {
                rect.width = num;
                bool flag8 = this._zs6.Count != 0 && this._zs6.Count != this._zs5;
                if (flag8)
                {
                    bool flag9 = this._zr5 != SymbolKind.None || (this._zs3.Count > 0 && this._zs3[0]._zr5 > SymbolKind.None);
                    if (flag9)
                    {
                        rect.x = base.position.width - 5.25f * num + 1f;
                    }
                    else
                    {
                        rect.x = base.position.width - 4f * num + 1f;
                    }
                }
                else
                {
                    bool flag10 = this._zr5 != SymbolKind.None || (this._zs3.Count > 0 && this._zs3[0]._zr5 > SymbolKind.None);
                    if (flag10)
                    {
                        rect.x = base.position.width - 4.25f * num + 1f;
                    }
                    else
                    {
                        rect.x = base.position.width - 3f * num + 1f;
                    }
                }
                bool flag11 = this._zs6.Count != 0 && GUI.Button(rect, new GUIContent(_bk5._zt3, "Expand All"), _bk5._zw3);
                if (flag11)
                {
                    this._zs6.Clear();
                    this._CIL = true;
                    this._zq1 = 0f;
                }
                bool flag12 = this._zr5 != SymbolKind.None || (this._zs3.Count > 0 && this._zs3[0]._zr5 > SymbolKind.None);
                if (flag12)
                {
                    rect.x = base.position.width - 4.25f * num + 1f;
                }
                else
                {
                    rect.x = base.position.width - 3f * num + 1f;
                }
                bool flag13 = this._zs6.Count != this._zs5 && GUI.Button(rect, new GUIContent(_bk5._zt4, "Collapse All"), _bk5._zw3);
                if (flag13)
                {
                    foreach (_bk5._zt5 _zt6 in this._zs2)
                    {
                        bool flag14 = _zt6._zt7 == null;
                        if (flag14)
                        {
                            bool flag15 = !this._zs6.Contains(_zt6._AMO);
                            if (flag15)
                            {
                                this._zs6.Add(_zt6._AMO);
                            }
                        }
                    }
                    this._CIL = true;
                    this._zq1 = 0f;
                }
            }
            GUI.enabled = true;
            bool flag16 = this._zr5 != SymbolKind.None || (this._zs3.Count > 0 && this._zs3[0]._zr5 > SymbolKind.None);
            if (flag16)
            {
                GUIContent guicontent = new GUIContent(_bk5._zs7, "List Filters");
                rect.width = 1.25f * num;
                rect.x = base.position.width - 3.25f * num + 1f;
                bool flag17 = EditorGUI.DropdownButton(rect, guicontent, (FocusType)2, EditorStyles.toolbarPopup);
                if (flag17)
                {
                    GenericMenu genericMenu = new GenericMenu();
                    bool flag18 = this._zr3 || (this._zs3.Count > 0 && this._zs3[0]._zr3);
                    if (flag18)
                    {
                        genericMenu.AddItem(new GUIContent("Read"), this._zo4._zo6, delegate
                        {
                            this._zo4._zo6 = !this._zo4._zo6;
                            this.UpdateFilters();
                        });
                        genericMenu.AddItem(new GUIContent("Write"), this._zo4._zo7, delegate
                        {
                            this._zo4._zo7 = !this._zo4._zo7;
                            this.UpdateFilters();
                        });
                    }
                    else
                    {
                        bool flag19 = this._zr5 == SymbolKind.Method || this._zr5 == SymbolKind.MethodGroup || (this._zs3.Count > 0 && this._zs3[0]._zr5 == SymbolKind.Method) || (this._zs3.Count > 0 && this._zs3[0]._zr5 == SymbolKind.MethodGroup);
                        if (flag19)
                        {
                            genericMenu.AddItem(new GUIContent("References"), this._zo4._zo6, delegate
                            {
                                this._zo4._zo6 = !this._zo4._zo6;
                                this.UpdateFilters();
                            });
                            genericMenu.AddItem(new GUIContent("Overload"), this._zo4._zm3, delegate
                            {
                                this._zo4._zm3 = !this._zo4._zm3;
                                this.UpdateFilters();
                            });
                            genericMenu.AddItem(new GUIContent("Overridden"), this._zo4._zo9, delegate
                            {
                                this._zo4._zo9 = !this._zo4._zo9;
                                this.UpdateFilters();
                            });
                            genericMenu.AddItem(new GUIContent("Overriding"), this._zo4._zo8, delegate
                            {
                                this._zo4._zo8 = !this._zo4._zo8;
                                this.UpdateFilters();
                            });
                        }
                        else
                        {
                            genericMenu.AddItem(new GUIContent("References"), this._zo4._zo6, delegate
                            {
                                this._zo4._zo6 = !this._zo4._zo6;
                                this.UpdateFilters();
                            });
                            bool _zw4 = this._zr4;
                            if (_zw4)
                            {
                                genericMenu.AddItem(new GUIContent("Var"), this._zo4._zp1, delegate
                                {
                                    this._zo4._zp1 = !this._zo4._zp1;
                                    this.UpdateFilters();
                                });
                                genericMenu.AddItem(new GUIContent("Var<T>"), this._zo4._zp2, delegate
                                {
                                    this._zo4._zp2 = !this._zo4._zp2;
                                    this.UpdateFilters();
                                });
                            }
                        }
                    }
                    genericMenu.AddItem(new GUIContent("#if"), this._zo4._zp4, delegate
                    {
                        this._zo4._zp4 = !this._zo4._zp4;
                        this.UpdateFilters();
                    });
                    genericMenu.AddItem(new GUIContent("String"), this._zo4._zu8, delegate
                    {
                        this._zo4._zu8 = !this._zo4._zu8;
                        this.UpdateFilters();
                    });
                    genericMenu.AddItem(new GUIContent("Comment"), this._zo4._zu7, delegate
                    {
                        this._zo4._zu7 = !this._zo4._zu7;
                        this.UpdateFilters();
                    });
                    genericMenu.ShowAsContext();
                }
            }
            GUI.enabled = this._zr9;
            rect.width = num;
            rect.x = base.position.width - 2f * num + 1f;
            bool flag20 = GUI.Toggle(rect, this._zn3(), new GUIContent(_bk5._zs8, "Group by file"), _bk5._zw3);
            GUI.enabled = true;
            rect.width = num;
            rect.x = base.position.width - num + 1f;
            bool flag21 = base.titleContent.text == "Replace";
            if (flag21)
            {
                GUI.enabled = this._zo2.Count == 0 && this._zr9;
                bool flag22 = GUI.Toggle(rect, false, new GUIContent(_bk5._zs9, "Replace all selected"), _bk5._zw3);
                if (flag22)
                {
                    this.ReplaceAll(false);
                }
                GUI.enabled = true;
            }
            else
            {
                bool flag23 = base.titleContent.text == "Rename";
                if (flag23)
                {
                    GUI.enabled = this._zo2.Count == 0 && this._zr9;
                    bool flag24 = GUI.Toggle(rect, false, new GUIContent(_bk5._zs9, "Rename all"), _bk5._zw3);
                    if (flag24)
                    {
                        this.ReplaceAll(true);
                    }
                    GUI.enabled = true;
                }
                else
                {
                    GUI.enabled = this._zr9;
                    this._zn2 = GUI.Toggle(rect, this._zn2, new GUIContent(_bk5._zt1, "Pin results window"), _bk5._zw3);
                    GUI.enabled = true;
                }
            }
            GUILayout.EndHorizontal();
            bool flag25 = flag20 != this._zn3();
            if (flag25)
            {
                _bk5._zt5 _zu3 = ((this._ADS < this._zs2.Count) ? this._zs2[this._ADS] : null);
                bool flag26 = _zu3 != null && _zu3._zt7 == null;
                if (flag26)
                {
                    _zu3 = this._zs2[this._ADS + 1];
                }
                this._zn5(flag20);
                this.UpdateFilters();
                bool flag27 = _zu3 != null;
                if (flag27)
                {
                    this._ADS = Mathf.Max(0, this._zs2.IndexOf(_zu3));
                }
                else
                {
                    this._ADS = 0;
                }
                this._CIL = true;
                this._zq1 = 0f;
                this._zv5 = true;
            }
            Rect rect2 = new Rect(0f, 20f, EditorGUIUtility.currentViewWidth, 1f);
            Color color = (EditorGUIUtility.isProSkin ? new Color(0f, 0f, 0f, 0.35f) : new Color(0f, 0f, 0f, 0.25f));
            EditorGUI.DrawRect(rect2, color);
            bool flag28 = Event.current.type == EventType.Repaint && this._zo2.Count > 0;
            if (flag28)
            {
                float num2 = ((float)this._zq3 + 1f + (float)this._zq6.Count) / (float)this._zo2.Count;
                Rect rect3 = rect2;
                rect3.yMin = rect3.yMax - 1f;
                rect3.width *= num2;
                rect3.height = 1f;
                Color32 color2 = new Color32(108, 226, 108, byte.MaxValue);
                Color color3 = GUI.color;
                GUI.color *= color2;
                GUI.DrawTexture(rect3, EditorGUIUtility.whiteTexture);
                GUI.color = color3;
            }
            this._zs1 = base.position.height - 20f;
        }

        // Token: 0x06000100 RID: 256 RVA: 0x0000ECA0 File Offset: 0x0000CEA0
        private void OnGUI()
        {
            this.OnGUIKey();
            this.OnGUIToolbar();
            GUILayout.Space(20f);
            this._AFS = GUILayout.BeginScrollView(this._AFS, _bk5._zw5);
            Vector2 _zw6 = this._AFS;
            EditorGUIUtility.SetIconSize(new Vector2(16f, 16f));
            bool flag = !this._zr9;
            if (flag)
            {
                GUILayout.Label("No Results...", Array.Empty<GUILayoutOption>());
            }
            else
            {
                bool flag2 = true;
                int num = 0;
                for (int i = 0; i < this._zs2.Count; i++)
                {
                    _bk5._zt5 _zt6 = this._zs2[i];
                    bool flag3 = _zt6._zt7 != null && !flag2;
                    if (!flag3)
                    {
                        GUIStyle guistyle = (((num & 1) == 0) ? _bk5._zv7 : _bk5._zv8);
                        num++;
                        Rect rect = GUILayoutUtility.GetRect(GUIContent.none, guistyle, _bk5._zw7);
                        rect.xMin = 0f;
                        bool flag4 = Event.current.type == EventType.Repaint;
                        if (flag4)
                        {
                            guistyle.Draw(rect, GUIContent.none, false, false, i == this._ADS, this == EditorWindow.focusedWindow);
                        }
                        bool flag5 = _zt6._zt7 == null;
                        if (flag5)
                        {
                            string _zv6 = _zt6._AMO;
                            flag2 = !this._zs6.Contains(_zv6);
                            Rect rect2 = rect;
                            rect2.xMin = 4f;
                            rect2.xMax = 22f;
                            rect2.yMin += 3f;
                            bool flag6 = GUI.Toggle(rect2, flag2, GUIContent.none, EditorStyles.foldout);
                            bool flag7 = flag6 != flag2;
                            if (flag7)
                            {
                                this._ADS = i;
                                bool flag8 = flag6 && !flag2;
                                if (flag8)
                                {
                                    this._zs6.Remove(_zv6);
                                }
                                else
                                {
                                    bool flag9 = !flag6 && flag2;
                                    if (flag9)
                                    {
                                        this._zs6.Add(_zv6);
                                    }
                                }
                                this._CIL = true;
                                this._zq1 = 0f;
                            }
                            bool flag10 = base.titleContent.text == "Replace";
                            if (flag10)
                            {
                                rect.xMin += 18f;
                                rect2 = rect;
                                rect2.width = 18f;
                                rect2.yMin += 2f;
                                bool flag11 = false;
                                bool flag12 = false;
                                int num2 = i + 1;
                                while (num2 < this._zs2.Count && (!flag11 || !flag12))
                                {
                                    _bk5._zt5 _zu3 = this._zs2[num2];
                                    bool flag13 = _zu3._zt7 == null;
                                    if (flag13)
                                    {
                                        break;
                                    }
                                    bool _zw8 = _zu3._BCL;
                                    if (_zw8)
                                    {
                                        flag11 = true;
                                    }
                                    else
                                    {
                                        flag12 = true;
                                    }
                                    num2++;
                                }
                                bool flag14 = flag11;
                                bool flag15 = flag14 != GUI.Toggle(rect2, flag14, GUIContent.none, (flag11 && flag12) ? _bk5._zw2 : EditorStyles.toggle);
                                if (flag15)
                                {
                                    flag14 = !flag14;
                                    for (int j = i + 1; j < this._zs2.Count; j++)
                                    {
                                        _bk5._zt5 _zu4 = this._zs2[j];
                                        bool flag16 = _zu4._zt7 == null;
                                        if (flag16)
                                        {
                                            break;
                                        }
                                        _zu4._BCL = flag14;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool flag17 = base.titleContent.text == "Replace";
                            if (flag17)
                            {
                                bool flag18 = this._zn3();
                                if (flag18)
                                {
                                    rect.xMin += 36f;
                                }
                                else
                                {
                                    rect.xMin += 4f;
                                }
                                Rect rect3 = rect;
                                rect3.width = 18f;
                                rect3.yMin += 2f;
                                _zt6._BCL = GUI.Toggle(rect3, _zt6._BCL, GUIContent.none);
                            }
                        }
                        bool flag19 = this._zv5 && i == this._ADS && Event.current.type == EventType.Repaint;
                        if (flag19)
                        {
                            bool flag20 = rect.yMin < this._AFS.y;
                            if (flag20)
                            {
                                _zw6.y = rect.yMin;
                                this._CIL = true;
                            }
                            else
                            {
                                bool flag21 = rect.yMax > this._AFS.y + this._zs1;
                                if (flag21)
                                {
                                    _zw6.y = rect.yMax - this._zs1 + 20f;
                                    this._CIL = true;
                                }
                            }
                        }
                        bool flag22 = rect.yMax < this._AFS.y || rect.yMin > this._AFS.y + this._zs1;
                        if (!flag22)
                        {
                            bool flag23 = rect.Contains(Event.current.mousePosition);
                            if (flag23)
                            {
                                bool flag24 = Event.current.button == 0 && (Event.current.clickCount == 1 || Event.current.clickCount == 2);
                                if (flag24)
                                {
                                    bool flag25 = _zt6._zt7 == null;
                                    if (flag25)
                                    {
                                        bool flag26 = Event.current.clickCount == 2;
                                        if (flag26)
                                        {
                                            bool flag27 = this._zs6.Contains(_zt6._AMO);
                                            if (flag27)
                                            {
                                                this._zs6.Remove(_zt6._AMO);
                                            }
                                            else
                                            {
                                                this._zs6.Add(_zt6._AMO);
                                            }
                                            this._CIL = true;
                                            this._zq1 = 0f;
                                        }
                                    }
                                    else
                                    {
                                        bool flag28 = Event.current.clickCount == 2;
                                        if (flag28)
                                        {
                                            _bb6.OpenAssetInTab(_zt6._ADF, _zt6._ABI, _zt6._AEU, _zt6._zu5, true);
                                        }
                                        else
                                        {
                                            _bb6.OpenAssetInTab(_zt6._ADF, _zt6._ABI, _zt6._AEU, _zt6._zu5, !_bg8.EAIK.GNIO());
                                            base.Focus();
                                        }
                                    }
                                }
                                this._ADS = i;
                                this._CIL = true;
                                this._zv5 = true;
                                bool flag30 = Event.current.type != EventType.Repaint;
                                if (flag30)
                                {
                                    Event.current.Use();
                                }
                            }
                            int num3 = 0;
                            bool flag29 = _zt6._zt7 == null;
                            GUIContent guicontent;
                            if (flag29)
                            {
                                guicontent = new GUIContent(_zt6._AMO, AssetDatabase.GetCachedIcon(_zt6._AMO));
                                rect.xMin += 16f;
                            }
                            else
                            {
                                bool flag30 = this._zn3();
                                string text;
                                if (flag30)
                                {
                                    text = (_zt6._ABI + 1).ToString() + ":   ";
                                }
                                else
                                {
                                    text = _zt6._BDK + " (" + (_zt6._ABI + 1).ToString() + "):   ";
                                }
                                num3 = text.Length;
                                guicontent = new GUIContent(text + _zt6._zt7);
                                bool flag31 = this._zn3();
                                if (flag31)
                                {
                                    rect.xMin += 18f;
                                }
                                else
                                {
                                    bool flag32 = base.titleContent.text == "Replace";
                                    if (flag32)
                                    {
                                        rect.xMin += 18f;
                                    }
                                    else
                                    {
                                        rect.xMin += 2f;
                                    }
                                }
                            }
                            bool flag33 = Event.current.type == EventType.Repaint;
                            if (flag33)
                            {
                                bool flag34 = _zt6._zt7 != null;
                                if (flag34)
                                {
                                    bool flag35 = _zt6._zu9.width == 0f;
                                    if (flag35)
                                    {
                                        GUIContent guicontent2 = new GUIContent(".");
                                        GUIContent guicontent3 = new GUIContent(guicontent.text.Substring(0, num3 + _zt6._AEU - _zt6._zv4) + ".");
                                        GUIContent guicontent4 = new GUIContent("." + guicontent.text.Substring(0, num3 + _zt6._AEU + _zt6._zu5 - _zt6._zv4) + ".");
                                        Vector2 vector = guistyle.CalcSize(guicontent2);
                                        Vector2 vector2 = guistyle.CalcSize(guicontent3);
                                        vector2.x -= vector.x;
                                        Vector2 vector3 = guistyle.CalcSize(guicontent4);
                                        vector3.x -= vector.x * 2f;
                                        _zt6._zu9 = new Rect(vector2.x - 4f, 2f, vector3.x - vector2.x + 14f, rect.height - 4f);
                                    }
                                    Rect _zw9 = _zt6._zu9;
                                    _zw9.x += rect.x;
                                    _zw9.y += rect.y;
                                    GUI.color = new Color(1f, 1f, 1f, 0.4f);
                                    Color backgroundColor = GUI.backgroundColor;
                                    bool flag36 = _zt6._zv2 == (_bk5._zu6)3;
                                    if (flag36)
                                    {
                                        GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(14, 69, 131, 162) : new Color32(160, byte.MaxValue, byte.MaxValue, byte.MaxValue));
                                        _bk5._zw1.Draw(_zw9, false, false, false, false);
                                    }
                                    else
                                    {
                                        bool flag37 = _zt6._zv2 == (_bk5._zu6)2 || _zt6._zv2 == (_bk5._zu6)4 || _zt6._zv2 == (_bk5._zu6)5;
                                        if (flag37)
                                        {
                                            GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(131, 14, 69, 162) : new Color32(byte.MaxValue, 160, 160, byte.MaxValue));
                                            _bk5._zw1.Draw(_zw9, false, false, false, false);
                                        }
                                        else
                                        {
                                            bool flag38 = _zt6._zv2 == (_bk5._zu6)8 || _zt6._zv2 == (_bk5._zu6)9 || _zt6._zv2 == (_bk5._zu6)7 || _zt6._zv2 == (_bk5._zu6)6;
                                            if (flag38)
                                            {
                                                bool flag39 = _zt6._zv2 == (_bk5._zu6)8 || _zt6._zv2 == (_bk5._zu6)7;
                                                if (flag39)
                                                {
                                                    GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(14, 131, 69, 162) : new Color32(160, byte.MaxValue, 160, byte.MaxValue));
                                                }
                                                else
                                                {
                                                    GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(131, 69, 131, 162) : new Color32(byte.MaxValue, 160, byte.MaxValue, byte.MaxValue));
                                                }
                                                _bk5._zw1.Draw(_zw9, false, false, false, false);
                                            }
                                            else
                                            {
                                                _bk5._zv9.Draw(_zw9, false, false, false, false);
                                            }
                                        }
                                    }
                                    GUI.backgroundColor = backgroundColor;
                                    GUI.color = Color.white;
                                }
                                GUI.backgroundColor = Color.clear;
                                guistyle.Draw(rect, guicontent, false, false, i == this._ADS, this == EditorWindow.focusedWindow);
                                GUI.backgroundColor = Color.white;
                                bool flag40 = guistyle.CalcSize(guicontent).x > this._zq1;
                                if (flag40)
                                {
                                    this._zq1 = guistyle.CalcSize(guicontent).x;
                                }
                            }
                        }
                    }
                }
            }
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag41 = this._zq1 != 0f && Event.current.type == EventType.Layout;
            if (flag41)
            {
                bool flag42 = base.titleContent.text == "Replace";
                if (flag42)
                {
                    bool flag43 = this._zn3();
                    if (flag43)
                    {
                        GUILayout.Space(this._zq1 + 20f + 36f);
                    }
                    else
                    {
                        GUILayout.Space(this._zq1 + 20f + 4f);
                    }
                }
                else
                {
                    bool flag44 = this._zn3();
                    if (flag44)
                    {
                        GUILayout.Space(this._zq1 + 20f);
                    }
                    else
                    {
                        GUILayout.Space(this._zq1 + 2f);
                    }
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndScrollView();
            bool flag45 = Event.current.type == EventType.Repaint;
            if (flag45)
            {
                bool _CKJ = this._CIL;
                if (_CKJ)
                {
                    this._AFS = _zw6;
                    this._CIL = false;
                    base.Repaint();
                }
                this._zv5 = false;
            }
        }

        // Token: 0x040000DF RID: 223
        internal bool _zr3;

        // Token: 0x040000E0 RID: 224
        internal bool _zr4;

        // Token: 0x040000E1 RID: 225
        internal bool _zq2;

        // Token: 0x040000E2 RID: 226
        internal SymbolKind _zr5;

        // Token: 0x040000E3 RID: 227
        private static GUIStyle _zv7;

        // Token: 0x040000E4 RID: 228
        private static GUIStyle _zv8;

        // Token: 0x040000E5 RID: 229
        private static GUIStyle _zv9;

        // Token: 0x040000E6 RID: 230
        private static GUIStyle _zw1;

        // Token: 0x040000E7 RID: 231
        private static GUIStyle _zw2;

        // Token: 0x040000E8 RID: 232
        private static GUIStyle _zw3;

        // Token: 0x040000E9 RID: 233
        private static readonly GUILayoutOption[] _zw5 = new GUILayoutOption[]
        {
            GUILayout.ExpandWidth(true),
            GUILayout.ExpandHeight(true)
        };

        // Token: 0x040000EA RID: 234
        private static readonly GUILayoutOption[] _zw7 = new GUILayoutOption[]
        {
            GUILayout.Height(21f),
            GUILayout.ExpandWidth(true)
        };

        // Token: 0x040000EB RID: 235
        private static readonly GUILayoutOption[] _zx1 = new GUILayoutOption[] { GUILayout.MaxWidth(26f) };

        // Token: 0x040000EC RID: 236
        private static readonly GUILayoutOption[] _zx2 = new GUILayoutOption[]
        {
            GUILayout.Height(20f),
            GUILayout.MinWidth(0f)
        };

        // Token: 0x040000ED RID: 237
        private static readonly GUILayoutOption[] _zx3 = new GUILayoutOption[] { GUILayout.Height(16f) };

        // Token: 0x040000EE RID: 238
        [SerializeField]
        private string _zn9 = "";

        // Token: 0x040000EF RID: 239
        [SerializeField]
        private string _zr8 = "Found 0 result.";

        // Token: 0x040000F0 RID: 240
        private Action<Action<string, string, TextPosition, int>, string, _bk5._AZL> _zo1;

        // Token: 0x040000F1 RID: 241
        private _bk5._zq9 _zr1;

        // Token: 0x040000F2 RID: 242
        private _bk5._zq8 _zq5;

        // Token: 0x040000F3 RID: 243
        private _bh4 _zr2;

        // Token: 0x040000F4 RID: 244
        [SerializeField]
        private string _zu1 = "";

        // Token: 0x040000F5 RID: 245
        [SerializeField]
        private List<string> _zo2 = new List<string>();

        // Token: 0x040000F6 RID: 246
        [SerializeField]
        private List<string> _zq6 = new List<string>();

        // Token: 0x040000F7 RID: 247
        [SerializeField]
        private _bk5._AZL _zo3 = new _bk5._AZL
        {
            _ABG = ""
        };

        // Token: 0x040000F8 RID: 248
        [SerializeField]
        private _bk5._zo5 _zo4;

        // Token: 0x040000F9 RID: 249
        [SerializeField]
        private bool _zr9;

        // Token: 0x040000FA RID: 250
        [NonSerialized]
        private int _zq3;

        // Token: 0x040000FB RID: 251
        [NonSerialized]
        private bool _zt8;

        // Token: 0x040000FC RID: 252
        [SerializeField]
        private Vector2 _AFS;

        // Token: 0x040000FD RID: 253
        [SerializeField]
        private int _ADS = 0;

        // Token: 0x040000FE RID: 254
        [NonSerialized]
        private bool _zv5;

        // Token: 0x040000FF RID: 255
        [NonSerialized]
        private float _zs1;

        // Token: 0x04000100 RID: 256
        private float _zq1 = 0f;

        // Token: 0x04000101 RID: 257
        [NonSerialized]
        private List<_bk5._zt5> _zs2 = new List<_bk5._zt5>();

        // Token: 0x04000102 RID: 258
        [SerializeField]
        private List<_bk5._zt5> _zs3 = new List<_bk5._zt5>();

        // Token: 0x04000103 RID: 259
        [SerializeField]
        private int _zs4;

        // Token: 0x04000104 RID: 260
        [SerializeField]
        private int _zs5;

        // Token: 0x04000105 RID: 261
        [SerializeField]
        private List<string> _zs6 = new List<string>();

        // Token: 0x04000106 RID: 262
        [SerializeField]
        private bool _zn2;

        // Token: 0x04000107 RID: 263
        [SerializeField]
        private bool _zn4;

        // Token: 0x04000108 RID: 264
        private bool _zx4;

        // Token: 0x04000109 RID: 265
        [SerializeField]
        private string _AVV = "";

        // Token: 0x0400010A RID: 266
        [NonSerialized]
        private bool _zr6;

        // Token: 0x0400010B RID: 267
        [NonSerialized]
        private EditorWindow _zr7;

        // Token: 0x0400010C RID: 268
        private static Texture2D _zs7;

        // Token: 0x0400010D RID: 269
        private static Texture2D _zs8;

        // Token: 0x0400010E RID: 270
        private static Texture2D _zs9;

        // Token: 0x0400010F RID: 271
        private static Texture2D _zt1;

        // Token: 0x04000110 RID: 272
        private static Texture2D _zt2;

        // Token: 0x04000111 RID: 273
        private static Texture2D _zt3;

        // Token: 0x04000112 RID: 274
        private static Texture2D _zt4;

        // Token: 0x04000113 RID: 275
        private static Texture2D _CEH;

        // Token: 0x04000114 RID: 276
        private static HashSet<_bk5> _zn8 = new HashSet<_bk5>();

        // Token: 0x04000115 RID: 277
        private static int _zp8 = 0;

        // Token: 0x04000116 RID: 278
        private static int _zp9 = 0;

        // Token: 0x04000117 RID: 279
        private bool _CIL = false;

        // Token: 0x0200001F RID: 31
        public enum _zu6
        {

        }

        // Token: 0x02000020 RID: 32
        [Serializable]
        internal class _AZL
        {
            // Token: 0x04000119 RID: 281
            public string _ABG;

            // Token: 0x0400011A RID: 282
            public string _zx5;

            // Token: 0x0400011B RID: 283
            public string _zx6;

            // Token: 0x0400011C RID: 284
            public bool _AYS;

            // Token: 0x0400011D RID: 285
            public bool _AZN;
        }

        // Token: 0x02000021 RID: 33
        [Serializable]
        internal class _zo5
        {
            // Token: 0x0400011E RID: 286
            public bool _zo7;

            // Token: 0x0400011F RID: 287
            public bool _zo6;

            // Token: 0x04000120 RID: 288
            public bool _zm3;

            // Token: 0x04000121 RID: 289
            public bool _zo8;

            // Token: 0x04000122 RID: 290
            public bool _zo9;

            // Token: 0x04000123 RID: 291
            public bool _zp1;

            // Token: 0x04000124 RID: 292
            public bool _zp2;

            // Token: 0x04000125 RID: 293
            public bool _zp3;

            // Token: 0x04000126 RID: 294
            public bool _zp4;

            // Token: 0x04000127 RID: 295
            public bool _zu8;

            // Token: 0x04000128 RID: 296
            public bool _zu7;

            // Token: 0x04000129 RID: 297
            public bool _zp5;

            // Token: 0x0400012A RID: 298
            public bool _zp6;

            // Token: 0x0400012B RID: 299
            public bool _zp7;

            // Token: 0x0400012C RID: 300
            public bool _AIC;
        }

        // Token: 0x02000022 RID: 34
        [Serializable]
        private class _zt5
        {
            // Token: 0x0400012D RID: 301
            public bool _zr3;

            // Token: 0x0400012E RID: 302
            public bool _zr4;

            // Token: 0x0400012F RID: 303
            public SymbolKind _zr5;

            // Token: 0x04000130 RID: 304
            public string _zt7;

            // Token: 0x04000131 RID: 305
            public string _ADF;

            // Token: 0x04000132 RID: 306
            public string _AMO;

            // Token: 0x04000133 RID: 307
            public string _BDK;

            // Token: 0x04000134 RID: 308
            public int _ABI;

            // Token: 0x04000135 RID: 309
            public int _AEU;

            // Token: 0x04000136 RID: 310
            public int _zu5;

            // Token: 0x04000137 RID: 311
            public int _zv4;

            // Token: 0x04000138 RID: 312
            public bool _BCL;

            // Token: 0x04000139 RID: 313
            public _bk5._zu6 _zv2;

            // Token: 0x0400013A RID: 314
            public Rect _zu9;
        }

        // Token: 0x02000023 RID: 35
        // (Invoke) Token: 0x06000116 RID: 278
        public delegate _bk5._zu6 _zq9(string guid, TextPosition location, int length, ref _bh4 referencedSymbol);

        // Token: 0x02000024 RID: 36
        // (Invoke) Token: 0x0600011A RID: 282
        public delegate bool _zq8(string guid, _bk5._zo5 options);
    }
}
