using System;
using System.Collections.Generic;
using System.Text;

namespace AHO
{
    // Token: 0x020000AE RID: 174
    internal class _bl4 : _bb3
    {
        // Token: 0x17000023 RID: 35
        // (get) Token: 0x060004F4 RID: 1268 RVA: 0x000D0568 File Offset: 0x000CE768
        internal override bool IsExtensionMethod
        {
            get
            {
                return this._AHX.IsExtensionMethod;
            }
        }

        // Token: 0x060004F5 RID: 1269 RVA: 0x000D0588 File Offset: 0x000CE788
        internal override _bh4 GetGenericSymbol()
        {
            return this._AHX;
        }

        // Token: 0x060004F6 RID: 1270 RVA: 0x000D05A0 File Offset: 0x000CE7A0
        public _bl4(_bb3 definition, KJK[] arguments)
        {
            this._AW = definition._AW;
            this._AT = definition._AT;
            this._AO = definition._AO;
            this._AHX = definition;
            this._AIK = this._AHX._AIK;
            this._AV = this._AHX._AV;
            bool flag = definition._AHL != null && arguments != null;
            if (flag)
            {
                this._AHL = definition._AHL;
                this._AHH = new KJK[this._AHL.Count];
                for (int i = 0; i < this._AHH.Length; i++)
                {
                    this._AHH[i] = ((i < arguments.Length) ? arguments[i] : new KJK(_bh4._AHA));
                }
            }
        }

        // Token: 0x060004F7 RID: 1271 RVA: 0x000D0670 File Offset: 0x000CE870
        internal override _b2 TypeOfTypeParameter(_bd7 tp)
        {
            bool flag = this._AHL != null;
            if (flag)
            {
                int num = this._AHL.IndexOf(tp);
                bool flag2 = num >= 0;
                if (flag2)
                {
                    return (this._AHH[num].definition as _b2) ?? tp;
                }
            }
            return base.TypeOfTypeParameter(tp);
        }

        // Token: 0x060004F8 RID: 1272 RVA: 0x000D06CC File Offset: 0x000CE8CC
        internal override _b2 ReturnType()
        {
            _b2 _AAC = this._AHX.ReturnType();
            return _AAC.SubstituteTypeParameters(this);
        }

        // Token: 0x060004F9 RID: 1273 RVA: 0x000D06F4 File Offset: 0x000CE8F4
        internal override string GetName()
        {
            List<_bd7> typeParameters = this.GetTypeParameters();
            bool flag = typeParameters == null || typeParameters.Count == 0;
            string text;
            if (flag)
            {
                text = this._AW;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(this._AW);
                stringBuilder.Append('<');
                stringBuilder.Append(this.TypeOfTypeParameter(typeParameters[0]).GetName());
                for (int i = 1; i < typeParameters.Count; i++)
                {
                    stringBuilder.Append(", ");
                    stringBuilder.Append(this.TypeOfTypeParameter(typeParameters[i]).GetName());
                }
                stringBuilder.Append('>');
                text = stringBuilder.ToString();
            }
            return text;
        }

        // Token: 0x060004FA RID: 1274 RVA: 0x000D07B4 File Offset: 0x000CE9B4
        internal override _bl4 ConstructMethod(KJK[] typeArgs)
        {
            return this._AHX.ConstructMethod(typeArgs);
        }

        // Token: 0x040004EC RID: 1260
        public readonly _bb3 _AHX;

        // Token: 0x040004ED RID: 1261
        public readonly KJK[] _AHH;
    }
}
