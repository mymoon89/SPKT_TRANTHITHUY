using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            doArrayList();
            doArray();
            doAdd();
            doAddObject();
            doAddRange();
            doAddRangeObject();
        }
        void doArrayList()
        {
            clsItem   Item;
            ArrayList arr = new ArrayList();
            string strCon = "server=(local);";
            strCon = "database=northwind";
            strCon += ";uid=sa;pwd=sa;";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = strCon;
            SqlCommand Com;
            string strSQL = "select customerID, companyname";
            strSQL += " from Customers";
            Com = new SqlCommand(strSQL, Con);
            try
            {
                SqlDataReader dr;
                Con.Open();
                dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    Item = new clsItem(dr.GetString(0), dr[1].ToString());
                    arr.Add(Item);                    
                }
                comboBox3.DataSource = arr;
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Value";
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
        void doArray()
        {
            string[] folder = Directory.GetDirectories("C:\\");
            comboBox2.DataSource = folder;
        }
        void doAdd() 
        {
            for (int i = 1; i <= 12;i++ )
                comboBox5.Items.Add("Mon " + i.ToString());
        }
        void doAddObject()
        {
            clsItem cls;
            for (int i = 1; i <= 12; i++)
            {
                cls = new clsItem(i.ToString(), "Mon " + i.ToString());
                comboBox8.Items.Add(cls);
            }
            comboBox8.DisplayMember = "Name";
            comboBox8.ValueMember = "Value";
        }
        void doAddRange()
        {
            string[] week = new string[7] {"Sun","Mon","Tue","Wed","Thu","Fri","Sat"};
            comboBox6.Items.AddRange(week);
        }
        void doAddRangeObject()
        {
            object[] week = new object[7];
            clsItem cls;
            for (int i = 1; i <= 7; i++)
            {
                cls = new clsItem(i.ToString(), "Weekday " + i.ToString());
                week[i-1]=cls;
            }
            comboBox9.Items.AddRange(week);
            comboBox9.DisplayMember = "Name";
            comboBox9.ValueMember = "Value";
            
        }

        private void comboBox7_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox7.SelectedItem.ToString () , "HUUKHANG.COM");
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox5.SelectedText, "HUUKHANG.COM");
        }

         

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("value:=" + Convert.ToString(comboBox3.SelectedValue)
           , "HUUKHANG.COM");
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem!=null)
            {
                clsItem cls = (clsItem)comboBox8.SelectedItem;
                MessageBox.Show("value:=" + cls.Value +
                    ", name:=" + cls.Name, "HUUKHANG.COM");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox8.SelectedIndex  = 5;
            
        }

        
    }
}