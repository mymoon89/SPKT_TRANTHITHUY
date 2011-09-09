using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MenuStripProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void toolStripComboBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }
        void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ToolStripMenuItem");
        }
        void CreateControls()
        {
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem mm = new ToolStripMenuItem();
            mm.Text = "&File";
            mm.Click += new System.EventHandler(ToolStripMenuItem1_Click);
            ms.Items.Add(mm);
            ms.Items.Add("&Edit");
            ms.Items.Add("&View");
            ms.Items.Add("&Windows");
            this.Controls.Add(ms);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.ShowDialog();
        }

        private void toolStripSeparatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.ShowDialog();
        }

        private void toolStripTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.ShowDialog();
        }

        
    }
}