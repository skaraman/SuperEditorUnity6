using System;
using System.Collections.Generic;
using SuperEditor;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000052 RID: 82
    internal class _b6 : _be3
    {
        // Token: 0x17000019 RID: 25
        // (get) Token: 0x0600025D RID: 605 RVA: 0x0001FC24 File Offset: 0x0001DE24
        public override HashSet<string> Keywords
        {
            get
            {
                return _b6._ABM;
            }
        }

        // Token: 0x1700001A RID: 26
        // (get) Token: 0x0600025E RID: 606 RVA: 0x0001FC3C File Offset: 0x0001DE3C
        public override HashSet<string> BuiltInLiterals
        {
            get
            {
                return _be3._ABN;
            }
        }

        // Token: 0x0600025F RID: 607 RVA: 0x0001FC54 File Offset: 0x0001DE54
        public override bool IsBuiltInType(string word)
        {
            return Array.BinarySearch<string>(_b6._ABO, word, StringComparer.Ordinal) >= 0;
        }

        // Token: 0x06000260 RID: 608 RVA: 0x0001FC7C File Offset: 0x0001DE7C
        public override bool IsBuiltInLiteral(string word)
        {
            return word == "true" || word == "false" || word == "null";
        }

        // Token: 0x06000262 RID: 610 RVA: 0x000201C4 File Offset: 0x0001E3C4
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
                                        bool flag10 = syntaxToken.text == "string" || syntaxToken.text == "object";
                                        if (flag10)
                                        {
                                            syntaxToken.style = this._ABQ._ABT._ACI;
                                        }
                                        else
                                        {
                                            syntaxToken.style = this._ABQ._ABT._ACJ;
                                        }
                                    }
                                    else
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ACK;
                                    }
                                    break;
                                }
                            case SyntaxToken.Kind.Identifier:
                                {
                                    bool flag11 = this.IsBuiltInLiteral(syntaxToken.text);
                                    if (flag11)
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ACL;
                                        syntaxToken.tokenKind = SyntaxToken.Kind.BuiltInLiteral;
                                    }
                                    else
                                    {
                                        bool flag12 = base.IsUnityType(syntaxToken.text);
                                        if (flag12)
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

        // Token: 0x06000263 RID: 611 RVA: 0x000205E4 File Offset: 0x0001E7E4
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
                bool flag3 = false;
                bool flag4 = false;
                bool flag5 = true;
                SyntaxToken syntaxToken2 = _be3.ScanWord(line, ref i);
                bool flag6 = !_b6._ACQ.Contains(syntaxToken2.text);
                if (flag6)
                {
                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorDirectiveExpected;
                    list.Add(syntaxToken2);
                    syntaxToken2.AIGN = formatedLine;
                    flag3 = true;
                }
                else
                {
                    syntaxToken2.tokenKind = SyntaxToken.Kind.Preprocessor;
                    list.Add(syntaxToken2);
                    syntaxToken2.AIGN = formatedLine;
                    syntaxToken = _be3.ScanWhitespace(line, ref i);
                    bool flag7 = syntaxToken != null;
                    if (flag7)
                    {
                        list.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag8 = syntaxToken2.text == "if";
                    if (flag8)
                    {
                        bool flag9 = base.ParsePPOrExpression(line, formatedLine, ref i);
                        bool flag10 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                        bool flag11 = flag9 && !flag10;
                        if (flag11)
                        {
                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)2);
                            flag4 = true;
                        }
                        else
                        {
                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)7);
                            flag4 = true;
                        }
                    }
                    else
                    {
                        bool flag12 = syntaxToken2.text == "elif";
                        if (flag12)
                        {
                            bool flag13 = base.ParsePPOrExpression(line, formatedLine, ref i);
                            bool flag14 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                            bool flag15 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8;
                            if (flag15)
                            {
                                base.OpenRegion(formatedLine, (GCE._ABW._ABX)8);
                            }
                            else
                            {
                                bool flag16 = formatedLine._ABZ._AT == (GCE._ABW._ABX)7;
                                if (flag16)
                                {
                                    flag14 = formatedLine._ABZ.OOME._AT > (GCE._ABW._ABX)5;
                                    bool flag17 = flag13 && !flag14;
                                    if (flag17)
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
                            bool flag18 = syntaxToken2.text == "else";
                            if (flag18)
                            {
                                bool flag19 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3;
                                if (flag19)
                                {
                                    base.OpenRegion(formatedLine, (GCE._ABW._ABX)9);
                                }
                                else
                                {
                                    bool flag20 = formatedLine._ABZ._AT == (GCE._ABW._ABX)7 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8;
                                    if (flag20)
                                    {
                                        bool flag21 = formatedLine._ABZ.OOME._AT > (GCE._ABW._ABX)5;
                                        bool flag22 = flag21;
                                        if (flag22)
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
                                bool flag23 = syntaxToken2.text == "endif";
                                if (flag23)
                                {
                                    bool flag24 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3 || formatedLine._ABZ._AT == (GCE._ABW._ABX)4 || formatedLine._ABZ._AT == (GCE._ABW._ABX)7 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8 || formatedLine._ABZ._AT == (GCE._ABW._ABX)9;
                                    if (flag24)
                                    {
                                        base.CloseRegion(formatedLine);
                                    }
                                    else
                                    {
                                        syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag25 = !flag5;
                if (flag25)
                {
                    syntaxToken = _be3.ScanWhitespace(line, ref i);
                    bool flag26 = syntaxToken != null;
                    if (flag26)
                    {
                        list.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag27 = i < length;
                    if (flag27)
                    {
                        string text = line.Substring(i);
                        text.TrimEnd(new char[] { ' ', '\t' });
                        list.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, text)
                        {
                            AIGN = formatedLine
                        });
                        i = length - text.Length;
                        bool flag28 = i < length;
                        if (flag28)
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
                        bool flag29 = syntaxToken != null;
                        if (flag29)
                        {
                            list.Add(syntaxToken);
                            syntaxToken.AIGN = formatedLine;
                        }
                        else
                        {
                            char c = line[i];
                            bool flag30 = i < length - 1 && c == '/' && line[i + 1] == '/';
                            if (flag30)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                break;
                            }
                            bool flag31 = flag4;
                            if (flag31)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorCommentExpected, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                break;
                            }
                            bool flag32 = char.IsLetterOrDigit(c) || c == '_';
                            if (flag32)
                            {
                                syntaxToken2 = _be3.ScanWord(line, ref i);
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                list.Add(syntaxToken2);
                                syntaxToken2.AIGN = formatedLine;
                            }
                            else
                            {
                                bool flag33 = c == '"';
                                if (flag33)
                                {
                                    syntaxToken2 = _be3.ScanStringLiteral(line, ref i);
                                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                    list.Add(syntaxToken2);
                                    syntaxToken2.AIGN = formatedLine;
                                }
                                else
                                {
                                    bool flag34 = c == '\'';
                                    if (flag34)
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
                            bool flag35 = flag3;
                            if (flag35)
                            {
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorDirectiveExpected;
                            }
                        }
                    }
                }
            }
            else
            {
                bool flag36 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                while (i < length)
                {
                    GCE._ACP _ACR = formatedLine._ACO;
                    GCE._ACP _ACS = _ACR;
                    if (_ACS != (GCE._ACP)0)
                    {
                        if (_ACS == (GCE._ACP)1)
                        {
                            int num = line.IndexOf("*/", i, StringComparison.Ordinal);
                            bool flag37 = num == -1;
                            if (flag37)
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
                        bool flag38 = syntaxToken != null;
                        if (flag38)
                        {
                            list.Add(syntaxToken);
                            syntaxToken.AIGN = formatedLine;
                        }
                        else
                        {
                            bool flag39 = flag36;
                            if (flag39)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                i = length;
                            }
                            else
                            {
                                bool flag40 = line[i] == '/' && i < length - 1;
                                if (flag40)
                                {
                                    bool flag41 = line[i + 1] == '/';
                                    if (flag41)
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
                                    bool flag42 = line[i + 1] == '*';
                                    if (flag42)
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
                                bool flag43 = line[i] == '\'';
                                if (flag43)
                                {
                                    SyntaxToken syntaxToken2 = _be3.ScanCharLiteral(line, ref i);
                                    list.Add(syntaxToken2);
                                    syntaxToken2.AIGN = formatedLine;
                                }
                                else
                                {
                                    bool flag44 = line[i] == '"';
                                    if (flag44)
                                    {
                                        SyntaxToken syntaxToken2 = _be3.ScanStringLiteral(line, ref i);
                                        list.Add(syntaxToken2);
                                        syntaxToken2.AIGN = formatedLine;
                                    }
                                    else
                                    {
                                        bool flag45 = (line[i] >= '0' && line[i] <= '9') || (i < length - 1 && line[i] == '.' && line[i + 1] >= '0' && line[i + 1] <= '9');
                                        if (flag45)
                                        {
                                            SyntaxToken syntaxToken2 = _be3.ScanNumericLiteral_JS(line, ref i);
                                            list.Add(syntaxToken2);
                                            syntaxToken2.AIGN = formatedLine;
                                        }
                                        else
                                        {
                                            SyntaxToken syntaxToken2 = this.ScanIdentifierOrKeyword(line, ref i);
                                            bool flag46 = syntaxToken2 != null;
                                            if (flag46)
                                            {
                                                list.Add(syntaxToken2);
                                                syntaxToken2.AIGN = formatedLine;
                                            }
                                            else
                                            {
                                                int num2 = i++;
                                                bool flag47 = i < line.Length;
                                                if (flag47)
                                                {
                                                    char c2 = line[num2];
                                                    char c3 = c2;
                                                    if (c3 <= '/')
                                                    {
                                                        if (c3 == '!')
                                                        {
                                                            goto IL_0A37;
                                                        }
                                                        switch (c3)
                                                        {
                                                            case '%':
                                                            case '*':
                                                            case '/':
                                                                goto IL_0A37;
                                                            case '&':
                                                                {
                                                                    bool flag48 = line[i] == '=' || line[i] == '&';
                                                                    if (flag48)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case '+':
                                                                {
                                                                    bool flag49 = line[i] == '+' || line[i] == '=' || line[i] == '>';
                                                                    if (flag49)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case '-':
                                                                {
                                                                    bool flag50 = line[i] == '-' || line[i] == '=';
                                                                    if (flag50)
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
                                                                    bool flag51 = line[i] == ':';
                                                                    if (flag51)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case ';':
                                                                break;
                                                            case '<':
                                                                {
                                                                    bool flag52 = line[i] == '=';
                                                                    if (flag52)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag53 = line[i] == '<';
                                                                        if (flag53)
                                                                        {
                                                                            i++;
                                                                            bool flag54 = i < line.Length && line[i] == '=';
                                                                            if (flag54)
                                                                            {
                                                                                i++;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                            case '=':
                                                                {
                                                                    bool flag55 = line[i] == '=' || line[i] == '>';
                                                                    if (flag55)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            case '>':
                                                                {
                                                                    bool flag56 = line[i] == '=';
                                                                    if (flag56)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag57 = i < line.Length && line[i] == '>';
                                                                        if (flag57)
                                                                        {
                                                                            i++;
                                                                            bool flag58 = line[i] == '=';
                                                                            if (flag58)
                                                                            {
                                                                                i++;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;
                                                                }
                                                            case '?':
                                                                {
                                                                    bool flag59 = line[i] == '?';
                                                                    if (flag59)
                                                                    {
                                                                        i++;
                                                                    }
                                                                    break;
                                                                }
                                                            default:
                                                                if (c3 == '^')
                                                                {
                                                                    goto IL_0A37;
                                                                }
                                                                if (c3 == '|')
                                                                {
                                                                    bool flag60 = line[i] == '=' || line[i] == '|';
                                                                    if (flag60)
                                                                    {
                                                                        i++;
                                                                    }
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    goto IL_0A66;
                                                IL_0A37:
                                                    bool flag61 = line[i] == '=';
                                                    if (flag61)
                                                    {
                                                        i++;
                                                    }
                                                }
                                            IL_0A66:
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

        // Token: 0x06000264 RID: 612 RVA: 0x000210F4 File Offset: 0x0001F2F4
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

        // Token: 0x06000265 RID: 613 RVA: 0x000211EC File Offset: 0x0001F3EC
        private bool IsKeyword(string word)
        {
            return _b6._ABM.Contains(word);
        }

        // Token: 0x06000266 RID: 614 RVA: 0x0002120C File Offset: 0x0001F40C
        private bool IsOperator(string text)
        {
            return _b6._ACT.Contains(text);
        }

        // Token: 0x0400028B RID: 651
        private static readonly HashSet<string> _ABM = new HashSet<string>
        {
            "abstract", "else", "instanceof", "super", "enum", "switch", "break", "static", "export", "interface",
            "synchronized", "extends", "let", "this", "case", "with", "throw", "catch", "final", "native",
            "throws", "finally", "new", "transient", "class", "const", "for", "package", "try", "continue",
            "private", "typeof", "debugger", "goto", "protected", "default", "if", "public", "delete", "implements",
            "return", "volatile", "do", "import", "while", "in", "function"
        };

        // Token: 0x0400028C RID: 652
        private static readonly HashSet<string> _ACT = new HashSet<string>
        {
            "++", "--", "->", "+", "-", "!", "~", "++", "--", "&",
            "*", "/", "%", "+", "-", "<<", ">>", "<", ">", "<=",
            ">=", "==", "!=", "&", "^", "|", "&&", "||", "??", "?",
            "::", ":", "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=",
            "^=", "<<=", ">>=", "=>"
        };

        // Token: 0x0400028D RID: 653
        private static readonly HashSet<string> _ACQ = new HashSet<string> { "elif", "else", "endif", "if", "pragma" };

        // Token: 0x0400028E RID: 654
        private static readonly string[] _ABO = new string[] { "boolean", "byte", "char", "double", "float", "int", "long", "short", "var", "void" };
    }
}
