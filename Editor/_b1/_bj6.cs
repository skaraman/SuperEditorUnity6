using System;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000CE RID: 206
    internal class _bj6 : _bn3
    {
        // Token: 0x060005BB RID: 1467 RVA: 0x000D6D48 File Offset: 0x000D4F48
        public _bj6(MemberInfo info, _bh4 memberOf)
        {
            MethodInfo methodInfo = null;
            MethodInfo methodInfo2 = null;
            MethodInfo methodInfo3 = null;
            MethodInfo methodInfo4 = null;
            MemberTypes memberType = info.MemberType;
            MemberTypes memberTypes = memberType;
            switch (memberTypes)
            {
                case MemberTypes.Constructor:
                    break;
                case MemberTypes.Event:
                    {
                        EventInfo eventInfo = (EventInfo)info;
                        methodInfo3 = eventInfo.GetAddMethod(true);
                        methodInfo4 = eventInfo.GetRemoveMethod(true);
                        this._AV = this.GetAccessorModifiers(methodInfo3, methodInfo4);
                        goto IL_0102;
                    }
                case MemberTypes.Constructor | MemberTypes.Event:
                    goto IL_0100;
                case MemberTypes.Field:
                    {
                        FieldInfo fieldInfo = (FieldInfo)info;
                        this._AV = (fieldInfo.IsPublic ? Modifiers.Public : (fieldInfo.IsFamilyOrAssembly ? (Modifiers.Internal | Modifiers.Protected) : (fieldInfo.IsAssembly ? Modifiers.Internal : (fieldInfo.IsFamily ? Modifiers.Protected : Modifiers.Private))));
                        bool isStatic = fieldInfo.IsStatic;
                        if (isStatic)
                        {
                            this._AV |= Modifiers.Static;
                        }
                        goto IL_0102;
                    }
                default:
                    if (memberTypes != MemberTypes.Method)
                    {
                        if (memberTypes != MemberTypes.Property)
                        {
                            goto IL_0100;
                        }
                        PropertyInfo propertyInfo = (PropertyInfo)info;
                        methodInfo = propertyInfo.GetGetMethod(true);
                        methodInfo2 = propertyInfo.GetSetMethod(true);
                        this._AV = this.GetAccessorModifiers(methodInfo, methodInfo2);
                        goto IL_0102;
                    }
                    break;
            }
            throw new InvalidOperationException();
        IL_0100:
        IL_0102:
            this._AU = _bh4.AccessLevelFromModifiers(this._AV);
            this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH = info;
            string name = info.Name;
            int num = name.IndexOf("`", StringComparison.Ordinal);
            this._AW = ((num < 0) ? name : name.Substring(0, num));
            this._AO = memberOf;
            MemberTypes memberType2 = info.MemberType;
            MemberTypes memberTypes2 = memberType2;
            if (memberTypes2 != MemberTypes.Event)
            {
                if (memberTypes2 != MemberTypes.Field)
                {
                    if (memberTypes2 != MemberTypes.Property)
                    {
                        throw new InvalidOperationException("Importing a non-supported member type!");
                    }
                    ParameterInfo[] indexParameters = ((PropertyInfo)info).GetIndexParameters();
                    this._AT = ((indexParameters.Length != 0) ? SymbolKind.Indexer : SymbolKind.Property);
                    bool flag = methodInfo != null;
                    if (flag)
                    {
                        _bh4 _AAH = _bh4.Create(SymbolKind.Accessor, "get");
                        _AAH._AV = ((methodInfo2 != null) ? this.GetAccessorModifiers(methodInfo) : this._AV);
                        this._AV |= _AAH._AV & (Modifiers.Abstract | Modifiers.Virtual | Modifiers.Override);
                        base.AddMember(_AAH);
                    }
                    bool flag2 = methodInfo2 != null;
                    if (flag2)
                    {
                        _bh4 _AAH2 = _bh4.Create(SymbolKind.Accessor, "set");
                        _AAH2._AV = ((methodInfo != null) ? this.GetAccessorModifiers(methodInfo2) : this._AV);
                        this._AV |= _AAH2._AV & (Modifiers.Abstract | Modifiers.Virtual | Modifiers.Override);
                        base.AddMember(_AAH2);
                    }
                }
                else
                {
                    this._AT = (((FieldInfo)info).IsLiteral ? ((memberOf._AT == SymbolKind.Enum) ? SymbolKind.EnumMember : SymbolKind.ConstantField) : SymbolKind.Field);
                }
            }
            else
            {
                this._AT = SymbolKind.Event;
                bool flag3 = methodInfo3 != null;
                if (flag3)
                {
                    _bh4 _AAH3 = _bh4.Create(SymbolKind.Accessor, "add");
                    _AAH3._AV = ((methodInfo4 != null) ? this.GetAccessorModifiers(methodInfo3) : this._AV);
                    this._AV |= _AAH3._AV & (Modifiers.Abstract | Modifiers.Virtual | Modifiers.Override);
                    base.AddMember(_AAH3);
                }
                bool flag4 = methodInfo4 != null;
                if (flag4)
                {
                    _bh4 _AAH4 = _bh4.Create(SymbolKind.Accessor, "remove");
                    _AAH4._AV = ((methodInfo3 != null) ? this.GetAccessorModifiers(methodInfo4) : this._AV);
                    this._AV |= _AAH4._AV & (Modifiers.Abstract | Modifiers.Virtual | Modifiers.Override);
                    base.AddMember(_AAH4);
                }
            }
        }

        // Token: 0x060005BC RID: 1468 RVA: 0x000D70B0 File Offset: 0x000D52B0
        private Modifiers GetAccessorModifiers(MethodInfo accessor1, MethodInfo accessor2)
        {
            Modifiers modifiers = this.GetAccessorModifiers(accessor1) | this.GetAccessorModifiers(accessor2);
            Modifiers modifiers2 = (((modifiers & Modifiers.Public) != Modifiers.None) ? Modifiers.Public : (modifiers & (Modifiers.Internal | Modifiers.Protected)));
            bool flag = modifiers2 == Modifiers.None;
            if (flag)
            {
                modifiers2 = Modifiers.Private;
            }
            return modifiers2 | (modifiers & (Modifiers.Static | Modifiers.Abstract | Modifiers.Virtual));
        }

        // Token: 0x060005BD RID: 1469 RVA: 0x000D70F4 File Offset: 0x000D52F4
        private Modifiers GetAccessorModifiers(MethodInfo accessor)
        {
            bool flag = accessor == null;
            Modifiers modifiers;
            if (flag)
            {
                modifiers = Modifiers.Private;
            }
            else
            {
                Modifiers modifiers2 = (accessor.IsPublic ? Modifiers.Public : (accessor.IsFamilyOrAssembly ? (Modifiers.Internal | Modifiers.Protected) : (accessor.IsAssembly ? Modifiers.Internal : (accessor.IsFamily ? Modifiers.Protected : Modifiers.Private))));
                bool isAbstract = accessor.IsAbstract;
                if (isAbstract)
                {
                    modifiers2 |= Modifiers.Abstract;
                }
                bool isVirtual = accessor.IsVirtual;
                if (isVirtual)
                {
                    modifiers2 |= Modifiers.Virtual;
                }
                bool isStatic = accessor.IsStatic;
                if (isStatic)
                {
                    modifiers2 |= Modifiers.Static;
                }
                MethodInfo baseDefinition = accessor.GetBaseDefinition();
                bool flag2 = baseDefinition != null && baseDefinition != accessor;
                if (flag2)
                {
                    modifiers2 = (modifiers2 & ~Modifiers.Virtual) | Modifiers.Override;
                }
                modifiers = modifiers2;
            }
            return modifiers;
        }

        // Token: 0x060005BE RID: 1470 RVA: 0x000D71B0 File Offset: 0x000D53B0
        internal override _bh4 TypeOf()
        {
            bool flag = this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH.MemberType == MemberTypes.Constructor;
            _bh4 _AAH;
            if (flag)
            {
                _AAH = this._AO.TypeOf();
            }
            else
            {
                bool flag2 = this.BLH != null && (this.BLH.definition == null || !this.BLH.definition.IsValid());
                if (flag2)
                {
                    this.BLH = null;
                }
                bool flag3 = this.BLH == null;
                if (flag3)
                {
                    Type type = null;
                    MemberTypes memberType = this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH.MemberType;
                    MemberTypes memberTypes = memberType;
                    if (memberTypes <= MemberTypes.Field)
                    {
                        if (memberTypes != MemberTypes.Event)
                        {
                            if (memberTypes == MemberTypes.Field)
                            {
                                type = ((FieldInfo)this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH).FieldType;
                            }
                        }
                        else
                        {
                            type = ((EventInfo)this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH).EventHandlerType;
                        }
                    }
                    else if (memberTypes != MemberTypes.Method)
                    {
                        if (memberTypes == MemberTypes.Property)
                        {
                            type = ((PropertyInfo)this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH).PropertyType;
                        }
                    }
                    else
                    {
                        type = ((MethodInfo)this.DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH).ReturnType;
                    }
                    this.BLH = _bl9.ForType(type);
                }
                _AAH = ((this.BLH != null) ? this.BLH.definition : _bh4._AHA);
            }
            return _AAH;
        }

        // Token: 0x0400052D RID: 1325
        private readonly MemberInfo DIOELNEKMDADNLLFANLAMGKBJDEHEBCHOJNH;
    }
}
