using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace TypeOfFormProject
{
    public partial class frmInherit : Form
    {
        public frmInherit()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(txtPath.Text);
                lvData.Columns.Add("Name", 100, 0);
                lvData.Columns.Add("Size", 50, 0);
                lvData.Columns.Add("Date", 70, 0);
                lvData.View = View.Details;
                ListViewItem item1;
                 foreach(FileInfo d in dir.GetFiles("*.*"))   
                 {
                    item1 = new ListViewItem( d.Name);
                    item1.SubItems.Add(d.Length.ToString());
                    item1.SubItems.Add(d.CreationTime.ToLongDateString());
                    lvData.Items.Add(item1);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show (ex.Message );
            }
        }
    }
}