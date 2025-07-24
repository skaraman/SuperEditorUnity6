using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000CF RID: 207
    internal class _bg4 : _bb3
    {
        // Token: 0x060005BF RID: 1471 RVA: 0x000D72E0 File Offset: 0x000D54E0
        public _bg4(MethodInfo methodInfo, _bh4 memberOf)
        {
            this._AV = (methodInfo.IsPublic ? Modifiers.Public : (methodInfo.IsFamilyOrAssembly ? (Modifiers.Internal | Modifiers.Protected) : (methodInfo.IsAssembly ? Modifiers.Internal : (methodInfo.IsFamily ? Modifiers.Protected : Modifiers.Private))));
            bool isAbstract = methodInfo.IsAbstract;
            if (isAbstract)
            {
                this._AV |= Modifiers.Abstract;
            }
            bool isVirtual = methodInfo.IsVirtual;
            if (isVirtual)
            {
                this._AV |= Modifiers.Virtual;
            }
            bool isStatic = methodInfo.IsStatic;
            if (isStatic)
            {
                this._AV |= Modifiers.Static;
            }
            bool flag = methodInfo.GetBaseDefinition() != methodInfo;
            if (flag)
            {
                this._AV = (this._AV & ~Modifiers.Virtual) | Modifiers.Override;
            }
            bool flag2 = this.IsStatic && methodInfo.IsDefined(typeof(ExtensionAttribute), false);
            if (flag2)
            {
                _b2 _AAC = memberOf._AO as _b2;
                bool flag3 = _AAC._AT == SymbolKind.Class && _AAC.IsStatic && _AAC._AHG() == 0;
                if (flag3)
                {
                    this._AIH = true;
                    _AAC._AF++;
                }
            }
            this._AU = _bh4.AccessLevelFromModifiers(this._AV);
            this._AZQ = methodInfo;
            string name = methodInfo.Name;
            int num = name.IndexOf("`", StringComparison.Ordinal);
            this._AW = ((num < 0) ? name : name.Substring(0, num));
            this._AO = memberOf;
            bool isGenericMethod = methodInfo.IsGenericMethod;
            if (isGenericMethod)
            {
                Type[] genericArguments = methodInfo.GetGenericArguments();
                bool flag4 = genericArguments.Length != 0;
                if (flag4)
                {
                    int num2 = genericArguments.Length;
                    this._AHL = new List<_bd7>(genericArguments.Length);
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
            this._AIJ = _bl9.ForType(methodInfo.ReturnType);
            ParameterInfo[] parameters = methodInfo.GetParameters();
            int num3 = parameters.Length;
            bool flag5 = this._AIK == null && num3 != 0;
            if (flag5)
            {
                this._AIK = new List<_bm1>(parameters.Length);
            }
            for (int j = 0; j < num3; j++)
            {
                ParameterInfo parameterInfo = parameters[j];
                bool isByRef = parameterInfo.ParameterType.IsByRef;
                Type type = (isByRef ? parameterInfo.ParameterType.GetElementType() : parameterInfo.ParameterType);
                _bm1 _AGS = new _bm1
                {
                    _AT = SymbolKind.Parameter,
                    _AO = this,
                    _AW = parameterInfo.Name,
                    BLH = _bl9.ForType(type),
                    _AV = (isByRef ? (parameterInfo.IsOut ? Modifiers.Out : (parameterInfo.IsIn ? Modifiers.In : Modifiers.Ref)) : ((type.IsArray && parameterInfo.IsDefined(typeof(ParamArrayAttribute), false)) ? Modifiers.Params : Modifiers.None))
                };
                bool flag6 = parameterInfo.RawDefaultValue != DBNull.Value;
                if (flag6)
                {
                    object rawDefaultValue = parameterInfo.RawDefaultValue;
                    _AGS._AWY = ((rawDefaultValue == null) ? "null" : ((rawDefaultValue is string) ? ("\"" + rawDefaultValue.ToString() + "\"") : ((rawDefaultValue is Enum) ? (type.ToString() + "." + rawDefaultValue.ToString()) : rawDefaultValue.ToString())));
                }
                this._AIK.Add(_AGS);
            }
            bool _AZR = this._AIH;
            if (_AZR)
            {
                this._AIK[0]._AV |= Modifiers.This;
            }
            this._AII = this.IsStatic && base._AFH() && methodInfo.IsSpecialName && _bh4.IsOperatorName(this._AW);
        }

        // Token: 0x0400052E RID: 1326
        public readonly MethodInfo _AZQ;
    }
}
