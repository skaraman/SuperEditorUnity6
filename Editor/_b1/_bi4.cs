using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AHO
{
    // Token: 0x02000074 RID: 116
    internal static class _bi4
    {
        // Token: 0x0600039B RID: 923 RVA: 0x000A7AF0 File Offset: 0x000A5CF0
        public static bool GetAboutEntry(out _bl3 about)
        {
            about = null;
            string[] files = Directory.GetFiles("./Assets", "SuperEditorInfo.txt", SearchOption.AllDirectories);
            bool flag = files == null || files.Length < 1;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    bool flag3 = about != null;
                    if (flag3)
                    {
                        break;
                    }
                    about = _bi4.ParseAboutEntry(files[i]);
                }
                flag2 = about != null;
            }
            return flag2;
        }

        // Token: 0x0600039C RID: 924 RVA: 0x000A7B60 File Offset: 0x000A5D60
        internal static bool GetCurrent(out _bj9 version)
        {
            _bl3 _yd6;
            bool flag = !_bi4.GetAboutEntry(out _yd6);
            bool flag2;
            if (flag)
            {
                version = default(_bj9);
                flag2 = false;
            }
            else
            {
                version = _bj9.FromString(_yd6._zk5);
                flag2 = true;
            }
            return flag2;
        }

        // Token: 0x0600039D RID: 925 RVA: 0x000A7BA0 File Offset: 0x000A5DA0
        internal static bool FormatChangelog(string raw, out _bj9 version, out string formatted_changes)
        {
            bool flag = true;
            string[] array = Regex.Split(raw, "(?!mi)^#\\s", RegexOptions.Multiline);
            try
            {
                Match match = Regex.Match(array[1], "(?<=^SuperEditor\\s).[0-9]*\\.[0-9]*\\.[0-9]*");
                version = _bj9.FromString(match.Success ? match.Value : array[1].Split(new char[] { '\n' })[0]);
            }
            catch
            {
                version = _bj9.FromString("not found");
                flag = false;
            }
            bool flag2;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                string[] array2 = array[1].Trim().Split(new char[] { '\n' });
                for (int i = 2; i < array2.Length; i++)
                {
                    stringBuilder.AppendLine(array2[i]);
                }
                formatted_changes = stringBuilder.ToString();
                formatted_changes = Regex.Replace(formatted_changes, "^-", "•", RegexOptions.Multiline);
                formatted_changes = Regex.Replace(formatted_changes, "(?<=^##\\\\s).*", "<size=16><b>${0}</b></size>", RegexOptions.Multiline);
                formatted_changes = Regex.Replace(formatted_changes, "^##\\ ", "", RegexOptions.Multiline);
                flag2 = flag;
            }
            catch
            {
                formatted_changes = "";
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x0600039E RID: 926 RVA: 0x000A7CD4 File Offset: 0x000A5ED4
        private static _bl3 ParseAboutEntry(string path)
        {
            bool flag = !File.Exists(path);
            _bl3 _yd6;
            if (flag)
            {
                _yd6 = null;
            }
            else
            {
                _bl3 _yh8 = new _bl3();
                string[] array = File.ReadAllLines(path);
                foreach (string text in array)
                {
                    bool flag2 = text.StartsWith("name: ");
                    if (flag2)
                    {
                        _yh8._AW = text.Replace("name: ", "").Trim();
                    }
                    else
                    {
                        bool flag3 = text.StartsWith("identifier: ");
                        if (flag3)
                        {
                            _yh8._zk4 = text.Replace("identifier: ", "").Trim();
                        }
                        else
                        {
                            bool flag4 = text.StartsWith("version: ");
                            if (flag4)
                            {
                                _yh8._zk5 = text.Replace("version: ", "").Trim();
                            }
                            else
                            {
                                bool flag5 = text.StartsWith("date: ");
                                if (flag5)
                                {
                                    _yh8._zk6 = text.Replace("date: ", "").Trim();
                                }
                                else
                                {
                                    bool flag6 = text.StartsWith("changelog: ");
                                    if (flag6)
                                    {
                                        _yh8._zk7 = text.Replace("changelog: ", "").Trim();
                                    }
                                }
                            }
                        }
                    }
                }
                _yd6 = _yh8;
            }
            return _yd6;
        }
    }
}
