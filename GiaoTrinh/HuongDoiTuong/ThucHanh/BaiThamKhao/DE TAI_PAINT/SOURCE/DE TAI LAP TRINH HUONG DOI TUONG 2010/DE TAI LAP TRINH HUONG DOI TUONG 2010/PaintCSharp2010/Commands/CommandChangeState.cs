using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{
   
    internal class CommandChangeState : Command
    {
       
        private List<DrawObject> listBefore;

     
        private List<DrawObject> listAfter;

       
        private int activeLayer;

  
        public CommandChangeState(LayersList layerList)
        {
         
            activeLayer = layerList.ActiveLayerIndex;
            FillList(layerList[activeLayer].Graphics, ref listBefore);
        }


     
        public void NewState(LayersList layerList)
        {
            FillList(layerList[activeLayer].Graphics, ref listAfter);
        }

        public override void Undo(LayersList list)
        {
           
            ReplaceObjects(list[activeLayer].Graphics, listBefore);
        }

        public override void Redo(LayersList list)
        {
          
            ReplaceObjects(list[activeLayer].Graphics, listAfter);
        }

    
        private void ReplaceObjects(GraphicsList graphicsList, List<DrawObject> list)
        {
            for (int i = 0; i < graphicsList.Count; i++)
            {
                DrawObject replacement = null;

                foreach (DrawObject o in list)
                {
                    if (o.ID ==
                        graphicsList[i].ID)
                    {
                        replacement = o;
                        break;
                    }
                }

                if (replacement != null)
                {
                    graphicsList.Replace(i, replacement);
                }
            }
        }
    
        private void FillList(GraphicsList graphicsList, ref List<DrawObject> listToFill)
        {
            listToFill = new List<DrawObject>();

            foreach (DrawObject o in graphicsList.Selection)
            {
                listToFill.Add(o.Clone());
            }
        }

    }
}
