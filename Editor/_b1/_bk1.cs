using System;

namespace AHO
{
    // Token: 0x020000DE RID: 222
    internal class _bk1 : _bm6
    {
        // Token: 0x0600067E RID: 1662 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public _bk1(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x0600067F RID: 1663 RVA: 0x000E5C10 File Offset: 0x000E3E10
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            return base._AMJ().AddDeclaration(symbol);
        }

        // Token: 0x06000680 RID: 1664 RVA: 0x000E5C2E File Offset: 0x000E3E2E
        internal override void RemoveDeclaration(FKI symbol)
        {
            base._AMJ().RemoveDeclaration(symbol);
        }

        // Token: 0x06000681 RID: 1665 RVA: 0x000E5C40 File Offset: 0x000E3E40
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            return base._AMJ().FindName(symbolName, numTypeParameters);
        }
    }
}
