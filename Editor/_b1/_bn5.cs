using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

namespace AHO
{
    // Token: 0x02000042 RID: 66
    [InitializeOnLoad]
    internal static class _bn5
    {
        // Token: 0x060001D9 RID: 473
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, _bn5._za4 lpfn, IntPtr hMod, uint dwThreadId);

        // Token: 0x060001DA RID: 474
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, _bn5._za3 lpfn, IntPtr hMod, uint dwThreadId);

        // Token: 0x060001DB RID: 475
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        // Token: 0x060001DC RID: 476
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        // Token: 0x060001DD RID: 477
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        // Token: 0x060001DE RID: 478 RVA: 0x00018D04 File Offset: 0x00016F04
        static _bn5()
        {
            bool flag = Application.platform == RuntimePlatform.WindowsEditor;
            if (flag)
            {
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bn5.SetHookOnFirstUpdate));
                EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.update, new EditorApplication.CallbackFunction(_bn5.OnUpdate));
                AppDomain.CurrentDomain.DomainUnload += _bn5.OnDomainUnload;
            }
        }

        // Token: 0x060001DF RID: 479 RVA: 0x00018DB0 File Offset: 0x00016FB0
        private static void SetHookOnFirstUpdate()
        {
            EditorApplication.update = (EditorApplication.CallbackFunction)Delegate.Remove(EditorApplication.update, new EditorApplication.CallbackFunction(_bn5.SetHookOnFirstUpdate));
            _bn5._za9 = _bn5.SetHook(_bn5._zb2);
            _bn5._za8 = _bn5.SetHook(_bn5._zb3);
        }

        // Token: 0x060001E0 RID: 480 RVA: 0x00018DFC File Offset: 0x00016FFC
        private static IntPtr SetHook(_bn5._za4 proc)
        {
            return _bn5.SetWindowsHookEx(2, proc, IntPtr.Zero, (uint)AppDomain.GetCurrentThreadId());
        }

        // Token: 0x060001E1 RID: 481 RVA: 0x00018E20 File Offset: 0x00017020
        private static IntPtr SetHook(_bn5._za3 proc)
        {
            return _bn5.SetWindowsHookEx(7, proc, IntPtr.Zero, (uint)AppDomain.GetCurrentThreadId());
        }

        // Token: 0x060001E2 RID: 482 RVA: 0x00018E44 File Offset: 0x00017044
        private static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            _bn5._za1 _za2 = (_bn5._za1)Marshal.PtrToStructure(lParam, typeof(_bn5._za1));
            bool flag = nCode >= 0;
            if (flag)
            {
                int num = wParam.ToInt32();
                EditorWindow focusedWindow = EditorWindow.focusedWindow;
                bool flag2 = focusedWindow != null && ((GCE._ALU != null && GCE._ALU._CDN() && focusedWindow == GCE._ALU._ABJ()) || focusedWindow is _bk5);
                if (flag2)
                {
                    int num2 = num;
                    int num3 = num2;
                    if (num3 <= 514)  // Changed from 173
                    {
                        if (num3 != 513 && num3 != 514)  // Changed from 171 and 173
                        {
                            goto IL_0146;
                        }
                    }
                    else if (num3 != 523 && num3 != 525)  // These might also need verification
                    {
                        goto IL_0146;
                    }
                    int num4 = _za2._za5 >> 16;
                    bool flag3 = num4 == 1;
                    if (flag3)
                    {
                        _bn5._za6 = focusedWindow;
                        _bn5._za7 = Event.KeyboardEvent(_bg8._BCF ? "&^left" : "&left");
                        return (IntPtr)1;
                    }
                    bool flag4 = num4 == 2;
                    if (flag4)
                    {
                        _bn5._za6 = focusedWindow;
                        _bn5._za7 = Event.KeyboardEvent(_bg8._BCF ? "&^right" : "&right");
                        return (IntPtr)1;
                    }
                IL_0146:;
                }
            }
            return _bn5.CallNextHookEx(_bn5._za8, nCode, wParam, lParam);
        }

        // Token: 0x060001E3 RID: 483 RVA: 0x00018FAC File Offset: 0x000171AC
        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool flag = nCode >= 0;
            if (flag)
            {
                bool flag2 = ((long)lParam.ToInt32() & unchecked((long)((ulong)(-1610612736)))) == 0L;
                if (flag2)
                {
                    int num = wParam.ToInt32();
                    bool flag3 = num == 70 && ((int)_bn5.GetKeyState(17) & 32768) != 0 && ((int)_bn5.GetKeyState(16) & 32768) != 0;
                    if (flag3)
                    {
                        EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, new EditorApplication.CallbackFunction(_bg3.ShowFindInFilesWindow));
                        return (IntPtr)1;
                    }
                    EditorWindow focusedWindow = EditorWindow.focusedWindow;
                    bool flag4 = focusedWindow != null && ((GCE._ALU != null && (GCE._ALU._CDN() || GCE._ALU._CDT) && focusedWindow == GCE._ALU._ABJ()) || (num == 9 && (focusedWindow is _bh1 || focusedWindow is _bk5)));
                    if (flag4)
                    {
                        bool flag5 = ((int)_bn5.GetKeyState(17) & 32768) != 0;
                        if (flag5)
                        {
                            bool flag6 = ((int)_bn5.GetKeyState(16) & 32768) == 0;
                            if (flag6)
                            {
                                bool flag7 = num == 83;
                                if (flag7)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("^&s");
                                    return (IntPtr)1;
                                }
                                bool flag8 = num == 90;
                                if (flag8)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("#^z");
                                    return (IntPtr)1;
                                }
                                bool flag9 = num == 89;
                                if (flag9)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("#^y");
                                    return (IntPtr)1;
                                }
                                bool flag10 = num == 82;
                                if (flag10)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("#^r");
                                    return (IntPtr)1;
                                }
                                bool flag11 = num == 9;
                                if (flag11)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("^\t");
                                    return (IntPtr)1;
                                }
                            }
                            else
                            {
                                bool flag12 = num == 90;
                                if (flag12)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("#^y");
                                    return (IntPtr)1;
                                }
                                bool flag13 = num == 9;
                                if (flag13)
                                {
                                    _bn5._za6 = focusedWindow;
                                    _bn5._za7 = Event.KeyboardEvent("#^\t");
                                    return (IntPtr)1;
                                }
                            }
                        }
                    }
                }
            }
            return _bn5.CallNextHookEx(_bn5._za9, nCode, wParam, lParam);
        }

        // Token: 0x060001E4 RID: 484 RVA: 0x0001923C File Offset: 0x0001743C
        private static void OnUpdate()
        {
            bool flag = _bn5._za7 != null;
            if (flag)
            {
                Event _zb1 = _bn5._za7;
                _bn5._za7 = null;
                bool flag2 = _bn5._za6 && _bn5._za6 == EditorWindow.focusedWindow;
                if (flag2)
                {
                    _bn5._za6.SendEvent(_zb1);
                }
            }
        }

        // Token: 0x060001E5 RID: 485 RVA: 0x00019294 File Offset: 0x00017494
        private static void OnDomainUnload(object sender, EventArgs e)
        {
            bool flag = _bn5._za9 != IntPtr.Zero;
            if (flag)
            {
                _bn5.UnhookWindowsHookEx(_bn5._za9);
            }
            _bn5._za9 = IntPtr.Zero;
            bool flag2 = _bn5._za8 != IntPtr.Zero;
            if (flag2)
            {
                _bn5.UnhookWindowsHookEx(_bn5._za8);
            }
            _bn5._za8 = IntPtr.Zero;
        }

        // Token: 0x04000232 RID: 562
        private static readonly _bn5._za4 _zb2 = new _bn5._za4(_bn5.KeyboardHookCallback);

        // Token: 0x04000233 RID: 563
        private static IntPtr _za9 = IntPtr.Zero;

        // Token: 0x04000234 RID: 564
        private static readonly _bn5._za3 _zb3 = new _bn5._za3(_bn5.MouseHookCallback);

        // Token: 0x04000235 RID: 565
        private static IntPtr _za8 = IntPtr.Zero;

        // Token: 0x04000236 RID: 566
        private static EditorWindow _za6;

        // Token: 0x04000237 RID: 567
        private static Event _za7;

        // Token: 0x02000043 RID: 67
        // (Invoke) Token: 0x060001E7 RID: 487
        private delegate IntPtr _za4(int nCode, IntPtr wParam, IntPtr lParam);

        // Token: 0x02000044 RID: 68
        // (Invoke) Token: 0x060001EB RID: 491
        private delegate IntPtr _za3(int nCode, IntPtr wParam, IntPtr lParam);

        // Token: 0x02000045 RID: 69
        [StructLayout(LayoutKind.Sequential)]
        internal class _zb4
        {
            // Token: 0x04000238 RID: 568
            public int _zb5;

            // Token: 0x04000239 RID: 569
            public int _zb6;
        }

        // Token: 0x02000046 RID: 70
        private struct _zb7
        {
            // Token: 0x0400023A RID: 570
            public _bn5._zb4 _zb8;

            // Token: 0x0400023B RID: 571
            public IntPtr _zb9;

            // Token: 0x0400023C RID: 572
            public uint _zc1;

            // Token: 0x0400023D RID: 573
            public IntPtr _zc2;
        }

        // Token: 0x02000047 RID: 71
        private struct _za1
        {
            // Token: 0x0400023E RID: 574
            public _bn5._zb7 _zc3;

            // Token: 0x0400023F RID: 575
            public int _za5;
        }
    }
}
