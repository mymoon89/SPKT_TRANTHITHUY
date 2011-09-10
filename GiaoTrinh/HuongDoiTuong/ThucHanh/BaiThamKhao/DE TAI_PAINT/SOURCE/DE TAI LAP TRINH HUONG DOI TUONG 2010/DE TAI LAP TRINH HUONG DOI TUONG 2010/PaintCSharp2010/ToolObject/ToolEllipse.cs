using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PaintCSharp2010.DrawObjects;

namespace PaintCSharp2010.ToolObject
{   
    internal class ToolEllipse : ToolRectangle
    {
        public ToolEllipse()
        {         
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            AddNewObject(drawArea, new DrawEllipse(p.X, p.Y, 1, 1));
        }

    }
}
