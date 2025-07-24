using System;

namespace AHO
{
    // Token: 0x020000E0 RID: 224
    internal class _be7 : _bc8
    {
        // Token: 0x06000689 RID: 1673 RVA: 0x000E5F32 File Offset: 0x000E4132
        public _be7()
            : base(null)
        {
        }

        // Token: 0x0600068A RID: 1674 RVA: 0x000E5F40 File Offset: 0x000E4140
        internal override string CreateAnonymousName()
        {
            string text = ".Anonymous_";
            int _AWH = this._AWI;
            this._AWI = _AWH + 1;
            return text + _AWH.ToString();
        }

        // Token: 0x04000594 RID: 1428
        public string _AWJ;

        // Token: 0x04000595 RID: 1429
        public _bj5 _AN;

        // Token: 0x04000596 RID: 1430
        private int _AWI;
    }
}
