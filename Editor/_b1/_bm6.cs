using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000E5 RID: 229
    internal abstract class _bm6
    {
        // Token: 0x060006AE RID: 1710 RVA: 0x000E7E07 File Offset: 0x000E6007
        public _bm6(_bb4._ACW node)
        {
            this._AEJ = node;
        }

        // Token: 0x060006AF RID: 1711 RVA: 0x000E7E18 File Offset: 0x000E6018
        public _bm6 _AMJ()
        {
            bool flag = this._zd5 != null || this._AEJ == null;
            _bm6 _AQI;
            if (flag)
            {
                _AQI = this._zd5;
            }
            else
            {
                for (_bb4._ACW _AGZ = this._AEJ.OOME; _AGZ != null; _AGZ = _AGZ.OOME)
                {
                    bool flag2 = _AGZ._AJW != null;
                    if (flag2)
                    {
                        return _AGZ._AJW;
                    }
                }
                _AQI = null;
            }
            return _AQI;
        }

        // Token: 0x060006B0 RID: 1712 RVA: 0x000E7E81 File Offset: 0x000E6081
        public void _zd6(_bm6 value)
        {
            this._zd5 = value;
        }

        // Token: 0x060006B1 RID: 1713 RVA: 0x000E7E8C File Offset: 0x000E608C
        public _bj5 GetAssembly()
        {
            for (_bm6 _AQI = this; _AQI != null; _AQI = _AQI._AMJ())
            {
                _be7 _CHH = _AQI as _be7;
                bool flag = _CHH != null;
                if (flag)
                {
                    return _CHH._AN;
                }
            }
            throw new Exception("No Assembly for scope???");
        }

        // Token: 0x060006B2 RID: 1714
        internal abstract _bh4 AddDeclaration(FKI symbol);

        // Token: 0x060006B3 RID: 1715
        internal abstract void RemoveDeclaration(FKI symbol);

        // Token: 0x060006B4 RID: 1716 RVA: 0x000E7ED8 File Offset: 0x000E60D8
        internal virtual string CreateAnonymousName()
        {
            return (this._AMJ() != null) ? this._AMJ().CreateAnonymousName() : null;
        }

        // Token: 0x060006B5 RID: 1717 RVA: 0x000E7F00 File Offset: 0x000E6100
        internal virtual void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            bool flag = this._AMJ() != null;
            if (flag)
            {
                this._AMJ().Resolve(leaf, numTypeArgs, asTypeOnly);
            }
        }

        // Token: 0x060006B6 RID: 1718 RVA: 0x000E7F34 File Offset: 0x000E6134
        internal virtual void ResolveAttribute(_bb4.DHBA leaf)
        {
            leaf._ACY(null);
            leaf._AJF = null;
            bool flag = this._AMJ() != null;
            if (flag)
            {
                this._AMJ().ResolveAttribute(leaf);
            }
        }

        // Token: 0x060006B7 RID: 1719 RVA: 0x000E7F6C File Offset: 0x000E616C
        public _bh4 ResolveAsImportedStaticMethod(_bb4.DHBA invokedLeaf, _bh4 invokedSymbol, _bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 context)
        {
            bool flag = invokedLeaf == null && (invokedSymbol == null || invokedSymbol._AT == SymbolKind.Error);
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                string text = ((invokedSymbol != null && invokedSymbol._AT != SymbolKind.Error) ? invokedSymbol._AW : ((invokedLeaf != null) ? _bh4.DecodeId(invokedLeaf._ACX.text) : ""));
                _AAH = this.ResolveAsImportedStaticMethod(text, argumentListNode, typeArgs, context, invokedLeaf);
            }
            return _AAH;
        }

        // Token: 0x060006B8 RID: 1720 RVA: 0x000E7FD8 File Offset: 0x000E61D8
        internal virtual _bh4 ResolveAsImportedStaticMethod(string id, _bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 context, _bb4.DHBA invokedLeaf = null)
        {
            return (this._AMJ() != null) ? this._AMJ().ResolveAsImportedStaticMethod(id, argumentListNode, typeArgs, context, invokedLeaf) : null;
        }

        // Token: 0x060006B9 RID: 1721 RVA: 0x000E8008 File Offset: 0x000E6208
        public _bh4 ResolveAsExtensionMethod(_bb4.DHBA invokedLeaf, _bh4 invokedSymbol, _b2 memberOf, _bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 context)
        {
            bool flag = invokedLeaf == null && (invokedSymbol == null || invokedSymbol._AT == SymbolKind.Error);
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                string text = ((invokedSymbol != null && invokedSymbol._AT != SymbolKind.Error) ? invokedSymbol._AW : ((invokedLeaf != null) ? _bh4.DecodeId(invokedLeaf._ACX.text) : ""));
                _AAH = this.ResolveAsExtensionMethod(text, memberOf, argumentListNode, typeArgs, context, invokedLeaf);
            }
            return _AAH;
        }

        // Token: 0x060006BA RID: 1722 RVA: 0x000E8078 File Offset: 0x000E6278
        internal virtual _bh4 ResolveAsExtensionMethod(string id, _b2 memberOf, _bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 context, _bb4.DHBA invokedLeaf = null)
        {
            return (this._AMJ() != null) ? this._AMJ().ResolveAsExtensionMethod(id, memberOf, argumentListNode, typeArgs, context, invokedLeaf) : null;
        }

        // Token: 0x060006BB RID: 1723
        internal abstract _bh4 FindName(string symbolName, int numTypeParameters);

        // Token: 0x060006BC RID: 1724 RVA: 0x000E80AC File Offset: 0x000E62AC
        internal virtual void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            bool flag = this._AMJ() != null;
            if (flag)
            {
                this._AMJ().GetCompletionData(data, context);
            }
        }

        // Token: 0x060006BD RID: 1725 RVA: 0x000E80D8 File Offset: 0x000E62D8
        internal virtual _bc6 EnclosingType()
        {
            return (this._AMJ() != null) ? this._AMJ().EnclosingType() : null;
        }

        // Token: 0x060006BE RID: 1726 RVA: 0x000E8100 File Offset: 0x000E6300
        public _bc8 EnclosingNamespaceScope()
        {
            for (_bm6 _AQI = this._AMJ(); _AQI != null; _AQI = _AQI._AMJ())
            {
                _bc8 _APS = _AQI as _bc8;
                bool flag = _APS != null;
                if (flag)
                {
                    return _APS;
                }
            }
            return null;
        }

        // Token: 0x060006BF RID: 1727 RVA: 0x000E8144 File Offset: 0x000E6344
        internal virtual void GetExtensionMethodsCompletionData(_b2 forType, Dictionary<string, _bh4> data)
        {
            bool flag = this._AMJ() != null;
            if (flag)
            {
                this._AMJ().GetExtensionMethodsCompletionData(forType, data);
            }
        }

        // Token: 0x060006C0 RID: 1728 RVA: 0x000E816D File Offset: 0x000E636D
        internal virtual IEnumerable<_bn1> VisibleNamespacesInScope()
        {
            bool flag = this._AMJ() != null;
            if (flag)
            {
                foreach (_bn1 ns in this._AMJ().VisibleNamespacesInScope())
                {
                    yield return ns;
                }
            }
            yield break;
        }

        // Token: 0x040005A4 RID: 1444
        public static _bb4._AIN _AML;

        // Token: 0x040005A5 RID: 1445
        public static string _AMM;

        // Token: 0x040005A6 RID: 1446
        public static int _AQD;

        // Token: 0x040005A7 RID: 1447
        public static int _AQE;

        // Token: 0x040005A8 RID: 1448
        protected _bb4._ACW _AEJ;

        // Token: 0x040005A9 RID: 1449
        public _bm6 _zd5;
    }
}
