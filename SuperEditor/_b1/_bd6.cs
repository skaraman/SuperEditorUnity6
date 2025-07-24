using System;
using System.Collections.Generic;
using SuperEditor;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000049 RID: 73
    internal class FLCK : _be3
    {
        // Token: 0x1700000F RID: 15
        // (get) Token: 0x060001F4 RID: 500 RVA: 0x00019690 File Offset: 0x00017890
        public override HashSet<string> Keywords
        {
            get
            {
                return FLCK._ABM;
            }
        }

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x060001F5 RID: 501 RVA: 0x000196A8 File Offset: 0x000178A8
        public override HashSet<string> BuiltInLiterals
        {
            get
            {
                return FLCK._ARE;
            }
        }

        // Token: 0x060001F6 RID: 502 RVA: 0x000196C0 File Offset: 0x000178C0
        public override bool IsBuiltInType(string word)
        {
            return Array.BinarySearch<string>(FLCK._ABO, word, StringComparer.OrdinalIgnoreCase) >= 0;
        }

        // Token: 0x060001F7 RID: 503 RVA: 0x000196E8 File Offset: 0x000178E8
        public override bool IsBuiltInLiteral(string word)
        {
            return Array.BinarySearch<string>(FLCK._ARF, word, StringComparer.OrdinalIgnoreCase) >= 0;
        }

        // Token: 0x060001F9 RID: 505 RVA: 0x00019E80 File Offset: 0x00018080
        public override void LexLine(int currentLine, GCE.PHFG formatedLine)
        {
            formatedLine.JIKB = currentLine;
            bool flag = this._ABP != null;
            if (flag)
            {
                this._ABP.Join();
            }
            this._ABP = null;
            string text = this._ABQ.FLOg[currentLine];
            bool flag2 = currentLine == 0;
            if (flag2)
            {
                string[] activeScriptCompilationDefines = EditorUserBuildSettings.activeScriptCompilationDefines;
                bool flag3 = this._ABR == null || !this._ABR.SetEquals(activeScriptCompilationDefines);
                if (flag3)
                {
                    bool flag4 = this._ABR == null;
                    if (flag4)
                    {
                        this._ABR = new HashSet<string>(activeScriptCompilationDefines);
                    }
                    else
                    {
                        this._ABR.Clear();
                        this._ABR.UnionWith(activeScriptCompilationDefines);
                    }
                }
            }
            this.Tokenize(text, formatedLine);
            List<SyntaxToken> _ABS = formatedLine.EOIA;
            bool flag5 = text.Length == 0;
            if (flag5)
            {
                formatedLine.EOIA.Clear();
            }
            else
            {
                bool flag6 = this._ABQ._ABT != null;
                if (flag6)
                {
                    int num = this._ABQ.CharIndexToColumn(text.Length, currentLine);
                    bool flag7 = num > this._ABQ._ABU;
                    if (flag7)
                    {
                        this._ABQ._ABU = num;
                    }
                    for (int i = 0; i < _ABS.Count; i++)
                    {
                        SyntaxToken syntaxToken = _ABS[i];
                        switch (syntaxToken.tokenKind)
                        {
                            case SyntaxToken.Kind.Missing:
                            case SyntaxToken.Kind.Whitespace:
                                syntaxToken.style = this._ABQ._ABT._ABV;
                                break;
                            case SyntaxToken.Kind.Comment:
                                {
                                    GCE._ABW._ABX _ABY = formatedLine._ABZ._AT;
                                    bool flag8 = _ABY > (GCE._ABW._ABX)5;
                                    syntaxToken.style = (flag8 ? this._ABQ._ABT._ACA : this._ABQ._ABT._ACB);
                                    break;
                                }
                            case SyntaxToken.Kind.Preprocessor:
                                syntaxToken.style = this._ABQ._ABT._ACC;
                                break;
                            case SyntaxToken.Kind.PreprocessorArguments:
                            case SyntaxToken.Kind.PreprocessorDirectiveExpected:
                            case SyntaxToken.Kind.PreprocessorCommentExpected:
                            case SyntaxToken.Kind.PreprocessorUnexpectedDirective:
                                syntaxToken.style = this._ABQ._ABT._ABV;
                                break;
                            case SyntaxToken.Kind.PreprocessorSymbol:
                                syntaxToken.style = this._ABQ._ABT._ACD;
                                break;
                            case SyntaxToken.Kind.VerbatimStringLiteral:
                            case SyntaxToken.Kind.VerbatimStringBegin:
                            case SyntaxToken.Kind.CharLiteral:
                            case SyntaxToken.Kind.StringLiteral:
                                syntaxToken.style = this._ABQ._ABT._ACE;
                                break;
                            case SyntaxToken.Kind.IntegerLiteral:
                            case SyntaxToken.Kind.RealLiteral:
                                syntaxToken.style = this._ABQ._ABT._ACF;
                                break;
                            case SyntaxToken.Kind.Punctuator:
                                syntaxToken.style = (this.IsOperator(syntaxToken.text) ? this._ABQ._ABT._ACG : this._ABQ._ABT._ACH);
                                break;
                            case SyntaxToken.Kind.Keyword:
                                {
                                    bool flag9 = this.IsBuiltInType(syntaxToken.text);
                                    if (flag9)
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ACN;
                                    }
                                    else
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ACK;
                                    }
                                    break;
                                }
                            case SyntaxToken.Kind.Identifier:
                                {
                                    bool flag10 = this.IsBuiltInLiteral(syntaxToken.text);
                                    if (flag10)
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ACL;
                                        syntaxToken.tokenKind = SyntaxToken.Kind.BuiltInLiteral;
                                    }
                                    else
                                    {
                                        bool flag11 = this.IsBuiltInType(syntaxToken.text);
                                        if (flag11)
                                        {
                                            syntaxToken.style = this._ABQ._ABT._ACN;
                                        }
                                        else
                                        {
                                            syntaxToken.style = this._ABQ._ABT._ABV;
                                        }
                                    }
                                    break;
                                }
                        }
                        _ABS[i] = syntaxToken;
                    }
                }
            }
        }

        // Token: 0x060001FA RID: 506 RVA: 0x0001A258 File Offset: 0x00018458
        protected override void Tokenize(string line, GCE.PHFG formatedLine)
        {
            List<SyntaxToken> list = new List<SyntaxToken>();
            formatedLine.EOIA = list;
            int i = 0;
            int length = line.Length;
            SyntaxToken syntaxToken = _be3.ScanWhitespace(line, ref i);
            bool flag = syntaxToken != null;
            if (flag)
            {
                list.Add(syntaxToken);
                syntaxToken.AIGN = formatedLine;
            }
            bool flag2 = formatedLine._ACO == (GCE._ACP)0 && i < length && line[i] == '#';
            if (flag2)
            {
                list.Add(new SyntaxToken(SyntaxToken.Kind.Preprocessor, "#")
                {
                    AIGN = formatedLine
                });
                i++;
                syntaxToken = _be3.ScanWhitespace(line, ref i);
                bool flag3 = syntaxToken != null;
                if (flag3)
                {
                    list.Add(syntaxToken);
                    syntaxToken.AIGN = formatedLine;
                }
                bool flag4 = false;
                bool flag5 = false;
                bool flag6 = true;
                SyntaxToken syntaxToken2 = _be3.ScanWord(line, ref i);
                bool flag7 = !FLCK._ACQ.Contains(syntaxToken2.text);
                if (flag7)
                {
                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorDirectiveExpected;
                    list.Add(syntaxToken2);
                    syntaxToken2.AIGN = formatedLine;
                    flag4 = true;
                }
                else
                {
                    syntaxToken2.tokenKind = SyntaxToken.Kind.Preprocessor;
                    list.Add(syntaxToken2);
                    syntaxToken2.AIGN = formatedLine;
                    syntaxToken = _be3.ScanWhitespace(line, ref i);
                    bool flag8 = syntaxToken != null;
                    if (flag8)
                    {
                        list.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag9 = syntaxToken2.text == "if";
                    if (flag9)
                    {
                        bool flag10 = base.ParsePPOrExpression(line, formatedLine, ref i);
                        bool flag11 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                        bool flag12 = flag10 && !flag11;
                        if (flag12)
                        {
                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)2);
                            flag5 = true;
                        }
                        else
                        {
                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)7);
                            flag5 = true;
                        }
                    }
                    else
                    {
                        bool flag13 = syntaxToken2.text == "elif";
                        if (flag13)
                        {
                            bool flag14 = base.ParsePPOrExpression(line, formatedLine, ref i);
                            bool flag15 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                            bool flag16 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8;
                            if (flag16)
                            {
                                base.OpenRegion(formatedLine, (GCE._ABW._ABX)8);
                            }
                            else
                            {
                                bool flag17 = formatedLine._ABZ._AT == (GCE._ABW._ABX)7;
                                if (flag17)
                                {
                                    flag15 = formatedLine._ABZ.OOME._AT > (GCE._ABW._ABX)5;
                                    bool flag18 = flag14 && !flag15;
                                    if (flag18)
                                    {
                                        base.OpenRegion(formatedLine, (GCE._ABW._ABX)3);
                                    }
                                    else
                                    {
                                        base.OpenRegion(formatedLine, (GCE._ABW._ABX)8);
                                    }
                                }
                                else
                                {
                                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                }
                            }
                        }
                        else
                        {
                            bool flag19 = syntaxToken2.text == "else";
                            if (flag19)
                            {
                                bool flag20 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3;
                                if (flag20)
                                {
                                    base.OpenRegion(formatedLine, (GCE._ABW._ABX)9);
                                }
                                else
                                {
                                    bool flag21 = formatedLine._ABZ._AT == (GCE._ABW._ABX)7 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8;
                                    if (flag21)
                                    {
                                        bool flag22 = formatedLine._ABZ.OOME._AT > (GCE._ABW._ABX)5;
                                        bool flag23 = flag22;
                                        if (flag23)
                                        {
                                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)9);
                                        }
                                        else
                                        {
                                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)4);
                                        }
                                    }
                                    else
                                    {
                                        syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                    }
                                }
                            }
                            else
                            {
                                bool flag24 = syntaxToken2.text == "endif";
                                if (flag24)
                                {
                                    bool flag25 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3 || formatedLine._ABZ._AT == (GCE._ABW._ABX)4 || formatedLine._ABZ._AT == (GCE._ABW._ABX)7 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8 || formatedLine._ABZ._AT == (GCE._ABW._ABX)9;
                                    if (flag25)
                                    {
                                        base.CloseRegion(formatedLine);
                                    }
                                    else
                                    {
                                        syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                    }
                                }
                                else
                                {
                                    bool flag26 = syntaxToken2.text == "region";
                                    if (flag26)
                                    {
                                        bool flag27 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                                        bool flag28 = flag27;
                                        if (flag28)
                                        {
                                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)6);
                                        }
                                        else
                                        {
                                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)1);
                                        }
                                        flag6 = false;
                                    }
                                    else
                                    {
                                        bool flag29 = syntaxToken2.text == "endregion";
                                        if (flag29)
                                        {
                                            bool flag30 = formatedLine._ABZ._AT == (GCE._ABW._ABX)1 || formatedLine._ABZ._AT == (GCE._ABW._ABX)6;
                                            if (flag30)
                                            {
                                                base.CloseRegion(formatedLine);
                                            }
                                            else
                                            {
                                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                            }
                                            flag6 = false;
                                        }
                                        else
                                        {
                                            bool flag31 = syntaxToken2.text == "define" || syntaxToken2.text == "undef";
                                            if (flag31)
                                            {
                                                SyntaxToken syntaxToken3 = _be3.ScanIdentifierOrKeyword(line, ref i);
                                                bool flag32 = syntaxToken3 != null && syntaxToken3.text != "true" && syntaxToken3.text != "false";
                                                if (flag32)
                                                {
                                                    syntaxToken3.tokenKind = SyntaxToken.Kind.PreprocessorSymbol;
                                                    formatedLine.EOIA.Add(syntaxToken3);
                                                    syntaxToken3.AIGN = formatedLine;
                                                    this._ARD = true;
                                                    bool flag33 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                                                    bool flag34 = !flag33;
                                                    if (flag34)
                                                    {
                                                        bool flag35 = syntaxToken2.text == "define";
                                                        if (flag35)
                                                        {
                                                            bool flag36 = !this._ABR.Contains(syntaxToken3.text);
                                                            if (flag36)
                                                            {
                                                                this._ABR.Add(syntaxToken3.text);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            bool flag37 = this._ABR.Contains(syntaxToken3.text);
                                                            if (flag37)
                                                            {
                                                                this._ABR.Remove(syntaxToken3.text);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                bool flag38 = syntaxToken2.text == "error" || syntaxToken2.text == "warning";
                                                if (flag38)
                                                {
                                                    flag6 = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag39 = !flag6;
                if (flag39)
                {
                    syntaxToken = _be3.ScanWhitespace(line, ref i);
                    bool flag40 = syntaxToken != null;
                    if (flag40)
                    {
                        list.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag41 = i < length;
                    if (flag41)
                    {
                        string text = line.Substring(i);
                        text.TrimEnd(new char[] { ' ', '\t' });
                        list.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, text)
                        {
                            AIGN = formatedLine
                        });
                        i = length - text.Length;
                        bool flag42 = i < length;
                        if (flag42)
                        {
                            list.Add(new SyntaxToken(SyntaxToken.Kind.Whitespace, line.Substring(i))
                            {
                                AIGN = formatedLine
                            });
                        }
                    }
                }
                else
                {
                    while (i < length)
                    {
                        syntaxToken = _be3.ScanWhitespace(line, ref i);
                        bool flag43 = syntaxToken != null;
                        if (flag43)
                        {
                            list.Add(syntaxToken);
                            syntaxToken.AIGN = formatedLine;
                        }
                        else
                        {
                            char c = line[i];
                            bool flag44 = i < length - 1 && c == '/' && line[i + 1] == '/';
                            if (flag44)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                break;
                            }
                            bool flag45 = flag5;
                            if (flag45)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorCommentExpected, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                break;
                            }
                            bool flag46 = char.IsLetterOrDigit(c) || c == '_';
                            if (flag46)
                            {
                                syntaxToken2 = _be3.ScanWord(line, ref i);
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                list.Add(syntaxToken2);
                                syntaxToken2.AIGN = formatedLine;
                            }
                            else
                            {
                                bool flag47 = c == '"';
                                if (flag47)
                                {
                                    syntaxToken2 = _be3.ScanStringLiteral(line, ref i);
                                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                    list.Add(syntaxToken2);
                                    syntaxToken2.AIGN = formatedLine;
                                }
                                else
                                {
                                    bool flag48 = c == '\'';
                                    if (flag48)
                                    {
                                        syntaxToken2 = _be3.ScanCharLiteral(line, ref i);
                                        syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                        list.Add(syntaxToken2);
                                        syntaxToken2.AIGN = formatedLine;
                                    }
                                    else
                                    {
                                        syntaxToken2 = new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, c.ToString())
                                        {
                                            AIGN = formatedLine
                                        };
                                        list.Add(syntaxToken2);
                                        i++;
                                    }
                                }
                            }
                            bool flag49 = flag4;
                            if (flag49)
                            {
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorDirectiveExpected;
                            }
                        }
                    }
                }
            }
            else
            {
                bool flag50 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                while (i < length)
                {
                    GCE._ACP _ACR = formatedLine._ACO;
                    GCE._ACP _ACS = _ACR;
                    if (_ACS != (GCE._ACP)0)
                    {
                        if (_ACS == (GCE._ACP)1)
                        {
                            int num = line.IndexOf("*/", i, StringComparison.Ordinal);
                            bool flag51 = num == -1;
                            if (flag51)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                i = length;
                            }
                            else
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i, num + 2 - i))
                                {
                                    AIGN = formatedLine
                                });
                                i = num + 2;
                                formatedLine._ACO = (GCE._ACP)0;
                            }
                        }
                    }
                    else
                    {
                        syntaxToken = _be3.ScanWhitespace(line, ref i);
                        bool flag52 = syntaxToken != null;
                        if (flag52)
                        {
                            list.Add(syntaxToken);
                            syntaxToken.AIGN = formatedLine;
                        }
                        else
                        {
                            bool flag53 = flag50;
                            if (flag53)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                i = length;
                            }
                            else
                            {
                                bool flag54 = line[i] == '/' && i < length - 1;
                                if (flag54)
                                {
                                    bool flag55 = line[i + 1] == '/';
                                    if (flag55)
                                    {
                                        list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, "//")
                                        {
                                            AIGN = formatedLine
                                        });
                                        i += 2;
                                        list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                        {
                                            AIGN = formatedLine
                                        });
                                        i = length;
                                        continue;
                                    }
                                    bool flag56 = line[i + 1] == '*';
                                    if (flag56)
                                    {
                                        list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, "/*")
                                        {
                                            AIGN = formatedLine
                                        });
                                        i += 2;
                                        formatedLine._ACO = (GCE._ACP)1;
                                        continue;
                                    }
                                }
                                bool flag57 = line[i] == '\'';
                                if (flag57)
                                {
                                    SyntaxToken syntaxToken2 = _be3.ScanCharLiteral(line, ref i);
                                    list.Add(syntaxToken2);
                                    syntaxToken2.AIGN = formatedLine;
                                }
                                else
                                {
                                    bool flag58 = line[i] == '"';
                                    if (flag58)
                                    {
                                        SyntaxToken syntaxToken2 = _be3.ScanStringLiteral(line, ref i);
                                        list.Add(syntaxToken2);
                                        syntaxToken2.AIGN = formatedLine;
                                    }
                                    else
                                    {
                                        bool flag59 = (line[i] >= '0' && line[i] <= '9') || (i < length - 1 && line[i] == '.' && line[i + 1] >= '0' && line[i + 1] <= '9');
                                        if (flag59)
                                        {
                                            SyntaxToken syntaxToken2 = _be3.ScanNumericLiteral(line, ref i);
                                            bool flag60 = syntaxToken2.text == "2D" || syntaxToken2.text == "2d" || syntaxToken2.text == "3D" || syntaxToken2.text == "3d";
                                            if (flag60)
                                            {
                                                syntaxToken2.tokenKind = SyntaxToken.Kind.Identifier;
                                            }
                                            list.Add(syntaxToken2);
                                            syntaxToken2.AIGN = formatedLine;
                                        }
                                        else
                                        {
                                            SyntaxToken syntaxToken2 = this.ScanIdentifierOrKeyword(line, ref i);
                                            bool flag61 = syntaxToken2 != null;
                                            if (flag61)
                                            {
                                                list.Add(syntaxToken2);
                                                syntaxToken2.AIGN = formatedLine;
                                            }
                                            else
                                            {
                                                int num2 = i++;
                                                bool flag62 = i < line.Length;
                                                if (flag62)
                                                {
                                                    char c2 = line[num2];
                                                    char c3 = c2;
                                                    if (c3 <= '/')
                                                    {
                                                        if (c3 == '!')
                                                        {
                                                            goto IL_0CC2;
                                                        }
                                                        switch (c3)
                                                        {
                                                            case '%':
                                                            case '*':
                                                            case '/':
                                                                goto IL_0CC2;
                                                            case '&':
                                                                {
                                                                    bool flag63 = line[i] == '=' || line[i] == '&';
                                                                    if (flag63)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case '+':
                                                                {
                                                                    bool flag64 = line[i] == '+' || line[i] == '=' || line[i] == '>';
                                                                    if (flag64)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case '-':
                                                                {
                                                                    bool flag65 = line[i] == '-' || line[i] == '=';
                                                                    if (flag65)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        switch (c3)
                                                        {
                                                            case ':':
                                                                {
                                                                    bool flag66 = line[i] == ':';
                                                                    if (flag66)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case ';':
                                                                break;
                                                            case '<':
                                                                {
                                                                    bool flag67 = line[i] == '=';
                                                                    if (flag67)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag68 = line[i] == '<';
                                                                        if (flag68)
                                                                        {
                                                                            i++;
                                                                            bool flag69 = i < line.Length && line[i] == '=';
                                                                            if (flag69)
                                                                            {
                                                                                i++;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                            case '=':
                                                                {
                                                                    bool flag70 = line[i] == '=' || line[i] == '>';
                                                                    if (flag70)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case '>':
                                                                {
                                                                    bool flag71 = line[i] == '=';
                                                                    if (flag71)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag72 = i < line.Length && line[i] == '>';
                                                                        if (flag72)
                                                                        {
                                                                            i++;
                                                                            bool flag73 = line[i] == '=';
                                                                            if (flag73)
                                                                            {
                                                                                i++;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                            case '?':
                                                                {
                                                                    bool flag74 = line[i] == '?';
                                                                    if (flag74)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            default:
                                                                if (c3 == '^')
                                                                {
                                                                    goto IL_0CC2;
                                                                }
                                                                if (c3 == '|')
                                                                {
                                                                    bool flag75 = line[i] == '=' || line[i] == '|';
                                                                    if (flag75)
                                                                    {
                                                                        i++;
                                                                    }
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    goto IL_0CF1;
                                                IL_0CC2:
                                                    bool flag76 = line[i] == '=';
                                                    if (flag76)
                                                    {
                                                        i++;
                                                    }
                                                }
                                            IL_0CF1:
                                                list.Add(new SyntaxToken(SyntaxToken.Kind.Punctuator, line.Substring(num2, i - num2))
                                                {
                                                    AIGN = formatedLine
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060001FB RID: 507 RVA: 0x0001AFF4 File Offset: 0x000191F4
        private SyntaxToken ScanIdentifierOrKeyword(string line, ref int startAt)
        {
            bool flag = false;
            int i = startAt;
            bool flag2 = i >= line.Length;
            SyntaxToken syntaxToken;
            if (flag2)
            {
                syntaxToken = null;
            }
            else
            {
                char c = line[i];
                bool flag3 = !char.IsLetter(c) && c != '_';
                if (flag3)
                {
                    syntaxToken = null;
                }
                else
                {
                    for (i++; i < line.Length; i++)
                    {
                        bool flag4 = char.IsLetterOrDigit(line, i) || line[i] == '_';
                        if (!flag4)
                        {
                            break;
                        }
                    }
                    string text = line.Substring(startAt, i - startAt);
                    startAt = i;
                    SyntaxToken syntaxToken2 = new SyntaxToken(flag ? SyntaxToken.Kind.Identifier : SyntaxToken.Kind.Keyword, text);
                    bool flag5 = syntaxToken2.tokenKind == SyntaxToken.Kind.Keyword && !this.IsKeyword(syntaxToken2.text) && !this.IsBuiltInType(syntaxToken2.text);
                    if (flag5)
                    {
                        syntaxToken2.tokenKind = SyntaxToken.Kind.Identifier;
                    }
                    syntaxToken = syntaxToken2;
                }
            }
            return syntaxToken;
        }

        // Token: 0x060001FC RID: 508 RVA: 0x0001B0EC File Offset: 0x000192EC
        private bool IsKeyword(string word)
        {
            return Array.BinarySearch<string>(FLCK._ARG, word, StringComparer.OrdinalIgnoreCase) >= 0;
        }

        // Token: 0x060001FD RID: 509 RVA: 0x0001B114 File Offset: 0x00019314
        private bool IsOperator(string text)
        {
            return FLCK._ARH.Contains(text);
        }

        // Token: 0x04000242 RID: 578
        private static readonly HashSet<string> _ABM = new HashSet<string>(FLCK._ARG);

        // Token: 0x04000243 RID: 579
        private static readonly string[] _ARG = new string[]
        {
            "AlphaTest", "Ambient", "Bind", "BindChannels", "Blend", "BorderScale", "Category", "CGINCLUDE", "CGPROGRAM", "ColorMask",
            "ColorMaterial", "Combine", "ConstantColor", "Cull", "Density", "Diffuse", "Emission", "ENDCG", "Fallback", "Fog",
            "GLSLEND", "GLSLPROGRAM", "GrabPass", "Lerp", "Lighting", "LightmapMode", "LightMode", "LightTexCount", "LOD", "Material",
            "Matrix", "Mode", "Name", "Offset", "Pass", "Properties", "RequireOptions", "SeparateSpecular", "SetTexture", "Shader",
            "Shininess", "Specular", "SubShader", "Tags", "TexGen", "TextureScale", "TextureSize", "UsePass", "ZTest", "ZWrite"
        };

        // Token: 0x04000244 RID: 580
        private static readonly HashSet<string> _ARH = new HashSet<string>
        {
            "++", "--", "->", "+", "-", "!", "~", "++", "--", "&",
            "*", "/", "%", "+", "-", "<<", ">>", "<", ">", "<=",
            ">=", "==", "!=", "&", "^", "|", "&&", "||", "??", "?",
            "::", ":", "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=",
            "^=", "<<=", ">>=", "=>"
        };

        // Token: 0x04000245 RID: 581
        private static readonly HashSet<string> _ACQ = new HashSet<string>
        {
            "define", "elif", "else", "endif", "error", "if", "ifdef", "ifndef", "include", "pragma",
            "undef"
        };

        // Token: 0x04000246 RID: 582
        private static readonly string[] _ABO = new string[]
        {
            "2D", "3D", "Color", "Constant", "Cube", "Float", "Float2", "Float3", "Float4", "Previous",
            "Primary", "Range", "Rect", "Texture", "Vector", "_CosTime", "_CubeNormalize", "_Light2World", "_ModelLightColor", "_Object2Light",
            "_Object2World", "_ObjectSpaceCameraPos", "_ObjectSpaceLightPos", "_ProjectionParams", "_SinTime", "_SpecFalloff", "_SpecularLightColor", "_Time", "_World2Light", "_World2Object"
        };

        // Token: 0x04000247 RID: 583
        protected static readonly HashSet<string> _ARE = new HashSet<string>(FLCK._ARF);

        // Token: 0x04000248 RID: 584
        protected static readonly string[] _ARF = new string[]
        {
            "A", "Always", "AmbientAndDiffuse", "AppDstAdd", "AppSrcAdd", "Back", "CubeNormal", "CubeReflect", "DstAlpha", "DstColor",
            "Emission", "EyeLinear", "Exp", "Exp2", "Front", "GEqual", "Greater", "LEqual", "Less", "Linear",
            "None", "Normal", "NotEqual", "ObjectLinear", "Off", "On", "One", "OneMinusDstAlpha", "OneMinusDstColor", "OneMinusSrcAlpha",
            "OneMinusSrcColor", "Pixel", "PixelOnly", "PixelOrNone", "RGB", "SoftVegetation", "SrcAlpha", "SrcColor", "SphereMap", "Vertex",
            "VertexAndPixel", "VertexOnly", "VertexOrNone", "VertexOrPixel", "Tangent", "Texcoord", "Texcoord0", "Texcoord1", "Zero"
        };
    }
}
