using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ListViewProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            DirectoryInfo dir = new DirectoryInfo("C:\\");            
            this.listView1.Columns.Add("Name", 200,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("Files", 50,
                HorizontalAlignment.Right);
            listView1.View = View.LargeIcon;
            ListViewItem item1;
            foreach (DirectoryInfo f in dir.GetDirectories())
            {
                int j = ((i%2)==0)?0:1;
                item1 = new ListViewItem(f.Name,j);                    
                item1.SubItems.Add(
                    f.GetFiles("*.*").Length.ToString());
                listView1.Items.Add(item1);
                i++;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List ;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FocusedItem;
            MessageBox.Show(item.Text,"HuuKhang.com");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        
    }
}