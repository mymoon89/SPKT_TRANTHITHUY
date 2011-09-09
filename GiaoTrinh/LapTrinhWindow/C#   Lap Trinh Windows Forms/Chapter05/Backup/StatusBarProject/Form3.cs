using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StatusBarProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            listView1.Items.Clear();
            DirectoryInfo dir = new 
                DirectoryInfo(@"C:\WINDOWS\system32\");
            
            ListViewItem item1;
            toolStripProgressBar1.Maximum 
                = dir.GetFiles("*.*").Length;
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {             
                item1 = new ListViewItem(f.Name );
                item1.SubItems.Add(
                    f.Length.ToString());
                listView1.Items.Add(item1);                
               
                toolStripProgressBar1.Value = i;
                i++;
                
            } toolStripStatusLabel1.Text = i.ToString()+" file(s)";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("Name", 200,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("Files", 50,
                HorizontalAlignment.Right);
            listView1.View = View.Details;
        }
    }
}