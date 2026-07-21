using System.Drawing;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class MainPanel : Panel
    {
        public MainPanel() { InitializeComponent(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(223, 223, 223), 1)) { e.Graphics.DrawLine(pen, 0, 0, Width, 0); }
        }
    }
}