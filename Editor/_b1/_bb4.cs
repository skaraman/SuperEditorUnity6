using System;
using System.Text;
using SuperEditor;

namespace AHO
{
    // Token: 0x02000127 RID: 295
    internal class _bb4
    {
        // Token: 0x060008BA RID: 2234 RVA: 0x000FB22C File Offset: 0x000F942C
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            this._AIT.Dump(stringBuilder, 0);
            return stringBuilder.ToString();
        }

        // Token: 0x04000714 RID: 1812
        public static uint _AIU = 2U;

        // Token: 0x04000715 RID: 1813
        public _bb4._ACW _AIT;

        // Token: 0x02000128 RID: 296
        public abstract class _AIN
        {
            // Token: 0x060008BD RID: 2237 RVA: 0x000FB260 File Offset: 0x000F9460
            public _bh4 _AAB()
            {
                bool flag = this._AIV != null && this._AIW != 0U && (this._AIW != _bb4._AIU || !this._AIV.IsValid());
                if (flag)
                {
                    this._AIV = null;
                }
                return this._AIV;
            }

            // Token: 0x060008BE RID: 2238 RVA: 0x000FB2B4 File Offset: 0x000F94B4
            public void _ACY(_bh4 value)
            {
                bool flag = this._AIW == 0U;
                if (!flag)
                {
                    this._AIW = _bb4._AIU;
                    this._AIV = value;
                }
            }

            // Token: 0x060008BF RID: 2239 RVA: 0x000FB2E4 File Offset: 0x000F94E4
            public _bh4 GetDeclaredSymbol()
            {
                bool flag = this._AIW > 0U;
                _bh4 _AAH;
                if (flag)
                {
                    _AAH = null;
                }
                else
                {
                    _AAH = this._AIV;
                }
                return _AAH;
            }

            // Token: 0x060008C0 RID: 2240 RVA: 0x000FB30D File Offset: 0x000F950D
            public void SetDeclaredSymbol(_bh4 symbol)
            {
                this._AIV = symbol;
                this._AIW = 0U;
            }

            // Token: 0x060008C1 RID: 2241 RVA: 0x000FB320 File Offset: 0x000F9520
            public _bb4.DHBA FindPreviousLeaf()
            {
                _bb4._AIN _AIO = this;
                while (_AIO._AIL == 0 && _AIO.OOME != null)
                {
                    _AIO = _AIO.OOME;
                }
                bool flag = _AIO.OOME == null;
                _bb4.DHBA _AEM;
                if (flag)
                {
                    _AEM = null;
                }
                else
                {
                    _AIO = _AIO.OOME.ChildAt((int)(_AIO._AIL - 1));
                    _bb4._ACW _AGZ;
                    while ((_AGZ = _AIO as _bb4._ACW) != null)
                    {
                        bool flag2 = _AGZ._AIX == 0;
                        if (flag2)
                        {
                            return _AGZ.FindPreviousLeaf();
                        }
                        _AIO = _AGZ._AIY();
                    }
                    _AEM = _AIO as _bb4.DHBA;
                }
                return _AEM;
            }

            // Token: 0x060008C2 RID: 2242 RVA: 0x000FB3B8 File Offset: 0x000F95B8
            public _bb4.DHBA FindNextLeaf()
            {
                _bb4._AIN _AIO = this;
                while (_AIO.OOME != null && _AIO._AIL == _AIO.OOME._AIX - 1)
                {
                    _AIO = _AIO.OOME;
                }
                bool flag = _AIO.OOME == null;
                _bb4.DHBA _AEM;
                if (flag)
                {
                    _AEM = null;
                }
                else
                {
                    _AIO = _AIO._AIZ;
                    _bb4._ACW _AGZ;
                    while ((_AGZ = _AIO as _bb4._ACW) != null)
                    {
                        bool flag2 = _AGZ._AIX == 0;
                        if (flag2)
                        {
                            return _AGZ.FindNextLeaf();
                        }
                        _AIO = _AGZ.ChildAt(0);
                    }
                    _AEM = _AIO as _bb4.DHBA;
                }
                return _AEM;
            }

            // Token: 0x060008C3 RID: 2243 RVA: 0x000FB450 File Offset: 0x000F9650
            public _bb4._AIN FindPreviousNode()
            {
                _bb4._AIN _AIO = this;
                while (_AIO._AIL == 0 && _AIO.OOME != null)
                {
                    _AIO = _AIO.OOME;
                }
                bool flag = _AIO.OOME == null;
                _bb4._AIN _AIO2;
                if (flag)
                {
                    _AIO2 = null;
                }
                else
                {
                    _AIO = _AIO.OOME.ChildAt((int)(_AIO._AIL - 1));
                    _AIO2 = _AIO;
                }
                return _AIO2;
            }

            // Token: 0x060008C4 RID: 2244
            public abstract void Dump(StringBuilder sb, int indent);

            // Token: 0x060008C5 RID: 2245 RVA: 0x000FB4AC File Offset: 0x000F96AC
            public bool IsAncestorOf(_bb4._AIN node)
            {
                while (node != null)
                {
                    bool flag = node.OOME == this;
                    if (flag)
                    {
                        return true;
                    }
                    node = node.OOME;
                }
                return false;
            }

