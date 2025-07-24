using System;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000007 RID: 7
    internal class _bf5 : _bi1
    {
        // Token: 0x06000018 RID: 24 RVA: 0x00003150 File Offset: 0x00001350
        public bool GNIO()
        {
            return this._AIE;
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00003168 File Offset: 0x00001368
        public void _AIF(bool value)
        {
            bool flag = this._AIE == value;
            if (!flag)
            {
                this._AIE = value;
                EditorPrefs.SetBool("Vik.SuperEditor." + base._AIG(), value);
                _bi2.RepaintAllInstances();
            }
        }

        // Token: 0x0600001A RID: 26 RVA: 0x000031A9 File Offset: 0x000013A9
        public _bf5(string key, bool defaultValue)
            : base(key)
        {
            this._AIE = EditorPrefs.GetBool("Vik.SuperEditor." + key, defaultValue);
        }

        // Token: 0x0600001B RID: 27 RVA: 0x000031CC File Offset: 0x000013CC
        public bool Toggle()
        {
            this._AIF(!this.GNIO());
            return this.GNIO();
        }

        // Token: 0x0600001C RID: 28 RVA: 0x000031F4 File Offset: 0x000013F4
        public override string ToString()
        {
            return this.GNIO().ToString();
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00003214 File Offset: 0x00001414
        public static implicit operator bool(_bf5 self)
        {
            return self.GNIO();
        }

        // Token: 0x04000054 RID: 84
        private bool _AIE;
    }
}
