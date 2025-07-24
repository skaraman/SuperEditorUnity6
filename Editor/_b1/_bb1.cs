using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace AHO
{
    // Token: 0x02000054 RID: 84
    [CustomEditor(typeof(DefaultAsset), true)]
    internal class _bb1 : _bh3
    {
        // Token: 0x0600026B RID: 619 RVA: 0x000212C4 File Offset: 0x0001F4C4
        public override void OnInspectorGUI()
        {
            bool flag = !_bg8._AGA;
            if (flag)
            {
                base.OnInspectorGUI();
            }
            else
            {
                string assetPath = AssetDatabase.GetAssetPath(base.target);
                bool flag2 = assetPath != this._AIA;
                if (flag2)
                {
                    this._AIA = assetPath;
                    string extension = Path.GetExtension(assetPath);
                    this._AIB = !AssetDatabase.IsValidFolder(assetPath) && this._AIC.Contains(extension);
                }
                bool _AID = this._AIB;
                if (_AID)
                {
                    bool _AGB = this._AGC;
                    if (_AGB)
                    {
                        this._AEK._AGD = new _bi2._AGE(this.Repaint);
                        this._AEK.OnEnable(base.target);
                        this._AGC = false;
                    }
                    bool flag3 = this._AEK == null;
                    if (!flag3)
                    {
                        EditorWindow currentInspector = _bh3.GetCurrentInspector();
                        this._AEK.OnInspectorGUI(1f, currentInspector, true);
                    }
                }
                else
                {
                    base.DrawDefaultInspector();
                }
            }
        }

        // Token: 0x0400028F RID: 655
        private readonly HashSet<string> _AIC = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".md", ".xaml", ".text", ".bat", ".cmd", ".sh", ".command", ".ini", ".rsp", ".plist",
            ".log", ".lua", ".h", ".c", ".cpp"
        };

        // Token: 0x04000290 RID: 656
        [NonSerialized]
        private string _AIA;

        // Token: 0x04000291 RID: 657
        [NonSerialized]
        private bool _AIB;
    }
}
