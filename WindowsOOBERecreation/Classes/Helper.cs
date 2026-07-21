using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    internal class Helper
    {
        public static void AttachBorder(Control control)
        {
            control.GotFocus += delegate { control.Invalidate(); };
            control.LostFocus += delegate { control.Invalidate(); };
            control.Paint += delegate (object sender, PaintEventArgs e) { if (control.Focused) { DrawDottedBorder(e.Graphics, control.ClientRectangle); } };
        }

        public static void DrawDottedBorder(Control control) { using (Graphics g = control.CreateGraphics()) { DrawDottedBorder(g, control.ClientRectangle); } }

        public static void DrawDottedBorder(Graphics g, Rectangle rect)
        {
            int right = rect.Right - 1;
            int bottom = rect.Bottom - 1;

            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                for (int x = rect.Left; x <= right; x += 2)
                {
                    g.FillRectangle(brush, x, rect.Top, 1, 1);
                    g.FillRectangle(brush, x, bottom, 1, 1);
                }

                for (int y = rect.Top; y <= bottom; y += 2)
                {
                    g.FillRectangle(brush, rect.Left, y, 1, 1);
                    g.FillRectangle(brush, right, y, 1, 1);
                }
            }
        }

        public static void ExecuteCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(error)) { throw new Exception(error); }
            }
        }
    }
}