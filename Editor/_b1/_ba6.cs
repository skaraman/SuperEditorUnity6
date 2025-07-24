using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000031 RID: 49
    internal class _ba6 : AssetPostprocessor
    {
        // Token: 0x0600016F RID: 367 RVA: 0x0001448C File Offset: 0x0001268C
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            bool flag = _ba6._AGF() == null;
            if (!flag)
            {
                string path = _ba6.GetSnippetsPath();
                bool flag2 = path == null;
                if (!flag2)
                {
                    Predicate<string> predicate = (string x) => x.StartsWith(path, StringComparison.OrdinalIgnoreCase);
                    bool flag3 = Array.Exists<string>(importedAssets, predicate) || Array.Exists<string>(deletedAssets, predicate) || Array.Exists<string>(movedAssets, predicate) || Array.Exists<string>(movedFromAssetPaths, predicate);
                    if (flag3)
                    {
                        _ba6.Reload();
                    }
                    _ba6._AGG = null;
                }
            }
        }

        // Token: 0x06000170 RID: 368 RVA: 0x00014510 File Offset: 0x00012710
        private static Dictionary<string, string> _AGF()
        {
            bool flag = _ba6._AGG == null;
            if (flag)
            {
                _ba6.Reload();
            }
            return _ba6._AGG;
        }

        // Token: 0x06000171 RID: 369 RVA: 0x00014539 File Offset: 0x00012739
        private static void _AGH(Dictionary<string, string> value)
        {
            _ba6._AGG = value;
        }

        // Token: 0x06000172 RID: 370 RVA: 0x00014544 File Offset: 0x00012744
        internal static string Get(string shortcut, _bh4 context, _bh2._AGI expected)
        {
            string text;
            bool flag = !_ba6._AGF().TryGetValue(shortcut, out text);
            string text2;
            if (flag)
            {
                text2 = null;
            }
            else
            {
                bool flag2 = !_ba6.IsValid(ref text, context, expected);
                if (flag2)
                {
                    text2 = null;
                }
                else
                {
                    text2 = text;
                }
            }
            return text2;
        }

        // Token: 0x06000173 RID: 371 RVA: 0x00014583 File Offset: 0x00012783
        internal static IEnumerable<_be5> EnumSnippets(_bh4 context, _bh2._AGI expected, SyntaxToken tokenLeft, _bm6 scope)
        {
            foreach (KeyValuePair<string, string> snippet in _ba6._AGF())
            {
                string text = snippet.Value;
                bool flag = _ba6.IsValid(ref text, context, expected);
                if (flag)
                {
                    yield return new _be5(snippet.Key + "...");
                }
                text = null;
                // snippet = default(KeyValuePair<string, string>);
            }
            Dictionary<string, string>.Enumerator enumerator = default(Dictionary<string, string>.Enumerator);
            bool flag2 = _ba6._AGJ == null;
            if (flag2)
            {
                _ba6._AGJ = new List<_bb8>();
                Type[] types = typeof(_ba6).Assembly.GetTypes();
                foreach (Type type in types)
                {
                    bool flag3 = typeof(_bb8).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;
                    if (flag3)
                    {
                        try
                        {
                            _bb8 instance = Activator.CreateInstance(type) as _bb8;
                            _ba6._AGJ.Add(instance);
                            instance = null;
                        }
                        catch (Exception ex)
                        {
                            Exception e = ex;
                            Debug.LogException(e);
                        }
                    }
                }
            }
            foreach (_bb8 snippetsProvider in _ba6._AGJ)
            {
                foreach (_be5 snippet2 in snippetsProvider.EnumSnippets(context, expected, tokenLeft, scope))
                {
                    yield return snippet2;
                }

            }
            yield break;
        }

        // Token: 0x06000174 RID: 372 RVA: 0x000145A8 File Offset: 0x000127A8
        internal static void Substitute(ref string part, _bh4 context)
        {
            _bb3 _AAN = context as _bb3;
            int num = 0;
            while ((num = part.IndexOf('$', num)) != -1)
            {
                int num2 = part.IndexOf('$', num + 1);
                bool flag = num2 > num;
                if (flag)
                {
                    string text = part.Substring(num + 1, num2 - num - 1);
                    part = part.Remove(num, num2 - num + 1);
                    string text2 = text;
                    string text3 = text2;
                    if (!(text3 == "MethodName"))
                    {
                        if (!(text3 == "ArgumentList"))
                        {
                            goto IL_00DE;
                        }
                        bool flag2 = _AAN == null;
                        if (flag2)
                        {
                            goto IL_00DE;
                        }
                        part = part.Insert(num, string.Join(", ", (from p in _AAN.GetParameters()
                                                                   select (p._AGK() ? "out " : (p._AGL() ? "ref " : "")) + p.GetName()).ToArray<string>()));
                    }
                    else
                    {
                        bool flag3 = _AAN == null;
                        if (flag3)
                        {
                            goto IL_00DE;
                        }
                        part = part.Insert(num, _AAN._AW);
                    }
                    continue;
                IL_00DE:
                    part = part.Insert(num, text);
                }
            }
        }

        // Token: 0x06000175 RID: 373 RVA: 0x000146C0 File Offset: 0x000128C0
        internal static bool IsValid(ref string expanded, _bh4 context, _bh2._AGI expected)
        {
            _bb3 _AAN = context as _bb3;
            bool flag = false;
            int num = 0;
            while ((num = expanded.IndexOf('$', num)) != -1)
            {
                int num2 = expanded.IndexOf('$', num + 1);
                bool flag2 = num2 < num;
                if (flag2)
                {
                    break;
                }
                string text = expanded.Substring(num + 1, num2 - num - 1);
                string text2 = text;
                string text3 = text2;
                uint num3 = Helper.ComputeStringHash(text3);
                if (num3 <= 2084867459U)
                {
                    if (num3 <= 1291874642U)
                    {
                        if (num3 != 424432139U)
                        {
                            if (num3 != 479137373U)
                            {
                                if (num3 == 1291874642U)
                                {
                                    if (text3 == "NamespaceMember")
                                    {
                                        bool flag3 = expected != null && !expected.Matches(_bm2._AGM()._AGN);
                                        if (flag3)
                                        {
                                            return false;
                                        }
                                        expanded = expanded.Remove(num, num2 - num + 2);
                                        continue;
                                    }
                                }
                            }
                            else if (text3 == "ClassMember")
                            {
                                bool flag4 = expected != null && !expected.Matches(_bm2._AGM()._AGO);
                                if (flag4)
                                {
                                    return false;
                                }
                                expanded = expanded.Remove(num, num2 - num + 2);
                                continue;
                            }
                        }
                        else if (text3 == "InProperty")
                        {
                            bool flag5 = context == null || (context._AT != SymbolKind.Property && (context._AO == null || context._AO._AT != SymbolKind.Property));
                            if (flag5)
                            {
                                return false;
                            }
                            expanded = expanded.Remove(num, num2 - num + 2);
                            continue;
                        }
                    }
                    else if (num3 != 1322532022U)
                    {
                        if (num3 != 1594101747U)
                        {
                            if (num3 == 2084867459U)
                            {
                                if (text3 == "NotStatement")
                                {
                                    bool flag6 = expected != null && expected.Matches(_bm2._AGM()._AGP);
                                    if (flag6)
                                    {
                                        return false;
                                    }
                                    expanded = expanded.Remove(num, num2 - num + 2);
                                    continue;
                                }
                            }
                        }
                        else if (text3 == "InMethod")
                        {
                            bool flag7 = _AAN == null;
                            if (flag7)
                            {
                                return false;
                            }
                            expanded = expanded.Remove(num, num2 - num + 2);
                            continue;
                        }
                    }
                    else if (text3 == "Statement")
                    {
                        bool flag8 = expected != null && !expected.Matches(_bm2._AGM()._AGP);
                        if (flag8)
                        {
                            return false;
                        }
                        expanded = expanded.Remove(num, num2 - num + 2);
                        continue;
                    }
                }
                else if (num3 <= 3454125988U)
                {
                    if (num3 != 2776659443U)
                    {
                        if (num3 != 3275460354U)
                        {
                            if (num3 != 3454125988U)
                            {
                                goto IL_047B;
                            }
                            if (!(text3 == "Keyword"))
                            {
                                goto IL_047B;
                            }
                            flag = true;
                            expanded = expanded.Remove(num, num2 - num + 2);
                            continue;
                        }
                        else if (!(text3 == "ArgumentList"))
                        {
                            goto IL_047B;
                        }
                    }
                    else if (!(text3 == "MethodName"))
                    {
                        goto IL_047B;
                    }
                    bool flag9 = _AAN == null;
                    if (flag9)
                    {
                        return false;
                    }
                }
                else if (num3 != 3957975170U)
                {
                    if (num3 != 4081372523U)
                    {
                        if (num3 == 4179089490U)
                        {
                            if (text3 == "StructMember")
                            {
                                bool flag10 = expected != null && !expected.Matches(_bm2._AGM()._AGQ);
                                if (flag10)
                                {
                                    return false;
                                }
                                expanded = expanded.Remove(num, num2 - num + 2);
                                continue;
                            }
                        }
                    }
                    else if (text3 == "TypeDeclaration")
                    {
                        bool flag11 = expected != null && (!expected.Matches(_bm2._AGM()._AGN) && !expected.Matches(_bm2._AGM()._AGO)) && !expected.Matches(_bm2._AGM()._AGQ);
                        if (flag11)
                        {
                            return false;
                        }
                        expanded = expanded.Remove(num, num2 - num + 2);
                        continue;
                    }
                }
                else if (text3 == "InterfaceMember")
                {
                    bool flag12 = expected != null && !expected.Matches(_bm2._AGM()._AGR);
                    if (flag12)
                    {
                        return false;
                    }
                    expanded = expanded.Remove(num, num2 - num + 2);
                    continue;
                }
            IL_047B:
                num = num2 + 1;
            }
            bool flag13 = flag && expected != null;
            if (flag13)
            {
                int num4 = 0;
                while (expanded[num4] >= 'a' && expanded[num4] <= 'z')
                {
                    num4++;
                }
                bool flag14 = num4 == 0;
                if (flag14)
                {
                    bool flag15 = expanded.StartsWith("!=", StringComparison.Ordinal) || expanded.StartsWith("==", StringComparison.Ordinal);
                    if (!flag15)
                    {
                        return false;
                    }
                    num4 = 2;
                }
                string text4 = expanded.Substring(0, num4);
                int num5 = _bm2._AGM().TokenToId(text4);
                bool flag16 = !expected.Matches(num5);
                if (flag16)
                {
                    return false;
                }
            }
            return true;
        }

        // Token: 0x06000176 RID: 374 RVA: 0x00014C24 File Offset: 0x00012E24
        private static string GetSnippetsPath()
        {
            MonoScript monoScript = MonoScript.FromScriptableObject(SuperEditorLocator.Instance());
            bool flag = !monoScript;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                string directoryName = Path.GetDirectoryName(Path.GetDirectoryName(AssetDatabase.GetAssetPath(monoScript)));
                text = directoryName + "/EditorResources/CodeTemplates/";
            }
            return text;
        }

        // Token: 0x06000177 RID: 375 RVA: 0x00014C70 File Offset: 0x00012E70
        private static void Reload()
        {
            _ba6._AGH(new Dictionary<string, string>());
            string snippetsPath = _ba6.GetSnippetsPath();
            bool flag = snippetsPath == null;
            if (!flag)
            {
                string[] files = Directory.GetFiles(snippetsPath, "*.txt");
                foreach (string text in files)
                {
                    TextAsset textAsset = AssetDatabase.LoadAssetAtPath(text, typeof(TextAsset)) as TextAsset;
                    bool flag2 = textAsset == null;
                    if (!flag2)
                    {
                        _ba6._AGF()[textAsset.name] = textAsset.text.Replace("\r\n", "\n").Replace('\r', '\n');
                    }
                }
            }
        }

        // Token: 0x04000193 RID: 403
        private static List<_bb8> _AGJ;

        // Token: 0x04000194 RID: 404
        private static Dictionary<string, string> _AGG;
    }
}
