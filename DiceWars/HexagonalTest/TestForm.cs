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

		Hexagonal.Board board;
		Hexagonal.GraphicsEngine graphicsEngine;

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
			Board board = new Board(20, 15, 25, HexOrientation.Pointy);
			//board.BoardState.BackgroundColor = Color.Green;
			board.BoardState.GridPenWidth = 2;
			board.BoardState.ActiveHexBorderColor = Color.Red;
			board.BoardState.ActiveHexBorderWidth = 2; 
			
			this.board = board;
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
					board.BoardState.ActiveHex = null;
					
				}
				else
				{
                    Console.WriteLine("Hex " + clickedHex + " was clicked.");
                    if (board.BoardState.ActiveHex == null)
                    {
                        board.BoardState.ActiveHex = clickedHex;
                    }
                        else
                    {
                        if (board.BoardState.ActiveHex.IsNeighbor(clickedHex))
                        {
                            clickedHex.HexState.BackgroundColor = board.BoardState.ActiveHex.HexState.BackgroundColor;
                            board.BoardState.ActiveHex = clickedHex;
                            if (e.Button == MouseButtons.Right)
                            {
                                clickedHex.HexState.BackgroundColor = Color.Blue;
                            }
                        }
                    }
                  
				}

			}
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

		
		
	}
}