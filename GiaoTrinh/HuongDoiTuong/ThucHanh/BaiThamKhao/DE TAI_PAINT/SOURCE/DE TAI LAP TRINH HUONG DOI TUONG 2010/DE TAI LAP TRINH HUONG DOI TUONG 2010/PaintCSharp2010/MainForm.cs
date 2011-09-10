using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaintCSharp2010.DocManagers;
using PaintCSharp2010.Commands;
using Microsoft.Win32;
using PaintCSharp2010.DrawObjects;
using System.Security;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.Serialization;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010
{
    public partial class MainForm : Form
    {
        #region Default
        private int childFormNumber = 0;
        public MainForm()
        {
            InitializeComponent();
            MouseWheel += new MouseEventHandler(MainForm_MouseWheel);
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion
        #region Members
        private DrawArea drawArea;
        private DocManager docManager;
        private DragDropManager dragDropManager;
        private MruManager mruManager;
        private string argumentFile = ""; 
        private bool fill;
        private const string registryPath = "C:";
        private bool _controlKey = false;
        private Color colorFront;
        private Color colorBack;
        #endregion
        #region Properties
        public string ArgumentFile
        {
            get { return argumentFile; }
            set { argumentFile = value; }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Tạo một vùng vẽ chính DrawArea.
            drawArea = new DrawArea();
            drawArea.Location = new Point(84, 50);
            drawArea.Size = new Size(800, 610);
            drawArea.Owner = this;
            Controls.Add(drawArea);
            // Các đối tượng hổ trợ. 
            InitializeHelperObjects();
            drawArea.Initialize(this, docManager);
            ResizeDrawArea();
            tsbPointer.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            // Set lại trạng thái điều khiển.
      
            Application.Idle += delegate { SetStateOfControls(); };
            // Mở File từ command line.          
            if (ArgumentFile.Length > 0)
                OpenDocument(ArgumentFile);

         

            Line_big.Visible = false;
            Line_midle.Visible = false;
            Line_normal.Visible = false;
            colorBack = Color.Tomato;
            colorFront = Color.Black;

        }
        private void InitializeHelperObjects()
        {
           
            DocManagerData data = new DocManagerData();
            data.FormOwner = this;
            data.UpdateTitle = true;
            data.FileDialogFilter = "ObjPaint File (*.,bmp)|*.bmp|All Files (*.*)|*.*";
            data.NewDocName = "PaintCSharp2010.bmp";
            data.RegistryPath = registryPath;
            docManager = new DocManager(data);
            docManager.RegisterFileType("dtl", "bmpfile", "ObjPaint File");
             // Subscribe to DocManager events.
            docManager.SaveEvent += docManager_SaveEvent;
            docManager.LoadEvent += docManager_LoadEvent;
            docManager.OpenEvent += delegate(object sender, OpenFileEventArgs e)
                                        {
                                            if (e.Succeeded)
                                                mruManager.Add(e.FileName);
                                            else
                                                mruManager.Remove(e.FileName);
                                        };

            docManager.DocChangedEvent += delegate
                                            {
                                                drawArea.Refresh();
                                                drawArea.ClearHistory();
                                            };

           docManager.ClearEvent += delegate
                                        {
                                            bool haveObjects = false;
                                            for (int i = 0; i < drawArea.TheLayers.Count; i++)
                                            {
                                                if (drawArea.TheLayers[i].Graphics.Count > 1)
                                                {
                                                    haveObjects = true;
                                                    break;
                                                }
                                            }
                                            if (haveObjects)
                                            {
                                                drawArea.TheLayers.Clear();
                                                drawArea.ClearHistory();
                                                drawArea.Refresh();
                                            }
                                        };          

            docManager.NewDocument();

       
            dragDropManager = new DragDropManager(this);
            dragDropManager.FileDroppedEvent += delegate(object sender, FileDroppedEventArgs e) { OpenDocument(e.FileArray.GetValue(0).ToString()); };
 
            mruManager = new MruManager();    
            mruManager.MruOpenEvent += delegate(object sender, MruFileOpenEventArgs e) 
            { OpenDocument(e.FileName); };
      
        }
        private void OpenDocument(string file)
        {
            docManager.OpenDocument(file);
        }
        private void docManager_SaveEvent(object sender, SerializationEventArgs e)
        {
            try
            {
                e.Formatter.Serialize(e.SerializationStream, drawArea.TheLayers);
            }
            catch (ArgumentNullException ex)
            {
                HandleSaveException(ex, e);
            }
            catch (SerializationException ex)
            {
                HandleSaveException(ex, e);
            }
            catch (SecurityException ex)
            {
                HandleSaveException(ex, e);
            }
        }
        private void HandleSaveException(Exception ex, SerializationEventArgs e)
        {
            MessageBox.Show(this,
                            "Save File operation failed. File name: " + e.FileName + "\n" +
                            "Reason: " + ex.Message,
                            Application.ProductName);

            e.Error = true;
        }
        private void docManager_LoadEvent(object sender, SerializationEventArgs e)
        {
         
            try
            {
                drawArea.TheLayers = (LayersList)e.Formatter.Deserialize(e.SerializationStream);
            }
            catch (ArgumentNullException ex)
            {
                HandleLoadException(ex, e);
            }
            catch (SerializationException ex)
            {
                HandleLoadException(ex, e);
            }
            catch (SecurityException ex)
            {
                HandleLoadException(ex, e);
            }
        }
        private void HandleLoadException(Exception ex, SerializationEventArgs e)
        {
            MessageBox.Show(this,
                            "Open File operation failed. File name: " + e.FileName + "\n" +
                            "Reason: " + ex.Message,
                            Application.ProductName);

            e.Error = true;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized &&
            drawArea != null)
            {
                ResizeDrawArea();
            }
        }
        private void ResizeDrawArea()
        {
            //Rectangle rect = ClientRectangle;
            //drawArea.Left = rect.Left + grdraw.Width;
            //drawArea.Top = rect.Top + toolStrip1.Height;
            //drawArea.Height = rect.Height - toolStrip1.Height - Groupcolor.Height - 20;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (drawArea.TheLayers[0].Graphics.Count != 0)
            {
                // if (this.docManager.IsSaved)  return;
                DialogResult dl = MessageBox.Show("Do you want to save change ? ", "Save PaintPro",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                    CommandSave();
                else if (dl == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void CommandSave()
        {
            docManager.SaveDocument(DocManager.SaveType.Save);
        }

        internal void SetStateOfControls()
        {
            // Select active tool
            int x = drawArea.TheLayers.ActiveLayerIndex;
            bool objects = (drawArea.TheLayers[x].Graphics.Count > 0);
            bool selectedObjects = (drawArea.TheLayers[x].Graphics.SelectionCount > 0);
            // File operations	         

            // Pan button

            ////tollbar button

            tsbPointer.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            tsbCurve.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Curve);
            tsbLine.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Line);
            tsbRectangle.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            tsbEllipse.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);
            tsbLine.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Polygon);
            tsbFill.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Fill);
            tsbText.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Text);
            tsbImage.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Image);
            tsbRoundRectangle.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.RoudedRectangle);

            //////statusbar
            numberOJ.Text = drawArea.TheLayers[x].Graphics.Count.ToString();
            lbzoom.Text = (Math.Round(drawArea.Zoom * 100)) + " %";
            lbPan.Text = drawArea.PanX + ", " + drawArea.PanY;
            ///undo,redo
            editundo.Enabled = drawArea.CanUndo;
            editredo.Enabled = drawArea.CanRedo;
        }

       
       
        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (_controlKey)
                {
                    
                    if (e.Delta > 0)
                        drawArea.PanY += 10;
                    else
                        drawArea.PanY -= 10;
                    Invalidate();
                }
                else
                {
                  
                    if (e.Delta > 0)
                        AdjustZoom(.1f);
                    else
                        AdjustZoom(-.1f);
                }
                SetStateOfControls();
                return;
            }
        }

        private void AdjustZoom(float _amount)
        {
            drawArea.Zoom += _amount;
            if (drawArea.Zoom < .1f)
                drawArea.Zoom = .1f;
            if (drawArea.Zoom > 10)
                drawArea.Zoom = 10f;
            drawArea.Invalidate();
            SetStateOfControls();
        }

       



        #region Các hàm xử lý GroupTools
        private void tsbPointer_Click(object sender, EventArgs e)
        {
            CommandPointer();
        }
        private void CommandPointer()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer;
            fill = false;
            SetStateOfControls();
            Line_big.Visible = false;
            Line_midle.Visible = false;
            Line_normal.Visible = false;
            nofill.Visible = false;
            FillCl.Visible = false;
            fillwhite.Visible = false;
            nofill.Visible = false; 
        }
        private void tsbCurve_Click(object sender, EventArgs e)
        {
            CommandCurve();
        }
        private void CommandCurve()
        {
            Line_normal.BorderStyle = BorderStyle.Fixed3D;
            drawArea.ActiveTool = DrawArea.DrawToolType.Curve;
            SetStateOfControls();
            fill = false;
            Line_big.Visible = true;
            Line_midle.Visible = true;
            Line_normal.Visible = true;
        }



        #endregion

        private void tsbLine_Click(object sender, EventArgs e)
        {
            CommandLine();
        }

        private void CommandLine()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Line;
            fill = false;
            SetStateOfControls();
            Line_normal.Visible = true;
            Line_midle.Visible = true;
            Line_big.Visible = true;
        }

        private void tsbRectangle_Click(object sender, EventArgs e)
        {
            CommandRectangle();
        }
        private void CommandRectangle()
        {
            nofill.BorderStyle = BorderStyle.Fixed3D;
            fillwhite.BorderStyle = BorderStyle.None;
            FillCl.BorderStyle = BorderStyle.None;
            drawArea.Rectangle.changefill(this, Color.Transparent);
            drawArea.ActiveTool = DrawArea.DrawToolType.Rectangle;
            fill = false;
            SetStateOfControls();
            Line_big.Visible = true;         
            Line_midle.Visible = true;
            Line_normal.Visible = true;
            nofill.Visible = true;
            fillwhite.Visible = true;
            FillCl.Visible = true;
        }

        private void tsbEllipse_Click(object sender, EventArgs e)
        {
            CommandEllipse();
        }

        private void CommandEllipse()
        {
            nofill.BorderStyle = BorderStyle.Fixed3D;
            fillwhite.BorderStyle = BorderStyle.None;
            FillCl.BorderStyle = BorderStyle.None;
            drawArea.Rectangle.changefill(this, Color.Transparent);
            drawArea.ActiveTool = DrawArea.DrawToolType.Ellipse;
            fill = false;
            SetStateOfControls();
            Line_big.Visible = true;
            Line_midle.Visible = true;
            Line_normal.Visible = true;
            nofill.Visible = true;
            fillwhite.Visible = true;
            FillCl.Visible = true;
        }

        private void tsbPolygon_Click(object sender, EventArgs e)
        {
            CommandPolygon();
        }

        private void CommandPolygon()
        {
            Line_normal.BorderStyle = BorderStyle.Fixed3D;
            drawArea.ActiveTool = DrawArea.DrawToolType.Polygon;
            fill = false;
            Line_midle.Visible = true;
            Line_big.Visible = true;
            Line_normal.Visible = true;
            SetStateOfControls();
        }

        private void tsbFill_Click(object sender, EventArgs e)
        {
            CommandFill();
        }

        private void CommandFill()
        {
            fill = true;
            drawArea.ActiveTool = DrawArea.DrawToolType.Fill;
            drawArea.Refresh();
            SetStateOfControls();
        }

        private void tsbText_Click(object sender, EventArgs e)
        {
            CommandText();
        }

        private void CommandText()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Text;
            fill = false;
            SetStateOfControls();
        }

        private void tsbImage_Click(object sender, EventArgs e)
        {
            CommandImage();
        }

        private void CommandImage()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Image;
            fill = false;
            SetStateOfControls();
        }

        private void tsbRoundRectangle_Click(object sender, EventArgs e)
        {
            CommandRoundRectangle();
        }

        private void CommandRoundRectangle()
        {
            nofill.BorderStyle = BorderStyle.Fixed3D;
            fillwhite.BorderStyle = BorderStyle.None;
            FillCl.BorderStyle = BorderStyle.None;
            drawArea.Rectangle.changefill(this, Color.Transparent);
            drawArea.ActiveTool = DrawArea.DrawToolType.RoudedRectangle;
       
            fill = false;
            SetStateOfControls();
            Line_midle.Visible = true;
            Line_big.Visible = true;
            Line_normal.Visible = true;
            nofill.Visible = true;
            fillwhite.Visible = true;
            FillCl.Visible = true;
        }

        private void Line_normal_MouseDown(object sender, MouseEventArgs e)
        {
            Line_midle.BorderStyle = BorderStyle.None;
            Line_normal.BorderStyle = BorderStyle.Fixed3D;
            drawArea.Rectangle.changesizepen(this,1);
        }

        private void Line_midle_MouseDown(object sender, MouseEventArgs e)
        {
            Line_midle.BorderStyle = BorderStyle.Fixed3D;
            Line_normal.BorderStyle = BorderStyle.None;          
            Line_big.BorderStyle = BorderStyle.None;
            drawArea.Rectangle.changesizepen(this, 2);

        }

        private void Line_big_Click(object sender, EventArgs e)
        {
            Line_big.BorderStyle = BorderStyle.Fixed3D;
            Line_midle.BorderStyle = BorderStyle.None;
            Line_normal.BorderStyle = BorderStyle.None;
            drawArea.Rectangle.changesizepen(this, 3);

        }

        private void line2_Click(object sender, EventArgs e)
        {
            Line_midle.BorderStyle = BorderStyle.None;
            Line_normal.BorderStyle = BorderStyle.None;
            Line_big.BorderStyle = BorderStyle.None;
            drawArea.Rectangle.changesizepen(this, 4);
        }

        private void editundo_Click(object sender, EventArgs e)
        {
            CommandUndo();
        }

        private void CommandUndo()
        {
            drawArea.Undo();
        }

        private void editredo_Click(object sender, EventArgs e)
        {
            CommandRedo();
        }

        private void CommandRedo()
        {
            drawArea.Redo();
        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            AdjustZoom(.1f);
        }

        private void ZoomResset_Click(object sender, EventArgs e)
        {
            drawArea.Zoom = 1.0f;
            drawArea.Invalidate();
        }

        private void Zoomout_Click(object sender, EventArgs e)
        {
            AdjustZoom(-.1f);
        }

        private void RotateL_Click(object sender, EventArgs e)
        {
            int al = drawArea.TheLayers.ActiveLayerIndex;
            if (drawArea.TheLayers[al].Graphics.SelectionCount > 0)
                RotateObject(-10);
            else
                RotateDrawing(-10);

        }

        private void RotateR_Click(object sender, EventArgs e)
        {
            int al = drawArea.TheLayers.ActiveLayerIndex;
            if (drawArea.TheLayers[al].Graphics.SelectionCount > 0)
                RotateObject(10);
            else
                RotateDrawing(10);
        }

        private void RotateObject(int p)
        {
            int al = drawArea.TheLayers.ActiveLayerIndex;
            for (int i = 0; i < drawArea.TheLayers[al].Graphics.Count; i++)
            {
                if (drawArea.TheLayers[al].Graphics[i].Selected)
                    if (p == 0)
                        drawArea.TheLayers[al].Graphics[i].Rotation = 0;
                    else
                        drawArea.TheLayers[al].Graphics[i].Rotation += p;
            }
            drawArea.Invalidate();
            SetStateOfControls();
        }

        private void RotateDrawing(int p)
        {
            if (p == 0)
                drawArea.Rotation = 0;
            else
            {
                drawArea.Rotation += p;
                if (p < 0)
                {
                    if (drawArea.Rotation <
                        -360)
                        drawArea.Rotation = 0;
                }
                else
                {
                    if (drawArea.Rotation > 360)
                        drawArea.Rotation = 0;
                }
            }
            drawArea.Invalidate();
            SetStateOfControls();
        }

        

        private void morecl_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(morecl.BackColor, e);
        }

        private void morecl_DoubleClick(object sender, EventArgs e)
        {
            dlgColor.AllowFullOpen = true;
            dlgColor.AnyColor = true;
            if (dlgColor.ShowDialog() ==
                DialogResult.OK)
            {
                morecl.BackColor = dlgColor.Color;
                FrontColor.BackColor = dlgColor.Color;
                colorFront = dlgColor.Color;
                drawArea.Rectangle.changepen(this, colorFront);
            }
        }

        private void nofill_MouseDown(object sender, MouseEventArgs e)
        {
            drawArea.Rectangle.changefill(this, Color.Transparent);
            nofill.BorderStyle = BorderStyle.Fixed3D;
            fillwhite.BorderStyle = BorderStyle.None;
            FillCl.BorderStyle = BorderStyle.None;
        }

        private void fillwhite_MouseDown(object sender, MouseEventArgs e)
        {
            drawArea.Rectangle.changefill(this, Color.White);
            drawArea.Rectangle.changesizepen(this, 2);
            nofill.BorderStyle = BorderStyle.None;
            fillwhite.BorderStyle = BorderStyle.Fixed3D;
            FillCl.BorderStyle = BorderStyle.None;
        }

        private void FillCl_MouseDown(object sender, MouseEventArgs e)
        {
            colorBack = backCl.BackColor;
            drawArea.Rectangle.changefill(this, colorBack);
            drawArea.Rectangle.changepen(this, colorBack);
            nofill.BorderStyle = BorderStyle.None;
            fillwhite.BorderStyle = BorderStyle.None;
            FillCl.BorderStyle = BorderStyle.Fixed3D;
        }





        #region Các hàm xử lý tool màu
        private void ChangeColor(Color color, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                colorFront = color;
                FrontColor.BackColor = color;
                if (fill == true && drawArea.TheLayers[0].Graphics.SelectionCount > 0)
                {
                    drawArea.TheLayers[0].Graphics.FillColor(this, colorFront);
                    drawArea.Refresh();
                }

            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    colorBack = color;
                    backCl.BackColor = color;

                }
        }
        private void black_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Black, e);
        }

        private void white_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.White, e);
        }

        private void blue_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Blue, e);
        }

        private void gray_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Gray, e);
        }

        private void yellow_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Yellow, e);
        }

        private void tomato_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Tomato, e);
        }

        private void green_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Green, e);
        }

        private void navy_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Navy, e);
        }

        private void maroon_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Maroon, e);
        }

        private void idigo_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Indigo, e);
        }

        private void lime_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Lime, e);
        }

        private void aqua_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Aqua, e);
        }

        private void peru_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Peru, e);
        }

        private void greenyl_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.GreenYellow, e);
        }

        private void olive_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Olive, e);
        }

        private void purple_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Purple, e);
        }

        private void violet_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Violet, e);
        }

        private void tan_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Tan, e);
        }

        private void orange_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Orange, e);
        }

        private void info_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Indigo, e);
        }

        private void fuchsia_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Fuchsia, e);
        }

        private void trafer_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Transparent, e);
        }

        private void pink_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Pink, e);
        }

        private void crson_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Crimson, e);
        }

        private void dpink_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.DeepPink, e);
        }

        private void red_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(Color.Red, e);
        }
        #endregion

        



        
       




    }
}
