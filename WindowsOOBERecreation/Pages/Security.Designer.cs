
namespace WindowsOOBERecreation
{
    partial class Security
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Security));
            this.titleLabel = new System.Windows.Forms.Label();
            this.securityPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.undLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.PSLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(34, 51);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(460, 21);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Help protect your computer and improve Windows automatically";
            // 
            // securityPanel
            // 
            this.securityPanel.Location = new System.Drawing.Point(38, 91);
            this.securityPanel.Name = "securityPanel";
            this.securityPanel.Size = new System.Drawing.Size(539, 186);
            this.securityPanel.TabIndex = 11;
            // 
            // undLabel
            // 
            this.undLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.undLabel.AutoSize = true;
            this.undLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.undLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.undLabel.Location = new System.Drawing.Point(35, 299);
            this.undLabel.Name = "undLabel";
            this.undLabel.Size = new System.Drawing.Size(167, 15);
            this.undLabel.TabIndex = 25;
            this.undLabel.TabStop = true;
            this.undLabel.Text = "Learn more about each option";
            this.undLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.undLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 45);
            this.label1.TabIndex = 26;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // PSLabel
            // 
            this.PSLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.PSLabel.AutoSize = true;
            this.PSLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PSLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.PSLabel.Location = new System.Drawing.Point(406, 348);
            this.PSLabel.Name = "PSLabel";
            this.PSLabel.Size = new System.Drawing.Size(150, 15);
            this.PSLabel.TabIndex = 27;
            this.PSLabel.TabStop = true;
            this.PSLabel.Text = "Read the privacy statement";
            this.PSLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PSLabel_LinkClicked);
            // 
            // Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.Controls.Add(this.PSLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.undLabel);
            this.Controls.Add(this.securityPanel);
            this.Controls.Add(this.titleLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Security";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel securityPanel;
        private System.Windows.Forms.LinkLabel undLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel PSLabel;
    }
}