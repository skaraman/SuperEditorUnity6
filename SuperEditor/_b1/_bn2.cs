using System;
using System.Collections.Generic;

namespace AHO
{
    // Token: 0x020000E1 RID: 225
    internal class _bn2 : _bm6
    {
        // Token: 0x0600068B RID: 1675 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public _bn2(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x0600068C RID: 1676 RVA: 0x000E5F74 File Offset: 0x000E4174
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            symbol._AJW = this;
            bool flag = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG == null;
            if (flag)
            {
                this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG = new List<_bh4>();
            }
            _bh4 _AAH = _bh4.Create(symbol);
            this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG.Add(_AAH);
            return _AAH;
        }

        // Token: 0x0600068D RID: 1677 RVA: 0x000E5FBC File Offset: 0x000E41BC
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG != null;
            if (flag)
            {
                int count = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG.Count;
                while (count-- > 0)
                {
                    _bh4 _AAH = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG[count];
                    bool flag2 = _AAH._AEI == null;
                    if (!flag2)
                    {
                        bool flag3 = !_AAH._AEI.Remove(symbol);
                        if (!flag3)
                        {
                            bool flag4 = _AAH._AEI.Count == 0;
                            if (flag4)
                            {
                                this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG.RemoveAt(count);
                            }
                        }
                    }
                }
            }
            symbol._ACV = null;
        }

        // Token: 0x0600068E RID: 1678 RVA: 0x000E6054 File Offset: 0x000E4254
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            bool flag = !asTypeOnly && this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG != null;
            if (flag)
            {
                string text = _bh4.DecodeId(leaf._ACX.text);
                int count = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG.Count;
                while (count-- > 0)
                {
                    bool flag2 = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG[count]._AW == text;
                    if (flag2)
                    {
                        leaf._ACY(this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG[count]);
                        return;
                    }
                }
            }
            base.Resolve(leaf, numTypeArgs, asTypeOnly);
        }

        // Token: 0x0600068F RID: 1679 RVA: 0x000E60EC File Offset: 0x000E42EC
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            symbolName = _bh4.DecodeId(symbolName);
            bool flag = numTypeParameters == 0 && this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG != null;
            if (flag)
            {
                int count = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG.Count;
                while (count-- > 0)
                {
                    bool flag2 = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG[count]._AW == symbolName;
                    if (flag2)
                    {
                        return this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG[count];
                    }
                }
            }
            return null;
        }

        // Token: 0x06000690 RID: 1680 RVA: 0x000E6164 File Offset: 0x000E4364
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            bool flag = this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG != null;
            if (flag)
            {
                foreach (_bh4 _AAH in this.CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG)
                {
                    FKI _AFF = _AAH._AEI.FirstOrDefault<FKI>();
                    _bb4._ACW _AGZ = ((_AFF != null) ? _AFF._AEJ : null);
                    bool flag2 = _AGZ == null;
                    if (!flag2)
                    {
                        _bb4.DHBA firstLeaf = _AGZ.GetFirstLeaf();
                        bool flag3 = firstLeaf != null && (firstLeaf.line > context._AQD || (firstLeaf.line == context._AQD && firstLeaf._AJG() >= context._AQE));
                        if (!flag3)
                        {
                            bool flag4 = !data.ContainsKey(_AAH._AW);
                            if (flag4)
                            {
                                data.Add(_AAH._AW, _AAH);
                            }
                        }
                    }
                }
            }
            base.GetCompletionData(data, context);
        }

        // Token: 0x04000597 RID: 1431
        protected List<_bh4> CLLBCBNBBJMLLCAEFKAJACIFKKFPIHKHEIIG;
    }
}
