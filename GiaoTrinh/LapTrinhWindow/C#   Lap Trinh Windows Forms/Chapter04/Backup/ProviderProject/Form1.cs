using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProviderProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateControls();
        }
        void CreateControls()
        {
            ToolTip tt = new ToolTip();
            
            tt.ToolTipTitle = "This is ToolTip Object";
            tt.ToolTipIcon = ToolTipIcon.Warning;
            TextBox txt = new TextBox();
            txt.Name = "txtUser";
            tt.SetToolTip(txt, "Blank is not valid");
            this.Controls.Add(txt);
        }

    }
}