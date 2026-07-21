using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WindowsOOBERecreation
{
    public partial class Network : Form
    {
        private Main _mainForm;

        public Network(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            AddCommandLink(networkPanel, "Home network", "If all the computers on this network are at your home, and you recognize them, this is a trusted home network. Don't choose this for public places such as coffee shops or airports.", new Icon(Path.Combine(Application.StartupPath, "Icons\\home.ico"), new Size(48, 48)), SetNetwork_Handler, new Size(536, 87), "Home");
            AddCommandLink(networkPanel, "Work network", "If all the computers on this network are at your workplace, and you recognize them, this is a trusted work network. Don't choose this for public places such as coffee shops or airports.", new Icon(Path.Combine(Application.StartupPath, "Icons\\work.ico"), new Size(48, 48)), SetNetwork_Handler, new Size(536, 87), "Work");
            AddCommandLink(networkPanel, "Public network", "If you don't recognize all the computers on the network (for example, you're in a coffee shop or airport, or you have mobile broadband), this is a public network and is not trusted.", new Icon(Path.Combine(Application.StartupPath, "Icons\\public.ico"), new Size(48, 48)), SetNetwork_Handler, new Size(536, 87), "Public");
        }

        private void AddCommandLink(Panel targetPanel, string text, string note, Icon icon, EventHandler onClick, Size? size = null, string tag = "")
        {
            CommandLink cmdLink = new CommandLink
            {
                Text = text,
                Note = note,
                Icon = icon,
                Size = size ?? new Size(500, 60),
                Tag = tag
            };

            if (onClick != null)
            {
                cmdLink.Click += onClick;
            }

            cmdLink.Margin = new Padding(0);
            targetPanel.Controls.Add(cmdLink);
        }

        private void SetNetwork_Handler(object sender, EventArgs e)
        {
            CommandLink cmdLink = (CommandLink)sender;
            string tag = cmdLink.Tag.ToString();

            NetworkLocation nwLocation;

            switch (tag)
            {
                case "Home":
                    nwLocation = NetworkLocation.Home;
                    break;
                case "Work":
                    nwLocation = NetworkLocation.Work;
                    break;
                default:
                    nwLocation = NetworkLocation.Public;
                    break;
            }

            ApplyNetworkLocation(nwLocation);
            _mainForm.LoadFinalizingForm();
        }

        private void ApplyNetworkLocation(NetworkLocation nwLocation)
        {
            NetworkLocationManager.Apply(nwLocation);
            if (NetworkLocationManager.LocationUsesHomeGroup(nwLocation)) { NetworkLocationManager.EnsureHomeGroup(); }
        }
    }
}