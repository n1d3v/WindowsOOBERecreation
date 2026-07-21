using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class MonthCal : UserControl
    {
        private IntPtr hMonthCal = IntPtr.Zero;
        const string MONTHCAL_CLASS = "SysMonthCal32";

        const int WS_CHILD = 0x40000000;
        const int WS_VISIBLE = 0x10000000;
        const int MCS_NOTODAY = 0x00000010;
        const int MCS_SHORTDAYSOFWEEK = 0x00000080;

        const int MCM_GETCURSEL = 0x1001;
        const int MCM_GETMINREQRECT = 0x1009;

        const int WM_NOTIFY = 0x004E;

        const int MCN_SELCHANGE = -749;

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RECT { public int left, top, right, bottom; }

        [StructLayout(LayoutKind.Sequential)]
        struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr CreateWindowEx(
            int exStyle, string className, string windowName,
            int style, int x, int y, int width, int height,
            IntPtr parent, IntPtr menu, IntPtr instance, IntPtr param);

        [DllImport("user32.dll")]
        static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref SYSTEMTIME lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetLocalTime(ref SYSTEMTIME time);

        public MonthCal()
        {
            InitializeComponent();

            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
            this.BorderStyle = BorderStyle.None;

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (DesignMode) return;

            hMonthCal = CreateWindowEx(
                0, MONTHCAL_CLASS, null,
                WS_CHILD | WS_VISIBLE | MCS_NOTODAY | MCS_SHORTDAYSOFWEEK,
                0, 0, 0, 0,
                this.Handle, IntPtr.Zero, GetModuleHandle(null), IntPtr.Zero);

            RECT rc = new RECT();
            SendMessage(hMonthCal, MCM_GETMINREQRECT, IntPtr.Zero, ref rc);

            int w = rc.right - rc.left;
            int h = rc.bottom - rc.top;

            MoveWindow(hMonthCal, 0, 0, w, h, true);
            this.Size = new System.Drawing.Size(w, h);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (hMonthCal != IntPtr.Zero)
            {
                DestroyWindow(hMonthCal);
                hMonthCal = IntPtr.Zero;
            }

            base.OnHandleDestroyed(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NOTIFY)
            {
                NMHDR hdr = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                if (hdr.hwndFrom == hMonthCal && hdr.code == MCN_SELCHANGE)
                {
                    DateTime selected = GetDate();
                    if (selected != DateTime.MinValue)
                        SetSystemDate(selected);
                }
            }

            base.WndProc(ref m);
        }

        private void SetSystemDate(DateTime date)
        {
            DateTime now = DateTime.Now;
            SYSTEMTIME st = new SYSTEMTIME
            {
                Year = (ushort)date.Year,
                Month = (ushort)date.Month,
                Day = (ushort)date.Day,
                Hour = (ushort)now.Hour,
                Minute = (ushort)now.Minute,
                Second = (ushort)now.Second,
                Milliseconds = (ushort)now.Millisecond
            };

            SetLocalTime(ref st);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#E3E3E3")))
            {
                var rect = this.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (hMonthCal != IntPtr.Zero)
                MoveWindow(hMonthCal, 1, 1, this.Width - 2, this.Height - 2, true);
        }

        public DateTime GetDate()
        {
            if (hMonthCal == IntPtr.Zero)
                return DateTime.MinValue;

            SYSTEMTIME st = new SYSTEMTIME();
            SendMessage(hMonthCal, MCM_GETCURSEL, IntPtr.Zero, ref st);

            return new DateTime(st.Year, st.Month, st.Day);
        }
    }
}