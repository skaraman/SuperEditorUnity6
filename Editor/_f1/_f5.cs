using System;
using System.Collections.Generic;
using SuperEditor.Hierarchy;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ODGL
{
    // Token: 0x0200013E RID: 318
    internal class _f5
    {
        // Token: 0x06000957 RID: 2391 RVA: 0x000FFBC8 File Offset: 0x000FDDC8
        internal static _f5 GetInstance()
        {
            bool flag = _f5._AA == null;
            if (flag)
            {
                _f5._AA = new _f5();
            }
            return _f5._AA;
        }

        // Token: 0x06000958 RID: 2392 RVA: 0x000FFBF8 File Offset: 0x000FDDF8
        private _f5()
        {
            this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH = new Dictionary<int, SettingChangedHandler>();
            this.OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO = new Dictionary<int, object>();
            List<_fb3> list = new List<_fb3>();
            string text = (string)this.GetEditorSetting(HierarchySetting.CustomTagIcon, "");
            string[] array = text.Split(new char[] { ';' });
            List<string> list2 = new List<string>(InternalEditorUtility.tags);
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                string text2 = array[i];
                bool flag = !list2.Contains(text2);
                if (!flag)
                {
                    string text3 = array[i + 1];
                    Texture2D texture2D = (Texture2D)AssetDatabase.LoadAssetAtPath(text3, typeof(Texture2D));
                    bool flag2 = texture2D != null;
                    if (flag2)
                    {
                        _fb3 lkjomimlicoddlgmaleoofiajcjldhdlmaha = new _fb3(text2, texture2D);
                        list.Add(lkjomimlicoddlgmaleoofiajcjldhdlmaha);
                    }
                }
            }
            this.InitSetting(HierarchySetting.ShowVisibility, false);
            this.InitSetting(HierarchySetting.ShowComponents, true);
            this.InitSetting(HierarchySetting.ShowLock, false);
            this.InitSetting(HierarchySetting.ShowGameObjectIcon, false);
            this.InitSetting(HierarchySetting.ShowMonoBehaviourIconComponent, false);
            this.InitSetting(HierarchySetting.ShowTagLayerComponent, false);
            this.InitSetting(HierarchySetting.ShowErrorComponent, false);
            this.InitSetting(HierarchySetting.ShowTagIconComponent, false);
            this.InitSetting(HierarchySetting.ShowStaticComponent, false);
            this.InitSetting(HierarchySetting.ShowRendererComponent, false);
            this.InitSetting(HierarchySetting.ShowSeparatorComponent, false);
            this.InitSetting(HierarchySetting.ShowChildrenCountComponent, false);
            this.InitSetting(HierarchySetting.ShowPrefabComponent, false);
            this.InitSetting(HierarchySetting.ShowErrorIconParent, true);
            this.InitSetting(HierarchySetting.ShowErrorIconScriptIsMissing, true);
            this.InitSetting(HierarchySetting.ShowErrorIconReferenceIsNull, true);
            this.InitSetting(HierarchySetting.ShowErrorIconStringIsEmpty, true);
            this.InitSetting(HierarchySetting.ShowErrorIconMissingEventMethod, true);
            this.InitSetting(HierarchySetting.ShowErrorIconWhenTagOrLayerIsUndefined, true);
            this.InitSetting(HierarchySetting.IgnoreErrorOfMonoBehaviours, "");
            this.InitSetting(HierarchySetting.TagAndLayerType, 1);
            this.InitSetting(HierarchySetting.TagAndLayerAligment, 0);
            this.InitSetting(HierarchySetting.TagAndLayerSizeValueType, 0);
            this.InitSetting(HierarchySetting.TagAndLayerSizeValuePercent, 0.25f);
            this.InitSetting(HierarchySetting.TagAndLayerSizeValuePixel, 75);
            this.InitSetting(HierarchySetting.TagAndLayerLabelSize, 0);
            this.InitSetting(HierarchySetting.ComponentOrder, "0;1;2;3;4;5;6;7;8");
            this.InitSetting(HierarchySetting.Identation, 0);
            this.InitSetting(HierarchySetting.CustomTagIcon, list);
            this.InitSetting(HierarchySetting.PreventSelectionOfLockedObjects, false);
            this.InitSetting(HierarchySetting.ShowHiddenObjectList, true);
            this.InitSetting(HierarchySetting.ShowModifierWarning, true);
            this.InitSetting(HierarchySetting.ShowErrorForDisabledComponents, true);
            this.InitSetting(HierarchySetting.IgnoreUnityMonobehaviour, true);
            this.InitSetting(HierarchySetting.ShowObjectListContent, false);
            this.InitSetting(HierarchySetting.ShowRowShading, true);
            this.InitSetting(HierarchySetting.ShowBreakedPrefabsOnly, false);
            this.InitSetting(HierarchySetting.HideIconsIfNotFit, true);
            this.InitSetting(HierarchySetting.LeftclickEnableComponent, false);
        }

        // Token: 0x06000959 RID: 2393 RVA: 0x000FFF10 File Offset: 0x000FE110
        public void OnDestroy()
        {
            this.OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO = null;
            this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH = null;
            _f5._AA = null;
        }

        // Token: 0x0600095A RID: 2394 RVA: 0x000FFF28 File Offset: 0x000FE128
        public T Get<T>(HierarchySetting setting)
        {
            return (T)((object)this.OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO[(int)setting]);
        }

        // Token: 0x0600095B RID: 2395 RVA: 0x000FFF4C File Offset: 0x000FE14C
        public void Set<T>(HierarchySetting setting, T value)
        {
            this.OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO[(int)setting] = value;
            this.SetEditorSetting(setting, value);
            bool flag = this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH.ContainsKey((int)setting) && this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH[(int)setting] != null;
            if (flag)
            {
                this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH[(int)setting]();
            }
            EditorApplication.RepaintHierarchyWindow();
        }

        // Token: 0x0600095C RID: 2396 RVA: 0x000FFFBC File Offset: 0x000FE1BC
        public void Set(HierarchySetting setting, List<_fb3> tagTextureList)
        {
            string text = "";
            for (int i = 0; i < tagTextureList.Count; i++)
            {
                text = string.Concat(new string[]
                {
                    text,
                    tagTextureList[i].KHIA,
                    ";",
                    AssetDatabase.GetAssetPath(tagTextureList[i].HBLA.GetInstanceID()),
                    ";"
                });
            }
            this.SetEditorSetting(setting, text);
            this.OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO[(int)setting] = tagTextureList;
        }

        // Token: 0x0600095D RID: 2397 RVA: 0x00100044 File Offset: 0x000FE244
        public void AddEventListener(HierarchySetting setting, SettingChangedHandler handler)
        {
            bool flag = !this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH.ContainsKey((int)setting);
            if (flag)
            {
                this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH.Add((int)setting, null);
            }
            bool flag2 = this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH[(int)setting] == null;
            if (flag2)
            {
                this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH[(int)setting] = handler;
            }
            else
            {
                Dictionary<int, SettingChangedHandler> ohilonmhjpjpkdelbddojblohkbefapedbjh = this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH;
                ohilonmhjpjpkdelbddojblohkbefapedbjh[(int)setting] = (SettingChangedHandler)Delegate.Combine(ohilonmhjpjpkdelbddojblohkbefapedbjh[(int)setting], handler);
            }
        }

        // Token: 0x0600095E RID: 2398 RVA: 0x001000C0 File Offset: 0x000FE2C0
        public void removeEventListener(HierarchySetting setting, SettingChangedHandler handler)
        {
            bool flag = this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH.ContainsKey((int)setting) && this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH[(int)setting] != null;
            if (flag)
            {
                Dictionary<int, SettingChangedHandler> ohilonmhjpjpkdelbddojblohkbefapedbjh = this.OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH;
                ohilonmhjpjpkdelbddojblohkbefapedbjh[(int)setting] = (SettingChangedHandler)Delegate.Remove(ohilonmhjpjpkdelbddojblohkbefapedbjh[(int)setting], handler);
            }
        }

        // Token: 0x0600095F RID: 2399 RVA: 0x00100118 File Offset: 0x000FE318
        private void InitSetting(HierarchySetting setting, object defaultValue)
        {
            object editorSetting = this.GetEditorSetting(setting, defaultValue);
            bool flag = editorSetting != defaultValue && editorSetting.GetType() == defaultValue.GetType();
            if (flag)
            {
                this.OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO[(int)setting] = editorSetting;
            }
            else
            {
                this.Set<object>(setting, defaultValue);
            }
        }

        // Token: 0x06000960 RID: 2400 RVA: 0x00100168 File Offset: 0x000FE368
        private object GetEditorSetting(HierarchySetting setting, object defaultValue)
        {
            bool flag = defaultValue is bool;
            object obj;
            if (flag)
            {
                obj = EditorPrefs.GetBool("Vik.SuperEditor." + setting.ToString("G"), (bool)defaultValue);
            }
            else
            {
                bool flag2 = defaultValue is int;
                if (flag2)
                {
                    obj = EditorPrefs.GetInt("Vik.SuperEditor." + setting.ToString("G"), (int)defaultValue);
                }
                else
                {
                    bool flag3 = defaultValue is float;
                    if (flag3)
                    {
                        obj = EditorPrefs.GetFloat("Vik.SuperEditor." + setting.ToString("G"), (float)defaultValue);
                    }
                    else
                    {
                        bool flag4 = defaultValue is string;
                        if (flag4)
                        {
                            obj = EditorPrefs.GetString("Vik.SuperEditor." + setting.ToString("G"), (string)defaultValue);
                        }
                        else
                        {
                            obj = defaultValue;
                        }
                    }
                }
            }
            return obj;
        }

        // Token: 0x06000961 RID: 2401 RVA: 0x00100268 File Offset: 0x000FE468
        private void SetEditorSetting(HierarchySetting setting, object value)
        {
            bool flag = value is bool;
            if (flag)
            {
                EditorPrefs.SetBool("Vik.SuperEditor." + setting.ToString("G"), (bool)value);
            }
            else
            {
                bool flag2 = value is int;
                if (flag2)
                {
                    EditorPrefs.SetInt("Vik.SuperEditor." + setting.ToString("G"), (int)value);
                }
                else
                {
                    bool flag3 = value is float;
                    if (flag3)
                    {
                        EditorPrefs.SetFloat("Vik.SuperEditor." + setting.ToString("G"), (float)value);
                    }
                    else
                    {
                        bool flag4 = value is string;
                        if (flag4)
                        {
                            EditorPrefs.SetString("Vik.SuperEditor." + setting.ToString("G"), (string)value);
                        }
                    }
                }
            }
        }

        // Token: 0x04000800 RID: 2048
        private Dictionary<int, object> OONGLEBGBAMJPLEDLNLDJOCDGOIIBKJLOKPO;

        // Token: 0x04000801 RID: 2049
        private Dictionary<int, SettingChangedHandler> OHILONMHJPJPKDELBDDOJBLOHKBEFAPEDBJH;

        // Token: 0x04000802 RID: 2050
        private static _f5 _AA;
    }
}
