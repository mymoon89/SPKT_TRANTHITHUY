using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test11234
{
    public partial class Form1 : Form
    {
        private Box box;
        public Form1()
        {
            InitializeComponent();
            box = new Box(0.0, 0.0, 0.0);
        }
         
        private void ShowValueAtIndex( string prefix, int index )
      {
        resultTextBox.Text = 
           prefix + "box[ " + index + " ] = " + box[ index ];
   }
        private void ShowValueAtIndex( string prefix, string name )
     {
       resultTextBox.Text = 
           prefix + "box[ " + name + " ] = " + box[ name ];
     }
        private void ClearTextBoxes()
     {
        indexTextBox.Text = "";
        valueTextBox.Text = "";
     }
        private void intGetButton_Click(object sender,  EventArgs e )
     {
        ShowValueAtIndex( 
           "get: ", Int32.Parse( indexTextBox.Text ) );
        ClearTextBoxes();
     } 
        private void intSetButton_Click(object sender,  EventArgs e )
     {
        int index = Int32.Parse( indexTextBox.Text );
        box[ index ] = Double.Parse( valueTextBox.Text );
  
       ShowValueAtIndex( "set: ", index );
        ClearTextBoxes();
     } 
      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nameGetButton_Click(object sender, EventArgs e)
        {
            ShowValueAtIndex("get: ", indexTextBox.Text);
            ClearTextBoxes();
        }

        private void nameSetButton_Click(object sender, EventArgs e)
        {
            box[indexTextBox.Text] =Double.Parse(valueTextBox.Text);

            ShowValueAtIndex("set: ", indexTextBox.Text);
            ClearTextBoxes();
        }

   
    }
}
