using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class ProductKey : Form
    {
        private Main _mainForm;

        public ProductKey(Main mainForm)
        {
            _mainForm = mainForm;
            this.AcceptButton = _mainForm.nextButton;
            InitializeComponent();
        }

        // This adds the - between the product key
        private void ProductKeyBox_TextChanged(object sender, EventArgs e)
        {
            string input = new string(productKeyBox.Text.Where(char.IsLetterOrDigit).ToArray());
            input = input.ToUpper();

            if (input.Length > 25)
            {
                input = input.Substring(0, 25);
            }

            StringBuilder formattedInput = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && i % 5 == 0)
                {
                    formattedInput.Append("-");
                }
                formattedInput.Append(input[i]);
            }

            productKeyBox.TextChanged -= ProductKeyBox_TextChanged;
            productKeyBox.Text = formattedInput.ToString();
            productKeyBox.SelectionStart = productKeyBox.Text.Length;
            productKeyBox.TextChanged += ProductKeyBox_TextChanged;
        }

        private void ProductKey_Load(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.backallowed))
            {
                _mainForm.backButtonPic.Image = Image.FromStream(ms);
            }
        }

        private void WIALabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpForm helpForm = new HelpForm(Path.Combine(Application.StartupPath, @"Help Files\activationHelp.rtf"));
            helpForm.ShowDialog();
        }

        private void PSLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpForm helpForm = new HelpForm(Path.Combine(Application.StartupPath, @"Help Files\sevenPrivacyStatement.rtf"));
            helpForm.ShowDialog();
        }
    }
}
