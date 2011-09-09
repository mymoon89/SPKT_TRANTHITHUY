using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageListProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            int i = 0;
            listView1.LargeImageList = this.imageList1;
            DirectoryInfo dir = new DirectoryInfo("C:\\");
            this.listView1.Columns.Add("Name", 170,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("Files", 40,
                HorizontalAlignment.Right);
            listView1.View = View.LargeIcon;
            ListViewItem item1;
            foreach (DirectoryInfo f in dir.GetDirectories())
            {                
                item1 = new ListViewItem(f.Name, i);
                item1.SubItems.Add(
                    f.GetFiles("*.*").Length.ToString());
                listView1.Items.Add(item1);
                i++;
                if (i == 10) i = 0;
            }
        }
    }
}