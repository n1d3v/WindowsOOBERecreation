using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedNativeWifi;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace WindowsOOBERecreation
{
    public partial class WLAN : Form
    {
        private WifiItem expandedItem = null;
        private Main _mainForm;
        private readonly Dictionary<WifiItem, AvailableNetworkPack> _networks = new Dictionary<WifiItem, AvailableNetworkPack>();

        public WLAN(Main mainForm)
        {
            InitializeComponent();
            DisplayScannedNetworks();

            _mainForm = mainForm;
            this.AcceptButton = _mainForm.nextButton;
        }

        private static Task ScanForNetworks()  { return NativeWifi.ScanNetworksAsync(ScanMode.OnlyNotConnected, null, null, TimeSpan.FromSeconds(10), CancellationToken.None);  }

        private async void DisplayScannedNetworks()
        {
            try
            {
                if (NativeWifi.EnumerateInterfaces().Any())
                {
                    await ScanForNetworks();
                    var scannedNetworks = NativeWifi.EnumerateAvailableNetworks();

                    wifiPanel.Controls.Clear();
                    _networks.Clear();
                    scanLabel.Visible = false;

                    foreach (var network in scannedNetworks)
                    {
                        // It likely isn't a real network, and it's the library hallucinating.
                        if (network.Ssid.ToString() == string.Empty) continue;

                        WifiItem item = new WifiItem(
                            network.Ssid.ToString(),
                            network.IsSecurityEnabled,
                            network.SignalQuality
                        );

                        _networks[item] = network;
                        AddItem(item);
                    }
                }
            }
            catch {}
        }

        private void AddItem(WifiItem item)
        {
            item.Dock = DockStyle.Top;
            item.Margin = Padding.Empty;

            item.WifiItemClicked += WifiItem_Click;

            wifiPanel.Controls.Add(item);
            wifiPanel.Controls.SetChildIndex(item, 0);

            UpdatePanelHeight();
        }

        private void WifiItem_Click(object sender, EventArgs e)
        {
            WifiItem item = sender as WifiItem;
            if (item == null) return;

            if (expandedItem != null && expandedItem != item)
            {
                bool suppressScroll = !wifiPanel.VerticalScroll.Visible;
                if (suppressScroll) wifiPanel.AutoScroll = false;

                int pending = 2;
                EventHandler onComplete = null;
                onComplete = (s, _) =>
                {
                    ((WifiItem)s).AnimationComplete -= onComplete;
                    if (--pending == 0)
                    {
                        if (suppressScroll) wifiPanel.AutoScroll = true;
                        UpdatePanelHeight();
                    }
                };

                expandedItem.AnimationComplete += onComplete;
                expandedItem.Collapse();

                item.AnimationComplete += onComplete;
                item.Expand();
                expandedItem = item;

                wifiPanel.Invalidate();
            }
            else
            {
                item.Expand();
                expandedItem = item;

                UpdatePanelHeight();
                wifiPanel.Invalidate();
            }
        }

        private void UpdatePanelHeight()
        {
            int totalHeight = 0;

            foreach (Control c in wifiPanel.Controls)
            {
                WifiItem item = c as WifiItem;
                totalHeight += (item?.targetHeightImmediate ?? c.Height) + c.Margin.Vertical;
            }

            wifiPanel.Height = Math.Min(totalHeight + 4, 221);
        }

        public async Task<bool> ConnectToSelectedAsync()
        {
            if (expandedItem == null) return false;
            if (!_networks.TryGetValue(expandedItem, out var network)) return false;

            return await WlanConnection.ConnectToNetworkAsync(network, expandedItem.SecurityKey, expandedItem.AutoConnect);
        }

        private void hiddenWlanLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
             Don't include this just yet.
             HiddenWifi hiddenWifi = new HiddenWifi();
             hiddenWifi.ShowDialog();
             */
            MessageBox.Show("Sorry, this feature isn't finished. Please come back later!", "WindowsOOBERecreation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (expandedItem != null)
            {
                expandedItem.Collapse();
                expandedItem = null;
            }

            scanLabel.Visible = true;
            DisplayScannedNetworks();
        }
    }
}