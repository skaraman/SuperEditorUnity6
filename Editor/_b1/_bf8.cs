using System;
using System.Collections.Generic;
using System.Text;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000A0 RID: 160
    internal class _bf8 : FKI
    {
        // Token: 0x0600048E RID: 1166 RVA: 0x000CC0BD File Offset: 0x000CA2BD
        public _bf8(string nsName)
            : base(nsName)
        {
        }

        // Token: 0x0600048F RID: 1167 RVA: 0x000CC0E9 File Offset: 0x000CA2E9
        public _bf8()
        {
        }

        // Token: 0x06000490 RID: 1168 RVA: 0x000CC114 File Offset: 0x000CA314
        public void ImportNamespace(string namespaceToImport, _bb4._AIN declaringNode)
        {
            throw new NotImplementedException();
        }

        // Token: 0x06000491 RID: 1169 RVA: 0x000CC11C File Offset: 0x000CA31C
        protected override void Dump(StringBuilder sb, string indent)
        {
            base.Dump(sb, indent);
            sb.AppendLine(indent + "Imports:");
            string text = indent + "  ";
            foreach (KJK _AAD in this._APL)
            {
                string text2 = text;
                KJK _AAD2 = _AAD;
                sb.AppendLine(text2 + ((_AAD2 != null) ? _AAD2.ToString() : null));
            }
            sb.AppendLine("  Aliases:");
            foreach (TypeAlias typeAlias in this._APO)
            {
                sb.AppendLine(text + typeAlias._AW);
            }
            sb.AppendLine("  Static imports:");
            foreach (KJK _AAD3 in this._APN)
            {
                sb.AppendLine(text + _AAD3.definition._AW);
            }
        }

        // Token: 0x040004A3 RID: 1187
        public List<KJK> _APL = new List<KJK>();

        // Token: 0x040004A4 RID: 1188
        public List<KJK> _APN = new List<KJK>();

        // Token: 0x040004A5 RID: 1189
        public List<TypeAlias> _APO = new List<TypeAlias>();
    }
}
