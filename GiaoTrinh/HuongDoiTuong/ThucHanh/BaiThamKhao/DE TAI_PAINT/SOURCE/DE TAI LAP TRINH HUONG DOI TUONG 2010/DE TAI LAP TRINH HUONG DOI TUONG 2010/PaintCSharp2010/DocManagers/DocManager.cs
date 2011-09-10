using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Globalization;

namespace PaintCSharp2010.DocManagers
{
    #region Class DocManager
    public class DocManager
    {

        #region Events

        public event SaveEventHandler SaveEvent;
        public event LoadEventHandler LoadEvent;
        public event OpenFileEventHandler OpenEvent;
        public event EventHandler ClearEvent;
        public event EventHandler DocChangedEvent;

        #endregion

        #region Members

        private string fileName = "";
        private bool dirty = false;
        private bool Issaved = false;

        private Form frmOwner;
        private string newDocName;
        private string fileDlgFilter;
        private string registryPath;
        private bool updateTitle;

        private const string registryValue = "Path";
        private string fileDlgInitDir = "";         

        #endregion

        #region Enum

   
        public enum SaveType
        {
            Save,
            SaveAs
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="data"></param>
        public DocManager(DocManagerData data)
        {
            frmOwner = data.FormOwner;
            frmOwner.Closing += OnClosing;

            updateTitle = data.UpdateTitle;

            newDocName = data.NewDocName;

            fileDlgFilter = data.FileDialogFilter;

            registryPath = data.RegistryPath;

            if (!registryPath.EndsWith("\\"))
                registryPath += "\\";

            registryPath += "FileDir";

   
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);

            if (key != null)
            {
                string s = (string)key.GetValue(registryValue);

                if (!Empty(s))
                    fileDlgInitDir = s;
            }
        }

        #endregion

        #region Public functions and Properties

     
        public bool Dirty
        {
            get
            {
                return dirty;
            }
            set
            {
                dirty = value;
                SetCaption();
            }
        }
        public bool IsSaved
        {
            get { return this.Issaved; }
            set { this.Issaved = value; }
        }


        public bool NewDocument()
        {
            if (!CloseDocument())
                return false;

            SetFileName("");

            if (ClearEvent != null)
            {
              
                ClearEvent(this, new EventArgs());
            }

            Dirty = false;
            IsSaved = false;

            return true;
        }

       
        public bool CloseDocument()
        {
            if (!this.dirty)
                return true;

            DialogResult res = MessageBox.Show(
                frmOwner,
                "Save changes?",
                Application.ProductName,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation);

            switch (res)
            {
                case DialogResult.Yes: return SaveDocument(SaveType.Save);
                case DialogResult.No: return true;
                case DialogResult.Cancel: return false;
                default: Debug.Assert(false); return false;
            }
        }

       
        public bool OpenDocument(string newFileName)
        {
           
            if (!CloseDocument())
                return false;

           
            if (Empty(newFileName))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Windows Bitmap (*.bmp)|*.bmp|" + "Image File (*.png)|*.bng|" + fileDlgFilter;
                openFileDialog1.InitialDirectory = fileDlgInitDir;

                DialogResult res = openFileDialog1.ShowDialog(frmOwner);

                if (res != DialogResult.OK)
                    return false;

                newFileName = openFileDialog1.FileName;
                fileDlgInitDir = new FileInfo(newFileName).DirectoryName;
            }

            try
            {
                using (Stream stream = new FileStream(
                           newFileName, FileMode.Open, FileAccess.Read))
                {
                  
                    IFormatter formatter = new BinaryFormatter();

                    if (LoadEvent != null)        
                    {
                        SerializationEventArgs args = new SerializationEventArgs(
                            formatter, stream, newFileName);

                   
                        LoadEvent(this, args);

                        if (args.Error)
                        {
                           
                            if (OpenEvent != null)
                            {
                                OpenEvent(this,
                                    new OpenFileEventArgs(newFileName, false));
                            }

                            return false;
                        }

                        if (DocChangedEvent != null)
                        {
                            DocChangedEvent(this, new EventArgs());
                        }
                    }
                }
            }
        
