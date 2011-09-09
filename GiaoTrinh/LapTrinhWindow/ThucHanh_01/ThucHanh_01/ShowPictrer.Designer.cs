namespace ThucHanh_01
{
    partial class ShowPictrer
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
            this.bt_EXIT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_EXIT
            // 
            this.bt_EXIT.Location = new System.Drawing.Point(504, 217);
            this.bt_EXIT.Name = "bt_EXIT";
            this.bt_EXIT.Size = new System.Drawing.Size(75, 23);
            this.bt_EXIT.TabIndex = 0;
            this.bt_EXIT.Text = "EXIT";
            this.bt_EXIT.UseVisualStyleBackColor = true;
            this.bt_EXIT.Click += new System.EventHandler(this.bt_EXIT_Click);
            // 
            // ShowPictrer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 262);
            this.Controls.Add(this.bt_EXIT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowPictrer";
            this.Text = "ShowPictrer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_EXIT;
    }
}