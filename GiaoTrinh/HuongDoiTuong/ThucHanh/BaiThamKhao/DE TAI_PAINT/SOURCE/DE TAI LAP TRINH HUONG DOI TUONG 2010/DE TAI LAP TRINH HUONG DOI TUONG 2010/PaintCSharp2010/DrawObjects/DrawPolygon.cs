﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace PaintCSharp2010.DrawObjects
{
 

    internal class DrawPolygon : DrawLine
    {
     
        private Point startPoint;
        private Point endPoint;
        private ArrayList pointArray; // list of points
        private const string entryLength = "Length";
        private const string entryPoint = "Point";

        public override DrawObject Clone()
        {
            DrawPolygon drawPolygon = new DrawPolygon();
            drawPolygon.startPoint = startPoint;
            drawPolygon.endPoint = endPoint;
            drawPolygon.pointArray = pointArray;
            FillDrawObjectFields(drawPolygon);
            return drawPolygon;
        }

        public DrawPolygon()
        {
            pointArray = new ArrayList();
            Initialize();
        }

        public DrawPolygon(int x1, int y1, int x2, int y2)
        {
            pointArray = new ArrayList();
            pointArray.Add(new Point(x1, y1));
            pointArray.Add(new Point(x2, y2));
            PointStart = new Point(x1, y1);
            PointEnd = new Point(x2, y2);
            Initialize();
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, PenWidth);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Point[] pts = new Point[pointArray.Count];
            for (int i = 0; i < pointArray.Count; i++)
            {
                Point px = (Point)pointArray[i];
                pts[i] = px;
            }
            byte[] types = new byte[pointArray.Count];
            for (int i = 0; i < pointArray.Count; i++)
                types[i] = (byte)PathPointType.Line;
            GraphicsPath gp = new GraphicsPath(pts, types);
         
            if (Rotation != 0)
            {
                RectangleF pathBounds = gp.GetBounds();
                Matrix m = new Matrix();
                m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
                gp.Transform(m);
            }
            g.DrawPath(pen, gp);
            gp.Dispose();
            if (pen != null)
                pen.Dispose();
            Shape = "Polygon";
        }

        public void AddPoint(Point point)
        {
            pointArray.Add(point);
        }

        public override int HandleCount
        {
            get
            {
                return pointArray.Count;
            }
        }

 
        public override Point GetHandle(int handleNumber)
        {
            if (handleNumber < 1)
                handleNumber = 1;
            if (handleNumber > pointArray.Count)
                handleNumber = pointArray.Count;
            return ((Point)pointArray[handleNumber - 1]);
        }

        public override void MoveHandleTo(Point point, int handleNumber)
        {
            if (handleNumber < 1)
                handleNumber = 1;
            if (handleNumber > pointArray.Count)
                handleNumber = pointArray.Count;
            pointArray[handleNumber - 1] = point;
            Invalidate();
        }

        public override void Move(int deltaX, int deltaY)
        {
            int n = pointArray.Count;

            for (int i = 0; i < n; i++)
            {
                Point point;
                point = new Point(((Point)pointArray[i]).X + deltaX, ((Point)pointArray[i]).Y + deltaY);
                pointArray[i] = point;
                PointEnd = point;

            }

            Invalidate();
        }

        public override void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryLength, orderNumber, objectIndex),pointArray.Count);

            int i = 0;
            foreach (Point p in pointArray)
            {
                info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}-{3}",new object[] { entryPoint, orderNumber, objectIndex, i++ }),p);
            }
            base.SaveToStream(info, orderNumber, objectIndex);
        }

        public override void LoadFromStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            int n = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryLength, orderNumber, objectIndex));

            for (int i = 0; i < n; i++)
            {
                Point point;
                point = (Point)info.GetValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}-{3}",new object[] { entryPoint, orderNumber, objectIndex, i }),typeof(Point));
                pointArray.Add(point);
            }
            base.LoadFromStream(info, orderNumber, objectIndex);
        }

      
        protected override void CreateObjects()
        {
            if (AreaPath != null)
                return;

           
            AreaPath = new GraphicsPath();

            int x1 = 0, y1 = 0; 

            IEnumerator enumerator = pointArray.GetEnumerator();

            if (enumerator.MoveNext())
            {
                x1 = ((Point)enumerator.Current).X;
                y1 = ((Point)enumerator.Current).Y;
            }

            while (enumerator.MoveNext())
            {
                int x2, y2; 
                x2 = ((Point)enumerator.Current).X;
                y2 = ((Point)enumerator.Current).Y;

                AreaPath.AddLine(x1, y1, x2, y2);

                x1 = x2;
                y1 = y2;
            }

            AreaPath.CloseFigure();

            
            AreaRegion = new Region(AreaPath);
        }


    }
}
