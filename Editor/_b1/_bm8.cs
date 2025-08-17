using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000A7 RID: 167
    internal class _bm8 : _bc6
    {
        // Token: 0x060004AD RID: 1197 RVA: 0x000CE038 File Offset: 0x000CC238
        public _bm8(_b2 elementType, int rank)
        {
            this._AT = SymbolKind.Class;
            this._AHP = new KJK(elementType);
            this._BEY = rank;
            this._AW = elementType.GetName() + this.RankString();
        }

        // Token: 0x060004AE RID: 1198 RVA: 0x000CE0C4 File Offset: 0x000CC2C4
        internal override _b2 BaseType()
        {
            bool flag = this._zd1 == null && this._BEY == 1;
            if (flag)
            {
                this.Interfaces();
            }
            return _bh4._AQG;
        }

        // Token: 0x060004AF RID: 1199 RVA: 0x000CE0FC File Offset: 0x000CC2FC
        internal override List<KJK> Interfaces()
        {
            bool flag = this._zd1 == null && this._BEY == 1;
            if (flag)
            {
                this._zd1 = new List<KJK>
                {
                    _bl9.ForType(typeof(IEnumerable<>)),
                    _bl9.ForType(typeof(IList<>)),
                    _bl9.ForType(typeof(ICollection<>))
                };
                KJK[] array = new KJK[] { this._AHP };
                for (int i = 0; i < this._zd1.Count; i++)
                {
                    _bc6 _AHD = this._zd1[i].definition as _bc6;
                    _AHD = _AHD.ConstructType(array);
                    this._zd1[i] = new KJK(_AHD);
                }
            }
            this._APD = this._zd1 ?? base.Interfaces();
            return this._APD;
        }

        // Token: 0x060004B0 RID: 1200 RVA: 0x000CE1FC File Offset: 0x000CC3FC
        internal override _b2 SubstituteTypeParameters(_bh4 context)
        {
            _b2 _AAC = this._AHP.definition.SubstituteTypeParameters(context);
            bool flag = _AAC != this._AHP.definition;
            _b2 _AAC2;
            if (flag)
            {
                _AAC2 = _AAC.MakeArrayType(this._BEY);
            }
            else
            {
                _AAC2 = base.SubstituteTypeParameters(context);
            }
            return _AAC2;
        }

        // Token: 0x060004B1 RID: 1201 RVA: 0x000CE24C File Offset: 0x000CC44C
        protected override string RankString()
        {
            bool flag = this._BEY < 8;
            string text;
            if (flag)
            {
                text = this._zd2[this._BEY - 1];
            }
            else
            {
                text = "[" + new string(',', this._BEY - 1) + "]";
            }
            return text;
        }

        // Token: 0x060004B2 RID: 1202 RVA: 0x000CE29C File Offset: 0x000CC49C
        internal override _bh4 FindName(string symbolName, int numTypeParameters, bool asTypeOnly)
        {
            symbolName = _bh4.DecodeId(symbolName);
            return base.FindName(symbolName, numTypeParameters, asTypeOnly);
        }

        // Token: 0x060004B3 RID: 1203 RVA: 0x000CE2C4 File Offset: 0x000CC4C4
        internal override string GetTooltipText()
        {
            bool flag = this._AHP == null || this._AHP.definition == null;
            string text;
            if (flag)
            {
                text = "array of unknown type";
            }
            else
            {
                bool flag2 = this._AO != null && !string.IsNullOrEmpty(this._AO.GetName());
                if (flag2)
                {
                    this._APK = this._AO.GetName() + "." + this._AHP.definition.GetName() + this.RankString();
                }
                else
                {
                    this._APK = this._AHP.definition.GetName() + this.RankString();
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

        // Token: 0x060004B4 RID: 1204 RVA: 0x000CE3AC File Offset: 0x000CC5AC
        internal override bool CanConvertTo(_b2 otherType)
        {
            _bm8 _AX = otherType as _bm8;
            bool flag = _AX != null;
            bool flag3;
            if (flag)
            {
                bool flag2 = this._BEY != _AX._BEY;
                flag3 = !flag2 && ((this._AHP.definition as _b2) ?? _bh4._AHA).CanConvertTo((_AX._AHP.definition as _b2) ?? _bh4._AHA);
            }
            else
            {
                bool flag4 = this._BEY == 1 && (otherType._AT == SymbolKind.Interface || otherType._AT == SymbolKind.TypeParameter);
                if (flag4)
                {
                    List<KJK> list = this.Interfaces();
                    for (int i = 0; i < list.Count; i++)
                    {
                        _b2 _AAC = list[i].definition as _b2;
                        bool flag5 = _AAC != null && _AAC.CanConvertTo(otherType);
                        if (flag5)
                        {
                            return true;
                        }
                    }
                }
                flag3 = base.CanConvertTo(otherType);
            }
            return flag3;
        }

        // Token: 0x060004B5 RID: 1205 RVA: 0x000CE4AC File Offset: 0x000CC6AC
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
                    _bm8 _AX = otherType as _bm8;
                    bool flag3 = _AX != null;
                    if (flag3)
                    {
                        bool flag4 = this._BEY != _AX._BEY;
                        if (flag4)
                        {
                            _AAC = null;
                        }
                        else
                        {
                            _b2 _AAC2 = ((this._AHP.definition as _b2) ?? _bh4._AHA).ConvertTo((_AX._AHP.definition as _b2) ?? _bh4._AHA);
                            bool flag5 = _AAC2 == null;
                            if (flag5)
                            {
                                _AAC = null;
                            }
                            else
                            {
                                bool flag6 = _AAC2 == this._AHP.definition;
                                if (flag6)
                                {
                                    _AAC = this;
                                }
                                else
                                {
                                    _AAC = _AAC2.MakeArrayType(this._BEY);
                                }
                            }
                        }
                    }
                    else
                    {
                        bool flag7 = this._BEY == 1 && otherType._AT == SymbolKind.Interface;
                        if (flag7)
                        {
                            List<KJK> list = this.Interfaces();
                            for (int i = 0; i < list.Count; i++)
                            {
                                _b2 _AAC3 = list[i].definition as _b2;
                                _b2 _AAC4 = _AAC3.ConvertTo(otherType);
                                bool flag8 = _AAC4 != null;
                                if (flag8)
                                {
                                    return _AAC4;
                                }
                            }
                        }
                        _AAC = base.ConvertTo(otherType);
                    }
                }
            }
            return _AAC;
        }

        // Token: 0x060004B6 RID: 1206 RVA: 0x000CE604 File Offset: 0x000CC804
        internal override _b2 BindTypeArgument(_b2 typeArgument, _b2 argumentType)
        {
            _bm8 _AX = argumentType as _bm8;
            bool flag = _AX != null && _AX._BEY == this._BEY;
            if (flag)
            {
                _b2 _AAC = ((this._AHP.definition as _b2) ?? _bh4._AHA).BindTypeArgument(typeArgument, _AX._AHP.definition as _b2);
                bool flag2 = _AAC != null;
                if (flag2)
                {
                    return _AAC;
                }
            }
            return base.BindTypeArgument(typeArgument, argumentType);
        }

        // Token: 0x040004C0 RID: 1216
        public readonly KJK _AHP;

        // Token: 0x040004C1 RID: 1217
        public readonly int _BEY;

        // Token: 0x040004C2 RID: 1218
        private List<KJK> _zd1;

        // Token: 0x040004C3 RID: 1219
        private readonly string[] _zd2 = new string[] { "[]", "[,]", "[,,]", "[,,,]", "[,,,,]", "[,,,,,]", "[,,,,,,]" };
    }
}
