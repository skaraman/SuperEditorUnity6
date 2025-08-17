using System;
using System.Collections.Generic;
using System.Reflection;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000A1 RID: 161
    internal class _bl9 : KJK
    {
        // Token: 0x06000492 RID: 1170 RVA: 0x000CC270 File Offset: 0x000CA470
        protected _bl9(Type type)
        {
            this._AWK = type;
        }

        // Token: 0x06000493 RID: 1171 RVA: 0x000CC284 File Offset: 0x000CA484
        public static _bl9 ForType(Type type)
        {
            _bl9 _BEK;
            bool flag = _bl9._zk1.TryGetValue(type, out _BEK);
            _bl9 _BEK2;
            if (flag)
            {
                _BEK2 = _BEK;
            }
            else
            {
                _BEK = new _bl9(type);
                _bl9._zk1[type] = _BEK;
                _BEK2 = _BEK;
            }
            return _BEK2;
        }

        // Token: 0x1700001B RID: 27
        // (get) Token: 0x06000494 RID: 1172 RVA: 0x000CC2C0 File Offset: 0x000CA4C0
        internal override _bh4 definition
        {
            get
            {
                bool flag = this._zk2 != null && !this._zk2.IsValid();
                if (flag)
                {
                    this._zk2 = this._zk2.Rebind();
                    bool flag2 = this._zk2 != null && !this._zk2.IsValid();
                    if (flag2)
                    {
                        this._zk2 = null;
                    }
                }
                bool flag3 = this._zk2 == null;
                if (flag3)
                {
                    bool isArray = this._AWK.IsArray;
                    if (isArray)
                    {
                        Type elementType = this._AWK.GetElementType();
                        _b2 _AAC = _bl9.ForType(elementType).definition as _b2;
                        int arrayRank = this._AWK.GetArrayRank();
                        this._zk2 = _AAC.MakeArrayType(arrayRank);
                        return this._zk2;
                    }
                    bool isGenericParameter = this._AWK.IsGenericParameter;
                    if (isGenericParameter)
                    {
                        int num = this._AWK.GenericParameterPosition;
                        MethodInfo methodInfo = this._AWK.DeclaringMethod as MethodInfo;
                        bool flag4 = methodInfo != null && methodInfo.IsGenericMethod;
                        if (flag4)
                        {
                            _bl9 _BEK = _bl9.ForType(methodInfo.DeclaringType);
                            _be8 _AFK = _BEK.definition as _be8;
                            bool flag5 = _AFK == null;
                            if (flag5)
                            {
                                return this._zk2 = _bh4._AHA;
                            }
                            string name = methodInfo.Name;
                            Type[] genericArguments = methodInfo.GetGenericArguments();
                            int num2 = genericArguments.Length;
                            _bh4 _AAH = _AFK.FindName(name, num2, false);
                            bool flag6 = _AAH == null && num2 > 0;
                            if (flag6)
                            {
                                _AAH = _AFK.FindName(name, 0, false);
                            }
                            bool flag7 = _AAH != null && _AAH._AT == SymbolKind.MethodGroup;
                            if (flag7)
                            {
                                _ba7 _AAK = (_ba7)_AAH;
                                List<_bb3> _AAL = _AAK._AAM;
                                int count = _AAL.Count;
                                while (count-- > 0)
                                {
                                    _bg4 _BEL = _AAL[count] as _bg4;
                                    bool flag8 = _BEL != null && _BEL._AZQ == methodInfo;
                                    if (flag8)
                                    {
                                        _AAH = _BEL;
                                        break;
                                    }
                                }
                            }
                            _bb3 _AAN = _AAH as _bb3;
                            this._zk2 = _AAN._AHL.ElementAtOrDefault(num);
                        }
                        else
                        {
                            Type type = this._AWK.DeclaringType;
                            int num3;
                            for (; ; )
                            {
                                Type declaringType = type.DeclaringType;
                                bool flag9 = declaringType == null;
                                if (flag9)
                                {
                                    break;
                                }
                                num3 = declaringType.GetGenericArguments().Length;
                                bool flag10 = num3 <= num;
                                if (flag10)
                                {
                                    goto Block_18;
                                }
                                type = declaringType;
                            }
                            goto IL_028E;
                        Block_18:
                            num -= num3;
                        IL_028E:
                            _bl9 _BEK2 = _bl9.ForType(type);
                            _bc6 _AHD = _BEK2.definition as _bc6;
                            bool flag11 = _AHD == null;
                            if (flag11)
                            {
                                return this._zk2 = _bh4._AHA;
                            }
                            this._zk2 = _AHD._AHL[num];
                        }
                        return this._zk2;
                    }
                    bool flag12 = this._AWK.IsGenericType && !this._AWK.IsGenericTypeDefinition;
                    if (flag12)
                    {
                        Type genericTypeDefinition = this._AWK.GetGenericTypeDefinition();
                        _bl9 _BEK3 = _bl9.ForType(genericTypeDefinition);
                        _bc6 _AHD2 = _BEK3.definition as _bc6;
                        bool flag13 = _AHD2 == null;
                        if (flag13)
                        {
                            return this._zk2 = _bh4._AHA;
                        }
                        Type[] genericArguments2 = this._AWK.GetGenericArguments();
                        int num4 = genericArguments2.Length;
                        Type declaringType2 = this._AWK.DeclaringType;
                        bool flag14 = declaringType2 != null && declaringType2.IsGenericType;
                        if (flag14)
                        {
                            Type[] genericArguments3 = declaringType2.GetGenericArguments();
                            num4 -= genericArguments3.Length;
                        }
                        _bl9[] array = new _bl9[num4];
                        int i = array.Length - num4;
                        int num5 = 0;
                        while (i < array.Length)
                        {
                            array[num5++] = _bl9.ForType(genericArguments2[i]);
                            i++;
                        }
                        _bc6 _AHD3 = _AHD2;
                        KJK[] array2 = array;
                        this._zk2 = _AHD3.ConstructType(array2);
                        return this._zk2;
                    }
                    else
                    {
                        string text = this._AWK.Name;
                        _bh4 _AAH2 = null;
                        bool isNested = this._AWK.IsNested;
                        if (isNested)
                        {
                            _AAH2 = _bl9.ForType(this._AWK.DeclaringType).definition;
                        }
                        else
                        {
                            _bj5 _AOS = _bj5.FromAssembly(this._AWK.Assembly);
                            bool flag15 = _AOS != null;
                            if (flag15)
                            {
                                _AAH2 = _AOS.FindNamespace(this._AWK.Namespace);
                            }
                        }
                        bool flag16 = _AAH2 != null && _AAH2._AT != SymbolKind.Error;
                        if (flag16)
                        {
                            int num6 = text.IndexOf("[", StringComparison.Ordinal);
                            bool flag17 = num6 > 0;
                            if (flag17)
                            {
                                text = text.Substring(0, num6);
                            }
                            int num7 = 0;
                            int num8 = text.IndexOf("`", StringComparison.Ordinal);
                            bool flag18 = num8 > 0;
                            if (flag18)
                            {
                                num7 = int.Parse(text.Substring(num8 + 1));
                                text = text.Substring(0, num8);
                            }
                            this._zk2 = _AAH2.FindName(text, num7, true);
                            bool flag19 = this._zk2 == null;
                            if (flag19)
                            {
                                return null;
                            }
                            bool flag20 = num6 > 0;
                            if (flag20)
                            {
                                _bc6 _AHD4 = this._zk2 as _bc6;
                                bool flag21 = _AHD4 != null;
                                if (flag21)
                                {
                                    this._zk2 = _AHD4.MakeArrayType(text.Length - num6 - 1);
                                }
                                else
                                {
                                    this._zk2 = null;
                                }
                            }
                        }
                        bool flag22 = this._zk2 == null;
                        if (flag22)
                        {
                            this._zk2 = _bh4._AHA;
                        }
                    }
                }
                return this._zk2;
            }
        }

        // Token: 0x06000495 RID: 1173 RVA: 0x000CC854 File Offset: 0x000CAA54
        public override string ToString()
        {
            return this.definition.GetName();
        }

        // Token: 0x040004A6 RID: 1190
        protected Type _AWK;

        // Token: 0x040004A7 RID: 1191
        private static readonly Dictionary<Type, _bl9> _zk1 = new Dictionary<Type, _bl9>();
    }
}