            // Token: 0x060008C6 RID: 2246 RVA: 0x000FB4E4 File Offset: 0x000F96E4
            public _bb4._ACW FindParentByName(string ruleName)
            {
                _bb4._ACW _AGZ = this.OOME;
                while (_AGZ != null && _AGZ._AHB() != ruleName)
                {
                    _AGZ = _AGZ.OOME;
                }
                return _AGZ;
            }

            // Token: 0x060008C7 RID: 2247 RVA: 0x000FB520 File Offset: 0x000F9720
            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
                this.Dump(stringBuilder, 1);
                return stringBuilder.ToString();
            }

            // Token: 0x060008C8 RID: 2248
            public abstract string Print();

            // Token: 0x060008C9 RID: 2249 RVA: 0x000FB548 File Offset: 0x000F9748
            public bool HasLeafs()
            {
                _bb4._AIN _AIO = this;
                for (; ; )
                {
                    _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                    bool flag = _AGZ == null;
                    if (flag)
                    {
                        break;
                    }
                    _AIO = _AGZ._AJA();
                    while (_AIO != null && _AIO._AIL < _AGZ._AIX)
                    {
                        _AGZ = _AIO as _bb4._ACW;
                        bool flag2 = _AGZ == null;
                        if (flag2)
                        {
                            goto Block_2;
                        }
                        _AIO = _AGZ._AJA();
                    }
                    bool flag3 = _AGZ == this;
                    if (flag3)
                    {
                        goto Block_5;
                    }
                    _AIO = _AGZ._AIZ;
                    while (_AIO == null || _AIO._AIL >= _AIO.OOME._AIX)
                    {
                        _AGZ = _AGZ.OOME;
                        bool flag4 = _AGZ == this;
                        if (flag4)
                        {
                            goto Block_6;
                        }
                        _AIO = _AGZ._AIZ;
                    }
                }
                return true;
            Block_2:
                return true;
            Block_5:
                return false;
            Block_6:
                return false;
            }

            // Token: 0x060008CA RID: 2250 RVA: 0x000FB614 File Offset: 0x000F9814
            public bool HasLeafs(bool validNodesOnly)
            {
                bool flag;
                if (validNodesOnly)
                {
                    flag = this.HasLeafs();
                }
                else
                {
                    _bb4._AIN _AIO = this;
                    for (; ; )
                    {
                        _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                        bool flag2 = _AGZ == null;
                        if (flag2)
                        {
                            break;
                        }
                        for (_AIO = _AGZ._AJA(); _AIO != null; _AIO = _AGZ._AJA())
                        {
                            _AGZ = _AIO as _bb4._ACW;
                            bool flag3 = _AGZ == null;
                            if (flag3)
                            {
                                goto Block_3;
                            }
                        }
                        bool flag4 = _AGZ == this;
                        if (flag4)
                        {
                            goto Block_5;
                        }
                        for (_AIO = _AGZ._AIZ; _AIO == null; _AIO = _AGZ._AIZ)
                        {
                            _AGZ = _AGZ.OOME;
                            bool flag5 = _AGZ == this;
                            if (flag5)
                            {
                                goto Block_6;
                            }
                        }
                    }
                    return true;
                Block_3:
                    return true;
                Block_5:
                    return false;
                Block_6:
                    flag = false;
                }
                return flag;
            }

            // Token: 0x060008CB RID: 2251 RVA: 0x000FB6C8 File Offset: 0x000F98C8
            public bool HasErrors()
            {
                _bb4._AIN _AIO = this;
                for (; ; )
                {
                    _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                    bool flag = _AGZ == null;
                    if (flag)
                    {
                        bool flag2 = _AIO._AJB != null;
                        if (flag2)
                        {
                            break;
                        }
                        bool flag3 = _AIO == this;
                        if (flag3)
                        {
                            goto Block_3;
                        }
                        _bb4._AIN _AIO2 = _AIO._AIZ;
                        while (_AIO2 == null || _AIO2._AIL >= _AIO2.OOME._AIX)
                        {
                            _AIO = _AIO.OOME;
                            bool flag4 = _AIO == this;
                            if (flag4)
                            {
                                goto Block_4;
                            }
                            _AIO2 = _AIO._AIZ;
                        }
                        _AIO = _AIO2;
                    }
                    else
                    {
                        _AIO = _AGZ._AJA();
                        while (_AIO != null && _AIO._AIL < _AGZ._AIX)
                        {
                            _bb4._ACW _AGZ2 = _AIO as _bb4._ACW;
                            bool flag5 = _AGZ2 == null;
                            if (flag5)
                            {
                                bool flag6 = _AIO._AJB != null;
                                if (flag6)
                                {
                                    goto Block_8;
                                }
                                _AIO = _AIO._AIZ;
                            }
                            else
                            {
                                _AGZ = _AGZ2;
                                _AIO = _AGZ._AJA();
                            }
                        }
                        bool flag7 = _AGZ == this;
                        if (flag7)
                        {
                            goto Block_11;
                        }
                        _AIO = _AGZ._AIZ;
                        while (_AIO == null || _AIO._AIL >= _AIO.OOME._AIX)
                        {
                            _AGZ = _AGZ.OOME;
                            bool flag8 = _AGZ == this;
                            if (flag8)
                            {
                                goto Block_12;
                            }
                            _AIO = _AGZ._AIZ;
                        }
                    }
                }
                return true;
            Block_3:
                return false;
            Block_4:
                return false;
            Block_8:
                return true;
            Block_11:
                return false;
            Block_12:
                return false;
            }

