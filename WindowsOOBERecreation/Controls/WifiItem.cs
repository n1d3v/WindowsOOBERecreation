using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsOOBERecreation
{
    public partial class WifiItem : UserControl
    {
        public event EventHandler WifiItemClicked;

        public bool Expanded { get; private set; } = false;

        public string Ssid => _wifiSsid;
        public bool IsSecure => _isSecure;
        public string SecurityKey => secKeyBox.Text;
        public bool AutoConnect => autoConnectChk.Checked;

        private bool _isHovered = false;

        private Timer _animTimer;

        private int _startHeight;
        private int _targetHeight;
        public int targetHeightImmediate => Expanded ? (_isSecure ? 88 : 93) : 42;

        private DateTime _animStart;
        private const int _animDuration = 200;

        private Image hoveredImg = Properties.Resources.hot;
        private Image selectedImg = Properties.Resources.selected;
        private Image hoveredSelectedImg = Properties.Resources.selected_hot;

        private string _wifiSsid;
        private bool _isSecure;
        private int _signalStrength;

        public WifiItem(string wifiSsid, bool isSecure, int signalStrength)
        {
            InitializeComponent();
            _wifiSsid = wifiSsid;
            _isSecure = isSecure;
            _signalStrength = signalStrength;

            this.BackColor = SystemColors.Window;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            secKeyBox.AutoSize = false;
            secKeyBox.Height = 20;

            AttachClickHandlers(this);
            AttachHoverHandlers(this);
            SetWiFiDetails();
        }

        private void SetWiFiDetails()
        {
            wifiSsid.Text = _wifiSsid;

            if (_isSecure) 
            {
                wifiSecType.Text = "Security-enabled network";
                unsecLabel.Visible = false;
            }
            else 
            {
                wifiSecType.Text = "Unsecure network";

                secKeyLabel.Visible = false;
                secKeyBox.Visible = false;

                // We need this to be accurate to Windows 7, for some reason Windows 7 sets it to 93 for Unsecured networks, possibly due to padding? Not sure...
                autoConnectChk.Location = new Point(autoConnectChk.Location.X, autoConnectChk.Location.Y + 5);
            }

            CalculateSignalImage();
        }

        private void CalculateSignalImage()
        {
            Image[] strengths =
            {
                Properties.Resources.strength_0,
                Properties.Resources.strength_1,
                Properties.Resources.strength_2,
                Properties.Resources.strength_3,
                Properties.Resources.strength_4,
                Properties.Resources.strength_5
            };

            int level = Clamp(_signalStrength / 20, 0, 5);
            wifiSignal.Image = strengths[level];
        }

        int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private static readonly int _sliceH = 3;
        private static readonly int _sliceW = 3;

        private void DrawNineSlice(Graphics g, Image src, Rectangle dest)
        {
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.None;

            int sw = src.Width, sh = src.Height;
            int l = _sliceW, t = _sliceH;
            int r = _sliceW, b = _sliceH;

            Rectangle[] srcRects =
            {
                new Rectangle(0,        0,        l,           t),
                new Rectangle(l,        0,        sw - l - r,  t),
                new Rectangle(sw - r,   0,        r,           t),
                new Rectangle(0,        t,        l,           sh - t - b),
                new Rectangle(l,        t,        sw - l - r,  sh - t - b),
                new Rectangle(sw - r,   t,        r,           sh - t - b),
                new Rectangle(0,        sh - b,   l,           b),
                new Rectangle(l,        sh - b,   sw - l - r,  b),
                new Rectangle(sw - r,   sh - b,   r,           b)
            };

            Rectangle[] dstRects =
            {
                new Rectangle(dest.X,         dest.Y,          l,                  t),
                new Rectangle(dest.X + l,     dest.Y,          dest.Width - l - r, t),
                new Rectangle(dest.Right - r, dest.Y,          r,                  t),
                new Rectangle(dest.X,         dest.Y + t,      l,                  dest.Height - t - b),
                new Rectangle(dest.X + l,     dest.Y + t,      dest.Width - l - r, dest.Height - t - b),
                new Rectangle(dest.Right - r, dest.Y + t,      r,                  dest.Height - t - b),
                new Rectangle(dest.X,         dest.Bottom - b, l,                  b),
                new Rectangle(dest.X + l,     dest.Bottom - b, dest.Width - l - r, b),
                new Rectangle(dest.Right - r, dest.Bottom - b, r,                  b)
            };

            using (var ia = new ImageAttributes())
            {
                ia.SetWrapMode(WrapMode.Clamp);
                for (int i = 0; i < 9; i++)
                {
                    if (dstRects[i].Width <= 0 || dstRects[i].Height <= 0)
                        continue;

                    g.DrawImage(src, dstRects[i], srcRects[i].X, srcRects[i].Y, srcRects[i].Width, srcRects[i].Height, GraphicsUnit.Pixel, ia);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Image wdBackground = null;
            if (Expanded && _isHovered)
                wdBackground = hoveredSelectedImg;
            else if (Expanded)
                wdBackground = selectedImg;
            else if (_isHovered)
                wdBackground = hoveredImg;

            if (wdBackground != null)
                DrawNineSlice(e.Graphics, wdBackground, ClientRectangle);
        }

        private void AttachClickHandlers(Control parent)
        {
            parent.Click += (s, e) => OnWifiItemClicked(e);
            foreach (Control c in parent.Controls) { AttachClickHandlers(c); }
        }

        private void AttachHoverHandlers(Control parent)
        {
            parent.MouseEnter += OnAnyMouseEnter;
            parent.MouseLeave += OnAnyMouseLeave;
            foreach (Control c in parent.Controls) { AttachHoverHandlers(c); }
        }

        private void OnAnyMouseEnter(object sender, EventArgs e) { if (!_isHovered) { _isHovered = true; Invalidate(); } }

        private void OnAnyMouseLeave(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(Cursor.Position)))
            {
                _isHovered = false;
                Invalidate();
            }
        }

        public void Expand()
        {
            if (Expanded) return;

            Expanded = true;
            extendedWifiProperties.Visible = true;

            if (_isSecure) { StartAnimation(this.Height, 88); }
            else { StartAnimation(this.Height, 93); }
        }

        public void Collapse()
        {
            if (!Expanded) return;
            Expanded = false;

            StartAnimation(this.Height, 42);
        }

        protected virtual void OnWifiItemClicked(EventArgs e) { WifiItemClicked?.Invoke(this, e); }

        private void StartAnimation(int from, int to)
        {
            if (_animTimer == null)
            {
                _animTimer = new Timer();
                _animTimer.Interval = 15;
                _animTimer.Tick += Animate;
            }

            _startHeight = from;
            _targetHeight = to;
            _animStart = DateTime.UtcNow;

            _animTimer.Start();
        }

        private void Animate(object sender, EventArgs e)
        {
            float t = (float)(DateTime.UtcNow - _animStart).TotalMilliseconds / _animDuration;
            if (t > 1f) t = 1f;

            float easedT = Expanded ? Ease(t) : 1f - Ease(1f - t);
            this.Height = (int)(_startHeight + (_targetHeight - _startHeight) * easedT);

            if (t >= 1f)
            {
                this.Height = _targetHeight;
                _animTimer.Stop();

                if (!Expanded)
                    extendedWifiProperties.Visible = false;
                else
                    BeginInvoke(new Action(() => secKeyBox.Focus()));

                AnimationComplete?.Invoke(this, EventArgs.Empty);
            }

            Invalidate();
        }

        public event EventHandler AnimationComplete;

        float Ease(float t) { return t * t * (3f - 2f * t); }
    }
}