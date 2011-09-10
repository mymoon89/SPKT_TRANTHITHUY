using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using System.Windows.Forms;
using System.Drawing;

namespace PaintCSharp2010.ToolObject
{
    internal class ToolCurve : ToolObject
    {

        private int lastX;
        private int lastY;
        private DrawCurve newPolygon;
        private int minDistance = 15 * 15;
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            newPolygon = new DrawCurve(p.X, p.Y, p.X + 1, p.Y + 1);
            minDistance = Convert.ToInt32((15 * drawArea.Zoom) * (15 * drawArea.Zoom));
            AddNewObject(drawArea, newPolygon);
            lastX = e.X;
            lastY = e.Y;
            drawArea.Refresh();
        }
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursors.Cross;
            if (e.Button !=
                MouseButtons.Left)
                return;

            if (newPolygon == null)
                return;
            Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            int distance = (e.X - lastX) * (e.X - lastX) + (e.Y - lastY) * (e.Y - lastY);

            if (distance < minDistance)
            {
                newPolygon.MoveHandleTo(point, newPolygon.HandleCount);
            }
            else
            {
                newPolygon.AddPoint(point);
                lastX = e.X;
                lastY = e.Y;
            }
            drawArea.Refresh();
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            newPolygon = null;
            base.OnMouseUp(drawArea, e);
        }
    }
}
