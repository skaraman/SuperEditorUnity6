using System;
using System.Collections.Generic;
using SuperEditor;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000039 RID: 57
    internal class _bi6 : _bb8
    {
        // Token: 0x0600019D RID: 413 RVA: 0x00015B83 File Offset: 0x00013D83
        public IEnumerable<_be5> EnumSnippets(_bh4 context, _bh2._AGI expectedTokens, SyntaxToken tokenLeft, _bm6 scope)
        {
            bool flag = tokenLeft == null || tokenLeft.OOME == null || tokenLeft.OOME.OOME == null;
            if (flag)
            {
                yield break;
            }
            bool flag2 = tokenLeft.tokenKind != SyntaxToken.Kind.Punctuator;
            if (flag2)
            {
                yield break;
            }
            bool flag3 = tokenLeft.text != "{" && tokenLeft.text != "}" && tokenLeft.text != ";";
            if (flag3)
            {
                yield break;
            }
            _bj8 bodyScope = scope as _bj8;
            bool flag4 = bodyScope == null;
            if (flag4)
            {
                yield break;
            }
            _bi6._yf1 = bodyScope._ACV as _b2;
            bool flag5 = _bi6._yf1 == null || _bi6._yf1._AT != SymbolKind.Class;
            if (flag5)
            {
                yield break;
            }
            bool flag6 = _bi6._yf1.DerivesFrom(_bi6._yf2);
            List<_be5> magicMethods;
            if (flag6)
            {
                magicMethods = _bi6._yf3;
            }
            else
            {
                bool flag7 = _bi6._yf1.DerivesFrom(_bi6._yf4);
                if (flag7)
                {
                    magicMethods = _bi6._yf5;
                }
                else
                {
                    bool flag8 = _bi6._yf1.DerivesFrom(_bi6._yf6);
                    if (flag8)
                    {
                        magicMethods = _bi6._yf7;
                    }
                    else
                    {
                        bool flag9 = _bi6._yf1.DerivesFrom(_bi6._yf8);
                        if (flag9)
                        {
                            magicMethods = _bi6._yf9;
                        }
                        else
                        {
                            bool flag10 = _bi6._yf1.DerivesFrom(_bi6._yg1);
                            if (flag10)
                            {
                                magicMethods = _bi6._yg2;
                            }
                            else
                            {
                                bool flag11 = _bi6._yf1.DerivesFrom(_bi6._yg3);
                                if (!flag11)
                                {
                                    yield break;
                                }
                                magicMethods = _bi6._yg4;
                            }
                        }
                    }
                }
            }
            _b2 baseType = _bi6._yf1.BaseType();
            _bb4.DHBA tempLeaf = new _bb4.DHBA
            {
                _ACX = new SyntaxToken(SyntaxToken.Kind.Identifier, "")
            };
            foreach (_be5 magic in magicMethods)
            {
                ((_bi6._yg5)magic).BaseSymbol = null;
                bool flag12 = _bi6._yf1.FindName(magic._AW, -1, false) != null;
                if (!flag12)
                {
                    tempLeaf._ACX.text = magic._AW;
                    baseType.ResolveMember(tempLeaf, scope, -1, false);
                    _bh4 baseSymbol = tempLeaf._AAB();
                    bool flag13 = baseSymbol == null || baseSymbol._AT == SymbolKind.Error;
                    if (flag13)
                    {
                        yield return magic;
                    }
                    else
                    {
                        _ba7 asMethodGroup = baseSymbol as _ba7;
                        bool flag14 = baseSymbol._AT != SymbolKind.MethodGroup || asMethodGroup == null;
                        if (flag14)
                        {
                            bool flag15 = !baseSymbol._yg6();
                            if (flag15)
                            {
                                ((_bi6._yg5)magic).BaseSymbol = baseSymbol;
                            }
                            yield return magic;
                        }
                        else
                        {
                            bool yield = true;
                            string magicSignature = ((_bi6._yg5)magic).GetParametersString();
                            foreach (_bb3 baseMethod in asMethodGroup._AAM)
                            {
                                bool flag16 = baseMethod.PrintParameters(baseMethod.GetParameters(), true) == magicSignature;
                                if (flag16)
                                {
                                    bool flag17 = baseMethod._AHF() || baseMethod._AAO() || baseMethod._AAP();
                                    if (flag17)
                                    {
                                        yield = false;
                                        break;
                                    }
                                    bool flag18 = !baseMethod._yg6();
                                    if (flag18)
                                    {
                                        _b2 returnType = baseMethod.ReturnType();
                                        bool flag19 = returnType == null || returnType._AT == SymbolKind.Error;
                                        if (flag19)
                                        {
                                            ((_bi6._yg5)magic).BaseSymbol = asMethodGroup;
                                        }
                                        else
                                        {
                                            bool baseIsCoroutine = returnType._AW == "IEnumerator";
                                            bool returnsVoid = baseMethod.ReturnType() == _bh4._BFU;
                                            bool flag20 = !baseIsCoroutine && !returnsVoid;
                                            if (flag20)
                                            {
                                                ((_bi6._yg5)magic).BaseSymbol = asMethodGroup;
                                            }
                                            else
                                            {
                                                ((_bi6._yg5)magic).BaseSymbol = baseMethod;
                                            }
                                        }
                                        returnType = null;
                                    }
                                    break;
                                }
                                else
                                {
                                    // Note: Cannot assign to baseMethod as it's a foreach iteration variable
                                }
                            }
                            List<_bb3>.Enumerator enumerator2 = default(List<_bb3>.Enumerator);
                            bool flag21 = yield;
                            if (flag21)
                            {
                                yield return magic;
                            }
                            baseSymbol = null;
                            asMethodGroup = null;
                            magicSignature = null;
                            // Note: Cannot assign to magic as it's a foreach iteration variable
                        }
                    }
                }
            }
            List<_be5>.Enumerator enumerator = default(List<_be5>.Enumerator);
            yield break;
        }

        // Token: 0x0600019E RID: 414 RVA: 0x00015BB0 File Offset: 0x00013DB0
        public string Get(string shortcut, _bh4 context, _bh2._AGI expectedTokens, _bm6 scope)
        {
            return null;
        }

        // Token: 0x040001D1 RID: 465
        private static _b2 _yf1;

        // Token: 0x040001D2 RID: 466
        private static List<_be5> _yf3 = new List<_be5>
        {
            new _bi6._yg7<MonoBehaviour>("void Awake()"),
            new _bi6._yg7<MonoBehaviour>("void Start()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator Start()"),
            new _bi6._yg7<MonoBehaviour>("void Update()"),
            new _bi6._yg7<MonoBehaviour>("void LateUpdate()"),
            new _bi6._yg7<MonoBehaviour>("void FixedUpdate()"),
            new _bi6._yg7<MonoBehaviour>("void OnGUI()"),
            new _bi6._yg7<MonoBehaviour>("void OnEnable()"),
            new _bi6._yg7<MonoBehaviour>("void OnDisable()"),
            new _bi6._yg7<MonoBehaviour>("void OnDestroy()"),
            new _bi6._yg7<MonoBehaviour>("void Reset()"),
            new _bi6._yg7<MonoBehaviour>("void OnValidate()"),
            new _bi6._yg7<MonoBehaviour>("void OnTriggerEnter(Collider other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnTriggerEnter(Collider other)"),
            new _bi6._yg7<MonoBehaviour>("void OnTriggerEnter2D(Collider2D other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnTriggerEnter2D(Collider2D other)"),
            new _bi6._yg7<MonoBehaviour>("void OnTriggerExit(Collider other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnTriggerExit(Collider other)"),
            new _bi6._yg7<MonoBehaviour>("void OnTriggerExit2D(Collider2D other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnTriggerExit2D(Collider2D other)"),
            new _bi6._yg7<MonoBehaviour>("void OnTriggerStay(Collider other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnTriggerStay(Collider other)"),
            new _bi6._yg7<MonoBehaviour>("void OnTriggerStay2D(Collider2D other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnTriggerStay2D(Collider2D other)"),
            new _bi6._yg7<MonoBehaviour>("void OnCollisionEnter(Collision collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnCollisionEnter(Collision collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("void OnCollisionEnter2D(Collision2D collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnCollisionEnter2D(Collision2D collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("void OnCollisionExit(Collision collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnCollisionExit(Collision collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("void OnCollisionExit2D(Collision2D collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnCollisionExit2D(Collision2D collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("void OnCollisionStay(Collision collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnCollisionStay(Collision collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("void OnCollisionStay2D(Collision2D collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnCollisionStay2D(Collision2D collisionInfo)"),
            new _bi6._yg7<MonoBehaviour>("void OnControllerColliderHit(ControllerColliderHit hit)"),
            new _bi6._yg7<MonoBehaviour>("void OnJointBreak(float breakForce)"),
            new _bi6._yg7<MonoBehaviour>("void OnParticleCollision(GameObject other)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnParticleCollision(GameObject other)"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseEnter()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseEnter()"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseOver()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseOver()"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseExit()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseExit()"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseDown()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseDown()"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseUp()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseUp()"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseUpAsButton()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseUpAsButton()"),
            new _bi6._yg7<MonoBehaviour>("void OnMouseDrag()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnMouseDrag()"),
            new _bi6._yg7<MonoBehaviour>("void OnLevelWasLoaded(int level)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnLevelWasLoaded(int level)"),
            new _bi6._yg7<MonoBehaviour>("void OnApplicationFocus(bool focus)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnApplicationFocus(bool focus)"),
            new _bi6._yg7<MonoBehaviour>("void OnApplicationPause(bool pause)"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnApplicationPause(bool pause)"),
            new _bi6._yg7<MonoBehaviour>("void OnApplicationQuit()"),
            new _bi6._yg7<MonoBehaviour>("void OnBecameVisible()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnBecameVisible()"),
            new _bi6._yg7<MonoBehaviour>("void OnBecameInvisible()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnBecameInvisible()"),
            new _bi6._yg7<MonoBehaviour>("void OnPreCull()"),
            new _bi6._yg7<MonoBehaviour>("void OnPreRender()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnPreRender()"),
            new _bi6._yg7<MonoBehaviour>("void OnPostRender()"),
            new _bi6._yg7<MonoBehaviour>("IEnumerator OnPostRender()"),
            new _bi6._yg7<MonoBehaviour>("void OnRenderObject()"),
            new _bi6._yg7<MonoBehaviour>("void OnWillRenderObject()"),
            new _bi6._yg7<MonoBehaviour>("void OnRenderImage(RenderTexture source, RenderTexture destination)"),
            new _bi6._yg7<MonoBehaviour>("void OnDrawGizmosSelected()"),
            new _bi6._yg7<MonoBehaviour>("void OnDrawGizmos()"),
            new _bi6._yg7<MonoBehaviour>("void OnPlayerConnected(NetworkPlayer player)"),
            new _bi6._yg7<MonoBehaviour>("void OnServerInitialized()"),
            new _bi6._yg7<MonoBehaviour>("void OnConnectedToServer()"),
            new _bi6._yg7<MonoBehaviour>("void OnPlayerDisconnected(NetworkPlayer player)"),
            new _bi6._yg7<MonoBehaviour>("void OnDisconnectedFromServer(NetworkDisconnection info)"),
            new _bi6._yg7<MonoBehaviour>("void OnFailedToConnect(NetworkConnectionError error)"),
            new _bi6._yg7<MonoBehaviour>("void OnFailedToConnectToMasterServer(NetworkConnectionError info)"),
            new _bi6._yg7<MonoBehaviour>("void OnMasterServerEvent(MasterServerEvent msEvent)"),
            new _bi6._yg7<MonoBehaviour>("void OnNetworkInstantiate(NetworkMessageInfo info)"),
            new _bi6._yg7<MonoBehaviour>("void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)"),
            new _bi6._yg7<MonoBehaviour>("void OnAnimatorIK(int layerIndex)"),
            new _bi6._yg7<MonoBehaviour>("void OnAnimatorMove()"),
            new _bi6._yg7<MonoBehaviour>("void ()"),
            new _bi6._yg7<MonoBehaviour>("void ()"),
            new _bi6._yg7<MonoBehaviour>("void ()"),
            new _bi6._yg7<MonoBehaviour>("void OnAudioFilterRead(float[] data, int channels)"),
            new _bi6._yg7<MonoBehaviour>("void OnTransformChildrenChanged()"),
            new _bi6._yg7<MonoBehaviour>("void OnTransformParentChanged()")
        };

        // Token: 0x040001D3 RID: 467
        private static List<_be5> _yf7 = new List<_be5>
        {
            new _bi6._yg7<EditorWindow>("void OnDestroy()"),
            new _bi6._yg7<EditorWindow>("void OnFocus()"),
            new _bi6._yg7<EditorWindow>("void OnGUI()"),
            new _bi6._yg7<EditorWindow>("void OnHierarchyChange()"),
            new _bi6._yg7<EditorWindow>("void OnInspectorUpdate()"),
            new _bi6._yg7<EditorWindow>("void OnLostFocus()"),
            new _bi6._yg7<EditorWindow>("void OnProjectChange()"),
            new _bi6._yg7<EditorWindow>("void OnSelectionChange()"),
            new _bi6._yg7<EditorWindow>("void Update()"),
            new _bi6._yg7<EditorWindow>("void ShowButton(Rect buttonRect)"),
            new _bi6._yg7<ScriptableObject>("void OnDisable()"),
            new _bi6._yg7<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D4 RID: 468
        private static List<_be5> _yg4 = new List<_be5>
        {
            new _bi6._yg7<ScriptableObject>("void OnDestroy()"),
            new _bi6._yg7<ScriptableObject>("void OnDisable()"),
            new _bi6._yg7<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D5 RID: 469
        private static List<_be5> _yf5 = new List<_be5>
        {
            new _bi6._yg7<ScriptableWizard>("void OnWizardCreate()"),
            new _bi6._yg7<ScriptableWizard>("void OnWizardOtherButton()"),
            new _bi6._yg7<ScriptableWizard>("void OnWizardUpdate()"),
            new _bi6._yg7<EditorWindow>("void OnDestroy()"),
            new _bi6._yg7<EditorWindow>("void OnFocus()"),
            new _bi6._yg7<EditorWindow>("void OnGUI()"),
            new _bi6._yg7<EditorWindow>("void OnHierarchyChange()"),
            new _bi6._yg7<EditorWindow>("void OnInspectorUpdate()"),
            new _bi6._yg7<EditorWindow>("void OnLostFocus()"),
            new _bi6._yg7<EditorWindow>("void OnProjectChange()"),
            new _bi6._yg7<EditorWindow>("void OnSelectionChange()"),
            new _bi6._yg7<EditorWindow>("void Update()"),
            new _bi6._yg7<ScriptableObject>("void OnDisable()"),
            new _bi6._yg7<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D6 RID: 470
        private static List<_be5> _yf9 = new List<_be5>
        {
            new _bi6._yg7<Editor>("void OnSceneGUI()"),
            new _bi6._yg7<Editor>("bool RequiresConstantRepaint()"),
            new _bi6._yg7<Editor>("bool UseDefaultMargins()"),
            new _bi6._yg7<ScriptableObject>("void OnDestroy()"),
            new _bi6._yg7<ScriptableObject>("void OnDisable()"),
            new _bi6._yg7<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D7 RID: 471
        private static List<_be5> _yg2 = new List<_be5>
        {
            new _bi6._yg7<AssetPostprocessor>("Material OnAssignMaterialModel(Material material, Renderer renderer)"),
            new _bi6._yg7<AssetPostprocessor>("static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPostprocessAssetbundleNameChanged(string assetPath, string previousAssetBundleName, string newAssetBundleName)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPostprocessAudio(AudioClip clip)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPostprocessGameObjectWithUserProperties(GameObject go, string[] propNames, object[] values)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPostprocessModel(GameObject root)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPostprocessSpeedTree(GameObject root)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPostprocessTexture(Texture2D texture)"),
            new _bi6._yg7<AssetPostprocessor>("void OnPreprocessAnimation()"),
            new _bi6._yg7<AssetPostprocessor>("void OnPreprocessAudio()"),
            new _bi6._yg7<AssetPostprocessor>("void OnPreprocessModel()"),
            new _bi6._yg7<AssetPostprocessor>("void OnPreprocessSpeedTree()"),
            new _bi6._yg7<AssetPostprocessor>("void OnPreprocessTexture()")
        };

        // Token: 0x040001D8 RID: 472
        private static _b2 _yf2 = _bl9.ForType(typeof(MonoBehaviour)).definition as _b2;

        // Token: 0x040001D9 RID: 473
        private static _b2 _yf6 = _bl9.ForType(typeof(EditorWindow)).definition as _b2;

        // Token: 0x040001DA RID: 474
        private static _b2 _yf4 = _bl9.ForType(typeof(ScriptableWizard)).definition as _b2;

        // Token: 0x040001DB RID: 475
        private static _b2 _yg3 = _bl9.ForType(typeof(ScriptableObject)).definition as _b2;

        // Token: 0x040001DC RID: 476
        private static _b2 _yf8 = _bl9.ForType(typeof(Editor)).definition as _b2;

        // Token: 0x040001DD RID: 477
        private static _b2 _yg1 = _bl9.ForType(typeof(AssetPostprocessor)).definition as _b2;

        // Token: 0x0200003A RID: 58
        private interface _yg5
        {
            // Token: 0x060001A1 RID: 417
            string GetParametersString();

            // Token: 0x17000009 RID: 9
            // (get) Token: 0x060001A2 RID: 418
            bool IsCoroutine { get; }

            // Token: 0x1700000A RID: 10
            // (get) Token: 0x060001A3 RID: 419
            // (set) Token: 0x060001A4 RID: 420
            _bh4 BaseSymbol { get; set; }
        }

        // Token: 0x0200003B RID: 59
        private class _yg7<_yg8> : _be5, _bi6._yg5
        {
            // Token: 0x1700000B RID: 11
            // (get) Token: 0x060001A5 RID: 421 RVA: 0x00016620 File Offset: 0x00014820
            // (set) Token: 0x060001A6 RID: 422 RVA: 0x00016638 File Offset: 0x00014838
            public _bh4 BaseSymbol
            {
                get
                {
                    return this._yg9;
                }
                set
                {
                    this._yg9 = value;
                }
            }

            // Token: 0x060001A7 RID: 423 RVA: 0x00016642 File Offset: 0x00014842
            public _yg7(string methodSignature)
                : base(_bi6._yg7<_yg8>.GetMethodName(methodSignature))
            {
                this._AWF = _bi6._yg7<_yg8>.GetDisplayName(methodSignature);
                this._yh1 = methodSignature;
                this._AFG = _bi6._yg7<_yg8>._yh2;
            }

            // Token: 0x060001A8 RID: 424 RVA: 0x00016670 File Offset: 0x00014870
            private static string GetMethodName(string signature)
            {
                int num = signature.IndexOf(' ');
                int num2 = signature.IndexOf('(', num + 1);
                num = signature.LastIndexOf(' ', num2);
                return signature.Substring(num + 1, num2 - num - 1);
            }

            // Token: 0x060001A9 RID: 425 RVA: 0x000166B4 File Offset: 0x000148B4
            private static string GetDisplayName(string signature)
            {
                bool flag = signature.StartsWith("IEnumerator", StringComparison.Ordinal);
                string text;
                if (flag)
                {
                    text = "IEnumerator {0}(...)";
                }
                else
                {
                    text = "{0}(...)";
                }
                return text;
            }

            // Token: 0x060001AA RID: 426 RVA: 0x000166E4 File Offset: 0x000148E4
            public override string Expand()
            {
                string text = "";
                bool flag = _bg8._BBB && _ba9._AHZ.Count > 0;
                if (flag)
                {
                    string text2 = typeof(_yg8).Name + "." + this._AW;
                    bool flag2 = _ba9._AHZ.TryGetValue(text2, out text) || _bm4._AHZ.TryGetValue(text2, out text);
                    if (flag2)
                    {
                        text = "// " + text + "\n";
                    }
                    else
                    {
                        text = "";
                    }
                }
                string text3 = (_bi6._yf1._yh3() ? "" : "protected ");
                string text4 = "";
                bool flag3 = this._yg9 != null;
                if (flag3)
                {
                    text3 += "new ";
                    bool flag4 = this._yg9._AT == SymbolKind.Method;
                    if (flag4)
                    {
                        text4 = "base." + this._AW + "(";
                        List<_bm1> parameters = this._yg9.GetParameters();
                        string text5 = "";
                        foreach (_bm1 _AGS in parameters)
                        {
                            text4 += text5;
                            text4 += _AGS._AW;
                            text5 = ", ";
                        }
                        text4 += ")";
                        _bh4 _AAH = this._yg9.TypeOf();
                        bool flag5 = _AAH != null && _AAH._AW == "IEnumerator";
                        bool flag6 = flag5;
                        if (flag6)
                        {
                            text4 = "StartCoroutine(" + text4 + ")";
                            bool isCoroutine = this.IsCoroutine;
                            if (isCoroutine)
                            {
                                text4 = "yield return " + text4;
                            }
                        }
                        text4 += ";";
                    }
                }
                return string.Format("{0}{1}{2}{3}{{\n\t{4}$end$\n}}", new object[]
                {
                    text,
                    text3,
                    this._yh1,
                    _bg8._BBC ? " " : "\n",
                    text4
                });
            }

            // Token: 0x060001AB RID: 427 RVA: 0x0001691C File Offset: 0x00014B1C
            public string GetParametersString()
            {
                int num = this._yh1.IndexOf('(');
                return this._yh1.Substring(num + 1, this._yh1.Length - num - 2);
            }

            // Token: 0x1700000C RID: 12
            // (get) Token: 0x060001AC RID: 428 RVA: 0x0001695C File Offset: 0x00014B5C
            public bool IsCoroutine
            {
                get
                {
                    return this._yh1.StartsWith("IEnumerator", StringComparison.Ordinal);
                }
            }

            // Token: 0x040001DE RID: 478
            private static Texture2D _yh2 = InternalEditorUtility.GetIconForFile("fakeScene.unity");

            // Token: 0x040001DF RID: 479
            public _bh4 _yg9;

            // Token: 0x040001E0 RID: 480
            private readonly string _yh1;
        }
    }
}
