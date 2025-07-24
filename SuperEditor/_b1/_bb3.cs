using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000C5 RID: 197
    internal class _bb3 : _bf1
    {
        // Token: 0x17000025 RID: 37
        // (get) Token: 0x06000574 RID: 1396 RVA: 0x000D3E8C File Offset: 0x000D208C
        internal override bool IsExtensionMethod
        {
            get
            {
                return this._AIH;
            }
        }

        // Token: 0x17000026 RID: 38
        // (get) Token: 0x06000575 RID: 1397 RVA: 0x000D3EA4 File Offset: 0x000D20A4
        internal override bool IsOperator
        {
            get
            {
                return this._AII;
            }
        }

        // Token: 0x06000576 RID: 1398 RVA: 0x000D3EBC File Offset: 0x000D20BC
        public _bb3()
        {
            this._AT = SymbolKind.Method;
        }

        // Token: 0x06000577 RID: 1399 RVA: 0x000D3ED0 File Offset: 0x000D20D0
        public static _bb3 CreateOperator(string operatorName, _b2 returnType, _b2 lhsOperandType, _b2 rhsOperandType)
        {
            return new _bb3
            {
                _AW = operatorName,
                _AII = true,
                _AV = (Modifiers.Public | Modifiers.Static),
                _AIJ = new KJK(returnType),
                _AIK = new List<_bm1>
                {
                    new _bm1
                    {
                        _AW = "a",
                        BLH = new KJK(lhsOperandType)
                    },
                    new _bm1
                    {
                        _AW = "b",
                        BLH = new KJK(rhsOperandType)
                    }
                }
            };
        }

        // Token: 0x06000578 RID: 1400 RVA: 0x000D3F5C File Offset: 0x000D215C
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            _bh4 _AAH = base.AddDeclaration(symbol);
            bool flag = this.IsStatic && _AAH._AT == SymbolKind.Parameter && (_AAH._AV & ~Modifiers.In) == Modifiers.This && symbol._AEJ != null && symbol._AEJ.OOME != null && symbol._AEJ.OOME._AIL == 0;
            if (flag)
            {
                _b2 _AAC = ((this._AO._AT == SymbolKind.MethodGroup) ? this._AO._AO : this._AO) as _b2;
                bool flag2 = _AAC._AT == SymbolKind.Class && _AAC._AHG() == 0;
                if (flag2)
                {
                    _bh4 _AIM = _AAC._AO;
                    bool flag3 = _AIM is _bn1;
                    if (flag3)
                    {
                        this._AIH = true;
                        _AAC._AF++;
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x06000579 RID: 1401 RVA: 0x000D4044 File Offset: 0x000D2244
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = this.IsExtensionMethod && symbol._AT == SymbolKind.Parameter && (symbol._ACV._AV & ~Modifiers.In) == Modifiers.This && (symbol._AEJ == null || symbol._AEJ.OOME == null || symbol._AEJ.OOME._AIL == 0);
            if (flag)
            {
                this._AIH = false;
                _b2 _AAC = ((this._AO._AT == SymbolKind.MethodGroup) ? this._AO._AO : this._AO) as _b2;
                _bh4 _AIM = _AAC._AO;
                bool flag2 = _AIM is _bn1;
                if (flag2)
                {
                    _AAC._AF--;
                }
            }
            base.RemoveDeclaration(symbol);
        }

        // Token: 0x0600057A RID: 1402 RVA: 0x000D410C File Offset: 0x000D230C
        internal override _b2 ReturnType()
        {
            bool flag = this._AIJ == null;
            if (flag)
            {
                bool flag2 = this._AT == SymbolKind.Constructor;
                if (flag2)
                {
                    return (this._AO as _b2) ?? _bh4._AHA;
                }
                bool flag3 = this._AEI != null;
                if (flag3)
                {
                    string text = this._AEI[0]._AEJ._AHB();
                    string text2 = text;
                    _bb4._AIN _AIO;
                    if (!(text2 == "methodDeclaration") && !(text2 == "interfaceMethodDeclaration"))
                    {
                        if (!(text2 == "conversionOperatorDeclarator"))
                        {
                            _AIO = this._AEI[0]._AEJ.OOME.OOME.ChildAt((int)(this._AEI[0]._AEJ.OOME._AIL - 1));
                        }
                        else
                        {
                            _AIO = this._AEI[0]._AEJ.ChildAt(2);
                        }
                    }
                    else
                    {
                        _AIO = this._AEI[0]._AEJ.FindPreviousNode();
                    }
                    this._AIJ = ((_AIO != null) ? new KJK(_AIO) : null);
                }
            }
            return (this._AIJ == null) ? _bh4._AHA : ((this._AIJ.definition as _b2) ?? _bh4._AHA);
        }

        // Token: 0x0600057B RID: 1403 RVA: 0x000D4268 File Offset: 0x000D2468
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            foreach (_bm1 _AGS in this.GetParameters())
            {
                string name = _AGS.GetName();
                bool flag = !data.ContainsKey(name);
                if (flag)
                {
                    data.Add(name, _AGS);
                }
            }
            bool flag2 = (flags & (BindingFlags.Instance | BindingFlags.Static)) != BindingFlags.Instance;
            if (flag2)
            {
                bool flag3 = this._AHL != null;
                if (flag3)
                {
                    foreach (_bd7 _AHM in this._AHL)
                    {
                        string _ADY = _AHM._AW;
                        bool flag4 = !data.ContainsKey(_ADY);
                        if (flag4)
                        {
                            data.Add(_ADY, _AHM);
                        }
                    }
                }
            }
        }

        // Token: 0x0600057C RID: 1404 RVA: 0x000D4360 File Offset: 0x000D2560
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
                _ba7 _AAK = (this._AO ?? this._AGU).Rebind() as _ba7;
                bool flag2 = _AAK == null;
                if (flag2)
                {
                    _AAH = null;
                }
                else
                {
                    bool flag3 = _AAK == this._AO;
                    if (flag3)
                    {
                        _AAH = this;
                    }
                    else
                    {
                        List<_bd7> typeParameters = this.GetTypeParameters();
                        int num = ((typeParameters != null) ? typeParameters.Count : 0);
                        _bb3 _AAN = null;
                        List<_bm1> parameters = this.GetParameters();
                        foreach (_bb3 _AAN2 in _AAK._AAM)
                        {
                            bool flag4 = _AAN2._AHG() != num;
                            if (!flag4)
                            {
                                List<_bm1> parameters2 = _AAN2.GetParameters();
                                bool flag5 = parameters.Count != parameters2.Count;
                                if (!flag5)
                                {
                                    bool flag6 = true;
                                    int count = parameters.Count;
                                    while (count-- > 0)
                                    {
                                        _bm1 _AGS = parameters[count];
                                        _bm1 _AGS2 = parameters2[count];
                                        bool flag7 = _AGS._AV != _AGS2._AV || _AGS._AW != _AGS2._AW || !_AGS.TypeOf().IsSameType(_AGS2.TypeOf() as _b2);
                                        if (flag7)
                                        {
                                            flag6 = false;
                                            break;
                                        }
                                    }
                                    bool flag8 = flag6;
                                    if (flag8)
                                    {
                                        _AAN = _AAN2;
                                        break;
                                    }
                                }
                            }
                        }
                        bool flag9 = _AAN == null || _AAN == this;
                        if (flag9)
                        {
                            _AAH = this;
                        }
                        else
                        {
                            bool flag10 = _AAN._AHL != null;
                            if (flag10)
                            {
                                int count2 = _AAN._AHL.Count;
                                while (count2-- > 0)
                                {
                                    _AAN._AHL[count2] = _AAN._AHL[count2].Rebind() as _bd7;
                                }
                            }
                            bool flag11 = this._AIP != null && this._AIP.Count > 0;
                            if (flag11)
                            {
                                Dictionary<int, _bl4> dictionary = new Dictionary<int, _bl4>();
                                foreach (KeyValuePair<int, _bl4> keyValuePair in this._AIP)
                                {
                                    _bl4 _AIQ = keyValuePair.Value.Rebind() as _bl4;
                                    bool flag12 = _AIQ == null;
                                    if (!flag12)
                                    {
                                        bool flag13 = _AIQ == keyValuePair.Value;
                                        if (flag13)
                                        {
                                            dictionary[keyValuePair.Key] = _AIQ;
                                        }
                                        else
                                        {
                                            KJK[] _AIR = _AIQ._AHH;
                                            int num2 = ((_AIR != null) ? _AIR.Length : 0);
                                            int num3 = 0;
                                            bool flag14 = _AIR != null;
                                            if (flag14)
                                            {
                                                num3 = -2128831035;
                                                for (int i = 0; i < num; i++)
                                                {
                                                    num3 = (num3 * 16777619) ^ ((i < num2) ? _AIR[i].definition : _bh4._AHA).GetHashCode();
                                                }
                                            }
                                            dictionary[num3] = _AIQ;
                                        }
                                    }
                                }
                                _AAN._AIP = dictionary;
                            }
                            _AAH = _AAN;
                        }
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x0600057D RID: 1405 RVA: 0x000D46C0 File Offset: 0x000D28C0
        internal virtual _bl4 ConstructMethod(KJK[] typeArgs)
        {
            int num = ((this._AHL != null) ? this._AHL.Count : 0);
            int num2 = ((typeArgs != null) ? typeArgs.Length : 0);
            int num3 = 0;
            bool flag = typeArgs != null;
            if (flag)
            {
                num3 = -2128831035;
                for (int i = 0; i < num; i++)
                {
                    num3 = (num3 * 16777619) ^ ((i < num2) ? typeArgs[i].definition : _bh4._AHA).GetHashCode();
                }
            }
            bool flag2 = this._AIP == null;
            if (flag2)
            {
                this._AIP = new Dictionary<int, _bl4>();
            }
            _bl4 _AIQ;
            bool flag3 = this._AIP.TryGetValue(num3, out _AIQ);
            if (flag3)
            {
                bool flag4 = _AIQ.IsValid() && _AIQ._AHH != null;
                if (flag4)
                {
                    bool flag5 = true;
                    KJK[] _AIR = _AIQ._AHH;
                    for (int j = 0; j < num; j++)
                    {
                        _bh4 definition = _AIR[j].definition;
                        _bh4 _AAH = ((j < num2) ? typeArgs[j].definition : _bh4._AHA);
                        bool flag6 = definition == null || !definition.IsValid() || definition != _AAH;
                        if (flag6)
                        {
                            flag5 = false;
                            break;
                        }
                    }
                    bool flag7 = flag5;
                    if (flag7)
                    {
                        return _AIQ;
                    }
                }
            }
            _AIQ = new _bl4(this, typeArgs);
            this._AIP[num3] = _AIQ;
            return _AIQ;
        }

        // Token: 0x0600057E RID: 1406 RVA: 0x000D4824 File Offset: 0x000D2A24
        public _b2 GetParentType()
        {
            bool flag = this._AO == null;
            _b2 _AAC;
            if (flag)
            {
                _AAC = null;
            }
            else
            {
                _b2 _AAC2 = this._AO._AO as _b2;
                _AAC = _AAC2;
            }
            return _AAC;
        }

        // Token: 0x0400050C RID: 1292
        protected bool _AIH;

        // Token: 0x0400050D RID: 1293
        public bool _AII;

        // Token: 0x0400050E RID: 1294
        private Dictionary<int, _bl4> _AIP;
    }
}
