using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000C4 RID: 196
    internal class _bk6 : _b2
    {
        // Token: 0x0600056F RID: 1391 RVA: 0x000D3C04 File Offset: 0x000D1E04
        internal override bool CanConvertTo(_b2 otherType)
        {
            return this.ConvertTo(otherType) != null;
        }

        // Token: 0x06000570 RID: 1392 RVA: 0x000D3C2C File Offset: 0x000D1E2C
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
                bool flag2 = otherType._AT != SymbolKind.Delegate;
                if (flag2)
                {
                    _AAC = null;
                }
                else
                {
                    FKI _AFF = this._AEI.FirstOrDefault<FKI>();
                    bool flag3 = _AFF == null;
                    if (flag3)
                    {
                        _AAC = null;
                    }
                    else
                    {
                        bool flag4 = _AFF._AEJ._AIX == 0;
                        if (flag4)
                        {
                            _AAC = null;
                        }
                        else
                        {
                            List<_bm1> parameters = otherType.GetParameters();
                            int num = ((parameters != null) ? parameters.Count : 0);
                            bool flag5 = _AFF._AEJ._AHB() == "anonymousMethodExpression";
                            if (flag5)
                            {
                                _bb4._ACW _AGZ = _AFF._AEJ.FindChildByName("explicitAnonymousFunctionSignature") as _bb4._ACW;
                                bool flag6 = _AGZ == null;
                                if (flag6)
                                {
                                    _AAC = otherType;
                                }
                                else
                                {
                                    _bb4._ACW _AGZ2 = _AGZ.FindChildByName("explicitAnonymousFunctionParameterList") as _bb4._ACW;
                                    int num2 = (int)((_AGZ2 == null) ? 0 : ((_AGZ2._AIX + 1) / 2));
                                    bool flag7 = num == num2;
                                    if (flag7)
                                    {
                                        _AAC = otherType;
                                    }
                                    else
                                    {
                                        _AAC = null;
                                    }
                                }
                            }
                            else
                            {
                                _bb4._ACW _AGZ3 = _AFF._AEJ.NodeAt(0);
                                bool flag8 = _AGZ3._AIX == 1 && _AGZ3.NodeAt(0) != null;
                                if (flag8)
                                {
                                    bool flag9 = num == 1;
                                    if (flag9)
                                    {
                                        return otherType;
                                    }
                                }
                                else
                                {
                                    _bb4._ACW _AGZ4 = (_AGZ3.FindChildByName("implicitAnonymousFunctionParameterList") ?? _AGZ3.FindChildByName("explicitAnonymousFunctionParameterList")) as _bb4._ACW;
                                    int num3 = (int)((_AGZ4 == null) ? 0 : ((_AGZ4._AIX + 1) / 2));
                                    bool flag10 = num == num3;
                                    if (flag10)
                                    {
                                        return otherType;
                                    }
                                }
                                _AAC = null;
                            }
                        }
                    }
                }
            }
            return _AAC;
        }

        // Token: 0x06000571 RID: 1393 RVA: 0x000D3DC8 File Offset: 0x000D1FC8
        private new _bh4 TypeOf()
        {
            FKI _AFF = this._AEI.FirstOrDefault<FKI>();
            bool flag = _AFF == null;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = _bh4._AHA;
            }
            else
            {
                bool flag2 = _AFF._AEJ._AIX != 3;
                if (flag2)
                {
                    _AAH = _bh4._AHA;
                }
                else
                {
                    _bb4._ACW _AGZ = _AFF._AEJ.NodeAt(2);
                    _bh4 _AAH2 = _bh4.ResolveNode(_AGZ, null, null, 0, false);
                    _bh4 _AAH3 = ((_AAH2 == null) ? _bh4._AHA : _AAH2.TypeOf());
                    _AAH = _AAH3;
                }
            }
            return _AAH;
        }

        // Token: 0x06000572 RID: 1394 RVA: 0x000D3E48 File Offset: 0x000D2048
        internal override _b2 BindTypeArgument(_b2 typeArgument, _b2 argumentType)
        {
            _b2 _AAC = this.TypeOf() as _b2;
            bool flag = _AAC != null && _AAC._AT != SymbolKind.Error;
            _b2 _AAC3;
            if (flag)
            {
                _b2 _AAC2 = argumentType.BindTypeArgument(typeArgument, _AAC);
                _AAC3 = _AAC2;
            }
            else
            {
                _AAC3 = null;
            }
            return _AAC3;
        }
    }
}
