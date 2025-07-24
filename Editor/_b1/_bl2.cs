using System;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000F4 RID: 244
    internal class _bl2
    {
        // Token: 0x060006FF RID: 1791 RVA: 0x000EAC70 File Offset: 0x000E8E70
        protected _bb4._ACW EnclosingNamespaceScopeNode(SyntaxToken token)
        {
            bool flag = token.OOME == null;
            _bb4._ACW _AGZ;
            if (flag)
            {
                _AGZ = null;
            }
            else
            {
                _bb4._ACW _AGZ2 = token.OOME.OOME;
                while (_AGZ2 != null && !(_AGZ2._AJW is _bc8))
                {
                    _AGZ2 = _AGZ2.OOME;
                }
                _AGZ = _AGZ2;
            }
            return _AGZ;
        }

        // Token: 0x040005CE RID: 1486
        protected _b2 BLH;
    }
}
