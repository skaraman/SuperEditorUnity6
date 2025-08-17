using System;
using AHO;
using SuperEditor.Themes;
using UnityEditor;
using UnityEngine;

namespace _yj2
{
    // Token: 0x02000154 RID: 340
    [InitializeOnLoad]
    internal class _da5
    {
        // Token: 0x060009CF RID: 2511 RVA: 0x001046D8 File Offset: 0x001028D8
        static _da5()
        {
            _bi2.AddTheme(_da5._CLS, _da5._yl6);
            _bi2._CBY++;
        }

        // Token: 0x04000863 RID: 2147
        private static string _yl6 = "VS Light with VA X";

        // Token: 0x04000864 RID: 2148
        internal static Theme _CLS = new Theme
        {
            background = Color.white,
            text = Color.black,
            hyperlinks = Color.blue,
            keywords = Color.blue,
            constants = Color.black,
            strings = new Color32(128, 0, 0, byte.MaxValue),
            builtInLiterals = Color.blue,
            operators = Color.black,
            referenceTypes = new Color32(43, 145, 175, byte.MaxValue),
            valueTypes = new Color32(43, 145, 175, byte.MaxValue),
            interfaceTypes = new Color32(43, 145, 175, byte.MaxValue),
            enumTypes = new Color32(43, 145, 175, byte.MaxValue),
            delegateTypes = new Color32(43, 145, 175, byte.MaxValue),
            builtInTypes = Color.blue,
            namespaces = new Color32(33, 111, 133, byte.MaxValue),
            methods = new Color32(136, 0, 0, byte.MaxValue),
            fields = new Color32(0, 0, 128, byte.MaxValue),
            properties = new Color32(0, 0, 128, byte.MaxValue),
            events = new Color32(0, 0, 128, byte.MaxValue),
            parameters = new Color32(0, 0, 128, byte.MaxValue),
            variables = new Color32(0, 0, 128, byte.MaxValue),
            typeParameters = new Color32(33, 111, 133, byte.MaxValue),
            enumMembers = new Color32(111, 0, 138, byte.MaxValue),
            preprocessor = Color.blue,
            defineSymbols = new Color32(111, 0, 138, byte.MaxValue),
            inactiveCode = Color.gray,
            comments = new Color32(0, 128, 0, byte.MaxValue),
            xmlDocs = new Color32(128, 128, 128, byte.MaxValue),
            xmlDocsTags = new Color32(128, 128, 128, byte.MaxValue),
            lineNumbers = new Color32(43, 145, 175, byte.MaxValue),
            lineNumbersHighlight = Color.blue,
            lineNumbersBackground = Color.white,
            fold = new Color32(165, 165, 165, byte.MaxValue),
            activeSelection = new Color32(51, 153, byte.MaxValue, 102),
            passiveSelection = new Color32(191, 205, 219, 102),
            searchResults = new Color32(byte.MaxValue, byte.MaxValue, 183, byte.MaxValue),
            trackSaved = new Color32(108, 226, 108, byte.MaxValue),
            trackChanged = new Color32(byte.MaxValue, 238, 98, byte.MaxValue),
            trackReverted = new Color32(246, 201, 60, byte.MaxValue),
            currentLine = new Color32(213, 213, 241, byte.MaxValue),
            currentLineInactive = new Color32(228, 228, 228, byte.MaxValue),
            referenceHighlight = new Color32(224, byte.MaxValue, byte.MaxValue, byte.MaxValue),
            referenceModifyHighlight = new Color32(byte.MaxValue, 221, 221, byte.MaxValue),
            tooltipBackground = new Color32(253, byte.MaxValue, 153, byte.MaxValue),
            tooltipFrame = new Color32(128, 128, 128, byte.MaxValue),
            tooltipText = new Color32(22, 22, 22, byte.MaxValue),
            listPopupBackground = Color.white
        };
    }
}
