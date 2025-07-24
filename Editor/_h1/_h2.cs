using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AHO;
using SuperEditor.Favorites;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace OKPF
{
    // Token: 0x02000130 RID: 304
    internal class _h2 : EditorWindow, IHasCustomMenu
    {
        // Token: 0x0600090F RID: 2319 RVA: 0x000FD280 File Offset: 0x000FB480
        public FavoriteList LBAF()
        {
            bool flag = this.LKII >= _h2.JDPP().FavoriteLists.Count;
            if (flag)
            {
                this.LKII--;
            }
            return _h2.JDPP().FavoriteLists[this.LKII];
        }

        // Token: 0x06000910 RID: 2320 RVA: 0x000FD2D4 File Offset: 0x000FB4D4
        private static FavoriteSave JDPP()
        {
            bool flag = !_h2.CPJP;
            if (flag)
            {
                _h2.InitFavoriteSave();
            }
            return _h2.CPJP;
        }

        // Token: 0x06000911 RID: 2321 RVA: 0x000FD304 File Offset: 0x000FB504
        [MenuItem("Window/Super Editor/Favorites", priority = 890)]
        internal static void ShowWindow()
        {
            _h2.IPHI = EditorWindow.GetWindow<_h2>("Favorites");
            _h2.IPHI.titleContent = new GUIContent("Favorites", EditorGUIUtility.IconContent("Favorite").image);
            _h2.IPHI.Show();
        }

        // Token: 0x06000912 RID: 2322 RVA: 0x000FD350 File Offset: 0x000FB550
        public void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(new GUIContent("Auto Sort"), EditorPrefs.GetBool("FavoritesSort", false), delegate
            {
                EditorPrefs.SetBool("FavoritesSort", !EditorPrefs.GetBool("FavoritesSort", false));
            });
            menu.AddItem(new GUIContent("Duplicate Tab"), false, delegate
            {
                EditorWindow.CreateWindow<_h2>(Array.Empty<Type>());
            });
            menu.AddItem(new GUIContent("Maximize"), base.maximized, delegate
            {
                base.maximized = !base.maximized;
            });
            menu.AddItem(new GUIContent("Close"), false, delegate
            {
                base.Close();
            });
            menu.ShowAsContext();
            GUIUtility.ExitGUI();
        }

        // Token: 0x06000913 RID: 2323 RVA: 0x000FD418 File Offset: 0x000FB618
        private void CheckObject(UnityEngine.Object[] _objects, out List<UnityEngine.Object> _addObjects, out List<UnityEngine.Object> _removeObjects)
        {
            _addObjects = new List<UnityEngine.Object>();
            _removeObjects = new List<UnityEngine.Object>();
            foreach (UnityEngine.Object @object in _objects)
            {
                bool flag = !this.LBAF().Contains(@object);
                if (flag)
                {
                    _addObjects.Add(@object);
                }
                else
                {
                    _removeObjects.Add(@object);
                }
            }
        }

        // Token: 0x06000914 RID: 2324 RVA: 0x000FD474 File Offset: 0x000FB674
        private void AddToFavoriteDrop(UnityEngine.Object[] _objects)
        {
            bool flag = !_h2.IPHI;
            if (flag)
            {
                _h2.ShowWindow();
            }
            List<UnityEngine.Object> list;
            List<UnityEngine.Object> list2;
            this.CheckObject(_objects, out list, out list2);
            bool flag2 = list.Count > 0;
            if (flag2)
            {
                this.LBAF().Add(list);
            }
            for (int i = 0; i < list.Count; i++)
            {
                _h2.ShiftRight<UnityEngine.Object>(this.LBAF().Objects);
            }
            EditorUtility.SetDirty(_h2.JDPP());
            AssetDatabase.SaveAssets();
        }

        // Token: 0x06000915 RID: 2325 RVA: 0x000FD500 File Offset: 0x000FB700
        public static void ShiftRight<T>(List<T> _list)
        {
            T t = _list[_list.Count - 1];
            for (int i = _list.Count - 1; i > 0; i--)
            {
                _list[i] = _list[i - 1];
            }
            _list[0] = t;
        }

        // Token: 0x06000916 RID: 2326 RVA: 0x000FD550 File Offset: 0x000FB750
        [MenuItem("Assets/Add or Remove to Favorites %&F", true, priority = -10)]
        internal static bool AddRemoveToFavoriteValidate()
        {
            bool flag = Selection.activeObject == null;
            return !flag;
        }

        // Token: 0x06000917 RID: 2327 RVA: 0x000FD578 File Offset: 0x000FB778
        public void RemoveFavorite(object _object)
        {
            GameObject gameObject = _object as GameObject;
            bool flag = gameObject && this.LBAF().ContainsGo(gameObject);
            if (flag)
            {
                this.LBAF().RemoveGos(gameObject);
            }
            else
            {
                UnityEngine.Object @object = (UnityEngine.Object)_object;
                bool flag2 = @object && this.LBAF().Contains(@object);
                if (flag2)
                {
                    this.LBAF().Remove(@object);
                }
                EditorUtility.SetDirty(_h2.JDPP());
                AssetDatabase.SaveAssets();
            }
        }

        // Token: 0x06000918 RID: 2328 RVA: 0x000FD5FC File Offset: 0x000FB7FC
        public void ClearFavorite()
        {
            bool flag = EditorUtility.DisplayDialog("Clear the list \"" + this.LBAF().Name + "\"?", "Are you sure you want delete all the Favorites of the list \"" + this.LBAF().Name + "\"?", "Yes", "No");
            if (flag)
            {
                this.LBAF().Clear();
            }
            EditorUtility.SetDirty(_h2.JDPP());
            AssetDatabase.SaveAssets();
        }

        // Token: 0x06000919 RID: 2329 RVA: 0x000FD670 File Offset: 0x000FB870
        public void ClearFavorite2()
        {
            bool flag = EditorUtility.DisplayDialog("Clear the GameObject list ?", "Are you sure you want delete all the Favorites of GameObjects?", "Yes", "No");
            if (flag)
            {
                this.LBAF().ClearGos();
            }
        }

        // Token: 0x0600091A RID: 2330 RVA: 0x000FD6AC File Offset: 0x000FB8AC
        public void OnEnable()
        {
            this.AHIC = new ReorderableList(null, typeof(GameObject), false, false, false, false);
            this.AHIC.showDefaultBackground = false;
            this.AHIC.headerHeight = 0f;
            this.AHIC.footerHeight = 0f;
            this.AHIC.drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.DrawFavoriteElement);
            this.BDKL = new ReorderableList(null, typeof(GameObject), false, false, false, false);
            this.BDKL.showDefaultBackground = false;
            this.BDKL.headerHeight = 0f;
            this.BDKL.footerHeight = 0f;
            this.BDKL.drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.DrawFavoriteElement2);
            _h2.InitFavoriteSave();
            this.EIGE = false;
            base.titleContent = new GUIContent("Favorites", EditorGUIUtility.IconContent("Favorite").image);
            this.MHGA = EditorGUIUtility.IconContent("FilterbyLabel").image as Texture2D;
            this.OIHB = this.FlipTexture(this.FlipTexture(this.DuplicateTexture(this.MHGA), true), false);
            this.LBAF().InitGos();
        }

        // Token: 0x0600091B RID: 2331 RVA: 0x000FD7E8 File Offset: 0x000FB9E8
        private static void InitFavoriteSave()
        {
            bool flag = !_h2.CPJP;
            if (flag)
            {
                string[] array = AssetDatabase.FindAssets("t:FavoriteSave");
                bool flag2 = array.Length != 0;
                if (flag2)
                {
                    _h2.CPJP = AssetDatabase.LoadAssetAtPath<FavoriteSave>(AssetDatabase.GUIDToAssetPath(array[0]));
                }
                bool flag3 = !_h2.CPJP;
                if (flag3)
                {
                    string text = _bi2.NPOF() + "/Internal/FavoriteSave.asset";
                    _h2.CPJP = ScriptableObject.CreateInstance<FavoriteSave>();
                    AssetDatabase.CreateAsset(_h2.CPJP, text);
                    AssetDatabase.SaveAssets();
                }
            }
        }

        // Token: 0x0600091C RID: 2332 RVA: 0x000FD870 File Offset: 0x000FBA70
        private Texture2D DuplicateTexture(Texture2D source)
        {
            RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm, 1);
            Graphics.Blit(source, temporary);
            RenderTexture active = RenderTexture.active;
            RenderTexture.active = temporary;
            Texture2D texture2D = new Texture2D(source.width, source.height);
            texture2D.ReadPixels(new Rect(0f, 0f, (float)temporary.width, (float)temporary.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = active;
            RenderTexture.ReleaseTemporary(temporary);
            return texture2D;
        }

        // Token: 0x0600091D RID: 2333 RVA: 0x000FD8FC File Offset: 0x000FBAFC
        private Texture2D DuplicateTexture2(Texture2D source)
        {
            Texture2D texture2D = new Texture2D(source.width, source.height, source.format, false);
            Graphics.CopyTexture(source, 0, 0, 0, 0, texture2D.width, texture2D.height, texture2D, 0, 0, 0, 0);
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x0600091E RID: 2334 RVA: 0x000FD94C File Offset: 0x000FBB4C
        private Texture2D FlipTexture(Texture2D original, bool upSideDown = true)
        {
            Texture2D texture2D = new Texture2D(original.width, original.height);
            int width = original.width;
            int height = original.height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (upSideDown)
                    {
                        texture2D.SetPixel(i, height - j - 1, original.GetPixel(i, j));
                    }
                    else
                    {
                        texture2D.SetPixel(width - i - 1, j, original.GetPixel(i, j));
                    }
                }
            }
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x0600091F RID: 2335 RVA: 0x000FD9E8 File Offset: 0x000FBBE8
        private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
        {
            Texture2D texture2D = new Texture2D(targetWidth, targetHeight, source.format, false);
            float num = 1f / (float)targetWidth;
            float num2 = 1f / (float)targetHeight;
            for (int i = 0; i < texture2D.height; i++)
            {
                for (int j = 0; j < texture2D.width; j++)
                {
                    Color pixelBilinear = source.GetPixelBilinear((float)j / (float)texture2D.width, (float)i / (float)texture2D.height);
                    texture2D.SetPixel(j, i, pixelBilinear);
                }
            }
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x06000920 RID: 2336 RVA: 0x000FDA84 File Offset: 0x000FBC84
        private Texture2D ScaleTexture2(Texture2D source, int targetWidth, int targetHeight)
        {
            Texture2D texture2D = new Texture2D(targetWidth, targetHeight, source.format, true);
            Color[] pixels = texture2D.GetPixels(0);
            float num = 1f / (float)targetWidth;
            float num2 = 1f / (float)targetHeight;
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = source.GetPixelBilinear(num * ((float)i % (float)targetWidth), num2 * Mathf.Floor((float)(i / targetWidth)));
            }
            texture2D.SetPixels(pixels, 0);
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x06000921 RID: 2337 RVA: 0x000FDB10 File Offset: 0x000FBD10
        private void DrawFavoriteElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            UnityEngine.Object @object = this.LBAF().Get(index);
            bool flag = !@object;
            if (!flag)
            {
                this.DrawObj(@object, rect);
            }
        }

        // Token: 0x06000922 RID: 2338 RVA: 0x000FDB44 File Offset: 0x000FBD44
        private void DrawFavoriteElement2(Rect rect, int index, bool isActive, bool isFocused)
        {
            UnityEngine.Object go = this.LBAF().GetGo(index);
            bool flag = !go;
            if (!flag)
            {
                this.DrawObj(go, rect);
            }
        }

        // Token: 0x06000923 RID: 2339 RVA: 0x000FDB78 File Offset: 0x000FBD78
        private void DrawObj(UnityEngine.Object currentObject, Rect rect)
        {
            Rect rect2 = new Rect(rect);
            rect2.y += 1f;
            rect2.height -= 4f;
            rect2.width = rect2.height;
            Rect rect3 = new Rect(rect);
            rect3.y += 2f;
            rect3.height -= 4f;
            rect3.x += rect2.width;
            rect3.width -= rect2.width;
            Rect rect4 = new Rect(rect);
            rect4.x = 0f;
            rect4.width = base.position.width;
            GUI.DrawTexture(rect2, AssetPreview.GetMiniThumbnail(currentObject), 2, true);
            EditorGUI.LabelField(rect3, currentObject.name, this.JEKH);
            bool isMouse = Event.current.isMouse;
            if (isMouse)
            {
                bool flag = Event.current.button == 0 && rect.Contains(Event.current.mousePosition);
                if (flag)
                {
                    bool flag2 = Event.current.type == 0;
                    if (flag2)
                    {
                        Selection.activeObject = currentObject;
                        bool flag3 = this.CMGO == currentObject && currentObject != null;
                        if (flag3)
                        {
                            bool flag4 = this.ADJL + _h2.POBA > EditorApplication.timeSinceStartup;
                            if (flag4)
                            {
                                AssetDatabase.OpenAsset(currentObject);
                            }
                            else
                            {
                                bool flag5 = this.ADJL + _h2.FFNK < EditorApplication.timeSinceStartup;
                                if (flag5)
                                {
                                    EditorGUIUtility.PingObject(currentObject);
                                }
                            }
                        }
                        this.CMGO = currentObject;
                        this.ADJL = EditorApplication.timeSinceStartup;
                        bool flag6 = _bb6.CanClickOpen(currentObject);
                        if (flag6)
                        {
                            _bb6.OpenAssetInTab(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(currentObject)), !_bg8.EAIK.GNIO());
                        }
                    }
                    bool @bool = EditorPrefs.GetBool("FavoritesSort", false);
                    if (@bool)
                    {
                        Event.current.Use();
                    }
                }
                else
                {
                    bool flag7 = Event.current.button == 0 && rect.Contains(Event.current.mousePosition);
                    if (flag7)
                    {
                        DragAndDrop.PrepareStartDrag();
                        DragAndDrop.SetGenericData("favorite", currentObject);
                        DragAndDrop.objectReferences = new UnityEngine.Object[] { currentObject };
                        Event.current.Use();
                    }
                    else
                    {
                        bool flag8 = (int)Event.current.type == 3 && Event.current.button == 0 && DragAndDrop.GetGenericData("favorite") == currentObject;
                        if (flag8)
                        {
                            DragAndDrop.StartDrag("Drag favorite");
                            Event.current.Use();
                        }
                        else
                        {
                            bool flag9 = (int)Event.current.type == 16 && rect.Contains(Event.current.mousePosition);
                            if (flag9)
                            {
                                bool flag10 = currentObject as GameObject == null;
                                if (flag10)
                                {
                                    this.ShowGenericMenu(currentObject);
                                }
                                else
                                {
                                    this.ShowGenericMenu2(currentObject);
                                }
                                Event.current.Use();
                            }
                            else
                            {
                                bool flag11 = Event.current.button == 0 && !rect.Contains(Event.current.mousePosition);
                                if (flag11)
                                {
                                    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
                                    MethodInfo method = typeof(ReorderableList).GetMethod("ClearSelection", bindingFlags);
                                    bool flag12 = method != null;
                                    if (flag12)
                                    {
                                        method.Invoke(this.AHIC, new object[0]);
                                        method.Invoke(this.BDKL, new object[0]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000924 RID: 2340 RVA: 0x000FDF38 File Offset: 0x000FC138
        private void ShowGenericMenu(UnityEngine.Object _object = null)
        {
            GenericMenu genericMenu = this.RemoveCommon(_object);
            genericMenu.AddItem(new GUIContent("Move to First"), false, new GenericMenu.MenuFunction2(this.MoveToFirst), _object);
            genericMenu.AddItem(new GUIContent("Clear All"), false, new GenericMenu.MenuFunction(this.ClearFavorite));
            genericMenu.ShowAsContext();
            EditorUtility.SetDirty(_h2.JDPP());
            AssetDatabase.SaveAssets();
        }

        // Token: 0x06000925 RID: 2341 RVA: 0x000FDFA4 File Offset: 0x000FC1A4
        private void ShowGenericMenu2(UnityEngine.Object _object = null)
        {
            GenericMenu genericMenu = this.RemoveCommon(_object);
            genericMenu.AddItem(new GUIContent("Move to First"), false, new GenericMenu.MenuFunction2(this.MoveToFirst), _object);
            genericMenu.AddItem(new GUIContent("Clear All"), false, new GenericMenu.MenuFunction(this.ClearFavorite2));
            genericMenu.ShowAsContext();
        }

        // Token: 0x06000926 RID: 2342 RVA: 0x000FE000 File Offset: 0x000FC200
        private GenericMenu RemoveCommon(UnityEngine.Object _object = null)
        {
            GenericMenu genericMenu = new GenericMenu();
            bool flag = _object;
            if (flag)
            {
                genericMenu.AddItem(new GUIContent("Remove"), false, new GenericMenu.MenuFunction2(this.RemoveFavorite), _object);
            }
            else
            {
                genericMenu.AddDisabledItem(new GUIContent("Remove"));
            }
            genericMenu.AddSeparator("");
            return genericMenu;
        }

        // Token: 0x06000927 RID: 2343 RVA: 0x000FE064 File Offset: 0x000FC264
        private void MoveToFirst(object _object = null)
        {
            GameObject gameObject = _object as GameObject;
            bool flag = gameObject && this.LBAF().ContainsGo(gameObject);
            if (flag)
            {
                this.LBAF().RemoveGos(gameObject);
                this.LBAF().InsertGo(0, gameObject);
            }
            else
            {
                UnityEngine.Object @object = (UnityEngine.Object)_object;
                bool flag2 = @object && this.LBAF().Contains(@object);
                if (flag2)
                {
                    this.LBAF().Remove(@object);
                    this.LBAF().Objects.Insert(0, @object);
                }
                EditorUtility.SetDirty(_h2.JDPP());
                AssetDatabase.SaveAssets();
            }
        }

        // Token: 0x06000928 RID: 2344 RVA: 0x000FE108 File Offset: 0x000FC308
        public void OnLostFocus()
        {
            bool anhe = this.ANHE;
            if (anhe)
            {
                this.ANHE = false;
            }
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            MethodInfo method = typeof(ReorderableList).GetMethod("ClearSelection", bindingFlags);
            bool flag = method != null;
            if (flag)
            {
                method.Invoke(this.AHIC, new object[0]);
                method.Invoke(this.BDKL, new object[0]);
            }
        }

        // Token: 0x06000929 RID: 2345 RVA: 0x000FE174 File Offset: 0x000FC374
        public void Update()
        {
            bool flag = EditorApplication.timeSinceStartup > this.PJDC;
            if (flag)
            {
                this.PJDC = EditorApplication.timeSinceStartup + _h2.LBAE;
                base.Repaint();
            }
        }

        // Token: 0x0600092A RID: 2346 RVA: 0x000FE1B0 File Offset: 0x000FC3B0
        public void OnGUI()
        {
            bool flag = !this.EIGE;
            if (flag)
            {
                this.EIGE = true;
                this.JEKH = new GUIStyle(EditorStyles.label);
                this.JEKH.focused.textColor = this.JEKH.normal.textColor;
            }
            GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag2 = this.OIHB == null;
            if (flag2)
            {
                this.OnEnable();
            }
            bool flag3 = GUILayout.Button(this.OIHB, EditorStyles.toolbarButton, new GUILayoutOption[] { GUILayout.MaxWidth(26f) });
            if (flag3)
            {
                this.ButtonEditFavoriteList();
            }
            bool anhe = this.ANHE;
            if (anhe)
            {
                string text = string.Empty;
                GUI.SetNextControlName("EditNameList");
                text = (this.LBAF().Name = EditorGUILayout.TextField(this.LBAF().Name, EditorStyles.toolbarTextField, new GUILayoutOption[] { GUILayout.ExpandWidth(true) }));
                EditorGUI.FocusTextInControl("EditNameList");
                bool flag4 = ((int)Event.current.type == 1 && Event.current.button == 0) || ((int)Event.current.type == 5 && (int)Event.current.keyCode == 13);
                if (flag4)
                {
                    bool flag5 = false;
                    List<string> list = _h2.JDPP().NameList().ToList<string>();
                    list.Remove(this.LBAF().Name);
                    list.ToArray();
                    foreach (string text2 in list)
                    {
                        bool flag6 = text2 == text;
                        if (flag6)
                        {
                            flag5 = true;
                        }
                    }
                    bool flag7 = !flag5;
                    if (flag7)
                    {
                        this.LBAF().Name = text;
                    }
                    else
                    {
                        for (int i = 1; i < 1000; i++)
                        {
                            text += i.ToString();
                            bool flag8 = !_h2.JDPP().NameList().Contains(text);
                            if (flag8)
                            {
                                break;
                            }
                        }
                        this.LBAF().Name = text;
                    }
                    this.ANHE = false;
                    EditorUtility.SetDirty(_h2.JDPP());
                    AssetDatabase.SaveAssets();
                }
            }
            else
            {
                int num = EditorGUILayout.Popup(this.LKII, _h2.JDPP().NameList(), EditorStyles.toolbarPopup, Array.Empty<GUILayoutOption>());
                bool flag9 = num != this.LKII;
                if (flag9)
                {
                    this.LKII = num;
                    this.LBAF().InitGos();
                }
            }
            EditorGUI.BeginDisabledGroup(this.ANHE);
            bool flag10 = GUILayout.Button(EditorGUIUtility.IconContent("Toolbar Plus"), EditorStyles.toolbarButton, new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
            if (flag10)
            {
                this.ButtonAddFavoriteList();
            }
            EditorGUI.BeginDisabledGroup(_h2.JDPP().FavoriteLists.Count <= 1);
            bool flag11 = GUILayout.Button(EditorGUIUtility.IconContent("Toolbar Minus"), EditorStyles.toolbarButton, new GUILayoutOption[] { GUILayout.ExpandWidth(false) });
            if (flag11)
            {
                this.ButtonRemoveFavoriteList();
            }
            EditorGUI.EndDisabledGroup();
            EditorGUI.EndDisabledGroup();
            GUILayout.EndHorizontal();
            Color color = new Color(0f, 0f, 0f, 0.25f);
            EditorGUI.DrawRect(new Rect(0f, 20f, base.position.size.x, 1f), color);
            bool flag12 = Event.current.mousePosition.x >= 0f && Event.current.mousePosition.x <= base.position.width && Event.current.mousePosition.y >= 20f && Event.current.mousePosition.y <= base.position.height;
            bool flag13 = (int)Event.current.type == 9 && flag12;
            if (flag13)
            {
                bool flag14 = DragAndDrop.objectReferences.Length != 0;
                if (flag14)
                {
                    DragAndDrop.visualMode = (DragAndDropVisualMode)1;
                }
                else
                {
                    DragAndDrop.visualMode = (DragAndDropVisualMode)32;
                }
            }
            else
            {
                bool flag15 = (int)Event.current.type == 10 && flag12;
                if (flag15)
                {
                    DragAndDrop.AcceptDrag();
                    List<UnityEngine.Object> list2 = new List<UnityEngine.Object>();
                    foreach (UnityEngine.Object @object in DragAndDrop.objectReferences)
                    {
                        GameObject gameObject = @object as GameObject;
                        Component component = @object as Component;
                        bool flag16 = AssetDatabase.GetAssetPath(@object) != "";
                        if (flag16)
                        {
                            list2.Add(@object);
                        }
                        else
                        {
                            bool flag17 = gameObject != null && !this.LBAF().ContainsGo(gameObject);
                            if (flag17)
                            {
                                this.LBAF().AddGo(gameObject);
                                _h2.ShiftRight<GameObject>(this.LBAF().gos);
                                _h2.ShiftRight<string>(this.LBAF().goIDs);
                            }
                            else
                            {
                                bool flag18 = component != null && !this.LBAF().ContainsGo(component.gameObject);
                                if (flag18)
                                {
                                    this.LBAF().AddGo(component.gameObject);
                                    _h2.ShiftRight<GameObject>(this.LBAF().gos);
                                    _h2.ShiftRight<string>(this.LBAF().goIDs);
                                }
                            }
                        }
                    }
                    this.AddToFavoriteDrop(list2.ToArray());
                    DragAndDrop.AcceptDrag();
                    Event.current.Use();
                }
            }
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            bool flag19 = this.LBAF().Objects.Count == 0 && this.LBAF().gos.Count == 0;
            if (flag19)
            {
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
                GUILayout.FlexibleSpace();
                GUILayout.Label("Drag and drop anything here", EditorStyles.boldLabel, Array.Empty<GUILayoutOption>());
                GUILayout.FlexibleSpace();
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
            }
            else
            {
                bool flag20 = this.LBAF().Objects.Count > 0;
                if (flag20)
                {
                    bool flag21 = this.LBAF().gos == null;
                    if (flag21)
                    {
                        this.LBAF().InitGos();
                    }
                    bool flag22 = this.LBAF().gos.Count > 0;
                    if (flag22)
                    {
                        this.MEJD = GUILayout.BeginScrollView(this.MEJD, new GUILayoutOption[] { GUILayout.Width(base.position.width / 2f) });
                    }
                    else
                    {
                        this.MEJD = GUILayout.BeginScrollView(this.MEJD, Array.Empty<GUILayoutOption>());
                    }
                    this.LBAF().Update();
                    this.AHIC.list = this.LBAF().Objects;
                    this.AHIC.draggable = !EditorPrefs.GetBool("FavoritesSort", false);
                    this.AHIC.DoLayoutList();
                    bool flag23 = (int)Event.current.type == 16;
                    if (flag23)
                    {
                        this.ShowGenericMenu(null);
                    }
                    else
                    {
                        bool flag24 = (int)Event.current.type == 1 && Event.current.button == 0;
                        if (flag24)
                        {
                            Selection.activeObject = null;
                        }
                    }
                    GUILayout.EndScrollView();
                }
                bool flag25 = this.LBAF().gos.Count > 0;
                if (flag25)
                {
                    bool flag26 = this.LBAF().Objects.Count > 0;
                    if (flag26)
                    {
                        this.EDLI = GUILayout.BeginScrollView(this.EDLI, new GUILayoutOption[] { GUILayout.Width(base.position.width / 2f) });
                    }
                    else
                    {
                        this.EDLI = GUILayout.BeginScrollView(this.EDLI, Array.Empty<GUILayoutOption>());
                    }
                    this.BDKL.list = this.LBAF().gos;
                    this.LBAF().gos.RemoveAll((GameObject obj) => obj == null);
                    this.BDKL.draggable = !EditorPrefs.GetBool("FavoritesSort", false);
                    this.BDKL.DoLayoutList();
                    bool flag27 = (int)Event.current.type == 16;
                    if (flag27)
                    {
                        this.ShowGenericMenu2(null);
                    }
                    else
                    {
                        bool flag28 = (int)Event.current.type == 1 && Event.current.button == 0;
                        if (flag28)
                        {
                            Selection.activeObject = null;
                        }
                    }
                    GUILayout.EndScrollView();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        // Token: 0x0600092B RID: 2347 RVA: 0x000FEA60 File Offset: 0x000FCC60
        public void ButtonAddFavoriteList()
        {
            _h2.JDPP().AddList();
            this.LKII = _h2.JDPP().FavoriteLists.Count - 1;
            EditorUtility.SetDirty(_h2.JDPP());
            AssetDatabase.SaveAssets();
        }

        // Token: 0x0600092C RID: 2348 RVA: 0x000FEA98 File Offset: 0x000FCC98
        public void ButtonRemoveFavoriteList()
        {
            bool flag = this.LBAF().Objects.Count == 0 && this.LBAF().gos.Count == 0;
            if (flag)
            {
                _h2.JDPP().RemoveList(this.LKII);
                EditorUtility.SetDirty(_h2.JDPP());
                AssetDatabase.SaveAssets();
            }
            else
            {
                bool flag2 = EditorUtility.DisplayDialog("Remove the list \"" + this.LBAF().Name + "\"?", "Are you sure you want delete the list \"" + this.LBAF().Name + "\"?", "Yes", "No");
                if (flag2)
                {
                    _h2.JDPP().RemoveList(this.LKII);
                    bool flag3 = this.LKII >= _h2.JDPP().FavoriteLists.Count;
                    if (flag3)
                    {
                        this.LKII--;
                    }
                    EditorUtility.SetDirty(_h2.JDPP());
                    AssetDatabase.SaveAssets();
                }
            }
        }

        // Token: 0x0600092D RID: 2349 RVA: 0x000FEB91 File Offset: 0x000FCD91
        public void ButtonEditFavoriteList()
        {
            this.ANHE = !this.ANHE;
        }

        // Token: 0x0400078B RID: 1931
        private static _h2 IPHI;

        // Token: 0x0400078C RID: 1932
        private Vector2 MEJD = Vector2.zero;

        // Token: 0x0400078D RID: 1933
        private Vector2 EDLI = Vector2.zero;

        // Token: 0x0400078E RID: 1934
        private UnityEngine.Object CMGO = null;

        // Token: 0x0400078F RID: 1935
        private double ADJL = 0.0;

        // Token: 0x04000790 RID: 1936
        private static readonly double POBA = 0.5;

        // Token: 0x04000791 RID: 1937
        private static readonly double FFNK = 1.0;

        // Token: 0x04000792 RID: 1938
        private double PJDC = 0.0;

        // Token: 0x04000793 RID: 1939
        private static readonly double LBAE = 0.10000000149011612;

        // Token: 0x04000794 RID: 1940
        public int LKII = 0;

        // Token: 0x04000795 RID: 1941
        private static FavoriteSave CPJP;

        // Token: 0x04000796 RID: 1942
        private ReorderableList AHIC;

        // Token: 0x04000797 RID: 1943
        private ReorderableList BDKL;

        // Token: 0x04000798 RID: 1944
        private bool EIGE = false;

        // Token: 0x04000799 RID: 1945
        private GUIStyle JEKH = null;

        // Token: 0x0400079A RID: 1946
        private bool ANHE = false;

        // Token: 0x0400079B RID: 1947
        private Texture2D MHGA;

        // Token: 0x0400079C RID: 1948
        private Texture2D OIHB;
    }
}
