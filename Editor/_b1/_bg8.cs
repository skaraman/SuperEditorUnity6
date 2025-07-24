using System;
using ODGL;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000004 RID: 4
    internal static class _bg8
    {
        // Token: 0x06000005 RID: 5 RVA: 0x00002138 File Offset: 0x00000338
        private static _bf5 Create(string key, bool defaultValue)
        {
            return new _bf5(key, defaultValue);
        }

        // Token: 0x06000006 RID: 6 RVA: 0x00002154 File Offset: 0x00000354
        private static _bb2 Create(string key, int defaultValue)
        {
            return new _bb2(key, defaultValue);
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002170 File Offset: 0x00000370
        private static _bf2 Create(string key, float defaultValue)
        {
            return new _bf2(key, defaultValue);
        }

        // Token: 0x06000008 RID: 8 RVA: 0x0000218C File Offset: 0x0000038C
        private static _bg5 Create(string key, string defaultValue)
        {
            return new _bg5(key, defaultValue);
        }

        // Token: 0x06000009 RID: 9 RVA: 0x000021A5 File Offset: 0x000003A5
        internal static void SaveSettings()
        {
            _bi2.RepaintAllInstances();
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002704 File Offset: 0x00000904
        [PreferenceItem("Super Editor")]
        private static void SettingsGUI()
        {
            EditorGUILayout.Space();
            int num = GUILayout.Toolbar(_bg8._AZS, _bg8._AZT, _bg8._AVA._AZU, Array.Empty<GUILayoutOption>());
            bool flag = num != _bg8._AZS;
            if (flag)
            {
                _bg8._AZS = num;
                EditorPrefs.SetInt("Vik.SuperEditor.SettingsMode", _bg8._AZS);
            }
            EditorGUILayout.Space();
            switch (_bg8._AZS)
            {
                case 0:
                    _bg8.General();
                    break;
                case 1:
                    _bg8.View();
                    break;
                case 2:
                    _bg8.Hierarchy();
                    break;
            }
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002794 File Offset: 0x00000994
        internal static void View()
        {
            bool flag = Application.platform == 0;
            _bg8._AZV = 275f;
            _bg8._AZW = GUILayout.BeginScrollView(_bg8._AZW, Array.Empty<GUILayoutOption>());
            GUILayout.Label("Highlighting", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Frame Current Line", _bg8._AZX, true, null);
            _bg8.Draw("Highlight Current Line", _bg8._AZY, true, null);
            EditorGUILayout.Space();
            _bg8._AZV = 275f;
            GUILayout.Label("Word Wrap", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Scripts & Shaders", _bg8._AZZ, true, null);
            _bg8.Draw("Text & Other Assets", _bg8._BAA, true, null);
            EditorGUILayout.Space();
            GUILayout.Label("Show Line Numbers", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Scripts & Shaders", _bg8._BAB, true, null);
            _bg8.Draw("Text & Other Assets", _bg8._BAC, true, null);
            EditorGUILayout.Space();
            GUILayout.Label("Track Changes", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Scripts & Shaders", _bg8._BAD, true, null);
            _bg8.Draw("Text & Other Assets", _bg8._BAE, true, null);
            EditorGUILayout.Space();
            GUILayout.Label("C# Code", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Use Neutral Colors in Popups", _bg8._BAF, true, null);
            _bg8.Draw("Reference Highlighting", _bg8._BAG, true, null);
            _bg8.Draw("Keep Last Highlighted Symbol", _bg8._BAH, true, null);
            _bg8.Draw("Highlight Writes in Red", _bg8._BAI, true, null);
            _bg8.Draw("Inspect Values of Properties", _bg8._BAJ, true, null);
            EditorGUILayout.HelpBox("Inspecting values of properties will slow down Tooltip", _bg8._BAJ ? MessageType.Warning : MessageType.Info, true);
            GUILayout.Label("More Options...", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Show thicker caret", _bg8._BAK, true, null);
            bool flag2 = flag;
            if (flag2)
            {
                _bg8.Draw("Use Cmd+MouseWheel to change font size", _bg8._BAL, true, null);
            }
            else
            {
                _bg8.Draw("Use Ctrl+MouseWheel to change font size", _bg8._BAL, true, null);
            }
            EditorGUILayout.Space();
            EditorGUILayout.EndScrollView();
        }

        // Token: 0x0600000D RID: 13 RVA: 0x000029B8 File Offset: 0x00000BB8
        internal static void General()
        {
            _bg8._BAM = GUILayout.BeginScrollView(_bg8._BAM, Array.Empty<GUILayoutOption>());
            _bg8._AZV = 275f;
            GUILayout.Label("Workflow Mode", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Quick Mode", _bg8.EAIK, true, null);
            bool flag = _bg8.EAIK.GNIO();
            if (flag)
            {
                _bg8._AGA._AIF(false);
                _bg8._BAN._AIF(false);
                _bg8._AKN._AIF(false);
                _bg8._AKM._AIF(true);
            }
            else
            {
                _bg8._AGA._AIF(true);
                _bg8._BAN._AIF(true);
                _bg8._AKN._AIF(true);
                _bg8._AKM._AIF(false);
            }
            _bg8.Draw("Old Mode", _bg8._BAN, true, null);
            bool flag2 = _bg8._BAN.GNIO();
            if (flag2)
            {
                _bg8._AGA._AIF(true);
                _bg8.EAIK._AIF(false);
                _bg8._AKN._AIF(true);
                _bg8._AKM._AIF(false);
            }
            else
            {
                _bg8._AGA._AIF(false);
                _bg8.EAIK._AIF(true);
                _bg8._AKN._AIF(false);
                _bg8._AKM._AIF(true);
            }
            bool flag3 = _bg8._BAN.GNIO();
            if (flag3)
            {
                EditorGUILayout.HelpBox("Old Mode takes the traditional Unity workflow mode of double-clicking the script to open the external IDE and only upgrades Unity Inspector's display", _bg8._BBD ? MessageType.Warning : MessageType.Info, true);
            }
            EditorGUILayout.Space();
            GUILayout.Label("Editor Keyboard", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Show Tooltip on 'Esc' key", _bg8._BAO, true, null);
            _bg8.Draw("Copy/Cut full line if no selection", _bg8._BAP, true, null);
            _bg8.Draw("Place semicolon Automatically", _bg8._BAQ, true, null);
            EditorGUILayout.Space();
            GUILayout.Label("Tabs", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Auto indent", _bg8._AUT, true, null);
            _bg8._AZV = 275f;
            _bg8.Draw("Tab size", _bg8._ASA, 1, 8, true);
            _bg8._AZV = 275f;
            EditorGUILayout.Space();
            GUILayout.Label("Toolbar", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Enable Toolbar", _bg8._BAR, true, null);
            bool flag4 = !_bg8._BAR;
            if (flag4)
            {
                GUI.enabled = false;
            }
            _bg8.Draw("Show Last Modified Time", _bg8._BAS, true, null);
            bool flag5 = _bg8._BAS;
            if (flag5)
            {
                _bf5 _BAT = _bg8._BAU;
                bool flag6;
                _bg8._BAV._AIF(flag6 = false);
                _BAT._AIF(flag6);
            }
            _bg8.Draw("Show File Path", _bg8._BAU, true, null);
            bool flag7 = _bg8._BAU;
            if (flag7)
            {
                _bf5 _BAW = _bg8._BAS;
                bool flag6;
                _bg8._BAV._AIF(flag6 = false);
                _BAW._AIF(flag6);
            }
            _bg8.Draw("Show File Size", _bg8._BAV, true, null);
            bool flag8 = _bg8._BAV;
            if (flag8)
            {
                _bf5 _BAT2 = _bg8._BAU;
                bool flag6;
                _bg8._BAS._AIF(flag6 = false);
                _BAT2._AIF(flag6);
            }
            bool flag9 = !_bg8._BAR;
            if (flag9)
            {
                GUI.enabled = true;
            }
            EditorGUILayout.Space();
            GUILayout.Label("Navigation bar", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Enable Navigation bar", _bg8._BAX, true, null);
            _bg8.Draw("Hide Namespace", _bg8._BAY, true, null);
            _bg8.Draw("Sort Symbols Alphabetically", _bg8._BAZ, true, null);
            _bg8.Draw("Group Symbols by #region", _bg8._BBA, true, null);
            EditorGUILayout.Space();
            GUILayout.Label("Unity Magic Methods", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Insert with comments", _bg8._BBB, true, null);
            _bg8.Draw("Opening brace on same line", _bg8._BBC, true, null);
            EditorGUILayout.Space();
            GUILayout.Label("More Options...", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Boost text/reference search speed", _bg8._BBD, true, null);
            EditorGUILayout.HelpBox("Enable it can nearly double the speed of text/reference searches, but can cause unity editor to stall during the search", _bg8._BBD ? MessageType.Warning : MessageType.Info, true);
            bool flag10 = !_bg8.EAIK;
            if (flag10)
            {
                _bg8.Draw("Enable Inspector View", _bg8._AGA, true, null);
            }
            _bg8.Draw("Smooth scrolling", _bg8._BBE, true, null);
            _bg8.Draw("Use Local Unity Documentation", _bg8._BBF, true, null);
            _bg8.Draw("Move opening brace on empty line", _bg8._BBG, true, null);
            EditorGUILayout.Space();
            EditorGUILayout.EndScrollView();
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002E44 File Offset: 0x00001044
        internal static void Hierarchy()
        {
            _bg8._BBH = GUILayout.BeginScrollView(_bg8._BBH, Array.Empty<GUILayoutOption>());
            GUILayout.Label("Display Kinds", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Visibility", HierarchySetting.ShowVisibility);
            _bg8.Draw("Components", HierarchySetting.ShowComponents);
            _bg8.Draw("Separator", HierarchySetting.ShowSeparatorComponent);
            _bg8.Draw("Static", HierarchySetting.ShowStaticComponent);
            _bg8.Draw("Error", HierarchySetting.ShowErrorComponent);
            _bg8.Draw("Renderer State", HierarchySetting.ShowRendererComponent);
            _bg8.Draw("Prefab State", HierarchySetting.ShowPrefabComponent);
            _bg8.Draw("Tag And Layer", HierarchySetting.ShowTagLayerComponent);
            _bg8.Draw("Children Count", HierarchySetting.ShowChildrenCountComponent);
            EditorGUILayout.Space();
            GUILayout.Label("More Options...", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
            _bg8.Draw("Hide Icons If Not Fit", HierarchySetting.HideIconsIfNotFit);
            _bg8.Draw("Left-click Icon Enable/Disable Component", HierarchySetting.LeftclickEnableComponent);
            int num = _f5.GetInstance().Get<int>(HierarchySetting.Identation);
            int num2 = EditorGUILayout.IntSlider("Right Indent", num, 0, 100, Array.Empty<GUILayoutOption>());
            bool flag = num2 != num;
            if (flag)
            {
                _f5.GetInstance().Set<int>(HierarchySetting.Identation, num2);
            }
            EditorGUILayout.Space();
            EditorGUILayout.EndScrollView();
        }

        // Token: 0x0600000F RID: 15 RVA: 0x00002F65 File Offset: 0x00001165
        private static void Draw(string label, _bf5 option1, _bf5 option2)
        {
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            _bg8.Draw(label, option1, true, null);
            _bg8.Draw(null, option2, true, null);
            GUILayout.EndHorizontal();
        }

        // Token: 0x06000010 RID: 16 RVA: 0x00002F90 File Offset: 0x00001190
        private static bool Draw(string label, _bf5 option, bool enabled = true, GUIStyle style = null)
        {
            EditorGUIUtility.labelWidth = ((label == null) ? 35f : _bg8._AZV);
            bool enabled2 = GUI.enabled;
            bool flag = !enabled;
            if (flag)
            {
                GUI.enabled = false;
            }
            bool flag2 = style != null;
            if (flag2)
            {
                option._AIF(EditorGUILayout.Toggle(label, option.GNIO(), style, Array.Empty<GUILayoutOption>()));
            }
            else
            {
                option._AIF(EditorGUILayout.Toggle(label, option.GNIO(), Array.Empty<GUILayoutOption>()));
            }
            bool flag3 = !enabled;
            if (flag3)
            {
                GUI.enabled = enabled2;
            }
            return option;
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00003020 File Offset: 0x00001220
        private static void Draw(string label, HierarchySetting setting)
        {
            EditorGUIUtility.labelWidth = ((label == null) ? 35f : _bg8._AZV);
            bool flag = _f5.GetInstance().Get<bool>(setting);
            bool flag2 = EditorGUILayout.Toggle(label, flag, Array.Empty<GUILayoutOption>());
            _f5.GetInstance().Set<bool>(setting, flag2);
        }

        // Token: 0x06000012 RID: 18 RVA: 0x0000306C File Offset: 0x0000126C
        private static int Draw(string label, _bb2 option, int min, int max, bool enabled = true)
        {
            bool enabled2 = GUI.enabled;
            bool flag = !enabled;
            if (flag)
            {
                GUI.enabled = false;
            }
            option._AIF(EditorGUILayout.IntSlider(label, option.GNIO(), min, max, Array.Empty<GUILayoutOption>()));
            bool flag2 = !enabled;
            if (flag2)
            {
                GUI.enabled = enabled2;
            }
            return option;
        }

        // Token: 0x04000001 RID: 1
        internal static _bf5 _BBI = _bg8.Create("AlwaysFalse", false);

        // Token: 0x04000002 RID: 2
        internal static _bb2 _BBJ = _bg8.Create("ExpandTabTitles", 1);

        // Token: 0x04000003 RID: 3
        internal static _bf5 _BAS = _bg8.Create("ShowLastModifiedTime", true);

        // Token: 0x04000004 RID: 4
        internal static _bf5 _BAU = _bg8.Create("ShowFilePath", false);

        // Token: 0x04000005 RID: 5
        internal static _bf5 _BAV = _bg8.Create("ShowFileSize", false);

        // Token: 0x04000006 RID: 6
        internal static _bf5 _BAZ = _bg8.Create("NavToolbarSortByName", false);

        // Token: 0x04000007 RID: 7
        internal static _bf5 _BBA = _bg8.Create("NavToolbarGroupByRegion", true);

        // Token: 0x04000008 RID: 8
        internal static _bf5 _BBK = _bg8.Create("NavToolbarGroupNonMethods", true);

        // Token: 0x04000009 RID: 9
        internal static _bf5 _BAX = _bg8.Create("EnableNavigationbar", true);

        // Token: 0x0400000A RID: 10
        internal static _bf5 _BAY = _bg8.Create("HideNamespace", true);

        // Token: 0x0400000B RID: 11
        internal static _bf5 _BAR = _bg8.Create("EnableToolbar", true);

        // Token: 0x0400000C RID: 12
        internal static _bf5 _BAF = _bg8.Create("UseStdColorsInPopups", false);

        // Token: 0x0400000D RID: 13
        internal static _bf5 _BAK = _bg8.Create("ShowThickerCaret", false);

        // Token: 0x0400000E RID: 14
        internal static _bf5 _BBL = _bg8.Create("MonospacedFontConsole", false);

        // Token: 0x0400000F RID: 15
        internal static _bf5 EAIK = _bg8.Create("QuickMode", true);

        // Token: 0x04000010 RID: 16
        internal static _bf5 _BAN = _bg8.Create("OldMode", false);

        // Token: 0x04000011 RID: 17
        internal static _bf5 _AKM = _bg8.Create("OpenInternal", true);

        // Token: 0x04000012 RID: 18
        internal static _bf5 _AKN = _bg8.Create("OpenExternal", false);

        // Token: 0x04000013 RID: 19
        internal static _bf5 _AKR = _bg8.Create("HandleOpenFromProject", true);

        // Token: 0x04000014 RID: 20
        internal static _bf5 _AKP = _bg8.Create("HandleOpenShaderFromProject", true);

        // Token: 0x04000015 RID: 21
        internal static _bf5 _AKO = _bg8.Create("HandleOpenTextFromProject", true);

        // Token: 0x04000016 RID: 22
        internal static _bf5 _AZY = _bg8.Create("HighlightCurrentLine", true);

        // Token: 0x04000017 RID: 23
        internal static _bf2 _BBM = _bg8.Create("HighlightCurrentLineAlpha", 0.5f);

        // Token: 0x04000018 RID: 24
        internal static _bf5 _AZX = _bg8.Create("FrameCurrentLine", true);

        // Token: 0x04000019 RID: 25
        internal static _bf5 _BAB = _bg8.Create("LineNumbersCode", true);

        // Token: 0x0400001A RID: 26
        internal static _bf5 _BBN = _bg8.Create("LineNumbersCodeInspector", false);

        // Token: 0x0400001B RID: 27
        internal static _bf5 _BAC = _bg8.Create("LineNumbersText", false);

        // Token: 0x0400001C RID: 28
        internal static _bf5 _BBO = _bg8.Create("LineNumbersTextInspector", false);

        // Token: 0x0400001D RID: 29
        internal static _bf5 _BAD = _bg8.Create("TrackChangesCode", true);

        // Token: 0x0400001E RID: 30
        internal static _bf5 _BBP = _bg8.Create("TrackChangesCodeInspector", false);

        // Token: 0x0400001F RID: 31
        internal static _bf5 _BAE = _bg8.Create("TrackChangesText", true);

        // Token: 0x04000020 RID: 32
        internal static _bf5 _BBQ = _bg8.Create("TrackChangesTextInspector", false);

        // Token: 0x04000021 RID: 33
        internal static _bf5 _AZZ = _bg8.Create("WordWrapCode", false);

        // Token: 0x04000022 RID: 34
        internal static _bf5 _BBR = _bg8.Create("WordWrapCodeInspector", true);

        // Token: 0x04000023 RID: 35
        internal static _bf5 _BAA = _bg8.Create("WordWrapText", false);

        // Token: 0x04000024 RID: 36
        internal static _bf5 _BBS = _bg8.Create("WordWrapTextInspector", true);

        // Token: 0x04000025 RID: 37
        internal static _bg5 _BBT = _bg8.Create("EditorFont", "Fonts/PTMono.ttc");

        // Token: 0x04000026 RID: 38
        internal static _bf5 _BBU = _bg8.Create("FontHinting", true);

        // Token: 0x04000027 RID: 39
        internal static _bb2 _AEP = _bg8.Create("FontSizeDelta", -2);

        // Token: 0x04000028 RID: 40
        internal static _bb2 _BBV = _bg8.Create("FontSizeDeltaInspector", -2);

        // Token: 0x04000029 RID: 41
        internal static _bf5 _BAL = _bg8.Create("ChangeFontSizeUsingWheel", true);

        // Token: 0x0400002A RID: 42
        internal static _bg5 _BBW = _bg8.Create("ThemeNameCode", EditorGUIUtility.isProSkin ? "VS Dark with VA X" : "Xcode");

        // Token: 0x0400002B RID: 43
        internal static _bg5 _BBX = _bg8.Create("ThemeNameText", EditorGUIUtility.isProSkin ? "VS Dark with VA X" : "Xcode");

        // Token: 0x0400002C RID: 44
        internal static _bf5 _BBY = _bg8.Create("AutoReloadAssemblies", true);

        // Token: 0x0400002D RID: 45
        internal static _bf5 _BBZ = _bg8.Create("CompileOnSave", true);

        // Token: 0x0400002E RID: 46
        internal static _bf5 _BCA = _bg8.Create("CancelReloadOnEdit", true);

        // Token: 0x0400002F RID: 47
        internal static _bf5 _ARW = _bg8.Create("AlwaysKeepInMemory", false);

        // Token: 0x04000030 RID: 48
        internal static _bf5 _BAG = _bg8.Create("ReferenceHighlighting", true);

        // Token: 0x04000031 RID: 49
        internal static _bf5 _BAH = _bg8.Create("KeepLastHighlight", true);

        // Token: 0x04000032 RID: 50
        internal static _bf5 _BAI = _bg8.Create("HighlightWritesInRed", true);

        // Token: 0x04000033 RID: 51
        internal static _bf5 _BBF = _bg8.Create("UseLocalUnityDocumentation", true);

        // Token: 0x04000034 RID: 52
        internal static _bf5 _BBD = _bg8.Create("BoostSearchSpeed", false);

        // Token: 0x04000035 RID: 53
        internal static _bf5 _AGA = _bg8.Create("EnableInspectorView", true);

        // Token: 0x04000036 RID: 54
        internal static _bf5 _BAP = _bg8.Create("CopyCutFullLine", true);

        // Token: 0x04000037 RID: 55
        internal static _bf5 _BAQ = _bg8.Create("SmartSemicolonPlacement", true);

        // Token: 0x04000038 RID: 56
        internal static _bf5 _BCB = _bg8.Create("LoopSearchResults", true);

        // Token: 0x04000039 RID: 57
        internal static _bf5 _BBE = _bg8.Create("smoothScrolling3", true);

        // Token: 0x0400003A RID: 58
        internal static _bf5 _BCC = _bg8.Create("XcodeMode", false);

        // Token: 0x0400003B RID: 59
        internal static _bf5 _BCD = _bg8.Create("sortRegionsByName", false);

        // Token: 0x0400003C RID: 60
        internal static _bf5 _BAO = _bg8.Create("OpenAutoCompleteOnEscape", true);

        // Token: 0x0400003D RID: 61
        internal static _bf5 _AEA = _bg8.Create("AutoCompleteAggressively", true);

        // Token: 0x0400003E RID: 62
        internal static _bf5 _BCE = _bg8.Create("CaptureShiftCtrlF", true);

        // Token: 0x0400003F RID: 63
        internal static _bf5 _BCF = _bg8.Create("WordBreak_UseBothModifiers", Application.platform == 0);

        // Token: 0x04000040 RID: 64
        internal static _bf5 _BCG = _bg8.Create("WordBreak_StopOnSubwords", Application.platform == 0);

        // Token: 0x04000041 RID: 65
        internal static _bf5 _ATS = _bg8.Create("WordBreak_IgnorePunctuations", Application.platform == 0);

        // Token: 0x04000042 RID: 66
        internal static _bf5 _ATT = _bg8.Create("WordBreak_RightArrowStopsAtWordEnd", Application.platform == 0);

        // Token: 0x04000043 RID: 67
        internal static _bf5 _BBB = _bg8.Create("MagicMethods.InsertWithComments", true);

        // Token: 0x04000044 RID: 68
        internal static _bf5 _BBC = _bg8.Create("MagicMethods.OpeningBraceOnSameLine", false);

        // Token: 0x04000045 RID: 69
        internal static _bf5 _AUT = _bg8.Create("AutoIndent", true);

        // Token: 0x04000046 RID: 70
        internal static _bb2 _ASA = _bg8.Create("TabSize", 4);

        // Token: 0x04000047 RID: 71
        internal static _bf5 _AUG = _bg8.Create("InsertSpacesOnTab", false);

        // Token: 0x04000048 RID: 72
        internal static _bf5 _BCH = _bg8.Create("GroupFindResultsByFile", true);

        // Token: 0x04000049 RID: 73
        internal static _bf5 _BAJ = _bg8.Create("InspectPropertyValues", false);

        // Token: 0x0400004A RID: 74
        internal static _bf5 _BCI = _bg8.Create("tripleclickSelectsFullLine", true);

        // Token: 0x0400004B RID: 75
        internal static _bf5 _BBG = _bg8.Create("moveOpeningBraceOnEmptyLine", true);

        // Token: 0x0400004C RID: 76
        private static float _AZV = 200f;

        // Token: 0x0400004D RID: 77
        internal static readonly GUIContent[] _AZT = new GUIContent[]
        {
            new GUIContent("General"),
            new GUIContent("View"),
            new GUIContent("Hierarchy")
        };

        // Token: 0x0400004E RID: 78
        internal static int _AZS = EditorPrefs.GetInt("Vik.SuperEditor.SettingsMode", 0);

        // Token: 0x0400004F RID: 79
        private static Vector2 _AZW;

        // Token: 0x04000050 RID: 80
        private static Vector2 _BAM;

        // Token: 0x04000051 RID: 81
        private static Vector2 _BBH;

        // Token: 0x02000005 RID: 5
        internal static class _AVA
        {
            // Token: 0x04000052 RID: 82
            internal static GUIStyle _AZU = "LargeButton";
        }
    }
}
