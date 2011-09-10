namespace IndexerBox
{
    partial class Form1
    {
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.intGetButton = new System.Windows.Forms.Button();
            this.intSetButton = new System.Windows.Forms.Button();
            this.nameGetButton = new System.Windows.Forms.Button();
            this.nameSetButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Index to set/get";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value to set";
            // 
            // intGetButton
            // 
            this.intGetButton.Location = new System.Drawing.Point(264, 35);
            this.intGetButton.Name = "intGetButton";
            this.intGetButton.Size = new System.Drawing.Size(144, 30);
            this.intGetButton.TabIndex = 2;
            this.intGetButton.Text = "get value by index";
            this.intGetButton.UseVisualStyleBackColor = true;
            // 
            // intSetButton
            // 
            this.intSetButton.Location = new System.Drawing.Point(445, 35);
            this.intSetButton.Name = "intSetButton";
            this.intSetButton.Size = new System.Drawing.Size(150, 30);
            this.intSetButton.TabIndex = 3;
            this.intSetButton.Text = "Set value by index";
            this.intSetButton.UseVisualStyleBackColor = true;
            // 
            // nameGetButton
            // 
            this.nameGetButton.Location = new System.Drawing.Point(264, 90);
            this.nameGetButton.Name = "nameGetButton";
            this.nameGetButton.Size = new System.Drawing.Size(144, 32);
            this.nameGetButton.TabIndex = 4;
            this.nameGetButton.Text = "Get value by Name";
            this.nameGetButton.UseVisualStyleBackColor = true;
            // 
            // nameSetButton
            // 
            this.nameSetButton.Location = new System.Drawing.Point(445, 90);
            this.nameSetButton.Name = "nameSetButton";
            this.nameSetButton.Size = new System.Drawing.Size(150, 32);
            this.nameSetButton.TabIndex = 5;
            this.nameSetButton.Text = "Set value by Name";
            this.nameSetButton.UseVisualStyleBackColor = true;
            this.nameSetButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(26, 145);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(569, 20);
            this.resultTextBox.TabIndex = 6;
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(121, 41);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(124, 20);
            this.indexTextBox.TabIndex = 7;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(121, 95);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(124, 20);
            this.valueTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 204);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.nameSetButton);
            this.Controls.Add(this.nameGetButton);
            this.Controls.Add(this.intSetButton);
            this.Controls.Add(this.intGetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

  

    }
}

