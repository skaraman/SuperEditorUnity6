using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000F3 RID: 243
    internal static class _bc9
    {
        // Token: 0x060006F4 RID: 1780 RVA: 0x000E9067 File Offset: 0x000E7267
        public static void RegisterIssueProvider(_bi7 provider)
        {
            _bc9._APY.Add(provider);
        }

        // Token: 0x060006F5 RID: 1781 RVA: 0x000E9076 File Offset: 0x000E7276
        public static void RegisterCodeFixProvider(_bg6 fixProvider)
        {
            _bc9._APZ.Add(fixProvider);
        }

        // Token: 0x060006F6 RID: 1782 RVA: 0x000E9088 File Offset: 0x000E7288
        public static List<_AQA> GetFixes(GCE textBuffer, SyntaxToken token)
        {
            List<_AQA> list = new List<_AQA>();
            foreach (_bi7 _AQB in _bc9._APY)
            {
                CodeIssue codeIssue = _AQB.Check(textBuffer, token);
                bool flag = codeIssue.kind == CodeIssue.Kind.None;
                if (!flag)
                {
                    foreach (_bg6 _AQC in _bc9._APZ)
                    {
                        bool flag2 = _AQC.CanFix(codeIssue, textBuffer, token);
                        if (flag2)
                        {
                            list.AddRange(_AQC.EnumFixes(codeIssue, textBuffer, token));
                        }
                    }
                }
            }
            return list;
        }

        // Token: 0x060006F7 RID: 1783 RVA: 0x000E9160 File Offset: 0x000E7360
        public static void GetCompletions(_bf4 completionTypes, _bb4._AIN parseTreeNode, HashSet<_bh4> completionSymbols, string assetPath)
        {
            try
            {
                Dictionary<string, _bh4> dictionary = new Dictionary<string, _bh4>();
                _bj5 _AOS = _bj5.FromAssetPath(assetPath);
                bool flag = (completionTypes & (_bf4)8192) > (_bf4)0;
                if (flag)
                {
                    _bb4._ACW _AGZ = parseTreeNode.OOME;
                    bool flag2 = _AGZ._AHB() != "objectOrCollectionInitializer";
                    if (flag2)
                    {
                        bool flag3 = _AGZ._AHB() != "objectInitializer";
                        if (flag3)
                        {
                            bool flag4 = _AGZ._AHB() == "memberInitializerList";
                            if (flag4)
                            {
                                _AGZ = _AGZ.OOME;
                            }
                        }
                        _AGZ = _AGZ.OOME;
                    }
                    _AGZ = _AGZ.OOME;
                    bool flag5 = _AGZ._AHB() == "objectCreationExpression";
                    _bb4._AIN _AIO;
                    if (flag5)
                    {
                        _AIO = _AGZ.OOME;
                    }
                    else
                    {
                        _AIO = _AGZ.LeafAt(0);
                    }
                    _bh4 _AAH = ((_AIO != null) ? _bh4.ResolveNode(_AIO, null, null, 0, false) : null);
                    bool flag6 = _AAH != null;
                    if (flag6)
                    {
                        _bc9.GetMemberCompletions(_AAH, parseTreeNode, _AOS, dictionary, false);
                        Dictionary<string, _bh4> dictionary2 = new Dictionary<string, _bh4>();
                        foreach (KeyValuePair<string, _bh4> keyValuePair in dictionary)
                        {
                            _bh4 value = keyValuePair.Value;
                            bool flag7 = (value._AT == SymbolKind.Field && (value._AV & Modifiers.ReadOnly) == Modifiers.None) || (value._AT == SymbolKind.Property && value.FindName("set", 0, false) != null);
                            if (flag7)
                            {
                                dictionary2[keyValuePair.Key] = value;
                            }
                        }
                        dictionary = dictionary2;
                    }
                    _b2 _AAC = ((_AAH != null) ? (_AAH.TypeOf() as _b2) : null);
                    bool flag8 = _AAC == null || !_AAC.DerivesFrom(_bh4._BFL);
                    if (flag8)
                    {
                        completionSymbols.Clear();
                        completionSymbols.UnionWith(dictionary.Values);
                        return;
                    }
                }
                bool flag9 = (completionTypes & (_bf4)512) > (_bf4)0;
                if (flag9)
                {
                    _bb4._AIN _AIO2 = parseTreeNode.FindPreviousNode();
                    bool flag10 = _AIO2 != null;
                    if (flag10)
                    {
                        _bb4._ACW _AGZ2 = _AIO2 as _bb4._ACW;
                        bool flag11 = _AGZ2 != null && _AGZ2._AHB() == "primaryExpressionPart";
                        if (flag11)
                        {
                            _bb4._ACW _AGZ3 = _AGZ2.NodeAt(0);
                            bool flag12 = _AGZ3 != null && _AGZ3._AHB() == "arguments";
                            if (flag12)
                            {
                                _AIO2 = _AIO2.FindPreviousNode();
                                _AGZ2 = _AIO2 as _bb4._ACW;
                            }
                        }
                        _bc9.ResolveNode(_AGZ2 ?? _AIO2.OOME);
                        _bh4 resolvedSymbol = _bc9.GetResolvedSymbol(_AGZ2 ?? _AIO2.OOME);
                        _bc9.GetMemberCompletions(resolvedSymbol, parseTreeNode, _AOS, dictionary, true);
                    }
                }
                else
                {
                    _bm6._AML = parseTreeNode;
                    _bm6._AMM = assetPath;
                    bool flag13 = parseTreeNode == null;
                    if (flag13)
                    {
                        return;
                    }
                    bool flag14 = parseTreeNode.IsLit("=>");
                    if (flag14)
                    {
                        parseTreeNode = parseTreeNode.OOME.NodeAt((int)(parseTreeNode._AIL + 1)) ?? parseTreeNode;
                    }
                    bool flag15 = parseTreeNode.IsLit("]") && parseTreeNode.OOME._AHB() == "attributes";
                    if (flag15)
                    {
                        parseTreeNode = parseTreeNode.OOME.OOME.NodeAt((int)(parseTreeNode.OOME._AIL + 1));
                    }
                    _bb4._ACW _AGZ4 = (parseTreeNode as _bb4._ACW) ?? parseTreeNode.OOME;
                    bool flag16 = _AGZ4 != null && _AGZ4._AJW is _bn4 && (parseTreeNode.IsLit(";") || parseTreeNode.IsLit("}")) && _AGZ4.GetLastLeaf() == parseTreeNode;
                    if (flag16)
                    {
                        _AGZ4 = _AGZ4.OOME;
                    }
                    while (_AGZ4 != null && _AGZ4._AJW == null)
                    {
                        _AGZ4 = _AGZ4.OOME;
                    }
                    bool flag17 = _AGZ4 != null;
                    if (flag17)
                    {
                        _bb4.DHBA _AEM;
                        if ((_AEM = parseTreeNode as _bb4.DHBA) == null)
                        {
                            _AEM = ((_bb4._ACW)parseTreeNode).GetLastLeaf() ?? ((_bb4._ACW)parseTreeNode).FindPreviousLeaf();
                        }
                        _bb4.DHBA _AEM2 = _AEM;
                        _bm6._AQD = ((_AEM2 != null) ? _AEM2.line : 0);
                        _bm6._AQE = ((_AEM2 != null) ? _AEM2._AJG() : 0);
                        _be4 _AQF = new _be4();
                        _AQF._AJW = _AGZ4._AJW;
                        _AQF._AML = parseTreeNode;
                        _AQF._AMM = assetPath;
                        _AQF._AQD = _bm6._AQD;
                        _AQF._AQE = _bm6._AQE;
                        _AQF._AN = _AOS;
                        _AQF.BLH = _AGZ4._AJW.EnclosingType();
                        _AQF._APW = true;
                        _AGZ4._AJW.GetCompletionData(dictionary, _AQF);
                    }
                }
                completionSymbols.UnionWith(dictionary.Values);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        // Token: 0x060006F8 RID: 1784 RVA: 0x000E9638 File Offset: 0x000E7838
        public static _bh4 GetResolvedSymbol(_bb4._AIN baseNode)
        {
            _bb4.DHBA _AEM = baseNode as _bb4.DHBA;
            bool flag = _AEM != null;
            _bh4 _AAH;
            if (flag)
            {
                bool flag2 = (_AEM._AAB() == null || _AEM._AAB()._AT == SymbolKind.Error) && _AEM.OOME != null;
                if (flag2)
                {
                    _bc9.ResolveNodeInternal(_AEM.OOME);
                }
                _AAH = _AEM._AAB();
            }
            else
            {
                _bb4._ACW _AGZ = baseNode as _bb4._ACW;
                bool flag3 = _AGZ == null || _AGZ._AIX == 0;
                if (flag3)
                {
                    _AAH = null;
                }
                else
                {
                    string text = _AGZ._AHB();
                    string text2 = text;
                    uint num = Helper.ComputeStringHash(text2);
                    if (num <= 1735118041U)
                    {
                        if (num <= 727204632U)
                        {
                            if (num <= 405554134U)
                            {
                                if (num != 82626113U)
                                {
                                    if (num != 221106847U)
                                    {
                                        if (num != 405554134U)
                                        {
                                            goto IL_0784;
                                        }
                                        if (!(text2 == "relationalExpression"))
                                        {
                                            goto IL_0784;
                                        }
                                        goto IL_0776;
                                    }
                                    else if (!(text2 == "predefinedType"))
                                    {
                                        goto IL_0784;
                                    }
                                }
                                else
                                {
                                    if (!(text2 == "defaultValueExpression"))
                                    {
                                        goto IL_0784;
                                    }
                                    goto IL_0776;
                                }
                            }
                            else if (num <= 693225631U)
                            {
                                if (num != 567569430U)
                                {
                                    if (num != 693225631U)
                                    {
                                        goto IL_0784;
                                    }
                                    if (!(text2 == "arguments"))
                                    {
                                        goto IL_0784;
                                    }
                                    return _bc9.GetResolvedSymbol(_AGZ.FindPreviousNode() as _bb4._ACW);
                                }
                                else
                                {
                                    if (!(text2 == "namespaceOrTypeName"))
                                    {
                                        goto IL_0784;
                                    }
                                    return _bc9.GetResolvedSymbol(_AGZ.NodeAt((int)(_AGZ._AIX & -2)));
                                }
                            }
                            else if (num != 708299687U)
                            {
                                if (num != 727204632U)
                                {
                                    goto IL_0784;
                                }
                                if (!(text2 == "exclusiveOrExpression"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                            else
                            {
                                if (!(text2 == "equalityExpression"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                        }
                        else if (num <= 1070359341U)
                        {
                            if (num <= 784738317U)
                            {
                                if (num != 781357933U)
                                {
                                    if (num != 784738317U)
                                    {
                                        goto IL_0784;
                                    }
                                    if (!(text2 == "parenExpression"))
                                    {
                                        goto IL_0784;
                                    }
                                    goto IL_0776;
                                }
                                else
                                {
                                    if (!(text2 == "uncheckedExpression"))
                                    {
                                        goto IL_0784;
                                    }
                                    goto IL_0776;
                                }
                            }
                            else if (num != 1020520569U)
                            {
                                if (num != 1070359341U)
                                {
                                    goto IL_0784;
                                }
                                if (!(text2 == "objectCreationExpression"))
                                {
                                    goto IL_0784;
                                }
                                _bh4 _AAH2 = _bc9.GetResolvedSymbol(_AGZ.FindPreviousNode() as _bb4._ACW);
                                bool flag4 = _AAH2 == null || _AAH2._AT == SymbolKind.Error;
                                if (flag4)
                                {
                                    _AAH2 = _bh4._AS;
                                }
                                _b2 _AAC = (_b2)_AAH2.TypeOf();
                                return _AAC.GetThisInstance();
                            }
                            else
                            {
                                if (!(text2 == "nameofExpression"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                        }
                        else if (num <= 1623885570U)
                        {
                            if (num != 1361572173U)
                            {
                                if (num != 1623885570U)
                                {
                                    goto IL_0784;
                                }
                                if (!(text2 == "typeofExpression"))
                                {
                                    goto IL_0784;
                                }
                                return ((_b2)_bl9.ForType(typeof(Type)).definition).GetThisInstance();
                            }
                            else
                            {
                                if (!(text2 == "type"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                        }
                        else if (num != 1662645679U)
                        {
                            if (num != 1735118041U)
                            {
                                goto IL_0784;
                            }
                            if (!(text2 == "nonArrayType"))
                            {
                                goto IL_0784;
                            }
                            _b2 _AAC2 = _bc9.GetResolvedSymbol(_AGZ.NodeAt(0)) as _b2;
                            bool flag5 = _AAC2 == null || _AAC2._AT == SymbolKind.Error;
                            if (flag5)
                            {
                                _AAC2 = _bh4._AS;
                            }
                            return (_AGZ._AIX == 1) ? _AAC2 : _AAC2.MakeNullableType();
                        }
                        else
                        {
                            if (!(text2 == "primaryExpression"))
                            {
                                goto IL_0784;
                            }
                            goto IL_0776;
                        }
                    }
                    else if (num <= 3015329114U)
                    {
                        if (num <= 2115434148U)
                        {
                            if (num <= 1956832512U)
                            {
                                if (num != 1767627332U)
                                {
                                    if (num != 1956832512U)
                                    {
                                        goto IL_0784;
                                    }
                                    if (!(text2 == "brackets"))
                                    {
                                        goto IL_0784;
                                    }
                                    goto IL_0776;
                                }
                                else
                                {
                                    if (!(text2 == "andExpression"))
                                    {
                                        goto IL_0784;
                                    }
                                    goto IL_0776;
                                }
                            }
                            else if (num != 1963880416U)
                            {
                                if (num != 2115434148U)
                                {
                                    goto IL_0784;
                                }
                                if (!(text2 == "checkedExpression"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                            else
                            {
                                if (!(text2 == "localVariableType"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                        }
                        else if (num <= 2622508398U)
                        {
                            if (num != 2590802725U)
                            {
                                if (num != 2622508398U)
                                {
                                    goto IL_0784;
                                }
                                if (!(text2 == "typeName"))
                                {
                                    goto IL_0784;
                                }
                                return _bc9.GetResolvedSymbol(_AGZ.NodeAt(0));
                            }
                            else
                            {
                                if (!(text2 == "primaryExpressionStart"))
                                {
                                    goto IL_0784;
                                }
                                bool flag6 = _AGZ._AIX < 3;
                                if (flag6)
                                {
                                    return _bc9.GetResolvedSymbol(_AGZ.ChildAt(0));
                                }
                                _AEM = _AGZ.LeafAt(2);
                                return (_AEM != null) ? _AEM._AAB() : null;
                            }
                        }
                        else if (num != 2938262002U)
                        {
                            if (num != 3015329114U)
                            {
                                goto IL_0784;
                            }
                            if (!(text2 == "inclusiveOrExpression"))
                            {
                                goto IL_0784;
                            }
                            goto IL_0776;
                        }
                        else
                        {
                            if (!(text2 == "unaryExpression"))
                            {
                                goto IL_0784;
                            }
                            goto IL_0776;
                        }
                    }
                    else if (num <= 3335511552U)
                    {
                        if (num <= 3253591965U)
                        {
                            if (num != 3119263074U)
                            {
                                if (num != 3253591965U)
                                {
                                    goto IL_0784;
                                }
                                if (!(text2 == "globalNamespace"))
                                {
                                    goto IL_0784;
                                }
                                goto IL_0776;
                            }
                            else
                            {
                                if (!(text2 == "primaryExpressionPart"))
                                {
                                    goto IL_0784;
                                }
                                return _bc9.GetResolvedSymbol(_AGZ.NodeAt(0));
                            }
                        }
                        else if (num != 3319310467U)
                        {
                            if (num != 3335511552U)
                            {
                                goto IL_0784;
                            }
                            if (!(text2 == "accessIdentifier"))
                            {
                                goto IL_0784;
                            }
                            _AEM = ((_AGZ._AIX < 2) ? null : _AGZ.LeafAt(1));
                            bool flag7 = _AEM != null && _AEM._AAB() == null;
                            if (flag7)
                            {
                                _bc9.ResolveNodeInternal(_AGZ);
                            }
                            return (_AEM != null) ? _AEM._AAB() : null;
                        }
                        else
                        {
                            if (!(text2 == "sizeofExpression"))
                            {
                                goto IL_0784;
                            }
                            return _bh4._AAQ.GetThisInstance();
                        }
                    }
                    else if (num <= 3381351465U)
                    {
                        if (num != 3366671281U)
                        {
                            if (num != 3381351465U)
                            {
                                goto IL_0784;
                            }
                            if (!(text2 == "shiftExpression"))
                            {
                                goto IL_0784;
                            }
                            goto IL_0776;
                        }
                        else if (!(text2 == "typeOrGeneric"))
                        {
                            goto IL_0784;
                        }
                    }
                    else if (num != 3433102825U)
                    {
                        if (num != 3474305003U)
                        {
                            goto IL_0784;
                        }
                        if (!(text2 == "expression"))
                        {
                            goto IL_0784;
                        }
                        goto IL_0776;
                    }
                    else
                    {
                        if (!(text2 == "arrayCreationExpression"))
                        {
                            goto IL_0784;
                        }
                        _bh4 resolvedSymbol = _bc9.GetResolvedSymbol(_AGZ.FindPreviousNode() as _bb4._ACW);
                        _bh4 _AAH3 = _bh4.ResolveNode(_AGZ, null, resolvedSymbol, 0, false);
                        return _AAH3 ?? _bh4._AQG.GetThisInstance();
                    }
                    return _AGZ.LeafAt(0)._AAB();
                IL_0776:
                    return _bh4.ResolveNode(_AGZ, null, null, 0, false);
                IL_0784:
                    _AAH = _bh4.ResolveNode(_AGZ, null, null, 0, false);
                }
            }
            return _AAH;
        }

        // Token: 0x060006F9 RID: 1785 RVA: 0x000E9DDC File Offset: 0x000E7FDC
        private static void GetMemberCompletions(_bh4 targetDef, _bb4._AIN parseTreeNode, _bj5 assemblyDefinition, Dictionary<string, _bh4> d, bool includeExtensionMethods)
        {
            bool flag = targetDef != null;
            if (flag)
            {
                _bh4 _AAH = targetDef.TypeOf();
                BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static;
                switch (targetDef._AT)
                {
                    case SymbolKind.None:
                    case SymbolKind.Error:
                        goto IL_00E5;
                    case SymbolKind.Namespace:
                    case SymbolKind.Interface:
                    case SymbolKind.Enum:
                    case SymbolKind.Struct:
                    case SymbolKind.Class:
                    case SymbolKind.Delegate:
                    case SymbolKind.TypeParameter:
                    case SymbolKind.TypeParameterConstraintList:
                    case SymbolKind.BaseTypesList:
                        bindingFlags = BindingFlags.Static;
                        goto IL_00E5;
                    case SymbolKind.Field:
                    case SymbolKind.ConstantField:
                    case SymbolKind.LocalConstant:
                    case SymbolKind.EnumMember:
                    case SymbolKind.Property:
                    case SymbolKind.Event:
                    case SymbolKind.Indexer:
                    case SymbolKind.Method:
                    case SymbolKind.MethodGroup:
                    case SymbolKind.Constructor:
                    case SymbolKind.Destructor:
                    case SymbolKind.Operator:
                    case SymbolKind.Accessor:
                    case SymbolKind.LambdaExpression:
                    case SymbolKind.Parameter:
                    case SymbolKind.CatchParameter:
                    case SymbolKind.Variable:
                    case SymbolKind.CaseVariable:
                    case SymbolKind.ForEachVariable:
                    case SymbolKind.FromClauseVariable:
                    case SymbolKind.OutVariable:
                    case SymbolKind.Instance:
                        bindingFlags = BindingFlags.Instance;
                        goto IL_00E5;
                    case SymbolKind.Null:
                    case SymbolKind.Label:
                        return;
                }
                throw new ArgumentOutOfRangeException();
            IL_00E5:
                _b2 _AAC = null;
                for (_bb4._ACW _AGZ = (parseTreeNode as _bb4._ACW) ?? parseTreeNode.OOME; _AGZ != null; _AGZ = _AGZ.OOME)
                {
                    _bn4 _AQH = _AGZ._AJW as _bn4;
                    bool flag2 = _AQH != null;
                    if (flag2)
                    {
                        _AAC = _AQH.EFI._ACV as _b2;
                        bool flag3 = _AAC != null;
                        if (flag3)
                        {
                            break;
                        }
                    }
                }
                AccessLevelMask accessLevelMask = ((_AAH == _AAC || _AAH.IsSameOrParentOf(_AAC)) ? AccessLevelMask.Any : ((_AAC != null && _AAC.DerivesFrom(_AAH as _b2)) ? (AccessLevelMask.Protected | AccessLevelMask.Internal | AccessLevelMask.Public) : (AccessLevelMask.Internal | AccessLevelMask.Public)));
                bool flag4 = _AAH.Assembly == null || !_AAH.Assembly.InternalsVisibleIn(assemblyDefinition);
                if (flag4)
                {
                    accessLevelMask &= ~AccessLevelMask.Internal;
                }
                _be4 _AQF = new _be4
                {
                    _AN = assemblyDefinition
                };
                _AAH.GetMembersCompletionData(d, bindingFlags, accessLevelMask, _AQF);
                bool flag5 = includeExtensionMethods && bindingFlags == BindingFlags.Instance && (_AAH._AT == SymbolKind.Class || _AAH._AT == SymbolKind.Struct || _AAH._AT == SymbolKind.Interface || _AAH._AT == SymbolKind.Enum);
                if (flag5)
                {
                    _bb4._ACW _AGZ2 = (parseTreeNode as _bb4._ACW) ?? parseTreeNode.OOME;
                    while (_AGZ2 != null && _AGZ2._AJW == null)
                    {
                        _AGZ2 = _AGZ2.OOME;
                    }
                    _bm6 _AQI = ((_AGZ2 != null) ? _AGZ2._AJW : null);
                    bool flag6 = _AQI != null;
                    if (flag6)
                    {
                        _AQI.GetExtensionMethodsCompletionData(_AAH as _b2, d);
                    }
                }
            }
        }

        // Token: 0x060006FA RID: 1786 RVA: 0x000EA03C File Offset: 0x000E823C
        public static _bb4._ACW ResolveNode(_bb4._ACW node)
        {
            _bb4._ACW _AGZ = _bc9.ResolveNodeInternal(node);
            bool flag = _ba7._AGW.Count != 0;
            if (flag)
            {
                Debug.LogError("argumentTypesStack.Count == " + _ba7._AGW.Count.ToString());
            }
            bool flag2 = _ba7._AGX.Count != 0;
            if (flag2)
            {
                Debug.LogError("resolvedArgumentsStack.Count == " + _ba7._AGX.Count.ToString());
            }
            bool flag3 = _ba7._AGV.Count != 0;
            if (flag3)
            {
                Debug.LogError("modifiersStack.Count == " + _ba7._AGV.Count.ToString());
            }
            bool flag4 = _ba7._AGY.Count != 0;
            if (flag4)
            {
                Debug.LogError("namedArguments.Count == " + _ba7._AGY.Count.ToString());
            }
            bool flag5 = _ba7._AHT.Count != 0;
            if (flag5)
            {
                Debug.LogError("argumentNodesStack.Count == " + _ba7._AHT.Count.ToString());
            }
            bool flag6 = _ba7._AHE.Count != 0;
            if (flag6)
            {
                Debug.LogError("methodCandidatesStack.Count == " + _ba7._AHE.Count.ToString());
            }
            return _AGZ;
        }

        // Token: 0x060006FB RID: 1787 RVA: 0x000EA194 File Offset: 0x000E8394
        public static _bb4._ACW ResolveNodeInternal(_bb4._ACW node)
        {
            bool flag = node == null;
            _bb4._ACW _AGZ;
            if (flag)
            {
                _AGZ = null;
            }
            else
            {
                while (node.OOME != null)
                {
                    string text = node._AHB();
                    string text2 = text;
                    uint num = Helper.ComputeStringHash(text2);
                    if (num <= 2585900876U)
                    {
                        if (num <= 1070359341U)
                        {
                            if (num <= 567569430U)
                            {
                                if (num != 180138408U)
                                {
                                    if (num != 192704362U)
                                    {
                                        if (num != 567569430U)
                                        {
                                            break;
                                        }
                                        if (!(text2 == "namespaceOrTypeName"))
                                        {
                                            break;
                                        }
                                    }
                                    else if (!(text2 == "caseVariableDeclarator"))
                                    {
                                        break;
                                    }
                                }
                                else if (!(text2 == "qidPart"))
                                {
                                    break;
                                }
                            }
                            else if (num != 1004943638U)
                            {
                                if (num != 1040765708U)
                                {
                                    if (num != 1070359341U)
                                    {
                                        break;
                                    }
                                    if (!(text2 == "objectCreationExpression"))
                                    {
                                        break;
                                    }
                                }
                                else if (!(text2 == "implicitArrayCreationExpression"))
                                {
                                    break;
                                }
                            }
                            else if (!(text2 == "arrayInitializerList"))
                            {
                                break;
                            }
                        }
                        else if (num <= 2095926690U)
                        {
                            if (num != 1735118041U)
                            {
                                if (num != 1956832512U)
                                {
                                    if (num != 2095926690U)
                                    {
                                        break;
                                    }
                                    if (!(text2 == "argumentList"))
                                    {
                                        break;
                                    }
                                }
                                else if (!(text2 == "brackets"))
                                {
                                    break;
                                }
                            }
                            else if (!(text2 == "nonArrayType"))
                            {
                                break;
                            }
                        }
                        else if (num <= 2371411181U)
                        {
                            if (num != 2227648195U)
                            {
                                if (num != 2371411181U)
                                {
                                    break;
                                }
                                if (!(text2 == "attributeArguments"))
                                {
                                    break;
                                }
                            }
                            else if (!(text2 == "qidStart"))
                            {
                                break;
                            }
                        }
                        else if (num != 2441638925U)
                        {
                            if (num != 2585900876U)
                            {
                                break;
                            }
                            if (!(text2 == "outVariableDeclarator"))
                            {
                                break;
                            }
                        }
                        else if (!(text2 == "objectOrCollectionInitializer"))
                        {
                            break;
                        }
                    }
                    else if (num <= 3335511552U)
                    {
                        if (num <= 2880676846U)
                        {
                            if (num != 2590802725U)
                            {
                                if (num != 2622508398U)
                                {
                                    if (num != 2880676846U)
                                    {
                                        break;
                                    }
                                    if (!(text2 == "attributeMemberName"))
                                    {
                                        break;
                                    }
                                }
                                else if (!(text2 == "typeName"))
                                {
                                    break;
                                }
                            }
                            else if (!(text2 == "primaryExpressionStart"))
                            {
                                break;
                            }
                        }
                        else if (num <= 3119263074U)
                        {
                            if (num != 2909293537U)
                            {
                                if (num != 3119263074U)
                                {
                                    break;
                                }
                                if (!(text2 == "primaryExpressionPart"))
                                {
                                    break;
                                }
                            }
                            else if (!(text2 == "memberInitializer"))
                            {
                                break;
                            }
                        }
                        else if (num != 3253591965U)
                        {
                            if (num != 3335511552U)
                            {
                                break;
                            }
                            if (!(text2 == "accessIdentifier"))
                            {
                                break;
                            }
                        }
                        else if (!(text2 == "globalNamespace"))
                        {
                            break;
                        }
                    }
                    else if (num <= 3549306485U)
                    {
                        if (num != 3366671281U)
                        {
                            if (num != 3433102825U)
                            {
                                if (num != 3549306485U)
                                {
                                    break;
                                }
                                if (!(text2 == "argumentName"))
                                {
                                    break;
                                }
                            }
                            else if (!(text2 == "arrayCreationExpression"))
                            {
                                break;
                            }
                        }
                        else if (!(text2 == "typeOrGeneric"))
                        {
                            break;
                        }
                    }
                    else if (num <= 3894489210U)
                    {
                        if (num != 3773347596U)
                        {
                            if (num != 3894489210U)
                            {
                                break;
                            }
                            if (!(text2 == "arrayInitializer"))
                            {
                                break;
                            }
                        }
                        else if (!(text2 == "attributeArgument"))
                        {
                            break;
                        }
                    }
                    else if (num != 3920802870U)
                    {
                        if (num != 4024465044U)
                        {
                            break;
                        }
                        if (!(text2 == "attributeArgumentList"))
                        {
                            break;
                        }
                    }
                    else if (!(text2 == "argument"))
                    {
                        break;
                    }
                    node = node.OOME;
                    continue;
                    break;
                }
                try
                {
                    _bh4 _AAH = _bh4.ResolveNode(node, null, null, 0, false);
                    bool flag2 = _AAH == null;
                    if (flag2)
                    {
                        _bc9.ResolveChildren(node);
                    }
                }
                catch (Exception ex)
                {
                    _ba7._AGW.Clear();
                    _ba7._AGX.Clear();
                    _ba7._AGV.Clear();
                    _ba7._AGY.Clear();
                    _ba7._AHT.Clear();
                    _ba7._AHE.Clear();
                    return null;
                }
                _AGZ = node;
            }
            return _AGZ;
        }

        // Token: 0x060006FC RID: 1788 RVA: 0x000EA664 File Offset: 0x000E8864
        private static void ResolveChildren(_bb4._ACW node)
        {
            bool flag = node == null;
            if (!flag)
            {
                bool flag2 = node._AIX != 0;
                if (flag2)
                {
                    int i = 0;
                    while (i < (int)node._AIX)
                    {
                        _bb4._AIN _AIO = node.ChildAt(i);
                        _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                        bool flag3 = _AEM == null || (_AEM._ACX != null && _AEM._ACX.tokenKind != SyntaxToken.Kind.Punctuator && (_AEM._ACX.tokenKind != SyntaxToken.Kind.Keyword || _bh4._ABO.ContainsKey(_AEM._ACX.text)));
                        if (flag3)
                        {
                            bool flag4 = _AEM == null;
                            if (flag4)
                            {
                                string text = ((_bb4._ACW)_AIO)._AHB();
                                string text2 = text;
                                if (text2 == "modifiers" || text2 == "methodBody")
                                {
                                    goto IL_00FE;
                                }
                            }
                            int num = 0;
                            bool flag5 = _bh4.ResolveNode(_AIO, null, null, num, false) == null;
                            if (flag5)
                            {
                                _bb4._ACW _AGZ = _AIO as _bb4._ACW;
                                bool flag6 = _AGZ != null;
                                if (flag6)
                                {
                                    _bc9.ResolveChildren(_AGZ);
                                }
                            }
                        }
                    IL_00FE:
                        i++;
                        continue;
                        goto IL_00FE;
                    }
                }
            }
        }

        // Token: 0x060006FD RID: 1789 RVA: 0x000EA788 File Offset: 0x000E8988
        public static bool IsWriteReference(SyntaxToken token)
        {
            bool flag = !(token.OOME._AAB() is _bn3);
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = token.OOME == null || token.OOME._AAB() == null;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    _bb4._ACW _AMI = token.OOME.OOME;
                    bool flag4 = _AMI == null;
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        string text = _AMI._AHB();
                        switch (token.OOME._AAB()._AT)
                        {
                            case SymbolKind.Field:
                            case SymbolKind.ConstantField:
                            case SymbolKind.LocalConstant:
                            case SymbolKind.Property:
                            case SymbolKind.Event:
                            case SymbolKind.Parameter:
                            case SymbolKind.CatchParameter:
                            case SymbolKind.Variable:
                            case SymbolKind.CaseVariable:
                            case SymbolKind.ForEachVariable:
                            case SymbolKind.FromClauseVariable:
                            case SymbolKind.OutVariable:
                                {
                                    bool flag5 = text == "localVariableDeclarator";
                                    if (flag5)
                                    {
                                        bool flag6 = _AMI._AIX == 1;
                                        if (flag6)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        bool flag7 = text == "variableDeclarator" || text == "eventDeclarator";
                                        if (!flag7)
                                        {
                                            bool flag8 = text == "foreachStatement";
                                            if (!flag8)
                                            {
                                                bool flag9 = text == "memberInitializer";
                                                if (!flag9)
                                                {
                                                    bool flag10 = text == "fixedParameter" || text == "parameterArray";
                                                    if (!flag10)
                                                    {
                                                        bool flag11 = text == "constantDeclarator";
                                                        if (!flag11)
                                                        {
                                                            bool flag12 = text == "eventDeclarator";
                                                            if (!flag12)
                                                            {
                                                                bool flag13 = text == "catchExceptionIdentifier";
                                                                if (!flag13)
                                                                {
                                                                    bool flag14 = text == "caseVariableDeclarator";
                                                                    if (!flag14)
                                                                    {
                                                                        bool flag15 = text == "outVariableDeclarator";
                                                                        if (!flag15)
                                                                        {
                                                                            bool flag16 = text == "qidStart";
                                                                            if (flag16)
                                                                            {
                                                                                bool flag17 = _AMI._AIL < _AMI.OOME._AIX - 1;
                                                                                if (flag17)
                                                                                {
                                                                                    break;
                                                                                }
                                                                                bool flag18 = _AMI._AIX == 3 && token.OOME._AIL != 2;
                                                                                if (flag18)
                                                                                {
                                                                                    break;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                bool flag19 = text == "accessIdentifier" && _AMI.OOME._AHB() == "qidPart";
                                                                                if (flag19)
                                                                                {
                                                                                    bool flag20 = _AMI.OOME._AIL < _AMI.OOME.OOME._AIX - 1;
                                                                                    if (flag20)
                                                                                    {
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    bool flag21 = (text == "primaryExpressionStart" && _AMI.OOME._AIX == 1) || (text == "accessIdentifier" && _AMI.OOME._AHB() == "primaryExpressionPart" && _AMI.OOME._AIL == _AMI.OOME.OOME._AIX - 1);
                                                                                    if (flag21)
                                                                                    {
                                                                                        _bb4._ACW _AGZ = ((text == "accessIdentifier") ? _AMI.OOME.OOME : _AMI.OOME);
                                                                                        _bb4._ACW _AGZ2 = _AGZ.OOME.OOME;
                                                                                        text = _AGZ2._AHB();
                                                                                        bool flag22 = text != "preIncrementExpression" && text != "preDecrementExpression";
                                                                                        if (flag22)
                                                                                        {
                                                                                            _bb4.DHBA _AEM = _AGZ.OOME.LeafAt(1);
                                                                                            bool flag23 = _AEM == null || (!_AEM.IsLit("++") && !_AEM.IsLit("--"));
                                                                                            if (flag23)
                                                                                            {
                                                                                                bool flag24 = text != "assignment" || _AGZ.OOME._AIL != 0;
                                                                                                if (flag24)
                                                                                                {
                                                                                                    while (_AGZ2 != null && _AGZ2._AHB() != "expression")
                                                                                                    {
                                                                                                        _AGZ2 = _AGZ2.OOME;
                                                                                                    }
                                                                                                    bool flag25 = _AGZ2 == null || _AGZ2.OOME._AHB() != "variableReference";
                                                                                                    if (flag25)
                                                                                                    {
                                                                                                        break;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        _bb4.DHBA _AEM2 = token.OOME.FindPreviousLeaf();
                                                                                        bool flag26 = _AEM2 == null || (!_AEM2.IsLit("ref") && !_AEM2.IsLit("out"));
                                                                                        if (flag26)
                                                                                        {
                                                                                            _bb4.DHBA _AEM3 = token.OOME.FindNextLeaf();
                                                                                            bool flag27 = _AEM3 == null || _AEM3.OOME._AHB() != "assignmentOperator";
                                                                                            if (flag27)
                                                                                            {
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
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    return true;
                                }
                        }
                        flag2 = false;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x040005CC RID: 1484
        private static List<_bi7> _APY = new List<_bi7>();

        // Token: 0x040005CD RID: 1485
        private static List<_bg6> _APZ = new List<_bg6>();
    }
}
