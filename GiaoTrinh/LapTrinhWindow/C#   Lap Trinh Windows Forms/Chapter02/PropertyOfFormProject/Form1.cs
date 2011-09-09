using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading ;
using System.Windows.Forms;

namespace PropertyOfFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
                      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "New Form";
            frm.Name = "frmNewForm";
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmOpacity ();             
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new frmIcon();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new frmBackColor ();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new frmForeColor ();
            frm.Show();        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new frmLogin();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "MDI Form";
            frm.IsMdiContainer = true;
            frm.Load += delegate(object sender1, EventArgs e1)
                {
                    Form ChildForm = new Form();
                    ChildForm.Text = "Child Form";
                    ChildForm.MdiParent = frm;
                    ChildForm.WindowState =
                        FormWindowState.Maximized;
                    ChildForm.Show();
                };                
            frm.ShowDialog();
        }
    }
}