using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsOOBERecreation.Enums;
using WindowsOOBERecreation.Interfaces;

namespace WindowsOOBERecreation
{
    public partial class ProductKey : Form, IOobePage
    {
        private Main _mainForm;
        public EOobePage Page => EOobePage.ProductKey;

        public ProductKey(Main mainForm)
        {
            _mainForm = mainForm;
            _mainForm.EnablePictureBox();
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
    }
}
