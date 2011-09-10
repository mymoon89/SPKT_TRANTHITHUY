using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HinhHoc;

namespace ThuaKe_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TamGiac_Click(object sender, EventArgs e)
        {
            Point dinhA = new Point(10, 10);
            Point dinhB = new Point(50, 50);
            Point dinhC = new Point(50, 20);
            TamGiac tg = new TamGiac(dinhA, dinhB, dinhC);
            Graphics g = pictureBox1.CreateGraphics();
            tg.Ve(g);

        }

        private void Doanthang_Click(object sender, EventArgs e)
        {
            Point DiemA = new Point(10, 10);
            Point DiemB = new Point(100, 100);
            DoanThang dt = new DoanThang(DiemA, DiemB);
            Graphics gdt = pictureBox1.CreateGraphics();
            dt.Ve(gdt);
        }


    }
}