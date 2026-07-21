
namespace WindowsOOBERecreation
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.helpPanel = new System.Windows.Forms.Panel();
            this.helpBox = new System.Windows.Forms.RichTextBox();
            this.helpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpPanel
            // 
            this.helpPanel.Controls.Add(this.helpBox);
            this.helpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpPanel.Location = new System.Drawing.Point(0, 0);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(284, 561);
            this.helpPanel.TabIndex = 0;
            // 
            // helpBox
            // 
            this.helpBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpBox.Location = new System.Drawing.Point(0, 0);
            this.helpBox.Name = "helpBox";
            this.helpBox.Size = new System.Drawing.Size(284, 561);
            this.helpBox.TabIndex = 0;
            this.helpBox.TabStop = false;
            this.helpBox.Text = "";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 561);
            this.Controls.Add(this.helpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.Text = "Help and Support";
            this.TopMost = true;
            this.helpPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel helpPanel;
        private System.Windows.Forms.RichTextBox helpBox;
    }
}