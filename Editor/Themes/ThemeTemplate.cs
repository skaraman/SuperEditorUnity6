using System;
using UnityEditor;
using UnityEngine;

namespace SuperEditor.Themes
{
    // Token: 0x02000164 RID: 356
    [InitializeOnLoad]
    public class ThemeTemplate : ScriptableObject
    {
        // Token: 0x060009EF RID: 2543 RVA: 0x00109BDA File Offset: 0x00107DDA
        public void OnValidate()
        {
            this.changed = true;
        }

        // Token: 0x040008E4 RID: 2276
        [HideInInspector]
        public bool changed;

        // Token: 0x040008E5 RID: 2277
        public Theme colorTheme = new Theme
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
            namespaces = Color.black,
            methods = Color.black,
            fields = Color.black,
            properties = Color.black,
            events = Color.black,
            parameters = Color.gray,
            variables = Color.black,
            typeParameters = new Color32(43, 145, 175, byte.MaxValue),
            enumMembers = new Color32(111, 0, 138, byte.MaxValue),
            preprocessor = Color.blue,
            defineSymbols = new Color32(111, 0, 138, byte.MaxValue),
            inactiveCode = Color.gray,
            comments = new Color32(0, 128, 0, byte.MaxValue),
            xmlDocs = new Color32(0, 128, 0, byte.MaxValue),
            xmlDocsTags = new Color32(128, 128, 128, byte.MaxValue),
            lineNumbers = new Color32(43, 145, 175, byte.MaxValue),
            lineNumbersHighlight = Color.blue,
            lineNumbersBackground = Color.white,
            fold = new Color32(165, 165, 165, byte.MaxValue),
            activeSelection = new Color32(51, 153, byte.MaxValue, 102),
            passiveSelection = new Color32(191, 205, 219, 102),
            searchResults = new Color32(244, 167, 33, byte.MaxValue),
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

        // Token: 0x040008E6 RID: 2278
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
            namespaces = Color.black,
            methods = Color.black,
            fields = Color.black,
            properties = Color.black,
            events = Color.black,
            parameters = Color.gray,
            variables = Color.black,
            typeParameters = new Color32(43, 145, 175, byte.MaxValue),
            enumMembers = new Color32(111, 0, 138, byte.MaxValue),
            preprocessor = Color.blue,
            defineSymbols = new Color32(111, 0, 138, byte.MaxValue),
            inactiveCode = Color.gray,
            comments = new Color32(0, 128, 0, byte.MaxValue),
            xmlDocs = new Color32(0, 128, 0, byte.MaxValue),
            xmlDocsTags = new Color32(128, 128, 128, byte.MaxValue),
            lineNumbers = new Color32(43, 145, 175, byte.MaxValue),
            lineNumbersHighlight = Color.blue,
            lineNumbersBackground = Color.white,
            fold = new Color32(165, 165, 165, byte.MaxValue),
            activeSelection = new Color32(51, 153, byte.MaxValue, 102),
            passiveSelection = new Color32(191, 205, 219, 102),
            searchResults = new Color32(244, 167, 33, byte.MaxValue),
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
