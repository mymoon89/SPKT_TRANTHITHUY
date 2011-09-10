namespace DelegateEvents
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
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDo = new System.Windows.Forms.Button();
            this.radCong = new System.Windows.Forms.RadioButton();
            this.radTru = new System.Windows.Forms.RadioButton();
            this.radNhan = new System.Windows.Forms.RadioButton();
            this.radChia = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(66, 19);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(101, 20);
            this.txtA.TabIndex = 0;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(267, 29);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(73, 20);
            this.txtB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số B";
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(102, 126);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(139, 46);
            this.btnDo.TabIndex = 3;
            this.btnDo.Text = "Thực Hiện Phép Toán";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // radCong
            // 
            this.radCong.AutoSize = true;
            this.radCong.Location = new System.Drawing.Point(395, 71);
            this.radCong.Name = "radCong";
            this.radCong.Size = new System.Drawing.Size(50, 17);
            this.radCong.TabIndex = 4;
            this.radCong.TabStop = true;
            this.radCong.Text = "Cộng";
            this.radCong.UseVisualStyleBackColor = true;
            // 
            // radTru
            // 
            this.radTru.AutoSize = true;
            this.radTru.Location = new System.Drawing.Point(395, 94);
            this.radTru.Name = "radTru";
            this.radTru.Size = new System.Drawing.Size(41, 17);
            this.radTru.TabIndex = 4;
            this.radTru.TabStop = true;
            this.radTru.Text = "Trừ";
            this.radTru.UseVisualStyleBackColor = true;
            // 
            // radNhan
            // 
            this.radNhan.AutoSize = true;
            this.radNhan.Location = new System.Drawing.Point(395, 117);
            this.radNhan.Name = "radNhan";
            this.radNhan.Size = new System.Drawing.Size(51, 17);
            this.radNhan.TabIndex = 4;
            this.radNhan.TabStop = true;
            this.radNhan.Text = "Nhân";
            this.radNhan.UseVisualStyleBackColor = true;
            this.radNhan.CheckedChanged += new System.EventHandler(this.radNhan_CheckedChanged);
            // 
            // radChia
            // 
            this.radChia.AutoSize = true;
            this.radChia.Location = new System.Drawing.Point(395, 141);
            this.radChia.Name = "radChia";
            this.radChia.Size = new System.Drawing.Size(46, 17);
            this.radChia.TabIndex = 4;
            this.radChia.TabStop = true;
            this.radChia.Text = "Chia";
            this.radChia.UseVisualStyleBackColor = true;
            this.radChia.CheckedChanged += new System.EventHandler(this.radChia_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "DoSomeThings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(333, 219);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(135, 61);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký nghe Nút Test";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(331, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 53);
            this.button3.TabIndex = 6;
            this.button3.Text = "Hủy đăng ký nghe Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(163, 335);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(95, 43);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Nút Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 403);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.radChia);
            this.Controls.Add(this.radNhan);
            this.Controls.Add(this.radTru);
            this.Controls.Add(this.radCong);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.RadioButton radCong;
        private System.Windows.Forms.RadioButton radTru;
        private System.Windows.Forms.RadioButton radNhan;
        private System.Windows.Forms.RadioButton radChia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnTest;
    }
}

