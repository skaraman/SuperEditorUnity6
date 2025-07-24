using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200007D RID: 125
    [InitializeOnLoad]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class _bc5 : ScriptableObject
    {
        // Token: 0x060003BC RID: 956 RVA: 0x000C4A8C File Offset: 0x000C2C8C
        internal static string _AMQ()
        {
            return _bc5._AMR._AMS;
        }

        // Token: 0x060003BD RID: 957 RVA: 0x000C4AA8 File Offset: 0x000C2CA8
        internal static void _AMT(string value)
        {
            _bc5._AMR._AMS = value;
        }

        // Token: 0x060003BE RID: 958 RVA: 0x000C4AB8 File Offset: 0x000C2CB8
        internal static bool _AMU()
        {
            return _bc5._AMV;
        }

        // Token: 0x060003BF RID: 959 RVA: 0x000C4AD0 File Offset: 0x000C2CD0
        internal static _bc5 Instance()
        {
            bool flag = _bc5._AMR == null;
            if (flag)
            {
                _bc5[] array = Resources.FindObjectsOfTypeAll(typeof(_bc5)) as _bc5[];
                bool flag2 = array.Length != 0;
                if (flag2)
                {
                    _bc5._AMR = array[0];
                }
                else
                {
                    _bc5._AMR = ScriptableObject.CreateInstance<_bc5>();
                }
                _bc5._AMR.hideFlags = (HideFlags)61;
            }
            return _bc5._AMR;
        }

        // Token: 0x060003C0 RID: 960 RVA: 0x000C4B3C File Offset: 0x000C2D3C
        static _bc5()
        {
            AppDomain.CurrentDomain.DomainUnload -= _bc5.CurrentDomain_DomainUnload;
            AppDomain.CurrentDomain.DomainUnload += _bc5.CurrentDomain_DomainUnload;
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += _bc5.ReflectionOnlyAssemblyResolve;
        }

        // Token: 0x060003C1 RID: 961 RVA: 0x000C4BB8 File Offset: 0x000C2DB8
        private static Assembly ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }

        // Token: 0x060003C2 RID: 962 RVA: 0x000C4BD8 File Offset: 0x000C2DD8
        private void OnEnable()
        {
            EditorApplication.playModeStateChanged -= _bc5.OnPlaymodeStateChanged;
            EditorApplication.playModeStateChanged += _bc5.OnPlaymodeStateChanged;
            base.hideFlags = (HideFlags)61;
            int count = this._AMW.Count;
            while (count-- > 0)
            {
                GCE _AMX = this._AMW[count];
                bool flag = _AMX == null || (!_AMX.CanUndo() && !_AMX.CanRedo());
                if (flag)
                {
                    this._AMW.RemoveAt(count);
                    bool flag2 = _AMX != null;
                    if (flag2)
                    {
                        Object.DestroyImmediate(_AMX);
                    }
                }
            }
            bool flag3 = _bc5._AMR == null;
            if (flag3)
            {
                _bc5._AMR = this;
                foreach (GCE _AMX2 in this._AMW)
                {
                    bool flag4 = _AMX2._ALW();
                    if (flag4)
                    {
                        _bc5._AMY.Enqueue(_AMX2._AMZ);
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.OnUpdate));
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.OnUpdate));
                    }
                }
            }
            else
            {
                bool flag5 = _bc5._AMR != this;
                if (flag5)
                {
                    bool flag6 = this._AMW.Count > 0;
                    if (flag6)
                    {
                        int count2 = this._AMW.Count;
                        while (count2-- > 0)
                        {
                            GCE buffer = this._AMW[count2];
                            GCE _AMX3 = _bc5._AMR._AMW.Find((GCE x) => x != null && x._AMZ == buffer._AMZ);
                            bool flag7 = _AMX3 == null;
                            if (flag7)
                            {
                                _bc5._AMR._AMW.Add(buffer);
                                this._AMW.RemoveAt(count2);
                            }
                        }
                    }
                    bool flag8 = this._AMW.Count == 0;
                    if (flag8)
                    {
                        Debug.Log("Multiple managers resolved successfully :)");
                        Object.DestroyImmediate(this);
                    }
                    else
                    {
                        Debug.LogWarning("Failed to resolve 'multiple managers'. :(");
                    }
                }
            }
        }

        // Token: 0x060003C3 RID: 963 RVA: 0x000C4E48 File Offset: 0x000C3048
        private static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            bool _AOA = _bc5._AMV;
            if (_AOA)
            {
                bool flag = _bi2._AOB() != null;
                if (flag)
                {
                    _bi2._AOB().CloseAllPopups();
                }
            }
            else
            {
                _bc5.SaveAllModified(true);
            }
        }

        // Token: 0x060003C4 RID: 964 RVA: 0x000C4E84 File Offset: 0x000C3084
        private static void OnPlaymodeStateChanged(PlayModeStateChange state)
        {
            bool flag = _bc5._AMR == null;
            if (!flag)
            {
                bool flag2 = (int)state == 1;
                if (flag2)
                {
                    _bc5.SaveAllModified(false);
                }
            }
        }

        // Token: 0x060003C5 RID: 965 RVA: 0x000C4EB4 File Offset: 0x000C30B4
        private static void OnPlaymodeStateChanged()
        {
            bool flag = _bc5._AMR == null;
            if (!flag)
            {
                bool flag2 = EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying;
                if (flag2)
                {
                    _bc5.SaveAllModified(false);
                }
            }
        }

        // Token: 0x060003C6 RID: 966 RVA: 0x000C4EF0 File Offset: 0x000C30F0
        internal static void AddBufferToGlobalUndo(GCE buffer)
        {
            bool flag = _bc5.Instance()._AOC == null;
            if (flag)
            {
                _bc5._AMR._AOC = new _b3();
                _bc5._AMR._AOC._ABD = new List<string>();
                _bc5._AMR._AOC._ABE = new List<int>();
            }
            _bc5._AMR._AOC._ABD.Add(buffer._AMZ);
            _bc5._AMR._AOC._ABE.Add(buffer._AOD);
        }

        // Token: 0x060003C7 RID: 967 RVA: 0x000C4F80 File Offset: 0x000C3180
        internal static void RecordGlobalUndo()
        {
            bool flag = _bc5.Instance()._AOC != null && _bc5._AMR._AOC._ABD.Count > 1;
            if (flag)
            {
                _bc5._AMR._AOE.Add(_bc5._AMR._AOC);
            }
            _bc5._AMR._AOC = null;
        }

        // Token: 0x060003C8 RID: 968 RVA: 0x000C4FE0 File Offset: 0x000C31E0
        internal static bool GlobalUndo(GCE buffer = null)
        {
            List<_b3> _AOF = _bc5.Instance()._AOE;
            bool flag = _AOF.Count == 0;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = buffer == null;
                if (flag3)
                {
                    _b3 _AOG = _AOF[_AOF.Count - 1];
                    string text = _AOG._ABD.FirstOrDefault<string>();
                    buffer = _bc5.GetBuffer(text);
                    bool flag4 = buffer == null;
                    if (flag4)
                    {
                        return false;
                    }
                }
                int count = _AOF.Count;
                while (count-- > 0)
                {
                    _b3 _AOG2 = _AOF[count];
                    int num = _AOG2._ABD.IndexOf(buffer._AMZ);
                    bool flag5 = num >= 0 && _AOG2._ABE[num] == buffer.GetUndoChangeId();
                    if (flag5)
                    {
                        int num2 = 0;
                        int count2 = _AOG2._ABD.Count;
                        int num3 = count2;
                        while (num3-- > 0)
                        {
                            string guid2 = _AOG2._ABD[num3];
                            GCE _AMX = _bc5._AMR._AMW.Find((GCE x) => x != null && guid2 == x._AMZ);
                            bool flag6 = _AMX != null && _AMX.GetUndoChangeId() == _AOG2._ABE[num3];
                            if (flag6)
                            {
                                num2++;
                            }
                        }
                        EditorWindow focusedWindow = EditorWindow.focusedWindow;
                        bool flag7 = false;
                        int num4 = -1;
                        bool flag8 = count2 == num2;
                        if (flag8)
                        {
                            num4 = EditorUtility.DisplayDialogComplex("SuperEditor - Global Undo", "You are about to Undo an operation that has affected " + count2.ToString() + " files!\n\n- Select 'Global Undo' to undo all related changes.\n- Select 'Local Undo' to undo changes in the current file only.", "Global Undo", "Cancel", "Local Undo");
                            bool flag9 = num4 == 0 || num4 == 1;
                            if (flag9)
                            {
                                flag7 = true;
                            }
                        }
                        else
                        {
                            bool flag10 = num2 >= 2;
                            if (flag10)
                            {
                                num4 = EditorUtility.DisplayDialogComplex("SuperEditor - Global Undo", string.Concat(new string[]
                                {
                                    "You are about to Undo an operation that has affected ",
                                    count2.ToString(),
                                    " files!\n\nHowever, Global Undo is only available for ",
                                    num2.ToString(),
                                    " files at this time...\n\n- Select 'Global Undo' to undo related changes in those files only.\n- Select 'Local Undo' to undo changes in the current file only."
                                }), "Global Undo", "Cancel", "Local Undo");
                                bool flag11 = num4 == 0 || num4 == 1;
                                if (flag11)
                                {
                                    flag7 = true;
                                }
                            }
                        }
                        bool flag12 = flag7 && num4 != 1;
                        if (flag12)
                        {
                            int num5 = count2;
                            while (num5-- > 0)
                            {
                                string guid = _AOG2._ABD[num5];
                                GCE _AMX2 = _bc5._AMR._AMW.Find((GCE x) => x != null && guid == x._AMZ);
                                bool flag13 = _AMX2 != null && _AMX2.GetUndoChangeId() == _AOG2._ABE[num5];
                                if (flag13)
                                {
                                    _AMX2.Undo();
                                }
                            }
                        }
                        bool flag14 = focusedWindow;
                        if (flag14)
                        {
                            focusedWindow.Focus();
                        }
                        return flag7;
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x060003C9 RID: 969 RVA: 0x000C52E8 File Offset: 0x000C34E8
        internal static bool GlobalRedo(GCE buffer)
        {
            List<_b3> _AOF = _bc5.Instance()._AOE;
            bool flag = _AOF.Count == 0;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                int count = _AOF.Count;
                while (count-- > 0)
                {
                    _b3 _AOG = _AOF[count];
                    int num = _AOG._ABD.IndexOf(buffer._AMZ);
                    bool flag3 = num >= 0 && _AOG._ABE[num] == buffer.GetRedoChangeId();
                    if (flag3)
                    {
                        int num2 = 0;
                        int count2 = _AOG._ABD.Count;
                        int num3 = count2;
                        while (num3-- > 0)
                        {
                            string guid2 = _AOG._ABD[num3];
                            GCE _AMX = _bc5._AMR._AMW.Find((GCE x) => x != null && guid2 == x._AMZ);
                            bool flag4 = _AMX != null && _AMX.GetRedoChangeId() == _AOG._ABE[num3];
                            if (flag4)
                            {
                                num2++;
                            }
                        }
                        EditorWindow focusedWindow = EditorWindow.focusedWindow;
                        bool flag5 = false;
                        int num4 = -1;
                        bool flag6 = count2 == num2;
                        if (flag6)
                        {
                            num4 = EditorUtility.DisplayDialogComplex("SuperEditor - Global Redo", "You are about to Redo an operation that has affected " + count2.ToString() + " files!\n\n- Select 'Global Redo' to redo all related changes.\n- Select 'Local Redo' to redo changes in the current file only.", "Global Redo", "Cancel", "Local Redo");
                            bool flag7 = num4 == 0 || num4 == 1;
                            if (flag7)
                            {
                                flag5 = true;
                            }
                        }
                        else
                        {
                            bool flag8 = num2 >= 2;
                            if (flag8)
                            {
                                num4 = EditorUtility.DisplayDialogComplex("SuperEditor - Global Redo", string.Concat(new string[]
                                {
                                    "You are about to Redo an operation that has affected ",
                                    count2.ToString(),
                                    " files!\n\nHowever, Global Redo is only available for ",
                                    num2.ToString(),
                                    " files at this time...\n\n- Select 'Global Redo' to redo related changes in those files only.\n- Select 'Local Redo' to redo changes in the current file only."
                                }), "Global Redo", "Cancel", "Local Redo");
                                bool flag9 = num4 == 0 || num4 == 1;
                                if (flag9)
                                {
                                    flag5 = true;
                                }
                            }
                        }
                        bool flag10 = flag5 && num4 != 1;
                        if (flag10)
                        {
                            int num5 = count2;
                            while (num5-- > 0)
                            {
                                string guid = _AOG._ABD[num5];
                                GCE _AMX2 = _bc5._AMR._AMW.Find((GCE x) => x != null && guid == x._AMZ);
                                bool flag11 = _AMX2 != null && _AMX2.GetRedoChangeId() == _AOG._ABE[num5];
                                if (flag11)
                                {
                                    _AMX2.Redo();
                                }
                            }
                        }
                        bool flag12 = focusedWindow;
                        if (flag12)
                        {
                            focusedWindow.Focus();
                        }
                        return flag5;
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x060003CA RID: 970 RVA: 0x000C55A4 File Offset: 0x000C37A4
        internal static void AddRecentLocation(string assetGuid, GCE._AFA caretPosition, bool insert)
        {
            bool flag = _bc5._AMR == null;
            if (!flag)
            {
                _ba3 _AOJ = new _ba3
                {
                    _ADF = assetGuid,
                    _ABI = caretPosition._ABI,
                    JIKB = caretPosition._AEU
                };
                bool flag2 = insert && _bc5._AMR._AOH != 0;
                if (flag2)
                {
                    int num = _bc5._AMR._AOI.Count - _bc5._AMR._AOH;
                    _bc5._AMR._AOI.Insert(num, _AOJ);
                }
                else
                {
                    bool flag3 = _bc5._AMR._AOH != 0;
                    if (flag3)
                    {
                        int num2 = _bc5._AMR._AOI.Count - _bc5._AMR._AOH;
                        _bc5._AMR._AOI.RemoveRange(num2, _bc5._AMR._AOH);
                    }
                    _bc5._AMR._AOI.Add(_AOJ);
                    _bc5._AMR._AOH = 0;
                }
                bool flag4 = _bc5._AMR._AOI.Count > 100 + _bc5._AMR._AOH;
                if (flag4)
                {
                    _bc5._AMR._AOI.RemoveRange(0, _bc5._AMR._AOI.Count - 100 - _bc5._AMR._AOH);
                }
            }
        }

        // Token: 0x060003CB RID: 971 RVA: 0x000C56F4 File Offset: 0x000C38F4
        internal static void OnInsertedText(GCE buffer, GCE._AFA fromPos, GCE._AFA toPos)
        {
            string _AOK = buffer._AMZ;
            TextPosition textPosition = new TextPosition(fromPos._ABI, fromPos._AEU);
            TextPosition textPosition2 = new TextPosition(toPos._ABI, toPos._AEU);
            List<_ba3> _AOL = _bc5.Instance()._AOI;
            int count = _AOL.Count;
            while (count-- > 0)
            {
                _ba3 _AOJ = _AOL[count];
                bool flag = _AOJ._ADF != _AOK;
                if (!flag)
                {
                    TextPosition textPosition3 = new TextPosition(_AOJ._ABI, _AOJ.JIKB);
                    bool flag2 = textPosition > textPosition3 || (_bc5._AOM && textPosition == textPosition3);
                    if (!flag2)
                    {
                        bool flag3 = textPosition.line == textPosition3.line;
                        if (flag3)
                        {
                            _AOJ.JIKB += textPosition2.index - textPosition.index;
                        }
                        _AOJ._ABI += textPosition2.line - textPosition.line;
                    }
                }
            }
        }

        // Token: 0x060003CC RID: 972 RVA: 0x000C5808 File Offset: 0x000C3A08
        internal static void OnRemovedText(GCE buffer, GCE._AFA fromPos, GCE._AFA toPos)
        {
            TextPosition textPosition = new TextPosition(fromPos._ABI, fromPos._AEU);
            TextPosition textPosition2 = new TextPosition(toPos._ABI, toPos._AEU);
            string _AOK = buffer._AMZ;
            List<_ba3> _AOL = _bc5.Instance()._AOI;
            int count = _AOL.Count;
            while (count-- > 0)
            {
                _ba3 _AOJ = _AOL[count];
                bool flag = _AOJ._ADF != _AOK;
                if (!flag)
                {
                    TextPosition textPosition3 = new TextPosition(_AOJ._ABI, _AOJ.JIKB);
                    bool flag2 = textPosition >= textPosition3;
                    if (!flag2)
                    {
                        bool flag3 = textPosition2 >= textPosition3;
                        if (flag3)
                        {
                            _AOJ._ABI = textPosition.line;
                            _AOJ.JIKB = textPosition.index;
                        }
                        else
                        {
                            bool flag4 = textPosition2.line == textPosition3.line;
                            if (flag4)
                            {
                                _AOJ.JIKB -= textPosition2.index - textPosition.index;
                            }
                            _AOJ._ABI -= textPosition2.line - textPosition.line;
                        }
                    }
                }
            }
            bool flag5 = _AOL.Count > 1;
            if (flag5)
            {
                _ba3 _AOJ2 = _AOL[0];
                for (int i = 1; i < _AOL.Count; i++)
                {
                    _ba3 _AOJ3 = _AOL[i];
                    bool flag6 = _AOJ3._ADF != _AOJ2._ADF || _AOJ3._ABI != _AOJ2._ABI || _AOJ3.JIKB != _AOJ2.JIKB;
                    if (flag6)
                    {
                        _AOJ2 = _AOJ3;
                    }
                    else
                    {
                        bool flag7 = _bc5._AMR._AOH >= _AOL.Count - i;
                        if (flag7)
                        {
                            _bc5._AMR._AOH--;
                        }
                        _AOL.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        // Token: 0x060003CD RID: 973 RVA: 0x000C5A03 File Offset: 0x000C3C03
        internal static void AddPendingAssetImport(string guid)
        {
            _bc5._AON.Add(guid);
        }

        // Token: 0x060003CE RID: 974 RVA: 0x000C5A14 File Offset: 0x000C3C14
        internal static bool _AOO()
        {
            return _bc5._AON.Count > 0;
        }

        // Token: 0x060003CF RID: 975 RVA: 0x000C5A34 File Offset: 0x000C3C34
        internal static void ImportPendingAssets()
        {
            foreach (string text in _bc5._AON)
            {
                AssetDatabase.ImportAsset(AssetDatabase.GUIDToAssetPath(text));
            }
            _bc5._AON.Clear();
        }

        // Token: 0x060003D0 RID: 976 RVA: 0x000C5A9C File Offset: 0x000C3C9C
        internal static void SaveAllModified(bool onQuit)
        {
            bool flag = _bc5._AMR == null;
            if (!flag)
            {
                try
                {
                    foreach (GCE _AMX in _bc5.Instance()._AMW)
                    {
                        bool flag2 = _AMX == null;
                        if (!flag2)
                        {
                            bool flag3 = _AMX._ALW();
                            if (flag3)
                            {
                                string text = AssetDatabase.GUIDToAssetPath(_AMX._AMZ);
                                bool flag4 = onQuit && !EditorUtility.DisplayDialog("SuperEditor", "Save changes to the following asset?\n\n" + text, "Save", "Don't Save");
                                if (!flag4)
                                {
                                    bool flag5 = _AMX.Save();
                                    if (flag5)
                                    {
                                        bool flag6 = !onQuit;
                                        if (flag6)
                                        {
                                            AssetDatabase.ImportAsset(text, 0);
                                            _AMX.UpdateViews();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    bool flag7 = !onQuit;
                    if (flag7)
                    {
                        _bc5.ImportPendingAssets();
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex);
                }
            }
        }

        // Token: 0x060003D1 RID: 977 RVA: 0x000C5BC0 File Offset: 0x000C3DC0
        internal static GCE TryGetBuffer(string assetPath)
        {
            bool flag = !assetPath.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase);
            GCE _AMX;
            if (flag)
            {
                _AMX = null;
            }
            else
            {
                string guid = AssetDatabase.AssetPathToGUID(assetPath);
                _AMX = _bc5.Instance()._AMW.Find((GCE x) => x != null && guid == x._AMZ);
            }
            return _AMX;
        }

        // Token: 0x060003D2 RID: 978 RVA: 0x000C5C18 File Offset: 0x000C3E18
        internal static GCE GetBuffer(Object target)
        {
            string text = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(target));
            return _bc5.GetBuffer(text);
        }

        // Token: 0x060003D3 RID: 979 RVA: 0x000C5C3C File Offset: 0x000C3E3C
        internal static GCE GetBuffer(string guid)
        {
            List<GCE> list = _bc5.Instance()._AMW.FindAll((GCE x) => x != null && guid == x._AMZ);
            bool flag = list.Count > 0;
            GCE _AMX;
            if (flag)
            {
                bool flag2 = list.Count > 1;
                if (flag2)
                {
                    Debug.Log("Removing " + (list.Count - 1).ToString() + " duplicates...");
                    for (int i = 1; i < list.Count; i++)
                    {
                        _bc5.Instance()._AMW.Remove(list[i]);
                    }
                }
                _AMX = list[0];
            }
            else
            {
                GCE _AMX2 = ScriptableObject.CreateInstance<GCE>();
                _AMX2._AMZ = guid;
                _bc5.Instance()._AMW.Add(_AMX2);
                _AMX = _AMX2;
            }
            return _AMX;
        }

        // Token: 0x060003D4 RID: 980 RVA: 0x000C5D20 File Offset: 0x000C3F20
        internal static void DestroyBuffer(GCE buffer)
        {
            _bc5.Instance()._AMW.Remove(buffer);
            Object.DestroyImmediate(buffer);
        }

        // Token: 0x060003D5 RID: 981 RVA: 0x000C5D3C File Offset: 0x000C3F3C
        internal static void FindOtherTypeDeclarationParts(FKI declaration)
        {
            bool flag = _bc5._AOP == null;
            if (flag)
            {
                _bc5._AOP = new Dictionary<_bj5, List<string>>();
                _bc5._AOQ = new Dictionary<_bj5, List<string>>();
                _bc5._AOR = new Dictionary<_bj5, List<string>>();
            }
            _bc6 _AHD = declaration._ACV as _bc6;
            bool flag2 = _AHD == null;
            if (!flag2)
            {
                _bj5 _AOS = _AHD.Assembly;
                Dictionary<_bj5, List<string>> dictionary = ((declaration._AT == SymbolKind.Class) ? _bc5._AOP : ((declaration._AT == SymbolKind.Struct) ? _bc5._AOQ : _bc5._AOR));
                List<string> list;
                bool flag3 = !dictionary.TryGetValue(_AOS, out list);
                if (flag3)
                {
                    _bh6.Reset();
                    _bh6.FindAllAssemblyScripts(_AOS);
                    list = (dictionary[_AOS] = new List<string>(_bh6._AOT.Count));
                    string[] array = new string[]
                    {
                        "partial",
                        (declaration._AT == SymbolKind.Class) ? "class" : ((declaration._AT == SymbolKind.Struct) ? "struct" : "interface")
                    };
                    int count = _bh6._AOT.Count;
                    while (count-- > 0)
                    {
                        string text = AssetDatabase.GUIDToAssetPath(_bh6._AOT[count]);
                        bool flag4 = _bh6.ContainsWordsSequence(text, array);
                        if (flag4)
                        {
                            list.Add(_bh6._AOT[count]);
                        }
                    }
                }
                string[] array2 = new string[]
                {
                    "partial",
                    (declaration._AT == SymbolKind.Class) ? "class" : ((declaration._AT == SymbolKind.Struct) ? "struct" : "interface"),
                    declaration.Name
                };
                int count2 = list.Count;
                while (count2-- > 0)
                {
                    string text2 = AssetDatabase.GUIDToAssetPath(list[count2]);
                    bool flag5 = _bh6.ContainsWordsSequence(text2, array2);
                    if (flag5)
                    {
                        _bc5._AMY.Enqueue(list[count2]);
                        list.RemoveAt(count2);
                    }
                }
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.OnUpdate));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.OnUpdate));
            }
        }

        // Token: 0x060003D6 RID: 982 RVA: 0x000C5F64 File Offset: 0x000C4164
        internal static void ParseAllAsyncBuffers()
        {
            while (_bc5._AMY.Count > 0)
            {
                _bc5.OnUpdate();
            }
        }

        // Token: 0x060003D7 RID: 983 RVA: 0x000C5F8C File Offset: 0x000C418C
        private static void OnUpdate()
        {
            bool flag = _bc5._AMY.Count > 0;
            if (flag)
            {
                string text = _bc5._AMY.Dequeue();
                GCE buffer = _bc5.GetBuffer(text);
                bool flag2 = buffer._AOU() == null;
                if (flag2)
                {
                    buffer.LoadImmediately();
                }
            }
            else
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.OnUpdate));
            }
        }

        // Token: 0x060003D8 RID: 984 RVA: 0x000C5FF8 File Offset: 0x000C41F8
        private static void CompileErrorsCheck()
        {
            bool isCompiling = EditorApplication.isCompiling;
            if (!isCompiling)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.CompileErrorsCheck));
                _bc5._AMV = false;
                _bi2.RepaintAllInstances();
            }
        }

        // Token: 0x060003D9 RID: 985 RVA: 0x000C6040 File Offset: 0x000C4240
        private static void RepaintConsoleAfterUpdate()
        {
            bool isUpdating = EditorApplication.isUpdating;
            if (!isUpdating)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.RepaintConsoleAfterUpdate));
            }
        }

        // Token: 0x060003DA RID: 986 RVA: 0x000C607C File Offset: 0x000C427C
        public void OnAssetReimported(string assetPath)
        {
            bool flag = !assetPath.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase);
            if (!flag)
            {
                string guid = AssetDatabase.AssetPathToGUID(assetPath);
                GCE _AMX = this._AMW.Find((GCE x) => guid == x._AMZ);
                bool flag2 = _AMX != null;
                if (flag2)
                {
                    _AMX.Reload();
                }
            }
        }

        // Token: 0x060003DB RID: 987 RVA: 0x000C60E0 File Offset: 0x000C42E0
        public void OnAssetMoved(string assetPath)
        {
            bool flag = !assetPath.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase);
            if (!flag)
            {
                string guid = AssetDatabase.AssetPathToGUID(assetPath);
                GCE _AMX = this._AMW.Find((GCE x) => guid == x._AMZ);
                bool flag2 = _AMX != null;
                if (flag2)
                {
                    _AMX._AOV = true;
                }
            }
        }

        // Token: 0x04000433 RID: 1075
        [SerializeField]
        private List<GCE> _AMW = new List<GCE>();

        // Token: 0x04000434 RID: 1076
        [SerializeField]
        private List<_b3> _AOE = new List<_b3>();

        // Token: 0x04000435 RID: 1077
        [NonSerialized]
        private _b3 _AOC;

        // Token: 0x04000436 RID: 1078
        [SerializeField]
        public List<_ba3> _AOI = new List<_ba3>();

        // Token: 0x04000437 RID: 1079
        internal static bool _AOM = false;

        // Token: 0x04000438 RID: 1080
        [SerializeField]
        public int _AOH;

        // Token: 0x04000439 RID: 1081
        [SerializeField]
        public string _AOW;

        // Token: 0x0400043A RID: 1082
        [SerializeField]
        private string _AMS;

        // Token: 0x0400043B RID: 1083
        private static bool _AMV = false;

        // Token: 0x0400043C RID: 1084
        private static HashSet<string> _AON = new HashSet<string>();

        // Token: 0x0400043D RID: 1085
        private static Queue<string> _AMY = new Queue<string>();

        // Token: 0x0400043E RID: 1086
        private static GCE _AOX;

        // Token: 0x0400043F RID: 1087
        private static Dictionary<_bj5, List<string>> _AOP;

        // Token: 0x04000440 RID: 1088
        private static Dictionary<_bj5, List<string>> _AOQ;

        // Token: 0x04000441 RID: 1089
        private static Dictionary<_bj5, List<string>> _AOR;

        // Token: 0x04000442 RID: 1090
        private static _bc5 _AMR = null;

        // Token: 0x0200007E RID: 126
        internal class _AOY : AssetPostprocessor
        {
            // Token: 0x060003DD RID: 989 RVA: 0x000C616C File Offset: 0x000C436C
            private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
            {
                bool flag = _bc5._AMR == null;
                if (!flag)
                {
                    for (int i = 0; i < importedAssets.Length; i++)
                    {
                        string imported = importedAssets[i];
                        bool flag2 = imported.EndsWith(".js", StringComparison.OrdinalIgnoreCase) || imported.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
                        if (flag2)
                        {
                            bool flag3 = !Array.Exists<string>(movedAssets, (string path) => imported == path);
                            if (flag3)
                            {
                                _bc5.Instance().OnAssetReimported(imported);
                            }
                            _bc5._AMV = true;
                        }
                        else
                        {
                            _bc5.Instance().OnAssetReimported(imported);
                        }
                    }
                    for (int j = 0; j < movedAssets.Length; j++)
                    {
                        bool flag4 = movedAssets[j].EndsWith(".js", StringComparison.OrdinalIgnoreCase) || movedAssets[j].EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
                        if (flag4)
                        {
                            _bc5.Instance().OnAssetMoved(movedAssets[j]);
                        }
                    }
                    bool _AOA = _bc5._AMV;
                    if (_AOA)
                    {
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.CompileErrorsCheck));
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.CompileErrorsCheck));
                    }
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.RepaintConsoleAfterUpdate));
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bc5.RepaintConsoleAfterUpdate));
                }
            }
        }
    }
}
