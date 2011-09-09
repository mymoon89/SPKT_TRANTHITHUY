using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MenuStripProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        void CreateControls()
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Name = "Shortcut";
            cms.Items.Add("Copy");
            cms.Items.Add("Cut");
            cms.Items.Add("Paste");
            this.Controls.Add(cms);
        }

    }
}