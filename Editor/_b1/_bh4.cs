using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000D2 RID: 210
    internal class _bh4
    {
        // Token: 0x060005D6 RID: 1494 RVA: 0x000D847C File Offset: 0x000D667C
        public bool ContainsDeclaration(FKI symbol)
        {
            bool flag = this._AEI == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                int count = this._AEI.Count;
                while (count-- > 0)
                {
                    bool flag3 = this._AEI[count] == symbol;
                    if (flag3)
                    {
                        return true;
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x060005D7 RID: 1495 RVA: 0x000D84D4 File Offset: 0x000D66D4
        public static AccessLevel AccessLevelFromModifiers(Modifiers modifiers)
        {
            bool flag = (modifiers & Modifiers.Public) > Modifiers.None;
            AccessLevel accessLevel;
            if (flag)
            {
                accessLevel = AccessLevel.Public;
            }
            else
            {
                bool flag2 = (modifiers & Modifiers.Protected) > Modifiers.None;
                if (flag2)
                {
                    bool flag3 = (modifiers & Modifiers.Internal) > Modifiers.None;
                    if (flag3)
                    {
                        accessLevel = AccessLevel.ProtectedOrInternal;
                    }
                    else
                    {
                        accessLevel = AccessLevel.Protected;
                    }
                }
                else
                {
                    bool flag4 = (modifiers & Modifiers.Internal) > Modifiers.None;
                    if (flag4)
                    {
                        accessLevel = AccessLevel.Internal;
                    }
                    else
                    {
                        bool flag5 = (modifiers & Modifiers.Private) > Modifiers.None;
                        if (flag5)
                        {
                            accessLevel = AccessLevel.Private;
                        }
                        else
                        {
                            accessLevel = AccessLevel.None;
                        }
                    }
                }
            }
            return accessLevel;
        }

        // Token: 0x060005D8 RID: 1496 RVA: 0x000D8534 File Offset: 0x000D6734
        public static string DecodeId(string name)
        {
            bool flag = !string.IsNullOrEmpty(name) && name[0] == '@';
            string text;
            if (flag)
            {
                text = name.Substring(1);
            }
            else
            {
                text = name;
            }
            return text;
        }

        // Token: 0x060005D9 RID: 1497 RVA: 0x000D856C File Offset: 0x000D676C
        public static bool IsOperatorName(string methodName)
        {
            uint num = Helper.ComputeStringHash(methodName);
            if (num <= 2366795836U)
            {
                if (num <= 1258540185U)
                {
                    if (num <= 588015465U)
                    {
                        if (num <= 120689619U)
                        {
                            if (num != 90588446U)
                            {
                                if (num != 120689619U)
                                {
                                    goto IL_06C9;
                                }
                                if (!(methodName == "op_LogicalOr"))
                                {
                                    goto IL_06C9;
                                }
                            }
                            else if (!(methodName == "op_OnesComplement"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (num != 215197780U)
                        {
                            if (num != 441288870U)
                            {
                                if (num != 588015465U)
                                {
                                    goto IL_06C9;
                                }
                                if (!(methodName == "op_DivisionAssignment"))
                                {
                                    goto IL_06C9;
                                }
                            }
                            else if (!(methodName == "op_Assign"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_Implicit"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (num <= 1034931220U)
                    {
                        if (num != 835846267U)
                        {
                            if (num != 906583475U)
                            {
                                if (num != 1034931220U)
                                {
                                    goto IL_06C9;
                                }
                                if (!(methodName == "op_Increment"))
                                {
                                    goto IL_06C9;
                                }
                            }
                            else if (!(methodName == "op_Addition"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_BitwiseAnd"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (num != 1195761148U)
                    {
                        if (num != 1234170120U)
                        {
                            if (num != 1258540185U)
                            {
                                goto IL_06C9;
                            }
                            if (!(methodName == "op_LessThan"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_LessThanOrEqual"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_GreaterThan"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (num <= 1757458838U)
                {
                    if (num <= 1587019679U)
                    {
                        if (num != 1516143579U)
                        {
                            if (num != 1548478473U)
                            {
                                if (num != 1587019679U)
                                {
                                    goto IL_06C9;
                                }
                                if (!(methodName == "op_Explicit"))
                                {
                                    goto IL_06C9;
                                }
                            }
                            else if (!(methodName == "op_RightShift"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_Equality"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (num != 1683505413U)
                    {
                        if (num != 1706699053U)
                        {
                            if (num != 1757458838U)
                            {
                                goto IL_06C9;
                            }
                            if (!(methodName == "op_SubtractionAssignment"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_MemberSelection"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_SignedRightShift"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (num <= 2188414031U)
                {
                    if (num != 1850069070U)
                    {
                        if (num != 1915672496U)
                        {
                            if (num != 2188414031U)
                            {
                                goto IL_06C9;
                            }
                            if (!(methodName == "op_UnsignedRightShiftAssignment"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_Division"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_False"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (num != 2242295702U)
                {
                    if (num != 2296502820U)
                    {
                        if (num != 2366795836U)
                        {
                            goto IL_06C9;
                        }
                        if (!(methodName == "op_ExclusiveOr"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_PointerDereference"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (!(methodName == "op_LeftShift"))
                {
                    goto IL_06C9;
                }
            }
            else if (num <= 3066180062U)
            {
                if (num <= 2660509025U)
                {
                    if (num <= 2461891882U)
                    {
                        if (num != 2429678952U)
                        {
                            if (num != 2459852411U)
                            {
                                if (num != 2461891882U)
                                {
                                    goto IL_06C9;
                                }
                                if (!(methodName == "op_AdditionAssignment"))
                                {
                                    goto IL_06C9;
                                }
                            }
                            else if (!(methodName == "op_GreaterThanOrEqual"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_Modulus"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (num != 2536726348U)
                    {
                        if (num != 2574677899U)
                        {
                            if (num != 2660509025U)
                            {
                                goto IL_06C9;
                            }
                            if (!(methodName == "op_ModulusAssignment"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_LogicalNot"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_Decrement"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (num <= 2828549379U)
                {
                    if (num != 2685647650U)
                    {
                        if (num != 2729711762U)
                        {
                            if (num != 2828549379U)
                            {
                                goto IL_06C9;
                            }
                            if (!(methodName == "op_LeftShiftAssignment"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_BitwiseAndAssignment"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_UnsignedRightShift"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (num != 2958252495U)
                {
                    if (num != 3055481669U)
                    {
                        if (num != 3066180062U)
                        {
                            goto IL_06C9;
                        }
                        if (!(methodName == "op_BitwiseOrAssignment"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_ExclusiveOrAssignment"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (!(methodName == "op_Multiply"))
                {
                    goto IL_06C9;
                }
            }
            else if (num <= 3568900899U)
            {
                if (num <= 3476452951U)
                {
                    if (num != 3075696130U)
                    {
                        if (num != 3279419199U)
                        {
                            if (num != 3476452951U)
                            {
                                goto IL_06C9;
                            }
                            if (!(methodName == "op_PointerToMemberSelection"))
                            {
                                goto IL_06C9;
                            }
                        }
                        else if (!(methodName == "op_Subtraction"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_UnaryPlus"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (num != 3492550567U)
                {
                    if (num != 3515220244U)
                    {
                        if (num != 3568900899U)
                        {
                            goto IL_06C9;
                        }
                        if (!(methodName == "op_True"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_RightShiftAssignment"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (!(methodName == "op_BitwiseOr"))
                {
                    goto IL_06C9;
                }
            }
            else if (num <= 3716665893U)
            {
                if (num != 3578149996U)
                {
                    if (num != 3716333934U)
                    {
                        if (num != 3716665893U)
                        {
                            goto IL_06C9;
                        }
                        if (!(methodName == "op_UnaryNegation"))
                        {
                            goto IL_06C9;
                        }
                    }
                    else if (!(methodName == "op_Comma"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (!(methodName == "op_MultiplicationAssignment"))
                {
                    goto IL_06C9;
                }
            }
            else if (num != 3794317784U)
            {
                if (num != 3938291511U)
                {
                    if (num != 4080629120U)
                    {
                        goto IL_06C9;
                    }
                    if (!(methodName == "op_AddressOf"))
                    {
                        goto IL_06C9;
                    }
                }
                else if (!(methodName == "op_LogicalAnd"))
                {
                    goto IL_06C9;
                }
            }
            else if (!(methodName == "op_Inequality"))
            {
                goto IL_06C9;
            }
            return true;
        IL_06C9:
            return false;
        }

        // Token: 0x060005DA RID: 1498 RVA: 0x000D8C48 File Offset: 0x000D6E48
        public bool IsValid()
        {
            bool flag = this._AEI == null;
            bool flag5;
            if (flag)
            {
                _bh4 genericSymbol = this.GetGenericSymbol();
                bool flag2 = genericSymbol != null;
                if (flag2)
                {
                    bool flag3 = genericSymbol is _be8 || genericSymbol is _bg4 || genericSymbol is _bf7 || genericSymbol is _bj6;
                    if (flag3)
                    {
                        return genericSymbol.Assembly != null;
                    }
                }
                bool flag4 = this is _be8 || this is _bg4 || this is _bf7 || this is _bj6;
                flag5 = !flag4 || this.Assembly != null;
            }
            else
            {
                bool flag6 = this._AT == SymbolKind.MethodGroup;
                if (flag6)
                {
                    flag5 = true;
                }
                else
                {
                    int count = this._AEI.Count;
                    while (count-- > 0)
                    {
                        FKI _AFF = this._AEI[count];
                        bool flag7 = !_AFF.IsValid();
                        if (flag7)
                        {
                            this._AEI.RemoveAt(count);
                            bool flag8 = _AFF._AJW != null;
                            if (flag8)
                            {
                                _AFF._AJW.RemoveDeclaration(_AFF);
                                _AFF._AJW = null;
                                _bb4._AIU += 1U;
                                bool flag9 = _bb4._AIU == 0U;
                                if (flag9)
                                {
                                    _bb4._AIU += 1U;
                                }
                            }
                        }
                    }
                    flag5 = this._AEI.Count > 0 || (this._AT == SymbolKind.Namespace && this._AAG.Count > 0);
                }
            }
            return flag5;
        }

        // Token: 0x060005DB RID: 1499 RVA: 0x000D8DE4 File Offset: 0x000D6FE4
        internal virtual _bh4 Rebind()
        {
            bool flag = this._AT == SymbolKind.Namespace;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = this.Assembly.FindSameNamespace(this as _bn1);
            }
            else
            {
                bool flag2 = this._AO == null && this._AGU == null;
                if (flag2)
                {
                    _AAH = this;
                }
                else
                {
                    _bh4 _AAH2 = (this._AO ?? this._AGU).Rebind();
                    bool flag3 = _AAH2 == null;
                    if (flag3)
                    {
                        _AAH = null;
                    }
                    else
                    {
                        bool flag4 = _AAH2 == this._AO;
                        if (flag4)
                        {
                            _AAH = this;
                        }
                        else
                        {
                            List<_bd7> typeParameters = this.GetTypeParameters();
                            int num = ((typeParameters != null) ? typeParameters.Count : 0);
                            bool flag5 = this is _b2;
                            _bh4 _AAH3 = _AAH2.FindName(this._AW, num, flag5);
                            _AAH = _AAH3;
                        }
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x060005DC RID: 1500 RVA: 0x000D8EA8 File Offset: 0x000D70A8
        internal virtual Type GetRuntimeType()
        {
            bool flag = this._AO == null;
            Type type;
            if (flag)
            {
                type = null;
            }
            else
            {
                type = this._AO.GetRuntimeType();
            }
            return type;
        }

        // Token: 0x060005DD RID: 1501 RVA: 0x000D8ED8 File Offset: 0x000D70D8
        public static _bh4 Create(FKI declaration)
        {
            string text = declaration.Name;
            bool flag = text != null;
            if (flag)
            {
                text = _bh4.DecodeId(text);
            }
            _bh4 _AAH = _bh4.Create(declaration._AT, text);
            declaration._ACV = _AAH;
            bool flag2 = declaration._AEJ != null;
            if (flag2)
            {
                _AAH._AV = declaration._AV;
                _AAH._AU = _bh4.AccessLevelFromModifiers(declaration._AV);
                bool flag3 = _AAH._AEI == null;
                if (flag3)
                {
                    _AAH._AEI = new List<FKI>();
                }
                _AAH._AEI.Add(declaration);
            }
            _bb4._AIN _AIO = declaration.NameNode();
            bool flag4 = _AIO is _bb4.DHBA;
            if (flag4)
            {
                _AIO.SetDeclaredSymbol(_AAH);
            }
            return _AAH;
        }

        // Token: 0x060005DE RID: 1502 RVA: 0x000D8F8C File Offset: 0x000D718C
        public static _bh4 Create(SymbolKind kind, string name)
        {
            _bh4 _AAH;
            switch (kind)
            {
                case SymbolKind.Namespace:
                    _AAH = new _bn1
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Interface:
                case SymbolKind.Struct:
                case SymbolKind.Class:
                    _AAH = new _bc6
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Enum:
                    _AAH = new _ba1
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Delegate:
                    _AAH = new _bd2
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Field:
                case SymbolKind.ConstantField:
                case SymbolKind.LocalConstant:
                case SymbolKind.EnumMember:
                case SymbolKind.Property:
                case SymbolKind.Event:
                case SymbolKind.CatchParameter:
                case SymbolKind.Variable:
                case SymbolKind.CaseVariable:
                case SymbolKind.ForEachVariable:
                case SymbolKind.FromClauseVariable:
                case SymbolKind.OutVariable:
                    _AAH = new _bn3
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Indexer:
                    _AAH = new _bb7
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Method:
                    _AAH = new _bb3
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.MethodGroup:
                    _AAH = new _ba7
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Constructor:
                    _AAH = new _bb3
                    {
                        _AW = ".ctor"
                    };
                    goto IL_018B;
                case SymbolKind.Operator:
                    kind = SymbolKind.Method;
                    _AAH = new _bb3
                    {
                        _AW = name,
                        _AII = true
                    };
                    goto IL_018B;
                case SymbolKind.Accessor:
                    _AAH = new _bh4
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.LambdaExpression:
                    _AAH = new _bk6
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.Parameter:
                    _AAH = new _bm1
                    {
                        _AW = name
                    };
                    goto IL_018B;
                case SymbolKind.TypeParameter:
                    _AAH = new _bd7
                    {
                        _AW = name
                    };
                    goto IL_018B;
            }
            _AAH = new _bh4
            {
                _AW = name
            };
        IL_018B:
            _AAH._AT = kind;
            return _AAH;
        }

        // Token: 0x060005DF RID: 1503 RVA: 0x000D9130 File Offset: 0x000D7330
        internal virtual string GetName()
        {
            List<_bd7> typeParameters = this.GetTypeParameters();
            bool flag = typeParameters == null || typeParameters.Count == 0;
            string text;
            if (flag)
            {
                text = this._AW;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(this._AW);
                stringBuilder.Append('<');
                stringBuilder.Append(typeParameters[0].GetName());
                for (int i = 1; i < typeParameters.Count; i++)
                {
                    stringBuilder.Append(", ");
                    stringBuilder.Append(typeParameters[i].GetName());
                }
                stringBuilder.Append('>');
                text = stringBuilder.ToString();
            }
            return text;
        }

        // Token: 0x060005E0 RID: 1504 RVA: 0x000D91E0 File Offset: 0x000D73E0
        public string _AP()
        {
            List<_bd7> typeParameters = this.GetTypeParameters();
            return (typeParameters != null && typeParameters.Count > 0) ? (this._AW + "`" + typeParameters.Count.ToString()) : this._AW;
        }

        // Token: 0x060005E1 RID: 1505 RVA: 0x000D922C File Offset: 0x000D742C
        internal virtual _bh4 TypeOf()
        {
            return this;
        }

        // Token: 0x060005E2 RID: 1506 RVA: 0x000D9240 File Offset: 0x000D7440
        internal virtual _bh4 GetGenericSymbol()
        {
            return this;
        }

        // Token: 0x060005E3 RID: 1507 RVA: 0x000D9254 File Offset: 0x000D7454
        internal virtual _b2 SubstituteTypeParameters(_bh4 context)
        {
            Debug.LogWarning("Not a type! Can't substitute type of: " + this.GetTooltipText());
            return null;
        }

        // Token: 0x060005E4 RID: 1508 RVA: 0x000D9280 File Offset: 0x000D7480
        public _b2 ImportReflectedType(Type type)
        {
            _be8 _AFK;
            bool flag = _bh4._BEJ.TryGetValue(type, out _AFK);
            _b2 _AAC;
            if (flag)
            {
                _AAC = _AFK;
            }
            else
            {
                bool isArray = type.IsArray;
                if (isArray)
                {
                    _b2 _AAC2 = this.ImportReflectedType(type.GetElementType());
                    _bm8 _AX = _AAC2.MakeArrayType(type.GetArrayRank());
                    _AAC = _AX;
                }
                else
                {
                    bool flag2 = (type.IsGenericType || type.ContainsGenericParameters) && !type.IsGenericTypeDefinition;
                    if (flag2)
                    {
                        Type[] genericArguments = type.GetGenericArguments();
                        int num = genericArguments.Length;
                        Type declaringType = type.DeclaringType;
                        bool flag3 = declaringType != null && declaringType.IsGenericType;
                        if (flag3)
                        {
                            Type[] genericArguments2 = declaringType.GetGenericArguments();
                            num -= genericArguments2.Length;
                        }
                        List<_bl9> list = new List<_bl9>(num);
                        for (int i = genericArguments.Length - num; i < genericArguments.Length; i++)
                        {
                            list.Add(_bl9.ForType(genericArguments[i]));
                        }
                        _bl9 _BEK = _bl9.ForType(type.GetGenericTypeDefinition());
                        _bc6 _AHD = _BEK.definition as _bc6;
                        _bc6 _AHD2 = _AHD;
                        KJK[] array = list.ToArray();
                        _bi5 _AAE = _AHD2.ConstructType(array);
                        _AAC = _AAE;
                    }
                    else
                    {
                        bool isGenericParameter = type.IsGenericParameter;
                        if (isGenericParameter)
                        {
                            Debug.LogError("Importing reflected generic type parameter " + type.FullName);
                        }
                        _AFK = (_bh4._BEJ[type] = new _be8(type));
                        this._AAG._AWM(_AFK._AW, _AFK._AHG(), _AFK);
                        _AFK._AO = this;
                        _AAC = _AFK;
                    }
                }
            }
            return _AAC;
        }

        // Token: 0x060005E5 RID: 1509 RVA: 0x000D940C File Offset: 0x000D760C
        public _ba7 ImportReflectedMethod(MethodInfo info)
        {
            string name = info.Name;
            _bh4 _AAH = null;
            this._AAG.TryGetValue(name, 0, out _AAH);
            _ba7 _AAK = _AAH as _ba7;
            bool flag = _AAH != null && _AAK == null;
            if (flag)
            {
                Debug.LogError("Error Importing Method: " + ((info != null) ? info.ToString() : null));
            }
            bool flag2 = _AAK == null;
            if (flag2)
            {
                _AAK = _bh4.Create(SymbolKind.MethodGroup, name) as _ba7;
                _AAK._AO = this;
                this._AAG._AWM(name, 0, _AAK);
            }
            _bg4 _BEL = new _bg4(info, _AAK);
            _AAK.AddMethod(_BEL);
            return _AAK;
        }

        // Token: 0x060005E6 RID: 1510 RVA: 0x000D94AC File Offset: 0x000D76AC
        public _bh4 ImportReflectedConstructor(ConstructorInfo info)
        {
            _bf7 _BEM = new _bf7(info, this);
            this._AAG._AWM(".ctor", 0, _BEM);
            return _BEM;
        }

        // Token: 0x060005E7 RID: 1511 RVA: 0x000D94DC File Offset: 0x000D76DC
        public void AddMember(_bh4 symbol)
        {
            symbol._AO = this;
            bool flag = !string.IsNullOrEmpty(symbol._AW);
            if (flag)
            {
                FKI _AFF = ((symbol._AEI != null && symbol._AEI.Count == 1) ? symbol._AEI[0] : null);
                bool flag2 = _AFF != null && _AFF._AQN > 0;
                if (flag2)
                {
                    this._AAG._AWM(_AFF.Name, _AFF._AQN, symbol);
                }
                else
                {
                    this._AAG._AWM(symbol._AW, symbol._AHG(), symbol);
                }
            }
        }

        // Token: 0x060005E8 RID: 1512 RVA: 0x000D9574 File Offset: 0x000D7774
        public _bh4 AddMember(FKI symbol)
        {
            _bh4 _AAH = _bh4.Create(symbol);
            string _ADY = _AAH._AW;
            bool flag = _AAH._AT == SymbolKind.Method;
            if (flag)
            {
                _bh4 _AAH2 = null;
                bool flag2 = !this._AAG.TryGetValue(_ADY, 0, out _AAH2) || !(_AAH2 is _ba7);
                if (flag2)
                {
                    _AAH2 = this.AddMember(new FKI(_ADY)
                    {
                        _AT = SymbolKind.MethodGroup,
                        _AV = symbol._AV,
                        _AEJ = symbol._AEJ,
                        _AJW = symbol._AJW
                    });
                }
                _ba7 _AAK = _AAH2 as _ba7;
                bool flag3 = _AAK != null;
                if (flag3)
                {
                    _AAK.AddMethod((_bb3)_AAH);
                }
            }
            else
            {
                bool flag4 = _AAH._AT == SymbolKind.Delegate;
                if (flag4)
                {
                    _bd2 _BEN = (_bd2)_AAH;
                    _BEN._AIJ = new KJK(symbol._AEJ.FindChildByName("void")) ?? new KJK(symbol._AEJ.FindChildByName("type"));
                }
                else
                {
                    bool flag5 = _AAH._AT == SymbolKind.Enum;
                    if (flag5)
                    {
                        _ba1 _BEO = (_ba1)_AAH;
                        _bb4._ACW _AGZ = symbol._AEJ.FindChildByName("enumBase") as _bb4._ACW;
                        bool flag6 = _AGZ != null;
                        if (flag6)
                        {
                            _AGZ = _AGZ.NodeAt(1);
                        }
                        _BEO._ADB((_AGZ == null) ? new KJK(_bh4._AAQ) : new KJK(_AGZ));
                    }
                }
                this.AddMember(_AAH);
            }
            bool flag7 = _AAH._AQL();
            if (flag7)
            {
                bool flag8 = _AAH is _b2;
                if (flag8)
                {
                    _bc5.FindOtherTypeDeclarationParts(symbol);
                    _bc5.ParseAllAsyncBuffers();
                }
            }
            return _AAH;
        }

        // Token: 0x060005E9 RID: 1513 RVA: 0x000D9720 File Offset: 0x000D7920
        internal virtual _bh4 AddDeclaration(FKI symbol)
        {
            _bn1 _APR = this as _bn1;
            bool flag = _APR != null && symbol is _bf8;
            if (flag)
            {
                _bb4._ACW _AGZ = symbol._AEJ.NodeAt(1);
                bool flag2 = _AGZ == null;
                if (flag2)
                {
                    return null;
                }
                for (int i = 0; i < (int)(_AGZ._AIX - 2); i += 2)
                {
                    string text = _AGZ.ChildAt(i).Print();
                    _bh4 _AAH = _APR.FindName(text, 0, false);
                    bool flag3 = _AAH == null;
                    if (flag3)
                    {
                        _AAH = new _bn1
                        {
                            _AT = SymbolKind.Namespace,
                            _AW = text,
                            _AU = AccessLevel.Public,
                            _AV = Modifiers.Public
                        };
                        _APR.AddMember(_AAH);
                    }
                    _APR = _AAH as _bn1;
                    bool flag4 = _APR == null;
                    if (flag4)
                    {
                        break;
                    }
                }
            }
            _bh4 _AAH2 = _APR ?? this;
            _bh4 _AAH3;
            bool flag5 = !_AAH2._AAG.TryGetValue(symbol.Name, (symbol._AT == SymbolKind.Method) ? 0 : symbol._AQN, out _AAH3) || ((symbol._AT == SymbolKind.Operator || symbol._AT == SymbolKind.Method) && _AAH3 is _ba7) || _AAH3 is _bj6 || _AAH3 is _be8 || _AAH3 is _bg4 || _AAH3 is _bf7 || !_AAH3.IsValid();
            if (flag5)
            {
                bool flag6 = _AAH3 != null && (_AAH3 is _bj6 || _AAH3 is _be8 || _AAH3 is _bg4 || _AAH3 is _bf7) && _AAH3 != symbol._ACV;
                if (flag6)
                {
                    _AAH3.Invalidate();
                }
                _AAH3 = _AAH2.AddMember(symbol);
            }
            else
            {
                bool flag7 = _AAH3._AT == SymbolKind.Namespace && symbol._AT == SymbolKind.Namespace;
                if (flag7)
                {
                    bool flag8 = _AAH3._AEI == null;
                    if (flag8)
                    {
                        _AAH3._AEI = new List<FKI>();
                    }
                    _AAH3._AEI.Add(symbol);
                }
                else
                {
                    bool flag9 = symbol._AQL() && _AAH3._AEI != null && _AAH3._AEI.Count > 0;
                    if (flag9)
                    {
                        _b2 _AAC = _AAH3 as _b2;
                        bool flag10 = _AAC != null;
                        if (flag10)
                        {
                            _AAC.InvalidateBaseType();
                        }
                        _AAH3._AEI.Add(symbol);
                        _AAH3._AV |= symbol._AV & (Modifiers.Static | Modifiers.New | Modifiers.Sealed | Modifiers.Abstract);
                    }
                    else
                    {
                        _AAH3 = _AAH2.AddMember(symbol);
                    }
                }
            }
            symbol._ACV = _AAH3;
            _bb4._AIN _AIO = symbol.NameNode();
            bool flag11 = _AIO != null;
            if (flag11)
            {
                _bb4.DHBA _AEM = _AIO as _bb4.DHBA;
                bool flag12 = _AEM == null;
                if (flag12)
                {
                    _bb4._ACW _AGZ2 = (_bb4._ACW)_AIO;
                    bool flag13 = _AGZ2._AHB() == "memberName";
                    if (flag13)
                    {
                        _AGZ2 = _AGZ2.NodeAt(0);
                        bool flag14 = _AGZ2 != null;
                        if (flag14)
                        {
                            _AGZ2 = _AGZ2.NodeAt(-1);
                            bool flag15 = _AGZ2 != null;
                            if (flag15)
                            {
                                bool flag16 = _AGZ2._AHB() == "qidStart";
                                if (flag16)
                                {
                                    bool flag17 = _AGZ2._AIX < 3;
                                    if (flag17)
                                    {
                                        _AEM = _AGZ2.LeafAt(0);
                                    }
                                    else
                                    {
                                        _AEM = _AGZ2.LeafAt(2);
                                    }
                                }
                                else
                                {
                                    _AGZ2 = _AGZ2.NodeAt(0);
                                    bool flag18 = _AGZ2 != null;
                                    if (flag18)
                                    {
                                        _AEM = _AGZ2.LeafAt(1);
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag19 = _AEM != null;
                if (flag19)
                {
                    _AEM.SetDeclaredSymbol(_AAH3);
                    bool flag20 = _AAH3._AT == SymbolKind.Destructor;
                    if (flag20)
                    {
                        string text2 = _bh4.DecodeId(_AEM._ACX.text);
                        bool flag21 = text2 != _AAH2._AW;
                        if (flag21)
                        {
                            _AEM._AJF = "Name of destructor must match name of class";
                        }
                    }
                    else
                    {
                        bool flag22 = _AAH3._AT == SymbolKind.Constructor;
                        if (flag22)
                        {
                            string text3 = _bh4.DecodeId(_AEM._ACX.text);
                            bool flag23 = text3 != _AAH2._AW;
                            if (flag23)
                            {
                                _AEM._AJF = "Methods must have return type";
                            }
                        }
                    }
                }
            }
            return _AAH3;
        }

        // Token: 0x060005EA RID: 1514 RVA: 0x000D9B20 File Offset: 0x000D7D20
        private void Invalidate()
        {
            this._AGU = this._AO;
            this._AO = null;
            int num = this._AAG.Count;
            while (num-- > 0)
            {
                this._AAG._AAI(num).Invalidate();
            }
            List<_bd7> typeParameters = this.GetTypeParameters();
            bool flag = typeParameters != null;
            if (flag)
            {
                int count = typeParameters.Count;
                while (count-- > 0)
                {
                    typeParameters[count].Invalidate();
                }
            }
        }

        // Token: 0x060005EB RID: 1515 RVA: 0x000D9BA4 File Offset: 0x000D7DA4
        internal virtual void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Method || symbol._AT == SymbolKind.Operator;
            if (flag)
            {
                int num = this._AAG.Count;
                while (num-- > 0)
                {
                    _bh4 _AAH = this._AAG._AAI(num);
                    bool flag2 = _AAH._AEI == null;
                    if (!flag2)
                    {
                        bool flag3 = _AAH._AT == SymbolKind.MethodGroup;
                        if (flag3)
                        {
                            _ba7 _AAK = _AAH as _ba7;
                            bool flag4 = _AAK._AAM.Count > 0;
                            if (flag4)
                            {
                                _AAK.RemoveDeclaration(symbol);
                                bool flag5 = _AAK._AAM.Count == 0;
                                if (flag5)
                                {
                                    _AAK._AEI.Clear();
                                    _AAK._AGU = _AAK._AO;
                                    _AAK._AO = null;
                                    this._AAG.RemoveAt(num);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                int num2 = this._AAG.Count;
                while (num2-- > 0)
                {
                    _bh4 _AAH2 = this._AAG._AAI(num2);
                    bool flag6 = _AAH2._AEI == null;
                    if (!flag6)
                    {
                        bool flag7 = _AAH2._AT == SymbolKind.MethodGroup;
                        if (!flag7)
                        {
                            bool flag8 = _AAH2.ContainsDeclaration(symbol);
                            if (flag8)
                            {
                                break;
                            }
                        }
                    }
                }
                bool flag9 = num2 >= 0;
                if (flag9)
                {
                    _bh4 _AAH3 = this._AAG._AAI(num2);
                    _AAH3._AEI.Remove(symbol);
                    bool flag10 = _AAH3._AEI.Count == 0;
                    if (flag10)
                    {
                        bool flag11 = _AAH3._AT != SymbolKind.Namespace || _AAH3._AAG.Count == 0;
                        if (flag11)
                        {
                            this._AAG.RemoveAt(num2);
                        }
                    }
                    else
                    {
                        SymbolKind _ABY = _AAH3._AEI[0]._AT;
                        bool flag12 = _AAH3._AT != _ABY;
                        if (flag12)
                        {
                            bool flag13 = (_ABY == SymbolKind.Class || _ABY == SymbolKind.Struct || _ABY == SymbolKind.Interface) && _AAH3._AQL() && _AAH3 is _b2;
                            if (flag13)
                            {
                                _AAH3._AT = _ABY;
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060005EC RID: 1516 RVA: 0x000D9DE0 File Offset: 0x000D7FE0
        public override string ToString()
        {
            return this._AT.ToString() + " " + this._AW;
        }

        // Token: 0x060005ED RID: 1517 RVA: 0x000D9E14 File Offset: 0x000D8014
        internal virtual string CompletionDisplayString(string styledName)
        {
            return styledName;
        }

        // Token: 0x060005EE RID: 1518 RVA: 0x000D9E28 File Offset: 0x000D8028
        internal virtual string GetDelegateInfoText()
        {
            return this.GetTooltipText();
        }

        // Token: 0x060005EF RID: 1519 RVA: 0x000D9E40 File Offset: 0x000D8040
        public string PrintParameters(List<_bm1> parameters, bool singleLine = false)
        {
            bool flag = parameters == null || (this._BEP && parameters.Count == 1);
            string text;
            if (flag)
            {
                text = "";
            }
            else
            {
                string text2 = "";
                string text3 = ((!singleLine && parameters.Count > (this._BEP ? 2 : 1)) ? "\n    " : "");
                string text4 = ((!singleLine && parameters.Count > (this._BEP ? 2 : 1)) ? ",\n    " : ", ");
                for (int i = (this._BEP ? 1 : 0); i < parameters.Count; i++)
                {
                    _bm1 _AGS = parameters[i];
                    bool flag2 = _AGS == null;
                    if (!flag2)
                    {
                        _b2 _AAC = _AGS.TypeOf() as _b2;
                        bool flag3 = _AAC == null;
                        if (!flag3)
                        {
                            _AAC = _AAC.SubstituteTypeParameters(this);
                            bool flag4 = _AAC == null;
                            if (!flag4)
                            {
                                text2 += text3;
                                bool flag5 = _AGS._AWV();
                                if (flag5)
                                {
                                    text2 += "this ";
                                }
                                else
                                {
                                    bool flag6 = _AGS._AGL();
                                    if (flag6)
                                    {
                                        text2 += "ref ";
                                    }
                                    else
                                    {
                                        bool flag7 = _AGS._AGK();
                                        if (flag7)
                                        {
                                            text2 += "out ";
                                        }
                                        else
                                        {
                                            bool flag8 = _AGS._AHS();
                                            if (flag8)
                                            {
                                                text2 += "in ";
                                            }
                                            else
                                            {
                                                bool flag9 = _AGS._AHO();
                                                if (flag9)
                                                {
                                                    text2 += "params ";
                                                }
                                            }
                                        }
                                    }
                                }
                                text2 = text2 + _AAC.GetName() + " " + _AGS._AW;
                                bool flag10 = _AGS._AWY != null;
                                if (flag10)
                                {
                                    text2 = text2 + " = " + _AGS._AWY;
                                }
                                text3 = text4;
                            }
                        }
                    }
                }
                bool flag11 = !singleLine && parameters.Count > 1;
                if (flag11)
                {
                    text2 += "\n";
                }
                text = text2;
            }
            return text;
        }

        // Token: 0x17000029 RID: 41
        // (get) Token: 0x060005F0 RID: 1520 RVA: 0x000DA03C File Offset: 0x000D823C
        internal virtual bool IsExtensionMethod
        {
            get
            {
                return false;
            }
        }

        // Token: 0x1700002A RID: 42
        // (get) Token: 0x060005F1 RID: 1521 RVA: 0x000DA050 File Offset: 0x000D8250
        internal virtual bool IsOperator
        {
            get
            {
                return false;
            }
        }

        // Token: 0x060005F2 RID: 1522 RVA: 0x000DA064 File Offset: 0x000D8264
        public bool _AHF()
        {
            return (this._AV & Modifiers.Override) > Modifiers.None;
        }

        // Token: 0x060005F3 RID: 1523 RVA: 0x000DA088 File Offset: 0x000D8288
        public bool _AAO()
        {
            return (this._AV & Modifiers.Virtual) > Modifiers.None;
        }

        // Token: 0x060005F4 RID: 1524 RVA: 0x000DA0AC File Offset: 0x000D82AC
        public string GetTooltipTextAsExtensionMethod()
        {
            string text = "";
            try
            {
                this._BEP = true;
                text = this.GetTooltipText();
            }
            finally
            {
                this._BEP = false;
            }
            return text;
        }

        // Token: 0x060005F5 RID: 1525 RVA: 0x000DA0F4 File Offset: 0x000D82F4
        internal virtual string GetTooltipText()
        {
            bool flag = this._AT == SymbolKind.Null;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                bool flag2 = this._AT == SymbolKind.Error;
                if (flag2)
                {
                    text = this._AW;
                }
                else
                {
                    string text2 = string.Empty;
                    switch (this._AT)
                    {
                        case SymbolKind.Namespace:
                            return this._APK = "namespace " + this._AYM();
                        case SymbolKind.Delegate:
                            text2 = "delegate ";
                            break;
                        case SymbolKind.ConstantField:
                        case SymbolKind.LocalConstant:
                            text2 = "(constant) ";
                            break;
                        case SymbolKind.Property:
                            text2 = "(property) ";
                            break;
                        case SymbolKind.Event:
                            text2 = "(event) ";
                            break;
                        case SymbolKind.Method:
                            text2 = (this.IsExtensionMethod ? "(extension) " : "");
                            break;
                        case SymbolKind.MethodGroup:
                            text2 = "(method group) ";
                            break;
                        case SymbolKind.Constructor:
                            text2 = "(constructor) ";
                            break;
                        case SymbolKind.Destructor:
                            text2 = "(destructor) ";
                            break;
                        case SymbolKind.Accessor:
                            text2 = "(accessor) ";
                            break;
                        case SymbolKind.Parameter:
                            text2 = "(parameter) ";
                            break;
                        case SymbolKind.CatchParameter:
                        case SymbolKind.Variable:
                        case SymbolKind.CaseVariable:
                        case SymbolKind.ForEachVariable:
                        case SymbolKind.FromClauseVariable:
                        case SymbolKind.OutVariable:
                            text2 = "(local variable) ";
                            break;
                        case SymbolKind.Label:
                            return this._APK = "(label) " + this._AW;
                    }
                    _bh4 _AAH = ((this._AT == SymbolKind.Accessor || this._AT == SymbolKind.MethodGroup) ? null : this.TypeOf());
                    string text3 = string.Empty;
                    bool flag3 = _AAH != null && this._AT != SymbolKind.Namespace && this._AT != SymbolKind.Constructor && this._AT != SymbolKind.Destructor;
                    if (flag3)
                    {
                        _bi5 _AAE = ((_AAH._AT == SymbolKind.Delegate) ? _AAH : this._AO) as _bi5;
                        bool flag4 = _AAE != null;
                        if (flag4)
                        {
                            _AAH = ((_b2)_AAH).SubstituteTypeParameters(_AAE);
                        }
                        bool flag5 = this._AT == SymbolKind.Keyword;
                        if (flag5)
                        {
                            text3 = "keyword ";
                        }
                        else
                        {
                            bool flag6 = this._AT == SymbolKind.Snippet;
                            if (flag6)
                            {
                                text3 = "template ";
                            }
                            else
                            {
                                text3 = _AAH.GetName() + " ";
                            }
                        }
                        bool flag7 = _AAH._AT != SymbolKind.TypeParameter;
                        if (flag7)
                        {
                            for (_b2 _AAC = _AAH._AO as _b2; _AAC != null; _AAC = _AAC._AO as _b2)
                            {
                                text3 = _AAC.GetName() + "." + text3;
                            }
                        }
                    }
                    List<_bm1> parameters = this.GetParameters();
                    string text4 = string.Empty;
                    _bh4 _AAH2 = ((this._AO is _ba7) ? this._AO._AO : this._AO);
                    bool flag8 = (_AAH2 is _b2 && _AAH2._AT != SymbolKind.Delegate && this._AT != SymbolKind.TypeParameter && _AAH2._AT != SymbolKind.LambdaExpression) || _AAH2 is _bn1;
                    if (flag8)
                    {
                        string text5 = _AAH2.GetName();
                        bool flag9 = this._AT == SymbolKind.Constructor;
                        if (flag9)
                        {
                            _b2 _AAC2 = _AAH2._AO as _b2;
                            text5 = ((_AAC2 != null) ? _AAC2.GetName() : null);
                        }
                        else
                        {
                            bool flag10 = this._AT == SymbolKind.Method && this._BEP;
                            if (flag10)
                            {
                                _bh4 _AAH3 = parameters[0].TypeOf();
                                bool flag11 = _AAH3 != null;
                                if (flag11)
                                {
                                    _AAH3 = _AAH3.SubstituteTypeParameters(this);
                                }
                                text5 = ((_AAH3 != null) ? _AAH3.GetName() : null);
                            }
                        }
                        bool flag12 = !string.IsNullOrEmpty(text5);
                        if (flag12)
                        {
                            text4 = text5 + ".";
                        }
                    }
                    string text6 = this.GetName();
                    string text7 = string.Empty;
                    string text8 = null;
                    bool flag13 = this._AT == SymbolKind.Method;
                    if (flag13)
                    {
                        text6 += ((parameters.Count == (this._BEP ? 2 : 1)) ? "( " : "(");
                        text8 = ((parameters.Count == (this._BEP ? 2 : 1)) ? " )" : ")");
                    }
                    else
                    {
                        bool flag14 = this._AT == SymbolKind.Constructor;
                        if (flag14)
                        {
                            text6 = _AAH2._AW + "(";
                            text8 = ")";
                        }
                        else
                        {
                            bool flag15 = this._AT == SymbolKind.Destructor;
                            if (flag15)
                            {
                                text6 = "~" + _AAH2._AW + "()";
                            }
                            else
                            {
                                bool flag16 = this._AT == SymbolKind.Indexer;
                                if (flag16)
                                {
                                    text6 = ((parameters.Count == 1) ? "this[ " : "this[");
                                    text8 = ((parameters.Count == 1) ? " ]" : "]");
                                }
                                else
                                {
                                    bool flag17 = this._AT == SymbolKind.Delegate;
                                    if (flag17)
                                    {
                                        text6 += ((parameters.Count == 1) ? "( " : "(");
                                        text8 = ((parameters.Count == 1) ? " )" : ")");
                                    }
                                }
                            }
                        }
                    }
                    bool flag18 = parameters != null;
                    if (flag18)
                    {
                        text7 = this.PrintParameters(parameters, false);
                    }
                    this._APK = string.Concat(new string[] { text2, text3, text4, text6, text7, text8 });
                    this._APK += this.DebugValue();
                    bool flag19 = _AAH != null && _AAH._AT == SymbolKind.Delegate;
                    if (flag19)
                    {
                        this._APK += "\n\nDelegate info\n";
                        this._APK += _AAH.GetDelegateInfoText();
                    }
                    string xmlDocs = this.GetXmlDocs();
                    bool flag20 = !string.IsNullOrEmpty(xmlDocs);
                    if (flag20)
                    {
                        this._APK = this._APK + "\n\n" + xmlDocs;
                    }
                    text = this._APK;
                }
            }
            return text;
        }

        // Token: 0x060005F6 RID: 1526 RVA: 0x000DA6FC File Offset: 0x000D88FC
        protected string DebugValue()
        {
            bool flag = this._AT == SymbolKind.Field || (this._AT == SymbolKind.Property && _bg8._BAJ);
            string text;
            if (flag)
            {
                bool flag2 = !(this._AO is _b2);
                if (flag2)
                {
                    text = "";
                }
                else
                {
                    Type runtimeType = this._AO.GetRuntimeType();
                    bool flag3 = runtimeType == null;
                    if (flag3)
                    {
                        text = "";
                    }
                    else
                    {
                        bool containsGenericParameters = runtimeType.ContainsGenericParameters;
                        if (containsGenericParameters)
                        {
                            text = "";
                        }
                        else
                        {
                            _b2 _AAC = this.TypeOf() as _b2;
                            bool flag4 = !this.IsStatic;
                            if (flag4)
                            {
                                bool flag5 = typeof(ScriptableObject).IsAssignableFrom(runtimeType);
                                bool flag6 = typeof(Component).IsAssignableFrom(runtimeType);
                                bool flag7 = flag5 || flag6;
                                if (flag7)
                                {
                                    UnityEngine.Object[] array = null;
                                    string text2 = "";
                                    bool flag8 = flag6;
                                    if (flag8)
                                    {
                                        bool flag9 = this._AW == "material" || this._AW == "mesh";
                                        if (flag9)
                                        {
                                            return "";
                                        }
                                        array = Selection.GetFiltered(runtimeType, 4);
                                        bool flag10 = array.Length != 0;
                                        if (flag10)
                                        {
                                            text2 = "\n    in " + array.Length.ToString() + " selected scene objects";
                                        }
                                        else
                                        {
                                        array = UnityEngine.Object.FindObjectsOfType(runtimeType);
                                            bool flag11 = array.Length != 0;
                                            if (flag11)
                                            {
                                                text2 = "\n    in " + array.Length.ToString() + " active scene objects";
                                            }
                                        }
                                    }
                                    bool flag12 = array == null || array.Length == 0;
                                    if (flag12)
                                    {
                                        array = Resources.FindObjectsOfTypeAll(runtimeType);
                                        text2 = "\n    in " + array.Length.ToString() + " instances";
                                    }
                                    FieldInfo fieldInfo = ((this._AT == SymbolKind.Field) ? runtimeType.GetField(this._AW, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : null);
                                    PropertyInfo propertyInfo = ((this._AT == SymbolKind.Property) ? runtimeType.GetProperty(this._AW, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : null);
                                    bool flag13 = fieldInfo == null && propertyInfo == null;
                                    if (flag13)
                                    {
                                        text = text2;
                                    }
                                    else
                                    {
                                        bool flag14 = propertyInfo != null && propertyInfo.GetGetMethod(true) == null;
                                        if (flag14)
                                        {
                                            text = text2;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                bool flag15 = !this.IsDebuggerBrowsable(fieldInfo ?? propertyInfo);
                                                if (flag15)
                                                {
                                                    return text2;
                                                }
                                                for (int i = 0; i < Math.Min(array.Length, 10); i++)
                                                {
                                                    object obj = ((fieldInfo != null) ? fieldInfo.GetValue(array[i]) : propertyInfo.GetValue(array[i], null));
                                                    text2 += this.DebugPrintValue(_AAC, obj, "\n    " + ((array[i].name == "") ? array[i].ToString() : string.Concat(new string[]
                                                    {
                                                        "\"",
                                                        array[i].name,
                                                        "\" (",
                                                        array[i].GetHashCode().ToString(),
                                                        ")"
                                                    })) + ": ");
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            text = text2;
                                        }
                                    }
                                }
                                else
                                {
                                    text = "";
                                }
                            }
                            else
                            {
                                bool flag16 = this._AT == SymbolKind.Field;
                                object obj;
                                if (flag16)
                                {
                                    FieldInfo field = runtimeType.GetField(this._AW, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                    bool flag17 = field == null;
                                    if (flag17)
                                    {
                                        return "";
                                    }
                                    try
                                    {
                                        bool flag18 = !this.IsDebuggerBrowsable(field);
                                        if (flag18)
                                        {
                                            return "";
                                        }
                                        obj = field.GetValue(null);
                                    }
                                    catch
                                    {
                                        return "";
                                    }
                                }
                                else
                                {
                                    bool flag19 = this._AT == SymbolKind.Property;
                                    if (!flag19)
                                    {
                                        return "";
                                    }
                                    PropertyInfo property = runtimeType.GetProperty(this._AW, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                    bool flag20 = property == null;
                                    if (flag20)
                                    {
                                        return "";
                                    }
                                    try
                                    {
                                        bool flag21 = !this.IsDebuggerBrowsable(property);
                                        if (flag21)
                                        {
                                            return "";
                                        }
                                        obj = property.GetValue(null, null);
                                    }
                                    catch
                                    {
                                        return "";
                                    }
                                }
                                text = this.DebugPrintValue(_AAC, obj, "\n    = ");
                            }
                        }
                    }
                }
            }
            else
            {
                text = "";
            }
            return text;
        }

        // Token: 0x060005F7 RID: 1527 RVA: 0x000DABB0 File Offset: 0x000D8DB0
        private bool IsDebuggerBrowsable(MemberInfo memberInfo)
        {
            DebuggerBrowsableAttribute debuggerBrowsableAttribute = Attribute.GetCustomAttribute(memberInfo, typeof(DebuggerBrowsableAttribute), true) as DebuggerBrowsableAttribute;
            return debuggerBrowsableAttribute == null || debuggerBrowsableAttribute.State == DebuggerBrowsableState.Collapsed;
        }

        // Token: 0x060005F8 RID: 1528 RVA: 0x000DABE8 File Offset: 0x000D8DE8
        protected string DebugPrintValue(_b2 typeOf, object value, string header)
        {
            bool flag = value == null;
            string text;
            if (flag)
            {
                text = header + "null;";
            }
            else
            {
                bool flag2 = typeOf == _bh4._BFP;
                if (flag2)
                {
                    text = header + (((bool)value) ? "true;" : "false;");
                }
                else
                {
                    bool flag3 = typeOf == _bh4._AAQ || typeOf == _bh4._AAX || typeOf == _bh4._AAZ;
                    if (flag3)
                    {
                        text = header + ((value != null) ? value.ToString() : null) + ";";
                    }
                    else
                    {
                        bool flag4 = typeOf == _bh4._AAU || typeOf == _bh4._AAY || typeOf == _bh4._AAW;
                        if (flag4)
                        {
                            text = header + ((value != null) ? value.ToString() : null) + "u;";
                        }
                        else
                        {
                            bool flag5 = typeOf == _bh4._AAR;
                            if (flag5)
                            {
                                text = header + ((value != null) ? value.ToString() : null) + "L;";
                            }
                            else
                            {
                                bool flag6 = typeOf == _bh4._AAV;
                                if (flag6)
                                {
                                    text = header + ((value != null) ? value.ToString() : null) + "UL;";
                                }
                                else
                                {
                                    bool flag7 = typeOf == _bh4._AAS;
                                    if (flag7)
                                    {
                                        text = header + ((value != null) ? value.ToString() : null) + "f;";
                                    }
                                    else
                                    {
                                        bool flag8 = typeOf == _bh4._ABA;
                                        if (flag8)
                                        {
                                            text = header + "'" + ((value != null) ? value.ToString() : null) + "';";
                                        }
                                        else
                                        {
                                            bool flag9 = typeOf == _bh4._BFD;
                                            if (flag9)
                                            {
                                                string text2 = "";
                                                try
                                                {
                                                    text2 = value as string;
                                                }
                                                catch
                                                {
                                                }
                                                bool flag10 = text2.Length > 100;
                                                if (flag10)
                                                {
                                                    text2 = text2.Substring(0, 100) + "...";
                                                }
                                                int num = text2.IndexOfAny(new char[] { '\r', '\n' });
                                                bool flag11 = num >= 0;
                                                if (flag11)
                                                {
                                                    text2 = text2.Substring(0, num) + "...";
                                                }
                                                text = header + "\"" + text2 + "\";";
                                            }
                                            else
                                            {
                                                IEnumerable enumerable = value as IEnumerable;
                                                bool flag12 = enumerable != null;
                                                if (flag12)
                                                {
                                                    Array array = value as Array;
                                                    bool flag13 = array != null;
                                                    if (flag13)
                                                    {
                                                        return header + "{ Length = " + array.Length.ToString() + " }";
                                                    }
                                                    ICollection collection = value as ICollection;
                                                    bool flag14 = collection != null;
                                                    if (flag14)
                                                    {
                                                        return header + "{ Count = " + collection.Count.ToString() + " }";
                                                    }
                                                    PropertyInfo property = value.GetType().GetProperty("Count");
                                                    bool flag15 = property != null;
                                                    if (flag15)
                                                    {
                                                        object value2 = property.GetValue(value, null);
                                                        return header + "{ Count = " + ((value2 != null) ? value2.ToString() : null) + " }";
                                                    }
                                                }
                                                string text3 = value.ToString();
                                                bool flag16 = text3.Length > 100;
                                                if (flag16)
                                                {
                                                    text3 = text3.Substring(0, 100) + "...";
                                                }
                                                int num2 = text3.IndexOfAny(new char[] { '\r', '\n' });
                                                bool flag17 = num2 >= 0;
                                                if (flag17)
                                                {
                                                    text3 = text3.Substring(0, num2) + "...";
                                                }
                                                text = header + "{ " + text3 + " }";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return text;
        }

        // Token: 0x060005F9 RID: 1529 RVA: 0x000DAF7C File Offset: 0x000D917C
        internal virtual List<_bm1> GetParameters()
        {
            return null;
        }

        // Token: 0x060005FA RID: 1530 RVA: 0x000DAF90 File Offset: 0x000D9190
        internal virtual List<_bd7> GetTypeParameters()
        {
            return null;
        }

        // Token: 0x060005FB RID: 1531 RVA: 0x000DAFA4 File Offset: 0x000D91A4
        public async void AsyncDownloadXml(string url, string path)
        {
            await Task.Run(delegate
            {
                this.DownloadXml(url, path);
            });
            if (this._BEQ != null)
            {
                this._BEQ();
            }
        }

        // Token: 0x060005FC RID: 1532 RVA: 0x000DAFEC File Offset: 0x000D91EC
        public void DownloadXml(string url, string path)
        {
            this._BER = true;
            WebResponse webResponse = null;
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                webResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            }
            catch (Exception ex)
            {
                this._BER = false;
                return;
            }
            bool flag = webResponse != null;
            if (flag)
            {
                try
                {
                    Stream responseStream = webResponse.GetResponseStream();
                    Stream stream = File.Create(path);
                    long contentLength = webResponse.ContentLength;
                    long num = 0L;
                    byte[] array = new byte[1024];
                    for (int i = responseStream.Read(array, 0, array.Length); i > 0; i = responseStream.Read(array, 0, array.Length))
                    {
                        num += (long)i;
                        stream.Write(array, 0, i);
                    }
                    stream.Dispose();
                    responseStream.Dispose();
                    this._BER = false;
                }
                catch (Exception ex2)
                {
                    this._BER = false;
                }
            }
        }

        // Token: 0x060005FD RID: 1533 RVA: 0x000DB0F0 File Offset: 0x000D92F0
        protected string GetXmlDocs()
        {
            string text = null;
            string text2 = this._BES();
            bool flag = text2 != null;
            string text3;
            if (flag)
            {
                bool flag2 = _ba9._AHZ.TryGetValue(text2, out text);
                if (flag2)
                {
                    text3 = text;
                }
                else
                {
                    bool flag3 = _bm4._AHZ.TryGetValue(text2, out text);
                    if (flag3)
                    {
                        text3 = text;
                    }
                    else
                    {
                        text3 = null;
                    }
                }
            }
            else
            {
                string text4 = this._BET();
                bool flag4 = text4 != null;
                if (flag4)
                {
                    bool flag5 = _bl8._AHZ.TryGetValue(text4, out text);
                    if (flag5)
                    {
                        return Regex.Replace(text, "`[1-9]", "");
                    }
                    string text5 = string.Empty;
                    string text6 = string.Empty;
                    for (_bh4 _AAH = this._AO; _AAH != null; _AAH = _AAH._AO)
                    {
                        bool flag6 = _AAH._AT == SymbolKind.Namespace && _AAH.GetName() != "";
                        if (flag6)
                        {
                            text5 = _AAH.GetName() + "." + text5;
                        }
                    }
                    bool flag7 = text5 != string.Empty && text5.StartsWith("System");
                    if (flag7)
                    {
                        text5 = text5.Substring(0, text5.Length - 1);
                        string text7 = Application.dataPath.Substring(0, Application.dataPath.Length - 7) + "/Library/XmlDocs";
                        bool flag8 = !Directory.Exists(text7);
                        if (flag8)
                        {
                            Directory.CreateDirectory(text7);
                        }
                        string text8 = text7 + "/" + text5;
                        bool flag9 = !Directory.Exists(text8);
                        if (flag9)
                        {
                            Directory.CreateDirectory(text8);
                        }
                        _bh4 _AAH2 = this;
                        _bh4 _AAH3 = null;
                        while (_AAH2._AO != null && _AAH2._AT != SymbolKind.Namespace)
                        {
                            _AAH3 = _AAH2;
                            _AAH2 = _AAH2._AO;
                        }
                        text6 = _AAH3._AW;
                        bool flag10 = _AAH3.GetTypeParameters() != null;
                        if (flag10)
                        {
                            text6 += string.Format("`{0}", _AAH3.GetTypeParameters().Count);
                        }
                        this._BEU = text8 + "/" + text6 + ".xml";
                        bool flag11 = !File.Exists(this._BEU) && !this._BER;
                        if (flag11)
                        {
                            this._BEV = text6;
                            try
                            {
                                this.AsyncDownloadXml(string.Format("https://raw.githubusercontent.com/dotnet/dotnet-api-docs/master/xml/{0}/{1}.xml", text5, text6), this._BEU);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    bool flag12 = this._BEU != string.Empty && File.Exists(this._BEU);
                    if (!flag12)
                    {
                        return ".Net Docs is downloading from Github...";
                    }
                    try
                    {
                        this._BEW.Load(this._BEU);
                        bool flag13 = this._BEW.FirstChild.Attributes[0].InnerText == text6;
                        if (flag13)
                        {
                            bool flag14 = this._AO._AT == SymbolKind.Namespace;
                            if (flag14)
                            {
                                XmlNode xmlNode = this._BEW.SelectSingleNode("/Type/Docs/summary");
                                bool flag15 = xmlNode != null;
                                if (flag15)
                                {
                                    string text9 = xmlNode.InnerXml;
                                    text9 = Regex.Replace(text9, "<see [a-z]{0,100}=\"([A-Za-z]:)?", "").Replace("\" />", "");
                                    text9 = Regex.Replace(text9, "(http|ftp|https):\\/\\/[\\w\\-_]+(\\.[\\w\\-_]+)+([\\w\\-\\.,@?^=%&:/~\\+#]*[\\w\\-@?^=%&/~\\+#])?\">", "");
                                    return Regex.Replace(text9, "`[1-9]", "");
                                }
                            }
                            else
                            {
                                XmlNode xmlNode2 = this._BEW.SelectSingleNode("/Type/Members/Member[@MemberName = '" + this._AW + "']/Docs/summary");
                                bool flag16 = xmlNode2 != null;
                                if (flag16)
                                {
                                    string text10 = xmlNode2.InnerXml;
                                    text10 = Regex.Replace(text10, "<see [a-z]{0,100}=\"([A-Za-z]:)?", "").Replace("\" />", "");
                                    text10 = Regex.Replace(text10, "(http|ftp|https):\\/\\/[\\w\\-_]+(\\.[\\w\\-_]+)+([\\w\\-\\.,@?^=%&:/~\\+#]*[\\w\\-@?^=%&/~\\+#])?\">", "");
                                    return Regex.Replace(text10, "`[1-9]", "");
                                }
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        return ".Net Docs is downloading from Github...";
                    }
                }
                text3 = text;
            }
            return text3;
        }

        // Token: 0x060005FE RID: 1534 RVA: 0x000DB558 File Offset: 0x000D9758
        public string _BES()
        {
            bool flag = this._AT == SymbolKind.TypeParameter;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                string text2 = this._AYM();
                bool flag2 = text2 == null;
                if (flag2)
                {
                    text = null;
                }
                else
                {
                    bool flag3 = text2.StartsWith("UnityEngine.", StringComparison.Ordinal);
                    if (flag3)
                    {
                        text2 = text2.Substring("UnityEngine.".Length);
                    }
                    else
                    {
                        bool flag4 = text2.StartsWith("UnityEditor.", StringComparison.Ordinal);
                        if (!flag4)
                        {
                            return null;
                        }
                        text2 = text2.Substring("UnityEditor.".Length);
                    }
                    bool flag5 = this._AT == SymbolKind.Indexer;
                    if (flag5)
                    {
                        text2 = text2.Substring(0, text2.LastIndexOf(".", StringComparison.Ordinal) + 1) + "Index_operator";
                    }
                    else
                    {
                        bool flag6 = this._AT == SymbolKind.Constructor;
                        if (flag6)
                        {
                            text2 = text2.Substring(0, text2.LastIndexOf(".", StringComparison.Ordinal)) + "-ctor";
                        }
                        else
                        {
                            bool flag7 = (this._AT == SymbolKind.Field || this._AT == SymbolKind.Property) && this._AO._AT != SymbolKind.Enum;
                            if (flag7)
                            {
                                text2 = text2.Substring(0, text2.LastIndexOf(".", StringComparison.Ordinal)) + "-" + this._AW;
                            }
                        }
                    }
                    bool flag8 = this._AT == SymbolKind.Class && this._AHG() > 0;
                    if (flag8)
                    {
                        this._AW = this._AW + "_" + this._AHG().ToString();
                    }
                    text = text2;
                }
            }
            return text;
        }

        // Token: 0x060005FF RID: 1535 RVA: 0x000DB6E0 File Offset: 0x000D98E0
        public string _BET()
        {
            bool flag = this._AT == SymbolKind.TypeParameter;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                string text2 = this._AYM();
                bool flag2 = text2 == null;
                if (flag2)
                {
                    text = null;
                }
                else
                {
                    bool flag3 = text2.StartsWith("System.IO.", StringComparison.Ordinal);
                    if (flag3)
                    {
                        text2 = text2.Substring("System.IO.".Length);
                    }
                    else
                    {
                        bool flag4 = text2.StartsWith("System.Collections.Generic.", StringComparison.Ordinal);
                        if (flag4)
                        {
                            text2 = text2.Substring("System.Collections.Generic.".Length);
                        }
                        else
                        {
                            bool flag5 = text2.StartsWith("System.Collections.", StringComparison.Ordinal);
                            if (flag5)
                            {
                                text2 = text2.Substring("System.Collections.".Length);
                            }
                            else
                            {
                                bool flag6 = text2.StartsWith("System.Reflection.", StringComparison.Ordinal);
                                if (flag6)
                                {
                                    text2 = text2.Substring("System.Reflection.".Length);
                                }
                                else
                                {
                                    bool flag7 = text2.StartsWith("System.Xml.", StringComparison.Ordinal);
                                    if (flag7)
                                    {
                                        text2 = text2.Substring("System.Xml.".Length);
                                    }
                                    else
                                    {
                                        bool flag8 = text2.StartsWith("System.", StringComparison.Ordinal);
                                        if (!flag8)
                                        {
                                            return null;
                                        }
                                        text2 = text2.Substring("System.".Length);
                                    }
                                }
                            }
                        }
                    }
                    bool flag9 = this._AT == SymbolKind.Indexer;
                    if (flag9)
                    {
                        text2 = text2.Substring(0, text2.LastIndexOf(".", StringComparison.Ordinal) + 1) + "Index_operator";
                    }
                    else
                    {
                        bool flag10 = this._AT == SymbolKind.Constructor;
                        if (flag10)
                        {
                            text2 = text2.Substring(0, text2.LastIndexOf(".", StringComparison.Ordinal)) + ".ctor";
                        }
                    }
                    bool flag11 = this._AHG() > 0;
                    if (flag11)
                    {
                        text2 = text2 + "_" + this._AHG().ToString();
                    }
                    else
                    {
                        bool flag12 = this._AO._AHG() > 0;
                        if (flag12)
                        {
                            text2 = text2.Insert(text2.IndexOf('.'), "_" + this._AO._AHG().ToString());
                        }
                    }
                    text = text2;
                }
            }
            return text;
        }

        // Token: 0x06000600 RID: 1536 RVA: 0x000DB8D8 File Offset: 0x000D9AD8
        protected int IndexOfTypeParameter(_bd7 tp)
        {
            List<_bd7> list = this.GetTypeParameters();
            int num = ((list != null) ? list.IndexOf(tp) : (-1));
            bool flag = num < 0;
            int num2;
            if (flag)
            {
                num2 = ((this._AO != null) ? this._AO.IndexOfTypeParameter(tp) : (-1));
            }
            else
            {
                for (_bh4 _AAH = this._AO; _AAH != null; _AAH = _AAH._AO)
                {
                    list = _AAH.GetTypeParameters();
                    bool flag2 = list != null;
                    if (flag2)
                    {
                        num += list.Count;
                    }
                }
                num2 = num;
            }
            return num2;
        }

        // Token: 0x06000601 RID: 1537 RVA: 0x000DB960 File Offset: 0x000D9B60
        public string _BEX()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this._AT)
            {
                case SymbolKind.Namespace:
                    stringBuilder.Append("N:");
                    stringBuilder.Append(this._AYM());
                    goto IL_01A6;
                case SymbolKind.Interface:
                case SymbolKind.Enum:
                case SymbolKind.Struct:
                case SymbolKind.Class:
                case SymbolKind.Delegate:
                    stringBuilder.Append("T:");
                    stringBuilder.Append(this._AQ());
                    goto IL_01A6;
                case SymbolKind.Field:
                case SymbolKind.ConstantField:
                    stringBuilder.Append("F:");
                    stringBuilder.Append(this._AQ());
                    goto IL_01A6;
                case SymbolKind.Property:
                    stringBuilder.Append("P:");
                    stringBuilder.Append(this._AQ());
                    goto IL_01A6;
                case SymbolKind.Event:
                    stringBuilder.Append("E:");
                    stringBuilder.Append(this._AQ());
                    goto IL_01A6;
                case SymbolKind.Indexer:
                    stringBuilder.Append("P:");
                    stringBuilder.Append(this._AO._AQ());
                    stringBuilder.Append(".Item");
                    goto IL_01A6;
                case SymbolKind.Method:
                case SymbolKind.Operator:
                    stringBuilder.Append("M:");
                    stringBuilder.Append(this._AQ());
                    goto IL_01A6;
                case SymbolKind.Constructor:
                    stringBuilder.Append("M:");
                    stringBuilder.Append(this._AO._AQ());
                    stringBuilder.Append(".#ctor");
                    goto IL_01A6;
                case SymbolKind.Destructor:
                    stringBuilder.Append("M:");
                    stringBuilder.Append(this._AO._AQ());
                    stringBuilder.Append(".Finalize");
                    goto IL_01A6;
            }
            return null;
        IL_01A6:
            List<_bm1> parameters = this.GetParameters();
            bool flag = this._AT != SymbolKind.Delegate && parameters != null && parameters.Count > 0;
            if (flag)
            {
                stringBuilder.Append("(");
                for (int i = 0; i < parameters.Count; i++)
                {
                    _bm1 _AGS = parameters[i];
                    bool flag2 = i > 0;
                    if (flag2)
                    {
                        stringBuilder.Append(",");
                    }
                    _bh4 _AAH = _AGS.TypeOf();
                    bool flag3 = _AAH._AT == SymbolKind.TypeParameter;
                    if (flag3)
                    {
                        stringBuilder.Append('`');
                        _bd7 _AHM = _AAH as _bd7;
                        int num = _AHM._AO.IndexOfTypeParameter(_AHM);
                        stringBuilder.Append(num);
                    }
                    else
                    {
                        stringBuilder.Append(_AAH._AQ());
                    }
                    _bm8 _AX = _AAH as _bm8;
                    bool flag4 = _AX != null;
                    if (flag4)
                    {
                        bool flag5 = _AX._BEY == 1;
                        if (flag5)
                        {
                            stringBuilder.Append("[]");
                        }
                        else
                        {
                            stringBuilder.Append("[0:");
                            for (int j = 1; j < _AX._BEY; j++)
                            {
                                stringBuilder.Append(",0:");
                            }
                            stringBuilder.Append("]");
                        }
                    }
                    else
                    {
                        bool flag6 = _AGS._AGL() || _AGS._AGK();
                        if (flag6)
                        {
                            stringBuilder.Append("@");
                        }
                    }
                    bool flag7 = _AGS._AWW();
                    if (flag7)
                    {
                        stringBuilder.Append("!");
                    }
                }
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        // Token: 0x06000602 RID: 1538 RVA: 0x000DBCB8 File Offset: 0x000D9EB8
        public string RelativeName(_bm6 context)
        {
            bool flag = context == null;
            string text;
            if (flag)
            {
                text = this._AYM();
            }
            else
            {
                foreach (KeyValuePair<string, _b2> keyValuePair in _bh4._ABO)
                {
                    bool flag2 = keyValuePair.Value == this;
                    if (flag2)
                    {
                        return keyValuePair.Key;
                    }
                }
                List<_bh4> list = new List<_bh4>();
                for (_bh4 _AAH = this; _AAH != null; _AAH = _AAH._AO)
                {
                    bool flag3 = _AAH is _ba7;
                    if (flag3)
                    {
                        _AAH = _AAH._AO;
                    }
                    bool flag4 = !string.IsNullOrEmpty(_AAH._AW);
                    if (flag4)
                    {
                        list.Add(_AAH);
                    }
                }
                List<_bh4> list2 = new List<_bh4>();
                for (_bm6 _AQI = context; _AQI != null; _AQI = _AQI._AMJ())
                {
                    _bc8 _APS = _AQI as _bc8;
                    bool flag5 = _APS != null;
                    if (flag5)
                    {
                        _bn1 _APR = _APS._ACV;
                        while (_APR != null && !string.IsNullOrEmpty(_APR._AW))
                        {
                            list2.Add(_APR);
                            _APR = _APR._AO as _bn1;
                        }
                        break;
                    }
                    _bj8 _BEZ = _AQI as _bj8;
                    bool flag6 = _BEZ != null;
                    if (flag6)
                    {
                        _bh4 _APX = _BEZ._ACV;
                        SymbolKind _ABY = _APX._AT;
                        SymbolKind symbolKind = _ABY;
                        if (symbolKind == SymbolKind.Interface || symbolKind - SymbolKind.Struct <= 1)
                        {
                            list2.Add(_APX);
                        }
                    }
                }
                while (list2.Count > 0 && list.Count > 0 && list2[list2.Count - 1] == list[list.Count - 1])
                {
                    list2.RemoveAt(list2.Count - 1);
                    list.RemoveAt(list.Count - 1);
                }
                bool flag7 = list.Count <= 1;
                if (flag7)
                {
                    text = this._AW;
                }
                else
                {
                    _bn1 _APR2 = null;
                    int num = list.Count;
                    while (num-- > 0)
                    {
                        _bn1 _APR3 = list[num] as _bn1;
                        bool flag8 = _APR3 == null;
                        if (flag8)
                        {
                            break;
                        }
                        _APR2 = _APR3;
                    }
                    bool flag9 = num >= 0 && _APR2 != null && _APR2._AO != null;
                    if (flag9)
                    {
                        num++;
                        string text2 = _APR2._AYM();
                        for (_bc8 _APS2 = context.EnclosingNamespaceScope(); _APS2 != null; _APS2 = _APS2._AMJ() as _bc8)
                        {
                            List<KJK> _APU = _APS2.EFI._APL;
                            int count = _APU.Count;
                            while (count-- > 0)
                            {
                                bool flag10 = _APU[count].definition._AYM() == text2;
                                if (flag10)
                                {
                                    list.RemoveRange(num, list.Count - num);
                                    goto IL_02EA;
                                }
                            }
                        }
                    }
                IL_02EA:
                    StringBuilder stringBuilder = new StringBuilder();
                    int count2 = list.Count;
                    while (count2-- > 0)
                    {
                        stringBuilder.Append(list[count2]._AW);
                        _bi5 _AAE = list[count2] as _bi5;
                        bool flag11 = _AAE != null;
                        if (flag11)
                        {
                            KJK[] _AIR = _AAE._AHH;
                            bool flag12 = _AIR != null && _AIR.Length != 0;
                            if (flag12)
                            {
                                string text3 = "<";
                                for (int i = 0; i < _AIR.Length; i++)
                                {
                                    stringBuilder.Append(text3);
                                    bool flag13 = _AIR[i] != null;
                                    if (flag13)
                                    {
                                        stringBuilder.Append(_AIR[i].definition.RelativeName(context));
                                    }
                                    text3 = ", ";
                                }
                                stringBuilder.Append('>');
                            }
                        }
                        bool flag14 = count2 > 0;
                        if (flag14)
                        {
                            stringBuilder.Append('.');
                        }
                    }
                    text = stringBuilder.ToString();
                }
            }
            return text;
        }

        // Token: 0x06000603 RID: 1539 RVA: 0x000DC0C0 File Offset: 0x000DA2C0
        public string _AYM()
        {
            bool flag = this._AO != null;
            string text2;
            if (flag)
            {
                string text = ((this._AO is _ba7) ? (this._AO._AO ?? _bh4._AAA)._AYM() : this._AO._AYM());
                bool flag2 = string.IsNullOrEmpty(this._AW);
                if (flag2)
                {
                    text2 = text;
                }
                else
                {
                    bool flag3 = string.IsNullOrEmpty(text);
                    if (flag3)
                    {
                        text2 = this._AW;
                    }
                    else
                    {
                        text2 = text + "." + this._AW;
                    }
                }
            }
            else
            {
                text2 = this._AW;
            }
            return text2;
        }

        // Token: 0x06000604 RID: 1540 RVA: 0x000DC158 File Offset: 0x000DA358
        public string _AQ()
        {
            bool flag = this._AO != null;
            string text2;
            if (flag)
            {
                string text = ((this._AO is _ba7) ? (this._AO._AO ?? _bh4._AAA)._AQ() : this._AO._AQ());
                bool flag2 = string.IsNullOrEmpty(this._AP());
                if (flag2)
                {
                    text2 = text;
                }
                else
                {
                    bool flag3 = string.IsNullOrEmpty(text);
                    if (flag3)
                    {
                        text2 = this._AP();
                    }
                    else
                    {
                        text2 = text + "." + this._AP();
                    }
                }
            }
            else
            {
                text2 = this._AP();
            }
            return text2;
        }

        // Token: 0x06000605 RID: 1541 RVA: 0x000DC1F0 File Offset: 0x000DA3F0
        public string Dump()
        {
            StringBuilder stringBuilder = new StringBuilder();
            this.Dump(stringBuilder, string.Empty);
            return stringBuilder.ToString();
        }

        // Token: 0x06000606 RID: 1542 RVA: 0x000DC21C File Offset: 0x000DA41C
        protected virtual void Dump(StringBuilder sb, string indent)
        {
            string[] array = new string[7];
            array[0] = indent;
            array[1] = this._AT.ToString();
            array[2] = " ";
            array[3] = this._AW;
            array[4] = " (";
            int num = 5;
            Type type = base.GetType();
            array[num] = ((type != null) ? type.ToString() : null);
            array[6] = ")";
            sb.AppendLine(string.Concat(array));
            for (int i = 0; i < this._AAG.Count; i++)
            {
                this._AAG._AAI(i).Dump(sb, indent + "  ");
            }
        }

        // Token: 0x06000607 RID: 1543 RVA: 0x000DC2C4 File Offset: 0x000DA4C4
        internal virtual void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            leaf._ACY(null);
            string text = _bh4.DecodeId(leaf._ACX.text);
            _bh4 _AAH;
            bool flag = !this._AAG.TryGetValue(text, numTypeArgs, out _AAH);
            if (!flag)
            {
                bool flag2 = _AAH != null && _AAH._AT != SymbolKind.Namespace && !(_AAH is _b2);
                if (flag2)
                {
                    if (asTypeOnly)
                    {
                        return;
                    }
                    bool flag3 = leaf.OOME != null && leaf.OOME._AHB() == "typeOrGeneric";
                    if (flag3)
                    {
                        leaf._AJF = "Type expected";
                    }
                }
                leaf._ACY(_AAH);
            }
        }

        // Token: 0x06000608 RID: 1544 RVA: 0x000DC368 File Offset: 0x000DA568
        internal virtual void ResolveAttributeMember(_bb4.DHBA leaf, _bm6 context)
        {
            leaf._ACY(null);
            leaf._AJF = null;
            string text = leaf._ACX.text;
            leaf._ACY(this.FindName(text, 0, true) ?? this.FindName(text + "Attribute", 0, true));
        }

        // Token: 0x06000609 RID: 1545 RVA: 0x000DC3B8 File Offset: 0x000DA5B8
        internal virtual _bh4 ResolveMethodOverloads(_bb4._ACW argumentListNode, KJK[] typeArgs, _bm6 scope, _bb4.DHBA invokedLeaf)
        {
            throw new InvalidOperationException();
        }

        // Token: 0x0600060A RID: 1546 RVA: 0x000DC3C0 File Offset: 0x000DA5C0
        public static Dictionary<string, List<_bb3>> _BFA()
        {
            bool flag = _bh4._BFB == null;
            if (flag)
            {
                _bh4._BFB = new Dictionary<string, List<_bb3>>();
                _bh4._BFB["op_Addition"] = new List<_bb3>
                {
                    _bb3.CreateOperator("op_Addition", _bh4._AAQ, _bh4._AAQ, _bh4._AAQ),
                    _bb3.CreateOperator("op_Addition", _bh4._AAU, _bh4._AAU, _bh4._AAU),
                    _bb3.CreateOperator("op_Addition", _bh4._AAR, _bh4._AAR, _bh4._AAR),
                    _bb3.CreateOperator("op_Addition", _bh4._AAV, _bh4._AAV, _bh4._AAV),
                    _bb3.CreateOperator("op_Addition", _bh4._AAS, _bh4._AAS, _bh4._AAS),
                    _bb3.CreateOperator("op_Addition", _bh4._AAT, _bh4._AAT, _bh4._AAT),
                    _bb3.CreateOperator("op_Addition", _bh4._BFC, _bh4._BFC, _bh4._BFC),
                    _bb3.CreateOperator("op_Addition", _bh4._BFD, _bh4._BFD, _bh4._BFD),
                    _bb3.CreateOperator("op_Addition", _bh4._BFD, _bh4._BFD, _bh4._AS),
                    _bb3.CreateOperator("op_Addition", _bh4._BFD, _bh4._AS, _bh4._BFD)
                };
                _bh4._BFB["op_Subtraction"] = new List<_bb3>
                {
                    _bb3.CreateOperator("op_Subtraction", _bh4._AAQ, _bh4._AAQ, _bh4._AAQ),
                    _bb3.CreateOperator("op_Subtraction", _bh4._AAU, _bh4._AAU, _bh4._AAU),
                    _bb3.CreateOperator("op_Subtraction", _bh4._AAR, _bh4._AAR, _bh4._AAR),
                    _bb3.CreateOperator("op_Subtraction", _bh4._AAV, _bh4._AAV, _bh4._AAV),
                    _bb3.CreateOperator("op_Subtraction", _bh4._AAS, _bh4._AAS, _bh4._AAS),
                    _bb3.CreateOperator("op_Subtraction", _bh4._AAT, _bh4._AAT, _bh4._AAT),
                    _bb3.CreateOperator("op_Subtraction", _bh4._BFC, _bh4._BFC, _bh4._BFC)
                };
            }
            return _bh4._BFB;
        }

        // Token: 0x0600060B RID: 1547 RVA: 0x000DC63C File Offset: 0x000DA83C
        private static _bh4 ResolveExpression(string operatorMethodName, _bh4 lhs, _bh4 rhs)
        {
            _b2 _AAC = lhs.TypeOf() as _b2;
            _b2 _AAC2 = rhs.TypeOf() as _b2;
            int count = _ba7._AGX.Count;
            List<_b2> _BFE = _ba7._AGW;
            List<_bh4> _BFF = _ba7._AGX;
            List<Modifiers> _AWU = _ba7._AGV;
            _BFE.Add(_AAC);
            _BFE.Add(_AAC2);
            _BFF.Add(lhs);
            _BFF.Add(rhs);
            _AWU.Add(Modifiers.None);
            _AWU.Add(Modifiers.None);
            _ba7._AGY.Add(null);
            _ba7._AGY.Add(null);
            List<_bb3> _APT = _ba7._AHE;
            int count2 = _APT.Count;
            int num = 0;
            _b2 _AAC3 = _BFE[count];
            while (num == 0 && _AAC3 != null)
            {
                _ba7 _AAK = _AAC3.FindName(operatorMethodName, 0, false) as _ba7;
                bool flag = _AAK != null;
                if (flag)
                {
                    num = _AAK.CollectCandidates(2, null, null);
                    bool flag2 = num > 0;
                    if (flag2)
                    {
                        int num2 = num;
                        while (num2-- > 0)
                        {
                            _bb3 _AAN = _APT[count2 + num2];
                            bool flag3 = !_BFE[count].CanConvertTo(_AAN._AIK[0].TypeOf() as _b2) || !_BFE[count + 1].CanConvertTo(_AAN._AIK[1].TypeOf() as _b2);
                            if (flag3)
                            {
                                _APT.RemoveAt(count2 + num2);
                            }
                        }
                        num = _APT.Count - count2;
                    }
                }
                _AAC3 = _AAC3.BaseType();
            }
            int count3 = _APT.Count;
            int num3 = 0;
            _AAC3 = _BFE[count + 1];
            while (num3 == 0 && _AAC3 != null)
            {
                _ba7 _AAK2 = _AAC3.FindName(operatorMethodName, 0, false) as _ba7;
                bool flag4 = _AAK2 != null;
                if (flag4)
                {
                    num3 = _AAK2.CollectCandidates(2, null, null);
                    bool flag5 = num3 != 0;
                    if (flag5)
                    {
                        int num4 = num3;
                        while (num4-- > 0)
                        {
                            _bb3 _AAN2 = _APT[count3 + num4];
                            bool flag6 = !_BFE[count].CanConvertTo(_AAN2._AIK[0].TypeOf() as _b2) || !_BFE[count + 1].CanConvertTo(_AAN2._AIK[1].TypeOf() as _b2);
                            if (flag6)
                            {
                                _APT.RemoveAt(count3 + num4);
                            }
                        }
                        num3 = _APT.Count - count3;
                    }
                }
                _AAC3 = _AAC3.BaseType();
            }
            num += num3;
            bool flag7 = num == 0;
            if (flag7)
            {
                List<_bb3> list;
                bool flag8 = !_bh4._BFA().TryGetValue(operatorMethodName, out list);
                if (flag8)
                {
                    Debug.LogError("Unknown predefined operator name: " + operatorMethodName);
                    _bh4 thisInstance = _BFE[0].GetThisInstance();
                    _AWU.RemoveRange(count, 2);
                    _BFE.RemoveRange(count, 2);
                    _BFF.RemoveRange(count, 2);
                    _ba7._AGY.RemoveRange(count, 2);
                    return thisInstance;
                }
                num = list.Count;
                _APT.AddRange(list);
            }
            _bb3 _AAN3 = _ba7.ResolveMethodOverloads(2, num);
            _APT.RemoveRange(count2, _APT.Count - count2);
            _AWU.RemoveRange(count, 2);
            _BFE.RemoveRange(count, 2);
            _BFF.RemoveRange(count, 2);
            _ba7._AGY.RemoveRange(count, 2);
            _b2 _AAC4 = _AAN3.ReturnType();
            return (_AAC4 == null) ? null : _AAC4.GetThisInstance();
        }

        // Token: 0x0600060C RID: 1548 RVA: 0x000DC9EC File Offset: 0x000DABEC
        public static _bh4 ResolveNodeAsConstructor(_bb4._AIN oceNode, _bm6 scope, _bh4 asMemberOf)
        {
            bool flag = asMemberOf == null;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                _bb4._ACW _AGZ = oceNode as _bb4._ACW;
                bool flag2 = _AGZ == null || _AGZ._AIX == 0;
                if (flag2)
                {
                    _AAH = null;
                }
                else
                {
                    _bb4._ACW _AGZ2 = ((_AGZ._AHB() == "arguments") ? _AGZ : _AGZ.NodeAt(0));
                    bool flag3 = _AGZ2 == null;
                    if (flag3)
                    {
                        _AAH = null;
                    }
                    else
                    {
                        _bh4 _AAH2 = asMemberOf.FindName(".ctor", 0, false);
                        bool flag4 = _AAH2 == null || _AAH2._AO != asMemberOf;
                        if (flag4)
                        {
                            _AAH2 = ((_b2)asMemberOf).GetDefaultConstructor();
                        }
                        bool flag5 = _AAH2 is _ba7;
                        if (flag5)
                        {
                            bool flag6 = _AGZ2._AHB() == "arguments";
                            if (flag6)
                            {
                                _AAH2 = _bh4.ResolveNode(_AGZ2, scope, _AAH2, 0, false);
                            }
                        }
                        else
                        {
                            bool flag7 = _AGZ2._AHB() == "arguments";
                            if (flag7)
                            {
                                for (int i = 1; i < (int)(_AGZ2._AIX - 1); i++)
                                {
                                    _bh4.ResolveNode(_AGZ2.ChildAt(i), scope, _AAH2, 0, false);
                                }
                            }
                        }
                        bool flag8 = _AGZ._AHB() != "arguments" && _AGZ._AIX == 2;
                        if (flag8)
                        {
                            _bh4.ResolveNode(_AGZ.ChildAt(1), null, null, 0, false);
                        }
                        _AAH = _AAH2;
                    }
                }
            }
            return _AAH;
        }

        // Token: 0x0600060D RID: 1549 RVA: 0x000DCB48 File Offset: 0x000DAD48
        public static _bh4 EnumerableElementType(_bb4._ACW node)
        {
            _bh4 _AAH = _bh4.ResolveNode(node, null, null, 0, false);
            bool flag = _AAH != null;
            if (flag)
            {
                _bm8 _AX = _AAH.TypeOf() as _bm8;
                bool flag2 = _AX != null;
                if (flag2)
                {
                    bool flag3 = _AX._BEY > 0 && _AX._AHP != null;
                    if (flag3)
                    {
                        return _AX._AHP.definition;
                    }
                }
                else
                {
                    _b2 _AAC = _AAH.TypeOf() as _b2;
                    bool flag4 = _AAC != null;
                    if (flag4)
                    {
                        _b2 _BFI = _bh4._BFJ;
                        bool flag5 = _AAC.DerivesFromRef(ref _BFI);
                        if (flag5)
                        {
                            _bi5 _AAE = _BFI as _bi5;
                            bool flag6 = _AAE != null;
                            if (flag6)
                            {
                                return _AAE._AHH[0].definition;
                            }
                        }
                        _bc6 _BFK = _bh4._BFL;
                        bool flag7 = _AAC.DerivesFrom(_BFK);
                        if (flag7)
                        {
                            return _bh4._AS;
                        }
                    }
                }
            }
            return _bh4._AHA;
        }

        // Token: 0x0600060E RID: 1550 RVA: 0x000DCC38 File Offset: 0x000DAE38
        private static _bh4 ResolveArgumentsNode(_bb4._ACW argumentsNode, _bm6 scope, _bb4.DHBA invokedLeaf, _bh4 invokedSymbol, _bh4 memberOf)
        {
            _bh4 _AAH = null;
            invokedSymbol = invokedSymbol ?? invokedLeaf._AAB();
            _bb4._ACW _AGZ = ((argumentsNode != null && argumentsNode._AIX >= 2) ? argumentsNode.NodeAt(1) : null);
            KJK[] array = null;
            bool flag = invokedSymbol._AT == SymbolKind.MethodGroup;
            if (flag)
            {
                bool flag2 = invokedLeaf != null && array == null;
                if (flag2)
                {
                    _bb4._ACW _AMI = invokedLeaf.OOME;
                    bool flag3 = _AMI != null;
                    if (flag3)
                    {
                        _bb4._ACW _AGZ2 = null;
                        bool flag4 = _AMI._AHB() == "accessIdentifier";
                        if (flag4)
                        {
                            _AGZ2 = _AMI.NodeAt(2);
                        }
                        else
                        {
                            bool flag5 = _AMI._AHB() == "primaryExpressionStart";
                            if (flag5)
                            {
                                _AGZ2 = _AMI.NodeAt(1);
                            }
                        }
                        bool flag6 = _AGZ2 != null && _AGZ2._AHB() == "typeArgumentList";
                        if (flag6)
                        {
                            int num = (int)(_AGZ2._AIX / 2);
                            array = new KJK[num];
                            for (int i = 0; i < num; i++)
                            {
                                array[i] = new KJK(_AGZ2.ChildAt(1 + 2 * i));
                            }
                        }
                    }
                }
                _AAH = invokedSymbol.ResolveMethodOverloads(_AGZ, array, scope, invokedLeaf);
                _bh4 _AAH2 = invokedSymbol;
                while (_AAH2 != null && !(_AAH2 is _b2))
                {
                    _AAH2 = _AAH2._AO;
                }
                while (_AAH == _ba7._AHN && _AAH2 != null)
                {
                    _AAH2 = (_AAH2 as _b2).BaseType();
                    bool flag7 = _AAH2 != null;
                    if (flag7)
                    {
                        _bh4 _AAH3 = _AAH2.FindName(invokedSymbol._AW, 0, false);
                        bool flag8 = _AAH3 != null && _AAH3._AT == SymbolKind.MethodGroup;
                        if (flag8)
                        {
                            _AAH = _AAH3.ResolveMethodOverloads(_AGZ, array, scope, invokedLeaf);
                        }
                    }
                }
                bool flag9 = _AAH != null && _AAH._AT == SymbolKind.Method && !(_AAH is _bb3);
                if (flag9)
                {
                    _AAH = _AAH as _bm7;
                }
                bool flag10 = _AAH != null && _AAH._AT != SymbolKind.Error;
                if (flag10)
                {
                    _bb4._ACW _AGZ3 = ((argumentsNode != null) ? (argumentsNode.OOME.FindPreviousNode() as _bb4._ACW) : null);
                    _bb4.DHBA _AEM = ((_AGZ3 != null) ? (_AGZ3.LeafAt(0) ?? _AGZ3.NodeAt(0).LeafAt(1)) : invokedLeaf);
                    bool flag11 = _AAH._AT == SymbolKind.Error;
                    if (flag11)
                    {
                        _AEM._ACY(invokedSymbol as _ba7);
                        _AEM._AJF = _AAH._AW;
                    }
                    else
                    {
                        bool flag12 = _AEM._AAB() != _AAH;
                        if (flag12)
                        {
                            _AEM._ACY(_AAH);
                            _AEM._AJF = null;
                            bool flag13 = _AGZ != null;
                            if (flag13)
                            {
                                _bh4.ReResolveImplicitlyTypedArguments(_AGZ);
                            }
                        }
                    }
                    return _AAH;
                }
            }
            bool flag14 = memberOf != null && !(memberOf is _b2);
            if (flag14)
            {
                bool flag15 = invokedLeaf != null && array == null;
                if (flag15)
                {
                    _bb4._ACW _AMI2 = invokedLeaf.OOME;
                    bool flag16 = _AMI2 != null;
                    if (flag16)
                    {
                        _bb4._ACW _AGZ4 = null;
                        bool flag17 = _AMI2._AHB() == "accessIdentifier";
                        if (flag17)
                        {
                            _AGZ4 = _AMI2.NodeAt(2);
                        }
                        else
                        {
                            bool flag18 = _AMI2._AHB() == "primaryExpressionStart";
                            if (flag18)
                            {
                                _AGZ4 = _AMI2.NodeAt(1);
                            }
                        }
                        bool flag19 = _AGZ4 != null && _AGZ4._AHB() == "typeArgumentList";
                        if (flag19)
                        {
                            bool flag20 = _AGZ4 != null;
                            if (flag20)
                            {
                                int num2 = (int)(_AGZ4._AIX / 2);
                                array = new KJK[num2];
                                for (int j = 0; j < num2; j++)
                                {
                                    array[j] = new KJK(_AGZ4.ChildAt(1 + 2 * j));
                                }
                            }
                        }
                    }
                }
                _b2 _AAC = (memberOf.TypeOf() as _b2) ?? scope.EnclosingType();
                _AAH = scope.ResolveAsExtensionMethod(invokedLeaf, invokedSymbol, _AAC, _AGZ, array, scope);
                bool flag21 = _AAH != null && _AAH._AT == SymbolKind.Method && !(_AAH is _bb3);
                if (flag21)
                {
                    _AAH = _AAH as _bm7;
                }
                bool flag22 = _AAH != null;
                if (flag22)
                {
                    bool flag23 = _AAH._AT == SymbolKind.Error;
                    if (flag23)
                    {
                        invokedLeaf._ACY(_AAH);
                        invokedLeaf._AJF = _AAH._AW;
                    }
                    else
                    {
                        bool flag24 = invokedLeaf._AAB() != _AAH;
                        if (flag24)
                        {
                            invokedLeaf._ACY(_AAH);
                            invokedLeaf._AJF = null;
                            bool flag25 = _AGZ != null;
                            if (flag25)
                            {
                                _bh4.ReResolveImplicitlyTypedArguments(_AGZ);
                            }
                        }
                    }
                    invokedSymbol = _AAH;
                }
            }
            bool flag26 = invokedSymbol._AT != SymbolKind.Method && invokedSymbol._AT != SymbolKind.Error;
            if (flag26)
            {
                _b2 _AAC2 = invokedSymbol.TypeOf() as _b2;
                bool flag27 = _AAC2 == null || _AAC2._AT == SymbolKind.Error;
                if (flag27)
                {
                    return _bh4._AHA;
                }
                _b2 _AAC3 = ((invokedSymbol._AT == SymbolKind.Delegate) ? _AAC2 : ((_AAC2._AT == SymbolKind.Delegate) ? (_AAC2.TypeOf() as _b2) : null));
                bool flag28 = _AAC3 != null;
                if (flag28)
                {
                    return _AAC3.GetThisInstance();
                }
                bool flag29 = invokedLeaf != null;
                if (flag29)
                {
                    invokedLeaf._AJF = "Cannot invoke symbol";
                }
            }
            return _AAH;
        }

        // Token: 0x0600060F RID: 1551 RVA: 0x000DD148 File Offset: 0x000DB348
        private static void ReResolveImplicitlyTypedArguments(_bb4._ACW argumentListNode)
        {
            for (int i = 0; i < (int)argumentListNode._AIX; i += 2)
            {
                _bb4._ACW _AGZ = argumentListNode.NodeAt(i);
                bool flag = _AGZ == null;
                if (!flag)
                {
                    _bb4._ACW _AGZ2 = _AGZ.NodeAt(-1);
                    bool flag2 = _AGZ2 == null;
                    if (!flag2)
                    {
                        _bb4._ACW _AGZ3 = _AGZ2.NodeAt(0);
                        bool flag3 = _AGZ3 == null || _AGZ3._AHB() != "expression";
                        if (!flag3)
                        {
                            _bb4._ACW _AGZ4 = _AGZ3.NodeAt(0);
                            bool flag4 = _AGZ4 == null || _AGZ4._AHB() != "nonAssignmentExpression";
                            if (!flag4)
                            {
                                _bb4._ACW _AGZ5 = _AGZ4.NodeAt(0);
                                bool flag5 = _AGZ5 == null || _AGZ5._AHB() != "lambdaExpression";
                                if (!flag5)
                                {
                                    _bb4._ACW _AGZ6 = _AGZ5.NodeAt(0);
                                    bool flag6 = _AGZ6 == null;
                                    if (!flag6)
                                    {
                                        _bb4._ACW _AGZ7 = _AGZ6.NodeAt(0);
                                        bool flag7 = _AGZ7 != null;
                                        if (flag7)
                                        {
                                            _bb4.DHBA _AEM = _AGZ7.LeafAt(0);
                                            bool flag8 = _AEM == null;
                                            if (!flag8)
                                            {
                                                _bn3 _BFM = _AEM._AAB() as _bn3;
                                                bool flag9 = _BFM == null;
                                                if (!flag9)
                                                {
                                                    _BFM.BLH = null;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            _bb4._ACW _AGZ8 = _AGZ6.NodeAt(1);
                                            bool flag10 = _AGZ7 == null;
                                            if (!flag10)
                                            {
                                                for (int j = 0; j < (int)_AGZ8._AIX; j += 2)
                                                {
                                                    _AGZ7 = _AGZ8.NodeAt(j);
                                                    bool flag11 = _AGZ7 == null;
                                                    if (!flag11)
                                                    {
                                                        _bb4.DHBA _AEM2 = _AGZ7.LeafAt(0);
                                                        bool flag12 = _AEM2 == null;
                                                        if (!flag12)
                                                        {
                                                            _bn3 _BFM2 = _AEM2._AAB() as _bn3;
                                                            bool flag13 = _BFM2 == null;
                                                            if (!flag13)
                                                            {
                                                                _BFM2.BLH = null;
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

        // Token: 0x06000610 RID: 1552 RVA: 0x000DD324 File Offset: 0x000DB524
        public static _bh4 ResolveNode(_bb4._AIN baseNode, _bm6 scope = null, _bh4 asMemberOf = null, int numTypeArguments = 0, bool asTypeOnly = false)
        {
            _bb4._ACW _AGZ = baseNode as _bb4._ACW;
            bool flag = scope == null;
            if (flag)
            {
                _bb4._ACW _AGZ2 = _AGZ;
                while (_AGZ2 != null && _AGZ2.OOME != null)
                {
                    string text = _AGZ2._AHB();
                    bool flag2 = text == "type" && _AGZ2._AIL == 2;
                    if (flag2)
                    {
                        _bb4._ACW _AGZ3 = _AGZ2.OOME.NodeAt(3);
                        bool flag3 = _AGZ3 != null && (_AGZ3._AHB() == "methodDeclaration" || _AGZ3._AHB() == "interfaceMethodDeclaration");
                        if (flag3)
                        {
                            scope = _AGZ3._AJW;
                            break;
                        }
                    }
                    bool flag4 = text != "type" && text != "typeName" && text != "namespaceOrTypeName" && text != "typeOrGeneric" && text != "typeArgumentList";
                    if (flag4)
                    {
                        break;
                    }
                    _AGZ2 = _AGZ2.OOME;
                }
            }
            bool flag5 = scope == null;
            if (flag5)
            {
                _bb4._ACW _AGZ4 = _bm2.EnclosingSemanticNode(baseNode, _bc1.ScopesMask);
                while (_AGZ4 != null && _AGZ4._AJW == null && _AGZ4.OOME != null)
                {
                    _AGZ4 = _bm2.EnclosingSemanticNode(_AGZ4.OOME, _bc1.ScopesMask);
                }
                bool flag6 = _AGZ4 != null;
                if (flag6)
                {
                    scope = _AGZ4._AJW;
                }
            }
            _bb4.DHBA _AEM = baseNode as _bb4.DHBA;
            bool flag7 = _AEM != null;
            _bh4 _AAH;
            if (flag7)
            {
                bool flag8 = (_AEM._AAB() == null || _AEM._AJF != null || _AEM._AAB()._AT == SymbolKind.Method || !_AEM._AAB().IsValid()) && _AEM._ACX != null;
                if (flag8)
                {
                    _AEM._ACY(null);
                    _AEM._AJF = null;
                    switch (_AEM._ACX.tokenKind)
                    {
                        case SyntaxToken.Kind.Missing:
                            return null;
                        case SyntaxToken.Kind.VerbatimStringLiteral:
                        case SyntaxToken.Kind.VerbatimStringBegin:
                        case SyntaxToken.Kind.StringLiteral:
                        case SyntaxToken.Kind.InterpolatedStringWholeLiteral:
                        case SyntaxToken.Kind.InterpolatedStringEndLiteral:
                            _AEM._ACY(_bh4._BFD.GetThisInstance());
                            goto IL_0A1E;
                        case SyntaxToken.Kind.BuiltInLiteral:
                            _AEM._ACY((_AEM._ACX.text == "null") ? _bh4._BFO : _bh4._BFP.GetThisInstance());
                            goto IL_0A1E;
                        case SyntaxToken.Kind.CharLiteral:
                            _AEM._ACY(_bh4._ABA.GetThisInstance());
                            goto IL_0A1E;
                        case SyntaxToken.Kind.InterpolatedStringStartLiteral:
                        case SyntaxToken.Kind.InterpolatedStringMidLiteral:
                        case SyntaxToken.Kind.InterpolatedStringFormatLiteral:
                            _AEM._ACY(_bh4._BFD.GetThisInstance());
                            goto IL_0A1E;
                        case SyntaxToken.Kind.IntegerLiteral:
                            {
                                char c = _AEM._ACX.text[_AEM._ACX.text.Length - 1];
                                bool flag9 = c == 'u' || c == 'U';
                                bool flag10 = c == 'l' || c == 'L';
                                bool flag11 = flag9;
                                if (flag11)
                                {
                                    c = _AEM._ACX.text[_AEM._ACX.text.Length - 2];
                                    flag10 = c == 'l' || c == 'L';
                                }
                                else
                                {
                                    bool flag12 = flag10;
                                    if (flag12)
                                    {
                                        c = _AEM._ACX.text[_AEM._ACX.text.Length - 2];
                                        flag9 = c == 'u' || c == 'U';
                                    }
                                }
                                bool flag13 = flag10 || flag9;
                                if (flag13)
                                {
                                    _AEM._ACY((flag10 ? (flag9 ? _bh4._AAV : _bh4._AAR) : _bh4._AAU).GetThisInstance());
                                }
                                else
                                {
                                    _AEM._ACY(_bi3.FromText(_AEM._ACX.text));
                                }
                                goto IL_0A1E;
                            }
                        case SyntaxToken.Kind.RealLiteral:
                            {
                                char c = _AEM._ACX.text[_AEM._ACX.text.Length - 1];
                                _AEM._ACY((c == 'f' || c == 'F') ? _bh4._AAS.GetThisInstance() : ((c == 'm' || c == 'M') ? _bh4._BFC.GetThisInstance() : _bh4._AAT.GetThisInstance()));
                                goto IL_0A1E;
                            }
                        case SyntaxToken.Kind.Punctuator:
                            return null;
                        case SyntaxToken.Kind.Keyword:
                            {
                                bool flag14 = _AEM._ACX.text == "this" || _AEM._ACX.text == "base";
                                if (!flag14)
                                {
                                    _b2 _AAC;
                                    bool flag15 = _bh4._ABO.TryGetValue(_AEM._ACX.text, out _AAC);
                                    if (flag15)
                                    {
                                        _AEM._ACY(_AAC);
                                    }
                                    goto IL_0A1E;
                                }
                                _bb4._ACW _AGZ5 = _bm2.EnclosingScopeNode(_AEM.OOME, _bc1.MethodBodyScope, _bc1.AccessorBodyScope);
                                bool flag16 = _AGZ5 == null;
                                if (flag16)
                                {
                                    bool flag17 = _AEM._AIL == 1 && _AEM.OOME._AHB() == "constructorInitializer";
                                    if (flag17)
                                    {
                                        _bj8 _BEZ = scope._AMJ()._AMJ() as _bj8;
                                        bool flag18 = _BEZ == null;
                                        if (!flag18)
                                        {
                                            asMemberOf = _BEZ._ACV;
                                            bool flag19 = asMemberOf._AT != SymbolKind.Class && asMemberOf._AT != SymbolKind.Struct;
                                            if (!flag19)
                                            {
                                                bool flag20 = _AEM._ACX.text == "base";
                                                if (flag20)
                                                {
                                                    bool flag21 = asMemberOf._AT == SymbolKind.Struct;
                                                    if (flag21)
                                                    {
                                                        goto IL_0A1E;
                                                    }
                                                    asMemberOf = ((_b2)asMemberOf).BaseType();
                                                }
                                                _AEM._ACY(_bh4.ResolveNodeAsConstructor(_AEM.OOME.NodeAt(2), scope, asMemberOf));
                                            }
                                        }
                                    }
                                    goto IL_0A1E;
                                }
                                _bj8 _BEZ2 = _AGZ5._AJW as _bj8;
                                bool flag22 = _BEZ2 != null && _BEZ2._ACV.IsStatic;
                                if (flag22)
                                {
                                    bool flag23 = _AEM._ACX.text == "base";
                                    if (flag23)
                                    {
                                        _AEM._ACY(_bh4._BFQ);
                                    }
                                    else
                                    {
                                        _AEM._ACY(_bh4._BFR);
                                    }
                                    goto IL_0A1E;
                                }
                                _AGZ5 = _bm2.EnclosingScopeNode(_AGZ5, _bc1.TypeDeclarationScope);
                                bool flag24 = _AGZ5 == null;
                                if (flag24)
                                {
                                    _AEM._ACY(_bh4._AAA);
                                    goto IL_0A1E;
                                }
                                _b2 _AAC2 = ((_bn4)_AGZ5._AJW).EFI._ACV as _b2;
                                bool flag25 = _AAC2 != null && _AEM._ACX.text == "base";
                                if (flag25)
                                {
                                    _AAC2 = _AAC2.BaseType();
                                }
                                bool flag26 = _AAC2 != null && (_AAC2._AT == SymbolKind.Struct || _AAC2._AT == SymbolKind.Class);
                                if (flag26)
                                {
                                    _AEM._ACY(_AAC2.GetThisInstance());
                                }
                                else
                                {
                                    _AEM._ACY(_bh4._AAA);
                                }
                                goto IL_0A1E;
                            }
                        case SyntaxToken.Kind.Identifier:
                            {
                                bool flag27 = asMemberOf != null;
                                if (flag27)
                                {
                                    asMemberOf.ResolveMember(_AEM, scope, numTypeArguments, asTypeOnly);
                                    bool flag28 = asTypeOnly && _AEM._AAB() == null;
                                    if (flag28)
                                    {
                                        asMemberOf.ResolveMember(_AEM, scope, numTypeArguments, false);
                                        bool flag29 = _AEM._AAB() != null && _AEM._AAB()._AT != SymbolKind.Error;
                                        if (flag29)
                                        {
                                            _AEM._AJF = "Type expected!";
                                        }
                                    }
                                }
                                else
                                {
                                    bool flag30 = scope != null;
                                    if (flag30)
                                    {
                                        bool flag31 = _AEM._ACX.text == "global";
                                        if (flag31)
                                        {
                                            _bb4.DHBA _AEM2 = _AEM.FindNextLeaf();
                                            bool flag32 = _AEM2 != null && _AEM2.IsLit("::");
                                            if (flag32)
                                            {
                                                _bj5 assembly = scope.GetAssembly();
                                                bool flag33 = assembly != null;
                                                if (flag33)
                                                {
                                                    _AEM._ACY(scope.GetAssembly()._AWL());
                                                    return _AEM._AAB();
                                                }
                                            }
                                        }
                                        scope.Resolve(_AEM, numTypeArguments, asTypeOnly);
                                        bool flag34 = _AEM._AAB() == null;
                                        if (flag34)
                                        {
                                            if (asTypeOnly)
                                            {
                                                scope.Resolve(_AEM, numTypeArguments, false);
                                                bool flag35 = _AEM._AAB() != null && _AEM._AAB()._AT != SymbolKind.Error;
                                                if (flag35)
                                                {
                                                    _AEM._AJF = "Type expected!";
                                                }
                                            }
                                            else
                                            {
                                                bool flag36 = !_bd5._AHR && _AEM._ACX.text == "nameof" && _AEM.OOME != null;
                                                if (flag36)
                                                {
                                                    _bb4._ACW _AGZ6 = _AEM.OOME._AIZ as _bb4._ACW;
                                                    bool flag37 = _AGZ6 != null;
                                                    if (flag37)
                                                    {
                                                        _bb4._ACW _AGZ7 = _AGZ6._AJA() as _bb4._ACW;
                                                        bool flag38 = _AGZ7 != null && _AGZ7._AHB() == "arguments";
                                                        if (flag38)
                                                        {
                                                            _AEM._ACX.tokenKind = SyntaxToken.Kind.Keyword;
                                                            _AEM._ACY(_bh4._BFD.GetThisInstance());
                                                            return _AEM._AAB();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                bool flag39 = _AEM._AAB() == null;
                                if (flag39)
                                {
                                    bool flag40 = asMemberOf != null;
                                    if (flag40)
                                    {
                                        asMemberOf.ResolveMember(_AEM, scope, -1, asTypeOnly);
                                    }
                                    else
                                    {
                                        bool flag41 = scope != null;
                                        if (flag41)
                                        {
                                            scope.Resolve(_AEM, -1, asTypeOnly);
                                        }
                                    }
                                }
                                bool flag42 = _AEM._AAB() != null && _AEM._AAB()._AHG() != numTypeArguments && _AEM._AAB()._AT != SymbolKind.Error;
                                if (flag42)
                                {
                                    bool flag43 = _AEM._AAB() is _b2;
                                    if (flag43)
                                    {
                                        bool flag44 = !(_AEM._AAB() is _bi5);
                                        if (flag44)
                                        {
                                            _AEM._AJF = string.Format("Type '{0}' does not take {1} type argument{2}", _AEM._AAB().GetName(), numTypeArguments, (numTypeArguments == 1) ? "" : "s");
                                        }
                                    }
                                    else
                                    {
                                        bool flag45 = numTypeArguments > 0 && _AEM._AAB()._AT == SymbolKind.Method;
                                        if (flag45)
                                        {
                                            _AEM._AJF = string.Format("Method '{0}' does not take {1} type argument{2}", _AEM._ACX.text, numTypeArguments, (numTypeArguments == 1) ? "" : "s");
                                        }
                                    }
                                }
                                goto IL_0A1E;
                            }
                        case SyntaxToken.Kind.ContextualKeyword:
                            return null;
                    }
                    Debug.LogWarning(_AEM.ToString());
                    return null;
                IL_0A1E:
                    bool flag46 = _AEM._AAB() == null;
                    if (flag46)
                    {
                        _AEM._ACY(_bh4._AAA);
                    }
                    bool flag47 = _AEM._AJF == null && _AEM._AAB()._AT == SymbolKind.Error;
                    if (flag47)
                    {
                        _AEM._AJF = _AEM._AAB()._AW;
                    }
                }
                _AAH = _AEM._AAB();
            }
            else
            {
                bool flag48 = _AGZ == null || _AGZ._AIX == 0 || _AGZ._AJC;
                if (flag48)
                {
                    _AAH = null;
                }
                else
                {
                    _bh4 _AAH2 = null;
                    _bh4 _AAH3 = null;
                    string text2 = _AGZ._AHB();
                    string text3 = text2;
                    uint num = Helper.ComputeStringHash(text3);
                    _bh4 _AAH25;
                    FKI _AFF;
                    if (num <= 2003406594U)
                    {
                        if (num <= 839436841U)
                        {
                            if (num <= 307867620U)
                            {
                                if (num <= 210866085U)
                                {
                                    if (num <= 136495084U)
                                    {
                                        if (num != 24260860U)
                                        {
                                            if (num != 82626113U)
                                            {
                                                if (num != 136495084U)
                                                {
                                                    goto IL_52D4;
                                                }
                                                if (!(text3 == "GROUP"))
                                                {
                                                    goto IL_52D4;
                                                }
                                                goto IL_1E5E;
                                            }
                                            else
                                            {
                                                if (!(text3 == "defaultValueExpression"))
                                                {
                                                    goto IL_52D4;
                                                }
                                                bool flag49 = _AGZ._AIX >= 3;
                                                if (flag49)
                                                {
                                                    _b2 _AAC3 = _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false) as _b2;
                                                    bool flag50 = _AAC3 != null;
                                                    if (flag50)
                                                    {
                                                        return _AAC3.GetThisInstance();
                                                    }
                                                }
                                                goto IL_52D9;
                                            }
                                        }
                                        else
                                        {
                                            if (!(text3 == "interpolatedStringLiteral"))
                                            {
                                                goto IL_52D4;
                                            }
                                            for (_bb4._AIN _AIO = _AGZ._AJA(); _AIO != null; _AIO = _AIO._AIZ)
                                            {
                                                _bh4.ResolveNode(_AIO, scope, null, 0, false);
                                            }
                                            return _bh4._BFD.GetThisInstance();
                                        }
                                    }
                                    else if (num <= 179780080U)
                                    {
                                        if (num != 177373158U)
                                        {
                                            if (num != 179780080U)
                                            {
                                                goto IL_52D4;
                                            }
                                            if (!(text3 == "assignment"))
                                            {
                                                goto IL_52D4;
                                            }
                                            bool flag51 = _AGZ._AIX >= 3;
                                            if (flag51)
                                            {
                                                _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                            }
                                            return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        }
                                        else
                                        {
                                            if (!(text3 == "usingAliasDirective"))
                                            {
                                                goto IL_52D4;
                                            }
                                            return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        }
                                    }
                                    else if (num != 180138408U)
                                    {
                                        if (num != 210866085U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "integralType"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_238F;
                                    }
                                    else
                                    {
                                        if (!(text3 == "qidPart"))
                                        {
                                            goto IL_52D4;
                                        }
                                        return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, false);
                                    }
                                }
                                else if (num <= 221106847U)
                                {
                                    if (num != 218120821U)
                                    {
                                        if (num != 218129310U)
                                        {
                                            if (num != 221106847U)
                                            {
                                                goto IL_52D4;
                                            }
                                            if (!(text3 == "predefinedType"))
                                            {
                                                goto IL_52D4;
                                            }
                                            goto IL_238F;
                                        }
                                        else
                                        {
                                            if (!(text3 == "VAR"))
                                            {
                                                goto IL_52D4;
                                            }
                                            bool flag52 = _AGZ.OOME.OOME._AHB() == "foreachStatement" && _AGZ.OOME.OOME._AIX >= 6;
                                            if (flag52)
                                            {
                                                _bb4._ACW _AGZ8 = _AGZ.OOME.OOME.NodeAt(5);
                                                bool flag53 = _AGZ8 != null && _AGZ8._AIX == 1;
                                                if (flag53)
                                                {
                                                    _bh4 _AAH4 = _bh4.EnumerableElementType(_AGZ8);
                                                    _AGZ.ChildAt(0)._ACY(_AAH4);
                                                }
                                            }
                                            else
                                            {
                                                bool flag54 = _AGZ.OOME.OOME._AHB() == "caseVariableDeclaration";
                                                if (flag54)
                                                {
                                                    _bb4._ACW _AGZ8 = _AGZ.FindParentByName("switchStatement");
                                                    _AGZ8 = ((_AGZ8 != null) ? _AGZ8.NodeAt(2) : null);
                                                    bool flag55 = _AGZ8 != null && _AGZ8._AIX == 1;
                                                    if (flag55)
                                                    {
                                                        _bh4 _AAH5 = _bh4.ResolveNode(_AGZ8, null, null, 0, false);
                                                        _bb4._AIN _AIO2 = _AGZ.ChildAt(0);
                                                        _AIO2._AJF = null;
                                                        bool flag56 = _AAH5 != null && _AAH5._AT != SymbolKind.Error;
                                                        if (flag56)
                                                        {
                                                            _AIO2._ACY(_AAH5.TypeOf());
                                                        }
                                                        else
                                                        {
                                                            _AIO2._ACY(_bh4._AHA);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    bool flag57 = _AGZ.OOME.OOME._AHB() == "outVariableDeclaration";
                                                    if (flag57)
                                                    {
                                                        _bb4.DHBA _AEM3 = null;
                                                        _bb4._ACW _AGZ9 = _AGZ.FindParentByName("arguments");
                                                        _bb4._ACW _AGZ8 = _AGZ9.OOME.FindPreviousNode() as _bb4._ACW;
                                                        bool flag58 = _AGZ8._AHB() == "primaryExpressionStart";
                                                        if (flag58)
                                                        {
                                                            _AEM3 = _AGZ8.GetFirstLeaf(true);
                                                        }
                                                        else
                                                        {
                                                            _bb4._ACW _AGZ10 = _AGZ8.NodeAt(0);
                                                            bool flag59 = _AGZ10 != null && _AGZ10._AHB() == "accessIdentifier";
                                                            if (flag59)
                                                            {
                                                                _AEM3 = _AGZ10.LeafAt(1);
                                                            }
                                                        }
                                                        _bb4._AIN _AIO3 = _AGZ.ChildAt(0);
                                                        bool flag60 = _AEM3 == null || (_AEM3._AAB() == null && _AEM3._AJF != null);
                                                        if (flag60)
                                                        {
                                                            _AIO3._ACY(_bh4._AHA);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool flag61 = _AGZ.OOME.OOME._AIX >= 2;
                                                        if (flag61)
                                                        {
                                                            _bb4._ACW _AGZ8 = _AGZ.OOME.OOME.NodeAt(1);
                                                            bool flag62 = _AGZ8 != null && _AGZ8._AIX == 1;
                                                            if (flag62)
                                                            {
                                                                _bb4._ACW _AGZ11 = _AGZ8.NodeAt(0);
                                                                bool flag63 = _AGZ11 != null && _AGZ11._AIX >= 3;
                                                                if (flag63)
                                                                {
                                                                    _bh4 _AAH6 = _bh4.ResolveNode(_AGZ11.ChildAt(-1), null, null, 0, false);
                                                                    _bb4._AIN _AIO4 = _AGZ.ChildAt(0);
                                                                    _AIO4._AJF = null;
                                                                    bool flag64 = _AAH6 != null && _AAH6._AT != SymbolKind.Error;
                                                                    if (flag64)
                                                                    {
                                                                        _AIO4._ACY(_AAH6.TypeOf());
                                                                    }
                                                                    else
                                                                    {
                                                                        _AIO4._ACY(_bh4._AHA);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    _AGZ.ChildAt(0)._ACY(_bh4._AHA);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            _AGZ.ChildAt(0)._ACY(_bh4._AHA);
                                                        }
                                                    }
                                                }
                                            }
                                            return _AGZ.ChildAt(0)._AAB();
                                        }
                                    }
                                    else
                                    {
                                        if (!(text3 == "constructorInitializer"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_52CF;
                                    }
                                }
                                else if (num <= 274733460U)
                                {
                                    if (num != 256650302U)
                                    {
                                        if (num != 274733460U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "EQUALS"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_1E5E;
                                    }
                                    else
                                    {
                                        if (!(text3 == "implicitAnonymousFunctionParameterList"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_52CF;
                                    }
                                }
                                else if (num != 289127768U)
                                {
                                    if (num != 307867620U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "lambdaExpressionBody"))
                                    {
                                        goto IL_52D4;
                                    }
                                    _bb4._ACW _AGZ12 = _AGZ.NodeAt(0);
                                    bool flag65 = _AGZ12 != null;
                                    if (flag65)
                                    {
                                        return _bh4.ResolveNode(_AGZ12, null, null, 0, false);
                                    }
                                    return null;
                                }
                                else
                                {
                                    if (!(text3 == "typeParameter"))
                                    {
                                        goto IL_52D4;
                                    }
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, true) as _b2;
                                }
                            }
                            else
                            {
                                if (num <= 693225631U)
                                {
                                    if (num <= 479015637U)
                                    {
                                        if (num != 405554134U)
                                        {
                                            if (num != 425270591U)
                                            {
                                                if (num != 479015637U)
                                                {
                                                    goto IL_52D4;
                                                }
                                                if (!(text3 == "anonymousMethodExpression"))
                                                {
                                                    goto IL_52D4;
                                                }
                                                bool flag66 = _AGZ._AIX > 1;
                                                if (flag66)
                                                {
                                                    _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                                                }
                                                bool flag67 = _AGZ._AIX == 3;
                                                if (flag67)
                                                {
                                                    _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                                }
                                                _bn4 _AQH = _AGZ._AJW as _bn4;
                                                bool flag68 = _AQH != null && _AQH.EFI != null;
                                                if (flag68)
                                                {
                                                    return _AQH.EFI._ACV;
                                                }
                                                return _bh4._AAA;
                                            }
                                            else
                                            {
                                                if (!(text3 == "collectionInitializer"))
                                                {
                                                    goto IL_52D4;
                                                }
                                                goto IL_52CF;
                                            }
                                        }
                                        else if (!(text3 == "relationalExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                    }
                                    else if (num <= 567569430U)
                                    {
                                        if (num != 563229867U)
                                        {
                                            if (num != 567569430U)
                                            {
                                                goto IL_52D4;
                                            }
                                            if (!(text3 == "namespaceOrTypeName"))
                                            {
                                                goto IL_52D4;
                                            }
                                            _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, (_AGZ._AIX == 1) ? numTypeArguments : 0, true);
                                            for (int i = 2; i < (int)_AGZ._AIX; i += 2)
                                            {
                                                _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(i), scope, _AAH2, (i == (int)(_AGZ._AIX - 1)) ? numTypeArguments : 0, true);
                                            }
                                            return _AAH2;
                                        }
                                        else
                                        {
                                            if (!(text3 == "additiveExpression"))
                                            {
                                                goto IL_52D4;
                                            }
                                            _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                            for (int j = 2; j < (int)_AGZ._AIX; j += 2)
                                            {
                                                _bh4 _AAH7 = _bh4.ResolveNode(_AGZ.ChildAt(j), scope, null, 0, false);
                                                bool flag69 = _AAH2 is _bn3 && _AAH7 is _bn3;
                                                if (flag69)
                                                {
                                                    bool flag70 = _AGZ.ChildAt(j - 1).IsLit("+");
                                                    if (flag70)
                                                    {
                                                        _AAH2 = _bh4.ResolveExpression("op_Addition", _AAH2, _AAH7);
                                                    }
                                                    else
                                                    {
                                                        _AAH2 = _bh4.ResolveExpression("op_Subtraction", _AAH2, _AAH7);
                                                    }
                                                }
                                            }
                                            return _AAH2;
                                        }
                                    }
                                    else if (num != 670883971U)
                                    {
                                        if (num != 693225631U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "arguments"))
                                        {
                                            goto IL_52D4;
                                        }
                                        bool flag71 = asMemberOf == null;
                                        if (flag71)
                                        {
                                            _bb4._AIN _AIO5 = _AGZ.FindPreviousNode();
                                            asMemberOf = _bh4.ResolveNode(_AIO5, scope, null, 0, false);
                                            bool flag72 = asMemberOf == null;
                                            if (flag72)
                                            {
                                                return null;
                                            }
                                        }
                                        _bb4._ACW _AGZ13 = ((_AGZ._AIX >= 2) ? _AGZ.NodeAt(1) : null);
                                        bool flag73 = _AGZ13 != null;
                                        if (flag73)
                                        {
                                            _bh4.ResolveNode(_AGZ13, scope, null, 0, false);
                                        }
                                        bool flag74 = _AGZ.OOME._AHB() == "attribute" || _AGZ.OOME._AHB() == "constructorInitializer";
                                        if (flag74)
                                        {
                                            return _bh4._AAA;
                                        }
                                        _bb4._ACW _AGZ14 = _AGZ.FindPreviousNode() as _bb4._ACW;
                                        _bb4.DHBA _AEM4 = _AGZ14.LeafAt(0) ?? _AGZ14.NodeAt(0).LeafAt(1);
                                        _ba7 _AAK = asMemberOf as _ba7;
                                        bool flag75 = _AAK != null;
                                        if (flag75)
                                        {
                                            asMemberOf = _AAK.ResolveMethodOverloads(_AGZ13, null, scope, _AEM4);
                                            _bh4 _AAH8 = asMemberOf as _bb3;
                                            bool flag76 = _AAH8 == null && asMemberOf != null && asMemberOf._AT == SymbolKind.Method;
                                            if (flag76)
                                            {
                                                _AAH8 = asMemberOf as _bm7;
                                            }
                                            bool flag77 = _AAH8 != null;
                                            if (flag77)
                                            {
                                                bool flag78 = _AAH8._AT == SymbolKind.Error;
                                                if (flag78)
                                                {
                                                    _AEM4._ACY(_AAK);
                                                    _AEM4._AJF = _AAH8._AW;
                                                }
                                                else
                                                {
                                                    bool flag79 = _AEM4._AAB() != _AAH8;
                                                    if (flag79)
                                                    {
                                                        _AEM4._ACY(_AAH8);
                                                    }
                                                }
                                                return _AAH8;
                                            }
                                        }
                                        else
                                        {
                                            bool flag80 = asMemberOf._AT == SymbolKind.MethodGroup;
                                            if (flag80)
                                            {
                                                _bm7 _BFS = asMemberOf as _bm7;
                                                bool flag81 = _BFS != null;
                                                if (flag81)
                                                {
                                                    asMemberOf = _BFS.ResolveMethodOverloads(_AGZ13, null, scope, _AEM4);
                                                }
                                                _bh4 _AAH9 = asMemberOf as _bb3;
                                                bool flag82 = _AAH9 == null && asMemberOf != null && asMemberOf._AT == SymbolKind.Method;
                                                if (flag82)
                                                {
                                                    _AAH9 = asMemberOf as _bm7;
                                                }
                                                bool flag83 = _AAH9 != null;
                                                if (flag83)
                                                {
                                                    bool flag84 = _AAH9._AT == SymbolKind.Error;
                                                    if (flag84)
                                                    {
                                                        _AEM4._ACY(_AAK);
                                                        _AEM4._AJF = _AAH9._AW;
                                                    }
                                                    else
                                                    {
                                                        bool flag85 = _AEM4._AAB() != _AAH9;
                                                        if (flag85)
                                                        {
                                                            _AEM4._ACY(_AAH9);
                                                        }
                                                    }
                                                    return _AAH9;
                                                }
                                            }
                                            else
                                            {
                                                bool flag86 = asMemberOf._AT != SymbolKind.Method && asMemberOf._AT != SymbolKind.Error;
                                                if (flag86)
                                                {
                                                    _b2 _AAC4 = asMemberOf.TypeOf() as _b2;
                                                    bool flag87 = _AAC4 == null || _AAC4._AT == SymbolKind.Error;
                                                    if (flag87)
                                                    {
                                                        return _bh4._AHA;
                                                    }
                                                    _b2 _AAC5 = ((asMemberOf._AT == SymbolKind.Delegate) ? _AAC4 : ((_AAC4._AT == SymbolKind.Delegate) ? (_AAC4.TypeOf() as _b2) : null));
                                                    bool flag88 = _AAC5 != null;
                                                    if (flag88)
                                                    {
                                                        return _AAC5.GetThisInstance();
                                                    }
                                                    _AGZ.LeafAt(0)._AJF = "Cannot invoke symbol";
                                                }
                                            }
                                        }
                                        return asMemberOf;
                                    }
                                    else
                                    {
                                        if (!(text3 == "variableInitializerList"))
                                        {
                                            goto IL_52D4;
                                        }
                                        _b2 _AAC6 = null;
                                        for (int k = 0; k < (int)_AGZ._AIX; k += 2)
                                        {
                                            _b2 _AAC7 = (_bh4.ResolveNode(_AGZ.ChildAt(k), scope, null, 0, false) ?? _bh4._AAA).TypeOf() as _b2;
                                            bool flag89 = _AAC7 != null;
                                            if (flag89)
                                            {
                                                bool flag90 = _AAC6 == null;
                                                if (flag90)
                                                {
                                                    _AAC6 = _AAC7;
                                                }
                                                else
                                                {
                                                    bool flag91 = _AAC6.DerivesFrom(_AAC7);
                                                    if (flag91)
                                                    {
                                                        _AAC6 = _AAC7;
                                                    }
                                                }
                                            }
                                        }
                                        return _AAC6;
                                    }
                                }
                                else if (num <= 784738317U)
                                {
                                    if (num <= 727204632U)
                                    {
                                        if (num != 708299687U)
                                        {
                                            if (num != 727204632U)
                                            {
                                                goto IL_52D4;
                                            }
                                            if (!(text3 == "exclusiveOrExpression"))
                                            {
                                                goto IL_52D4;
                                            }
                                            goto IL_4712;
                                        }
                                        else
                                        {
                                            if (!(text3 == "equalityExpression"))
                                            {
                                                goto IL_52D4;
                                            }
                                            bool flag92 = _AGZ._AIX == 1;
                                            if (!flag92)
                                            {
                                                for (int l = 0; l < (int)_AGZ._AIX; l += 2)
                                                {
                                                    _bh4.ResolveNode(_AGZ.ChildAt(l), scope, null, 0, false);
                                                }
                                                return _bh4._BFP;
                                            }
                                            _AGZ = _AGZ.NodeAt(0);
                                        }
                                    }
                                    else if (num != 781357933U)
                                    {
                                        if (num != 784738317U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "parenExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                        return _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                                    }
                                    else
                                    {
                                        if (!(text3 == "uncheckedExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_41B6;
                                    }
                                }
                                else if (num <= 786707865U)
                                {
                                    if (num != 784967220U)
                                    {
                                        if (num != 786707865U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "elementInitializerList"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_52CF;
                                    }
                                    else
                                    {
                                        if (!(text3 == "explicitAnonymousFunctionSignature"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_52CF;
                                    }
                                }
                                else if (num != 832730651U)
                                {
                                    if (num != 839436841U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "preDecrementExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_46D3;
                                }
                                else
                                {
                                    if (!(text3 == "classMemberDeclaration"))
                                    {
                                        goto IL_52D4;
                                    }
                                    return null;
                                }
                                bool flag93 = _AGZ._AIX == 1;
                                if (flag93)
                                {
                                    _AGZ = _AGZ.NodeAt(0);
                                    goto IL_4712;
                                }
                                _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                for (int m = 2; m < (int)_AGZ._AIX; m += 2)
                                {
                                    bool flag94 = _AGZ.ChildAt(m - 1).IsLit("as");
                                    if (flag94)
                                    {
                                        _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(m), scope, null, 0, false);
                                        bool flag95 = _AAH2 is _b2;
                                        if (flag95)
                                        {
                                            _AAH2 = (_AAH2 as _b2).GetThisInstance();
                                        }
                                    }
                                    else
                                    {
                                        _bh4.ResolveNode(_AGZ.ChildAt(m), scope, null, 0, false);
                                        _AAH2 = _bh4._BFP.GetThisInstance();
                                    }
                                }
                                return _AAH2;
                            }
                        }
                        else if (num <= 1361572173U)
                        {
                            if (num <= 1088498413U)
                            {
                                if (num <= 1020520569U)
                                {
                                    if (num != 870153044U)
                                    {
                                        if (num != 889900154U)
                                        {
                                            if (num != 1020520569U)
                                            {
                                                goto IL_52D4;
                                            }
                                            if (!(text3 == "nameofExpression"))
                                            {
                                                goto IL_52D4;
                                            }
                                            bool flag96 = _AGZ._AIX >= 3;
                                            if (flag96)
                                            {
                                                _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                            }
                                            return _bh4._BFD.GetThisInstance();
                                        }
                                        else
                                        {
                                            if (!(text3 == "variableReference"))
                                            {
                                                goto IL_52D4;
                                            }
                                            goto IL_4235;
                                        }
                                    }
                                    else
                                    {
                                        if (!(text3 == "BY"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_1E5E;
                                    }
                                }
                                else if (num <= 1047347951U)
                                {
                                    if (num != 1040765708U)
                                    {
                                        if (num != 1047347951U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "attribute"))
                                        {
                                            goto IL_52D4;
                                        }
                                        _bh4 _AAH10 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        bool flag97 = _AGZ._AIX == 2;
                                        if (flag97)
                                        {
                                            _bh4.ResolveNode(_AGZ.ChildAt(1), null, null, 0, false);
                                        }
                                        return _AAH10;
                                    }
                                    else
                                    {
                                        if (!(text3 == "implicitArrayCreationExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                        _b2 _AAC8 = null;
                                        _bb4._ACW _AGZ15 = _AGZ.NodeAt(0);
                                        int num2 = (int)((_AGZ15 != null && _AGZ15._AIX > 0) ? (_AGZ15._AIX - 1) : 1);
                                        _bb4._ACW _AGZ16 = _AGZ.NodeAt(1);
                                        _bh4 _AAH11 = ((_AGZ16 != null) ? _bh4.ResolveNode(_AGZ16, null, null, 0, false) : null);
                                        bool flag98 = _AAH11 != null;
                                        if (flag98)
                                        {
                                            _AAC8 = ((_AAH11.TypeOf() as _b2) ?? _bh4._AHA).MakeArrayType(num2);
                                        }
                                        return (_AAC8 ?? _bh4._AHA).GetThisInstance();
                                    }
                                }
                                else if (num != 1070359341U)
                                {
                                    if (num != 1088498413U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "type2"))
                                    {
                                        goto IL_52D4;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "objectCreationExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    _b2 _AAC9 = (_bh4.ResolveNode(_AGZ.FindPreviousNode(), scope, null, 0, false) ?? _bh4._AHA).TypeOf() as _b2;
                                    return (_AAC9 != null) ? _AAC9.GetThisInstance() : null;
                                }
                            }
                            else if (num <= 1214048978U)
                            {
                                if (num != 1126432755U)
                                {
                                    if (num != 1168862016U)
                                    {
                                        if (num != 1214048978U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "qualifiedIdentifier"))
                                        {
                                            goto IL_52D4;
                                        }
                                        _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false) as _bn1;
                                        int num3 = 2;
                                        while (_AAH2 != null && num3 < (int)_AGZ._AIX)
                                        {
                                            _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(num3), scope, _AAH2, 0, false);
                                            _bb4._ACW _AGZ17 = _AGZ.NodeAt(num3);
                                            bool flag99 = _AGZ17 != null && _AGZ17._AIX == 1;
                                            if (flag99)
                                            {
                                                _AGZ17.ChildAt(0)._ACY(_AAH2);
                                            }
                                            num3 += 2;
                                        }
                                        return _AAH2;
                                    }
                                    else
                                    {
                                        if (!(text3 == "conditionalOrExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                        bool flag100 = _AGZ._AIX == 1;
                                        if (flag100)
                                        {
                                            _AGZ = _AGZ.NodeAt(0);
                                            goto IL_4C86;
                                        }
                                        for (int n = 0; n < (int)_AGZ._AIX; n += 2)
                                        {
                                            _bh4.ResolveNode(_AGZ.ChildAt(n), scope, null, 0, false);
                                        }
                                        return _bh4._BFP;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "awaitExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag101 = _AGZ._AIX < 2;
                                    if (flag101)
                                    {
                                        return _bh4._AHA;
                                    }
                                    _bh4 _AAH12 = _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                                    _bc6 _AHD = (_AAH12.TypeOf() as _bc6) ?? _bh4._AHA;
                                    bool flag102 = _AHD._AT == SymbolKind.Error;
                                    if (flag102)
                                    {
                                        return _AHD;
                                    }
                                    bool flag103 = _AHD == _bh4._BFT;
                                    if (flag103)
                                    {
                                        return _bh4._BFU.GetThisInstance();
                                    }
                                    _bi5 _AAE = _AHD.ConvertTo(_bh4._BFV) as _bi5;
                                    bool flag104 = _AAE != null;
                                    if (flag104)
                                    {
                                        KJK _AAD = ((_AAE._AHH == null) ? null : _AAE._AHH.FirstOrDefault<KJK>());
                                        bool flag105 = _AAD == null;
                                        if (flag105)
                                        {
                                            return null;
                                        }
                                        _bc6 _AHD2 = _AAD.definition as _bc6;
                                        return (_AHD2 == null) ? null : _AHD2.GetThisInstance();
                                    }
                                    else
                                    {
                                        _bb3 _AAN = _AHD.FindMethod("GetAwaiter", 0, 0, true);
                                        bool flag106 = _AAN == null;
                                        if (flag106)
                                        {
                                            _AAN = scope.ResolveAsExtensionMethod("GetAwaiter", _AHD, null, null, scope, null) as _bb3;
                                        }
                                        bool flag107 = _AAN == null;
                                        if (flag107)
                                        {
                                            return null;
                                        }
                                        _b2 _AAC10 = _AAN.ReturnType();
                                        bool flag108 = _AAC10 == null || !_AAC10.DerivesFrom(_bh4._BFW);
                                        if (flag108)
                                        {
                                            return null;
                                        }
                                        _bb3 _AAN2 = _AAC10.FindMethod("GetResult", 0, 0, true);
                                        bool flag109 = _AAN2 == null;
                                        if (flag109)
                                        {
                                            return null;
                                        }
                                        _b2 _AAC11 = _AAN2.ReturnType();
                                        _AAC11 = _AAC11.SubstituteTypeParameters(_AAN2);
                                        _AAC11 = _AAC11.SubstituteTypeParameters(_AAC10);
                                        _AAC11 = _AAC11.SubstituteTypeParameters(_AAN);
                                        _AAC11 = _AAC11.SubstituteTypeParameters(_AHD);
                                        return _AAC11.GetThisInstance();
                                    }
                                }
                            }
                            else if (num <= 1251344729U)
                            {
                                if (num != 1224835811U)
                                {
                                    if (num != 1251344729U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "explicitAnonymousFunctionParameter"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_52CF;
                                }
                                else
                                {
                                    if (!(text3 == "SET"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_1DE9;
                                }
                            }
                            else if (num != 1253668138U)
                            {
                                if (num != 1361572173U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "type"))
                                {
                                    goto IL_52D4;
                                }
                            }
                            else
                            {
                                if (!(text3 == "nullCoalescingExpression"))
                                {
                                    goto IL_52D4;
                                }
                                for (int num4 = 2; num4 < (int)_AGZ._AIX; num4 += 2)
                                {
                                    _bh4.ResolveNode(_AGZ.ChildAt(num4), scope, null, 0, false);
                                }
                                _bh4 _AAH13 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                bool flag110 = _AGZ._AIX >= 2 && _AAH13 != null && (_AAH13.TypeOf() ?? _bh4._AHA).GetGenericSymbol() == _bh4._AY;
                                if (flag110)
                                {
                                    _bi5 _AAE2 = _AAH13.TypeOf() as _bi5;
                                    bool flag111 = _AAE2 != null;
                                    if (flag111)
                                    {
                                        _b2 _AAC12 = _AAE2._AHH[0].definition as _b2;
                                        bool flag112 = _AAC12 != null;
                                        if (flag112)
                                        {
                                            return _AAC12.GetThisInstance();
                                        }
                                    }
                                }
                                return _AAH13;
                            }
                            _bh4 _AAH14 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, numTypeArguments, true);
                            _b2 _AAC13 = _AAH14 as _b2;
                            bool flag113 = _AAC13 != null;
                            if (flag113)
                            {
                                bool flag114 = _AGZ._AIX > 1;
                                if (flag114)
                                {
                                    _bb4.DHBA _AEM5 = _AGZ.LeafAt(1);
                                    bool flag115 = _AEM5 != null && _AEM5._ACX.text == "?";
                                    if (flag115)
                                    {
                                        _AAC13 = _AAC13.MakeNullableType();
                                    }
                                    _bb4._ACW _AGZ18 = _AGZ.NodeAt(-1);
                                    bool flag116 = _AGZ18 != null && _AGZ18._AIX != 0;
                                    if (flag116)
                                    {
                                        for (int num5 = 1; num5 < (int)_AGZ18._AIX; num5 += 2)
                                        {
                                            int num2 = 1;
                                            while (num5 < (int)_AGZ18._AIX && _AGZ18.ChildAt(num5).IsLit(","))
                                            {
                                                int num6 = num2 + 1;
                                                num2 = num6;
                                                num6 = num5 + 1;
                                                num5 = num6;
                                            }
                                            _AAC13 = _AAC13.MakeArrayType(num2);
                                        }
                                    }
                                }
                                return _AAC13;
                            }
                            bool flag117 = _AAH14 != null && _AAH14._AT != SymbolKind.Error;
                            if (flag117)
                            {
                                _bb4.DHBA _AEM6 = _AGZ.LeafAt(0) ?? _AGZ.NodeAt(0).GetFirstLeaf();
                                bool flag118 = _AEM6 != null;
                                if (flag118)
                                {
                                    _AEM6._AJF = "Type expected";
                                }
                            }
                            goto IL_52D9;
                        }
                        else if (num <= 1767627332U)
                        {
                            if (num <= 1522621410U)
                            {
                                if (num != 1436603660U)
                                {
                                    if (num != 1493151911U)
                                    {
                                        if (num != 1522621410U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "interfaceMemberDeclaration"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_52CF;
                                    }
                                    else
                                    {
                                        if (!(text3 == "simpleType"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_238F;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "castExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag119 = _AGZ._AIX == 4;
                                    if (flag119)
                                    {
                                        _bh4.ResolveNode(_AGZ.ChildAt(3), scope, null, 0, false);
                                    }
                                    _b2 _AAC14 = _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false) as _b2;
                                    bool flag120 = _AAC14 != null;
                                    if (flag120)
                                    {
                                        return _AAC14.GetThisInstance();
                                    }
                                    goto IL_52D9;
                                }
                            }
                            else if (num <= 1662645679U)
                            {
                                if (num != 1623885570U)
                                {
                                    if (num != 1662645679U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "primaryExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    _bh4 _AAH15 = _AAH2;
                                    bool flag121 = false;
                                    _bb4.DHBA _AEM7 = null;
                                    int num6;
                                    for (int num7 = 0; num7 < (int)_AGZ._AIX; num7 = num6)
                                    {
                                        _bb4._AIN _AIO6 = _AGZ.ChildAt(num7);
                                        _bb4.DHBA _AEM8 = _AIO6 as _bb4.DHBA;
                                        bool flag122 = _AEM8 != null && _AEM8._AJC;
                                        if (flag122)
                                        {
                                            return _AAH2;
                                        }
                                        _bb4._ACW _AGZ19 = _AIO6 as _bb4._ACW;
                                        _bh4 _AAH16 = null;
                                        bool flag123 = num7 == 0 && _AEM8 != null && _AEM8._ACX != null && _AEM8._ACX.text == "new";
                                        if (flag123)
                                        {
                                            _AGZ19 = _AGZ.NodeAt(1);
                                            bool flag124 = _AGZ19 != null && _AGZ19._AIX > 0;
                                            if (flag124)
                                            {
                                                _bb4._ACW _AGZ20 = ((_AGZ19._AHB() == "nonArrayType") ? _AGZ19 : null);
                                                bool flag125 = _AGZ20 != null;
                                                if (flag125)
                                                {
                                                    asMemberOf = _bh4.ResolveNode(_AGZ20, scope, null, 0, false);
                                                    _bb4._ACW _AGZ21 = _AGZ.NodeAt(2);
                                                    bool flag126 = _AGZ21 != null && _AGZ21._AHB() == "objectCreationExpression";
                                                    if (flag126)
                                                    {
                                                        num7 += 2;
                                                        _AAH16 = _bh4.ResolveNodeAsConstructor(_AGZ21, scope, asMemberOf);
                                                        bool flag127 = _AAH16 != null && _AAH16._AT == SymbolKind.Constructor;
                                                        if (flag127)
                                                        {
                                                            _bi5 _AAE3 = asMemberOf as _bi5;
                                                            bool flag128 = _AAE3 != null;
                                                            if (flag128)
                                                            {
                                                                _AAH16 = _AAE3.GetConstructedMember(_AAH16);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool flag129 = _AGZ21 != null;
                                                        if (flag129)
                                                        {
                                                            num7 += 2;
                                                            _AAH16 = _bh4.ResolveNode(_AGZ.ChildAt(num7), scope, asMemberOf, 0, false);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    _AAH16 = _bh4.ResolveNode(_AGZ19, scope, null, 0, false);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            _bb4._ACW _AGZ22 = ((num7 != 0) ? (_AIO6 as _bb4._ACW) : null);
                                            _bb4._ACW _AGZ23 = ((_AGZ22 != null) ? _AGZ22.NodeAt(0) : null);
                                            bool flag130 = _AGZ23 != null && _AGZ23._AHB() == "arguments";
                                            if (flag130)
                                            {
                                                _AAH16 = _bh4.ResolveArgumentsNode(_AGZ23, scope, _AEM7, _AAH2, asMemberOf);
                                                List<_bm1> list = ((_AAH16 != null) ? _AAH16.GetParameters() : null);
                                                bool flag131 = list != null;
                                                if (flag131)
                                                {
                                                    _bb4._ACW _AGZ24 = ((_AGZ23 != null && _AGZ23._AIX >= 2) ? _AGZ23.NodeAt(1) : null);
                                                    bool flag132 = _AGZ24 != null;
                                                    if (flag132)
                                                    {
                                                        for (int num8 = 0; num8 < (int)_AGZ24._AIX; num8 += 2)
                                                        {
                                                            _bb4._ACW _AGZ25 = _AGZ24.NodeAt(num8);
                                                            bool flag133 = _AGZ25 == null;
                                                            if (!flag133)
                                                            {
                                                                _bb4._AIN _AIO7 = _AGZ25.FindChildByName(_bh4._BFX);
                                                                bool flag134 = _AIO7 != null;
                                                                if (flag134)
                                                                {
                                                                    _bh4.ResolveNode(_AIO7, null, null, 0, false);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                _AAH16 = _bh4.ResolveNode(_AIO6, scope, _AAH2, 0, false);
                                            }
                                        }
                                        asMemberOf = _AAH2;
                                        bool flag135 = _AAH16 != null && _AAH16._AT != SymbolKind.Error;
                                        if (flag135)
                                        {
                                            _bh4 _AAH17 = ((_AAH16._AT == SymbolKind.Method || _AAH16._AT == SymbolKind.Constructor) ? _AAH16 : null);
                                            bool flag136 = _AAH16._AT == SymbolKind.MethodGroup;
                                            if (flag136)
                                            {
                                                bool flag137 = _AGZ19._AIX == 2 && !(_AAH16 is _bd1);
                                                if (flag137)
                                                {
                                                    _AAH16 = _bh4.ResolveNode(_AGZ19.NodeAt(1), scope, _AAH16, 0, false);
                                                }
                                            }
                                            bool flag138 = _AAH17 != null;
                                            if (flag138)
                                            {
                                                bool flag139 = _AGZ19 != null;
                                                if (flag139)
                                                {
                                                    bool flag140 = _AGZ19._AHB() == "primaryExpressionStart";
                                                    if (flag140)
                                                    {
                                                        _bb4.DHBA _AEM9 = _AGZ19.LeafAt((_AGZ19._AIX < 3) ? 0 : 2);
                                                        bool flag141 = _AEM9 != null;
                                                        if (flag141)
                                                        {
                                                            _AEM9._ACY(_AAH16);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool flag142 = _AGZ19._AHB() == "primaryExpressionPart";
                                                        if (flag142)
                                                        {
                                                            _bb4._ACW _AGZ26 = _AGZ19.NodeAt(0);
                                                            bool flag143 = _AGZ26 != null && _AGZ26._AHB() == "accessIdentifier";
                                                            if (flag143)
                                                            {
                                                                _bb4.DHBA _AEM10 = _AGZ26.LeafAt(1);
                                                                bool flag144 = _AEM10 != null;
                                                                if (flag144)
                                                                {
                                                                    _AEM10._ACY(_AAH16);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    _AGZ.ChildAt(num7)._ACY(_AAH17);
                                                }
                                            }
                                        }
                                        _bb4._ACW _AGZ27 = _AIO6 as _bb4._ACW;
                                        bool flag145 = _AGZ27 != null;
                                        if (flag145)
                                        {
                                            _AGZ27 = _AGZ27.NodeAt(0);
                                        }
                                        bool flag146 = _AGZ27 != null;
                                        if (flag146)
                                        {
                                            bool flag147 = _AAH16 != null && _AAH15 != null && !(_AAH15 is _b2) && (_AAH16 is _b2 || _AAH16.IsStatic);
                                            if (flag147)
                                            {
                                                switch (_AAH15._AT)
                                                {
                                                    case SymbolKind.Field:
                                                    case SymbolKind.ConstantField:
                                                    case SymbolKind.LocalConstant:
                                                    case SymbolKind.Property:
                                                    case SymbolKind.Event:
                                                    case SymbolKind.Indexer:
                                                    case SymbolKind.Parameter:
                                                    case SymbolKind.CatchParameter:
                                                    case SymbolKind.Variable:
                                                    case SymbolKind.CaseVariable:
                                                    case SymbolKind.ForEachVariable:
                                                    case SymbolKind.FromClauseVariable:
                                                    case SymbolKind.OutVariable:
                                                    case SymbolKind.Instance:
                                                        {
                                                            _bh4 _AAH18 = _AAH16._AO;
                                                            while (_AAH18 != null && !(_AAH18 is _b2))
                                                            {
                                                                _AAH18 = _AAH18._AO;
                                                            }
                                                            bool flag148 = _AAH18 != null && _AAH18._AHG() == 0 && _AAH15._AHG() == 0 && _AAH15._AW == _AAH18._AW;
                                                            if (flag148)
                                                            {
                                                                _AEM7._ACY(_AAH18);
                                                            }
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        _AAH2 = _AAH16;
                                        bool flag149 = _AAH2 == null;
                                        if (flag149)
                                        {
                                            break;
                                        }
                                        bool flag150 = _AAH2._AT == SymbolKind.Method;
                                        if (flag150)
                                        {
                                            _bb4._ACW _AGZ28 = _AIO6 as _bb4._ACW;
                                            bool flag151 = _AGZ28 != null;
                                            if (flag151)
                                            {
                                                _AGZ28 = ((_AGZ28._AHB() == "primaryExpressionPart") ? _AGZ28.NodeAt(0) : null);
                                            }
                                            bool flag152 = _AGZ28 == null || _AGZ28._AHB() != "arguments";
                                            if (flag152)
                                            {
                                                _AAH2 = _AAH2._AO;
                                            }
                                        }
                                        bool flag153 = _AAH2 == null;
                                        if (flag153)
                                        {
                                            break;
                                        }
                                        bool flag154 = _AAH2._AT == SymbolKind.Method;
                                        if (flag154)
                                        {
                                            _b2 _AAC15 = (_AAH2 = _AAH2.TypeOf()) as _b2;
                                            bool flag155 = _AAC15 != null;
                                            if (flag155)
                                            {
                                                _AAH2 = _AAC15.GetThisInstance();
                                            }
                                        }
                                        else
                                        {
                                            bool flag156 = _AAH2._AT == SymbolKind.Constructor;
                                            if (flag156)
                                            {
                                                _AAH2 = ((_b2)_AAH2._AO).GetThisInstance();
                                            }
                                        }
                                        bool flag157 = _AAH2 == null;
                                        if (flag157)
                                        {
                                            break;
                                        }
                                        bool flag158 = _AAH2._AT != SymbolKind.MethodGroup;
                                        if (flag158)
                                        {
                                            _AAH15 = _AAH2;
                                        }
                                        _bb4._ACW _AGZ29 = _AIO6 as _bb4._ACW;
                                        bool flag159 = _AGZ29 != null;
                                        if (flag159)
                                        {
                                            bool flag160 = _AGZ29._AHB() == "primaryExpressionPart";
                                            if (flag160)
                                            {
                                                _bb4._ACW _AGZ30 = _AGZ29.NodeAt(0);
                                                bool flag161 = _AGZ30 != null && _AGZ30._AHB() == "accessIdentifier";
                                                if (flag161)
                                                {
                                                    _AEM7 = _AGZ30.LeafAt(1);
                                                    _bb4.DHBA _AEM11 = _AGZ30.LeafAt(0);
                                                    bool flag162 = _AEM11 != null && _AEM11._ACX.text == "?.";
                                                    if (flag162)
                                                    {
                                                        flag121 = true;
                                                        _b2 _AAC16 = asMemberOf.TypeOf() as _b2;
                                                        bool flag163 = _AAC16 != null && ((_AAC16._AT == SymbolKind.Struct && _AAC16.GetGenericSymbol() != _bh4._AY) || _AAC16._AT == SymbolKind.Enum);
                                                        if (flag163)
                                                        {
                                                            _AEM11._AJF = "Operator '?.' cannot be applied to operand of a value type";
                                                            return _bh4._AHA;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    _AEM7 = null;
                                                }
                                            }
                                            else
                                            {
                                                bool flag164 = _AGZ29._AHB() == "primaryExpressionStart";
                                                if (flag164)
                                                {
                                                    _bb4.DHBA _AEM12 = _AGZ29.LeafAt(0);
                                                    bool flag165 = _AEM12 != null && _AEM12._ACX.tokenKind == SyntaxToken.Kind.Identifier;
                                                    if (flag165)
                                                    {
                                                        _AEM7 = _AGZ29.LeafAt((_AGZ29._AIX == 3) ? 2 : 0);
                                                    }
                                                }
                                            }
                                        }
                                        num6 = num7 + 1;
                                    }
                                    bool flag166 = flag121 && _AAH2 != null;
                                    if (flag166)
                                    {
                                        _b2 _AAC17 = _AAH2.TypeOf() as _b2;
                                        bool flag167 = _AAC17 != null && (_AAC17._AT == SymbolKind.Struct || _AAC17._AT == SymbolKind.Enum);
                                        if (flag167)
                                        {
                                            _AAH2 = _AAC17.MakeNullableType().GetThisInstance();
                                        }
                                    }
                                    return _AAH2 ?? _bh4._AAA;
                                }
                                else
                                {
                                    if (!(text3 == "typeofExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag168 = _AGZ._AIX >= 3;
                                    if (flag168)
                                    {
                                        _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                    }
                                    return ((_b2)_bl9.ForType(typeof(Type)).definition).GetThisInstance();
                                }
                            }
                            else if (num != 1735118041U)
                            {
                                if (num != 1767627332U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "andExpression"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_4712;
                            }
                            else
                            {
                                if (!(text3 == "nonArrayType"))
                                {
                                    goto IL_52D4;
                                }
                                _bh4 _AAH19 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, true);
                                _b2 _AAC18 = _AAH19 as _b2;
                                bool flag169 = _AAC18 != null && _AGZ._AIX == 2;
                                if (flag169)
                                {
                                    return _AAC18.MakeNullableType();
                                }
                                return _AAC18;
                            }
                        }
                        else if (num <= 1956832512U)
                        {
                            if (num <= 1826872355U)
                            {
                                if (num != 1814290442U)
                                {
                                    if (num != 1826872355U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "INTO"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_1E5E;
                                }
                                else
                                {
                                    if (!(text3 == "typeArgumentList"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag170 = asMemberOf == null;
                                    if (flag170)
                                    {
                                        asMemberOf = _bh4.ResolveNode(_AGZ.FindPreviousNode(), scope, null, 0, false);
                                    }
                                    numTypeArguments = (int)(_AGZ._AIX / 2);
                                    _ba7 _AAK2 = asMemberOf as _ba7;
                                    _bm7 _BFS2 = asMemberOf as _bm7;
                                    bool flag171 = _BFS2 != null;
                                    if (flag171)
                                    {
                                        _AAK2 = _BFS2._CBS() as _ba7;
                                    }
                                    bool flag172 = _AAK2 != null;
                                    int num6;
                                    if (!flag172)
                                    {
                                        _bc6 _AHD3 = asMemberOf as _bc6;
                                        bool flag173 = _AHD3 != null;
                                        if (flag173)
                                        {
                                            KJK[] array = new KJK[numTypeArguments];
                                            for (int num9 = 0; num9 < numTypeArguments; num9 = num6)
                                            {
                                                array[num9] = new KJK(_AGZ.ChildAt(2 * num9 + 1));
                                                num6 = num9 + 1;
                                            }
                                            bool flag174 = _AHD3._AHL != null && _AHD3._AHL.Count == numTypeArguments;
                                            if (flag174)
                                            {
                                                _bi5 _AAE4 = _AHD3.ConstructType(array);
                                                bool flag175 = _AAE4 != null;
                                                if (flag175)
                                                {
                                                    _bb4.DHBA _AEM13 = _AGZ.FindPreviousNode() as _bb4.DHBA;
                                                    bool flag176 = _AEM13 != null;
                                                    if (flag176)
                                                    {
                                                        _AEM13._ACY(_AAE4);
                                                    }
                                                    return _AAE4;
                                                }
                                            }
                                        }
                                        return asMemberOf;
                                    }
                                    KJK[] array2 = new KJK[numTypeArguments];
                                    for (int num10 = 0; num10 < numTypeArguments; num10 = num6)
                                    {
                                        array2[num10] = new KJK(_AGZ.ChildAt(2 * num10 + 1));
                                        num6 = num10 + 1;
                                    }
                                    _AAK2 = _AAK2.ConstructMethodGroup(array2);
                                    bool flag177 = _BFS2 == null;
                                    if (flag177)
                                    {
                                        return _AAK2;
                                    }
                                    _bi5 _AAE5 = _BFS2._AO as _bi5;
                                    bool flag178 = _AAE5 == null;
                                    if (flag178)
                                    {
                                        return _AAK2;
                                    }
                                    _BFS2 = _AAE5.GetConstructedMember(_AAK2) as _bm7;
                                    return _BFS2 ?? _AAK2;
                                }
                            }
                            else if (num != 1888325963U)
                            {
                                if (num != 1956832512U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "brackets"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag179 = asMemberOf == null;
                                if (flag179)
                                {
                                    asMemberOf = _bh4.ResolveNode(_AGZ.FindPreviousNode(), scope, null, 0, false);
                                }
                                bool flag180 = asMemberOf != null;
                                if (flag180)
                                {
                                    _bm8 _AX = asMemberOf.TypeOf() as _bm8;
                                    bool flag181 = _AX != null && _AX._AHP != null;
                                    if (flag181)
                                    {
                                        return ((_AX._AHP.definition as _b2) ?? _bh4._AHA).GetThisInstance();
                                    }
                                    bool flag182 = _AGZ._AIX == 3;
                                    if (flag182)
                                    {
                                        _bb4._ACW _AGZ31 = _AGZ.NodeAt(1);
                                        bool flag183 = _AGZ31 != null && _AGZ31._AIX >= 1;
                                        if (flag183)
                                        {
                                            _b2[] array3 = new _b2[(int)((_AGZ31._AIX + 1) / 2)];
                                            int num6;
                                            for (int num11 = 0; num11 < array3.Length; num11 = num6)
                                            {
                                                _bh4 _AAH20 = _bh4.ResolveNode(_AGZ31.ChildAt(num11 * 2), scope, null, 0, false);
                                                bool flag184 = _AAH20 == null;
                                                if (flag184)
                                                {
                                                    goto IL_52D4;
                                                }
                                                array3[num11] = _AAH20.TypeOf() as _b2;
                                                num6 = num11 + 1;
                                            }
                                            _b2 _AAC19 = asMemberOf.TypeOf() as _b2;
                                            _bh4 _AAH21 = ((_AAC19 == null) ? null : _AAC19.GetIndexer(array3));
                                            bool flag185 = _AAH21 != null;
                                            if (flag185)
                                            {
                                                _AAC19 = _AAH21.TypeOf() as _b2;
                                                return (_AAC19 == null) ? null : _AAC19.GetThisInstance();
                                            }
                                            return _bh4._AAA;
                                        }
                                    }
                                }
                                goto IL_52D9;
                            }
                            else
                            {
                                if (!(text3 == "nonAssignmentExpression"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_4235;
                            }
                        }
                        else if (num <= 1963880416U)
                        {
                            if (num != 1958281977U)
                            {
                                if (num != 1963880416U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "localVariableType"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag186 = _AGZ._AIX == 1;
                                if (flag186)
                                {
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, false);
                                }
                                goto IL_52D9;
                            }
                            else
                            {
                                if (!(text3 == "JOIN"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_1E5E;
                            }
                        }
                        else if (num != 1974876933U)
                        {
                            if (num != 2003406594U)
                            {
                                goto IL_52D4;
                            }
                            if (!(text3 == "ORDERBY"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_1E5E;
                        }
                        else
                        {
                            if (!(text3 == "multiplicativeExpression"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_4712;
                        }
                    }
                    else if (num <= 3035179478U)
                    {
                        if (num <= 2371411181U)
                        {
                            if (num <= 2162470992U)
                            {
                                if (num <= 2095926690U)
                                {
                                    if (num != 2016976174U)
                                    {
                                        if (num != 2039056939U)
                                        {
                                            if (num != 2095926690U)
                                            {
                                                goto IL_52D4;
                                            }
                                            if (!(text3 == "argumentList"))
                                            {
                                                goto IL_52D4;
                                            }
                                            for (int num12 = 0; num12 < (int)_AGZ._AIX; num12 += 2)
                                            {
                                                _AAH3 = _bh4.ResolveNode(_AGZ.ChildAt(num12), scope, null, 0, false);
                                            }
                                            return _AAH3;
                                        }
                                        else
                                        {
                                            if (!(text3 == "constantExpression"))
                                            {
                                                goto IL_52D4;
                                            }
                                            goto IL_4235;
                                        }
                                    }
                                    else
                                    {
                                        if (!(text3 == "typeVariableName"))
                                        {
                                            goto IL_52D4;
                                        }
                                        return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false) as _bd7;
                                    }
                                }
                                else if (num <= 2115434148U)
                                {
                                    if (num != 2104842452U)
                                    {
                                        if (num != 2115434148U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "checkedExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_41B6;
                                    }
                                    else if (!(text3 == "ADD"))
                                    {
                                        goto IL_52D4;
                                    }
                                }
                                else if (num != 2120094542U)
                                {
                                    if (num != 2162470992U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "ON"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_1E5E;
                                }
                                else
                                {
                                    if (!(text3 == "YIELD"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_1E5E;
                                }
                            }
                            else if (num <= 2230359093U)
                            {
                                if (num != 2217445568U)
                                {
                                    if (num != 2227648195U)
                                    {
                                        if (num != 2230359093U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "queryExpression"))
                                        {
                                            goto IL_52D4;
                                        }
                                        _bb4._ACW _AGZ32 = _AGZ.NodeAt(1);
                                        bool flag187 = _AGZ32 != null;
                                        if (flag187)
                                        {
                                            _bb4._ACW _AGZ33 = _AGZ32.FindChildByName("selectClause") as _bb4._ACW;
                                            bool flag188 = _AGZ33 != null;
                                            if (flag188)
                                            {
                                                _bb4._ACW _AGZ34 = _AGZ33.NodeAt(1);
                                                bool flag189 = _AGZ34 != null;
                                                if (flag189)
                                                {
                                                    _bh4 _AAH22 = _bh4.ResolveNode(_AGZ34, null, null, 0, false);
                                                    bool flag190 = _AAH22 != null;
                                                    if (flag190)
                                                    {
                                                        _b2 _AAC20 = _AAH22.TypeOf() as _b2;
                                                        bool flag191 = _AAC20 != null;
                                                        if (flag191)
                                                        {
                                                            _bi5 _AAE6 = _bh4._BFJ.ConstructType(new KJK[]
                                                            {
                                                                new KJK(_AAC20)
                                                            });
                                                            return _AAE6.GetThisInstance();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        return _bh4._AAA;
                                    }
                                    else
                                    {
                                        if (!(text3 == "qidStart"))
                                        {
                                            goto IL_52D4;
                                        }
                                        bool flag192 = _AGZ._AIX == 1;
                                        if (flag192)
                                        {
                                            return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        }
                                        bool flag193 = _AGZ._AIX == 2 && _AGZ.NodeAt(1) != null;
                                        if (flag193)
                                        {
                                            _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                                            return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, (int)(_AGZ.NodeAt(1)._AIX / 2), true);
                                        }
                                        asMemberOf = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        bool flag194 = asMemberOf != null && asMemberOf._AT != SymbolKind.Error && _AGZ._AIX == 3;
                                        if (flag194)
                                        {
                                            return _bh4.ResolveNode(_AGZ.ChildAt(2), scope, asMemberOf, 0, false);
                                        }
                                        return _bh4._AAA;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "typeParameterList"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_52CF;
                                }
                            }
                            else if (num <= 2282262626U)
                            {
                                if (num != 2254452306U)
                                {
                                    if (num != 2282262626U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "implicitAnonymousFunctionParameter"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_52CF;
                                }
                                else
                                {
                                    if (!(text3 == "ASCENDING_OR_DESCENDING"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_1E5E;
                                }
                            }
                            else if (num != 2284645925U)
                            {
                                if (num != 2371411181U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "attributeArguments"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag195 = asMemberOf == null;
                                if (flag195)
                                {
                                    _bb4._AIN _AIO8 = _AGZ.FindPreviousNode();
                                    asMemberOf = _bh4.ResolveNode(_AIO8, scope, null, 0, false);
                                }
                                _bb4._ACW _AGZ35 = ((_AGZ._AIX >= 2) ? _AGZ.NodeAt(1) : null);
                                bool flag196 = _AGZ35 != null;
                                if (flag196)
                                {
                                    _bh4.ResolveNode(_AGZ35, scope, asMemberOf, 0, false);
                                }
                                return _bh4._BFY;
                            }
                            else
                            {
                                if (!(text3 == "conditionalExpression"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag197 = _AGZ._AIX >= 3;
                                if (flag197)
                                {
                                    _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                    _bh4 _AAH23 = _bh4._BFO;
                                    bool flag198 = _AGZ._AIX >= 5;
                                    if (flag198)
                                    {
                                        _AAH23 = _bh4.ResolveNode(_AGZ.ChildAt(-1), scope, null, 0, false);
                                    }
                                    _bh4 _AAH24 = _bh4.ResolveNode(_AGZ.FindChildByName("expression"), scope, null, 0, false);
                                    return (_AAH24 != _bh4._BFO) ? _AAH24 : _AAH23;
                                }
                                return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, false);
                            }
                        }
                        else if (num <= 2622508398U)
                        {
                            if (num <= 2478748789U)
                            {
                                if (num != 2388036128U)
                                {
                                    if (num != 2427029714U)
                                    {
                                        if (num != 2478748789U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "FROM"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_1E5E;
                                    }
                                    else
                                    {
                                        if (!(text3 == "ATTRIBUTETARGET"))
                                        {
                                            goto IL_52D4;
                                        }
                                        goto IL_1E5E;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "numericType"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_238F;
                                }
                            }
                            else if (num <= 2531704439U)
                            {
                                if (num != 2489527780U)
                                {
                                    if (num != 2531704439U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "GET"))
                                    {
                                        goto IL_52D4;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "localVariableInitializer"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_4235;
                                }
                            }
                            else if (num != 2590802725U)
                            {
                                if (num != 2622508398U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "typeName"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_238F;
                            }
                            else
                            {
                                if (!(text3 == "primaryExpressionStart"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag199 = _AGZ._AIX == 1;
                                if (flag199)
                                {
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                }
                                bool flag200 = _AGZ._AIX == 2;
                                if (flag200)
                                {
                                    _bb4._ACW _AGZ36 = _AGZ.NodeAt(1);
                                    bool flag201 = _AGZ36 != null && _AGZ36._AHB() == "typeArgumentList";
                                    if (flag201)
                                    {
                                        numTypeArguments = (int)(_AGZ36._AIX / 2);
                                    }
                                    asMemberOf = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, numTypeArguments, false);
                                    bool flag202 = asMemberOf is _b2;
                                    if (flag202)
                                    {
                                        return _bh4.ResolveNode(_AGZ36, scope, asMemberOf, 0, false);
                                    }
                                    return asMemberOf;
                                }
                                else
                                {
                                    bool flag203 = _AGZ._AIX == 3;
                                    if (flag203)
                                    {
                                        _AAH2 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        return _bh4.ResolveNode(_AGZ.ChildAt(2), scope, _AAH2, 0, false);
                                    }
                                    goto IL_52D9;
                                }
                            }
                        }
                        else if (num <= 2938262002U)
                        {
                            if (num <= 2909293537U)
                            {
                                if (num != 2880676846U)
                                {
                                    if (num != 2909293537U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "memberInitializer"))
                                    {
                                        goto IL_52D4;
                                    }
                                    _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                    bool flag204 = _AGZ._AIX == 3;
                                    if (flag204)
                                    {
                                        _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                    }
                                    return null;
                                }
                                else
                                {
                                    if (!(text3 == "attributeMemberName"))
                                    {
                                        goto IL_52D4;
                                    }
                                    _b2 _AAC21 = asMemberOf as _b2;
                                    bool flag205 = _AAC21 != null;
                                    if (flag205)
                                    {
                                        return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, _AAC21.GetThisInstance(), 0, false);
                                    }
                                    return _bh4._AAA;
                                }
                            }
                            else if (num != 2909992379U)
                            {
                                if (num != 2938262002U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "unaryExpression"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag206 = _AGZ._AIX == 1;
                                if (flag206)
                                {
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                }
                                bool flag207 = _AGZ.ChildAt(0) is _bb4._ACW;
                                if (flag207)
                                {
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                }
                                return _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                            }
                            else
                            {
                                if (!(text3 == "floatingPointType"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_238F;
                            }
                        }
                        else if (num <= 3015329114U)
                        {
                            if (num != 2967425815U)
                            {
                                if (num != 3015329114U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "inclusiveOrExpression"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_4712;
                            }
                            else
                            {
                                if (!(text3 == "argumentValue"))
                                {
                                    goto IL_52D4;
                                }
                                return _bh4.ResolveNode(_AGZ.ChildAt(-1), scope, null, 0, false);
                            }
                        }
                        else if (num != 3022600877U)
                        {
                            if (num != 3035179478U)
                            {
                                goto IL_52D4;
                            }
                            if (!(text3 == "conditionalAndExpression"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_4C86;
                        }
                        else
                        {
                            if (!(text3 == "SELECT"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_1E5E;
                        }
                    }
                    else if (num <= 3544547290U)
                    {
                        if (num <= 3366671281U)
                        {
                            if (num <= 3119263074U)
                            {
                                if (num != 3093954077U)
                                {
                                    if (num != 3118184253U)
                                    {
                                        if (num != 3119263074U)
                                        {
                                            goto IL_52D4;
                                        }
                                        if (!(text3 == "primaryExpressionPart"))
                                        {
                                            goto IL_52D4;
                                        }
                                        bool flag208 = asMemberOf == null;
                                        if (flag208)
                                        {
                                            asMemberOf = _bh4.ResolveNode(_AGZ.FindPreviousNode(), scope, null, 0, false);
                                            bool flag209 = asMemberOf != null && asMemberOf._AT == SymbolKind.Method;
                                            if (flag209)
                                            {
                                                asMemberOf = asMemberOf.TypeOf();
                                            }
                                        }
                                        bool flag210 = asMemberOf != null;
                                        if (flag210)
                                        {
                                            return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, false);
                                        }
                                        goto IL_52D9;
                                    }
                                    else if (!(text3 == "REMOVE"))
                                    {
                                        goto IL_52D4;
                                    }
                                }
                                else
                                {
                                    if (!(text3 == "elementInitializer"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_52CF;
                                }
                            }
                            else if (num <= 3319310467U)
                            {
                                if (num != 3253591965U)
                                {
                                    if (num != 3319310467U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "sizeofExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag211 = _AGZ._AIX >= 3;
                                    if (flag211)
                                    {
                                        _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                    }
                                    return _bh4._AAQ.GetThisInstance();
                                }
                                else
                                {
                                    if (!(text3 == "globalNamespace"))
                                    {
                                        goto IL_52D4;
                                    }
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                }
                            }
                            else if (num != 3335511552U)
                            {
                                if (num != 3366671281U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "typeOrGeneric"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag212 = asMemberOf == null && _AGZ._AIL > 0;
                                if (flag212)
                                {
                                    asMemberOf = _bh4.ResolveNode(_AGZ.OOME.ChildAt((int)(_AGZ._AIL - 2)), scope, null, 0, true);
                                }
                                bool flag213 = _AGZ._AIX >= 2;
                                if (flag213)
                                {
                                    _bb4._ACW _AGZ37 = _AGZ.NodeAt(1);
                                    bool flag214 = _AGZ37 != null && _AGZ37._AIX > 0;
                                    if (flag214)
                                    {
                                        bool flag215 = _AGZ37._AHB() == "unboundTypeRank";
                                        int num13 = (int)(flag215 ? (_AGZ37._AIX - 1) : (_AGZ37._AIX / 2));
                                        _bc6 _AHD4 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, num13, true) as _bc6;
                                        bool flag216 = _AHD4 == null;
                                        if (flag216)
                                        {
                                            return _AGZ.ChildAt(0)._AAB();
                                        }
                                        bool flag217 = !flag215;
                                        if (flag217)
                                        {
                                            KJK[] array4 = new KJK[num13];
                                            int num6;
                                            for (int num14 = 0; num14 < num13; num14 = num6)
                                            {
                                                array4[num14] = new KJK(_AGZ37.ChildAt(1 + 2 * num14));
                                                num6 = num14 + 1;
                                            }
                                            bool flag218 = _AHD4._AHL != null && _AHD4._AHL.Count == num13;
                                            if (flag218)
                                            {
                                                _bi5 _AAE7 = _AHD4.ConstructType(array4);
                                                _AGZ.ChildAt(0)._ACY(_AAE7);
                                                return _AAE7;
                                            }
                                        }
                                        return _AHD4;
                                    }
                                }
                                else
                                {
                                    bool flag219 = scope is _bk7 && _AGZ._AIL == _AGZ.OOME._AIX - 1 && _AGZ.OOME.OOME.OOME._AHB() == "attribute";
                                    if (flag219)
                                    {
                                        _bb4.DHBA _AEM14 = _AGZ.LeafAt(0);
                                        bool flag220 = asMemberOf != null;
                                        if (flag220)
                                        {
                                            asMemberOf.ResolveAttributeMember(_AEM14, scope);
                                        }
                                        else
                                        {
                                            scope.ResolveAttribute(_AEM14);
                                        }
                                        bool flag221 = _AEM14._AAB() == null;
                                        if (flag221)
                                        {
                                            _AEM14._ACY(_bh4._AAA);
                                            _AEM14._AJF = _bh4._AAA._AW;
                                        }
                                        return _AEM14._AAB();
                                    }
                                }
                                return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, true);
                            }
                            else
                            {
                                if (!(text3 == "accessIdentifier"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag222 = asMemberOf == null;
                                if (flag222)
                                {
                                    asMemberOf = _bh4.ResolveNode(_AGZ.FindPreviousNode(), scope, null, 0, false);
                                    bool flag223 = asMemberOf != null && asMemberOf._AT == SymbolKind.Method;
                                    if (flag223)
                                    {
                                        asMemberOf = asMemberOf.TypeOf();
                                    }
                                }
                                bool flag224 = _AGZ._AIX == 2;
                                if (flag224)
                                {
                                    _bb4._AIN _AIO9 = _AGZ.ChildAt(1);
                                    bool flag225 = !_AIO9._AJC;
                                    if (flag225)
                                    {
                                        return _bh4.ResolveNode(_AGZ.ChildAt(1), scope, asMemberOf, 0, false);
                                    }
                                }
                                else
                                {
                                    bool flag226 = _AGZ._AIX == 3;
                                    if (flag226)
                                    {
                                        _bb4._ACW _AGZ38 = _AGZ.NodeAt(2);
                                        bool flag227 = _AGZ38 != null && _AGZ38._AHB() == "typeArgumentList";
                                        if (flag227)
                                        {
                                            numTypeArguments = (int)(_AGZ38._AIX / 2);
                                        }
                                        asMemberOf = _bh4.ResolveNode(_AGZ.ChildAt(1), scope, asMemberOf, numTypeArguments, false);
                                        return _bh4.ResolveNode(_AGZ38, scope, asMemberOf, 0, false);
                                    }
                                }
                                return asMemberOf;
                            }
                        }
                        else if (num <= 3439399365U)
                        {
                            if (num != 3381351465U)
                            {
                                if (num != 3433102825U)
                                {
                                    if (num != 3439399365U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "explicitAnonymousFunctionParameterList"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_52CF;
                                }
                                else
                                {
                                    if (!(text3 == "arrayCreationExpression"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag228 = asMemberOf == null;
                                    if (flag228)
                                    {
                                        asMemberOf = _bh4.ResolveNode(_AGZ.FindPreviousNode(), null, null, 0, false);
                                    }
                                    _b2 _AAC8 = asMemberOf as _b2;
                                    bool flag229 = _AAC8 == null;
                                    if (flag229)
                                    {
                                        return _bh4._AHA.MakeArrayType(1);
                                    }
                                    _bb4._ACW _AGZ39 = _AGZ.FindChildByName("rankSpecifiers") as _bb4._ACW;
                                    bool flag230 = _AGZ39 == null || _AGZ39._AIL > 0;
                                    if (flag230)
                                    {
                                        _bb4._ACW _AGZ40 = _AGZ.NodeAt(1);
                                        bool flag231 = _AGZ40 != null && _AGZ40._AHB() == "expressionList";
                                        if (flag231)
                                        {
                                            _AAC8 = _AAC8.MakeArrayType((int)(1 + _AGZ40._AIX / 2));
                                        }
                                    }
                                    bool flag232 = _AGZ39 != null && _AGZ39._AIX != 0;
                                    if (flag232)
                                    {
                                        for (int num15 = 1; num15 < (int)_AGZ39._AIX; num15 += 2)
                                        {
                                            int num2 = 1;
                                            while (num15 < (int)_AGZ39._AIX && _AGZ39.ChildAt(num15).IsLit(","))
                                            {
                                                int num6 = num2 + 1;
                                                num2 = num6;
                                                num6 = num15 + 1;
                                                num15 = num6;
                                            }
                                            _AAC8 = _AAC8.MakeArrayType(num2);
                                        }
                                    }
                                    _bb4._ACW _AGZ16 = _AGZ.NodeAt(-1);
                                    bool flag233 = _AGZ16 != null && _AGZ16._AHB() == "arrayInitializer";
                                    if (flag233)
                                    {
                                        _bh4.ResolveNode(_AGZ16, null, null, 0, false);
                                    }
                                    return (_AAC8 ?? _bh4._AHA).GetThisInstance();
                                }
                            }
                            else
                            {
                                if (!(text3 == "shiftExpression"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_4712;
                            }
                        }
                        else if (num <= 3474305003U)
                        {
                            if (num != 3460058757U)
                            {
                                if (num != 3474305003U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "expression"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_4235;
                            }
                            else
                            {
                                if (!(text3 == "methodHeader"))
                                {
                                    goto IL_52D4;
                                }
                                goto IL_52CF;
                            }
                        }
                        else if (num != 3486280120U)
                        {
                            if (num != 3544547290U)
                            {
                                goto IL_52D4;
                            }
                            if (!(text3 == "LET"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_1E5E;
                        }
                        else
                        {
                            if (!(text3 == "WHERE"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_1E5E;
                        }
                    }
                    else if (num <= 3920802870U)
                    {
                        if (num <= 3806680326U)
                        {
                            if (num != 3549306485U)
                            {
                                if (num != 3773347596U)
                                {
                                    if (num != 3806680326U)
                                    {
                                        goto IL_52D4;
                                    }
                                    if (!(text3 == "exceptionClassType"))
                                    {
                                        goto IL_52D4;
                                    }
                                    goto IL_238F;
                                }
                                else
                                {
                                    if (!(text3 == "attributeArgument"))
                                    {
                                        goto IL_52D4;
                                    }
                                    bool flag234 = _AGZ._AIX >= 1;
                                    if (flag234)
                                    {
                                        bool flag235 = _AGZ._AIX == 1;
                                        if (flag235)
                                        {
                                            return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                        }
                                        _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, false);
                                    }
                                    bool flag236 = _AGZ._AIX == 3;
                                    if (flag236)
                                    {
                                        return _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                                    }
                                    return _bh4._BFY;
                                }
                            }
                            else
                            {
                                if (!(text3 == "argumentName"))
                                {
                                    goto IL_52D4;
                                }
                                _bb4.DHBA _AEM15 = _AGZ.LeafAt(0);
                                bool flag237 = _AEM15 == null;
                                if (flag237)
                                {
                                    return _bh4._AAA;
                                }
                                _bb4._ACW _AMI = _AGZ.OOME.OOME.OOME;
                                _bb4._AIN _AIO10 = _AMI.FindPreviousNode();
                                _bh4 resolvedSymbol = _bc9.GetResolvedSymbol(_AIO10);
                                _ba7 _AAK = resolvedSymbol as _ba7;
                                bool flag238 = _AAK != null;
                                if (flag238)
                                {
                                    return _AAK.ResolveParameterName(_AEM15);
                                }
                                _bf1 hpomlclippdnpjciibilcalngekicmmdifhn = resolvedSymbol as _bf1;
                                bool flag239 = hpomlclippdnpjciibilcalngekicmmdifhn != null;
                                if (flag239)
                                {
                                    return hpomlclippdnpjciibilcalngekicmmdifhn.ResolveParameterName(_AEM15);
                                }
                                _AEM15._ACY(_AAH25 = _bh4._AAA);
                                return _AAH25;
                            }
                        }
                        else if (num <= 3894489210U)
                        {
                            if (num != 3836030979U)
                            {
                                if (num != 3894489210U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "arrayInitializer"))
                                {
                                    goto IL_52D4;
                                }
                                bool flag240 = _AGZ._AIX >= 2;
                                if (flag240)
                                {
                                    bool flag241 = !_AGZ.ChildAt(1).IsLit("}");
                                    if (flag241)
                                    {
                                        return _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                                    }
                                }
                                return _bh4._AHA;
                            }
                            else
                            {
                                if (!(text3 == "namespaceName"))
                                {
                                    goto IL_52D4;
                                }
                                _bh4 _AAH26 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, 0, true);
                                bool flag242 = _AAH26 != null && _AAH26._AT != SymbolKind.Error && !(_AAH26 is _bn1);
                                if (flag242)
                                {
                                    _AGZ.ChildAt(0)._AJF = "Namespace name expected";
                                }
                                return _AAH26;
                            }
                        }
                        else if (num != 3919423225U)
                        {
                            if (num != 3920802870U)
                            {
                                goto IL_52D4;
                            }
                            if (!(text3 == "argument"))
                            {
                                goto IL_52D4;
                            }
                            bool flag243 = _AGZ._AIX >= 1;
                            if (flag243)
                            {
                                bool flag244 = _AGZ._AIX == 1;
                                if (flag244)
                                {
                                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                                }
                                _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                            }
                            bool flag245 = _AGZ._AIX == 3;
                            if (flag245)
                            {
                                return _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                            }
                            return _bh4._BFY;
                        }
                        else
                        {
                            if (!(text3 == "preIncrementExpression"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_46D3;
                        }
                    }
                    else if (num <= 4055318312U)
                    {
                        if (num <= 4009610321U)
                        {
                            if (num != 3963074971U)
                            {
                                if (num != 4009610321U)
                                {
                                    goto IL_52D4;
                                }
                                if (!(text3 == "qid"))
                                {
                                    goto IL_52D4;
                                }
                                int num6;
                                for (int num16 = 0; num16 < (int)(_AGZ._AIX - 1); num16 = num6 + 1)
                                {
                                    asMemberOf = _bh4.ResolveNode(_AGZ.ChildAt(num16), scope, asMemberOf, 0, false);
                                    bool flag246 = asMemberOf == null || asMemberOf._AT == SymbolKind.Error;
                                    if (flag246)
                                    {
                                        break;
                                    }
                                    num6 = num16;
                                }
                                bool flag247 = _AGZ._AIX == 1 && _AGZ.NodeAt(0)._AIX == 3;
                                if (flag247)
                                {
                                    asMemberOf = _bh4.ResolveNode(_AGZ.NodeAt(0).ChildAt(0), scope, null, 0, false);
                                }
                                return asMemberOf ?? _bh4._AAA;
                            }
                            else
                            {
                                if (!(text3 == "variableInitializer"))
                                {
                                    goto IL_52D4;
                                }
                                return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                            }
                        }
                        else if (num != 4024465044U)
                        {
                            if (num != 4055318312U)
                            {
                                goto IL_52D4;
                            }
                            if (!(text3 == "anonymousFunctionSignature"))
                            {
                                goto IL_52D4;
                            }
                            goto IL_52CF;
                        }
                        else
                        {
                            if (!(text3 == "attributeArgumentList"))
                            {
                                goto IL_52D4;
                            }
                            for (int num17 = 0; num17 < (int)_AGZ._AIX; num17 += 2)
                            {
                                _AAH3 = _bh4.ResolveNode(_AGZ.ChildAt(num17), scope, asMemberOf, 0, false);
                            }
                            return _bh4._BFY;
                        }
                    }
                    else if (num <= 4187448189U)
                    {
                        if (num != 4094101544U)
                        {
                            if (num != 4187448189U)
                            {
                                goto IL_52D4;
                            }
                            if (!(text3 == "destructorDeclarator"))
                            {
                                goto IL_52D4;
                            }
                            return _bh4._BFU;
                        }
                        else
                        {
                            if (!(text3 == "memberName"))
                            {
                                goto IL_52D4;
                            }
                            _AFF = null;
                            while (_AFF == null && _AGZ != null)
                            {
                                _AFF = _AGZ.EFI;
                                _AGZ = _AGZ.OOME;
                            }
                            bool flag248 = _AFF == null;
                            if (flag248)
                            {
                                return _bh4._AAA;
                            }
                            return _AFF._ACV;
                        }
                    }
                    else if (num != 4219338552U)
                    {
                        if (num != 4233109569U)
                        {
                            goto IL_52D4;
                        }
                        if (!(text3 == "booleanExpression"))
                        {
                            goto IL_52D4;
                        }
                        _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                        return _bh4._BFP;
                    }
                    else
                    {
                        if (!(text3 == "lambdaExpression"))
                        {
                            goto IL_52D4;
                        }
                        _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                        _bn4 _AQH = _AGZ._AJW as _bn4;
                        bool flag249 = _AQH != null && _AQH.EFI != null;
                        if (flag249)
                        {
                            return _AQH.EFI._ACV;
                        }
                        return _bh4._AAA;
                    }
                IL_1DE9:
                    _AFF = null;
                    _bb4._ACW _AGZ41 = _AGZ;
                    while (_AFF == null && _AGZ41 != null)
                    {
                        _AFF = _AGZ41.EFI;
                        _AGZ41 = _AGZ41.OOME;
                    }
                    bool flag250 = _AFF == null;
                    if (flag250)
                    {
                        _AGZ.ChildAt(0)._ACY(_AAH25 = _bh4._AAA);
                        return _AAH25;
                    }
                    _AGZ.ChildAt(0)._ACY(_AAH25 = _AFF._ACV);
                    return _AAH25;
                IL_1E5E:
                    _AGZ.ChildAt(0)._ACY(_bh4._BDH);
                    return _bh4._BDH;
                IL_238F:
                    _bh4 _AAH27 = _bh4.ResolveNode(_AGZ.ChildAt(0), scope, asMemberOf, numTypeArguments, true);
                    bool flag251 = _AAH27 != null && _AAH27._AT != SymbolKind.Error && !(_AAH27 is _b2);
                    if (flag251)
                    {
                        _AGZ.GetFirstLeaf()._AJF = "Type expected";
                    }
                    return _AAH27;
                IL_41B6:
                    bool flag252 = _AGZ._AIX >= 3;
                    if (flag252)
                    {
                        return _bh4.ResolveNode(_AGZ.ChildAt(2), scope, null, 0, false);
                    }
                    return _bh4._AAA;
                IL_4235:
                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                IL_46D3:
                    bool flag253 = _AGZ._AIX == 2;
                    if (flag253)
                    {
                        return _bh4.ResolveNode(_AGZ.ChildAt(1), scope, null, 0, false);
                    }
                    return _bh4._AAQ.GetThisInstance();
                IL_4712:
                    for (int num18 = 2; num18 < (int)_AGZ._AIX; num18 += 2)
                    {
                        _bh4.ResolveNode(_AGZ.ChildAt(num18), scope, null, 0, false);
                    }
                    return _bh4.ResolveNode(_AGZ.ChildAt(0), scope, null, 0, false);
                IL_4C86:
                    bool flag254 = _AGZ._AIX == 1;
                    if (flag254)
                    {
                        _AGZ = _AGZ.NodeAt(0);
                        goto IL_4712;
                    }
                    for (int num19 = 0; num19 < (int)_AGZ._AIX; num19 += 2)
                    {
                        _bh4.ResolveNode(_AGZ.ChildAt(num19), scope, null, 0, false);
                    }
                    return _bh4._BFP;
                IL_52CF:
                    return null;
                IL_52D4:
                    return null;
                IL_52D9:
                    _AAH = null;
                }
            }
            return _AAH;
        }

        // Token: 0x06000611 RID: 1553 RVA: 0x000E2614 File Offset: 0x000E0814
        protected virtual _bh4 GetIndexer(_b2[] argumentTypes)
        {
            return null;
        }

        // Token: 0x06000612 RID: 1554 RVA: 0x000E2628 File Offset: 0x000E0828
        internal virtual _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            memberName = _bh4.DecodeId(memberName);
            _bh4 _AAH;
            bool flag = !this._AAG.TryGetValue(memberName, numTypeParameters, out _AAH);
            _bh4 _AAH2;
            if (flag)
            {
                _AAH2 = null;
            }
            else
            {
                bool flag2 = asTypeOnly && _AAH != null && _AAH._AT != SymbolKind.Namespace && !(_AAH is _b2);
                if (flag2)
                {
                    _AAH2 = null;
                }
                else
                {
                    _AAH2 = _AAH;
                }
            }
            return _AAH2;
        }

        // Token: 0x06000613 RID: 1555 RVA: 0x000E2684 File Offset: 0x000E0884
        internal virtual void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            List<_bd7> typeParameters = this.GetTypeParameters();
            bool flag = typeParameters != null;
            if (flag)
            {
                for (int i = 0; i < typeParameters.Count; i++)
                {
                    _bd7 _AHM = typeParameters[i];
                    bool flag2 = !data.ContainsKey(_AHM._AW);
                    if (flag2)
                    {
                        data.Add(_AHM._AW, _AHM);
                    }
                }
            }
            this.GetMembersCompletionData(data, context._APW ? BindingFlags.Default : BindingFlags.Static, AccessLevelMask.Any, context);
        }

        // Token: 0x06000614 RID: 1556 RVA: 0x000E2700 File Offset: 0x000E0900
        internal virtual void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            bool flag = (mask & AccessLevelMask.Public) > AccessLevelMask.None;
            if (flag)
            {
                bool flag2 = context._AN.InternalsVisibleIn(this.Assembly);
                if (flag2)
                {
                    mask |= AccessLevelMask.Internal;
                }
                else
                {
                    mask &= ~AccessLevelMask.Internal;
                }
            }
            flags &= BindingFlags.Instance | BindingFlags.Static;
            bool flag3 = flags == BindingFlags.Static;
            bool flag4 = flags == BindingFlags.Instance;
            for (int i = 0; i < this._AAG.Count; i++)
            {
                _bh4 _AAH = this._AAG._AAI(i);
                bool flag5 = _AAH._AT == SymbolKind.Namespace;
                if (flag5)
                {
                    bool flag6 = !data.ContainsKey(_AAH._AP());
                    if (flag6)
                    {
                        data.Add(_AAH._AP(), _AAH);
                    }
                }
                else
                {
                    bool flag7 = _AAH._AT != SymbolKind.MethodGroup;
                    if (flag7)
                    {
                        bool flag8 = (flag3 ? (!_AAH.PJOINCMEBNKJCMPMCNPDBKOIJCGMPJPLOEFJ()) : (!flag4 || _AAH.PJOINCMEBNKJCMPMCNPDBKOIJCGMPJPLOEFJ())) && _AAH.IsAccessible(mask) && _AAH._AT != SymbolKind.Constructor && _AAH._AT != SymbolKind.Destructor && _AAH._AT != SymbolKind.Indexer && !data.ContainsKey(_AAH._AP());
                        if (flag8)
                        {
                            data.Add(_AAH._AP(), _AAH);
                        }
                    }
                    else
                    {
                        _ba7 _AAK = _AAH as _ba7;
                        foreach (_bb3 _AAN in _AAK._AAM)
                        {
                            bool flag9 = (flag3 ? _AAN.IsStatic : (!flag4 || !_AAN.IsStatic)) && _AAN.IsAccessible(mask) && _AAN._AT != SymbolKind.Constructor && _AAN._AT != SymbolKind.Destructor && _AAN._AT != SymbolKind.Indexer && !data.ContainsKey(_AAH._AP());
                            if (flag9)
                            {
                                data.Add(_AAH._AP(), _AAN);
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000615 RID: 1557 RVA: 0x000E291C File Offset: 0x000E0B1C
        public bool PJOINCMEBNKJCMPMCNPDBKOIJCGMPJPLOEFJ()
        {
            return !this.IsStatic && this._AT != SymbolKind.ConstantField && !(this is _b2);
        }

        // Token: 0x06000616 RID: 1558 RVA: 0x000E2950 File Offset: 0x000E0B50
        public bool CCHFDEPNIEOKILOEBJANDNGJDJMHMHJHAEEC()
        {
            return (this._AV & Modifiers.Sealed) > Modifiers.None;
        }

        // Token: 0x1700002B RID: 43
        // (get) Token: 0x06000617 RID: 1559 RVA: 0x000E2970 File Offset: 0x000E0B70
        // (set) Token: 0x06000618 RID: 1560 RVA: 0x000E2990 File Offset: 0x000E0B90
        internal virtual bool IsStatic
        {
            get
            {
                return (this._AV & Modifiers.Static) > Modifiers.None;
            }
            set
            {
                if (value)
                {
                    this._AV |= Modifiers.Static;
                }
                else
                {
                    this._AV &= ~Modifiers.Static;
                }
            }
        }

        // Token: 0x06000619 RID: 1561 RVA: 0x000E29C4 File Offset: 0x000E0BC4
        public bool _AFH()
        {
            return (this._AV & Modifiers.Public) != Modifiers.None || this._AT == SymbolKind.Namespace || (this._AO != null && ((this._AO._AO != null && (this._AT == SymbolKind.Method || this._AT == SymbolKind.Indexer) && this._AO._AO._AT == SymbolKind.Interface) || ((this._AT == SymbolKind.Property || this._AT == SymbolKind.Event) && this._AO._AT == SymbolKind.Interface)));
        }

        // Token: 0x0600061A RID: 1562 RVA: 0x000E2A54 File Offset: 0x000E0C54
        public void _CAN(bool value)
        {
            if (value)
            {
                this._AV |= Modifiers.Public;
            }
            else
            {
                this._AV &= ~Modifiers.Public;
            }
        }

        // Token: 0x0600061B RID: 1563 RVA: 0x000E2A88 File Offset: 0x000E0C88
        public bool _AFI()
        {
            return (this._AV & Modifiers.Internal) != Modifiers.None || (this._AT != SymbolKind.Namespace && (this._AV & Modifiers.Public) == Modifiers.None && this._AO != null && this._AO._AT == SymbolKind.Namespace);
        }

        // Token: 0x0600061C RID: 1564 RVA: 0x000E2AD4 File Offset: 0x000E0CD4
        public void _CAP(bool value)
        {
            if (value)
            {
                this._AV |= Modifiers.Internal;
            }
            else
            {
                this._AV &= ~Modifiers.Internal;
            }
        }

        // Token: 0x0600061D RID: 1565 RVA: 0x000E2B08 File Offset: 0x000E0D08
        public bool _AFJ()
        {
            return (this._AV & Modifiers.Protected) > Modifiers.None;
        }

        // Token: 0x0600061E RID: 1566 RVA: 0x000E2B28 File Offset: 0x000E0D28
        public void _CAO(bool value)
        {
            if (value)
            {
                this._AV |= Modifiers.Protected;
            }
            else
            {
                this._AV &= ~Modifiers.Protected;
            }
        }

        // Token: 0x0600061F RID: 1567 RVA: 0x000E2B5C File Offset: 0x000E0D5C
        public bool PGIPEAHFGPPKEMGFLHBIMNOONGJMJEFBMIJG()
        {
            return (this._AV & (Modifiers.Public | Modifiers.Internal | Modifiers.Protected)) == Modifiers.None;
        }

        // Token: 0x06000620 RID: 1568 RVA: 0x000E2B7C File Offset: 0x000E0D7C
        public bool _AAP()
        {
            return (this._AV & Modifiers.Abstract) > Modifiers.None;
        }

        // Token: 0x06000621 RID: 1569 RVA: 0x000E2BA0 File Offset: 0x000E0DA0
        public void HHKKKHOOMJJBAJDEHGFJJEHGHMLFBNEGFKOH(bool value)
        {
            if (value)
            {
                this._AV |= Modifiers.Abstract;
            }
            else
            {
                this._AV &= ~Modifiers.Abstract;
            }
        }

        // Token: 0x06000622 RID: 1570 RVA: 0x000E2BDC File Offset: 0x000E0DDC
        public bool _AQL()
        {
            return (this._AV & Modifiers.Partial) > Modifiers.None;
        }

        // Token: 0x1700002C RID: 44
        // (get) Token: 0x06000623 RID: 1571 RVA: 0x000E2C00 File Offset: 0x000E0E00
        public _bj5 Assembly
        {
            get
            {
                for (_bh4 _AAH = this; _AAH != null; _AAH = _AAH._AO)
                {
                    _bj5 _AOS = _AAH as _bj5;
                    bool flag = _AOS != null;
                    if (flag)
                    {
                        return _AOS;
                    }
                }
                return null;
            }
        }

        // Token: 0x06000624 RID: 1572 RVA: 0x000E2C40 File Offset: 0x000E0E40
        internal virtual bool IsSameType(_b2 type)
        {
            return type == this;
        }

        // Token: 0x06000625 RID: 1573 RVA: 0x000E2C58 File Offset: 0x000E0E58
        public bool IsSameOrParentOf(_b2 type)
        {
            _bi5 _AAE = this as _bi5;
            _bh4 _AAH = ((_AAE != null) ? _AAE._AAF() : this);
            while (type != null)
            {
                bool flag = type == _AAH;
                if (flag)
                {
                    return true;
                }
                _AAE = type as _bi5;
                type = ((_AAE != null) ? _AAE._AAF() : type)._AO as _b2;
            }
            return false;
        }

        // Token: 0x06000626 RID: 1574 RVA: 0x000E2CB8 File Offset: 0x000E0EB8
        internal virtual _b2 TypeOfTypeParameter(_bd7 tp)
        {
            bool flag = this._AO != null;
            _b2 _AAC;
            if (flag)
            {
                _AAC = this._AO.TypeOfTypeParameter(tp);
            }
            else
            {
                _AAC = tp;
            }
            return _AAC;
        }

        // Token: 0x06000627 RID: 1575 RVA: 0x000E2CE8 File Offset: 0x000E0EE8
        internal virtual bool IsAccessible(AccessLevelMask accessLevelMask)
        {
            bool flag = accessLevelMask == AccessLevelMask.None;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = this._AFH();
                if (flag3)
                {
                    flag2 = true;
                }
                else
                {
                    bool flag4 = this._AFJ() && (accessLevelMask & AccessLevelMask.Protected) > AccessLevelMask.None;
                    if (flag4)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        bool flag5 = this._AFI() && (accessLevelMask & AccessLevelMask.Internal) > AccessLevelMask.None;
                        flag2 = flag5 || (accessLevelMask & AccessLevelMask.Private) > AccessLevelMask.None;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x06000628 RID: 1576 RVA: 0x000E2D50 File Offset: 0x000E0F50
        public int _AHG()
        {
            List<_bd7> typeParameters = this.GetTypeParameters();
            return (typeParameters != null) ? typeParameters.Count : 0;
        }

        // Token: 0x06000629 RID: 1577 RVA: 0x000E2D78 File Offset: 0x000E0F78
        public int _ABC()
        {
            List<_bm1> parameters = this.GetParameters();
            return (parameters != null) ? parameters.Count : 0;
        }

        // Token: 0x04000537 RID: 1335
        public static readonly _bh4 _BFY = new _bh4
        {
            _AT = SymbolKind.None
        };

        // Token: 0x04000538 RID: 1336
        public static readonly _bh4 _BFO = new _bl6
        {
            _AT = SymbolKind.Null
        };

        // Token: 0x04000539 RID: 1337
        public static readonly _bh4 _BDH = new _bh4
        {
            _AT = SymbolKind.Null
        };

        // Token: 0x0400053A RID: 1338
        public static readonly _bc6 _AHA = new _bc6
        {
            _AW = "unknown type",
            _AT = SymbolKind.Error
        };

        // Token: 0x0400053B RID: 1339
        public static readonly _bc6 _APG = new _bc6
        {
            _AW = "circular base type",
            _AT = SymbolKind.Error
        };

        // Token: 0x0400053C RID: 1340
        public static readonly _bh4 _AAA = new _bh4
        {
            _AW = "unknown symbol",
            _AT = SymbolKind.Error
        };

        // Token: 0x0400053D RID: 1341
        public static readonly _bh4 _AGT = new _bh4
        {
            _AW = "unknown parameter name",
            _AT = SymbolKind.Error
        };

        // Token: 0x0400053E RID: 1342
        public static readonly _bh4 _BFR = new _bh4
        {
            _AW = "cannot use 'this' in static member",
            _AT = SymbolKind.Error
        };

        // Token: 0x0400053F RID: 1343
        public static readonly _bh4 _BFQ = new _bh4
        {
            _AW = "cannot use 'base' in static member",
            _AT = SymbolKind.Error
        };

        // Token: 0x04000540 RID: 1344
        protected static readonly List<_bm1> _AHV = new List<_bm1>();

        // Token: 0x04000541 RID: 1345
        protected static readonly List<KJK> _AR = new List<KJK>();

        // Token: 0x04000542 RID: 1346
        public SymbolKind _AT;

        // Token: 0x04000543 RID: 1347
        public string _AW;

        // Token: 0x04000544 RID: 1348
        public Texture2D _AFG;

        // Token: 0x04000545 RID: 1349
        public _bh4 _AO;

        // Token: 0x04000546 RID: 1350
        public _bh4 _AGU;

        // Token: 0x04000547 RID: 1351
        public Modifiers _AV;

        // Token: 0x04000548 RID: 1352
        public AccessLevel _AU;

        // Token: 0x04000549 RID: 1353
        public List<FKI> _AEI;

        // Token: 0x0400054A RID: 1354
        public _bh4._CAT _AAG = default(_bh4._CAT);

        // Token: 0x0400054B RID: 1355
        public static Dictionary<Type, _be8> _BEJ = new Dictionary<Type, _be8>();

        // Token: 0x0400054C RID: 1356
        protected string _APK;

        // Token: 0x0400054D RID: 1357
        private bool _BEP;

        // Token: 0x0400054E RID: 1358
        internal bool _BER = false;

        // Token: 0x0400054F RID: 1359
        internal Action _BEQ;

        // Token: 0x04000550 RID: 1360
        private XmlDocument _BEW = new XmlDocument();

        // Token: 0x04000551 RID: 1361
        private string _BEV = string.Empty;

        // Token: 0x04000552 RID: 1362
        private string _BEU = string.Empty;

        // Token: 0x04000553 RID: 1363
        private static Dictionary<string, List<_bb3>> _BFB;

        // Token: 0x04000554 RID: 1364
        public static Dictionary<string, _b2> _ABO;

        // Token: 0x04000555 RID: 1365
        public static _bc6 _AAQ;

        // Token: 0x04000556 RID: 1366
        public static _bc6 _AAU;

        // Token: 0x04000557 RID: 1367
        public static _bc6 _AAW;

        // Token: 0x04000558 RID: 1368
        public static _bc6 _AAZ;

        // Token: 0x04000559 RID: 1369
        public static _bc6 _AAX;

        // Token: 0x0400055A RID: 1370
        public static _bc6 _AAY;

        // Token: 0x0400055B RID: 1371
        public static _bc6 _AAR;

        // Token: 0x0400055C RID: 1372
        public static _bc6 _AAV;

        // Token: 0x0400055D RID: 1373
        public static _bc6 _AAS;

        // Token: 0x0400055E RID: 1374
        public static _bc6 _AAT;

        // Token: 0x0400055F RID: 1375
        public static _bc6 _BFC;

        // Token: 0x04000560 RID: 1376
        public static _bc6 _ABA;

        // Token: 0x04000561 RID: 1377
        public static _bc6 _BFD;

        // Token: 0x04000562 RID: 1378
        public static _bc6 _BFP;

        // Token: 0x04000563 RID: 1379
        public static _bc6 _AS;

        // Token: 0x04000564 RID: 1380
        public static _bc6 _BFU;

        // Token: 0x04000565 RID: 1381
        public static _bc6 _AQG;

        // Token: 0x04000566 RID: 1382
        public static _bc6 _AY;

        // Token: 0x04000567 RID: 1383
        public static _bc6 _BFL;

        // Token: 0x04000568 RID: 1384
        public static _bc6 _BFJ;

        // Token: 0x04000569 RID: 1385
        public static _bc6 _CBR;

        // Token: 0x0400056A RID: 1386
        public static _bc6 _ADE;

        // Token: 0x0400056B RID: 1387
        public static _bc6 _BFT;

        // Token: 0x0400056C RID: 1388
        public static _bc6 _BFV;

        // Token: 0x0400056D RID: 1389
        public static _bc6 _BFW;

        // Token: 0x0400056E RID: 1390
        private static readonly string[] _BFX = new string[] { "argumentValue", "expression", "nonAssignmentExpression", "lambdaExpression", "lambdaExpressionBody" };

        // Token: 0x020000D3 RID: 211
        [DefaultMember("Item")]
        public struct _CAT
        {
            // Token: 0x1700002D RID: 45
            // (get) Token: 0x0600062C RID: 1580 RVA: 0x000E2F18 File Offset: 0x000E1118
            public int Count
            {
                get
                {
                    return (this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ == null) ? 0 : this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.Count;
                }
            }

            // Token: 0x0600062D RID: 1581 RVA: 0x000E2F40 File Offset: 0x000E1140
            public void RemoveAt(int index)
            {
                this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.RemoveAt(index);
            }

            // Token: 0x0600062E RID: 1582 RVA: 0x000E2F50 File Offset: 0x000E1150
            private int BinarySearch(string name, int numTypeParameters)
            {
                int i = 0;
                int num = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.Count - 1;
                while (i <= num)
                {
                    int num2 = i + (num - i >> 1);
                    _bh4 _AAH = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[num2];
                    int num3 = string.CompareOrdinal(_AAH._AW, name);
                    bool flag = num3 == 0;
                    if (flag)
                    {
                        while (num2 > 0 && this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[num2 - 1]._AW == name)
                        {
                            num2--;
                        }
                        _AAH = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[num2];
                        bool flag2 = numTypeParameters < 0 || numTypeParameters == _AAH._AHG() || _AAH._AT == SymbolKind.MethodGroup;
                        int num4;
                        if (flag2)
                        {
                            num4 = num2;
                        }
                        else
                        {
                            while (++num2 < this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.Count)
                            {
                                _AAH = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[num2];
                                bool flag3 = _AAH._AW != name;
                                if (flag3)
                                {
                                    return ~num2;
                                }
                                bool flag4 = _AAH._AHG() == numTypeParameters;
                                if (flag4)
                                {
                                    return num2;
                                }
                                bool flag5 = _AAH._AHG() > numTypeParameters;
                                if (flag5)
                                {
                                    return ~num2;
                                }
                            }
                            num4 = ~num2;
                        }
                        return num4;
                    }
                    bool flag6 = num3 < 0;
                    if (flag6)
                    {
                        i = num2 + 1;
                    }
                    else
                    {
                        num = num2 - 1;
                    }
                }
                return ~i;
            }

            // Token: 0x0600062F RID: 1583 RVA: 0x000E30B0 File Offset: 0x000E12B0
            public bool TryGetValue(string name, int numTypeParameters, out _bh4 value)
            {
                bool flag = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ == null;
                bool flag2;
                if (flag)
                {
                    value = null;
                    flag2 = false;
                }
                else
                {
                    int num = this.BinarySearch(name, numTypeParameters);
                    bool flag3 = num < 0;
                    if (flag3)
                    {
                        value = null;
                        flag2 = false;
                    }
                    else
                    {
                        value = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[num];
                        flag2 = true;
                    }
                }
                return flag2;
            }

            // Token: 0x06000630 RID: 1584 RVA: 0x000E3100 File Offset: 0x000E1300
            public bool Remove(string name, int numTypeParameters)
            {
                bool flag = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ == null;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    int num = this.BinarySearch(name, numTypeParameters);
                    bool flag3 = num >= 0;
                    if (flag3)
                    {
                        this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.RemoveAt(num);
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
                return flag2;
            }

            // Token: 0x06000631 RID: 1585 RVA: 0x000E314C File Offset: 0x000E134C
            public bool Contains(string name, int numTypeParameters)
            {
                return this.BinarySearch(name, numTypeParameters) >= 0;
            }

            // Token: 0x06000632 RID: 1586 RVA: 0x000E316C File Offset: 0x000E136C
            public _bh4 _AAI(int index)
            {
                return this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[index];
            }

            // Token: 0x06000633 RID: 1587 RVA: 0x000E318C File Offset: 0x000E138C
            public _bh4 _AAI(string name, int numTypeParameters)
            {
                _bh4 _AAH;
                bool flag = !this.TryGetValue(name, numTypeParameters, out _AAH);
                _bh4 _AAH2;
                if (flag)
                {
                    _AAH2 = null;
                }
                else
                {
                    _AAH2 = _AAH;
                }
                return _AAH2;
            }

            // Token: 0x06000634 RID: 1588 RVA: 0x000E31B4 File Offset: 0x000E13B4
            public void _AWM(string name, int numTypeParameters, _bh4 value)
            {
                bool flag = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ == null;
                if (flag)
                {
                    this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ = new List<_bh4>();
                    this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.Add(value);
                }
                else
                {
                    int i = this.BinarySearch(name, numTypeParameters);
                    bool flag2 = i >= 0;
                    if (flag2)
                    {
                        int num = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.Count;
                        while (i < num)
                        {
                            _bh4 _AAH = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[i];
                            bool flag3 = value == _AAH;
                            if (flag3)
                            {
                                return;
                            }
                            bool flag4 = true;
                            bool flag5 = _AAH._AEI != null;
                            if (flag5)
                            {
                                List<FKI> _CAV = _AAH._AEI;
                                int count = _CAV.Count;
                                while (count-- > 0)
                                {
                                    bool flag6 = !_CAV[count].IsValid();
                                    if (flag6)
                                    {
                                        flag4 = false;
                                        break;
                                    }
                                }
                            }
                            bool flag7 = _AAH._AEI == null || _AAH._AEI.Count == 0 || !flag4;
                            if (flag7)
                            {
                                this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.RemoveAt(i);
                                num--;
                            }
                            else
                            {
                                i++;
                            }
                            bool flag8 = i < num;
                            if (flag8)
                            {
                                _AAH = this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ[i];
                                bool flag9 = _AAH._AW != name || (_AAH._AT != SymbolKind.MethodGroup && _AAH._AHG() != numTypeParameters);
                                if (flag9)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        i = ~i;
                    }
                    this.DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ.Insert(i, value);
                }
            }

            // Token: 0x0400056F RID: 1391
            private List<_bh4> DLGOMEIEAOBJPCOFKDCFCJCKGIKDFKIILOBJ;
        }
    }
}
