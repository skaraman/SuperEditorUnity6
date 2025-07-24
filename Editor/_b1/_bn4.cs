using System;
using System.Collections.Generic;
using SuperEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x020000E8 RID: 232
    internal class _bn4 : _bm6
    {
        // Token: 0x060006CD RID: 1741 RVA: 0x000E5AC8 File Offset: 0x000E3CC8
        public _bn4(_bb4._ACW node)
            : base(node)
        {
        }

        // Token: 0x060006CE RID: 1742 RVA: 0x000E8394 File Offset: 0x000E6594
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = symbol._AJW == null;
            if (flag)
            {
                symbol._AJW = this;
            }
            bool flag2 = this.EFI == null;
            _bh4 _AAH;
            if (flag2)
            {
                string text = "Missing declaration in SymbolDeclarationScope! Can't add ";
                string text2 = ((symbol != null) ? symbol.ToString() : null);
                string text3 = "\nfor node: ";
                _bb4._ACW _APQ = this._AEJ;
                Debug.LogWarning(text + text2 + text3 + ((_APQ != null) ? _APQ.ToString() : null));
                _AAH = null;
            }
            else
            {
                _bh4 _APX = this.EFI._ACV;
                _AAH = ((_APX != null) ? _APX.AddDeclaration(symbol) : null);
            }
            return _AAH;
        }

        // Token: 0x060006CF RID: 1743 RVA: 0x000E8418 File Offset: 0x000E6618
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Method && this.EFI == symbol;
            if (flag)
            {
                this.EFI = null;
                base._AMJ().RemoveDeclaration(symbol);
            }
            else
            {
                bool flag2 = this.EFI != null && this.EFI._ACV != null;
                if (flag2)
                {
                    this.EFI._ACV.RemoveDeclaration(symbol);
                }
            }
        }

        // Token: 0x060006D0 RID: 1744 RVA: 0x000CC114 File Offset: 0x000CA314
        internal override _bh4 FindName(string symbolName, int numTypeParameters)
        {
            throw new NotImplementedException();
        }

        // Token: 0x060006D1 RID: 1745 RVA: 0x000E848C File Offset: 0x000E668C
        internal override void Resolve(_bb4.DHBA leaf, int numTypeArgs, bool asTypeOnly)
        {
            bool flag = this.EFI != null && this.EFI._ACV != null;
            if (flag)
            {
                this.EFI._ACV.ResolveMember(leaf, this, numTypeArgs, asTypeOnly);
                bool flag2 = numTypeArgs == 0 && leaf._AAB() == null;
                if (flag2)
                {
                    List<_bd7> typeParameters = this.EFI._ACV.GetTypeParameters();
                    bool flag3 = typeParameters != null;
                    if (flag3)
                    {
                        string text = _bh4.DecodeId(leaf._ACX.text);
                        int count = typeParameters.Count;
                        while (count-- > 0)
                        {
                            bool flag4 = typeParameters[count].GetName() == text;
                            if (flag4)
                            {
                                leaf._ACY(typeParameters[count]);
                                break;
                            }
                        }
                    }
                }
            }
            bool flag5 = leaf._AAB() == null;
            if (flag5)
            {
                base.Resolve(leaf, numTypeArgs, asTypeOnly);
            }
        }

        // Token: 0x060006D2 RID: 1746 RVA: 0x000E8574 File Offset: 0x000E6774
        internal override void ResolveAttribute(_bb4.DHBA leaf)
        {
            bool flag = this.EFI != null;
            if (flag)
            {
                this.EFI._ACV.ResolveAttributeMember(leaf, this);
            }
            bool flag2 = leaf._AAB() == null;
            if (flag2)
            {
                base.ResolveAttribute(leaf);
            }
        }

        // Token: 0x060006D3 RID: 1747 RVA: 0x000E85B8 File Offset: 0x000E67B8
        internal override _bc6 EnclosingType()
        {
            bool flag = this.EFI != null;
            if (flag)
            {
                SymbolKind _ABY = this.EFI._AT;
                SymbolKind symbolKind = _ABY;
                if (symbolKind == SymbolKind.Interface || symbolKind - SymbolKind.Struct <= 1)
                {
                    return (_bc6)this.EFI._ACV;
                }
            }
            return (base._AMJ() != null) ? base._AMJ().EnclosingType() : null;
        }

        // Token: 0x060006D4 RID: 1748 RVA: 0x000E8620 File Offset: 0x000E6820
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            bool flag = this.EFI != null && this.EFI._ACV != null;
            if (flag)
            {
                List<_bd7> typeParameters = this.EFI._ACV.GetTypeParameters();
                bool flag2 = typeParameters != null;
                if (flag2)
                {
                    int count = typeParameters.Count;
                    while (count-- > 0)
                    {
                        _bd7 _AHM = typeParameters[count];
                        bool flag3 = !data.ContainsKey(_AHM._AW);
                        if (flag3)
                        {
                            data.Add(_AHM._AW, _AHM);
                        }
                    }
                }
            }
            base.GetCompletionData(data, context);
        }

        // Token: 0x040005B0 RID: 1456
        public FKI EFI;
    }
}
