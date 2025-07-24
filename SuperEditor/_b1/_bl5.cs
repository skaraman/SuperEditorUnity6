using System;

namespace AHO
{
    // Token: 0x020000E9 RID: 233
    internal class NLGEOGIKCPGHIFEMBHMJCBHPIFHBPGOJKCJI : _bm6
    {
        // Token: 0x060006D5 RID: 1749 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public NLGEOGIKCPGHIFEMBHMJCBHPIFHBPGOJKCJI(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x060006D6 RID: 1750 RVA: 0x000E86BC File Offset: 0x000E68BC
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            return null;
        }

        // Token: 0x060006D7 RID: 1751 RVA: 0x00014488 File Offset: 0x00012688
        internal override void RemoveDeclaration(FKI symbol)
        {
        }

        // Token: 0x060006D8 RID: 1752 RVA: 0x000E86D0 File Offset: 0x000E68D0
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            return base._AMJ().FindName(symbolName, numTypeParameters);
        }

        // Token: 0x060006D9 RID: 1753 RVA: 0x000E86F0 File Offset: 0x000E68F0
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            bool flag = base._AMJ() != null;
            if (flag)
            {
                base._AMJ().Resolve(leaf, numTypeArgs, asTypeOnly);
            }
        }

        // Token: 0x040005B1 RID: 1457
        public _b2 _ACV;
    }
}
