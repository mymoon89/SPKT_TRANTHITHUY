using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{

    internal class CommandDelete : Command
    {
  
        private List<DrawObject> cloneList;

        
        public CommandDelete(LayersList list)
        {
            cloneList = new List<DrawObject>();

     

            foreach (DrawObject o in list[list.ActiveLayerIndex].Graphics.Selection)
            {
                cloneList.Add(o);
            }
        }

        public override void Undo(LayersList list)
        {
            list[list.ActiveLayerIndex].Graphics.UnselectAll();

           
            foreach (DrawObject o in cloneList)
            {
                list[list.ActiveLayerIndex].Graphics.Add(o);
            }
        }

        public override void Redo(LayersList list)
        {
        

            int n = list[list.ActiveLayerIndex].Graphics.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                bool toDelete = false;
                DrawObject objectToDelete = list[list.ActiveLayerIndex].Graphics[i];

                foreach (DrawObject o in cloneList)
                {
                    if (objectToDelete.ID ==
                        o.ID)
                    {
                        toDelete = true;
                        break;
                    }
                }

                if (toDelete)
                {
                    list[list.ActiveLayerIndex].Graphics.RemoveAt(i);
                }
            }
        }
    }
}
