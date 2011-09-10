using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;
using System.Drawing;
using System.Security.Permissions;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.GraphicsObject
{

    [Serializable]
    public class LayersList : ISerializable
    {
  
        private ArrayList layerList;

        private bool _isDirty;

  
        public bool Dirty
        {
            get
            {
                if (_isDirty == false)
                {
                    foreach (LayersPropeties l in layerList)
                    {
                        if (l.Dirty)
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
                foreach (LayersPropeties l in layerList)
                    l.Dirty = false;
                _isDirty = false;
            }
        }

        private const string entryCount = "LayerCount";
        private const string entryLayer = "LayerType";

        public LayersList()
        {
            layerList = new ArrayList();
        }

   
        public int ActiveLayerIndex
        {
            get
            {
                int i = 0;
                foreach (LayersPropeties l in layerList)
                {
                    if (l.IsActive)
                        break;
                    i++;
                }
                return i;
            }
        }
        public void Create()
        { }

        protected LayersList(SerializationInfo info, StreamingContext context)
        {
            layerList = new ArrayList();

            int n = info.GetInt32(entryCount);

            for (int i = 0; i < n; i++)
            {
                string typeName;
                typeName = info.GetString(
                    String.Format(CultureInfo.InvariantCulture,
                                  "{0}{1}",
                                  entryLayer, i));

                object _layer;
                _layer = Assembly.GetExecutingAssembly().CreateInstance(typeName);
                ((LayersPropeties)_layer).LoadFromStream(info, i);
                layerList.Add(_layer);
            }
        }


        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(entryCount, layerList.Count);

            int i = 0;

            foreach (LayersPropeties l in layerList)
            {
                info.AddValue(
                    String.Format(CultureInfo.InvariantCulture,
                                  "{0}{1}",
                                  entryLayer, i),
                    l.GetType().FullName);

                l.SaveToStream(info, i);
                i++;
            }
        }

        public void Draw(Graphics g)
        {
            foreach (LayersPropeties l in layerList)
            {
                if (l.IsVisible)
                    l.Draw(g);
            }
        }


        public bool Clear()
        {
            bool result = (layerList.Count > 0);
            foreach (LayersPropeties l in layerList)
                l.Graphics.Clear();

            layerList.Clear();
            
            CreateNewLayer("Default");

            
            if (result)
                _isDirty = false;
            return result;
        }

      
        public int Count
        {
            get { return layerList.Count; }
        }

  
        public LayersPropeties this[int index]
        {
            get
            {
                if (index < 0 ||
                    index >= layerList.Count)
                    return null;
                return (LayersPropeties)layerList[index];
            }
        }


        public void Add(LayersPropeties obj)
        {

            layerList.Insert(0, obj);
        }


        public void CreateNewLayer(string theName)
        {

            if (layerList.Count > 0)
                ((LayersPropeties)layerList[ActiveLayerIndex]).IsActive = false;

            LayersPropeties l = new LayersPropeties();
            l.IsVisible = true;
            l.IsActive = true;
            l.LayerName = theName;

            l.Graphics = new GraphicsList();

            Add(l);
        }


 
        public void InactivateAllLayers()
        {
            foreach (LayersPropeties l in layerList)
                l.IsActive = false;
        }


        public void MakeLayerInvisible(int p)
        {
            if (p > -1 &&
                p < layerList.Count)
                ((LayersPropeties)layerList[p]).IsVisible = false;
        }

      
        public void MakeLayerVisible(int p)
        {
            if (p > -1 &&
                p < layerList.Count)
                ((LayersPropeties)layerList[p]).IsVisible = true;
        }

        public void SetActiveLayer(int p)
        {
  
            if (ActiveLayerIndex == p)
                return;

            if (p > -1 &&
                p < layerList.Count)
            {
      
                if (((LayersPropeties)layerList[ActiveLayerIndex]).Graphics != null)
                    ((LayersPropeties)layerList[ActiveLayerIndex]).Graphics.UnselectAll();
                ((LayersPropeties)layerList[ActiveLayerIndex]).IsActive = false;
                ((LayersPropeties)layerList[p]).IsActive = true;
                ((LayersPropeties)layerList[p]).IsVisible = true;
            }
        }


        public void RemoveLayer(int p)
        {
            if (ActiveLayerIndex == p)
            {
                MessageBox.Show("Cannot Remove the Active Layer");
                return;
            }
            if (layerList.Count == 1)
            {
                MessageBox.Show("There is only one Layer in this drawing! You Cannot Remove the Only Layer!");
                return;
            }

            if (p > -1 &&
                p < layerList.Count)
            {
                ((LayersPropeties)layerList[p]).Graphics.Clear();
                layerList.RemoveAt(p);
            }
        }
    }
}
