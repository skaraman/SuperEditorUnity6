using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000EB RID: 235
    internal class _bg2 : _bl2, _AQA
    {
        // Token: 0x060006DD RID: 1757 RVA: 0x000E871A File Offset: 0x000E691A
        public _bg2(_b2 type)
        {
            this.BLH = type;
        }

        // Token: 0x060006DE RID: 1758 RVA: 0x000E87D8 File Offset: 0x000E69D8
        public string GetTitle(SyntaxToken token)
        {
            return "using " + this.BLH._AO._AYM() + ";";
        }

        // Token: 0x060006DF RID: 1759 RVA: 0x000E880C File Offset: 0x000E6A0C
        public void Apply(_bi2 editor, SyntaxToken token)
        {
            _bb4._ACW _AGZ = base.EnclosingNamespaceScopeNode(token);
            bool flag = _AGZ == null;
            if (!flag)
            {
                _bb4._AIN _AIO = _AGZ.FindChildByName("namespaceMemberDeclaration");
                bool flag2 = _AIO == null;
                if (!flag2)
                {
                    GCE _AMX = editor._ABK();
                    _bb4.DHBA _AEM = _AIO.FindPreviousLeaf();
                    bool flag3 = _AEM != null;
                    TextPosition endPosition;
                    if (flag3)
                    {
                        endPosition = editor._ABK().GetTokenSpan(_AEM).EndPosition;
                    }
                    else
                    {
                        endPosition = new TextPosition(_AIO.GetFirstLeaf().line, 0);
                        while (endPosition.line > 0)
                        {
                            SyntaxToken syntaxToken;
                            SyntaxToken syntaxToken2;
                            _AMX.GetFirstTokens(endPosition.line - 1, out syntaxToken, out syntaxToken2);
                            bool flag4 = syntaxToken2 != null;
                            if (flag4)
                            {
                                break;
                            }
                            bool flag5 = syntaxToken != null && syntaxToken.text != "//";
                            if (flag5)
                            {
                                break;
                            }
                            bool flag6 = syntaxToken != null;
                            if (flag6)
                            {
                                List<SyntaxToken> _ABS = _AMX._AQQ[endPosition.line - 1].EOIA;
                                bool flag7 = _ABS.Count <= syntaxToken.TokenIndex + 1 || !_ABS[syntaxToken.TokenIndex + 1].text.StartsWith("/", StringComparison.Ordinal);
                                if (flag7)
                                {
                                    break;
                                }
                            }
                            endPosition.line--;
                        }
                    }
                    editor.SetCursorPosition(endPosition.line, endPosition.index);
                    bool flag8 = _AEM != null;
                    if (flag8)
                    {
                        editor._ABK().InsertText(editor._ABH, "\nusing " + this.BLH._AO._AYM() + ";");
                    }
                    else
                    {
                        editor._ABK().InsertText(editor._ABH, "using " + this.BLH._AO._AYM() + ";\n");
                    }
                    editor._ABK().UpdateHighlighting(endPosition.line, endPosition.line + 1, false);
                    editor.ReindentLines(endPosition.line, endPosition.line + 1);
                }
            }
        }
    }
}
