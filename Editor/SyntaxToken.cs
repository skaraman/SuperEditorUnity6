using System;
using AHO;
using UnityEngine;

namespace SuperEditor
{
    // Token: 0x0200004E RID: 78
    public class SyntaxToken
    {
        // Token: 0x17000015 RID: 21
        // (get) Token: 0x0600022E RID: 558 RVA: 0x0001E1A4 File Offset: 0x0001C3A4
        public int Line
        {
            get
            {
                return (this.AIGN == null) ? 0 : this.AIGN.JIKB;
            }
        }

        // Token: 0x17000016 RID: 22
        // (get) Token: 0x0600022F RID: 559 RVA: 0x0001E1CC File Offset: 0x0001C3CC
        public int TokenIndex
        {
            get
            {
                return this.AIGN.EOIA.IndexOf(this);
            }
        }

        // Token: 0x06000230 RID: 560 RVA: 0x0001E1EF File Offset: 0x0001C3EF
        public SyntaxToken(SyntaxToken.Kind kind, string text)
        {
            this.tokenKind = kind;
            this.text = text;
            this.tokenId = -1;
        }

        // Token: 0x06000231 RID: 561 RVA: 0x0001E210 File Offset: 0x0001C410
        public bool IsMissing()
        {
            return this.tokenKind == SyntaxToken.Kind.Missing;
        }

        // Token: 0x06000232 RID: 562 RVA: 0x0001E22C File Offset: 0x0001C42C
        public override string ToString()
        {
            return this.tokenKind.ToString() + "(\"" + this.text + "\")";
        }

        // Token: 0x06000233 RID: 563 RVA: 0x0001E264 File Offset: 0x0001C464
        public string Dump()
        {
            return string.Concat(new string[]
            {
                "[Token: ",
                this.tokenKind.ToString(),
                " \"",
                this.text,
                "\"]"
            });
        }

        // Token: 0x0400025C RID: 604
        public static readonly SyntaxToken Missing = new SyntaxToken(SyntaxToken.Kind.Missing, string.Empty);

        // Token: 0x0400025D RID: 605
        public SyntaxToken.Kind tokenKind;

        // Token: 0x0400025E RID: 606
        public GUIStyle style;

        // Token: 0x0400025F RID: 607
        internal _bb4.DHBA OOME;

        // Token: 0x04000260 RID: 608
        public string text;

        // Token: 0x04000261 RID: 609
        public int tokenId;

        // Token: 0x04000262 RID: 610
        internal GCE.PHFG AIGN;

        // Token: 0x0200004F RID: 79
        public enum Kind
        {
            // Token: 0x04000264 RID: 612
            Missing,
            // Token: 0x04000265 RID: 613
            Whitespace,
            // Token: 0x04000266 RID: 614
            Comment,
            // Token: 0x04000267 RID: 615
            Preprocessor,
            // Token: 0x04000268 RID: 616
            PreprocessorArguments,
            // Token: 0x04000269 RID: 617
            PreprocessorSymbol,
            // Token: 0x0400026A RID: 618
            PreprocessorDirectiveExpected,
            // Token: 0x0400026B RID: 619
            PreprocessorCommentExpected,
            // Token: 0x0400026C RID: 620
            PreprocessorUnexpectedDirective,
            // Token: 0x0400026D RID: 621
            VerbatimStringLiteral,
            // Token: 0x0400026E RID: 622
            LastWSToken,
            // Token: 0x0400026F RID: 623
            VerbatimStringBegin,
            // Token: 0x04000270 RID: 624
            BuiltInLiteral,
            // Token: 0x04000271 RID: 625
            CharLiteral,
            // Token: 0x04000272 RID: 626
            StringLiteral,
            // Token: 0x04000273 RID: 627
            InterpolatedStringWholeLiteral,
            // Token: 0x04000274 RID: 628
            InterpolatedStringStartLiteral,
            // Token: 0x04000275 RID: 629
            InterpolatedStringMidLiteral,
            // Token: 0x04000276 RID: 630
            InterpolatedStringEndLiteral,
            // Token: 0x04000277 RID: 631
            InterpolatedStringFormatLiteral,
            // Token: 0x04000278 RID: 632
            IntegerLiteral,
            // Token: 0x04000279 RID: 633
            RealLiteral,
            // Token: 0x0400027A RID: 634
            Punctuator,
            // Token: 0x0400027B RID: 635
            Keyword,
            // Token: 0x0400027C RID: 636
            Identifier,
            // Token: 0x0400027D RID: 637
            ContextualKeyword,
            // Token: 0x0400027E RID: 638
            EOF
        }
    }
}
