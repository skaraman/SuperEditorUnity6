using System;
using System.Collections.Generic;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000135 RID: 309
    internal class _fa1
    {
        // Token: 0x0600094E RID: 2382 RVA: 0x000FF5FC File Offset: 0x000FD7FC
        public _fa1()
        {
            this._yt1 = new Dictionary<int, _fa7>();
            this._yt1.Add(0, new _f6());
            this._yt1.Add(1, new _fa4());
            this._yt1.Add(2, new _fb1());
            this._yt1.Add(4, new _fb4());
            this._yt1.Add(6, new _f3());
            this._yt1.Add(7, new _fa9());
            this._yt1.Add(3, new _fa6());
            this._yt1.Add(11, new _fa5());
            this._yt1.Add(8, new _fb2());
            this._yt1.Add(5, new _fa3());
            this._yt2 = new List<_fa7>();
            this._yt3 = new List<_fa7>();
            this._yt3.Add(new _f4());
            this._yt4 = _fa2.GetInstance().GetTexture((_f2)23);
            _f5.GetInstance().AddEventListener(HierarchySetting.Identation, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ComponentOrder, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.HideIconsIfNotFit, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x0600094F RID: 2383 RVA: 0x000FF774 File Offset: 0x000FD974
        private void SettingsChanged()
        {
            this._yt2.Clear();
            string text = _f5.GetInstance().Get<string>(HierarchySetting.ComponentOrder);
            string[] array = text.Split(new char[] { ';' });
            bool flag = array.Length != 9;
            if (flag)
            {
                _f5.GetInstance().Set<string>(HierarchySetting.ComponentOrder, "0;1;2;3;4;5;6;7;8");
                array = "0;1;2;3;4;5;6;7;8".Split(new char[] { ';' });
            }
            for (int i = 0; i < array.Length; i++)
            {
                this._yt2.Add(this._yt1[int.Parse(array[i])]);
            }
            this._yt2.Add(this._yt1[11]);
            this._yt5 = _f5.GetInstance().Get<int>(HierarchySetting.Identation);
            this._yt6 = _f5.GetInstance().Get<bool>(HierarchySetting.HideIconsIfNotFit);
        }

        // Token: 0x06000950 RID: 2384 RVA: 0x000FF858 File Offset: 0x000FDA58
        public void HierarchyWindowItemOnGUIHandler(int instanceId, Rect selectionRect)
        {
            bool flag = Event.current.type == EventType.MouseEnterWindow;
            if (flag)
            {
                _fa1.IGPC = true;
            }
            bool flag2 = Event.current.type == EventType.MouseLeaveWindow;
            if (flag2)
            {
                _fa1.IGPC = false;
            }
            try
            {
                GameObject gameObject = (GameObject)EditorUtility.InstanceIDToObject(instanceId);
                bool flag3 = gameObject == null;
                if (!flag3)
                {
                    Rect rect;
                    rect = selectionRect;
                    rect.width = 16f;
                    rect.x += selectionRect.width - (float)this._yt5;
                    float num = (this._yt6 ? GUI.skin.label.CalcSize(new GUIContent(gameObject.name)).x : 0f);
                    _fb5 objectList = _f7.getInstance().getObjectList(gameObject, false);
                    this.DrawComponents(this._yt2, selectionRect, ref rect, gameObject, objectList, this._yt6, selectionRect.x + num + 7f);
                    this.DrawComponents(this._yt3, selectionRect, ref rect, gameObject, objectList, false, 50f);
                    this._yt7 = rect;
                    this._yt8.Remove(instanceId);
                }
            }
            catch (Exception ex)
            {
                bool flag4 = this._yt8.Add(instanceId);
                if (flag4)
                {
                    Debug.LogError(ex.ToString());
                }
            }
        }

        // Token: 0x06000951 RID: 2385 RVA: 0x000FF9B8 File Offset: 0x000FDBB8
        private void DrawComponents(List<_fa7> components, Rect selectionRect, ref Rect curRect, GameObject gameObject, _fb5 objectList, bool trim = false, float minX = 50f)
        {
            Rect rect;
            rect = curRect;
            bool flag = Event.current.type == EventType.Repaint;
            if (flag)
            {
                int i = 0;
                int count = components.Count;
                while (i < count)
                {
                    _fa7 _yt9 = components[i];
                    bool flag2 = _yt9.IsEnabled();
                    if (flag2)
                    {
                        _yt9.Layout(gameObject, objectList, ref rect);
                        bool flag3 = trim && minX > rect.x;
                        if (flag3)
                        {
                            rect.Set(curRect.x - 16f, curRect.y, 16f, 16f);
                            GUI.DrawTexture(rect, this._yt4);
                            break;
                        }
                        _yt9.Draw(gameObject, objectList, selectionRect, rect);
                        curRect.Set(rect.x, rect.y, rect.width, rect.height);
                    }
                    else
                    {
                        _yt9.DisabledHandler(gameObject, objectList);
                    }
                    i++;
                }
            }
            else
            {
                bool isMouse = Event.current.isMouse;
                if (isMouse)
                {
                    int j = 0;
                    int count2 = components.Count;
                    while (j < count2)
                    {
                        _fa7 _yu1 = components[j];
                        bool flag4 = _yu1.IsEnabled();
                        if (flag4)
                        {
                            _yu1.Layout(gameObject, objectList, ref rect);
                            bool flag5 = trim && minX > rect.x;
                            if (flag5)
                            {
                                rect.Set(curRect.x - 7f, curRect.y, 7f, 16f);
                                GUI.DrawTexture(rect, this._yt4);
                                break;
                            }
                            _yu1.EventHandler(gameObject, objectList, Event.current, rect);
                            curRect.Set(rect.x, rect.y, rect.width, rect.height);
                        }
                        j++;
                    }
                }
            }
        }

        // Token: 0x040007B1 RID: 1969
        private HashSet<int> _yt8 = new HashSet<int>();

        // Token: 0x040007B2 RID: 1970
        private Dictionary<int, _fa7> _yt1;

        // Token: 0x040007B3 RID: 1971
        private List<_fa7> _yt2;

        // Token: 0x040007B4 RID: 1972
        private List<_fa7> _yt3;

        // Token: 0x040007B5 RID: 1973
        private bool _yt6;

        // Token: 0x040007B6 RID: 1974
        private int _yt5;

        // Token: 0x040007B7 RID: 1975
        private Texture2D _yt4;

        // Token: 0x040007B8 RID: 1976
        internal Rect _yt7 = Rect.zero;

        // Token: 0x040007B9 RID: 1977
        internal static bool IGPC;
    }
}
