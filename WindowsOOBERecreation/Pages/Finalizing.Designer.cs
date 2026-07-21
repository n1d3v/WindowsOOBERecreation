namespace WindowsOOBERecreation
{
    partial class Finalizing
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
            this.finalizingProgBar = new System.Windows.Forms.ProgressBar();
            this.finalizingLabel = new System.Windows.Forms.Label();
            this.windowsBrandingPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.windowsBrandingPic)).BeginInit();
            this.SuspendLayout();
            // 
            // finalizingProgBar
            // 
            this.finalizingProgBar.Location = new System.Drawing.Point(107, 225);
            this.finalizingProgBar.Name = "finalizingProgBar";
            this.finalizingProgBar.Size = new System.Drawing.Size(396, 15);
            this.finalizingProgBar.TabIndex = 2;
            // 
            // finalizingLabel
            // 
            this.finalizingLabel.AutoSize = true;
            this.finalizingLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalizingLabel.Location = new System.Drawing.Point(199, 206);
            this.finalizingLabel.Name = "finalizingLabel";
            this.finalizingLabel.Size = new System.Drawing.Size(189, 15);
            this.finalizingLabel.TabIndex = 3;
            this.finalizingLabel.Text = "Windows is finalizing your settings";
            // 
            // windowsBrandingPic
            // 
            this.windowsBrandingPic.Image = global::WindowsOOBERecreation.Properties.Resources.branding;
            this.windowsBrandingPic.Location = new System.Drawing.Point(67, 91);
            this.windowsBrandingPic.Name = "windowsBrandingPic";
            this.windowsBrandingPic.Size = new System.Drawing.Size(458, 72);
            this.windowsBrandingPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.windowsBrandingPic.TabIndex = 1;
            this.windowsBrandingPic.TabStop = false;
            // 
            // Finalizing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.Controls.Add(this.finalizingLabel);
            this.Controls.Add(this.finalizingProgBar);
            this.Controls.Add(this.windowsBrandingPic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Finalizing";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.windowsBrandingPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox windowsBrandingPic;
        private System.Windows.Forms.ProgressBar finalizingProgBar;
        private System.Windows.Forms.Label finalizingLabel;
    }
}