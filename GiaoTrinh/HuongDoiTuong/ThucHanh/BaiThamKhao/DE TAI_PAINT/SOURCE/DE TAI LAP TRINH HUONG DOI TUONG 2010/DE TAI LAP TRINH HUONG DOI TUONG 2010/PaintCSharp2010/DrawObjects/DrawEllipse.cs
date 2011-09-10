using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PaintCSharp2010.DrawObjects
{

    [Serializable]
    public class DrawEllipse : DrawRectangle
    {

        
        public DrawEllipse()
        {
            SetRectangle(0, 0, 1, 1);
            Initialize();
        }

        public DrawEllipse(int x, int y, int width, int height)
        {
            Rectangle = new Rectangle(x, y, width, height);

            Initialize();
        }
        public override void Draw(Graphics g)
        {

            SolidBrush n = new SolidBrush(FillColor);
            Pen pen = new Pen(Color, PenWidth);
          
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(GetNormalizedRectangle(Rectangle));
         
            if (Rotation != 0)
            {
                RectangleF pathBounds = gp.GetBounds();
                Matrix m = new Matrix();
                m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
                gp.Transform(m);
            }
            g.DrawPath(pen, gp);
            g.FillPath(n, gp);
            gp.Dispose();
            n.Dispose();
            pen.Dispose();
            Shape = "Ellipse";
        }
    }
}
