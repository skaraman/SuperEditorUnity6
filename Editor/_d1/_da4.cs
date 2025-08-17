using System;
using AHO;
using SuperEditor.Themes;
using UnityEditor;
using UnityEngine;

namespace _yj2
{
    // Token: 0x02000162 RID: 354
    [InitializeOnLoad]
    internal class _da4
    {
        // Token: 0x060009EB RID: 2539 RVA: 0x00109470 File Offset: 0x00107670
        static _da4()
        {
            _bi2.AddTheme(_da4._CLS, _da4._yl6);
            _bi2._CBY++;
        }

        // Token: 0x040008E0 RID: 2272
        private static string _yl6 = "Tango Light";

        // Token: 0x040008E1 RID: 2273
        internal static Theme _CLS = new Theme
        {
            background = Color.white,
            text = _bg1._AYL,
            hyperlinks = Color.blue,
            keywords = _bg1._AXY,
            constants = _bg1._AXY,
            strings = _bg1._AYA,
            builtInLiterals = _bg1._AXZ,
            operators = _bg1._AYL,
            referenceTypes = _bg1._AXX,
            valueTypes = _bg1._AXV,
            interfaceTypes = _bg1._AXV,
            enumTypes = _bg1._AXV,
            delegateTypes = _bg1._AXX,
            builtInTypes = Color.clear,
            namespaces = _bg1._AYL,
            methods = _bg1._AYB,
            fields = _bg1._AYB,
            properties = _bg1._AYB,
            events = _bg1._AYB,
            parameters = _bg1._AYL,
            variables = _bg1._AYL,
            typeParameters = _bg1._AXV,
            enumMembers = _bg1._AYL,
            preprocessor = _bg1._AXP,
            defineSymbols = _bg1._AXO,
            inactiveCode = _bg1._AYH,
            comments = _bg1._AXV,
            xmlDocs = _bg1._AXV,
            xmlDocsTags = _bg1._AXV,
            lineNumbers = _bg1._AYI,
            lineNumbersHighlight = _bg1._AYJ,
            lineNumbersBackground = Color.white,
            fold = _bg1._AYH,
            tooltipBackground = new Color32(253, byte.MaxValue, 153, byte.MaxValue),
            tooltipFrame = new Color32(128, 128, 128, byte.MaxValue),
            tooltipText = new Color32(22, 22, 22, byte.MaxValue),
            listPopupBackground = Color.white,
            activeSelection = new Color32(51, 153, byte.MaxValue, 102),
            passiveSelection = new Color32(191, 205, 219, 102),
            searchResults = new Color32(byte.MaxValue, 226, 185, byte.MaxValue),
            trackSaved = new Color32(108, 226, 108, byte.MaxValue),
            trackChanged = new Color32(byte.MaxValue, 238, 98, byte.MaxValue),
            trackReverted = new Color32(246, 201, 60, byte.MaxValue),
            currentLine = _bg1._AYF,
            currentLineInactive = _bg1._AYF,
            preprocessorStyle = (FontStyle)2
        };
    }
}
