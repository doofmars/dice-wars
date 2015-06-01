using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Hexagonal;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace HexagonalTest
{
	public partial class Fight : Form
	{

		Board board;
		GraphicsEngine graphicsEngine;
        private Label[,] labels;
        int sizeOfField;

		public Fight(Board x, int size)
		{
            board = x;
            sizeOfField = size;
			InitializeComponent(sizeOfField);

            startGame();
		}

		private void Form_MouseMove(object sender, MouseEventArgs e)
		{
			labelXY.Text = e.X.ToString() + "," + e.Y.ToString();

		}

		private void startGame()
		{
            
            const int POSX = 15;
            const int POSY = 37;
            
			this.graphicsEngine = new GraphicsEngine(board,20,20);

            labels = new Label[sizeOfField, sizeOfField]; // MaHa
            // MaHa -- 
            // Textboxen "zeichnen"
            int[,] tmpX = board.TextPosX;
            int[,] tmpY = board.TextPosY;

            for (int i = 0; i < sizeOfField; i++)
            {
                for (int j = 0; j < sizeOfField; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Text = board.Hexes[i, j].Dices.ToString();
                    labels[i, j].BackColor = board.Hexes[i, j].HexState.BackgroundColor;
                    labels[i, j].Size = new System.Drawing.Size(13, 15);
                    labels[i, j].Location = new Point(tmpX[i, j] + POSX, tmpY[i, j] + POSY);
                    this.Controls.Add(labels[i, j]);
                }
            }

            DiceLabels.GetInstance.addLabels(this.labels);
            // -- End
		}

		private void Form_MouseClick(object sender, MouseEventArgs e)
		{
			
			//Console.WriteLine("Mouse Click " + e.Location.ToString());
			
			if (board != null && graphicsEngine != null)
			{
				//
				// need to account for any offset
				//
				Point mouseClick = new Point(e.X - graphicsEngine.BoardXOffset, e.Y - graphicsEngine.BoardYOffset);

				//Console.WriteLine("Click in Board bounding rectangle: {0}", board.PointInBoardRectangle(e.Location));

				Hex clickedHex = board.FindHexMouseClick(mouseClick);

				if (clickedHex == null)
				{
					Console.WriteLine("No hex was clicked.");
				}
				else
				{
                    if (e.Button == MouseButtons.Right)
                    {
                        Console.WriteLine("Hex " + clickedHex + " was clicked." + "Hex has " + clickedHex.Dices + " Dices");
                        return;
                    }

                    if (board.getCurrentPlayerColor() == clickedHex.HexState.BackgroundColor) 
                    {
                        board.BoardState.ActiveHex = clickedHex;
                    }
                    else if (clickedHex.IsNeighbor(board.BoardState.ActiveHex)) 
                    {
                        board.performAttack(board.BoardState.ActiveHex, clickedHex);
                    }
				}
			}
            //Update status lable
            lable_players.Text = this.board.getStatus();
		}

		private void Form_Paint(object sender, PaintEventArgs e)
		{
			//Draw the graphics/GUI

			foreach (Control c in this.Controls)
			{
				c.Refresh();
			}

			if (graphicsEngine != null)
			{
				graphicsEngine.Draw(e.Graphics);
			}
            //set Current player from model
            current_player.BackColor = this.board.getCurrentPlayerColor();
            //Update status lable
            lable_players.Text = this.board.getStatus();
			//Force the next Paint()
			this.Invalidate();

		}

		private void Form_Closing(object sender, FormClosingEventArgs e)
		{
			if (graphicsEngine != null)
			{
				graphicsEngine = null;
			}

			if (board != null)
			{
				board = null;
			}
		}

        private void bt_end_Click(object sender, EventArgs e)
        {
            this.board.nextPlayer();
            //set Current player from model
            current_player.BackColor = this.board.getCurrentPlayerColor();
            this.board.BoardState.ActiveHex = null;
        }


       

	}
}