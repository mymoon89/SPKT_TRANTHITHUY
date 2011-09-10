using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaintCSharp2010.ToolObject;

namespace PaintCSharp2010.ToolObject
{
    internal class ToolFill : Tool
    {
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursors.Default;
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer;


        }
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursors.Default;

        }
    }
}
