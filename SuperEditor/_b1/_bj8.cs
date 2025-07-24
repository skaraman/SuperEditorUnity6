using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000DF RID: 223
    internal class _bj8 : _bn2
    {
        // Token: 0x06000682 RID: 1666 RVA: 0x000E59C1 File Offset: 0x000E3BC1
        public _bj8(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x06000683 RID: 1667 RVA: 0x000E5C60 File Offset: 0x000E3E60
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = this._ACV == null;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                symbol._AJW = this;
                SymbolKind _ABY = symbol._AT;
                SymbolKind symbolKind = _ABY;
                if (symbolKind - SymbolKind.ConstantField > 1)
                {
                    if (symbolKind - SymbolKind.Variable <= 4)
                    {
                        return base.AddDeclaration(symbol);
                    }
                }
                else
                {
                    bool flag2 = !(this._ACV is _b2);
                    if (flag2)
                    {
                        return base.AddDeclaration(symbol);
                    }
                }
                _AAH = this._ACV.AddDeclaration(symbol);
            }
            return _AAH;
        }

        // Token: 0x06000684 RID: 1668 RVA: 0x000E5CE0 File Offset: 0x000E3EE0
        internal override void RemoveDeclaration(FKI symbol)
        {
            SymbolKind _ABY = symbol._AT;
            SymbolKind symbolKind = _ABY;
            if (symbolKind != SymbolKind.LocalConstant && symbolKind - SymbolKind.Variable > 4)
            {
                bool flag = this._ACV != null;
                if (flag)
                {
                    this._ACV.RemoveDeclaration(symbol);
                }
                base.RemoveDeclaration(symbol);
            }
            else
            {
                base.RemoveDeclaration(symbol);
            }
        }

        // Token: 0x06000685 RID: 1669 RVA: 0x000E5D34 File Offset: 0x000E3F34
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            return this._ACV.FindName(symbolName, numTypeParameters, false);
        }

        // Token: 0x06000686 RID: 1670 RVA: 0x000E5D54 File Offset: 0x000E3F54
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            bool flag = this._ACV != null;
            if (flag)
            {
                this._ACV.ResolveMember(leaf, this, numTypeArgs, asTypeOnly);
                bool flag2 = leaf._AAB() != null;
                if (flag2)
                {
                    return;
                }
                bool flag3 = numTypeArgs == 0 && leaf._AAB() == null;
                if (flag3)
                {
                    List<_bd7> typeParameters = this._ACV.GetTypeParameters();
                    bool flag4 = typeParameters != null;
                    if (flag4)
                    {
                        string text = _bh4.DecodeId(leaf._ACX.text);
                        int count = typeParameters.Count;
                        while (count-- > 0)
                        {
                            bool flag5 = typeParameters[count].GetName() == text;
                            if (flag5)
                            {
                                leaf._ACY(typeParameters[count]);
                                return;
                            }
                        }
                    }
                }
            }
            base.Resolve(leaf, numTypeArgs, asTypeOnly);
        }

        // Token: 0x06000687 RID: 1671 RVA: 0x000E5E30 File Offset: 0x000E4030
        internal override void ResolveAttribute(_bb4.DHBA leaf)
        {
            leaf._ACY(null);
            leaf._AJF = null;
            bool flag = this._ACV != null;
            if (flag)
            {
                this._ACV.ResolveAttributeMember(leaf, this);
            }
            bool flag2 = leaf._AAB() == null;
            if (flag2)
            {
                base.ResolveAttribute(leaf);
            }
        }

        // Token: 0x06000688 RID: 1672 RVA: 0x000E5E80 File Offset: 0x000E4080
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            bool flag = this._ACV != null;
            if (flag)
            {
                this._ACV.GetCompletionData(data, context);
            }
            bool _APV = context._APW;
            _bm6 _AQI = this;
            while (context._APW && _AQI != null)
            {
                _bj8 _BEZ = _AQI as _bj8;
                bool flag2 = _BEZ != null;
                if (flag2)
                {
                    _bh4 _APX = _BEZ._ACV;
                    bool flag3 = _APX != null && _APX._AT != SymbolKind.LambdaExpression;
                    if (flag3)
                    {
                        bool flag4 = !_APX.PJOINCMEBNKJCMPMCNPDBKOIJCGMPJPLOEFJ();
                        if (flag4)
                        {
                            context._APW = false;
                        }
                        break;
                    }
                }
                _AQI = _AQI._AMJ();
            }
            base.GetCompletionData(data, context);
            context._APW = _APV;
        }

        // Token: 0x04000593 RID: 1427
        public _bh4 _ACV;
    }
}
