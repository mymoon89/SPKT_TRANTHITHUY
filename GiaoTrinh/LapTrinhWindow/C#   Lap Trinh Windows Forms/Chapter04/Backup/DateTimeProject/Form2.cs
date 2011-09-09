using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Windows.Forms;

namespace DateTimeProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void CreateControls()
        {
            MonthCalendar mc = new MonthCalendar();
            mc.Name = "OrderDate";
            mc.ShowToday = true;
            mc.ShowTodayCircle = true;
            mc.TodayDate = DateTime.Now.Date;
            this.Controls.Add(mc);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string strSQL = "select EmployeeID,";
            strSQL+="Firstname + ' ' + LastName ";
            strSQL += " as FullName,BirthDate ";
            strSQL += " from Employees ";
            strSQL += " where BirthDate between cast('";
            strSQL += e.Start.Date.ToString("dd/MMM/yyyy");
            strSQL += "' as SmallDateTime) and cast('";
            strSQL += e.End.Date.ToString("dd/MMM/yyyy");
            strSQL += "' as SmallDateTime) ";
            Employees(strSQL );
        }
        
        void Employees( string strSQL)
        {            
            listView1.Items.Clear ();
            #region DatabaseConnection
            string strCon;
            strCon = "server=(local);";
            strCon += "database=northwind";
            strCon += ";uid=sa;pwd=sa;";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com;
            Com = new SqlCommand(strSQL, Con);
            #endregion
            listView1.FullRowSelect = true;
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
        private void Form2_Load(object sender, EventArgs e)
        {
            
            monthCalendar1.TodayDate = 
                DateTime.Now.Date ;
            monthCalendar1.SelectionStart = 
                Convert.ToDateTime("27/Jan/1966");
            monthCalendar1.SelectionEnd = 
                Convert.ToDateTime("27/Jan/1966");
            this.listView1.Columns.Add("No", 30,
                HorizontalAlignment.Center);
            this.listView1.Columns.Add("Name", 120,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("DOB", 70,
                HorizontalAlignment.Right);
            
        }
    }
}