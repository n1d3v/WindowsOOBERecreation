// Reimplementation of CCDigitalClock from DirectUI.
// The color of the hands is slightly off, not sure on how to fix it.

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class ClockCont : UserControl
    {
        private Timer timer;

        public ClockCont()
        {
            InitializeComponent();

            DoubleBuffered = true;

            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += (s, e) => Invalidate();
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var now = DateTime.Now;
            float cx = Width / 2f;
            float cy = Height / 2f;
            float radius = Math.Min(Width, Height) / 2f;

            float hourAngle = 30f * now.Hour + now.Minute / 2f;
            float minuteAngle = 6f * now.Minute;
            float secondAngle = 6f * now.Second;

            Color teal = Color.FromArgb(14, 63, 76);
            DrawHand(e.Graphics, cx - 2f, cy - 1f, radius * 0.5f, hourAngle, 2f, teal, 0.605f);
            DrawHand(e.Graphics, cx - 2f, cy - 2f, radius * 0.7f, minuteAngle, 2f, teal, 0.605f);
            DrawHand(e.Graphics, cx - 2f, cy - 2f, 65f, secondAngle, 1f, teal, 0.605f, 20f);

            var img = Properties.Resources.clock_middle;

            float imgX = cx - img.Width / 2f;
            float imgY = cy - img.Height / 2f;

            e.Graphics.DrawImage(img, imgX, imgY, img.Width, img.Height);
        }

        private void DrawHand(Graphics g, float centerX, float centerY, float length, float angleDeg, float thickness, Color color, float opacity, float tipOffset = 0f)
        {
            double angleRad = (Math.PI / 180) * (angleDeg - 90);

            float dx = (float)Math.Cos(angleRad);
            float dy = (float)Math.Sin(angleRad);

            float startX = centerX - dx * tipOffset;
            float startY = centerY - dy * tipOffset;

            float x2 = startX + dx * length;
            float y2 = startY + dy * length;

            using (var pen = new Pen(Color.FromArgb((int)(opacity * 255), color), thickness))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawLine(pen, startX, startY, x2, y2);
            }
        }
    }
}