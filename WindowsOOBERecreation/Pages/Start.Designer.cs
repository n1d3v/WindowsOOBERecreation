namespace WindowsOOBERecreation
{
    partial class Start
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.computerNameBox = new System.Windows.Forms.TextBox();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.EOAPic = new System.Windows.Forms.PictureBox();
            this.windowsBrandingPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EOAPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsBrandingPic)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(167, 203);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(206, 15);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Type a user name (for example, John):";
            // 
            // usernameBox
            // 
            this.usernameBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.Location = new System.Drawing.Point(168, 218);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(240, 23);
            this.usernameBox.TabIndex = 0;
            // 
            // computerNameBox
            // 
            this.computerNameBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.computerNameBox.Location = new System.Drawing.Point(168, 261);
            this.computerNameBox.Name = "computerNameBox";
            this.computerNameBox.Size = new System.Drawing.Size(240, 23);
            this.computerNameBox.TabIndex = 1;
            this.computerNameBox.Text = "PC";
            this.computerNameBox.TextChanged += new System.EventHandler(this.computerNameBox_TextChanged);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.Location = new System.Drawing.Point(262, 408);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(328, 15);
            this.copyrightLabel.TabIndex = 7;
            this.copyrightLabel.Text = "Copyright © 2009 Microsoft Corporation.  All rights reserved.";
            // 
            // EOAPic
            // 
            this.EOAPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EOAPic.Image = global::WindowsOOBERecreation.Properties.Resources.image;
            this.EOAPic.Location = new System.Drawing.Point(11, 397);
            this.EOAPic.Name = "EOAPic";
            this.EOAPic.Size = new System.Drawing.Size(24, 24);
            this.EOAPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EOAPic.TabIndex = 2;
            this.EOAPic.TabStop = true;
            this.EOAPic.Click += new System.EventHandler(this.EOAPic_Click);
            // 
            // windowsBrandingPic
            // 
            this.windowsBrandingPic.Image = global::WindowsOOBERecreation.Properties.Resources.branding;
            this.windowsBrandingPic.Location = new System.Drawing.Point(67, 91);
            this.windowsBrandingPic.Name = "windowsBrandingPic";
            this.windowsBrandingPic.Size = new System.Drawing.Size(458, 72);
            this.windowsBrandingPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.windowsBrandingPic.TabIndex = 0;
            this.windowsBrandingPic.TabStop = false;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.Controls.Add(this.EOAPic);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.computerNameBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.windowsBrandingPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Start";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.EOAPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsBrandingPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox windowsBrandingPic;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox computerNameBox;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.PictureBox EOAPic;
    }
}

