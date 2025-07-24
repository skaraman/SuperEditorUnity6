using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperEditor.Favorites
{
    // Token: 0x0200012D RID: 301
    public class FavoriteSave : ScriptableObject
    {
        // Token: 0x060008F4 RID: 2292 RVA: 0x000FCD3B File Offset: 0x000FAF3B
        public FavoriteSave()
        {
            this.FavoriteLists = new List<FavoriteList>();
            this.AddList();
        }

        // Token: 0x060008F5 RID: 2293 RVA: 0x000FCD64 File Offset: 0x000FAF64
        public void AddList()
        {
            string text = "Favorites ";
            List<string> list = this.NameList().ToList<string>();
            for (int i = 1; i < 1000; i++)
            {
                text = "Favorites " + i.ToString();
                bool flag = !list.Contains(text);
                if (flag)
                {
                    break;
                }
            }
            this.FavoriteLists.Add(new FavoriteList(text));
        }

        // Token: 0x060008F6 RID: 2294 RVA: 0x000FCDD0 File Offset: 0x000FAFD0
        public void RemoveList(int _index)
        {
            bool flag = this.FavoriteLists.Count > 1;
            if (flag)
            {
                this.FavoriteLists.RemoveAt(_index);
            }
        }

        // Token: 0x060008F7 RID: 2295 RVA: 0x000FCE00 File Offset: 0x000FB000
        public string[] NameList()
        {
            string[] array = new string[this.FavoriteLists.Count];
            for (int i = 0; i < this.FavoriteLists.Count; i++)
            {
                array[i] = this.FavoriteLists[i].Name;
            }
            return array;
        }

        // Token: 0x04000783 RID: 1923
        public List<FavoriteList> FavoriteLists = new List<FavoriteList>();
    }
}
