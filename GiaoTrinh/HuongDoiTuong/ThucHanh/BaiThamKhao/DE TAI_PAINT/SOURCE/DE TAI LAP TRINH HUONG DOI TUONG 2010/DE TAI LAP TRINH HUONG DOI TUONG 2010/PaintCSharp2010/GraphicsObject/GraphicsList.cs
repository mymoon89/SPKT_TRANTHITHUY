using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;
using PaintCSharp2010.DrawObjects;
using System.Globalization;
using System.Reflection;

namespace PaintCSharp2010.GraphicsObject
{
    
    [Serializable]
    public class GraphicsList //	 : ISerializable
    {
        private ArrayList graphicsList;

        private bool _isDirty;

        public bool Dirty
        {
            get
            {
                if (_isDirty == false)
                {
                    foreach (DrawObject o in graphicsList)
                    {
                        if (o.Dirty)
                        {
                            _isDirty = true;
                            break;
                        }
                    }
                }
                return _isDirty;
            }
            set
            {
                foreach (DrawObject o in graphicsList)
                    o.Dirty = false;
                _isDirty = false;
            }
        }


        public IEnumerable<DrawObject> Selection
        {
            get
            {
                foreach (DrawObject o in graphicsList)
                {
                    if (o.Selected)
                    {
                        yield return o;
                    }
                }
            }
        }

        private const string entryCount = "ObjectCount";
        private const string entryType = "ObjectType";

        public GraphicsList()
        {
            graphicsList = new ArrayList();
        }

        public void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            graphicsList = new ArrayList();

