using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Globalization;

namespace PaintCSharp2010.DrawObjects
{

    [Serializable]

    public class DrawRectangle : DrawObject
    {
        private Rectangle rectangle;
        public Point topleft, topright, bottomleft, bottomright, center;
        private int w, h;
        private const string entryRectangle = "Rect";

        protected Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public Point TopLeft
        {
            get
            {
                return topleft;
            }
            set
            {
                topleft = value;
            }
        }
        public Point TopRight
        {
            get
            {
                return topright;
            }
            set
            {
                topright = value;
            }
        }
        public Point BottomLeft
        {
            get
            {
                return bottomleft;
            }
            set
            {
                bottomleft = value;
            }
        }
        public Point BottomRight
        {
            get
            {
                return bottomright;
            }
            set
            {
                bottomright = value;
            }
        }
        public Point Center
        {
            get
            {
                return center;
            }
            set
            {
                center = value;
            }
        }
 
        public override DrawObject Clone()
        {
            DrawRectangle drawRectangle = new DrawRectangle();
            drawRectangle.rectangle = rectangle;

            FillDrawObjectFields(drawRectangle);
            return drawRectangle;
        }

        public DrawRectangle()
        {
            SetRectangle(0, 0, 1, 1);
            Initialize();
        }

        public DrawRectangle(int x, int y, int width, int height)
        {
            Center = new Point(x + (width / 2), y + (height / 2));
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width;
            rectangle.Height = height;
            Initialize();
        }
     
        public void changesizepen(IWin32Window parent, int penwitdh)
        {
            PenWidth = penwitdh;
            LastUsedPenWidth = penwitdh;
        }
        public void changefill(IWin32Window parent, Color clb)
        {
            LastFilllColor = clb;
        }

    
        public override void Draw(Graphics g)
        {
            Pen pen;
            Brush b = new SolidBrush(FillColor);
        
            pen = new Pen(Color, PenWidth);
         
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(GetNormalizedRectangle(Rectangle));
          
            if (Rotation != 0)
            {
                RectangleF pathBounds = gp.GetBounds();
                Matrix m = new Matrix();
                m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
                gp.Transform(m);
            }

            g.DrawPath(pen, gp);
            g.FillPath(b, gp);

            gp.Dispose();
            pen.Dispose();
            b.Dispose();
            Shape = "Rectangle";
        }

        protected void SetRectangle(int x, int y, int width, int height)
        {
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width;
            rectangle.Height = height;
            topleft = new Point(rectangle.Left, rectangle.Top);
            topright = new Point(rectangle.Right, rectangle.Top);
            bottomleft = new Point(rectangle.Left, rectangle.Bottom);
            bottomright = new Point(rectangle.Right, rectangle.Bottom);
            w = bottomright.X - bottomleft.X;
            h = bottomleft.Y - topleft.Y;
            center = new Point(bottomleft.X + (bottomright.X - bottomleft.X) / 2, topleft.Y + (bottomleft.Y - topleft.Y) / 2);
        }

        
        public override int HandleCount
        {
            get { return 8; }
        }

   
        public override Point GetHandle(int handleNumber)
        {
            int x, y, xCenter, yCenter;

            xCenter = rectangle.X + rectangle.Width / 2;
            yCenter = rectangle.Y + rectangle.Height / 2;
            x = rectangle.X;
            y = rectangle.Y;

            switch (handleNumber)
            {
                case 1:
                    x = rectangle.X;
                    y = rectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = rectangle.Y;
                    break;
                case 3:
                    x = rectangle.Right;
                    y = rectangle.Y;
                    break;
                case 4:
                    x = rectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = rectangle.Right;
                    y = rectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = rectangle.Bottom;
                    break;
                case 7:
                    x = rectangle.X;
                    y = rectangle.Bottom;
                    break;
                case 8:
                    x = rectangle.X;
                    y = yCenter;
                    break;
            }
            return new Point(x, y);
        }

     
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                        return i;
                }
            }

            if (PointInObject(point))
                return 0;
            return -1;
        }

        protected override bool PointInObject(Point point)
        {
            return rectangle.Contains(point);
        }

        
        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Hand;
            }
        }

     
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int left = Rectangle.Left;
            int top = Rectangle.Top;
            int right = Rectangle.Right;
            int bottom = Rectangle.Bottom;

            switch (handleNumber)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }
            Dirty = true;
            SetRectangle(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(Rectangle rectangle)
        {
            return Rectangle.IntersectsWith(rectangle);
        }

 
        public override void Move(int deltaX, int deltaY)
        {
            rectangle.X += deltaX;
            rectangle.Y += deltaY;
            Dirty = true;
            topleft = new Point(rectangle.Left, rectangle.Top);
            topright = new Point(rectangle.Right, rectangle.Top);
            bottomleft = new Point(rectangle.Left, rectangle.Bottom);
            bottomright = new Point(rectangle.Right, rectangle.Bottom);
            w = bottomright.X - bottomleft.X;
            h = bottomleft.Y - topleft.Y;
            center = new Point(bottomright.X - bottomleft.X, bottomleft.Y - topleft.Y);
        }

        public override void Dump()
        {
            base.Dump();

            Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

       
        public override void Normalize()
        {
            rectangle = GetNormalizedRectangle(rectangle);
        }

       
        public override void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryRectangle, orderNumber, objectIndex),rectangle);

            base.SaveToStream(info, orderNumber, objectIndex);
        }

    
        public override void LoadFromStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            rectangle = (Rectangle)info.GetValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryRectangle, orderNumber, objectIndex),typeof(Rectangle));

            base.LoadFromStream(info, orderNumber, objectIndex);
        }

        #region Helper Functions
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static Rectangle GetNormalizedRectangle(Rectangle r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }
        #endregion Helper Functions
        #region change pen

        public void changepen(IWin32Window parent, Color clb)
        {
            LastUsedColor = clb;
        }

        #endregion

        #region setproperty  dinh, chieu dai ,rong va tam       ;
        public int ShapWidth
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }
        public int ShapHeigh
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }

        }
        #endregion
    }
}
