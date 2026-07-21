// somethingPanel is called that because I forgot what it does
// God I haven't touched this source code in a while
using System;
using System.Drawing;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;
using System.IO;

namespace WindowsOOBERecreation
{
    public partial class Start : Form
    {
        private Main _mainForm;
        public string Username { get; private set; }
        public string ComputerName { get; private set; }

        public bool PCNameModified = false;
        private bool _updatingComputerName = false;

        public Start(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.AcceptButton = _mainForm.nextButton;

            // This fixes the issue of text boxes not being resizable in forms
            usernameBox.TextChanged += UsernameBox_TextChanged;
            usernameBox.AutoSize = false;
            usernameBox.Height = 20;

            // The ComputerNameBox_KeyPress() function makes it so you can't press space
            computerNameBox.KeyPress += ComputerNameBox_KeyPress;
            computerNameBox.AutoSize = false;
            computerNameBox.Height = 20;
            _mainForm.nextButton.Enabled = false;

            windowsBrandingPic.MouseClick += WindowsBrandingPic_MouseClick;

            var accountLabel = new HtmlLabel
            {
                Text = @"<div style='font-family:Segoe UI; font-size:9pt;'>
                            Choose a user name for your <a href='#account'>account</a> and name your computer
                            to distinguish it on the network.
                        </div>",
                AutoSize = true,
                Location = new Point(38, 168),
                Font = new Font("Segoe UI", 6f, FontStyle.Regular)
            };
            var computerNameLabel = new HtmlLabel
            {
                Text = @"<div style='font-family:Segoe UI; font-size:9pt;'>
                            Type a <a href='#computer'>computer name</a>:
                        </div>",
                AutoSize = true,
                Location = new Point(168, 242),
                Font = new Font("Segoe UI", 6f, FontStyle.Regular)
            };

            accountLabel.LinkClicked += HtmlLabel_LinkClicked;
            computerNameLabel.LinkClicked += HtmlLabel_LinkClicked;

            this.Controls.Add(accountLabel);
            this.Controls.Add(computerNameLabel);
        }

        private void UsernameBox_TextChanged(object sender, EventArgs e)
        {
            string usernameText = usernameBox.Text;

            if (usernameText.Length > 20)
                usernameText = usernameText.Substring(0, 20);

            Username = usernameText;

            if (!PCNameModified)
            {
                string usernameNoSpaces = usernameText.Replace(" ", string.Empty);
                string expectedStr = string.IsNullOrEmpty(usernameNoSpaces) ? "PC" : $"{usernameNoSpaces}-PC";

                _updatingComputerName = true;
                computerNameBox.Text = expectedStr;
                _updatingComputerName = false;
            }

            ComputerName = computerNameBox.Text;
            _mainForm.nextButton.Enabled = usernameText.Length > 0;
        }

        private void computerNameBox_TextChanged(object sender, EventArgs e)
        {
            if (_updatingComputerName)
                return;

            PCNameModified = true;
            ComputerName = computerNameBox.Text;

            if (ComputerName.Length > 15)
            {
                ComputerName = ComputerName.Substring(0, 15);

                _updatingComputerName = true;
                computerNameBox.Text = ComputerName;
                computerNameBox.SelectionStart = ComputerName.Length;
                _updatingComputerName = false;
            }
        }

        private void ComputerNameBox_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == ' ') { e.Handled = true; } }

        public void MainBtnClick()
        {
            _mainForm.Username = Username;
            _mainForm.ComputerName = ComputerName;
        }

        private void WindowsBrandingPic_MouseClick(object sender, MouseEventArgs e) { MessageBox.Show("Made with love by patricktbp! ♥︎", "WindowsOOBERecreation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

        private void EOAPic_Click(object sender, EventArgs e)
        {
            Helper.ExecuteCommand("Utilman.exe");
        }

        private void HtmlLabel_LinkClicked(object sender, TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs e)
        {
            // We can't use the AttachBorder function here, since the links are rendered via HTML :(
            string baseDir = Application.StartupPath;
            string helpLink = null;

            if (e.Link == "#account") { helpLink = Path.Combine(baseDir, @"Help Files\userAccountHelp.rtf"); }
            else if (e.Link == "#computer") { helpLink = Path.Combine(baseDir, @"Help Files\changeComputerName.rtf"); }

            using (var helpForm = new HelpForm(helpLink)) { helpForm.ShowDialog(); }

            e.Handled = true;
        }
    }
}
