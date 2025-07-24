using System;
using SuperEditor.Hierarchy;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200014A RID: 330
    internal class _fb2 : _fa7
    {
        // Token: 0x06000992 RID: 2450 RVA: 0x00102154 File Offset: 0x00100354
        internal _fb2()
        {
            this.NKCO = _fa2.GetInstance().GetColor((_f8)1);
            this.OIGP = new GUIStyle();
            this.OIGP.normal.textColor = _fa2.GetInstance().GetColor((_f8)2);
            this.OIGP.fontSize = 9;
            this.OIGP.clipping = (TextClipping)1;
            this.OIGP.alignment = (TextAnchor)4;
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowChildrenCountComponent, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x06000993 RID: 2451 RVA: 0x001021E9 File Offset: 0x001003E9
        private void SettingsChanged()
        {
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowChildrenCountComponent);
        }

        // Token: 0x06000994 RID: 2452 RVA: 0x00102200 File Offset: 0x00100400
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            this.GBEO = gameObject.transform.childCount;
            bool flag = this.GBEO > _fb2.IFGG;
            if (flag)
            {
                _fb2.IFGG = this.GBEO;
                _fb2.CAFB = gameObject;
            }
            bool flag2 = _fb2.CAFB == null;
            if (flag2)
            {
                _fb2.CAFB = gameObject;
            }
            bool flag3 = _fb2.CAFB.transform.childCount != _fb2.IFGG;
            if (flag3)
            {
                _fb2.IFGG = _fb2.CAFB.transform.childCount;
            }
            float x = this.OIGP.CalcSize(new GUIContent(_fb2.IFGG.ToString())).x;
            rect.x -= x;
            rect.width = x;
        }

        // Token: 0x06000995 RID: 2453 RVA: 0x001022C4 File Offset: 0x001004C4
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            bool flag = this.GBEO > 0;
            if (flag)
            {
                GUI.Label(curRect, this.GBEO.ToString(), this.OIGP);
            }
        }

        // Token: 0x04000832 RID: 2098
        private Color NKCO;

        // Token: 0x04000833 RID: 2099
        private GUIStyle OIGP;

        // Token: 0x04000834 RID: 2100
        private int GBEO;

        // Token: 0x04000835 RID: 2101
        private static GameObject CAFB;

        // Token: 0x04000836 RID: 2102
        private static int IFGG;
    }
}
