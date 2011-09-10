using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaintCSharp2010.GraphicsObject;
using PaintCSharp2010.DrawObjects;
using PaintCSharp2010.Commands;
using PaintCSharp2010.DocManagers;
using System.Drawing.Drawing2D;
using PaintCSharp2010.ToolObject;

namespace PaintCSharp2010
{
    /// <summary>
    /// Working area.
    /// Handles mouse input and draws graphics objects.
    /// </summary>
    internal partial class DrawArea : UserControl
    {
        #region Constructor, Dispose
        public DrawArea()
        {
            this.CopToPas = new List<DrawObject>();
            // create list of Layers, with one default active visible layer
            _layers = new LayersList();
            player = new LayersList();
            _layers.CreateNewLayer("Default");
            _panning = false;
            _panX = 0;
            _panY = 0;
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


        }
        #endregion Constructor, Dispose

        #region Enumerations
        public enum DrawToolType
        {
            Pointer,
            Rectangle,
            Ellipse,
            Line,
            Curve,
            Polygon,
            Text,
            Image,
            Fill,
            RoudedRectangle,
            NumberOfDrawTools
        } ;
        #endregion Enumerations

        #region Members
        private float _zoom = 1.0f;
        private float _rotation = 0f;
        private int _panX = 0;
        private int _panY;
        private int _originalPanY;
        private bool _panning = false;
        private Point lastPoint;
        private GraphicsList grp = new GraphicsList();
        private DrawRectangle drec = new DrawRectangle();

        private LayersList _layers, player;
        private List<DrawObject> CopToPas;
        private PasteManager pasteManager;

        private DrawToolType activeTool;
        private Tool[] tools; 

      
        private MainForm owner;
        private DocManager docManager;

        
        private Rectangle netRectangle;
        private bool drawNetRectangle = false;
        private UndoManager undoManager;

        private Form myparent;
        #endregion Members

        #region Properties
        public Form MyParent
        {
            get { return myparent; }
            set { myparent = value; }
        }
        public GraphicsList GraphicsList
        {
            get
            {
                return grp;
            }
            set
            {
                grp = value;
            }
        }
     
        public DrawRectangle Rectangle
        {
            get
            {
                return drec;
            }
            set
            {
                drec = value;
            }
        }




      
        public int OriginalPanY
        {
            get { return _originalPanY; }
            set { _originalPanY = value; }
        }

      
        public bool Panning
        {
            get { return _panning; }
            set { _panning = value; }
        }

  
        public int PanX
        {
            get { return _panX; }
            set { _panX = value; }
        }


        public int PanY
        {
            get { return _panY; }
            set { _panY = value; }
        }

  
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }


