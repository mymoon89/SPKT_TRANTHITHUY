using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ListViewProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        ListViewGroup gArchive;
        ListViewGroup gSystem;
        ListViewGroup gNormal;
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Windows\\");
            
            int i = 0;
            
            ListViewItem item1;
            string attribute = "";
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                i++;
                
                item1 = new ListViewItem(i.ToString());
                item1.SubItems.Add(f.Name);
                item1.SubItems.Add(
                    f.Length.ToString());
                attribute = f.Attributes.ToString();
                item1.SubItems.Add(attribute);
                if (attribute.StartsWith("Archive"))
                {
                    gArchive.Items.Add(item1);                    
                }
                if (attribute.StartsWith("Normal"))
                {
                    gNormal.Items.Add(item1);

                }
                if (attribute.StartsWith("System"))
                {
                    gSystem.Items.Add(item1);

                }
                listView1.Items.Add(item1);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("No", 30,
                HorizontalAlignment.Center);
            this.listView1.Columns.Add("Name", 120,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("Size", 50,
                HorizontalAlignment.Right);
            this.listView1.Columns.Add("Type", 120,
                            HorizontalAlignment.Right);
            listView1.View = View.Details;
            gArchive = new ListViewGroup("Archive");
            listView1.Groups.Add(gArchive);

            gSystem = new ListViewGroup("System");
            listView1.Groups.Add(gSystem);

            gNormal = new ListViewGroup("Normal");
            listView1.Groups.Add(gNormal);
        }
    }
}