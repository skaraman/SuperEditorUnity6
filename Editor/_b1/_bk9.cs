using System;
using System.Collections.Generic;
using System.Xml;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000019 RID: 25
    internal class _bk9 : _bm5
    {
        // Token: 0x060000C7 RID: 199 RVA: 0x00009FB4 File Offset: 0x000081B4
        public string _CKB()
        {
            return this.AHIMHNGEHPGDOJKDGBKPKBMNAOOLNPKFFHPB;
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x00009FCC File Offset: 0x000081CC
        private void FAIDBFHPLIAGICLHFOMFMNHDAIEJHLDEMPMC(string value)
        {
            this.AHIMHNGEHPGDOJKDGBKPKBMNAOOLNPKFFHPB = value;
            this.GBKBJAAHKMMBHBKFMNPBPFHGPDPMKHJGACJP = null;
        }

        // Token: 0x060000C9 RID: 201 RVA: 0x00009FE0 File Offset: 0x000081E0
        public void _CGI(int value)
        {
            bool flag = this.PIHEEHJKNFBBBKIBIFAALNDIHLOBJLBCIODA != value;
            if (flag)
            {
                this.PIHEEHJKNFBBBKIBIFAALNDIHLOBJLBCIODA = value;
                base.Repaint();
            }
        }

        // Token: 0x060000CA RID: 202 RVA: 0x0000A010 File Offset: 0x00008210
        internal static _bk9 CreateTokenWidget(_bi2 editor, Rect tokenRect, _bb4.DHBA leaf, bool horizontal = false)
        {
            _bk9 mojdbdaophnjeicpnaopeifioeflcmcfomhj = _bk9.Create(editor, tokenRect, leaf, horizontal, false, false);
            mojdbdaophnjeicpnaopeifioeflcmcfomhj.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK = false;
            return mojdbdaophnjeicpnaopeifioeflcmcfomhj;
        }

        // Token: 0x060000CB RID: 203 RVA: 0x0000A038 File Offset: 0x00008238
        internal static _bk9 Create(_bi2 editor, Rect tokenRect, _bb4.DHBA leaf, bool horizontal = false, bool showError = true, bool forListPopup = false)
        {
            string text = null;
            _bh4 symbolDefinition = leaf._AAB();
            _bh4[] array = null;
            int num = 0;
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            _bk9 window = _bm5.CreatePopup<_bk9>();
            bool flag = symbolDefinition != null;
            if (flag)
            {
                try
                {
                    _bi5 _AAE = symbolDefinition._AO as _bi5;
                    bool flag2 = symbolDefinition._AT == SymbolKind.MethodGroup;
                    if (flag2)
                    {
                        _ba7 _AAK = symbolDefinition as _ba7;
                        bool flag3 = _AAK == null;
                        if (flag3)
                        {
                            _bm7 _BFS = symbolDefinition as _bm7;
                            bool flag4 = _BFS != null;
                            if (flag4)
                            {
                                _ba7 _AAK2 = _BFS._CBS() as _ba7;
                                bool flag5 = _AAE != null;
                                if (flag5)
                                {
                                    symbolDefinition = _AAE.GetConstructedMember(_AAK2._AAM.FirstOrDefault<_bb3>());
                                }
                            }
                        }
                        bool flag6 = _AAK != null && _AAK._AAM != null;
                        if (flag6)
                        {
                            symbolDefinition = _AAK._AAM.FirstOrDefault<_bb3>() ?? symbolDefinition;
                        }
                    }
                    text = _bk9.GetTooltipText(symbolDefinition, leaf, editor, window);
                    bool flag7 = leaf.FindNextLeaf() != null && (leaf.FindNextLeaf()._ACX.text == "(" || leaf.FindNextLeaf()._ACX.text == "<") && (symbolDefinition._AT == SymbolKind.Class || symbolDefinition._AT == SymbolKind.Struct);
                    if (flag7)
                    {
                    }
                    _bh4 _AAH = symbolDefinition;
                    bool flag8 = _AAH._AO != null;
                    if (flag8)
                    {
                        bool flag9 = _AAH._AO._AT == SymbolKind.MethodGroup;
                        if (flag9)
                        {
                            _bd1 _ABB = _AAH._AO as _bd1;
                            _AAH = _ABB ?? _AAH._AO;
                        }
                        else
                        {
                            bool flag10 = _AAE != null;
                            if (flag10)
                            {
                                _bm7 _BFS2 = _AAH as _bm7;
                                _AAH = ((_BFS2 != null) ? (_BFS2._CBS()._AO as _ba7) : null);
                            }
                        }
                    }
                    bool flag11 = _AAH != null && _AAH._AT == SymbolKind.MethodGroup;
                    if (flag11)
                    {
                        _ba7 _AAK3 = _AAH as _ba7;
                        bool flag12 = _AAK3 != null && _AAK3._AAM.Count > 1;
                        if (flag12)
                        {
                            _bb3[] array2 = new _bb3[_AAK3._AAM.Count];
                            _bm6 _AQI = null;
                            for (_bb4._ACW _AGZ = leaf.OOME; _AGZ != null; _AGZ = _AGZ.OOME)
                            {
                                bool flag13 = _AGZ._AJW != null;
                                if (flag13)
                                {
                                    _AQI = _AGZ._AJW;
                                    break;
                                }
                            }
                            bool flag14 = _ba7._AHE.Count != 0;
                            if (flag14)
                            {
                                throw new IndexOutOfRangeException();
                            }
                            int num2 = _AAK3.CollectCandidates(-1, _AQI, null);
                            bool flag15 = num2 != 0;
                            if (flag15)
                            {
                                array2 = _ba7._AHE.ToArray();
                                _ba7._AHE.Clear();
                                bool flag16 = _AAE != null;
                                if (flag16)
                                {
                                    array = new _bh4[array2.Length];
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        array[i] = _AAE.GetConstructedMember(array2[i]);
                                    }
                                }
                                else
                                {
                                    _bh4[] array3 = array2;
                                    array = array3;
                                }
                                num = Array.IndexOf<_bh4>(array, symbolDefinition);
                                bool flag17 = num == -1;
                                if (flag17)
                                {
                                    num = Array.IndexOf<_bh4>(array, symbolDefinition.GetGenericSymbol());
                                }
                                num = Mathf.Clamp(num, 0, array.Length - 1);
                            }
                        }
                    }
                    bool flag18 = array == null && symbolDefinition._AT == SymbolKind.Method;
                    if (flag18)
                    {
                        array = new _bh4[] { symbolDefinition };
                        num = 0;
                    }
                }
                catch (Exception ex)
                {
                    text = ex.ToString();
                }
            }
            if (showError)
            {
                bool flag19 = leaf._AJB != null;
                if (flag19)
                {
                    text = leaf._AJB.GetErrorMessage();
                }
                else
                {
                    bool flag20 = leaf._AJF != null && (symbolDefinition == null || symbolDefinition._AT != SymbolKind.Error);
                    if (flag20)
                    {
                        bool flag21 = text != "";
                        if (flag21)
                        {
                            text = text + "\n\nSemantic error:\n\t" + leaf._AJF;
                        }
                        else
                        {
                            text = leaf._AJF;
                        }
                    }
                }
            }
            Rect rect = (horizontal ? new Rect(tokenRect.xMax, tokenRect.y, 1f, 1f) : new Rect(tokenRect.x, tokenRect.yMax, 1f, 1f));
            window.EBINNJIEDKILBKEDCAKOOHHEHNIOGIKHPKHN = forListPopup;
            window.wantsMouseMove = true;
            window._AEZ = tokenRect;
            window.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF = horizontal;
            window.hideFlags = HideFlags.HideAndDontSave;
            window._AEK = editor;
            window.minSize = Vector2.one;
            window._AEX = focusedWindow;
            window.APEIGILDGNBKKGCAAEECFHGOODFOLNFFBLJA = leaf;
            window.FAIDBFHPLIAGICLHFOMFMNHDAIEJHLDEMPMC(text);
            window.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN = array;
            window.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB = num;
            window.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP = editor._ABT._CFF;
            window.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.normal.textColor = (_bg8._BAF ? editor._CJL().text : editor._CJL().tooltipText);
            window.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.font = EditorStyles.standardFont;
            window.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.fontSize = _bg8._AEP + 12;
            window.GJGILFNBGFGECCHDCGILPCMMCFELLIKHGHBB = new GUIStyle(window.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP);
            window.GJGILFNBGFGECCHDCGILPCMMCFELLIKHGHBB.font = EditorStyles.boldFont;
            window.position = rect;
            window.ShowTooltip();
            bool flag22 = symbolDefinition != null;
            if (flag22)
            {
                _bh4 symbolDefinition2 = symbolDefinition;
                symbolDefinition2._BEQ = (Action)Delegate.Combine(symbolDefinition2._BEQ, new Action(delegate
                {
                    window.FAIDBFHPLIAGICLHFOMFMNHDAIEJHLDEMPMC(symbolDefinition.GetTooltipText());
                    window.Repaint();
                }));
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(window.HideCheck));
            return window;
        }

        // Token: 0x060000CC RID: 204 RVA: 0x0000A6A8 File Offset: 0x000088A8
        private static string GetTooltipText(_bh4 theSymbol, _bb4.DHBA leaf, _bi2 editor = null, _bk9 window = null)
        {
            bool flag = theSymbol._AT == SymbolKind.Method;
            if (flag)
            {
                _bb3 _AAN = theSymbol as _bb3;
                bool flag2 = _AAN != null && _AAN.IsExtensionMethod;
                if (flag2)
                {
                    _bb4._ACW _AGZ = leaf.OOME;
                    bool flag3 = _AGZ != null && _AGZ._AHB() == "accessIdentifier";
                    if (flag3)
                    {
                        _AGZ = _AGZ.FindPreviousNode() as _bb4._ACW;
                        bool flag4 = _AGZ != null && (_AGZ._AHB() == "primaryExpressionPart" || _AGZ._AHB() == "primaryExpressionStart");
                        if (flag4)
                        {
                            _bh4 resolvedSymbol = _bc9.GetResolvedSymbol(_AGZ);
                            bool flag5 = resolvedSymbol != null && resolvedSymbol._AT != SymbolKind.Error && !(resolvedSymbol is _b2);
                            if (flag5)
                            {
                                return theSymbol.GetTooltipTextAsExtensionMethod();
                            }
                        }
                    }
                }
            }
            string text = theSymbol.GetTooltipText();
            bool flag6 = editor != null && window != null;
            if (flag6)
            {
                try
                {
                    window.HJDNGHINOLHEPMFIEMMOHDJIGGDACMDELLHB = _ba4.GetSymbolIcon(theSymbol);
                    bool flag7 = theSymbol.Assembly != null && theSymbol.Assembly._CHJ && theSymbol._AT != SymbolKind.Parameter;
                    if (flag7)
                    {
                        List<FKI> list = _bh6.FindDeclarations(theSymbol);
                        bool flag8 = list != null && list.Count > 0;
                        if (flag8)
                        {
                            _bb4._AIN _AIO = list[0].NameNode();
                            bool flag9 = _AIO != null;
                            if (flag9)
                            {
                                string text2 = null;
                                GCE _AMX = null;
                                for (_bm6 _AQI = list[0]._AJW; _AQI != null; _AQI = _AQI._AMJ())
                                {
                                    _be7 _CHH = _AQI as _be7;
                                    bool flag10 = _CHH != null;
                                    if (flag10)
                                    {
                                        text2 = _CHH._AWJ;
                                        break;
                                    }
                                }
                                bool flag11 = text2 != null;
                                if (flag11)
                                {
                                    UnityEngine.Object @object = AssetDatabase.LoadAssetAtPath(text2, typeof(MonoScript));
                                    _AMX = _bc5.GetBuffer(@object);
                                }
                                int num = _AMX.GetParseTreeNodeSpan(_AIO).line;
                                string text3 = string.Empty;
                                string text4 = _AMX.FLOg[0].Trim();
                                bool flag12 = num > 0;
                                if (flag12)
                                {
                                    text4 = _AMX.FLOg[--num].Trim();
                                }
                                while (text4.StartsWith("["))
                                {
                                    text4 = _AMX.FLOg[--num].Trim();
                                }
                                while (text4.StartsWith("//"))
                                {
                                    text3 = text4 + text3;
                                    text4 = _AMX.FLOg[--num].Trim();
                                }
                                bool flag13 = text3.StartsWith("///") && text3.Contains("</summary>");
                                if (flag13)
                                {
                                    text3 = text3.Replace("///", "");
                                    string text5 = text3.Substring(0, text3.IndexOf("</summary>") + 10);
                                    XmlDocument xmlDocument = new XmlDocument();
                                    xmlDocument.LoadXml(text5);
                                    text3 = xmlDocument.SelectSingleNode("/summary").InnerText;
                                }
                                else
                                {
                                    text3 = text3.Replace("//", "");
                                }
                                text3 = text3.Trim();
                                bool flag14 = text3 != string.Empty;
                                if (flag14)
                                {
                                    text = text + "\n\n" + text3;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return text;
        }

        // Token: 0x060000CD RID: 205 RVA: 0x0000AA50 File Offset: 0x00008C50
        public void Hide()
        {
            this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN = null;
            this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB = 0;
            this.FAIDBFHPLIAGICLHFOMFMNHDAIEJHLDEMPMC(null);
            bool flag = this == this._AEK._CDA;
            if (flag)
            {
                this._AEK._CDV = default(DateTime);
                this._AEK._CDU = null;
                this._AEK._CDA = null;
            }
            else
            {
                bool flag2 = this == this._AEK._CBC;
                if (flag2)
                {
                    this._AEK._CBC = null;
                    this._AEK.CloseArgumentsHint();
                }
            }
            base.Close();
            UnityEngine.Object.DestroyImmediate(this);
        }

        // Token: 0x060000CE RID: 206 RVA: 0x0000AAF4 File Offset: 0x00008CF4
        public void HideCheck()
        {
            bool flag = (this.EBINNJIEDKILBKEDCAKOOHHEHNIOGIKHPKHN && this._AEL == null) || this._AEK == null;
            if (flag)
            {
                this.Hide();
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.HideCheck));
            }
        }

        // Token: 0x060000CF RID: 207 RVA: 0x0000AB54 File Offset: 0x00008D54
        public void OnGUI()
        {
            bool flag = (!this.EBINNJIEDKILBKEDCAKOOHHEHNIOGIKHPKHN && this.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK && Event.current.type == EventType.MouseMove) || Event.current.type == EventType.ScrollWheel || (Event.current.type == EventType.KeyDown && Event.current.keyCode == 27) || this._AEK._ABT._CFT == null;
            if (flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.Hide));
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.Hide));
            }
            else
            {
                bool flag2 = this._CKB() == null;
                if (!flag2)
                {
                    string text = this._CKB();
                    bool flag3 = this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN != null && this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length > 1;
                    if (flag3)
                    {
                        bool epalnjeijoejdlklclkpogglfmaecghipebf = this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF;
                        if (epalnjeijoejdlklclkpogglfmaecghipebf)
                        {
                            text = string.Concat(new string[]
                            {
                                "◄",
                                (this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB + 1).ToString(),
                                " of ",
                                this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length.ToString(),
                                "► ",
                                text
                            });
                        }
                        else
                        {
                            text = string.Concat(new string[]
                            {
                                "▲",
                                (this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB + 1).ToString(),
                                " of ",
                                this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length.ToString(),
                                "▼ ",
                                text
                            });
                        }
                    }
                    text = "     " + text;
                    bool flag4 = text.IndexOf("\n\n") != -1;
                    string text2 = "";
                    bool flag5 = flag4;
                    string text3;
                    if (flag5)
                    {
                        text3 = text.Remove(text.IndexOf("\n\n"));
                        text2 = text.Substring(text.IndexOf("\n\n"));
                    }
                    else
                    {
                        text3 = text;
                    }
                    text = text3.Replace("\n", "\n  ") + text2;
                    Rect rect;
                    rect..ctor(2.5f + (float)((_bg8._AEP + 3) / 5), 2.5f + (float)((_bg8._AEP + 3) / 5), (float)(16 + _bg8._AEP + 3), (float)(16 + _bg8._AEP + 3));
                    Rect rect2;
                    rect2..ctor(5f, 5f, base.position.width - 5f, base.position.height - 5f);
                    bool flag6 = this.HJDNGHINOLHEPMFIEMMOHDJIGGDACMDELLHB == null;
                    if (flag6)
                    {
                        this.HJDNGHINOLHEPMFIEMMOHDJIGGDACMDELLHB = _ba4.GetSymbolIcon(this.APEIGILDGNBKKGCAAEECFHGOODFOLNFFBLJA._AAB());
                    }
                    bool flag7 = Event.current.type == EventType.Layout;
                    if (flag7)
                    {
                        this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.fixedWidth = 0f;
                        GUIContent guicontent = new GUIContent(text);
                        Vector2 vector = ((this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.font != null) ? this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.CalcSize(guicontent) : Vector2.zero);
                        bool flag8 = vector.x > 400f;
                        if (flag8)
                        {
                            vector.x = 400f;
                            vector.y = this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.CalcHeight(guicontent, 400f);
                            this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.fixedWidth = vector.x;
                        }
                        base.SetSize(vector.x + 10f, vector.y + 10f);
                    }
                    else
                    {
                        bool flag9 = _bg8._BAF;
                        if (flag9)
                        {
                            GUI.Label(new Rect(2f, 2f, base.position.width - 4f, base.position.height - 4f), GUIContent.none, this._AEK._ABT._CEK);
                        }
                        else
                        {
                            GUI.Label(new Rect(0f, 0f, base.position.width, base.position.height), GUIContent.none, this._AEK._ABT._CFT);
                            GUI.Label(new Rect(2f, 2f, base.position.width - 4f, base.position.height - 4f), GUIContent.none, this._AEK._ABT._CFS);
                        }
                        bool flag10 = this.HJDNGHINOLHEPMFIEMMOHDJIGGDACMDELLHB != null;
                        if (flag10)
                        {
                            GUI.DrawTexture(rect, this.HJDNGHINOLHEPMFIEMMOHDJIGGDACMDELLHB);
                        }
                        bool flag11 = !this.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK && this.GBKBJAAHKMMBHBKFMNPBPFHGPDPMKHJGACJP == null;
                        if (flag11)
                        {
                            this.GBKBJAAHKMMBHBKFMNPBPFHGPDPMKHJGACJP = text.Split(new char[] { '\n' });
                        }
                        bool flag12 = this.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK || this.PIHEEHJKNFBBBKIBIFAALNDIHLOBJLBCIODA < 0 || this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN == null || this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB < 0 || this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB >= this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length || this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN[this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB].GetParameters().Count <= this.PIHEEHJKNFBBBKIBIFAALNDIHLOBJLBCIODA;
                        if (flag12)
                        {
                            GUI.Label(rect2, text, this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP);
                        }
                        else
                        {
                            Rect rect3 = rect2;
                            for (int i = 0; i < this.GBKBJAAHKMMBHBKFMNPBPFHGPDPMKHJGACJP.Length; i++)
                            {
                                GUIContent guicontent2 = new GUIContent(this.GBKBJAAHKMMBHBKFMNPBPFHGPDPMKHJGACJP[i]);
                                bool flag13 = i > 0;
                                if (flag13)
                                {
                                    rect2.x = rect3.x;
                                }
                                bool flag14 = i != this.PIHEEHJKNFBBBKIBIFAALNDIHLOBJLBCIODA + 1;
                                if (flag14)
                                {
                                    GUI.Label(rect2, guicontent2, this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP);
                                    rect2.yMin += this.BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP.CalcHeight(guicontent2, rect2.width);
                                }
                                else
                                {
                                    GUI.Label(rect2, guicontent2, this.GJGILFNBGFGECCHDCGILPCMMCFELLIKHGHBB);
                                    rect2.yMin += this.GJGILFNBGFGECCHDCGILPCMMCFELLIKHGHBB.CalcHeight(guicontent2, rect2.width);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x0000B18C File Offset: 0x0000938C
        public void OnOwnerGUI()
        {
            bool flag = this.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK && Event.current.type == EventType.Layout;
            if (flag)
            {
                Vector2 vector = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
                bool flag2 = !this._AEZ.Contains(vector);
                if (flag2)
                {
                    this.Hide();
                    return;
                }
            }
            bool flag3 = Event.current.type == EventType.ScrollWheel;
            if (flag3)
            {
                this.Hide();
            }
            else
            {
                bool flag4 = Event.current.type == EventType.KeyDown;
                if (flag4)
                {
                    bool flag5 = !Event.current.alt && !Event.current.command && !Event.current.control && !Event.current.shift;
                    if (flag5)
                    {
                        bool flag6 = this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN != null && this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length > 1;
                        if (flag6)
                        {
                            bool flag7 = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? (Event.current.keyCode == 275) : (Event.current.keyCode == 274));
                            bool flag8 = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? (Event.current.keyCode == 276) : (Event.current.keyCode == 273));
                            bool flag9 = flag8 || flag7;
                            if (flag9)
                            {
                                Event.current.Use();
                                this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB = (this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB + this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length + (flag7 ? 1 : (-1))) % this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN.Length;
                                this.FAIDBFHPLIAGICLHFOMFMNHDAIEJHLDEMPMC(_bk9.GetTooltipText(this.EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN[this.PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB], this.APEIGILDGNBKKGCAAEECFHGOODFOLNFFBLJA, this._AEK, this));
                                this.RepaintOnUpdate();
                                return;
                            }
                        }
                        bool flag10 = Event.current.keyCode == 27;
                        if (flag10)
                        {
                            Event.current.Use();
                            this.Hide();
                            return;
                        }
                    }
                    else
                    {
                        bool flag11 = !this.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK && (Event.current.keyCode == 273 || Event.current.keyCode == 274);
                        if (flag11)
                        {
                            Event.current.modifiers = Event.current.modifiers & -11;
                            this.Hide();
                        }
                    }
                    bool amaaeocibndoadeficmeicedipjceeoodick = this.AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK;
                    if (amaaeocibndoadeficmeicedipjceeoodick)
                    {
                        this.Hide();
                    }
                }
            }
        }

        // Token: 0x060000D1 RID: 209 RVA: 0x0000B3DF File Offset: 0x000095DF
        private void RepaintOnUpdate()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.DelayedRepaint));
        }

        // Token: 0x060000D2 RID: 210 RVA: 0x0000B402 File Offset: 0x00009602
        private void DelayedRepaint()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.DelayedRepaint));
            base.Repaint();
        }

        // Token: 0x040000BA RID: 186
        private string AHIMHNGEHPGDOJKDGBKPKBMNAOOLNPKFFHPB;

        // Token: 0x040000BB RID: 187
        private string[] GBKBJAAHKMMBHBKFMNPBPFHGPDPMKHJGACJP;

        // Token: 0x040000BC RID: 188
        private _bi2 _AEK;

        // Token: 0x040000BD RID: 189
        private _bh4[] EFFBNPPIAJOPILBOBPPDIICLHBPEOCKILAPN;

        // Token: 0x040000BE RID: 190
        private int PHDIDHMPIDGPFIFGMFOCFEJJABPGKGBNLMMB;

        // Token: 0x040000BF RID: 191
        private GUIStyle BMIJJAMJFPPMBPOLCFFAONNEBBEGNOHLFHNP;

        // Token: 0x040000C0 RID: 192
        private GUIStyle GJGILFNBGFGECCHDCGILPCMMCFELLIKHGHBB;

        // Token: 0x040000C1 RID: 193
        private _bb4.DHBA APEIGILDGNBKKGCAAEECFHGOODFOLNFFBLJA;

        // Token: 0x040000C2 RID: 194
        internal Texture2D HJDNGHINOLHEPMFIEMMOHDJIGGDACMDELLHB;

        // Token: 0x040000C3 RID: 195
        private bool AMAAEOCIBNDOADEFICMEICEDIPJCEEOODICK = true;

        // Token: 0x040000C4 RID: 196
        internal bool EBINNJIEDKILBKEDCAKOOHHEHNIOGIKHPKHN = false;

        // Token: 0x040000C5 RID: 197
        internal _ba4 _AEL;

        // Token: 0x040000C6 RID: 198
        private int PIHEEHJKNFBBBKIBIFAALNDIHLOBJLBCIODA = -1;
    }
}
