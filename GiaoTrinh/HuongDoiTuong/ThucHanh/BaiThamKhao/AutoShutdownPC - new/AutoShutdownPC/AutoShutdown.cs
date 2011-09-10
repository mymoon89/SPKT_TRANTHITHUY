using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Management;
using System.Windows;

namespace AutoShutdownPC
{
    public partial class ShutdownPC : Form
    {

        [DllImport("user32.dll")]
        public static extern void LockWorkStation(); 
        public ShutdownPC()
        {
            InitializeComponent();
        }
        int HoursHh, MinuteHh, SecondHh, DenHh;
        int HoursHd, MinuteHd, SecondHd, DenHd;
        int hour, minute, second, den;
        int SumTimeSc; // tổng thời gian tính = giây

        Introduction Intro = new Introduction();
        private void ShutdownPC_Load(object sender, EventArgs e)
        {
            Intro.ShowDialog();
            ButtonCancel.Enabled = false;
            Choose.Text = "Shutdown";
        }
        // Chọn các chế độ
        private void Choose_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  string text = Choose.Text;
            string text = Choose.Text;

            // Trợ giúp cho người dùng dưới dạng ToolTipText
            switch (text)
            {
                case "Shutdown":
                    toolTip1.SetToolTip(Choose, "Đóng tất cả chương trình, thoát Windows và tắt máy");
                    toolTip1.ToolTipTitle = "Funktion " + text;
                    break;
                case "Log off":
                    toolTip1.SetToolTip(Choose, "Đóng tất cả chương trình và Log out");
                    toolTip1.ToolTipTitle = "Funktion " + text;
                    break;
                case "Log computer":
                    toolTip1.SetToolTip(Choose, "Khóa tạm thời máy tính");
                    toolTip1.ToolTipTitle = "Funktion " + text;
                    break;
                case "Restart":
                    toolTip1.SetToolTip(Choose, "Đóng tất cả chương trình, thoát Windows và sau đó Restart");
                    toolTip1.ToolTipTitle = "Funktion " + text;
                    break;              
                case "Stanby":
                    toolTip1.SetToolTip(Choose, "Lưu dữ liệu của máy tính vào RAM và đưa máy tính vào chế độ Stanby. CHÚ Ý, khi máy tính bị mất nguồn, dữ liệu sẽ bị mất!!!!!");
                    toolTip1.ToolTipTitle = "Funktion " + text;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Choose.Text)
            {
                case "Shutdown": ShutDown("1");
                    break;
                case "Restart": ShutDown("2");
                    break;
                case "Log off": ShutDown("0");
                    break;
                case "Lock computer": LockWorkStation();
                    break;
                case "Stanby": Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (SumTimeSc > 0)
            {
                int time;
                if ((SumTimeSc / 3600) < 10) LabelHours.Text = "0" + SumTimeSc / 3600;
                else LabelHours.Text = (SumTimeSc / 3600).ToString();

                time = SumTimeSc - (SumTimeSc / 3600) * 3600;
                if ((time / 60) < 10) LabelMinute.Text = "0" + time / 60;
                else LabelMinute.Text = (time / 60).ToString();

                time = time - (time / 60) * 60;
                if (time < 10) LabelSecond.Text = "0" + time;
                else LabelSecond.Text = time.ToString();
                SumTimeSc -= 1;

                notifyIcon1.Text = "Thời gian còn lại: " + LabelHours.Text + " : "
                               + LabelMinute.Text + " : " + LabelSecond.Text;
                if (SumTimeSc == 20) notifyIcon1_DoubleClick(sender, e);
            }
            else timer2.Enabled = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            WindowState = 0;
        }
        private void OpenMainInterface_Click(object sender, EventArgs e)
        {
            notifyIcon1_DoubleClick(sender, e);
        }
        private void CancelAction_Click(object sender, EventArgs e)
        {
            ButtonCancel_Click(sender, e);
            notifyIcon1_DoubleClick(sender, e);
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Thoi gian bat dau chon
                DateTime SumTimeHd = new DateTime();
                SumTimeHd = dateTimePicker1.Value;
                DenHd = SumTimeHd.Day;
                HoursHd = SumTimeHd.Hour;
                MinuteHd = SumTimeHd.Minute;
                SecondHd = SumTimeHd.Second;
                // Thoi gian hien hanh
                DateTime SumTimeHh = new DateTime();
                SumTimeHh = DateTime.Now;
                DenHh = SumTimeHh.Day;
                HoursHh = SumTimeHh.Hour;
                MinuteHh = SumTimeHh.Minute;
                SecondHh = SumTimeHh.Second;

                Choose.Enabled = false;
                dateTimePicker1.Enabled = false;

                den = DenHd - DenHh;
                hour = HoursHd - HoursHh;
                minute = MinuteHd - MinuteHh;
                second = SecondHd - SecondHh;
                SumTimeSc = den * 86400 + hour * 3600 + minute * 60 + second;

                timer1.Interval = SumTimeSc * 1000;
                timer1.Enabled = true;
                timer2.Enabled = true;
                ButtonCancel.Enabled = true;
                ButtonStart.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Bạn cần chỉnh thời gian cho đúng hơn !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Choose.Enabled = true;
                dateTimePicker1.Enabled = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                LabelHours.Text = "00";
                LabelMinute.Text = "00";
                LabelSecond.Text = "00";
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ButtonStart.Enabled = true;
            ButtonCancel.Enabled = false;
            Choose.Enabled = true;
            dateTimePicker1.Enabled = true;
            timer1.Enabled = false;
            timer2.Enabled = false;
            LabelHours.Text = "00";
            LabelMinute.Text = "00";
            LabelSecond.Text = "00";

        }
        public static void ShutDown(string a)
        {
            ManagementBaseObject output = null;
            ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
            sysOS.Get();
            // lấy sự đồng ý của hệ thống
            sysOS.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject input = sysOS.GetMethodParameters("Win32Shutdown");

            // 0 = log out
            // 1 = shutdown
            // 2 = restart
            // 4 = tắt tất cả các ứng dụng mà không lưu
            input["Flags"] = a;
            input["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOS.GetInstances())
            {
                output = manObj.InvokeMethod("Win32Shutdown", input, null);
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
