using System;
using System.Linq;
using System.Reflection;
using AHO;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000147 RID: 327
    internal class _fa5 : _fa7
    {
        // Token: 0x06000982 RID: 2434 RVA: 0x00101A98 File Offset: 0x000FFC98
        internal _fa5()
        {
            this.NKCO = _fa2.GetInstance().GetColor((_f8)1);
            this.AAOE = _fa2.GetInstance().GetColor((_f8)0);
            this.FMNE = _fa2.GetInstance().GetColor((_f8)2);
            this.KIMO = _fa2.GetInstance().GetTexture((_f2)6);
            this.IOMN = new GUIStyle();
            this.IOMN.normal.textColor = this.FMNE;
            this.IOMN.fontSize = 11;
            this.IOMN.clipping = (TextClipping)1;
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowComponents, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x06000983 RID: 2435 RVA: 0x00101B4D File Offset: 0x000FFD4D
        private void SettingsChanged()
        {
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowComponents);
            this.KDEA = _f5.GetInstance().Get<bool>(HierarchySetting.LeftclickEnableComponent);
        }

        // Token: 0x06000984 RID: 2436 RVA: 0x00101B74 File Offset: 0x000FFD74
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect curRect)
        {
            this.OPLK = gameObject.GetComponents<Component>();
            int num = 2 + 16 * (this.OPLK.Length - 1);
            curRect.x -= (float)num;
            curRect.width = (float)num;
        }

        // Token: 0x06000985 RID: 2437 RVA: 0x00101BB8 File Offset: 0x000FFDB8
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            curRect.width = 16f;
            int i = 0;
            int num = this.OPLK.Length;
            while (i < num)
            {
                Component component = this.OPLK[i];
                bool flag = component is Transform;
                if (!flag)
                {
                    GUIContent guicontent = EditorGUIUtility.ObjectContent(component, null);
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
                    GUI.DrawTexture(curRect, (guicontent.image == null) ? this.KIMO : guicontent.image);
                    color.a = 1f;
                    GUI.color = color;
                    bool flag3 = curRect.Contains(Event.current.mousePosition);
                    if (flag3)
                    {
                        string text = "Missing script";
                        bool flag4 = component != null;
                        if (flag4)
                        {
                            text = component.GetType().Name;
                        }
                        int num2 = Mathf.CeilToInt(this.IOMN.CalcSize(new GUIContent(text)).x);
                        selectionRect.x = curRect.x - (float)(num2 / 2) - 4f;
                        selectionRect.width = (float)(num2 + 8);
                        selectionRect.height -= 1f;
                        bool flag5 = selectionRect.y < 16f;
                        if (flag5)
                        {
                            selectionRect.x -= (float)num2;
                        }
                        else
                        {
                            selectionRect.y -= 16f;
                        }
                        EditorGUI.DrawRect(selectionRect, this.NKCO);
                        EditorGUI.DrawRect(selectionRect, this.AAOE);
                        selectionRect.x += 4f;
                        selectionRect.y += 1f;
                        GUI.Label(selectionRect, text, this.IOMN);
                        EditorApplication.RepaintHierarchyWindow();
                    }
                    curRect.x += 16f;
                }
                i++;
            }
        }

        // Token: 0x06000986 RID: 2438 RVA: 0x00101DFC File Offset: 0x000FFFFC
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
            bool flag = curRect.Contains(currentEvent.mousePosition) && currentEvent.isMouse;
            if (flag)
            {
                int num = Mathf.FloorToInt((currentEvent.mousePosition.x - curRect.x) / 16f) + 1;
                bool flag2 = currentEvent.button == 0;
                if (flag2)
                {
                    bool flag3 = this.KDEA && currentEvent.type == 0;
                    if (flag3)
                    {
                        try
                        {
                            PropertyInfo property = this.OPLK[num].GetType().GetProperty("enabled");
                            bool flag4 = (bool)property.GetGetMethod().Invoke(this.OPLK[num], null);
                            Undo.RecordObject(this.OPLK[num], flag4 ? "Disable Component" : "Enable Component");
                            property.GetSetMethod().Invoke(this.OPLK[num], new object[] { !flag4 });
                        }
                        catch
                        {
                        }
                        EditorUtility.SetDirty(gameObject);
                    }
                    else
                    {
                        bool flag5 = !this.KDEA;
                        if (flag5)
                        {
                            try
                            {
                                MonoScript monoScript = MonoScript.FromMonoBehaviour(this.OPLK[num] as MonoBehaviour);
                                bool flag6 = monoScript != null;
                                if (flag6)
                                {
                                    string assetPath = AssetDatabase.GetAssetPath(monoScript);
                                    string text = AssetDatabase.AssetPathToGUID(assetPath);
                                    bool flag7 = (!string.IsNullOrEmpty(assetPath) && assetPath.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase)) || (assetPath.StartsWith("Packages/", StringComparison.OrdinalIgnoreCase) && !assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase));
                                    if (flag7)
                                    {
                                        _bb6.OpenAssetInTab(text, !_bg8.EAIK.GNIO());
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    currentEvent.Use();
                }
                else
                {
                    bool flag8 = currentEvent.button == 1;
                    if (flag8)
                    {
                        MethodInfo methodInfo = typeof(EditorUtility).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).Single((MethodInfo method) => method.Name == "DisplayObjectContextMenu" && method.GetParameters()[1].ParameterType == typeof(Object));
                        Undo.RecordObject(this.OPLK[num], "Remove Component");
                        methodInfo.Invoke(null, new object[]
                        {
                            curRect,
                            this.OPLK[num],
                            0
                        });
                        currentEvent.Use();
                    }
                }
            }
        }

        // Token: 0x04000827 RID: 2087
        private GUIStyle IOMN;

        // Token: 0x04000828 RID: 2088
        private Color FMNE;

        // Token: 0x04000829 RID: 2089
        private Color NKCO;

        // Token: 0x0400082A RID: 2090
        private Color AAOE;

        // Token: 0x0400082B RID: 2091
        private Texture2D KIMO;

        // Token: 0x0400082C RID: 2092
        private Component[] OPLK;

        // Token: 0x0400082D RID: 2093
        private bool KDEA;

        // Token: 0x0400082E RID: 2094
        private static Action<Rect, Object, int> FDJJ;
    }
}
