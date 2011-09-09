using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventOfFormProject
{
    public partial class frmResize : Form
    {
        public frmResize()
        {
            InitializeComponent();
        }

        private void frmResize_Resize(object sender, EventArgs e)
        {
            richTextBox1.Width = this.Width - 30;
            richTextBox1.Height = this.Height - 50;
        }
    }
}