using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PaintCSharp2010.DrawObjects;

namespace PaintCSharp2010.ToolObject
{
    
    internal class ToolRectangle : ToolObject
    {
        public ToolRectangle()
        {
           
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            AddNewObject(drawArea, new DrawRectangle(p.X, p.Y, 1, 1));
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursors.Cross;
            int al = drawArea.TheLayers.ActiveLayerIndex;
            if (e.Button ==
                MouseButtons.Left)
            {
                Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                drawArea.TheLayers[al].Graphics[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }
    }
}
