using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AHO;
using SuperEditor;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

namespace FEOCJICFPEHKGMMCGOCFIOPPOJIAOLJNEKNO
{
    // Token: 0x02000169 RID: 361
    [InitializeOnLoad]
    [CustomPropertyDrawer(typeof(UnityEventBase), true)]
    internal class _c3 : UnityEventDrawer
    {
        // Token: 0x060009F9 RID: 2553 RVA: 0x0010B04C File Offset: 0x0010924C
        static _c3()
        {
            bool isPlayingOrWillChangePlaymode = EditorApplication.isPlayingOrWillChangePlaymode;
            if (isPlayingOrWillChangePlaymode)
            {
                _c3.Initialize();
            }
            else
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_c3.Initialize));
            }
        }

        // Token: 0x060009FA RID: 2554 RVA: 0x0010B098 File Offset: 0x00109298
        private static void Initialize()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_c3.Initialize));
            Type type = typeof(UnityEventDrawer).Assembly.GetType("UnityEditor.ScriptAttributeUtility");
            bool flag = type == null;
            if (!flag)
            {
                FieldInfo field = type.GetField("s_DrawerTypeForType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                bool flag2 = field == null;
                if (!flag2)
                {
                    IDictionary dictionary = field.GetValue(null) as IDictionary;
                    bool flag3 = dictionary == null;
                    if (flag3)
                    {
                        MethodInfo method = type.GetMethod("BuildDrawerTypeForTypeDictionary", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        bool flag4 = method == null;
                        if (flag4)
                        {
                            return;
                        }
                        method.Invoke(null, null);
                        dictionary = field.GetValue(null) as IDictionary;
                        bool flag5 = dictionary == null;
                        if (flag5)
                        {
                            return;
                        }
                    }
                    Type type2 = typeof(UnityEventDrawer).Assembly.GetType("UnityEditor.ScriptAttributeUtility+DrawerKeySet");
                    bool flag6 = type2 == null;
                    if (!flag6)
                    {
                        FieldInfo field2 = type2.GetField("drawer", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        FieldInfo field3 = type2.GetField("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        bool flag7 = field == null || field3 == null;
                        if (!flag7)
                        {
                            Type typeFromHandle = typeof(_c3);
                            Type typeFromHandle2 = typeof(UnityEventBase);
                            Type typeFromHandle3 = typeof(UnityEventDrawer);
                            for (; ; )
                            {
                            IL_015B:
                                foreach (object obj in dictionary)
                                {
                                    DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
                                    Type type3 = dictionaryEntry.Key as Type;
                                    object value = dictionaryEntry.Value;
                                    bool flag8 = typeFromHandle2.IsAssignableFrom(type3);
                                    if (flag8)
                                    {
                                        Type type4 = field2.GetValue(value) as Type;
                                        bool flag9 = type4 == typeFromHandle3;
                                        if (flag9)
                                        {
                                            field2.SetValue(value, typeFromHandle);
                                            dictionary[type3] = value;
                                            goto IL_015B;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060009FB RID: 2555 RVA: 0x0010B2B4 File Offset: 0x001094B4
        protected override void DrawEventHeader(Rect headerRect)
        {
            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            headerRect.xMin += 10f;
            bool flag = this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG != null;
            if (flag)
            {
                bool flag2 = this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG.GetType().ToString() == "UnityEngine.EventSystems.EventTrigger+TriggerEvent";
                if (flag2)
                {
                    headerRect.xMax -= 20f;
                }
                _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = "";
                _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.tooltip = "";
                this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL = EditorGUI.Foldout(headerRect, this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL, _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, true);
                int persistentEventCount = this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG.GetPersistentEventCount();
                _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = persistentEventCount.ToString();
                Vector2 vector = EditorStyles.label.CalcSize(_c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM);
                Rect rect = headerRect;
                headerRect.xMax -= vector.x + 4f;
                bool flag3 = Event.current.type == 7;
                if (flag3)
                {
                    rect.xMin = rect.xMax - vector.x;
                    EditorStyles.label.Draw(rect, _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM, false, false, false, false);
                }
            }
            base.DrawEventHeader(headerRect);
            EditorGUI.indentLevel = indentLevel;
        }

        // Token: 0x060009FC RID: 2556 RVA: 0x0010B400 File Offset: 0x00109600
        protected bool InitializeForProperty(SerializedProperty property)
        {
            bool flag = this.HCOLMCFNGFHPBHCNLDDOBKAKNCFAHBMJLEFP == null;
            if (flag)
            {
                this.HCOLMCFNGFHPBHCNLDDOBKAKNCFAHBMJLEFP = typeof(UnityEventDrawer).GetMethod("RestoreState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                this.JCDCMEMFNHOAHJHIGEOAINCAEPKIMBFEBGLL = typeof(UnityEventDrawer).GetField("m_ReorderableList", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                this.MHFODCCKJOIIFCPECNHEPFPENCFBMJAJMJMK = typeof(UnityEventDrawer).GetField("m_DummyEvent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                this.HGHCOKJCDDJMOJGJIOOIFHDGLIEIDJMLPCKB = typeof(UnityEventDrawer).GetField("m_Text", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                this.LEJDNGKEKFIJOGNPCPGJCIKNLPDGMPHJFAOP = Type.GetType("UnityEngine.Events.PersistentCall,UnityEngine");
                bool flag2 = this.LEJDNGKEKFIJOGNPCPGJCIKNLPDGMPHJFAOP != null;
                if (flag2)
                {
                    this.ECHKCMCGCNBGJJBHLEPCIHICPIIGDKFPBENC = typeof(UnityEventBase).GetMethod("FindMethod", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { this.LEJDNGKEKFIJOGNPCPGJCIKNLPDGMPHJFAOP }, null);
                    this.GNODCIGDEILAGFDDMMNLOOGBJAG_AWMFGGDE = Type.GetType("UnityEngine.Events.PersistentCallGroup,UnityEngine");
                    bool flag3 = this.GNODCIGDEILAGFDDMMNLOOGBJAG_AWMFGGDE != null;
                    if (flag3)
                    {
                        this.MOIPDOAAAABPAACGCBMONLEHGJJCOBHOOINH = this.GNODCIGDEILAGFDDMMNLOOGBJAG_AWMFGGDE.GetMethod("GetListener", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    }
                    this.NKKKGIKOALPNCFHOLKJAFHGIDNFELFBPLICG = typeof(UnityEventBase).GetField("m_PersistentCalls", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    this.NPBBCKMKLKPJAIPBPLKAJFPDFEKLEJFOCEHF = typeof(UnityEventDrawer).GetField("m_ListenersArray", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    this.KFCOCJOLIHLABAPHNFDBLKFLMIEBCAEGAJFI = typeof(UnityEventBase).GetMethod("RebuildPersistentCallsIfNeeded", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
                }
            }
            bool flag4 = this.HCOLMCFNGFHPBHCNLDDOBKAKNCFAHBMJLEFP == null || this.JCDCMEMFNHOAHJHIGEOAINCAEPKIMBFEBGLL == null || this.ECHKCMCGCNBGJJBHLEPCIHICPIIGDKFPBENC == null || this.MOIPDOAAAABPAACGCBMONLEHGJJCOBHOOINH == null || this.NKKKGIKOALPNCFHOLKJAFHGIDNFELFBPLICG == null || this.NPBBCKMKLKPJAIPBPLKAJFPDFEKLEJFOCEHF == null || this.KFCOCJOLIHLABAPHNFDBLKFLMIEBCAEGAJFI == null;
            bool flag5;
            if (flag4)
            {
                flag5 = false;
            }
            else
            {
                this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL = property.isExpanded;
                this.HCOLMCFNGFHPBHCNLDDOBKAKNCFAHBMJLEFP.Invoke(this, new object[] { property });
                ReorderableList reorderableList = this.JCDCMEMFNHOAHJHIGEOAINCAEPKIMBFEBGLL.GetValue(this) as ReorderableList;
                bool flag6 = reorderableList == null;
                if (flag6)
                {
                    flag5 = false;
                }
                else
                {
                    bool flag7 = this.MEHPOJFCHBNKIOIOMPCIKMICIBMCEEDDEAMH == null || this.MEHPOJFCHBNKIOIOMPCIKMICIBMCEEDDEAMH.Target == null;
                    if (flag7)
                    {
                        this.MEHPOJFCHBNKIOIOMPCIKMICIBMCEEDDEAMH = reorderableList.drawElementCallback;
                    }
                    reorderableList.drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.DrawEventListener);
                    this.IEMMAMAHFFGLDFIOMMALNHDMLMPALJCOGOHO = this.NPBBCKMKLKPJAIPBPLKAJFPDFEKLEJFOCEHF.GetValue(this) as SerializedProperty;
                    bool flag8 = this.IEMMAMAHFFGLDFIOMMALNHDMLMPALJCOGOHO != null && !this.IEMMAMAHFFGLDFIOMMALNHDMLMPALJCOGOHO.isArray;
                    if (flag8)
                    {
                        this.IEMMAMAHFFGLDFIOMMALNHDMLMPALJCOGOHO = null;
                    }
                    object obj = property.serializedObject.targetObject;
                    this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL = null;
                    string[] array = property.propertyPath.Split(this.GFKIBCELJHDFBIJCGEDLLBHFJMBHAGOGCDDA, StringSplitOptions.RemoveEmptyEntries);
                    int num = 0;
                    while (obj != null && num < array.Length)
                    {
                        bool flag9 = array[num] == "Array";
                        if (flag9)
                        {
                            this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL = null;
                            IList list = obj as IList;
                            bool flag10 = list == null;
                            if (flag10)
                            {
                                break;
                            }
                            int num2 = int.Parse(array[num += 2]);
                            bool flag11 = num2 >= list.Count;
                            if (flag11)
                            {
                                break;
                            }
                            obj = list[num2];
                        }
                        else
                        {
                            Type type = obj.GetType();
                            while (type != typeof(object))
                            {
                                this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL = type.GetField(array[num], BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                                bool flag12 = this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL != null;
                                if (flag12)
                                {
                                    break;
                                }
                                type = type.BaseType;
                            }
                            bool flag13 = this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL == null;
                            if (flag13)
                            {
                                Debug.LogWarning(string.Concat(new string[]
                                {
                                    "Could not find field #",
                                    num.ToString(),
                                    " in type ",
                                    obj.GetType().FullName,
                                    "\n",
                                    string.Join(", ", array)
                                }));
                                obj = null;
                                break;
                            }
                            obj = this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL.GetValue(obj);
                        }
                        num++;
                    }
                    this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG = obj as UnityEventBase;
                    flag5 = true;
                }
            }
            return flag5;
        }

        // Token: 0x060009FD RID: 2557 RVA: 0x0010B840 File Offset: 0x00109A40
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            bool flag = !this.InitializeForProperty(property);
            float num;
            if (flag)
            {
                num = base.GetPropertyHeight(property, label);
            }
            else
            {
                float propertyHeight = base.GetPropertyHeight(property, label);
                num = (property.isExpanded ? propertyHeight : 16f);
            }
            return num;
        }

        // Token: 0x060009FE RID: 2558 RVA: 0x0010B884 File Offset: 0x00109A84
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool flag = !this.InitializeForProperty(property);
            if (flag)
            {
                base.OnGUI(position, property, label);
            }
            else
            {
                this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL = property.isExpanded;
                bool flag2 = !this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL;
                if (flag2)
                {
                    position.height = 16f;
                }
                bool flag3 = this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL || this.MHFODCCKJOIIFCPECNHEPFPENCFBMJAJMJMK == null || this.HGHCOKJCDDJMOJGJIOOIFHDGLIEIDJMLPCKB == null;
                if (flag3)
                {
                    base.OnGUI(position, property, label);
                }
                else
                {
                    bool flag4 = this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG != null;
                    if (flag4)
                    {
                        bool flag5 = Event.current.type == 7;
                        if (flag5)
                        {
                            this.HNNPIDINLKJHIBEFFDJBLGACBGDHIPHJBHOF.Draw(position, false, false, false, false);
                        }
                        this.MHFODCCKJOIIFCPECNHEPFPENCFBMJAJMJMK.SetValue(this, this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG);
                        this.HGHCOKJCDDJMOJGJIOOIFHDGLIEIDJMLPCKB.SetValue(this, label.text);
                        Rect rect = position;
                        rect.xMin += 6f;
                        rect.xMax -= 6f;
                        rect.height -= 2f;
                        float y = rect.y;
                        rect.y = y + 1f;
                        this.DrawEventHeader(rect);
                    }
                }
                property.isExpanded = this.CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL;
                bool flag6 = this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL != null;
                if (flag6)
                {
                    bool flag7 = Attribute.IsDefined(this.FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL, typeof(TooltipAttribute));
                    if (flag7)
                    {
                        TooltipAttribute tooltipAttribute = (TooltipAttribute)Attribute.GetCustomAttribute(base.fieldInfo, typeof(TooltipAttribute));
                        bool flag8 = tooltipAttribute.tooltip != "";
                        if (flag8)
                        {
                            position.height = 18f;
                            _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.text = "";
                            _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM.tooltip = tooltipAttribute.tooltip;
                            GUI.Label(position, _c3.FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM);
                        }
                    }
                }
            }
        }

        // Token: 0x060009FF RID: 2559 RVA: 0x0010BA80 File Offset: 0x00109C80
        private void DrawEventListener(Rect rect, int index, bool isactive, bool isfocused)
        {
            SerializedProperty arrayElementAtIndex = this.IEMMAMAHFFGLDFIOMMALNHDMLMPALJCOGOHO.GetArrayElementAtIndex(index);
            SerializedProperty serializedProperty = arrayElementAtIndex.FindPropertyRelative("m_MethodName");
            bool flag = !string.IsNullOrEmpty(serializedProperty.stringValue);
            MethodInfo methodInfo = null;
            bool flag2 = flag && this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG != null;
            if (flag2)
            {
                try
                {
                    this.KFCOCJOLIHLABAPHNFDBLKFLMIEBCAEGAJFI.Invoke(this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG, null);
                }
                catch
                {
                }
                this.KKPJPAPEIMLEICOAGHCMACCFLKFHNBDJPGGF = this.NKKKGIKOALPNCFHOLKJAFHGIDNFELFBPLICG.GetValue(this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG);
                object obj = this.MOIPDOAAAABPAACGCBMONLEHGJJCOBHOOINH.Invoke(this.KKPJPAPEIMLEICOAGHCMACCFLKFHNBDJPGGF, new object[] { index });
                methodInfo = this.ECHKCMCGCNBGJJBHLEPCIHICPIIGDKFPBENC.Invoke(this.DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG, new object[] { obj }) as MethodInfo;
                flag = false;
                bool flag3 = methodInfo != null;
                if (flag3)
                {
                    Type declaringType = methodInfo.DeclaringType;
                    bool flag4 = declaringType != null;
                    if (flag4)
                    {
                        string text = declaringType.Assembly.GetName().Name.ToLowerInvariant();
                        flag = text == "assembly-csharp" || text == "assembly-csharp-firstpass" || text == "assembly-csharp-editor" || text == "assembly-csharp-editor-firstpass";
                    }
                }
            }
            bool flag5 = Event.current.type == null && Event.current.clickCount == 2 && rect.Contains(Event.current.mousePosition);
            Rect rect2 = rect;
            rect2.y += 3f;
            rect2.height = 15f;
            rect2.xMin = rect2.xMax - 21f;
            rect2.width = 21f;
            rect.width -= 20f;
            bool flag6 = this.MEHPOJFCHBNKIOIOMPCIKMICIBMCEEDDEAMH != null;
            if (flag6)
            {
                this.MEHPOJFCHBNKIOIOMPCIKMICIBMCEEDDEAMH.Invoke(rect, index, isactive, isfocused);
            }
            bool flag7 = isactive && isfocused && Event.current.type == 4 && Event.current.character == '\n';
            if (flag7)
            {
                flag5 = true;
            }
            bool enabled = GUI.enabled;
            GUI.enabled = flag;
            bool flag8 = GUI.Button(rect2, "...", EditorStyles.miniButtonRight);
            bool flag9 = flag && (flag8 || (flag5 && Event.current.type != 12));
            if (flag9)
            {
                _bh4 definition = _bl9.ForType(methodInfo.DeclaringType).definition;
                bool flag10 = definition != null;
                if (flag10)
                {
                    _bh4 _AAH = definition.FindName(methodInfo.IsSpecialName ? methodInfo.Name.Substring("set_".Length) : methodInfo.Name, 0, false);
                    bool flag11 = _AAH != null;
                    if (flag11)
                    {
                        List<FKI> list = null;
                        _ba7 _AAK = _AAH as _ba7;
                        bool flag12 = _AAH._AT == SymbolKind.MethodGroup && _AAK != null;
                        if (flag12)
                        {
                            ParameterInfo[] parameters = methodInfo.GetParameters();
                            using (List<_bb3>.Enumerator enumerator = _AAK._AAM.GetEnumerator())
                            {
                            IL_03FF:
                                while (enumerator.MoveNext())
                                {
                                    _bb3 _AAN = enumerator.Current;
                                    bool isStatic = _AAN.IsStatic;
                                    if (!isStatic)
                                    {
                                        List<_bm1> list2 = _AAN.GetParameters() ?? new List<_bm1>();
                                        bool flag13 = list2.Count != parameters.Length;
                                        if (!flag13)
                                        {
                                            int count = list2.Count;
                                            while (count-- > 0)
                                            {
                                                _bh4 _AAH2 = list2[count].TypeOf();
                                                bool flag14 = _AAH2 == null;
                                                if (!flag14)
                                                {
                                                    _b2 _AAC = _bl9.ForType(parameters[count].ParameterType).definition as _b2;
                                                    bool flag15 = !_AAH2.IsSameType(_AAC);
                                                    if (!flag15)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                goto IL_03FF;
                                            }
                                            list = _AAN._AEI;
                                            bool flag16 = list == null || list.Count == 0;
                                            if (flag16)
                                            {
                                                list = _bh6.FindDeclarations(_AAN);
                                                bool flag17 = list == null || list.Count == 0;
                                                if (flag17)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            list = _AAH._AEI;
                            bool flag18 = list == null || list.Count == 0;
                            if (flag18)
                            {
                                list = _bh6.FindDeclarations(_AAH);
                            }
                        }
                        bool flag19 = list != null && list.Count > 0;
                        if (flag19)
                        {
                            foreach (FKI _AFF in list)
                            {
                                _bb4._AIN _AIO = _AFF.NameNode();
                                bool flag20 = _AIO == null || !_AIO.HasLeafs();
                                if (!flag20)
                                {
                                    string cuPath = null;
                                    for (_bm6 _AQI = _AFF._AJW; _AQI != null; _AQI = _AQI._AMJ())
                                    {
                                        _be7 hebiehngcbipegicgdnhcaaoamfabehlcmkf = _AQI as _be7;
                                        bool flag21 = hebiehngcbipegicgdnhcaaoamfabehlcmkf != null;
                                        if (flag21)
                                        {
                                            cuPath = hebiehngcbipegicgdnhcaaoamfabehlcmkf._AWJ;
                                            break;
                                        }
                                    }
                                    bool flag22 = cuPath == null;
                                    if (!flag22)
                                    {
                                        UnityEngine.Object @object = AssetDatabase.LoadAssetAtPath(cuPath, typeof(MonoScript));
                                        bool flag23 = @object == null;
                                        if (!flag23)
                                        {
                                            GCE buffer = _bc5.GetBuffer(@object);
                                            bool flag24 = buffer == null;
                                            if (!flag24)
                                            {
                                                bool flag25 = buffer.FLOg.Count == 0;
                                                if (flag25)
                                                {
                                                    buffer.LoadImmediately();
                                                }
                                                TextSpan span = buffer.GetParseTreeNodeSpan(_AIO);
                                                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                                                {
                                                    _bb6.OpenAssetInTab(AssetDatabase.AssetPathToGUID(cuPath), span.line + 1);
                                                }));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            GUI.enabled = enabled;
        }

        // Token: 0x0400092D RID: 2349
        [NonSerialized]
        private ReorderableList.ElementCallbackDelegate MEHPOJFCHBNKIOIOMPCIKMICIBMCEEDDEAMH;

        // Token: 0x0400092E RID: 2350
        [NonSerialized]
        private SerializedProperty IEMMAMAHFFGLDFIOMMALNHDMLMPALJCOGOHO;

        // Token: 0x0400092F RID: 2351
        [NonSerialized]
        private UnityEventBase DGGABCKPMNOOMLMCBLMPCNGADOHFLHOMBNBG;

        // Token: 0x04000930 RID: 2352
        private FieldInfo FPANIMICIKBOPALLGOABHNIMKCMBJKJDLAGL;

        // Token: 0x04000931 RID: 2353
        [NonSerialized]
        private object KKPJPAPEIMLEICOAGHCMACCFLKFHNBDJPGGF;

        // Token: 0x04000932 RID: 2354
        private Type LEJDNGKEKFIJOGNPCPGJCIKNLPDGMPHJFAOP;

        // Token: 0x04000933 RID: 2355
        private Type GNODCIGDEILAGFDDMMNLOOGBJAG_AWMFGGDE;

        // Token: 0x04000934 RID: 2356
        private FieldInfo NKKKGIKOALPNCFHOLKJAFHGIDNFELFBPLICG;

        // Token: 0x04000935 RID: 2357
        private FieldInfo NPBBCKMKLKPJAIPBPLKAJFPDFEKLEJFOCEHF;

        // Token: 0x04000936 RID: 2358
        private MethodInfo ECHKCMCGCNBGJJBHLEPCIHICPIIGDKFPBENC;

        // Token: 0x04000937 RID: 2359
        private MethodInfo MOIPDOAAAABPAACGCBMONLEHGJJCOBHOOINH;

        // Token: 0x04000938 RID: 2360
        private MethodInfo HCOLMCFNGFHPBHCNLDDOBKAKNCFAHBMJLEFP;

        // Token: 0x04000939 RID: 2361
        private FieldInfo JCDCMEMFNHOAHJHIGEOAINCAEPKIMBFEBGLL;

        // Token: 0x0400093A RID: 2362
        private MethodInfo KFCOCJOLIHLABAPHNFDBLKFLMIEBCAEGAJFI;

        // Token: 0x0400093B RID: 2363
        private FieldInfo MHFODCCKJOIIFCPECNHEPFPENCFBMJAJMJMK;

        // Token: 0x0400093C RID: 2364
        private FieldInfo HGHCOKJCDDJMOJGJIOOIFHDGLIEIDJMLPCKB;

        // Token: 0x0400093D RID: 2365
        private readonly char[] GFKIBCELJHDFBIJCGEDLLBHFJMBHAGOGCDDA = new char[] { '.', '[', ']' };

        // Token: 0x0400093E RID: 2366
        private static readonly GUIContent FADGCFAIAJEFHCBLKDGGHBGJJNBKJBMIOOEM = new GUIContent();

        // Token: 0x0400093F RID: 2367
        private readonly GUIStyle HNNPIDINLKJHIBEFFDJBLGACBGDHIPHJBHOF = "RL Header";

        // Token: 0x04000940 RID: 2368
        [NonSerialized]
        private bool CJMJBAKOHPGCDGOAJNIAJHBCHCKMLHKJKHNL;
    }
}
