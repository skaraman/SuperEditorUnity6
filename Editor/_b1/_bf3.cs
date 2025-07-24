using System;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000053 RID: 83
    [CustomEditor(typeof(TextAsset))]
    internal class _bf3 : _bh3
    {
        // Token: 0x06000268 RID: 616 RVA: 0x0002122C File Offset: 0x0001F42C
        public override void OnInspectorGUI()
        {
            bool flag = !_bg8._AGA;
            if (flag)
            {
                base.OnInspectorGUI();
            }
            else
            {
                EditorWindow currentInspector = _bh3.GetCurrentInspector();
                bool flag2 = this._AEK == null;
                if (!flag2)
                {
                    bool _AGB = this._AGC;
                    if (_AGB)
                    {
                        this._AEK._AGD = new _bi2._AGE(this.Repaint);
                        this._AEK.OnEnable(base.target);
                        this._AGC = false;
                    }
                    this._AEK.OnInspectorGUI(1f, currentInspector, true);
                }
            }
        }
    }
}
