using System;
using System.Collections.Generic;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200014D RID: 333
    internal class _f6 : _fa7
    {
        // Token: 0x060009A7 RID: 2471 RVA: 0x00102DD4 File Offset: 0x00100FD4
        internal _f6()
        {
            this._yr3 = _fa2.GetInstance().GetTexture((_f2)10);
            this._yr4 = _fa2.GetInstance().GetTexture((_f2)9);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowModifierWarning, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowLock, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x060009A8 RID: 2472 RVA: 0x00102E4C File Offset: 0x0010104C
        private void SettingsChanged()
        {
            this._yr5 = _f5.GetInstance().Get<bool>(HierarchySetting.ShowModifierWarning);
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowLock);
        }

        // Token: 0x060009A9 RID: 2473 RVA: 0x00102E72 File Offset: 0x00101072
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            rect.x -= 13f;
            rect.width = 13f;
        }

        // Token: 0x060009AA RID: 2474 RVA: 0x00102E94 File Offset: 0x00101094
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            bool flag = this.IsGameObjectLock(gameObject, objectList);
            bool flag2 = flag && (gameObject.hideFlags & HideFlags.NotEditable) != HideFlags.NotEditable;
            if (flag2)
            {
                gameObject.hideFlags |= HideFlags.NotEditable;
                EditorUtility.SetDirty(gameObject);
            }
            else
            {
                bool flag3 = !flag && (gameObject.hideFlags & HideFlags.NotEditable) == HideFlags.NotEditable;
                if (flag3)
                {
                    gameObject.hideFlags ^= HideFlags.NotEditable;
                    EditorUtility.SetDirty(gameObject);
                }
            }
            GUI.DrawTexture(curRect, flag ? this._yr3 : this._yr4);
        }

        // Token: 0x060009AB RID: 2475 RVA: 0x00102F24 File Offset: 0x00101124
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
            bool flag = currentEvent.isMouse && currentEvent.button == 0 && curRect.Contains(currentEvent.mousePosition);
            if (flag)
            {
                bool flag2 = this.IsGameObjectLock(gameObject, objectList);
                bool flag3 = currentEvent.type == EventType.MouseDown;
                if (flag3)
                {
                    this._yr6 = ((!flag2) ? 1 : 0);
                }
                else
                {
                    bool flag4 = currentEvent.type == EventType.MouseDrag && this._yr6 != -1;
                    if (!flag4)
                    {
                        this._yr6 = -1;
                        return;
                    }
                    bool flag5 = this._yr6 == (flag2 ? 1 : 0);
                    if (flag5)
                    {
                        return;
                    }
                }
                List<GameObject> list = new List<GameObject>();
                bool shift = currentEvent.shift;
                if (shift)
                {
                    bool flag6 = !this._yr5 || EditorUtility.DisplayDialog("Change locking", "Are you sure you want to " + (flag2 ? "unlock" : "lock") + " this GameObject and all its children? (You can disable this warning in the settings)", "Yes", "Cancel");
                    if (flag6)
                    {
                        base.GetGameObjectListRecursive(gameObject, ref list, int.MaxValue);
                    }
                }
                else
                {
                    bool alt = currentEvent.alt;
                    if (alt)
                    {
                        bool flag7 = gameObject.transform.parent != null;
                        if (!flag7)
                        {
                            Debug.Log("This action for root objects is supported only for Unity3d 5.3.3 and above");
                            return;
                        }
                        bool flag8 = !this._yr5 || EditorUtility.DisplayDialog("Change locking", "Are you sure you want to " + (flag2 ? "unlock" : "lock") + " this GameObject and its siblings? (You can disable this warning in the settings)", "Yes", "Cancel");
                        if (flag8)
                        {
                            base.GetGameObjectListRecursive(gameObject.transform.parent.gameObject, ref list, 1);
                            list.Remove(gameObject.transform.parent.gameObject);
                        }
                    }
                    else
                    {
                        bool flag9 = Selection.Contains(gameObject);
                        if (flag9)
                        {
                            list.AddRange(Selection.gameObjects);
                        }
                        else
                        {
                            base.GetGameObjectListRecursive(gameObject, ref list, 0);
                        }
                    }
                }
                this.SetLock(list, objectList, !flag2);
                currentEvent.Use();
            }
        }

        // Token: 0x060009AC RID: 2476 RVA: 0x0010312C File Offset: 0x0010132C
        internal override void DisabledHandler(GameObject gameObject, _fb5 objectList)
        {
            bool flag = objectList != null && objectList.AENN.Contains(gameObject);
            if (flag)
            {
                objectList.AENN.Remove(gameObject);
                gameObject.hideFlags &= ~HideFlags.NotEditable;
                EditorUtility.SetDirty(gameObject);
            }
        }

        // Token: 0x060009AD RID: 2477 RVA: 0x0010317C File Offset: 0x0010137C
        private bool IsGameObjectLock(GameObject gameObject, _fb5 objectList)
        {
            return !(objectList == null) && objectList.AENN.Contains(gameObject);
        }

        // Token: 0x060009AE RID: 2478 RVA: 0x001031A8 File Offset: 0x001013A8
        private void SetLock(List<GameObject> gameObjects, _fb5 objectList, bool targetLock)
        {
            bool flag = gameObjects.Count == 0;
            if (!flag)
            {
                bool flag2 = objectList == null;
                if (flag2)
                {
                    objectList = _f7.getInstance().getObjectList(gameObjects[0], true);
                }
                Undo.RecordObject(objectList, targetLock ? "Lock" : "Unlock");
                for (int i = gameObjects.Count - 1; i >= 0; i--)
                {
                    GameObject gameObject = gameObjects[i];
                    Undo.RecordObject(gameObject, targetLock ? "Lock" : "Unlock");
                    if (targetLock)
                    {
                        gameObject.hideFlags |= HideFlags.NotEditable;
                        bool flag3 = !objectList.AENN.Contains(gameObject);
                        if (flag3)
                        {
                            objectList.AENN.Add(gameObject);
                        }
                    }
                    else
                    {
                        gameObject.hideFlags &= ~HideFlags.NotEditable;
                        objectList.AENN.Remove(gameObject);
                    }
                    EditorUtility.SetDirty(gameObject);
                }
            }
        }

        // Token: 0x04000847 RID: 2119
        private Texture2D _yr3;

        // Token: 0x04000848 RID: 2120
        private Texture2D _yr4;

        // Token: 0x04000849 RID: 2121
        private bool _yr5;

        // Token: 0x0400084A RID: 2122
        private int _yr6 = -1;
    }
}
