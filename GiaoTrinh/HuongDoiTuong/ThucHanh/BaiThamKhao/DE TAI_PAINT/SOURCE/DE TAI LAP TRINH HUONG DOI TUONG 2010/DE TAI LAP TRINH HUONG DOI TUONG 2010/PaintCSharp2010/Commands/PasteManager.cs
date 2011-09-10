using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{
    internal class PasteManager
    {
        #region Member
        private LayersList PasteLayer;
        private List<Command> PasteHistory;
        private bool AblePaste = false;

        #endregion
        #region Constructor
        public PasteManager(LayersList layer)
        {
            PasteLayer = layer;
            ClearHistory();
        }
        #endregion Const
        #region Public Funtion
        public void ClearHistory()
        {
            PasteHistory = new List<Command>();
            AblePaste = false;
        }
        public bool CanPaste()
        {
            return AblePaste;
        }
        public void AddCommandToPasteHistory(Command cmd)
        {
            TrimPasteHistory();
            PasteHistory.Add(cmd);
            AblePaste = true;
        }
        public void Paste()
        {
            if (!AblePaste) return;
            Command cmd = PasteHistory[0];
            cmd.Undo(PasteLayer);
        }
        #endregion
        #region Private Funtion
        private void TrimPasteHistory()
        {
            if (PasteHistory.Count == 0)
            { return; }
            else
            {
                for (int i = PasteHistory.Count - 1; i >= 0; i--)
                {
                    PasteHistory.RemoveAt(i);
                }
            }
        }
        #endregion
    }
}
