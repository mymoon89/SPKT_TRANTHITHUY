using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PaintCSharp2010.ToolObject
{
    internal abstract class Tool
    {
        public virtual void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
        }
        public virtual void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
        }
        public virtual void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
        }
    }
}
