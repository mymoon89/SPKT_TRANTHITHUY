using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventOfFormProject
{
    public partial class frmClosed : Form
    {
        public frmClosed()
        {
            InitializeComponent();
        }

        private void frmClosed_FormClosed(
            object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(e.CloseReason.ToString());
        }
    }
}