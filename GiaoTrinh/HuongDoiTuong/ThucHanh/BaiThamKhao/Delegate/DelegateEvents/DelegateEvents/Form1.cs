using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DelegateEvents
{
    //Khai báo kiểu delegate
    public delegate double PhepToan(double a, double b);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //Khai báo một biến delegate
        PhepToan hamGiDo;

        private void btnDo_Click(object sender, EventArgs e)
        {
            try
            {
                double soA = double.Parse(txtA.Text);
                double soB = double.Parse(txtB.Text);
                if (hamGiDo != null)
                {
                    double c = hamGiDo(soA, soB);
                    MessageBox.Show(c.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bị lỗi: " + ex.Message);
            }
            
        }
        double Cong(double a, double b)
        {
            return a + b;
        }
        double Tru(double a, double b)
        {
            return a - b;
        }
        double Nhan(double a, double b)
        {
            return a *b;
        }
        double Chia(double a, double b)
        {
            return a / b;
        }
        double TumLumTala(double a, double b)
        {
            return (a + b) / (a * b - b / 2);
        }
        private void radCong_CheckedChanged(object sender, EventArgs e)
        {
            hamGiDo = new PhepToan(Cong);            
        }

        private void radTru_CheckedChanged(object sender, EventArgs e)
        {
            hamGiDo = Tru;
        }

        private void radNhan_CheckedChanged(object sender, EventArgs e)
        {
            hamGiDo = new PhepToan(Nhan);
        }

        private void radChia_CheckedChanged(object sender, EventArgs e)
        {
            hamGiDo = new PhepToan(Chia);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThucVat hoaHong = new ThucVat("Hoa Hồng");
            ThucVat hoaLan= new ThucVat("Hoa Lan");

            DoSomeThing lamGiDo1 = new DoSomeThing(hoaHong.SayGoodBye);
            DoSomeThing lamGiDo2 = new DoSomeThing(hoaHong.SayHello);
            DoSomeThing lamGiDo3 = new DoSomeThing(hoaLan.SayHello);
            DoSomeThing lamGiDo4 = new DoSomeThing(hoaLan.SayGoodBye);
            DoSomeThing lamGiDo5 = new DoSomeThing(hoaLan.SayGoodBye);
            lamGiDo1.Invoke();
            lamGiDo2();
            lamGiDo3();
            lamGiDo4();

            MessageBox.Show(lamGiDo4.Equals(lamGiDo3).ToString());
            MessageBox.Show(lamGiDo4.Equals(lamGiDo5).ToString());
        }

        ThucVat thucVat = new ThucVat("ABC");

        private void button2_Click(object sender, EventArgs e)
        {
            thucVat.OnSayHello += new DoSomeThing(LangNghe1);
            thucVat.OnSayHello += new DoSomeThing(LangNghe2);
        }
        public void LangNghe1()
        {
            MessageBox.Show("Ham 1");
            throw new Exception("Lỗi Hàm 1");
        }
        public void LangNghe2()
        {
            MessageBox.Show("Ham 2");
        }

        void ThaoTac1(object obj, EventArgs arg)
        {
            MessageBox.Show("Thao tac 1");
            throw new Exception("Bị lỗi ở thao tác 1");
        }
        void ThaoTac2(object obj, EventArgs arg)
        {
            MessageBox.Show("Thao tac 2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnTest.Click -= new EventHandler(ThaoTac1);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            thucVat.PhatSinhSuKienSayHello();
        }
    }
}
