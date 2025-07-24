using System;

namespace SuperEditor
{
    // Token: 0x020000F7 RID: 247
    [Flags]
    public enum AccessLevelMask : byte
    {
        // Token: 0x040005D8 RID: 1496
        None = 0,
        // Token: 0x040005D9 RID: 1497
        Private = 1,
        // Token: 0x040005DA RID: 1498
        Protected = 2,
        // Token: 0x040005DB RID: 1499
        Internal = 4,
        // Token: 0x040005DC RID: 1500
        Public = 8,
        // Token: 0x040005DD RID: 1501
        Any = 15,
        // Token: 0x040005DE RID: 1502
        NonPublic = 7
    }
}
