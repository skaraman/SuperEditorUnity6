using System;
using System.Collections.Generic;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000149 RID: 329
    internal class _fa7
    {
        // Token: 0x0600098A RID: 2442 RVA: 0x001020B7 File Offset: 0x001002B7
        internal _fa7()
        {
        }

        // Token: 0x0600098B RID: 2443 RVA: 0x00014488 File Offset: 0x00012688
        internal virtual void Layout(GameObject gameObject, _fb5 objectList, ref Rect curRect)
        {
        }

        // Token: 0x0600098C RID: 2444 RVA: 0x00014488 File Offset: 0x00012688
        internal virtual void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
        }

        // Token: 0x0600098D RID: 2445 RVA: 0x00014488 File Offset: 0x00012688
        internal virtual void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
        }

        // Token: 0x0600098E RID: 2446 RVA: 0x00014488 File Offset: 0x00012688
        internal virtual void DisabledHandler(GameObject gameObject, _fb5 objectList)
        {
        }

        // Token: 0x0600098F RID: 2447 RVA: 0x001020C8 File Offset: 0x001002C8
        internal virtual void SetEnabled(bool value)
        {
            this.HHIK = value;
        }

        // Token: 0x06000990 RID: 2448 RVA: 0x001020D4 File Offset: 0x001002D4
        internal virtual bool IsEnabled()
        {
            bool flag = !this.HHIK;
            return !flag;
        }

        // Token: 0x06000991 RID: 2449 RVA: 0x001020F8 File Offset: 0x001002F8
        protected void GetGameObjectListRecursive(GameObject gameObject, ref List<GameObject> result, int maxDepth = 2147483647)
        {
            result.Add(gameObject);
            bool flag = maxDepth > 0;
            if (flag)
            {
                Transform transform = gameObject.transform;
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    this.GetGameObjectListRecursive(transform.GetChild(i).gameObject, ref result, maxDepth - 1);
                }
            }
        }

        // Token: 0x04000831 RID: 2097
        protected bool HHIK = false;
    }
}
