using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000D8 RID: 216
    internal abstract class _b2 : _bh4
    {
        // Token: 0x0600064D RID: 1613 RVA: 0x000E467C File Offset: 0x000E287C
        protected static bool InvalidSymbolReference(KJK x)
        {
            return !x.IsValid();
        }

        // Token: 0x0600064E RID: 1614 RVA: 0x000E4698 File Offset: 0x000E2898
        internal override Type GetRuntimeType()
        {
            bool flag = base.Assembly == null || base.Assembly._AN == null;
            Type type;
            if (flag)
            {
                type = null;
            }
            else
            {
                bool flag2 = this._AO is _b2;
                if (flag2)
                {
                    Type runtimeType = this._AO.GetRuntimeType();
                    bool flag3 = runtimeType == null;
                    if (flag3)
                    {
                        type = null;
                    }
                    else
                    {
                        Type nestedType = runtimeType.GetNestedType(base._AP(), BindingFlags.Public | BindingFlags.NonPublic);
                        type = nestedType;
                    }
                }
                else
                {
                    type = base.Assembly._AN.GetType(base._AQ());
                }
            }
            return type;
        }

        // Token: 0x0600064F RID: 1615 RVA: 0x000E472C File Offset: 0x000E292C
        internal override _bh4 TypeOf()
        {
            return this;
        }

        // Token: 0x06000650 RID: 1616 RVA: 0x000E4740 File Offset: 0x000E2940
        internal override _b2 SubstituteTypeParameters(_bh4 context)
        {
            return this;
        }

        // Token: 0x06000651 RID: 1617 RVA: 0x00014488 File Offset: 0x00012688
        internal virtual void InvalidateBaseType()
        {
        }

        // Token: 0x06000652 RID: 1618 RVA: 0x000E4754 File Offset: 0x000E2954
        internal virtual List<KJK> Interfaces()
        {
            return _bh4._AR;
        }

        // Token: 0x06000653 RID: 1619 RVA: 0x000E476C File Offset: 0x000E296C
        internal virtual _b2 BaseType()
        {
            return (this == _bh4._AS) ? null : _bh4._AS;
        }

        // Token: 0x06000654 RID: 1620 RVA: 0x000E4790 File Offset: 0x000E2990
        protected virtual string RankString()
        {
            return string.Empty;
        }

        // Token: 0x06000655 RID: 1621 RVA: 0x000E47A8 File Offset: 0x000E29A8
        internal virtual _bb3 GetDefaultConstructor()
        {
            bool flag = this._AI == null;
            if (flag)
            {
                this._AI = new _bb3
                {
                    _AT = SymbolKind.Constructor,
                    _AO = this,
                    _AW = ".ctor",
                    _AU = this._AU,
                    _AV = (this._AV & (Modifiers.Public | Modifiers.Internal | Modifiers.Protected))
                };
            }
            return this._AI;
        }

        // Token: 0x06000656 RID: 1622 RVA: 0x000E4810 File Offset: 0x000E2A10
        public _bm8 MakeArrayType(int arrayRank)
        {
            bool flag = this._AJ == null;
            if (flag)
            {
                this._AJ = new Dictionary<int, _bm8>();
            }
            _bm8 _AX;
            bool flag2 = !this._AJ.TryGetValue(arrayRank, out _AX);
            if (flag2)
            {
                _AX = (this._AJ[arrayRank] = new _bm8(this, arrayRank));
            }
            return _AX;
        }

        // Token: 0x06000657 RID: 1623 RVA: 0x000E4868 File Offset: 0x000E2A68
        public _bc6 MakeNullableType()
        {
            bool flag = this._AK == null;
            if (flag)
            {
                this._AK = _bh4._AY.ConstructType(new KJK[]
                {
                    new KJK(this)
                });
            }
            return this._AK;
        }

        // Token: 0x06000658 RID: 1624 RVA: 0x000E48B0 File Offset: 0x000E2AB0
        public _bh4 GetThisInstance()
        {
            _bc7 _AZ = this._AE as _bc7;
            bool flag = _AZ == null || !_AZ.IsValid();
            if (flag)
            {
                bool isStatic = this.IsStatic;
                if (isStatic)
                {
                    return this._AE = _bh4._AAA;
                }
                this._AE = new _bc7(this);
            }
            return this._AE;
        }

        // Token: 0x06000659 RID: 1625 RVA: 0x000E4914 File Offset: 0x000E2B14
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            base.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
            bool flag = !this._AL && leaf._AAB() == null;
            if (flag)
            {
                this._AL = true;
                _b2 _AAC = this.BaseType();
                List<KJK> list = this.Interfaces();
                bool flag2 = !asTypeOnly && list != null && (this._AT == SymbolKind.Interface || this._AT == SymbolKind.TypeParameter);
                if (flag2)
                {
                    int count = list.Count;
                    while (count-- > 0)
                    {
                        KJK _AAD = list[count];
                        _AAD.definition.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
                        bool flag3 = leaf._AAB() != null;
                        if (flag3)
                        {
                            this._AL = false;
                            return;
                        }
                    }
                }
                bool flag4 = _AAC != null && _AAC != this;
                if (flag4)
                {
                    _AAC.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
                }
                this._AL = false;
            }
        }

        // Token: 0x0600065A RID: 1626 RVA: 0x000E4A00 File Offset: 0x000E2C00
        internal virtual bool DerivesFrom(_b2 otherType)
        {
            bool flag = otherType == null;
            return !flag && this.DerivesFromRef(ref otherType);
        }

        // Token: 0x0600065B RID: 1627 RVA: 0x000E4A28 File Offset: 0x000E2C28
        internal virtual bool DerivesFromRef(ref _b2 otherType)
        {
            bool flag = otherType == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                _bi5 _AAE = otherType as _bi5;
                bool flag3 = _AAE != null;
                if (flag3)
                {
                    otherType = _AAE._AAF();
                }
                bool flag4 = this == otherType;
                if (flag4)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag5 = this.BaseType() != null;
                    flag2 = flag5 && this.BaseType().DerivesFromRef(ref otherType);
                }
            }
            return flag2;
        }

        // Token: 0x0600065C RID: 1628 RVA: 0x000E4A90 File Offset: 0x000E2C90
        protected override _bh4 GetIndexer(_b2[] argumentTypes)
        {
            List<_bh4> allIndexers = this.GetAllIndexers();
            return (allIndexers != null) ? allIndexers[0] : null;
        }

        // Token: 0x0600065D RID: 1629 RVA: 0x000E4AB8 File Offset: 0x000E2CB8
        internal virtual List<_bh4> GetAllIndexers()
        {
            List<_bh4> list = null;
            for (int i = 0; i < this._AAG.Count; i++)
            {
                _bh4 _AAH = this._AAG._AAI(i);
                bool flag = _AAH._AT == SymbolKind.Indexer;
                if (flag)
                {
                    bool flag2 = list == null;
                    if (flag2)
                    {
                        list = new List<_bh4>();
                    }
                    list.Add(_AAH);
                }
            }
            return list;
        }

        // Token: 0x0600065E RID: 1630 RVA: 0x000E4B24 File Offset: 0x000E2D24
        public void ListOverrideCandidates(List<_bb3> methods, _bj5 context)
        {
            bool _AAJ = this._AM;
            if (!_AAJ)
            {
                this._AM = true;
                _b2 _AAC = this.BaseType();
                bool flag = _AAC != null && (_AAC._AT == SymbolKind.Class || _AAC._AT == SymbolKind.Struct);
                if (flag)
                {
                    _AAC.ListOverrideCandidates(methods, context);
                }
                this._AM = false;
                AccessLevelMask accessLevelMask = AccessLevelMask.Protected | AccessLevelMask.Public;
                bool flag2 = base.Assembly.InternalsVisibleIn(context);
                if (flag2)
                {
                    accessLevelMask |= AccessLevelMask.Internal;
                }
                int num = this._AAG.Count;
                while (num-- > 0)
                {
                    _bh4 _AAH = this._AAG._AAI(num);
                    bool flag3 = _AAH._AT == SymbolKind.MethodGroup;
                    if (flag3)
                    {
                        _ba7 _AAK = _AAH as _ba7;
                        bool flag4 = _AAK != null;
                        if (flag4)
                        {
                            List<_bb3> _AAL = _AAK._AAM;
                            int count = _AAL.Count;
                            while (count-- > 0)
                            {
                                _bb3 _AAN = _AAL[count];
                                bool flag5 = (_AAN._AAO() || _AAN._AAP()) && _AAN.IsAccessible(accessLevelMask);
                                if (flag5)
                                {
                                    methods.Add(_AAN);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600065F RID: 1631 RVA: 0x000E4C55 File Offset: 0x000E2E55
        public void GetCompletionDataFromImportedType(Dictionary<string, _bh4> data, AccessLevelMask mask, _be4 context)
        {
            this._AM = true;
            this.GetCompletionData(data, context);
            this._AM = false;
        }

        // Token: 0x06000660 RID: 1632 RVA: 0x000E4C70 File Offset: 0x000E2E70
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            base.GetMembersCompletionData(data, flags, mask, context);
            bool _AAJ = this._AM;
            if (!_AAJ)
            {
                this._AM = true;
                _b2 _AAC = this.BaseType();
                List<KJK> list = this.Interfaces();
                bool flag = flags != BindingFlags.Static && (this._AT == SymbolKind.Interface || this._AT == SymbolKind.TypeParameter);
                if (flag)
                {
                    foreach (KJK _AAD in list)
                    {
                        _AAD.definition.GetMembersCompletionData(data, flags, mask & ~AccessLevelMask.Private, context);
                    }
                }
                bool flag2 = _AAC != null && (this._AT != SymbolKind.Enum || flags != BindingFlags.Static) && (_AAC._AT != SymbolKind.Interface || this._AT == SymbolKind.Interface || this._AT == SymbolKind.TypeParameter);
                if (flag2)
                {
                    _AAC.GetMembersCompletionData(data, flags, mask & ~AccessLevelMask.Private, context);
                }
                this._AM = false;
            }
        }

        // Token: 0x06000661 RID: 1633 RVA: 0x000E4D78 File Offset: 0x000E2F78
        internal virtual _b2 BindTypeArgument(_b2 typeArgument, _b2 argumentType)
        {
            return null;
        }

        // Token: 0x06000662 RID: 1634 RVA: 0x000E4D8C File Offset: 0x000E2F8C
        internal virtual bool CanConvertTo(_b2 otherType)
        {
            bool flag = this.ConvertTo(otherType) != null;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = this.HasImplicitConversionOperatorTo(otherType);
                if (flag3)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag4 = otherType.HasImplicitConversionOperatorFrom(this);
                    flag2 = flag4;
                }
            }
            return flag2;
        }

        // Token: 0x06000663 RID: 1635 RVA: 0x000E4DD0 File Offset: 0x000E2FD0
        internal virtual _b2 ConvertTo(_b2 otherType)
        {
            bool flag = otherType == null;
            _b2 _AAC;
            if (flag)
            {
                _AAC = null;
            }
            else
            {
                bool flag2 = otherType == this;
                if (flag2)
                {
                    _AAC = this;
                }
                else
                {
                    bool flag3 = otherType is _bd7;
                    if (flag3)
                    {
                        _AAC = this;
                    }
                    else
                    {
                        bool flag4 = otherType == _bh4._AS;
                        if (flag4)
                        {
                            _AAC = otherType;
                        }
                        else
                        {
                            bool flag5 = this == _bh4._AAQ && (otherType == _bh4._AAR || otherType == _bh4._AAS || otherType == _bh4._AAT);
                            if (flag5)
                            {
                                _AAC = otherType;
                            }
                            else
                            {
                                bool flag6 = this == _bh4._AAU && (otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                if (flag6)
                                {
                                    _AAC = otherType;
                                }
                                else
                                {
                                    bool flag7 = this == _bh4._AAW && (otherType == _bh4._AAX || otherType == _bh4._AAY || otherType == _bh4._AAQ || otherType == _bh4._AAU || otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                    if (flag7)
                                    {
                                        _AAC = otherType;
                                    }
                                    else
                                    {
                                        bool flag8 = this == _bh4._AAZ && (otherType == _bh4._AAX || otherType == _bh4._AAQ || otherType == _bh4._AAR || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                        if (flag8)
                                        {
                                            _AAC = otherType;
                                        }
                                        else
                                        {
                                            bool flag9 = this == _bh4._AAX && (otherType == _bh4._AAQ || otherType == _bh4._AAR || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                            if (flag9)
                                            {
                                                _AAC = otherType;
                                            }
                                            else
                                            {
                                                bool flag10 = this == _bh4._AAY && (otherType == _bh4._AAQ || otherType == _bh4._AAU || otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                                if (flag10)
                                                {
                                                    _AAC = otherType;
                                                }
                                                else
                                                {
                                                    bool flag11 = (this == _bh4._AAR || this == _bh4._AAV) && (otherType == _bh4._AAS || otherType == _bh4._AAT);
                                                    if (flag11)
                                                    {
                                                        _AAC = otherType;
                                                    }
                                                    else
                                                    {
                                                        bool flag12 = this == _bh4._AAS && otherType == _bh4._AAT;
                                                        if (flag12)
                                                        {
                                                            _AAC = otherType;
                                                        }
                                                        else
                                                        {
                                                            bool flag13 = this == _bh4._ABA && (otherType == _bh4._AAY || otherType == _bh4._AAQ || otherType == _bh4._AAU || otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                                            if (flag13)
                                                            {
                                                                _AAC = otherType;
                                                            }
                                                            else
                                                            {
                                                                bool flag14 = this.DerivesFromRef(ref otherType);
                                                                if (flag14)
                                                                {
                                                                    _AAC = otherType;
                                                                }
                                                                else
                                                                {
                                                                    _AAC = null;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return _AAC;
        }

        // Token: 0x06000664 RID: 1636 RVA: 0x000E5070 File Offset: 0x000E3270
        public bool HasImplicitConversionOperatorTo(_b2 otherType)
        {
            _ba7 _AAK = this.FindName("op_Implicit", 0, false) as _ba7;
            bool flag = _AAK == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                List<_bb3> _AAL = _AAK._AAM;
                int count = _AAL.Count;
                bool flag3 = count > 0;
                if (flag3)
                {
                    int num = count;
                    while (num-- > 0)
                    {
                        _bb3 _AAN = _AAL[num];
                        _b2 _AAC = _AAN.ReturnType();
                        bool flag4 = _AAC != null && _AAC.IsSameType(otherType);
                        if (flag4)
                        {
                            return true;
                        }
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x06000665 RID: 1637 RVA: 0x000E5104 File Offset: 0x000E3304
        public bool HasImplicitConversionOperatorFrom(_b2 otherType)
        {
            _ba7 _AAK = this.FindName("op_Implicit", 0, false) as _ba7;
            bool flag = _AAK == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                List<_bb3> _AAL = _AAK._AAM;
                int count = _AAL.Count;
                bool flag3 = count > 0;
                if (flag3)
                {
                    int num = count;
                    while (num-- > 0)
                    {
                        _bb3 _AAN = _AAL[num];
                        List<_bm1> parameters = _AAN.GetParameters();
                        bool flag4 = parameters.Count != 1;
                        if (!flag4)
                        {
                            _bh4 _AAH = parameters[0].TypeOf();
                            bool flag5 = _AAH != null && _AAH.IsSameType(otherType);
                            if (flag5)
                            {
                                return true;
                            }
                        }
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x06000666 RID: 1638 RVA: 0x000E51C0 File Offset: 0x000E33C0
        public _bb3 FindMethod(string name, int numTypeParams, int numParams, bool onlyNonStatic)
        {
            _bh4 _AAH = this.FindName(name, numTypeParams, false);
            bool flag = _AAH == null;
            _bb3 _AAN;
            if (flag)
            {
                _AAN = null;
            }
            else
            {
                bool flag2 = _AAH._AT != SymbolKind.MethodGroup;
                if (flag2)
                {
                    _AAN = null;
                }
                else
                {
                    _ba7 _AAK = _AAH as _ba7;
                    bool flag3 = _AAK != null;
                    List<_bb3> list;
                    if (flag3)
                    {
                        bool flag4 = _AAK.IsStatic && onlyNonStatic;
                        if (flag4)
                        {
                            return null;
                        }
                        list = _AAK._AAM;
                    }
                    else
                    {
                        _bd1 _ABB = _AAH as _bd1;
                        bool flag5 = _ABB == null;
                        if (flag5)
                        {
                            return null;
                        }
                        bool flag6 = _ABB.IsStatic && onlyNonStatic;
                        if (flag6)
                        {
                            return null;
                        }
                        list = _ABB._AAM;
                    }
                    _bb3 _AAN2 = list.Find((_bb3 x) => x._ABC() == numParams);
                    _AAN = _AAN2;
                }
            }
            return _AAN;
        }

        // Token: 0x04000582 RID: 1410
        private _bh4 _AE;

        // Token: 0x04000583 RID: 1411
        public int _AF;

        // Token: 0x04000584 RID: 1412
        protected bool _AG;

        // Token: 0x04000585 RID: 1413
        protected static Predicate<KJK> _AH = new Predicate<KJK>(_b2.InvalidSymbolReference);

        // Token: 0x04000586 RID: 1414
        protected _bb3 _AI;

        // Token: 0x04000587 RID: 1415
        private Dictionary<int, _bm8> _AJ;

        // Token: 0x04000588 RID: 1416
        private _bc6 _AK;

        // Token: 0x04000589 RID: 1417
        private bool _AL = false;

        // Token: 0x0400058A RID: 1418
        private bool _AM = false;
    }
}
