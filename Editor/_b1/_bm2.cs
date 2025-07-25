using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000FA RID: 250
    internal class _bm2 : _bh2
    {
        // Token: 0x06000704 RID: 1796 RVA: 0x000EAD28 File Offset: 0x000E8F28
        public static _bm2 _AGM()
        {
            return _bm2._AA ?? new _bm2();
        }

        // Token: 0x06000705 RID: 1797 RVA: 0x000EAD48 File Offset: 0x000E8F48
        public override string GetToken(int n)
        {
            return this._ASF.GetToken(n);
        }

        // Token: 0x06000706 RID: 1798 RVA: 0x000EAD68 File Offset: 0x000E8F68
        public override int TokenToId(string tokenText)
        {
            int num = this._ASF.TokenToId(tokenText);
            bool flag = num < 0;
            if (flag)
            {
                num = this._CBN;
            }
            return num;
        }

        // Token: 0x06000708 RID: 1800 RVA: 0x000EAD97 File Offset: 0x000E8F97
        [CompilerGenerated]
        internal _bh2._AJQ IODAGDLMLMILBHGAJCCLNFIJIDLOIBMOEFPC()
        {
            return this.FKDBLAPJOHEFCNDHHCEKGOABJGBCPIFCAHII;
        }

        // Token: 0x06000709 RID: 1801 RVA: 0x000EAD9F File Offset: 0x000E8F9F
        [CompilerGenerated]
        private void MANFIKJIKENHGMELHHFPNFCJGLHNBPKJNGHF(_bh2._AJQ value)
        {
            this.FKDBLAPJOHEFCNDHHCEKGOABJGBCPIFCAHII = value;
        }

        // Token: 0x17000034 RID: 52
        // (get) Token: 0x0600070A RID: 1802 RVA: 0x000EADA8 File Offset: 0x000E8FA8
        internal override _bh2._BCX GetParser
        {
            get
            {
                return this._ASF;
            }
        }

        // Token: 0x0600070B RID: 1803 RVA: 0x000EADC0 File Offset: 0x000E8FC0
        private void InitializeTokenCategories()
        {
            this._CBN = this.TokenToId("IDENTIFIER");
            this._CBG = this.TokenToId("NAME");
            this._CBK = this.TokenToId("LITERAL");
            this.MEHGHAJAPILANIBMGENBFHNIAEELJDEHHCGB = this.TokenToId("INTERP_STR_WHOLE");
            this.IJMAALOAAPKFFKBPLJAEDLOOEMEKPLGGFIOJ = this.TokenToId("INTERP_STR_START");
            this.CKCBAOEDNFKIMKMDIPBBFBNCAFEBBHFNFKBI = this.TokenToId("INTERP_STR_MID");
            this.PNAHIEKBKBGIJCGNLCGDEAEHMHEKCEFMDFEE = this.TokenToId("INTERP_STR_END");
            this.MEGFEAMOJEOFOGJCMBEJBJJBIBOODCBNANGO = this.TokenToId("INTERP_STR_FORMAT");
            this.NCHAGCLBBEFNHPICIAMMOMHPCBOOPBMOEGDB = this.TokenToId(".ATTRIBUTE");
            this._AGP = this.TokenToId(".STATEMENT");
            this._AGO = this.TokenToId(".CLASSBODY");
            this._AGQ = this.TokenToId(".STRUCTBODY");
            this._AGR = this.TokenToId(".INTERFACEBODY");
            this._AGN = this.TokenToId(".NAMESPACEBODY");
            this.AHHEGIICLMMGAMIIBCOALJAANLNIDBOHPBGH = this.TokenToId(".BINARYOPERATOR");
            this._CBI = this.TokenToId(".EXPECTEDTYPE");
            this._CBP = this.TokenToId(".MEMBERINITIALIZER");
            this.BNNEMMKGMCLMLANHKADMEEJIOFEGNPDHGMOH = this.TokenToId(".NAMEDPARAMETER");
            this._CBJ = this.TokenToId("EOF");
        }

        // Token: 0x0600070C RID: 1804 RVA: 0x000EAF14 File Offset: 0x000E9114
        public _bm2()
        {
            _bm2._AA = this;
            this._BDD = new _bh2._AEN("EOF");
            this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ = new _bh2._AEN("IDENTIFIER");
            this.PJLPDGACCJPCAGGNGOIMGGJLDDNFDCPMAMAP = new _bh2._AEN("LITERAL");
            this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND = new _bh2._BDW();
            this.PADBMJLLGAAIPKILFLHMJIFHNCEBBGFKHLJJ = new _bh2._AEN("INTERP_STR_WHOLE");
            this.NEOEKODKBFIFEHEMCOBJCNDDGIGIBIALFBBB = new _bh2._AEN("INTERP_STR_START");
            this.GPPFFDKKGDPEJFMLIIPIIFCOPNNLMFPHKMEK = new _bh2._AEN("INTERP_STR_MID");
            this.MBOCPMDAGPNEBBALHCJIKENPKHCHOMMEMDBG = new _bh2._AEN("INTERP_STR_END");
            this.FPKACCPNCJADKMOLADGCFAPFGMMJPEOPKKGD = new _bh2._AEN("INTERP_STR_FORMAT");
            _bh2._AEN _AJU = new _bh2._AEN("externAliasDirective");
            _bh2._AEN _AJU2 = new _bh2._AEN("usingDirective");
            _bh2._AEN _AJU3 = new _bh2._AEN("namespaceMemberDeclaration");
            _bh2._AEN _AJU4 = new _bh2._AEN("namespaceDeclaration");
            _bh2._AEN _AJU5 = new _bh2._AEN("qualifiedIdentifier");
            _bh2._AEN _AJU6 = new _bh2._AEN("namespaceBody");
            _bh2._AEN _AJU7 = new _bh2._AEN("attributes");
            _bh2._AEN _AJU8 = new _bh2._AEN("modifiers");
            _bh2._AEN _AJU9 = new _bh2._AEN("typeParameterList");
            _bh2._AEN _AJU10 = new _bh2._AEN("typeParameter");
            _bh2._AEN _AJU11 = new _bh2._AEN("classBase");
            _bh2._AEN _AJU12 = new _bh2._AEN("typeParameterConstraintsClauses");
            _bh2._AEN _AJU13 = new _bh2._AEN("typeParameterConstraintsClause");
            _bh2._AEN _AJU14 = new _bh2._AEN("classBody");
            _bh2._AEN _AJU15 = new _bh2._AEN("classMemberDeclaration");
            _bh2._AEN _AJU16 = new _bh2._AEN("attribute");
            _bh2._AEN _AJU17 = new _bh2._AEN("typeName");
            _bh2._AEN _AJU18 = new _bh2._AEN("argumentList");
            _bh2._AEN _AJU19 = new _bh2._AEN("attributeArgumentList");
            _bh2._AEN _AJU20 = new _bh2._AEN("expression");
            _bh2._AEN _AJU21 = new _bh2._AEN("conditionalExpression");
            _bh2._AEN _AJU22 = new _bh2._AEN("constantExpression");
            _bh2._AEN _AJU23 = new _bh2._AEN("primaryExpression");
            _bh2._AEN _AJU24 = new _bh2._AEN("arrayCreationExpression");
            _bh2._AEN _AJU25 = new _bh2._AEN("implicitArrayCreationExpression");
            _bh2._AEN _AJU26 = new _bh2._AEN("constantDeclaration");
            _bh2._AEN _AJU27 = new _bh2._AEN("fieldDeclaration");
            _bh2._AEN _AJU28 = new _bh2._AEN("methodDeclaration");
            _bh2._AEN _AJU29 = new _bh2._AEN("propertyDeclaration");
            _bh2._AEN _AJU30 = new _bh2._AEN("eventDeclaration");
            _bh2._AEN _AJU31 = new _bh2._AEN("indexerDeclaration");
            _bh2._AEN _AJU32 = new _bh2._AEN("operatorDeclaration");
            _bh2._AEN _AJU33 = new _bh2._AEN("constructorDeclaration");
            _bh2._AEN _AJU34 = new _bh2._AEN("destructorDeclaration");
            _bh2._AEN _AJU35 = new _bh2._AEN("constantDeclarators");
            _bh2._AEN _AJU36 = new _bh2._AEN("constantDeclarator");
            _bh2._AEN _AJU37 = new _bh2._AEN("type");
            _bh2._AEN _AJU38 = new _bh2._AEN("type2");
            _bh2._AEN _AJU39 = new _bh2._AEN("predefinedType");
            _bh2._AEN _AJU40 = new _bh2._AEN("variableDeclarators");
            _bh2._AEN _AJU41 = new _bh2._AEN("variableDeclarator");
            _bh2._AEN _AJU42 = new _bh2._AEN("arrayInitializer");
            _bh2._AEN _AJU43 = new _bh2._AEN("variableInitializer");
            _bh2._AEN _AJU44 = new _bh2._AEN("variableInitializerList");
            _bh2._AEN _AJU45 = new _bh2._AEN("simpleType");
            _bh2._AEN _AJU46 = new _bh2._AEN("exceptionClassType");
            _bh2._AEN _AJU47 = new _bh2._AEN("nonArrayType");
            _bh2._AEN _AJU48 = new _bh2._AEN("rankSpecifier");
            _bh2._AEN _AJU49 = new _bh2._AEN("numericType");
            _bh2._AEN _AJU50 = new _bh2._AEN("integralType");
            _bh2._AEN _AJU51 = new _bh2._AEN("floatingPointType");
            this.MANFIKJIKENHGMELHHFPNFCJGLHNBPKJNGHF(new _bh2._AJQ("compilationUnit", new _bh2._BEG(_AJU) - new _bh2._BEG(_AJU2) - new _bh2._BEG(_AJU3) - this._BDD)
            {
                _AJR = _bc1.ScopesBegin
            });
            this._ASF = new _bh2._BCX(this.IODAGDLMLMILBHGAJCCLNFIJIDLOIBMOEFPC(), this);
            this._ASF.Add(new _bh2._AJQ("externAliasDirective", new _bh2._BDS(new _bh2._ACW[] { "extern", "alias", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, ";" }))
            {
                _AJR = _bc1.ExternAlias
            });
            _bh2._AEN _AJU52 = new _bh2._AEN("usingNamespaceDirective");
            _bh2._AEN _AJU53 = new _bh2._AEN("usingAliasDirective");
            _bh2._AEN _AJU54 = new _bh2._AEN("usingStaticDirective");
            _bh2._AEN _AJU55 = new _bh2._AEN("globalNamespace");
            _bh2._AEN _AJU56 = new _bh2._AEN("namespaceName");
            _bh2._AEN _AJU57 = new _bh2._AEN("namespaceOrTypeName");
            _bh2._AEN _AJU58 = new _bh2._AEN("PARTIAL");
            _bh2._AEN _AJU59 = new _bh2._AEN("ASYNC");
            bool _AHQ = _bd5._AHR;
            if (_AHQ)
            {
                this._ASF.Add(new _bh2._AJQ("usingDirective", "using" - (new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=", _AJU53, false) | _AJU52) - ";"));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("usingDirective", "using" - (new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=", _AJU53, false) | _AJU52 | _AJU54) - ";"));
            }
            this._ASF.Add(new _bh2._AJQ("PARTIAL", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "partial", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, false) | "partial")
            {
                _BDH = true
            });
            bool flag = !_bd5._AHR;
            if (flag)
            {
                this._ASF.Add(new _bh2._AJQ("ASYNC", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "async")
                {
                    _BDH = true
                });
            }
            bool _AHQ2 = _bd5._AHR;
            if (_AHQ2)
            {
                this._ASF.Add(new _bh2._AJQ("namespaceMemberDeclaration", _AJU4 | (_AJU7 - _AJU8 - new _bh2._BDR(new _bh2._ACW[]
                {
                    new _bh2._BDS(new _bh2._ACW[]
                    {
                        new _bh2._BDU(_AJU58),
                        new _bh2._AEN("classDeclaration") | new _bh2._AEN("structDeclaration") | new _bh2._AEN("interfaceDeclaration")
                    }),
                    new _bh2._AEN("enumDeclaration"),
                    new _bh2._AEN("delegateDeclaration")
                })) | ".NAMESPACEBODY"));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("namespaceMemberDeclaration", _AJU4 | (_AJU7 - _AJU8 - new _bh2._BDR(new _bh2._ACW[]
                {
                    new _bh2._BDS(new _bh2._ACW[]
                    {
                        new _bh2._BDU(_AJU58),
                        new _bh2._AEN("classDeclaration") | new _bh2._AEN("structDeclaration") | new _bh2._AEN("interfaceDeclaration")
                    }),
                    new _bh2._AEN("enumDeclaration"),
                    new _bh2._AEN("delegateDeclaration"),
                    "ref" - new _bh2._BDU(_AJU58) - new _bh2._AEN("structDeclaration")
                })) | ".NAMESPACEBODY"));
            }
            this._ASF.Add(new _bh2._AJQ("namespaceDeclaration", "namespace" - _AJU5 - _AJU6 - new _bh2._BDU(";"))
            {
                _AJR = _bc1.NamespaceDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("qualifiedIdentifier", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BEG(new _bh2._AJI(".") - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)));
            this._ASF.Add(new _bh2._AJQ("namespaceBody", "{" - new _bh2._BEG(_AJU) - new _bh2._BEG(_AJU2) - new _bh2._BEG(_AJU3) - "}")
            {
                _AJR = _bc1.NamespaceBodyScope
            });
            this._ASF.Add(new _bh2._AJQ("usingNamespaceDirective", _AJU56)
            {
                _AJR = _bc1.UsingNamespace
            });
            this._ASF.Add(new _bh2._AJQ("namespaceName", _AJU57));
            this._ASF.Add(new _bh2._AJQ("usingAliasDirective", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=" - _AJU57)
            {
                _AJR = _bc1.UsingAlias
            });
            bool flag2 = !_bd5._AHR;
            if (flag2)
            {
                this._ASF.Add(new _bh2._AJQ("usingStaticDirective", "static" - _AJU57)
                {
                    _AJR = _bc1.UsingStatic
                });
            }
            this._ASF.Add(new _bh2._AJQ("classDeclaration", new _bh2._BDS(new _bh2._ACW[]
            {
                "class",
                this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND,
                new _bh2._BDU(_AJU9),
                new _bh2._BDU(_AJU11),
                new _bh2._BDU(_AJU12),
                _AJU14,
                new _bh2._BDU(";")
            }))
            {
                _AJR = (_bc1)7431
            });
            this._ASF.Add(new _bh2._AJQ("typeParameterList", "<" - _AJU7 - _AJU10 - new _bh2._BEG("," - _AJU7 - _AJU10) - ">"));
            this._ASF.Add(new _bh2._AJQ("typeParameter", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
            {
                _AJR = _bc1.TypeParameterDeclaration
            });
            _bh2._AEN _AJU60 = new _bh2._AEN("interfaceTypeList");
            this._ASF.Add(new _bh2._AJQ("classBase", ":" - _AJU60)
            {
                _AJR = _bc1.ClassBaseScope
            });
            this._ASF.Add(new _bh2._AJQ("interfaceTypeList", (_AJU17 | "object") - new _bh2._BEG("," - _AJU17))
            {
                _AJR = _bc1.BaseListDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("classBody", "{" - new _bh2._BEG(_AJU15) - "}")
            {
                _AJR = _bc1.ClassBodyScope
            });
            _bh2._AEN _AJU61 = new _bh2._AEN("interfaceDeclaration");
            _bh2._AEN _AJU62 = new _bh2._AEN("classDeclaration");
            _bh2._AEN _AJU63 = new _bh2._AEN("structDeclaration");
            _bh2._AEN _AJU64 = new _bh2._AEN("memberName");
            _bh2._AEN _AJU65 = new _bh2._AEN("qid");
            _bh2._AEN _AJU66 = new _bh2._AEN("enumDeclaration");
            _bh2._AEN _AJU67 = new _bh2._AEN("delegateDeclaration");
            _bh2._AEN _AJU68 = new _bh2._AEN("conversionOperatorDeclaration");
            this._ASF.Add(new _bh2._AJQ("memberName", _AJU65));
            bool flag3 = !_bd5._AHR;
            if (flag3)
            {
                this._ASF.Add(new _bh2._AJQ("classMemberDeclaration", new _bh2._BDS(new _bh2._ACW[]
                {
                    _AJU7,
                    _AJU8,
                    _AJU26 | ("void" - _AJU28) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU58 - "void", _AJU59 - _AJU8 - _AJU58 - "void" - _AJU28, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - "void", _AJU59 - _AJU8 - "void" - _AJU28, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU58 - _AJU37 - _AJU64 - "(", _AJU59 - _AJU8 - _AJU58 - _AJU37 - _AJU28, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU37 - _AJU64 - "(", _AJU59 - _AJU8 - _AJU37 - _AJU28, false) | new _bh2._BEF(_AJU58, _AJU58 - (("void" - _AJU28) | _AJU62 | _AJU63 | _AJU61), false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(", _AJU33, false) | ("ref" - (new _bh2._BEF(_AJU58, _AJU58 - _AJU63, false) | _AJU63 | (new _bh2._BDU("readonly") - _AJU37 - (new _bh2._BEF(_AJU64 - "(", _AJU28, false) | new _bh2._BEF(_AJU64 - (new _bh2._AJI("{") | "=>"), _AJU29, false) | new _bh2._BEF(_AJU64 - "this", _AJU64 - _AJU31, false) | _AJU31)))) | new _bh2._BDS(new _bh2._ACW[]
                    {
                        _AJU37,
                        new _bh2._BEF(_AJU64 - "(", _AJU28, false) | new _bh2._BEF(_AJU64 - (new _bh2._AJI("{") | "=>"), _AJU29, false) | new _bh2._BEF(_AJU64 - "this", _AJU64 - _AJU31, false) | _AJU31 | _AJU27 | _AJU32
                    }) | _AJU62 | _AJU63 | _AJU61 | _AJU66 | _AJU67 | _AJU30 | _AJU68
                }) | _AJU34 | ".CLASSBODY"));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("classMemberDeclaration", new _bh2._BDS(new _bh2._ACW[]
                {
                    _AJU7,
                    _AJU8,
                    _AJU26 | ("void" - _AJU28) | new _bh2._BEF(_AJU58, _AJU58 - (("void" - _AJU28) | _AJU62 | _AJU63 | _AJU61), false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(", _AJU33, false) | new _bh2._BDS(new _bh2._ACW[]
                    {
                        _AJU37,
                        new _bh2._BEF(_AJU64 - "(", _AJU28, false) | new _bh2._BEF(_AJU64 - "{", _AJU29, false) | new _bh2._BEF(_AJU64 - "this", _AJU64 - _AJU31, false) | _AJU31 | _AJU27 | _AJU32
                    }) | _AJU62 | _AJU63 | _AJU61 | _AJU66 | _AJU67 | _AJU30 | _AJU68
                }) | _AJU34 | ".CLASSBODY"));
            }
            _bh2._AEN _AJU69 = new _bh2._AEN("constructorDeclarator");
            _bh2._AEN _AJU70 = new _bh2._AEN("constructorBody");
            _bh2._AEN _AJU71 = new _bh2._AEN("constructorInitializer");
            _bh2._AEN _AJU72 = new _bh2._AEN("destructorDeclarator");
            _bh2._AEN _AJU73 = new _bh2._AEN("destructorBody");
            _bh2._AEN _AJU74 = new _bh2._AEN("arguments");
            _bh2._AEN _AJU75 = new _bh2._AEN("attributeArguments");
            _bh2._AEN _AJU76 = new _bh2._AEN("formalParameterList");
            _bh2._AEN _AJU77 = new _bh2._AEN("block");
            _bh2._AEN _AJU78 = new _bh2._AEN("statementList");
            this._ASF.Add(new _bh2._AJQ("constructorDeclaration", _AJU69 - _AJU70)
            {
                _AJR = (_bc1)7690
            });
            this._ASF.Add(new _bh2._AJQ("constructorDeclarator", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(" - new _bh2._BDU(_AJU76) - ")" - new _bh2._BDU(_AJU71)));
            this._ASF.Add(new _bh2._AJQ("constructorInitializer", ":" - (new _bh2._AJI("base") | "this") - _AJU74)
            {
                _AJR = _bc1.ConstructorInitializerScope
            });
            bool _AHQ3 = _bd5._AHR;
            if (_AHQ3)
            {
                this._ASF.Add(new _bh2._AJQ("constructorBody", ("{" - _AJU78 - "}") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("constructorBody", ("{" - _AJU78 - "}") | ("=>" - _AJU20 - ";") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            this._ASF.Add(new _bh2._AJQ("destructorDeclaration", _AJU72 - _AJU73)
            {
                _AJR = (_bc1)7691
            });
            this._ASF.Add(new _bh2._AJQ("destructorDeclarator", "~" - new _bh2._BDU("extern") - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(" - ")"));
            bool _AHQ4 = _bd5._AHR;
            if (_AHQ4)
            {
                this._ASF.Add(new _bh2._AJQ("destructorBody", ("{" - _AJU78 - "}") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("destructorBody", ("{" - _AJU78 - "}") | ("=>" - _AJU20 - ";") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            this._ASF.Add(new _bh2._AJQ("constantDeclaration", "const" - _AJU37 - _AJU35 - ";"));
            this._ASF.Add(new _bh2._AJQ("constantDeclarators", _AJU36 - new _bh2._BEG("," - _AJU36)));
            this._ASF.Add(new _bh2._AJQ("constantDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - "=" - _AJU22)
            {
                _AJR = _bc1.ConstantDeclarator
            });
            this._ASF.Add(new _bh2._AJQ("constantExpression", _AJU20 | ".EXPECTEDTYPE"));
            _bh2._AEN _AJU79 = new _bh2._AEN("methodHeader");
            _bh2._AEN _AJU80 = new _bh2._AEN("methodBody");
            _bh2._AEN _AJU81 = new _bh2._AEN("formalParameter");
            _bh2._AEN _AJU82 = new _bh2._AEN("fixedParameter");
            _bh2._AEN _AJU83 = new _bh2._AEN("parameterModifier");
            _bh2._AEN _AJU84 = new _bh2._AEN("defaultArgument");
            _bh2._AEN _AJU85 = new _bh2._AEN("parameterArray");
            _bh2._AEN _AJU86 = new _bh2._AEN("statement");
            _bh2._AEN _AJU87 = new _bh2._AEN("typeVariableName");
            _bh2._AEN _AJU88 = new _bh2._AEN("typeParameterConstraintList");
            _bh2._AEN _AJU89 = new _bh2._AEN("secondaryConstraintList");
            _bh2._AEN _AJU90 = new _bh2._AEN("secondaryConstraint");
            _bh2._AEN _AJU91 = new _bh2._AEN("constructorConstraint");
            _bh2._AEN _AJU92 = new _bh2._AEN("WHERE");
            this._ASF.Add(new _bh2._AJQ("methodDeclaration", _AJU79 - _AJU80)
            {
                _AJR = (_bc1)7693
            });
            this._ASF.Add(new _bh2._AJQ("methodHeader", _AJU64 - "(" - new _bh2._BDU(_AJU76) - ")" - new _bh2._BDU(_AJU12)));
            this._ASF.Add(new _bh2._AJQ("typeParameterConstraintsClauses", _AJU13 - new _bh2._BEG(_AJU13)));
            this._ASF.Add(new _bh2._AJQ("WHERE", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "where", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, false) | "where")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("typeParameterConstraintsClause", _AJU92 - _AJU87 - ":" - _AJU88));
            this._ASF.Add(new _bh2._AJQ("typeParameterConstraintList", ((new _bh2._AJI("class") | "struct") - new _bh2._BDU("," - _AJU89)) | _AJU89));
            this._ASF.Add(new _bh2._AJQ("secondaryConstraintList", (_AJU90 - new _bh2._BDU("," - new _bh2._AEN("secondaryConstraintList"))) | _AJU91));
            this._ASF.Add(new _bh2._AJQ("secondaryConstraint", _AJU17));
            this._ASF.Add(new _bh2._AJQ("typeVariableName", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ));
            this._ASF.Add(new _bh2._AJQ("constructorConstraint", new _bh2._AJI("new") - "(" - ")"));
            bool _AHQ5 = _bd5._AHR;
            if (_AHQ5)
            {
                this._ASF.Add(new _bh2._AJQ("methodBody", ("{" - _AJU78 - "}") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("methodBody", ("{" - _AJU78 - "}") | ("=>" - new _bh2._BDU("ref") - _AJU20 - ";") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            this._ASF.Add(new _bh2._AJQ("block", ("{" - _AJU78 - "}") | ";")
            {
                _AJR = _bc1.CodeBlockScope
            });
            this._ASF.Add(new _bh2._AJQ("statementList", new _bh2._BEG(new _bh2._BEJ(new _bh2._BDS(new _bh2._ACW[] { "default", ":" }), _AJU86))));
            _bh2._AEN _AJU93 = new _bh2._AEN("labeledStatement");
            _bh2._AEN _AJU94 = new _bh2._AEN("embeddedStatement");
            _bh2._AEN _AJU95 = new _bh2._AEN("selectionStatement");
            _bh2._AEN _AJU96 = new _bh2._AEN("iterationStatement");
            _bh2._AEN _AJU97 = new _bh2._AEN("jumpStatement");
            _bh2._AEN _AJU98 = new _bh2._AEN("tryStatement");
            _bh2._AEN _AJU99 = new _bh2._AEN("lockStatement");
            _bh2._AEN _AJU100 = new _bh2._AEN("usingStatement");
            _bh2._AEN _AJU101 = new _bh2._AEN("yieldStatement");
            _bh2._AEN _AJU102 = new _bh2._AEN("expressionStatement");
            _bh2._AEN _AJU103 = new _bh2._AEN("breakStatement");
            _bh2._AEN _AJU104 = new _bh2._AEN("continueStatement");
            _bh2._AEN _AJU105 = new _bh2._AEN("gotoStatement");
            _bh2._AEN _AJU106 = new _bh2._AEN("returnStatement");
            _bh2._AEN _AJU107 = new _bh2._AEN("throwStatement");
            _bh2._AEN _AJU108 = new _bh2._AEN("checkedStatement");
            _bh2._AEN _AJU109 = new _bh2._AEN("uncheckedStatement");
            _bh2._AEN _AJU110 = new _bh2._AEN("localVariableDeclaration");
            _bh2._AEN _AJU111 = new _bh2._AEN("localVariableType");
            _bh2._AEN _AJU112 = new _bh2._AEN("localVariableDeclarators");
            _bh2._AEN _AJU113 = new _bh2._AEN("localVariableDeclarator");
            _bh2._AEN _AJU114 = new _bh2._AEN("localVariableInitializer");
            _bh2._AEN _AJU115 = new _bh2._AEN("caseVariableDeclaration");
            _bh2._AEN _AJU116 = new _bh2._AEN("caseVariableDeclarator");
            _bh2._AEN _AJU117 = new _bh2._AEN("localConstantDeclaration");
            _bh2._AEN _AJU118 = new _bh2._AEN("resourceAcquisition");
            _bh2._AEN _AJU119 = new _bh2._AEN("outVariableDeclaration");
            _bh2._AEN _AJU120 = new _bh2._AEN("outVariableDeclarator");
            _bh2._AEN _AJU121 = new _bh2._AEN("VAR");
            _bh2._AEN _AJU122 = new _bh2._AEN("awaitExpression");
            this._ASF.Add(new _bh2._AJQ("VAR", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "var")
            {
                _BDH = true
            });
            bool _AHQ6 = _bd5._AHR;
            if (_AHQ6)
            {
                this._ASF.Add(new _bh2._AJQ("statement", new _bh2._BEF(new Predicate<_bh2._AJH>(this.IsAwaitInsideAsyncMethod), _AJU122, false) | new _bh2._BEF((_AJU37 | "var") - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - (new _bh2._AJI(";") | "=" | "[" | ","), _AJU110 - ";", false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - ":", _AJU93, false) | _AJU117 | _AJU94));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("statement", new _bh2._BEF(new Predicate<_bh2._AJH>(this.IsAwaitInsideAsyncMethod), _AJU122, false) | new _bh2._BEF((_AJU37 | "var") - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - (new _bh2._AJI(";") | "=" | "[" | ","), _AJU110 - ";", false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - ":", _AJU93, false) | ("ref" - new _bh2._BDU("readonly") - _AJU110 - ";") | _AJU117 | _AJU94));
            }
            this._ASF.Add(new _bh2._AJQ("localVariableDeclaration", _AJU111 - _AJU112));
            this._ASF.Add(new _bh2._AJQ("localVariableType", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "var", _AJU121, false) | _AJU37));
            this._ASF.Add(new _bh2._AJQ("localVariableDeclarators", _AJU113 - new _bh2._BEG("," - _AJU113)));
            bool _AHQ7 = _bd5._AHR;
            if (_AHQ7)
            {
                this._ASF.Add(new _bh2._AJQ("localVariableDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU("=" - _AJU114))
                {
                    _AJR = _bc1.LocalVariableDeclarator
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("localVariableDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU("=" - new _bh2._BDU("ref") - _AJU114))
                {
                    _AJR = _bc1.LocalVariableDeclarator
                });
            }
            bool flag4 = !_bd5._AHR;
            if (flag4)
            {
                this._ASF.Add(new _bh2._AJQ("caseVariableDeclaration", _AJU111 - _AJU116));
                this._ASF.Add(new _bh2._AJQ("caseVariableDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
                {
                    _AJR = _bc1.CaseVariableDeclaration
                });
            }
            this._ASF.Add(new _bh2._AJQ("localVariableInitializer", _AJU20 | _AJU42 | ".EXPECTEDTYPE")
            {
                _AJR = _bc1.LocalVariableInitializerScope
            });
            this._ASF.Add(new _bh2._AJQ("localConstantDeclaration", "const" - _AJU37 - _AJU35 - ";"));
            this._ASF.Add(new _bh2._AJQ("labeledStatement", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - ":" - _AJU86)
            {
                _AJR = _bc1.LabeledStatement
            });
            _bh2._AEN _AJU123 = new _bh2._AEN("YIELD");
            this._ASF.Add(new _bh2._AJQ("YIELD", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "yield")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("embeddedStatement", _AJU77 | _AJU95 | _AJU96 | _AJU97 | _AJU98 | _AJU99 | _AJU100 | new _bh2._BEF(delegate (_bh2._AJH s)
            {
                bool flag10 = s.Current.text != "yield";
                bool flag11;
                if (flag10)
                {
                    flag11 = false;
                }
                else
                {
                    string text2 = s.Lookahead(1, true).text;
                    flag11 = text2 == "return" || text2 == "break";
                }
                return flag11;
            }, _AJU101, false) | "yield return" | "yield break;" | new _bh2._BEF(new _bh2._AJI("checked") - "{", _AJU108, false) | new _bh2._BEF(new _bh2._AJI("unchecked") - "{", _AJU109, false) | _AJU102 | ".STATEMENT")
            {
                _AJR = _bc1.CodeBlockScope
            });
            this._ASF.Add(new _bh2._AJQ("lockStatement", new _bh2._BDS(new _bh2._ACW[] { "lock", "(", _AJU20, ")", _AJU94 })));
            this._ASF.Add(new _bh2._AJQ("checkedStatement", new _bh2._BDS(new _bh2._ACW[] { "checked", _AJU77 })));
            this._ASF.Add(new _bh2._AJQ("uncheckedStatement", new _bh2._BDS(new _bh2._ACW[] { "unchecked", _AJU77 })));
            this._ASF.Add(new _bh2._AJQ("usingStatement", new _bh2._BDS(new _bh2._ACW[] { "using", "(", _AJU118, ")", _AJU94 }))
            {
                _AJR = _bc1.UsingStatementScope
            });
            this._ASF.Add(new _bh2._AJQ("resourceAcquisition", new _bh2._BEF(_AJU111 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, _AJU110, false) | _AJU20));
            this._ASF.Add(new _bh2._AJQ("yieldStatement", _AJU123 - (("return" - _AJU20 - ";") | (new _bh2._AJI("break") - ";"))));
            _bh2._AEN _AJU124 = new _bh2._AEN("WHEN");
            this._ASF.Add(new _bh2._AJQ("WHEN", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "when", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, false) | "when")
            {
                _BDH = true
            });
            _bh2._AEN _AJU125 = new _bh2._AEN("ifStatement");
            _bh2._AEN _AJU126 = new _bh2._AEN("elseStatement");
            _bh2._AEN _AJU127 = new _bh2._AEN("switchStatement");
            _bh2._AEN _AJU128 = new _bh2._AEN("booleanExpression");
            _bh2._AEN _AJU129 = new _bh2._AEN("switchBlock");
            _bh2._AEN _AJU130 = new _bh2._AEN("switchSection");
            _bh2._AEN _AJU131 = new _bh2._AEN("switchLabel");
            _bh2._AEN _AJU132 = new _bh2._AEN("statementExpression");
            this._ASF.Add(new _bh2._AJQ("selectionStatement", _AJU125 | _AJU127));
            this._ASF.Add(new _bh2._AJQ("ifStatement", new _bh2._AJI("if") - "(" - _AJU128 - ")" - _AJU94 - new _bh2._BDU(_AJU126)));
            this._ASF.Add(new _bh2._AJQ("elseStatement", "else" - _AJU94));
            this._ASF.Add(new _bh2._AJQ("switchStatement", new _bh2._AJI("switch") - "(" - _AJU20 - ")" - _AJU129));
            this._ASF.Add(new _bh2._AJQ("switchBlock", "{" - new _bh2._BEG(_AJU130) - "}")
            {
                _AJR = _bc1.SwitchBlockScope
            });
            bool _AHQ8 = _bd5._AHR;
            if (_AHQ8)
            {
                this._ASF.Add(new _bh2._AJQ("switchSection", _AJU131 - new _bh2._BEG(_AJU131) - _AJU86 - _AJU78));
                this._ASF.Add(new _bh2._AJQ("switchLabel", ("case" - _AJU22 - ":") | new _bh2._BDS(new _bh2._ACW[] { "default", ":" })));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("switchSection", _AJU131 - new _bh2._BEG(_AJU131) - _AJU86 - _AJU78)
                {
                    _AJR = _bc1.SwitchSectionScope
                });
                this._ASF.Add(new _bh2._AJQ("switchLabel", ("case" - ((new _bh2._BEF(_AJU22 - (_AJU124 | ":"), _AJU22, false) | _AJU115) - new _bh2._BDU(_AJU124 - _AJU20) - ":")) | new _bh2._BDS(new _bh2._ACW[] { "default", ":" })));
            }
            this._ASF.Add(new _bh2._AJQ("expressionStatement", _AJU132 - ";"));
            this._ASF.Add(new _bh2._AJQ("jumpStatement", _AJU103 | _AJU104 | _AJU105 | _AJU106 | _AJU107));
            this._ASF.Add(new _bh2._AJQ("breakStatement", new _bh2._BDS(new _bh2._ACW[] { "break", ";" })));
            this._ASF.Add(new _bh2._AJQ("continueStatement", new _bh2._BDS(new _bh2._ACW[] { "continue", ";" })));
            this._ASF.Add(new _bh2._AJQ("gotoStatement", "goto" - (this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | ("case" - _AJU22) | "default") - ";"));
            bool _AHQ9 = _bd5._AHR;
            if (_AHQ9)
            {
                this._ASF.Add(new _bh2._AJQ("returnStatement", "return" - new _bh2._BDU(_AJU20) - ";"));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("returnStatement", "return" - new _bh2._BDU(new _bh2._BDU("ref") - _AJU20) - ";"));
            }
            this._ASF.Add(new _bh2._AJQ("throwStatement", "throw" - new _bh2._BDU(_AJU20) - ";"));
            _bh2._AEN _AJU133 = new _bh2._AEN("catchClauses");
            _bh2._AEN _AJU134 = new _bh2._AEN("finallyClause");
            _bh2._AEN _AJU135 = new _bh2._AEN("specificCatchClauses");
            _bh2._AEN _AJU136 = new _bh2._AEN("specificCatchClause");
            _bh2._AEN _AJU137 = new _bh2._AEN("catchExceptionIdentifier");
            _bh2._AEN _AJU138 = new _bh2._AEN("generalCatchClause");
            this._ASF.Add(new _bh2._AJQ("tryStatement", "try" - _AJU77 - ((_AJU133 - new _bh2._BDU(_AJU134)) | _AJU134)));
            bool _AHQ10 = _bd5._AHR;
            if (_AHQ10)
            {
                this._ASF.Add(new _bh2._AJQ("catchClauses", new _bh2._BEF(new _bh2._BDS(new _bh2._ACW[] { "catch", "(" }), _AJU135 - new _bh2._BDU(_AJU138), false) | _AJU138));
                this._ASF.Add(new _bh2._AJQ("specificCatchClauses", _AJU136 - new _bh2._BEG(new _bh2._BEF(new _bh2._BDS(new _bh2._ACW[] { "catch", "(" }), _AJU136, false))));
                this._ASF.Add(new _bh2._AJQ("specificCatchClause", new _bh2._AJI("catch") - "(" - _AJU46 - new _bh2._BDU(_AJU137) - ")" - _AJU77)
                {
                    _AJR = _bc1.SpecificCatchScope
                });
                this._ASF.Add(new _bh2._AJQ("generalCatchClause", "catch" - _AJU77));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("catchClauses", new _bh2._BEF("catch" - (_AJU124 | "("), _AJU135 - new _bh2._BDU(_AJU138), false) | _AJU138));
                this._ASF.Add(new _bh2._AJQ("specificCatchClauses", _AJU136 - new _bh2._BEG(new _bh2._BEF("catch" - (_AJU124 | "("), _AJU136, false))));
                this._ASF.Add(new _bh2._AJQ("specificCatchClause", new _bh2._AJI("catch") - ((_AJU124 - "(" - _AJU20 - ")" - _AJU77) | ("(" - _AJU46 - new _bh2._BDU(_AJU137) - ")" - new _bh2._BDU(_AJU124 - "(" - _AJU20 - ")") - _AJU77)))
                {
                    _AJR = _bc1.SpecificCatchScope
                });
                this._ASF.Add(new _bh2._AJQ("generalCatchClause", "catch" - new _bh2._BDU("when") - _AJU77));
            }
            this._ASF.Add(new _bh2._AJQ("catchExceptionIdentifier", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
            {
                _AJR = _bc1.CatchExceptionParameterDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("finallyClause", "finally" - _AJU77));
            this._ASF.Add(new _bh2._AJQ("formalParameterList", _AJU81 - new _bh2._BEG("," - _AJU81))
            {
                _AJR = _bc1.FormalParameterListScope
            });
            this._ASF.Add(new _bh2._AJQ("formalParameter", _AJU7 - (_AJU82 | _AJU85)));
            this._ASF.Add(new _bh2._AJQ("fixedParameter", new _bh2._BDU(_AJU83) - _AJU37 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU84))
            {
                _AJR = _bc1.FixedParameterDeclaration
            });
            bool _AHQ11 = _bd5._AHR;
            if (_AHQ11)
            {
                this._ASF.Add(new _bh2._AJQ("parameterModifier", ("ref" - new _bh2._BDU("this")) | "out" | ("this" - new _bh2._BDU("ref"))));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("parameterModifier", ("ref" - new _bh2._BDU("this")) | "out" | ("this" - new _bh2._BDU(new _bh2._AJI("ref") | "in")) | ("in" - new _bh2._BDU("this"))));
            }
            this._ASF.Add(new _bh2._AJQ("defaultArgument", "=" - (_AJU20 | ".EXPECTEDTYPE")));
            this._ASF.Add(new _bh2._AJQ("parameterArray", "params" - _AJU37 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
            {
                _AJR = _bc1.ParameterArrayDeclaration
            });
            _bh2._AEN _AJU139 = new _bh2._AEN("whileStatement");
            _bh2._AEN _AJU140 = new _bh2._AEN("doStatement");
            _bh2._AEN _AJU141 = new _bh2._AEN("forStatement");
            _bh2._AEN _AJU142 = new _bh2._AEN("foreachStatement");
            _bh2._AEN _AJU143 = new _bh2._AEN("forInitializer");
            _bh2._AEN _AJU144 = new _bh2._AEN("forIterator");
            _bh2._AEN _AJU145 = new _bh2._AEN("statementExpressionList");
            this._ASF.Add(new _bh2._AJQ("iterationStatement", _AJU139 | _AJU140 | _AJU141 | _AJU142));
            this._ASF.Add(new _bh2._AJQ("whileStatement", new _bh2._BDS(new _bh2._ACW[] { "while", "(", _AJU128, ")", _AJU94 })));
            this._ASF.Add(new _bh2._AJQ("doStatement", "do" - _AJU94 - "while" - "(" - _AJU128 - ")" - ";"));
            this._ASF.Add(new _bh2._AJQ("forStatement", new _bh2._BDS(new _bh2._ACW[]
            {
                "for",
                "(",
                new _bh2._BDU(_AJU143),
                ";",
                new _bh2._BDU(_AJU128),
                ";",
                new _bh2._BDU(_AJU144),
                ")",
                _AJU94
            }))
            {
                _AJR = _bc1.ForStatementScope
            });
            bool _AHQ12 = _bd5._AHR;
            if (_AHQ12)
            {
                this._ASF.Add(new _bh2._AJQ("forInitializer", new _bh2._BEF(_AJU111 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, _AJU110, false) | _AJU145));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("forInitializer", new _bh2._BEF(_AJU111 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, _AJU110, false) | ("ref" - new _bh2._BDU("readonly") - _AJU110) | _AJU145));
            }
            this._ASF.Add(new _bh2._AJQ("forIterator", _AJU145));
            this._ASF.Add(new _bh2._AJQ("foreachStatement", new _bh2._AJI("foreach") - "(" - _AJU111 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - "in" - _AJU20 - ")" - _AJU94)
            {
                _AJR = (_bc1)5392
            });
            this._ASF.Add(new _bh2._AJQ("statementExpressionList", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU132,
                new _bh2._BEG(new _bh2._BDS(new _bh2._ACW[] { ",", _AJU132 }))
            })));
            this._ASF.Add(new _bh2._AJQ("statementExpression", _AJU20));
            _bh2._AEN _AJU146 = new _bh2._AEN("accessorDeclarations");
            _bh2._AEN _AJU147 = new _bh2._AEN("getAccessorDeclaration");
            _bh2._AEN _AJU148 = new _bh2._AEN("setAccessorDeclaration");
            _bh2._AEN _AJU149 = new _bh2._AEN("accessorModifiers");
            _bh2._AEN _AJU150 = new _bh2._AEN("accessorBody");
            _bh2._AEN _AJU151 = new _bh2._AEN("readonlyAccessorDeclaration");
            _bh2._AEN _AJU152 = new _bh2._AEN("expressionBodiedGetAccessorBody");
            bool _AHQ13 = _bd5._AHR;
            if (_AHQ13)
            {
                this._ASF.Add(new _bh2._AJQ("indexerDeclaration", new _bh2._AJI("this") - "[" - _AJU76 - "]" - "{" - _AJU146 - "}")
                {
                    _AJR = (_bc1)8474
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("indexerDeclaration", new _bh2._AJI("this") - "[" - _AJU76 - "]" - (("{" - _AJU146 - "}") | _AJU151))
                {
                    _AJR = (_bc1)8474
                });
            }
            bool _AHQ14 = _bd5._AHR;
            if (_AHQ14)
            {
                this._ASF.Add(new _bh2._AJQ("propertyDeclaration", _AJU64 - "{" - _AJU146 - "}")
                {
                    _AJR = (_bc1)8473
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("propertyDeclaration", _AJU64 - (_AJU151 | ("{" - _AJU146 - "}" - new _bh2._BDU("=" - _AJU20 - ";"))))
                {
                    _AJR = (_bc1)8473
                });
            }
            this._ASF.Add(new _bh2._AJQ("accessorModifiers", ("internal" - new _bh2._BDU("protected")) | ("protected" - new _bh2._BDU("internal")) | "public" | "private"));
            _bh2._AEN _AJU153 = new _bh2._AEN("GET");
            _bh2._AEN _AJU154 = new _bh2._AEN("SET");
            this._ASF.Add(new _bh2._AJQ("GET", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "get")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("SET", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "set")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("accessorDeclarations", _AJU7 - new _bh2._BDU(_AJU149) - (new _bh2._BEF((_bh2._AJH s) => s.Current.text == "get", _AJU147 - new _bh2._BDU(_AJU7 - new _bh2._BDU(_AJU149) - _AJU148), false) | (_AJU148 - new _bh2._BDU(_AJU7 - new _bh2._BDU(_AJU149) - _AJU147)))));
            this._ASF.Add(new _bh2._AJQ("getAccessorDeclaration", _AJU153 - _AJU150)
            {
                _AJR = _bc1.GetAccessorDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("setAccessorDeclaration", _AJU154 - _AJU150)
            {
                _AJR = _bc1.SetAccessorDeclaration
            });
            bool _AHQ15 = _bd5._AHR;
            if (_AHQ15)
            {
                this._ASF.Add(new _bh2._AJQ("accessorBody", ("{" - _AJU78 - "}") | ";")
                {
                    _AJR = _bc1.AccessorBodyScope
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("readonlyAccessorDeclaration", "=>" - new _bh2._BDU("ref") - _AJU152)
                {
                    _AJR = _bc1.GetAccessorDeclaration
                });
                this._ASF.Add(new _bh2._AJQ("expressionBodiedGetAccessorBody", _AJU20 - ";")
                {
                    _AJR = _bc1.AccessorBodyScope
                });
                this._ASF.Add(new _bh2._AJQ("accessorBody", ("{" - _AJU78 - "}") | ("=>" - new _bh2._BDU("ref") - _AJU20 - ";") | ";")
                {
                    _AJR = _bc1.AccessorBodyScope
                });
            }
            _bh2._AEN _AJU155 = new _bh2._AEN("eventDeclarators");
            _bh2._AEN _AJU156 = new _bh2._AEN("eventDeclarator");
            _bh2._AEN _AJU157 = new _bh2._AEN("eventWithAccessorsDeclaration");
            _bh2._AEN _AJU158 = new _bh2._AEN("eventAccessorDeclarations");
            _bh2._AEN _AJU159 = new _bh2._AEN("addAccessorDeclaration");
            _bh2._AEN _AJU160 = new _bh2._AEN("removeAccessorDeclaration");
            this._ASF.Add(new _bh2._AJQ("eventDeclaration", "event" - _AJU37 - (new _bh2._BEF(_AJU64 - "{", _AJU157, false) | (_AJU155 - ";"))));
            this._ASF.Add(new _bh2._AJQ("eventWithAccessorsDeclaration", _AJU64 - "{" - _AJU158 - "}")
            {
                _AJR = (_bc1)8478
            });
            this._ASF.Add(new _bh2._AJQ("eventDeclarators", _AJU156 - new _bh2._BEG("," - _AJU156)));
            this._ASF.Add(new _bh2._AJQ("eventDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU("=" - _AJU43))
            {
                _AJR = _bc1.EventDeclarator
            });
            this._ASF.Add(new _bh2._AJQ("eventAccessorDeclarations", _AJU7 - (new _bh2._BEF((_bh2._AJH s) => s.Current.text == "add", _AJU159 - _AJU7 - _AJU160, false) | (_AJU160 - _AJU7 - _AJU159))));
            _bh2._AEN _AJU161 = new _bh2._AEN("ADD");
            _bh2._AEN _AJU162 = new _bh2._AEN("REMOVE");
            this._ASF.Add(new _bh2._AJQ("ADD", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "add")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("REMOVE", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "remove")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("addAccessorDeclaration", _AJU161 - _AJU150)
            {
                _AJR = _bc1.AddAccessorDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("removeAccessorDeclaration", _AJU162 - _AJU150)
            {
                _AJR = _bc1.RemoveAccessorDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("fieldDeclaration", _AJU40 - ";"));
            this._ASF.Add(new _bh2._AJQ("variableDeclarators", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU41,
                new _bh2._BEG(new _bh2._BDS(new _bh2._ACW[] { ",", _AJU41 }))
            })));
            this._ASF.Add(new _bh2._AJQ("variableDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU("=" - _AJU43))
            {
                _AJR = _bc1.VariableDeclarator
            });
            this._ASF.Add(new _bh2._AJQ("variableInitializer", _AJU20 | _AJU42 | ".EXPECTEDTYPE"));
            this._ASF.Add(new _bh2._AJQ("modifiers", new _bh2._BEG(new _bh2._AJI("new") | "public" | "protected" | "internal" | "private" | "abstract" | "sealed" | "static" | "readonly" | "volatile" | "virtual" | "override" | "extern")));
            _bh2._AEN _AJU163 = new _bh2._AEN("operatorDeclarator");
            _bh2._AEN _AJU164 = new _bh2._AEN("operatorBody");
            _bh2._AEN _AJU165 = new _bh2._AEN("operatorParameter");
            _bh2._AEN _AJU166 = new _bh2._AEN("binaryOperatorPart");
            _bh2._AEN _AJU167 = new _bh2._AEN("unaryOperatorPart");
            _bh2._AEN _AJU168 = new _bh2._AEN("overloadableBinaryOperator");
            _bh2._AEN _AJU169 = new _bh2._AEN("overloadableUnaryOperator");
            _bh2._AEN _AJU170 = new _bh2._AEN("conversionOperatorDeclarator");
            this._ASF.Add(new _bh2._AJQ("operatorDeclaration", _AJU163 - _AJU164));
            this._ASF.Add(new _bh2._AJQ("operatorDeclarator", new _bh2._BDS(new _bh2._ACW[]
            {
                "operator",
                new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("+") | "-",
                    "(",
                    _AJU165,
                    _AJU166 | _AJU167
                }) | (_AJU169 - "(" - _AJU165 - _AJU167) | (_AJU168 - "(" - _AJU165 - _AJU166)
            }))
            {
                _AJR = (_bc1)7714
            });
            this._ASF.Add(new _bh2._AJQ("operatorParameter", _AJU37 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
            {
                _AJR = _bc1.FixedParameterDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("unaryOperatorPart", ")"));
            this._ASF.Add(new _bh2._AJQ("binaryOperatorPart", "," - _AJU165 - ")"));
            this._ASF.Add(new _bh2._AJQ("overloadableUnaryOperator", new _bh2._AJI("!") | "~" | "++" | "--" | "true" | "false"));
            this._ASF.Add(new _bh2._AJQ("overloadableBinaryOperator", new _bh2._AJI("*") | "/" | "%" | "&" | "|" | "^" | "<<" | new _bh2._BEF(new _bh2._BDS(new _bh2._ACW[] { ">", ">" }), new _bh2._BDS(new _bh2._ACW[] { ">", ">" }), false) | "==" | "!=" | ">" | "<" | ">=" | "<="));
            this._ASF.Add(new _bh2._AJQ("conversionOperatorDeclaration", _AJU170 - _AJU164));
            this._ASF.Add(new _bh2._AJQ("conversionOperatorDeclarator", (new _bh2._AJI("implicit") | "explicit") - "operator" - _AJU37 - "(" - _AJU165 - ")")
            {
                _AJR = (_bc1)7715
            });
            bool _AHQ16 = _bd5._AHR;
            if (_AHQ16)
            {
                this._ASF.Add(new _bh2._AJQ("operatorBody", ("{" - _AJU78 - "}") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("operatorBody", ("{" - _AJU78 - "}") | ("=>" - _AJU20 - ";") | ";")
                {
                    _AJR = _bc1.MethodBodyScope
                });
            }
            _bh2._AEN _AJU171 = new _bh2._AEN("typeOrGeneric");
            _bh2._AEN _AJU172 = new _bh2._AEN("typeArgumentList");
            _bh2._AEN _AJU173 = new _bh2._AEN("unboundTypeRank");
            _bh2._AEN _AJU174 = new _bh2._AEN("structInterfaces");
            _bh2._AEN _AJU175 = new _bh2._AEN("structBody");
            _bh2._AEN _AJU176 = new _bh2._AEN("structMemberDeclaration");
            this._ASF.Add(new _bh2._AJQ("structDeclaration", "struct" - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU9) - new _bh2._BDU(_AJU174) - new _bh2._BDU(_AJU12) - _AJU175 - new _bh2._BDU(";"))
            {
                _AJR = (_bc1)7460
            });
            this._ASF.Add(new _bh2._AJQ("structInterfaces", ":" - _AJU60)
            {
                _AJR = _bc1.StructInterfacesScope
            });
            this._ASF.Add(new _bh2._AJQ("structBody", "{" - new _bh2._BEG(_AJU176) - "}")
            {
                _AJR = _bc1.StructBodyScope
            });
            bool flag5 = !_bd5._AHR;
            if (flag5)
            {
                this._ASF.Add(new _bh2._AJQ("structMemberDeclaration", new _bh2._BDS(new _bh2._ACW[]
                {
                    _AJU7,
                    _AJU8,
                    _AJU26 | ("void" - _AJU28) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU58 - "void", _AJU59 - _AJU8 - _AJU58 - "void" - _AJU28, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - "void", _AJU59 - _AJU8 - "void" - _AJU28, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU58 - _AJU37 - _AJU64 - "(", _AJU59 - _AJU8 - _AJU58 - _AJU37 - _AJU28, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU37 - _AJU64 - "(", _AJU59 - _AJU8 - _AJU37 - _AJU28, false) | new _bh2._BEF(_AJU58, _AJU58 - (("void" - _AJU28) | _AJU62 | _AJU63 | _AJU61), false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(", _AJU33, false) | ("ref" - (new _bh2._BEF(_AJU58, _AJU58 - _AJU63, false) | _AJU63 | (new _bh2._BDU("readonly") - _AJU37 - (new _bh2._BEF(_AJU64 - "(", _AJU28, false) | new _bh2._BEF(_AJU64 - (new _bh2._AJI("{") | "=>"), _AJU29, false) | new _bh2._BEF(_AJU64 - "this", _AJU64 - _AJU31, false) | _AJU31)))) | new _bh2._BDS(new _bh2._ACW[]
                    {
                        _AJU37,
                        new _bh2._BEF(_AJU64 - "(", _AJU28, false) | new _bh2._BEF(_AJU64 - (new _bh2._AJI("{") | "=>"), _AJU29, false) | new _bh2._BEF(_AJU64 - "this", _AJU64 - _AJU31, false) | _AJU31 | _AJU27 | _AJU32
                    }) | _AJU62 | _AJU63 | _AJU61 | _AJU66 | _AJU67 | _AJU30 | _AJU68 | ".STRUCTBODY"
                })));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("structMemberDeclaration", new _bh2._BDS(new _bh2._ACW[]
                {
                    _AJU7,
                    _AJU8,
                    _AJU26 | ("void" - _AJU28) | new _bh2._BEF(_AJU58, _AJU58 - (("void" - _AJU28) | _AJU62 | _AJU63 | _AJU61), false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(", _AJU33, false) | new _bh2._BDS(new _bh2._ACW[]
                    {
                        _AJU37,
                        new _bh2._BEF(_AJU64 - "(", _AJU28, false) | new _bh2._BEF(_AJU64 - "{", _AJU29, false) | new _bh2._BEF(_AJU64 - "this", _AJU64 - _AJU31, false) | _AJU31 | _AJU27 | _AJU32
                    }) | _AJU62 | _AJU63 | _AJU61 | _AJU66 | _AJU67 | _AJU30 | _AJU68 | ".STRUCTBODY"
                })));
            }
            _bh2._AEN _AJU177 = new _bh2._AEN("interfaceBase");
            _bh2._AEN _AJU178 = new _bh2._AEN("interfaceBody");
            _bh2._AEN _AJU179 = new _bh2._AEN("interfaceMemberDeclaration");
            _bh2._AEN _AJU180 = new _bh2._AEN("interfaceMethodDeclaration");
            _bh2._AEN _AJU181 = new _bh2._AEN("interfaceEventDeclaration");
            _bh2._AEN _AJU182 = new _bh2._AEN("interfacePropertyDeclaration");
            _bh2._AEN _AJU183 = new _bh2._AEN("interfaceIndexerDeclaration");
            _bh2._AEN _AJU184 = new _bh2._AEN("interfaceAccessorDeclarations");
            _bh2._AEN _AJU185 = new _bh2._AEN("interfaceGetAccessorDeclaration");
            _bh2._AEN _AJU186 = new _bh2._AEN("interfaceSetAccessorDeclaration");
            this._ASF.Add(new _bh2._AJQ("interfaceDeclaration", "interface" - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU9) - new _bh2._BDU(_AJU177) - new _bh2._BDU(_AJU12) - _AJU178 - new _bh2._BDU(";"))
            {
                _AJR = (_bc1)7461
            });
            this._ASF.Add(new _bh2._AJQ("interfaceBase", ":" - _AJU60)
            {
                _AJR = _bc1.InterfaceBaseScope
            });
            this._ASF.Add(new _bh2._AJQ("interfaceBody", "{" - new _bh2._BEG(_AJU179) - "}")
            {
                _AJR = _bc1.InterfaceBodyScope
            });
            bool flag6 = !_bd5._AHR;
            if (flag6)
            {
                this._ASF.Add(new _bh2._AJQ("interfaceMemberDeclaration", new _bh2._BDS(new _bh2._ACW[]
                {
                    _AJU7,
                    _AJU8,
                    ("void" - _AJU180) | new _bh2._BEF("async", _AJU59 - _AJU8 - "void", _AJU59 - _AJU8 - "void" - _AJU180, false) | new _bh2._BEF("async", _AJU59 - _AJU8 - _AJU37 - _AJU64 - "(", _AJU59 - _AJU8 - _AJU37 - _AJU180, false) | (new _bh2._BDU("ref" - new _bh2._BDU("readonly")) - _AJU37 - (new _bh2._BEF(_AJU64 - "(", _AJU180, false) | new _bh2._BEF(_AJU64 - "{", _AJU182, false) | _AJU183)) | _AJU181 | ".INTERFACEBODY"
                })));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("interfaceMemberDeclaration", new _bh2._BDS(new _bh2._ACW[]
                {
                    _AJU7,
                    _AJU8,
                    ("void" - _AJU180) | _AJU181 | new _bh2._BDS(new _bh2._ACW[]
                    {
                        _AJU37,
                        new _bh2._BEF(_AJU64 - "(", _AJU180, false) | new _bh2._BEF(_AJU64 - "{", _AJU182, false) | _AJU183
                    }) | ".INTERFACEBODY"
                })));
            }
            this._ASF.Add(new _bh2._AJQ("interfacePropertyDeclaration", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - "{" - _AJU184 - "}")
            {
                _AJR = _bc1.InterfacePropertyDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("interfaceMethodDeclaration", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU9) - "(" - new _bh2._BDU(_AJU76) - ")" - new _bh2._BDU(_AJU12) - ";")
            {
                _AJR = (_bc1)7719
            });
            this._ASF.Add(new _bh2._AJQ("interfaceEventDeclaration", new _bh2._BDS(new _bh2._ACW[] { "event", _AJU17, this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND, ";" }))
            {
                _AJR = _bc1.InterfaceEventDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("interfaceIndexerDeclaration", new _bh2._BDS(new _bh2._ACW[] { "this", "[", _AJU76, "]", "{", _AJU184, "}" }))
            {
                _AJR = _bc1.InterfaceIndexerDeclaration
            });
            _bh2._BCX oeimgfdjoicohiegmaoafpfpfpndgmcfgbbl = this._ASF;
            string text = "interfaceAccessorDeclarations";
            _bh2._ACW[] array = new _bh2._ACW[2];
            array[0] = _AJU7;
            array[1] = new _bh2._BEF((_bh2._AJH s) => s.Current.text == "get", _AJU185 - new _bh2._BDU(_AJU7 - _AJU186), false) | (_AJU186 - new _bh2._BDU(_AJU7 - _AJU185));
            oeimgfdjoicohiegmaoafpfpfpndgmcfgbbl.Add(new _bh2._AJQ(text, new _bh2._BDS(array)));
            this._ASF.Add(new _bh2._AJQ("interfaceGetAccessorDeclaration", _AJU153 - ";")
            {
                _AJR = _bc1.InterfaceGetAccessorDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("interfaceSetAccessorDeclaration", _AJU154 - ";")
            {
                _AJR = _bc1.InterfaceSetAccessorDeclaration
            });
            _bh2._AEN _AJU187 = new _bh2._AEN("enumBase");
            _bh2._AEN _AJU188 = new _bh2._AEN("enumBody");
            _bh2._AEN _AJU189 = new _bh2._AEN("enumMemberDeclarations");
            _bh2._AEN _AJU190 = new _bh2._AEN("enumMemberDeclaration");
            this._ASF.Add(new _bh2._AJQ("enumDeclaration", "enum" - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU187) - _AJU188 - new _bh2._BDU(";"))
            {
                _AJR = (_bc1)7468
            });
            this._ASF.Add(new _bh2._AJQ("enumBase", new _bh2._BDS(new _bh2._ACW[] { ":", _AJU50 })));
            this._ASF.Add(new _bh2._AJQ("enumBody", "{" - new _bh2._BDU(_AJU189) - "}")
            {
                _AJR = _bc1.EnumBodyScope
            });
            this._ASF.Add(new _bh2._AJQ("enumMemberDeclarations", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU190,
                new _bh2._BEG(new _bh2._BEJ(new _bh2._BDS(new _bh2._ACW[] { ",", "}" }) | "}", "," - _AJU190)),
                new _bh2._BDU(",")
            })));
            this._ASF.Add(new _bh2._AJQ("enumMemberDeclaration", _AJU7 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU("=" - _AJU22))
            {
                _AJR = _bc1.EnumMemberDeclaration
            });
            bool _AHQ17 = _bd5._AHR;
            if (_AHQ17)
            {
                this._ASF.Add(new _bh2._AJQ("delegateDeclaration", "delegate" - ("void" | _AJU37) - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU9) - "(" - new _bh2._BDU(_AJU76) - ")" - new _bh2._BDU(_AJU12) - ";")
                {
                    _AJR = (_bc1)7470
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("delegateDeclaration", "delegate" - ("void" | (new _bh2._BDU("ref" - new _bh2._BDU("readonly")) - _AJU37)) - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - new _bh2._BDU(_AJU9) - "(" - new _bh2._BDU(_AJU76) - ")" - new _bh2._BDU(_AJU12) - ";")
                {
                    _AJR = (_bc1)7470
                });
            }
            _bh2._AEN _AJU191 = new _bh2._AEN("attributeTargetSpecifier");
            _bh2._AEN _AJU192 = new _bh2._AEN("ATTRIBUTETARGET");
            this._ASF.Add(new _bh2._AJQ("ATTRIBUTETARGET", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "event:" | "return:" | "field:" | "method:" | "param:" | "property:" | "type:" | "assembly:" | "module:")
            {
                _BDH = true
            });
            this._ASF.Add(new _bh2._AJQ("attributeTargetSpecifier", (new _bh2._BEF((_bh2._AJH s) => s.Current.text == "field" || s.Current.text == "method" || s.Current.text == "param" || s.Current.text == "property" || s.Current.text == "type" || s.Current.text == "assembly" || s.Current.text == "module", _AJU192, false) | "event" | "return") - ":"));
            this._ASF.Add(new _bh2._AJQ("attributes", new _bh2._BEG("[" - new _bh2._BEF(_AJU191, _AJU191, false) - _AJU16 - new _bh2._BEG("," - _AJU16) - "]"))
            {
                _AJR = _bc1.AttributesScope
            });
            this._ASF.Add(new _bh2._AJQ("attribute", (_AJU17 - new _bh2._BDU(_AJU75)) | ".ATTRIBUTE"));
            _bh2._AEN _AJU193 = new _bh2._AEN("rankSpecifiers");
            this._ASF.Add(new _bh2._AJQ("type", (_AJU39 - new _bh2._BDU("?") - new _bh2._BDU(_AJU193)) | (_AJU17 - new _bh2._BDU("?") - new _bh2._BDU(_AJU193))));
            this._ASF.Add(new _bh2._AJQ("type2", (_AJU39 - new _bh2._BDU(_AJU193)) | (_AJU17 - new _bh2._BDU(_AJU193))));
            this._ASF.Add(new _bh2._AJQ("exceptionClassType", _AJU17 | "object" | "string"));
            this._ASF.Add(new _bh2._AJQ("nonArrayType", ((_AJU17 | _AJU45) - new _bh2._BDU("?")) | "object" | "string"));
            this._ASF.Add(new _bh2._AJQ("simpleType", _AJU49 | "bool"));
            this._ASF.Add(new _bh2._AJQ("numericType", _AJU50 | _AJU51 | "decimal"));
            this._ASF.Add(new _bh2._AJQ("integralType", new _bh2._AJI("sbyte") | "byte" | "short" | "ushort" | "int" | "uint" | "long" | "ulong" | "char"));
            this._ASF.Add(new _bh2._AJQ("floatingPointType", new _bh2._AJI("float") | "double"));
            this._ASF.Add(new _bh2._AJQ("typeName", _AJU57));
            this._ASF.Add(new _bh2._AJQ("globalNamespace", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "global"));
            this._ASF.Add(new _bh2._AJQ("namespaceOrTypeName", new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "::", _AJU55 - "::", false) - _AJU171 - new _bh2._BEG("." - _AJU171)));
            this._ASF.Add(new _bh2._AJQ("typeOrGeneric", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - new _bh2._BEF("<" - _AJU37, _AJU172, false) - new _bh2._BEF("<" - (new _bh2._AJI(",") | ">"), _AJU173, false)));
            this._ASF.Add(new _bh2._AJQ("typeArgumentList", "<" - _AJU37 - new _bh2._BEG("," - _AJU37) - ">"));
            this._ASF.Add(new _bh2._AJQ("unboundTypeRank", "<" - new _bh2._BEG(",") - ">"));
            this._ASF.Add(new _bh2._AJQ("rankSpecifier", "[" - new _bh2._BEG(",") - "]"));
            _bh2._AEN _AJU194 = new _bh2._AEN("unaryExpression");
            _bh2._AEN _AJU195 = new _bh2._AEN("assignmentOperator");
            _bh2._AEN _AJU196 = new _bh2._AEN("assignment");
            _bh2._AEN _AJU197 = new _bh2._AEN("nonAssignmentExpression");
            _bh2._AEN _AJU198 = new _bh2._AEN("castExpression");
            this._ASF.Add(new _bh2._AJQ("expression", new _bh2._BEF(_AJU194 - _AJU195, _AJU196, false) | _AJU197));
            bool flag7 = !_bd5._AHR;
            if (flag7)
            {
                this._ASF.Add(new _bh2._AJQ("assignment", _AJU194 - _AJU195 - new _bh2._BDU("ref") - (_AJU20 | ".EXPECTEDTYPE")));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("assignment", _AJU194 - _AJU195 - (_AJU20 | ".EXPECTEDTYPE")));
            }
            _bh2._AEN _AJU199 = new _bh2._AEN("preIncrementExpression");
            _bh2._AEN _AJU200 = new _bh2._AEN("preDecrementExpression");
            this._ASF.Add(new _bh2._AJQ("unaryExpression", new _bh2._BEF("(" - _AJU37 - ")" - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, _AJU198, false) | new _bh2._BEF(_AJU198, _AJU198, false) | new _bh2._BEF(new Predicate<_bh2._AJH>(this.IsAwaitInsideAsyncMethod), _AJU122, false) | (_AJU23 - new _bh2._BEG(new _bh2._AJI("++") | "--")) | new _bh2._BDS(new _bh2._ACW[]
            {
                new _bh2._AJI("+") | "-" | "!",
                _AJU194
            }) | new _bh2._BDS(new _bh2._ACW[]
            {
                "~",
                _AJU194 | ".EXPECTEDTYPE"
            }) | _AJU199 | _AJU200));
            bool flag8 = !_bd5._AHR;
            if (flag8)
            {
                _bh2._AEN _AJU201 = new _bh2._AEN("AWAIT");
                this._ASF.Add(new _bh2._AJQ("AWAIT", "await" | this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ)
                {
                    _BDH = true
                });
                this._ASF.Add(new _bh2._AJQ("awaitExpression", _AJU201 - _AJU194));
            }
            this._ASF.Add(new _bh2._AJQ("castExpression", "(" - _AJU37 - ")" - _AJU194));
            this._ASF.Add(new _bh2._AJQ("assignmentOperator", new _bh2._AJI("=") | "+=" | "-=" | "*=" | "/=" | "%=" | "&=" | "|=" | "^=" | "<<=" | new _bh2._BDS(new _bh2._ACW[] { ">", ">=" })));
            this._ASF.Add(new _bh2._AJQ("preIncrementExpression", "++" - _AJU194));
            this._ASF.Add(new _bh2._AJQ("preDecrementExpression", "--" - _AJU194));
            _bh2._AEN _AJU202 = new _bh2._AEN("brackets");
            _bh2._AEN _AJU203 = new _bh2._AEN("primaryExpressionStart");
            _bh2._AEN _AJU204 = new _bh2._AEN("primaryExpressionPart");
            _bh2._AEN _AJU205 = new _bh2._AEN("objectCreationExpression");
            _bh2._AEN _AJU206 = new _bh2._AEN("anonymousObjectCreationExpression");
            _bh2._AEN _AJU207 = new _bh2._AEN("sizeofExpression");
            _bh2._AEN _AJU208 = new _bh2._AEN("checkedExpression");
            _bh2._AEN _AJU209 = new _bh2._AEN("uncheckedExpression");
            _bh2._AEN _AJU210 = new _bh2._AEN("defaultValueExpression");
            _bh2._AEN _AJU211 = new _bh2._AEN("anonymousMethodExpression");
            _bh2._AEN _AJU212 = new _bh2._AEN("NAMEOF");
            _bh2._AEN _AJU213 = new _bh2._AEN("nameofExpression");
            bool flag9 = !_bd5._AHR;
            if (flag9)
            {
                this._ASF.Add(new _bh2._AJQ("NAMEOF", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "nameof", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "nameof", false))
                {
                    _BDH = true
                });
                this._ASF.Add(new _bh2._AJQ("nameofExpression", _AJU212 - "(" - _AJU20 - ")"));
            }
            this._ASF.Add(new _bh2._AJQ("primaryExpression", (_AJU203 - new _bh2._BEG(_AJU204)) | new _bh2._BDS(new _bh2._ACW[]
            {
                "new",
                ((_AJU47 | ".EXPECTEDTYPE") - (_AJU205 | _AJU24)) | _AJU25 | _AJU206,
                new _bh2._BEG(_AJU204)
            }) | _AJU211));
            _bh2._AEN _AJU214 = new _bh2._AEN("parenExpression");
            _bh2._AEN _AJU215 = new _bh2._AEN("typeofExpression");
            _bh2._AEN _AJU216 = new _bh2._AEN("qidStart");
            _bh2._AEN _AJU217 = new _bh2._AEN("qidPart");
            _bh2._AEN _AJU218 = new _bh2._AEN("accessIdentifier");
            this._ASF.Add(new _bh2._AJQ("typeofExpression", new _bh2._AJI("typeof") - "(" - (_AJU37 | "void") - ")"));
            this._ASF.Add(new _bh2._AJQ("predefinedType", new _bh2._AJI("bool") | "byte" | "char" | "decimal" | "double" | "float" | "int" | "long" | "object" | "sbyte" | "short" | "string" | "uint" | "ulong" | "ushort"));
            this._ASF.Add(new _bh2._AJQ("qid", _AJU216 - new _bh2._BEG(_AJU217)));
            this._ASF.Add(new _bh2._AJQ("qidStart", new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU172 - ".", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - _AJU172, false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "<", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - _AJU9, false) | (this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - new _bh2._BDU("::" - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ))));
            this._ASF.Add(new _bh2._AJQ("qidPart", new _bh2._BEF("." - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, _AJU218, false) | "."));
            _bh2._AEN _AJU219 = new _bh2._AEN("interpolatedStringLiteral");
            _bh2._AEN _AJU220 = new _bh2._AEN("stringInterpolation");
            bool _AHQ18 = _bd5._AHR;
            if (_AHQ18)
            {
                this._ASF.Add(new _bh2._AJQ("primaryExpressionStart", _AJU39 | this.PJLPDGACCJPCAGGNGOIMGGJLDDNFDCPMAMAP | "true" | "false" | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU172, this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU172, false) | (new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "::", _AJU55 - "::", false) - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ) | _AJU214 | "this" | "base" | _AJU215 | _AJU207 | _AJU208 | _AJU209 | _AJU210));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("interpolatedStringLiteral", this.PADBMJLLGAAIPKILFLHMJIFHNCEBBGFKHLJJ | (this.NEOEKODKBFIFEHEMCOBJCNDDGIGIBIALFBBB - _AJU220 - new _bh2._BEG(new _bh2._BDU(this.GPPFFDKKGDPEJFMLIIPIIFCOPNNLMFPHKMEK) - _AJU220) - this.MBOCPMDAGPNEBBALHCJIKENPKHCHOMMEMDBG)));
                this._ASF.Add(new _bh2._AJQ("stringInterpolation", "{" - _AJU20 - new _bh2._BDU("," - _AJU22) - new _bh2._BDU(":" - this.FPKACCPNCJADKMOLADGCFAPFGMMJPEOPKKGD) - "}"));
                this._ASF.Add(new _bh2._AJQ("primaryExpressionStart", _AJU39 | this.PJLPDGACCJPCAGGNGOIMGGJLDDNFDCPMAMAP | "true" | "false" | _AJU219 | new _bh2._BEF("nameof", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "(", _AJU213, false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU172, this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU172, false) | (new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "::", _AJU55 - "::", false) - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ) | _AJU214 | "this" | "base" | _AJU215 | _AJU207 | _AJU208 | _AJU209 | _AJU210));
            }
            _bh2._AEN _AJU221 = new _bh2._AEN("argument");
            _bh2._AEN _AJU222 = new _bh2._AEN("attributeArgument");
            _bh2._AEN _AJU223 = new _bh2._AEN("expressionList");
            _bh2._AEN _AJU224 = new _bh2._AEN("argumentValue");
            _bh2._AEN _AJU225 = new _bh2._AEN("argumentName");
            _bh2._AEN _AJU226 = new _bh2._AEN("attributeMemberName");
            _bh2._AEN _AJU227 = new _bh2._AEN("variableReference");
            this._ASF.Add(new _bh2._AJQ("primaryExpressionPart", _AJU218 | _AJU202 | _AJU74));
            this._ASF.Add(new _bh2._AJQ("accessIdentifier", (new _bh2._AJI(".") | "?.") - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - new _bh2._BEF(_AJU172, _AJU172, false)));
            this._ASF.Add(new _bh2._AJQ("brackets", "[" - new _bh2._BDU(_AJU223) - "]"));
            this._ASF.Add(new _bh2._AJQ("expressionList", _AJU20 - new _bh2._BEG("," - _AJU20)));
            this._ASF.Add(new _bh2._AJQ("parenExpression", "(" - _AJU20 - ")"));
            this._ASF.Add(new _bh2._AJQ("arguments", "(" - _AJU18 - ")"));
            this._ASF.Add(new _bh2._AJQ("attributeArguments", "(" - _AJU19 - ")"));
            this._ASF.Add(new _bh2._AJQ("argumentList", new _bh2._BDU(_AJU221 - new _bh2._BEG("," - _AJU221)))
            {
                _AJR = _bc1.ArgumentListScope
            });
            this._ASF.Add(new _bh2._AJQ("attributeArgumentList", new _bh2._BDU(_AJU222 - new _bh2._BEG("," - _AJU222)))
            {
                _AJR = _bc1.AttributeArgumentsScope
            });
            this._ASF.Add(new _bh2._AJQ("argument", new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - ":", _AJU225 - _AJU224, false) | _AJU224));
            this._ASF.Add(new _bh2._AJQ("attributeArgument", new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=", _AJU226 - _AJU224, false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - ":", _AJU225 - _AJU224, false) | _AJU224));
            this._ASF.Add(new _bh2._AJQ("argumentName", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - ":"));
            this._ASF.Add(new _bh2._AJQ("attributeMemberName", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "="));
            bool _AHQ19 = _bd5._AHR;
            if (_AHQ19)
            {
                this._ASF.Add(new _bh2._AJQ("argumentValue", _AJU20 | new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("out") | "ref",
                    _AJU227
                }) | ".EXPECTEDTYPE"));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("outVariableDeclaration", _AJU111 - _AJU120));
                this._ASF.Add(new _bh2._AJQ("outVariableDeclarator", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
                {
                    _AJR = _bc1.OutVariableDeclarator
                });
                this._ASF.Add(new _bh2._AJQ("argumentValue", _AJU20 | new _bh2._BEF("out" - _AJU111 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, "out" - _AJU119, false) | new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("out") | "ref" | "in",
                    _AJU227
                }) | ".EXPECTEDTYPE"));
            }
            this._ASF.Add(new _bh2._AJQ("variableReference", _AJU20));
            this._ASF.Add(new _bh2._AJQ("rankSpecifiers", "[" - new _bh2._BEG(",") - "]" - new _bh2._BEG("[" - new _bh2._BEG(",") - "]")));
            _bh2._AEN _AJU228 = new _bh2._AEN("anonymousObjectInitializer");
            _bh2._AEN _AJU229 = new _bh2._AEN("memberDeclaratorList");
            _bh2._AEN _AJU230 = new _bh2._AEN("memberDeclarator");
            _bh2._AEN _AJU231 = new _bh2._AEN("memberAccessExpression");
            this._ASF.Add(new _bh2._AJQ("anonymousObjectCreationExpression", _AJU228)
            {
                _AJR = _bc1.AnonymousObjectCreation
            });
            this._ASF.Add(new _bh2._AJQ("anonymousObjectInitializer", "{" - new _bh2._BDU(_AJU229) - new _bh2._BDU(",") - "}"));
            this._ASF.Add(new _bh2._AJQ("memberDeclaratorList", _AJU230 - new _bh2._BEG(new _bh2._BEF("," - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ, "," - _AJU230, false))));
            this._ASF.Add(new _bh2._AJQ("memberDeclarator", new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=" - _AJU20, false) | _AJU231)
            {
                _AJR = _bc1.MemberDeclarator
            });
            this._ASF.Add(new _bh2._AJQ("memberAccessExpression", _AJU20));
            _bh2._AEN _AJU232 = new _bh2._AEN("objectOrCollectionInitializer");
            _bh2._AEN _AJU233 = new _bh2._AEN("objectInitializer");
            _bh2._AEN _AJU234 = new _bh2._AEN("collectionInitializer");
            _bh2._AEN _AJU235 = new _bh2._AEN("elementInitializerList");
            _bh2._AEN _AJU236 = new _bh2._AEN("elementInitializer");
            _bh2._AEN _AJU237 = new _bh2._AEN("memberInitializerList");
            _bh2._AEN _AJU238 = new _bh2._AEN("memberInitializer");
            this._ASF.Add(new _bh2._AJQ("objectCreationExpression", (_AJU74 - new _bh2._BDU(_AJU232)) | _AJU232));
            this._ASF.Add(new _bh2._AJQ("objectOrCollectionInitializer", "{" - (new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=", _AJU233, false) | "}" | _AJU234)));
            this._ASF.Add(new _bh2._AJQ("collectionInitializer", _AJU235 - new _bh2._BDU(",") - "}"));
            this._ASF.Add(new _bh2._AJQ("elementInitializerList", _AJU236 - new _bh2._BEG(new _bh2._BEJ(new _bh2._BDU(",") - "}", "," - _AJU236))));
            this._ASF.Add(new _bh2._AJQ("elementInitializer", _AJU197 | ("{" - _AJU223 - "}") | ".EXPECTEDTYPE"));
            this._ASF.Add(new _bh2._AJQ("objectInitializer", new _bh2._BDU(_AJU237) - new _bh2._BDU(",") - (new _bh2._AJI("}") | ".MEMBERINITIALIZER")));
            this._ASF.Add(new _bh2._AJQ("memberInitializerList", _AJU238 - new _bh2._BEG(new _bh2._BEJ(new _bh2._BDU(",") - "}", "," - _AJU238)))
            {
                _AJR = _bc1.MemberInitializerScope
            });
            this._ASF.Add(new _bh2._AJQ("memberInitializer", (this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | ".MEMBERINITIALIZER") - "=" - (_AJU20 | _AJU232 | ".EXPECTEDTYPE")));
            _bh2._AEN _AJU239 = new _bh2._AEN("explicitAnonymousFunctionParameterList");
            _bh2._AEN _AJU240 = new _bh2._AEN("explicitAnonymousFunctionParameter");
            _bh2._AEN _AJU241 = new _bh2._AEN("anonymousFunctionParameterModifier");
            _bh2._AEN _AJU242 = new _bh2._AEN("explicitAnonymousFunctionSignature");
            this._ASF.Add(new _bh2._AJQ("arrayCreationExpression", new _bh2._BEF(new _bh2._BDS(new _bh2._ACW[]
            {
                "[",
                new _bh2._AJI(",") | "]"
            }), _AJU193 - _AJU42, false) | ("[" - _AJU223 - "]" - new _bh2._BDU(_AJU193) - new _bh2._BDU(_AJU42))));
            this._ASF.Add(new _bh2._AJQ("implicitArrayCreationExpression", _AJU48 - _AJU42));
            this._ASF.Add(new _bh2._AJQ("arrayInitializer", "{" - new _bh2._BDU(_AJU44) - "}"));
            this._ASF.Add(new _bh2._AJQ("variableInitializerList", _AJU43 - new _bh2._BEG(new _bh2._BEJ(new _bh2._BDS(new _bh2._ACW[] { ",", "}" }), "," - new _bh2._BDU(_AJU43))) - new _bh2._BDU(",")));
            this._ASF.Add(new _bh2._AJQ("sizeofExpression", new _bh2._AJI("sizeof") - "(" - _AJU45 - ")"));
            this._ASF.Add(new _bh2._AJQ("checkedExpression", new _bh2._AJI("checked") - "(" - _AJU20 - ")"));
            this._ASF.Add(new _bh2._AJQ("uncheckedExpression", new _bh2._AJI("unchecked") - "(" - _AJU20 - ")"));
            this._ASF.Add(new _bh2._AJQ("defaultValueExpression", new _bh2._BDS(new _bh2._ACW[] { "default", "(", _AJU37, ")" })));
            _bh2._AEN _AJU243 = new _bh2._AEN("anonymousFunctionSignature");
            _bh2._AEN _AJU244 = new _bh2._AEN("lambdaExpression");
            _bh2._AEN _AJU245 = new _bh2._AEN("queryExpression");
            _bh2._AEN _AJU246 = new _bh2._AEN("lambdaExpressionBody");
            _bh2._AEN _AJU247 = new _bh2._AEN("anonymousMethodBody");
            _bh2._AEN _AJU248 = new _bh2._AEN("implicitAnonymousFunctionParameterList");
            _bh2._AEN _AJU249 = new _bh2._AEN("implicitAnonymousFunctionParameter");
            _bh2._AEN _AJU250 = new _bh2._AEN("FROM");
            this._ASF.Add(new _bh2._AJQ("FROM", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "from")
            {
                _BDH = true
            });
            _bh2._AEN _AJU251 = new _bh2._AEN("SELECT");
            this._ASF.Add(new _bh2._AJQ("SELECT", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ)
            {
                _BDH = true
            });
            _bh2._AEN _AJU252 = new _bh2._AEN("GROUP");
            this._ASF.Add(new _bh2._AJQ("GROUP", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "group")
            {
                _BDH = true
            });
            _bh2._AEN _AJU253 = new _bh2._AEN("INTO");
            this._ASF.Add(new _bh2._AJQ("INTO", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "into", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "into", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU254 = new _bh2._AEN("ORDERBY");
            this._ASF.Add(new _bh2._AJQ("ORDERBY", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "orderby", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "orderby", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU255 = new _bh2._AEN("JOIN");
            this._ASF.Add(new _bh2._AJQ("JOIN", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "join", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "join", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU256 = new _bh2._AEN("LET");
            this._ASF.Add(new _bh2._AJQ("LET", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "let", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "let", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU257 = new _bh2._AEN("ON");
            this._ASF.Add(new _bh2._AJQ("ON", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "on", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "on", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU258 = new _bh2._AEN("EQUALS");
            this._ASF.Add(new _bh2._AJQ("EQUALS", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "equals", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "equals", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU259 = new _bh2._AEN("BY");
            this._ASF.Add(new _bh2._AJQ("BY", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "by", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "by", false))
            {
                _BDH = true
            });
            _bh2._AEN _AJU260 = new _bh2._AEN("ASCENDING_OR_DESCENDING");
            this._ASF.Add(new _bh2._AJQ("ASCENDING_OR_DESCENDING", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ | "ascending" | "descending")
            {
                _BDH = true
            });
            _bh2._AEN _AJU261 = new _bh2._AEN("fromClause");
            this._ASF.Add(new _bh2._AJQ("nonAssignmentExpression", new _bh2._BEF(_AJU243 - "=>", _AJU244, false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "in", _AJU245, false) | new _bh2._BEF(this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU37 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "in", _AJU245, false) | _AJU21));
            this._ASF.Add(new _bh2._AJQ("lambdaExpression", _AJU243 - "=>" - _AJU246)
            {
                _AJR = (_bc1)3633
            });
            this._ASF.Add(new _bh2._AJQ("anonymousFunctionSignature", new _bh2._BDS(new _bh2._ACW[]
            {
                "(",
                new _bh2._BDU(new _bh2._BEF(new _bh2._BDS(new _bh2._ACW[]
                {
                    this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ,
                    new _bh2._AJI(",") | ")"
                }), _AJU248, false) | _AJU239),
                ")"
            }) | _AJU249));
            this._ASF.Add(new _bh2._AJQ("implicitAnonymousFunctionParameterList", _AJU249 - new _bh2._BEG("," - _AJU249)));
            this._ASF.Add(new _bh2._AJQ("implicitAnonymousFunctionParameter", this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ)
            {
                _AJR = _bc1.ImplicitParameterDeclaration
            });
            bool _AHQ20 = _bd5._AHR;
            if (_AHQ20)
            {
                this._ASF.Add(new _bh2._AJQ("lambdaExpressionBody", _AJU20 | ("{" - _AJU78 - "}"))
                {
                    _AJR = _bc1.LambdaExpressionBodyScope
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("lambdaExpressionBody", (new _bh2._BDU("ref") - _AJU20) | ("{" - _AJU78 - "}"))
                {
                    _AJR = _bc1.LambdaExpressionBodyScope
                });
            }
            this._ASF.Add(new _bh2._AJQ("anonymousMethodExpression", "delegate" - new _bh2._BDU(_AJU242) - _AJU247)
            {
                _AJR = (_bc1)4146
            });
            this._ASF.Add(new _bh2._AJQ("anonymousMethodBody", "{" - _AJU78 - "}")
            {
                _AJR = _bc1.AnonymousMethodBodyScope
            });
            this._ASF.Add(new _bh2._AJQ("explicitAnonymousFunctionSignature", "(" - new _bh2._BDU(_AJU239) - ")")
            {
                _AJR = _bc1.FormalParameterListScope
            });
            this._ASF.Add(new _bh2._AJQ("explicitAnonymousFunctionParameterList", _AJU240 - new _bh2._BEG("," - _AJU240)));
            this._ASF.Add(new _bh2._AJQ("explicitAnonymousFunctionParameter", new _bh2._BDU(_AJU241) - _AJU37 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)
            {
                _AJR = _bc1.ExplicitParameterDeclaration
            });
            bool _AHQ21 = _bd5._AHR;
            if (_AHQ21)
            {
                this._ASF.Add(new _bh2._AJQ("anonymousFunctionParameterModifier", new _bh2._AJI("ref") | "out"));
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("anonymousFunctionParameterModifier", new _bh2._AJI("ref") | "out" | "in"));
            }
            _bh2._AEN _AJU262 = new _bh2._AEN("queryBody");
            _bh2._AEN _AJU263 = new _bh2._AEN("queryBodyClause");
            _bh2._AEN _AJU264 = new _bh2._AEN("queryContinuation");
            _bh2._AEN _AJU265 = new _bh2._AEN("letClause");
            _bh2._AEN _AJU266 = new _bh2._AEN("whereClause");
            _bh2._AEN _AJU267 = new _bh2._AEN("joinClause");
            _bh2._AEN _AJU268 = new _bh2._AEN("orderbyClause");
            _bh2._AEN _AJU269 = new _bh2._AEN("orderingList");
            _bh2._AEN _AJU270 = new _bh2._AEN("ordering");
            _bh2._AEN _AJU271 = new _bh2._AEN("selectClause");
            _bh2._AEN _AJU272 = new _bh2._AEN("groupClause");
            this._ASF.Add(new _bh2._AJQ("queryExpression", _AJU261 - _AJU262)
            {
                _AJR = _bc1.QueryExpressionScope
            });
            this._ASF.Add(new _bh2._AJQ("fromClause", _AJU250 - (new _bh2._BEF(this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND - "in", this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND, false) | (_AJU37 - this.EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND)) - "in" - _AJU20)
            {
                _AJR = _bc1.FromClauseVariableDeclaration
            });
            this._ASF.Add(new _bh2._AJQ("queryBody", new _bh2._BEG(new _bh2._BEF((_bh2._AJH s) => (s.Current.text == "from") | (s.Current.text == "let") | (s.Current.text == "join") | (s.Current.text == "orderby") | (s.Current.text == "where"), _AJU263, false)) - (new _bh2._BEF((_bh2._AJH s) => s.Current.text == "select", _AJU271, false) | "select" | _AJU272) - new _bh2._BDU(_AJU264))
            {
                _AJR = _bc1.QueryBodyScope
            });
            this._ASF.Add(new _bh2._AJQ("queryContinuation", _AJU253 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - _AJU262));
            this._ASF.Add(new _bh2._AJQ("queryBodyClause", new _bh2._BEF((_bh2._AJH s) => s.Current.text == "from", _AJU261, false) | new _bh2._BEF((_bh2._AJH s) => s.Current.text == "let", _AJU265, false) | new _bh2._BEF((_bh2._AJH s) => s.Current.text == "join", _AJU267, false) | new _bh2._BEF((_bh2._AJH s) => s.Current.text == "orderby", _AJU268, false) | _AJU266));
            this._ASF.Add(new _bh2._AJQ("joinClause", _AJU255 - new _bh2._BDU(_AJU37) - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "in" - _AJU20 - _AJU257 - _AJU20 - _AJU258 - _AJU20 - new _bh2._BDU(_AJU253 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ)));
            this._ASF.Add(new _bh2._AJQ("letClause", _AJU256 - this.JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ - "=" - _AJU20));
            this._ASF.Add(new _bh2._AJQ("orderbyClause", _AJU254 - _AJU269));
            this._ASF.Add(new _bh2._AJQ("orderingList", _AJU270 - new _bh2._BEG("," - _AJU270)));
            this._ASF.Add(new _bh2._AJQ("ordering", _AJU20 - new _bh2._BDU(new _bh2._BEF((_bh2._AJH s) => s.Current.text == "ascending" || s.Current.text == "descending", _AJU260, false))));
            this._ASF.Add(new _bh2._AJQ("selectClause", _AJU251 - _AJU20));
            this._ASF.Add(new _bh2._AJQ("groupClause", _AJU252 - _AJU20 - _AJU259 - _AJU20));
            this._ASF.Add(new _bh2._AJQ("whereClause", _AJU92 - _AJU128));
            this._ASF.Add(new _bh2._AJQ("booleanExpression", _AJU20));
            _bh2._AEN _AJU273 = new _bh2._AEN("nullCoalescingExpression");
            _bh2._AEN _AJU274 = new _bh2._AEN("conditionalOrExpression");
            _bh2._AEN _AJU275 = new _bh2._AEN("conditionalAndExpression");
            _bh2._AEN _AJU276 = new _bh2._AEN("inclusiveOrExpression");
            _bh2._AEN _AJU277 = new _bh2._AEN("exclusiveOrExpression");
            _bh2._AEN _AJU278 = new _bh2._AEN("andExpression");
            _bh2._AEN _AJU279 = new _bh2._AEN("equalityExpression");
            _bh2._AEN _AJU280 = new _bh2._AEN("relationalExpression");
            _bh2._AEN _AJU281 = new _bh2._AEN("shiftExpression");
            _bh2._AEN _AJU282 = new _bh2._AEN("additiveExpression");
            _bh2._AEN _AJU283 = new _bh2._AEN("multiplicativeExpression");
            bool _AHQ22 = _bd5._AHR;
            if (_AHQ22)
            {
                this._ASF.Add(new _bh2._AJQ("conditionalExpression", _AJU273 - new _bh2._BDU("?" - _AJU20 - ":" - _AJU20))
                {
                    _BDM = true
                });
            }
            else
            {
                this._ASF.Add(new _bh2._AJQ("conditionalExpression", _AJU273 - new _bh2._BDU("?" - (("ref" - _AJU20 - ":" - "ref" - _AJU20) | (_AJU20 - ":" - _AJU20))))
                {
                    _BDM = true
                });
            }
            this._ASF.Add(new _bh2._AJQ("nullCoalescingExpression", _AJU274 - new _bh2._BEG("??" - _AJU274))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("conditionalOrExpression", _AJU275 - new _bh2._BEG("||" - _AJU275))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("conditionalAndExpression", _AJU276 - new _bh2._BEG("&&" - _AJU276))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("inclusiveOrExpression", _AJU277 - new _bh2._BEG("|" - (_AJU277 | ".EXPECTEDTYPE")))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("exclusiveOrExpression", _AJU278 - new _bh2._BEG("^" - _AJU278))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("andExpression", _AJU279 - new _bh2._BEG("&" - (_AJU279 | ".EXPECTEDTYPE")))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("equalityExpression", _AJU280 - new _bh2._BEG((new _bh2._AJI("==") | "!=") - (_AJU280 | ".EXPECTEDTYPE")))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("relationalExpression", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU281,
                new _bh2._BEG(new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("<") | ">" | "<=" | ">=",
                    _AJU281 | ".EXPECTEDTYPE"
                }) | new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("is") | "as",
                    new _bh2._BEF(_AJU38 - "?" - _AJU20 - ":", _AJU38, false) | _AJU37
                }))
            }))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("shiftExpression", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU282,
                new _bh2._BEG(new _bh2._BEF(new _bh2._BDS(new _bh2._ACW[] { ">", ">" }) | "<<", new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._BDS(new _bh2._ACW[] { ">", ">" }) | "<<",
                    _AJU282
                }), false))
            }))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("additiveExpression", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU283,
                new _bh2._BEG(new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("+") | "-",
                    _AJU283
                }))
            }))
            {
                _BDM = true
            });
            this._ASF.Add(new _bh2._AJQ("multiplicativeExpression", new _bh2._BDS(new _bh2._ACW[]
            {
                _AJU194,
                new _bh2._BEG(new _bh2._BDS(new _bh2._ACW[]
                {
                    new _bh2._AJI("*") | "/" | "%",
                    _AJU194
                }))
            }))
            {
                _BDM = true
            });
            _bh2._AJQ._BEM = false;
            this._ASF.InitializeGrammar();
            this.InitializeTokenCategories();
        }

        // Token: 0x0600070D RID: 1805 RVA: 0x000F2E54 File Offset: 0x000F1054
        internal void Parse(GCE.PHFG[] lines, string bufferName)
        {
            _bm2._AJS _AQP = _bm2._AJS.New(this, lines, bufferName);
            try
            {
                this._ASF.ParseAll(_AQP);
            }
            catch (Exception ex)
            {
                string[] array = new string[8];
                array[0] = "Parsing crashed at line: ";
                array[1] = _AQP.CurrentLine().ToString();
                array[2] = ", token ";
                array[3] = _AQP.CurrentTokenIndex().ToString();
                array[4] = " with:\n    ";
                int num = 5;
                Exception ex2 = ex;
                array[num] = ((ex2 != null) ? ex2.ToString() : null);
                array[6] = " at ";
                array[7] = ex.StackTrace;
                Debug.LogError(string.Concat(array));
                Debug.Log(string.Concat(new string[]
                {
                    "Current token: ",
                    _AQP.Current.tokenKind.ToString(),
                    " '",
                    _AQP.Current.text,
                    "'"
                }));
            }
            _AQP.Delete();
        }

        // Token: 0x0600070E RID: 1806 RVA: 0x000F2F58 File Offset: 0x000F1158
        internal _bb4 ParseAll(_bm2._AJS scanner)
        {
            return this._ASF.ParseAll(scanner);
        }

        // Token: 0x0600070F RID: 1807 RVA: 0x000F2F78 File Offset: 0x000F1178
        public bool ParseLine(_bm2._AJS scanner, int line)
        {
            int num = ((scanner._BDN != null) ? 1 : 0);
            while (scanner.CurrentLine() - 1 <= line)
            {
                int num2 = scanner.CurrentLine();
                int num3 = scanner.CurrentTokenIndex();
                _bh2._ACW _BEX = scanner._BDL;
                _bb4._ACW _BEY = scanner._AJT;
                bool flag = !this._ASF.ParseStep(scanner);
                if (flag)
                {
                    return false;
                }
                bool flag2 = scanner._BDN != null;
                if (flag2)
                {
                    num++;
                }
                else
                {
                    bool flag3 = scanner._AJT == _BEY && scanner._BDL == _BEX && scanner.CurrentTokenIndex() == num3 && scanner.CurrentLine() == num2;
                    if (flag3)
                    {
                        this._ASF._BEZ = false;
                    }
                    num = 0;
                }
            }
            return num < 10;
        }

        // Token: 0x06000710 RID: 1808 RVA: 0x000F304C File Offset: 0x000F124C
        internal override _bf4 GetCompletionTypes(_bb4._AIN afterNode)
        {
            _bf4 _CBT = (_bf4)2054;
            _bb4.DHBA _AEM = afterNode as _bb4.DHBA;
            bool flag = _AEM == null;
            _bf4 _CBT2;
            if (flag)
            {
                _CBT2 = _CBT;
            }
            else
            {
                bool flag2 = _AEM._ACX.text == ".";
                if (flag2)
                {
                    _CBT = (_bf4)2564;
                }
                else
                {
                    bool flag3 = _AEM._ACX.text == "::";
                    if (flag3)
                    {
                        _CBT = (_bf4)518;
                    }
                    else
                    {
                        bool flag4 = _AEM._ACX.text == "?.";
                        if (flag4)
                        {
                            _CBT = (_bf4)512;
                        }
                    }
                }
                short num = afterNode._AIL;
                _bb4._ACW _AGZ = afterNode.OOME;
                while (_AGZ != null)
                {
                    string text = _AGZ._AHB();
                    string text2 = text;
                    uint num2 = Helper.ComputeStringHash(text2);
                    if (num2 <= 2622508398U)
                    {
                        if (num2 > 567569430U)
                        {
                            if (num2 <= 1047347951U)
                            {
                                if (num2 != 693225631U)
                                {
                                    if (num2 != 1047347951U)
                                    {
                                        goto IL_0318;
                                    }
                                    if (!(text2 == "attribute"))
                                    {
                                        goto IL_0318;
                                    }
                                    goto IL_02CF;
                                }
                                else if (!(text2 == "arguments"))
                                {
                                    goto IL_0318;
                                }
                            }
                            else if (num2 != 2371411181U)
                            {
                                if (num2 != 2622508398U)
                                {
                                    goto IL_0318;
                                }
                                if (!(text2 == "typeName"))
                                {
                                    goto IL_0318;
                                }
                                _CBT &= (_bf4)(-2049);
                                goto IL_0318;
                            }
                            else if (!(text2 == "attributeArguments"))
                            {
                                goto IL_0318;
                            }
                            break;
                        }
                        if (num2 != 177373158U)
                        {
                            if (num2 != 237698322U)
                            {
                                if (num2 == 567569430U)
                                {
                                    if (text2 == "namespaceOrTypeName")
                                    {
                                        _CBT &= (_bf4)(-2049);
                                    }
                                }
                            }
                            else if (!(text2 == "usingStaticDirective"))
                            {
                            }
                        }
                        else if (!(text2 == "usingAliasDirective"))
                        {
                        }
                    }
                    else if (num2 <= 3549306485U)
                    {
                        if (num2 != 3335511552U)
                        {
                            if (num2 != 3366671281U)
                            {
                                if (num2 == 3549306485U)
                                {
                                    if (text2 == "argumentName")
                                    {
                                        _CBT = (_bf4)4096;
                                        break;
                                    }
                                }
                            }
                            else if (text2 == "typeOrGeneric")
                            {
                                _CBT = (_bf4)4;
                                break;
                            }
                        }
                        else if (text2 == "accessIdentifier")
                        {
                            _CBT &= (_bf4)(-3);
                            break;
                        }
                    }
                    else if (num2 <= 3806680326U)
                    {
                        if (num2 != 3791641492U)
                        {
                            if (num2 == 3806680326U)
                            {
                                if (text2 == "exceptionClassType")
                                {
                                    break;
                                }
                            }
                        }
                        else if (text2 == "attributes")
                        {
                            goto IL_02CF;
                        }
                    }
                    else if (num2 != 3836030979U)
                    {
                        if (num2 == 4220349718U)
                        {
                            if (text2 == "statement")
                            {
                                bool flag5 = num == 0;
                                if (flag5)
                                {
                                    _CBT |= (_bf4)2054;
                                }
                            }
                        }
                    }
                    else if (text2 == "namespaceName")
                    {
                        _CBT &= (_bf4)(-2053);
                    }
                IL_0318:
                    num = _AGZ._AIL;
                    _AGZ = _AGZ.OOME;
                    continue;
                IL_02CF:
                    _CBT |= (_bf4)256;
                    break;
                }
                _CBT2 = _CBT;
            }
            return _CBT2;
        }

        // Token: 0x06000711 RID: 1809 RVA: 0x000F339C File Offset: 0x000F159C
        internal static _bb4._ACW EnclosingSemanticNode(_bb4._AIN node, _bc1 flags)
        {
            bool flag = node is _bb4.DHBA;
            _bb4._ACW _AGZ;
            if (flag)
            {
                _AGZ = _bm2.EnclosingSemanticNode(node.OOME, flags);
            }
            else
            {
                _AGZ = _bm2.EnclosingSemanticNode((_bb4._ACW)node, flags);
            }
            return _AGZ;
        }

        // Token: 0x06000712 RID: 1810 RVA: 0x000F33D8 File Offset: 0x000F15D8
        internal static _bb4._ACW EnclosingSemanticNode(_bb4._ACW node, _bc1 flags)
        {
            while (node != null)
            {
                _bc1 _CHG = node._AJO() & flags;
                bool flag = _CHG > _bc1.None;
                if (flag)
                {
                    return node;
                }
                node = node.OOME;
            }
            return null;
        }

        // Token: 0x06000713 RID: 1811 RVA: 0x000F3414 File Offset: 0x000F1614
        internal static _bb4._ACW EnclosingScopeNode(_bb4._ACW node)
        {
            while (node != null)
            {
                _bc1 _CHG = node._AJO() & _bc1.ScopesMask;
                bool flag = _CHG > _bc1.None;
                if (flag)
                {
                    return node;
                }
                node = node.OOME;
            }
            return null;
        }

        // Token: 0x06000714 RID: 1812 RVA: 0x000F3454 File Offset: 0x000F1654
        internal static _bb4._ACW EnclosingScopeNode(_bb4._ACW node, _bc1 scopeType)
        {
            while (node != null)
            {
                _bc1 _CHG = node._AJO() & _bc1.ScopesMask;
                bool flag = _CHG > _bc1.None;
                if (flag)
                {
                    bool flag2 = scopeType == _CHG;
                    if (flag2)
                    {
                        return node;
                    }
                }
                node = node.OOME;
            }
            return null;
        }

        // Token: 0x06000715 RID: 1813 RVA: 0x000F34A0 File Offset: 0x000F16A0
        internal static _bb4._ACW EnclosingScopeNode(_bb4._ACW node, _bc1 scopeType1, _bc1 scopeType2)
        {
            while (node != null)
            {
                _bc1 _CHG = node._AJO() & _bc1.ScopesMask;
                bool flag = _CHG > _bc1.None;
                if (flag)
                {
                    bool flag2 = scopeType1 == _CHG || scopeType2 == _CHG;
                    if (flag2)
                    {
                        return node;
                    }
                }
                node = node.OOME;
            }
            return null;
        }

        // Token: 0x06000716 RID: 1814 RVA: 0x000F34F4 File Offset: 0x000F16F4
        internal static _bb4._ACW EnclosingScopeNode(_bb4._ACW node, _bc1 scopeType1, _bc1 scopeType2, _bc1 scopeType3)
        {
            while (node != null)
            {
                _bc1 _CHG = node._AJO() & _bc1.ScopesMask;
                bool flag = _CHG > _bc1.None;
                if (flag)
                {
                    bool flag2 = scopeType1 == _CHG || scopeType2 == _CHG || scopeType3 == _CHG;
                    if (flag2)
                    {
                        return node;
                    }
                }
                node = node.OOME;
            }
            return null;
        }

        // Token: 0x06000717 RID: 1815 RVA: 0x000F354C File Offset: 0x000F174C
        private static _bm6 GetNodeScope(_bb4._ACW node, string fileName = null)
        {
            bool flag = node == null;
            _bm6 _AQI;
            if (flag)
            {
                _AQI = null;
            }
            else
            {
                _bn4 _AQH = node._AJW as _bn4;
                bool flag2 = node._AJW == null || (_AQH != null && _AQH.EFI == null);
                if (flag2)
                {
                    _bb4._ACW _AGZ = _bm2.EnclosingSemanticNode(node.OOME, _bc1.ScopesMask);
                    _bm6 nodeScope = _bm2.GetNodeScope(_AGZ, fileName);
                    _bc1 _CHG = node._AJO() & _bc1.ScopesMask;
                    _bc1 _CHG2 = _CHG;
                    _bc1 _CHG3 = _CHG2;
                    if (_CHG3 <= _bc1.CodeBlockScope)
                    {
                        FKI _AFF;
                        if (_CHG3 <= _bc1.InterfaceBodyScope)
                        {
                            if (_CHG3 <= _bc1.TypeParameterConstraintsScope)
                            {
                                if (_CHG3 <= _bc1.NamespaceBodyScope)
                                {
                                    if (_CHG3 != _bc1.ScopesBegin)
                                    {
                                        if (_CHG3 != _bc1.NamespaceBodyScope)
                                        {
                                            goto IL_0794;
                                        }
                                        _AFF = _bm2.GetNodeDeclaration(node.OOME, null);
                                        _bc8 _APS = new _bc8(node);
                                        _APS.EFI = (_bf8)_AFF;
                                        _APS._ACV = ((_AFF != null) ? ((_bn1)_AFF._ACV) : null);
                                        _APS.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                        node._AJW = _APS;
                                        goto IL_07CB;
                                    }
                                    else
                                    {
                                        _be7 compilationUnitScope = _bj5.GetCompilationUnitScope(fileName, true);
                                        bool flag3 = compilationUnitScope == null;
                                        if (flag3)
                                        {
                                            return null;
                                        }
                                        compilationUnitScope.EFI._AEJ = node;
                                        node._AJW = compilationUnitScope;
                                        goto IL_07CB;
                                    }
                                }
                                else if (_CHG3 != _bc1.ClassBaseScope)
                                {
                                    if (_CHG3 != _bc1.TypeParameterConstraintsScope)
                                    {
                                        goto IL_0794;
                                    }
                                    _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl = new _bn2(node);
                                    pfmepljdkgnppejbglhfbhkgndaojcnfjjfl.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                    node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl;
                                    goto IL_07CB;
                                }
                            }
                            else if (_CHG3 <= _bc1.StructInterfacesScope)
                            {
                                if (_CHG3 == _bc1.ClassBodyScope)
                                {
                                    goto IL_040C;
                                }
                                if (_CHG3 != _bc1.StructInterfacesScope)
                                {
                                    goto IL_0794;
                                }
                            }
                            else
                            {
                                if (_CHG3 == _bc1.StructBodyScope)
                                {
                                    goto IL_040C;
                                }
                                if (_CHG3 != _bc1.InterfaceBaseScope)
                                {
                                    if (_CHG3 != _bc1.InterfaceBodyScope)
                                    {
                                        goto IL_0794;
                                    }
                                    goto IL_040C;
                                }
                            }
                            _AFF = (nodeScope as _bn4).EFI;
                            NLGEOGIKCPGHIFEMBHMJCBHPIFHBPGOJKCJI nlgeogikcpghifembhmjcbhpifhbpgojkcji = new NLGEOGIKCPGHIFEMBHMJCBHPIFHBPGOJKCJI(node);
                            nlgeogikcpghifembhmjcbhpifhbpgojkcji.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            nlgeogikcpghifembhmjcbhpifhbpgojkcji._ACV = ((_AFF != null) ? (_AFF._ACV as _b2) : null);
                            node._AJW = nlgeogikcpghifembhmjcbhpifhbpgojkcji;
                            goto IL_07CB;
                        }
                        if (_CHG3 > _bc1.ConstructorInitializerScope)
                        {
                            if (_CHG3 <= _bc1.LambdaExpressionBodyScope)
                            {
                                if (_CHG3 != _bc1.LambdaExpressionScope)
                                {
                                    if (_CHG3 != _bc1.LambdaExpressionBodyScope)
                                    {
                                        goto IL_0794;
                                    }
                                    goto IL_048E;
                                }
                            }
                            else if (_CHG3 != _bc1.AnonymousMethodScope)
                            {
                                if (_CHG3 == _bc1.AnonymousMethodBodyScope)
                                {
                                    goto IL_048E;
                                }
                                if (_CHG3 != _bc1.CodeBlockScope)
                                {
                                    goto IL_0794;
                                }
                                goto IL_057C;
                            }
                            _AFF = _bm2.GetNodeDeclaration(node, null);
                            _bn4 _AQH2 = new _bn4(node);
                            _AQH2.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            _AQH2.EFI = _AFF;
                            node._AJW = _AQH2;
                            goto IL_07CB;
                        IL_048E:
                            _AFF = _bm2.GetNodeDeclaration(node.OOME, null);
                            _bj8 _BEZ = new _bj8(node);
                            _BEZ.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            _BEZ._ACV = _AFF._ACV;
                            node._AJW = _BEZ;
                            goto IL_07CB;
                        }
                        if (_CHG3 <= _bc1.EnumBodyScope)
                        {
                            if (_CHG3 == _bc1.FormalParameterListScope)
                            {
                                _AFF = (((node.OOME._AJO() & _bc1.SymbolDeclarationsMask) != _bc1.None) ? _bm2.GetNodeDeclaration(node.OOME, null) : _bm2.GetNodeDeclaration(node.OOME.OOME, null));
                                bool flag4 = _AFF != null;
                                if (flag4)
                                {
                                    _bj8 _BEZ2 = new _bj8(node);
                                    _BEZ2.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                    _BEZ2._ACV = _AFF._ACV;
                                    node._AJW = _BEZ2;
                                }
                                goto IL_07CB;
                            }
                            if (_CHG3 != _bc1.EnumBodyScope)
                            {
                                goto IL_0794;
                            }
                        }
                        else
                        {
                            if (_CHG3 == _bc1.MethodBodyScope)
                            {
                                bool flag5 = (node.OOME._AJO() & _bc1.SymbolDeclarationsMask) > _bc1.None;
                                if (flag5)
                                {
                                    _AFF = _bm2.GetNodeDeclaration(node.OOME, null);
                                }
                                else
                                {
                                    _AFF = ((node.OOME.NodeAt(0) == null) ? null : _bm2.GetNodeDeclaration(node.OOME.NodeAt(0), null));
                                }
                                _bm6 _AQI2;
                                if (_AFF != null)
                                {
                                    _bj8 _BEZ3 = new _bj8(node);
                                    _BEZ3.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                    _AQI2 = _BEZ3;
                                    _BEZ3._ACV = _AFF._ACV;
                                }
                                else
                                {
                                    _AQI2 = null;
                                }
                                node._AJW = _AQI2;
                                goto IL_07CB;
                            }
                            if (_CHG3 != _bc1.ConstructorInitializerScope)
                            {
                                goto IL_0794;
                            }
                            _bk1 mdaepkfbdjnhibpdacpfaaleochkoccedffc = new _bk1(node);
                            mdaepkfbdjnhibpdacpfaaleochkoccedffc.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            node._AJW = mdaepkfbdjnhibpdacpfaaleochkoccedffc;
                            goto IL_07CB;
                        }
                    IL_040C:
                        _AFF = _bm2.GetNodeDeclaration(node.OOME, null);
                        bool flag6 = _AFF == null;
                        if (flag6)
                        {
                            _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl2 = new _bn2(node);
                            pfmepljdkgnppejbglhfbhkgndaojcnfjjfl2.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl2;
                        }
                        else
                        {
                            _bj8 _BEZ4 = new _bj8(node);
                            _BEZ4.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            _BEZ4._ACV = _AFF._ACV;
                            node._AJW = _BEZ4;
                        }
                        goto IL_07CB;
                    }
                    if (_CHG3 <= _bc1.AttributeArgumentsScope)
                    {
                        if (_CHG3 <= _bc1.EmbeddedStatementScope)
                        {
                            if (_CHG3 <= _bc1.SwitchSectionScope)
                            {
                                if (_CHG3 != _bc1.SwitchBlockScope)
                                {
                                    if (_CHG3 != _bc1.SwitchSectionScope)
                                    {
                                        goto IL_0794;
                                    }
                                    _bh5 khacndfpokhiekfdajlkpgmdeobhnmnjaeoh = new _bh5(node);
                                    khacndfpokhiekfdajlkpgmdeobhnmnjaeoh.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                    node._AJW = khacndfpokhiekfdajlkpgmdeobhnmnjaeoh;
                                    goto IL_07CB;
                                }
                            }
                            else if (_CHG3 != _bc1.ForStatementScope)
                            {
                                if (_CHG3 != _bc1.EmbeddedStatementScope)
                                {
                                    goto IL_0794;
                                }
                                _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl3 = new _bn2(node);
                                pfmepljdkgnppejbglhfbhkgndaojcnfjjfl3.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl3;
                                goto IL_07CB;
                            }
                        }
                        else if (_CHG3 <= _bc1.LocalVariableInitializerScope)
                        {
                            if (_CHG3 != _bc1.UsingStatementScope)
                            {
                                if (_CHG3 != _bc1.LocalVariableInitializerScope)
                                {
                                    goto IL_0794;
                                }
                                _bk1 mdaepkfbdjnhibpdacpfaaleochkoccedffc2 = new _bk1(node);
                                mdaepkfbdjnhibpdacpfaaleochkoccedffc2.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                node._AJW = mdaepkfbdjnhibpdacpfaaleochkoccedffc2;
                                goto IL_07CB;
                            }
                        }
                        else
                        {
                            if (_CHG3 == _bc1.SpecificCatchScope)
                            {
                                _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl4 = new _bn2(node);
                                pfmepljdkgnppejbglhfbhkgndaojcnfjjfl4.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl4;
                                goto IL_07CB;
                            }
                            if (_CHG3 == _bc1.ArgumentListScope)
                            {
                                _bk1 mdaepkfbdjnhibpdacpfaaleochkoccedffc3 = new _bk1(node);
                                mdaepkfbdjnhibpdacpfaaleochkoccedffc3.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                node._AJW = mdaepkfbdjnhibpdacpfaaleochkoccedffc3;
                                goto IL_07CB;
                            }
                            if (_CHG3 != _bc1.AttributeArgumentsScope)
                            {
                                goto IL_0794;
                            }
                            _be9 hjlbhcahfcdppomkbkckncgacloaejjofdic = new _be9(node);
                            hjlbhcahfcdppomkbkckncgacloaejjofdic.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            node._AJW = hjlbhcahfcdppomkbkckncgacloaejjofdic;
                            goto IL_07CB;
                        }
                        _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl5 = new _bn2(node);
                        pfmepljdkgnppejbglhfbhkgndaojcnfjjfl5.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                        node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl5;
                        goto IL_07CB;
                    }
                    if (_CHG3 <= _bc1.AttributesScope)
                    {
                        if (_CHG3 <= _bc1.TypeDeclarationScope)
                        {
                            if (_CHG3 == _bc1.MemberInitializerScope)
                            {
                                _bb9 coingoplbpbknfilcibhidegpgfgggnnjnfj = new _bb9(node);
                                coingoplbpbknfilcibhidegpgfgggnnjnfj.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                node._AJW = coingoplbpbknfilcibhidegpgfgggnnjnfj;
                                goto IL_07CB;
                            }
                            if (_CHG3 != _bc1.TypeDeclarationScope)
                            {
                                goto IL_0794;
                            }
                            FKI _AFF = _bm2.GetNodeDeclaration(node, null);
                            _bn4 _AQH3 = new _bn4(node);
                            _AQH3.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            _AQH3.EFI = _AFF;
                            node._AJW = _AQH3;
                            goto IL_07CB;
                        }
                        else
                        {
                            if (_CHG3 == _bc1.MethodDeclarationScope)
                            {
                                FKI _AFF = _bm2.GetNodeDeclaration(node, null);
                                _bn4 _AQH4 = new _bn4(node);
                                _AQH4.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                                _AQH4.EFI = _AFF;
                                node._AJW = _AQH4;
                                goto IL_07CB;
                            }
                            if (_CHG3 != _bc1.AttributesScope)
                            {
                                goto IL_0794;
                            }
                            _bk7 mmmbkhlgiodfapfchcagjonjnjemfmlobaef = new _bk7(node);
                            mmmbkhlgiodfapfchcagjonjnjemfmlobaef.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            node._AJW = mmmbkhlgiodfapfchcagjonjnjemfmlobaef;
                            goto IL_07CB;
                        }
                    }
                    else if (_CHG3 <= _bc1.AccessorsListScope)
                    {
                        FKI _AFF;
                        if (_CHG3 == _bc1.AccessorBodyScope)
                        {
                            _AFF = _bm2.GetNodeDeclaration(node.OOME, null);
                            _b9 akhihgmonaolkkadmcchmjnoebakffohidce = new _b9(node);
                            akhihgmonaolkkadmcchmjnoebakffohidce.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                            akhihgmonaolkkadmcchmjnoebakffohidce._ACV = ((_AFF != null) ? _AFF._ACV : null);
                            node._AJW = akhihgmonaolkkadmcchmjnoebakffohidce;
                            goto IL_07CB;
                        }
                        if (_CHG3 != _bc1.AccessorsListScope)
                        {
                            goto IL_0794;
                        }
                        _AFF = _bm2.GetNodeDeclaration(node, null);
                        _bn4 _AQH5 = new _bn4(node);
                        _AQH5.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                        _AQH5.EFI = _AFF;
                        node._AJW = _AQH5;
                        goto IL_07CB;
                    }
                    else if (_CHG3 != _bc1.QueryExpressionScope && _CHG3 != _bc1.QueryBodyScope)
                    {
                        if (_CHG3 != _bc1.MemberDeclarationScope)
                        {
                            goto IL_0794;
                        }
                        _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl6 = new _bn2(node);
                        pfmepljdkgnppejbglhfbhkgndaojcnfjjfl6.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                        node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl6;
                        goto IL_07CB;
                    }
                IL_057C:
                    _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl7 = new _bn2(node);
                    pfmepljdkgnppejbglhfbhkgndaojcnfjjfl7.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                    node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl7;
                    goto IL_07CB;
                IL_0794:
                    throw new ArgumentOutOfRangeException("Unhandled case " + _CHG.ToString() + ": in switch statement!\nsemantics: " + node._AJO().ToString());
                IL_07CB:
                    bool flag7 = node._AJW == null;
                    if (flag7)
                    {
                        _bn2 pfmepljdkgnppejbglhfbhkgndaojcnfjjfl8 = new _bn2(node);
                        pfmepljdkgnppejbglhfbhkgndaojcnfjjfl8.GJOKNNJPNCHGBGCLIMHKIOHPIFBKHGDNIJLO(nodeScope);
                        node._AJW = pfmepljdkgnppejbglhfbhkgndaojcnfjjfl8;
                    }
                }
                _AQI = node._AJW;
            }
            return _AQI;
        }

        // Token: 0x06000718 RID: 1816 RVA: 0x000F3D58 File Offset: 0x000F1F58
        private static FKI GetNodeDeclaration(_bb4._ACW node, string fileName = null)
        {
            bool flag = node.EFI == null;
            if (flag)
            {
                _bc1 _CHG = node._AJO() & _bc1.SymbolDeclarationsMask;
                _bb4._ACW _AGZ = _bm2.EnclosingSemanticNode(node.OOME, _bc1.ScopesMask);
                _bm6 _AQI = _bm2.GetNodeScope(_AGZ, fileName);
                bool flag2 = _AQI == null;
                if (flag2)
                {
                    return null;
                }
                _bb4._AIN _AIO = null;
                _bb4._AIN _AIO2 = null;
                _bb4._ACW _AGZ2 = null;
                _bb4._AIN _AIO3 = null;
                _bb4._ACW _AGZ3 = null;
                switch (_CHG)
                {
                    case _bc1.None:
                        Debug.LogWarning("declarationSemantics is None on " + ((node != null) ? node.ToString() : null));
                        goto IL_0996;
                    case _bc1.NamespaceDeclaration:
                        node.EFI = new _bf8
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Namespace
                        };
                        goto IL_0996;
                    case _bc1.UsingNamespace:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.ImportedNamespace
                        };
                        goto IL_0996;
                    case _bc1.UsingAlias:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.TypeAlias
                        };
                        goto IL_0996;
                    case _bc1.UsingStatic:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.ImportedStaticType
                        };
                        goto IL_0996;
                    case _bc1.ExternAlias:
                        goto IL_0996;
                    case _bc1.ClassDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        _AIO3 = node.OOME.FindChildByName("PARTIAL");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Class
                        };
                        _AGZ3 = node.FindChildByName("typeParameterList") as _bb4._ACW;
                        goto IL_0996;
                    case _bc1.TypeParameterDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.TypeParameter
                        };
                        return node.EFI;
                    case _bc1.BaseListDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.BaseTypesList
                        };
                        goto IL_0996;
                    case _bc1.ConstructorDeclarator:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Constructor
                        };
                        goto IL_0996;
                    case _bc1.DestructorDeclarator:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Destructor
                        };
                        goto IL_0996;
                    case _bc1.ConstantDeclarator:
                        _AIO = node.OOME.OOME.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = ((node.OOME.OOME._AHB() == "constantDeclaration") ? SymbolKind.ConstantField : SymbolKind.LocalConstant)
                        };
                        goto IL_0996;
                    case _bc1.MethodDeclarator:
                        {
                            _AIO = node.OOME.FindChildByName("modifiers");
                            bool flag3 = !_bd5._AHR;
                            if (flag3)
                            {
                                _AIO2 = node.OOME.FindChildByName("ASYNC");
                                bool flag4 = _AIO2 != null && _AIO != null;
                                if (flag4)
                                {
                                    _AGZ2 = _AIO2._AIZ as _bb4._ACW;
                                    bool flag5 = _AGZ2 != null && _AGZ2._AHB() != "modifiers";
                                    if (flag5)
                                    {
                                        _AGZ2 = null;
                                    }
                                }
                            }
                            _AIO3 = node.OOME.FindChildByName("PARTIAL");
                            _AGZ3 = node.NodeAt(0);
                            bool flag6 = _AGZ3 != null;
                            if (flag6)
                            {
                                _AGZ3 = _AGZ3.NodeAt(0);
                            }
                            bool flag7 = _AGZ3 != null;
                            if (flag7)
                            {
                                _AGZ3 = _AGZ3.NodeAt(0);
                            }
                            bool flag8 = _AGZ3 != null;
                            if (flag8)
                            {
                                _AGZ3 = _AGZ3.NodeAt(-1);
                            }
                            bool flag9 = _AGZ3 != null;
                            if (flag9)
                            {
                                _AGZ3 = _AGZ3.FindChildByName("typeParameterList") as _bb4._ACW;
                            }
                            node.EFI = new FKI
                            {
                                _AEJ = node,
                                _AT = SymbolKind.Method
                            };
                            goto IL_0996;
                        }
                    case _bc1.LocalVariableDeclarator:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Variable
                        };
                        goto IL_0996;
                    case _bc1.OutVariableDeclarator:
                        _AGZ = null;
                        _AQI = _AQI._AMJ();
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.OutVariable
                        };
                        goto IL_0996;
                    case _bc1.ForEachVariableDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.ForEachVariable
                        };
                        goto IL_0996;
                    case _bc1.FromClauseVariableDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.FromClauseVariable
                        };
                        goto IL_0996;
                    case _bc1.CaseVariableDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.CaseVariable
                        };
                        goto IL_0996;
                    case _bc1.LabeledStatement:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Label
                        };
                        goto IL_0996;
                    case _bc1.CatchExceptionParameterDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.CatchParameter
                        };
                        goto IL_0996;
                    case _bc1.FixedParameterDeclaration:
                        _AIO = node.FindChildByName("parameterModifier");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Parameter
                        };
                        goto IL_0996;
                    case _bc1.ParameterArrayDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Parameter,
                            _AV = Modifiers.Params
                        };
                        goto IL_0996;
                    case _bc1.ImplicitParameterDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Parameter
                        };
                        goto IL_0996;
                    case _bc1.ExplicitParameterDeclaration:
                        _AIO = node.FindChildByName("anonymousFunctionParameterModifier");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Parameter
                        };
                        goto IL_0996;
                    case _bc1.PropertyDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Property
                        };
                        goto IL_0996;
                    case _bc1.IndexerDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Indexer
                        };
                        goto IL_0996;
                    case _bc1.GetAccessorDeclaration:
                    case _bc1.SetAccessorDeclaration:
                        _AIO = node.OOME.FindChildByName("accessorModifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Accessor
                        };
                        goto IL_0996;
                    case _bc1.EventDeclarator:
                        _AIO = node.OOME.OOME.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Event
                        };
                        goto IL_0996;
                    case _bc1.EventWithAccessorsDeclaration:
                        _AIO = node.OOME.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Event
                        };
                        goto IL_0996;
                    case _bc1.AddAccessorDeclaration:
                    case _bc1.RemoveAccessorDeclaration:
                    case _bc1.InterfaceGetAccessorDeclaration:
                    case _bc1.InterfaceSetAccessorDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Accessor
                        };
                        goto IL_0996;
                    case _bc1.VariableDeclarator:
                        _AIO = node.OOME.OOME.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Field
                        };
                        goto IL_0996;
                    case _bc1.OperatorDeclarator:
                    case _bc1.ConversionOperatorDeclarator:
                        _AIO = node.OOME.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Operator
                        };
                        goto IL_0996;
                    case _bc1.StructDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        _AIO3 = node.OOME.FindChildByName("PARTIAL");
                        _AGZ3 = node.FindChildByName("typeParameterList") as _bb4._ACW;
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Struct
                        };
                        goto IL_0996;
                    case _bc1.InterfaceDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        _AIO3 = node.OOME.FindChildByName("PARTIAL");
                        _AGZ3 = node.FindChildByName("typeParameterList") as _bb4._ACW;
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Interface
                        };
                        goto IL_0996;
                    case _bc1.InterfacePropertyDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Property
                        };
                        goto IL_0996;
                    case _bc1.InterfaceMethodDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Method
                        };
                        goto IL_0996;
                    case _bc1.InterfaceEventDeclaration:
                        goto IL_0996;
                    case _bc1.InterfaceIndexerDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Property
                        };
                        goto IL_0996;
                    case _bc1.EnumDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Enum
                        };
                        goto IL_0996;
                    case _bc1.EnumMemberDeclaration:
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.EnumMember,
                            _AV = (Modifiers.Public | Modifiers.Static | Modifiers.ReadOnly)
                        };
                        goto IL_0996;
                    case _bc1.DelegateDeclaration:
                        _AIO = node.OOME.FindChildByName("modifiers");
                        _AGZ3 = node.FindChildByName("typeParameterList") as _bb4._ACW;
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.Delegate
                        };
                        goto IL_0996;
                    case _bc1.AnonymousObjectCreation:
                        goto IL_0996;
                    case _bc1.MemberDeclarator:
                        goto IL_0996;
                    case _bc1.LambdaExpressionDeclaration:
                    case _bc1.AnonymousMethodDeclaration:
                        _AGZ = _bm2.EnclosingScopeNode(node.OOME, _bc1.CodeBlockScope, _bc1.MethodBodyScope, _bc1.TypeDeclarationScope);
                        _AQI = _bm2.GetNodeScope(_AGZ, fileName);
                        node.EFI = new FKI
                        {
                            _AEJ = node,
                            _AT = SymbolKind.LambdaExpression
                        };
                        goto IL_0996;
                }
                throw new ArgumentOutOfRangeException("Unhandled case " + _CHG.ToString() + " for node " + ((node != null) ? node.ToString() : null));
            IL_0996:
                bool flag10 = node.EFI != null;
                if (flag10)
                {
                    bool flag11 = _AIO != null;
                    if (flag11)
                    {
                        node.EFI._AV = _bm2.ParseModifiers(_AIO);
                    }
                    bool flag12 = _AIO3 != null;
                    if (flag12)
                    {
                        node.EFI._AV |= Modifiers.Partial;
                    }
                    bool flag13 = _AIO2 != null;
                    if (flag13)
                    {
                        node.EFI._AV |= Modifiers.Async;
                        bool flag14 = _AGZ2 != null;
                        if (flag14)
                        {
                            node.EFI._AV |= _bm2.ParseModifiers(_AGZ2);
                        }
                    }
                    bool flag15 = _AGZ3 != null;
                    if (flag15)
                    {
                        node.EFI._AQN = _bm2.CountTypeParameters(_AGZ3);
                    }
                    bool flag16 = _AQI == null;
                    if (flag16)
                    {
                        Debug.LogWarning(string.Concat(new string[]
                        {
                            "Symbol declaration ",
                            _CHG.ToString(),
                            " outside of declaration space!\nenclosingScopeNode: ",
                            (_AGZ != null) ? _AGZ._AHB() : "null",
                            "\nnode: ",
                            (node != null) ? node.ToString() : null
                        }));
                    }
                    else
                    {
                        bool eemmpgfnocikdepiendbnnmfcfaenpfcpdng = KJK.EEMMPGFNOCIKDEPIENDBNNMFCFAENPFCPDNG;
                        KJK.EEMMPGFNOCIKDEPIENDBNNMFCFAENPFCPDNG = true;
                        try
                        {
                            _bh4 _AAH = _AQI.AddDeclaration(node.EFI);
                            bool flag17 = _AAH != null && _AGZ3 != null;
                            if (flag17)
                            {
                                _AGZ = _bm2.EnclosingSemanticNode(_AGZ3.OOME, _bc1.ScopesMask);
                                _AQI = _bm2.GetNodeScope(_AGZ, fileName);
                                for (int i = 2; i < (int)_AGZ3._AIX; i += 3)
                                {
                                    _bb4._ACW _AGZ4 = _AGZ3.NodeAt(i);
                                    bool flag18 = _AGZ4 == null;
                                    if (!flag18)
                                    {
                                        FKI nodeDeclaration = _bm2.GetNodeDeclaration(_AGZ4, fileName);
                                        bool flag19 = nodeDeclaration != null;
                                        if (flag19)
                                        {
                                            nodeDeclaration._AJW = _AQI;
                                            _AAH.AddDeclaration(nodeDeclaration);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.LogException(ex);
                        }
                        finally
                        {
                            KJK.EEMMPGFNOCIKDEPIENDBNNMFCFAENPFCPDNG = eemmpgfnocikdepiendbnnmfcfaenpfcpdng;
                        }
                        _bb4._AIU += 1U;
                        bool flag20 = _bb4._AIU == 0U;
                        if (flag20)
                        {
                            _bb4._AIU += 1U;
                        }
                    }
                }
            }
            return node.EFI;
        }

        // Token: 0x06000719 RID: 1817 RVA: 0x000F4938 File Offset: 0x000F2B38
        private static int CountTypeParameters(_bb4._ACW typeParamsNode)
        {
            int num = ((typeParamsNode._AIX > 0) ? 1 : 0);
            for (int i = 1; i < (int)typeParamsNode._AIX; i++)
            {
                bool flag = typeParamsNode.ChildAt(i).IsLit(",");
                if (flag)
                {
                    num++;
                }
            }
            return num;
        }

        // Token: 0x0600071A RID: 1818 RVA: 0x000F498C File Offset: 0x000F2B8C
        private static Modifiers ParseModifiers(_bb4._AIN node)
        {
            _bb4._ACW _AGZ = node as _bb4._ACW;
            bool flag = _AGZ == null || _AGZ._AIX == 0;
            Modifiers modifiers;
            if (flag)
            {
                modifiers = Modifiers.None;
            }
            else
            {
                Modifiers modifiers2 = Modifiers.None;
                for (int i = 0; i < (int)_AGZ._AIX; i++)
                {
                    _bb4.DHBA _AEM = _AGZ.LeafAt(i);
                    bool flag2 = _AEM == null;
                    if (!flag2)
                    {
                        string text = _AEM._ACX.text;
                        string text2 = text;
                        uint num = Helper.ComputeStringHash(text2);
                        if (num <= 2497774445U)
                        {
                            if (num <= 1123320834U)
                            {
                                if (num <= 681154065U)
                                {
                                    if (num != 508850813U)
                                    {
                                        if (num != 681154065U)
                                        {
                                            goto IL_0419;
                                        }
                                        if (!(text2 == "new"))
                                        {
                                            goto IL_0419;
                                        }
                                        modifiers2 |= Modifiers.New;
                                    }
                                    else
                                    {
                                        if (!(text2 == "protected"))
                                        {
                                            goto IL_0419;
                                        }
                                        modifiers2 |= Modifiers.Protected;
                                    }
                                }
                                else if (num != 1094220446U)
                                {
                                    if (num != 1123320834U)
                                    {
                                        goto IL_0419;
                                    }
                                    if (!(text2 == "ref"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Ref;
                                }
                                else
                                {
                                    if (!(text2 == "in"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.In;
                                }
                            }
                            else if (num <= 1657474316U)
                            {
                                if (num != 1570143932U)
                                {
                                    if (num != 1657474316U)
                                    {
                                        goto IL_0419;
                                    }
                                    if (!(text2 == "private"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Private;
                                }
                                else
                                {
                                    if (!(text2 == "virtual"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Virtual;
                                }
                            }
                            else if (num != 2325638003U)
                            {
                                if (num != 2424823223U)
                                {
                                    if (num != 2497774445U)
                                    {
                                        goto IL_0419;
                                    }
                                    if (!(text2 == "volatile"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Volatile;
                                }
                                else
                                {
                                    if (!(text2 == "extern"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Extern;
                                }
                            }
                            else
                            {
                                if (!(text2 == "abstract"))
                                {
                                    goto IL_0419;
                                }
                                modifiers2 |= Modifiers.Abstract;
                            }
                        }
                        else if (num <= 3310188186U)
                        {
                            if (num <= 2717370895U)
                            {
                                if (num != 2591649024U)
                                {
                                    if (num != 2717370895U)
                                    {
                                        goto IL_0419;
                                    }
                                    if (!(text2 == "async"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Async;
                                }
                                else
                                {
                                    if (!(text2 == "internal"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Internal;
                                }
                            }
                            else if (num != 2870621791U)
                            {
                                if (num != 3300482109U)
                                {
                                    if (num != 3310188186U)
                                    {
                                        goto IL_0419;
                                    }
                                    if (!(text2 == "partial"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Partial;
                                }
                                else
                                {
                                    if (!(text2 == "override"))
                                    {
                                        goto IL_0419;
                                    }
                                    modifiers2 |= Modifiers.Override;
                                }
                            }
                            else
                            {
                                if (!(text2 == "out"))
                                {
                                    goto IL_0419;
                                }
                                modifiers2 |= Modifiers.Out;
                            }
                        }
                        else if (num <= 3432027008U)
                        {
                            if (num != 3386378657U)
                            {
                                if (num != 3432027008U)
                                {
                                    goto IL_0419;
                                }
                                if (!(text2 == "public"))
                                {
                                    goto IL_0419;
                                }
                                modifiers2 |= Modifiers.Public;
                            }
                            else
                            {
                                if (!(text2 == "sealed"))
                                {
                                    goto IL_0419;
                                }
                                modifiers2 |= Modifiers.Sealed;
                            }
                        }
                        else if (num != 3456888823U)
                        {
                            if (num != 3532702267U)
                            {
                                if (num != 3660305025U)
                                {
                                    goto IL_0419;
                                }
                                if (!(text2 == "this"))
                                {
                                    goto IL_0419;
                                }
                                modifiers2 |= Modifiers.This;
                            }
                            else
                            {
                                if (!(text2 == "static"))
                                {
                                    goto IL_0419;
                                }
                                modifiers2 |= Modifiers.Static;
                            }
                        }
                        else
                        {
                            if (!(text2 == "readonly"))
                            {
                                goto IL_0419;
                            }
                            modifiers2 |= Modifiers.ReadOnly;
                        }
                        goto IL_041E;
                    IL_0419:
                        return modifiers2;
                    }
                IL_041E:;
                }
                modifiers = modifiers2;
            }
            return modifiers;
        }

        // Token: 0x0600071B RID: 1819 RVA: 0x000F4DD8 File Offset: 0x000F2FD8
        internal void OnReduceSemanticNode(_bb4._ACW node, string fileName = null)
        {
            bool flag = node._AIX == 0;
            if (!flag)
            {
                _bc1 _CHG = node._AJO();
                _bc1 _CHG2 = _CHG & _bc1.SymbolDeclarationsMask;
                bool flag2 = _CHG2 == _bc1.None;
                if (flag2)
                {
                    _bm2.GetNodeScope(node, fileName);
                }
                else
                {
                    bool flag3 = node._AHB() != "typeParameter";
                    if (flag3)
                    {
                        _bm2.GetNodeDeclaration(node, fileName);
                        bool flag4 = (node._AJO() & _bc1.ScopesMask) > _bc1.None;
                        if (flag4)
                        {
                            _bm2.GetNodeScope(node, fileName);
                        }
                    }
                }
            }
        }

        // Token: 0x0600071C RID: 1820 RVA: 0x000F4E58 File Offset: 0x000F3058
        private bool IsAwaitInsideAsyncMethod(_bh2._AJH s)
        {
            bool _AHQ = _bd5._AHR;
            bool flag;
            if (_AHQ)
            {
                flag = false;
            }
            else
            {
                bool flag2 = s.Current.text != "await";
                if (flag2)
                {
                    flag = false;
                }
                else
                {
                    _bb4._ACW _AGZ = s._AJT.FindParentByName("methodDeclaration");
                    bool flag3 = _AGZ == null;
                    if (flag3)
                    {
                        flag = false;
                    }
                    else
                    {
                        bool flag4 = _AGZ.EFI == null;
                        if (flag4)
                        {
                            flag = _AGZ.OOME.FindChildByName("ASYNC") != null;
                        }
                        else
                        {
                            flag = _AGZ.EFI._AQM();
                        }
                    }
                }
            }
            return flag;
        }

        // Token: 0x0400061F RID: 1567
        private static _bm2 _AA;

        // Token: 0x04000620 RID: 1568
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CompilerGenerated]
        private _bh2._AJQ FKDBLAPJOHEFCNDHHCEKGOABJGBCPIFCAHII;

        // Token: 0x04000621 RID: 1569
        private _bh2._BCX _ASF;

        // Token: 0x04000622 RID: 1570
        private readonly _bh2._AEN _BDD;

        // Token: 0x04000623 RID: 1571
        private readonly _bh2._AEN JCLFNNCMKINNNHLOFIHGGPGPLHKGBHNELHPJ;

        // Token: 0x04000624 RID: 1572
        private readonly _bh2._AEN EMENFMGGHFEHGJGCBCDNGKDPPLEDPMBDGMND;

        // Token: 0x04000625 RID: 1573
        private readonly _bh2._AEN PJLPDGACCJPCAGGNGOIMGGJLDDNFDCPMAMAP;

        // Token: 0x04000626 RID: 1574
        private readonly _bh2._AEN PADBMJLLGAAIPKILFLHMJIFHNCEBBGFKHLJJ;

        // Token: 0x04000627 RID: 1575
        private readonly _bh2._AEN NEOEKODKBFIFEHEMCOBJCNDDGIGIBIALFBBB;

        // Token: 0x04000628 RID: 1576
        private readonly _bh2._AEN GPPFFDKKGDPEJFMLIIPIIFCOPNNLMFPHKMEK;

        // Token: 0x04000629 RID: 1577
        private readonly _bh2._AEN MBOCPMDAGPNEBBALHCJIKENPKHCHOMMEMDBG;

        // Token: 0x0400062A RID: 1578
        private readonly _bh2._AEN FPKACCPNCJADKMOLADGCFAPFGMMJPEOPKKGD;

        // Token: 0x0400062B RID: 1579
        public int _CBN;

        // Token: 0x0400062C RID: 1580
        public int _CBG;

        // Token: 0x0400062D RID: 1581
        public int _CBK;

        // Token: 0x0400062E RID: 1582
        public int MEHGHAJAPILANIBMGENBFHNIAEELJDEHHCGB;

        // Token: 0x0400062F RID: 1583
        public int IJMAALOAAPKFFKBPLJAEDLOOEMEKPLGGFIOJ;

        // Token: 0x04000630 RID: 1584
        public int CKCBAOEDNFKIMKMDIPBBFBNCAFEBBHFNFKBI;

        // Token: 0x04000631 RID: 1585
        public int PNAHIEKBKBGIJCGNLCGDEAEHMHEKCEFMDFEE;

        // Token: 0x04000632 RID: 1586
        public int MEGFEAMOJEOFOGJCMBEJBJJBIBOODCBNANGO;

        // Token: 0x04000633 RID: 1587
        public int NCHAGCLBBEFNHPICIAMMOMHPCBOOPBMOEGDB;

        // Token: 0x04000634 RID: 1588
        public int _AGP;

        // Token: 0x04000635 RID: 1589
        public int _AGO;

        // Token: 0x04000636 RID: 1590
        public int _AGQ;

        // Token: 0x04000637 RID: 1591
        public int _AGR;

        // Token: 0x04000638 RID: 1592
        public int _AGN;

        // Token: 0x04000639 RID: 1593
        public int AHHEGIICLMMGAMIIBCOALJAANLNIDBOHPBGH;

        // Token: 0x0400063A RID: 1594
        public int _CBI;

        // Token: 0x0400063B RID: 1595
        public int _CBP;

        // Token: 0x0400063C RID: 1596
        public int BNNEMMKGMCLMLANHKADMEEJIOFEGNPDHGMOH;

        // Token: 0x0400063D RID: 1597
        public int _CBJ;

        // Token: 0x020000FB RID: 251
        internal class _AJS : _bh2._AJH
        {
            // Token: 0x0600071D RID: 1821 RVA: 0x000F4EE4 File Offset: 0x000F30E4
            internal static _bm2._AJS New(_bm2 grammar, GCE.PHFG[] formatedLines, string fileName)
            {
                bool flag = _bm2._AJS.OLMFPGNAECCIJJEJCJKBDLFFEANAPGJHFCNI.Count == 0;
                _bm2._AJS _AQP;
                if (flag)
                {
                    _AQP = new _bm2._AJS(grammar, formatedLines, fileName);
                }
                else
                {
                    _bm2._AJS _AQP2 = _bm2._AJS.OLMFPGNAECCIJJEJCJKBDLFFEANAPGJHFCNI.Pop();
                    _AQP2.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC = grammar;
                    _AQP2.FLOg = formatedLines;
                    _AQP2._BDK = fileName;
                    _AQP = _AQP2;
                }
                return _AQP;
            }

            // Token: 0x0600071E RID: 1822 RVA: 0x000F4F34 File Offset: 0x000F3134
            public override void Delete()
            {
                this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC = null;
                this.FLOg = null;
                this.EOIA = null;
                this._BDE = -1;
                this._BDC = -1;
                this._BDL = null;
                this._AJT = null;
                this._BDM = null;
                this._BDN = null;
                this._BDO = null;
                this._BDP = null;
                this._BDQ = false;
                this._BDB = null;
                _bm2._AJS.OLMFPGNAECCIJJEJCJKBDLFFEANAPGJHFCNI.Push(this);
            }

            // Token: 0x0600071F RID: 1823 RVA: 0x000F4FAC File Offset: 0x000F31AC
            protected _AJS(_bm2 grammar, GCE.PHFG[] formatedLines, string fileName)
            {
                this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC = grammar;
                this._BDK = fileName;
                this.FLOg = formatedLines;
                bool flag = _bh2._AJH._BDD == null;
                if (flag)
                {
                    _bh2._AJH._BDD = new SyntaxToken(SyntaxToken.Kind.EOF, string.Empty)
                    {
                        tokenId = grammar._CBJ
                    };
                }
            }

            // Token: 0x06000720 RID: 1824 RVA: 0x000F5000 File Offset: 0x000F3200
            public override _bh2._AJH Clone()
            {
                _bm2._AJS _AQP = _bm2._AJS.New(this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC, this.FLOg, this._BDK);
                _AQP.EOIA = this.EOIA;
                _AQP._BDE = this._BDE;
                _AQP._BDC = this._BDC;
                _AQP._BDB = this._BDB;
                _AQP._BDL = this._BDL;
                _AQP._AJT = this._AJT;
                _AQP._BDM = this._BDM;
                _AQP._BDN = this._BDN;
                _AQP._BDO = this._BDO;
                _AQP._BDP = this._BDP;
                return _AQP;
            }

            // Token: 0x06000721 RID: 1825 RVA: 0x000F50A3 File Offset: 0x000F32A3
            public override void OnReduceSemanticNode(_bb4._ACW node)
            {
                this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.OnReduceSemanticNode(node, this._BDK);
            }

            // Token: 0x06000722 RID: 1826 RVA: 0x000F50BC File Offset: 0x000F32BC
            public override void SyntaxErrorExpected(_bh2._AGI lookahead)
            {
                bool flag = this._BDN != null;
                if (!flag)
                {
                    this._BDN = new _bh2._BCZ(this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.GetParser, lookahead);
                    bool flag2 = this._AJT != null && this._AJT._AJB == null;
                    if (flag2)
                    {
                        this._AJT._AJB = this._BDN;
                    }
                }
            }

            // Token: 0x06000723 RID: 1827 RVA: 0x000F5120 File Offset: 0x000F3320
            public override void CollectCompletions(_bh2._AGI tokenSet)
            {
                (this._BDL ?? _bm2._AA.IODAGDLMLMILBHGAJCCLNFIJIDLOIBMOEFPC()).CollectCompletions(tokenSet, this, this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC._CBN);
                bool flag = this._BDL != null && tokenSet.Matches(_bm2._AGM()._CBN);
                if (flag)
                {
                    this._BDB = new SyntaxToken(SyntaxToken.Kind.Identifier, "special");
                    this._BDB.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC._CBN;
                    base.Lookahead(this._BDL, 1);
                    this._BDB = null;
                }
            }

            // Token: 0x06000724 RID: 1828 RVA: 0x000F51B8 File Offset: 0x000F33B8
            public override void InsertMissingToken(_bh2._AJE errorMessage)
            {
                int num = this._BDE;
                int num2 = this._BDC;
                for (; ; )
                {
                    bool flag = --num2 < 0;
                    if (flag)
                    {
                        bool flag2 = --num < 0;
                        if (flag2)
                        {
                            break;
                        }
                        num2 = this.FLOg[num].EOIA.Count;
                    }
                    else
                    {
                        SyntaxToken.Kind tokenKind = this.FLOg[num].EOIA[num2].tokenKind;
                        bool flag3 = tokenKind > SyntaxToken.Kind.LastWSToken;
                        if (flag3)
                        {
                            goto Block_3;
                        }
                        bool flag4 = tokenKind == SyntaxToken.Kind.Missing;
                        if (flag4)
                        {
                            goto Block_4;
                        }
                    }
                }
                num2 = (num = 0);
                goto IL_00B3;
            Block_3:
                num2++;
                goto IL_00B3;
            Block_4:
                this._BDM = this.FLOg[num].EOIA[num2].OOME;
                return;
            IL_00B3:
                GCE.PHFG _AUB = this.FLOg[num];
                SyntaxToken syntaxToken = new SyntaxToken(SyntaxToken.Kind.Missing, string.Empty)
                {
                    style = null,
                    AIGN = _AUB
                };
                _AUB.EOIA.Insert(num2, syntaxToken);
                _bb4.DHBA _AEM = this._BDP.AddToken(syntaxToken);
                _AEM._AJC = true;
                _AEM._AJB = errorMessage;
                _AEM._AJD = this._BDO;
                bool flag5 = this._BDM == null;
                if (flag5)
                {
                    this._BDM = _AEM;
                }
                bool flag6 = num == this._BDE;
                if (flag6)
                {
                    this._BDC++;
                }
            }

            // Token: 0x06000725 RID: 1829 RVA: 0x000F5308 File Offset: 0x000F3508
            internal void MoveToLine(int line, _bb4 parseTree)
            {
                for (int i = line - 1; i >= 0; i--)
                {
                    this.EOIA = this.FLOg[i].EOIA;
                    for (int j = this.EOIA.Count - 1; j >= 0; j--)
                    {
                        SyntaxToken syntaxToken = this.EOIA[j];
                        _bb4.DHBA _AMI = syntaxToken.OOME;
                        bool flag = syntaxToken.tokenKind == SyntaxToken.Kind.Missing;
                        if (flag)
                        {
                            bool flag2 = syntaxToken.OOME != null && syntaxToken.OOME.OOME != null;
                            if (flag2)
                            {
                                syntaxToken.OOME.OOME._AJB = null;
                            }
                            this.EOIA.RemoveAt(j);
                        }
                        else
                        {
                            bool flag3 = _AMI == null || _AMI._AJD == null;
                            if (!flag3)
                            {
                                bool flag4 = syntaxToken.tokenKind < SyntaxToken.Kind.LastWSToken;
                                if (!flag4)
                                {
                                    bool flag5 = _AMI._AJB != null;
                                    if (!flag5)
                                    {
                                        this.MoveAfterLeaf(_AMI);
                                        return;
                                    }
                                    this._BDM = _AMI;
                                    this._BDN = _AMI._AJB;
                                }
                            }
                        }
                    }
                }
                this.EOIA = null;
                this._BDE = -1;
                this._BDC = -1;
                this._AJT = null;
                this._BDL = null;
                this._BDM = null;
                this._BDN = null;
                this._BDP = null;
                this._BDO = null;
                this.MoveNext();
                _bh2._AJQ _BEB = _bm2._AGM().IODAGDLMLMILBHGAJCCLNFIJIDLOIBMOEFPC();
                this._AJT = parseTree._AIT;
                this._BDL = _BEB;
                this._BDP = this._AJT;
                this._BDO = this._BDL;
            }

            // Token: 0x06000726 RID: 1830 RVA: 0x000F54B4 File Offset: 0x000F36B4
            internal bool MoveAfterLeaf(_bb4.DHBA leaf)
            {
                bool flag = leaf == null || leaf._AJD == null;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    bool flag3 = leaf._AJB != null;
                    if (flag3)
                    {
                        string text = "Can't move after error node! ";
                        _bh2._AJE galfeenijiemihmlgeghkmafeckpklcdmcmf = leaf._AJB;
                        Debug.LogError(text + ((galfeenijiemihmlgeghkmafeckpklcdmcmf != null) ? galfeenijiemihmlgeghkmafeckpklcdmcmf.ToString() : null));
                        flag2 = false;
                    }
                    else
                    {
                        _bb4._ACW _AMI = leaf.OOME;
                        bool flag4 = _AMI == null;
                        if (flag4)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            this._AJT = null;
                            this._BDL = null;
                            this._BDM = null;
                            this._BDN = null;
                            this._BDP = null;
                            this._BDO = null;
                            SyntaxToken _BDJ = leaf._ACX;
                            this._BDE = ((_BDJ != null) ? _BDJ.AIGN.JIKB : 0);
                            this.EOIA = this.FLOg[this._BDE].EOIA;
                            this._BDC = leaf._AJG();
                            this.MoveNext();
                            this._AJT = leaf.OOME;
                            this._BDN = null;
                            this._BDQ = true;
                            this._BDO = (this._BDL = leaf._AJD.OOME.NextAfterChild(leaf._AJD, this));
                            this._BDQ = false;
                            this._BDP = this._AJT;
                            flag2 = true;
                        }
                    }
                }
                return flag2;
            }

            // Token: 0x06000727 RID: 1831 RVA: 0x000F55FC File Offset: 0x000F37FC
            public override bool MoveNext()
            {
                bool flag = this._BDG > 0;
                if (flag)
                {
                    this._BDG--;
                }
                while (this.MoveNextSingle())
                {
                    bool flag2 = this.EOIA[this._BDC].tokenId == -1;
                    if (flag2)
                    {
                        SyntaxToken syntaxToken = this.EOIA[this._BDC];
                        switch (syntaxToken.tokenKind)
                        {
                            case SyntaxToken.Kind.Missing:
                            case SyntaxToken.Kind.Whitespace:
                            case SyntaxToken.Kind.Comment:
                            case SyntaxToken.Kind.Preprocessor:
                            case SyntaxToken.Kind.PreprocessorArguments:
                            case SyntaxToken.Kind.PreprocessorSymbol:
                            case SyntaxToken.Kind.PreprocessorDirectiveExpected:
                            case SyntaxToken.Kind.PreprocessorCommentExpected:
                            case SyntaxToken.Kind.PreprocessorUnexpectedDirective:
                            case SyntaxToken.Kind.VerbatimStringLiteral:
                            case SyntaxToken.Kind.EOF:
                                break;
                            case SyntaxToken.Kind.LastWSToken:
                                goto IL_017D;
                            case SyntaxToken.Kind.VerbatimStringBegin:
                            case SyntaxToken.Kind.CharLiteral:
                            case SyntaxToken.Kind.StringLiteral:
                            case SyntaxToken.Kind.IntegerLiteral:
                            case SyntaxToken.Kind.RealLiteral:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC._CBK;
                                break;
                            case SyntaxToken.Kind.BuiltInLiteral:
                            case SyntaxToken.Kind.Punctuator:
                            case SyntaxToken.Kind.Keyword:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.TokenToId(syntaxToken.text);
                                break;
                            case SyntaxToken.Kind.InterpolatedStringWholeLiteral:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.MEHGHAJAPILANIBMGENBFHNIAEELJDEHHCGB;
                                break;
                            case SyntaxToken.Kind.InterpolatedStringStartLiteral:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.IJMAALOAAPKFFKBPLJAEDLOOEMEKPLGGFIOJ;
                                break;
                            case SyntaxToken.Kind.InterpolatedStringMidLiteral:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.CKCBAOEDNFKIMKMDIPBBFBNCAFEBBHFNFKBI;
                                break;
                            case SyntaxToken.Kind.InterpolatedStringEndLiteral:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.PNAHIEKBKBGIJCGNLCGDEAEHMHEKCEFMDFEE;
                                break;
                            case SyntaxToken.Kind.InterpolatedStringFormatLiteral:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC.MEGFEAMOJEOFOGJCMBEJBJJBIBOODCBNANGO;
                                break;
                            case SyntaxToken.Kind.Identifier:
                            case SyntaxToken.Kind.ContextualKeyword:
                                syntaxToken.tokenId = this.KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC._CBN;
                                break;
                            default:
                                goto IL_017D;
                        }
                        goto IL_0184;
                    IL_017D:
                        throw new ArgumentOutOfRangeException();
                    }
                IL_0184:
                    bool flag3 = this.EOIA[this._BDC].tokenKind > SyntaxToken.Kind.VerbatimStringLiteral;
                    if (flag3)
                    {
                        return true;
                    }
                }
                this.EOIA = null;
                this._BDE++;
                this._BDC = -1;
                return false;
            }

            // Token: 0x06000728 RID: 1832 RVA: 0x000F57E8 File Offset: 0x000F39E8
            public bool MoveNextSingle()
            {
                while (this.EOIA == null)
                {
                    bool flag = this._BDE + 1 >= this.FLOg.Length;
                    if (flag)
                    {
                        return false;
                    }
                    this._BDC = -1;
                    GCE.PHFG[] _CAB = this.FLOg;
                    int num = this._BDE + 1;
                    this._BDE = num;
                    this.EOIA = _CAB[num].EOIA;
                }
                while (this._BDC + 1 >= this.EOIA.Count)
                {
                    bool flag2 = this._BDE + 1 >= this.FLOg.Length;
                    if (flag2)
                    {
                        this.EOIA = null;
                        return false;
                    }
                    this._BDC = -1;
                    GCE.PHFG[] _CAB2 = this.FLOg;
                    int num = this._BDE + 1;
                    this._BDE = num;
                    this.EOIA = _CAB2[num].EOIA;
                    while (this.EOIA == null)
                    {
                        bool flag3 = this._BDE + 1 >= this.FLOg.Length;
                        if (flag3)
                        {
                            return false;
                        }
                        GCE.PHFG[] _CAB3 = this.FLOg;
                        num = this._BDE + 1;
                        this._BDE = num;
                        this.EOIA = _CAB3[num].EOIA;
                    }
                }
                this._BDC++;
                return true;
            }

            // Token: 0x0400063E RID: 1598
            private static Stack<_bm2._AJS> OLMFPGNAECCIJJEJCJKBDLFFEANAPGJHFCNI = new Stack<_bm2._AJS>();

            // Token: 0x0400063F RID: 1599
            private _bm2 KFDPMMGEANKNCJLNBOLDNJPMJGLOKNBAMOEC;
        }
    }
}
