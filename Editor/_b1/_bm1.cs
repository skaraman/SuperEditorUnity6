using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000CC RID: 204
    internal class _bm1 : _bn3
    {
        // Token: 0x060005B3 RID: 1459 RVA: 0x000D6A20 File Offset: 0x000D4C20
        public bool _AWV()
        {
            return (this._AV & Modifiers.This) == Modifiers.This;
        }

        // Token: 0x060005B4 RID: 1460 RVA: 0x000D6A48 File Offset: 0x000D4C48
        public bool _AGL()
        {
            return (this._AV & Modifiers.Ref) == Modifiers.Ref;
        }

        // Token: 0x060005B5 RID: 1461 RVA: 0x000D6A70 File Offset: 0x000D4C70
        public bool _AGK()
        {
            return this._AV == Modifiers.Out;
        }

        // Token: 0x060005B6 RID: 1462 RVA: 0x000D6A90 File Offset: 0x000D4C90
        public bool _AHS()
        {
            return (this._AV & Modifiers.In) == Modifiers.In;
        }

        // Token: 0x060005B7 RID: 1463 RVA: 0x000D6AB8 File Offset: 0x000D4CB8
        public bool _AHO()
        {
            return this._AV == Modifiers.Params;
        }

        // Token: 0x060005B8 RID: 1464 RVA: 0x000D6AD8 File Offset: 0x000D4CD8
        public bool _AWW()
        {
            return this._AWY != null || this._AHO();
        }

        // Token: 0x0400052C RID: 1324
        public string _AWY;
    }
}
