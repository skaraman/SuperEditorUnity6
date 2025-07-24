using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000EA RID: 234
    internal class _bk2 : _bl2, _AQA
    {
        // Token: 0x060006DA RID: 1754 RVA: 0x000E871A File Offset: 0x000E691A
        public _bk2(_b2 type)
        {
            this.BLH = type;
        }

        // Token: 0x060006DB RID: 1755 RVA: 0x000E872C File Offset: 0x000E692C
        public string GetTitle(SyntaxToken token)
        {
            return this.BLH._AO._AYM() + "." + token.text;
        }

        // Token: 0x060006DC RID: 1756 RVA: 0x000E8760 File Offset: 0x000E6960
        public void Apply(_bi2 editor, SyntaxToken token)
        {
            TextSpan tokenSpan = editor._ABK().GetTokenSpan(token.OOME);
            editor.SetCursorPosition(tokenSpan.line, tokenSpan.index);
            editor._ABK().InsertText(editor._ABH, this.BLH._AO._AYM() + ".");
            editor._ABK().UpdateHighlighting(tokenSpan.line, tokenSpan.line, false);
        }
    }
}
