using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NotifyIconProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        void CreateControls()
        {
            ToolStrip ts = new ToolStrip();
            ts.Name  = "Main";
            ToolStripButton tsb = new ToolStripButton();
            tsb.Text = "Open";
            tsb.ToolTipText = "Open Document";
            ts.Items.Add(tsb);
            tsb = new ToolStripButton();
            tsb.Text = "Save";
            tsb.ToolTipText = "Save Document";
            ts.Items.Add(tsb);
            this.Controls.Add(ts);
        }


    }
}