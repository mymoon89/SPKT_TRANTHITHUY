using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MenuStripProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text =toolStripTextBox1.Text;
             
                   
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        void CreateControls()
        {
            ToolStripTextBox txt = new ToolStripTextBox();
            txt.Name = "Size";
            txt.Text = "10";
            MenuStrip ms = new MenuStrip();
            ms.Items.Add(txt);
            ms.Items.Add("&File");
            ms.Items.Add("&Edit");
            ms.Items.Add("&View");
            ms.Items.Add("&Windows");
            this.Controls.Add(ms);            
        }

         
    }
}