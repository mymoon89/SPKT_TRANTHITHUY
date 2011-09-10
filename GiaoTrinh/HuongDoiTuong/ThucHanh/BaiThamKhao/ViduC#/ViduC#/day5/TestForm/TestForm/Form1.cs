using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace TestForm
{
    public class ComplexTest : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label realLabel;
        private System.Windows.Forms.Label imaginaryLabel;
        private System.Windows.Forms.Label statusLabel;

        private System.Windows.Forms.TextBox realTextBox;
        private System.Windows.Forms.TextBox imaginaryTextBox;

        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button secondButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button multiplyButton;
        private ComplexNumber x = new ComplexNumber();
        private ComplexNumber y = new ComplexNumber();

        [STAThread]
        static void Main()
        {
            Application.Run(new ComplexTest());
        }
        private void firstButton_Click(
           object sender, System.EventArgs e)
        {
            x.Real = Int32.Parse(realTextBox.Text);
            x.Imaginary = Int32.Parse(imaginaryTextBox.Text);
            realTextBox.Clear();
            imaginaryTextBox.Clear();
            statusLabel.Text = "First Complex Number is: " + x;
        }

        private void secondButton_Click(
           object sender, System.EventArgs e)
        {
            y.Real = Int32.Parse(realTextBox.Text);
            y.Imaginary = Int32.Parse(imaginaryTextBox.Text);
            realTextBox.Clear();
            imaginaryTextBox.Clear();
            statusLabel.Text = "Second Complex Number is: " + y;
        }

        // add complex numbers
        private void addButton_Click(object sender, System.EventArgs e)
        {
            statusLabel.Text = x + " + " + y + " = " + (x + y);
        }

        // subtract complex numbers
        private void subtractButton_Click(
           object sender, System.EventArgs e)
        {
            statusLabel.Text = x + " - " + y + " = " + (x - y);
        }
        private void multiplyButton_Click(
          object sender, System.EventArgs e)
        {
            statusLabel.Text = x + " * " + y + " = " + (x * y);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // ComplexTest
            // 
            this.ClientSize = new System.Drawing.Size(403, 264);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ComplexTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
    }
}
