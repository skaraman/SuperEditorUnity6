using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000DC RID: 220
    internal class _be9 : _bn2
    {
        // Token: 0x06000677 RID: 1655 RVA: 0x000E59C1 File Offset: 0x000E3BC1
        public _be9(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x06000678 RID: 1656 RVA: 0x000E59CC File Offset: 0x000E3BCC
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            _bb4.DHBA lastLeaf = this._AEJ.OOME.OOME.NodeAt(0).GetLastLeaf();
            bool flag = lastLeaf != null;
            if (flag)
            {
                _b2 _AAC = lastLeaf._AAB() as _b2;
                bool flag2 = _AAC != null;
                if (flag2)
                {
                    Dictionary<string, _bh4> dictionary = new Dictionary<string, _bh4>();
                    _AAC.GetMembersCompletionData(dictionary, BindingFlags.Instance, AccessLevelMask.Internal | AccessLevelMask.Public, context);
                    foreach (KeyValuePair<string, _bh4> keyValuePair in dictionary)
                    {
                        SymbolKind _ABY = keyValuePair.Value._AT;
                        bool flag3 = _ABY == SymbolKind.Field || _ABY == SymbolKind.Property;
                        if (flag3)
                        {
                            bool flag4 = !data.ContainsKey(keyValuePair.Key);
                            if (flag4)
                            {
                                data[keyValuePair.Key] = keyValuePair.Value;
                            }
                        }
                    }
                }
            }
            base.GetCompletionData(data, context);
        }
    }
}
