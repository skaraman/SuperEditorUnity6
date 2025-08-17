using System;
using AHO;
using SuperEditor.Themes;
using UnityEditor;
using UnityEngine;

namespace _yj2
{
    // Token: 0x0200015B RID: 347
    [InitializeOnLoad]
    internal class MOIA
    {
        // Token: 0x060009DE RID: 2526 RVA: 0x00106F64 File Offset: 0x00105164
        static MOIA()
        {
            _bi2.AddTheme(MOIA._CLS, MOIA._yl6);
            _bi2._CBY++;
        }

        // Token: 0x040008B4 RID: 2228
        private static string _yl6 = "Xcode";

        // Token: 0x040008B5 RID: 2229
        internal static Theme _CLS = new Theme
        {
            background = MOIA._ym1._ym2,
            text = MOIA._ym1._ym3,
            hyperlinks = MOIA._ym1._ym4,
            keywords = MOIA._ym1._ym5,
            constants = MOIA._ym1._ym6,
            strings = MOIA._ym1._ym7,
            builtInLiterals = MOIA._ym1._ym5,
            operators = Color.black,
            referenceTypes = MOIA._ym1._ym8,
            valueTypes = MOIA._ym1._ym9,
            interfaceTypes = MOIA._ym1._ym9,
            enumTypes = MOIA._ym1._ym9,
            delegateTypes = MOIA._ym1._ym9,
            builtInTypes = MOIA._ym1._ym5,
            namespaces = MOIA._ym1._ym5,
            methods = MOIA._ym1._yn1,
            fields = Color.black,
            properties = MOIA._ym1._yn2,
            events = MOIA._ym1._yn1,
            parameters = Color.black,
            variables = Color.black,
            typeParameters = new Color32(128, 70, 176, byte.MaxValue),
            enumMembers = MOIA._ym1._yn3,
            preprocessor = MOIA._ym1._yn4,
            defineSymbols = MOIA._ym1._yn4,
            inactiveCode = _bg1._AYI,
            comments = MOIA._ym1._yn5,
            xmlDocs = new Color32(35, 151, 45, byte.MaxValue),
            xmlDocsTags = new Color32(35, 151, 45, byte.MaxValue),
            lineNumbers = MOIA._ym1._yn6,
            lineNumbersHighlight = MOIA._ym1._yn6,
            lineNumbersBackground = MOIA._ym1._yn7,
            fold = MOIA._ym1._yn8,
            activeSelection = new Color32(164, 205, byte.MaxValue, byte.MaxValue),
            passiveSelection = new Color32(212, 212, 212, 127),
            searchResults = new Color32(250, 241, 190, byte.MaxValue),
            trackSaved = new Color32(108, 226, 108, byte.MaxValue),
            trackChanged = new Color32(byte.MaxValue, 238, 98, byte.MaxValue),
            trackReverted = new Color32(246, 201, 60, byte.MaxValue),
            currentLine = new Color32(213, 213, 241, byte.MaxValue),
            currentLineInactive = new Color32(228, 228, 228, byte.MaxValue),
            referenceHighlight = new Color32(224, byte.MaxValue, byte.MaxValue, byte.MaxValue),
            referenceModifyHighlight = new Color32(byte.MaxValue, 221, 221, byte.MaxValue),
            tooltipBackground = new Color32(byte.MaxValue, 254, 205, byte.MaxValue),
            tooltipFrame = new Color32(210, 210, 210, byte.MaxValue),
            tooltipText = new Color32(20, 15, 0, byte.MaxValue),
            listPopupBackground = MOIA._ym1._ym2
        };

        // Token: 0x0200015C RID: 348
        private static class _ym1
        {
            // Token: 0x040008B6 RID: 2230
            internal static Color32 _ym3 = new Color32(0, 0, 0, byte.MaxValue);

            // Token: 0x040008B7 RID: 2231
            internal static Color32 _yn5 = new Color32(0, 116, 0, byte.MaxValue);

            // Token: 0x040008B8 RID: 2232
            internal static Color32 _yn9 = new Color32(0, 116, 0, byte.MaxValue);

