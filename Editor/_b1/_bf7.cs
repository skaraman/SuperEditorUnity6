using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000CD RID: 205
    internal class _bf7 : _bb3
    {
        // Token: 0x060005BA RID: 1466 RVA: 0x000D6AFC File Offset: 0x000D4CFC
        public _bf7(ConstructorInfo constructorInfo, _bh4 memberOf)
        {
            this._AV = (constructorInfo.IsPublic ? Modifiers.Public : (constructorInfo.IsFamilyOrAssembly ? (Modifiers.Internal | Modifiers.Protected) : (constructorInfo.IsAssembly ? Modifiers.Internal : (constructorInfo.IsFamily ? Modifiers.Protected : Modifiers.Private))));
            bool isAbstract = constructorInfo.IsAbstract;
            if (isAbstract)
            {
                this._AV |= Modifiers.Abstract;
            }
            bool isStatic = constructorInfo.IsStatic;
            if (isStatic)
            {
                this._AV |= Modifiers.Static;
            }
            this._AU = _bh4.AccessLevelFromModifiers(this._AV);
            this._AW = ".ctor";
            this._AT = SymbolKind.Constructor;
            this._AO = memberOf;
            this._AIJ = new KJK(memberOf);
            ParameterInfo[] parameters = constructorInfo.GetParameters();
            int num = parameters.Length;
            bool flag = this._AIK == null && num != 0;
            if (flag)
            {
                this._AIK = new List<_bm1>(num);
            }
            for (int i = 0; i < num; i++)
            {
                ParameterInfo parameterInfo = parameters[i];
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
                bool flag2 = parameterInfo.RawDefaultValue != DBNull.Value;
                if (flag2)
                {
                    object rawDefaultValue = parameterInfo.RawDefaultValue;
                    _AGS._AWY = ((rawDefaultValue == null) ? "null" : ((rawDefaultValue is string) ? ("\"" + rawDefaultValue.ToString() + "\"") : ((rawDefaultValue is Enum) ? (type.ToString() + "." + rawDefaultValue.ToString()) : rawDefaultValue.ToString())));
                }
                this._AIK.Add(_AGS);
            }
        }
    }
}
