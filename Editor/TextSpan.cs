using System;

namespace SuperEditor
{
    // Token: 0x0200004D RID: 77
    public struct TextSpan
    {
        // Token: 0x06000222 RID: 546 RVA: 0x0001DD9C File Offset: 0x0001BF9C
        public override string ToString()
        {
            return string.Concat(new string[]
            {
                "TextSpan{ line = ",
                (this.line + 1).ToString(),
                ", index/fromChar = ",
                this.index.ToString(),
                ", lineOffset = ",
                this.lineOffset.ToString(),
                ", indexOffset/toChar = ",
                this.indexOffset.ToString(),
                " }"
            });
        }

        // Token: 0x06000223 RID: 547 RVA: 0x0001DE20 File Offset: 0x0001C020
        public static TextSpan CreateEmpty(TextPosition position)
        {
            return new TextSpan
            {
                line = position.line,
                index = position.index
            };
        }

        // Token: 0x06000224 RID: 548 RVA: 0x0001DE58 File Offset: 0x0001C058
        public static TextSpan Create(TextPosition from, TextPosition to)
        {
            return new TextSpan
            {
                line = from.line,
                index = from.index,
                lineOffset = to.line - from.line,
                indexOffset = to.index - ((to.line == from.line) ? from.index : 0)
            };
        }

        // Token: 0x06000225 RID: 549 RVA: 0x0001DEC8 File Offset: 0x0001C0C8
        public static TextSpan CreateBetween(TextSpan from, TextSpan to)
        {
            return TextSpan.Create(from.EndPosition, to.StartPosition);
        }

        // Token: 0x06000226 RID: 550 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
        public static TextSpan CreateEnclosing(TextSpan from, TextSpan to)
        {
            return TextSpan.Create(from.StartPosition, to.EndPosition);
        }

        // Token: 0x06000227 RID: 551 RVA: 0x0001DF18 File Offset: 0x0001C118
        public static TextSpan Create(TextPosition start, TextOffset length)
        {
            return new TextSpan
            {
                line = start.line,
                index = start.index,
                lineOffset = length.lines,
                indexOffset = length.indexOffset
            };
        }

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x06000228 RID: 552 RVA: 0x0001DF68 File Offset: 0x0001C168
        // (set) Token: 0x06000229 RID: 553 RVA: 0x0001DFA0 File Offset: 0x0001C1A0
        public TextPosition StartPosition
        {
            get
            {
                return new TextPosition
                {
                    line = this.line,
                    index = this.index
                };
            }
            set
            {
                bool flag = value.line == this.line + this.lineOffset;
                if (flag)
                {
                    this.line = value.line;
                    this.lineOffset = 0;
                    this.indexOffset = this.index + this.indexOffset - value.index;
                    this.index = value.index;
                }
                else
                {
                    this.lineOffset = this.line + this.lineOffset - value.line;
                    this.line = value.line;
                    this.index = value.index;
                }
            }
        }

        // Token: 0x17000014 RID: 20
        // (get) Token: 0x0600022A RID: 554 RVA: 0x0001E038 File Offset: 0x0001C238
        // (set) Token: 0x0600022B RID: 555 RVA: 0x0001E088 File Offset: 0x0001C288
        public TextPosition EndPosition
        {
            get
            {
                return new TextPosition
                {
                    line = this.line + this.lineOffset,
                    index = this.indexOffset + ((this.lineOffset == 0) ? this.index : 0)
                };
            }
            set
            {
                bool flag = value.line == this.line;
                if (flag)
                {
                    this.lineOffset = 0;
                    this.indexOffset = value.index - this.index;
                }
                else
                {
                    this.lineOffset = value.line - this.line;
                    this.indexOffset = value.index;
                }
            }
        }

        // Token: 0x0600022C RID: 556 RVA: 0x0001E0E7 File Offset: 0x0001C2E7
        public void Offset(int deltaLines, int deltaIndex)
        {
            this.line += deltaLines;
            this.index += deltaIndex;
        }

        // Token: 0x0600022D RID: 557 RVA: 0x0001E108 File Offset: 0x0001C308
        public bool Contains(TextPosition position)
        {
            return position.line >= this.line && (position.line != this.line || (position.index >= this.index && (this.lineOffset != 0 || position.index <= this.index + this.indexOffset))) && position.line <= this.line + this.lineOffset && (position.line != this.line + this.lineOffset || position.index <= this.indexOffset);
        }

        // Token: 0x04000258 RID: 600
        public int line;

        // Token: 0x04000259 RID: 601
        public int index;

        // Token: 0x0400025A RID: 602
        public int lineOffset;

        // Token: 0x0400025B RID: 603
        public int indexOffset;
    }
}
