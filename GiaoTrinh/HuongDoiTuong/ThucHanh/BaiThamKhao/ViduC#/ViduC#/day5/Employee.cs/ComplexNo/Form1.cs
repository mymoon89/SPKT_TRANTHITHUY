using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComplexNo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ComplexNumber x = new ComplexNumber();
        private ComplexNumber y = new ComplexNumber();

        private void button1_Click(object sender, EventArgs e)
        {
         x.Real = Int32.Parse( textBox1.Text );
         x.Imaginary = Int32.Parse( textBox2.Text );
         textBox1.Clear();
         textBox2.Clear();
         label3.Text = "First Complex Number is: " + x;

        }

        private void button2_Click(object sender, EventArgs e)
        {
         y.Real = Int32.Parse( textBox1.Text );
         y.Imaginary = Int32.Parse( textBox2.Text );
         textBox1.Clear();
         textBox2.Clear();
         label3.Text = "Second Complex Number is: " + y;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = x + " + " + y + " = " + (x + y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = x + " - " + y + " = " + (x - y);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = x + " * " + y + " = " + (x * y);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
 


         

         
    }
}
