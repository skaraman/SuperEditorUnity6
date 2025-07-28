using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using SuperEditor;
using UnityEditor.Compilation;
using UnityEditorInternal;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000A8 RID: 168
    internal class _bj5 : _bh4
    {
        // Token: 0x060004B7 RID: 1207 RVA: 0x000CE680 File Offset: 0x000CC880
        private static bool IsManagedAssembly(string assemblyFile)
        {
            DllType dllType = InternalEditorUtility.DetectDotNetDll(assemblyFile);
            return dllType != DllType.Unknown && dllType != DllType.Native;
        }

        // Token: 0x060004B8 RID: 1208 RVA: 0x000CE6A8 File Offset: 0x000CC8A8
        internal string[] KBDHCOIANEGBFJDPKJDCGEFIEIADIMFJLMPE()
        {
            bool flag = this.IPIBJLDELAOIIOOAKPNMONGKKKKNFOEMLCMD == null;
            if (flag)
            {
                bool flag2 = this._AN != null;
                if (flag2)
                {
                    AssemblyName[] referencedAssemblies = this._AN.GetReferencedAssemblies();
                    this.IPIBJLDELAOIIOOAKPNMONGKKKKNFOEMLCMD = new string[referencedAssemblies.Length];
                    int num = referencedAssemblies.Length;
                    while (num-- > 0)
                    {
                        this.IPIBJLDELAOIIOOAKPNMONGKKKKNFOEMLCMD[num] = referencedAssemblies[num].Name;
                    }
                }
            }
            return this.IPIBJLDELAOIIOOAKPNMONGKKKKNFOEMLCMD;
        }

        // Token: 0x060004B9 RID: 1209 RVA: 0x000CE724 File Offset: 0x000CC924
        public _bj5[] _CGL()
        {
            bool flag = this.FBDPOLPFENEOLPJAIAOLLFPPDBDGGJAPEDCL == null;
            if (flag)
            {
                HashSet<_bj5> hashSet = new HashSet<_bj5>();
                bool flag2 = this._AN != null;
                if (flag2)
                {
                    foreach (string text in this.KBDHCOIANEGBFJDPKJDCGEFIEIADIMFJLMPE())
                    {
                        _bj5 _AOS = _bj5.FromName(text);
                        bool flag3 = _AOS != null;
                        if (flag3)
                        {
                            hashSet.Add(_AOS);
                        }
                    }
                }
                string text2 = _bj5.AIHMBPHEBJJOIOJHJLAKHCLOPLCHGKELDCBB[(int)this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN];
                bool flag4 = text2 == null && this._AN != null;
                if (flag4)
                {
                    text2 = this.AssemblyName;
                }
                bool flag5 = text2 != null;
                if (flag5)
                {
                    string[] referencedAssembliesFor = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.GetReferencedAssembliesFor(text2);
                    bool flag6 = referencedAssembliesFor != null;
                    if (flag6)
                    {
                        for (int j = 0; j < referencedAssembliesFor.Length; j++)
                        {
                            bool flag7 = !_bj5.IsManagedAssembly(referencedAssembliesFor[j]);
                            if (!flag7)
                            {
                                _bj5 _AOS2 = _bj5.FromPath(referencedAssembliesFor[j]);
                                bool flag8 = _AOS2 != null;
                                if (flag8)
                                {
                                    hashSet.Add(_AOS2);
                                }
                                else
                                {
                                    Debug.LogWarning("Can't load " + referencedAssembliesFor[j]);
                                }
                            }
                        }
                    }
                }
                hashSet.Add(_bj5.FromName("mscorlib"));
                hashSet.Add(_bj5.FromName("nunit.framework"));
                hashSet.Add(_bj5.FromName("System"));
                hashSet.Add(_bj5.FromName("System.Core"));
                hashSet.Add(_bj5.FromName("System.Runtime.Serialization"));
                hashSet.Add(_bj5.FromName("System.XML"));
                hashSet.Add(_bj5.FromName("System.Xml.Linq"));
                hashSet.Remove(null);
                this.FBDPOLPFENEOLPJAIAOLLFPPDBDGGJAPEDCL = new _bj5[hashSet.Count];
                hashSet.CopyTo(this.FBDPOLPFENEOLPJAIAOLLFPPDBDGGJAPEDCL);
            }
            return this.FBDPOLPFENEOLPJAIAOLLFPPDBDGGJAPEDCL;
        }

        // Token: 0x060004BA RID: 1210 RVA: 0x000CE8FC File Offset: 0x000CCAFC
        public static _bj5 FromAssembly(System.Reflection.Assembly assembly)
        {
            _bj5 _AOS = null;
            bool flag = !_bj5.DIBFNKBPDMFNEMNDIPLBONFLMFAKKCEPLILA.TryGetValue(assembly, out _AOS);
            if (flag)
            {
                _AOS = new _bj5(assembly);
                _bj5.DIBFNKBPDMFNEMNDIPLBONFLMFAKKCEPLILA[assembly] = _AOS;
            }
            return _AOS;
        }

        // Token: 0x060004BB RID: 1211 RVA: 0x000CE93C File Offset: 0x000CCB3C
        public static bool IsScriptAssemblyName(string name)
        {
            return Array.IndexOf<string>(_bj5.AIHMBPHEBJJOIOJHJLAKHCLOPLCHGKELDCBB, name.ToLowerInvariant()) >= 0;
        }

        // Token: 0x060004BC RID: 1212 RVA: 0x000CE964 File Offset: 0x000CCB64
        private static List<System.Reflection.Assembly> INDCDHPALHNEMDLDBPLEMKPEACJDGFKKACHA()
        {
            bool flag = _bj5.IDKNPDILLAILDKAJDMDDGHJLFOGFCIHKFDND != null;
            List<System.Reflection.Assembly> list;
            if (flag)
            {
                list = _bj5.IDKNPDILLAILDKAJDMDDGHJLFOGFCIHKFDND;
            }
            else
            {
                _bj5.IDKNPDILLAILDKAJDMDDGHJLFOGFCIHKFDND = new List<System.Reflection.Assembly>(AppDomain.CurrentDomain.GetAssemblies());
                AppDomain.CurrentDomain.AssemblyLoad += _bj5.AssemblyLoadEventHandler;
                list = _bj5.IDKNPDILLAILDKAJDMDDGHJLFOGFCIHKFDND;
            }
            return list;
        }

        // Token: 0x060004BD RID: 1213 RVA: 0x000CE9BA File Offset: 0x000CCBBA
        private static void AssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args)
        {
            _bj5.IDKNPDILLAILDKAJDMDDGHJLFOGFCIHKFDND.Add(args.LoadedAssembly);
        }

        // Token: 0x060004BE RID: 1214 RVA: 0x000CE9D0 File Offset: 0x000CCBD0
        private static _bj5 FromPath(string assemblyPath)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(assemblyPath);
            int count = _bj5.INDCDHPALHNEMDLDBPLEMKPEACJDGFKKACHA().Count;
            while (count-- > 0)
            {
                System.Reflection.Assembly assembly = _bj5.INDCDHPALHNEMDLDBPLEMKPEACJDGFKKACHA()[count];
                bool flag = assembly is System.Reflection.Emit.AssemblyBuilder;
                if (!flag)
                {
                    bool flag2 = string.Compare(assembly.GetName().Name, fileNameWithoutExtension, StringComparison.InvariantCultureIgnoreCase) == 0;
                    if (flag2)
                    {
                        return _bj5.FromAssembly(assembly);
                    }
                }
            }
            _bj5 _AOS = null;
            bool flag3 = !_bj5.PJKEBCBBMNJPCABBHPIKIMEJMACMLDFJBDNH.TryGetValue(assemblyPath, out _AOS);
            if (flag3)
            {
                try
                {
                    bool flag4 = !_bj5.IsManagedAssembly(assemblyPath);
                    if (flag4)
                    {
                        return null;
                    }
                    System.Reflection.Assembly assembly2 = global::System.Reflection.Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                    _AOS = _bj5.FromAssembly(assembly2);
                    bool flag5 = _AOS != null;
                    if (flag5)
                    {
                        _bj5.PJKEBCBBMNJPCABBHPIKIMEJMACMLDFJBDNH[assemblyPath] = _AOS;
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
            return _AOS;
        }

        // Token: 0x060004BF RID: 1215 RVA: 0x000CEAC0 File Offset: 0x000CCCC0
        private static _bj5 FromName(string assemblyName)
        {
            int count = _bj5.INDCDHPALHNEMDLDBPLEMKPEACJDGFKKACHA().Count;
            while (count-- > 0)
            {
                System.Reflection.Assembly assembly = _bj5.INDCDHPALHNEMDLDBPLEMKPEACJDGFKKACHA()[count];
                bool flag = assembly is System.Reflection.Emit.AssemblyBuilder;
                if (!flag)
                {
                    bool flag2 = string.Compare(assembly.GetName().Name, assemblyName, true) == 0;
                    if (flag2)
                    {
                        return _bj5.FromAssembly(assembly);
                    }
                }
            }
            return null;
        }

        // Token: 0x060004C0 RID: 1216 RVA: 0x000CEB30 File Offset: 0x000CCD30
        private static _bj5 FromId(_bj5._AZG assemblyId)
        {
            bool flag = assemblyId == (_bj5._AZG)0;
            _bj5 _AOS;
            if (flag)
            {
                _AOS = null;
            }
            else
            {
                bool flag2 = _bj5.HPEELBCJDACILOAICOJANFMEPEPPLAJLOOOO[(int)assemblyId] == null;
                if (flag2)
                {
                    string text = _bj5.AIHMBPHEBJJOIOJHJLAKHCLOPLCHGKELDCBB[(int)assemblyId];
                    _bj5.HPEELBCJDACILOAICOJANFMEPEPPLAJLOOOO[(int)assemblyId] = _bj5.FromName(text) ?? new _bj5(assemblyId);
                }
                _AOS = _bj5.HPEELBCJDACILOAICOJANFMEPEPPLAJLOOOO[(int)assemblyId];
            }
            return _AOS;
        }

        // Token: 0x060004C1 RID: 1217 RVA: 0x000CEB88 File Offset: 0x000CCD88
        public static bool IsIgnoredScript(string assetPath)
        {
            return assetPath.StartsWith("assets/webplayertemplates/", StringComparison.OrdinalIgnoreCase) || assetPath.StartsWith("assets/webgltemplates/", StringComparison.OrdinalIgnoreCase) || assetPath.StartsWith("assets/streamingassets/", StringComparison.OrdinalIgnoreCase);
        }

        // Token: 0x060004C2 RID: 1218 RVA: 0x000CEBC8 File Offset: 0x000CCDC8
        private static _bj5._AZG AssemblyIdFromAssetPath(string pathName)
        {
            string text = (Path.GetExtension(pathName) ?? string.Empty).ToLower();
            bool flag = text == ".cs";
            bool flag2 = text == ".js";
            bool flag3 = text == ".boo";
            bool flag4 = text == ".dll";
            bool flag5 = !flag && !flag2 && !flag3 && !flag4;
            _bj5._AZG mlejggcpjlinlonjmjngdnmfonagfffjpolb;
            if (flag5)
            {
                mlejggcpjlinlonjmjngdnmfonagfffjpolb = (_bj5._AZG)0;
            }
            else
            {
                string text2 = (Path.GetDirectoryName(pathName) ?? string.Empty).ToLowerInvariant() + "/";
                bool flag6 = _bj5.IsIgnoredScript(text2);
                if (flag6)
                {
                    mlejggcpjlinlonjmjngdnmfonagfffjpolb = (_bj5._AZG)0;
                }
                else
                {
                    bool flag7 = true;
                    bool flag8 = text2.StartsWith("assets/plugins/", StringComparison.Ordinal);
                    bool flag9 = text2.StartsWith("assets/standard assets/", StringComparison.Ordinal) || text2.StartsWith("assets/pro standard assets/", StringComparison.Ordinal);
                    bool flag10 = flag8 || flag9;
                    bool flag11 = flag10 && !flag7;
                    bool flag12;
                    if (flag11)
                    {
                        flag12 = (flag8 && text2.StartsWith("assets/plugins/editor/", StringComparison.Ordinal)) || (flag9 && text2.StartsWith("assets/pro standard assets/editor/", StringComparison.Ordinal)) || (flag9 && text2.StartsWith("assets/standard assets/editor/", StringComparison.Ordinal));
                    }
                    else
                    {
                        flag12 = text2.Contains("/editor/");
                    }
                    bool flag13 = flag10 && flag12;
                    _bj5._AZG mlejggcpjlinlonjmjngdnmfonagfffjpolb2;
                    if (flag13)
                    {
                        mlejggcpjlinlonjmjngdnmfonagfffjpolb2 = (flag ? ((_bj5._AZG)6) : (flag3 ? ((_bj5._AZG)8) : (flag2 ? ((_bj5._AZG)7) : ((_bj5._AZG)5))));
                    }
                    else
                    {
                        bool flag14 = flag12;
                        if (flag14)
                        {
                            mlejggcpjlinlonjmjngdnmfonagfffjpolb2 = (flag ? ((_bj5._AZG)14) : (flag3 ? ((_bj5._AZG)16) : (flag2 ? ((_bj5._AZG)15) : ((_bj5._AZG)13))));
                        }
                        else
                        {
                            bool flag15 = flag10;
                            if (flag15)
                            {
                                mlejggcpjlinlonjmjngdnmfonagfffjpolb2 = (flag ? ((_bj5._AZG)2) : (flag3 ? ((_bj5._AZG)4) : (flag2 ? ((_bj5._AZG)3) : ((_bj5._AZG)1))));
                            }
                            else
                            {
                                mlejggcpjlinlonjmjngdnmfonagfffjpolb2 = (flag ? ((_bj5._AZG)10) : (flag3 ? ((_bj5._AZG)12) : (flag2 ? ((_bj5._AZG)11) : ((_bj5._AZG)9))));
                            }
                        }
                    }
                    mlejggcpjlinlonjmjngdnmfonagfffjpolb = mlejggcpjlinlonjmjngdnmfonagfffjpolb2;
                }
            }
            return mlejggcpjlinlonjmjngdnmfonagfffjpolb;
        }

        // Token: 0x060004C3 RID: 1219 RVA: 0x000CED94 File Offset: 0x000CCF94
        public static _bj5 FromAssetPath(string pathName)
        {
            string text = CompilationPipeline.GetAssemblyNameFromScriptPath(pathName);
            text = text.Substring(0, text.Length - ".dll".Length);
            _bj5 _AOS = _bj5.FromName(text);
            bool flag = _AOS != null;
            _bj5 _AOS2;
            if (flag)
            {
                _AOS2 = _AOS;
            }
            else
            {
                _AOS2 = _bj5.FromId(_bj5.AssemblyIdFromAssetPath(pathName));
            }
            return _AOS2;
        }

        // Token: 0x060004C4 RID: 1220 RVA: 0x000CEDE4 File Offset: 0x000CCFE4
        private _bj5(_bj5._AZG id)
        {
            this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = id;
            this.AHMPIKDFEFMCLFLJOEKHGBJIMNOBBAPNIJHE = id != (_bj5._AZG)0 && id != (_bj5._AZG)9 && id != (_bj5._AZG)1 && id != (_bj5._AZG)13 && id != (_bj5._AZG)5;
            this._CHJ = id == (_bj5._AZG)10 || id == (_bj5._AZG)2 || id == (_bj5._AZG)14 || id == (_bj5._AZG)6;
        }

        // Token: 0x060004C5 RID: 1221 RVA: 0x000CEE3C File Offset: 0x000CD03C
        public static bool IsScriptAssembly(System.Reflection.Assembly assembly)
        {
            bool flag = _bj5.IsScriptAssemblyName(assembly.GetName().Name);
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                System.Reflection.Assembly assembly2 = _bj5.FindScriptAssembly(assembly);
                flag2 = assembly2 != null;
            }
            return flag2;
        }

        // Token: 0x060004C6 RID: 1222 RVA: 0x000CEE74 File Offset: 0x000CD074
        public static System.Reflection.Assembly FindScriptAssembly(System.Reflection.Assembly assembly)
        {
            bool flag = string.IsNullOrEmpty(assembly.Location);
            System.Reflection.Assembly assembly2;
            if (flag)
            {
                assembly2 = null;
            }
            else
            {
                string directoryName = Path.GetDirectoryName(assembly.Location);
                bool flag2 = !directoryName.StartsWith(Directory.GetCurrentDirectory(), StringComparison.InvariantCultureIgnoreCase);
                if (flag2)
                {
                    assembly2 = null;
                }
                else
                {
                    bool flag3 = _bj5.GHGINOAGGIFEFJMGDMAMNONFFDIOJLJAMIPP == null;
                    if (flag3)
                    {
                        _bj5.GHGINOAGGIFEFJMGDMAMNONFFDIOJLJAMIPP = CompilationPipeline.GetAssemblies();
                    }
                    int num = _bj5.GHGINOAGGIFEFJMGDMAMNONFFDIOJLJAMIPP.Length;
                    while (num-- > 0)
                    {
                        UnityEditor.Compilation.Assembly assembly3 = _bj5.GHGINOAGGIFEFJMGDMAMNONFFDIOJLJAMIPP[num];
                        bool flag4 = string.Compare(Path.GetFullPath(assembly3.outputPath), assembly.Location, StringComparison.InvariantCultureIgnoreCase) == 0;
                        if (flag4)
                        {
                            return assembly3;
                        }
                    }
                    assembly2 = null;
                }
            }
            return assembly2;
        }

        // Token: 0x060004C7 RID: 1223 RVA: 0x000CEF2C File Offset: 0x000CD12C
        public static _bj5[] GetAllCSharpAssemblyDefinitions()
        {
            List<_bj5> list = new List<_bj5>();
            foreach (System.Reflection.Assembly assembly in _bj5.INDCDHPALHNEMDLDBPLEMKPEACJDGFKKACHA())
            {
                bool flag = !_bj5.IsScriptAssembly(assembly);
                if (!flag)
                {
                    _bj5 _AOS = _bj5.FromAssembly(assembly);
                    bool flag2 = !_AOS._CHJ;
                    if (!flag2)
                    {
                        list.Add(_AOS);
                    }
                }
            }
            return list.ToArray();
        }

        // Token: 0x060004C8 RID: 1224 RVA: 0x000CEFC0 File Offset: 0x000CD1C0
        private _bj5(System.Reflection.Assembly assembly)
        {
            this._AN = assembly;
            this.CNLPKBIEMCAJJODDNIDIOECPEGCPLFIFCECM = _bj5.FindScriptAssembly(assembly);
            this.AHMPIKDFEFMCLFLJOEKHGBJIMNOBBAPNIJHE = this.CNLPKBIEMCAJJODDNIDIOECPEGCPLFIFCECM != null;
            string text = assembly.GetName().Name.ToLower();
            string text2 = text;
            uint num = Helper.ComputeStringHash(text2);
            if (num <= 2529873529U)
            {
                if (num <= 960551262U)
                {
                    if (num != 350188464U)
                    {
                        if (num != 772452690U)
                        {
                            if (num == 960551262U)
                            {
                                if (text2 == "assembly-boo-editor")
                                {
                                    this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)16;
                                    this._CHJ = false;
                                    goto IL_02DF;
                                }
                            }
                        }
                        else if (text2 == "assembly-boo-firstpass")
                        {
                            this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)4;
                            this._CHJ = false;
                            goto IL_02DF;
                        }
                    }
                    else if (text2 == "assembly-boo-editor-firstpass")
                    {
                        this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)8;
                        this._CHJ = false;
                        goto IL_02DF;
                    }
                }
                else if (num != 1454904528U)
                {
                    if (num != 1766519622U)
                    {
                        if (num == 2529873529U)
                        {
                            if (text2 == "assembly-csharp-editor-firstpass")
                            {
                                this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)6;
                                this._CHJ = true;
                                goto IL_02DF;
                            }
                        }
                    }
                    else if (text2 == "assembly-unityscript-editor-firstpass")
                    {
                        this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)7;
                        this._CHJ = false;
                        goto IL_02DF;
                    }
                }
                else if (text2 == "assembly-unityscript-editor")
                {
                    this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)15;
                    this._CHJ = false;
                    goto IL_02DF;
                }
            }
            else if (num <= 3657578900U)
            {
                if (num != 3198918732U)
                {
                    if (num != 3335090971U)
                    {
                        if (num == 3657578900U)
                        {
                            if (text2 == "assembly-boo")
                            {
                                this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)12;
                                this._CHJ = false;
                                goto IL_02DF;
                            }
                        }
                    }
                    else if (text2 == "assembly-csharp")
                    {
                        this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)10;
                        this._CHJ = true;
                        goto IL_02DF;
                    }
                }
                else if (text2 == "assembly-unityscript-firstpass")
                {
                    this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)3;
                    this._CHJ = false;
                    goto IL_02DF;
                }
            }
            else if (num != 3862350530U)
            {
                if (num != 3868876961U)
                {
                    if (num == 4014451219U)
                    {
                        if (text2 == "assembly-csharp-editor")
                        {
                            this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)14;
                            this._CHJ = true;
                            goto IL_02DF;
                        }
                    }
                }
                else if (text2 == "assembly-csharp-firstpass")
                {
                    this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)2;
                    this._CHJ = true;
                    goto IL_02DF;
                }
            }
            else if (text2 == "assembly-unityscript")
            {
                this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)11;
                this._CHJ = false;
                goto IL_02DF;
            }
            this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN = (_bj5._AZG)0;
            this._CHJ = false;
        IL_02DF:
            bool _AWT = this.AHMPIKDFEFMCLFLJOEKHGBJIMNOBBAPNIJHE;
            if (_AWT)
            {
                this._CHJ = true;
            }
        }

        // Token: 0x1700001E RID: 30
        // (get) Token: 0x060004C9 RID: 1225 RVA: 0x000CF2C0 File Offset: 0x000CD4C0
        public string AssemblyName
        {
            get
            {
                bool flag = this._AN != null;
                string text;
                if (flag)
                {
                    text = this._AN.GetName().Name;
                }
                else
                {
                    text = _bj5.AIHMBPHEBJJOIOJHJLAKHCLOPLCHGKELDCBB[(int)this.BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN] ?? "<Unknown-Assembly>";
                }
                return text;
            }
        }

        // Token: 0x060004CA RID: 1226 RVA: 0x000CF30C File Offset: 0x000CD50C
        public bool InternalsVisibleIn(_bj5 referencingAssembly)
        {
            return referencingAssembly == this;
        }

        // Token: 0x060004CB RID: 1227 RVA: 0x000CF32C File Offset: 0x000CD52C
        public static _be7 GetCompilationUnitScope(string assetPath, bool forceCreateNew = false)
        {
            bool flag = assetPath == null;
            _be7 _CHH;
            if (flag)
            {
                _CHH = null;
            }
            else
            {
                assetPath = assetPath.ToLower();
                _bj5 _AOS = _bj5.FromAssetPath(assetPath);
                bool flag2 = _AOS == null;
                if (flag2)
                {
                    _CHH = null;
                }
                else
                {
                    bool flag3 = _AOS.EKNILLOGEAIKLJHEMKKAGIBGBNKMFENLCAFB == null;
                    if (flag3)
                    {
                        _AOS.EKNILLOGEAIKLJHEMKKAGIBGBNKMFENLCAFB = new Dictionary<string, _be7>();
                    }
                    _be7 _CHH2 = null;
                    bool flag4 = !_AOS.EKNILLOGEAIKLJHEMKKAGIBGBNKMFENLCAFB.TryGetValue(assetPath, out _CHH2) || forceCreateNew;
                    if (flag4)
                    {
                        if (forceCreateNew)
                        {
                            bool flag5 = _CHH2 != null && _CHH2._APM != null;
                            if (flag5)
                            {
                                bool flag6 = false;
                                List<FKI> cehjafhelfgggomkeiklndkdbnngpbkkiaed = _CHH2._APM;
                                int count = cehjafhelfgggomkeiklndkdbnngpbkkiaed.Count;
                                while (count-- > 0)
                                {
                                    FKI _AFF = cehjafhelfgggomkeiklndkdbnngpbkkiaed[count];
                                    _CHH2.RemoveDeclaration(_AFF);
                                    flag6 = true;
                                }
                                bool flag7 = flag6;
                                if (flag7)
                                {
                                    _bb4._AIU += 1U;
                                    bool flag8 = _bb4._AIU == 0U;
                                    if (flag8)
                                    {
                                        _bb4._AIU += 1U;
                                    }
                                }
                            }
                            _AOS.EKNILLOGEAIKLJHEMKKAGIBGBNKMFENLCAFB.Remove(assetPath);
                        }
                        _CHH2 = new _be7
                        {
                            _AN = _AOS,
                            _AWJ = assetPath
                        };
                        _AOS.EKNILLOGEAIKLJHEMKKAGIBGBNKMFENLCAFB[assetPath] = _CHH2;
                        _CHH2.EFI = new _bf8
                        {
                            _AT = SymbolKind.Namespace,
                            _ACV = _AOS._AWL()
                        };
                        _CHH2._ACV = _AOS._AWL();
                    }
                    _CHH = _CHH2;
                }
            }
            return _CHH;
        }

        // Token: 0x060004CC RID: 1228 RVA: 0x000CF494 File Offset: 0x000CD694
        public _bn1 _AWL()
        {
            return this.IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN ?? this.InitializeGlobalNamespace();
        }

        // Token: 0x060004CD RID: 1229 RVA: 0x000CF4B6 File Offset: 0x000CD6B6
        public void EGLEKCJLEMJFKIGKJHCKOHHKGFEEHCJFHJDI(_bn1 value)
        {
            this.IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN = value;
        }

        // Token: 0x060004CE RID: 1230 RVA: 0x000CF4C0 File Offset: 0x000CD6C0
        private _bn1 InitializeGlobalNamespace()
        {
            this.IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN = new _bn1
            {
                _AW = "",
                _AT = SymbolKind.Namespace,
                _AO = this
            };
            bool flag = this._AN != null;
            if (flag)
            {
                Type[] array = null;
                try
                {
                    array = (this.AHMPIKDFEFMCLFLJOEKHGBJIMNOBBAPNIJHE ? this._AN.GetTypes() : this._AN.GetExportedTypes());
                }
                catch
                {
                    return this.IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN;
                }
                Dictionary<string, _bn1> dictionary = new Dictionary<string, _bn1>();
                foreach (Type type in array)
                {
                    bool isNested = type.IsNested;
                    if (!isNested)
                    {
                        _be8 _AFK = null;
                        bool flag2 = _bh4._BEJ.TryGetValue(type, out _AFK);
                        if (!flag2)
                        {
                            _bh4 _AAH = this.IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN;
                            string @namespace = type.Namespace;
                            bool flag3 = !string.IsNullOrEmpty(@namespace);
                            if (flag3)
                            {
                                _bn1 _APR = null;
                                bool flag4 = dictionary.TryGetValue(@namespace, out _APR);
                                if (flag4)
                                {
                                    _AAH = _APR;
                                }
                                else
                                {
                                    foreach (string text in @namespace.Split(new char[] { '.' }))
                                    {
                                        _bh4 _AAH2 = _AAH.FindName(text, 0, true);
                                        bool flag5 = _AAH2 != null;
                                        if (flag5)
                                        {
                                            _AAH = _AAH2;
                                        }
                                        else
                                        {
                                            _APR = new _bn1
                                            {
                                                _AT = SymbolKind.Namespace,
                                                _AW = text,
                                                _AO = _AAH,
                                                _AU = AccessLevel.Public,
                                                _AV = Modifiers.Public
                                            };
                                            _AAH.AddMember(_APR);
                                            _AAH = _APR;
                                        }
                                    }
                                    dictionary[@namespace] = (_bn1)_AAH;
                                }
                            }
                            _AAH.ImportReflectedType(type);
                        }
                    }
                }
            }
            bool flag6 = _bh4._ABO == null;
            if (flag6)
            {
                _bh4._ABO = new Dictionary<string, _b2>(16);
                _bh4._ABO.Add("int", _bh4._AAQ = _bj5.DefineBuiltInType(typeof(int)));
                _bh4._ABO.Add("uint", _bh4._AAU = _bj5.DefineBuiltInType(typeof(uint)));
                _bh4._ABO.Add("byte", _bh4._AAW = _bj5.DefineBuiltInType(typeof(byte)));
                _bh4._ABO.Add("sbyte", _bh4._AAZ = _bj5.DefineBuiltInType(typeof(sbyte)));
                _bh4._ABO.Add("short", _bh4._AAX = _bj5.DefineBuiltInType(typeof(short)));
                _bh4._ABO.Add("ushort", _bh4._AAY = _bj5.DefineBuiltInType(typeof(ushort)));
                _bh4._ABO.Add("long", _bh4._AAR = _bj5.DefineBuiltInType(typeof(long)));
                _bh4._ABO.Add("ulong", _bh4._AAV = _bj5.DefineBuiltInType(typeof(ulong)));
                _bh4._ABO.Add("float", _bh4._AAS = _bj5.DefineBuiltInType(typeof(float)));
                _bh4._ABO.Add("double", _bh4._AAT = _bj5.DefineBuiltInType(typeof(double)));
                _bh4._ABO.Add("decimal", _bh4._BFC = _bj5.DefineBuiltInType(typeof(decimal)));
                _bh4._ABO.Add("char", _bh4._ABA = _bj5.DefineBuiltInType(typeof(char)));
                _bh4._ABO.Add("string", _bh4._BFD = _bj5.DefineBuiltInType(typeof(string)));
                _bh4._ABO.Add("bool", _bh4._BFP = _bj5.DefineBuiltInType(typeof(bool)));
                _bh4._ABO.Add("object", _bh4._AS = _bj5.DefineBuiltInType(typeof(object)));
                _bh4._ABO.Add("void", _bh4._BFU = _bj5.DefineBuiltInType(typeof(void)));
                _bh4._AQG = _bj5.DefineBuiltInType(typeof(Array));
                _bh4._AY = _bj5.DefineBuiltInType(typeof(Nullable<>));
                _bh4._BFL = _bj5.DefineBuiltInType(typeof(IEnumerable));
                _bh4._BFJ = _bj5.DefineBuiltInType(typeof(IEnumerable<>));
                _bh4._CBR = _bj5.DefineBuiltInType(typeof(Exception));
                _bh4._ADE = _bj5.DefineBuiltInType(typeof(Enum));
                Type type2 = Type.GetType("System.Threading.Tasks.Task,mscorlib");
                _bh4._BFT = _bj5.DefineBuiltInType(type2);
                Type type3 = Type.GetType("System.Threading.Tasks.Task`1,mscorlib");
                _bh4._BFV = _bj5.DefineBuiltInType(type3);
                Type type4 = Type.GetType("System.Runtime.CompilerServices.INotifyCompletion,mscorlib");
                _bh4._BFW = _bj5.DefineBuiltInType(type4);
            }
            return this.IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN;
        }

        // Token: 0x060004CF RID: 1231 RVA: 0x000CF9CC File Offset: 0x000CDBCC
        public static _bc6 DefineBuiltInType(Type type)
        {
            bool flag = type == null;
            _bc6 _AHD;
            if (flag)
            {
                _AHD = null;
            }
            else
            {
                _bj5 _AOS = _bj5.FromAssembly(type.Assembly);
                _bh4 _AAH = _AOS.FindNamespace(type.Namespace);
                string text = type.Name;
                int num = text.IndexOf("`", StringComparison.Ordinal);
                bool flag2 = num > 0;
                if (flag2)
                {
                    text = text.Substring(0, num);
                }
                _bh4 _AAH2 = _AAH.FindName(text, type.GetGenericArguments().Length, true);
                _AHD = _AAH2 as _bc6;
            }
            return _AHD;
        }

        // Token: 0x060004D0 RID: 1232 RVA: 0x000CFA4C File Offset: 0x000CDC4C
        public _bh4 FindNamespace(string namespaceName)
        {
            _bh4 _AAH = this._AWL();
            bool flag = string.IsNullOrEmpty(namespaceName);
            _bh4 _AAH2;
            if (flag)
            {
                _AAH2 = _AAH;
            }
            else
            {
                int num;
                for (int i = 0; i < namespaceName.Length; i = ((num == -1) ? int.MaxValue : (num + 1)))
                {
                    num = namespaceName.IndexOf(".", i, StringComparison.Ordinal);
                    string text = ((num == -1) ? namespaceName.Substring(i) : namespaceName.Substring(i, num - i));
                    _AAH = _AAH.FindName(text, 0, true) as _bn1;
                    bool flag2 = _AAH == null;
                    if (flag2)
                    {
                        return _bh4._AAA;
                    }
                }
                _AAH2 = _AAH ?? _bh4._AAA;
            }
            return _AAH2;
        }

        // Token: 0x060004D1 RID: 1233 RVA: 0x000CFAF0 File Offset: 0x000CDCF0
        public _bn1 FindSameNamespace(_bn1 namespaceDefinition)
        {
            bool flag = string.IsNullOrEmpty(namespaceDefinition._AW);
            _bn1 _APR;
            if (flag)
            {
                _APR = this._AWL();
            }
            else
            {
                _bn1 _APR2 = (namespaceDefinition._AO ?? namespaceDefinition._AGU) as _bn1;
                _APR2 = this.FindSameNamespace(_APR2);
                bool flag2 = _APR2 == null;
                if (flag2)
                {
                    _APR = null;
                }
                else
                {
                    _APR = _APR2.FindName(namespaceDefinition._AW, 0, true) as _bn1;
                }
            }
            return _APR;
        }

        // Token: 0x060004D2 RID: 1234 RVA: 0x000CFB58 File Offset: 0x000CDD58
        public void ResolveInReferencedAssemblies(_bb4.DHBA leaf, _bn1 namespaceDefinition, int numTypeArgs)
        {
            string text = _bh4.DecodeId(leaf._ACX.text);
            foreach (_bj5 _AOS in this._CGL())
            {
                _bn1 _APR = _AOS.FindSameNamespace(namespaceDefinition);
                bool flag = _APR != null;
                if (flag)
                {
                    leaf._ACY(_APR.FindName(text, numTypeArgs, true));
                    bool flag2 = leaf._AAB() != null;
                    if (flag2)
                    {
                        break;
                    }
                }
            }
        }

        // Token: 0x060004D3 RID: 1235 RVA: 0x000CFBCC File Offset: 0x000CDDCC
        public void ResolveAttributeInReferencedAssemblies(_bb4.DHBA leaf, _bn1 namespaceDefinition)
        {
            string text = _bh4.DecodeId(leaf._ACX.text);
            foreach (_bj5 _AOS in this._CGL())
            {
                _bn1 _APR = _AOS.FindSameNamespace(namespaceDefinition);
                bool flag = _APR != null;
                if (flag)
                {
                    leaf._ACY(_APR.FindName(text, 0, true));
                    bool flag2 = leaf._AAB() != null;
                    if (flag2)
                    {
                        break;
                    }
                    leaf._ACY(_APR.FindName(text + "Attribute", 0, true));
                    bool flag3 = leaf._AAB() != null;
                    if (flag3)
                    {
                        break;
                    }
                }
            }
        }

        // Token: 0x060004D4 RID: 1236 RVA: 0x000CFC6C File Offset: 0x000CDE6C
        public void GetMembersCompletionDataFromReferencedAssemblies(Dictionary<string, _bh4> data, _bn1 namespaceDefinition, _be4 context)
        {
            bool dpffejopbcppmnlkdimelbaiddffeieonpic = _bj5.DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC;
            if (!dpffejopbcppmnlkdimelbaiddffeieonpic)
            {
                foreach (_bj5 _AOS in this._CGL())
                {
                    _bn1 _APR = _AOS.FindSameNamespace(namespaceDefinition);
                    bool flag = _APR != null;
                    if (flag)
                    {
                        _bj5.DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC = true;
                        AccessLevelMask accessLevelMask = (_AOS.InternalsVisibleIn(this) ? (AccessLevelMask.Internal | AccessLevelMask.Public) : AccessLevelMask.Public);
                        _APR.GetMembersCompletionData(data, BindingFlags.Default, accessLevelMask, context);
                        _bj5.DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC = false;
                    }
                }
            }
        }

        // Token: 0x060004D5 RID: 1237 RVA: 0x000CFCE0 File Offset: 0x000CDEE0
        public void GetTypesOnlyCompletionDataFromReferencedAssemblies(Dictionary<string, _bh4> data, _bn1 namespaceDefinition)
        {
            bool dpffejopbcppmnlkdimelbaiddffeieonpic = _bj5.DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC;
            if (!dpffejopbcppmnlkdimelbaiddffeieonpic)
            {
                foreach (_bj5 _AOS in this._CGL())
                {
                    _bn1 _APR = _AOS.FindSameNamespace(namespaceDefinition);
                    bool flag = _APR != null;
                    if (flag)
                    {
                        _bj5.DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC = true;
                        AccessLevelMask accessLevelMask = (_AOS.InternalsVisibleIn(this) ? (AccessLevelMask.Internal | AccessLevelMask.Public) : AccessLevelMask.Public);
                        _APR.GetTypesOnlyCompletionData(data, accessLevelMask, this);
                        _bj5.DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC = false;
                    }
                }
            }
        }

        // Token: 0x060004D6 RID: 1238 RVA: 0x000CFD54 File Offset: 0x000CDF54
        public void CollectExtensionMethods(_bn1 namespaceDefinition, string id, KJK[] typeArgs, _b2 extendedType, HashSet<_bb3> extensionsMethods, _bm6 context)
        {
            namespaceDefinition.CollectExtensionMethods(id, typeArgs, extendedType, extensionsMethods, context);
            foreach (_bj5 _AOS in this._CGL())
            {
                _bn1 _APR = _AOS.FindSameNamespace(namespaceDefinition);
                bool flag = _APR != null;
                if (flag)
                {
                    _APR.CollectExtensionMethods(id, typeArgs, extendedType, extensionsMethods, context);
                }
            }
        }

        // Token: 0x060004D7 RID: 1239 RVA: 0x000CFDB0 File Offset: 0x000CDFB0
        public void GetExtensionMethodsCompletionData(_b2 targetType, _bn1 namespaceDefinition, Dictionary<string, _bh4> data)
        {
            namespaceDefinition.GetExtensionMethodsCompletionData(targetType, data, AccessLevelMask.Internal | AccessLevelMask.Public);
            foreach (_bj5 _AOS in this._CGL())
            {
                _bn1 _APR = _AOS.FindSameNamespace(namespaceDefinition);
                bool flag = _APR != null;
                if (flag)
                {
                    _APR.GetExtensionMethodsCompletionData(targetType, data, AccessLevelMask.Public | (_AOS.InternalsVisibleIn(this) ? AccessLevelMask.Internal : AccessLevelMask.None));
                }
            }
        }

        // Token: 0x060004D8 RID: 1240 RVA: 0x000CFE0F File Offset: 0x000CE00F
        public IEnumerable<_b2> EnumAssignableTypesFor(_b2 type)
        {
            yield return type;
            yield break;
        }

        // Token: 0x060004D9 RID: 1241 RVA: 0x000CFE26 File Offset: 0x000CE026
        public IEnumerable<_b2> EnumTypes(string name)
        {
            foreach (_b2 type in this._AWL().EnumTypes(name))
            {
                yield return type;
            }
            IEnumerator<_b2> enumerator = null;
            int i = this._CGL().Length;
            for (; ; )
            {
                int num = i;
                i = num - 1;
                if (num <= 0)
                {
                    break;
                }
                foreach (_b2 type2 in this._CGL()[i]._AWL().EnumTypes(name))
                {
                    yield return type2;
                }
                IEnumerator<_b2> enumerator2 = null;
            }
            yield break;
            yield break;
        }

        // Token: 0x040004C4 RID: 1220
        public readonly System.Reflection.Assembly _AN;

        // Token: 0x040004C5 RID: 1221
        public readonly _bj5._AZG BONGPABCEFDMENFDOAGEDKEJJHNFJEILMCJN;

        // Token: 0x040004C6 RID: 1222
        public readonly bool AHMPIKDFEFMCLFLJOEKHGBJIMNOBBAPNIJHE;

        // Token: 0x040004C7 RID: 1223
        public readonly bool _CHJ;

        // Token: 0x040004C8 RID: 1224
        private readonly System.Reflection.Assembly CNLPKBIEMCAJJODDNIDIOECPEGCPLFIFCECM;

        // Token: 0x040004C9 RID: 1225
        private string[] IPIBJLDELAOIIOOAKPNMONGKKKKNFOEMLCMD;

        // Token: 0x040004CA RID: 1226
        private _bj5[] FBDPOLPFENEOLPJAIAOLLFPPDBDGGJAPEDCL;

        // Token: 0x040004CB RID: 1227
        public Dictionary<string, _be7> EKNILLOGEAIKLJHEMKKAGIBGBNKMFENLCAFB;

        // Token: 0x040004CC RID: 1228
        private static readonly Dictionary<System.Reflection.Assembly, _bj5> DIBFNKBPDMFNEMNDIPLBONFLMFAKKCEPLILA = new Dictionary<System.Reflection.Assembly, _bj5>();

        // Token: 0x040004CD RID: 1229
        private static readonly string[] AIHMBPHEBJJOIOJHJLAKHCLOPLCHGKELDCBB = new string[]
        {
            null, null, "assembly-csharp-firstpass", "assembly-unityscript-firstpass", "assembly-boo-firstpass", null, "assembly-csharp-editor-firstpass", "assembly-unityscript-editor-firstpass", "assembly-boo-editor-firstpass", null,
            "assembly-csharp", "assembly-unityscript", "assembly-boo", null, "assembly-csharp-editor", "assembly-unityscript-editor", "assembly-boo-editor"
        };

        // Token: 0x040004CE RID: 1230
        private static List<System.Reflection.Assembly> IDKNPDILLAILDKAJDMDDGHJLFOGFCIHKFDND;

        // Token: 0x040004CF RID: 1231
        private static Dictionary<string, _bj5> PJKEBCBBMNJPCABBHPIKIMEJMACMLDFJBDNH = new Dictionary<string, _bj5>();

        // Token: 0x040004D0 RID: 1232
        private static readonly _bj5[] HPEELBCJDACILOAICOJANFMEPEPPLAJLOOOO = new _bj5[17];

        // Token: 0x040004D1 RID: 1233
        private static UnityEditor.Compilation.Assembly[] GHGINOAGGIFEFJMGDMAMNONFFDIOJLJAMIPP;

        // Token: 0x040004D2 RID: 1234
        private _bn1 IEHBPMHEDHEDEIDGKCOEMLAOBNPFFFKFGMBN;

        // Token: 0x040004D3 RID: 1235
        private static bool DPFFEJOPBCPPMNLKDIMELBAIDDFFEIEONPIC = false;

        // Token: 0x020000A9 RID: 169
        public enum _AZG
        {

        }

        // Token: 0x020000AA RID: 170
        private static class DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH
        {
            // Token: 0x060004DB RID: 1243 RVA: 0x000CFEE8 File Offset: 0x000CE0E8
            static DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH()
            {
                bool flag = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.MMJJHOFKBADDJHDANIDEDLHCGBHBAFLECEFP == null;
                if (!flag)
                {
                    bool flag2 = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.CFCELDACEKAFNCDBGPKBICBKKFHBMHBLDPFD == null;
                    if (!flag2)
                    {
                        bool flag3 = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.HONGPCHCHGPABLPNNMDHENOLKEDAPBCICEAO == null;
                        if (flag3)
                        {
                            _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.HONGPCHCHGPABLPNNMDHENOLKEDAPBCICEAO = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.CFCELDACEKAFNCDBGPKBICBKKFHBMHBLDPFD.GetField("_output", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.BLELCPBEGBFFCDFHJGNHFMIEEAIBJOMJKKOI = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.CFCELDACEKAFNCDBGPKBICBKKFHBMHBLDPFD.GetField("_references", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        }
                        bool flag4 = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.HONGPCHCHGPABLPNNMDHENOLKEDAPBCICEAO == null || _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.BLELCPBEGBFFCDFHJGNHFMIEEAIBJOMJKKOI == null;
                        if (!flag4)
                        {
                            _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.EIECBAGFDILHCEKGMLHOCBHEELKMAJADPFOL = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.MMJJHOFKBADDJHDANIDEDLHCGBHBAFLECEFP.Invoke(null, null) as IEnumerable;
                        }
                    }
                }
            }

            // Token: 0x060004DC RID: 1244 RVA: 0x000CFFBC File Offset: 0x000CE1BC
            public static string[] GetReferencedAssembliesFor(string assemblyName)
            {
                bool flag = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.EIECBAGFDILHCEKGMLHOCBHEELKMAJADPFOL == null;
                string[] array;
                if (flag)
                {
                    array = null;
                }
                else
                {
                    assemblyName += ".dll";
                    foreach (object obj in _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.EIECBAGFDILHCEKGMLHOCBHEELKMAJADPFOL)
                    {
                        string text = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.HONGPCHCHGPABLPNNMDHENOLKEDAPBCICEAO.GetValue(obj) as string;
                        bool flag2 = !text.EndsWith(assemblyName, StringComparison.OrdinalIgnoreCase);
                        if (!flag2)
                        {
                            string[] array2 = _bj5.DFJANIPKIHDLIPCJMJBAILHMKBNDMPBAACAH.BLELCPBEGBFFCDFHJGNHFMIEEAIBJOMJKKOI.GetValue(obj) as string[];
                            bool flag3 = array2 == null;
                            if (flag3)
                            {
                                return null;
                            }
                            int num = array2.Length;
                            while (num-- > 0)
                            {
                                string text2 = array2[num];
                                array2[num] = Path.GetFullPath(text2);
                            }
                            return array2;
                        }
                    }
                    array = null;
                }
                return array;
            }

            // Token: 0x040004D5 RID: 1237
            private static IEnumerable EIECBAGFDILHCEKGMLHOCBHEELKMAJADPFOL;

            // Token: 0x040004D6 RID: 1238
            private static FieldInfo HONGPCHCHGPABLPNNMDHENOLKEDAPBCICEAO;

            // Token: 0x040004D7 RID: 1239
            private static FieldInfo BLELCPBEGBFFCDFHJGNHFMIEEAIBJOMJKKOI;

            // Token: 0x040004D8 RID: 1240
            private static Type CFCELDACEKAFNCDBGPKBICBKKFHBMHBLDPFD = Type.GetType("UnityEditor.Scripting.MonoIsland,UnityEditor.dll");

            // Token: 0x040004D9 RID: 1241
            private static MethodInfo MMJJHOFKBADDJHDANIDEDLHCGBHBAFLECEFP = typeof(InternalEditorUtility).GetMethod("GetMonoIslands", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }
    }
}
