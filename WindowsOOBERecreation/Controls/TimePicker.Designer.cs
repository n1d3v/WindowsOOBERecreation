
namespace WindowsOOBERecreation
{
    partial class TimePicker
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
            this.clockBox = new System.Windows.Forms.TextBox();
            this.upButton = new System.Windows.Forms.PictureBox();
            this.downButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.upButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downButton)).BeginInit();
            this.SuspendLayout();
            // 
            // clockBox
            // 
            this.clockBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clockBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockBox.Location = new System.Drawing.Point(0, 0);
            this.clockBox.Name = "clockBox";
            this.clockBox.Size = new System.Drawing.Size(72, 23);
            this.clockBox.TabIndex = 0;
            this.clockBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clockBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clockBox_KeyDown);
            this.clockBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clockBox_KeyPress);
            this.clockBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clockBox_MouseUp);
            // 
            // upButton
            // 
            this.upButton.Image = global::WindowsOOBERecreation.Properties.Resources.up_normal;
            this.upButton.Location = new System.Drawing.Point(73, 1);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(15, 9);
            this.upButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.upButton.TabIndex = 1;
            this.upButton.TabStop = false;
            this.upButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.upButton_MouseDown);
            this.upButton.MouseEnter += new System.EventHandler(this.upButton_MouseEnter);
            this.upButton.MouseLeave += new System.EventHandler(this.upButton_MouseLeave);
            this.upButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.upButton_MouseUp);
            // 
            // downButton
            // 
            this.downButton.Image = global::WindowsOOBERecreation.Properties.Resources.down_normal;
            this.downButton.Location = new System.Drawing.Point(73, 11);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(15, 9);
            this.downButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.downButton.TabIndex = 2;
            this.downButton.TabStop = false;
            this.downButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.downButton_MouseDown);
            this.downButton.MouseEnter += new System.EventHandler(this.downButton_MouseEnter);
            this.downButton.MouseLeave += new System.EventHandler(this.downButton_MouseLeave);
            this.downButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.downButton_MouseUp);
            // 
            // TimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.clockBox);
            this.Name = "TimePicker";
            this.Size = new System.Drawing.Size(89, 21);
            ((System.ComponentModel.ISupportInitialize)(this.upButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clockBox;
        private System.Windows.Forms.PictureBox upButton;
        private System.Windows.Forms.PictureBox downButton;
    }
}