            // Token: 0x060008CC RID: 2252
            public abstract bool IsLit(string litText);

            // Token: 0x060008CD RID: 2253 RVA: 0x000FB830 File Offset: 0x000F9A30
            public _bb4.DHBA GetFirstLeaf()
            {
                return this.GetFirstLeaf(true);
            }

            // Token: 0x060008CE RID: 2254
            public abstract _bb4.DHBA GetFirstLeaf(bool validNodesOnly);

            // Token: 0x060008CF RID: 2255 RVA: 0x000FB84C File Offset: 0x000F9A4C
            public _bb4.DHBA GetLastLeafInParent()
            {
                bool flag = this.OOME != null;
                if (flag)
                {
                    bool flag2 = this._AIL >= this.OOME._AIX;
                    if (flag2)
                    {
                        return null;
                    }
                    bool flag3 = this._AIZ != null && this._AIZ._AIL < this.OOME._AIX;
                    if (flag3)
                    {
                        _bb4.DHBA lastLeafInParent = this._AIZ.GetLastLeafInParent();
                        bool flag4 = lastLeafInParent != null;
                        if (flag4)
                        {
                            return lastLeafInParent;
                        }
                    }
                }
                _bb4.DHBA _AEM = this as _bb4.DHBA;
                bool flag5 = _AEM != null && _AEM._ACX != null;
                _bb4.DHBA _AEM2;
                if (flag5)
                {
                    _AEM2 = _AEM;
                }
                else
                {
                    _bb4._ACW _AGZ = this as _bb4._ACW;
                    bool flag6 = _AGZ._AJA() != null;
                    if (flag6)
                    {
                        _AEM2 = _AGZ._AJA().GetLastLeafInParent();
                    }
                    else
                    {
                        _AEM2 = null;
                    }
                }
                return _AEM2;
            }

            // Token: 0x04000716 RID: 1814
            public _bb4._ACW OOME;

            // Token: 0x04000717 RID: 1815
            public _bb4._AIN _AIZ;

            // Token: 0x04000718 RID: 1816
            public short _AIL;

            // Token: 0x04000719 RID: 1817
            public bool _AJC;

            // Token: 0x0400071A RID: 1818
            public _bh2._ACW _AJD;

            // Token: 0x0400071B RID: 1819
            public _bh2._AJE _AJB;

            // Token: 0x0400071C RID: 1820
            public string _AJF;

            // Token: 0x0400071D RID: 1821
            private uint _AIW = 1U;

