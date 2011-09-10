using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PaintCSharp2010.Commands;
using System.Windows.Forms;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.ToolObject;

namespace PaintCSharp2010.ToolObject
{
    internal class ToolPointer : Tool
    {
        private enum SelectionMode
        {
            None,
            NetSelection, 
            Move, 
            Size 
        }

        private SelectionMode selectMode = SelectionMode.None;

        private DrawObject resizedObject;
        private int resizedObjectHandle;

       
        private Point lastPoint = new Point(0, 0);
        private Point startPoint = new Point(0, 0);
        private CommandChangeState commandChangeState;
        private bool wasMove;

     
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            commandChangeState = null;
            wasMove = false;

            selectMode = SelectionMode.None;
            Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));

            int al = drawArea.TheLayers.ActiveLayerIndex;
            int n = drawArea.TheLayers[al].Graphics.SelectionCount;

            for (int i = 0; i < n; i++)
            {
                DrawObject o = drawArea.TheLayers[al].Graphics.GetSelectedObject(i);
                int handleNumber = o.HitTest(point);

                if (handleNumber > 0)
                {
                    selectMode = SelectionMode.Size;
                 
                    resizedObject = o;
                    resizedObjectHandle = handleNumber;
                  
                    drawArea.TheLayers[al].Graphics.UnselectAll();
                    o.Selected = true;
                    commandChangeState = new CommandChangeState(drawArea.TheLayers);
                    o.Selected = true;
                    break;
                }
            }

            if (selectMode == SelectionMode.None)
            {
                int n1 = drawArea.TheLayers[al].Graphics.Count;
                DrawObject o = null;

                for (int i = 0; i < n1; i++)
                {
                    if (drawArea.TheLayers[al].Graphics[i].HitTest(point) == 0)
                    {
                        o = drawArea.TheLayers[al].Graphics[i];
                        break;
                    }
                }

                if (o != null)
                {
                    selectMode = SelectionMode.Move;

                  
                    if ((Control.ModifierKeys & Keys.Control) == 0 &&
                        !o.Selected)
                        drawArea.TheLayers[al].Graphics.UnselectAll();

                    o.Selected = true;
                    commandChangeState = new CommandChangeState(drawArea.TheLayers);

                    drawArea.Cursor = Cursors.SizeAll;
                }
            }

           
            if (selectMode == SelectionMode.None)
            {
                
                if ((Control.ModifierKeys & Keys.Control) == 0)
                    drawArea.TheLayers[al].Graphics.UnselectAll();

                selectMode = SelectionMode.NetSelection;
                drawArea.DrawNetRectangle = true;
            }

            lastPoint.X = point.X;
            lastPoint.Y = point.Y;
            startPoint.X = point.X;
            startPoint.Y = point.Y;

            drawArea.Capture = true;
            drawArea.NetRectangle = DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint);
            drawArea.Refresh();
        }
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            int al = drawArea.TheLayers.ActiveLayerIndex;
            wasMove = true;

            if (e.Button ==
                MouseButtons.None)
            {
                Cursor cursor = null;

                if (drawArea.TheLayers[al].Graphics != null)
                {
                    for (int i = 0; i < drawArea.TheLayers[al].Graphics.Count; i++)
                    {
                        int n = drawArea.TheLayers[al].Graphics[i].HitTest(point);

                        if (n > 0)
                        {
                            cursor = drawArea.TheLayers[al].Graphics[i].GetHandleCursor(n);
                            break;
                        }
                    }
                }

                if (cursor == null)
                    cursor = Cursors.Default;

                drawArea.Cursor = cursor;
                return;
            }

            if (e.Button !=
                MouseButtons.Left)
                return;

            int dx = point.X - lastPoint.X;
            int dy = point.Y - lastPoint.Y;

            lastPoint.X = point.X;
            lastPoint.Y = point.Y;

     
            if (selectMode == SelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    resizedObject.MoveHandleTo(point, resizedObjectHandle);
                    drawArea.Refresh();
                }
            }

            if (selectMode == SelectionMode.Move)
            {
                int n = drawArea.TheLayers[al].Graphics.SelectionCount;

                for (int i = 0; i < n; i++)
                {
                    drawArea.TheLayers[al].Graphics.GetSelectedObject(i).Move(dx, dy);
                }

                drawArea.Cursor = Cursors.SizeAll;
                drawArea.Refresh();
            }

            if (selectMode == SelectionMode.NetSelection)
            {
                drawArea.NetRectangle = DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint);
                drawArea.Refresh();
                return;
            }
        }

      
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            int al = drawArea.TheLayers.ActiveLayerIndex;
            if (selectMode == SelectionMode.NetSelection)
            {
         
                drawArea.TheLayers[al].Graphics.SelectInRectangle(drawArea.NetRectangle);

                selectMode = SelectionMode.None;
                drawArea.DrawNetRectangle = false;
            }

            if (resizedObject != null)
            {
       
                resizedObject.Normalize();
                resizedObject = null;
            }

            drawArea.Capture = false;
            drawArea.Refresh();

            if (commandChangeState != null && wasMove)
            {
               
                commandChangeState.NewState(drawArea.TheLayers);
                drawArea.AddCommandToHistory(commandChangeState);
                commandChangeState = null;
            }
            lastPoint = drawArea.BackTrackMouse(e.Location);
        }
    }
}
