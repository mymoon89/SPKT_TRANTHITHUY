using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

// Box class definition represents a box with length, 
// width and height dimensions
public class Box
{
    private string[] names = { "length", "width", "height" };
    private double[] dimensions = new double[3];

    // constructor
    public Box(double length, double width, double height)
    {
        dimensions[0] = length;
        dimensions[1] = width;
        dimensions[2] = height;
    }

    // access dimensions by index number
    public double this[int index]
    {
        get
        {
            return (index < 0 || index > dimensions.Length) ?
               -1 : dimensions[index];
        }
        set
        {
            if (index >= 0 && index < dimensions.Length)
                dimensions[index] = value;
        }

    } // end numeric indexer

    // access dimensions by their names
    public double this[string name]
    {
        get
        {
            // locate element to get
            int i = 0;

            while (i < names.Length &&
                   name.ToLower() != names[i])
                i++;

            return (i == names.Length) ? -1 : dimensions[i];
        }

        set
        {
            // locate element to set
            int i = 0;

            while (i < names.Length &&
                   name.ToLower() != names[i])
                i++;
            if (i != names.Length)
                dimensions[i] = value;
        }

    } // end indexer

} // end class Box

// Class IndexerTest
public class IndexerTest : System.Windows.Forms.Form
{
    private System.Windows.Forms.Label indexLabel;
    private System.Windows.Forms.Label nameLabel;

    private System.Windows.Forms.TextBox indexTextBox;
    private System.Windows.Forms.TextBox valueTextBox;

    private System.Windows.Forms.Button nameSetButton;
    private System.Windows.Forms.Button nameGetButton;

    private System.Windows.Forms.Button intSetButton;
    private System.Windows.Forms.Button intGetButton;

    private System.Windows.Forms.TextBox resultTextBox;

    // required designer variable
    private System.ComponentModel.Container components = null;

    private Box box;

    // constructor
    public IndexerTest()
    {
        // required for Windows Form Designer support
        //InitializeComponent();
        // create block
        box = new Box(0.0, 0.0, 0.0);
    }

    // Visual Studio .NET generated code

    // main entry point for application
    [STAThread]
    static void Main()
    {
        Application.Run(new IndexerTest());
    }

    // display value at specified index number
    private void ShowValueAtIndex(string prefix, int index)
    {
        resultTextBox.Text =
           prefix + "box[ " + index + " ] = " + box[index];
    }

    // display value with specified name
    private void ShowValueAtIndex(string prefix, string name)
    {
        resultTextBox.Text =
           prefix + "box[ " + name + " ] = " + box[name];
    }

    // clear indexTextBox and valueTextBox
    private void ClearTextBoxes()
    {
        indexTextBox.Text = "";
        valueTextBox.Text = "";
    }
    // get value at specified index
    private void intGetButton_Click(
       object sender, System.EventArgs e)
    {
        ShowValueAtIndex(
           "get: ", Int32.Parse(indexTextBox.Text));
        ClearTextBoxes();
    }

    // set value at specified index
    private void intSetButton_Click(
       object sender, System.EventArgs e)
    {
        int index = Int32.Parse(indexTextBox.Text);
        box[index] = Double.Parse(valueTextBox.Text);

        ShowValueAtIndex("set: ", index);
        ClearTextBoxes();
    }

    // get value with specified name
    private void nameGetButton_Click(
       object sender, System.EventArgs e)
    {
        ShowValueAtIndex("get: ", indexTextBox.Text);
        ClearTextBoxes();
    }
    // set value with specified name
    private void nameSetButton_Click(
       object sender, System.EventArgs e)
    {
        box[indexTextBox.Text] =
           Double.Parse(valueTextBox.Text);

        ShowValueAtIndex("set: ", indexTextBox.Text);
        ClearTextBoxes();
    }

} // 