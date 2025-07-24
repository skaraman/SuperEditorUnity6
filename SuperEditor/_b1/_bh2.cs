using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000FD RID: 253
    internal abstract class _bh2
    {
        // Token: 0x17000035 RID: 53
        // (get) Token: 0x06000744 RID: 1860
        internal abstract _bh2._BCX GetParser { get; }

        // Token: 0x06000745 RID: 1861
        internal abstract _bf4 GetCompletionTypes(_bb4._AIN afterNode);

        // Token: 0x06000746 RID: 1862
        public abstract int TokenToId(string s);

        // Token: 0x06000747 RID: 1863
        public abstract string GetToken(int tokenId);

        // Token: 0x020000FE RID: 254
        public abstract class _AJE
        {
            // Token: 0x06000749 RID: 1865 RVA: 0x000F5C79 File Offset: 0x000F3E79
            protected _AJE(_bh2._BCX parser, _bh2._AGI lookahead)
            {
                this._ASF = parser;
                this._BCY = lookahead;
            }

            // Token: 0x0600074A RID: 1866
            public abstract string GetErrorMessage();

            // Token: 0x04000659 RID: 1625
            protected _bh2._AGI _BCY;

            // Token: 0x0400065A RID: 1626
            protected _bh2._BCX _ASF;
        }

        // Token: 0x020000FF RID: 255
        public class _BCZ : _bh2._AJE
        {
            // Token: 0x0600074B RID: 1867 RVA: 0x000F5C91 File Offset: 0x000F3E91
            public _BCZ(_bh2._BCX parser, _bh2._AGI lookahead)
                : base(parser, lookahead)
            {
            }

            // Token: 0x0600074C RID: 1868 RVA: 0x000F5CA0 File Offset: 0x000F3EA0
            public override string GetErrorMessage()
            {
                return "Syntax error: Expected " + this._BCY.ToString(this._ASF);
            }
        }

        // Token: 0x02000100 RID: 256
        public class _BDA : _bh2._AJE
        {
            // Token: 0x0600074D RID: 1869 RVA: 0x000F5C91 File Offset: 0x000F3E91
            public _BDA(_bh2._BCX parser, _bh2._AGI lookahead)
                : base(parser, lookahead)
            {
            }

            // Token: 0x0600074E RID: 1870 RVA: 0x000F5CD0 File Offset: 0x000F3ED0
            public override string GetErrorMessage()
            {
                return "Unexpected token! Expected " + this._BCY.ToString(this._ASF);
            }
        }

        // Token: 0x02000101 RID: 257
        public abstract class _AJH : IEnumerator<SyntaxToken>, IEnumerator, IDisposable
        {
            // Token: 0x17000036 RID: 54
            // (get) Token: 0x0600074F RID: 1871 RVA: 0x000F5D00 File Offset: 0x000F3F00
            public SyntaxToken Current
            {
                get
                {
                    return this._BDB ?? ((this.EOIA != null) ? this.EOIA[this._BDC] : _bh2._AJH._BDD);
                }
            }

            // Token: 0x17000037 RID: 55
            // (get) Token: 0x06000750 RID: 1872 RVA: 0x000F5D3C File Offset: 0x000F3F3C
            object IEnumerator.Current
            {
                get
                {
                    return this._BDB ?? ((this.EOIA != null) ? this.EOIA[this._BDC] : _bh2._AJH._BDD);
                }
            }

            // Token: 0x06000751 RID: 1873 RVA: 0x00014488 File Offset: 0x00012688
            public void Dispose()
            {
            }

            // Token: 0x06000752 RID: 1874
            public abstract bool MoveNext();

            // Token: 0x06000753 RID: 1875 RVA: 0x000F5D78 File Offset: 0x000F3F78
            public void Reset()
            {
                this._BDE = -1;
                this._BDC = -1;
                this.EOIA = null;
            }

            // Token: 0x06000754 RID: 1876 RVA: 0x000F5D90 File Offset: 0x000F3F90
            public bool _BDF()
            {
                return this._BDG > 0;
            }

            // Token: 0x06000755 RID: 1877 RVA: 0x000F5DAC File Offset: 0x000F3FAC
            public int CurrentLine()
            {
                return this._BDE + 1;
            }

            // Token: 0x06000756 RID: 1878 RVA: 0x000F5DC8 File Offset: 0x000F3FC8
            public int CurrentTokenIndex()
            {
                return this._BDC;
            }

            // Token: 0x06000757 RID: 1879 RVA: 0x000F5DE0 File Offset: 0x000F3FE0
            public SyntaxToken CurrentToken()
            {
                return this._BDB ?? ((this.EOIA != null) ? this.EOIA[this._BDC] : _bh2._AJH._BDD);
            }

            // Token: 0x06000758 RID: 1880
            public abstract _bh2._AJH Clone();

            // Token: 0x06000759 RID: 1881
            public abstract void Delete();

            // Token: 0x0600075A RID: 1882 RVA: 0x000F5E1C File Offset: 0x000F401C
            public bool Lookahead(_bh2._ACW node, int maxDistance = 2147483647)
            {
                bool flag = this.EOIA == null && this._BDE > 0;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    int _BDH = this._BDE;
                    int _BDI = this._BDC;
                    int _BDJ = this._BDG;
                    this._BDG = maxDistance;
                    bool flag3 = node.Scan(this);
                    this._BDG = _BDJ;
                    for (int i = this._BDE; i > _BDH; i--)
                    {
                        bool flag4 = i < this.FLOg.Length;
                        if (flag4)
                        {
                            this.FLOg[i]._AUW = Math.Max(this.FLOg[i]._AUW, i - _BDH);
                        }
                    }
                    this._BDE = _BDH;
                    this._BDC = _BDI;
                    this.EOIA = ((this._BDE < this.FLOg.Length) ? this.FLOg[this._BDE].EOIA : null);
                    flag2 = flag3;
                }
                return flag2;
            }

            // Token: 0x0600075B RID: 1883 RVA: 0x000F5F0C File Offset: 0x000F410C
            public SyntaxToken Lookahead(int offset, bool skipWhitespace = true)
            {
                bool flag = !skipWhitespace;
                SyntaxToken syntaxToken;
                if (flag)
                {
                    syntaxToken = ((this._BDC + 1 < this.EOIA.Count) ? this.EOIA[this._BDC + 1] : _bh2._AJH._BDD);
                }
                else
                {
                    List<SyntaxToken> _ABS = this.EOIA;
                    int _BDH = this._BDE;
                    int _BDI = this._BDC;
                    while (offset-- > 0)
                    {
                        bool flag2 = !this.MoveNext();
                        if (flag2)
                        {
                            this.EOIA = _ABS;
                            this._BDE = _BDH;
                            this._BDC = _BDI;
                            return _bh2._AJH._BDD;
                        }
                    }
                    SyntaxToken syntaxToken2 = this.EOIA[this._BDC];
                    for (int i = this._BDE; i > _BDH; i--)
                    {
                        bool flag3 = i < this.FLOg.Length;
                        if (flag3)
                        {
                            this.FLOg[i]._AUW = Math.Max(this.FLOg[i]._AUW, i - _BDH);
                        }
                    }
                    this.EOIA = _ABS;
                    this._BDE = _BDH;
                    this._BDC = _BDI;
                    syntaxToken = syntaxToken2;
                }
                return syntaxToken;
            }

            // Token: 0x0600075C RID: 1884
            public abstract void InsertMissingToken(_bh2._AJE errorMessage);

            // Token: 0x0600075D RID: 1885
            public abstract void CollectCompletions(_bh2._AGI tokenSet);

            // Token: 0x0600075E RID: 1886
            public abstract void OnReduceSemanticNode(_bb4._ACW node);

            // Token: 0x0600075F RID: 1887
            public abstract void SyntaxErrorExpected(_bh2._AGI lookahead);

            // Token: 0x0400065B RID: 1627
            protected string _BDK;

            // Token: 0x0400065C RID: 1628
            protected GCE.PHFG[] FLOg;

            // Token: 0x0400065D RID: 1629
            protected List<SyntaxToken> EOIA;

            // Token: 0x0400065E RID: 1630
            protected int _BDE = -1;

            // Token: 0x0400065F RID: 1631
            protected int _BDC = -1;

            // Token: 0x04000660 RID: 1632
            protected static SyntaxToken _BDD;

            // Token: 0x04000661 RID: 1633
            protected SyntaxToken _BDB;

            // Token: 0x04000662 RID: 1634
            protected int _BDG;

            // Token: 0x04000663 RID: 1635
            public _bh2._ACW _BDL;

            // Token: 0x04000664 RID: 1636
            public _bb4._ACW _AJT;

            // Token: 0x04000665 RID: 1637
            public _bb4.DHBA _BDM;

            // Token: 0x04000666 RID: 1638
            public _bh2._AJE _BDN;

            // Token: 0x04000667 RID: 1639
            public _bh2._ACW _BDO;

            // Token: 0x04000668 RID: 1640
            public _bb4._ACW _BDP;

            // Token: 0x04000669 RID: 1641
            public bool _BDQ;
        }

        // Token: 0x02000102 RID: 258
        public abstract class _ACW
        {
            // Token: 0x06000761 RID: 1889 RVA: 0x000F604C File Offset: 0x000F424C
            public static implicit operator _bh2._ACW(string s)
            {
                return new _bh2._AJI(s);
            }

            // Token: 0x06000762 RID: 1890 RVA: 0x000F6064 File Offset: 0x000F4264
            public static _bh2._ACW operator |(_bh2._ACW a, _bh2._ACW b)
            {
                return new _bh2._BDR(new _bh2._ACW[] { a, b });
            }

            // Token: 0x06000763 RID: 1891 RVA: 0x000F608C File Offset: 0x000F428C
            public static _bh2._ACW operator |(_bh2._BDR a, _bh2._ACW b)
            {
                a.Add(b);
                return a;
            }

            // Token: 0x06000764 RID: 1892 RVA: 0x000F60A8 File Offset: 0x000F42A8
            public static _bh2._ACW operator -(_bh2._ACW a, _bh2._ACW b)
            {
                return new _bh2._BDS(new _bh2._ACW[] { a, b });
            }

            // Token: 0x06000765 RID: 1893 RVA: 0x000F60D0 File Offset: 0x000F42D0
            public static _bh2._ACW operator -(_bh2._BDS a, _bh2._ACW b)
            {
                a.Add(b);
                return a;
            }

            // Token: 0x06000766 RID: 1894 RVA: 0x000F60EC File Offset: 0x000F42EC
            public virtual _bh2._ACW GetNode()
            {
                return this;
            }

            // Token: 0x06000767 RID: 1895 RVA: 0x000F60FF File Offset: 0x000F42FF
            public virtual void Add(_bh2._ACW node)
            {
                Type type = base.GetType();
                throw new Exception(((type != null) ? type.ToString() : null) + ": cannot Add()");
            }

            // Token: 0x06000768 RID: 1896 RVA: 0x000F6124 File Offset: 0x000F4324
            public virtual bool Matches(_bh2._AJH scanner)
            {
                return this._BCY.Matches(scanner.Current);
            }

            // Token: 0x06000769 RID: 1897
            public abstract _bh2._AGI SetLookahead(_bh2._BCX parser);

            // Token: 0x0600076A RID: 1898
            public abstract _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ);

            // Token: 0x0600076B RID: 1899 RVA: 0x000F6148 File Offset: 0x000F4348
            public virtual void CheckLL1(_bh2._BCX parser)
            {
                bool flag = this._BDT == null;
                if (flag)
                {
                    throw new Exception(((this != null) ? this.ToString() : null) + ": follow not set");
                }
                bool flag2 = this._BCY.MatchesEmpty() && this._BCY.Accepts(this._BDT);
                if (flag2)
                {
                    throw new Exception(string.Concat(new string[]
                    {
                        (this != null) ? this.ToString() : null,
                        ": ambiguous\n  lookahead ",
                        this._BCY.ToString(parser),
                        "\n  follow ",
                        this._BDT.ToString(parser)
                    }));
                }
            }

            // Token: 0x0600076C RID: 1900
            public abstract bool Scan(_bh2._AJH scanner);

            // Token: 0x0600076D RID: 1901 RVA: 0x000F61F4 File Offset: 0x000F43F4
            public void SyntaxError(_bh2._AJH scanner, _bh2._AJE errorMessage)
            {
                bool flag = scanner._BDN != null;
                if (!flag)
                {
                    scanner._BDN = errorMessage;
                }
            }

            // Token: 0x0600076E RID: 1902 RVA: 0x000F6218 File Offset: 0x000F4418
            public virtual IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                yield break;
            }

            // Token: 0x0600076F RID: 1903 RVA: 0x000F6228 File Offset: 0x000F4428
            public virtual IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                yield break;
            }

            // Token: 0x06000770 RID: 1904 RVA: 0x000F6238 File Offset: 0x000F4438
            public virtual IEnumerable<T> EnumerateNodesOfType<T>() where T : _bh2._ACW
            {
                bool flag = this is T;
                if (flag)
                {
                    yield return (T)((object)this);
                }
                yield break;
            }

            // Token: 0x06000771 RID: 1905
            public abstract _bh2._ACW Parse(_bh2._AJH scanner);

            // Token: 0x06000772 RID: 1906 RVA: 0x000F6248 File Offset: 0x000F4448
            public _bh2._ACW Recover(_bh2._AJH scanner, out int numMissing)
            {
                numMissing = 0;
                _bh2._ACW _AGZ = this;
                while (_AGZ.OOME != null)
                {
                    _bh2._ACW _AGZ2 = _AGZ.OOME.NextAfterChild(_AGZ, scanner);
                    bool flag = _AGZ2 == null;
                    if (flag)
                    {
                        break;
                    }
                    _bh2._AEN _AJU = _AGZ2 as _bh2._AEN;
                    bool flag2 = _AJU != null && _AJU.GetName() == "attribute";
                    _bh2._ACW _AGZ3;
                    if (flag2)
                    {
                        _AGZ3 = _AJU;
                    }
                    else
                    {
                        bool flag3 = _AGZ2.Matches(scanner);
                        while (_AGZ2 != null && !flag3 && _AGZ2._BCY.MatchesEmpty())
                        {
                            _AGZ2 = _AGZ2.OOME.NextAfterChild(_AGZ2, scanner);
                            flag3 = _AGZ2 != null && _AGZ2.Matches(scanner);
                        }
                        bool flag4 = flag3 && scanner.Current.text == ";" && _AGZ2 is _bh2._BDU;
                        if (!flag4)
                        {
                            numMissing++;
                            bool flag5 = flag3;
                            if (flag5)
                            {
                                bool flag6 = scanner.Current.text == "{" || scanner.Current.text == "}" || scanner.Lookahead(_AGZ2, 3);
                                if (flag6)
                                {
                                    return _AGZ2;
                                }
                            }
                            bool flag7 = numMissing <= 1 && scanner.Current.text != "{" && scanner.Current.text != "}";
                            if (flag7)
                            {
                                using (_bh2._AJH _BDV = scanner.Clone())
                                {
                                    bool flag8 = _BDV.MoveNext() && _AGZ2.Matches(_BDV);
                                    if (flag8)
                                    {
                                        bool flag9 = _BDV.Lookahead(_AGZ2, 3);
                                        if (flag9)
                                        {
                                            return null;
                                        }
                                    }
                                }
                            }
                            _AGZ = _AGZ2;
                            continue;
                        }
                        _AGZ3 = null;
                    }
                    return _AGZ3;
                }
                return null;
            }

            // Token: 0x06000773 RID: 1907 RVA: 0x000F6424 File Offset: 0x000F4624
            public virtual _bh2._ACW NextAfterChild(_bh2._ACW child, _bh2._AJH scanner)
            {
                return (this.OOME != null) ? this.OOME.NextAfterChild(this, scanner) : null;
            }

            // Token: 0x06000774 RID: 1908 RVA: 0x000F6450 File Offset: 0x000F4650
            public void CollectCompletions(_bh2._AGI tokenSet, _bh2._AJH scanner, int identifierId)
            {
                _bh2._AJH _BDV = scanner.Clone();
                _bh2._ACW _AGZ = this;
                while (_AGZ != null && _AGZ.OOME != null)
                {
                    tokenSet.Add(_AGZ._BCY);
                    bool flag = !_AGZ._BCY.MatchesEmpty();
                    if (flag)
                    {
                        break;
                    }
                    _AGZ = _AGZ.OOME.NextAfterChild(_AGZ, _BDV);
                }
                tokenSet.RemoveEmpty();
            }

            // Token: 0x0400066A RID: 1642
            public _bh2._ACW OOME;

            // Token: 0x0400066B RID: 1643
            public int _AIL;

            // Token: 0x0400066C RID: 1644
            public _bh2._AGI _BCY;

            // Token: 0x0400066D RID: 1645
            public _bh2._AGI _BDT;
        }

        // Token: 0x02000106 RID: 262
        public class _BDW : _bh2._AEN
        {
            // Token: 0x0600078E RID: 1934 RVA: 0x000F66C3 File Offset: 0x000F48C3
            public _BDW()
                : base("NAME")
            {
            }

            // Token: 0x0600078F RID: 1935 RVA: 0x000F66D4 File Offset: 0x000F48D4
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    base.SetLookahead(parser);
                    this._BCY.Add(new _bh2._AGI(parser.TokenToId("IDENTIFIER")));
                }
                return this._BCY;
            }
        }

        // Token: 0x02000107 RID: 263
        public class _AEN : _bh2._ACW
        {
            // Token: 0x06000790 RID: 1936 RVA: 0x000F671F File Offset: 0x000F491F
            [CompilerGenerated]
            public _bh2._ACW _AJP()
            {
                return this._BDX;
            }

            // Token: 0x06000791 RID: 1937 RVA: 0x000F6727 File Offset: 0x000F4927
            [CompilerGenerated]
            protected void _BDY(_bh2._ACW value)
            {
                this._BDX = value;
            }

            // Token: 0x06000792 RID: 1938 RVA: 0x000F6730 File Offset: 0x000F4930
            public _bh2._AJQ _AJV()
            {
                return this._AJP() as _bh2._AJQ;
            }

            // Token: 0x06000793 RID: 1939 RVA: 0x000F674D File Offset: 0x000F494D
            public _AEN(string name)
            {
                this._AW = name;
            }

            // Token: 0x06000794 RID: 1940 RVA: 0x000F6760 File Offset: 0x000F4960
            public _bh2._AEN Clone()
            {
                _bh2._AEN _AJU = new _bh2._AEN(this._AW);
                _AJU._BDY(this._AJP());
                _AJU._BCY = this._BCY;
                _AJU._BDT = this._BDT;
                _bh2._AEN _AJU2 = _AJU;
                _bh2._BDZ _BEA = this._AJP() as _bh2._BDZ;
                bool flag = _BEA != null;
                if (flag)
                {
                    _AJU2._BDY(_BEA.Clone());
                    _AJU2._AJP().OOME = this;
                }
                return _AJU2;
            }

            // Token: 0x06000795 RID: 1941 RVA: 0x000F67D4 File Offset: 0x000F49D4
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    this._BDY(parser.GetPeer(this._AW));
                    bool flag2 = this._AJP() == null;
                    if (flag2)
                    {
                        Debug.LogError("Parser rule \"" + this._AW + "\" not found!!!");
                    }
                    else
                    {
                        this._AJP().OOME = this;
                        this._AJP()._AIL = 0;
                        this._BCY = this._AJP().SetLookahead(parser);
                    }
                }
                return this._BCY;
            }

            // Token: 0x06000796 RID: 1942 RVA: 0x000F6864 File Offset: 0x000F4A64
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                this.SetLookahead(parser);
                bool flag = this._AJP() is _bh2._AJQ;
                if (flag)
                {
                    this._AJP().SetFollow(parser, succ);
                }
                return this._BCY;
            }

            // Token: 0x06000797 RID: 1943 RVA: 0x00014488 File Offset: 0x00012688
            public override void CheckLL1(_bh2._BCX parser)
            {
            }

            // Token: 0x06000798 RID: 1944 RVA: 0x000F68A4 File Offset: 0x000F4AA4
            public override bool Scan(_bh2._AJH scanner)
            {
                return !scanner._BDF() || this._AJP().Scan(scanner);
            }

            // Token: 0x06000799 RID: 1945 RVA: 0x000F68D0 File Offset: 0x000F4AD0
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                this._AJP().OOME = this;
                _bh2._AJQ _BEB = this._AJP() as _bh2._AJQ;
                bool flag = _BEB != null;
                if (flag)
                {
                    bool flag2;
                    scanner._AJT = scanner._AJT.AddNode(this, scanner, out flag2);
                    bool flag3 = flag2;
                    if (flag3)
                    {
                        return scanner._BDL;
                    }
                }
                _bh2._ACW _AGZ = this._AJP().Parse(scanner);
                this._AJP().OOME = this;
                return _AGZ;
            }

            // Token: 0x0600079A RID: 1946 RVA: 0x000F6948 File Offset: 0x000F4B48
            public override _bh2._ACW NextAfterChild(_bh2._ACW child, _bh2._AJH scanner)
            {
                bool flag = this._AJP() is _bh2._AJQ;
                if (flag)
                {
                    scanner._AJT = scanner._AJT.OOME;
                }
                return base.NextAfterChild(this, scanner);
            }

            // Token: 0x0600079B RID: 1947 RVA: 0x000F6988 File Offset: 0x000F4B88
            public override string ToString()
            {
                return this._AW;
            }

            // Token: 0x0600079C RID: 1948 RVA: 0x000F69A0 File Offset: 0x000F4BA0
            public string GetName()
            {
                return this._AW;
            }

            // Token: 0x0600079D RID: 1949 RVA: 0x000F69B8 File Offset: 0x000F4BB8
            public sealed override IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                yield return this;
                yield break;
            }

            // Token: 0x0400067A RID: 1658
            protected string _AW;

            // Token: 0x0400067B RID: 1659
            [CompilerGenerated]
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private _bh2._ACW _BDX;
        }

        // Token: 0x02000109 RID: 265
        public class _AJI : _bh2._ACW
        {
            // Token: 0x060007A6 RID: 1958 RVA: 0x000F6A83 File Offset: 0x000F4C83
            public _AJI(string body)
            {
                this._AJK = body;
                this._AJL = body.Trim();
            }

            // Token: 0x060007A7 RID: 1959 RVA: 0x000F6AA0 File Offset: 0x000F4CA0
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                _bh2._AGI _BEC;
                if ((_BEC = this._BCY) == null)
                {
                    _BEC = (this._BCY = new _bh2._AGI(parser.TokenToId(this._AJL)));
                }
                return _BEC;
            }

            // Token: 0x060007A8 RID: 1960 RVA: 0x000F6AD8 File Offset: 0x000F4CD8
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                return this.SetLookahead(parser);
            }

            // Token: 0x060007A9 RID: 1961 RVA: 0x00014488 File Offset: 0x00012688
            public override void CheckLL1(_bh2._BCX parser)
            {
            }

            // Token: 0x060007AA RID: 1962 RVA: 0x000F6AF4 File Offset: 0x000F4CF4
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag3 = !this._BCY.Matches(scanner.Current.tokenId);
                    if (flag3)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        scanner.MoveNext();
                        flag2 = true;
                    }
                }
                return flag2;
            }

            // Token: 0x060007AB RID: 1963 RVA: 0x000F6B40 File Offset: 0x000F4D40
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                bool flag = !this._BCY.Matches(scanner.Current.tokenId);
                _bh2._ACW _AGZ;
                if (flag)
                {
                    scanner.SyntaxErrorExpected(this._BCY);
                    _AGZ = this;
                }
                else
                {
                    scanner._AJT.AddToken(scanner)._AJD = this;
                    scanner.MoveNext();
                    bool flag2 = scanner._BDN == null;
                    if (flag2)
                    {
                        scanner._BDP = scanner._AJT;
                        scanner._BDO = scanner._BDL;
                    }
                    _AGZ = this.OOME.NextAfterChild(this, scanner);
                }
                return _AGZ;
            }

            // Token: 0x060007AC RID: 1964 RVA: 0x000F6BD0 File Offset: 0x000F4DD0
            public override string ToString()
            {
                return this._AJL;
            }

            // Token: 0x060007AD RID: 1965 RVA: 0x000F6BE8 File Offset: 0x000F4DE8
            public sealed override IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                yield return this;
                yield break;
            }

            // Token: 0x04000680 RID: 1664
            public readonly string _AJL;

            // Token: 0x04000681 RID: 1665
            public string _AJK;
        }

        // Token: 0x0200010B RID: 267
        public class _BDR : _bh2._ACW
        {
            // Token: 0x060007B6 RID: 1974 RVA: 0x000F6CB4 File Offset: 0x000F4EB4
            public _BDR(params _bh2._ACW[] nodes)
            {
                foreach (_bh2._ACW _AGZ in nodes)
                {
                    this.Add(_AGZ);
                }
            }

            // Token: 0x060007B7 RID: 1975 RVA: 0x000F6CF4 File Offset: 0x000F4EF4
            public sealed override void Add(_bh2._ACW node)
            {
                _bh2._AEN _AJU = node as _bh2._AEN;
                bool flag = _AJU != null;
                if (flag)
                {
                    node = _AJU.Clone();
                }
                _bh2._BDR _BED = node as _bh2._BDR;
                bool flag2 = _BED != null;
                if (flag2)
                {
                    int count = _BED._BEE.Count;
                    for (int i = 0; i < count; i++)
                    {
                        _bh2._ACW _AGZ = _BED._BEE[i];
                        _AGZ.OOME = this;
                        this._BEE.Add(_AGZ);
                    }
                }
                else
                {
                    node.OOME = this;
                    this._BEE.Add(node);
                }
            }

            // Token: 0x060007B8 RID: 1976 RVA: 0x000F6D90 File Offset: 0x000F4F90
            public override _bh2._ACW GetNode()
            {
                return (this._BEE.Count == 1) ? this._BEE[0] : this;
            }

            // Token: 0x060007B9 RID: 1977 RVA: 0x000F6DC0 File Offset: 0x000F4FC0
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    this._BCY = new _bh2._AGI();
                    for (int i = 0; i < this._BEE.Count; i++)
                    {
                        _bh2._ACW _AGZ = this._BEE[i];
                        bool flag2 = _AGZ is _bh2._BEF;
                        if (!flag2)
                        {
                            _bh2._AGI _BEC = _AGZ.SetLookahead(parser);
                            bool flag3 = this._BCY.Accepts(_BEC);
                            if (flag3)
                            {
                                Debug.LogError(((this != null) ? this.ToString() : null) + ": ambiguous alternatives");
                                Debug.LogWarning(this._BCY.Intersecton(_BEC).ToString(parser));
                            }
                            this._BCY.Add(_BEC);
                        }
                    }
                    for (int j = 0; j < this._BEE.Count; j++)
                    {
                        _bh2._ACW _AGZ2 = this._BEE[j];
                        bool flag4 = _AGZ2 is _bh2._BEF;
                        if (flag4)
                        {
                            _bh2._AGI _BEC2 = _AGZ2.SetLookahead(parser);
                            this._BCY.Add(_BEC2);
                        }
                    }
                }
                return this._BCY;
            }

            // Token: 0x060007BA RID: 1978 RVA: 0x000F6EF4 File Offset: 0x000F50F4
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                this.SetLookahead(parser);
                this._BDT = succ;
                int count = this._BEE.Count;
                for (int i = 0; i < count; i++)
                {
                    _bh2._ACW _AGZ = this._BEE[i];
                    _AGZ.SetFollow(parser, succ);
                }
                return this._BCY;
            }

            // Token: 0x060007BB RID: 1979 RVA: 0x000F6F54 File Offset: 0x000F5154
            public override void CheckLL1(_bh2._BCX parser)
            {
                base.CheckLL1(parser);
                int count = this._BEE.Count;
                for (int i = 0; i < count; i++)
                {
                    _bh2._ACW _AGZ = this._BEE[i];
                    _AGZ.CheckLL1(parser);
                }
            }

            // Token: 0x060007BC RID: 1980 RVA: 0x000F6FA0 File Offset: 0x000F51A0
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    int count = this._BEE.Count;
                    for (int i = 0; i < count; i++)
                    {
                        _bh2._ACW _AGZ = this._BEE[i];
                        bool flag3 = _AGZ.Matches(scanner);
                        if (flag3)
                        {
                            return _AGZ.Scan(scanner);
                        }
                    }
                    bool flag4 = !this._BCY.MatchesEmpty();
                    flag2 = !flag4;
                }
                return flag2;
            }

            // Token: 0x060007BD RID: 1981 RVA: 0x000F7024 File Offset: 0x000F5224
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                int count = this._BEE.Count;
                for (int i = 0; i < count; i++)
                {
                    _bh2._ACW _AGZ = this._BEE[i];
                    bool flag = _AGZ.Matches(scanner);
                    if (flag)
                    {
                        return _AGZ.Parse(scanner);
                    }
                }
                bool flag2 = this._BCY.MatchesEmpty();
                if (flag2)
                {
                    return this.NextAfterChild(this, scanner);
                }
                scanner.SyntaxErrorExpected(this._BCY);
                return this;
            }

            // Token: 0x060007BE RID: 1982 RVA: 0x000F70A8 File Offset: 0x000F52A8
            public override string ToString()
            {
                string text = "( ";
                _bh2._ACW _AGZ = this._BEE[0];
                StringBuilder stringBuilder = new StringBuilder(text + ((_AGZ != null) ? _AGZ.ToString() : null));
                for (int i = 1; i < this._BEE.Count; i++)
                {
                    StringBuilder stringBuilder2 = stringBuilder;
                    string text2 = " | ";
                    _bh2._ACW _AGZ2 = this._BEE[i];
                    stringBuilder2.Append(text2 + ((_AGZ2 != null) ? _AGZ2.ToString() : null));
                }
                stringBuilder.Append(" )");
                return stringBuilder.ToString();
            }

            // Token: 0x060007BF RID: 1983 RVA: 0x000F7137 File Offset: 0x000F5337
            public sealed override IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                int count = this._BEE.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    _bh2._ACW node = this._BEE[i];
                    foreach (_bh2._AJI subnode in node.EnumerateLitNodes())
                    {
                        yield return subnode;
                    }
                    IEnumerator<_bh2._AJI> enumerator = null;
                    node = null;
                    num = i + 1;
                }
                yield break;
                yield break;
            }

            // Token: 0x060007C0 RID: 1984 RVA: 0x000F7147 File Offset: 0x000F5347
            public sealed override IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                int count = this._BEE.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    _bh2._ACW node = this._BEE[i];
                    foreach (_bh2._AEN subnode in node.EnumerateIdNodes())
                    {
                        yield return subnode;
                    }
                    IEnumerator<_bh2._AEN> enumerator = null;
                    node = null;
                    num = i + 1;
                }
                yield break;
                yield break;
            }

            // Token: 0x060007C1 RID: 1985 RVA: 0x000F7157 File Offset: 0x000F5357
            public override IEnumerable<T> EnumerateNodesOfType<T>()
            {
                int count = this._BEE.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    _bh2._ACW node = this._BEE[i];
                    foreach (T subnode in node.EnumerateNodesOfType<T>())
                    {
                        yield return subnode;
                    }
                    IEnumerator<T> enumerator = null;
                    node = null;
                    num = i + 1;
                }
                base.EnumerateNodesOfType<T>();
                yield break;
                yield break;
            }

            // Token: 0x04000686 RID: 1670
            protected List<_bh2._ACW> _BEE = new List<_bh2._ACW>();
        }

        // Token: 0x0200010F RID: 271
        public class _BEG : _bh2._ACW
        {
            // Token: 0x060007DE RID: 2014 RVA: 0x000F77BC File Offset: 0x000F59BC
            public _BEG(_bh2._ACW node)
            {
                _bh2._AEN _AJU = node as _bh2._AEN;
                bool flag = _AJU != null;
                if (flag)
                {
                    node = _AJU.Clone();
                }
                node.OOME = this;
                this._BEH = node;
            }

            // Token: 0x060007DF RID: 2015 RVA: 0x000F77F8 File Offset: 0x000F59F8
            public override _bh2._ACW GetNode()
            {
                bool flag = this._BEH is _bh2._BDU;
                _bh2._ACW _AGZ;
                if (flag)
                {
                    _AGZ = new _bh2._BEG(this._BEH.GetNode());
                }
                else
                {
                    bool flag2 = this._BEH is _bh2._BEG;
                    if (flag2)
                    {
                        _AGZ = this._BEH;
                    }
                    else
                    {
                        _AGZ = this;
                    }
                }
                return _AGZ;
            }

            // Token: 0x060007E0 RID: 2016 RVA: 0x000F784C File Offset: 0x000F5A4C
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    this._BCY = new _bh2._AGI(this._BEH.SetLookahead(parser));
                    this._BCY.AddEmpty();
                }
                return this._BCY;
            }

            // Token: 0x060007E1 RID: 2017 RVA: 0x000F7898 File Offset: 0x000F5A98
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                this.SetLookahead(parser);
                this._BDT = succ;
                this._BEH.SetFollow(parser, succ);
                return this._BCY;
            }

            // Token: 0x060007E2 RID: 2018 RVA: 0x000F78D0 File Offset: 0x000F5AD0
            public override void CheckLL1(_bh2._BCX parser)
            {
                bool flag = this._BDT == null;
                if (flag)
                {
                    throw new Exception(((this != null) ? this.ToString() : null) + ": follow not set");
                }
                this._BEH.CheckLL1(parser);
            }

            // Token: 0x060007E3 RID: 2019 RVA: 0x000F7918 File Offset: 0x000F5B18
            public override bool Matches(_bh2._AJH scanner)
            {
                return this._BEH.Matches(scanner);
            }

            // Token: 0x060007E4 RID: 2020 RVA: 0x000F7938 File Offset: 0x000F5B38
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    _bh2._BEF _BEI = (this._BEH as _bh2._BEF) ?? (this._BEH as _bh2._BEJ);
                    bool flag3 = _BEI != null;
                    if (flag3)
                    {
                        for (; ; )
                        {
                            int num = scanner.CurrentTokenIndex();
                            int num2 = scanner.CurrentLine();
                            bool flag4 = !this._BEH.Scan(scanner);
                            if (flag4)
                            {
                                break;
                            }
                            bool flag5 = !scanner._BDF();
                            if (flag5)
                            {
                                goto Block_4;
                            }
                            if (scanner.CurrentTokenIndex() == num && scanner.CurrentLine() == num2)
                            {
                                goto Block_6;
                            }
                        }
                        return false;
                    Block_4:
                        return true;
                    Block_6:;
                    }
                    else
                    {
                        while (this._BCY.Matches(scanner.Current.tokenId))
                        {
                            int num3 = scanner.CurrentTokenIndex();
                            int num4 = scanner.CurrentLine();
                            bool flag6 = !this._BEH.Scan(scanner);
                            if (flag6)
                            {
                                return false;
                            }
                            bool flag7 = !scanner._BDF();
                            if (flag7)
                            {
                                return true;
                            }
                            bool flag8 = scanner.CurrentTokenIndex() == num3 && scanner.CurrentLine() == num4;
                            if (flag8)
                            {
                                throw new Exception("Infinite loop!!!");
                            }
                        }
                    }
                    flag2 = true;
                }
                return flag2;
            }

            // Token: 0x060007E5 RID: 2021 RVA: 0x000F7A78 File Offset: 0x000F5C78
            public override _bh2._ACW NextAfterChild(_bh2._ACW child, _bh2._AJH scanner)
            {
                return this;
            }

            // Token: 0x060007E6 RID: 2022 RVA: 0x000F7A8C File Offset: 0x000F5C8C
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                _bh2._BEF _BEI = this._BEH as _bh2._BEF;
                bool flag = _BEI != null;
                if (flag)
                {
                    bool flag2 = !_BEI.Matches(scanner);
                    if (flag2)
                    {
                        return this.OOME.NextAfterChild(this, scanner);
                    }
                    int num = scanner.CurrentTokenIndex();
                    int num2 = scanner.CurrentLine();
                    _bh2._ACW _AGZ = this._BEH.Parse(scanner);
                    bool flag3 = _AGZ != this || scanner.CurrentTokenIndex() != num || scanner.CurrentLine() != num2;
                    if (flag3)
                    {
                        return _AGZ;
                    }
                }
                else
                {
                    bool flag4 = !this._BCY.Matches(scanner.Current.tokenId);
                    if (flag4)
                    {
                        return this.OOME.NextAfterChild(this, scanner);
                    }
                    int num3 = scanner.CurrentTokenIndex();
                    int num4 = scanner.CurrentLine();
                    _bh2._ACW _AGZ2 = this._BEH.Parse(scanner);
                    bool flag5 = _AGZ2 != this || scanner.CurrentTokenIndex() != num3 || scanner.CurrentLine() != num4;
                    if (flag5)
                    {
                        return _AGZ2;
                    }
                }
                return this.OOME.NextAfterChild(this, scanner);
            }

            // Token: 0x060007E7 RID: 2023 RVA: 0x000F7BAC File Offset: 0x000F5DAC
            public override string ToString()
            {
                string text = "[{ ";
                _bh2._ACW _BEK = this._BEH;
                return text + ((_BEK != null) ? _BEK.ToString() : null) + " }]";
            }

            // Token: 0x060007E8 RID: 2024 RVA: 0x000F7BDF File Offset: 0x000F5DDF
            public sealed override IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                foreach (_bh2._AJI i in this._BEH.EnumerateLitNodes())
                {
                    yield return i;
                }
                IEnumerator<_bh2._AJI> enumerator = null;
                yield break;
            }

            // Token: 0x060007E9 RID: 2025 RVA: 0x000F7BEF File Offset: 0x000F5DEF
            public sealed override IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                foreach (_bh2._AEN i in this._BEH.EnumerateIdNodes())
                {
                    yield return i;
                }
                IEnumerator<_bh2._AEN> enumerator = null;
                yield break;
            }

            // Token: 0x060007EA RID: 2026 RVA: 0x000F7BFF File Offset: 0x000F5DFF
            public override IEnumerable<T> EnumerateNodesOfType<T>()
            {
                foreach (T i in this._BEH.EnumerateNodesOfType<T>())
                {
                    yield return i;
                }
                IEnumerator<T> enumerator = null;
                base.EnumerateNodesOfType<T>();
                yield break;
            }

            // Token: 0x040006A2 RID: 1698
            protected readonly _bh2._ACW _BEH;
        }

        // Token: 0x02000113 RID: 275
        protected class _BDU : _bh2._BEG
        {
            // Token: 0x06000807 RID: 2055 RVA: 0x000F80F3 File Offset: 0x000F62F3
            public _BDU(_bh2._ACW node)
                : base(node)
            {
            }

            // Token: 0x06000808 RID: 2056 RVA: 0x000F8100 File Offset: 0x000F6300
            public override _bh2._ACW GetNode()
            {
                bool flag = this._BEH is _bh2._BDU;
                _bh2._ACW _AGZ;
                if (flag)
                {
                    _AGZ = this._BEH;
                }
                else
                {
                    bool flag2 = this._BEH is _bh2._BEG;
                    if (flag2)
                    {
                        _AGZ = this._BEH;
                    }
                    else
                    {
                        _AGZ = this;
                    }
                }
                return _AGZ;
            }

            // Token: 0x06000809 RID: 2057 RVA: 0x000F814C File Offset: 0x000F634C
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag3 = this._BCY.Matches(scanner.Current.tokenId);
                    flag2 = !flag3 || this._BEH.Scan(scanner);
                }
                return flag2;
            }

            // Token: 0x0600080A RID: 2058 RVA: 0x000F819C File Offset: 0x000F639C
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                bool flag = this._BCY.Matches(scanner.Current.tokenId);
                _bh2._ACW _AGZ;
                if (flag)
                {
                    _AGZ = this._BEH.Parse(scanner);
                }
                else
                {
                    _AGZ = this.OOME.NextAfterChild(this, scanner);
                }
                return _AGZ;
            }

            // Token: 0x0600080B RID: 2059 RVA: 0x000F81E4 File Offset: 0x000F63E4
            public override _bh2._ACW NextAfterChild(_bh2._ACW child, _bh2._AJH scanner)
            {
                return (this.OOME != null) ? this.OOME.NextAfterChild(this, scanner) : null;
            }

            // Token: 0x0600080C RID: 2060 RVA: 0x000F8210 File Offset: 0x000F6410
            public override string ToString()
            {
                string text = "[ ";
                _bh2._ACW _BEK = this._BEH;
                return text + ((_BEK != null) ? _BEK.ToString() : null) + " ]";
            }
        }

        // Token: 0x02000114 RID: 276
        protected class _BEF : _bh2._BDU
        {
            // Token: 0x0600080D RID: 2061 RVA: 0x000F8243 File Offset: 0x000F6443
            public _BEF(Predicate<_bh2._AJH> pred, _bh2._ACW node, bool debug = false)
                : base(node)
            {
                this._BEL = pred;
                this._BEM = debug;
            }

            // Token: 0x0600080E RID: 2062 RVA: 0x000F825C File Offset: 0x000F645C
            public _BEF(_bh2._ACW pred, _bh2._ACW node, bool debug = false)
                : base(node)
            {
                this._BEN = pred;
                this._BEM = debug;
            }

            // Token: 0x0600080F RID: 2063 RVA: 0x000F8275 File Offset: 0x000F6475
            public _BEF(string currentText, _bh2._ACW pred, _bh2._ACW node, bool debug = false)
                : base(node)
            {
                this._BEO = currentText;
                this._BEN = pred;
                this._BEM = debug;
            }

            // Token: 0x06000810 RID: 2064 RVA: 0x000F8298 File Offset: 0x000F6498
            public override _bh2._ACW GetNode()
            {
                return this;
            }

            // Token: 0x06000811 RID: 2065 RVA: 0x000F82AC File Offset: 0x000F64AC
            public virtual bool CheckPredicate(_bh2._AJH scanner)
            {
                bool flag = this._BEL != null;
                bool flag2;
                if (flag)
                {
                    flag2 = this._BEL(scanner);
                }
                else
                {
                    bool flag3 = this._BEN != null;
                    if (flag3)
                    {
                        bool flag4 = this._BEO != null && scanner.Current.text != this._BEO;
                        flag2 = !flag4 && scanner.Lookahead(this._BEN, int.MaxValue);
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
                return flag2;
            }

            // Token: 0x06000812 RID: 2066 RVA: 0x000F8328 File Offset: 0x000F6528
            public override bool Matches(_bh2._AJH scanner)
            {
                return this._BCY.Matches(scanner.Current) && this.CheckPredicate(scanner);
            }

            // Token: 0x06000813 RID: 2067 RVA: 0x000F8358 File Offset: 0x000F6558
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag3 = this._BCY.Matches(scanner.Current.tokenId) && this.CheckPredicate(scanner);
                    flag2 = !flag3 || this._BEH.Scan(scanner);
                }
                return flag2;
            }

            // Token: 0x06000814 RID: 2068 RVA: 0x000F83B4 File Offset: 0x000F65B4
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                bool flag = this._BCY.Matches(scanner.Current.tokenId) && this.CheckPredicate(scanner);
                _bh2._ACW _AGZ;
                if (flag)
                {
                    _AGZ = this._BEH.Parse(scanner);
                }
                else
                {
                    _AGZ = this.OOME.NextAfterChild(this, scanner);
                }
                return _AGZ;
            }

            // Token: 0x06000815 RID: 2069 RVA: 0x000F8408 File Offset: 0x000F6608
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    this._BCY = new _bh2._AGI(this._BEH.SetLookahead(parser));
                }
                return this._BCY;
            }

            // Token: 0x06000816 RID: 2070 RVA: 0x000F8444 File Offset: 0x000F6644
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                bool flag = this._BEN != null && this._BEN._BDT == null;
                if (flag)
                {
                    this._BEN.SetFollow(parser, new _bh2._AGI());
                }
                return base.SetFollow(parser, succ);
            }

            // Token: 0x06000817 RID: 2071 RVA: 0x000F8490 File Offset: 0x000F6690
            public override string ToString()
            {
                string[] array = new string[5];
                array[0] = "[ ?(";
                int num = 1;
                Predicate<_bh2._AJH> _BEP = this._BEL;
                array[num] = ((_BEP != null) ? _BEP.ToString() : null);
                array[2] = ") ";
                int num2 = 3;
                _bh2._ACW _BEK = this._BEH;
                array[num2] = ((_BEK != null) ? _BEK.ToString() : null);
                array[4] = " ]";
                return string.Concat(array);
            }

            // Token: 0x040006B5 RID: 1717
            protected readonly string _BEO;

            // Token: 0x040006B6 RID: 1718
            protected readonly Predicate<_bh2._AJH> _BEL;

            // Token: 0x040006B7 RID: 1719
            protected readonly _bh2._ACW _BEN;

            // Token: 0x040006B8 RID: 1720
            protected readonly bool _BEM;
        }

        // Token: 0x02000115 RID: 277
        protected class _BEJ : _bh2._BEF
        {
            // Token: 0x06000818 RID: 2072 RVA: 0x000F84EF File Offset: 0x000F66EF
            public _BEJ(_bh2._ACW pred, _bh2._ACW node)
                : base(pred, node, false)
            {
            }

            // Token: 0x06000819 RID: 2073 RVA: 0x000F84FC File Offset: 0x000F66FC
            public override bool CheckPredicate(_bh2._AJH scanner)
            {
                return !base.CheckPredicate(scanner);
            }
        }

        // Token: 0x02000116 RID: 278
        public class _BDS : _bh2._ACW
        {
            // Token: 0x0600081A RID: 2074 RVA: 0x000F8518 File Offset: 0x000F6718
            public _BDS(params _bh2._ACW[] nodes)
            {
                foreach (_bh2._ACW _AGZ in nodes)
                {
                    this.Add(_AGZ);
                }
            }

            // Token: 0x0600081B RID: 2075 RVA: 0x000F8558 File Offset: 0x000F6758
            public sealed override void Add(_bh2._ACW node)
            {
                _bh2._AEN _AJU = node as _bh2._AEN;
                bool flag = _AJU != null;
                if (flag)
                {
                    node = _AJU.Clone();
                }
                _bh2._BDS _BEQ = node as _bh2._BDS;
                bool flag2 = _BEQ != null;
                if (flag2)
                {
                    for (int i = 0; i < _BEQ._BEE.Count; i++)
                    {
                        this.Add(_BEQ._BEE[i]);
                    }
                }
                else
                {
                    node.OOME = this;
                    node._AIL = this._BEE.Count;
                    this._BEE.Add(node);
                }
            }

            // Token: 0x0600081C RID: 2076 RVA: 0x000F85EC File Offset: 0x000F67EC
            public override _bh2._ACW GetNode()
            {
                return (this._BEE.Count == 1) ? this._BEE[0] : this;
            }

            // Token: 0x0600081D RID: 2077 RVA: 0x000F861C File Offset: 0x000F681C
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    this._BCY = new _bh2._AGI();
                    bool flag2 = this._BEE.Count == 0;
                    if (flag2)
                    {
                        this._BCY.AddEmpty();
                    }
                    else
                    {
                        for (int i = 0; i < this._BEE.Count; i++)
                        {
                            _bh2._ACW _AGZ = this._BEE[i];
                            _bh2._AGI _BEC = _AGZ.SetLookahead(parser);
                            this._BCY.Add(_BEC);
                            bool flag3 = !_BEC.MatchesEmpty();
                            if (flag3)
                            {
                                this._BCY.RemoveEmpty();
                                break;
                            }
                        }
                    }
                }
                return this._BCY;
            }

            // Token: 0x0600081E RID: 2078 RVA: 0x000F86D4 File Offset: 0x000F68D4
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                this.SetLookahead(parser);
                this._BDT = succ;
                int count = this._BEE.Count;
                while (count-- > 0)
                {
                    _bh2._AGI _BEC = this._BEE[count].SetFollow(parser, succ);
                    bool flag = _BEC.MatchesEmpty();
                    if (flag)
                    {
                        _BEC = new _bh2._AGI(_BEC);
                        _BEC.RemoveEmpty();
                        _BEC.Add(succ);
                    }
                    succ = _BEC;
                }
                return this._BCY;
            }

            // Token: 0x0600081F RID: 2079 RVA: 0x000F8754 File Offset: 0x000F6954
            public override void CheckLL1(_bh2._BCX parser)
            {
                base.CheckLL1(parser);
                int count = this._BEE.Count;
                for (int i = 0; i < count; i++)
                {
                    _bh2._ACW _AGZ = this._BEE[i];
                    _AGZ.CheckLL1(parser);
                }
            }

            // Token: 0x06000820 RID: 2080 RVA: 0x000F87A0 File Offset: 0x000F69A0
            public override bool Scan(_bh2._AJH scanner)
            {
                int count = this._BEE.Count;
                int i = 0;
                while (i < count)
                {
                    _bh2._ACW _AGZ = this._BEE[i];
                    bool flag = !scanner._BDF();
                    bool flag2;
                    if (flag)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        bool flag3 = !_AGZ.Scan(scanner);
                        if (!flag3)
                        {
                            i++;
                            continue;
                        }
                        flag2 = false;
                    }
                    return flag2;
                }
                return true;
            }

            // Token: 0x06000821 RID: 2081 RVA: 0x000F880C File Offset: 0x000F6A0C
            public override _bh2._ACW NextAfterChild(_bh2._ACW child, _bh2._AJH scanner)
            {
                int num = child._AIL;
                bool flag = ++num < this._BEE.Count;
                _bh2._ACW _AGZ;
                if (flag)
                {
                    _AGZ = this._BEE[num];
                }
                else
                {
                    _AGZ = base.NextAfterChild(this, scanner);
                }
                return _AGZ;
            }

            // Token: 0x06000822 RID: 2082 RVA: 0x000F8854 File Offset: 0x000F6A54
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                return this._BEE[0].Parse(scanner);
            }

            // Token: 0x06000823 RID: 2083 RVA: 0x000F8878 File Offset: 0x000F6A78
            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder("( ");
                foreach (_bh2._ACW _AGZ in this._BEE)
                {
                    StringBuilder stringBuilder2 = stringBuilder;
                    string text = " ";
                    _bh2._ACW _AGZ2 = _AGZ;
                    stringBuilder2.Append(text + ((_AGZ2 != null) ? _AGZ2.ToString() : null));
                }
                stringBuilder.Append(" )");
                return stringBuilder.ToString();
            }

            // Token: 0x06000824 RID: 2084 RVA: 0x000F8908 File Offset: 0x000F6B08
            public sealed override IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                int count = this._BEE.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    _bh2._ACW node = this._BEE[i];
                    foreach (_bh2._AJI subnode in node.EnumerateLitNodes())
                    {
                        yield return subnode;
                    }
                    IEnumerator<_bh2._AJI> enumerator = null;
                    node = null;
                    num = i + 1;
                }
                yield break;
            }

            // Token: 0x06000825 RID: 2085 RVA: 0x000F8918 File Offset: 0x000F6B18
            public sealed override IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                int count = this._BEE.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    _bh2._ACW node = this._BEE[i];
                    foreach (_bh2._AEN subnode in node.EnumerateIdNodes())
                    {
                        yield return subnode;
                    }
                    IEnumerator<_bh2._AEN> enumerator = null;
                    node = null;
                    num = i + 1;
                }
                yield break;
            }

            // Token: 0x06000826 RID: 2086 RVA: 0x000F8928 File Offset: 0x000F6B28
            public override IEnumerable<T> EnumerateNodesOfType<T>()
            {
                int count = this._BEE.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    _bh2._ACW node = this._BEE[i];
                    foreach (T subnode in node.EnumerateNodesOfType<T>())
                    {
                        yield return subnode;
                    }
                    IEnumerator<T> enumerator = null;
                    node = null;
                    num = i + 1;
                }
                yield break;
            }

            // Token: 0x040006B9 RID: 1721
            private readonly List<_bh2._ACW> _BEE = new List<_bh2._ACW>();
        }

        // Token: 0x0200011A RID: 282
        public class _BDZ : _bh2._ACW
        {
            // Token: 0x06000842 RID: 2114 RVA: 0x000F8F77 File Offset: 0x000F7177
            public _BDZ(string name, _bh2._AGI lookahead)
            {
                this._AW = name;
                this._BCY = lookahead;
            }

            // Token: 0x06000843 RID: 2115 RVA: 0x000F8F90 File Offset: 0x000F7190
            public _bh2._BDZ Clone()
            {
                return new _bh2._BDZ(this._AW, this._BCY);
            }

            // Token: 0x06000844 RID: 2116 RVA: 0x000F8FB8 File Offset: 0x000F71B8
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                return this._BCY;
            }

            // Token: 0x06000845 RID: 2117 RVA: 0x000F8FD0 File Offset: 0x000F71D0
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                return this._BCY;
            }

            // Token: 0x06000846 RID: 2118 RVA: 0x00014488 File Offset: 0x00012688
            public override void CheckLL1(_bh2._BCX parser)
            {
            }

            // Token: 0x06000847 RID: 2119 RVA: 0x000F8FE8 File Offset: 0x000F71E8
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag3 = !this._BCY.Matches(scanner.Current.tokenId);
                    if (flag3)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        scanner.MoveNext();
                        flag2 = true;
                    }
                }
                return flag2;
            }

            // Token: 0x06000848 RID: 2120 RVA: 0x000F9034 File Offset: 0x000F7234
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                bool flag = !this._BCY.Matches(scanner.Current.tokenId);
                _bh2._ACW _AGZ;
                if (flag)
                {
                    scanner.SyntaxErrorExpected(this._BCY);
                    _AGZ = this;
                }
                else
                {
                    scanner._AJT.AddToken(scanner)._AJD = this;
                    scanner.MoveNext();
                    bool flag2 = scanner._BDN == null;
                    if (flag2)
                    {
                        scanner._BDP = scanner._AJT;
                        scanner._BDO = scanner._BDL;
                    }
                    _AGZ = this.OOME.NextAfterChild(this, scanner);
                }
                return _AGZ;
            }

            // Token: 0x06000849 RID: 2121 RVA: 0x000F90C4 File Offset: 0x000F72C4
            public override string ToString()
            {
                return this._AW;
            }

            // Token: 0x040006D5 RID: 1749
            protected string _AW;
        }

        // Token: 0x0200011B RID: 283
        public class _BCX : _bh2._ACW
        {
            // Token: 0x0600084A RID: 2122 RVA: 0x000F90DC File Offset: 0x000F72DC
            public _bh2._AJQ _BER()
            {
                return this._BES[0];
            }

            // Token: 0x0600084B RID: 2123 RVA: 0x000F90FC File Offset: 0x000F72FC
            public _BCX(_bh2._AJQ start, _bh2 grammar)
            {
                this._BES.Add(start);
            }

            // Token: 0x0600084C RID: 2124 RVA: 0x000F9154 File Offset: 0x000F7354
            public void Add(_bh2._AJQ rule)
            {
                string nt = rule.GetNt();
                bool flag = this._BET.ContainsKey(nt);
                if (flag)
                {
                    throw new Exception(nt + ": duplicate");
                }
                this._BET.Add(nt, rule);
                this._BES.Add(rule);
            }

            // Token: 0x0600084D RID: 2125 RVA: 0x000F91A8 File Offset: 0x000F73A8
            public void InitializeGrammar()
            {
                HashSet<string> hashSet = new HashSet<string>();
                List<string> list = new List<string>();
                foreach (_bh2._AJI _AJJ in this.EnumerateLitNodes())
                {
                    bool flag = hashSet.Add(_AJJ._AJL);
                    if (flag)
                    {
                        list.Add(_AJJ._AJL);
                    }
                }
                foreach (_bh2._AEN _AJU in this.EnumerateIdNodes())
                {
                    string name = _AJU.GetName();
                    bool flag2 = this._BEU.ContainsKey(name);
                    if (!flag2)
                    {
                        this._BEU.Add(name, this._BET.ContainsKey(name) ? this._BET[name] : null);
                        list.Add(name);
                    }
                }
                list.Sort();
                this.EOIA = list.ToArray();
                for (int i = 0; i < this.EOIA.Length; i++)
                {
                    string text = this.EOIA[i];
                    this._BEV[text] = i;
                    bool flag3 = !hashSet.Contains(text) && this._BEU[text] == null;
                    if (flag3)
                    {
                        this._BEU[text] = new _bh2._BDZ(text, new _bh2._AGI(i));
                        bool flag4 = text == "NAME";
                        if (flag4)
                        {
                            this._BEU[text]._BCY.Add(this._BEU["IDENTIFIER"]._BCY);
                        }
                    }
                }
                this.SetLookahead(this);
                this.SetFollow(this, null);
                this.CheckLL1(this);
            }

            // Token: 0x0600084E RID: 2126 RVA: 0x000F93A0 File Offset: 0x000F75A0
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                int count = this._BES.Count;
                for (int i = 0; i < count; i++)
                {
                    _bh2._AJQ _BEB = this._BES[i];
                    _BEB.SetLookahead(this);
                }
                return null;
            }

            // Token: 0x0600084F RID: 2127 RVA: 0x000F93E8 File Offset: 0x000F75E8
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                this._BER().SetFollow();
                bool flag;
                do
                {
                    int num = this._BES.Count;
                    for (int i = 0; i < num; i++)
                    {
                        this._BES[i].SetFollow(this);
                    }
                    flag = false;
                    num = this._BES.Count;
                    for (int j = 0; j < num; j++)
                    {
                        flag |= this._BES[j].FollowChanged();
                    }
                }
                while (flag);
                return null;
            }

            // Token: 0x06000850 RID: 2128 RVA: 0x000F947C File Offset: 0x000F767C
            public override void CheckLL1(_bh2._BCX parser)
            {
                int count = this._BES.Count;
                for (int i = 0; i < count; i++)
                {
                    this._BES[i].CheckLL1(this);
                }
            }

            // Token: 0x06000851 RID: 2129 RVA: 0x000DC3B8 File Offset: 0x000DA5B8
            public override bool Scan(_bh2._AJH scanner)
            {
                throw new InvalidOperationException();
            }

            // Token: 0x06000852 RID: 2130 RVA: 0x000DC3B8 File Offset: 0x000DA5B8
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                throw new InvalidOperationException();
            }

            // Token: 0x06000853 RID: 2131 RVA: 0x000F94BC File Offset: 0x000F76BC
            public _bb4 ParseAll(_bh2._AJH scanner)
            {
                bool flag = !scanner.MoveNext();
                _bb4 _BEW;
                if (flag)
                {
                    _BEW = null;
                }
                else
                {
                    _bb4 _BEW2 = new _bb4();
                    _bh2._AEN _AJU = new _bh2._AEN(this._BER().GetNt());
                    this._BEU[this._BER().GetNt()] = this._BER();
                    _AJU.SetLookahead(this);
                    this._BER().OOME = _AJU;
                    scanner._AJT = (_BEW2._AIT = new _bb4._ACW(_AJU));
                    scanner._BDL = this._BER().Parse(scanner);
                    scanner._BDP = scanner._AJT;
                    scanner._BDO = scanner._BDL;
                    while (scanner._BDL != null)
                    {
                        int num = scanner.CurrentLine();
                        int num2 = scanner.CurrentTokenIndex();
                        _bh2._ACW _BEX = scanner._BDL;
                        _bb4._ACW _BEY = scanner._AJT;
                        bool flag2 = !this.ParseStep(scanner);
                        if (flag2)
                        {
                            break;
                        }
                        bool flag3 = scanner._BDN == null;
                        if (flag3)
                        {
                            bool flag4 = scanner._AJT == _BEY && scanner._BDL == _BEX && scanner.CurrentTokenIndex() == num2 && scanner.CurrentLine() == num;
                            if (flag4)
                            {
                                this._BEZ = false;
                            }
                        }
                    }
                    _BEW = _BEW2;
                }
                return _BEW;
            }

            // Token: 0x06000854 RID: 2132 RVA: 0x000F9600 File Offset: 0x000F7800
            public bool ParseStep(_bh2._AJH scanner)
            {
                bool flag = scanner._BDL == null;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    SyntaxToken syntaxToken = scanner.Current;
                    bool flag3 = scanner._BDN == null;
                    if (flag3)
                    {
                        while (scanner._BDL != null)
                        {
                            scanner._BDL = scanner._BDL.Parse(scanner);
                            bool flag4 = scanner._BDN != null || syntaxToken != scanner.Current;
                            if (flag4)
                            {
                                break;
                            }
                        }
                        bool flag5 = scanner._BDN == null && syntaxToken != scanner.Current;
                        if (flag5)
                        {
                            scanner._BDP = scanner._AJT;
                            scanner._BDO = scanner._BDL;
                        }
                    }
                    bool flag6 = scanner._BDN != null;
                    if (flag6)
                    {
                        bool flag7 = syntaxToken.tokenKind == SyntaxToken.Kind.EOF;
                        if (flag7)
                        {
                            return false;
                        }
                        _bb4._ACW _BEY = scanner._AJT;
                        _bh2._ACW _BEX = scanner._BDL;
                        scanner._AJT = scanner._BDP;
                        scanner._BDL = scanner._BDO;
                        bool flag8 = scanner._AJT != null;
                        if (flag8)
                        {
                            _bb4._ACW _BEY2 = scanner._AJT;
                            while (_BEY2._AIY() != null && !_BEY2._AIY().HasLeafs())
                            {
                                _BEY2.InvalidateFrom((int)_BEY2._AIY()._AIL);
                            }
                        }
                        bool flag9 = !this._BEZ;
                        if (flag9)
                        {
                            this._BEZ = true;
                            scanner._BDL = null;
                        }
                        else
                        {
                            bool flag10 = scanner._BDL != null;
                            if (flag10)
                            {
                                int num;
                                scanner._BDL = scanner._BDL.Recover(scanner, out num);
                            }
                        }
                        bool flag11 = scanner._BDL == null;
                        if (flag11)
                        {
                            bool flag12 = syntaxToken.OOME != null;
                            if (flag12)
                            {
                                syntaxToken.OOME.ReparseToken();
                            }
                            new _bb4.DHBA(scanner);
                            bool flag13 = _bh2._BCX._BDA == scanner._BDO;
                            if (flag13)
                            {
                                syntaxToken.OOME._AJB = _bh2._BCX._BDB;
                            }
                            else
                            {
                                syntaxToken.OOME._AJB = new _bh2._BDA(this, scanner._BDO._BCY);
                                _bh2._BCX._BDB = syntaxToken.OOME._AJB;
                                _bh2._BCX._BDA = scanner._BDO;
                            }
                            scanner._BDL = scanner._BDO;
                            scanner._AJT = scanner._BDP;
                            bool flag14 = !scanner.MoveNext();
                            if (flag14)
                            {
                                return false;
                            }
                            scanner._BDN = null;
                        }
                        else
                        {
                            bool flag15 = _BEX != null && _BEY != null;
                            if (flag15)
                            {
                                scanner._AJT = _BEY;
                                scanner._BDL = _BEX;
                            }
                            scanner.InsertMissingToken(scanner._BDN ?? new _bh2._BCZ(this, _BEX._BCY));
                            bool flag16 = _BEX != null && _BEY != null;
                            if (flag16)
                            {
                                scanner._BDN = null;
                                scanner._BDM = null;
                                scanner._AJT = _BEY;
                                scanner._BDL = _BEX;
                                scanner._BDL = _BEX.OOME.NextAfterChild(_BEX, scanner);
                            }
                            scanner._BDN = null;
                            scanner._BDM = null;
                        }
                    }
                    flag2 = true;
                }
                return flag2;
            }

            // Token: 0x06000855 RID: 2133 RVA: 0x000F9910 File Offset: 0x000F7B10
            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder(base.GetType().Name + " {\n");
                foreach (_bh2._AJQ _BEB in this._BES)
                {
                    stringBuilder.AppendLine(_BEB.ToString(this));
                }
                stringBuilder.Append("}");
                return stringBuilder.ToString();
            }

            // Token: 0x06000856 RID: 2134 RVA: 0x000F99A0 File Offset: 0x000F7BA0
            public int TokenToId(string s)
            {
                int num;
                bool flag = !this._BEV.TryGetValue(s, out num);
                if (flag)
                {
                    num = -1;
                }
                return num;
            }

            // Token: 0x06000857 RID: 2135 RVA: 0x000F99CC File Offset: 0x000F7BCC
            public string GetToken(int tokenId)
            {
                return (tokenId >= 0 && tokenId < this.EOIA.Length) ? this.EOIA[tokenId] : (tokenId.ToString() + "?");
            }

            // Token: 0x06000858 RID: 2136 RVA: 0x000F9A08 File Offset: 0x000F7C08
            public _bh2._ACW GetPeer(string name)
            {
                _bh2._ACW _AGZ = this._BEU[name];
                _bh2._BDZ _BEA = _AGZ as _bh2._BDZ;
                bool flag = _BEA != null;
                if (flag)
                {
                    _AGZ = _BEA.Clone();
                }
                return _AGZ;
            }

            // Token: 0x06000859 RID: 2137 RVA: 0x000F9A3E File Offset: 0x000F7C3E
            public sealed override IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                int count = this._BES.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    foreach (_bh2._AJI node in this._BES[i].EnumerateLitNodes())
                    {
                        yield return node;
                    }
                    IEnumerator<_bh2._AJI> enumerator = null;
                    num = i + 1;
                }
                yield break;
            }

            // Token: 0x0600085A RID: 2138 RVA: 0x000F9A4E File Offset: 0x000F7C4E
            public sealed override IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                int count = this._BES.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    foreach (_bh2._AEN node in this._BES[i].EnumerateIdNodes())
                    {
                        yield return node;
                    }
                    IEnumerator<_bh2._AEN> enumerator = null;
                    num = i + 1;
                }
                yield break;
            }

            // Token: 0x0600085B RID: 2139 RVA: 0x000F9A5E File Offset: 0x000F7C5E
            public override IEnumerable<T> EnumerateNodesOfType<T>()
            {
                int count = this._BES.Count;
                int num;
                for (int i = 0; i < count; i = num)
                {
                    foreach (T node in this._BES[i].EnumerateNodesOfType<T>())
                    {
                        yield return node;
                     }
                    IEnumerator<T> enumerator = null;
                    num = i + 1;
                }
                base.EnumerateNodesOfType<T>();
                yield break;
            }

            // Token: 0x040006D6 RID: 1750
            private readonly List<_bh2._AJQ> _BES = new List<_bh2._AJQ>();

            // Token: 0x040006D7 RID: 1751
            private readonly Dictionary<string, _bh2._AJQ> _BET = new Dictionary<string, _bh2._AJQ>();

            // Token: 0x040006D8 RID: 1752
            protected Dictionary<string, _bh2._ACW> _BEU = new Dictionary<string, _bh2._ACW>();

            // Token: 0x040006D9 RID: 1753
            protected string[] EOIA;

            // Token: 0x040006DA RID: 1754
            protected Dictionary<string, int> _BEV = new Dictionary<string, int>();

            // Token: 0x040006DB RID: 1755
            public bool _BEZ = true;

            // Token: 0x040006DC RID: 1756
            private static _bh2._AJE _BDB;

            // Token: 0x040006DD RID: 1757
            private static _bh2._ACW _BDA;
        }

        // Token: 0x0200011F RID: 287
        public class _AJQ : _bh2._ACW
        {
            // Token: 0x06000878 RID: 2168 RVA: 0x000FA060 File Offset: 0x000F8260
            public _AJQ(string nt, _bh2._ACW rhs)
            {
                _bh2._AEN _AJU = rhs as _bh2._AEN;
                bool flag = _AJU != null;
                if (flag)
                {
                    rhs = _AJU.Clone();
                }
                this._BDC = nt;
                rhs.OOME = this;
                this._BDD = rhs;
            }

            // Token: 0x06000879 RID: 2169 RVA: 0x000FA0A4 File Offset: 0x000F82A4
            public override _bh2._AGI SetLookahead(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    bool _BDE = this._BDF;
                    if (_BDE)
                    {
                        throw new Exception(this._BDC + ": recursive lookahead");
                    }
                    this._BDF = true;
                    this._BCY = this._BDD.SetLookahead(parser);
                }
                return this._BCY;
            }

            // Token: 0x0600087A RID: 2170 RVA: 0x000FA104 File Offset: 0x000F8304
            public bool FollowChanged()
            {
                this._BDF = this._BDG;
                this._BDG = false;
                return this._BDF;
            }

            // Token: 0x0600087B RID: 2171 RVA: 0x000FA12F File Offset: 0x000F832F
            public void SetFollow()
            {
                this._BDT = new _bh2._AGI();
            }

            // Token: 0x0600087C RID: 2172 RVA: 0x000FA140 File Offset: 0x000F8340
            public void SetFollow(_bh2._BCX parser)
            {
                bool flag = this._BCY == null;
                if (flag)
                {
                    throw new Exception(this._BDC + ": lookahead not set");
                }
                bool flag2 = this._BDT == null;
                if (!flag2)
                {
                    bool _BDE = this._BDF;
                    if (_BDE)
                    {
                        this._BDD.SetFollow(parser, this._BDT);
                    }
                }
            }

            // Token: 0x0600087D RID: 2173 RVA: 0x000FA1A0 File Offset: 0x000F83A0
            public override _bh2._AGI SetFollow(_bh2._BCX parser, _bh2._AGI succ)
            {
                bool flag = this._BDT == null;
                if (flag)
                {
                    this._BDG = true;
                    this._BDT = new _bh2._AGI(succ);
                }
                else
                {
                    bool flag2 = this._BDT.Add(succ);
                    if (flag2)
                    {
                        this._BDG = true;
                    }
                }
                return this._BCY;
            }

            // Token: 0x0600087E RID: 2174 RVA: 0x000FA1F8 File Offset: 0x000F83F8
            public override void CheckLL1(_bh2._BCX parser)
            {
                bool flag = !this._BDH;
                if (flag)
                {
                    base.CheckLL1(parser);
                    this._BDD.CheckLL1(parser);
                }
            }

            // Token: 0x0600087F RID: 2175 RVA: 0x000FA22C File Offset: 0x000F842C
            public override bool Scan(_bh2._AJH scanner)
            {
                bool flag = !scanner._BDF();
                bool flag2;
                if (flag)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag3 = this._BCY.Matches(scanner.Current);
                    if (flag3)
                    {
                        flag2 = this._BDD.Scan(scanner);
                    }
                    else
                    {
                        bool flag4 = !this._BCY.MatchesEmpty();
                        flag2 = !flag4;
                    }
                }
                return flag2;
            }

            // Token: 0x06000880 RID: 2176 RVA: 0x000FA28C File Offset: 0x000F848C
            public override _bh2._ACW Parse(_bh2._AJH scanner)
            {
                return this.RhsParse2(scanner);
            }

            // Token: 0x06000881 RID: 2177 RVA: 0x000FA2A8 File Offset: 0x000F84A8
            public override _bh2._ACW NextAfterChild(_bh2._ACW child, _bh2._AJH scanner)
            {
                _bb4._ACW _BEY = scanner._AJT;
                bool flag = _BEY == null;
                _bh2._ACW _AGZ;
                if (flag)
                {
                    _AGZ = null;
                }
                else
                {
                    _bh2._ACW _AGZ2 = ((_BEY._AJD != null) ? _BEY._AJD.NextAfterChild(this, scanner) : null);
                    bool _BDI = scanner._BDQ;
                    if (_BDI)
                    {
                        _AGZ = _AGZ2;
                    }
                    else
                    {
                        bool flag2 = this._BDH && _BEY._AIX == 1;
                        if (flag2)
                        {
                            SyntaxToken _BDJ = _BEY.LeafAt(0)._ACX;
                            _BDJ.tokenKind = SyntaxToken.Kind.ContextualKeyword;
                        }
                        bool flag3 = _BEY._AJO() > _bc1.None;
                        if (flag3)
                        {
                            scanner.OnReduceSemanticNode(_BEY);
                        }
                        _AGZ = _AGZ2;
                    }
                }
                return _AGZ;
            }

            // Token: 0x06000882 RID: 2178 RVA: 0x000FA344 File Offset: 0x000F8544
            private _bh2._ACW RhsParse2(_bh2._AJH scanner)
            {
                bool flag = scanner._BDN != null;
                _bh2._ACW _AGZ = null;
                bool flag2 = this._BCY.Matches(scanner.Current);
                if (flag2)
                {
                    _AGZ = this._BDD.Parse(scanner);
                }
                bool flag3 = (_AGZ == null || (!flag && scanner._BDN != null)) && !this._BCY.MatchesEmpty();
                _bh2._ACW _AGZ2;
                if (flag3)
                {
                    scanner.SyntaxErrorExpected(this._BCY);
                    _AGZ2 = _AGZ ?? this;
                }
                else
                {
                    bool flag4 = _AGZ != null;
                    if (flag4)
                    {
                        _AGZ2 = _AGZ;
                    }
                    else
                    {
                        _AGZ2 = this.NextAfterChild(this._BDD, scanner);
                    }
                }
                return _AGZ2;
            }

            // Token: 0x06000883 RID: 2179 RVA: 0x000FA3E0 File Offset: 0x000F85E0
            public override string ToString()
            {
                string _BDK = this._BDC;
                string text = " : ";
                _bh2._ACW _BDL = this._BDD;
                return _BDK + text + ((_BDL != null) ? _BDL.ToString() : null) + " .";
            }

            // Token: 0x06000884 RID: 2180 RVA: 0x000FA41C File Offset: 0x000F861C
            public string ToString(_bh2._BCX parser)
            {
                string _BDK = this._BDC;
                string text = " : ";
                _bh2._ACW _BDL = this._BDD;
                StringBuilder stringBuilder = new StringBuilder(_BDK + text + ((_BDL != null) ? _BDL.ToString() : null) + " .");
                bool flag = this._BCY != null;
                if (flag)
                {
                    stringBuilder.Append("\n  lookahead " + this._BCY.ToString(parser));
                }
                bool flag2 = this._BDT != null;
                if (flag2)
                {
                    stringBuilder.Append("\n  follow " + this._BDT.ToString(parser));
                }
                return stringBuilder.ToString();
            }

            // Token: 0x06000885 RID: 2181 RVA: 0x000FA4B8 File Offset: 0x000F86B8
            public string GetNt()
            {
                return this._BDC;
            }

            // Token: 0x06000886 RID: 2182 RVA: 0x000FA4D0 File Offset: 0x000F86D0
            public sealed override IEnumerable<_bh2._AJI> EnumerateLitNodes()
            {
                foreach (_bh2._AJI node in this._BDD.EnumerateLitNodes())
                {
                    yield return node;
                }
                IEnumerator<_bh2._AJI> enumerator = null;
                yield break;
            }

            // Token: 0x06000887 RID: 2183 RVA: 0x000FA4E0 File Offset: 0x000F86E0
            public sealed override IEnumerable<_bh2._AEN> EnumerateIdNodes()
            {
                foreach (_bh2._AEN node in this._BDD.EnumerateIdNodes())
                {
                    yield return node;
                }
                IEnumerator<_bh2._AEN> enumerator = null;
                yield break;
            }

            // Token: 0x06000888 RID: 2184 RVA: 0x000FA4F0 File Offset: 0x000F86F0
            public override IEnumerable<T> EnumerateNodesOfType<T>()
            {
                foreach (T node in this._BDD.EnumerateNodesOfType<T>())
                {
                    yield return node;
                }
                IEnumerator<T> enumerator = null;
                base.EnumerateNodesOfType<T>();
                yield break;
            }

            // Token: 0x040006F6 RID: 1782
            public static bool _BEM;

            // Token: 0x040006F7 RID: 1783
            public _bc1 _AJR;

            // Token: 0x040006F8 RID: 1784
            public bool _BDM;

            // Token: 0x040006F9 RID: 1785
            public bool _BDH;

            // Token: 0x040006FA RID: 1786
            protected string _BDC;

            // Token: 0x040006FB RID: 1787
            protected _bh2._ACW _BDD;

            // Token: 0x040006FC RID: 1788
            protected bool _BDF;

            // Token: 0x040006FD RID: 1789
            protected bool _BDG;
        }

        // Token: 0x02000123 RID: 291
        public class _AGI
        {
            // Token: 0x060008A5 RID: 2213 RVA: 0x000FA9E4 File Offset: 0x000F8BE4
            public int GetDataSet(out BitArray bitArray)
            {
                bitArray = this._BDN;
                return this._BDO;
            }

            // Token: 0x060008A6 RID: 2214 RVA: 0x000FAA04 File Offset: 0x000F8C04
            public _AGI()
            {
            }

            // Token: 0x060008A7 RID: 2215 RVA: 0x000FAA15 File Offset: 0x000F8C15
            public _AGI(int tokenId)
            {
                this._BDO = tokenId;
            }

            // Token: 0x060008A8 RID: 2216 RVA: 0x000FAA30 File Offset: 0x000F8C30
            public _AGI(_bh2._AGI s)
            {
                this._BDP = s._BDP;
                bool flag = s._BDN != null;
                if (flag)
                {
                    this._BDN = new BitArray(s._BDN);
                }
                else
                {
                    this._BDO = s._BDO;
                }
            }

            // Token: 0x060008A9 RID: 2217 RVA: 0x000FAA84 File Offset: 0x000F8C84
            public void AddEmpty()
            {
                this._BDP = true;
            }

            // Token: 0x060008AA RID: 2218 RVA: 0x000FAA8E File Offset: 0x000F8C8E
            public void RemoveEmpty()
            {
                this._BDP = false;
            }

            // Token: 0x060008AB RID: 2219 RVA: 0x000FAA98 File Offset: 0x000F8C98
            public bool Remove(int token)
            {
                bool flag = this._BDN == null;
                bool flag3;
                if (flag)
                {
                    bool flag2 = token != this._BDO;
                    if (flag2)
                    {
                        flag3 = false;
                    }
                    else
                    {
                        this._BDO = -1;
                        flag3 = true;
                    }
                }
                else
                {
                    bool flag4 = token >= this._BDN.Count;
                    if (flag4)
                    {
                        Debug.LogError("Unknown token " + token.ToString());
                    }
                    bool flag5 = this._BDN[token];
                    this._BDN[token] = false;
                    flag3 = flag5;
                }
                return flag3;
            }

            // Token: 0x060008AC RID: 2220 RVA: 0x000FAB24 File Offset: 0x000F8D24
            public bool Add(_bh2._AGI s)
            {
                bool flag = false;
                bool flag2 = s._BDP && !this._BDP;
                if (flag2)
                {
                    this._BDP = true;
                    flag = true;
                }
                bool flag3 = s._BDN != null;
                if (flag3)
                {
                    bool flag4 = this._BDN != null;
                    if (flag4)
                    {
                        for (int i = 0; i < s._BDN.Count; i++)
                        {
                            bool flag5 = s._BDN[i] && !this._BDN[i];
                            if (flag5)
                            {
                                this._BDN.Set(i, true);
                                flag = true;
                            }
                        }
                    }
                    else
                    {
                        this._BDN = new BitArray(s._BDN);
                        bool flag6 = this._BDO >= 0;
                        if (flag6)
                        {
                            this._BDN.Set(this._BDO, true);
                            this._BDO = -1;
                        }
                        flag = true;
                    }
                }
                else
                {
                    bool flag7 = s._BDO >= 0;
                    if (flag7)
                    {
                        bool flag8 = this._BDN != null;
                        if (flag8)
                        {
                            bool flag9 = !this._BDN.Get(s._BDO);
                            if (flag9)
                            {
                                this._BDN.Set(s._BDO, true);
                                flag = true;
                            }
                        }
                        else
                        {
                            bool flag10 = this._BDO >= 0;
                            if (flag10)
                            {
                                bool flag11 = this._BDO != s._BDO;
                                if (flag11)
                                {
                                    this._BDN = new BitArray(700, false);
                                    this._BDN.Set(s._BDO, true);
                                    this._BDN.Set(this._BDO, true);
                                    this._BDO = -1;
                                    flag = true;
                                }
                            }
                            else
                            {
                                this._BDO = s._BDO;
                                flag = true;
                            }
                        }
                    }
                }
                return flag;
            }

            // Token: 0x060008AD RID: 2221 RVA: 0x000FAD00 File Offset: 0x000F8F00
            public bool MatchesEmpty()
            {
                return this._BDP;
            }

            // Token: 0x060008AE RID: 2222 RVA: 0x000FAD18 File Offset: 0x000F8F18
            public bool Matches(_bh2._AGI tokenSet)
            {
                bool flag = tokenSet == null;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    bool flag3 = tokenSet._BDO >= 0;
                    if (!flag3)
                    {
                        throw new Exception("matches() botched");
                    }
                    flag2 = ((this._BDN != null) ? this._BDN[tokenSet._BDO] : (this._BDO == tokenSet._BDO));
                }
                return flag2;
            }

            // Token: 0x060008AF RID: 2223 RVA: 0x000FAD7C File Offset: 0x000F8F7C
            public bool Matches(SyntaxToken token)
            {
                return (this._BDN != null) ? this._BDN[token.tokenId] : (token.tokenId == this._BDO);
            }

            // Token: 0x060008B0 RID: 2224 RVA: 0x000FADB8 File Offset: 0x000F8FB8
            public bool Matches(int token)
            {
                bool flag = this._BDN == null;
                bool flag2;
                if (flag)
                {
                    flag2 = token == this._BDO;
                }
                else
                {
                    bool flag3 = token >= this._BDN.Count;
                    if (flag3)
                    {
                        Debug.LogError("Unknown token " + token.ToString());
                    }
                    flag2 = this._BDN[token];
                }
                return flag2;
            }

            // Token: 0x060008B1 RID: 2225 RVA: 0x000FAE1C File Offset: 0x000F901C
            public bool Accepts(_bh2._AGI s)
            {
                bool flag = s._BDN != null;
                if (flag)
                {
                    bool flag2 = this._BDN != null;
                    if (flag2)
                    {
                        BitArray bitArray = new BitArray(this._BDN);
                        bitArray = bitArray.And(s._BDN);
                        for (int i = 0; i < bitArray.Count; i++)
                        {
                            bool flag3 = bitArray[i];
                            if (flag3)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        bool flag4 = this._BDO >= 0;
                        if (flag4)
                        {
                            return s._BDN[this._BDO];
                        }
                    }
                }
                else
                {
                    bool flag5 = s._BDO >= 0;
                    if (flag5)
                    {
                        bool flag6 = this._BDN != null;
                        if (flag6)
                        {
                            return this._BDN[s._BDO];
                        }
                        bool flag7 = this._BDO >= 0;
                        if (flag7)
                        {
                            return this._BDO == s._BDO;
                        }
                    }
                }
                return false;
            }

            // Token: 0x060008B2 RID: 2226 RVA: 0x000FAF20 File Offset: 0x000F9120
            public _bh2._AGI Intersecton(_bh2._AGI s)
            {
                bool flag = s._BDN != null;
                if (flag)
                {
                    bool flag2 = this._BDN != null;
                    if (flag2)
                    {
                        BitArray bitArray = new BitArray(this._BDN);
                        bitArray = bitArray.And(s._BDN);
                        _bh2._AGI _BEC = new _bh2._AGI();
                        for (int i = 0; i < bitArray.Length; i++)
                        {
                            bool flag3 = bitArray[i];
                            if (flag3)
                            {
                                _BEC.Add(new _bh2._AGI(i));
                            }
                        }
                        return _BEC;
                    }
                    bool flag4 = this._BDO >= 0 && s._BDN[this._BDO];
                    if (flag4)
                    {
                        return this;
                    }
                }
                else
                {
                    bool flag5 = s._BDO >= 0;
                    if (flag5)
                    {
                        bool flag6 = this._BDN != null && this._BDN[s._BDO];
                        if (flag6)
                        {
                            return s;
                        }
                        bool flag7 = this._BDO >= 0 && this._BDO == s._BDO;
                        if (flag7)
                        {
                            return this;
                        }
                    }
                }
                return new _bh2._AGI();
            }

            // Token: 0x060008B3 RID: 2227 RVA: 0x000FB044 File Offset: 0x000F9244
            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
                string text = "";
                bool _BDQ = this._BDP;
                if (_BDQ)
                {
                    stringBuilder.Append("empty");
                    text = ", ";
                }
                bool flag = this._BDN != null;
                if (flag)
                {
                    StringBuilder stringBuilder2 = stringBuilder;
                    string text2 = text;
                    string text3 = "set ";
                    BitArray _BDR = this._BDN;
                    stringBuilder2.Append(text2 + text3 + ((_BDR != null) ? _BDR.ToString() : null));
                }
                else
                {
                    bool flag2 = this._BDO >= 0;
                    if (flag2)
                    {
                        stringBuilder.Append(text + "token " + this._BDO.ToString());
                    }
                }
                string text4 = "{";
                StringBuilder stringBuilder3 = stringBuilder;
                return text4 + ((stringBuilder3 != null) ? stringBuilder3.ToString() : null) + "}";
            }

            // Token: 0x060008B4 RID: 2228 RVA: 0x000FB100 File Offset: 0x000F9300
            public string ToString(_bh2._BCX parser)
            {
                bool flag = this._BDS != null;
                string text;
                if (flag)
                {
                    text = this._BDS;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    string text2 = string.Empty;
                    bool _BDQ = this._BDP;
                    if (_BDQ)
                    {
                        stringBuilder.Append("[empty]");
                        text2 = ", ";
                    }
                    bool flag2 = this._BDN != null;
                    if (flag2)
                    {
                        for (int i = 0; i < this._BDN.Count; i++)
                        {
                            bool flag3 = this._BDN.Get(i);
                            if (flag3)
                            {
                                stringBuilder.Append(text2 + parser.GetToken(i));
                                text2 = ((i == this._BDN.Count - 2) ? ", or " : ", ");
                            }
                        }
                    }
                    else
                    {
                        bool flag4 = this._BDO >= 0;
                        if (flag4)
                        {
                            stringBuilder.Append(text2 + parser.GetToken(this._BDO));
                        }
                    }
                    text = (this._BDS = stringBuilder.ToString());
                }
                return text;
            }

            // Token: 0x04000710 RID: 1808
            protected bool _BDP;

            // Token: 0x04000711 RID: 1809
            private BitArray _BDN;

            // Token: 0x04000712 RID: 1810
            private int _BDO = -1;

            // Token: 0x04000713 RID: 1811
            private string _BDS;
        }
    }
}
