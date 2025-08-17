using System;
using System.Text.RegularExpressions;

namespace AHO
{
    // Token: 0x02000079 RID: 121
    [Serializable]
    internal struct _bj9 : IEquatable<_bj9>, IComparable<_bj9>
    {
        // Token: 0x060003B2 RID: 946 RVA: 0x000A8874 File Offset: 0x000A6A74
        public override bool Equals(object o)
        {
            bool flag = o is _bj9;
            return flag && this.Equals((_bj9)o);
        }

        // Token: 0x060003B3 RID: 947 RVA: 0x000A88A4 File Offset: 0x000A6AA4
        public override int GetHashCode()
        {
            int num = 13;
            bool mmbkelddnfgmmjjcacojbbiokincddjnnmlo = this.MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO;
            int num2;
            if (mmbkelddnfgmmjjcacojbbiokincddjnnmlo)
            {
                num = num * 7 + this.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC.GetHashCode();
                num = num * 7 + this.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK.GetHashCode();
                num = num * 7 + this.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH.GetHashCode();
                num = num * 7 + this.HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK.GetHashCode();
                num2 = num * 7 + this.BLH.GetHashCode();
            }
            else
            {
                num2 = this._ABG.GetHashCode();
            }
            return num2;
        }

        // Token: 0x060003B4 RID: 948 RVA: 0x000A8928 File Offset: 0x000A6B28
        public bool Equals(_bj9 version)
        {
            bool flag = this.MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO != version.MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool mmbkelddnfgmmjjcacojbbiokincddjnnmlo = this.MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO;
                if (mmbkelddnfgmmjjcacojbbiokincddjnnmlo)
                {
                    bool flag3 = this.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC == version.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC && this.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK == version.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK && this.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH == version.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH && this.BLH == version.BLH;
                    flag2 = flag3 && this.HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK == version.HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK;
                }
                else
                {
                    bool flag4 = string.IsNullOrEmpty(this._ABG) || string.IsNullOrEmpty(version._ABG);
                    flag2 = !flag4 && this._ABG.Equals(version._ABG);
                }
            }
            return flag2;
        }

        // Token: 0x060003B5 RID: 949 RVA: 0x000A89F0 File Offset: 0x000A6BF0
        public int CompareTo(_bj9 version)
        {
            bool flag = this.Equals(version);
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                bool flag2 = this.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC > version.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC;
                if (flag2)
                {
                    num = 1;
                }
                else
                {
                    bool flag3 = this.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC < version.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC;
                    if (flag3)
                    {
                        num = -1;
                    }
                    else
                    {
                        bool flag4 = this.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK > version.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK;
                        if (flag4)
                        {
                            num = 1;
                        }
                        else
                        {
                            bool flag5 = this.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK < version.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK;
                            if (flag5)
                            {
                                num = -1;
                            }
                            else
                            {
                                bool flag6 = this.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH > version.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH;
                                if (flag6)
                                {
                                    num = 1;
                                }
                                else
                                {
                                    bool flag7 = this.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH < version.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH;
                                    if (flag7)
                                    {
                                        num = -1;
                                    }
                                    else
                                    {
                                        bool flag8 = this.BLH > version.BLH;
                                        if (flag8)
                                        {
                                            num = 1;
                                        }
                                        else
                                        {
                                            bool flag9 = this.BLH < version.BLH;
                                            if (flag9)
                                            {
                                                num = -1;
                                            }
                                            else
                                            {
                                                bool flag10 = this.HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK > version.HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK;
                                                if (flag10)
                                                {
                                                    num = 1;
                                                }
                                                else
                                                {
                                                    num = -1;
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
            return num;
        }

        // Token: 0x060003B6 RID: 950 RVA: 0x000A8B00 File Offset: 0x000A6D00
        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", this.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC, this.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK, this.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH);
        }

        // Token: 0x060003B7 RID: 951 RVA: 0x000A8B40 File Offset: 0x000A6D40
        public static _bj9 FromString(string str)
        {
            _bj9 _zl1 = default(_bj9);
            _zl1._ABG = str;
            _bj9 _zl2;
            try
            {
                string[] array = Regex.Split(str, "[\\.A-Za-z]");
                Match match = Regex.Match(str, "A-Za-z");
                int.TryParse(array[0], out _zl1.OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC);
                int.TryParse(array[1], out _zl1.PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK);
                int.TryParse(array[2], out _zl1.BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH);
                int.TryParse(array[3], out _zl1.HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK);
                _zl1.BLH = _bj9.GetVersionType((match != null && match.Success) ? match.Value : "");
                _zl1.MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO = true;
                _zl2 = _zl1;
            }
            catch
            {
                _zl1.MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO = false;
                _zl2 = _zl1;
            }
            return _zl2;
        }

        // Token: 0x060003B8 RID: 952 RVA: 0x000A8C08 File Offset: 0x000A6E08
        private static _bi8 GetVersionType(string type)
        {
            bool flag = type.Equals("b") || type.Equals("B");
            _bi8 lhmbbnebjhbjmicofodopplghhnfbbbicnif;
            if (flag)
            {
                lhmbbnebjhbjmicofodopplghhnfbbbicnif = (_bi8)2;
            }
            else
            {
                bool flag2 = type.Equals("p") || type.Equals("P");
                if (flag2)
                {
                    lhmbbnebjhbjmicofodopplghhnfbbbicnif = (_bi8)1;
                }
                else
                {
                    lhmbbnebjhbjmicofodopplghhnfbbbicnif = (_bi8)3;
                }
            }
            return lhmbbnebjhbjmicofodopplghhnfbbbicnif;
        }

        // Token: 0x04000426 RID: 1062
        internal int OIBKGBGJIEGDFNECHAAPHPHCNLCEPEDDGDNC;

        // Token: 0x04000427 RID: 1063
        internal int PMBLIHFHDHLONFPFDKBPAAKKGEHKOIBPBIMK;

        // Token: 0x04000428 RID: 1064
        internal int BHJHJCPIEPLKAFNMFIHJOBHHMOPOIKGFGDPH;

        // Token: 0x04000429 RID: 1065
        internal int HMMKGDMFLPLHJPOJMPAEEGPDIGKIELPJOCEK;

        // Token: 0x0400042A RID: 1066
        internal _bi8 BLH;

        // Token: 0x0400042B RID: 1067
        internal string _ABG;

        // Token: 0x0400042C RID: 1068
        internal bool MMBKELDDNFGMMJJCACOJBBIOKINCDDJNNMLO;
    }
}
