using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HinhHoc;

namespace ThuaKe_Form
{
    public partial class Form1 : Form
    {
        List<HinhHoc.ClassHinhHoc> dsHinh = new List<ClassHinhHoc>();
        public Form1()
        {
            InitializeComponent();
        }

        private void TamGiac_Click(object sender, EventArgs e)
        {
            /*Point dinhA = new Point(10, 10);
            Point dinhB = new Point(50, 50);
            Point dinhC = new Point(50, 20);
            TamGiac tg = new TamGiac(dinhA, dinhB, dinhC);*/

            TamGiac tg = new TamGiac();
            tg.Nhap();
            dsHinh.Add(tg);
            Graphics g = pictureBox1.CreateGraphics();
            this.Ve(g);

        }

        void Ve(Graphics g)
        {
            g.Clear(Color.White);
            foreach (HinhHoc.ClassHinhHoc hinh in dsHinh)
            {
                hinh.Ve(g);
            }
        }
        private void Doanthang_Click(object sender, EventArgs e)
        {
            Point DiemA = new Point(10, 10);
            Point DiemB = new Point(100, 100);
            DoanThang dt = new DoanThang(DiemA, DiemB);
            Graphics gdt = pictureBox1.CreateGraphics();
            dt.Ve(gdt);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                foreach (HinhHoc.ClassHinhHoc hinh in dsHinh)
                {
                    ILuaChon luachon = hinh as ILuaChon;
                    if (luachon != null && luachon.KiemTraDuocChon(p))
                    {
                        luachon.Chon = !luachon.Chon;
                    }
                }
            }
            else if(e.Button==MouseButtons.Right)
            {
                foreach (HinhHoc.ClassHinhHoc hinh in dsHinh)
                {
                    if (hinh is ILuaChon && ((ILuaChon)hinh).Chon)
                    {
                        IDiChuyen dichuyen = hinh as IDiChuyen;
                        if (dichuyen != null)
                        {
                            dichuyen.DiChuyenToi(p);
                        }
                    }
                }
            }
            Graphics g = pictureBox1.CreateGraphics();
            Ve(g);
        }
    }
}