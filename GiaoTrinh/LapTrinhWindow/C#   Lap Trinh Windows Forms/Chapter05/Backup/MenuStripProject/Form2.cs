using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MenuStripProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.toolStripComboBox1.Items.Add("10%");
            toolStripComboBox1.Items.Add("20%");
            toolStripComboBox1.Items.Add("50%");
            toolStripComboBox1.Items.Add("70%");
            toolStripComboBox1.Items.Add("100%");
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(toolStripComboBox1.SelectedItem));
        }
        void CreateControls()
        {
            MenuStrip ms = new MenuStrip();
            ms.Items.Add("&File");
            ms.Items.Add("&Edit");
            ms.Items.Add("&View");
            ms.Items.Add("&Windows");
            this.Controls.Add(ms);
        }
        void CreateControls1()
        {
            ToolStripComboBox tsc = new ToolStripComboBox();
            tsc.Name = "Font";
            tsc.Text = "&Font";
            tsc.Items.Add("Arial");
            tsc.Items.Add("Tohoma");
            tsc.Items.Add("VN-Times");
            MenuStrip ms = new MenuStrip();
            ms.Items.Add(tsc);
            ms.Items.Add("&File");
            ms.Items.Add("&Edit");
            ms.Items.Add("&View");
            ms.Items.Add("&Windows");
            this.Controls.Add(ms);
        }

        private void previewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

    }
}