using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class CommandLink : Button
    {
        private const int BS_COMMANDLINK = 0x0000000E;
        private const int BCM_SETNOTE = 0x00001609;
        private const int BM_SETIMAGE = 0x00F7;
        private const int IMAGE_ICON = 1;

        private string noteText = "";
        private Icon icon;

        public CommandLink()
        {
            FlatStyle = FlatStyle.System;
            this.CreateHandle();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= BS_COMMANDLINK;
                return cp;
            }
        }

        [Category("Appearance")]
        [Description("The secondary text displayed below the main button text.")]
        public string Note
        {
            get => noteText;
            set
            {
                noteText = value ?? "";
                if (IsHandleCreated)
                {
                    SendMessage(Handle, BCM_SETNOTE, IntPtr.Zero, noteText);
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The icon displayed on the command link button.")]
        public Icon Icon
        {
            get => icon;
            set
            {
                icon = value;
                if (IsHandleCreated)
                {
                    IntPtr hIcon = icon != null ? icon.Handle : IntPtr.Zero;
                    SendMessage(Handle, BM_SETIMAGE, (IntPtr)IMAGE_ICON, hIcon);
                    this.Invalidate();
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            Note = noteText;
            if (icon != null)
            {
                SendMessage(Handle, BM_SETIMAGE, (IntPtr)IMAGE_ICON, icon.Handle);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}