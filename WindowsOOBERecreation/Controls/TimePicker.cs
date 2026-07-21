using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WindowsOOBERecreation
{
    public partial class TimePicker : UserControl
    {
        #region Control variables
        enum TimePart { Hours, Minutes, Seconds, AmPm }
        private TimePart currentPart = TimePart.Hours;
        private Timer holdTimer;
        private int holdDelta;
        private Timer syncTimer;
        private bool _isEditing;
        #endregion

        #region Interop variables
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Milliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetLocalTime(ref SYSTEMTIME time);
        #endregion

        public TimePicker()
        {
            InitializeComponent();

            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
            this.BorderStyle = BorderStyle.None;

            clockBox.AutoSize = false;
            clockBox.Size = new Size(72, 21);

            #region Timer setup
            holdTimer = new Timer();
            holdTimer.Interval = 100;
            holdTimer.Tick += (s, e) =>
            {
                if (currentPart == TimePart.AmPm)
                {
                    holdTimer.Stop();
                    return;
                }
                ChangeValue(holdDelta);
            };

            syncTimer = new Timer();
            syncTimer.Interval = 1000;
            syncTimer.Tick += (s, e) => SetTime(DateTime.Now);
            syncTimer.Start();
            #endregion

            clockBox.Enter += (s, e) => PauseSync();
            clockBox.Leave += (s, e) =>
            {
                BeginInvoke(new Action(CheckResumeSync));
            };

            SetTime(DateTime.Now);
            clockBox.SelectionStart = 0;
            clockBox.SelectionLength = 0;
        }

        #region Set system clock handler
        private void SetSystemClock(int h, int m, int s)
        {
            DateTime now = DateTime.Now;
            DateTime newTime = new DateTime(now.Year, now.Month, now.Day, h, m, s);

            SYSTEMTIME st = new SYSTEMTIME
            {
                Year = (short)newTime.Year,
                Month = (short)newTime.Month,
                Day = (short)newTime.Day,
                Hour = (short)newTime.Hour,
                Minute = (short)newTime.Minute,
                Second = (short)newTime.Second,
                Milliseconds = (short)newTime.Millisecond
            };

            if (!SetLocalTime(ref st))
            {
                int error = Marshal.GetLastWin32Error();
                System.Diagnostics.Debug.WriteLine($"SetLocalTime failed. Win32 error: {error}");
            }
        }
        #endregion

        #region upButton click handling
        private void upButton_MouseEnter(object sender, EventArgs e) => upButton.Image = Properties.Resources.up_hovered;
        private void upButton_MouseLeave(object sender, EventArgs e) => upButton.Image = Properties.Resources.up_normal;

        private void upButton_MouseDown(object sender, MouseEventArgs e)
        {
            upButton.Image = Properties.Resources.up_pressed;
            PauseSync();   // Behavior 3: changing a value keeps sync paused
            holdDelta = 1;
            ChangeValue(holdDelta);
            holdTimer.Start();
        }

        private void upButton_MouseUp(object sender, MouseEventArgs e)
        {
            holdTimer.Stop();
            upButton.Image = IsMouseOver(upButton)
                ? Properties.Resources.up_hovered
                : Properties.Resources.up_normal;
        }
        #endregion

        #region downButton click handling
        private void downButton_MouseEnter(object sender, EventArgs e) => downButton.Image = Properties.Resources.down_hovered;
        private void downButton_MouseLeave(object sender, EventArgs e) => downButton.Image = Properties.Resources.down_normal;

        private void downButton_MouseDown(object sender, MouseEventArgs e)
        {
            downButton.Image = Properties.Resources.down_pressed;
            PauseSync();
            holdDelta = -1;
            ChangeValue(holdDelta);
            holdTimer.Start();
        }

        private void downButton_MouseUp(object sender, MouseEventArgs e)
        {
            holdTimer.Stop();
            downButton.Image = IsMouseOver(downButton)
                ? Properties.Resources.down_hovered
                : Properties.Resources.down_normal;
        }
        #endregion

        #region clockBox click handling
        private void clockBox_MouseUp(object sender, MouseEventArgs e)
        {
            int pos = clockBox.GetCharIndexFromPosition(e.Location);

            int firstColon = clockBox.Text.IndexOf(':');
            int lastColon = clockBox.Text.LastIndexOf(':');
            int spaceIndex = clockBox.Text.LastIndexOf(' ');

            if (pos <= firstColon) currentPart = TimePart.Hours;
            else if (pos <= lastColon) currentPart = TimePart.Minutes;
            else if (pos <= spaceIndex) currentPart = TimePart.Seconds;
            else currentPart = TimePart.AmPm;

            clockBox.SelectionStart = pos;
            clockBox.SelectionLength = 0;
        }
        #endregion

        #region clockBox key handlers
        private void clockBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int pos = clockBox.SelectionStart;
            int firstColon = clockBox.Text.IndexOf(':');
            int lastColon = clockBox.Text.LastIndexOf(':');

            if (pos == firstColon || pos == lastColon)
                e.Handled = true;
        }

        private void clockBox_KeyDown(object sender, KeyEventArgs e)
        {
            int pos = clockBox.SelectionStart;
            int firstColon = clockBox.Text.IndexOf(':');
            int lastColon = clockBox.Text.LastIndexOf(':');

            if (e.KeyCode == Keys.Left)
            {
                int newPos = Math.Max(0, pos - 1);
                if (newPos == firstColon || newPos == lastColon) { e.SuppressKeyPress = true; return; }

                clockBox.SelectionStart = newPos;
                clockBox.SelectionLength = 0;
                UpdatePartFromCaret();
                SelectPartAfterChange();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (pos == firstColon || pos == lastColon) { e.SuppressKeyPress = true; return; }

                int newPos = Math.Min(clockBox.Text.Length, pos + 1);
                clockBox.SelectionStart = newPos;
                clockBox.SelectionLength = 0;
                UpdatePartFromCaret();
                SelectPartAfterChange();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                ChangeValue(1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                ChangeValue(-1);
                e.SuppressKeyPress = true;
            }
            else
            {
                if (currentPart != TimePart.AmPm)
                {
                    bool isDigit = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);
                    bool isNav = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Tab;

                    if (!isDigit && !isNav)
                        e.SuppressKeyPress = true;
                }
                else { e.SuppressKeyPress = true; }
            }
        }
        #endregion

        #region Visual clock handlers
        private string FormatTime(DateTime dt)
        {
            int h24 = dt.Hour;
            int displayHour = h24 % 12;
            if (displayHour == 0) displayHour = 12;

            string period = h24 >= 12 ? "PM" : "AM";
            return $"{displayHour}:{dt.Minute:D2}:{dt.Second:D2} {period}";
        }

        private void ParseTime(out int h, out int m, out int s, out string period)
        {
            h = 0; m = 0; s = 0; period = "AM";

            var parts = clockBox.Text.Split(' ', ':');
            if (parts.Length >= 4)
            {
                int.TryParse(parts[0], out int displayHour);
                int.TryParse(parts[1], out m);
                int.TryParse(parts[2], out s);
                period = parts[3];

                if (period == "PM" && displayHour != 12) h = displayHour + 12;
                else if (period == "AM" && displayHour == 12) h = 0;
                else h = displayHour;
            }
        }

        private void ToggleAmPm(ref int h)
        {
            if (h >= 12) h -= 12;
            else h += 12;
        }

        private void ApplyTime(int h, int m, int s)
        {
            int displayHour = h % 12;
            if (displayHour == 0) displayHour = 12;

            string period = h >= 12 ? "PM" : "AM";
            clockBox.Text = $"{displayHour}:{m:D2}:{s:D2} {period}";
        }

        private void ChangeValue(int delta)
        {
            ParseTime(out int h, out int m, out int s, out string _);
            if (currentPart == TimePart.AmPm) { ToggleAmPm(ref h); }
            else
            {
                switch (currentPart)
                {
                    case TimePart.Hours: h = (h + delta + 24) % 24; break;
                    case TimePart.Minutes: m = (m + delta + 60) % 60; break;
                    case TimePart.Seconds: s = (s + delta + 60) % 60; break;
                }
            }

            ApplyTime(h, m, s);
            SetSystemClock(h, m, s);
            SelectPartAfterChange();
        }

        private void UpdatePartFromCaret()
        {
            int pos = clockBox.SelectionStart;
            int firstColon = clockBox.Text.IndexOf(':');
            int lastColon = clockBox.Text.LastIndexOf(':');
            int spaceIndex = clockBox.Text.LastIndexOf(' ');

            if (pos <= firstColon) currentPart = TimePart.Hours;
            else if (pos <= lastColon) currentPart = TimePart.Minutes;
            else if (pos <= spaceIndex) currentPart = TimePart.Seconds;
            else currentPart = TimePart.AmPm;
        }

        private void SelectPartAfterChange()
        {
            int firstColon = clockBox.Text.IndexOf(':');
            int lastColon = clockBox.Text.LastIndexOf(':');
            int spaceIndex = clockBox.Text.LastIndexOf(' ');

            switch (currentPart)
            {
                case TimePart.Hours:
                    clockBox.SelectionStart = 0;
                    clockBox.SelectionLength = firstColon;
                    break;

                case TimePart.Minutes:
                    clockBox.SelectionStart = firstColon + 1;
                    clockBox.SelectionLength = lastColon - firstColon - 1;
                    break;

                case TimePart.Seconds:
                    clockBox.SelectionStart = lastColon + 1;
                    clockBox.SelectionLength = spaceIndex - lastColon - 1;
                    break;

                case TimePart.AmPm:
                    clockBox.SelectionStart = spaceIndex + 1;
                    clockBox.SelectionLength = 2;
                    break;
            }
        }
        #endregion

        #region Control helpers
        private void PauseSync()
        {
            if (_isEditing) return;
            _isEditing = true;
            syncTimer.Stop();
        }

        private void CheckResumeSync()
        {
            Control focused = FindFocusedChild(this);
            if (focused != null)
                return;

            _isEditing = false;
            SetTime(DateTime.Now);
            syncTimer.Start();
        }

        private static Control FindFocusedChild(Control root)
        {
            foreach (Control c in root.Controls)
            {
                if (c.Focused) return c;
                var found = FindFocusedChild(c);
                if (found != null) return found;
            }
            return null;
        }

        private bool IsMouseOver(Control c) { return c.ClientRectangle.Contains(c.PointToClient(Cursor.Position)); }
        private void SetTime(DateTime dt) { clockBox.Text = FormatTime(dt); }

        public void RefreshNow()
        {
            if (!_isEditing)
                SetTime(DateTime.Now);
        }
        #endregion
    }
}