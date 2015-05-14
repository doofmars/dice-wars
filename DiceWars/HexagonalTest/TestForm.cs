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

namespace HexagonalTest
{
	public partial class TestForm : Form
	{

		Board board;
		GraphicsEngine graphicsEngine;

		public TestForm()
		{
			InitializeComponent();

            startGame();
		}

		private void Form_MouseMove(object sender, MouseEventArgs e)
		{
			labelXY.Text = e.X.ToString() + "," + e.Y.ToString();

		}

		private void startGame()
		{

            BoardState state = new Builder.BoardStateBuilder()
                .withGridPenWidth(2)
                .withActiveHexBorderColor(Color.Red)
                .withActiveGridPenWidth(2)
                .build();

            this.board = new Builder.BoardBuilder()
                .witHeight(15)
                .withWidht(15)
                .withSide(25)
                .withPlayer(5)
                .withOrientation(HexOrientation.Pointy)
                .withBoardState(state)
                .build();

			this.graphicsEngine = new GraphicsEngine(board,20,20);
		}

		private void Form_MouseClick(object sender, MouseEventArgs e)
		{
			
			Console.WriteLine("Mouse Click " + e.Location.ToString());
			
			if (board != null && graphicsEngine != null)
			{
				//
				// need to account for any offset
				//
				Point mouseClick = new Point(e.X - graphicsEngine.BoardXOffset, e.Y - graphicsEngine.BoardYOffset);

				Console.WriteLine("Click in Board bounding rectangle: {0}", board.PointInBoardRectangle(e.Location));

				Hex clickedHex = board.FindHexMouseClick(mouseClick);

				if (clickedHex == null)
				{
					Console.WriteLine("No hex was clicked.");
				}
				else
				{
                    Console.WriteLine("Hex " + clickedHex + " was clicked.");
                    if (board.getCurrentPlayerColour() == clickedHex.HexState.BackgroundColor) 
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
            current_player.BackColor = this.board.getCurrentPlayerColour();
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
            current_player.BackColor = this.board.getCurrentPlayerColour();
            this.board.BoardState.ActiveHex = null;
        }

		
		
	}
}