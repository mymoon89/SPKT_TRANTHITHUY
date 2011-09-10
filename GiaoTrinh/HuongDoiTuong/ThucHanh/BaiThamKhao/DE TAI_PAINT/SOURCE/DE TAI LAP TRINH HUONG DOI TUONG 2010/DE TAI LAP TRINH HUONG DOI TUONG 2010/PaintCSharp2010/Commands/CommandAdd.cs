using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{
    internal class CommandAdd : Command
    {
        private DrawObject drawObject;
        public CommandAdd(DrawObject drawObject): base()
        {        
            this.drawObject = drawObject.Clone();
        }
        public override void Undo(LayersList list)
        {
            list[list.ActiveLayerIndex].Graphics.DeleteLastAddedObject();
        }
        public override void Redo(LayersList list)
        {
            list[list.ActiveLayerIndex].Graphics.UnselectAll();
            list[list.ActiveLayerIndex].Graphics.Add(drawObject);
        }

    }
}
