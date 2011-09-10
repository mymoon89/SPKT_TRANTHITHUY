using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{
    internal class CommandPaste : Command
    {
        private List<DrawObject> ListPaste;
        public CommandPaste(LayersList layer, List<DrawObject> ListCopyToPaste)
        {
            this.ListPaste = ListCopyToPaste;
            layer[layer.ActiveLayerIndex].Graphics.UnselectAll();
            layer.Create();
            foreach (DrawObject o in ListPaste)
            {
                layer[layer.ActiveLayerIndex].Graphics.Add(o);
            }
            layer[layer.ActiveLayerIndex].Graphics.SelectAll();
        }
        public override void Undo(LayersList list)
        {
            int n = list[list.ActiveLayerIndex].Graphics.Count - 1;
            list[list.ActiveLayerIndex].Graphics.RemoveAt(n);
        }
        public override void Redo(LayersList list)
        {
        }
    }
}
