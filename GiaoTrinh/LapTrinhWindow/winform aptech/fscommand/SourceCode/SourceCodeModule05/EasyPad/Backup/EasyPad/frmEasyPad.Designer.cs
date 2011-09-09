/*
 * frmEasyPad.Designer.cs
 * 
 * Copyright © 2007 Aptech Software Limited. All rights reserved.
 */

namespace EasyPad
{
    partial class frmEasyPad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.rtbEasyPad = new System.Windows.Forms.RichTextBox();
            this.odlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.sdlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.fdlgFont = new System.Windows.Forms.FontDialog();
            this.cdlgColor = new System.Windows.Forms.ColorDialog();
            this.pdlgPrint = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(467, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(59, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(207, 9);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(59, 23);
            this.btnSaveAs.TabIndex = 13;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(537, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(67, 23);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(402, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(59, 23);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnColor
            // 
            this.btnColor.Enabled = false;
            this.btnColor.Location = new System.Drawing.Point(337, 9);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(59, 23);
            this.btnColor.TabIndex = 15;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnFont
            // 
            this.btnFont.Enabled = false;
            this.btnFont.Location = new System.Drawing.Point(272, 9);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(59, 23);
            this.btnFont.TabIndex = 14;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(142, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(77, 9);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 23);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // rtbEasyPad
            // 
            this.rtbEasyPad.Enabled = false;
            this.rtbEasyPad.HideSelection = false;
            this.rtbEasyPad.Location = new System.Drawing.Point(12, 38);
            this.rtbEasyPad.Name = "rtbEasyPad";
            this.rtbEasyPad.Size = new System.Drawing.Size(592, 210);
            this.rtbEasyPad.TabIndex = 0;
            this.rtbEasyPad.Text = "";
            this.rtbEasyPad.TextChanged += new System.EventHandler(this.rtbEasyPad_TextChanged);
            this.rtbEasyPad.Click += new System.EventHandler(this.rtbEasyPad_TextChanged);
            // 
            // odlgOpenFile
            // 
            this.odlgOpenFile.DefaultExt = "*.rtf";
            this.odlgOpenFile.Filter = "Rich Text files (*.rtf)|*.rtf| Text Files (*.txt)|*.txt";
            this.odlgOpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.odlgOpenFile_FileOk);
            // 
            // sdlgSaveFile
            // 
            this.sdlgSaveFile.Filter = "Rich Text files (*.rtf)|*.rtf| Text Files (*.txt)|*.txt";
            this.sdlgSaveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.sdlgSaveFile_FileOk);
            // 
            // cdlgColor
            // 
            this.cdlgColor.AnyColor = true;
            // 
            // pdlgPrint
            // 
            this.pdlgPrint.UseEXDialog = true;
            // 
            // frmEasyPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 260);
            this.Controls.Add(this.rtbEasyPad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Name = "frmEasyPad";
            this.Text = "EasyPad";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RichTextBox rtbEasyPad;
        private System.Windows.Forms.OpenFileDialog odlgOpenFile;
        private System.Windows.Forms.SaveFileDialog sdlgSaveFile;
        private System.Windows.Forms.FontDialog fdlgFont;
        private System.Windows.Forms.ColorDialog cdlgColor;
        private System.Windows.Forms.PrintDialog pdlgPrint;

    }
}

