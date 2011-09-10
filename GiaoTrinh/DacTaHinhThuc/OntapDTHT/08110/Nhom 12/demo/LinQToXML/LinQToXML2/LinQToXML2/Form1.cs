using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinQToXML2
{
    public partial class Form1 : Form
    {
        Bitmap bit = new Bitmap(650, 566);
        Graphics gr;
        Point diemdau;
        Point diemcuoi;
        Point []P1;
        Point []P2;
        Point []temp;
        Point []temp1;
        Color co;
        Color []mangmau;
        Color []mangtam;
        int i = 0;
        int j = 0;
        int l = 0;
        
        public Form1()
        {
            InitializeComponent();
            temp = new Point[50];
            temp1 = new Point[50];
            mangtam = new Color[50];
        }
        private Color[] TaoMangMau(int k, Color[] c)
        {
            c[k] = co;
            return c;
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            co = colorDialog1.Color;
            //mangmau = TaoMangMau(l, mangtam);
            //l++;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            gr.Clear(Color.White);
            pbShape.Image = bit;
        }
        private Point[] TaoDiemDau(int k, Point[] p)
        {
            p[k] = new Point(diemdau.X, diemdau.Y);
            return p;
        }
        private Point[] TaoDiemCuoi(int k, Point[] p)
        {
            p[k] = new Point(diemcuoi.X, diemcuoi.Y);
            return p;
        }
        private void pbShape_MouseDown(object sender, MouseEventArgs e)
        {
            if (!co.Name.Equals("0"))
            {
                diemdau = new Point(e.X, e.Y);
                P1 = TaoDiemDau(i, temp);
                i++;
            }
        }
        
        private void pbShape_MouseUp(object sender, MouseEventArgs e)
        {
            
            
            if (co.Name.Equals("0"))
            {
                MessageBox.Show("Bạn Chưa Chọn Màu Vẽ");
            }
            else
            {
                mangmau = TaoMangMau(l, mangtam);
                l++;

                diemcuoi = new Point(e.X, e.Y);
                P2 = TaoDiemCuoi(j, temp1);
                j++;

                gr = Graphics.FromImage(bit);
                Pen p = new Pen(co, 5);

                gr.DrawLine(p, diemdau, diemcuoi);                
                pbShape.Image = bit;
            }
                
        }
        private XDocument LoadXmlDocument(string url)
        {
            //Hàm load một file xml vào đối tượng XDocument
            try
            {
                return XDocument.Load(url);
            }
            catch
            {
                return null;
            }
        }
        public int HexToDec(string hex)
        {
            string hexa = "0123456789ABCDEF";
            int len = hex.Length - 1;
            int dec = 0;

            for (int i = 0; i <= len; i++)
            {
                int tam = len - i;
                int index = hexa.IndexOf(hex[i]);
                dec += index * (int)Math.Pow(16, tam);
            }

            return dec;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //XDocument doc = LoadXmlDocument("Shape.xml");
            //doc.Descendants("Line").Last().AddAfterSelf(new XElement("Line",                                                            
            //                                                new XElement("X1", diemdau.X.ToString()),
            //                                                new XElement("Y1", diemdau.Y.ToString()),
            //                                                new XElement("X2", diemcuoi.X.ToString()),
            //                                                new XElement("Y2", diemcuoi.Y.ToString()),
            //                                                new XElement("Color", "Green")));
            XDocument doc = LoadXmlDocument("Shape.xml");

            for (int m = 0; m < i; m++)
            {
                //if (mangmau[m].Name.Equals("0"))
                //    mangmau[m] = co;
                if (P1[m].X == 0 && P1[m].Y == 0 && P2[m].X == 0 && P2[m].Y == 0)
                    break;
                doc.Descendants("Line").Last().AddAfterSelf(new XElement("Line",
                                                                new XElement("X1", P1[m].X.ToString()),
                                                                new XElement("Y1", P1[m].Y.ToString()),
                                                                new XElement("X2", P2[m].X.ToString()),
                                                                new XElement("Y2", P2[m].Y.ToString()),
                                                                new XElement("Color", mangmau[m].Name)));
                doc.Save("Shape.xml");
            }
            
            MessageBox.Show("Lưu Thành Công!");
            for (int t = 0; t < i; t++)
            {
                P1[t] = new Point(0, 0);
                P2[t] = new Point(0, 0);                
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //string myColor = "Red";
            //Color cd = (Color)Convert.ChangeType(myColor, typeof(Color), null);
            XDocument doc = LoadXmlDocument("Shape.xml");
            int[] data = new int[4];
            Color color;
            string mau;

            foreach (XElement p in doc.Descendants("Line"))
            {
                //data[0] = int.Parse(p.Attribute("ID").Value);
                data[0] = int.Parse(p.Element("X1").Value);
                data[1] = int.Parse(p.Element("Y1").Value);
                data[2] = int.Parse(p.Element("X2").Value);
                data[3] = int.Parse(p.Element("Y2").Value);
                
                mau = p.Element("Color").Value;
                if (mau.StartsWith("ff"))
                {
                    string _alpha = mau.Substring(0, 2);
                    string _red = mau.Substring(2, 2);
                    string _green = mau.Substring(4, 2);
                    string _blue = mau.Substring(6, 2);


                    int alpha = HexToDec(_alpha.ToUpper());
                    int red = HexToDec(_red.ToUpper());
                    int green = HexToDec(_green.ToUpper());
                    int blue = HexToDec(_blue.ToUpper());
                    color = Color.FromArgb(alpha, red, green, blue);

                    //MessageBox.Show(argb.ToString());
                }
                else
                    color = Color.FromName(mau);


                diemdau = new Point(data[0], data[1]);
                diemcuoi = new Point(data[2], data[3]);


                gr = Graphics.FromImage(bit);
                Pen pen = new Pen(color, 5);

                gr.DrawLine(pen, diemdau, diemcuoi);
                pbShape.Image = bit;
            }

        }
    }
}
