using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HinhHoc
{
    public partial class FormNhapTamGiac : Form
    {
        public TamGiac Data;
        public FormNhapTamGiac()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Point A = new Point(int.Parse(toadoX1.Text), int.Parse(toadoY1.Text));
            Point B = new Point(int.Parse(toadoX2.Text), int.Parse(toadoY2.Text));
            Point C = new Point(int.Parse(toadoX3.Text), int.Parse(toadoY3.Text));
            Data = new TamGiac(A, B, C);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
