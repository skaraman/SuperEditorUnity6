using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace AHO
{
    // Token: 0x02000073 RID: 115
    [InitializeOnLoad]
    internal static class _bl1
    {
        // Token: 0x06000395 RID: 917 RVA: 0x000A786C File Offset: 0x000A5A6C
        static _bl1()
        {
            bool @bool = EditorPrefs.GetBool("CheckForSuperEditorUpdates");
            if (@bool)
            {
                _bl1._zk8 = false;
                _bl1.CheckForUpdate();
            }
        }

        // Token: 0x06000396 RID: 918 RVA: 0x000A7896 File Offset: 0x000A5A96
        [MenuItem("Window/Super Editor/Check for Updates", false, 991)]
        private static void MenuCheckForUpdate()
        {
            _bl1._zk8 = true;
            _bl1.CheckForUpdate();
        }

        // Token: 0x06000397 RID: 919 RVA: 0x000A78A8 File Offset: 0x000A5AA8
        internal static void CheckForUpdate()
        {
            bool flag = _bl1._zk9 == null;
            if (flag)
            {
                _bl1._zk9 = UnityWebRequest.Get("https://raw.githubusercontent.com/UnitySuperEditor/SuperEditor/master/Updates.txt");
                _bl1._zk9.SendWebRequest();
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bl1.Update));
            }
        }

        // Token: 0x06000398 RID: 920 RVA: 0x000A78F4 File Offset: 0x000A5AF4
        private static void Update()
        {
            bool flag = _bl1._zk9 != null;
            if (flag)
            {
                bool flag2 = !_bl1._zk9.isDone;
                if (flag2)
                {
                    return;
                }
                try
                {
                    bool flag3 = _bl1._zk9.result == UnityWebRequest.Result.Success || !Regex.IsMatch(_bl1._zk9.downloadHandler.text, "404 not found", RegexOptions.IgnoreCase);
                    if (flag3)
                    {
                        _bj9 _zl1;
                        string text;
                        bool flag4 = !_bi4.FormatChangelog(_bl1._zk9.downloadHandler.text, out _zl1, out text);
                        if (flag4)
                        {
                            _bl1.FailedConnection(null);
                        }
                        else
                        {
                            _bj9 _zl2;
                            bool flag5 = !_bi4.GetCurrent(out _zl2) || _zl1.CompareTo(_zl2) > 0;
                            if (flag5)
                            {
                                string @string = EditorPrefs.GetString("LastWebVersionChecked", "");
                                bool flag6 = _bl1._zk8 || !@string.Equals(_zl1._ABG);
                                if (flag6)
                                {
                                    _bj7.Init(_zl1, text);
                                    EditorPrefs.SetString("LastWebVersionChecked", _zl1._ABG);
                                }
                            }
                            else
                            {
                                _bl1.UpToDate(_zl2.ToString());
                            }
                        }
                    }
                    else
                    {
                        _bl1.FailedConnection(null);
                    }
                }
                catch (Exception ex)
                {
                    _bl1.FailedConnection(string.Format("Error: Is build target is Webplayer?\n\n{0}", ex.ToString()));
                }
                _bl1._zk9 = null;
            }
            _bl1._zk8 = false;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bl1.Update));
        }

        // Token: 0x06000399 RID: 921 RVA: 0x000A7A78 File Offset: 0x000A5C78
        private static void UpToDate(string version)
        {
            bool _zl3 = _bl1._zk8;
            if (_zl3)
            {
                EditorUtility.DisplayDialog("SuperEditor Update Check", string.Format("You're up to date!\n\nInstalled Version: {0}\nLatest Version: {0}", version), "Ok");
            }
        }

        // Token: 0x0600039A RID: 922 RVA: 0x000A7AAC File Offset: 0x000A5CAC
        private static void FailedConnection(string error = null)
        {
            bool _zl3 = _bl1._zk8;
            if (_zl3)
            {
                EditorUtility.DisplayDialog("SuperEditor Update Check", (error == null) ? "Failed to connect to server!" : string.Format("Failed to connect to server!\n\n{0}", error.ToString()), "Ok");
            }
        }

        // Token: 0x0400040D RID: 1037
        private static UnityWebRequest _zk9;

        // Token: 0x0400040E RID: 1038
        private static bool _zk8;
    }
}
