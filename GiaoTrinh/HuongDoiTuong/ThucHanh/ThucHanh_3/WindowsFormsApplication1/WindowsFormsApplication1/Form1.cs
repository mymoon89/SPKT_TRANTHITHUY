using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            zoomno = 20;
            
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void hinh_MouseClick(object sender, EventArgs e)
        {
            Graphics g;
            g = hinh.CreateGraphics();
            Image newImage = Image.FromFile("ca.jpg");
            g.DrawImage(newImage, hinh.Width /72, hinh.Height / 72);
           
        }
        PictureBox PictureBox1 = new PictureBox();
        Button Button1 = new Button();

        private void InitializePictureBoxAndButton()
        {

            this.Controls.Add(PictureBox1);
            this.Controls.Add(Button1);
            Button1.Location = new Point(175, 20);
            Button1.Text = "Stretch";
            Button1.Click += new EventHandler(Button1_Click);

            // Set the size of the PictureBox control.
            this.PictureBox1.Size = new System.Drawing.Size(140, 140);

            //Set the SizeMode to center the image.
            this.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            // Set the border style to a three-dimensional border.
            this.PictureBox1.BorderStyle = BorderStyle.Fixed3D;

            // Set the image property.
            this.PictureBox1.Image = new Bitmap(typeof(Button), "chuot1.jpg");
        }
        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            // Set the SizeMode property to the StretchImage value.  This
            // will enlarge the image as needed to fit into
            // the PictureBox.
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile("ca.jpg");
            hinh.SizeMode = PictureBoxSizeMode.AutoSize;
            hinh.Image = img;

            if (img != null)
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                hinh.Image = img;
            }

        }

        private void button2_MouseClick(object sender, EventArgs e)
        {
            prnPrvControl.Size = new Size(zoomno * 10, zoomno * 10);
            zoomno = zoomno + 1;
            prnPrvControl.AutoZoom = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ht = prnPrvControl.Height;
            wd = prnPrvControl.Width;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //prnPrvControl.Size = new Size(wd, ht);
            //zoomno = 20;
            //this.u
        }
    }
}
