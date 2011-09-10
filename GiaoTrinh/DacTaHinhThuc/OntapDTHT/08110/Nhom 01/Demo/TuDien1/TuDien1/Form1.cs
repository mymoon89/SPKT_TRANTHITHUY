using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Xml;
namespace TuDien1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public XElement xmlword;
        private void laydulieu()
        {
             xmlword = XElement.Load("Source.xml");
            List<word> Words = (from q in xmlword.Elements("Word")
                                select new word
                                {
                                    enlish = q.Element("English").Value,
                                    phonetic = q.Element("Phonetic").Value,
                                    vietnamese = q.Element("Vietnamese").Value

                                }).ToList<word>();
            foreach (word w in Words)
            {
                List_tudien.Items.Add(w.enlish);
            }
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            laydulieu();
            cmb_ngonngu.SelectedIndex = 0;
            grb2.Hide();
        }

        private void List_tudien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (List_tudien.SelectedItem != null)
            {
                txt_timkiem.Text = List_tudien.SelectedItem.ToString();
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grb3.Show();
            grb2.Hide();
            xmlword = XElement.Load("Source.xml");
            List<word> Words = (from q in xmlword.Elements("Word")
                                select new word
                                {
                                    enlish = q.Element("English").Value,
                                    phonetic = q.Element("Phonetic").Value,
                                    vietnamese = q.Element("Vietnamese").Value

                                }).ToList<word>();
            foreach(word w in Words)
            {
                if (w.enlish==txt_timkiem.Text)
                {
                    txt_Phonetic.Text = w.phonetic.ToString();
                    txt_vietnamese.Text = w.vietnamese.ToString();
                }
            }
           
        }

        private void btn_themtu_Click(object sender, EventArgs e)
        {

            grb2.Show();
            grb3.Hide();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            string str_Enlish = txt_tienganh.Text;
            string str_Vietnamese = txt_nghiaviet.Text;
            string str_Phonetic = txt_phienam.Text;
            XmlDocument themmoi = new XmlDocument();
            themmoi.Load(Application.StartupPath + "\\Source.xml");
            XmlNode nodeEnglish = themmoi.SelectNodes("/Dictionary/Word")[0];
            XmlNode newnode = nodeEnglish.CloneNode(true);
            newnode.SelectSingleNode("English").InnerXml = str_Enlish;
            newnode.SelectSingleNode("Vietnamese").InnerXml = str_Vietnamese;
            newnode.SelectSingleNode("Phonetic").InnerXml = str_Phonetic;
            themmoi.DocumentElement.AppendChild(newnode);
            themmoi.Save(Application.StartupPath + "\\Source.xml");
            laydulieu();
            MessageBox.Show("Thêm từ thành công !");
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_thaydoi_Click(object sender, EventArgs e)
        {
            int i = 0;
            XmlNodeList xmlphienam, xmlnghia, xmltienganh;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("Source.xml");
            xmltienganh = xmldoc.GetElementsByTagName("English");
            xmlphienam = xmldoc.GetElementsByTagName("Phonetic");
            xmlnghia = xmldoc.GetElementsByTagName("Vietnamese");
            if (rd_phienam.Checked == true)
            {
                for (i = 0; i < xmltienganh.Count; i++)
                {
                    if (xmltienganh[i].InnerText == txt_timkiem.Text)
                    {
                        xmlphienam[i].InnerText = txt_fix.Text;
                        xmldoc.Save("Source.xml");
                        MessageBox.Show("Sửa phiên âm thành công !");
                    }
                }
            }
            if (rd_nghia.Checked == true)
            {
                for (i = 0; i < xmltienganh.Count; i++)
                {
                    if (xmltienganh[i].InnerText == txt_timkiem.Text)
                    {
                        xmlnghia[i].InnerText = txt_nghiaviet.Text;
                        xmldoc.Save("Source.xml");
                        MessageBox.Show("Sửa phiên âm thành công !");
                    }
                }
            }
            laydulieu();
        }

    }

}
