using System;
using AHO;
using UnityEditor;
using UnityEngine;

namespace FEOCJICFPEHKGMMCGOCFIOPPOJIAOLJNEKNO
{
    // Token: 0x02000168 RID: 360
    internal static class HKAIMFAJFFLFHGGCFLIEGGMNPNPIFDNAAION
    {
        // Token: 0x060009F7 RID: 2551 RVA: 0x0010AF9E File Offset: 0x0010919E
        [MenuItem("Window/Super Editor/Open File... _&%o", false, 500)]
        private static void OpenFile()
        {
            EditorGUIUtility.ShowObjectPicker<UnityEngine.Object>(null, true, null, 332553);
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(HKAIMFAJFFLFHGGCFLIEGGMNPNPIFDNAAION.WaitForObjectPicker));
        }

        // Token: 0x060009F8 RID: 2552 RVA: 0x0010AFD0 File Offset: 0x001091D0
        private static void WaitForObjectPicker()
        {
            int objectPickerControlID = EditorGUIUtility.GetObjectPickerControlID();
            bool flag = objectPickerControlID == 332553;
            if (flag)
            {
                HKAIMFAJFFLFHGGCFLIEGGMNPNPIFDNAAION._BCL = EditorGUIUtility.GetObjectPickerObject();
            }
            else
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(HKAIMFAJFFLFHGGCFLIEGGMNPNPIFDNAAION.WaitForObjectPicker));
                string assetPath = AssetDatabase.GetAssetPath(HKAIMFAJFFLFHGGCFLIEGGMNPNPIFDNAAION._BCL);
                string text = AssetDatabase.AssetPathToGUID(assetPath);
                bool flag2 = text != "";
                if (flag2)
                {
                    _bb6.OpenAssetInTab(text);
                }
            }
        }

        // Token: 0x0400092C RID: 2348
        private static UnityEngine.Object _BCL;
    }
}
