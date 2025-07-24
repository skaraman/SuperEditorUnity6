using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000040 RID: 64
    internal class _bg3 : EditorWindow
    {
        // Token: 0x060001BB RID: 443 RVA: 0x000173B4 File Offset: 0x000155B4
        [MenuItem("Window/Super Editor/Find in Files... _&%#f", false, 502)]
        internal static void ShowFindInFilesWindow()
        {
            bool flag = _bg3._AA != null && !_bg3._AA._AYN;
            if (!flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                {
                    bool flag2 = _bg3._AA != null;
                    if (flag2)
                    {
                        _bg3._AA._AYN = false;
                        _bg3._AA._AYO = true;
                        _bg3._AA.Repaint();
                    }
                    else
                    {
                        _bg3.Create(false);
                    }
                }));
            }
        }

        // Token: 0x060001BC RID: 444 RVA: 0x00017418 File Offset: 0x00015618
        internal static void ShowReplaceInFilesWindow()
        {
            bool flag = _bg3._AA != null && _bg3._AA._AYN;
            if (!flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                {
                    bool flag2 = _bg3._AA != null;
                    if (flag2)
                    {
                        _bg3._AA._AYN = true;
                        _bg3._AA._AYP = true;
                        _bg3._AA.Repaint();
                    }
                    else
                    {
                        _bg3.Create(true);
                    }
                }));
            }
        }

        // Token: 0x060001BD RID: 445 RVA: 0x0001747C File Offset: 0x0001567C
        internal static void Create(bool replace)
        {
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            _bg3 window = EditorWindow.GetWindow<_bg3>(true);
            window._AVP = focusedWindow;
            _bi2 _AVQ = GCE._ALU;
            window._ABF = _AVQ;
            bool flag = _AVQ != null && _AVQ._ATW() != null && _AVQ._ATW()._ABI == _AVQ._ABH._ABI;
            if (flag)
            {
                int num = Mathf.Min(_AVQ._ATW()._AEU, _AVQ._ABH._AEU);
                int num2 = Mathf.Max(_AVQ._ATW()._AEU, _AVQ._ABH._AEU);
                window._AVU = _AVQ._ABK().FLOg[_AVQ._ABH._ABI].Substring(num, num2 - num);
            }
            else
            {
                window._AVU = ((_AVQ != null) ? _AVQ.GetSearchTextFromSelection() : "");
            }
            window._AVW = window._AVU;
            window._AVV = null;
            window._AYN = replace;
            bool flag2 = focusedWindow != null;
            if (flag2)
            {
                Vector2 center = focusedWindow.position.center;
                window.position = new Rect((float)((int)(center.x - 160f)), (float)((int)(center.y - 116f)), 320f, 232f);
            }
            window.ShowAuxWindow();
        }

        // Token: 0x060001BE RID: 446 RVA: 0x000175D4 File Offset: 0x000157D4
        private void OnEnable()
        {
            _bg3._AA = this;
            _bg3._AYQ = (FindReplace_LookIn)EditorPrefs.GetInt("SuperEditor.FindReplace.LookIn", 0);
            _bg3._AYR = (FindReplace_LookFor)EditorPrefs.GetInt("SuperEditor.FindReplace.LookFor", 0);
            this._AYS = EditorPrefs.GetBool("SuperEditor.FindReplace.MatchCase", false);
            this._AYT = EditorPrefs.GetBool("SuperEditor.FindReplace.MatchWholeWord", false);
            _bg3._AYU = EditorPrefs.GetBool("SuperEditor.FindReplace.ListResultsInNewWindow", false);
            base.titleContent.text = "Find Text";
            base.minSize = new Vector2(320f, 232f);
            base.maxSize = new Vector2(320f, 232f);
            base.Repaint();
            for (int i = 0; i < _bg3._AYV.Length; i++)
            {
                _bg3._AYV[i] = EditorPrefs.GetString("SuperEditor.SearchHistory_" + i.ToString());
                bool flag = _bg3._AYV[i] == "";
                if (flag)
                {
                    _bg3._AYV[i] = null;
                    break;
                }
            }
            for (int j = 0; j < _bg3._AYW.Length; j++)
            {
                _bg3._AYW[j] = EditorPrefs.GetString("SuperEditor.ReplaceHistory_" + j.ToString());
                bool flag2 = _bg3._AYW[j] == "";
                if (flag2)
                {
                    _bg3._AYW[j] = null;
                    break;
                }
            }
        }

        // Token: 0x060001BF RID: 447 RVA: 0x0001772C File Offset: 0x0001592C
        private void OnDisable()
        {
            EditorPrefs.SetInt("SuperEditor.FindReplace.LookIn", (int)_bg3._AYQ);
            EditorPrefs.SetInt("SuperEditor.FindReplace.LookFor", (int)_bg3._AYR);
            EditorPrefs.SetBool("SuperEditor.FindReplace.MatchCase", this._AYS);
            EditorPrefs.SetBool("SuperEditor.FindReplace.MatchWholeWord", this._AYT);
            EditorPrefs.SetBool("SuperEditor.FindReplace.ListResultsInNewWindow", _bg3._AYU);
            _bg3._AA = null;
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

        // Token: 0x060001C0 RID: 448 RVA: 0x000177E0 File Offset: 0x000159E0
        private void SelectFindHistory(object s)
        {
            string text = (string)s;
            int num = _bg3._AYV.Length;
            while (num-- > 0)
            {
                bool flag = _bg3._AYV[num] == text;
                if (flag)
                {
                    while (num-- > 0)
                    {
                        _bg3._AYV[num + 1] = _bg3._AYV[num];
                    }
                    _bg3._AYV[0] = text;
                    break;
                }
            }
            this._AVU = text;
            this._AYX = 1;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReFocusFindField));
        }

        // Token: 0x060001C1 RID: 449 RVA: 0x00017878 File Offset: 0x00015A78
        private void SelectReplaceHistory(object s)
        {
            string text = (string)s;
            int num = _bg3._AYW.Length;
            while (num-- > 0)
            {
                bool flag = _bg3._AYW[num] == text;
                if (flag)
                {
                    while (num-- > 0)
                    {
                        _bg3._AYW[num + 1] = _bg3._AYW[num];
                    }
                    _bg3._AYW[0] = text;
                    break;
                }
            }
            this._AVV = text;
            this._AYX = 1;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReFocusReplaceField));
        }

        // Token: 0x060001C2 RID: 450 RVA: 0x00017910 File Offset: 0x00015B10
        private void ReFocusFindField()
        {
            bool flag = this._AYX > 0;
            if (flag)
            {
                this._AYX--;
                this._AYY = true;
            }
            else
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReFocusFindField));
                this._AYO = true;
            }
            base.Repaint();
        }

        // Token: 0x060001C3 RID: 451 RVA: 0x00017974 File Offset: 0x00015B74
        private void ReFocusReplaceField()
        {
            bool flag = this._AYX > 0;
            if (flag)
            {
                this._AYX--;
                this._AYY = true;
            }
            else
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReFocusReplaceField));
                this._AYP = true;
            }
            base.Repaint();
        }

        // Token: 0x060001C4 RID: 452 RVA: 0x000179D8 File Offset: 0x00015BD8
        private void ShowFindHistory()
        {
            string text = " _";
            GenericMenu genericMenu = new GenericMenu();
            bool flag = this._AVU != this._AVW && this._AVW.Trim() != "" && this._AVW.IndexOfAny(_bg3._AYZ) < 0;
            if (flag)
            {
                genericMenu.AddItem(new GUIContent(this._AVW + text), false, new GenericMenu.MenuFunction2(this.SelectFindHistory), this._AVW);
            }
            int num = 0;
            while (num < _bg3._AYV.Length && _bg3._AYV[num] != null)
            {
                bool flag2 = this._AVU != _bg3._AYV[num] && _bg3._AYV[num].IndexOfAny(_bg3._AYZ) < 0;
                if (flag2)
                {
                    genericMenu.AddItem(new GUIContent(_bg3._AYV[num] + text), false, new GenericMenu.MenuFunction2(this.SelectFindHistory), _bg3._AYV[num]);
                }
                num++;
            }
            bool flag3 = genericMenu.GetItemCount() > 0;
            if (flag3)
            {
                genericMenu.DropDown(new Rect(14f, 58f, EditorGUIUtility.currentViewWidth - 10f, 18f));
            }
            Event.current.Use();
        }

        // Token: 0x060001C5 RID: 453 RVA: 0x00017B24 File Offset: 0x00015D24
        private void ShowReplaceHistory()
        {
            string text = " _";
            GenericMenu genericMenu = new GenericMenu();
            bool flag = this._AVV != this._AVW && this._AVW.Trim() != "" && this._AVW.IndexOfAny(_bg3._AYZ) < 0;
            if (flag)
            {
                genericMenu.AddItem(new GUIContent(this._AVW + text), false, new GenericMenu.MenuFunction2(this.SelectReplaceHistory), this._AVW);
            }
            int num = 0;
            while (num < _bg3._AYW.Length && _bg3._AYW[num] != null)
            {
                bool flag2 = this._AVV != _bg3._AYW[num] && _bg3._AYW[num].IndexOfAny(_bg3._AYZ) < 0;
                if (flag2)
                {
                    genericMenu.AddItem(new GUIContent(_bg3._AYW[num] + text), false, new GenericMenu.MenuFunction2(this.SelectReplaceHistory), _bg3._AYW[num]);
                }
                num++;
            }
            bool flag3 = genericMenu.GetItemCount() > 0;
            if (flag3)
            {
                genericMenu.DropDown(new Rect(14f, 104f, EditorGUIUtility.currentViewWidth - 10f, 18f));
            }
            Event.current.Use();
        }

        // Token: 0x060001C6 RID: 454 RVA: 0x00017C70 File Offset: 0x00015E70
        private void OnGUI()
        {
            bool flag = (int)Event.current.type == 4;
            if (flag)
            {
                bool flag2 = (int)Event.current.keyCode == 13 || (int)Event.current.keyCode == 271;
                if (flag2)
                {
                    Event.current.Use();
                    bool flag3 = this._AVU != "" && (!this._AYN || this._AVU != this._AVV);
                    if (flag3)
                    {
                        bool _AZA = this._AYN;
                        if (_AZA)
                        {
                            this.ReplaceSelected();
                        }
                        else
                        {
                            this.FindAll();
                        }
                    }
                    return;
                }
                bool flag4 = Event.current.character == '\n';
                if (flag4)
                {
                    Event.current.Use();
                    return;
                }
                bool flag5 = (int)Event.current.keyCode == 27;
                if (flag5)
                {
                    Event.current.Use();
                    base.Close();
                    bool flag6 = this._ABF != null && this._ABF._ABJ();
                    if (flag6)
                    {
                        this._ABF._ABJ().Focus();
                    }
                    else
                    {
                        bool flag7 = this._AVP;
                        if (flag7)
                        {
                            this._AVP.Focus();
                        }
                    }
                    return;
                }
                bool flag8 = (int)Event.current.keyCode == 274;
                if (flag8)
                {
                    bool flag9 = GUI.GetNameOfFocusedControl() == "Find field";
                    if (flag9)
                    {
                        this.ShowFindHistory();
                    }
                    else
                    {
                        bool flag10 = GUI.GetNameOfFocusedControl() == "Replace field";
                        if (flag10)
                        {
                            this.ShowReplaceHistory();
                        }
                    }
                }
                else
                {
                    bool flag11 = EditorGUI.actionKey && (int)Event.current.keyCode == 102;
                    if (flag11)
                    {
                        Event.current.Use();
                        _bg3.ShowFindInFilesWindow();
                        return;
                    }
                    bool flag12 = EditorGUI.actionKey && (int)Event.current.keyCode == 114;
                    if (flag12)
                    {
                        Event.current.Use();
                        _bg3.ShowReplaceInFilesWindow();
                        return;
                    }
                }
            }
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            GUILayout.Space(10f);
            GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
            GUILayout.Space(10f);
            this._AYN = 1 == GUILayout.Toolbar(this._AYN ? 1 : 0, _bg3._AZP, Array.Empty<GUILayoutOption>());
            GUILayout.Space(10f);
            GUILayout.Label("Find:", Array.Empty<GUILayoutOption>());
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            GUI.SetNextControlName("Find field");
            bool _AZB = this._AYO;
            if (_AZB)
            {
                EditorGUI.FocusTextInControl("Find field");
            }
            try
            {
                this._AVU = EditorGUILayout.TextField(this._AVU, Array.Empty<GUILayoutOption>());
            }
            catch
            {
            }
            bool _AZB2 = this._AYO;
            if (_AZB2)
            {
                GUI.FocusControl("Find field");
            }
            this._AYO = false;
            bool flag13 = GUILayout.Button(GUIContent.none, EditorStyles.toolbarDropDown, _bg3._AZO);
            if (flag13)
            {
                this.ShowFindHistory();
            }
            GUILayout.Space(4f);
            GUILayout.EndHorizontal();
            bool _AZA2 = this._AYN;
            if (_AZA2)
            {
                GUILayout.Space(10f);
                GUILayout.Label("Replace:", Array.Empty<GUILayoutOption>());
                this._AVV = this._AVV ?? this._AVU;
                GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
                GUI.SetNextControlName("Replace field");
                bool _AZC = this._AYP;
                if (_AZC)
                {
                    EditorGUI.FocusTextInControl("Replace field");
                }
                try
                {
                    this._AVV = EditorGUILayout.TextField(this._AVV, Array.Empty<GUILayoutOption>());
                }
                catch
                {
                }
                bool _AZC2 = this._AYP;
                if (_AZC2)
                {
                    GUI.FocusControl("Replace field");
                }
                this._AYP = false;
                bool flag14 = GUILayout.Button(GUIContent.none, EditorStyles.toolbarDropDown, _bg3._AZO);
                if (flag14)
                {
                    this.ShowReplaceHistory();
                }
                GUILayout.Space(4f);
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(10f);
            GUI.SetNextControlName("Asset types");
            _bg3._AYR = (FindReplace_LookFor)EditorGUILayout.EnumPopup("Asset types:", _bg3._AYR, Array.Empty<GUILayoutOption>());
            bool _AZD = this._AYY;
            if (_AZD)
            {
                GUI.FocusControl("Asset types");
            }
            this._AYY = false;
            int num = (int)_bg3._AYQ;
            bool flag15 = _bg3._AYQ > FindReplace_LookIn.CurrentTabOnly;
            if (flag15)
            {
                num = 0;
            }
            int num2 = EditorGUILayout.Popup("Search scope:", num, _bg3._AZE, Array.Empty<GUILayoutOption>());
            bool flag16 = num2 != num;
            if (flag16)
            {
                _bg3._AYQ = (FindReplace_LookIn)num2;
            }
            GUILayout.Space(10f);
            this._AYS = EditorGUILayout.ToggleLeft(" Match case", this._AYS, Array.Empty<GUILayoutOption>());
            this._AYT = EditorGUILayout.ToggleLeft(" Match whole words", this._AYT, Array.Empty<GUILayoutOption>());
            bool flag17 = !this._AYN;
            if (flag17)
            {
                _bg3._AYU = EditorGUILayout.ToggleLeft(" List results in a new window", _bg3._AYU, Array.Empty<GUILayoutOption>());
            }
            GUILayout.Space(10f);
            GUI.enabled = this._AVU != "" && (!this._AYN || this._AVU != this._AVV);
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            GUILayout.FlexibleSpace();
            bool _AZA3 = this._AYN;
            if (_AZA3)
            {
                bool flag18 = GUILayout.Button("Replace Selected", Array.Empty<GUILayoutOption>());
                if (flag18)
                {
                    this.ReplaceSelected();
                }
            }
            else
            {
                bool flag19 = GUILayout.Button("Find All", Array.Empty<GUILayoutOption>());
                if (flag19)
                {
                    this.FindAll();
                }
            }
            GUILayout.Space(6f);
            GUI.enabled = true;
            bool flag20 = GUILayout.Button("Cancel", Array.Empty<GUILayoutOption>());
            if (flag20)
            {
                base.Close();
                bool flag21 = this._ABF != null && this._ABF._ABJ();
                if (flag21)
                {
                    this._ABF._ABJ().Focus();
                }
                else
                {
                    bool flag22 = this._AVP;
                    if (flag22)
                    {
                        this._AVP.Focus();
                    }
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(20f);
            GUILayout.EndVertical();
            GUILayout.Space(10f);
            GUILayout.EndHorizontal();
            bool _AZA4 = this._AYN;
            if (_AZA4)
            {
                bool flag23 = base.position.height != 260f;
                if (flag23)
                {
                    base.maxSize = new Vector2(320f, 260f);
                    base.minSize = new Vector2(320f, 260f);
                }
            }
            else
            {
                bool flag24 = base.position.height != 232f;
                if (flag24)
                {
                    base.maxSize = new Vector2(320f, 232f);
                    base.minSize = new Vector2(320f, 232f);
                }
            }
        }

        // Token: 0x060001C7 RID: 455 RVA: 0x00018384 File Offset: 0x00016584
        private void ReplaceAll()
        {
            this.SaveHistory(_bg3._AYW, this._AVV, "SuperEditor.ReplaceHistory_");
            _bk5 _AZF = this.FindAll();
            bool flag = _AZF;
            if (flag)
            {
                _AZF.SetReplaceText(this._AVV);
                _AZF.ReplaceAllAfterSearchAndSetFocus((this._ABF != null && this._ABF._ABJ()) ? this._ABF._ABJ() : this._AVP);
            }
        }

        // Token: 0x060001C8 RID: 456 RVA: 0x00018400 File Offset: 0x00016600
        private void ReplaceSelected()
        {
            this.SaveHistory(_bg3._AYW, this._AVV, "SuperEditor.ReplaceHistory_");
            _bk5 _AZF = this.FindAll();
            bool flag = _AZF;
            if (flag)
            {
                _AZF.SetReplaceText(this._AVV);
            }
        }

        // Token: 0x060001C9 RID: 457 RVA: 0x00018444 File Offset: 0x00016644
        private void SaveHistory(string[] history, string newItem, string preferencePrefix)
        {
            bool flag = newItem.Trim() != "";
            if (flag)
            {
                int num = Array.IndexOf<string>(history, newItem);
                bool flag2 = num < 0;
                if (flag2)
                {
                    num = history.Length - 1;
                }
                int num2 = num;
                while (num2-- > 0)
                {
                    history[num2 + 1] = history[num2];
                }
                history[0] = newItem;
            }
            for (int i = 0; i < history.Length; i++)
            {
                bool flag3 = history[i] != null;
                if (flag3)
                {
                    EditorPrefs.SetString(preferencePrefix + i.ToString(), history[i]);
                }
            }
        }

        // Token: 0x060001CA RID: 458 RVA: 0x000184D8 File Offset: 0x000166D8
        private _bk5 FindAll()
        {
            this.SaveHistory(_bg3._AYV, this._AVU, "SuperEditor.SearchHistory_");
            base.Close();
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
            return this.ListAllResults();
        }

        // Token: 0x060001CB RID: 459 RVA: 0x0001855C File Offset: 0x0001675C
        public _bk5 ListAllResults()
        {
            bool flag = _bg3._AYR == FindReplace_LookFor.AllAssets || _bg3._AYR == FindReplace_LookFor.Shaders || _bg3._AYR == FindReplace_LookFor.TextAssets;
            if (flag)
            {
                bool flag2 = _bg3._AYQ > FindReplace_LookIn.CurrentTabOnly;
                if (flag2)
                {
                    _bg3._AYQ = FindReplace_LookIn.WholeProject;
                }
            }
            bool flag3 = _bg3._AYQ == FindReplace_LookIn.OpenTabsOnly;
            string[] array;
            if (flag3)
            {
                array = (from w in _bb6._AJZ()
                         select w.LPDN()).Distinct<string>().ToArray<string>();
            }
            else
            {
                bool flag4 = _bg3._AYQ == FindReplace_LookIn.CurrentTabOnly;
                if (flag4)
                {
                    array = new string[] { (this._ABF != null) ? this._ABF._AKQ() : _bb6.GetGuidHistory().FirstOrDefault<string>() };
                }
                else
                {
                    bool flag5 = _bg3._AYQ != FindReplace_LookIn.WholeProject && _bg3._AYR != FindReplace_LookFor.AllAssets && _bg3._AYR != FindReplace_LookFor.Shaders && _bg3._AYR != FindReplace_LookFor.TextAssets;
                    if (flag5)
                    {
                        bool flag6 = _bh6._AOT != null;
                        if (flag6)
                        {
                            _bh6._AOT.Clear();
                        }
                        bool flag7 = _bg3._AYQ == FindReplace_LookIn.FirstPassGameAssemblies || _bg3._AYQ == FindReplace_LookIn.AllGameAssemblies;
                        if (flag7)
                        {
                            bool flag8 = _bg3._AYR == FindReplace_LookFor.CSharpScripts || _bg3._AYR == FindReplace_LookFor.AllScriptTypes;
                            if (flag8)
                            {
                                _bh6.FindAllAssemblyScripts((_bj5._AZG)2);
                            }
                        }
                        bool flag9 = _bg3._AYQ == FindReplace_LookIn.GameAssemblies || _bg3._AYQ == FindReplace_LookIn.AllGameAssemblies;
                        if (flag9)
                        {
                            bool flag10 = _bg3._AYR == FindReplace_LookFor.CSharpScripts || _bg3._AYR == FindReplace_LookFor.AllScriptTypes;
                            if (flag10)
                            {
                                _bh6.FindAllAssemblyScripts((_bj5._AZG)10);
                            }
                        }
                        bool flag11 = _bg3._AYQ == FindReplace_LookIn.FirstPassEditorAssemblies || _bg3._AYQ == FindReplace_LookIn.AllEditorAssemblies;
                        if (flag11)
                        {
                            bool flag12 = _bg3._AYR == FindReplace_LookFor.CSharpScripts || _bg3._AYR == FindReplace_LookFor.AllScriptTypes;
                            if (flag12)
                            {
                                _bh6.FindAllAssemblyScripts((_bj5._AZG)6);
                            }
                        }
                        bool flag13 = _bg3._AYQ == FindReplace_LookIn.EditorAssemblies || _bg3._AYQ == FindReplace_LookIn.AllEditorAssemblies;
                        if (flag13)
                        {
                            bool flag14 = _bg3._AYR == FindReplace_LookFor.CSharpScripts || _bg3._AYR == FindReplace_LookFor.AllScriptTypes;
                            if (flag14)
                            {
                                _bh6.FindAllAssemblyScripts((_bj5._AZG)14);
                            }
                        }
                        array = _bh6._AOT.ToArray();
                    }
                    else
                    {
                        array = _bh6.FindAllTextAssets().ToArray();
                        IEnumerable<string> enumerable = null;
                        switch (_bg3._AYR)
                        {
                            case FindReplace_LookFor.AllAssets:
                                enumerable = array.Where((string guid) => !_bg3._AZH.Contains(Path.GetExtension(AssetDatabase.GUIDToAssetPath(guid).ToLowerInvariant())));
                                break;
                            case FindReplace_LookFor.AllScriptTypes:
                                enumerable = array.Where((string guid) => _bg3._AZI.Contains(Path.GetExtension(AssetDatabase.GUIDToAssetPath(guid).ToLowerInvariant())));
                                break;
                            case FindReplace_LookFor.CSharpScripts:
                                enumerable = array.Where((string guid) => Path.GetExtension(AssetDatabase.GUIDToAssetPath(guid).ToLowerInvariant()) == ".cs");
                                break;
                            case FindReplace_LookFor.Shaders:
                                enumerable = array.Where((string guid) => _bg3._AZJ.Contains(Path.GetExtension(AssetDatabase.GUIDToAssetPath(guid).ToLowerInvariant())));
                                break;
                            case FindReplace_LookFor.TextAssets:
                                enumerable = array.Where((string guid) => !_bg3._AZK.Contains(Path.GetExtension(AssetDatabase.GUIDToAssetPath(guid).ToLowerInvariant())));
                                break;
                        }
                        array = enumerable.ToArray<string>();
                    }
                }
            }
            bool flag15 = array.Length == 0 || (array.Length == 1 && array[0] == null);
            _bk5 _AZF;
            if (flag15)
            {
                Debug.LogWarning("No asset matches selected searching scope!");
                _AZF = null;
            }
            else
            {
                _bk5._AZL _AZM = new _bk5._AZL
                {
                    _ABG = this._AVU,
                    _AYS = this._AYS,
                    _AZN = this._AYT
                };
                _bk5 _AZF2 = _bk5.Create("Searching for '" + this._AVU + "'", new Action<Action<string, string, TextPosition, int>, string, _bk5._AZL>(_bh6.FindAllInSingleFile), array, _AZM, this._AYN ? "Replace" : (_bg3._AYU ? "" : "Find Results"));
                _AZF = _AZF2;
            }
            return _AZF;
        }

        // Token: 0x060001CC RID: 460 RVA: 0x00018928 File Offset: 0x00016B28
        internal static void FindAllResultsInAllAssets()
        {
            string[] array = _bh6.FindAllTextAssets().ToArray();
            _bk5._AZL _AZM = new _bk5._AZL
            {
                _ABG = GCE._ALU.GetSearchTextFromSelection(),
                _AYS = true,
                _AZN = true
            };
            _bk5 _AZF = _bk5.Create("Searching for '" + _AZM._ABG + "'", new Action<Action<string, string, TextPosition, int>, string, _bk5._AZL>(_bh6.FindAllInSingleFile), array, _AZM, _bg3._AYU ? "" : "Find Results");
        }

        // Token: 0x0400020F RID: 527
        private static string[] _AZE = new string[] { "Whole Project", "Open Tabs Only", "Current Tab Only" };

        // Token: 0x04000210 RID: 528
        private static readonly GUILayoutOption[] _AZO = new GUILayoutOption[]
        {
            GUILayout.Height(16f),
            GUILayout.Width(16f)
        };

        // Token: 0x04000211 RID: 529
        [NonSerialized]
        private static _bg3 _AA;

        // Token: 0x04000212 RID: 530
        private string _AVU;

        // Token: 0x04000213 RID: 531
        private string _AVV;

        // Token: 0x04000214 RID: 532
        private string _AVW;

        // Token: 0x04000215 RID: 533
        private static FindReplace_LookIn _AYQ = FindReplace_LookIn.WholeProject;

        // Token: 0x04000216 RID: 534
        private static FindReplace_LookFor _AYR = FindReplace_LookFor.AllAssets;

        // Token: 0x04000217 RID: 535
        [NonSerialized]
        private EditorWindow _AVP;

        // Token: 0x04000218 RID: 536
        private _bi2 _ABF;

        // Token: 0x04000219 RID: 537
        private bool _AYO = true;

        // Token: 0x0400021A RID: 538
        private bool _AYP = false;

        // Token: 0x0400021B RID: 539
        private bool _AYY = false;

        // Token: 0x0400021C RID: 540
        private bool _AYN;

        // Token: 0x0400021D RID: 541
        private bool _AYS;

        // Token: 0x0400021E RID: 542
        private bool _AYT;

        // Token: 0x0400021F RID: 543
        private static bool _AYU;

        // Token: 0x04000220 RID: 544
        private static string[] _AYV = new string[20];

        // Token: 0x04000221 RID: 545
        private static string[] _AYW = new string[20];

        // Token: 0x04000222 RID: 546
        private static readonly string[] _AZP = new string[] { "Find in Files", "Replace in Files" };

        // Token: 0x04000223 RID: 547
        private int _AYX;

        // Token: 0x04000224 RID: 548
        private static char[] _AYZ = new char[] { '/' };

        // Token: 0x04000225 RID: 549
        private static List<string> _AZH = new List<string> { ".dll", ".a", ".so", ".dylib", ".exe" };

        // Token: 0x04000226 RID: 550
        private static List<string> _AZI = new List<string> { ".cs", ".js" };

        // Token: 0x04000227 RID: 551
        internal static List<string> _AZJ = new List<string> { ".shader", ".cg", ".cginc", ".hlsl", ".hlslinc", ".compute", ".raytrace" };

        // Token: 0x04000228 RID: 552
        private static List<string> _AZK = new List<string>
        {
            ".dll", ".a", ".so", ".dylib", ".exe", ".cs", ".js", ".shader", ".cg", ".cginc",
            ".hlsl", ".hlslinc"
        };
    }
}
