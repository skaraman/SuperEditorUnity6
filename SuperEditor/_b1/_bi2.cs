using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using ACGG;
using FEPKBIPDOHCNNFAKLHKGGCCCPGMCNPGGOCGM;
using SuperEditor;
using SuperEditor.IDE;
using SuperEditor.Themes;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;

namespace AHO
{
    // Token: 0x02000057 RID: 87
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class _bi2
    {
        // Token: 0x06000276 RID: 630 RVA: 0x00021A78 File Offset: 0x0001FC78
        internal float DoCodeNavigationToolbar()
        {
            this._AFO.yMin = this._AFO.yMin + 21f;
            Rect rect;
            rect..ctor(this._AFO.xMin, this._AFO.yMin - 21f, this._AFO.width, 21f);
            bool enabled = GUI.enabled;
            GUI.enabled = true;
            rect.width -= 60f;
            bool flag = Application.platform == 0;
            Vector2 vector;
            vector..ctor(27f, 21f);
            Rect rect2;
            rect2..ctor(0f, rect.yMin, vector.x, vector.y);
            GUI.enabled = this.CanGoBack() && this.CanEdit();
            _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.image = null;
            _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = "←";
            _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.tooltip = (_bg8._BCF ? (flag ? "Go Back\n(Command+Alt+Left)" : "Go Back\n(Ctrl+Alt+Left)") : "Go Back\n(Alt+Left)");
            bool flag2 = GUI.Button(rect2, _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, EditorStyles.toolbarButton);
            if (flag2)
            {
                this.GoToRecentLocation(false);
            }
            rect2.x += vector.x;
            GUI.enabled = this.CanGoForward() && this.CanEdit();
            _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = "→";
            _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.tooltip = (_bg8._BCF ? (flag ? "Go Forward\n(Command+Alt+Right)" : "Go Forward\n(Ctrl+Alt+Right)") : "Go Forward\n(Alt+Right)");
            bool flag3 = GUI.Button(rect2, _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, EditorStyles.toolbarButton);
            if (flag3)
            {
                this.GoToRecentLocation(true);
            }
            rect2.x += 28f;
            GUI.enabled = this.CanEdit();
            bool flag4 = this._ABH._ABI >= this._ABQ._AQQ.Length;
            float num;
            if (flag4)
            {
                GUI.enabled = enabled;
                num = 21f;
            }
            else
            {
                GCE.PHFG _AUB = null;
                SyntaxToken syntaxToken = null;
                int num2 = this._ABH._AEU;
                GCE.PHFG[] _AQS = this._ABQ._AQQ;
                List<string> flogicchcfaljohninkpcdacoidcghkimhpo = this._ABQ.FLOg;
                int count = flogicchcfaljohninkpcdacoidcghkimhpo.Count;
                int num3 = this._ABH._ABI;
                while (syntaxToken == null && num3 < count)
                {
                    GCE.PHFG _AUB2 = _AQS[num3];
                    bool flag5 = _AUB2 == null || _AUB2.EOIA == null;
                    if (flag5)
                    {
                        GUI.enabled = enabled;
                        return 21f;
                    }
                    List<SyntaxToken> _ABS = _AUB2.EOIA;
                    int count2 = _ABS.Count;
                    int i = 0;
                    while (num2 > 0 && i < count2 - 1)
                    {
                        num2 -= _ABS[i].text.Length;
                        bool flag6 = num2 > 0;
                        if (flag6)
                        {
                            i++;
                        }
                    }
                    while (i < count2)
                    {
                        SyntaxToken syntaxToken2 = _ABS[i];
                        bool flag7 = syntaxToken2.tokenKind > SyntaxToken.Kind.LastWSToken;
                        if (flag7)
                        {
                            bool flag8 = syntaxToken2.OOME != null && syntaxToken2.OOME.OOME != null;
                            if (flag8)
                            {
                                syntaxToken = syntaxToken2;
                            }
                            break;
                        }
                        bool flag9 = _AUB == null && syntaxToken2.tokenKind >= SyntaxToken.Kind.Preprocessor && syntaxToken2.tokenKind != SyntaxToken.Kind.VerbatimStringLiteral;
                        if (flag9)
                        {
                            _AUB = _AUB2;
                        }
                        i++;
                    }
                    num3++;
                }
                bool flag10 = syntaxToken == null;
                if (flag10)
                {
                    int num4 = this._ABH._ABI - 1;
                    while (syntaxToken == null && num4 >= 0)
                    {
                        GCE.PHFG _AUB3 = _AQS[num4];
                        bool flag11 = _AUB3 == null || _AUB3.EOIA == null;
                        if (flag11)
                        {
                            GUI.enabled = enabled;
                            return 21f;
                        }
                        List<SyntaxToken> _ABS2 = _AUB3.EOIA;
                        int count3 = _ABS2.Count;
                        while (count3-- > 0)
                        {
                            SyntaxToken syntaxToken3 = _ABS2[count3];
                            bool flag12 = syntaxToken3.tokenKind > SyntaxToken.Kind.LastWSToken;
                            if (flag12)
                            {
                                bool flag13 = syntaxToken3.OOME != null && syntaxToken3.OOME.OOME != null;
                                if (flag13)
                                {
                                    syntaxToken = _ABS2[count3];
                                }
                                break;
                            }
                            bool flag14 = _AUB == null && syntaxToken3.tokenKind >= SyntaxToken.Kind.Preprocessor && syntaxToken3.tokenKind != SyntaxToken.Kind.VerbatimStringLiteral;
                            if (flag14)
                            {
                                _AUB = _AUB3;
                            }
                        }
                        num4--;
                    }
                }
                bool flag15 = syntaxToken != null;
                if (flag15)
                {
                    _bh4 _AAH = null;
                    bool flag16 = syntaxToken.OOME != null;
                    if (flag16)
                    {
                        for (_bb4._ACW _AGZ = syntaxToken.OOME.OOME; _AGZ != null; _AGZ = _AGZ.OOME)
                        {
                            string text = _AGZ._AHB();
                            bool flag17 = text == "namespaceDeclaration" || text == "namespaceMemberDeclaration" || text == "classMemberDeclaration" || text == "structMemberDeclaration" || text == "interfaceMemberDeclaration" || text == "enumMemberDeclaration" || text == "delegateDeclaration" || text == "variableDeclarator" || text == "getAccessorDeclaration" || text == "setAccessorDeclaration" || text == "addAccessorDeclaration" || text == "removeAccessorDeclaration";
                            if (flag17)
                            {
                                bool flag18 = text == "namespaceMemberDeclaration" || text == "classMemberDeclaration" || text == "structMemberDeclaration" || text == "interfaceMemberDeclaration";
                                if (flag18)
                                {
                                    _AGZ = _AGZ.NodeAt(-1);
                                    text = ((_AGZ != null) ? _AGZ._AHB() : null);
                                }
                                bool flag19 = text == "constructorDeclaration" || text == "destructorDeclaration" || text == "operatorDeclaration" || text == "conversionOperatorDeclaration";
                                if (flag19)
                                {
                                    bool flag20 = _AGZ.EFI == null;
                                    if (flag20)
                                    {
                                        _AGZ = _AGZ.NodeAt(0);
                                        string text2 = ((_AGZ != null) ? _AGZ._AHB() : null);
                                    }
                                }
                                else
                                {
                                    bool flag21 = text == "fieldDeclaration";
                                    if (flag21)
                                    {
                                        _AGZ = _AGZ.FindChildByName("variableDeclarators", "variableDeclarator") as _bb4._ACW;
                                    }
                                    else
                                    {
                                        bool flag22 = text == "constantDeclaration";
                                        if (flag22)
                                        {
                                            _AGZ = _AGZ.FindChildByName("constantDeclarators", "constantDeclarator") as _bb4._ACW;
                                        }
                                        else
                                        {
                                            bool flag23 = text == "eventDeclaration";
                                            if (flag23)
                                            {
                                                _AGZ = (_AGZ.FindChildByName("eventWithAccessorsDeclaration") as _bb4._ACW) ?? (_AGZ.FindChildByName("eventDeclarators", "eventDeclarator") as _bb4._ACW);
                                            }
                                        }
                                    }
                                }
                                bool flag24 = _AGZ != null && _AGZ.EFI != null && _AGZ.EFI._ACV != null;
                                if (flag24)
                                {
                                    _AAH = _AGZ.EFI._ACV;
                                }
                                break;
                            }
                        }
                    }
                    bool flag25 = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM == null;
                    if (flag25)
                    {
                        bool flag26 = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM == null;
                        if (flag26)
                        {
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM = new GUIStyle(EditorStyles.foldout);
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF = new GUIStyle(EditorStyles.foldout);
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.normal = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onNormal;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.active = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onActive;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.hover = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onHover;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.focused = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onFocused;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM;
                            _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF;
                        }
                        else
                        {
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM = new GUIStyle(_bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM);
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.padding.top--;
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.padding.left = 0;
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.alignment = 0;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF = new GUIStyle(_bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM);
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.normal = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onNormal;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.active = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onActive;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.hover = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onHover;
                            _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.focused = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF.onFocused;
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.onNormal = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.normal;
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.onActive = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.active;
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.onHover = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.hover;
                            _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.onFocused = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM.focused;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB = new GUIStyle(_bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB);
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.padding.top--;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.alignment = 0;
                            _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP = new GUIStyle(_bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB);
                            _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.normal = _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.onNormal;
                            _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.active = _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.onActive;
                            _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.hover = _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.onHover;
                            _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.focused = _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP.onFocused;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.onNormal = _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.normal;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.onActive = _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.active;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.onHover = _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.hover;
                            _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.onFocused = _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB.focused;
                        }
                    }
                    bool flag27 = _AAH != null && !_AAH.IsValid();
                    if (flag27)
                    {
                        _AAH = null;
                    }
                    bool flag28 = _AAH != this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP || this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Count == 0;
                    if (flag28)
                    {
                        this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP = _AAH;
                        this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Clear();
                        bool flag29 = _AAH == null;
                        if (flag29)
                        {
                            this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Add(new _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP
                            {
                                IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM = new GUIContent("...")
                            });
                        }
                        else
                        {
                            while (_AAH != null && _AAH._AW != "")
                            {
                                bool isOperator = _AAH.IsOperator;
                                if (isOperator)
                                {
                                    bool flag30;
                                    string text3 = this.ReadableOperatorName(_AAH, out flag30);
                                    bool flag31 = flag30;
                                    if (flag31)
                                    {
                                        _bb3 _AAN = _AAH as _bb3;
                                        bool flag32 = _AAN != null;
                                        if (flag32)
                                        {
                                            text3 = text3 + "(" + _AAN.PrintParameters(_AAN.GetParameters(), true) + ")";
                                        }
                                    }
                                    _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP lcgoehpfjakiihchklfjchmkgjneajjipkmp = new _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP
                                    {
                                        _AMN = _AAH,
                                        IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM = new GUIContent(" " + text3 + " ", _ba4.GetSymbolIcon(_AAH)),
                                        MACGPHIBANLBNBMKLNGPAGIFGHDICBLPINBC = (this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Count == 0)
                                    };
                                    this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Insert(0, lcgoehpfjakiihchklfjchmkgjneajjipkmp);
                                }
                                else
                                {
                                    bool flag33 = _AAH._AT != SymbolKind.MethodGroup;
                                    if (flag33)
                                    {
                                        string text4 = _AAH.GetName();
                                        bool flag34 = text4 == ".ctor";
                                        if (flag34)
                                        {
                                            text4 = _AAH._AO.GetName();
                                        }
                                        bool flag35 = _AAH._AT == SymbolKind.Destructor;
                                        if (flag35)
                                        {
                                            text4 = "~" + _AAH._AO.GetName() + "()";
                                        }
                                        _bb3 _AAN2 = _AAH as _bb3;
                                        bool flag36 = _AAN2 != null;
                                        if (flag36)
                                        {
                                            text4 = text4 + "(" + _AAN2.PrintParameters(_AAN2.GetParameters(), true) + ")";
                                        }
                                        _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP lcgoehpfjakiihchklfjchmkgjneajjipkmp2 = new _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP
                                        {
                                            _AMN = _AAH,
                                            IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM = new GUIContent(" " + text4 + " ", _ba4.GetSymbolIcon(_AAH)),
                                            MACGPHIBANLBNBMKLNGPAGIFGHDICBLPINBC = (this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Count == 0)
                                        };
                                        _bb7 cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd = _AAH as _bb7;
                                        bool flag37 = cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd != null;
                                        if (flag37)
                                        {
                                            text4 = text4 + " this[" + cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd.PrintParameters(cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd.GetParameters(), true) + "]";
                                            _bh4 _AAH2 = new _bh4();
                                            _AAH2._AT = SymbolKind.Property;
                                            _AAH2.EFBEFFMKKMDKGGOJJGINKADLJOBNDGMEICFB(_AAH._AFH());
                                            _AAH2.NNBOMNBKBEALNJMFFCLMGKELEOOBAGIOJFPM(_AAH._AFJ());
                                            _AAH2.MNHNMADHLFHFEMIBKHINNEDLNHDLBDGCDILB(_AAH._AFI());
                                            lcgoehpfjakiihchklfjchmkgjneajjipkmp2.IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM = new GUIContent(" " + text4 + " ", _ba4.GetSymbolIcon(_AAH2));
                                        }
                                        this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Insert(0, lcgoehpfjakiihchklfjchmkgjneajjipkmp2);
                                    }
                                }
                                _AAH = _AAH._AO;
                            }
                            bool flag38 = this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP._AT == SymbolKind.Class || this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP._AT == SymbolKind.Enum || this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP._AT == SymbolKind.Interface || this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP._AT == SymbolKind.Namespace || this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP._AT == SymbolKind.Struct;
                            if (flag38)
                            {
                                this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Add(new _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP
                                {
                                    IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM = new GUIContent("...")
                                });
                            }
                        }
                    }
                    GUIStyle guistyle = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM;
                    GUIStyle guistyle2 = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF;
                    int num5 = -1;
                    int num6 = 0;
                    string text5 = "";
                    List<_bh4> list = new List<_bh4>();
                    for (int j = 0; j < this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Count; j++)
                    {
                        _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP lcgoehpfjakiihchklfjchmkgjneajjipkmp3 = this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[j];
                        bool flag39 = lcgoehpfjakiihchklfjchmkgjneajjipkmp3._AMN == null;
                        if (!flag39)
                        {
                            bool flag40 = lcgoehpfjakiihchklfjchmkgjneajjipkmp3._AMN._AT == SymbolKind.Namespace;
                            if (flag40)
                            {
                                list.Add(lcgoehpfjakiihchklfjchmkgjneajjipkmp3._AMN);
                                List<FKI> list2 = _bh6.FindDeclarations(lcgoehpfjakiihchklfjchmkgjneajjipkmp3._AMN);
                                bool flag41 = list2 == null;
                                if (flag41)
                                {
                                    num6++;
                                }
                                else
                                {
                                    foreach (FKI _AFF in lcgoehpfjakiihchklfjchmkgjneajjipkmp3._AMN._AEI)
                                    {
                                        bool flag42 = !_AFF.IsValid();
                                        if (flag42)
                                        {
                                            num6++;
                                        }
                                    }
                                    text5 = "";
                                    for (int k = 0; k < list.Count; k++)
                                    {
                                        bool flag43 = k == list.Count - 1;
                                        if (flag43)
                                        {
                                            text5 += list[k].GetName();
                                            break;
                                        }
                                        text5 = text5 + list[k].GetName() + ".";
                                    }
                                    text5 = " " + text5 + " ";
                                }
                            }
                        }
                    }
                    int l = 0;
                    while (l < this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Count)
                    {
                        bool flag44 = rect2.x >= rect.xMax;
                        if (flag44)
                        {
                            break;
                        }
                        _bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP lcgoehpfjakiihchklfjchmkgjneajjipkmp4 = this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[l];
                        GUIContent ijladedjggfcnglkjelkempgoamjiaibdenm = lcgoehpfjakiihchklfjchmkgjneajjipkmp4.IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM;
                        this.NCNKKLKOFJAKAPPFFHMDALGLDGPBKGLCNIIA.text = ijladedjggfcnglkjelkempgoamjiaibdenm.text;
                        Vector2 vector2 = guistyle.CalcSize(this.NCNKKLKOFJAKAPPFFHMDALGLDGPBKGLCNIIA);
                        vector2.x += 16f;
                        vector2.y += 16f;
                        rect2.width = vector2.x;
                        bool flag45 = l == num6;
                        if (!flag45)
                        {
                            guistyle = _bi2.CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM;
                            guistyle2 = _bi2.CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF;
                            goto IL_1047;
                        }
                        guistyle = new GUIStyle(EditorStyles.label);
                        vector2.x -= 12f;
                        rect2.width -= 12f;
                        rect2.x += 5f;
                        guistyle2 = guistyle;
                        _bh4 jjloddnfldggiplhldhkjnbhjfnbpoplkgdd = this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[l]._AMN;
                        bool flag46 = jjloddnfldggiplhldhkjnbhjfnbpoplkgdd != null && jjloddnfldggiplhldhkjnbhjfnbpoplkgdd._AT == SymbolKind.Namespace;
                        if (flag46)
                        {
                            ijladedjggfcnglkjelkempgoamjiaibdenm.text = text5;
                            goto IL_1047;
                        }
                        goto IL_10DA;
                    IL_1C3B:
                        l++;
                        continue;
                    IL_10DA:
                        EventModifiers eventModifiers = Event.current.modifiers & -113;
                        _bh4 jjloddnfldggiplhldhkjnbhjfnbpoplkgdd2 = lcgoehpfjakiihchklfjchmkgjneajjipkmp4._AMN;
                        bool flag47 = jjloddnfldggiplhldhkjnbhjfnbpoplkgdd2 != null && jjloddnfldggiplhldhkjnbhjfnbpoplkgdd2._AT == SymbolKind.Namespace && l != num6;
                        if (flag47)
                        {
                            goto IL_1C3B;
                        }
                        bool flag48 = GUI.Button(rect2, ijladedjggfcnglkjelkempgoamjiaibdenm, lcgoehpfjakiihchklfjchmkgjneajjipkmp4.MACGPHIBANLBNBMKLNGPAGIFGHDICBLPINBC ? guistyle2 : guistyle) || (l == this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA.Count - 1 && Event.current.type == 4 && eventModifiers == (flag ? 2 : 4) && Event.current.keyCode == 109);
                        if (flag48)
                        {
                            Event.current.Use();
                            _bh4 jjloddnfldggiplhldhkjnbhjfnbpoplkgdd3 = lcgoehpfjakiihchklfjchmkgjneajjipkmp4._AMN;
                            bool flag49 = !lcgoehpfjakiihchklfjchmkgjneajjipkmp4.MACGPHIBANLBNBMKLNGPAGIFGHDICBLPINBC && lcgoehpfjakiihchklfjchmkgjneajjipkmp4._AMN != null;
                            if (flag49)
                            {
                                this.GoToSymbol(jjloddnfldggiplhldhkjnbhjfnbpoplkgdd3);
                            }
                            else
                            {
                                GenericMenu genericMenu = new GenericMenu();
                                _bb4._ACW jlgembmpdbbhbaphjijihkhepgpnbojcconn = this._ABQ._AOU()._AQT()._AIT;
                                bool flag50 = l == num6;
                                if (flag50)
                                {
                                    List<FKI> list3 = new List<FKI>();
                                    _bi2.EnumScopeDeclarations(jlgembmpdbbhbaphjijihkhepgpnbojcconn, new Action<FKI>(list3.Add));
                                    list3.Sort((FKI x, FKI y) => x.Name.CompareTo(y.Name));
                                    List<string> list4 = new List<string>(list3.Count);
                                    bool flag51 = _bg8._BBA;
                                    if (flag51)
                                    {
                                        HashSet<string> hashSet = new HashSet<string>();
                                        for (int m = 0; m < list3.Count; m++)
                                        {
                                            list4.Add(null);
                                            FKI _AFF2 = list3[m];
                                            _bb4._AIN _AIO = ((_AFF2 == null) ? null : _AFF2.NameNode());
                                            bool flag52 = _AIO != null;
                                            if (flag52)
                                            {
                                                _bb4.DHBA firstLeaf = _AIO.GetFirstLeaf();
                                                bool flag53 = firstLeaf != null;
                                                if (flag53)
                                                {
                                                    string text6 = firstLeaf._ACX.AIGN.GetRegionName();
                                                    bool flag54 = !string.IsNullOrEmpty(text6);
                                                    if (flag54)
                                                    {
                                                        text6 = " " + text6;
                                                        list4[m] = text6;
                                                        hashSet.Add(text6);
                                                    }
                                                }
                                            }
                                        }
                                        int num7 = 0;
                                        foreach (string text7 in hashSet.OrderBy((string x) => x))
                                        {
                                            int num8 = list4.IndexOf(text7);
                                            FKI _AFF3 = list3[num8];
                                            list3.RemoveAt(num8);
                                            list3.Insert(num7, _AFF3);
                                            list4.RemoveAt(num8);
                                            list4.Insert(num7, text7);
                                            num7++;
                                        }
                                    }
                                    for (int n = 0; n < list3.Count; n++)
                                    {
                                        FKI decl = list3[n];
                                        string text8 = decl.Name;
                                        bool flag55 = _bg8._BBA;
                                        if (flag55)
                                        {
                                            string text9 = list4[n];
                                            bool flag56 = !string.IsNullOrEmpty(text9);
                                            if (flag56)
                                            {
                                                text8 = text9 + "/" + text8;
                                            }
                                        }
                                        bool flag57 = decl._ACV == this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[0]._AMN;
                                        switch (decl._AT)
                                        {
                                            case SymbolKind.Namespace:
                                                text8 = "Namespace " + text5;
                                                break;
                                            case SymbolKind.Interface:
                                                text8 = "Interface " + text8;
                                                break;
                                            case SymbolKind.Enum:
                                                text8 = "Enum " + text8;
                                                break;
                                            case SymbolKind.Struct:
                                                text8 = "Struct " + text8;
                                                break;
                                            case SymbolKind.Class:
                                                text8 = "Class " + text8;
                                                break;
                                            case SymbolKind.Delegate:
                                                text8 = "Delegate " + text8;
                                                break;
                                        }
                                        genericMenu.AddItem(new GUIContent(text8), flag57, delegate
                                        {
                                            this.GoToSymbolDeclaration(decl);
                                        });
                                    }
                                }
                                else
                                {
                                    _bh4.AANJKEKCHABAMPJEAMNFDPMGKHPFMLNPIMNB mdgiinhnoodfkloojkbbphjnnbonmlflmioa = this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[l - 1]._AMN._AAG;
                                    List<_bh4> list5 = new List<_bh4>(mdgiinhnoodfkloojkbbphjnnbonmlflmioa.Count);
                                    int num9 = 0;
                                    while (num9 < mdgiinhnoodfkloojkbbphjnnbonmlflmioa.Count)
                                    {
                                        _bh4 _AAH3 = mdgiinhnoodfkloojkbbphjnnbonmlflmioa._AAI(num9);
                                        bool flag58 = _AAH3._AT == SymbolKind.MethodGroup;
                                        if (flag58)
                                        {
                                            _ba7 _AAK = (_ba7)_AAH3;
                                            foreach (_bb3 _AAN3 in _AAK._AAM)
                                            {
                                                List<FKI> jdlafinmknbedpejmjahhodcpgnkklelobcd = _AAN3._AEI;
                                                bool flag59 = jdlafinmknbedpejmjahhodcpgnkklelobcd == null || jdlafinmknbedpejmjahhodcpgnkklelobcd.Count == 0;
                                                if (!flag59)
                                                {
                                                    for (int num10 = 0; num10 < jdlafinmknbedpejmjahhodcpgnkklelobcd.Count; num10++)
                                                    {
                                                        FKI _AFF4 = jdlafinmknbedpejmjahhodcpgnkklelobcd[num10];
                                                        bool flag60 = !_AFF4.IsValid() || !jlgembmpdbbhbaphjijihkhepgpnbojcconn.IsAncestorOf(_AFF4._AEJ);
                                                        if (!flag60)
                                                        {
                                                            list5.Add(_AAN3);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            List<FKI> jdlafinmknbedpejmjahhodcpgnkklelobcd2 = _AAH3._AEI;
                                            bool flag61 = jdlafinmknbedpejmjahhodcpgnkklelobcd2 == null || jdlafinmknbedpejmjahhodcpgnkklelobcd2.Count == 0;
                                            if (!flag61)
                                            {
                                                for (int num11 = 0; num11 < jdlafinmknbedpejmjahhodcpgnkklelobcd2.Count; num11++)
                                                {
                                                    FKI _AFF5 = jdlafinmknbedpejmjahhodcpgnkklelobcd2[num11];
                                                    bool flag62 = !_AFF5.IsValid() || !jlgembmpdbbhbaphjijihkhepgpnbojcconn.IsAncestorOf(_AFF5._AEJ);
                                                    if (!flag62)
                                                    {
                                                        list5.Add(_AAH3);
                                                    }
                                                }
                                            }
                                        }
                                    IL_16A4:
                                        num9++;
                                        continue;
                                        goto IL_16A4;
                                    }
                                    bool flag63 = _bg8._BAZ;
                                    if (flag63)
                                    {
                                        list5.Sort(delegate (_bh4 x, _bh4 y)
                                        {
                                            string text15 = x.GetName();
                                            string text16 = y.GetName();
                                            bool flag94 = text15 == ".ctor";
                                            if (flag94)
                                            {
                                                text15 = ((x._AO._AT == SymbolKind.MethodGroup) ? x._AO._AO.GetName() : x._AO.GetName());
                                            }
                                            else
                                            {
                                                bool flag95 = x._AT == SymbolKind.Destructor;
                                                if (flag95)
                                                {
                                                    text15 = "~" + x._AO.GetName();
                                                }
                                            }
                                            bool flag96 = text16 == ".ctor";
                                            if (flag96)
                                            {
                                                text16 = ((y._AO._AT == SymbolKind.MethodGroup) ? y._AO._AO.GetName() : y._AO.GetName());
                                            }
                                            else
                                            {
                                                bool flag97 = y._AT == SymbolKind.Destructor;
                                                if (flag97)
                                                {
                                                    text16 = "~" + y._AO.GetName();
                                                }
                                            }
                                            return text15.CompareTo(text16);
                                        });
                                    }
                                    else
                                    {
                                        list5.Sort(delegate (_bh4 x, _bh4 y)
                                        {
                                            FKI _AFF7 = x._AEI.Find((FKI d) => d.IsValid());
                                            FKI _AFF8 = y._AEI.Find((FKI d) => d.IsValid());
                                            bool flag98 = _AFF7 == null;
                                            int num18;
                                            if (flag98)
                                            {
                                                num18 = 1;
                                            }
                                            else
                                            {
                                                bool flag99 = _AFF8 == null;
                                                if (flag99)
                                                {
                                                    num18 = -1;
                                                }
                                                else
                                                {
                                                    SyntaxToken _BDJ = _AFF7._AEJ.GetFirstLeaf()._ACX;
                                                    SyntaxToken _BDJ2 = _AFF8._AEJ.GetFirstLeaf()._ACX;
                                                    int line = _BDJ.Line;
                                                    int line2 = _BDJ2.Line;
                                                    num18 = ((line != line2) ? line.CompareTo(line2) : _BDJ.TokenIndex.CompareTo(_BDJ2.TokenIndex));
                                                }
                                            }
                                            return num18;
                                        });
                                    }
                                    int num12 = 0;
                                    List<string> list6 = new List<string>(list5.Count);
                                    bool flag64 = _bg8._BBA;
                                    if (flag64)
                                    {
                                        HashSet<string> hashSet2 = new HashSet<string>();
                                        for (int num13 = 0; num13 < list5.Count; num13++)
                                        {
                                            list6.Add(null);
                                            _bh4 _AAH4 = list5[num13];
                                            FKI _AFF6 = _AAH4._AEI.FirstOrDefault<FKI>();
                                            _bb4.DHBA _AEM = ((_AFF6 == null || _AFF6._AEJ == null) ? null : _AFF6._AEJ.GetFirstLeaf());
                                            bool flag65 = _AEM != null;
                                            if (flag65)
                                            {
                                                string text10 = _AEM._ACX.AIGN.GetRegionName();
                                                bool flag66 = !string.IsNullOrEmpty(text10);
                                                if (flag66)
                                                {
                                                    text10 = " " + text10;
                                                    list6[num13] = text10;
                                                    hashSet2.Add(text10);
                                                }
                                            }
                                        }
                                        foreach (string text11 in hashSet2.OrderBy((string x) => x))
                                        {
                                            int num14 = list6.IndexOf(text11);
                                            _bh4 _AAH5 = list5[num14];
                                            list5.RemoveAt(num14);
                                            list5.Insert(num12, _AAH5);
                                            list6.RemoveAt(num14);
                                            list6.Insert(num12, text11);
                                            num12++;
                                        }
                                    }
                                    for (int num15 = 0; num15 < list5.Count; num15++)
                                    {
                                        _bh4 target = list5[num15];
                                        string text12 = target.GetName();
                                        _bb3 _AAN4 = target as _bb3;
                                        bool flag67 = text12 == ".ctor";
                                        if (flag67)
                                        {
                                            text12 = string.Concat(new string[]
                                            {
                                                "Constructor ",
                                                (target._AO._AT == SymbolKind.MethodGroup) ? target._AO._AO.GetName() : target._AO.GetName(),
                                                "(",
                                                _AAN4.PrintParameters(_AAN4.GetParameters(), true),
                                                ")"
                                            });
                                        }
                                        else
                                        {
                                            bool flag68 = target._AT == SymbolKind.Destructor;
                                            if (flag68)
                                            {
                                                text12 = "Destructor " + target._AO.GetName() + "()";
                                            }
                                            else
                                            {
                                                bool flag69 = _AAN4 != null;
                                                if (flag69)
                                                {
                                                    text12 = "Method " + text12;
                                                    bool flag70 = true;
                                                    bool isOperator2 = _AAN4.IsOperator;
                                                    if (isOperator2)
                                                    {
                                                        text12 = this.ReadableOperatorName(_AAN4, out flag70);
                                                    }
                                                    bool flag71 = flag70;
                                                    if (flag71)
                                                    {
                                                        text12 = text12 + "(" + _AAN4.PrintParameters(_AAN4.GetParameters(), true) + ")";
                                                    }
                                                }
                                            }
                                        }
                                        _bb7 cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd2 = target as _bb7;
                                        bool flag72 = cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd2 != null;
                                        if (flag72)
                                        {
                                            text12 = "Indexer this[" + cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd2.PrintParameters(cinfdnhmckaokjkkdoakfmmnfcljhlbojbmd2.GetParameters(), true) + "]";
                                        }
                                        switch (target._AT)
                                        {
                                            case SymbolKind.Namespace:
                                                text12 = "Namespace " + text5;
                                                break;
                                            case SymbolKind.Interface:
                                                text12 = "Interface " + text12;
                                                break;
                                            case SymbolKind.Enum:
                                                text12 = "Enum " + text12;
                                                break;
                                            case SymbolKind.Struct:
                                                text12 = "Struct " + text12;
                                                break;
                                            case SymbolKind.Class:
                                                text12 = "Class " + text12;
                                                break;
                                            case SymbolKind.Delegate:
                                                text12 = "Delegate " + text12;
                                                break;
                                            case SymbolKind.Field:
                                                text12 = "Field " + text12;
                                                break;
                                            case SymbolKind.ConstantField:
                                                text12 = "Constant " + text12;
                                                break;
                                            case SymbolKind.Property:
                                                text12 = "Property " + text12;
                                                break;
                                            case SymbolKind.Event:
                                                text12 = "Event " + text12;
                                                break;
                                        }
                                        text12 = _bb6.StringCheck(text12);
                                        bool flag73 = _bg8._BBA;
                                        if (flag73)
                                        {
                                            string text13 = list6[num15];
                                            bool flag74 = !string.IsNullOrEmpty(text13);
                                            if (flag74)
                                            {
                                                text12 = text13 + "/" + text12;
                                            }
                                        }
                                        bool flag75 = target == this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[l]._AMN;
                                        genericMenu.AddItem(new GUIContent(text12), flag75, delegate
                                        {
                                            this.GoToSymbol(target);
                                        });
                                    }
                                }
                                rect2.x -= (float)guistyle.overflow.left;
                                rect2.width = 1f;
                                genericMenu.DropDown(rect2);
                            }
                        }
                        rect2.x += vector2.x;
                    IL_1C2B:
                        guistyle = _bi2.HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB;
                        guistyle2 = _bi2.FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP;
                        goto IL_1C3B;
                    IL_1047:
                        bool flag76;
                        if (_bg8._BAY)
                        {
                            _bh4 jjloddnfldggiplhldhkjnbhjfnbpoplkgdd4 = this.EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA[l]._AMN;
                            flag76 = jjloddnfldggiplhldhkjnbhjfnbpoplkgdd4 != null && jjloddnfldggiplhldhkjnbhjfnbpoplkgdd4._AT == SymbolKind.Namespace;
                        }
                        else
                        {
                            flag76 = false;
                        }
                        bool flag77 = flag76;
                        if (flag77)
                        {
                            num5 = l;
                            goto IL_1C2B;
                        }
                        bool flag78 = _bg8._BAY && l - num5 == 1;
                        if (flag78)
                        {
                            guistyle = new GUIStyle(EditorStyles.label);
                            vector2.x -= 12f;
                            rect2.width -= 12f;
                            guistyle2 = guistyle;
                            goto IL_10DA;
                        }
                        goto IL_10DA;
                    }
                }
                GCE.PHFG _AUB4 = this._ABQ._AQQ[this._ABH._ABI];
                GCE._ABW _AVO = _AUB4._ABZ;
                bool flag79 = _AUB == _AUB4 && this._ABH._ABI > 0;
                if (flag79)
                {
                    int count4 = _AUB.EOIA.Count;
                    while (count4-- > 0)
                    {
                        bool flag80 = _AUB.EOIA[count4].tokenKind == SyntaxToken.Kind.Preprocessor && _AUB.EOIA[count4].text == "endregion";
                        if (flag80)
                        {
                            _AVO = this._ABQ._AQQ[this._ABH._ABI - 1]._ABZ;
                            break;
                        }
                    }
                }
                while (_AVO.OOME != null && _AVO._AT != (GCE._ABW._ABX)1 && _AVO._AT != (GCE._ABW._ABX)6)
                {
                    _AVO = _AVO.OOME;
                }
                bool flag81 = _AVO.OOME != null;
                if (flag81)
                {
                    _AUB = _AVO._ABI;
                }
                else
                {
                    _AUB = null;
                }
                GUIContent guicontent = ((_AUB != null) ? this.DGKGFJBJNCKONKKACKJDNJPLGPCKNJDIBJBL : _bi2.LLBPLBCAPNJMEDNAGOOJBIANDIBLAMGOBDLE);
                bool flag82 = _AUB != null;
                if (flag82)
                {
                    int count5 = _AUB.EOIA.Count;
                    while (count5-- > 0)
                    {
                        bool flag83 = _AUB.EOIA[count5].tokenKind == SyntaxToken.Kind.PreprocessorArguments;
                        if (flag83)
                        {
                            string text14 = _AUB.EOIA[count5].text;
                            bool flag84 = this.DGKGFJBJNCKONKKACKJDNJPLGPCKNJDIBJBL.text.Length != "#region ".Length + text14.Length || !this.DGKGFJBJNCKONKKACKJDNJPLGPCKNJDIBJBL.text.EndsWith(text14, StringComparison.Ordinal);
                            if (flag84)
                            {
                                this.DGKGFJBJNCKONKKACKJDNJPLGPCKNJDIBJBL.text = "#region " + text14;
                            }
                            break;
                        }
                    }
                }
                rect.xMax += 60f;
                rect2.x += 3f;
                rect2.xMax = rect.xMax + 1f;
                Vector2 vector3 = EditorStyles.toolbarDropDown.CalcSize(guicontent);
                bool flag85 = vector3.x < rect2.width;
                if (flag85)
                {
                    rect2.xMin = rect2.xMax - vector3.x;
                }
                bool flag86 = false;
                this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF = new List<GCE._ABW>();
                this.ListAllRegions(this._ABQ._AUY, this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF);
                bool flag87 = this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF.Count > 0;
                if (flag87)
                {
                    foreach (GCE._ABW _AVO2 in this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF)
                    {
                        bool flag88 = _AVO2._AT == (GCE._ABW._ABX)1 || _AVO2._AT == (GCE._ABW._ABX)6;
                        if (flag88)
                        {
                            flag86 = true;
                        }
                    }
                }
                bool flag89 = flag86 && GUI.Button(rect2, guicontent, EditorStyles.toolbarDropDown);
                if (flag89)
                {
                    bool flag90 = !_bg8._BCD;
                    if (flag90)
                    {
                        this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF.Sort((GCE._ABW a, GCE._ABW b) => a._ABI.JIKB.CompareTo(b._ABI.JIKB));
                    }
                    string[] array = new string[this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF.Count];
                    int count6 = this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF.Count;
                    while (count6-- > 0)
                    {
                        array[count6] = "";
                        GCE._ABW _AVO3 = this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF[count6];
                        List<SyntaxToken> _ABS3 = _AVO3._ABI.EOIA;
                        for (int num16 = 0; num16 < _ABS3.Count; num16++)
                        {
                            bool flag91 = _ABS3[num16].tokenKind == SyntaxToken.Kind.PreprocessorArguments;
                            if (flag91)
                            {
                                array[count6] = _ABS3[num16].text;
                                break;
                            }
                        }
                    }
                    GCE._ABW[] array2 = this.HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF.ToArray();
                    bool flag92 = _bg8._BCD;
                    if (flag92)
                    {
                        Array.Sort<string, GCE._ABW>(array, array2);
                    }
                    GenericMenu genericMenu2 = new GenericMenu();
                    for (int num17 = 0; num17 < array.Length; num17++)
                    {
                        genericMenu2.AddItem(new GUIContent(array[num17]), _AUB != null && array2[num17] == _AUB._ABZ, delegate (object x)
                        {
                            this.GoToRegion((GCE._ABW)x);
                        }, array2[num17]);
                    }
                    bool flag93 = array.Length != 0;
                    if (flag93)
                    {
                        genericMenu2.AddSeparator("");
                        genericMenu2.AddItem(new GUIContent("Sort by name"), _bg8._BCD, delegate
                        {
                            _bg8._BCD.Toggle();
                        });
                    }
                    else
                    {
                        genericMenu2.AddDisabledItem(new GUIContent("No regions"));
                    }
                    genericMenu2.DropDown(rect2);
                }
                GUI.enabled = enabled;
                num = 21f;
            }
            return num;
        }

        // Token: 0x06000277 RID: 631 RVA: 0x00023C2C File Offset: 0x00021E2C
        private void Autocomplete(bool suggestionsOnly)
        {
            bool flag = this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL || !this._ABQ._ASC;
            if (!flag)
            {
                bool flag2 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO == null;
                if (flag2)
                {
                    Rect caretRect = this.GetCaretRect(this._ABH);
                    caretRect.x += 4f + this._AFO.x - this._AFS.x;
                    caretRect.y += 4f + this._AFO.y - this._AFS.y;
                    this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO = _ba4.Create(this, caretRect, this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null && !this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.OLLEJPDNBBODLEICOBPMPIPPIJBOBOOHEKFP());
                    bool flag3 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO == null;
                    if (!flag3)
                    {
                        this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.UpdateTypedInPart();
                        bool flag4 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                        if (flag4)
                        {
                            this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB._AEW(!this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.OLLEJPDNBBODLEICOBPMPIPPIJBOBOOHEKFP());
                        }
                        HashSet<_bh4> hashSet = new HashSet<_bh4>();
                        _ba4._AFC = false;
                        bool flag5 = false;
                        bool flag6 = false;
                        SyntaxToken syntaxToken = _ba4._AET;
                        bool flag7 = syntaxToken != null;
                        if (flag7)
                        {
                            _bb4.DHBA _AEM = syntaxToken.OOME;
                            bool flag8 = _AEM != null && _AEM.OOME == null;
                            if (flag8)
                            {
                                int num = _AEM.line;
                                int num2 = _AEM._AJG();
                                while (_AEM != null && _AEM.OOME == null)
                                {
                                    SyntaxToken tokenLeftOf = this._ABQ.GetTokenLeftOf(ref num, ref num2);
                                    bool flag9 = tokenLeftOf == null;
                                    if (flag9)
                                    {
                                        break;
                                    }
                                    _AEM = tokenLeftOf.OOME;
                                }
                                bool flag10 = _AEM != null;
                                if (flag10)
                                {
                                    bool flag11 = syntaxToken.text == "," && _AEM._AAB() != null && _AEM._AAB() is _b2;
                                    if (flag11)
                                    {
                                        flag5 = true;
                                    }
                                    syntaxToken = _AEM._ACX;
                                }
                            }
                        }
                        bool flag12 = syntaxToken != null && (syntaxToken.OOME == null || syntaxToken.OOME._AJD == null);
                        if (!flag12)
                        {
                            _bh2._AJH _BDV = this._ABK()._AOU().MoveAfterLeaf((syntaxToken != null) ? syntaxToken.OOME : null);
                            _bb4._ACW _AGZ = ((_BDV != null) ? _BDV._AJT : null);
                            _bm2 oajkkabajliogpdkoahpmclnkpppodpdfgmj = _bm2._AGM();
                            _bh2._AGI _BEC = new _bh2._AGI();
                            bool flag13 = _BDV != null;
                            if (flag13)
                            {
                                _BDV.CollectCompletions(_BEC);
                                _BDV.Delete();
                                bool flag14 = this.JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL && _BEC.Matches(oajkkabajliogpdkoahpmclnkpppodpdfgmj.KAHJDLLICNDGMPOOEJNMMBBFFBAMEFDPHNAD);
                                if (flag14)
                                {
                                    this.CloseAutocomplete();
                                    return;
                                }
                            }
                            int hbppbagcfpcgcnfakinahhhifamjkfgmkimc = oajkkabajliogpdkoahpmclnkpppodpdfgmj.HBPPBAGCFPCGCNFAKINAHHHIFAMJKFGMKIMC;
                            bool flag15 = suggestionsOnly && !_BEC.Matches(hbppbagcfpcgcnfakinahhhifamjkfgmkimc) && (syntaxToken == null || syntaxToken.text != "override");
                            if (flag15)
                            {
                                this.CloseAutocomplete();
                                return;
                            }
                            _BEC.Remove(oajkkabajliogpdkoahpmclnkpppodpdfgmj.GHLHPHLFDEMBHDBMGMEBAMMKDPPKIHIMODCN);
                            bool flag16 = _BEC.Remove(oajkkabajliogpdkoahpmclnkpppodpdfgmj.EFJDEBNLGANKFFGCHEOIJMBIMGFKDMLLBDAB);
                            if (flag16)
                            {
                                bool flag17 = !this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADK();
                                if (flag17)
                                {
                                    hashSet.Add(new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK("null"));
                                }
                            }
                            _bb4._ACW _AGZ2 = _bm2.EnclosingScopeNode(_AGZ);
                            _bm6 _AQI = ((_AGZ2 != null) ? _AGZ2._AJW : null);
                            _bh2._BCX getParser = oajkkabajliogpdkoahpmclnkpppodpdfgmj.GetParser;
                            int ijfpnidkifchjmbgdkgmfeacoeckeoeobhbm = oajkkabajliogpdkoahpmclnkpppodpdfgmj.IJFPNIDKIFCHJMBGDKGMFEACOECKEOEOBHBM;
                            int ihmbkpmcamjflmleaacbohgclgbcodfocafl = oajkkabajliogpdkoahpmclnkpppodpdfgmj.IHMBKPMCAMJFLMLEAACBOHGCLGBCODFOCAFL;
                            BitArray bitArray;
                            int dataSet = _BEC.GetDataSet(out bitArray);
                            bool flag18 = flag5 || this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADK();
                            bool flag19 = false;
                            bool flag20 = false;
                            _b2 _AAC = null;
                            bool flag21 = dataSet != -1;
                            if (flag21)
                            {
                                bool flag22 = dataSet == ijfpnidkifchjmbgdkgmfeacoeckeoeobhbm;
                                if (flag22)
                                {
                                    flag18 = true;
                                }
                                else
                                {
                                    bool flag23 = dataSet == ihmbkpmcamjflmleaacbohgclgbcodfocafl;
                                    if (flag23)
                                    {
                                        flag20 = true;
                                    }
                                    else
                                    {
                                        bool flag24 = !this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADK();
                                        if (flag24)
                                        {
                                            string token = getParser.GetToken(dataSet);
                                            bool flag25 = token[0] == '_' || char.IsLetterOrDigit(token[0]);
                                            if (flag25)
                                            {
                                                hashSet.Add(new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(token));
                                                flag19 = true;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bool flag26 = bitArray != null;
                                if (flag26)
                                {
                                    for (int i = 0; i < bitArray.Length; i++)
                                    {
                                        bool flag27 = bitArray[i];
                                        if (flag27)
                                        {
                                            bool flag28 = i == hbppbagcfpcgcnfakinahhhifamjkfgmkimc;
                                            if (flag28)
                                            {
                                                int num3 = -1;
                                                _bb4._AIN _AIO = null;
                                                bool flag29 = _AGZ != null && _AGZ._AHB() == "primaryExpression" && syntaxToken != null && (syntaxToken.text == "new" || syntaxToken.text == "case");
                                                if (flag29)
                                                {
                                                    _AGZ = _AGZ.OOME;
                                                    while (_AGZ != null && _AGZ._AIL == 0)
                                                    {
                                                        _AGZ = _AGZ.OOME;
                                                    }
                                                    bool flag30 = _AGZ != null && _AGZ._AHB() == "expression";
                                                    if (flag30)
                                                    {
                                                        _AGZ = _AGZ.OOME;
                                                    }
                                                }
                                                while (_AGZ != null && _AGZ._AHB() == "unaryExpression")
                                                {
                                                    _AGZ = _AGZ.OOME;
                                                }
                                                bool flag31 = _AGZ != null;
                                                if (flag31)
                                                {
                                                    string text = _AGZ._AHB();
                                                    string text2 = text;
                                                    uint num4 = Helper.ComputeStringHash(text2);
                                                    if (num4 <= 2095926690U)
                                                    {
                                                        if (num4 <= 415448089U)
                                                        {
                                                            if (num4 <= 367351068U)
                                                            {
                                                                if (num4 != 123527744U)
                                                                {
                                                                    if (num4 != 179780080U)
                                                                    {
                                                                        if (num4 == 367351068U)
                                                                        {
                                                                            if (text2 == "fixedParameter")
                                                                            {
                                                                                _AIO = _AGZ.FindChildByName("type") as _bb4._ACW;
                                                                            }
                                                                        }
                                                                    }
                                                                    else if (text2 == "assignment")
                                                                    {
                                                                        goto IL_09A4;
                                                                    }
                                                                }
                                                                else if (text2 == "eventDeclarator")
                                                                {
                                                                    goto IL_09A4;
                                                                }
                                                            }
                                                            else if (num4 != 402333753U)
                                                            {
                                                                if (num4 != 405554134U)
                                                                {
                                                                    if (num4 == 415448089U)
                                                                    {
                                                                        if (text2 == "defaultArgument")
                                                                        {
                                                                            _AIO = _AGZ.OOME.ChildAt(0);
                                                                        }
                                                                    }
                                                                }
                                                                else if (text2 == "relationalExpression")
                                                                {
                                                                    goto IL_09A4;
                                                                }
                                                            }
                                                            else if (text2 == "switchLabel")
                                                            {
                                                                _AIO = _AGZ.OOME.OOME.OOME.NodeAt(2);
                                                            }
                                                        }
                                                        else if (num4 <= 708299687U)
                                                        {
                                                            if (num4 != 670883971U)
                                                            {
                                                                if (num4 != 693225631U)
                                                                {
                                                                    if (num4 == 708299687U)
                                                                    {
                                                                        if (text2 == "equalityExpression")
                                                                        {
                                                                            goto IL_09A4;
                                                                        }
                                                                    }
                                                                }
                                                                else if (text2 == "arguments")
                                                                {
                                                                    _AIO = _AGZ;
                                                                    num3 = 0;
                                                                }
                                                            }
                                                            else if (text2 == "variableInitializerList")
                                                            {
                                                                _bb4._ACW _AMI = _AGZ.OOME.OOME;
                                                                bool flag32 = _AMI._AHB() == "arrayCreationExpression";
                                                                if (flag32)
                                                                {
                                                                    _AIO = _AMI.OOME.NodeAt(1);
                                                                }
                                                                else
                                                                {
                                                                    _AIO = null;
                                                                }
                                                            }
                                                        }
                                                        else if (num4 <= 1767627332U)
                                                        {
                                                            if (num4 != 727204632U)
                                                            {
                                                                if (num4 == 1767627332U)
                                                                {
                                                                    if (text2 == "andExpression")
                                                                    {
                                                                        goto IL_09A4;
                                                                    }
                                                                }
                                                            }
                                                            else if (text2 == "exclusiveOrExpression")
                                                            {
                                                                goto IL_09A4;
                                                            }
                                                        }
                                                        else if (num4 != 1974876933U)
                                                        {
                                                            if (num4 == 2095926690U)
                                                            {
                                                                if (text2 == "argumentList")
                                                                {
                                                                    _AIO = _AGZ.OOME;
                                                                    num3 = this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG;
                                                                }
                                                            }
                                                        }
                                                        else if (text2 == "multiplicativeExpression")
                                                        {
                                                            goto IL_09A4;
                                                        }
                                                    }
                                                    else if (num4 <= 2909293537U)
                                                    {
                                                        if (num4 <= 2441638925U)
                                                        {
                                                            if (num4 != 2150376270U)
                                                            {
                                                                if (num4 != 2389855086U)
                                                                {
                                                                    if (num4 == 2441638925U)
                                                                    {
                                                                        if (!(text2 == "objectOrCollectionInitializer"))
                                                                        {
                                                                        }
                                                                    }
                                                                }
                                                                else if (text2 == "variableDeclarator")
                                                                {
                                                                    goto IL_09A4;
                                                                }
                                                            }
                                                            else if (text2 == "constantDeclarator")
                                                            {
                                                                _AIO = _AGZ.OOME.OOME.NodeAt(1);
                                                            }
                                                        }
                                                        else if (num4 != 2489527780U)
                                                        {
                                                            if (num4 != 2526016404U)
                                                            {
                                                                if (num4 == 2909293537U)
                                                                {
                                                                    if (text2 == "memberInitializer")
                                                                    {
                                                                        _AIO = _AGZ.ChildAt(0);
                                                                    }
                                                                }
                                                            }
                                                            else if (text2 == "throwStatement")
                                                            {
                                                                _AAC = _bh4.PALGJHLFMADEDCFPKIHLMGPEBCNEJGINDGBD;
                                                            }
                                                        }
                                                        else if (text2 == "localVariableInitializer")
                                                        {
                                                            _AIO = _AGZ.OOME.OOME.OOME.NodeAt(0);
                                                        }
                                                    }
                                                    else if (num4 <= 3543203919U)
                                                    {
                                                        if (num4 != 3015329114U)
                                                        {
                                                            if (num4 != 3425203650U)
                                                            {
                                                                if (num4 == 3543203919U)
                                                                {
                                                                    if (text2 == "localVariableDeclarator")
                                                                    {
                                                                        goto IL_09A4;
                                                                    }
                                                                }
                                                            }
                                                            else if (!(text2 == "statementList"))
                                                            {
                                                            }
                                                        }
                                                        else if (text2 == "inclusiveOrExpression")
                                                        {
                                                            goto IL_09A4;
                                                        }
                                                    }
                                                    else if (num4 <= 3920802870U)
                                                    {
                                                        if (num4 != 3894489210U)
                                                        {
                                                            if (num4 == 3920802870U)
                                                            {
                                                                if (text2 == "argument")
                                                                {
                                                                    _AIO = _AGZ.OOME.OOME;
                                                                    num3 = this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG;
                                                                }
                                                            }
                                                        }
                                                        else if (text2 == "arrayInitializer")
                                                        {
                                                            _AIO = _AGZ.OOME.FindPreviousNode();
                                                        }
                                                    }
                                                    else if (num4 != 3963074971U)
                                                    {
                                                        if (num4 == 4220349718U)
                                                        {
                                                            if (!(text2 == "statement"))
                                                            {
                                                            }
                                                        }
                                                    }
                                                    else if (text2 == "variableInitializer")
                                                    {
                                                        _AIO = _AGZ.OOME.LeafAt(0);
                                                    }
                                                    goto IL_0AC4;
                                                IL_09A4:
                                                    _AIO = _AGZ.ChildAt(0);
                                                }
                                            IL_0AC4:
                                                bool flag33 = _AIO != null && _AQI != null;
                                                if (flag33)
                                                {
                                                    _bh4 _AAH = _bc9.GetResolvedSymbol(_AIO);
                                                    bool flag34 = _AAH != null && _AAH._AT != SymbolKind.Error;
                                                    if (flag34)
                                                    {
                                                        bool flag35 = num3 < 0;
                                                        if (flag35)
                                                        {
                                                            _AAC = _AAH.TypeOf() as _b2;
                                                        }
                                                        else
                                                        {
                                                            _bi5 _AAE = null;
                                                            bool flag36 = _AAH._AT == SymbolKind.MethodGroup;
                                                            if (flag36)
                                                            {
                                                                _ba7 _AAK = _AAH as _ba7;
                                                                _bm7 _BFS = _AAH as _bm7;
                                                                _AAE = _AAH._AO as _bi5;
                                                                bool flag37 = _AAK == null && _BFS != null;
                                                                if (flag37)
                                                                {
                                                                    _AAK = _BFS.MAPALBBIIIJIGCOOHOOIFPIBFPLDBDGNCBOI() as _ba7;
                                                                }
                                                                bool flag38 = _AAK != null;
                                                                if (flag38)
                                                                {
                                                                    foreach (_bb3 _AAN in _AAK._AAM)
                                                                    {
                                                                        List<_bm1> parameters = _AAN.GetParameters();
                                                                        bool flag39 = parameters != null && num3 < parameters.Count;
                                                                        if (flag39)
                                                                        {
                                                                            _AAH = _AAN;
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            bool flag40 = _AAH._AT == SymbolKind.Method;
                                                            if (flag40)
                                                            {
                                                                bool isExtensionMethod = _AAH.IsExtensionMethod;
                                                                if (isExtensionMethod)
                                                                {
                                                                    num3++;
                                                                }
                                                                List<_bm1> parameters2 = _AAH.GetParameters();
                                                                bool flag41 = num3 < parameters2.Count;
                                                                if (flag41)
                                                                {
                                                                    _AAC = parameters2[num3].TypeOf() as _b2;
                                                                }
                                                                bool flag42 = _AAC != null && _AAE != null;
                                                                if (flag42)
                                                                {
                                                                    _AAC = _AAC.SubstituteTypeParameters(_AAE);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                bool flag43 = i == ijfpnidkifchjmbgdkgmfeacoeckeoeobhbm;
                                                if (flag43)
                                                {
                                                    flag18 = true;
                                                }
                                                else
                                                {
                                                    bool flag44 = i == ihmbkpmcamjflmleaacbohgclgbcodfocafl;
                                                    if (flag44)
                                                    {
                                                        flag20 = true;
                                                    }
                                                    else
                                                    {
                                                        bool flag45 = !this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADK();
                                                        if (flag45)
                                                        {
                                                            string token2 = getParser.GetToken(i);
                                                            bool flag46 = token2[0] == '_' || char.IsLetterOrDigit(token2[0]);
                                                            if (flag46)
                                                            {
                                                                hashSet.Add(new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(token2));
                                                                flag19 = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bool flag47 = !this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADK();
                                    if (flag47)
                                    {
                                        foreach (string text3 in this._ABQ._AOU().Keywords)
                                        {
                                            hashSet.Add(new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(text3));
                                        }
                                        foreach (string text4 in this._ABQ._AOU().BuiltInLiterals)
                                        {
                                            hashSet.Add(new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(text4));
                                        }
                                        flag18 = true;
                                        flag19 = true;
                                    }
                                }
                            }
                            bool flag48 = flag18 && syntaxToken != null;
                            if (flag48)
                            {
                                _bb4._AIN _AIO2 = syntaxToken.OOME;
                                bool flag49 = _AIO2.IsLit("}");
                                if (flag49)
                                {
                                    _AIO2 = _AIO2.FindNextLeaf();
                                }
                                else
                                {
                                    bool flag50 = _AIO2.IsLit("=>");
                                    if (flag50)
                                    {
                                        _AIO2 = _AIO2.OOME.NodeAt((int)(_AIO2._AIL + 1)) ?? _AIO2;
                                    }
                                    else
                                    {
                                        bool flag51 = _AIO2.IsLit("]") && _AIO2.OOME._AHB() == "attributes";
                                        if (flag51)
                                        {
                                            _AIO2 = _AIO2.OOME.OOME.NodeAt((int)(_AIO2.OOME._AIL + 1));
                                        }
                                    }
                                }
                                _bf4 igbagdlmmpchfdhmhnbcifpkofpfgdokblkb = oajkkabajliogpdkoahpmclnkpppodpdfgmj.GetCompletionTypes(_AIO2);
                                bool flag52 = flag20;
                                if (flag52)
                                {
                                    bool flag53 = !flag19;
                                    if (flag53)
                                    {
                                        igbagdlmmpchfdhmhnbcifpkofpfgdokblkb = (_bf4)8192;
                                    }
                                    else
                                    {
                                        igbagdlmmpchfdhmhnbcifpkofpfgdokblkb |= (_bf4)8192;
                                    }
                                }
                                _bc9.GetCompletions(igbagdlmmpchfdhmhnbcifpkofpfgdokblkb, _AIO2, hashSet, this._ABQ._ARQ());
                                hashSet.RemoveWhere((_bh4 x) => !x.IsValid() || x._AW == "" || x._AW[0] == '<' || x._AW[0] == '.');
                                _ba4._AFC = (igbagdlmmpchfdhmhnbcifpkofpfgdokblkb & (_bf4)256) > (_bf4)0;
                                bool khgnnjeplkfpgofgnkcaafnpllncgbaafogp = _ba4._AFC;
                                if (khgnnjeplkfpgofgnkcaafnpllncgbaafogp)
                                {
                                    this.FilterCompletions(hashSet);
                                }
                                _bh4 _AAH2 = null;
                                bool flag54 = _AAC != null;
                                if (flag54)
                                {
                                    bool flag55 = _AAC._AT == SymbolKind.Delegate;
                                    if (flag55)
                                    {
                                        bool jhonfkmhpkclklhkmoebehpgnbladgbbehil = this.JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL;
                                        if (jhonfkmhpkclklhkmoebehpgnbladgbbehil)
                                        {
                                            flag6 = true;
                                        }
                                    }
                                    else
                                    {
                                        bool flag56 = _AAC._AT == SymbolKind.Enum;
                                        if (flag56)
                                        {
                                            bool flag57 = !hashSet.Contains(_AAC);
                                            if (flag57)
                                            {
                                                string text5 = _AAC.RelativeName(_AQI);
                                                _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK oipmphoikplmammolnhcfkpgjkpldokecmak = new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(text5);
                                                oipmphoikplmammolnhcfkpgjkpldokecmak._AT = SymbolKind.Enum;
                                                hashSet.Add(oipmphoikplmammolnhcfkpgjkpldokecmak);
                                                _AAH2 = _AAH2 ?? oipmphoikplmammolnhcfkpgjkpldokecmak;
                                            }
                                            else
                                            {
                                                _AAH2 = _AAH2 ?? _AAC;
                                            }
                                        }
                                        else
                                        {
                                            bool flag58 = syntaxToken != null && syntaxToken.text == "new";
                                            if (flag58)
                                            {
                                                foreach (_b2 _AAC2 in _AQI.GetAssembly().EnumAssignableTypesFor(_AAC))
                                                {
                                                    bool flag59 = _AAC2._AT == SymbolKind.Enum || _AAC2._AT == SymbolKind.Delegate || _AAC2._AT == SymbolKind.Interface || _AAC2.IsStatic || _AAC2._AAP();
                                                    if (!flag59)
                                                    {
                                                        bool flag60 = hashSet.Contains(_AAC2);
                                                        if (flag60)
                                                        {
                                                            _AAH2 = _AAH2 ?? _AAC2;
                                                        }
                                                        else
                                                        {
                                                            string text6 = _AAC.RelativeName(_AQI);
                                                            _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK oipmphoikplmammolnhcfkpgjkpldokecmak2 = new _bi2.OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(text6);
                                                            oipmphoikplmammolnhcfkpgjkpldokecmak2._AT = SymbolKind.Enum;
                                                            hashSet.Add(oipmphoikplmammolnhcfkpgjkpldokecmak2);
                                                            _AAH2 = _AAH2 ?? oipmphoikplmammolnhcfkpgjkpldokecmak2;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    bool flag61 = _AAH2 != null;
                                    if (flag61)
                                    {
                                        _ba4.SetTopSuggestion(_AAH2);
                                    }
                                }
                                bool flag62 = suggestionsOnly && _AAH2 == null && (syntaxToken == null || syntaxToken.text != "override");
                                if (flag62)
                                {
                                    this.CloseAutocomplete();
                                    return;
                                }
                            }
                            else
                            {
                                bool flag63 = flag20 && syntaxToken != null;
                                if (flag63)
                                {
                                    _bc9.GetCompletions((_bf4)8192, syntaxToken.OOME, hashSet, this._ABQ._ARQ());
                                }
                            }
                            bool flag64 = flag19;
                            if (flag64)
                            {
                                bool flag65 = suggestionsOnly && syntaxToken != null && syntaxToken.text == "override";
                                if (flag65)
                                {
                                    hashSet.Clear();
                                }
                                try
                                {
                                    foreach (_be5 gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl in _ba6.EnumSnippets(this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP, _BEC, syntaxToken, _AQI))
                                    {
                                        hashSet.Add(gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                }
                            }
                        }
                        bool flag66 = hashSet.Count > 0;
                        if (flag66)
                        {
                            bool flag67 = flag6;
                            if (flag67)
                            {
                                this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADZ = true;
                            }
                            bool flag68 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.SetCompletionData(hashSet);
                            bool flag69 = !flag68;
                            if (flag69)
                            {
                                this.CloseAutocomplete();
                            }
                        }
                        else
                        {
                            this.CloseAutocomplete();
                        }
                    }
                }
            }
        }

        // Token: 0x06000278 RID: 632 RVA: 0x00024E74 File Offset: 0x00023074
        internal static bool EditorVersionValid(int minVersionNum = 20194)
        {
            string text = Application.unityVersion;
            Regex regex = new Regex("[a-z]*");
            MatchCollection matchCollection = regex.Matches(text);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                bool flag = matchCollection[i].Value != string.Empty;
                if (flag)
                {
                    text = text.Replace(matchCollection[i].Value, "");
                }
            }
            text = text.Replace(".", "").Substring(0, 5);
            int num = int.Parse(text);
            return num >= minVersionNum;
        }

        // Token: 0x06000279 RID: 633 RVA: 0x00024F28 File Offset: 0x00023128
        internal static void AddTheme(Theme t, string name)
        {
            bool flag = _bi2.BGBI.Contains(name);
            if (!flag)
            {
                _bi2.BPDG.Add(t);
                _bi2.BGBI.Add(name);
            }
        }

        // Token: 0x0600027A RID: 634 RVA: 0x00024F60 File Offset: 0x00023160
        internal static void RemoveTheme()
        {
            List<Theme> list = new List<Theme>();
            List<string> list2 = new List<string>();
            int num = _bi2.BGBI.Count - _bi2.CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO;
            bool flag = _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN().Count == 0;
            if (flag)
            {
                for (int i = 0; i < num; i++)
                {
                    _bi2.BPDG.Remove(_bi2.BPDG[_bi2.CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO]);
                    _bi2.BGBI.Remove(_bi2.BGBI[_bi2.CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO]);
                }
            }
            else
            {
                foreach (ThemeTemplate themeTemplate in _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN())
                {
                    list.Add(themeTemplate.colorTheme);
                    list2.Add(themeTemplate.name);
                }
                int j = 0;
                int num2 = 0;
                while (j < num)
                {
                    bool flag2 = !list2.Contains(_bi2.BGBI[_bi2.CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO + j + num2]);
                    if (flag2)
                    {
                        _bi2.BGBI.Remove(_bi2.BGBI[_bi2.CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO + j + num2]);
                        _bi2.BPDG.Remove(_bi2.BPDG[_bi2.CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO + j + num2]);
                        num2--;
                    }
                    j++;
                }
                _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN().RemoveAll((ThemeTemplate obj) => obj == null);
            }
        }

        // Token: 0x0600027B RID: 635 RVA: 0x00025100 File Offset: 0x00023300
        private bool TryEdit()
        {
            bool flag = this.KPOKBHDGCMLBFEPIHIPEKAIPDGAAGIMNLFCD == (_bi2.PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD)0;
            bool flag3;
            if (flag)
            {
                bool flag2 = this._ABQ.TryEdit();
                this.KPOKBHDGCMLBFEPIHIPEKAIPDGAAGIMNLFCD = (flag2 ? ((_bi2.PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD)1) : ((_bi2.PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD)2));
                flag3 = flag2;
            }
            else
            {
                flag3 = this.KPOKBHDGCMLBFEPIHIPEKAIPDGAAGIMNLFCD == (_bi2.PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD)1;
            }
            return flag3;
        }

        // Token: 0x0600027C RID: 636 RVA: 0x00025148 File Offset: 0x00023348
        internal bool IsLineVisible(int lineIndex)
        {
            bool flag = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count == 0;
            bool flag2;
            if (flag)
            {
                flag2 = true;
            }
            else
            {
                bool flag3 = lineIndex >= this._ABQ.FLOg.Count;
                if (flag3)
                {
                    flag2 = false;
                }
                else
                {
                    int num = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.BinarySearch(lineIndex);
                    bool flag4 = num >= 0;
                    if (flag4)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        num = ~num;
                        bool flag5 = num == 0;
                        if (flag5)
                        {
                            flag2 = true;
                        }
                        else
                        {
                            num--;
                            flag2 = lineIndex >= this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[num] + this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num];
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x0600027D RID: 637 RVA: 0x000251E0 File Offset: 0x000233E0
        internal void HideLines(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                this.HideLine(i);
            }
        }

        // Token: 0x0600027E RID: 638 RVA: 0x00025208 File Offset: 0x00023408
        internal void HideLine(int lineIndex)
        {
            int num = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.BinarySearch(lineIndex);
            bool flag = num >= 0;
            if (!flag)
            {
                num = ~num;
                bool flag2 = num < this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count;
                if (flag2)
                {
                    bool flag3 = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[num] == lineIndex + 1;
                    if (flag3)
                    {
                        List<int> koihkopajahojbiddopapjckbhpogdgpoejp = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP;
                        int num2 = num;
                        int num3 = koihkopajahojbiddopapjckbhpogdgpoejp[num2] - 1;
                        koihkopajahojbiddopapjckbhpogdgpoejp[num2] = num3;
                        List<int> ncjpnooaenpccmamkafnbiikkpbejimjnjki = this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI;
                        num3 = num;
                        num2 = ncjpnooaenpccmamkafnbiikkpbejimjnjki[num3] + 1;
                        ncjpnooaenpccmamkafnbiikkpbejimjnjki[num3] = num2;
                        bool flag4 = num > 0 && this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[num - 1] + this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num - 1] == lineIndex;
                        if (flag4)
                        {
                            List<int> ncjpnooaenpccmamkafnbiikkpbejimjnjki2 = this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI;
                            num2 = num - 1;
                            ncjpnooaenpccmamkafnbiikkpbejimjnjki2[num2] += this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num];
                            this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.RemoveAt(num);
                            this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI.RemoveAt(num);
                        }
                        bool flag5 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null;
                        if (flag5)
                        {
                            this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Clear();
                        }
                        return;
                    }
                }
                bool flag6 = num > 0;
                if (flag6)
                {
                    bool flag7 = lineIndex < this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[num - 1] + this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num - 1];
                    if (flag7)
                    {
                        return;
                    }
                    bool flag8 = lineIndex == this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[num - 1] + this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num - 1];
                    if (flag8)
                    {
                        List<int> ncjpnooaenpccmamkafnbiikkpbejimjnjki3 = this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI;
                        int num2 = num - 1;
                        int num3 = ncjpnooaenpccmamkafnbiikkpbejimjnjki3[num2] + 1;
                        ncjpnooaenpccmamkafnbiikkpbejimjnjki3[num2] = num3;
                        bool flag9 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null;
                        if (flag9)
                        {
                            this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Clear();
                        }
                        return;
                    }
                }
                this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Insert(num, lineIndex);
                this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI.Insert(num, 1);
                bool flag10 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null;
                if (flag10)
                {
                    this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Clear();
                }
            }
        }

        // Token: 0x0600027F RID: 639 RVA: 0x00025410 File Offset: 0x00023610
        internal float GetLineOffset(int index)
        {
            bool flag = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count == 0;
            float num;
            if (flag)
            {
                num = this._AEY().y * (float)index;
            }
            else
            {
                bool flag2 = index <= 0;
                if (flag2)
                {
                    num = 0f;
                }
                else
                {
                    bool flag3 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC == null || this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count != this._ABQ.FLOg.Count;
                    if (flag3)
                    {
                        int num2 = 0;
                        int count = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count;
                        float num3 = 0f;
                        bool flag4 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null;
                        if (flag4)
                        {
                            this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Clear();
                        }
                        else
                        {
                            this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC = new List<float>(this._ABQ.FLOg.Count);
                        }
                        for (int i = 0; i < this._ABQ.FLOg.Count; i++)
                        {
                            bool flag5 = num2 < count && i == this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[num2];
                            if (flag5)
                            {
                                i += this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num2] - 1;
                                int num4 = this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI[num2++];
                                while (num4-- > 0)
                                {
                                    this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Add(num3);
                                }
                            }
                            else
                            {
                                num3 += this._AEY().y * (float)(this.GetSoftLineBreaks(i).Count + 1);
                                this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Add(num3);
                            }
                        }
                    }
                    bool flag6 = index > this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count;
                    if (flag6)
                    {
                        num = ((this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count > 0) ? this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC[this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count - 1] : 0f);
                    }
                    else
                    {
                        num = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC[index - 1];
                    }
                }
            }
            return num;
        }

        // Token: 0x06000280 RID: 640 RVA: 0x00025608 File Offset: 0x00023808
        internal int GetLineAt(float yOffset)
        {
            bool flag = (!this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count == 0) || this._ABQ.FLOg.Count <= 1;
            int num;
            if (flag)
            {
                num = Mathf.Min((int)(yOffset / this._AEY().y), this._ABQ.FLOg.Count - 1);
            }
            else
            {
                this.GetLineOffset(this._ABQ.FLOg.Count);
                int num2 = _bi2.FindFirstIndexGreaterThanOrEqualTo<float>(this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC, yOffset + 1f);
                bool flag2 = num2 >= this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count;
                if (flag2)
                {
                    num2 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count - 1;
                }
                bool flag3 = !this.IsLineVisible(num2);
                if (flag3)
                {
                    bool flag4 = num2 >= this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count - 1];
                    if (flag4)
                    {
                        num2 = this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP[this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Count - 1] - 1;
                    }
                    else
                    {
                        while (num2 < this._ABQ.FLOg.Count - 1 && !this.IsLineVisible(num2))
                        {
                            num2++;
                        }
                    }
                }
                num = num2;
            }
            return num;
        }

        // Token: 0x06000281 RID: 641 RVA: 0x00025746 File Offset: 0x00023946
        internal void FocusCodeView()
        {
            this._ATM = default(DateTime);
            this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
            this.Repaint();
        }

        // Token: 0x06000282 RID: 642 RVA: 0x00025764 File Offset: 0x00023964
        private static void InitializeFont(bool forText)
        {
            bool flag = string.IsNullOrEmpty(_bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC);
            if (flag)
            {
                _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bg8._BBT;
                bool flag2 = _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC == null;
                if (flag2)
                {
                    _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = Array.Find<string>(_bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK(), (string x) => x.Contains("SourceCodePro"));
                }
                bool flag3 = _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC == null;
                if (flag3)
                {
                    _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[0];
                }
                bool flag4 = _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC == "VeraMono";
                if (flag4)
                {
                    _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[0];
                }
            }
        }

        // Token: 0x06000283 RID: 643 RVA: 0x00025808 File Offset: 0x00023A08
        internal void OnEnable(Object targetFile)
        {
            bool flag = this._ATW() != null && this._ATW()._ABI == -1;
            if (flag)
            {
                this._ATL(null);
            }
            this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL = !(targetFile is MonoScript) && !(targetFile is Shader);
            GCE _AMX = targetFile as GCE;
            bool flag2 = _AMX != null;
            if (flag2)
            {
                this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL = _AMX._ARR;
                bool flag3 = this._ABQ == null;
                if (flag3)
                {
                    this._ABQ = _AMX;
                }
            }
            bool flag4 = this._ABQ == null;
            if (flag4)
            {
                try
                {
                    this._ABQ = GCE.GetBuffer(targetFile);
                }
                catch (Exception ex)
                {
                    string text = "Exception while trying to get buffer!!!\n";
                    Exception ex2 = ex;
                    Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
                    return;
                }
            }
            _bi2.InitializeFont(this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL);
            this._ABT = (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM : _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE);
            this._ABQ._ABT = this._ABT;
            this.Initialize();
            this._ABQ.Initialize();
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj._ASW = (GCE._AVE)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj._ASW, new GCE._AVE(this.Repaint));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj2._ASW = (GCE._AVE)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._ASW, new GCE._AVE(this.Repaint));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj3 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj3._AUZ = (GCE._AVF)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj3._AUZ, new GCE._AVF(this.OnLineFormatted));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj4 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj4._AUZ = (GCE._AVF)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj4._AUZ, new GCE._AVF(this.OnLineFormatted));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj5 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj5._AUI = (GCE._AVG)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj5._AUI, new GCE._AVG(this.OnInsertedLines));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj6 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj6._AUI = (GCE._AVG)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj6._AUI, new GCE._AVG(this.OnInsertedLines));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj7 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj7._AUM = (GCE._AVK)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj7._AUM, new GCE._AVK(this.OnRemovedLines));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj8 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj8._AUM = (GCE._AVK)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj8._AUM, new GCE._AVK(this.OnRemovedLines));
            this._ABQ.AddEditor(this);
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnUpdate));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnUpdate));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.SearchOnLoaded));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.SearchOnLoaded));
            _bi2.InitCustomThemes();
            _bi2.RemoveTheme();
            bool flag5 = _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN().Count > 0;
            if (flag5)
            {
                foreach (ThemeTemplate themeTemplate in _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN())
                {
                    _bi2.AddTheme(themeTemplate.colorTheme, themeTemplate.name);
                }
            }
            _bi2.RepaintAllThemes();
        }

        // Token: 0x06000284 RID: 644 RVA: 0x00025B78 File Offset: 0x00023D78
        private void SearchOnLoaded()
        {
            bool flag = this.CanEdit();
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.SearchOnLoaded));
                string fnablfjgddbbclnclglmabbfifelkogmeffj = _bi2.FNABLFJGDDBBCLNCLGLMABBFIFELKOGMEFFJ;
                this.SetSearchText(this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
                _bi2.FNABLFJGDDBBCLNCLGLMABBFIFELKOGMEFFJ = fnablfjgddbbclnclglmabbfifelkogmeffj;
            }
        }

        // Token: 0x06000285 RID: 645 RVA: 0x00025BCC File Offset: 0x00023DCC
        private void InvalidateSoftLineBreaks()
        {
            bool flag = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH != null;
            if (flag)
            {
                for (int i = 0; i < this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count; i++)
                {
                    this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[i] = null;
                }
            }
            bool flag2 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null;
            if (flag2)
            {
                this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Clear();
            }
        }

        // Token: 0x06000286 RID: 646 RVA: 0x00025C28 File Offset: 0x00023E28
        private void OnLineFormatted(int line)
        {
            bool flag = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH != null && line < this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count;
            if (flag)
            {
                this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[line] = null;
            }
        }

        // Token: 0x06000287 RID: 647 RVA: 0x00025C64 File Offset: 0x00023E64
        private void OnInsertedLines(int lineIndex, int numLines)
        {
            bool flag = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH != null && lineIndex <= this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count;
            if (flag)
            {
                this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.InsertRange(lineIndex, new List<int>[numLines]);
            }
            bool flag2 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null && lineIndex < this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count;
            if (flag2)
            {
                this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.RemoveRange(lineIndex, this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count - lineIndex);
            }
            bool flag3 = lineIndex < this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE;
            if (flag3)
            {
                this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = 0f;
                this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE += numLines;
            }
        }

        // Token: 0x06000288 RID: 648 RVA: 0x00025D08 File Offset: 0x00023F08
        private void OnRemovedLines(int lineIndex, int numLines)
        {
            bool flag = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH != null && lineIndex < this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count;
            if (flag)
            {
                this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.RemoveRange(lineIndex, Math.Min(numLines, this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count - lineIndex));
            }
            bool flag2 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null && lineIndex < this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count;
            if (flag2)
            {
                this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.RemoveRange(lineIndex, this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count - lineIndex);
            }
            bool flag3 = lineIndex < this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE;
            if (flag3)
            {
                this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = 0f;
                bool flag4 = lineIndex + numLines <= this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE;
                if (flag4)
                {
                    this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE -= numLines;
                }
                else
                {
                    this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = lineIndex;
                }
            }
        }

        // Token: 0x06000289 RID: 649 RVA: 0x00025DD4 File Offset: 0x00023FD4
        internal void SaveBuffer()
        {
            this.CloseAllPopups();
            bool flag = this.CanEdit();
            if (flag)
            {
                bool flag2 = this._ALW();
                if (flag2)
                {
                    bool flag3 = !this._ABQ.Save();
                    if (!flag3)
                    {
                        bool flag4 = this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL || this._ABQ._ARO;
                        if (flag4)
                        {
                            AssetDatabase.ImportAsset(this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC());
                        }
                        else
                        {
                            _bc5.AddPendingAssetImport(this._ABQ._AMZ);
                            _bg8._BBZ._AIF((bool)typeof(EditorUtility).GetMethod("IsAutoRefreshEnabled", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null));
                            bool flag5 = _bg8._BBZ && !_bg8._BBY;
                            if (flag5)
                            {
                                _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN = 1;
                                _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Clear();
                                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.HoldReloadingAssemblies));
                            }
                            bool flag6 = _bg8._BBZ;
                            if (flag6)
                            {
                                _bc5.ImportPendingAssets();
                            }
                        }
                        _bi2.RepaintAllInstances();
                    }
                }
                else
                {
                    _bi2.MenuReloadAssemblies();
                }
            }
        }

        // Token: 0x0600028A RID: 650 RVA: 0x00025F08 File Offset: 0x00024108
        [MenuItem("Window/Super Editor/Save All Modified _&%s", false, 501)]
        private static void MenuReloadAssemblies()
        {
            _bc5.SaveAllModified(false);
            bool flag = !EditorApplication.isCompiling && !_bc5._AMU();
            if (!flag)
            {
                bool flag2 = _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN > 0;
                if (flag2)
                {
                    _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN = 0;
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.HoldReloadingAssemblies));
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.ReloadAssemblies));
                    EditorApplication.UnlockReloadAssemblies();
                }
                else
                {
                    bool flag3 = !_bc5._AMU();
                    if (flag3)
                    {
                        bool flag4 = _bg8._BBZ && !_bg8._BBY;
                        if (flag4)
                        {
                            _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN = 1;
                            _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Clear();
                            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.HoldReloadingAssemblies));
                        }
                        bool flag5 = _bg8._BBZ;
                        if (flag5)
                        {
                            _bc5.ImportPendingAssets();
                        }
                    }
                }
            }
        }

        // Token: 0x0600028B RID: 651 RVA: 0x00026010 File Offset: 0x00024210
        private static void HoldReloadingAssemblies()
        {
            bool flag = EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying;
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.HoldReloadingAssemblies));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.ReloadAssemblies));
                _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN = 10;
            }
            else
            {
                bool flag2 = false;
                bool flag3 = false;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    try
                    {
                        bool flag4 = process.ProcessName == "mono";
                        if (flag4)
                        {
                            _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Add(process);
                            bool flag5 = process.ExitCode != 0;
                            if (flag5)
                            {
                                flag3 = true;
                                break;
                            }
                            flag2 = true;
                        }
                    }
                    catch
                    {
                    }
                }
                _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.RemoveWhere((Process x) => x.HasExited && x.ExitCode == 0);
                bool flag6;
                if (!flag3)
                {
                    flag6 = _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Any((Process x) => x.HasExited && x.ExitCode != 0);
                }
                else
                {
                    flag6 = true;
                }
                flag3 = flag6;
                bool flag7 = flag3;
                if (flag7)
                {
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.HoldReloadingAssemblies));
                    EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.ReloadAssemblies));
                }
                else
                {
                    bool flag8 = flag2 || _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN < 10;
                    if (flag8)
                    {
                        bool flag9 = !flag2;
                        if (flag9)
                        {
                            _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN++;
                        }
                        EditorApplication.LockReloadAssemblies();
                    }
                    else
                    {
                        bool flag10 = !flag2 && _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Count == 0;
                        if (flag10)
                        {
                            _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN = 10;
                            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.HoldReloadingAssemblies));
                            _bi2.RepaintAllInstances();
                        }
                    }
                }
            }
        }

        // Token: 0x0600028C RID: 652 RVA: 0x00026228 File Offset: 0x00024428
        private static void ReloadAssemblies()
        {
            _bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN = 0;
            _bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Clear();
            for (int i = 0; i < 10; i++)
            {
                EditorApplication.UnlockReloadAssemblies();
            }
            bool flag = !_bi2.IBJPBLKKEKFIOKLKOAHFHFNKPAEBABFIBMEN || (EditorApplication.isCompiling && !EditorApplication.isUpdating);
            if (flag)
            {
                bool flag2 = !_bi2.IBJPBLKKEKFIOKLKOAHFHFNKPAEBABFIBMEN;
                if (flag2)
                {
                    _bi2.DKJCMMDHBKEIIHAPOIPCGOGHBAKOMEGIGHPC = EditorWindow.focusedWindow;
                    _bi2.IBJPBLKKEKFIOKLKOAHFHFNKPAEBABFIBMEN = true;
                    EditorUtility.DisplayProgressBar("Code Window", "Reloading assemblies...", 0f);
                    AppDomain.CurrentDomain.DomainUnload -= _bi2.HideProgressBarOnUnload;
                    AppDomain.CurrentDomain.DomainUnload += _bi2.HideProgressBarOnUnload;
                    return;
                }
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.ReloadAssemblies));
            _bi2.IBJPBLKKEKFIOKLKOAHFHFNKPAEBABFIBMEN = false;
            EditorUtility.ClearProgressBar();
            bool flag3 = _bi2.DKJCMMDHBKEIIHAPOIPCGOGHBAKOMEGIGHPC;
            if (flag3)
            {
                _bi2.DKJCMMDHBKEIIHAPOIPCGOGHBAKOMEGIGHPC.Focus();
            }
            _bi2.DKJCMMDHBKEIIHAPOIPCGOGHBAKOMEGIGHPC = null;
            _bi2.RepaintAllInstances();
        }

        // Token: 0x0600028D RID: 653 RVA: 0x00026335 File Offset: 0x00024535
        private static void HideProgressBarOnUnload(object sender, EventArgs args)
        {
            EditorUtility.ClearProgressBar();
        }

        // Token: 0x0600028E RID: 654 RVA: 0x00026340 File Offset: 0x00024540
        private void CheckFocusDelayed()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.CheckFocusDelayed));
            bool flag = EditorWindow.focusedWindow == this._ABJ();
            if (!flag)
            {
                bool flag2 = EditorWindow.focusedWindow == this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO;
                if (!flag2)
                {
                    bool flag3 = EditorWindow.focusedWindow == this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;
                    if (flag3)
                    {
                        this.CloseAllPopups();
                        this.FocusCodeView();
                        this._ABJ().Focus();
                    }
                    else
                    {
                        Input.imeCompositionMode = 0;
                        this.CloseAllPopups();
                        this.OnReallyLostFocus();
                    }
                }
            }
        }

        // Token: 0x0600028F RID: 655 RVA: 0x000263E0 File Offset: 0x000245E0
        private void OnReallyLostFocus()
        {
            bool iagmgplnbonfccinlnnelhhbejpihbhhpgha = _bi2.IAGMGPLNBONFCCINLNNELHHBEJPIHBHHPGHA;
            if (iagmgplnbonfccinlnnelhhbejpihbhhpgha)
            {
                this.AddRecentLocation(0, true);
            }
            _bi2.IAGMGPLNBONFCCINLNNELHHBEJPIHBHHPGHA = true;
        }

        // Token: 0x06000290 RID: 656 RVA: 0x00026408 File Offset: 0x00024608
        public void OnLostFocus()
        {
            bool flag = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null || this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null || this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
            if (flag)
            {
                bool flag2 = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null;
                if (flag2)
                {
                    this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.Hide();
                    this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP = null;
                }
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(this.CheckFocusDelayed));
            }
            else
            {
                Input.imeCompositionMode = 0;
                bool flag3 = this.CanEdit();
                if (flag3)
                {
                    this.OnReallyLostFocus();
                }
            }
        }

        // Token: 0x06000291 RID: 657 RVA: 0x000264A8 File Offset: 0x000246A8
        public void OnDisable()
        {
            bool flag = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
            if (flag)
            {
                this.CloseAutocomplete();
            }
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.OnUpdate));
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(this.SearchOnLoaded));
            bool flag2 = this._ABQ != null;
            if (flag2)
            {
                this._ABQ.RemoveEditor(this);
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj._ASW = (GCE._AVE)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj._ASW, new GCE._AVE(this.Repaint));
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUZ = (GCE._AVF)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUZ, new GCE._AVF(this.OnLineFormatted));
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj3 = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj3._AUI = (GCE._AVG)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj3._AUI, new GCE._AVG(this.OnInsertedLines));
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj4 = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj4._AUM = (GCE._AVK)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj4._AUM, new GCE._AVK(this.OnRemovedLines));
            }
            bool flag3 = GCE._ALU == this;
            if (flag3)
            {
                this.AddRecentLocation(1, false);
                GCE._ALU = null;
            }
        }

        // Token: 0x06000292 RID: 658 RVA: 0x000265E8 File Offset: 0x000247E8
        private void Repaint()
        {
            bool flag = this._AGD != null;
            if (flag)
            {
                this._AGD();
            }
        }

        // Token: 0x06000293 RID: 659 RVA: 0x00026610 File Offset: 0x00024810
        static _bi2()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bi2.UpdateTime));
        }

        // Token: 0x06000294 RID: 660 RVA: 0x000267D4 File Offset: 0x000249D4
        private static void UpdateTime()
        {
            _bi2._ATN = DateTime.Now;
        }

        // Token: 0x06000295 RID: 661 RVA: 0x000267E4 File Offset: 0x000249E4
        public void OnUpdate()
        {
            bool flag = this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN != Vector2.zero || this.MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA || this.PEGFBNGNMIIMHJHBGGJMIPPGCENEDFKBJIPF || this.DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC || this.ALLEDCEJLCOEBNDPEPFIJNFCIFIDIDNEHKFJ;
            if (flag)
            {
                float num = (float)(_bi2._ATN - this.LAHBGBFFABHOMBCEKEOONHEFBNAHFPKDNLNM).TotalSeconds;
                bool flag2 = !this.MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA && !this.PEGFBNGNMIIMHJHBGGJMIPPGCENEDFKBJIPF;
                if (flag2)
                {
                    this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x = this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x * 0.9f;
                    bool flag3 = this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x != 0f;
                    if (flag3)
                    {
                        this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x = ((this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x > 0f) ? Mathf.Max(0f, this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x - 50f * num) : Mathf.Min(0f, this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x + 50f * num));
                    }
                }
                else
                {
                    this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x = Mathf.Clamp(this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.x + (this.MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA ? (-500f) : 500f) * num, -2000f, 2000f);
                }
                bool flag4 = !this.DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC && !this.ALLEDCEJLCOEBNDPEPFIJNFCIFIDIDNEHKFJ;
                if (flag4)
                {
                    this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y = this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y * 0.9f;
                    bool flag5 = this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y != 0f;
                    if (flag5)
                    {
                        this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y = ((this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y > 0f) ? Mathf.Max(0f, this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y - 50f * num) : Mathf.Min(0f, this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y + 50f * num));
                    }
                }
                else
                {
                    this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y = Mathf.Clamp(this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN.y + (this.DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC ? (-500f) : 500f) * num, -2000f, 2000f);
                }
                this.DAOLEHELIBAIPNAPOFMDOLIAOEHCLFOGLHGI = this.FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN * num;
                bool flag6 = this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA != null;
                if (flag6)
                {
                    this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI = this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL && !this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                }
                this.LAHBGBFFABHOMBCEKEOONHEFBNAHFPKDNLNM = _bi2._ATN;
                bool flag7 = EditorWindow.focusedWindow == this._ABJ();
                if (flag7)
                {
                    EditorWindow.focusedWindow.wantsMouseMove = true;
                }
                this.Repaint();
            }
            else
            {
                bool flag8 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
                if (flag8)
                {
                    this.LAHBGBFFABHOMBCEKEOONHEFBNAHFPKDNLNM = _bi2._ATN;
                    float num2 = (float)(_bi2._ATN - this._ATM).TotalSeconds % 1f;
                    bool flag9 = !this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL && this.FHJLFMFHAGFPFMJLEGINHPPNDKNNANJLLHHH != this._ATM;
                    if (flag9)
                    {
                        int num3;
                        int num4;
                        bool flag10;
                        SyntaxToken syntaxToken = this._ABQ.GetTokenAt(this._ABH, out num3, out num4, out flag10);
                        bool flag11 = syntaxToken != null;
                        if (flag11)
                        {
                            bool flag12 = flag10 && syntaxToken.tokenKind != SyntaxToken.Kind.Identifier && syntaxToken.tokenKind != SyntaxToken.Kind.Keyword && syntaxToken.tokenKind != SyntaxToken.Kind.ContextualKeyword && syntaxToken.tokenKind != SyntaxToken.Kind.PreprocessorSymbol;
                            if (flag12)
                            {
                                List<SyntaxToken> _ABS = this._ABQ._AQQ[num3].EOIA;
                                bool flag13 = num4 < _ABS.Count - 1;
                                if (flag13)
                                {
                                    syntaxToken = _ABS[num4 + 1];
                                }
                            }
                        }
                        bool flag14 = (float)(_bi2._ATN - this._ATM).TotalSeconds >= 0.35f;
                        if (flag14)
                        {
                            bool flag15 = syntaxToken != null;
                            if (flag15)
                            {
                                this.FHJLFMFHAGFPFMJLEGINHPPNDKNNANJLLHHH = this._ATM;
                                bool flag16 = syntaxToken.OOME != null && syntaxToken.OOME._AAB() != null && (syntaxToken.tokenKind == SyntaxToken.Kind.Identifier || syntaxToken.tokenKind == SyntaxToken.Kind.ContextualKeyword || syntaxToken.tokenKind == SyntaxToken.Kind.Keyword) && syntaxToken.OOME._AAB()._AT != SymbolKind.Error;
                                if (flag16)
                                {
                                    bool flag17 = this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != syntaxToken.OOME._AAB();
                                    if (flag17)
                                    {
                                        this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = syntaxToken.OOME._AAB().GetGenericSymbol();
                                        this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH = null;
                                        this.Repaint();
                                        return;
                                    }
                                }
                                else
                                {
                                    bool flag18 = syntaxToken.tokenKind == SyntaxToken.Kind.PreprocessorSymbol;
                                    if (flag18)
                                    {
                                        this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = null;
                                        this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH = syntaxToken.text;
                                        this.Repaint();
                                        return;
                                    }
                                    bool flag19 = !_bg8._BAH && (this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != null || this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH != null);
                                    if (flag19)
                                    {
                                        this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = null;
                                        this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH = null;
                                        this.Repaint();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                bool flag20 = !_bg8._BAH && (this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != null || this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH != null);
                                if (flag20)
                                {
                                    this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = null;
                                    this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH = null;
                                    this.Repaint();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            bool flag21 = !_bg8._BAH && this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != null;
                            if (flag21)
                            {
                                bool flag22 = syntaxToken == null || syntaxToken.OOME == null || syntaxToken.OOME._AAB() == null || syntaxToken.OOME._AAB()._AT == SymbolKind.Error || (syntaxToken.tokenKind != SyntaxToken.Kind.Identifier && syntaxToken.tokenKind != SyntaxToken.Kind.ContextualKeyword && syntaxToken.tokenKind != SyntaxToken.Kind.Keyword) || (this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != syntaxToken.OOME._AAB() && this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != syntaxToken.OOME._AAB().GetGenericSymbol());
                                if (flag22)
                                {
                                    this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = null;
                                    this.Repaint();
                                    return;
                                }
                            }
                            else
                            {
                                bool flag23 = !_bg8._BAH && this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH != null;
                                if (flag23)
                                {
                                    bool flag24 = syntaxToken == null || syntaxToken.tokenKind != SyntaxToken.Kind.PreprocessorSymbol;
                                    if (flag24)
                                    {
                                        this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH = null;
                                        this.Repaint();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    bool flag25 = EditorWindow.focusedWindow != null && EditorWindow.focusedWindow == this._ABJ();
                    if (flag25)
                    {
                        EditorWindow.focusedWindow.wantsMouseMove = true;
                    }
                    bool flag26 = num2 < 0.5f;
                    bool flag27 = this.PJJNCLILMNNHAGCFMAEOAHDAGGAKDOIMCAEI != flag26;
                    if (flag27)
                    {
                        this.Repaint();
                    }
                }
            }
            bool flag28 = this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM != null && this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
            if (flag28)
            {
                this.ShowArgumentsHint(this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM);
                this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = null;
            }
            else
            {
                bool flag29 = this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM != null;
                if (!flag29)
                {
                    bool flag30 = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP == null && (this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() || this.PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM);
                    if (flag30)
                    {
                        bool flag31 = this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII != null && this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC != default(DateTime) && (float)(_bi2._ATN - this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC).TotalSeconds > 0.25f;
                        if (flag31)
                        {
                            bool flag32 = this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME != null && EditorWindow.mouseOverWindow == this._ABJ();
                            if (flag32)
                            {
                                _bh4 _AAH = this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME._AAB();
                                bool flag33 = _AAH == null || !_AAH.IsValid() || _AAH._AT == SymbolKind.Error;
                                if (flag33)
                                {
                                    this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME._ACY(null);
                                    _bc9.ResolveNode(this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME.OOME);
                                }
                                bool flag34 = this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME._AAB() != null;
                                if (flag34)
                                {
                                    this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP = _bk9.Create(this, this.HMBHHLIKJCBCEFKDGKPNLHMOKOOLHJDKLBOL, this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME, false, true, false);
                                }
                                else
                                {
                                    bool flag35 = this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME._AJB != null || this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME._AJF != null;
                                    if (flag35)
                                    {
                                        this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP = _bk9.Create(this, this.HMBHHLIKJCBCEFKDGKPNLHMOKOOLHJDKLBOL, this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII.OOME, false, true, false);
                                    }
                                }
                            }
                            else
                            {
                                this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII = null;
                            }
                        }
                    }
                    else
                    {
                        bool flag36 = this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC == default(DateTime) && this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null;
                        if (flag36)
                        {
                            this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.Hide();
                        }
                    }
                }
            }
            _bi2.RepaintChangedTheme(this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL);
            _bi2.RepaintChangedTheme(!this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL);
        }

        // Token: 0x06000296 RID: 662 RVA: 0x000270EC File Offset: 0x000252EC
        internal static T LoadEditorResource<T>(string indieAndProName) where T : Object
        {
            return _bi2.LoadEditorResource<T>(indieAndProName, null);
        }

        // Token: 0x06000297 RID: 663 RVA: 0x00027108 File Offset: 0x00025308
        internal static T LoadEditorResource<T>(string indieName, string proName) where T : Object
        {
            string text = ((proName == null) ? indieName : (EditorGUIUtility.isProSkin ? proName : indieName));
            string text2 = Path.Combine(_bi2.NPOF(), text);
            return AssetDatabase.LoadMainAssetAtPath(text2) as T;
        }

        // Token: 0x06000298 RID: 664 RVA: 0x0002714C File Offset: 0x0002534C
        private static int GetDynamicFontSize(Font font)
        {
            bool flag = font == null;
            int num;
            if (flag)
            {
                num = 0;
            }
            else
            {
                TrueTypeFontImporter trueTypeFontImporter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(font)) as TrueTypeFontImporter;
                num = ((trueTypeFontImporter != null && trueTypeFontImporter.fontTextureCase == -2) ? trueTypeFontImporter.fontSize : 0);
            }
            return num;
        }

        // Token: 0x06000299 RID: 665 RVA: 0x0002719C File Offset: 0x0002539C
        public void Initialize()
        {
            Vector2 vector = ((this._ABT._ABV != null && this._ABT._ABV.font != null) ? this._ABT._ABV.CalcSize(_bi2.JKEGIJCLAEEMOEKPHALMICPOHFLNNBDPPAIK) : this._AEY());
            bool flag = this._ABQ != null && this._ABQ._ARR;
            bool flag2 = (flag ? _bi2.LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH : _bi2.PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL);
            bool flag3 = vector != this._AEY() || this._ABT._ABV == null || this._ABT._ABV.font == null || _bg8._AEP == 0 != (this._ABT._ABV.fontSize == 0) || flag2;
            if (flag3)
            {
                this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH = null;
                this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC = null;
                this.PKFNCAIDJDMDDHBBFMKAGPDLNGLMMHKHHFOD.Clear();
                bool flag4 = flag;
                if (flag4)
                {
                    _bi2.LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH = false;
                }
                else
                {
                    _bi2.PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL = false;
                }
                _bi2.LoadStyles(this._ABT, flag);
                this.HOPMPOOFCKGLAFDCFAAODFFEMMMOJHGAOJMI((this._ABT._ABV.font != null) ? this._ABT._ABV.CalcSize(_bi2.JKEGIJCLAEEMOEKPHALMICPOHFLNNBDPPAIK) : this._AEY());
            }
        }

        // Token: 0x0600029A RID: 666 RVA: 0x000272F8 File Offset: 0x000254F8
        internal static _bi2._AVA GetStyles(bool forText)
        {
            _bi2._AVA gpioonjlkbmhjkddepbfbbnpijalemmekbbm = (forText ? _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM : _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE);
            bool flag = gpioonjlkbmhjkddepbfbbnpijalemmekbbm._ABV == null;
            if (flag)
            {
                _bi2.InitializeFont(forText);
                _bi2.LoadStyles(gpioonjlkbmhjkddepbfbbnpijalemmekbbm, forText);
            }
            return gpioonjlkbmhjkddepbfbbnpijalemmekbbm;
        }

        // Token: 0x0600029B RID: 667 RVA: 0x0002733C File Offset: 0x0002553C
        internal static void LoadIcons(bool forDll = false)
        {
            _bi2.FJHJMLPMPICJDJHGPHKCHLPDABECAPHNLBDL = _a2.GetInstance().GetTexture(Base64Texture.SaveIcon);
            _bi2.IKAJMFCHNHPALEOMJJLHJFIOOABGCPIIBMMF = _a2.GetInstance().GetTexture(Base64Texture.EditUndoIcon);
            _bi2.PKNNMKEEKOEEDPPADOBGGMNPANFDLFEKELML = _a2.GetInstance().GetTexture(Base64Texture.EditRedoIcon);
            _bi2.NLKLFFEHGAOCPBJMKILBAJBPHJMHBJEKHOFA = _a2.GetInstance().GetTexture(Base64Texture.WavyUnderline);
            _bi2.PFGMEJLLJPMAPPHJDBPLAODICICMBLHNKKAB = _a2.GetInstance().GetTexture(Base64Texture.WhitePing);
        }

        // Token: 0x0600029C RID: 668 RVA: 0x000273A4 File Offset: 0x000255A4
        internal static void LoadStyles(_bi2._AVA styles = null, bool forText = false)
        {
            _bi2.LoadIcons(false);
            bool flag = styles == null;
            if (flag)
            {
                int num = _bi2.BGBI.IndexOf(EditorGUIUtility.isProSkin ? "VS Dark with VA X" : "Xcode");
                num = ((num < 0) ? 0 : num);
                _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF = _bi2.BPDG[num];
                _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN = _bi2.BPDG[num];
                _bi2.LoadStyles(_bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM, true);
                _bi2.LoadStyles(_bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE, false);
                _bi2.SelectTheme(num, true);
                _bi2.SelectTheme(num, false);
                EditorPrefs.DeleteKey("Vik.SuperEditor.ThemeNameCode");
                EditorPrefs.DeleteKey("Vik.SuperEditor.ThemeNameText");
                for (int i = 0; i < _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK().Length; i++)
                {
                    bool flag2 = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[i].Equals("Fonts/PTMono.ttc");
                    if (flag2)
                    {
                        _bg8._BBT._AIF(_bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[i]);
                        break;
                    }
                    _bg8._BBT._AIF(_bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[0]);
                }
            }
            else
            {
                int num2 = _bi2.BGBI.IndexOf(forText ? _bg8._BBX : _bg8._BBW);
                num2 = ((num2 < 0) ? 0 : num2);
                if (forText)
                {
                    _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF = _bi2.BPDG[num2];
                }
                else
                {
                    _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN = _bi2.BPDG[num2];
                }
                styles.MNAINPPJCJGPLHBFJICPBAPKHGGPKHFKGHKI = styles.MNAINPPJCJGPLHBFJICPBAPKHGGPKHFKGHKI ?? new GUIStyle(GUIStyle.none);
                styles.EEHEIDPKDPFECCNEMEAOEDHDMOCMLHIMGBIO = styles.EEHEIDPKDPFECCNEMEAOEDHDMOCMLHIMGBIO ?? new GUIStyle(GUIStyle.none);
                styles._ABV = styles._ABV ?? new GUIStyle(GUIStyle.none);
                styles._ABV.richText = false;
                string text = _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC;
                bool flag3 = text != null;
                if (flag3)
                {
                    styles._ABV.font = _bi2.LoadEditorResource<Font>(text);
                    int num3 = 0;
                    while (styles._ABV.font == null && num3 < _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK().Length)
                    {
                        _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[num3];
                        text = _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC;
                        styles._ABV.font = _bi2.LoadEditorResource<Font>(text);
                        num3++;
                    }
                    _bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = null;
                }
                int dynamicFontSize = _bi2.GetDynamicFontSize(styles._ABV.font);
                bool flag4 = dynamicFontSize != 0;
                bool flag5 = _bg8._AEP != 0;
                if (flag5)
                {
                    styles._ABV.fontSize = dynamicFontSize + _bg8._AEP;
                }
                else
                {
                    styles._ABV.fontSize = 0;
                }
                styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK = styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK ?? new GUIStyle(styles._ABV);
                styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE = styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE ?? new GUIStyle(styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK);
                styles._ACK = styles._ACK ?? new GUIStyle(styles._ABV);
                styles._ACF = styles._ACF ?? new GUIStyle(styles._ABV);
                styles._ACE = styles._ACE ?? new GUIStyle(styles._ABV);
                styles._ACL = styles._ACL ?? new GUIStyle(styles._ACK);
                styles._ACG = styles._ACG ?? new GUIStyle(styles._ABV);
                styles._ACH = styles._ACH ?? new GUIStyle(styles._ABV);
                styles._ACN = styles._ACN ?? new GUIStyle(styles._ABV);
                styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB = styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB ?? new GUIStyle(styles._ABV);
                styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD = styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD ?? new GUIStyle(styles._ABV);
                styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL = styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL ?? new GUIStyle(styles._ABV);
                styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC = styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC ?? new GUIStyle(styles._ABV);
                styles._ACI = styles._ACI ?? new GUIStyle(styles._ABV);
                styles._ACJ = styles._ACJ ?? new GUIStyle(styles._ABV);
                styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM = styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM ?? new GUIStyle(styles._ABV);
                styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP = styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP ?? new GUIStyle(styles._ABV);
                styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE = styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE ?? new GUIStyle(styles._ABV);
                styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK = styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK ?? new GUIStyle(styles._ABV);
                styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI = styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI ?? new GUIStyle(styles._ABV);
                styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG = styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG ?? new GUIStyle(styles._ABV);
                styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP = styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP ?? new GUIStyle(styles._ABV);
                styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD = styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD ?? new GUIStyle(styles._ABV);
                styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI = styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI ?? new GUIStyle(styles._ABV);
                styles._ACC = styles._ACC ?? new GUIStyle(styles._ABV);
                styles._ACD = styles._ACD ?? new GUIStyle(styles._ABV);
                styles._ACA = styles._ACA ?? new GUIStyle(styles._ABV);
                styles._ACB = styles._ACB ?? new GUIStyle(styles._ABV);
                styles.BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI = styles.BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI ?? new GUIStyle(styles._ABV);
                styles.AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI = styles.AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI ?? new GUIStyle(styles._ABV);
                styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM = styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM ?? new GUIStyle(styles._ABV);
                styles.DHLIECBFHFIOLJODNKHAIFAMDEFLDKDPBLJH = styles.DHLIECBFHFIOLJODNKHAIFAMDEFLDKDPBLJH ?? new GUIStyle(styles._ABV);
                styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK = styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK ?? new GUIStyle(styles._ABV);
                styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.font = styles._ABV.font;
                styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.font = styles._ABV.font;
                styles._ACK.font = styles._ABV.font;
                styles._ACF.font = styles._ABV.font;
                styles._ACE.font = styles._ABV.font;
                styles._ACL.font = styles._ABV.font;
                styles._ACG.font = styles._ABV.font;
                styles._ACH.font = styles._ABV.font;
                styles._ACN.font = styles._ABV.font;
                styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB.font = styles._ABV.font;
                styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD.font = styles._ABV.font;
                styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL.font = styles._ABV.font;
                styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC.font = styles._ABV.font;
                styles._ACI.font = styles._ABV.font;
                styles._ACJ.font = styles._ABV.font;
                styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM.font = styles._ABV.font;
                styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP.font = styles._ABV.font;
                styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE.font = styles._ABV.font;
                styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK.font = styles._ABV.font;
                styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI.font = styles._ABV.font;
                styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.font = styles._ABV.font;
                styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP.font = styles._ABV.font;
                styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.font = styles._ABV.font;
                styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.font = styles._ABV.font;
                styles._ACC.font = styles._ABV.font;
                styles._ACD.font = styles._ABV.font;
                styles._ACA.font = styles._ABV.font;
                styles._ACB.font = styles._ABV.font;
                styles.BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI.font = styles._ABV.font;
                styles.AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI.font = styles._ABV.font;
                styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.font = styles._ABV.font;
                styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.font = styles._ABV.font;
                styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.wordWrap = true;
                bool flag6 = flag4;
                if (flag6)
                {
                    styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontSize = styles._ABV.fontSize;
                    styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontSize = styles._ABV.fontSize;
                    styles._ACK.fontSize = styles._ABV.fontSize;
                    styles._ACF.fontSize = styles._ABV.fontSize;
                    styles._ACE.fontSize = styles._ABV.fontSize;
                    styles._ACL.fontSize = styles._ABV.fontSize;
                    styles._ACG.fontSize = styles._ABV.fontSize;
                    styles._ACH.fontSize = styles._ABV.fontSize;
                    styles._ACN.fontSize = styles._ABV.fontSize;
                    styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB.fontSize = styles._ABV.fontSize;
                    styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD.fontSize = styles._ABV.fontSize;
                    styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL.fontSize = styles._ABV.fontSize;
                    styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC.fontSize = styles._ABV.fontSize;
                    styles._ACI.fontSize = styles._ABV.fontSize;
                    styles._ACJ.fontSize = styles._ABV.fontSize;
                    styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM.fontSize = styles._ABV.fontSize;
                    styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP.fontSize = styles._ABV.fontSize;
                    styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE.fontSize = styles._ABV.fontSize;
                    styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK.fontSize = styles._ABV.fontSize;
                    styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI.fontSize = styles._ABV.fontSize;
                    styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontSize = styles._ABV.fontSize;
                    styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP.fontSize = styles._ABV.fontSize;
                    styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontSize = styles._ABV.fontSize;
                    styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontSize = styles._ABV.fontSize;
                    styles._ACC.fontSize = styles._ABV.fontSize;
                    styles._ACD.fontSize = styles._ABV.fontSize;
                    styles._ACA.fontSize = styles._ABV.fontSize;
                    styles._ACB.fontSize = styles._ABV.fontSize;
                    styles.BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI.fontSize = styles._ABV.fontSize;
                    styles.AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI.fontSize = styles._ABV.fontSize;
                    styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.fontSize = styles._ABV.fontSize;
                    styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.fontSize = styles._ABV.fontSize;
                }
                else
                {
                    styles._ABV.fontSize = 0;
                    styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontSize = 0;
                    styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontSize = 0;
                    styles._ACK.fontSize = 0;
                    styles._ACF.fontSize = 0;
                    styles._ACE.fontSize = 0;
                    styles._ACL.fontSize = 0;
                    styles._ACG.fontSize = 0;
                    styles._ACH.fontSize = 0;
                    styles._ACN.fontSize = 0;
                    styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB.fontSize = 0;
                    styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD.fontSize = 0;
                    styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL.fontSize = 0;
                    styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC.fontSize = 0;
                    styles._ACI.fontSize = 0;
                    styles._ACJ.fontSize = 0;
                    styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM.fontSize = 0;
                    styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP.fontSize = 0;
                    styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE.fontSize = 0;
                    styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK.fontSize = 0;
                    styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI.fontSize = 0;
                    styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontSize = 0;
                    styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP.fontSize = 0;
                    styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontSize = 0;
                    styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontSize = 0;
                    styles._ACC.fontSize = 0;
                    styles._ACD.fontSize = 0;
                    styles._ACA.fontSize = 0;
                    styles._ACB.fontSize = 0;
                    styles.BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI.fontSize = 0;
                    styles.AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI.fontSize = 0;
                    styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.fontSize = 0;
                    styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.fontSize = 0;
                }
                styles.FKPDLHMDAGCDBKHOJAABIDBDBPCOGPOPIOJC = styles.FKPDLHMDAGCDBKHOJAABIDBDBPCOGPOPIOJC ?? new GUIStyle();
                styles.IICGPMAMBHPFKAIGDAKKDFCDPAKDCNNGOAOF = styles.IICGPMAMBHPFKAIGDAKKDFCDPAKDCNNGOAOF ?? new GUIStyle();
                styles.OAHNJENALMPCNGMEAFGPAOPDCFGGJFIMDLCK = styles.OAHNJENALMPCNGMEAFGPAOPDCFGGJFIMDLCK ?? new GUIStyle();
                styles.LCGFHIJHPLEJMFEAAMLOGEKDKLGPGLCKJHKN = styles.LCGFHIJHPLEJMFEAAMLOGEKDKLGPGLCKJHKN ?? new GUIStyle();
                styles.MGHDGDOIBIKACABHDJMHENIACBOCIOEAJJJH = styles.MGHDGDOIBIKACABHDJMHENIACBOCIOEAJJJH ?? new GUIStyle();
                styles.MNIDILAEJNANLBJOKMBBFAPKMBLJPHDOOKHC = styles.MNIDILAEJNANLBJOKMBBFAPKMBLJPHDOOKHC ?? new GUIStyle();
                styles.FIJCFMEBKKCPHHDEICAFJGNHALMFHHDFMJCF = styles.FIJCFMEBKKCPHHDEICAFJGNHALMFHHDFMJCF ?? new GUIStyle();
                styles.EFFPDLCPLHCEJBKAEOGCFKCJMEJJCGNOEAJC = styles.EFFPDLCPLHCEJBKAEOGCFKCJMEJJCGNOEAJC ?? new GUIStyle();
                styles.LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG = styles.LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG ?? new GUIStyle();
                styles.MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ = styles.MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ ?? new GUIStyle();
                styles.EDPELGLOHBEDHHGMAFPGLEMGKFNEHIMBHLBE = styles.EDPELGLOHBEDHHGMAFPGLEMGKFNEHIMBHLBE ?? new GUIStyle();
                styles.CDKDJIHGIELEEDGFLEBKFMAICBICIONFMOMH = styles.CDKDJIHGIELEEDGFLEBKFMAICBICIONFMOMH ?? new GUIStyle();
                styles.GJOPALBNPHOPNFJCBICFHFIBJHAADOBENDJP = styles.GJOPALBNPHOPNFJCBICFHFIBJHAADOBENDJP ?? new GUIStyle();
                styles.EABGPJDDADACGMHPOGOFNJCDNONPNHNPJIMK = styles.EABGPJDDADACGMHPOGOFNJCDNONPNHNPJIMK ?? new GUIStyle();
                styles._AFT = styles._AFT ?? new GUIStyle();
                styles._AFU = styles._AFU ?? new GUIStyle();
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP = styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP ?? new GUIStyle();
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.richText = false;
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.normal.background = _bi2.PFGMEJLLJPMAPPHJDBPLAODICICMBLHNKKAB;
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.normal.textColor = Color.black;
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.font = styles._ABV.font;
                bool flag7 = flag4;
                if (flag7)
                {
                    styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.fontSize = styles._ABV.fontSize;
                }
                else
                {
                    styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.fontSize = 0;
                }
                bool flag8 = _bg8._AEP > 0;
                if (flag8)
                {
                    styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.border = new RectOffset(10, 10, 10, 10);
                }
                else
                {
                    styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.border = new RectOffset(10 + (int)((float)_bg8._AEP * 0.5f), 10 + (int)((float)_bg8._AEP * 0.5f), 10 + (int)((float)_bg8._AEP * 0.5f), 10 + (int)((float)_bg8._AEP * 0.5f));
                }
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.overflow = new RectOffset(6, 6, 6, 6);
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.stretchWidth = false;
                styles.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.stretchHeight = false;
                _bi2.ApplyTheme(styles, forText ? _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF : _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN);
            }
        }

        // Token: 0x0600029D RID: 669 RVA: 0x00028408 File Offset: 0x00026608
        private static void ApplyTheme(_bi2._AVA styles, Theme currentTheme)
        {
            bool flag = styles == null || currentTheme == null;
            if (!flag)
            {
                styles.MNAINPPJCJGPLHBFJICPBAPKHGGPKHFKGHKI.normal.background = _bi2.FlatColorTexture(currentTheme.background);
                styles.EEHEIDPKDPFECCNEMEAOEDHDMOCMLHIMGBIO.normal.background = _bi2.FlatColorTexture(currentTheme.searchResults);
                styles.OAHNJENALMPCNGMEAFGPAOPDCFGGJFIMDLCK.normal.background = _bi2.FlatColorTexture(currentTheme.text);
                styles.LCGFHIJHPLEJMFEAAMLOGEKDKLGPGLCKJHKN.normal.background = _bi2.FlatColorTexture(currentTheme.activeSelection);
                styles.MGHDGDOIBIKACABHDJMHENIACBOCIOEAJJJH.normal.background = _bi2.FlatColorTexture(currentTheme.passiveSelection);
                styles.FIJCFMEBKKCPHHDEICAFJGNHALMFHHDFMJCF.normal.background = _bi2.FlatColorTexture(currentTheme.trackChanged);
                styles.MNIDILAEJNANLBJOKMBBFAPKMBLJPHDOOKHC.normal.background = _bi2.FlatColorTexture(currentTheme.trackSaved);
                styles.EFFPDLCPLHCEJBKAEOGCFKCJMEJJCGNOEAJC.normal.background = _bi2.FlatColorTexture(currentTheme.trackReverted);
                styles.LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG.normal.background = _bi2.FlatColorTexture(currentTheme.currentLine);
                styles.MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ.normal.background = _bi2.FlatColorTexture(currentTheme.currentLineInactive);
                styles.EDPELGLOHBEDHHGMAFPGLEMGKFNEHIMBHLBE.normal.background = _bi2.FlatColorTexture(currentTheme.referenceHighlight);
                styles.CDKDJIHGIELEEDGFLEBKFMAICBICIONFMOMH.normal.background = _bi2.FlatColorTexture(currentTheme.referenceModifyHighlight);
                styles.GJOPALBNPHOPNFJCBICFHFIBJHAADOBENDJP.normal.background = _bi2.FlatColorTexture(currentTheme.tooltipBackground);
                styles.EABGPJDDADACGMHPOGOFNJCDNONPNHNPJIMK.normal.background = _bi2.FlatColorTexture(currentTheme.tooltipFrame);
                styles._AFT.normal.background = _bi2.FlatColorTexture((currentTheme.listPopupFrame == Color.clear) ? currentTheme.fold : currentTheme.listPopupFrame);
                styles._AFU.normal.background = _bi2.FlatColorTexture(currentTheme.listPopupBackground);
                styles._ABV.normal.textColor = currentTheme.text;
                styles._ACK.normal.textColor = currentTheme.keywords;
                styles._ACF.normal.textColor = currentTheme.constants;
                styles._ACE.normal.textColor = currentTheme.strings;
                styles._ACL.normal.textColor = currentTheme.builtInLiterals;
                styles._ACG.normal.textColor = currentTheme.operators;
                styles._ACH.normal.textColor = ((currentTheme.punctuators.a > 0f) ? currentTheme.punctuators : currentTheme.text);
                styles._ACN.normal.textColor = currentTheme.referenceTypes;
                styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB.normal.textColor = currentTheme.valueTypes;
                styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD.normal.textColor = currentTheme.interfaceTypes;
                styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL.normal.textColor = currentTheme.enumTypes;
                styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC.normal.textColor = currentTheme.delegateTypes;
                styles._ACI.normal.textColor = ((currentTheme.builtInTypes.a > 0f) ? currentTheme.builtInTypes : currentTheme.referenceTypes);
                styles._ACJ.normal.textColor = ((currentTheme.builtInTypes.a > 0f) ? currentTheme.builtInTypes : currentTheme.valueTypes);
                styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM.normal.textColor = currentTheme.namespaces;
                styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP.normal.textColor = currentTheme.methods;
                styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE.normal.textColor = currentTheme.fields;
                styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK.normal.textColor = currentTheme.properties;
                styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI.normal.textColor = currentTheme.events;
                styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.normal.textColor = currentTheme.parameters;
                styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP.normal.textColor = currentTheme.variables;
                styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.normal.textColor = currentTheme.typeParameters;
                styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.normal.textColor = ((currentTheme.enumMembers.a != 0f) ? currentTheme.enumMembers : currentTheme.text);
                styles._ACC.normal.textColor = currentTheme.preprocessor;
                styles._ACD.normal.textColor = currentTheme.defineSymbols;
                styles._ACA.normal.textColor = currentTheme.inactiveCode;
                styles._ACB.normal.textColor = currentTheme.comments;
                styles.BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI.normal.textColor = currentTheme.xmlDocs;
                styles.AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI.normal.textColor = currentTheme.xmlDocsTags;
                styles.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.normal.textColor = (_bg8._BAF ? currentTheme.text : currentTheme.tooltipText);
                styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.normal.textColor = currentTheme.hyperlinks;
                styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.normal.textColor = currentTheme.hyperlinks;
                styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.normal.background = (styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.normal.background = _bi2.UnderlineTexture(currentTheme.hyperlinks, (int)styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.lineHeight));
                styles.FKPDLHMDAGCDBKHOJAABIDBDBPCOGPOPIOJC.normal.background = _bi2.FlatColorTexture(currentTheme.lineNumbersBackground);
                styles.IICGPMAMBHPFKAIGDAKKDFCDPAKDCNNGOAOF.normal.background = _bi2.FlatColorTexture(currentTheme.fold);
                styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.normal.textColor = currentTheme.lineNumbers;
                styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.hover.textColor = currentTheme.lineNumbersHighlight;
                styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.hover.background = styles.FKPDLHMDAGCDBKHOJAABIDBDBPCOGPOPIOJC.normal.background;
                styles.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.alignment = 2;
                bool flag2 = _bi2.GetDynamicFontSize(styles._ABV.font) != 0;
                int num = ((_bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC == "Fonts/DejaVu Sans Mono.ttf") ? 3 : 2);
                styles._ACB.fontStyle = (flag2 ? (currentTheme.commentsStyle & num) : 0);
                styles._ACE.fontStyle = (flag2 ? (currentTheme.stringsStyle & num) : 0);
                styles._ACK.fontStyle = (flag2 ? (currentTheme.keywordsStyle & num) : 0);
                styles._ACF.fontStyle = (flag2 ? (currentTheme.constantsStyle & num) : 0);
                styles._ACN.fontStyle = (flag2 ? (currentTheme.typesStyle & num) : 0);
                styles.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB.fontStyle = (flag2 ? (currentTheme.typesStyle & num) : 0);
                styles.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD.fontStyle = (flag2 ? (currentTheme.typesStyle & num) : 0);
                styles.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL.fontStyle = (flag2 ? (currentTheme.typesStyle & num) : 0);
                styles.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC.fontStyle = (flag2 ? (currentTheme.typesStyle & num) : 0);
                styles._ACI.fontStyle = (flag2 ? (((currentTheme.builtInTypes == Color.clear) ? currentTheme.typesStyle : currentTheme.keywordsStyle) & num) : 0);
                styles._ACJ.fontStyle = (flag2 ? (((currentTheme.builtInTypes == Color.clear) ? currentTheme.typesStyle : currentTheme.keywordsStyle) & num) : 0);
                styles.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM.fontStyle = (flag2 ? (currentTheme.namespacesStyle & num) : 0);
                styles.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP.fontStyle = (flag2 ? (currentTheme.methodsStyle & num) : 0);
                styles.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE.fontStyle = (flag2 ? (currentTheme.fieldsStyle & num) : 0);
                styles.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK.fontStyle = (flag2 ? (currentTheme.propertiesStyle & num) : 0);
                styles.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI.fontStyle = (flag2 ? (currentTheme.eventsStyle & num) : 0);
                styles.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontStyle = (flag2 ? (currentTheme.hyperlinksStyle & num) : 0);
                styles.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontStyle = (flag2 ? (currentTheme.hyperlinksStyle & num) : 0);
                styles._ACC.fontStyle = (flag2 ? (currentTheme.preprocessorStyle & num) : 0);
                styles._ACD.fontStyle = (flag2 ? (currentTheme.preprocessorStyle & num) : 0);
                styles._ACA.fontStyle = (flag2 ? (currentTheme.inactiveCodeStyle & num) : 0);
                styles.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontStyle = (flag2 ? (currentTheme.parametersStyle & num) : 0);
                styles.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP.fontStyle = (flag2 ? (currentTheme.variablesStyle & num) : 0);
                styles.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontStyle = (flag2 ? (currentTheme.typeParametersStyle & num) : 0);
                styles.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontStyle = (flag2 ? (currentTheme.enumMembersStyle & num) : 0);
            }
        }

        // Token: 0x0600029E RID: 670 RVA: 0x00028D18 File Offset: 0x00026F18
        internal static Texture2D FlatColorTexture(Color color)
        {
            Texture2D texture2D = new Texture2D(1, 1, 4, false, false);
            texture2D.SetPixels(new Color[] { color });
            texture2D.Apply();
            texture2D.hideFlags = 61;
            return texture2D;
        }

        // Token: 0x0600029F RID: 671 RVA: 0x00028D5C File Offset: 0x00026F5C
        private static Texture2D UnderlineTexture(Color color, int lineHeight)
        {
            return _bi2.CreateUnderlineTexture(color, lineHeight, Color.clear);
        }

        // Token: 0x060002A0 RID: 672 RVA: 0x00028D7C File Offset: 0x00026F7C
        private static Texture2D CreateUnderlineTexture(Color color, int lineHeight, Color bgColor)
        {
            Texture2D texture2D = new Texture2D(1, lineHeight, 4, false, true);
            texture2D.SetPixel(0, 0, color);
            for (int i = 1; i < lineHeight; i++)
            {
                texture2D.SetPixel(0, i, new Color32(0, 0, 0, 0));
            }
            texture2D.Apply();
            texture2D.hideFlags = 61;
            return texture2D;
        }

        // Token: 0x060002A1 RID: 673 RVA: 0x00028DDC File Offset: 0x00026FDC
        private static bool MightBePrintableKey(Event evt)
        {
            bool flag = evt.command || evt.control;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool alt = evt.alt;
                if (alt)
                {
                    flag2 = false;
                }
                else
                {
                    bool flag3 = evt.keyCode >= 323 && evt.keyCode <= 329;
                    if (flag3)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        bool flag4 = evt.keyCode >= 330;
                        if (flag4)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            bool flag5 = evt.keyCode >= 282 && evt.keyCode <= 296;
                            if (flag5)
                            {
                                flag2 = false;
                            }
                            else
                            {
                                KeyCode keyCode = evt.keyCode;
                                KeyCode keyCode2 = keyCode;
                                if (keyCode2 <= 12)
                                {
                                    if (keyCode2 == null)
                                    {
                                        return evt.character > '\0';
                                    }
                                    if (keyCode2 != 8 && keyCode2 != 12)
                                    {
                                        goto IL_01DC;
                                    }
                                }
                                else if (keyCode2 <= 27)
                                {
                                    if (keyCode2 != 19 && keyCode2 != 27)
                                    {
                                        goto IL_01DC;
                                    }
                                }
                                else if (keyCode2 != 127)
                                {
                                    switch (keyCode2)
                                    {
                                        case 273:
                                        case 274:
                                        case 275:
                                        case 276:
                                        case 277:
                                        case 278:
                                        case 279:
                                        case 280:
                                        case 281:
                                        case 300:
                                        case 301:
                                        case 302:
                                        case 303:
                                        case 304:
                                        case 305:
                                        case 306:
                                        case 307:
                                        case 308:
                                        case 309:
                                        case 310:
                                        case 311:
                                        case 312:
                                        case 313:
                                        case 315:
                                        case 316:
                                        case 317:
                                        case 318:
                                        case 319:
                                            break;
                                        case 282:
                                        case 283:
                                        case 284:
                                        case 285:
                                        case 286:
                                        case 287:
                                        case 288:
                                        case 289:
                                        case 290:
                                        case 291:
                                        case 292:
                                        case 293:
                                        case 294:
                                        case 295:
                                        case 296:
                                        case 297:
                                        case 298:
                                        case 299:
                                        case 314:
                                            goto IL_01DC;
                                        default:
                                            goto IL_01DC;
                                    }
                                }
                                return false;
                            IL_01DC:
                                flag2 = true;
                            }
                        }
                    }
                }
            }
            return flag2;
        }

        // Token: 0x060002A2 RID: 674 RVA: 0x00028FCC File Offset: 0x000271CC
        private void UpdateMatchingBraces()
        {
            this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH = (this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL = default(TextPosition));
            int num;
            int num2;
            bool flag;
            SyntaxToken tokenAt = this._ABQ.GetTokenAt(this._ABH, out num, out num2, out flag);
            GCE.PHFG[] _AQS = this._ABQ._AQQ;
            bool flag2 = num >= _AQS.Length;
            if (!flag2)
            {
                int num3 = num;
                List<SyntaxToken> _ABS = _AQS[num3].EOIA;
                bool flag3 = _ABS == null;
                if (!flag3)
                {
                    bool flag4 = tokenAt != null && (flag || this._ABH._AEU == 0) && tokenAt.text.Length == 1 && (tokenAt.text[0] == '}' || tokenAt.text[0] == ']' || tokenAt.text[0] == ')');
                    if (flag4)
                    {
                        SyntaxToken syntaxToken = ((num2 + 1 < _ABS.Count) ? _ABS[num2 + 1] : null);
                        bool flag5 = syntaxToken == null || syntaxToken.text.Length != 1 || (syntaxToken.text[0] != '}' && syntaxToken.text[0] != ']' && syntaxToken.text[0] != ')');
                        if (flag5)
                        {
                            num2--;
                        }
                    }
                    else
                    {
                        bool flag6 = tokenAt != null && flag;
                        if (flag6)
                        {
                            bool flag7 = tokenAt.text.Length != 1 || (tokenAt.text[0] != '{' && tokenAt.text[0] != '[' && tokenAt.text[0] != '(');
                            if (flag7)
                            {
                                SyntaxToken syntaxToken2 = ((num2 + 1 < _ABS.Count) ? _ABS[num2 + 1] : null);
                                bool flag8 = syntaxToken2 != null && syntaxToken2.text.Length == 1 && (syntaxToken2.text[0] == '{' || syntaxToken2.text[0] == '[' || syntaxToken2.text[0] == '(');
                                if (flag8)
                                {
                                    num2++;
                                }
                            }
                        }
                    }
                    this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH = this._ABQ.GetOpeningBraceLeftOf(num3, num2, -1);
                    this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL = this._ABQ.GetClosingBraceRightOf(num, num2, -1);
                }
            }
        }

        // Token: 0x060002A3 RID: 675 RVA: 0x00029224 File Offset: 0x00027424
        private List<int> GetSoftLineBreaks(int line)
        {
            bool flag = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
            List<int> list;
            if (flag)
            {
                list = _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
            }
            else
            {
                bool flag2 = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH == null;
                if (flag2)
                {
                    this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH = new List<List<int>>(this._ABQ.FLOg.Count);
                }
                bool flag3 = line < this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count && this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[line] != null;
                if (flag3)
                {
                    list = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[line];
                }
                else
                {
                    bool flag4 = line >= this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count;
                    if (flag4)
                    {
                        bool flag5 = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Capacity < this._ABQ.FLOg.Count;
                        if (flag5)
                        {
                            this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Capacity = this._ABQ.FLOg.Count;
                        }
                        for (int i = this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Count; i < this._ABQ.FLOg.Count; i++)
                        {
                            this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH.Add(null);
                        }
                    }
                    bool flag6 = this._AEY().x == 0f || this._AEY().x * 2f > this._ALM.width;
                    if (flag6)
                    {
                        list = _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                    }
                    else
                    {
                        bool flag7 = line >= this._ABQ._AQQ.Length;
                        if (flag7)
                        {
                            list = _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                        }
                        else
                        {
                            GCE.PHFG _AUB = this._ABQ._AQQ[line];
                            bool flag8 = _AUB.EOIA == null;
                            if (flag8)
                            {
                                list = _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                            }
                            else
                            {
                                List<int> list2 = (this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[line] = _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC);
                                float num = this._ALM.width;
                                num = ((num < 8f * this._AEY().x) ? (8f * this._AEY().x) : num);
                                this.BBNCFBJBOKMILIDIMJKJKEHCDAFMDFNDNGGI = false;
                                int num2 = 0;
                                float num3 = 0f;
                                foreach (SyntaxToken syntaxToken in _AUB.EOIA)
                                {
                                    bool flag9 = syntaxToken == null;
                                    if (!flag9)
                                    {
                                        bool flag10 = (syntaxToken.tokenKind > SyntaxToken.Kind.InterpolatedStringEndLiteral && syntaxToken.tokenKind < SyntaxToken.Kind.StringLiteral) || syntaxToken.tokenKind > SyntaxToken.Kind.InterpolatedStringEndLiteral;
                                        if (flag10)
                                        {
                                            int length = syntaxToken.text.Length;
                                            bool flag11 = length == 0;
                                            if (!flag11)
                                            {
                                                float textWidth = this.GetTextWidth(line, num2, num2 + length, num3);
                                                bool flag12 = num3 + textWidth < num;
                                                if (flag12)
                                                {
                                                    num2 += length;
                                                    num3 += textWidth;
                                                }
                                                else
                                                {
                                                    bool flag13 = list2 == _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                                                    if (flag13)
                                                    {
                                                        list2 = (this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[line] = new List<int>());
                                                    }
                                                    bool flag14 = num3 > 0f;
                                                    if (flag14)
                                                    {
                                                        list2.Add(num2);
                                                    }
                                                    bool flag15 = textWidth > num;
                                                    if (flag15)
                                                    {
                                                        int num4 = (int)(num / this._AEY().x);
                                                        int j;
                                                        for (j = num4; j < length; j += num4)
                                                        {
                                                            list2.Add(num2 + j);
                                                        }
                                                        num3 = this.GetTextWidth(line, num2 + j, num2 + length, 0f);
                                                    }
                                                    else
                                                    {
                                                        num3 = textWidth;
                                                    }
                                                    num2 += length;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int num5 = ((num3 > 0f) ? (-1) : 0);
                                            int num6 = -1;
                                            for (int k = 0; k < syntaxToken.text.Length; k++)
                                            {
                                                num3 += this.GetTextWidth(line, num2 + k, num2 + k + 1, num3);
                                                bool flag16 = syntaxToken.text[k] == ' ' || syntaxToken.text[k] == '\t';
                                                if (flag16)
                                                {
                                                    num6 = k;
                                                }
                                                bool flag17 = num3 >= num;
                                                if (flag17)
                                                {
                                                    bool flag18 = list2 == _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                                                    if (flag18)
                                                    {
                                                        list2 = (this.LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH[line] = new List<int>());
                                                    }
                                                    bool flag19 = num6 >= num5;
                                                    if (flag19)
                                                    {
                                                        num5 = num6 + 1;
                                                        list2.Add(num2 + num5);
                                                        num6 = -1;
                                                    }
                                                    else
                                                    {
                                                        bool flag20 = num5 >= 0;
                                                        if (flag20)
                                                        {
                                                            num5 = k;
                                                            list2.Add(num2 + num5);
                                                        }
                                                        else
                                                        {
                                                            list2.Add(num2);
                                                        }
                                                    }
                                                    num3 = this.GetTextWidth(line, num2 + num5, num2 + k, 0f);
                                                }
                                            }
                                            num2 += syntaxToken.text.Length;
                                        }
                                    }
                                }
                                bool flag21 = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC != null && this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count > line;
                                if (flag21)
                                {
                                    float num7 = ((line > 0) ? this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC[line - 1] : 0f);
                                    float num8 = (this.IsLineVisible(line) ? (num7 + this._AEY().y * (float)(list2.Count + 1)) : num7);
                                    bool flag22 = num8 != this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC[line];
                                    if (flag22)
                                    {
                                        num7 = num8 - this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC[line];
                                        for (int l = line; l < this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC.Count; l++)
                                        {
                                            List<float> jklcmhofnijekghfafdfneimanieoaimbkpc = this.JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC;
                                            int num9 = l;
                                            jklcmhofnijekghfafdfneimanieoaimbkpc[num9] += num7;
                                        }
                                    }
                                }
                                list = list2;
                            }
                        }
                    }
                }
            }
            return list;
        }

        // Token: 0x060002A4 RID: 676 RVA: 0x000297D0 File Offset: 0x000279D0
        private GUIStyle GetTokenStyle(SyntaxToken token)
        {
            GUIStyle guistyle = token.style ?? this._ABQ._ABT._ABV;
            bool flag = token.tokenKind == SyntaxToken.Kind.ContextualKeyword;
            GUIStyle guistyle2;
            if (flag)
            {
                guistyle = ((token.text == "value") ? this._ABQ._ABT.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG : this._ABQ._ABT._ACK);
                bool flag2 = token.text == "var" && token.OOME != null && (token.OOME._AAB() == null || token.OOME._AAB()._AT == SymbolKind.Error);
                if (flag2)
                {
                    _bc9.ResolveNode(token.OOME.OOME);
                }
                guistyle2 = guistyle;
            }
            else
            {
                _bb4.DHBA _AMI = token.OOME;
                bool flag3 = _AMI != null && _AMI.OOME != null;
                if (flag3)
                {
                    bool flag4 = token.tokenKind == SyntaxToken.Kind.Keyword;
                    if (flag4)
                    {
                        bool flag5 = (token.text == "base" || token.text == "this") && (_AMI._AAB() == null || _AMI._AJB != null);
                        if (flag5)
                        {
                            _bc9.ResolveNode(_AMI.OOME);
                        }
                    }
                    else
                    {
                        bool flag6 = token.tokenKind == SyntaxToken.Kind.Identifier;
                        if (flag6)
                        {
                            bool flag7 = _AMI._AAB() == null || _AMI._AJB != null;
                            if (flag7)
                            {
                                _bc9.ResolveNode(_AMI.OOME);
                            }
                            bool flag8 = _AMI._AAB() != null;
                            if (flag8)
                            {
                                switch (_AMI._AAB()._AT)
                                {
                                    case SymbolKind.Namespace:
                                        guistyle = this._ABQ._ABT.MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM;
                                        break;
                                    case SymbolKind.Interface:
                                        guistyle = this._ABQ._ABT.FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD;
                                        break;
                                    case SymbolKind.Enum:
                                        guistyle = this._ABQ._ABT.AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL;
                                        break;
                                    case SymbolKind.Struct:
                                        guistyle = this._ABQ._ABT.ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB;
                                        break;
                                    case SymbolKind.Class:
                                        guistyle = this._ABQ._ABT._ACN;
                                        break;
                                    case SymbolKind.Delegate:
                                        guistyle = this._ABQ._ABT.NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC;
                                        break;
                                    case SymbolKind.Field:
                                    case SymbolKind.ConstantField:
                                        {
                                            bool flag9 = _AMI._AAB()._AO != null && _AMI._AAB()._AO._AT == SymbolKind.Enum;
                                            if (flag9)
                                            {
                                                guistyle = this._ABQ._ABT.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI;
                                            }
                                            else
                                            {
                                                _bh4 _AAH = _AMI._AAB().TypeOf();
                                                bool flag10 = _AAH != null && _AAH._AT == SymbolKind.Delegate;
                                                if (flag10)
                                                {
                                                    guistyle = this._ABQ._ABT.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI;
                                                }
                                                else
                                                {
                                                    guistyle = this._ABQ._ABT.IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE;
                                                }
                                            }
                                            break;
                                        }
                                    case SymbolKind.LocalConstant:
                                    case SymbolKind.Variable:
                                    case SymbolKind.ForEachVariable:
                                    case SymbolKind.FromClauseVariable:
                                        guistyle = this._ABQ._ABT.FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP;
                                        break;
                                    case SymbolKind.EnumMember:
                                    case SymbolKind.Label:
                                        guistyle = this._ABQ._ABT.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI;
                                        break;
                                    case SymbolKind.Property:
                                        guistyle = this._ABQ._ABT.LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK;
                                        break;
                                    case SymbolKind.Event:
                                        guistyle = this._ABQ._ABT.CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI;
                                        break;
                                    case SymbolKind.Method:
                                    case SymbolKind.MethodGroup:
                                    case SymbolKind.Constructor:
                                    case SymbolKind.Destructor:
                                    case SymbolKind.Accessor:
                                        guistyle = this._ABQ._ABT.IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP;
                                        break;
                                    case SymbolKind.Parameter:
                                    case SymbolKind.CatchParameter:
                                        guistyle = this._ABQ._ABT.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG;
                                        break;
                                    case SymbolKind.TypeParameter:
                                        guistyle = this._ABQ._ABT.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD;
                                        break;
                                    case SymbolKind.Null:
                                        guistyle = this._ABQ._ABT._ACL;
                                        break;
                                }
                            }
                        }
                    }
                }
                guistyle2 = guistyle;
            }
            return guistyle2;
        }

        // Token: 0x060002A5 RID: 677 RVA: 0x00029BE0 File Offset: 0x00027DE0
        private static void DrawWavyUnderline(Rect rect, Color color)
        {
            Color color2 = GUI.color;
            GUI.color = color;
            rect.yMin = rect.yMax - 2f;
            rect.yMax += 1f;
            bool flag = _bi2.NLKLFFEHGAOCPBJMKILBAJBPHJMHBJEKHOFA != null;
            if (flag)
            {
                GUI.DrawTextureWithTexCoords(rect, _bi2.NLKLFFEHGAOCPBJMKILBAJBPHJMHBJEKHOFA, new Rect(rect.xMin / 6f, 0f, rect.width / 6f, 1f));
            }
            GUI.color = color2;
        }

        // Token: 0x060002A6 RID: 678 RVA: 0x00029C70 File Offset: 0x00027E70
        private void DrawSelectionRectCharIndex(int line, int startCharIndex, int numChars, bool newLine, GUIStyle style)
        {
            bool flag = style == null;
            if (flag)
            {
                style = (this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() ? this._ABT.LCGFHIJHPLEJMFEAAMLOGEKDKLGPGLCKJHKN : this._ABT.MGHDGDOIBIKACABHDJMHENIACBOCIOEAJJJH);
            }
            bool flag2 = !this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL && style == this._ABT.LCGFHIJHPLEJMFEAAMLOGEKDKLGPGLCKJHKN;
            bool flag3 = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
            if (flag3)
            {
                float lineOffset = this.GetLineOffset(line);
                float charXOffset = this.GetCharXOffset(startCharIndex, line, 0);
                float num = this.GetCharXOffset(startCharIndex + numChars, line, 0);
                if (newLine)
                {
                    num += this._AEY().x;
                }
                Rect rect;
                rect..ctor(charXOffset + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, lineOffset, num - charXOffset, this._AEY().y);
                GUI.Label(rect, GUIContent.none, style);
                bool flag4 = flag2;
                if (flag4)
                {
                    EditorGUIUtility.AddCursorRect(rect, 8);
                }
            }
            else
            {
                float num2 = this.GetLineOffset(line);
                List<int> softLineBreaks = this.GetSoftLineBreaks(line);
                int num3 = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(softLineBreaks, startCharIndex);
                bool flag5 = num3 < softLineBreaks.Count && startCharIndex == softLineBreaks[num3];
                if (flag5)
                {
                    num3++;
                }
                int num4 = ((num3 > 0) ? softLineBreaks[num3 - 1] : 0);
                bool flag6 = newLine && numChars == 0 && startCharIndex == this._ABQ.FLOg[line].Length;
                if (flag6)
                {
                    float charXOffset2 = this.GetCharXOffset(startCharIndex, line, num4);
                    Rect rect2;
                    rect2..ctor(charXOffset2 + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, num2 + (float)num3 * this._AEY().y, this._AEY().x, this._AEY().y);
                    GUI.Label(rect2, GUIContent.none, style);
                    bool flag7 = flag2;
                    if (flag7)
                    {
                        EditorGUIUtility.AddCursorRect(rect2, 8);
                    }
                }
                else
                {
                    num2 += this._AEY().y * (float)num3;
                    startCharIndex -= num4;
                    while (numChars > 0)
                    {
                        int num5 = ((num3 < softLineBreaks.Count) ? (softLineBreaks[num3] - num4) : (startCharIndex + numChars));
                        int num6 = Math.Min(numChars, num5 - startCharIndex);
                        float charXOffset3 = this.GetCharXOffset(num4 + startCharIndex, line, num4);
                        float num7 = this.GetCharXOffset(num4 + startCharIndex + num6, line, num4) + ((numChars == num6 && newLine) ? this._AEY().x : 0f);
                        Rect rect3;
                        rect3..ctor(charXOffset3 + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, num2, num7 - charXOffset3, this._AEY().y);
                        GUI.Label(rect3, GUIContent.none, style);
                        bool flag8 = flag2;
                        if (flag8)
                        {
                            EditorGUIUtility.AddCursorRect(rect3, 8);
                        }
                        numChars -= num6;
                        num4 += num5;
                        startCharIndex = 0;
                        num3++;
                        num2 += this._AEY().y;
                    }
                }
            }
        }

        // Token: 0x060002A7 RID: 679 RVA: 0x00029F40 File Offset: 0x00028140
        public GUIStyle GetReferenceHighlightStyle(SyntaxToken token)
        {
            GUIStyle guistyle = this._ABT.EDPELGLOHBEDHHGMAFPGLEMGKFNEHIMBHLBE;
            bool flag = !_bg8._BAI;
            GUIStyle guistyle2;
            if (flag)
            {
                guistyle2 = guistyle;
            }
            else
            {
                bool flag2 = this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != null && _bc9.IsWriteReference(token);
                if (flag2)
                {
                    guistyle = this._ABT.CDKDJIHGIELEEDGFLEBKFMAICBICIONFMOMH;
                }
                guistyle2 = guistyle;
            }
            return guistyle2;
        }

        // Token: 0x060002A8 RID: 680 RVA: 0x00029F98 File Offset: 0x00028198
        public void ValidateCarets()
        {
            bool flag = this.CanEdit();
            if (flag)
            {
                this.ValidateCaret(ref this._ABH);
                bool bodjhgoiefmippgplnbaibniefngejodghfl = this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL;
                if (bodjhgoiefmippgplnbaibniefngejodghfl)
                {
                    this.ValidateCaret(ref this.GLAAHLAEKKCKGBFLOGGJOIAHHBGOIFHFLJOL);
                }
                this.Repaint();
            }
        }

        // Token: 0x060002A9 RID: 681 RVA: 0x00029FE0 File Offset: 0x000281E0
        private bool ValidateCaret(ref GCE._AFA caret)
        {
            bool flag = caret != null && this._ABQ.FLOg.Count > 0;
            if (flag)
            {
                bool flag2 = caret._ABI < 0;
                if (flag2)
                {
                    return false;
                }
                bool flag3 = caret._ABI >= this._ABQ.FLOg.Count;
                if (flag3)
                {
                    caret = new GCE._AFA
                    {
                        _ABI = this._ABQ.FLOg.Count - 1,
                        _AEU = 0,
                        _ATG = 0,
                        _ATF = 0
                    };
                    return false;
                }
                bool flag4 = caret._AEU > this._ABQ.FLOg[caret._ABI].Length;
                if (flag4)
                {
                    caret = new GCE._AFA
                    {
                        _ABI = caret._ABI,
                        _AEU = 0,
                        _ATG = 0,
                        _ATF = 0
                    };
                    return false;
                }
                caret._ATG = (caret._ATF = this.CharIndexToColumn(caret._AEU, caret._ABI));
            }
            return true;
        }

        // Token: 0x060002AA RID: 682 RVA: 0x0002A110 File Offset: 0x00028310
        private Rect GetCaretRect(GCE._AFA position)
        {
            Vector2 vector = this.BufferToViewPosition(position);
            Rect rect;
            rect..ctor(vector.x + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, vector.y + this.GetLineOffset(position._ABI), 1f, this._AEY().y);
            bool flag = _bg8._BAK;
            if (flag)
            {
                rect.xMin -= 1f;
            }
            return rect;
        }

        // Token: 0x060002AB RID: 683 RVA: 0x0002A184 File Offset: 0x00028384
        private Rect GetTokenRect(SyntaxToken token)
        {
            Rect rect = default(Rect);
            bool flag = this._ABQ == null || token.OOME == null;
            Rect rect2;
            if (flag)
            {
                rect2 = rect;
            }
            else
            {
                TextSpan tokenSpan = this._ABQ.GetTokenSpan(token.OOME.line, token.OOME._AJG());
                rect = this.GetTextRect(tokenSpan);
                Vector2 vector = GUIUtility.GUIToScreenPoint(new Vector2(rect.xMin, rect.yMin));
                rect.x = vector.x;
                rect.y = vector.y;
                rect2 = rect;
            }
            return rect2;
        }

        // Token: 0x060002AC RID: 684 RVA: 0x0002A224 File Offset: 0x00028424
        private Rect GetTextRect(TextSpan span)
        {
            Vector2 vector = this.BufferToViewPosition(span.line, span.index, false);
            float textWidth = this.GetTextWidth(span.line, span.index, span.index + span.indexOffset, vector.x);
            Rect rect;
            rect..ctor(vector.x + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, vector.y + this.GetLineOffset(span.line), textWidth, this._AEY().y);
            return rect;
        }

        // Token: 0x060002AD RID: 685 RVA: 0x0002A2A4 File Offset: 0x000284A4
        private float GetTextWidth(int line, int fromChar, int toChar, float xOffset)
        {
            List<string> flogicchcfaljohninkpcdacoidcghkimhpo = this._ABQ.FLOg;
            bool flag = line >= flogicchcfaljohninkpcdacoidcghkimhpo.Count;
            float num;
            if (flag)
            {
                num = 0f;
            }
            else
            {
                string text = flogicchcfaljohninkpcdacoidcghkimhpo[line];
                bool flag2 = fromChar >= text.Length;
                if (flag2)
                {
                    num = 0f;
                }
                else
                {
                    bool flag3 = toChar >= text.Length;
                    if (flag3)
                    {
                        toChar = text.Length;
                    }
                    bool flag4 = fromChar >= toChar;
                    if (flag4)
                    {
                        num = 0f;
                    }
                    else
                    {
                        float num2 = 0f;
                        float num3 = (float)_bg8._ASA * this._AEY().x;
                        for (int i = fromChar; i < toChar; i++)
                        {
                            char c = text[i];
                            bool flag5 = c == '\t';
                            float num4;
                            if (flag5)
                            {
                                num4 = num3 - xOffset % num3;
                            }
                            else
                            {
                                bool flag6 = c < '\u007f';
                                if (flag6)
                                {
                                    num4 = this._AEY().x;
                                }
                                else
                                {
                                    int j;
                                    for (j = i + 1; j < toChar; j++)
                                    {
                                        bool flag7 = text[j] < '\u007f';
                                        if (flag7)
                                        {
                                            break;
                                        }
                                    }
                                    _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = text.Substring(i, j - i);
                                    num4 = this._ABT._ABV.CalcSize(_bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM).x;
                                    i = j - 1;
                                }
                            }
                            xOffset += num4;
                            num2 += num4;
                        }
                        num = num2;
                    }
                }
            }
            return num;
        }

        // Token: 0x060002AE RID: 686 RVA: 0x0002A434 File Offset: 0x00028634
        private void ToggleFolding(int line)
        {
            string regionName = this._ABQ._AQQ[line].GetRegionName();
            int num = this.FDJNLNLEAGGCEHMOOPKBCCCLCKEMHMBENEAF.IndexOf(regionName);
            bool flag = num < 0;
            if (flag)
            {
                this.FDJNLNLEAGGCEHMOOPKBCCCLCKEMHMBENEAF.Add(regionName);
                GCE._ABW _AUX = this._ABQ._AQQ[line]._ABZ;
                while (++line < this._ABQ._AQQ.Length)
                {
                    GCE._ABW _AVO = this._ABQ._AQQ[line]._ABZ;
                    while (_AVO != _AUX && _AVO != null)
                    {
                        _AVO = _AVO.OOME;
                    }
                    bool flag2 = _AVO != _AUX;
                    if (flag2)
                    {
                        break;
                    }
                }
            }
            else
            {
                this.FDJNLNLEAGGCEHMOOPKBCCCLCKEMHMBENEAF.RemoveAt(num);
                GCE._ABW _AUX2 = this._ABQ._AQQ[line]._ABZ;
                while (++line < this._ABQ._AQQ.Length)
                {
                    GCE._ABW _AVO2 = this._ABQ._AQQ[line]._ABZ;
                    while (_AVO2 != _AUX2 && _AVO2 != null)
                    {
                        _AVO2 = _AVO2.OOME;
                    }
                    bool flag3 = _AVO2 != _AUX2;
                    if (flag3)
                    {
                        break;
                    }
                }
                this.KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP.Clear();
                this.NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI.Clear();
            }
        }

        // Token: 0x060002AF RID: 687 RVA: 0x0002A594 File Offset: 0x00028794
        private void CommandFindAllReferences()
        {
            bool flag = !this._ABQ._ASC;
            if (!flag)
            {
                int num;
                int num2;
                bool flag2;
                SyntaxToken syntaxToken = this._ABQ.GetTokenAt(this._ABH, out num, out num2, out flag2);
                bool flag3 = syntaxToken == null;
                if (!flag3)
                {
                    bool flag4 = flag2 && syntaxToken.tokenKind != SyntaxToken.Kind.Identifier && syntaxToken.tokenKind != SyntaxToken.Kind.ContextualKeyword && syntaxToken.tokenKind != SyntaxToken.Kind.Keyword;
                    if (flag4)
                    {
                        List<SyntaxToken> _ABS = this._ABQ._AQQ[num].EOIA;
                        bool flag5 = num2 < _ABS.Count - 1;
                        if (flag5)
                        {
                            syntaxToken = _ABS[num2 + 1];
                        }
                    }
                    bool flag6 = syntaxToken.tokenKind == SyntaxToken.Kind.StringLiteral || syntaxToken.tokenKind == SyntaxToken.Kind.Comment || syntaxToken.tokenKind == SyntaxToken.Kind.PreprocessorSymbol;
                    if (flag6)
                    {
                        _bg3.FindAllResultsInAllAssets();
                    }
                    else
                    {
                        bool flag7 = (syntaxToken.tokenKind != SyntaxToken.Kind.Identifier && syntaxToken.tokenKind != SyntaxToken.Kind.ContextualKeyword && syntaxToken.tokenKind != SyntaxToken.Kind.Keyword) || string.IsNullOrEmpty(syntaxToken.text);
                        if (!flag7)
                        {
                            _bh4 _AAH = syntaxToken.OOME._AAB();
                            bool flag8 = _AAH == null || _AAH._AT == SymbolKind.Error || !_AAH.IsValid();
                            if (!flag8)
                            {
                                _bh6.FindAllReferences(_AAH, this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC());
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060002B0 RID: 688 RVA: 0x0002A6E4 File Offset: 0x000288E4
        private void CommandDeleteLine()
        {
            this.ProcessEditorKeyboard(new Event
            {
                type = 4,
                keyCode = 127,
                modifiers = 1
            }, true);
        }

        // Token: 0x060002B1 RID: 689 RVA: 0x0002A71C File Offset: 0x0002891C
        private void CommandDuplicateLinesDown()
        {
            int num = ((this._ATW() == null) ? 1 : (Mathf.Abs(this._ABH._ABI - this._ATW()._ABI) + 1));
            bool flag = this._ATW() != null;
            if (flag)
            {
                bool flag2 = this._ATW() < this._ABH;
                if (flag2)
                {
                    bool flag3 = this._ABH._AEU == 0;
                    if (flag3)
                    {
                        num--;
                    }
                }
                else
                {
                    bool flag4 = this._ATW()._AEU == 0;
                    if (flag4)
                    {
                        num--;
                    }
                }
            }
            GCE._AFA _ATD = ((this._ATW() != null) ? ((this._ABH < this._ATW()) ? this._ABH.Clone() : this._ATW().Clone()) : this._ABH.Clone());
            _ATD._ATG = 0;
            _ATD._AEU = 0;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append(this._ABQ.FLOg[i + _ATD._ABI]).Append('\n');
            }
            this._ABQ.InsertText(_ATD, stringBuilder.ToString());
            bool flag5 = this._ATW() != null;
            if (flag5)
            {
                this._ATW()._ABI += num;
            }
            this._ABH._ABI += num;
            this._ABQ.UpdateHighlighting(_ATD._ABI, _ATD._ABI + num - 1, false);
        }

        // Token: 0x060002B2 RID: 690 RVA: 0x0002A8BC File Offset: 0x00028ABC
        private void OpenAtCursor()
        {
            bool flag = this._ALW();
            if (flag)
            {
                switch (EditorUtility.DisplayDialogComplex("Super Editor", AssetDatabase.GUIDToAssetPath(this._ABQ._AMZ) + "\n\nThis file has been modified.\nDo you want to save the changes before opening it in the external IDE?", "Save", "Cancel", "Open"))
                {
                    case 0:
                        this.SaveBuffer();
                        break;
                    case 1:
                        return;
                }
            }
            _bb6._AKL = true;
            AssetDatabase.OpenAsset(AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(this._ABQ._AMZ), typeof(Object)), this._ABH._ABI + 1);
        }

        // Token: 0x060002B3 RID: 691 RVA: 0x0002A968 File Offset: 0x00028B68
        public string GetSearchTextFromSelection()
        {
            bool flag = this._ATW() != null && this._ATW()._ABI == this._ABH._ABI;
            string text2;
            if (flag)
            {
                bool flag2 = this._ABH > this._ATW();
                string text;
                if (flag2)
                {
                    text = this._ABQ.FLOg[this._ABH._ABI].Substring(this._ATW()._AEU, this._ABH._AEU - this._ATW()._AEU);
                }
                else
                {
                    text = this._ABQ.FLOg[this._ABH._ABI].Substring(this._ABH._AEU, this._ATW()._AEU - this._ABH._AEU);
                }
                text2 = text;
            }
            else
            {
                int num;
                int num2;
                bool flag3 = !this._ABQ.GetWordExtents(this._ABH._AEU, this._ABH._ABI, out num, out num2);
                if (flag3)
                {
                    text2 = "";
                }
                else
                {
                    string text3 = this._ABQ.FLOg[this._ABH._ABI];
                    string text = text3.Substring(num, num2 - num);
                    bool flag4 = text.Trim() == "";
                    if (flag4)
                    {
                        text2 = "";
                    }
                    else
                    {
                        bool flag5 = num > 0 && this._ABH._AEU == num && text3[num] != '_' && !char.IsLetterOrDigit(text3, num) && (text3[num] == '_' || char.IsLetterOrDigit(text3, num - 1));
                        if (flag5)
                        {
                            bool wordExtents = this._ABQ.GetWordExtents(this._ABH._AEU - 1, this._ABH._ABI, out num, out num2);
                            if (wordExtents)
                            {
                                return text3.Substring(num, num2 - num);
                            }
                        }
                        text2 = text;
                    }
                }
            }
            return text2;
        }

        // Token: 0x060002B4 RID: 692 RVA: 0x0002AB64 File Offset: 0x00028D64
        private bool ExpandSnippet(_be5 completion)
        {
            bool flag = !this._ABQ._ASC;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                int num;
                int num2;
                bool flag3;
                SyntaxToken tokenAt = this._ABQ.GetTokenAt(this._ABH, out num, out num2, out flag3);
                bool flag4 = tokenAt != null;
                if (flag4)
                {
                    TextSpan tokenSpan = this._ABQ.GetTokenSpan(num, num2);
                    string text = this._ABQ.FLOg[num].Substring(tokenSpan.index, this._ABH._AEU - tokenSpan.index);
                    string text2 = ((completion != null) ? completion.Expand() : null);
                    text2 = text2 ?? _ba6.Get(text, this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP, null);
                    bool flag5 = completion != null;
                    if (flag5)
                    {
                        string text3 = completion.ToString();
                        text3 = text3.Substring(0, text3.Length - 3).Substring(8);
                        string text4 = _ba6.Get(text3, this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP, null);
                        string[] array = text3.Split(new char[] { ' ' });
                        int length = array[array.Length - 1].Length;
                        bool flag6 = text4 != null;
                        if (flag6)
                        {
                            text2 = text4;
                            text = text3;
                            tokenSpan.index = tokenSpan.index + length - text3.Length;
                            tokenSpan.indexOffset = text3.Length;
                        }
                    }
                    bool flag7 = text2 != null;
                    if (flag7)
                    {
                        this._ABQ.BeginEdit("Expand Snippet");
                        string text5 = "\n" + this._ABQ.FLOg[num].Substring(0, this._ABQ.FirstNonWhitespace(num));
                        string[] array2 = text2.Split(new char[] { '\n' });
                        string text6 = string.Join(text5, array2);
                        GCE._AFA _ATD = this._ABH.Clone();
                        _ATD._AEU = tokenSpan.index;
                        _ATD._ATG -= text.Length;
                        _ATD._ATF -= text.Length;
                        this._ABH = this._ABQ.DeleteText(_ATD, this._ABH);
                        int num3 = text6.IndexOf("$end$");
                        bool flag8 = num3 < 0;
                        if (flag8)
                        {
                            num3 = text6.Length;
                        }
                        string text7 = text6.Substring(0, num3);
                        _ba6.Substitute(ref text7, this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP);
                        this._ABH = this._ABQ.InsertText(this._ABH, text7);
                        bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                        if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                        {
                            this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                        }
                        bool flag9 = num3 < text6.Length;
                        if (flag9)
                        {
                            text7 = text6.Substring(num3 + 5);
                            _ba6.Substitute(ref text7, this.EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP);
                            this._ABQ.InsertText(this._ABH, text7);
                        }
                        this._ABQ.UpdateHighlighting(num, num + text2.Count((char x) => x == '\n'), false);
                        this._ABQ.EndEdit();
                        return true;
                    }
                }
                flag2 = false;
            }
            return flag2;
        }

        // Token: 0x060002B5 RID: 693 RVA: 0x0002AEB0 File Offset: 0x000290B0
        private void IndentMoreOrInsertTab(bool expandSnippets)
        {
            bool flag = !this.TryEdit();
            if (!flag)
            {
                bool flag2 = this._ATW() != null;
                if (flag2)
                {
                    this.IndentMore();
                }
                else
                {
                    bool flag3 = expandSnippets && this.ExpandSnippet(null);
                    if (!flag3)
                    {
                        this._ABQ.BeginEdit("Insert Tab");
                        int num = 0;
                        while ((this._ABH._ATG - num) % _bg8._ASA > 0)
                        {
                            int num2 = this._ABH._AEU - num - 1;
                            bool flag4 = num2 >= 0 && this._ABQ.FLOg[this._ABH._ABI][num2] == ' ';
                            if (!flag4)
                            {
                                break;
                            }
                            num++;
                        }
                        bool flag5 = num > 0;
                        if (flag5)
                        {
                            GCE._AFA _ATD = this._ABH.Clone();
                            _ATD._AEU -= num;
                            _ATD._ATG -= num;
                            _ATD._ATF -= num;
                            this._ABH = this._ABQ.DeleteText(_ATD, this._ABH);
                        }
                        this._ABH = this._ABQ.InsertText(this._ABH, "\t");
                        bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                        if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                        {
                            this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                        }
                        this._ABQ.UpdateHighlighting(this._ABH._ABI, this._ABH._ABI, false);
                        this._ABQ.EndEdit();
                    }
                }
            }
        }

        // Token: 0x060002B6 RID: 694 RVA: 0x0002B078 File Offset: 0x00029278
        private void IndentMore()
        {
            bool flag = !this.TryEdit();
            if (!flag)
            {
                this._ABQ.BeginEdit("Increase Indent");
                bool flag2 = this._ATW() != null;
                bool flag3 = !flag2;
                if (flag3)
                {
                    this._ATL(this._ABH.Clone());
                }
                GCE._AFA _ATD = this._ABH.Clone();
                GCE._AFA _ATD2 = this._ABH.Clone();
                int num = this._ABH._ABI;
                int num2 = this._ABH._ABI;
                bool flag4 = this._ABH < this._ATW();
                if (flag4)
                {
                    _ATD2 = this._ATW().Clone();
                    num2 = _ATD2._ABI;
                }
                else
                {
                    _ATD = this._ATW().Clone();
                    num = _ATD._ABI;
                }
                bool flag5 = _ATD2._AEU == 0 && num < num2;
                if (flag5)
                {
                    num2--;
                }
                bool flag6 = _ATD._AEU > 0;
                bool flag7 = _ATD2._ABI == num2 && _ATD2._AEU > 0;
                GCE._AFA _ATD3 = new GCE._AFA
                {
                    _AEU = 0,
                    _ATG = 0,
                    _ABI = num,
                    _ATF = 0
                };
                while (_ATD3._ABI <= num2)
                {
                    GCE._AFA _ATD4 = this._ABQ.InsertText(_ATD3, "\t");
                    bool flag8 = flag6 && _ATD3._ABI == num;
                    if (flag8)
                    {
                        _ATD._AEU += _ATD4._AEU;
                    }
                    bool flag9 = flag7 && _ATD3._ABI == num2;
                    if (flag9)
                    {
                        _ATD2._AEU += _ATD4._AEU;
                    }
                    _ATD3._ABI++;
                }
                this._ABQ.UpdateHighlighting(num, num2, false);
                _ATD._ATG = (_ATD._ATF = this._ABQ.CharIndexToColumn(_ATD._AEU, _ATD._ABI));
                _ATD2._ATG = (_ATD2._ATF = this._ABQ.CharIndexToColumn(_ATD2._AEU, _ATD2._ABI));
                bool flag10 = this._ABH < this._ATW();
                if (flag10)
                {
                    this._ABH = _ATD.Clone();
                    this._ATL(_ATD2.Clone());
                }
                else
                {
                    this._ATL(_ATD.Clone());
                    this._ABH = _ATD2.Clone();
                }
                bool flag11 = !flag2;
                if (flag11)
                {
                    this._ATL(null);
                }
                bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                {
                    this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                    bool flag12 = this._ATW() != null;
                    if (flag12)
                    {
                        this._ATW()._ATG = (this._ATW()._ATF = this.CharIndexToColumn(this._ATW()._AEU, this._ATW()._ABI));
                    }
                }
                this._ABQ.EndEdit();
            }
        }

        // Token: 0x060002B7 RID: 695 RVA: 0x0002B3A0 File Offset: 0x000295A0
        private void IndentLess()
        {
            bool flag = !this.TryEdit();
            if (!flag)
            {
                this._ABQ.BeginEdit("Decrease Indent");
                bool flag2 = this._ATW() != null;
                bool flag3 = !flag2;
                if (flag3)
                {
                    this._ATL(this._ABH.Clone());
                }
                GCE._AFA _ATD = this._ABH.Clone();
                GCE._AFA _ATD2 = this._ABH.Clone();
                int num = this._ABH._ABI;
                int num2 = this._ABH._ABI;
                bool flag4 = this._ABH < this._ATW();
                if (flag4)
                {
                    _ATD2 = this._ATW().Clone();
                    num2 = _ATD2._ABI;
                }
                else
                {
                    _ATD = this._ATW().Clone();
                    num = _ATD._ABI;
                }
                bool flag5 = _ATD2._AEU == 0 && num < num2;
                if (flag5)
                {
                    num2--;
                }
                bool flag6 = _ATD._AEU > 0;
                bool flag7 = _ATD2._AEU > 0;
                GCE._AFA _ATD3 = new GCE._AFA
                {
                    _AEU = 0,
                    _ATG = 0,
                    _ABI = num,
                    _ATF = 0
                };
                while (_ATD3._ABI <= num2)
                {
                    GCE._AFA _ATD4 = _ATD3.Clone();
                    string text = this._ABQ.FLOg[_ATD3._ABI];
                    while (_ATD4._AEU < text.Length && GCE.GetCharClass(text[_ATD4._AEU], false, false) == 0)
                    {
                        GCE._AFA _ATD5 = _ATD4;
                        GCE._AFA _ATD6 = _ATD4;
                        GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                        GCE._AFA _ATD7 = _ATD4;
                        int num3 = _ATD7._AEU + 1;
                        _ATD7._AEU = num3;
                        _ATD5._ATG = (_ATD6._ATF = cdghkglnkfhjenlebomgbogcmlafoejmngmj.CharIndexToColumn(num3, _ATD4._ABI));
                        bool flag8 = _ATD4._ATG == _bg8._ASA;
                        if (flag8)
                        {
                            break;
                        }
                    }
                    bool flag9 = _ATD3 != _ATD4;
                    if (flag9)
                    {
                        this._ABQ.DeleteText(_ATD3, _ATD4);
                        bool flag10 = flag6 && _ATD3._ABI == num;
                        if (flag10)
                        {
                            _ATD._AEU = Mathf.Max(0, _ATD._AEU - (_ATD4._AEU - _ATD3._AEU));
                        }
                        bool flag11 = flag7 && _ATD3._ABI == num2;
                        if (flag11)
                        {
                            _ATD2._AEU = Mathf.Max(0, _ATD2._AEU - (_ATD4._AEU - _ATD3._AEU));
                        }
                    }
                    else
                    {
                        bool flag12 = _ATD3._ABI == num2;
                        if (flag12)
                        {
                            flag7 = false;
                        }
                        bool flag13 = num <= _ATD3._ABI - 1;
                        if (flag13)
                        {
                            this._ABQ.UpdateHighlighting(num, _ATD3._ABI - 1, false);
                        }
                        num = _ATD3._ABI + 1;
                        flag6 = false;
                    }
                    _ATD3._ABI++;
                }
                bool flag14 = num <= num2;
                if (flag14)
                {
                    this._ABQ.UpdateHighlighting(num, num2, false);
                }
                _ATD._ATG = (_ATD._ATF = this._ABQ.CharIndexToColumn(_ATD._AEU, _ATD._ABI));
                _ATD2._ATG = (_ATD2._ATF = this._ABQ.CharIndexToColumn(_ATD2._AEU, _ATD2._ABI));
                bool flag15 = this._ABH < this._ATW();
                if (flag15)
                {
                    this._ABH = _ATD.Clone();
                    this._ATL(_ATD2.Clone());
                }
                else
                {
                    this._ATL(_ATD.Clone());
                    this._ABH = _ATD2.Clone();
                }
                bool flag16 = !flag2;
                if (flag16)
                {
                    this._ATL(null);
                }
                bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                {
                    this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                    bool flag17 = this._ATW() != null;
                    if (flag17)
                    {
                        this._ATW()._ATG = (this._ATW()._ATF = this.CharIndexToColumn(this._ATW()._AEU, this._ATW()._ABI));
                    }
                }
                this._ABQ.EndEdit();
            }
        }

        // Token: 0x060002B8 RID: 696 RVA: 0x0002B7F8 File Offset: 0x000299F8
        internal void ShowArgumentsHint(_bb4.DHBA methodLeaf)
        {
            this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN = null;
            this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN = new TextPosition(-1, -1);
            bool flag = methodLeaf._AAB() == null;
            if (flag)
            {
                _bc9.ResolveNode(methodLeaf.OOME);
            }
            _bh4 _AAH = methodLeaf._AAB();
            bool flag2 = _AAH == null;
            if (flag2)
            {
                bool flag3 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                if (flag3)
                {
                    this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.Hide();
                }
            }
            else
            {
                bool flag4 = _AAH._AT == SymbolKind.Method || _AAH._AT == SymbolKind.MethodGroup || _AAH._AT == SymbolKind.Class || _AAH._AT == SymbolKind.Struct;
                if (flag4)
                {
                    bool flag5 = false;
                    bool flag6 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                    if (flag6)
                    {
                        flag5 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.OLLEJPDNBBODLEICOBPMPIPPIJBOBOOHEKFP();
                        this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.Hide();
                    }
                    this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB = _bk9.CreateTokenWidget(this, this.MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB, methodLeaf, false);
                    bool flag7 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;
                    if (flag7)
                    {
                        this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.BPFOKIKKJCELJLDEACHGMOGPJLKFLLDCCOLH(this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG);
                        this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN = methodLeaf._AAB();
                        this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN = new TextPosition(methodLeaf.line, methodLeaf._AJG());
                        bool flag8 = this.GetSoftLineBreaks(this._ABH._ABI) != _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                        if (flag8)
                        {
                            this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB._AEW(true);
                        }
                        else
                        {
                            bool flag9 = (flag5 && this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO == null) || methodLeaf.line < this._ABH._ABI;
                            if (flag9)
                            {
                                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB._AEW(true);
                            }
                            else
                            {
                                bool flag10 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                                if (flag10)
                                {
                                    this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._AEW(!this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.OLLEJPDNBBODLEICOBPMPIPPIJBOBOOHEKFP());
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060002B9 RID: 697 RVA: 0x0002B9C1 File Offset: 0x00029BC1
        private void FilterCompletions(HashSet<_bh4> data)
        {
            data.RemoveWhere((_bh4 x) => !this.DerivesFromOrContains(x, _bi2.FODMINEMHCODAKPMOCKCHANGHHFDPFCJONPH(), true));
        }

        // Token: 0x060002BA RID: 698 RVA: 0x0002B9D8 File Offset: 0x00029BD8
        private bool DerivesFromOrContains(_bh4 symbol, _b2 type, bool checkReferencedAssemblies)
        {
            bool flag = symbol._AT == SymbolKind.Namespace;
            if (flag)
            {
                for (int i = 0; i < symbol._AAG.Count; i++)
                {
                    _bh4 _AAH = symbol._AAG._AAI(i);
                    bool flag2 = this.DerivesFromOrContains(_AAH, type, true);
                    if (flag2)
                    {
                        return true;
                    }
                }
                if (checkReferencedAssemblies)
                {
                    _bn1 _APR = (_bn1)symbol;
                    _bj5 ilbdcihgkpfpcljfbhlgkohdpnlncpijnlfg = ((_be7)this._ABQ._AOU()._AQT()._AIT._AJW)._AN;
                    bool flag3 = ilbdcihgkpfpcljfbhlgkohdpnlncpijnlfg != null;
                    if (flag3)
                    {
                        foreach (_bj5 _AOS in ilbdcihgkpfpcljfbhlgkohdpnlncpijnlfg.KLGDDLJGIKKDDHDOECDICLMOMBNLNLCDCJDH())
                        {
                            _bn1 _APR2 = _AOS.FindSameNamespace(_APR);
                            bool flag4 = _APR2 != null;
                            if (flag4)
                            {
                                for (int k = 0; k < _APR2._AAG.Count; k++)
                                {
                                    _bh4 _AAH2 = _APR2._AAG._AAI(k);
                                    bool flag5 = this.DerivesFromOrContains(_AAH2, type, false);
                                    if (flag5)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                bool flag6 = symbol._AT == SymbolKind.Class;
                if (flag6)
                {
                    _b2 _AAC = symbol as _b2;
                    bool flag7 = _AAC.DerivesFrom(type);
                    if (flag7)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Token: 0x060002BB RID: 699 RVA: 0x0002BB40 File Offset: 0x00029D40
        public void CloseAllPopups()
        {
            bool flag = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null;
            if (flag)
            {
                this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.Hide();
            }
            bool flag2 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
            if (flag2)
            {
                this.CloseArgumentsHint();
            }
            bool flag3 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
            if (flag3)
            {
                this.CloseAutocomplete();
            }
        }

        // Token: 0x060002BC RID: 700 RVA: 0x0002BB98 File Offset: 0x00029D98
        public void CloseAutocomplete()
        {
            bool flag = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
            if (flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.Close));
                this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO = null;
            }
            _ba4._AFR = (_ba4._AFP = 0f);
        }

        // Token: 0x060002BD RID: 701 RVA: 0x0002BBF4 File Offset: 0x00029DF4
        public void CloseArgumentsHint()
        {
            bool flag = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
            if (flag)
            {
                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.Hide();
                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB = null;
                this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN = null;
                this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN = new TextPosition(-1, -1);
            }
        }

        // Token: 0x060002BE RID: 702 RVA: 0x0002BC3C File Offset: 0x00029E3C
        public void BufferToViewPosition(GCE._AFA position, out int row, out int column)
        {
            List<int> softLineBreaks = this.GetSoftLineBreaks(position._ABI);
            row = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(softLineBreaks, position._AEU);
            bool flag = row < softLineBreaks.Count && position._AEU == softLineBreaks[row] && position._ATF == 0;
            if (flag)
            {
                row++;
            }
            int num = ((row > 0) ? softLineBreaks[row - 1] : 0);
            column = this._ABQ.CharIndexToColumn(position._AEU, position._ABI, num);
        }

        // Token: 0x060002BF RID: 703 RVA: 0x0002BCC4 File Offset: 0x00029EC4
        public Vector2 BufferToViewPosition(GCE._AFA position)
        {
            List<int> softLineBreaks = this.GetSoftLineBreaks(position._ABI);
            int num = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(softLineBreaks, position._AEU);
            bool flag = num < softLineBreaks.Count && position._AEU == softLineBreaks[num] && position._ATF == 0;
            if (flag)
            {
                num++;
            }
            int num2 = ((num > 0) ? softLineBreaks[num - 1] : 0);
            float charXOffset = this.GetCharXOffset(position._AEU, position._ABI, num2);
            return new Vector2(charXOffset, this._AEY().y * (float)num);
        }

        // Token: 0x060002C0 RID: 704 RVA: 0x0002BD5C File Offset: 0x00029F5C
        public Vector2 BufferToViewPosition(int line, int charIndex, bool newLine)
        {
            List<int> softLineBreaks = this.GetSoftLineBreaks(line);
            int num = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(softLineBreaks, charIndex);
            bool flag = num < softLineBreaks.Count && charIndex == softLineBreaks[num] && newLine;
            if (flag)
            {
                num++;
            }
            int num2 = ((num > 0) ? softLineBreaks[num - 1] : 0);
            float charXOffset = this.GetCharXOffset(charIndex, line, num2);
            return new Vector2(charXOffset, this._AEY().y * (float)num);
        }

        // Token: 0x060002C1 RID: 705 RVA: 0x0002BDD4 File Offset: 0x00029FD4
        public float GetCharXOffset(int charIndex, int line, int start)
        {
            List<string> flogicchcfaljohninkpcdacoidcghkimhpo = this._ABQ.FLOg;
            bool flag = line >= flogicchcfaljohninkpcdacoidcghkimhpo.Count;
            float num;
            if (flag)
            {
                num = 0f;
            }
            else
            {
                string text = flogicchcfaljohninkpcdacoidcghkimhpo[line];
                bool flag2 = text.Length < charIndex;
                if (flag2)
                {
                    charIndex = text.Length;
                }
                float num2 = (float)_bg8._ASA * this._AEY().x;
                float num3 = 0f;
                for (int i = start; i < charIndex; i++)
                {
                    char c = text[i];
                    bool flag3 = c == ' ';
                    if (flag3)
                    {
                        num3 += this._AEY().x;
                    }
                    else
                    {
                        bool flag4 = c == '\t';
                        if (flag4)
                        {
                            num3 += num2 - num3 % num2;
                        }
                        else
                        {
                            bool flag5 = c < '\u007f';
                            if (flag5)
                            {
                                num3 += this._AEY().x;
                            }
                            else
                            {
                                int j;
                                for (j = i + 1; j < charIndex; j++)
                                {
                                    bool flag6 = text[j] < '\u007f';
                                    if (flag6)
                                    {
                                        break;
                                    }
                                }
                                _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = text.Substring(i, j - i);
                                num3 += this._ABT._ABV.CalcSize(_bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM).x;
                                i = j - 1;
                            }
                        }
                    }
                }
                num = num3;
            }
            return num;
        }

        // Token: 0x060002C2 RID: 706 RVA: 0x0002BF38 File Offset: 0x0002A138
        public float GetCharAt(float x, float y, int line)
        {
            string text = this._ABQ.FLOg[line];
            List<int> softLineBreaks = this.GetSoftLineBreaks(line);
            int count = softLineBreaks.Count;
            int num = Mathf.Clamp((int)((y - this.GetLineOffset(line)) / this._AEY().y), 0, count);
            int num2 = ((num > 0) ? softLineBreaks[num - 1] : 0);
            int num3 = ((num == count) ? text.Length : softLineBreaks[num]);
            float num4 = (float)_bg8._ASA * this._AEY().x;
            float num5 = 0f;
            for (int i = num2; i < num3; i++)
            {
                char c = text[i];
                bool flag = c == '\t';
                float num6;
                if (flag)
                {
                    num6 = num4 - num5 % num4;
                }
                else
                {
                    bool flag2 = c < '\u007f';
                    if (flag2)
                    {
                        num6 = this._AEY().x;
                    }
                    else
                    {
                        _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = text[i].ToString();
                        num6 = this._ABT._ABV.CalcSize(_bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM).x;
                    }
                }
                bool flag3 = x <= num6;
                if (flag3)
                {
                    return (float)i + x / num6;
                }
                x -= num6;
                num5 += num6;
            }
            return (float)num3;
        }

        // Token: 0x060002C3 RID: 707 RVA: 0x0002C094 File Offset: 0x0002A294
        public GCE._AFA ViewToBufferPosition(int line, int row, int column)
        {
            bool flag = line >= this._ABQ._AQQ.Length;
            if (flag)
            {
                line = this._ABQ._AQQ.Length - 1;
            }
            bool flag2 = line < 0;
            if (flag2)
            {
                line = 0;
            }
            bool flag3 = row < 0;
            if (flag3)
            {
                row = 0;
            }
            GCE._AFA _ATD = new GCE._AFA
            {
                _ATG = column,
                _ABI = line,
                _ATF = column
            };
            List<int> softLineBreaks = this.GetSoftLineBreaks(line);
            bool flag4 = row > softLineBreaks.Count;
            if (flag4)
            {
                row = softLineBreaks.Count;
            }
            int num = ((row > 0) ? softLineBreaks[row - 1] : 0);
            _ATD._AEU = this._ABQ.ColumnToCharIndex(ref _ATD._ATG, line, num);
            int num2 = ((row < softLineBreaks.Count) ? softLineBreaks[row] : this._ABQ.FLOg[line].Length);
            bool flag5 = _ATD._AEU > num2;
            if (flag5)
            {
                _ATD._AEU = num2;
            }
            return _ATD;
        }

        // Token: 0x060002C4 RID: 708 RVA: 0x0002C190 File Offset: 0x0002A390
        public GCE._AFA GetLinesOffset(GCE._AFA position, int linesDown)
        {
            GCE._AFA _ATD = position.Clone();
            bool flag = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
            if (flag)
            {
                _ATD._ABI += linesDown;
                bool flag2 = _ATD._ABI < 0;
                if (flag2)
                {
                    _ATD._ABI = 0;
                    _ATD._AEU = 0;
                    _ATD._ATG = 0;
                    _ATD._ATF = 0;
                }
                else
                {
                    bool flag3 = _ATD._ABI >= this._ABQ.FLOg.Count;
                    if (flag3)
                    {
                        _ATD._ABI = this._ABQ.FLOg.Count - 1;
                        _ATD._AEU = this._ABQ.FLOg[_ATD._ABI].Length;
                        _ATD._ATG = this._ABQ.CharIndexToColumn(_ATD._AEU, _ATD._ABI);
                        _ATD._ATF = _ATD._ATG;
                    }
                    else
                    {
                        bool flag4 = _ATD._ABI != position._ABI;
                        if (flag4)
                        {
                            _ATD._ATG = _ATD._ATF;
                        }
                        _ATD._AEU = this._ABQ.ColumnToCharIndex(ref _ATD._ATG, _ATD._ABI);
                    }
                }
            }
            else
            {
                List<int> list = this.GetSoftLineBreaks(_ATD._ABI);
                int num = list.Count + 1;
                int num2 = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(list, _ATD._AEU);
                bool flag5 = num2 < list.Count && _ATD._AEU == list[num2] && _ATD._ATF == 0;
                if (flag5)
                {
                    num2++;
                }
                while (linesDown > 0)
                {
                    linesDown--;
                    bool flag6 = num2 < num - 1;
                    if (flag6)
                    {
                        num2++;
                    }
                    else
                    {
                        bool flag7 = _ATD._ABI == this._ABQ.FLOg.Count - 1;
                        if (flag7)
                        {
                            int num3 = ((num2 > 0) ? list[num2 - 1] : 0);
                            _ATD._ATF = ((num2 < list.Count) ? list[num2] : this._ABQ.CharIndexToColumn(this._ABQ.FLOg[_ATD._ABI].Length, _ATD._ABI, num3));
                            break;
                        }
                        _ATD._ABI++;
                        num2 = 0;
                        list = this.GetSoftLineBreaks(_ATD._ABI);
                        num = list.Count + 1;
                    }
                }
                while (linesDown < 0)
                {
                    linesDown++;
                    bool flag8 = num2 > 0;
                    if (flag8)
                    {
                        num2--;
                    }
                    else
                    {
                        bool flag9 = _ATD._ABI == 0;
                        if (flag9)
                        {
                            _ATD._ATF = 0;
                            break;
                        }
                        _ATD._ABI--;
                        list = this.GetSoftLineBreaks(_ATD._ABI);
                        num = list.Count + 1;
                        num2 = num - 1;
                    }
                }
                int num4 = ((num2 > 0) ? list[num2 - 1] : 0);
                int num5 = ((num2 < list.Count) ? list[num2] : this._ABQ.FLOg[_ATD._ABI].Length);
                _ATD._ATG = _ATD._ATF;
                _ATD._AEU = this._ABQ.ColumnToCharIndex(ref _ATD._ATG, _ATD._ABI, num4);
                bool flag10 = _ATD._AEU > num5;
                if (flag10)
                {
                    _ATD._AEU = num5;
                    _ATD._ATG = this._ABQ.CharIndexToColumn(_ATD._AEU, _ATD._ABI, num4);
                }
            }
            return _ATD;
        }

        // Token: 0x060002C5 RID: 709 RVA: 0x0002C524 File Offset: 0x0002A724
        public SyntaxToken GetTokenAtCursor()
        {
            int num;
            int num2;
            return this.GetTokenAtCursor(out num, out num2);
        }

        // Token: 0x060002C6 RID: 710 RVA: 0x0002C540 File Offset: 0x0002A740
        public SyntaxToken GetTokenAtCursor(out int lineIndex, out int tokenIndex)
        {
            bool flag = this._ABQ == null;
            SyntaxToken syntaxToken;
            if (flag)
            {
                lineIndex = -1;
                tokenIndex = -1;
                syntaxToken = null;
            }
            else
            {
                bool flag2;
                SyntaxToken syntaxToken2 = this._ABQ.GetTokenAt(this._ABH, out lineIndex, out tokenIndex, out flag2);
                bool flag3 = syntaxToken2 != null;
                if (flag3)
                {
                    bool flag4 = flag2 && (syntaxToken2.tokenKind == SyntaxToken.Kind.Whitespace || (syntaxToken2.tokenKind != SyntaxToken.Kind.Identifier && syntaxToken2.tokenKind != SyntaxToken.Kind.BuiltInLiteral && syntaxToken2.tokenKind != SyntaxToken.Kind.ContextualKeyword && syntaxToken2.tokenKind != SyntaxToken.Kind.Keyword && syntaxToken2.tokenKind != SyntaxToken.Kind.Preprocessor && syntaxToken2.tokenKind != SyntaxToken.Kind.PreprocessorSymbol));
                    if (flag4)
                    {
                        List<SyntaxToken> _ABS = this._ABQ._AQQ[lineIndex].EOIA;
                        bool flag5 = tokenIndex < _ABS.Count - 1;
                        if (flag5)
                        {
                            syntaxToken2 = _ABS[tokenIndex + 1];
                        }
                    }
                }
                syntaxToken = syntaxToken2;
            }
            return syntaxToken;
        }

        // Token: 0x060002C7 RID: 711 RVA: 0x0002C624 File Offset: 0x0002A824
        private SyntaxToken GetTokenAtPosition(int line, int characterIndex)
        {
            int num;
            int num2;
            bool flag;
            return this._ABQ.GetTokenAt(new TextPosition(line, characterIndex), out num, out num2, out flag);
        }

        // Token: 0x060002C8 RID: 712 RVA: 0x0002C654 File Offset: 0x0002A854
        private string HelpURL()
        {
            SyntaxToken tokenAtCursor = this.GetTokenAtCursor();
            bool flag = (tokenAtCursor.tokenKind == SyntaxToken.Kind.Identifier || (tokenAtCursor.tokenKind == SyntaxToken.Kind.Keyword && this._ABQ._AOU().IsBuiltInType(tokenAtCursor.text))) && tokenAtCursor.OOME != null && tokenAtCursor.OOME._AAB() == null;
            if (flag)
            {
                _bc9.ResolveNode(tokenAtCursor.OOME.OOME);
            }
            string text = null;
            string text2 = null;
            bool flag2 = tokenAtCursor.tokenKind == SyntaxToken.Kind.Keyword || tokenAtCursor.tokenKind == SyntaxToken.Kind.ContextualKeyword;
            if (flag2)
            {
                string text3 = tokenAtCursor.text;
                string text4 = text3;
                uint num = Helper.ComputeStringHash(text4);
                if (num <= 2317739966U)
                {
                    if (num <= 1410115415U)
                    {
                        if (num <= 894604266U)
                        {
                            if (num <= 508850813U)
                            {
                                if (num <= 231090382U)
                                {
                                    if (num != 90969176U)
                                    {
                                        if (num != 231090382U)
                                        {
                                            goto IL_1208;
                                        }
                                        if (!(text4 == "while"))
                                        {
                                            goto IL_1208;
                                        }
                                        text = "2aeyhxcd";
                                        goto IL_1208;
                                    }
                                    else
                                    {
                                        if (!(text4 == "where"))
                                        {
                                            goto IL_1208;
                                        }
                                        text2 = ((tokenAtCursor.OOME.OOME._AHB() == "typeParameterConstraintsClause") ? "where-generic-type-constraint" : "where-clause");
                                        goto IL_1208;
                                    }
                                }
                                else if (num != 297952813U)
                                {
                                    if (num != 503252654U)
                                    {
                                        if (num != 508850813U)
                                        {
                                            goto IL_1208;
                                        }
                                        if (!(text4 == "protected"))
                                        {
                                            goto IL_1208;
                                        }
                                        text = "bcd5672a";
                                        goto IL_1208;
                                    }
                                    else
                                    {
                                        if (!(text4 == "global"))
                                        {
                                            goto IL_1208;
                                        }
                                        text2 = "global";
                                        goto IL_1208;
                                    }
                                }
                                else
                                {
                                    if (!(text4 == "select"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "select-clause";
                                    goto IL_1208;
                                }
                            }
                            else if (num <= 559900755U)
                            {
                                if (num != 554782406U)
                                {
                                    if (num != 559900755U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "params"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "w5zay9db";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "checked"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "checked";
                                    goto IL_1208;
                                }
                            }
                            else if (num != 681154065U)
                            {
                                if (num != 798074659U)
                                {
                                    if (num != 894604266U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "delegate"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "900fyy8e";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "into"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "into";
                                    goto IL_1208;
                                }
                            }
                            else
                            {
                                if (!(text4 == "new"))
                                {
                                    goto IL_1208;
                                }
                                text = "51y09td4";
                                goto IL_1208;
                            }
                        }
                        else if (num <= 1113510858U)
                        {
                            if (num <= 993596020U)
                            {
                                if (num != 959999494U)
                                {
                                    if (num != 993596020U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "add"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "add";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "if"))
                                    {
                                        goto IL_1208;
                                    }
                                    goto IL_0ECE;
                                }
                            }
                            else if (num != 1037866200U)
                            {
                                if (num != 1094220446U)
                                {
                                    if (num != 1113510858U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "value"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "value";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "in"))
                                    {
                                        goto IL_1208;
                                    }
                                    goto IL_0F26;
                                }
                            }
                            else
                            {
                                if (!(text4 == "base"))
                                {
                                    goto IL_1208;
                                }
                                text = "hfw7t1ce";
                                goto IL_1208;
                            }
                        }
                        else if (num <= 1312329493U)
                        {
                            if (num != 1116268876U)
                            {
                                if (num != 1123320834U)
                                {
                                    if (num != 1312329493U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "is"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "scekt9xw";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "ref"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "14akc2c7";
                                    goto IL_1208;
                                }
                            }
                            else if (!(text4 == "catch"))
                            {
                                goto IL_1208;
                            }
                        }
                        else if (num != 1349190650U)
                        {
                            if (num != 1362922900U)
                            {
                                if (num != 1410115415U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "get"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "get";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "equals"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "equals";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "let"))
                            {
                                goto IL_1208;
                            }
                            text2 = "let-clause";
                            goto IL_1208;
                        }
                    }
                    else if (num <= 1760006473U)
                    {
                        if (num <= 1630810064U)
                        {
                            if (num <= 1570143932U)
                            {
                                if (num != 1412156564U)
                                {
                                    if (num != 1570143932U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "virtual"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "9fkccyh4";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "by"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "by";
                                    goto IL_1208;
                                }
                            }
                            else if (num != 1579491469U)
                            {
                                if (num != 1605967500U)
                                {
                                    if (num != 1630810064U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "on"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "on";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "group"))
                                    {
                                        goto IL_1208;
                                    }
                                    text2 = "group-clause";
                                    goto IL_1208;
                                }
                            }
                            else
                            {
                                if (!(text4 == "as"))
                                {
                                    goto IL_1208;
                                }
                                text = "cscsdfbt";
                                goto IL_1208;
                            }
                        }
                        else if (num <= 1657474316U)
                        {
                            if (num != 1646057492U)
                            {
                                if (num != 1657474316U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "private"))
                                {
                                    goto IL_1208;
                                }
                                text = "st6sy9xe";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "do"))
                                {
                                    goto IL_1208;
                                }
                                text = "370s1zax";
                                goto IL_1208;
                            }
                        }
                        else if (num != 1679047863U)
                        {
                            if (num != 1716507092U)
                            {
                                if (num != 1760006473U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "explicit"))
                                {
                                    goto IL_1208;
                                }
                                text = "xhbhezf4";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "const"))
                                {
                                    goto IL_1208;
                                }
                                text = "e6w8fe1b";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "nameof"))
                            {
                                goto IL_1208;
                            }
                            text2 = "nameof";
                            goto IL_1208;
                        }
                    }
                    else if (num <= 2054714927U)
                    {
                        if (num <= 1821831854U)
                        {
                            if (num != 1775113223U)
                            {
                                if (num != 1821831854U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "yield"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "yield";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "using"))
                                {
                                    goto IL_1208;
                                }
                                text = ((tokenAtCursor.OOME.OOME._AHB() == "usingStatement") ? "yh598w02" : "sf0df423");
                                goto IL_1208;
                            }
                        }
                        else if (num != 1860254461U)
                        {
                            if (num != 1989400379U)
                            {
                                if (num != 2054714927U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "throw"))
                                {
                                    goto IL_1208;
                                }
                                text = "1ah5wsex";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "descending"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "descending";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "sizeof"))
                            {
                                goto IL_1208;
                            }
                            text = "eahchzkf";
                            goto IL_1208;
                        }
                    }
                    else if (num <= 2171383808U)
                    {
                        if (num != 2099675479U)
                        {
                            if (num != 2138539289U)
                            {
                                if (num != 2171383808U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "enum"))
                                {
                                    goto IL_1208;
                                }
                                text = "sbbt4032";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "when"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "when";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "alias"))
                            {
                                goto IL_1208;
                            }
                            text2 = "extern-alias";
                            goto IL_1208;
                        }
                    }
                    else if (num != 2229948720U)
                    {
                        if (num != 2246981567U)
                        {
                            if (num != 2317739966U)
                            {
                                goto IL_1208;
                            }
                            if (!(text4 == "var"))
                            {
                                goto IL_1208;
                            }
                            text2 = "var";
                            goto IL_1208;
                        }
                        else
                        {
                            if (!(text4 == "return"))
                            {
                                goto IL_1208;
                            }
                            text = "1h3swy84";
                            goto IL_1208;
                        }
                    }
                    else
                    {
                        if (!(text4 == "interface"))
                        {
                            goto IL_1208;
                        }
                        text = "87d83y5b";
                        goto IL_1208;
                    }
                }
                else if (num <= 3076491097U)
                {
                    if (num <= 2602907825U)
                    {
                        if (num <= 2480955249U)
                        {
                            if (num <= 2424823223U)
                            {
                                if (num != 2325638003U)
                                {
                                    if (num != 2424823223U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "extern"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "e59b22c5";
                                    goto IL_1208;
                                }
                                else
                                {
                                    if (!(text4 == "abstract"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = "sf985hc5";
                                    goto IL_1208;
                                }
                            }
                            else if (num != 2462236192U)
                            {
                                if (num != 2470140894U)
                                {
                                    if (num != 2480955249U)
                                    {
                                        goto IL_1208;
                                    }
                                    if (!(text4 == "switch"))
                                    {
                                        goto IL_1208;
                                    }
                                }
                                else
                                {
                                    if (!(text4 == "default"))
                                    {
                                        goto IL_1208;
                                    }
                                    text = ((tokenAtCursor.OOME.OOME._AHB() == "defaultValueExpression") ? "xwth0h0d" : "06tc147t");
                                    goto IL_1208;
                                }
                            }
                            else
                            {
                                if (!(text4 == "struct"))
                                {
                                    goto IL_1208;
                                }
                                text = "ah19swz4";
                                goto IL_1208;
                            }
                        }
                        else if (num <= 2513272949U)
                        {
                            if (num != 2497774445U)
                            {
                                if (num != 2513272949U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "from"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "from-clause";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "volatile"))
                                {
                                    goto IL_1208;
                                }
                                text = "x13ttww7";
                                goto IL_1208;
                            }
                        }
                        else if (num != 2591649024U)
                        {
                            if (num != 2593171616U)
                            {
                                if (num != 2602907825U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "case"))
                                {
                                    goto IL_1208;
                                }
                            }
                            else
                            {
                                if (!(text4 == "typeof"))
                                {
                                    goto IL_1208;
                                }
                                text = "58918ffs";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "internal"))
                            {
                                goto IL_1208;
                            }
                            text = "7c5ka91b";
                            goto IL_1208;
                        }
                        text = "06tc147t";
                        goto IL_1208;
                    }
                    if (num <= 2870621791U)
                    {
                        if (num <= 2696878241U)
                        {
                            if (num != 2618047400U)
                            {
                                if (num != 2696878241U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "ascending"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "ascending";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "finally"))
                                {
                                    goto IL_1208;
                                }
                                text = "zwc8s4fz";
                                goto IL_1208;
                            }
                        }
                        else if (num != 2717370895U)
                        {
                            if (num != 2819722039U)
                            {
                                if (num != 2870621791U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "out"))
                                {
                                    goto IL_1208;
                                }
                                text = "ee332485";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "unsafe"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "unsafe";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "async"))
                            {
                                goto IL_1208;
                            }
                            text2 = "async";
                            goto IL_1208;
                        }
                    }
                    else if (num <= 2901640080U)
                    {
                        if (num != 2872970239U)
                        {
                            if (num != 2887626766U)
                            {
                                if (num != 2901640080U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "for"))
                                {
                                    goto IL_1208;
                                }
                                text = "ch45axte";
                                goto IL_1208;
                            }
                            else if (!(text4 == "try"))
                            {
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "class"))
                            {
                                goto IL_1208;
                            }
                            text = "0b0thckt";
                            goto IL_1208;
                        }
                    }
                    else if (num != 2977070660U)
                    {
                        if (num != 3019201529U)
                        {
                            if (num != 3076491097U)
                            {
                                goto IL_1208;
                            }
                            if (!(text4 == "foreach"))
                            {
                                goto IL_1208;
                            }
                            goto IL_0F26;
                        }
                        else
                        {
                            if (!(text4 == "fixed"))
                            {
                                goto IL_1208;
                            }
                            text2 = "fixed-statement";
                            goto IL_1208;
                        }
                    }
                    else
                    {
                        if (!(text4 == "continue"))
                        {
                            goto IL_1208;
                        }
                        text = "923ahwt1";
                        goto IL_1208;
                    }
                }
                else if (num <= 3532702267U)
                {
                    if (num <= 3374496889U)
                    {
                        if (num <= 3300482109U)
                        {
                            if (num != 3183434736U)
                            {
                                if (num != 3300482109U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "override"))
                                {
                                    goto IL_1208;
                                }
                                text = "ebca9ah3";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "else"))
                                {
                                    goto IL_1208;
                                }
                                goto IL_0ECE;
                            }
                        }
                        else if (num != 3310188186U)
                        {
                            if (num != 3324446467U)
                            {
                                if (num != 3374496889U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "join"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "join-clause";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "set"))
                                {
                                    goto IL_1208;
                                }
                                text2 = "set";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "partial"))
                            {
                                goto IL_1208;
                            }
                            text2 = ((tokenAtCursor.OOME.OOME._AHB() == "namespaceMemberDeclaration") ? "partial-type" : "partial-method");
                            goto IL_1208;
                        }
                    }
                    else if (num <= 3402529440U)
                    {
                        if (num != 3378807160U)
                        {
                            if (num != 3386378657U)
                            {
                                if (num != 3402529440U)
                                {
                                    goto IL_1208;
                                }
                                if (!(text4 == "namespace"))
                                {
                                    goto IL_1208;
                                }
                                text = "z2kcy19k";
                                goto IL_1208;
                            }
                            else
                            {
                                if (!(text4 == "sealed"))
                                {
                                    goto IL_1208;
                                }
                                text = "88c54tsw";
                                goto IL_1208;
                            }
                        }
                        else
                        {
                            if (!(text4 == "break"))
                            {
                                goto IL_1208;
                            }
                            text = "adbctzc4";
                            goto IL_1208;
                        }
                    }
                    else if (num != 3432027008U)
                    {
                        if (num != 3456888823U)
                        {
                            if (num != 3532702267U)
                            {
                                goto IL_1208;
                            }
                            if (!(text4 == "static"))
                            {
                                goto IL_1208;
                            }
                            text = "98f28cdx";
                            goto IL_1208;
                        }
                        else
                        {
                            if (!(text4 == "readonly"))
                            {
                                goto IL_1208;
                            }
                            text = "acdd6hb7";
                            goto IL_1208;
                        }
                    }
                    else
                    {
                        if (!(text4 == "public"))
                        {
                            goto IL_1208;
                        }
                        text = "yzh058ae";
                        goto IL_1208;
                    }
                }
                else if (num <= 3826381794U)
                {
                    if (num <= 3660305025U)
                    {
                        if (num != 3651751782U)
                        {
                            if (num != 3660305025U)
                            {
                                goto IL_1208;
                            }
                            if (!(text4 == "this"))
                            {
                                goto IL_1208;
                            }
                            text = "dk1507sz";
                            goto IL_1208;
                        }
                        else
                        {
                            if (!(text4 == "implicit"))
                            {
                                goto IL_1208;
                            }
                            text = "z5z9kes2";
                            goto IL_1208;
                        }
                    }
                    else if (num != 3683784189U)
                    {
                        if (num != 3691757453U)
                        {
                            if (num != 3826381794U)
                            {
                                goto IL_1208;
                            }
                            if (!(text4 == "orderby"))
                            {
                                goto IL_1208;
                            }
                            text2 = "orderby-clause";
                            goto IL_1208;
                        }
                        else
                        {
                            if (!(text4 == "await"))
                            {
                                goto IL_1208;
                            }
                            text2 = "await";
                            goto IL_1208;
                        }
                    }
                    else
                    {
                        if (!(text4 == "remove"))
                        {
                            goto IL_1208;
                        }
                        text2 = "remove";
                        goto IL_1208;
                    }
                }
                else if (num <= 4010637378U)
                {
                    if (num != 3887508500U)
                    {
                        if (num != 3894620667U)
                        {
                            if (num != 4010637378U)
                            {
                                goto IL_1208;
                            }
                            if (!(text4 == "lock"))
                            {
                                goto IL_1208;
                            }
                            text = "c5kehkcz";
                            goto IL_1208;
                        }
                        else
                        {
                            if (!(text4 == "unchecked"))
                            {
                                goto IL_1208;
                            }
                            text2 = "unchecked";
                            goto IL_1208;
                        }
                    }
                    else
                    {
                        if (!(text4 == "stackalloc"))
                        {
                            goto IL_1208;
                        }
                        text = "cx9s2sy4";
                        goto IL_1208;
                    }
                }
                else if (num != 4121104358U)
                {
                    if (num != 4225036029U)
                    {
                        if (num != 4264611999U)
                        {
                            goto IL_1208;
                        }
                        if (!(text4 == "event"))
                        {
                            goto IL_1208;
                        }
                        text = "8627sbea";
                        goto IL_1208;
                    }
                    else
                    {
                        if (!(text4 == "operator"))
                        {
                            goto IL_1208;
                        }
                        text = "s53ehcz3";
                        goto IL_1208;
                    }
                }
                else
                {
                    if (!(text4 == "goto"))
                    {
                        goto IL_1208;
                    }
                    text = "13940fs2";
                    goto IL_1208;
                }
                text = "0yd65esw";
                goto IL_1208;
            IL_0ECE:
                text = "5011f09h";
                goto IL_1208;
            IL_0F26:
                text = "ttw7t8t6";
            IL_1208:;
            }
            bool flag3 = text != null;
            string text5;
            if (flag3)
            {
                text5 = "http://msdn.microsoft.com/library/" + text;
            }
            else
            {
                bool flag4 = text2 != null;
                if (flag4)
                {
                    text5 = "http://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/" + text2;
                }
                else
                {
                    bool flag5 = tokenAtCursor.OOME != null && tokenAtCursor.OOME._AAB() != null;
                    if (flag5)
                    {
                        _bh4 _AAH = tokenAtCursor.OOME._AAB();
                        bool flag6 = _AAH._AT == SymbolKind.Error;
                        if (flag6)
                        {
                            return "http://docs.unity3d.com/ScriptReference/30_search.html?q=" + tokenAtCursor.text;
                        }
                        _bj5 _AOS = _AAH.Assembly;
                        bool flag7 = _AOS == null && _AAH._AEI != null;
                        if (flag7)
                        {
                            _AOS = ((_be7)this._ABQ._AOU()._AQT()._AIT._AJW)._AN;
                        }
                        bool flag8 = _AOS != null;
                        if (flag8)
                        {
                            string text6 = _AOS.AssemblyName;
                            bool flag9 = text6 == "UnityEngine" || text6 == "UnityEditor" || text6.StartsWith("UnityEngine.", StringComparison.Ordinal) || text6.StartsWith("UnityEditor.", StringComparison.Ordinal);
                            if (flag9)
                            {
                                bool flag10 = _bg8._BBF || Application.internetReachability == 0;
                                if (flag10)
                                {
                                    return "file:///unity/ScriptReference/" + _AAH._BES();
                                }
                                return "http://docs.unity3d.com/ScriptReference/" + _AAH._BES() + ".html";
                            }
                            else
                            {
                                bool flag11 = text6 == "mscorlib" || text6 == "System" || text6.StartsWith("System.", StringComparison.Ordinal);
                                if (flag11)
                                {
                                    _bh4 _AAH2 = _AAH;
                                    bool flag12 = _AAH2._AT == SymbolKind.EnumMember;
                                    if (flag12)
                                    {
                                        _AAH2 = _AAH2._AO;
                                    }
                                    bool flag13 = _AAH2._AYM() == _AAH2._AQ();
                                    if (flag13)
                                    {
                                        return "http://msdn.microsoft.com/library/" + _AAH2._AYM() + "(v=vs.90)";
                                    }
                                    return "http://msdn.microsoft.com/query/dev12.query?appId=Dev12IDEF1&l=EN-US&k=k(" + _AAH2.GetGenericSymbol()._AQ() + ");k(TargetFrameworkMoniker-.NETFramework,Version%3Dv3.5);k(DevLang-csharp)";
                                }
                            }
                        }
                    }
                    text5 = null;
                }
            }
            return text5;
        }

        // Token: 0x060002C9 RID: 713 RVA: 0x0002DA9C File Offset: 0x0002BC9C
        private _bj5 GetSymbolAssembly(SyntaxToken token)
        {
            bool flag = token.tokenKind == SyntaxToken.Kind.Identifier && token.OOME != null && token.OOME._AAB() == null;
            if (flag)
            {
                _bc9.ResolveNode(token.OOME.OOME);
            }
            bool flag2 = token.OOME == null || token.OOME._AAB() == null;
            _bj5 _AOS;
            if (flag2)
            {
                _AOS = null;
            }
            else
            {
                _bh4 _AAH = token.OOME._AAB();
                _bj5 _AOS2 = _AAH.Assembly;
                bool flag3 = _AOS2 == null && _AAH._AEI != null;
                if (flag3)
                {
                    _AOS2 = ((_be7)this._ABQ._AOU()._AQT()._AIT._AJW)._AN;
                }
                _AOS = _AOS2;
            }
            return _AOS;
        }

        // Token: 0x060002CA RID: 714 RVA: 0x0002DB58 File Offset: 0x0002BD58
        private void ExecuteStaticMethod()
        {
            SyntaxToken tokenAtCursor = this.GetTokenAtCursor();
            bool flag = tokenAtCursor == null || tokenAtCursor.OOME == null;
            if (!flag)
            {
                _bh4 _AAH = tokenAtCursor.OOME._AAB();
                bool flag2 = _AAH == null || !_AAH.IsStatic || _AAH._AT != SymbolKind.Method || _AAH.GetParameters().Count != 0;
                if (!flag2)
                {
                    bool flag3 = _AAH.GetParameters() != null && _AAH.GetParameters().Count != 0;
                    if (!flag3)
                    {
                        Type runtimeType = _AAH.GetRuntimeType();
                        bool flag4 = runtimeType == null;
                        if (!flag4)
                        {
                            MethodInfo methodInfo = runtimeType.GetMethod(_AAH._AW, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                            bool flag5 = methodInfo == null;
                            if (!flag5)
                            {
                                bool flag6 = methodInfo.GetParameters().Length != 0;
                                if (!flag6)
                                {
                                    _bl4 _AIQ = _AAH as _bl4;
                                    bool flag7 = _AIQ != null;
                                    if (flag7)
                                    {
                                        KJK[] _AIR = _AIQ._AHH;
                                        bool flag8 = _AIR != null && _AIR.Length != 0;
                                        if (flag8)
                                        {
                                            Type[] array = new Type[_AIR.Length];
                                            for (int i = 0; i < _AIR.Length; i++)
                                            {
                                                _bh4 definition = _AIR[i].definition;
                                                bool flag9 = definition == null || definition._AT == SymbolKind.Error;
                                                if (flag9)
                                                {
                                                    return;
                                                }
                                                array[i] = definition.GetRuntimeType();
                                            }
                                            methodInfo = methodInfo.MakeGenericMethod(array);
                                        }
                                    }
                                    bool flag10 = !methodInfo.ContainsGenericParameters;
                                    if (flag10)
                                    {
                                        methodInfo.Invoke(null, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060002CB RID: 715 RVA: 0x0002DCF0 File Offset: 0x0002BEF0
        private void GoToDefinition()
        {
            List<FKI> symbolDeclarations = this.GetSymbolDeclarations(null);
            bool flag = symbolDeclarations == null || symbolDeclarations.Count == 0;
            if (!flag)
            {
                bool flag2 = symbolDeclarations.Count == 1;
                if (flag2)
                {
                    this.GoToSymbolDeclaration(symbolDeclarations[0]);
                }
                else
                {
                    GenericMenu genericMenu = new GenericMenu();
                    foreach (FKI _AFF in symbolDeclarations)
                    {
                        _bm6 _AQI = _AFF._AJW;
                        while (_AQI._AMJ() != null)
                        {
                            _AQI = _AQI._AMJ();
                        }
                        string text = ((_be7)_AQI)._AWJ;
                        text = AssetDatabase.AssetPathToGUID(text);
                        text = AssetDatabase.GUIDToAssetPath(text);
                        text = Path.GetFileName(text);
                        _bb4._AIN _AIO = _AFF.NameNode();
                        _bb4.DHBA _AEM = (_AIO as _bb4.DHBA) ?? (_AIO as _bb4._ACW).GetFirstLeaf();
                        bool flag3 = _AFF._AT == SymbolKind.Method;
                        if (flag3)
                        {
                            _bh4 _APX = _AFF._ACV;
                            string text2 = _AFF.Name + " (" + _APX.PrintParameters(_APX.GetParameters(), true) + ")";
                            genericMenu.AddItem(new GUIContent(text2), false, delegate (object d)
                            {
                                this.GoToSymbolDeclaration((FKI)d);
                            }, _AFF);
                        }
                        else
                        {
                            genericMenu.AddItem(new GUIContent(text + " : " + (_AEM._ACX.Line + 1).ToString()), false, delegate (object d)
                            {
                                this.GoToSymbolDeclaration((FKI)d);
                            }, _AFF);
                        }
                    }
                    SyntaxToken tokenAtCursor = this.GetTokenAtCursor();
                    Rect tokenRect = this.GetTokenRect(tokenAtCursor);
                    tokenRect.x += this._AFO.x - this._AFS.x;
                    tokenRect.y += 4f + this._AFO.y - this._AFS.y;
                    Vector2 vector = GUIUtility.ScreenToGUIPoint(new Vector2(tokenRect.x, tokenRect.y));
                    tokenRect.x += vector.x - tokenRect.x;
                    tokenRect.y += vector.y - tokenRect.y;
                    genericMenu.DropDown(tokenRect);
                }
            }
        }

        // Token: 0x060002CC RID: 716 RVA: 0x0002DF78 File Offset: 0x0002C178
        private List<FKI> GetSymbolDeclarations(SyntaxToken token = null)
        {
            bool flag = token == null;
            if (flag)
            {
                token = this.GetTokenAtCursor();
                bool flag2 = token == null;
                if (flag2)
                {
                    return null;
                }
            }
            _bj5 symbolAssembly = this.GetSymbolAssembly(token);
            bool flag3 = symbolAssembly == null;
            List<FKI> list;
            if (flag3)
            {
                list = null;
            }
            else
            {
                _bh4 _AAH = token.OOME._AAB();
                string text = symbolAssembly.AssemblyName;
                bool flag4 = text == "mscorlib" || text == "System" || text.StartsWith("System.", StringComparison.Ordinal);
                if (flag4)
                {
                    string text2 = _AAH._BEX();
                    bool flag5 = text2 != null;
                    if (flag5)
                    {
                        MD5 md = MD5.Create();
                        byte[] bytes = Encoding.UTF8.GetBytes(text2);
                        byte[] array = md.ComputeHash(bytes);
                        char[] array2 = new char[16];
                        for (int i = 0; i < 8; i++)
                        {
                            byte b = (byte)(array[i] >> 4);
                            array2[i * 2] = (char)((b > 9) ? (b + 87) : (b + 48));
                            b = array[i] & 15;
                            array2[i * 2 + 1] = (char)((b > 9) ? (b + 87) : (b + 48));
                        }
                        Help.BrowseURL("http://referencesource.microsoft.com/mscorlib/a.html#" + new string(array2));
                        return null;
                    }
                }
                bool flag6 = !symbolAssembly.PPFHKDOLLCGGPJAFEKHMNABKNMLONAJANCLJ;
                if (flag6)
                {
                    list = null;
                }
                else
                {
                    List<FKI> list2 = _AAH._AEI;
                    bool flag7 = list2 == null || list2.Count == 0;
                    if (flag7)
                    {
                        list2 = _bh6.FindDeclarations(_AAH);
                        bool flag8 = list2 == null || list2.Count == 0;
                        if (flag8)
                        {
                            token.OOME._ACY(null);
                            _bc9.ResolveNode(token.OOME.OOME);
                            _AAH = token.OOME._AAB();
                            bool flag9 = _AAH != null;
                            if (flag9)
                            {
                                list2 = _AAH._AEI;
                            }
                        }
                    }
                    bool flag10 = _AAH._AT == SymbolKind.MethodGroup;
                    if (flag10)
                    {
                        list2 = new List<FKI>();
                        _ba7 _AAK = _AAH as _ba7;
                        bool flag11 = _AAK == null;
                        if (flag11)
                        {
                            _bm7 _BFS = _AAH as _bm7;
                            bool flag12 = _BFS != null;
                            if (flag12)
                            {
                                _AAK = _BFS.MAPALBBIIIJIGCOOHOOIFPIBFPLDBDGNCBOI() as _ba7;
                            }
                        }
                        foreach (_bb3 _AAN in _AAK._AAM)
                        {
                            List<FKI> jdlafinmknbedpejmjahhodcpgnkklelobcd = _AAN._AEI;
                            bool flag13 = jdlafinmknbedpejmjahhodcpgnkklelobcd != null;
                            if (flag13)
                            {
                                list2.AddRange(jdlafinmknbedpejmjahhodcpgnkklelobcd);
                            }
                        }
                    }
                    List<FKI> list3 = new List<FKI>();
                    bool flag14 = list2 != null && list2.Count > 0;
                    if (flag14)
                    {
                        foreach (FKI _AFF in list2)
                        {
                            bool flag15 = this.IsValidSymbolDeclaration(_AFF);
                            if (flag15)
                            {
                                list3.Add(_AFF);
                            }
                        }
                    }
                    list = ((list3 != null && list3.Count > 0) ? list3 : null);
                }
            }
            return list;
        }

        // Token: 0x060002CD RID: 717 RVA: 0x0002E2A0 File Offset: 0x0002C4A0
        private string CheckAutoClose(char typedChar)
        {
            string text = null;
            SyntaxToken tokenAtPosition = this.GetTokenAtPosition(this._ABH._ABI, this._ABH._AEU);
            bool flag = tokenAtPosition == null || (tokenAtPosition.tokenKind != SyntaxToken.Kind.Comment && tokenAtPosition.tokenKind != SyntaxToken.Kind.CharLiteral && tokenAtPosition.tokenKind != SyntaxToken.Kind.StringLiteral && tokenAtPosition.tokenKind != SyntaxToken.Kind.VerbatimStringBegin && tokenAtPosition.tokenKind != SyntaxToken.Kind.VerbatimStringLiteral);
            if (flag)
            {
                bool flag2 = typedChar == '{';
                if (flag2)
                {
                    text = this.TryAutoClose("}");
                }
                else
                {
                    bool flag3 = typedChar == '[';
                    if (flag3)
                    {
                        text = this.TryAutoClose("]");
                    }
                    else
                    {
                        bool flag4 = typedChar == '(';
                        if (flag4)
                        {
                            text = this.TryAutoClose(")");
                        }
                        else
                        {
                            bool flag5 = typedChar == '"';
                            if (flag5)
                            {
                                text = this.TryAutoClose("\"");
                            }
                            else
                            {
                                bool flag6 = tokenAtPosition == null || (tokenAtPosition.tokenKind != SyntaxToken.Kind.InterpolatedStringWholeLiteral && tokenAtPosition.tokenKind != SyntaxToken.Kind.InterpolatedStringStartLiteral && tokenAtPosition.tokenKind != SyntaxToken.Kind.InterpolatedStringMidLiteral && tokenAtPosition.tokenKind != SyntaxToken.Kind.InterpolatedStringEndLiteral);
                                if (flag6)
                                {
                                    bool flag7 = typedChar == '[';
                                    if (flag7)
                                    {
                                        text = this.TryAutoClose("]");
                                    }
                                    else
                                    {
                                        bool flag8 = typedChar == '(';
                                        if (flag8)
                                        {
                                            text = this.TryAutoClose(")");
                                        }
                                        else
                                        {
                                            bool flag9 = typedChar == '<';
                                            if (flag9)
                                            {
                                                bool flag10 = tokenAtPosition != null && tokenAtPosition.OOME != null;
                                                if (flag10)
                                                {
                                                    _bh4 _AAH = tokenAtPosition.OOME._AAB();
                                                    bool flag11 = _AAH != null;
                                                    if (flag11)
                                                    {
                                                        bool flag12 = _AAH is _b2 || _AAH._AT == SymbolKind.Method || _AAH._AT == SymbolKind.MethodGroup;
                                                        if (flag12)
                                                        {
                                                            text = this.TryAutoClose(">");
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
            return text;
        }

        // Token: 0x060002CE RID: 718 RVA: 0x0002E47C File Offset: 0x0002C67C
        private string GetXMLDocsText(int line)
        {
            bool flag = line >= this._ABQ.FLOg.Count;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                GCE.PHFG _AUB = ((line > 0) ? this._ABQ._AQQ[line - 1] : null);
                bool flag2 = _AUB != null && _AUB._ACO > (GCE._ACP)0;
                if (flag2)
                {
                    text = null;
                }
                else
                {
                    _AUB = this._ABQ._AQQ[line];
                    bool flag3 = _AUB.EOIA.Count < 2 || _AUB.EOIA.Count > 3;
                    if (flag3)
                    {
                        text = null;
                    }
                    else
                    {
                        bool flag4 = _AUB.EOIA.Count == 3 && _AUB.EOIA[0].tokenKind != SyntaxToken.Kind.Whitespace;
                        if (flag4)
                        {
                            text = null;
                        }
                        else
                        {
                            SyntaxToken syntaxToken = _AUB.EOIA[_AUB.EOIA.Count - 2];
                            bool flag5 = syntaxToken.tokenKind != SyntaxToken.Kind.Comment || syntaxToken.text != "//";
                            if (flag5)
                            {
                                text = null;
                            }
                            else
                            {
                                syntaxToken = _AUB.EOIA[_AUB.EOIA.Count - 1];
                                bool flag6 = !syntaxToken.text.StartsWith("/", StringComparison.Ordinal);
                                if (flag6)
                                {
                                    text = null;
                                }
                                else
                                {
                                    bool flag7 = syntaxToken.text.StartsWith("//", StringComparison.Ordinal);
                                    if (flag7)
                                    {
                                        text = null;
                                    }
                                    else
                                    {
                                        text = syntaxToken.text.Substring(1);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return text;
        }

        // Token: 0x060002CF RID: 719 RVA: 0x0002E5F0 File Offset: 0x0002C7F0
        private void AfterCharecterTyped(string text, int nextCaretLine, int nextCharacterIndex)
        {
            bool flag = false;
            bool flag2 = text.Length == 1 && this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO == null;
            if (flag2)
            {
                SyntaxToken syntaxToken = this.GetTokenAtPosition(nextCaretLine, nextCharacterIndex);
                bool flag3 = syntaxToken != null && syntaxToken.tokenKind == SyntaxToken.Kind.Whitespace && syntaxToken.TokenIndex > 0;
                if (flag3)
                {
                    List<SyntaxToken> _ABS = this._ABQ._AQQ[syntaxToken.Line].EOIA;
                    syntaxToken = _ABS[syntaxToken.TokenIndex - 1];
                    int num = 1;
                    while (syntaxToken != null && syntaxToken.TokenIndex > 0 && (syntaxToken.tokenKind == SyntaxToken.Kind.Missing || syntaxToken.tokenKind == SyntaxToken.Kind.Whitespace))
                    {
                        num++;
                        syntaxToken = this._ABQ._AQQ[syntaxToken.Line].EOIA[syntaxToken.TokenIndex - 1];
                    }
                    bool flag4 = syntaxToken != null && syntaxToken.OOME != null && syntaxToken.OOME._AJB == null;
                    if (flag4)
                    {
                        string text2 = syntaxToken.text;
                        char c = text2[text2.Length - 1];
                        bool flag5 = c == '=' || text2 == ">" || text2 == "<" || text2 == "~" || text2 == "|" || text2 == "&" || text2 == "(" || text2 == "," || text2 == "case" || text2 == "new" || (text2 == "override" && syntaxToken.tokenKind == SyntaxToken.Kind.Keyword && syntaxToken.TokenIndex == _ABS.Count - num - 1);
                        if (flag5)
                        {
                            flag = true;
                            this.LLJFBDFABMBMPEBEDAKOJBDMGGFBOJEKCPKD = true;
                        }
                    }
                }
                else
                {
                    bool flag6 = syntaxToken != null && syntaxToken.tokenKind == SyntaxToken.Kind.Punctuator && syntaxToken.text == "~";
                    if (flag6)
                    {
                        flag = true;
                        this.LLJFBDFABMBMPEBEDAKOJBDMGGFBOJEKCPKD = true;
                    }
                    else
                    {
                        bool flag7 = syntaxToken != null && syntaxToken.OOME != null && syntaxToken.OOME._AJB == null;
                        if (flag7)
                        {
                            bool flag8 = syntaxToken.tokenKind == SyntaxToken.Kind.Punctuator;
                            if (flag8)
                            {
                                bool flag9 = text == "." || text == "?.";
                                if (flag9)
                                {
                                    flag = true;
                                    string text3 = this._ABQ.FLOg[nextCaretLine];
                                    bool flag10 = nextCharacterIndex > 1 && char.IsDigit(text3, nextCharacterIndex - 2);
                                    if (flag10)
                                    {
                                        flag = false;
                                        for (int i = nextCharacterIndex - 3; i >= 0; i--)
                                        {
                                            bool flag11 = !char.IsDigit(text3, i);
                                            if (flag11)
                                            {
                                                char c2 = text3[i];
                                                flag = c2 == '.' || c2 == '_' || char.IsLetter(c2);
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bool flag12 = text == ":";
                                    if (flag12)
                                    {
                                        bool flag13 = nextCharacterIndex >= 1 && this._ABQ.FLOg[nextCaretLine][nextCharacterIndex - 2] == ':';
                                        if (flag13)
                                        {
                                            flag = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag14 = syntaxToken == null || syntaxToken.tokenKind != SyntaxToken.Kind.Comment;
                if (flag14)
                {
                    char c3 = text[0];
                    bool flag15 = char.IsLetterOrDigit(c3) || c3 == '_';
                    if (flag15)
                    {
                        flag = true;
                    }
                }
            }
            bool flag16 = flag;
            if (flag16)
            {
                this.JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL = true;
            }
        }

        // Token: 0x060002D0 RID: 720 RVA: 0x0002E994 File Offset: 0x0002CB94
        private void OnRemovedText(GCE._AFA fromPos, GCE._AFA toPos)
        {
            TextPosition textPosition = new TextPosition(fromPos._ABI, fromPos._AEU);
            TextPosition textPosition2 = new TextPosition(toPos._ABI, toPos._AEU);
            int count = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count;
            while (count-- > 0)
            {
                _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA epaffddcaeggcpdgeebebadboblmgpdeplea = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count];
                bool flag = textPosition <= epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND;
                if (flag)
                {
                    bool flag2 = textPosition2 > epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND;
                    if (flag2)
                    {
                        this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.RemoveAt(count);
                    }
                    else
                    {
                        bool flag3 = textPosition2.line == epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.line;
                        if (flag3)
                        {
                            epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.index = epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.index - (textPosition2.index - textPosition.index);
                        }
                        bool flag4 = textPosition2.line == epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line;
                        if (flag4)
                        {
                            epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index - (textPosition2.index - textPosition.index);
                        }
                        epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.line = epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.line - (textPosition2.line - textPosition.line);
                        epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line - (textPosition2.line - textPosition.line);
                        this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count] = epaffddcaeggcpdgeebebadboblmgpdeplea;
                    }
                }
                else
                {
                    bool flag5 = textPosition <= epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
                    if (flag5)
                    {
                        bool flag6 = textPosition2 > epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
                        if (flag6)
                        {
                            this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.RemoveAt(count);
                        }
                        else
                        {
                            bool flag7 = textPosition2.line == epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line;
                            if (flag7)
                            {
                                epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index - (textPosition2.index - textPosition.index);
                            }
                            epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line - (textPosition2.line - textPosition.line);
                            this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count] = epaffddcaeggcpdgeebebadboblmgpdeplea;
                        }
                    }
                }
            }
            bool flag8 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count == 0;
            if (flag8)
            {
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK = (GCE._AVI)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK, new GCE._AVI(this.OnInsertedText));
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO = (GCE._AVM)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO, new GCE._AVM(this.OnRemovedText));
            }
        }

        // Token: 0x060002D1 RID: 721 RVA: 0x0002EBEC File Offset: 0x0002CDEC
        private void OnRemovedTextTrackSelection(GCE._AFA fromPos, GCE._AFA toPos)
        {
            TextPosition textPosition = new TextPosition(fromPos._ABI, fromPos._AEU);
            TextPosition textPosition2 = new TextPosition(toPos._ABI, toPos._AEU);
            bool flag = textPosition <= this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD;
            if (flag)
            {
                bool flag2 = textPosition2 > this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD;
                if (flag2)
                {
                    this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD = textPosition;
                }
                else
                {
                    bool flag3 = textPosition2.line == this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line;
                    if (flag3)
                    {
                        this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.index = this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.index - (textPosition2.index - textPosition.index);
                    }
                    this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line = this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line - (textPosition2.line - textPosition.line);
                }
            }
            bool flag4 = textPosition <= this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO;
            if (flag4)
            {
                bool flag5 = textPosition2 > this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO;
                if (flag5)
                {
                    this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO = textPosition;
                }
                else
                {
                    bool flag6 = textPosition2.line == this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line;
                    if (flag6)
                    {
                        this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.index = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.index - (textPosition2.index - textPosition.index);
                    }
                    this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line - (textPosition2.line - textPosition.line);
                }
            }
        }

        // Token: 0x060002D2 RID: 722 RVA: 0x0002ED24 File Offset: 0x0002CF24
        private void OnInsertedText(GCE._AFA fromPos, GCE._AFA toPos)
        {
            TextPosition textPosition = new TextPosition(fromPos._ABI, fromPos._AEU);
            TextPosition textPosition2 = new TextPosition(toPos._ABI, toPos._AEU);
            int count = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count;
            while (count-- > 0)
            {
                _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA epaffddcaeggcpdgeebebadboblmgpdeplea = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count];
                bool flag = textPosition <= epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND;
                if (flag)
                {
                    bool flag2 = textPosition.line == epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.line;
                    if (flag2)
                    {
                        epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.index = epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.index + (textPosition2.index - textPosition.index);
                    }
                    bool flag3 = textPosition.line == epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line;
                    if (flag3)
                    {
                        epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index + (textPosition2.index - textPosition.index);
                    }
                    epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.line = epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND.line + (textPosition2.line - textPosition.line);
                    epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line + (textPosition2.line - textPosition.line);
                    this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count] = epaffddcaeggcpdgeebebadboblmgpdeplea;
                }
                else
                {
                    bool flag4 = textPosition <= epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
                    if (flag4)
                    {
                        bool flag5 = textPosition.line == epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line;
                        if (flag5)
                        {
                            epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index + (textPosition2.index - textPosition.index);
                        }
                        epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line = epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line + (textPosition2.line - textPosition.line);
                        this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count] = epaffddcaeggcpdgeebebadboblmgpdeplea;
                    }
                }
            }
        }

        // Token: 0x060002D3 RID: 723 RVA: 0x0002EECC File Offset: 0x0002D0CC
        private void OnInsertedTextTrackSelection(GCE._AFA fromPos, GCE._AFA toPos)
        {
            TextPosition textPosition = new TextPosition(fromPos._ABI, fromPos._AEU);
            TextPosition textPosition2 = new TextPosition(toPos._ABI, toPos._AEU);
            bool fdilmobikgloafgdfhgbclbhnpnhklokdcnn = this.FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN;
            if (fdilmobikgloafgdfhgbclbhnpnhklokdcnn)
            {
                bool flag = textPosition <= this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD;
                if (flag)
                {
                    bool flag2 = textPosition.line == this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line;
                    if (flag2)
                    {
                        this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.index = this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.index + (textPosition2.index - textPosition.index);
                    }
                    this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line = this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line + (textPosition2.line - textPosition.line);
                }
                bool flag3 = textPosition <= this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO;
                if (flag3)
                {
                    bool flag4 = textPosition.line == this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line;
                    if (flag4)
                    {
                        this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.index = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.index + (textPosition2.index - textPosition.index);
                    }
                    this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line + (textPosition2.line - textPosition.line);
                }
            }
        }

        // Token: 0x060002D4 RID: 724 RVA: 0x0002EFD8 File Offset: 0x0002D1D8
        public void BeginRefactoring(string description)
        {
            bool fdilmobikgloafgdfhgbclbhnpnhklokdcnn = this.FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN;
            if (!fdilmobikgloafgdfhgbclbhnpnhklokdcnn)
            {
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK = (GCE._AVI)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK, new GCE._AVI(this.OnInsertedTextTrackSelection));
                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
                cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO = (GCE._AVM)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO, new GCE._AVM(this.OnRemovedTextTrackSelection));
                this._ABQ.BeginEdit("Refactoring");
                this.FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN = true;
                this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD = new TextPosition(this._ABH._ABI, this._ABH._AEU);
                bool flag = this._ATW() != null;
                if (flag)
                {
                    this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO = new TextPosition(this._ATW()._ABI, this._ATW()._AEU);
                }
                else
                {
                    this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO = TextPosition.invalid;
                }
            }
        }

        // Token: 0x060002D5 RID: 725 RVA: 0x0002F0BC File Offset: 0x0002D2BC
        public void EndRefactoring()
        {
            bool flag = !this.FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN;
            if (flag)
            {
                Debug.LogError("EndRefactoring() called without calling BeginRefactoring()");
            }
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK = (GCE._AVI)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK, new GCE._AVI(this.OnInsertedTextTrackSelection));
            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
            cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO = (GCE._AVM)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO, new GCE._AVM(this.OnRemovedTextTrackSelection));
            this.FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN = false;
            int num = this.CharIndexToColumn(this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.index, this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line);
            this._ABH = new GCE._AFA
            {
                _ABI = this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.line,
                _AEU = this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD.index,
                _ATG = num,
                _ATF = num
            };
            this._ATL(null);
            bool flag2 = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line >= 0 && this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO != this.CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD;
            if (flag2)
            {
                num = this.CharIndexToColumn(this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.index, this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line);
                this._ATL(new GCE._AFA
                {
                    _ABI = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.line,
                    _AEU = this.CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO.index,
                    _ATG = num,
                    _ATF = num
                });
            }
            this.ValidateCarets();
            bool flag3 = this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL && this._ATW().IsSameAs(this._ABH);
            if (flag3)
            {
                this._ATL(null);
            }
            this._ATM = _bi2._ATN;
            this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
            this._ATO = true;
            this._ABQ.EndEdit();
            this.AddRecentLocation(1, true);
        }

        // Token: 0x060002D6 RID: 726 RVA: 0x0002F278 File Offset: 0x0002D478
        private string TryAutoClose(string closeWith)
        {
            string text = this._ABQ.FLOg[this._ABH._ABI];
            int i = this._ABH._AEU;
            int num = text.Length;
            bool flag = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count > 0;
            if (flag)
            {
                TextPosition agjbfopcgmoggdjkcdlbnmjailheklmgpalb = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Last<_bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA>().AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
                bool flag2 = agjbfopcgmoggdjkcdlbnmjailheklmgpalb.line == this._ABH._ABI;
                if (flag2)
                {
                    num = Math.Min(agjbfopcgmoggdjkcdlbnmjailheklmgpalb.index, text.Length);
                }
            }
            while (i < num)
            {
                bool flag3 = !char.IsWhiteSpace(text, i);
                if (flag3)
                {
                    return null;
                }
                i++;
            }
            return closeWith;
        }

        // Token: 0x060002D7 RID: 727 RVA: 0x0002F334 File Offset: 0x0002D534
        public void ReindentLines(int from, int to)
        {
            bool flag = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
            if (!flag)
            {
                this._ABQ.BeginEdit("Auto-indent");
                int num = int.MaxValue;
                int num2 = -1;
                for (int i = from; i <= to; i++)
                {
                    string text = this._ABQ.CalcAutoIndent(i);
                    bool flag2 = text == null;
                    if (!flag2)
                    {
                        int num3 = this._ABQ.FirstNonWhitespace(i);
                        bool flag3 = num3 != text.Length;
                        if (flag3)
                        {
                            num = Mathf.Min(num, i);
                            num2 = Mathf.Max(num2, i);
                            GCE._AFA _ATD = this._ABQ.DeleteText(new GCE._AFA
                            {
                                _ABI = i,
                                _AEU = 0
                            }, new GCE._AFA
                            {
                                _ABI = i,
                                _AEU = num3
                            });
                            _ATD = this._ABQ.InsertText(_ATD, text);
                            bool flag4 = this._ABH._ABI == i && num3 <= this._ABH._AEU;
                            if (flag4)
                            {
                                this._ABH._AEU += _ATD._AEU - num3;
                                this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, i));
                            }
                            bool flag5 = this._ATW() != null && this._ATW()._ABI == i && num3 <= this._ATW()._AEU;
                            if (flag5)
                            {
                                this._ATW()._AEU += _ATD._AEU - num3;
                                this._ATW()._ATG = (this._ATW()._ATF = this.CharIndexToColumn(this._ATW()._AEU, i));
                            }
                        }
                    }
                }
                this._ABQ.EndEdit();
                bool flag6 = num2 > -1;
                if (flag6)
                {
                    this._ABQ.UpdateHighlighting(num, num2, false);
                }
            }
        }

        // Token: 0x060002D8 RID: 728 RVA: 0x0002F544 File Offset: 0x0002D744
        private void UpdateArgumentsHint(bool canShow)
        {
            this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = null;
            this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG = -1;
            bool flag = this._ABH._ABI >= this._ABQ._AQQ.Length;
            if (!flag)
            {
                int num;
                int num2;
                SyntaxToken syntaxToken = this._ABQ.GetNonTriviaTokenLeftOf(this._ABH, out num, out num2);
                bool flag2 = syntaxToken != null && syntaxToken.OOME != null;
                if (flag2)
                {
                    int num3 = syntaxToken.OOME._AJG();
                    while (syntaxToken != null && (syntaxToken.OOME == null || syntaxToken.OOME._AJB != null))
                    {
                        syntaxToken = this._ABQ.GetTokenLeftOf(ref num, ref num3);
                    }
                }
                bool flag3 = syntaxToken != null && syntaxToken.OOME != null && syntaxToken.OOME._AJB == null;
                if (flag3)
                {
                    _bb4._ACW _AGZ = syntaxToken.OOME.OOME;
                    bool flag4 = syntaxToken.text == ")" && _AGZ != null && _AGZ._AHB() == "arguments";
                    if (flag4)
                    {
                        _AGZ = _AGZ.OOME;
                    }
                    bool flag5 = _AGZ != null;
                    if (flag5)
                    {
                        bool flag6 = _AGZ._AHB() == "argumentList";
                        if (flag6)
                        {
                            this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG = (int)((syntaxToken.OOME._AIL + 1) / 2);
                        }
                        else
                        {
                            bool flag7 = _AGZ._AHB() == "arguments";
                            if (flag7)
                            {
                                this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG = 0;
                            }
                        }
                        while (_AGZ != null && _AGZ._AHB() != "arguments")
                        {
                            bool flag8 = _AGZ._AHB() == "argument" || (_AGZ.OOME != null && _AGZ.OOME._AHB() == "argumentList");
                            if (flag8)
                            {
                                this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG = (int)((_AGZ._AIL + 1) / 2);
                            }
                            bool flag9 = _AGZ._AHB() == "lambdaExpressionBody" || _AGZ._AHB() == "objectOrCollectionInitializer";
                            if (flag9)
                            {
                                _AGZ = null;
                            }
                            else
                            {
                                _AGZ = _AGZ.OOME;
                            }
                        }
                    }
                    bool flag10 = _AGZ != null;
                    if (flag10)
                    {
                        _bb4.DHBA _AEM = _AGZ.FindPreviousLeaf();
                        bool flag11 = _AEM != null && _AEM.OOME != null;
                        if (flag11)
                        {
                            _bb4._ACW _AGZ2 = _AEM.OOME;
                            bool flag12 = _AGZ2 != null;
                            if (flag12)
                            {
                                _bb4.DHBA _AEM2 = null;
                                bool flag13 = _AGZ2._AHB() == "typeArgumentList";
                                if (flag13)
                                {
                                    _AGZ2 = _AGZ2.OOME;
                                }
                                bool flag14 = _AGZ2._AHB() == "primaryExpressionStart";
                                if (flag14)
                                {
                                    _AEM2 = _AGZ2.LeafAt(0);
                                }
                                else
                                {
                                    bool flag15 = _AGZ2._AHB() == "accessIdentifier";
                                    if (flag15)
                                    {
                                        _AEM2 = _AGZ2.LeafAt(1);
                                    }
                                }
                                bool flag16 = _AEM2 != null;
                                if (flag16)
                                {
                                    bool flag17 = _AEM2.OOME != null;
                                    if (flag17)
                                    {
                                        this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = _AEM2;
                                    }
                                }
                                else
                                {
                                    this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = _AEM;
                                }
                            }
                        }
                    }
                }
                bool flag18 = this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM == null;
                if (flag18)
                {
                    this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN = null;
                    this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN = new TextPosition(-1, -1);
                    bool flag19 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                    if (flag19)
                    {
                        this.CloseArgumentsHint();
                    }
                }
                else
                {
                    bool flag20 = !canShow;
                    if (flag20)
                    {
                        bool flag21 = this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.line >= 0 && (this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.line != this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM.line || this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.index != this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._AJG());
                        if (flag21)
                        {
                            this.CloseArgumentsHint();
                        }
                        else
                        {
                            bool flag22 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;
                            if (flag22)
                            {
                                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.BPFOKIKKJCELJLDEACHGMOGPJLKFLLDCCOLH(this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG);
                                bool flag23 = this.GetSoftLineBreaks(this._ABH._ABI) != _bi2.BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC;
                                if (flag23)
                                {
                                    this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB._AEW(true);
                                }
                                else
                                {
                                    bool flag24 = this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.line < this._ABH._ABI;
                                    if (flag24)
                                    {
                                        this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB._AEW(true);
                                    }
                                }
                                bool flag25 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                                if (flag25)
                                {
                                    this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._AEW(!this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.OLLEJPDNBBODLEICOBPMPIPPIJBOBOOHEKFP());
                                }
                            }
                        }
                        this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = null;
                    }
                    else
                    {
                        bool flag26 = this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._AAB() == null;
                        if (flag26)
                        {
                            _bc9.ResolveNode(this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM.OOME.OOME);
                        }
                        bool flag27 = this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN == this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._AAB();
                        if (flag27)
                        {
                            bool flag28 = this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.line != this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM.line || this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.index != this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._AJG();
                            if (flag28)
                            {
                                this.CloseArgumentsHint();
                            }
                            bool flag29 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;
                            if (flag29)
                            {
                                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.BPFOKIKKJCELJLDEACHGMOGPJLKFLLDCCOLH(this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG);
                            }
                            this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = null;
                        }
                        else
                        {
                            bool flag30 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;
                            if (flag30)
                            {
                                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.BPFOKIKKJCELJLDEACHGMOGPJLKFLLDCCOLH(this.DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG);
                            }
                            else
                            {
                                bool flag31 = this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.line == this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM.line && this.EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN.index == this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._AJG();
                                if (flag31)
                                {
                                    this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = null;
                                    return;
                                }
                            }
                            bool flag32 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB && this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN != null;
                            if (flag32)
                            {
                                _bh4 _AAH = this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN;
                                while (_AAH != null && _AAH._AT == SymbolKind.Method)
                                {
                                    _AAH = _AAH._AO;
                                }
                                _bh4 _AAH2 = this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._AAB();
                                while (_AAH2 != null && _AAH2._AT == SymbolKind.Method)
                                {
                                    _AAH2 = _AAH2._AO;
                                }
                                bool flag33 = _AAH == _AAH2;
                                if (flag33)
                                {
                                    this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM = null;
                                    return;
                                }
                            }
                            this.MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB = this.GetTokenRect(this.DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM._ACX);
                            this.MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB.y = this.MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB.y - 2f;
                            this.MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB.height = this.MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB.height + 4f;
                        }
                    }
                }
            }
        }

        // Token: 0x060002D9 RID: 729 RVA: 0x0002FBCC File Offset: 0x0002DDCC
        private void DrawPing(float indent, Rect rcPing, bool bgOnly)
        {
            bool flag = this._ABT.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP == null;
            if (!flag)
            {
                float num = (1f - this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC) * 64f;
                bool flag2 = num > 0f && num < 64f;
                if (flag2)
                {
                    rcPing.x += indent;
                    GUIStyle kccbaeppgoemghpdpnebiicofiimdofppnpp = this._ABT.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP;
                    int left = kccbaeppgoemghpdpnebiicofiimdofppnpp.padding.left;
                    kccbaeppgoemghpdpnebiicofiimdofppnpp.padding.left = 0;
                    Color color = GUI.color;
                    Color backgroundColor = GUI.backgroundColor;
                    bool flag3 = num > 4f;
                    if (flag3)
                    {
                        bool flag4 = !bgOnly;
                        if (flag4)
                        {
                            GUI.backgroundColor = new Color(this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH.r, this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH.g, this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH.b, this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH.a * (8f - num) * 0.125f);
                        }
                        else
                        {
                            GUI.backgroundColor = this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH;
                        }
                        bool flag5 = num > 56f;
                        if (flag5)
                        {
                            GUI.color = new Color(color.r, color.g, color.b, this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH.a * (64f - num) * 0.125f);
                        }
                    }
                    else
                    {
                        GUI.backgroundColor = this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH;
                    }
                    Matrix4x4 matrix = GUI.matrix;
                    bool flag6 = num < 4f;
                    if (flag6)
                    {
                        float num2 = 2f - Mathf.Abs(1f - num * 0.5f);
                        Vector2 center = rcPing.center;
                        GUIUtility.ScaleAroundPivot(new Vector2(num2, num2), center);
                    }
                    kccbaeppgoemghpdpnebiicofiimdofppnpp.Draw(rcPing, bgOnly ? GUIContent.none : this.ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML, false, false, false, false);
                    GUI.matrix = matrix;
                    kccbaeppgoemghpdpnebiicofiimdofppnpp.padding.left = left;
                    GUI.color = color;
                    GUI.backgroundColor = backgroundColor;
                }
            }
        }

        // Token: 0x060002DA RID: 730 RVA: 0x0002FDB8 File Offset: 0x0002DFB8
        private void FollowHyperlink(object hyperlink)
        {
            Application.OpenURL((string)hyperlink);
        }

        // Token: 0x060002DB RID: 731 RVA: 0x0002FDC8 File Offset: 0x0002DFC8
        private bool CanUndo()
        {
            return this.CanEdit() && this._ABQ.CanUndo();
        }

        // Token: 0x060002DC RID: 732 RVA: 0x0002FDF0 File Offset: 0x0002DFF0
        private bool CanRedo()
        {
            return this.CanEdit() && this._ABQ.CanRedo();
        }

        // Token: 0x060002DD RID: 733 RVA: 0x0002FE18 File Offset: 0x0002E018
        internal void Undo()
        {
            bool flag = !this.TryEdit();
            if (!flag)
            {
                bool flag2 = !_bc5.GlobalUndo(this._ABQ);
                if (flag2)
                {
                    this._ABQ.Undo();
                }
                this.AddRecentLocation(0, true);
            }
        }

        // Token: 0x060002DE RID: 734 RVA: 0x0002FE5C File Offset: 0x0002E05C
        internal void Redo()
        {
            bool flag = !this.TryEdit();
            if (!flag)
            {
                bool flag2 = !_bc5.GlobalRedo(this._ABQ);
                if (flag2)
                {
                    this._ABQ.Redo();
                }
                this.AddRecentLocation(0, true);
            }
        }

        // Token: 0x060002DF RID: 735 RVA: 0x0002FEA0 File Offset: 0x0002E0A0
        private void ToggleCommentSelection()
        {
            bool flag = !this.TryEdit();
            if (!flag)
            {
                this._ABQ.BeginEdit("Toggle Comment");
                GCE._AFA _ATD = this._ABH.Clone();
                GCE._AFA _ATD2 = this._ABH.Clone();
                int num = this._ABH._ABI;
                int num2 = this._ABH._ABI;
                bool flag2 = this._ATW() != null;
                if (flag2)
                {
                    bool flag3 = this._ABH < this._ATW();
                    if (flag3)
                    {
                        _ATD2 = this._ATW().Clone();
                        num2 = _ATD2._ABI;
                    }
                    else
                    {
                        _ATD = this._ATW().Clone();
                        num = _ATD._ABI;
                    }
                    bool flag4 = _ATD2._AEU == 0;
                    if (flag4)
                    {
                        num2--;
                    }
                }
                int num3 = int.MaxValue;
                int[] array = new int[num2 - num + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = this._ABQ.FirstNonWhitespace(num + i);
                    bool flag5 = array[i] < this._ABQ.FLOg[num + i].Length;
                    if (flag5)
                    {
                        int num4 = this.CharIndexToColumn(array[i], num + i);
                        bool flag6 = num4 < num3;
                        if (flag6)
                        {
                            num3 = num4;
                        }
                    }
                }
                bool flag7 = num3 == int.MaxValue;
                if (flag7)
                {
                    this._ABQ.EndEdit();
                }
                else
                {
                    bool flag8 = true;
                    for (int j = 0; j < array.Length; j++)
                    {
                        int length = this._ABQ.FLOg[num + j].Length;
                        bool flag9 = array[j] < length;
                        if (flag9)
                        {
                            int num5 = this._ABQ.ColumnToCharIndex(ref num3, num + j);
                            bool flag10 = this._ABQ.FLOg[num + j][num5] != '/' || num5 + 1 >= length || this._ABQ.FLOg[num + j][num5 + 1] != '/';
                            if (flag10)
                            {
                                flag8 = false;
                                break;
                            }
                        }
                    }
                    bool flag11 = _ATD._ABI == num && (flag8 ? (array[0] < _ATD._AEU) : (array[0] <= _ATD._AEU));
                    bool flag12 = _ATD2._ABI == num2 && (flag8 ? (array[array.Length - 1] < _ATD2._AEU) : (array[array.Length - 1] <= _ATD2._AEU));
                    bool flag13 = flag8;
                    if (flag13)
                    {
                        GCE._AFA _ATD3 = new GCE._AFA
                        {
                            _AEU = 0,
                            _ATG = num3,
                            _ABI = num,
                            _ATF = num3
                        };
                        while (_ATD3._ABI <= num2)
                        {
                            bool flag14 = array[_ATD3._ABI - num] < this._ABQ.FLOg[_ATD3._ABI].Length;
                            if (flag14)
                            {
                                _ATD3._AEU = this._ABQ.ColumnToCharIndex(ref num3, _ATD3._ABI);
                                GCE._AFA _ATD4 = _ATD3.Clone();
                                _ATD4._ATG = (_ATD4._ATF += 2);
                                _ATD4._AEU += 2;
                                this._ABQ.DeleteText(_ATD3, _ATD4);
                            }
                            _ATD3._ABI++;
                        }
                    }
                    else
                    {
                        GCE._AFA _ATD5 = new GCE._AFA
                        {
                            _AEU = 0,
                            _ATG = num3,
                            _ABI = num,
                            _ATF = num3
                        };
                        while (_ATD5._ABI <= num2)
                        {
                            bool flag15 = array[_ATD5._ABI - num] < this._ABQ.FLOg[_ATD5._ABI].Length;
                            if (flag15)
                            {
                                _ATD5._AEU = this._ABQ.ColumnToCharIndex(ref num3, _ATD5._ABI);
                                this._ABQ.InsertText(_ATD5, "//");
                            }
                            _ATD5._ABI++;
                        }
                    }
                    this._ABQ.UpdateHighlighting(num, num2, false);
                    bool flag16 = flag11;
                    if (flag16)
                    {
                        _ATD._AEU += (flag8 ? (-2) : 2);
                    }
                    bool flag17 = flag12;
                    if (flag17)
                    {
                        _ATD2._AEU += (flag8 ? (-2) : 2);
                    }
                    _ATD._ATG = (_ATD._ATF = this.CharIndexToColumn(_ATD._AEU, _ATD._ABI));
                    _ATD2._ATG = (_ATD2._ATF = this.CharIndexToColumn(_ATD2._AEU, _ATD2._ABI));
                    bool flag18 = this._ATW() != null;
                    if (flag18)
                    {
                        bool flag19 = this._ABH < this._ATW();
                        if (flag19)
                        {
                            this._ABH = _ATD;
                            this._ATL(_ATD2);
                        }
                        else
                        {
                            this._ATL(_ATD);
                            this._ABH = _ATD2;
                        }
                    }
                    else
                    {
                        this._ABH = _ATD;
                    }
                    this._ATM = _bi2._ATN;
                    this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                    this._ATO = true;
                    this._ABQ.EndEdit();
                    this.AddRecentLocation(1, true);
                }
            }
        }

        // Token: 0x060002E0 RID: 736 RVA: 0x000303FC File Offset: 0x0002E5FC
        public void PingLine(int line)
        {
            this.CloseAllPopups();
            bool flag = line == 0;
            if (flag)
            {
                line = 1;
            }
            bool flag2 = line > this._ABQ.FLOg.Count;
            if (flag2)
            {
                line = this._ABQ.FLOg.Count;
            }
            int num = this._ABQ.FirstNonWhitespace(line - 1);
            int num2 = this.CharIndexToColumn(num, line - 1);
            string text = this._ABQ.FLOg[line - 1];
            this.ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML.text = text.Trim(_bi2.JHCFMJHGFHIGMNHFMLDCNLHAMGHANGOPFJNN);
            bool flag3 = !string.IsNullOrEmpty(this.ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML.text);
            if (flag3)
            {
                int length = text.Length;
                this._ABH = new GCE._AFA
                {
                    _ABI = line - 1,
                    _ATG = num2,
                    _ATF = num2,
                    _AEU = num
                };
                this._ATL(new GCE._AFA
                {
                    _ABI = line - 1,
                    _ATG = length,
                    _ATF = length,
                    _AEU = this._ABQ.FLOg[line - 1].Length
                });
            }
            else
            {
                this._ABH = new GCE._AFA
                {
                    _ABI = line - 1,
                    _ATG = 0,
                    _ATF = 0,
                    _AEU = 0
                };
                bool flag4 = line < this._ABQ.FLOg.Count;
                if (flag4)
                {
                    this._ATL(new GCE._AFA
                    {
                        _ABI = line,
                        _ATG = 0,
                        _ATF = 0,
                        _AEU = 0
                    });
                }
                else
                {
                    this._ATL(null);
                }
            }
            this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 1f;
            this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO = _bi2._ATN;
            this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH = _bi2._ALN;
            this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.x = this.GetCharXOffset(num, this._ABH._ABI, 0);
            this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.y = this.GetLineOffset(this._ABH._ABI);
            this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.xMax = this.GetCharXOffset(num + this.ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML.text.Length, this._ABH._ABI, 0);
            this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.height = this._AEY().y;
            this._ATM = _bi2._ATN;
            this.Repaint();
        }

        // Token: 0x060002E1 RID: 737 RVA: 0x0003064C File Offset: 0x0002E84C
        private bool CanGoBack()
        {
            List<_ba3> _AOL = _bc5.Instance()._AOI;
            bool flag = _AOL.Count == 0;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                int pkhkdckmdjbmelkjcjigdbppeickfgfokpia = _bc5.Instance()._AOH;
                bool flag3 = pkhkdckmdjbmelkjcjigdbppeickfgfokpia < _AOL.Count - 1;
                if (flag3)
                {
                    flag2 = true;
                }
                else
                {
                    _ba3 _AOJ = _AOL[0];
                    bool flag4 = _AOJ._ADF != this._AKQ() || this._ABH._ABI != _AOJ._ABI;
                    flag2 = flag4;
                }
            }
            return flag2;
        }

        // Token: 0x060002E2 RID: 738 RVA: 0x000306E0 File Offset: 0x0002E8E0
        private bool CanGoForward()
        {
            return _bc5.Instance()._AOH > 0;
        }

        // Token: 0x060002E3 RID: 739 RVA: 0x00030700 File Offset: 0x0002E900
        public bool AddRecentLocation(int minLinesDistance, bool insert)
        {
            bool flag = this._AKQ() == "";
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                List<_ba3> _AOL = _bc5.Instance()._AOI;
                int pkhkdckmdjbmelkjcjigdbppeickfgfokpia = _bc5.Instance()._AOH;
                bool flag3 = _AOL.Count <= pkhkdckmdjbmelkjcjigdbppeickfgfokpia;
                if (flag3)
                {
                    _bc5.AddRecentLocation(this._AKQ(), this._ABH, false);
                    flag2 = true;
                }
                else
                {
                    _ba3 _AOJ = _AOL[_AOL.Count - 1 - pkhkdckmdjbmelkjcjigdbppeickfgfokpia];
                    int num = Mathf.Abs(this._ABH._ABI - _AOJ._ABI);
                    _ba3 _AOJ2 = ((pkhkdckmdjbmelkjcjigdbppeickfgfokpia > 0) ? _AOL[_AOL.Count - pkhkdckmdjbmelkjcjigdbppeickfgfokpia] : null);
                    int num2 = ((_AOJ2 != null) ? Mathf.Abs(this._ABH._ABI - _AOJ2._ABI) : (-1));
                    bool flag4 = (_AOJ._ADF != this._AKQ() || (num >= minLinesDistance && (num > 0 || this._ABH._AEU != _AOJ.JIKB))) && (_AOJ2 == null || _AOJ2._ADF != this._AKQ() || (num2 >= minLinesDistance && (num2 > 0 || this._ABH._AEU != _AOJ2.JIKB)));
                    if (flag4)
                    {
                        _bc5.AddRecentLocation(this._AKQ(), this._ABH, insert);
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = false;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x060002E4 RID: 740 RVA: 0x0003086C File Offset: 0x0002EA6C
        private void GoToRecentLocation(bool forward)
        {
            bool flag = this.AddRecentLocation(1, true);
            List<_ba3> _AOL = _bc5.Instance()._AOI;
            int num = _bc5.Instance()._AOH;
            bool flag2 = flag;
            bool flag3 = !flag2;
            if (flag3)
            {
                _ba3 _AOJ = _AOL[_AOL.Count - 1 - num];
                flag2 = _AOJ._ADF == this._AKQ() && this._ABH._ABI == _AOJ._ABI;
            }
            if (forward)
            {
                num--;
            }
            else
            {
                bool flag4 = flag2;
                if (flag4)
                {
                    num++;
                }
            }
            _bc5.Instance()._AOH = num;
            _ba3 _AOJ2 = _AOL[_AOL.Count - 1 - num];
            bool flag5 = _AOJ2._ADF == this._AKQ();
            if (flag5)
            {
                this.SetCursorPosition(_AOJ2._ABI, _AOJ2.JIKB);
            }
            else
            {
                _bi2.IAGMGPLNBONFCCINLNNELHHBEJPIHBHHPGHA = false;
                _bb6.OpenAssetInTab(_AOJ2._ADF, _AOJ2._ABI, _AOJ2.JIKB, 0, !_bg8.EAIK.GNIO());
            }
        }

        // Token: 0x060002E5 RID: 741 RVA: 0x00030984 File Offset: 0x0002EB84
        internal void SetCursorPosition(int line, int characterIndex)
        {
            this._ATL(null);
            int num = this.CharIndexToColumn(characterIndex, line);
            this._ABH = new GCE._AFA
            {
                _ABI = line,
                _AEU = characterIndex,
                _ATG = num,
                _ATF = num
            };
            this.ValidateCaret(ref this._ABH);
            bool flag = !this.FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN;
            if (flag)
            {
                this._ATO = true;
                this._ATM = _bi2._ATN;
                this.ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML = new GUIContent();
                this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH = _bi2._ALN;
                this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH.a = 0.4f;
                this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 1f;
                this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO = _bi2._ATN;
                this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.x = this._AEY().x * (float)this._ABH._ATG - 3f;
                this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.y = this.GetLineOffset(this._ABH._ABI);
                this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.width = 6f;
                this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.height = this._AEY().y;
                this.Repaint();
            }
        }

        // Token: 0x060002E6 RID: 742 RVA: 0x00030AB0 File Offset: 0x0002ECB0
        private string ReadableOperatorName(_bh4 symbol, out bool addParameters)
        {
            addParameters = true;
            string name = symbol.GetName();
            string text = name;
            string text2 = text;
            uint num = Helper.ComputeStringHash(text2);
            if (num <= 1915672496U)
            {
                if (num <= 1195761148U)
                {
                    if (num <= 441288870U)
                    {
                        if (num <= 120689619U)
                        {
                            if (num != 90588446U)
                            {
                                if (num != 120689619U)
                                {
                                    goto IL_06B7;
                                }
                                if (!(text2 == "op_LogicalOr"))
                                {
                                    goto IL_06B7;
                                }
                                return "operator ||";
                            }
                            else
                            {
                                if (!(text2 == "op_OnesComplement"))
                                {
                                    goto IL_06B7;
                                }
                                addParameters = false;
                                return "operator ~";
                            }
                        }
                        else if (num != 215197780U)
                        {
                            if (num != 441288870U)
                            {
                                goto IL_06B7;
                            }
                            if (!(text2 == "op_Assign"))
                            {
                                goto IL_06B7;
                            }
                            return "operator =";
                        }
                        else
                        {
                            if (!(text2 == "op_Implicit"))
                            {
                                goto IL_06B7;
                            }
                            return "implicit operator " + symbol.TypeOf().GetName();
                        }
                    }
                    else if (num <= 906583475U)
                    {
                        if (num != 835846267U)
                        {
                            if (num != 906583475U)
                            {
                                goto IL_06B7;
                            }
                            if (!(text2 == "op_Addition"))
                            {
                                goto IL_06B7;
                            }
                            return "operator +";
                        }
                        else
                        {
                            if (!(text2 == "op_BitwiseAnd"))
                            {
                                goto IL_06B7;
                            }
                            return "operator &";
                        }
                    }
                    else if (num != 1034931220U)
                    {
                        if (num != 1195761148U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_GreaterThan"))
                        {
                            goto IL_06B7;
                        }
                        return "operator >";
                    }
                    else
                    {
                        if (!(text2 == "op_Increment"))
                        {
                            goto IL_06B7;
                        }
                        return "operator ++";
                    }
                }
                else if (num <= 1548478473U)
                {
                    if (num <= 1258540185U)
                    {
                        if (num != 1234170120U)
                        {
                            if (num != 1258540185U)
                            {
                                goto IL_06B7;
                            }
                            if (!(text2 == "op_LessThan"))
                            {
                                goto IL_06B7;
                            }
                            return "operator <";
                        }
                        else
                        {
                            if (!(text2 == "op_LessThanOrEqual"))
                            {
                                goto IL_06B7;
                            }
                            return "operator <=";
                        }
                    }
                    else if (num != 1516143579U)
                    {
                        if (num != 1548478473U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_RightShift"))
                        {
                            goto IL_06B7;
                        }
                    }
                    else
                    {
                        if (!(text2 == "op_Equality"))
                        {
                            goto IL_06B7;
                        }
                        return "operator ==";
                    }
                }
                else if (num <= 1683505413U)
                {
                    if (num != 1587019679U)
                    {
                        if (num != 1683505413U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_SignedRightShift"))
                        {
                            goto IL_06B7;
                        }
                    }
                    else
                    {
                        if (!(text2 == "op_Explicit"))
                        {
                            goto IL_06B7;
                        }
                        return "explicit operator " + symbol.TypeOf().GetName();
                    }
                }
                else if (num != 1706699053U)
                {
                    if (num != 1850069070U)
                    {
                        if (num != 1915672496U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_Division"))
                        {
                            goto IL_06B7;
                        }
                        return "operator /";
                    }
                    else
                    {
                        if (!(text2 == "op_False"))
                        {
                            goto IL_06B7;
                        }
                        addParameters = false;
                        return "operator false";
                    }
                }
                else
                {
                    if (!(text2 == "op_MemberSelection"))
                    {
                        goto IL_06B7;
                    }
                    goto IL_06B7;
                }
            }
            else if (num <= 2958252495U)
            {
                if (num <= 2429678952U)
                {
                    if (num <= 2296502820U)
                    {
                        if (num != 2242295702U)
                        {
                            if (num != 2296502820U)
                            {
                                goto IL_06B7;
                            }
                            if (!(text2 == "op_PointerDereference"))
                            {
                                goto IL_06B7;
                            }
                            goto IL_06B7;
                        }
                        else
                        {
                            if (!(text2 == "op_LeftShift"))
                            {
                                goto IL_06B7;
                            }
                            return "operator <<";
                        }
                    }
                    else if (num != 2366795836U)
                    {
                        if (num != 2429678952U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_Modulus"))
                        {
                            goto IL_06B7;
                        }
                        return "operator %";
                    }
                    else
                    {
                        if (!(text2 == "op_ExclusiveOr"))
                        {
                            goto IL_06B7;
                        }
                        return "operator ^";
                    }
                }
                else if (num <= 2536726348U)
                {
                    if (num != 2459852411U)
                    {
                        if (num != 2536726348U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_Decrement"))
                        {
                            goto IL_06B7;
                        }
                        return "operator --";
                    }
                    else
                    {
                        if (!(text2 == "op_GreaterThanOrEqual"))
                        {
                            goto IL_06B7;
                        }
                        return "operator >=";
                    }
                }
                else if (num != 2574677899U)
                {
                    if (num != 2685647650U)
                    {
                        if (num != 2958252495U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_Multiply"))
                        {
                            goto IL_06B7;
                        }
                        return "operator *";
                    }
                    else if (!(text2 == "op_UnsignedRightShift"))
                    {
                        goto IL_06B7;
                    }
                }
                else
                {
                    if (!(text2 == "op_LogicalNot"))
                    {
                        goto IL_06B7;
                    }
                    addParameters = false;
                    return "operator !";
                }
            }
            else if (num <= 3492550567U)
            {
                if (num <= 3279419199U)
                {
                    if (num != 3075696130U)
                    {
                        if (num != 3279419199U)
                        {
                            goto IL_06B7;
                        }
                        if (!(text2 == "op_Subtraction"))
                        {
                            goto IL_06B7;
                        }
                        return "operator -";
                    }
                    else
                    {
                        if (!(text2 == "op_UnaryPlus"))
                        {
                            goto IL_06B7;
                        }
                        addParameters = false;
                        return "operator +";
                    }
                }
                else if (num != 3476452951U)
                {
                    if (num != 3492550567U)
                    {
                        goto IL_06B7;
                    }
                    if (!(text2 == "op_BitwiseOr"))
                    {
                        goto IL_06B7;
                    }
                    return "operator |";
                }
                else
                {
                    if (!(text2 == "op_PointerToMemberSelection"))
                    {
                        goto IL_06B7;
                    }
                    goto IL_06B7;
                }
            }
            else if (num <= 3716665893U)
            {
                if (num != 3568900899U)
                {
                    if (num != 3716665893U)
                    {
                        goto IL_06B7;
                    }
                    if (!(text2 == "op_UnaryNegation"))
                    {
                        goto IL_06B7;
                    }
                    addParameters = false;
                    return "operator -";
                }
                else
                {
                    if (!(text2 == "op_True"))
                    {
                        goto IL_06B7;
                    }
                    addParameters = false;
                    return "operator true";
                }
            }
            else if (num != 3794317784U)
            {
                if (num != 3938291511U)
                {
                    if (num != 4080629120U)
                    {
                        goto IL_06B7;
                    }
                    if (!(text2 == "op_AddressOf"))
                    {
                        goto IL_06B7;
                    }
                    goto IL_06B7;
                }
                else
                {
                    if (!(text2 == "op_LogicalAnd"))
                    {
                        goto IL_06B7;
                    }
                    return "operator &&";
                }
            }
            else
            {
                if (!(text2 == "op_Inequality"))
                {
                    goto IL_06B7;
                }
                return "operator !=";
            }
            return "operator >>";
        IL_06B7:
            return "operator UNKNOWN";
        }

        // Token: 0x060002E7 RID: 743 RVA: 0x00031184 File Offset: 0x0002F384
        private void GoToRegion(GCE._ABW region)
        {
            int _AQZ = region._ABI.JIKB;
            bool flag = _AQZ >= 0 && _AQZ < this._ABQ.FLOg.Count && this._ABQ._AQQ[_AQZ] == region._ABI;
            if (flag)
            {
                List<SyntaxToken> _ABS = region._ABI.EOIA;
                for (int i = 0; i < _ABS.Count; i++)
                {
                    bool flag2 = _ABS[i].tokenKind == SyntaxToken.Kind.Preprocessor && _ABS[i].text == "region";
                    if (flag2)
                    {
                        this.AddRecentLocation(0, true);
                        TextSpan tokenSpan = this._ABQ.GetTokenSpan(_AQZ, i);
                        this.PingText(new GCE._AFA
                        {
                            _ABI = _AQZ,
                            _AEU = tokenSpan.index
                        }, "region".Length, _bi2._ALN);
                        break;
                    }
                }
            }
        }

        // Token: 0x060002E8 RID: 744 RVA: 0x00031278 File Offset: 0x0002F478
        private void ListAllRegions(GCE._ABW root, List<GCE._ABW> regions)
        {
            bool flag = root._ARB == null;
            if (!flag)
            {
                int count = this._ABQ.FLOg.Count;
                int count2 = root._ARB.Count;
                while (count2-- > 0)
                {
                    GCE._ABW _AVO = root._ARB[count2];
                    GCE.PHFG _ARC = _AVO._ABI;
                    int _AQZ = _ARC.JIKB;
                    bool flag2 = _AQZ < 0 || _AQZ >= count || this._ABQ._AQQ[_AQZ] != _ARC;
                    if (flag2)
                    {
                        root._ARB.RemoveAt(count2);
                    }
                    else
                    {
                        List<SyntaxToken> _ABS = _AVO._ABI.EOIA;
                        for (int i = 0; i < _ABS.Count; i++)
                        {
                            SyntaxToken syntaxToken = _ABS[i];
                            bool flag3 = syntaxToken.tokenKind == SyntaxToken.Kind.Preprocessor && syntaxToken.text != "#";
                            if (flag3)
                            {
                                bool flag4 = syntaxToken.text == "region";
                                if (flag4)
                                {
                                    regions.Add(_AVO);
                                }
                                this.ListAllRegions(_AVO, regions);
                                break;
                            }
                            bool flag5 = syntaxToken.tokenKind > SyntaxToken.Kind.Preprocessor;
                            if (flag5)
                            {
                                break;
                            }
                        }
                    }
                }
                bool flag6 = root._ARB.Count == 0;
                if (flag6)
                {
                    root._ARB = null;
                }
            }
        }

        // Token: 0x060002E9 RID: 745 RVA: 0x000313DC File Offset: 0x0002F5DC
        private static void EnumScopeDeclarations(_bb4._ACW root, Action<FKI> action)
        {
            for (int i = 0; i < (int)root._AIX; i++)
            {
                _bb4._ACW _AGZ = root.NodeAt(i);
                bool flag = _AGZ == null;
                if (!flag)
                {
                    _bc1 cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof = _AGZ._AJO();
                    _bc1 cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 = cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof & _bc1.SymbolDeclarationsMask;
                    bool flag2 = _AGZ.EFI != null && (cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.ExternAlias || cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.NamespaceDeclaration || cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.ClassDeclaration || cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.StructDeclaration || cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.InterfaceDeclaration || cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.EnumDeclaration || cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof2 == _bc1.DelegateDeclaration);
                    if (flag2)
                    {
                        action(_AGZ.EFI);
                    }
                    bool flag3 = (cojbeknpolcfmdflbkcmhcjkjpdhcmkmgdof & _bc1.ScopesMask) == _bc1.None;
                    if (flag3)
                    {
                        _bi2.EnumScopeDeclarations(_AGZ, action);
                    }
                }
            }
        }

        // Token: 0x060002EA RID: 746 RVA: 0x00031488 File Offset: 0x0002F688
        public void GoToSymbol(_bh4 symbol)
        {
            List<FKI> list = symbol._AEI;
            bool flag = list == null || list.Count == 0;
            if (flag)
            {
                list = _bh6.FindDeclarations(symbol);
            }
            bool flag2 = list == null;
            if (!flag2)
            {
                foreach (FKI _AFF in symbol._AEI)
                {
                    bool flag3 = _AFF.IsValid();
                    if (flag3)
                    {
                        this.GoToSymbolDeclaration(_AFF);
                        break;
                    }
                }
            }
        }

        // Token: 0x060002EB RID: 747 RVA: 0x00031520 File Offset: 0x0002F720
        public bool IsValidSymbolDeclaration(FKI declaration)
        {
            _bb4._AIN _AIO = declaration.NameNode();
            bool flag = _AIO == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                string text = null;
                for (_bm6 _AQI = declaration._AJW; _AQI != null; _AQI = _AQI._AMJ())
                {
                    _be7 hebiehngcbipegicgdnhcaaoamfabehlcmkf = _AQI as _be7;
                    bool flag3 = hebiehngcbipegicgdnhcaaoamfabehlcmkf != null;
                    if (flag3)
                    {
                        text = hebiehngcbipegicgdnhcaaoamfabehlcmkf._AWJ;
                        break;
                    }
                }
                bool flag4 = text == null;
                if (flag4)
                {
                    flag2 = false;
                }
                else
                {
                    Object @object = AssetDatabase.LoadAssetAtPath(text, typeof(MonoScript));
                    bool flag5 = @object == null;
                    if (flag5)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        GCE buffer = _bc5.GetBuffer(@object);
                        bool flag6 = buffer == null;
                        flag2 = !flag6;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x060002EC RID: 748 RVA: 0x000315DC File Offset: 0x0002F7DC
        public bool GoToSymbolDeclaration(FKI declaration)
        {
            _bb4._AIN _AIO = declaration.NameNode() ?? declaration._AEJ;
            bool flag = _AIO == null || !_AIO.HasLeafs();
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                string cuPath = null;
                for (_bm6 _AQI = declaration._AJW; _AQI != null; _AQI = _AQI._AMJ())
                {
                    _be7 hebiehngcbipegicgdnhcaaoamfabehlcmkf = _AQI as _be7;
                    bool flag3 = hebiehngcbipegicgdnhcaaoamfabehlcmkf != null;
                    if (flag3)
                    {
                        cuPath = hebiehngcbipegicgdnhcaaoamfabehlcmkf._AWJ;
                        break;
                    }
                }
                bool flag4 = cuPath == null;
                if (flag4)
                {
                    Debug.Log("Source code for '" + _AIO.Print() + "' is not available.");
                    flag2 = false;
                }
                else
                {
                    string text = AssetDatabase.AssetPathToGUID(cuPath);
                    bool flag5 = string.IsNullOrEmpty(text);
                    if (flag5)
                    {
                        text = cuPath;
                    }
                    GCE buffer = _bc5.GetBuffer(text);
                    bool flag6 = buffer == null;
                    if (flag6)
                    {
                        Debug.Log("Error: Failed to load " + cuPath);
                        flag2 = false;
                    }
                    else
                    {
                        bool flag7 = buffer.FLOg.Count == 0;
                        if (flag7)
                        {
                            buffer.LoadImmediately();
                        }
                        this.AddRecentLocation(0, true);
                        TextSpan span = buffer.GetParseTreeNodeSpan(_AIO);
                        bool flag8 = buffer == this._ABQ;
                        if (flag8)
                        {
                            int num = this.CharIndexToColumn(span.index, span.line);
                            GCE._AFA _ATD = new GCE._AFA
                            {
                                _AEU = span.index,
                                _ATG = num,
                                _ATF = num,
                                _ABI = span.line
                            };
                            this.PingText(_ATD, (span.lineOffset == 0) ? span.indexOffset : (buffer.FLOg[span.line].Length - span.index), _bi2._ALN);
                        }
                        else
                        {
                            EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                            {
                                _bb6.OpenAssetInTab(AssetDatabase.AssetPathToGUID(cuPath), span.line + 1, -1, 0, !_bg8.EAIK.GNIO());
                                _bi2._AKS = true;
                            }));
                        }
                        flag2 = true;
                    }
                }
            }
            return flag2;
        }

        // Token: 0x060002ED RID: 749 RVA: 0x00031809 File Offset: 0x0002FA09
        private void AddGoToTypeDefinitionMenuItems(GenericMenu menu, _b2 symbolType)
        {
            this.AddGoToTypeDefinitionMenuItems(menu, null, symbolType);
        }

        // Token: 0x060002EE RID: 750 RVA: 0x00031818 File Offset: 0x0002FA18
        private void AddGoToTypeDefinitionMenuItems(GenericMenu menu, string parentItem, _b2 symbolType)
        {
            bool flag = symbolType == null;
            if (!flag)
            {
                _bm8 _AX = symbolType as _bm8;
                bool flag2 = _AX != null;
                if (flag2)
                {
                    symbolType = _AX._AHP.definition as _b2;
                }
                bool flag3 = symbolType == null;
                if (!flag3)
                {
                    _bj5 _AOS = symbolType.Assembly;
                    bool flag4 = _AOS == null && symbolType._AEI != null;
                    if (flag4)
                    {
                        _AOS = ((_be7)this._ABQ._AOU()._AQT()._AIT._AJW)._AN;
                    }
                    bool flag5 = _AOS == null;
                    if (!flag5)
                    {
                        _bi5 _AAE = symbolType as _bi5;
                        bool flag6 = _AAE != null && _AAE._AHH != null;
                        if (flag6)
                        {
                            foreach (KJK _AAD in _AAE._AHH)
                            {
                                _b2 _AAC = _AAD.definition as _b2;
                                bool flag7 = _AAC != null;
                                if (flag7)
                                {
                                    parentItem = "Go To Type Definition/";
                                    this.AddGoToTypeDefinitionMenuItems(menu, parentItem, _AAC);
                                }
                            }
                        }
                        string text = _AOS.AssemblyName;
                        bool flag8 = text == "mscorlib" || text == "System" || text.StartsWith("System.", StringComparison.Ordinal);
                        if (flag8)
                        {
                            string text2 = symbolType._BEX();
                            bool flag9 = text2 != null;
                            if (flag9)
                            {
                                MD5 md = MD5.Create();
                                byte[] bytes = Encoding.UTF8.GetBytes(text2);
                                byte[] array = md.ComputeHash(bytes);
                                char[] c = new char[16];
                                for (int j = 0; j < 8; j++)
                                {
                                    byte b = (byte)(array[j] >> 4);
                                    c[j * 2] = (char)((b > 9) ? (b + 87) : (b + 48));
                                    b = array[j] & 15;
                                    c[j * 2 + 1] = (char)((b > 9) ? (b + 87) : (b + 48));
                                }
                                string text3 = "Go To Type Definition (.Net)";
                                bool flag10 = parentItem != null;
                                if (flag10)
                                {
                                    text3 = parentItem + symbolType._AW.Replace('_', '\uff3f') + " (.Net)";
                                }
                                menu.AddItem(new GUIContent(text3), false, delegate
                                {
                                    Help.BrowseURL("http://referencesource.microsoft.com/mscorlib/a.html#" + new string(c));
                                });
                            }
                        }
                        else
                        {
                            bool ppfhkdollcggpjafekhmnabknmlonajanclj = _AOS.PPFHKDOLLCGGPJAFEKHMNABKNMLONAJANCLJ;
                            if (ppfhkdollcggpjafekhmnabknmlonajanclj)
                            {
                                List<FKI> declarations = symbolType._AEI;
                                bool flag11 = declarations == null || declarations.Count == 0;
                                if (flag11)
                                {
                                    declarations = _bh6.FindDeclarations(symbolType);
                                }
                                List<FKI> list = new List<FKI>();
                                bool flag12 = declarations != null && declarations.Count > 0;
                                if (flag12)
                                {
                                    foreach (FKI _AFF in declarations)
                                    {
                                        bool flag13 = this.IsValidSymbolDeclaration(_AFF);
                                        if (flag13)
                                        {
                                            list.Add(_AFF);
                                        }
                                    }
                                }
                                declarations = list;
                                bool flag14 = declarations != null && declarations.Count == 1;
                                if (flag14)
                                {
                                    string text4 = "Go To Type Definition";
                                    bool flag15 = parentItem != null;
                                    if (flag15)
                                    {
                                        text4 = parentItem + symbolType._AW.Replace('_', '\uff3f');
                                    }
                                    menu.AddItem(new GUIContent(text4), false, delegate
                                    {
                                        this.GoToSymbolDeclaration(declarations[0]);
                                    });
                                }
                                else
                                {
                                    bool flag16 = declarations != null && declarations.Count > 0;
                                    if (flag16)
                                    {
                                        string text5 = "Go To Type Definition/";
                                        bool flag17 = parentItem != null;
                                        if (flag17)
                                        {
                                            text5 = text5 + parentItem + symbolType._AW.Replace('_', '\uff3f') + "/";
                                        }
                                        foreach (FKI _AFF2 in declarations)
                                        {
                                            _bm6 _AQI = _AFF2._AJW;
                                            while (_AQI._AMJ() != null)
                                            {
                                                _AQI = _AQI._AMJ();
                                            }
                                            string text6 = ((_be7)_AQI)._AWJ;
                                            text6 = AssetDatabase.AssetPathToGUID(text6);
                                            text6 = AssetDatabase.GUIDToAssetPath(text6);
                                            text6 = Path.GetFileName(text6);
                                            _bb4._AIN _AIO = _AFF2.NameNode();
                                            _bb4.DHBA _AEM = (_AIO as _bb4.DHBA) ?? (_AIO as _bb4._ACW).GetFirstLeaf();
                                            menu.AddItem(new GUIContent(text5 + text6 + " : " + (_AEM._ACX.Line + 1).ToString()), false, delegate (object d)
                                            {
                                                this.GoToSymbolDeclaration((FKI)d);
                                            }, _AFF2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060002EF RID: 751 RVA: 0x00031D18 File Offset: 0x0002FF18
        private void OpenInNewTab()
        {
            bool flag = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH != null;
            if (flag)
            {
                _bb6.OpenAssetInTab(this._AKQ());
            }
            else
            {
                EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("SuperEditor.AddTab"));
            }
        }

        // Token: 0x060002F0 RID: 752 RVA: 0x00031D60 File Offset: 0x0002FF60
        private static int FindFirstIndexGreaterThanOrEqualTo<T>(IList<T> sortedCollection, T key)
        {
            return _bi2.FindFirstIndexGreaterThanOrEqualTo<T>(sortedCollection, key, Comparer<T>.Default);
        }

        // Token: 0x060002F1 RID: 753 RVA: 0x00031D80 File Offset: 0x0002FF80
        private static int FindFirstIndexGreaterThanOrEqualTo<T>(IList<T> sortedCollection, T key, IComparer<T> comparer)
        {
            int num = 0;
            int i = sortedCollection.Count;
            while (i > num)
            {
                int num2 = (num + i) / 2;
                T t = sortedCollection[num2];
                bool flag = comparer.Compare(t, key) >= 0;
                if (flag)
                {
                    i = num2;
                }
                else
                {
                    num = num2 + 1;
                }
            }
            return i;
        }

        // Token: 0x060002F2 RID: 754 RVA: 0x00031DD8 File Offset: 0x0002FFD8
        private void SearchPrevious()
        {
            bool flag = this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH != this._ABQ._ASJ;
            if (flag)
            {
                this.SetSearchText(this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
            }
            GCE._AFA _ATD = this._ABH;
            bool flag2 = this._ATW() != null && this._ATW() < this._ABH;
            if (flag2)
            {
                _ATD = this._ATW();
            }
            this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = _bi2.FindFirstIndexGreaterThanOrEqualTo<GCE._AFA>(this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH, _ATD) - 1;
            this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = Math.Min(this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count - 1, this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD);
            bool flag3 = this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD == -1;
            if (flag3)
            {
                bool flag4 = this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG && _bg8._BCB;
                if (flag4)
                {
                    this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count - 1;
                    this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count == 1;
                }
                else
                {
                    this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = 0;
                    this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = true;
                }
            }
            else
            {
                this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count == 1;
            }
            this.ShowSearchResult(this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD);
        }

        // Token: 0x060002F3 RID: 755 RVA: 0x00031F00 File Offset: 0x00030100
        private void SearchNext()
        {
            bool flag = this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH != this._ABQ._ASJ;
            if (flag)
            {
                this.SetSearchText(this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
            }
            GCE._AFA _ATD = this._ABH;
            bool flag2 = this._ATW() != null && this._ATW() > this._ABH;
            if (flag2)
            {
                _ATD = this._ATW();
            }
            this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = _bi2.FindFirstIndexGreaterThanOrEqualTo<GCE._AFA>(this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH, _ATD);
            this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = Math.Max(0, this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD);
            bool flag3 = this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD >= this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count;
            if (flag3)
            {
                bool flag4 = this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG && _bg8._BCB;
                if (flag4)
                {
                    this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = 0;
                    this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count == 1;
                }
                else
                {
                    this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count - 1;
                    this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = true;
                }
            }
            else
            {
                this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count == 1;
            }
            this.ShowSearchResult(this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD);
        }

        // Token: 0x060002F4 RID: 756 RVA: 0x00032024 File Offset: 0x00030224
        private void ShowSearchResult(int index)
        {
            bool flag = !this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA;
            if (flag)
            {
                this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = true;
                this.AddRecentLocation(0, true);
            }
            bool flag2 = this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH != this._ABQ._ASJ;
            if (flag2)
            {
                this.SetSearchText(this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
            }
            bool flag3 = index >= 0 && index < this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count;
            if (flag3)
            {
                this.PingText(this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH[index], this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD.Length, this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG ? _bi2.LPOHMAKKMINPLMFKLACCFKJDLPMPAPBBAECP : _bi2._ALN);
            }
        }

        // Token: 0x060002F5 RID: 757 RVA: 0x000320C8 File Offset: 0x000302C8
        private int CharIndexToColumn(int charIndex, int line)
        {
            bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
            int num2;
            if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
            {
                List<int> softLineBreaks = this.GetSoftLineBreaks(line);
                int num = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(softLineBreaks, charIndex);
                num2 = this._ABQ.CharIndexToColumn(charIndex, line, (num > 0) ? softLineBreaks[num - 1] : 0);
            }
            else
            {
                num2 = this._ABQ.CharIndexToColumn(charIndex, line);
            }
            return num2;
        }

        // Token: 0x060002F6 RID: 758 RVA: 0x00032124 File Offset: 0x00030324
        public void PingText(GCE._AFA startPosition, int numChars, Color color)
        {
            this.CloseAllPopups();
            startPosition = startPosition.Clone();
            bool flag = startPosition._ABI >= this._ABQ.FLOg.Count;
            if (flag)
            {
                startPosition._ABI = this._ABQ.FLOg.Count - 1;
            }
            string text = this._ABQ.FLOg[startPosition._ABI];
            startPosition._AEU = Mathf.Min(startPosition._AEU, text.Length);
            this._ATL(startPosition.Clone());
            this._ATW()._ATG = (this._ATW()._ATF = this.CharIndexToColumn(startPosition._AEU, startPosition._ABI));
            int num = Mathf.Min(this._ATW()._AEU + numChars, text.Length);
            int num2 = this.CharIndexToColumn(num, this._ATW()._ABI);
            this._ABH = new GCE._AFA
            {
                _AEU = startPosition._AEU + numChars,
                _ATG = num2,
                _ATF = num2,
                _ABI = this._ATW()._ABI
            };
            this._ATM = _bi2._ATN;
            Vector2 vector = this.BufferToViewPosition(this._ATW());
            this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF = new Rect(vector.x, vector.y + this.GetLineOffset(this._ATW()._ABI), this.GetTextWidth(this._ATW()._ABI, this._ATW()._AEU, num, vector.x), this._AEY().y);
            int kggnbkifblghnondpjanhfhhhjflkghelefk = this._ATW()._AEU;
            this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 1f;
            this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO = _bi2._ATN;
            numChars = Mathf.Min(numChars, text.Length - kggnbkifblghnondpjanhfhhhjflkghelefk);
            this.ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML.text = text.Substring(kggnbkifblghnondpjanhfhhhjflkghelefk, numChars);
            this.FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH = color;
            this.Repaint();
        }

        // Token: 0x060002F7 RID: 759 RVA: 0x0003230C File Offset: 0x0003050C
        internal static void RepaintAllInstances()
        {
            _bb6.RepaintAllWindows();
        }

        // Token: 0x060002F8 RID: 760 RVA: 0x00032315 File Offset: 0x00030515
        private static void ToggleHighlightCurrentLine()
        {
            _bg8._AZY.Toggle();
        }

        // Token: 0x060002F9 RID: 761 RVA: 0x00032323 File Offset: 0x00030523
        private static void ToggleFrameCurrentLine()
        {
            _bg8._AZX.Toggle();
        }

        // Token: 0x060002FA RID: 762 RVA: 0x00032334 File Offset: 0x00030534
        private static void ToggleLineNumbersCode()
        {
            bool flag = _bh3.IsFocused();
            if (flag)
            {
                _bg8._BBN.Toggle();
            }
            else
            {
                _bg8._BAB.Toggle();
            }
        }

        // Token: 0x060002FB RID: 763 RVA: 0x00032364 File Offset: 0x00030564
        private static void ToggleLineNumbersText()
        {
            bool flag = _bh3.IsFocused();
            if (flag)
            {
                _bg8._BBO.Toggle();
            }
            else
            {
                _bg8._BAC.Toggle();
            }
        }

        // Token: 0x060002FC RID: 764 RVA: 0x00032394 File Offset: 0x00030594
        private static void ToggleTrackChangesCode()
        {
            bool flag = _bh3.IsFocused();
            if (flag)
            {
                _bg8._BBP.Toggle();
            }
            else
            {
                _bg8._BAD.Toggle();
            }
        }

        // Token: 0x060002FD RID: 765 RVA: 0x000323C4 File Offset: 0x000305C4
        private static void ToggleTrackChangesText()
        {
            bool flag = _bh3.IsFocused();
            if (flag)
            {
                _bg8._BBQ.Toggle();
            }
            else
            {
                _bg8._BAE.Toggle();
            }
        }

        // Token: 0x060002FE RID: 766 RVA: 0x000323F4 File Offset: 0x000305F4
        private static void ToggleWordWrapText()
        {
            bool flag = _bh3.IsFocused();
            if (flag)
            {
                _bg8._BBS.Toggle();
            }
            else
            {
                _bg8._BAA.Toggle();
            }
        }

        // Token: 0x060002FF RID: 767 RVA: 0x00032424 File Offset: 0x00030624
        private static void ToggleWordWrapCode()
        {
            bool flag = _bh3.IsFocused();
            if (flag)
            {
                _bg8._BBR.Toggle();
            }
            else
            {
                _bg8._AZZ.Toggle();
            }
        }

        // Token: 0x06000300 RID: 768 RVA: 0x00032454 File Offset: 0x00030654
        private static void SelectTheme(int themeIndex, bool forText)
        {
            if (forText)
            {
                _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF = _bi2.BPDG[themeIndex];
                _bi2.ApplyTheme(_bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM, _bi2.BPDG[themeIndex]);
                _bg8._BBX._AIF(_bi2.BGBI[themeIndex]);
            }
            else
            {
                _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN = _bi2.BPDG[themeIndex];
                _bi2.ApplyTheme(_bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE, _bi2.BPDG[themeIndex]);
                _bg8._BBW._AIF(_bi2.BGBI[themeIndex]);
            }
            _bi2.RepaintAllInstances();
        }

        // Token: 0x06000301 RID: 769 RVA: 0x000324EC File Offset: 0x000306EC
        [MenuItem("Window/Super Editor/Reset Font Size", false, 600)]
        internal static void ResetFontSize()
        {
            _bg8._AEP._AIF(-2);
            _bi2.PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL = true;
            _bi2.LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH = true;
            bool flag = _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ABV != null;
            if (flag)
            {
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ABV.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACK.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACF.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACN.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACB.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACE.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACC.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.fontSize = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ABV.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACK.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACF.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACN.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACB.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACE.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ACC.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontStyle = 0;
                _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.fontStyle = 0;
            }
            bool flag2 = _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ABV != null;
            if (flag2)
            {
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ABV.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACK.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACF.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACN.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACB.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACE.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACC.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.fontSize = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ABV.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACK.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACF.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACN.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACB.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACE.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ACC.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI.fontStyle = 0;
                _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM.KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP.fontStyle = 0;
            }
        }

        // Token: 0x06000302 RID: 770 RVA: 0x00032919 File Offset: 0x00030B19
        private static void SelectFont(int fontIndex)
        {
            _bi2.PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL = true;
            _bi2.LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH = true;
            _bg8._BBT._AIF(_bi2.LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[fontIndex]);
        }

        // Token: 0x06000303 RID: 771 RVA: 0x00032940 File Offset: 0x00030B40
        private static void ToggleFontHinting()
        {
            _bi2.PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL = true;
            _bi2.LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH = true;
            _bg8._BBU.Toggle();
        }

        // Token: 0x06000304 RID: 772 RVA: 0x0003295A File Offset: 0x00030B5A
        private void ModifyFontSize(int delta)
        {
            _bi2.PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL = true;
            _bi2.LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH = true;
            _bg8._AEP._AIF(Math.Max(-10, Math.Min(10, _bg8._AEP + Math.Sign(delta))));
        }

        // Token: 0x06000305 RID: 773 RVA: 0x00032994 File Offset: 0x00030B94
        private static void About()
        {
            _be2 window = EditorWindow.GetWindow<_be2>(true);
            window.ShowAuxWindow();
        }

        // Token: 0x06000306 RID: 774 RVA: 0x000329B0 File Offset: 0x00030BB0
        private static void InitCustomThemes()
        {
            _bi2.JMFFKMDENDGHKKBOFMDHJLMPKAKCGLBLJIFP = new List<ThemeTemplate>();
            string text = _bi2.NPOF() + "/Themes";
            bool flag = !AssetDatabase.IsValidFolder(text);
            if (!flag)
            {
                string[] array = AssetDatabase.FindAssets("t:ThemeTemplate", new string[] { text });
                bool flag2 = array.Length != 0;
                if (flag2)
                {
                    foreach (string text2 in array)
                    {
                        _bi2.JMFFKMDENDGHKKBOFMDHJLMPKAKCGLBLJIFP.Add(AssetDatabase.LoadAssetAtPath<ThemeTemplate>(AssetDatabase.GUIDToAssetPath(text2)));
                    }
                }
            }
        }

        // Token: 0x06000307 RID: 775 RVA: 0x00032A40 File Offset: 0x00030C40
        private static void NewTheme()
        {
            string text = _bi2.NPOF() + "/Themes";
            bool flag = !AssetDatabase.IsValidFolder(text);
            if (flag)
            {
                AssetDatabase.CreateFolder(_bi2.NPOF(), "Themes");
            }
            ThemeTemplate themeTemplate = ScriptableObject.CreateInstance<ThemeTemplate>();
            _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN().Add(themeTemplate);
            ProjectWindowUtil.CreateAsset(themeTemplate, text + "/Theme.asset");
        }

        // Token: 0x06000308 RID: 776 RVA: 0x00032AA0 File Offset: 0x00030CA0
        internal static void RepaintChangedTheme(bool isText)
        {
            bool flag = _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN() == null;
            if (!flag)
            {
                foreach (ThemeTemplate themeTemplate in _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN())
                {
                    bool changed = themeTemplate.changed;
                    if (changed)
                    {
                        if (isText)
                        {
                            _bi2.ApplyTheme(_bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM, _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF);
                        }
                        else
                        {
                            _bi2.ApplyTheme(_bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE, _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN);
                        }
                        _bi2.RepaintAllInstances();
                        themeTemplate.changed = false;
                    }
                }
            }
        }

        // Token: 0x06000309 RID: 777 RVA: 0x00032B44 File Offset: 0x00030D44
        internal static void RepaintAllThemes()
        {
            int num = _bi2.BGBI.IndexOf(_bg8._BBX);
            int num2 = _bi2.BGBI.IndexOf(_bg8._BBW);
            _bi2.LoadStyles(_bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM, true);
            _bi2.LoadStyles(_bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE, false);
            bool flag = num > 0;
            if (flag)
            {
                _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF = _bi2.BPDG[num];
                _bi2.ApplyTheme(_bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM, _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF);
            }
            bool flag2 = num2 > 0;
            if (flag2)
            {
                _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN = _bi2.BPDG[num2];
                _bi2.ApplyTheme(_bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE, _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN);
            }
        }

        // Token: 0x0600030A RID: 778 RVA: 0x00032BE8 File Offset: 0x00030DE8
        private float DoToolbar()
        {
            this._AFO.yMin = this._AFO.yMin + 21f;
            Rect rect;
            rect..ctor(this._AFO.xMin, this._AFO.yMin - 21f, this._AFO.width, 21f);
            bool flag = Application.platform == 0;
            bool flag2 = !this.KDLLNFPMJDJLLNBHCKGJIGPICHOPAOFCMKAF.image;
            if (flag2)
            {
                string fileName = Path.GetFileName(this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC());
                bool flag3 = flag;
                if (flag3)
                {
                    this.KDLLNFPMJDJLLNBHCKGJIGPICHOPAOFCMKAF = new GUIContent(_bi2.FJHJMLPMPICJDJHGPHKCHLPDABECAPHNLBDL, "Save " + fileName + "\n(Command+S)");
                    this.HAIFADBGDJMADHMOCHGILGGMCJCPGEODJBPH = new GUIContent(_bi2.IKAJMFCHNHPALEOMJJLHJFIOOABGCPIIBMMF, "Undo\n(Command+Z)");
                    this.JPLMCBDFMNFFHLLHIAECHLBFKNLEGBEOLBBC = new GUIContent(_bi2.PKNNMKEEKOEEDPPADOBGGMNPANFDLFEKELML, "Redo\n(Shift+Command+Z)");
                }
                else
                {
                    this.KDLLNFPMJDJLLNBHCKGJIGPICHOPAOFCMKAF = new GUIContent(_bi2.FJHJMLPMPICJDJHGPHKCHLPDABECAPHNLBDL, "Save " + fileName + "\n(Ctrl+S)");
                    this.HAIFADBGDJMADHMOCHGILGGMCJCPGEODJBPH = new GUIContent(_bi2.IKAJMFCHNHPALEOMJJLHJFIOOABGCPIIBMMF, "Undo\n(Ctrl+Z)");
                    this.JPLMCBDFMNFFHLLHIAECHLBFKNLEGBEOLBBC = new GUIContent(_bi2.PKNNMKEEKOEEDPPADOBGGMNPANFDLFEKELML, "Redo\n(Ctrl+Shift+Z)");
                }
            }
            Color color = GUI.color;
            GUI.contentColor = EditorStyles.toolbarButton.normal.textColor;
            Vector2 vector;
            vector..ctor(27f, 21f);
            GUI.enabled = this.CanEdit() && this._ALW();
            Rect rect2;
            rect2..ctor(rect.xMin, rect.yMin, vector.x, vector.y);
            bool flag4 = GUI.Button(rect2, this.KDLLNFPMJDJLLNBHCKGJIGPICHOPAOFCMKAF, EditorStyles.toolbarButton);
            if (flag4)
            {
                this.SaveBuffer();
            }
            GUI.enabled = this.CanUndo();
            rect2..ctor(rect2.xMax, rect.yMin, vector.x, vector.y);
            bool flag5 = GUI.Button(rect2, this.HAIFADBGDJMADHMOCHGILGGMCJCPGEODJBPH, EditorStyles.toolbarButton);
            if (flag5)
            {
                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                this.Undo();
            }
            GUI.enabled = this.CanRedo();
            rect2..ctor(rect2.xMax, rect.yMin, vector.x, vector.y);
            bool flag6 = GUI.Button(rect2, this.JPLMCBDFMNFFHLLHIAECHLBFKNLEGBEOLBBC, EditorStyles.toolbarButton);
            if (flag6)
            {
                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                this.Redo();
            }
            GUI.contentColor = color;
            rect2.xMin = rect2.xMax + 8f;
            rect2.xMax = rect.xMax - 25f;
            bool flag7 = Event.current.type == 7;
            if (flag7)
            {
                string text = (this._ABQ._ARV() ? "Loading..." : ((!EditorApplication.isCompiling && _bc5._AOO() && !this._ABQ._ALW()) ? ((Application.platform == null) ? "Saved,Press Command+S to compile" : "Saved,Press Ctrl+S to compile") : ((!EditorApplication.isCompiling) ? null : ((_bi2.CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL.Count > 0) ? "Compiling in background..." : ((_bi2.MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN == 0) ? "Compiling..." : ((this._ALW() && flag) ? "Cmd-Alt-R to reload assemblies..." : (this._ALW() ? "Ctrl+R to reload assemblies..." : (flag ? "Cmd-Alt-R or Save again to reload assemblies..." : "Ctrl+R or Save again to reload assemblies..."))))))));
                bool flag8 = text == null && rect2.width > 300f;
                if (flag8)
                {
                    FileInfo fileInfo = new FileInfo(this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC());
                    GUI.enabled = false;
                    bool flag9 = !fileInfo.Exists;
                    if (flag9)
                    {
                        EditorStyles.label.Draw(rect2, "(Not Found)", false, false, false, false);
                    }
                    else
                    {
                        GUI.enabled = false;
                        bool flag10 = _bg8._BAS;
                        if (flag10)
                        {
                            EditorStyles.label.Draw(rect2, "Last modified at " + fileInfo.LastWriteTime.ToString(), false, false, false, false);
                        }
                        else
                        {
                            bool flag11 = _bg8._BAU;
                            if (flag11)
                            {
                                EditorStyles.label.Draw(rect2, this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC(), false, false, false, false);
                            }
                            else
                            {
                                bool flag12 = _bg8._BAV;
                                if (flag12)
                                {
                                    EditorStyles.label.Draw(rect2, "File size is " + Math.Ceiling((double)fileInfo.Length / 1024.0).ToString() + " KB", false, false, false, false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    GUI.enabled = true;
                    bool flag13 = this.NADMKBHKCNFNCNCBDFLCHFIPGKOGNONBFNIL == null;
                    if (flag13)
                    {
                        this.NADMKBHKCNFNCNCBDFLCHFIPGKOGNONBFNIL = new GUIStyle(EditorStyles.boldLabel);
                        this.NADMKBHKCNFNCNCBDFLCHFIPGKOGNONBFNIL.normal.textColor = (EditorGUIUtility.isProSkin ? new Color(1f, 0.5f, 0f) : new Color(0.9f, 0.4f, 0f));
                    }
                    this.NADMKBHKCNFNCNCBDFLCHFIPGKOGNONBFNIL.Draw(rect2, text, false, false, false, false);
                }
            }
            GUI.enabled = this.CanEdit();
            bool flag14 = rect2.width > 300f;
            if (flag14)
            {
                rect2.xMin = rect2.xMax * 0.618f;
            }
            this.DoSearchBox(rect2);
            this.ANOBINGJIAOEAFAMODAAAGGONPMOKEGBCMLJ = new GUIContent(EditorGUIUtility.IconContent("Settings").image, "Settings");
            vector = EditorStyles.toolbarButton.CalcSize(this.ANOBINGJIAOEAFAMODAAAGGONPMOKEGBCMLJ);
            Rect rect3;
            rect3..ctor(rect.xMax - 25f, rect.yMin, vector.x, vector.y);
            bool flag15 = GUI.Button(rect3, this.ANOBINGJIAOEAFAMODAAAGGONPMOKEGBCMLJ, EditorStyles.toolbarButton);
            if (flag15)
            {
                GenericMenu genericMenu = new GenericMenu();
                _bi2.InitCustomThemes();
                bool flag16 = _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN().Count > 0;
                if (flag16)
                {
                    foreach (ThemeTemplate themeTemplate in _bi2.NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN())
                    {
                        _bi2.AddTheme(themeTemplate.colorTheme, themeTemplate.name);
                    }
                }
                _bi2.RemoveTheme();
                bool flag17 = this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF == null;
                bool fcbalhajjbkhbjlanclocpgjfliaieoolbjk = this._ABQ._ARR;
                if (fcbalhajjbkhbjlanclocpgjfliaieoolbjk)
                {
                    genericMenu.AddItem(new GUIContent("View Options/Word Wrap"), flag17 ? _bg8._BBS : _bg8._BAA, new GenericMenu.MenuFunction(_bi2.ToggleWordWrapText));
                    genericMenu.AddItem(new GUIContent("View Options/Highlight Current Line"), _bg8._AZY, new GenericMenu.MenuFunction(_bi2.ToggleHighlightCurrentLine));
                    genericMenu.AddItem(new GUIContent("View Options/Line Numbers"), flag17 ? _bg8._BBO : _bg8._BAC, new GenericMenu.MenuFunction(_bi2.ToggleLineNumbersText));
                    genericMenu.AddItem(new GUIContent("View Options/Track Changes"), flag17 ? _bg8._BBQ : _bg8._BAE, new GenericMenu.MenuFunction(_bi2.ToggleTrackChangesText));
                }
                else
                {
                    genericMenu.AddItem(new GUIContent("View Options/Word Wrap"), flag17 ? _bg8._BBR : _bg8._AZZ, new GenericMenu.MenuFunction(_bi2.ToggleWordWrapCode));
                    genericMenu.AddItem(new GUIContent("View Options/Highlight Current Line"), _bg8._AZY, new GenericMenu.MenuFunction(_bi2.ToggleHighlightCurrentLine));
                    genericMenu.AddItem(new GUIContent("View Options/Line Numbers"), flag17 ? _bg8._BBN : _bg8._BAB, new GenericMenu.MenuFunction(_bi2.ToggleLineNumbersCode));
                    genericMenu.AddItem(new GUIContent("View Options/Track Changes"), flag17 ? _bg8._BBP : _bg8._BAD, new GenericMenu.MenuFunction(_bi2.ToggleTrackChangesCode));
                }
                for (int i = 0; i < _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK().Length; i++)
                {
                    genericMenu.AddItem(new GUIContent("Font/" + Path.GetFileNameWithoutExtension(_bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[i])), _bg8._BBT.GNIO() == _bi2.MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()[i], delegate (object x)
                    {
                        _bi2.SelectFont((int)x);
                    }, i);
                }
                string[] array = _bi2.BGBI.ToArray();
                Array.Sort<string>(array, StringComparer.OrdinalIgnoreCase);
                for (int j = 0; j < array.Length; j++)
                {
                    int num = _bi2.BGBI.IndexOf(array[j]);
                    bool fcbalhajjbkhbjlanclocpgjfliaieoolbjk2 = this._ABQ._ARR;
                    if (fcbalhajjbkhbjlanclocpgjfliaieoolbjk2)
                    {
                        genericMenu.AddItem(new GUIContent("Color Theme/" + array[j]), _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF == _bi2.BPDG[num], delegate (object x)
                        {
                            _bi2.SelectTheme((int)x, true);
                        }, num);
                    }
                    else
                    {
                        genericMenu.AddItem(new GUIContent("Color Theme/" + array[j]), _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN == _bi2.BPDG[num], delegate (object x)
                        {
                            _bi2.SelectTheme((int)x, false);
                        }, num);
                    }
                }
                genericMenu.AddSeparator(string.Empty);
                genericMenu.AddItem(new GUIContent("Settings"), false, new GenericMenu.MenuFunction(_bk4.OpenSettingsWindow));
                genericMenu.AddSeparator(string.Empty);
                genericMenu.AddItem(new GUIContent("Help"), false, new GenericMenu.MenuFunction(_bj2.MenuInitAbout));
                genericMenu.AddSeparator("Color Theme//");
                genericMenu.AddItem(new GUIContent("Color Theme/New Theme..."), false, new GenericMenu.MenuFunction(_bi2.NewTheme));
                genericMenu.AddItem(new GUIContent("Star it!"), false, delegate
                {
                    Application.OpenURL("https://github.com/UnitySuperEditor/SuperEditor");
                });
                rect2..ctor(this._AFO.xMax - 27f, this._AFO.yMin - 17f, 18f, 16f);
                genericMenu.DropDown(rect2);
                GUIUtility.ExitGUI();
            }
            GUI.enabled = true;
            return 20f;
        }

        // Token: 0x0600030B RID: 779 RVA: 0x0003364C File Offset: 0x0003184C
        private void DoSearchBox(Rect position = default(Rect))
        {
            _bi2.JCOIBCPNFDEEEKEJBMMLNNCHKHFFNFMKPGOP = EditorPrefs.GetBool("SuperEditorDynamicSearchbar", false);
            this.SearchBoxEvent(position);
            string text = string.Empty;
            bool flag = position == default(Rect);
            if (flag)
            {
                bool jcoibcpnfdeeekejbmmlnnchkhffnfmkpgop = _bi2.JCOIBCPNFDEEEKEJBMMLNNCHKHFFNFMKPGOP;
                if (jcoibcpnfdeeekejbmmlnnchkhffnfmkpgop)
                {
                    this._AFO.yMin = this._AFO.yMin + 21f;
                    position..ctor(this._AFO.xMin, this._AFO.yMin - 21f, this._AFO.width, 21f);
                    text = this.ToolbarSearchField(position, this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
                    Color color;
                    color..ctor(0f, 0f, 0f, 0.25f);
                    EditorGUI.DrawRect(new Rect(this._AFO.xMin, this._AFO.yMin - 1f, this._AFO.xMin, 1f), color);
                }
            }
            else
            {
                text = this.ToolbarSearchField(position, this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
            }
            bool flag2 = this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD != text;
            if (flag2)
            {
                this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD = text;
                this.SetSearchText(this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD);
            }
        }

        // Token: 0x0600030C RID: 780 RVA: 0x00033788 File Offset: 0x00031988
        private void SearchBoxEvent(Rect position)
        {
            bool flag = Event.current.type == 13;
            if (flag)
            {
                bool flag2 = Event.current.commandName == "Find";
                if (flag2)
                {
                    Event.current.Use();
                    return;
                }
            }
            else
            {
                bool flag3 = Event.current.type == 14;
                if (flag3)
                {
                    bool flag4 = Event.current.commandName == "Find";
                    if (flag4)
                    {
                        bool flag5 = position == default(Rect);
                        if (flag5)
                        {
                            EditorPrefs.SetBool("SuperEditorDynamicSearchbar", true);
                        }
                        bool flag6 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
                        if (flag6)
                        {
                            this.UseSelectionForSearch();
                        }
                        this.HNFGMNOKDFHDBOOJNFKJEEHBPKBFIOPLMAGK = true;
                        Event.current.Use();
                    }
                }
            }
            bool flag7 = this._ABQ._ASJ != this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH;
            if (flag7)
            {
                this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = -1;
                this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = false;
            }
            bool flag8 = Event.current.type == 4 && !Event.current.alt;
            if (flag8)
            {
                this.PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM = this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP != null && this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP.HasFocus();
                bool flag9 = Application.platform == 0;
                bool flag10 = Event.current.keyCode == 284 && !EditorGUI.actionKey;
                if (flag10)
                {
                    bool shift = Event.current.shift;
                    if (shift)
                    {
                        this.SearchPrevious();
                    }
                    else
                    {
                        this.SearchNext();
                    }
                    Event.current.Use();
                }
                EventModifiers eventModifiers = Event.current.modifiers & -113;
                bool flag11 = Event.current.keyCode == 115 && (eventModifiers == 2 || eventModifiers == 8);
                if (flag11)
                {
                    Event.current.Use();
                    this.SaveBuffer();
                }
            }
            bool flag12 = Event.current.rawType == 5 && (Event.current.keyCode == 27 || Event.current.keyCode == 9);
            if (flag12)
            {
                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                Event.current.Use();
            }
            bool flag13 = this.PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM && Event.current.type == 4;
            if (flag13)
            {
                bool flag14 = Event.current.keyCode == 27;
                if (flag14)
                {
                    EditorPrefs.SetBool("SuperEditorDynamicSearchbar", false);
                    Event.current.Use();
                    this.PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM = false;
                }
                else
                {
                    bool flag15 = Event.current.keyCode == 273 || (Event.current.shift && (Event.current.keyCode == 13 || Event.current.keyCode == 271));
                    if (flag15)
                    {
                        this.SearchPrevious();
                        this.HNFGMNOKDFHDBOOJNFKJEEHBPKBFIOPLMAGK = true;
                        Event.current.Use();
                    }
                    else
                    {
                        bool flag16 = Event.current.keyCode == 274 || (!Event.current.shift && (Event.current.keyCode == 13 || Event.current.keyCode == 271));
                        if (flag16)
                        {
                            this.SearchNext();
                            this.HNFGMNOKDFHDBOOJNFKJEEHBPKBFIOPLMAGK = true;
                            Event.current.Use();
                        }
                        else
                        {
                            bool flag17 = Event.current.keyCode == 9;
                            if (flag17)
                            {
                                Event.current.Use();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600030D RID: 781 RVA: 0x00033AF8 File Offset: 0x00031CF8
        private string ToolbarSearchField(Rect position, string text)
        {
            bool flag = this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE == null;
            if (flag)
            {
                this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE = new GUIStyle(this._ABT._ABV);
                this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.font = EditorStyles.textField.font;
                this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.fontSize = EditorStyles.textField.fontSize - 1;
                this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.alignment = 5;
                this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.normal.textColor = (EditorGUIUtility.isProSkin ? new Color(0.824f, 0.824f, 0.824f, 1f) : new Color(0.035f, 0.035f, 0.035f, 1f));
            }
            bool flag2 = this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP == null;
            if (flag2)
            {
                this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP = new SearchField();
            }
            Rect rect = position;
            rect.width -= 50f;
            rect.y += 2f;
            bool flag3 = _bi2.JCOIBCPNFDEEEKEJBMMLNNCHKHFFNFMKPGOP && !_bg8._BAR;
            if (flag3)
            {
                rect.x += 2f;
                rect.width -= 24f;
            }
            text = this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP.OnToolbarGUI(rect, text);
            bool hnfgmnokdfhdboojnfkjeehbpkbfioplmagk = this.HNFGMNOKDFHDBOOJNFKJEEHBPKBFIOPLMAGK;
            if (hnfgmnokdfhdboojnfkjeehbpkbfioplmagk)
            {
                this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP.SetFocus();
                bool flag4 = Event.current.type == 7;
                if (flag4)
                {
                    this.HNFGMNOKDFHDBOOJNFKJEEHBPKBFIOPLMAGK = false;
                }
            }
            bool flag5 = !string.IsNullOrEmpty(text);
            if (flag5)
            {
                GUI.enabled = false;
                rect.width -= 16f;
                rect.y -= 2f;
                bool flag6 = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count > 0;
                if (flag6)
                {
                    bool flag7 = this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD == null || this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count != this.JJIAPPLKBPOHJIJHNMNENIKEMLNDFKILKHKH || this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD != this.KOGJPGADGOFLMJHNPBMLJCOIKHJCKGHKKNAF;
                    if (flag7)
                    {
                        this.KOGJPGADGOFLMJHNPBMLJCOIKHJCKGHKKNAF = this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD;
                        this.JJIAPPLKBPOHJIJHNMNENIKEMLNDFKILKHKH = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count;
                        this.FBMOFGALBJNAKOJCGHOMPOIAOMOHKNPFLACL = ((this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD >= 0) ? ((this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD + 1).ToString() + " of " + this.JJIAPPLKBPOHJIJHNMNENIKEMLNDFKILKHKH.ToString()) : (this.JJIAPPLKBPOHJIJHNMNENIKEMLNDFKILKHKH.ToString() + " results")) + "\u00a0";
                    }
                    float x = this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.CalcSize(new GUIContent(text)).x;
                    float x2 = this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.CalcSize(new GUIContent(this.FBMOFGALBJNAKOJCGHOMPOIAOMOHKNPFLACL)).x;
                    bool flag8 = x + x2 < rect.width - 16f;
                    if (flag8)
                    {
                        EditorGUI.LabelField(rect, this.FBMOFGALBJNAKOJCGHOMPOIAOMOHKNPFLACL, this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE);
                    }
                }
                else
                {
                    float x3 = this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.CalcSize(new GUIContent(text)).x;
                    float x4 = this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.CalcSize(new GUIContent("no results")).x;
                    bool flag9 = x3 + x4 < rect.width - 16f;
                    if (flag9)
                    {
                        EditorGUI.LabelField(rect, "no results\u00a0", this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE);
                    }
                }
                GUI.enabled = true;
                rect.width += 16f;
                rect.y += 2f;
            }
            else
            {
                bool flag10 = !this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP.HasFocus();
                if (flag10)
                {
                    this.FBMOFGALBJNAKOJCGHOMPOIAOMOHKNPFLACL = ((Application.platform == null) ? "command + F" : "ctrl + F");
                    GUI.enabled = false;
                    rect.x += 16f;
                    rect.y -= 3f;
                    this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.alignment = 3;
                    EditorGUI.LabelField(rect, this.FBMOFGALBJNAKOJCGHOMPOIAOMOHKNPFLACL, this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE);
                    this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE.alignment = 5;
                    GUI.enabled = true;
                    rect.x -= 16f;
                    rect.y += 3f;
                }
            }
            rect.y -= 2f;
            rect.width += 62f;
            this.PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM = this.EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP.HasFocus();
            bool flag11 = text == string.Empty;
            bool flag12 = !this.PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM && !flag11 && text.Trim() == "";
            if (flag12)
            {
                GUI.Label(rect, text.Replace("\t", "<tab>").Replace(" ", "<space>"), this._ABT.GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE);
            }
            rect.width = 24f;
            rect.x += position.width - 48f;
            bool flag13 = _bi2.JCOIBCPNFDEEEKEJBMMLNNCHKHFFNFMKPGOP && !_bg8._BAR;
            if (flag13)
            {
                rect.x -= 24f;
            }
            bool flag14 = !flag11 && this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count != 0;
            if (flag14)
            {
                bool flag15 = GUI.Button(rect, new GUIContent("<", "Search Previous\n(UpArrow)"), EditorStyles.toolbarButton);
                if (flag15)
                {
                    this.SearchPrevious();
                }
                rect.x += 24f;
                bool flag16 = GUI.Button(rect, new GUIContent(">", "Search Next\n(DownArrow)"), EditorStyles.toolbarButton);
                if (flag16)
                {
                    this.SearchNext();
                }
                rect.x += 24f;
            }
            else
            {
                GUI.enabled = false;
                GUI.Button(rect, new GUIContent("<", "Search Previous"), EditorStyles.toolbarButton);
                rect.x += 24f;
                GUI.Button(rect, new GUIContent(">", "Search Next"), EditorStyles.toolbarButton);
                rect.x += 24f;
                GUI.enabled = true;
            }
            bool flag17 = _bi2.JCOIBCPNFDEEEKEJBMMLNNCHKHFFNFMKPGOP && !_bg8._BAR && GUI.Button(rect, new GUIContent("x"), EditorStyles.toolbarButton);
            if (flag17)
            {
                text = string.Empty;
                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                EditorPrefs.SetBool("SuperEditorDynamicSearchbar", false);
            }
            return text;
        }

        // Token: 0x0600030E RID: 782 RVA: 0x000341E0 File Offset: 0x000323E0
        private void UseSelectionForSearch()
        {
            string searchTextFromSelection = this.GetSearchTextFromSelection();
            bool flag = searchTextFromSelection != "";
            if (flag)
            {
                this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD = searchTextFromSelection;
                this.SetSearchText(searchTextFromSelection);
            }
        }

        // Token: 0x0600030F RID: 783 RVA: 0x00034218 File Offset: 0x00032418
        private void SetSearchText(string text)
        {
            this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH = this._ABQ._ASJ;
            _bi2.FNABLFJGDDBBCLNCLGLMABBFIFELKOGMEFFJ = text;
            this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Clear();
            this.HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = -1;
            int length = text.Length;
            bool flag = length == 0;
            if (flag)
            {
                this.Repaint();
            }
            else
            {
                List<string> flogicchcfaljohninkpcdacoidcghkimhpo = this._ABQ.FLOg;
                for (int i = 0; i < flogicchcfaljohninkpcdacoidcghkimhpo.Count; i++)
                {
                    string text2 = flogicchcfaljohninkpcdacoidcghkimhpo[i];
                    int num = 0;
                    while ((num = text2.IndexOf(text, num, StringComparison.OrdinalIgnoreCase)) != -1)
                    {
                        int num2 = this._ABQ.CharIndexToColumn(num, i);
                        GCE._AFA _ATD = new GCE._AFA
                        {
                            _ABI = i,
                            _AEU = num,
                            _ATG = num2,
                            _ATF = num2
                        };
                        this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Add(_ATD);
                        num += length;
                    }
                }
                this.LPDHPJNAHLLADJCFMGCEECABJMPHIPPIFMPC = text != "";
                this.Repaint();
            }
        }

        // Token: 0x06000310 RID: 784 RVA: 0x00034320 File Offset: 0x00032520
        private void ProcessEditorKeyboard(Event current, bool acceptingAutoComplete)
        {
            this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM = null;
            bool flag = !this.CanEdit();
            if (!flag)
            {
                bool flag2 = current.type == 4 && current.keyCode != 306 && current.keyCode != 305 && current.keyCode != 310 && current.keyCode != 309 && current.keyCode != 304 && current.keyCode != 303;
                if (flag2)
                {
                    this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 0f;
                }
                bool flag3 = true;
                bool flag4 = Application.platform == 0;
                bool flag5 = Application.platform == 16;
                bool flag6 = Application.platform == 7;
                EventModifiers eventModifiers = current.modifiers & -113;
                bool flag7 = (current.modifiers & (flag4 ? 8 : 2)) > 0;
                int num = -1;
                int num2 = -1;
                bool flag8 = flag4 && current.type == 4;
                if (flag8)
                {
                    bool flag9 = current.keyCode == 122;
                    if (flag9)
                    {
                        bool flag10 = eventModifiers == 2 || eventModifiers == 8 || eventModifiers == 12;
                        if (flag10)
                        {
                            this.Undo();
                            current.Use();
                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                            return;
                        }
                        bool flag11 = eventModifiers == 3 || eventModifiers == 9 || eventModifiers == 13;
                        if (flag11)
                        {
                            this.Redo();
                            current.Use();
                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                            return;
                        }
                    }
                    else
                    {
                        bool flag12 = (current.keyCode == 97 && eventModifiers == 2) || (current.keyCode == 276 && flag7 && (eventModifiers & 4) == 0);
                        if (flag12)
                        {
                            current.Use();
                            Event @event = Event.KeyboardEvent("home");
                            @event.modifiers = eventModifiers & 1;
                            this.ProcessEditorKeyboard(@event, false);
                            return;
                        }
                        bool flag13 = (current.keyCode == 101 && eventModifiers == 2) || (current.keyCode == 275 && flag7 && (eventModifiers & 4) == 0);
                        if (flag13)
                        {
                            current.Use();
                            Event event2 = Event.KeyboardEvent("end");
                            event2.modifiers = eventModifiers & 1;
                            this.ProcessEditorKeyboard(event2, false);
                            return;
                        }
                        bool flag14 = current.keyCode == 115 && (eventModifiers == 2 || eventModifiers == 8);
                        if (flag14)
                        {
                            current.Use();
                            this.SaveBuffer();
                            return;
                        }
                        bool flag15 = current.keyCode == 114 && eventModifiers == 9;
                        if (flag15)
                        {
                            current.Use();
                            this.CommandFindAllReferences();
                            return;
                        }
                        bool flag16 = current.keyCode == 103 && eventModifiers == 2;
                        if (flag16)
                        {
                            current.Use();
                            EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                            {
                                _b4.Create(this);
                            }));
                            return;
                        }
                        bool flag17 = current.keyCode == 274 && eventModifiers == 12;
                        if (flag17)
                        {
                            this.CommandDuplicateLinesDown();
                            current.Use();
                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                            return;
                        }
                    }
                }
                bool flag18 = current.type == 4 && !current.shift && !current.alt && (flag4 ? (!current.control) : (!current.command));
                if (flag18)
                {
                    bool flag19 = (flag7 && current.keyCode == 39) || (!flag4 && !current.control && current.keyCode == 282);
                    if (flag19)
                    {
                        string text = this.HelpURL();
                        bool flag20 = text != null;
                        if (flag20)
                        {
                            current.Use();
                            bool flag21 = text.StartsWith("file:///unity/ScriptReference/", StringComparison.OrdinalIgnoreCase);
                            if (flag21)
                            {
                                Help.ShowHelpPage(text);
                            }
                            else
                            {
                                Help.BrowseURL(text);
                            }
                        }
                    }
                    else
                    {
                        bool flag22 = (flag4 && current.command && current.keyCode == 121) || (!current.control && !current.command && current.keyCode == 293);
                        if (flag22)
                        {
                            current.Use();
                            bool flag23 = _bi2._AKS && this.CanGoBack();
                            if (flag23)
                            {
                                _bi2._AKS = false;
                                this.GoToRecentLocation(false);
                                return;
                            }
                            flag3 = false;
                            int _ARC = this._ABH._ABI;
                            this.GoToDefinition();
                            bool flag24 = _ARC != this._ABH._ABI;
                            if (flag24)
                            {
                                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                                {
                                    _bi2._AKS = true;
                                }));
                            }
                        }
                        else
                        {
                            bool flag25 = (flag4 ? (current.command && (current.keyCode == 108 || current.keyCode == 103)) : (current.control && current.keyCode == 103));
                            if (flag25)
                            {
                                current.Use();
                                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                                {
                                    _b4.Create(this);
                                }));
                                return;
                            }
                            bool flag26 = (flag4 ? (current.command && current.keyCode == 101) : (current.control && current.keyCode == 101));
                            if (flag26)
                            {
                                current.Use();
                                this.ExecuteStaticMethod();
                                return;
                            }
                        }
                    }
                }
                bool flag27 = flag7 && current.type == 4;
                if (flag27)
                {
                    EventModifiers eventModifiers2 = eventModifiers & -11;
                    bool flag28 = current.keyCode == 32 && eventModifiers2 == 0;
                    if (flag28)
                    {
                        current.Use();
                        this.Autocomplete(false);
                        return;
                    }
                    bool flag29 = current.keyCode == 116 && eventModifiers2 == 0;
                    if (flag29)
                    {
                        current.Use();
                        EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(this.OpenInNewTab));
                        return;
                    }
                    bool flag30 = (current.keyCode == 107 || current.keyCode == 47) && eventModifiers2 == 0;
                    if (flag30)
                    {
                        current.Use();
                        this.ToggleCommentSelection();
                        return;
                    }
                    bool flag31 = flag5 && current.keyCode == 122 && eventModifiers == 2;
                    if (flag31)
                    {
                        current.Use();
                        this.Undo();
                        this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                        return;
                    }
                    bool flag32 = flag5 && current.keyCode == 122 && eventModifiers == 3;
                    if (flag32)
                    {
                        current.Use();
                        this.Redo();
                        this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                        return;
                    }
                    bool flag33 = flag6 && current.keyCode == 122 && eventModifiers2 == 1;
                    if (flag33)
                    {
                        current.Use();
                        this.Undo();
                        this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                        return;
                    }
                    bool flag34 = flag6 && current.keyCode == 121 && eventModifiers2 == 1;
                    if (flag34)
                    {
                        current.Use();
                        this.Redo();
                        this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                        return;
                    }
                    bool flag35 = current.keyCode == 115 && (eventModifiers2 & -2) == 4;
                    if (flag35)
                    {
                        current.Use();
                        _bi2.MenuReloadAssemblies();
                        this.Repaint();
                        return;
                    }
                    bool flag36 = current.keyCode == 115 && eventModifiers2 == 4;
                    if (flag36)
                    {
                        current.Use();
                        this.SaveBuffer();
                        return;
                    }
                    bool flag37 = current.keyCode == 102 && (eventModifiers2 & -5) == 1;
                    if (flag37)
                    {
                        current.Use();
                        _bg3.ShowFindInFilesWindow();
                        return;
                    }
                    bool flag38 = current.keyCode == 114 && (eventModifiers2 & -5) != 1;
                    if (flag38)
                    {
                        current.Use();
                        _bg3.ShowReplaceInFilesWindow();
                        return;
                    }
                    bool flag39 = current.keyCode == 114 && eventModifiers2 == (flag4 ? 4 : 1);
                    if (flag39)
                    {
                        current.Use();
                        _bi2.MenuReloadAssemblies();
                        this.Repaint();
                        return;
                    }
                    bool flag40 = current.keyCode == 108 && (eventModifiers2 & -5) == 1;
                    if (flag40)
                    {
                        current.Use();
                        Assembly assembly = typeof(EditorWindow).Assembly;
                        EditorWindow.GetWindow(assembly.GetType("UnityEditor.ProjectBrowser"));
                        bool flag41 = this._ALP != null;
                        if (flag41)
                        {
                            EditorGUIUtility.PingObject(this._ALP._AKT);
                            this._ALP.Focus();
                        }
                        else
                        {
                            EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(this._ABQ._ARQ()));
                            this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.Focus();
                        }
                        return;
                    }
                    bool flag42 = !current.alt;
                    if (flag42)
                    {
                        bool flag43 = current.keyCode == 45 || current.keyCode == 269;
                        if (flag43)
                        {
                            current.Use();
                            this.ModifyFontSize(-1);
                            return;
                        }
                        bool flag44 = current.keyCode == 43 || current.keyCode == 61 || current.keyCode == 270;
                        if (flag44)
                        {
                            current.Use();
                            this.ModifyFontSize(1);
                            return;
                        }
                    }
                }
                bool flag45 = current.type == 4;
                if (flag45)
                {
                    bool flag46 = (eventModifiers == 8 || eventModifiers == 2) && (current.keyCode == 46 || current.keyCode == 266);
                    if (flag46)
                    {
                        bool mljcflpnjpehbilbamiacglghfegimgdpmnb = this._ABQ._ASC;
                        if (mljcflpnjpehbilbamiacglghfegimgdpmnb)
                        {
                            int num3;
                            int i;
                            bool flag47;
                            SyntaxToken token = this._ABQ.GetTokenAt(this._ABH, out num3, out i, out flag47);
                            List<SyntaxToken> _ABS = this._ABQ._AQQ[num3].EOIA;
                            bool flag48 = token != null;
                            if (flag48)
                            {
                                bool flag49 = flag47 && token.tokenKind != SyntaxToken.Kind.Identifier && token.tokenKind != SyntaxToken.Kind.ContextualKeyword && token.tokenKind != SyntaxToken.Kind.Keyword;
                                if (flag49)
                                {
                                    bool flag50 = i < _ABS.Count - 1;
                                    if (flag50)
                                    {
                                        token = _ABS[i + 1];
                                    }
                                }
                            }
                            i = -1;
                            while (i < _ABS.Count)
                            {
                                bool flag51 = token != null && token.OOME != null && token.OOME._AAB() != null && token.OOME._AJF == "unknown symbol";
                                if (flag51)
                                {
                                    List<_AQA> fixes = _bc9.GetFixes(this._ABQ, token);
                                    bool flag52 = fixes.Count > 0;
                                    if (flag52)
                                    {
                                        current.Use();
                                        GenericMenu genericMenu = new GenericMenu();
                                        foreach (_AQA kclolinkdgmfifeiidoolpiiejameegabmlg in fixes)
                                        {
                                            _AQA captured = kclolinkdgmfifeiidoolpiiejameegabmlg;
                                            genericMenu.AddItem(new GUIContent(captured.GetTitle(token)), false, delegate
                                            {
                                                this.BeginRefactoring(captured.GetTitle(token));
                                                captured.Apply(this, token);
                                                this.EndRefactoring();
                                            });
                                        }
                                        Rect tokenRect = this.GetTokenRect(token);
                                        tokenRect.x += this._AFO.x - this._AFS.x;
                                        tokenRect.y += 4f + this._AFO.y - this._AFS.y;
                                        Vector2 vector = GUIUtility.ScreenToGUIPoint(new Vector2(tokenRect.x, tokenRect.y));
                                        tokenRect.x += vector.x - tokenRect.x;
                                        tokenRect.y += vector.y - tokenRect.y;
                                        genericMenu.DropDown(tokenRect);
                                        this._ATM = _bi2._ATN;
                                        this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                        this._ATO = true;
                                        this.AddRecentLocation(2, true);
                                        return;
                                    }
                                }
                                i++;
                                token = ((i < _ABS.Count) ? _ABS[i] : null);
                            }
                        }
                    }
                }
                bool flag53 = flag4 && current.type == 4 && current.keyCode == 115 && eventModifiers == 6;
                if (flag53)
                {
                    current.Use();
                    this.SaveBuffer();
                }
                else
                {
                    bool flag54 = current.type == 4 && current.keyCode == 293 && eventModifiers == 1;
                    if (flag54)
                    {
                        current.Use();
                        this.CommandFindAllReferences();
                    }
                    else
                    {
                        bool flag55 = (_bg8._BCF ? ((eventModifiers & 6) > 0) : (flag4 ? ((eventModifiers & 2) > 0) : flag7));
                        bool flag56 = false;
                        bool flag57 = _bg8._BCG && !_bg8._BCF;
                        if (flag57)
                        {
                            flag56 = true;
                        }
                        else
                        {
                            bool flag58 = _bg8._BCF;
                            if (flag58)
                            {
                                flag56 = (eventModifiers & 6) == (flag4 ? 2 : 4);
                            }
                        }
                        int num4 = this._ABH._AEU;
                        int num5 = this._ABH._ATF;
                        int num6 = this._ABH._ABI;
                        bool flag59 = false;
                        bool flag60 = false;
                        bool flag61 = current.type == 4;
                        if (flag61)
                        {
                            KeyCode keyCode = current.keyCode;
                            KeyCode keyCode2 = keyCode;
                            if (keyCode2 <= 27)
                            {
                                if (keyCode2 != 13)
                                {
                                    if (keyCode2 == 27)
                                    {
                                        flag3 = false;
                                        bool flag62 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                                        if (flag62)
                                        {
                                            this.CloseAutocomplete();
                                            current.Use();
                                        }
                                        else
                                        {
                                            bool flag63 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                                            if (flag63)
                                            {
                                                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.Hide();
                                                this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB = null;
                                                current.Use();
                                            }
                                            else
                                            {
                                                bool flag64 = !string.IsNullOrEmpty(this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD) && this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH == this._ABQ._ASJ;
                                                if (flag64)
                                                {
                                                    this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH = -1;
                                                    this.IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = false;
                                                    current.Use();
                                                }
                                                else
                                                {
                                                    bool flag65 = this._ATW() != null;
                                                    if (flag65)
                                                    {
                                                        flag60 = true;
                                                        current.Use();
                                                    }
                                                    else
                                                    {
                                                        bool flag66 = _bg8._BAO;
                                                        if (flag66)
                                                        {
                                                            current.Use();
                                                            this.Autocomplete(false);
                                                            return;
                                                        }
                                                        bool flag67 = this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != null;
                                                        if (flag67)
                                                        {
                                                            this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = null;
                                                            current.Use();
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                switch (keyCode2)
                                {
                                    case 271:
                                        {
                                            bool flag68 = flag7 && EditorWindow.focusedWindow;
                                            if (flag68)
                                            {
                                                bool flag69 = Application.platform == 0;
                                                if (flag69)
                                                {
                                                    current.Use();
                                                    EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("OpenAtCursor"));
                                                    GUIUtility.ExitGUI();
                                                }
                                                return;
                                            }
                                            break;
                                        }
                                    case 272:
                                    case 277:
                                        break;
                                    case 273:
                                        {
                                            bool flag70 = flag4 && eventModifiers == 8;
                                            if (flag70)
                                            {
                                                flag59 = true;
                                                num6 = 0;
                                                num4 = 0;
                                            }
                                            else
                                            {
                                                bool flag71 = eventModifiers == 4;
                                                if (flag71)
                                                {
                                                    int num7 = this._ABH._ABI;
                                                    int num8 = ((this._ATW() != null) ? this._ATW()._ABI : this._ABH._ABI);
                                                    bool flag72 = num8 < num7;
                                                    if (flag72)
                                                    {
                                                        int num9 = num8;
                                                        num8 = num7;
                                                        num7 = num9;
                                                    }
                                                    bool flag73 = this._ATW() != null;
                                                    if (flag73)
                                                    {
                                                        bool flag74 = this._ATW() > this._ABH && this._ATW()._AEU == 0;
                                                        if (flag74)
                                                        {
                                                            num8--;
                                                        }
                                                        else
                                                        {
                                                            bool flag75 = this._ATW() < this._ABH && this._ABH._AEU == 0;
                                                            if (flag75)
                                                            {
                                                                num8--;
                                                            }
                                                        }
                                                    }
                                                    bool flag76 = num7 > 0;
                                                    if (!flag76)
                                                    {
                                                        return;
                                                    }
                                                    string text2 = this._ABQ.FLOg[num7 - 1];
                                                    GCE._AFA _ATD = new GCE._AFA
                                                    {
                                                        _ABI = num7,
                                                        _AEU = 0,
                                                        _ATG = 0,
                                                        _ATF = 0
                                                    };
                                                    GCE._AFA _ATD2 = _ATD.Clone();
                                                    _ATD2._ABI--;
                                                    this._ABQ.DeleteText(_ATD2, _ATD);
                                                    _ATD = new GCE._AFA
                                                    {
                                                        _ABI = num8 - 1,
                                                        _AEU = this._ABQ.FLOg[num8 - 1].Length
                                                    };
                                                    _ATD._ATG = (_ATD._ATF = this.CharIndexToColumn(_ATD._AEU, _ATD._ABI));
                                                    this._ABQ.InsertText(_ATD, "\n" + text2);
                                                    num6 = this._ABH._ABI - 1;
                                                    num5 = this._ABH._ATG;
                                                    num4 = this._ABH._AEU;
                                                    bool flag77 = this._ATW() != null;
                                                    if (flag77)
                                                    {
                                                        eventModifiers |= 1;
                                                        this._ATL(this._ATW().Clone());
                                                        this._ATW()._ABI--;
                                                    }
                                                    this._ABQ.UpdateHighlighting(num7 - 1, num8, false);
                                                    num = num7 - 1;
                                                    num2 = num8 - 1;
                                                }
                                                else
                                                {
                                                    bool flag78 = !current.control && !flag7;
                                                    if (flag78)
                                                    {
                                                        bool flag79 = !current.shift && this._ATW() != null && this._ATW()._ABI < num6;
                                                        if (flag79)
                                                        {
                                                            this._ABH = this._ATW().Clone();
                                                        }
                                                        GCE._AFA linesOffset = this.GetLinesOffset(this._ABH, -1);
                                                        num6 = linesOffset._ABI;
                                                        num5 = linesOffset._ATF;
                                                        num4 = linesOffset._AEU;
                                                    }
                                                    else
                                                    {
                                                        bool flag80 = !current.shift;
                                                        if (flag80)
                                                        {
                                                            this._AFS.y = this._AFS.y - this._AEY().y;
                                                            bool flag81 = this._AFS.y < 0f;
                                                            if (flag81)
                                                            {
                                                                this._AFS.y = 0f;
                                                            }
                                                            this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                                            this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                                            this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                                            current.Use();
                                                            return;
                                                        }
                                                        this.UseSelectionForSearch();
                                                        this.SearchPrevious();
                                                        current.Use();
                                                        this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                                        return;
                                                    }
                                                }
                                            }
                                            current.Use();
                                            flag3 = false;
                                            break;
                                        }
                                    case 274:
                                        {
                                            bool flag82 = flag4 && eventModifiers == 8;
                                            if (flag82)
                                            {
                                                flag59 = true;
                                                num6 = this._ABQ.FLOg.Count - 1;
                                                num4 = this._ABQ.FLOg[num6].Length;
                                            }
                                            else
                                            {
                                                bool flag83 = eventModifiers == 4;
                                                if (flag83)
                                                {
                                                    int num10 = this._ABH._ABI;
                                                    int num11 = ((this._ATW() != null) ? this._ATW()._ABI : this._ABH._ABI);
                                                    bool flag84 = num11 < num10;
                                                    if (flag84)
                                                    {
                                                        int num12 = num11;
                                                        num11 = num10;
                                                        num10 = num12;
                                                    }
                                                    bool flag85 = this._ATW() != null;
                                                    if (flag85)
                                                    {
                                                        bool flag86 = this._ATW() > this._ABH && this._ATW()._AEU == 0;
                                                        if (flag86)
                                                        {
                                                            num11--;
                                                        }
                                                        else
                                                        {
                                                            bool flag87 = this._ATW() < this._ABH && this._ABH._AEU == 0;
                                                            if (flag87)
                                                            {
                                                                num11--;
                                                            }
                                                        }
                                                    }
                                                    bool flag88 = num11 < this._ABQ.FLOg.Count - 1;
                                                    if (!flag88)
                                                    {
                                                        return;
                                                    }
                                                    string text3 = this._ABQ.FLOg[num11 + 1];
                                                    GCE._AFA _ATD3 = new GCE._AFA
                                                    {
                                                        _ABI = num11,
                                                        _AEU = this._ABQ.FLOg[num11].Length
                                                    };
                                                    _ATD3._ATG = (_ATD3._ATF = this.CharIndexToColumn(_ATD3._AEU, _ATD3._ABI));
                                                    GCE._AFA _ATD4 = new GCE._AFA
                                                    {
                                                        _ABI = num11 + 1,
                                                        _AEU = this._ABQ.FLOg[num11 + 1].Length
                                                    };
                                                    _ATD4._ATG = (_ATD4._ATF = this.CharIndexToColumn(_ATD4._AEU, _ATD4._ABI));
                                                    this._ABQ.DeleteText(_ATD3, _ATD4);
                                                    _ATD3 = new GCE._AFA
                                                    {
                                                        _ABI = num10,
                                                        _AEU = 0,
                                                        _ATG = 0,
                                                        _ATF = 0
                                                    };
                                                    this._ABQ.InsertText(_ATD3, text3 + "\n");
                                                    num6 = this._ABH._ABI + 1;
                                                    num5 = this._ABH._ATG;
                                                    num4 = this._ABH._AEU;
                                                    bool flag89 = this._ATW() != null;
                                                    if (flag89)
                                                    {
                                                        eventModifiers |= 1;
                                                        this._ATL(this._ATW().Clone());
                                                        this._ATW()._ABI++;
                                                    }
                                                    this._ABQ.UpdateHighlighting(num10, num11 + 1, false);
                                                    num = num10 + 1;
                                                    num2 = num11 + 1;
                                                }
                                                else
                                                {
                                                    bool flag90 = !current.control && !flag7;
                                                    if (flag90)
                                                    {
                                                        bool flag91 = !current.shift && this._ATW() != null && this._ATW()._ABI > num6;
                                                        if (flag91)
                                                        {
                                                            this._ABH = this._ATW().Clone();
                                                        }
                                                        GCE._AFA linesOffset2 = this.GetLinesOffset(this._ABH, 1);
                                                        num6 = linesOffset2._ABI;
                                                        num5 = linesOffset2._ATF;
                                                        num4 = linesOffset2._AEU;
                                                    }
                                                    else
                                                    {
                                                        bool flag92 = !current.shift;
                                                        if (flag92)
                                                        {
                                                            this._AFS.y = this._AFS.y + this._AEY().y;
                                                            this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                                            this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                                            this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                                            current.Use();
                                                            return;
                                                        }
                                                        this.UseSelectionForSearch();
                                                        this.SearchNext();
                                                        current.Use();
                                                        this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                                        return;
                                                    }
                                                }
                                            }
                                            current.Use();
                                            flag3 = false;
                                            break;
                                        }
                                    case 275:
                                        {
                                            bool flag93 = eventModifiers == (4 | (_bg8._BCF ? (flag4 ? 8 : 2) : 0));
                                            if (flag93)
                                            {
                                                current.Use();
                                                bool flag94 = this.CanGoForward();
                                                if (flag94)
                                                {
                                                    this.GoToRecentLocation(true);
                                                }
                                                return;
                                            }
                                            flag59 = true;
                                            flag3 = false;
                                            bool flag95 = !current.shift && !flag55 && this._ATW() != null;
                                            if (flag95)
                                            {
                                                bool flag96 = this._ATW() > this._ABH;
                                                if (flag96)
                                                {
                                                    num6 = this._ATW()._ABI;
                                                    num5 = this._ATW()._ATG;
                                                    num4 = this._ATW()._AEU;
                                                }
                                                else
                                                {
                                                    flag60 = true;
                                                }
                                                current.Use();
                                            }
                                            else
                                            {
                                                bool flag97 = flag55;
                                                if (flag97)
                                                {
                                                    GCE._AFA _ATD5 = this._ABQ.WordStopRight(this._ABH, flag56);
                                                    num6 = _ATD5._ABI;
                                                    num5 = _ATD5._ATG;
                                                    num4 = _ATD5._AEU;
                                                    current.Use();
                                                }
                                                else
                                                {
                                                    bool flag98 = num6 >= 0;
                                                    if (flag98)
                                                    {
                                                        num4++;
                                                        bool flag99 = num4 > this._ABQ.FLOg[num6].Length;
                                                        if (flag99)
                                                        {
                                                            bool flag100 = ++num6 < this._ABQ._ASK;
                                                            if (flag100)
                                                            {
                                                                num4 = 0;
                                                            }
                                                            else
                                                            {
                                                                num6--;
                                                                num4--;
                                                            }
                                                        }
                                                    }
                                                    current.Use();
                                                }
                                            }
                                            break;
                                        }
                                    case 276:
                                        {
                                            bool flag101 = eventModifiers == (4 | (_bg8._BCF ? (flag4 ? 8 : 2) : 0));
                                            if (flag101)
                                            {
                                                current.Use();
                                                bool flag102 = this.CanGoBack();
                                                if (flag102)
                                                {
                                                    this.GoToRecentLocation(false);
                                                }
                                                return;
                                            }
                                            flag59 = true;
                                            flag3 = false;
                                            bool flag103 = !current.shift && !flag55 && this._ATW() != null;
                                            if (flag103)
                                            {
                                                bool flag104 = this._ATW() < this._ABH;
                                                if (flag104)
                                                {
                                                    num6 = this._ATW()._ABI;
                                                    num5 = this._ATW()._ATG;
                                                    num4 = this._ATW()._AEU;
                                                }
                                                else
                                                {
                                                    flag60 = true;
                                                }
                                                current.Use();
                                            }
                                            else
                                            {
                                                bool flag105 = flag55;
                                                if (flag105)
                                                {
                                                    GCE._AFA _ATD6 = this._ABQ.WordStopLeft(this._ABH, flag56);
                                                    num6 = _ATD6._ABI;
                                                    num5 = _ATD6._ATG;
                                                    num4 = _ATD6._AEU;
                                                    current.Use();
                                                }
                                                else
                                                {
                                                    num4--;
                                                    bool flag106 = num4 < 0;
                                                    if (flag106)
                                                    {
                                                        bool flag107 = --num6 >= 0;
                                                        if (flag107)
                                                        {
                                                            num4 = this._ABQ.FLOg[num6].Length;
                                                        }
                                                        else
                                                        {
                                                            num6 = 0;
                                                            num4 = 0;
                                                        }
                                                    }
                                                    current.Use();
                                                }
                                            }
                                            break;
                                        }
                                    case 278:
                                        {
                                            bool flag108 = flag7;
                                            if (flag108)
                                            {
                                                flag59 = true;
                                                num6 = 0;
                                                num4 = 0;
                                            }
                                            else
                                            {
                                                flag59 = true;
                                                int num13 = this._ABQ.FirstNonWhitespace(num6);
                                                bool flag109 = num13 == this._ABQ.FLOg[num6].Length;
                                                if (flag109)
                                                {
                                                    num13 = 0;
                                                }
                                                bool flag110 = num4 == num13;
                                                if (flag110)
                                                {
                                                    num4 = 0;
                                                }
                                                else
                                                {
                                                    num4 = num13;
                                                }
                                                flag3 = false;
                                            }
                                            current.Use();
                                            break;
                                        }
                                    case 279:
                                        {
                                            bool flag111 = flag7;
                                            if (flag111)
                                            {
                                                flag59 = true;
                                                num6 = this._ABQ.FLOg.Count - 1;
                                                num4 = this._ABQ.FLOg[num6].Length;
                                            }
                                            else
                                            {
                                                flag59 = true;
                                                bool flag112 = !current.shift && this._ATW() != null;
                                                if (flag112)
                                                {
                                                    bool flag113 = this._ATW()._ABI > num6;
                                                    if (flag113)
                                                    {
                                                        num6 = this._ATW()._ABI;
                                                    }
                                                }
                                                num4 = this._ABQ.FLOg[num6].Length;
                                                flag3 = false;
                                            }
                                            current.Use();
                                            break;
                                        }
                                    case 280:
                                        {
                                            bool flag114 = flag7;
                                            if (flag114)
                                            {
                                                flag59 = true;
                                                num6 = 0;
                                                num4 = 0;
                                            }
                                            else
                                            {
                                                GCE._AFA linesOffset3 = this.GetLinesOffset(this._ABH, -(int)(this._ALM.height / this._AEY().y));
                                                num6 = linesOffset3._ABI;
                                                num5 = linesOffset3._ATF;
                                                num4 = linesOffset3._AEU;
                                                this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLinesOffset(new GCE._AFA
                                                {
                                                    _ABI = this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE
                                                }, -(int)(this._ALM.height / this._AEY().y))._ABI;
                                                _bi2.JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM = true;
                                                flag3 = false;
                                            }
                                            current.Use();
                                            break;
                                        }
                                    case 281:
                                        {
                                            bool flag115 = flag7;
                                            if (flag115)
                                            {
                                                flag59 = true;
                                                num6 = this._ABQ.FLOg.Count - 1;
                                                num4 = this._ABQ.FLOg[num6].Length;
                                            }
                                            else
                                            {
                                                GCE._AFA linesOffset4 = this.GetLinesOffset(this._ABH, (int)(this._ALM.height / this._AEY().y));
                                                num6 = linesOffset4._ABI;
                                                num5 = linesOffset4._ATF;
                                                num4 = linesOffset4._AEU;
                                                this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLinesOffset(new GCE._AFA
                                                {
                                                    _ABI = this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE
                                                }, (int)(this._ALM.height / this._AEY().y))._ABI;
                                                _bi2.JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM = true;
                                                flag3 = false;
                                            }
                                            current.Use();
                                            break;
                                        }
                                    default:
                                        if (keyCode2 != 326)
                                        {
                                            if (keyCode2 == 327)
                                            {
                                                current.Use();
                                                bool flag116 = this.CanGoForward();
                                                if (flag116)
                                                {
                                                    this.GoToRecentLocation(true);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            current.Use();
                                            bool flag117 = this.CanGoBack();
                                            if (flag117)
                                            {
                                                this.GoToRecentLocation(false);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        bool flag118 = current.shift && current.keyCode == 32;
                        if (flag118)
                        {
                            current.Use();
                            flag3 = false;
                        }
                        bool flag119 = current.type == 4;
                        if (flag119)
                        {
                            bool flag120 = eventModifiers == 2 && current.character == ' ';
                            if (flag120)
                            {
                                current.Use();
                                return;
                            }
                            bool flag121 = flag7 && (current.character == '\n' || current.keyCode == 13) && !current.shift && !current.alt;
                            if (flag121)
                            {
                                this.AddRecentLocation(1, true);
                                bool flag122 = EditorWindow.focusedWindow;
                                if (flag122)
                                {
                                    this.OpenAtCursor();
                                }
                                current.Use();
                                return;
                            }
                            bool flag123 = (current.keyCode == 9 || current.character == '\t' || current.character == '\u0019') && (eventModifiers & -2) == 0;
                            if (flag123)
                            {
                                bool flag124 = current.keyCode != 9;
                                if (flag124)
                                {
                                    bool flag125 = eventModifiers == 1;
                                    if (flag125)
                                    {
                                        this.IndentLess();
                                    }
                                    else
                                    {
                                        this.IndentMoreOrInsertTab(!acceptingAutoComplete);
                                    }
                                    this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                    this._ATM = _bi2._ATN;
                                    this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                    this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                }
                                current.Use();
                                return;
                            }
                            bool flag126 = flag7 && (current.keyCode == 91 || current.keyCode == 93);
                            if (flag126)
                            {
                                bool flag127 = current.keyCode == 91;
                                if (flag127)
                                {
                                    this.IndentLess();
                                }
                                else
                                {
                                    this.IndentMore();
                                }
                                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                this._ATM = _bi2._ATN;
                                this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                current.Use();
                                return;
                            }
                            bool flag128 = (current.character >= ' ' || current.character == '\n' || (current.character == '\0' && Input.compositionString != "")) && (!flag7 || ((eventModifiers & 8) == null && current.keyCode == null)) && this.TryEdit();
                            if (flag128)
                            {
                                char character = current.character;
                                bool flag129 = character == '\n' && eventModifiers == 1 && this._ATW() == null;
                                if (flag129)
                                {
                                    this._ABH._AEU = this._ABQ.FLOg[this._ABH._ABI].Length;
                                }
                                string text4 = ((character != '\0') ? character.ToString() : Input.compositionString);
                                string text5 = null;
                                TextPosition textPosition = TextPosition.invalid;
                                bool flag130 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count > 0 && "}])\">".IndexOf(character) != -1;
                                if (flag130)
                                {
                                    bool flag131 = this._ATW() == null;
                                    if (flag131)
                                    {
                                        TextPosition textPosition2 = this._ABQ.FirstNonWhitespacePos(this._ABH._ABI, this._ABH._AEU);
                                        bool flag132 = textPosition2 == this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Last<_bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA>().AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB && this._ABQ.FLOg[textPosition2.line][textPosition2.index] == character;
                                        if (flag132)
                                        {
                                            this._ATL(new GCE._AFA
                                            {
                                                _ABI = textPosition2.line,
                                                _AEU = textPosition2.index + 1
                                            });
                                            this._ATW()._ATG = (this._ATW()._ATF = this.CharIndexToColumn(this._ATW()._AEU, this._ATW()._ABI));
                                            this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.RemoveAt(this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count - 1);
                                            bool flag133 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count == 0;
                                            if (flag133)
                                            {
                                                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                                                cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK = (GCE._AVI)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK, new GCE._AVI(this.OnInsertedText));
                                                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
                                                cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO = (GCE._AVM)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO, new GCE._AVM(this.OnRemovedText));
                                            }
                                        }
                                    }
                                }
                                bool flag134 = !acceptingAutoComplete && this._ATW() == null && "{[(\"<".IndexOf(character) != -1;
                                if (flag134)
                                {
                                    text5 = this.CheckAutoClose(character);
                                }
                                else
                                {
                                    bool flag135 = character == '\n';
                                    if (flag135)
                                    {
                                        int num14 = this._ABQ.FirstNonWhitespace(this._ABH._ABI);
                                        bool flag136 = num14 > this._ABH._AEU;
                                        if (flag136)
                                        {
                                            num14 = this._ABH._AEU;
                                        }
                                        string text6 = this._ABQ.FLOg[this._ABH._ABI].Substring(0, num14);
                                        text4 += text6;
                                        bool flag137 = this._ABH._AEU > 0;
                                        if (flag137)
                                        {
                                            SyntaxToken nonTriviaTokenLeftOf = this._ABQ.GetNonTriviaTokenLeftOf(this._ABH._ABI, this._ABH._AEU);
                                            bool flag138 = nonTriviaTokenLeftOf != null && nonTriviaTokenLeftOf.tokenKind == SyntaxToken.Kind.Punctuator && nonTriviaTokenLeftOf.text == "{" && nonTriviaTokenLeftOf.OOME != null && nonTriviaTokenLeftOf.OOME.line == this._ABH._ABI;
                                            if (flag138)
                                            {
                                                _bb4.DHBA _AEM = nonTriviaTokenLeftOf.OOME.FindNextLeaf();
                                                bool flag139 = _AEM != null && _AEM.line == this._ABH._ABI && _AEM.IsLit("}");
                                                if (flag139)
                                                {
                                                    text5 = text4;
                                                    bool flag140 = _bg8._BBG;
                                                    if (flag140)
                                                    {
                                                        bool flag141 = nonTriviaTokenLeftOf.TokenIndex > 1 || (nonTriviaTokenLeftOf.TokenIndex == 1 && nonTriviaTokenLeftOf.AIGN.EOIA[0].tokenKind != SyntaxToken.Kind.Whitespace);
                                                        if (flag141)
                                                        {
                                                            textPosition = this._ABQ.GetTokenSpan(nonTriviaTokenLeftOf.OOME).StartPosition;
                                                        }
                                                    }
                                                }
                                                text4 += "\t";
                                            }
                                            else
                                            {
                                                bool flag142 = nonTriviaTokenLeftOf != null && nonTriviaTokenLeftOf.tokenKind == SyntaxToken.Kind.StringLiteral;
                                                if (flag142)
                                                {
                                                    char c = this._ABQ.FLOg[this._ABH._ABI][this._ABH._AEU - 1];
                                                    bool flag143 = c != '"' && c != '\\';
                                                    if (flag143)
                                                    {
                                                        text4 = "\" +" + text4 + "\"";
                                                    }
                                                }
                                                else
                                                {
                                                    bool flag144 = nonTriviaTokenLeftOf == null || nonTriviaTokenLeftOf.Line < this._ABH._ABI;
                                                    if (flag144)
                                                    {
                                                        string xmldocsText = this.GetXMLDocsText(this._ABH._ABI);
                                                        bool flag145 = xmldocsText != null && this._ABH._AEU >= this._ABQ.FLOg[this._ABH._ABI].Length - xmldocsText.Length;
                                                        if (flag145)
                                                        {
                                                            bool flag146 = xmldocsText.TrimStart(Array.Empty<char>()) != "";
                                                            if (flag146)
                                                            {
                                                                text4 += "/// ";
                                                            }
                                                            else
                                                            {
                                                                string xmldocsText2 = this.GetXMLDocsText(this._ABH._ABI + 1);
                                                                bool flag147 = xmldocsText2 != null;
                                                                if (flag147)
                                                                {
                                                                    text4 += "/// ";
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        bool flag148 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                                        if (flag148)
                                        {
                                            this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB._AEW(true);
                                        }
                                    }
                                }
                                GCE._AFA _ATD7 = this._ABH.Clone();
                                bool flag149 = this._ATW() != null;
                                if (flag149)
                                {
                                    _ATD7 = this._ABQ.DeleteText(this._ATW(), this._ABH);
                                    flag60 = true;
                                }
                                int _ARC2 = _ATD7._ABI;
                                bool flag150 = current.character == '\n' && !acceptingAutoComplete;
                                if (flag150)
                                {
                                    string text7 = this._ABQ.FLOg[_ARC2];
                                    int length = text7.Length;
                                    int num15 = 0;
                                    while (num15 + _ATD7._AEU < length)
                                    {
                                        bool flag151 = char.IsWhiteSpace(text7[num15 + _ATD7._AEU]);
                                        if (!flag151)
                                        {
                                            break;
                                        }
                                        num15++;
                                    }
                                    bool flag152 = num15 > 0;
                                    if (flag152)
                                    {
                                        GCE._AFA _ATD8 = _ATD7.Clone();
                                        _ATD8._AEU += num15;
                                        this._ABQ.DeleteText(_ATD7, _ATD8);
                                    }
                                }
                                bool flag153 = character == '\0';
                                if (flag153)
                                {
                                    this._ATL(_ATD7.Clone());
                                    flag60 = false;
                                }
                                _ATD7 = this._ABQ.InsertText(_ATD7, text4);
                                int num16 = _ATD7._ABI;
                                bool flag154 = !acceptingAutoComplete && text5 != null;
                                if (flag154)
                                {
                                    _bc5._AOM = true;
                                    num16 = this._ABQ.InsertText(_ATD7, text5)._ABI;
                                    bool flag155 = textPosition.line >= 0;
                                    if (flag155)
                                    {
                                        GCE._AFA _ATD9 = new GCE._AFA();
                                        _ATD9.Set(textPosition.line, textPosition.index, 0);
                                        this._ABQ.InsertText(_ATD9, text5);
                                        _ATD7._ABI++;
                                        num16++;
                                        textPosition = TextPosition.invalid;
                                    }
                                    _bc5._AOM = false;
                                    bool flag156 = character != '\n';
                                    if (flag156)
                                    {
                                        _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA epaffddcaeggcpdgeebebadboblmgpdeplea = new _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA
                                        {
                                            OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND = new TextPosition(this._ABH._ABI, this._ABH._AEU),
                                            AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB = new TextPosition(this._ABH._ABI, this._ABH._AEU + 1)
                                        };
                                        this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Add(epaffddcaeggcpdgeebebadboblmgpdeplea);
                                        bool flag157 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count == 1;
                                        if (flag157)
                                        {
                                            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj3 = this._ABQ;
                                            cdghkglnkfhjenlebomgbogcmlafoejmngmj3._AUO = (GCE._AVM)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj3._AUO, new GCE._AVM(this.OnRemovedText));
                                            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj4 = this._ABQ;
                                            cdghkglnkfhjenlebomgbogcmlafoejmngmj4._AUK = (GCE._AVI)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj4._AUK, new GCE._AVI(this.OnInsertedText));
                                        }
                                    }
                                }
                                num4 = _ATD7._AEU;
                                num5 = _ATD7._ATG;
                                num6 = _ATD7._ABI;
                                flag59 = true;
                                bool flag158 = !acceptingAutoComplete;
                                if (flag158)
                                {
                                    this._ABQ.UpdateHighlighting(_ARC2, num16, false);
                                }
                                bool flag159 = character != '\0' && character != ' ' && !acceptingAutoComplete;
                                if (flag159)
                                {
                                    num = _ARC2;
                                    num2 = num16;
                                }
                                eventModifiers &= -2;
                                current.Use();
                                bool flag160 = !acceptingAutoComplete;
                                if (flag160)
                                {
                                    this.AfterCharecterTyped(text4, num6, num4);
                                    this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                                }
                                this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM = text4;
                            }
                            else
                            {
                                bool flag161 = current.keyCode == 127 && eventModifiers == 1 && this._ATW() == null && this.TryEdit();
                                if (flag161)
                                {
                                    eventModifiers = 0;
                                    bool flag162 = this._ABH._ABI == this._ABQ._ASK - 1;
                                    if (flag162)
                                    {
                                        this._ABQ.FLOg[this._ABH._ABI] = string.Empty;
                                        num4 = 0;
                                        num5 = 0;
                                    }
                                    else
                                    {
                                        this._ABQ.DeleteText(new GCE._AFA
                                        {
                                            _AEU = 0,
                                            _ATG = 0,
                                            _ATF = 0,
                                            _ABI = this._ABH._ABI
                                        }, new GCE._AFA
                                        {
                                            _AEU = 0,
                                            _ATG = 0,
                                            _ATF = 0,
                                            _ABI = this._ABH._ABI + 1
                                        });
                                        num5 = this._ABH._ATG;
                                        num4 = this._ABQ.ColumnToCharIndex(ref num5, this._ABH._ABI);
                                    }
                                    flag60 = true;
                                    this._ABQ.UpdateHighlighting(this._ABH._ABI, this._ABH._ABI, false);
                                    current.Use();
                                }
                                else
                                {
                                    bool flag163 = (current.keyCode == 8 || current.keyCode == 127) && this.TryEdit();
                                    if (flag163)
                                    {
                                        eventModifiers &= -2;
                                        GCE._AFA _ATD10 = this._ABH.Clone();
                                        bool flag164 = this._ATW() == null;
                                        if (flag164)
                                        {
                                            Event event3 = new Event(current);
                                            bool flag165 = false;
                                            bool flag166 = current.keyCode == 127;
                                            if (flag166)
                                            {
                                                event3.keyCode = 275;
                                                bool flag167 = this._ABH._AEU == this._ABQ.FLOg[this._ABH._ABI].Length && this._ABH._ABI + 1 < this._ABQ.FLOg.Count;
                                                if (flag167)
                                                {
                                                    string text8 = this._ABQ.FLOg[this._ABH._ABI + 1];
                                                    bool flag168 = text8 != "" && (text8[0] == ' ' || text8[0] == '\t');
                                                    if (flag168)
                                                    {
                                                        event3 = null;
                                                        this._ATL(new GCE._AFA
                                                        {
                                                            _ABI = this._ABH._ABI + 1,
                                                            _AEU = this._ABQ.FirstNonWhitespace(this._ABH._ABI + 1)
                                                        });
                                                        this._ATW()._ATG = this.CharIndexToColumn(this._ATW()._AEU, this._ATW()._ABI);
                                                        this._ATW()._ATF = this._ATW()._ATG;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                event3.keyCode = 276;
                                                flag165 = true;
                                            }
                                            bool flag169 = event3 != null;
                                            if (flag169)
                                            {
                                                event3.modifiers |= 1;
                                                this.ProcessEditorKeyboard(event3, true);
                                            }
                                            bool flag170 = flag165 && this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count > 0;
                                            if (flag170)
                                            {
                                                _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA epaffddcaeggcpdgeebebadboblmgpdeplea2 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Last<_bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA>();
                                                TextPosition ojkljinfjbephbppeabijnjcdopnejgpagnd = epaffddcaeggcpdgeebebadboblmgpdeplea2.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND;
                                                bool flag171 = ojkljinfjbephbppeabijnjcdopnejgpagnd.line == this._ABH._ABI && ojkljinfjbephbppeabijnjcdopnejgpagnd.index == this._ABH._AEU;
                                                if (flag171)
                                                {
                                                    ojkljinfjbephbppeabijnjcdopnejgpagnd.Move(this._ABQ, 1);
                                                    while (ojkljinfjbephbppeabijnjcdopnejgpagnd < epaffddcaeggcpdgeebebadboblmgpdeplea2.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB)
                                                    {
                                                        string text9 = this._ABQ.FLOg[ojkljinfjbephbppeabijnjcdopnejgpagnd.line];
                                                        int num17 = ((ojkljinfjbephbppeabijnjcdopnejgpagnd.line == epaffddcaeggcpdgeebebadboblmgpdeplea2.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line) ? epaffddcaeggcpdgeebebadboblmgpdeplea2.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index : text9.Length);
                                                        while (ojkljinfjbephbppeabijnjcdopnejgpagnd.index < num17)
                                                        {
                                                            bool flag172 = !char.IsWhiteSpace(text9, ojkljinfjbephbppeabijnjcdopnejgpagnd.index);
                                                            if (flag172)
                                                            {
                                                                break;
                                                            }
                                                            ojkljinfjbephbppeabijnjcdopnejgpagnd.index++;
                                                        }
                                                        bool flag173 = ojkljinfjbephbppeabijnjcdopnejgpagnd.index < num17;
                                                        if (flag173)
                                                        {
                                                            break;
                                                        }
                                                        ojkljinfjbephbppeabijnjcdopnejgpagnd.index = 0;
                                                        ojkljinfjbephbppeabijnjcdopnejgpagnd.line++;
                                                    }
                                                    bool flag174 = ojkljinfjbephbppeabijnjcdopnejgpagnd >= epaffddcaeggcpdgeebebadboblmgpdeplea2.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
                                                    if (flag174)
                                                    {
                                                        this._ATL(new GCE._AFA
                                                        {
                                                            _ABI = epaffddcaeggcpdgeebebadboblmgpdeplea2.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.line,
                                                            _AEU = epaffddcaeggcpdgeebebadboblmgpdeplea2.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB.index + 1
                                                        });
                                                        this._ATW()._ATG = (this._ATW()._ATF = this.CharIndexToColumn(this._ATW()._AEU, this._ATW()._ABI));
                                                        this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.RemoveAt(this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count - 1);
                                                        bool flag175 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count == 0;
                                                        if (flag175)
                                                        {
                                                            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj5 = this._ABQ;
                                                            cdghkglnkfhjenlebomgbogcmlafoejmngmj5._AUK = (GCE._AVI)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj5._AUK, new GCE._AVI(this.OnInsertedText));
                                                            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj6 = this._ABQ;
                                                            cdghkglnkfhjenlebomgbogcmlafoejmngmj6._AUO = (GCE._AVM)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj6._AUO, new GCE._AVM(this.OnRemovedText));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        eventModifiers &= -2;
                                        bool flag176 = this._ATW() != null;
                                        if (flag176)
                                        {
                                            _ATD10 = this._ABQ.DeleteText(this._ATW(), this._ABH);
                                            num4 = _ATD10._AEU;
                                            num5 = _ATD10._ATG;
                                            num6 = _ATD10._ABI;
                                            flag59 = true;
                                            flag60 = true;
                                            this._ABQ.UpdateHighlighting(_ATD10._ABI, _ATD10._ABI, false);
                                            current.Use();
                                        }
                                        this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                                    }
                                }
                            }
                        }
                        bool flag177 = current.type == 12;
                        if (flag177)
                        {
                            this._ATM = _bi2._ATN;
                            this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                            bool flag178 = this._ATW() == null && current.shift;
                            if (flag178)
                            {
                                this._ATL(new GCE._AFA
                                {
                                    _ATG = this._ABH._ATG,
                                    _ABI = this._ABH._ABI,
                                    _ATF = this._ABH._ATG,
                                    _AEU = this._ABH._AEU
                                });
                                bool flag179 = !flag59 && num6 != this._ABH._ABI;
                                if (flag179)
                                {
                                    num5 = this._ABH._ATG;
                                }
                            }
                            bool flag180 = num6 < 0;
                            if (flag180)
                            {
                                num6 = 0;
                            }
                            bool flag181 = num6 >= this._ABQ._ASK;
                            if (flag181)
                            {
                                num6 = this._ABQ._ASK - 1;
                            }
                            bool flag182 = flag59;
                            if (flag182)
                            {
                                bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                                {
                                    List<int> softLineBreaks = this.GetSoftLineBreaks(num6);
                                    int num18 = _bi2.FindFirstIndexGreaterThanOrEqualTo<int>(softLineBreaks, num4);
                                    bool flag183 = num18 < softLineBreaks.Count && num4 == softLineBreaks[num18];
                                    if (flag183)
                                    {
                                        num18++;
                                    }
                                    num5 = (this._ABH._ATF = this._ABQ.CharIndexToColumn(num4, num6, (num18 > 0) ? softLineBreaks[num18 - 1] : 0));
                                }
                                else
                                {
                                    num5 = (this._ABH._ATF = this._ABQ.CharIndexToColumn(num4, num6));
                                }
                            }
                            this._ABH._ATG = num5;
                            this._ABH._AEU = num4;
                            this._ABH._ABI = num6;
                            bool flag184 = !flag59 && num6 >= 0;
                            if (flag184)
                            {
                                this._ABH._ATF = num5;
                                this._ABH._ATG = this._ABQ.CharIndexToColumn(this._ABH._AEU, num6);
                            }
                            bool flag185 = current.character != '\0' || Input.compositionString == "";
                            if (flag185)
                            {
                                bool flag186 = flag60 || (this._ATW() != null && ((eventModifiers & 1) == null || this._ATW() == this._ABH));
                                if (flag186)
                                {
                                    this._ATL(null);
                                }
                            }
                            this._ATO = true;
                            this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                            bool flag187 = num >= 0 && num <= num2 && this._ABQ.CanEdit();
                            if (flag187)
                            {
                                this.ReindentLines(num, num2);
                            }
                            bool flag188 = flag3;
                            if (flag188)
                            {
                                this.AddRecentLocation(0, true);
                            }
                            bool flag189 = _bg8._BAQ && !this.IKLLHBOIKJFIAHLFHOEAIKOEOIPKDFMKPMPH && this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM == ";";
                            if (flag189)
                            {
                                this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM = null;
                                SyntaxToken tokenAtPosition = this.GetTokenAtPosition(this._ABH._ABI, this._ABH._AEU);
                                bool flag190 = tokenAtPosition != null && tokenAtPosition.tokenKind == SyntaxToken.Kind.Punctuator;
                                if (flag190)
                                {
                                    List<SyntaxToken> list = this._ABQ._AQQ[tokenAtPosition.Line].EOIA;
                                    int tokenIndex = tokenAtPosition.TokenIndex;
                                    bool flag191 = tokenIndex < list.Count - 1;
                                    if (flag191)
                                    {
                                        bool flag192 = !list.Exists((SyntaxToken t) => t.TokenIndex != tokenIndex && t.tokenKind > SyntaxToken.Kind.LastWSToken && (t.text == "}" || t.text == "{" || t.text == ";" || t.text == "for"));
                                        if (flag192)
                                        {
                                            int num19 = list.FindLastIndex((SyntaxToken t) => t.tokenKind > SyntaxToken.Kind.LastWSToken && t.TokenIndex > tokenIndex);
                                            bool flag193 = num19 > tokenIndex;
                                            if (flag193)
                                            {
                                                this._ABQ.EndEdit();
                                                this._ABQ.BeginEdit("Smart Semicolon Placement");
                                                this.ProcessEditorKeyboard(Event.KeyboardEvent("backspace"), true);
                                                list = this._ABQ._AQQ[this._ABH._ABI].EOIA;
                                                num19 = list.FindLastIndex((SyntaxToken t) => t.tokenKind > SyntaxToken.Kind.LastWSToken);
                                                TextSpan tokenSpan = this._ABQ.GetTokenSpan(this._ABH._ABI, num19);
                                                this._ABH = new GCE._AFA
                                                {
                                                    _ABI = tokenSpan.line,
                                                    _AEU = tokenSpan.EndPosition.index
                                                };
                                                this._ABH._ATG = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI);
                                                this._ABH._ATF = this._ABH._ATG;
                                                this.IKLLHBOIKJFIAHLFHOEAIKOEOIPKDFMKPMPH = true;
                                                this.ProcessEditorKeyboard(Event.KeyboardEvent(";"), false);
                                                this.IKLLHBOIKJFIAHLFHOEAIKOEOIPKDFMKPMPH = false;
                                                this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM = null;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            bool flag194 = this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM == "/";
                            if (flag194)
                            {
                                SyntaxToken tokenAtPosition2 = this.GetTokenAtPosition(this._ABH._ABI, this._ABH._AEU);
                                bool flag195 = tokenAtPosition2 != null && tokenAtPosition2.tokenKind == SyntaxToken.Kind.Comment;
                                if (flag195)
                                {
                                    List<SyntaxToken> _ABS2 = this._ABQ._AQQ[tokenAtPosition2.Line].EOIA;
                                    int tokenIndex2 = tokenAtPosition2.TokenIndex;
                                    bool flag196 = tokenIndex2 >= 1 && tokenIndex2 <= 2 && tokenIndex2 == _ABS2.Count - 1 && tokenAtPosition2.text == "/" && _ABS2[tokenIndex2 - 1].text == "//";
                                    if (flag196)
                                    {
                                        bool flag197 = tokenIndex2 == 1 || _ABS2[0].tokenKind == SyntaxToken.Kind.Whitespace;
                                        if (flag197)
                                        {
                                            SyntaxToken nonTriviaTokenAfter = this._ABQ.GetNonTriviaTokenAfter(tokenAtPosition2);
                                            bool flag198 = nonTriviaTokenAfter != null && nonTriviaTokenAfter.OOME != null && nonTriviaTokenAfter.OOME.OOME != null;
                                            if (flag198)
                                            {
                                                _bb4._ACW _AMI = nonTriviaTokenAfter.OOME.OOME;
                                                _bb4._ACW _AGZ;
                                                for (_AGZ = _AMI; _AGZ != null; _AGZ = _AGZ.OOME)
                                                {
                                                    string text10 = _AGZ._AHB();
                                                    string text11 = text10;
                                                    if (text11 == "namespaceMemberDeclaration" || text11 == "classMemberDeclaration" || text11 == "structMemberDeclaration" || text11 == "interfaceMemberDeclaration")
                                                    {
                                                        bool flag199 = nonTriviaTokenAfter.OOME != _AGZ.GetFirstLeaf();
                                                        if (flag199)
                                                        {
                                                            _AGZ = null;
                                                        }
                                                        else
                                                        {
                                                            _bb4._AIN _AIO;
                                                            if ((_AIO = _AGZ.FindChildByName("methodDeclaration")) == null && (_AIO = _AGZ.FindChildByName("classDeclaration")) == null && (_AIO = _AGZ.FindChildByName("structDeclaration")) == null && (_AIO = _AGZ.FindChildByName("interfaceDeclaration")) == null && (_AIO = _AGZ.FindChildByName("enumDeclaration")) == null && (_AIO = _AGZ.FindChildByName("delegateDeclaration")) == null && (_AIO = _AGZ.FindChildByName("constructorDeclaration")) == null && (_AIO = _AGZ.FindChildByName("destructorDeclaration")) == null && (_AIO = _AGZ.FindChildByName("propertyDeclaration")) == null && (_AIO = _AGZ.FindChildByName("indexerDeclaration")) == null && (_AIO = _AGZ.FindChildByName("fieldDeclaration")) == null && (_AIO = _AGZ.FindChildByName("operatorDeclaration")) == null && (_AIO = _AGZ.FindChildByName("eventDeclaration")) == null && (_AIO = _AGZ.FindChildByName("conversionOperatorDeclaration")) == null && (_AIO = _AGZ.FindChildByName("constantDeclaration")) == null && (_AIO = _AGZ.FindChildByName("interfaceMethodDeclaration")) == null && (_AIO = _AGZ.FindChildByName("interfaceEventDeclaration")) == null && (_AIO = _AGZ.FindChildByName("interfacePropertyDeclaration")) == null)
                                                            {
                                                                _AIO = _AGZ.FindChildByName("interfaceIndexerDeclaration") ?? _AGZ.FindChildByName("enumMemberDeclaration");
                                                            }
                                                            _AGZ = _AIO as _bb4._ACW;
                                                        }
                                                        break;
                                                    }
                                                }
                                                bool flag200 = _AGZ != null;
                                                if (flag200)
                                                {
                                                    this._ABQ.EndEdit();
                                                    this._ABQ.BeginEdit("Autocomplete XMLDocs");
                                                    int _ARC3 = this._ABH._ABI;
                                                    string text12 = ((tokenIndex2 == 1) ? "" : _ABS2[0].text);
                                                    this._ABH = this._ABQ.InsertText(this._ABH, " <summary>\n" + text12 + "/// ");
                                                    StringBuilder stringBuilder = new StringBuilder("\n");
                                                    stringBuilder.Append(text12);
                                                    stringBuilder.Append("/// </summary>");
                                                    _bh4 _AAH = ((_AGZ.EFI != null) ? _AGZ.EFI._ACV : null);
                                                    bool flag201 = _AAH != null;
                                                    if (flag201)
                                                    {
                                                        List<_bd7> typeParameters = _AAH.GetTypeParameters();
                                                        bool flag202 = typeParameters != null;
                                                        if (flag202)
                                                        {
                                                            for (int j = 0; j < typeParameters.Count; j++)
                                                            {
                                                                stringBuilder.Append("\n");
                                                                stringBuilder.Append(text12);
                                                                stringBuilder.Append("/// <typeparam name=\"");
                                                                stringBuilder.Append(typeParameters[j]._AW);
                                                                stringBuilder.Append("\"></typeparam>");
                                                            }
                                                        }
                                                        List<_bm1> parameters = _AAH.GetParameters();
                                                        bool flag203 = parameters != null;
                                                        if (flag203)
                                                        {
                                                            for (int k = 0; k < parameters.Count; k++)
                                                            {
                                                                stringBuilder.Append("\n");
                                                                stringBuilder.Append(text12);
                                                                stringBuilder.Append("/// <param name=\"");
                                                                stringBuilder.Append(parameters[k]._AW);
                                                                stringBuilder.Append("\"></param>");
                                                            }
                                                        }
                                                        _bf1 hpomlclippdnpjciibilcalngekicmmdifhn = (_AAH as _bf1) ?? (_AAH as _bl4);
                                                        bool flag204 = _AAH._AT == SymbolKind.Indexer || (hpomlclippdnpjciibilcalngekicmmdifhn != null && _AAH.TypeOf() != _bh4._BFU);
                                                        if (flag204)
                                                        {
                                                            stringBuilder.Append("\n");
                                                            stringBuilder.Append(text12);
                                                            stringBuilder.Append("/// <returns></returns>");
                                                        }
                                                    }
                                                    _bc5._AOM = true;
                                                    int _ARC4 = this._ABQ.InsertText(this._ABH, stringBuilder.ToString())._ABI;
                                                    _bc5._AOM = false;
                                                    this._ABQ.UpdateHighlighting(_ARC3, _ARC4, false);
                                                    this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM = null;
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

        // Token: 0x06000311 RID: 785 RVA: 0x00037EC0 File Offset: 0x000360C0
        private void ProcessEditorMouse(float margin, Event current)
        {
            bool flag = current.type == 3 || current.type == 0;
            if (flag)
            {
                this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 0f;
            }
            bool flag2 = !this.CanEdit();
            if (!flag2)
            {
                bool flag3 = GUIUtility.hotControl != 0 && GUIUtility.hotControl != _bi2.BLPCHGOBMBLGEAPDFHEIFAEBPBCJAFEONIIC && DragAndDrop.GetGenericData("SuperEditor.Text") == null;
                if (!flag3)
                {
                    this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ABI = -1;
                    this.DGFPNNENOAAGOMLLCKFKADELBMKMIEIFNJBJ._ABI = -1;
                    bool flag4 = current.type == 0;
                    if (flag4)
                    {
                        _bi2._AKS = false;
                        bool flag5 = current.button == 0;
                        if (flag5)
                        {
                            this.BLGGAMPHPAAEJEABCOGEBGGCAMIEELCDPMNE = true;
                            bool flhmmgogabacngebpcfefgpmfnakdpiglabb = this.FLHMMGOGABACNGEBPCFEFGPMFNAKDPIGLABB;
                            if (flhmmgogabacngebpcfefgpmfnakdpiglabb)
                            {
                                bool flag6 = current.mousePosition.x >= this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this._AEY().x - 6f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x && current.mousePosition.x < this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this._AEY().x - 6f + this._AEY().x + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x;
                                if (flag6)
                                {
                                    int lineAt = this.GetLineAt(current.mousePosition.y);
                                    bool flag7 = lineAt >= 0 && lineAt < this._ABQ.FLOg.Count;
                                    if (flag7)
                                    {
                                        bool flag8 = current.mousePosition.y - this.GetLineOffset(lineAt) < this._AEY().y;
                                        if (flag8)
                                        {
                                            GCE._ABW _AUX = this._ABQ._AQQ[lineAt]._ABZ;
                                            bool flag9 = _AUX != null && _AUX._ABI != null;
                                            if (flag9)
                                            {
                                                bool flag10 = _AUX._AT == (GCE._ABW._ABX)1 || _AUX._AT == (GCE._ABW._ABX)6;
                                                if (flag10)
                                                {
                                                    int _AQZ = _AUX._ABI.JIKB;
                                                    bool flag11 = _AQZ == lineAt;
                                                    if (flag11)
                                                    {
                                                        this.AKNDCMEKCLNECEIINAOBBODFNCODAADFNILP = lineAt;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            bool lfgcffnkdedpogflakndcphcnedjkmpjmdfg = this.LFGCFFNKDEDPOGFLAKNDCPHCNEDJKMPJMDFG;
                            if (lfgcffnkdedpogflakndcphcnedjkmpjmdfg)
                            {
                                bool flag12 = current.mousePosition.x >= this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x && current.mousePosition.x < this.BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG + this._AEY().x + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x;
                                if (flag12)
                                {
                                    int lineAt2 = this.GetLineAt(current.mousePosition.y);
                                    bool flag13 = lineAt2 >= 0 && lineAt2 < this._ABQ.FLOg.Count;
                                    if (flag13)
                                    {
                                        this.MDKDMJHJKJKGBMLNFDHCKDIJDONPLLKDFGKC = lineAt2;
                                    }
                                    bool flag14 = !this.CFGMIHPKGHMFFINDHELODHEJGENHNKBBHPGK.Contains(this.MDKDMJHJKJKGBMLNFDHCKDIJDONPLLKDFGKC);
                                    if (flag14)
                                    {
                                        this.CFGMIHPKGHMFFINDHELODHEJGENHNKBBHPGK.Add(this.MDKDMJHJKJKGBMLNFDHCKDIJDONPLLKDFGKC);
                                    }
                                    else
                                    {
                                        this.CFGMIHPKGHMFFINDHELODHEJGENHNKBBHPGK.Remove(this.MDKDMJHJKJKGBMLNFDHCKDIJDONPLLKDFGKC);
                                    }
                                }
                            }
                        }
                    }
                    bool flag15 = !this.BLGGAMPHPAAEJEABCOGEBGGCAMIEELCDPMNE && current.button == 0 && current.rawType != 1 && current.type != 2;
                    if (!flag15)
                    {
                        bool flag16 = current.rawType == 1 && current.button == 0;
                        if (flag16)
                        {
                            this.BLGGAMPHPAAEJEABCOGEBGGCAMIEELCDPMNE = false;
                            this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = false;
                            this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = false;
                        }
                        EventType type = current.type;
                        EventModifiers eventModifiers = current.modifiers & -113;
                        bool flag17 = type == 3 && current.button == 0;
                        int num = this._ABH._ATF;
                        int num2 = this._ABH._AEU;
                        int num3 = this._ABH._ABI;
                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI = this._ABH._ABI;
                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = this._ABH._AEU;
                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = this._ABH._ATG;
                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATF = this._ABH._ATF;
                        float num4 = current.mousePosition.x;
                        float num5 = current.mousePosition.y;
                        bool flag18 = flag17;
                        if (flag18)
                        {
                            num4 = Mathf.Clamp(num4, this._ALM.x, this._ALM.xMax);
                            num5 = Mathf.Clamp(num5, this._ALM.y, this._ALM.yMax);
                        }
                        num4 -= margin;
                        int num6 = Mathf.Clamp(this.GetLineAt(num5), 0, this._ABQ.FLOg.Count - 1);
                        float charAt = this.GetCharAt(num4, num5, num6);
                        int num7 = Mathf.RoundToInt(num4 / this._AEY().x);
                        int num8 = (int)(num4 / this._AEY().x);
                        int num9 = Mathf.RoundToInt(charAt);
                        int num10 = (int)charAt;
                        this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC = new GCE._AFA
                        {
                            _AEU = num9,
                            _ATG = num7,
                            _ABI = num6,
                            _ATF = num7
                        };
                        bool flag19 = num8 == num7;
                        if (flag19)
                        {
                            this.DGFPNNENOAAGOMLLCKFKADELBMKMIEIFNJBJ = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC;
                            num10 = num9;
                        }
                        else
                        {
                            this.DGFPNNENOAAGOMLLCKFKADELBMKMIEIFNJBJ = new GCE._AFA
                            {
                                _AEU = num10,
                                _ATG = num8,
                                _ABI = num6,
                                _ATF = num8
                            };
                        }
                        bool flag20 = this._ABQ._ASC && current.type == 2 && eventModifiers == null && this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.Contains(current.mousePosition) && num6 >= 0 && num6 < this._ABQ.FLOg.Count && num10 < this._ABQ.FLOg[num6].Length;
                        if (flag20)
                        {
                            TextPosition textPosition = new TextPosition(num6, num10 + 1);
                            int num11;
                            int num12;
                            bool flag21;
                            SyntaxToken tokenAt = this._ABQ.GetTokenAt(textPosition, out num11, out num12, out flag21);
                            bool flag22 = tokenAt != this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII;
                            if (flag22)
                            {
                                this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC = default(DateTime);
                                this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII = null;
                                bool flag23 = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null;
                                if (flag23)
                                {
                                    this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.Hide();
                                }
                                bool flag24 = tokenAt != null && tokenAt.OOME != null && (tokenAt.style == this._ABT._ACN || tokenAt.OOME._AJB != null || tokenAt.OOME._AJF != null || (tokenAt.tokenKind >= SyntaxToken.Kind.BuiltInLiteral && (tokenAt.tokenKind != SyntaxToken.Kind.Keyword || tokenAt.text == "this" || tokenAt.text == "base" || this._ABQ._AOU().IsBuiltInType(tokenAt.text) || this._ABQ._AOU().IsBuiltInLiteral(tokenAt.text)) && tokenAt.tokenKind != SyntaxToken.Kind.Punctuator));
                                if (flag24)
                                {
                                    this.HMBHHLIKJCBCEFKDGKPNLHMOKOOLHJDKLBOL = this.GetTokenRect(tokenAt);
                                    Vector2 vector = GUIUtility.GUIToScreenPoint(current.mousePosition);
                                    bool flag25 = this.HMBHHLIKJCBCEFKDGKPNLHMOKOOLHJDKLBOL.Contains(vector);
                                    if (flag25)
                                    {
                                        this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII = tokenAt;
                                        this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC = ((tokenAt != null) ? _bi2._ATN : default(DateTime));
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC = default(DateTime);
                            this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII = null;
                        }
                        bool flag26 = type == 10 || type == 9;
                        if (flag26)
                        {
                            int num13 = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.CompareTo(this._ABH);
                            int num14 = ((this._ATW() != null) ? this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.CompareTo(this._ATW()) : num13);
                            bool flag27 = (num13 >= 0 || num14 >= 0) && (num13 <= 0 || num14 <= 0);
                            bool flag28 = EditorGUI.actionKey && (num13 == 0 || num14 == 0);
                            if (flag28)
                            {
                                flag27 = false;
                            }
                            DragAndDrop.visualMode = (flag27 ? 32 : (EditorGUI.actionKey ? 1 : 16));
                            bool flag29 = type == 10;
                            if (flag29)
                            {
                                object genericData = DragAndDrop.GetGenericData("SuperEditor.Text");
                                bool flag30 = !string.IsNullOrEmpty(genericData as string) && this.TryEdit();
                                if (flag30)
                                {
                                    this._ABQ.BeginEdit("Drag selection");
                                    bool flag31 = !EditorGUI.actionKey;
                                    if (flag31)
                                    {
                                        GCE._AFA _ATD = this._ABQ.DeleteText(this._ATW(), this._ABH);
                                        this._ABQ.UpdateHighlighting(_ATD._ABI, _ATD._ABI, false);
                                        bool flag32 = this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND > this._ABH;
                                        if (flag32)
                                        {
                                            int num15 = Math.Abs(this._ABH._ABI - this._ATW()._ABI);
                                            bool flag33 = num15 == 0;
                                            if (flag33)
                                            {
                                                bool flag34 = this._ABH._ABI == this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI;
                                                if (flag34)
                                                {
                                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._AEU -= Math.Abs(this._ABH._AEU - this._ATW()._AEU);
                                                }
                                            }
                                            else
                                            {
                                                bool flag35 = Math.Max(this._ABH._ABI, this._ATW()._ABI) == this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI;
                                                if (flag35)
                                                {
                                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI = _ATD._ABI;
                                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._AEU -= ((this._ABH > this._ATW()) ? this._ABH._AEU : this._ATW()._AEU) - _ATD._AEU;
                                                }
                                                else
                                                {
                                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI -= num15;
                                                }
                                            }
                                            this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ATG = (this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ATF = this.CharIndexToColumn(this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._AEU, this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI));
                                        }
                                    }
                                    this._ABH = this._ABQ.InsertText(this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND, genericData as string);
                                    bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                    if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                                    {
                                        this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                                    }
                                    this._ABQ.UpdateHighlighting(this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI, this._ABH._ABI, false);
                                    this._ATL(this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND.Clone());
                                    this._ABQ.EndEdit();
                                }
                                DragAndDrop.AcceptDrag();
                                DragAndDrop.SetGenericData("SuperEditor.Text", null);
                                GUIUtility.hotControl = 0;
                                this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = false;
                                this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = false;
                                this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;
                                this.MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA = false;
                                this.PEGFBNGNMIIMHJHBGGJMIPPGCENEDFKBJIPF = false;
                                this.DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC = false;
                                this.ALLEDCEJLCOEBNDPEPFIJNFCIFIDIDNEHKFJ = false;
                                current.Use();
                            }
                            else
                            {
                                bool flag36 = flag27;
                                if (flag36)
                                {
                                    this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ABI = this._ABH._ABI;
                                    this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._AEU = this._ABH._AEU;
                                    this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATG = this._ABH._ATG;
                                    this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATF = this._ABH._ATF;
                                }
                                bool flag37 = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC != this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND;
                                if (flag37)
                                {
                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ABI = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ABI;
                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._AEU = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._AEU;
                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ATG = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATG;
                                    this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND._ATF = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATF;
                                    this._ATM = _bi2._ATN;
                                    this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                    this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                }
                                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                current.Use();
                            }
                        }
                        else
                        {
                            bool flag38 = !this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL && current.mousePosition.y >= 0f && type == null && ((flag17 && current.mousePosition.x >= this._ALM.x) || (type == null && current.mousePosition.x >= 0f));
                            if (flag38)
                            {
                                bool bodjhgoiefmippgplnbaibniefngejodghfl = this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL;
                                if (bodjhgoiefmippgplnbaibniefngejodghfl)
                                {
                                    int num16 = this.DGFPNNENOAAGOMLLCKFKADELBMKMIEIFNJBJ.CompareTo(this._ABH);
                                    int num17 = this.DGFPNNENOAAGOMLLCKFKADELBMKMIEIFNJBJ.CompareTo(this._ATW());
                                    this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = (num16 >= 0 || num17 >= 0) && (num16 < 0 || num17 < 0);
                                }
                                else
                                {
                                    this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;
                                }
                            }
                            bool flag39 = flag17 && current.button == 0;
                            if (flag39)
                            {
                                bool flag40 = !this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL;
                                if (flag40)
                                {
                                    this.LAHBGBFFABHOMBCEKEOONHEFBNAHFPKDNLNM = _bi2._ATN;
                                    bool flag41 = this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI && !current.shift;
                                    if (flag41)
                                    {
                                        DragAndDrop.PrepareStartDrag();
                                        DragAndDrop.objectReferences = new Object[] { this._ABQ };
                                        DragAndDrop.StartDrag("Dragging selected text");
                                        DragAndDrop.SetGenericData("SuperEditor.Text", this._ABQ.GetTextRange(this._ATW(), this._ABH));
                                        GUIUtility.hotControl = 0;
                                        current.Use();
                                        this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = true;
                                        this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND = this._ABH.Clone();
                                        return;
                                    }
                                    this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;
                                }
                                this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = true;
                            }
                            else
                            {
                                bool flag42 = current.button == 1;
                                if (flag42)
                                {
                                    bool flag43 = type == null && current.mousePosition.x >= 0f && current.mousePosition.y >= 0f;
                                    if (!flag43)
                                    {
                                        return;
                                    }
                                    current.Use();
                                    bool flag44 = !this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                                    if (!flag44)
                                    {
                                        return;
                                    }
                                    num2 = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._AEU;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ABI;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._AEU;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATG;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATF = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATF;
                                    this._ATO = true;
                                }
                            }
                            bool flag45 = flag17 || type == 0;
                            if (flag45)
                            {
                                GUIUtility.hotControl = _bi2.BLPCHGOBMBLGEAPDFHEIFAEBPBCJAFEONIIC;
                                this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                bool flag46 = (current.mousePosition.x >= 0f && current.mousePosition.y >= 0f) || flag17;
                                if (flag46)
                                {
                                    bool flag47 = !flag17 && current.button == 0;
                                    if (flag47)
                                    {
                                        bool flag48 = current.mousePosition.x < margin + this._AFS.x;
                                        if (flag48)
                                        {
                                            this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = true;
                                            this.IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK = false;
                                            this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA = (this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG = null);
                                        }
                                        else
                                        {
                                            bool flag49 = _bg8._BCI;
                                            if (flag49)
                                            {
                                                bool flag50 = _bi2._ATN > _bi2.EPOKGOLNPBHMELMJEOKOLPHGMLINFJCCFMMP && (float)(_bi2._ATN - _bi2.EPOKGOLNPBHMELMJEOKOLPHGMLINFJCCFMMP).TotalSeconds <= 0.5f;
                                                if (flag50)
                                                {
                                                    this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = true;
                                                    this.IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK = false;
                                                    this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA = (this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG = null);
                                                    current.clickCount = 3;
                                                    this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;
                                                }
                                            }
                                        }
                                    }
                                    this._ATO = !flag17 && !this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                                    num2 = num9;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ABI;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._AEU;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATG;
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATF = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC._ATF;
                                    bool flag51 = current.button == 0;
                                    if (flag51)
                                    {
                                        bool flag52 = current.clickCount == 1 && this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                                        if (flag52)
                                        {
                                            this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                            return;
                                        }
                                        bool flag53 = !this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK && (current.clickCount == 2 || (EditorGUI.actionKey && type == null) || this.IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK);
                                        if (flag53)
                                        {
                                            bool flag54 = current.clickCount == 2;
                                            if (flag54)
                                            {
                                                _bi2.EPOKGOLNPBHMELMJEOKOLPHGMLINFJCCFMMP = _bi2._ATN;
                                            }
                                            int num18;
                                            int num19;
                                            bool wordExtents = this._ABQ.GetWordExtents(num2, num6, out num18, out num19);
                                            if (wordExtents)
                                            {
                                                bool flag55 = this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA != null && ((eventModifiers & 1) != null || this.IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK);
                                                if (flag55)
                                                {
                                                    bool flag56 = num6 > this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._ABI || (num6 == this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._ABI && num18 >= this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._AEU);
                                                    bool flag57 = flag56;
                                                    if (flag57)
                                                    {
                                                        this._ATL(this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA.Clone());
                                                        num2 = num19;
                                                        num = this.CharIndexToColumn(num19, num6);
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.Clone();
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = num;
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = num2;
                                                    }
                                                    else
                                                    {
                                                        this._ATL(this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG.Clone());
                                                        num2 = num18;
                                                        num = this.CharIndexToColumn(num18, num6);
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.Clone();
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = num;
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = num2;
                                                    }
                                                }
                                                else
                                                {
                                                    bool flag58 = this._ATW() != null;
                                                    if (flag58)
                                                    {
                                                        this._ABH = this._ATW();
                                                    }
                                                    this._ATL(null);
                                                    bool flag59 = (eventModifiers & 1) == 0;
                                                    if (flag59)
                                                    {
                                                        this._ABH._ABI = num6;
                                                        this._ABH._AEU = num18;
                                                        this._ABH._ATF = (this._ABH._ATG = this.CharIndexToColumn(num18, num6));
                                                        num2 = num19;
                                                        num = this.CharIndexToColumn(num19, num6);
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.Clone();
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = num;
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = num2;
                                                        this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA = this._ABH.Clone();
                                                        this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.Clone();
                                                        this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG._ATF = this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG._ATG;
                                                    }
                                                    else
                                                    {
                                                        bool flag60 = num6 > this._ABH._ABI || (num6 == this._ABH._ABI && num9 > this._ABH._AEU);
                                                        int num20;
                                                        int num21;
                                                        bool wordExtents2 = this._ABQ.GetWordExtents(this._ABH._AEU, this._ABH._ABI, out num20, out num21);
                                                        if (wordExtents2)
                                                        {
                                                            this._ABH._AEU = (flag60 ? num20 : num21);
                                                            this._ABH._ATF = (this._ABH._ATG = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                                                            this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA = this._ABH.Clone();
                                                            this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._AEU = num20;
                                                            this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._ATF = (this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._ATG = this.CharIndexToColumn(num20, this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA._ABI));
                                                            this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG = this._ABH.Clone();
                                                            this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG._AEU = num21;
                                                            this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG._ATF = (this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG._ATG = this.CharIndexToColumn(num21, this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG._ABI));
                                                        }
                                                        else
                                                        {
                                                            this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA = this._ABH.Clone();
                                                            this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG = this._ABH.Clone();
                                                        }
                                                        num2 = (flag60 ? num19 : num18);
                                                        num = this.CharIndexToColumn(num2, num6);
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.Clone();
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG = num;
                                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU = num2;
                                                    }
                                                }
                                                eventModifiers |= 1;
                                                this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = false;
                                                this.IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK = true;
                                            }
                                        }
                                        else
                                        {
                                            this.FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA = null;
                                            this.DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG = null;
                                        }
                                    }
                                }
                                current.Use();
                            }
                            int num22 = 0;
                            bool flag61 = this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK && this._ATW() != null && this._ATW() < this._ABH;
                            if (flag61)
                            {
                                num22 = -1;
                            }
                            bool flag62 = current.rawType == 1 && current.button == 0 && GUIUtility.hotControl != 0;
                            if (flag62)
                            {
                                bool flhmmgogabacngebpcfefgpmfnakdpiglabb2 = this.FLHMMGOGABACNGEBPCFEFGPMFNAKDPIGLABB;
                                if (flhmmgogabacngebpcfefgpmfnakdpiglabb2)
                                {
                                    bool flag63 = this.AKNDCMEKCLNECEIINAOBBODFNCODAADFNILP >= 0;
                                    if (flag63)
                                    {
                                        bool flag64 = current.mousePosition.x >= this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this._AEY().x - 6f && current.mousePosition.x < this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this._AEY().x - 6f + this._AEY().x;
                                        if (flag64)
                                        {
                                            int lineAt3 = this.GetLineAt(current.mousePosition.y);
                                            bool flag65 = lineAt3 == this.AKNDCMEKCLNECEIINAOBBODFNCODAADFNILP;
                                            if (flag65)
                                            {
                                                this.AKNDCMEKCLNECEIINAOBBODFNCODAADFNILP = -1;
                                                bool flag66 = current.mousePosition.y - this.GetLineOffset(lineAt3) < this._AEY().y;
                                                if (flag66)
                                                {
                                                    GCE._ABW _AUX2 = this._ABQ._AQQ[lineAt3]._ABZ;
                                                    bool flag67 = _AUX2 != null && _AUX2._ABI != null;
                                                    if (flag67)
                                                    {
                                                        bool flag68 = _AUX2._AT == (GCE._ABW._ABX)1 || _AUX2._AT == (GCE._ABW._ABX)6;
                                                        if (flag68)
                                                        {
                                                            int _AQZ2 = _AUX2._ABI.JIKB;
                                                            bool flag69 = _AQZ2 == lineAt3;
                                                            if (flag69)
                                                            {
                                                                this.ToggleFolding(lineAt3);
                                                                Event.current.Use();
                                                                return;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                bool ciollbejaojggedhbafdiiephpnccnjpfnci = this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                                if (ciollbejaojggedhbafdiiephpnccnjpfnci)
                                {
                                    bool flag70 = !this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL;
                                    if (flag70)
                                    {
                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN = this.GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC.Clone();
                                        this._ABH._ATF--;
                                    }
                                }
                                GUIUtility.hotControl = 0;
                                this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = false;
                                this.IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK = false;
                                this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = false;
                                this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;
                                this.MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA = false;
                                this.PEGFBNGNMIIMHJHBGGJMIPPGCENEDFKBJIPF = false;
                                this.DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC = false;
                                this.ALLEDCEJLCOEBNDPEPFIJNFCIFIDIDNEHKFJ = false;
                                current.Use();
                                this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                num22 = 0;
                            }
                            bool flag71 = !this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.IsSameAs(this._ABH) || this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI != this._ABH._ABI + num22 || (type == null && current.button == 0);
                            if (flag71)
                            {
                                this._ATM = _bi2._ATN;
                                this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                bool flag72 = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI < 0;
                                if (flag72)
                                {
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.Set(0, 0, 0, 0);
                                }
                                bool flag73 = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI >= this._ABQ._ASK;
                                if (flag73)
                                {
                                    this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.Set(this._ABQ._ASK - 1, 0, 0, 0);
                                }
                                num3 = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI;
                                bool flag74 = this._ATW() == null && (flag17 || (eventModifiers & 1) > 0);
                                if (flag74)
                                {
                                    this._ATL(this._ABH.Clone());
                                }
                                bool kolagfcmkefoakdpphcebjpfdneglgmblodk = this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK;
                                if (kolagfcmkefoakdpphcebjpfdneglgmblodk)
                                {
                                    bool flag75 = this._ATW() == null || (!flag17 && (eventModifiers & 1) == 0);
                                    if (flag75)
                                    {
                                        this._ATL(new GCE._AFA
                                        {
                                            _ATG = 0,
                                            _ATF = 0,
                                            _AEU = 0,
                                            _ABI = num3
                                        });
                                    }
                                    bool flag76 = num3 >= this._ATW()._ABI;
                                    if (flag76)
                                    {
                                        num3++;
                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.Set(this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI + 1, 0, 0, 0);
                                        bool flag77 = num3 >= this._ABQ._ASK;
                                        if (flag77)
                                        {
                                            num3 = this._ABQ._ASK - 1;
                                            num2 = this._ABQ.FLOg[num3].Length;
                                            num = this._ABQ.CharIndexToColumn(num2, num3);
                                            this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.Set(this._ABQ._ASK - 1, this._ABQ.FLOg[num3].Length, num);
                                        }
                                        this._ATL(new GCE._AFA
                                        {
                                            _AEU = 0,
                                            _ATG = 0,
                                            _ATF = 0,
                                            _ABI = this._ATW()._ABI
                                        });
                                    }
                                    else
                                    {
                                        int length = this._ABQ.FLOg[this._ATW()._ABI].Length;
                                        int num23 = this._ABQ.CharIndexToColumn(length, this._ATW()._ABI);
                                        this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN.Set(this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI, 0, 0, 0);
                                        this._ATL(new GCE._AFA
                                        {
                                            _AEU = length,
                                            _ATG = num23,
                                            _ATF = num23,
                                            _ABI = this._ATW()._ABI
                                        });
                                    }
                                }
                                bool flag78 = !this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                                if (flag78)
                                {
                                    this._ABH._ABI = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ABI;
                                    this._ABH._AEU = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._AEU;
                                    this._ABH._ATG = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATG;
                                    this._ABH._ATF = this.MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN._ATF;
                                    bool flag79 = num3 >= 0;
                                    if (flag79)
                                    {
                                        this._ABH._ATF = this._ABH._ATG;
                                    }
                                }
                                bool flag80 = !flag17 && !this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK && (eventModifiers & 1) == 0;
                                if (flag80)
                                {
                                    this._ATL(null);
                                }
                                bool flag81 = !this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL;
                                if (flag81)
                                {
                                    this.AddRecentLocation(11, true);
                                    this._ATO = true;
                                }
                                this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                            }
                            bool flag82 = (eventModifiers & 8) != null || (eventModifiers & 2) > 0;
                            if (flag82)
                            {
                                TextPosition textPosition2 = new TextPosition(num6, num10 + 1);
                                int num24;
                                int num25;
                                bool flag83;
                                SyntaxToken tokenAt2 = this._ABQ.GetTokenAt(textPosition2, out num24, out num25, out flag83);
                                bool flag84 = tokenAt2 != null;
                                if (flag84)
                                {
                                    bool flag85 = Event.current.button == 0 && type == 0;
                                    if (flag85)
                                    {
                                        List<FKI> symbolDeclarations = this.GetSymbolDeclarations(tokenAt2);
                                        bool flag86 = symbolDeclarations != null;
                                        if (flag86)
                                        {
                                            this.GoToSymbolDeclaration(symbolDeclarations[0]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000312 RID: 786 RVA: 0x00039A30 File Offset: 0x00037C30
        public Theme NHJINOFPANCPFCKBNMLCEDJOGNKEIDJCBPBH()
        {
            return (this._ABQ != null && this._ABQ._ARR) ? _bi2.NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF : _bi2.LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN;
        }

        // Token: 0x06000313 RID: 787 RVA: 0x00039A6C File Offset: 0x00037C6C
        internal static string[] MALGDKADEDLONPFACJAGNOJFCCJHGAELLKBK()
        {
            string[] array = AssetDatabase.FindAssets("t:Font", new string[] { _bi2.NPOF() + "/Fonts" });
            bool flag = array.Length == 0;
            if (flag)
            {
                array = AssetDatabase.FindAssets("t:Font", new string[] { "Assets/SuperEditor/EditorResources/Fonts" });
            }
            bool flag2 = array.Length == 0;
            if (flag2)
            {
                array = AssetDatabase.FindAssets("t:Font", new string[] { "Assets/Plugins/SuperEditor/EditorResources/Fonts" });
            }
            _bi2.OFCDBBBDLNHBALAKIGKPEIMNCAECAFBMGPAP = new string[array.Length];
            for (int i = 0; i < _bi2.OFCDBBBDLNHBALAKIGKPEIMNCAECAFBMGPAP.Length; i++)
            {
                _bi2.OFCDBBBDLNHBALAKIGKPEIMNCAECAFBMGPAP[i] = "Fonts/" + Path.GetFileName(AssetDatabase.GUIDToAssetPath(array[i]));
            }
            return _bi2.OFCDBBBDLNHBALAKIGKPEIMNCAECAFBMGPAP;
        }

        // Token: 0x06000314 RID: 788 RVA: 0x00039B34 File Offset: 0x00037D34
        internal static _bi2._AVA _AEE()
        {
            bool flag = _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE._ABV == null;
            if (flag)
            {
                _bi2.InitializeFont(false);
                _bi2.LoadStyles(_bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE, false);
            }
            return _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE;
        }

        // Token: 0x06000315 RID: 789 RVA: 0x00039B74 File Offset: 0x00037D74
        internal static _bi2._AVA _ASD()
        {
            bool flag = _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM._ABV == null;
            if (flag)
            {
                _bi2.InitializeFont(true);
                _bi2.LoadStyles(_bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM, true);
            }
            return _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM;
        }

        // Token: 0x06000316 RID: 790 RVA: 0x00039BB1 File Offset: 0x00037DB1
        [CompilerGenerated]
        public bool GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK()
        {
            return this.BBFLOGMOLBEMOMBADGIPFCDNLNOKPIEMCPAB;
        }

        // Token: 0x06000317 RID: 791 RVA: 0x00039BB9 File Offset: 0x00037DB9
        [CompilerGenerated]
        private void IOPEBNDLLLDJELEBEIKHKAGNHKBDPKFIAEEL(bool value)
        {
            this.BBFLOGMOLBEMOMBADGIPFCDNLNOKPIEMCPAB = value;
        }

        // Token: 0x06000318 RID: 792 RVA: 0x00039BC2 File Offset: 0x00037DC2
        [CompilerGenerated]
        public Vector2 _AEY()
        {
            return this.NCOGBBOAIHDPGKJIFPBILAHCAKNBMFGPJPML;
        }

        // Token: 0x06000319 RID: 793 RVA: 0x00039BCA File Offset: 0x00037DCA
        [CompilerGenerated]
        private void HOPMPOOFCKGLAFDCFAAODFFEMMMOJHGAOJMI(Vector2 value)
        {
            this.NCOGBBOAIHDPGKJIFPBILAHCAKNBMFGPJPML = value;
        }

        // Token: 0x0600031A RID: 794 RVA: 0x00039BD4 File Offset: 0x00037DD4
        private bool LEODMLGKKNFBILELIDFFIOPLHDMDGAIFLKMM()
        {
            bool flag = this._ABQ == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF != null;
                if (flag3)
                {
                    flag2 = (this._ABQ._ARR ? _bg8._BAA : _bg8._AZZ);
                }
                else
                {
                    flag2 = (this._ABQ._ARR ? _bg8._BBS : _bg8._BBR);
                }
            }
            return flag2;
        }

        // Token: 0x0600031B RID: 795 RVA: 0x00039C4C File Offset: 0x00037E4C
        private bool HFBBKNBEOLAICCGCIFGLPKHFCNHPANGIIGDM()
        {
            bool flag = this._ABQ == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF != null;
                if (flag3)
                {
                    flag2 = (this._ABQ._ARR ? _bg8._BAE : _bg8._BAD);
                }
                else
                {
                    flag2 = (this._ABQ._ARR ? _bg8._BBQ : _bg8._BBP);
                }
            }
            return flag2;
        }

        // Token: 0x0600031C RID: 796 RVA: 0x00039CC4 File Offset: 0x00037EC4
        public GCE._AFA _ATW()
        {
            return this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL ? this.GLAAHLAEKKCKGBFLOGGJOIAHHBGOIFHFLJOL : null;
        }

        // Token: 0x0600031D RID: 797 RVA: 0x00039CE8 File Offset: 0x00037EE8
        public void _ATL(GCE._AFA value)
        {
            bool flag = value == null;
            if (flag)
            {
                this.GLAAHLAEKKCKGBFLOGGJOIAHHBGOIFHFLJOL = null;
                this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL = false;
            }
            else
            {
                this.GLAAHLAEKKCKGBFLOGGJOIAHHBGOIFHFLJOL = value;
                this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL = true;
            }
        }

        // Token: 0x0600031E RID: 798 RVA: 0x00039D24 File Offset: 0x00037F24
        public GCE _ABK()
        {
            bool flag = this._ABQ == null;
            if (flag)
            {
                this._ABQ = GCE.GetBuffer(this._ALP._AKT);
            }
            return this._ABQ;
        }

        // Token: 0x0600031F RID: 799 RVA: 0x00039D64 File Offset: 0x00037F64
        public bool _ALW()
        {
            return this._ABQ != null && this._ABQ._ALW();
        }

        // Token: 0x06000320 RID: 800 RVA: 0x00039D94 File Offset: 0x00037F94
        public bool _ARV()
        {
            return this._ABQ == null || this._ABQ._ARV();
        }

        // Token: 0x06000321 RID: 801 RVA: 0x00039DC4 File Offset: 0x00037FC4
        public bool CanEdit()
        {
            return !this._ARV();
        }

        // Token: 0x06000322 RID: 802 RVA: 0x00039DE0 File Offset: 0x00037FE0
        public string _AKQ()
        {
            return (this._ABQ != null) ? this._ABQ._AMZ : string.Empty;
        }

        // Token: 0x06000323 RID: 803 RVA: 0x00039E14 File Offset: 0x00038014
        public string NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC()
        {
            return (this._ABQ != null) ? this._ABQ._ARQ() : string.Empty;
        }

        // Token: 0x06000324 RID: 804 RVA: 0x00039E48 File Offset: 0x00038048
        internal static string NPOF()
        {
            MonoScript monoScript = MonoScript.FromScriptableObject(SuperEditorLocator.Instance());
            _bi2.LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ = AssetDatabase.GetAssetPath(monoScript);
            _bi2.LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ = Path.GetDirectoryName(Path.GetDirectoryName(_bi2.LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ));
            _bi2.LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ = Path.Combine(_bi2.LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ, "EditorResources");
            return _bi2.LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ;
        }

        // Token: 0x06000325 RID: 805 RVA: 0x00039EA0 File Offset: 0x000380A0
        public EditorWindow _ABJ()
        {
            return this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF ?? this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH;
        }

        // Token: 0x06000326 RID: 806 RVA: 0x00039EC4 File Offset: 0x000380C4
        private static _b2 FODMINEMHCODAKPMOCKCHANGHHFDPFCJONPH()
        {
            bool flag = _bi2.IGFEHLGDDCJOMNOLHGKLFBICAMPPMDGMAJJK == null;
            if (flag)
            {
                _bi2.IGFEHLGDDCJOMNOLHGKLFBICAMPPMDGMAJJK = _bl9.ForType(typeof(Attribute)).definition as _b2;
            }
            return _bi2.IGFEHLGDDCJOMNOLHGKLFBICAMPPMDGMAJJK;
        }

        // Token: 0x06000327 RID: 807 RVA: 0x00039F05 File Offset: 0x00038105
        [CompilerGenerated]
        internal static _bi2 _AOB()
        {
            return _bi2.LIEJDFDLPDHHMPLFMPKOANNIPICOMKPBKFCN;
        }

        // Token: 0x06000328 RID: 808 RVA: 0x00039F0C File Offset: 0x0003810C
        [CompilerGenerated]
        private static void PBBPFHLOKNCCODDMCKNNJGFOGBHHKMDKKGHJ(_bi2 value)
        {
            _bi2.LIEJDFDLPDHHMPLFMPKOANNIPICOMKPBKFCN = value;
        }

        // Token: 0x06000329 RID: 809 RVA: 0x00039F14 File Offset: 0x00038114
        private static List<ThemeTemplate> NFKLDALAOOLJNIPCPGLGHLNHCNDAFBLLHCKN()
        {
            bool flag = _bi2.JMFFKMDENDGHKKBOFMDHJLMPKAKCGLBLJIFP == null;
            if (flag)
            {
                _bi2.InitCustomThemes();
            }
            return _bi2.JMFFKMDENDGHKKBOFMDHJLMPKAKCGLBLJIFP;
        }

        // Token: 0x0600032A RID: 810 RVA: 0x00039F3D File Offset: 0x0003813D
        private static void EELPNPKMEABFHHAJHIHGOGGKIGENPADEIOBM(List<ThemeTemplate> value)
        {
            _bi2.JMFFKMDENDGHKKBOFMDHJLMPKAKCGLBLJIFP = value;
        }

        // Token: 0x0600032B RID: 811 RVA: 0x00039F48 File Offset: 0x00038148
        private void DoGUIWithAutocomplete(bool enableGUI)
        {
            GCE._ASA = _bg8._ASA;
            this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO = this.LEODMLGKKNFBILELIDFFIOPLHDMDGAIFLKMM();
            bool flag = this._ATM == default(DateTime);
            if (flag)
            {
                this._ATM = _bi2._ATN;
                this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
            }
            this.KPOKBHDGCMLBFEPIHIPEKAIPDGAAGIMNLFCD = (_bi2.PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD)0;
            bool flag2 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO == null;
            if (flag2)
            {
                try
                {
                    this.DoGUI(enableGUI);
                }
                catch (ExitGUIException ex)
                {
                }
            }
            else
            {
                GCE._AFA _ATD = this._ABH.Clone();
                try
                {
                    this.DoGUI(enableGUI);
                }
                catch (ExitGUIException ex2)
                {
                }
                bool flag3 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                if (flag3)
                {
                    bool flag4 = !this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() && EditorWindow.focusedWindow != this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO;
                    if (flag4)
                    {
                        this.CloseAutocomplete();
                    }
                    else
                    {
                        bool flag5 = this._ABH._ABI == _ATD._ABI && this._ABH != _ATD;
                        if (flag5)
                        {
                            this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.UpdateTypedInPart();
                        }
                    }
                }
            }
            bool flag6 = Event.current.type == 4;
            if (flag6)
            {
                bool flag7 = _bi2.MightBePrintableKey(Event.current);
                if (flag7)
                {
                    Event.current.Use();
                }
            }
            bool jhonfkmhpkclklhkmoebehpgnbladgbbehil = this.JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL;
            if (jhonfkmhpkclklhkmoebehpgnbladgbbehil)
            {
                this.Autocomplete(this.LLJFBDFABMBMPEBEDAKOJBDMGGFBOJEKCPKD);
                this.LLJFBDFABMBMPEBEDAKOJBDMGGFBOJEKCPKD = false;
                this.JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL = false;
            }
            bool flag8 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
            if (flag8)
            {
                bool flag9 = !this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() && EditorWindow.focusedWindow != this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;
                if (flag9)
                {
                    this.CloseArgumentsHint();
                    this.Repaint();
                }
            }
            bool flag10 = this._ABQ == null;
            if (!flag10)
            {
                bool flag11 = Event.current.type == 7;
                if (flag11)
                {
                    this.KCNPCIEKAJFBIOBEGEOCHIAELCCBKBFBCADM = this._ALM;
                }
                bool flag12 = this._ABH != this.JDIEJIOALBJFEGNLOFNIEOFHIEPHADLOHKBG || this._ATO || this._ATM == _bi2._ATN;
                if (flag12)
                {
                    bool flag13 = this.OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN != null;
                    if (flag13)
                    {
                        this.UpdateArgumentsHint(false);
                    }
                    bool flag14 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count > 0;
                    if (flag14)
                    {
                        TextPosition textPosition = new TextPosition(this._ABH._ABI, this._ABH._AEU);
                        int count = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count;
                        while (count-- > 0)
                        {
                            _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA epaffddcaeggcpdgeebebadboblmgpdeplea = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH[count];
                            bool flag15 = textPosition <= epaffddcaeggcpdgeebebadboblmgpdeplea.OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND || textPosition > epaffddcaeggcpdgeebebadboblmgpdeplea.AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
                            if (flag15)
                            {
                                this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.RemoveAt(count);
                            }
                        }
                        bool flag16 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count == 0;
                        if (flag16)
                        {
                            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                            cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK = (GCE._AVI)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUK, new GCE._AVI(this.OnInsertedText));
                            GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
                            cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO = (GCE._AVM)Delegate.Remove(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUO, new GCE._AVM(this.OnRemovedText));
                        }
                    }
                }
                bool flag17 = this._ABH != this.JDIEJIOALBJFEGNLOFNIEOFHIEPHADLOHKBG || this._ABQ._ASJ != this.DDEDCENDGNAJAOGKJCMAEGOHJHGEJMLIGKJA;
                if (flag17)
                {
                    bool flag18 = this._ATW() == null && !this._ARV();
                    if (flag18)
                    {
                        this.UpdateMatchingBraces();
                        this.DDEDCENDGNAJAOGKJCMAEGOHJHGEJMLIGKJA = this._ABQ._ASJ;
                        this.JDIEJIOALBJFEGNLOFNIEOFHIEPHADLOHKBG = this._ABH.Clone();
                    }
                }
            }
        }

        // Token: 0x0600032C RID: 812 RVA: 0x0003A328 File Offset: 0x00038528
        public void DoGUI(bool enableGUI = false)
        {
            bool flag = this._ABQ == null;
            if (!flag)
            {
                bool flag2 = this._ABQ._ARQ() == null;
                if (!flag2)
                {
                    bool flag3 = this._ABQ._ARQ().EndsWith(".dll", StringComparison.OrdinalIgnoreCase);
                    if (!flag3)
                    {
                        bool flag4 = this._ABQ._ARQ().EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
                        if (!flag4)
                        {
                            this._ABQ._ABT = (this._ABT = (this._ABQ._ARR ? _bi2.EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM : _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE));
                            bool flag5 = Event.current.type == 8;
                            if (flag5)
                            {
                                this.Initialize();
                            }
                            bool flag6 = Event.current.rawType == 2 && this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI && this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL;
                            if (flag6)
                            {
                                this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;
                                this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = false;
                                this.KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = false;
                            }
                            EditorWindow editorWindow = EditorWindow.focusedWindow;
                            bool flag7 = editorWindow == this._ABJ();
                            if (flag7)
                            {
                                _bi2.PBBPFHLOKNCCODDMCKNNJGFOGBHHKMDKKGHJ(this);
                            }
                            bool flag8 = editorWindow != null;
                            if (flag8)
                            {
                                bool flag9 = editorWindow == this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP || editorWindow == this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB || editorWindow == this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO;
                                if (flag9)
                                {
                                    editorWindow = _bi2.FCDGPNNHCEFBJKDFCKDNLICBBLOJGGIPBPIO;
                                }
                            }
                            bool flag10 = _bi2.FCDGPNNHCEFBJKDFCKDNLICBBLOJGGIPBPIO != EditorWindow.focusedWindow;
                            _bi2.FCDGPNNHCEFBJKDFCKDNLICBBLOJGGIPBPIO = EditorWindow.focusedWindow;
                            bool flag11 = flag10;
                            if (flag11)
                            {
                                bool flag12 = this._ABJ() == _bi2.FCDGPNNHCEFBJKDFCKDNLICBBLOJGGIPBPIO;
                                if (flag12)
                                {
                                    this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                }
                            }
                            Color color;
                            color..ctor(0f, 0f, 0f, 0.25f);
                            bool flag13 = _bg8._BAR;
                            if (flag13)
                            {
                                this.DoToolbar();
                                bool flag14 = this._ALP != null;
                                if (flag14)
                                {
                                    EditorGUI.DrawRect(new Rect(this._AFO.xMin, this._AFO.yMin - 1f, this._ALP.position.size.x, 1f), color);
                                }
                                else
                                {
                                    bool flag15 = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH != null;
                                    if (flag15)
                                    {
                                        EditorGUI.DrawRect(new Rect(this._AFO.xMin, this._AFO.yMin - 1f, this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.position.size.x, 1f), color);
                                    }
                                }
                            }
                            bool flag16 = _bg8._BAX;
                            if (flag16)
                            {
                                this.DoCodeNavigationToolbar();
                                bool flag17 = this._ALP != null;
                                if (flag17)
                                {
                                    EditorGUI.DrawRect(new Rect(this._AFO.xMin, this._AFO.yMin - 1f, this._ALP.position.size.x, 1f), color);
                                }
                                else
                                {
                                    bool flag18 = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH != null;
                                    if (flag18)
                                    {
                                        EditorGUI.DrawRect(new Rect(this._AFO.xMin, this._AFO.yMin - 1f, this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.position.size.x, 1f), color);
                                    }
                                }
                            }
                            bool flag19 = !_bg8._BAR.GNIO();
                            if (flag19)
                            {
                                this.DoSearchBox(default(Rect));
                            }
                            bool flag20 = ((this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF != null) ? (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? _bg8._BAC : _bg8._BAB) : (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? _bg8._BBO : _bg8._BBN));
                            bool flag21 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
                            if (flag21)
                            {
                                bool flag22 = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null && this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.FHKIKKJCPBCBKIHJEICNBIGGLCFEPPOPBHGB() != null;
                                if (flag22)
                                {
                                    this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.OnOwnerGUI();
                                }
                                bool flag23 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                                if (flag23)
                                {
                                    int length = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADN().Length;
                                    _bh4 _AAH = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.OnOwnerGUI();
                                    string text = ((_AAH != null) ? (_AAH._AW ?? "") : null);
                                    bool flag24 = _ba4._AFC && text != null && text.EndsWith("Attribute", StringComparison.Ordinal);
                                    if (flag24)
                                    {
                                        text = _ba4.NameOf(_AAH);
                                    }
                                    bool flag25 = text == this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO._ADN() && Event.current.character != '\n' && Event.current.keyCode != 271;
                                    if (flag25)
                                    {
                                        text = "";
                                    }
                                    bool flag26 = text != null;
                                    if (flag26)
                                    {
                                        this.CloseAutocomplete();
                                        this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;
                                        EditorWindow editorWindow2 = this._ABJ();
                                        bool flag27 = editorWindow2 != null && EditorWindow.focusedWindow != editorWindow2;
                                        if (flag27)
                                        {
                                            editorWindow2.Focus();
                                        }
                                    }
                                    bool flag28 = !string.IsNullOrEmpty(text);
                                    if (flag28)
                                    {
                                        bool flag29 = !this.TryEdit();
                                        if (flag29)
                                        {
                                            text = null;
                                            Event.current.Use();
                                        }
                                    }
                                    bool flag30 = !string.IsNullOrEmpty(text);
                                    if (flag30)
                                    {
                                        string text2 = this._ABQ.FLOg[this._ABH._ABI];
                                        GCE._AFA _ATD = this._ABH.Clone();
                                        _be5 gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl = _AAH as _be5;
                                        bool flag31 = gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl != null;
                                        if (flag31)
                                        {
                                            bool flag32 = Event.current.character != '\n' && Event.current.character != '\t' && Event.current.keyCode != 271;
                                            if (flag32)
                                            {
                                                goto IL_0A3D;
                                            }
                                            bool flag33 = text.EndsWith("...", StringComparison.Ordinal);
                                            if (flag33)
                                            {
                                                text = text.Substring(0, text.Length - 3);
                                            }
                                        }
                                        bool flag34 = Event.current.isKey && gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl == null;
                                        if (flag34)
                                        {
                                            try
                                            {
                                                this.ProcessEditorKeyboard(Event.current, true);
                                                bool flag35 = Event.current == null || Event.current.type == 12;
                                                if (flag35)
                                                {
                                                    _bi2._AKS = false;
                                                }
                                            }
                                            catch (ExitGUIException)
                                            {
                                            }
                                        }
                                        this._ABQ.EndEdit();
                                        this._ABQ.BeginEdit("Auto Completion '" + text + "'");
                                        string text3 = null;
                                        bool flag36 = gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl == null && this._ABH > _ATD && this._ABQ.FLOg[_ATD._ABI].Length >= _ATD._AEU;
                                        if (flag36)
                                        {
                                            text3 = this._ABQ.GetTextRange(_ATD, this._ABH);
                                            bool flag37 = text3[0] == '\n';
                                            if (flag37)
                                            {
                                                this._ABH = this._ABQ.DeleteText(_ATD, this._ABH);
                                                string text4 = this._ABQ.FLOg[this._ABH._ABI];
                                                int num = text4.Length - text2.Length;
                                                bool flag38 = num < 0;
                                                if (flag38)
                                                {
                                                    this._ABQ.InsertText(this._ABH, text2.Substring(this._ABH._AEU, -num));
                                                }
                                            }
                                            else
                                            {
                                                bool flag39 = Event.current.character != '\t';
                                                if (flag39)
                                                {
                                                    text += text3;
                                                    this._ABH = this._ABQ.DeleteText(_ATD, this._ABH);
                                                }
                                                else
                                                {
                                                    this._ABH = this._ABQ.DeleteText(_ATD, this._ABH);
                                                }
                                            }
                                        }
                                        bool flag40 = gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl != null;
                                        if (flag40)
                                        {
                                            gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl.OverrideTypedInLength(ref length);
                                        }
                                        bool flag41 = length > 0;
                                        if (flag41)
                                        {
                                            GCE._AFA _ATD2 = _ATD.Clone();
                                            _ATD._AEU -= length;
                                            this._ABH = this._ABQ.DeleteText(_ATD, _ATD2);
                                        }
                                        this._ABH = this._ABQ.InsertText(_ATD, text);
                                        string text5 = null;
                                        bool flag42 = text3 != null;
                                        if (flag42)
                                        {
                                            text5 = this.CheckAutoClose(text3[0]);
                                        }
                                        int num2 = this._ABH._ABI;
                                        bool flag43 = text5 != null;
                                        if (flag43)
                                        {
                                            _bc5._AOM = true;
                                            num2 = this._ABQ.InsertText(this._ABH, text5)._ABI;
                                            _bc5._AOM = false;
                                            _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA epaffddcaeggcpdgeebebadboblmgpdeplea = new _bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA
                                            {
                                                OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND = new TextPosition(this._ABH._ABI, this._ABH._AEU - 1),
                                                AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB = new TextPosition(this._ABH._ABI, this._ABH._AEU)
                                            };
                                            this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Add(epaffddcaeggcpdgeebebadboblmgpdeplea);
                                            bool flag44 = this.KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH.Count == 1;
                                            if (flag44)
                                            {
                                                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj = this._ABQ;
                                                cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUO = (GCE._AVM)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj._AUO, new GCE._AVM(this.OnRemovedText));
                                                GCE cdghkglnkfhjenlebomgbogcmlafoejmngmj2 = this._ABQ;
                                                cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUK = (GCE._AVI)Delegate.Combine(cdghkglnkfhjenlebomgbogcmlafoejmngmj2._AUK, new GCE._AVI(this.OnInsertedText));
                                            }
                                        }
                                        bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                        if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                                        {
                                            this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                                        }
                                        this._ABQ.UpdateHighlighting(_ATD._ABI, num2, false);
                                        bool flag45 = gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl != null;
                                        if (flag45)
                                        {
                                            this.ExpandSnippet(gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl);
                                        }
                                        else
                                        {
                                            this.ReindentLines(_ATD._ABI, num2);
                                        }
                                        this._ATM = _bi2._ATN;
                                        this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                        this._ATO = true;
                                        bool flag46 = this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM != null && gnahabjnnpkneoolbdnkmbpaeplmlkmclkcl == null;
                                        if (flag46)
                                        {
                                            this.AfterCharecterTyped(this.IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM, this._ABH._ABI, this._ABH._AEU);
                                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                                        }
                                        GUIUtility.ExitGUI();
                                    }
                                    bool flag47 = Event.current.type == 12;
                                    if (flag47)
                                    {
                                        return;
                                    }
                                }
                            IL_0A3D:
                                bool flag48 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null && this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.FHKIKKJCPBCBKIHJEICNBIGGLCFEPPOPBHGB() != null;
                                if (flag48)
                                {
                                    this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB.OnOwnerGUI();
                                }
                                bool flag49 = this._ABQ != null && this.ProcessCodeViewCommands();
                                if (flag49)
                                {
                                    return;
                                }
                                bool flag50 = Application.platform == 0;
                                bool flag51 = Event.current.type == 16 || (flag50 && Event.current.type == 1 && Event.current.button == 1);
                                bool flag52 = (Event.current.type == 4 && (Event.current.keyCode == 319 || Event.current.Equals(Event.KeyboardEvent("#f12")))) || (flag51 && this._AFO.Contains(Event.current.mousePosition));
                                if (flag52)
                                {
                                    Event.current.Use();
                                    GenericMenu genericMenu = new GenericMenu();
                                    bool flag53 = this._ATW() != null && this._ATW()._ABI == this._ABH._ABI;
                                    bool mljcflpnjpehbilbamiacglghfegimgdpmnb = this._ABQ._ASC;
                                    if (mljcflpnjpehbilbamiacglghfegimgdpmnb)
                                    {
                                        int num3;
                                        int num4;
                                        bool flag54;
                                        SyntaxToken token = this._ABQ.GetTokenAt(this._ABH, out num3, out num4, out flag54);
                                        bool flag55 = token != null;
                                        if (flag55)
                                        {
                                            bool flag56 = flag54 && token.tokenKind != SyntaxToken.Kind.Identifier && token.tokenKind != SyntaxToken.Kind.ContextualKeyword && token.tokenKind != SyntaxToken.Kind.Keyword;
                                            if (flag56)
                                            {
                                                List<SyntaxToken> _ABS = this._ABQ._AQQ[num3].EOIA;
                                                bool flag57 = num4 < _ABS.Count - 1;
                                                if (flag57)
                                                {
                                                    token = _ABS[num4 + 1];
                                                }
                                            }
                                            bool flag58 = token.OOME != null && token.OOME._AAB() != null && token.OOME._AJF == "unknown symbol";
                                            if (flag58)
                                            {
                                                List<_AQA> fixes = _bc9.GetFixes(this._ABQ, token);
                                                foreach (_AQA kclolinkdgmfifeiidoolpiiejameegabmlg in fixes)
                                                {
                                                    _AQA captured = kclolinkdgmfifeiidoolpiiejameegabmlg;
                                                    genericMenu.AddItem(new GUIContent("Fix/" + captured.GetTitle(token)), false, delegate
                                                    {
                                                        this.BeginRefactoring(captured.GetTitle(token));
                                                        captured.Apply(this, token);
                                                        this.EndRefactoring();
                                                    });
                                                }
                                                bool flag59 = fixes.Count > 0;
                                                if (flag59)
                                                {
                                                    genericMenu.AddSeparator("");
                                                }
                                            }
                                            string helpUrl = this.HelpURL();
                                            bool flag60 = helpUrl != null;
                                            if (flag60)
                                            {
                                                bool flag61 = token.tokenKind == SyntaxToken.Kind.Keyword;
                                                if (flag61)
                                                {
                                                    genericMenu.AddItem("MSDN C# Reference", "%'", "MSDN C# Reference", "f1", false, delegate
                                                    {
                                                        Help.BrowseURL(helpUrl);
                                                    });
                                                }
                                                else
                                                {
                                                    bool flag62 = helpUrl.StartsWith("file:///unity/ScriptReference/", StringComparison.OrdinalIgnoreCase);
                                                    if (flag62)
                                                    {
                                                        genericMenu.AddItem("Unity Script Reference", "%'", "Unity Scripting Reference", "f1", false, delegate
                                                        {
                                                            Help.ShowHelpPage(helpUrl);
                                                        });
                                                    }
                                                    else
                                                    {
                                                        bool flag63 = helpUrl.StartsWith("http://docs.unity3d.com/", StringComparison.OrdinalIgnoreCase);
                                                        if (flag63)
                                                        {
                                                            genericMenu.AddItem("Unity Script Reference", "%'", "Unity Scripting Reference", "f1", false, delegate
                                                            {
                                                                Help.BrowseURL(helpUrl);
                                                            });
                                                        }
                                                        else
                                                        {
                                                            genericMenu.AddItem("MSDN .Net Reference", "%'", "MSDN .Net Reference", "f1", false, delegate
                                                            {
                                                                Help.BrowseURL(helpUrl);
                                                            });
                                                        }
                                                    }
                                                }
                                            }
                                            bool flag64 = token.OOME != null && token.OOME._AAB() != null;
                                            if (flag64)
                                            {
                                                this._AMN = token.OOME._AAB();
                                                this._AN = this._AMN.Assembly;
                                                bool flag65 = this._AN == null && this._AMN._AEI != null;
                                                if (flag65)
                                                {
                                                    this._AN = ((_be7)this._ABQ._AOU()._AQT()._AIT._AJW)._AN;
                                                }
                                                bool flag66 = this._AN != null;
                                                if (flag66)
                                                {
                                                    string text6 = this._AN.AssemblyName;
                                                    bool flag67 = text6 == "mscorlib" || text6 == "System" || text6.StartsWith("System.", StringComparison.Ordinal);
                                                    if (flag67)
                                                    {
                                                        bool flag68 = this._AMN._AT != SymbolKind.Namespace;
                                                        if (flag68)
                                                        {
                                                            string text7 = this._AMN._BEX();
                                                            bool flag69 = text7 != null;
                                                            if (flag69)
                                                            {
                                                                MD5 md = MD5.Create();
                                                                byte[] bytes = Encoding.UTF8.GetBytes(text7);
                                                                byte[] array = md.ComputeHash(bytes);
                                                                char[] c = new char[16];
                                                                for (int i = 0; i < 8; i++)
                                                                {
                                                                    byte b = (byte)(array[i] >> 4);
                                                                    c[i * 2] = (char)((b > 9) ? (b + 87) : (b + 48));
                                                                    b = array[i] & 15;
                                                                    c[i * 2 + 1] = (char)((b > 9) ? (b + 87) : (b + 48));
                                                                }
                                                                genericMenu.AddItem("Go To Definition (.Net)", "F12", "Go To Definition (.Net)", "F12", false, delegate
                                                                {
                                                                    Help.BrowseURL("http://referencesource.microsoft.com/mscorlib/a.html#" + new string(c));
                                                                });
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bool ppfhkdollcggpjafekhmnabknmlonajanclj = this._AN.PPFHKDOLLCGGPJAFEKHMNABKNMLONAJANCLJ;
                                                        if (ppfhkdollcggpjafekhmnabknmlonajanclj)
                                                        {
                                                            List<FKI> declarations = this.GetSymbolDeclarations(null);
                                                            this._AMN = this._AMN.Rebind() ?? this._AMN;
                                                            bool flag70 = declarations != null && declarations.Count == 1;
                                                            if (flag70)
                                                            {
                                                                genericMenu.AddItem("Go To Definition", "F12", "Go To Definition", "F12", false, delegate
                                                                {
                                                                    this.GoToSymbolDeclaration(declarations[0]);
                                                                });
                                                            }
                                                            else
                                                            {
                                                                bool flag71 = declarations != null && declarations.Count > 0;
                                                                if (flag71)
                                                                {
                                                                    foreach (FKI _AFF in declarations)
                                                                    {
                                                                        _bm6 _AQI = _AFF._AJW;
                                                                        while (_AQI._AMJ() != null)
                                                                        {
                                                                            _AQI = _AQI._AMJ();
                                                                        }
                                                                        string text8 = ((_be7)_AQI)._AWJ;
                                                                        text8 = AssetDatabase.AssetPathToGUID(text8);
                                                                        text8 = AssetDatabase.GUIDToAssetPath(text8);
                                                                        text8 = Path.GetFileName(text8);
                                                                        _bb4._AIN _AIO = _AFF.NameNode();
                                                                        _bb4.DHBA _AEM = (_AIO as _bb4.DHBA) ?? (_AIO as _bb4._ACW).GetFirstLeaf();
                                                                        bool flag72 = _AFF._ACV._AT == SymbolKind.Method;
                                                                        if (flag72)
                                                                        {
                                                                            _bh4 _APX = _AFF._ACV;
                                                                            string text9 = _AFF.Name + " (" + _APX.PrintParameters(_APX.GetParameters(), true) + ")";
                                                                            genericMenu.AddItem(new GUIContent("Go To Overload Definition/" + text9), false, delegate (object d)
                                                                            {
                                                                                this.GoToSymbolDeclaration((FKI)d);
                                                                            }, _AFF);
                                                                        }
                                                                        else
                                                                        {
                                                                            genericMenu.AddItem(new GUIContent("Go To Definition/" + text8 + " : " + (_AEM._ACX.Line + 1).ToString()), false, delegate (object d)
                                                                            {
                                                                                this.GoToSymbolDeclaration((FKI)d);
                                                                            }, _AFF);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            _b2 _AAC = ((this._AMN != null) ? (this._AMN.TypeOf() as _b2) : null);
                                                            bool flag73 = _AAC != this._AMN && _AAC != null;
                                                            if (flag73)
                                                            {
                                                                this.AddGoToTypeDefinitionMenuItems(genericMenu, _AAC);
                                                            }
                                                        }
                                                    }
                                                    TextSpan tokenSpan = this._ABQ.GetTokenSpan(token.Line, token.TokenIndex);
                                                    bool flag74 = this._ATW() == null || (this._ATW()._ABI == tokenSpan.StartPosition.line && this._ATW()._AEU == tokenSpan.StartPosition.index && this._ABH._ABI == tokenSpan.EndPosition.line && this._ABH._AEU == tokenSpan.EndPosition.index) || (this._ATW()._ABI == tokenSpan.EndPosition.line && this._ATW()._AEU == tokenSpan.EndPosition.index && this._ABH._ABI == tokenSpan.StartPosition.line && this._ABH._AEU == tokenSpan.StartPosition.index);
                                                    if (flag74)
                                                    {
                                                        bool flag75 = this._AMN != null;
                                                        if (flag75)
                                                        {
                                                            flag53 = false;
                                                            genericMenu.AddItem("Find All References", "%#r", "Find All References", "#f12", false, delegate
                                                            {
                                                                _bh6.FindAllReferences(this._AMN, this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC());
                                                            });
                                                        }
                                                    }
                                                    bool flag76 = this._AN != null && this._AN.PPFHKDOLLCGGPJAFEKHMNABKNMLONAJANCLJ;
                                                    if (flag76)
                                                    {
                                                        bool flag77 = this.GetSymbolDeclarations(null) != null && this.GetSymbolDeclarations(null).Count > 0;
                                                        if (flag77)
                                                        {
                                                            genericMenu.AddItem("Rename " + this._AMN._AT.ToString() + "...", "", "Rename " + this._AMN._AT.ToString() + "...", "", false, delegate
                                                            {
                                                                _bc2.CreateWindow(this._AMN, this.NOKEHFCAKDDOPKCFMLCLBACCAHNLKLHBCEDC());
                                                            });
                                                        }
                                                    }
                                                }
                                                bool flag78 = this._AMN != null && this._AMN._AT == SymbolKind.Method && this._AMN.GetParameters().Count == 0 && this._AMN.IsStatic;
                                                if (flag78)
                                                {
                                                    bool flag79 = flag53;
                                                    if (flag79)
                                                    {
                                                        flag53 = false;
                                                        genericMenu.AddItem("Find in Files...", "%#f", "Find in Files...", "%#f", false, new GenericMenu.MenuFunction(_bg3.ShowFindInFilesWindow));
                                                    }
                                                    bool flag80 = genericMenu.GetItemCount() > 0;
                                                    if (flag80)
                                                    {
                                                        genericMenu.AddSeparator("");
                                                    }
                                                    genericMenu.AddItem("Execute", "%e", "Execute", "%e", false, new GenericMenu.MenuFunction(this.ExecuteStaticMethod));
                                                }
                                            }
                                        }
                                    }
                                    bool flag81 = flag53;
                                    if (flag81)
                                    {
                                        genericMenu.AddItem("Find in Files...", "%#f", "Find in Files...", "%#f", false, new GenericMenu.MenuFunction(_bg3.ShowFindInFilesWindow));
                                        genericMenu.AddItem("Replace in Files...", "%r", "Replace in Files...", "%r", false, new GenericMenu.MenuFunction(_bg3.ShowReplaceInFilesWindow));
                                    }
                                    bool flag82 = genericMenu.GetItemCount() > 0;
                                    if (flag82)
                                    {
                                        genericMenu.AddSeparator(string.Empty);
                                    }
                                    bool flag83 = this._ATW() != null;
                                    if (flag83)
                                    {
                                        genericMenu.AddItem("Copy", "%c", "Copy", "%c", false, delegate
                                        {
                                            EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("Copy"));
                                        });
                                        genericMenu.AddItem("Cut", "%x", "Cut", "%x", false, delegate
                                        {
                                            EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("Cut"));
                                        });
                                    }
                                    else
                                    {
                                        bool flag84 = _bg8._BAP;
                                        if (flag84)
                                        {
                                            genericMenu.AddItem("Copy Line", "%c", "Copy Line", "%c", false, delegate
                                            {
                                                EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("Copy"));
                                            });
                                            genericMenu.AddItem("Cut Line", "%x", "Cut Line", "%x", false, delegate
                                            {
                                                EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("Cut"));
                                            });
                                        }
                                        else
                                        {
                                            genericMenu.AddItem("Copy", "%c", "Copy", "%c", false, null);
                                            genericMenu.AddItem("Cut", "%x", "Cut", "%x", false, null);
                                        }
                                    }
                                    bool flag85 = string.IsNullOrEmpty(EditorGUIUtility.systemCopyBuffer);
                                    if (flag85)
                                    {
                                        genericMenu.AddItem("Paste", "%v", "Paste", "%v", false, null);
                                    }
                                    else
                                    {
                                        genericMenu.AddItem("Paste", "%v", "Paste", "%v", false, delegate
                                        {
                                            EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("Paste"));
                                        });
                                    }
                                    genericMenu.AddSeparator(string.Empty);
                                    genericMenu.AddItem("Switch Tab...", "&\t", "Switch Tab...", "%tab", false, delegate
                                    {
                                        _bh1.MenuCreate();
                                    });
                                    genericMenu.AddSeparator(string.Empty);
                                    genericMenu.AddItem("Select All", "%a", "Select All", "%a", false, delegate
                                    {
                                        EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("SelectAll"));
                                    });
                                    bool flag86 = !this._ABQ._ARR;
                                    if (flag86)
                                    {
                                        genericMenu.AddItem("Toggle Line Comment(s)", "%/", "Toggle Line Comment(s)", "%/", false, new GenericMenu.MenuFunction(this.ToggleCommentSelection));
                                    }
                                    genericMenu.AddItem("Indent", "%]", "Indent", "%]", false, new GenericMenu.MenuFunction(this.IndentMore));
                                    genericMenu.AddItem("Unindent", "%[", "Unindent", "%[", false, new GenericMenu.MenuFunction(this.IndentLess));
                                    genericMenu.AddItem("Go to Line...", "%g", "Go to Line...", "%g", false, delegate
                                    {
                                        _b4.Create(this);
                                    });
                                    genericMenu.AddItem("Open external IDE at Line " + (this._ABH._ABI + 1).ToString(), "%\n", "Open external IDE at Line " + (this._ABH._ABI + 1).ToString(), "%Enter", false, delegate
                                    {
                                        EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("OpenAtCursor"));
                                    });
                                    SyntaxToken syntaxToken = this.GetTokenAtCursor();
                                    bool flag87 = (syntaxToken != null && syntaxToken.tokenKind < SyntaxToken.Kind.Keyword && syntaxToken.tokenKind != SyntaxToken.Kind.BuiltInLiteral) || !this._ABQ._ASC;
                                    if (flag87)
                                    {
                                        syntaxToken = null;
                                    }
                                    bool ciollbejaojggedhbafdiiephpnccnjpfnci = this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI;
                                    Rect rect;
                                    if (ciollbejaojggedhbafdiiephpnccnjpfnci)
                                    {
                                        rect..ctor(Event.current.mousePosition.x, Event.current.mousePosition.y, 1f, 1f);
                                    }
                                    else
                                    {
                                        rect = ((syntaxToken != null) ? this.GetTokenRect(syntaxToken) : this.GetCaretRect(this._ABH));
                                        rect.x += this._AFO.x - this._AFS.x;
                                        rect.y += 4f + this._AFO.y - this._AFS.y;
                                        bool flag88 = syntaxToken != null;
                                        if (flag88)
                                        {
                                            Vector2 vector = GUIUtility.ScreenToGUIPoint(new Vector2(rect.x, rect.y));
                                            rect.x += vector.x - rect.x;
                                            rect.y += vector.y - rect.y;
                                        }
                                    }
                                    genericMenu.DropDown(rect);
                                    return;
                                }
                                bool isKey = Event.current.isKey;
                                if (isKey)
                                {
                                    this.ProcessEditorKeyboard(Event.current, false);
                                    bool flag89 = Event.current == null || Event.current.type == 12;
                                    if (flag89)
                                    {
                                        _bi2._AKS = false;
                                        GUIUtility.ExitGUI();
                                        return;
                                    }
                                }
                            }
                            bool flag90 = Event.current.type == 6;
                            if (flag90)
                            {
                                this.GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII = null;
                                this.OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC = default(DateTime);
                                bool flag91 = this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP != null;
                                if (flag91)
                                {
                                    this.ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP.Hide();
                                }
                                bool flag92 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                                if (flag92)
                                {
                                    this.CloseArgumentsHint();
                                }
                            }
                            bool flag93 = _bg8._BAL;
                            if (flag93)
                            {
                                bool flag94 = Event.current.type == 6;
                                if (flag94)
                                {
                                    bool actionKey = EditorGUI.actionKey;
                                    if (actionKey)
                                    {
                                        bool lcmgiakmdblnmjehgkejjmkghgonffbgmcfo = this.LCMGIAKMDBLNMJEHGKEJJMKGHGONFFBGMCFO;
                                        if (lcmgiakmdblnmjehgkejjmkghgonffbgmcfo)
                                        {
                                            Event.current.Use();
                                            this.ModifyFontSize(-(int)Event.current.delta.y);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        this.LCMGIAKMDBLNMJEHGKEJJMKGHGONFFBGMCFO = false;
                                    }
                                }
                                else
                                {
                                    bool flag95 = !this.LCMGIAKMDBLNMJEHGKEJJMKGHGONFFBGMCFO;
                                    if (flag95)
                                    {
                                        bool flag96 = Event.current.type == null || Event.current.character > '\0';
                                        if (flag96)
                                        {
                                            this.LCMGIAKMDBLNMJEHGKEJJMKGHGONFFBGMCFO = true;
                                        }
                                    }
                                }
                            }
                            this.HNBKJDKPBPNIOBIGJKDEDOFLENDLKDCOCMAH = Mathf.Round(Mathf.Max(this.HNBKJDKPBPNIOBIGJKDEDOFLENDLKDCOCMAH, (float)this._ABQ._ABU * this._AEY().x));
                            float num5 = Mathf.Max(this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width - 8f, this.HNBKJDKPBPNIOBIGJKDEDOFLENDLKDCOCMAH);
                            float num6 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? (this.GetLineOffset(this._ABQ.FLOg.Count) + 8f) : (8f + this._AEY().y * (float)this._ABQ._AQQ.Length));
                            this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.Set(-4f, -4f, num5 + 8f, num6);
                            bool flag97 = Event.current.type != 8;
                            if (flag97)
                            {
                                this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK = 0f;
                                bool flag98 = flag20;
                                if (flag98)
                                {
                                    this.GBDPEFEOCLPNDEPKHJNLBKNGGHIDLKLJEOJK = Mathf.FloorToInt(Mathf.Log10((float)(this._ABQ._AQQ.Length + 1 + this.BEOOILOKJPMGIAIFECEOEGHJCFAFCGJFJICN)) + 1f);
                                    this.BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG = this._AEY().x * (float)this.GBDPEFEOCLPNDEPKHJNLBKNGGHIDLKLJEOJK;
                                    this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK = this.BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG;
                                }
                                bool flag99 = this.HFBBKNBEOLAICCGCIFGLPKHFCNHPANGIIGDM();
                                if (flag99)
                                {
                                    this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK += (flag20 ? 7f : 3f);
                                }
                                bool flhmmgogabacngebpcfefgpmfnakdpiglabb = this.FLHMMGOGABACNGEBPCFEFGPMFNAKDPIGLABB;
                                if (flhmmgogabacngebpcfefgpmfnakdpiglabb)
                                {
                                    this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK += this._AEY().x;
                                }
                                bool flag100 = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK > 0f;
                                if (flag100)
                                {
                                    this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK += 9f;
                                }
                            }
                            int num7;
                            int num8;
                            for (; ; )
                            {
                                this._AFS.y = this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE) + this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF;
                                num7 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? this.GetLineAt(this._AFS.y) : Math.Max(0, (int)(this._AFS.y / this._AEY().y) - 1));
                                num8 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? (1 + this.GetLineAt(this._AFS.y + this._AFO.height)) : ((this._AFO.height > 0f) ? (num7 + 2 + (int)(this._AFO.height / this._AEY().y)) : ((int)((float)Screen.height / EditorGUIUtility.pixelsPerPoint / this._AEY().y))));
                                bool flag101 = num8 > this._ABQ._AQQ.Length;
                                if (flag101)
                                {
                                    num8 = this._ABQ._AQQ.Length;
                                    num7 = Mathf.Max(0, Mathf.Min(num7, num8 - (int)(this._AFO.height / this._AEY().y)));
                                }
                                bool flag102 = this._ATO && Event.current.type != 8;
                                if (flag102)
                                {
                                    this._ATO = false;
                                    GCE._AFA _ATD3 = ((this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL && this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI) ? this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND : this._ABH);
                                    this._ALM.x = this._AFS.x + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                    this._ALM.y = this._AFS.y;
                                    this._ALM.width = this._AFO.width - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 4f;
                                    this._ALM.height = this._AFO.height - 4f;
                                    float num9 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? (this.GetLineOffset(this._ABQ.FLOg.Count) + 8f) : this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.height);
                                    bool flag103 = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width - 4f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this.MFHBMAGLJHOKEHCENMEKNBKPGBPBEECMDAKC > this._ALM.width;
                                    bool flag104 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? num9 : this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.height) - 4f > this._ALM.height;
                                    bool flag105 = flag103 && flag104;
                                    if (flag105)
                                    {
                                        this._ALM.width = this._ALM.width - 15f;
                                        this._ALM.height = this._ALM.height - 15f;
                                    }
                                    else
                                    {
                                        bool flag106 = flag103;
                                        if (flag106)
                                        {
                                            this._ALM.height = this._ALM.height - 15f;
                                            flag104 = this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.height - 4f > this._ALM.height;
                                            bool flag107 = flag104;
                                            if (flag107)
                                            {
                                                this._ALM.width = this._ALM.width - 15f;
                                            }
                                        }
                                        else
                                        {
                                            bool flag108 = flag104;
                                            if (flag108)
                                            {
                                                this._ALM.width = this._ALM.width - 15f;
                                                flag103 = this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width - 4f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this.MFHBMAGLJHOKEHCENMEKNBKPGBPBEECMDAKC > this._ALM.width;
                                                bool flag109 = flag103;
                                                if (flag109)
                                                {
                                                    this._ALM.height = this._ALM.height - 15f;
                                                }
                                            }
                                        }
                                    }
                                    this._ALM.xMin = Mathf.Ceil((this._ALM.x - 1f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK) / this._AEY().x) * this._AEY().x + 0f + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                    this._ALM.width = Mathf.Floor(this._ALM.width / this._AEY().x) * this._AEY().x;
                                    this._ALM.yMin = Mathf.Ceil(this._ALM.y / this._AEY().y) * this._AEY().y;
                                    this._ALM.height = Mathf.Floor(this._ALM.height / this._AEY().y) * this._AEY().y;
                                    bool bopcdiiiaacdailgpofhgpkbbolaifbdfado2 = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                    float num12;
                                    if (bopcdiiiaacdailgpofhgpkbbolaifbdfado2)
                                    {
                                        int num10;
                                        int num11;
                                        this.BufferToViewPosition(this._ABH, out num10, out num11);
                                        num12 = this._AEY().y * (float)num10 + this.GetLineOffset(_ATD3._ABI);
                                    }
                                    else
                                    {
                                        num12 = this._AEY().y * (float)_ATD3._ABI;
                                    }
                                    bool flag110 = num12 < this._AFS.y;
                                    if (flag110)
                                    {
                                        this._AFS.y = num12;
                                        this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                        this._ATO = true;
                                    }
                                    float num13 = num12 + this._AEY().y - this._AFO.height + (flag103 ? 23f : 8f);
                                    bool flag111 = num13 > 0f && num13 > this._AFS.y;
                                    if (flag111)
                                    {
                                        this._AFS.y = num13;
                                        this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                        this._ATO = true;
                                    }
                                    bool flag112 = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                    if (flag112)
                                    {
                                        Rect caretRect = this.GetCaretRect(_ATD3);
                                        caretRect.x -= this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                        bool flag113 = caretRect.x < this._AFS.x;
                                        if (flag113)
                                        {
                                            float x = this._AFS.x;
                                            this._AFS.x = Mathf.Round(Mathf.Max(0f, caretRect.x - 20f * this._AEY().x));
                                            bool flag114 = x != this._AFS.x;
                                            if (flag114)
                                            {
                                                this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                                this._ATO = true;
                                                bool flag115 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                                                if (flag115)
                                                {
                                                    Rect position = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.position;
                                                    position.x += x - this._AFS.x;
                                                    this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.position = position;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            bool flag116 = caretRect.x + this._AEY().x > this._AFS.x + this._AFO.width - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 22f;
                                            if (flag116)
                                            {
                                                float x2 = this._AFS.x;
                                                this._AFS.x = Mathf.Max(0f, caretRect.x + 21f * this._AEY().x - this._AFO.width + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK + 22f);
                                                bool flag117 = x2 != this._AFS.x;
                                                if (flag117)
                                                {
                                                    this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                                    this._ATO = true;
                                                    bool flag118 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO != null;
                                                    if (flag118)
                                                    {
                                                        Rect position2 = this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.position;
                                                        position2.x += x2 - this._AFS.x;
                                                        this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO.position = position2;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    bool faabiagajjgamjhjffckggmdofhdolelpkpn = this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN;
                                    if (faabiagajjgamjhjffckggmdofhdolelpkpn)
                                    {
                                        bool flag119 = this._ATO && this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null;
                                        if (flag119)
                                        {
                                            this.CloseArgumentsHint();
                                        }
                                        bool flag120 = this.CanEdit();
                                        if (flag120)
                                        {
                                            this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                            this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                        }
                                        this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = false;
                                        continue;
                                    }
                                }
                                bool flag121 = this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC >= 1f && this._AFO.height > 1f && Event.current.type == 8;
                                if (flag121)
                                {
                                    bool flag122 = this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.yMin < this._AFS.y + 30f || this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.yMax > this._AFS.y + this._AFO.height - 50f;
                                    if (flag122)
                                    {
                                        float num14 = Mathf.Floor(Mathf.Max(0f, this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.center.y - this._AFO.height * 0.5f));
                                        bool flag123 = this._AFS.y != num14;
                                        if (flag123)
                                        {
                                            this._AFS.y = num14;
                                            this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                        }
                                    }
                                    bool flag124 = this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.xMin < this._AFS.x + 30f || this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.xMax > this._AFS.x + this._AFO.width - 30f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                    if (flag124)
                                    {
                                        float num15 = Mathf.Floor(Mathf.Max(0f, this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF.center.x - this._AFO.width * 0.5f));
                                        bool flag125 = this._AFS.x != num15;
                                        if (flag125)
                                        {
                                            this._AFS.x = num15;
                                            this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = true;
                                        }
                                    }
                                    bool faabiagajjgamjhjffckggmdofhdolelpkpn2 = this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN;
                                    if (faabiagajjgamjhjffckggmdofhdolelpkpn2)
                                    {
                                        this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO = _bi2._ATN;
                                        bool flag126 = this.CanEdit();
                                        if (flag126)
                                        {
                                            this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                            this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                        }
                                        this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = false;
                                        continue;
                                    }
                                    this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 0.999f;
                                }
                                bool flag127 = Event.current.type == 7;
                                if (!flag127)
                                {
                                    break;
                                }
                                bool faabiagajjgamjhjffckggmdofhdolelpkpn3 = this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN;
                                if (!faabiagajjgamjhjffckggmdofhdolelpkpn3)
                                {
                                    break;
                                }
                                this.FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN = false;
                                bool flag128 = this.CanEdit();
                                if (flag128)
                                {
                                    int ainbdlceicdfcimeofnoefahllpoheecopne = this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE;
                                    float lpapjbhkomflpdifiijehjbmoefhhaibgjbf = this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF;
                                    this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                    this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                    bool flag129 = ainbdlceicdfcimeofnoefahllpoheecopne != this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE || lpapjbhkomflpdifiijehjbmoefhhaibgjbf != this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF;
                                    if (!flag129)
                                    {
                                        break;
                                    }
                                }
                            }
                            bool flag130 = Event.current.type == 8;
                            if (flag130)
                            {
                                bool flag131 = this.CanEdit();
                                if (flag131)
                                {
                                    this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                    this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                }
                            }
                            else
                            {
                                GUI.Box(this._AFO, GUIContent.none, this._ABT.MNAINPPJCJGPLHBFJICPBAPKHGGPKHFKGHKI);
                                bool flag132 = this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA != null && this.DAOLEHELIBAIPNAPOFMDOLIAOEHCLFOGLHGI != Vector2.zero;
                                if (flag132)
                                {
                                    this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA.mousePosition -= this._AFS;
                                    this._AFS += this.DAOLEHELIBAIPNAPOFMDOLIAOEHCLFOGLHGI;
                                    this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                    this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                    num7 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE : Math.Max(0, (int)(this._AFS.y / this._AEY().y) - 1));
                                    num8 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? (1 + this.GetLineAt(this._AFS.y + this._AFO.height)) : ((this._AFO.height > 0f) ? (num7 + 2 + (int)(this._AFO.height / this._AEY().y)) : ((int)((float)Screen.height / EditorGUIUtility.pixelsPerPoint / this._AEY().y))));
                                    bool flag133 = num8 > this._ABQ._AQQ.Length;
                                    if (flag133)
                                    {
                                        num8 = this._ABQ._AQQ.Length;
                                        num7 = Mathf.Max(0, Mathf.Min(num7, num8 - (int)(this._AFO.height / this._AEY().y)));
                                    }
                                }
                                bool flag134 = !this.FCDDEENLBDFBMKEFLKIKPCKPAAGBJLEPHCHC;
                                if (flag134)
                                {
                                    this.FCDDEENLBDFBMKEFLKIKPCKPAAGBJLEPHCHC = true;
                                    this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE = this._AFS;
                                    this.EMPLHHGIPJCGEICPFEHNLAIMLHOHKPNCGCCO = Vector2.zero;
                                    this.NJLKIOECLMPLPCIEOLCBGKJBLDPMHBCHJBJN = default(DateTime);
                                }
                                bool flag135 = float.IsNaN(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x) || float.IsNaN(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.y);
                                if (flag135)
                                {
                                    this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE = this._AFS;
                                    this.EMPLHHGIPJCGEICPFEHNLAIMLHOHKPNCGCCO = Vector2.zero;
                                    this.NJLKIOECLMPLPCIEOLCBGKJBLDPMHBCHJBJN = default(DateTime);
                                    bool flag136 = float.IsNaN(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x) || float.IsNaN(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.y);
                                    if (flag136)
                                    {
                                        this.FCDDEENLBDFBMKEFLKIKPCKPAAGBJLEPHCHC = false;
                                    }
                                }
                                bool flag137 = Event.current.type == 6 && this._AFO.Contains(Event.current.mousePosition);
                                bool flag138 = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && flag137 && Event.current.shift;
                                if (flag138)
                                {
                                    Event current = Event.current;
                                    current.delta = new Vector2(current.delta.y, current.delta.x);
                                    Event.current = current;
                                }
                                bool flag139 = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && flag137;
                                if (flag139)
                                {
                                    this._AFS.x = Mathf.Clamp(this._AFS.x + Event.current.delta.x * this._AEY().y, 0f, this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width - this._ALM.width);
                                    this._AFS.y = Mathf.Clamp(this._AFS.y + Event.current.delta.y * this._AEY().y, 0f, this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.height - this._ALM.height);
                                    Event.current.Use();
                                    this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(this._AFS.y);
                                    this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = this._AFS.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                }
                                bool flag140 = _bg8._BBE && !_bi2.JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM && !flag137;
                                if (flag140)
                                {
                                    bool flag141 = Event.current.type == 7;
                                    if (flag141)
                                    {
                                        float num16 = Mathf.Clamp01((float)(_bi2._ATN - this.NJLKIOECLMPLPCIEOLCBGKJBLDPMHBCHJBJN).TotalSeconds);
                                        this.NJLKIOECLMPLPCIEOLCBGKJBLDPMHBCHJBJN = _bi2._ATN;
                                        bool flag142 = this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE != this._AFS;
                                        if (flag142)
                                        {
                                            this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x = Mathf.SmoothDamp(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, this._AFS.x, ref this.EMPLHHGIPJCGEICPFEHNLAIMLHOHKPNCGCCO.x, 0.05f, float.PositiveInfinity, num16);
                                            this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.y = Mathf.SmoothDamp(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.y, this._AFS.y, ref this.EMPLHHGIPJCGEICPFEHNLAIMLHOHKPNCGCCO.y, 0.05f, float.PositiveInfinity, num16);
                                        }
                                    }
                                }
                                else
                                {
                                    this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE = this._AFS;
                                }
                                Vector2 vector3;
                                for (; ; )
                                {
                                    Vector2 vector2;
                                    vector2..ctor((float)((int)this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x), (float)((int)this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.y));
                                    Rect rect2 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? new Rect(this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.x, this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.y, 1f, num6) : this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB);
                                    rect2..ctor(rect2.x, rect2.y, Mathf.Ceil(rect2.width), Mathf.Ceil(rect2.height));
                                    vector3 = _bi2.BeginScrollView(this._AFO, vector2, rect2);
                                    bool flag143 = this.CanEdit() && (this._AFS != vector3 || flag137);
                                    if (!flag143)
                                    {
                                        goto IL_30F5;
                                    }
                                    bool flag144 = flag137;
                                    if (flag144)
                                    {
                                        flag137 = false;
                                        Vector2 vector4 = vector3 - vector2;
                                        this._AFS += vector4;
                                        this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(vector3.y);
                                        this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = vector3.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                        _bi2.EndScrollView(true);
                                    }
                                    else
                                    {
                                        bool flag145 = !_bi2.JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM && vector2 != vector3;
                                        if (!flag145)
                                        {
                                            break;
                                        }
                                        this._AFS = vector3;
                                        this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE = this.GetLineAt(vector3.y);
                                        this.LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF = vector3.y - this.GetLineOffset(this.AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE);
                                        _bi2.EndScrollView(true);
                                    }
                                }
                                int lineAt = this.GetLineAt(vector3.y);
                                num7 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? lineAt : Math.Max(0, (int)(vector3.y / this._AEY().y) - 1));
                                num8 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? (1 + this.GetLineAt(vector3.y + this._AFO.height)) : ((this._AFO.height > 0f) ? (num7 + 2 + (int)(this._AFO.height / this._AEY().y)) : ((int)((float)Screen.height / EditorGUIUtility.pixelsPerPoint / this._AEY().y))));
                                bool flag146 = num8 > this._ABQ._AQQ.Length;
                                if (flag146)
                                {
                                    num8 = this._ABQ._AQQ.Length;
                                    num7 = Mathf.Max(0, Mathf.Min(num7, num8 - (int)(this._AFO.height / this._AEY().y)));
                                }
                                goto IL_30FF;
                            IL_30F5:
                                this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE = vector3;
                            IL_30FF:
                                bool flag147 = this._ABQ.FLOg.Count == 0;
                                if (flag147)
                                {
                                    _bi2.EndScrollView(true);
                                    _bi2.JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM = false;
                                }
                                else
                                {
                                    bool flag148 = Event.current.rawType == 1 && GUIUtility.hotControl == _bi2.BLPCHGOBMBLGEAPDFHEIFAEBPBCJAFEONIIC;
                                    if (flag148)
                                    {
                                        this.ProcessEditorMouse(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, Event.current);
                                    }
                                    else
                                    {
                                        bool flag149 = this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA != null && this.DAOLEHELIBAIPNAPOFMDOLIAOEHCLFOGLHGI != Vector2.zero;
                                        if (flag149)
                                        {
                                            this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA.mousePosition += this._AFS;
                                            this.DAOLEHELIBAIPNAPOFMDOLIAOEHCLFOGLHGI = Vector2.zero;
                                        }
                                        bool poaahkkefhafhhjdhlcdiokhakghnkokppfg = this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG;
                                        if (poaahkkefhafhhjdhlcdiokhakghnkokppfg)
                                        {
                                            this.POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = false;
                                            this._ATM = _bi2._ATN;
                                            GUIUtility.keyboardControl = _bi2.BLPCHGOBMBLGEAPDFHEIFAEBPBCJAFEONIIC;
                                            this.Repaint();
                                        }
                                        this.IOPEBNDLLLDJELEBEIKHKAGNHKBDPKFIAEEL(GUIUtility.keyboardControl == _bi2.BLPCHGOBMBLGEAPDFHEIFAEBPBCJAFEONIIC);
                                        bool flag150 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() && Event.current.rawType != 1;
                                        if (flag150)
                                        {
                                            EditorWindow focusedWindow = EditorWindow.focusedWindow;
                                            bool flag151 = focusedWindow == null;
                                            if (flag151)
                                            {
                                                this.IOPEBNDLLLDJELEBEIKHKAGNHKBDPKFIAEEL(false);
                                            }
                                            else
                                            {
                                                bool flag152 = focusedWindow != this.EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO;
                                                if (flag152)
                                                {
                                                    this.IOPEBNDLLLDJELEBEIKHKAGNHKBDPKFIAEEL(focusedWindow == this._ABJ());
                                                }
                                            }
                                        }
                                        bool flag153 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
                                        if (flag153)
                                        {
                                            Input.imeCompositionMode = 1;
                                        }
                                        bool flag154 = Event.current.type != 8;
                                        if (flag154)
                                        {
                                            this._ALM.x = this._AFS.x + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                            this._ALM.y = this._AFS.y;
                                            this._ALM.width = this._AFO.width - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 4f - this.MFHBMAGLJHOKEHCENMEKNBKPGBPBEECMDAKC;
                                            this._ALM.height = this._AFO.height - 4f;
                                            bool flag155 = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width - 4f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this.MFHBMAGLJHOKEHCENMEKNBKPGBPBEECMDAKC > this._ALM.width;
                                            bool flag156 = (this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? num6 : this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.height) - 4f > this._ALM.height;
                                            bool flag157 = flag155 && flag156;
                                            if (flag157)
                                            {
                                                this._ALM.width = this._ALM.width - 15f;
                                                this._ALM.height = this._ALM.height - 15f;
                                            }
                                            else
                                            {
                                                bool flag158 = flag155;
                                                if (flag158)
                                                {
                                                    this._ALM.height = this._ALM.height - 15f;
                                                    flag156 = this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.height - 4f > this._ALM.height;
                                                    bool flag159 = flag156;
                                                    if (flag159)
                                                    {
                                                        this._ALM.width = this._ALM.width - 15f;
                                                    }
                                                }
                                                else
                                                {
                                                    bool flag160 = flag156;
                                                    if (flag160)
                                                    {
                                                        this._ALM.width = this._ALM.width - 15f;
                                                        flag155 = this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width - 4f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this.MFHBMAGLJHOKEHCENMEKNBKPGBPBEECMDAKC > this._ALM.width;
                                                        bool flag161 = flag155;
                                                        if (flag161)
                                                        {
                                                            this._ALM.height = this._ALM.height - 15f;
                                                        }
                                                    }
                                                }
                                            }
                                            this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH = this._ALM;
                                            this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.xMin = this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.xMin + -4f;
                                            this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.yMin = this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.yMin + -4f;
                                            this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.yMax = this.LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH.yMax + 4f;
                                            this._ALM.xMin = Mathf.Ceil((this._ALM.x - 1f - this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK) / this._AEY().x) * this._AEY().x + 0f + this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                            this._ALM.width = Mathf.Floor(this._ALM.width / this._AEY().x) * this._AEY().x;
                                            this._ALM.yMin = Mathf.Ceil(this._ALM.y / this._AEY().y) * this._AEY().y;
                                            this._ALM.height = Mathf.Floor(this._ALM.height / this._AEY().y) * this._AEY().y;
                                        }
                                        this.BBNCFBJBOKMILIDIMJKJKEHCDAFMDFNDNGGI = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && Event.current.type == 7 && (this.KCNPCIEKAJFBIOBEGEOCHIAELCCBKBFBCADM.width != this._ALM.width || _bg8._ASA != this.ANAGDFICEFNAOCIGDFJALOOGGMBIDBLNPPON);
                                        bool flag162 = Event.current.type == 7;
                                        if (flag162)
                                        {
                                            Rect rect3 = default(Rect);
                                            bool flag163 = (_bg8._AZY || _bg8._AZX) && !this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL && Event.current.type == 7 && this._ABH._ABI >= num7 && this._ABH._ABI < num8 && !this._ARV();
                                            if (flag163)
                                            {
                                                int num17;
                                                int num18;
                                                this.BufferToViewPosition(this._ABH, out num17, out num18);
                                                float num19 = this._AEY().y * (float)num17 + this.GetLineOffset(this._ABH._ABI);
                                                Rect rect4;
                                                rect4..ctor(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 4f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, num19, this._ALM.width + this._AEY().x + 4f, 1f);
                                                bool flag164 = _bg8._AZX;
                                                if (flag164)
                                                {
                                                    GUI.Label(rect4, GUIContent.none, this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() ? this._ABT.LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG : this._ABT.MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ);
                                                }
                                                rect4.y += this._AEY().y - 1f;
                                                bool flag165 = _bg8._AZX;
                                                if (flag165)
                                                {
                                                    GUI.Label(rect4, GUIContent.none, this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() ? this._ABT.LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG : this._ABT.MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ);
                                                }
                                                rect4.y -= this._AEY().y - 2f;
                                                rect4.height = this._AEY().y - 2f;
                                                Color color2 = GUI.color;
                                                GUI.color = new Color(1f, 1f, 1f, _bg8._BBM);
                                                bool flag166 = _bg8._AZY;
                                                if (flag166)
                                                {
                                                    GUI.Label(rect4, GUIContent.none, this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() ? this._ABT.LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG : this._ABT.MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ);
                                                }
                                                GUI.color = color2;
                                            }
                                            bool flag167 = this._ABQ._ASJ == this.KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH && this.LPDHPJNAHLLADJCFMGCEECABJMPHIPPIFMPC;
                                            if (flag167)
                                            {
                                                bool pnbfhjbpgljpbommohfihhjonmjlbkbgffll = this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL;
                                                this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = true;
                                                int length2 = this.FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD.Length;
                                                rect3.height = this._AEY().y;
                                                int num20 = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.BinarySearch(new GCE._AFA
                                                {
                                                    _ABI = num7,
                                                    _AEU = -1
                                                });
                                                bool flag168 = num20 < 0;
                                                if (flag168)
                                                {
                                                    num20 = ~num20;
                                                }
                                                for (int j = num20; j < this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH.Count; j++)
                                                {
                                                    GCE._AFA _ATD4 = this.DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH[j];
                                                    bool flag169 = _ATD4._ABI >= num7;
                                                    if (flag169)
                                                    {
                                                        bool flag170 = _ATD4._ABI > num8;
                                                        if (flag170)
                                                        {
                                                            break;
                                                        }
                                                        this.DrawSelectionRectCharIndex(_ATD4._ABI, _ATD4._AEU, length2, false, this._ABT.EEHEIDPKDPFECCNEMEAOEDHDMOCMLHIMGBIO);
                                                    }
                                                }
                                                this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = pnbfhjbpgljpbommohfihhjonmjlbkbgffll;
                                            }
                                            bool flag171 = !this._ARV() && this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL;
                                            if (flag171)
                                            {
                                                bool flag172 = this._ATW()._ABI == this._ABH._ABI;
                                                if (flag172)
                                                {
                                                    this.DrawSelectionRectCharIndex(this._ABH._ABI, Math.Min(this._ABH._AEU, this._ATW()._AEU), Math.Abs(this._ABH._AEU - this._ATW()._AEU), false, null);
                                                }
                                                else
                                                {
                                                    bool flag173 = this._ATW() != null && this._ABH < this._ATW();
                                                    GCE._AFA _ATD5 = (flag173 ? this._ABH : this._ATW());
                                                    GCE._AFA _ATD6 = (flag173 ? this._ATW() : this._ABH);
                                                    int num21 = _ATD5._ABI;
                                                    int num22 = _ATD6._ABI;
                                                    this.DrawSelectionRectCharIndex(num21, _ATD5._AEU, this._ABQ.FLOg[num21].Length - _ATD5._AEU, true, null);
                                                    this.DrawSelectionRectCharIndex(num22, 0, _ATD6._AEU, false, null);
                                                    num21++;
                                                    num22--;
                                                    bool flag174 = num21 < num7;
                                                    if (flag174)
                                                    {
                                                        num21 = num7;
                                                    }
                                                    bool flag175 = num22 >= num8;
                                                    if (flag175)
                                                    {
                                                        num22 = num8 - 1;
                                                    }
                                                    for (int k = num21; k <= num22; k++)
                                                    {
                                                        this.DrawSelectionRectCharIndex(k, 0, this._ABQ.FLOg[k].Length, true, null);
                                                    }
                                                }
                                            }
                                            bool flag176;
                                            if (this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC > 0f)
                                            {
                                                DateTime ceioidhacnpfgacjaepbfokgbdkajdnjboho = this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO;
                                                DateTime dateTime = default(DateTime);
                                                flag176 = ceioidhacnpfgacjaepbfokgbdkajdnjboho != dateTime;
                                            }
                                            else
                                            {
                                                flag176 = false;
                                            }
                                            bool flag177 = flag176;
                                            if (flag177)
                                            {
                                                this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 1f - (float)(_bi2._ATN - this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO).TotalSeconds * 0.5f;
                                                bool flag178 = this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC < 0f;
                                                if (flag178)
                                                {
                                                    this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 0f;
                                                    this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO = default(DateTime);
                                                }
                                                int num23;
                                                int num24;
                                                this.BufferToViewPosition(this._ABH, out num23, out num24);
                                                Rect ekiiiobhdbpddbjfcmeghbhlmoegccodhdff = this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF;
                                                ekiiiobhdbpddbjfcmeghbhlmoegccodhdff.y = this._AEY().y * (float)num23 + this.GetLineOffset(this._ABH._ABI);
                                                this.DrawPing(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, ekiiiobhdbpddbjfcmeghbhlmoegccodhdff, true);
                                            }
                                        }
                                        SyntaxToken syntaxToken2 = null;
                                        Rect rect5 = default(Rect);
                                        rect5.height = this._AEY().y;
                                        rect5.y = this.GetLineOffset(num7) - this._AEY().y;
                                        for (int l = num7; l < num8; l++)
                                        {
                                            bool flag179 = !this.IsLineVisible(l);
                                            if (flag179)
                                            {
                                                bool flag180 = num8 < this._ABQ.FLOg.Count;
                                                if (flag180)
                                                {
                                                    num8++;
                                                }
                                            }
                                            else
                                            {
                                                rect5.x = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                                rect5.y += this._AEY().y;
                                                GCE.PHFG _AUB = this._ABQ._AQQ[l];
                                                int num25 = 0;
                                                List<SyntaxToken> _ABS2 = _AUB.EOIA;
                                                bool flag181 = _ABS2 == null;
                                                if (flag181)
                                                {
                                                    bool flag182 = syntaxToken2 == null;
                                                    if (flag182)
                                                    {
                                                        syntaxToken2 = new SyntaxToken(SyntaxToken.Kind.PreprocessorArguments, this._ABQ.FLOg[l]);
                                                    }
                                                    else
                                                    {
                                                        syntaxToken2.text = this._ABQ.FLOg[l];
                                                    }
                                                }
                                                List<int> softLineBreaks = this.GetSoftLineBreaks(l);
                                                int count = softLineBreaks.Count;
                                                int num26 = 0;
                                                int num27 = ((_ABS2 == null) ? 1 : _ABS2.Count);
                                                for (int m = 0; m < num27; m++)
                                                {
                                                    SyntaxToken syntaxToken3 = ((_ABS2 == null) ? syntaxToken2 : _ABS2[m]);
                                                    bool flag183 = syntaxToken3 == null;
                                                    if (!flag183)
                                                    {
                                                        bool flag184 = syntaxToken3.tokenKind == SyntaxToken.Kind.Missing;
                                                        if (flag184)
                                                        {
                                                            bool flag185 = Event.current.type == 7;
                                                            if (flag185)
                                                            {
                                                                Rect rect6;
                                                                rect6..ctor(rect5.xMax, rect5.yMin, this._AEY().x * 2f, this._AEY().y);
                                                                _bi2.DrawWavyUnderline(rect6, new Color(1f, 0f, 0f, 0.8f));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            int n = 0;
                                                            int length3 = syntaxToken3.text.Length;
                                                            while (n < length3)
                                                            {
                                                                int num28 = ((num26 > 0) ? softLineBreaks[num26 - 1] : 0);
                                                                int num29 = ((num26 < count) ? (softLineBreaks[num26] - num25) : int.MaxValue);
                                                                int num30 = Math.Min(length3 - n, num29);
                                                                bool flag186 = num30 > 0;
                                                                if (flag186)
                                                                {
                                                                    string text10 = syntaxToken3.text.Substring(n, num30);
                                                                    num25 += num30;
                                                                    rect5.width = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK + this.GetCharXOffset(num25, l, num28) - rect5.x;
                                                                    syntaxToken3.style = this.GetTokenStyle(syntaxToken3);
                                                                    bool flag187 = syntaxToken3.style == this._ABT.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK || syntaxToken3.style == this._ABT.LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE;
                                                                    if (flag187)
                                                                    {
                                                                        bool flag188 = GUI.Button(rect5, text10, syntaxToken3.style);
                                                                        if (flag188)
                                                                        {
                                                                            bool flag189 = syntaxToken3.style == this._ABT.MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK;
                                                                            if (flag189)
                                                                            {
                                                                                Application.OpenURL(syntaxToken3.text);
                                                                            }
                                                                            else
                                                                            {
                                                                                Application.OpenURL("mailto:" + syntaxToken3.text);
                                                                            }
                                                                        }
                                                                        bool flag190 = Event.current.type == 7;
                                                                        if (flag190)
                                                                        {
                                                                            EditorGUIUtility.AddCursorRect(rect5, 4);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag191 = !this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL && this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC == 0f && _bg8._BAG;
                                                                        if (flag191)
                                                                        {
                                                                            bool flag192 = this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI != null;
                                                                            if (flag192)
                                                                            {
                                                                                bool flag193 = syntaxToken3.OOME != null && syntaxToken3.OOME._AAB() != null && syntaxToken3.OOME._AAB().GetGenericSymbol() == this.EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI;
                                                                                if (flag193)
                                                                                {
                                                                                    GUIStyle referenceHighlightStyle = this.GetReferenceHighlightStyle(syntaxToken3);
                                                                                    GUI.Label(rect5, GUIContent.none, referenceHighlightStyle);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                bool flag194 = this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH != null;
                                                                                if (flag194)
                                                                                {
                                                                                    bool flag195 = syntaxToken3.tokenKind == SyntaxToken.Kind.PreprocessorSymbol && syntaxToken3.text == this.ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH;
                                                                                    if (flag195)
                                                                                    {
                                                                                        GUIStyle referenceHighlightStyle2 = this.GetReferenceHighlightStyle(syntaxToken3);
                                                                                        GUI.Label(rect5, GUIContent.none, referenceHighlightStyle2);
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        bool flag196 = Event.current.type == 7;
                                                                        if (flag196)
                                                                        {
                                                                            _bb4.DHBA _AMI = syntaxToken3.OOME;
                                                                            bool flag197 = _AMI != null && syntaxToken3.tokenKind > SyntaxToken.Kind.Missing;
                                                                            if (flag197)
                                                                            {
                                                                            }
                                                                            string text11 = text10;
                                                                            while (text11 != "")
                                                                            {
                                                                                int num31 = text11.IndexOf('\t');
                                                                                bool flag198 = num31 < 0;
                                                                                if (flag198)
                                                                                {
                                                                                    syntaxToken3.style.Draw(rect5, text11, false, false, false, false);
                                                                                    break;
                                                                                }
                                                                                bool flag199 = num31 > 0;
                                                                                if (flag199)
                                                                                {
                                                                                    string text12 = text11.Substring(0, num31);
                                                                                    syntaxToken3.style.Draw(rect5, text12, false, false, false, false);
                                                                                }
                                                                                do
                                                                                {
                                                                                    num31++;
                                                                                }
                                                                                while (num31 < text11.Length && text11[num31] == '\t');
                                                                                bool flag200 = num31 < text11.Length;
                                                                                if (!flag200)
                                                                                {
                                                                                    break;
                                                                                }
                                                                                text11 = text11.Substring(num31);
                                                                                rect5.xMin = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK + this.GetCharXOffset(num25 - text11.Length, l, num28);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                rect5.xMin = rect5.xMax;
                                                                n += num30;
                                                                bool flag201 = n < length3;
                                                                if (flag201)
                                                                {
                                                                    rect5.x = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK;
                                                                    rect5.width = 0f;
                                                                    rect5.y += this._AEY().y;
                                                                    num26++;
                                                                }
                                                            }
                                                            rect5.xMin = rect5.xMax;
                                                        }
                                                    }
                                                }
                                                this.HNBKJDKPBPNIOBIGJKDEDOFLENDLKDCOCMAH = Mathf.Ceil(Mathf.Max(this.HNBKJDKPBPNIOBIGJKDEDOFLENDLKDCOCMAH, rect5.xMax));
                                            }
                                        }
                                        bool flag202 = Event.current.type == 7;
                                        if (flag202)
                                        {
                                            bool flag203 = !this._ARV() && !this.BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL && this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC == 0f && this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH < this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL && this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.line >= 0 && this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.line < this._ABQ._AQQ.Length && this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.line >= 0 && this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.line < this._ABQ._AQQ.Length && this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.index < this._ABQ._AQQ[this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.line].EOIA.Count && this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.index < this._ABQ._AQQ[this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.line].EOIA.Count && this.IsLineVisible(this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.line);
                                            if (flag203)
                                            {
                                                TextSpan tokenSpan2 = this._ABQ.GetTokenSpan(this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.line, this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.index);
                                                TextSpan tokenSpan3 = this._ABQ.GetTokenSpan(this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.line, this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.index);
                                                Rect textRect = this.GetTextRect(tokenSpan2);
                                                Rect textRect2 = this.GetTextRect(tokenSpan3);
                                                char c3 = this._ABQ.FLOg[tokenSpan2.line][tokenSpan2.index];
                                                char c2 = this._ABQ.FLOg[tokenSpan3.line][tokenSpan3.index];
                                                int num32 = (int)(c2 - c3);
                                                GUIStyle guistyle = ((num32 == 1 || num32 == 2) ? this._ABT.EDPELGLOHBEDHHGMAFPGLEMGKFNEHIMBHLBE : this._ABT.CDKDJIHGIELEEDGFLEBKFMAICBICIONFMOMH);
                                                Rect rect7;
                                                rect7..ctor(textRect.x - 1f, textRect.yMax, textRect.width + 2f, 1f);
                                                Rect rect8;
                                                rect8..ctor(textRect2.x - 1f, textRect2.yMax, textRect2.width + 2f, 1f);
                                                Color color3 = GUI.color;
                                                GUI.color = this._ABT._ABV.normal.textColor;
                                                GUI.DrawTexture(rect7, EditorGUIUtility.whiteTexture);
                                                GUI.DrawTexture(rect8, EditorGUIUtility.whiteTexture);
                                                GUI.color = color3;
                                                SyntaxToken syntaxToken4 = this._ABQ._AQQ[this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.line].EOIA[this.DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH.index];
                                                SyntaxToken syntaxToken5 = this._ABQ._AQQ[this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.line].EOIA[this.AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL.index];
                                                GUI.Label(textRect, GUIContent.none, guistyle);
                                                GUI.Label(textRect2, GUIContent.none, guistyle);
                                                GUI.Label(textRect, new GUIContent(syntaxToken4.text), this._ABT._ABV);
                                                GUI.Label(textRect2, new GUIContent(syntaxToken5.text), this._ABT._ABV);
                                                bool flag204 = syntaxToken4.OOME != null && syntaxToken4.OOME._AJB != null;
                                                if (flag204)
                                                {
                                                    _bi2.DrawWavyUnderline(textRect, new Color(1f, 0f, 0f, 0.8f));
                                                }
                                                bool flag205 = syntaxToken5.OOME != null && syntaxToken5.OOME._AJB != null;
                                                if (flag205)
                                                {
                                                    _bi2.DrawWavyUnderline(textRect2, new Color(1f, 0f, 0f, 0.8f));
                                                }
                                            }
                                        }
                                        bool flag206 = Event.current.type == 10 || Event.current.type == 9;
                                        bool flag207 = flag206 || Event.current.isMouse || (Event.current.type == 7 && this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI);
                                        if (flag207)
                                        {
                                            this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI = this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI && !Event.current.isMouse && !flag206;
                                            Event @event = (this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI ? new Event(this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA) : Event.current);
                                            bool flag208 = !this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI;
                                            if (flag208)
                                            {
                                                this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA = new Event(Event.current);
                                            }
                                            this.FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI = false;
                                            this.ProcessEditorMouse(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, @event);
                                            bool pnbfhjbpgljpbommohfihhjonmjlbkbgffll2 = this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL;
                                            if (pnbfhjbpgljpbommohfihhjonmjlbkbgffll2)
                                            {
                                                this.MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA.mousePosition.x < this._ALM.x;
                                                this.PEGFBNGNMIIMHJHBGGJMIPPGCENEDFKBJIPF = !this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO && this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA.mousePosition.x >= this._ALM.xMax;
                                                this.DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC = this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA.mousePosition.y < this._ALM.y;
                                                this.ALLEDCEJLCOEBNDPEPFIJNFCIFIDIDNEHKFJ = this.ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA.mousePosition.y >= this._ALM.yMax;
                                            }
                                            bool flag209 = Event.current.type == 12;
                                            if (flag209)
                                            {
                                                goto IL_58A9;
                                            }
                                        }
                                        bool flag210 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() && Event.current.type == 7 && this.CanEdit();
                                        if (flag210)
                                        {
                                            GCE._AFA _ATD7 = ((this.PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL && this.CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI) ? this.GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND : this._ABH);
                                            float num33 = (float)(_bi2._ATN - this._ATM).TotalSeconds % 1f;
                                            this.PJJNCLILMNNHAGCFMAEOAHDAGGAKDOIMCAEI = num33 < 0.5f;
                                            if (!this.PJJNCLILMNNHAGCFMAEOAHDAGGAKDOIMCAEI)
                                            {
                                                if (this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC <= 0f)
                                                {
                                                    goto IL_4DEC;
                                                }
                                                DateTime ceioidhacnpfgacjaepbfokgbdkajdnjboho2 = this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO;
                                                DateTime dateTime = default(DateTime);
                                                if (!(ceioidhacnpfgacjaepbfokgbdkajdnjboho2 != dateTime))
                                                {
                                                    goto IL_4DEC;
                                                }
                                            }
                                            bool flag211;
                                            if (_ATD7._ABI >= num7)
                                            {
                                                flag211 = _ATD7._ABI < num8;
                                                goto IL_4DED;
                                            }
                                        IL_4DEC:
                                            flag211 = false;
                                        IL_4DED:
                                            bool flag212 = flag211;
                                            if (flag212)
                                            {
                                                Rect caretRect2 = this.GetCaretRect(_ATD7);
                                                GUI.Label(caretRect2, GUIContent.none, this.PJJNCLILMNNHAGCFMAEOAHDAGGAKDOIMCAEI ? this._ABT.OAHNJENALMPCNGMEAFGPAOPDCFGGJFIMDLCK : this._ABT.MNAINPPJCJGPLHBFJICPBAPKHGGPKHFKGHKI);
                                            }
                                        }
                                        bool flag213 = Event.current.type == 7;
                                        if (flag213)
                                        {
                                            bool flag214 = flag20 || this.HFBBKNBEOLAICCGCIFGLPKHFCNHPANGIIGDM();
                                            if (flag214)
                                            {
                                                rect5.Set(-4f, -4f, this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 2f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, num6);
                                                EditorGUIUtility.AddCursorRect(rect5, 0);
                                                rect5.Set(-4f, -4f, this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 1f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, num6);
                                                bool flag215 = rect5.height < this._AFO.height;
                                                if (flag215)
                                                {
                                                    rect5.height = this._AFO.height;
                                                }
                                                this._ABT.FKPDLHMDAGCDBKHOJAABIDBDBPCOGPOPIOJC.Draw(rect5, false, false, false, false);
                                                rect5.xMin = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 5f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x;
                                                rect5.width = 1f;
                                                this._ABT.IICGPMAMBHPFKAIGDAKKDFCDPAKDCNNGOAOF.Draw(rect5, false, false, false, false);
                                            }
                                            bool flag216 = flag20;
                                            if (flag216)
                                            {
                                                string[] array2;
                                                if ((array2 = _bi2.HJEDHEAJDDEAIGLAAMLLNOFBJHJKKLLPCHJN) == null)
                                                {
                                                    array2 = (_bi2.HJEDHEAJDDEAIGLAAMLLNOFBJHJKKLLPCHJN = new string[this._ABQ.FLOg.Count]);
                                                }
                                                string[] array3 = array2;
                                                bool flag217 = array3.Length < this._ABQ.FLOg.Count;
                                                if (flag217)
                                                {
                                                    Array.Resize<string>(ref array3, this._ABQ.FLOg.Count);
                                                }
                                                for (int num34 = num7; num34 < num8; num34++)
                                                {
                                                    bool flag218 = !this.IsLineVisible(num34);
                                                    if (!flag218)
                                                    {
                                                        GUIContent fadgcfaiajefhcblkdgghbgjjnbkjbmiooem = _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM;
                                                        string text13;
                                                        if ((text13 = array3[num34]) == null)
                                                        {
                                                            text13 = (array3[num34] = (num34 + 1 + this.BEOOILOKJPMGIAIFECEOEGHJCFAFCGJFJICN).ToString());
                                                        }
                                                        fadgcfaiajefhcblkdgghbgjjnbkjbmiooem.text = text13;
                                                        rect5.Set(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, this.GetLineOffset(num34), this.BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG, this._AEY().y);
                                                        this._ABT.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.Draw(rect5, _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, this._ABH._ABI == num34, false, false, false);
                                                    }
                                                }
                                                _bi2.HJEDHEAJDDEAIGLAAMLLNOFBJHJKKLLPCHJN = array3;
                                            }
                                            bool flag219 = this.HFBBKNBEOLAICCGCIFGLPKHFCNHPANGIIGDM();
                                            if (flag219)
                                            {
                                                rect5.xMin = this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - 13f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x;
                                                bool flhmmgogabacngebpcfefgpmfnakdpiglabb2 = this.FLHMMGOGABACNGEBPCFEFGPMFNAKDPIGLABB;
                                                if (flhmmgogabacngebpcfefgpmfnakdpiglabb2)
                                                {
                                                    rect5.xMin -= this._AEY().x;
                                                }
                                                rect5.width = 5f;
                                                int num35 = num7;
                                                while (num35 < num8)
                                                {
                                                    int locagnfbkgfdobdclfnhlbmkibajaojgmnnm = this._ABQ._AQQ[num35]._ASP;
                                                    int bilgabgdbajjilakifbfecdfkloakfiofnle = this._ABQ._AQQ[num35]._ASQ;
                                                    bool flag220 = locagnfbkgfdobdclfnhlbmkibajaojgmnnm > 0 || bilgabgdbajjilakifbfecdfkloakfiofnle > 0;
                                                    if (flag220)
                                                    {
                                                        rect5.yMin = this.GetLineOffset(num35);
                                                        rect5.yMax = this.GetLineOffset(num35 + 1);
                                                        bool flag221 = rect5.height == 0f;
                                                        if (!flag221)
                                                        {
                                                            bool flag222 = bilgabgdbajjilakifbfecdfkloakfiofnle == locagnfbkgfdobdclfnhlbmkibajaojgmnnm;
                                                            if (flag222)
                                                            {
                                                                GUI.Label(rect5, GUIContent.none, this._ABT.MNIDILAEJNANLBJOKMBBFAPKMBLJPHDOOKHC);
                                                            }
                                                            else
                                                            {
                                                                bool flag223 = bilgabgdbajjilakifbfecdfkloakfiofnle > locagnfbkgfdobdclfnhlbmkibajaojgmnnm;
                                                                if (flag223)
                                                                {
                                                                    GUI.Label(rect5, GUIContent.none, this._ABT.FIJCFMEBKKCPHHDEICAFJGNHALMFHHDFMJCF);
                                                                }
                                                                else
                                                                {
                                                                    GUI.Label(rect5, GUIContent.none, this._ABT.EFFPDLCPLHCEJBKAEOGCFKCJMEJJCGNOEAJC);
                                                                }
                                                            }
                                                        }
                                                    }
                                                IL_52B7:
                                                    num35++;
                                                    continue;
                                                    goto IL_52B7;
                                                }
                                            }
                                            bool flhmmgogabacngebpcfefgpmfnakdpiglabb3 = this.FLHMMGOGABACNGEBPCFEFGPMFNAKDPIGLABB;
                                            if (flhmmgogabacngebpcfefgpmfnakdpiglabb3)
                                            {
                                                for (int num36 = num7; num36 < num8; num36++)
                                                {
                                                    bool flag224 = !this.IsLineVisible(num36);
                                                    if (!flag224)
                                                    {
                                                        GCE._ABW _AUX = this._ABQ._AQQ[num36]._ABZ;
                                                        bool flag225 = _AUX == null || _AUX._ABI == null;
                                                        if (!flag225)
                                                        {
                                                            bool flag226 = _AUX._AT != (GCE._ABW._ABX)1 && _AUX._AT != (GCE._ABW._ABX)6;
                                                            if (!flag226)
                                                            {
                                                                int _AQZ = _AUX._ABI.JIKB;
                                                                bool flag227 = num36 != _AQZ;
                                                                if (!flag227)
                                                                {
                                                                    _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = (this.FDJNLNLEAGGCEHMOOPKBCCCLCKEMHMBENEAF.Contains(this._ABQ._AQQ[num36].GetRegionName()) ? "►" : "▼");
                                                                    rect5.Set(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this._AEY().x - 6f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, this.GetLineOffset(num36), this._AEY().x, this._AEY().y);
                                                                    this._ABT.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.Draw(rect5, _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, this._ABH._ABI == num36, false, false, false);
                                                                    bool flag228 = _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text.Equals("▼");
                                                                    if (flag228)
                                                                    {
                                                                        EditorGUIUtility.AddCursorRect(rect5, 12);
                                                                    }
                                                                    else
                                                                    {
                                                                        EditorGUIUtility.AddCursorRect(rect5, 11);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            bool lfgcffnkdedpogflakndcphcnedjkmpjmdfg = this.LFGCFFNKDEDPOGFLAKNDCPHCNEDJKMPJMDFG;
                                            if (lfgcffnkdedpogflakndcphcnedjkmpjmdfg)
                                            {
                                                foreach (int num37 in this.CFGMIHPKGHMFFINDHELODHEJGENHNKBBHPGK)
                                                {
                                                    rect5.Set(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK - this._AEY().x - 8f + this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, this.GetLineOffset(num37), this._AEY().x, this._AEY().y);
                                                    _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = "●";
                                                    this._ABT.FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM.Draw(rect5, _bi2.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, true, false, false, false);
                                                    rect5.Set(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, this.GetLineOffset(num37), this.BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG + this._AEY().x, this._AEY().y);
                                                    EditorGUIUtility.AddCursorRect(rect5, 12);
                                                }
                                                for (int num38 = num7; num38 < num8; num38++)
                                                {
                                                    rect5.Set(this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE.x, this.GetLineOffset(num38), this.BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG + this._AEY().x, this._AEY().y);
                                                    EditorGUIUtility.AddCursorRect(rect5, 11);
                                                    foreach (int num39 in this.CFGMIHPKGHMFFINDHELODHEJGENHNKBBHPGK)
                                                    {
                                                        bool flag229 = num38 == num39;
                                                        if (flag229)
                                                        {
                                                            EditorGUIUtility.AddCursorRect(rect5, 12);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        bool bbncfbjbokmilidimjkjkehcdafmdfndnggi = this.BBNCFBJBOKMILIDIMJKJKEHCDAFMDFNDNGGI;
                                        if (bbncfbjbokmilidimjkjkehcdafmdfndnggi)
                                        {
                                            this.BBNCFBJBOKMILIDIMJKJKEHCDAFMDFNDNGGI = false;
                                            this.ANAGDFICEFNAOCIGDFJALOOGGMBIDBLNPPON = _bg8._ASA;
                                            this.InvalidateSoftLineBreaks();
                                            bool fcddeenlbdfbmkeflkikpckpaagbjlephchc = this.FCDDEENLBDFBMKEFLKIKPCKPAAGBJLEPHCHC;
                                            if (fcddeenlbdfbmkeflkikpckpaagbjlephchc)
                                            {
                                                this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE = this._AFS;
                                                this.EMPLHHGIPJCGEICPFEHNLAIMLHOHKPNCGCCO = Vector2.zero;
                                                this.NJLKIOECLMPLPCIEOLCBGKJBLDPMHBCHJBJN = default(DateTime);
                                            }
                                            _bi2.EndScrollView(true);
                                            this.Repaint();
                                            return;
                                        }
                                        bool flag230 = Event.current.type == 7;
                                        if (flag230)
                                        {
                                            EditorGUIUtility.AddCursorRect(this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO ? new Rect(this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.x, this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.y, this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB.width, num6) : this.JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB, 1);
                                        }
                                        bool flag231;
                                        if (Event.current.type == 7 && this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC > 0f)
                                        {
                                            DateTime ceioidhacnpfgacjaepbfokgbdkajdnjboho3 = this.CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO;
                                            DateTime dateTime = default(DateTime);
                                            flag231 = ceioidhacnpfgacjaepbfokgbdkajdnjboho3 != dateTime;
                                        }
                                        else
                                        {
                                            flag231 = false;
                                        }
                                        bool flag232 = flag231;
                                        if (flag232)
                                        {
                                            int num40;
                                            int num41;
                                            this.BufferToViewPosition(this._ABH, out num40, out num41);
                                            Rect ekiiiobhdbpddbjfcmeghbhlmoegccodhdff2 = this.EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF;
                                            ekiiiobhdbpddbjfcmeghbhlmoegccodhdff2.y = this._AEY().y * (float)num40 + this.GetLineOffset(this._ABH._ABI);
                                            this.DrawPing(this.JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK, ekiiiobhdbpddbjfcmeghbhlmoegccodhdff2, false);
                                            this.Repaint();
                                        }
                                    }
                                IL_58A9:
                                    bool flag233 = this.OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE != this._AFS;
                                    if (flag233)
                                    {
                                        this.Repaint();
                                    }
                                    else
                                    {
                                        bool flag234 = Event.current.type == 7;
                                        if (flag234)
                                        {
                                            _bi2.JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM = false;
                                        }
                                    }
                                    bool gfkaldcdcjkdllfgkmbfpabmpcnbgcfejein = this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN;
                                    if (gfkaldcdcjkdllfgkmbfpabmpcnbgcfejein)
                                    {
                                        this.UpdateArgumentsHint(true);
                                    }
                                    else
                                    {
                                        bool flag235 = this.KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB != null && this._ATM == _bi2._ATN;
                                        if (flag235)
                                        {
                                            this.UpdateArgumentsHint(true);
                                        }
                                    }
                                    this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = false;
                                    _bi2.EndScrollView(true);
                                    bool flag236 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() && Event.current.type == 7 && this.CanEdit();
                                    if (flag236)
                                    {
                                        Rect caretRect3 = this.GetCaretRect(this._ABH);
                                        Vector2 vector5 = new Vector2(caretRect3.x, caretRect3.y + this._AEY().y + 7f) - this._AFS + this._AFO.min;
                                        Input.compositionCursorPos = EditorGUIUtility.pixelsPerPoint * vector5;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0600032D RID: 813 RVA: 0x0003FDB0 File Offset: 0x0003DFB0
        public void OnWindowGUI(EditorWindow window, RectOffset margins)
        {
            bool flag = window != this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH;
            if (flag)
            {
                this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF = window;
            }
            bool flag2 = EditorWindow.focusedWindow == window;
            if (flag2)
            {
                GCE._ALU = this;
            }
            bool flag3 = Event.current.type != 8;
            if (flag3)
            {
                bool flag4 = this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF;
                if (flag4)
                {
                    this._AFO = new Rect(0f, 0f, this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF.position.width, this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF.position.height);
                }
                bool flag5 = !(window is _bb6);
                if (flag5)
                {
                    this._AFO.xMin = 0f;
                }
                this._AFO = margins.Remove(this._AFO);
            }
            else
            {
                bool flag6 = !this.OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF;
                if (flag6)
                {
                    GUILayoutUtility.GetRect(1f, (float)Screen.width, 112f, (float)Screen.height);
                }
            }
            bool enabled = GUI.enabled;
            GUI.enabled = this.CanEdit();
            bool flag7 = this._ABQ != null;
            if (flag7)
            {
                Rect rect;
                rect..ctor(this._AFO.xMax - 21f, this._AFO.yMin - 17f, 21f, 16f);
            }
            Color color = GUI.color;
            bool flag8 = !GUI.enabled && Event.current.type == 7;
            if (flag8)
            {
                GUI.color = new Color(0.85f, 0.85f, 0.85f);
                bool flag9 = this._ABQ != null;
                if (flag9)
                {
                    this._ABQ.LoadFaster();
                }
            }
            try
            {
                bool flag10 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK() && GUI.enabled;
                if (flag10)
                {
                    GCE._ALU = this;
                    this._ABQ.BeginEdit("change");
                    try
                    {
                        this.DoGUIWithAutocomplete(enabled);
                    }
                    finally
                    {
                        this._ABQ.EndEdit();
                    }
                }
                else
                {
                    this.DoGUIWithAutocomplete(enabled);
                }
            }
            finally
            {
                GUI.color = color;
                GUI.enabled = enabled;
            }
        }

        // Token: 0x0600032E RID: 814 RVA: 0x0003FFFC File Offset: 0x0003E1FC
        public void OnInspectorGUI(bool isFileWindow, RectOffset margins, EditorWindow currentInspector)
        {
            this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH = currentInspector;
            this._AFO = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, currentInspector.position.height - 290f);
            this._AFO.xMin = 0f;
            this._AFO.xMax = this._AFO.xMax + 4f;
            bool enabled = GUI.enabled;
            Color color = GUI.color;
            bool flag = !GUI.enabled && Event.current.type == 7;
            if (flag)
            {
                GUI.color = new Color(0.85f, 0.85f, 0.85f);
                bool flag2 = this._ABQ != null;
                if (flag2)
                {
                    this._ABQ.LoadFaster();
                }
            }
            try
            {
                bool flag3 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
                if (flag3)
                {
                    GCE._ALU = this;
                    this._ABQ.BeginEdit("change");
                    try
                    {
                        this.DoGUIWithAutocomplete(enabled);
                    }
                    finally
                    {
                        this._ABQ.EndEdit();
                    }
                }
                else
                {
                    this.DoGUIWithAutocomplete(enabled);
                }
            }
            finally
            {
                GUI.color = color;
                GUI.enabled = enabled;
            }
        }

        // Token: 0x0600032F RID: 815 RVA: 0x00040148 File Offset: 0x0003E348
        public void OnInspectorGUI(float offset, EditorWindow curInspector, bool hasAssemblyDefinitionFilePath = true)
        {
            this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH = curInspector;
            bool flag = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH == null;
            if (!flag)
            {
                bool flag2 = this.CAKHIDEDHOGABNHPLIHFBBDGGEFFNPBAMFJA != this.GetHeightInInspector();
                if (flag2)
                {
                    this.CAKHIDEDHOGABNHPLIHFBBDGGEFFNPBAMFJA = this.GetHeightInInspector();
                }
                else
                {
                    bool flag3 = !_bi2.NALGACOOFEHEHONBNAEIKOEKDJGIODABHAAB || (!this.DMNDDOLDBANIGJLBJIDFEAHIIPDHJAFAALJJ && Event.current.type == 8);
                    if (flag3)
                    {
                        this.DMNDDOLDBANIGJLBJIDFEAHIIPDHJAFAALJJ = true;
                        _bi2.NALGACOOFEHEHONBNAEIKOEKDJGIODABHAAB = true;
                        this.Repaint();
                    }
                    else
                    {
                        bool flag4 = Event.current.type == 8;
                        if (flag4)
                        {
                            bool flag5 = !_bi2.EditorVersionValid(20210);
                            if (flag5)
                            {
                                bool flag6 = !_bi2.EditorVersionValid(20200);
                                if (flag6)
                                {
                                    if (hasAssemblyDefinitionFilePath)
                                    {
                                        this._AFO = (this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, this.GetHeightInInspector() - (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? 0f : 72f)));
                                    }
                                    else
                                    {
                                        this._AFO = (this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, this.GetHeightInInspector() - (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? 0f : 52f)));
                                    }
                                }
                                else if (hasAssemblyDefinitionFilePath)
                                {
                                    this._AFO = (this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, this.GetHeightInInspector() - (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? 11f : 74f)));
                                }
                                else
                                {
                                    this._AFO = (this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, this.GetHeightInInspector() - (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? 11f : 54f)));
                                }
                            }
                            else if (hasAssemblyDefinitionFilePath)
                            {
                                this._AFO = (this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, this.GetHeightInInspector() - (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? 11f : 74f)));
                            }
                            else
                            {
                                this._AFO = (this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ = GUILayoutUtility.GetRect(0f, (float)Screen.width, 0f, this.GetHeightInInspector() - (this.EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL ? 11f : 54f)));
                            }
                        }
                        else
                        {
                            this._AFO = this.KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ;
                        }
                        this._AFO.xMin = 0f;
                        this._AFO.yMin = this._AFO.yMin + offset;
                        this._AFO.yMax = this.GetHeightInInspector();
                        this._AFO.xMax = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.position.size.x;
                        Color color;
                        color..ctor(0f, 0f, 0f, 0.25f);
                        EditorGUI.DrawRect(new Rect(0f, this._AFO.yMin - 1f, this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.position.size.x, 1f), color);
                        bool enabled = GUI.enabled;
                        Color color2 = GUI.color;
                        try
                        {
                            bool flag7 = this.GJDLGEEKCBIHCFECOIOFLIFNOCPOAPGNHJMK();
                            if (flag7)
                            {
                                GCE._ALU = this;
                                this._ABQ.BeginEdit("change");
                                try
                                {
                                    this.DoGUIWithAutocomplete(enabled);
                                }
                                finally
                                {
                                    this._ABQ.EndEdit();
                                }
                            }
                            else
                            {
                                this.DoGUIWithAutocomplete(enabled);
                            }
                        }
                        finally
                        {
                            GUI.color = color2;
                            GUI.enabled = enabled;
                        }
                    }
                }
            }
        }

        // Token: 0x06000330 RID: 816 RVA: 0x00040524 File Offset: 0x0003E724
        private static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect)
        {
            _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD = GUI.skin.horizontalScrollbar;
            _bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML = GUI.skin.verticalScrollbar;
            bool flag = Event.current.type == 9 && position.Contains(Event.current.mousePosition);
            if (flag)
            {
                bool flag2 = Mathf.Abs(Event.current.mousePosition.y - position.y) < 8f;
                if (flag2)
                {
                    scrollPosition.y -= 16f;
                }
                else
                {
                    bool flag3 = Mathf.Abs(Event.current.mousePosition.y - position.yMax) < 8f;
                    if (flag3)
                    {
                        scrollPosition.y += 16f;
                    }
                }
            }
            int controlID = GUIUtility.GetControlID(_bi2.COAPOMHMLBIKCFLNDDEIJBBPBHFBFFEKOHLH, 2);
            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB = (_bi2.ICMBIOEGBPCFGEOEAPHLDMPDMCPNIACDAEBC)GUIUtility.GetStateObject(typeof(_bi2.ICMBIOEGBPCFGEOEAPHLDMPDMCPNIACDAEBC), controlID);
            bool bndnmnlngecciikkaglniphbpmbggljknkje = _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.BNDNMNLNGECCIIKKAGLNIPHBPMBGGLJKNKJE;
            if (bndnmnlngecciikkaglniphbpmbggljknkje)
            {
                scrollPosition = _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB._AFS;
                _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.BNDNMNLNGECCIIKKAGLNIPHBPMBGGLJKNKJE = false;
            }
            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.ELLBKFOCFILNGHCCPNIIOHJBJLLFNDLPJFEM = position;
            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB._AFS = scrollPosition;
            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP = (_bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.CJOOAMFFPFAHKPGODOFCHGHMJOOPHFMJIPEF = viewRect);
            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.width = position.width;
            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height = position.height;
            Rect rect = position;
            EventType type = Event.current.type;
            bool flag4 = type != 8;
            if (flag4)
            {
                bool flag5 = type != 12;
                if (flag5)
                {
                    bool flag6 = false;
                    bool flag7 = false;
                    bool flag8 = viewRect.width > rect.width;
                    if (flag8)
                    {
                        _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height = position.height - _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.fixedHeight + (float)_bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.margin.top;
                        rect.height -= _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.fixedHeight + (float)_bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.margin.top;
                        flag7 = true;
                    }
                    bool flag9 = viewRect.height > rect.height;
                    if (flag9)
                    {
                        _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.width = position.width - _bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML.fixedWidth + (float)_bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML.margin.left;
                        rect.width -= _bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML.fixedWidth + (float)_bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML.margin.left;
                        flag6 = true;
                        bool flag10 = !flag7 && viewRect.width > rect.width;
                        if (flag10)
                        {
                            _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height = position.height - _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.fixedHeight + (float)_bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.margin.top;
                            rect.height -= _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.fixedHeight + (float)_bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.margin.top;
                            flag7 = true;
                        }
                    }
                    bool flag11 = flag7 && _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD != GUIStyle.none;
                    if (flag11)
                    {
                        Rect rect2;
                        rect2..ctor(position.x, position.yMax - _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.fixedHeight, rect.width, _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD.fixedHeight);
                        float num = Mathf.Min(rect.width, viewRect.width);
                        float num2 = Mathf.Clamp(scrollPosition.x, 0f, viewRect.width - num);
                        scrollPosition.x = GUI.HorizontalScrollbar(rect2, num2, num, 0f, viewRect.width);
                    }
                    else
                    {
                        GUIUtility.GetControlID(_bi2.DJPMGBHJLNGIAAEIKDPJIEPEELOPHLFAOHIK, 2);
                        GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                        GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                        bool flag12 = _bi2.JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD != GUIStyle.none;
                        if (flag12)
                        {
                            scrollPosition.x = 0f;
                        }
                        else
                        {
                            scrollPosition.x = Mathf.Clamp(scrollPosition.x, 0f, Mathf.Max(viewRect.width - position.width, 0f));
                        }
                    }
                    bool flag13 = flag6 && _bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML != GUIStyle.none;
                    if (flag13)
                    {
                        bool flag14 = scrollPosition.y < 0f;
                        if (flag14)
                        {
                            scrollPosition.y = 0f;
                        }
                        scrollPosition.y = GUI.VerticalScrollbar(new Rect(rect.xMax + (float)_bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML.margin.left, rect.y, _bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML.fixedWidth, rect.height), scrollPosition.y, Mathf.Min(rect.height, viewRect.height), 0f, viewRect.height);
                    }
                    else
                    {
                        GUIUtility.GetControlID(_bi2.DJPMGBHJLNGIAAEIKDPJIEPEELOPHLFAOHIK, 2);
                        GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                        GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                        bool flag15 = _bi2.LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML != GUIStyle.none;
                        if (flag15)
                        {
                            scrollPosition.y = 0f;
                        }
                        else
                        {
                            scrollPosition.y = Mathf.Clamp(scrollPosition.y, 0f, Mathf.Max(viewRect.height - position.height, 0f));
                        }
                    }
                }
            }
            else
            {
                GUIUtility.GetControlID(_bi2.DJPMGBHJLNGIAAEIKDPJIEPEELOPHLFAOHIK, 2);
                GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                GUIUtility.GetControlID(_bi2.DJPMGBHJLNGIAAEIKDPJIEPEELOPHLFAOHIK, 2);
                GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
                GUIUtility.GetControlID(_bi2.CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID, 2);
            }
            GUI.BeginClip(rect, new Vector2(Mathf.Round(-scrollPosition.x - viewRect.x), Mathf.Round(-scrollPosition.y - viewRect.y)), Vector2.zero, false);
            return scrollPosition;
        }

        // Token: 0x06000331 RID: 817 RVA: 0x00040B1C File Offset: 0x0003ED1C
        private static void EndScrollView(bool handleScrollWheel = true)
        {
            GUI.EndClip();
            bool flag = handleScrollWheel && Event.current.type == 6 && _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.ELLBKFOCFILNGHCCPNIIOHJBJLLFNDLPJFEM.Contains(Event.current.mousePosition);
            if (flag)
            {
                _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB._AFS.x = Mathf.Clamp(_bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB._AFS.x + Event.current.delta.x * 20f, 0f, _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.CJOOAMFFPFAHKPGODOFCHGHMJOOPHFMJIPEF.width - _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.width);
                _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB._AFS.y = Mathf.Clamp(_bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB._AFS.y + Event.current.delta.y * 20f, 0f, _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.CJOOAMFFPFAHKPGODOFCHGHMJOOPHFMJIPEF.height - _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height);
                _bi2.HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB.BNDNMNLNGECCIIKKAGLNIPHBPMBGGLJKNKJE = true;
                Event.current.Use();
            }
        }

        // Token: 0x06000332 RID: 818 RVA: 0x00040C38 File Offset: 0x0003EE38
        private float GetHeightInInspector()
        {
            float num = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.position.height;
            VisualElement visualElement = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.rootVisualElement[1];
            bool flag = visualElement == null;
            float num2;
            if (flag)
            {
                num2 = num;
            }
            else
            {
                visualElement = UQueryExtensions.Query(visualElement, null, "unity-inspector-main-container").First();
                bool flag2 = visualElement == null;
                if (flag2)
                {
                    num2 = num;
                }
                else
                {
                    ScrollView scrollView = UQueryExtensions.Query(visualElement, null, "unity-inspector-root-scrollview").First() as ScrollView;
                    bool flag3 = scrollView == null;
                    if (flag3)
                    {
                        num2 = num;
                    }
                    else
                    {
                        Rect worldBound = scrollView.worldBound;
                        VisualElement visualElement2 = UQueryExtensions.Query(scrollView.contentViewport, null, "unity-inspector-editors-list").First();
                        bool flag4 = visualElement2 == null;
                        if (flag4)
                        {
                            num2 = num;
                        }
                        else
                        {
                            VisualElement visualElement3 = UQueryExtensions.Query(visualElement2.Children().Last<VisualElement>(), null, "unity-inspector-element").First();
                            bool flag5 = visualElement3 == null;
                            if (flag5)
                            {
                                num2 = num;
                            }
                            else
                            {
                                Vector2 vector = VisualElementExtensions.ChangeCoordinatesTo(visualElement3, scrollView, Vector2.zero);
                                num = worldBound.height - vector.y;
                                bool flag6 = vector.y == 0f || num < 1f;
                                if (flag6)
                                {
                                    num2 = this.OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH.position.height;
                                }
                                else
                                {
                                    num2 = num;
                                }
                            }
                        }
                    }
                }
            }
            return num2;
        }

        // Token: 0x06000333 RID: 819 RVA: 0x00040D9C File Offset: 0x0003EF9C
        private bool ProcessCodeViewCommands()
        {
            bool flag = Event.current.type == 13;
            if (flag)
            {
                bool flag2 = Event.current.commandName == "SelectAll";
                if (flag2)
                {
                    Event.current.Use();
                    return true;
                }
                bool flag3 = Event.current.commandName == "Copy" || Event.current.commandName == "Cut";
                if (flag3)
                {
                    bool flag4 = this._ATW() != null || _bg8._BAP;
                    if (flag4)
                    {
                        Event.current.Use();
                        return true;
                    }
                }
                else
                {
                    bool flag5 = Event.current.commandName == "Paste";
                    if (flag5)
                    {
                        bool flag6 = !string.IsNullOrEmpty(EditorGUIUtility.systemCopyBuffer);
                        if (flag6)
                        {
                            Event.current.Use();
                            return true;
                        }
                    }
                    else
                    {
                        bool flag7 = Event.current.commandName == "Delete";
                        if (flag7)
                        {
                            Event.current.Use();
                            return true;
                        }
                        bool flag8 = Event.current.commandName == "Duplicate";
                        if (flag8)
                        {
                            Event.current.Use();
                            return true;
                        }
                        bool flag9 = Event.current.commandName == "OpenAtCursor";
                        if (flag9)
                        {
                            Event.current.Use();
                            return true;
                        }
                        bool flag10 = Event.current.commandName == "SuperEditor.Autocomplete";
                        if (flag10)
                        {
                            Event.current.Use();
                            return true;
                        }
                    }
                }
            }
            else
            {
                bool flag11 = !this.CanEdit();
                if (flag11)
                {
                    return false;
                }
                bool flag12 = Event.current.type == 14;
                if (flag12)
                {
                    this.PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 0f;
                    bool flag13 = Event.current.commandName == "SelectAll";
                    if (flag13)
                    {
                        this._ATL(new GCE._AFA
                        {
                            _ATG = 0,
                            _ATF = 0,
                            _AEU = 0,
                            _ABI = 0
                        });
                        this._ABH._ABI = this._ABQ._ASK - 1;
                        this._ABH._AEU = ((this._ABQ._ASK > 0) ? this._ABQ.FLOg[this._ABQ._ASK - 1].Length : 0);
                        this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABQ._ASK - 1));
                        Event.current.Use();
                        this._ATM = _bi2._ATN;
                        this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                        this._ATO = true;
                        this.Repaint();
                        return true;
                    }
                    bool flag14 = Event.current.commandName == "Paste";
                    if (flag14)
                    {
                        bool flag15 = !string.IsNullOrEmpty(EditorGUIUtility.systemCopyBuffer) && this.TryEdit();
                        if (flag15)
                        {
                            bool flag16 = _bc5.Instance()._AOW == EditorGUIUtility.systemCopyBuffer;
                            bool flag17 = this._ATW() != null;
                            if (flag17)
                            {
                                this._ABH = this._ABQ.DeleteText(this._ATW(), this._ABH);
                                this._ATL(null);
                                flag16 = false;
                            }
                            string text = EditorGUIUtility.systemCopyBuffer;
                            text = text.Replace("\r\n", "\n");
                            text = text.Replace('\r', '\n');
                            this._ABQ.BeginEdit("Paste");
                            int _ARC = this._ABH._ABI;
                            bool flag18 = this._ABQ.FirstNonWhitespace(_ARC) == this._ABQ.FLOg[_ARC].Length;
                            bool flag19 = flag16;
                            if (flag19)
                            {
                                this._ABQ.InsertText(new GCE._AFA
                                {
                                    _ABI = _ARC
                                }, text);
                                this._ABH._ABI++;
                            }
                            else
                            {
                                this._ABH = this._ABQ.InsertText(this._ABH, text);
                                bool bopcdiiiaacdailgpofhgpkbbolaifbdfado = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                if (bopcdiiiaacdailgpofhgpkbbolaifbdfado)
                                {
                                    this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                                }
                            }
                            this._ABQ.UpdateHighlighting(_ARC, this._ABH._ABI, false);
                            bool flag20 = _ARC < this._ABH._ABI || flag18;
                            if (flag20)
                            {
                                this.ReindentLines(_ARC, this._ABH._ABI);
                            }
                            this._ABQ.EndEdit();
                            this.AddRecentLocation(0, true);
                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                            Event.current.Use();
                            this._ATM = _bi2._ATN;
                            this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                            this._ATO = true;
                            this.Repaint();
                            return true;
                        }
                    }
                    else
                    {
                        bool flag21 = Event.current.commandName == "Copy" || (Event.current.commandName == "Cut" && this.TryEdit());
                        if (flag21)
                        {
                            bool flag22 = this._ATW() != null;
                            if (flag22)
                            {
                                _bc5.Instance()._AOW = null;
                                EditorGUIUtility.systemCopyBuffer = this._ABQ.GetTextRange(this._ABH, this._ATW());
                                bool flag23 = Event.current.commandName == "Cut";
                                if (flag23)
                                {
                                    this._ABQ.BeginEdit("Cut Selection");
                                    this._ABH = this._ABQ.DeleteText(this._ATW(), this._ABH);
                                    bool bopcdiiiaacdailgpofhgpkbbolaifbdfado2 = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                    if (bopcdiiiaacdailgpofhgpkbbolaifbdfado2)
                                    {
                                        this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                                    }
                                    this._ABQ.UpdateHighlighting(this._ABH._ABI, this._ABH._ABI, false);
                                    this._ABQ.EndEdit();
                                    this._ATL(null);
                                    this.AddRecentLocation(0, true);
                                    this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                                    this._ATM = _bi2._ATN;
                                    this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                    this._ATO = true;
                                    this.Repaint();
                                }
                            }
                            else
                            {
                                bool flag24 = _bg8._BAP;
                                if (flag24)
                                {
                                    string text2 = this._ABQ.FLOg[this._ABH._ABI];
                                    bool flag25 = text2 != "";
                                    if (flag25)
                                    {
                                        _bc5.Instance()._AOW = text2 + "\n";
                                        EditorGUIUtility.systemCopyBuffer = _bc5.Instance()._AOW;
                                        bool flag26 = Event.current.commandName == "Cut";
                                        if (flag26)
                                        {
                                            this._ABQ.BeginEdit("Cut Line");
                                            GCE._AFA _ATD = new GCE._AFA
                                            {
                                                _ABI = this._ABH._ABI + 1
                                            };
                                            bool flag27 = this._ABQ.FLOg.Count == _ATD._ABI;
                                            if (flag27)
                                            {
                                                _ATD._AEU = this._ABQ.FLOg[this._ABQ.FLOg.Count - 1].Length;
                                                _ATD._ABI--;
                                                _ATD._ATG = (_ATD._ATF = this.CharIndexToColumn(_ATD._AEU, _ATD._ABI));
                                            }
                                            this._ABH = this._ABQ.DeleteText(new GCE._AFA
                                            {
                                                _ABI = this._ABH._ABI
                                            }, _ATD);
                                            bool bopcdiiiaacdailgpofhgpkbbolaifbdfado3 = this.BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;
                                            if (bopcdiiiaacdailgpofhgpkbbolaifbdfado3)
                                            {
                                                this._ABH._ATG = (this._ABH._ATF = this.CharIndexToColumn(this._ABH._AEU, this._ABH._ABI));
                                            }
                                            this._ABQ.UpdateHighlighting(this._ABH._ABI, this._ABH._ABI, false);
                                            this._ABQ.EndEdit();
                                            this.AddRecentLocation(0, true);
                                            this._ATM = _bi2._ATN;
                                            this.DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA = false;
                                            this._ATO = true;
                                            this.Repaint();
                                        }
                                    }
                                }
                            }
                            Event.current.Use();
                            return true;
                        }
                        bool flag28 = Event.current.commandName == "Delete" && this.TryEdit();
                        if (flag28)
                        {
                            bool flag29 = Application.platform == null || (this._ATW() == null && !_bg8._BAP);
                            if (flag29)
                            {
                                this.CommandDeleteLine();
                            }
                            else
                            {
                                bool flag30 = this._ATW() == null && this._ABQ.FLOg[this._ABH._ABI] == "";
                                if (!flag30)
                                {
                                    Event.current.commandName = "Cut";
                                    return this.ProcessCodeViewCommands();
                                }
                                this.CommandDeleteLine();
                            }
                            Event.current.Use();
                            return true;
                        }
                        bool flag31 = Event.current.commandName == "Duplicate" && this.TryEdit();
                        if (flag31)
                        {
                            this.CommandDuplicateLinesDown();
                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                            Event.current.Use();
                            return true;
                        }
                        bool flag32 = Event.current.commandName == "OpenAtCursor";
                        if (flag32)
                        {
                            Event.current.Use();
                            this.OpenAtCursor();
                            return true;
                        }
                        bool flag33 = Event.current.commandName == "SuperEditor.Autocomplete" && this.TryEdit();
                        if (flag33)
                        {
                            Event.current.Use();
                            this.JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL = true;
                            this.GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN = true;
                            this.Repaint();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Token: 0x040002A4 RID: 676
        private GUIContent NCNKKLKOFJAKAPPFFHMDALGLDGPBKGLCNIIA = new GUIContent();

        // Token: 0x040002A5 RID: 677
        private static Texture2D NLKLFFEHGAOCPBJMKILBAJBPHJMHBJEKHOFA;

        // Token: 0x040002A6 RID: 678
        private static Texture2D PFGMEJLLJPMAPPHJDBPLAODICICMBLHNKKAB;

        // Token: 0x040002A7 RID: 679
        private static Texture2D FJHJMLPMPICJDJHGPHKCHLPDABECAPHNLBDL;

        // Token: 0x040002A8 RID: 680
        private static Texture2D IKAJMFCHNHPALEOMJJLHJFIOOABGCPIIBMMF;

        // Token: 0x040002A9 RID: 681
        private static Texture2D PKNNMKEEKOEEDPPADOBGGMNPANFDLFEKELML;

        // Token: 0x040002AA RID: 682
        private static char[] JHCFMJHGFHIGMNHFMLDCNLHAMGHANGOPFJNN = new char[] { ' ', '\t' };

        // Token: 0x040002AB RID: 683
        internal _bb6 _ALP;

        // Token: 0x040002AC RID: 684
        private bool LFGCFFNKDEDPOGFLAKNDCPHCNEDJKMPJMDFG = true;

        // Token: 0x040002AD RID: 685
        private List<int> CFGMIHPKGHMFFINDHELODHEJGENHNKBBHPGK = new List<int>();

        // Token: 0x040002AE RID: 686
        private bool FLHMMGOGABACNGEBPCFEFGPMFNAKDPIGLABB = false;

        // Token: 0x040002AF RID: 687
        internal static List<string> BGBI = new List<string> { "VS Dark with VA X", "Xcode" };

        // Token: 0x040002B0 RID: 688
        internal static List<Theme> BPDG = new List<Theme>
        {
            KPODIDCKKJDLNODNNDDKCACKFJBBAEEKMGKN.OCJCCBBKNNLIAJBPBMMFHLHIAJEAFBMOIOFM,
            MOIA.OCJCCBBKNNLIAJBPBMMFHLHIAJEAFBMOIOFM
        };

        // Token: 0x040002B1 RID: 689
        private static Theme LMHCAPKMBCKPJCOFDJBKMEFJDCENENGPPKKN;

        // Token: 0x040002B2 RID: 690
        private static Theme NEJDBEMCGLKCAHENKLCFDOMOFGNHCBAIIDLF;

        // Token: 0x040002B3 RID: 691
        private _bh4 _AMN;

        // Token: 0x040002B4 RID: 692
        private _bj5 _AN;

        // Token: 0x040002B5 RID: 693
        internal static int CILPDAECBAHABNCJKNDKGGINMCLJFJKGEBAO = _bi2.BGBI.Count;

        // Token: 0x040002B6 RID: 694
        internal static string[] OFCDBBBDLNHBALAKIGKPEIMNCAECAFBMGPAP;

        // Token: 0x040002B7 RID: 695
        private static string LJKHDAPCHJBAPKJLHCFIANJIODFKNMHPAMOC = null;

        // Token: 0x040002B8 RID: 696
        private static bool PJOMAIJGCAPMFLENCDNIAPJJKNGLFDICIFLL = true;

        // Token: 0x040002B9 RID: 697
        private static bool LAMCCIBPLNNJDOIKIKNLEKKMPAEIIAHGEGDH = true;

        // Token: 0x040002BA RID: 698
        [NonSerialized]
        private float JPPFMECFJCDOMNMEIPPNOEIICFJPJCAFJLMK = 0f;

        // Token: 0x040002BB RID: 699
        [NonSerialized]
        private float MFHBMAGLJHOKEHCENMEKNBKPGBPBEECMDAKC = 1f;

        // Token: 0x040002BC RID: 700
        [SerializeField]
        private bool EIMJAKFHOFKPPHINOOONMDAPCKAAPELJKAIL = true;

        // Token: 0x040002BD RID: 701
        private static _bi2._AVA FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE = new _bi2._AVA();

        // Token: 0x040002BE RID: 702
        private static _bi2._AVA EMGEKEIEHPNEFMOMMCIFEEGIFJDEJFOKPAFM = new _bi2._AVA();

        // Token: 0x040002BF RID: 703
        [NonSerialized]
        public _bi2._AVA _ABT = _bi2.FKIPBDDJJKDBAABDMLPKIGEAKBOODIOIIJEE;

        // Token: 0x040002C0 RID: 704
        [NonSerialized]
        private GUIStyle NADMKBHKCNFNCNCBDFLCHFIPGKOGNONBFNIL;

        // Token: 0x040002C1 RID: 705
        [SerializeField]
        [HideInInspector]
        private Vector2 _AFS;

        // Token: 0x040002C2 RID: 706
        [SerializeField]
        [HideInInspector]
        private int AINBDLCEICDFCIMEOFNOEFAHLLPOHEECOPNE;

        // Token: 0x040002C3 RID: 707
        [HideInInspector]
        [SerializeField]
        private float LPAPJBHKOMFLPDIFIIJEHJBMOEFHHAIBGJBF;

        // Token: 0x040002C4 RID: 708
        [NonSerialized]
        private Vector2 OKJELGDKOEAMANJFODNINLMCPLBNCFHKDNNE;

        // Token: 0x040002C5 RID: 709
        private float BHANPCDIOAHCJKEGENEHNEHACADLNINEFAKG = 0f;

        // Token: 0x040002C6 RID: 710
        private int GBDPEFEOCLPNDEPKHJNLBKNGGHIDLKLJEOJK = 0;

        // Token: 0x040002C7 RID: 711
        [NonSerialized]
        private Vector2 EMPLHHGIPJCGEICPFEHNLAIMLHOHKPNCGCCO;

        // Token: 0x040002C8 RID: 712
        [NonSerialized]
        private DateTime NJLKIOECLMPLPCIEOLCBGKJBLDPMHBCHJBJN;

        // Token: 0x040002C9 RID: 713
        [NonSerialized]
        private bool FCDDEENLBDFBMKEFLKIKPCKPAAGBJLEPHCHC;

        // Token: 0x040002CA RID: 714
        [NonSerialized]
        private Rect _AFO;

        // Token: 0x040002CB RID: 715
        [NonSerialized]
        private Rect JOOAGLFAONABMOABLNMAKLBBGDJOFNMGFBOB;

        // Token: 0x040002CC RID: 716
        [NonSerialized]
        private float HNBKJDKPBPNIOBIGJKDEDOFLENDLKDCOCMAH = 1f;

        // Token: 0x040002CD RID: 717
        [NonSerialized]
        private bool FAABIAGAJJGAMJHJFFCKGGMDOFHDOLELPKPN;

        // Token: 0x040002CE RID: 718
        [NonSerialized]
        private bool BBNCFBJBOKMILIDIMJKJKEHCDAFMDFNDNGGI;

        // Token: 0x040002CF RID: 719
        [NonSerialized]
        private int ANAGDFICEFNAOCIGDFJALOOGGMBIDBLNPPON;

        // Token: 0x040002D0 RID: 720
        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool BBFLOGMOLBEMOMBADGIPFCDNLNOKPIEMCPAB;

        // Token: 0x040002D1 RID: 721
        [NonSerialized]
        private EditorWindow OGJMAADHJNFCLONPJGOCCAKPODNCOKEOJFMF;

        // Token: 0x040002D2 RID: 722
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CompilerGenerated]
        private Vector2 NCOGBBOAIHDPGKJIFPBILAHCAKNBMFGPJPML;

        // Token: 0x040002D3 RID: 723
        private Dictionary<string, float> PKFNCAIDJDMDDHBBFMKAGPDLNGLMMHKHHFOD = new Dictionary<string, float>();

        // Token: 0x040002D4 RID: 724
        private bool BOPCDIIIAACDAILGPOFHGPKBBOLAIFBDFADO;

        // Token: 0x040002D5 RID: 725
        private static readonly int POLEBJDFFKNDNEPLJLCBHAFEMDIOHJCFICJF = "Button".GetHashCode();

        // Token: 0x040002D6 RID: 726
        [NonSerialized]
        public bool PKEDGKNPLDKJDFNDFLIOAEPLNNJAMOHKEHKM;

        // Token: 0x040002D7 RID: 727
        [NonSerialized]
        private bool HNFGMNOKDFHDBOOJNFKJEEHBPKBFIOPLMAGK = false;

        // Token: 0x040002D8 RID: 728
        [NonSerialized]
        private bool POAAHKKEFHAFHHJDHLCDIOKHAKGHNKOKPPFG = true;

        // Token: 0x040002D9 RID: 729
        [SerializeField]
        private static bool JCOIBCPNFDEEEKEJBMMLNNCHKHFFNFMKPGOP = false;

        // Token: 0x040002DA RID: 730
        private static string FNABLFJGDDBBCLNCLGLMABBFIFELKOGMEFFJ = string.Empty;

        // Token: 0x040002DB RID: 731
        [SerializeField]
        private string FEDKNBJPGLNNBLCBJGPAICAGEHEAFOEDMJOD = "";

        // Token: 0x040002DC RID: 732
        [NonSerialized]
        private List<GCE._AFA> DFBJCNCLBOHCOOEENDPAPNJEPKICJHFHLHFH = new List<GCE._AFA>();

        // Token: 0x040002DD RID: 733
        [NonSerialized]
        private int HNJLNADMDKDENNBDPEGJAIJBFAEKFABKLGJD = -1;

        // Token: 0x040002DE RID: 734
        [NonSerialized]
        private int KEGJHDFHDLGNNJHGDCGACGKHOGLEMOAPJFAH = 0;

        // Token: 0x040002DF RID: 735
        [NonSerialized]
        private bool IEBKNKNJPHMNKJBGPLICNBIKHCFFODECEOHG = false;

        // Token: 0x040002E0 RID: 736
        [NonSerialized]
        private bool LPDHPJNAHLLADJCFMGCEECABJMPHIPPIFMPC;

        // Token: 0x040002E1 RID: 737
        [NonSerialized]
        private float PLNPCENGAKFOMJMLMFIMLBMEBCMJAICLKBCC = 0f;

        // Token: 0x040002E2 RID: 738
        [NonSerialized]
        private DateTime CEIOIDHACNPFGACJAEPBFOKGBDKAJDNJBOHO;

        // Token: 0x040002E3 RID: 739
        [NonSerialized]
        private GUIContent ALEFBKKGNIEBNDEELINNCPMNIEFPJDMODNML = new GUIContent();

        // Token: 0x040002E4 RID: 740
        [NonSerialized]
        private Color FDPCNBHGMAKONNHGIDPBGOCAAFAJOMNOANAH = _bi2._ALN;

        // Token: 0x040002E5 RID: 741
        internal static readonly Color LPOHMAKKMINPLMFKLACCFKJDLPMPAPBBAECP = new Color32(243, 124, 119, byte.MaxValue);

        // Token: 0x040002E6 RID: 742
        internal static readonly Color _ALN = new Color32(6, 180, 238, byte.MaxValue);

        // Token: 0x040002E7 RID: 743
        [NonSerialized]
        private Rect EKIIIOBHDBPDDBJFCMEGHBHLMOEGCCODHDFF;

        // Token: 0x040002E8 RID: 744
        [NonSerialized]
        public bool _ATO = false;

        // Token: 0x040002E9 RID: 745
        [NonSerialized]
        private _bh4 EPLFFMMBLDBGHFONANEPOMGLDJEBDGHFEKCI = null;

        // Token: 0x040002EA RID: 746
        [NonSerialized]
        private string ECFNGKOPKNOCJICAIJMDNLOMFCBIADJGGDGH = null;

        // Token: 0x040002EB RID: 747
        [NonSerialized]
        private DateTime FHJLFMFHAGFPFMJLEGINHPPNDKNNANJLLHHH;

        // Token: 0x040002EC RID: 748
        [NonSerialized]
        private TextPosition DBCDHOGMLKDLIIGDJKGEMBKDOKBFHBEPOACH;

        // Token: 0x040002ED RID: 749
        [NonSerialized]
        private TextPosition AINAPHEFHKPMIMHDICFLJBJPOPICCAJNCCAL;

        // Token: 0x040002EE RID: 750
        [NonSerialized]
        private int DDEDCENDGNAJAOGKJCMAEGOHJHGEJMLIGKJA = -1;

        // Token: 0x040002EF RID: 751
        [NonSerialized]
        private GCE._AFA JDIEJIOALBJFEGNLOFNIEOFHIEPHADLOHKBG;

        // Token: 0x040002F0 RID: 752
        private static string[] HJEDHEAJDDEAIGLAAMLLNOFBJHJKKLLPCHJN = new string[0];

        // Token: 0x040002F1 RID: 753
        internal static bool _AKS;

        // Token: 0x040002F2 RID: 754
        [NonSerialized]
        private bool PJJNCLILMNNHAGCFMAEOAHDAGGAKDOIMCAEI = true;

        // Token: 0x040002F3 RID: 755
        [NonSerialized]
        public DateTime _ATM;

        // Token: 0x040002F4 RID: 756
        [HideInInspector]
        [SerializeField]
        public GCE._AFA _ABH = new GCE._AFA();

        // Token: 0x040002F5 RID: 757
        [HideInInspector]
        [SerializeField]
        private GCE._AFA GLAAHLAEKKCKGBFLOGGJOIAHHBGOIFHFLJOL = null;

        // Token: 0x040002F6 RID: 758
        [HideInInspector]
        [SerializeField]
        private bool BODJHGOIEFMIPPGPLNBAIBNIEFNGEJODGHFL = false;

        // Token: 0x040002F7 RID: 759
        [NonSerialized]
        private bool PNBFHJBPGLJPBOMMOHFIHHJONMJLBKBGFFLL = false;

        // Token: 0x040002F8 RID: 760
        [NonSerialized]
        private bool CIOLLBEJAOJGGEDHBAFDIIEPHPNCCNJPFNCI = false;

        // Token: 0x040002F9 RID: 761
        [NonSerialized]
        private GCE._AFA GDCGAOFJJOCBOKONDOHJMAFAGPHDOEKIKLND = new GCE._AFA();

        // Token: 0x040002FA RID: 762
        [NonSerialized]
        private Vector2 FNLMKBLHLEDPNOLIJLANGCMHHAKNHDJGFCFN = Vector2.zero;

        // Token: 0x040002FB RID: 763
        [NonSerialized]
        private Vector2 DAOLEHELIBAIPNAPOFMDOLIAOEHCLFOGLHGI = Vector2.zero;

        // Token: 0x040002FC RID: 764
        [NonSerialized]
        private DateTime LAHBGBFFABHOMBCEKEOONHEFBNAHFPKDNLNM;

        // Token: 0x040002FD RID: 765
        [NonSerialized]
        private bool MCGNCIKLJIGDHCHFMOIJFAHKLHHKFFJKAJEA = false;

        // Token: 0x040002FE RID: 766
        [NonSerialized]
        private bool PEGFBNGNMIIMHJHBGGJMIPPGCENEDFKBJIPF = false;

        // Token: 0x040002FF RID: 767
        [NonSerialized]
        private bool DJGNBJKIOLLPFOCBADELJOOKBOBDJDHIFHLC = false;

        // Token: 0x04000300 RID: 768
        [NonSerialized]
        private bool ALLEDCEJLCOEBNDPEPFIJNFCIFIDIDNEHKFJ = false;

        // Token: 0x04000301 RID: 769
        [NonSerialized]
        private GCE _ABQ = null;

        // Token: 0x04000302 RID: 770
        [NonSerialized]
        private _bi2.PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD KPOKBHDGCMLBFEPIHIPEKAIPDGAAGIMNLFCD;

        // Token: 0x04000303 RID: 771
        [SerializeField]
        public List<int> KOIHKOPAJAHOJBIDDOPAPJCKBHPOGDGPOEJP = new List<int>();

        // Token: 0x04000304 RID: 772
        [SerializeField]
        public List<int> NCJPNOOAENPCCMAMKAFNBIIKKPBEJIMJNJKI = new List<int>();

        // Token: 0x04000305 RID: 773
        [SerializeField]
        public int BEOOILOKJPMGIAIFECEOEGHJCFAFCGJFJICN = 0;

        // Token: 0x04000306 RID: 774
        [SerializeField]
        private List<float> JKLCMHOFNIJEKGHFAFDFNEIMANIEOAIMBKPC;

        // Token: 0x04000307 RID: 775
        private static int MIEOJDKEHOCEGDGBNGALKEANHMLJDPKPBDEN;

        // Token: 0x04000308 RID: 776
        private static HashSet<Process> CNCBOMMHGCFHFIHPLKAAODEAJHLKCFAPMILL = new HashSet<Process>();

        // Token: 0x04000309 RID: 777
        private static bool IBJPBLKKEKFIOKLKOAHFHFNKPAEBABFIBMEN;

        // Token: 0x0400030A RID: 778
        private static EditorWindow DKJCMMDHBKEIIHAPOIPCGOGHBAKOMEGIGHPC;

        // Token: 0x0400030B RID: 779
        public _bi2._AGE _AGD;

        // Token: 0x0400030C RID: 780
        private static string LCACECDIEPMANKEBMJDCAGDDDCNOFOFFKPBJ;

        // Token: 0x0400030D RID: 781
        private static readonly GUIContent JKEGIJCLAEEMOEKPHALMICPOHFLNNBDPPAIK = new GUIContent("W");

        // Token: 0x0400030E RID: 782
        [NonSerialized]
        private bool IJHPBGAKHCDFMHNJBPIKHIBLJKELODMJBKIK = false;

        // Token: 0x0400030F RID: 783
        [NonSerialized]
        private GCE._AFA FJPJHHHPDBGHFLKJKMKBLKJDJEMHAHPODLBA;

        // Token: 0x04000310 RID: 784
        [NonSerialized]
        private GCE._AFA DKELKEIMAPNONDDGGMONPPBABKHIJADBIGIG;

        // Token: 0x04000311 RID: 785
        [NonSerialized]
        private bool KOLAGFCMKEFOAKDPPHCEBJPFDNEGLGMBLODK = false;

        // Token: 0x04000312 RID: 786
        [NonSerialized]
        private bool BLGGAMPHPAAEJEABCOGEBGGCAMIEELCDPMNE = false;

        // Token: 0x04000313 RID: 787
        [NonSerialized]
        private int AKNDCMEKCLNECEIINAOBBODFNCODAADFNILP = -1;

        // Token: 0x04000314 RID: 788
        [NonSerialized]
        private int MDKDMJHJKJKGBMLNFDHCKDIJDONPLLKDFGKC = -1;

        // Token: 0x04000315 RID: 789
        [NonSerialized]
        internal static DateTime EPOKGOLNPBHMELMJEOKOLPHGMLINFJCCFMMP;

        // Token: 0x04000316 RID: 790
        [NonSerialized]
        public SyntaxToken GPLPKMAECBMBIFJFHBAOKAKOILAEHLNFKIII;

        // Token: 0x04000317 RID: 791
        [NonSerialized]
        private Rect HMBHHLIKJCBCEFKDGKPNLHMOKOOLHJDKLBOL;

        // Token: 0x04000318 RID: 792
        [NonSerialized]
        public DateTime OEDBMEGKONIDNGNNNBOJKCNPNCEJPOGPBNHC;

        // Token: 0x04000319 RID: 793
        public _bk9 ADJPMDHKMMDMAGNDGAHMHFBBEEALGMEDJGFP;

        // Token: 0x0400031A RID: 794
        public _bk9 KBBCMMCMDLMOHHGNAPNIJGLHBLBGGPODLFEB;

        // Token: 0x0400031B RID: 795
        [NonSerialized]
        private GCE._AFA MGLMBDNKELHNGEPMGCMBLIGJGEOLPCLHKPBN = new GCE._AFA();

        // Token: 0x0400031C RID: 796
        [NonSerialized]
        private GCE._AFA GHAALLBLGMBDHHPIMPOIIIDIJCJBGDDBKHIC = new GCE._AFA();

        // Token: 0x0400031D RID: 797
        [NonSerialized]
        private GCE._AFA DGFPNNENOAAGOMLLCKFKADELBMKMIEIFNJBJ = new GCE._AFA();

        // Token: 0x0400031E RID: 798
        [SerializeField]
        private List<string> FDJNLNLEAGGCEHMOOPKBCCCLCKEMHMBENEAF = new List<string>();

        // Token: 0x0400031F RID: 799
        private _ba4 EEJFFFONEBHEFJKECHMCKDFAFABLNECBNBDO;

        // Token: 0x04000320 RID: 800
        [NonSerialized]
        private _bh4 OOKEDGDAPFGOMCMDMNKICHAECDBNCBGJNMKN;

        // Token: 0x04000321 RID: 801
        [NonSerialized]
        private TextPosition EGKFACOBOCJNEILBKNNIKOJMKGJHNFAHPJDN;

        // Token: 0x04000322 RID: 802
        [NonSerialized]
        private Rect MEBADINKGFMGNLFBPFEOMIEJLMDPMOLFCOAB;

        // Token: 0x04000323 RID: 803
        private static int COAPOMHMLBIKCFLNDDEIJBBPBHFBFFEKOHLH = "ScrollView".GetHashCode();

        // Token: 0x04000324 RID: 804
        private static int DJPMGBHJLNGIAAEIKDPJIEPEELOPHLFAOHIK = "Slider".GetHashCode();

        // Token: 0x04000325 RID: 805
        private static int CJKCFJLLJFNHBJPEAPKGPFPCNBGNDOJBCIID = "RepeatButton".GetHashCode();

        // Token: 0x04000326 RID: 806
        private static GUIStyle JPIEFGLNHCBCDGGCBGJDOHCNCPPKPBKEKILD;

        // Token: 0x04000327 RID: 807
        private static GUIStyle LKPFEIOPLGKOINOFJGHJGEGOPNIHGHHHDCML;

        // Token: 0x04000328 RID: 808
        private static _bi2.ICMBIOEGBPCFGEOEAPHLDMPDMCPNIACDAEBC HKFCADPHFPLAOPHGPJINLJGNOKIKJMFKMFCB;

        // Token: 0x04000329 RID: 809
        [NonSerialized]
        private List<List<int>> LOMAMECAAIALIGHCOLCOOGEHJBAMPBLPEMKH;

        // Token: 0x0400032A RID: 810
        private static readonly List<int> BJBOLEFDMGLIONMHPMDJCJEKHJKIKHJHFGDC = new List<int>();

        // Token: 0x0400032B RID: 811
        private EditorWindow OBGEMALIEGDPMEGFAOJCKCIMLAKLMFFNDLKH;

        // Token: 0x0400032C RID: 812
        private bool HGDJAMMOIBGEIGDHPGICDPHEDKLKLBGKJOFM = false;

        // Token: 0x0400032D RID: 813
        public Rect _ALM;

        // Token: 0x0400032E RID: 814
        private Rect LLIDNFNLGHEFNODHJHAAIMNPHDDIHJEJMKCH;

        // Token: 0x0400032F RID: 815
        private static int BLPCHGOBMBLGEAPDFHEIFAEBPBCJAFEONIIC = Mathf.Abs("SiCodeView".GetHashCode());

        // Token: 0x04000330 RID: 816
        private Event ONLNKGAOOFOBMBIEIDHCODGLAIFOEPJMMHGA;

        // Token: 0x04000331 RID: 817
        private bool FCOMEABJIHMPEJIHMAOBEGODANCJHOFGCDKI;

        // Token: 0x04000332 RID: 818
        private bool JHONFKMHPKCLKLHKMOEBEHPGNBLADGBBEHIL;

        // Token: 0x04000333 RID: 819
        private bool LLJFBDFABMBMPEBEDAKOJBDMGGFBOJEKCPKD;

        // Token: 0x04000334 RID: 820
        private bool GFKALDCDCJKDLLFGKMBFPABMPCNBGCFEJEIN;

        // Token: 0x04000335 RID: 821
        private string IFOOFJEHFDEEDMEJMCKOLIBPDFBJEFLOBCEM;

        // Token: 0x04000336 RID: 822
        [NonSerialized]
        private bool IKLLHBOIKJFIAHLFHOEAIKOEOIPKDFMKPMPH;

        // Token: 0x04000337 RID: 823
        private static Type GNKMGOCJJIKILOJAIHKDPGNGIHKFGFCPGOND = Type.GetType("P4Connect.Menus,P4Connect");

        // Token: 0x04000338 RID: 824
        private static MethodInfo[] OJDCDLPIEPHCKLBBPIMDFAPPBEEJJPPKJCGE;

        // Token: 0x04000339 RID: 825
        private static PropertyInfo JANKLBGMKNJIIECLOOOELKFHIDBKGGKJPIAN;

        // Token: 0x0400033A RID: 826
        private GUIContent KDLLNFPMJDJLLNBHCKGJIGPICHOPAOFCMKAF = new GUIContent();

        // Token: 0x0400033B RID: 827
        private GUIContent HAIFADBGDJMADHMOCHGILGGMCJCPGEODJBPH = new GUIContent();

        // Token: 0x0400033C RID: 828
        private GUIContent JPLMCBDFMNFFHLLHIAECHLBFKNLEGBEOLBBC = new GUIContent();

        // Token: 0x0400033D RID: 829
        private GUIContent ANOBINGJIAOEAFAMODAAAGGONPMOKEGBCMLJ = new GUIContent();

        // Token: 0x0400033E RID: 830
        private static _b2 IGFEHLGDDCJOMNOLHGKLFBICAMPPMDGMAJJK;

        // Token: 0x0400033F RID: 831
        private static bool IAGMGPLNBONFCCINLNNELHHBEJPIHBHHPGHA = true;

        // Token: 0x04000340 RID: 832
        [NonSerialized]
        private bool LCMGIAKMDBLNMJEHGKEJJMKGHGONFFBGMCFO = true;

        // Token: 0x04000341 RID: 833
        internal static EditorWindow FCDGPNNHCEFBJKDFCKDNLICBBLOJGGIPBPIO;

        // Token: 0x04000342 RID: 834
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CompilerGenerated]
        private static _bi2 LIEJDFDLPDHHMPLFMPKOANNIPICOMKPBKFCN;

        // Token: 0x04000343 RID: 835
        private static bool JKLAPMECMLAAJBICDAKNMBFEMBLIJGBBDGCM = false;

        // Token: 0x04000344 RID: 836
        [NonSerialized]
        private Rect KCNPCIEKAJFBIOBEGEOCHIAELCCBKBFBCADM;

        // Token: 0x04000345 RID: 837
        private List<GCE._ABW> HCOPKDNNJMCJODPEEAMFFJOHKLANGEEOCNOF;

        // Token: 0x04000346 RID: 838
        [NonSerialized]
        private List<_bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA> KGNJCNNMIFPKALPOGAHDGCDKCMMDLDBDLILH = new List<_bi2.EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA>();

        // Token: 0x04000347 RID: 839
        private _bh4 EIHOAOKGDIECDKLLIHNPGPFALCCKMALIPMFP;

        // Token: 0x04000348 RID: 840
        internal readonly List<_bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP> EDFABJAMKHOONBEDBDMFIPINKHADJLABOKOA = new List<_bi2.LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP>();

        // Token: 0x04000349 RID: 841
        private static GUIStyle CNPBICHBNGEHDEDGNGNKNHKJEFGMFKJKBPCM;

        // Token: 0x0400034A RID: 842
        private static GUIStyle CKGHHCOKLFNM_AWHNHHDHJIGMAAHLCELHJIF;

        // Token: 0x0400034B RID: 843
        private static GUIStyle HKMOIMKALMOPECMHELNEKJKCMDLMGOPMCELB;

        // Token: 0x0400034C RID: 844
        private static GUIStyle FPHFIPDJDADEJBALAJFCMIPIJEOODGLEDEEP;

        // Token: 0x0400034D RID: 845
        [NonSerialized]
        private readonly GUIContent DGKGFJBJNCKONKKACKJDNJPLGPCKNJDIBJBL = new GUIContent("#region ");

        // Token: 0x0400034E RID: 846
        private static readonly GUIContent LLBPLBCAPNJMEDNAGOOJBIANDIBLAMGOBDLE = new GUIContent("Region");

        // Token: 0x0400034F RID: 847
        private static readonly GUIContent FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM = new GUIContent();

        // Token: 0x04000350 RID: 848
        private SearchField EJIPALGACBAGINMGHOMAGBLDNJCOAKLJGPHP;

        // Token: 0x04000351 RID: 849
        [NonSerialized]
        private string FBMOFGALBJNAKOJCGHOMPOIAOMOHKNPFLACL;

        // Token: 0x04000352 RID: 850
        [NonSerialized]
        private int JJIAPPLKBPOHJIJHNMNENIKEMLNDFKILKHKH;

        // Token: 0x04000353 RID: 851
        [NonSerialized]
        private int KOGJPGADGOFLMJHNPBMLJCOIKHJCKGHKKNAF;

        // Token: 0x04000354 RID: 852
        [NonSerialized]
        private _bb4.DHBA DFEJMEJFBMCNDGKMAAEBPLKAAGIDNBHMMLFM;

        // Token: 0x04000355 RID: 853
        [NonSerialized]
        private int DBPNPLAGPNIFADNFHOKFFCPKKIHHKOPIGFBG = -1;

        // Token: 0x04000356 RID: 854
        private static List<ThemeTemplate> JMFFKMDENDGHKKBOFMDHJLMPKAKCGLBLJIFP;

        // Token: 0x04000357 RID: 855
        internal static DateTime _ATN = DateTime.Now;

        // Token: 0x04000358 RID: 856
        [NonSerialized]
        private bool FDILMOBIKGLOAFGDFHGBCLBHNPNHKLOKDCNN;

        // Token: 0x04000359 RID: 857
        [NonSerialized]
        private TextPosition CHHDGGEFPPLGNDHEEKADDPLNNJIAKMIPDKOD;

        // Token: 0x0400035A RID: 858
        [NonSerialized]
        private TextPosition CHPBGFIBMHEHHEPCOFLHBLJABIHHBHJCPPHO;

        // Token: 0x0400035B RID: 859
        [NonSerialized]
        private bool DJLIKNMAIPOALAMANDOGJHEODLHBGBBNBMIA;

        // Token: 0x0400035C RID: 860
        private static bool NALGACOOFEHEHONBNAEIKOEKDJGIODABHAAB;

        // Token: 0x0400035D RID: 861
        private bool DMNDDOLDBANIGJLBJIDFEAHIIPDHJAFAALJJ;

        // Token: 0x0400035E RID: 862
        private float CAKHIDEDHOGABNHPLIHFBBDGGEFFNPBAMFJA;

        // Token: 0x0400035F RID: 863
        private Rect KEEPEDCLFCGNKDCIALMFGMGDNDHNMOFBIBJJ;

        // Token: 0x02000058 RID: 88
        internal class _AVA
        {
            // Token: 0x04000360 RID: 864
            public GUIStyle MNAINPPJCJGPLHBFJICPBAPKHGGPKHFKGHKI;

            // Token: 0x04000361 RID: 865
            public GUIStyle _ABV;

            // Token: 0x04000362 RID: 866
            public GUIStyle MLINBOOFJJFOOJDFIODGPBCGFAFGFGHIINAK;

            // Token: 0x04000363 RID: 867
            public GUIStyle LPMHKIAKCIJCOALOPOKIGFPOBAHPLGHMDGJE;

            // Token: 0x04000364 RID: 868
            public GUIStyle _ACK;

            // Token: 0x04000365 RID: 869
            public GUIStyle _ACF;

            // Token: 0x04000366 RID: 870
            public GUIStyle _ACE;

            // Token: 0x04000367 RID: 871
            public GUIStyle _ACL;

            // Token: 0x04000368 RID: 872
            public GUIStyle _ACG;

            // Token: 0x04000369 RID: 873
            public GUIStyle _ACH;

            // Token: 0x0400036A RID: 874
            public GUIStyle _ACN;

            // Token: 0x0400036B RID: 875
            public GUIStyle ABFOGCOCKGPDGCECELHDDPLJPLOMFINBMDFB;

            // Token: 0x0400036C RID: 876
            public GUIStyle FEPCGBBLADFJIOAOEGONMDEELEFFPMAGDNLD;

            // Token: 0x0400036D RID: 877
            public GUIStyle AFJAELGAFCMBADAHILPMPIMHNBLJOHPBDMFL;

            // Token: 0x0400036E RID: 878
            public GUIStyle NKFJNHICAHKHIKAHLOCGMGMOPDGCGCHDBEKC;

            // Token: 0x0400036F RID: 879
            public GUIStyle _ACI;

            // Token: 0x04000370 RID: 880
            public GUIStyle _ACJ;

            // Token: 0x04000371 RID: 881
            public GUIStyle MBNAKPHMLKEJFEHCAKCELDLDCKFHLGHAFPCM;

            // Token: 0x04000372 RID: 882
            public GUIStyle IEHHNFHGANAAGPCGFGLGFPPIEACCGPNBCGHP;

            // Token: 0x04000373 RID: 883
            public GUIStyle IBECDLBCDCMKNOFEGCLBDBHJLCOPJIIDOENE;

            // Token: 0x04000374 RID: 884
            public GUIStyle LKPEKDFLBIFFAFLONCNILICBNHJMBOHPDHOK;

            // Token: 0x04000375 RID: 885
            public GUIStyle CIAPHJPLJPJFPFHKIGOLEPILKEDJCEBKOGLI;

            // Token: 0x04000376 RID: 886
            public GUIStyle PBOJOMJKIBIKNDAOLEDPDHJIAOCOCDFBCPMG;

            // Token: 0x04000377 RID: 887
            public GUIStyle FFKKHGMKNOAEDPHBACLDPIHIAMCLDLKCHMDP;

            // Token: 0x04000378 RID: 888
            public GUIStyle JMJPFJGGIEEPNKMMFKFKBMEALOBACMLKKGDD;

            // Token: 0x04000379 RID: 889
            public GUIStyle IDEBBOAIFDBCFICJJCOCOIBKDOPNMGADPJBI;

            // Token: 0x0400037A RID: 890
            public GUIStyle _ACC;

            // Token: 0x0400037B RID: 891
            public GUIStyle _ACD;

            // Token: 0x0400037C RID: 892
            public GUIStyle _ACA;

            // Token: 0x0400037D RID: 893
            public GUIStyle _ACB;

            // Token: 0x0400037E RID: 894
            public GUIStyle BBOLFNEKGDIMCIMDGFBDONKOHIMAFOOONJLI;

            // Token: 0x0400037F RID: 895
            public GUIStyle AIIPFPOMAMLAHOHOBJPDNLMGIIIEFJAIEALI;

            // Token: 0x04000380 RID: 896
            public GUIStyle FKNGDNMIFFNDKLBIMPEOABJDFILGGHFFEKNM;

            // Token: 0x04000381 RID: 897
            public GUIStyle FKPDLHMDAGCDBKHOJAABIDBDBPCOGPOPIOJC;

            // Token: 0x04000382 RID: 898
            public GUIStyle IICGPMAMBHPFKAIGDAKKDFCDPAKDCNNGOAOF;

            // Token: 0x04000383 RID: 899
            public GUIStyle DHLIECBFHFIOLJODNKHAIFAMDEFLDKDPBLJH;

            // Token: 0x04000384 RID: 900
            public GUIStyle OAHNJENALMPCNGMEAFGPAOPDCFGGJFIMDLCK;

            // Token: 0x04000385 RID: 901
            public GUIStyle LCGFHIJHPLEJMFEAAMLOGEKDKLGPGLCKJHKN;

            // Token: 0x04000386 RID: 902
            public GUIStyle MGHDGDOIBIKACABHDJMHENIACBOCIOEAJJJH;

            // Token: 0x04000387 RID: 903
            public GUIStyle EEHEIDPKDPFECCNEMEAOEDHDMOCMLHIMGBIO;

            // Token: 0x04000388 RID: 904
            public GUIStyle MNIDILAEJNANLBJOKMBBFAPKMBLJPHDOOKHC;

            // Token: 0x04000389 RID: 905
            public GUIStyle FIJCFMEBKKCPHHDEICAFJGNHALMFHHDFMJCF;

            // Token: 0x0400038A RID: 906
            public GUIStyle EFFPDLCPLHCEJBKAEOGCFKCJMEJJCGNOEAJC;

            // Token: 0x0400038B RID: 907
            public GUIStyle LMJFOHEICFJKKJDPABNJJMODGIAGGCDCGIDG;

            // Token: 0x0400038C RID: 908
            public GUIStyle MENCECOHFEKPKPJCHBPHPLNADBLKDNLOFBMJ;

            // Token: 0x0400038D RID: 909
            public GUIStyle EDPELGLOHBEDHHGMAFPGLEMGKFNEHIMBHLBE;

            // Token: 0x0400038E RID: 910
            public GUIStyle CDKDJIHGIELEEDGFLEBKFMAICBICIONFMOMH;

            // Token: 0x0400038F RID: 911
            public GUIStyle GJOPALBNPHOPNFJCBICFHFIBJHAADOBENDJP;

            // Token: 0x04000390 RID: 912
            public GUIStyle EABGPJDDADACGMHPOGOFNJCDNONPNHNPJIMK;

            // Token: 0x04000391 RID: 913
            public GUIStyle OFHACCJKFEDEPPHBLPBAGNDAFFAJECCJDKBK;

            // Token: 0x04000392 RID: 914
            public GUIStyle _AFT;

            // Token: 0x04000393 RID: 915
            public GUIStyle _AFU;

            // Token: 0x04000394 RID: 916
            public GUIStyle KCCBAEPPGOEMGHPDPNEBIICOFIIMDOFPPNPP;

            // Token: 0x04000395 RID: 917
            public GUIStyle GLLDPBLCJGHJEOCPKMGICIEJOIDFAEIKAEKE;
        }

        // Token: 0x02000059 RID: 89
        private enum PEFGKHDNIOOJKNNHMIBNIFOKLBMEDOGOBDKD
        {

        }

        // Token: 0x0200005A RID: 90
        // (Invoke) Token: 0x06000343 RID: 835
        public delegate void _AGE();

        // Token: 0x0200005B RID: 91
        private class OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK : _bh4
        {
            // Token: 0x06000346 RID: 838 RVA: 0x00041A9C File Offset: 0x0003FC9C
            public OIPMPHOIKPLMAMMOLNHCFKPGJKPLDOKECMAK(string keyword)
            {
                this._AW = keyword;
                this._AT = SymbolKind.Keyword;
            }
        }

        // Token: 0x0200005C RID: 92
        internal sealed class ICMBIOEGBPCFGEOEAPHLDMPDMCPNIACDAEBC
        {
            // Token: 0x06000347 RID: 839 RVA: 0x00041AB4 File Offset: 0x0003FCB4
            internal void ScrollTo(Rect position)
            {
                this.ScrollTowards(position, float.PositiveInfinity);
            }

            // Token: 0x06000348 RID: 840 RVA: 0x00041AC4 File Offset: 0x0003FCC4
            internal bool ScrollTowards(Rect position, float maxDelta)
            {
                Vector2 vector = this.ScrollNeeded(position);
                bool flag = vector.sqrMagnitude < 0.0001f;
                bool flag2;
                if (flag)
                {
                    flag2 = false;
                }
                else
                {
                    bool flag3 = maxDelta == 0f;
                    if (flag3)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        bool flag4 = vector.magnitude > maxDelta;
                        if (flag4)
                        {
                            vector = vector.normalized * maxDelta;
                        }
                        this._AFS += vector;
                        this.BNDNMNLNGECCIIKKAGLNIPHBPMBGGLJKNKJE = true;
                        flag2 = true;
                    }
                }
                return flag2;
            }

            // Token: 0x06000349 RID: 841 RVA: 0x00041B3C File Offset: 0x0003FD3C
            internal Vector2 ScrollNeeded(Rect position)
            {
                Rect ogbfjigaappfdgoakhcjilnilpddhgfogelp = this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP;
                ogbfjigaappfdgoakhcjilnilpddhgfogelp.x += this._AFS.x;
                ogbfjigaappfdgoakhcjilnilpddhgfogelp.y += this._AFS.y;
                float num = position.width - this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.width;
                bool flag = num > 0f;
                if (flag)
                {
                    position.width -= num;
                    position.x += num * 0.5f;
                }
                num = position.height - this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height;
                bool flag2 = num > 0f;
                if (flag2)
                {
                    position.height -= num;
                    position.y += num * 0.5f;
                }
                Vector2 zero = Vector2.zero;
                bool flag3 = position.xMax > ogbfjigaappfdgoakhcjilnilpddhgfogelp.xMax;
                if (flag3)
                {
                    zero.x += position.xMax - ogbfjigaappfdgoakhcjilnilpddhgfogelp.xMax;
                }
                else
                {
                    bool flag4 = position.xMin < ogbfjigaappfdgoakhcjilnilpddhgfogelp.xMin;
                    if (flag4)
                    {
                        zero.x -= ogbfjigaappfdgoakhcjilnilpddhgfogelp.xMin - position.xMin;
                    }
                }
                bool flag5 = position.yMax > ogbfjigaappfdgoakhcjilnilpddhgfogelp.yMax;
                if (flag5)
                {
                    zero.y += position.yMax - ogbfjigaappfdgoakhcjilnilpddhgfogelp.yMax;
                }
                else
                {
                    bool flag6 = position.yMin < ogbfjigaappfdgoakhcjilnilpddhgfogelp.yMin;
                    if (flag6)
                    {
                        zero.y -= ogbfjigaappfdgoakhcjilnilpddhgfogelp.yMin - position.yMin;
                    }
                }
                Rect cjooamffpfahkpgodofchghmjoophfmjipef = this.CJOOAMFFPFAHKPGODOFCHGHMJOOPHFMJIPEF;
                cjooamffpfahkpgodofchghmjoophfmjipef.width = Mathf.Max(cjooamffpfahkpgodofchghmjoophfmjipef.width, this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.width);
                cjooamffpfahkpgodofchghmjoophfmjipef.height = Mathf.Max(cjooamffpfahkpgodofchghmjoophfmjipef.height, this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height);
                zero.x = Mathf.Clamp(zero.x, cjooamffpfahkpgodofchghmjoophfmjipef.xMin - this._AFS.x, cjooamffpfahkpgodofchghmjoophfmjipef.xMax - this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.width - this._AFS.x);
                zero.y = Mathf.Clamp(zero.y, cjooamffpfahkpgodofchghmjoophfmjipef.yMin - this._AFS.y, cjooamffpfahkpgodofchghmjoophfmjipef.yMax - this.OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP.height - this._AFS.y);
                return zero;
            }

            // Token: 0x04000397 RID: 919
            public Rect ELLBKFOCFILNGHCCPNIIOHJBJLLFNDLPJFEM;

            // Token: 0x04000398 RID: 920
            public Rect OGBFJIGAAPPFDGOAKHCJILNILPDDHGFOGELP;

            // Token: 0x04000399 RID: 921
            public Rect CJOOAMFFPFAHKPGODOFCHGHMJOOPHFMJIPEF;

            // Token: 0x0400039A RID: 922
            public Vector2 _AFS;

            // Token: 0x0400039B RID: 923
            public bool BNDNMNLNGECCIIKKAGLNIPHBPMBGGLJKNKJE;
        }

        // Token: 0x0200005D RID: 93
        private struct EPAFFDDCAEGGCPDGEEBEBADBOBLMGPDEPLEA
        {
            // Token: 0x0400039C RID: 924
            public TextPosition OJKLJINFJBEPHBPPEABIJNJCDOPNEJGPAGND;

            // Token: 0x0400039D RID: 925
            public TextPosition AGJBFOPCGMOGGDJKCDLBNMJAILHEKLMGPALB;
        }

        // Token: 0x0200005E RID: 94
        internal struct LCGOEHPFJAKIIHCHKLFJCHMKGJNEAJJIPKMP
        {
            // Token: 0x0400039E RID: 926
            public _bh4 _AMN;

            // Token: 0x0400039F RID: 927
            public GUIContent IJLADEDJGGFCNGLKJELKEMPGOAMJIAIBDENM;

            // Token: 0x040003A0 RID: 928
            public bool MACGPHIBANLBNBMKLNGPAGIFGHDICBLPINBC;
        }
    }
}
