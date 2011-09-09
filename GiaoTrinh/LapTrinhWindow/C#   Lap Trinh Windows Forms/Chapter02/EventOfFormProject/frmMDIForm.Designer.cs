namespace EventOfFormProject
{
    partial class frmMDIForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.childFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.child1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.child2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.child3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.childFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(324, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // childFormToolStripMenuItem
            // 
            this.childFormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.child1ToolStripMenuItem,
            this.child2ToolStripMenuItem,
            this.child3ToolStripMenuItem});
            this.childFormToolStripMenuItem.Name = "childFormToolStripMenuItem";
            this.childFormToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.childFormToolStripMenuItem.Text = "Child Form";
            this.childFormToolStripMenuItem.Click += new System.EventHandler(this.childFormToolStripMenuItem_Click);
            // 
            // child1ToolStripMenuItem
            // 
            this.child1ToolStripMenuItem.Name = "child1ToolStripMenuItem";
            this.child1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.child1ToolStripMenuItem.Text = "Child1";
            this.child1ToolStripMenuItem.Click += new System.EventHandler(this.child1ToolStripMenuItem_Click);
            // 
            // child2ToolStripMenuItem
            // 
            this.child2ToolStripMenuItem.Name = "child2ToolStripMenuItem";
            this.child2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.child2ToolStripMenuItem.Text = "Child2";
            this.child2ToolStripMenuItem.Click += new System.EventHandler(this.child2ToolStripMenuItem_Click);
            // 
            // child3ToolStripMenuItem
            // 
            this.child3ToolStripMenuItem.Name = "child3ToolStripMenuItem";
            this.child3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.child3ToolStripMenuItem.Text = "Child3";
            this.child3ToolStripMenuItem.Click += new System.EventHandler(this.child3ToolStripMenuItem_Click);
            // 
            // frmMDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDIForm";
            this.Text = "frmMDIForm";
            this.MdiChildActivate += new System.EventHandler(this.frmMDIForm_MdiChildActivate);
            this.Load += new System.EventHandler(this.frmMDIForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem childFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem child1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem child2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem child3ToolStripMenuItem;
    }
}