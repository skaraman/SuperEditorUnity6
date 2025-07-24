using System;
using SuperEditor;
using UnityEditor;

namespace AHO
{
    // Token: 0x020000F5 RID: 245
    [InitializeOnLoad]
    internal class _bb5 : _bi7
    {
        // Token: 0x06000701 RID: 1793 RVA: 0x000EACC4 File Offset: 0x000E8EC4
        static _bb5()
        {
            _bc9.RegisterIssueProvider(new _bb5());
        }

        // Token: 0x06000702 RID: 1794 RVA: 0x000EACD4 File Offset: 0x000E8ED4
        public CodeIssue Check(GCE textBuffer, SyntaxToken token)
        {
            bool flag = token.OOME != null && token.OOME._AAB() != null && token.OOME._AJF == "unknown symbol";
            CodeIssue codeIssue;
            if (flag)
            {
                codeIssue = new CodeIssue(CodeIssue.Kind.UnknownSymbol);
            }
            else
            {
                codeIssue = new CodeIssue(CodeIssue.Kind.None);
            }
            return codeIssue;
        }
    }
}
