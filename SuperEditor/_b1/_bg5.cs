using System;
using UnityEditor;

namespace AHO
{
    // Token: 0x0200000A RID: 10
    internal class _bg5 : _bi1
    {
        // Token: 0x06000028 RID: 40 RVA: 0x00003394 File Offset: 0x00001594
        public string GNIO()
        {
            return this._AIE;
        }

        // Token: 0x06000029 RID: 41 RVA: 0x000033AC File Offset: 0x000015AC
        public void _AIF(string value)
        {
            bool flag = this._AIE == value;
            if (!flag)
            {
                this._AIE = value;
                EditorPrefs.SetString("Vik.SuperEditor." + base._AIG(), value);
                _bi2.RepaintAllInstances();
            }
        }

        // Token: 0x0600002A RID: 42 RVA: 0x000033F0 File Offset: 0x000015F0
        public _bg5(string key, string defaultValue)
            : base(key)
        {
            this._AIE = EditorPrefs.GetString("Vik.SuperEditor." + key, defaultValue);
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00003414 File Offset: 0x00001614
        public override string ToString()
        {
            return this.GNIO().ToString();
        }

        // Token: 0x0600002C RID: 44 RVA: 0x00003434 File Offset: 0x00001634
        public static implicit operator string(_bg5 self)
        {
            return self.GNIO();
        }

        // Token: 0x04000057 RID: 87
        private string _AIE;
    }
}
