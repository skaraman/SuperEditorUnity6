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
        public bool KKHDOOBGKDFNBNHKIABFLCLNEEKLNAOBFKLL()
        {
            return this.KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG;
        }

        // Token: 0x060000E4 RID: 228 RVA: 0x0000B9EC File Offset: 0x00009BEC
        private bool GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL()
        {
            return this.IEAFHEIADBPDLHOICBNABMGPIJIFJBPONCEG;
        }

        // Token: 0x060000E5 RID: 229 RVA: 0x0000BA04 File Offset: 0x00009C04
        private void LDMGGPLFEICIBLAPIIHKEPPPJMMONMLHJKFO(bool value)
        {
            _bf5 ifakfikkhcdjcimikjnjfhcafmjnkieilfpb = _bg8._BCH;
            this.IEAFHEIADBPDLHOICBNABMGPIJIFJBPONCEG = value;
            ifakfikkhcdjcimikjnjfhcafmjnkieilfpb._AIF(value);
        }

        // Token: 0x060000E6 RID: 230 RVA: 0x0000BA28 File Offset: 0x00009C28
        internal static HashSet<_bk5> ELBDCKLCPKCKNMHKMJBOLAIJAILJMCEOFICG()
        {
            return _bk5.LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL;
        }

        // Token: 0x060000E7 RID: 231 RVA: 0x0000BA40 File Offset: 0x00009C40
        public void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(new GUIContent("Lock"), this.KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG, delegate
            {
                this.KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG = !this.KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG;
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
            _bk5 _AZF = array.FirstOrDefault((_bk5 w) => !w.KKHDOOBGKDFNBNHKIABFLCLNEEKLNAOBFKLL() && w.titleContent.text.Contains(reuseWindowByTitle));
            _bk5 _AZF2 = _AZF ?? ScriptableObject.CreateInstance<_bk5>();
            bool flag = !_AZF && array.Length == 0;
            if (flag)
            {
                Assembly assembly = typeof(EditorWindow).Assembly;
                _bb6.DockNextTo(_AZF2, EditorWindow.GetWindow(assembly.GetType("UnityEditor.ConsoleWindow")));
            }
            _AZF2.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = description;
            _AZF2.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL = searchFunction;
            _AZF2.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD = new List<string>(assetGuids);
            _AZF2.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI = searchOptions;
            _AZF2.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP = new _bk5.OLICOJKMCLBLLGDNHPLEFMBEBCBOMOGCCFMG
            {
                LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB = true,
                CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG = true,
                EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN = true,
                LHENAJONEMNBCMPLOFPIEACFPMMNJPPBCPBL = true,
                DJDCLJAEKIMKHHEMBLNCJMHHECCJNIOAFFAN = true,
                DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ = true,
                PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN = true,
                PEDKJJOBBCANDKHAKPGFBOOGMDIKMNFBPNJJ = false,
                IFGBHIENCIHHNDDDHJDCDNGLOEMBPLELKBKG = true,
                FILMHPLDEBEFKFIALNEDOIFFHNFNPOCMIANI = true,
                DPEMBCFJFEONMONFGFCJJBBEHDKFPJAEPFNJ = true,
                NBPNKNDFNIPKOLLALEOOIMBKKCNKKCICIPLE = true,
                _AIC = true
            };
            _AZF2.IEAFHEIADBPDLHOICBNABMGPIJIFJBPONCEG = _bg8._BCH;
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
                _bk5.NLMCPMFNKKMCNFOAGAJBILLOLNNDELPCJOEG++;
                _AZF2.titleContent.text = "References";
                bool flag8 = _bk5.NLMCPMFNKKMCNFOAGAJBILLOLNNDELPCJOEG > 1;
                if (flag8)
                {
                    int num = 0;
                    foreach (_bk5 _AZF4 in _bk5.LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL)
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
                _bk5.JLJAHPNMHNJFEDCLDBEEFLOEPOLOGKPAFKBI++;
                _AZF2.titleContent.text = "Find Results";
                bool flag14 = _bk5.JLJAHPNMHNJFEDCLDBEEFLOEPOLOGKPAFKBI > 1;
                if (flag14)
                {
                    int num3 = 0;
                    foreach (_bk5 _AZF5 in _bk5.LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL)
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
            _AZF2.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
            return _AZF2;
        }

        // Token: 0x060000E9 RID: 233 RVA: 0x0000BF34 File Offset: 0x0000A134
        internal void BackgroundSearch()
        {
            bool flag = this.ANAFOPMKLEICDAGPAABKGGMCDLCFLAAGCPEF && !_bg8._BBD;
            if (!flag)
            {
                bool flag2 = this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL != null && this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK < this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                if (flag2)
                {
                    List<string> jiiohdobnlkgcmaneljkkpbpddaajcaichkd = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD;
                    int num = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK;
                    this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = num + 1;
                    string text = jiiohdobnlkgcmaneljkkpbpddaajcaichkd[num];
                    bool flag3 = this.ACCCDMNKMKPLNNIGMFMPJHJPIILMAKOCOKNL != null;
                    if (flag3)
                    {
                        while (text != null && !this.ACCCDMNKMKPLNNIGMFMPJHJPIILMAKOCOKNL(text, this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP))
                        {
                            this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Add(text);
                            bool flag4 = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK < this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                            if (flag4)
                            {
                                List<string> jiiohdobnlkgcmaneljkkpbpddaajcaichkd2 = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD;
                                num = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK;
                                this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = num + 1;
                                text = jiiohdobnlkgcmaneljkkpbpddaajcaichkd2[num];
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
                        this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL(new Action<string, string, TextPosition, int>(this.AddResult), text, this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI);
                    }
                }
                else
                {
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.BackgroundSearch));
                }
            }
        }

        // Token: 0x060000EA RID: 234 RVA: 0x0000C074 File Offset: 0x0000A274
        public void SetFilesValidator(_bk5.EIJNJHPLNPFJGGJHJPGEMFCMHALBIIFBBOEI validateFileFunction)
        {
            this.ACCCDMNKMKPLNNIGMFMPJHJPIILMAKOCOKNL = validateFileFunction;
        }

        // Token: 0x060000EB RID: 235 RVA: 0x0000C080 File Offset: 0x0000A280
        public void SetResultsValidator(_bk5.ONEILDCAMHIOCHJBHGPGBFLIDNIFNKFCIGAD validateResultFunction, _bh4 referencedSymbol)
        {
            this.FGEBPBBLGHOBKAEMFDHLMGKGHFLFEHPJCJAK = validateResultFunction;
            this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI = referencedSymbol;
            this.CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI = referencedSymbol is _bn3;
            this.GFCFECKGDMOOLINNBENJLAHKNFBHMBMMMHDB = referencedSymbol is _b2;
            this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO = referencedSymbol._AT;
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
            base.titleContent.text = ((this.FGEBPBBLGHOBKAEMFDHLMGKGHFLFEHPJCJAK != null) ? "Rename" : "Replace");
            base.Repaint();
        }

        // Token: 0x060000ED RID: 237 RVA: 0x0000C18C File Offset: 0x0000A38C
        public void ReplaceAllAfterSearchAndSetFocus(EditorWindow toWindow)
        {
            this.NAGHPOFOPMEFEJGNHKEJPGMIEPMNPPLDHGOJ = true;
            this.DMMNGGPAMAPFEKGELANHKAHHDNNGHBCJKIDF = toWindow;
        }

        // Token: 0x060000EE RID: 238 RVA: 0x0000C1A0 File Offset: 0x0000A3A0
        private void ClearResults()
        {
            this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = "Found 0 result.";
            this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO = true;
            this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = 0;
            this._AFS = Vector2.zero;
            this._ADS = 0;
            this.OGCAAFGPNCHFLOBHGHIBIBNDBPDGPMNMBFAP = 0f;
            this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Clear();
            this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Clear();
            this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Clear();
            this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO = 0;
            this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL = 0;
            this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Clear();
        }

        // Token: 0x060000EF RID: 239 RVA: 0x0000C224 File Offset: 0x0000A424
        private void OnEnable()
        {
            _bk5.LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL.Add(this);
            base.titleContent.image = EditorGUIUtility.IconContent("UnityEditor.ConsoleWindow").image;
            bool flag = _bk5.LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL.Count > 0;
            if (flag)
            {
                bool flag2 = base.titleContent.text.Contains("References");
                if (flag2)
                {
                    _bk5.NLMCPMFNKKMCNFOAGAJBILLOLNNDELPCJOEG++;
                }
                bool flag3 = base.titleContent.text.Contains("Find Results");
                if (flag3)
                {
                    _bk5.JLJAHPNMHNJFEDCLDBEEFLOEPOLOGKPAFKBI++;
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
            _bk5.MMCDDHCLAFDONNAEGKKAMPCHIPKEGFLOKKNJ = _a2.GetInstance().GetTexture(Base64Texture.Filter);
            _bk5.AGLHFAKCNBPCDFDPAPHOKIFMJMBKMNGNEFDA = _a2.GetInstance().GetTexture(Base64Texture.SortingGrouping);
            _bk5.ALOEFJKKLIKBILEHIFCLFFEFLHPAPLKFEECC = _a2.GetInstance().GetTexture(Base64Texture.ReplaceAll);
            _bk5.HHGCJOCHLBGIINKOOAHBGOOPCPGDIIMKAMMJ = _a2.GetInstance().GetTexture(Base64Texture.Pin);
            _bk5.PKGBCHECOFFCCDOJHGBBAHPEBJBPIKNKBPIP = _a2.GetInstance().GetTexture(Base64Texture.Stop);
            _bk5.JDOPNFHIMOEPCHNKNFIBGNHDOHMFHJBJPNPE = _a2.GetInstance().GetTexture(Base64Texture.ExpandAll);
            _bk5.GIIMBFLDGJKPDBOBDLJFLDMHCEINMPCJFNAJ = _a2.GetInstance().GetTexture(Base64Texture.CollapseAll);
            _bk5._CEH = _a2.GetInstance().GetTexture(Base64Texture.WhitePing);
        }

        // Token: 0x060000F1 RID: 241 RVA: 0x0000C3E4 File Offset: 0x0000A5E4
        private void Unsubscribe()
        {
            this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Clear();
            this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Clear();
            this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = 0;
            this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL = null;
            GCE._AUJ = (GCE._AVH)Delegate.Remove(GCE._AUJ, new GCE._AVH(this.OnInsertedLines));
            GCE._AUN = (GCE._AVL)Delegate.Remove(GCE._AUN, new GCE._AVL(this.OnRemovedLines));
            GCE._AUL = (GCE._AVJ)Delegate.Remove(GCE._AUL, new GCE._AVJ(this.OnBufferModified));
            GCE._AUP = (GCE._AVN)Delegate.Remove(GCE._AUP, new GCE._AVN(this.OnBufferModified));
        }

        // Token: 0x060000F2 RID: 242 RVA: 0x0000C498 File Offset: 0x0000A698
        private void OnDisable()
        {
            _bk5.LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL.Remove(this);
            this.Unsubscribe();
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x0000C4B0 File Offset: 0x0000A6B0
        private void OnDestroy()
        {
            this.Unsubscribe();
            bool flag = base.titleContent.text.Contains("References");
            if (flag)
            {
                _bk5.NLMCPMFNKKMCNFOAGAJBILLOLNNDELPCJOEG--;
            }
            bool flag2 = base.titleContent.text.Contains("Find Results");
            if (flag2)
            {
                _bk5.JLJAHPNMHNJFEDCLDBEEFLOEPOLOGKPAFKBI--;
            }
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x0000C510 File Offset: 0x0000A710
        private void OnBufferModified(string guid, GCE._AFA from, GCE._AFA to)
        {
            for (int i = 0; i < this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count; i++)
            {
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[i];
                bool flag = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && guid == iobcmjadenalgemehnfhliaillknadbhioan._ADF;
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
            for (int i = 0; i < this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count; i++)
            {
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[i];
                bool flag = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && guid == iobcmjadenalgemehnfhliaillknadbhioan._ADF;
                if (flag)
                {
                    bool flag2 = lineIndex <= iobcmjadenalgemehnfhliaillknadbhioan._ABI;
                    if (flag2)
                    {
                        iobcmjadenalgemehnfhliaillknadbhioan._ABI += numLines;
                        this.JCMLMBHKNGPHMBCGCJIDKKBNCAOGCOCEEKDI = true;
                    }
                }
            }
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x0000C5F4 File Offset: 0x0000A7F4
        private void OnRemovedLines(string guid, int lineIndex, int numLines)
        {
            for (int i = 0; i < this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count; i++)
            {
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[i];
                bool flag = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && guid == iobcmjadenalgemehnfhliaillknadbhioan._ADF;
                if (flag)
                {
                    bool flag2 = lineIndex <= iobcmjadenalgemehnfhliaillknadbhioan._ABI;
                    if (flag2)
                    {
                        bool flag3 = lineIndex + numLines <= iobcmjadenalgemehnfhliaillknadbhioan._ABI;
                        if (flag3)
                        {
                            iobcmjadenalgemehnfhliaillknadbhioan._ABI -= numLines;
                        }
                        else
                        {
                            iobcmjadenalgemehnfhliaillknadbhioan._ABI = lineIndex;
                        }
                        this.JCMLMBHKNGPHMBCGCJIDKKBNCAOGCOCEEKDI = true;
                    }
                }
            }
        }

        // Token: 0x060000F7 RID: 247 RVA: 0x0000C691 File Offset: 0x0000A891
        protected void OnLostFocus()
        {
            this.ANAFOPMKLEICDAGPAABKGGMCDLCFLAAGCPEF = false;
        }

        // Token: 0x060000F8 RID: 248 RVA: 0x0000C69C File Offset: 0x0000A89C
        private void Update()
        {
            this.ANAFOPMKLEICDAGPAABKGGMCDLCFLAAGCPEF = true;
            bool flag = base.titleContent.tooltip != this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB;
            if (flag)
            {
                this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = _bb6.StringCheck(this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB);
                base.titleContent.tooltip = this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB;
            }
            bool jcmlmbhkngphmbcgcjidkkbncaogcoceekdi = this.JCMLMBHKNGPHMBCGCJIDKKBNCAOGCOCEEKDI;
            if (jcmlmbhkngphmbcgcjidkkbncaogcoceekdi)
            {
                this.JCMLMBHKNGPHMBCGCJIDKKBNCAOGCOCEEKDI = false;
                base.Repaint();
            }
            else
            {
                bool flag2 = this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL != null && this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK < this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                if (flag2)
                {
                    List<string> jiiohdobnlkgcmaneljkkpbpddaajcaichkd = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD;
                    int num = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK;
                    this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = num + 1;
                    string text = jiiohdobnlkgcmaneljkkpbpddaajcaichkd[num];
                    bool flag3 = this.ACCCDMNKMKPLNNIGMFMPJHJPIILMAKOCOKNL != null;
                    if (flag3)
                    {
                        while (text != null && !this.ACCCDMNKMKPLNNIGMFMPJHJPIILMAKOCOKNL(text, this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP))
                        {
                            this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Add(text);
                            bool flag4 = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK < this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                            if (flag4)
                            {
                                List<string> jiiohdobnlkgcmaneljkkpbpddaajcaichkd2 = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD;
                                num = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK;
                                this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = num + 1;
                                text = jiiohdobnlkgcmaneljkkpbpddaajcaichkd2[num];
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
                        this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL(new Action<string, string, TextPosition, int>(this.AddResult), text, this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI);
                        return;
                    }
                }
                bool flag6 = this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL != null && this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK == this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                if (flag6)
                {
                    this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Clear();
                    this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = 1;
                    bool flag7 = this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI != null && base.titleContent.text != "Rename";
                    if (flag7)
                    {
                        this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "References to " + this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI._AYM();
                        this.HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH = "References to " + this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI._AYM();
                    }
                    else
                    {
                        bool flag8 = this.HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH != "";
                        if (flag8)
                        {
                            this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = this.HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH;
                        }
                        else
                        {
                            bool flag9 = base.titleContent.text.Contains("Find Results");
                            if (flag9)
                            {
                                this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "Find results for '" + this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG + "'";
                            }
                            else
                            {
                                bool flag10 = base.titleContent.text == "Replace";
                                if (flag10)
                                {
                                    this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = string.Concat(new string[]
                                    {
                                        "Replace '",
                                        this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG,
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
                                        this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = string.Concat(new string[]
                                        {
                                            "Rename '",
                                            this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG,
                                            "' to '",
                                            this._AVV,
                                            "'"
                                        });
                                    }
                                }
                            }
                        }
                    }
                    this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO > 0;
                    bool naghpofopmefejgnhkejpgmiepmnppldhgoj = this.NAGHPOFOPMEFEJGNHKEJPGMIEPMNPPLDHGOJ;
                    if (naghpofopmefejgnhkejpgmiepmnppldhgoj)
                    {
                        this.NAGHPOFOPMEFEJGNHKEJPGMIEPMNPPLDHGOJ = false;
                        this.ReplaceAll(false);
                        bool flag12 = this.DMMNGGPAMAPFEKGELANHKAHHDNNGHBCJKIDF;
                        if (flag12)
                        {
                            this.DMMNGGPAMAPFEKGELANHKAHHDNNGHBCJKIDF.Focus();
                        }
                        this.DMMNGGPAMAPFEKGELANHKAHHDNNGHBCJKIDF = null;
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
            List<_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN> list;
            if (isRename)
            {
                list = new List<_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN>();
                foreach (_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan in this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF)
                {
                    bool flag2 = iobcmjadenalgemehnfhliaillknadbhioan._ABI != 0;
                    if (flag2)
                    {
                        list.Add(iobcmjadenalgemehnfhliaillknadbhioan);
                    }
                }
            }
            else
            {
                list = this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK;
            }
            int count = list.Count;
            Func<_bb6, bool> tempBool3 = null;
            while (count-- > 0)
            {
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan2 = list[count];
                bool flag3 = !iobcmjadenalgemehnfhliaillknadbhioan2._BCL;
                if (!flag3)
                {
                    bool flag4 = iobcmjadenalgemehnfhliaillknadbhioan2._ADF != guid;
                    if (flag4)
                    {
                        guid = iobcmjadenalgemehnfhliaillknadbhioan2._ADF;
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
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan3 = list[count2];
                bool flag11 = !iobcmjadenalgemehnfhliaillknadbhioan3._BCL;
                if (!flag11)
                {
                    bool flag12 = iobcmjadenalgemehnfhliaillknadbhioan3._ADF != guid;
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
                        guid = iobcmjadenalgemehnfhliaillknadbhioan3._ADF;
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
                            _ABI = iobcmjadenalgemehnfhliaillknadbhioan3._ABI,
                            _AEU = iobcmjadenalgemehnfhliaillknadbhioan3._AEU
                        };
                        GCE._AFA _ATD2 = new GCE._AFA
                        {
                            _ABI = iobcmjadenalgemehnfhliaillknadbhioan3._ABI,
                            _AEU = iobcmjadenalgemehnfhliaillknadbhioan3._AEU + iobcmjadenalgemehnfhliaillknadbhioan3.MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG
                        };
                        GCE._AFA _ATD3 = _AMX.DeleteText(_ATD, _ATD2);
                        bool flag17 = base.titleContent.text == "Replace" || base.titleContent.text == "Rename";
                        if (flag17)
                        {
                            _AMX.InsertText(_ATD3, this._AVV);
                        }
                        hashSet2.Add(iobcmjadenalgemehnfhliaillknadbhioan3._ABI);
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
        private bool CheckFiltering(_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK resultType)
        {
            bool flag;
            switch (resultType)
            {
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)2:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)3:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)4:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB || this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)5:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)6:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LHENAJONEMNBCMPLOFPIEACFPMMNJPPBCPBL;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)7:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DJDCLJAEKIMKHHEMBLNCJMHHECCJNIOAFFAN;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)8:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)9:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)10:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PEDKJJOBBCANDKHAKPGFBOOGMDIKMNFBPNJJ;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)11:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PEDKJJOBBCANDKHAKPGFBOOGMDIKMNFBPNJJ && (this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ || this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN);
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)12:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.IFGBHIENCIHHNDDDHJDCDNGLOEMBPLELKBKG;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)13:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.AMGPPANKBBMOFJBOEPECEPHNFHIIDAADJAMP;
                    break;
                case (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)14:
                    flag = this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.FCAKBOGNALCBCLCDDEMIMHNPPEIAGLDGNOIC;
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
            bool flag = this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0;
            if (flag)
            {
                this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Clear();
                this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO = 0;
                this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL = 0;
                for (int i = 0; i < this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count; i++)
                {
                    _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[i];
                    iobcmjadenalgemehnfhliaillknadbhioan.OIFGAJHBBOJODCCNKLHBPPOHMNNDNMCFPFJD = default(Rect);
                    _bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK onhcmochmdldefeiodakclhnaoiaeoelfnmm = iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM;
                    bool flag2 = onhcmochmdldefeiodakclhnaoiaeoelfnmm == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                    if (!flag2)
                    {
                        bool flag3 = !this.CheckFiltering(onhcmochmdldefeiodakclhnaoiaeoelfnmm);
                        if (!flag3)
                        {
                            string text = ((this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count > 0) ? this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count - 1]._ADF : null);
                            bool flag4 = iobcmjadenalgemehnfhliaillknadbhioan._ADF != text;
                            if (flag4)
                            {
                                this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL++;
                                bool flag5 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                                if (flag5)
                                {
                                    this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Add(new _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN
                                    {
                                        _ADF = iobcmjadenalgemehnfhliaillknadbhioan._ADF,
                                        _AMO = AssetDatabase.GUIDToAssetPath(iobcmjadenalgemehnfhliaillknadbhioan._ADF),
                                        _BCL = true
                                    });
                                }
                            }
                            else
                            {
                                bool flag6 = text == null;
                                if (flag6)
                                {
                                    this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL++;
                                }
                            }
                            this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Add(iobcmjadenalgemehnfhliaillknadbhioan);
                            this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO++;
                            bool flag7 = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO <= 1 && this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL <= 1;
                            if (flag7)
                            {
                                this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = string.Concat(new string[]
                                {
                                    "Found ",
                                    this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO.ToString(),
                                    " result in ",
                                    this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL.ToString(),
                                    " file."
                                });
                            }
                            else
                            {
                                bool flag8 = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO > 1 && this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL < 2;
                                if (flag8)
                                {
                                    this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = string.Concat(new string[]
                                    {
                                        "Found ",
                                        this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO.ToString(),
                                        " results in ",
                                        this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL.ToString(),
                                        " file."
                                    });
                                }
                                else
                                {
                                    this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = string.Concat(new string[]
                                    {
                                        "Found ",
                                        this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO.ToString(),
                                        " results in ",
                                        this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL.ToString(),
                                        " files."
                                    });
                                }
                            }
                        }
                    }
                }
                bool flag9 = this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI != null && base.titleContent.text != "Rename";
                if (flag9)
                {
                    this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "References to " + this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI._AYM();
                    this.HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH = "References to " + this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI._AYM();
                }
                else
                {
                    bool flag10 = this.HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH != "";
                    if (flag10)
                    {
                        this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = this.HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH;
                    }
                    else
                    {
                        bool flag11 = base.titleContent.text.Contains("Find Results");
                        if (flag11)
                        {
                            this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "Find results for '" + this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG + "'";
                        }
                        else
                        {
                            bool flag12 = base.titleContent.text == "Replace";
                            if (flag12)
                            {
                                this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = string.Concat(new string[]
                                {
                                    "Replace '",
                                    this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG,
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
                                    this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = string.Concat(new string[]
                                    {
                                        "Rename '",
                                        this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG,
                                        "' to '",
                                        this._AVV,
                                        "'"
                                    });
                                }
                            }
                        }
                    }
                }
                this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO > 0;
            }
            bool flag14 = this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Count > 0;
            if (flag14)
            {
                bool flag15 = this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK > this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                if (flag15)
                {
                    this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
                }
                this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.AddRange(this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH);
                this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Clear();
                this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO = true;
            }
            this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
        }

        // Token: 0x060000FC RID: 252 RVA: 0x0000D434 File Offset: 0x0000B634
        private void AddResult(string text, string guid, TextPosition location, int length)
        {
            try
            {
                _bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)0;
                bool flag = this.FGEBPBBLGHOBKAEMFDHLMGKGHFLFEHPJCJAK != null;
                if (flag)
                {
                    bpkllieiaimnbnmjccecpkdeheoodpgmplbk = this.FGEBPBBLGHOBKAEMFDHLMGKGHFLFEHPJCJAK(guid, location, length, ref this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI);
                    bool flag2 = bpkllieiaimnbnmjccecpkdeheoodpgmplbk == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                    if (flag2)
                    {
                        return;
                    }
                }
                bool flag3 = this.CheckFiltering(bpkllieiaimnbnmjccecpkdeheoodpgmplbk);
                bool flag4 = !char.IsWhiteSpace(text, location.index) && !char.IsWhiteSpace(text, location.index + length - 1);
                bool flag5 = flag3;
                if (flag5)
                {
                    string text2 = ((this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count > 0) ? this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count - 1]._ADF : null);
                    bool flag6 = guid != text2;
                    if (flag6)
                    {
                        this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL++;
                        bool flag7 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                        if (flag7)
                        {
                            this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Add(new _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN
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
                            this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL++;
                        }
                    }
                }
                string text3 = (flag4 ? text.TrimStart(Array.Empty<char>()) : text);
                int num = text.Length - text3.Length;
                text3 = (flag4 ? text3.TrimEnd(Array.Empty<char>()) : text);
                string text4 = AssetDatabase.GUIDToAssetPath(guid);
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = new _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN
                {
                    JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO = text3,
                    _ADF = guid,
                    _AMO = text4,
                    _BDK = Path.GetFileName(text4),
                    _ABI = location.line,
                    _AEU = location.index,
                    MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG = length,
                    LNGFNEJGOEBIFOOBCKPMGIMJHMKMNBAJFMNF = num,
                    ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM = bpkllieiaimnbnmjccecpkdeheoodpgmplbk,
                    _BCL = true,
                    AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO = this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO,
                    CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI = this.CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI,
                    GFCFECKGDMOOLINNBENJLAHKNFBHMBMMMHDB = this.GFCFECKGDMOOLINNBENJLAHKNFBHMBMMMHDB
                };
                bool flag9 = flag3;
                if (flag9)
                {
                    this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Add(iobcmjadenalgemehnfhliaillknadbhioan);
                    this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO++;
                    bool flag10 = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO <= 1 && this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL <= 1;
                    if (flag10)
                    {
                        this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = string.Concat(new string[]
                        {
                            "Found ",
                            this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO.ToString(),
                            " result in ",
                            this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL.ToString(),
                            " file."
                        });
                    }
                    else
                    {
                        bool flag11 = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO > 1 && this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL < 2;
                        if (flag11)
                        {
                            this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = string.Concat(new string[]
                            {
                                "Found ",
                                this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO.ToString(),
                                " results in ",
                                this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL.ToString(),
                                " file."
                            });
                        }
                        else
                        {
                            this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = string.Concat(new string[]
                            {
                                "Found ",
                                this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO.ToString(),
                                " results in ",
                                this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL.ToString(),
                                " files."
                            });
                        }
                    }
                }
                this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Add(iobcmjadenalgemehnfhliaillknadbhioan);
            }
            finally
            {
            }
            this.JCMLMBHKNGPHMBCGCJIDKKBNCAOGCOCEEKDI = true;
        }

        // Token: 0x060000FD RID: 253 RVA: 0x0000D788 File Offset: 0x0000B988
        private void GoToResult(int index)
        {
            bool flag = index >= this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count;
            if (!flag)
            {
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[index];
                _bb6.OpenAssetInTab(iobcmjadenalgemehnfhliaillknadbhioan._ADF, iobcmjadenalgemehnfhliaillknadbhioan._ABI, iobcmjadenalgemehnfhliaillknadbhioan._AEU, iobcmjadenalgemehnfhliaillknadbhioan.MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG, !_bg8.EAIK.GNIO());
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
                    bool flag8 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                    if (flag8)
                    {
                        while (num < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count && this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num]._AMO))
                        {
                            num++;
                        }
                    }
                    bool flag9 = num == this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count;
                    if (flag9)
                    {
                        num = this._ADS;
                    }
                    bool flag10 = num >= 0 && this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null;
                    if (flag10)
                    {
                        this.GoToResult(num);
                        base.Focus();
                    }
                }
                else
                {
                    bool flag11 = (int)Event.current.keyCode == 275 && this._ADS < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count;
                    if (flag11)
                    {
                        bool flag12 = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null && this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._AMO);
                        if (flag12)
                        {
                            this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Remove(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._AMO);
                            this._CIL = true;
                            this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
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
                            bool flag14 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                            if (flag14)
                            {
                                while (num > 0 && this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num]._AMO))
                                {
                                    num--;
                                }
                            }
                            bool flag15 = num >= 0 && this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null;
                            if (flag15)
                            {
                                this.GoToResult(num);
                                base.Focus();
                            }
                        }
                        else
                        {
                            bool flag16 = (int)Event.current.keyCode == 276 && this._ADS < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count;
                            if (flag16)
                            {
                                bool flag17 = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                                if (flag17)
                                {
                                    bool flag18 = !this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._AMO);
                                    if (flag18)
                                    {
                                        this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Add(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._AMO);
                                    }
                                    this._CIL = true;
                                    this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
                                }
                                else
                                {
                                    bool flag19 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                                    if (flag19)
                                    {
                                        while (this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null)
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
                                        num = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count - 1;
                                        bool flag22 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                                        if (flag22)
                                        {
                                            while (num > 0 && this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num]._AMO))
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
                num = Mathf.Max(0, Mathf.Min(num, this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count - 1));
                this.KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ = this.KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ || this._CIL || num != this._ADS;
                this._CIL = this._CIL || num != this._ADS;
                this._ADS = num;
                bool flag23 = (int)Event.current.keyCode == 13 || (int)Event.current.keyCode == 271 || (int)Event.current.keyCode == 32;
                if (flag23)
                {
                    bool flag24 = this._ADS < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count;
                    if (flag24)
                    {
                        Event.current.Use();
                        bool flag25 = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS].JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null;
                        if (flag25)
                        {
                            bool flag26 = this._AVV == "" || (int)Event.current.keyCode != 32;
                            if (flag26)
                            {
                                this.GoToResult(this._ADS);
                            }
                            else
                            {
                                this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._BCL = !this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._BCL;
                                this._CIL = true;
                            }
                        }
                        else
                        {
                            string gbcbidoiiiaefjkdnpijonchckjlgpnjklfd = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS]._AMO;
                            bool flag27 = this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
                            if (flag27)
                            {
                                this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Remove(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
                            }
                            else
                            {
                                bool flag28 = !this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
                                if (flag28)
                                {
                                    this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Add(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
                                }
                            }
                            this._CIL = true;
                            this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
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
            bool flag = _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB == null;
            if (flag)
            {
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB = new GUIStyle("PR Label");
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.padding.top = 2;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.padding.bottom = 2;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.padding.left = 2;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.margin.right = 0;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.fixedHeight = 0f;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.richText = false;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.stretchWidth = true;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.wordWrap = false;
                _bk5.NLHGNOONBNJBGNDJKIHEBJPBNABHBONANLPE = new GUIStyle(_bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB);
                GUIStyle guistyle = "CN EntryBackEven";
                GUIStyle guistyle2 = "CN EntryBackodd";
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.normal.background = guistyle.normal.background;
                _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB.focused.background = guistyle.normal.background;
                _bk5.NLHGNOONBNJBGNDJKIHEBJPBNABHBONANLPE.normal.background = guistyle2.normal.background;
                _bk5.NLHGNOONBNJBGNDJKIHEBJPBNABHBONANLPE.focused.background = guistyle2.normal.background;
                _bk5.KJGFPGANEBLIMMAEFLMJAJCMJCDGDCOADNCA = "PR Ping";
                _bk5.CIFMDOEMJOFLMKNNCIBJHJKECJBBHIMIHODF = new GUIStyle(_bk5.KJGFPGANEBLIMMAEFLMJAJCMJCDGDCOADNCA);
                _bk5.CIFMDOEMJOFLMKNNCIBJHJKECJBBHIMIHODF.normal.background = _bk5._CEH;
                _bk5.PCNMLIIMDPLNLDAJDPGCGLONAEBJGCJCIHHL = "ToggleMixed";
                _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK = new GUIStyle(EditorStyles.toolbarButton);
                _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK.fontStyle = (FontStyle)1;
            }
            float num = 26f;
            Rect rect = new Rect(0f, 20f, EditorGUIUtility.currentViewWidth, 1f);
            GUILayout.Space(1f);
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag2 = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count > 0;
            if (flag2)
            {
                rect.width = num;
                rect.x = 0f;
                bool flag3 = GUI.Toggle(rect, false, new GUIContent(_bk5.PKGBCHECOFFCCDOJHGBBAHPEBJBPIKNKBPIP, "Stop"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
                if (flag3)
                {
                    this.PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL = null;
                    this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK = 1;
                    this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Clear();
                    this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Clear();
                    this.NAGHPOFOPMEFEJGNHKEJPGMIEPMNPPLDHGOJ = false;
                    this.DMMNGGPAMAPFEKGELANHKAHHDNNGHBCJKIDF = null;
                    bool flag4 = this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI != null;
                    if (flag4)
                    {
                        this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "Incomplete references to " + this.KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI._AYM();
                    }
                    else
                    {
                        bool flag5 = base.titleContent.text != "Replace";
                        if (flag5)
                        {
                            this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "Incomplete find results for '" + this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG + "'";
                        }
                        else
                        {
                            bool flag6 = base.titleContent.text != "Rename";
                            if (flag6)
                            {
                                this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = string.Concat(new string[]
                                {
                                    "Incomplete search for Replace '",
                                    this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG,
                                    "' to '",
                                    this._AVV,
                                    "'"
                                });
                            }
                            else
                            {
                                this.PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = string.Concat(new string[]
                                {
                                    "Incomplete search for Rename '",
                                    this.HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI._ABG,
                                    "' to '",
                                    this._AVV,
                                    "'"
                                });
                            }
                        }
                    }
                    this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO = this.IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO > 0;
                }
                rect.x = 46f;
                rect.width = base.position.width;
            }
            else
            {
                rect.x = 10f;
                rect.width = base.position.width;
            }
            GUI.Label(rect, this.BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF);
            rect.y = 0f;
            GUI.enabled = this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;
            bool flag7 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
            if (flag7)
            {
                rect.width = num;
                bool flag8 = this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Count != 0 && this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Count != this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL;
                if (flag8)
                {
                    bool flag9 = this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO != SymbolKind.None || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO > SymbolKind.None);
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
                    bool flag10 = this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO != SymbolKind.None || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO > SymbolKind.None);
                    if (flag10)
                    {
                        rect.x = base.position.width - 4.25f * num + 1f;
                    }
                    else
                    {
                        rect.x = base.position.width - 3f * num + 1f;
                    }
                }
                bool flag11 = this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Count != 0 && GUI.Button(rect, new GUIContent(_bk5.JDOPNFHIMOEPCHNKNFIBGNHDOHMFHJBJPNPE, "Expand All"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
                if (flag11)
                {
                    this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Clear();
                    this._CIL = true;
                    this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
                }
                bool flag12 = this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO != SymbolKind.None || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO > SymbolKind.None);
                if (flag12)
                {
                    rect.x = base.position.width - 4.25f * num + 1f;
                }
                else
                {
                    rect.x = base.position.width - 3f * num + 1f;
                }
                bool flag13 = this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Count != this.IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL && GUI.Button(rect, new GUIContent(_bk5.GIIMBFLDGJKPDBOBDLJFLDMHCEINMPCJFNAJ, "Collapse All"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
                if (flag13)
                {
                    foreach (_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan in this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF)
                    {
                        bool flag14 = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                        if (flag14)
                        {
                            bool flag15 = !this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(iobcmjadenalgemehnfhliaillknadbhioan._AMO);
                            if (flag15)
                            {
                                this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Add(iobcmjadenalgemehnfhliaillknadbhioan._AMO);
                            }
                        }
                    }
                    this._CIL = true;
                    this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
                }
            }
            GUI.enabled = true;
            bool flag16 = this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO != SymbolKind.None || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO > SymbolKind.None);
            if (flag16)
            {
                GUIContent guicontent = new GUIContent(_bk5.MMCDDHCLAFDONNAEGKKAMPCHIPKEGFLOKKNJ, "List Filters");
                rect.width = 1.25f * num;
                rect.x = base.position.width - 3.25f * num + 1f;
                bool flag17 = EditorGUI.DropdownButton(rect, guicontent, (FocusType)2, EditorStyles.toolbarPopup);
                if (flag17)
                {
                    GenericMenu genericMenu = new GenericMenu();
                    bool flag18 = this.CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI);
                    if (flag18)
                    {
                        genericMenu.AddItem(new GUIContent("Read"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB, delegate
                        {
                            this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB;
                            this.UpdateFilters();
                        });
                        genericMenu.AddItem(new GUIContent("Write"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG, delegate
                        {
                            this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG;
                            this.UpdateFilters();
                        });
                    }
                    else
                    {
                        bool flag19 = this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO == SymbolKind.Method || this.AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO == SymbolKind.MethodGroup || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO == SymbolKind.Method) || (this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK.Count > 0 && this.CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK[0].AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO == SymbolKind.MethodGroup);
                        if (flag19)
                        {
                            genericMenu.AddItem(new GUIContent("References"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB, delegate
                            {
                                this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB;
                                this.UpdateFilters();
                            });
                            genericMenu.AddItem(new GUIContent("Overload"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN, delegate
                            {
                                this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN;
                                this.UpdateFilters();
                            });
                            genericMenu.AddItem(new GUIContent("Overridden"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DJDCLJAEKIMKHHEMBLNCJMHHECCJNIOAFFAN, delegate
                            {
                                this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DJDCLJAEKIMKHHEMBLNCJMHHECCJNIOAFFAN = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DJDCLJAEKIMKHHEMBLNCJMHHECCJNIOAFFAN;
                                this.UpdateFilters();
                            });
                            genericMenu.AddItem(new GUIContent("Overriding"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LHENAJONEMNBCMPLOFPIEACFPMMNJPPBCPBL, delegate
                            {
                                this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LHENAJONEMNBCMPLOFPIEACFPMMNJPPBCPBL = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LHENAJONEMNBCMPLOFPIEACFPMMNJPPBCPBL;
                                this.UpdateFilters();
                            });
                        }
                        else
                        {
                            genericMenu.AddItem(new GUIContent("References"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB, delegate
                            {
                                this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB;
                                this.UpdateFilters();
                            });
                            bool gfcfeckgdmoolinnbenjlahknfbhmbmmmhdb = this.GFCFECKGDMOOLINNBENJLAHKNFBHMBMMMHDB;
                            if (gfcfeckgdmoolinnbenjlahknfbhmbmmmhdb)
                            {
                                genericMenu.AddItem(new GUIContent("Var"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ, delegate
                                {
                                    this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ;
                                    this.UpdateFilters();
                                });
                                genericMenu.AddItem(new GUIContent("Var<T>"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN, delegate
                                {
                                    this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN;
                                    this.UpdateFilters();
                                });
                            }
                        }
                    }
                    genericMenu.AddItem(new GUIContent("#if"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.IFGBHIENCIHHNDDDHJDCDNGLOEMBPLELKBKG, delegate
                    {
                        this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.IFGBHIENCIHHNDDDHJDCDNGLOEMBPLELKBKG = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.IFGBHIENCIHHNDDDHJDCDNGLOEMBPLELKBKG;
                        this.UpdateFilters();
                    });
                    genericMenu.AddItem(new GUIContent("String"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.FCAKBOGNALCBCLCDDEMIMHNPPEIAGLDGNOIC, delegate
                    {
                        this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.FCAKBOGNALCBCLCDDEMIMHNPPEIAGLDGNOIC = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.FCAKBOGNALCBCLCDDEMIMHNPPEIAGLDGNOIC;
                        this.UpdateFilters();
                    });
                    genericMenu.AddItem(new GUIContent("Comment"), this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.AMGPPANKBBMOFJBOEPECEPHNFHIIDAADJAMP, delegate
                    {
                        this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.AMGPPANKBBMOFJBOEPECEPHNFHIIDAADJAMP = !this.NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP.AMGPPANKBBMOFJBOEPECEPHNFHIIDAADJAMP;
                        this.UpdateFilters();
                    });
                    genericMenu.ShowAsContext();
                }
            }
            GUI.enabled = this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;
            rect.width = num;
            rect.x = base.position.width - 2f * num + 1f;
            bool flag20 = GUI.Toggle(rect, this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL(), new GUIContent(_bk5.AGLHFAKCNBPCDFDPAPHOKIFMJMBKMNGNEFDA, "Group by file"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
            GUI.enabled = true;
            rect.width = num;
            rect.x = base.position.width - num + 1f;
            bool flag21 = base.titleContent.text == "Replace";
            if (flag21)
            {
                GUI.enabled = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count == 0 && this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;
                bool flag22 = GUI.Toggle(rect, false, new GUIContent(_bk5.ALOEFJKKLIKBILEHIFCLFFEFLHPAPLKFEECC, "Replace all selected"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
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
                    GUI.enabled = this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count == 0 && this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;
                    bool flag24 = GUI.Toggle(rect, false, new GUIContent(_bk5.ALOEFJKKLIKBILEHIFCLFFEFLHPAPLKFEECC, "Rename all"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
                    if (flag24)
                    {
                        this.ReplaceAll(true);
                    }
                    GUI.enabled = true;
                }
                else
                {
                    GUI.enabled = this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;
                    this.KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG = GUI.Toggle(rect, this.KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG, new GUIContent(_bk5.HHGCJOCHLBGIINKOOAHBGOOPCPGDIIMKAMMJ, "Pin results window"), _bk5.CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK);
                    GUI.enabled = true;
                }
            }
            GUILayout.EndHorizontal();
            bool flag25 = flag20 != this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
            if (flag25)
            {
                _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan2 = ((this._ADS < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count) ? this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS] : null);
                bool flag26 = iobcmjadenalgemehnfhliaillknadbhioan2 != null && iobcmjadenalgemehnfhliaillknadbhioan2.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                if (flag26)
                {
                    iobcmjadenalgemehnfhliaillknadbhioan2 = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[this._ADS + 1];
                }
                this.LDMGGPLFEICIBLAPIIHKEPPPJMMONMLHJKFO(flag20);
                this.UpdateFilters();
                bool flag27 = iobcmjadenalgemehnfhliaillknadbhioan2 != null;
                if (flag27)
                {
                    this._ADS = Mathf.Max(0, this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.IndexOf(iobcmjadenalgemehnfhliaillknadbhioan2));
                }
                else
                {
                    this._ADS = 0;
                }
                this._CIL = true;
                this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
                this.KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ = true;
            }
            Rect rect2 = new Rect(0f, 20f, EditorGUIUtility.currentViewWidth, 1f);
            Color color = (EditorGUIUtility.isProSkin ? new Color(0f, 0f, 0f, 0.35f) : new Color(0f, 0f, 0f, 0.25f));
            EditorGUI.DrawRect(rect2, color);
            bool flag28 = Event.current.type == EventType.Repaint && this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count > 0;
            if (flag28)
            {
                float num2 = ((float)this.MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK + 1f + (float)this.EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH.Count) / (float)this.JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD.Count;
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
            this.OGCAAFGPNCHFLOBHGHIBIBNDBPDGPMNMBFAP = base.position.height - 20f;
        }

        // Token: 0x06000100 RID: 256 RVA: 0x0000ECA0 File Offset: 0x0000CEA0
        private void OnGUI()
        {
            this.OnGUIKey();
            this.OnGUIToolbar();
            GUILayout.Space(20f);
            this._AFS = GUILayout.BeginScrollView(this._AFS, _bk5.APCOLHPBENJNHPBBCDJMDIEIDJNBGIACLFHB);
            Vector2 nldklbhokblieldlieapikhkmafeieikcnej = this._AFS;
            EditorGUIUtility.SetIconSize(new Vector2(16f, 16f));
            bool flag = !this.IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;
            if (flag)
            {
                GUILayout.Label("No Results...", Array.Empty<GUILayoutOption>());
            }
            else
            {
                bool flag2 = true;
                int num = 0;
                for (int i = 0; i < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count; i++)
                {
                    _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[i];
                    bool flag3 = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null && !flag2;
                    if (!flag3)
                    {
                        GUIStyle guistyle = (((num & 1) == 0) ? _bk5.ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB : _bk5.NLHGNOONBNJBGNDJKIHEBJPBNABHBONANLPE);
                        num++;
                        Rect rect = GUILayoutUtility.GetRect(GUIContent.none, guistyle, _bk5.INOKGCJHKHFHOCCBGNAGIOJDICPEJKBCAHCK);
                        rect.xMin = 0f;
                        bool flag4 = Event.current.type == EventType.Repaint;
                        if (flag4)
                        {
                            guistyle.Draw(rect, GUIContent.none, false, false, i == this._ADS, this == EditorWindow.focusedWindow);
                        }
                        bool flag5 = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                        if (flag5)
                        {
                            string gbcbidoiiiaefjkdnpijonchckjlgpnjklfd = iobcmjadenalgemehnfhliaillknadbhioan._AMO;
                            flag2 = !this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
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
                                    this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Remove(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
                                }
                                else
                                {
                                    bool flag9 = !flag6 && flag2;
                                    if (flag9)
                                    {
                                        this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Add(gbcbidoiiiaefjkdnpijonchckjlgpnjklfd);
                                    }
                                }
                                this._CIL = true;
                                this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
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
                                while (num2 < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count && (!flag11 || !flag12))
                                {
                                    _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan2 = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[num2];
                                    bool flag13 = iobcmjadenalgemehnfhliaillknadbhioan2.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                                    if (flag13)
                                    {
                                        break;
                                    }
                                    bool mhpgiflnijdjgfmhekahkanhpbbifkoelhfd = iobcmjadenalgemehnfhliaillknadbhioan2._BCL;
                                    if (mhpgiflnijdjgfmhekahkanhpbbifkoelhfd)
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
                                bool flag15 = flag14 != GUI.Toggle(rect2, flag14, GUIContent.none, (flag11 && flag12) ? _bk5.PCNMLIIMDPLNLDAJDPGCGLONAEBJGCJCIHHL : EditorStyles.toggle);
                                if (flag15)
                                {
                                    flag14 = !flag14;
                                    for (int j = i + 1; j < this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF.Count; j++)
                                    {
                                        _bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN iobcmjadenalgemehnfhliaillknadbhioan3 = this.INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF[j];
                                        bool flag16 = iobcmjadenalgemehnfhliaillknadbhioan3.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                                        if (flag16)
                                        {
                                            break;
                                        }
                                        iobcmjadenalgemehnfhliaillknadbhioan3._BCL = flag14;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool flag17 = base.titleContent.text == "Replace";
                            if (flag17)
                            {
                                bool flag18 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
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
                                iobcmjadenalgemehnfhliaillknadbhioan._BCL = GUI.Toggle(rect3, iobcmjadenalgemehnfhliaillknadbhioan._BCL, GUIContent.none);
                            }
                        }
                        bool flag19 = this.KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ && i == this._ADS && Event.current.type == EventType.Repaint;
                        if (flag19)
                        {
                            bool flag20 = rect.yMin < this._AFS.y;
                            if (flag20)
                            {
                                nldklbhokblieldlieapikhkmafeieikcnej.y = rect.yMin;
                                this._CIL = true;
                            }
                            else
                            {
                                bool flag21 = rect.yMax > this._AFS.y + this.OGCAAFGPNCHFLOBHGHIBIBNDBPDGPMNMBFAP;
                                if (flag21)
                                {
                                    nldklbhokblieldlieapikhkmafeieikcnej.y = rect.yMax - this.OGCAAFGPNCHFLOBHGHIBIBNDBPDGPMNMBFAP + 20f;
                                    this._CIL = true;
                                }
                            }
                        }
                        bool flag22 = rect.yMax < this._AFS.y || rect.yMin > this._AFS.y + this.OGCAAFGPNCHFLOBHGHIBIBNDBPDGPMNMBFAP;
                        if (!flag22)
                        {
                            bool flag23 = rect.Contains(Event.current.mousePosition);
                            if (flag23)
                            {
                                bool flag24 = Event.current.button == 0 && (Event.current.clickCount == 1 || Event.current.clickCount == 2);
                                if (flag24)
                                {
                                    bool flag25 = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                                    if (flag25)
                                    {
                                        bool flag26 = Event.current.clickCount == 2;
                                        if (flag26)
                                        {
                                            bool flag27 = this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Contains(iobcmjadenalgemehnfhliaillknadbhioan._AMO);
                                            if (flag27)
                                            {
                                                this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Remove(iobcmjadenalgemehnfhliaillknadbhioan._AMO);
                                            }
                                            else
                                            {
                                                this.GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO.Add(iobcmjadenalgemehnfhliaillknadbhioan._AMO);
                                            }
                                            this._CIL = true;
                                            this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;
                                        }
                                    }
                                    else
                                    {
                                        bool flag28 = Event.current.clickCount == 2;
                                        if (flag28)
                                        {
                                            _bb6.OpenAssetInTab(iobcmjadenalgemehnfhliaillknadbhioan._ADF, iobcmjadenalgemehnfhliaillknadbhioan._ABI, iobcmjadenalgemehnfhliaillknadbhioan._AEU, iobcmjadenalgemehnfhliaillknadbhioan.MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG, true);
                                        }
                                        else
                                        {
                                            _bb6.OpenAssetInTab(iobcmjadenalgemehnfhliaillknadbhioan._ADF, iobcmjadenalgemehnfhliaillknadbhioan._ABI, iobcmjadenalgemehnfhliaillknadbhioan._AEU, iobcmjadenalgemehnfhliaillknadbhioan.MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG, !_bg8.EAIK.GNIO());
                                            base.Focus();
                                        }
                                    }
                                }
                                this._ADS = i;
                                this._CIL = true;
                                this.KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ = true;
                                Event.current.Use();
                            }
                            int num3 = 0;
                            bool flag29 = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO == null;
                            GUIContent guicontent;
                            if (flag29)
                            {
                                guicontent = new GUIContent(iobcmjadenalgemehnfhliaillknadbhioan._AMO, AssetDatabase.GetCachedIcon(iobcmjadenalgemehnfhliaillknadbhioan._AMO));
                                rect.xMin += 16f;
                            }
                            else
                            {
                                bool flag30 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                                string text;
                                if (flag30)
                                {
                                    text = (iobcmjadenalgemehnfhliaillknadbhioan._ABI + 1).ToString() + ":   ";
                                }
                                else
                                {
                                    text = iobcmjadenalgemehnfhliaillknadbhioan._BDK + " (" + (iobcmjadenalgemehnfhliaillknadbhioan._ABI + 1).ToString() + "):   ";
                                }
                                num3 = text.Length;
                                guicontent = new GUIContent(text + iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO);
                                bool flag31 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
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
                                bool flag34 = iobcmjadenalgemehnfhliaillknadbhioan.JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO != null;
                                if (flag34)
                                {
                                    bool flag35 = iobcmjadenalgemehnfhliaillknadbhioan.OIFGAJHBBOJODCCNKLHBPPOHMNNDNMCFPFJD.width == 0f;
                                    if (flag35)
                                    {
                                        GUIContent guicontent2 = new GUIContent(".");
                                        GUIContent guicontent3 = new GUIContent(guicontent.text.Substring(0, num3 + iobcmjadenalgemehnfhliaillknadbhioan._AEU - iobcmjadenalgemehnfhliaillknadbhioan.LNGFNEJGOEBIFOOBCKPMGIMJHMKMNBAJFMNF) + ".");
                                        GUIContent guicontent4 = new GUIContent("." + guicontent.text.Substring(0, num3 + iobcmjadenalgemehnfhliaillknadbhioan._AEU + iobcmjadenalgemehnfhliaillknadbhioan.MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG - iobcmjadenalgemehnfhliaillknadbhioan.LNGFNEJGOEBIFOOBCKPMGIMJHMKMNBAJFMNF) + ".");
                                        Vector2 vector = guistyle.CalcSize(guicontent2);
                                        Vector2 vector2 = guistyle.CalcSize(guicontent3);
                                        vector2.x -= vector.x;
                                        Vector2 vector3 = guistyle.CalcSize(guicontent4);
                                        vector3.x -= vector.x * 2f;
                                        iobcmjadenalgemehnfhliaillknadbhioan.OIFGAJHBBOJODCCNKLHBPPOHMNNDNMCFPFJD = new Rect(vector2.x - 4f, 2f, vector3.x - vector2.x + 14f, rect.height - 4f);
                                    }
                                    Rect oifgajhbbojodccnklhbppohmnndnmcfpfjd = iobcmjadenalgemehnfhliaillknadbhioan.OIFGAJHBBOJODCCNKLHBPPOHMNNDNMCFPFJD;
                                    oifgajhbbojodccnklhbppohmnndnmcfpfjd.x += rect.x;
                                    oifgajhbbojodccnklhbppohmnndnmcfpfjd.y += rect.y;
                                    GUI.color = new Color(1f, 1f, 1f, 0.4f);
                                    Color backgroundColor = GUI.backgroundColor;
                                    bool flag36 = iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)3;
                                    if (flag36)
                                    {
                                        GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(14, 69, 131, 162) : new Color32(160, byte.MaxValue, byte.MaxValue, byte.MaxValue));
                                        _bk5.CIFMDOEMJOFLMKNNCIBJHJKECJBBHIMIHODF.Draw(oifgajhbbojodccnklhbppohmnndnmcfpfjd, false, false, false, false);
                                    }
                                    else
                                    {
                                        bool flag37 = iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)2 || iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)4 || iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)5;
                                        if (flag37)
                                        {
                                            GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(131, 14, 69, 162) : new Color32(byte.MaxValue, 160, 160, byte.MaxValue));
                                            _bk5.CIFMDOEMJOFLMKNNCIBJHJKECJBBHIMIHODF.Draw(oifgajhbbojodccnklhbppohmnndnmcfpfjd, false, false, false, false);
                                        }
                                        else
                                        {
                                            bool flag38 = iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)8 || iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)9 || iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)7 || iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)6;
                                            if (flag38)
                                            {
                                                bool flag39 = iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)8 || iobcmjadenalgemehnfhliaillknadbhioan.ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM == (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)7;
                                                if (flag39)
                                                {
                                                    GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(14, 131, 69, 162) : new Color32(160, byte.MaxValue, 160, byte.MaxValue));
                                                }
                                                else
                                                {
                                                    GUI.backgroundColor = (EditorGUIUtility.isProSkin ? new Color32(131, 69, 131, 162) : new Color32(byte.MaxValue, 160, byte.MaxValue, byte.MaxValue));
                                                }
                                                _bk5.CIFMDOEMJOFLMKNNCIBJHJKECJBBHIMIHODF.Draw(oifgajhbbojodccnklhbppohmnndnmcfpfjd, false, false, false, false);
                                            }
                                            else
                                            {
                                                _bk5.KJGFPGANEBLIMMAEFLMJAJCMJCDGDCOADNCA.Draw(oifgajhbbojodccnklhbppohmnndnmcfpfjd, false, false, false, false);
                                            }
                                        }
                                    }
                                    GUI.backgroundColor = backgroundColor;
                                    GUI.color = Color.white;
                                }
                                GUI.backgroundColor = Color.clear;
                                guistyle.Draw(rect, guicontent, false, false, i == this._ADS, this == EditorWindow.focusedWindow);
                                GUI.backgroundColor = Color.white;
                                bool flag40 = guistyle.CalcSize(guicontent).x > this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ;
                                if (flag40)
                                {
                                    this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = guistyle.CalcSize(guicontent).x;
                                }
                            }
                        }
                    }
                }
            }
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag41 = this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ != 0f && Event.current.type == EventType.Layout;
            if (flag41)
            {
                bool flag42 = base.titleContent.text == "Replace";
                if (flag42)
                {
                    bool flag43 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                    if (flag43)
                    {
                        GUILayout.Space(this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ + 20f + 36f);
                    }
                    else
                    {
                        GUILayout.Space(this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ + 20f + 4f);
                    }
                }
                else
                {
                    bool flag44 = this.GGLJIKLNPIIBNJICDPHDKINJAPEKABDBBGOL();
                    if (flag44)
                    {
                        GUILayout.Space(this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ + 20f);
                    }
                    else
                    {
                        GUILayout.Space(this.HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ + 2f);
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
                    this._AFS = nldklbhokblieldlieapikhkmafeieikcnej;
                    this._CIL = false;
                    base.Repaint();
                }
                this.KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ = false;
            }
        }

        // Token: 0x040000DF RID: 223
        internal bool CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI;

        // Token: 0x040000E0 RID: 224
        internal bool GFCFECKGDMOOLINNBENJLAHKNFBHMBMMMHDB;

        // Token: 0x040000E1 RID: 225
        internal bool ANAFOPMKLEICDAGPAABKGGMCDLCFLAAGCPEF;

        // Token: 0x040000E2 RID: 226
        internal SymbolKind AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO;

        // Token: 0x040000E3 RID: 227
        private static GUIStyle ACDDLHCIBHMMAOGJNNNCNDKMJJJKIFIOCLDB;

        // Token: 0x040000E4 RID: 228
        private static GUIStyle NLHGNOONBNJBGNDJKIHEBJPBNABHBONANLPE;

        // Token: 0x040000E5 RID: 229
        private static GUIStyle KJGFPGANEBLIMMAEFLMJAJCMJCDGDCOADNCA;

        // Token: 0x040000E6 RID: 230
        private static GUIStyle CIFMDOEMJOFLMKNNCIBJHJKECJBBHIMIHODF;

        // Token: 0x040000E7 RID: 231
        private static GUIStyle PCNMLIIMDPLNLDAJDPGCGLONAEBJGCJCIHHL;

        // Token: 0x040000E8 RID: 232
        private static GUIStyle CGEJNOLPKMAFIAIMIMFFOBCCBIEEOHKPKOMK;

        // Token: 0x040000E9 RID: 233
        private static readonly GUILayoutOption[] APCOLHPBENJNHPBBCDJMDIEIDJNBGIACLFHB = new GUILayoutOption[]
        {
            GUILayout.ExpandWidth(true),
            GUILayout.ExpandHeight(true)
        };

        // Token: 0x040000EA RID: 234
        private static readonly GUILayoutOption[] INOKGCJHKHFHOCCBGNAGIOJDICPEJKBCAHCK = new GUILayoutOption[]
        {
            GUILayout.Height(21f),
            GUILayout.ExpandWidth(true)
        };

        // Token: 0x040000EB RID: 235
        private static readonly GUILayoutOption[] PPOGAAFFILGLFHFFIBBOAOHNPBLKJFMLKDEO = new GUILayoutOption[] { GUILayout.MaxWidth(26f) };

        // Token: 0x040000EC RID: 236
        private static readonly GUILayoutOption[] AAGJMMHCIIIKPBJDPAHBNDMDLMFNJJCILNDM = new GUILayoutOption[]
        {
            GUILayout.Height(20f),
            GUILayout.MinWidth(0f)
        };

        // Token: 0x040000ED RID: 237
        private static readonly GUILayoutOption[] PHEBEKCMBFKOEEBJOABNPFIBFNPDLPKCAAPE = new GUILayoutOption[] { GUILayout.Height(16f) };

        // Token: 0x040000EE RID: 238
        [SerializeField]
        private string PBJKEHFMAEDFLOEDBIHFILFMFLIEJCCAKIDB = "";

        // Token: 0x040000EF RID: 239
        [SerializeField]
        private string BPEJGAPOKBLMJHKHLEILECFEEMLOMJAPFIJF = "Found 0 result.";

        // Token: 0x040000F0 RID: 240
        private Action<Action<string, string, TextPosition, int>, string, _bk5._AZL> PFPDHFOCDMGHDLBGKIEIKGEHNDNOGBPEFCOL;

        // Token: 0x040000F1 RID: 241
        private _bk5.ONEILDCAMHIOCHJBHGPGBFLIDNIFNKFCIGAD FGEBPBBLGHOBKAEMFDHLMGKGHFLFEHPJCJAK;

        // Token: 0x040000F2 RID: 242
        private _bk5.EIJNJHPLNPFJGGJHJPGEMFCMHALBIIFBBOEI ACCCDMNKMKPLNNIGMFMPJHJPIILMAKOCOKNL;

        // Token: 0x040000F3 RID: 243
        private _bh4 KIPCELLILEOPBCIHDGBJHPKJENMNPHIOAMFI;

        // Token: 0x040000F4 RID: 244
        [SerializeField]
        private string HDKBPKMMOKIEDNFEJGAEGBENPLGFECGDIHFH = "";

        // Token: 0x040000F5 RID: 245
        [SerializeField]
        private List<string> JIIOHDOBNLKGCMANELJKKPBPDDAAJCAICHKD = new List<string>();

        // Token: 0x040000F6 RID: 246
        [SerializeField]
        private List<string> EJCBEHODBLENOJPKNNCCEKJEGJGFADAIGCAH = new List<string>();

        // Token: 0x040000F7 RID: 247
        [SerializeField]
        private _bk5._AZL HOODILDNBDEKENCHKOGCHAIOEMBGGGILALEI = new _bk5._AZL
        {
            _ABG = ""
        };

        // Token: 0x040000F8 RID: 248
        [SerializeField]
        private _bk5.OLICOJKMCLBLLGDNHPLEFMBEBCBOMOGCCFMG NKKFPMHMIGHOECDBNDLEKBFADDCBNMCHIOFP;

        // Token: 0x040000F9 RID: 249
        [SerializeField]
        private bool IDEHIGMIKJKIIJKHNBDCDOECMAINMEIFLENO;

        // Token: 0x040000FA RID: 250
        [NonSerialized]
        private int MCMFONFOECBBJCKIHIGBIHNLNGBDHLBBOMHK;

        // Token: 0x040000FB RID: 251
        [NonSerialized]
        private bool JCMLMBHKNGPHMBCGCJIDKKBNCAOGCOCEEKDI;

        // Token: 0x040000FC RID: 252
        [SerializeField]
        private Vector2 _AFS;

        // Token: 0x040000FD RID: 253
        [SerializeField]
        private int _ADS = 0;

        // Token: 0x040000FE RID: 254
        [NonSerialized]
        private bool KAPJGFDEIKMIJMLLNOLBIHAANHPKDKOMOOCJ;

        // Token: 0x040000FF RID: 255
        [NonSerialized]
        private float OGCAAFGPNCHFLOBHGHIBIBNDBPDGPMNMBFAP;

        // Token: 0x04000100 RID: 256
        private float HBKBKBFLOLLHNJEEENKFBBJIJCHBKDIKHPLJ = 0f;

        // Token: 0x04000101 RID: 257
        [NonSerialized]
        private List<_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN> INDMMEFLDEAJFFMAPKOLJLKJAHCADMBCOHIF = new List<_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN>();

        // Token: 0x04000102 RID: 258
        [SerializeField]
        private List<_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN> CHGLLHDHGAAPGDJBPJOHHENNDPNCHLJCNLHK = new List<_bk5.IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN>();

        // Token: 0x04000103 RID: 259
        [SerializeField]
        private int IMJMLGAHKFGIFFOOFNDGNPJJJLKBIOHPFPHO;

        // Token: 0x04000104 RID: 260
        [SerializeField]
        private int IKPKLNEGBIAIHOILDJKALBPLAIDHKGDOBAGL;

        // Token: 0x04000105 RID: 261
        [SerializeField]
        private List<string> GHCCHOEHPHPEAFDECNFLPKBJPJBJGINJGFEO = new List<string>();

        // Token: 0x04000106 RID: 262
        [SerializeField]
        private bool KGOOJEEMCGLKBPACKEKMIBNJPMOBEECBJOBG;

        // Token: 0x04000107 RID: 263
        [SerializeField]
        private bool IEAFHEIADBPDLHOICBNABMGPIJIFJBPONCEG;

        // Token: 0x04000108 RID: 264
        private bool OBOGDFNCHADCHGBLOPIFAABDCGBKPFDDMGMA;

        // Token: 0x04000109 RID: 265
        [SerializeField]
        private string _AVV = "";

        // Token: 0x0400010A RID: 266
        [NonSerialized]
        private bool NAGHPOFOPMEFEJGNHKEJPGMIEPMNPPLDHGOJ;

        // Token: 0x0400010B RID: 267
        [NonSerialized]
        private EditorWindow DMMNGGPAMAPFEKGELANHKAHHDNNGHBCJKIDF;

        // Token: 0x0400010C RID: 268
        private static Texture2D MMCDDHCLAFDONNAEGKKAMPCHIPKEGFLOKKNJ;

        // Token: 0x0400010D RID: 269
        private static Texture2D AGLHFAKCNBPCDFDPAPHOKIFMJMBKMNGNEFDA;

        // Token: 0x0400010E RID: 270
        private static Texture2D ALOEFJKKLIKBILEHIFCLFFEFLHPAPLKFEECC;

        // Token: 0x0400010F RID: 271
        private static Texture2D HHGCJOCHLBGIINKOOAHBGOOPCPGDIIMKAMMJ;

        // Token: 0x04000110 RID: 272
        private static Texture2D PKGBCHECOFFCCDOJHGBBAHPEBJBPIKNKBPIP;

        // Token: 0x04000111 RID: 273
        private static Texture2D JDOPNFHIMOEPCHNKNFIBGNHDOHMFHJBJPNPE;

        // Token: 0x04000112 RID: 274
        private static Texture2D GIIMBFLDGJKPDBOBDLJFLDMHCEINMPCJFNAJ;

        // Token: 0x04000113 RID: 275
        private static Texture2D _CEH;

        // Token: 0x04000114 RID: 276
        private static HashSet<_bk5> LIFGLGAGLDPMAMGNJMKMKELAEEALICEFJLGL = new HashSet<_bk5>();

        // Token: 0x04000115 RID: 277
        private static int NLMCPMFNKKMCNFOAGAJBILLOLNNDELPCJOEG = 0;

        // Token: 0x04000116 RID: 278
        private static int JLJAHPNMHNJFEDCLDBEEFLOEPOLOGKPAFKBI = 0;

        // Token: 0x04000117 RID: 279
        private bool _CIL = false;

        // Token: 0x0200001F RID: 31
        public enum BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK
        {

        }

        // Token: 0x02000020 RID: 32
        [Serializable]
        internal class _AZL
        {
            // Token: 0x04000119 RID: 281
            public string _ABG;

            // Token: 0x0400011A RID: 282
            public string ADFICBDCAFGKMIJLIPIODEIIEIDNJMDGIJFJ;

            // Token: 0x0400011B RID: 283
            public string EIFANAJKPEMGMDMGCIMKIEMEBINHJOFDNKAM;

            // Token: 0x0400011C RID: 284
            public bool _AYS;

            // Token: 0x0400011D RID: 285
            public bool _AZN;
        }

        // Token: 0x02000021 RID: 33
        [Serializable]
        internal class OLICOJKMCLBLLGDNHPLEFMBEBCBOMOGCCFMG
        {
            // Token: 0x0400011E RID: 286
            public bool CCFOPFEAFBGMEDANGDNPFJDFLHPNKEGJBICG;

            // Token: 0x0400011F RID: 287
            public bool LOEOKPCGHJFOJGLBCEJOAMEJODLGLGNEKFPB;

            // Token: 0x04000120 RID: 288
            public bool EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN;

            // Token: 0x04000121 RID: 289
            public bool LHENAJONEMNBCMPLOFPIEACFPMMNJPPBCPBL;

            // Token: 0x04000122 RID: 290
            public bool DJDCLJAEKIMKHHEMBLNCJMHHECCJNIOAFFAN;

            // Token: 0x04000123 RID: 291
            public bool DHJMJFACJBJGABBDEHMIDCEIHGLCDDAJFGOJ;

            // Token: 0x04000124 RID: 292
            public bool PHBBCPPEIHCLJPKHIOANCGJFAFILGPMBKJAN;

            // Token: 0x04000125 RID: 293
            public bool PEDKJJOBBCANDKHAKPGFBOOGMDIKMNFBPNJJ;

            // Token: 0x04000126 RID: 294
            public bool IFGBHIENCIHHNDDDHJDCDNGLOEMBPLELKBKG;

            // Token: 0x04000127 RID: 295
            public bool FCAKBOGNALCBCLCDDEMIMHNPPEIAGLDGNOIC;

            // Token: 0x04000128 RID: 296
            public bool AMGPPANKBBMOFJBOEPECEPHNFHIIDAADJAMP;

            // Token: 0x04000129 RID: 297
            public bool FILMHPLDEBEFKFIALNEDOIFFHNFNPOCMIANI;

            // Token: 0x0400012A RID: 298
            public bool DPEMBCFJFEONMONFGFCJJBBEHDKFPJAEPFNJ;

            // Token: 0x0400012B RID: 299
            public bool NBPNKNDFNIPKOLLALEOOIMBKKCNKKCICIPLE;

            // Token: 0x0400012C RID: 300
            public bool _AIC;
        }

        // Token: 0x02000022 RID: 34
        [Serializable]
        private class IOBCMJADENALGEMEHNFHLIAILLKNADBHIOAN
        {
            // Token: 0x0400012D RID: 301
            public bool CLPKGDLBDBALMFKNBLCKFFKAODBMFPKKFIAI;

            // Token: 0x0400012E RID: 302
            public bool GFCFECKGDMOOLINNBENJLAHKNFBHMBMMMHDB;

            // Token: 0x0400012F RID: 303
            public SymbolKind AHPNBMHMGHAGBIACCPAIHHNFLHLOBOLBEKOO;

            // Token: 0x04000130 RID: 304
            public string JKFAOBNFIELFFJCAMDHLEKPEMKBBHAHNHBCO;

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
            public int MOHFHIMMMECKHLGAMKNAKDDDMLPINFDIPFCG;

            // Token: 0x04000137 RID: 311
            public int LNGFNEJGOEBIFOOBCKPMGIMJHMKMNBAJFMNF;

            // Token: 0x04000138 RID: 312
            public bool _BCL;

            // Token: 0x04000139 RID: 313
            public _bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK ONHCMOCHMDLDEFEIODAKCLHNAOIAEOELFNMM;

            // Token: 0x0400013A RID: 314
            public Rect OIFGAJHBBOJODCCNKLHBPPOHMNNDNMCFPFJD;
        }

        // Token: 0x02000023 RID: 35
        // (Invoke) Token: 0x06000116 RID: 278
        public delegate _bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK ONEILDCAMHIOCHJBHGPGBFLIDNIFNKFCIGAD(string guid, TextPosition location, int length, ref _bh4 referencedSymbol);

        // Token: 0x02000024 RID: 36
        // (Invoke) Token: 0x0600011A RID: 282
        public delegate bool EIJNJHPLNPFJGGJHJPGEMFCMHALBIIFBBOEI(string guid, _bk5.OLICOJKMCLBLLGDNHPLEFMBEBCBOMOGCCFMG options);
    }
}
