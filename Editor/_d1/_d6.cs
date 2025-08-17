using System;
using AHO;
using SuperEditor.Themes;
using UnityEditor;
using UnityEngine;

namespace _yj2
{
    // Token: 0x02000158 RID: 344
    [InitializeOnLoad]
    internal class _yl9
    {
        // Token: 0x060009D7 RID: 2519 RVA: 0x00105C78 File Offset: 0x00103E78
        static _yl9()
        {
            _bi2.AddTheme(_yl9._CLS, _yl9._yl6);
            _bi2._CBY++;
        }

        // Token: 0x0400086B RID: 2155
        private static string _yl6 = "Visual Studio Dark";

        // Token: 0x0400086C RID: 2156
        internal static Theme _CLS = new Theme
        {
            background = new Color32(30, 30, 30, byte.MaxValue),
            text = new Color32(218, 218, 218, byte.MaxValue),
            hyperlinks = new Color32(86, 156, 214, byte.MaxValue),
            keywords = new Color32(86, 156, 214, byte.MaxValue),
            constants = new Color32(181, 206, 168, byte.MaxValue),
            strings = new Color32(214, 157, 133, byte.MaxValue),
            builtInLiterals = new Color32(86, 156, 214, byte.MaxValue),
            operators = new Color32(180, 180, 180, byte.MaxValue),
            referenceTypes = new Color32(78, 201, 176, byte.MaxValue),
            valueTypes = new Color32(78, 201, 176, byte.MaxValue),
            interfaceTypes = new Color32(184, 215, 163, byte.MaxValue),
            enumTypes = new Color32(184, 215, 163, byte.MaxValue),
            delegateTypes = new Color32(78, 201, 176, byte.MaxValue),
            builtInTypes = new Color32(86, 156, 214, byte.MaxValue),
            namespaces = new Color32(200, 200, 200, byte.MaxValue),
            methods = new Color32(200, 200, 200, byte.MaxValue),
            fields = new Color32(218, 218, 218, byte.MaxValue),
            properties = new Color32(200, 200, 200, byte.MaxValue),
            events = new Color32(200, 200, 200, byte.MaxValue),
            parameters = new Color32(127, 127, 127, byte.MaxValue),
            variables = new Color32(200, 200, 200, byte.MaxValue),
            typeParameters = new Color32(184, 215, 163, byte.MaxValue),
            enumMembers = new Color32(189, 99, 197, byte.MaxValue),
            preprocessor = new Color32(155, 155, 155, byte.MaxValue),
            defineSymbols = new Color32(189, 99, 197, byte.MaxValue),
            inactiveCode = new Color32(155, 155, 155, byte.MaxValue),
            comments = new Color32(87, 166, 74, byte.MaxValue),
            xmlDocs = new Color32(87, 166, 74, byte.MaxValue),
            xmlDocsTags = new Color32(87, 166, 74, byte.MaxValue),
            lineNumbers = new Color32(43, 145, 175, byte.MaxValue),
            lineNumbersHighlight = new Color32(173, 216, 230, byte.MaxValue),
            lineNumbersBackground = new Color32(30, 30, 30, byte.MaxValue),
            fold = new Color32(165, 165, 165, byte.MaxValue),
            activeSelection = new Color32(51, 153, byte.MaxValue, 102),
            passiveSelection = new Color32(86, 86, 86, 102),
            searchResults = new Color32(119, 56, 0, byte.MaxValue),
            trackSaved = new Color32(87, 116, 48, byte.MaxValue),
            trackChanged = new Color32(239, 242, 132, byte.MaxValue),
            trackReverted = new Color32(95, 149, 250, byte.MaxValue),
            currentLine = new Color32(0, 0, 0, byte.MaxValue),
            currentLineInactive = new Color32(42, 42, 42, byte.MaxValue),
            referenceHighlight = new Color32(14, 69, 131, 162),
            referenceModifyHighlight = new Color32(131, 14, 69, 162),
            tooltipBackground = new Color32(66, 66, 69, byte.MaxValue),
            tooltipText = new Color32(241, 241, 241, byte.MaxValue),
            tooltipFrame = new Color32(102, 102, 102, byte.MaxValue),
            listPopupBackground = new Color32(37, 37, 38, byte.MaxValue)
        };
    }
}
