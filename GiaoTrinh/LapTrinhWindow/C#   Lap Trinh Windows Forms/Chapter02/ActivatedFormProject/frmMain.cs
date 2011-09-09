using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActivatedFormProject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEmployees();
            frm.MdiParent = this;
            
            frm.Show();
        }

        private void overtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmOvertimes();
            frm.MdiParent = this;
            frm.Show();
        }

        
        
    }
}