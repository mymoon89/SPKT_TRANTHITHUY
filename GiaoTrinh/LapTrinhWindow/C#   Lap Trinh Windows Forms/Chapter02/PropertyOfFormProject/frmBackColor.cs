using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PropertyOfFormProject
{
    public partial class frmBackColor : Form
    {
        public frmBackColor()
        {
            InitializeComponent();
        }

        private void frmBackColor_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Azure;
        }
    }
}