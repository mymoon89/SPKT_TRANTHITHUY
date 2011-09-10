namespace kethua
{
    partial class Form1
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
            this.DoanThang = new System.Windows.Forms.Button();
            this.TamGiac = new System.Windows.Forms.Button();
            this.ChuNhat = new System.Windows.Forms.Button();
            this.HinhTron = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DoanThang
            // 
            this.DoanThang.Location = new System.Drawing.Point(35, 35);
            this.DoanThang.Name = "DoanThang";
            this.DoanThang.Size = new System.Drawing.Size(75, 23);
            this.DoanThang.TabIndex = 0;
            this.DoanThang.Text = "DoanThang";
            this.DoanThang.UseVisualStyleBackColor = true;
            this.DoanThang.Click += new System.EventHandler(this.DoanThang_Click);
            // 
            // TamGiac
            // 
            this.TamGiac.Location = new System.Drawing.Point(35, 103);
            this.TamGiac.Name = "TamGiac";
            this.TamGiac.Size = new System.Drawing.Size(75, 23);
            this.TamGiac.TabIndex = 1;
            this.TamGiac.Text = "TamGiac";
            this.TamGiac.UseVisualStyleBackColor = true;
            this.TamGiac.Click += new System.EventHandler(this.TamGiac_Click);
            // 
            // ChuNhat
            // 
            this.ChuNhat.Location = new System.Drawing.Point(35, 167);
            this.ChuNhat.Name = "ChuNhat";
            this.ChuNhat.Size = new System.Drawing.Size(75, 23);
            this.ChuNhat.TabIndex = 2;
            this.ChuNhat.Text = "ChuNhat";
            this.ChuNhat.UseVisualStyleBackColor = true;
            this.ChuNhat.Click += new System.EventHandler(this.ChuNhat_Click);
            // 
            // HinhTron
            // 
            this.HinhTron.Location = new System.Drawing.Point(35, 230);
            this.HinhTron.Name = "HinhTron";
            this.HinhTron.Size = new System.Drawing.Size(75, 23);
            this.HinhTron.TabIndex = 3;
            this.HinhTron.Text = "HinhTron";
            this.HinhTron.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(163, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(462, 276);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 312);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HinhTron);
            this.Controls.Add(this.ChuNhat);
            this.Controls.Add(this.TamGiac);
            this.Controls.Add(this.DoanThang);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoanThang;
        private System.Windows.Forms.Button TamGiac;
        private System.Windows.Forms.Button ChuNhat;
        private System.Windows.Forms.Button HinhTron;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

