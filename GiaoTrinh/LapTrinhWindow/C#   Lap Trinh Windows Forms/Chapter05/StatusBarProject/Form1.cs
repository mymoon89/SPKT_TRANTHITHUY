using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StatusBarProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolStripStatusLabel label1 = new ToolStripStatusLabel();
            label1.Text = "Module";
            label1.ToolTipText = "This is name of activate module";
            label1.Click += new EventHandler(OnClick);
            this.statusStrip1.Items.Add(label1);
        }
        void OnClick(object sender, EventArgs e)
        {
                MessageBox.Show("Module");
        }

        private void toolStripStatusLabel3_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.huukhang.com");
        }
    }
}