            int n = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}",
                              entryCount, orderNumber));

            for (int i = 0; i < n; i++)
            {
                string typeName;
                typeName = info.GetString(
                    String.Format(CultureInfo.InvariantCulture,
                                  "{0}{1}",
                                  entryType, i));

                object drawObject;
                drawObject = Assembly.GetExecutingAssembly().CreateInstance(
                    typeName);

                ((DrawObject)drawObject).LoadFromStream(info, orderNumber, i);

                graphicsList.Add(drawObject);
            }
        }

      
        public void SaveToStream(SerializationInfo info, int orderNumber)
        {
            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}",
                              entryCount, orderNumber),
                graphicsList.Count);

            int i = 0;
            foreach (DrawObject o in graphicsList)
            {
                info.AddValue(
                    String.Format(CultureInfo.InvariantCulture,
                                  "{0}{1}",
                                  entryType, i),
                    o.GetType().FullName);

                o.SaveToStream(info, orderNumber, i);
                i++;
            }
        }

        public void Draw(Graphics g)
        {
            int n = graphicsList.Count;

        
            for (int i = n - 1; i >= 0; i--)
            {
                DrawObject o;
                o = (DrawObject)graphicsList[i];
           
                if (o.IntersectsWith(Rectangle.Round(g.ClipBounds)))
                    o.Draw(g);
            }
        }
       
        public DrawObject Getproperty()
        {
            int n = graphicsList.Count;
            DrawObject o;
            for (int i = 0; i < n; i++)
            {
                o = (DrawObject)graphicsList[i];
                if (o.Selected == true)
                    return o;
            }
            return null;

        }
      
        public void Tracker(Graphics g)
        {
            int n = graphicsList.Count;
            DrawObject o;
            for (int i = n - 1; i >= 0; i--)
            {
                o = (DrawObject)graphicsList[i];
                if (o.Selected == true)
                {
                    o.DrawTracker(g);
                }
            }
        }
        public void RmTracker(Graphics g)
        {
            int n = graphicsList.Count;
            DrawObject o;
            for (int i = n - 1; i >= 0; i--)
            {
                o = (DrawObject)graphicsList[i];
                if (o.Selected == true)
                {
                    o.RemoveTracker(g);
                }
            }
        }
       
        public bool Clear()
        {
            bool result = (graphicsList.Count > 0);
            graphicsList.Clear();
            
            if (result)
                _isDirty = false;
            return result;
        }


        public int Count
        {
            get { return graphicsList.Count; }
        }

        public DrawObject this[int index]
        {
            get
            {
                if (index < 0 ||
                    index >= graphicsList.Count)
                    return null;

                return (DrawObject)graphicsList[index];
            }
        }

       
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawObject o in graphicsList)
                {
                    if (o.Selected)
                        n++;
                }

                return n;
            }
        }

        public DrawObject GetSelectedObject(int index)
        {
            int n = -1;

            foreach (DrawObject o in graphicsList)
            {
                if (o.Selected)
                {
                    n++;

                    if (n == index)
                        return o;
                }
            }

            return null;
        }

        public void Add(DrawObject obj)
        {
            graphicsList.Sort();
            foreach (DrawObject o in graphicsList)
                o.ZOrder++;

            graphicsList.Insert(0, obj);
        }

        public void SelectInRectangle(Rectangle rectangle)
        {
            UnselectAll();

            foreach (DrawObject o in graphicsList)
            {
                if (o.IntersectsWith(rectangle))
                    o.Selected = true;
            }
        }

        public void UnselectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = false;
            }
        }

        public void SelectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = true;
            }
        }

   
        public bool DeleteSelection()
        {
            bool result = false;

            int n = graphicsList.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                if (((DrawObject)graphicsList[i]).Selected)
                {
                    graphicsList.RemoveAt(i);
                    result = true;
                }
            }
            if (result)
                _isDirty = true;
            return result;
        }

      
        public void DeleteLastAddedObject()
        {
            if (graphicsList.Count > 0)
            {
                graphicsList.RemoveAt(0);
            }
        }

      
        public void Replace(int index, DrawObject obj)
        {
            if (index >= 0 &&
                index < graphicsList.Count)
            {
                graphicsList.RemoveAt(index);
                graphicsList.Insert(index, obj);
            }
        }

        
        public void RemoveAt(int index)
        {
            graphicsList.RemoveAt(index);
        }

       
        public bool MoveSelectionToFront()
        {
            int n;
            int i;
            ArrayList tempList;

            tempList = new ArrayList();
            n = graphicsList.Count;

           
            for (i = n - 1; i >= 0; i--)
            {
                if (((DrawObject)graphicsList[i]).Selected)
                {
                    tempList.Add(graphicsList[i]);
                    graphicsList.RemoveAt(i);
                }
            }

         
            n = tempList.Count;

            for (i = 0; i < n; i++)
            {
                graphicsList.Insert(0, tempList[i]);
            }
            if (n > 0)
                _isDirty = true;
            return (n > 0);
        }

        
        public bool MoveSelectionToBack()
        {
            int n;
            int i;
            ArrayList tempList;

            tempList = new ArrayList();
            n = graphicsList.Count;

            for (i = n - 1; i >= 0; i--)
            {
                if (((DrawObject)graphicsList[i]).Selected)
                {
                    tempList.Add(graphicsList[i]);
                    graphicsList.RemoveAt(i);
                }
            }

   
            n = tempList.Count;

            for (i = n - 1; i >= 0; i--)
            {
                graphicsList.Add(tempList[i]);
            }
            if (n > 0)
                _isDirty = true;
            return (n > 0);
        }

       
        #region apply
        private GraphicsProperties GetProperties()
        {
            GraphicsProperties properties = new GraphicsProperties();
            int n = SelectionCount;
            if (n < 1)
                return properties;
            DrawObject o = GetSelectedObject(0);
            int firstColor = o.Color.ToArgb();
            int firstPenWidth = o.PenWidth;
            bool allColorsAreEqual = true;
            bool allWidthAreEqual = true;
            for (int i = 1; i < n; i++)
            {
                if (GetSelectedObject(i).Color.ToArgb() != firstColor)
                    allColorsAreEqual = false;

                if (GetSelectedObject(i).PenWidth != firstPenWidth)
                    allWidthAreEqual = false;
            }

            if (allColorsAreEqual)
            {
                properties.ColorDefined = true;
                properties.Color = Color.FromArgb(firstColor);
            }
            if (allWidthAreEqual)
            {
                properties.PenWidthDefined = true;
                properties.PenWidth = firstPenWidth;
            }

            return properties;
        }

        
        private bool ApplyProperties(GraphicsProperties properties)
        {
            bool changed = false;
            foreach (DrawObject o in graphicsList)
            {
                if (o.Selected)
                {
                    {
                        o.Color = properties.Color;
                        DrawObject.LastUsedColor = properties.Color;
                        changed = true;
                    }

                    if (properties.PenWidthDefined)
                    {
                        o.PenWidth = properties.PenWidth;
                        DrawObject.LastUsedPenWidth = properties.PenWidth;
                        changed = true;
                    }
                }
            }
            return changed;
        }
        public bool ShowPropertiesDialog(IWin32Window parent)
        {
            if (SelectionCount < 1)
                return false;
            GraphicsProperties properties = GetProperties();
            PropertiesDialog dlg = new PropertiesDialog();
            dlg.Properties = properties;
            if (dlg.ShowDialog(parent) !=
                DialogResult.OK)
                return false;
            if (ApplyProperties(properties))
            {
            }
            return true;
        }
        private bool FillApplyProperties(GraphicsProperties properties)
        {
            bool changed = false;
            foreach (DrawObject o in graphicsList)
            {
                if (o.Selected)
                {
                    o.FillColor = properties.Fill;
                 
                    o.PenWidth = 2;
                    changed = true;
                }
            }


            return changed;
        }
        public GraphicsProperties FillColor(IWin32Window parent, Color cl)
        {
            GraphicsProperties gr = new GraphicsProperties();
            gr.Fill = cl;
            FillApplyProperties(gr);
            return gr;
        }
        #endregion
    }
}
