using System;
using AHO;
using SuperEditor.Themes;
using UnityEditor;
using UnityEngine;

namespace _yj2
{
    // Token: 0x02000163 RID: 355
    [InitializeOnLoad]
    internal class _d2
    {
        // Token: 0x060009ED RID: 2541 RVA: 0x00109804 File Offset: 0x00107A04
        static _d2()
        {
            _bi2.AddTheme(_d2._CLS, _d2._yl6);
            _bi2._CBY++;
        }

        // Token: 0x040008E2 RID: 2274
        private static string _yl6 = "Tango Dark (Oblivion)";

        // Token: 0x040008E3 RID: 2275
        internal static Theme _CLS = new Theme
        {
            background = _bg1._AYK,
            text = _bg1._AYG,
            hyperlinks = _bg1._AXK,
            keywords = _bg1._AXZ,
            constants = _bg1._AXK,
            strings = _bg1._AXK,
            builtInLiterals = _bg1._AXP,
            operators = _bg1._AYG,
            referenceTypes = _bg1._AXT,
            valueTypes = _bg1._AXT,
            interfaceTypes = _bg1._AXT,
            enumTypes = _bg1._AXT,
            delegateTypes = _bg1._AXT,
            builtInTypes = _bg1._AXZ,
            namespaces = _bg1._AYG,
            methods = _bg1._AYG,
            fields = _bg1._AYG,
            properties = _bg1._AYG,
            events = _bg1._AYG,
            parameters = _bg1._AYG,
            variables = _bg1._AYG,
            typeParameters = _bg1._AXT,
            enumMembers = _bg1._AYG,
            preprocessor = _bg1._AXW,
            defineSymbols = _bg1._AXW,
            inactiveCode = _bg1._AYI,
            comments = _bg1._AYI,
            xmlDocs = _bg1._AYI,
            xmlDocsTags = _bg1._AYI,
            lineNumbers = _bg1._AYJ,
            lineNumbersHighlight = _bg1._AYH,
            lineNumbersBackground = _bg1._AYL,
            fold = _bg1._AYH,
            activeSelection = _bg1._AYJ,
            passiveSelection = _bg1._AYJ,
            searchResults = new Color32(0, 96, 96, byte.MaxValue),
            trackSaved = new Color32(108, 226, 108, byte.MaxValue),
            trackChanged = new Color32(byte.MaxValue, 238, 98, byte.MaxValue),
            trackReverted = new Color32(246, 201, 60, byte.MaxValue),
            currentLine = _bg1._AYL,
            currentLineInactive = new Color32(17, 17, 17, 128),
            referenceHighlight = new Color32(48, 65, 87, byte.MaxValue),
            referenceModifyHighlight = new Color32(105, 48, 49, 192),
            tooltipBackground = (Color)_bg1._AYL * 0.5f + (Color)_bg1._AYK * 0.5f,
            tooltipFrame = _bg1._AYI,
            tooltipText = _bg1._AYG,
            listPopupBackground = (Color)_bg1._AYL * 0.5f + (Color)_bg1._AYK * 0.5f,
            preprocessorStyle = (FontStyle)2
        };
    }
}
