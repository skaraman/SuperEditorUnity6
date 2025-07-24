using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000D6 RID: 214
    internal class _bc7 : _bn3
    {
        // Token: 0x0600063A RID: 1594 RVA: 0x000E349C File Offset: 0x000E169C
        public _bc7(_b2 type)
        {
            this.BLH = new KJK(type.SubstituteTypeParameters(type ?? _bh4._AHA));
            this._AT = SymbolKind.Instance;
        }

        // Token: 0x0600063B RID: 1595 RVA: 0x000E34CC File Offset: 0x000E16CC
        internal override string GetTooltipText()
        {
            return this.BLH.definition.GetTooltipText();
        }

        // Token: 0x0600063C RID: 1596 RVA: 0x000E34F0 File Offset: 0x000E16F0
        public new bool IsValid()
        {
            return this.BLH != null && this.BLH.definition != null && this.BLH.definition.IsValid();
        }
    }
}
