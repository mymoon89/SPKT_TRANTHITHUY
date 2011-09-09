using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShapeOfFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmCircle();
            GraphicsPath shape;
            shape = new GraphicsPath();
            shape.AddEllipse(15, 25, this.Width, this.Height);
            frm.Region = new Region(shape);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmOthers();
            GraphicsPath shape;
            shape = new GraphicsPath();
            Point point1 = new Point(100, 50);
            Point point2 = new Point(250, 100);
            Point point3 = new Point(300, 200);
            Point point4 = new Point(180, 300);
            Point point5 = new Point(80, 200);
            Point point6 = new Point(30, 150);
            Point[] points = { point1, point2, point3, point4, point5, point6 };

            shape.AddCurve(points);
            frm.Region = new Region(shape);
            frm.Show();
        }
    }
}