using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProviderProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            HelpProvider hp = new HelpProvider();
            hp.HelpNamespace = @"D:\Books\Examples\C#2005\Chapter04\ProviderProject\cs.chm";
            hp.SetHelpKeyword(textBox4, "Telephone");
            hp.SetHelpNavigator(textBox4, HelpNavigator.Index);
            hp.SetHelpString(textBox4, "Telephone");
            hp.SetShowHelp(textBox4, true);
        }
    }
}