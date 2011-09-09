using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Windows.Forms;

namespace PanelProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                panel2.Visible = false;
                panel1.Visible = true;
                btnClose.Text = "Back";
                btnNew.Text = "Save";
            }
            lbHeader.Text = "New Database";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Back")
            {
                panel2.Visible = true;
                panel1.Visible = false;
                btnClose.Text = "Close";
                btnNew.Text = "New";
            }
            else
                this.Close();
            lbHeader.Text = "Databases";

        }
        void LoadData(string strSQL)
        {
            string strCon = "server=(local);";
            strCon += "database=northwind";
            strCon += ";uid=sa;pwd=sa;";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com;
            Com = new SqlCommand(strSQL, Con);
            try
            {
                SqlDataReader dr;
                Con.Open();
                dr = Com.ExecuteReader();
                ListViewItem item1;
                while (dr.Read())
                {
                    item1 = new ListViewItem(dr[0].ToString());
                    item1.SubItems.Add(dr[1].ToString());
                    item1.SubItems.Add(dr[2].ToString());
                    lvData.Items.Add(item1);
                }


                dr.Close();
                dr.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            lvData.Columns.Add("Name", 100, 0);
            lvData.Columns.Add("Date", 70, 0);
            lvData.Columns.Add("File", 70, 0);
            lvData.View = View.Details;
            string strSQL = "select Name,CRdate,FileName";
            strSQL += " from master.dbo.sysdatabases";
            LoadData(strSQL);
        }
    }
}