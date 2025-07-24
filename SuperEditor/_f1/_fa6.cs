using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

namespace ODGL
{
    // Token: 0x02000144 RID: 324
    internal class _fa6 : _fa7
    {
        // Token: 0x0600096E RID: 2414 RVA: 0x00100B70 File Offset: 0x000FED70
        internal _fa6()
        {
            this.KIBC = _fa2.GetInstance().GetTexture((_f2)8);
            this.GDDH = _fa2.GetInstance().GetTexture((_f2)7);
            this.NKCO = _fa2.GetInstance().GetColor((_f8)1);
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorIconParent, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorIconReferenceIsNull, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorIconStringIsEmpty, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorIconScriptIsMissing, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorForDisabledComponents, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorIconMissingEventMethod, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorIconWhenTagOrLayerIsUndefined, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.ShowErrorComponent, new SettingChangedHandler(this.SettingsChanged));
            _f5.GetInstance().AddEventListener(HierarchySetting.IgnoreErrorOfMonoBehaviours, new SettingChangedHandler(this.SettingsChanged));
            this.SettingsChanged();
        }

        // Token: 0x0600096F RID: 2415 RVA: 0x00100CAC File Offset: 0x000FEEAC
        private void SettingsChanged()
        {
            this.MKFN = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorIconParent);
            this.GHNJ = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorIconReferenceIsNull);
            this.IBDK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorIconStringIsEmpty);
            this.MAGC = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorIconScriptIsMissing);
            this.AAPI = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorForDisabledComponents);
            this.CPGL = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorIconMissingEventMethod);
            this.CJMF = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorIconWhenTagOrLayerIsUndefined);
            this.HHIK = _f5.GetInstance().Get<bool>(HierarchySetting.ShowErrorComponent);
            string text = _f5.GetInstance().Get<string>(HierarchySetting.IgnoreErrorOfMonoBehaviours);
            bool flag = text != "";
            if (flag)
            {
                this.OCPE = new List<string>(text.Split(new char[] { ',', ';', '.', ' ' }));
                this.OCPE.RemoveAll((string item) => item == "");
            }
            else
            {
                this.OCPE = null;
            }
        }

        // Token: 0x06000970 RID: 2416 RVA: 0x00100DC0 File Offset: 0x000FEFC0
        internal override void Layout(GameObject gameObject, _fb5 objectList, ref Rect rect)
        {
            bool flag = _fa6.CBIJ == null;
            if (!flag)
            {
                rect.x -= 16f;
                rect.width = 16f;
            }
        }

        // Token: 0x06000971 RID: 2417 RVA: 0x00100E00 File Offset: 0x000FF000
        internal override void Draw(GameObject gameObject, _fb5 objectList, Rect selectionRect, Rect curRect)
        {
            bool flag = this.FindError(gameObject, gameObject.GetComponents<MonoBehaviour>(), false);
            bool flag2 = flag;
            if (flag2)
            {
                GUI.DrawTexture(curRect, this.KIBC);
                _fa6.CBIJ = gameObject;
            }
            else
            {
                bool mkfn = this.MKFN;
                if (mkfn)
                {
                    flag = this.FindError(gameObject, gameObject.GetComponentsInChildren<MonoBehaviour>(true), false);
                    bool flag3 = flag;
                    if (flag3)
                    {
                        GUI.DrawTexture(curRect, this.GDDH);
                        _fa6.CBIJ = gameObject;
                    }
                }
            }
        }

        // Token: 0x06000972 RID: 2418 RVA: 0x00100E74 File Offset: 0x000FF074
        internal override void EventHandler(GameObject gameObject, _fb5 objectList, Event currentEvent, Rect curRect)
        {
            bool flag = currentEvent.isMouse && currentEvent.button == 0 && curRect.Contains(currentEvent.mousePosition);
            if (flag)
            {
                currentEvent.Use();
                this.ADJI = 0;
                this.MJKG = new StringBuilder();
                this.FindError(gameObject, gameObject.GetComponents<MonoBehaviour>(), true);
                bool flag2 = this.ADJI > 0;
                if (flag2)
                {
                    EditorUtility.DisplayDialog(this.ADJI.ToString() + ((this.ADJI == 1) ? " error was found" : " errors were found"), this.MJKG.ToString(), "OK");
                }
            }
        }

        // Token: 0x06000973 RID: 2419 RVA: 0x00100F24 File Offset: 0x000FF124
        private bool FindError(GameObject gameObject, MonoBehaviour[] components, bool printError = false)
        {
            bool cjmf = this.CJMF;
            if (cjmf)
            {
                try
                {
                    gameObject.tag.CompareTo(null);
                }
                catch
                {
                    if (!printError)
                    {
                        return true;
                    }
                    this.AppendErrorLine("Tag is undefined");
                }
                bool flag = LayerMask.LayerToName(gameObject.layer).Equals("");
                if (flag)
                {
                    if (!printError)
                    {
                        return true;
                    }
                    this.AppendErrorLine("Layer is undefined");
                }
            }
            int i = 0;
            while (i < components.Length)
            {
                MonoBehaviour monoBehaviour = components[i];
                bool flag2 = monoBehaviour == null;
                if (flag2)
                {
                    bool magc = this.MAGC;
                    if (magc)
                    {
                        if (!printError)
                        {
                            return true;
                        }
                        this.AppendErrorLine("Component #" + i.ToString() + " is missing");
                    }
                }
                else
                {
                    bool flag3 = this.OCPE != null;
                    if (flag3)
                    {
                        for (int j = this.OCPE.Count - 1; j >= 0; j--)
                        {
                            bool flag4 = monoBehaviour.GetType().FullName.Contains(this.OCPE[j]);
                            if (flag4)
                            {
                                return false;
                            }
                        }
                    }
                    bool cpgl = this.CPGL;
                    if (cpgl)
                    {
                        bool flag5 = monoBehaviour.gameObject.activeSelf || this.AAPI;
                        if (flag5)
                        {
                            try
                            {
                                bool flag6 = this.IsUnityEventsNullOrMissing(monoBehaviour, printError);
                                if (flag6)
                                {
                                    return true;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    bool flag7 = this.GHNJ || this.IBDK;
                    if (flag7)
                    {
                        bool flag8 = (!monoBehaviour.enabled || !monoBehaviour.gameObject.activeSelf) && !this.AAPI;
                        if (!flag8)
                        {
                            FieldInfo[] fields = monoBehaviour.GetType().GetFields();
                            int k = 0;
                            while (k < fields.Length)
                            {
                                FieldInfo fieldInfo = fields[k];
                                try
                                {
                                    bool flag9 = Attribute.IsDefined(fieldInfo, typeof(HideInInspector)) || fieldInfo.IsStatic;
                                    if (!flag9)
                                    {
                                        object value = fieldInfo.GetValue(monoBehaviour);
                                        bool flag10 = this.GHNJ && (value == null || value.Equals(null));
                                        if (flag10)
                                        {
                                            if (!printError)
                                            {
                                                return true;
                                            }
                                            this.AppendErrorLine(monoBehaviour.GetType().Name + "." + fieldInfo.Name + ": Reference is null");
                                        }
                                        else
                                        {
                                            bool flag11 = fieldInfo.FieldType == typeof(string);
                                            if (flag11)
                                            {
                                                bool flag12 = this.IBDK && value != null && ((string)value).Equals("");
                                                if (flag12)
                                                {
                                                    if (!printError)
                                                    {
                                                        return true;
                                                    }
                                                    this.AppendErrorLine(monoBehaviour.GetType().Name + "." + fieldInfo.Name + ": String value is empty");
                                                }
                                            }
                                            else
                                            {
                                                bool flag13 = this.GHNJ && value is IEnumerable;
                                                if (flag13)
                                                {
                                                    foreach (object obj in ((IEnumerable)value))
                                                    {
                                                        bool flag14 = obj == null;
                                                        if (flag14)
                                                        {
                                                            if (!printError)
                                                            {
                                                                return true;
                                                            }
                                                            this.AppendErrorLine(monoBehaviour.GetType().Name + "." + fieldInfo.Name + ": IEnumerable has value with null reference");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                                k++;
                            }
                        }
                    }
                }
                i++;

            }
            return false;
        }

        // Token: 0x06000974 RID: 2420 RVA: 0x0010138C File Offset: 0x000FF58C
        private bool IsUnityEventsNullOrMissing(MonoBehaviour monoBehaviour, bool printError)
        {
            this.EGMH.Clear();
            FieldInfo[] fields = monoBehaviour.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            for (int i = fields.Length - 1; i >= 0; i--)
            {
                FieldInfo fieldInfo = fields[i];
                bool flag = fieldInfo.FieldType == typeof(UnityEvent) || fieldInfo.FieldType.IsSubclassOf(typeof(UnityEvent));
                if (flag)
                {
                    this.EGMH.Add(fieldInfo.Name);
                }
            }
            bool flag2 = this.EGMH.Count > 0;
            if (flag2)
            {
                SerializedObject serializedObject = new SerializedObject(monoBehaviour);
                for (int j = this.EGMH.Count - 1; j >= 0; j--)
                {
                    string text = this.EGMH[j];
                    SerializedProperty serializedProperty = serializedObject.FindProperty(text);
                    SerializedProperty serializedProperty2 = serializedProperty.FindPropertyRelative("m_PersistentCalls.m_Calls");
                    for (int k = serializedProperty2.arraySize - 1; k >= 0; k--)
                    {
                        SerializedProperty arrayElementAtIndex = serializedProperty2.GetArrayElementAtIndex(k);
                        SerializedProperty serializedProperty3 = arrayElementAtIndex.FindPropertyRelative("m_Target");
                        bool flag3 = serializedProperty3.objectReferenceValue == null;
                        if (flag3)
                        {
                            if (!printError)
                            {
                                return true;
                            }
                            this.AppendErrorLine(monoBehaviour.GetType().Name + ": Event object reference is null");
                        }
                        SerializedProperty serializedProperty4 = arrayElementAtIndex.FindPropertyRelative("m_MethodName");
                        bool flag4 = string.IsNullOrEmpty(serializedProperty4.stringValue);
                        if (flag4)
                        {
                            if (!printError)
                            {
                                return true;
                            }
                            this.AppendErrorLine(monoBehaviour.GetType().Name + ": Event handler function is not selected");
                        }
                        else
                        {
                            string stringValue = arrayElementAtIndex.FindPropertyRelative("m_Arguments").FindPropertyRelative("m_ObjectArgumentAssemblyTypeName").stringValue;
                            bool flag5 = !string.IsNullOrEmpty(stringValue);
                            Type type;
                            if (flag5)
                            {
                                type = Type.GetType(stringValue, false) ?? typeof(Object);
                            }
                            else
                            {
                                type = typeof(Object);
                            }
                            Type type2 = Type.GetType(serializedProperty.FindPropertyRelative("m_TypeName").stringValue, false);
                            bool flag6 = type2 == null;
                            UnityEventBase unityEventBase;
                            if (flag6)
                            {
                                unityEventBase = new UnityEvent();
                            }
                            else
                            {
                                unityEventBase = Activator.CreateInstance(type2) as UnityEventBase;
                            }
                            bool flag7 = !UnityEventDrawer.IsPersistantListenerValid(unityEventBase, serializedProperty4.stringValue, serializedProperty3.objectReferenceValue, arrayElementAtIndex.FindPropertyRelative("m_Mode").enumValueIndex, type);
                            if (flag7)
                            {
                                if (!printError)
                                {
                                    return true;
                                }
                                this.AppendErrorLine(monoBehaviour.GetType().Name + ": Event handler function is missing");
                            }
                        }
                    }
                }
            }
            return false;
        }

        // Token: 0x06000975 RID: 2421 RVA: 0x00101664 File Offset: 0x000FF864
        private void AppendErrorLine(string error)
        {
            this.ADJI++;
            this.MJKG.Append(this.ADJI.ToString());
            this.MJKG.Append(") ");
            this.MJKG.AppendLine(error);
        }

        // Token: 0x04000811 RID: 2065
        private Texture2D KIBC;

        // Token: 0x04000812 RID: 2066
        private Texture2D GDDH;

        // Token: 0x04000813 RID: 2067
        private Color NKCO;

        // Token: 0x04000814 RID: 2068
        private bool MKFN;

        // Token: 0x04000815 RID: 2069
        private bool GHNJ;

        // Token: 0x04000816 RID: 2070
        private bool IBDK;

        // Token: 0x04000817 RID: 2071
        private bool MAGC;

        // Token: 0x04000818 RID: 2072
        private bool CJMF;

        // Token: 0x04000819 RID: 2073
        private bool AAPI;

        // Token: 0x0400081A RID: 2074
        private bool CPGL;

        // Token: 0x0400081B RID: 2075
        private List<string> OCPE;

        // Token: 0x0400081C RID: 2076
        private StringBuilder MJKG;

        // Token: 0x0400081D RID: 2077
        private int ADJI;

        // Token: 0x0400081E RID: 2078
        private List<string> EGMH = new List<string>(10);

        // Token: 0x0400081F RID: 2079
        private static GameObject CBIJ;

        // Token: 0x04000820 RID: 2080
        private static bool CDHE;
    }
}
