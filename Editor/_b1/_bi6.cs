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
            _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM = bodyScope._ACV as _b2;
            bool flag5 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM == null || _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM._AT != SymbolKind.Class;
            if (flag5)
            {
                yield break;
            }
            bool flag6 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.DerivesFrom(_bi6.KNMLPJPCEBLEGAFCAFJMBIPHLMGHKEPEGKCA);
            List<_be5> magicMethods;
            if (flag6)
            {
                magicMethods = _bi6.BCLNBIFDLONNCMAEOCMLNPAEGAPHMANAFPCJ;
            }
            else
            {
                bool flag7 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.DerivesFrom(_bi6.NHIOKJHIBMEJMJDAINIHFLABHPGKEJBOACLI);
                if (flag7)
                {
                    magicMethods = _bi6.MHIBOKCIFPOHOBENNCEFMEFBENHOAHBLPJID;
                }
                else
                {
                    bool flag8 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.DerivesFrom(_bi6.FJNAIDNBCNINJFLBGFJJHFBBKKIIFPIBDIKM);
                    if (flag8)
                    {
                        magicMethods = _bi6.DNFGPIHCLIPBLDDGDDOEPOOBIHKOHINACDJJ;
                    }
                    else
                    {
                        bool flag9 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.DerivesFrom(_bi6.OGNEKKLIBGFAAFICOLGCFLDJDJEGFNLAIBKA);
                        if (flag9)
                        {
                            magicMethods = _bi6.BDNCEEFBLGKFNIDNBNBGOAAHOBFNKKBNEBAG;
                        }
                        else
                        {
                            bool flag10 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.DerivesFrom(_bi6.DMBBNCFAADCJAHGINEIJABDEBEGPGIBMEIIL);
                            if (flag10)
                            {
                                magicMethods = _bi6.AECPDCHJKLBGFPAIAFCFAMLKAKFKAOODDPEO;
                            }
                            else
                            {
                                bool flag11 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.DerivesFrom(_bi6.ODGHFJJGGAAMHMMAHAAKIOMEIEIJJCIJOJOB);
                                if (!flag11)
                                {
                                    yield break;
                                }
                                magicMethods = _bi6.BGBHCPOEMLMBDCLDKFPAAONMDLJEACFNBFLC;
                            }
                        }
                    }
                }
            }
            _b2 baseType = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.BaseType();
            _bb4.DHBA tempLeaf = new _bb4.DHBA
            {
                _ACX = new SyntaxToken(SyntaxToken.Kind.Identifier, "")
            };
            foreach (_be5 magic in magicMethods)
            {
                ((_bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO)magic).BaseSymbol = null;
                bool flag12 = _bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.FindName(magic._AW, -1, false) != null;
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
                            bool flag15 = !baseSymbol.PGIPEAHFGPPKEMGFLHBIMNOONGJMJEFBMIJG();
                            if (flag15)
                            {
                                ((_bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO)magic).BaseSymbol = baseSymbol;
                            }
                            yield return magic;
                        }
                        else
                        {
                            bool yield = true;
                            string magicSignature = ((_bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO)magic).GetParametersString();
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
                                    bool flag18 = !baseMethod.PGIPEAHFGPPKEMGFLHBIMNOONGJMJEFBMIJG();
                                    if (flag18)
                                    {
                                        _b2 returnType = baseMethod.ReturnType();
                                        bool flag19 = returnType == null || returnType._AT == SymbolKind.Error;
                                        if (flag19)
                                        {
                                            ((_bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO)magic).BaseSymbol = asMethodGroup;
                                        }
                                        else
                                        {
                                            bool baseIsCoroutine = returnType._AW == "IEnumerator";
                                            bool returnsVoid = baseMethod.ReturnType() == _bh4._BFU;
                                            bool flag20 = !baseIsCoroutine && !returnsVoid;
                                            if (flag20)
                                            {
                                                ((_bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO)magic).BaseSymbol = asMethodGroup;
                                            }
                                            else
                                            {
                                                ((_bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO)magic).BaseSymbol = baseMethod;
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
            yield break;
        }

        // Token: 0x0600019E RID: 414 RVA: 0x00015BB0 File Offset: 0x00013DB0
        public string Get(string shortcut, _bh4 context, _bh2._AGI expectedTokens, _bm6 scope)
        {
            return null;
        }

        // Token: 0x040001D1 RID: 465
        private static _b2 NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM;

        // Token: 0x040001D2 RID: 466
        private static List<_be5> BCLNBIFDLONNCMAEOCMLNPAEGAPHMANAFPCJ = new List<_be5>
        {
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void Awake()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void Start()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator Start()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void Update()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void LateUpdate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void FixedUpdate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnGUI()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnEnable()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnDisable()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnDestroy()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void Reset()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnValidate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTriggerEnter(Collider other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnTriggerEnter(Collider other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTriggerEnter2D(Collider2D other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnTriggerEnter2D(Collider2D other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTriggerExit(Collider other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnTriggerExit(Collider other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTriggerExit2D(Collider2D other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnTriggerExit2D(Collider2D other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTriggerStay(Collider other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnTriggerStay(Collider other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTriggerStay2D(Collider2D other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnTriggerStay2D(Collider2D other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnCollisionEnter(Collision collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnCollisionEnter(Collision collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnCollisionEnter2D(Collision2D collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnCollisionEnter2D(Collision2D collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnCollisionExit(Collision collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnCollisionExit(Collision collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnCollisionExit2D(Collision2D collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnCollisionExit2D(Collision2D collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnCollisionStay(Collision collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnCollisionStay(Collision collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnCollisionStay2D(Collision2D collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnCollisionStay2D(Collision2D collisionInfo)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnControllerColliderHit(ControllerColliderHit hit)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnJointBreak(float breakForce)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnParticleCollision(GameObject other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnParticleCollision(GameObject other)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseEnter()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseEnter()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseOver()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseOver()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseExit()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseExit()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseDown()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseDown()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseUp()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseUp()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseUpAsButton()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseUpAsButton()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMouseDrag()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnMouseDrag()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnLevelWasLoaded(int level)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnLevelWasLoaded(int level)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnApplicationFocus(bool focus)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnApplicationFocus(bool focus)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnApplicationPause(bool pause)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnApplicationPause(bool pause)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnApplicationQuit()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnBecameVisible()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnBecameVisible()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnBecameInvisible()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnBecameInvisible()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnPreCull()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnPreRender()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnPreRender()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnPostRender()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("IEnumerator OnPostRender()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnRenderObject()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnWillRenderObject()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnRenderImage(RenderTexture source, RenderTexture destination)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnDrawGizmosSelected()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnDrawGizmos()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnPlayerConnected(NetworkPlayer player)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnServerInitialized()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnConnectedToServer()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnPlayerDisconnected(NetworkPlayer player)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnDisconnectedFromServer(NetworkDisconnection info)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnFailedToConnect(NetworkConnectionError error)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnFailedToConnectToMasterServer(NetworkConnectionError info)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnMasterServerEvent(MasterServerEvent msEvent)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnNetworkInstantiate(NetworkMessageInfo info)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnAnimatorIK(int layerIndex)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnAnimatorMove()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void ()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void ()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void ()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnAudioFilterRead(float[] data, int channels)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTransformChildrenChanged()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<MonoBehaviour>("void OnTransformParentChanged()")
        };

        // Token: 0x040001D3 RID: 467
        private static List<_be5> DNFGPIHCLIPBLDDGDDOEPOOBIHKOHINACDJJ = new List<_be5>
        {
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnDestroy()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnFocus()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnGUI()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnHierarchyChange()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnInspectorUpdate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnLostFocus()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnProjectChange()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnSelectionChange()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void Update()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void ShowButton(Rect buttonRect)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnDisable()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D4 RID: 468
        private static List<_be5> BGBHCPOEMLMBDCLDKFPAAONMDLJEACFNBFLC = new List<_be5>
        {
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnDestroy()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnDisable()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D5 RID: 469
        private static List<_be5> MHIBOKCIFPOHOBENNCEFMEFBENHOAHBLPJID = new List<_be5>
        {
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableWizard>("void OnWizardCreate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableWizard>("void OnWizardOtherButton()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableWizard>("void OnWizardUpdate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnDestroy()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnFocus()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnGUI()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnHierarchyChange()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnInspectorUpdate()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnLostFocus()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnProjectChange()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void OnSelectionChange()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EditorWindow>("void Update()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnDisable()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D6 RID: 470
        private static List<_be5> BDNCEEFBLGKFNIDNBNBGOAAHOBFNKKBNEBAG = new List<_be5>
        {
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<Editor>("void OnSceneGUI()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<Editor>("bool RequiresConstantRepaint()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<Editor>("bool UseDefaultMargins()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnDestroy()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnDisable()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<ScriptableObject>("void OnEnable()")
        };

        // Token: 0x040001D7 RID: 471
        private static List<_be5> AECPDCHJKLBGFPAIAFCFAMLKAKFKAOODDPEO = new List<_be5>
        {
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("Material OnAssignMaterialModel(Material material, Renderer renderer)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPostprocessAssetbundleNameChanged(string assetPath, string previousAssetBundleName, string newAssetBundleName)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPostprocessAudio(AudioClip clip)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPostprocessGameObjectWithUserProperties(GameObject go, string[] propNames, object[] values)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPostprocessModel(GameObject root)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPostprocessSpeedTree(GameObject root)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPostprocessTexture(Texture2D texture)"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPreprocessAnimation()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPreprocessAudio()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPreprocessModel()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPreprocessSpeedTree()"),
            new _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<AssetPostprocessor>("void OnPreprocessTexture()")
        };

        // Token: 0x040001D8 RID: 472
        private static _b2 KNMLPJPCEBLEGAFCAFJMBIPHLMGHKEPEGKCA = _bl9.ForType(typeof(MonoBehaviour)).definition as _b2;

        // Token: 0x040001D9 RID: 473
        private static _b2 FJNAIDNBCNINJFLBGFJJHFBBKKIIFPIBDIKM = _bl9.ForType(typeof(EditorWindow)).definition as _b2;

        // Token: 0x040001DA RID: 474
        private static _b2 NHIOKJHIBMEJMJDAINIHFLABHPGKEJBOACLI = _bl9.ForType(typeof(ScriptableWizard)).definition as _b2;

        // Token: 0x040001DB RID: 475
        private static _b2 ODGHFJJGGAAMHMMAHAAKIOMEIEIJJCIJOJOB = _bl9.ForType(typeof(ScriptableObject)).definition as _b2;

        // Token: 0x040001DC RID: 476
        private static _b2 OGNEKKLIBGFAAFICOLGCFLDJDJEGFNLAIBKA = _bl9.ForType(typeof(Editor)).definition as _b2;

        // Token: 0x040001DD RID: 477
        private static _b2 DMBBNCFAADCJAHGINEIJABDEBEGPGIBMEIIL = _bl9.ForType(typeof(AssetPostprocessor)).definition as _b2;

        // Token: 0x0200003A RID: 58
        private interface DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO
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
        private class LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EMMOKJIALCDEJMEOGHNAEBCAAAKCAIBHHENP> : _be5, _bi6.DDEFKBNENLCPKJBKGBPJNMHEHFFHMNDKNJCO
        {
            // Token: 0x1700000B RID: 11
            // (get) Token: 0x060001A5 RID: 421 RVA: 0x00016620 File Offset: 0x00014820
            // (set) Token: 0x060001A6 RID: 422 RVA: 0x00016638 File Offset: 0x00014838
            public _bh4 BaseSymbol
            {
                get
                {
                    return this.NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA;
                }
                set
                {
                    this.NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA = value;
                }
            }

            // Token: 0x060001A7 RID: 423 RVA: 0x00016642 File Offset: 0x00014842
            public LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ(string methodSignature)
                : base(_bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EMMOKJIALCDEJMEOGHNAEBCAAAKCAIBHHENP>.GetMethodName(methodSignature))
            {
                this._AWF = _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EMMOKJIALCDEJMEOGHNAEBCAAAKCAIBHHENP>.GetDisplayName(methodSignature);
                this.NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ = methodSignature;
                this._AFG = _bi6.LDDCOKGJBJBGCODMFHHFGGMNLMAPPKKAIKDJ<EMMOKJIALCDEJMEOGHNAEBCAAAKCAIBHHENP>.NNCDIJLMJLKLJNBGOFLGIFJHJHOOCCHBGONB;
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
                    string text2 = typeof(EMMOKJIALCDEJMEOGHNAEBCAAAKCAIBHHENP).Name + "." + this._AW;
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
                string text3 = (_bi6.NAMBPNJECIKOADMPEBEDLODIOGMEIOICKKPM.CCHFDEPNIEOKILOEBJANDNGJDJMHMHJHAEEC() ? "" : "protected ");
                string text4 = "";
                bool flag3 = this.NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA != null;
                if (flag3)
                {
                    text3 += "new ";
                    bool flag4 = this.NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA._AT == SymbolKind.Method;
                    if (flag4)
                    {
                        text4 = "base." + this._AW + "(";
                        List<_bm1> parameters = this.NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA.GetParameters();
                        string text5 = "";
                        foreach (_bm1 _AGS in parameters)
                        {
                            text4 += text5;
                            text4 += _AGS._AW;
                            text5 = ", ";
                        }
                        text4 += ")";
                        _bh4 _AAH = this.NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA.TypeOf();
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
                    this.NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ,
                    _bg8._BBC ? " " : "\n",
                    text4
                });
            }

            // Token: 0x060001AB RID: 427 RVA: 0x0001691C File Offset: 0x00014B1C
            public string GetParametersString()
            {
                int num = this.NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ.IndexOf('(');
                return this.NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ.Substring(num + 1, this.NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ.Length - num - 2);
            }

            // Token: 0x1700000C RID: 12
            // (get) Token: 0x060001AC RID: 428 RVA: 0x0001695C File Offset: 0x00014B5C
            public bool IsCoroutine
            {
                get
                {
                    return this.NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ.StartsWith("IEnumerator", StringComparison.Ordinal);
                }
            }

            // Token: 0x040001DE RID: 478
            private static Texture2D NNCDIJLMJLKLJNBGOFLGIFJHJHOOCCHBGONB = InternalEditorUtility.GetIconForFile("fakeScene.unity");

            // Token: 0x040001DF RID: 479
            public _bh4 NKBLMHPNICNKOCCMJJKFAHNNABPEHFLBFEOA;

            // Token: 0x040001E0 RID: 480
            private readonly string NGNIIHMGMOJHGHBBOHAHCFFEHIOGDHJBJHGJ;
        }
    }
}
