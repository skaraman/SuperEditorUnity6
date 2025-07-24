using System;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000008 RID: 8
    internal class _bb2 : _bi1
    {
        // Token: 0x0600001E RID: 30 RVA: 0x0000322C File Offset: 0x0000142C
        public int GNIO()
        {
            return this._AIE;
        }

        // Token: 0x0600001F RID: 31 RVA: 0x00003244 File Offset: 0x00001444
        public void _AIF(int value)
        {
            bool flag = this._AIE == value;
            if (!flag)
            {
                this._AIE = value;
                EditorPrefs.SetInt("Vik.SuperEditor." + base._AIG(), value);
                _bi2.RepaintAllInstances();
            }
        }

        // Token: 0x06000020 RID: 32 RVA: 0x00003285 File Offset: 0x00001485
        public _bb2(string key, int defaultValue)
            : base(key)
        {
            this._AIE = EditorPrefs.GetInt("Vik.SuperEditor." + key, defaultValue);
        }

        // Token: 0x06000021 RID: 33 RVA: 0x000032A8 File Offset: 0x000014A8
        public override string ToString()
        {
            return this.GNIO().ToString();
        }

        // Token: 0x06000022 RID: 34 RVA: 0x000032C8 File Offset: 0x000014C8
        public static implicit operator int(_bb2 self)
        {
            return self.GNIO();
        }

        // Token: 0x04000055 RID: 85
        private int _AIE;
    }
}
