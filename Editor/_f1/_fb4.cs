using System;
using System.Reflection;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000146 RID: 326
    internal class _fb4 : _fa7
    {
        // Token: 0x06000979 RID: 2425 RVA: 0x001016D0 File Offset: 0x000FF8D0
        internal _fb4()
        {
            this.DGMB = _fa2.GetInstance().GetTexture((_f2)17);
            this.NDJJ = _fa2.GetInstance().GetTexture((_f2)16);
            this.IIKM = _fa2.GetInstance().GetTexture((_f2)15);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowRendererComponent, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x0600097A RID: 2426 RVA: 0x00101741 File Offset: 0x000FF941
        private void SettingsChanged()
        {
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowRendererComponent);
        }

        // Token: 0x0600097B RID: 2427 RVA: 0x00101755 File Offset: 0x000FF955
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            rect.x -= 14f;
            rect.width = 14f;
        }

        // Token: 0x0600097C RID: 2428 RVA: 0x00101778 File Offset: 0x000FF978
        internal override void DisabledHandler(GameObject gameObject, _fb5 objectList)
        {
            bool flag = objectList != null && objectList.MBGD.Contains(gameObject);
            if (flag)
            {
                objectList.MBGD.Remove(gameObject);
                Renderer component = gameObject.GetComponent<Renderer>();
                bool flag2 = component != null;
                if (flag2)
                {
                    _fb4.SetSelectedRenderState(component, false);
                }
            }
        }

        // Token: 0x0600097D RID: 2429 RVA: 0x001017CC File Offset: 0x000FF9CC
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            Renderer component = gameObject.GetComponent<Renderer>();
            GUIContent guicontent = EditorGUIUtility.ObjectContent(component, null);
            bool flag = component != null;
            if (flag)
            {
                bool flag2 = true;
                try
                {
                    PropertyInfo property = component.GetType().GetProperty("enabled");
                    flag2 = (bool)property.GetGetMethod().Invoke(component, null);
                }
                catch
                {
                }
                Color color = GUI.color;
                color.a = (flag2 ? 1f : 0.3f);
                GUI.color = color;
                GUI.DrawTexture(curRect, guicontent.image);
                color.a = 1f;
                GUI.color = color;
            }
        }

        // Token: 0x0600097E RID: 2430 RVA: 0x00101880 File Offset: 0x000FFA80
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect rect)
        {
            bool flag = currentEvent.isMouse && currentEvent.button == 0 && rect.Contains(currentEvent.mousePosition);
            if (flag)
            {
                Renderer component = gameObject.GetComponent<Renderer>();
                bool flag2 = component != null;
                if (flag2)
                {
                    bool flag3 = this.IsWireframeHidden(gameObject, objectList);
                    bool enabled = component.enabled;
                    bool flag4 = currentEvent.type == EventType.MouseDown;
                    if (flag4)
                    {
                        this.HBAL = ((!enabled) ? 1 : 0);
                    }
                    else
                    {
                        bool flag5 = currentEvent.type == EventType.MouseDrag && this.HBAL != -1;
                        if (!flag5)
                        {
                            this.HBAL = -1;
                            return;
                        }
                        bool flag6 = this.HBAL == (enabled ? 1 : 0);
                        if (flag6)
                        {
                            return;
                        }
                    }
                    Undo.RecordObject(component, "renderer visibility change");
                    bool flag7 = currentEvent.control || currentEvent.command;
                    if (flag7)
                    {
                        bool flag8 = !flag3;
                        if (flag8)
                        {
                            _fb4.SetSelectedRenderState(component, true);
                            SceneView.RepaintAll();
                            this.SetWireframeMode(gameObject, objectList, true);
                        }
                    }
                    else
                    {
                        bool flag9 = flag3;
                        if (flag9)
                        {
                            _fb4.SetSelectedRenderState(component, false);
                            SceneView.RepaintAll();
                            this.SetWireframeMode(gameObject, objectList, false);
                        }
                        else
                        {
                            Undo.RecordObject(component, enabled ? "Disable Component" : "Enable Component");
                            component.enabled = !enabled;
                        }
                    }
                    EditorUtility.SetDirty(gameObject);
                }
                currentEvent.Use();
            }
        }

        // Token: 0x0600097F RID: 2431 RVA: 0x001019F0 File Offset: 0x000FFBF0
        public bool IsWireframeHidden(GameObject gameObject, _fb5 objectList)
        {
            return !(objectList == null) && objectList.MBGD.Contains(gameObject);
        }

        // Token: 0x06000980 RID: 2432 RVA: 0x00101A1C File Offset: 0x000FFC1C
        public void SetWireframeMode(GameObject gameObject, _fb5 objectList, bool targetWireframe)
        {
            bool flag = objectList == null && targetWireframe;
            if (flag)
            {
                objectList = _f7.getInstance().getObjectList(gameObject, true);
            }
            bool flag2 = objectList != null;
            if (flag2)
            {
                Undo.RecordObject(objectList, "Renderer Visibility Change");
                if (targetWireframe)
                {
                    objectList.MBGD.Add(gameObject);
                }
                else
                {
                    objectList.MBGD.Remove(gameObject);
                }
                EditorUtility.SetDirty(objectList);
            }
        }

        // Token: 0x06000981 RID: 2433 RVA: 0x00101A86 File Offset: 0x000FFC86
        public static void SetSelectedRenderState(Renderer renderer, bool visible)
        {
            EditorUtility.SetSelectedRenderState(renderer, (EditorSelectedRenderState)(visible ? 1 : 0));
        }

        // Token: 0x04000823 RID: 2083
        private Texture2D NDJJ;

        // Token: 0x04000824 RID: 2084
        private Texture2D IIKM;

        // Token: 0x04000825 RID: 2085
        private Texture2D DGMB;

        // Token: 0x04000826 RID: 2086
        private int HBAL = -1;
    }
}
