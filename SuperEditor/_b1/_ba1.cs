using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000B3 RID: 179
    internal class _ba1 : _bc6
    {
        // Token: 0x06000534 RID: 1332 RVA: 0x000D1E08 File Offset: 0x000D0008
        public KJK _ACZ()
        {
            bool flag = this._ADA == null;
            if (flag)
            {
                this._ADA = new KJK(_bh4._AAQ);
            }
            return this._ADA;
        }

        // Token: 0x06000535 RID: 1333 RVA: 0x000D1E40 File Offset: 0x000D0040
        public void _ADB(KJK value)
        {
            bool flag = this._ADA == value;
            if (!flag)
            {
                bool flag2 = this._ADC != null;
                if (flag2)
                {
                    this._ADC = null;
                }
                bool flag3 = this._ADD != null;
                if (flag3)
                {
                    this._ADD = null;
                }
                this._ADA = value;
            }
        }

        // Token: 0x06000536 RID: 1334 RVA: 0x000D1E8C File Offset: 0x000D008C
        internal override _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            bool flag = memberName == "op_Addition" && this._ADC == null && this._ADA.definition.IsValid();
            if (flag)
            {
                this._ADC = new _ba7
                {
                    _AT = SymbolKind.MethodGroup,
                    _AW = "op_Addition",
                    _AV = (Modifiers.Public | Modifiers.Static),
                    _AO = this
                };
                base.AddMember(this._ADC);
                this._ADC.AddMethod(_bb3.CreateOperator("op_Addition", this, this, this._ADA.definition as _b2));
                this._ADC.AddMethod(_bb3.CreateOperator("op_Addition", this, this._ADA.definition as _b2, this));
            }
            else
            {
                bool flag2 = memberName == "op_Subtraction" && this._ADD == null && this._ADA.definition.IsValid();
                if (flag2)
                {
                    this._ADD = new _ba7
                    {
                        _AT = SymbolKind.MethodGroup,
                        _AW = "op_Subtraction",
                        _AV = (Modifiers.Public | Modifiers.Static),
                        _AO = this
                    };
                    base.AddMember(this._ADD);
                    this._ADD.AddMethod(_bb3.CreateOperator("op_Subtraction", this._ADA.definition as _b2, this, this));
                    this._ADD.AddMethod(_bb3.CreateOperator("op_Subtraction", this, this, this._ADA.definition as _b2));
                }
            }
            return base.FindName(memberName, numTypeParameters, asTypeOnly);
        }

        // Token: 0x06000537 RID: 1335 RVA: 0x000D2024 File Offset: 0x000D0224
        internal override _b2 BaseType()
        {
            return _bh4._ADE;
        }

        // Token: 0x040004F8 RID: 1272
        private KJK _ADA;

        // Token: 0x040004F9 RID: 1273
        private _ba7 _ADC;

        // Token: 0x040004FA RID: 1274
        private _ba7 _ADD;
    }
}
