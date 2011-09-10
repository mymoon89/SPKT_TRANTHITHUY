using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PaintCSharp2010.DocManagers
{
    
    public class DragDropManager
    {
        private Form frmOwner;          // Lien ket toi form quan li

        // Su kien duoc goi khi co mot file duoc drop tu form.
        public event FileDroppedEventHandler FileDroppedEvent;

        public DragDropManager(Form owner)
        {
            frmOwner = owner;

            // Kiem tra de dam bao form cha cho phep mo
          
            frmOwner.AllowDrop = true;

            // Ho tro cac su kien drag-drop tu form cha
          
            frmOwner.DragEnter += OnDragEnter;
            frmOwner.DragDrop += OnDragDrop;
        }



        private void OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
           
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

     
        private void OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
     
            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

            if (a != null)
            {
                if (FileDroppedEvent != null)
                {
                   

                    FileDroppedEvent.BeginInvoke(this, new FileDroppedEventArgs(a), null, null);

                    frmOwner.Activate();     
                }
            }

            
        }
    }

    public delegate void FileDroppedEventHandler(object sender, FileDroppedEventArgs e);

    public class FileDroppedEventArgs : System.EventArgs
    {
        private Array fileArray;

        public FileDroppedEventArgs(Array array)
        {
            this.fileArray = array;
        }

        public Array FileArray
        {
            get
            {
                return fileArray;
            }
        }
    }
}
