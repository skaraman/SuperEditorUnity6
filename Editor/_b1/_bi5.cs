using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000B1 RID: 177
    internal class _bi5 : _bc6
    {
        // Token: 0x06000510 RID: 1296 RVA: 0x000D0CC8 File Offset: 0x000CEEC8
        public _bc6 _AAF()
        {
            return this._yh4;
        }

        // Token: 0x06000511 RID: 1297 RVA: 0x000D0CE0 File Offset: 0x000CEEE0
        private void _yh5(_bc6 value)
        {
            this._yh4 = value.GetGenericSymbol() as _bc6;
        }

        // Token: 0x06000512 RID: 1298 RVA: 0x000D0CF4 File Offset: 0x000CEEF4
        public _bi5(_bc6 definition, KJK[] arguments)
        {
            this._AW = definition._AW;
            this._AT = definition._AT;
            this._AO = definition._AO.GetGenericSymbol();
            this._yh5(definition);
            bool flag = definition._AHL != null && arguments != null;
            if (flag)
            {
                this._AHL = definition._AHL;
                this._AHH = new KJK[this._AHL.Count];
                int num = 0;
                while (num < this._AHH.Length && num < arguments.Length)
                {
                    this._AHH[num] = arguments[num];
                    num++;
                }
            }
        }

        // Token: 0x06000513 RID: 1299 RVA: 0x000D0DA8 File Offset: 0x000CEFA8
        internal override _bh4 Rebind()
        {
            bool flag = this._AO == null;
            _bh4 _AAH;
            if (flag)
            {
                _b2 _AAC = base.Rebind() as _b2;
                _bi5 _AAE = _AAC as _bi5;
                bool flag2 = _AAE == null || _AAE == this;
                if (flag2)
                {
                    _AAH = this;
                }
                else
                {
                    _AAE = _AAE.ConstructType(this._AHH);
                    _AAE._yh5(_AAE._AAF().Rebind() as _bc6);
                    _AAH = _AAE;
                }
            }
            else
            {
                this._yh5(this._AAF().Rebind() as _bc6);
                int count = this._AHL.Count;
                while (count-- > 0)
                {
                    bool flag3 = this._AHL[count] != null;
                    if (flag3)
                    {
                        this._AHL[count] = this._AHL[count].Rebind() as _bd7;
                    }
                }
                _AAH = this;
            }
            return _AAH;
        }

        // Token: 0x06000514 RID: 1300 RVA: 0x000D0E90 File Offset: 0x000CF090
        internal override _bh4 TypeOf()
        {
            bool flag = this._AT != SymbolKind.Delegate;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = base.TypeOf();
            }
            else
            {
                _b2 _AAC = this._AAF().TypeOf() as _b2;
                _AAC = _AAC.SubstituteTypeParameters(this);
                _AAH = _AAC;
            }
            return _AAH;
        }

        // Token: 0x06000515 RID: 1301 RVA: 0x000D0ED8 File Offset: 0x000CF0D8
        internal override _bh4 GetGenericSymbol()
        {
            return this._AAF().GetGenericSymbol();
        }

        // Token: 0x06000516 RID: 1302 RVA: 0x000D0EF8 File Offset: 0x000CF0F8
        internal override _b2 TypeOfTypeParameter(_bd7 tp)
        {
            bool flag = this._AHL != null;
            if (flag)
            {
                int num = this._AHL.IndexOf(tp);
                bool flag2 = num >= 0;
                if (flag2)
                {
                    bool flag3 = this._AHH[num] == null;
                    if (flag3)
                    {
                        return _bh4._AHA;
                    }
                    return (this._AHH[num].definition as _b2) ?? tp;
                }
            }
            return base.TypeOfTypeParameter(tp);
        }

        // Token: 0x06000517 RID: 1303 RVA: 0x000D0F70 File Offset: 0x000CF170
        internal override _b2 SubstituteTypeParameters(_bh4 context)
        {
            _bi5 _AAE = this;
            _b2 _AAC = this._AO as _b2;
            bool flag = _AAC != null;
            if (flag)
            {
                _AAC = _AAC.SubstituteTypeParameters(context);
                _bi5 _AAE2 = _AAC as _bi5;
                bool flag2 = _AAE2 != null;
                if (flag2)
                {
                    _AAE = _AAE2.GetConstructedMember(this._AAF()) as _bi5;
                }
            }
            bool flag3 = this._AHH == null;
            _b2 _AAC2;
            if (flag3)
            {
                _AAC2 = _AAE;
            }
            else
            {
                bool flag4 = false;
                KJK[] array = new KJK[this._AHH.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = this._AHH[i];
                    _b2 _AAC3 = ((this._AHH[i] != null) ? (this._AHH[i].definition as _b2) : null);
                    bool flag5 = _AAC3 == null;
                    if (!flag5)
                    {
                        _b2 _AAC4 = _AAC3.SubstituteTypeParameters(context);
                        bool flag6 = _AAC4 != _AAC3;
                        if (flag6)
                        {
                            array[i] = new KJK(_AAC4);
                            flag4 = true;
                        }
                    }
                }
                bool flag7 = !flag4;
                if (flag7)
                {
                    _AAC2 = _AAE;
                }
                else
                {
                    _AAC2 = this.ConstructType(array);
                }
            }
            return _AAC2;
        }

        // Token: 0x06000518 RID: 1304 RVA: 0x000D1088 File Offset: 0x000CF288
        internal override _b2 BindTypeArgument(_b2 typeArgument, _b2 argumentType)
        {
            bool flag = argumentType._AT == SymbolKind.LambdaExpression;
            _b2 _AAC;
            if (flag)
            {
                _AAC = argumentType.BindTypeArgument(typeArgument, this.TypeOf() as _b2);
            }
            else
            {
                _b2 _AAC2 = argumentType.ConvertTo(this);
                _bi5 _AAE = _AAC2 as _bi5;
                bool flag2 = _AAE != null && this.GetGenericSymbol() == _AAE.GetGenericSymbol();
                if (flag2)
                {
                    _b2 _AAC3 = null;
                    for (int i = 0; i < base._AHG(); i++)
                    {
                        _b2 _AAC4 = _AAE._AHH[i].definition as _b2;
                        bool flag3 = _AAC4 != null;
                        if (flag3)
                        {
                            _b2 _AAC5 = this._AHH[i].definition as _b2;
                            _b2 _AAC6 = _AAC5.BindTypeArgument(typeArgument, _AAC4);
                            bool flag4 = _AAC6 != null;
                            if (flag4)
                            {
                                bool flag5 = _AAC3 == null || _AAC3.CanConvertTo(_AAC6);
                                if (flag5)
                                {
                                    _AAC3 = _AAC6;
                                }
                                else
                                {
                                    bool flag6 = !_AAC6.CanConvertTo(_AAC3);
                                    if (flag6)
                                    {
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                    bool flag7 = _AAC3 != null;
                    if (flag7)
                    {
                        return _AAC3;
                    }
                }
                _AAC = base.BindTypeArgument(typeArgument, argumentType);
            }
            return _AAC;
        }

        // Token: 0x06000519 RID: 1305 RVA: 0x000D11B0 File Offset: 0x000CF3B0
        internal override List<KJK> Interfaces()
        {
            bool flag = this._APD == null;
            if (flag)
            {
                this.BaseType();
            }
            return this._APD;
        }

        // Token: 0x0600051A RID: 1306 RVA: 0x000D11DC File Offset: 0x000CF3DC
        internal override _b2 BaseType()
        {
            bool flag = (this._APC != null && (this._APC.definition == null || !this._APC.definition.IsValid())) || (this._APD != null && this._APD.Exists(new Predicate<KJK>(_b2.InvalidSymbolReference)));
            if (flag)
            {
                this._APC = null;
                this._APD = null;
            }
            bool flag2 = this._APD == null;
            if (flag2)
            {
                _bc6 _AHD = this._AAF();
                _b2 _AAC = _AHD.BaseType();
                this._APC = ((_AAC != null) ? new KJK(_AAC.SubstituteTypeParameters(this)) : null);
                this._APD = new List<KJK>(_AHD.Interfaces());
                for (int i = 0; i < this._APD.Count; i++)
                {
                    _b2 _AAC2 = this._APD[i].definition as _b2;
                    bool flag3 = _AAC2 != null;
                    if (flag3)
                    {
                        this._APD[i] = new KJK(_AAC2.SubstituteTypeParameters(this));
                    }
                }
            }
            return (this._APC != null) ? (this._APC.definition as _b2) : base.BaseType();
        }

        // Token: 0x0600051B RID: 1307 RVA: 0x000D131C File Offset: 0x000CF51C
        internal override List<_bm1> GetParameters()
        {
            return this._AAF().GetParameters();
        }

        // Token: 0x0600051C RID: 1308 RVA: 0x000D133C File Offset: 0x000CF53C
        internal override bool CanConvertTo(_b2 otherType)
        {
            return this.ConvertTo(otherType) != null;
        }

        // Token: 0x0600051D RID: 1309 RVA: 0x000D1358 File Offset: 0x000CF558
        internal override _b2 ConvertTo(_b2 otherType)
        {
            bool flag = otherType == null;
            _b2 _AAC;
            if (flag)
            {
                _AAC = null;
            }
            else
            {
                bool flag2 = otherType is _bd7;
                if (flag2)
                {
                    _AAC = this;
                }
                else
                {
                    bool flag3 = this._AAF() == otherType;
                    if (flag3)
                    {
                        _AAC = this;
                    }
                    else
                    {
                        _b2 _AAC2 = otherType.GetGenericSymbol() as _b2;
                        bool flag4 = this._AAF() == _AAC2;
                        if (flag4)
                        {
                            _bi5 _AAE = otherType as _bi5;
                            KJK[] _AIR = _AAE._AHH;
                            List<KJK> list = new List<KJK>(this._AHH.Length);
                            for (int i = 0; i < this._AHH.Length; i++)
                            {
                                _b2 _AAC3 = this._AHH[i].definition as _b2;
                                bool flag5 = _AAC3 == null;
                                if (flag5)
                                {
                                    _AAC3 = _AIR[i].definition as _b2;
                                }
                                else
                                {
                                    _AAC3 = _AAC3.ConvertTo(_AIR[i].definition as _b2);
                                }
                                bool flag6 = _AAC3 == null;
                                if (flag6)
                                {
                                    break;
                                }
                                KJK _AAD = new KJK(_AAC3);
                                list.Add(_AAD);
                            }
                            bool flag7 = list.Count == this._AHH.Length;
                            if (flag7)
                            {
                                return this._AAF().ConstructType(list.ToArray());
                            }
                        }
                        bool _APH = this._AG;
                        if (_APH)
                        {
                            _AAC = null;
                        }
                        else
                        {
                            this._AG = true;
                            _b2 _AAC4 = this.BaseType();
                            bool flag8 = otherType._AT == SymbolKind.Interface;
                            if (flag8)
                            {
                                for (int j = 0; j < this._APD.Count; j++)
                                {
                                    _b2 _AAC5 = (_b2)this._APD[j].definition;
                                    bool flag9 = _AAC5 == null;
                                    if (!flag9)
                                    {
                                        _b2 _AAC6 = _AAC5.ConvertTo(otherType);
                                        bool flag10 = _AAC6 != null;
                                        if (flag10)
                                        {
                                            this._AG = false;
                                            return _AAC6;
                                        }
                                    }
                                }
                            }
                            bool flag11 = _AAC4 != null;
                            if (flag11)
                            {
                                _b2 _AAC7 = _AAC4.ConvertTo(otherType);
                                bool flag12 = _AAC7 != null;
                                if (flag12)
                                {
                                    this._AG = false;
                                    return _AAC7;
                                }
                            }
                            this._AG = false;
                            _AAC = null;
                        }
                    }
                }
            }
            return _AAC;
        }

        // Token: 0x0600051E RID: 1310 RVA: 0x000D1578 File Offset: 0x000CF778
        internal override bool DerivesFromRef(ref _b2 otherType)
        {
            bool flag = otherType == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = this._AAF() == otherType;
                if (flag3)
                {
                    otherType = this;
                    flag2 = true;
                }
                else
                {
                    _b2 _AAC = this.BaseType();
                    bool flag4 = otherType._AT == SymbolKind.Interface || otherType._AT == SymbolKind.TypeParameter;
                    if (flag4)
                    {
                        int count = this._APD.Count;
                        while (count-- > 0)
                        {
                            KJK _AAD = this._APD[count];
                            bool flag5 = ((_b2)_AAD.definition).DerivesFromRef(ref otherType);
                            if (flag5)
                            {
                                otherType = otherType.SubstituteTypeParameters(this);
                                return true;
                            }
                        }
                    }
                    bool flag6 = _AAC != null && _AAC.DerivesFromRef(ref otherType);
                    if (flag6)
                    {
                        otherType = otherType.SubstituteTypeParameters(this);
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x0600051F RID: 1311 RVA: 0x000D1654 File Offset: 0x000CF854
        internal override bool DerivesFrom(_b2 otherType)
        {
            bool flag = otherType == null;
            return !flag && this._AAF().DerivesFrom(otherType);
        }

        // Token: 0x06000520 RID: 1312 RVA: 0x000D1680 File Offset: 0x000CF880
        internal override string GetName()
        {
            bool flag = this._AHH == null || this._AHH.Length == 0;
            string text;
            if (flag)
            {
                text = this._AW;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(this._AW);
                string text2 = "<";
                for (int i = 0; i < this._AHH.Length; i++)
                {
                    stringBuilder.Append(text2);
                    bool flag2 = this._AHH[i] != null;
                    if (flag2)
                    {
                        stringBuilder.Append(this._AHH[i].definition.GetName());
                    }
                    text2 = ", ";
                }
                stringBuilder.Append('>');
                text = stringBuilder.ToString();
            }
            return text;
        }

        // Token: 0x06000521 RID: 1313 RVA: 0x000D1738 File Offset: 0x000CF938
        internal override _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            memberName = _bh4.DecodeId(memberName);
            return this._AAF().FindName(memberName, numTypeParameters, asTypeOnly);
        }

        // Token: 0x06000522 RID: 1314 RVA: 0x000D1760 File Offset: 0x000CF960
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            this._AAF().ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
            _bh4 _AAH = leaf._AAB();
            bool flag = _AAH == null;
            if (!flag)
            {
                _bh4 _AAH2 = null;
                bool flag2 = this._yh6 != null && this._yh6.TryGetValue(_AAH, out _AAH2);
                if (flag2)
                {
                    leaf._ACY(_AAH2);
                }
                else
                {
                    leaf._ACY(this.GetConstructedMember(_AAH));
                }
                bool flag3 = asTypeOnly && !(leaf._AAB() is _b2);
                if (flag3)
                {
                    leaf._ACY(null);
                }
            }
        }

        // Token: 0x06000523 RID: 1315 RVA: 0x000D17EC File Offset: 0x000CF9EC
        internal override _bb3 GetDefaultConstructor()
        {
            bool flag = this._AI == null;
            if (flag)
            {
                _bb3 defaultConstructor = base.GetDefaultConstructor();
                this._AI = this.GetConstructedMember(defaultConstructor) as _bb3;
            }
            return this._AI;
        }

        // Token: 0x06000524 RID: 1316 RVA: 0x000D182C File Offset: 0x000CFA2C
        public _bh4 GetConstructedMember(_bh4 member)
        {
            _bh4 _AAH = member._AO;
            bool flag = _AAH is _ba7;
            if (flag)
            {
                _AAH = _AAH._AO;
            }
            bool flag2 = _AAH == this;
            _bh4 _AAH2;
            if (flag2)
            {
                _AAH2 = member;
            }
            else
            {
                bool flag3 = this._yh6 == null;
                _bh4 _AAH3;
                if (flag3)
                {
                    this._yh6 = new Dictionary<_bh4, _bh4>();
                }
                else
                {
                    bool flag4 = this._yh6.TryGetValue(member, out _AAH3);
                    if (flag4)
                    {
                        return _AAH3;
                    }
                }
                _AAH3 = this.ConstructMember(member);
                this._yh6[member] = _AAH3;
                _AAH2 = _AAH3;
            }
            return _AAH2;
        }

        // Token: 0x06000525 RID: 1317 RVA: 0x000D18B8 File Offset: 0x000CFAB8
        private _bh4 ConstructMember(_bh4 member)
        {
            bool flag = member is _bn3;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = new _ba8(member as _bn3);
            }
            bool flag2 = member is _bc6;
            if (flag2)
            {
                _AAH = (member as _bc6).ConstructType(this._yh7);
            }
            else
            {
                _AAH = new _bm7(member);
            }
            _AAH._AO = this;
            return _AAH;
        }

        // Token: 0x06000526 RID: 1318 RVA: 0x000D191C File Offset: 0x000CFB1C
        internal override bool IsSameType(_b2 type)
        {
            bool flag = type == this;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                _bi5 _AAE = type as _bi5;
                bool flag3 = _AAE == null;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    bool flag4 = this._AAF() != _AAE._AAF();
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        for (int i = 0; i < this._AHH.Length; i++)
                        {
                            bool flag5 = !this._AHH[i].definition.IsSameType(_AAE._AHH[i].definition as _b2);
                            if (flag5)
                            {
                                return false;
                            }
                        }
                        flag2 = true;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000527 RID: 1319 RVA: 0x000D19BC File Offset: 0x000CFBBC
        protected override _bh4 GetIndexer(_b2[] argumentTypes)
        {
            List<_bh4> allIndexers = this.GetAllIndexers();
            return (allIndexers != null) ? allIndexers[allIndexers.Count - 1] : null;
        }

        // Token: 0x06000528 RID: 1320 RVA: 0x000D19EC File Offset: 0x000CFBEC
        internal override List<_bh4> GetAllIndexers()
        {
            List<_bh4> allIndexers = this._AAF().GetAllIndexers();
            bool flag = allIndexers != null;
            if (flag)
            {
                for (int i = 0; i < allIndexers.Count; i++)
                {
                    _bh4 _AAH = allIndexers[i];
                    _AAH = this.GetConstructedMember(_AAH);
                    allIndexers[i] = _AAH;
                }
            }
            return allIndexers;
        }

        // Token: 0x06000529 RID: 1321 RVA: 0x000D1A4C File Offset: 0x000CFC4C
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            Dictionary<string, _bh4> dictionary = new Dictionary<string, _bh4>();
            this._AAF().GetMembersCompletionData(dictionary, flags, mask, context);
            foreach (KeyValuePair<string, _bh4> keyValuePair in dictionary)
            {
                bool flag = !data.ContainsKey(keyValuePair.Key);
                if (flag)
                {
                    _bh4 constructedMember = this.GetConstructedMember(keyValuePair.Value);
                    data.Add(keyValuePair.Key, constructedMember);
                }
            }
        }

        // Token: 0x040004F1 RID: 1265
        private _bc6 _yh4;

        // Token: 0x040004F2 RID: 1266
        public readonly KJK[] _AHH;

        // Token: 0x040004F3 RID: 1267
        public Dictionary<_bh4, _bh4> _yh6;

        // Token: 0x040004F4 RID: 1268
        private readonly KJK[] _yh7 = new KJK[0];
    }
}
