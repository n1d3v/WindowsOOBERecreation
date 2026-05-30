using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using WindowsOOBERecreation.Enums;
using WindowsOOBERecreation.Interfaces;

namespace WindowsOOBERecreation
{
    public partial class Main : Form
    {
        private Panel mainPanel;
        private readonly Stack<EOobePage> navigationStack = new Stack<EOobePage>();

        public string Username { get; set; }
        public string ComputerName { get; set; }
        public int PageNumber = 0;

        private Image imgBackNotAllowed;
        private Image imgBackAllowed;
        private Image imgBackHovered;
        private Image imgBackPressed;

        private bool backDisabled = true;
        private bool isMouseDown = false;

        public Main()
        {
            InitializeComponent();

            Background backgroundForm = new Background();
            backgroundForm.Show();

            imgBackNotAllowed = LoadImage(Properties.Resources.backnotallowed);
            imgBackAllowed = LoadImage(Properties.Resources.backallowed);
            imgBackHovered = LoadImage(Properties.Resources.backhovered);
            imgBackPressed = LoadImage(Properties.Resources.backpressed);

            mainPanel = new Panel {
                Dock = DockStyle.Fill
            };

            TopMost = true;
            Controls.Add(mainPanel);

            LoadPage(EOobePage.Start);
            EnablePictureBoxEvents();
        }

        private Image LoadImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private bool IsMouseOver(Control c)
        {
            return c.ClientRectangle.Contains(c.PointToClient(Cursor.Position));
        }

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

            if (IsMouseOver(backButtonPic)) { HandleBackNav(); }
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

        public void LoadPage(EOobePage page, bool pushToStack = true) {
            Form form;

            switch (page) {
                case EOobePage.Start:
                    form = new Start(this);
                    break;
                case EOobePage.Password:
                    form = new Password(this, Username, ComputerName);
                    break;
                case EOobePage.Security:
                    form = new Security(this);
                    break;
                case EOobePage.TimeAndDate:
                    form = new TimeAndDate(this);
                    break;
                case EOobePage.Network:
                    form = new Network(this);
                    break;
                case EOobePage.ProductKey:
                    form = new ProductKey(this);
                    break;
                case EOobePage.Finalizing:
                    form = new Finalizing(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(page), page, null);
            }

            if (pushToStack) 
            {
                navigationStack.Push(page);
            }

            LoadFormIntoPanel(form);
        }

        public void GoBack() {
            if (navigationStack.Count <= 1) { return; }

            navigationStack.Pop();

            EOobePage previous = navigationStack.Peek();
            LoadPage(previous, pushToStack: false);

            if (previous == EOobePage.Password || previous == EOobePage.Start) {
                buttonPanel.Visible = true;
                nextButton.Visible = true;
            }
            else if (previous == EOobePage.Security) {
                buttonPanel.Visible = true;
                nextButton.Visible = true;
            }
            else if (previous == EOobePage.TimeAndDate) {
                buttonPanel.Visible = false;
                nextButton.Visible = false;
            }
        }

        public void HandleBackNav() {
            GoBack();
        }

        public void LoadFormIntoPanel(Form form) {
            foreach (Control c in mainPanel.Controls) { c.Dispose(); }

            mainPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (mainPanel.Controls[0] is not IOobePage page) { return; }

            switch (page.Page) {
                case EOobePage.Start:
                    ((Start)page).MainBtnClick();
                    LoadPage(EOobePage.Password);
                    break;
                case EOobePage.Password:
                    ((Password)page).MainBtnClick();

                    buttonPanel.Visible = false;
                    nextButton.Visible = false;

                    LoadPage(EOobePage.Security);
                    break;
                case EOobePage.Security:
                    // Do nothing, security handles it.
                    break;
                case EOobePage.TimeAndDate:
                    buttonPanel.Visible = false;
                    nextButton.Visible = false;

                    bool wifiConnected = false;

                    foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces()) 
                    {
                        if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && ni.OperationalStatus == OperationalStatus.Up) 
                        {
                            wifiConnected = true;
                            break;
                        }
                    }

                    LoadPage(wifiConnected ? EOobePage.Network : EOobePage.Finalizing);
                    break;
                case EOobePage.Network:
                    break;
            }
        }
    }
}