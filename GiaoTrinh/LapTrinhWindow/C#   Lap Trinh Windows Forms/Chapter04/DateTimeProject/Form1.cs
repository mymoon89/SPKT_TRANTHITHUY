using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DateTimeProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void CreateControls()
        {
            DateTimePicker dtp = new DateTimePicker();
            dtp.Name = "OrderDate";
            dtp.Value = DateTime.Now.Date; 
            this.Controls.Add(dtp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = 
                Convert.ToDateTime("1/1/2006");
        }
        void File(DateTime dt, string Path)
        {
            listView1.Clear();
            DirectoryInfo dir = new DirectoryInfo(@Path);
            this.listView1.Columns.Add("No", 30,
                HorizontalAlignment.Center);
            this.listView1.Columns.Add("Name", 120,
                HorizontalAlignment.Left);
            this.listView1.Columns.Add("Size", 70,
                HorizontalAlignment.Right);
            this.listView1.Columns.Add("Type", 120,
                            HorizontalAlignment.Right);
            int i = 0;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            ListViewItem item1;
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                if (f.CreationTime >= dt)
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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            File(dateTimePicker1.Value,comboBox1.Text );
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            File(dateTimePicker1.Value, comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }
    }
}