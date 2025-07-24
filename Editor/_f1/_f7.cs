using System;
using System.Collections.Generic;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ODGL
{
    // Token: 0x02000151 RID: 337
    internal class _f7
    {
        // Token: 0x060009C0 RID: 2496 RVA: 0x00103AA4 File Offset: 0x00101CA4
        internal static _f7 getInstance()
        {
            bool flag = _f7._AA == null;
            if (flag)
            {
                _f7._AA = new _f7();
            }
            return _f7._AA;
        }

        // Token: 0x060009C1 RID: 2497 RVA: 0x00103AD4 File Offset: 0x00101CD4
        private _f7()
        {
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowHiddenObjectList, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.PreventSelectionOfLockedObjects, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowLock, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x060009C2 RID: 2498 RVA: 0x00103B5A File Offset: 0x00101D5A
        private void SettingsChanged()
        {
            this.JJCBFBDNALIDAOGOEEOANMGBEGFINLIHPHOF = _f5.GetInstance().Get<bool>(HierarchySetting.ShowHiddenObjectList);
            this.GACIFCJIJAKPDCECMBCDJODEPJJEKPOFJIEO = _f5.GetInstance().Get<bool>(HierarchySetting.ShowLock) && _f5.GetInstance().Get<bool>(HierarchySetting.PreventSelectionOfLockedObjects);
        }

        // Token: 0x060009C3 RID: 2499 RVA: 0x00103B94 File Offset: 0x00101D94
        private bool isSelectionChanged()
        {
            bool flag = this.KMLAJJMIPKAJCPECIBCEFBOIOKMDCIOPBGNL != Selection.activeGameObject || this.FDECGOFLKOFLOIBBKMCAKMPOAPDDHKLPBDNA != Selection.gameObjects.Length;
            bool flag2;
            if (flag)
            {
                this.KMLAJJMIPKAJCPECIBCEFBOIOKMDCIOPBGNL = Selection.activeGameObject;
                this.FDECGOFLKOFLOIBBKMCAKMPOAPDDHKLPBDNA = Selection.gameObjects.Length;
                flag2 = true;
            }
            else
            {
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x060009C4 RID: 2500 RVA: 0x00103BF0 File Offset: 0x00101DF0
        public void validate()
        {
            _fb5.FGNP.RemoveAll((_fb5 item) => item == null);
            foreach (_fb5 njahlagmgabdcnloedcemmeoblfchpnlhaac in _fb5.FGNP)
            {
                njahlagmgabdcnloedcemmeoblfchpnlhaac.CheckIntegrity();
            }
            this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.Clear();
            foreach (_fb5 njahlagmgabdcnloedcemmeoblfchpnlhaac2 in _fb5.FGNP)
            {
                this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.Add(njahlagmgabdcnloedcemmeoblfchpnlhaac2.gameObject.scene, njahlagmgabdcnloedcemmeoblfchpnlhaac2);
            }
        }

        // Token: 0x060009C5 RID: 2501 RVA: 0x00103CD0 File Offset: 0x00101ED0
        public void update()
        {
            try
            {
                List<_fb5> fgnpddkhhhmagpmjampcijfahjmckcpkgjdl = _fb5.FGNP;
                int count = fgnpddkhhhmagpmjampcijfahjmckcpkgjdl.Count;
                bool flag = count > 0;
                if (flag)
                {
                    for (int i = count - 1; i >= 0; i--)
                    {
                        _fb5 njahlagmgabdcnloedcemmeoblfchpnlhaac = fgnpddkhhhmagpmjampcijfahjmckcpkgjdl[i];
                        Scene scene = njahlagmgabdcnloedcemmeoblfchpnlhaac.gameObject.scene;
                        bool flag2 = this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.ContainsKey(scene);
                        if (flag2)
                        {
                            bool flag3 = this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE[scene] != njahlagmgabdcnloedcemmeoblfchpnlhaac;
                            if (flag3)
                            {
                                this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE[scene].Merge(njahlagmgabdcnloedcemmeoblfchpnlhaac);
                                UnityEngine.Object.DestroyImmediate(njahlagmgabdcnloedcemmeoblfchpnlhaac.gameObject);
                            }
                        }
                        else
                        {
                            this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.Add(scene, njahlagmgabdcnloedcemmeoblfchpnlhaac);
                        }
                    }
                    foreach (KeyValuePair<Scene, _fb5> keyValuePair in this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE)
                    {
                        _fb5 value = keyValuePair.Value;
                        this.setupObjectList(value);
                        bool flag4 = (this.JJCBFBDNALIDAOGOEEOANMGBEGFINLIHPHOF && (value.gameObject.hideFlags & 1) > 0) || (!this.JJCBFBDNALIDAOGOEEOANMGBEGFINLIHPHOF && (value.gameObject.hideFlags & 1) == 0);
                        if (flag4)
                        {
                            value.gameObject.hideFlags ^= 1;
                            EditorApplication.DirtyHierarchyWindowSorting();
                        }
                    }
                    bool gacifcjijakpdcecmbcdjodepjjekpofjieo = this.GACIFCJIJAKPDCECMBCDJODEPJJEKPOFJIEO;
                    if (gacifcjijakpdcecmbcdjodepjjekpofjieo)
                    {
                        GameObject[] gameObjects = Selection.gameObjects;
                        List<GameObject> list = new List<GameObject>(gameObjects.Length);
                        bool flag5 = false;
                        for (int j = gameObjects.Length - 1; j >= 0; j--)
                        {
                            GameObject gameObject = gameObjects[j];
                            bool flag6 = this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.ContainsKey(gameObject.scene);
                            if (flag6)
                            {
                                bool flag7 = this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE[gameObject.scene].AENN.Contains(gameObjects[j]);
                                bool flag8 = !flag7;
                                if (flag8)
                                {
                                    list.Add(gameObjects[j]);
                                }
                                else
                                {
                                    flag5 = true;
                                }
                            }
                        }
                        bool flag9 = flag5;
                        if (flag9)
                        {
                            UnityEngine.Object[] array = list.ToArray();
                            Selection.objects = array;
                        }
                    }
                    this.KODPIDPPBCBCJKOJM_AWGEBJBJLMDBJNPCKI = SceneManager.GetActiveScene();
                    this.MOHJMKPPPLBLNAPKJONNPCCGELMCLOGLJLIP = SceneManager.loadedSceneCount;
                }
            }
            catch
            {
            }
        }

        // Token: 0x060009C6 RID: 2502 RVA: 0x00103F50 File Offset: 0x00102150
        public _fb5 getObjectList(GameObject gameObject, bool createIfNotExist = true)
        {
            _fb5 njahlagmgabdcnloedcemmeoblfchpnlhaac = null;
            this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.TryGetValue(gameObject.scene, out njahlagmgabdcnloedcemmeoblfchpnlhaac);
            bool flag = njahlagmgabdcnloedcemmeoblfchpnlhaac == null && createIfNotExist;
            if (flag)
            {
                njahlagmgabdcnloedcemmeoblfchpnlhaac = this.createObjectList(gameObject);
                bool flag2 = gameObject.scene != njahlagmgabdcnloedcemmeoblfchpnlhaac.gameObject.scene;
                if (flag2)
                {
                    SceneManager.MoveGameObjectToScene(njahlagmgabdcnloedcemmeoblfchpnlhaac.gameObject, gameObject.scene);
                }
                this.GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE.Add(gameObject.scene, njahlagmgabdcnloedcemmeoblfchpnlhaac);
            }
            return njahlagmgabdcnloedcemmeoblfchpnlhaac;
        }

        // Token: 0x060009C7 RID: 2503 RVA: 0x00103FD0 File Offset: 0x001021D0
        public bool isSceneChanged()
        {
            return this.KODPIDPPBCBCJKOJM_AWGEBJBJLMDBJNPCKI != SceneManager.GetActiveScene() || this.MOHJMKPPPLBLNAPKJONNPCCGELMCLOGLJLIP != SceneManager.loadedSceneCount;
        }

        // Token: 0x060009C8 RID: 2504 RVA: 0x00104010 File Offset: 0x00102210
        private _fb5 createObjectList(GameObject gameObject)
        {
            _fb5 njahlagmgabdcnloedcemmeoblfchpnlhaac = new GameObject
            {
                name = "ObjectList"
            }.AddComponent<_fb5>();
            this.setupObjectList(njahlagmgabdcnloedcemmeoblfchpnlhaac);
            return njahlagmgabdcnloedcemmeoblfchpnlhaac;
        }

        // Token: 0x060009C9 RID: 2505 RVA: 0x00104044 File Offset: 0x00102244
        private void setupObjectList(_fb5 objectList)
        {
            bool flag = objectList.tag == "EditorOnly";
            if (flag)
            {
                objectList.tag = "Untagged";
            }
            MonoScript monoScript = MonoScript.FromMonoBehaviour(objectList);
            bool flag2 = MonoImporter.GetExecutionOrder(monoScript) != -10000;
            if (flag2)
            {
                MonoImporter.SetExecutionOrder(monoScript, -10000);
            }
        }

        // Token: 0x04000857 RID: 2135
        private static _f7 _AA;

        // Token: 0x04000858 RID: 2136
        private bool JJCBFBDNALIDAOGOEEOANMGBEGFINLIHPHOF;

        // Token: 0x04000859 RID: 2137
        private bool GACIFCJIJAKPDCECMBCDJODEPJJEKPOFJIEO;

        // Token: 0x0400085A RID: 2138
        private GameObject KMLAJJMIPKAJCPECIBCEFBOIOKMDCIOPBGNL = null;

        // Token: 0x0400085B RID: 2139
        private int FDECGOFLKOFLOIBBKMCAKMPOAPDDHKLPBDNA = 0;

        // Token: 0x0400085C RID: 2140
        private Dictionary<Scene, _fb5> GJFBPNOOLONPKHEINBDDOJAMFFOINGGPFDIE = new Dictionary<Scene, _fb5>();

        // Token: 0x0400085D RID: 2141
        private Scene KODPIDPPBCBCJKOJM_AWGEBJBJLMDBJNPCKI;

        // Token: 0x0400085E RID: 2142
        private int MOHJMKPPPLBLNAPKJONNPCCGELMCLOGLJLIP = 0;
    }
}
