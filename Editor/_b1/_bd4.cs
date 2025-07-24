using System;
using System.Text;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000A3 RID: 163
    internal class FKI
    {
        // Token: 0x06000498 RID: 1176 RVA: 0x000CC87D File Offset: 0x000CAA7D
        public FKI()
        {
        }

        // Token: 0x06000499 RID: 1177 RVA: 0x000CC887 File Offset: 0x000CAA87
        public FKI(string name)
        {
            this._AW = name;
        }

        // Token: 0x0600049A RID: 1178 RVA: 0x000CC898 File Offset: 0x000CAA98
        public bool IsValid()
        {
            bool flag = this._AJW == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                _bb4._ACW _AGZ = this._AEJ;
                bool flag3 = _AGZ != null;
                if (flag3)
                {
                    bool flag4 = _AGZ.EFI == this;
                    if (flag4)
                    {
                        while (_AGZ.OOME != null)
                        {
                            _AGZ = _AGZ.OOME;
                        }
                        bool flag5 = _AGZ._AHB() == "compilationUnit";
                        if (flag5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        bool flag6 = this._AT == SymbolKind.MethodGroup && this._ACV != null;
                        if (flag6)
                        {
                            _ba7 _AAK = this._ACV as _ba7;
                            int count = _AAK._AAM.Count;
                            while (count-- > 0)
                            {
                                bool flag7 = _AAK._AAM[count].ContainsDeclaration(_AGZ.EFI);
                                if (flag7)
                                {
                                    while (_AGZ.OOME != null)
                                    {
                                        _AGZ = _AGZ.OOME;
                                    }
                                    bool flag8 = _AGZ._AHB() == "compilationUnit";
                                    if (flag8)
                                    {
                                        return true;
                                    }
                                }
                                _AAK.RemoveDeclaration(_AGZ.EFI);
                            }
                            bool flag9 = _AAK._AAM.Count == 0 && _AAK._AO != null;
                            if (flag9)
                            {
                                this._ACV._AO.RemoveDeclaration(this);
                                return false;
                            }
                            return true;
                        }
                    }
                }
                bool flag10 = this._AJW != null;
                if (flag10)
                {
                    this._AJW.RemoveDeclaration(this);
                    _bb4._AIU += 1U;
                    bool flag11 = _bb4._AIU == 0U;
                    if (flag11)
                    {
                        _bb4._AIU += 1U;
                    }
                }
                else
                {
                    bool flag12 = this._ACV != null;
                    if (flag12)
                    {
                        bool flag13 = this._ACV._AO != null;
                        if (flag13)
                        {
                            this._ACV._AO.RemoveDeclaration(this);
                        }
                    }
                }
                this._AJW = null;
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x0600049B RID: 1179 RVA: 0x000CCA98 File Offset: 0x000CAC98
        public bool _AQL()
        {
            return (this._AV & Modifiers.Partial) > Modifiers.None;
        }

        // Token: 0x0600049C RID: 1180 RVA: 0x000CCABC File Offset: 0x000CACBC
        public bool _AQM()
        {
            return (this._AV & Modifiers.Async) > Modifiers.None;
        }

        // Token: 0x0600049D RID: 1181 RVA: 0x000CCAE0 File Offset: 0x000CACE0
        public _bb4._AIN NameNode()
        {
            bool flag = this._AEJ == null || this._AEJ._AIX == 0;
            _bb4._AIN _AIO;
            if (flag)
            {
                _AIO = null;
            }
            else
            {
                _bb4._AIN _AIO2 = null;
                string text = this._AEJ._AHB();
                string text2 = text;
                uint num = Helper.ComputeStringHash(text2);
                if (num <= 1955771841U)
                {
                    if (num <= 813785911U)
                    {
                        if (num <= 289127768U)
                        {
                            if (num <= 192704362U)
                            {
                                if (num != 123527744U)
                                {
                                    if (num != 177373158U)
                                    {
                                        if (num != 192704362U)
                                        {
                                            goto IL_09DC;
                                        }
                                        if (!(text2 == "caseVariableDeclarator"))
                                        {
                                            goto IL_09DC;
                                        }
                                        goto IL_0893;
                                    }
                                    else
                                    {
                                        if (!(text2 == "usingAliasDirective"))
                                        {
                                            goto IL_09DC;
                                        }
                                        _AIO2 = this._AEJ.ChildAt(0);
                                        goto IL_0A02;
                                    }
                                }
                                else
                                {
                                    if (!(text2 == "eventDeclarator"))
                                    {
                                        goto IL_09DC;
                                    }
                                    goto IL_0893;
                                }
                            }
                            else if (num != 214116047U)
                            {
                                if (num != 284132666U)
                                {
                                    if (num != 289127768U)
                                    {
                                        goto IL_09DC;
                                    }
                                    if (!(text2 == "typeParameter"))
                                    {
                                        goto IL_09DC;
                                    }
                                    _AIO2 = this._AEJ.ChildAt(0);
                                    goto IL_0A02;
                                }
                                else
                                {
                                    if (!(text2 == "delegateDeclaration"))
                                    {
                                        goto IL_09DC;
                                    }
                                    _AIO2 = this._AEJ.FindChildByName("NAME");
                                    goto IL_0A02;
                                }
                            }
                            else
                            {
                                if (!(text2 == "usingNamespaceDirective"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09D8;
                            }
                        }
                        else if (num <= 431734952U)
                        {
                            if (num != 367351068U)
                            {
                                if (num != 369023728U)
                                {
                                    if (num != 431734952U)
                                    {
                                        goto IL_09DC;
                                    }
                                    if (!(text2 == "operatorParameter"))
                                    {
                                        goto IL_09DC;
                                    }
                                }
                                else
                                {
                                    if (!(text2 == "readonlyAccessorDeclaration"))
                                    {
                                        goto IL_09DC;
                                    }
                                    goto IL_09B6;
                                }
                            }
                            else if (!(text2 == "fixedParameter"))
                            {
                                goto IL_09DC;
                            }
                        }
                        else if (num != 479015637U)
                        {
                            if (num != 782329552U)
                            {
                                if (num != 813785911U)
                                {
                                    goto IL_09DC;
                                }
                                if (!(text2 == "interfaceMethodDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_0893;
                            }
                            else
                            {
                                if (!(text2 == "getAccessorDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09B6;
                            }
                        }
                        else
                        {
                            if (!(text2 == "anonymousMethodExpression"))
                            {
                                goto IL_09DC;
                            }
                            goto IL_098B;
                        }
                    }
                    else
                    {
                        if (num > 1347432701U)
                        {
                            if (num <= 1695637348U)
                            {
                                if (num != 1579599801U)
                                {
                                    if (num != 1606138482U)
                                    {
                                        if (num != 1695637348U)
                                        {
                                            goto IL_09DC;
                                        }
                                        if (!(text2 == "interfaceDeclaration"))
                                        {
                                            goto IL_09DC;
                                        }
                                        goto IL_086B;
                                    }
                                    else
                                    {
                                        if (!(text2 == "enumMemberDeclaration"))
                                        {
                                            goto IL_09DC;
                                        }
                                        bool flag2 = this._AEJ.ChildAt(0) is _bb4._ACW;
                                        if (flag2)
                                        {
                                            _AIO2 = this._AEJ.ChildAt(1);
                                        }
                                        else
                                        {
                                            _AIO2 = this._AEJ.ChildAt(0);
                                        }
                                        goto IL_0A02;
                                    }
                                }
                                else if (!(text2 == "constructorDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                            }
                            else if (num <= 1765573194U)
                            {
                                if (num != 1712880051U)
                                {
                                    if (num != 1765573194U)
                                    {
                                        goto IL_09DC;
                                    }
                                    if (!(text2 == "foreachStatement"))
                                    {
                                        goto IL_09DC;
                                    }
                                    goto IL_09A3;
                                }
                                else
                                {
                                    if (!(text2 == "eventWithAccessorsDeclaration"))
                                    {
                                        goto IL_09DC;
                                    }
                                    goto IL_0893;
                                }
                            }
                            else if (num != 1804550500U)
                            {
                                if (num != 1955771841U)
                                {
                                    goto IL_09DC;
                                }
                                if (!(text2 == "labeledStatement"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09C9;
                            }
                            else if (!(text2 == "methodDeclaration"))
                            {
                                goto IL_09DC;
                            }
                            _bb4._ACW _AGZ = this._AEJ.NodeAt(0);
                            bool flag3 = _AGZ != null && _AGZ._AIX > 0;
                            if (flag3)
                            {
                                _AIO2 = _AGZ.ChildAt(0);
                            }
                            goto IL_0A02;
                        }
                        if (num <= 1054153197U)
                        {
                            if (num != 861072976U)
                            {
                                if (num != 1035727138U)
                                {
                                    if (num != 1054153197U)
                                    {
                                        goto IL_09DC;
                                    }
                                    if (!(text2 == "parameterArray"))
                                    {
                                        goto IL_09DC;
                                    }
                                }
                                else
                                {
                                    if (!(text2 == "removeAccessorDeclaration"))
                                    {
                                        goto IL_09DC;
                                    }
                                    goto IL_09B6;
                                }
                            }
                            else
                            {
                                if (!(text2 == "constructorDeclarator"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_08D8;
                            }
                        }
                        else if (num != 1251344729U)
                        {
                            if (num != 1281091206U)
                            {
                                if (num != 1347432701U)
                                {
                                    goto IL_09DC;
                                }
                                if (!(text2 == "interfaceIndexerDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09C9;
                            }
                            else
                            {
                                if (!(text2 == "destructorDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                                _bb4._ACW _AGZ2 = this._AEJ.NodeAt(0);
                                bool flag4 = _AGZ2 != null;
                                if (flag4)
                                {
                                    _AIO2 = _AGZ2.FindChildByName("IDENTIFIER");
                                }
                                goto IL_0A02;
                            }
                        }
                        else if (!(text2 == "explicitAnonymousFunctionParameter"))
                        {
                            goto IL_09DC;
                        }
                    }
                    _AIO2 = this._AEJ.FindChildByName("NAME");
                    goto IL_0A02;
                }
                if (num <= 2585900876U)
                {
                    if (num <= 2233282796U)
                    {
                        if (num <= 2063832884U)
                        {
                            if (num != 1997571305U)
                            {
                                if (num != 2060521100U)
                                {
                                    if (num != 2063832884U)
                                    {
                                        goto IL_09DC;
                                    }
                                    if (!(text2 == "structDeclaration"))
                                    {
                                        goto IL_09DC;
                                    }
                                }
                                else
                                {
                                    if (!(text2 == "indexerDeclaration"))
                                    {
                                        goto IL_09DC;
                                    }
                                    goto IL_09C9;
                                }
                            }
                            else
                            {
                                if (!(text2 == "typeParameterConstraintsClause"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09D8;
                            }
                        }
                        else if (num != 2069287005U)
                        {
                            if (num != 2150376270U)
                            {
                                if (num != 2233282796U)
                                {
                                    goto IL_09DC;
                                }
                                if (!(text2 == "propertyDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_0893;
                            }
                            else
                            {
                                if (!(text2 == "constantDeclarator"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_0893;
                            }
                        }
                        else
                        {
                            if (!(text2 == "interfaceGetAccessorDeclaration"))
                            {
                                goto IL_09DC;
                            }
                            goto IL_09B6;
                        }
                    }
                    else if (num <= 2335194422U)
                    {
                        if (num != 2262832473U)
                        {
                            if (num != 2282262626U)
                            {
                                if (num != 2335194422U)
                                {
                                    goto IL_09DC;
                                }
                                if (!(text2 == "catchExceptionIdentifier"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_0893;
                            }
                            else
                            {
                                if (!(text2 == "implicitAnonymousFunctionParameter"))
                                {
                                    goto IL_09DC;
                                }
                                _AIO2 = this._AEJ.ChildAt(0);
                                goto IL_0A02;
                            }
                        }
                        else
                        {
                            if (!(text2 == "interfaceSetAccessorDeclaration"))
                            {
                                goto IL_09DC;
                            }
                            goto IL_09B6;
                        }
                    }
                    else if (num != 2389855086U)
                    {
                        if (num != 2404319412U)
                        {
                            if (num != 2585900876U)
                            {
                                goto IL_09DC;
                            }
                            if (!(text2 == "outVariableDeclarator"))
                            {
                                goto IL_09DC;
                            }
                            goto IL_0893;
                        }
                        else
                        {
                            if (!(text2 == "namespaceDeclaration"))
                            {
                                goto IL_09DC;
                            }
                            _AIO2 = this._AEJ.ChildAt(1);
                            _bb4._ACW _AGZ3 = _AIO2 as _bb4._ACW;
                            bool flag5 = _AGZ3 != null && _AGZ3._AIX != 0;
                            if (flag5)
                            {
                                _AIO2 = _AGZ3.ChildAt(-1) ?? _AIO2;
                            }
                            goto IL_0A02;
                        }
                    }
                    else
                    {
                        if (!(text2 == "variableDeclarator"))
                        {
                            goto IL_09DC;
                        }
                        goto IL_0893;
                    }
                }
                else if (num <= 3425203650U)
                {
                    if (num <= 2950430117U)
                    {
                        if (num != 2795350912U)
                        {
                            if (num != 2866236280U)
                            {
                                if (num != 2950430117U)
                                {
                                    goto IL_09DC;
                                }
                                if (!(text2 == "addAccessorDeclaration"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09B6;
                            }
                            else
                            {
                                if (!(text2 == "fromClause"))
                                {
                                    goto IL_09DC;
                                }
                                goto IL_09A3;
                            }
                        }
                        else
                        {
                            if (!(text2 == "interfaceTypeList"))
                            {
                                goto IL_09DC;
                            }
                            _AIO2 = this._AEJ.ChildAt(0);
                            goto IL_0A02;
                        }
                    }
                    else if (num != 3295794182U)
                    {
                        if (num != 3309165359U)
                        {
                            if (num != 3425203650U)
                            {
                                goto IL_09DC;
                            }
                            if (!(text2 == "statementList"))
                            {
                                goto IL_09DC;
                            }
                            return null;
                        }
                        else
                        {
                            if (!(text2 == "interfacePropertyDeclaration"))
                            {
                                goto IL_09DC;
                            }
                            goto IL_0893;
                        }
                    }
                    else
                    {
                        if (!(text2 == "conversionOperatorDeclarator"))
                        {
                            goto IL_09DC;
                        }
                        goto IL_09D8;
                    }
                }
                else if (num <= 3543203919U)
                {
                    if (num != 3460058757U)
                    {
                        if (num != 3464504788U)
                        {
                            if (num != 3543203919U)
                            {
                                goto IL_09DC;
                            }
                            if (!(text2 == "localVariableDeclarator"))
                            {
                                goto IL_09DC;
                            }
                            goto IL_0893;
                        }
                        else if (!(text2 == "enumDeclaration"))
                        {
                            goto IL_09DC;
                        }
                    }
                    else
                    {
                        if (!(text2 == "methodHeader"))
                        {
                            goto IL_09DC;
                        }
                        goto IL_08D8;
                    }
                }
                else if (num <= 4002173414U)
                {
                    if (num != 3818230468U)
                    {
                        if (num != 4002173414U)
                        {
                            goto IL_09DC;
                        }
                        if (!(text2 == "operatorDeclarator"))
                        {
                            goto IL_09DC;
                        }
                        goto IL_09D8;
                    }
                    else
                    {
                        if (!(text2 == "setAccessorDeclaration"))
                        {
                            goto IL_09DC;
                        }
                        goto IL_09B6;
                    }
                }
                else if (num != 4136408329U)
                {
                    if (num != 4219338552U)
                    {
                        goto IL_09DC;
                    }
                    if (!(text2 == "lambdaExpression"))
                    {
                        goto IL_09DC;
                    }
                    goto IL_098B;
                }
                else if (!(text2 == "classDeclaration"))
                {
                    goto IL_09DC;
                }
            IL_086B:
                _AIO2 = this._AEJ.ChildAt(1);
                goto IL_0A02;
            IL_0893:
                _AIO2 = this._AEJ.ChildAt(0);
                goto IL_0A02;
            IL_08D8:
                _AIO2 = this._AEJ.ChildAt(0);
                goto IL_0A02;
            IL_098B:
                return this._AEJ;
            IL_09A3:
                _AIO2 = this._AEJ.FindChildByName("NAME");
                goto IL_0A02;
            IL_09B6:
                _AIO2 = this._AEJ.FindChildByName("IDENTIFIER");
                goto IL_0A02;
            IL_09C9:
                return this._AEJ.ChildAt(0);
            IL_09D8:
                return null;
            IL_09DC:
                string text3 = "Don't know how to extract symbol name from: ";
                _bb4._ACW _APQ = this._AEJ;
                Debug.LogWarning(text3 + ((_APQ != null) ? _APQ.ToString() : null));
                return null;
            IL_0A02:
                _AIO = _AIO2;
            }
            return _AIO;
        }

        // Token: 0x1700001C RID: 28
        // (get) Token: 0x0600049E RID: 1182 RVA: 0x000CD4F4 File Offset: 0x000CB6F4
        public string Name
        {
            get
            {
                bool flag = this._AW != null;
                string text;
                if (flag)
                {
                    text = this._AW;
                }
                else
                {
                    bool flag2 = this._ACV != null;
                    if (flag2)
                    {
                        text = (this._AW = this._ACV._AW);
                    }
                    else
                    {
                        bool flag3 = this._AT == SymbolKind.Constructor;
                        if (flag3)
                        {
                            text = (this._AW = ".ctor");
                        }
                        else
                        {
                            bool flag4 = this._AT == SymbolKind.Destructor;
                            if (flag4)
                            {
                                text = (this._AW = "Finalize");
                            }
                            else
                            {
                                bool flag5 = this._AT == SymbolKind.Indexer;
                                if (flag5)
                                {
                                    text = (this._AW = "Indexer");
                                }
                                else
                                {
                                    bool flag6 = this._AT == SymbolKind.LambdaExpression;
                                    if (flag6)
                                    {
                                        _bb4._ACW _AGZ = this._AEJ;
                                        while (_AGZ != null && !(_AGZ._AJW is _be7))
                                        {
                                            _AGZ = _AGZ.OOME;
                                        }
                                        this._AW = ((_AGZ != null) ? _AGZ._AJW.CreateAnonymousName() : this._AJW.CreateAnonymousName());
                                        text = this._AW;
                                    }
                                    else
                                    {
                                        bool flag7 = this._AT == SymbolKind.Accessor;
                                        if (flag7)
                                        {
                                            string text2 = this._AEJ._AHB();
                                            string text3 = text2;
                                            uint num = Helper.ComputeStringHash(text3);
                                            if (num > 1035727138U)
                                            {
                                                if (num <= 2262832473U)
                                                {
                                                    if (num != 2069287005U)
                                                    {
                                                        if (num != 2262832473U)
                                                        {
                                                            goto IL_026F;
                                                        }
                                                        if (!(text3 == "interfaceSetAccessorDeclaration"))
                                                        {
                                                            goto IL_026F;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (!(text3 == "interfaceGetAccessorDeclaration"))
                                                        {
                                                            goto IL_026F;
                                                        }
                                                        goto IL_023F;
                                                    }
                                                }
                                                else if (num != 2950430117U)
                                                {
                                                    if (num != 3818230468U)
                                                    {
                                                        goto IL_026F;
                                                    }
                                                    if (!(text3 == "setAccessorDeclaration"))
                                                    {
                                                        goto IL_026F;
                                                    }
                                                }
                                                else
                                                {
                                                    if (!(text3 == "addAccessorDeclaration"))
                                                    {
                                                        goto IL_026F;
                                                    }
                                                    return "add";
                                                }
                                                return "set";
                                            }
                                            if (num != 369023728U)
                                            {
                                                if (num != 782329552U)
                                                {
                                                    if (num != 1035727138U)
                                                    {
                                                        goto IL_026F;
                                                    }
                                                    if (!(text3 == "removeAccessorDeclaration"))
                                                    {
                                                        goto IL_026F;
                                                    }
                                                    return "remove";
                                                }
                                                else if (!(text3 == "getAccessorDeclaration"))
                                                {
                                                    goto IL_026F;
                                                }
                                            }
                                            else if (!(text3 == "readonlyAccessorDeclaration"))
                                            {
                                                goto IL_026F;
                                            }
                                        IL_023F:
                                            return "get";
                                        IL_026F:;
                                        }
                                        bool flag8 = this._AT == SymbolKind.Operator;
                                        if (flag8)
                                        {
                                            string text4 = this._AEJ._AHB();
                                            string text5 = text4;
                                            if (!(text5 == "conversionOperatorDeclarator"))
                                            {
                                                _bb4._AIN _AIO = this._AEJ.ChildAt(1);
                                                bool flag9 = _AIO != null && _AIO.IsLit("+");
                                                if (flag9)
                                                {
                                                    _bb4._ACW _AGZ2 = this._AEJ.NodeAt(-1);
                                                    text = ((_AGZ2 != null && _AGZ2._AHB() == "unaryOperatorPart") ? "op_UnaryPlus" : "op_Addition");
                                                }
                                                else
                                                {
                                                    bool flag10 = _AIO != null && _AIO.IsLit("-");
                                                    if (flag10)
                                                    {
                                                        _bb4._ACW _AGZ3 = this._AEJ.NodeAt(-1);
                                                        text = ((_AGZ3 != null && _AGZ3._AHB() == "unaryOperatorPart") ? "op_UnaryNegation" : "op_Subtraction");
                                                    }
                                                    else
                                                    {
                                                        _bb4._ACW _AGZ4 = this._AEJ.NodeAt(1);
                                                        bool flag11 = _AGZ4 == null;
                                                        if (flag11)
                                                        {
                                                            text = "UNKNOWN";
                                                        }
                                                        else
                                                        {
                                                            _AIO = _AGZ4.ChildAt(0);
                                                            bool flag12 = _AIO == null;
                                                            if (flag12)
                                                            {
                                                                text = "UNKNOWN";
                                                            }
                                                            else
                                                            {
                                                                bool flag13 = _AIO.IsLit("*");
                                                                if (flag13)
                                                                {
                                                                    text = "op_Multiply";
                                                                }
                                                                else
                                                                {
                                                                    bool flag14 = _AIO.IsLit("/");
                                                                    if (flag14)
                                                                    {
                                                                        text = "op_Division";
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag15 = _AIO.IsLit("%");
                                                                        if (flag15)
                                                                        {
                                                                            text = "op_Modulus";
                                                                        }
                                                                        else
                                                                        {
                                                                            bool flag16 = _AIO.IsLit("^");
                                                                            if (flag16)
                                                                            {
                                                                                text = "op_ExclusiveOr";
                                                                            }
                                                                            else
                                                                            {
                                                                                bool flag17 = _AIO.IsLit("&");
                                                                                if (flag17)
                                                                                {
                                                                                    text = "op_BitwiseAnd";
                                                                                }
                                                                                else
                                                                                {
                                                                                    bool flag18 = _AIO.IsLit("|");
                                                                                    if (flag18)
                                                                                    {
                                                                                        text = "op_BitwiseOr";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        bool flag19 = _AIO.IsLit("<<");
                                                                                        if (flag19)
                                                                                        {
                                                                                            text = "op_LeftShift";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            bool flag20 = _AIO.IsLit(">");
                                                                                            if (flag20)
                                                                                            {
                                                                                                _bb4._AIN _AIO2 = this._AEJ.ChildAt(2);
                                                                                                text = ((_AIO2 != null && _AIO2.IsLit(">")) ? "op_RightShift" : "op_GreaterThan");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                bool flag21 = _AIO.IsLit("==");
                                                                                                if (flag21)
                                                                                                {
                                                                                                    text = "op_Equality";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    bool flag22 = _AIO.IsLit("<");
                                                                                                    if (flag22)
                                                                                                    {
                                                                                                        text = "op_LessThan";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        bool flag23 = _AIO.IsLit("!=");
                                                                                                        if (flag23)
                                                                                                        {
                                                                                                            text = "op_Inequality";
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            bool flag24 = _AIO.IsLit(">=");
                                                                                                            if (flag24)
                                                                                                            {
                                                                                                                text = "op_GreaterThanOrEqual";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                bool flag25 = _AIO.IsLit("<=");
                                                                                                                if (flag25)
                                                                                                                {
                                                                                                                    text = "op_LessThanOrEqual";
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    bool flag26 = _AIO.IsLit("--");
                                                                                                                    if (flag26)
                                                                                                                    {
                                                                                                                        text = "op_Decrement";
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        bool flag27 = _AIO.IsLit("++");
                                                                                                                        if (flag27)
                                                                                                                        {
                                                                                                                            text = "op_Increment";
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            bool flag28 = _AIO.IsLit("~");
                                                                                                                            if (flag28)
                                                                                                                            {
                                                                                                                                text = "op_OnesComplement";
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                bool flag29 = _AIO.IsLit("!");
                                                                                                                                if (flag29)
                                                                                                                                {
                                                                                                                                    text = "op_LogicalNot";
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    bool flag30 = _AIO.IsLit("true");
                                                                                                                                    if (flag30)
                                                                                                                                    {
                                                                                                                                        text = "op_True";
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        bool flag31 = _AIO.IsLit("false");
                                                                                                                                        if (flag31)
                                                                                                                                        {
                                                                                                                                            text = "op_False";
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            text = "UNKNOWN";
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                text = (this._AEJ.ChildAt(0).IsLit("implicit") ? "op_Implicit" : "op_Explicit");
                                            }
                                        }
                                        else
                                        {
                                            _bb4._AIN _AIO3 = this.NameNode();
                                            _bb4._ACW _AGZ5 = _AIO3 as _bb4._ACW;
                                            bool flag32 = _AGZ5 != null && _AGZ5._AIX != 0 && _AGZ5._AHB() == "memberName";
                                            if (flag32)
                                            {
                                                _AGZ5 = _AGZ5.NodeAt(0);
                                                bool flag33 = _AGZ5 != null && _AGZ5._AIX != 0 && _AGZ5._AHB() == "qid";
                                                if (flag33)
                                                {
                                                    _AGZ5 = _AGZ5.NodeAt(-1);
                                                    bool flag34 = _AGZ5 != null && _AGZ5._AIX != 0;
                                                    if (flag34)
                                                    {
                                                        bool flag35 = _AGZ5._AHB() == "qidStart";
                                                        if (flag35)
                                                        {
                                                            _AIO3 = _AGZ5.ChildAt(0);
                                                        }
                                                        else
                                                        {
                                                            _AGZ5 = _AGZ5.NodeAt(0);
                                                            bool flag36 = _AGZ5 != null && _AGZ5._AIX != 0;
                                                            if (flag36)
                                                            {
                                                                _AIO3 = _AGZ5.ChildAt(1);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            _bb4.DHBA _AEM = _AIO3 as _bb4.DHBA;
                                            bool flag37 = _AEM != null && _AEM._ACX != null && _AEM._ACX.tokenKind != SyntaxToken.Kind.Identifier;
                                            if (flag37)
                                            {
                                                _AIO3 = null;
                                            }
                                            this._AW = ((_AIO3 != null) ? _AIO3.Print() : "UNKNOWN");
                                            text = this._AW;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return text;
            }
        }

        // Token: 0x0600049F RID: 1183 RVA: 0x000CDC58 File Offset: 0x000CBE58
        public string _AP()
        {
            bool flag = this._AQN == 0;
            string text;
            if (flag)
            {
                text = this.Name;
            }
            else
            {
                text = this.Name + "`" + this._AQN.ToString();
            }
            return text;
        }

        // Token: 0x060004A0 RID: 1184 RVA: 0x000CDC9C File Offset: 0x000CBE9C
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            this.Dump(stringBuilder, string.Empty);
            return stringBuilder.ToString();
        }

        // Token: 0x060004A1 RID: 1185 RVA: 0x000CDCC8 File Offset: 0x000CBEC8
        protected virtual void Dump(StringBuilder sb, string indent)
        {
            string[] array = new string[7];
            array[0] = indent;
            array[1] = this._AT.ToString();
            array[2] = " ";
            array[3] = this._AP();
            array[4] = " (";
            int num = 5;
            Type type = base.GetType();
            array[num] = ((type != null) ? type.ToString() : null);
            array[6] = ")";
            sb.AppendLine(string.Concat(array));
        }

        // Token: 0x060004A2 RID: 1186 RVA: 0x000CDD38 File Offset: 0x000CBF38
        public bool HasAllModifiers(Modifiers mods)
        {
            return (this._AV & mods) == mods;
        }

        // Token: 0x060004A3 RID: 1187 RVA: 0x000CDD58 File Offset: 0x000CBF58
        public bool HasAnyModifierOf(Modifiers mods)
        {
            return (this._AV & mods) > Modifiers.None;
        }

        // Token: 0x040004B1 RID: 1201
        public _bh4 _ACV;

        // Token: 0x040004B2 RID: 1202
        public _bm6 _AJW;

        // Token: 0x040004B3 RID: 1203
        public SymbolKind _AT;

        // Token: 0x040004B4 RID: 1204
        public _bb4._ACW _AEJ;

        // Token: 0x040004B5 RID: 1205
        public Modifiers _AV;

        // Token: 0x040004B6 RID: 1206
        public int _AQN;

        // Token: 0x040004B7 RID: 1207
        protected string _AW;
    }
}
