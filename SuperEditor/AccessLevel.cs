using System;

namespace SuperEditor
{
    // Token: 0x020000F6 RID: 246
    public enum AccessLevel : byte
    {
        // Token: 0x040005D0 RID: 1488
        None,
        // Token: 0x040005D1 RID: 1489
        Private,
        // Token: 0x040005D2 RID: 1490
        ProtectedAndInternal,
        // Token: 0x040005D3 RID: 1491
        ProtectedOrInternal = 4,
        // Token: 0x040005D4 RID: 1492
        Protected,
        // Token: 0x040005D5 RID: 1493
        Internal,
        // Token: 0x040005D6 RID: 1494
        Public
    }
}