            // Token: 0x0400071E RID: 1822
            private _bh4 _AIV;
        }

        // Token: 0x02000129 RID: 297
        public class DHBA : _bb4._AIN
        {
            // Token: 0x17000060 RID: 96
            // (get) Token: 0x060008D1 RID: 2257 RVA: 0x000FB934 File Offset: 0x000F9B34
            public int line
            {
                get
                {
                    return (this._ACX != null) ? this._ACX.Line : 0;
                }
            }

            // Token: 0x060008D2 RID: 2258 RVA: 0x000FB95C File Offset: 0x000F9B5C
            public int _AJG()
            {
                return (this._ACX != null && this._ACX.AIGN != null) ? this._ACX.AIGN.EOIA.IndexOf(this._ACX) : 0;
            }

            // Token: 0x060008D3 RID: 2259 RVA: 0x000FB9A1 File Offset: 0x000F9BA1
            public DHBA()
            {
            }

            // Token: 0x060008D4 RID: 2260 RVA: 0x000FB9AB File Offset: 0x000F9BAB
            public DHBA(_bh2._AJH scanner)
            {
                this._ACX = scanner.Current;
                this._ACX.OOME = this;
            }

            // Token: 0x060008D5 RID: 2261 RVA: 0x000FB9D0 File Offset: 0x000F9BD0
            public bool TryReuse(_bh2._AJH scanner)
            {
                bool flag = this._ACX == null;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    SyntaxToken syntaxToken = scanner.Current;
                    bool flag3 = syntaxToken.OOME == this;
                    if (flag3)
                    {
                        this._ACX.OOME = this;
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
                return flag2;
            }

            // Token: 0x060008D6 RID: 2262 RVA: 0x000FBA1C File Offset: 0x000F9C1C
            public override void Dump(StringBuilder sb, int indent)
            {
                sb.Append(' ', 2 * indent);
                sb.Append(this._AIL);
                sb.Append(" ");
                bool flag = this._AJB != null;
                if (flag)
                {
                    sb.Append("? ");
                }
                sb.Append(this._ACX);
                sb.Append(' ');
                sb.Append(this.line + 1);
                sb.Append(':');
                sb.Append(this._AJG());
                bool flag2 = this._AJB != null;
                if (flag2)
                {
                    sb.Append(' ').Append(this._AJB);
                }
                sb.AppendLine();
            }

            // Token: 0x060008D7 RID: 2263 RVA: 0x000FBACC File Offset: 0x000F9CCC
            public void ReparseToken()
            {
                bool flag = this._ACX != null;
                if (flag)
                {
                    this._ACX.OOME = null;
                    this._ACX = null;
                }
                bool flag2 = this.OOME != null;
                if (flag2)
                {
                    this.OOME.RemoveNodeAt((int)this._AIL);
                }
            }

            // Token: 0x060008D8 RID: 2264 RVA: 0x000FBB1C File Offset: 0x000F9D1C
            public override string Print()
            {
                _bh2._AJI _AJJ = this._AJD as _bh2._AJI;
                bool flag = _AJJ != null;
                string text;
                if (flag)
                {
                    text = _AJJ._AJK;
                }
                else
                {
                    text = ((this._ACX != null) ? this._ACX.text : "");
                }
                return text;
            }

            // Token: 0x060008D9 RID: 2265 RVA: 0x000FBB68 File Offset: 0x000F9D68
            public override bool IsLit(string litText)
            {
                _bh2._AJI _AJJ = this._AJD as _bh2._AJI;
                return _AJJ != null && _AJJ._AJL == litText;
            }

            // Token: 0x060008DA RID: 2266 RVA: 0x000FBB98 File Offset: 0x000F9D98
            public override _bb4.DHBA GetFirstLeaf(bool validNodesOnly)
            {
                return this;
            }

            // Token: 0x0400071F RID: 1823
            public SyntaxToken _ACX;
        }

        // Token: 0x0200012A RID: 298
        public class _ACW : _bb4._AIN
        {
            // Token: 0x060008DB RID: 2267 RVA: 0x000FBBAC File Offset: 0x000F9DAC
            public _bb4._AIN _AJA()
            {
                return this._AJM;
            }

            // Token: 0x060008DC RID: 2268 RVA: 0x000FBBC4 File Offset: 0x000F9DC4
            public _bb4._AIN _AIY()
            {
                return this._AJN;
            }

            // Token: 0x060008DD RID: 2269 RVA: 0x000FBBDC File Offset: 0x000F9DDC
            public _bc1 _AJO()
            {
                _bh2._ACW _AGZ = ((_bh2._AEN)this._AJD)._AJP();
                return (_AGZ != null) ? ((_bh2._AJQ)_AGZ)._AJR : _bc1.None;
            }

            // Token: 0x060008DE RID: 2270 RVA: 0x000FBC10 File Offset: 0x000F9E10
            public _ACW(_bh2._AEN rule)
            {
                this._AJD = rule;
            }

            // Token: 0x060008DF RID: 2271 RVA: 0x000FBC24 File Offset: 0x000F9E24
            public _bb4._AIN ChildAt(int index)
            {
                bool flag = index < 0;
                if (flag)
                {
                    index += (int)this._AIX;
                }
                bool flag2 = index < 0 || index >= (int)this._AIX;
                _bb4._AIN _AIO;
                if (flag2)
                {
                    _AIO = null;
                }
                else
                {
                    _bb4._AIN _AIO2 = this._AJM;
                    while (_AIO2 != null && index-- > 0)
                    {
                        _AIO2 = _AIO2._AIZ;
                    }
                    _AIO = _AIO2;
                }
                return _AIO;
            }

            // Token: 0x060008E0 RID: 2272 RVA: 0x000FBC8C File Offset: 0x000F9E8C
            public _bb4.DHBA LeafAt(int index)
            {
                bool flag = index < 0;
                if (flag)
                {
                    index += (int)this._AIX;
                }
                bool flag2 = index < 0 || index >= (int)this._AIX;
                _bb4.DHBA _AEM;
                if (flag2)
                {
                    _AEM = null;
                }
                else
                {
                    _bb4._AIN _AIO = this._AJM;
                    while (_AIO != null && index-- > 0)
                    {
                        _AIO = _AIO._AIZ;
                    }
                    _AEM = _AIO as _bb4.DHBA;
                }
                return _AEM;
            }

            // Token: 0x060008E1 RID: 2273 RVA: 0x000FBCF8 File Offset: 0x000F9EF8
            public _bb4._ACW NodeAt(int index)
            {
                bool flag = index < 0;
                if (flag)
                {
                    index += (int)this._AIX;
                }
                bool flag2 = index < 0 || index >= (int)this._AIX;
                _bb4._ACW _AGZ;
                if (flag2)
                {
                    _AGZ = null;
                }
                else
                {
                    _bb4._AIN _AIO = this._AJM;
                    while (_AIO != null && index-- > 0)
                    {
                        _AIO = _AIO._AIZ;
                    }
                    _AGZ = _AIO as _bb4._ACW;
                }
                return _AGZ;
            }

            // Token: 0x060008E2 RID: 2274 RVA: 0x000FBD64 File Offset: 0x000F9F64
            public string _AHB()
            {
                return ((_bh2._AEN)this._AJD).GetName();
            }

            // Token: 0x060008E3 RID: 2275 RVA: 0x000FBD88 File Offset: 0x000F9F88
            public _bb4.DHBA AddToken(_bh2._AJH scanner)
            {
                _bb4._AIN _AIO = ((this._AJN != null) ? this._AJN._AIZ : this._AJM);
                _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                bool flag = _AEM != null && _AEM.TryReuse(scanner);
                _bb4.DHBA _AEM2;
                if (flag)
                {
                    this._AIX += 1;
                    this._AJN = _AEM;
                    _AEM2 = _AEM;
                }
                else
                {
                    _bb4.DHBA _AEM3 = new _bb4.DHBA(scanner)
                    {
                        OOME = this,
                        _AIL = this._AIX
                    };
                    bool flag2 = this._AJN != null;
                    if (flag2)
                    {
                        _AEM3._AIZ = this._AJN._AIZ;
                        this._AJN._AIZ = _AEM3;
                        this._AIX += 1;
                    }
                    else
                    {
                        _AEM3._AIZ = this._AJM;
                        this._AJM = _AEM3;
                        this._AIX += 1;
                    }
                    this._AJN = _AEM3;
                    for (_bb4._AIN _AIO2 = _AEM3._AIZ; _AIO2 != null; _AIO2 = _AIO2._AIZ)
                    {
                        _bb4._AIN _AIO3 = _AIO2;
                        _AIO3._AIL += 1;
                    }
                    _AEM2 = _AEM3;
                }
                return _AEM2;
            }

            // Token: 0x060008E4 RID: 2276 RVA: 0x000FBEA4 File Offset: 0x000FA0A4
            public _bb4.DHBA AddToken(SyntaxToken token)
            {
                _bb4._AIN _AIO = ((this._AJN != null) ? this._AJN._AIZ : this._AJM);
                bool flag = !token.IsMissing();
                if (flag)
                {
                    _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                    bool flag2 = _AEM != null && _AEM._ACX.text == token.text && _AEM._ACX.tokenKind == token.tokenKind;
                    if (flag2)
                    {
                        _AEM._AJC = false;
                        _AEM._AJB = null;
                        _AEM._ACX = token;
                        _AEM.OOME = this;
                        _AEM._AIL = this._AIX;
                        this._AIX += 1;
                        this._AJN = _AEM;
                        return _AEM;
                    }
                }
                _bb4.DHBA _AEM2 = new _bb4.DHBA
                {
                    _ACX = token,
                    OOME = this,
                    _AIL = this._AIX
                };
                bool flag3 = this._AJN != null;
                if (flag3)
                {
                    _AEM2._AIZ = this._AJN._AIZ;
                    this._AJN._AIZ = _AEM2;
                    this._AIX += 1;
                }
                else
                {
                    _AEM2._AIZ = this._AJM;
                    this._AJM = _AEM2;
                    this._AIX += 1;
                }
                this._AJN = _AEM2;
                for (_bb4._AIN _AIO2 = _AEM2._AIZ; _AIO2 != null; _AIO2 = _AIO2._AIZ)
                {
                    _bb4._AIN _AIO3 = _AIO2;
                    _AIO3._AIL += 1;
                }
                return _AEM2;
            }

            // Token: 0x060008E5 RID: 2277 RVA: 0x000FC02C File Offset: 0x000FA22C
            public int InvalidateFrom(int index)
            {
                int num = ((index >= (int)this._AIX) ? 0 : ((int)this._AIX - index));
                bool flag = num == 0;
                int num2;
                if (flag)
                {
                    num2 = 0;
                }
                else
                {
                    this._AIX -= (short)num;
                    bool flag2 = this._AIX == 0;
                    if (flag2)
                    {
                        this._AJN = null;
                    }
                    else
                    {
                        this._AJN = this.ChildAt((int)(this._AIX - 1));
                    }
                    num2 = num;
                }
                return num2;
            }

            // Token: 0x060008E6 RID: 2278 RVA: 0x000FC09C File Offset: 0x000FA29C
            public void RemoveNodeAt(int index)
            {
                bool flag = index == 0;
                if (flag)
                {
                    bool flag2 = this._AJM == null;
                    if (flag2)
                    {
                        return;
                    }
                    this._AJM.OOME = null;
                    bool flag3 = index < (int)this._AIX;
                    if (flag3)
                    {
                        this._AIX -= 1;
                        bool flag4 = this._AIX == 0;
                        if (flag4)
                        {
                            this._AJN = null;
                        }
                    }
                    _bb4._ACW _AGZ = this._AJM as _bb4._ACW;
                    this._AJM = this._AJM._AIZ;
                    bool flag5 = _AGZ != null;
                    if (flag5)
                    {
                        _AGZ.Dispose();
                    }
                    for (_bb4._AIN _AIO = this._AJM; _AIO != null; _AIO = _AIO._AIZ)
                    {
                        bool flag6 = _AIO._AIL == this._AIX;
                        if (flag6)
                        {
                            this._AJN = _AIO;
                        }
                        _bb4._AIN _AIO2 = _AIO;
                        _AIO2._AIL -= 1;
                    }
                }
                else
                {
                    _bb4._AIN _AIO3 = this._AJM;
                    int num = 1;
                    while (_AIO3 != null && num < index)
                    {
                        _AIO3 = _AIO3._AIZ;
                        num++;
                    }
                    bool flag7 = _AIO3 == null || _AIO3._AIZ == null;
                    if (flag7)
                    {
                        return;
                    }
                    _AIO3._AIZ.OOME = null;
                    bool flag8 = index < (int)this._AIX;
                    if (flag8)
                    {
                        this._AIX -= 1;
                        this._AJN = this.ChildAt((int)(this._AIX - 1));
                    }
                    _bb4._ACW _AGZ2 = _AIO3._AIZ as _bb4._ACW;
                    _AIO3._AIZ = _AIO3._AIZ._AIZ;
                    bool flag9 = _AGZ2 != null;
                    if (flag9)
                    {
                        _AGZ2.Dispose();
                    }
                    for (_bb4._AIN _AIO4 = _AIO3._AIZ; _AIO4 != null; _AIO4 = _AIO4._AIZ)
                    {
                        _bb4._AIN _AIO5 = _AIO4;
                        _AIO5._AIL -= 1;
                    }
                }
                bool flag10 = this.OOME != null && !base.HasLeafs(false);
                if (flag10)
                {
                    this.OOME.RemoveNodeAt((int)this._AIL);
                }
            }

            // Token: 0x060008E7 RID: 2279 RVA: 0x000FC2A8 File Offset: 0x000FA4A8
            public _bb4._ACW AddNode(_bh2._AEN rule, _bh2._AJH scanner, out bool skipParsing)
            {
                skipParsing = false;
                bool flag = false;
                _bb4._AIN _AIO = ((this._AJN != null) ? this._AJN._AIZ : this._AJM);
                _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                bool flag2 = _AGZ != null;
                if (flag2)
                {
                    _bb4.DHBA firstLeaf = _AGZ.GetFirstLeaf(false);
                    bool flag3 = _AGZ._AJD != rule;
                    if (flag3)
                    {
                        bool flag4 = firstLeaf == null || firstLeaf._ACX == null || firstLeaf.line <= scanner.CurrentLine() - 1;
                        if (flag4)
                        {
                            _AGZ.Dispose();
                            flag = true;
                        }
                    }
                    else
                    {
                        bool flag5 = firstLeaf != null && firstLeaf._ACX != null && firstLeaf.line > scanner.CurrentLine() - 1;
                        if (!flag5)
                        {
                            bool flag6 = firstLeaf == null || (firstLeaf._ACX != null && firstLeaf._AJB != null);
                            if (flag6)
                            {
                                _AGZ.Dispose();
                                flag = true;
                            }
                            else
                            {
                                bool flag7 = firstLeaf._ACX == scanner.Current;
                                if (flag7)
                                {
                                    _bb4.DHBA lastLeaf = _AGZ.GetLastLeaf();
                                    bool flag8 = lastLeaf != null && !_AGZ.HasErrors();
                                    if (flag8)
                                    {
                                        bool flag9 = lastLeaf._ACX != null;
                                        if (flag9)
                                        {
                                            ((_bm2._AJS)scanner).MoveAfterLeaf(lastLeaf);
                                            skipParsing = true;
                                            this._AIX += 1;
                                            this._AJN = _AGZ;
                                            return scanner._AJT;
                                        }
                                    }
                                    else
                                    {
                                        _AGZ.Dispose();
                                        flag = true;
                                    }
                                }
                                else
                                {
                                    bool flag10 = _AGZ._AIX == 0;
                                    if (flag10)
                                    {
                                        this._AIX += 1;
                                        this._AJN = _AGZ;
                                        _AGZ._AJB = null;
                                        _AGZ._AJC = false;
                                        return _AGZ;
                                    }
                                    bool flag11 = scanner.Current != null && (firstLeaf._ACX == null || firstLeaf.line <= scanner.CurrentLine() - 1);
                                    if (flag11)
                                    {
                                        _AGZ.Dispose();
                                        bool flag12 = firstLeaf._ACX == null || firstLeaf.line == scanner.CurrentLine() - 1;
                                        if (!flag12)
                                        {
                                            bool flag13 = this._AJN != null;
                                            if (flag13)
                                            {
                                                this._AJN._AIZ = _AIO._AIZ;
                                            }
                                            else
                                            {
                                                this._AJM = _AIO._AIZ;
                                            }
                                            for (_bb4._AIN _AIO2 = _AIO._AIZ; _AIO2 != null; _AIO2 = _AIO2._AIZ)
                                            {
                                                _bb4._AIN _AIO3 = _AIO2;
                                                _AIO3._AIL -= 1;
                                            }
                                            return this.AddNode(rule, scanner, out skipParsing);
                                        }
                                        flag = true;
                                    }
                                }
                            }
                        }
                    }
                }
                _bb4._ACW _AGZ2 = new _bb4._ACW(rule)
                {
                    OOME = this,
                    _AIL = this._AIX
                };
                bool flag14 = _AIO == null;
                if (flag14)
                {
                    bool flag15 = this._AJN != null;
                    if (flag15)
                    {
                        this._AJN._AIZ = _AGZ2;
                    }
                    else
                    {
                        this._AJM = _AGZ2;
                    }
                    this._AIX += 1;
                    this._AJN = _AGZ2;
                }
                else
                {
                    bool flag16 = flag;
                    if (flag16)
                    {
                        bool flag17 = this._AJN != null;
                        if (flag17)
                        {
                            this._AJN._AIZ = _AGZ2;
                            _AGZ2._AIZ = _AIO._AIZ;
                        }
                        else
                        {
                            this._AJM = _AGZ2;
                            _AGZ2._AIZ = _AIO._AIZ;
                        }
                    }
                    else
                    {
                        bool flag18 = this._AJN != null;
                        if (flag18)
                        {
                            _AGZ2._AIZ = this._AJN._AIZ;
                            this._AJN._AIZ = _AGZ2;
                        }
                        else
                        {
                            _AGZ2._AIZ = this._AJM;
                            this._AJM = _AGZ2;
                        }
                    }
                    this._AIX += 1;
                    this._AJN = _AGZ2;
                }
                _bb4._AIN _AIO4 = _AGZ2._AIZ;
                bool flag19 = _AIO4 != null && _AIO4._AIL != this._AIX;
                if (flag19)
                {
                    short num = this._AIX;
                    while (_AIO4 != null)
                    {
                        _AIO4._AIL = num;
                        num += 1;
                        _AIO4 = _AIO4._AIZ;
                    }
                }
                return _AGZ2;
            }

            // Token: 0x060008E8 RID: 2280 RVA: 0x000FC6B8 File Offset: 0x000FA8B8
            public _bb4._AIN FindChildByName(string name)
            {
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null && _AIO._AIL < this._AIX)
                {
                    bool flag = _AIO._AJD != null && _AIO._AJD.ToString() == name;
                    if (flag)
                    {
                        return _AIO;
                    }
                    _AIO = _AIO._AIZ;
                }
                return null;
            }

            // Token: 0x060008E9 RID: 2281 RVA: 0x000FC71C File Offset: 0x000FA91C
            public _bb4._AIN FindChildByName(string name, string name1)
            {
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null && _AIO._AIL < this._AIX)
                {
                    bool flag = _AIO._AJD != null && _AIO._AJD.ToString() == name;
                    if (flag)
                    {
                        _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                        bool flag2 = _AGZ == null;
                        _bb4._AIN _AIO2;
                        if (flag2)
                        {
                            _AIO2 = null;
                        }
                        else
                        {
                            _AIO2 = _AGZ.FindChildByName(name1);
                        }
                        return _AIO2;
                    }
                    _AIO = _AIO._AIZ;
                }
                return null;
            }

            // Token: 0x060008EA RID: 2282 RVA: 0x000FC7A0 File Offset: 0x000FA9A0
            public _bb4._AIN FindChildByName(string name, string name1, string name2)
            {
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null && _AIO._AIL < this._AIX)
                {
                    bool flag = _AIO._AJD != null && _AIO._AJD.ToString() == name;
                    if (flag)
                    {
                        _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                        bool flag2 = _AGZ == null;
                        _bb4._AIN _AIO2;
                        if (flag2)
                        {
                            _AIO2 = null;
                        }
                        else
                        {
                            _AIO2 = _AGZ.FindChildByName(name1, name2);
                        }
                        return _AIO2;
                    }
                    _AIO = _AIO._AIZ;
                }
                return null;
            }

            // Token: 0x060008EB RID: 2283 RVA: 0x000FC824 File Offset: 0x000FAA24
            public _bb4._AIN FindChildByName(params string[] name)
            {
                _bb4._AIN _AIO = this;
                int i = 0;
                while (i < name.Length)
                {
                    string text = name[i];
                    _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                    bool flag = _AGZ == null;
                    _bb4._AIN _AIO2;
                    if (flag)
                    {
                        _AIO2 = null;
                    }
                    else
                    {
                        _AIO = null;
                        _bb4._AIN _AIO3 = _AGZ._AJM;
                        while (_AIO3 != null && _AIO3._AIL < _AGZ._AIX)
                        {
                            bool flag2 = _AIO3._AJD != null && _AIO3._AJD.ToString() == text;
                            if (flag2)
                            {
                                _AIO = _AIO3;
                                break;
                            }
                            _AIO3 = _AIO3._AIZ;
                        }
                        bool flag3 = _AIO == null;
                        if (!flag3)
                        {
                            i++;
                            continue;
                        }
                        _AIO2 = null;
                    }
                    return _AIO2;
                }
                return _AIO;
            }

            // Token: 0x060008EC RID: 2284 RVA: 0x000FC8E4 File Offset: 0x000FAAE4
            public override void Dump(StringBuilder sb, int indent)
            {
                sb.Append(' ', 2 * indent);
                sb.Append(this._AIL);
                sb.Append(' ');
                _bh2._AEN _AJU = this._AJD as _bh2._AEN;
                bool flag = _AJU != null && _AJU._AJV() != null;
                if (flag)
                {
                    bool flag2 = this._AJB != null;
                    if (flag2)
                    {
                        sb.Append("? ");
                    }
                    sb.AppendLine(_AJU._AJV().GetNt());
                    bool flag3 = this._AJB != null;
                    if (flag3)
                    {
                        sb.Append(' ').AppendLine(this._AJB.GetErrorMessage());
                    }
                }
                indent++;
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null && _AIO._AIL < this._AIX)
                {
                    _AIO.Dump(sb, indent);
                    _AIO = _AIO._AIZ;
                }
            }

            // Token: 0x060008ED RID: 2285 RVA: 0x000FC9C4 File Offset: 0x000FABC4
            public override string Print()
            {
                string text = string.Empty;
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null && _AIO._AIL < this._AIX)
                {
                    text += _AIO.Print();
                    _AIO = _AIO._AIZ;
                }
                return text;
            }

            // Token: 0x060008EE RID: 2286 RVA: 0x000FCA14 File Offset: 0x000FAC14
            public override bool IsLit(string litText)
            {
                return false;
            }

            // Token: 0x060008EF RID: 2287 RVA: 0x000FCA28 File Offset: 0x000FAC28
            public override _bb4.DHBA GetFirstLeaf(bool validNodesOnly)
            {
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null && (!validNodesOnly || _AIO._AIL < this._AIX))
                {
                    _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                    bool flag = _AEM != null;
                    _bb4.DHBA _AEM2;
                    if (flag)
                    {
                        _AEM2 = _AEM;
                    }
                    else
                    {
                        _AEM = ((_bb4._ACW)_AIO).GetFirstLeaf(validNodesOnly);
                        bool flag2 = _AEM != null;
                        if (!flag2)
                        {
                            _AIO = _AIO._AIZ;
                            continue;
                        }
                        _AEM2 = _AEM;
                    }
                    return _AEM2;
                }
                return null;
            }

            // Token: 0x060008F0 RID: 2288 RVA: 0x000FCA9C File Offset: 0x000FAC9C
            public _bb4.DHBA GetLastLeaf()
            {
                bool flag = this._AJM == null;
                _bb4.DHBA _AEM;
                if (flag)
                {
                    _AEM = null;
                }
                else
                {
                    _AEM = this._AJM.GetLastLeafInParent();
                }
                return _AEM;
            }

            // Token: 0x060008F1 RID: 2289 RVA: 0x000FCACC File Offset: 0x000FACCC
            public void Exclude()
            {
                bool flag = this.OOME == null || this._AIX != 1 || this._AJM == null || this._AJM._AIZ != null;
                if (!flag)
                {
                    bool flag2 = this._AIL == 0;
                    if (flag2)
                    {
                        this.OOME._AJM = this._AJM;
                    }
                    else
                    {
                        _bb4._AIN _AIO = this.OOME.ChildAt((int)(this._AIL - 1));
                        _AIO._AIZ = this._AJM;
                        this._AJM._AIL = this._AIL;
                    }
                    this._AJM.OOME = this.OOME;
                    this._AJM._AIZ = this._AIZ;
                    this.OOME = null;
                    this._AIZ = null;
                    this._AJM = null;
                }
            }

            // Token: 0x060008F2 RID: 2290 RVA: 0x000FCB9C File Offset: 0x000FAD9C
            public void CleanUp()
            {
                _bb4._AIN _AIO = this._AJM;
                bool flag = this._AIX == 0;
                if (flag)
                {
                    while (_AIO != null)
                    {
                        _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                        _AIO = _AIO._AIZ;
                        bool flag2 = _AGZ != null;
                        if (flag2)
                        {
                            _AGZ.Dispose();
                        }
                    }
                    this._AJM = null;
                    this._AJN = null;
                }
                else
                {
                    while (_AIO != null)
                    {
                        _bb4._ACW _AGZ2 = _AIO as _bb4._ACW;
                        bool flag3 = _AGZ2 != null;
                        if (flag3)
                        {
                            _AGZ2.CleanUp();
                        }
                        bool flag4 = _AIO._AIL >= this._AIX - 1;
                        if (flag4)
                        {
                            _bb4._AIN _AIO2 = _AIO;
                            _AIO = _AIO._AIZ;
                            _AIO2._AIZ = null;
                            while (_AIO != null)
                            {
                                _AGZ2 = _AIO as _bb4._ACW;
                                _AIO = _AIO._AIZ;
                                bool flag5 = _AGZ2 != null;
                                if (flag5)
                                {
                                    _AGZ2.Dispose();
                                }
                            }
                            break;
                        }
                        _AIO = _AIO._AIZ;
                    }
                }
            }

            // Token: 0x060008F3 RID: 2291 RVA: 0x000FCC94 File Offset: 0x000FAE94
            public void Dispose()
            {
                _bb4._AIN _AIO = this._AJM;
                while (_AIO != null)
                {
                    _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                    _AIO = _AIO._AIZ;
                    bool flag = _AGZ != null;
                    if (flag)
                    {
                        _AGZ.Dispose();
                    }
                }
                bool flag2 = this.EFI != null;
                if (flag2)
                {
                    bool flag3 = this.EFI._AJW != null;
                    if (flag3)
                    {
                        this.EFI._AJW.RemoveDeclaration(this.EFI);
                    }
                    _bb4._AIU += 1U;
                    bool flag4 = _bb4._AIU == 0U;
                    if (flag4)
                    {
                        _bb4._AIU += 1U;
                    }
                    this.EFI = null;
                }
            }

            // Token: 0x04000720 RID: 1824
            protected _bb4._AIN _AJM;

            // Token: 0x04000721 RID: 1825
            private _bb4._AIN _AJN;

            // Token: 0x04000722 RID: 1826
            public short _AIX;

            // Token: 0x04000723 RID: 1827
            public _bm6 _AJW;

            // Token: 0x04000724 RID: 1828
            public FKI EFI;
        }
    }
}
