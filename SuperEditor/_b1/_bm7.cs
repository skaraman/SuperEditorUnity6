using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000B0 RID: 176
    internal class _bm7 : _bh4
    {
        // Token: 0x06000502 RID: 1282 RVA: 0x000D0A06 File Offset: 0x000CEC06
        [CompilerGenerated]
        public _bh4 _CBS()
        {
            return this.IFHBDILHNIBEGNMFFMBDEBMGAOBIFIOMBNOG;
        }

        // Token: 0x06000503 RID: 1283 RVA: 0x000D0A0E File Offset: 0x000CEC0E
        [CompilerGenerated]
        private void KAIFPIBBINFLPLILIMLFGAHKIJJLLGPCFMGJ(_bh4 value)
        {
            this.IFHBDILHNIBEGNMFFMBDEBMGAOBIFIOMBNOG = value;
        }

        // Token: 0x06000504 RID: 1284 RVA: 0x000D0A18 File Offset: 0x000CEC18
        public _bm7(_bh4 referencedSymbolDefinition)
        {
            this.KAIFPIBBINFLPLILIMLFGAHKIJJLLGPCFMGJ(referencedSymbolDefinition);
            this._AT = this._CBS()._AT;
            this._AV = this._CBS()._AV;
            this._AU = this._CBS()._AU;
            this._AW = this._CBS()._AW;
        }

        // Token: 0x06000505 RID: 1285 RVA: 0x000D0A7C File Offset: 0x000CEC7C
        internal override _bh4 Rebind()
        {
            this.KAIFPIBBINFLPLILIMLFGAHKIJJLLGPCFMGJ(this._CBS().Rebind());
            return base.Rebind();
        }

        // Token: 0x17000024 RID: 36
        // (get) Token: 0x06000506 RID: 1286 RVA: 0x000D0AA8 File Offset: 0x000CECA8
        internal override bool IsExtensionMethod
        {
            get
            {
                return this._CBS().IsExtensionMethod;
            }
        }

        // Token: 0x06000507 RID: 1287 RVA: 0x000D0AC8 File Offset: 0x000CECC8
        internal override _b2 TypeOfTypeParameter(_bd7 tp)
        {
            _b2 _AAC = this._CBS().TypeOfTypeParameter(tp);
            _bd7 _AHM = _AAC as _bd7;
            bool flag = _AHM != null;
            _b2 _AAC2;
            if (flag)
            {
                _AAC2 = base.TypeOfTypeParameter(tp);
            }
            else
            {
                _AAC2 = _AAC;
            }
            return _AAC2;
        }

        // Token: 0x06000508 RID: 1288 RVA: 0x000D0B04 File Offset: 0x000CED04
        internal override _b2 SubstituteTypeParameters(_bh4 context)
        {
            return base.SubstituteTypeParameters(context);
        }

        // Token: 0x06000509 RID: 1289 RVA: 0x000D0B20 File Offset: 0x000CED20
        internal override _bh4 TypeOf()
        {
            _b2 _AAC = this._CBS().TypeOf() as _b2;
            _bi5 _AAE = this._AO as _bi5;
            bool flag = _AAE != null && _AAC != null;
            if (flag)
            {
                _AAC = _AAC.SubstituteTypeParameters(_AAE);
            }
            return _AAC;
        }

        // Token: 0x0600050A RID: 1290 RVA: 0x000D0B68 File Offset: 0x000CED68
        internal override _bh4 GetGenericSymbol()
        {
            return this._CBS().GetGenericSymbol();
        }

        // Token: 0x0600050B RID: 1291 RVA: 0x000D0B88 File Offset: 0x000CED88
        internal override List<_bm1> GetParameters()
        {
            return this._CBS().GetParameters();
        }

        // Token: 0x0600050C RID: 1292 RVA: 0x000D0BA8 File Offset: 0x000CEDA8
        internal override List<_bd7> GetTypeParameters()
        {
            return this._CBS().GetTypeParameters();
        }

        // Token: 0x0600050D RID: 1293 RVA: 0x000D0BC8 File Offset: 0x000CEDC8
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            if (!asTypeOnly)
            {
                _b2 _AAC = this.TypeOf() as _b2;
                bool flag = _AAC != null;
                if (flag)
                {
                    _AAC.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
                }
            }
        }

        // Token: 0x0600050E RID: 1294 RVA: 0x000D0C00 File Offset: 0x000CEE00
        internal override _bh4 ResolveMethodOverloads(_bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            bool flag = this._AT != SymbolKind.MethodGroup;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                bool flag2 = this._CBS()._AO == null && this._CBS()._AGU != null;
                if (flag2)
                {
                    this.KAIFPIBBINFLPLILIMLFGAHKIJJLLGPCFMGJ(this._CBS().Rebind());
                }
                _bh4 _AAH2 = this._CBS().ResolveMethodOverloads(argumentListNode, typeArgs, scope, invokedLeaf);
                bool flag3 = _AAH2 == null || _AAH2._AT != SymbolKind.Method;
                if (flag3)
                {
                    _AAH = null;
                }
                else
                {
                    _AAH = ((_bi5)this._AO).GetConstructedMember(_AAH2);
                }
            }
            return _AAH;
        }

        // Token: 0x0600050F RID: 1295 RVA: 0x000D0C9C File Offset: 0x000CEE9C
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            _bh4 _AAH = this.TypeOf();
            bool flag = _AAH != null;
            if (flag)
            {
                _AAH.GetMembersCompletionData(data, BindingFlags.Instance, mask, context);
            }
        }

        // Token: 0x040004F0 RID: 1264
        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private _bh4 IFHBDILHNIBEGNMFFMBDEBMGAOBIFIOMBNOG;
    }
}
