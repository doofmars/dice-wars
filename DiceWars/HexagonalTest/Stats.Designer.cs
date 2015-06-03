namespace HexagonalTest
{
    partial class Stats
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
            this.tableLayoutPanelDatabase = new System.Windows.Forms.TableLayoutPanel();
            this.labelSizeOfField = new System.Windows.Forms.Label();
            this.labelEnemies = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelWinner = new System.Windows.Forms.Label();
            this.tableLayoutPanelDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDatabase
            // 
            this.tableLayoutPanelDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDatabase.AutoScroll = true;
            this.tableLayoutPanelDatabase.AutoSize = true;
            this.tableLayoutPanelDatabase.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelDatabase.ColumnCount = 4;
            this.tableLayoutPanelDatabase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDatabase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDatabase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanelDatabase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanelDatabase.Controls.Add(this.labelSizeOfField, 3, 0);
            this.tableLayoutPanelDatabase.Controls.Add(this.labelEnemies, 2, 0);
            this.tableLayoutPanelDatabase.Controls.Add(this.labelTime, 1, 0);
            this.tableLayoutPanelDatabase.Controls.Add(this.labelWinner, 0, 0);
            this.tableLayoutPanelDatabase.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelDatabase.Name = "tableLayoutPanelDatabase";
            this.tableLayoutPanelDatabase.RowCount = 1;
            this.tableLayoutPanelDatabase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDatabase.Size = new System.Drawing.Size(482, 39);
            this.tableLayoutPanelDatabase.TabIndex = 0;
            // 
            // labelSizeOfField
            // 
            this.labelSizeOfField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSizeOfField.AutoSize = true;
            this.labelSizeOfField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSizeOfField.Location = new System.Drawing.Point(350, 13);
            this.labelSizeOfField.Name = "labelSizeOfField";
            this.labelSizeOfField.Size = new System.Drawing.Size(128, 13);
            this.labelSizeOfField.TabIndex = 1;
            this.labelSizeOfField.Text = "Spielfeldgröße";
            this.labelSizeOfField.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelEnemies
            // 
            this.labelEnemies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEnemies.AutoSize = true;
            this.labelEnemies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemies.Location = new System.Drawing.Point(214, 13);
            this.labelEnemies.Name = "labelEnemies";
            this.labelEnemies.Size = new System.Drawing.Size(129, 13);
            this.labelEnemies.TabIndex = 1;
            this.labelEnemies.Text = "Gegner-Anzahl";
            this.labelEnemies.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(109, 13);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(98, 13);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Spielzeit";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelWinner
            // 
            this.labelWinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWinner.AutoSize = true;
            this.labelWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinner.Location = new System.Drawing.Point(4, 13);
            this.labelWinner.Name = "labelWinner";
            this.labelWinner.Size = new System.Drawing.Size(98, 13);
            this.labelWinner.TabIndex = 1;
            this.labelWinner.Text = "Gewinner-Name";
            this.labelWinner.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(506, 440);
            this.Controls.Add(this.tableLayoutPanelDatabase);
            this.MaximumSize = new System.Drawing.Size(522, 478);
            this.MinimumSize = new System.Drawing.Size(522, 478);
            this.Name = "Stats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stats";
            this.tableLayoutPanelDatabase.ResumeLayout(false);
            this.tableLayoutPanelDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDatabase;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelEnemies;
        private System.Windows.Forms.Label labelSizeOfField;
        private System.Windows.Forms.Label labelWinner;


    }
}