using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToolStripProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string click = Convert.ToString(e.ClickedItem.Text );
            switch(click)
            {
                case "New":                    
                case "Open":
                case "Save":
                case "Format":
                    MessageBox.Show(click,"C# 2005");
                    break;                                    
            }
            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(toolStripComboBox1.SelectedItem));
        }

       

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolStripTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolStrip ts = new ToolStrip();
            ts.Dock = DockStyle.Bottom;

            ToolStripTextBox tt = new ToolStripTextBox();
            tt.Text = "*.*";    
            ToolStripButton bt = new ToolStripButton();
            bt.Text="Go";
            ToolStripComboBox tc = new ToolStripComboBox();
            tc.Text = "Folder";
            tc.Items.Add("Folder");
            tc.Items.Add("File");
            ts.Items.Add(tt);
            ts.Items.Add(bt);
            ts.Items.Add(tc);
            this.Controls.Add(ts);
        }
    }
}