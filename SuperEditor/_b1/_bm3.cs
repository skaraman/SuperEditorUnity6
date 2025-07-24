using System;

namespace AHO
{
    // Token: 0x020000B6 RID: 182
    internal class _bm3 : _b2
    {
        // Token: 0x06000546 RID: 1350 RVA: 0x000D2EBC File Offset: 0x000D10BC
        internal override string GetTooltipText()
        {
            return _bh4._AAQ.GetTooltipText();
        }

        // Token: 0x06000547 RID: 1351 RVA: 0x000D2ED8 File Offset: 0x000D10D8
        internal override _bh4 TypeOf()
        {
            return _bh4._AAQ;
        }

        // Token: 0x06000548 RID: 1352 RVA: 0x000D2EF0 File Offset: 0x000D10F0
        internal override bool CanConvertTo(_b2 otherType)
        {
            return this.IsSameType(otherType) || otherType == _bh4._AAS || otherType == _bh4._AAT || otherType == _bh4._BFC || base.CanConvertTo(otherType);
        }
    }
}
