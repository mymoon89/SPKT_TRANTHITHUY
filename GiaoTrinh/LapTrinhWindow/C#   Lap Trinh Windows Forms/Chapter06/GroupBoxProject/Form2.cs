using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GroupBoxProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GroupBox gr = new GroupBox();
            gr.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gr.Location = new  Point(10, 20);
            RadioButton rd ;
            rd= new RadioButton();
            rd.Text = "Single";
            rd.Checked = true;
            rd.Location = new  Point(20, 12);
            gr.Controls.Add(rd);
            rd = new RadioButton();
            rd.Text = "Married";
            rd.Location = new  Point(20, 42);
            gr.Controls.Add(rd);
            this.Controls.Add(gr);
        }
    }
}