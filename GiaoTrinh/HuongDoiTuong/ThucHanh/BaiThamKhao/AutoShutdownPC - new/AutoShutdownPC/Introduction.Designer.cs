namespace AutoShutdownPC
{
    partial class Introduction
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
            this.StrPrg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StrPrg
            // 
            this.StrPrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StrPrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrPrg.Location = new System.Drawing.Point(381, 340);
            this.StrPrg.Name = "StrPrg";
            this.StrPrg.Size = new System.Drawing.Size(109, 30);
            this.StrPrg.TabIndex = 1;
            this.StrPrg.Text = "Start Program";
            this.StrPrg.UseVisualStyleBackColor = false;
            this.StrPrg.Click += new System.EventHandler(this.StrPrg_Click);
            // 
            // Introduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AutoShutdownPC.Properties.Resources.IconIntro1;
            this.ClientSize = new System.Drawing.Size(506, 377);
            this.Controls.Add(this.StrPrg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Introduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Introduction";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StrPrg;
    }
}