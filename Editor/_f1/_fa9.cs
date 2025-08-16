using System;
using System.Reflection;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000142 RID: 322
    internal class _fa9 : _fa7
    {
        // Token: 0x06000966 RID: 2406 RVA: 0x001007B0 File Offset: 0x000FE9B0
        internal _fa9()
        {
            this.JIOC = typeof(EditorGUIUtility).GetMethod("GetIconForObject", BindingFlags.Static | BindingFlags.NonPublic);
            this.GGMA = new object[1];
            this.NKCO = _fa2.GetInstance().GetColor((_f8)1);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowGameObjectIcon, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x06000967 RID: 2407 RVA: 0x0010081D File Offset: 0x000FEA1D
        private void SettingsChanged()
        {
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowGameObjectIcon);
        }

        // Token: 0x06000968 RID: 2408 RVA: 0x00100831 File Offset: 0x000FEA31
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            rect.x -= 18f;
            rect.width = 18f;
        }

        // Token: 0x06000969 RID: 2409 RVA: 0x00100854 File Offset: 0x000FEA54
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect rect)
        {
            this.GGMA[0] = gameObject;
            Texture2D texture2D = (Texture2D)this.JIOC.Invoke(null, this.GGMA);
            rect.width = 16f;
            bool flag = texture2D != null;
            if (flag)
            {
                GUI.DrawTexture(rect, texture2D, ScaleMode.ScaleToFit, true);
            }
            else
            {
                bool flag2 = PrefabUtility.GetPrefabAssetType(gameObject) != PrefabAssetType.NotAPrefab;
                if (flag2)
                {
                    GUI.DrawTexture(rect, EditorGUIUtility.IconContent("Prefab icon").image, (ScaleMode)2, true);
                }
                else
                {
                    GUI.DrawTexture(rect, EditorGUIUtility.IconContent("GameObject icon").image, (ScaleMode)2, true);
                }
            }
        }

        // Token: 0x0600096A RID: 2410 RVA: 0x00100900 File Offset: 0x000FEB00
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
            bool flag = currentEvent.isMouse && currentEvent.button == 0 && curRect.Contains(currentEvent.mousePosition);
            if (flag)
            {
                currentEvent.Use();
                Type type = Assembly.Load("UnityEditor").GetType("UnityEditor.IconSelector");
                MethodInfo method = type.GetMethod("ShowAtPosition", BindingFlags.Static | BindingFlags.NonPublic, null, CallingConventions.Any, new Type[]
                {
                    typeof(UnityEngine.Object),
                    typeof(Rect),
                    typeof(bool)
                }, null);
                method.Invoke(null, new object[] { gameObject, curRect, true });
            }
        }

        // Token: 0x0400080B RID: 2059
        private MethodInfo JIOC;

        // Token: 0x0400080C RID: 2060
        private object[] GGMA;

        // Token: 0x0400080D RID: 2061
        private Color NKCO;
    }
}
