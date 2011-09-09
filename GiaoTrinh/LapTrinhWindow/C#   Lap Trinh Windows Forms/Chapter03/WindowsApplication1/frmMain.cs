using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new Form7();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new Form8();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form frm = new Form9();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form frm = new Form10();
            frm.ShowDialog();
        }
    }
}