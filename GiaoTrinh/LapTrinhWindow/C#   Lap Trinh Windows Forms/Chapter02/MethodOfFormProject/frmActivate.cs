using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MethodOfFormProject
{
    public partial class frmActivate : Form
    {
        public frmActivate()
        {
            InitializeComponent();
        }

        private void childForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChildForm1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void childForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChildForm2();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}