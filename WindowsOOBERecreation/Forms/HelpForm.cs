using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class HelpForm : Form
    {
        private string _helpPath;
        public HelpForm(string helpPath)
        {
            InitializeComponent();
            _helpPath = helpPath;

            this.StartPosition = FormStartPosition.Manual;
            helpPanel.Paint += helpPanel_Paint;
        }

        private void helpPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(ColorTranslator.FromHtml("#A0A0A0")))
            {
                var rect = new Rectangle(0, 0, helpPanel.ClientSize.Width - 1, helpPanel.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var workingArea = Screen.PrimaryScreen.WorkingArea;

            this.Height = workingArea.Height;
            this.Top = workingArea.Top;
            this.Left = workingArea.Right - this.Width;

            helpPanel.Padding = new Padding(5, 1, 5, 1);
            helpBox.LoadFile(_helpPath);
        }
    }
}