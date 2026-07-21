using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.ServiceProcess;
using ManagedNativeWifi;

namespace WindowsOOBERecreation
{
    public partial class Main : Form
    {
        private Panel mainPanel;
        public string Username { get; set; }
        public string ComputerName { get; set; }
        public int PageNumber = 0;

        private Image imgBackNotAllowed;
        private Image imgBackAllowed;
        private Image imgBackHovered;
        private Image imgBackPressed;

        private bool backDisabled = true;
        private bool isMouseDown = false;

        private readonly Stack<Func<Form>> history = new Stack<Func<Form>>();
        private Func<Form> currentPage;

        private readonly Task<bool> wlanServiceReady;

        private struct PageConfig
        {
            public bool BackEnabled;
            public bool ButtonPanel;
            public bool Next;
            public bool Skip;
        }

        private readonly Dictionary<Type, PageConfig> pageConfigs = new Dictionary<Type, PageConfig>
        {
            { typeof(Start),       new PageConfig { BackEnabled = false, ButtonPanel = true,  Next = true,  Skip = false } },
            { typeof(Password),    new PageConfig { BackEnabled = false, ButtonPanel = true,  Next = true,  Skip = false } },
            { typeof(ProductKey),  new PageConfig { BackEnabled = true,  ButtonPanel = true,  Next = true,  Skip = true  } },
            { typeof(Security),    new PageConfig { BackEnabled = true,  ButtonPanel = false, Next = false, Skip = false } },
            { typeof(TimeAndDate), new PageConfig { BackEnabled = true,  ButtonPanel = true,  Next = true,  Skip = false } },
            { typeof(Network),     new PageConfig { BackEnabled = true,  ButtonPanel = false, Next = false, Skip = false } },
            { typeof(Finalizing),  new PageConfig { BackEnabled = false, ButtonPanel = false, Next = false, Skip = false } },
            { typeof(WLAN),        new PageConfig { BackEnabled = true,  ButtonPanel = true,  Next = true,  Skip = true  } },
        };

        public Main()
        {
            InitializeComponent();
            // Start the WLAN service in the background so before the user gets to the WLAN page, it works as intended.
            wlanServiceReady = Task.Run(() => EnsureWlanServiceRunning());

            Background backgroundForm = new Background();
            backgroundForm.Show();
            
            imgBackNotAllowed = LoadImage(Properties.Resources.backnotallowed);
            imgBackAllowed = LoadImage(Properties.Resources.backallowed);
            imgBackHovered = LoadImage(Properties.Resources.backhovered);
            imgBackPressed = LoadImage(Properties.Resources.backpressed);

            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;

            this.TopMost = true;
            this.Controls.Add(mainPanel);

            this.Deactivate += Main_Deactivate;
            this.Activated += Main_Activated;

            LoadStartForm();
        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            basicPanel.BackColor = Color.FromArgb(215, 228, 242);
            displayPanel.BackColor = Color.FromArgb(182, 193, 204);
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            basicPanel.BackColor = Color.FromArgb(185, 209, 234);
            displayPanel.BackColor = Color.FromArgb(169, 191, 214);
        }

        private Image LoadImage(byte[] data) { using (var ms = new MemoryStream(data)) { return Image.FromStream(ms); } }
        private bool IsMouseOver(Control c) { return c.ClientRectangle.Contains(c.PointToClient(Cursor.Position)); }

        private void BackButtonPic_MouseEnter(object sender, EventArgs e)
        {
            if (backDisabled) return;
            UpdateBackButtonVisual();
        }

        private void BackButtonPic_MouseLeave(object sender, EventArgs e)
        {
            if (backDisabled) return;
            UpdateBackButtonVisual();
        }

        private void BackButtonPic_MouseDown(object sender, MouseEventArgs e)
        {
            if (backDisabled) return;
            if (e.Button != MouseButtons.Left) return;

            isMouseDown = true;
            UpdateBackButtonVisual();
        }

        private void BackButtonPic_MouseUp(object sender, MouseEventArgs e)
        {
            if (backDisabled) return;
            if (e.Button != MouseButtons.Left) return;

            isMouseDown = false;

            if (IsMouseOver(backButtonPic)) { GoBack(); }
            UpdateBackButtonVisual();
        }

        private void UpdateBackButtonVisual()
        {
            if (backDisabled)
            {
                backButtonPic.Image = imgBackNotAllowed;
                return;
            }
            if (isMouseDown)
            {
                backButtonPic.Image = imgBackPressed;
                return;
            }

            if (IsMouseOver(backButtonPic))
                backButtonPic.Image = imgBackHovered;
            else
                backButtonPic.Image = imgBackAllowed;
        }

        public void DisablePictureBox()
        {
            backDisabled = true;
            backButtonPic.Image = imgBackNotAllowed;
            backButtonPic.Tag = "backNotAllowed";
            DisablePictureBoxEvents();
        }

        public void EnablePictureBox()
        {
            backDisabled = false;
            backButtonPic.Image = imgBackAllowed;
            backButtonPic.Tag = "backAllowed";
            DisablePictureBoxEvents();
            EnablePictureBoxEvents();
        }

