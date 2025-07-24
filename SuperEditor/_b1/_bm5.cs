using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x0200002E RID: 46
    internal class _bm5 : EditorWindow
    {
        // Token: 0x0600015B RID: 347 RVA: 0x00013DB8 File Offset: 0x00011FB8
        static _bm5()
        {
            bool flag = _bm5._AMB != null;
            if (flag)
            {
                _bm5.BDLFPOGMCKEAJDPNGAPNKEKDPHCDALNEIHLO = _bm5._AMB.GetMethod("FitWindowRectToScreen", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                _bm5.BMOHGNEIHHLBGGDBBFOALCOBNPHECALDMEEL = _bm5._AMB.GetField("m_DontSaveToLayout", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                _bm5.JGEKFNHHHJPAHMKOPILBBKFEFEKNAIAKLOKL = _bm5._AMB.GetMethod("MoveInFrontOf", new Type[] { _bm5._AMB });
            }
            _bm5._ALH = typeof(EditorWindow).GetField("m_Parent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            bool flag2 = _bm5._ALH != null;
            if (flag2)
            {
                Type type = typeof(EditorWindow).Assembly.GetType("UnityEditor.View");
                _bm5.MDAEJPECLMIINJGKIAEPJBOGCAKOBEHFFICG = type.GetProperty("window", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            }
        }

        // Token: 0x0600015C RID: 348 RVA: 0x00013EE8 File Offset: 0x000120E8
        protected void ShowTooltip()
        {
            bool flag = _bm5.OMKGMAEGOFGNOEPAGIHIKFEOOGMHNNNKJOEJ != null;
            if (flag)
            {
                _bm5.OMKGMAEGOFGNOEPAGIHIKFEOOGMHNNNKJOEJ.Invoke(this, new object[] { 1, false });
            }
            else
            {
                bool flag2 = _bm5.AAKGGGKCCLHPGBIOJGEAIGDAHMFBDBNNMKKD != null;
                if (flag2)
                {
                    _bm5.AAKGGGKCCLHPGBIOJGEAIGDAHMFBDBNNMKKD.Invoke(this, null);
                }
                else
                {
                    base.ShowPopup();
                }
            }
        }

        // Token: 0x0600015D RID: 349 RVA: 0x00013F50 File Offset: 0x00012150
        protected void MoveInFrontOf(EditorWindow window)
        {
            bool flag = _bm5.JGEKFNHHHJPAHMKOPILBBKFEFEKNAIAKLOKL == null;
            if (!flag)
            {
                object containerWindow = _bm5.GetContainerWindow(this);
                bool flag2 = !(UnityEngine.Object)containerWindow;
                if (!flag2)
                {
                    object containerWindow2 = _bm5.GetContainerWindow(window);
                    bool flag3 = !(UnityEngine.Object)containerWindow2;
                    if (!flag3)
                    {
                        _bm5.JGEKFNHHHJPAHMKOPILBBKFEFEKNAIAKLOKL.Invoke(containerWindow, new object[] { containerWindow2 });
                    }
                }
            }
        }

        // Token: 0x0600015E RID: 350 RVA: 0x00013FC0 File Offset: 0x000121C0
        protected virtual void OnEnable()
        {
            bool flag = _bm5.HIIPPBCKMJCKALKAGJEOFMIMDFFMBDCOHBGB == 0;
            if (flag)
            {
                EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(delegate
                {
                    bool flag2 = !this;
                    if (!flag2)
                    {
                        try
                        {
                            base.Close();
                        }
                        catch
                        {
                        }
                        UnityEngine.Object.DestroyImmediate(this);
                    }
                }));
            }
            else
            {
                _bm5.HIIPPBCKMJCKALKAGJEOFMIMDFFMBDCOHBGB--;
            }
        }

        // Token: 0x0600015F RID: 351 RVA: 0x0001400C File Offset: 0x0001220C
        protected static T CreatePopup<T>() where T : _bm5
        {
            _bm5.HIIPPBCKMJCKALKAGJEOFMIMDFFMBDCOHBGB++;
            return ScriptableObject.CreateInstance<T>();
        }

        // Token: 0x06000160 RID: 352 RVA: 0x00014034 File Offset: 0x00012234
        private static object GetContainerWindow(EditorWindow window)
        {
            bool flag = _bm5._ALH == null || _bm5.MDAEJPECLMIINJGKIAEPJBOGCAKOBEHFFICG == null;
            object obj;
            if (flag)
            {
                obj = null;
            }
            else
            {
                object value = _bm5._ALH.GetValue(window);
                bool flag2 = value == null;
                if (flag2)
                {
                    obj = null;
                }
                else
                {
                    obj = _bm5.MDAEJPECLMIINJGKIAEPJBOGCAKOBEHFFICG.GetValue(value, null);
                }
            }
            return obj;
        }

        // Token: 0x06000161 RID: 353 RVA: 0x00014090 File Offset: 0x00012290
        protected static Rect FitRectToScreen(Rect rc, EditorWindow window)
        {
            object containerWindow = _bm5.GetContainerWindow(window);
            bool flag = containerWindow == null;
            Rect rect;
            if (flag)
            {
                rect = rc;
            }
            else
            {
                bool flag2 = _bm5.BMOHGNEIHHLBGGDBBFOALCOBNPHECALDMEEL != null;
                if (flag2)
                {
                    _bm5.BMOHGNEIHHLBGGDBBFOALCOBNPHECALDMEEL.SetValue(containerWindow, _bm5.DGBCGPHIJFGHHLCHAPNMOGLHHLPJDBCECIPP);
                }
                bool flag3 = _bm5.BDLFPOGMCKEAJDPNGAPNKEKDPHCDALNEIHLO == null;
                if (flag3)
                {
                    rect = rc;
                }
                else
                {
                    rc.height += 20f;
                    rc = (Rect)_bm5.BDLFPOGMCKEAJDPNGAPNKEKDPHCDALNEIHLO.Invoke(containerWindow, new object[]
                    {
                        rc,
                        _bm5.DGBCGPHIJFGHHLCHAPNMOGLHHLPJDBCECIPP,
                        _bm5.DBMBBICBEAICBNJJGMEOBKEKGELPINPHMPID
                    });
                    rc.height -= 20f;
                    rect = rc;
                }
            }
            return rect;
        }

        // Token: 0x06000162 RID: 354 RVA: 0x00014148 File Offset: 0x00012348
        public bool OLLEJPDNBBODLEICOBPMPIPPIJBOBOOHEKFP()
        {
            return this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI;
        }

        // Token: 0x06000163 RID: 355 RVA: 0x00014160 File Offset: 0x00012360
        public void _AEW(bool value)
        {
            bool flag = value != this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI;
            if (flag)
            {
                this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI = value;
                bool flag2 = this._AEX;
                if (flag2)
                {
                    this.SetSize(base.position.width, base.position.height);
                }
                else
                {
                    this.MNAOBEMFIPHCEEOLMMHCODEOOBBIIKEPPJHF = true;
                }
            }
        }

        // Token: 0x06000164 RID: 356 RVA: 0x000141C4 File Offset: 0x000123C4
        protected void SetSize(float width, float height)
        {
            float num = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? (this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI ? (this._AEZ.x - width) : this._AEZ.xMax) : this._AEZ.x);
            float num2 = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? this._AEZ.y : (this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI ? (this._AEZ.y - height) : this._AEZ.yMax));
            Rect rect;
            rect..ctor(num, num2, width, height);
            Rect rect2 = _bm5.FitRectToScreen(rect, this);
            bool flag = this.MNAOBEMFIPHCEEOLMMHCODEOOBBIIKEPPJHF == this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI;
            if (flag)
            {
                bool flag2 = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? (rect.x != rect2.x) : (rect.y != rect2.y));
                if (flag2)
                {
                    this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI = !this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI;
                    bool hmgbdhfgccockeecfgjgpfalnblaoempbbai = this.HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI;
                    if (hmgbdhfgccockeecfgjgpfalnblaoempbbai)
                    {
                        num = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? (this._AEZ.x - width) : rect2.x);
                        num2 = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? rect2.y : (this._AEZ.y - height));
                        rect..ctor(num, num2, width, height);
                        rect2 = _bm5.FitRectToScreen(rect, this);
                    }
                    else
                    {
                        num = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? (this._AEZ.x - width) : rect2.x);
                        num2 = (this.EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF ? rect2.y : this._AEZ.yMax);
                        rect..ctor(num, num2, width, height);
                        rect2 = _bm5.FitRectToScreen(rect, this);
                    }
                }
            }
            this.FFKGLBDLKIFNBNOHLILPEHDFCNCPHAFPGIED = true;
            base.minSize = Vector2.one;
            base.maxSize = new Vector2(4000f, 4000f);
            base.position = rect2;
            Vector2 vector;
            vector..ctor(width, height);
            base.minSize = vector;
            base.maxSize = vector;
            this.FFKGLBDLKIFNBNOHLILPEHDFCNCPHAFPGIED = false;
        }

        // Token: 0x04000180 RID: 384
        private static int HIIPPBCKMJCKALKAGJEOFMIMDFFMBDCOHBGB;

        // Token: 0x04000181 RID: 385
        [NonSerialized]
        protected EditorWindow _AEX;

        // Token: 0x04000182 RID: 386
        protected Rect _AEZ;

        // Token: 0x04000183 RID: 387
        protected bool EPALNJEIJOEJDLKLCLKPOGGLFMAECGHIPEBF;

        // Token: 0x04000184 RID: 388
        private bool HMGBDHFGCCOCKEECFGJGPFALNBLAOEMPBBAI;

        // Token: 0x04000185 RID: 389
        private bool MNAOBEMFIPHCEEOLMMHCODEOOBBIIKEPPJHF;

        // Token: 0x04000186 RID: 390
        protected bool FFKGLBDLKIFNBNOHLILPEHDFCNCPHAFPGIED;

        // Token: 0x04000187 RID: 391
        private static Type _AMB = typeof(EditorWindow).Assembly.GetType("UnityEditor.ContainerWindow");

        // Token: 0x04000188 RID: 392
        private static MethodInfo BDLFPOGMCKEAJDPNGAPNKEKDPHCDALNEIHLO;

        // Token: 0x04000189 RID: 393
        private static FieldInfo BMOHGNEIHHLBGGDBBFOALCOBNPHECALDMEEL;

        // Token: 0x0400018A RID: 394
        private static FieldInfo _ALH;

        // Token: 0x0400018B RID: 395
        private static PropertyInfo MDAEJPECLMIINJGKIAEPJBOGCAKOBEHFFICG;

        // Token: 0x0400018C RID: 396
        private static MethodInfo JGEKFNHHHJPAHMKOPILBBKFEFEKNAIAKLOKL;

        // Token: 0x0400018D RID: 397
        private static MethodInfo AAKGGGKCCLHPGBIOJGEAIGDAHMFBDBNNMKKD = typeof(EditorWindow).GetMethod("ShowTooltip", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        // Token: 0x0400018E RID: 398
        private static MethodInfo OMKGMAEGOFGNOEPAGIHIKFEOOGMHNNNKJOEJ = typeof(EditorWindow).GetMethod("ShowPopupWithMode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        // Token: 0x0400018F RID: 399
        private static readonly object DGBCGPHIJFGHHLCHAPNMOGLHHLPJDBCECIPP = true;

        // Token: 0x04000190 RID: 400
        private static readonly object DBMBBICBEAICBNJJGMEOBKEKGELPINPHMPID = false;
    }
}
