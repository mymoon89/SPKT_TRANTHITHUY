using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActivatedFormProject
{
    public partial class frmOvertimes : Form
    {
        public frmOvertimes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = frmMain.ActiveForm;
            foreach (Form f in frm.MdiChildren)
                if (f.Name == "frmEmployees")
                    f.Activate();
        }
    }
}