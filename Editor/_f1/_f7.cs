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
            this._yr7 = _f5.GetInstance().Get<bool>(HierarchySetting.ShowHiddenObjectList);
            this._yr8 = _f5.GetInstance().Get<bool>(HierarchySetting.ShowLock) && _f5.GetInstance().Get<bool>(HierarchySetting.PreventSelectionOfLockedObjects);
        }

        // Token: 0x060009C3 RID: 2499 RVA: 0x00103B94 File Offset: 0x00101D94
        private bool isSelectionChanged()
        {
            bool flag = this._yr9 != Selection.activeGameObject || this._ys1 != Selection.gameObjects.Length;
            bool flag2;
            if (flag)
            {
                this._yr9 = Selection.activeGameObject;
                this._ys1 = Selection.gameObjects.Length;
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
            foreach (_fb5 _ys2 in _fb5.FGNP)
            {
                _ys2.CheckIntegrity();
            }
            this._ys3.Clear();
            foreach (_fb5 _ys4 in _fb5.FGNP)
            {
                this._ys3.Add(_ys4.gameObject.scene, _ys4);
            }
        }

        // Token: 0x060009C5 RID: 2501 RVA: 0x00103CD0 File Offset: 0x00101ED0
        public void update()
        {
            try
            {
                List<_fb5> _ys5 = _fb5.FGNP;
                int count = _ys5.Count;
                bool flag = count > 0;
                if (flag)
                {
                    for (int i = count - 1; i >= 0; i--)
                    {
                        _fb5 _ys2 = _ys5[i];
                        Scene scene = _ys2.gameObject.scene;
                        bool flag2 = this._ys3.ContainsKey(scene);
                        if (flag2)
                        {
                            bool flag3 = this._ys3[scene] != _ys2;
                            if (flag3)
                            {
                                this._ys3[scene].Merge(_ys2);
                                UnityEngine.Object.DestroyImmediate(_ys2.gameObject);
                            }
                        }
                        else
                        {
                            this._ys3.Add(scene, _ys2);
                        }
                    }
                    foreach (KeyValuePair<Scene, _fb5> keyValuePair in this._ys3)
                    {
                        _fb5 value = keyValuePair.Value;
                        this.setupObjectList(value);
                        bool flag4 = (this._yr7 && (value.gameObject.hideFlags & HideFlags.HideInHierarchy) > 0) || (!this._yr7 && (value.gameObject.hideFlags & HideFlags.HideInHierarchy) == 0);
                        if (flag4)
                        {
                            value.gameObject.hideFlags ^= HideFlags.HideInHierarchy;
                            EditorApplication.DirtyHierarchyWindowSorting();
                        }
                    }
                    bool _ys6 = this._yr8;
                    if (_ys6)
                    {
                        GameObject[] gameObjects = Selection.gameObjects;
                        List<GameObject> list = new List<GameObject>(gameObjects.Length);
                        bool flag5 = false;
                        for (int j = gameObjects.Length - 1; j >= 0; j--)
                        {
                            GameObject gameObject = gameObjects[j];
                            bool flag6 = this._ys3.ContainsKey(gameObject.scene);
                            if (flag6)
                            {
                                bool flag7 = this._ys3[gameObject.scene].AENN.Contains(gameObjects[j]);
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
                    this._ys7 = SceneManager.GetActiveScene();
                    this._ys8 = SceneManager.loadedSceneCount;
                }
            }
            catch
            {
            }
        }

        // Token: 0x060009C6 RID: 2502 RVA: 0x00103F50 File Offset: 0x00102150
        public _fb5 getObjectList(GameObject gameObject, bool createIfNotExist = true)
        {
            _fb5 _ys2 = null;
            this._ys3.TryGetValue(gameObject.scene, out _ys2);
            bool flag = _ys2 == null && createIfNotExist;
            if (flag)
            {
                _ys2 = this.createObjectList(gameObject);
                bool flag2 = gameObject.scene != _ys2.gameObject.scene;
                if (flag2)
                {
                    SceneManager.MoveGameObjectToScene(_ys2.gameObject, gameObject.scene);
                }
                this._ys3.Add(gameObject.scene, _ys2);
            }
            return _ys2;
        }

        // Token: 0x060009C7 RID: 2503 RVA: 0x00103FD0 File Offset: 0x001021D0
        public bool isSceneChanged()
        {
            return this._ys7 != SceneManager.GetActiveScene() || this._ys8 != SceneManager.loadedSceneCount;
        }

        // Token: 0x060009C8 RID: 2504 RVA: 0x00104010 File Offset: 0x00102210
        private _fb5 createObjectList(GameObject gameObject)
        {
            _fb5 _ys2 = new GameObject
            {
                name = "ObjectList"
            }.AddComponent<_fb5>();
            this.setupObjectList(_ys2);
            return _ys2;
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
        private bool _yr7;

        // Token: 0x04000859 RID: 2137
        private bool _yr8;

        // Token: 0x0400085A RID: 2138
        private GameObject _yr9 = null;

        // Token: 0x0400085B RID: 2139
        private int _ys1 = 0;

        // Token: 0x0400085C RID: 2140
        private Dictionary<Scene, _fb5> _ys3 = new Dictionary<Scene, _fb5>();

        // Token: 0x0400085D RID: 2141
        private Scene _ys7;

        // Token: 0x0400085E RID: 2142
        private int _ys8 = 0;
    }
}
