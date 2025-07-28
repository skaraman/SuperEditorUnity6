using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SuperEditor;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200000B RID: 11
    internal static class _bh6
    {
        // Token: 0x0600002D RID: 45 RVA: 0x0000344C File Offset: 0x0000164C
        internal static List<FKI> FindDeclarations(_bh4 symbol)
        {
            symbol = symbol.GetGenericSymbol();
            List<string> list = _bh6.FindDefinitionCandidates(symbol, true);
            foreach (string text in list)
            {
                TextAsset textAsset = AssetDatabase.LoadAssetAtPath(text, typeof(TextAsset)) as TextAsset;
                bool flag = !textAsset;
                if (!flag)
                {
                    GCE buffer = _bc5.GetBuffer(textAsset);
                    buffer.LoadImmediately();
                }
            }
            _bh4 _AAH = symbol.Rebind();
            List<FKI> list2 = ((_AAH == null) ? null : _AAH._AEI);
            bool flag2 = list2 == null && symbol._AEI == null && symbol.Assembly != null;
            if (flag2)
            {
                list = _bh6.FindDefinitionCandidates(symbol, false);
                foreach (string text2 in list)
                {
                    TextAsset textAsset2 = AssetDatabase.LoadAssetAtPath(text2, typeof(TextAsset)) as TextAsset;
                    bool flag3 = !textAsset2;
                    if (!flag3)
                    {
                        GCE buffer2 = _bc5.GetBuffer(textAsset2);
                        buffer2.LoadImmediately();
                    }
                }
                _AAH = symbol.Rebind();
                list2 = ((_AAH == null) ? null : _AAH._AEI);
            }
            return list2 ?? symbol._AEI;
        }

        // Token: 0x0600002E RID: 46 RVA: 0x000035C0 File Offset: 0x000017C0
        private static List<string> FindDefinitionCandidates(_bh4 symbol, bool fileSameName = true)
        {
            List<string> list = new List<string>();
            bool flag = _bh6._AOT != null;
            if (flag)
            {
                _bh6._AOT.Clear();
            }
            _bh4 _AAH = symbol;
            bool flag2 = symbol._AT == SymbolKind.Namespace;
            List<string> list2;
            if (flag2)
            {
                list2 = list;
            }
            else
            {
                while (_AAH != null && _AAH._AT != SymbolKind.Class && _AAH._AT != SymbolKind.Struct && _AAH._AT != SymbolKind.Enum && _AAH._AT != SymbolKind.Interface && _AAH._AT != SymbolKind.Delegate)
                {
                    _AAH = _AAH._AO;
                }
                _bj5 _AOS = _AAH.Assembly;
                _bh6.FindAllAssemblyScripts(_AOS);
                int count = _bh6._AOT.Count;
                while (count-- > 0)
                {
                    _bh6._AOT[count] = AssetDatabase.GUIDToAssetPath(_bh6._AOT[count]);
                }
                string _ADY = _AAH._AW;
                string[] array;
                switch (_AAH._AT)
                {
                    case SymbolKind.Interface:
                        array = new string[] { "interface", _ADY };
                        break;
                    case SymbolKind.Enum:
                        array = new string[] { "enum", _ADY };
                        break;
                    case SymbolKind.Struct:
                        array = new string[] { "struct", _ADY };
                        break;
                    case SymbolKind.Class:
                        array = new string[] { "class", _ADY };
                        break;
                    case SymbolKind.Delegate:
                        array = new string[] { _ADY, "(" };
                        break;
                    default:
                        return list;
                }
                if (fileSameName)
                {
                    string[] array2 = AssetDatabase.FindAssets("t:Script " + array[1]);
                    bool flag3 = array2.Length != 0;
                    if (flag3)
                    {
                        int num = array2.Length;
                        while (num-- > 0)
                        {
                            string text = AssetDatabase.GUIDToAssetPath(array2[num]);
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
                            bool flag4 = fileNameWithoutExtension == array[1] && _bh6.ContainsWordsSequence(text, array);
                            if (flag4)
                            {
                                list.Add(text);
                            }
                        }
                    }
                }
                else
                {
                    int count2 = _bh6._AOT.Count;
                    while (count2-- > 0)
                    {
                        bool flag5 = _bh6.ContainsWordsSequence(_bh6._AOT[count2], array);
                        if (flag5)
                        {
                            list.Add(_bh6._AOT[count2]);
                        }
                    }
                }
                list2 = list;
            }
            return list2;
        }

        // Token: 0x0600002F RID: 47 RVA: 0x0000381C File Offset: 0x00001A1C
        internal static void FindAllReferences(_bh4 symbol, string localAssetPath)
        {
            bool flag = symbol._AT == SymbolKind.Accessor || symbol._AT == SymbolKind.Constructor || symbol._AT == SymbolKind.Destructor;
            if (flag)
            {
                symbol = symbol._AO;
            }
            bool flag2 = symbol == null;
            if (!flag2)
            {
                symbol = symbol.GetGenericSymbol();
                List<string> list = _bh6.FindReferenceCandidates(symbol, localAssetPath);
                _bk5._AZL _AZM = new _bk5._AZL
                {
                    _ABG = symbol._AW,
                    _AZN = true,
                    _AYS = true
                };
                string[] array = new string[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    array[i] = AssetDatabase.AssetPathToGUID(list[i]);
                }
                bool flag3 = symbol is _b2 && symbol._AT != SymbolKind.Delegate;
                bool flag4 = flag3;
                if (flag4)
                {
                    _AZM.ADFICBDCAFGKMIJLIPIODEIIEIDNJMDGIJFJ = "var";
                    Dictionary<string, _b2>.Enumerator enumerator = _bh4._ABO.GetEnumerator();
                    for (int j = 0; j < 16; j++)
                    {
                        enumerator.MoveNext();
                        KeyValuePair<string, _b2> keyValuePair = enumerator.Current;
                        _b2 value = keyValuePair.Value;
                        bool flag5 = value == symbol;
                        if (flag5)
                        {
                            _bk5._AZL _AZM2 = _AZM;
                            keyValuePair = enumerator.Current;
                            _AZM2.EIFANAJKPEMGMDMGCIMKIEMEBINHJOFDNKAM = keyValuePair.Key;
                            break;
                        }
                    }
                }
                _bk5 _AZF = _bk5.Create("References to " + symbol._AYM(), new Action<Action<string, string, TextPosition, int>, string, _bk5._AZL>(_bh6.FindAllInSingleFile), array, _AZM, "References");
                _AZF.SetFilesValidator(new _bk5.EIJNJHPLNPFJGGJHJPGEMFCMHALBIIFBBOEI(_bh6.ValidateFileForReferences));
                _AZF.SetResultsValidator(new _bk5.ONEILDCAMHIOCHJBHGPGBFLIDNIFNKFCIGAD(_bh6.ValidateResultAsReference), symbol);
            }
        }

        // Token: 0x06000030 RID: 48 RVA: 0x000039B4 File Offset: 0x00001BB4
        internal static void RenameSymbol(_bh4 symbol, string localAssetPath, string renameText)
        {
            bool flag = symbol._AT == SymbolKind.Accessor || symbol._AT == SymbolKind.TypeAlias;
            if (!flag)
            {
                bool flag2 = symbol._AT == SymbolKind.Constructor || symbol._AT == SymbolKind.Destructor;
                if (flag2)
                {
                    symbol = symbol._AO;
                }
                bool flag3 = symbol == null;
                if (!flag3)
                {
                    symbol = symbol.GetGenericSymbol();
                    List<string> list = _bh6.FindReferenceCandidates(symbol, localAssetPath);
                    _bk5._AZL _AZM = new _bk5._AZL
                    {
                        _ABG = symbol._AW,
                        _AZN = true,
                        _AYS = true
                    };
                    string[] array = new string[list.Count];
                    for (int i = 0; i < list.Count; i++)
                    {
                        array[i] = AssetDatabase.AssetPathToGUID(list[i]);
                    }
                    bool flag4 = symbol is _b2 && symbol._AT != SymbolKind.Delegate;
                    bool flag5 = flag4;
                    if (flag5)
                    {
                        _AZM.ADFICBDCAFGKMIJLIPIODEIIEIDNJMDGIJFJ = "var";
                        Dictionary<string, _b2>.Enumerator enumerator = _bh4._ABO.GetEnumerator();
                        for (int j = 0; j < 16; j++)
                        {
                            enumerator.MoveNext();
                            KeyValuePair<string, _b2> keyValuePair = enumerator.Current;
                            _b2 value = keyValuePair.Value;
                            bool flag6 = value == symbol;
                            if (flag6)
                            {
                                _bk5._AZL _AZM2 = _AZM;
                                keyValuePair = enumerator.Current;
                                _AZM2.EIFANAJKPEMGMDMGCIMKIEMEBINHJOFDNKAM = keyValuePair.Key;
                                break;
                            }
                        }
                    }
                    _bk5 _AZF = _bk5.Create("Rename " + symbol._AYM(), new Action<Action<string, string, TextPosition, int>, string, _bk5._AZL>(_bh6.FindAllInSingleFile), array, _AZM, "Rename");
                    _AZF.SetFilesValidator(new _bk5.EIJNJHPLNPFJGGJHJPGEMFCMHALBIIFBBOEI(_bh6.ValidateFileForReferences));
                    _AZF.SetResultsValidator(new _bk5.ONEILDCAMHIOCHJBHGPGBFLIDNIFNKFCIGAD(_bh6.ValidateResultAsReference), symbol);
                    _AZF.SetReplaceText(renameText);
                }
            }
        }

        // Token: 0x06000031 RID: 49 RVA: 0x00003B6C File Offset: 0x00001D6C
        private static bool ValidateFileForReferences(string assetGuid, _bk5.OLICOJKMCLBLLGDNHPLEFMBEBCBOMOGCCFMG options)
        {
            string text = AssetDatabase.GUIDToAssetPath(assetGuid);
            bool flag = text.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
            bool flag2 = flag;
            bool flag3;
            if (flag2)
            {
                flag3 = true;
            }
            else
            {
                bool flag4 = _bg3._AZJ.Contains(Path.GetExtension(text).ToLowerInvariant());
                if (flag4)
                {
                    flag3 = options.NBPNKNDFNIPKOLLALEOOIMBKKCNKKCICIPLE;
                }
                else
                {
                    flag3 = options._AIC;
                }
            }
            return flag3;
        }

        // Token: 0x06000032 RID: 50 RVA: 0x00003BC8 File Offset: 0x00001DC8
        private static _bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK ValidateResultAsReference(string assetGuid, TextPosition location, int length, ref _bh4 referencedSymbol)
        {
            string text = AssetDatabase.GUIDToAssetPath(assetGuid);
            bool flag = string.IsNullOrEmpty(text);
            _bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK bpkllieiaimnbnmjccecpkdeheoodpgmplbk;
            if (flag)
            {
                bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
            }
            else
            {
                bool flag2 = text.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
                GCE buffer = _bc5.GetBuffer(assetGuid);
                bool flag3 = buffer == null;
                if (flag3)
                {
                    bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                }
                else
                {
                    bool flag4 = buffer._AOU() == null;
                    if (flag4)
                    {
                        buffer.LoadImmediately();
                        referencedSymbol = referencedSymbol.Rebind();
                    }
                    GCE.PHFG _AUB = buffer._AQQ[location.line];
                    string text2 = buffer.FLOg[location.line];
                    bool flag5 = length == 3 && referencedSymbol is _b2 && location.index + 3 < text2.Length && text2[location.index] == 'v' && text2[location.index + 1] == 'a' && text2[location.index + 2] == 'r';
                    bool flag6 = flag2;
                    if (flag6)
                    {
                        bool flag7 = _AUB._ABZ._AT > (GCE._ABW._ABX)5;
                        if (flag7)
                        {
                            bool flag8 = flag5;
                            if (flag8)
                            {
                                return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                            }
                            return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)12;
                        }
                    }
                    else
                    {
                        bool flag9 = flag5;
                        if (flag9)
                        {
                            return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                        }
                    }
                    int num;
                    bool flag10;
                    SyntaxToken tokenAt = buffer.GetTokenAt(new TextPosition(location.line, location.index + 1), out location.line, out num, out flag10);
                    switch (tokenAt.tokenKind)
                    {
                        case SyntaxToken.Kind.Comment:
                        case SyntaxToken.Kind.PreprocessorArguments:
                        case SyntaxToken.Kind.PreprocessorSymbol:
                            {
                                bool flag11 = flag5;
                                if (flag11)
                                {
                                    return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                                }
                                return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)13;
                            }
                        case SyntaxToken.Kind.Preprocessor:
                            return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                        case SyntaxToken.Kind.VerbatimStringLiteral:
                        case SyntaxToken.Kind.VerbatimStringBegin:
                        case SyntaxToken.Kind.StringLiteral:
                        case SyntaxToken.Kind.InterpolatedStringWholeLiteral:
                        case SyntaxToken.Kind.InterpolatedStringStartLiteral:
                        case SyntaxToken.Kind.InterpolatedStringMidLiteral:
                        case SyntaxToken.Kind.InterpolatedStringEndLiteral:
                        case SyntaxToken.Kind.InterpolatedStringFormatLiteral:
                            {
                                bool flag12 = flag5;
                                if (flag12)
                                {
                                    return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                                }
                                return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)14;
                            }
                    }
                    bool flag13 = !flag2 || tokenAt.OOME == null;
                    if (flag13)
                    {
                        bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (flag5 ? ((_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)11) : ((_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)10));
                    }
                    else
                    {
                        _bh4 _AAH = tokenAt.OOME._AAB();
                        bool flag14 = _AAH == null || _AAH._AT == SymbolKind.Error;
                        if (flag14)
                        {
                            _bc9.ResolveNode(tokenAt.OOME.OOME);
                        }
                        bool flag15 = _AAH != null && _AAH._AT == SymbolKind.MethodGroup && tokenAt.OOME.OOME != null;
                        if (flag15)
                        {
                            _bb4.DHBA _AEM = tokenAt.OOME.OOME.FindNextLeaf();
                            bool flag16 = _AEM != null && _AEM.IsLit("(");
                            if (flag16)
                            {
                                _bb4._ACW _AMI = _AEM.OOME;
                                bool flag17 = _AMI._AHB() == "arguments";
                                if (flag17)
                                {
                                    _bc9.ResolveNode(_AMI);
                                    bool flag18 = tokenAt.OOME != null;
                                    if (flag18)
                                    {
                                        bool flag19 = tokenAt.OOME._AAB() == null || tokenAt.OOME._AAB()._AT == SymbolKind.Error;
                                        if (flag19)
                                        {
                                            tokenAt.OOME._ACY(_AAH);
                                        }
                                    }
                                }
                            }
                        }
                        _AAH = ((tokenAt.OOME != null) ? tokenAt.OOME._AAB() : null);
                        bool flag20 = _AAH == null || _AAH._AT == SymbolKind.Error;
                        if (flag20)
                        {
                            bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (flag5 ? ((_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)11) : ((_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)10));
                        }
                        else
                        {
                            bool flag21 = _AAH._AT == SymbolKind.Constructor || _AAH._AT == SymbolKind.Destructor;
                            if (flag21)
                            {
                                _AAH = _AAH._AO;
                            }
                            bool flag22 = _AAH == null || _AAH._AT == SymbolKind.Error;
                            if (flag22)
                            {
                                bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (flag5 ? ((_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)11) : ((_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)10));
                            }
                            else
                            {
                                _bh4 _AAH2 = _AAH;
                                _AAH = _AAH.GetGenericSymbol();
                                bool flag23 = referencedSymbol._AT == SymbolKind.MethodGroup && _AAH._AT == SymbolKind.Method;
                                if (flag23)
                                {
                                    _AAH = _AAH._AO;
                                }
                                bool flag24 = _AAH != referencedSymbol;
                                if (flag24)
                                {
                                    _b2 _AAC = referencedSymbol as _b2;
                                    _bi5 _AAE = _AAH2 as _bi5;
                                    bool flag25 = flag5 && _AAC != null && _AAE != null;
                                    if (flag25)
                                    {
                                        bool flag26 = _bh6.IsUsedAsTypeArgument(_AAC.GetGenericSymbol() as _b2, _AAE);
                                        if (flag26)
                                        {
                                            return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)9;
                                        }
                                    }
                                    bool flag27 = (_AAH._AT == SymbolKind.Property && referencedSymbol._AT == SymbolKind.Property) || (_AAH._AT == SymbolKind.Event && referencedSymbol._AT == SymbolKind.Event) || (_AAH._AT == SymbolKind.Indexer && referencedSymbol._AT == SymbolKind.Indexer);
                                    if (flag27)
                                    {
                                        _bn3 _BFM = _AAH as _bn3;
                                        _bn3 _BFM2 = referencedSymbol as _bn3;
                                        bool flag28 = _BFM != null && _BFM2 != null;
                                        if (flag28)
                                        {
                                            _b2 _AAC2 = (_BFM._AO as _b2) ?? (_BFM._AO._AO as _b2);
                                            _b2 _AAC3 = (_BFM2._AO as _b2) ?? (_BFM2._AO._AO as _b2);
                                            bool flag29 = (_AAC2 != null && _AAC2._AT == SymbolKind.Interface) || (_AAC3 != null && _AAC3._AT == SymbolKind.Interface);
                                            bool flag30 = flag29 || _BFM._AHF() || _BFM._AAO() || _BFM._AAP();
                                            bool flag31 = flag29 || _BFM2._AHF() || _BFM2._AAO() || _BFM2._AAP();
                                            bool flag32 = flag30 && flag31;
                                            if (flag32)
                                            {
                                                bool flag33;
                                                if (_AAH._AT == SymbolKind.Indexer)
                                                {
                                                    flag33 = (from x in _BFM.GetParameters()
                                                              select x.TypeOf()).SequenceEqual(from x in _BFM2.GetParameters()
                                                                                               select x.TypeOf());
                                                }
                                                else
                                                {
                                                    flag33 = true;
                                                }
                                                bool flag34 = flag33;
                                                if (flag34)
                                                {
                                                    bool flag35 = _AAC2 != null && _AAC2.DerivesFrom(_AAC3);
                                                    if (flag35)
                                                    {
                                                        return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)6;
                                                    }
                                                    bool flag36 = _AAC3 != null && _AAC3.DerivesFrom(_AAC2);
                                                    if (flag36)
                                                    {
                                                        return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)7;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    bool flag37 = _AAH._AT == SymbolKind.Method && referencedSymbol._AT == SymbolKind.Method;
                                    if (flag37)
                                    {
                                        bool flag38 = _AAH._AO == referencedSymbol._AO;
                                        if (flag38)
                                        {
                                            return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)5;
                                        }
                                        _bb3 _AAN = _AAH as _bb3;
                                        _bb3 _AAN2 = referencedSymbol as _bb3;
                                        bool flag39 = _AAN != null && _AAN2 != null;
                                        if (flag39)
                                        {
                                            _b2 _AAC4 = (_AAN._AO as _b2) ?? (_AAN._AO._AO as _b2);
                                            _b2 _AAC5 = (_AAN2._AO as _b2) ?? (_AAN2._AO._AO as _b2);
                                            bool flag40 = (_AAC4 != null && _AAC4._AT == SymbolKind.Interface) || (_AAC5 != null && _AAC5._AT == SymbolKind.Interface);
                                            bool flag41 = flag40 || _AAN._AHF() || _AAN._AAO() || _AAN._AAP();
                                            bool flag42 = flag40 || _AAN2._AHF() || _AAN2._AAO() || _AAN2._AAP();
                                            bool flag43 = flag41 && flag42;
                                            if (flag43)
                                            {
                                                bool flag44 = (from x in _AAN.GetParameters()
                                                               select x.TypeOf()).SequenceEqual(from x in _AAN2.GetParameters()
                                                                                                select x.TypeOf());
                                                if (flag44)
                                                {
                                                    bool flag45 = _AAC4 != null && _AAC4.DerivesFrom(_AAC5);
                                                    if (flag45)
                                                    {
                                                        return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)6;
                                                    }
                                                    bool flag46 = _AAC5 != null && _AAC5.DerivesFrom(_AAC4);
                                                    if (flag46)
                                                    {
                                                        return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)7;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    bool flag47 = _AAH._AT != SymbolKind.MethodGroup || referencedSymbol._AO != _AAH;
                                    if (flag47)
                                    {
                                        return (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)1;
                                    }
                                }
                                bool flag48 = flag5;
                                if (flag48)
                                {
                                    bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)8;
                                }
                                else
                                {
                                    bool flag49 = _bc9.IsWriteReference(tokenAt);
                                    if (flag49)
                                    {
                                        bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)2;
                                    }
                                    else
                                    {
                                        bpkllieiaimnbnmjccecpkdeheoodpgmplbk = (_bk5.BPKLLIEIAIMNBNMJCCECPKDEHEOODPGMPLBK)3;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bpkllieiaimnbnmjccecpkdeheoodpgmplbk;
        }

        // Token: 0x06000033 RID: 51 RVA: 0x00004408 File Offset: 0x00002608
        private static bool IsUsedAsTypeArgument(_b2 typeArgument, _bi5 constructedType)
        {
            KJK[] _AIR = constructedType._AHH;
            bool flag = _AIR == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                int num = _AIR.Length;
                while (num-- > 0)
                {
                    KJK _AAD = _AIR[num];
                    bool flag3 = _AAD == null;
                    if (!flag3)
                    {
                        _bh4 definition = _AAD.definition;
                        bool flag4 = definition == null;
                        if (!flag4)
                        {
                            bool flag5 = definition.GetGenericSymbol() == typeArgument;
                            if (flag5)
                            {
                                return true;
                            }
                            _bi5 _AAE = definition as _bi5;
                            bool flag6 = _AAE != null && _bh6.IsUsedAsTypeArgument(typeArgument, _AAE);
                            if (flag6)
                            {
                                return true;
                            }
                        }
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x06000034 RID: 52 RVA: 0x000044A4 File Offset: 0x000026A4
        private static List<string> FindReferenceCandidates(_bh4 symbol, string localAssetPath)
        {
            List<string> list = new List<string> { localAssetPath };
            bool flag = _bh6._AOT != null;
            if (flag)
            {
                _bh6._AOT.Clear();
            }
            else
            {
                _bh6._AOT = new List<string>();
            }
            bool flag2 = symbol._AT == SymbolKind.CatchParameter || symbol._AT == SymbolKind.Destructor || symbol._AT == SymbolKind.ForEachVariable || symbol._AT == SymbolKind.FromClauseVariable || symbol._AT == SymbolKind.Label || symbol._AT == SymbolKind.LambdaExpression || symbol._AT == SymbolKind.LocalConstant || symbol._AT == SymbolKind.Parameter || symbol._AT == SymbolKind.Variable;
            List<string> list2;
            if (flag2)
            {
                list2 = list;
            }
            else
            {
                List<string> list3 = _bh6.FindAllTextAssets();
                int count = list3.Count;
                while (count-- > 0)
                {
                    string text = AssetDatabase.GUIDToAssetPath(list3[count]);
                    bool flag3 = text != localAssetPath;
                    if (flag3)
                    {
                        bool flag4 = !_bh6._AZH.Contains(Path.GetExtension(text.ToLowerInvariant()));
                        if (flag4)
                        {
                            _bh6._AOT.Add(AssetDatabase.GUIDToAssetPath(list3[count]));
                        }
                    }
                }
                int count2 = _bh6._AOT.Count;
                while (count2-- > 0)
                {
                    list.Add(_bh6._AOT[count2]);
                }
                list.Sort(delegate (string a, string b)
                {
                    int num = (a.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) ? 1 : 0);
                    int num2 = (b.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) ? 1 : 0);
                    bool flag5 = num != 0 && num2 != 0;
                    int num3;
                    if (flag5)
                    {
                        num3 = num2 - num;
                    }
                    else
                    {
                        bool flag6 = a.EndsWith(".js", StringComparison.OrdinalIgnoreCase);
                        bool flag7 = b.EndsWith(".js", StringComparison.OrdinalIgnoreCase);
                        bool flag8 = flag6 || flag7;
                        if (flag8)
                        {
                            num3 = (flag7 ? 1 : 0) - (flag6 ? 1 : 0);
                        }
                        else
                        {
                            num3 = 0;
                        }
                    }
                    return num3;
                });
                list2 = list;
            }
            return list2;
        }

        // Token: 0x06000035 RID: 53 RVA: 0x00004624 File Offset: 0x00002824
        internal static void FindAllInSingleFile(Action<string, string, TextPosition, int> addResultAction, string assetGuid, _bk5._AZL search)
        {
            string text = AssetDatabase.GUIDToAssetPath(assetGuid);
            bool flag = Path.GetExtension(text).Equals(".cs", StringComparison.OrdinalIgnoreCase);
            IList<string> orReadAllLines = _bh6.GetOrReadAllLines(assetGuid);
            bool flag2 = !flag || search.ADFICBDCAFGKMIJLIPIODEIIEIDNJMDGIJFJ == null;
            if (flag2)
            {
                foreach (TextPosition textPosition in _bh6.FindAll(orReadAllLines, search))
                {
                    string text2 = orReadAllLines[textPosition.line];
                    addResultAction(text2, assetGuid, textPosition, search._ABG.Length);
                }
            }
            else
            {
                IEnumerator<TextPosition> enumerator2 = _bh6.FindAll(orReadAllLines, search).GetEnumerator();
                _bk5._AZL _AZM = new _bk5._AZL
                {
                    _ABG = search.ADFICBDCAFGKMIJLIPIODEIIEIDNJMDGIJFJ,
                    _AYS = search._AYS,
                    _AZN = search._AZN
                };
                IEnumerator<TextPosition> enumerator3 = _bh6.FindAll(orReadAllLines, _AZM).GetEnumerator();
                IEnumerator<TextPosition> enumerator4 = null;
                bool flag3 = search.EIFANAJKPEMGMDMGCIMKIEMEBINHJOFDNKAM != null;
                if (flag3)
                {
                    _bk5._AZL _AZM2 = new _bk5._AZL
                    {
                        _ABG = search.EIFANAJKPEMGMDMGCIMKIEMEBINHJOFDNKAM,
                        _AYS = search._AYS,
                        _AZN = search._AZN
                    };
                    enumerator4 = _bh6.FindAll(orReadAllLines, _AZM2).GetEnumerator();
                }
                bool flag4 = enumerator2.MoveNext();
                bool flag5 = enumerator3.MoveNext();
                bool flag6 = enumerator4 != null && enumerator4.MoveNext();
                while (flag4 || flag5 || flag6)
                {
                    bool flag7 = flag4 && (!flag5 || enumerator2.Current <= enumerator3.Current) && (!flag6 || enumerator2.Current <= enumerator4.Current);
                    if (flag7)
                    {
                        string text3 = orReadAllLines[enumerator2.Current.line];
                        addResultAction(text3, assetGuid, enumerator2.Current, search._ABG.Length);
                        flag4 = enumerator2.MoveNext();
                    }
                    else
                    {
                        bool flag8 = flag5 && (!flag4 || enumerator3.Current <= enumerator2.Current) && (!flag6 || enumerator3.Current <= enumerator4.Current);
                        if (flag8)
                        {
                            string text4 = orReadAllLines[enumerator3.Current.line];
                            addResultAction(text4, assetGuid, enumerator3.Current, search.ADFICBDCAFGKMIJLIPIODEIIEIDNJMDGIJFJ.Length);
                            flag5 = enumerator3.MoveNext();
                        }
                        else
                        {
                            string text5 = orReadAllLines[enumerator4.Current.line];
                            addResultAction(text5, assetGuid, enumerator4.Current, search.EIFANAJKPEMGMDMGCIMKIEMEBINHJOFDNKAM.Length);
                            flag6 = enumerator4.MoveNext();
                        }
                    }
                }
            }
        }

        // Token: 0x06000036 RID: 54 RVA: 0x000048E0 File Offset: 0x00002AE0
        internal static IList<string> GetOrReadAllLines(string assetGuid)
        {
            string text = AssetDatabase.GUIDToAssetPath(assetGuid);
            return _bh6.GetOrReadAllLinesForPath(text);
        }

        // Token: 0x06000037 RID: 55 RVA: 0x00004900 File Offset: 0x00002B00
        internal static IList<string> GetOrReadAllLinesForPath(string assetPath)
        {
            string[] array;
            try
            {
                GCE _AMX = _bc5.TryGetBuffer(assetPath);
                bool flag = _AMX != null;
                if (flag)
                {
                    return _AMX.FLOg;
                }
                array = File.ReadAllLines(assetPath);
            }
            catch (IOException ex)
            {
                Debug.LogError(ex);
                return null;
            }
            return array;
        }

        // Token: 0x06000038 RID: 56 RVA: 0x00004958 File Offset: 0x00002B58
        internal static IEnumerable<TextPosition> FindAll(IList<string> lines, _bk5._AZL search)
        {
            int length = search._ABG.Length;
            bool flag = length == 0;
            if (flag)
            {
                yield break;
            }
            StringComparison comparison = (search._AYS ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
            char firstChar = search._ABG[0];
            bool startsAsWord = firstChar == '_' || char.IsLetterOrDigit(firstChar);
            char lastChar = search._ABG[search._ABG.Length - 1];
            bool endsAsWord = lastChar == '_' || char.IsLetterOrDigit(lastChar);
            int skipThisWord = search._ABG.IndexOf(firstChar.ToString(), 1, comparison);
            bool flag2 = skipThisWord < 0;
            if (flag2)
            {
                skipThisWord = search._ABG.Length;
            }
            int i = 0;
            int c = 0;
            while (i < lines.Count)
            {
                string line = lines[i];
                bool flag3 = c > line.Length - length;
                if (flag3)
                {
                    c = 0;
                    int num = i + 1;
                    i = num;
                }
                else
                {
                    c = line.IndexOf(search._ABG, c, comparison);
                    bool flag4 = c < 0;
                    if (flag4)
                    {
                        c = 0;
                        int num = i + 1;
                        i = num;
                    }
                    else
                    {
                        bool fggbiibieiajeneiceejdjnocfpdpkdljpbm = search._AZN;
                        if (fggbiibieiajeneiceejdjnocfpdpkdljpbm)
                        {
                            bool flag5 = startsAsWord && c > 0;
                            if (flag5)
                            {
                                char prevChar = line[c - 1];
                                bool flag6 = prevChar == '_' || char.IsLetterOrDigit(prevChar);
                                if (flag6)
                                {
                                    c += skipThisWord;
                                    continue;
                                }
                            }
                            bool flag7 = endsAsWord && c + length < line.Length;
                            if (flag7)
                            {
                                char nextChar = line[c + length];
                                bool flag8 = nextChar == '_' || char.IsLetterOrDigit(nextChar);
                                if (flag8)
                                {
                                    c += skipThisWord;
                                    continue;
                                }
                            }
                        }
                        yield return new TextPosition(i, c);
                        c += length;
                        line = null;
                    }
                }
            }
            yield break;
        }

        // Token: 0x06000039 RID: 57 RVA: 0x00004970 File Offset: 0x00002B70
        internal static bool ContainsWordsSequence(string assetPath, params string[] words)
        {
            try
            {
                string[] array = File.ReadAllLines(assetPath);
                int i = 0;
                int j = 0;
                while (i < array.Length)
                {
                    bool flag = j > array[i].Length - words[0].Length;
                    if (flag)
                    {
                        j = 0;
                        i++;
                    }
                    else
                    {
                        j = array[i].IndexOf(words[0], j, StringComparison.Ordinal);
                        bool flag2 = j < 0;
                        if (flag2)
                        {
                            j = 0;
                            i++;
                        }
                        else
                        {
                            bool flag3 = j > 0;
                            if (flag3)
                            {
                                char c = array[i][j - 1];
                                bool flag4 = c == '_' || char.IsLetterOrDigit(c);
                                if (flag4)
                                {
                                    j += words[0].Length;
                                    continue;
                                }
                            }
                            j += words[0].Length;
                            bool flag5 = j < array[i].Length;
                            if (flag5)
                            {
                                bool flag6 = words[1] != "(";
                                if (flag6)
                                {
                                    char c2 = array[i][j];
                                    j++;
                                    bool flag7 = c2 != ' ' && c2 != '\t';
                                    if (flag7)
                                    {
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                j = 0;
                                i++;
                                bool flag8 = i == array.Length;
                                if (flag8)
                                {
                                    break;
                                }
                            }
                            int k = 1;
                            while (k < words.Length)
                            {
                                while (j < array[i].Length)
                                {
                                    char c3 = array[i][j];
                                    bool flag9 = c3 == ' ' || c3 == '\t';
                                    if (!flag9)
                                    {
                                        break;
                                    }
                                    j++;
                                }
                                bool flag10 = j == array[i].Length;
                                if (flag10)
                                {
                                    j = 0;
                                    i++;
                                    bool flag11 = i == array.Length;
                                    if (flag11)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    bool flag12 = !array[i].Substring(j).StartsWith(words[k], StringComparison.Ordinal);
                                    if (flag12)
                                    {
                                        k = 0;
                                        break;
                                    }
                                    j += words[k].Length;
                                    bool flag13 = j < array[i].Length && words[k] != "(";
                                    if (flag13)
                                    {
                                        char c4 = array[i][j];
                                        bool flag14 = c4 == '_' || char.IsLetterOrDigit(c4);
                                        if (flag14)
                                        {
                                            k = 0;
                                            break;
                                        }
                                    }
                                    k++;
                                }
                            }
                            bool flag15 = k == words.Length;
                            if (flag15)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Debug.LogError(ex);
            }
            return false;
        }

        // Token: 0x0600003A RID: 58 RVA: 0x00004BE4 File Offset: 0x00002DE4
        internal static void Reset()
        {
            bool flag = _bh6._AOT != null;
            if (flag)
            {
                _bh6._AOT.Clear();
            }
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00004C0C File Offset: 0x00002E0C
        internal static List<string> FindAllTextAssets()
        {
            HierarchyProperty hierarchyProperty = new HierarchyProperty(HierarchyType.Assets);
            hierarchyProperty.SetSearchFilter("t:TextAsset", 0);
            hierarchyProperty.Reset();
            List<string> list = new List<string>();
            while (hierarchyProperty.Next(null))
            {
                list.Add(hierarchyProperty.guid);
            }
            return list;
        }

        // Token: 0x0600003C RID: 60 RVA: 0x00004C5C File Offset: 0x00002E5C
        internal static void FindAllAssemblyScripts(_bj5._AZG assemblyId)
        {
            bool flag = false;
            bool flag2 = false;
            string text = "";
            if (assemblyId - (_bj5._AZG)2 <= 1 || assemblyId - (_bj5._AZG)6 <= 1)
            {
                flag2 = true;
            }
            switch (assemblyId)
            {
                case (_bj5._AZG)2:
                case (_bj5._AZG)6:
                case (_bj5._AZG)10:
                case (_bj5._AZG)14:
                    text = ".cs";
                    break;
                case (_bj5._AZG)3:
                case (_bj5._AZG)7:
                case (_bj5._AZG)11:
                case (_bj5._AZG)15:
                    text = ".js";
                    break;
            }
            if (assemblyId - (_bj5._AZG)6 <= 1 || assemblyId - (_bj5._AZG)14 <= 1)
            {
                flag = true;
            }
            string[] files = Directory.GetFiles("Assets", "*" + text, SearchOption.AllDirectories);
            int num = files.Length;
            bool flag3 = _bh6._AOT == null;
            if (flag3)
            {
                _bh6._AOT = new List<string>(num);
            }
            int num2 = num;
            while (num2-- > 0)
            {
                string text2 = files[num2];
                text2 = (files[num2] = text2.Replace('\\', '/'));
                string text3 = text2.ToLowerInvariant();
                bool flag4 = text2.Contains("/.") || _bj5.IsIgnoredScript(text3);
                if (flag4)
                {
                    files[num2] = files[--num];
                }
                else
                {
                    files[num2] = AssetDatabase.AssetPathToGUID(files[num2]);
                    string extension = Path.GetExtension(text3);
                    bool flag5 = extension != text;
                    if (flag5)
                    {
                        files[num2] = files[--num];
                    }
                    else
                    {
                        bool flag6 = text3.StartsWith("assets/standard assets/", StringComparison.Ordinal) || text3.StartsWith("assets/pro standard assets/", StringComparison.Ordinal) || text3.StartsWith("assets/plugins/", StringComparison.Ordinal);
                        bool flag7 = flag2 != flag6;
                        if (flag7)
                        {
                            files[num2] = files[--num];
                        }
                        else
                        {
                            bool flag8 = flag6;
                            bool flag9;
                            if (flag8)
                            {
                                flag9 = text3.StartsWith("assets/plugins/editor/", StringComparison.Ordinal) || text3.StartsWith("assets/standard assets/editor/", StringComparison.Ordinal) || text3.StartsWith("assets/pro standard assets/editor/", StringComparison.Ordinal);
                            }
                            else
                            {
                                flag9 = text3.Contains("/editor/");
                            }
                            bool flag10 = flag != flag9;
                            if (flag10)
                            {
                                files[num2] = files[--num];
                            }
                            else
                            {
                                _bh6._AOT.Add(files[num2]);
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00004EAC File Offset: 0x000030AC
        internal static void FindAllAssemblyScripts(_bj5 assembly)
        {
            string[] array = AssetDatabase.FindAssets("t:Script", new string[] { "Assets", "Packages" });
            int num = array.Length;
            bool flag = _bh6._AOT == null;
            if (flag)
            {
                _bh6._AOT = new List<string>(num);
            }
            int num2 = num;
            while (num2-- > 0)
            {
                _bh6._AOT.Add(array[num2]);
            }
        }

        // Token: 0x04000058 RID: 88
        internal static List<string> _AOT;

        // Token: 0x04000059 RID: 89
        private static List<string> _AZH = new List<string> { ".dll", ".a", ".so", ".dylib", ".exe" };
    }
}
