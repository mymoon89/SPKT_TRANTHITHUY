using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventOfFormProject
{
    public partial class frmKeyPress : Form
    {
        public frmKeyPress()
        {
            InitializeComponent();
        }

        private void frmKeyPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            label1.Text = "Pressed by key :"
                +e.KeyChar.ToString();
        }
    }
}