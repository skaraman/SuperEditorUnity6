using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000B5 RID: 181
    internal class _bn3 : _bh4
    {
        // Token: 0x06000541 RID: 1345 RVA: 0x000D2294 File Offset: 0x000D0494
        internal override _bh4 TypeOf()
        {
            bool ofdaedbmnafldiagfdnddbgcbobdlfnmcijk = this.OFDAEDBMNAFLDIAGFDNDDBGCBOBDLFNMCIJK;
            _bh4 _AAH;
            if (ofdaedbmnafldiagfdnddbgcbobdlfnmcijk)
            {
                _AAH = _bh4._AHA;
            }
            else
            {
                this.OFDAEDBMNAFLDIAGFDNDDBGCBOBDLFNMCIJK = true;
                bool flag = this.BLH != null && (this.BLH.definition == null || !this.BLH.definition.IsValid());
                if (flag)
                {
                    this.BLH = null;
                }
                bool flag2 = this.BLH == null;
                if (flag2)
                {
                    FKI _AFF = ((this._AEI != null) ? this._AEI.FirstOrDefault<FKI>() : null);
                    bool flag3 = _AFF != null && _AFF._AEJ != null && _AFF._AEJ.OOME != null;
                    if (flag3)
                    {
                        _bb4._AIN _AIO = null;
                        switch (_AFF._AT)
                        {
                            case SymbolKind.Field:
                                _AIO = _AFF._AEJ.OOME.OOME.OOME.FindChildByName("type");
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                goto IL_0435;
                            case SymbolKind.ConstantField:
                            case SymbolKind.LocalConstant:
                                {
                                    string text = _AFF._AEJ.OOME.OOME._AHB();
                                    string text2 = text;
                                    if (!(text2 == "constantDeclaration") && !(text2 == "localConstantDeclaration"))
                                    {
                                        _AIO = _AFF._AEJ.OOME.OOME.OOME.FindChildByName("IDENTIFIER");
                                    }
                                    else
                                    {
                                        _AIO = _AFF._AEJ.OOME.OOME.ChildAt(1);
                                    }
                                    this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                    goto IL_0435;
                                }
                            case SymbolKind.EnumMember:
                                this.BLH = new KJK(this._AO);
                                goto IL_0435;
                            case SymbolKind.Property:
                            case SymbolKind.Indexer:
                                _AIO = _AFF._AEJ.OOME.FindChildByName("type");
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                goto IL_0435;
                            case SymbolKind.Event:
                                _AIO = _AFF._AEJ.FindParentByName("eventDeclaration").ChildAt(1);
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                goto IL_0435;
                            case SymbolKind.Parameter:
                                {
                                    bool flag4 = _AFF._AEJ._AHB() == "implicitAnonymousFunctionParameter";
                                    if (flag4)
                                    {
                                        this.BLH = this.TypeOfImplicitParameter(_AFF);
                                    }
                                    else
                                    {
                                        _AIO = _AFF._AEJ.FindChildByName("type");
                                        this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                    }
                                    goto IL_0435;
                                }
                            case SymbolKind.CatchParameter:
                                _AIO = _AFF._AEJ.OOME.FindChildByName("exceptionClassType");
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                goto IL_0435;
                            case SymbolKind.Variable:
                                {
                                    bool flag5 = _AFF._AEJ.OOME.OOME != null;
                                    if (flag5)
                                    {
                                        _AIO = _AFF._AEJ.OOME.OOME.FindChildByName("localVariableType");
                                    }
                                    this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                    goto IL_0435;
                                }
                            case SymbolKind.CaseVariable:
                                _AIO = _AFF._AEJ.OOME.FindChildByName("localVariableType");
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                goto IL_0435;
                            case SymbolKind.ForEachVariable:
                                _AIO = _AFF._AEJ.FindChildByName("localVariableType");
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                goto IL_0435;
                            case SymbolKind.FromClauseVariable:
                                _AIO = _AFF._AEJ.FindChildByName("type");
                                this.BLH = ((_AIO != null) ? new KJK(_AIO) : new KJK(_bh4.EnumerableElementType(_AFF._AEJ.NodeAt(-1))));
                                goto IL_0435;
                            case SymbolKind.OutVariable:
                                {
                                    bool flag6 = _AFF._AEJ.OOME != null;
                                    if (flag6)
                                    {
                                        _AIO = _AFF._AEJ.OOME.NodeAt(0);
                                    }
                                    this.BLH = ((_AIO != null) ? new KJK(_AIO) : null);
                                    goto IL_0435;
                                }
                        }
                        Debug.LogError(_AFF._AT);
                    IL_0435:;
                    }
                }
                _bh4 _AAH2 = ((this.BLH != null) ? this.BLH.definition : _bh4._AHA);
                this.OFDAEDBMNAFLDIAGFDNDDBGCBOBDLFNMCIJK = false;
                _AAH = _AAH2;
            }
            return _AAH;
        }

        // Token: 0x06000542 RID: 1346 RVA: 0x000D2700 File Offset: 0x000D0900
        private KJK TypeOfImplicitParameter(FKI declaration)
        {
            int num = 0;
            _bb4._ACW _AGZ = declaration._AEJ;
            bool flag = _AGZ.OOME._AHB() == "implicitAnonymousFunctionParameterList";
            if (flag)
            {
                num = (int)(_AGZ._AIL / 2);
                _AGZ = _AGZ.OOME;
            }
            _AGZ = _AGZ.OOME;
            _AGZ = _AGZ.OOME;
            _AGZ = _AGZ.OOME;
            _AGZ = _AGZ.OOME;
            bool flag2 = _AGZ._AHB() == "elementInitializer";
            if (flag2)
            {
                _AGZ = _AGZ.OOME.OOME.OOME.OOME.OOME;
                bool flag3 = _AGZ._AHB() != "primaryExpression";
                if (flag3)
                {
                    return null;
                }
                _AGZ = _AGZ.NodeAt(1);
                bool flag4 = _AGZ == null || _AGZ._AHB() != "nonArrayType";
                if (flag4)
                {
                    return null;
                }
                _b2 _AAC = _bh4.ResolveNode(_AGZ.ChildAt(0), null, null, 0, false).TypeOf() as _b2;
                bool flag5 = _AAC != null && _AAC._AT != SymbolKind.Error;
                if (flag5)
                {
                    _bi5 _AAE = _AAC.ConvertTo(_bh4._BFJ) as _bi5;
                    KJK _AAD = ((_AAE == null || _AAE._AHH == null) ? null : _AAE._AHH.FirstOrDefault<KJK>());
                    _bh4 _AAH = ((_AAD == null) ? null : _AAD.definition);
                    bool flag6 = _AAH != null && _AAH._AT == SymbolKind.Delegate;
                    if (flag6)
                    {
                        List<_bm1> parameters = _AAH.GetParameters();
                        bool flag7 = parameters != null && num < parameters.Count;
                        if (flag7)
                        {
                            _bh4 _AAH2 = parameters[num].TypeOf();
                            _AAH2 = _AAH2.SubstituteTypeParameters(_AAH);
                            return new KJK(_AAH2);
                        }
                    }
                }
            }
            bool flag8 = _AGZ._AHB() == "expression" && (_AGZ.OOME._AHB() == "localVariableInitializer" || _AGZ.OOME._AHB() == "variableInitializer");
            if (flag8)
            {
                _AGZ = _AGZ.OOME.OOME;
                bool flag9 = _AGZ._AHB() == "variableInitializerList";
                if (flag9)
                {
                    _AGZ = _AGZ.OOME.OOME.OOME.NodeAt(1);
                    bool flag10 = _AGZ == null || _AGZ._AHB() != "nonArrayType";
                    if (flag10)
                    {
                        return null;
                    }
                }
                else
                {
                    bool flag11 = _AGZ._AHB() != "localVariableDeclarator" && _AGZ._AHB() != "variableDeclarator";
                    if (flag11)
                    {
                        return null;
                    }
                }
                _bh4 _AAH3 = _AGZ.ChildAt(0)._AAB() ?? _bh4.ResolveNode(_AGZ.ChildAt(0), null, null, 0, false);
                bool flag12 = _AAH3 != null && _AAH3._AT != SymbolKind.Error;
                if (flag12)
                {
                    _bh4 _AAH4 = ((_AAH3._AT == SymbolKind.Delegate) ? _AAH3 : _AAH3.TypeOf());
                    bool flag13 = _AAH4 != null && _AAH4._AT == SymbolKind.Delegate;
                    if (flag13)
                    {
                        List<_bm1> parameters2 = _AAH4.GetParameters();
                        bool flag14 = parameters2 != null && num < parameters2.Count;
                        if (flag14)
                        {
                            _bh4 _AAH5 = parameters2[num].TypeOf();
                            _AAH5 = _AAH5.SubstituteTypeParameters(_AAH4);
                            return new KJK(_AAH5);
                        }
                    }
                }
            }
            else
            {
                bool flag15 = _AGZ._AHB() == "expression" && _AGZ.OOME._AHB() == "argumentValue";
                if (flag15)
                {
                    _AGZ = _AGZ.OOME;
                    bool flag16 = _AGZ._AIL == 0;
                    if (flag16)
                    {
                        _AGZ = _AGZ.OOME;
                        int num2 = (int)(_AGZ._AIL / 2);
                        _AGZ = _AGZ.OOME;
                        _AGZ = _AGZ.OOME;
                        _AGZ = _AGZ.OOME;
                        bool flag17 = _AGZ._AHB() == "primaryExpressionPart";
                        if (flag17)
                        {
                            _bb4.DHBA _AEM = null;
                            _AGZ = _AGZ.OOME.NodeAt((int)(_AGZ._AIL - 1));
                            bool flag18 = _AGZ._AHB() == "primaryExpressionStart";
                            if (flag18)
                            {
                                _AEM = _AGZ.LeafAt(0);
                            }
                            else
                            {
                                _AGZ = _AGZ.NodeAt(0);
                                bool flag19 = _AGZ._AHB() == "accessIdentifier";
                                if (flag19)
                                {
                                    _AEM = _AGZ.LeafAt(1);
                                }
                            }
                            bool flag20 = _AEM != null && _AEM._ACX.tokenKind == SyntaxToken.Kind.Identifier;
                            if (flag20)
                            {
                                bool flag21 = _AEM._AAB() == null || _AEM._AAB()._AT == SymbolKind.MethodGroup || _AEM._AAB()._AT == SymbolKind.Error;
                                if (flag21)
                                {
                                    _bc9.GetResolvedSymbol(_AEM);
                                }
                                _b2 _AAC2 = null;
                                _bb3 _AAN = _AEM._AAB() as _bb3;
                                _bm7 _BFS = _AEM._AAB() as _bm7;
                                bool flag22 = _BFS != null && _BFS._AT == SymbolKind.Method;
                                if (flag22)
                                {
                                    _AAN = _BFS._CBS() as _bb3;
                                }
                                bool flag23 = _AAN != null && _AAN.IsExtensionMethod;
                                if (flag23)
                                {
                                    _bb4._ACW _AGZ2 = _AEM.OOME;
                                    bool flag24 = _AGZ2 != null && _AGZ2._AHB() == "accessIdentifier";
                                    if (flag24)
                                    {
                                        _AGZ2 = _AGZ2.FindPreviousNode() as _bb4._ACW;
                                        bool flag25 = _AGZ2 != null;
                                        if (flag25)
                                        {
                                            bool flag26 = _AGZ2._AHB() == "primaryExpressionPart" || _AGZ2._AHB() == "primaryExpressionStart";
                                            if (flag26)
                                            {
                                                _bh4 resolvedSymbol = _bc9.GetResolvedSymbol(_AGZ2);
                                                bool flag27 = resolvedSymbol != null && resolvedSymbol._AT != SymbolKind.Error && !(resolvedSymbol is _b2);
                                                if (flag27)
                                                {
                                                    num2++;
                                                    _AAC2 = resolvedSymbol.TypeOf() as _b2;
                                                    bool flag28 = _AAC2 != null && _AAC2._AT == SymbolKind.Error;
                                                    if (flag28)
                                                    {
                                                        _AAC2 = null;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                num2++;
                                            }
                                        }
                                    }
                                }
                                bool flag29 = _AAN != null;
                                if (flag29)
                                {
                                    List<_bm1> parameters3 = _AAN.GetParameters();
                                    bool flag30 = parameters3 != null && num2 < parameters3.Count;
                                    if (flag30)
                                    {
                                        _bm1 _AGS = parameters3[num2];
                                        _bh4 _AAH6 = _AGS.TypeOf();
                                        bool flag31 = _AAH6._AT == SymbolKind.Delegate;
                                        if (flag31)
                                        {
                                            bool flag32 = _BFS != null;
                                            if (flag32)
                                            {
                                                _AAH6 = _AAH6.SubstituteTypeParameters(_BFS);
                                            }
                                            else
                                            {
                                                _AAH6 = _AAH6.SubstituteTypeParameters(_AAN);
                                            }
                                            List<_bm1> parameters4 = _AAH6.GetParameters();
                                            bool flag33 = parameters4 != null && num < parameters4.Count;
                                            if (flag33)
                                            {
                                                _bh4 _AAH7 = parameters4[num].TypeOf();
                                                _AAH7 = _AAH7.SubstituteTypeParameters(_AAH6);
                                                bool flag34 = _BFS != null;
                                                if (flag34)
                                                {
                                                    _AAH7 = _AAH7.SubstituteTypeParameters(_BFS);
                                                }
                                                else
                                                {
                                                    _AAH7 = _AAH7.SubstituteTypeParameters(_AAN);
                                                }
                                                bool flag35 = _AAC2 != null;
                                                if (flag35)
                                                {
                                                    _AAH7 = _AAH7.SubstituteTypeParameters(_AAC2);
                                                }
                                                return new KJK(_AAH7);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        // Token: 0x06000543 RID: 1347 RVA: 0x000D2DF8 File Offset: 0x000D0FF8
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            if (asTypeOnly)
            {
                leaf._ACY(null);
            }
            else
            {
                this.TypeOf();
                bool flag = this.BLH == null || this.BLH.definition == null || this.BLH.definition == _bh4._AHA || this.BLH.definition == _bh4._AAA;
                if (flag)
                {
                    leaf._ACY(null);
                }
                else
                {
                    this.BLH.definition.ResolveMember(leaf, context, numTypeArgs, false);
                }
            }
        }

        // Token: 0x06000544 RID: 1348 RVA: 0x000D2E80 File Offset: 0x000D1080
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            _bh4 _AAH = this.TypeOf();
            bool flag = _AAH != null;
            if (flag)
            {
                _AAH.GetMembersCompletionData(data, BindingFlags.Instance, mask, context);
            }
        }

        // Token: 0x040004FC RID: 1276
        public KJK BLH;

        // Token: 0x040004FD RID: 1277
        private bool OFDAEDBMNAFLDIAGFDNDDBGCBOBDLFNMCIJK = false;
    }
}
