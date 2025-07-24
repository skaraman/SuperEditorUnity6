using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x0200001B RID: 27
    internal class _bf9 : _bb8
    {
        // Token: 0x060000D6 RID: 214 RVA: 0x0000B470 File Offset: 0x00009670
        public IEnumerable<_be5> EnumSnippets(_bh4 context, _bh2._AGI expectedTokens, SyntaxToken tokenLeft, _bm6 scope)
        {
            bool flag = scope == null;
            if (flag)
            {
                yield break;
            }
            _bj8 bodyScope = (scope as _bj8) ?? (scope._AMJ() as _bj8);
            bool flag2 = bodyScope == null;
            if (flag2)
            {
                yield break;
            }
            _b2 contextType = bodyScope._ACV as _b2;
            bool flag3 = contextType == null || (contextType._AT != SymbolKind.Class && contextType._AT != SymbolKind.Struct);
            if (flag3)
            {
                yield break;
            }
            bool flag4 = tokenLeft == null || tokenLeft.OOME == null || tokenLeft.OOME.OOME == null;
            if (flag4)
            {
                yield break;
            }
            bool flag5 = tokenLeft.tokenKind != SyntaxToken.Kind.Punctuator;
            if (flag5)
            {
                yield break;
            }
            bool flag6 = tokenLeft.text != "{" && tokenLeft.text != "}" && tokenLeft.text != ";";
            if (flag6)
            {
                yield break;
            }
            int i = contextType._AAG.Count;
            for (; ; )
            {
                int num = i;
                i = num - 1;
                if (num <= 0)
                {
                    break;
                }
                _bh4 member = contextType._AAG._AAI(i);
                bool flag7 = member._AT == SymbolKind.Field;
                if (flag7)
                {
                    _bh4 type = member.TypeOf();
                    bool flag8 = type == null || type._AT == SymbolKind.Error || !(type is _b2);
                    if (flag8)
                    {
                        continue;
                    }
                    string fieldName = member._AW;
                    bool flag9 = string.IsNullOrEmpty(fieldName) || fieldName[0] == '.';
                    if (flag9)
                    {
                        continue;
                    }
                    fieldName = char.ToUpperInvariant(fieldName[0]).ToString() + fieldName.Substring(1);
                    string propertyName = fieldName;
                    int suffix = 1;
                    while (contextType._AAG.Contains(propertyName, -1))
                    {
                        propertyName = fieldName + suffix.ToString();
                        num = suffix + 1;
                        suffix = num;
                    }
                    yield return new _bf9._AXF(propertyName, member, true);
                    yield return new _bf9._AXF(propertyName, member, false);
                    type = null;
                    fieldName = null;
                    propertyName = null;
                }
                member = null;
            }
            yield break;
        }

        // Token: 0x060000D7 RID: 215 RVA: 0x0000B4A0 File Offset: 0x000096A0
        public string Get(string shortcut, _bh4 context, _bh2._AGI expectedTokens, _bm6 scope)
        {
            return null;
        }

        // Token: 0x0200001C RID: 28
        private class _AXF : _be5
        {
            // Token: 0x060000D9 RID: 217 RVA: 0x0000B4B3 File Offset: 0x000096B3
            public _AXF(string propertyName, _bh4 field, bool withSetter)
                : base(propertyName, withSetter ? "{0} {{ get {{...}} set {{...}} }}" : "{0} {{ get {{...}} }}")
            {
                this._AXG = field;
                this._AXH = withSetter;
            }

            // Token: 0x060000DA RID: 218 RVA: 0x0000B4DC File Offset: 0x000096DC
            public override string Expand()
            {
                _bh4 _AAH = this._AXG.Rebind() ?? this._AXG;
                FKI _AFF = _AAH._AEI.FirstOrDefault<FKI>();
                bool flag = _AFF == null;
                string text;
                if (flag)
                {
                    text = "";
                }
                else
                {
                    _bm6 _AXI = _AFF._AJW;
                    _bh4 _AAH2 = _AAH.TypeOf();
                    string text2 = _AAH2._AU.ToCSharpString();
                    bool flag2 = text2 == "private";
                    if (flag2)
                    {
                        text2 = "internal";
                    }
                    string text3 = (_AAH.IsStatic ? "static " : "");
                    string text4 = _AAH.TypeOf().RelativeName(_AXI);
                    string text5 = "{0} {1}{2} {3} {{\n\tget {{ return {4}; }}\n" + (this._AXH ? "\tset {{ {4} = value;$end$ }}\n}}" : "}}$end$");
                    text = string.Format(text5, new object[] { text2, text3, text4, this._AW, _AAH._AW });
                }
                return text;
            }

            // Token: 0x040000C9 RID: 201
            private _bh4 _AXG;

            // Token: 0x040000CA RID: 202
            private bool _AXH;
        }
    }
}
