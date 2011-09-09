using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MethodOfFormProject
{
    public partial class frmChildForm2 : Form
    {
        public frmChildForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = frmActivate.ActiveForm;
            foreach (Form f in frm.MdiChildren)
            {
                if (f.Text == "frmChildForm1")
                    f.Activate();
            }
        }
    }
}