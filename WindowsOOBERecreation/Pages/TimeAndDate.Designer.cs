namespace WindowsOOBERecreation
{
    partial class TimeAndDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeAndDate));
            this.titleLabel = new System.Windows.Forms.Label();
            this.tzCombo = new System.Windows.Forms.ComboBox();
            this.tzLabel = new System.Windows.Forms.Label();
            this.DSTCheck = new System.Windows.Forms.CheckBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timePicker = new WindowsOOBERecreation.TimePicker();
            this.clockCont1 = new WindowsOOBERecreation.ClockCont();
            this.monthCalBox = new WindowsOOBERecreation.MonthCal();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(34, 51);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(253, 21);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Review your time and date settings";
            // 
            // tzCombo
            // 
            this.tzCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tzCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tzCombo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tzCombo.FormattingEnabled = true;
            this.tzCombo.Location = new System.Drawing.Point(38, 116);
            this.tzCombo.Name = "tzCombo";
            this.tzCombo.Size = new System.Drawing.Size(376, 23);
            this.tzCombo.TabIndex = 0;
            // 
            // tzLabel
            // 
            this.tzLabel.AutoSize = true;
            this.tzLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tzLabel.Location = new System.Drawing.Point(37, 91);
            this.tzLabel.Name = "tzLabel";
            this.tzLabel.Size = new System.Drawing.Size(64, 15);
            this.tzLabel.TabIndex = 11;
            this.tzLabel.Text = "Time zone:";
            // 
            // DSTCheck
            // 
            this.DSTCheck.AutoSize = true;
            this.DSTCheck.Checked = true;
            this.DSTCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DSTCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DSTCheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DSTCheck.Location = new System.Drawing.Point(38, 146);
            this.DSTCheck.Name = "DSTCheck";
            this.DSTCheck.Size = new System.Drawing.Size(304, 20);
            this.DSTCheck.TabIndex = 1;
            this.DSTCheck.Text = "Automatically adjust clock for Daylight Saving Time";
            this.DSTCheck.UseVisualStyleBackColor = true;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(37, 184);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(34, 15);
            this.dateLabel.TabIndex = 13;
            this.dateLabel.Text = "Date:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(255, 184);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(36, 15);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.Text = "Time:";
            // 
            // timePicker
            // 
            this.timePicker.BackColor = System.Drawing.Color.Transparent;
            this.timePicker.Location = new System.Drawing.Point(278, 341);
            this.timePicker.Margin = new System.Windows.Forms.Padding(0);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(89, 21);
            this.timePicker.TabIndex = 4;
            // 
            // clockCont1
            // 
            this.clockCont1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clockCont1.BackgroundImage")));
            this.clockCont1.Location = new System.Drawing.Point(256, 209);
            this.clockCont1.Name = "clockCont1";
            this.clockCont1.Size = new System.Drawing.Size(130, 130);
            this.clockCont1.TabIndex = 3;
            // 
            // monthCalBox
            // 
            this.monthCalBox.Location = new System.Drawing.Point(38, 209);
            this.monthCalBox.Margin = new System.Windows.Forms.Padding(0);
            this.monthCalBox.Name = "monthCalBox";
            this.monthCalBox.Size = new System.Drawing.Size(170, 137);
            this.monthCalBox.TabIndex = 2;
            // 
            // TimeAndDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.clockCont1);
            this.Controls.Add(this.monthCalBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.DSTCheck);
            this.Controls.Add(this.tzLabel);
            this.Controls.Add(this.tzCombo);
            this.Controls.Add(this.titleLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeAndDate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox tzCombo;
        private System.Windows.Forms.Label tzLabel;
        private System.Windows.Forms.CheckBox DSTCheck;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private MonthCal monthCalBox;
        private ClockCont clockCont1;
        private TimePicker timePicker;
    }
}