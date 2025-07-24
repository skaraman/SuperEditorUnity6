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
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME = new Dictionary<int, _fa7>();
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(0, new _f6());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(1, new _fa4());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(2, new _fb1());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(4, new _fb4());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(6, new _f3());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(7, new _fa9());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(3, new _fa6());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(11, new _fa5());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(8, new _fb2());
            this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME.Add(5, new _fa3());
            this.MGIAPPIPBKEJIAGCDDEFMBNAOJJMJJBIJHAH = new List<_fa7>();
            this.AKHDBNNHIFJLFHKFHOPLGHOEMNIIMBEIJAPJ = new List<_fa7>();
            this.AKHDBNNHIFJLFHKFHOPLGHOEMNIIMBEIJAPJ.Add(new _f4());
            this.NLCDGBGNEMBJDHIGBNMEMGIDLJNPJFBMICHG = _fa2.GetInstance().GetTexture((_f2)23);
            _f5.GetInstance().AddEventListener(HierarchySetting.Identation, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ComponentOrder, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.HideIconsIfNotFit, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x0600094F RID: 2383 RVA: 0x000FF774 File Offset: 0x000FD974
        private void SettingsChanged()
        {
            this.MGIAPPIPBKEJIAGCDDEFMBNAOJJMJJBIJHAH.Clear();
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
                this.MGIAPPIPBKEJIAGCDDEFMBNAOJJMJJBIJHAH.Add(this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME[int.Parse(array[i])]);
            }
            this.MGIAPPIPBKEJIAGCDDEFMBNAOJJMJJBIJHAH.Add(this.DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME[11]);
            this.NJHFKMIPEIJKGFLDDKFEEPDBAKHJOJFPAFJC = _f5.GetInstance().Get<int>(HierarchySetting.Identation);
            this.FGJEFJGDONJJLLCILFFGACDGHLFDEBGJAKED = _f5.GetInstance().Get<bool>(HierarchySetting.HideIconsIfNotFit);
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
                    rect..ctor(selectionRect);
                    rect.width = 16f;
                    rect.x += selectionRect.width - (float)this.NJHFKMIPEIJKGFLDDKFEEPDBAKHJOJFPAFJC;
                    float num = (this.FGJEFJGDONJJLLCILFFGACDGHLFDEBGJAKED ? GUI.skin.label.CalcSize(new GUIContent(gameObject.name)).x : 0f);
                    _fb5 objectList = _f7.getInstance().getObjectList(gameObject, false);
                    this.DrawComponents(this.MGIAPPIPBKEJIAGCDDEFMBNAOJJMJJBIJHAH, selectionRect, ref rect, gameObject, objectList, this.FGJEFJGDONJJLLCILFFGACDGHLFDEBGJAKED, selectionRect.x + num + 7f);
                    this.DrawComponents(this.AKHDBNNHIFJLFHKFHOPLGHOEMNIIMBEIJAPJ, selectionRect, ref rect, gameObject, objectList, false, 50f);
                    this.HLEPHLDNDOHCOGHEHGJEOAEKLFFODEKPKJNG = rect;
                    this.IAGDKCPKIBMBEACBIIPEEPAJMDMHOJJHOBHH.Remove(instanceId);
                }
            }
            catch (Exception ex)
            {
                bool flag4 = this.IAGDKCPKIBMBEACBIIPEEPAJMDMHOJJHOBHH.Add(instanceId);
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
            rect..ctor(curRect);
            bool flag = Event.current.type == EventType.Repaint;
            if (flag)
            {
                int i = 0;
                int count = components.Count;
                while (i < count)
                {
                    _fa7 jenckjegfhgblglbfmfgplmabmkcgbbfighp = components[i];
                    bool flag2 = jenckjegfhgblglbfmfgplmabmkcgbbfighp.IsEnabled();
                    if (flag2)
                    {
                        jenckjegfhgblglbfmfgplmabmkcgbbfighp.Layout(gameObject, objectList, ref rect);
                        bool flag3 = trim && minX > rect.x;
                        if (flag3)
                        {
                            rect.Set(curRect.x - 16f, curRect.y, 16f, 16f);
                            GUI.DrawTexture(rect, this.NLCDGBGNEMBJDHIGBNMEMGIDLJNPJFBMICHG);
                            break;
                        }
                        jenckjegfhgblglbfmfgplmabmkcgbbfighp.Draw(gameObject, objectList, selectionRect, rect);
                        curRect.Set(rect.x, rect.y, rect.width, rect.height);
                    }
                    else
                    {
                        jenckjegfhgblglbfmfgplmabmkcgbbfighp.DisabledHandler(gameObject, objectList);
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
                        _fa7 jenckjegfhgblglbfmfgplmabmkcgbbfighp2 = components[j];
                        bool flag4 = jenckjegfhgblglbfmfgplmabmkcgbbfighp2.IsEnabled();
                        if (flag4)
                        {
                            jenckjegfhgblglbfmfgplmabmkcgbbfighp2.Layout(gameObject, objectList, ref rect);
                            bool flag5 = trim && minX > rect.x;
                            if (flag5)
                            {
                                rect.Set(curRect.x - 7f, curRect.y, 7f, 16f);
                                GUI.DrawTexture(rect, this.NLCDGBGNEMBJDHIGBNMEMGIDLJNPJFBMICHG);
                                break;
                            }
                            jenckjegfhgblglbfmfgplmabmkcgbbfighp2.EventHandler(gameObject, objectList, Event.current, rect);
                            curRect.Set(rect.x, rect.y, rect.width, rect.height);
                        }
                        j++;
                    }
                }
            }
        }

        // Token: 0x040007B1 RID: 1969
        private HashSet<int> IAGDKCPKIBMBEACBIIPEEPAJMDMHOJJHOBHH = new HashSet<int>();

        // Token: 0x040007B2 RID: 1970
        private Dictionary<int, _fa7> DMLKICHGPPIDCDIDILFNJJCJOALJJGAFHOME;

        // Token: 0x040007B3 RID: 1971
        private List<_fa7> MGIAPPIPBKEJIAGCDDEFMBNAOJJMJJBIJHAH;

        // Token: 0x040007B4 RID: 1972
        private List<_fa7> AKHDBNNHIFJLFHKFHOPLGHOEMNIIMBEIJAPJ;

        // Token: 0x040007B5 RID: 1973
        private bool FGJEFJGDONJJLLCILFFGACDGHLFDEBGJAKED;

        // Token: 0x040007B6 RID: 1974
        private int NJHFKMIPEIJKGFLDDKFEEPDBAKHJOJFPAFJC;

        // Token: 0x040007B7 RID: 1975
        private Texture2D NLCDGBGNEMBJDHIGBNMEMGIDLJNPJFBMICHG;

        // Token: 0x040007B8 RID: 1976
        internal Rect HLEPHLDNDOHCOGHEHGJEOAEKLFFODEKPKJNG = Rect.zero;

        // Token: 0x040007B9 RID: 1977
        internal static bool IGPC;
    }
}
