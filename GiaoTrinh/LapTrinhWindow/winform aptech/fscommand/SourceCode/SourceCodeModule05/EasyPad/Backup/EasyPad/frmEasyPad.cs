/*
 * frmEasyPad.cs
 * 
 * Copyright © 2007 Aptech Software Limited. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyPad
{
    /// <summary>
    /// Class frmEasyPad is used to demonstrate the use of dialog boxes.
    /// </summary>
    public partial class frmEasyPad : Form
    {
        string unModifiedText = "";
        DialogResult dlgresResult;
        string fileName = "";
        bool textChanged = false;

        /// <summary>
        /// Constructor without parameters to initialize the
        /// controls for displaying the frmEasyPad form. 
        /// </summary>
        public frmEasyPad()
        {
            InitializeComponent();
        }

        // Load the frmEasyPad form
        private void frmEasyPad_Load(object sender, EventArgs e)
        {
            rtbEasyPad.Clear();
            DisableControls();
            unModifiedText = "";
            fileName = "";
            textChanged = false;
        }

        // Enables the controls
        void EnableControls()
        {
            btnSave.Enabled = true;
            btnSaveAs.Enabled = true;
            btnFont.Enabled = true;
            btnColor.Enabled = true;
            btnPrint.Enabled = true;
            btnCancel.Enabled = true;
        }

        // Disables the controls
        void DisableControls()
        {
            btnSave.Enabled = false;
            btnSaveAs.Enabled = false;
            btnFont.Enabled = false;
            btnColor.Enabled = false;
            btnPrint.Enabled = false;
            btnCancel.Enabled = false;
            rtbEasyPad.Enabled = false;
        }

        // Opens the new file
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                dlgresResult = MessageBox.Show("Do you want to save the file?", "EasyPad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlgresResult == DialogResult.Yes)
                    btnSave_Click(null, null);
                else if (dlgresResult == DialogResult.Cancel)
                {
                    rtbEasyPad.Focus();
                }
                else
                {
                    fileName = "";
                    rtbEasyPad.Enabled = true;
                    rtbEasyPad.Clear();
                    EnableControls();
                    rtbEasyPad.Focus();
                    textChanged = false;
                }
            }
            else
            {
                fileName = "";
                rtbEasyPad.Enabled = true;
                rtbEasyPad.Clear();
                EnableControls();
                rtbEasyPad.Focus();
                textChanged = false;
            }
        }

        // Opens the OpenFileDialog box
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                dlgresResult = MessageBox.Show("Do you want to save the file?", "EasyPad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlgresResult == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                    textChanged = false;
                }
                else if (dlgresResult == DialogResult.Cancel)
                    rtbEasyPad.Focus();
            }

            odlgOpenFile.ShowDialog();
        }

        // Opens the file
        private void odlgOpenFile_FileOk(object sender, CancelEventArgs e)
        {
            fileName = odlgOpenFile.FileName;
            rtbEasyPad.LoadFile(fileName);
            unModifiedText = rtbEasyPad.Text;
            rtbEasyPad.Enabled = true;
            rtbEasyPad.Focus();
            EnableControls();
            rtbEasyPad.Focus();
            textChanged = false;
        }

        // Opens the SaveFileDialog box
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fileName == "")
                sdlgSaveFile.ShowDialog();
            else
            {
                rtbEasyPad.SaveFile(fileName);
                unModifiedText = rtbEasyPad.Text;
                rtbEasyPad.Focus();
                textChanged = false;
            }
        }

        // Saves the file
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            sdlgSaveFile.ShowDialog();
        }

        // Saves the file
        private void sdlgSaveFile_FileOk(object sender, CancelEventArgs e)
        {
            fileName = sdlgSaveFile.FileName;
            rtbEasyPad.SaveFile(fileName);
            unModifiedText = rtbEasyPad.Text;
            textChanged = false;
            rtbEasyPad.Focus();
        }

        // Opens the FontDialog box
        private void btnFont_Click(object sender, EventArgs e)
        {
            dlgresResult = fdlgFont.ShowDialog();
            if (dlgresResult == DialogResult.OK)
            {
                if (rtbEasyPad.SelectedText.Length > 0)
                    rtbEasyPad.SelectionFont = fdlgFont.Font;
                else
                {
                    rtbEasyPad.SelectAll();
                    rtbEasyPad.Font = fdlgFont.Font;
                }
                rtbEasyPad.Select(rtbEasyPad.TextLength, rtbEasyPad.TextLength);
                rtbEasyPad.Focus();
            }
        }

        // Opens the ColorDialog box
        private void btnColor_Click(object sender, EventArgs e)
        {
            dlgresResult = cdlgColor.ShowDialog();
            if (dlgresResult == DialogResult.OK)
            {
                if (rtbEasyPad.SelectedText.Length > 0)
                    rtbEasyPad.SelectionColor = cdlgColor.Color;
                else
                {
                    rtbEasyPad.SelectAll();
                    rtbEasyPad.ForeColor = cdlgColor.Color;
                }
                rtbEasyPad.Select(rtbEasyPad.TextLength, rtbEasyPad.TextLength);
                rtbEasyPad.Focus();
            }
        }

        // Opens the PrintDialog box
        private void btnPrint_Click(object sender, EventArgs e)
        {
            dlgresResult = pdlgPrint.ShowDialog();
            if (dlgresResult == DialogResult.OK)
                MessageBox.Show("The file has been printed successfully.", "EasyPad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (dlgresResult == DialogResult.Cancel)
                MessageBox.Show("Printing of the file has been cancelled.", "EasyPad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cancels the operation
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                dlgresResult = MessageBox.Show("Do you want to save the file?", "EasyPad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlgresResult == DialogResult.Yes)
                    btnSave_Click(null, null);
                else if (dlgresResult == DialogResult.No)
                    frmEasyPad_Load(null, null);
                else if (dlgresResult == DialogResult.Cancel)
                {
                    rtbEasyPad.Focus();
                }
            }
        }

        // Closes the application 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Sets the flag to true
        private void rtbEasyPad_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }
    }
}