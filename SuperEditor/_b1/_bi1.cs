using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AHO
{
    // Token: 0x02000006 RID: 6
    internal class _bi1
    {
        // Token: 0x06000014 RID: 20 RVA: 0x000030D5 File Offset: 0x000012D5
        [CompilerGenerated]
        protected string _AIG()
        {
            return this.IMFHFECEGEPHPPCLPEPBCOLFFAJMBLNIGHAC;
        }

        // Token: 0x06000015 RID: 21 RVA: 0x000030DD File Offset: 0x000012DD
        [CompilerGenerated]
        private void NMBPBFJFHGJFIHDIHKLMJLFPANJAODJEPBEC(string value)
        {
            this.IMFHFECEGEPHPPCLPEPBCOLFFAJMBLNIGHAC = value;
        }

        // Token: 0x06000016 RID: 22 RVA: 0x000030E6 File Offset: 0x000012E6
        protected _bi1(string key)
        {
            this.NMBPBFJFHGJFIHDIHKLMJLFPANJAODJEPBEC(key);
        }

        // Token: 0x06000017 RID: 23 RVA: 0x000030F8 File Offset: 0x000012F8
        public string ToJson()
        {
            return string.Concat(new string[]
            {
                "\"Vik.SuperEditor.",
                this._AIG(),
                "\" = \"",
                this.ToString().Replace("\"", "\\\""),
                "\""
            });
        }

        // Token: 0x04000053 RID: 83
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CompilerGenerated]
        private string IMFHFECEGEPHPPCLPEPBCOLFFAJMBLNIGHAC;
    }
}
