using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ACGG;
using SuperEditor;
using SuperEditor.IDE;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000028 RID: 40
    internal class _ba4 : _bm5
    {
        // Token: 0x06000132 RID: 306 RVA: 0x00010CF0 File Offset: 0x0000EEF0
        private static List<string> _ADG()
        {
            bool flag = _ba4._ADH == null;
            if (flag)
            {
                _ba4._ADH = new List<string>(200);
                _ba4._ADI = new List<string>(200);
                string @string = EditorPrefs.GetString("SuperEditorIDERecentCompletions_1", "");
                _ba4._ADH.AddRange(@string.Split(_ba4._ADJ, StringSplitOptions.RemoveEmptyEntries));
                _ba4._ADI.AddRange(_ba4._ADH);
            }
            return _ba4._ADH;
        }

        // Token: 0x06000133 RID: 307 RVA: 0x00010D6A File Offset: 0x0000EF6A
        [CompilerGenerated]
        public bool _ADK()
        {
            return this._ADL;
        }

        // Token: 0x06000134 RID: 308 RVA: 0x00010D72 File Offset: 0x0000EF72
        [CompilerGenerated]
        private void _ADM(bool value)
        {
            this._ADL = value;
        }

        // Token: 0x06000135 RID: 309 RVA: 0x00010D7C File Offset: 0x0000EF7C
        public string _ADN()
        {
            return this._ADO;
        }

        // Token: 0x06000136 RID: 310 RVA: 0x00010D94 File Offset: 0x0000EF94
        public void _ADP(string value)
        {
            this._ADQ = null;
            bool flag = this._ADR == null;
            if (!flag)
            {
                bool flag2 = this._ADS >= 0;
                bool flag3 = false;
                bool flag4 = false;
                value = _bh4.DecodeId(value);
                _bh4 _AAH = new _bh4
                {
                    _AW = value
                };
                int num = ((this._ADS < 0) ? (~this._ADS) : this._ADS);
                _bh4 _AAH2 = ((this._ADT.Count > 0 && num < this._ADT.Count) ? this._ADT[num] : null);
                this._ADO = value;
                bool flag5 = value == "";
                if (flag5)
                {
                    this._ADT.Clear();
                    this._ADT.AddRange(this._ADR);
                    bool flag6 = _AAH2 != null;
                    if (flag6)
                    {
                        num = this._ADT.IndexOf(_AAH2);
                        this._ADS = ((this._ADS < 0) ? (~num) : num);
                        flag4 = _ba4._ADU != null;
                    }
                    else
                    {
                        this._ADS = -1;
                        flag4 = true;
                    }
                }
                else
                {
                    this._ADQ = new _bf6(value);
                    HashSet<string> hashSet = new HashSet<string>();
                    int num2 = -1;
                    int num3 = -1;
                    this._ADV.Clear();
                    for (int i = 0; i < this._ADR.Length; i++)
                    {
                        string text = _ba4.NameOf(this._ADR[i]);
                        int num4;
                        bool flag7 = !this._ADQ.CalcMatchRank(text, out num4);
                        if (!flag7)
                        {
                            bool flag8 = num4 > num3;
                            if (flag8)
                            {
                                num2 = this._ADV.Count;
                                num3 = num4;
                                hashSet.Clear();
                                hashSet.Add(text);
                                bool flag9 = num4 >= int.MaxValue - value.Length - 1;
                                if (flag9)
                                {
                                    flag3 = true;
                                    _AAH2 = null;
                                }
                            }
                            else
                            {
                                bool flag10 = num4 == num3;
                                if (flag10)
                                {
                                    hashSet.Add(text);
                                }
                            }
                            this._ADV.Add(this._ADR[i]);
                        }
                    }
                    bool flag11 = this._ADV.Count == 0;
                    if (flag11)
                    {
                        bool flag12 = this._ADS >= 0;
                        if (flag12)
                        {
                            this._ADS = ~this._ADS;
                        }
                    }
                    else
                    {
                        List<_bh4> _ADW = this._ADT;
                        this._ADT = this._ADV;
                        this._ADV = _ADW;
                        bool flag13 = _AAH2 != null;
                        if (flag13)
                        {
                            bool flag14 = _AAH2._AW.StartsWith(value, StringComparison.OrdinalIgnoreCase);
                            if (flag14)
                            {
                                this._ADS = this._ADT.IndexOf(_AAH2);
                            }
                            else
                            {
                                this._ADS = num2;
                                bool flag15 = hashSet.Count > 1;
                                if (flag15)
                                {
                                    flag4 = true;
                                }
                            }
                        }
                        else
                        {
                            this._ADS = num2;
                            flag4 = !flag3 && (this._ADT.Count > 1 || this._ADS < 0 || _ba4._ADU != null);
                        }
                    }
                }
                bool flag16 = flag4 && (!flag2 || this._ADS < 0 || value != this._ADT[this._ADS]._AW);
                if (flag16)
                {
                    bool flag17 = _ba4._ADU != null && !flag3;
                    if (flag17)
                    {
                        _AAH._AW = _ba4._ADU;
                        int num5 = this._ADT.BinarySearch(_AAH, _ba4._ADX);
                        bool flag18 = num5 >= 0;
                        if (flag18)
                        {
                            this._ADS = num5;
                            flag4 = false;
                        }
                    }
                    bool flag19 = flag4;
                    if (flag19)
                    {
                        int count = _ba4._ADG().Count;
                        while (count-- > 0)
                        {
                            _AAH._AW = _ba4._ADG()[count];
                            int num6 = this._ADT.BinarySearch(_AAH, _ba4._ADX);
                            bool flag20 = num6 >= 0 && (value == "" || value[0] == '@' || value[0] == '_' || char.IsLower(value[0]) || !char.IsLower(_AAH._AW[0]));
                            if (flag20)
                            {
                                bool flag21 = this._ADT[num6]._AW.StartsWith(this._ADT[(this._ADS >= 0) ? this._ADS : (~this._ADS)]._AW, StringComparison.OrdinalIgnoreCase);
                                if (flag21)
                                {
                                    break;
                                }
                                this._ADS = num6;
                                break;
                            }
                        }
                    }
                }
                bool flag22 = this._ADS > 0 && this._ADS < this._ADT.Count;
                if (flag22)
                {
                    string text2 = this._ADT[this._ADS]._AW;
                    bool flag23 = _ba4._ADU == null || _ba4._ADU != text2;
                    if (flag23)
                    {
                        int j = this._ADS;
                        while (j > 0)
                        {
                            j--;
                            string _ADY = this._ADT[j]._AW;
                            bool flag24 = text2.StartsWith(_ADY, StringComparison.Ordinal) && _ADY.Length < text2.Length;
                            if (flag24)
                            {
                                this._ADS = j;
                                text2 = _ADY;
                            }
                            bool flag25 = char.ToLower(text2[0]) != char.ToLower(_ADY[0]);
                            if (flag25)
                            {
                                break;
                            }
                        }
                    }
                }
                bool flag26 = !flag2 && this._ADS >= 0 && (this._ADZ || !_bg8._AEA);
                if (flag26)
                {
                    this._ADS = ~this._ADS;
                }
                this.CenterScrollCurrentItem();
            }
        }

        // Token: 0x06000137 RID: 311 RVA: 0x00011348 File Offset: 0x0000F548
        internal static void LoadSymbolIcons()
        {
            bool flag = _ba4._AEB != null;
            if (!flag)
            {
                SymbolKind[] array = new SymbolKind[]
                {
                    SymbolKind.Namespace,
                    SymbolKind.Interface,
                    SymbolKind.Enum,
                    SymbolKind.Struct,
                    SymbolKind.Class,
                    SymbolKind.Delegate,
                    SymbolKind.Field,
                    SymbolKind.ConstantField,
                    SymbolKind.LocalConstant,
                    SymbolKind.EnumMember,
                    SymbolKind.Property,
                    SymbolKind.Event,
                    SymbolKind.Indexer,
                    SymbolKind.Method,
                    SymbolKind.Constructor,
                    SymbolKind.Destructor,
                    SymbolKind.Operator,
                    SymbolKind.Accessor,
                    SymbolKind.Parameter,
                    SymbolKind.CatchParameter,
                    SymbolKind.Variable,
                    SymbolKind.ForEachVariable,
                    SymbolKind.FromClauseVariable,
                    SymbolKind.TypeParameter,
                    SymbolKind.Label
                };
                HashSet<SymbolKind> hashSet = new HashSet<SymbolKind>
                {
                    SymbolKind.Namespace,
                    SymbolKind.EnumMember,
                    SymbolKind.Parameter,
                    SymbolKind.CatchParameter,
                    SymbolKind.Variable,
                    SymbolKind.ForEachVariable,
                    SymbolKind.FromClauseVariable,
                    SymbolKind.TypeParameter,
                    SymbolKind.Label,
                    SymbolKind.LocalConstant,
                    SymbolKind.Constructor,
                    SymbolKind.Destructor
                };
                _ba4._AEB = new Texture2D[Enum.GetNames(typeof(SymbolKind)).Length, 3];
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i].ToString();
                    bool flag2 = text == "ConstantField" || text == "LocalConstant";
                    if (flag2)
                    {
                        text = "Constant";
                    }
                    bool flag3 = text == "EnumMember";
                    if (flag3)
                    {
                        text = "EnumItem";
                    }
                    int num = (int)array[i];
                    Base64Texture base64Texture;
                    bool flag4 = Enum.TryParse<Base64Texture>(text + "_Public", out base64Texture);
                    if (flag4)
                    {
                        _ba4._AEB[num, 0] = _a2.GetInstance().GetTexture(base64Texture);
                    }
                    bool flag5 = _ba4._AEB[num, 0] == null;
                    if (flag5)
                    {
                        bool flag6 = Enum.TryParse<Base64Texture>(text, out base64Texture);
                        if (flag6)
                        {
                            _ba4._AEB[num, 0] = _a2.GetInstance().GetTexture(base64Texture);
                        }
                    }
                    bool flag7 = hashSet.Contains(array[i]);
                    if (flag7)
                    {
                        _ba4._AEB[num, 1] = _ba4._AEB[num, 0];
                        _ba4._AEB[num, 2] = _ba4._AEB[num, 0];
                    }
                    else
                    {
                        bool flag8 = Enum.TryParse<Base64Texture>(text + "_Protected", out base64Texture);
                        if (flag8)
                        {
                            _ba4._AEB[num, 1] = _a2.GetInstance().GetTexture(base64Texture);
                        }
                        bool flag9 = Enum.TryParse<Base64Texture>(text + "_Private", out base64Texture);
                        if (flag9)
                        {
                            _ba4._AEB[num, 2] = _a2.GetInstance().GetTexture(base64Texture);
                        }
                    }
                }
                _ba4._AEB[2, 0] = (_ba4._AEC = _a2.GetInstance().GetTexture(Base64Texture.Keyword));
                _ba4._AEB[2, 1] = _ba4._AEC;
                _ba4._AEB[2, 2] = _ba4._AEC;
                _ba4._AEB[3, 0] = (_ba4._AED = _a2.GetInstance().GetTexture(Base64Texture.Snippet));
                _ba4._AEB[3, 1] = _ba4._AED;
                _ba4._AEB[3, 2] = _ba4._AED;
            }
        }

        // Token: 0x06000138 RID: 312 RVA: 0x0001162C File Offset: 0x0000F82C
        private static void LoadResources()
        {
            _ba4.LoadSymbolIcons();
            Color textColor = _bi2._AEE()._ABV.normal.textColor;
            Texture2D texture2D = new Texture2D(1, 1);
            texture2D.SetPixel(0, 0, Color.clear);
            texture2D.Apply();
            _ba4._AEF = new GUIStyle("PR Label")
            {
                richText = true,
                fixedHeight = 0f,
                padding =
                {
                    left = 2,
                    top = 2,
                    bottom = 2,
                    right = 2
                },
                border = new RectOffset(2, 2, 2, 2),
                margin = new RectOffset(3, 3, 0, 0)
            };
        }

        // Token: 0x06000139 RID: 313 RVA: 0x000116F0 File Offset: 0x0000F8F0
        internal void CreatePopupTooltip()
        {
            Func<Task> func = async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(0.15000000596046448));
                this._AEG = new Rect(base.position.x + base.position.width, base.position.y - base.position.height, base.position.width, base.position.height);
                if (this._ADS >= 0)
                {
                    if (this._AEH != null)
                    {
                        this._AEH.Hide();
                    }
                    if (this._ADT[this._ADS]._AEI != null)
                    {
                        this._ADT[this._ADS]._AEI[0]._AEJ.GetFirstLeaf()._ACY(this._ADT[this._ADS]);
                        this._AEH = _bk9.Create(this._AEK, this._AEG, this._ADT[this._ADS]._AEI[0]._AEJ.GetFirstLeaf(), false, true, true);
                        this._AEH._AEL = this;
                    }
                    else
                    {
                        _bb4.DHBA _AEM = new _bb4.DHBA();
                        _AEM._ACY(this._ADT[this._ADS]);
                        _AEM.OOME = new _bb4._ACW(new _bh2._AEN("IDENTIFIER"));
                        _bb4.DHBA newLeaf = _AEM;
                        if (newLeaf._AAB() == null)
                        {
                        }
                        this._AEH = _bk9.Create(this._AEK, this._AEG, newLeaf, false, true, true);
                        this._AEH._AEL = this;
                        newLeaf = null;
                    }
                    this._AEO = this._ADT[this._ADS];
                }
                else
                {
                    if (this._AEH != null)
                    {
                        this._AEH.Hide();
                    }
                    this._AEO = null;
                }
            };
            func();
        }

        // Token: 0x0600013A RID: 314 RVA: 0x00011714 File Offset: 0x0000F914
        internal static _ba4 Create(_bi2 editor, Rect buttonRect, bool flipped)
        {
            bool flag = _ba4._AEF == null;
            if (flag)
            {
                _ba4.LoadResources();
            }
            _ba4._AEF.fontSize = _bg8._AEP + 12;
            _ba4._AEQ = Mathf.Max(19f, _ba4._AEF.CalcHeight(new GUIContent(_ba4._AEB[0, 0], "W"), 100f));
            _ba4._AEF.onNormal.textColor = editor._ABT._ABV.normal.textColor;
            _ba4._AEF.normal.textColor = editor._ABT._ABV.normal.textColor;
            _ba4._ADU = null;
            string text = "";
            int num;
            bool flag2;
            SyntaxToken tokenAt = editor._ABK().GetTokenAt(editor._ABH, out _ba4._AER, out num, out flag2);
            bool flag3 = tokenAt != null && tokenAt.tokenKind >= SyntaxToken.Kind.Keyword;
            if (flag3)
            {
                TextSpan tokenSpan = editor._ABK().GetTokenSpan(_ba4._AER, num);
                _ba4._AES = tokenSpan.StartPosition.index;
                _ba4._AET = editor._ABK().GetNonTriviaTokenLeftOf(_ba4._AER, _ba4._AES);
                text = tokenAt.text.Substring(0, editor._ABH._AEU - tokenSpan.index);
            }
            else
            {
                bool flag4 = !flag2 && tokenAt.tokenKind == SyntaxToken.Kind.Comment;
                if (flag4)
                {
                    return null;
                }
                bool flag5 = tokenAt != null && (tokenAt.tokenKind == SyntaxToken.Kind.StringLiteral || tokenAt.tokenKind == SyntaxToken.Kind.VerbatimStringLiteral || 
                    tokenAt.tokenKind == SyntaxToken.Kind.InterpolatedStringWholeLiteral || tokenAt.tokenKind == SyntaxToken.Kind.InterpolatedStringStartLiteral || 
                    tokenAt.tokenKind == SyntaxToken.Kind.InterpolatedStringMidLiteral || tokenAt.tokenKind == SyntaxToken.Kind.InterpolatedStringEndLiteral || 
                    tokenAt.tokenKind == SyntaxToken.Kind.InterpolatedStringFormatLiteral || tokenAt.tokenKind == SyntaxToken.Kind.CharLiteral || 
                    tokenAt.tokenKind == SyntaxToken.Kind.CharLiteral || (tokenAt.tokenKind >= SyntaxToken.Kind.Preprocessor && tokenAt.tokenKind <= SyntaxToken.Kind.PreprocessorUnexpectedDirective));
                if (flag5)
                {
                    return null;
                }
                _ba4._AES = editor._ABH._AEU;
                _ba4._AER = editor._ABH._ABI;
                _ba4._AET = editor._ABK().GetNonTriviaTokenLeftOf(_ba4._AER, _ba4._AES);
            }
            _ba4 _AEV = _bm5.CreatePopup<_ba4>();
            _AEV._AEW(flipped);
            _AEV.minSize = new Vector2(1f, 1f);
            _AEV._AEK = editor;
            _AEV._ABQ = ((editor != null) ? editor._ABK() : null);
            _AEV._AEX = EditorWindow.focusedWindow;
            _ba4._AES = ((editor != null) ? editor._ABH._AEU : 0);
            _ba4._AER = ((editor != null) ? editor._ABH._ABI : 0);
            Vector2 vector = GUIUtility.GUIToScreenPoint(new Vector2(buttonRect.x, flipped ? buttonRect.y : buttonRect.yMax));
            Rect rect = new Rect(vector.x - 24f - editor._AEY().x * (float)text.Length, flipped ? (vector.y - 21f) : vector.y, 1f, 21f);
            _AEV._AEZ = new Rect(rect.x, flipped ? (rect.y + 21f) : (rect.y - editor._AEY().y), 1f, editor._AEY().y);
            _AEV.position = rect;
            _AEV._ADP(text);
            _AEV.ShowTooltip();
            return _AEV;
        }

        // Token: 0x0600013B RID: 315 RVA: 0x00011AB0 File Offset: 0x0000FCB0
        public void UpdateTypedInPart()
        {
            GCE._AFA _AFB = this._AEK._ABH;
            string text = this._ABQ.FLOg[_AFB._ABI];
            int i;
            for (i = _AFB._AEU; i > 0; i--)
            {
                bool flag = !char.IsLetterOrDigit(text, i - 1) && text[i - 1] != '_' && text[i - 1] != '\\';
                if (flag)
                {
                    bool flag2 = text[i - 1] == '@';
                    if (flag2)
                    {
                        this._ADM(true);
                        i--;
                    }
                    break;
                }
            }
            bool flag3 = _ba4._AES < i;
            if (flag3)
            {
                this._ADO = "";
            }
            else
            {
                bool flag4 = _ba4._AES > _AFB._AEU;
                if (flag4)
                {
                    this._ADO = "";
                }
                else
                {
                    string text2 = text.Substring(i, _AFB._AEU - i);
                    this._ADP(text2);
                }
            }
        }

        // Token: 0x0600013C RID: 316 RVA: 0x00011BA4 File Offset: 0x0000FDA4
        internal static string NameOf(_bh4 symbol)
        {
            string text = symbol._AW;
            bool flag = _ba4._AFC && symbol._AT == SymbolKind.Class && symbol._AW.EndsWith("Attribute", StringComparison.Ordinal) && symbol._AW != "Attribute";
            if (flag)
            {
                text = text.Substring(0, text.Length - "Attribute".Length);
            }
            return text;
        }

        // Token: 0x0600013D RID: 317 RVA: 0x00011C14 File Offset: 0x0000FE14
        private static string ItemDisplayString(_bh4 symbol, string styledName)
        {
            return " " + symbol.CompletionDisplayString(styledName);
        }

        // Token: 0x0600013E RID: 318 RVA: 0x00011C38 File Offset: 0x0000FE38
        public bool SetCompletionData(HashSet<_bh4> data)
        {
            this._ADR = data.Where((_bh4 s) => !s.IsOperator).ToArray<_bh4>();
            List<_ba4._AFD> list = new List<_ba4._AFD>();
            List<_ba4._AFD> list2 = new List<_ba4._AFD>();
            int num = this._ADR.Length;
            while (num-- > 0)
            {
                _bh4 _AAH = this._ADR[num];
                SymbolKind _ABY = _AAH._AT;
                bool flag = _ABY == SymbolKind.Variable || _ABY == SymbolKind.Parameter || _ABY == SymbolKind.LocalConstant || _ABY == SymbolKind.Label || _ABY == SymbolKind.CatchParameter || _ABY == SymbolKind.FromClauseVariable || _ABY == SymbolKind.ForEachVariable;
                if (flag)
                {
                    string text = _ba4.NameOf(_AAH);
                    int num2 = _ba4._ADG().IndexOf(text);
                    List<_ba4._AFD> list3 = list2;
                    _ba4._AFD _AFE = new _ba4._AFD
                    {
                        _AW = text,
                        JIKB = ((num2 < 0) ? (_ba4.GetSymbolDeclarationLine(_AAH) - _ba4._AER) : num2)
                    };
                    list3.Add(_AFE);
                }
                else
                {
                    bool flag2 = _ABY == SymbolKind.Field || _ABY == SymbolKind.Property || _ABY == SymbolKind.ConstantField || _ABY == SymbolKind.Event;
                    if (flag2)
                    {
                        string text2 = _ba4.NameOf(_AAH);
                        int num3 = _ba4._ADG().IndexOf(text2);
                        List<_ba4._AFD> list4 = list;
                        _ba4._AFD _AFE = new _ba4._AFD
                        {
                            _AW = text2,
                            JIKB = ((num3 < 0) ? (-num) : num3)
                        };
                        list4.Add(_AFE);
                    }
                }
            }
            bool flag3 = list.Count > 0;
            if (flag3)
            {
                list.Sort(new Comparison<_ba4._AFD>(this.OrderByIndex));
                for (int i = 0; i < list.Count; i++)
                {
                    _ba4.AddRecentCompletion(_ba4._ADG(), list[i]._AW);
                }
            }
            bool flag4 = list2.Count > 0;
            if (flag4)
            {
                list2.Sort(new Comparison<_ba4._AFD>(this.OrderByIndex));
                for (int j = 0; j < list2.Count; j++)
                {
                    _ba4.AddRecentCompletion(_ba4._ADG(), list2[j]._AW);
                }
            }
            Array.Sort<_bh4>(this._ADR, _ba4._ADX);
            this.UpdateTypedInPart();
            return this._ADT.Count > 0;
        }

        // Token: 0x0600013F RID: 319 RVA: 0x00011E78 File Offset: 0x00010078
        private int OrderByIndex(_ba4._AFD a, _ba4._AFD b)
        {
            return a.JIKB.CompareTo(b.JIKB);
        }

        // Token: 0x06000140 RID: 320 RVA: 0x00011E9C File Offset: 0x0001009C
        private static int GetSymbolDeclarationLine(_bh4 symbol)
        {
            FKI _AFF = ((symbol._AEI == null) ? null : symbol._AEI.FirstOrDefault<FKI>());
            bool flag = _AFF == null;
            int num;
            if (flag)
            {
                num = -1;
            }
            else
            {
                _bb4.DHBA _AEM = ((_AFF._AEJ == null) ? null : _AFF._AEJ.GetFirstLeaf());
                num = ((_AEM == null) ? (-1) : symbol._AEI[0]._AEJ.GetFirstLeaf().line);
            }
            return num;
        }

        // Token: 0x06000141 RID: 321 RVA: 0x00011F09 File Offset: 0x00010109
        internal static void SetTopSuggestion(_bh4 suggestion)
        {
            _ba4._ADU = suggestion.GetName();
        }

        // Token: 0x06000142 RID: 322 RVA: 0x00011F18 File Offset: 0x00010118
        internal static Texture2D GetSymbolIcon(_bh4 symbol)
        {
            _ba4.LoadSymbolIcons();
            bool flag = symbol == null;
            Texture2D texture2D;
            if (flag)
            {
                texture2D = null;
            }
            else
            {
                Texture2D texture2D2 = symbol._AFG;
                bool flag2 = texture2D2;
                if (flag2)
                {
                    texture2D = texture2D2;
                }
                else
                {
                    texture2D2 = _ba4._AEB[(int)symbol._AT, (symbol._AFH() | symbol._AFI()) ? 0 : (symbol._AFJ() ? 1 : 2)] ?? _ba4._AEC;
                    bool flag3 = symbol._AT == SymbolKind.MethodGroup;
                    if (flag3)
                    {
                        texture2D2 = _ba4._AEB[17, 0];
                    }
                    _be8 _AFK = symbol as _be8;
                    bool flag4 = _AFK != null && typeof(Component).IsAssignableFrom(_AFK.GetReflectedType());
                    if (flag4)
                    {
                        GUIContent guicontent = EditorGUIUtility.ObjectContent(null, _AFK.GetReflectedType());
                        bool flag5 = guicontent.image != null;
                        if (flag5)
                        {
                            texture2D2 = (guicontent.image as Texture2D) ?? texture2D2;
                        }
                    }
                    symbol._AFG = texture2D2;
                    texture2D = texture2D2;
                }
            }
            return texture2D;
        }

        // Token: 0x06000143 RID: 323 RVA: 0x00012018 File Offset: 0x00010218
        private static void AddRecentCompletion(List<string> list, string completion)
        {
            bool flag = !list.Remove(completion) && list.Count == list.Capacity;
            if (flag)
            {
                list.RemoveAt(0);
            }
            list.Add(completion);
        }

        // Token: 0x06000144 RID: 324 RVA: 0x00012054 File Offset: 0x00010254
        private void Update()
        {
            bool _AFL = this._AFM;
            if (_AFL)
            {
                this._AFM = false;
                this._AEX.SendEvent(Event.KeyboardEvent("\n"));
            }
            bool flag = !this._AFN;
            if (flag)
            {
                base.SetSize(0f, 0f);
            }
            this._AFO.width = base.position.width;
            this._AFO.height = base.position.height;
        }

        // Token: 0x06000145 RID: 325 RVA: 0x000120E0 File Offset: 0x000102E0
        private void OnGUI()
        {
            bool flag = this._ADR == null || this._ADT.Count == 0;
            if (!flag)
            {
                bool flag2 = (int)Event.current.type == 8;
                if (!flag2)
                {
                    bool flag3 = (int)Event.current.type == 6;
                    if (flag3)
                    {
                        _ba4._AFP += Event.current.delta.y * (float)_ba4._AFQ;
                        bool flag4 = Mathf.Abs(_ba4._AFP - _ba4._AFR) > 1f;
                        if (flag4)
                        {
                            int num = ((_ba4._AFP - _ba4._AFR > 0f) ? 1 : (-1));
                            this._AFS = Mathf.Clamp(this._AFS + num, 0, this._ADT.Count - 8);
                            this._AFS = Mathf.Clamp(this._AFS, 0, Mathf.Max(0, this._ADT.Count - 8));
                            _ba4._AFR = (_ba4._AFP = 0f);
                        }
                        Event.current.Use();
                    }
                    EventModifiers eventModifiers = (EventModifiers)((int)Event.current.modifiers & -113);
                    EventModifiers eventModifiers2 = (EventModifiers)((int)eventModifiers & -11);
                    bool isKey = Event.current.isKey;
                    if (isKey)
                    {
                        bool flag5 = (int)Event.current.keyCode == 115 && ((int)eventModifiers == 2 || (int)eventModifiers == 8);
                        if (flag5)
                        {
                            this._AEK.SaveBuffer();
                            Event.current.Use();
                        }
                        else
                        {
                            bool flag6 = (int)Event.current.keyCode == 115 && (int)eventModifiers2 == 4;
                            if (flag6)
                            {
                                this._AEK.SaveBuffer();
                                Event.current.Use();
                            }
                        }
                        bool flag7 = (int)Event.current.keyCode == 122;
                        if (flag7)
                        {
                            bool flag8 = (int)eventModifiers == 2 || (int)eventModifiers == 8 || (int)eventModifiers == 12;
                            if (flag8)
                            {
                                this._AEK.Undo();
                                Event.current.Use();
                            }
                            else
                            {
                                bool flag9 = (int)eventModifiers == 3 || (int)eventModifiers == 9 || (int)eventModifiers == 13;
                                if (flag9)
                                {
                                    this._AEK.Redo();
                                    Event.current.Use();
                                }
                            }
                        }
                    }
                    this._AFO.x = (this._AFO.y = 0f);
                    GUI.Label(this._AFO, GUIContent.none, this._AEK._ABT._AFT);
                    this._AFO.xMin = this._AFO.xMin + 2f;
                    this._AFO.yMin = this._AFO.yMin + 2f;
                    this._AFO.xMax = this._AFO.xMax - 2f;
                    this._AFO.yMax = this._AFO.yMax - 2f;
                    GUI.Label(this._AFO, GUIContent.none, this._AEK._ABT._AFU);
                    Rect rect = new Rect(this._AFO);
                    rect.xMin = rect.xMax - 13f;
                    bool flag10 = this._ADT.Count > 8;
                    if (flag10)
                    {
                        object obj = _ba4._AFV;
                        bool isMouse = Event.current.isMouse;
                        if (isMouse)
                        {
                            bool flag11 = _ba4._AFW == null;
                            if (flag11)
                            {
                                _ba4._AFW = typeof(GUI).GetField("scrollStepSize", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            }
                            bool flag12 = _ba4._AFW != null;
                            if (flag12)
                            {
                                obj = _ba4._AFW.GetValue(null);
                                _ba4._AFW.SetValue(null, _ba4._AFX);
                            }
                        }
                        bool flag13 = _ba4._AFW == null;
                        if (flag13)
                        {
                            this._AFS = (int)(0.1f * GUI.VerticalScrollbar(rect, (float)this._AFS * 10f, 80f, 0f, (float)this._ADT.Count * 10f));
                        }
                        else
                        {
                            this._AFS = (int)GUI.VerticalScrollbar(rect, (float)this._AFS, 8f, 0f, (float)this._ADT.Count);
                        }
                        this._AFS = Mathf.Clamp(this._AFS, 0, Mathf.Max(0, this._ADT.Count - 8));
                        bool flag14 = Event.current.isMouse && _ba4._AFW != null;
                        if (flag14)
                        {
                            _ba4._AFW.SetValue(null, obj);
                        }
                    }
                    bool flag15 = (int)Event.current.type == 7;
                    if (flag15)
                    {
                        float num2 = 100f;
                        for (int i = Mathf.Min(this._ADT.Count, this._AFS + 8) - 1; i >= this._AFS; i--)
                        {
                            GUIContent guicontent = new GUIContent(_ba4.ItemDisplayString(this._ADT[i], "<b>" + this._ADT[i].GetName() + "</b>"));
                            bool flag16 = this._ADT[i].GetTypeParameters() != null;
                            if (flag16)
                            {
                                GUIContent guicontent2 = guicontent;
                                guicontent2.text += "<>";
                            }
                            num2 = Mathf.Max(num2, _ba4._AEF.CalcSize(guicontent).x);
                        }
                        Rect position = base.position;
                        position.width = Mathf.Max(position.width, num2 + 24f + ((this._ADT.Count > 8) ? 21f : 2f));
                        position.height = _ba4._AEQ * (float)Mathf.Min(8, this._ADT.Count) + 4f;
                        bool flag17 = !this._AFN || position != base.position;
                        if (flag17)
                        {
                            base.SetSize(position.width, position.height);
                            this._AFN = true;
                        }
                        EditorGUIUtility.SetIconSize(new Vector2(16f, 16f));
                        StringBuilder stringBuilder = null;
                        int num3 = Mathf.Min(this._ADT.Count, this._AFS + 8);
                        while (--num3 >= this._AFS)
                        {
                            Rect rect2 = new Rect(2f, 2f + _ba4._AEQ * (float)(num3 - this._AFS), base.position.width - 4f, _ba4._AEQ);
                            bool flag18 = this._ADT.Count > 8;
                            if (flag18)
                            {
                                rect2.xMax -= 13f;
                            }
                            bool flag19 = num3 == this._ADS;
                            bool flag20 = flag19 || ~num3 == this._ADS;
                            _bh4 _AAH = this._ADT[num3];
                            Texture2D symbolIcon = _ba4.GetSymbolIcon(_AAH);
                            string text = _ba4.NameOf(this._ADT[num3]);
                            bool flag21 = this._ADQ != null;
                            if (flag21)
                            {
                                int[] match = this._ADQ.GetMatch(text);
                                bool flag22 = match != null && match.Length != 0;
                                if (flag22)
                                {
                                    stringBuilder = stringBuilder ?? new StringBuilder();
                                    stringBuilder.Length = 0;
                                    bool flag23 = false;
                                    int num4 = 0;
                                    for (int j = 0; j < text.Length; j++)
                                    {
                                        bool flag24 = num4 == match.Length;
                                        if (flag24)
                                        {
                                            bool flag25 = flag23;
                                            if (flag25)
                                            {
                                                flag23 = false;
                                                stringBuilder.Append("</b>");
                                            }
                                            stringBuilder.Append(text, j, text.Length - j);
                                            break;
                                        }
                                        bool flag26 = j == match[num4];
                                        if (flag26)
                                        {
                                            num4++;
                                            bool flag27 = !flag23;
                                            if (flag27)
                                            {
                                                stringBuilder.Append("<b>");
                                                flag23 = true;
                                            }
                                        }
                                        else
                                        {
                                            bool flag28 = flag23;
                                            if (flag28)
                                            {
                                                stringBuilder.Append("</b>");
                                                flag23 = false;
                                            }
                                        }
                                        stringBuilder.Append(text[j]);
                                    }
                                    bool flag29 = flag23;
                                    if (flag29)
                                    {
                                        stringBuilder.Append("</b>");
                                    }
                                    text = stringBuilder.ToString();
                                }
                            }
                            string text2 = _ba4.ItemDisplayString(this._ADT[num3], text);
                            GUIContent guicontent3 = new GUIContent(text2, symbolIcon);
                            bool flag30 = this._ADT[num3].GetTypeParameters() != null;
                            if (flag30)
                            {
                                GUIContent guicontent4 = guicontent3;
                                guicontent4.text += "<>";
                            }
                            bool flag31 = (int)Application.platform != 16;
                            if (flag31)
                            {
                                _ba4._AEF.Draw(rect2, guicontent3, false, flag20, flag20, flag19);
                            }
                            else
                            {
                                bool flag32 = (int)Event.current.type == 7;
                                if (flag32)
                                {
                                    _ba4._AEF.Draw(rect2, guicontent3, false, flag20, flag20, flag19);
                                }
                            }
                        }
                        EditorGUIUtility.SetIconSize(Vector2.zero);
                    }
                    bool flag33 = EditorWindow.focusedWindow == this && this._AEX != null;
                    if (flag33)
                    {
                        this._AEK.FocusCodeView();
                    }
                    bool flag34 = (int)Event.current.type == 14 || (int)Event.current.type == 13 || Event.current.isKey;
                    if (flag34)
                    {
                        this._AEX.SendEvent(Event.current);
                    }
                    bool flag35 = (int)Event.current.type == 4;
                    if (flag35)
                    {
                        bool flag36 = Event.current.button == 0 && (this._ADT.Count <= 8 || Event.current.mousePosition.x < rect.x);
                        if (flag36)
                        {
                            int num5 = Mathf.Clamp((int)(Event.current.mousePosition.y / _ba4._AEQ), 0, 7);
                            this._ADS = Mathf.Clamp(num5 + this._AFS, 0, this._ADT.Count - 1);
                            Event.current.Use();
                            bool flag37 = Event.current.clickCount == 2;
                            if (flag37)
                            {
                                this._AFM = true;
                            }
                        }
                        this.CreatePopupTooltip();
                    }
                }
            }
        }

        // Token: 0x06000146 RID: 326 RVA: 0x00012B1C File Offset: 0x00010D1C
        protected void OnDestroy()
        {
            bool flag = this._AEH != null;
            if (flag)
            {
                this._AEH.Hide();
            }
        }

        // Token: 0x06000147 RID: 327 RVA: 0x00012B48 File Offset: 0x00010D48
        protected void OnLostFocus()
        {
            this._AEK.CloseAutocomplete();
        }

        // Token: 0x06000148 RID: 328 RVA: 0x00012B58 File Offset: 0x00010D58
        public _bh4 OnOwnerGUI()
        {
            int _AFY = this._ADS;
            bool flag = (int)Event.current.type == 6;
            _bh4 _AAH;
            if (flag)
            {
                bool flag2 = this._ADT.Count <= 8;
                if (flag2)
                {
                    _AAH = new _bh4();
                }
                else
                {
                    this._AFS = Mathf.Clamp(this._AFS + (int)Event.current.delta.y, 0, this._ADT.Count - 8);
                    Event.current.Use();
                    base.Repaint();
                    _AAH = null;
                }
            }
            else
            {
                bool flag3 = (int)Event.current.type == 4;
                if (flag3)
                {
                    string text = ((this._ADS < 0) ? "\t" : "\t\n {}[]().,:;+-*/%&|^!~=<>?@#'\"\\");
                    bool flag4 = _ba4._ADU != null && this._ADS >= 0;
                    if (flag4)
                    {
                        _bh4 _AAH2 = this._ADT[this._ADS];
                        bool flag5 = _ba4._ADU == _AAH2._AW;
                        if (flag5)
                        {
                            bool flag6 = _AAH2._AT == SymbolKind.Enum;
                            if (flag6)
                            {
                                text = "\t\n.";
                            }
                            else
                            {
                                bool flag7 = _AAH2._AT == SymbolKind.Constructor || _AAH2._AT == SymbolKind.Class || _AAH2._AT == SymbolKind.Struct;
                                if (flag7)
                                {
                                    text = "\t\n {(";
                                }
                                else
                                {
                                    text = "\t\n";
                                }
                            }
                        }
                    }
                    bool flag8 = !Event.current.alt && !Event.current.command && !Event.current.control && (text.IndexOf(Event.current.character) >= 0 || (int)Event.current.keyCode == 271);
                    if (flag8)
                    {
                        bool flag9 = Event.current.shift && Event.current.character == '\t';
                        if (flag9)
                        {
                            return new _bh4();
                        }
                        bool flag10 = this._ADS < 0;
                        if (flag10)
                        {
                            this._ADS = ~this._ADS;
                        }
                        string text2 = _ba4.NameOf(this._ADT[this._ADS]);
                        _ba4._ADG().Clear();
                        _ba4._ADH.AddRange(_ba4._ADI);
                        _ba4.AddRecentCompletion(_ba4._ADH, text2);
                        _ba4.AddRecentCompletion(_ba4._ADI, text2);
                        string text3 = string.Join(",", _ba4._ADG().ToArray());
                        EditorPrefs.SetString("SuperEditorIDERecentCompletions_1", text3);
                        return this._ADT[this._ADS];
                    }
                    else
                    {
                        KeyCode keyCode = Event.current.keyCode;
                        KeyCode keyCode2 = keyCode;
                        if ((int)keyCode2 <= 273)
                        {
                            if ((int)keyCode2 == 27)
                            {
                                Event.current.Use();
                                return new _bh4();
                            }
                            if ((int)keyCode2 == 273)
                            {
                                bool flag11 = Event.current.shift || Event.current.alt || Event.current.command || Event.current.control;
                                if (flag11)
                                {
                                    bool flag12 = !Event.current.shift && !Event.current.alt;
                                    if (flag12)
                                    {
                                        Event.current.modifiers = (EventModifiers)((int)Event.current.modifiers & -11);
                                    }
                                    return new _bh4();
                                }
                                Event.current.Use();
                                bool flag13 = this._ADS >= 0;
                                if (flag13)
                                {
                                    this._ADS = Mathf.Max(0, this._ADS - 1);
                                }
                                else
                                {
                                    this._ADS = Mathf.Max(0, -1 - this._ADS);
                                }
                            }
                        }
                        else if ((int)keyCode2 != 274)
                        {
                            if ((int)keyCode2 != 280)
                            {
                                if ((int)keyCode2 == 281)
                                {
                                    Event.current.Use();
                                    bool flag14 = this._ADS >= 0;
                                    if (flag14)
                                    {
                                        this._ADS = Mathf.Min(this._ADT.Count - 1, this._ADS + 8);
                                    }
                                    else
                                    {
                                        this._ADS = Mathf.Max(0, 9 - this._ADS);
                                    }
                                }
                            }
                            else
                            {
                                Event.current.Use();
                                bool flag15 = this._ADS >= 0;
                                if (flag15)
                                {
                                    this._ADS = Mathf.Max(0, this._ADS - 8);
                                }
                                else
                                {
                                    this._ADS = Mathf.Max(0, -10 - this._ADS);
                                }
                            }
                        }
                        else
                        {
                            bool flag16 = Event.current.shift || Event.current.alt || Event.current.command || Event.current.control;
                            if (flag16)
                            {
                                bool flag17 = !Event.current.shift && !Event.current.alt;
                                if (flag17)
                                {
                                    Event.current.modifiers = (EventModifiers)((int)Event.current.modifiers & -11);
                                }
                                return new _bh4();
                            }
                            Event.current.Use();
                            bool flag18 = this._ADS >= 0;
                            if (flag18)
                            {
                                this._ADS = Mathf.Min(this._ADT.Count - 1, this._ADS + 1);
                            }
                            else
                            {
                                this._ADS = Mathf.Min(this._ADT.Count - 1, ~this._ADS);
                            }
                        }
                    }
                }
                bool isKey = Event.current.isKey;
                if (isKey)
                {
                    this.CreatePopupTooltip();
                }
                bool flag19 = this._ADS != _AFY;
                if (flag19)
                {
                    this.ScrollToCurrentItem();
                    bool flag20 = this._ADS != -1;
                    if (flag20)
                    {
                        this._AFS = Mathf.Min(this._AFS, this._ADS);
                        this._AFS = Mathf.Max(this._AFS, this._ADS - 8 + 1);
                    }
                    base.Repaint();
                }
                bool flag21 = this._AEK._ABH._ABI != _ba4._AER;
                if (flag21)
                {
                    _AAH = new _bh4();
                }
                else
                {
                    bool flag22 = this._AEK._ABH._AEU < _ba4._AES;
                    if (flag22)
                    {
                        _AAH = new _bh4();
                    }
                    else
                    {
                        bool flag23 = this._AEK._ABH._AEU > _ba4._AES + this._ADO.Length;
                        if (flag23)
                        {
                            _AAH = new _bh4();
                        }
                        else
                        {
                            _AAH = null;
                        }
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x06000149 RID: 329 RVA: 0x0001319C File Offset: 0x0001139C
        private void ScrollToCurrentItem()
        {
            int num = this._ADS;
            bool flag = num < 0;
            if (flag)
            {
                num = ~num;
            }
            this._AFS = Mathf.Min(this._AFS, num);
            this._AFS = Mathf.Max(this._AFS, num - 8 + 1);
            base.Repaint();
        }

        // Token: 0x0600014A RID: 330 RVA: 0x000131EC File Offset: 0x000113EC
        private void CenterScrollCurrentItem()
        {
            int num = this._ADS;
            bool flag = num < 0;
            if (flag)
            {
                num = ~num;
            }
            this._AFS = Mathf.Clamp(num, 0, Mathf.Max(0, this._ADT.Count - 8));
            base.Repaint();
        }

        // Token: 0x0400014C RID: 332
        private _bh4 _AEO;

        // Token: 0x0400014D RID: 333
        private int _ADS = -1;

        // Token: 0x0400014E RID: 334
        private _bh4[] _ADR;

        // Token: 0x0400014F RID: 335
        private List<_bh4> _ADT = new List<_bh4>();

        // Token: 0x04000150 RID: 336
        private List<_bh4> _ADV = new List<_bh4>();

        // Token: 0x04000151 RID: 337
        private _bf6 _ADQ;

        // Token: 0x04000152 RID: 338
        private Rect _AFO = Rect.zero;

        // Token: 0x04000153 RID: 339
        private int _AFS;

        // Token: 0x04000154 RID: 340
        private static float _AEQ = 19f;

        // Token: 0x04000155 RID: 341
        private bool _AFN;

        // Token: 0x04000156 RID: 342
        private _bk9 _AEH;

        // Token: 0x04000157 RID: 343
        internal Rect _AEG;

        // Token: 0x04000158 RID: 344
        private GCE _ABQ;

        // Token: 0x04000159 RID: 345
        private _bi2 _AEK;

        // Token: 0x0400015A RID: 346
        private bool _AFM;

        // Token: 0x0400015B RID: 347
        private static string _ADU;

        // Token: 0x0400015C RID: 348
        private static char[] _ADJ = new char[] { ',' };

        // Token: 0x0400015D RID: 349
        private static List<string> _ADH;

        // Token: 0x0400015E RID: 350
        private static List<string> _ADI;

        // Token: 0x0400015F RID: 351
        private static int _AES;

        // Token: 0x04000160 RID: 352
        private static int _AER;

        // Token: 0x04000161 RID: 353
        internal static SyntaxToken _AET;

        // Token: 0x04000162 RID: 354
        internal static bool _AFC;

        // Token: 0x04000163 RID: 355
        private static readonly _ba4._AFZ _ADX = new _ba4._AFZ();

        // Token: 0x04000164 RID: 356
        private static FieldInfo _AFW;

        // Token: 0x04000165 RID: 357
        private static readonly object _AFX = 1f;

        // Token: 0x04000166 RID: 358
        private static readonly object _AFV = 10f;

        // Token: 0x04000167 RID: 359
        internal static int _AFQ = 1;

        // Token: 0x04000168 RID: 360
        internal static float _AFR;

        // Token: 0x04000169 RID: 361
        internal static float _AFP;

        // Token: 0x0400016A RID: 362
        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _ADL;

        // Token: 0x0400016B RID: 363
        [NonSerialized]
        public bool _ADZ;

        // Token: 0x0400016C RID: 364
        private string _ADO = "";

        // Token: 0x0400016D RID: 365
        private static GUIStyle _AEF;

        // Token: 0x0400016E RID: 366
        internal static Texture2D[,] _AEB;

        // Token: 0x0400016F RID: 367
        internal static Texture2D _AEC;

        // Token: 0x04000170 RID: 368
        internal static Texture2D _AED;

        // Token: 0x02000029 RID: 41
        private class _AFZ : IComparer<_bh4>
        {
            // Token: 0x0600014E RID: 334 RVA: 0x0001330C File Offset: 0x0001150C
            public int Compare(_bh4 a, _bh4 b)
            {
                string text = _ba4.NameOf(a);
                string text2 = _ba4.NameOf(b);
                int num = string.Compare(text, text2, StringComparison.OrdinalIgnoreCase);
                bool flag = num == 0;
                if (flag)
                {
                    num = string.Compare(text, text2, StringComparison.Ordinal);
                }
                return num;
            }
        }

        // Token: 0x0200002A RID: 42
        private struct _AFD
        {
            // Token: 0x04000171 RID: 369
            public string _AW;

            // Token: 0x04000172 RID: 370
            public int JIKB;
        }
    }
}
