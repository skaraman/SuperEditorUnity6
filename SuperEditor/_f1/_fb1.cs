using System;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200014E RID: 334
    internal class _fb1 : _fa7
    {
        // Token: 0x060009AF RID: 2479 RVA: 0x001032A4 File Offset: 0x001014A4
        internal _fb1()
        {
            this.ILLN = _fa2.GetInstance().GetTexture((_f2)20);
            this.OEOO = _fa2.GetInstance().GetTexture((_f2)18);
            this.PPMK = _fa2.GetInstance().GetTexture((_f2)19);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowStaticComponent, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x060009B0 RID: 2480 RVA: 0x0010330F File Offset: 0x0010150F
        private void SettingsChanged()
        {
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowStaticComponent);
        }

        // Token: 0x060009B1 RID: 2481 RVA: 0x00103324 File Offset: 0x00101524
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            rect.x -= 16f;
            rect.width = 16f;
            this.CKCH = GameObjectUtility.GetStaticEditorFlags(gameObject);
        }

        // Token: 0x060009B2 RID: 2482 RVA: 0x00103354 File Offset: 0x00101554
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            GUI.DrawTexture(curRect, gameObject.isStatic ? (((int)this.CKCH == -1) ? this.ILLN : this.OEOO) : this.PPMK);
        }

        // Token: 0x060009B3 RID: 2483 RVA: 0x00103394 File Offset: 0x00101594
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
            bool flag = currentEvent.isMouse && currentEvent.button == 0 && curRect.Contains(currentEvent.mousePosition);
            if (flag)
            {
                currentEvent.Use();
                int ckch = (int)this.CKCH;
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
                GenericMenu genericMenu = new GenericMenu();
                genericMenu.AddItem(new GUIContent("Nothing"), ckch == 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 0);
                genericMenu.AddItem(new GUIContent("Everything"), ckch == -1, new GenericMenu.MenuFunction2(this.staticChangeHandler), -1);
                genericMenu.AddItem(new GUIContent("Lightmap Static"), (ckch & 1) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 1);
                genericMenu.AddItem(new GUIContent("Occluder Static"), (ckch & 2) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 2);
                genericMenu.AddItem(new GUIContent("Batching Static"), (ckch & 4) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 4);
                genericMenu.AddItem(new GUIContent("Navigation Static"), (ckch & 8) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 8);
                genericMenu.AddItem(new GUIContent("Occludee Static"), (ckch & 16) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 16);
                genericMenu.AddItem(new GUIContent("Off Mesh Link Generation"), (ckch & 32) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 32);
                genericMenu.AddItem(new GUIContent("Reflection Probe Static"), (ckch & 64) > 0, new GenericMenu.MenuFunction2(this.staticChangeHandler), 64);
                genericMenu.ShowAsContext();
            }
        }

        // Token: 0x060009B4 RID: 2484 RVA: 0x00103580 File Offset: 0x00101780
        private void staticChangeHandler(object result)
        {
            StaticEditorFlags staticEditorFlags = (StaticEditorFlags)result;
            for (int i = this.HOMD.Length - 1; i >= 0; i--)
            {
                GameObject gameObject = this.HOMD[i];
                Undo.RecordObject(gameObject, "Change Static Flags");
                GameObjectUtility.SetStaticEditorFlags(gameObject, staticEditorFlags);
                EditorUtility.SetDirty(gameObject);
            }
        }

        // Token: 0x0400084B RID: 2123
        private Texture2D ILLN;

        // Token: 0x0400084C RID: 2124
        private Texture2D PPMK;

        // Token: 0x0400084D RID: 2125
        private Texture2D OEOO;

        // Token: 0x0400084E RID: 2126
        private StaticEditorFlags CKCH;

        // Token: 0x0400084F RID: 2127
        private GameObject[] HOMD;
    }
}
