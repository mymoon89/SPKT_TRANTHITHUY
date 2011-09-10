using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using PaintCSharp2010.DrawObjects;

namespace PaintCSharp2010.ToolObject
{   
    internal class ToolLine : ToolObject
    {
        public ToolLine()
        {
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            AddNewObject(drawArea, new DrawLine(p.X, p.Y, p.X + 1, p.Y + 1));
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursors.Cross;

            if (e.Button ==
                MouseButtons.Left)
            {
                Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                int al = drawArea.TheLayers.ActiveLayerIndex;
                drawArea.TheLayers[al].Graphics[0].MoveHandleTo(point, 2);

                drawArea.Refresh();

            }
        }
    }
}
