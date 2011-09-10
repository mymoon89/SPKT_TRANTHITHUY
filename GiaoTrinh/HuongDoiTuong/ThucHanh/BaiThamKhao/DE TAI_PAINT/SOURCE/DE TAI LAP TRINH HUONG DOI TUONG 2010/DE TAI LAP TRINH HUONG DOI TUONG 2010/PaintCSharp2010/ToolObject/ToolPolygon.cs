using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using System.Windows.Forms;
using System.Drawing;

namespace PaintCSharp2010.ToolObject
{
   
    internal class ToolPolygon : ToolObject
    {
        private DrawPolygon newPolygon;
        private bool _drawingInProcess = false; 
        
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                _drawingInProcess = false;
                newPolygon = null;
            }
            else
            {
                Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                if (_drawingInProcess == false)
                {
                    newPolygon = new DrawPolygon(e.X, e.Y, e.X + 1, e.Y + 1);
                    newPolygon.PointEnd = new Point(e.X + 1, e.Y + 1);
                    AddNewObject(drawArea, newPolygon);
                    _drawingInProcess = true;
                }
                else
                {
               
                    newPolygon.AddPoint(p);
                    newPolygon.PointEnd = p;
                }
            }


        }

     
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursors.Cross;
            if (e.Button !=
                MouseButtons.Left)
                return;
            if (newPolygon == null)
                return; 
            Point point = new Point(e.X, e.Y);
          
            newPolygon.MoveHandleTo(point, newPolygon.HandleCount);
            drawArea.Refresh();
        }
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {

            if (e.Button !=
                  MouseButtons.Left)
                return;
            if (newPolygon == null)
                return;
            Point point = new Point(e.X, e.Y);
           
            newPolygon.MoveHandleTo(point, newPolygon.HandleCount);
            drawArea.Refresh();
        }

    }
}
