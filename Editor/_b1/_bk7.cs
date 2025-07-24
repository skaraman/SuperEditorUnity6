using System;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000DD RID: 221
    internal class _bk7 : _bm6
    {
        // Token: 0x06000679 RID: 1657 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public _bk7(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x0600067A RID: 1658 RVA: 0x000E5AD4 File Offset: 0x000E3CD4
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            Debug.LogException(new InvalidOperationException());
            return null;
        }

        // Token: 0x0600067B RID: 1659 RVA: 0x000E5AF2 File Offset: 0x000E3CF2
        internal override void RemoveDeclaration(FKI symbol)
        {
            Debug.LogException(new InvalidOperationException());
        }

        // Token: 0x0600067C RID: 1660 RVA: 0x000E5B00 File Offset: 0x000E3D00
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            return base._AMJ().FindName(symbolName, numTypeParameters);
        }

        // Token: 0x0600067D RID: 1661 RVA: 0x000E5B24 File Offset: 0x000E3D24
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            base.Resolve(leaf, numTypeArgs, asTypeOnly);
            bool flag = leaf._AAB() == null || leaf._AAB() == _bh4._AAA;
            if (flag)
            {
                bool flag2 = leaf.OOME._AHB() == "typeOrGeneric" && leaf.OOME.OOME.OOME.OOME._AHB() == "attribute" && leaf.OOME._AIL == leaf.OOME.OOME._AIX - 1;
                if (flag2)
                {
                    string text = leaf._ACX.text;
                    SyntaxToken _BDJ = leaf._ACX;
                    _BDJ.text += "Attribute";
                    leaf._ACY(null);
                    base.Resolve(leaf, numTypeArgs, true);
                    leaf._ACX.text = text;
                }
            }
        }
    }
}
