using System;
using System.Drawing;
using System.Windows.Forms;

namespace SplashProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            frmSplash f = new frmSplash();
            f.Show();
            System.Threading.Thread.Sleep(3000);
            f.Close();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}