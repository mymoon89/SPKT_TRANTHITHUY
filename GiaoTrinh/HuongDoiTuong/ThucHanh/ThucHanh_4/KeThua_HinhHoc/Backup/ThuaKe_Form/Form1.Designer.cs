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
            this.Doanthang = new System.Windows.Forms.Button();
            this.btnTamGiac = new System.Windows.Forms.Button();
            this.TuGiac = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Doanthang
            // 
            this.Doanthang.Location = new System.Drawing.Point(67, 30);
            this.Doanthang.Name = "Doanthang";
            this.Doanthang.Size = new System.Drawing.Size(70, 25);
            this.Doanthang.TabIndex = 0;
            this.Doanthang.Text = "Doanthang";
            this.Doanthang.UseVisualStyleBackColor = true;
            this.Doanthang.Click += new System.EventHandler(this.Doanthang_Click);
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
            // TuGiac
            // 
            this.TuGiac.Location = new System.Drawing.Point(269, 34);
            this.TuGiac.Name = "TuGiac";
            this.TuGiac.Size = new System.Drawing.Size(70, 25);
            this.TuGiac.TabIndex = 2;
            this.TuGiac.Text = "TuGiac";
            this.TuGiac.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(374, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 24);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(86, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 300);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 464);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.TuGiac);
            this.Controls.Add(this.btnTamGiac);
            this.Controls.Add(this.Doanthang);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Doanthang;
        private System.Windows.Forms.Button btnTamGiac;
        private System.Windows.Forms.Button TuGiac;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

