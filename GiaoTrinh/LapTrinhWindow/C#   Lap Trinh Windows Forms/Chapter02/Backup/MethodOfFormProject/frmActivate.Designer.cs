namespace MethodOfFormProject
{
    partial class frmActivate
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.childFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childForm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childForm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // childFormToolStripMenuItem
            // 
            this.childFormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childForm1ToolStripMenuItem,
            this.childForm2ToolStripMenuItem});
            this.childFormToolStripMenuItem.Name = "childFormToolStripMenuItem";
            this.childFormToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.childFormToolStripMenuItem.Text = "Child Form";
            // 
            // childForm1ToolStripMenuItem
            // 
            this.childForm1ToolStripMenuItem.Name = "childForm1ToolStripMenuItem";
            this.childForm1ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.childForm1ToolStripMenuItem.Text = "Child Form1";
            this.childForm1ToolStripMenuItem.Click += new System.EventHandler(this.childForm1ToolStripMenuItem_Click);
            // 
            // childForm2ToolStripMenuItem
            // 
            this.childForm2ToolStripMenuItem.Name = "childForm2ToolStripMenuItem";
            this.childForm2ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.childForm2ToolStripMenuItem.Text = "Child Form2";
            this.childForm2ToolStripMenuItem.Click += new System.EventHandler(this.childForm2ToolStripMenuItem_Click);
            // 
            // frmActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 182);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmActivate";
            this.Text = "frmActivate";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem childFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childForm1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childForm2ToolStripMenuItem;
    }
}