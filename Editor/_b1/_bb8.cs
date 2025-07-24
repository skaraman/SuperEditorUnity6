using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x02000030 RID: 48
    internal interface _bb8
    {
        // Token: 0x0600016D RID: 365
        IEnumerable<_be5> EnumSnippets(_bh4 context, _bh2._AGI expectedTokens, SyntaxToken tokenLeft, _bm6 scope);

        // Token: 0x0600016E RID: 366
        string Get(string shortcut, _bh4 context, _bh2._AGI expectedTokens, _bm6 scope);
    }
}
