namespace ThuaKe_Form
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
            this.btnDoanthang = new System.Windows.Forms.Button();
            this.btnTamGiac = new System.Windows.Forms.Button();
            this.btnTuGiac = new System.Windows.Forms.Button();
            this.btnHinhTron = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDoanthang
            // 
            this.btnDoanthang.Location = new System.Drawing.Point(67, 30);
            this.btnDoanthang.Name = "btnDoanthang";
            this.btnDoanthang.Size = new System.Drawing.Size(70, 25);
            this.btnDoanthang.TabIndex = 0;
            this.btnDoanthang.Text = "Doanthang";
            this.btnDoanthang.UseVisualStyleBackColor = true;
            this.btnDoanthang.Click += new System.EventHandler(this.Doanthang_Click);
            // 
            // btnTamGiac
            // 
            this.btnTamGiac.Location = new System.Drawing.Point(172, 32);
            this.btnTamGiac.Name = "btnTamGiac";
            this.btnTamGiac.Size = new System.Drawing.Size(70, 25);
            this.btnTamGiac.TabIndex = 1;
            this.btnTamGiac.Text = "TamGiac";
            this.btnTamGiac.UseVisualStyleBackColor = true;
            this.btnTamGiac.Click += new System.EventHandler(this.TamGiac_Click);
            // 
            // btnTuGiac
            // 
            this.btnTuGiac.Location = new System.Drawing.Point(269, 34);
            this.btnTuGiac.Name = "btnTuGiac";
            this.btnTuGiac.Size = new System.Drawing.Size(70, 25);
            this.btnTuGiac.TabIndex = 2;
            this.btnTuGiac.Text = "TuGiac";
            this.btnTuGiac.UseVisualStyleBackColor = true;
            // 
            // btnHinhTron
            // 
            this.btnHinhTron.Location = new System.Drawing.Point(374, 36);
            this.btnHinhTron.Name = "btnHinhTron";
            this.btnHinhTron.Size = new System.Drawing.Size(70, 25);
            this.btnHinhTron.TabIndex = 3;
            this.btnHinhTron.Text = "HinhTron";
            this.btnHinhTron.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(551, 309);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 464);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnHinhTron);
            this.Controls.Add(this.btnTuGiac);
            this.Controls.Add(this.btnTamGiac);
            this.Controls.Add(this.btnDoanthang);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDoanthang;
        private System.Windows.Forms.Button btnTamGiac;
        private System.Windows.Forms.Button btnTuGiac;
        private System.Windows.Forms.Button btnHinhTron;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

