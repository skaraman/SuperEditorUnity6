using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

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
                _bl1.AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE = false;
                _bl1.CheckForUpdate();
            }
        }

        // Token: 0x06000396 RID: 918 RVA: 0x000A7896 File Offset: 0x000A5A96
        [MenuItem("Window/Super Editor/Check for Updates", false, 991)]
        private static void MenuCheckForUpdate()
        {
            _bl1.AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE = true;
            _bl1.CheckForUpdate();
        }

        // Token: 0x06000397 RID: 919 RVA: 0x000A78A8 File Offset: 0x000A5AA8
        internal static void CheckForUpdate()
        {
            bool flag = _bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL == null;
            if (flag)
            {
                _bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL = new WWW("https://raw.githubusercontent.com/UnitySuperEditor/SuperEditor/master/Updates.txt");
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bl1.Update));
            }
        }

        // Token: 0x06000398 RID: 920 RVA: 0x000A78F4 File Offset: 0x000A5AF4
        private static void Update()
        {
            bool flag = _bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL != null;
            if (flag)
            {
                bool flag2 = !_bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL.isDone;
                if (flag2)
                {
                    return;
                }
                try
                {
                    bool flag3 = string.IsNullOrEmpty(_bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL.error) || !Regex.IsMatch(_bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL.text, "404 not found", RegexOptions.IgnoreCase);
                    if (flag3)
                    {
                        _bj9 mcknonjhcbhjpkmknajcpjikiglijfkmmnop;
                        string text;
                        bool flag4 = !_bi4.FormatChangelog(_bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL.text, out mcknonjhcbhjpkmknajcpjikiglijfkmmnop, out text);
                        if (flag4)
                        {
                            _bl1.FailedConnection(null);
                        }
                        else
                        {
                            _bj9 mcknonjhcbhjpkmknajcpjikiglijfkmmnop2;
                            bool flag5 = !_bi4.GetCurrent(out mcknonjhcbhjpkmknajcpjikiglijfkmmnop2) || mcknonjhcbhjpkmknajcpjikiglijfkmmnop.CompareTo(mcknonjhcbhjpkmknajcpjikiglijfkmmnop2) > 0;
                            if (flag5)
                            {
                                string @string = EditorPrefs.GetString("LastWebVersionChecked", "");
                                bool flag6 = _bl1.AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE || !@string.Equals(mcknonjhcbhjpkmknajcpjikiglijfkmmnop._ABG);
                                if (flag6)
                                {
                                    _bj7.Init(mcknonjhcbhjpkmknajcpjikiglijfkmmnop, text);
                                    EditorPrefs.SetString("LastWebVersionChecked", mcknonjhcbhjpkmknajcpjikiglijfkmmnop._ABG);
                                }
                            }
                            else
                            {
                                _bl1.UpToDate(mcknonjhcbhjpkmknajcpjikiglijfkmmnop2.ToString());
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
                _bl1.NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL = null;
            }
            _bl1.AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE = false;
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bl1.Update));
        }

        // Token: 0x06000399 RID: 921 RVA: 0x000A7A78 File Offset: 0x000A5C78
        private static void UpToDate(string version)
        {
            bool aepkaaeafjndldlpkbhanealgcfnoiclfkie = _bl1.AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE;
            if (aepkaaeafjndldlpkbhanealgcfnoiclfkie)
            {
                EditorUtility.DisplayDialog("SuperEditor Update Check", string.Format("You're up to date!\n\nInstalled Version: {0}\nLatest Version: {0}", version), "Ok");
            }
        }

        // Token: 0x0600039A RID: 922 RVA: 0x000A7AAC File Offset: 0x000A5CAC
        private static void FailedConnection(string error = null)
        {
            bool aepkaaeafjndldlpkbhanealgcfnoiclfkie = _bl1.AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE;
            if (aepkaaeafjndldlpkbhanealgcfnoiclfkie)
            {
                EditorUtility.DisplayDialog("SuperEditor Update Check", (error == null) ? "Failed to connect to server!" : string.Format("Failed to connect to server!\n\n{0}", error.ToString()), "Ok");
            }
        }

        // Token: 0x0400040D RID: 1037
        private static WWW NEOJKEJIPAGOFOPPFHADHOFKGMAGENJECGIL;

        // Token: 0x0400040E RID: 1038
        private static bool AEPKAAEAFJNDLDLPKBHANEALGCFNOICLFKIE;
    }
}
