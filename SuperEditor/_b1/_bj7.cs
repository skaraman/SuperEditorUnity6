using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using ACGG;
using SuperEditor.IDE;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000077 RID: 119
    internal class _bj7 : EditorWindow
    {
        // Token: 0x060003A3 RID: 931 RVA: 0x000A7E6C File Offset: 0x000A606C
        private bool OLDMDNBALBFCLMNDDOCBBGCDAFJLOLCKCOBG()
        {
            return EditorPrefs.GetBool("SuperEditorUpdateAutoImport", false);
        }

        // Token: 0x060003A4 RID: 932 RVA: 0x000A7E89 File Offset: 0x000A6089
        private void IOANEMHEDEHCIJNNEGACJFIKCMMNLPMLHMON(bool value)
        {
            EditorPrefs.SetBool("SuperEditorUpdateAutoImport", value);
        }

        // Token: 0x060003A5 RID: 933 RVA: 0x000A7E98 File Offset: 0x000A6098
        internal static void LoadIcons(bool forDll = false)
        {
            _bj7.FADBGFHELNOBMJEKEMFOKHGEEKINDLDMIJML.normal.background = _a2.GetInstance().GetTexture(EditorGUIUtility.isProSkin ? Base64Texture.ScrollBackgroundPro : Base64Texture.ScrollBackgroundLight);
            _bj7.MGPAIJHPAPPELDLPELONIFICCKMIPFKHKKHG.normal.background = _a2.GetInstance().GetTexture(Base64Texture.DownloadNormal);
            _bj7.MGPAIJHPAPPELDLPELONIFICCKMIPFKHKKHG.hover.background = _a2.GetInstance().GetTexture(Base64Texture.DownloadHover);
        }

        // Token: 0x060003A6 RID: 934 RVA: 0x000A7F04 File Offset: 0x000A6104
        internal static void Init(_bj9 newVersion, string changelog)
        {
            _bj7 window = EditorWindow.GetWindow<_bj7>(true, "SuperEditor Update Available", true);
            window.MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI = newVersion;
            window.NMOCIHFKLIGDMOEGAMEEFGPEIJKCMCBJBOIF = changelog;
        }

        // Token: 0x060003A7 RID: 935 RVA: 0x000A7F30 File Offset: 0x000A6130
        public async void GetUnityPackage()
        {
            this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL = 0f;
            this.ONJLOECDFEKNEIDDDOMBFCNKLLOKNBEEIGBA = "Downloading...";
            await Task.Run(delegate
            {
                this.HttpDownloadFile(this.KNGIADFDFDKPIOKMAJJLOHFOFJLKJCJBNHOJ, this.NMINMLAOPGNLLIFFFOKOCIDCNHFPENGNOJJB);
            });
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.AutoImportPackage));
        }

        // Token: 0x060003A8 RID: 936 RVA: 0x000A7F6C File Offset: 0x000A616C
        public void AutoImportPackage()
        {
            bool flag = this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL == 1f;
            if (flag)
            {
                AssetDatabase.ImportPackage(this._AWJ, !this.OLDMDNBALBFCLMNDDOCBBGCDAFJLOLCKCOBG());
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.AutoImportPackage));
            }
        }

        // Token: 0x060003A9 RID: 937 RVA: 0x000A7FC4 File Offset: 0x000A61C4
        public void HttpDownloadFile(string url, string tempPath)
        {
            this.MLEJNDABNJALNNFMJIOEAACHMAFMNPHLAPIH = true;
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream responseStream = httpWebResponse.GetResponseStream();
            Stream stream = new FileStream(tempPath, FileMode.Create);
            long contentLength = httpWebResponse.ContentLength;
            long num = 0L;
            byte[] array = new byte[1024];
            int i = responseStream.Read(array, 0, array.Length);
            while (i > 0)
            {
                num += (long)i;
                stream.Write(array, 0, i);
                i = responseStream.Read(array, 0, array.Length);
                this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL = (float)((int)((float)num / (float)contentLength * 100f));
                this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL /= 100f;
            }
            stream.Close();
            responseStream.Close();
            this.MLEJNDABNJALNNFMJIOEAACHMAFMNPHLAPIH = false;
            bool flag = this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL == 1f;
            if (flag)
            {
                FileInfo fileInfo = new FileInfo(tempPath);
                fileInfo.MoveTo(Path.ChangeExtension(tempPath, ".unitypackage"));
            }
        }

        // Token: 0x060003AA RID: 938 RVA: 0x000A80C8 File Offset: 0x000A62C8
        internal static void InitGuiStyles()
        {
            _bj7.LHNNNCHIOKENOLCFIOLBAOAGMKEJLIGKACNJ = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                fontSize = 14,
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2.MNNLCEKFLEFMBCHACDKEKPNKJFLNGODIEIHL : _bj2.FGKLKJAOLFOKANIIGGCLFGBHKNGKGLNOAEEG)
                }
            };
            _bj7.FADBGFHELNOBMJEKEMFOKHGEEKINDLDMIJML = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "PTMono.ttc")),
                richText = true,
                normal = new GUIStyleState()
            };
            _bj7.OPJONFIMONDDOHCIPOLBIHOLJHIKHNOBKNPP = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                fontSize = 14,
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2.MNNLCEKFLEFMBCHACDKEKPNKJFLNGODIEIHL : _bj2.FGKLKJAOLFOKANIIGGCLFGBHKNGKGLNOAEEG)
                },
                richText = true,
                wordWrap = true
            };
            _bj7.MGPAIJHPAPPELDLPELONIFICCKMIPFKHKKHG = new GUIStyle
            {
                margin = new RectOffset(10, 10, 10, 10),
                fixedWidth = 80f,
                fixedHeight = 85f,
                normal = new GUIStyleState(),
                hover = new GUIStyleState()
            };
            _bj7.DHDFOGEKKINJPMEDLKCIOKDLCPBMEKEAGAEM = new GUIStyle
            {
                margin = new RectOffset(0, 0, 0, 0),
                alignment = 4,
                fixedHeight = 85f,
                fontSize = 24,
                wordWrap = true,
                font = _bi2.LoadEditorResource<Font>(string.Format("Fonts/{0}", "")),
                normal = new GUIStyleState
                {
                    textColor = (EditorGUIUtility.isProSkin ? _bj2.MNNLCEKFLEFMBCHACDKEKPNKJFLNGODIEIHL : _bj2.FGKLKJAOLFOKANIIGGCLFGBHKNGKGLNOAEEG)
                }
            };
        }

        // Token: 0x060003AB RID: 939 RVA: 0x000A82D4 File Offset: 0x000A64D4
        private void OnEnable()
        {
            _bj7.InitGuiStyles();
            _bj7.LoadIcons(false);
            base.wantsMouseMove = true;
            base.minSize = new Vector2(400f, 350f);
            this.MGMEGOOBOECKFEEEEFDADMMJNJJFHGOHKBOL = typeof(EditorGUILayout).GetMethod("LinkButton", new Type[]
            {
                typeof(string),
                typeof(GUILayoutOption[])
            });
        }

        // Token: 0x060003AC RID: 940 RVA: 0x000A8348 File Offset: 0x000A6548
        private void OnGUI()
        {
            bool flag = this._AWJ == "" || this.KNGIADFDFDKPIOKMAJJLOHFOFJLKJCJBNHOJ == "";
            if (flag)
            {
                this.KNGIADFDFDKPIOKMAJJLOHFOFJLKJCJBNHOJ = string.Format("https://github.com/UnitySuperEditor/SuperEditor/releases/download/v{0}/SuperEditor{1}.unitypackage", this.MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI.ToString(), this.MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI.ToString());
                this._AWJ = Directory.GetParent(Application.dataPath).ToString() + string.Format("/Temp/SuperEditor{0}.unitypackage", this.MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI.ToString());
                this.NMINMLAOPGNLLIFFFOKOCIDCNHFPENGNOJJB = Directory.GetParent(Application.dataPath).ToString() + string.Format("/Temp/SuperEditor{0}.temp", this.MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI.ToString());
            }
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag2 = GUILayout.Button(this.BJHDMBMCEEKGFPMNHELDJLHPNCAHCHAFAAHF, _bj7.MGPAIJHPAPPELDLPELONIFICCKMIPFKHKKHG, Array.Empty<GUILayoutOption>());
            if (flag2)
            {
                bool flag3 = File.Exists(this._AWJ) && !this.MLEJNDABNJALNNFMJIOEAACHMAFMNPHLAPIH;
                if (flag3)
                {
                    try
                    {
                        AssetDatabase.ImportPackage(this._AWJ, true);
                        this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL = 1f;
                    }
                    catch
                    {
                        this.GetUnityPackage();
                    }
                }
                else
                {
                    bool flag4 = !this.MLEJNDABNJALNNFMJIOEAACHMAFMNPHLAPIH;
                    if (flag4)
                    {
                        this.GetUnityPackage();
                    }
                }
            }
            bool flag5 = GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition);
            if (flag5)
            {
                base.Repaint();
            }
            GUILayout.BeginVertical(_bj7.FADBGFHELNOBMJEKEMFOKHGEEKINDLDMIJML, Array.Empty<GUILayoutOption>());
            GUILayout.Label(this.ONJLOECDFEKNEIDDDOMBFCNKLLOKNBEEIGBA, _bj7.DHDFOGEKKINJPMEDLKCIOKDLCPBMEKEAGAEM, Array.Empty<GUILayoutOption>());
            GUILayout.EndVertical();
            Color32 color;
            color..ctor(108, 226, 108, 100);
            this.OHEKADAFHMIDHMCDKBIJOLAPLFHHGEEECPGP = GUILayoutUtility.GetLastRect();
            this.OHEKADAFHMIDHMCDKBIJOLAPLFHHGEEECPGP.width = this.OHEKADAFHMIDHMCDKBIJOLAPLFHHGEEECPGP.width * this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL;
            Color color2 = GUI.color;
            GUI.color *= color;
            GUI.DrawTexture(this.OHEKADAFHMIDHMCDKBIJOLAPLFHHGEEECPGP, EditorGUIUtility.whiteTexture);
            bool flag6 = this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL < 1f;
            if (flag6)
            {
                base.Repaint();
            }
            bool flag7 = this.HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL == 1f;
            if (flag7)
            {
                this.ONJLOECDFEKNEIDDDOMBFCNKLLOKNBEEIGBA = "Download Completed";
            }
            GUI.color = color2;
            GUILayout.EndHorizontal();
            this.EHOPFFNHBPPOLENAJMNEBEFIBLPLLGNIBIAC = EditorGUILayout.BeginScrollView(this.EHOPFFNHBPPOLENAJMNEBEFIBLPLLGNIBIAC, _bj7.FADBGFHELNOBMJEKEMFOKHGEEKINDLDMIJML, Array.Empty<GUILayoutOption>());
            GUILayout.Label(string.Format("Version: {0}", this.MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI._ABG), _bj7.LHNNNCHIOKENOLCFIOLBAOAGMKEJLIGKACNJ, Array.Empty<GUILayoutOption>());
            GUILayout.Label("\n" + this.NMOCIHFKLIGDMOEGAMEEFGPEIJKCMCBJBOIF, _bj7.OPJONFIMONDDOHCIPOLBIHOLJHIKHNOBKNPP, Array.Empty<GUILayoutOption>());
            EditorGUILayout.EndScrollView();
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            GUILayout.Space(10f);
            this.IOANEMHEDEHCIJNNEGACJFIKCMMNLPMLHMON(GUILayout.Toggle(this.OLDMDNBALBFCLMNDDOCBBGCDAFJLOLCKCOBG(), "Auto Import", new GUILayoutOption[]
            {
                GUILayout.Height(16f),
                GUILayout.ExpandWidth(false)
            }));
            GUILayout.FlexibleSpace();
            bool flag8 = this.MGMEGOOBOECKFEEEEFDADMMJNJJFHGOHKBOL != null;
            if (flag8)
            {
                MethodBase mgmegooboeckfeeeefdadmmjnjjfhgohkbol = this.MGMEGOOBOECKFEEEEFDADMMJNJJFHGOHKBOL;
                object obj = null;
                object[] array = new object[2];
                array[0] = "View full release notes on Github";
                bool flag9 = (bool)mgmegooboeckfeeeefdadmmjnjjfhgohkbol.Invoke(obj, array);
                if (flag9)
                {
                    Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor/releases");
                }
            }
            else
            {
                bool flag10 = GUILayout.Button("View full release notes on Github", Array.Empty<GUILayoutOption>());
                if (flag10)
                {
                    Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor/releases");
                }
            }
            GUILayout.Space(5f);
            GUILayout.EndHorizontal();
            GUILayout.Space(10f);
        }

        // Token: 0x04000410 RID: 1040
        [SerializeField]
        private _bj9 MFJNEKEICMLFADGKJBGHBGAPDNPEHGFKBPLI;

        // Token: 0x04000411 RID: 1041
        [SerializeField]
        private string NMOCIHFKLIGDMOEGAMEEFGPEIJKCMCBJBOIF;

        // Token: 0x04000412 RID: 1042
        private Vector2 EHOPFFNHBPPOLENAJMNEBEFIBLPLLGNIBIAC = Vector2.zero;

        // Token: 0x04000413 RID: 1043
        private GUIContent BJHDMBMCEEKGFPMNHELDJLHPNCAHCHAFAAHF = new GUIContent("", "Download Directly");

        // Token: 0x04000414 RID: 1044
        private static GUIStyle MGPAIJHPAPPELDLPELONIFICCKMIPFKHKKHG;

        // Token: 0x04000415 RID: 1045
        private static GUIStyle DHDFOGEKKINJPMEDLKCIOKDLCPBMEKEAGAEM;

        // Token: 0x04000416 RID: 1046
        private static GUIStyle JGMAIKNNJFPCNPLCPCODDNMKGHKHIPICNHLH;

        // Token: 0x04000417 RID: 1047
        private static GUIStyle LHNNNCHIOKENOLCFIOLBAOAGMKEJLIGKACNJ;

        // Token: 0x04000418 RID: 1048
        private static GUIStyle FADBGFHELNOBMJEKEMFOKHGEEKINDLDMIJML;

        // Token: 0x04000419 RID: 1049
        private static GUIStyle OPJONFIMONDDOHCIPOLBIHOLJHIKHNOBKNPP;

        // Token: 0x0400041A RID: 1050
        private string KNGIADFDFDKPIOKMAJJLOHFOFJLKJCJBNHOJ = "";

        // Token: 0x0400041B RID: 1051
        private string _AWJ = "";

        // Token: 0x0400041C RID: 1052
        private string NMINMLAOPGNLLIFFFOKOCIDCNHFPENGNOJJB = "";

        // Token: 0x0400041D RID: 1053
        private float HMGEOOBPKDDIMIOLCKFHBGFBFCOACIIDKJCL;

        // Token: 0x0400041E RID: 1054
        private Rect OHEKADAFHMIDHMCDKBIJOLAPLFHHGEEECPGP;

        // Token: 0x0400041F RID: 1055
        private string ONJLOECDFEKNEIDDDOMBFCNKLLOKNBEEIGBA = "Update Available";

        // Token: 0x04000420 RID: 1056
        private bool MLEJNDABNJALNNFMJIOEAACHMAFMNPHLAPIH;

        // Token: 0x04000421 RID: 1057
        private MethodInfo MGMEGOOBOECKFEEEEFDADMMJNJJFHGOHKBOL;
    }
}
