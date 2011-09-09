using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventOfFormProject
{
    public partial class frmMDIForm : Form
    {
        public frmMDIForm()
        {
            InitializeComponent();
        }

        private void child1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Child1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void child2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Child2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void child3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Child3();
            frm.MdiParent = this;
            frm.Show();
        }

        private void childFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMDIForm_MdiChildActivate(object sender, EventArgs e)
        {            
            foreach (Form frm in this.MdiChildren)
            {                
                label1.Text = frm.Name;
            }
        }

        private void frmMDIForm_Load(object sender, EventArgs e)
        {

        }
    }
}