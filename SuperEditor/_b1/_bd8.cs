using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using SuperEditor;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000089 RID: 137
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class GCE : ScriptableObject
    {
        // Token: 0x060003F3 RID: 1011 RVA: 0x000C6424 File Offset: 0x000C4624
        public Encoding _ARN()
        {
            return (this._ARO || (this._ARR && this._ARP == Encoding.UTF8.CodePage)) ? new UTF8Encoding(false) : Encoding.GetEncoding(this._ARP);
        }

        // Token: 0x060003F4 RID: 1012 RVA: 0x000C646B File Offset: 0x000C466B
        [CompilerGenerated]
        public string _ARQ()
        {
            return this._ARS;
        }

        // Token: 0x060003F5 RID: 1013 RVA: 0x000C6473 File Offset: 0x000C4673
        [CompilerGenerated]
        private void _ART(string value)
        {
            this._ARS = value;
        }

        // Token: 0x060003F6 RID: 1014 RVA: 0x000C647C File Offset: 0x000C467C
        public void AddEditor(_bi2 editor)
        {
            bool flag = !this._ARU.Contains(editor);
            if (flag)
            {
                this._ARU.Add(editor);
                bool flag2 = !this._ARV() && this.FLOg.Count > 0;
                if (flag2)
                {
                    editor.ValidateCarets();
                }
            }
        }

        // Token: 0x060003F7 RID: 1015 RVA: 0x000C64D0 File Offset: 0x000C46D0
        public void RemoveEditor(_bi2 editor)
        {
            this._ARU.Remove(editor);
        }

        // Token: 0x060003F8 RID: 1016 RVA: 0x000C64E0 File Offset: 0x000C46E0
        public bool CheckSaveIfCancel()
        {
            bool flag = this._ARU.Count == 1 && !_bb6._AMA && !_bg8._ARW && this._ALW() && !GCE.IsAnyWindowMaximized();
            bool flag3;
            if (flag)
            {
                string text = AssetDatabase.GUIDToAssetPath(this._AMZ);
                switch (EditorUtility.DisplayDialogComplex("SuperEditor", "Save changes to the following asset?          \n\n" + text, "Save", "Discard Changes", "Cancel"))
                {
                    case 0:
                        {
                            bool flag2 = this.Save();
                            if (flag2)
                            {
                                AssetDatabase.ImportAsset(text, 0);
                            }
                            break;
                        }
                    case 1:
                        _bc5.DestroyBuffer(this);
                        break;
                    case 2:
                        return true;
                }
                flag3 = false;
            }
            else
            {
                flag3 = false;
            }
            return flag3;
        }

        // Token: 0x060003F9 RID: 1017 RVA: 0x000C65A0 File Offset: 0x000C47A0
        internal static GCE GetBuffer(Object target)
        {
            return _bc5.GetBuffer(target);
        }

        // Token: 0x060003FA RID: 1018 RVA: 0x000C65B8 File Offset: 0x000C47B8
        public void OnEnable()
        {
            base.hideFlags = 61;
            string text = AssetDatabase.GUIDToAssetPath(this._AMZ);
            bool flag = !string.IsNullOrEmpty(text);
            if (flag)
            {
                this._ART(text);
            }
            bool _ARX = this._ARY;
            if (_ARX)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReloadOnNextUpdate));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReloadOnNextUpdate));
            }
        }

        // Token: 0x060003FB RID: 1019 RVA: 0x000C663C File Offset: 0x000C483C
        public void OnDisable()
        {
            GCE._ARZ.Remove(this._AMZ);
        }

        // Token: 0x060003FC RID: 1020 RVA: 0x000C663C File Offset: 0x000C483C
        public void OnDestroy()
        {
            GCE._ARZ.Remove(this._AMZ);
        }

        // Token: 0x060003FD RID: 1021 RVA: 0x000C6650 File Offset: 0x000C4850
        public void InitializeWithCSharpCode(string content)
        {
            GCE._ASA = _bg8._ASA;
            this._ART(this._AMZ);
            this._ASB = false;
            this._ASC = true;
            this._ARO = false;
            this._ARR = false;
            this._ABT = (this._ARR ? _bi2._ASD() : _bi2._AEE());
            this._ARY = false;
            this._ASE = default(DateTime);
            this._ASF = _be3.Create(this, this._ARQ());
            this.FLOg = new List<string>(content.Replace("\r\n", "\n").Replace('\r', '\n').Split(new char[] { '\n' }));
            this._ASG = "\n";
            this._ARP = Encoding.UTF8.CodePage;
            this._ASH.Clear();
            this._ABU = 0;
            this._ASI = this._ASJ;
            this._AQQ = new GCE.PHFG[this.FLOg.Count];
            this.ReformatLines(0, this.FLOg.Count - 1);
            this._ASK = this.FLOg.Count;
            this.UpdateViews();
            this.ValidateCarets();
            this._ASF.OnLoaded();
        }

        // Token: 0x060003FE RID: 1022 RVA: 0x000C679C File Offset: 0x000C499C
        public void Initialize()
        {
            GCE._ASA = _bg8._ASA;
            string text = AssetDatabase.GUIDToAssetPath(this._AMZ);
            bool flag = string.IsNullOrEmpty(text);
            if (!flag)
            {
                this._ART(text);
                this._ASB = this._ARQ().EndsWith(".js", StringComparison.OrdinalIgnoreCase);
                this._ASC = this._ARQ().EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
                this._ARO = this._ARQ().EndsWith(".shader", StringComparison.OrdinalIgnoreCase) || this._ARQ().EndsWith(".cg", StringComparison.OrdinalIgnoreCase) || this._ARQ().EndsWith(".cginc", StringComparison.OrdinalIgnoreCase) || this._ARQ().EndsWith(".hlsl", StringComparison.OrdinalIgnoreCase) || this._ARQ().EndsWith(".hlslinc", StringComparison.OrdinalIgnoreCase) || this._ARQ().EndsWith(".compute", StringComparison.OrdinalIgnoreCase) || this._ARQ().EndsWith(".raytrace", StringComparison.OrdinalIgnoreCase);
                this._ARR = !this._ASB && !this._ASC && !this._ARO;
                this._ABT = _bi2.GetStyles(this._ARR);
                bool flag2 = !this._ARY && this._ASL && this._ASK > 0;
                if (!flag2)
                {
                    bool flag3 = this._ARY || this.FLOg == null || this.FLOg.Count == 0;
                    if (flag3)
                    {
                        try
                        {
                            this._ASE = File.GetLastWriteTime(this._ARQ());
                        }
                        catch
                        {
                        }
                        this._ASF = _be3.Create(this, this._ARQ());
                        this.FLOg = new List<string>();
                        this._ASG = "\n";
                        try
                        {
                            Stream stream = new BufferedStream(new FileStream(this._ARQ(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 1024);
                            bool flag4 = stream != null;
                            if (flag4)
                            {
                                this._ASM = new StreamReader(stream, true);
                            }
                            this._ARP = Encoding.UTF8.CodePage;
                        }
                        catch
                        {
                            bool flag5 = this._ASM != null;
                            if (flag5)
                            {
                                this._ASM.Close();
                                this._ASM.Dispose();
                                this._ASM = null;
                            }
                            this._ASE = default(DateTime);
                        }
                        this._AQQ = new GCE.PHFG[0];
                        this._ASH.Clear();
                        this._ABU = 0;
                        this._ASK = 0;
                        this._ASI = this._ASJ;
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveLoadOnUpdate));
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveLoadOnUpdate));
                    }
                    else
                    {
                        bool flag6 = this._ASK == 0;
                        if (flag6)
                        {
                            bool flag7 = this._ASF == null;
                            if (flag7)
                            {
                                this._ASF = _be3.Create(this, this._ARQ());
                            }
                            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveLoadOnUpdate));
                            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveLoadOnUpdate));
                        }
                        else
                        {
                            this._ASL = true;
                        }
                    }
                    bool flag8 = this._ARV();
                    if (flag8)
                    {
                        this.ProgressiveLoadOnUpdate();
                    }
                }
            }
        }

        // Token: 0x060003FF RID: 1023 RVA: 0x000C6B04 File Offset: 0x000C4D04
        public void LoadImmediately()
        {
            bool flag = this._ARV();
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReloadOnNextUpdate));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveLoadOnUpdate));
                bool flag2 = this._ASM == null;
                if (flag2)
                {
                    this.Initialize();
                }
                while (this._ARV())
                {
                    this.ProgressiveLoadOnUpdate();
                }
                this.ProgressiveLoadOnUpdate();
            }
        }

        // Token: 0x06000400 RID: 1024 RVA: 0x000C6B8C File Offset: 0x000C4D8C
        public void Reload()
        {
            try
            {
                DateTime lastWriteTime = File.GetLastWriteTime(this._ARQ());
                this._AOV = lastWriteTime == this._ASE;
            }
            catch
            {
            }
            this._ARY = this._ARY || !this._AOV;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReloadOnNextUpdate));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReloadOnNextUpdate));
        }

        // Token: 0x06000401 RID: 1025 RVA: 0x000C6C2C File Offset: 0x000C4E2C
        private void ReloadOnNextUpdate()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ReloadOnNextUpdate));
            bool danalhepofnonjhnmaegpnfhneilbjbnaank = this._AOV;
            if (danalhepofnonjhnmaegpnfhneilbjbnaank)
            {
                this._AOV = false;
                this.RescanHyperlinks();
                bool flag = this._ASF == null;
                if (flag)
                {
                    string text = AssetDatabase.GUIDToAssetPath(this._AMZ);
                    this._ASF = _be3.Create(this, text);
                }
                this.UpdateViews();
            }
            else
            {
                _bb6.CheckAssetRename(this._AMZ);
                bool flag2 = this._ALW();
                if (flag2)
                {
                    bool flag3 = !EditorUtility.DisplayDialog("Super Editor", AssetDatabase.GUIDToAssetPath(this._AMZ) + "\n\nThis file has been modified outside of Unity Editor.\nDo you want to reload it and lose the changes made in Super Editor?", "Reload", "Keep changes");
                    if (flag3)
                    {
                        this._ARY = false;
                        this._ASI = 0;
                        this.UpdateViews();
                        return;
                    }
                }
                this.ReloadNow();
            }
        }

        // Token: 0x06000402 RID: 1026 RVA: 0x000C6D10 File Offset: 0x000C4F10
        private void ReloadNow()
        {
            this._AQQ = new GCE.PHFG[0];
            this.FLOg = new List<string>();
            this._ASG = "\n";
            this._ASH.Clear();
            bool flag = this._ASM != null;
            if (flag)
            {
                this._ASM.Close();
                this._ASM.Dispose();
                this._ASM = null;
            }
            this._ARP = Encoding.UTF8.CodePage;
            this._ASK = 0;
            this._ABU = 0;
            this._ASB = false;
            this._ASC = false;
            this._ARO = false;
            this._ARR = false;
            this._ASN = new List<GCE._ASO>();
            this._ASJ = 0;
            this._AOD = 0;
            this._ASI = 0;
            this._ASL = false;
            this.Initialize();
        }

        // Token: 0x06000403 RID: 1027 RVA: 0x000C6DE2 File Offset: 0x000C4FE2
        public void RescanHyperlinks()
        {
            this._ASH.Clear();
        }

        // Token: 0x06000404 RID: 1028 RVA: 0x000C6DF4 File Offset: 0x000C4FF4
        public bool Save()
        {
            bool flag = !this.TryEdit();
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = true;
                this._AOV = true;
                string text = AssetDatabase.GUIDToAssetPath(this._AMZ);
                bool flag4 = string.IsNullOrEmpty(text);
                if (flag4)
                {
                    flag2 = false;
                }
                else
                {
                    StreamWriter streamWriter = null;
                    try
                    {
                        StreamWriter streamWriter2;
                        streamWriter = (streamWriter2 = new StreamWriter(text, false, this._ARN()));
                        try
                        {
                            streamWriter.NewLine = this._ASG;
                            int count = this.FLOg.Count;
                            for (int i = 0; i < count - 1; i++)
                            {
                                streamWriter.WriteLine(this.FLOg[i]);
                            }
                            streamWriter.Write(this.FLOg[count - 1]);
                            streamWriter.Close();
                        }
                        finally
                        {
                            if (streamWriter2 != null)
                            {
                                ((IDisposable)streamWriter2).Dispose();
                            }
                        }
                        for (int j = 0; j < this._ASK; j++)
                        {
                            this._AQQ[j]._ASP = this._AQQ[j]._ASQ;
                        }
                        this._ASI = this._ASJ;
                        foreach (GCE._ASO _ASR in this._ASN)
                        {
                            foreach (GCE._ASO._ASS _AST in _ASR._ASU)
                            {
                                _AST._ASV = null;
                            }
                        }
                    }
                    catch
                    {
                        bool flag5 = streamWriter != null;
                        if (flag5)
                        {
                            streamWriter.Close();
                            streamWriter.Dispose();
                        }
                        EditorUtility.DisplayDialog("Error Saving Script", "The script '" + AssetDatabase.GUIDToAssetPath(this._AMZ) + "' could not be saved!", "OK");
                        this._AOV = false;
                        flag3 = false;
                    }
                    bool flag6 = streamWriter != null;
                    if (flag6)
                    {
                        streamWriter.Close();
                        streamWriter.Dispose();
                    }
                    try
                    {
                        this._ASE = File.GetLastWriteTime(text);
                    }
                    catch
                    {
                    }
                    this.UpdateViews();
                    flag2 = flag3;
                }
            }
            return flag2;
        }

        // Token: 0x06000405 RID: 1029 RVA: 0x000C708C File Offset: 0x000C528C
        private static bool IsAnyWindowMaximized()
        {
            Type type = typeof(EditorWindow).Assembly.GetType("UnityEditor.MaximizedHostView");
            return Resources.FindObjectsOfTypeAll(type).Length != 0;
        }

        // Token: 0x06000406 RID: 1030 RVA: 0x000C70C4 File Offset: 0x000C52C4
        public void UpdateViews()
        {
            bool flag = this._ASW != null;
            if (flag)
            {
                this._ASW();
            }
        }

        // Token: 0x06000407 RID: 1031 RVA: 0x000C70EC File Offset: 0x000C52EC
        public _be3 _AOU()
        {
            return this._ASF;
        }

        // Token: 0x06000408 RID: 1032 RVA: 0x00014488 File Offset: 0x00012688
        public void LoadFaster()
        {
        }

        // Token: 0x06000409 RID: 1033 RVA: 0x000C7104 File Offset: 0x000C5304
        public void ProgressiveLoadOnUpdate()
        {
            this._ASL = true;
            bool flag = GCE._ARZ.Count > 0 && !GCE._ARZ.Contains(this._AMZ);
            if (!flag)
            {
                bool flag2 = this._ASM != null;
                if (flag2)
                {
                    try
                    {
                        this.Parse(this._ASK + 128);
                    }
                    catch (Exception ex)
                    {
                        bool flag3 = this._ASM != null;
                        if (flag3)
                        {
                            this._ASM.Close();
                            this._ASM.Dispose();
                            this._ASM = null;
                        }
                    }
                    bool flag4 = this._ASM == null;
                    if (flag4)
                    {
                        int num = this._AQQ.Length;
                        while (num-- > 0)
                        {
                            this._AQQ[num]._ASQ = -1;
                        }
                        this.UpdateViews();
                    }
                }
                else
                {
                    bool flag5 = this._ASK < this.FLOg.Count;
                    if (flag5)
                    {
                        int num2 = Math.Min(this._ASK + 128, this.FLOg.Count - 1);
                        this.ReformatLines(this._ASK, num2);
                        this._ASK = num2 + 1;
                        this.UpdateViews();
                    }
                    else
                    {
                        this._ARY = false;
                        EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveLoadOnUpdate));
                        GCE._ARZ.Remove(this._AMZ);
                        this.ValidateCarets();
                        bool flag6 = this._ASF != null;
                        if (flag6)
                        {
                            this._ASF.OnLoaded();
                        }
                    }
                }
            }
        }

        // Token: 0x0600040A RID: 1034 RVA: 0x000C72DC File Offset: 0x000C54DC
        private void ValidateCarets()
        {
            foreach (_bi2 _ASX in this._ARU)
            {
                _ASX.ValidateCarets();
            }
        }

        // Token: 0x0600040B RID: 1035 RVA: 0x000C7334 File Offset: 0x000C5534
        public int GetUndoChangeId()
        {
            bool flag = !this.CanUndo();
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                num = this._ASN[this._ASJ - 1]._ASY;
            }
            return num;
        }

        // Token: 0x0600040C RID: 1036 RVA: 0x000C7370 File Offset: 0x000C5570
        public int GetRedoChangeId()
        {
            bool flag = !this.CanRedo();
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                num = this._ASN[this._ASJ]._ASY;
            }
            return num;
        }

        // Token: 0x0600040D RID: 1037 RVA: 0x000C73AC File Offset: 0x000C55AC
        public bool CanUndo()
        {
            return this._ASJ > 0;
        }

        // Token: 0x0600040E RID: 1038 RVA: 0x000C73C8 File Offset: 0x000C55C8
        public bool CanRedo()
        {
            return this._ASJ < this._ASN.Count;
        }

        // Token: 0x0600040F RID: 1039 RVA: 0x000C73F0 File Offset: 0x000C55F0
        public void Undo()
        {
            bool flag = !this.CanUndo();
            if (!flag)
            {
                this._ASZ = false;
                int num = int.MaxValue;
                int num2 = -1;
                List<GCE._ASO> _ATA = this._ASN;
                int num3 = this._ASJ - 1;
                this._ASJ = num3;
                GCE._ASO _ASR = _ATA[num3];
                int count = _ASR._ASU.Count;
                while (count-- != 0)
                {
                    GCE._ASO._ASS _AST = _ASR._ASU[count];
                    int num4 = _AST._ATB._ABI;
                    int num5 = _AST._ATC._ABI;
                    bool flag2 = num4 > num5;
                    if (flag2)
                    {
                        int num6 = num5;
                        num5 = num4;
                        num4 = num6;
                    }
                    int[] array = null;
                    GCE._AFA _ATD = _AST._ATB.Clone();
                    bool flag3 = _AST._ATE != string.Empty;
                    if (flag3)
                    {
                        string[] array2 = _AST._ATE.Split(new char[] { '\n' });
                        GCE._AFA _ATD2 = _AST._ATB.Clone();
                        _ATD2._AEU = ((array2.Length > 1) ? array2[array2.Length - 1].Length : (_ATD2._AEU + _AST._ATE.Length));
                        _ATD2._ABI += array2.Length - 1;
                        _ATD2._ATF = (_ATD2._ATG = this.CharIndexToColumn(_ATD2._AEU, _ATD2._ABI));
                        int num7 = 1 + _ATD2._ABI - num4;
                        array = new int[num7];
                        for (int i = 0; i < num7; i++)
                        {
                            array[i] = this._AQQ[num4 + i]._ASP;
                        }
                        _ATD = this.DeleteText(_AST._ATB, _ATD2);
                        bool flag4 = num > _ATD._ABI;
                        if (flag4)
                        {
                            num = _ATD._ABI;
                        }
                        bool flag5 = num2 > _ATD._ABI;
                        if (flag5)
                        {
                            num2 -= num7 - 1;
                        }
                        bool flag6 = num2 < _ATD._ABI;
                        if (flag6)
                        {
                            num2 = _ATD._ABI;
                        }
                    }
                    bool flag7 = _AST._ATH != string.Empty;
                    if (flag7)
                    {
                        GCE._AFA _ATD3 = this.InsertText(_ATD, _AST._ATH);
                        bool flag8 = num > _ATD._ABI;
                        if (flag8)
                        {
                            num = _ATD._ABI;
                        }
                        bool flag9 = num2 < _ATD._ABI;
                        if (flag9)
                        {
                            num2 = _ATD._ABI;
                        }
                        num2 += _ATD3._ABI - _ATD._ABI;
                    }
                    int num8 = _AST._ATI.Length;
                    while (num8-- > 0)
                    {
                        this._AQQ[num8 + num4]._ASQ = _AST._ATI[num8];
                        bool flag10 = _AST._ASV != null && _AST._ASV.Length == 1 + num5 - num4;
                        if (flag10)
                        {
                            this._AQQ[num8 + num4]._ASP = _AST._ASV[num8];
                        }
                    }
                    _AST._ASV = array;
                }
                _bi2 _ASX = ((GCE._ALU != null && GCE._ALU._ABK() == this) ? GCE._ALU : null);
                bool flag11 = _ASX != null && _ASR._ATJ._ABI >= 0;
                if (flag11)
                {
                    _ASX._ABH = _ASR._ATJ.Clone();
                    bool flag12 = _ASR._ATJ == _ASR._ATK;
                    if (flag12)
                    {
                        _ASX._ATL(null);
                    }
                    else
                    {
                        _ASX._ATL(_ASR._ATK.Clone());
                    }
                    _ASX._ATM = _bi2._ATN;
                    _ASX._ATO = true;
                }
                this.UpdateHighlighting(num, num2, true);
                this._ASZ = true;
            }
        }

        // Token: 0x06000410 RID: 1040 RVA: 0x000C77A4 File Offset: 0x000C59A4
        public void Redo()
        {
            bool flag = !this.CanRedo();
            if (!flag)
            {
                this._ASZ = false;
                int num = int.MaxValue;
                int num2 = -1;
                List<GCE._ASO> _ATA = this._ASN;
                int _ATP = this._ASJ;
                this._ASJ = _ATP + 1;
                GCE._ASO _ASR = _ATA[_ATP];
                for (int i = 0; i < _ASR._ASU.Count; i++)
                {
                    GCE._ASO._ASS _AST = _ASR._ASU[i];
                    int num3 = _AST._ATB._ABI;
                    int num4 = _AST._ATC._ABI;
                    bool flag2 = num3 > num4;
                    if (flag2)
                    {
                        int num5 = num4;
                        num4 = num3;
                        num3 = num5;
                    }
                    int num6 = 1 + num4 - num3;
                    int[] array = new int[num6];
                    int num7 = num6;
                    while (num7-- > 0)
                    {
                        array[num7] = this._AQQ[num7 + num3]._ASP;
                    }
                    GCE._AFA _ATD = _AST._ATB.Clone();
                    bool flag3 = _AST._ATH != string.Empty;
                    if (flag3)
                    {
                        _ATD = this.DeleteText(_AST._ATB, _AST._ATC);
                        bool flag4 = num > _ATD._ABI;
                        if (flag4)
                        {
                            num = _ATD._ABI;
                        }
                        bool flag5 = num2 > _ATD._ABI;
                        if (flag5)
                        {
                            num2 -= num6 - 1;
                        }
                        bool flag6 = num2 < _ATD._ABI;
                        if (flag6)
                        {
                            num2 = _ATD._ABI;
                        }
                    }
                    bool flag7 = _AST._ATE != string.Empty;
                    if (flag7)
                    {
                        _ATD = this.InsertText(_ATD, _AST._ATE);
                        bool flag8 = num > num3;
                        if (flag8)
                        {
                            num = num3;
                        }
                        bool flag9 = num2 < num3;
                        if (flag9)
                        {
                            num2 = num3;
                        }
                        num2 += _ATD._ABI - num3;
                    }
                    for (int j = num3; j <= _ATD._ABI; j++)
                    {
                        this._AQQ[j]._ASQ = _ASR._ASY;
                        bool flag10 = _AST._ASV != null && _AST._ASV.Length != 0;
                        if (flag10)
                        {
                            this._AQQ[j]._ASP = _AST._ASV[j - num3];
                        }
                    }
                    _AST._ASV = array;
                }
                _bi2 _ASX = ((GCE._ALU != null && GCE._ALU._ABK() == this) ? GCE._ALU : null);
                bool flag11 = _ASX != null && _ASR._ATQ._ABI >= 0;
                if (flag11)
                {
                    _ASX._ABH = _ASR._ATQ.Clone();
                    bool flag12 = _ASR._ATQ == _ASR._ATR;
                    if (flag12)
                    {
                        _ASX._ATL(null);
                    }
                    else
                    {
                        _ASX._ATL(_ASR._ATR.Clone());
                    }
                    _ASX._ATM = _bi2._ATN;
                    _ASX._ATO = true;
                }
                this.UpdateHighlighting(num, num2, true);
                this._ASZ = true;
            }
        }

        // Token: 0x06000411 RID: 1041 RVA: 0x000C7A98 File Offset: 0x000C5C98
        public int CharIndexToColumn(int charIndex, int line, int start)
        {
            bool flag = line >= this.FLOg.Count;
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                string text = this.FLOg[line];
                bool flag2 = text.Length < charIndex;
                if (flag2)
                {
                    charIndex = text.Length;
                }
                int num2 = 0;
                for (int i = start; i < charIndex; i++)
                {
                    num2 += ((text[i] != '\t') ? 1 : (GCE._ASA - num2 % GCE._ASA));
                }
                num = num2;
            }
            return num;
        }

        // Token: 0x06000412 RID: 1042 RVA: 0x000C7B20 File Offset: 0x000C5D20
        public int CharIndexToColumn(int charIndex, int line)
        {
            bool flag = line >= this.FLOg.Count;
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                string text = this.FLOg[line];
                bool flag2 = text.Length < charIndex;
                if (flag2)
                {
                    charIndex = text.Length;
                }
                int num2 = 0;
                for (int i = 0; i < charIndex; i++)
                {
                    num2 += ((text[i] != '\t') ? 1 : (GCE._ASA - num2 % GCE._ASA));
                }
                num = num2;
            }
            return num;
        }

        // Token: 0x06000413 RID: 1043 RVA: 0x000C7BA8 File Offset: 0x000C5DA8
        public int ColumnToCharIndex(ref int column, int line, int rowStart)
        {
            line = Math.Max(0, Math.Min(line, this.FLOg.Count - 1));
            column = Math.Max(0, column);
            bool flag = this.FLOg.Count == 0;
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                string text = this.FLOg[line];
                int num2 = rowStart;
                int num3 = 0;
                while (num2 < text.Length && num3 < column)
                {
                    bool flag2 = text[num2] == '\t';
                    if (flag2)
                    {
                        num3 += GCE._ASA - num3 % GCE._ASA;
                    }
                    else
                    {
                        num3++;
                    }
                    num2++;
                }
                bool flag3 = num2 == text.Length;
                if (flag3)
                {
                    column = num3;
                }
                else
                {
                    bool flag4 = num3 > column;
                    if (flag4)
                    {
                        int num4 = num3 % GCE._ASA;
                        bool flag5 = num4 < GCE._ASA / 2;
                        if (flag5)
                        {
                            num3--;
                            num2--;
                            column -= column % GCE._ASA;
                        }
                        else
                        {
                            column += GCE._ASA - column % GCE._ASA;
                        }
                    }
                }
                num = num2;
            }
            return num;
        }

        // Token: 0x06000414 RID: 1044 RVA: 0x000C7CC0 File Offset: 0x000C5EC0
        public int ColumnToCharIndex(ref int column, int line)
        {
            line = Math.Max(0, Math.Min(line, this._ASK - 1));
            column = Math.Max(0, column);
            bool flag = this.FLOg.Count == 0 || line >= this.FLOg.Count;
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                string text = this.FLOg[line];
                int num2 = 0;
                int num3 = 0;
                while (num2 < text.Length && num3 < column)
                {
                    bool flag2 = text[num2] == '\t';
                    if (flag2)
                    {
                        num3 += GCE._ASA - num3 % GCE._ASA;
                    }
                    else
                    {
                        num3++;
                    }
                    num2++;
                }
                bool flag3 = num2 == text.Length;
                if (flag3)
                {
                    column = num3;
                }
                else
                {
                    bool flag4 = num3 > column;
                    if (flag4)
                    {
                        bool flag5 = column % GCE._ASA < GCE._ASA / 2;
                        if (flag5)
                        {
                            num3--;
                            num2--;
                            column -= column % GCE._ASA;
                        }
                        else
                        {
                            column += GCE._ASA - column % GCE._ASA;
                        }
                    }
                }
                num = num2;
            }
            return num;
        }

        // Token: 0x06000415 RID: 1045 RVA: 0x000C7DE4 File Offset: 0x000C5FE4
        public string GetTextRange(GCE._AFA from, GCE._AFA to)
        {
            bool flag = from == null || to == null;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                bool flag2 = from < to;
                int num;
                int num2;
                int num3;
                int num4;
                if (flag2)
                {
                    num = from._AEU;
                    num2 = from._ABI;
                    num3 = to._AEU;
                    num4 = to._ABI;
                }
                else
                {
                    num = to._AEU;
                    num2 = to._ABI;
                    num3 = from._AEU;
                    num4 = from._ABI;
                }
                StringBuilder stringBuilder = new StringBuilder();
                bool flag3 = num2 == num4;
                if (flag3)
                {
                    stringBuilder.Append(this.FLOg[num2].Substring(num, num3 - num));
                }
                else
                {
                    stringBuilder.Append(this.FLOg[num2].Substring(num) + "\n");
                    for (int i = num2 + 1; i < num4; i++)
                    {
                        stringBuilder.Append(this.FLOg[i]);
                        stringBuilder.Append('\n');
                    }
                    stringBuilder.Append(this.FLOg[num4].Substring(0, num3));
                }
                text = stringBuilder.ToString();
            }
            return text;
        }

        // Token: 0x06000416 RID: 1046 RVA: 0x000C7F18 File Offset: 0x000C6118
        internal static int GetCharClass(char c, bool digitsAsLetters = false, bool ignorePunctuations = false)
        {
            bool flag = c == ' ' || c == '\t';
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                bool flag2 = c >= '0' && c <= '9';
                if (flag2)
                {
                    num = 1;
                }
                else
                {
                    bool flag3 = c == '_' || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
                    if (flag3)
                    {
                        num = (digitsAsLetters ? 1 : 2);
                    }
                    else
                    {
                        num = (ignorePunctuations ? 0 : 3);
                    }
                }
            }
            return num;
        }

        // Token: 0x06000417 RID: 1047 RVA: 0x000C7F90 File Offset: 0x000C6190
        public bool GetWordExtents(int charIndex, int line, out int wordStart, out int wordEnd)
        {
            wordStart = charIndex;
            wordEnd = charIndex;
            bool flag = line >= this._AQQ.Length;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                string text = this.FLOg[line];
                int length = text.Length;
                wordStart = (wordEnd = Math.Min(charIndex, length - 1));
                bool flag3 = wordStart < 0;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    int num = GCE.GetCharClass(text[wordStart], false, false);
                    bool flag4 = wordStart > 0 && num == 0;
                    if (flag4)
                    {
                        wordStart--;
                        num = GCE.GetCharClass(text[wordStart], false, false);
                        bool flag5 = num != 0;
                        if (flag5)
                        {
                            wordEnd--;
                        }
                    }
                    bool flag6 = num == 3;
                    if (flag6)
                    {
                        wordEnd++;
                    }
                    else
                    {
                        bool flag7 = num == 0;
                        if (flag7)
                        {
                            while (wordStart > 0 && GCE.GetCharClass(text[wordStart - 1], false, false) == 0)
                            {
                                wordStart--;
                            }
                            while (wordEnd < length && GCE.GetCharClass(text[wordEnd], false, false) == 0)
                            {
                                wordEnd++;
                            }
                        }
                        else
                        {
                            while (wordStart > 0)
                            {
                                char c = text[wordStart - 1];
                                int charClass = GCE.GetCharClass(c, false, false);
                                bool flag8 = charClass == 1 || charClass == 2 || (num == 1 && c == '.');
                                if (!flag8)
                                {
                                    break;
                                }
                                wordStart--;
                                num = charClass;
                            }
                            while (wordEnd < length)
                            {
                                int charClass2 = GCE.GetCharClass(text[wordEnd], false, false);
                                bool flag9 = charClass2 == 1 || charClass2 == 2 || (num == 1 && text[wordEnd] == '.');
                                if (!flag9)
                                {
                                    break;
                                }
                                wordEnd++;
                            }
                        }
                    }
                    flag2 = true;
                }
            }
            return flag2;
        }

        // Token: 0x06000418 RID: 1048 RVA: 0x000C8178 File Offset: 0x000C6378
        public GCE._AFA WordStopLeft(GCE._AFA from, bool stopOnSubwords)
        {
            bool flag = _bg8._ATS;
            int i = from._AEU;
            int num = from._ABI;
            bool flag2 = i == 0;
            if (flag2)
            {
                bool flag3 = num == 0;
                if (flag3)
                {
                    return new GCE._AFA
                    {
                        _AEU = 0,
                        _ATG = 0,
                        _ABI = 0,
                        _ATF = 0
                    };
                }
                num--;
                i = this.FLOg[num].Length;
            }
            string text = this.FLOg[num];
            bool flag4 = i > 0;
            if (flag4)
            {
                if (stopOnSubwords)
                {
                    int num2 = GCE.GetCharClass(text[--i], false, flag);
                    while (i > 0 && num2 == 0)
                    {
                        num2 = GCE.GetCharClass(text[--i], false, flag);
                    }
                    char c = text[i];
                    while (i > 0)
                    {
                        char c2 = text[i - 1];
                        int charClass = GCE.GetCharClass(c2, false, flag);
                        bool flag5 = !_bg8._ATS;
                        if (flag5)
                        {
                            bool flag6 = charClass != num2;
                            if (flag6)
                            {
                                break;
                            }
                        }
                        else
                        {
                            bool flag7 = charClass != 2 && num2 == 2;
                            if (flag7)
                            {
                                break;
                            }
                            bool flag8 = charClass != 1 && num2 == 1;
                            if (flag8)
                            {
                                break;
                            }
                        }
                        bool flag9 = c2 == '_' && c != '_';
                        if (flag9)
                        {
                            break;
                        }
                        bool flag10 = c >= 'A' && c <= 'Z' && (c2 < 'A' || c2 > 'Z');
                        if (flag10)
                        {
                            break;
                        }
                        i--;
                        bool flag11 = c2 >= 'A' && c2 <= 'Z' && (c < 'A' || c > 'Z');
                        if (flag11)
                        {
                            break;
                        }
                        c = c2;
                    }
                }
                else
                {
                    int num3 = GCE.GetCharClass(text[--i], true, flag);
                    while (i > 0 && num3 == 0)
                    {
                        num3 = GCE.GetCharClass(text[--i], true, flag);
                    }
                    while (i > 0 && GCE.GetCharClass(text[i - 1], true, flag) == num3)
                    {
                        i--;
                    }
                }
                bool flag12 = i == 0;
                if (flag12)
                {
                    bool flag13 = num == 0;
                    if (flag13)
                    {
                        return new GCE._AFA
                        {
                            _AEU = 0,
                            _ATG = 0,
                            _ABI = 0,
                            _ATF = 0
                        };
                    }
                    num--;
                    i = this.FLOg[num].Length;
                }
            }
            return new GCE._AFA
            {
                _AEU = i,
                _ATG = this.CharIndexToColumn(i, num),
                _ABI = num,
                _ATF = i
            };
        }

        // Token: 0x06000419 RID: 1049 RVA: 0x000C8438 File Offset: 0x000C6638
        public GCE._AFA WordStopRight(GCE._AFA from, bool stopOnSubwords)
        {
            bool flag = _bg8._ATS;
            int i = from._AEU;
            int num = from._ABI;
            bool flag2 = i >= this.FLOg[num].Length;
            if (flag2)
            {
                bool flag3 = num == this.FLOg.Count - 1;
                if (flag3)
                {
                    return new GCE._AFA
                    {
                        _AEU = i,
                        _ATG = this.CharIndexToColumn(i, num),
                        _ABI = num,
                        _ATF = i
                    };
                }
                num++;
                i = 0;
            }
            string text = this.FLOg[num];
            bool flag4 = i < text.Length;
            if (flag4)
            {
                int num2 = GCE.GetCharClass(text[i++], !stopOnSubwords, flag);
                bool flag5 = _bg8._ATT;
                if (flag5)
                {
                    bool flag6 = num2 == 0;
                    if (flag6)
                    {
                        while (i < text.Length)
                        {
                            num2 = GCE.GetCharClass(text[i++], !stopOnSubwords, flag);
                            bool flag7 = num2 != 0;
                            if (flag7)
                            {
                                break;
                            }
                        }
                        bool flag8 = i >= text.Length;
                        if (flag8)
                        {
                            return new GCE._AFA
                            {
                                _AEU = i,
                                _ATG = this.CharIndexToColumn(i, num),
                                _ABI = num,
                                _ATF = i
                            };
                        }
                    }
                }
                bool flag9 = num2 != 0;
                if (flag9)
                {
                    if (stopOnSubwords)
                    {
                        char c = ((i > 0) ? text[i - 1] : 'A');
                        char c2 = '\0';
                        int num3 = 4;
                        while (i < text.Length)
                        {
                            c2 = text[i];
                            num3 = GCE.GetCharClass(c2, false, flag);
                            bool flag10 = num3 != num2;
                            if (flag10)
                            {
                                num2 = num3;
                                break;
                            }
                            bool flag11 = (c < 'A' || c > 'Z') && c != '_' && c2 >= 'A' && c2 <= 'Z';
                            if (flag11)
                            {
                                break;
                            }
                            bool flag12 = (_bg8._ATT ? (c != '_' && c2 == '_') : (c == '_' && c2 != '_'));
                            if (flag12)
                            {
                                break;
                            }
                            bool flag13 = c >= 'A' && c <= 'Z' && c2 >= 'A' && c2 <= 'Z';
                            if (flag13)
                            {
                                bool flag14 = i + 1 < text.Length;
                                if (flag14)
                                {
                                    char c3 = text[i + 1];
                                    bool flag15 = GCE.GetCharClass(c3, false, flag) == 2 && (c3 < 'A' || c3 > 'Z');
                                    if (flag15)
                                    {
                                        break;
                                    }
                                }
                            }
                            i++;
                            c = c2;
                            num2 = num3;
                        }
                        bool flag16 = num2 == 2 && num3 == 2 && !_bg8._ATT && c != '_';
                        if (flag16)
                        {
                            while (i < text.Length && c2 == '_')
                            {
                                c2 = text[++i];
                            }
                        }
                    }
                    else
                    {
                        while (i < text.Length)
                        {
                            int charClass = GCE.GetCharClass(text[i], true, flag);
                            bool flag17 = charClass != num2;
                            if (flag17)
                            {
                                num2 = charClass;
                                break;
                            }
                            i++;
                        }
                    }
                }
                bool flag18 = !_bg8._ATT;
                if (flag18)
                {
                    bool flag19 = num2 == 0;
                    if (flag19)
                    {
                        while (i < text.Length && GCE.GetCharClass(text[i], false, flag) == 0)
                        {
                            i++;
                        }
                    }
                }
            }
            return new GCE._AFA
            {
                _AEU = i,
                _ATG = this.CharIndexToColumn(i, num),
                _ABI = num,
                _ATF = i
            };
        }

        // Token: 0x0600041A RID: 1050 RVA: 0x000C8804 File Offset: 0x000C6A04
        public bool _ALW()
        {
            return this._ASJ != this._ASI;
        }

        // Token: 0x0600041B RID: 1051 RVA: 0x000C8828 File Offset: 0x000C6A28
        public bool _ARV()
        {
            return this._ARY || this._ASM != null || this._ASK != this.FLOg.Count;
        }

        // Token: 0x0600041C RID: 1052 RVA: 0x000C8864 File Offset: 0x000C6A64
        public void BeginEdit(string description)
        {
            _bi2 _ASX = ((GCE._ALU != null && GCE._ALU._ABK() == this) ? GCE._ALU : null);
            bool flag = !this._ASZ;
            if (!flag)
            {
                int _ATU = this._ATV;
                this._ATV = _ATU + 1;
                bool flag2 = _ATU == 0;
                if (flag2)
                {
                    GCE._AFA _ATD;
                    if (_ASX == null)
                    {
                        (_ATD = new GCE._AFA())._ABI = -1;
                    }
                    else
                    {
                        _ATD = _ASX._ABH;
                    }
                    GCE._AFA _ATD2 = _ATD;
                    GCE._AFA _ATD3 = ((_ASX != null) ? _ASX._ATW() : null);
                    this._ATX = this._ATX ?? new GCE._ASO();
                    this._ATX._ASU = this._ATX._ASU ?? new List<GCE._ASO._ASS>();
                    this._ATX._ASY = this._AOD + 1;
                    this._ATX._ATY = description;
                    bool flag3 = this._ATX._ATJ == null;
                    if (flag3)
                    {
                        this._ATX._ATJ = _ATD2.Clone();
                    }
                    else
                    {
                        this._ATX._ATJ._ABI = _ATD2._ABI;
                        this._ATX._ATJ._AEU = _ATD2._AEU;
                        this._ATX._ATJ._ATG = _ATD2._ATG;
                        this._ATX._ATJ._ATF = _ATD2._ATF;
                    }
                    bool flag4 = _ATD3 != null;
                    if (flag4)
                    {
                        bool flag5 = this._ATX._ATK == null;
                        if (flag5)
                        {
                            this._ATX._ATK = _ATD3.Clone();
                        }
                        else
                        {
                            this._ATX._ATK._ABI = _ATD3._ABI;
                            this._ATX._ATK._AEU = _ATD3._AEU;
                            this._ATX._ATK._ATG = _ATD3._ATG;
                            this._ATX._ATK._ATF = _ATD3._ATF;
                        }
                    }
                    else
                    {
                        bool flag6 = this._ATX._ATK == null;
                        if (flag6)
                        {
                            this._ATX._ATK = _ATD2.Clone();
                        }
                        else
                        {
                            this._ATX._ATK._ABI = _ATD2._ABI;
                            this._ATX._ATK._AEU = _ATD2._AEU;
                            this._ATX._ATK._ATG = _ATD2._ATG;
                            this._ATX._ATK._ATF = _ATD2._ATF;
                        }
                    }
                    bool flag7 = this._ATZ != null;
                    if (flag7)
                    {
                        this._ATZ.Clear();
                    }
                    else
                    {
                        this._ATZ = new List<GCE.PHFG>();
                    }
                }
            }
        }

        // Token: 0x0600041D RID: 1053 RVA: 0x000C8B20 File Offset: 0x000C6D20
        private void RegisterUndoText(string actionType, GCE._AFA from, GCE._AFA to, string text)
        {
            bool flag = !this._ASZ;
            if (!flag)
            {
                GCE._ASO._ASS _AST = new GCE._ASO._ASS();
                bool flag2 = from < to;
                if (flag2)
                {
                    _AST._ATB = from.Clone();
                    _AST._ATC = to.Clone();
                }
                else
                {
                    _AST._ATB = to.Clone();
                    _AST._ATC = from.Clone();
                }
                _AST._ATH = this.GetTextRange(_AST._ATB, _AST._ATC);
                _AST._ATE = text;
                _AST._ATI = new int[1 + _AST._ATC._ABI - _AST._ATB._ABI];
                _AST._ASV = new int[1 + _AST._ATC._ABI - _AST._ATB._ABI];
                int num = _AST._ATI.Length;
                while (num-- > 0)
                {
                    _AST._ATI[num] = this._AQQ[num + _AST._ATB._ABI]._ASQ;
                    _AST._ASV[num] = this._AQQ[num + _AST._ATB._ABI]._ASP;
                }
                this._ATX._ASU.Add(_AST);
                this._ATX._ATY = actionType;
            }
        }

        // Token: 0x0600041E RID: 1054 RVA: 0x000C8C6C File Offset: 0x000C6E6C
        public void EndEdit()
        {
            bool flag = !this._ASZ;
            if (!flag)
            {
                int num = this._ATV - 1;
                this._ATV = num;
                bool flag2 = num > 0;
                if (!flag2)
                {
                    bool flag3 = this._ATX._ASU.Count == 0;
                    if (!flag3)
                    {
                        _bi2 _ASX = ((GCE._ALU != null && GCE._ALU._ABK() == this) ? GCE._ALU : null);
                        GCE._ASO _AUA = this._ATX;
                        GCE._AFA _ATD;
                        if (_ASX == null)
                        {
                            (_ATD = new GCE._AFA())._ABI = -1;
                        }
                        else
                        {
                            _ATD = _ASX._ABH.Clone();
                        }
                        _AUA._ATQ = _ATD;
                        this._ATX._ATR = ((_ASX != null && _ASX._ATW() != null) ? _ASX._ATW().Clone() : this._ATX._ATQ.Clone());
                        bool flag4 = true;
                        bool flag5 = this._ASJ < this._ASN.Count;
                        if (flag5)
                        {
                            this._ASN.RemoveRange(this._ASJ, this._ASN.Count - this._ASJ);
                            bool flag6 = this._ASI > this._ASJ;
                            if (flag6)
                            {
                                this._ASI = -1;
                            }
                        }
                        else
                        {
                            bool flag7 = _ASX != null && this._ASJ > 0 && this._ATX._ASU.Count == 1;
                            if (flag7)
                            {
                                GCE._ASO _ASR = this._ASN[this._ASJ - 1];
                                bool flag8 = this._ALW() && _ASR._ASU.Count == 1 && _ASR._ATQ == this._ATX._ATJ && _ASR._ATR == this._ATX._ATK && _ASR._ATY == this._ATX._ATY && !_ASR._ATY.StartsWith("*");
                                if (flag8)
                                {
                                    GCE._ASO._ASS _AST = this._ATX._ASU[0];
                                    GCE._ASO._ASS _AST2 = _ASR._ASU[0];
                                    bool flag9 = _AST._ATH == string.Empty && _AST._ATE.Length == 1 && _AST2._ATE != string.Empty;
                                    if (flag9)
                                    {
                                        int charClass = GCE.GetCharClass(_AST._ATE[0], false, false);
                                        int charClass2 = GCE.GetCharClass(_AST2._ATE[_AST2._ATE.Length - 1], false, false);
                                        bool flag10 = charClass == charClass2;
                                        if (flag10)
                                        {
                                            flag4 = false;
                                            GCE._ASO._ASS _AST3 = _AST2;
                                            _AST3._ATE += _AST._ATE;
                                            _ASR._ASU[0] = _AST2;
                                            _ASR._ATQ = this._ATX._ATQ.Clone();
                                            _ASR._ATR = this._ATX._ATR.Clone();
                                        }
                                    }
                                }
                            }
                        }
                        bool flag11 = flag4;
                        if (flag11)
                        {
                            this._ASN.Add(this._ATX);
                            this._ASJ++;
                            this._AOD++;
                            this._ATX = new GCE._ASO();
                        }
                        else
                        {
                            this._ATX._ASU.Clear();
                            this._ATX._ATQ = null;
                            this._ATX._ATR = null;
                        }
                        foreach (GCE.PHFG _AUB in this._ATZ)
                        {
                            _AUB._ASQ = this._AOD;
                        }
                    }
                }
            }
        }

        // Token: 0x0600041F RID: 1055 RVA: 0x000C9038 File Offset: 0x000C7238
        public GCE._AFA DeleteText(GCE._AFA fromPos, GCE._AFA toPos)
        {
            GCE._AFA _ATD = fromPos.Clone();
            GCE._AFA _ATD2 = toPos.Clone();
            int num = _ATD.CompareTo(_ATD2);
            bool flag = num == 0;
            GCE._AFA _ATD3;
            if (flag)
            {
                _ATD3 = _ATD.Clone();
            }
            else
            {
                this.RegisterUndoText("Delete Text", _ATD, _ATD2, string.Empty);
                bool flag2 = num > 0;
                if (flag2)
                {
                    GCE._AFA _ATD4 = _ATD;
                    _ATD = _ATD2;
                    _ATD2 = _ATD4;
                }
                bool flag3 = _ATD._ABI == _ATD2._ABI;
                if (flag3)
                {
                    this.FLOg[_ATD._ABI] = this.FLOg[_ATD._ABI].Remove(_ATD._AEU, _ATD2._AEU - _ATD._AEU);
                }
                else
                {
                    this.FLOg[_ATD._ABI] = this.FLOg[_ATD._ABI].Substring(0, _ATD._AEU) + this.FLOg[_ATD2._ABI].Substring(_ATD2._AEU);
                    this.FLOg.RemoveRange(_ATD._ABI + 1, _ATD2._ABI - _ATD._ABI);
                    int num2 = 1;
                    while (_ATD2._ABI + num2 < this._AQQ.Length)
                    {
                        this._AQQ[_ATD._ABI + num2] = this._AQQ[_ATD2._ABI + num2];
                        this._AQQ[_ATD._ABI + num2].JIKB = _ATD._ABI + num2;
                        num2++;
                    }
                    Array.Resize<GCE.PHFG>(ref this._AQQ, this._AQQ.Length - _ATD2._ABI + _ATD._ABI);
                    this._ASK -= _ATD2._ABI - _ATD._ABI;
                    this.NotifyRemovedLines(_ATD._ABI + 1, _ATD2._ABI - _ATD._ABI);
                }
                this.NotifyRemovedText(_ATD, _ATD2);
                _ATD3 = _ATD;
            }
            return _ATD3;
        }

        // Token: 0x06000420 RID: 1056 RVA: 0x000C9230 File Offset: 0x000C7430
        public bool CanEdit()
        {
            bool flag = this._ALW();
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = !File.Exists(this._ARQ()) || (File.GetAttributes(this._ARQ()) & FileAttributes.ReadOnly) == FileAttributes.None;
                flag2 = flag3;
            }
            return flag2;
        }

        // Token: 0x06000421 RID: 1057 RVA: 0x000C927C File Offset: 0x000C747C
        private void TryP4Checkout()
        {
            bool flag = GCE._AUC == null;
            if (flag)
            {
                GCE._AUC = Type.GetType("P4Connect.Engine,P4Connect");
                bool flag2 = GCE._AUC != null;
                if (flag2)
                {
                    GCE._AUD = GCE._AUC.GetMethod("CheckoutAssets");
                    GCE._AUE = Type.GetType("P4Connect.Queries,P4Connect");
                    bool flag3 = GCE._AUE != null;
                    if (flag3)
                    {
                        GCE._AUF = GCE._AUE.GetMethod("GetFileState");
                    }
                }
            }
            bool flag4 = GCE._AUD == null || GCE._AUF == null;
            if (!flag4)
            {
                GCE._AUD.Invoke(null, new object[] { new string[] { this._ARQ() } });
                EditorApplication.RepaintProjectWindow();
            }
        }

        // Token: 0x06000422 RID: 1058 RVA: 0x000C934C File Offset: 0x000C754C
        public bool TryEdit()
        {
            bool flag = this._ALW() || !File.Exists(this._ARQ()) || (File.GetAttributes(this._ARQ()) & FileAttributes.ReadOnly) == FileAttributes.None;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                Asset assetByGUID = Provider.GetAssetByGUID(this._AMZ);
                bool flag3 = assetByGUID == null;
                if (flag3)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag4 = (assetByGUID.state & 16384) == null || (assetByGUID.state & 256) > 0;
                    if (flag4)
                    {
                        bool flag5 = (assetByGUID.state & 256) == 0;
                        if (flag5)
                        {
                            bool flag6 = File.Exists(this._ARQ()) && (File.GetAttributes(this._ARQ()) & FileAttributes.ReadOnly) > FileAttributes.None;
                            if (flag6)
                            {
                                this.TryP4Checkout();
                            }
                        }
                        bool flag7 = File.Exists(this._ARQ()) && (File.GetAttributes(this._ARQ()) & FileAttributes.ReadOnly) > FileAttributes.None;
                        flag2 = !flag7 || this.EditReadOnly();
                    }
                    else
                    {
                        bool flag8 = false;
                        Task task = Provider.Checkout(assetByGUID, 3);
                        try
                        {
                            task.Wait();
                            foreach (Message message in task.messages)
                            {
                                bool flag9 = (int)message.severity == 3 || (int)message.severity == 4;
                                if (flag9)
                                {
                                    message.Show();
                                }
                            }
                            flag8 = task.success;
                        }
                        catch (Exception ex)
                        {
                            
                        }
                        finally
                        {
                            bool flag10 = task != null;
                            if (flag10)
                            {
                                task.Dispose();
                            }
                        }
                        flag2 = flag8 || this.EditReadOnly();
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000423 RID: 1059 RVA: 0x000C9508 File Offset: 0x000C7708
        private bool EditReadOnly()
        {
            string fileName = Path.GetFileName(this._ARQ());
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            bool flag = EditorUtility.DisplayDialog("SuperEditor", "The file '" + fileName + "' is read-only! You may not be able to save the changes.\n\nWould you still like to edit it?          \n\n", "Yes, Edit in Memory", "No, Don't Edit");
            bool flag2 = focusedWindow;
            if (flag2)
            {
                focusedWindow.Focus();
            }
            return flag;
        }

        // Token: 0x06000424 RID: 1060 RVA: 0x000C9568 File Offset: 0x000C7768
        public GCE._AFA InsertText(GCE._AFA position, string text)
        {
            GCE._AFA _ATD = new GCE._AFA
            {
                _AEU = position._AEU,
                _ATG = position._ATG,
                _ATF = position._ATG,
                _ABI = position._ABI
            };
            GCE._AFA _ATD2 = new GCE._AFA
            {
                _AEU = position._AEU,
                _ATG = position._ATG,
                _ATF = position._ATG,
                _ABI = position._ABI
            };
            string[] array = text.Split(new char[] { '\n' }, StringSplitOptions.None);
            bool flag = this._ASZ && _bg8._AUG;
            if (flag)
            {
                _bb2 _AUH = _bg8._ASA;
                int num = _ATD._ATG;
                for (int i = 0; i < array.Length; i++)
                {
                    text = array[i];
                    int num2;
                    while ((num2 = text.IndexOf('\t')) >= 0)
                    {
                        int num3 = num + num2;
                        num3 = _AUH - num3 % _AUH;
                        text = text.Substring(0, num2) + new string(' ', num3) + text.Substring(num2 + 1);
                    }
                    array[i] = text;
                    num = 0;
                }
                bool flag2 = array.Length > 1;
                if (flag2)
                {
                    text = string.Join("\n", array);
                }
            }
            this.RegisterUndoText("Insert Text", position, position, text);
            bool flag3 = array.Length == 1;
            if (flag3)
            {
                this.FLOg[_ATD._ABI] = this.FLOg[_ATD._ABI].Insert(_ATD._AEU, text);
                _ATD2._AEU += text.Length;
                _ATD2._ATG = (_ATD2._ATF = this.CharIndexToColumn(_ATD2._AEU, _ATD2._ABI));
            }
            else
            {
                this.FLOg.Insert(_ATD._ABI + 1, array[array.Length - 1] + this.FLOg[_ATD._ABI].Substring(_ATD._AEU));
                this.FLOg[_ATD._ABI] = this.FLOg[_ATD._ABI].Substring(0, _ATD._AEU) + array[0];
                for (int j = 1; j < array.Length - 1; j++)
                {
                    this.FLOg.Insert(_ATD._ABI + j, array[j]);
                }
                _ATD2._AEU = array[array.Length - 1].Length;
                _ATD2._ABI = _ATD._ABI + array.Length - 1;
                _ATD2._ATG = (_ATD2._ATF = this.CharIndexToColumn(_ATD2._AEU, _ATD2._ABI));
                Array.Resize<GCE.PHFG>(ref this._AQQ, this._AQQ.Length + array.Length - 1);
                for (int k = this._AQQ.Length - 1; k > _ATD2._ABI; k--)
                {
                    this._AQQ[k] = this._AQQ[k - array.Length + 1];
                    this._AQQ[k].JIKB = k;
                }
                for (int l = 1; l <= array.Length - 1; l++)
                {
                    this._AQQ[_ATD._ABI + l] = new GCE.PHFG
                    {
                        JIKB = _ATD._ABI + l
                    };
                }
                this._ASK = this._AQQ.Length;
                this.NotifyInsertedLines(_ATD._ABI + 1, array.Length - 1);
            }
            this.NotifyInsertedText(position, _ATD2);
            return _ATD2;
        }

        // Token: 0x06000425 RID: 1061 RVA: 0x000C9910 File Offset: 0x000C7B10
        private void NotifyInsertedLines(int lineIndex, int numLines)
        {
            bool flag = this._AUI != null;
            if (flag)
            {
                this._AUI(lineIndex, numLines);
            }
            bool flag2 = GCE._AUJ != null;
            if (flag2)
            {
                GCE._AUJ(this._AMZ, lineIndex, numLines);
            }
        }

        // Token: 0x06000426 RID: 1062 RVA: 0x000C9958 File Offset: 0x000C7B58
        private void NotifyInsertedText(GCE._AFA from, GCE._AFA to)
        {
            _bc5.OnInsertedText(this, from, to);
            bool flag = this._AUK != null;
            if (flag)
            {
                this._AUK(from.Clone(), to.Clone());
            }
            bool flag2 = GCE._AUL != null;
            if (flag2)
            {
                GCE._AUL(this._AMZ, from.Clone(), to.Clone());
            }
        }

        // Token: 0x06000427 RID: 1063 RVA: 0x000C99C0 File Offset: 0x000C7BC0
        private void NotifyRemovedLines(int lineIndex, int numLines)
        {
            bool flag = this._AUM != null;
            if (flag)
            {
                this._AUM(lineIndex, numLines);
            }
            bool flag2 = GCE._AUN != null;
            if (flag2)
            {
                GCE._AUN(this._AMZ, lineIndex, numLines);
            }
        }

        // Token: 0x06000428 RID: 1064 RVA: 0x000C9A08 File Offset: 0x000C7C08
        private void NotifyRemovedText(GCE._AFA from, GCE._AFA to)
        {
            _bc5.OnRemovedText(this, from, to);
            bool flag = this._AUO != null;
            if (flag)
            {
                this._AUO(from.Clone(), to.Clone());
            }
            bool flag2 = GCE._AUP != null;
            if (flag2)
            {
                GCE._AUP(this._AMZ, from.Clone(), to.Clone());
            }
        }

        // Token: 0x06000429 RID: 1065 RVA: 0x000C9A70 File Offset: 0x000C7C70
        public int FirstNonWhitespace(int atLine)
        {
            int i = 0;
            string text = this.FLOg[atLine];
            while (i < text.Length)
            {
                char c = text[i];
                bool flag = c != ' ' && c != '\t';
                if (flag)
                {
                    break;
                }
                i++;
            }
            return i;
        }

        // Token: 0x0600042A RID: 1066 RVA: 0x000C9ACC File Offset: 0x000C7CCC
        public TextPosition FirstNonWhitespacePos(int fromLine, int fromCharIndex)
        {
            int i = fromCharIndex;
            for (int j = fromLine; j < this.FLOg.Count; j++)
            {
                string text = this.FLOg[j];
                while (i < text.Length)
                {
                    char c = text[i];
                    bool flag = c != ' ' && c != '\t';
                    if (flag)
                    {
                        return new TextPosition(j, i);
                    }
                    i++;
                }
                i = 0;
            }
            return new TextPosition(this.FLOg.Count, 0);
        }

        // Token: 0x0600042B RID: 1067 RVA: 0x000C9B64 File Offset: 0x000C7D64
        internal static string ExpandTabs(string s, int startAtColumn)
        {
            int num = s.IndexOf('\t', 0);
            bool flag = num == -1;
            string text;
            if (flag)
            {
                text = s;
            }
            else
            {
                bool flag2 = GCE._ASA != GCE._AUQ;
                if (flag2)
                {
                    GCE._AUQ = GCE._ASA;
                    GCE._AUR = new Dictionary<string, string>[]
                    {
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>(),
                        new Dictionary<string, string>()
                    };
                }
                string text2;
                bool flag3 = GCE._AUR[startAtColumn % GCE._ASA].TryGetValue(s, out text2);
                if (flag3)
                {
                    text = text2;
                }
                else
                {
                    int num2 = 0;
                    StringBuilder stringBuilder = new StringBuilder();
                    while ((num = s.IndexOf('\t', num2)) != -1)
                    {
                        stringBuilder.Append(s, num2, num - num2);
                        stringBuilder.Append(' ', GCE._ASA - (stringBuilder.Length + startAtColumn) % GCE._ASA);
                        num2 = num + 1;
                    }
                    bool flag4 = num2 == 0;
                    if (flag4)
                    {
                        text = s;
                    }
                    else
                    {
                        stringBuilder.Append(s.Substring(num2));
                        text2 = stringBuilder.ToString();
                        GCE._AUR[startAtColumn % GCE._ASA][s] = text2;
                        text = text2;
                    }
                }
            }
            return text;
        }

        // Token: 0x0600042C RID: 1068 RVA: 0x000C9CB0 File Offset: 0x000C7EB0
        private void Parse(int parseToLine)
        {
            bool flag = this._ASM == null;
            if (!flag)
            {
                for (int i = this._ASK; i < parseToLine; i++)
                {
                    bool flag2 = i == 0;
                    string text2;
                    if (flag2)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        while (!this._ASM.EndOfStream)
                        {
                            char[] array = new char[1];
                            this._ASM.ReadBlock(array, 0, 1);
                            bool flag3 = array[0] == '\r' || array[0] == '\n';
                            if (flag3)
                            {
                                this._ASG = array[0].ToString();
                                bool flag4 = !this._ASM.EndOfStream;
                                if (flag4)
                                {
                                    string text = char.ConvertFromUtf32(this._ASM.Peek());
                                    bool flag5 = text != this._ASG && (text == "\r" || text == "\n");
                                    if (flag5)
                                    {
                                        this._ASG += text;
                                        this._ASM.ReadBlock(array, 0, 1);
                                    }
                                }
                                break;
                            }
                            stringBuilder.Append(array[0]);
                        }
                        text2 = stringBuilder.ToString();
                        bool flag6 = this._ASM != null;
                        if (flag6)
                        {
                            this._ARP = this._ASM.CurrentEncoding.CodePage;
                        }
                    }
                    else
                    {
                        text2 = this._ASM.ReadLine();
                    }
                    bool flag7 = text2 == null;
                    if (flag7)
                    {
                        bool flag8 = this._ASM.BaseStream.Position > 0L;
                        if (flag8)
                        {
                            this._ASM.BaseStream.Position -= 1L;
                            int num = this._ASM.BaseStream.ReadByte();
                            bool flag9 = num == 0 && this._ASM.BaseStream.Position > 1L;
                            if (flag9)
                            {
                                this._ASM.BaseStream.Position -= 2L;
                                num = this._ASM.BaseStream.ReadByte();
                            }
                            bool flag10 = num == 10 || num == 13;
                            if (flag10)
                            {
                                this.FLOg.Add(string.Empty);
                            }
                        }
                        this._ASM.Close();
                        this._ASM.Dispose();
                        this._ASM = null;
                        this._ARY = false;
                        break;
                    }
                    this.FLOg.Add(text2);
                }
                bool flag11 = this._AQQ.Length == parseToLine;
                if (!flag11)
                {
                    parseToLine = Math.Min(parseToLine, this.FLOg.Count);
                    Array.Resize<GCE.PHFG>(ref this._AQQ, parseToLine);
                    for (int j = this._ASK; j < parseToLine; j++)
                    {
                        this.FormatLine(j);
                    }
                    this._ASK = parseToLine;
                }
            }
        }

        // Token: 0x0600042D RID: 1069 RVA: 0x000C9FA8 File Offset: 0x000C81A8
        private void ProgressiveParseOnUpdate()
        {
            bool flag = this._AUS == null || !this._AUS();
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveParseOnUpdate));
                this._AUS = null;
            }
        }

        // Token: 0x0600042E RID: 1070 RVA: 0x000C9FFC File Offset: 0x000C81FC
        public SyntaxToken FirstNonTriviaToken(int line)
        {
            GCE.PHFG _AUB = this._AQQ[line];
            bool flag = _AUB == null;
            SyntaxToken syntaxToken;
            if (flag)
            {
                syntaxToken = null;
            }
            else
            {
                List<SyntaxToken> _ABS = _AUB.EOIA;
                bool flag2 = _ABS == null || _ABS.Count == 0;
                if (flag2)
                {
                    syntaxToken = null;
                }
                else
                {
                    SyntaxToken syntaxToken2 = null;
                    for (int i = 0; i < _ABS.Count; i++)
                    {
                        bool flag3 = _ABS[i].tokenKind > SyntaxToken.Kind.LastWSToken;
                        if (flag3)
                        {
                            syntaxToken2 = _ABS[i];
                            break;
                        }
                    }
                    syntaxToken = syntaxToken2;
                }
            }
            return syntaxToken;
        }

        // Token: 0x0600042F RID: 1071 RVA: 0x000CA08C File Offset: 0x000C828C
        public void GetFirstTokens(int line, out SyntaxToken firstToken, out SyntaxToken firstNonTrivia)
        {
            firstToken = null;
            firstNonTrivia = null;
            List<SyntaxToken> _ABS = this._AQQ[line].EOIA;
            for (int i = 0; i < _ABS.Count; i++)
            {
                SyntaxToken syntaxToken = _ABS[i];
                bool flag = syntaxToken.tokenKind > SyntaxToken.Kind.Whitespace;
                if (flag)
                {
                    firstToken = syntaxToken;
                    for (; ; )
                    {
                        bool flag2 = _ABS[i].tokenKind > SyntaxToken.Kind.LastWSToken && _ABS[i].OOME != null && _ABS[i].OOME.OOME != null;
                        if (flag2)
                        {
                            break;
                        }
                        i++;
                        if (i >= _ABS.Count)
                        {
                            goto IL_008F;
                        }
                    }
                    firstNonTrivia = _ABS[i];
                IL_008F:
                    break;
                }
            }
        }

        // Token: 0x06000430 RID: 1072 RVA: 0x000CA144 File Offset: 0x000C8344
        public SyntaxToken FirstNonWhitespaceToken(int line)
        {
            List<SyntaxToken> _ABS = this._AQQ[line].EOIA;
            bool flag = _ABS == null || _ABS.Count == 0;
            SyntaxToken syntaxToken;
            if (flag)
            {
                syntaxToken = null;
            }
            else
            {
                for (int i = 0; i < _ABS.Count; i++)
                {
                    bool flag2 = _ABS[i].tokenKind != SyntaxToken.Kind.Whitespace;
                    if (flag2)
                    {
                        return _ABS[i];
                    }
                }
                syntaxToken = null;
            }
            return syntaxToken;
        }

        // Token: 0x06000431 RID: 1073 RVA: 0x000CA1B8 File Offset: 0x000C83B8
        public TextPosition GetOpeningBraceLeftOf(int tokenLine, int tokenIndex, int maxLinesDistance)
        {
            int num = ((maxLinesDistance >= 0) ? Mathf.Max(0, tokenLine - maxLinesDistance) : 0);
            TextPosition textPosition = default(TextPosition);
            List<SyntaxToken> list = this._AQQ[tokenLine].EOIA;
            int num2 = 0;
            while (tokenIndex < 0)
            {
                bool flag = --tokenLine < num;
                if (flag)
                {
                    break;
                }
                list = this._AQQ[tokenLine].EOIA;
                tokenIndex = list.Count - 1;
            }
            while (tokenIndex >= 0)
            {
                SyntaxToken syntaxToken = list[tokenIndex];
                string text = syntaxToken.text;
                bool flag2 = syntaxToken.tokenKind == SyntaxToken.Kind.Punctuator && text.Length == 1;
                if (flag2)
                {
                    char c = text[0];
                    bool flag3 = '(' == c || '[' == c || '{' == c;
                    if (flag3)
                    {
                        bool flag4 = num2 > 0;
                        if (!flag4)
                        {
                            textPosition = new TextPosition(tokenLine, tokenIndex);
                            break;
                        }
                        num2--;
                    }
                    else
                    {
                        bool flag5 = ')' == c || ']' == c || '}' == c;
                        if (flag5)
                        {
                            num2++;
                        }
                    }
                }
                while (--tokenIndex < 0)
                {
                    bool flag6 = --tokenLine < num;
                    if (flag6)
                    {
                        break;
                    }
                    list = this._AQQ[tokenLine].EOIA;
                    tokenIndex = list.Count;
                }
            }
            return textPosition;
        }

        // Token: 0x06000432 RID: 1074 RVA: 0x000CA318 File Offset: 0x000C8518
        public TextPosition GetClosingBraceRightOf(int tokenLine, int tokenIndex, int maxLinesDistance)
        {
            int num = ((maxLinesDistance >= 0) ? Mathf.Min(this._AQQ.Length - 1, tokenLine + maxLinesDistance) : (this._AQQ.Length - 1));
            List<SyntaxToken> list = this._AQQ[tokenLine].EOIA;
            bool flag = list == null;
            TextPosition textPosition;
            if (flag)
            {
                textPosition = default(TextPosition);
            }
            else
            {
                int num2 = 0;
                int num3 = list.Count;
                while (tokenLine <= num)
                {
                    while (++tokenIndex >= num3)
                    {
                        bool flag2 = ++tokenLine > num;
                        if (flag2)
                        {
                            break;
                        }
                        list = this._AQQ[tokenLine].EOIA;
                        bool flag3 = list == null;
                        if (flag3)
                        {
                            return default(TextPosition);
                        }
                        tokenIndex = -1;
                        num3 = list.Count;
                    }
                    bool flag4 = tokenIndex >= num3;
                    if (flag4)
                    {
                        break;
                    }
                    SyntaxToken syntaxToken = list[tokenIndex];
                    string text = syntaxToken.text;
                    bool flag5 = syntaxToken.tokenKind == SyntaxToken.Kind.Punctuator && text.Length == 1;
                    if (flag5)
                    {
                        char c = text[0];
                        bool flag6 = ')' == c || ']' == c || '}' == c;
                        if (flag6)
                        {
                            bool flag7 = num2 > 0;
                            if (!flag7)
                            {
                                return new TextPosition(tokenLine, tokenIndex);
                            }
                            num2--;
                        }
                        else
                        {
                            bool flag8 = '(' == c || '[' == c || '{' == c;
                            if (flag8)
                            {
                                num2++;
                            }
                        }
                    }
                }
                textPosition = default(TextPosition);
            }
            return textPosition;
        }

        // Token: 0x06000433 RID: 1075 RVA: 0x000CA4A8 File Offset: 0x000C86A8
        public string GetAutoIndentAfter(int line)
        {
            bool flag = line < 0;
            string text;
            if (flag)
            {
                text = "";
            }
            else
            {
                int num = line;
                int count = this._AQQ[line].EOIA.Count;
                SyntaxToken nonTriviaTokenLeftOf = this.GetNonTriviaTokenLeftOf(ref num, ref count);
                bool flag2 = nonTriviaTokenLeftOf == null;
                if (flag2)
                {
                    text = "";
                }
                else
                {
                    List<SyntaxToken> _ABS = this._AQQ[num].EOIA;
                    text = ((_ABS[0].tokenKind == SyntaxToken.Kind.Whitespace) ? _ABS[0].text : "");
                }
            }
            return text;
        }

        // Token: 0x06000434 RID: 1076 RVA: 0x000CA534 File Offset: 0x000C8734
        public string CalcAutoIndent(int line)
        {
            bool flag = !_bg8._AUT;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                SyntaxToken syntaxToken;
                SyntaxToken syntaxToken2;
                this.GetFirstTokens(line, out syntaxToken, out syntaxToken2);
                bool flag2 = syntaxToken2 != null && syntaxToken2.OOME._AJB != null;
                if (flag2)
                {
                    text = null;
                }
                else
                {
                    _bb4.DHBA _AEM = ((syntaxToken2 != null) ? syntaxToken2.OOME : null);
                    bool flag3 = _AEM == null && (syntaxToken == null || syntaxToken.text.StartsWith("#", StringComparison.Ordinal));
                    if (flag3)
                    {
                        text = null;
                    }
                    else
                    {
                        string text2 = null;
                        int num = 0;
                        _bb4.DHBA _AEM2 = null;
                        _bb4._ACW _AGZ = ((_AEM != null) ? _AEM.OOME : null);
                        short num2 = ((short)((_AEM != null) ? (int)_AEM._AIL : 0));
                        bool flag4 = _AEM == null;
                        if (flag4)
                        {
                            SyntaxToken nonTriviaTokenLeftOf = this.GetNonTriviaTokenLeftOf(line, 0);
                            bool flag5 = nonTriviaTokenLeftOf == null;
                            if (flag5)
                            {
                                return "";
                            }
                            bool flag6 = nonTriviaTokenLeftOf.OOME == null;
                            if (flag6)
                            {
                                return null;
                            }
                            _bb4._AIN _AIO = nonTriviaTokenLeftOf.OOME;
                            bool flag7 = _AIO == null;
                            if (flag7)
                            {
                                return null;
                            }
                            _bh2._AJH _BDV = this._ASF.MoveAfterLeaf(nonTriviaTokenLeftOf.OOME);
                            bool flag8 = _BDV == null;
                            if (flag8)
                            {
                                return null;
                            }
                            _bh2._ACW _BEX = _BDV._BDL;
                            _BEX.OOME.NextAfterChild(_BEX, _BDV);
                            _AGZ = _BDV._AJT;
                            while (_AIO.OOME != null && _AIO.OOME != _AGZ)
                            {
                                _AIO = _AIO.OOME;
                            }
                            bool flag9 = _AIO.OOME != _AGZ;
                            if (flag9)
                            {
                                return null;
                            }
                            num2 = (short)((int)_AIO._AIL + 1);
                        }
                        bool flag10 = _AEM != null && (_AEM.IsLit("{") || _AEM.IsLit("[") || _AEM.IsLit("("));
                        if (flag10)
                        {
                            do
                            {
                                while (_AGZ != null && _AGZ._AIL > 0)
                                {
                                    bool flag11 = true;
                                    bool flag12 = true;
                                    short num3 = _AGZ._AIL;
                                    _bb4.DHBA _AEM3;
                                    for (; ; )
                                    {
                                        short num4 = num3;
                                        num3 = (short)(num4 - (short)1);
                                        if (num4 <= 0)
                                        {
                                            break;
                                        }
                                        _AEM3 = _AGZ.OOME.LeafAt((int)num3);
                                        bool flag13 = _AEM3 == null;
                                        if (!flag13)
                                        {
                                            bool flag14 = _AEM3.IsLit("{") || (flag11 && _AEM3.IsLit("[")) || (flag12 && _AEM3.IsLit("("));
                                            if (flag14)
                                            {
                                                goto Block_25;
                                            }
                                            bool flag15 = _AEM3.IsLit(",");
                                            if (flag15)
                                            {
                                                goto Block_26;
                                            }
                                            bool flag16 = _AEM3.IsLit(")");
                                            if (flag16)
                                            {
                                                flag12 = false;
                                            }
                                            else
                                            {
                                                bool flag17 = _AEM3.IsLit("]");
                                                if (flag17)
                                                {
                                                    flag11 = false;
                                                }
                                            }
                                        }
                                    }
                                IL_02DC:
                                    bool flag18 = _AEM2 != null;
                                    if (flag18)
                                    {
                                        break;
                                    }
                                    _AGZ = _AGZ.OOME;
                                    continue;
                                Block_25:
                                    _AEM2 = _AEM3;
                                    num = 1;
                                    goto IL_02DC;
                                Block_26:
                                    _AGZ = _AEM3.FindPreviousNode() as _bb4._ACW;
                                    _AEM2 = ((_AGZ != null) ? _AGZ.GetFirstLeaf() : _AEM3);
                                    _AGZ = null;
                                    num = 0;
                                    goto IL_02DC;
                                }
                                bool flag19 = _AGZ != null;
                                if (flag19)
                                {
                                    _AGZ = _AGZ.OOME;
                                }
                            }
                            while (_AGZ != null && _AGZ.GetFirstLeaf() == _AEM);
                            bool flag20 = _AGZ != null;
                            if (flag20)
                            {
                                _AEM2 = _AGZ.GetFirstLeaf();
                                bool flag21 = _AEM2 != null && _AEM2.IsLit("{");
                                if (flag21)
                                {
                                    num = 1;
                                }
                            }
                        }
                        else
                        {
                            bool flag22 = _AEM != null && (_AEM.IsLit("}") || _AEM.IsLit("]") || _AEM.IsLit(")"));
                            if (flag22)
                            {
                                string text3 = _AEM._ACX.text;
                                text3 = ((text3 == "}") ? "{" : ((text3 == "]") ? "[" : "("));
                                short num5 = _AEM._AIL;
                                for (; ; )
                                {
                                    short num6 = num5;
                                    num5 = num6 - 1;
                                    if (num6 <= 0)
                                    {
                                        break;
                                    }
                                    _AEM2 = _AGZ.LeafAt((int)num5);
                                    bool flag23 = _AEM2 != null;
                                    if (flag23)
                                    {
                                        bool flag24 = _AEM2.IsLit(text3);
                                        if (flag24)
                                        {
                                            break;
                                        }
                                        _AEM2 = null;
                                    }
                                }
                            }
                            else
                            {
                                bool flag25 = _AGZ != null;
                                if (flag25)
                                {
                                    while (_AGZ != null)
                                    {
                                        short num7 = num2;
                                        num2 = _AGZ._AIL;
                                        string text4 = _AGZ._AHB();
                                        bool flag26 = text4 == null;
                                        if (flag26)
                                        {
                                            break;
                                        }
                                        bool flag27 = text4 == "embeddedStatement";
                                        if (flag27)
                                        {
                                            bool flag28 = _AGZ.OOME._AHB() != "statement";
                                            if (flag28)
                                            {
                                                _AEM2 = _AGZ.OOME.GetFirstLeaf();
                                                num = 1;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            bool flag29 = text4 == "statement";
                                            if (flag29)
                                            {
                                                _AEM2 = _AGZ.GetFirstLeaf();
                                                bool flag30 = _AEM2 != _AEM;
                                                if (flag30)
                                                {
                                                    num = 1;
                                                    break;
                                                }
                                                _AEM2 = null;
                                            }
                                            else
                                            {
                                                bool flag31 = text4 == "elseStatement";
                                                if (flag31)
                                                {
                                                    _AGZ = _AGZ.OOME;
                                                    _AEM2 = _AGZ.GetFirstLeaf();
                                                    break;
                                                }
                                                bool flag32 = text4 == "switchLabel";
                                                if (flag32)
                                                {
                                                    _AGZ = _AGZ.OOME;
                                                    bool flag33 = num2 == 0;
                                                    if (flag33)
                                                    {
                                                        bool flag34 = _AGZ._AIL >= 2;
                                                        if (flag34)
                                                        {
                                                            _AGZ = _AGZ.OOME.NodeAt(1);
                                                        }
                                                        else
                                                        {
                                                            _AGZ = _AGZ.OOME;
                                                        }
                                                    }
                                                    _AEM2 = _AGZ.GetFirstLeaf();
                                                    break;
                                                }
                                                bool flag35 = text4 == "switchSection";
                                                if (flag35)
                                                {
                                                    bool flag36 = num7 > 0;
                                                    if (flag36)
                                                    {
                                                        _AEM2 = _AGZ.GetFirstLeaf();
                                                        num = 1;
                                                    }
                                                    else
                                                    {
                                                        _AEM2 = _AGZ.OOME.GetFirstLeaf();
                                                    }
                                                    break;
                                                }
                                                bool flag37 = text4 == "labeledStatement" && num2 < 2;
                                                if (flag37)
                                                {
                                                    _AGZ = _AGZ.OOME.OOME.OOME;
                                                    _AEM2 = _AGZ.GetFirstLeaf();
                                                    break;
                                                }
                                                bool flag38 = text4 == "fieldDeclaration" || text4 == "eventDeclaration";
                                                if (flag38)
                                                {
                                                    _AGZ = _AGZ.OOME;
                                                    _AEM2 = _AGZ.GetFirstLeaf();
                                                    num = 1;
                                                    break;
                                                }
                                                bool flag39 = text4 == "constantDeclaration";
                                                if (flag39)
                                                {
                                                    _AGZ = _AGZ.OOME.OOME;
                                                    _AEM2 = _AGZ.GetFirstLeaf();
                                                    num = 1;
                                                    break;
                                                }
                                                bool flag40 = text4 == "formalParameterList";
                                                if (flag40)
                                                {
                                                    _AGZ = _AGZ.OOME;
                                                    _AEM2 = _AGZ.GetFirstLeaf();
                                                    num = 1;
                                                    break;
                                                }
                                            }
                                        }
                                        short num8 = num2;
                                        _bb4.DHBA _AEM4;
                                        for (; ; )
                                        {
                                            short num9 = num8;
                                            num8 = num9 - 1;
                                            if (num9 <= 0)
                                            {
                                                break;
                                            }
                                            _AEM4 = _AGZ.LeafAt((int)num8);
                                            bool flag41 = _AEM4 != null && _AEM4.IsLit("{");
                                            if (flag41)
                                            {
                                                goto Block_65;
                                            }
                                        }
                                    IL_06EE:
                                        bool flag42 = _AEM2 != null;
                                        if (flag42)
                                        {
                                            break;
                                        }
                                        _AGZ = _AGZ.OOME;
                                        continue;
                                    Block_65:
                                        _AEM2 = _AEM4;
                                        num = 1;
                                        goto IL_06EE;
                                    }
                                }
                            }
                        }
                        bool flag43 = _AEM2 != null;
                        if (flag43)
                        {
                            text2 = this.FLOg[_AEM2.line].Substring(0, this.FirstNonWhitespace(_AEM2.line));
                            bool flag44 = num > 0;
                            if (flag44)
                            {
                                text2 = new string('\t', num) + text2;
                            }
                            else
                            {
                                int num10 = 0;
                                while (num < 0 && num10 < text2.Length)
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        bool flag45 = text2[num10++] == '\t';
                                        if (flag45)
                                        {
                                            break;
                                        }
                                    }
                                    num++;
                                }
                                text2 = text2.Substring(num10);
                            }
                        }
                        text = text2;
                    }
                }
            }
            return text;
        }

        // Token: 0x06000435 RID: 1077 RVA: 0x000CAD10 File Offset: 0x000C8F10
        public void UpdateHighlighting(int fromLine, int toLineInclusive, bool keepLastChangeId = false)
        {
            bool flag = this._AUS != null;
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveParseOnUpdate));
                this._AUS = null;
            }
            bool flag2 = this._ASF != null;
            if (flag2)
            {
                this._ASF.CutParseTree(toLineInclusive + 1, this._AQQ);
            }
            for (int i = fromLine; i <= toLineInclusive; i++)
            {
                GCE.PHFG _AUB = this._AQQ[i];
                bool flag3 = _AUB == null || _AUB.EOIA == null;
                if (!flag3)
                {
                    List<SyntaxToken> _ABS = _AUB.EOIA;
                    for (int j = 0; j < _ABS.Count; j++)
                    {
                        SyntaxToken syntaxToken = _ABS[j];
                        bool flag4 = syntaxToken.OOME != null;
                        if (flag4)
                        {
                            syntaxToken.OOME.ReparseToken();
                        }
                    }
                }
            }
            bool flag5 = this._ASF != null;
            if (flag5)
            {
                this._ASF._ARD = false;
            }
            int num = this.UpdateLexer(fromLine, toLineInclusive, keepLastChangeId);
            bool flag6 = this._ASF != null;
            if (flag6)
            {
                this._ASF.CutParseTree(num, this._AQQ);
                bool _AUU = this._ASF._ARD;
                if (_AUU)
                {
                    bool flag7 = fromLine != 0;
                    if (flag7)
                    {
                        this._ASF._ARD = false;
                        bool _AUV = this._ASZ;
                        this._ASZ = false;
                        this.UpdateHighlighting(0, this._AQQ.Length - 1, true);
                        this._ASZ = _AUV;
                        return;
                    }
                }
            }
            for (int k = num; k < fromLine; k++)
            {
                for (int l = 0; l < this._AQQ[k].EOIA.Count; l++)
                {
                    SyntaxToken syntaxToken2 = this._AQQ[k].EOIA[l];
                    bool flag8 = syntaxToken2.OOME != null;
                    if (flag8)
                    {
                        syntaxToken2.OOME.ReparseToken();
                    }
                }
            }
            bool flag9 = this._ASF != null;
            if (flag9)
            {
                Func<bool> func = this._ASF.Update(num, toLineInclusive);
                bool flag10 = func != null;
                if (flag10)
                {
                    this._AUS = func;
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.ProgressiveParseOnUpdate));
                }
            }
            this.UpdateViews();
        }

        // Token: 0x06000436 RID: 1078 RVA: 0x000CAF78 File Offset: 0x000C9178
        private int UpdateLexer(int fromLine, int toLineInclusive, bool keepLastChangeId)
        {
            int num = fromLine;
            int i;
            for (i = fromLine; i <= toLineInclusive; i++)
            {
                num = Mathf.Clamp(i - this._AQQ[i]._AUW, 0, num);
                this.FormatLine(i);
                bool flag = !keepLastChangeId;
                if (flag)
                {
                    this._AQQ[i]._ASQ = this._AOD;
                }
                bool _AUV = this._ASZ;
                if (_AUV)
                {
                    this._ATZ.Add(this._AQQ[i]);
                }
            }
            bool flag2 = fromLine != 0 && this._ASF != null && this._ASF._ARD;
            int num2;
            if (flag2)
            {
                num2 = -1;
            }
            else
            {
                while (i < this._AQQ.Length)
                {
                    GCE.PHFG _AUB = this._AQQ[i];
                    num = Mathf.Clamp(i - _AUB._AUW, 0, num);
                    GCE._ACP _ACR = _AUB._ACO;
                    GCE._ABW _AUX = _AUB._ABZ;
                    this.FormatLine(i);
                    bool flag3 = fromLine != 0 && this._ASF != null && this._ASF._ARD;
                    if (flag3)
                    {
                        return -1;
                    }
                    _AUB = this._AQQ[i++];
                    bool flag4 = (this._ASF == null || !this._ASF._ARD) && _ACR == _AUB._ACO && _AUX == _AUB._ABZ;
                    if (flag4)
                    {
                        break;
                    }
                }
                num2 = num;
            }
            return num2;
        }

        // Token: 0x06000437 RID: 1079 RVA: 0x000CB0E0 File Offset: 0x000C92E0
        private void ReformatLines(int fromLine, int toLineInclusive)
        {
            for (int i = fromLine; i <= toLineInclusive; i++)
            {
                this.FormatLine(i);
            }
        }

        // Token: 0x06000438 RID: 1080 RVA: 0x000CB10C File Offset: 0x000C930C
        private void FormatLine(int currentLine)
        {
            GCE.PHFG _AUB = this._AQQ[currentLine];
            bool flag = _AUB == null;
            if (flag)
            {
                GCE.PHFG[] _AQS = this._AQQ;
                GCE.PHFG _AUB2 = new GCE.PHFG();
                _AUB2.JIKB = currentLine;
                GCE.PHFG _AUB3 = _AUB2;
                _AQS[currentLine] = _AUB2;
                _AUB = _AUB3;
                _AUB._ASQ = this._AOD;
            }
            else
            {
                List<SyntaxToken> _ABS = _AUB.EOIA;
                bool flag2 = _ABS != null;
                if (flag2)
                {
                    int count = _ABS.Count;
                    while (count-- > 0)
                    {
                        SyntaxToken syntaxToken = _ABS[count];
                        bool flag3 = syntaxToken.OOME != null;
                        if (flag3)
                        {
                            syntaxToken.OOME._ACX = null;
                            syntaxToken.OOME = null;
                        }
                    }
                }
            }
            bool flag4 = currentLine > 0;
            if (flag4)
            {
                GCE.PHFG _AUB4 = this._AQQ[currentLine - 1];
                _AUB._ACO = _AUB4._ACO;
                _AUB._ABZ = _AUB4._ABZ;
            }
            else
            {
                _AUB._ACO = (GCE._ACP)0;
                _AUB._ABZ = this._AUY;
            }
            bool flag5 = this._ASF != null;
            if (flag5)
            {
                this._ASF.LexLine(currentLine, _AUB);
            }
            bool flag6 = this._AUZ != null;
            if (flag6)
            {
                this._AUZ(currentLine);
            }
        }

        // Token: 0x06000439 RID: 1081 RVA: 0x000CB238 File Offset: 0x000C9438
        public TextSpan GetTokenSpan(_bb4.DHBA parseTreeLeaf)
        {
            return this.GetTokenSpan(parseTreeLeaf.line, parseTreeLeaf._AJG());
        }

        // Token: 0x0600043A RID: 1082 RVA: 0x000CB25C File Offset: 0x000C945C
        public TextSpan GetTokenSpan(int lineIndex, int tokenIndex)
        {
            List<SyntaxToken> _ABS = this._AQQ[lineIndex].EOIA;
            int num = 0;
            for (int i = 0; i < tokenIndex; i++)
            {
                bool flag = i < _ABS.Count;
                if (flag)
                {
                    num += _ABS[i].text.Length;
                }
                else
                {
                    Debug.LogWarning(string.Concat(new string[]
                    {
                        "Token at line ",
                        (lineIndex + 1).ToString(),
                        ", index ",
                        i.ToString(),
                        " is out of range!"
                    }));
                }
            }
            int length = _ABS[tokenIndex].text.Length;
            return TextSpan.Create(new TextPosition
            {
                line = lineIndex,
                index = num
            }, new TextOffset
            {
                indexOffset = length
            });
        }

        // Token: 0x0600043B RID: 1083 RVA: 0x000CB33C File Offset: 0x000C953C
        public TextSpan GetParseTreeNodeSpan(_bb4._AIN parseTreeNode)
        {
            _bb4.DHBA _AEM = parseTreeNode as _bb4.DHBA;
            bool flag = _AEM != null;
            TextSpan textSpan;
            if (flag)
            {
                textSpan = this.GetTokenSpan(_AEM);
            }
            else
            {
                _bb4._ACW _AGZ = (_bb4._ACW)parseTreeNode;
                _bb4.DHBA firstLeaf = _AGZ.GetFirstLeaf();
                _bb4.DHBA lastLeaf = _AGZ.GetLastLeaf();
                bool flag2 = firstLeaf == null || lastLeaf == null;
                if (flag2)
                {
                    textSpan = default(TextSpan);
                }
                else
                {
                    textSpan = TextSpan.Create(this.GetTokenSpan(firstLeaf).StartPosition, this.GetTokenSpan(lastLeaf).EndPosition);
                }
            }
            return textSpan;
        }

        // Token: 0x0600043C RID: 1084 RVA: 0x000CB3C4 File Offset: 0x000C95C4
        public SyntaxToken GetTokenLeftOf(ref int lineIndex, ref int tokenIndex)
        {
            while (lineIndex >= 0)
            {
                List<SyntaxToken> _ABS = this._AQQ[lineIndex].EOIA;
                bool flag = tokenIndex == -1;
                if (flag)
                {
                    tokenIndex = _ABS.Count;
                }
                int num = tokenIndex - 1;
                tokenIndex = num;
                bool flag2 = num >= 0;
                if (flag2)
                {
                    return _ABS[tokenIndex];
                }
                lineIndex--;
            }
            return null;
        }

        // Token: 0x0600043D RID: 1085 RVA: 0x000CB430 File Offset: 0x000C9630
        public SyntaxToken GetTokenAt(GCE._AFA caretPosition, out int lineIndex, out int tokenIndex, out bool atTokenEnd)
        {
            return this.GetTokenAt(new TextPosition(caretPosition._ABI, caretPosition._AEU), out lineIndex, out tokenIndex, out atTokenEnd);
        }

        // Token: 0x0600043E RID: 1086 RVA: 0x000CB460 File Offset: 0x000C9660
        public SyntaxToken GetTokenAt(TextPosition position, out int lineIndex, out int tokenIndex, out bool atTokenEnd)
        {
            atTokenEnd = true;
            lineIndex = position.line;
            tokenIndex = 0;
            bool flag = lineIndex < 0 || lineIndex >= this._AQQ.Length;
            SyntaxToken syntaxToken;
            if (flag)
            {
                syntaxToken = null;
            }
            else
            {
                int i = position.index;
                List<SyntaxToken> _ABS = this._AQQ[lineIndex].EOIA;
                bool flag2 = _ABS == null;
                if (flag2)
                {
                    syntaxToken = null;
                }
                else
                {
                    while (tokenIndex < _ABS.Count && _ABS[tokenIndex].IsMissing())
                    {
                        tokenIndex++;
                    }
                    bool flag3 = tokenIndex == _ABS.Count;
                    if (flag3)
                    {
                        tokenIndex = -1;
                        syntaxToken = null;
                    }
                    else
                    {
                        bool flag4 = i == 0;
                        if (flag4)
                        {
                            atTokenEnd = false;
                            syntaxToken = _ABS[0];
                        }
                        else
                        {
                            SyntaxToken syntaxToken2 = null;
                            while (i > 0)
                            {
                                bool flag5 = _ABS[tokenIndex].IsMissing();
                                if (flag5)
                                {
                                    int num = tokenIndex + 1;
                                    tokenIndex = num;
                                    bool flag6 = num == _ABS.Count;
                                    if (flag6)
                                    {
                                        tokenIndex--;
                                        while (tokenIndex >= 0 && _ABS[tokenIndex].IsMissing())
                                        {
                                            tokenIndex--;
                                        }
                                        i = 0;
                                        break;
                                    }
                                }
                                else
                                {
                                    syntaxToken2 = _ABS[tokenIndex];
                                    bool flag7 = tokenIndex < _ABS.Count;
                                    if (flag7)
                                    {
                                        i -= syntaxToken2.text.Length;
                                    }
                                    bool flag8 = i > 0 && tokenIndex < _ABS.Count - 1;
                                    if (!flag8)
                                    {
                                        break;
                                    }
                                    tokenIndex++;
                                }
                            }
                            atTokenEnd = i == 0;
                            syntaxToken = syntaxToken2;
                        }
                    }
                }
            }
            return syntaxToken;
        }

        // Token: 0x0600043F RID: 1087 RVA: 0x000CB5F8 File Offset: 0x000C97F8
        public SyntaxToken GetNonTriviaTokenAfter(SyntaxToken token)
        {
            int i = token.Line;
            int num = token.TokenIndex;
            while (i < this._AQQ.Length)
            {
                List<SyntaxToken> _ABS = this._AQQ[i].EOIA;
                num++;
                while (num < _ABS.Count && _ABS[num].tokenKind <= SyntaxToken.Kind.LastWSToken)
                {
                    num++;
                }
                bool flag = num < _ABS.Count;
                if (flag)
                {
                    return _ABS[num];
                }
                i++;
                bool flag2 = i < this._AQQ.Length;
                if (flag2)
                {
                    num = -1;
                }
            }
            return null;
        }

        // Token: 0x06000440 RID: 1088 RVA: 0x000CB69C File Offset: 0x000C989C
        public SyntaxToken GetNonTriviaTokenLeftOf(ref int lineIndex, ref int tokenIndex)
        {
            while (lineIndex > 0)
            {
                List<SyntaxToken> _ABS = this._AQQ[lineIndex].EOIA;
                tokenIndex--;
                while (tokenIndex >= 0 && _ABS[tokenIndex].tokenKind <= SyntaxToken.Kind.LastWSToken)
                {
                    tokenIndex--;
                }
                bool flag = tokenIndex >= 0;
                if (flag)
                {
                    return _ABS[tokenIndex];
                }
                lineIndex--;
                bool flag2 = lineIndex >= 0;
                if (flag2)
                {
                    tokenIndex = this._AQQ[lineIndex].EOIA.Count;
                }
            }
            return null;
        }

        // Token: 0x06000441 RID: 1089 RVA: 0x000CB740 File Offset: 0x000C9940
        public SyntaxToken GetNonTriviaTokenLeftOf(GCE._AFA position, out int lineIndex, out int tokenIndex)
        {
            lineIndex = position._ABI;
            tokenIndex = -1;
            int i = position._AEU;
            List<SyntaxToken> list = this._AQQ[lineIndex].EOIA;
            bool flag = list == null;
            SyntaxToken syntaxToken;
            if (flag)
            {
                syntaxToken = null;
            }
            else
            {
                bool flag2 = list.Count > 0;
                if (flag2)
                {
                    while (i > 0)
                    {
                        int num = tokenIndex + 1;
                        tokenIndex = num;
                        bool flag3 = num == list.Count - 1;
                        if (flag3)
                        {
                            break;
                        }
                        i -= list[tokenIndex].text.Length;
                    }
                }
                while (tokenIndex < 0 || list[tokenIndex].tokenKind <= SyntaxToken.Kind.LastWSToken)
                {
                    bool flag4 = tokenIndex >= 0;
                    if (flag4)
                    {
                        tokenIndex--;
                    }
                    else
                    {
                        bool flag5 = lineIndex > 0;
                        if (!flag5)
                        {
                            break;
                        }
                        GCE.PHFG[] _AQS = this._AQQ;
                        int num = lineIndex - 1;
                        lineIndex = num;
                        list = _AQS[num].EOIA;
                        tokenIndex = list.Count - 1;
                    }
                }
                syntaxToken = ((tokenIndex >= 0) ? list[tokenIndex] : null);
            }
            return syntaxToken;
        }

        // Token: 0x06000442 RID: 1090 RVA: 0x000CB858 File Offset: 0x000C9A58
        public SyntaxToken GetNonTriviaTokenLeftOf(int lineIndex, int characterIndex)
        {
            int num = -1;
            List<SyntaxToken> list = this._AQQ[lineIndex].EOIA;
            bool flag = list == null;
            SyntaxToken syntaxToken;
            if (flag)
            {
                syntaxToken = null;
            }
            else
            {
                bool flag2 = list.Count > 0;
                if (flag2)
                {
                    while (characterIndex > 0)
                    {
                        bool flag3 = ++num == list.Count - 1;
                        if (flag3)
                        {
                            break;
                        }
                        characterIndex -= list[num].text.Length;
                    }
                }
                while (num < 0 || list[num].tokenKind <= SyntaxToken.Kind.LastWSToken)
                {
                    bool flag4 = num >= 0;
                    if (flag4)
                    {
                        num--;
                    }
                    else
                    {
                        bool flag5 = lineIndex > 0;
                        if (!flag5)
                        {
                            break;
                        }
                        list = this._AQQ[--lineIndex].EOIA;
                        num = list.Count - 1;
                    }
                }
                syntaxToken = ((num >= 0) ? list[num] : null);
            }
            return syntaxToken;
        }

        // Token: 0x0400044D RID: 1101
        public GCE._ABW _AUY = new GCE._ABW();

        // Token: 0x0400044E RID: 1102
        [SerializeField]
        [HideInInspector]
        public GCE.PHFG[] _AQQ = new GCE.PHFG[0];

        // Token: 0x0400044F RID: 1103
        [HideInInspector]
        [SerializeField]
        public List<string> FLOg = new List<string>();

        // Token: 0x04000450 RID: 1104
        [SerializeField]
        [HideInInspector]
        private string _ASG = "\n";

        // Token: 0x04000451 RID: 1105
        [NonSerialized]
        public HashSet<string> _ASH = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Token: 0x04000452 RID: 1106
        [NonSerialized]
        private StreamReader _ASM;

        // Token: 0x04000453 RID: 1107
        [SerializeField]
        [HideInInspector]
        public int _ARP = Encoding.UTF8.CodePage;

        // Token: 0x04000454 RID: 1108
        [NonSerialized]
        public int _ASK = 0;

        // Token: 0x04000455 RID: 1109
        [HideInInspector]
        [SerializeField]
        public int _ABU = 0;

        // Token: 0x04000456 RID: 1110
        [SerializeField]
        [HideInInspector]
        public bool _ASB = false;

        // Token: 0x04000457 RID: 1111
        [SerializeField]
        [HideInInspector]
        public bool _ASC = false;

        // Token: 0x04000458 RID: 1112
        [HideInInspector]
        [SerializeField]
        public bool _ARR = false;

        // Token: 0x04000459 RID: 1113
        [SerializeField]
        [HideInInspector]
        public bool _ARO = false;

        // Token: 0x0400045A RID: 1114
        internal static int _ASA = 4;

        // Token: 0x0400045B RID: 1115
        [NonSerialized]
        public _bi2._AVA _ABT = null;

        // Token: 0x0400045C RID: 1116
        [HideInInspector]
        [SerializeField]
        public string _AMZ = "";

        // Token: 0x0400045D RID: 1117
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CompilerGenerated]
        private string _ARS;

        // Token: 0x0400045E RID: 1118
        [NonSerialized]
        public GUIContent _AVB;

        // Token: 0x0400045F RID: 1119
        [NonSerialized]
        public float _AVC;

        // Token: 0x04000460 RID: 1120
        [NonSerialized]
        public GUIContent _AVD;

        // Token: 0x04000461 RID: 1121
        [SerializeField]
        [HideInInspector]
        public bool _AOV = false;

        // Token: 0x04000462 RID: 1122
        [SerializeField]
        [HideInInspector]
        public bool _ARY = true;

        // Token: 0x04000463 RID: 1123
        [NonSerialized]
        public DateTime _ASE;

        // Token: 0x04000464 RID: 1124
        [NonSerialized]
        private List<_bi2> _ARU = new List<_bi2>();

        // Token: 0x04000465 RID: 1125
        [SerializeField]
        [HideInInspector]
        private bool _ASL = false;

        // Token: 0x04000466 RID: 1126
        public GCE._AVE _ASW;

        // Token: 0x04000467 RID: 1127
        private static List<string> _ARZ = new List<string>();

        // Token: 0x04000468 RID: 1128
        public GCE._AVF _AUZ;

        // Token: 0x04000469 RID: 1129
        [NonSerialized]
        private _be3 _ASF;

        // Token: 0x0400046A RID: 1130
        [SerializeField]
        [HideInInspector]
        private List<GCE._ASO> _ASN = new List<GCE._ASO>();

        // Token: 0x0400046B RID: 1131
        [NonSerialized]
        private GCE._ASO _ATX;

        // Token: 0x0400046C RID: 1132
        [SerializeField]
        [HideInInspector]
        public int _ASJ = 0;

        // Token: 0x0400046D RID: 1133
        [SerializeField]
        [HideInInspector]
        public int _ASI = 0;

        // Token: 0x0400046E RID: 1134
        [SerializeField]
        [HideInInspector]
        public int _AOD = 0;

        // Token: 0x0400046F RID: 1135
        [NonSerialized]
        private bool _ASZ = true;

        // Token: 0x04000470 RID: 1136
        [NonSerialized]
        private int _ATV = 0;

        // Token: 0x04000471 RID: 1137
        [NonSerialized]
        private List<GCE.PHFG> _ATZ = new List<GCE.PHFG>();

        // Token: 0x04000472 RID: 1138
        internal static _bi2 _ALU = null;

        // Token: 0x04000473 RID: 1139
        private static Type _AUC;

        // Token: 0x04000474 RID: 1140
        private static MethodInfo _AUD;

        // Token: 0x04000475 RID: 1141
        private static Type _AUE;

        // Token: 0x04000476 RID: 1142
        private static MethodInfo _AUF;

        // Token: 0x04000477 RID: 1143
        public GCE._AVG _AUI;

        // Token: 0x04000478 RID: 1144
        internal static GCE._AVH _AUJ;

        // Token: 0x04000479 RID: 1145
        public GCE._AVI _AUK;

        // Token: 0x0400047A RID: 1146
        internal static GCE._AVJ _AUL;

        // Token: 0x0400047B RID: 1147
        public GCE._AVK _AUM;

        // Token: 0x0400047C RID: 1148
        internal static GCE._AVL _AUN;

        // Token: 0x0400047D RID: 1149
        public GCE._AVM _AUO;

        // Token: 0x0400047E RID: 1150
        internal static GCE._AVN _AUP;

        // Token: 0x0400047F RID: 1151
        private static Dictionary<string, string>[] _AUR;

        // Token: 0x04000480 RID: 1152
        private static int _AUQ = 0;

        // Token: 0x04000481 RID: 1153
        private Func<bool> _AUS;

        // Token: 0x0200008A RID: 138
        public enum _ACP : byte
        {

        }

        // Token: 0x0200008B RID: 139
        internal class _ABW
        {
            // Token: 0x04000483 RID: 1155
            public GCE._ABW._ABX _AT;

            // Token: 0x04000484 RID: 1156
            public GCE.PHFG _ABI;

            // Token: 0x04000485 RID: 1157
            public GCE._ABW OOME;

            // Token: 0x04000486 RID: 1158
            public List<GCE._ABW> _ARB;

            // Token: 0x0200008C RID: 140
            public enum _ABX
            {

            }
        }

        // Token: 0x0200008D RID: 141
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal class PHFG
        {
            // Token: 0x06000446 RID: 1094 RVA: 0x000CBA5C File Offset: 0x000C9C5C
            public string GetRegionName()
            {
                GCE._ABW _AVO = this._ABZ;
                bool flag = _AVO == null;
                string text;
                if (flag)
                {
                    text = null;
                }
                else
                {
                    while (_AVO.OOME != null && _AVO._AT != (GCE._ABW._ABX)1 && _AVO._AT != (GCE._ABW._ABX)6)
                    {
                        _AVO = _AVO.OOME;
                    }
                    bool flag2 = _AVO.OOME == null;
                    if (flag2)
                    {
                        text = null;
                    }
                    else
                    {
                        GCE.PHFG _ARC = _AVO._ABI;
                        bool flag3 = _ARC == null;
                        if (flag3)
                        {
                            text = null;
                        }
                        else
                        {
                            int count = _ARC.EOIA.Count;
                            while (count-- > 0)
                            {
                                bool flag4 = _ARC.EOIA[count].tokenKind == SyntaxToken.Kind.PreprocessorArguments;
                                if (flag4)
                                {
                                    return _ARC.EOIA[count].text;
                                }
                            }
                            text = null;
                        }
                    }
                }
                return text;
            }

            // Token: 0x04000488 RID: 1160
            [NonSerialized]
            public GCE._ACP _ACO;

            // Token: 0x04000489 RID: 1161
            [NonSerialized]
            public GCE._ABW _ABZ;

            // Token: 0x0400048A RID: 1162
            [SerializeField]
            [HideInInspector]
            public int _ASQ = -1;

            // Token: 0x0400048B RID: 1163
            [HideInInspector]
            [SerializeField]
            public int _ASP = -1;

            // Token: 0x0400048C RID: 1164
            [NonSerialized]
            public List<SyntaxToken> EOIA;

            // Token: 0x0400048D RID: 1165
            [NonSerialized]
            public int _AUW;

            // Token: 0x0400048E RID: 1166
            [NonSerialized]
            public int JIKB;
        }

        // Token: 0x0200008E RID: 142
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal class _AFA : IComparable<GCE._AFA>, IEquatable<GCE._AFA>
        {
            // Token: 0x06000448 RID: 1096 RVA: 0x000CBB44 File Offset: 0x000C9D44
            public override string ToString()
            {
                return string.Concat(new string[]
                {
                    "line: ",
                    this._ABI.ToString(),
                    ", index: ",
                    this._AEU.ToString(),
                    ", col: ",
                    this._ATG.ToString(),
                    ", vc: ",
                    this._ATF.ToString()
                });
            }

            // Token: 0x06000449 RID: 1097 RVA: 0x000CBBBC File Offset: 0x000C9DBC
            public GCE._AFA Clone()
            {
                return new GCE._AFA
                {
                    _ATF = this._ATF,
                    _ATG = this._ATG,
                    _AEU = this._AEU,
                    _ABI = this._ABI
                };
            }

            // Token: 0x0600044A RID: 1098 RVA: 0x000CBC03 File Offset: 0x000C9E03
            public void Set(int line, int characterIndex, int column)
            {
                this._ATG = column;
                this._AEU = characterIndex;
                this._ABI = line;
            }

            // Token: 0x0600044B RID: 1099 RVA: 0x000CBC1B File Offset: 0x000C9E1B
            public void Set(int line, int characterIndex, int column, int virtualColumn)
            {
                this._ATF = virtualColumn;
                this._ATG = column;
                this._AEU = characterIndex;
                this._ABI = line;
            }

            // Token: 0x0600044C RID: 1100 RVA: 0x000CBC3B File Offset: 0x000C9E3B
            public void Set(GCE._AFA other)
            {
                this._ATF = other._ATF;
                this._ATG = other._ATG;
                this._AEU = other._AEU;
                this._ABI = other._ABI;
            }

            // Token: 0x0600044D RID: 1101 RVA: 0x000CBC70 File Offset: 0x000C9E70
            public bool IsSameAs(GCE._AFA other)
            {
                return this.Equals(other) && this._ATG == other._ATG && this._ATF == other._ATF;
            }

            // Token: 0x0600044E RID: 1102 RVA: 0x000CBCAC File Offset: 0x000C9EAC
            public int CompareTo(GCE._AFA other)
            {
                return (this._ABI == other._ABI) ? (this._AEU - other._AEU) : (this._ABI - other._ABI);
            }

            // Token: 0x0600044F RID: 1103 RVA: 0x000CBCE8 File Offset: 0x000C9EE8
            public static bool operator <(GCE._AFA A, GCE._AFA B)
            {
                return A.CompareTo(B) < 0;
            }

            // Token: 0x06000450 RID: 1104 RVA: 0x000CBD04 File Offset: 0x000C9F04
            public static bool operator >(GCE._AFA A, GCE._AFA B)
            {
                return A.CompareTo(B) > 0;
            }

            // Token: 0x06000451 RID: 1105 RVA: 0x000CBD20 File Offset: 0x000C9F20
            public static bool operator <=(GCE._AFA A, GCE._AFA B)
            {
                return A.CompareTo(B) <= 0;
            }

            // Token: 0x06000452 RID: 1106 RVA: 0x000CBD40 File Offset: 0x000C9F40
            public static bool operator >=(GCE._AFA A, GCE._AFA B)
            {
                return A.CompareTo(B) >= 0;
            }

            // Token: 0x06000453 RID: 1107 RVA: 0x000CBD60 File Offset: 0x000C9F60
            public static bool operator ==(GCE._AFA A, GCE._AFA B)
            {
                bool flag = A == B;
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag3 = A == null;
                    if (flag3)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        bool flag4 = B == null;
                        flag2 = !flag4 && A.Equals(B);
                    }
                }
                return flag2;
            }

            // Token: 0x06000454 RID: 1108 RVA: 0x000CBDA0 File Offset: 0x000C9FA0
            public static bool operator !=(GCE._AFA A, GCE._AFA B)
            {
                return !(A == B);
            }

            // Token: 0x06000455 RID: 1109 RVA: 0x000CBDBC File Offset: 0x000C9FBC
            public bool Equals(GCE._AFA other)
            {
                return this._ABI == other._ABI && this._AEU == other._AEU;
            }

            // Token: 0x06000456 RID: 1110 RVA: 0x000CBDF0 File Offset: 0x000C9FF0
            public override bool Equals(object obj)
            {
                bool flag = obj == null;
                bool flag2;
                if (flag)
                {
                    flag2 = base.Equals(obj);
                }
                else
                {
                    bool flag3 = !(obj is GCE._AFA);
                    if (flag3)
                    {
                        throw new InvalidCastException("The 'obj' argument is not a CaretPos object.");
                    }
                    flag2 = this == (GCE._AFA)obj;
                }
                return flag2;
            }

            // Token: 0x06000457 RID: 1111 RVA: 0x000CBE3C File Offset: 0x000CA03C
            public override int GetHashCode()
            {
                return this._ABI.GetHashCode() ^ this._AEU.GetHashCode();
            }

            // Token: 0x0400048F RID: 1167
            [SerializeField]
            public int _ATF;

            // Token: 0x04000490 RID: 1168
            [SerializeField]
            public int _ATG;

            // Token: 0x04000491 RID: 1169
            [SerializeField]
            public int _AEU;

            // Token: 0x04000492 RID: 1170
            [SerializeField]
            public int _ABI;
        }

        // Token: 0x0200008F RID: 143
        // (Invoke) Token: 0x0600045A RID: 1114
        public delegate void _AVE();

        // Token: 0x02000090 RID: 144
        // (Invoke) Token: 0x0600045E RID: 1118
        public delegate void _AVF(int line);

        // Token: 0x02000091 RID: 145
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        private class _ASO
        {
            // Token: 0x04000493 RID: 1171
            [HideInInspector]
            [SerializeField]
            public List<GCE._ASO._ASS> _ASU;

            // Token: 0x04000494 RID: 1172
            [SerializeField]
            [HideInInspector]
            public int _ASY;

            // Token: 0x04000495 RID: 1173
            [SerializeField]
            [HideInInspector]
            public GCE._AFA _ATJ;

            // Token: 0x04000496 RID: 1174
            [HideInInspector]
            [SerializeField]
            public GCE._AFA _ATK;

            // Token: 0x04000497 RID: 1175
            [SerializeField]
            [HideInInspector]
            public GCE._AFA _ATQ;

            // Token: 0x04000498 RID: 1176
            [HideInInspector]
            [SerializeField]
            public GCE._AFA _ATR;

            // Token: 0x04000499 RID: 1177
            [SerializeField]
            [HideInInspector]
            public string _ATY;

            // Token: 0x02000092 RID: 146
            [Serializable]
            [StructLayout(LayoutKind.Sequential)]
            internal class _ASS
            {
                // Token: 0x0400049A RID: 1178
                [SerializeField]
                [HideInInspector]
                public GCE._AFA _ATB;

                // Token: 0x0400049B RID: 1179
                [HideInInspector]
                [SerializeField]
                public GCE._AFA _ATC;

                // Token: 0x0400049C RID: 1180
                [HideInInspector]
                [SerializeField]
                public string _ATH;

                // Token: 0x0400049D RID: 1181
                [SerializeField]
                [HideInInspector]
                public string _ATE;

                // Token: 0x0400049E RID: 1182
                [SerializeField]
                [HideInInspector]
                public int[] _ATI;

                // Token: 0x0400049F RID: 1183
                [SerializeField]
                [HideInInspector]
                public int[] _ASV;
            }
        }

        // Token: 0x02000093 RID: 147
        // (Invoke) Token: 0x06000464 RID: 1124
        public delegate void _AVG(int lineIndex, int numLines);

        // Token: 0x02000094 RID: 148
        // (Invoke) Token: 0x06000468 RID: 1128
        public delegate void _AVH(string assetGuid, int lineIndex, int numLines);

        // Token: 0x02000095 RID: 149
        // (Invoke) Token: 0x0600046C RID: 1132
        public delegate void _AVI(GCE._AFA from, GCE._AFA to);

        // Token: 0x02000096 RID: 150
        // (Invoke) Token: 0x06000470 RID: 1136
        public delegate void _AVJ(string assetGuid, GCE._AFA from, GCE._AFA to);

        // Token: 0x02000097 RID: 151
        // (Invoke) Token: 0x06000474 RID: 1140
        public delegate void _AVK(int lineIndex, int numLines);

        // Token: 0x02000098 RID: 152
        // (Invoke) Token: 0x06000478 RID: 1144
        public delegate void _AVL(string assetGuid, int lineIndex, int numLines);

        // Token: 0x02000099 RID: 153
        // (Invoke) Token: 0x0600047C RID: 1148
        public delegate void _AVM(GCE._AFA from, GCE._AFA to);

        // Token: 0x0200009A RID: 154
        // (Invoke) Token: 0x06000480 RID: 1152
        public delegate void _AVN(string assetGuid, GCE._AFA from, GCE._AFA to);
    }
}
