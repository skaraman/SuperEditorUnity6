using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000EF RID: 239
    internal interface _bg6
    {
        // Token: 0x060006E3 RID: 1763
        bool CanFix(CodeIssue issue, GCE textBuffer, SyntaxToken token);

        // Token: 0x060006E4 RID: 1764
        IEnumerable<_AQA> EnumFixes(CodeIssue issue, GCE textBuffer, SyntaxToken token);
    }
}
