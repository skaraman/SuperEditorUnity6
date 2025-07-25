using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200014B RID: 331
    internal class _f3 : _fa7
    {
        // Token: 0x06000996 RID: 2454 RVA: 0x001022F8 File Offset: 0x001004F8
        internal _f3()
        {
            this.NKCO = _fa2.GetInstance().GetColor((_f8)1);
            this.BEALMDCDBHLDMKIHCFOMJGCHHLLCJIAPOLJO = _fa2.GetInstance().GetColor((_f8)4);
            this.PIAJEEJBAGMBEECEMOJNAHHJNLHOMFOCJNJN = _fa2.GetInstance().GetColor((_f8)3);
            this.OIGP = new GUIStyle();
            this.OIGP.normal.textColor = this.BEALMDCDBHLDMKIHCFOMJGCHHLLCJIAPOLJO;
            this.OIGP.fontSize = 8;
            this.OIGP.clipping = (TextClipping)1;
            _f5.GetInstance().AddEventListener(HierarchySetting.TagAndLayerType, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.TagAndLayerSizeValueType, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.TagAndLayerSizeValuePixel, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.TagAndLayerSizeValuePercent, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.TagAndLayerLabelSize, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowTagLayerComponent, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x06000997 RID: 2455 RVA: 0x00102418 File Offset: 0x00100618
        private void SettingsChanged()
        {
            this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH = _f5.GetInstance().Get<int>(HierarchySetting.TagAndLayerType) == 0;
            this.CFGGEHHIPPPLPLCFKAPAFBLHEPCBCFFIFMDM = _f5.GetInstance().Get<int>(HierarchySetting.TagAndLayerSizeValueType) == 0;
            this.PFBFIEHFFADJHHCDOIKOOJIAOMKDHEOJKHIK = _f5.GetInstance().Get<int>(HierarchySetting.TagAndLayerSizeValuePixel);
            this.MJBEOAFJOPNAPFPNMHPAIDBGJDNPPMDKKABA = _f5.GetInstance().Get<float>(HierarchySetting.TagAndLayerSizeValuePercent);
            this.IAMFJGJFGOOIPJMKNFKHCHPIECOPCBONELLD = (TagAndLayerLabelSize)_f5.GetInstance().Get<int>(HierarchySetting.TagAndLayerLabelSize);
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowTagLayerComponent);
        }

        // Token: 0x06000998 RID: 2456 RVA: 0x00102498 File Offset: 0x00100698
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            string tagName = this.GetTagName(gameObject);
            string layerName = this.GetLayerName(gameObject.layer);
            bool flag = tagName == "Untagged" && layerName == "Default" && _f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO == null;
            if (!flag)
            {
                bool flag2 = tagName.Length > _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA.Length;
                if (flag2)
                {
                    _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA = tagName;
                    _f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO = gameObject;
                }
                bool flag3 = layerName.Length > _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA.Length;
                if (flag3)
                {
                    _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA = layerName;
                    _f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO = gameObject;
                }
                bool flag4 = _f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO == null;
                if (flag4)
                {
                    _f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO = gameObject;
                }
                string tagName2 = this.GetTagName(_f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO);
                string layerName2 = this.GetLayerName(_f3.BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO.layer);
                bool flag5 = tagName2 != _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA && layerName2 != _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA;
                if (flag5)
                {
                    _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA = ((tagName2.Length > layerName2.Length) ? tagName2 : layerName2);
                }
                rect.width = this.OIGP.CalcSize(new GUIContent("T: " + _f3.HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA)).x;
                rect.x -= rect.width;
            }
        }

        // Token: 0x06000999 RID: 2457 RVA: 0x001025EC File Offset: 0x001007EC
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            int layer = gameObject.layer;
            string tagName = this.GetTagName(gameObject);
            bool flag = this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH || tagName != "Untagged" || layer != 0;
            if (flag)
            {
                curRect.height = 17f;
                curRect.y -= 2f;
                curRect.x += 2f;
                int num = _f5.GetInstance().Get<int>(HierarchySetting.TagAndLayerAligment);
                bool flag2 = num == 0;
                if (flag2)
                {
                    this.OIGP.alignment = 0;
                }
                else
                {
                    bool flag3 = num == 1;
                    if (flag3)
                    {
                        this.OIGP.alignment = 1;
                    }
                    else
                    {
                        bool flag4 = num == 2;
                        if (flag4)
                        {
                            this.OIGP.alignment = 2;
                        }
                    }
                }
                this.OIGP.fontSize = 8;
                bool flag5 = layer == 0 && tagName != "Untagged" && !this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH;
                if (flag5)
                {
                    curRect.y += 5f;
                    this.OIGP.normal.textColor = this.PIAJEEJBAGMBEECEMOJNAHHJNLHOMFOCJNJN;
                    EditorGUI.LabelField(curRect, "T: " + tagName, this.OIGP);
                }
                else
                {
                    bool flag6 = layer != 0 && tagName == "Untagged" && !this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH;
                    if (flag6)
                    {
                        curRect.y += 5f;
                        this.OIGP.normal.textColor = this.PIAJEEJBAGMBEECEMOJNAHHJNLHOMFOCJNJN;
                        EditorGUI.LabelField(curRect, "L: " + this.GetLayerName(layer), this.OIGP);
                    }
                    else
                    {
                        this.OIGP.normal.textColor = ((tagName == "Untagged") ? this.BEALMDCDBHLDMKIHCFOMJGCHHLLCJIAPOLJO : this.PIAJEEJBAGMBEECEMOJNAHHJNLHOMFOCJNJN);
                        EditorGUI.LabelField(curRect, "T: " + tagName, this.OIGP);
                        curRect.y += 8f;
                        this.OIGP.normal.textColor = ((layer == 0) ? this.BEALMDCDBHLDMKIHCFOMJGCHHLLCJIAPOLJO : this.PIAJEEJBAGMBEECEMOJNAHHJNLHOMFOCJNJN);
                        EditorGUI.LabelField(curRect, "L: " + this.GetLayerName(layer), this.OIGP);
                    }
                }
            }
        }

        // Token: 0x0600099A RID: 2458 RVA: 0x00102848 File Offset: 0x00100A48
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect rect)
        {
            bool flag = Event.current.isMouse && currentEvent.type == EventType.MouseDown && Event.current.button == 0 && rect.Contains(Event.current.mousePosition);
            if (flag)
            {
                int layer = gameObject.layer;
                string tagName = this.GetTagName(gameObject);
                bool flag2 = this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH || tagName != "Untagged" || layer != 0;
                if (flag2)
                {
                    Event.current.Use();
                    GameObject[] array;
                    if (!Selection.Contains(gameObject))
                    {
                        (array = new GameObject[1])[0] = gameObject;
                    }
                    else
                    {
                        array = Selection.gameObjects;
                    }
                    this.HOMD = array;
                    bool flag3 = layer == 0 && tagName != "Untagged" && !this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH;
                    if (flag3)
                    {
                        this.ShowTagsContextMenu(tagName);
                    }
                    else
                    {
                        bool flag4 = layer != 0 && tagName == "Untagged" && !this.CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH;
                        if (flag4)
                        {
                            this.ShowLayersContextMenu(LayerMask.LayerToName(layer));
                        }
                        else
                        {
                            bool flag5 = Event.current.mousePosition.y < rect.y + rect.height / 2f;
                            if (flag5)
                            {
                                this.ShowTagsContextMenu(tagName);
                            }
                            else
                            {
                                this.ShowLayersContextMenu(LayerMask.LayerToName(layer));
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600099B RID: 2459 RVA: 0x001029A0 File Offset: 0x00100BA0
        private string GetTagName(GameObject gameObject)
        {
            string text = "Undefined";
            try
            {
                text = gameObject.tag;
            }
            catch
            {
            }
            return text;
        }

        // Token: 0x0600099C RID: 2460 RVA: 0x001029DC File Offset: 0x00100BDC
        private string GetLayerName(int layer)
        {
            string text = LayerMask.LayerToName(layer);
            bool flag = text.Equals("");
            if (flag)
            {
                text = "Undefined";
            }
            return text;
        }

        // Token: 0x0600099D RID: 2461 RVA: 0x00102A0C File Offset: 0x00100C0C
        private void ShowTagsContextMenu(string tag)
        {
            List<string> list = new List<string>(InternalEditorUtility.tags);
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Untagged"), false, new GenericMenu.MenuFunction2(this.TagChangedHandler), "Untagged");
            int i = 0;
            int count = list.Count;
            while (i < count)
            {
                string text = list[i];
                genericMenu.AddItem(new GUIContent(text), tag == text, new GenericMenu.MenuFunction2(this.TagChangedHandler), text);
                i++;
            }
            genericMenu.AddSeparator("");
            genericMenu.AddItem(new GUIContent("Add Tag..."), false, new GenericMenu.MenuFunction2(this.AddTagOrLayerHandler), "Tags");
            genericMenu.ShowAsContext();
        }

        // Token: 0x0600099E RID: 2462 RVA: 0x00102ACC File Offset: 0x00100CCC
        private void ShowLayersContextMenu(string layer)
        {
            List<string> list = new List<string>(InternalEditorUtility.layers);
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Default"), false, new GenericMenu.MenuFunction2(this.LayerChangedHandler), "Default");
            int i = 0;
            int count = list.Count;
            while (i < count)
            {
                string text = list[i];
                genericMenu.AddItem(new GUIContent(text), layer == text, new GenericMenu.MenuFunction2(this.LayerChangedHandler), text);
                i++;
            }
            genericMenu.AddSeparator("");
            genericMenu.AddItem(new GUIContent("Add Layer..."), false, new GenericMenu.MenuFunction2(this.AddTagOrLayerHandler), "Layers");
            genericMenu.ShowAsContext();
        }

        // Token: 0x0600099F RID: 2463 RVA: 0x00102B8C File Offset: 0x00100D8C
        private void TagChangedHandler(object newTag)
        {
            for (int i = this.HOMD.Length - 1; i >= 0; i--)
            {
                GameObject gameObject = this.HOMD[i];
                Undo.RecordObject(gameObject, "Change Tag");
                gameObject.tag = (string)newTag;
                EditorUtility.SetDirty(gameObject);
            }
        }

        // Token: 0x060009A0 RID: 2464 RVA: 0x00102BE4 File Offset: 0x00100DE4
        private void LayerChangedHandler(object newLayer)
        {
            int num = LayerMask.NameToLayer((string)newLayer);
            for (int i = this.HOMD.Length - 1; i >= 0; i--)
            {
                GameObject gameObject = this.HOMD[i];
                Undo.RecordObject(gameObject, "Change Layer");
                gameObject.layer = num;
                EditorUtility.SetDirty(gameObject);
            }
        }

        // Token: 0x060009A1 RID: 2465 RVA: 0x00102C40 File Offset: 0x00100E40
        private void AddTagOrLayerHandler(object value)
        {
            PropertyInfo property = typeof(EditorApplication).GetProperty("tagManager", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty);
            UnityEngine.Object @object = (UnityEngine.Object)property.GetValue(null, null);
            @object.GetType().GetField("m_DefaultExpandedFoldout").SetValue(@object, value);
            Selection.activeObject = @object;
        }

        // Token: 0x04000837 RID: 2103
        private GUIStyle OIGP;

        // Token: 0x04000838 RID: 2104
        private Color PIAJEEJBAGMBEECEMOJNAHHJNLHOMFOCJNJN;

        // Token: 0x04000839 RID: 2105
        private Color BEALMDCDBHLDMKIHCFOMJGCHHLLCJIAPOLJO;

        // Token: 0x0400083A RID: 2106
        private Color NKCO;

        // Token: 0x0400083B RID: 2107
        private bool CGEAEHAOPNLHEMHNPHAPAAPNOLHDIMIPIFBH;

        // Token: 0x0400083C RID: 2108
        private bool CFGGEHHIPPPLPLCFKAPAFBLHEPCBCFFIFMDM;

        // Token: 0x0400083D RID: 2109
        private int PFBFIEHFFADJHHCDOIKOOJIAOMKDHEOJKHIK;

        // Token: 0x0400083E RID: 2110
        private float MJBEOAFJOPNAPFPNMHPAIDBGJDNPPMDKKABA;

        // Token: 0x0400083F RID: 2111
        private GameObject[] HOMD;

        // Token: 0x04000840 RID: 2112
        private TagAndLayerLabelSize IAMFJGJFGOOIPJMKNFKHCHPIECOPCBONELLD;

        // Token: 0x04000841 RID: 2113
        private static string HEJGIHBKIOGPEICKCJHMFFGCOGKDDBOEFPPA = "";

        // Token: 0x04000842 RID: 2114
        private static GameObject BCEOAOBFEGJFCDJPKPKFJPOIIGGDIBOCDPBO;
    }
}
