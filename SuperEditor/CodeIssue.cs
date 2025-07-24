using System;

namespace SuperEditor
{
    // Token: 0x020000EC RID: 236
    public struct CodeIssue
    {
        // Token: 0x060006E0 RID: 1760 RVA: 0x000E8A1A File Offset: 0x000E6C1A
        public CodeIssue(CodeIssue.Kind issueKind)
        {
            this.kind = issueKind;
        }

        // Token: 0x040005B2 RID: 1458
        public CodeIssue.Kind kind;

        // Token: 0x020000ED RID: 237
        public enum Kind
        {
            // Token: 0x040005B4 RID: 1460
            None,
            // Token: 0x040005B5 RID: 1461
            UnknownSymbol,
            // Token: 0x040005B6 RID: 1462
            UnknownMember
        }
    }
}
