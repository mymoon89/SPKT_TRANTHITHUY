namespace duangua2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pxanh = new System.Windows.Forms.PictureBox();
            this.pxam = new System.Windows.Forms.PictureBox();
            this.pblue = new System.Windows.Forms.PictureBox();
            this.pdo = new System.Windows.Forms.PictureBox();
            this.btStart = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbtotal = new System.Windows.Forms.TextBox();
            this.tbdiem = new System.Windows.Forms.TextBox();
            this.pcxanh = new System.Windows.Forms.PictureBox();
            this.pcxam = new System.Windows.Forms.PictureBox();
            this.pcblue = new System.Windows.Forms.PictureBox();
            this.pcdo = new System.Windows.Forms.PictureBox();
            this.lbnew = new System.Windows.Forms.Label();
            this.lbnew1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcxanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcxam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcblue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcdo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbnew1);
            this.panel1.Controls.Add(this.lbnew);
            this.panel1.Controls.Add(this.pxanh);
            this.panel1.Controls.Add(this.pxam);
            this.panel1.Controls.Add(this.pblue);
            this.panel1.Controls.Add(this.pdo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 191);
            this.panel1.TabIndex = 0;
            // 
            // pxanh
            // 
            this.pxanh.Image = global::duangua2.Properties.Resources.XANH;
            this.pxanh.Location = new System.Drawing.Point(12, 132);
            this.pxanh.Name = "pxanh";
            this.pxanh.Size = new System.Drawing.Size(27, 30);
            this.pxanh.TabIndex = 106;
            this.pxanh.TabStop = false;
            // 
            // pxam
            // 
            this.pxam.Image = global::duangua2.Properties.Resources.XAM;
            this.pxam.Location = new System.Drawing.Point(12, 88);
            this.pxam.Name = "pxam";
            this.pxam.Size = new System.Drawing.Size(27, 30);
            this.pxam.TabIndex = 106;
            this.pxam.TabStop = false;
            // 
            // pblue
            // 
            this.pblue.Image = global::duangua2.Properties.Resources.DUONG;
            this.pblue.Location = new System.Drawing.Point(12, 49);
            this.pblue.Name = "pblue";
            this.pblue.Size = new System.Drawing.Size(27, 30);
            this.pblue.TabIndex = 106;
            this.pblue.TabStop = false;
            // 
            // pdo
            // 
            this.pdo.Image = global::duangua2.Properties.Resources.DO;
            this.pdo.Location = new System.Drawing.Point(12, 12);
            this.pdo.Name = "pdo";
            this.pdo.Size = new System.Drawing.Size(27, 30);
            this.pdo.TabIndex = 1;
            this.pdo.TabStop = false;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(529, 168);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Bắt đầu";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(498, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Chọn ngựa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Đặt cược";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "Số tiền";
            // 
            // tbtotal
            // 
            this.tbtotal.Location = new System.Drawing.Point(498, 22);
            this.tbtotal.Name = "tbtotal";
            this.tbtotal.Size = new System.Drawing.Size(136, 20);
            this.tbtotal.TabIndex = 102;
            // 
            // tbdiem
            // 
            this.tbdiem.Location = new System.Drawing.Point(498, 142);
            this.tbdiem.Name = "tbdiem";
            this.tbdiem.Size = new System.Drawing.Size(136, 20);
            this.tbdiem.TabIndex = 101;
            // 
            // pcxanh
            // 
            this.pcxanh.Image = global::duangua2.Properties.Resources.XANH;
            this.pcxanh.Location = new System.Drawing.Point(600, 88);
            this.pcxanh.Name = "pcxanh";
            this.pcxanh.Size = new System.Drawing.Size(27, 30);
            this.pcxanh.TabIndex = 2;
            this.pcxanh.TabStop = false;
            this.pcxanh.Click += new System.EventHandler(this.pcxanh_Click);
            // 
            // pcxam
            // 
            this.pcxam.Image = global::duangua2.Properties.Resources.XAM;
            this.pcxam.Location = new System.Drawing.Point(567, 88);
            this.pcxam.Name = "pcxam";
            this.pcxam.Size = new System.Drawing.Size(27, 30);
            this.pcxam.TabIndex = 3;
            this.pcxam.TabStop = false;
            this.pcxam.Click += new System.EventHandler(this.pcxam_Click);
            // 
            // pcblue
            // 
            this.pcblue.Image = global::duangua2.Properties.Resources.DUONG;
            this.pcblue.Location = new System.Drawing.Point(534, 88);
            this.pcblue.Name = "pcblue";
            this.pcblue.Size = new System.Drawing.Size(27, 30);
            this.pcblue.TabIndex = 4;
            this.pcblue.TabStop = false;
            this.pcblue.Click += new System.EventHandler(this.pcblue_Click);
            // 
            // pcdo
            // 
            this.pcdo.Image = global::duangua2.Properties.Resources.DO;
            this.pcdo.Location = new System.Drawing.Point(501, 88);
            this.pcdo.Name = "pcdo";
            this.pcdo.Size = new System.Drawing.Size(27, 30);
            this.pcdo.TabIndex = 5;
            this.pcdo.TabStop = false;
            this.pcdo.Click += new System.EventHandler(this.pcdo_Click);
            // 
            // lbnew
            // 
            this.lbnew.AutoSize = true;
            this.lbnew.Location = new System.Drawing.Point(12, 173);
            this.lbnew.Name = "lbnew";
            this.lbnew.Size = new System.Drawing.Size(52, 13);
            this.lbnew.TabIndex = 107;
            this.lbnew.Text = "Thông tin";
            // 
            // lbnew1
            // 
            this.lbnew1.AutoSize = true;
            this.lbnew1.Location = new System.Drawing.Point(347, 173);
            this.lbnew1.Name = "lbnew1";
            this.lbnew1.Size = new System.Drawing.Size(96, 13);
            this.lbnew1.TabIndex = 108;
            this.lbnew1.Text = "Chuẩn bị xuất phát";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 192);
            this.Controls.Add(this.pcxanh);
            this.Controls.Add(this.pcxam);
            this.Controls.Add(this.pcblue);
            this.Controls.Add(this.pcdo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbtotal);
            this.Controls.Add(this.tbdiem);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Game đua ngựa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcxanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcxam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcblue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcdo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.PictureBox pdo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbtotal;
        private System.Windows.Forms.TextBox tbdiem;
        private System.Windows.Forms.PictureBox pcxanh;
        private System.Windows.Forms.PictureBox pcxam;
        private System.Windows.Forms.PictureBox pcblue;
        private System.Windows.Forms.PictureBox pcdo;
        private System.Windows.Forms.PictureBox pxam;
        private System.Windows.Forms.PictureBox pblue;
        private System.Windows.Forms.PictureBox pxanh;
        private System.Windows.Forms.Label lbnew;
        private System.Windows.Forms.Label lbnew1;
    }
}

