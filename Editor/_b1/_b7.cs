using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x0200009C RID: 156
    internal static class _b7
    {
        // Token: 0x06000485 RID: 1157 RVA: 0x000CBEB0 File Offset: 0x000CA0B0
        public static string ToCSharpString(this AccessLevel self)
        {
            string text;
            switch (self)
            {
                case AccessLevel.ProtectedOrInternal:
                    text = "protected internal";
                    break;
                case AccessLevel.Protected:
                    text = "protected";
                    break;
                case AccessLevel.Internal:
                    text = "internal";
                    break;
                case AccessLevel.Public:
                    text = "public";
                    break;
                default:
                    text = "private";
                    break;
            }
            return text;
        }
    }
}
