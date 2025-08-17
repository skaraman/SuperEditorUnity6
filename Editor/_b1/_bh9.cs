using System;

namespace AHO
{
    // Token: 0x02000125 RID: 293
    internal interface _bh9<_zc4, DHBA>
    {
        // Token: 0x060008B6 RID: 2230
        bool Visit(DHBA leafNode);

        // Token: 0x060008B7 RID: 2231
        bool VisitEnter(_zc4 nonLeafNode);

        // Token: 0x060008B8 RID: 2232
        bool VisitLeave(_zc4 nonLeafNode);
    }
}