            catch (ArgumentNullException ex) { return HandleOpenException(ex, newFileName); }
            catch (ArgumentOutOfRangeException ex) { return HandleOpenException(ex, newFileName); }
            catch (ArgumentException ex) { return HandleOpenException(ex, newFileName); }
            catch (SecurityException ex) { return HandleOpenException(ex, newFileName); }
            catch (FileNotFoundException ex) { return HandleOpenException(ex, newFileName); }
            catch (DirectoryNotFoundException ex) { return HandleOpenException(ex, newFileName); }
            catch (PathTooLongException ex) { return HandleOpenException(ex, newFileName); }
            catch (IOException ex) { return HandleOpenException(ex, newFileName); }

  
            Dirty = false;
            SetFileName(newFileName);

            if (OpenEvent != null)
            {
             
                OpenEvent(this, new OpenFileEventArgs(newFileName, true));
            }

            return true;
        }


        public bool SaveDocument(SaveType type)
        {
         
            string newFileName = this.fileName;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Windows Bitmap (*.bmp)|*.bmp|" + "Image File (*.png)|*.bng|" + fileDlgFilter;
           


            if ((type == SaveType.SaveAs) ||
                Empty(newFileName))
            {

                if (!Empty(newFileName))
                {
                    saveFileDialog1.InitialDirectory = Path.GetDirectoryName(newFileName);
                    saveFileDialog1.FileName = Path.GetFileName(newFileName);
                }
                else
                {
                    saveFileDialog1.InitialDirectory = fileDlgInitDir;
                    saveFileDialog1.FileName = newDocName;
                }

                DialogResult res = saveFileDialog1.ShowDialog(frmOwner);

                if (res != DialogResult.OK)
                    return false;
                IsSaved = true;
                newFileName = saveFileDialog1.FileName;
                fileDlgInitDir = new FileInfo(newFileName).DirectoryName;
            }

         
            try
            {
                using (Stream stream = new FileStream(
                           newFileName, FileMode.Create, FileAccess.Write))
                {

                    IFormatter formatter = new BinaryFormatter();

                    if (SaveEvent != null)    
                    {
                        SerializationEventArgs args = new SerializationEventArgs(
                            formatter, stream, newFileName);

                        
                        SaveEvent(this, args);

                        if (args.Error)
                            return false;
                    }

                }
            }
            catch (ArgumentNullException ex) { return HandleSaveException(ex, newFileName); }
            catch (ArgumentOutOfRangeException ex) { return HandleSaveException(ex, newFileName); }
            catch (ArgumentException ex) { return HandleSaveException(ex, newFileName); }
            catch (SecurityException ex) { return HandleSaveException(ex, newFileName); }
            catch (FileNotFoundException ex) { return HandleSaveException(ex, newFileName); }
            catch (DirectoryNotFoundException ex) { return HandleSaveException(ex, newFileName); }
            catch (PathTooLongException ex) { return HandleSaveException(ex, newFileName); }
            catch (IOException ex) { return HandleSaveException(ex, newFileName); }

        
            Dirty = false;

            SetFileName(newFileName);

       
            return true;
        }

      
        public bool RegisterFileType(
            string fileExtension,
            string progId,
            string typeDisplayName)
        {
            try
            {
                string s = String.Format(CultureInfo.InvariantCulture, ".{0}", fileExtension);

            
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(s))
                {
                  
                    key.SetValue(null, progId);
                }

            
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(progId))
                {
                    key.SetValue(null, typeDisplayName);
                }

         
                using (RegistryKey key =
                           Registry.ClassesRoot.CreateSubKey(progId + @"\DefaultIcon"))
                {
                    key.SetValue(null, Application.ExecutablePath + ",0");
                }

