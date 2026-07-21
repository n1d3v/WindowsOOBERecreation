using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class HiddenWifi : Form
    {
        public HiddenWifi()
        {
            InitializeComponent();

            nwNameBox.AutoSize = false;
            nwNameBox.Height = 20;

            secTypeBox.SelectedItem = "WPA2-PSK";
            encTypeBox.SelectedItem = "AES";
        }

        private void cancelButton_Click(object sender, EventArgs e) { this.Close(); }
        private void okButton_Click(object sender, EventArgs e) {}
    }
}