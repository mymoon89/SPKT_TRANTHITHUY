using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContextMenuStripProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text= Clipboard.GetText();
        }
        void CreateControls()
        {
             
            ContextMenuStrip cms = new
            ContextMenuStrip();
            cms.Name = "Shortcut";
            cms.Items.Add("Copy");
            cms.Items.Add("Cut");
            cms.Items.Add("Paste");
            this.Controls.Add(cms);
        }

    }
}