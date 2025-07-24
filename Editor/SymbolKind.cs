using System;

namespace SuperEditor
{
    // Token: 0x020000F9 RID: 249
    public enum SymbolKind : byte
    {
        // Token: 0x040005F6 RID: 1526
        None,
        // Token: 0x040005F7 RID: 1527
        Error,
        // Token: 0x040005F8 RID: 1528
        Keyword,
        // Token: 0x040005F9 RID: 1529
        Snippet,
        // Token: 0x040005FA RID: 1530
        Namespace,
        // Token: 0x040005FB RID: 1531
        Interface,
        // Token: 0x040005FC RID: 1532
        Enum,
        // Token: 0x040005FD RID: 1533
        Struct,
        // Token: 0x040005FE RID: 1534
        Class,
        // Token: 0x040005FF RID: 1535
        Delegate,
        // Token: 0x04000600 RID: 1536
        Field,
        // Token: 0x04000601 RID: 1537
        ConstantField,
        // Token: 0x04000602 RID: 1538
        LocalConstant,
        // Token: 0x04000603 RID: 1539
        EnumMember,
        // Token: 0x04000604 RID: 1540
        Property,
        // Token: 0x04000605 RID: 1541
        Event,
        // Token: 0x04000606 RID: 1542
        Indexer,
        // Token: 0x04000607 RID: 1543
        Method,
        // Token: 0x04000608 RID: 1544
        ExtensionMethod,
        // Token: 0x04000609 RID: 1545
        MethodGroup,
        // Token: 0x0400060A RID: 1546
        Constructor,
        // Token: 0x0400060B RID: 1547
        Destructor,
        // Token: 0x0400060C RID: 1548
        Operator,
        // Token: 0x0400060D RID: 1549
        Accessor,
        // Token: 0x0400060E RID: 1550
        LambdaExpression,
        // Token: 0x0400060F RID: 1551
        Parameter,
        // Token: 0x04000610 RID: 1552
        CatchParameter,
        // Token: 0x04000611 RID: 1553
        Variable,
        // Token: 0x04000612 RID: 1554
        CaseVariable,
        // Token: 0x04000613 RID: 1555
        ForEachVariable,
        // Token: 0x04000614 RID: 1556
        FromClauseVariable,
        // Token: 0x04000615 RID: 1557
        OutVariable,
        // Token: 0x04000616 RID: 1558
        TypeParameter,
        // Token: 0x04000617 RID: 1559
        TypeParameterConstraintList,
        // Token: 0x04000618 RID: 1560
        BaseTypesList,
        // Token: 0x04000619 RID: 1561
        Instance,
        // Token: 0x0400061A RID: 1562
        Null,
        // Token: 0x0400061B RID: 1563
        Label,
        // Token: 0x0400061C RID: 1564
        ImportedNamespace,
        // Token: 0x0400061D RID: 1565
        TypeAlias,
        // Token: 0x0400061E RID: 1566
        ImportedStaticType
    }
}
