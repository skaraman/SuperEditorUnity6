using System;
using System.Collections.Generic;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000AF RID: 175
    internal class _bd1 : _ba7
    {
        // Token: 0x060004FB RID: 1275 RVA: 0x000D07D4 File Offset: 0x000CE9D4
        internal override _bh4 GetGenericSymbol()
        {
            return this._AQJ;
        }

        // Token: 0x060004FC RID: 1276 RVA: 0x000D07EC File Offset: 0x000CE9EC
        public _bd1(_ba7 definition, KJK[] arguments)
        {
            this._AW = definition._AW;
            this._AT = definition._AT;
            this._AO = definition._AO;
            this._AQJ = definition;
            this._AV = definition._AV;
            this._AHH = arguments;
            this.UpdateMethods();
        }

        // Token: 0x060004FD RID: 1277 RVA: 0x000D0848 File Offset: 0x000CEA48
        private void UpdateMethods()
        {
            List<_bb3> _AAL = this._AQJ._AAM;
            int count = this._AAM.Count;
            while (count-- > 0)
            {
                bool flag = !_AAL.Contains(this._AAM[count].GetGenericSymbol() as _bb3);
                if (flag)
                {
                    this._AAM.RemoveAt(count);
                }
            }
            int count2 = _AAL.Count;
            while (count2-- > 0)
            {
                _bb3 _AAN = _AAL[count2];
                bool flag2 = _AAN._AHG() == this._AHH.Length;
                if (flag2)
                {
                    bool flag3 = false;
                    int count3 = this._AAM.Count;
                    while (count3-- > 0)
                    {
                        bool flag4 = this._AAM[count3].GetGenericSymbol() == _AAN;
                        if (flag4)
                        {
                            flag3 = true;
                            break;
                        }
                    }
                    bool flag5 = !flag3;
                    if (flag5)
                    {
                        _bl4 _AIQ = _AAN.ConstructMethod(this._AHH);
                        bool flag6 = _AIQ != null;
                        if (flag6)
                        {
                            _AIQ._AO = this;
                            this._AAM.Add(_AIQ);
                        }
                    }
                }
            }
        }

        // Token: 0x060004FE RID: 1278 RVA: 0x000D0978 File Offset: 0x000CEB78
        internal override _bh4 ResolveMethodOverloads(_bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            this.UpdateMethods();
            return base.ResolveMethodOverloads(argumentListNode, typeArgs, scope, invokedLeaf);
        }

        // Token: 0x060004FF RID: 1279 RVA: 0x000D09A0 File Offset: 0x000CEBA0
        internal override _bb3 ResolveMethodOverloads(int numArguments, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            this.UpdateMethods();
            return base.ResolveMethodOverloads(numArguments, scope, invokedLeaf);
        }

        // Token: 0x06000500 RID: 1280 RVA: 0x000D09C4 File Offset: 0x000CEBC4
        internal override int CollectCandidates(int numArguments, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            this.UpdateMethods();
            return base.CollectCandidates(numArguments, scope, invokedLeaf);
        }

        // Token: 0x06000501 RID: 1281 RVA: 0x000D09E6 File Offset: 0x000CEBE6
        internal override void AddMethod(_bb3 method)
        {
            Debug.LogError("AddMethod on ConstructedMethodGroupDefinition: " + ((method != null) ? method.ToString() : null));
        }

        // Token: 0x040004EE RID: 1262
        public readonly _ba7 _AQJ;

        // Token: 0x040004EF RID: 1263
        public readonly KJK[] _AHH;
    }
}
