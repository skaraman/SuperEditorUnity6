using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SuperEditor.Favorites
{
    // Token: 0x0200012E RID: 302
    [Serializable]
    public class FavoriteList
    {
        // Token: 0x060008F8 RID: 2296 RVA: 0x000FCE52 File Offset: 0x000FB052
        public FavoriteList(string _name = "Favorites")
        {
            this.Name = _name;
            this.Objects = new List<UnityEngine.Object>();
            this.goIDs = new List<string>();
            this.gos = new List<GameObject>();
        }

        // Token: 0x060008F9 RID: 2297 RVA: 0x000FCE84 File Offset: 0x000FB084
        public List<GameObject> InitGos()
        {
            bool flag = this.gos == null;
            if (flag)
            {
                this.gos = new List<GameObject>();
            }
            this.gos.Clear();
            for (int i = 0; i < this.goIDs.Count; i++)
            {
                GlobalObjectId globalObjectId;
                GlobalObjectId.TryParse(this.goIDs[i], ref globalObjectId);
                GameObject gameObject = GlobalObjectId.GlobalObjectIdentifierToObjectSlow(globalObjectId) as GameObject;
                bool flag2 = !this.gos.Contains(gameObject);
                if (flag2)
                {
                    this.gos.Add(gameObject);
                }
            }
            return this.gos;
        }

        // Token: 0x060008FA RID: 2298 RVA: 0x000FCF24 File Offset: 0x000FB124
        public void AddGo(GameObject go)
        {
            if (go == null) return;
            this.goIDs.Add(GlobalObjectId.GetGlobalObjectIdSlow(go).ToString());
            this.gos.Add(go);
        }

        // Token: 0x060008FB RID: 2299 RVA: 0x000FCF60 File Offset: 0x000FB160
        public void AddGo(List<GameObject> gos)
        {
            if (gos == null) return;
            foreach (GameObject gameObject in gos)
            {
                if (gameObject == null) continue;
                this.goIDs.Add(GlobalObjectId.GetGlobalObjectIdSlow(gameObject).ToString());
                this.gos.Add(gameObject);
            }
        }

        // Token: 0x060008FC RID: 2300 RVA: 0x000FCFD4 File Offset: 0x000FB1D4
        public void RemoveGos(GameObject go)
        {
            if (go == null) return;
            this.goIDs.Remove(GlobalObjectId.GetGlobalObjectIdSlow(go).ToString());
            this.gos.Remove(go);
        }

        // Token: 0x060008FD RID: 2301 RVA: 0x000FD00F File Offset: 0x000FB20F
        public void RemoveGosAt(int _index)
        {
            this.goIDs.RemoveAt(_index);
            this.gos.RemoveAt(_index);
        }

        // Token: 0x060008FE RID: 2302 RVA: 0x000FD02C File Offset: 0x000FB22C
        public void ClearGos()
        {
            this.goIDs.Clear();
            this.gos.Clear();
        }

        // Token: 0x060008FF RID: 2303 RVA: 0x000FD048 File Offset: 0x000FB248
        public void InsertGo(int index, GameObject go)
        {
            if (go == null) return;
            this.goIDs.Insert(index, GlobalObjectId.GetGlobalObjectIdSlow(go).ToString());
            this.gos.Insert(index, go);
        }

        // Token: 0x06000900 RID: 2304 RVA: 0x000FD088 File Offset: 0x000FB288
        public bool ContainsGo(GameObject go)
        {
            return this.gos.Contains(go);
        }

        // Token: 0x06000901 RID: 2305 RVA: 0x000FD0A8 File Offset: 0x000FB2A8
        public GameObject GetGo(int _index)
        {
            bool flag = this.gos.Count <= _index || _index < 0;
            GameObject gameObject;
            if (flag)
            {
                gameObject = null;
            }
            else
            {
                gameObject = this.gos[_index];
            }
            return gameObject;
        }

        // Token: 0x06000902 RID: 2306 RVA: 0x000FD0DC File Offset: 0x000FB2DC
        public void Update()
        {
            this.Objects.RemoveAll((UnityEngine.Object obj) => obj == null);
            bool @bool = EditorPrefs.GetBool("FavoritesSort", false);
            if (@bool)
            {
                this.Objects.Sort((UnityEngine.Object _a, UnityEngine.Object _b) => new CaseInsensitiveComparer().Compare(_a.name, _b.name));
            }
        }

        // Token: 0x06000903 RID: 2307 RVA: 0x000FD150 File Offset: 0x000FB350
        public UnityEngine.Object Get(int _index)
        {
            bool flag = this.Objects.Count <= _index || _index < 0;
            UnityEngine.Object @object;
            if (flag)
            {
                @object = null;
            }
            else
            {
                @object = this.Objects[_index];
            }
            return @object;
        }

        // Token: 0x06000904 RID: 2308 RVA: 0x000FD184 File Offset: 0x000FB384
        public bool Contains(UnityEngine.Object _object)
        {
            return this.Objects.Contains(_object);
        }

        // Token: 0x06000905 RID: 2309 RVA: 0x000FD1A2 File Offset: 0x000FB3A2
        public void Add(List<UnityEngine.Object> _objects)
        {
            if (_objects == null) return;
            this.Objects.AddRange(_objects);
        }

        // Token: 0x06000906 RID: 2310 RVA: 0x000FD1B2 File Offset: 0x000FB3B2
        public void Add(UnityEngine.Object _object)
        {
            if (_object == null) return;
            this.Objects.Add(_object);
        }

        // Token: 0x06000907 RID: 2311 RVA: 0x000FD1C4 File Offset: 0x000FB3C4
        public void Remove(List<UnityEngine.Object> _objects)
        {
            if (_objects == null) return;
            foreach (UnityEngine.Object @object in _objects)
            {
                this.Objects.Remove(@object);
            }
        }

        // Token: 0x06000908 RID: 2312 RVA: 0x000FD21C File Offset: 0x000FB41C
        public void Remove(UnityEngine.Object _object)
        {
            this.Objects.Remove(_object);
        }

        // Token: 0x06000909 RID: 2313 RVA: 0x000FD22C File Offset: 0x000FB42C
        public void RemoveAt(int _index)
        {
            this.Objects.RemoveAt(_index);
        }

        // Token: 0x0600090A RID: 2314 RVA: 0x000FD23C File Offset: 0x000FB43C
        public void Clear()
        {
            this.Objects.Clear();
        }

        // Token: 0x04000784 RID: 1924
        public string Name;

        // Token: 0x04000785 RID: 1925
        public List<UnityEngine.Object> Objects;

        // Token: 0x04000786 RID: 1926
        public List<string> goIDs;

        // Token: 0x04000787 RID: 1927
        [NonSerialized]
        public List<GameObject> gos;
    }
}