                string cmdkey = progId + @"\shell\open\command";
                using (RegistryKey key =
                           Registry.ClassesRoot.CreateSubKey(cmdkey))
                {
                    
                    key.SetValue(null, Application.ExecutablePath + " \"%1\"");
                }

              
                string appkey = "Applications\\" +
                    new FileInfo(Application.ExecutablePath).Name +
                    "\\shell";
                using (RegistryKey key =
                           Registry.ClassesRoot.CreateSubKey(appkey))
                {
                    key.SetValue("FriendlyCache", Application.ProductName);
                }
            }
            catch (ArgumentNullException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (SecurityException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (ArgumentException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (ObjectDisposedException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                return HandleRegistryException(ex);
            }

            return true;
        }

        #endregion

        #region Other Functions


  
        private bool HandleRegistryException(Exception ex)
        {
            Trace.WriteLine("Registry operation failed: " + ex.Message);
            return false;
        }

  
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
            key.SetValue(registryValue, fileDlgInitDir);
        }


        private void SetFileName(string fileName)
        {
            this.fileName = fileName;
            SetCaption();
        }

        private void SetCaption()
        {
            if (!updateTitle)
                return;

            frmOwner.Text = string.Format(
                CultureInfo.InvariantCulture,
                "{0} - {1}{2}",
                Application.ProductName,
                Empty(this.fileName) ? newDocName : Path.GetFileName(this.fileName),
                this.dirty ? "*" : "");
        }

 
        private bool HandleOpenException(Exception ex, string fileName)
        {
            MessageBox.Show(frmOwner,
                "Open File operation failed. File name: " + fileName + "\n" +
                "Reason: " + ex.Message,
                Application.ProductName);

            if (OpenEvent != null)
            {
             
                OpenEvent(this, new OpenFileEventArgs(fileName, false));
            }

            return false;
        }

        
        private bool HandleSaveException(Exception ex, string fileName)
        {
            MessageBox.Show(frmOwner,
                "Save File operation failed. File name: " + fileName + "\n" +
                "Reason: " + ex.Message,
                Application.ProductName);

            return false;
        }


        static bool Empty(string s)
        {
            return s == null || s.Length == 0;
        }

        #endregion

    }

    #endregion

    #region Delegates

    public delegate void SaveEventHandler(object sender, SerializationEventArgs e);
    public delegate void LoadEventHandler(object sender, SerializationEventArgs e);
    public delegate void OpenFileEventHandler(object sender, OpenFileEventArgs e);

    #endregion

    #region Class SerializationEventArgs

   
    public class SerializationEventArgs : System.EventArgs
    {
        private IFormatter formatter;
        private Stream stream;
        private string fileName;
        private bool errorFlag;

        public SerializationEventArgs(IFormatter formatter, Stream stream,
            string fileName)
        {
            this.formatter = formatter;
            this.stream = stream;
            this.fileName = fileName;
            errorFlag = false;
        }

        public bool Error
        {
            get
            {
                return errorFlag;
            }
            set
            {
                errorFlag = value;
            }
        }

        public IFormatter Formatter
        {
            get
            {
                return formatter;
            }
        }

        public Stream SerializationStream
        {
            get
            {
                return stream;
            }
        }
        public string FileName
        {
            get
            {
                return fileName;
            }
        }
    }

    #endregion

    #region Class OpenFileEventArgs

  
    public class OpenFileEventArgs : System.EventArgs
    {
        private string fileName;
        private bool success;

        public OpenFileEventArgs(string fileName, bool success)
        {
            this.fileName = fileName;
            this.success = success;
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public bool Succeeded
        {
            get
            {
                return success;
            }
        }
    }

    #endregion

    #region class DocManagerData

   
    public class DocManagerData
    {
        public DocManagerData()
        {
            frmOwner = null;
            updateTitle = true;
            newDocName = "Untitled";
            fileDlgFilter = "All File (*.*)|*.*";
            registryPath = "Software\\Unknown";
        }

        private Form frmOwner;
        private bool updateTitle;
        private string newDocName;
        private string fileDlgFilter;
        private string registryPath;

        public Form FormOwner
        {
            get
            {
                return frmOwner;
            }
            set
            {
                frmOwner = value;
            }
        }

        public bool UpdateTitle
        {
            get
            {
                return updateTitle;
            }
            set
            {
                updateTitle = value;
            }
        }

        public string NewDocName
        {
            get
            {
                return newDocName;
            }
            set
            {
                newDocName = value;
            }
        }

        public string FileDialogFilter
        {
            get
            {
                return fileDlgFilter;
            }
            set
            {
                fileDlgFilter = value;
            }
        }

        public string RegistryPath
        {
            get
            {
                return registryPath;
            }
            set
            {
                registryPath = value;
            }
        }
    };

    #endregion
}
