namespace WindowsOOBERecreation
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.basicPanel = new System.Windows.Forms.Panel();
            this.backButtonPic = new System.Windows.Forms.PictureBox();
            this.iconPicBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new WindowsOOBERecreation.MainPanel();
            this.skipButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.basicPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPicBox)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // basicPanel
            // 
            this.basicPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.basicPanel.Controls.Add(this.backButtonPic);
            this.basicPanel.Controls.Add(this.iconPicBox);
            this.basicPanel.Controls.Add(this.titleLabel);
            this.basicPanel.Location = new System.Drawing.Point(0, 0);
            this.basicPanel.Name = "basicPanel";
            this.basicPanel.Size = new System.Drawing.Size(593, 31);
            this.basicPanel.TabIndex = 0;
            // 
            // backButtonPic
            // 
            this.backButtonPic.BackColor = System.Drawing.Color.Transparent;
            this.backButtonPic.Image = ((System.Drawing.Image)(resources.GetObject("backButtonPic.Image")));
            this.backButtonPic.Location = new System.Drawing.Point(0, 0);
            this.backButtonPic.Name = "backButtonPic";
            this.backButtonPic.Size = new System.Drawing.Size(31, 31);
            this.backButtonPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backButtonPic.TabIndex = 2;
            this.backButtonPic.TabStop = false;
            // 
            // iconPicBox
            // 
            this.iconPicBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPicBox.Image = global::WindowsOOBERecreation.Properties.Resources.oobe;
            this.iconPicBox.Location = new System.Drawing.Point(37, 7);
            this.iconPicBox.Name = "iconPicBox";
            this.iconPicBox.Size = new System.Drawing.Size(16, 16);
            this.iconPicBox.TabIndex = 2;
            this.iconPicBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(57, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(93, 15);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Set Up Windows";
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(191)))), ((int)(((byte)(214)))));
            this.displayPanel.Location = new System.Drawing.Point(0, 30);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(593, 1);
            this.displayPanel.TabIndex = 1;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonPanel.Controls.Add(this.skipButton);
            this.buttonPanel.Controls.Add(this.nextButton);
            this.buttonPanel.Location = new System.Drawing.Point(0, 426);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(593, 40);
            this.buttonPanel.TabIndex = 10;
            // 
            // skipButton
            // 
            this.skipButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.skipButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skipButton.Location = new System.Drawing.Point(439, 8);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(68, 23);
            this.skipButton.TabIndex = 8;
            this.skipButton.Text = "Skip";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Visible = false;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(515, 8);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(68, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.ControlBox = false;
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.basicPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "‎ ";
            this.basicPanel.ResumeLayout(false);
            this.basicPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPicBox)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel basicPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.PictureBox iconPicBox;
        public System.Windows.Forms.PictureBox backButtonPic;
        public WindowsOOBERecreation.MainPanel buttonPanel;
        public System.Windows.Forms.Button nextButton;
        public System.Windows.Forms.Button skipButton;
    }
}