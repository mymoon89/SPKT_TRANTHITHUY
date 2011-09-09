using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActivatedFormProject
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }
        int i = 0;
        private void frmEmployees_Activated(object sender, EventArgs e)
        {
            i += 1;
            this.label2.Text = "Activated " + i.ToString();
        }
    }
}