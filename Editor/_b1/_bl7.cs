using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000CB RID: 203
    internal class _bl7 : _b2
    {
        // Token: 0x060005B0 RID: 1456 RVA: 0x000D698C File Offset: 0x000D4B8C
        internal override bool CanConvertTo(_b2 otherType)
        {
            return otherType._AT == SymbolKind.Class || otherType._AT == SymbolKind.Interface || otherType._AT == SymbolKind.Delegate || otherType._AT == SymbolKind.TypeParameter;
        }

        // Token: 0x060005B1 RID: 1457 RVA: 0x000D69C8 File Offset: 0x000D4BC8
        internal override _b2 ConvertTo(_b2 otherType)
        {
            bool flag = otherType == null;
            _b2 _AAC;
            if (flag)
            {
                _AAC = null;
            }
            else
            {
                bool flag2 = otherType is _bd7;
                if (flag2)
                {
                    _AAC = this;
                }
                else
                {
                    bool flag3 = otherType._AT == SymbolKind.Class || otherType._AT == SymbolKind.Interface || otherType._AT == SymbolKind.Delegate;
                    if (flag3)
                    {
                        _AAC = otherType;
                    }
                    else
                    {
                        _AAC = null;
                    }
                }
            }
            return _AAC;
        }
    }
}
