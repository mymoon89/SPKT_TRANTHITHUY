using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NegativeNoException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double SquareRoot(double operand)
        {
            // if negative operand, throw NegativeNumberException
            if (operand < 0)
                throw new NegativeNumberException(
                   "KHong tinh so am cho can bat 2");

            // compute the square root
            return Math.Sqrt(operand);

        } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             label1.Text   = "";
   
         // catch any NegativeNumberExceptions thrown
         try
         {
            double result = 
               SquareRoot( Double.Parse( textBox1 .Text  ) );
            label1.Text = result.ToString();
         }

         // process invalid number format, this is system' exception
         catch (FormatException notInteger)
         {
             MessageBox.Show(notInteger.Message,
                "Loi sai", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
         }

         // display MessageBox if negative number input,user defined Exception
         catch (NegativeNumberException error)
         {
             MessageBox.Show(error.Message, "Invalid Operation",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

        }
    }
}
