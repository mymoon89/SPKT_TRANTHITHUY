using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PaintCSharp2010.DrawObjects
{
    public class DrawRoundedRectangle :DrawRectangle
    {
        public static int radius = 15;
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        public DrawRoundedRectangle()
        {
            SetRectangle(0, 0, 1, 1);
            Initialize();
        }
        public DrawRoundedRectangle(int x, int y, int width, int height)
        {
            Rectangle = new Rectangle(x, y, width, height);

            Initialize();
        }
 
        public override void Draw(Graphics g)
        {
            GraphicsPath grap = new GraphicsPath();
            Pen pen = new Pen(Color, PenWidth);
            SolidBrush p = new SolidBrush(FillColor);
            ////////////////////////////////////////////////////
            int width = Rectangle.Width;
            int height = Rectangle.Height;
            grap.AddLine(Rectangle.X + radius, Rectangle.Y, Rectangle.X + width - (radius * 2), Rectangle.Y);
            grap.AddArc(Rectangle.X + width - (radius * 2), Rectangle.Y, radius * 2, radius * 2, 270, 90);
            //////////////////////////////////////////////////////
            grap.AddLine(Rectangle.X + width, Rectangle.Y + radius, Rectangle.X + width, Rectangle.Y + height - (radius * 2));
            grap.AddArc(Rectangle.X + width - (radius * 2), Rectangle.Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            //////////////////////////////////////////////////////////
            grap.AddLine(Rectangle.X + width - (radius * 2), Rectangle.Y + height, Rectangle.X + radius, Rectangle.Y + height);
            grap.AddArc(Rectangle.X, Rectangle.Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            /////////////////////////////////////////////////////
            grap.AddLine(Rectangle.X, Rectangle.Y + height - (radius * 2), Rectangle.X, Rectangle.Y + radius);
            grap.AddArc(Rectangle.X, Rectangle.Y, radius * 2, radius * 2, 180, 90);
  
            if (Rotation != 0)
            {
                RectangleF pathBounds = grap.GetBounds();
                Matrix m = new Matrix();
                m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
                grap.Transform(m);
            }
            g.DrawPath(pen, grap);
            g.FillPath(p, grap);
            pen.Dispose();
            p.Dispose();
            Shape = "RoundedRectangle";



        }
    }
}
