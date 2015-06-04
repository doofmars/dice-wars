namespace HexagonalTest
{
    partial class WinnerName
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
            this.textBoxWinnerName = new System.Windows.Forms.TextBox();
            this.buttonSaveName = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxWinnerName
            // 
            this.textBoxWinnerName.Location = new System.Drawing.Point(12, 214);
            this.textBoxWinnerName.Name = "textBoxWinnerName";
            this.textBoxWinnerName.Size = new System.Drawing.Size(190, 20);
            this.textBoxWinnerName.TabIndex = 0;
            // 
            // buttonSaveName
            // 
            this.buttonSaveName.Location = new System.Drawing.Point(236, 212);
            this.buttonSaveName.Name = "buttonSaveName";
            this.buttonSaveName.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveName.TabIndex = 1;
            this.buttonSaveName.Text = "Save";
            this.buttonSaveName.UseVisualStyleBackColor = true;
            this.buttonSaveName.ForeColor = System.Drawing.Color.White;
            this.buttonSaveName.Click += new System.EventHandler(this.buttonSaveName_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HexagonalTest.Properties.Resources.winner;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 196);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // WinnerName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(322, 246);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSaveName);
            this.Controls.Add(this.textBoxWinnerName);
            this.Name = "WinnerName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winner enter name";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWinnerName;
        private System.Windows.Forms.Button buttonSaveName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}