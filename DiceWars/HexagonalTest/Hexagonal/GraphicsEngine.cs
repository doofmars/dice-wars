using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hexagonal
{
	public class GraphicsEngine
	{
		private Hexagonal.Board board;
		private int boardXOffset;
		private int boardYOffset;
	
		public GraphicsEngine(Hexagonal.Board board)
		{
			this.Initialize(board, 0, 0);
		}

		public GraphicsEngine(Hexagonal.Board board, int xOffset, int yOffset)
		{
			this.Initialize(board, xOffset, yOffset);
		}

		public int BoardXOffset
		{
			get
			{
				return boardXOffset;
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		public int BoardYOffset
		{
			get
			{
				return boardYOffset;
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}
		
		private void Initialize(Hexagonal.Board board, int xOffset, int yOffset)
		{
			this.board = board;
			this.boardXOffset = xOffset;
			this.boardYOffset = yOffset;
		}

		public void Draw(Graphics graphics)
		{ 
		
			int width =  Convert.ToInt32(System.Math.Ceiling(board.PixelWidth));
			int height = Convert.ToInt32(System.Math.Ceiling(board.PixelHeight));
			// seems to be needed to avoid bottom and right from being chopped off
			width += 1;
			height += 1;

			//
			// Create drawing objects
			//
			Bitmap bitmap = new Bitmap(width, height);
			Graphics bitmapGraphics = Graphics.FromImage(bitmap);
			Pen p = new Pen(Color.Black);
			SolidBrush sb = new SolidBrush(Color.Black);

			
			//
			// Draw Board background
			//
			sb = new SolidBrush(board.BoardState.BackgroundColor);
			bitmapGraphics.FillRectangle(sb, 0, 0, width, height);

			//
			// Draw Hex Background 
			//
			for (int i = 0; i < board.Hexes.GetLength(0); i++)
			{
				for (int j = 0; j < board.Hexes.GetLength(1); j++)
				{
					//bitmapGraphics.DrawPolygon(p, board.Hexes[i, j].Points);
					bitmapGraphics.FillPolygon(new SolidBrush(board.Hexes[i,j].HexState.BackgroundColor), board.Hexes[i, j].Points);
				}
			}

			
			//
			// Draw Hex Grid
			//
			p.Color = board.BoardState.GridColor;
			p.Width = board.BoardState.GridPenWidth;
			for (int i = 0; i < board.Hexes.GetLength(0); i++)
			{
				for (int j = 0; j < board.Hexes.GetLength(1); j++)
				{
					bitmapGraphics.DrawPolygon(p, board.Hexes[i, j].Points);
				}
			}

			//
			// Draw Active Hex, if present
			//
			if (board.BoardState.ActiveHex != null)
			{
				p.Color = board.BoardState.ActiveHexBorderColor;
				p.Width = board.BoardState.ActiveHexBorderWidth;
				bitmapGraphics.DrawPolygon(p, board.BoardState.ActiveHex.Points);
			}

			//
			// Draw internal bitmap to screen
			//
			graphics.DrawImage(bitmap, new Point(this.boardXOffset , this.boardYOffset));
			
			//
			// Release objects
			//
			bitmapGraphics.Dispose();
			bitmap.Dispose();

		}

	}
}
