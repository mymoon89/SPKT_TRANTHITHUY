using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProviderProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
           
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Login";
            toolTip1.SetToolTip(this.textBox1 , 
                "Username is not  blank");
            toolTip1.SetToolTip(this.textBox2, 
                "Password must be 6-10 characters");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}