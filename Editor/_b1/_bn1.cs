using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000C8 RID: 200
    internal class _bn1 : _bh4
    {
        // Token: 0x06000598 RID: 1432 RVA: 0x000D604C File Offset: 0x000D424C
        internal override _bh4 Rebind()
        {
            for (_bh4 _AAH = this; _AAH != null; _AAH = _AAH._AO ?? _AAH._AGU)
            {
                _bj5 _AOS = _AAH as _bj5;
                bool flag = _AOS != null;
                if (flag)
                {
                    return _AOS.FindSameNamespace(this);
                }
            }
            return null;
        }

        // Token: 0x06000599 RID: 1433 RVA: 0x000D609C File Offset: 0x000D429C
        public void CollectExtensionMethods(string id, KJK[] typeArgs, _b2 extendedType, HashSet<_bb3> extensionsMethods, _bm6 context)
        {
            int num = ((typeArgs == null) ? (-1) : typeArgs.Length);
            _bj5 assembly = context.GetAssembly();
            int num2 = this._AAG.Count;
            while (num2-- > 0)
            {
                _bh4 _AAH = this._AAG._AAI(num2);
                bool flag = _AAH._AT != SymbolKind.Class || !_AAH.IsValid() || (_AAH as _b2)._AF == 0 || !_AAH.IsStatic || _AAH._AHG() > 0;
                if (!flag)
                {
                    AccessLevelMask accessLevelMask = AccessLevelMask.Public;
                    bool flag2 = _AAH.Assembly != null && _AAH.Assembly.InternalsVisibleIn(assembly);
                    if (flag2)
                    {
                        accessLevelMask |= AccessLevelMask.Internal;
                    }
                    bool flag3 = !_AAH.IsAccessible(accessLevelMask);
                    if (!flag3)
                    {
                        _bh4 _AAH2 = null;
                        bool flag4 = _AAH._AAG.TryGetValue(id, num, out _AAH2);
                        if (flag4)
                        {
                            bool flag5 = _AAH2._AT == SymbolKind.MethodGroup;
                            if (flag5)
                            {
                                _ba7 _AAK = _AAH2 as _ba7;
                                bool flag6 = _AAK != null;
                                if (flag6)
                                {
                                    foreach (_bb3 _AAN in _AAK._AAM)
                                    {
                                        bool flag7 = _AAN.IsExtensionMethod && _AAN.IsAccessible(accessLevelMask);
                                        if (flag7)
                                        {
                                            _b2 _AAC = _AAN._AIK[0].TypeOf() as _b2;
                                            bool flag8 = extendedType.CanConvertTo(_AAC);
                                            if (flag8)
                                            {
                                                bool flag9 = num > 0;
                                                if (flag9)
                                                {
                                                    _bl4 _AIQ = _AAN.ConstructMethod(typeArgs);
                                                    extensionsMethods.Add(_AIQ);
                                                }
                                                else
                                                {
                                                    extensionsMethods.Add(_AAN);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("Expected a method group: " + _AAH2.GetTooltipText());
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600059A RID: 1434 RVA: 0x000D6288 File Offset: 0x000D4488
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            bool _zc8 = this._zc9;
            if (!_zc8)
            {
                this._zc9 = true;
                leaf._ACY(null);
                base.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
                this._zc9 = false;
                bool flag = leaf._AAB() == null;
                if (flag)
                {
                    bool flag2 = context != null;
                    if (flag2)
                    {
                        _bj5 assembly = context.GetAssembly();
                        assembly.ResolveInReferencedAssemblies(leaf, this, numTypeArgs);
                    }
                }
            }
        }

        // Token: 0x0600059B RID: 1435 RVA: 0x000D62F0 File Offset: 0x000D44F0
        internal override void ResolveAttributeMember(_bb4.DHBA leaf, _bm6 context)
        {
            bool _zc8 = this._zc9;
            if (!_zc8)
            {
                this._zc9 = true;
                leaf._ACY(null);
                leaf._AJF = null;
                base.ResolveAttributeMember(leaf, context);
                this._zc9 = false;
                bool flag = leaf._AAB() == null;
                if (flag)
                {
                    _bj5 assembly = context.GetAssembly();
                    assembly.ResolveAttributeInReferencedAssemblies(leaf, this);
                }
            }
        }

        // Token: 0x0600059C RID: 1436 RVA: 0x000D634F File Offset: 0x000D454F
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            this.GetMembersCompletionData(data, context._APW ? BindingFlags.Default : BindingFlags.Static, AccessLevelMask.Any, context);
        }

        // Token: 0x0600059D RID: 1437 RVA: 0x000D636C File Offset: 0x000D456C
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            base.GetMembersCompletionData(data, flags, mask, context);
            _bj5 _CGK = context._AN;
            _CGK.GetMembersCompletionDataFromReferencedAssemblies(data, this, context);
        }

        // Token: 0x0600059E RID: 1438 RVA: 0x000D639C File Offset: 0x000D459C
        public void GetTypesOnlyCompletionData(Dictionary<string, _bh4> data, AccessLevelMask mask, _bj5 assembly)
        {
            bool flag = (mask & AccessLevelMask.Public) > AccessLevelMask.None;
            if (flag)
            {
                bool flag2 = assembly.InternalsVisibleIn(base.Assembly);
                if (flag2)
                {
                    mask |= AccessLevelMask.Internal;
                }
                else
                {
                    mask &= ~AccessLevelMask.Internal;
                }
            }
            for (int i = 0; i < this._AAG.Count; i++)
            {
                _bh4 _AAH = this._AAG._AAI(i);
                bool flag3 = _AAH._AT == SymbolKind.Namespace;
                if (!flag3)
                {
                    bool flag4 = _AAH._AT != SymbolKind.MethodGroup;
                    if (flag4)
                    {
                        bool flag5 = _AAH.IsAccessible(mask) && !data.ContainsKey(_AAH._AP());
                        if (flag5)
                        {
                            data.Add(_AAH._AP(), _AAH);
                        }
                    }
                }
            }
            bool flag6 = assembly != null;
            if (flag6)
            {
                assembly.GetTypesOnlyCompletionDataFromReferencedAssemblies(data, this);
            }
        }

        // Token: 0x0600059F RID: 1439 RVA: 0x000D646C File Offset: 0x000D466C
        internal override _b2 TypeOfTypeParameter(_bd7 tp)
        {
            return tp;
        }

        // Token: 0x060005A0 RID: 1440 RVA: 0x000D6480 File Offset: 0x000D4680
        internal override string GetTooltipText()
        {
            return (this._AW == string.Empty) ? "global namespace" : base.GetTooltipText();
        }

        // Token: 0x060005A1 RID: 1441 RVA: 0x000D64B4 File Offset: 0x000D46B4
        public void GetExtensionMethodsCompletionData(_b2 targetType, Dictionary<string, _bh4> data, AccessLevelMask accessLevelMask)
        {
            for (int i = 0; i < this._AAG.Count; i++)
            {
                _bh4 _AAH = this._AAG._AAI(i);
                bool flag = _AAH._AT == SymbolKind.Class && _AAH.IsStatic && _AAH._AHG() == 0 && (_AAH as _b2)._AF > 0 && _AAH.IsAccessible(accessLevelMask);
                if (flag)
                {
                    _bh4._CAT _CAU = _AAH._AAG;
                    int j = 0;
                    while (j < _CAU.Count)
                    {
                        _bh4 _AAH2 = _CAU._AAI(j);
                        bool flag2 = _AAH2._AT == SymbolKind.MethodGroup;
                        if (flag2)
                        {
                            _ba7 _AAK = _AAH2 as _ba7;
                            bool flag3 = _AAK == null;
                            if (!flag3)
                            {
                                bool flag4 = data.ContainsKey(_AAK._AW);
                                if (!flag4)
                                {
                                    foreach (_bb3 _AAN in _AAK._AAM)
                                    {
                                        bool flag5 = _AAN._AT != SymbolKind.Method;
                                        if (!flag5)
                                        {
                                            bool flag6 = !_AAN.IsExtensionMethod;
                                            if (!flag6)
                                            {
                                                bool flag7 = !_AAN.IsAccessible(accessLevelMask);
                                                if (!flag7)
                                                {
                                                    List<_bm1> parameters = _AAN.GetParameters();
                                                    bool flag8 = parameters == null || parameters.Count == 0;
                                                    if (!flag8)
                                                    {
                                                        bool flag9 = !targetType.CanConvertTo(parameters[0].TypeOf() as _b2);
                                                        if (!flag9)
                                                        {
                                                            data.Add(_AAN._AW, _AAN);
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    
                        j++;
                        continue;
                     
                    }
                }
            }
        }

        // Token: 0x060005A2 RID: 1442 RVA: 0x000D6688 File Offset: 0x000D4888
        public IEnumerable<_b2> EnumTypes(string name)
        {
            int i = this._AAG.Count;
            for (; ; )
            {
                int num = i;
                i = num - 1;
                if (num <= 0)
                {
                    break;
                }
                _bh4 member = this._AAG._AAI(i);
                SymbolKind _ABY = member._AT;
                SymbolKind symbolKind = _ABY;
                SymbolKind symbolKind2 = symbolKind;
                _bn1 nsDef;
                if (symbolKind2 != SymbolKind.Namespace)
                {
                    if (symbolKind2 - SymbolKind.Interface <= 4)
                    {
                        bool flag = member._AW == name;
                        if (flag)
                        {
                            yield return member as _b2;
                        }
                    }
                }
                else
                {
                    nsDef = member as _bn1;
                    foreach (_b2 type in nsDef.EnumTypes(name))
                    {
                        yield return type;
                    }
                }
            }
            yield break;
        }

        // Token: 0x0400051E RID: 1310
        private bool _zc9 = false;
    }
}
