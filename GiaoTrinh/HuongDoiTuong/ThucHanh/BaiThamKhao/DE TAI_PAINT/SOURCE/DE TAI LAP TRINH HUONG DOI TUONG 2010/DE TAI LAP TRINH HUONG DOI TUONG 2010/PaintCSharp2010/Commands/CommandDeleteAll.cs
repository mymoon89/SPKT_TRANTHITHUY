using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{
   
    internal class CommandDeleteAll : Command
    {
        private List<DrawObject> cloneList;


        public CommandDeleteAll(LayersList list)
        {
            cloneList = new List<DrawObject>();
     
            int n = list[list.ActiveLayerIndex].Graphics.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                cloneList.Add(list[list.ActiveLayerIndex].Graphics[i].Clone());
            }
        }

        public override void Undo(LayersList list)
        {
          
            foreach (DrawObject o in cloneList)
            {
                list[list.ActiveLayerIndex].Graphics.Add(o);
            }
        }

        public override void Redo(LayersList list)
        {
         
            list[list.ActiveLayerIndex].Graphics.Clear();
        }
    }
}