        public Rectangle NetRectangle
        {
            get { return netRectangle; }
            set { netRectangle = value; }
        }

      
        public bool DrawNetRectangle
        {
            get { return drawNetRectangle; }
            set { drawNetRectangle = value; }
        }

       
        public MainForm Owner
        {
            get { return owner; }
            set { owner = value; }
        }

      
        public DocManager DocManager
        {
            get { return docManager; }
            set { docManager = value; }
        }


    
        public DrawToolType ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }

        public LayersList TheLayers
        {
            get { return _layers; }
            set { _layers = value; }
        }
        public LayersList Player
        {
            get { return player; }
            set { player = value; }
        }

        
        public bool CanUndo
        {
            get
            {
                if (undoManager != null)
                {
                    return undoManager.CanUndo;
                }

                return false;
            }
        }

       
        public bool CanRedo
        {
            get
            {
                if (undoManager != null)
                {
                    return undoManager.CanRedo;
                }

                return false;
            }
        }

        #endregion

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2, -ClientSize.Height / 2, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2 + _panX, ClientSize.Height / 2 + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            e.Graphics.Transform = mx;
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            e.Graphics.FillRectangle(brush,ClientRectangle);
           
            if (_layers != null)
            {
                int lc = _layers.Count;
                for (int i = 0; i < lc; i++)
                {
                    if (_layers[i].IsVisible)
                        if (_layers[i].Graphics != null)
                            _layers[i].Graphics.Draw(e.Graphics);

                }
            }
            if (GraphicsList != null)
            {
                if (activeTool == DrawToolType.Pointer || activeTool == DrawToolType.Fill)
                {
                    TheLayers[0].Graphics.Tracker(e.Graphics);
                }
            }
            DrawObject o = TheLayers[0].Graphics.Getproperty();
            DrawNetSelection(e.Graphics);
            brush.Dispose();

        }
        private void DrawNetSelection(Graphics g)
        {
            if (!DrawNetRectangle)
                return;

            ControlPaint.DrawFocusRectangle(g, NetRectangle, Color.Black, Color.Transparent);
        }
        internal Point BackTrackMouse(Point p)
        {
            
            Point[] pts = new Point[] { p };
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2, -ClientSize.Height / 2, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2 + _panX, ClientSize.Height / 2 + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            mx.Invert();
            mx.TransformPoints(pts);
            return pts[0];
        }
        public void Initialize(MainForm owner, DocManager docManager)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            Invalidate();
          
            this.Owner = owner;
            DocManager = docManager;

            
            activeTool = DrawToolType.Pointer;

            undoManager = new UndoManager(_layers);
            pasteManager = new PasteManager(_layers);

            
            tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
            tools[(int)DrawToolType.Pointer] = new ToolPointer();
            tools[(int)DrawToolType.Curve] = new ToolCurve();
            tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
            tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
            tools[(int)DrawToolType.Line] = new ToolLine();
            
            tools[(int)DrawToolType.Polygon] = new ToolPolygon();
            tools[(int)DrawToolType.Image] = new ToolImage();
            tools[(int)DrawToolType.Fill] = new ToolFill();
            tools[(int)DrawToolType.RoudedRectangle] = new ToolRoundedRectangle();
        }
        public void ClearHistory()
        {
            undoManager.ClearHistory();
        }
        public void AddCommandToHistory(Command command)
        {
            undoManager.AddCommandToHistory(command);
        }
        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = BackTrackMouse(e.Location);
            if (e.Button ==
                MouseButtons.Left)
                tools[(int)activeTool].OnMouseDown(this, e);
            else if (e.Button ==
         MouseButtons.Right)
            {
                if (_panning)
                    _panning = false;
                if (activeTool == DrawToolType.Polygon)
                    tools[(int)activeTool].OnMouseDown(this, e);
                ActiveTool = DrawToolType.Pointer;
                OnContextMenu(e);
            }
        }
        private void OnContextMenu(MouseEventArgs e)
        {
            
            Point point = new Point(e.X, e.Y);
            int n = GraphicsList.Count;
            DrawObject o = null;
            for (int i = 0; i < n; i++)
            {
                if (GraphicsList[i].HitTest(point) == 0)
                {
                    o = GraphicsList[i];
                    break;
                }
            }
            if (o != null)
            {
                if (!o.Selected)
                    GraphicsList.UnselectAll();
             
                o.Selected = true;
            }
            else
            {
                GraphicsList.UnselectAll();
            }

            Refresh();
          
            MainMenu mainMenu = Owner.Menu;   
            MenuItem editItem = mainMenu.MenuItems[1];            
           
            MenuItem[] items = new MenuItem[editItem.MenuItems.Count];
            for (int i = 0; i < editItem.MenuItems.Count; i++)
            {
                items[i] = editItem.MenuItems[i];
            }
            Owner.SetStateOfControls(); 
          
            ContextMenu menu = new ContextMenu(items);
            menu.Show(this, point);
           
            editItem.MergeMenu(menu);
        }
        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            Point curLoc = BackTrackMouse(e.Location);
            if (e.Button == MouseButtons.Left ||
                e.Button == MouseButtons.None)
                if (e.Button == MouseButtons.Left && _panning)
                {
                    if (curLoc.X !=
                        lastPoint.X)
                        _panX += curLoc.X - lastPoint.X;
                    if (curLoc.Y !=
                        lastPoint.Y)
                        _panY += curLoc.Y - lastPoint.Y;
                    Invalidate();
                }
                else
                    tools[(int)activeTool].OnMouseMove(this, e);
            else
                Cursor = Cursors.Default;
            lastPoint = BackTrackMouse(e.Location);
            if (e.Button == MouseButtons.None)
               // Owner.mlc.Text = e.X + "," + e.Y;
            this.docManager.Dirty = true;
        }
        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = BackTrackMouse(e.Location);
            if (e.Button ==
                MouseButtons.Left)
            {
                if (TheLayers[0].Graphics.Count != 0)
                    this.AddCommandToHistory(new CommandAdd(this.TheLayers[0].Graphics[0]));
                tools[(int)activeTool].OnMouseUp(this, e);
            }
            Invalidate();
        }
        public void CopyToPaste(LayersList layer)
        {
            int al = layer.ActiveLayerIndex;
            int n = layer[al].Graphics.SelectionCount;
            DrawObject o;
            for (int i = 0; i < n; i++)
            {
                o = layer[al].Graphics.GetSelectedObject(i);
                this.CopToPas.Add(o);
            }
        }
        public void Past(LayersList layer)
        {
            layer.CreateNewLayer("");
            int al = layer.ActiveLayerIndex;
            layer[al].IsActive = true;
            layer[al].Graphics.SelectAll();
            Command cmd = new CommandPaste(this.TheLayers, this.CopToPas);
            undoManager.AddCommandToHistory(cmd);

        }
        //Hàm cho phép quay lại
        public void Undo()
        {
            undoManager.Undo();
            Refresh();
        }
        //Hàm cho phép quay tới
        public void Redo()
        {
            undoManager.Redo();
            Refresh();
        }

        private void DrawArea_Load(object sender, EventArgs e)
        {

        }
    }
}
