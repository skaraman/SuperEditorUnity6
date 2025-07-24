using System;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000075 RID: 117
    [InitializeOnLoad]
    internal static class _bk3
    {
        // Token: 0x0600039F RID: 927 RVA: 0x000A7E2D File Offset: 0x000A602D
        static _bk3()
        {
            EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
            {
                _bj2.Init(false);
            }));
        }
    }
}
