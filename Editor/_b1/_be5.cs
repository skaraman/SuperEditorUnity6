using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x0200002F RID: 47
    internal class _be5 : _bh4
    {
        // Token: 0x06000167 RID: 359 RVA: 0x00014408 File Offset: 0x00012608
        public _be5(string name)
        {
            this._AW = name;
            this._AT = SymbolKind.Snippet;
        }

        // Token: 0x06000168 RID: 360 RVA: 0x0001442B File Offset: 0x0001262B
        public _be5(string name, string displayFormat)
            : this(name)
        {
            this._AWF = displayFormat;
        }

        // Token: 0x06000169 RID: 361 RVA: 0x0001443D File Offset: 0x0001263D
        public _be5(string name, string displayFormat, string expandTo)
            : this(name, displayFormat)
        {
            this._AWG = expandTo;
        }

        // Token: 0x0600016A RID: 362 RVA: 0x00014450 File Offset: 0x00012650
        internal override string CompletionDisplayString(string styledName)
        {
            return string.Format(this._AWF, styledName);
        }

        // Token: 0x0600016B RID: 363 RVA: 0x00014470 File Offset: 0x00012670
        public virtual string Expand()
        {
            return this._AWG;
        }

        // Token: 0x0600016C RID: 364 RVA: 0x00014488 File Offset: 0x00012688
        public virtual void OverrideTypedInLength(ref int typedInLength)
        {
        }

        // Token: 0x04000191 RID: 401
        protected string _AWF = "{0}";

        // Token: 0x04000192 RID: 402
        protected string _AWG;
    }
}
