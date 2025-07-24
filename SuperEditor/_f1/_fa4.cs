using System;
using System.Collections.Generic;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200014F RID: 335
    internal class _fa4 : _fa7
    {
        // Token: 0x060009B5 RID: 2485 RVA: 0x001035D8 File Offset: 0x001017D8
        internal _fa4()
        {
            this.LLBP = _fa2.GetInstance().GetTexture((_f2)28);
            this.HIAM = _fa2.GetInstance().GetTexture((_f2)24);
            this.JKCJ = _fa2.GetInstance().GetTexture((_f2)26);
            this.BAHP = this.LLBP;
            this.ADDI = this.HIAM;
            this.EBCL = this.JKCJ;
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowVisibility, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x060009B6 RID: 2486 RVA: 0x0010366D File Offset: 0x0010186D
        private void SettingsChanged()
        {
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowVisibility);
        }

        // Token: 0x060009B7 RID: 2487 RVA: 0x00100831 File Offset: 0x000FEA31
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            rect.x -= 18f;
            rect.width = 18f;
        }

        // Token: 0x060009B8 RID: 2488 RVA: 0x00103684 File Offset: 0x00101884
        internal override void DisabledHandler(GameObject gameObject, _fb5 objectList)
        {
            bool flag = objectList != null;
            if (flag)
            {
                bool flag2 = gameObject.activeSelf && objectList.MGEE.Contains(gameObject);
                if (flag2)
                {
                    objectList.MGEE.Remove(gameObject);
                    gameObject.SetActive(false);
                    EditorUtility.SetDirty(gameObject);
                }
                else
                {
                    bool flag3 = !gameObject.activeSelf && objectList.GINK.Contains(gameObject);
                    if (flag3)
                    {
                        objectList.GINK.Remove(gameObject);
                        gameObject.SetActive(true);
                        EditorUtility.SetDirty(gameObject);
                    }
                }
            }
        }

        // Token: 0x060009B9 RID: 2489 RVA: 0x00103714 File Offset: 0x00101914
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            int num = (gameObject.activeSelf ? 1 : 0);
            bool flag = this.IsEditModeVisibile(gameObject, objectList);
            bool flag2 = this.IsEditModeInvisibile(gameObject, objectList);
            bool flag3 = !EditorApplication.isPlayingOrWillChangePlaymode && ((!gameObject.activeSelf && flag) || (gameObject.activeSelf && flag2));
            if (flag3)
            {
                gameObject.SetActive(!gameObject.activeSelf);
            }
            bool flag4 = num == 1;
            if (flag4)
            {
                Transform transform = gameObject.transform;
                while (transform.parent != null)
                {
                    transform = transform.parent;
                    bool flag5 = !transform.gameObject.activeSelf;
                    if (flag5)
                    {
                        num = 2;
                        break;
                    }
                }
            }
            bool flag6 = !EditorApplication.isPlayingOrWillChangePlaymode && (flag || flag2);
            Texture2D texture2D;
            if (flag6)
            {
                texture2D = ((num == 0) ? this.ADDI : ((num == 1) ? this.BAHP : this.EBCL));
            }
            else
            {
                texture2D = ((num == 0) ? this.HIAM : ((num == 1) ? this.LLBP : this.JKCJ));
            }
            GUI.DrawTexture(curRect, texture2D);
        }

        // Token: 0x060009BA RID: 2490 RVA: 0x00103824 File Offset: 0x00101A24
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
            bool flag = currentEvent.isMouse && currentEvent.button == 0 && curRect.Contains(currentEvent.mousePosition);
            if (flag)
            {
                bool flag2 = currentEvent.type == 0;
                if (flag2)
                {
                    this.KIEJ = ((!gameObject.activeSelf) ? 1 : 0);
                }
                else
                {
                    bool flag3 = (int)currentEvent.type == 3 && this.KIEJ != -1;
                    if (!flag3)
                    {
                        this.KIEJ = -1;
                        return;
                    }
                    bool flag4 = this.KIEJ == (gameObject.activeSelf ? 1 : 0);
                    if (flag4)
                    {
                        return;
                    }
                }
                bool flag5 = _f5.GetInstance().Get<bool>(HierarchySetting.ShowModifierWarning);
                List<GameObject> list = new List<GameObject>();
                bool flag6 = Selection.Contains(gameObject);
                if (flag6)
                {
                    list.AddRange(Selection.gameObjects);
                }
                else
                {
                    base.GetGameObjectListRecursive(gameObject, ref list, 0);
                }
                this.SetVisibility(list, objectList, !gameObject.activeSelf, currentEvent.control || currentEvent.command);
                currentEvent.Use();
            }
        }

        // Token: 0x060009BB RID: 2491 RVA: 0x00103930 File Offset: 0x00101B30
        private bool IsEditModeVisibile(GameObject gameObject, _fb5 objectList)
        {
            return !(objectList == null) && objectList.MGEE.Contains(gameObject);
        }

        // Token: 0x060009BC RID: 2492 RVA: 0x0010395C File Offset: 0x00101B5C
        private bool IsEditModeInvisibile(GameObject gameObject, _fb5 objectList)
        {
            return !(objectList == null) && objectList.GINK.Contains(gameObject);
        }

        // Token: 0x060009BD RID: 2493 RVA: 0x00103988 File Offset: 0x00101B88
        private void SetVisibility(List<GameObject> gameObjects, _fb5 objectList, bool targetVisibility, bool editMode)
        {
            bool flag = gameObjects.Count == 0;
            if (!flag)
            {
                for (int i = gameObjects.Count - 1; i >= 0; i--)
                {
                    GameObject gameObject = gameObjects[i];
                    Undo.RecordObject(gameObject, "visibility change");
                    gameObject.SetActive(targetVisibility);
                    EditorUtility.SetDirty(gameObject);
                }
            }
        }

        // Token: 0x04000850 RID: 2128
        private Texture2D LLBP;

        // Token: 0x04000851 RID: 2129
        private Texture2D BAHP;

        // Token: 0x04000852 RID: 2130
        private Texture2D HIAM;

        // Token: 0x04000853 RID: 2131
        private Texture2D ADDI;

        // Token: 0x04000854 RID: 2132
        private Texture2D JKCJ;

        // Token: 0x04000855 RID: 2133
        private Texture2D EBCL;

        // Token: 0x04000856 RID: 2134
        private int KIEJ = -1;
    }
}
