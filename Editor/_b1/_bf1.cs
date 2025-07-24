using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000C3 RID: 195
    internal abstract class _bf1 : _bh4
    {
        // Token: 0x06000562 RID: 1378
        internal abstract _b2 ReturnType();

        // Token: 0x06000563 RID: 1379 RVA: 0x000D34B0 File Offset: 0x000D16B0
        public _bh4 AddTypeParameter(FKI symbol)
        {
            string text = symbol.Name;
            bool flag = this._AHL == null;
            if (flag)
            {
                this._AHL = new List<_bd7>();
            }
            _bd7 _AHM = this._AHL.FirstByName(text);
            bool flag2 = _AHM == null;
            if (flag2)
            {
                _AHM = (_bd7)_bh4.Create(symbol);
                _AHM._AO = this;
                this._AHL.Add(_AHM);
            }
            symbol._ACV = _AHM;
            _bb4._AIN _AIO = symbol.NameNode();
            bool flag3 = _AIO != null;
            if (flag3)
            {
                _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                bool flag4 = _AEM != null;
                if (flag4)
                {
                    _AEM.SetDeclaredSymbol(_AHM);
                }
                else
                {
                    _bb4.DHBA _AEM2 = ((_bb4._ACW)_AIO).GetLastLeaf();
                    bool flag5 = _AEM2 != null;
                    if (flag5)
                    {
                        bool flag6 = _AEM2.OOME._AHB() == "typeParameterList";
                        if (flag6)
                        {
                            _AEM2 = _AEM2.OOME.OOME.LeafAt(0);
                        }
                        _AEM2.SetDeclaredSymbol(_AHM);
                    }
                }
            }
            return _AHM;
        }

        // Token: 0x06000564 RID: 1380 RVA: 0x000D35AC File Offset: 0x000D17AC
        public bool CanCallWith(int numArguments, bool asExtensionMethod)
        {
            List<Modifiers> _AWU = _ba7._AGV;
            int num = _AWU.Count - numArguments;
            int num2 = (asExtensionMethod ? 1 : 0);
            int num3 = num2;
            List<_bm1> list = this._AIK ?? _bh4._AHV;
            for (int i = 0; i < list.Count; i++)
            {
                _bm1 _AGS = list[i];
                bool flag = i < numArguments;
                if (flag)
                {
                    bool flag2 = _AWU[num + i] == Modifiers.Out;
                    bool flag3 = _AWU[num + i] == Modifiers.Ref;
                    bool flag4 = _AWU[num + i] == Modifiers.In;
                    bool flag5 = _AGS._AGK() != flag2 || _AGS._AGL() != flag3 || (flag4 && !_AGS._AHS());
                    if (flag5)
                    {
                        return false;
                    }
                }
                bool flag6 = !asExtensionMethod || !_AGS._AWV();
                if (flag6)
                {
                    bool flag7 = _AGS._AHO();
                    if (flag7)
                    {
                        num3 = 100000;
                    }
                    else
                    {
                        bool flag8 = !_AGS._AWW();
                        if (flag8)
                        {
                            num2++;
                        }
                    }
                    num3++;
                }
            }
            bool flag9 = numArguments < num2 || numArguments > num3;
            if (flag9)
            {
                return false;
            }
            int num4 = 0;
            List<string> _AWX = _ba7._AGY;
            for (int j = (asExtensionMethod ? 1 : 0); j < numArguments; j++)
            {
                string text = _AWX[num + j];
                bool flag10 = text == null;
                if (!flag10)
                {
                    for (int k = j; k < numArguments; k++)
                    {
                        bool flag11 = false;
                        text = _AWX[num + k];
                        for (int l = j; l < list.Count; l++)
                        {
                            _bm1 _AGS2 = list[l];
                            bool flag12 = _AGS2._AW == text;
                            if (flag12)
                            {
                                bool flag13 = _AGS2._AWW();
                                if (flag13)
                                {
                                    num4++;
                                }
                                flag11 = true;
                                break;
                            }
                        }
                        bool flag14 = !flag11;
                        if (flag14)
                        {
                            return false;
                        }
                    }
                    break;
                }
            }
            bool flag15 = numArguments - num4 < num2;
            return !flag15;
        }

        // Token: 0x06000565 RID: 1381 RVA: 0x000D37E8 File Offset: 0x000D19E8
        internal override _bh4 TypeOf()
        {
            return this.ReturnType();
        }

        // Token: 0x06000566 RID: 1382 RVA: 0x000D3800 File Offset: 0x000D1A00
        internal override List<_bm1> GetParameters()
        {
            return this._AIK ?? _bh4._AHV;
        }

        // Token: 0x06000567 RID: 1383 RVA: 0x000D3824 File Offset: 0x000D1A24
        internal override List<_bd7> GetTypeParameters()
        {
            return this._AHL;
        }

        // Token: 0x06000568 RID: 1384 RVA: 0x000D383C File Offset: 0x000D1A3C
        public _bh4 AddParameter(FKI symbol)
        {
            string text = symbol.Name;
            _bm1 _AGS = (_bm1)_bh4.Create(symbol);
            _AGS.BLH = new KJK(symbol._AEJ.FindChildByName("type"));
            _AGS._AO = this;
            _bb4._ACW _AGZ = symbol._AEJ.NodeAt(-1);
            bool flag = _AGZ != null && _AGZ._AHB() == "defaultArgument";
            if (flag)
            {
                _bb4._ACW _AGZ2 = _AGZ.NodeAt(1);
                bool flag2 = _AGZ2 != null;
                if (flag2)
                {
                    _AGS._AWY = _AGZ2.Print();
                }
            }
            bool flag3 = !string.IsNullOrEmpty(text);
            if (flag3)
            {
                bool flag4 = this._AIK == null;
                if (flag4)
                {
                    this._AIK = new List<_bm1>();
                }
                this._AIK.Add(_AGS);
            }
            return _AGS;
        }

        // Token: 0x06000569 RID: 1385 RVA: 0x000D3908 File Offset: 0x000D1B08
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Parameter;
            _bh4 _AAH2;
            if (flag)
            {
                _bh4 _AAH = this.AddParameter(symbol);
                symbol._ACV = _AAH;
                _AAH2 = _AAH;
            }
            else
            {
                bool flag2 = symbol._AT == SymbolKind.TypeParameter;
                if (flag2)
                {
                    _bh4 _AAH3 = this.AddTypeParameter(symbol);
                    _AAH2 = _AAH3;
                }
                else
                {
                    _AAH2 = base.AddDeclaration(symbol);
                }
            }
            return _AAH2;
        }

        // Token: 0x0600056A RID: 1386 RVA: 0x000D3960 File Offset: 0x000D1B60
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Parameter && this._AIK != null;
            if (flag)
            {
                this._AIK.Remove((_bm1)symbol._ACV);
            }
            else
            {
                bool flag2 = symbol._AT == SymbolKind.TypeParameter && this._AHL != null;
                if (flag2)
                {
                    this._AHL.Remove((_bd7)symbol._ACV);
                }
                else
                {
                    base.RemoveDeclaration(symbol);
                }
            }
        }

        // Token: 0x0600056B RID: 1387 RVA: 0x000D39DC File Offset: 0x000D1BDC
        internal override _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            memberName = _bh4.DecodeId(memberName);
            bool flag = !asTypeOnly && numTypeParameters == 0 && this._AIK != null;
            if (flag)
            {
                _bm1 _AGS = this._AIK.FirstByName(memberName);
                bool flag2 = _AGS != null;
                if (flag2)
                {
                    return _AGS;
                }
            }
            else
            {
                bool flag3 = this._AHL != null;
                if (flag3)
                {
                    _bd7 _AHM = this._AHL.FirstByName(memberName);
                    bool flag4 = _AHM != null;
                    if (flag4)
                    {
                        return _AHM;
                    }
                }
            }
            return base.FindName(memberName, numTypeParameters, asTypeOnly);
        }

        // Token: 0x0600056C RID: 1388 RVA: 0x000D3A64 File Offset: 0x000D1C64
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            if (!asTypeOnly)
            {
                bool flag = numTypeArgs == 0;
                if (flag)
                {
                    string text = _bh4.DecodeId(leaf._ACX.text);
                    bool flag2 = this._AIK != null;
                    if (flag2)
                    {
                        int count = this._AIK.Count;
                        while (count-- > 0)
                        {
                            bool flag3 = this._AIK[count]._AW == text;
                            if (flag3)
                            {
                                leaf._ACY(this._AIK[count]);
                                return;
                            }
                        }
                    }
                    bool flag4 = this._AHL != null;
                    if (flag4)
                    {
                        int count2 = this._AHL.Count;
                        while (count2-- > 0)
                        {
                            bool flag5 = this._AHL[count2]._AW == text;
                            if (flag5)
                            {
                                leaf._ACY(this._AHL[count2]);
                                return;
                            }
                        }
                    }
                }
                base.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
            }
        }

        // Token: 0x0600056D RID: 1389 RVA: 0x000D3B78 File Offset: 0x000D1D78
        public _bh4 ResolveParameterName(_bb4.DHBA leaf)
        {
            string text = _bh4.DecodeId(leaf._ACX.text);
            List<_bm1> parameters = this.GetParameters();
            int count = parameters.Count;
            _bh4 _AAH;
            while (count-- > 0)
            {
                _bm1 _AGS = parameters[count];
                bool flag = _AGS._AW == text;
                if (flag)
                {
                    leaf._ACY(_AAH = _AGS);
                    return _AAH;
                }
            }
            leaf._ACY(_AAH = _bh4._AGT);
            return _AAH;
        }

        // Token: 0x04000509 RID: 1289
        protected KJK _AIJ;

        // Token: 0x0400050A RID: 1290
        public List<_bm1> _AIK;

        // Token: 0x0400050B RID: 1291
        public List<_bd7> _AHL;
    }
}
