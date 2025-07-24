using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000E3 RID: 227
    internal class _bc8 : _bm6
    {
        // Token: 0x06000697 RID: 1687 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public _bc8(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x06000698 RID: 1688 RVA: 0x000E6507 File Offset: 0x000E4707
        internal override IEnumerable<_bn1> VisibleNamespacesInScope()
        {
            yield return this._ACV;
            foreach (KJK nsRef in this.EFI._APL)
            {
                _bn1 ns = nsRef.definition as _bn1;
                bool flag = ns != null;
                if (flag)
                {
                    yield return ns;
                }
            }
            List<KJK>.Enumerator enumerator = default(List<KJK>.Enumerator);
            bool flag2 = base._AMJ() != null;
            if (flag2)
            {
                foreach (_bn1 ns2 in base._AMJ().VisibleNamespacesInScope())
                {
                    yield return ns2;
                }
                IEnumerator<_bn1> enumerator2 = null;
            }
            yield break;
        }

        // Token: 0x06000699 RID: 1689 RVA: 0x000E6518 File Offset: 0x000E4718
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = this._ACV == null;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                symbol._AJW = this;
                bool flag2 = symbol._AT == SymbolKind.Class || symbol._AT == SymbolKind.Struct || symbol._AT == SymbolKind.Interface || symbol._AT == SymbolKind.Enum || symbol._AT == SymbolKind.Delegate;
                if (flag2)
                {
                    bool flag3 = this._APM == null;
                    if (flag3)
                    {
                        this._APM = new List<FKI>();
                    }
                    this._APM.Add(symbol);
                }
                bool flag4 = symbol._AT == SymbolKind.ImportedNamespace;
                if (flag4)
                {
                    this.EFI._APL.Add(new KJK(symbol._AEJ.ChildAt(0)));
                    _AAH = null;
                }
                else
                {
                    bool flag5 = symbol._AT == SymbolKind.ImportedStaticType;
                    if (flag5)
                    {
                        bool flag6 = symbol._AEJ._AIX >= 2;
                        if (flag6)
                        {
                            this.EFI._APN.Add(new KJK(symbol._AEJ.ChildAt(1)));
                        }
                        _AAH = null;
                    }
                    else
                    {
                        bool flag7 = symbol._AT == SymbolKind.TypeAlias;
                        if (flag7)
                        {
                            this.EFI._APO.Add(new TypeAlias
                            {
                                _AW = symbol._AEJ.ChildAt(0).Print(),
                                BLH = new KJK(symbol._AEJ.ChildAt(2)),
                                EFI = symbol
                            });
                            _AAH = null;
                        }
                        else
                        {
                            _AAH = this._ACV.AddDeclaration(symbol);
                        }
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x0600069A RID: 1690 RVA: 0x000E66A0 File Offset: 0x000E48A0
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = this._APM != null;
            if (flag)
            {
                this._APM.Remove(symbol);
            }
            bool flag2 = symbol._AT == SymbolKind.ImportedNamespace;
            if (flag2)
            {
                _bb4._ACW _APQ = symbol._AEJ;
                int count = this.EFI._APL.Count;
                while (count-- > 0)
                {
                    _bb4._AIN _AIO = this.EFI._APL[count]._APP();
                    bool flag3 = _AIO != null && _AIO.OOME == _APQ;
                    if (flag3)
                    {
                        this.EFI._APL.RemoveAt(count);
                        break;
                    }
                }
            }
            else
            {
                bool flag4 = symbol._AT == SymbolKind.ImportedStaticType;
                if (flag4)
                {
                    _bb4._ACW _APQ2 = symbol._AEJ;
                    int count2 = this.EFI._APN.Count;
                    while (count2-- > 0)
                    {
                        _bb4._AIN _AIO2 = this.EFI._APN[count2]._APP();
                        bool flag5 = _AIO2 != null && _AIO2.OOME == _APQ2;
                        if (flag5)
                        {
                            this.EFI._APN.RemoveAt(count2);
                            break;
                        }
                    }
                }
                else
                {
                    bool flag6 = symbol._AT == SymbolKind.TypeAlias;
                    if (flag6)
                    {
                        int count3 = this.EFI._APO.Count;
                        while (count3-- > 0)
                        {
                            TypeAlias typeAlias = this.EFI._APO[count3];
                            bool flag7 = typeAlias.EFI == symbol;
                            if (flag7)
                            {
                                this.EFI._APO.RemoveAt(count3);
                                break;
                            }
                        }
                    }
                    else
                    {
                        bool flag8 = this._ACV != null;
                        if (flag8)
                        {
                            this._ACV.RemoveDeclaration(symbol);
                        }
                    }
                }
            }
        }

        // Token: 0x0600069B RID: 1691 RVA: 0x000E686C File Offset: 0x000E4A6C
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            bool flag = this.EFI == null;
            if (!flag)
            {
                string text = _bh4.DecodeId(leaf._ACX.text);
                int count = this.EFI._APO.Count;
                while (count-- > 0)
                {
                    bool flag2 = this.EFI._APO[count]._AW == text;
                    if (flag2)
                    {
                        bool flag3 = this.EFI._APO[count].BLH != null;
                        if (flag3)
                        {
                            leaf._ACY(this.EFI._APO[count].BLH.definition);
                            return;
                        }
                        break;
                    }
                }
                bool flag4 = leaf._AAB() == null;
                if (flag4)
                {
                    this._ACV.ResolveMember(leaf, this, numTypeArgs, true);
                }
                bool flag5 = leaf._AAB() == null;
                if (flag5)
                {
                    int count2 = this.EFI._APL.Count;
                    while (count2-- > 0)
                    {
                        KJK _AAD = this.EFI._APL[count2];
                        bool flag6 = _AAD.IsBefore(leaf) && _AAD.definition != null;
                        if (flag6)
                        {
                            _AAD.definition.ResolveMember(leaf, this, numTypeArgs, true);
                            bool flag7 = leaf._AAB() != null;
                            if (flag7)
                            {
                                bool flag8 = leaf._AAB()._AT == SymbolKind.Namespace;
                                if (!flag8)
                                {
                                    break;
                                }
                                leaf._ACY(null);
                            }
                        }
                    }
                }
                bool flag9 = leaf._AAB() == null;
                if (flag9)
                {
                    bool flag10 = leaf.OOME._AHB() == "primaryExpressionStart";
                    if (flag10)
                    {
                        _bb4._ACW _AGZ = leaf.OOME._AIZ as _bb4._ACW;
                        bool flag11 = _AGZ != null && _AGZ._AHB() == "primaryExpressionPart";
                        if (flag11)
                        {
                            _bb4._ACW _AGZ2 = _AGZ.FindChildByName("arguments", "argumentList") as _bb4._ACW;
                            bool flag12 = _AGZ2 != null;
                            if (flag12)
                            {
                                KJK[] array = null;
                                _bb4._ACW _AGZ3 = leaf.OOME.NodeAt(1);
                                bool flag13 = _AGZ3 != null && _AGZ3._AHB() == "typeArgumentList";
                                if (flag13)
                                {
                                    int num = (int)(_AGZ3._AIX / 2);
                                    array = new KJK[num];
                                    for (int i = 0; i < num; i++)
                                    {
                                        array[i] = new KJK(_AGZ3.ChildAt(1 + 2 * i));
                                    }
                                }
                                base.ResolveAsImportedStaticMethod(leaf, null, _AGZ2, array, this);
                            }
                        }
                    }
                    bool flag14 = leaf._AAB() == null;
                    if (flag14)
                    {
                        int count3 = this.EFI._APN.Count;
                        while (count3-- > 0)
                        {
                            KJK _AAD2 = this.EFI._APN[count3];
                            _b2 _AAC = _AAD2.definition as _b2;
                            bool flag15 = _AAC == null;
                            if (!flag15)
                            {
                                _AAC.ResolveMember(leaf, this, numTypeArgs, false);
                                bool flag16 = leaf._AAB() == null;
                                if (!flag16)
                                {
                                    bool flag17 = leaf._AAB()._AO == _AAC;
                                    if (flag17)
                                    {
                                        bool flag18 = leaf._AAB() is _b2;
                                        if (flag18)
                                        {
                                            break;
                                        }
                                        bool isStatic = leaf._AAB().IsStatic;
                                        if (isStatic)
                                        {
                                            break;
                                        }
                                    }
                                    leaf._ACY(null);
                                }
                            }
                        }
                    }
                }
                _bn1 _APR = ((base._AMJ() != null) ? ((_bc8)base._AMJ())._ACV : null);
                _bn1 _APR2 = this._ACV._AO as _bn1;
                while (leaf._AAB() == null && _APR2 != null && _APR2 != _APR)
                {
                    _APR2.ResolveMember(leaf, this, numTypeArgs, true);
                    _APR2 = _APR2._AO as _bn1;
                }
                bool flag19 = leaf._AAB() == null && base._AMJ() != null;
                if (flag19)
                {
                    base._AMJ().Resolve(leaf, numTypeArgs, true);
                }
            }
        }

        // Token: 0x0600069C RID: 1692 RVA: 0x000E6C80 File Offset: 0x000E4E80
        internal override void ResolveAttribute(_bb4.DHBA leaf)
        {
            leaf._ACY(null);
            leaf._AJF = null;
            string text = _bh4.DecodeId(leaf._ACX.text);
            int count = this.EFI._APO.Count;
            while (count-- > 0)
            {
                bool flag = this.EFI._APO[count]._AW == text;
                if (flag)
                {
                    bool flag2 = this.EFI._APO[count].BLH != null;
                    if (flag2)
                    {
                        leaf._ACY(this.EFI._APO[count].BLH.definition);
                        return;
                    }
                    break;
                }
            }
            _bn1 _APR = ((base._AMJ() != null) ? ((_bc8)base._AMJ())._ACV : null);
            _bn1 _APR2 = this._ACV;
            while (leaf._AAB() == null && _APR2 != null && _APR2 != _APR)
            {
                _APR2.ResolveAttributeMember(leaf, this);
                _APR2 = _APR2._AO as _bn1;
            }
            bool flag3 = leaf._AAB() == null;
            if (flag3)
            {
                foreach (KJK _AAD in this.EFI._APL)
                {
                    bool flag4 = _AAD.IsBefore(leaf) && _AAD.definition != null;
                    if (flag4)
                    {
                        _AAD.definition.ResolveAttributeMember(leaf, this);
                        bool flag5 = leaf._AAB() != null;
                        if (flag5)
                        {
                            break;
                        }
                    }
                }
            }
            bool flag6 = leaf._AAB() == null && base._AMJ() != null;
            if (flag6)
            {
                base._AMJ().ResolveAttribute(leaf);
                return;
            }
        }

        // Token: 0x0600069D RID: 1693 RVA: 0x000E6E5C File Offset: 0x000E505C
        public void CollectImportedStaticMethods(string id, KJK[] typeArgs, _bm6 context, HashSet<_bb3> methods)
        {
            int num = ((typeArgs == null) ? (-1) : typeArgs.Length);
            _bj5 assembly = context.GetAssembly();
            int count = this.EFI._APN.Count;
            while (count-- > 0)
            {
                _bh4 definition = this.EFI._APN[count].definition;
                bool flag = definition == null || (definition._AT != SymbolKind.Class && definition._AT != SymbolKind.Struct) || !definition.IsValid();
                if (!flag)
                {
                    AccessLevelMask accessLevelMask = AccessLevelMask.Public;
                    bool flag2 = definition.Assembly != null && definition.Assembly.InternalsVisibleIn(assembly);
                    if (flag2)
                    {
                        accessLevelMask |= AccessLevelMask.Internal;
                    }
                    bool flag3 = !definition.IsAccessible(accessLevelMask);
                    if (!flag3)
                    {
                        _bh4 _AAH;
                        bool flag4 = !definition._AAG.TryGetValue(id, num, out _AAH);
                        if (!flag4)
                        {
                            bool flag5 = _AAH._AT != SymbolKind.MethodGroup;
                            if (!flag5)
                            {
                                _ba7 _AAK = _AAH as _ba7;
                                bool flag6 = _AAK == null;
                                if (flag6)
                                {
                                    Debug.LogError("Expected a method group: " + _AAH.GetTooltipText());
                                }
                                else
                                {
                                    foreach (_bb3 _AAN in _AAK._AAM)
                                    {
                                        bool flag7 = _AAN.IsExtensionMethod || !_AAN.IsStatic || !_AAN.IsAccessible(accessLevelMask);
                                        if (!flag7)
                                        {
                                            bool flag8 = num > 0;
                                            if (flag8)
                                            {
                                                _bl4 _AIQ = _AAN.ConstructMethod(typeArgs);
                                                methods.Add(_AIQ);
                                            }
                                            else
                                            {
                                                methods.Add(_AAN);
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

        // Token: 0x0600069E RID: 1694 RVA: 0x000E7028 File Offset: 0x000E5228
        internal override _bh4 ResolveAsImportedStaticMethod(string id, _bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 context, _bb4.DHBA invokedLeaf = null)
        {
            _bb3 _AAN = null;
            HashSet<_bb3> hashSet = new HashSet<_bb3>();
            _bb3 _AAN2 = null;
            int num = 0;
            int count = _ba7._AGV.Count;
            for (_bc8 _APS = this; _APS != null; _APS = _APS._AMJ() as _bc8)
            {
                this.CollectImportedStaticMethods(id, typeArgs, context, hashSet);
                bool flag = hashSet.Count == 0;
                if (!flag)
                {
                    _AAN = hashSet.First<_bb3>();
                    bool flag2 = num == 0;
                    if (flag2)
                    {
                        num = _ba7.ProcessArgumentListNode(argumentListNode, null);
                        _AAN2 = _ba7.CheckNamedArguments(num);
                    }
                    _bb3 _AAN3 = _AAN2;
                    bool flag3 = _AAN3 == null;
                    if (flag3)
                    {
                        List<_bb3> _APT = _ba7._AHE;
                        int count2 = _APT.Count;
                        foreach (_bb3 _AAN4 in hashSet)
                        {
                            bool flag4 = num == 0 || _AAN4.CanCallWith(num, false);
                            if (flag4)
                            {
                                _APT.Add(_AAN4);
                            }
                        }
                        int num2 = _APT.Count - count2;
                        bool flag5 = typeArgs == null;
                        if (flag5)
                        {
                            int num3 = num2;
                            while (num3-- > 0)
                            {
                                _bb3 _AAN5 = _APT[count2 + num3];
                                bool flag6 = _AAN5._AHG() == 0 || num == 0;
                                if (!flag6)
                                {
                                    _AAN5 = _ba7.InferMethodTypeArguments(_AAN5, num, invokedLeaf);
                                    bool flag7 = _AAN5 == null;
                                    if (flag7)
                                    {
                                        _APT.RemoveAt(count2 + num3);
                                    }
                                    else
                                    {
                                        _APT[count2 + num3] = _AAN5;
                                    }
                                }
                            }
                        }
                        num2 = _APT.Count - count2;
                        _AAN3 = _ba7.ResolveMethodOverloads(num, num2);
                        _APT.RemoveRange(count2, num2);
                    }
                    bool flag8 = _AAN3 != null && _AAN3._AT != SymbolKind.Error;
                    if (flag8)
                    {
                        _ba7._AGV.RemoveRange(count, num);
                        _ba7._AGW.RemoveRange(count, num);
                        _ba7._AGX.RemoveRange(count, num);
                        _ba7._AGY.RemoveRange(count, num);
                        bool flag9 = invokedLeaf != null;
                        if (flag9)
                        {
                            invokedLeaf._ACY(_AAN3);
                        }
                        return _AAN3;
                    }
                    hashSet.Clear();
                }
            }
            _ba7._AGV.RemoveRange(count, num);
            _ba7._AGW.RemoveRange(count, num);
            _ba7._AGX.RemoveRange(count, num);
            _ba7._AGY.RemoveRange(count, num);
            bool flag10 = _AAN != null && invokedLeaf != null;
            if (flag10)
            {
                invokedLeaf._ACY(_AAN);
                invokedLeaf._AJF = _ba7._AHN._AW;
            }
            return null;
        }

        // Token: 0x0600069F RID: 1695 RVA: 0x000E72C8 File Offset: 0x000E54C8
        internal override _bh4 ResolveAsExtensionMethod(string id, _b2 memberOf, _bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 context, _bb4.DHBA invokedLeaf = null)
        {
            _bb3 _AAN = null;
            _bj5 assembly = base.GetAssembly();
            HashSet<_bb3> hashSet = new HashSet<_bb3>();
            _bb3 _AAN2 = null;
            int num = 0;
            int count = _ba7._AGV.Count;
            _bc8 _APS = base._AMJ() as _bc8;
            _bn1 _APR = ((_APS != null) ? _APS._ACV : null);
            _bn1 _APR2 = this._ACV;
            while (_APR2 != null && _APR2 != _APR)
            {
                assembly.CollectExtensionMethods(_APR2, id, typeArgs, memberOf, hashSet, context);
                bool flag = hashSet.Count > 0;
                if (flag)
                {
                    _AAN = hashSet.First<_bb3>();
                    bool flag2 = num == 0;
                    if (flag2)
                    {
                        num = _ba7.ProcessArgumentListNode(argumentListNode, memberOf);
                        _AAN2 = _ba7.CheckNamedArguments(num);
                    }
                    _bb3 _AAN3 = _AAN2;
                    bool flag3 = _AAN3 == null;
                    if (flag3)
                    {
                        List<_bb3> _APT = _ba7._AHE;
                        int count2 = _APT.Count;
                        foreach (_bb3 _AAN4 in hashSet)
                        {
                            bool flag4 = num == 0 || _AAN4.CanCallWith(num, true);
                            if (flag4)
                            {
                                _APT.Add(_AAN4);
                            }
                        }
                        int num2 = _APT.Count - count2;
                        bool flag5 = typeArgs == null;
                        if (flag5)
                        {
                            int num3 = num2;
                            while (num3-- > 0)
                            {
                                _bb3 _AAN5 = _APT[count2 + num3];
                                bool flag6 = _AAN5._AHG() == 0 || num == 0;
                                if (!flag6)
                                {
                                    _AAN5 = _ba7.InferMethodTypeArguments(_AAN5, num, invokedLeaf);
                                    bool flag7 = _AAN5 == null;
                                    if (flag7)
                                    {
                                        _APT.RemoveAt(count2 + num3);
                                    }
                                    else
                                    {
                                        _APT[count2 + num3] = _AAN5;
                                    }
                                }
                            }
                        }
                        num2 = _APT.Count - count2;
                        _AAN3 = _ba7.ResolveMethodOverloads(num, num2);
                        _APT.RemoveRange(count2, num2);
                    }
                    bool flag8 = _AAN3 != null && _AAN3._AT != SymbolKind.Error;
                    if (flag8)
                    {
                        _ba7._AGV.RemoveRange(count, num);
                        _ba7._AGW.RemoveRange(count, num);
                        _ba7._AGX.RemoveRange(count, num);
                        _ba7._AGY.RemoveRange(count, num);
                        return _AAN3;
                    }
                }
                hashSet.Clear();
                _APR2 = _APR2._AO as _bn1;
            }
            List<KJK> _APU = this.EFI._APL;
            int count3 = _APU.Count;
            while (count3-- > 0)
            {
                _bn1 _APR3 = _APU[count3].definition as _bn1;
                bool flag9 = _APR3 != null;
                if (flag9)
                {
                    assembly.CollectExtensionMethods(_APR3, id, typeArgs, memberOf, hashSet, context);
                }
            }
            bool flag10 = hashSet.Count > 0;
            if (flag10)
            {
                bool flag11 = _AAN == null;
                if (flag11)
                {
                    _AAN = hashSet.First<_bb3>();
                }
                bool flag12 = num == 0;
                if (flag12)
                {
                    num = _ba7.ProcessArgumentListNode(argumentListNode, memberOf);
                    _AAN2 = _ba7.CheckNamedArguments(num);
                }
                _bb3 _AAN6 = _AAN2;
                bool flag13 = _AAN6 == null;
                if (flag13)
                {
                    List<_bb3> _APT2 = _ba7._AHE;
                    int count4 = _APT2.Count;
                    foreach (_bb3 _AAN7 in hashSet)
                    {
                        bool flag14 = num == 0 || _AAN7.CanCallWith(num, true);
                        if (flag14)
                        {
                            _APT2.Add(_AAN7);
                        }
                    }
                    int num4 = _APT2.Count - count4;
                    bool flag15 = typeArgs == null;
                    if (flag15)
                    {
                        int num5 = num4;
                        while (num5-- > 0)
                        {
                            _bb3 _AAN8 = _APT2[count4 + num5];
                            bool flag16 = _AAN8._AHG() == 0 || num == 0;
                            if (!flag16)
                            {
                                _AAN8 = _ba7.InferMethodTypeArguments(_AAN8, num, invokedLeaf);
                                bool flag17 = _AAN8 == null;
                                if (flag17)
                                {
                                    _APT2.RemoveAt(count4 + num5);
                                }
                                else
                                {
                                    _APT2[count4 + num5] = _AAN8;
                                }
                            }
                        }
                    }
                    num4 = _APT2.Count - count4;
                    _AAN6 = _ba7.ResolveMethodOverloads(num, num4);
                    _APT2.RemoveRange(count4, num4);
                }
                bool flag18 = _AAN6 != null && _AAN6._AT != SymbolKind.Error;
                if (flag18)
                {
                    _ba7._AGV.RemoveRange(count, num);
                    _ba7._AGW.RemoveRange(count, num);
                    _ba7._AGX.RemoveRange(count, num);
                    _ba7._AGY.RemoveRange(count, num);
                    return _AAN6;
                }
            }
            _ba7._AGV.RemoveRange(count, num);
            _ba7._AGW.RemoveRange(count, num);
            _ba7._AGX.RemoveRange(count, num);
            _ba7._AGY.RemoveRange(count, num);
            bool flag19 = base._AMJ() != null;
            if (flag19)
            {
                _bh4 _AAH = base._AMJ().ResolveAsExtensionMethod(id, memberOf, argumentListNode, typeArgs, context, invokedLeaf);
                bool flag20 = _AAH != null;
                if (flag20)
                {
                    return _AAH;
                }
            }
            bool flag21 = _AAN != null && invokedLeaf != null;
            if (flag21)
            {
                invokedLeaf._ACY(_AAN);
                invokedLeaf._AJF = _ba7._AHN._AW;
            }
            return null;
        }

        // Token: 0x060006A0 RID: 1696 RVA: 0x000E7800 File Offset: 0x000E5A00
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            return this._ACV.FindName(symbolName, numTypeParameters, true);
        }

        // Token: 0x060006A1 RID: 1697 RVA: 0x000E7820 File Offset: 0x000E5A20
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            this._ACV.GetMembersCompletionData(data, BindingFlags.NonPublic, AccessLevelMask.Any, context);
            foreach (TypeAlias typeAlias in this.EFI._APO)
            {
                bool flag = !data.ContainsKey(typeAlias._AW);
                if (flag)
                {
                    data.Add(typeAlias._AW, typeAlias.BLH.definition);
                }
            }
            foreach (KJK _AAD in this.EFI._APL)
            {
                _bn1 _APR = _AAD.definition as _bn1;
                bool flag2 = _APR != null;
                if (flag2)
                {
                    _APR.GetTypesOnlyCompletionData(data, AccessLevelMask.Any, context._AN);
                }
            }
            foreach (KJK _AAD2 in this.EFI._APN)
            {
                _b2 _AAC = _AAD2.definition as _b2;
                bool flag3 = _AAC == null;
                if (!flag3)
                {
                    _AAC.GetCompletionDataFromImportedType(data, AccessLevelMask.Any, context);
                }
            }
            bool flag4 = base._AMJ() != null;
            if (flag4)
            {
                _bn1 _APX = ((_bc8)base._AMJ())._ACV;
                _bh4 _AAH = this._ACV._AO;
                while (_AAH != null && _AAH != _APX)
                {
                    _AAH.GetCompletionData(data, context);
                    _AAH = _AAH._AO as _bn1;
                }
            }
            bool _APV = context._APW;
            context._APW = false;
            base.GetCompletionData(data, context);
            context._APW = _APV;
        }

        // Token: 0x060006A2 RID: 1698 RVA: 0x000E7A10 File Offset: 0x000E5C10
        internal override _bc6 EnclosingType()
        {
            return null;
        }

        // Token: 0x060006A3 RID: 1699 RVA: 0x000E7A24 File Offset: 0x000E5C24
        internal override void GetExtensionMethodsCompletionData(_b2 forType, Dictionary<string, _bh4> data)
        {
            _bj5 assembly = base.GetAssembly();
            assembly.GetExtensionMethodsCompletionData(forType, this._ACV, data);
            foreach (KJK _AAD in this.EFI._APL)
            {
                _bn1 _APR = _AAD.definition as _bn1;
                bool flag = _APR != null;
                if (flag)
                {
                    assembly.GetExtensionMethodsCompletionData(forType, _APR, data);
                }
            }
            bool flag2 = base._AMJ() != null;
            if (flag2)
            {
                _bn1 _APX = ((_bc8)base._AMJ())._ACV;
                _bn1 _APR2 = this._ACV._AO as _bn1;
                while (_APR2 != null && _APR2 != _APX)
                {
                    assembly.GetExtensionMethodsCompletionData(forType, _APR2, data);
                    _APR2 = _APR2._AO as _bn1;
                }
                base._AMJ().GetExtensionMethodsCompletionData(forType, data);
            }
        }

        // Token: 0x04000598 RID: 1432
        public _bf8 EFI;

        // Token: 0x04000599 RID: 1433
        public _bn1 _ACV;

        // Token: 0x0400059A RID: 1434
        public List<FKI> _APM;
    }
}
