using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ListViewProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\");
            this.listView1.Columns.Add("No", 45,
                HorizontalAlignment.Center);
            this.listView1.Columns.Add("Name", 120,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("Size", 50,
                HorizontalAlignment.Right);
            this.listView1.Columns.Add("Type", 120,
                            HorizontalAlignment.Right);
            int i = 0;
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.View = View.Details;
            ListViewItem item1;
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                i++;
                item1 = new ListViewItem(i.ToString());
                item1.SubItems.Add(f.Name);
                item1.SubItems.Add(
                    f.Length.ToString());
                item1.SubItems.Add(
                    f.Attributes.ToString());
                listView1.Items.Add(item1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strChecked="";
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                strChecked += item.SubItems[1].Text + ",";                
            }
            if (!strChecked.Equals(""))
                MessageBox.Show(strChecked);
        }
    }
}