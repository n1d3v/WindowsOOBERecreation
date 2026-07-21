using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowAnimations.DisableForProcess();

            try { Application.Run(new Main()); }
            finally { WindowAnimations.Uninstall(); }
        }

        private static class WindowAnimations
        {
            private const int WH_CBT = 5;
            private const int HCBT_CREATEWND = 3;
            private const int HCBT_ACTIVATE = 5;
            private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;

            private static readonly HookProc _proc = CbtHookProc;
            private static IntPtr _hook = IntPtr.Zero;

            public static void DisableForProcess()
            {
                if (_hook != IntPtr.Zero) return;

                _hook = SetWindowsHookEx(WH_CBT, _proc, IntPtr.Zero, GetCurrentThreadId());
            }

            public static void Uninstall()
            {
                if (_hook == IntPtr.Zero) return;

                UnhookWindowsHookEx(_hook);
                _hook = IntPtr.Zero;
            }

            private static IntPtr CbtHookProc(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode == HCBT_CREATEWND || nCode == HCBT_ACTIVATE)
                {
                    int disabled = 1;
                    DwmSetWindowAttribute(wParam, DWMWA_TRANSITIONS_FORCEDISABLED, ref disabled, sizeof(int));
                }

                return CallNextHookEx(_hook, nCode, wParam, lParam);
            }

            private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll")]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll")]
            private static extern uint GetCurrentThreadId();

            [DllImport("dwmapi.dll", PreserveSig = true)]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        }
    }
}