using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditorInternal;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200000E RID: 14
    [InitializeOnLoad]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class _bb6 : EditorWindow, IHasCustomMenu
    {
        // Token: 0x0600004E RID: 78 RVA: 0x000053F4 File Offset: 0x000035F4
        internal string LPDN()
        {
            return this._AJX;
        }

        // Token: 0x0600004F RID: 79 RVA: 0x0000540C File Offset: 0x0000360C
        internal _bi2 _AJY()
        {
            return this._AEK;
        }

        // Token: 0x06000050 RID: 80 RVA: 0x00005424 File Offset: 0x00003624
        internal static HashSet<_bb6> _AJZ()
        {
            return _bb6._AKA;
        }

        // Token: 0x06000051 RID: 81 RVA: 0x0000543C File Offset: 0x0000363C
        static _bb6()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.InitOnLoad));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.InitOnLoad));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.EditorUpdateCheckUndocked));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.EditorUpdateCheckUndocked));
        }

        // Token: 0x06000052 RID: 82 RVA: 0x000054EC File Offset: 0x000036EC
        private static void EditorUpdateCheckUndocked()
        {
            bool flag = _bb6._AKA.Count == 0;
            if (!flag)
            {
                foreach (_bb6 _AKB in _bb6._AKA)
                {
                    bool flag2 = !_AKB._AKC;
                    if (flag2)
                    {
                        _bb6._AKD = true;
                        break;
                    }
                    bool flag3 = _AKB._AKC && _AKB.titleContent.text.StartsWith("^");
                    if (flag3)
                    {
                        _AKB.titleContent.text = _AKB._AKE + "\u00a0";
                    }
                    _bb6._AKD = false;
                }
            }
        }

        // Token: 0x06000053 RID: 83 RVA: 0x000055B4 File Offset: 0x000037B4
        internal static bool CanClickOpen(UnityEngine.Object obj)
        {
            string assetPath = AssetDatabase.GetAssetPath(obj);
            bool flag = assetPath == string.Empty;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                UnityEngine.Object @object = AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript)) as MonoScript;
                bool flag3 = @object == null;
                if (flag3)
                {
                    @object = AssetDatabase.LoadAssetAtPath(assetPath, typeof(TextAsset)) as TextAsset;
                }
                bool flag4 = @object == null;
                if (flag4)
                {
                    @object = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Shader)) as Shader;
                }
                bool flag5 = @object == null;
                flag2 = !flag5;
            }
            return flag2;
        }

        // Token: 0x06000054 RID: 84 RVA: 0x00005650 File Offset: 0x00003850
        private static void LoadPrefs()
        {
            _bb6._AKF = true;
            string @string = EditorPrefs.GetString("SuperEditorRecentGUIDs", "");
            List<string> _AKG = _bb6._AKH;
            _bb6._AKH = @string.Split(new char[] { ';' }, 50, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            int count = _AKG.Count;
            while (count-- > 0)
            {
                _bb6.AddMostRecentGuidHistory(_AKG[count]);
            }
            _bb6._AKI = EditorPrefs.GetString("SuperEditorDefaultDockNextTo", "");
            bool flag = _bb6._AKI == "";
            if (flag)
            {
                _bb6._AKI = null;
            }
            _bb6._AKJ = new Rect(EditorPrefs.GetFloat("SuperEditorDefaultPositionX", 100f), EditorPrefs.GetFloat("SuperEditorDefaultPositionY", 100f), Mathf.Max(400f, EditorPrefs.GetFloat("SuperEditorDefaultPositionW", 600f)), Mathf.Max(100f, EditorPrefs.GetFloat("SuperEditorDefaultPositionH", 380f)));
        }

        // Token: 0x06000055 RID: 85 RVA: 0x00005744 File Offset: 0x00003944
        private static void InitOnLoad()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.InitOnLoad));
            EditorApplication.projectWindowItemOnGUI = (EditorApplication.ProjectWindowItemCallback)Delegate.Remove(EditorApplication.projectWindowItemOnGUI, new EditorApplication.ProjectWindowItemCallback(_bb6.OnProjectItemGUI));
            EditorApplication.projectWindowItemOnGUI = (EditorApplication.ProjectWindowItemCallback)Delegate.Combine(EditorApplication.projectWindowItemOnGUI, new EditorApplication.ProjectWindowItemCallback(_bb6.OnProjectItemGUI));
            bool flag = !_bb6._AKF;
            if (flag)
            {
                _bb6.LoadPrefs();
            }
        }

        // Token: 0x06000056 RID: 86 RVA: 0x000057C4 File Offset: 0x000039C4
        [MenuItem("CONTEXT/MonoBehaviour/Edit this Editor class", false, 611)]
        private static void OpenEditorScript(MenuCommand mc)
        {
            Component target = mc.context as Component;
            bool flag = target == null;
            if (!flag)
            {
                Editor editor = ActiveEditorTracker.sharedTracker.activeEditors.FirstOrDefault((Editor x) => x.target == target);
                bool flag2 = editor == null;
                if (!flag2)
                {
                    MonoScript monoScript = MonoScript.FromScriptableObject(editor);
                    bool flag3 = monoScript == null;
                    if (!flag3)
                    {
                        string assetPath = AssetDatabase.GetAssetPath(monoScript);
                        bool flag4 = string.IsNullOrEmpty(assetPath);
                        if (!flag4)
                        {
                            bool flag5 = assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || assetPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                            if (!flag5)
                            {
                                _bb6._AKK = true;
                                _bb6.OpenAssetInTab(AssetDatabase.AssetPathToGUID(assetPath));
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000057 RID: 87 RVA: 0x00005890 File Offset: 0x00003A90
        [MenuItem("CONTEXT/MonoBehaviour/Edit this Editor class", true, 611)]
        private static bool CanOpenEditorScript(MenuCommand mc)
        {
            Component target = mc.context as Component;
            bool flag = target == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                Editor editor = ActiveEditorTracker.sharedTracker.activeEditors.FirstOrDefault((Editor x) => x.target == target);
                bool flag3 = editor == null;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    MonoScript monoScript = MonoScript.FromScriptableObject(editor);
                    bool flag4 = monoScript == null;
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        string assetPath = AssetDatabase.GetAssetPath(monoScript);
                        bool flag5 = string.IsNullOrEmpty(assetPath);
                        if (flag5)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            bool flag6 = assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || assetPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                            flag2 = !flag6;
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000058 RID: 88 RVA: 0x00005960 File Offset: 0x00003B60
        [MenuItem("Assets/Create/Text", false, 90)]
        internal static void CreateTextAsset()
        {
            string text = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            bool flag = !AssetDatabase.Contains(Selection.activeInstanceID);
            if (flag)
            {
                text = "Assets";
            }
            bool flag2 = !Directory.Exists(text);
            if (flag2)
            {
                text = Path.GetDirectoryName(text);
            }
            text = Path.Combine(text, "New Text.txt");
            text = AssetDatabase.GenerateUniqueAssetPath(text);
            StreamWriter streamWriter = File.CreateText(text);
            streamWriter.Close();
            streamWriter.Dispose();
            AssetDatabase.ImportAsset(text);
            Selection.activeObject = AssetDatabase.LoadAssetAtPath(text, typeof(TextAsset));
        }

        // Token: 0x06000059 RID: 89 RVA: 0x000059EC File Offset: 0x00003BEC
        internal static void RepaintAllWindows()
        {
            foreach (_bb6 _AKB in _bb6._AKA)
            {
                bool flag = _AKB;
                if (flag)
                {
                    _AKB.Repaint();
                }
            }
        }

        // Token: 0x0600005A RID: 90 RVA: 0x00005A4C File Offset: 0x00003C4C
        [OnOpenAsset(0)]
        internal static bool OnOpenAsset(int instanceID, int line)
        {
            bool flag = Event.current != null && (int)Event.current.keyCode != 274;
            bool flag2 = _bb6._AKL || ((flag && EditorGUI.actionKey) ? _bg8._AKM : _bg8._AKN);
            bool flag3;
            if (flag2)
            {
                _bb6._AKL = false;
                flag3 = false;
            }
            else
            {
                bool flag4 = ((flag && EditorGUI.actionKey) ? _bg8._AKN : _bg8._AKM);
                if (flag4)
                {
                    UnityEngine.Object @object = EditorUtility.InstanceIDToObject(instanceID);
                    bool flag5 = @object is MonoScript || @object is TextAsset || @object is Shader;
                    if (flag5)
                    {
                        string assetPath = AssetDatabase.GetAssetPath(instanceID);
                        bool flag6 = assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || assetPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                        if (flag6)
                        {
                            return false;
                        }
                        string text = AssetDatabase.AssetPathToGUID(assetPath);
                        _bb6._AKK = true;
                        _bb6.OpenAssetInTab(text, line);
                        return true;
                    }
                }
                flag3 = false;
            }
            return flag3;
        }

        // Token: 0x0600005B RID: 91 RVA: 0x00005B54 File Offset: 0x00003D54
        private static void OnProjectItemGUI(string item, Rect selectionRect)
        {
            bool flag = _bg8._AKM;
            bool flag2 = _bg8._AKN;
            bool flag3 = string.IsNullOrEmpty(item);
            if (!flag3)
            {
                bool isMouse = Event.current.isMouse;
                if (isMouse)
                {
                    bool flag4 = Event.current.button != 0;
                    if (!flag4)
                    {
                        bool flag5 = selectionRect.height < 20f;
                        if (flag5)
                        {
                            selectionRect.xMin = 0f;
                        }
                        bool flag6 = !selectionRect.Contains(Event.current.mousePosition);
                        if (!flag6)
                        {
                            string text = AssetDatabase.GUIDToAssetPath(item);
                            bool flag7 = text.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || text.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                            if (!flag7)
                            {
                                bool actionKey = EditorGUI.actionKey;
                                bool flag8 = !text.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) && !text.EndsWith(".js", StringComparison.OrdinalIgnoreCase);
                                if (flag8)
                                {
                                    Shader shader = null;
                                    TextAsset textAsset = AssetDatabase.LoadAssetAtPath(text, typeof(TextAsset)) as TextAsset;
                                    bool flag9 = textAsset == null;
                                    if (flag9)
                                    {
                                        shader = AssetDatabase.LoadAssetAtPath(text, typeof(Shader)) as Shader;
                                    }
                                    bool flag10 = shader == null && textAsset == null;
                                    if (!flag10)
                                    {
                                        bool flag11 = actionKey;
                                        if (flag11)
                                        {
                                            Selection.objects = new UnityEngine.Object[] { (UnityEngine.Object)(textAsset ?? (UnityEngine.Object)shader) };
                                        }

                                        bool flag12 = !flag2 && (flag || _bg8._AKO);
                                        bool flag13 = !flag2 && (flag || _bg8._AKP);
                                        if (!flag2)
                                        {
                                            bool flag14 = flag || _bg8._AKO;
                                        }
                                        if (!flag2)
                                        {
                                            bool flag15 = flag || _bg8._AKO;
                                        }
                                        bool flag16 = (textAsset != null && flag12 != actionKey) || (shader != null && flag13 != actionKey);
                                        if (flag16)
                                        {
                                            bool flag17 = Event.current.clickCount == 1 && _bg8.EAIK.GNIO() && !Event.current.shift;
                                            if (flag17)
                                            {
                                                foreach (_bb6 _AKB in _bb6._AKA)
                                                {
                                                    bool flag18 = _AKB && _AKB._AEK._AKQ() == item && !_AKB._AKC;
                                                    if (flag18)
                                                    {
                                                        _AKB.Focus();
                                                        _AKB.Show();
                                                        EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.ProjectBrowser")).Focus();
                                                        return;
                                                    }
                                                }
                                                _bb6.OpenAssetInTab(item, false);
                                                EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.ProjectBrowser")).Focus();
                                            }
                                            else
                                            {
                                                bool flag19 = Event.current.clickCount == 2;
                                                if (flag19)
                                                {
                                                    for (; ; )
                                                    {
                                                    IL_0336:
                                                        foreach (_bb6 _AKB2 in _bb6._AKA)
                                                        {
                                                            bool flag20 = !_AKB2._AKC && _bg8.EAIK.GNIO();
                                                            if (flag20)
                                                            {
                                                                _bb6._AKA.Remove(_AKB2);
                                                                try
                                                                {
                                                                    _AKB2.Close();
                                                                }
                                                                catch
                                                                {
                                                                }
                                                                goto IL_0336;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    Event.current.Use();
                                                    _bb6.OpenAssetInTab(item);
                                                    GUIUtility.ExitGUI();
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MonoScript monoScript = AssetDatabase.LoadAssetAtPath(text, typeof(MonoScript)) as MonoScript;
                                    bool flag21 = monoScript != null;
                                    if (flag21)
                                    {
                                        bool flag22 = actionKey;
                                        if (flag22)
                                        {
                                            Selection.objects = new UnityEngine.Object[] { monoScript };
                                        }
                                        bool flag23 = !flag2 && (flag || _bg8._AKR);
                                        bool flag24 = flag23 == actionKey;
                                        if (!flag24)
                                        {
                                            bool flag25 = Event.current.clickCount == 1 && _bg8.EAIK.GNIO() && !Event.current.shift;
                                            if (flag25)
                                            {
                                                foreach (_bb6 _AKB3 in _bb6._AKA)
                                                {
                                                    bool flag26 = _AKB3 && _AKB3._AEK._AKQ() == item && !_AKB3._AKC;
                                                    if (flag26)
                                                    {
                                                        _AKB3.Focus();
                                                        _AKB3.Show();
                                                        EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.ProjectBrowser")).Focus();
                                                        return;
                                                    }
                                                }
                                                _bb6.OpenAssetInTab(item, false);
                                                EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.ProjectBrowser")).Focus();
                                            }
                                            else
                                            {
                                                bool flag27 = Event.current.clickCount == 2;
                                                if (flag27)
                                                {
                                                    Event.current.Use();
                                                    _bb6.OpenAssetInTab(item);
                                                    GUIUtility.ExitGUI();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600005C RID: 92 RVA: 0x000060F4 File Offset: 0x000042F4
        internal static _bb6 OpenAssetInTab(string guid)
        {
            return _bb6.OpenAssetInTab(guid, -1, -1, 0, true);
        }

        // Token: 0x0600005D RID: 93 RVA: 0x00006110 File Offset: 0x00004310
        internal static _bb6 OpenAssetInTab(string guid, bool isDocked)
        {
            return _bb6.OpenAssetInTab(guid, -1, -1, 0, isDocked);
        }

        // Token: 0x0600005E RID: 94 RVA: 0x0000612C File Offset: 0x0000432C
        internal static _bb6 OpenAssetInTab(string guid, int line)
        {
            return _bb6.OpenAssetInTab(guid, line, -1, 0, true);
        }

        // Token: 0x0600005F RID: 95 RVA: 0x00006148 File Offset: 0x00004348
        internal static _bb6 OpenAssetInTab(string guid, int line, int characterIndex)
        {
            return _bb6.OpenAssetInTab(guid, line, characterIndex, 0, true);
        }

        // Token: 0x06000060 RID: 96 RVA: 0x00006164 File Offset: 0x00004364
        internal static _bb6 OpenAssetInTab(string guid, int line, int characterIndex, int length, bool isDocked = true)
        {
            _bi2._AKS = false;
            for (; ; )
            {
            IL_0007:
                foreach (_bb6 _AKB in _bb6._AKA)
                {
                    bool flag = _AKB && _AKB._AKT == null;
                    if (flag)
                    {
                        _bb6._AKA.Remove(_AKB);
                        try
                        {
                            _AKB.Close();
                        }
                        catch
                        {
                        }
                        goto IL_0007;
                    }
                }
                break;
            }
            foreach (_bb6 _AKB2 in _bb6._AKA)
            {
                bool flag2 = _bg8.EAIK.GNIO() && _AKB2 && _AKB2._AEK._AKQ() == guid && _AKB2._AKC && _bb6._AKD;
                if (flag2)
                {
                    goto IL_017C;
                }
            }
            for (; ; )
            {
            IL_00F6:
                foreach (_bb6 _AKB3 in _bb6._AKA)
                {
                    bool flag3 = !_AKB3._AKC && _bg8.EAIK.GNIO() && _AKB3._AEK._AKQ() != guid;
                    if (flag3)
                    {
                        _bb6._AKA.Remove(_AKB3);
                        try
                        {
                            _AKB3.Close();
                        }
                        catch
                        {
                        }
                        goto IL_00F6;
                    }
                }
                break;
            }
        IL_017C:
            foreach (_bb6 _AKB4 in _bb6._AKA)
            {
                bool flag4 = _AKB4 && _AKB4._AEK._AKQ() == guid;
                if (flag4)
                {
                    if (isDocked)
                    {
                        _AKB4._AKC = isDocked;
                    }
                    _AKB4.Show();
                    _AKB4.Focus();
                    bool flag5 = characterIndex < 0;
                    if (flag5)
                    {
                        bool flag6 = line >= 0;
                        if (flag6)
                        {
                            _AKB4.PingLine(line);
                        }
                    }
                    else
                    {
                        bool flag7 = line >= 0;
                        if (flag7)
                        {
                            _AKB4.SetCursorPosition(line, characterIndex);
                            _AKB4._AKU = length;
                        }
                    }
                    bool _AKV = _bb6._AKK;
                    if (_AKV)
                    {
                        _AKB4._AEK.AddRecentLocation(1, false);
                    }
                    _bb6._AKK = false;
                    return _AKB4;
                }
            }
            string text = AssetDatabase.GUIDToAssetPath(guid);
            object @object = AssetDatabase.LoadAssetAtPath(text, typeof(MonoScript)) as MonoScript;
            if (@object == null) @object = AssetDatabase.LoadAssetAtPath(text, typeof(TextAsset)) as TextAsset;
            if (@object == null) @object = AssetDatabase.LoadAssetAtPath(text, typeof(Shader)) as Shader;
            if (@object == null) @object = AssetDatabase.LoadAssetAtPath(text, typeof(UnityEngine.Object));

            var mostRecentlyActive = _bb6.GetMostRecentlyActive(guid);
            _bb6 _AKB5;

            if (mostRecentlyActive != null)
                _AKB5 = _bb6.OpenNewWindow(@object, mostRecentlyActive, true);
            else
                _AKB5 = _bb6.OpenNewWindow(@object, EditorWindow.GetWindow<SceneView>(), true);

            bool flag12 = _bg8.EAIK.GNIO();
            if (flag12)
            {
                _AKB5._AKC = isDocked;
            }
            foreach (_bb6 _AKB6 in _bb6._AKA)
            {
                bool flag13 = _bg8.EAIK.GNIO();
                if (flag13)
                {
                    bool flag14 = !_AKB6._AKC;
                    if (flag14)
                    {
                        _bb6._AKD = true;
                        break;
                    }
                    _bb6._AKD = false;
                }
            }
            bool flag15 = _AKB5 != null;
            if (flag15)
            {
                bool flag16 = characterIndex < 0;
                if (flag16)
                {
                    bool flag17 = line >= 0;
                    if (flag17)
                    {
                        _AKB5.PingLine(line);
                    }
                }
                else
                {
                    bool flag18 = line >= 0;
                    if (flag18)
                    {
                        _AKB5.SetCursorPosition(line, characterIndex);
                        _AKB5._AKU = length;
                    }
                }
                bool _AKV2 = _bb6._AKK;
                if (_AKV2)
                {
                    _AKB5._AEK.AddRecentLocation(1, false);
                }
                _bb6._AKK = false;
            }
            return _AKB5;
        }

        // Token: 0x06000061 RID: 97 RVA: 0x000065E8 File Offset: 0x000047E8
        private static _bb6 OpenNewWindow(UnityEngine.Object target, EditorWindow nextTo, bool reuseExisting)
        {
            _bi2._AKS = false;
            bool flag = EditorWindow.focusedWindow && _bb6.IsMaximized(EditorWindow.focusedWindow);
            if (flag)
            {
                _bb6.ToggleMaximized(EditorWindow.focusedWindow);
            }
            _bb6.UnhideCodeWindowTabs();
            bool flag2 = reuseExisting || target == null;
            if (flag2)
            {
                bool flag3 = target == null;
                if (flag3)
                {
                    target = Selection.activeObject as MonoScript;
                }
                bool flag4 = target == null;
                if (flag4)
                {
                    target = Selection.activeObject as TextAsset;
                }
                bool flag5 = target == null;
                if (flag5)
                {
                    target = Selection.activeObject as Shader;
                }
                bool flag6 = target == null;
                if (flag6)
                {
                    return null;
                }
                string assetPath = AssetDatabase.GetAssetPath(target);
                bool flag7 = assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || assetPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                if (flag7)
                {
                    return null;
                }
                string text = AssetDatabase.AssetPathToGUID(assetPath);
                foreach (_bb6 _AKB in _bb6._AKA)
                {
                    bool flag8 = _AKB && _AKB._AJX == text;
                    if (flag8)
                    {
                        _AKB.Focus();
                        return _AKB;
                    }
                }
            }
            _bb6._AKW = target;
            _bb6 _AKB2 = ScriptableObject.CreateInstance<_bb6>();
            _bb6._AKW = null;
            bool flag9 = !_AKB2.TryDockNextToSimilarTab(nextTo);
            if (flag9)
            {
                Rect _AKX = _bb6._AKJ;
                _AKX.y += 25f;
                _AKX.height -= 3f;
                _AKB2.position = _AKX;
                _AKB2.Show();
                _AKB2.position = _AKX;
            }
            return _AKB2;
        }

        // Token: 0x06000062 RID: 98 RVA: 0x000067C4 File Offset: 0x000049C4
        private void PingLine(int line)
        {
            this._AKY = line;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.PingLineWhenLoaded));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.PingLineWhenLoaded));
        }

        // Token: 0x06000063 RID: 99 RVA: 0x0000681C File Offset: 0x00004A1C
        private void SetCursorPosition(int line, int characterIndex)
        {
            this._AKZ = line;
            this._ALA = characterIndex;
            this._AKU = 0;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.SetCursorWhenLoaded));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.SetCursorWhenLoaded));
        }

        // Token: 0x06000064 RID: 100 RVA: 0x00006880 File Offset: 0x00004A80
        private bool TryDockNextToSimilarTab(EditorWindow nextTo)
        {
            return _bb6.DockNextTo(this, nextTo);
        }

        // Token: 0x06000065 RID: 101 RVA: 0x0000689C File Offset: 0x00004A9C
        internal static bool DockNextTo(EditorWindow dockThis, EditorWindow nextTo)
        {
            bool flag = _bb6._ALB._ALC == null || _bb6._ALB._ALD == null || _bb6._ALB._ALE == null || (_bb6._ALB._ALF == null && _bb6._ALB._ALG == null);
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                Array array = _bb6._ALB._ALC.GetValue(null, null) as Array;
                bool flag3 = array == null;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    object obj = null;
                    object obj2 = null;
                    object obj3 = null;
                    bool flag4 = nextTo != null && _bb6._ALB._ALH != null;
                    if (flag4)
                    {
                        object value = _bb6._ALB._ALH.GetValue(nextTo);
                        bool flag5 = value != null && value.GetType() == _bb6._ALB._ALI;
                        if (flag5)
                        {
                            obj = value;
                        }
                    }
                    foreach (object obj4 in array)
                    {
                        bool flag6 = obj != null;
                        if (flag6)
                        {
                            break;
                        }
                        object value2 = _bb6._ALB._ALD.GetValue(obj4, null);
                        Array array2 = _bb6._ALB._ALJ.GetValue(value2, null) as Array;
                        bool flag7 = array2 == null;
                        if (!flag7)
                        {
                            foreach (object obj5 in array2)
                            {
                                bool flag8 = obj5.GetType() != _bb6._ALB._ALI;
                                if (!flag8)
                                {
                                    List<EditorWindow> list = _bb6._ALB._ALE.GetValue(obj5) as List<EditorWindow>;
                                    bool flag9 = list == null;
                                    if (!flag9)
                                    {
                                        bool flag10 = nextTo != null && list.Contains(nextTo);
                                        if (flag10)
                                        {
                                            obj = obj5;
                                            break;
                                        }
                                        bool flag11 = obj2 == null && _bb6._AKI != null;
                                        if (flag11)
                                        {
                                            bool flag12 = list.Any((EditorWindow pane) => pane.GetType().ToString() == _bb6._AKI);
                                            if (flag12)
                                            {
                                                obj2 = obj5;
                                            }
                                            bool flag13 = list.Any((EditorWindow pane) => pane is _bb6);
                                            if (flag13)
                                            {
                                                obj3 = obj5;
                                            }
                                        }
                                        bool flag14;
                                        if (obj3 == null)
                                        {
                                            flag14 = list.Any((EditorWindow pane) => pane is _bb6);
                                        }
                                        else
                                        {
                                            flag14 = false;
                                        }
                                        bool flag15 = flag14;
                                        if (flag15)
                                        {
                                            obj3 = obj5;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    object obj6;
                    if ((obj6 = obj) == null)
                    {
                        obj6 = obj3 ?? obj2;
                    }
                    object obj7 = obj6;
                    bool flag16 = obj7 == null;
                    if (flag16)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        bool flag17 = _bb6._ALB._ALF != null;
                        if (flag17)
                        {
                            _bb6._ALB._ALF.Invoke(obj7, new object[] { dockThis });
                        }
                        else
                        {
                            _bb6._ALB._ALG.Invoke(obj7, new object[] { dockThis, true });
                        }
                        flag2 = true;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000066 RID: 102 RVA: 0x00006BE0 File Offset: 0x00004DE0
        private List<EditorWindow> GetTabsInDockArea()
        {
            object obj = _bb6._ALB._ALH.GetValue(this) ?? this._ALK;
            bool flag = obj == null || obj.GetType() != _bb6._ALB._ALI;
            List<EditorWindow> list;
            if (flag)
            {
                list = null;
            }
            else
            {
                list = _bb6._ALB._ALE.GetValue(obj) as List<EditorWindow>;
            }
            return list;
        }

        // Token: 0x06000067 RID: 103 RVA: 0x00006C38 File Offset: 0x00004E38
        private _bb6 GetAdjacentCodeTab(bool right)
        {
            List<EditorWindow> tabsInDockArea = this.GetTabsInDockArea();
            bool flag = tabsInDockArea == null;
            _bb6 _AKB;
            if (flag)
            {
                _AKB = null;
            }
            else
            {
                int num = tabsInDockArea.FindIndex((EditorWindow wnd) => wnd == this);
                bool flag2 = num < 0;
                if (flag2)
                {
                    _AKB = null;
                }
                else
                {
                    if (right)
                    {
                        bool flag3 = num + 1 < tabsInDockArea.Count;
                        if (flag3)
                        {
                            num = tabsInDockArea.FindIndex(num + 1, (EditorWindow wnd) => wnd is _bb6);
                        }
                        else
                        {
                            num = -1;
                        }
                    }
                    else
                    {
                        bool flag4 = num > 0;
                        if (flag4)
                        {
                            num = tabsInDockArea.FindLastIndex(num - 1, (EditorWindow wnd) => wnd is _bb6);
                        }
                        else
                        {
                            num = -1;
                        }
                    }
                    bool flag5 = num >= 0;
                    if (flag5)
                    {
                        _AKB = tabsInDockArea[num] as _bb6;
                    }
                    else
                    {
                        _AKB = null;
                    }
                }
            }
            return _AKB;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x00006D24 File Offset: 0x00004F24
        private void SelectAdjacentCodeTab(bool right)
        {
            _bb6 adjacentCodeTab = this.GetAdjacentCodeTab(right);
            bool flag = adjacentCodeTab != null;
            if (flag)
            {
                adjacentCodeTab.Focus();
                adjacentCodeTab._AEK.AddRecentLocation(1, false);
            }
        }

        // Token: 0x06000069 RID: 105 RVA: 0x00006D5C File Offset: 0x00004F5C
        private void MoveThisTab(bool right)
        {
            object value = _bb6._ALB._ALH.GetValue(this);
            bool flag = value == null || value.GetType() != _bb6._ALB._ALI;
            if (!flag)
            {
                List<EditorWindow> list = _bb6._ALB._ALE.GetValue(value) as List<EditorWindow>;
                bool flag2 = list == null;
                if (!flag2)
                {
                    int num = list.FindIndex((EditorWindow wnd) => wnd == this);
                    bool flag3 = num < 0;
                    if (!flag3)
                    {
                        bool flag4 = right && num < list.Count - 1;
                        if (flag4)
                        {
                            list[num] = list[num + 1];
                            list[num + 1] = this;
                            base.Focus();
                            base.Repaint();
                        }
                        else
                        {
                            bool flag5 = !right && num > 0;
                            if (flag5)
                            {
                                list[num] = list[num - 1];
                                list[num - 1] = this;
                                base.Focus();
                                base.Repaint();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600006A RID: 106 RVA: 0x00006E58 File Offset: 0x00005058
        private void DestroyIfOrphaned()
        {
            _bb6.DestroyWindowIfOrphaned(this);
        }

        // Token: 0x0600006B RID: 107 RVA: 0x00006E64 File Offset: 0x00005064
        internal static bool DestroyWindowIfOrphaned(EditorWindow wnd)
        {
            UnityEngine.Object @object = _bb6._ALB._ALH.GetValue(wnd) as UnityEngine.Object;
            bool flag = !@object;
            bool flag2;
            if (flag)
            {
                UnityEngine.Object.DestroyImmediate(wnd);
                flag2 = true;
            }
            else
            {
                bool flag3 = @object.GetType() != _bb6._ALB._ALI;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    List<EditorWindow> list = _bb6._ALB._ALE.GetValue(@object) as List<EditorWindow>;
                    bool flag4 = list == null;
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        bool flag5 = !list.Contains(wnd);
                        if (flag5)
                        {
                            UnityEngine.Object.DestroyImmediate(wnd);
                            flag2 = true;
                        }
                        else
                        {
                            flag2 = false;
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00006EF8 File Offset: 0x000050F8
        private Texture2D DuplicateTexture(Texture2D source)
        {
            RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm, 1);
            Graphics.Blit(source, temporary);
            RenderTexture active = RenderTexture.active;
            RenderTexture.active = temporary;
            Texture2D texture2D = new Texture2D(source.width, source.height);
            texture2D.ReadPixels(new Rect(0f, 0f, (float)temporary.width, (float)temporary.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = active;
            RenderTexture.ReleaseTemporary(temporary);
            return texture2D;
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00006F84 File Offset: 0x00005184
        private Texture2D DuplicateTexture2(Texture2D source)
        {
            Texture2D texture2D = new Texture2D(source.width, source.height, source.format, false);
            Graphics.CopyTexture(source, 0, 0, 0, 0, texture2D.width, texture2D.height, texture2D, 0, 0, 0, 0);
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00006FD4 File Offset: 0x000051D4
        private Texture2D FlipTexture(Texture2D original, bool upSideDown = true)
        {
            Texture2D texture2D = new Texture2D(original.width, original.height);
            int width = original.width;
            int height = original.height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (upSideDown)
                    {
                        texture2D.SetPixel(j, width - i - 1, original.GetPixel(j, i));
                    }
                    else
                    {
                        texture2D.SetPixel(width - i - 1, j, original.GetPixel(i, j));
                    }
                }
            }
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00007070 File Offset: 0x00005270
        private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
        {
            Texture2D texture2D = new Texture2D(targetWidth, targetHeight, source.format, false);
            float num = 1f / (float)targetWidth;
            float num2 = 1f / (float)targetHeight;
            for (int i = 0; i < texture2D.height; i++)
            {
                for (int j = 0; j < texture2D.width; j++)
                {
                    Color pixelBilinear = source.GetPixelBilinear((float)j / (float)texture2D.width, (float)i / (float)texture2D.height);
                    texture2D.SetPixel(j, i, pixelBilinear);
                }
            }
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x06000070 RID: 112 RVA: 0x0000710C File Offset: 0x0000530C
        private Texture2D ScaleTexture2(Texture2D source, int targetWidth, int targetHeight)
        {
            Texture2D texture2D = new Texture2D(targetWidth, targetHeight, source.format, true);
            Color[] pixels = texture2D.GetPixels(0);
            float num = 1f / (float)targetWidth;
            float num2 = 1f / (float)targetHeight;
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = source.GetPixelBilinear(num * ((float)i % (float)targetWidth), num2 * Mathf.Floor((float)(i / targetWidth)));
            }
            texture2D.SetPixels(pixels, 0);
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x06000071 RID: 113 RVA: 0x00007198 File Offset: 0x00005398
        internal static string StringCheck(string withHotkey)
        {
            bool flag = withHotkey.Contains(" _") || withHotkey.Contains(" #") || withHotkey.Contains(" %") || withHotkey.Contains(" &");
            string text;
            if (flag)
            {
                text = withHotkey.Replace(" ", "\u00a0");
            }
            else
            {
                text = withHotkey;
            }
            return text;
        }

        // Token: 0x06000072 RID: 114 RVA: 0x000071F8 File Offset: 0x000053F8
        internal void OnFirstUpdate()
        {
            base.Repaint();
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnFirstUpdate));
            this._ALL = true;
            bool flag = this._AKT != null;
            if (flag)
            {
                bool flag2 = !_bb6._AKH.Contains(this._AJX);
                if (flag2)
                {
                    bool flag3 = this == EditorWindow.focusedWindow && _bb6._AKH.Count > 0;
                    if (flag3)
                    {
                        _bb6._AKH.Insert(0, this._AJX);
                    }
                    else
                    {
                        _bb6._AKH.Add(this._AJX);
                    }
                    _bb6.SaveGuidHistory();
                }
                _bb6.SaveDefaultPosition();
                string fileName = Path.GetFileName(AssetDatabase.GetAssetPath(this._AKT));
                string text = Path.GetFileNameWithoutExtension(fileName);
                this._AKE = text;
                bool flag4 = !this._AKC && _bg8.EAIK.GNIO();
                if (flag4)
                {
                    text = "^" + this._AKE;
                }
                else
                {
                    text = this._AKE + "\u00a0";
                }
                Texture2D texture2D = AssetDatabase.GetCachedIcon(AssetDatabase.GetAssetPath(this._AKT)) as Texture2D;
                base.titleContent = new GUIContent(text, texture2D, _bb6.StringCheck(AssetDatabase.GetAssetPath(this._AKT)));
            }
            else
            {
                _bb6._AKA.Remove(this);
                base.Close();
            }
            this.UpdateWindowTitle();
        }

        // Token: 0x06000073 RID: 115 RVA: 0x0000736C File Offset: 0x0000556C
        private void OnFirstRepaint()
        {
            bool flag = !this._ALL;
            if (flag)
            {
                this.OnFirstUpdate();
            }
            this._AEK.OnEnable(this._AKT);
            bool flag2 = this == EditorWindow.focusedWindow;
            if (flag2)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this._AEK._ABK().LoadImmediately));
            }
        }

        // Token: 0x06000074 RID: 116 RVA: 0x000073DC File Offset: 0x000055DC
        internal static void CheckAssetRename(string guid)
        {
            foreach (_bb6 _AKB in _bb6._AKA)
            {
                bool flag = _AKB && _AKB._AJX == guid;
                if (flag)
                {
                    bool flag2 = !_AKB._AKC && _bg8.EAIK.GNIO();
                    if (flag2)
                    {
                        _AKB.titleContent.text = "^" + _AKB._AKE;
                    }
                    else
                    {
                        _AKB.titleContent.text = _AKB._AKE + "\u00a0";
                    }
                    _AKB.UpdateWindowTitle();
                    _AKB.Repaint();
                }
            }
        }

        // Token: 0x06000075 RID: 117 RVA: 0x000074B4 File Offset: 0x000056B4
        private void PingLineWhenLoaded()
        {
            bool flag = this._AEK.CanEdit() && this._AEK._ALM.width > 0f;
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.PingLineWhenLoaded));
                this._AEK.PingLine(this._AKY);
            }
        }

        // Token: 0x06000076 RID: 118 RVA: 0x00007524 File Offset: 0x00005724
        private void SetCursorWhenLoaded()
        {
            bool flag = this._AEK.CanEdit() && this._AEK._ALM.width > 0f;
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.SetCursorWhenLoaded));
                this._AEK.SetCursorPosition(this._AKZ, this._ALA);
                bool flag2 = this._AKU > 0;
                if (flag2)
                {
                    this._AEK.PingText(this._AEK._ABH, this._AKU, _bi2._ALN);
                }
            }
        }

        // Token: 0x06000077 RID: 119 RVA: 0x000075C8 File Offset: 0x000057C8
        private void FocusNextTabOnUpdate()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.FocusNextTabOnUpdate));
            bool flag = _bb6._ALO;
            if (flag)
            {
                _bb6._ALO.Focus();
                _bb6._ALO = null;
            }
        }

        // Token: 0x06000078 RID: 120 RVA: 0x00007617 File Offset: 0x00005817
        private void OnTextBufferChanged()
        {
            this.UpdateWindowTitle();
            base.Repaint();
        }

        // Token: 0x06000079 RID: 121 RVA: 0x00007628 File Offset: 0x00005828
        internal static List<string> GetGuidHistory()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < _bb6._AKH.Count; i++)
            {
                string text = _bb6._AKH[i];
                foreach (_bb6 _AKB in _bb6._AKA)
                {
                    bool flag = _AKB && _AKB._AJX == text;
                    if (flag)
                    {
                        bool flag2 = !list.Contains(text);
                        if (flag2)
                        {
                            list.Add(text);
                        }
                        break;
                    }
                }
            }
            foreach (_bb6 _AKB2 in _bb6._AKA)
            {
                bool flag3 = _AKB2 && !string.IsNullOrEmpty(_AKB2._AJX) && !list.Contains(_AKB2._AJX);
                if (flag3)
                {
                    string text2 = AssetDatabase.GUIDToAssetPath(_AKB2._AJX);
                    bool flag4 = !string.IsNullOrEmpty(text2);
                    if (flag4)
                    {
                        list.Add(_AKB2._AJX);
                    }
                }
            }
            return list;
        }

        // Token: 0x0600007A RID: 122 RVA: 0x0000778C File Offset: 0x0000598C
        internal static _bb6 GetMostRecentlyActive(string ignoreGuid)
        {
            for (int i = 0; i < _bb6._AKH.Count; i++)
            {
                string text = _bb6._AKH[i];
                bool flag = text != ignoreGuid;
                if (flag)
                {
                    foreach (_bb6 _AKB in _bb6._AKA)
                    {
                        bool flag2 = _AKB && _AKB._AJX == text;
                        if (flag2)
                        {
                            return _AKB;
                        }
                    }
                }
            }
            return null;
        }

        // Token: 0x0600007B RID: 123 RVA: 0x00007840 File Offset: 0x00005A40
        private static void AddMostRecentGuidHistory(string guid)
        {
            int num = _bb6._AKH.IndexOf(guid);
            bool flag = num > 0;
            if (flag)
            {
                for (int i = num; i >= 1; i--)
                {
                    _bb6._AKH[i] = _bb6._AKH[i - 1];
                }
                _bb6._AKH[0] = guid;
                _bb6.SaveGuidHistory();
            }
            else
            {
                bool flag2 = num < 0;
                if (flag2)
                {
                    _bb6._AKH.Insert(0, guid);
                    _bb6.SaveGuidHistory();
                }
            }
            _bb6.SaveDefaultPosition();
        }

        // Token: 0x0600007C RID: 124 RVA: 0x000078CC File Offset: 0x00005ACC
        private void OnDestroy()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnFirstUpdate));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.PingLineWhenLoaded));
            bool flag = !this._AKC && _bb6._AKD;
            if (flag)
            {
                _bb6._AKD = false;
            }
            bool flag2 = _bb6._ALO == this;
            if (flag2)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.FocusNextTabOnUpdate));
                _bb6._ALO = null;
            }
            _bb6 _AKB = null;
            List<EditorWindow> tabsInDockArea = this.GetTabsInDockArea();
            bool flag3 = tabsInDockArea != null;
            if (flag3)
            {
                _bb6._AKI = null;
                int num = int.MaxValue;
                int count = tabsInDockArea.Count;
                while (count-- > 0 && num != 0)
                {
                    _bb6 _AKB2 = tabsInDockArea[count] as _bb6;
                    bool flag4 = _AKB2 != null;
                    if (flag4)
                    {
                        bool flag5 = _AKB2 != this;
                        if (!flag5)
                        {
                            int num2 = _bb6._AKH.IndexOf(_AKB2._AJX);
                            bool flag6 = num2 >= 0 && num2 < num;
                            if (flag6)
                            {
                                _AKB = _AKB2;
                                num = num2;
                            }
                        }
                    }
                    else
                    {
                        bool flag7 = tabsInDockArea[count];
                        if (flag7)
                        {
                            _bb6._AKI = tabsInDockArea[count].GetType().ToString();
                        }
                    }
                }
                bool flag8 = _AKB != null;
                if (flag8)
                {
                    _bb6._ALO = _AKB;
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.FocusNextTabOnUpdate));
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.FocusNextTabOnUpdate));
                }
                _bb6.SaveDefaultDockNextTo();
            }
        }

        // Token: 0x0600007D RID: 125 RVA: 0x00007AA4 File Offset: 0x00005CA4
        internal void OnEnable()
        {
            base.minSize = new Vector2(300f, 300f);
            bool flag = !_bb6._AKF;
            if (flag)
            {
                _bb6.LoadPrefs();
            }
            bool flag2 = this._AEK._ALP == null;
            if (flag2)
            {
                this._AEK._ALP = this;
            }
            EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.DestroyIfOrphaned));
            _bb6._AKA.Add(this);
            bool flag3 = !this._AKC;
            if (flag3)
            {
                _bb6._AKD = true;
            }
            base.hideFlags = (HideFlags)61;
            this._AEK._AGD = new _bi2._AGE(this.OnTextBufferChanged);
            bool flag4 = this._AKT == null;
            if (flag4)
            {
                this._AKT = _bb6._AKW;
            }
            bool flag5 = this._AKT == null && !string.IsNullOrEmpty(this._AJX);
            if (flag5)
            {
                string text = AssetDatabase.GUIDToAssetPath(this._AJX);
                bool flag6 = !string.IsNullOrEmpty(text);
                if (flag6)
                {
                    this._AKT = AssetDatabase.LoadAssetAtPath(text, typeof(UnityEngine.Object));
                }
            }
            bool flag7 = this._AKT == null;
            if (flag7)
            {
                this._AKT = Selection.activeObject as MonoScript;
            }
            bool flag8 = this._AKT == null;
            if (flag8)
            {
                this._AKT = Selection.activeObject as TextAsset;
            }
            bool flag9 = this._AKT == null;
            if (flag9)
            {
                this._AKT = Selection.activeObject as Shader;
            }
            bool flag10 = this._AKT != null;
            if (flag10)
            {
                this._AJX = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this._AKT));
            }
            bool flag11 = this._AKT == null && !string.IsNullOrEmpty(this._AJX);
            if (flag11)
            {
                _bb6._AKA.Remove(this);
                try
                {
                    base.Close();
                }
                catch
                {
                }
                UnityEngine.Object.DestroyImmediate(this);
            }
            else
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnFirstUpdate));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnFirstUpdate));
            }
        }

        // Token: 0x0600007E RID: 126 RVA: 0x00007CFC File Offset: 0x00005EFC
        private void OnDisable()
        {
            _bb6._AKA.Remove(this);
            this._AEK._AGD = null;
            this._AEK.OnDisable();
        }

        // Token: 0x0600007F RID: 127 RVA: 0x00007D24 File Offset: 0x00005F24
        private void OnFocus()
        {
            bool flag = string.IsNullOrEmpty(this._AJX);
            if (!flag)
            {
                this._ALK = _bb6._ALB._ALH.GetValue(this) ?? this._ALK;
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.AddMostRecentGuidOnUpdate));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.AddMostRecentGuidOnUpdate));
            }
        }

        // Token: 0x06000080 RID: 128 RVA: 0x00007DA0 File Offset: 0x00005FA0
        internal void OnLostFocus()
        {
            bool _ALQ = this._ALR;
            if (_ALQ)
            {
                this._ALR = false;
            }
            else
            {
                this._AEK.OnLostFocus();
            }
        }

        // Token: 0x06000081 RID: 129 RVA: 0x00007DD0 File Offset: 0x00005FD0
        private void OnGUI()
        {
            bool _ALS = this._ALT;
            if (_ALS)
            {
                this._ALT = false;
                this.OnFirstRepaint();
            }
            bool flag = Event.current.isKey && _bh1.OnGUIGlobal();
            if (!flag)
            {
                bool flag2 = Application.platform == RuntimePlatform.OSXEditor;
                switch (Event.current.type)
                {
                    case 4:
                        {
                            bool flag3 = ((int)Event.current.modifiers & -113) == 2 && ((int)Event.current.keyCode == 280 || (int)Event.current.keyCode == 281);
                            if (flag3)
                            {
                                this.SelectAdjacentCodeTab((int)Event.current.keyCode == 281);
                                Event.current.Use();
                                GUIUtility.ExitGUI();
                            }
                            else
                            {
                                bool flag4 = Event.current.alt && Event.current.control;
                                if (flag4)
                                {
                                    bool flag5 = (int)Event.current.keyCode == 275 || (int)Event.current.keyCode == 276;
                                    if (flag5)
                                    {
                                        bool shift = Event.current.shift;
                                        if (shift)
                                        {
                                            this.MoveThisTab((int)Event.current.keyCode == 275);
                                        }
                                        else
                                        {
                                            this.SelectAdjacentCodeTab((int)Event.current.keyCode == 275);
                                        }
                                        Event.current.Use();
                                        GUIUtility.ExitGUI();
                                    }
                                }
                                else
                                {
                                    bool flag6 = EditorGUI.actionKey && ((int)Event.current.keyCode == 119 || (int)Event.current.keyCode == 285);
                                    if (flag6)
                                    {
                                        Event.current.Use();
                                        bool flag7 = !GCE._ALU._ABK().CheckSaveIfCancel();
                                        if (flag7)
                                        {
                                            Event.current.Use();
                                            _bb6._AKA.Remove(this);
                                            base.Close();
                                        }
                                        else
                                        {
                                            Event.current.Use();
                                        }
                                    }
                                    else
                                    {
                                        bool flag8 = !flag2 && !Event.current.alt && Event.current.shift && EditorGUI.actionKey;
                                        if (flag8)
                                        {
                                            bool flag9 = (int)Event.current.keyCode == 119 || (int)Event.current.keyCode == 285;
                                            if (flag9)
                                            {
                                                this.CloseOtherTabs();
                                            }
                                        }
                                        else
                                        {
                                            bool flag10 = Event.current.alt && !Event.current.shift && !EditorGUI.actionKey && (int)Event.current.keyCode == 13;
                                            if (flag10)
                                            {
                                                Event.current.Use();
                                                _bb6.ToggleMaximized(this);
                                                GUIUtility.ExitGUI();
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case 8:
                        {
                            bool flag11 = this.IsFloating() && GCE._ALU == this._AEK;
                            if (flag11)
                            {
                                _bb6._AKJ = base.position;
                            }
                            break;
                        }
                    case 9:
                    case 10:
                        {
                            bool flag12 = DragAndDrop.objectReferences.Length != 0;
                            if (flag12)
                            {
                                bool flag13 = false;
                                HashSet<UnityEngine.Object> hashSet = new HashSet<UnityEngine.Object>();
                                foreach (UnityEngine.Object @object in DragAndDrop.objectReferences)
                                {
                                    string text = AssetDatabase.GetAssetPath(@object);
                                    bool flag14 = text.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || text.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                                    if (!flag14)
                                    {
                                        bool flag15 = text.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase) || text.StartsWith("Packages/", StringComparison.OrdinalIgnoreCase);
                                        if (flag15)
                                        {
                                            bool flag16 = @object is MonoScript;
                                            if (flag16)
                                            {
                                                hashSet.Add(@object);
                                            }
                                            else
                                            {
                                                bool flag17 = @object is TextAsset || @object is Shader;
                                                if (flag17)
                                                {
                                                    hashSet.Add(@object);
                                                }
                                                else
                                                {
                                                    bool flag18 = @object is Material;
                                                    if (flag18)
                                                    {
                                                        Material material = @object as Material;
                                                        bool flag19 = material.shader != null;
                                                        if (flag19)
                                                        {
                                                            int instanceID = material.shader.GetInstanceID();
                                                            bool flag20 = instanceID != 0;
                                                            if (flag20)
                                                            {
                                                                text = AssetDatabase.GetAssetPath(instanceID);
                                                                bool flag21 = !string.IsNullOrEmpty(text);
                                                                if (flag21)
                                                                {
                                                                    hashSet.Add(material.shader);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        hashSet.Add(@object);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            bool flag22 = @object is MonoBehaviour;
                                            if (flag22)
                                            {
                                                MonoBehaviour monoBehaviour = @object as MonoBehaviour;
                                                MonoScript monoScript = MonoScript.FromMonoBehaviour(monoBehaviour);
                                                hashSet.Add(monoScript);
                                            }
                                            else
                                            {
                                                bool flag23 = @object is GameObject;
                                                if (flag23)
                                                {
                                                    GameObject gameObject = @object as GameObject;
                                                    MonoBehaviour[] components = gameObject.GetComponents<MonoBehaviour>();
                                                    foreach (MonoBehaviour monoBehaviour2 in components)
                                                    {
                                                        MonoScript monoScript2 = MonoScript.FromMonoBehaviour(monoBehaviour2);
                                                        bool flag24 = monoScript2 != null;
                                                        if (flag24)
                                                        {
                                                            text = AssetDatabase.GetAssetPath(monoScript2);
                                                            bool flag25 = (!string.IsNullOrEmpty(text) && text.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase)) || (text.StartsWith("Packages/", StringComparison.OrdinalIgnoreCase) && !text.EndsWith(".dll", StringComparison.OrdinalIgnoreCase));
                                                            if (flag25)
                                                            {
                                                                hashSet.Add(monoScript2);
                                                                flag13 = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                bool flag26 = hashSet.Count > 0;
                                if (flag26)
                                {
                                    DragAndDrop.AcceptDrag();
                                    DragAndDrop.visualMode = (DragAndDropVisualMode)1;
                                    bool flag27 = (int)Event.current.type == 10;
                                    if (flag27)
                                    {
                                        UnityEngine.Object[] sorted = hashSet.OrderBy((UnityEngine.Object x) => x.name, StringComparer.OrdinalIgnoreCase).ToArray<UnityEngine.Object>();
                                        bool flag28 = flag13 && sorted.Length > 1;
                                        if (flag28)
                                        {
                                            GenericMenu genericMenu = new GenericMenu();
                                            UnityEngine.Object[] sorted4 = sorted;
                                            for (int k = 0; k < sorted4.Length; k++)
                                            {
                                                UnityEngine.Object object2 = sorted4[k];
                                                UnityEngine.Object tempTarget = object2;
                                                string fileName = Path.GetFileName(AssetDatabase.GetAssetPath(object2));
                                                genericMenu.AddItem(new GUIContent("Open " + fileName), false, delegate
                                                {
                                                    _bb6.OpenNewWindow(tempTarget, this, true);
                                                });
                                            }
                                            genericMenu.AddSeparator("");
                                            genericMenu.AddItem(new GUIContent("Open All"), false, delegate
                                            {
                                                foreach (UnityEngine.Object object4 in sorted)
                                                {
                                                    _bb6.OpenNewWindow(object4, this, true);
                                                }
                                            });
                                            genericMenu.ShowAsContext();
                                        }
                                        else
                                        {
                                            foreach (UnityEngine.Object object3 in sorted)
                                            {
                                                _bb6.OpenNewWindow(object3, this, true);
                                            }
                                        }
                                    }
                                    Event.current.Use();
                                    return;
                                }
                            }
                            break;
                        }
                    case 13:
                        {
                            bool flag29 = Event.current.commandName == "SuperEditor.AddTab";
                            if (flag29)
                            {
                                Event.current.Use();
                                return;
                            }
                            break;
                        }
                    case 14:
                        {
                            bool flag30 = Event.current.commandName == "SuperEditor.AddTab";
                            if (flag30)
                            {
                                Event.current.Use();
                                _bb6.OpenNewWindow(this._AKT, this, false);
                                return;
                            }
                            break;
                        }
                }
                bool flag31 = !base.wantsMouseMove;
                if (flag31)
                {
                    base.wantsMouseMove = true;
                }
                bool flag32 = _bb6._ALV == null;
                if (flag32)
                {
                    _bb6._ALV = new RectOffset(0, 0, 0, 0);
                }
                this._AEK.OnWindowGUI(this, _bb6._ALV);
            }
        }

        // Token: 0x06000082 RID: 130 RVA: 0x00008594 File Offset: 0x00006794
        private static void AddMostRecentGuidOnUpdate()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bb6.AddMostRecentGuidOnUpdate));
            _bb6 _AKB = EditorWindow.focusedWindow as _bb6;
            bool flag = _AKB != null && !string.IsNullOrEmpty(_AKB._AJX);
            if (flag)
            {
                _bb6.AddMostRecentGuidHistory(_AKB._AJX);
            }
        }

        // Token: 0x06000083 RID: 131 RVA: 0x000085F8 File Offset: 0x000067F8
        private static void SaveGuidHistory()
        {
            bool flag = _bb6._AKH.Count > 50;
            if (flag)
            {
                _bb6._AKH.RemoveRange(50, _bb6._AKH.Count - 50);
            }
            string text = string.Join(";", _bb6._AKH.ToArray());
            EditorPrefs.SetString("SuperEditorRecentGUIDs", text);
            _bb6.SaveDefaultDockNextTo();
        }

        // Token: 0x06000084 RID: 132 RVA: 0x00008659 File Offset: 0x00006859
        private static void SaveDefaultDockNextTo()
        {
            EditorPrefs.SetString("SuperEditorDefaultDockNextTo", _bb6._AKI ?? "UnityEditor.SceneView");
        }

        // Token: 0x06000085 RID: 133 RVA: 0x00008678 File Offset: 0x00006878
        private static void SaveDefaultPosition()
        {
            EditorPrefs.SetFloat("SuperEditorDefaultPositionX", _bb6._AKJ.x);
            EditorPrefs.SetFloat("SuperEditorDefaultPositionY", _bb6._AKJ.y);
            EditorPrefs.SetFloat("SuperEditorDefaultPositionW", _bb6._AKJ.width);
            EditorPrefs.SetFloat("SuperEditorDefaultPositionH", _bb6._AKJ.height);
        }

        // Token: 0x06000086 RID: 134 RVA: 0x000086DC File Offset: 0x000068DC
        private void UpdateWindowTitle()
        {
            bool flag = this._AEK._ALW();
            bool flag2 = !flag && this._AEK._ABK() == null;
            if (flag2)
            {
                bool flag3 = !string.IsNullOrEmpty(this._AJX);
                if (flag3)
                {
                    string text = AssetDatabase.GUIDToAssetPath(this._AJX);
                    bool flag4 = !string.IsNullOrEmpty(text);
                    if (flag4)
                    {
                        GCE _AMX = _bc5.TryGetBuffer(text);
                        bool flag5 = _AMX != null;
                        if (flag5)
                        {
                            flag = _AMX._ALW();
                        }
                    }
                }
            }
            bool flag6 = base.titleContent.text.StartsWith("*", StringComparison.Ordinal);
            if (flag6)
            {
                bool flag7 = !flag;
                if (!flag7)
                {
                    return;
                }
                base.titleContent.text = base.titleContent.text.Substring(1);
            }
            else
            {
                bool flag8 = flag;
                if (!flag8)
                {
                    return;
                }
                base.titleContent.text = "*" + this._AKE;
                this._AKC = true;
            }
            foreach (_bb6 _AKB in _bb6._AKA)
            {
                bool flag9 = _AKB && _AKB._AJX == this._AJX;
                if (flag9)
                {
                    _AKB.UpdateWindowTitle();
                }
            }
        }

        // Token: 0x06000087 RID: 135 RVA: 0x00008850 File Offset: 0x00006A50
        private static bool IsMaximized(EditorWindow window)
        {
            return window.maximized;
        }

        // Token: 0x06000088 RID: 136 RVA: 0x00008868 File Offset: 0x00006A68
        private static void ToggleMaximized(EditorWindow window)
        {
            window.maximized = !window.maximized;
            _bb6 _AKB = window as _bb6;
            bool flag = _AKB;
            if (flag)
            {
                _AKB._AEK.FocusCodeView();
            }
        }

        // Token: 0x06000089 RID: 137 RVA: 0x000088A4 File Offset: 0x00006AA4
        private bool IsMaximized()
        {
            return base.maximized;
        }

        // Token: 0x0600008A RID: 138 RVA: 0x000088BC File Offset: 0x00006ABC
        public void AddItemsToMenu(GenericMenu menu)
        {
            bool flag = !string.IsNullOrEmpty(this._AJX);
            if (flag)
            {
                bool flag2 = Application.platform == RuntimePlatform.OSXEditor;
                bool flag3 = Application.platform == RuntimePlatform.WindowsEditor;
                bool flag4 = Application.platform == RuntimePlatform.LinuxEditor;
                string assetPath = AssetDatabase.GUIDToAssetPath(this._AJX);
                menu.AddItem("Locate", "&%l", "Locate", "%#l", false, delegate
                {
                    Assembly assembly = typeof(EditorWindow).Assembly;
                    EditorWindow.GetWindow(assembly.GetType("UnityEditor.ProjectBrowser"));
                    EditorGUIUtility.PingObject(this._AKT);
                });
                menu.AddItem(new GUIContent("Copy Path"), false, delegate
                {
                    string text = Path.GetFullPath(assetPath);
                    bool flag13 = text.IndexOf(' ') >= 0;
                    if (flag13)
                    {
                        text = "\"" + text + "\"";
                    }
                    EditorGUIUtility.systemCopyBuffer = text;
                });
                bool flag5 = flag2;
                if (flag5)
                {
                    menu.AddItem(new GUIContent("Reveal in Finder"), false, delegate
                    {
                        Selection.activeObject = this._AKT;
                        EditorApplication.ExecuteMenuItem("Assets/Reveal in Finder");
                    });
                }
                bool flag6 = flag3;
                if (flag6)
                {
                    menu.AddItem(new GUIContent("Show in Explorer"), false, delegate
                    {
                        Selection.activeObject = this._AKT;
                        EditorApplication.ExecuteMenuItem("Assets/Show in Explorer");
                    });
                }
                bool flag7 = flag4;
                if (flag7)
                {
                    menu.AddItem(new GUIContent("Open Containing Folder"), false, delegate
                    {
                        Selection.activeObject = this._AKT;
                        EditorApplication.ExecuteMenuItem("Assets/Open Containing Folder");
                    });
                }
                bool flag8 = !flag4;
                if (flag8)
                {
                    menu.AddItem("Duplicate Tab", "%t", "Duplicate Tab", "%t", false, delegate
                    {
                        EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("SuperEditor.AddTab"));
                    });
                }
                else
                {
                    menu.AddItem("Duplicate Tab", "%t", "Duplicate Tab", "%t", false, delegate
                    {
                        _bb6.OpenNewWindow(this._AKT, this, false);
                    });
                }
                menu.AddSeparator("");
                menu.AddItem("Save All", "_&%s", "Save all", "%&s", false, delegate
                {
                    EditorApplication.ExecuteMenuItem("Window/Super Editor/Save All Modified");
                });
                menu.AddSeparator("");
                bool flag9 = this.IsMaximized();
                menu.AddItem("Maximize", "&\n", "Maximize", "&enter", flag9, delegate
                {
                    _bb6.ToggleMaximized(this);
                });
                bool flag10 = !this._AKC;
                if (flag10)
                {
                    menu.AddItem("Dock Tab", "", "Dock Tab", "", false, new GenericMenu.MenuFunction(this.DockTab));
                }
                menu.AddItem("Close", "%w", "Close", "%w", false, delegate
                {
                    bool flag14 = GCE._ALU._ABK().CheckSaveIfCancel();
                    if (!flag14)
                    {
                        _bb6._AKA.Remove(this);
                        base.Close();
                    }
                });
                bool flag11 = _bb6._AKA.Count > 1;
                if (flag11)
                {
                    menu.AddItem(new GUIContent("Close All"), false, delegate
                    {
                        this.CloseOtherTabs();
                        try
                        {
                            _bb6._AKA.Remove(this);
                            base.Close();
                        }
                        catch
                        {
                        }
                    });
                    menu.AddItem("Close Other", "", "Close Other", "%#w", false, new GenericMenu.MenuFunction(this.CloseOtherTabs));
                    bool flag12 = this.GetRightTabsCount() > 0;
                    if (flag12)
                    {
                        menu.AddItem("Close Tabs to the Right", "", "Close Tabs to the Right", "", false, new GenericMenu.MenuFunction(this.CloseTabsRightOf));
                    }
                }
                menu.ShowAsContext();
                GUIUtility.ExitGUI();
            }
        }

        // Token: 0x0600008B RID: 139 RVA: 0x00008BCC File Offset: 0x00006DCC
        internal static void ResetTabsPosition()
        {
            _bb6._AKI = "UnityEditor.SceneView";
            EditorPrefs.SetString("SuperEditorDefaultDockNextTo", "UnityEditor.SceneView");
            _bb6[] array = new _bb6[_bb6._AKA.Count];
            _bb6._AKA.CopyTo(array);
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    _bb6.OpenNewWindow(array[i]._AKT, EditorWindow.GetWindow<SceneView>(), false);
                    array[i].Close();
                }
                catch
                {
                }
            }
        }

        // Token: 0x0600008C RID: 140 RVA: 0x00008C5C File Offset: 0x00006E5C
        [MenuItem("Window/Super Editor/Reset to Factory Settings", false, 601)]
        internal static void ResetToFactory()
        {
            _bb6.ResetTabsPosition();
            _bi2.ResetFontSize();
            _bi2.LoadStyles(null, false);
        }

        // Token: 0x0600008D RID: 141 RVA: 0x00008C74 File Offset: 0x00006E74
        [MenuItem("Window/Super Editor/Close All", true, 503)]
        internal static bool ValidateCloseAllTabs()
        {
            return _bb6._AKA.Count > 0;
        }

        // Token: 0x0600008E RID: 142 RVA: 0x00008C94 File Offset: 0x00006E94
        [MenuItem("Window/Super Editor/Close All", false, 503)]
        internal static void CloseAllTabs()
        {
            _bc5.SaveAllModified(true);
            _bb6[] array = new _bb6[_bb6._AKA.Count];
            _bb6._AKA.CopyTo(array);
            foreach (_bb6 _AKB in array)
            {
                try
                {
                    _bb6._AKA.Remove(_AKB);
                    _AKB.Close();
                }
                catch
                {
                }
            }
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00008D08 File Offset: 0x00006F08
        internal void CloseOtherTabs()
        {
            _bc5.SaveAllModified(true);
            _bb6[] array = new _bb6[_bb6._AKA.Count];
            _bb6._AKA.CopyTo(array);
            foreach (_bb6 _AKB in array)
            {
                bool flag = _AKB && _AKB != this;
                if (flag)
                {
                    try
                    {
                        _bb6._AKA.Remove(_AKB);
                        _AKB.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

        // Token: 0x06000090 RID: 144 RVA: 0x00008D94 File Offset: 0x00006F94
        internal int GetRightTabsCount()
        {
            object value = _bb6._ALB._ALH.GetValue(this);
            List<EditorWindow> list = _bb6._ALB._ALE.GetValue(value) as List<EditorWindow>;
            int num = list.FindIndex((EditorWindow wnd) => wnd == this);
            return list.Count - 1 - num;
        }

        // Token: 0x06000091 RID: 145 RVA: 0x00008DE0 File Offset: 0x00006FE0
        internal void CloseTabsRightOf()
        {
            object value = _bb6._ALB._ALH.GetValue(this);
            bool flag = value == null || value.GetType() != _bb6._ALB._ALI;
            if (!flag)
            {
                List<EditorWindow> list = _bb6._ALB._ALE.GetValue(value) as List<EditorWindow>;
                bool flag2 = list == null;
                if (!flag2)
                {
                    int num = list.FindIndex((EditorWindow wnd) => wnd == this);
                    bool flag3 = num < 0;
                    if (!flag3)
                    {
                        for (int i = list.Count - 1; i > num; i--)
                        {
                            _bb6 _AKB = list[i] as _bb6;
                            bool flag4 = _AKB == null;
                            if (!flag4)
                            {
                                _AKB.Close();
                            }
                        }
                        base.Focus();
                        base.Repaint();
                    }
                }
            }
        }

        // Token: 0x06000092 RID: 146 RVA: 0x00008EA9 File Offset: 0x000070A9
        internal void DockTab()
        {
            this._AKC = true;
            base.titleContent.text = this._AKE + "\u00a0";
        }

        // Token: 0x06000093 RID: 147 RVA: 0x00008ED0 File Offset: 0x000070D0
        private bool IsFloating()
        {
            bool flag = _bb6._ALB._ALH == null || _bb6._ALB._ALX == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                object obj = _bb6._ALB._ALH.GetValue(this);
                bool flag3 = obj == null;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    bool flag4 = obj.GetType() != _bb6._ALB._ALI;
                    if (flag4)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        obj = _bb6._ALB._ALX.GetValue(obj, null);
                        bool flag5 = obj == null;
                        if (flag5)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            object obj2 = obj;
                            while (obj != null)
                            {
                                bool flag6 = obj.GetType() != _bb6._ALB._ALY;
                                if (flag6)
                                {
                                    break;
                                }
                                obj2 = obj;
                                obj = _bb6._ALB._ALX.GetValue(obj, null);
                            }
                            bool flag7 = obj2 == null;
                            if (flag7)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                object value = _bb6._ALB._ALX.GetValue(obj2, null);
                                bool flag8 = value == null || value.GetType() != _bb6._ALB._ALZ;
                                flag2 = flag8;
                            }
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000094 RID: 148 RVA: 0x00008FD8 File Offset: 0x000071D8
        private static void UnhideCodeWindowTabs()
        {
            string text = Directory.GetCurrentDirectory() + "/Library/CodeWindowLayout.temp";
            bool flag = File.Exists(text);
            if (flag)
            {
                _bb6.ToggleCodeWindowTabs();
            }
        }

        // Token: 0x06000095 RID: 149 RVA: 0x00009008 File Offset: 0x00007208
        private static void ToggleCodeWindowTabs()
        {
            string text = Directory.GetCurrentDirectory() + "/Library/CodeWindowLayout.temp";
            string[] array = _bb6._AKH.ToArray();
            int num = int.MaxValue;
            Rect _AKX = _bb6._AKJ;
            bool flag = File.Exists(text);
            if (flag)
            {
                _AKX.y += 25f;
                _AKX.height -= 3f;
                _bb6 _AKB = null;
                _bb6 _AKB2 = null;
                UnityEngine.Object[] array2 = InternalEditorUtility.LoadSerializedFileAndForget(text);
                try
                {
                    File.Delete(text);
                }
                catch (IOException)
                {
                    foreach (UnityEngine.Object @object in array2)
                    {
                        UnityEngine.Object.DestroyImmediate(@object);
                    }
                    return;
                }
                bool flag2 = true;
                foreach (UnityEngine.Object object2 in array2)
                {
                    _bb6 _AKB3 = (_bb6)object2;
                    bool flag3 = flag2 || !_AKB3.TryDockNextToSimilarTab(_AKB2);
                    if (flag3)
                    {
                        _AKB3.Show(true);
                        _AKX.yMin += 1f;
                        _AKB3.position = _AKX;
                        _AKX.yMin -= 1f;
                        _AKB3.Focus();
                        _AKB3.Repaint();
                        _AKB3.position = _AKX;
                        _AKB2 = _AKB3;
                        flag2 = false;
                    }
                    int num2 = Array.IndexOf<string>(array, _AKB3._AJX);
                    bool flag4 = num2 >= 0 && num2 < num;
                    if (flag4)
                    {
                        num = num2;
                        _AKB = _AKB3;
                    }
                }
                bool flag5 = _AKB;
                if (flag5)
                {
                    _AKB.Focus();
                }
            }
            else
            {
                bool flag6 = _bb6._AKA.Count > 0;
                if (flag6)
                {
                    List<_bb6> list = new List<_bb6>(_bb6._AKA);
                    int count = list.Count;
                    while (count-- > 0)
                    {
                        _bb6 _AKB4 = list[count];
                        bool flag7 = !_AKB4 || !_AKB4.IsFloating();
                        if (flag7)
                        {
                            list.RemoveAt(count);
                        }
                        else
                        {
                            _AKB4.Repaint();
                        }
                    }
                    _bb6 _AKB5 = EditorWindow.focusedWindow as _bb6;
                    bool flag8 = !_AKB5 || !_AKB5.IsFloating();
                    if (flag8)
                    {
                        _bb6 _AKB6 = null;
                        int count2 = list.Count;
                        while (count2-- > 0)
                        {
                            _bb6 _AKB7 = list[count2];
                            int num3 = Array.IndexOf<string>(array, _AKB7._AJX);
                            bool flag9 = num3 >= 0 && num3 < num;
                            if (flag9)
                            {
                                num = num3;
                                _AKB6 = _AKB7;
                            }
                        }
                        bool flag10 = _AKB6;
                        if (flag10)
                        {
                            _AKB6.Focus();
                            return;
                        }
                    }
                    _bb6._AMA = true;
                    EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                    {
                        _bb6._AMA = false;
                    }));
                    _bb6[] array5 = list.ToArray();
                    UnityEngine.Object[] array6 = array5;
                    InternalEditorUtility.SaveToSerializedFileAndForget(array6, text, true);
                    int num4 = array5.Length;
                    while (num4-- > 0)
                    {
                        _bb6 _AKB8 = array5[num4];
                        bool flag11 = _AKB8;
                        if (flag11)
                        {
                            _bb6._AKA.Remove(_AKB8);
                            _AKB8.Close();
                        }
                    }
                    _bb6._AKJ = _AKX;
                    _bb6.SaveDefaultPosition();
                }
            }
            _bb6._AKH.Clear();
            _bb6._AKH.AddRange(array);
            _bb6.SaveGuidHistory();
        }

        // Token: 0x04000073 RID: 115
        [HideInInspector]
        [SerializeField]
        internal UnityEngine.Object _AKT;

        // Token: 0x04000074 RID: 116
        [SerializeField]
        [HideInInspector]
        internal string _AKE;

        // Token: 0x04000075 RID: 117
        [HideInInspector]
        [SerializeField]
        private string _AJX;

        // Token: 0x04000076 RID: 118
        [SerializeField]
        [HideInInspector]
        internal bool _AKC = true;

        // Token: 0x04000077 RID: 119
        internal static bool _AKD;

        // Token: 0x04000078 RID: 120
        private static UnityEngine.Object _AKW = null;

        // Token: 0x04000079 RID: 121
        [HideInInspector]
        [SerializeField]
        private _bi2 _AEK = new _bi2();

        // Token: 0x0400007A RID: 122
        [NonSerialized]
        private int _AKY = -1;

        // Token: 0x0400007B RID: 123
        [NonSerialized]
        private int _AKZ = -1;

        // Token: 0x0400007C RID: 124
        [NonSerialized]
        private int _ALA = -1;

        // Token: 0x0400007D RID: 125
        [NonSerialized]
        private int _AKU = 0;

        // Token: 0x0400007E RID: 126
        private static HashSet<_bb6> _AKA = new HashSet<_bb6>();

        // Token: 0x0400007F RID: 127
        private static string _AKI;

        // Token: 0x04000080 RID: 128
        private static Rect _AKJ;

        // Token: 0x04000081 RID: 129
        private static bool _AKF;

        // Token: 0x04000082 RID: 130
        [NonSerialized]
        private object _ALK;

        // Token: 0x04000083 RID: 131
        internal static bool _AKK;

        // Token: 0x04000084 RID: 132
        internal static bool _AKL;

        // Token: 0x04000085 RID: 133
        internal static bool _AMA;

        // Token: 0x04000086 RID: 134
        [NonSerialized]
        private bool _ALL;

        // Token: 0x04000087 RID: 135
        private static EditorWindow _ALO = null;

        // Token: 0x04000088 RID: 136
        private static List<string> _AKH = new List<string>();

        // Token: 0x04000089 RID: 137
        [NonSerialized]
        internal bool _ALR = false;

        // Token: 0x0400008A RID: 138
        [NonSerialized]
        private bool _ALT = true;

        // Token: 0x0400008B RID: 139
        [NonSerialized]
        private static RectOffset _ALV;

        // Token: 0x0200000F RID: 15
        private static class _ALB
        {
            // Token: 0x060000A3 RID: 163 RVA: 0x00009510 File Offset: 0x00007710
            static _ALB()
            {
                Assembly assembly = typeof(EditorWindow).Assembly;
                _bb6._ALB._AMB = assembly.GetType("UnityEditor.ContainerWindow");
                _bb6._ALB._AMC = assembly.GetType("UnityEditor.View");
                _bb6._ALB._ALI = assembly.GetType("UnityEditor.DockArea");
                _bb6._ALB._ALY = assembly.GetType("UnityEditor.SplitView");
                _bb6._ALB._ALZ = assembly.GetType("UnityEditor.MainWindow") ?? assembly.GetType("UnityEditor.MainView");
                _bb6._ALB._AMD = assembly.GetType("UnityEditor.WindowLayout");
                _bb6._ALB._ALH = typeof(EditorWindow).GetField("m_Parent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                bool flag = _bb6._ALB._AMC != null;
                if (flag)
                {
                    _bb6._ALB._ALX = _bb6._ALB._AMC.GetProperty("parent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                }
                bool flag2 = _bb6._ALB._ALI != null;
                if (flag2)
                {
                    _bb6._ALB._ALE = _bb6._ALB._ALI.GetField("m_Panes", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    _bb6._ALB._ALF = _bb6._ALB._ALI.GetMethod("AddTab", new Type[] { typeof(EditorWindow) });
                    _bb6._ALB._ALG = _bb6._ALB._ALI.GetMethod("AddTab", new Type[]
                    {
                        typeof(EditorWindow),
                        typeof(bool)
                    });
                }
                bool flag3 = _bb6._ALB._AMB != null;
                if (flag3)
                {
                    _bb6._ALB._ALC = _bb6._ALB._AMB.GetProperty("windows", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    _bb6._ALB._ALD = _bb6._ALB._AMB.GetProperty("mainView", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ?? _bb6._ALB._AMB.GetProperty("rootView", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                }
                bool flag4 = _bb6._ALB._AMC != null;
                if (flag4)
                {
                    _bb6._ALB._ALJ = _bb6._ALB._AMC.GetProperty("allChildren", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                }
                Type type = assembly.GetType("UnityEditor.ProjectWindowUtil");
                bool flag5 = type != null;
                if (flag5)
                {
                    _bb6._ALB._AMH = type.GetMethod("CreateAsset", new Type[]
                    {
                        typeof(UnityEngine.Object),
                        typeof(string)
                    });
                }
                bool flag6 = _bb6._ALB._AMD != null;
                if (flag6)
                {
                    _bb6._ALB._AME = _bb6._ALB._AMD.GetMethod("IsMaximized", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    _bb6._ALB._AMF = _bb6._ALB._AMD.GetMethod("Maximize", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    _bb6._ALB._AMG = _bb6._ALB._AMD.GetMethod("Unmaximize", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    bool flag7 = _bb6._ALB._AME == null || _bb6._ALB._AMF == null || _bb6._ALB._AMG == null;
                    if (flag7)
                    {
                        _bb6._ALB._AMD = null;
                    }
                }
            }

            // Token: 0x060000A4 RID: 164 RVA: 0x000097AC File Offset: 0x000079AC
            internal static bool CreateAsset(UnityEngine.Object asset, string pathName)
            {
                bool flag = _bb6._ALB._AMH == null;
                if (flag)
                {
                    _bb6._ALB._AMH.Invoke(null, new object[] { asset, pathName });
                }
                return _bb6._ALB._AMH == null;
            }

            // Token: 0x0400008C RID: 140
            internal static Type _AMB;

            // Token: 0x0400008D RID: 141
            internal static Type _AMC;

            // Token: 0x0400008E RID: 142
            internal static Type _ALI;

            // Token: 0x0400008F RID: 143
            internal static Type _ALY;

            // Token: 0x04000090 RID: 144
            internal static Type _ALZ;

            // Token: 0x04000091 RID: 145
            internal static FieldInfo _ALE;

            // Token: 0x04000092 RID: 146
            internal static PropertyInfo _ALC;

            // Token: 0x04000093 RID: 147
            internal static PropertyInfo _ALD;

            // Token: 0x04000094 RID: 148
            internal static PropertyInfo _ALJ;

            // Token: 0x04000095 RID: 149
            internal static MethodInfo _ALF;

            // Token: 0x04000096 RID: 150
            internal static MethodInfo _ALG;

            // Token: 0x04000097 RID: 151
            internal static FieldInfo _ALH;

            // Token: 0x04000098 RID: 152
            internal static PropertyInfo _ALX;

            // Token: 0x04000099 RID: 153
            internal static MethodInfo _AMH;

            // Token: 0x0400009A RID: 154
            internal static Type _AMD;

            // Token: 0x0400009B RID: 155
            internal static MethodInfo _AME;

            // Token: 0x0400009C RID: 156
            internal static MethodInfo _AMF;

            // Token: 0x0400009D RID: 157
            internal static MethodInfo _AMG;
        }
    }
}
