using System;
using System.IO;
using ACGG;
using SuperEditor.IDE;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000070 RID: 112
    internal class _bj2 : EditorWindow
    {
        // Token: 0x06000389 RID: 905 RVA: 0x000A7038 File Offset: 0x000A5238
        internal static void LoadIcons(bool forDll = false)
        {
            UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(_bj2));
            bool flag = array == null || array.Length == 0;
            if (!flag)
            {
                _bj2._yd4.normal.background = _a2.GetInstance().GetTexture(Base64Texture.AboutBannerNormal);
                _bj2._yd4.hover.background = _bj2._yd4.normal.background;
                _bj2._zx9.normal.background = (_bj2._yd5.normal.background = (_bj2._yd5.hover.background = _a2.GetInstance().GetTexture(EditorGUIUtility.isProSkin ? Base64Texture.ScrollBackgroundPro : Base64Texture.ScrollBackgroundLight)));
            }
        }

        // Token: 0x0600038A RID: 906 RVA: 0x000A70F4 File Offset: 0x000A52F4
        internal static bool Init(bool fromMenu)
        {
            _bl3 _yd6;
            bool flag = !_bi4.GetAboutEntry(out _yd6);
            bool flag2;
            if (flag)
            {
                Debug.LogWarning("Couldn't find SuperEditorInfo.txt");
                flag2 = false;
            }
            else
            {
                bool flag3 = fromMenu || EditorPrefs.GetString(_yd6._zk4) != _yd6._zk5;
                if (flag3)
                {
                    _bj2 _yd7 = (_bj2)EditorWindow.GetWindow(typeof(_bj2), true, _yd6._AW, true);
                    _yd7.ShowUtility();
                    _yd7.SetAbout(_yd6);
                    EditorPrefs.SetString(_yd6._zk4, _yd6._zk5);
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
            }
            return flag2;
        }

        // Token: 0x0600038B RID: 907 RVA: 0x000A718B File Offset: 0x000A538B
        [MenuItem("Window/Super Editor/Help", false, 992)]
        internal static void MenuInitAbout()
        {
            _bj2.Init(true);
        }

        // Token: 0x0600038C RID: 908 RVA: 0x000A7198 File Offset: 0x000A5398
        private static Color HexToColor(uint x)
        {
            return new Color(((x >> 16) & 255U) / 255f, ((x >> 8) & 255U) / 255f, (x & 255U) / 255f, 1f);
        }

        // Token: 0x0600038D RID: 909 RVA: 0x000A71E8 File Offset: 0x000A53E8
        internal static void InitGuiStyles()
        {
            _bj2._yd4 = new GUIStyle
            {
                margin = new RectOffset(12, 12, 12, 12),
                normal = new GUIStyleState(),
                hover = new GUIStyleState()
            };
            _bj2._yd4.fixedWidth = 480f;
            _bj2._yd4.fixedHeight = 270f;
            _bj2._yd8 = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                alignment = (TextAnchor)4,
                fontSize = 24,
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "PTMono.ttc")),
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2._zz1 : _bj2._zz2)
                }
            };
            _bj2._zy9 = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                fontSize = 14,
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2._zz1 : _bj2._zz2)
                }
            };
            _bj2._yd5 = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                alignment = (TextAnchor)4,
                fontSize = 16,
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                normal = new GUIStyleState
                {
                    textColor = _bj2._yd9
                },
                hover = new GUIStyleState
                {
                    textColor = _bj2._ye1
                }
            };
            _bj2._ye2 = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                alignment = (TextAnchor)4,
                fontSize = 16,
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2._zz1 : _bj2._zz2)
                }
            };
            _bj2._zx9 = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "PTMono.ttc")),
                richText = true,
                normal = new GUIStyleState()
            };
            _bj2._zz3 = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                fontSize = 14,
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2._zz1 : _bj2._zz2)
                },
                richText = true,
                wordWrap = true
            };
        }

        // Token: 0x0600038E RID: 910 RVA: 0x000A74D4 File Offset: 0x000A56D4
        private void OnEnable()
        {
            _bj2.InitGuiStyles();
            _bj2.LoadIcons(false);
            base.wantsMouseMove = true;
            base.minSize = new Vector2(504f, 675f);
            base.maxSize = new Vector2(504f, 675f);
        }

        // Token: 0x0600038F RID: 911 RVA: 0x000A7524 File Offset: 0x000A5724
        private void SetAbout(_bl3 about)
        {
            this._ye3 = about;
            bool flag = !File.Exists(about._zk7);
            if (flag)
            {
                about._zk7 = _bi2.NPOF() + "/Internal/ChangeLog.txt";
            }
            bool flag2 = File.Exists(about._zk7);
            if (flag2)
            {
                string text = File.ReadAllText(about._zk7);
                bool flag3 = !string.IsNullOrEmpty(text);
                if (flag3)
                {
                    _bj9 _zl1;
                    _bi4.FormatChangelog(text, out _zl1, out this._ye4);
                }
            }
        }

        // Token: 0x06000390 RID: 912 RVA: 0x000A75A0 File Offset: 0x000A57A0
        protected void Update()
        {
            bool flag = _bj2._yd4.normal.background == null;
            if (flag)
            {
                _bj2.InitGuiStyles();
                _bj2.LoadIcons(false);
                base.Repaint();
            }
        }

        // Token: 0x06000391 RID: 913 RVA: 0x000A75E0 File Offset: 0x000A57E0
        private void OnGUI()
        {
            Vector2 mousePosition = Event.current.mousePosition;
            bool flag = GUILayout.Button(this._ye5, _bj2._yd4, Array.Empty<GUILayoutOption>());
            if (flag)
            {
                Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor");
            }
            bool flag2 = GUILayoutUtility.GetLastRect().Contains(mousePosition);
            if (flag2)
            {
                base.Repaint();
            }
            GUILayout.BeginVertical(_bj2._zx9, Array.Empty<GUILayoutOption>());
            GUILayout.Label(this._ye6, _bj2._yd8, Array.Empty<GUILayoutOption>());
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            GUILayout.FlexibleSpace();
            bool flag3 = GUILayout.Button(this._ye7, _bj2._yd5, Array.Empty<GUILayoutOption>());
            if (flag3)
            {
                Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor");
            }
            GUILayout.Label("|", _bj2._ye2, Array.Empty<GUILayoutOption>());
            bool flag4 = GUILayout.Button(this._ye8, _bj2._yd5, Array.Empty<GUILayoutOption>());
            if (flag4)
            {
                Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor/issues");
            }
            GUILayout.Label("|", _bj2._ye2, Array.Empty<GUILayoutOption>());
            bool flag5 = GUILayout.Button(this._ye9, _bj2._yd5, Array.Empty<GUILayoutOption>());
            if (flag5)
            {
                Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor/issues");
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            bool flag6 = GUILayoutUtility.GetLastRect().Contains(mousePosition);
            if (flag6)
            {
                base.Repaint();
            }
            GUILayout.EndVertical();
            this._zz8 = GUILayout.BeginScrollView(this._zz8, _bj2._zx9);
            GUILayout.Label(string.Format("Version: {0}", this._ye3._zk5), _bj2._zy9, Array.Empty<GUILayoutOption>());
            GUILayout.Label("\n" + this._ye4, _bj2._zz3, Array.Empty<GUILayoutOption>());
            GUILayout.EndScrollView();
        }

        // Token: 0x040003F4 RID: 1012
        [SerializeField]
        private GUIContent _ye7 = new GUIContent("Learn SuperEditor", "");

        // Token: 0x040003F5 RID: 1013
        [SerializeField]
        private GUIContent _ye8 = new GUIContent("Support Forum", "");

        // Token: 0x040003F6 RID: 1014
        [SerializeField]
        private GUIContent _ye9 = new GUIContent("Contact Us", "");

        // Token: 0x040003F7 RID: 1015
        [SerializeField]
        private GUIContent _ye5 = new GUIContent("", "Quick-Start Tutorials");

        // Token: 0x040003F8 RID: 1016
        public static readonly Color _zz1 = _bj2.HexToColor(13553358U);

        // Token: 0x040003F9 RID: 1017
        public static readonly Color _zz2 = _bj2.HexToColor(5526612U);

        // Token: 0x040003FA RID: 1018
        public static readonly Color _yd9 = _bj2.HexToColor(43759U);

        // Token: 0x040003FB RID: 1019
        public static readonly Color _ye1 = _bj2.HexToColor(35823U);

        // Token: 0x040003FC RID: 1020
        private string _ye6 = "SuperEditor Pro";

        // Token: 0x040003FD RID: 1021
        private _bl3 _ye3;

        // Token: 0x040003FE RID: 1022
        private string _ye4 = "";

        // Token: 0x040003FF RID: 1023
        internal static GUIStyle _yd4;

        // Token: 0x04000400 RID: 1024
        internal static GUIStyle _yd8;

        // Token: 0x04000401 RID: 1025
        internal static GUIStyle _zy9;

        // Token: 0x04000402 RID: 1026
        internal static GUIStyle _yd5;

        // Token: 0x04000403 RID: 1027
        internal static GUIStyle _ye2;

        // Token: 0x04000404 RID: 1028
        internal static GUIStyle _zx9;

        // Token: 0x04000405 RID: 1029
        internal static GUIStyle _zz3;

        // Token: 0x04000406 RID: 1030
        private Vector2 _zz8 = Vector2.zero;
    }
}
