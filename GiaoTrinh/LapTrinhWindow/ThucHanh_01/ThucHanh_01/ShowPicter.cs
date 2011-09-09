using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThucHanh_01
{
    public partial class ShowPicter : Form
    {
        public ShowPicter()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Baby2")
            {
                pictureBox1.Image= imglis_Picter.Images[0];
                tb_En.Text = "250";
                tb_Ma.Text = ".jpg";
                tb_Mi.Text = "400kpmb0";
            }
            else if (comboBox1.Text == "baby 35")
            {
                pictureBox1.Image = imglis_Picter.Images[1];
                tb_En.Text = "350";
                tb_Ma.Text = ".jpg";
                tb_Mi.Text = "400kbmp1";
            }
        }
    }
}
