
namespace WindowsOOBERecreation
{
    partial class WLAN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.wlanDesc = new System.Windows.Forms.Label();
            this.hiddenWlanLink = new System.Windows.Forms.LinkLabel();
            this.refreshLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.wifiPanel = new WindowsOOBERecreation.BorderPanel();
            this.scanLabel = new System.Windows.Forms.Label();
            this.wifiPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(34, 50);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(171, 21);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Join a wireless network";
            // 
            // wlanDesc
            // 
            this.wlanDesc.AutoSize = true;
            this.wlanDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wlanDesc.Location = new System.Drawing.Point(37, 90);
            this.wlanDesc.Name = "wlanDesc";
            this.wlanDesc.Size = new System.Drawing.Size(523, 30);
            this.wlanDesc.TabIndex = 1;
            this.wlanDesc.Text = "Please choose your wireless network. If you don\'t know your wireless network deta" +
    "ils, you can skip\r\nthis step and do it later.";
            // 
            // hiddenWlanLink
            // 
            this.hiddenWlanLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.hiddenWlanLink.AutoSize = true;
            this.hiddenWlanLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiddenWlanLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.hiddenWlanLink.Location = new System.Drawing.Point(35, 390);
            this.hiddenWlanLink.Name = "hiddenWlanLink";
            this.hiddenWlanLink.Size = new System.Drawing.Size(205, 15);
            this.hiddenWlanLink.TabIndex = 2;
            this.hiddenWlanLink.TabStop = true;
            this.hiddenWlanLink.Text = "Connect to a hidden wireless network";
            this.hiddenWlanLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.hiddenWlanLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hiddenWlanLink_LinkClicked);
            // 
            // refreshLabel
            // 
            this.refreshLabel.AutoSize = true;
            this.refreshLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshLabel.Location = new System.Drawing.Point(485, 129);
            this.refreshLabel.Name = "refreshLabel";
            this.refreshLabel.Size = new System.Drawing.Size(46, 15);
            this.refreshLabel.TabIndex = 4;
            this.refreshLabel.Text = "Refresh";
            // 
            // refreshButton
            // 
            this.refreshButton.Image = global::WindowsOOBERecreation.Properties.Resources.refresh;
            this.refreshButton.Location = new System.Drawing.Point(446, 125);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(32, 24);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // wifiPanel
            // 
            this.wifiPanel.AutoScroll = true;
            this.wifiPanel.Controls.Add(this.scanLabel);
            this.wifiPanel.Location = new System.Drawing.Point(83, 154);
            this.wifiPanel.Margin = new System.Windows.Forms.Padding(0);
            this.wifiPanel.Name = "wifiPanel";
            this.wifiPanel.Padding = new System.Windows.Forms.Padding(2);
            this.wifiPanel.Size = new System.Drawing.Size(446, 46);
            this.wifiPanel.TabIndex = 1;
            // 
            // scanLabel
            // 
            this.scanLabel.AutoSize = true;
            this.scanLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scanLabel.Location = new System.Drawing.Point(154, 13);
            this.scanLabel.Name = "scanLabel";
            this.scanLabel.Size = new System.Drawing.Size(134, 15);
            this.scanLabel.TabIndex = 0;
            this.scanLabel.Text = "Scanning for networks...";
            // 
            // WLAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.Controls.Add(this.wifiPanel);
            this.Controls.Add(this.refreshLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.hiddenWlanLink);
            this.Controls.Add(this.wlanDesc);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WLAN";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.wifiPanel.ResumeLayout(false);
            this.wifiPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label wlanDesc;
        private System.Windows.Forms.LinkLabel hiddenWlanLink;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label refreshLabel;
        private BorderPanel wifiPanel;
        private System.Windows.Forms.Label scanLabel;
    }
}

