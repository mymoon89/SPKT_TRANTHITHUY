using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void CreateControls()
        {
            LinkLabel ll = new LinkLabel();
            ll.Links.Add(15, 18, "mailto:sales@huukhang.com");
            ll.Links.Add(18, 23, "http://www.huukhang.com");
            this.Controls.Add(ll);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.linkLabel1.Links.Add(15, 18, "mailto:sales@huukhang.com");
            this.linkLabel2.Links.Add(18, 23, "http://www.huukhang.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strURL = Convert.ToString(e.Link.LinkData);
            if (strURL.StartsWith("mailto:"))
                Process.Start(strURL+"?subject=Hello");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strURL = Convert.ToString(e.Link.LinkData);
            if (strURL.StartsWith("http://www"))
                Process.Start(strURL);
        }
    }
}