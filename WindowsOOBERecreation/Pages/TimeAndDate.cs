using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WindowsOOBERecreation
{
    public partial class TimeAndDate : Form
    {
        private Main _mainForm;

        public TimeAndDate(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            FetchTZs(tzCombo);

            this.AcceptButton = _mainForm.nextButton;
            tzCombo.SelectedIndexChanged += TimeZoneCombo_SelectedIndexChanged;
        }

        private void FetchTZs(ComboBox timeZoneCombo)
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            string currentTimeZoneId = TimeZoneInfo.Local.Id;

            timeZoneCombo.Items.Clear();

            foreach (var timeZone in timeZones)
            {
                timeZoneCombo.Items.Add(timeZone.DisplayName);

                if (timeZone.Id == currentTimeZoneId)
                {
                    timeZoneCombo.SelectedItem = timeZone.DisplayName;
                    DSTCheck.Enabled = timeZone.SupportsDaylightSavingTime;
                    DSTCheck.Checked = timeZone.SupportsDaylightSavingTime;
                }
            }
        }

        private void TimeZoneCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                string selectedTimeZoneDisplayName = comboBox.SelectedItem.ToString();
                var timeZone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(tz => tz.DisplayName == selectedTimeZoneDisplayName);
                if (timeZone != null)
                {
                    DSTCheck.Enabled = timeZone.SupportsDaylightSavingTime;

                    if (timeZone.SupportsDaylightSavingTime) { DSTCheck.Checked = true; }
                    else { DSTCheck.Checked = false; }

                    SetTimeZone(timeZone.Id);
                }
            }
        }

        private void SetTimeZone(string timeZoneId)
        {
            if (DSTCheck.Checked == false) { timeZoneId += "_dstoff"; }
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "tzutil.exe",
                Arguments = $"/s \"{timeZoneId}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
            }

            TimeZoneInfo.ClearCachedData();
            timePicker.RefreshNow();
        }
    }
}