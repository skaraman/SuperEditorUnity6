using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200004A RID: 74
    internal class _bd5 : _be3
    {
        // Token: 0x17000011 RID: 17
        // (get) Token: 0x060001FF RID: 511 RVA: 0x0001B13C File Offset: 0x0001933C
        public override HashSet<string> Keywords
        {
            get
            {
                return _bd5._ABM;
            }
        }

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x06000200 RID: 512 RVA: 0x0001B154 File Offset: 0x00019354
        public override HashSet<string> BuiltInLiterals
        {
            get
            {
                return _be3._ABN;
            }
        }

        // Token: 0x06000201 RID: 513 RVA: 0x0001B16C File Offset: 0x0001936C
        public override bool IsBuiltInType(string word)
        {
            return _bd5._ABO.Contains(word);
        }

        // Token: 0x06000202 RID: 514 RVA: 0x0001B18C File Offset: 0x0001938C
        public override bool IsBuiltInLiteral(string word)
        {
            return word == "true" || word == "false" || word == "null";
        }

        // Token: 0x06000203 RID: 515 RVA: 0x0001B1C8 File Offset: 0x000193C8
        static _bd5()
        {
            _bd5._AQO.UnionWith(_bd5._ABM);
            _bd5._AQO.UnionWith(_bd5._ABO);
        }

        // Token: 0x06000204 RID: 516 RVA: 0x0001B8B4 File Offset: 0x00019AB4
        protected override void ParseAll(string bufferName)
        {
            _bm2._AJS _AQP = _bm2._AJS.New(_bm2._AGM(), this._ABQ._AQQ, bufferName);
            base._AQR(_bm2._AGM().ParseAll(_AQP));
            _AQP.Delete();
        }

        // Token: 0x06000205 RID: 517 RVA: 0x0001B8F4 File Offset: 0x00019AF4
        public override _bh2._AJH MoveAfterLeaf(_bb4.DHBA leaf)
        {
            _bm2._AJS _AQP = _bm2._AJS.New(_bm2._AGM(), this._ABQ._AQQ, this._AMO);
            _bm2._AJS _AQP2 = ((leaf == null) ? _AQP : (_AQP.MoveAfterLeaf(leaf) ? _AQP : null));
            bool flag = _AQP2 == null;
            if (flag)
            {
                _AQP.Delete();
            }
            return _AQP2;
        }

        // Token: 0x06000206 RID: 518 RVA: 0x0001B948 File Offset: 0x00019B48
        public override bool ParseLines(int fromLine, int toLineInclusive)
        {
            GCE.PHFG[] _AQS = this._ABQ._AQQ;
            for (int i = Math.Max(0, fromLine); i <= toLineInclusive; i++)
            {
                List<SyntaxToken> _ABS = _AQS[i].EOIA;
                int count = _ABS.Count;
                while (count-- > 0)
                {
                    SyntaxToken syntaxToken = _ABS[count];
                    bool flag = syntaxToken.tokenKind == SyntaxToken.Kind.Missing;
                    if (flag)
                    {
                        bool flag2 = syntaxToken.OOME != null && syntaxToken.OOME.OOME != null;
                        if (flag2)
                        {
                            syntaxToken.OOME.OOME._AJB = null;
                        }
                        _ABS.RemoveAt(count);
                    }
                }
            }
            _bm2._AJS _AQP = _bm2._AJS.New(_bm2._AGM(), _AQS, this._AMO);
            _AQP.MoveToLine(fromLine, base._AQT());
            _bm2 _CBF = _bm2._AGM();
            bool flag3 = true;
            int num = Math.Max(0, _AQP.CurrentLine() - 1);
            while (flag3 && num <= toLineInclusive)
            {
                flag3 = _CBF.ParseLine(_AQP, num);
                num = _AQP.CurrentLine() - 1;
            }
            bool flag4 = flag3 && toLineInclusive == _AQS.Length - 1;
            if (flag4)
            {
                flag3 = _CBF.GetParser.ParseStep(_AQP);
            }
            _AQP.Delete();
            for (int j = fromLine; j <= toLineInclusive; j++)
            {
                foreach (SyntaxToken syntaxToken2 in _AQS[j].EOIA)
                {
                    bool flag5 = syntaxToken2.tokenKind == SyntaxToken.Kind.ContextualKeyword;
                    if (flag5)
                    {
                        syntaxToken2.style = ((syntaxToken2.text == "value") ? this._ABQ._ABT._CEX : this._ABQ._ABT._ACK);
                    }
                }
            }
            return flag3;
        }

        // Token: 0x06000207 RID: 519 RVA: 0x0001BB50 File Offset: 0x00019D50
        public override void FullRefresh()
        {
            base.FullRefresh();
            this._ABP = new Thread((ThreadStart)delegate
            {
                base.OnLoaded();
                this._ABP = null;
            });
            this._ABP.Start();
        }

        // Token: 0x06000208 RID: 520 RVA: 0x0001BB80 File Offset: 0x00019D80
        protected static HashSet<string> GetActiveScriptCompilationDefines()
        {
            bool flag = _bd5._AQV != null;
            HashSet<string> hashSet;
            if (flag)
            {
                hashSet = _bd5._AQV;
            }
            else
            {
                _bd5._AQV = new HashSet<string>(EditorUserBuildSettings.activeScriptCompilationDefines);
                string text = null;
                try
                {
                    string text2 = null;
                    for (int i = 0; i < _bd5._AQW.Length; i++)
                    {
                        bool flag2 = File.Exists(_bd5._AQW[i]);
                        if (flag2)
                        {
                            text2 = _bd5._AQW[i];
                            break;
                        }
                    }
                    bool flag3 = text2 != null;
                    if (flag3)
                    {
                        text = File.ReadAllText(text2);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
                bool flag4 = text != null;
                if (flag4)
                {
                    string[] array = text.Split(_bd5._AQX, StringSplitOptions.RemoveEmptyEntries);
                    int num = array.Length;
                    while (num-- > 0)
                    {
                        string text3 = array[num];
                        bool flag5 = text3.StartsWith("-define:", StringComparison.OrdinalIgnoreCase) || text3.StartsWith("/define:", StringComparison.OrdinalIgnoreCase);
                        if (flag5)
                        {
                            text3 = text3.Substring("-define:".Length);
                        }
                        else
                        {
                            bool flag6 = text3.StartsWith("-d:", StringComparison.OrdinalIgnoreCase) || text3.StartsWith("/d:", StringComparison.OrdinalIgnoreCase);
                            if (!flag6)
                            {
                                continue;
                            }
                            text3 = text3.Substring("-d:".Length);
                        }
                        string[] array2 = text3.Split(_bd5._AQY, StringSplitOptions.RemoveEmptyEntries);
                        int num2 = array2.Length;
                        while (num2-- > 0)
                        {
                            _bd5._AQV.Add(array2[num2]);
                        }
                    }
                }
                hashSet = _bd5._AQV;
            }
            return hashSet;
        }

        // Token: 0x06000209 RID: 521 RVA: 0x0001BD2C File Offset: 0x00019F2C
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
                HashSet<string> activeScriptCompilationDefines = _bd5.GetActiveScriptCompilationDefines();
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
                            case SyntaxToken.Kind.InterpolatedStringWholeLiteral:
                            case SyntaxToken.Kind.InterpolatedStringStartLiteral:
                            case SyntaxToken.Kind.InterpolatedStringMidLiteral:
                            case SyntaxToken.Kind.InterpolatedStringEndLiteral:
                            case SyntaxToken.Kind.InterpolatedStringFormatLiteral:
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
                                    bool flag11 = syntaxToken.text == "true" || syntaxToken.text == "false" || syntaxToken.text == "null";
                                    if (flag11)
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ACL;
                                        syntaxToken.tokenKind = SyntaxToken.Kind.BuiltInLiteral;
                                    }
                                    else
                                    {
                                        syntaxToken.style = this._ABQ._ABT._ABV;
                                    }
                                    break;
                                }
                        }
                        _ABS[i] = syntaxToken;
                    }
                }
            }
        }

        // Token: 0x0600020A RID: 522 RVA: 0x0001C14C File Offset: 0x0001A34C
        protected override void Tokenize(string line, GCE.PHFG formatedLine)
        {
            List<SyntaxToken> list = formatedLine.EOIA ?? new List<SyntaxToken>();
            formatedLine.EOIA = list;
            list.Clear();
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
                bool flag7 = !_bd5._ACQ.Contains(syntaxToken2.text);
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
                            bool flag14 = formatedLine._ABZ.OOME == null;
                            if (flag14)
                            {
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                            }
                            else
                            {
                                bool flag15 = base.ParsePPOrExpression(line, formatedLine, ref i);
                                bool flag16 = formatedLine._ABZ.OOME._AT > (GCE._ABW._ABX)5;
                                bool flag17 = flag15 && !flag16;
                                bool flag18 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2;
                                if (flag18)
                                {
                                    flag17 = false;
                                }
                                else
                                {
                                    bool flag19 = formatedLine._ABZ._AT == (GCE._ABW._ABX)3 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8;
                                    if (flag19)
                                    {
                                        bool flag20 = flag17 && formatedLine._ABZ.OOME != null;
                                        if (flag20)
                                        {
                                            int _AQZ = formatedLine.JIKB;
                                            int num = -1;
                                            int num2 = -1;
                                            List<GCE._ABW> _ARA = formatedLine._ABZ.OOME._ARB;
                                            int count = _ARA.Count;
                                            while (count-- > 0)
                                            {
                                                GCE.PHFG _ARC = _ARA[count]._ABI;
                                                int _AQZ2 = _ARC.JIKB;
                                                bool flag21 = _AQZ2 < _AQZ;
                                                if (flag21)
                                                {
                                                    bool flag22 = _AQZ2 > num2 && _ARC._ABZ._AT < (GCE._ABW._ABX)5;
                                                    if (flag22)
                                                    {
                                                        num2 = _AQZ2;
                                                    }
                                                    bool flag23 = _AQZ2 > num && (_ARC._ABZ._AT == (GCE._ABW._ABX)2 || _ARC._ABZ._AT == (GCE._ABW._ABX)7);
                                                    if (flag23)
                                                    {
                                                        num = _AQZ2;
                                                    }
                                                }
                                            }
                                            bool flag24 = num2 >= num;
                                            if (flag24)
                                            {
                                                flag17 = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bool flag25 = formatedLine._ABZ._AT != (GCE._ABW._ABX)7;
                                        if (flag25)
                                        {
                                            syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                            flag17 = !flag16;
                                        }
                                    }
                                }
                                bool flag26 = syntaxToken2.tokenKind != SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                if (flag26)
                                {
                                    bool flag27 = flag17;
                                    if (flag27)
                                    {
                                        base.OpenRegion(formatedLine, (GCE._ABW._ABX)3);
                                    }
                                    else
                                    {
                                        base.OpenRegion(formatedLine, (GCE._ABW._ABX)8);
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool flag28 = syntaxToken2.text == "else";
                            if (flag28)
                            {
                                bool flag29 = formatedLine._ABZ.OOME == null;
                                if (flag29)
                                {
                                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                }
                                else
                                {
                                    bool flag30 = formatedLine._ABZ.OOME._AT > (GCE._ABW._ABX)5;
                                    bool flag31 = !flag30;
                                    bool flag32 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3;
                                    if (flag32)
                                    {
                                        flag31 = false;
                                    }
                                    else
                                    {
                                        bool flag33 = formatedLine._ABZ._AT == (GCE._ABW._ABX)7 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8;
                                        if (flag33)
                                        {
                                            bool flag34 = flag31;
                                            if (flag34)
                                            {
                                                int _AQZ3 = formatedLine.JIKB;
                                                int num3 = -1;
                                                int num4 = -1;
                                                List<GCE._ABW> _ARA2 = formatedLine._ABZ.OOME._ARB;
                                                int count2 = _ARA2.Count;
                                                while (count2-- > 0)
                                                {
                                                    GCE.PHFG _ARC2 = _ARA2[count2]._ABI;
                                                    int _AQZ4 = _ARC2.JIKB;
                                                    bool flag35 = _AQZ4 < _AQZ3;
                                                    if (flag35)
                                                    {
                                                        bool flag36 = _AQZ4 > num4 && _ARC2._ABZ._AT < (GCE._ABW._ABX)5;
                                                        if (flag36)
                                                        {
                                                            num4 = _AQZ4;
                                                        }
                                                        bool flag37 = _AQZ4 > num3 && (_ARC2._ABZ._AT == (GCE._ABW._ABX)2 || _ARC2._ABZ._AT == (GCE._ABW._ABX)7);
                                                        if (flag37)
                                                        {
                                                            num3 = _AQZ4;
                                                        }
                                                    }
                                                }
                                                bool flag38 = num4 >= num3;
                                                if (flag38)
                                                {
                                                    flag31 = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            bool flag39 = formatedLine._ABZ._AT != (GCE._ABW._ABX)7;
                                            if (flag39)
                                            {
                                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                            }
                                        }
                                    }
                                    bool flag40 = syntaxToken2.tokenKind != SyntaxToken.Kind.PreprocessorUnexpectedDirective;
                                    if (flag40)
                                    {
                                        bool flag41 = flag31;
                                        if (flag41)
                                        {
                                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)4);
                                        }
                                        else
                                        {
                                            base.OpenRegion(formatedLine, (GCE._ABW._ABX)9);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bool flag42 = syntaxToken2.text == "endif";
                                if (flag42)
                                {
                                    bool flag43 = formatedLine._ABZ._AT == (GCE._ABW._ABX)2 || formatedLine._ABZ._AT == (GCE._ABW._ABX)3 || formatedLine._ABZ._AT == (GCE._ABW._ABX)4 || formatedLine._ABZ._AT == (GCE._ABW._ABX)7 || formatedLine._ABZ._AT == (GCE._ABW._ABX)8 || formatedLine._ABZ._AT == (GCE._ABW._ABX)9;
                                    if (flag43)
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
                                    bool flag44 = syntaxToken2.text == "region";
                                    if (flag44)
                                    {
                                        bool flag45 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                                        bool flag46 = flag45;
                                        if (flag46)
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
                                        bool flag47 = syntaxToken2.text == "endregion";
                                        if (flag47)
                                        {
                                            bool flag48 = formatedLine._ABZ._AT == (GCE._ABW._ABX)1 || formatedLine._ABZ._AT == (GCE._ABW._ABX)6;
                                            if (flag48)
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
                                            bool flag49 = syntaxToken2.text == "define" || syntaxToken2.text == "undef";
                                            if (flag49)
                                            {
                                                SyntaxToken syntaxToken3 = _be3.ScanIdentifierOrKeyword(line, ref i);
                                                bool flag50 = syntaxToken3 != null && syntaxToken3.text != "true" && syntaxToken3.text != "false";
                                                if (flag50)
                                                {
                                                    syntaxToken3.tokenKind = SyntaxToken.Kind.PreprocessorSymbol;
                                                    formatedLine.EOIA.Add(syntaxToken3);
                                                    syntaxToken3.AIGN = formatedLine;
                                                    this._ARD = true;
                                                    bool flag51 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                                                    bool flag52 = !flag51;
                                                    if (flag52)
                                                    {
                                                        bool flag53 = syntaxToken2.text == "define";
                                                        if (flag53)
                                                        {
                                                            bool flag54 = !this._ABR.Contains(syntaxToken3.text);
                                                            if (flag54)
                                                            {
                                                                this._ABR.Add(syntaxToken3.text);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            bool flag55 = this._ABR.Contains(syntaxToken3.text);
                                                            if (flag55)
                                                            {
                                                                this._ABR.Remove(syntaxToken3.text);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                bool flag56 = syntaxToken2.text == "error" || syntaxToken2.text == "warning";
                                                if (flag56)
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
                bool flag57 = !flag6;
                if (flag57)
                {
                    syntaxToken = _be3.ScanWhitespace(line, ref i);
                    bool flag58 = syntaxToken != null;
                    if (flag58)
                    {
                        list.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag59 = i < length;
                    if (flag59)
                    {
                        string text = line.Substring(i);
                        text.TrimEnd(new char[] { ' ', '\t' });
                        list.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, text)
                        {
                            AIGN = formatedLine
                        });
                        i += text.Length;
                        bool flag60 = i < length;
                        if (flag60)
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
                        bool flag61 = syntaxToken != null;
                        if (flag61)
                        {
                            list.Add(syntaxToken);
                            syntaxToken.AIGN = formatedLine;
                        }
                        else
                        {
                            char c = line[i];
                            bool flag62 = i < length - 1 && c == '/' && line[i + 1] == '/';
                            if (flag62)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                break;
                            }
                            bool flag63 = flag5;
                            if (flag63)
                            {
                                list.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorCommentExpected, line.Substring(i))
                                {
                                    AIGN = formatedLine
                                });
                                break;
                            }
                            bool flag64 = char.IsLetterOrDigit(c) || c == '_';
                            if (flag64)
                            {
                                syntaxToken2 = _be3.ScanWord(line, ref i);
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                list.Add(syntaxToken2);
                                syntaxToken2.AIGN = formatedLine;
                            }
                            else
                            {
                                bool flag65 = c == '"';
                                if (flag65)
                                {
                                    syntaxToken2 = _be3.ScanStringLiteral(line, ref i);
                                    syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorArguments;
                                    list.Add(syntaxToken2);
                                    syntaxToken2.AIGN = formatedLine;
                                }
                                else
                                {
                                    bool flag66 = c == '\'';
                                    if (flag66)
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
                            bool flag67 = flag4;
                            if (flag67)
                            {
                                syntaxToken2.tokenKind = SyntaxToken.Kind.PreprocessorDirectiveExpected;
                            }
                        }
                    }
                }
            }
            else
            {
                bool flag68 = formatedLine._ABZ._AT > (GCE._ABW._ABX)5;
                while (i < length)
                {
                    switch (formatedLine._ACO)
                    {
                        case (GCE._ACP)0:
                            {
                                syntaxToken = _be3.ScanWhitespace(line, ref i);
                                bool flag69 = syntaxToken != null;
                                if (flag69)
                                {
                                    list.Add(syntaxToken);
                                    syntaxToken.AIGN = formatedLine;
                                }
                                else
                                {
                                    bool flag70 = flag68;
                                    if (flag70)
                                    {
                                        list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                        {
                                            AIGN = formatedLine
                                        });
                                        i = length;
                                    }
                                    else
                                    {
                                        bool flag71 = line[i] == '/' && i < length - 1;
                                        if (flag71)
                                        {
                                            bool flag72 = line[i + 1] == '/';
                                            if (flag72)
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
                                                break;
                                            }
                                            bool flag73 = line[i + 1] == '*';
                                            if (flag73)
                                            {
                                                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, "/*")
                                                {
                                                    AIGN = formatedLine
                                                });
                                                i += 2;
                                                formatedLine._ACO = (GCE._ACP)1;
                                                break;
                                            }
                                        }
                                        bool flag74 = line[i] == '\'';
                                        if (flag74)
                                        {
                                            SyntaxToken syntaxToken2 = _be3.ScanCharLiteral(line, ref i);
                                            list.Add(syntaxToken2);
                                            syntaxToken2.AIGN = formatedLine;
                                        }
                                        else
                                        {
                                            bool flag75 = line[i] == '"' || (!_bd5._AHR && line[i] == '$');
                                            if (flag75)
                                            {
                                                this.ScanStringLiteral(line, ref i, formatedLine);
                                            }
                                            else
                                            {
                                                bool flag76 = i < length - 1 && line[i] == '@' && line[i + 1] == '"';
                                                if (flag76)
                                                {
                                                    SyntaxToken syntaxToken2 = new SyntaxToken(SyntaxToken.Kind.VerbatimStringBegin, line.Substring(i, 2))
                                                    {
                                                        AIGN = formatedLine
                                                    };
                                                    list.Add(syntaxToken2);
                                                    i += 2;
                                                    formatedLine._ACO = (GCE._ACP)2;
                                                }
                                                else
                                                {
                                                    bool flag77 = (line[i] >= '0' && line[i] <= '9') || (i < length - 1 && line[i] == '.' && line[i + 1] >= '0' && line[i + 1] <= '9');
                                                    if (flag77)
                                                    {
                                                        SyntaxToken syntaxToken2 = _be3.ScanNumericLiteral(line, ref i);
                                                        list.Add(syntaxToken2);
                                                        syntaxToken2.AIGN = formatedLine;
                                                    }
                                                    else
                                                    {
                                                        SyntaxToken syntaxToken2 = this.ScanIdentifierOrKeyword(line, ref i);
                                                        bool flag78 = syntaxToken2 != null;
                                                        if (flag78)
                                                        {
                                                            list.Add(syntaxToken2);
                                                            syntaxToken2.AIGN = formatedLine;
                                                        }
                                                        else
                                                        {
                                                            int num5 = i++;
                                                            bool flag79 = i < line.Length;
                                                            if (flag79)
                                                            {
                                                                char c2 = line[i];
                                                                char c3 = line[num5];
                                                                char c4 = c3;
                                                                if (c4 <= '/')
                                                                {
                                                                    if (c4 == '!')
                                                                    {
                                                                        goto IL_0EEC;
                                                                    }
                                                                    switch (c4)
                                                                    {
                                                                        case '%':
                                                                        case '*':
                                                                        case '/':
                                                                            goto IL_0EEC;
                                                                        case '&':
                                                                            {
                                                                                bool flag80 = c2 == '=' || c2 == '&';
                                                                                if (flag80)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                        case '+':
                                                                            {
                                                                                bool flag81 = c2 == '+' || c2 == '=';
                                                                                if (flag81)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                        case '-':
                                                                            {
                                                                                bool flag82 = c2 == '-' || c2 == '=';
                                                                                if (flag82)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    switch (c4)
                                                                    {
                                                                        case ':':
                                                                            {
                                                                                bool flag83 = c2 == ':';
                                                                                if (flag83)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                        case ';':
                                                                            break;
                                                                        case '<':
                                                                            {
                                                                                bool flag84 = c2 == '=';
                                                                                if (flag84)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                else
                                                                                {
                                                                                    bool flag85 = c2 == '<';
                                                                                    if (flag85)
                                                                                    {
                                                                                        i++;
                                                                                        bool flag86 = i < line.Length && line[i] == '=';
                                                                                        if (flag86)
                                                                                        {
                                                                                            i++;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                break;
                                                                            }
                                                                        case '=':
                                                                            {
                                                                                bool flag87 = c2 == '=' || c2 == '>';
                                                                                if (flag87)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                        case '>':
                                                                            {
                                                                                bool flag88 = c2 == '=';
                                                                                if (flag88)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                        case '?':
                                                                            {
                                                                                bool flag89 = c2 == '?' || (!_bd5._AHR && (c2 == '.' || c2 == '['));
                                                                                if (flag89)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                                break;
                                                                            }
                                                                        default:
                                                                            if (c4 == '^')
                                                                            {
                                                                                goto IL_0EEC;
                                                                            }
                                                                            if (c4 == '|')
                                                                            {
                                                                                bool flag90 = c2 == '=' || c2 == '|';
                                                                                if (flag90)
                                                                                {
                                                                                    i++;
                                                                                }
                                                                            }
                                                                            break;
                                                                    }
                                                                }
                                                                goto IL_0F11;
                                                            IL_0EEC:
                                                                bool flag91 = c2 == '=';
                                                                if (flag91)
                                                                {
                                                                    i++;
                                                                }
                                                            }
                                                        IL_0F11:
                                                            list.Add(new SyntaxToken(SyntaxToken.Kind.Punctuator, line.Substring(num5, i - num5))
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
                                break;
                            }
                        case (GCE._ACP)1:
                            {
                                int num6 = line.IndexOf("*/", i, StringComparison.Ordinal);
                                bool flag92 = num6 == -1;
                                if (flag92)
                                {
                                    list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i))
                                    {
                                        AIGN = formatedLine
                                    });
                                    i = length;
                                }
                                else
                                {
                                    list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, line.Substring(i, num6 + 2 - i))
                                    {
                                        AIGN = formatedLine
                                    });
                                    i = num6 + 2;
                                    formatedLine._ACO = (GCE._ACP)0;
                                }
                                break;
                            }
                        case (GCE._ACP)2:
                            {
                                int num7 = line.IndexOf('"', i);
                                while (num7 != -1 && num7 < length - 1 && line[num7 + 1] == '"')
                                {
                                    int num8 = num7 + 2;
                                    num7 = line.IndexOf('"', num8);
                                }
                                bool flag93 = num7 == -1;
                                if (flag93)
                                {
                                    list.Add(new SyntaxToken(SyntaxToken.Kind.VerbatimStringLiteral, line.Substring(i))
                                    {
                                        AIGN = formatedLine
                                    });
                                    i = length;
                                }
                                else
                                {
                                    list.Add(new SyntaxToken(SyntaxToken.Kind.VerbatimStringLiteral, line.Substring(i, num7 - i))
                                    {
                                        AIGN = formatedLine
                                    });
                                    i = num7;
                                    list.Add(new SyntaxToken(SyntaxToken.Kind.VerbatimStringLiteral, line.Substring(i, 1))
                                    {
                                        AIGN = formatedLine
                                    });
                                    i++;
                                    formatedLine._ACO = (GCE._ACP)0;
                                }
                                break;
                            }
                    }
                }
            }
        }

        // Token: 0x0600020B RID: 523 RVA: 0x0001D1D0 File Offset: 0x0001B3D0
        private SyntaxToken ScanIdentifierOrKeyword(string line, ref int startAt)
        {
            SyntaxToken syntaxToken = _be3.ScanIdentifierOrKeyword(line, ref startAt);
            bool flag = syntaxToken != null && syntaxToken.tokenKind == SyntaxToken.Kind.Keyword && !this.IsKeywordOrBuiltInType(syntaxToken.text);
            if (flag)
            {
                syntaxToken.tokenKind = SyntaxToken.Kind.Identifier;
            }
            return syntaxToken;
        }

        // Token: 0x0600020C RID: 524 RVA: 0x0001D218 File Offset: 0x0001B418
        private bool IsKeyword(string word)
        {
            return _bd5._ABM.Contains(word);
        }

        // Token: 0x0600020D RID: 525 RVA: 0x0001D238 File Offset: 0x0001B438
        private bool IsKeywordOrBuiltInType(string word)
        {
            return _bd5._AQO.Contains(word);
        }

        // Token: 0x0600020E RID: 526 RVA: 0x0001D258 File Offset: 0x0001B458
        private bool IsOperator(string text)
        {
            return _bd5.IGCKJDOKFKPIOCGOLGLHHKHMDJGLBNPCKEJK.Contains(text);
        }

        // Token: 0x0600020F RID: 527 RVA: 0x0001D278 File Offset: 0x0001B478
        private void ScanStringLiteral(string line, ref int startAt, GCE.PHFG formatedLine)
        {
            // Check if this is an interpolated string ($"...")
            bool isInterpolatedString = startAt < line.Length && line[startAt] == '$' && 
                                       startAt + 1 < line.Length && line[startAt + 1] == '"';
            if (isInterpolatedString)
            {
                this.ScanInterpolatedStringLiteral(line, ref startAt, formatedLine);
                return;
            }

            int i;
            for (i = startAt + 1; i < line.Length; i++)
            {
                bool flag = line[i] == '"';
                if (flag)
                {
                    i++;
                    break;
                }
                bool flag2 = line[i] == '\\' && i < line.Length - 1;
                if (flag2)
                {
                    i++;
                }
            }
            bool flag3 = formatedLine != null;
            if (flag3)
            {
                SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.StringLiteral, line.Substring(startAt, i - startAt));
                formatedLine.EOIA.Add(syntaxToken);
                syntaxToken.AIGN = formatedLine;
            }
            startAt = i;
        }

        /// <summary>
        /// Find matching closing brace for balanced bracket counting
        /// </summary>
        /// <param name="line">The line to search in</param>
        /// <param name="start">Starting position (should be at opening brace)</param>
        /// <returns>Index of matching closing brace, or -1 if not found</returns>
        private int FindMatchingBrace(string line, int start)
        {
            int braceCount = 1;
            int i = start + 1;
            
            while (i < line.Length && braceCount > 0)
            {
                char c = line[i];
                if (c == '{') 
                {
                    braceCount++;
                }
                else if (c == '}') 
                {
                    braceCount--;
                }
                else if (c == '"' || c == '\'')
                {
                    // Handle string literals - skip over them to avoid counting braces inside strings
                    char quote = c;
                    i++;
                    while (i < line.Length && line[i] != quote)
                    {
                        if (line[i] == '\\' && i + 1 < line.Length)
                        {
                            i++; // Skip escaped character
                        }
                        i++;
                    }
                }
                else if (c == '/' && i + 1 < line.Length)
                {
                    // Handle comments
                    if (line[i + 1] == '/')
                    {
                        // Single line comment - skip to end
                        break;
                    }
                    else if (line[i + 1] == '*')
                    {
                        // Multi-line comment - skip until */
                        i += 2;
                        while (i + 1 < line.Length && !(line[i] == '*' && line[i + 1] == '/'))
                        {
                            i++;
                        }
                        if (i + 1 < line.Length) i++; // Skip the '/'
                    }
                }
                i++;
            }
            
            return braceCount == 0 ? i - 1 : -1;
        }

        /// <summary>
        /// Scan the start of an interpolated string ($" part)
        /// </summary>
        private void ScanInterpolatedStringStart(string line, int originalStartAt, int currentPos, GCE.PHFG formattedLine, SyntaxToken.Kind tokenKind)
        {
            if (formattedLine != null)
            {
                SyntaxToken syntaxToken = new SyntaxToken(tokenKind, line.Substring(originalStartAt, currentPos - originalStartAt));
                formattedLine.EOIA.Add(syntaxToken);
                syntaxToken.AIGN = formattedLine;
            }
        }

        /// <summary>
        /// Scan an expression within interpolated string ({expression} part)
        /// </summary>
        private void ScanInterpolatedStringExpression(string line, int startAt, int endAt, GCE.PHFG formattedLine)
        {
            if (formattedLine != null)
            {
                this.Tokenize(line.Substring(startAt, endAt - startAt), formattedLine);
            }
        }

        /// <summary>
        /// Scan format specifier within interpolated string ({expression:format} part)
        /// </summary>
        private void ScanInterpolatedStringFormat(string line, int formatStart, int formatEnd, GCE.PHFG formattedLine)
        {
            if (formattedLine != null)
            {
                // Add the colon punctuator
                SyntaxToken colonToken = new SyntaxToken(SyntaxToken.Kind.Punctuator, ":");
                formattedLine.EOIA.Add(colonToken);
                colonToken.AIGN = formattedLine;

                // Add the format specifier if there is content
                int formatLength = formatEnd - (formatStart + 1);
                if (formatLength > 0)
                {
                    SyntaxToken formatToken = new SyntaxToken(SyntaxToken.Kind.InterpolatedStringFormatLiteral, 
                        line.Substring(formatStart + 1, formatLength));
                    formattedLine.EOIA.Add(formatToken);
                    formatToken.AIGN = formattedLine;
                }
            }
        }

        /// <summary>
        /// Scan the end of an interpolated string (closing " and closing brace)
        /// </summary>
        private void ScanInterpolatedStringEnd(string line, int originalStartAt, int endPos, GCE.PHFG formattedLine, SyntaxToken.Kind tokenKind)
        {
            if (formattedLine != null)
            {
                SyntaxToken syntaxToken = new SyntaxToken(tokenKind, line.Substring(originalStartAt, endPos - originalStartAt));
                formattedLine.EOIA.Add(syntaxToken);
                syntaxToken.AIGN = formattedLine;
            }
        }

        // Interpolation state tracking for proper state management
        private enum InterpolationState
        {
            StringContent,
            Expression,
            FormatSpecifier
        }

        // Token: 0x06000210 RID: 528 RVA: 0x0001D314 File Offset: 0x0001B514
        private void ScanInterpolatedStringLiteral(string line, ref int startAt, GCE.PHFG formatedLine)
        {
            SyntaxToken.Kind kind = SyntaxToken.Kind.InterpolatedStringStartLiteral;
            int originalStartAt = startAt; // Preserve the original starting position
            // Fix starting position - skip both '$' and '"' directly
            int i = startAt + 2;
            
            while (i < line.Length)
            {
                char c = line[i];
                bool flag2 = c == '{';
                if (flag2)
                {
                    bool flag3 = i + 1 < line.Length && line[i + 1] == '{';
                    if (!flag3)
                    {
                        // Found start of interpolation expression
                        ScanInterpolatedStringStart(line, originalStartAt, i, formatedLine, kind);
                        kind = SyntaxToken.Kind.InterpolatedStringMidLiteral;
                        startAt = i;
                        
                        // Use the original SkipStringInterpolation logic
                        int num = this.SkipStringInterpolation(line, ref i);
                        bool flag5 = formatedLine != null;
                        if (flag5)
                        {
                            bool flag6 = num >= 0;
                            if (flag6)
                            {
                                ScanInterpolatedStringExpression(line, startAt + 1, num, formatedLine);
                                bool flag7 = line[num] == ':';
                                if (flag7)
                                {
                                    ScanInterpolatedStringFormat(line, num, i, formatedLine);
                                }
                            }
                            else
                            {
                                ScanInterpolatedStringExpression(line, startAt + 1, i, formatedLine);
                            }
                            
                            // Add closing brace token
                            bool flag9 = i < line.Length && line[i] == '}';
                            if (flag9)
                            {
                                i++;
                                SyntaxToken syntaxToken3 = new SyntaxToken(SyntaxToken.Kind.Punctuator, "}");
                                formatedLine.EOIA.Add(syntaxToken3);
                                syntaxToken3.AIGN = formatedLine;
                            }
                        }
                        
                        startAt = i;
                        continue;
                    }
                    i++; // Skip the second '{' in escaped "{{"
                }
                bool flag10 = c == '"';
                if (flag10)
                {
                    i++; // Move past the closing quote
                    break;
                }
                i++;
                bool flag11 = c == '\\' && i < line.Length;
                if (flag11)
                {
                    i++; // Skip escaped character
                }
            }
            
            // Create final token
            bool flag12 = formatedLine != null;
            if (flag12)
            {
                bool flag13 = kind == SyntaxToken.Kind.InterpolatedStringStartLiteral;
                if (flag13)
                {
                    // Whole interpolated string without any expressions
                    ScanInterpolatedStringEnd(line, originalStartAt, i, formatedLine, SyntaxToken.Kind.InterpolatedStringWholeLiteral);
                }
                else
                {
                    // End part of interpolated string
                    ScanInterpolatedStringEnd(line, originalStartAt, i, formatedLine, SyntaxToken.Kind.InterpolatedStringEndLiteral);
                }
            }
            startAt = i;
        }

        // Token: 0x06000211 RID: 529 RVA: 0x0001D5AC File Offset: 0x0001B7AC
        private int SkipStringInterpolation(string line, ref int i)
        {
            int length = line.Length;
            i++;
            while (i < length)
            {
                char c = line[i];
                bool flag = c == '}' || c == ':';
                if (flag)
                {
                    break;
                }
                bool flag2 = !this.ScanRegularBalancedText(line, ref i, true);
                if (flag2)
                {
                    break;
                }
            }
            bool flag3 = i >= length;
            int num;
            if (flag3)
            {
                num = -1;
            }
            else
            {
                bool flag4 = line[i] == ':';
                if (flag4)
                {
                    int num2 = i;
                    i++;
                    while (i < length)
                    {
                        char c2 = line[i];
                        bool flag5 = c2 == '"';
                        if (flag5)
                        {
                            break;
                        }
                        bool flag6 = c2 == '{';
                        if (flag6)
                        {
                            bool flag7 = i + 1 < line.Length && line[i + 1] == '{';
                            if (!flag7)
                            {
                                break;
                            }
                            i++;
                        }
                        else
                        {
                            bool flag8 = c2 == '}';
                            if (flag8)
                            {
                                bool flag9 = i + 1 < line.Length && line[i + 1] == '}';
                                if (!flag9)
                                {
                                    break;
                                }
                                i++;
                            }
                        }
                        i++;
                        bool flag10 = c2 == '\\';
                        if (flag10)
                        {
                            bool flag11 = i < line.Length;
                            if (!flag11)
                            {
                                break;
                            }
                            i++;
                        }
                    }
                    num = num2;
                }
                else
                {
                    num = -1;
                }
            }
            return num;
        }

        // Token: 0x06000212 RID: 530 RVA: 0x0001D720 File Offset: 0x0001B920
        private bool ScanRegularBalancedText(string line, ref int i, bool scanInterpolationFormat)
        {
            int num = i;
            int length = line.Length;
            bool flag = i >= length;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                while (i < length)
                {
                    char c = line[i];
                    bool flag3 = c == '$' || c == '"' || (c == '@' && i + 1 < length && line[i + 1] == '"');
                    if (flag3)
                    {
                        this.ScanStringLiteral(line, ref i, null);
                    }
                    else
                    {
                        bool flag4 = c == '/' && i + 1 < length;
                        if (flag4)
                        {
                            i++;
                            char c2 = line[i];
                            bool flag5 = c2 == '/';
                            if (flag5)
                            {
                                i = length;
                                break;
                            }
                            bool flag6 = c2 == '*';
                            if (flag6)
                            {
                                i++;
                                while (i < length)
                                {
                                    bool flag7 = line[i] != '*';
                                    if (flag7)
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        i++;
                                        bool flag8 = i < length && line[i] == '/';
                                        if (flag8)
                                        {
                                            i++;
                                            break;
                                        }
                                    }
                                }
                                continue;
                            }
                        }
                        else
                        {
                            bool flag9 = c == '}' || c == ')' || c == ']' || c == ':';
                            if (flag9)
                            {
                                break;
                            }
                        }
                        i++;
                        bool flag10 = c == '{';
                        if (flag10)
                        {
                            this.ScanRegularBalancedText(line, ref i, false);
                            bool flag11 = i < length && line[i] == '}';
                            if (flag11)
                            {
                                i++;
                            }
                        }
                        else
                        {
                            bool flag12 = c == '[';
                            if (flag12)
                            {
                                this.ScanRegularBalancedText(line, ref i, false);
                                bool flag13 = i < length && line[i] == ']';
                                if (flag13)
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                bool flag14 = c == '(';
                                if (flag14)
                                {
                                    this.ScanRegularBalancedText(line, ref i, false);
                                    bool flag15 = i < length && line[i] == ')';
                                    if (flag15)
                                    {
                                        i++;
                                    }
                                }
                                else
                                {
                                    bool flag16 = scanInterpolationFormat && c == ':';
                                    if (flag16)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                flag2 = i > num;
            }
            return flag2;
        }

        // Token: 0x04000249 RID: 585
        public static bool _AHR = false;

        // Token: 0x0400024A RID: 586
        private static readonly HashSet<string> _ABM = new HashSet<string>
        {
            "abstract", "as", "base", "break", "case", "catch", "checked", "class", "const", "continue",
            "default", "delegate", "do", "else", "enum", "event", "explicit", "extern", "finally", "fixed",
            "for", "foreach", "goto", "if", "implicit", "in", "interface", "internal", "is", "lock",
            "namespace", "new", "operator", "out", "override", "params", "private", "protected", "public", "readonly",
            "ref", "return", "sealed", "sizeof", "stackalloc", "static", "struct", "switch", "this", "throw",
            "try", "typeof", "unchecked", "unsafe", "using", "virtual", "volatile", "while"
        };

        // Token: 0x0400024B RID: 587
        private static readonly HashSet<string> IGCKJDOKFKPIOCGOLGLHHKHMDJGLBNPCKEJK = new HashSet<string>
        {
            "++", "--", "->", "+", "-", "!", "~", "++", "--", "&",
            "*", "/", "%", "+", "-", "<<", ">>", "<", ">", "<=",
            ">=", "==", "!=", "&", "^", "|", "&&", "||", "??", "?",
            "::", ":", "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=",
            "^=", "<<=", ">>=", "=>", "?.", "?["
        };

        // Token: 0x0400024C RID: 588
        private static readonly HashSet<string> _ACQ = new HashSet<string>
        {
            "define", "elif", "else", "endif", "endregion", "error", "if", "line", "pragma", "region",
            "undef", "warning"
        };

        // Token: 0x0400024D RID: 589
        private static readonly HashSet<string> _ABO = new HashSet<string>
        {
            "bool", "byte", "char", "decimal", "double", "float", "int", "long", "object", "sbyte",
            "short", "string", "uint", "ulong", "ushort", "void"
        };

        // Token: 0x0400024E RID: 590
        private static readonly HashSet<string> _AQO = new HashSet<string>();

        // Token: 0x0400024F RID: 591
        private static string[] _AQW = new string[] { "Assets/mcs.rsp", "Assets/smcs.rsp", "Assets/gmcs.rsp", "Assets/csc.rsp" };

        // Token: 0x04000250 RID: 592
        private static char[] _AQX = new char[] { ' ', '\n', '\r' };

        // Token: 0x04000251 RID: 593
        private static char[] _AQY = new char[] { ';', ',' };

        // Token: 0x04000252 RID: 594
        private static HashSet<string> _AQV;
    }
}
