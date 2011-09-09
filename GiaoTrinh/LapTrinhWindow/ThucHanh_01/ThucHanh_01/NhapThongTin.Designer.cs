namespace ThucHanh_01
{
    partial class NhapThongTin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_Female = new System.Windows.Forms.RadioButton();
            this.rdb_Male = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_Add = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clb_Qua = new System.Windows.Forms.CheckedListBox();
            this.cb_Bike = new System.Windows.Forms.CheckBox();
            this.cb_Car = new System.Windows.Forms.CheckBox();
            this.cb_Home = new System.Windows.Forms.CheckBox();
            this.bt_OK = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_NEXT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(18, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(16, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Qualification:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(16, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Assets";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(109, 20);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(200, 20);
            this.tb_name.TabIndex = 5;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_Female);
            this.groupBox1.Controls.Add(this.rdb_Male);
            this.groupBox1.Location = new System.Drawing.Point(109, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 33);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rdb_Female
            // 
            this.rdb_Female.AutoSize = true;
            this.rdb_Female.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rdb_Female.Location = new System.Drawing.Point(114, 10);
            this.rdb_Female.Name = "rdb_Female";
            this.rdb_Female.Size = new System.Drawing.Size(59, 17);
            this.rdb_Female.TabIndex = 7;
            this.rdb_Female.TabStop = true;
            this.rdb_Female.Text = "Female";
            this.rdb_Female.UseVisualStyleBackColor = true;
            // 
            // rdb_Male
            // 
            this.rdb_Male.AutoSize = true;
            this.rdb_Male.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rdb_Male.Location = new System.Drawing.Point(45, 10);
            this.rdb_Male.Name = "rdb_Male";
            this.rdb_Male.Size = new System.Drawing.Size(48, 17);
            this.rdb_Male.TabIndex = 7;
            this.rdb_Male.TabStop = true;
            this.rdb_Male.Text = "Male";
            this.rdb_Male.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_Add);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tb_name);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 159);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // rtb_Add
            // 
            this.rtb_Add.Location = new System.Drawing.Point(110, 97);
            this.rtb_Add.Name = "rtb_Add";
            this.rtb_Add.Size = new System.Drawing.Size(199, 49);
            this.rtb_Add.TabIndex = 8;
            this.rtb_Add.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clb_Qua);
            this.groupBox3.Controls.Add(this.cb_Bike);
            this.groupBox3.Controls.Add(this.cb_Car);
            this.groupBox3.Controls.Add(this.cb_Home);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(14, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 150);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // clb_Qua
            // 
            this.clb_Qua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.clb_Qua.FormattingEnabled = true;
            this.clb_Qua.Items.AddRange(new object[] {
            "MBA",
            "MS",
            "DS",
            "FF"});
            this.clb_Qua.Location = new System.Drawing.Point(105, 23);
            this.clb_Qua.Name = "clb_Qua";
            this.clb_Qua.Size = new System.Drawing.Size(199, 34);
            this.clb_Qua.TabIndex = 9;
            // 
            // cb_Bike
            // 
            this.cb_Bike.AutoSize = true;
            this.cb_Bike.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cb_Bike.Location = new System.Drawing.Point(108, 125);
            this.cb_Bike.Name = "cb_Bike";
            this.cb_Bike.Size = new System.Drawing.Size(47, 17);
            this.cb_Bike.TabIndex = 8;
            this.cb_Bike.Text = "Bike";
            this.cb_Bike.UseVisualStyleBackColor = true;
            // 
            // cb_Car
            // 
            this.cb_Car.AutoSize = true;
            this.cb_Car.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cb_Car.Location = new System.Drawing.Point(108, 102);
            this.cb_Car.Name = "cb_Car";
            this.cb_Car.Size = new System.Drawing.Size(42, 17);
            this.cb_Car.TabIndex = 7;
            this.cb_Car.Text = "Car";
            this.cb_Car.UseVisualStyleBackColor = true;
            // 
            // cb_Home
            // 
            this.cb_Home.AutoSize = true;
            this.cb_Home.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cb_Home.Location = new System.Drawing.Point(108, 79);
            this.cb_Home.Name = "cb_Home";
            this.cb_Home.Size = new System.Drawing.Size(54, 17);
            this.cb_Home.TabIndex = 6;
            this.cb_Home.Text = "Home";
            this.cb_Home.UseVisualStyleBackColor = true;
            // 
            // bt_OK
            // 
            this.bt_OK.BackColor = System.Drawing.Color.Maroon;
            this.bt_OK.ForeColor = System.Drawing.Color.White;
            this.bt_OK.Location = new System.Drawing.Point(58, 329);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 9;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = false;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.Black;
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(246, 329);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 23);
            this.bt_Exit.TabIndex = 10;
            this.bt_Exit.Text = "EXIT";
            this.bt_Exit.UseVisualStyleBackColor = false;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_NEXT
            // 
            this.bt_NEXT.BackColor = System.Drawing.Color.Blue;
            this.bt_NEXT.ForeColor = System.Drawing.Color.White;
            this.bt_NEXT.Location = new System.Drawing.Point(154, 329);
            this.bt_NEXT.Name = "bt_NEXT";
            this.bt_NEXT.Size = new System.Drawing.Size(75, 23);
            this.bt_NEXT.TabIndex = 11;
            this.bt_NEXT.Text = "NEXT";
            this.bt_NEXT.UseVisualStyleBackColor = false;
            this.bt_NEXT.Click += new System.EventHandler(this.bt_NEXT_Click);
            // 
            // NhapThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 364);
            this.Controls.Add(this.bt_NEXT);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "NhapThongTin";
            this.Text = "NhapThongTin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_Female;
        private System.Windows.Forms.RadioButton rdb_Male;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_Add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cb_Bike;
        private System.Windows.Forms.CheckBox cb_Car;
        private System.Windows.Forms.CheckBox cb_Home;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.CheckedListBox clb_Qua;
        private System.Windows.Forms.Button bt_NEXT;
    }
}