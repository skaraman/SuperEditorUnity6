using System;
using System.Globalization;

namespace AHO
{
    // Token: 0x020000C2 RID: 194
    internal static class _bi3
    {
        // Token: 0x06000560 RID: 1376 RVA: 0x000D31F0 File Offset: 0x000D13F0
        public static _bh4 FromText(string text)
        {
            bool flag = text[0] == '-';
            bool flag2 = text.StartsWith(flag ? "-0x" : "0x", StringComparison.OrdinalIgnoreCase);
            text = (flag ? text.Substring(flag2 ? 3 : 1) : (flag2 ? text.Substring(2) : text));
            ulong num;
            bool flag3 = !ulong.TryParse(text, flag2 ? NumberStyles.AllowHexSpecifier : NumberStyles.None, NumberFormatInfo.InvariantInfo, out num);
            _bh4 _AAH;
            if (flag3)
            {
                _AAH = _bh4._AAQ.GetThisInstance();
            }
            else
            {
                bool flag4 = num == 0UL;
                if (flag4)
                {
                    _AAH = _bi3._yh9.GetThisInstance();
                }
                else
                {
                    bool flag5 = flag;
                    if (flag5)
                    {
                        bool flag6 = num <= 128UL;
                        if (flag6)
                        {
                            _AAH = _bi3._yi1.GetThisInstance();
                        }
                        else
                        {
                            bool flag7 = num <= 32768UL;
                            if (flag7)
                            {
                                _AAH = _bi3._yi2.GetThisInstance();
                            }
                            else
                            {
                                bool flag8 = num <= unchecked((ulong)int.MinValue);
                                if (flag8)
                                {
                                    _AAH = _bi3._yi3.GetThisInstance();
                                }
                                else
                                {
                                    bool flag9 = num <= 9223372036854775808UL;
                                    if (flag9)
                                    {
                                        _AAH = _bh4._AAR.GetThisInstance();
                                    }
                                    else
                                    {
                                        _AAH = _bh4._AAQ.GetThisInstance();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bool flag10 = num <= 127UL;
                        if (flag10)
                        {
                            _AAH = _bi3._yi4.GetThisInstance();
                        }
                        else
                        {
                            bool flag11 = num <= 255UL;
                            if (flag11)
                            {
                                _AAH = _bi3._yi5.GetThisInstance();
                            }
                            else
                            {
                                bool flag12 = num <= 32767UL;
                                if (flag12)
                                {
                                    _AAH = _bi3._yi6.GetThisInstance();
                                }
                                else
                                {
                                    bool flag13 = num <= 65535UL;
                                    if (flag13)
                                    {
                                        _AAH = _bi3._yi7.GetThisInstance();
                                    }
                                    else
                                    {
                                        bool flag14 = num <= 2147483647UL;
                                        if (flag14)
                                        {
                                            _AAH = _bi3._yi8.GetThisInstance();
                                        }
                                        else
                                        {
                                            bool flag15 = num <= unchecked((ulong)(-1));
                                            if (flag15)
                                            {
                                                _AAH = _bi3._yi9.GetThisInstance();
                                            }
                                            else
                                            {
                                                bool flag16 = num <= 9223372036854775807UL;
                                                if (flag16)
                                                {
                                                    _AAH = _bi3._yj1.GetThisInstance();
                                                }
                                                else
                                                {
                                                    _AAH = _bh4._AAV.GetThisInstance();
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
            return _AAH;
        }

        // Token: 0x040004FE RID: 1278
        private static readonly _bn8 _yh9 = new _bn8();

        // Token: 0x040004FF RID: 1279
        private static readonly _bc4 _yi4 = new _bc4();

        // Token: 0x04000500 RID: 1280
        private static readonly _bk8 _yi5 = new _bk8();

        // Token: 0x04000501 RID: 1281
        private static readonly _ABL _yi1 = new _ABL();

        // Token: 0x04000502 RID: 1282
        private static readonly _bc3 _yi6 = new _bc3();

        // Token: 0x04000503 RID: 1283
        private static readonly _bm9 _yi7 = new _bm9();

        // Token: 0x04000504 RID: 1284
        private static readonly _bn6 _yi2 = new _bn6();

        // Token: 0x04000505 RID: 1285
        private static readonly _be1 _yi8 = new _be1();

        // Token: 0x04000506 RID: 1286
        private static readonly _be6 _yi9 = new _be6();

        // Token: 0x04000507 RID: 1287
        private static readonly _bj3 _yi3 = new _bj3();

        // Token: 0x04000508 RID: 1288
        private static readonly _b8 _yj1 = new _b8();
    }
}
