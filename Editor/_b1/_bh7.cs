using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000A4 RID: 164
    internal class KJK
    {
        // Token: 0x060004A4 RID: 1188 RVA: 0x000CDD78 File Offset: 0x000CBF78
        public _bb4._AIN _APP()
        {
            return this._AEJ;
        }

        // Token: 0x1700001D RID: 29
        // (get) Token: 0x060004A5 RID: 1189 RVA: 0x000CDD90 File Offset: 0x000CBF90
        internal virtual _bh4 definition
        {
            get
            {
                bool flag = this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH != null && !this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH.IsValid();
                if (flag)
                {
                    this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH = this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH.Rebind();
                    bool flag2 = this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH != null && !this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH.IsValid();
                    if (flag2)
                    {
                        this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH = null;
                    }
                }
                bool flag3 = this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH != null;
                if (flag3)
                {
                    bool flag4 = (this._AEJ != null && this._AIW != _bb4._AIU) || !this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH.IsValid();
                    if (flag4)
                    {
                        this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH = null;
                    }
                }
                bool flag5 = this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH == null;
                if (flag5)
                {
                    bool flag6 = !this.LJFIGAEOEPDFDCBFGBENELPCPGFPDLGINLBE;
                    if (!flag6)
                    {
                        return _bh4._AAA;
                    }
                    bool eemmpgfnocikdepiendbnnmfcfaenpfcpdng = KJK.EEMMPGFNOCIKDEPIENDBNNMFCFAENPFCPDNG;
                    if (eemmpgfnocikdepiendbnnmfcfaenpfcpdng)
                    {
                        return _bh4._AAA;
                    }
                    this.LJFIGAEOEPDFDCBFGBENELPCPGFPDLGINLBE = true;
                    this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH = _bh4.ResolveNode(this._AEJ, null, null, 0, false);
                    this._AIW = _bb4._AIU;
                    this.LJFIGAEOEPDFDCBFGBENELPCPGFPDLGINLBE = false;
                    bool flag7 = this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH == null;
                    if (flag7)
                    {
                        this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH = _bh4._AHA;
                        this._AIW = _bb4._AIU;
                    }
                }
                return this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH;
            }
        }

        // Token: 0x060004A6 RID: 1190 RVA: 0x000CDEDA File Offset: 0x000CC0DA
        protected KJK()
        {
        }

        // Token: 0x060004A7 RID: 1191 RVA: 0x000CDEEB File Offset: 0x000CC0EB
        public KJK(_bb4._AIN node)
        {
            this._AEJ = node;
        }

        // Token: 0x060004A8 RID: 1192 RVA: 0x000CDF03 File Offset: 0x000CC103
        public KJK(_bh4 definedSymbol)
        {
            this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH = definedSymbol;
        }

        // Token: 0x060004A9 RID: 1193 RVA: 0x000CDF1C File Offset: 0x000CC11C
        public bool IsValid()
        {
            _bh4 _AAH = null;
            bool flag = this is _bl9;
            if (flag)
            {
                _AAH = this.definition;
            }
            bool flag2 = this._AEJ == null && (this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH == null || this.FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH._AT == SymbolKind.Error);
            bool flag3;
            if (flag2)
            {
                flag3 = false;
            }
            else
            {
                bool flag4 = _AAH == null;
                if (flag4)
                {
                    _AAH = this.definition;
                }
                flag3 = _AAH != null && _AAH.IsValid();
            }
            return flag3;
        }

        // Token: 0x060004AA RID: 1194 RVA: 0x000CDF90 File Offset: 0x000CC190
        public bool IsBefore(_bb4.DHBA leaf)
        {
            bool flag = this._AEJ == null;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                _bb4.DHBA _AEM = this._AEJ as _bb4.DHBA;
                bool flag3 = _AEM == null;
                if (flag3)
                {
                    _AEM = ((_bb4._ACW)this._AEJ).GetLastLeaf();
                }
                flag2 = _AEM != null && (_AEM.line < leaf.line || (_AEM.line == leaf.line && _AEM._AJG() < leaf._AJG()));
            }
            return flag2;
        }

        // Token: 0x060004AB RID: 1195 RVA: 0x000CE010 File Offset: 0x000CC210
        public override string ToString()
        {
            return this.definition.GetTooltipText();
        }

        // Token: 0x040004B8 RID: 1208
        protected _bb4._AIN _AEJ;

        // Token: 0x040004B9 RID: 1209
        protected uint _AIW;

        // Token: 0x040004BA RID: 1210
        protected _bh4 FPNIPCAGFHAMPMOPKHBJLDNLIAOFDPNPODOH;

        // Token: 0x040004BB RID: 1211
        protected bool LJFIGAEOEPDFDCBFGBENELPCPGFPDLGINLBE = false;

        // Token: 0x040004BC RID: 1212
        public static bool EEMMPGFNOCIKDEPIENDBNNMFCFAENPFCPDNG;
    }
}
