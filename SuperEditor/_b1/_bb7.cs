using System;
using System.Collections.Generic;
using SuperEditor;

namespace AHO
{
    // Token: 0x020000B4 RID: 180
    internal class _bb7 : _bn3
    {
        // Token: 0x06000539 RID: 1337 RVA: 0x000D203C File Offset: 0x000D023C
        public _bh4 AddParameter(FKI symbol)
        {
            string text = symbol.Name;
            _bm1 _AGS = (_bm1)_bh4.Create(symbol);
            _AGS.BLH = new KJK(symbol._AEJ.FindChildByName("type"));
            _AGS._AO = this;
            bool flag = !string.IsNullOrEmpty(text);
            if (flag)
            {
                bool flag2 = this._AIK == null;
                if (flag2)
                {
                    this._AIK = new List<_bm1>();
                }
                this._AIK.Add(_AGS);
            }
            return _AGS;
        }

        // Token: 0x0600053A RID: 1338 RVA: 0x000D20BC File Offset: 0x000D02BC
        internal override _bh4 AddDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Parameter;
            _bh4 _AAH2;
            if (flag)
            {
                _bh4 _AAH = this.AddParameter(symbol);
                symbol._ACV = _AAH;
                _AAH2 = _AAH;
            }
            else
            {
                _AAH2 = base.AddDeclaration(symbol);
            }
            return _AAH2;
        }

        // Token: 0x0600053B RID: 1339 RVA: 0x000D20F8 File Offset: 0x000D02F8
        internal override void RemoveDeclaration(FKI symbol)
        {
            bool flag = symbol._AT == SymbolKind.Parameter && this._AIK != null;
            if (flag)
            {
                this._AIK.Remove((_bm1)symbol._ACV);
            }
            else
            {
                base.RemoveDeclaration(symbol);
            }
        }

        // Token: 0x0600053C RID: 1340 RVA: 0x000D2144 File Offset: 0x000D0344
        internal override List<_bm1> GetParameters()
        {
            return this._AIK ?? _bh4._AHV;
        }

        // Token: 0x0600053D RID: 1341 RVA: 0x000D2168 File Offset: 0x000D0368
        internal override _bh4 FindName(string memberName, int numTypeParameters, bool asTypeOnly)
        {
            memberName = _bh4.DecodeId(memberName);
            bool flag = !asTypeOnly && this._AIK != null;
            if (flag)
            {
                _bm1 _AGS = this._AIK.LastByName(memberName);
                bool flag2 = _AGS != null;
                if (flag2)
                {
                    return _AGS;
                }
            }
            return base.FindName(memberName, numTypeParameters, asTypeOnly);
        }

        // Token: 0x0600053E RID: 1342 RVA: 0x000D21BC File Offset: 0x000D03BC
        internal override void ResolveMember(_bb4.DHBA leaf, _bm6 context, int numTypeArgs, bool asTypeOnly)
        {
            bool flag = !asTypeOnly && this._AIK != null;
            if (flag)
            {
                string text = _bh4.DecodeId(leaf._ACX.text);
                _bm1 _AGS = this._AIK.LastByName(text);
                bool flag2 = _AGS != null;
                if (flag2)
                {
                    leaf._ACY(_AGS);
                    return;
                }
            }
            base.ResolveMember(leaf, context, numTypeArgs, asTypeOnly);
        }

        // Token: 0x0600053F RID: 1343 RVA: 0x000D2220 File Offset: 0x000D0420
        internal override void GetCompletionData(Dictionary<string, _bh4> data, _be4 context)
        {
            bool flag = this._AIK != null;
            if (flag)
            {
                int count = this._AIK.Count;
                while (count-- > 0)
                {
                    _bm1 _AGS = this._AIK[count];
                    bool flag2 = !data.ContainsKey(_AGS._AW);
                    if (flag2)
                    {
                        data.Add(_AGS._AW, _AGS);
                    }
                }
            }
        }

        // Token: 0x040004FB RID: 1275
        public List<_bm1> _AIK;
    }
}
