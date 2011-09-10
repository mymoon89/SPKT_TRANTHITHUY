using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DivByZero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = ""; 
   
         // retrieve user input and call Quotient
         try
         {
            // Convert.ToInt32 generates FormatException if 
            // argument is not an integer
            int numerator = Convert.ToInt32(textBox1 .Text  );
            int denominator = Convert.ToInt32(textBox2 .Text );
   
            // division generates DivideByZeroException if
            // denominator is 0
            int result = numerator / denominator;
   
            label1.Text = result.ToString();
   
         } // end try
         catch (FormatException)
         {
             MessageBox.Show("Nhap 2 so Nguyen",
                "Bao sai",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         // user attempted to divide by zero
         catch (DivideByZeroException divideByZeroException)
         {
             MessageBox.Show(divideByZeroException.Message,
                "So Bi Chia la 0",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
