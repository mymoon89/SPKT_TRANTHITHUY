namespace test11234
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.nameGetButton = new System.Windows.Forms.Button();
            this.nameSetButton = new System.Windows.Forms.Button();
            this.intGetButton = new System.Windows.Forms.Button();
            this.intSetButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Index to set/get";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value to Set";
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(104, 22);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(171, 20);
            this.indexTextBox.TabIndex = 2;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(105, 71);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(169, 20);
            this.valueTextBox.TabIndex = 3;
            // 
            // nameGetButton
            // 
            this.nameGetButton.Location = new System.Drawing.Point(320, 74);
            this.nameGetButton.Name = "nameGetButton";
            this.nameGetButton.Size = new System.Drawing.Size(144, 25);
            this.nameGetButton.TabIndex = 4;
            this.nameGetButton.Text = "Set name";
            this.nameGetButton.UseVisualStyleBackColor = true;
            this.nameGetButton.Click += new System.EventHandler(this.nameGetButton_Click);
            // 
            // nameSetButton
            // 
            this.nameSetButton.Location = new System.Drawing.Point(495, 78);
            this.nameSetButton.Name = "nameSetButton";
            this.nameSetButton.Size = new System.Drawing.Size(150, 21);
            this.nameSetButton.TabIndex = 5;
            this.nameSetButton.Text = "Get name";
            this.nameSetButton.UseVisualStyleBackColor = true;
            this.nameSetButton.Click += new System.EventHandler(this.nameSetButton_Click);
            // 
            // intGetButton
            // 
            this.intGetButton.Location = new System.Drawing.Point(319, 22);
            this.intGetButton.Name = "intGetButton";
            this.intGetButton.Size = new System.Drawing.Size(144, 29);
            this.intGetButton.TabIndex = 6;
            this.intGetButton.Text = "Set Number";
            this.intGetButton.UseVisualStyleBackColor = true;
            this.intGetButton.Click += new System.EventHandler(this.intGetButton_Click);
            // 
            // intSetButton
            // 
            this.intSetButton.Location = new System.Drawing.Point(493, 23);
            this.intSetButton.Name = "intSetButton";
            this.intSetButton.Size = new System.Drawing.Size(151, 28);
            this.intSetButton.TabIndex = 7;
            this.intSetButton.Text = "Get Number";
            this.intSetButton.UseVisualStyleBackColor = true;
            this.intSetButton.Click += new System.EventHandler(this.intSetButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(109, 152);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(534, 20);
            this.resultTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 264);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.intSetButton);
            this.Controls.Add(this.intGetButton);
            this.Controls.Add(this.nameSetButton);
            this.Controls.Add(this.nameGetButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Button nameGetButton;
        private System.Windows.Forms.Button nameSetButton;
        private System.Windows.Forms.Button intGetButton;
        private System.Windows.Forms.Button intSetButton;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