        public void DisablePictureBoxEvents()
        {
            backButtonPic.MouseEnter -= BackButtonPic_MouseEnter;
            backButtonPic.MouseLeave -= BackButtonPic_MouseLeave;
            backButtonPic.MouseDown -= BackButtonPic_MouseDown;
            backButtonPic.MouseUp -= BackButtonPic_MouseUp;
        }

        public void EnablePictureBoxEvents()
        {
            backButtonPic.MouseEnter += BackButtonPic_MouseEnter;
            backButtonPic.MouseLeave += BackButtonPic_MouseLeave;
            backButtonPic.MouseDown += BackButtonPic_MouseDown;
            backButtonPic.MouseUp += BackButtonPic_MouseUp;
        }

        public void NavigateTo(Func<Form> pageFactory)
        {
            if (currentPage != null) history.Push(currentPage);
            ShowPage(pageFactory);
        }

        public void GoBack()
        {
            if (history.Count == 0) return;
            ShowPage(history.Pop());
        }

        private void ShowPage(Func<Form> pageFactory)
        {
            currentPage = pageFactory;

            Form form = pageFactory();
            LoadFormIntoPanel(form);

            if (!pageConfigs.TryGetValue(form.GetType(), out PageConfig cfg)) return;

            buttonPanel.Visible = cfg.ButtonPanel;
            nextButton.Visible = cfg.Next;
            skipButton.Visible = cfg.Skip;

            if (cfg.BackEnabled && history.Count > 0) EnablePictureBox();
            else DisablePictureBox();
        }

        private void LoadFormIntoPanel(Form form)
        {
            foreach (Control c in mainPanel.Controls)
            {
                c.Dispose();
            }
            mainPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(form);

            // Recreate the focused link effect, like in 7's OOBE.
            AttachToLinkLabels(form);

            form.Show();
        }

        private void AttachToLinkLabels(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is LinkLabel) { Helper.AttachBorder(c); }
                AttachToLinkLabels(c);
            }
        }

        private void LoadStartForm() { NavigateTo(() => new Start(this)); }
        public void LoadPasswordForm() { NavigateTo(() => new Password(this, Username, ComputerName)); }
        public void LoadProductKeyForm() { NavigateTo(() => new ProductKey(this)); } // Unused, since we are not in a sysprepped install.
        public void LoadSecurityForm() { NavigateTo(() => new Security(this)); }
        public void LoadTimeAndDateForm() { NavigateTo(() => new TimeAndDate(this)); }
        private void LoadWlanForm() { NavigateTo(() => new WLAN(this)); }
        private void LoadNetworkForm() { NavigateTo(() => new Network(this)); }
        public void LoadFinalizingForm() { NavigateTo(() => new Finalizing(this)); }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (mainPanel.Controls[0] is Start startForm)
            {
                startForm.MainBtnClick();
                LoadPasswordForm();
            }
            else if (mainPanel.Controls[0] is Password pwForm)
            {
                pwForm.MainBtnClick();
                LoadProductKeyForm();
            }
            else if (mainPanel.Controls[0] is ProductKey productKeyForm) { LoadSecurityForm(); }
            else if (mainPanel.Controls[0] is Security securityForm)
            {
                // Do nothing, security handles it.
            }
            else if (mainPanel.Controls[0] is TimeAndDate timeAndDateForm)
            {
                bool hasInternetConnectivity = HasInternet();
                bool hasWlanSupport = HasWlanSupport();

                if (hasWlanSupport) { LoadWlanForm(); }
                else if (hasInternetConnectivity) { LoadNetworkForm(); }
                else { LoadFinalizingForm(); }
            }
            else if (mainPanel.Controls[0] is WLAN wlanForm)
            {
                _ = wlanForm.ConnectToSelectedAsync();
                LoadNetworkForm();
            }
            else if (mainPanel.Controls[0] is Network nwForm)
            {
                // Do nothing, network handles it.
            }
        }

        private void skipButton_Click(object sender, EventArgs e) 
        {
            if (mainPanel.Controls[0] is ProductKey productKeyForm) { LoadSecurityForm(); }
            else if (mainPanel.Controls[0] is WLAN wlanForm) { LoadNetworkForm(); }
        }

        bool HasInternet()
        {
            try
            {
                using (var client = new WebClient())
                // MSFT killed their old .txt file, and now it leads to an SSL error, this is a better example!
                using (client.OpenRead("https://raw.githubusercontent.com/frictionlessdata/examples/refs/heads/main/text-file/text-file.txt")) { return true; }
            }
            catch { return false; }
        }

        bool HasWlanSupport()
        {
            if (!wlanServiceReady.Result) return false;

            try { return NativeWifi.EnumerateInterfaces().Any(); }
            catch { return false; }
        }

        bool EnsureWlanServiceRunning()
        {
            try
            {
                using (ServiceController wlanService = new ServiceController("Wlansvc"))
                {
                    if (wlanService.Status == ServiceControllerStatus.Running) return true;
                    if (wlanService.Status == ServiceControllerStatus.Stopped) wlanService.Start();

                    wlanService.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(15));
                    return true;
                }
            }
            catch { return false; }
        }
    }
}