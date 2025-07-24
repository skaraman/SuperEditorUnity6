using System;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000018 RID: 24
    internal static class _ba2
    {
        // Token: 0x060000C4 RID: 196 RVA: 0x00009D38 File Offset: 0x00007F38
        private static string DecodeWinKey(string key)
        {
            bool flag = key == "";
            string text;
            if (flag)
            {
                text = "";
            }
            else
            {
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                string text2 = "\t";
                int i = 0;
                while (i < key.Length)
                {
                    switch (key[i])
                    {
                        case '#':
                            flag4 = true;
                            break;
                        case '$':
                            goto IL_0069;
                        case '%':
                            flag3 = true;
                            break;
                        case '&':
                            flag2 = true;
                            break;
                        default:
                            goto IL_0069;
                    }
                    i++;
                    continue;
                IL_0069:
                    bool flag5 = flag2;
                    if (flag5)
                    {
                        text2 += "Alt+";
                    }
                    bool flag6 = flag3;
                    if (flag6)
                    {
                        text2 += "Ctrl+";
                    }
                    bool flag7 = flag4;
                    if (flag7)
                    {
                        text2 += "Shift+";
                    }
                    text2 += key.Substring(i).ToUpperInvariant();
                    break;
                }
                text = text2;
            }
            return text;
        }

        // Token: 0x060000C5 RID: 197 RVA: 0x00009E20 File Offset: 0x00008020
        internal static void AddItem(this GenericMenu menu, string osxText, string osxKey, string winText, string winKey, bool on, GenericMenu.MenuFunction func)
        {
            bool flag = Application.platform == 0;
            if (flag)
            {
                menu.AddItem(new GUIContent(osxText + " _" + osxKey), on, func);
            }
            else
            {
                bool flag2 = (int)Application.platform == 16;
                if (flag2)
                {
                    winKey = (winKey.Contains("enter") ? winKey.Replace("enter", "Return") : winKey);
                    winKey = (winKey.Contains("Enter") ? winKey.Replace("Enter", "Return") : winKey);
                    winKey = (winKey.Contains("tab") ? winKey.Replace("tab", "Tab") : winKey);
                    winKey = (winKey.Contains("f12") ? winKey.Replace("f12", "F12") : winKey);
                    winKey = (winKey.Contains("f1") ? winKey.Replace("f1", "F1") : winKey);
                    menu.AddItem(new GUIContent(winText + " _" + winKey), on, func);
                }
                else
                {
                    menu.AddItem(new GUIContent(winText + " _" + winKey), on, func);
                }
            }
        }

        // Token: 0x060000C6 RID: 198 RVA: 0x00009F64 File Offset: 0x00008164
        internal static void AddItem(this GenericMenu menu, string osxText, string osxKey, string winText, string winKey, bool on, GenericMenu.MenuFunction2 func, object userData)
        {
            bool flag = Application.platform == 0;
            if (flag)
            {
                menu.AddItem(new GUIContent(osxText), on, func, userData);
            }
            else
            {
                menu.AddItem(new GUIContent(winText + _ba2.DecodeWinKey(winKey)), on, func, userData);
            }
        }
    }
}
