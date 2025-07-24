using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000C6 RID: 198
    internal class _ba7 : _bh4
    {
        // Token: 0x0600057F RID: 1407 RVA: 0x000D485C File Offset: 0x000D2A5C
        internal virtual void AddMethod(_bb3 method)
        {
            int count = this._AAM.Count;
            while (count-- > 0)
            {
                bool flag = !this._AAM[count].IsValid();
                if (flag)
                {
                    this._AAM.RemoveAt(count);
                }
            }
            bool flag2 = method._AEI != null;
            if (flag2)
            {
                FKI _AFF = method._AEI[0];
                int count2 = this._AAM.Count;
                while (count2-- > 0)
                {
                    bool flag3 = this._AAM[count2].ContainsDeclaration(_AFF);
                    if (flag3)
                    {
                        this._AAM.RemoveAt(count2);
                        break;
                    }
                }
            }
            this._AAM.Add(method);
            method._AO = this;
        }

        // Token: 0x06000580 RID: 1408 RVA: 0x000D4928 File Offset: 0x000D2B28
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            return base.AddDeclaration(symbol);
        }

        // Token: 0x06000581 RID: 1409 RVA: 0x000D4944 File Offset: 0x000D2B44
        internal override void RemoveDeclaration(FKI symbol)
        {
            int count = this._AAM.Count;
            while (count-- > 0)
            {
                bool flag = this._AAM[count].ContainsDeclaration(symbol);
                if (flag)
                {
                    this._AAM.RemoveAt(count);
                    break;
                }
            }
        }

        // Token: 0x06000582 RID: 1410 RVA: 0x000D4994 File Offset: 0x000D2B94
        public _bh4 ResolveParameterName(_bb4.DHBA leaf)
        {
            List<_bb3> list = this._AAM;
            bool flag = list.Count == 0;
            if (flag)
            {
                _ba7 _AAK = this.GetGenericSymbol() as _ba7;
                bool flag2 = _AAK != null;
                if (flag2)
                {
                    list = _AAK._AAM;
                }
            }
            string text = _bh4.DecodeId(leaf._ACX.text);
            int count = list.Count;
            _bh4 _AAH;
            while (count-- > 0)
            {
                _bb3 _AAN = list[count];
                List<_bm1> parameters = _AAN.GetParameters();
                int count2 = parameters.Count;
                while (count2-- > 0)
                {
                    _bm1 _AGS = parameters[count2];
                    bool flag3 = _AGS._AW == text;
                    if (flag3)
                    {
                        leaf._ACY(_AAH = _AGS);
                        return _AAH;
                    }
                }
            }
            leaf._ACY(_AAH = _bh4._AGT);
            return _AAH;
        }

        // Token: 0x06000583 RID: 1411 RVA: 0x000D4A7C File Offset: 0x000D2C7C
        internal override _bh4 Rebind()
        {
            bool flag = this._AO == null && this._AGU == null;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = this;
            }
            else
            {
                _bh4 _AAH2 = (this._AO ?? this._AGU).Rebind();
                bool flag2 = _AAH2 == null;
                if (flag2)
                {
                    _AAH = null;
                }
                else
                {
                    bool flag3 = _AAH2 == this._AO;
                    if (flag3)
                    {
                        _AAH = this;
                    }
                    else
                    {
                        _bh4 _AAH3 = _AAH2.FindName(this._AW, -1, false);
                        _AAH = _AAH3;
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x06000584 RID: 1412 RVA: 0x000D4AF4 File Offset: 0x000D2CF4
        public static int ProcessArgumentListNode(_bb4._ACW argumentListNode, _b2 extendedType)
        {
            int num = 0;
            int num2 = (int)((argumentListNode == null) ? 0 : ((argumentListNode._AIX + 1) / 2));
            bool flag = extendedType != null;
            if (flag)
            {
                num = 1;
                num2++;
                _ba7._AGV.Add(Modifiers.This);
                _ba7._AGW.Add(extendedType);
                _ba7._AGX.Add(null);
                _ba7._AGY.Add(null);
            }
            int i = num;
            while (i < num2)
            {
                _bb4._ACW _AGZ = argumentListNode.NodeAt((i - num) * 2);
                bool flag2 = _AGZ != null;
                if (flag2)
                {
                    _bb4._ACW _AGZ2 = _AGZ.FindChildByName("argumentValue") as _bb4._ACW;
                    bool flag3 = _AGZ2 != null;
                    if (flag3)
                    {
                        _bh4 _AAH = _bh4.ResolveNode(_AGZ2, null, null, 0, false);
                        _ba7._AGX.Add(_AAH);
                        _ba7._AGW.Add(_bh4._AHA);
                        _ba7._AGV.Add(Modifiers.None);
                        _ba7._AGY.Add(null);
                        bool flag4 = _AAH != null;
                        if (flag4)
                        {
                            _ba7._AGW[_ba7._AGW.Count - 1] = (_AAH.TypeOf() as _b2) ?? _bh4._AHA;
                        }
                        _bb4.DHBA _AEM = _AGZ2.LeafAt(0);
                        bool flag5 = _AEM != null;
                        if (flag5)
                        {
                            bool flag6 = _AEM.IsLit("ref");
                            if (flag6)
                            {
                                _ba7._AGV[_ba7._AGV.Count - 1] = Modifiers.Ref;
                            }
                            else
                            {
                                bool flag7 = _AEM.IsLit("out");
                                if (flag7)
                                {
                                    _ba7._AGV[_ba7._AGV.Count - 1] = Modifiers.Out;
                                }
                                else
                                {
                                    bool flag8 = _AEM.IsLit("in");
                                    if (flag8)
                                    {
                                        _ba7._AGV[_ba7._AGV.Count - 1] = Modifiers.In;
                                    }
                                }
                            }
                        }
                        _bb4._ACW _AGZ3 = _AGZ.NodeAt(0);
                        bool flag9 = _AGZ3._AHB() == "argumentName";
                        if (flag9)
                        {
                            _bb4.DHBA _AEM2 = _AGZ3.LeafAt(0);
                            bool flag10 = _AEM2 != null && _AEM2._ACX.tokenKind == SyntaxToken.Kind.Identifier;
                            if (flag10)
                            {
                                _ba7._AGY[_ba7._AGY.Count - 1] = _AEM2._ACX.text;
                            }
                        }
                        i++;
                        continue;
                    }
                }
                num2 = i;
                break;
            }
            return num2;
        }

        // Token: 0x06000585 RID: 1413 RVA: 0x000D4D50 File Offset: 0x000D2F50
        public static _bb3 CheckNamedArguments(int numArguments)
        {
            int num = _ba7._AGY.Count - numArguments;
            for (int i = 0; i < numArguments; i++)
            {
                bool flag = _ba7._AGY[num + i] == null;
                if (!flag)
                {
                    for (int j = i; j < numArguments; j++)
                    {
                        string text = _ba7._AGY[num + j];
                        bool flag2 = string.IsNullOrEmpty(text);
                        if (flag2)
                        {
                            return _ba7._AHC;
                        }
                        for (int k = j + 1; k < numArguments; k++)
                        {
                            bool flag3 = text == _ba7._AGY[num + k];
                            if (flag3)
                            {
                                return _ba7._AHC;
                            }
                        }
                    }
                    break;
                }
            }
            return null;
        }

        // Token: 0x06000586 RID: 1414 RVA: 0x000D4E18 File Offset: 0x000D3018
        internal override _bh4 ResolveMethodOverloads(_bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            bool flag = invokedLeaf != null && !invokedLeaf.HasErrors() && invokedLeaf._AAB() is _bb3;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = invokedLeaf._AAB();
            }
            else
            {
                int count = _ba7._AGV.Count;
                int num = _ba7.ProcessArgumentListNode(argumentListNode, null);
                _bb3 _AAN = _ba7.CheckNamedArguments(num);
                _bb3 _AAN2 = _AAN ?? this.ResolveMethodOverloads(num, scope, invokedLeaf);
                _ba7._AGV.RemoveRange(count, num);
                _ba7._AGW.RemoveRange(count, num);
                _ba7._AGX.RemoveRange(count, num);
                _ba7._AGY.RemoveRange(count, num);
                _AAH = _AAN2;
            }
            return _AAH;
        }

        // Token: 0x06000587 RID: 1415 RVA: 0x000D4EBC File Offset: 0x000D30BC
        internal virtual int CollectCandidates(int numArguments, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            bool flag = this._AO == null && this._AGU != null;
            if (flag)
            {
                this.Rebind();
            }
            bool flag2 = this._AO == null;
            int num;
            if (flag2)
            {
                num = 0;
            }
            else
            {
                AccessLevelMask accessLevelMask = AccessLevelMask.Public;
                _b2 _AAC = (this._AO as _b2) ?? (this._AO._AO as _b2);
                _bc6 _AHD = ((scope == null) ? null : scope.EnclosingType());
                bool flag3 = _AHD != null;
                if (flag3)
                {
                    bool flag4 = _AAC.Assembly != null && _AAC.Assembly.InternalsVisibleIn(_AHD.Assembly);
                    if (flag4)
                    {
                        accessLevelMask |= AccessLevelMask.Internal;
                    }
                    bool flag5 = _AHD == _AAC || _AAC.IsSameOrParentOf(_AHD);
                    if (flag5)
                    {
                        accessLevelMask |= AccessLevelMask.Private | AccessLevelMask.Protected | AccessLevelMask.Public;
                    }
                    else
                    {
                        bool flag6 = _AHD.DerivesFrom(_AAC);
                        if (flag6)
                        {
                            accessLevelMask |= AccessLevelMask.Protected | AccessLevelMask.Public;
                        }
                    }
                }
                int count = _ba7._AHE.Count;
                for (int i = 0; i < this._AAM.Count; i++)
                {
                    _bb3 _AAN = this._AAM[i];
                    bool flag7 = !_AAN._AHF() && _AAN.IsAccessible(accessLevelMask) && (numArguments == -1 || _AAN.CanCallWith(numArguments, false));
                    if (flag7)
                    {
                        _ba7._AHE.Add(_AAN);
                    }
                }
                int num2 = _ba7._AHE.Count - count;
                _bd1 _ABB = this as _bd1;
                int num3 = num2;
                while (num3-- > 0)
                {
                    _bb3 _AAN2 = _ba7._AHE[count + num3];
                    bool flag8 = _ABB == null;
                    if (flag8)
                    {
                        bool flag9 = invokedLeaf == null;
                        if (!flag9)
                        {
                            bool flag10 = _AAN2._AHG() == 0 || numArguments == -1;
                            if (!flag10)
                            {
                                _AAN2 = _ba7.InferMethodTypeArguments(_AAN2, numArguments, invokedLeaf);
                                bool flag11 = _AAN2 == null;
                                if (flag11)
                                {
                                    _ba7._AHE.RemoveAt(count + num3);
                                }
                                else
                                {
                                    _ba7._AHE[count + num3] = _AAN2;
                                }
                            }
                        }
                    }
                    else
                    {
                        _ba7._AHE[count + num3] = _AAN2.ConstructMethod(_ABB._AHH);
                    }
                }
                num2 = _ba7._AHE.Count - count;
                bool flag12 = num2 != 0 && numArguments != -1;
                if (flag12)
                {
                    num = num2;
                }
                else
                {
                    _b2 _AAC2 = (_b2)this._AO;
                    while ((_AAC2 = _AAC2.BaseType()) != null)
                    {
                        _ba7 _AAK = _AAC2.FindName(this._AW, 0, false) as _ba7;
                        bool flag13 = _AAK != null;
                        if (flag13)
                        {
                            return num2 + _AAK.CollectCandidates(numArguments, scope, invokedLeaf);
                        }
                    }
                    num = num2;
                }
            }
            return num;
        }

        // Token: 0x06000588 RID: 1416 RVA: 0x000D515C File Offset: 0x000D335C
        private static List<int> GenerateRangeList(int to)
        {
            List<int> list = ((_ba7._AHI.Count > 0) ? _ba7._AHI.Pop() : new List<int>(to));
            for (int i = 0; i < to; i++)
            {
                list.Add(i);
            }
            return list;
        }

        // Token: 0x06000589 RID: 1417 RVA: 0x000D51A7 File Offset: 0x000D33A7
        private static void ReleaseRangeList(List<int> list)
        {
            list.Clear();
            _ba7._AHI.Push(list);
        }

        // Token: 0x0600058A RID: 1418 RVA: 0x000D51C0 File Offset: 0x000D33C0
        private static List<_b2> CreateTypeList()
        {
            return (_ba7._AHJ.Count > 0) ? _ba7._AHJ.Pop() : new List<_b2>();
        }

        // Token: 0x0600058B RID: 1419 RVA: 0x000D51F0 File Offset: 0x000D33F0
        private static void ReleaseTypeList(List<_b2> list)
        {
            list.Clear();
            _ba7._AHJ.Push(list);
        }

        // Token: 0x0600058C RID: 1420 RVA: 0x000D5208 File Offset: 0x000D3408
        public static _bb3 InferMethodTypeArguments(_bb3 method, int numArguments, _bb4.DHBA invokedLeaf)
        {
            int num = _ba7._AGW.Count - numArguments;
            int num2 = method._AHG();
            List<_b2> list = _ba7.CreateTypeList();
            List<_bd7> _AHK = method._AHL;
            for (int i = 0; i < _AHK.Count; i++)
            {
                _bd7 _AHM = _AHK[i];
                list.Add(_AHM.SubstituteTypeParameters(method));
            }
            List<_bm1> parameters = method.GetParameters();
            int num3 = Math.Min(parameters.Count, numArguments);
            List<int> list2 = _ba7.GenerateRangeList(num2);
            bool flag = true;
            while (flag)
            {
                flag = false;
                int count = list2.Count;
                while (count-- > 0)
                {
                    int num4 = list2[count];
                    _b2 _AAC = list[num4];
                    int num5 = num3;
                    while (num5-- > 0)
                    {
                        _b2 _AAC2 = _ba7._AGW[num + num5];
                        bool flag2 = _AAC2 == null;
                        if (!flag2)
                        {
                            _bm1 _AGS = parameters[num5];
                            _b2 _AAC3 = _AGS.TypeOf() as _b2;
                            _AAC3 = _AAC3.SubstituteTypeParameters(method);
                            bool flag3 = _AAC3 != null && _AAC3.IsValid();
                            if (flag3)
                            {
                                _b2 _AAC4 = _AAC3.BindTypeArgument(_AAC, _AAC2);
                                bool flag4 = _AAC4 != null && _AAC4 != _AAC && _AAC4._AT != SymbolKind.Error;
                                if (flag4)
                                {
                                    list[num4] = _AAC4;
                                    list2.RemoveAt(count);
                                    flag = list2.Count > 0;
                                    bool flag5 = flag;
                                    if (flag5)
                                    {
                                        KJK[] array = new KJK[list.Count];
                                        int count2 = list.Count;
                                        while (count2-- > 0)
                                        {
                                            array[count2] = new KJK(list[count2]);
                                        }
                                        method = method.ConstructMethod(array);
                                        bool flag6 = invokedLeaf != null;
                                        if (flag6)
                                        {
                                            invokedLeaf._ACY(method);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            _ba7.ReleaseRangeList(list2);
            KJK[] array2 = new KJK[num2];
            for (int j = 0; j < num2; j++)
            {
                array2[j] = new KJK(list[j] ?? _bh4._AS);
            }
            method = method.ConstructMethod(array2);
            _ba7.ReleaseTypeList(list);
            return method;
        }

        // Token: 0x0600058D RID: 1421 RVA: 0x000D5464 File Offset: 0x000D3664
        internal virtual _bb3 ResolveMethodOverloads(int numArguments, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            int count = _ba7._AHE.Count;
            int num = this.CollectCandidates(numArguments, scope, invokedLeaf);
            bool flag = num == 0;
            _bb3 _AAN;
            if (flag)
            {
                _AAN = _ba7._AHN;
            }
            else
            {
                _bb3 _AAN2 = _ba7.ResolveMethodOverloads(numArguments, num);
                bool flag2 = _ba7._AHE.Count > count;
                if (flag2)
                {
                    _ba7._AHE.RemoveRange(count, _ba7._AHE.Count - count);
                }
                _AAN = _AAN2;
            }
            return _AAN;
        }

        // Token: 0x0600058E RID: 1422 RVA: 0x000D54D4 File Offset: 0x000D36D4
        public static _bb3 ResolveMethodOverloads(int numArguments, int numCandidates)
        {
            int num = _ba7._AGW.Count - numArguments;
            int num2 = _ba7._AHE.Count - numCandidates;
            int i;
            for (i = numArguments; i > 0; i--)
            {
                string text = _ba7._AGY[num + i - 1];
                bool flag = text == null;
                if (flag)
                {
                    break;
                }
            }
            _bb3 _AAN = null;
            int num3 = -1;
            int num4 = 0;
            int j = 0;
            while (j < numCandidates)
            {
                _bb3 _AAN2 = _ba7._AHE[num2 + j];
                List<_bm1> parameters = _AAN2.GetParameters();
                bool flag2 = true;
                int num5;
                for (; ; )
                {
                    num5 = 0;
                    _bm1 _AGS = null;
                    int num6 = Mathf.Min(numArguments, parameters.Count);
                    int k = 0;
                    while (k < num6)
                    {
                        int l = k;
                        bool flag3 = l >= i;
                        if (flag3)
                        {
                            string text2 = _ba7._AGY[num + k];
                            for (l = i; l < parameters.Count; l++)
                            {
                                bool flag4 = text2 == parameters[l]._AW;
                                if (flag4)
                                {
                                    break;
                                }
                            }
                            bool flag5 = l == parameters.Count;
                            if (flag5)
                            {
                                num5 = -1;
                                break;
                            }
                        }
                        bool flag6 = flag2 && _AGS == null && parameters[l]._AHO();
                        if (flag6)
                        {
                            _AGS = parameters[l];
                        }
                        _b2 _AAC = null;
                        bool flag7 = _AGS != null;
                        if (flag7)
                        {
                            _bm8 _AX = _AGS.TypeOf() as _bm8;
                            bool flag8 = _AX != null;
                            if (flag8)
                            {
                                _AAC = _AX._AHP.definition as _b2;
                            }
                        }
                        else
                        {
                            bool flag9 = l >= parameters.Count;
                            if (flag9)
                            {
                                num5 = -1;
                                break;
                            }
                            _AAC = parameters[l].TypeOf() as _b2;
                        }
                        _AAC = ((_AAC == null) ? _bh4._AHA : _AAC.SubstituteTypeParameters(_AAN2));
                        bool flag10 = _AAC._AT == SymbolKind.Delegate;
                        if (flag10)
                        {
                            _bh4 _AAH = _ba7._AGX[num + k];
                            bool flag11 = _AAH != null && _AAH._AT == SymbolKind.MethodGroup;
                            if (flag11)
                            {
                                _ba7 _AAK = _AAH as _ba7;
                                bool flag12 = _AAK != null;
                                if (flag12)
                                {
                                    _bb3 _AAN3 = _AAK.FindMatchingMethod(_AAC);
                                    bool flag13 = _AAN3 != null;
                                    if (flag13)
                                    {
                                        num5++;
                                        goto IL_0315;
                                    }
                                    num5 = -1;
                                    break;
                                }
                            }
                            goto IL_0240;
                        }
                        goto IL_0240;
                    IL_0315:
                        k++;
                        continue;
                    IL_0240:
                        _b2 _AAC2 = _ba7._AGW[num + k];
                        bool flag14 = _AAC2 == null || _AAC2 == _bh4._AHA;
                        if (flag14)
                        {
                            num5 = -1;
                            break;
                        }
                        bool flag15 = _AAC2.IsSameType(_AAC);
                        bool flag16 = flag15;
                        if (flag16)
                        {
                            bool _AHQ = _bd5._AHR;
                            if (_AHQ)
                            {
                                num5++;
                                goto IL_0315;
                            }
                            bool flag17 = parameters[l]._AHS();
                            bool flag18 = _ba7._AGV[num + k] == Modifiers.In;
                            bool flag19 = flag17 == flag18;
                            if (flag19)
                            {
                                num5++;
                                goto IL_0315;
                            }
                        }
                        bool flag20 = !flag15 && !_AAC2.CanConvertTo(_AAC);
                        if (!flag20)
                        {
                            goto IL_0315;
                        }
                        bool flag21 = numCandidates == 1 && _AAC2._AT == SymbolKind.TypeParameter;
                        if (flag21)
                        {
                            num5++;
                            goto IL_0315;
                        }
                        num5 = -1;
                        break;
                    }
                    bool flag22 = num5 < 0;
                    if (!flag22)
                    {
                        goto IL_034E;
                    }
                    bool flag23 = _AGS == null;
                    if (flag23)
                    {
                        break;
                    }
                    flag2 = false;
                }
            IL_039A:
                j++;
                continue;
            IL_034E:
                num4++;
                bool flag24 = num5 > num3;
                if (flag24)
                {
                    num3 = num5;
                    _AAN = _AAN2;
                }
                else
                {
                    bool flag25 = num5 == num3;
                    if (flag25)
                    {
                        bool flag26 = _AAN2._AHG() == 0 && _AAN._AHG() > 0;
                        if (flag26)
                        {
                            _AAN = _AAN2;
                        }
                    }
                }
                goto IL_039A;
            }
            bool flag27 = _AAN != null;
            _bb3 _AAN5;
            if (flag27)
            {
                List<_bm1> parameters2 = _AAN.GetParameters();
                int num7 = numArguments;
                while (num7-- > 0)
                {
                    int m = -1;
                    Modifiers modifiers = _ba7._AGV[num + num7];
                    bool flag28 = modifiers == Modifiers.Out;
                    if (flag28)
                    {
                        _bb4._ACW _AGZ = _ba7._AHT[num + num7].NodeAt(-1);
                        bool flag29 = _AGZ != null;
                        if (flag29)
                        {
                            _bb4._ACW _AGZ2 = _AGZ.NodeAt(1);
                            bool flag30 = _AGZ2 != null;
                            if (flag30)
                            {
                                _bb4._ACW _AGZ3 = _AGZ2.NodeAt(0);
                                bool flag31 = _AGZ3 != null;
                                if (flag31)
                                {
                                    _bb4._ACW _AGZ4 = _AGZ3.NodeAt(0);
                                    bool flag32 = _AGZ4 != null && _AGZ4._AHB() == "VAR";
                                    if (flag32)
                                    {
                                        bool flag33 = m == -1;
                                        if (flag33)
                                        {
                                            m = num7;
                                            bool flag34 = m >= i;
                                            if (flag34)
                                            {
                                                string text3 = _ba7._AGY[num + num7];
                                                for (m = i; m < parameters2.Count; m++)
                                                {
                                                    bool flag35 = text3 == parameters2[m]._AW;
                                                    if (flag35)
                                                    {
                                                        break;
                                                    }
                                                }
                                                bool flag36 = m == parameters2.Count;
                                                if (flag36)
                                                {
                                                }
                                            }
                                        }
                                        bool flag37 = m < parameters2.Count;
                                        if (flag37)
                                        {
                                            _bb4.DHBA _AEM = _AGZ4.LeafAt(0);
                                            _bh4 _AAH2 = parameters2[m].TypeOf();
                                            bool flag38 = _AAH2 != null;
                                            if (flag38)
                                            {
                                                _AAH2 = _AAH2.SubstituteTypeParameters(_AAN);
                                            }
                                            _AEM._ACY(_AAH2);
                                            _ba7._AGX[num + num7] = _AAH2;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    _ba7 _AAK2 = _ba7._AGX[num + num7] as _ba7;
                    bool flag39 = _AAK2 == null;
                    if (!flag39)
                    {
                        bool flag40 = _AAK2._AT == SymbolKind.MethodGroup;
                        if (flag40)
                        {
                            bool flag41 = m == -1;
                            if (flag41)
                            {
                                m = num7;
                                bool flag42 = m >= i;
                                if (flag42)
                                {
                                    string text4 = _ba7._AGY[num + num7];
                                    for (m = i; m < parameters2.Count; m++)
                                    {
                                        bool flag43 = text4 == parameters2[m]._AW;
                                        if (flag43)
                                        {
                                            break;
                                        }
                                    }
                                    bool flag44 = m == parameters2.Count;
                                    if (flag44)
                                    {
                                    }
                                }
                            }
                            bool flag45 = m < parameters2.Count;
                            if (flag45)
                            {
                                _bb3 _AAN4 = _AAK2.FindMatchingMethod(parameters2[m].TypeOf() as _b2);
                                bool flag46 = _AAN4 != null;
                                if (flag46)
                                {
                                    _ba7._AGX[num + num7] = _AAN4;
                                }
                            }
                        }
                    }
                }
                _AAN5 = _AAN;
            }
            else
            {
                bool flag47 = numCandidates <= 1;
                if (flag47)
                {
                    _AAN5 = _ba7._AHN;
                }
                else
                {
                    _AAN5 = ((num4 > 0) ? _ba7._AHU : _ba7._AHN);
                }
            }
            return _AAN5;
        }

        // Token: 0x0600058F RID: 1423 RVA: 0x000D5B88 File Offset: 0x000D3D88
        public _bb3 FindMatchingMethod(_b2 delegateType)
        {
            List<_bm1> list = delegateType.GetParameters() ?? _bh4._AHV;
            _b2 _AAC = delegateType.TypeOf() as _b2;
            _b2[] array = new _b2[list.Count];
            int count = list.Count;
            while (count-- > 0)
            {
                array[count] = (list[count].TypeOf() as _b2).SubstituteTypeParameters(delegateType);
            }
            int count2 = this._AAM.Count;
        IL_010C:
            while (count2-- > 0)
            {
                _bb3 _AAN = this._AAM[count2];
                List<_bm1> list2 = _AAN.GetParameters() ?? _bh4._AHV;
                bool flag = list2.Count != list.Count;
                if (!flag)
                {
                    int count3 = list2.Count;
                    while (count3-- > 0)
                    {
                        _bh4 _AAH = list2[count3].TypeOf();
                        bool flag2 = !_AAH.IsSameType(array[count3]);
                        if (flag2)
                        {
                            goto IL_010C;
                        }
                    }
                    bool flag3 = !_AAN.ReturnType().IsSameType(_AAC);
                    if (!flag3)
                    {
                        return _AAN;
                    }
                }
            }
            return null;
        }

        // Token: 0x06000590 RID: 1424 RVA: 0x000CC114 File Offset: 0x000CA314
        private bool CanConvertTo(_bd2 delegateType)
        {
            throw new NotImplementedException();
        }

        // Token: 0x06000591 RID: 1425 RVA: 0x000D5CBC File Offset: 0x000D3EBC
        internal override bool IsAccessible(AccessLevelMask accessLevelMask)
        {
            int count = this._AAM.Count;
            while (count-- > 0)
            {
                bool flag = this._AAM[count].IsAccessible(accessLevelMask);
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000592 RID: 1426 RVA: 0x000D5D04 File Offset: 0x000D3F04
        public _bd1 ConstructMethodGroup(KJK[] typeArgs)
        {
            string text = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = typeArgs != null;
            if (flag)
            {
                foreach (KJK _AAD in typeArgs)
                {
                    stringBuilder.Append(text);
                    stringBuilder.Append(_AAD.ToString());
                    text = ", ";
                }
            }
            string text2 = stringBuilder.ToString();
            bool flag2 = this._AHW == null;
            if (flag2)
            {
                this._AHW = new Dictionary<string, _bd1>();
            }
            _bd1 _ABB;
            bool flag3 = this._AHW.TryGetValue(text2, out _ABB);
            if (flag3)
            {
                bool flag4 = _ABB.IsValid() && _ABB._AHH != null && _ABB._AAM.Count == this._AAM.Count;
                if (flag4)
                {
                    bool flag5 = _ABB._AHH.All((KJK x) => x.definition != null && x.definition._AT != SymbolKind.Error && x.definition.IsValid());
                    if (flag5)
                    {
                        int count = _ABB._AAM.Count;
                        while (count-- > 0)
                        {
                            bool flag6 = !_ABB._AAM[count].IsValid();
                            if (flag6)
                            {
                                _ABB._AAM.RemoveAt(count);
                            }
                        }
                        int count2 = _ABB._AAM.Count;
                        while (count2-- > 0)
                        {
                            bool flag7 = !this._AAM.Contains(((_bl4)_ABB._AAM[count2])._AHX);
                            if (flag7)
                            {
                                _ABB._AAM.RemoveAt(count2);
                            }
                        }
                        bool flag8 = this._AAM.Count == _ABB._AAM.Count;
                        if (flag8)
                        {
                            return _ABB;
                        }
                    }
                }
            }
            bool flag9 = _ABB != null;
            if (flag9)
            {
                int count3 = _ABB._AAM.Count;
                while (count3-- > 0)
                {
                    _bb3 _AAN = _ABB._AAM[count3];
                    _AAN._AGU = _AAN._AO;
                    _AAN._AO = null;
                }
                _ABB._AGU = this._AO;
                _ABB._AO = null;
            }
            _ABB = new _bd1(this, typeArgs);
            this._AHW[text2] = _ABB;
            return _ABB;
        }

        // Token: 0x0400050F RID: 1295
        public static readonly _bb3 _AHU = new _bb3
        {
            _AT = SymbolKind.Error,
            _AW = "ambiguous method overload"
        };

        // Token: 0x04000510 RID: 1296
        public static readonly _bb3 _AHN = new _bb3
        {
            _AT = SymbolKind.Error,
            _AW = "unresolved method overload"
        };

        // Token: 0x04000511 RID: 1297
        public static readonly _bb3 _AHC = new _bb3
        {
            _AT = SymbolKind.Error,
            _AW = "invalid use of named arguments"
        };

        // Token: 0x04000512 RID: 1298
        public readonly List<_bb3> _AAM = new List<_bb3>();

        // Token: 0x04000513 RID: 1299
        public static List<Modifiers> _AGV = new List<Modifiers>();

        // Token: 0x04000514 RID: 1300
        public static List<_b2> _AGW = new List<_b2>();

        // Token: 0x04000515 RID: 1301
        public static List<_bh4> _AGX = new List<_bh4>();

        // Token: 0x04000516 RID: 1302
        public static List<string> _AGY = new List<string>();

        // Token: 0x04000517 RID: 1303
        public static List<_bb4._ACW> _AHT = new List<_bb4._ACW>();

        // Token: 0x04000518 RID: 1304
        public static List<_bb3> _AHE = new List<_bb3>();

        // Token: 0x04000519 RID: 1305
        private static Stack<List<int>> _AHI = new Stack<List<int>>();

        // Token: 0x0400051A RID: 1306
        private static Stack<List<_b2>> _AHJ = new Stack<List<_b2>>();

        // Token: 0x0400051B RID: 1307
        private Dictionary<string, _bd1> _AHW;
    }
}
