namespace HexagonalTest
{
	partial class Fight
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
		private void InitializeComponent(int sizeBoard)
		{
            //Dynamic size of the Fight form
            int sizeOfBoardx = 0;
            int sizeOfBoardy = 0;

            //position of the elements on the right side
            //the Y-Position is fix ... only the X-position change dynamic
            int dynamicPos = 0;

            //the label at the bottom
            int labelBot = 0;
            
            //set the size dynamic, because of the size of the playground
            switch (sizeBoard)
            {
                case 5: sizeOfBoardx = 350;
                        sizeOfBoardy = 270;
                        dynamicPos = 270;
                        labelBot = 240;    

                    break;
                case 8: sizeOfBoardx = 490;
                         sizeOfBoardy = 380;
                         dynamicPos = 415;
                         labelBot = 350;

                    break;
                case 11: sizeOfBoardx = 620;
                         sizeOfBoardy = 500;
                         dynamicPos = 540;
                         labelBot = 470;

                    break;
                case 14: sizeOfBoardx = 740;
                         sizeOfBoardy = 600;
                         dynamicPos = 665;
                         labelBot = 570;

                    break;
                case 18: sizeOfBoardx = 920;
                         sizeOfBoardy = 755;
                         dynamicPos = 835;
                         labelBot = 725;

                    break;
                default:
                    break;
            }

            this.labelXY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_end = new System.Windows.Forms.Button();
            this.current_player = new System.Windows.Forms.Panel();
            this.lable_players = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelXY
            // 
            this.labelXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelXY.AutoSize = true;
            this.labelXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXY.ForeColor = System.Drawing.Color.Blue;
            this.labelXY.Location = new System.Drawing.Point(dynamicPos, 22);
            this.labelXY.Name = "labelXY";
            this.labelXY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelXY.Size = new System.Drawing.Size(41, 13);
            this.labelXY.TabIndex = 1;
            this.labelXY.Text = "label1";
            this.labelXY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(dynamicPos, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mouse X,Y";
            // 
            // bt_end
            // 
            this.bt_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_end.Location = new System.Drawing.Point(dynamicPos, 38);
            this.bt_end.Name = "bt_end";
            this.bt_end.Size = new System.Drawing.Size(65, 23);
            this.bt_end.TabIndex = 11;
            this.bt_end.Text = "End Turn";
            this.bt_end.UseVisualStyleBackColor = true;
            this.bt_end.Click += new System.EventHandler(this.bt_end_Click);
            // 
            // current_player
            // 
            this.current_player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.current_player.Location = new System.Drawing.Point(dynamicPos, 68);
            this.current_player.Name = "current_player";
            this.current_player.Size = new System.Drawing.Size(65, 65);
            this.current_player.TabIndex = 12;
            // 
            // lable_players
            // 
            this.lable_players.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lable_players.AutoSize = true;
            this.lable_players.Location = new System.Drawing.Point(12, labelBot);
            this.lable_players.Name = "lable_players";
            this.lable_players.Size = new System.Drawing.Size(35, 13);
            this.lable_players.TabIndex = 13;
            this.lable_players.Text = "label1";
            // 
            // Fight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(sizeOfBoardx, sizeOfBoardy); //803, 627
            this.Controls.Add(this.lable_players);
            this.Controls.Add(this.current_player);
            this.Controls.Add(this.bt_end);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelXY);
            this.DoubleBuffered = true;
            this.Name = "Fight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fight";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(sizeOfBoardx+20, sizeOfBoardy+40);
            this.MaximumSize = new System.Drawing.Size(sizeOfBoardx+20, sizeOfBoardy+40);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label labelXY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_end;
        private System.Windows.Forms.Panel current_player;
        private System.Windows.Forms.Label lable_players;
	}
}