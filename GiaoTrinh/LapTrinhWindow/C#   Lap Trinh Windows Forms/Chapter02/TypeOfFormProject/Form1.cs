using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TypeOfFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();            
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.IsMdiContainer = true;
            frm.Show ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.MdiParent = this;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "New Form";
            frm.Name = "frmNewForm";
            frm.Click += delegate(object sender1, EventArgs e1) 
            { System.Windows.Forms.MessageBox.Show("Click on the new Form!","HUUKHANG.COM"); };

            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new frmInherit ();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.MdiParent = Form2.ActiveForm  ;
            frm.Show();
        }

    }
}