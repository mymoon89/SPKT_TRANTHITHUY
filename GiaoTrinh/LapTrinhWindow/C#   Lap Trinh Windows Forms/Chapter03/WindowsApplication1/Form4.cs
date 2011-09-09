using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void maskedTextBox3_MaskInputRejected(
            object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Please enter with 'dd/mm/yyyy'","HUUKHANG.COM");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        void CreateControls()
        {
            MaskedTextBox txt = new MaskedTextBox();
            txt.Name = "txtU";
            txt.Text = "01/Mar/2006";
            txt.Mask = "dd/mm/yyyy";
            this.Controls.Add(txt);
        }

    }
}