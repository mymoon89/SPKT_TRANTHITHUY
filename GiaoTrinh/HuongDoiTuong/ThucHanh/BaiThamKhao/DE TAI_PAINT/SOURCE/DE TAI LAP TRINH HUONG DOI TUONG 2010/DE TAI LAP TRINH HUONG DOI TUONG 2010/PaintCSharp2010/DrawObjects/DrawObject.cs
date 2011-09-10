using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Globalization;
using System.Diagnostics;

namespace PaintCSharp2010.DrawObjects
{
 
    [Serializable]

    public abstract class DrawObject : IComparable
    {
        #region Members
       
        private bool selected;
        private Color color;
        private Color fillColor;
        private int penWidth;
        public string name = "";
       
        private static Color lastUsedColor = Color.Black;
        private static int lastUsedPenWidth = 1;
        private static Color lastfillcolor = Color.Transparent;
      
        private const string entryColor = "Color";
        private const string entryPenWidth = "PenWidth";
        private const string entryPen = "DrawPen";
        private const string entryBrush = "DrawBrush";
        private const string entryFillColor = "FillColor";
        private const string entryFilled = "Filled";
        private const string entryZOrder = "ZOrder";
        private const string entryRotation = "Rotation";
        private bool dirty;
        private int _id;
        private int _zOrder;
        private int _rotation = 0;

        #endregion Members

        #region Properties


     
        public int Rotation
        {
            get { return _rotation; }
            set
            {
                if (value > 360)
                    _rotation = value - 360;
                else if (value < -360)
                    _rotation = value + 360;
                else
                    _rotation = value;
            }
        }
        public string Shape
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public int ZOrder
        {
            get { return _zOrder; }
            set { _zOrder = value; }
        }

       
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

      
        public bool Dirty
        {
            get { return dirty; }
            set { dirty = value; }
        }

        
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

       
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

      
        public int PenWidth
        {
            get { return penWidth; }
            set { penWidth = value; }
        }


     
        public virtual int HandleCount
        {
            get { return 0; }
        }

     
        public static Color LastUsedColor
        {
            get { return lastUsedColor; }
            set { lastUsedColor = value; }
        }

        public static int LastUsedPenWidth
        {
            get { return lastUsedPenWidth; }
            set { lastUsedPenWidth = value; }
        }
   
        public static Color LastFilllColor
        {
            get
            {
                return lastfillcolor;
            }
            set
            {
                lastfillcolor = value;
            }


        }
        #endregion Properties



        #region Virtual Functions
   
        public abstract DrawObject Clone();

 
        public virtual void Draw(Graphics g)
        {
            _id = GetHashCode();
        }

   
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }


        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);
 
            return new Rectangle(point.X - (penWidth + 3), point.Y - (penWidth + 3), 7 + penWidth, 7 + penWidth);
        }
  
        public virtual void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;
            Pen p = new Pen(Color.BlueViolet, 1f);
            for (int i = 1; i <= HandleCount; i++)
            {
                g.DrawRectangle(p, GetHandleRectangle(i));

            }

        }
        public virtual void RemoveTracker(Graphics g)
        {
            if (!Selected)
                return;
            Pen p = new Pen(Color.Transparent, 0);
            for (int i = 1; i <= HandleCount; i++)
            {
                g.DrawRectangle(p, GetHandleRectangle(i));
            }
        }
   
        public virtual int HitTest(Point point)
        {
            return -1;
        }


    
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }


     
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

      
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

       
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }

        public virtual void Dump()
        {
            Trace.WriteLine("");
            Trace.WriteLine(GetType().Name);
            Trace.WriteLine("Selected = " + selected.ToString(CultureInfo.InvariantCulture));
        }

     
        public virtual void Normalize()
        {
        }


        
        public virtual void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryColor, orderNumber, objectIndex),Color.ToArgb());

            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryPenWidth, orderNumber, objectIndex),PenWidth);

            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryFillColor, orderNumber, objectIndex),FillColor.ToArgb());


            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryZOrder, orderNumber, objectIndex),ZOrder);

            info.AddValue(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryRotation, orderNumber, objectIndex),Rotation);
        }

     
        public virtual void LoadFromStream(SerializationInfo info, int orderNumber, int objectData)
        {
            int n = info.GetInt32(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryColor, orderNumber, objectData));Color = Color.FromArgb(n);

            PenWidth = info.GetInt32(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryPenWidth, orderNumber, objectData));


            n = info.GetInt32(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryFillColor, orderNumber, objectData));FillColor = Color.FromArgb(n);


            ZOrder = info.GetInt32(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryZOrder, orderNumber, objectData));

            Rotation = info.GetInt32(String.Format(CultureInfo.InvariantCulture,"{0}{1}-{2}",entryRotation, orderNumber, objectData));

        }
        #endregion Virtual Functions

        #region Other functions
      
        protected void Initialize()
        {
            color = lastUsedColor;
            fillColor = lastfillcolor;
            penWidth = lastUsedPenWidth;
        }

        
        protected void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject.selected = selected;
            drawObject.color = color;
            drawObject.penWidth = penWidth;
            drawObject.ID = ID;
            drawObject.fillColor = fillColor;
            drawObject._rotation = _rotation;

        }
        #endregion Other functions

        #region IComparable Members
        
        public int CompareTo(object obj)
        {
            DrawObject d = obj as DrawObject;
            int x = 0;
            if (d != null)
                if (d.ZOrder == ZOrder)
                    x = 0;
                else if (d.ZOrder > ZOrder)
                    x = -1;
                else
                    x = 1;

            return x;
        }
        #endregion IComparable Members
    }
}
