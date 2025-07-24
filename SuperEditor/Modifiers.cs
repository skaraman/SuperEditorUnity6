using System;

namespace SuperEditor
{
    // Token: 0x020000F8 RID: 248
    [Flags]
    public enum Modifiers
    {
        // Token: 0x040005E0 RID: 1504
        None = 0,
        // Token: 0x040005E1 RID: 1505
        Public = 1,
        // Token: 0x040005E2 RID: 1506
        Internal = 2,
        // Token: 0x040005E3 RID: 1507
        Protected = 4,
        // Token: 0x040005E4 RID: 1508
        Private = 8,
        // Token: 0x040005E5 RID: 1509
        Static = 16,
        // Token: 0x040005E6 RID: 1510
        New = 32,
        // Token: 0x040005E7 RID: 1511
        Sealed = 64,
        // Token: 0x040005E8 RID: 1512
        Abstract = 128,
        // Token: 0x040005E9 RID: 1513
        ReadOnly = 256,
        // Token: 0x040005EA RID: 1514
        Volatile = 512,
        // Token: 0x040005EB RID: 1515
        Virtual = 1024,
        // Token: 0x040005EC RID: 1516
        Override = 2048,
        // Token: 0x040005ED RID: 1517
        Extern = 4096,
        // Token: 0x040005EE RID: 1518
        Ref = 8192,
        // Token: 0x040005EF RID: 1519
        Out = 16384,
        // Token: 0x040005F0 RID: 1520
        Params = 32768,
        // Token: 0x040005F1 RID: 1521
        This = 65536,
        // Token: 0x040005F2 RID: 1522
        Partial = 131072,
        // Token: 0x040005F3 RID: 1523
        Async = 262144,
        // Token: 0x040005F4 RID: 1524
        In = 524288
    }
}
