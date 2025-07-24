using System;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000009 RID: 9
    internal class _bf2 : _bi1
    {
        // Token: 0x06000023 RID: 35 RVA: 0x000032E0 File Offset: 0x000014E0
        public float GNIO()
        {
            return this._AIE;
        }

        // Token: 0x06000024 RID: 36 RVA: 0x000032F8 File Offset: 0x000014F8
        public void _AIF(float value)
        {
            bool flag = this._AIE == value;
            if (!flag)
            {
                this._AIE = value;
                EditorPrefs.SetFloat("Vik.SuperEditor." + base._AIG(), value);
                _bi2.RepaintAllInstances();
            }
        }

        // Token: 0x06000025 RID: 37 RVA: 0x00003339 File Offset: 0x00001539
        public _bf2(string key, float defaultValue)
            : base(key)
        {
            this._AIE = EditorPrefs.GetFloat("Vik.SuperEditor." + key, defaultValue);
        }

        // Token: 0x06000026 RID: 38 RVA: 0x0000335C File Offset: 0x0000155C
        public override string ToString()
        {
            return this.GNIO().ToString();
        }

        // Token: 0x06000027 RID: 39 RVA: 0x0000337C File Offset: 0x0000157C
        public static implicit operator float(_bf2 self)
        {
            return self.GNIO();
        }

        // Token: 0x04000056 RID: 86
        private float _AIE;
    }
}
