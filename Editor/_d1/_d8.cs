using System;
using AHO;
using SuperEditor.Themes;
using UnityEditor;
using UnityEngine;

namespace _yj2
{
    // Token: 0x02000160 RID: 352
    [InitializeOnLoad]
    internal class _d8
    {
        // Token: 0x060009E7 RID: 2535 RVA: 0x0010893C File Offset: 0x00106B3C
        static _d8()
        {
            _bi2.AddTheme(_d8._CLS, _d8._yl6);
            _bi2._CBY++;
        }

        // Token: 0x040008DC RID: 2268
        private static string _yl6 = "Solarized Dark";

        // Token: 0x040008DD RID: 2269
        internal static Theme _CLS = new Theme
        {
            background = new Color32(0, 43, 54, byte.MaxValue),
            text = new Color32(131, 148, 150, byte.MaxValue),
            hyperlinks = new Color32(38, 139, 210, byte.MaxValue),
            keywords = new Color32(113, 154, 7, byte.MaxValue),
            constants = new Color32(42, 161, 152, byte.MaxValue),
            strings = new Color32(42, 161, 152, byte.MaxValue),
            builtInLiterals = new Color32(113, 154, 7, byte.MaxValue),
            operators = new Color32(113, 154, 7, byte.MaxValue),
            referenceTypes = new Color32(181, 137, 0, byte.MaxValue),
            valueTypes = new Color32(181, 137, 0, byte.MaxValue),
            interfaceTypes = new Color32(181, 137, 0, byte.MaxValue),
            enumTypes = new Color32(181, 137, 0, byte.MaxValue),
            delegateTypes = new Color32(108, 113, 196, byte.MaxValue),
            builtInTypes = new Color32(113, 154, 7, byte.MaxValue),
            namespaces = new Color32(101, 123, 131, byte.MaxValue),
            methods = new Color32(147, 161, 161, byte.MaxValue),
            fields = new Color32(131, 148, 150, byte.MaxValue),
            properties = new Color32(131, 148, 150, byte.MaxValue),
            events = new Color32(108, 113, 196, byte.MaxValue),
            parameters = new Color32(131, 148, 150, byte.MaxValue),
            variables = new Color32(131, 148, 150, byte.MaxValue),
            typeParameters = new Color32(211, 54, 130, byte.MaxValue),
            enumMembers = new Color32(211, 54, 130, byte.MaxValue),
            preprocessor = new Color32(203, 75, 22, byte.MaxValue),
            defineSymbols = new Color32(211, 54, 130, byte.MaxValue),
            inactiveCode = new Color32(88, 110, 117, byte.MaxValue),
            comments = new Color32(88, 110, 117, byte.MaxValue),
            xmlDocs = new Color32(88, 110, 117, byte.MaxValue),
            xmlDocsTags = new Color32(88, 110, 117, byte.MaxValue),
            lineNumbers = new Color32(101, 123, 131, byte.MaxValue),
            lineNumbersHighlight = new Color32(131, 148, 150, byte.MaxValue),
            lineNumbersBackground = new Color32(7, 54, 66, byte.MaxValue),
            fold = new Color32(101, 123, 131, byte.MaxValue),
            activeSelection = new Color32(88, 110, 117, 102),
            passiveSelection = new Color32(88, 110, 117, 102),
            searchResults = new Color32(7, 54, 66, byte.MaxValue),
            trackSaved = new Color32(113, 154, 7, byte.MaxValue),
            trackChanged = new Color32(181, 137, 0, byte.MaxValue),
            trackReverted = new Color32(95, 149, 250, byte.MaxValue),
            currentLine = new Color32(7, 54, 66, byte.MaxValue),
            currentLineInactive = new Color32(7, 54, 66, byte.MaxValue),
            referenceHighlight = new Color32(0, 73, 62, 204),
            referenceModifyHighlight = new Color32(121, 34, 5, 144),
            tooltipBackground = new Color32(7, 54, 66, byte.MaxValue),
            tooltipText = new Color32(131, 148, 150, byte.MaxValue),
            tooltipFrame = new Color32(101, 123, 131, byte.MaxValue),
            listPopupBackground = new Color32(7, 54, 66, byte.MaxValue)
        };
    }
}
