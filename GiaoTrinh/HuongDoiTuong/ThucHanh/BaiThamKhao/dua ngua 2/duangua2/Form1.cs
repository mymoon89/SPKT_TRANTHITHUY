using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
namespace duangua2
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        int total = 10000;
        int db1 = 1, db2 = 1, db3 = 1, db4 = 1;
        int kt = 0, ktdc = 0, stdc = 0;
        int reset=0;
        //new----------
        int status = 1;
        string thongtin = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset =pdo.Left;
            tbtotal.Enabled = false;
            tbtotal.Text = "" + total;
        }
        public void nguado() {
            if (pdo.Left < panel1.Width - pdo.Width)
            {
                db1 = r.Next(1, 5);
                pdo.Left += db1;
            }
            else {
                kt = 1;
                lbnew1.Text = "ngựa RED win!!!";
            }
            Application.DoEvents();
            Thread.Sleep(50);
        }
        public void nguablue()
        {
            if (pblue.Left < panel1.Width - pblue.Width)
            {
                db2 = r.Next(1, 5);
                pblue.Left += db2;
            }
            else
            {
                kt = 2;
                lbnew1.Text = "ngựa BLUE win!!!";
            }
            Application.DoEvents();
            Thread.Sleep(50);
        }
        public void nguaxam()
        {
            if (pxam.Left < panel1.Width - pxam.Width)
            {
                db3 = r.Next(1, 5);
                pxam.Left += db3;
            }
            else
            {
                kt = 3;
                lbnew1.Text = "ngựa GRAY win!!!";
            }
            Application.DoEvents();
            Thread.Sleep(50);
        }
        public void nguaxanh()
        {
            if (pxanh.Left < panel1.Width - pxanh.Width)
            {
                db4 = r.Next(1, 5);
                pxanh.Left += db4;
            }
            else
            {
                kt = 4;
                lbnew1.Text = "ngựa GREEN win!!!";
            }
            Application.DoEvents();
            Thread.Sleep(50);
        }
        [DllImportAttribute("User32.dll")]
        public static extern int MessageBox(int hParent, string Message, string Caption, int Type);
        public void threadtest() {
            while (true)
            {
                if (kt == 0)
                {
                    lbnew1.Text = "cố lên ....";
                    nguado();
                    nguablue();
                    nguaxam();
                    nguaxanh();
                    if (status == 1)
                        break;
                }
                else
                {
                    if (ktdc == kt)
                    {
                        MessageBox(0, "Bạn đã thắng", "Notify", 0);
                        tbtotal.Text = "" + (total += (stdc * 5));
                    }
                    else
                    {
                        MessageBox(0, "Bạn đã thua", "Notify", 0);
                        tbtotal.Text = "" + (total -= stdc);
                    }
                    pdo.Left = pblue.Left = pxam.Left = pxanh.Left = reset;
                    db1 = db2 = db3 = db4 = kt = ktdc = stdc = 0;
                    tbdiem.Text = "";
                    lbnew.Text = "Chưa có thông tin";
                    lbnew1.Text = "Chuẩn bị xuất phát";
                    break;
                }
            }
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            if (tbdiem.Text.Length == 0)
            {
                MessageBox(0, "Chưa nhập tiền đặt cược", "NOtify", 0);
                return;
            }
            if (ktdc == 0)
            {
                MessageBox(0, "Chưa chọn ngựa", "NOtify", 0);
                return;
            }
            if(ktdc == 1){ thongtin = "RED";}
            if (ktdc == 2) { thongtin = "BLUE"; }
            if (ktdc == 3) { thongtin = "GRAY"; }
            if (ktdc == 4) { thongtin = "GREEN"; }
            stdc = int.Parse(tbdiem.Text);
            lbnew.Text = "Bạn đã chọn ngựa " + thongtin + " với " + stdc + " đặt cược";
            if (status == 1)
            {  
                status = 0;
                btStart.Text = "Tạm dừng";
                threadtest();
              
            }
            else
            {
                status = 1;
                btStart.Text = "Tiếp tục";
                
            }
           
        }

        private void pcdo_Click(object sender, EventArgs e)
        {
            ktdc = 1;
        }

        private void pcblue_Click(object sender, EventArgs e)
        {
            ktdc = 2;
        }

        private void pcxam_Click(object sender, EventArgs e)
        {
            ktdc =3;
        }

        private void pcxanh_Click(object sender, EventArgs e)
        {
            ktdc = 4;
        }
    }
}