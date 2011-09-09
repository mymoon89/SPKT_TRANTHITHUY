using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using N=System.Windows.Forms.SystemInformation;
namespace TabControlProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Drive();
            Network();
        }

        void Network()
        {     
            listView2.Columns.Add("No", 40, 0);
            listView2.Columns.Add("Name", 100, 0);
            listView2.Columns.Add("Value", 100, 0);
            listView2.View = View.Details;            
            ListViewItem item1;
            item1=new ListViewItem("1");
            item1.SubItems.Add("Computer Name");
            item1.SubItems.Add(N.ComputerName);
            listView2.Items.Add(item1);
            item1 = new ListViewItem("2");
            item1.SubItems.Add("User Name");
            item1.SubItems.Add(N.UserName);
            listView2.Items.Add(item1);
            item1 = new ListViewItem("3");
            item1.SubItems.Add("Domain Name");
            item1.SubItems.Add(N.UserDomainName);
            listView2.Items.Add(item1);
            item1 = new ListViewItem("4");
            item1.SubItems.Add("Logged");
            item1.SubItems.Add(N.Network.ToString());
            listView2.Items.Add(item1);  
        }
        void Drive()
        { 
            listView1.Columns.Add("No", 70, 0);
            listView1.Columns.Add("Name", 100, 0);                       
            listView1.View = View.Details;
            int i=0;
             ListViewItem item1;
            foreach(string d in Directory.GetLogicalDrives())
            {
                i++;
                item1=new ListViewItem(i.ToString());
                item1.SubItems.Add(d);
                listView1.Items.Add(item1);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            this.Text=e.TabPage.Text;
            if (e.TabPage.Text.Equals("Image"))
            {
                Form frm = new Form2();
                frm.ShowDialog();
            }
        }
    }
}