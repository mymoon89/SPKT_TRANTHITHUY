using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string choose = "";
            foreach (Control chk in this.Controls)
            { 
                if (chk is CheckBox)
                {
                    if (((CheckBox)chk).Checked==true)
                    choose += chk.Text + ",";
                }
            }
            MessageBox.Show("You are selected: " +choose );
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Visible = checkBox4.Checked;
        }
    }
}