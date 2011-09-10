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

        private void DoanThang_Click(object sender, EventArgs e)
        {
            Point DinhA = new Point(50, 50);
            Point DinhB = new Point(200, 150);
            DoanThang dt = new DoanThang(DinhA, DinhB);
            Graphics g = pictureBox1.CreateGraphics();
            dt.Ve(g);
        }

        private void TamGiac_Click(object sender, EventArgs e)
        {
            Point DinhA = new Point(50, 50);
            Point DinhB = new Point(200, 150);
            Point DinhC = new Point(300, 520);
            TamGiac tg = new TamGiac(DinhA, DinhB,DinhC);
            Graphics g = pictureBox1.CreateGraphics();
            tg.Ve(g);
        }
    }
}
