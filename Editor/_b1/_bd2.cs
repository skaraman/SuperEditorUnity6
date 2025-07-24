using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000B2 RID: 178
    internal class _bd2 : _bc6
    {
        // Token: 0x0600052A RID: 1322 RVA: 0x000D1AE4 File Offset: 0x000CFCE4
        internal override _b2 BaseType()
        {
            bool flag = this._APC == null;
            if (flag)
            {
                this._APC = _bl9.ForType(typeof(MulticastDelegate));
            }
            return this._APC.definition as _b2;
        }

        // Token: 0x0600052B RID: 1323 RVA: 0x000D1B28 File Offset: 0x000CFD28
        internal override List<KJK> Interfaces()
        {
            bool flag = this._APD == null;
            if (flag)
            {
                this._APD = this.BaseType().Interfaces();
            }
            return this._APD;
        }

        // Token: 0x0600052C RID: 1324 RVA: 0x000D1B60 File Offset: 0x000CFD60
        internal override _bh4 TypeOf()
        {
            return (this._AIJ != null && this._AIJ.definition.IsValid()) ? this._AIJ.definition : _bh4._AHA;
        }

        // Token: 0x0600052D RID: 1325 RVA: 0x000D1BA0 File Offset: 0x000CFDA0
        public _bh4 AddParameter(FKI symbol)
        {
            string text = symbol.Name;
            _bm1 _AGS = (_bm1)_bh4.Create(symbol);
            _AGS.BLH = new KJK(symbol._AEJ.FindChildByName("type"));
            _AGS._AO = this;
            bool flag = !string.IsNullOrEmpty(text);
            if (flag)
            {
                bool flag2 = this._AIK == null;
                if (flag2)
                {
                    this._AIK = new List<_bm1>();
                }
                this._AIK.Add(_AGS);
                _bb4._AIN _AIO = symbol.NameNode();
                bool flag3 = _AIO != null;
                if (flag3)
                {
                    _AIO.SetDeclaredSymbol(_AGS);
                }
            }
            return _AGS;
        }

        // Token: 0x0600052E RID: 1326 RVA: 0x000D1C3C File Offset: 0x000CFE3C
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Parameter;
            _bh4 _AAH2;
            if (flag)
            {
                _bh4 _AAH = this.AddParameter(symbol);
                symbol._ACV = _AAH;
                _AAH2 = _AAH;
            }
            else
            {
                _AAH2 = base.AddDeclaration(symbol);
            }
            return _AAH2;
        }

        // Token: 0x0600052F RID: 1327 RVA: 0x000D1C78 File Offset: 0x000CFE78
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Parameter && this._AIK != null;
            if (flag)
            {
                this._AIK.Remove((_bm1)symbol._ACV);
            }
            else
            {
                base.RemoveDeclaration(symbol);
            }
        }

        // Token: 0x06000530 RID: 1328 RVA: 0x000D1CC4 File Offset: 0x000CFEC4
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            bool flag = !asTypeOnly && this._AIK != null;
            if (flag)
            {
                string text = _bh4.DecodeId(leaf._ACX.text);
                _bm1 _AGS = this._AIK.LastByName(text);
                bool flag2 = _AGS != null;
                if (flag2)
                {
                    leaf._ACY(_AGS);
                    return;
                }
            }
            base.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
        }

        // Token: 0x06000531 RID: 1329 RVA: 0x000D1D28 File Offset: 0x000CFF28
        internal override List<_bm1> GetParameters()
        {
            return this._AIK ?? _bh4._AHV;
        }

        // Token: 0x06000532 RID: 1330 RVA: 0x000D1D4C File Offset: 0x000CFF4C
        internal override string GetDelegateInfoText()
        {
            bool flag = this._AQK == null;
            if (flag)
            {
                this._AQK = this._AIJ.definition.GetName() + " " + this.GetName() + ((this._AIK != null && this._AIK.Count == 1) ? "( " : "(");
                this._AQK = this._AQK + base.PrintParameters(this._AIK, false) + ((this._AIK != null && this._AIK.Count == 1) ? " )" : ")");
            }
            return this._AQK;
        }

        // Token: 0x040004F5 RID: 1269
        public KJK _AIJ;

        // Token: 0x040004F6 RID: 1270
        public List<_bm1> _AIK;

        // Token: 0x040004F7 RID: 1271
        private string _AQK;
    }
}
