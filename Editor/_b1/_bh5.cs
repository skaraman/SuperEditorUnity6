using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000E7 RID: 231
    internal class _bh5 : _bn2
    {
        // Token: 0x060006CA RID: 1738 RVA: 0x000E59C1 File Offset: 0x000E3BC1
        public _bh5(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x060006CB RID: 1739 RVA: 0x000E8328 File Offset: 0x000E6528
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.CaseVariable;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = base.AddDeclaration(symbol);
            }
            else
            {
                _AAH = base._AMJ().AddDeclaration(symbol);
            }
            return _AAH;
        }

        // Token: 0x060006CC RID: 1740 RVA: 0x000E8360 File Offset: 0x000E6560
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.CaseVariable;
            if (flag)
            {
                base.RemoveDeclaration(symbol);
            }
            else
            {
                base._AMJ().RemoveDeclaration(symbol);
            }
        }
    }
}
