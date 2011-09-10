namespace WindowsFormsApplication1
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
        private int zoomno, ht, wd;
        private System.Windows.Forms.PrintPreviewControl prnPrvControl;
        private System.Drawing.Printing.PrintDocument prnDoc;
        /// 
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.hinh = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Box2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Box6 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.prnDoc = new System.Drawing.Printing.PrintDocument();
            this.prnPrvControl = new System.Windows.Forms.PrintPreviewControl();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box6)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Chuot1;
            this.button1.Location = new System.Drawing.Point(581, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 81);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hinh
            // 
            this.hinh.Location = new System.Drawing.Point(38, 12);
            this.hinh.Name = "hinh";
            this.hinh.Size = new System.Drawing.Size(165, 89);
            this.hinh.TabIndex = 6;
            this.hinh.TabStop = false;
            this.hinh.Click += new System.EventHandler(this.hinh_MouseClick);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Vit2;
            this.pictureBox5.Location = new System.Drawing.Point(235, 303);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(123, 121);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // Box2
            // 
            this.Box2.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Mouse1;
            this.Box2.Location = new System.Drawing.Point(429, 327);
            this.Box2.Name = "Box2";
            this.Box2.Size = new System.Drawing.Size(135, 97);
            this.Box2.TabIndex = 4;
            this.Box2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Tiger3;
            this.pictureBox4.Location = new System.Drawing.Point(606, 303);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 121);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Eagle3;
            this.pictureBox3.Location = new System.Drawing.Point(46, 277);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(140, 121);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.BirdTakeGift;
            this.pictureBox1.Location = new System.Drawing.Point(224, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 132);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Box6
            // 
            this.Box6.Location = new System.Drawing.Point(25, 119);
            this.Box6.Name = "Box6";
            this.Box6.Size = new System.Drawing.Size(178, 132);
            this.Box6.TabIndex = 8;
            this.Box6.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(224, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 55);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_MouseClick);
            // 
            // prnPrvControl
            // 
            this.prnPrvControl.AutoZoom = false;
            this.prnPrvControl.Document = this.prnDoc;
            this.prnPrvControl.Location = new System.Drawing.Point(390, 12);
            this.prnPrvControl.Name = "prnPrvControl";
            this.prnPrvControl.Size = new System.Drawing.Size(152, 160);
            this.prnPrvControl.TabIndex = 4;
            this.prnPrvControl.Zoom = 0.13272727272727272;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(619, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 436);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.prnPrvControl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Box6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hinh);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.Box2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox Box2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox hinh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Box6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

