using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kethua
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public Point DinhA = new Point(50, 50);
       // public Point DinhB = new Point(50, 200);
        private void DoanThang_Click(object sender, EventArgs e)
        {
             Point DinhA = new Point(50, 50);
             Point DinhB = new Point(50, 200);
   
            DoanThang dt = new DoanThang(DinhA, DinhB);
            Graphics g = pictureBox1.CreateGraphics();
            dt.Ve(g);
        }

        private void TamGiac_Click(object sender, EventArgs e)
        {
            NhapTamGiac form = new NhapTamGiac();
            //Point DinhA = new Point(50, 50);
            //Point DinhB = new Point(200, 150);
            Point DinhC = new Point(200, 50);
            TamGiac tg = new TamGiac(DinhC);
            //TamGiac tg = new TamGiac(DinhA, DinhB, DinhC);
            Graphics g = pictureBox1.CreateGraphics();
            tg.Ve(g);
        }

        private void ChuNhat_Click(object sender, EventArgs e)
        {
           // Point DinhA = new Point(50, 50);
            Point DinhD = new Point(200, 200);
          //  Point DinhB = new Point(50, 200);
          //  Point DinhC = new Point(200, 200);
           // ChuNhat cn = new ChuNhat(DinhA, DinhB, DinhC, DinhD);
            ChuNhat cn = new ChuNhat(DinhD);
            Graphics g = pictureBox1.CreateGraphics();
            cn.Ve(g);
        }
    }
}
