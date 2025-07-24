using System;
using System.Collections.Generic;

namespace AHO
{
    // Token: 0x0200009D RID: 157
    internal static class _bd9
    {
        // Token: 0x06000486 RID: 1158 RVA: 0x000CBF08 File Offset: 0x000CA108
        public static T FirstOrDefault<T>(this List<T> self)
        {
            return (self.Count == 0) ? default(T) : self[0];
        }

        // Token: 0x06000487 RID: 1159 RVA: 0x000CBF34 File Offset: 0x000CA134
        public static T ElementAtOrDefault<T>(this List<T> self, int index)
        {
            return (index >= self.Count) ? default(T) : self[index];
        }

        // Token: 0x06000488 RID: 1160 RVA: 0x000CBF64 File Offset: 0x000CA164
        public static T FirstByName<T>(this List<T> self, string name) where T : _bh4
        {
            int count = self.Count;
            for (int i = 0; i < count; i++)
            {
                bool flag = self[i]._AW == name;
                if (flag)
                {
                    return self[i];
                }
            }
            return default(T);
        }

        // Token: 0x06000489 RID: 1161 RVA: 0x000CBFC0 File Offset: 0x000CA1C0
        public static T LastByName<T>(this List<T> self, string name) where T : _bh4
        {
            int count = self.Count;
            while (count-- > 0)
            {
                bool flag = self[count]._AW == name;
                if (flag)
                {
                    return self[count];
                }
            }
            return default(T);
        }
    }
}
