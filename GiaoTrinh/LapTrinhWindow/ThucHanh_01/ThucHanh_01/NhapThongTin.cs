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
    public partial class NhapThongTin : Form
    {
        string msg= "" ; 
        public NhapThongTin()
        {
            InitializeComponent();
            
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            //toolTip1.InitialDelay = 10;
            //toolTip1.Show(" Please", tb_name);
            msg = "Name:" + tb_name.Text + "\n";
            if (rdb_Male.Checked)
            {
                msg = msg + "Gender:" + rdb_Male.Text + "\n";
            }
            else
            {
                msg = msg + "Gender:" + rdb_Female.Text + "\n";
            }
            msg = msg + "Address: " + rtb_Add.Text + "\nQualification: ";
            for (int i = 0; i < clb_Qua.CheckedItems.Count; i++)
            {
                msg = msg + clb_Qua.CheckedItems[i].ToString() + ",";
            }
            msg = msg.Substring(0, msg.Length - 2);
            msg = msg + "\nAssets: ";
            if (cb_Home.Checked)
                msg = msg + cb_Home.Text + " ";
            if (cb_Car.Checked)
                msg = msg + cb_Car.Text + " ";
            if (cb_Bike.Checked)
                msg = msg + cb_Bike.Text + " ";
            MessageBox.Show("Information saved sucessfully: "+msg,"customer detail",MessageBoxButtons.OK,MessageBoxIcon.Information);
            tb_name.Text = null;
            rtb_Add.Text = null;
            cb_Home.Checked = false;
            cb_Car.Checked = false;
            cb_Bike.Checked = false;
            for (int j = 0; j < clb_Qua.CheckedItems.Count; j++)
            {
                //clb_Qua.CheckedItems[j] = false;
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Please customer Name: ", "customer detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }

        private void bt_NEXT_Click(object sender, EventArgs e)
        {
            Form ShowPicter = new Form();
            ShowPicter.Show();
            
            
        }


    }
}
