namespace Confuse
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
            this.realTextBox = new System.Windows.Forms.TextBox();
            this.imaginaryTextBox = new System.Windows.Forms.TextBox();
            this.realLabel = new System.Windows.Forms.Label();
            this.imaginaryLabel = new System.Windows.Forms.Label();
            this.firstButton = new System.Windows.Forms.Button();
            this.secondButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // realTextBox
            // 
            this.realTextBox.Location = new System.Drawing.Point(131, 12);
            this.realTextBox.Name = "realTextBox";
            this.realTextBox.Size = new System.Drawing.Size(100, 20);
            this.realTextBox.TabIndex = 0;
            // 
            // imaginaryTextBox
            // 
            this.imaginaryTextBox.Location = new System.Drawing.Point(131, 77);
            this.imaginaryTextBox.Name = "imaginaryTextBox";
            this.imaginaryTextBox.Size = new System.Drawing.Size(100, 20);
            this.imaginaryTextBox.TabIndex = 1;
            // 
            // realLabel
            // 
            this.realLabel.AutoSize = true;
            this.realLabel.Location = new System.Drawing.Point(33, 19);
            this.realLabel.Name = "realLabel";
            this.realLabel.Size = new System.Drawing.Size(29, 13);
            this.realLabel.TabIndex = 2;
            this.realLabel.Text = "Real";
            // 
            // imaginaryLabel
            // 
            this.imaginaryLabel.AutoSize = true;
            this.imaginaryLabel.Location = new System.Drawing.Point(33, 84);
            this.imaginaryLabel.Name = "imaginaryLabel";
            this.imaginaryLabel.Size = new System.Drawing.Size(52, 13);
            this.imaginaryLabel.TabIndex = 3;
            this.imaginaryLabel.Text = "Imaginary";
            // 
            // firstButton
            // 
            this.firstButton.Location = new System.Drawing.Point(276, 10);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(75, 23);
            this.firstButton.TabIndex = 4;
            this.firstButton.Text = "Set No 1";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // secondButton
            // 
            this.secondButton.Location = new System.Drawing.Point(276, 79);
            this.secondButton.Name = "secondButton";
            this.secondButton.Size = new System.Drawing.Size(75, 23);
            this.secondButton.TabIndex = 5;
            this.secondButton.Text = "Set No2";
            this.secondButton.UseVisualStyleBackColor = true;
            this.secondButton.Click += new System.EventHandler(this.secondButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(36, 150);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // subtractButton
            // 
            this.subtractButton.Location = new System.Drawing.Point(144, 150);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(75, 23);
            this.subtractButton.TabIndex = 7;
            this.subtractButton.Text = "Substract";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new System.EventHandler(this.subtractButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(276, 150);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(75, 23);
            this.multiplyButton.TabIndex = 8;
            this.multiplyButton.Text = "Multify";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(36, 217);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Notice:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 264);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.subtractButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.secondButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.imaginaryLabel);
            this.Controls.Add(this.realLabel);
            this.Controls.Add(this.imaginaryTextBox);
            this.Controls.Add(this.realTextBox);
            this.Name = "Form1";
            this.Text = "ComplexNumber";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox realTextBox;
        private System.Windows.Forms.TextBox imaginaryTextBox;
        private System.Windows.Forms.Label realLabel;
        private System.Windows.Forms.Label imaginaryLabel;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button secondButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Label statusLabel;
    }
}

