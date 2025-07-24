using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000AD RID: 173
    internal class _ba8 : _bn3
    {
        // Token: 0x060004EF RID: 1263 RVA: 0x000D044C File Offset: 0x000CE64C
        public _ba8(_bn3 genericSymbolDefinition)
        {
            this._AHY = genericSymbolDefinition;
            this._AT = this._AHY._AT;
            this._AV = this._AHY._AV;
            this._AU = this._AHY._AU;
            this._AW = this._AHY._AW;
        }

        // Token: 0x060004F0 RID: 1264 RVA: 0x000D04AC File Offset: 0x000CE6AC
        internal override _bh4 TypeOf()
        {
            _b2 _AAC = this._AHY.TypeOf() as _b2;
            _bi5 _AAE = this._AO as _bi5;
            bool flag = _AAE != null && _AAC != null;
            if (flag)
            {
                _AAC = _AAC.SubstituteTypeParameters(_AAE);
            }
            return _AAC;
        }

        // Token: 0x060004F1 RID: 1265 RVA: 0x000D04F4 File Offset: 0x000CE6F4
        internal override _bh4 GetGenericSymbol()
        {
            return this._AHY;
        }

        // Token: 0x060004F2 RID: 1266 RVA: 0x000D050C File Offset: 0x000CE70C
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            _b2 _AAC = this.TypeOf() as _b2;
            bool flag = _AAC != null;
            if (flag)
            {
                _AAC.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
            }
        }

        // Token: 0x060004F3 RID: 1267 RVA: 0x000D053C File Offset: 0x000CE73C
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            _bh4 _AAH = this.TypeOf();
            bool flag = _AAH != null;
            if (flag)
            {
                _AAH.GetMembersCompletionData(data, BindingFlags.Instance, mask, context);
            }
        }

        // Token: 0x040004EB RID: 1259
        public readonly _bn3 _AHY;
    }
}
