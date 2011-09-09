using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            doArray();
            doAddObject();
           doAddRangeObject();
        }
        void doArray()
        {
            string[] folder = Directory.GetDirectories("C:\\");
            listBox1.DataSource = folder;
        }
        void doAddObject()
        {
            clsItem cls;
            for (int i = 1; i <= 12; i++)
            {
                cls = new clsItem(i.ToString(), "Mon " + i.ToString());
                listBox2.Items.Add(cls);
            }
            listBox2.DisplayMember = "Name";
            listBox2.ValueMember = "Value";
        }
        void doAddRangeObject()
        {
            object[] week = new object[7];
            clsItem cls;
            for (int i = 1; i <= 7; i++)
            {
                cls = new clsItem(i.ToString(), "Weekday " + i.ToString());
                week[i - 1] = cls;
            }
            listBox3.Items.AddRange(week);
            listBox3.DisplayMember = "Name";
            listBox3.ValueMember = "Value";

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedValue.ToString() ,"HUUKHANG.COM");
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                clsItem cls = (clsItem)listBox2.SelectedItem;
                MessageBox.Show("value=" + cls.Value + ",name="+ cls.Name , "HUUKHANG.COM");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems != null)
            {
                string strValues = "";
                foreach (clsItem cls in listBox3.SelectedItems)
                    strValues += cls.Value + ",";
                MessageBox.Show("Days: " + strValues, "HUUKHANG.COM");
            }
        }
    }
}