using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventOfFormProject
{
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {
            textBox1.Text = SystemInformation.ComputerName;
            textBox2.Text = SystemInformation.UserName;
            textBox3.Text = SystemInformation.UserDomainName;
        }
    }
}