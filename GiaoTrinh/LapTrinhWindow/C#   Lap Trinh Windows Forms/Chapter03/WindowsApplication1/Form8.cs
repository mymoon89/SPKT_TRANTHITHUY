using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            doAdd();
            doAddRange();
           
        }
        void CreateControls()
        {
            CheckedListBox chk = new CheckedListBox();
            chk.Name = "chkCertificate";
            chk.Sorted = true;
            chk.Items.Add("B.A");
            chk.Items.Add("M.B.A");
            this.Controls.Add(chk);
        }

        void doAdd()
        {
            string strCon = "server=(local);";
            strCon = "database=northwind";
            strCon += ";uid=sa;pwd=sa;";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com;
            string strSQL = "select name from ";
            strSQL += " master.dbo.sysdatabases";
            Com = new SqlCommand(strSQL, Con);
            try
            {
                SqlDataReader dr;
                Con.Open();
                dr = Com.ExecuteReader();                
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetString(0));                    
                }
                dr.Close();
                dr.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show ("Error: "+ ex.Message);
                if (Con.State != ConnectionState.Closed)
                {

                    Con.Close();
                }
            }
            finally
            {
                Con.Dispose();
            }
                
        }
        
        void doAddRange()
        {
            string[] week = Directory.GetDirectories("C:\\"); ;
            checkedListBox2.Items.AddRange(week);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            label1.Text = ((e.NewValue == CheckState.Checked) ? checkedListBox1.Text  : "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strValues = "";
            foreach (string str in checkedListBox2.CheckedItems)
            {
                strValues += str + ",";                
            }
            MessageBox.Show("Folder: " + strValues, "HUUKHANG.COM");
        }
    }
}