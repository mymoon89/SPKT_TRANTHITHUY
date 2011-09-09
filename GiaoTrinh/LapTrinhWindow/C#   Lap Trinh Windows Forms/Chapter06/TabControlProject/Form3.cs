using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TabControlProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CreateControls();
        }
        void CreateControls()
        {
            TabControl tc = new TabControl();
            tc.Name  = "Customers";
            TabPage tp = new TabPage();
            tp.Text = "Customers";
            ListView lv = new ListView();
            lv.View = View.Details;
            lv.Columns.Add("CustomerID");
            lv.Columns.Add("CustomerName");
            tp.Controls.Add(lv);
            tc.TabPages.Add(tp);
            tp = new TabPage();
            tp.Text = "Orders";
             lv = new ListView();
             lv.View = View.Details;
            lv.Columns.Add("OrderID");
            lv.Columns.Add("Date");
            tp.Controls.Add(lv);
            tc.TabPages.Add(tp);
            this.Controls.Add(tc);
        }

    }
}