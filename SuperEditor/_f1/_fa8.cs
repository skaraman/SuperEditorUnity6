using System;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000134 RID: 308
    [InitializeOnLoad]
    internal class _fa8
    {
        // Token: 0x06000947 RID: 2375 RVA: 0x000FF3F8 File Offset: 0x000FD5F8
        static _fa8()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_fa8.Update));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_fa8.Update));
            EditorApplication.hierarchyWindowItemOnGUI = (EditorApplication.HierarchyWindowItemCallback)Delegate.Remove(EditorApplication.hierarchyWindowItemOnGUI, new EditorApplication.HierarchyWindowItemCallback(_fa8.HierarchyWindowItemOnGUIHandler));
            EditorApplication.hierarchyWindowItemOnGUI = (EditorApplication.HierarchyWindowItemCallback)Delegate.Combine(EditorApplication.hierarchyWindowItemOnGUI, new EditorApplication.HierarchyWindowItemCallback(_fa8.HierarchyWindowItemOnGUIHandler));
            EditorApplication.hierarchyChanged += (Action)_fa8.HierarchyWindowChanged;
            EditorApplication.hierarchyChanged += (Action)_fa8.HierarchyWindowChanged;
            Undo.undoRedoPerformed = (Undo.UndoRedoCallback)Delegate.Remove(Undo.undoRedoPerformed, new Undo.UndoRedoCallback(_fa8.UndoRedoPerformed));
            Undo.undoRedoPerformed = (Undo.UndoRedoCallback)Delegate.Combine(Undo.undoRedoPerformed, new Undo.UndoRedoCallback(_fa8.UndoRedoPerformed));
        }

        // Token: 0x06000948 RID: 2376 RVA: 0x000FF510 File Offset: 0x000FD710
        private static void Init()
        {
            _fa8.FGGM = new _fa1();
        }

        // Token: 0x06000949 RID: 2377 RVA: 0x000FF51D File Offset: 0x000FD71D
        private static void UndoRedoPerformed()
        {
            EditorApplication.RepaintHierarchyWindow();
        }

        // Token: 0x0600094A RID: 2378 RVA: 0x000FF528 File Offset: 0x000FD728
        private static void Update()
        {
            bool flag = _fa8.FGGM == null;
            if (flag)
            {
                _fa8.Init();
            }
            _f7.getInstance().update();
            bool igpc = _fa1.IGPC;
            if (igpc)
            {
                bool flag2 = (DateTime.Now - _fa8.IEPM).TotalMilliseconds / 1000.0 > 0.20000000298023224;
                if (flag2)
                {
                    _fa8.IEPM = DateTime.Now;
                    EditorApplication.RepaintHierarchyWindow();
                }
            }
        }

        // Token: 0x0600094B RID: 2379 RVA: 0x000FF5A0 File Offset: 0x000FD7A0
        private static void HierarchyWindowItemOnGUIHandler(int instanceId, Rect selectionRect)
        {
            bool flag = _fa8.FGGM == null;
            if (flag)
            {
                _fa8.Init();
            }
            _fa8.FGGM.HierarchyWindowItemOnGUIHandler(instanceId, selectionRect);
        }

        // Token: 0x0600094C RID: 2380 RVA: 0x000FF5D0 File Offset: 0x000FD7D0
        private static void HierarchyWindowChanged()
        {
            bool flag = _fa8.FGGM == null;
            if (flag)
            {
                _fa8.Init();
            }
            _f7.getInstance().validate();
        }

        // Token: 0x040007AF RID: 1967
        private static _fa1 FGGM;

        // Token: 0x040007B0 RID: 1968
        internal static DateTime IEPM = DateTime.Now;
    }
}
