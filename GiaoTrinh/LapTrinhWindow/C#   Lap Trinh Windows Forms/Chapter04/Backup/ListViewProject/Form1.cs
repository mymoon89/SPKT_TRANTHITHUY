using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ListViewProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void CreateControls()
        {
            ListView lv = new ListView();
            lv.Name = "lvFile";
            lv.Columns.Add("No", 30,
                HorizontalAlignment.Center);
            lv.Columns.Add("Name", 120,
                HorizontalAlignment.Left);
            lv.Columns.Add("Size", 50,
                HorizontalAlignment.Right);
            lv.Columns.Add("Type", 120,
                HorizontalAlignment.Right);
            int i = 0;
            lv.FullRowSelect = true;
            lv.View = View.Details;            
            this.Controls.Add(lv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\");
            this.listView1.Columns.Add("No", 30, 
                HorizontalAlignment.Center);
            this.listView1.Columns.Add("Name", 120, 
                HorizontalAlignment.Left );
            this.listView1.Columns.Add("Size", 50, 
                HorizontalAlignment.Right );
            this.listView1.Columns.Add("Type", 120,
                            HorizontalAlignment.Right);
            int i = 0;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            ListViewItem item1  ;            
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                i++;
                
                
                item1 = new ListViewItem(i.ToString());
                item1.SubItems.Add (f.Name);
                item1.SubItems.Add(
                    f.Length.ToString());
                item1.SubItems.Add(
                    f.Attributes.ToString());
                
                listView1.Items.Add(item1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.ShowDialog();
        }

         

        
    }
}