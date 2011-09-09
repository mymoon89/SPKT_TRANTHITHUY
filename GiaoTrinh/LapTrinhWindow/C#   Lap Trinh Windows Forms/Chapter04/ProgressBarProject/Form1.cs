using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProgressBarProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int j ;
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("H:\\");
            this.progressBar1.Maximum = dir.GetDirectories().Length;
            int i = 0 ;
            j = 0;
            foreach (DirectoryInfo f in dir.GetDirectories())
            {
                i++;
                this.progressBar1.Value=i;
                this.label1.Text = f.Name;
                readfile(f.FullName);
            }
            this.label1.Text = "Completed";
            this.label2.Text = i.ToString()+" folders and " + j.ToString()+ " files" ;
        }
        void readfile(string foldername)
        {
            DirectoryInfo dir = new DirectoryInfo(foldername);                        
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                j++;
                this.label2.Text = f.Name;
                Application.DoEvents();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void CreateControls()
        {
            ProgressBar pb = new ProgressBar();
            pb.Name = "Process";
            pb.Maximum = 100;
            pb.Minimum = 0;            
            this.Controls.Add(pb);
        }

    }
}