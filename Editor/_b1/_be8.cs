using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000D0 RID: 208
    internal class _be8 : _bc6
    {
        // Token: 0x060005C0 RID: 1472 RVA: 0x000D76F0 File Offset: 0x000D58F0
        public Type GetReflectedType()
        {
            return this._AWK;
        }

        // Token: 0x060005C1 RID: 1473 RVA: 0x000D7708 File Offset: 0x000D5908
        public _be8(Type type)
        {
            this._AWK = type;
            this._AV = (type.IsNested ? (type.IsNestedPublic ? Modifiers.Public : (type.IsNestedFamORAssem ? (Modifiers.Internal | Modifiers.Protected) : (type.IsNestedAssembly ? Modifiers.Internal : (type.IsNestedFamily ? Modifiers.Protected : Modifiers.Private)))) : (type.IsPublic ? Modifiers.Public : ((!type.IsVisible) ? Modifiers.Internal : Modifiers.Private)));
            bool flag = type.IsAbstract && type.IsSealed;
            if (flag)
            {
                this._AV |= Modifiers.Static;
            }
            else
            {
                bool isAbstract = type.IsAbstract;
                if (isAbstract)
                {
                    this._AV |= Modifiers.Abstract;
                }
                else
                {
                    bool isSealed = type.IsSealed;
                    if (isSealed)
                    {
                        this._AV |= Modifiers.Sealed;
                    }
                }
            }
            this._AU = _bh4.AccessLevelFromModifiers(this._AV);
            _bj5 _AOS = _bj5.FromAssembly(type.Assembly);
            int num = type.Name.IndexOf("`", StringComparison.Ordinal);
            string name = type.Name;
            this._AW = ((num < 0) ? name : name.Substring(0, num));
            this._AW = this._AW.Replace("[*]", "[]");
            string @namespace = type.Namespace;
            this._AO = (string.IsNullOrEmpty(@namespace) ? _AOS._AWL() : _AOS.FindNamespace(@namespace));
            bool isInterface = type.IsInterface;
            if (isInterface)
            {
                this._AT = SymbolKind.Interface;
            }
            else
            {
                bool isEnum = type.IsEnum;
                if (isEnum)
                {
                    this._AT = SymbolKind.Enum;
                }
                else
                {
                    bool isValueType = type.IsValueType;
                    if (isValueType)
                    {
                        this._AT = SymbolKind.Struct;
                    }
                    else
                    {
                        bool isClass = type.IsClass;
                        if (isClass)
                        {
                            this._AT = SymbolKind.Class;
                            bool flag2 = type.BaseType == typeof(MulticastDelegate);
                            if (flag2)
                            {
                                this._AT = SymbolKind.Delegate;
                            }
                        }
                        else
                        {
                            this._AT = SymbolKind.None;
                        }
                    }
                }
            }
            bool isGenericTypeDefinition = type.IsGenericTypeDefinition;
            if (isGenericTypeDefinition)
            {
                Type type2 = type.GetGenericTypeDefinition() ?? type;
                Type[] genericArguments = type2.GetGenericArguments();
                int num2 = genericArguments.Length;
                Type declaringType = type2.DeclaringType;
                bool flag3 = declaringType != null && declaringType.IsGenericType;
                if (flag3)
                {
                    Type[] genericArguments2 = declaringType.GetGenericArguments();
                    num2 -= genericArguments2.Length;
                }
                bool flag4 = num2 > 0;
                if (flag4)
                {
                    this._AHL = new List<_bd7>(num2);
                    for (int i = genericArguments.Length - num2; i < genericArguments.Length; i++)
                    {
                        _bd7 _AHM = new _bd7
                        {
                            _AT = SymbolKind.TypeParameter,
                            _AW = genericArguments[i].Name,
                            _AO = this
                        };
                        this._AHL.Add(_AHM);
                    }
                }
            }
            bool flag5 = this.IsStatic && base._AHG() == 0 && !type.IsNested;
            if (flag5)
            {
                bool flag6 = type.IsDefined(typeof(ExtensionAttribute), false);
                if (flag6)
                {
                    this.ReflectAllMembers(BindingFlags.Public);
                }
            }
        }

        // Token: 0x060005C2 RID: 1474 RVA: 0x000D7A00 File Offset: 0x000D5C00
        internal override _b2 BaseType()
        {
            bool _APE = this._APF;
            _b2 _AAC;
            if (_APE)
            {
                _AAC = null;
            }
            else
            {
                this._APF = true;
                bool flag;
                if (this._APC == null || (this._APC.definition != null && this._APC.definition.IsValid()))
                {
                    if (this._APD != null)
                    {
                        flag = this._APD.Exists((KJK x) => x.definition == null || !x.definition.IsValid());
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = true;
                }
                bool flag2 = flag;
                if (flag2)
                {
                    this._APC = null;
                    this._APD = null;
                }
                bool flag3 = this._APC == null && this._APD == null && this != _bh4._AS;
                if (flag3)
                {
                    this._APC = _bl9.ForType((this._AWK.BaseType != null) ? this._AWK.BaseType : typeof(object));
                    this._APD = new List<KJK>();
                    Type[] interfaces = this._AWK.GetInterfaces();
                    for (int i = 0; i < interfaces.Length; i++)
                    {
                        this._APD.Add(_bl9.ForType(interfaces[i]));
                    }
                }
                _b2 _AAC2 = ((this._APC != null) ? (this._APC.definition as _b2) : base.BaseType());
                bool flag4 = _AAC2 == this;
                if (flag4)
                {
                    this._APC = new KJK(_bh4._APG);
                    _AAC2 = _bh4._APG;
                }
                this._APF = false;
                _AAC = _AAC2;
            }
            return _AAC;
        }

        // Token: 0x060005C3 RID: 1475 RVA: 0x000D7B8C File Offset: 0x000D5D8C
        private _bh4 ImportReflectedMember(Type info, bool importInternal)
        {
            bool flag = info.IsNestedPrivate || (!importInternal && info.IsNestedAssembly);
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                _bh4 _AAH2 = base.ImportReflectedType(info);
                _AAH = _AAH2;
            }
            return _AAH;
        }

        // Token: 0x060005C4 RID: 1476 RVA: 0x000D7BC8 File Offset: 0x000D5DC8
        private _bh4 ImportReflectedMember(FieldInfo info, bool importInternal)
        {
            bool flag = info.IsPrivate || (this._AT == SymbolKind.Enum && info.Name == "value__") || (!importInternal && info.IsAssembly);
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                _bh4 _AAH2 = new _bj6(info, this);
                this._AAG._AWM(_AAH2._AW, _AAH2._AHG(), _AAH2);
                _AAH = _AAH2;
            }
            return _AAH;
        }

        // Token: 0x060005C5 RID: 1477 RVA: 0x000D7C38 File Offset: 0x000D5E38
        private _bh4 ImportReflectedMember(PropertyInfo info, bool importInternal)
        {
            MethodInfo getMethod = info.GetGetMethod(true);
            MethodInfo setMethod = info.GetSetMethod(true);
            bool flag = (getMethod == null || getMethod.IsPrivate || (!importInternal && getMethod.IsAssembly)) && (setMethod == null || setMethod.IsPrivate || (!importInternal && setMethod.IsAssembly));
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                _bh4 _AAH2 = new _bj6(info, this);
                this._AAG._AWM(_AAH2._AW, _AAH2._AHG(), _AAH2);
                _AAH = _AAH2;
            }
            return _AAH;
        }

        // Token: 0x060005C6 RID: 1478 RVA: 0x000D7CCC File Offset: 0x000D5ECC
        private _bh4 ImportReflectedMember(EventInfo info, bool importInternal)
        {
            MethodInfo addMethod = info.GetAddMethod(true);
            MethodInfo removeMethod = info.GetRemoveMethod(true);
            bool flag = (addMethod == null || addMethod.IsPrivate || (!importInternal && addMethod.IsAssembly)) && (removeMethod == null || removeMethod.IsPrivate || (!importInternal && removeMethod.IsAssembly));
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                _bh4 _AAH2 = new _bj6(info, this);
                this._AAG._AWM(_AAH2._AW, _AAH2._AHG(), _AAH2);
                _AAH = _AAH2;
            }
            return _AAH;
        }

        // Token: 0x060005C7 RID: 1479 RVA: 0x000D7D60 File Offset: 0x000D5F60
        private _bh4 ImportReflectedMember(MethodInfo info, bool importInternal)
        {
            bool flag = info.IsPrivate || (!importInternal && info.IsAssembly);
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                bool flag2 = info.Name == "Finalize" && !info.IsGenericMethod && info.GetParameters().Length == 0;
                if (flag2)
                {
                    _AAH = null;
                }
                else
                {
                    _bh4 _AAH2 = base.ImportReflectedMethod(info);
                    _AAH = _AAH2;
                }
            }
            return _AAH;
        }

        // Token: 0x060005C8 RID: 1480 RVA: 0x000D7DCC File Offset: 0x000D5FCC
        private _bh4 ImportReflectedMember(ConstructorInfo info, bool importInternal)
        {
            bool flag = info.IsPrivate || (!importInternal && info.IsAssembly);
            _bh4 _AAH;
            if (flag)
            {
                _AAH = null;
            }
            else
            {
                _bh4 _AAH2 = base.ImportReflectedConstructor(info);
                _AAH = _AAH2;
            }
            return _AAH;
        }

        // Token: 0x060005C9 RID: 1481 RVA: 0x000D7E08 File Offset: 0x000D6008
        internal override string GetName()
        {
            foreach (KeyValuePair<string, _b2> keyValuePair in _bh4._ABO)
            {
                bool flag = keyValuePair.Value == this;
                if (flag)
                {
                    return keyValuePair.Key;
                }
            }
            return base.GetName();
        }

        // Token: 0x060005CA RID: 1482 RVA: 0x000D7E78 File Offset: 0x000D6078
        internal override _bh4 TypeOf()
        {
            bool flag = this._AT != SymbolKind.Delegate;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = this;
            }
            else
            {
                this.GetParameters();
                _AAH = this._AIJ.definition;
            }
            return _AAH;
        }

        // Token: 0x060005CB RID: 1483 RVA: 0x000D7EB4 File Offset: 0x000D60B4
        internal override List<_bh4> GetAllIndexers()
        {
            bool flag = !this._AWN || !this._AWO;
            if (flag)
            {
                this.ReflectAllMembers(BindingFlags.Public | BindingFlags.NonPublic);
            }
            return base.GetAllIndexers();
        }

        // Token: 0x060005CC RID: 1484 RVA: 0x000D7EF0 File Offset: 0x000D60F0
        internal override _bb3 GetDefaultConstructor()
        {
            bool flag = !this._AWN || !this._AWO;
            if (flag)
            {
                this.ReflectAllMembers(BindingFlags.Public | BindingFlags.NonPublic);
            }
            return base.GetDefaultConstructor();
        }

        // Token: 0x060005CD RID: 1485 RVA: 0x000D7F2C File Offset: 0x000D612C
        internal override _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            memberName = _bh4.DecodeId(memberName);
            _bh4 _AAH = null;
            bool flag = !this._AWN || !this._AWO;
            if (flag)
            {
                this.ReflectAllMembers(BindingFlags.Public | BindingFlags.NonPublic);
            }
            bool flag2 = !this._AAG.TryGetValue(memberName, numTypeParameters, out _AAH);
            _bh4 _AAH2;
            if (flag2)
            {
                _AAH2 = null;
            }
            else
            {
                bool flag3 = asTypeOnly && _AAH != null && !(_AAH is _b2);
                if (flag3)
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

        // Token: 0x060005CE RID: 1486 RVA: 0x000D7FA4 File Offset: 0x000D61A4
        public void ReflectAllMembers(BindingFlags flags)
        {
            bool flag = this._AWN && this._AWO;
            if (!flag)
            {
                flags |= BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static;
                bool _AWP = this._AWN;
                if (_AWP)
                {
                    flags &= ~BindingFlags.Public;
                }
                bool _AWQ = this._AWO;
                if (_AWQ)
                {
                    flags &= ~BindingFlags.NonPublic;
                }
                bool _AWT = base.Assembly._yb7;
                foreach (Type type in this._AWK.GetNestedTypes(flags))
                {
                    this.ImportReflectedMember(type, _AWT);
                }
                foreach (FieldInfo fieldInfo in this._AWK.GetFields(flags))
                {
                    this.ImportReflectedMember(fieldInfo, _AWT);
                }
                foreach (PropertyInfo propertyInfo in this._AWK.GetProperties(flags))
                {
                    this.ImportReflectedMember(propertyInfo, _AWT);
                }
                foreach (EventInfo eventInfo in this._AWK.GetEvents(flags))
                {
                    this.ImportReflectedMember(eventInfo, _AWT);
                }
                foreach (MethodInfo methodInfo in this._AWK.GetMethods(flags))
                {
                    bool flag2 = !methodInfo.IsSpecialName || _bh4.IsOperatorName(methodInfo.Name);
                    if (flag2)
                    {
                        this.ImportReflectedMember(methodInfo, _AWT);
                    }
                }
                foreach (ConstructorInfo constructorInfo in this._AWK.GetConstructors(flags))
                {
                    this.ImportReflectedMember(constructorInfo, _AWT);
                }
                bool flag3 = (flags & BindingFlags.Public) == BindingFlags.Public;
                if (flag3)
                {
                    this._AWN = true;
                }
                bool flag4 = (flags & BindingFlags.NonPublic) == BindingFlags.NonPublic;
                if (flag4)
                {
                    this._AWO = true;
                }
            }
        }

        // Token: 0x060005CF RID: 1487 RVA: 0x000D8178 File Offset: 0x000D6378
        internal override List<_bm1> GetParameters()
        {
            bool flag = this._AT != SymbolKind.Delegate;
            List<_bm1> list;
            if (flag)
            {
                list = null;
            }
            else
            {
                bool flag2 = this._AIK == null;
                if (flag2)
                {
                    MethodInfo method = this._AWK.GetMethod("Invoke");
                    this._AIJ = _bl9.ForType(method.ReturnType);
                    this._AIK = new List<_bm1>();
                    foreach (ParameterInfo parameterInfo in method.GetParameters())
                    {
                        bool isByRef = parameterInfo.ParameterType.IsByRef;
                        Type type = (isByRef ? parameterInfo.ParameterType.GetElementType() : parameterInfo.ParameterType);
                        this._AIK.Add(new _bm1
                        {
                            _AT = SymbolKind.Parameter,
                            _AO = this,
                            _AW = parameterInfo.Name,
                            BLH = _bl9.ForType(type),
                            _AV = (isByRef ? (parameterInfo.IsOut ? Modifiers.Out : (parameterInfo.IsIn ? Modifiers.In : Modifiers.Ref)) : ((type.IsArray && parameterInfo.IsDefined(typeof(ParamArrayAttribute), false)) ? Modifiers.Params : Modifiers.None))
                        });
                    }
                }
                list = this._AIK;
            }
            return list;
        }

        // Token: 0x060005D0 RID: 1488 RVA: 0x000D82D4 File Offset: 0x000D64D4
        internal override string GetDelegateInfoText()
        {
            bool flag = this._AQK == null;
            if (flag)
            {
                List<_bm1> parameters = this.GetParameters();
                _bh4 _AAH = this.TypeOf();
                this._AQK = _AAH.GetName() + " " + this.GetName() + ((parameters.Count == 1) ? "( " : "(");
                this._AQK = this._AQK + base.PrintParameters(parameters, false) + ((parameters.Count == 1) ? " )" : ")");
            }
            return this._AQK;
        }

        // Token: 0x060005D1 RID: 1489 RVA: 0x000D8368 File Offset: 0x000D6568
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            bool flag = !this._AWN;
            if (flag)
            {
                bool flag2 = !this._AWO;
                if (flag2)
                {
                    this.ReflectAllMembers(BindingFlags.Public | BindingFlags.NonPublic);
                }
                else
                {
                    this.ReflectAllMembers(BindingFlags.Public);
                }
            }
            else
            {
                bool flag3 = !this._AWO;
                if (flag3)
                {
                    this.ReflectAllMembers(BindingFlags.NonPublic);
                }
            }
            base.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
        }

        // Token: 0x060005D2 RID: 1490 RVA: 0x000D83CC File Offset: 0x000D65CC
        internal override void GetMembersCompletionData(Dictionary<string, _bh4> data, BindingFlags flags, AccessLevelMask mask, _be4 context)
        {
            bool flag = !this._AWN;
            if (flag)
            {
                bool flag2 = !this._AWO && ((mask & AccessLevelMask.NonPublic) != AccessLevelMask.None || (flags & BindingFlags.NonPublic) > BindingFlags.Default);
                if (flag2)
                {
                    this.ReflectAllMembers(BindingFlags.Public | BindingFlags.NonPublic);
                }
                else
                {
                    this.ReflectAllMembers(BindingFlags.Public);
                }
            }
            else
            {
                bool flag3 = !this._AWO && ((mask & AccessLevelMask.NonPublic) != AccessLevelMask.None || (flags & BindingFlags.NonPublic) > BindingFlags.Default);
                if (flag3)
                {
                    this.ReflectAllMembers(BindingFlags.NonPublic);
                }
            }
            base.GetMembersCompletionData(data, flags, mask, context);
        }

        // Token: 0x0400052F RID: 1327
        private readonly Type _AWK;

        // Token: 0x04000530 RID: 1328
        private bool _AWN;

        // Token: 0x04000531 RID: 1329
        private bool _AWO;

        // Token: 0x04000532 RID: 1330
        private _bl9 _AIJ;

        // Token: 0x04000533 RID: 1331
        private List<_bm1> _AIK;

        // Token: 0x04000534 RID: 1332
        private string _AQK;
    }
}
