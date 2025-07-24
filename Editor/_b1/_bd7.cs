using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000DA RID: 218
    internal class _bd7 : _b2
    {
        // Token: 0x0600066B RID: 1643 RVA: 0x000E52D0 File Offset: 0x000E34D0
        internal override string GetTooltipText()
        {
            this._APK = this._AW + " in " + this._AO.GetName();
            bool flag = this._ARI != null && this._ARI.definition != null;
            if (flag)
            {
                this._APK = string.Concat(new string[]
                {
                    this._APK,
                    " where ",
                    this._AW,
                    " : ",
                    this._ARI.definition.GetName()
                });
            }
            return this._APK;
        }

        // Token: 0x0600066C RID: 1644 RVA: 0x000E5370 File Offset: 0x000E3570
        internal override string GetName()
        {
            return this._AW;
        }

        // Token: 0x0600066D RID: 1645 RVA: 0x000E5388 File Offset: 0x000E3588
        internal override _b2 SubstituteTypeParameters(_bh4 context)
        {
            return context.TypeOfTypeParameter(this);
        }

        // Token: 0x0600066E RID: 1646 RVA: 0x000E53A4 File Offset: 0x000E35A4
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
                bool flag = (this._ARI != null && (this._ARI.definition == null || !this._ARI.definition.IsValid())) || (this._ARJ != null && this._ARJ.Exists(new Predicate<KJK>(_b2.InvalidSymbolReference)));
                if (flag)
                {
                    this._ARI = null;
                    this._ARJ = null;
                }
                bool flag2 = this._ARI == null && this._ARJ == null;
                if (flag2)
                {
                    this._ARJ = new List<KJK>();
                    _bb4._ACW _AGZ = null;
                    bool flag3 = this._AEI != null;
                    if (flag3)
                    {
                        for (int i = 0; i < this._AEI.Count; i++)
                        {
                            FKI _AFF = this._AEI[i];
                            bool flag4 = _AFF != null && _AFF.IsValid();
                            if (flag4)
                            {
                                _bb4._ACW _AGZ2 = null;
                                _bb4._ACW _AMI = _AFF._AEJ.OOME;
                                string text = _AMI.OOME._AHB();
                                bool flag5 = text == "structDeclaration" || text == "classDeclaration" || text == "interfaceDeclaration" || text == "delegateDeclaration" || text == "interfaceMethodDeclaration";
                                if (flag5)
                                {
                                    _AGZ2 = _AMI.OOME.FindChildByName("typeParameterConstraintsClauses") as _bb4._ACW;
                                }
                                else
                                {
                                    bool flag6 = text == "qidStart" || text == "qidPart";
                                    if (flag6)
                                    {
                                        _AGZ2 = _AMI.OOME.OOME.OOME.OOME.FindChildByName("typeParameterConstraintsClauses") as _bb4._ACW;
                                    }
                                }
                                bool flag7 = _AGZ2 != null;
                                if (flag7)
                                {
                                    for (int j = 0; j < (int)_AGZ2._AIX; j++)
                                    {
                                        _AGZ = _AGZ2.NodeAt(j);
                                        bool flag8 = _AGZ != null && _AGZ._AIX == 4;
                                        if (flag8)
                                        {
                                            _bb4._ACW _AGZ3 = _AGZ.NodeAt(1);
                                            bool flag9 = _AGZ3 != null && _AGZ3._AIX == 1;
                                            if (flag9)
                                            {
                                                string text2 = _bh4.DecodeId(_AGZ3.LeafAt(0)._ACX.text);
                                                bool flag10 = text2 == this._AW;
                                                if (flag10)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        _AGZ = null;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    bool flag11 = _AGZ != null;
                    if (flag11)
                    {
                        _bb4._ACW _AGZ4 = _AGZ.NodeAt(3);
                        bool flag12 = _AGZ4 != null;
                        if (flag12)
                        {
                            _bb4._ACW _AGZ5 = _AGZ4.NodeAt(-1);
                            bool flag13 = _AGZ5 != null && _AGZ5._AHB() == "secondaryConstraintList";
                            if (flag13)
                            {
                                for (int k = 0; k < (int)_AGZ5._AIX; k += 2)
                                {
                                    _bb4._ACW _AGZ6 = _AGZ5.NodeAt(k);
                                    bool flag14 = _AGZ6 != null;
                                    if (flag14)
                                    {
                                        _bb4._ACW _AGZ7 = _AGZ6.NodeAt(0);
                                        bool flag15 = _AGZ7 != null;
                                        if (flag15)
                                        {
                                            bool flag16 = this._ARI == null && this._ARJ.Count == 0;
                                            if (flag16)
                                            {
                                                _b2 _AAC2 = _bh4.ResolveNode(_AGZ7, null, null, 0, true) as _b2;
                                                bool flag17 = _AAC2 != null && _AAC2._AT != SymbolKind.Error;
                                                if (flag17)
                                                {
                                                    bool flag18 = _AAC2._AT == SymbolKind.Interface;
                                                    if (flag18)
                                                    {
                                                        this._ARJ.Add(new KJK(_AGZ7));
                                                    }
                                                    else
                                                    {
                                                        this._ARI = new KJK(_AGZ7);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this._ARJ.Add(new KJK(_AGZ7));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                _b2 _AAC3 = ((this._ARI != null) ? (this._ARI.definition as _b2) : base.BaseType());
                bool flag19 = _AAC3 == this;
                if (flag19)
                {
                    this._ARI = new KJK(_bh4._APG);
                    _AAC3 = _bh4._APG;
                }
                this._APF = false;
                _AAC = _AAC3;
            }
            return _AAC;
        }

        // Token: 0x0600066F RID: 1647 RVA: 0x000E57D4 File Offset: 0x000E39D4
        internal override List<KJK> Interfaces()
        {
            bool flag = this._ARJ == null;
            if (flag)
            {
                this.BaseType();
            }
            return this._ARJ;
        }

        // Token: 0x06000670 RID: 1648 RVA: 0x000E5800 File Offset: 0x000E3A00
        internal override _b2 BindTypeArgument(_b2 typeArgument, _b2 argumentType)
        {
            bool flag = this == typeArgument;
            _b2 _AAC;
            if (flag)
            {
                _AAC = argumentType;
            }
            else
            {
                _AAC = null;
            }
            return _AAC;
        }

        // Token: 0x0400058C RID: 1420
        public KJK _ARI;

        // Token: 0x0400058D RID: 1421
        public List<KJK> _ARJ;

        // Token: 0x0400058E RID: 1422
        public bool _ARK;

        // Token: 0x0400058F RID: 1423
        public bool _ARL;

        // Token: 0x04000590 RID: 1424
        public bool _ARM;

        // Token: 0x04000591 RID: 1425
        private bool _APF;
    }
}
