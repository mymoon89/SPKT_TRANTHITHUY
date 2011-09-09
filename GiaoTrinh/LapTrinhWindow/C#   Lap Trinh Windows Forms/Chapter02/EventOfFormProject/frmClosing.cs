using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventOfFormProject
{
    public partial class frmClosing : Form
    {
        public frmClosing()
        {
            InitializeComponent();
        }

        private void frmClosing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?",
                "HUUKHANG.COM",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                e.Cancel = true;
            
        }
    }
}