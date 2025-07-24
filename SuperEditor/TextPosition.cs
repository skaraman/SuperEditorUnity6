using System;
using AHO;

namespace SuperEditor
{
    // Token: 0x0200004B RID: 75
    public struct TextPosition
    {
        // Token: 0x06000215 RID: 533 RVA: 0x0001D96A File Offset: 0x0001BB6A
        public TextPosition(int line, int index)
        {
            this.line = line;
            this.index = index;
        }

        // Token: 0x06000216 RID: 534 RVA: 0x0001D97C File Offset: 0x0001BB7C
        public static TextPosition operator +(TextPosition other, int offset)
        {
            return new TextPosition
            {
                line = other.line,
                index = other.index + offset
            };
        }

        // Token: 0x06000217 RID: 535 RVA: 0x0001D9B4 File Offset: 0x0001BBB4
        public static bool operator ==(TextPosition lhs, TextPosition rhs)
        {
            return lhs.line == rhs.line && lhs.index == rhs.index;
        }

        // Token: 0x06000218 RID: 536 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
        public static bool operator !=(TextPosition lhs, TextPosition rhs)
        {
            return lhs.line != rhs.line || lhs.index != rhs.index;
        }

        // Token: 0x06000219 RID: 537 RVA: 0x0001DA1C File Offset: 0x0001BC1C
        public static bool operator <(TextPosition lhs, TextPosition rhs)
        {
            return lhs.line < rhs.line || (lhs.line == rhs.line && lhs.index < rhs.index);
        }

        // Token: 0x0600021A RID: 538 RVA: 0x0001DA60 File Offset: 0x0001BC60
        public static bool operator <=(TextPosition lhs, TextPosition rhs)
        {
            return lhs.line < rhs.line || (lhs.line == rhs.line && lhs.index <= rhs.index);
        }

        // Token: 0x0600021B RID: 539 RVA: 0x0001DAA8 File Offset: 0x0001BCA8
        public static bool operator >(TextPosition lhs, TextPosition rhs)
        {
            return lhs.line > rhs.line || (lhs.line == rhs.line && lhs.index > rhs.index);
        }

        // Token: 0x0600021C RID: 540 RVA: 0x0001DAEC File Offset: 0x0001BCEC
        public static bool operator >=(TextPosition lhs, TextPosition rhs)
        {
            return lhs.line > rhs.line || (lhs.line == rhs.line && lhs.index >= rhs.index);
        }

        // Token: 0x0600021D RID: 541 RVA: 0x0001DB34 File Offset: 0x0001BD34
        public override bool Equals(object obj)
        {
            bool flag = !(obj is TextPosition);
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                TextPosition textPosition = (TextPosition)obj;
                flag2 = this.line == textPosition.line && this.index == textPosition.index;
            }
            return flag2;
        }

        // Token: 0x0600021E RID: 542 RVA: 0x0001DB80 File Offset: 0x0001BD80
        public override int GetHashCode()
        {
            int num = -2128831035;
            num = (num * 16777619) ^ this.line.GetHashCode();
            return (num * 16777619) ^ this.index.GetHashCode();
        }

        // Token: 0x0600021F RID: 543 RVA: 0x0001DBC4 File Offset: 0x0001BDC4
        internal bool Move(GCE textBuffer, int offset)
        {
            while (offset > 0)
            {
                int length = textBuffer.FLOg[this.line].Length;
                bool flag = this.index + offset <= length;
                bool flag3;
                if (flag)
                {
                    this.index += offset;
                    bool flag2 = this.index == length;
                    if (flag2)
                    {
                        this.index = 0;
                        this.line++;
                    }
                    flag3 = true;
                }
                else
                {
                    offset -= length - this.index;
                    this.line++;
                    this.index = 0;
                    bool flag4 = this.line >= textBuffer.FLOg.Count;
                    if (!flag4)
                    {
                        continue;
                    }
                    this.line = textBuffer.FLOg.Count;
                    this.index = 0;
                    flag3 = false;
                }
                return flag3;
            }
            while (offset < 0)
            {
                bool flag5 = this.index + offset >= 0;
                if (flag5)
                {
                    this.index += offset;
                    return true;
                }
                offset += this.index;
                this.line--;
                bool flag6 = this.line < 0;
                if (flag6)
                {
                    this.line = 0;
                    this.index = 0;
                    return false;
                }
                this.index = textBuffer.FLOg[this.line].Length;
            }
            return true;
        }

        // Token: 0x06000220 RID: 544 RVA: 0x0001DD3C File Offset: 0x0001BF3C
        public override string ToString()
        {
            return string.Concat(new string[]
            {
                "TextPosition (line: ",
                this.line.ToString(),
                ", index: ",
                this.index.ToString(),
                ")"
            });
        }

        // Token: 0x04000253 RID: 595
        public static TextPosition invalid = new TextPosition(-1, -1);

        // Token: 0x04000254 RID: 596
        public int line;

        // Token: 0x04000255 RID: 597
        public int index;
    }
}