            // Token: 0x040008B9 RID: 2233
            internal static Color32 _yo1 = new Color32(2, 61, 16, byte.MaxValue);

            // Token: 0x040008BA RID: 2234
            internal static Color32 _ym7 = new Color32(196, 26, 22, byte.MaxValue);

            // Token: 0x040008BB RID: 2235
            internal static Color32 _yo2 = new Color32(28, 0, 207, byte.MaxValue);

            // Token: 0x040008BC RID: 2236
            internal static Color32 _ym6 = new Color32(28, 0, 207, byte.MaxValue);

            // Token: 0x040008BD RID: 2237
            internal static Color32 _ym5 = new Color32(170, 13, 145, byte.MaxValue);

            // Token: 0x040008BE RID: 2238
            internal static Color32 _yo3 = new Color32(100, 56, 32, byte.MaxValue);

            // Token: 0x040008BF RID: 2239
            internal static Color32 _ym4 = new Color32(14, 14, byte.MaxValue, byte.MaxValue);

            // Token: 0x040008C0 RID: 2240
            internal static Color32 _yo4 = new Color32(131, 108, 40, byte.MaxValue);

            // Token: 0x040008C1 RID: 2241
            internal static Color32 _yo5 = new Color32(63, 110, 116, byte.MaxValue);

            // Token: 0x040008C2 RID: 2242
            internal static Color32 _yn1 = new Color32(38, 71, 75, byte.MaxValue);

            // Token: 0x040008C3 RID: 2243
            internal static Color32 _yo6 = new Color32(38, 71, 75, byte.MaxValue);

            // Token: 0x040008C4 RID: 2244
            internal static Color32 _ym8 = new Color32(63, 110, 116, byte.MaxValue);

            // Token: 0x040008C5 RID: 2245
            internal static Color32 _yo7 = new Color32(63, 110, 116, byte.MaxValue);

            // Token: 0x040008C6 RID: 2246
            internal static Color32 _yn4 = new Color32(100, 56, 32, byte.MaxValue);

            // Token: 0x040008C7 RID: 2247
            internal static Color32 _yo8 = new Color32(92, 38, 153, byte.MaxValue);

            // Token: 0x040008C8 RID: 2248
            internal static Color32 _yo9 = new Color32(46, 13, 110, byte.MaxValue);

            // Token: 0x040008C9 RID: 2249
            internal static Color32 _yn3 = new Color32(46, 13, 110, byte.MaxValue);

            // Token: 0x040008CA RID: 2250
            internal static Color32 _ym9 = new Color32(92, 38, 153, byte.MaxValue);

            // Token: 0x040008CB RID: 2251
            internal static Color32 _yn2 = new Color32(92, 38, 153, byte.MaxValue);

            // Token: 0x040008CC RID: 2252
            internal static Color32 _yp1 = new Color32(100, 56, 32, byte.MaxValue);

            // Token: 0x040008CD RID: 2253
            internal static Color32 _ym2 = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

            // Token: 0x040008CE RID: 2254
            internal static Color32 _yp2 = new Color32(167, 202, byte.MaxValue, byte.MaxValue);

            // Token: 0x040008CF RID: 2255
            internal static Color32 _yp3 = new Color32(0, 0, 0, byte.MaxValue);

            // Token: 0x040008D0 RID: 2256
            internal static Color32 _yp4 = new Color32(127, 127, 127, byte.MaxValue);

            // Token: 0x040008D1 RID: 2257
            internal static Color32 _yp5 = new Color32(212, 212, 212, byte.MaxValue);

            // Token: 0x040008D2 RID: 2258
            internal static Color32 _yn7 = new Color32(247, 247, 247, byte.MaxValue);

            // Token: 0x040008D3 RID: 2259
            internal static Color32 _yn6 = new Color32(146, 146, 146, byte.MaxValue);

            // Token: 0x040008D4 RID: 2260
            internal static Color32 _yn8 = new Color32(231, 231, 231, byte.MaxValue);

            // Token: 0x040008D5 RID: 2261
            internal static Color32 _CHN = new Color32(250, 241, 190, byte.MaxValue);
        }
    }
}
