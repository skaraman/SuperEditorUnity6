using System;
using System.Collections.Generic;
using SuperEditor;
using UnityEditor;

namespace AHO
{
    // Token: 0x020000F1 RID: 241
    [InitializeOnLoad]
    internal class _bd3 : _bg6
    {
        // Token: 0x060006E6 RID: 1766 RVA: 0x000E8A24 File Offset: 0x000E6C24
        static _bd3()
        {
            _bc9.RegisterCodeFixProvider(new _bd3());
        }

        // Token: 0x060006E7 RID: 1767 RVA: 0x000E8A34 File Offset: 0x000E6C34
        public bool CanFix(CodeIssue issue, GCE textBuffer, SyntaxToken token)
        {
            return issue.kind == CodeIssue.Kind.UnknownSymbol;
        }

        // Token: 0x060006E8 RID: 1768 RVA: 0x000E8A4F File Offset: 0x000E6C4F
        public IEnumerable<_AQA> EnumFixes(CodeIssue issue, GCE textBuffer, SyntaxToken token)
        {
            bool flag = token.OOME.OOME != null && (token.OOME.OOME._AHB() == "primaryExpressionStart" || token.OOME.OOME._AHB() == "typeOrGeneric");
            if (flag)
            {
                int lineIndex = token.Line;
                int tokenIndex = token.TokenIndex;
                SyntaxToken prevToken = textBuffer.GetTokenLeftOf(ref lineIndex, ref tokenIndex);
                bool flag2 = prevToken != null && prevToken.tokenKind == SyntaxToken.Kind.Missing;
                if (flag2)
                {
                    yield break;
                }
                _bb4._ACW tokenScopeNode = token.OOME.OOME;
                while (tokenScopeNode != null && tokenScopeNode._AJW == null)
                {
                    tokenScopeNode = tokenScopeNode.OOME;
                }
                bool flag3 = tokenScopeNode == null;
                if (flag3)
                {
                    yield break;
                }
                _bb4._ACW enclosingNamespaceScopeNode = tokenScopeNode;
                while (enclosingNamespaceScopeNode != null && !(enclosingNamespaceScopeNode._AJW is _bc8))
                {
                    enclosingNamespaceScopeNode = enclosingNamespaceScopeNode.OOME;
                }
                bool flag4 = enclosingNamespaceScopeNode == null;
                if (flag4)
                {
                    yield break;
                }
                _bc8 namespaceScope = enclosingNamespaceScopeNode._AJW as _bc8;
                IEnumerable<_b2> allTypes = namespaceScope.GetAssembly().EnumTypes(token.text);
                foreach (_b2 type in allTypes)
                {
                    yield return new _bg2(type);
                    yield return new _bk2(type);
                }
                IEnumerator<_b2> enumerator = null;
                bool flag5 = token.text.Length > "Attribute".Length && !token.text.EndsWith("Attribute", StringComparison.Ordinal) && token.OOME.OOME._AHB() == "typeOrGeneric" && token.OOME.OOME.OOME != null && token.OOME.OOME.OOME.OOME != null && token.OOME.OOME.OOME.OOME.OOME != null && token.OOME.OOME.OOME.OOME.OOME._AHB() == "attribute";
                if (flag5)
                {
                    allTypes = namespaceScope.GetAssembly().EnumTypes(token.text + "Attribute");
                    foreach (_b2 type2 in allTypes)
                    {
                        yield return new _bg2(type2);
                        yield return new _bk2(type2);
                    }
                    IEnumerator<_b2> enumerator2 = null;
                }
                prevToken = null;
                tokenScopeNode = null;
                enclosingNamespaceScopeNode = null;
                namespaceScope = null;
                allTypes = null;
            }
            yield break;
        }
    }
}
