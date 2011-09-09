using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TreeViewProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        void GetDisk()
        {
            int i = 0;
            foreach (string d in Directory.GetLogicalDrives())
            {
                this.treeView1.Nodes.Add(d);
                GetFolder(d, i);
                i++;
            }            
        }
        void GetFolder(string name, int level)
        {
            try
            {
                int level1 = 0;
                foreach (string d in Directory.GetDirectories(name))
                {
                    this.treeView1.Nodes[level].Nodes.Add(d.Substring(3));
                    GetFile(d, level, level1);
                    level1++;
                }
            }
            catch (Exception ex)
            { 
                
            }
        }
        void GetFile(string name, int level, int level1)
        {
            try
            {
                foreach (string d in Directory.GetFiles(name))
                {
                    this.treeView1.Nodes[level].Nodes[level1].Nodes.Add(d.Substring(name.Length+1));
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetDisk();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(e.Node.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }
    }
}