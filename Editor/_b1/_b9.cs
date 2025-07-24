using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000DB RID: 219
    internal class _b9 : _bj8
    {
        // Token: 0x06000672 RID: 1650 RVA: 0x000E5820 File Offset: 0x000E3A20
        private _bj1 GNIO()
        {
            bool flag = this._ACU == null || !this._ACU.IsValid();
            if (flag)
            {
                this._ACV._AO.TypeOf();
                this._ACU = new _bj1
                {
                    _AW = "value",
                    _AT = SymbolKind.Parameter,
                    _AO = this._ACV,
                    BLH = ((_bn3)this._ACV._AO).BLH
                };
            }
            return this._ACU;
        }

        // Token: 0x06000673 RID: 1651 RVA: 0x000E58AD File Offset: 0x000E3AAD
        public _b9(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x06000674 RID: 1652 RVA: 0x000E58B8 File Offset: 0x000E3AB8
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            bool flag = numTypeParameters == 0 && symbolName == "value" && this._ACV._AW != "get";
            _bh4 _AAH;
            if (flag)
            {
                _AAH = this.GNIO();
            }
            else
            {
                _AAH = base.FindName(symbolName, numTypeParameters);
            }
            return _AAH;
        }

        // Token: 0x06000675 RID: 1653 RVA: 0x000E5908 File Offset: 0x000E3B08
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            bool flag = !asTypeOnly && numTypeArgs == 0 && leaf._ACX.text == "value" && this._ACV._AW != "get";
            if (flag)
            {
                leaf._ACY(this.GNIO());
            }
            else
            {
                base.Resolve(leaf, numTypeArgs, asTypeOnly);
            }
        }

        // Token: 0x06000676 RID: 1654 RVA: 0x000E596C File Offset: 0x000E3B6C
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            bool flag = this._ACV._AW != "get";
            if (flag)
            {
                data["value"] = this.GNIO();
            }
            this._ACV._AO.GetCompletionData(data, context);
            base.GetCompletionData(data, context);
        }

        // Token: 0x04000592 RID: 1426
        private _bj1 _ACU;
    }
}
