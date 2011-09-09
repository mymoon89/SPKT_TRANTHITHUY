using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageListProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ListView listView1;
        private void Form2_Load(object sender, EventArgs e)
        {
            CreateListView();
            DirectoryInfo dir = new DirectoryInfo("C:\\");
            ListViewItem item1;
            int i = 0;
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                item1 = new ListViewItem(f.Name, i);
                item1.SubItems.Add(
                    f.Length.ToString());
                listView1.Items.Add(item1);
                i++;
                if (i == 10) i = 0;
            }
            this.Controls.Add(listView1);
        }
        void CreateListView()
        {
            listView1 = new ListView();
            listView1.Width = this.Width - 10;
            listView1.Height = this.Height - 10;
            listView1.LargeImageList = CreateImage();
            listView1.Columns.Add("Name", 170,
                HorizontalAlignment.Left);
            listView1.Columns.Add("Files", 40,
                HorizontalAlignment.Right);
            listView1.View = View.LargeIcon;
        }
        ImageList CreateImage()
        {
            ImageList imageList1 = new ImageList();
            string path=@"D:\Books\Examples\C#2005\Chapter05\icons\";
            Icon icon1;
            for (int i = 1; i <= 10; i++)
            {
                icon1 = new Icon(path + i.ToString() + ".ico");
                imageList1.Images.Add(icon1);
            }
            return imageList1;
        }
    }
}