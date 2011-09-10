using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PaintCSharp2010.GraphicsObject
{

  
    public class GraphicsProperties
    {
        private Color color;
        private Color fillcolor;
        private int penWidth;
        private bool colorDefined;
        private bool penWidthDefined;
        public GraphicsProperties()
        {
            color = Color.Black;
            penWidth = 1;
            colorDefined = false; ;
            penWidthDefined = false;
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public int PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                penWidth = value;
            }
        }

        public bool ColorDefined
        {
            get
            {
                return colorDefined;
            }
            set
            {
                colorDefined = value;
            }
        }

        public bool PenWidthDefined
        {
            get
            {
                return penWidthDefined;
            }
            set
            {
                penWidthDefined = value;
            }
        }
        public Color Fill
        {
            get
            {
                return fillcolor;
            }
            set
            {
                fillcolor = value;
            }
        }
    }
}
