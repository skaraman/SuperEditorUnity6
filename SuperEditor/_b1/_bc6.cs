using System;
using System.Collections.Generic;
using System.Text;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000D7 RID: 215
    internal class _bc6 : _b2
    {
        // Token: 0x0600063D RID: 1597 RVA: 0x000E352A File Offset: 0x000E172A
        internal _bc6()
        {
        }

        // Token: 0x0600063E RID: 1598 RVA: 0x000E3548 File Offset: 0x000E1748
        internal override _bh4 Rebind()
        {
            _bc6 _AHD = base.Rebind() as _bc6;
            bool flag = _AHD == null || _AHD == this;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = this;
            }
            else
            {
                bool flag2 = _AHD._AHL != null;
                if (flag2)
                {
                    int count = _AHD._AHL.Count;
                    while (count-- > 0)
                    {
                        _AHD._AHL[count] = _AHD._AHL[count].Rebind() as _bd7;
                    }
                }
                bool flag3 = !this._AOZ && this._APA != null && this._APA.Count > 0;
                if (flag3)
                {
                    this._AOZ = true;
                    Dictionary<string, _bi5> dictionary = new Dictionary<string, _bi5>();
                    foreach (KeyValuePair<string, _bi5> keyValuePair in this._APA)
                    {
                        dictionary[keyValuePair.Key] = keyValuePair.Value.Rebind() as _bi5;
                    }
                    _AHD._APA = dictionary;
                    this._AOZ = false;
                }
                _AAH = _AHD;
            }
            return _AAH;
        }

        // Token: 0x0600063F RID: 1599 RVA: 0x000E3678 File Offset: 0x000E1878
        internal virtual _bi5 ConstructType(KJK[] typeArgs)
        {
            string text = string.Empty;
            this._APB.Length = 0;
            bool flag = typeArgs != null;
            if (flag)
            {
                foreach (KJK _AAD in typeArgs)
                {
                    this._APB.Append(text);
                    this._APB.Append(_AAD.ToString());
                    text = ", ";
                }
            }
            string text2 = this._APB.ToString();
            bool flag2 = this._APA == null;
            if (flag2)
            {
                this._APA = new Dictionary<string, _bi5>();
            }
            _bi5 _AAE;
            bool flag3 = this._APA.TryGetValue(text2, out _AAE);
            if (flag3)
            {
                bool flag4 = _AAE.IsValid();
                if (flag4)
                {
                    bool flag5 = true;
                    bool flag6 = _AAE._AHH == null;
                    if (flag6)
                    {
                        flag5 = typeArgs == null;
                    }
                    else
                    {
                        bool flag7 = typeArgs == null || _AAE._AHH.Length != typeArgs.Length;
                        if (flag7)
                        {
                            flag5 = false;
                        }
                        else
                        {
                            int num = _AAE._AHH.Length;
                            while (num-- > 0)
                            {
                                bool flag8 = typeArgs[num].definition != _AAE._AHH[num].definition;
                                if (flag8)
                                {
                                    flag5 = false;
                                    break;
                                }
                            }
                        }
                    }
                    bool flag9 = flag5;
                    if (flag9)
                    {
                        _AAE._AI = null;
                        return _AAE;
                    }
                }
            }
            _bi5 _AAE2 = new _bi5(this, typeArgs);
            this._APA[text2] = _AAE2;
            return _AAE2;
        }

        // Token: 0x06000640 RID: 1600 RVA: 0x000E37F4 File Offset: 0x000E19F4
        internal override _bh4 TypeOf()
        {
            return this;
        }

        // Token: 0x06000641 RID: 1601 RVA: 0x000E3808 File Offset: 0x000E1A08
        internal override void InvalidateBaseType()
        {
            this._APC = null;
            this._APD = null;
            _bb4._AIU += 1U;
            bool flag = _bb4._AIU == 0U;
            if (flag)
            {
                _bb4._AIU += 1U;
            }
        }

        // Token: 0x06000642 RID: 1602 RVA: 0x000E3848 File Offset: 0x000E1A48
        internal override List<KJK> Interfaces()
        {
            bool flag = this._APD == null;
            if (flag)
            {
                this.BaseType();
            }
            return this._APD;
        }

        // Token: 0x06000643 RID: 1603 RVA: 0x000E3874 File Offset: 0x000E1A74
        internal override _b2 BaseType()
        {
            bool _APE = this._APF;
            _b2 _AAC;
            if (_APE)
            {
                _AAC = null;
            }
            else
            {
                this._APF = true;
                bool flag = this._APD == null;
                bool flag2 = (this._APC != null && (this._APC.definition == null || !this._APC.definition.IsValid())) || (this._APD != null && this._APD.Exists(_b2._AH));
                if (flag2)
                {
                    this._APC = null;
                    flag = true;
                }
                bool flag3 = this._APC == null && flag;
                if (flag3)
                {
                    this._APD = this._APD ?? new List<KJK>();
                    this._APD.Clear();
                    _bb4._ACW _AGZ = null;
                    FKI _AFF = null;
                    bool flag4 = this._AEI != null;
                    if (flag4)
                    {
                        int count = this._AEI.Count;
                        while (count-- > 0)
                        {
                            FKI _AFF2 = this._AEI[count];
                            bool flag5 = _AFF2 != null;
                            if (flag5)
                            {
                                _bb4._ACW _AGZ2 = (_bb4._ACW)_AFF2._AEJ.FindChildByName((_AFF2._AT == SymbolKind.Class) ? "classBase" : ((_AFF2._AT == SymbolKind.Struct) ? "structInterfaces" : "interfaceBase"));
                                _AGZ = ((_AGZ2 != null) ? _AGZ2.NodeAt(1) : null);
                                bool flag6 = _AGZ2 != null;
                                if (flag6)
                                {
                                    _AFF = _AFF2;
                                    break;
                                }
                            }
                        }
                    }
                    bool flag7 = _AFF != null;
                    if (flag7)
                    {
                        switch (_AFF._AT)
                        {
                            case SymbolKind.Interface:
                            case SymbolKind.Struct:
                                {
                                    this._APC = ((_AFF._AT == SymbolKind.Struct) ? _bl9.ForType(typeof(ValueType)) : _bl9.ForType(typeof(object)));
                                    bool flag8 = _AGZ != null;
                                    if (flag8)
                                    {
                                        for (int i = 0; i < (int)_AGZ._AIX; i += 2)
                                        {
                                            this._APD.Add(new KJK(_AGZ.ChildAt(i)));
                                        }
                                    }
                                    break;
                                }
                            case SymbolKind.Enum:
                                this._APC = _bl9.ForType(typeof(Enum));
                                break;
                            case SymbolKind.Class:
                                {
                                    bool flag9 = _AGZ != null;
                                    if (flag9)
                                    {
                                        this._APC = new KJK(_AGZ.ChildAt(0));
                                        bool flag10 = this._APC.definition._AT == SymbolKind.Interface;
                                        if (flag10)
                                        {
                                            this._APD.Add(this._APC);
                                            this._APC = ((this != _bh4._AS) ? _bl9.ForType(typeof(object)) : null);
                                        }
                                        for (int j = 2; j < (int)_AGZ._AIX; j += 2)
                                        {
                                            this._APD.Add(new KJK(_AGZ.ChildAt(j)));
                                        }
                                    }
                                    else
                                    {
                                        this._APC = ((this != _bh4._AS) ? _bl9.ForType(typeof(object)) : null);
                                    }
                                    break;
                                }
                            case SymbolKind.Delegate:
                                this._APC = _bl9.ForType(typeof(MulticastDelegate));
                                break;
                        }
                    }
                }
                _b2 _AAC2 = ((this._APC != null) ? (this._APC.definition as _b2) : base.BaseType());
                bool flag11 = _AAC2 == this;
                if (flag11)
                {
                    this._APC = new KJK(_bh4._APG);
                    _AAC2 = _bh4._APG;
                }
                this._APF = false;
                _AAC = _AAC2;
            }
            return _AAC;
        }

        // Token: 0x06000644 RID: 1604 RVA: 0x000E3BEC File Offset: 0x000E1DEC
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
                    bool flag3 = otherType == _bh4._AS;
                    if (flag3)
                    {
                        _AAC = otherType;
                    }
                    else
                    {
                        bool flag4 = otherType.GetGenericSymbol() == _bh4._AY;
                        if (flag4)
                        {
                            _bi5 _AAE = otherType as _bi5;
                            bool flag5 = _AAE != null && _AAE._AHH[0].definition == this;
                            if (flag5)
                            {
                                return otherType;
                            }
                        }
                        bool flag6 = this == _bh4._AAQ && (otherType == _bh4._AAR || otherType == _bh4._AAS || otherType == _bh4._AAT);
                        if (flag6)
                        {
                            _AAC = otherType;
                        }
                        else
                        {
                            bool flag7 = this == _bh4._AAU && (otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                            if (flag7)
                            {
                                _AAC = otherType;
                            }
                            else
                            {
                                bool flag8 = this == _bh4._AAW && (otherType == _bh4._AAX || otherType == _bh4._AAY || otherType == _bh4._AAQ || otherType == _bh4._AAU || otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                if (flag8)
                                {
                                    _AAC = otherType;
                                }
                                else
                                {
                                    bool flag9 = this == _bh4._AAZ && (otherType == _bh4._AAX || otherType == _bh4._AAQ || otherType == _bh4._AAR || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                    if (flag9)
                                    {
                                        _AAC = otherType;
                                    }
                                    else
                                    {
                                        bool flag10 = this == _bh4._AAX && (otherType == _bh4._AAQ || otherType == _bh4._AAR || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                        if (flag10)
                                        {
                                            _AAC = otherType;
                                        }
                                        else
                                        {
                                            bool flag11 = this == _bh4._AAY && (otherType == _bh4._AAQ || otherType == _bh4._AAU || otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                            if (flag11)
                                            {
                                                _AAC = otherType;
                                            }
                                            else
                                            {
                                                bool flag12 = (this == _bh4._AAR || this == _bh4._AAV) && (otherType == _bh4._AAS || otherType == _bh4._AAT);
                                                if (flag12)
                                                {
                                                    _AAC = otherType;
                                                }
                                                else
                                                {
                                                    bool flag13 = this == _bh4._AAS && otherType == _bh4._AAT;
                                                    if (flag13)
                                                    {
                                                        _AAC = otherType;
                                                    }
                                                    else
                                                    {
                                                        bool flag14 = this == _bh4._ABA && (otherType == _bh4._AAY || otherType == _bh4._AAQ || otherType == _bh4._AAU || otherType == _bh4._AAR || otherType == _bh4._AAV || otherType == _bh4._AAS || otherType == _bh4._AAT);
                                                        if (flag14)
                                                        {
                                                            _AAC = otherType;
                                                        }
                                                        else
                                                        {
                                                            _bi5 _AAE2 = otherType as _bi5;
                                                            bool flag15 = _AAE2 != null;
                                                            if (flag15)
                                                            {
                                                                otherType = _AAE2._AAF();
                                                            }
                                                            bool flag16 = this == otherType;
                                                            if (flag16)
                                                            {
                                                                _AAC = this;
                                                            }
                                                            else
                                                            {
                                                                bool _APH = this._AG;
                                                                if (_APH)
                                                                {
                                                                    _AAC = null;
                                                                }
                                                                else
                                                                {
                                                                    this._AG = true;
                                                                    _b2 _AAC2 = this.BaseType();
                                                                    bool flag17 = this._APD != null && (otherType._AT == SymbolKind.Interface || otherType._AT == SymbolKind.TypeParameter);
                                                                    if (flag17)
                                                                    {
                                                                        for (int i = 0; i < this._APD.Count; i++)
                                                                        {
                                                                            _b2 _AAC3 = this._APD[i].definition as _b2;
                                                                            bool flag18 = _AAC3 != null;
                                                                            if (flag18)
                                                                            {
                                                                                _b2 _AAC4 = _AAC3.ConvertTo(otherType);
                                                                                bool flag19 = _AAC4 != null;
                                                                                if (flag19)
                                                                                {
                                                                                    this._AG = false;
                                                                                    return _AAC4;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    bool flag20 = _AAC2 != null;
                                                                    if (flag20)
                                                                    {
                                                                        _b2 _AAC5 = _AAC2.ConvertTo(otherType);
                                                                        this._AG = false;
                                                                        _AAC = _AAC5;
                                                                    }
                                                                    else
                                                                    {
                                                                        this._AG = false;
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
            }
            return _AAC;
        }

        // Token: 0x06000645 RID: 1605 RVA: 0x000E3FB8 File Offset: 0x000E21B8
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
                    bool flag5 = this._APD == null;
                    if (flag5)
                    {
                        this.BaseType();
                    }
                    bool _API = this._APJ;
                    if (_API)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        this._APJ = true;
                        bool flag6 = this._APD != null;
                        if (flag6)
                        {
                            for (int i = 0; i < this._APD.Count; i++)
                            {
                                _b2 _AAC = this._APD[i].definition as _b2;
                                bool flag7 = _AAC != null && _AAC.DerivesFromRef(ref otherType);
                                if (flag7)
                                {
                                    this._APJ = false;
                                    return true;
                                }
                            }
                        }
                        bool flag8 = this.BaseType() != null;
                        if (flag8)
                        {
                            bool flag9 = this.BaseType().DerivesFromRef(ref otherType);
                            this._APJ = false;
                            flag2 = flag9;
                        }
                        else
                        {
                            this._APJ = false;
                            flag2 = false;
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000646 RID: 1606 RVA: 0x000E40D4 File Offset: 0x000E22D4
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = symbol._AT != SymbolKind.TypeParameter;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = base.AddDeclaration(symbol);
            }
            else
            {
                string text = symbol._AP();
                bool flag2 = this._AHL == null;
                if (flag2)
                {
                    this._AHL = new List<_bd7>();
                }
                _bd7 _AHM = this._AHL.FirstByName(text);
                bool flag3 = _AHM == null;
                if (flag3)
                {
                    _AHM = (_bd7)_bh4.Create(symbol);
                    _AHM._AO = this;
                    this._AHL.Add(_AHM);
                }
                symbol._ACV = _AHM;
                _bb4._AIN _AIO = symbol.NameNode();
                bool flag4 = _AIO != null;
                if (flag4)
                {
                    _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                    bool flag5 = _AEM != null;
                    if (flag5)
                    {
                        _AEM.SetDeclaredSymbol(_AHM);
                    }
                    else
                    {
                        _bb4.DHBA _AEM2 = ((_bb4._ACW)_AIO).GetLastLeaf();
                        bool flag6 = _AEM2 != null;
                        if (flag6)
                        {
                            bool flag7 = _AEM2.OOME._AHB() == "typeParameterList";
                            if (flag7)
                            {
                                _AEM2 = _AEM2.OOME.OOME.LeafAt(0);
                            }
                            _AEM2.SetDeclaredSymbol(_AHM);
                        }
                    }
                }
                _AAH = _AHM;
            }
            return _AAH;
        }

        // Token: 0x06000647 RID: 1607 RVA: 0x000E41F0 File Offset: 0x000E23F0
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.TypeParameter && this._AHL != null;
            if (flag)
            {
                bool flag2 = this._AHL.Remove(symbol._ACV as _bd7);
                if (flag2)
                {
                }
            }
            base.RemoveDeclaration(symbol);
        }

        // Token: 0x06000648 RID: 1608 RVA: 0x000E4240 File Offset: 0x000E2440
        internal override _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            memberName = _bh4.DecodeId(memberName);
            bool flag = numTypeParameters == 0 && this._AHL != null;
            if (flag)
            {
                int count = this._AHL.Count;
                while (count-- > 0)
                {
                    bool flag2 = this._AHL[count]._AW == memberName;
                    if (flag2)
                    {
                        return this._AHL[count];
                    }
                }
            }
            return base.FindName(memberName, numTypeParameters, asTypeOnly);
        }

        // Token: 0x06000649 RID: 1609 RVA: 0x000E42C4 File Offset: 0x000E24C4
        internal override List<_bd7> GetTypeParameters()
        {
            return this._AHL;
        }

        // Token: 0x0600064A RID: 1610 RVA: 0x000E42DC File Offset: 0x000E24DC
        internal override string GetTooltipText()
        {
            bool flag = this._AT == SymbolKind.Delegate;
            string text;
            if (flag)
            {
                text = base.GetTooltipText();
            }
            else
            {
                _bh4 _AAH = this._AO;
                string text2 = string.Empty;
                while (_AAH != null && _AAH._AO != null && _AAH.GetName() != string.Empty)
                {
                    text2 = _AAH.GetName() + "." + text2;
                    _AAH = _AAH._AO;
                }
                this._APK = this._AT.ToString().ToLowerInvariant() + " " + text2 + this._AW;
                bool flag2 = this._AHL != null;
                if (flag2)
                {
                    this._APK = this._APK + "<" + this.TypeOfTypeParameter(this._AHL[0]).GetName();
                    for (int i = 1; i < this._AHL.Count; i++)
                    {
                        this._APK = this._APK + ", " + this.TypeOfTypeParameter(this._AHL[i]).GetName();
                    }
                    this._APK += ">";
                }
                string xmlDocs = base.GetXmlDocs();
                bool flag3 = !string.IsNullOrEmpty(xmlDocs);
                if (flag3)
                {
                    this._APK = this._APK + "\n\n" + xmlDocs;
                }
                text = this._APK;
            }
            return text;
        }

        // Token: 0x0600064B RID: 1611 RVA: 0x000E4460 File Offset: 0x000E2660
        internal override _b2 SubstituteTypeParameters(_bh4 context)
        {
            bool flag = this._AHL == null;
            _b2 _AAC;
            if (flag)
            {
                _AAC = base.SubstituteTypeParameters(context);
            }
            else
            {
                bool flag2 = false;
                KJK[] array = new KJK[this._AHL.Count];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = new KJK(this._AHL[i]);
                    _bd7 _AHM = this._AHL[i];
                    bool flag3 = _AHM == null;
                    if (!flag3)
                    {
                        _b2 _AAC2 = _AHM.SubstituteTypeParameters(context);
                        bool flag4 = _AAC2 != _AHM;
                        if (flag4)
                        {
                            array[i] = new KJK(_AAC2);
                            flag2 = true;
                        }
                    }
                }
                bool flag5 = !flag2;
                if (flag5)
                {
                    _AAC = this;
                }
                else
                {
                    _AAC = this.ConstructType(array);
                }
            }
            return _AAC;
        }

        // Token: 0x0600064C RID: 1612 RVA: 0x000E4528 File Offset: 0x000E2728
        internal override _b2 BindTypeArgument(_b2 typeArgument, _b2 argumentType)
        {
            bool flag = base._AHG() == 0;
            _b2 _AAC;
            if (flag)
            {
                _AAC = base.BindTypeArgument(typeArgument, argumentType);
            }
            else
            {
                bool flag2 = argumentType._AT == SymbolKind.LambdaExpression;
                if (flag2)
                {
                    _AAC = argumentType.BindTypeArgument(typeArgument, this.TypeOf() as _b2);
                }
                else
                {
                    _b2 _AAC2 = this;
                    bool flag3 = !argumentType.DerivesFromRef(ref _AAC2);
                    if (flag3)
                    {
                        _AAC = base.BindTypeArgument(typeArgument, argumentType);
                    }
                    else
                    {
                        _bi5 _AAE = _AAC2 as _bi5;
                        bool flag4 = _AAE != null && this.GetGenericSymbol() == _AAE.GetGenericSymbol();
                        if (flag4)
                        {
                            _b2 _AAC3 = null;
                            for (int i = 0; i < base._AHG(); i++)
                            {
                                _b2 _AAC4 = _AAE._AHH[i].definition as _b2;
                                bool flag5 = _AAC4 != null;
                                if (flag5)
                                {
                                    _b2 _AAC5 = this._AHL[i].BindTypeArgument(typeArgument, _AAC4);
                                    bool flag6 = _AAC5 != null;
                                    if (flag6)
                                    {
                                        bool flag7 = _AAC3 == null || _AAC3.CanConvertTo(_AAC5);
                                        if (flag7)
                                        {
                                            _AAC3 = _AAC5;
                                        }
                                        else
                                        {
                                            bool flag8 = !_AAC5.CanConvertTo(_AAC3);
                                            if (flag8)
                                            {
                                                return null;
                                            }
                                        }
                                    }
                                }
                            }
                            bool flag9 = _AAC3 != null;
                            if (flag9)
                            {
                                return _AAC3;
                            }
                        }
                        _AAC = base.BindTypeArgument(typeArgument, argumentType);
                    }
                }
            }
            return _AAC;
        }

        // Token: 0x0400057A RID: 1402
        protected KJK _APC;

        // Token: 0x0400057B RID: 1403
        protected List<KJK> _APD;

        // Token: 0x0400057C RID: 1404
        public List<_bd7> _AHL;

        // Token: 0x0400057D RID: 1405
        private bool _AOZ;

        // Token: 0x0400057E RID: 1406
        private StringBuilder _APB = new StringBuilder();

        // Token: 0x0400057F RID: 1407
        private Dictionary<string, _bi5> _APA;

        // Token: 0x04000580 RID: 1408
        protected bool _APF = false;

        // Token: 0x04000581 RID: 1409
        private bool _APJ;
    }
}
