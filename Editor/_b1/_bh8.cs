using System;
using System.Collections.Generic;
using System.Linq;
using SuperEditor;

namespace AHO
{
    // Token: 0x02000035 RID: 53
    internal class _bh8 : _bb8
    {
        // Token: 0x06000189 RID: 393 RVA: 0x00015247 File Offset: 0x00013447
        public IEnumerable<_be5> EnumSnippets(_bh4 context, _bh2._AGI expectedTokens, SyntaxToken tokenLeft, _bm6 scope)
        {
            _bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF.FHBOENLOIAPMMKLMFHJIPKBIJNCIHHJMAKOA = scope;
            bool flag = tokenLeft == null || tokenLeft.OOME == null || tokenLeft.OOME.OOME == null;
            if (flag)
            {
                yield break;
            }
            bool flag2 = tokenLeft.tokenKind != SyntaxToken.Kind.Keyword;
            if (flag2)
            {
                yield break;
            }
            bool flag3 = tokenLeft.text != "override";
            if (flag3)
            {
                yield break;
            }
            _bj8 bodyScope = scope as _bj8;
            bool flag4 = bodyScope == null;
            if (flag4)
            {
                yield break;
            }
            _b2 contextType = bodyScope._ACV as _b2;
            bool flag5 = contextType == null || (contextType._AT != SymbolKind.Class && contextType._AT != SymbolKind.Struct);
            if (flag5)
            {
                yield break;
            }
            _b2 baseType = contextType.BaseType();
            bool flag6 = baseType == null || (baseType._AT != SymbolKind.Class && baseType._AT != SymbolKind.Struct);
            if (flag6)
            {
                yield break;
            }
            List<_bb3> overrideMethodCandidates = new List<_bb3>();
            baseType.ListOverrideCandidates(overrideMethodCandidates, contextType.Assembly);
            bool flag7 = overrideMethodCandidates.Count == 0;
            if (flag7)
            {
                yield break;
            }
            GCE textBuffer = GCE._ALU._ABK();
            SyntaxToken firstToken = tokenLeft.OOME.OOME.GetFirstLeaf()._ACX;
            bool flag8 = firstToken.AIGN != tokenLeft.AIGN;
            if (flag8)
            {
                firstToken = tokenLeft.AIGN.EOIA[0];
                while (firstToken.tokenKind <= SyntaxToken.Kind.LastWSToken)
                {
                    firstToken = firstToken.AIGN.EOIA[firstToken.TokenIndex + 1];
                }
            }
            TextSpan tokenSpan = textBuffer.GetTokenSpan(firstToken.OOME);
            _bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF.HNAKHGBHHJJOKIFJMIEPACFDHHPEGPCMAPAI = GCE._ALU._ABH._AEU - tokenSpan.StartPosition.index;
            foreach (_bb3 method in overrideMethodCandidates)
            {
                _ba7 methodGroup = contextType.FindName(method._AW, -1, false) as _ba7;
                bool flag9 = methodGroup != null;
                if (flag9)
                {
                    bool skipThis = false;
                    string signature = method.PrintParameters(method.GetParameters(), true);
                    foreach (_bb3 i in methodGroup._AAM)
                    {
                        bool flag10 = method._AHG() == i._AHG() && signature == i.PrintParameters(i.GetParameters(), false);
                        if (flag10)
                        {
                            skipThis = true;
                            break;
                        }
                    }
                    List<_bb3>.Enumerator enumerator2 = default(List<_bb3>.Enumerator);
                    bool flag11 = skipThis;
                    if (flag11)
                    {
                        continue;
                    }
                    signature = null;
                }
                _bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF overrideCompletion = new _bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF(method);
                yield return overrideCompletion;
                methodGroup = null;
                overrideCompletion = null;
            }
            List<_bb3>.Enumerator enumerator = default(List<_bb3>.Enumerator);
            yield break;
            yield break;
        }

        // Token: 0x0600018A RID: 394 RVA: 0x00015274 File Offset: 0x00013474
        public string Get(string shortcut, _bh4 context, _bh2._AGI expectedTokens, _bm6 scope)
        {
            return null;
        }

