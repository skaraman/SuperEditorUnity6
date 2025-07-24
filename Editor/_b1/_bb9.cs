using System;
using System.Collections.Generic;

namespace AHO
{
    // Token: 0x020000E2 RID: 226
    internal class _bb9 : _bm6
    {
        // Token: 0x06000691 RID: 1681 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public _bb9(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x06000692 RID: 1682 RVA: 0x000E6270 File Offset: 0x000E4470
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            bool flag = numTypeArgs == 0 && !asTypeOnly;
            if (flag)
            {
                bool flag2 = leaf._AIL == 0 && leaf.OOME != null && leaf.OOME.OOME == this._AEJ;
                if (flag2)
                {
                    _bb4._ACW _AMI = this._AEJ.OOME.OOME.OOME;
                    bool flag3 = _AMI._AHB() == "objectCreationExpression";
                    _bb4._AIN _AIO;
                    if (flag3)
                    {
                        _AIO = _AMI.OOME.NodeAt(1);
                    }
                    else
                    {
                        _AIO = _AMI.LeafAt(0);
                    }
                    bool flag4 = _AIO != null;
                    if (flag4)
                    {
                        _bh4 _AAH = _AIO._AAB();
                        bool flag5 = _AAH != null;
                        if (flag5)
                        {
                            _AAH = _AAH.TypeOf();
                        }
                        else
                        {
                            _AAH = _bh4.ResolveNode(_AIO, base._AMJ(), null, 0, false);
                        }
                        bool flag6 = _AAH != null;
                        if (flag6)
                        {
                            _AAH.ResolveMember(leaf, base._AMJ(), 0, false);
                        }
                        return;
                    }
                }
            }
            base.Resolve(leaf, numTypeArgs, asTypeOnly);
        }

        // Token: 0x06000693 RID: 1683 RVA: 0x000E6374 File Offset: 0x000E4574
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            _bb4._AIN _AMK = context._AML;
            bool flag = _AMK.OOME != null && (_AMK.OOME == this._AEJ || (_AMK._AIL == 0 && _AMK.OOME.OOME == this._AEJ));
            if (flag)
            {
                _bb4._ACW _AMI = this._AEJ.OOME.OOME.OOME;
                bool flag2 = _AMI._AHB() == "objectCreationExpression";
                _bb4._AIN _AIO;
                _bh4 _AAH;
                if (flag2)
                {
                    _AIO = _AMI.OOME;
                    _AAH = _bh4.ResolveNode(_AIO, null, null, 0, false);
                    _b2 _AAC = _AAH as _b2;
                    bool flag3 = _AAC != null;
                    if (flag3)
                    {
                        _AAH = _AAC.GetThisInstance();
                    }
                }
                else
                {
                    _AIO = _AMI.OOME.LeafAt(0);
                    _AAH = _bh4.ResolveNode(_AMI.OOME.LeafAt(0), null, null, 0, false);
                }
                bool flag4 = _AAH != null;
                if (flag4)
                {
                    HashSet<_bh4> hashSet = new HashSet<_bh4>();
                    _bc9.GetCompletions((_bf4)512, _AIO, hashSet, _bm6._AMM);
                    foreach (_bh4 _AAH2 in hashSet)
                    {
                        data.Add(_AAH2._AW, _AAH2);
                    }
                }
            }
            else
            {
                base.GetCompletionData(data, context);
            }
        }

        // Token: 0x06000694 RID: 1684 RVA: 0x000E64DC File Offset: 0x000E46DC
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            return base._AMJ().AddDeclaration(symbol);
        }

        // Token: 0x06000695 RID: 1685 RVA: 0x000E5C2E File Offset: 0x000E3E2E
        internal override void RemoveDeclaration(FKI symbol)
        {
            base._AMJ().RemoveDeclaration(symbol);
        }

        // Token: 0x06000696 RID: 1686 RVA: 0x000E64FA File Offset: 0x000E46FA
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            throw new InvalidOperationException("Calling FindName on MemberInitializerScope is not allowed!");
        }
    }
}
