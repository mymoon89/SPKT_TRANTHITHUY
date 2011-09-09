using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TreeViewProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string strCon ;
        void GetDatabase(string strSQL )
        {
            treeView1.Nodes.Clear();
            
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com;
            Com = new SqlCommand(strSQL, Con);
            try
            {
                SqlDataReader dr;
                Con.Open();
                dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    treeView1.Nodes.Add(dr.GetString(0)); 
                }
                dr.Close();
                dr.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message);
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
         
        void GetTable(string strSQL)
        {
            listView1.Clear();            
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com;
            Com = new SqlCommand(strSQL, Con);
            listView1.Columns.Add("ID", 70, 0);
            listView1.Columns.Add("Name", 150, 0);
            listView1.Columns.Add("Date", 70, 0);
            listView1.View = View.Details;
            ListViewItem item1;
            try
            {
                SqlDataReader dr;
                Con.Open();
                dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    item1 = new ListViewItem(dr[0].ToString());
                    item1.SubItems.Add(dr.GetString(1));
                    item1.SubItems.Add(dr[2].ToString());
                    listView1.Items.Add(item1);            
                }
                dr.Close();
                dr.Dispose();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
        private void button1_Click(object sender, EventArgs e)
        {
            string SQL = "select name from ";
            SQL+="master.dbo.sysdatabases";
            GetDatabase(SQL);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string SQL = "select id,name,crdate from ";
            SQL += e.Node.Text +".dbo.sysobjects";
            SQL += " where type='U' order by name";
            GetTable(SQL);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            strCon = "server=(local);";
            strCon += "database=northwind";
            strCon += ";uid=sa;pwd=sa;";
        }
        void CreateControls()
        {
            TreeView tv = new TreeView(); 
            tv.Name = "Computer";
            tv.Nodes.Add("Root");
            tv.Nodes[0].Nodes.Add("A:\\");
            tv.Nodes[0].Nodes.Add("B:\\");
            tv.Nodes[0].Nodes.Add("C:\\");
            tv.Nodes[0].Nodes.Add("D:\\");
            this.Controls.Add(tv);
        }
    }
}