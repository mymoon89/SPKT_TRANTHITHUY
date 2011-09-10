using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.ToolObject;

namespace PaintCSharp2010.ToolObject
{
    internal abstract class ToolObject : Tool
    {
        private Cursor cursor;
        protected Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }        
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            int al = drawArea.TheLayers.ActiveLayerIndex;
            if (drawArea.TheLayers[al].Graphics.Count > 0)
                drawArea.TheLayers[al].Graphics[0].Normalize();
            drawArea.Capture = false;
            drawArea.Refresh();
        }
        protected void AddNewObject(DrawArea drawArea, DrawObject o)
        {
            int al = drawArea.TheLayers.ActiveLayerIndex;
            drawArea.TheLayers[al].Graphics.UnselectAll();
            o.Selected = true;
            o.Dirty = true;
            drawArea.TheLayers[al].Graphics.Add(o);
            drawArea.Capture = true;
            drawArea.Refresh();
        }
    }
}
