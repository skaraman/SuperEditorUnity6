using System;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000143 RID: 323
    internal class _f4 : _fa7
    {
        // Token: 0x0600096B RID: 2411 RVA: 0x001009C0 File Offset: 0x000FEBC0
        internal _f4()
        {
            this._yq6 = new Color(0f, 0f, 0f, 0.15f);
            this._yq7 = new Color(0f, 0f, 0f, 0.05f);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowRowShading, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowSeparatorComponent, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x0600096C RID: 2412 RVA: 0x00100A4B File Offset: 0x000FEC4B
        private void SettingsChanged()
        {
            this._yq8 = _f5.GetInstance().Get<bool>(HierarchySetting.ShowRowShading);
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowSeparatorComponent);
        }

        // Token: 0x0600096D RID: 2413 RVA: 0x00100A74 File Offset: 0x000FEC74
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            curRect.y = selectionRect.y + selectionRect.height - 1f;
            curRect.width = selectionRect.width + selectionRect.x + 16f;
            curRect.height = 1f;
            curRect.x = 0f;
            EditorGUI.DrawRect(curRect, this._yq6);
            bool flag = this._yq8 && Mathf.FloorToInt((selectionRect.y - 4f) / 16f % 2f) == 0;
            if (flag)
            {
                selectionRect.width += selectionRect.x;
                selectionRect.width += 16f;
                selectionRect.x = 0f;
                selectionRect.height -= 1f;
                EditorGUI.DrawRect(selectionRect, this._yq7);
            }
        }

        // Token: 0x0400080E RID: 2062
        private Color _yq6;

        // Token: 0x0400080F RID: 2063
        private Color _yq7;

        // Token: 0x04000810 RID: 2064
        private bool _yq8;
    }
}