        // Token: 0x02000036 RID: 54
        private class GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF : _be5
        {
            // Token: 0x0600018C RID: 396 RVA: 0x00015287 File Offset: 0x00013487
            public GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF(_bb3 virtualMethod)
                : base(virtualMethod._AW)
            {
                this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM = virtualMethod;
                this._AWF = _bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF.GetDisplayName(virtualMethod);
            }

            // Token: 0x0600018D RID: 397 RVA: 0x000152AC File Offset: 0x000134AC
            private static string GetDisplayName(_bb3 method)
            {
                string text = method.PrintParameters(method.GetParameters(), true);
                string text2;
                if (method._AHG() != 0)
                {
                    text2 = "<" + string.Join(", ", method._AHL.Select((_bd7 t) => t._AW).ToArray<string>()) + ">";
                }
                else
                {
                    text2 = "";
                }
                string text3 = text2;
                return string.Concat(new string[] { "{0}", text3, "(", text, ") {{...}}" });
            }

            // Token: 0x0600018E RID: 398 RVA: 0x00015350 File Offset: 0x00013550
            public override string Expand()
            {
                string text = (this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AFI() ? (this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AFJ() ? "internal protected" : "internal") : (this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AFJ() ? "protected" : "public"));
                string text2 = this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM.ReturnType().RelativeName(_bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF.FHBOENLOIAPMMKLMFHJIPKBIJNCIHHJMAKOA);
                string text3;
                if (this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AHG() != 0)
                {
                    text3 = "<" + string.Join(", ", this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AHL.Select((_bd7 t) => t._AW).ToArray<string>()) + ">";
                }
                else
                {
                    text3 = "";
                }
                string text4 = text3;
                List<_bm1> parameters = this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM.GetParameters();
                string text5 = this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM.PrintParameters(parameters, true);
                string text6 = "";
                string text7 = "";
                for (int i = 0; i < parameters.Count; i++)
                {
                    _bm1 _AGS = parameters[i];
                    text7 += text6;
                    bool flag = _AGS._AGL();
                    if (flag)
                    {
                        text7 += "ref ";
                    }
                    else
                    {
                        bool flag2 = _AGS._AGK();
                        if (flag2)
                        {
                            text7 += "out ";
                        }
                    }
                    text7 += _AGS._AW;
                    text6 = ", ";
                }
                string text8 = (this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AAP() ? ("throw new " + _bl9.ForType(typeof(NotImplementedException)).definition.RelativeName(_bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF.FHBOENLOIAPMMKLMFHJIPKBIJNCIHHJMAKOA) + "();") : string.Concat(new string[]
                {
                    "base.",
                    this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AW,
                    text4,
                    "(",
                    text7,
                    ");"
                }));
                string text9 = ((text2 == "void" || this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AAP()) ? "" : "return ");
                return string.Format("{0} override {1} {2}{3}({4}){5}{{\n\t{6}{7}$end$\n}}", new object[]
                {
                    text,
                    text2,
                    this.ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM._AW,
                    text4,
                    text5,
                    _bg8._BBC ? " " : "\n",
                    text9,
                    text8
                });
            }

            // Token: 0x0600018F RID: 399 RVA: 0x000155C0 File Offset: 0x000137C0
            public override void OverrideTypedInLength(ref int typedInLength)
            {
                typedInLength += _bh8.GPHLIBIHMEIBAPENHDNDLDFEGJOHLANCOBHF.HNAKHGBHHJJOKIFJMIEPACFDHHPEGPCMAPAI;
            }

            // Token: 0x040001B0 RID: 432
            internal static _bm6 FHBOENLOIAPMMKLMFHJIPKBIJNCIHHJMAKOA;

            // Token: 0x040001B1 RID: 433
            internal static int HNAKHGBHHJJOKIFJMIEPACFDHHPEGPCMAPAI;

            // Token: 0x040001B2 RID: 434
            private readonly _bb3 ELGDCKDDEHAJBIKCBNDPCEFLODKKBOLOJOAM;
        }
    }
}
