
namespace WindowsOOBERecreation
{
    partial class WifiItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wifiSsid = new System.Windows.Forms.Label();
            this.wifiSecType = new System.Windows.Forms.Label();
            this.wifiSignal = new System.Windows.Forms.PictureBox();
            this.secKeyLabel = new System.Windows.Forms.Label();
            this.secKeyBox = new System.Windows.Forms.TextBox();
            this.autoConnectChk = new System.Windows.Forms.CheckBox();
            this.extendedWifiProperties = new System.Windows.Forms.Panel();
            this.unsecNotice = new System.Windows.Forms.Label();
            this.unsecLabel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wifiSignal)).BeginInit();
            this.extendedWifiProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unsecLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // wifiSsid
            // 
            this.wifiSsid.BackColor = System.Drawing.Color.Transparent;
            this.wifiSsid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wifiSsid.Location = new System.Drawing.Point(14, 9);
            this.wifiSsid.Name = "wifiSsid";
            this.wifiSsid.Size = new System.Drawing.Size(120, 23);
            this.wifiSsid.TabIndex = 0;
            this.wifiSsid.Text = "Wi-Fi Network";
            this.wifiSsid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wifiSecType
            // 
            this.wifiSecType.BackColor = System.Drawing.Color.Transparent;
            this.wifiSecType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wifiSecType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.wifiSecType.Location = new System.Drawing.Point(144, 9);
            this.wifiSecType.Name = "wifiSecType";
            this.wifiSecType.Size = new System.Drawing.Size(240, 23);
            this.wifiSecType.TabIndex = 1;
            this.wifiSecType.Text = "Security-enabled network";
            this.wifiSecType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wifiSignal
            // 
            this.wifiSignal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wifiSignal.BackColor = System.Drawing.Color.Transparent;
            this.wifiSignal.Image = global::WindowsOOBERecreation.Properties.Resources.strength_5;
            this.wifiSignal.Location = new System.Drawing.Point(395, 5);
            this.wifiSignal.Name = "wifiSignal";
            this.wifiSignal.Size = new System.Drawing.Size(32, 32);
            this.wifiSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.wifiSignal.TabIndex = 2;
            this.wifiSignal.TabStop = false;
            // 
            // secKeyLabel
            // 
            this.secKeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.secKeyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secKeyLabel.Location = new System.Drawing.Point(-2, 1);
            this.secKeyLabel.Name = "secKeyLabel";
            this.secKeyLabel.Size = new System.Drawing.Size(111, 23);
            this.secKeyLabel.TabIndex = 3;
            this.secKeyLabel.Text = "Security key:";
            this.secKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // secKeyBox
            // 
            this.secKeyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secKeyBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secKeyBox.Location = new System.Drawing.Point(109, 3);
            this.secKeyBox.Name = "secKeyBox";
            this.secKeyBox.Size = new System.Drawing.Size(302, 23);
            this.secKeyBox.TabIndex = 4;
            // 
            // autoConnectChk
            // 
            this.autoConnectChk.AutoSize = true;
            this.autoConnectChk.BackColor = System.Drawing.Color.Transparent;
            this.autoConnectChk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.autoConnectChk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoConnectChk.Location = new System.Drawing.Point(0, 26);
            this.autoConnectChk.Name = "autoConnectChk";
            this.autoConnectChk.Size = new System.Drawing.Size(216, 20);
            this.autoConnectChk.TabIndex = 5;
            this.autoConnectChk.Text = "Start this connection automatically";
            this.autoConnectChk.UseVisualStyleBackColor = false;
            // 
            // extendedWifiProperties
            // 
            this.extendedWifiProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extendedWifiProperties.BackColor = System.Drawing.Color.Transparent;
            this.extendedWifiProperties.Controls.Add(this.secKeyBox);
            this.extendedWifiProperties.Controls.Add(this.secKeyLabel);
            this.extendedWifiProperties.Controls.Add(this.unsecNotice);
            this.extendedWifiProperties.Controls.Add(this.unsecLabel);
            this.extendedWifiProperties.Controls.Add(this.autoConnectChk);
            this.extendedWifiProperties.Location = new System.Drawing.Point(16, 34);
            this.extendedWifiProperties.Name = "extendedWifiProperties";
            this.extendedWifiProperties.Size = new System.Drawing.Size(411, 54);
            this.extendedWifiProperties.TabIndex = 6;
            this.extendedWifiProperties.Visible = false;
            // 
            // unsecNotice
            // 
            this.unsecNotice.AutoSize = true;
            this.unsecNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unsecNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.unsecNotice.Location = new System.Drawing.Point(19, 8);
            this.unsecNotice.Name = "unsecNotice";
            this.unsecNotice.Size = new System.Drawing.Size(324, 15);
            this.unsecNotice.TabIndex = 7;
            this.unsecNotice.Text = "Joining an unsecured network can put your computer at risk";
            // 
            // unsecLabel
            // 
            this.unsecLabel.Image = global::WindowsOOBERecreation.Properties.Resources.warning_icon;
            this.unsecLabel.Location = new System.Drawing.Point(-1, 7);
            this.unsecLabel.Name = "unsecLabel";
            this.unsecLabel.Size = new System.Drawing.Size(16, 16);
            this.unsecLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.unsecLabel.TabIndex = 6;
            this.unsecLabel.TabStop = false;
            // 
            // WifiItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extendedWifiProperties);
            this.Controls.Add(this.wifiSignal);
            this.Controls.Add(this.wifiSecType);
            this.Controls.Add(this.wifiSsid);
            this.Name = "WifiItem";
            this.Size = new System.Drawing.Size(442, 88);
            ((System.ComponentModel.ISupportInitialize)(this.wifiSignal)).EndInit();
            this.extendedWifiProperties.ResumeLayout(false);
            this.extendedWifiProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unsecLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wifiSsid;
        private System.Windows.Forms.Label wifiSecType;
        private System.Windows.Forms.PictureBox wifiSignal;
        private System.Windows.Forms.Label secKeyLabel;
        private System.Windows.Forms.TextBox secKeyBox;
        private System.Windows.Forms.CheckBox autoConnectChk;
        private System.Windows.Forms.Panel extendedWifiProperties;
        private System.Windows.Forms.PictureBox unsecLabel;
        private System.Windows.Forms.Label unsecNotice;
    }
}
