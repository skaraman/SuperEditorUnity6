using System;
using System.Globalization;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200002D RID: 45
    internal class _bf6
    {
        // Token: 0x06000156 RID: 342 RVA: 0x000136F8 File Offset: 0x000118F8
        public _bf6(string filterText)
        {
            this._AWZ = filterText ?? "";
            bool flag = filterText != null;
            if (flag)
            {
                int num = 0;
                while (num < filterText.Length && num < 64)
                {
                    this._AXA |= (char.IsLower(filterText[num]) ? (1UL << num) : 0UL);
                    this._AXB |= ((!char.IsLetterOrDigit(filterText[num])) ? (1UL << num) : 0UL);
                    this._AXC |= (char.IsDigit(filterText[num]) ? (1UL << num) : 0UL);
                    num++;
                }
                this._AXD = filterText.ToUpper();
            }
            else
            {
                this._AXD = "";
            }
        }

        // Token: 0x06000157 RID: 343 RVA: 0x000137DC File Offset: 0x000119DC
        public bool CalcMatchRank(string name, out int matchRank)
        {
            bool flag = this._AXD.Length == 0;
            bool flag2;
            if (flag)
            {
                matchRank = int.MinValue;
                flag2 = true;
            }
            else
            {
                int[] match = this.GetMatch(name);
                bool flag3 = match != null;
                if (flag3)
                {
                    bool flag4 = name.Length == this._AWZ.Length;
                    if (flag4)
                    {
                        matchRank = int.MaxValue;
                        for (int i = 0; i < name.Length; i++)
                        {
                            bool flag5 = this._AWZ[i] != name[i];
                            if (flag5)
                            {
                                matchRank--;
                            }
                        }
                        flag2 = true;
                    }
                    else
                    {
                        bool flag6 = name.Length - 1 == this._AWZ.Length && name[name.Length - 1] == ':';
                        if (flag6)
                        {
                            matchRank = 2147483646;
                            for (int j = 0; j < name.Length - 1; j++)
                            {
                                bool flag7 = this._AWZ[j] != name[j];
                                if (flag7)
                                {
                                    matchRank--;
                                }
                            }
                            flag2 = true;
                        }
                        else
                        {
                            int num = 0;
                            int num2 = 0;
                            int num3 = 0;
                            int num4 = 0;
                            int num5 = -1;
                            for (int k = 0; k < match.Length; k++)
                            {
                                char c = this._AWZ[k];
                                int num6 = match[k];
                                bool flag8 = num6 > num5 + 1;
                                bool flag9 = flag8;
                                if (flag9)
                                {
                                    num4++;
                                }
                                num5 = num6;
                                bool flag10 = c == name[num6];
                                if (flag10)
                                {
                                    num3 += 1000 / (1 + num4);
                                    bool flag11 = char.IsUpper(c);
                                    if (flag11)
                                    {
                                        num += Mathf.Max(1, 10000 - 1000 * num4);
                                    }
                                }
                                else
                                {
                                    bool flag12 = flag8 || num6 == 0;
                                    if (flag12)
                                    {
                                        num3 += 900 / (1 + num4);
                                        bool flag13 = char.IsUpper(c);
                                        if (flag13)
                                        {
                                            num += Mathf.Max(1, 1000 - 100 * num4);
                                        }
                                    }
                                    else
                                    {
                                        int num7 = 600 / (1 + num4);
                                        num2 += num7;
                                    }
                                }
                            }
                            matchRank = num + num3 - num4 + num2 + this._AWZ.Length - name.Length;
                            bool flag14 = name[name.Length - 1] == ':';
                            if (flag14)
                            {
                                matchRank /= 2;
                            }
                            flag2 = true;
                        }
                    }
                }
                else
                {
                    matchRank = int.MinValue;
                    flag2 = false;
                }
            }
            return flag2;
        }

        // Token: 0x06000158 RID: 344 RVA: 0x00013A64 File Offset: 0x00011C64
        public bool IsMatch(string text)
        {
            int[] match = this.GetMatch(text);
            this._AXE = this._AXE ?? match;
            return match != null;
        }

        // Token: 0x06000159 RID: 345 RVA: 0x00013A94 File Offset: 0x00011C94
        private int GetMatchChar(string text, int i, int j, bool onlyWordStart)
        {
            char c = this._AXD[i];
            ulong num = 1UL << i;
            bool flag = (this._AXB & num) > 0UL;
            int num2;
            if (flag)
            {
                while (j < text.Length)
                {
                    bool flag2 = c == text[j];
                    if (flag2)
                    {
                        return j;
                    }
                    j++;
                }
                num2 = -1;
            }
            else
            {
                char c2 = text[j];
                bool flag3 = char.IsUpper(c2);
                bool flag4 = !onlyWordStart && c == (flag3 ? c2 : char.ToUpper(c2)) && char.IsLetter(c2);
                if (flag4)
                {
                    bool flag5 = !flag3 && (this._AXA & num) == 0UL && j + 1 < text.Length;
                    if (flag5)
                    {
                        int matchChar = this.GetMatchChar(text, i, j + 1, onlyWordStart);
                        bool flag6 = matchChar >= 0;
                        if (flag6)
                        {
                            return matchChar;
                        }
                    }
                    num2 = j;
                }
                else
                {
                    bool flag7 = false;
                    bool flag8 = false;
                    int num3 = j + 1;
                    while (j < text.Length)
                    {
                        c2 = text[j];
                        UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c2);
                        bool flag9 = unicodeCategory == UnicodeCategory.LowercaseLetter;
                        if (flag9)
                        {
                            bool flag10 = flag8 && j - num3 > 0;
                            if (flag10)
                            {
                                bool flag11 = c == char.ToUpper(text[j - 1]);
                                if (flag11)
                                {
                                    return j - 1;
                                }
                            }
                            flag7 = true;
                            flag8 = false;
                        }
                        else
                        {
                            bool flag12 = unicodeCategory == UnicodeCategory.UppercaseLetter;
                            if (flag12)
                            {
                                bool flag13 = flag7;
                                if (flag13)
                                {
                                    bool flag14 = c == char.ToUpper(c2);
                                    if (flag14)
                                    {
                                        return j;
                                    }
                                }
                                flag7 = false;
                                flag8 = true;
                            }
                            else
                            {
                                bool flag15 = c == c2;
                                if (flag15)
                                {
                                    return j;
                                }
                                bool flag16 = j + 1 < text.Length && c == char.ToUpper(text[j + 1]);
                                if (flag16)
                                {
                                    return j + 1;
                                }
                                flag8 = (flag7 = false);
                            }
                        }
                        j++;
                    }
                    num2 = -1;
                }
            }
            return num2;
        }

        // Token: 0x0600015A RID: 346 RVA: 0x00013C88 File Offset: 0x00011E88
        public int[] GetMatch(string text)
        {
            bool flag = string.IsNullOrEmpty(this._AXD);
            int[] array;
            if (flag)
            {
                array = new int[0];
            }
            else
            {
                bool flag2 = string.IsNullOrEmpty(text) || this._AWZ.Length > text.Length;
                if (flag2)
                {
                    array = null;
                }
                else
                {
                    bool flag3 = this._AXE != null;
                    int[] array2;
                    if (flag3)
                    {
                        array2 = this._AXE;
                    }
                    else
                    {
                        array2 = (this._AXE = new int[this._AXD.Length]);
                    }
                    int num = 0;
                    int i = 0;
                    bool flag4 = false;
                    while (i < this._AWZ.Length)
                    {
                        bool flag5 = num >= text.Length;
                        if (flag5)
                        {
                            bool flag6 = i > 0;
                            if (!flag6)
                            {
                                return null;
                            }
                            num = array2[--i] + 1;
                            flag4 = true;
                        }
                        else
                        {
                            num = this.GetMatchChar(text, i, num, flag4);
                            flag4 = false;
                            bool flag7 = num == -1;
                            if (flag7)
                            {
                                bool flag8 = i > 0;
                                if (!flag8)
                                {
                                    return null;
                                }
                                num = array2[--i] + 1;
                                flag4 = true;
                            }
                            else
                            {
                                array2[i] = num++;
                                i++;
                            }
                        }
                    }
                    this._AXE = null;
                    array = array2;
                }
            }
            return array;
        }

        // Token: 0x0400017A RID: 378
        private readonly string _AXD;

        // Token: 0x0400017B RID: 379
        private readonly ulong _AXA;

        // Token: 0x0400017C RID: 380
        private readonly ulong _AXB;

        // Token: 0x0400017D RID: 381
        private readonly ulong _AXC;

        // Token: 0x0400017E RID: 382
        private readonly string _AWZ;

        // Token: 0x0400017F RID: 383
        private int[] _AXE;
    }
}
