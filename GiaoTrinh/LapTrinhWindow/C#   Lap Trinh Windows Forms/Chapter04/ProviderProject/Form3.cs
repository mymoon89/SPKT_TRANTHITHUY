using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProviderProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        void CreateControls()
        {
            ErrorProvider rp = new ErrorProvider();

            rp.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            TextBox txt = new TextBox();
            txt.Name = "txtUser";
            rp.SetError(txt, "Blank is not valid");
            this.Controls.Add(txt);
        }
        private void textBox2_Validated(object sender, EventArgs e)
        {
            if (textBox2.Text !="")
            {                
                errorProvider1.SetError(this.textBox2, "");
            }
            else
            {
                
                errorProvider1.SetError(this.textBox2, 
                    "Password is required.");
            }

        }
    }
}