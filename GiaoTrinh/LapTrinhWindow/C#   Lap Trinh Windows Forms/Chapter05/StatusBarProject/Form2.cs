using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StatusBarProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            toolStripDropDownButton1.
                DropDownItems[2].Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 10; i <= 100;i+=10)
                toolStripComboBox2.
                    Items.Add(i.ToString()+"%");
        }
    }
}