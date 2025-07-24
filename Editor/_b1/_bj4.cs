using System;
using System.Collections.Generic;
using System.Linq;

namespace AHO
{
    // Token: 0x0200009E RID: 158
    internal static class _bj4
    {
        // Token: 0x0600048A RID: 1162 RVA: 0x000CC018 File Offset: 0x000CA218
        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(delegate (KeyValuePair<TKey, TValue> kv)
            {
                TKey key = kv.Key;
                string text = key.ToString();
                string text2 = "=";
                TValue value = kv.Value;
                return text + text2 + value.ToString();
            }).ToArray<string>()) + "}";
        }
    }
}
