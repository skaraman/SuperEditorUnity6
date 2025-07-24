using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000050 RID: 80
    [InitializeOnLoad]
    internal abstract class _be3
    {
        // Token: 0x06000235 RID: 565 RVA: 0x0001E2C8 File Offset: 0x0001C4C8
        public static _be3 Create(GCE textBuffer, string path)
        {
            string text = Path.GetExtension(path) ?? string.Empty;
            Type type;
            bool flag = !_bj5.IsIgnoredScript(path) && _be3._AVX.TryGetValue(text, out type);
            _be3 _AVY;
            if (flag)
            {
                _AVY = (_be3)Activator.CreateInstance(type);
            }
            else
            {
                _AVY = new _bi9();
            }
            _AVY._ABQ = textBuffer;
            _AVY._AMO = path;
            return _AVY;
        }

        // Token: 0x06000236 RID: 566 RVA: 0x0001E330 File Offset: 0x0001C530
        private static void RegisterParsers()
        {
            _be3._AVX.Add(".cs", typeof(_bd5));
            _be3._AVX.Add(".js", typeof(_b6));
            _be3._AVX.Add(".shader", typeof(FLCK));
            _be3._AVX.Add(".cg", typeof(FLCK));
            _be3._AVX.Add(".cginc", typeof(FLCK));
            _be3._AVX.Add(".hlsl", typeof(FLCK));
            _be3._AVX.Add(".hlslinc", typeof(FLCK));
            _be3._AVX.Add(".txt", typeof(_bi9));
        }

        // Token: 0x06000237 RID: 567 RVA: 0x0001E410 File Offset: 0x0001C610
        static _be3()
        {
            _be3.RegisterParsers();
            _be3._AVZ = new HashSet<string>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Assembly[] array = assemblies;
            int i = 0;
            while (i < array.Length)
            {
                Assembly assembly = array[i];
                try
                {
                    bool flag = assembly is AssemblyBuilder;
                    if (!flag)
                    {
                        Type[] array2 = (_bj5.IsScriptAssembly(assembly) ? assembly.GetTypes() : assembly.GetExportedTypes());
                        foreach (Type type in array2)
                        {
                            string text = type.Name;
                            int num = text.IndexOf("`", StringComparison.Ordinal);
                            bool flag2 = num >= 0;
                            if (flag2)
                            {
                                text = text.Remove(num);
                            }
                            _be3._AVZ.Add(text);
                            bool flag3 = type.IsSubclassOf(typeof(Attribute)) && text.EndsWith("Attribute", StringComparison.Ordinal);
                            if (flag3)
                            {
                                _be3._AVZ.Add(text.Substring(0, text.Length - "Attribute".Length));
                            }
                        }
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    Debug.LogWarning("Error reading types from assembly " + assembly.FullName);
                }
            IL_0180:
                i++;
                continue;
                goto IL_0180;
            }
        }

        // Token: 0x06000238 RID: 568 RVA: 0x0001E5BC File Offset: 0x0001C7BC
        [CompilerGenerated]
        public _bb4 _AQT()
        {
            return this._AWA;
        }

        // Token: 0x06000239 RID: 569 RVA: 0x0001E5C4 File Offset: 0x0001C7C4
        [CompilerGenerated]
        protected void _AQR(_bb4 value)
        {
            this._AWA = value;
        }

        // Token: 0x0600023A RID: 570 RVA: 0x0001E5CD File Offset: 0x0001C7CD
        public void OnLoaded()
        {
            this._ARD = false;
            this.ParseAll(this._AMO);
        }

        // Token: 0x0600023B RID: 571 RVA: 0x0001E5E4 File Offset: 0x0001C7E4
        public virtual _bh2._AJH MoveAfterLeaf(_bb4.DHBA leaf)
        {
            return null;
        }

        // Token: 0x0600023C RID: 572 RVA: 0x0001E5F8 File Offset: 0x0001C7F8
        public virtual bool ParseLines(int fromLine, int toLineInclusive)
        {
            return true;
        }

        // Token: 0x0600023D RID: 573 RVA: 0x0001E60C File Offset: 0x0001C80C
        public virtual void FullRefresh()
        {
            bool flag = this._ABP != null;
            if (flag)
            {
                this._ABP.Join();
            }
            this._ABP = null;
        }

        // Token: 0x0600023E RID: 574 RVA: 0x0001E63C File Offset: 0x0001C83C
        public virtual void LexLine(int currentLine, GCE.PHFG formatedLine)
        {
            formatedLine.JIKB = currentLine;
            bool flag = this._ABP != null;
            if (flag)
            {
                this._ABP.Join();
            }
            this._ABP = null;
            string text = this._ABQ.FLOg[currentLine];
            List<SyntaxToken> list = formatedLine.EOIA ?? new List<SyntaxToken>();
            list.Clear();
            formatedLine.EOIA = list;
            bool flag2 = !string.IsNullOrEmpty(text);
            if (flag2)
            {
                list.Add(new SyntaxToken(SyntaxToken.Kind.Comment, text)
                {
                    style = this._ABQ._ABT._ABV,
                    AIGN = formatedLine
                });
                int num = this._ABQ.CharIndexToColumn(text.Length, currentLine);
                bool flag3 = num > this._ABQ._ABU;
                if (flag3)
                {
                    this._ABQ._ABU = num;
                }
            }
        }

        // Token: 0x0600023F RID: 575 RVA: 0x00014488 File Offset: 0x00012688
        protected virtual void Tokenize(string line, GCE.PHFG formatedLine)
        {
        }

        // Token: 0x06000240 RID: 576 RVA: 0x00014488 File Offset: 0x00012688
        protected virtual void ParseAll(string bufferName)
        {
        }

        // Token: 0x06000241 RID: 577 RVA: 0x0001E714 File Offset: 0x0001C914
        public virtual void CutParseTree(int fromLine, GCE.PHFG[] formatedLines)
        {
            bool flag = this._AQT() == null;
            if (!flag)
            {
                _bb4._AIN _AIO = null;
                int num = fromLine;
                while (_AIO == null && num-- > 0)
                {
                    List<SyntaxToken> _ABS = this._ABQ._AQQ[num].EOIA;
                    bool flag2 = _ABS != null;
                    if (flag2)
                    {
                        int count = _ABS.Count;
                        while (count-- > 0)
                        {
                            bool flag3 = _ABS[count].tokenKind > SyntaxToken.Kind.LastWSToken && _ABS[count].OOME != null && _ABS[count].OOME._AJB == null;
                            if (flag3)
                            {
                                _AIO = _ABS[count].OOME;
                                break;
                            }
                        }
                    }
                }
                bool flag4 = false;
                bool flag5 = _AIO == null;
                if (flag5)
                {
                    _AIO = this._AQT()._AIT.ChildAt(0);
                    flag4 = true;
                }
                while (_AIO != null)
                {
                    _bb4._ACW _AMI = _AIO.OOME;
                    bool flag6 = _AMI == null;
                    if (flag6)
                    {
                        break;
                    }
                    int i;
                    for (i = (int)(flag4 ? _AIO._AIL : (_AIO._AIL + 1)); i > 0; i--)
                    {
                        _bb4._AIN _AIO2 = _AMI.ChildAt(i - 1);
                        bool flag7 = _AIO2 != null && !_AIO2.HasLeafs();
                        if (!flag7)
                        {
                            break;
                        }
                    }
                    flag4 = flag4 && i == 0;
                    bool flag8 = i < (int)_AMI._AIX;
                    if (flag8)
                    {
                        _AMI.InvalidateFrom(i);
                    }
                    _AIO = _AMI;
                    _AIO._AJB = null;
                }
            }
        }

        // Token: 0x17000017 RID: 23
        // (get) Token: 0x06000242 RID: 578 RVA: 0x0001E8BC File Offset: 0x0001CABC
        public virtual HashSet<string> Keywords
        {
            get
            {
                return this._AWB;
            }
        }

        // Token: 0x17000018 RID: 24
        // (get) Token: 0x06000243 RID: 579 RVA: 0x0001E8D4 File Offset: 0x0001CAD4
        public virtual HashSet<string> BuiltInLiterals
        {
            get
            {
                return this._AWB;
            }
        }

        // Token: 0x06000244 RID: 580 RVA: 0x0001E8EC File Offset: 0x0001CAEC
        public virtual bool IsBuiltInType(string word)
        {
            return false;
        }

        // Token: 0x06000245 RID: 581
        public abstract bool IsBuiltInLiteral(string word);

        // Token: 0x06000246 RID: 582 RVA: 0x0001E900 File Offset: 0x0001CB00
        protected bool IsUnityType(string word)
        {
            return !this._ABQ._ARO && _be3._AVZ.Contains(word);
        }

        // Token: 0x06000247 RID: 583 RVA: 0x0001E930 File Offset: 0x0001CB30
        public Func<bool> Update(int fromLine, int toLineInclusive)
        {
            int num = this._ABQ._AQQ.Length - 1;
            try
            {
                bool flag = this._AQT() != null;
                if (flag)
                {
                    this.ParseLines(fromLine, num);
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            bool flag2 = this._AQT() != null && this._AQT()._AIT != null;
            if (flag2)
            {
                this._AQT()._AIT.CleanUp();
            }
            return null;
        }

        // Token: 0x06000248 RID: 584 RVA: 0x0001E9BC File Offset: 0x0001CBBC
        private bool ProgressiveParser()
        {
            bool flag = this._ABQ == null || this._ABQ.FLOg == null || this._ABQ.FLOg.Count <= this._AWC;
            bool flag2;
            if (flag)
            {
                this._AWC = -1;
                flag2 = false;
            }
            else
            {
                bool flag3 = !this.ParseLines(this._AWC, this._AWC);
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    this._AWC++;
                    bool flag4 = this._AWC < this._ABQ.FLOg.Count;
                    if (flag4)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        this._AWC = -1;
                        flag2 = false;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000249 RID: 585 RVA: 0x0001EA6C File Offset: 0x0001CC6C
        protected static SyntaxToken ScanWhitespace(string line, ref int startAt)
        {
            int num = startAt;
            int length = line.Length;
            while (num < length && (line[num] == ' ' || line[num] == '\t'))
            {
                num++;
            }
            bool flag = num == startAt;
            SyntaxToken syntaxToken;
            if (flag)
            {
                syntaxToken = null;
            }
            else
            {
                SyntaxToken syntaxToken2 = new SyntaxToken(SyntaxToken.Kind.Whitespace, line.Substring(startAt, num - startAt));
                startAt = num;
                syntaxToken = syntaxToken2;
            }
            return syntaxToken;
        }

        // Token: 0x0600024A RID: 586 RVA: 0x0001EADC File Offset: 0x0001CCDC
        protected static SyntaxToken ScanWord(string line, ref int startAt)
        {
            int i;
            for (i = startAt; i < line.Length; i++)
            {
                bool flag = !char.IsLetterOrDigit(line, i) && line[i] != '_';
                if (flag)
                {
                    break;
                }
            }
            SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.Identifier, line.Substring(startAt, i - startAt));
            startAt = i;
            return syntaxToken;
        }

        // Token: 0x0600024B RID: 587 RVA: 0x0001EB40 File Offset: 0x0001CD40
        protected static bool ScanUnicodeEscapeChar(string line, ref int startAt)
        {
            bool flag = startAt >= line.Length - 5;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = line[startAt] != '\\';
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    int num = startAt + 1;
                    bool flag4 = line[num] != 'u' && line[num] != 'U';
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        int i = ((line[num] == 'u') ? 4 : 8);
                        num++;
                        while (i > 0)
                        {
                            bool flag5 = !_be3.ScanHexDigit(line, ref num);
                            if (flag5)
                            {
                                break;
                            }
                            i--;
                        }
                        bool flag6 = i == 0;
                        if (flag6)
                        {
                            startAt = num;
                            flag2 = true;
                        }
                        else
                        {
                            flag2 = false;
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x0600024C RID: 588 RVA: 0x0001EBFC File Offset: 0x0001CDFC
        protected static SyntaxToken ScanCharLiteral(string line, ref int startAt)
        {
            int i;
            for (i = startAt + 1; i < line.Length; i++)
            {
                bool flag = line[i] == '\'';
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
            SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.CharLiteral, line.Substring(startAt, i - startAt));
            startAt = i;
            return syntaxToken;
        }

        // Token: 0x0600024D RID: 589 RVA: 0x0001EC7C File Offset: 0x0001CE7C
        protected static SyntaxToken ScanStringLiteral(string line, ref int startAt)
        {
            int i = startAt + 1;
            bool flag = line[startAt] == '$';
            if (flag)
            {
                i++;
            }
            while (i < line.Length)
            {
                bool flag2 = line[i] == '"';
                if (flag2)
                {
                    i++;
                    break;
                }
                bool flag3 = line[i] == '\\' && i < line.Length - 1;
                if (flag3)
                {
                    i++;
                }
                i++;
            }
            SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.StringLiteral, line.Substring(startAt, i - startAt));
            startAt = i;
            return syntaxToken;
        }

        // Token: 0x0600024E RID: 590 RVA: 0x0001ED14 File Offset: 0x0001CF14
        protected static SyntaxToken ScanNumericLiteral(string line, ref int startAt)
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            int i = startAt;
            bool flag4 = line[i] == '0' && i < line.Length - 1 && (line[i + 1] == 'x' || line[i + 1] == 'X');
            if (flag4)
            {
                i += 2;
                flag = true;
                while (i < line.Length)
                {
                    char c = line[i];
                    bool flag5 = (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
                    if (!flag5)
                    {
                        break;
                    }
                    i++;
                }
            }
            else
            {
                while (i < line.Length && line[i] >= '0' && line[i] <= '9')
                {
                    i++;
                }
            }
            bool flag6 = i > startAt && i < line.Length;
            if (flag6)
            {
                char c = line[i];
                bool flag7 = c == 'l' || c == 'L' || c == 'u' || c == 'U';
                if (flag7)
                {
                    i++;
                    bool flag8 = i < line.Length;
                    if (flag8)
                    {
                        bool flag9 = c == 'l' || c == 'L';
                        if (flag9)
                        {
                            bool flag10 = line[i] == 'u' || line[i] == 'U';
                            if (flag10)
                            {
                                i++;
                            }
                        }
                        else
                        {
                            bool flag11 = line[i] == 'l' || line[i] == 'L';
                            if (flag11)
                            {
                                i++;
                            }
                        }
                    }
                    SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.IntegerLiteral, line.Substring(startAt, i - startAt));
                    startAt = i;
                    return syntaxToken;
                }
            }
            bool flag12 = flag;
            SyntaxToken syntaxToken2;
            if (flag12)
            {
                SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.IntegerLiteral, line.Substring(startAt, i - startAt));
                startAt = i;
                syntaxToken2 = syntaxToken;
            }
            else
            {
                while (i < line.Length)
                {
                    char c = line[i];
                    bool flag13 = !flag2 && !flag3 && c == '.';
                    if (flag13)
                    {
                        bool flag14 = i < line.Length - 1 && line[i + 1] >= '0' && line[i + 1] <= '9';
                        if (!flag14)
                        {
                            break;
                        }
                        flag2 = true;
                        i++;
                    }
                    else
                    {
                        bool flag15 = !flag3 && i > startAt && (c == 'e' || c == 'E');
                        if (flag15)
                        {
                            flag3 = true;
                            i++;
                            bool flag16 = i < line.Length && (line[i] == '-' || line[i] == '+');
                            if (flag16)
                            {
                                i++;
                            }
                        }
                        else
                        {
                            bool flag17 = c == 'f' || c == 'F' || c == 'd' || c == 'D' || c == 'm' || c == 'M';
                            if (flag17)
                            {
                                flag2 = true;
                                i++;
                                break;
                            }
                            bool flag18 = c < '0' || c > '9';
                            if (flag18)
                            {
                                break;
                            }
                            i++;
                        }
                    }
                }
                SyntaxToken syntaxToken = new SyntaxToken((flag2 || flag3) ? SyntaxToken.Kind.RealLiteral : SyntaxToken.Kind.IntegerLiteral, line.Substring(startAt, i - startAt));
                startAt = i;
                syntaxToken2 = syntaxToken;
            }
            return syntaxToken2;
        }

        // Token: 0x0600024F RID: 591 RVA: 0x0001F050 File Offset: 0x0001D250
        protected static SyntaxToken ScanNumericLiteral_JS(string line, ref int startAt)
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            int i = startAt;
            bool flag4 = line[i] == '0' && i < line.Length - 1 && line[i + 1] == 'x';
            if (flag4)
            {
                i += 2;
                flag = true;
                while (i < line.Length)
                {
                    char c = line[i];
                    bool flag5 = (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
                    if (!flag5)
                    {
                        break;
                    }
                    i++;
                }
            }
            else
            {
                while (i < line.Length && line[i] >= '0' && line[i] <= '9')
                {
                    i++;
                }
            }
            bool flag6 = i > startAt && i < line.Length;
            if (flag6)
            {
                char c = line[i];
                bool flag7 = c == 'l' || c == 'L';
                if (flag7)
                {
                    i++;
                    SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.IntegerLiteral, line.Substring(startAt, i - startAt));
                    startAt = i;
                    return syntaxToken;
                }
            }
            bool flag8 = flag;
            SyntaxToken syntaxToken2;
            if (flag8)
            {
                SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.IntegerLiteral, line.Substring(startAt, i - startAt));
                startAt = i;
                syntaxToken2 = syntaxToken;
            }
            else
            {
                while (i < line.Length)
                {
                    char c = line[i];
                    bool flag9 = !flag2 && !flag3 && c == '.';
                    if (flag9)
                    {
                        bool flag10 = i < line.Length - 1 && line[i + 1] >= '0' && line[i + 1] <= '9';
                        if (!flag10)
                        {
                            break;
                        }
                        flag2 = true;
                        i++;
                    }
                    else
                    {
                        bool flag11 = !flag3 && i > startAt && (c == 'e' || c == 'E');
                        if (flag11)
                        {
                            flag3 = true;
                            i++;
                            bool flag12 = i < line.Length && (line[i] == '-' || line[i] == '+');
                            if (flag12)
                            {
                                i++;
                            }
                        }
                        else
                        {
                            bool flag13 = c == 'f' || c == 'F' || c == 'd' || c == 'D';
                            if (flag13)
                            {
                                flag2 = true;
                                i++;
                                break;
                            }
                            bool flag14 = c < '0' || c > '9';
                            if (flag14)
                            {
                                break;
                            }
                            i++;
                        }
                    }
                }
                SyntaxToken syntaxToken = new SyntaxToken((flag2 || flag3) ? SyntaxToken.Kind.RealLiteral : SyntaxToken.Kind.IntegerLiteral, line.Substring(startAt, i - startAt));
                startAt = i;
                syntaxToken2 = syntaxToken;
            }
            return syntaxToken2;
        }

        // Token: 0x06000250 RID: 592 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
        protected static bool ScanHexDigit(string line, ref int i)
        {
            bool flag = i >= line.Length;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                char c = line[i];
                bool flag3 = (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
                if (flag3)
                {
                    i++;
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
            }
            return flag2;
        }

        // Token: 0x06000251 RID: 593 RVA: 0x0001F358 File Offset: 0x0001D558
        protected static SyntaxToken ScanIdentifierOrKeyword(string line, ref int startAt)
        {
            bool flag = false;
            int i = startAt;
            int length = line.Length;
            bool flag2 = i >= length;
            SyntaxToken syntaxToken;
            if (flag2)
            {
                syntaxToken = null;
            }
            else
            {
                char c = line[i];
                bool flag3 = c == '@';
                if (flag3)
                {
                    flag = true;
                    i++;
                }
                bool flag4 = i < length;
                if (flag4)
                {
                    c = line[i];
                    bool flag5 = char.IsLetter(c) || c == '_';
                    if (flag5)
                    {
                        i++;
                    }
                    else
                    {
                        bool flag6 = !_be3.ScanUnicodeEscapeChar(line, ref i);
                        if (flag6)
                        {
                            bool flag7 = i == startAt;
                            if (flag7)
                            {
                                return null;
                            }
                            string text = line.Substring(startAt, i - startAt);
                            startAt = i;
                            return new SyntaxToken(SyntaxToken.Kind.Identifier, text);
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    while (i < line.Length)
                    {
                        bool flag8 = char.IsLetterOrDigit(line, i) || line[i] == '_';
                        if (flag8)
                        {
                            i++;
                        }
                        else
                        {
                            bool flag9 = !_be3.ScanUnicodeEscapeChar(line, ref i);
                            if (flag9)
                            {
                                break;
                            }
                            flag = true;
                        }
                    }
                }
                string text2 = line.Substring(startAt, i - startAt);
                startAt = i;
                syntaxToken = new SyntaxToken(flag ? SyntaxToken.Kind.Identifier : SyntaxToken.Kind.Keyword, text2);
            }
            return syntaxToken;
        }

        // Token: 0x06000252 RID: 594 RVA: 0x0001F490 File Offset: 0x0001D690
        protected bool ParsePPOrExpression(string line, GCE.PHFG formatedLine, ref int startAt)
        {
            bool flag = startAt >= line.Length;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = this.ParsePPAndExpression(line, formatedLine, ref startAt);
                SyntaxToken syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                bool flag4 = syntaxToken != null;
                if (flag4)
                {
                    formatedLine.EOIA.Add(syntaxToken);
                    syntaxToken.AIGN = formatedLine;
                }
                bool flag5 = startAt + 1 < line.Length && line[startAt] == '|' && line[startAt + 1] == '|';
                if (flag5)
                {
                    formatedLine.EOIA.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, "||")
                    {
                        AIGN = formatedLine
                    });
                    startAt += 2;
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag6 = syntaxToken != null;
                    if (flag6)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag7 = this.ParsePPOrExpression(line, formatedLine, ref startAt);
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag8 = syntaxToken != null;
                    if (flag8)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    flag2 = flag3 || flag7;
                }
                else
                {
                    flag2 = flag3;
                }
            }
            return flag2;
        }

        // Token: 0x06000253 RID: 595 RVA: 0x0001F5A8 File Offset: 0x0001D7A8
        protected bool ParsePPAndExpression(string line, GCE.PHFG formatedLine, ref int startAt)
        {
            bool flag = startAt >= line.Length;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = this.ParsePPEqualityExpression(line, formatedLine, ref startAt);
                SyntaxToken syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                bool flag4 = syntaxToken != null;
                if (flag4)
                {
                    formatedLine.EOIA.Add(syntaxToken);
                    syntaxToken.AIGN = formatedLine;
                }
                bool flag5 = startAt + 1 < line.Length && line[startAt] == '&' && line[startAt + 1] == '&';
                if (flag5)
                {
                    formatedLine.EOIA.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, "&&")
                    {
                        AIGN = formatedLine
                    });
                    startAt += 2;
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag6 = syntaxToken != null;
                    if (flag6)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag7 = this.ParsePPAndExpression(line, formatedLine, ref startAt);
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag8 = syntaxToken != null;
                    if (flag8)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    flag2 = flag3 && flag7;
                }
                else
                {
                    flag2 = flag3;
                }
            }
            return flag2;
        }

        // Token: 0x06000254 RID: 596 RVA: 0x0001F6C0 File Offset: 0x0001D8C0
        protected bool ParsePPEqualityExpression(string line, GCE.PHFG formatedLine, ref int startAt)
        {
            bool flag = startAt >= line.Length;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = this.ParsePPUnaryExpression(line, formatedLine, ref startAt);
                SyntaxToken syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                bool flag4 = syntaxToken != null;
                if (flag4)
                {
                    formatedLine.EOIA.Add(syntaxToken);
                    syntaxToken.AIGN = formatedLine;
                }
                bool flag5 = startAt + 1 < line.Length && (line[startAt] == '=' || line[startAt + 1] == '!') && line[startAt + 1] == '=';
                if (flag5)
                {
                    bool flag6 = line[startAt] == '=';
                    formatedLine.EOIA.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, flag6 ? "==" : "!=")
                    {
                        AIGN = formatedLine
                    });
                    startAt += 2;
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag7 = syntaxToken != null;
                    if (flag7)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag8 = this.ParsePPEqualityExpression(line, formatedLine, ref startAt);
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag9 = syntaxToken != null;
                    if (flag9)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    flag2 = (flag6 ? (flag3 == flag8) : (flag3 != flag8));
                }
                else
                {
                    flag2 = flag3;
                }
            }
            return flag2;
        }

        // Token: 0x06000255 RID: 597 RVA: 0x0001F810 File Offset: 0x0001DA10
        protected bool ParsePPUnaryExpression(string line, GCE.PHFG formatedLine, ref int startAt)
        {
            bool flag = startAt >= line.Length;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = line[startAt] == '!';
                if (flag3)
                {
                    formatedLine.EOIA.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, "!")
                    {
                        AIGN = formatedLine
                    });
                    startAt++;
                    SyntaxToken syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag4 = syntaxToken != null;
                    if (flag4)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    bool flag5 = this.ParsePPUnaryExpression(line, formatedLine, ref startAt);
                    syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                    bool flag6 = syntaxToken != null;
                    if (flag6)
                    {
                        formatedLine.EOIA.Add(syntaxToken);
                        syntaxToken.AIGN = formatedLine;
                    }
                    flag2 = !flag5;
                }
                else
                {
                    flag2 = this.ParsePPPrimaryExpression(line, formatedLine, ref startAt);
                }
            }
            return flag2;
        }

        // Token: 0x06000256 RID: 598 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
        protected bool ParsePPPrimaryExpression(string line, GCE.PHFG formatedLine, ref int startAt)
        {
            bool flag = line[startAt] == '(';
            bool flag5;
            if (flag)
            {
                formatedLine.EOIA.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, "(")
                {
                    AIGN = formatedLine
                });
                startAt++;
                SyntaxToken syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                bool flag2 = syntaxToken != null;
                if (flag2)
                {
                    formatedLine.EOIA.Add(syntaxToken);
                    syntaxToken.AIGN = formatedLine;
                }
                bool flag3 = this.ParsePPOrExpression(line, formatedLine, ref startAt);
                bool flag4 = startAt >= line.Length;
                if (flag4)
                {
                    flag5 = flag3;
                }
                else
                {
                    bool flag6 = line[startAt] == ')';
                    if (flag6)
                    {
                        formatedLine.EOIA.Add(new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, ")")
                        {
                            AIGN = formatedLine
                        });
                        startAt++;
                        syntaxToken = _be3.ScanWhitespace(line, ref startAt);
                        bool flag7 = syntaxToken != null;
                        if (flag7)
                        {
                            formatedLine.EOIA.Add(syntaxToken);
                            syntaxToken.AIGN = formatedLine;
                        }
                        flag5 = flag3;
                    }
                    else
                    {
                        flag5 = flag3;
                    }
                }
            }
            else
            {
                bool flag8 = this.ParsePPSymbol(line, formatedLine, ref startAt);
                SyntaxToken syntaxToken2 = _be3.ScanWhitespace(line, ref startAt);
                bool flag9 = syntaxToken2 != null;
                if (flag9)
                {
                    formatedLine.EOIA.Add(syntaxToken2);
                    syntaxToken2.AIGN = formatedLine;
                }
                flag5 = flag8;
            }
            return flag5;
        }

        // Token: 0x06000257 RID: 599 RVA: 0x0001FA1C File Offset: 0x0001DC1C
        protected bool ParsePPSymbol(string line, GCE.PHFG formatedLine, ref int startAt)
        {
            SyntaxToken syntaxToken = _be3.ScanIdentifierOrKeyword(line, ref startAt);
            bool flag = syntaxToken == null;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                syntaxToken.tokenKind = SyntaxToken.Kind.PreprocessorSymbol;
                formatedLine.EOIA.Add(syntaxToken);
                syntaxToken.AIGN = formatedLine;
                bool flag3 = syntaxToken.text == "true";
                if (flag3)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag4 = syntaxToken.text == "false";
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        bool flag5 = this._ABR == null;
                        if (flag5)
                        {
                            this._ABR = new HashSet<string>(EditorUserBuildSettings.activeScriptCompilationDefines);
                        }
                        bool flag6 = this._ABR.Contains(syntaxToken.text);
                        flag2 = flag6;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000258 RID: 600 RVA: 0x0001FAC8 File Offset: 0x0001DCC8
        protected void OpenRegion(GCE.PHFG formatedLine, GCE._ABW._ABX regionKind)
        {
            GCE._ABW _AVO = formatedLine._ABZ;
            GCE._ABW _AVO2 = null;
            if (regionKind - (GCE._ABW._ABX)3 <= 1 || regionKind - (GCE._ABW._ABX)8 <= 1)
            {
                _AVO = _AVO.OOME;
            }
            bool flag = _AVO._ARB != null;
            if (flag)
            {
                int count = _AVO._ARB.Count;
                while (count-- > 0)
                {
                    bool flag2 = _AVO._ARB[count]._ABI == formatedLine;
                    if (flag2)
                    {
                        _AVO2 = _AVO._ARB[count];
                        break;
                    }
                }
            }
            bool flag3 = _AVO2 != null;
            if (flag3)
            {
                bool flag4 = _AVO2._AT == regionKind;
                if (flag4)
                {
                    formatedLine._ABZ = _AVO2;
                    return;
                }
                _AVO2.OOME = null;
                _AVO._ARB.Remove(_AVO2);
            }
            formatedLine._ABZ = new GCE._ABW
            {
                OOME = _AVO,
                _AT = regionKind,
                _ABI = formatedLine
            };
            bool flag5 = _AVO._ARB == null;
            if (flag5)
            {
                _AVO._ARB = new List<GCE._ABW>();
            }
            _AVO._ARB.Add(formatedLine._ABZ);
        }

        // Token: 0x06000259 RID: 601 RVA: 0x0001FBDF File Offset: 0x0001DDDF
        protected void CloseRegion(GCE.PHFG formatedLine)
        {
            formatedLine._ABZ = formatedLine._ABZ.OOME;
        }

        // Token: 0x0400027F RID: 639
        protected static readonly char[] COBFFGGNFGGLHEPFIGFMBMFLNNKILMJBLALB = new char[] { ' ', '\t' };

        // Token: 0x04000280 RID: 640
        private static readonly Dictionary<string, Type> _AVX = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        // Token: 0x04000281 RID: 641
        protected string _AMO;

        // Token: 0x04000282 RID: 642
        protected GCE _ABQ;

        // Token: 0x04000283 RID: 643
        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private _bb4 _AWA;

        // Token: 0x04000284 RID: 644
        public HashSet<string> _ABR;

        // Token: 0x04000285 RID: 645
        public bool _ARD;

        // Token: 0x04000286 RID: 646
        protected Thread _ABP;

        // Token: 0x04000287 RID: 647
        private HashSet<string> _AWB = new HashSet<string>();

        // Token: 0x04000288 RID: 648
        protected static HashSet<string> _ABN = new HashSet<string> { "false", "null", "true" };

        // Token: 0x04000289 RID: 649
        protected static HashSet<string> _AVZ;

        // Token: 0x0400028A RID: 650
        private int _AWC = -1;
    }
}
