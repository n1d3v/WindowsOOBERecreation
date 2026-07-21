using System;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class Password : Form
    {
        private Main _mainForm;
        public string usernameString;
        public string computerNameString;
        public string passString;
        public string confirmPassString;

        public Password(Main mainForm, string username, string computerName)
        {
            InitializeComponent();
            _mainForm = mainForm;
            usernameString = username;
            computerNameString = computerName;
            this.AcceptButton = _mainForm.nextButton;

            passwordBox.TextChanged += ValidateInput;
            confirmPassBox.TextChanged += ValidateInput;
            passHintBox.TextChanged += ValidateInput;

            passwordBox.AutoSize = false;
            passwordBox.Height = 20;
            confirmPassBox.AutoSize = false;
            confirmPassBox.Height = 20;
            passHintBox.AutoSize = false;
            passHintBox.Height = 20;

            _mainForm.nextButton.Enabled = true;
        }

        private void ValidateInput(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            string confirmPassword = confirmPassBox.Text;
            string passwordHint = passHintBox.Text;

            if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(confirmPassword) && string.IsNullOrEmpty(passwordHint))
            {
                _mainForm.nextButton.Enabled = true;
                hintLabel.Text = "Type a password hint:";
            }
            else if (!string.IsNullOrEmpty(password) && password == confirmPassword && !string.IsNullOrEmpty(passwordHint))
            {
                _mainForm.nextButton.Enabled = true;
                hintLabel.Text = "Type a password hint (required):";
            }
            else
            {
                _mainForm.nextButton.Enabled = false;
                hintLabel.Text = "Type a password hint (required):";
            }
        }

        public void MainBtnClick()
        {
            Properties.Settings.Default.usernameStg = usernameString;
            Properties.Settings.Default.compNameStg = computerNameString;
            Properties.Settings.Default.passwordStg = passwordBox.Text;
            Properties.Settings.Default.confPassStg = confirmPassBox.Text;
            Properties.Settings.Default.passHintStg = passHintBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
