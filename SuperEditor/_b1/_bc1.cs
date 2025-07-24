using System;

namespace AHO
{
    // Token: 0x0200012B RID: 299
    internal enum _bc1
    {
        // Token: 0x04000726 RID: 1830
        None,
        // Token: 0x04000727 RID: 1831
        SymbolDeclarationsMask = 255,
        // Token: 0x04000728 RID: 1832
        ScopesMask = -256,
        // Token: 0x04000729 RID: 1833
        SymbolDeclarationsBegin = 1,
        // Token: 0x0400072A RID: 1834
        NamespaceDeclaration,
        // Token: 0x0400072B RID: 1835
        UsingNamespace,
        // Token: 0x0400072C RID: 1836
        UsingAlias,
        // Token: 0x0400072D RID: 1837
        UsingStatic,
        // Token: 0x0400072E RID: 1838
        ExternAlias,
        // Token: 0x0400072F RID: 1839
        ClassDeclaration,
        // Token: 0x04000730 RID: 1840
        TypeParameterDeclaration,
        // Token: 0x04000731 RID: 1841
        BaseListDeclaration,
        // Token: 0x04000732 RID: 1842
        ConstructorDeclarator,
        // Token: 0x04000733 RID: 1843
        DestructorDeclarator,
        // Token: 0x04000734 RID: 1844
        ConstantDeclarator,
        // Token: 0x04000735 RID: 1845
        MethodDeclarator,
        // Token: 0x04000736 RID: 1846
        LocalVariableDeclarator,
        // Token: 0x04000737 RID: 1847
        OutVariableDeclarator,
        // Token: 0x04000738 RID: 1848
        ForEachVariableDeclaration,
        // Token: 0x04000739 RID: 1849
        FromClauseVariableDeclaration,
        // Token: 0x0400073A RID: 1850
        CaseVariableDeclaration,
        // Token: 0x0400073B RID: 1851
        LabeledStatement,
        // Token: 0x0400073C RID: 1852
        CatchExceptionParameterDeclaration,
        // Token: 0x0400073D RID: 1853
        FixedParameterDeclaration,
        // Token: 0x0400073E RID: 1854
        ParameterArrayDeclaration,
        // Token: 0x0400073F RID: 1855
        ImplicitParameterDeclaration,
        // Token: 0x04000740 RID: 1856
        ExplicitParameterDeclaration,
        // Token: 0x04000741 RID: 1857
        PropertyDeclaration,
        // Token: 0x04000742 RID: 1858
        IndexerDeclaration,
        // Token: 0x04000743 RID: 1859
        GetAccessorDeclaration,
        // Token: 0x04000744 RID: 1860
        SetAccessorDeclaration,
        // Token: 0x04000745 RID: 1861
        EventDeclarator,
        // Token: 0x04000746 RID: 1862
        EventWithAccessorsDeclaration,
        // Token: 0x04000747 RID: 1863
        AddAccessorDeclaration,
        // Token: 0x04000748 RID: 1864
        RemoveAccessorDeclaration,
        // Token: 0x04000749 RID: 1865
        VariableDeclarator,
        // Token: 0x0400074A RID: 1866
        OperatorDeclarator,
        // Token: 0x0400074B RID: 1867
        ConversionOperatorDeclarator,
        // Token: 0x0400074C RID: 1868
        StructDeclaration,
        // Token: 0x0400074D RID: 1869
        InterfaceDeclaration,
        // Token: 0x0400074E RID: 1870
        InterfacePropertyDeclaration,
        // Token: 0x0400074F RID: 1871
        InterfaceMethodDeclaration,
        // Token: 0x04000750 RID: 1872
        InterfaceEventDeclaration,
        // Token: 0x04000751 RID: 1873
        InterfaceIndexerDeclaration,
        // Token: 0x04000752 RID: 1874
        InterfaceGetAccessorDeclaration,
        // Token: 0x04000753 RID: 1875
        InterfaceSetAccessorDeclaration,
        // Token: 0x04000754 RID: 1876
        EnumDeclaration,
        // Token: 0x04000755 RID: 1877
        EnumMemberDeclaration,
        // Token: 0x04000756 RID: 1878
        DelegateDeclaration,
        // Token: 0x04000757 RID: 1879
        AnonymousObjectCreation,
        // Token: 0x04000758 RID: 1880
        MemberDeclarator,
        // Token: 0x04000759 RID: 1881
        LambdaExpressionDeclaration,
        // Token: 0x0400075A RID: 1882
        AnonymousMethodDeclaration,
        // Token: 0x0400075B RID: 1883
        SymbolDeclarationsEnd,
        // Token: 0x0400075C RID: 1884
        ScopesBegin = 256,
        // Token: 0x0400075D RID: 1885
        CompilationUnitScope = 256,
        // Token: 0x0400075E RID: 1886
        NamespaceBodyScope = 512,
        // Token: 0x0400075F RID: 1887
        ClassBaseScope = 768,
        // Token: 0x04000760 RID: 1888
        TypeParameterConstraintsScope = 1024,
        // Token: 0x04000761 RID: 1889
        ClassBodyScope = 1280,
        // Token: 0x04000762 RID: 1890
        StructInterfacesScope = 1536,
        // Token: 0x04000763 RID: 1891
        StructBodyScope = 1792,
        // Token: 0x04000764 RID: 1892
        InterfaceBaseScope = 2048,
        // Token: 0x04000765 RID: 1893
        InterfaceBodyScope = 2304,
        // Token: 0x04000766 RID: 1894
        FormalParameterListScope = 2560,
        // Token: 0x04000767 RID: 1895
        EnumBodyScope = 2816,
        // Token: 0x04000768 RID: 1896
        MethodBodyScope = 3072,
        // Token: 0x04000769 RID: 1897
        ConstructorInitializerScope = 3328,
        // Token: 0x0400076A RID: 1898
        LambdaExpressionScope = 3584,
        // Token: 0x0400076B RID: 1899
        LambdaExpressionBodyScope = 3840,
        // Token: 0x0400076C RID: 1900
        AnonymousMethodScope = 4096,
        // Token: 0x0400076D RID: 1901
        AnonymousMethodBodyScope = 4352,
        // Token: 0x0400076E RID: 1902
        CodeBlockScope = 4608,
        // Token: 0x0400076F RID: 1903
        SwitchBlockScope = 4864,
        // Token: 0x04000770 RID: 1904
        SwitchSectionScope = 5120,
        // Token: 0x04000771 RID: 1905
        ForStatementScope = 5376,
        // Token: 0x04000772 RID: 1906
        EmbeddedStatementScope = 5632,
        // Token: 0x04000773 RID: 1907
        UsingStatementScope = 5888,
        // Token: 0x04000774 RID: 1908
        LocalVariableInitializerScope = 6144,
        // Token: 0x04000775 RID: 1909
        SpecificCatchScope = 6400,
        // Token: 0x04000776 RID: 1910
        ArgumentListScope = 6656,
        // Token: 0x04000777 RID: 1911
        AttributeArgumentsScope = 6912,
        // Token: 0x04000778 RID: 1912
        MemberInitializerScope = 7168,
        // Token: 0x04000779 RID: 1913
        TypeDeclarationScope = 7424,
        // Token: 0x0400077A RID: 1914
        MethodDeclarationScope = 7680,
        // Token: 0x0400077B RID: 1915
        AttributesScope = 7936,
        // Token: 0x0400077C RID: 1916
        AccessorBodyScope = 8192,
        // Token: 0x0400077D RID: 1917
        AccessorsListScope = 8448,
        // Token: 0x0400077E RID: 1918
        QueryExpressionScope = 8704,
        // Token: 0x0400077F RID: 1919
        QueryBodyScope = 8960,
        // Token: 0x04000780 RID: 1920
        MemberDeclarationScope = 9216,
        // Token: 0x04000781 RID: 1921
        ScopesEnd
    }
}
