using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class BorderPanel : Panel
    {
        public BorderPanel() { this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true); }

        [DllImport("user32.dll")] static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")] static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                cp.Style |= 0x00800000; // WS_BORDER

                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0085)
            {
                IntPtr hdc = GetWindowDC(Handle);
                if (hdc == IntPtr.Zero) return;
                try
                {
                    using (Graphics g = Graphics.FromHdc(hdc))
                    using (var pen = new Pen(ColorTranslator.FromHtml("#e3e3e3")))
                        g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                }
                finally { ReleaseDC(Handle, hdc); }
            }
        }
    }
}