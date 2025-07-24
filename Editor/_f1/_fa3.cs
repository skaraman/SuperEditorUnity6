using System;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200014C RID: 332
    internal class _fa3 : _fa7
    {
        // Token: 0x060009A3 RID: 2467 RVA: 0x00102CA4 File Offset: 0x00100EA4
        internal _fa3()
        {
            this.PABN = _fa2.GetInstance().GetTexture((_f2)13);
            this.MOJO = _fa2.GetInstance().GetTexture((_f2)14);
            this.NKCO = _fa2.GetInstance().GetColor((_f8)1);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowBreakedPrefabsOnly, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowPrefabComponent, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x060009A4 RID: 2468 RVA: 0x00102D27 File Offset: 0x00100F27
        private void SettingsChanged()
        {
            this.KADK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowBreakedPrefabsOnly);
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowPrefabComponent);
        }

        // Token: 0x060009A5 RID: 2469 RVA: 0x00102D4E File Offset: 0x00100F4E
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            rect.x -= 16f;
            rect.width = 16f;
        }

        // Token: 0x060009A6 RID: 2470 RVA: 0x00102D70 File Offset: 0x00100F70
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            PrefabType prefabType = PrefabUtility.GetPrefabType(gameObject);
            bool flag = (int)prefabType == 5 || (int)prefabType == 6 || (int)prefabType == 7;
            if (flag)
            {
                GUI.DrawTexture(curRect, this.MOJO);
            }
            else
            {
                bool flag2 = !this.KADK && prefabType > 0;
                if (flag2)
                {
                    GUI.DrawTexture(curRect, this.PABN);
                }
            }
        }

        // Token: 0x04000843 RID: 2115
        private Texture2D PABN;

        // Token: 0x04000844 RID: 2116
        private Texture2D MOJO;

        // Token: 0x04000845 RID: 2117
        private Color NKCO;

        // Token: 0x04000846 RID: 2118
        private bool KADK;
    }
}
