using System;
using AHO;
using UnityEngine;

namespace SuperEditor.Themes
{
    // Token: 0x0200015A RID: 346
    [Serializable]
    public class Theme
    {
        // Token: 0x060009DC RID: 2524 RVA: 0x00106BA4 File Offset: 0x00104DA4
        public override string ToString()
        {
            int num = _bi2.BPDG.IndexOf(this);
            return (num < 0) ? "Unregistered theme" : _bi2.BGBI[num];
        }

        // Token: 0x04000871 RID: 2161
        public Color background = Color.gray;

        // Token: 0x04000872 RID: 2162
        public Color text = Color.red;

        // Token: 0x04000873 RID: 2163
        public Color hyperlinks = Color.red;

        // Token: 0x04000874 RID: 2164
        public Color keywords = Color.red;

        // Token: 0x04000875 RID: 2165
        public Color constants = Color.red;

        // Token: 0x04000876 RID: 2166
        public Color strings = Color.red;

        // Token: 0x04000877 RID: 2167
        public Color builtInLiterals = Color.red;

        // Token: 0x04000878 RID: 2168
        public Color operators = Color.red;

        // Token: 0x04000879 RID: 2169
        public Color punctuators = Color.clear;

        // Token: 0x0400087A RID: 2170
        public Color referenceTypes = Color.red;

        // Token: 0x0400087B RID: 2171
        public Color valueTypes = Color.red;

        // Token: 0x0400087C RID: 2172
        public Color interfaceTypes = Color.red;

        // Token: 0x0400087D RID: 2173
        public Color enumTypes = Color.red;

        // Token: 0x0400087E RID: 2174
        public Color delegateTypes = Color.red;

        // Token: 0x0400087F RID: 2175
        public Color builtInTypes = Color.red;

        // Token: 0x04000880 RID: 2176
        public Color namespaces = Color.red;

        // Token: 0x04000881 RID: 2177
        public Color methods = Color.red;

        // Token: 0x04000882 RID: 2178
        public Color fields = Color.red;

        // Token: 0x04000883 RID: 2179
        public Color properties = Color.red;

        // Token: 0x04000884 RID: 2180
        public Color events = Color.red;

        // Token: 0x04000885 RID: 2181
        public Color parameters = Color.red;

        // Token: 0x04000886 RID: 2182
        public Color variables = Color.red;

        // Token: 0x04000887 RID: 2183
        public Color typeParameters = Color.red;

        // Token: 0x04000888 RID: 2184
        public Color enumMembers = Color.red;

        // Token: 0x04000889 RID: 2185
        public Color preprocessor = Color.red;

        // Token: 0x0400088A RID: 2186
        public Color defineSymbols = Color.red;

        // Token: 0x0400088B RID: 2187
        public Color inactiveCode = Color.gray;

        // Token: 0x0400088C RID: 2188
        public Color comments = Color.red;

        // Token: 0x0400088D RID: 2189
        public Color xmlDocs = Color.red;

        // Token: 0x0400088E RID: 2190
        public Color xmlDocsTags = Color.red;

        // Token: 0x0400088F RID: 2191
        public Color lineNumbers = Color.red;

        // Token: 0x04000890 RID: 2192
        public Color lineNumbersHighlight = Color.red;

        // Token: 0x04000891 RID: 2193
        public Color lineNumbersBackground = Color.gray;

        // Token: 0x04000892 RID: 2194
        public Color fold = Color.red;

        // Token: 0x04000893 RID: 2195
        public Color activeSelection = new Color32(51, 153, byte.MaxValue, 102);

        // Token: 0x04000894 RID: 2196
        public Color passiveSelection = new Color32(191, 205, 219, 102);

        // Token: 0x04000895 RID: 2197
        public Color searchResults = Color.yellow;

        // Token: 0x04000896 RID: 2198
        public Color trackSaved = new Color32(108, 226, 108, byte.MaxValue);

        // Token: 0x04000897 RID: 2199
        public Color trackChanged = new Color32(byte.MaxValue, 238, 98, byte.MaxValue);

        // Token: 0x04000898 RID: 2200
        public Color trackReverted = new Color32(246, 201, 60, byte.MaxValue);

        // Token: 0x04000899 RID: 2201
        public Color currentLine = Color.green;

        // Token: 0x0400089A RID: 2202
        public Color currentLineInactive = Color.magenta;

        // Token: 0x0400089B RID: 2203
        public Color referenceHighlight = new Color32(224, byte.MaxValue, byte.MaxValue, byte.MaxValue);

        // Token: 0x0400089C RID: 2204
        public Color referenceModifyHighlight = new Color32(byte.MaxValue, 221, 221, byte.MaxValue);

        // Token: 0x0400089D RID: 2205
        public Color tooltipBackground = new Color32(253, byte.MaxValue, 153, byte.MaxValue);

        // Token: 0x0400089E RID: 2206
        public Color tooltipFrame = new Color32(128, 128, 128, byte.MaxValue);

        // Token: 0x0400089F RID: 2207
        public Color tooltipText = new Color32(22, 22, 22, byte.MaxValue);

        // Token: 0x040008A0 RID: 2208
        public Color listPopupFrame = Color.clear;

        // Token: 0x040008A1 RID: 2209
        public Color listPopupBackground = Color.gray;

        // Token: 0x040008A2 RID: 2210
        public FontStyle commentsStyle = 0;

        // Token: 0x040008A3 RID: 2211
        public FontStyle stringsStyle = 0;

        // Token: 0x040008A4 RID: 2212
        public FontStyle keywordsStyle = 0;

        // Token: 0x040008A5 RID: 2213
        public FontStyle constantsStyle = 0;

        // Token: 0x040008A6 RID: 2214
        public FontStyle typesStyle = 0;

        // Token: 0x040008A7 RID: 2215
        public FontStyle namespacesStyle = 0;

        // Token: 0x040008A8 RID: 2216
        public FontStyle methodsStyle = 0;

        // Token: 0x040008A9 RID: 2217
        public FontStyle fieldsStyle = 0;

        // Token: 0x040008AA RID: 2218
        public FontStyle propertiesStyle = 0;

        // Token: 0x040008AB RID: 2219
        public FontStyle eventsStyle = 0;

        // Token: 0x040008AC RID: 2220
        public FontStyle hyperlinksStyle = 0;

        // Token: 0x040008AD RID: 2221
        public FontStyle preprocessorStyle = 0;

        // Token: 0x040008AE RID: 2222
        public FontStyle defineSymbolsStyle = 0;

        // Token: 0x040008AF RID: 2223
        public FontStyle inactiveCodeStyle = 0;

        // Token: 0x040008B0 RID: 2224
        public FontStyle parametersStyle = 0;

        // Token: 0x040008B1 RID: 2225
        public FontStyle variablesStyle = 0;

        // Token: 0x040008B2 RID: 2226
        public FontStyle typeParametersStyle = 0;

        // Token: 0x040008B3 RID: 2227
        public FontStyle enumMembersStyle = 0;
    }
}
