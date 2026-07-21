
namespace WindowsOOBERecreation
{
    partial class HiddenWifi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HiddenWifi));
            this.dlgLabel = new System.Windows.Forms.Label();
            this.nwNameLbl = new System.Windows.Forms.Label();
            this.secTypeLbl = new System.Windows.Forms.Label();
            this.encTypeLbl = new System.Windows.Forms.Label();
            this.nwNameBox = new System.Windows.Forms.TextBox();
            this.secTypeBox = new System.Windows.Forms.ComboBox();
            this.encTypeBox = new System.Windows.Forms.ComboBox();
            this.buttonPanel = new WindowsOOBERecreation.MainPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgLabel
            // 
            this.dlgLabel.AutoSize = true;
            this.dlgLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlgLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.dlgLabel.Location = new System.Drawing.Point(20, 10);
            this.dlgLabel.Name = "dlgLabel";
            this.dlgLabel.Size = new System.Drawing.Size(355, 21);
            this.dlgLabel.TabIndex = 0;
            this.dlgLabel.Text = "Enter information for the hidden wireless network";
            // 
            // nwNameLbl
            // 
            this.nwNameLbl.AutoSize = true;
            this.nwNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nwNameLbl.Location = new System.Drawing.Point(21, 51);
            this.nwNameLbl.Name = "nwNameLbl";
            this.nwNameLbl.Size = new System.Drawing.Size(88, 15);
            this.nwNameLbl.TabIndex = 1;
            this.nwNameLbl.Text = "Network name:";
            // 
            // secTypeLbl
            // 
            this.secTypeLbl.AutoSize = true;
            this.secTypeLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secTypeLbl.Location = new System.Drawing.Point(21, 83);
            this.secTypeLbl.Name = "secTypeLbl";
            this.secTypeLbl.Size = new System.Drawing.Size(78, 15);
            this.secTypeLbl.TabIndex = 2;
            this.secTypeLbl.Text = "Security type:";
            // 
            // encTypeLbl
            // 
            this.encTypeLbl.AutoSize = true;
            this.encTypeLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encTypeLbl.Location = new System.Drawing.Point(21, 116);
            this.encTypeLbl.Name = "encTypeLbl";
            this.encTypeLbl.Size = new System.Drawing.Size(93, 15);
            this.encTypeLbl.TabIndex = 3;
            this.encTypeLbl.Text = "Encryption type:";
            // 
            // nwNameBox
            // 
            this.nwNameBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nwNameBox.Location = new System.Drawing.Point(197, 51);
            this.nwNameBox.Name = "nwNameBox";
            this.nwNameBox.Size = new System.Drawing.Size(175, 23);
            this.nwNameBox.TabIndex = 4;
            // 
            // secTypeBox
            // 
            this.secTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secTypeBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secTypeBox.FormattingEnabled = true;
            this.secTypeBox.Items.AddRange(new object[] {
            "WPA2-PSK",
            "WPA-PSK",
            "WPA2",
            "WPA",
            "WEP",
            "Open"});
            this.secTypeBox.Location = new System.Drawing.Point(197, 83);
            this.secTypeBox.Name = "secTypeBox";
            this.secTypeBox.Size = new System.Drawing.Size(175, 23);
            this.secTypeBox.TabIndex = 5;
            // 
            // encTypeBox
            // 
            this.encTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encTypeBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encTypeBox.FormattingEnabled = true;
            this.encTypeBox.Items.AddRange(new object[] {
            "AES",
            "TKIP"});
            this.encTypeBox.Location = new System.Drawing.Point(197, 116);
            this.encTypeBox.Name = "encTypeBox";
            this.encTypeBox.Size = new System.Drawing.Size(175, 23);
            this.encTypeBox.TabIndex = 6;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Location = new System.Drawing.Point(0, 187);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(425, 43);
            this.buttonPanel.TabIndex = 7;
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(244, 9);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(328, 9);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // HiddenWifi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 230);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.encTypeBox);
            this.Controls.Add(this.secTypeBox);
            this.Controls.Add(this.nwNameBox);
            this.Controls.Add(this.encTypeLbl);
            this.Controls.Add(this.secTypeLbl);
            this.Controls.Add(this.nwNameLbl);
            this.Controls.Add(this.dlgLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HiddenWifi";
            this.Text = "Connect to a Hidden Network";
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dlgLabel;
        private System.Windows.Forms.Label nwNameLbl;
        private System.Windows.Forms.Label secTypeLbl;
        private System.Windows.Forms.Label encTypeLbl;
        private System.Windows.Forms.TextBox nwNameBox;
        private System.Windows.Forms.ComboBox secTypeBox;
        private System.Windows.Forms.ComboBox encTypeBox;
        private MainPanel buttonPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}