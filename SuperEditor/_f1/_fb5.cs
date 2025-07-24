using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ODGL
{
    // Token: 0x02000132 RID: 306
    [ExecuteInEditMode]
    [AddComponentMenu("")]
    internal class _fb5 : MonoBehaviour, ISerializationCallbackReceiver
    {
        // Token: 0x06000937 RID: 2359 RVA: 0x000FEC70 File Offset: 0x000FCE70
        public void Awake()
        {
            this.CheckIntegrity();
            foreach (GameObject gameObject in this.MGEE)
            {
                gameObject.SetActive(!Application.isPlaying);
            }
            foreach (GameObject gameObject2 in this.GINK)
            {
                gameObject2.SetActive(Application.isPlaying);
            }
            bool flag = !Application.isEditor && Application.isPlaying;
            if (flag)
            {
                _fb5.FGNP.Remove(this);
                Object.DestroyImmediate(base.gameObject);
            }
            else
            {
                _fb5.FGNP.RemoveAll((_fb5 item) => item == null);
                bool flag2 = !_fb5.FGNP.Contains(this);
                if (flag2)
                {
                    _fb5.FGNP.Add(this);
                }
            }
        }

        // Token: 0x06000938 RID: 2360 RVA: 0x000FED98 File Offset: 0x000FCF98
        public void OnEnable()
        {
            bool flag = !_fb5.FGNP.Contains(this);
            if (flag)
            {
                _fb5.FGNP.Add(this);
            }
            foreach (GameObject gameObject in this.MBGD)
            {
                Renderer component = gameObject.GetComponent<Renderer>();
                bool flag2 = component != null;
                if (flag2)
                {
                    EditorUtility.SetSelectedRenderState(component, 0);
                }
            }
        }

        private const int V = -9;

        // Token: 0x06000939 RID: 2361 RVA: 0x000FEE28 File Offset: 0x000FD028
        public void OnDestroy()
        {
            bool flag = !Application.isPlaying;
            if (flag)
            {
                this.CheckIntegrity();
                foreach (GameObject gameObject in this.MGEE)
                {
                    gameObject.SetActive(false);
                }
                foreach (GameObject gameObject2 in this.GINK)
                {
                    gameObject2.SetActive(true);
                }
                foreach (GameObject gameObject3 in this.AENN)
                {
                    gameObject3.hideFlags = (HideFlags)V;
                }
                _fb5.FGNP.Remove(this);
            }
        }

        // Token: 0x0600093A RID: 2362 RVA: 0x000FEF3C File Offset: 0x000FD13C
        public void Merge(_fb5 anotherInstance)
        {
            for (int i = anotherInstance.AENN.Count - 1; i >= 0; i--)
            {
                bool flag = !this.AENN.Contains(anotherInstance.AENN[i]);
                if (flag)
                {
                    this.AENN.Add(anotherInstance.AENN[i]);
                }
            }
            for (int j = anotherInstance.MGEE.Count - 1; j >= 0; j--)
            {
                bool flag2 = !this.MGEE.Contains(anotherInstance.MGEE[j]);
                if (flag2)
                {
                    this.MGEE.Add(anotherInstance.MGEE[j]);
                }
            }
            for (int k = anotherInstance.GINK.Count - 1; k >= 0; k--)
            {
                bool flag3 = !this.GINK.Contains(anotherInstance.GINK[k]);
                if (flag3)
                {
                    this.GINK.Add(anotherInstance.GINK[k]);
                }
            }
            for (int l = anotherInstance.MBGD.Count - 1; l >= 0; l--)
            {
                bool flag4 = !this.MBGD.Contains(anotherInstance.MBGD[l]);
                if (flag4)
                {
                    this.MBGD.Add(anotherInstance.MBGD[l]);
                }
            }
            for (int m = anotherInstance.GLJO.Count - 1; m >= 0; m--)
            {
                bool flag5 = !this.GLJO.Contains(anotherInstance.GLJO[m]);
                if (flag5)
                {
                    this.GLJO.Add(anotherInstance.GLJO[m]);
                    this.ENGB.Add(anotherInstance.ENGB[m]);
                    this.EKBJ.Add(anotherInstance.GLJO[m], anotherInstance.ENGB[m]);
                }
            }
        }

        // Token: 0x0600093B RID: 2363 RVA: 0x000FF168 File Offset: 0x000FD368
        public void CheckIntegrity()
        {
            this.AENN.RemoveAll((GameObject item) => item == null);
            this.MGEE.RemoveAll((GameObject item) => item == null);
            this.GINK.RemoveAll((GameObject item) => item == null);
            this.MBGD.RemoveAll((GameObject item) => item == null);
            for (int i = this.GLJO.Count - 1; i >= 0; i--)
            {
                bool flag = this.GLJO[i] == null;
                if (flag)
                {
                    this.GLJO.RemoveAt(i);
                    this.ENGB.RemoveAt(i);
                }
            }
            this.OnAfterDeserialize();
        }

        // Token: 0x0600093C RID: 2364 RVA: 0x000FF27C File Offset: 0x000FD47C
        public void OnBeforeSerialize()
        {
            Debug.Log("OnBeforeSerialize");
            this.GLJO.Clear();
            this.ENGB.Clear();
            foreach (KeyValuePair<GameObject, Color> keyValuePair in this.EKBJ)
            {
                this.GLJO.Add(keyValuePair.Key);
                this.ENGB.Add(keyValuePair.Value);
            }
        }

        // Token: 0x0600093D RID: 2365 RVA: 0x000FF318 File Offset: 0x000FD518
        public void OnAfterDeserialize()
        {
            Debug.Log("OnAfterDeserialize");
            this.EKBJ.Clear();
            for (int i = 0; i < this.GLJO.Count; i++)
            {
                this.EKBJ.Add(this.GLJO[i], this.ENGB[i]);
            }
        }

        // Token: 0x040007A1 RID: 1953
        internal static List<_fb5> FGNP = new List<_fb5>();

        // Token: 0x040007A2 RID: 1954
        public List<GameObject> AENN = new List<GameObject>();

        // Token: 0x040007A3 RID: 1955
        public List<GameObject> MGEE = new List<GameObject>();

        // Token: 0x040007A4 RID: 1956
        public List<GameObject> GINK = new List<GameObject>();

        // Token: 0x040007A5 RID: 1957
        public List<GameObject> MBGD = new List<GameObject>();

        // Token: 0x040007A6 RID: 1958
        public Dictionary<GameObject, Color> EKBJ = new Dictionary<GameObject, Color>();

        // Token: 0x040007A7 RID: 1959
        public List<GameObject> GLJO = new List<GameObject>();

        // Token: 0x040007A8 RID: 1960
        public List<Color> ENGB = new List<Color>();
    }
}
