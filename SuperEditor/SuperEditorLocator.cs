using System;
using UnityEngine;

namespace SuperEditor
{
    // Token: 0x0200009B RID: 155
    public class SuperEditorLocator : ScriptableObject
    {
        // Token: 0x06000483 RID: 1155 RVA: 0x000CBE68 File Offset: 0x000CA068
        internal static SuperEditorLocator Instance()
        {
            bool flag = SuperEditorLocator.NCOL == null;
            if (flag)
            {
                SuperEditorLocator.NCOL = ScriptableObject.CreateInstance<SuperEditorLocator>();
                SuperEditorLocator.NCOL.hideFlags = (HideFlags)61;
            }
            return SuperEditorLocator.NCOL;
        }

        // Token: 0x040004A0 RID: 1184
        private static SuperEditorLocator NCOL;
    }
}
