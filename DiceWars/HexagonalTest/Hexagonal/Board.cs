using System;
using System.Collections.Generic;
using System.Text;

namespace Hexagonal
{
	/// <summary>
	/// Represents a 2D hexagon board
	/// </summary>
	public class Board
	{
		private Hexagonal.Hex[,] hexes;
		private int width;
		private int height;
		private int xOffset;
		private int yOffset;
		private int side;
		private float pixelWidth;
		private float pixelHeight;
		private Hexagonal.HexOrientation orientation;
		private System.Drawing.Color backgroundColor;
		private Hexagonal.BoardState boardState;
		/// <param name="width">Board width</param>
		/// <param name="height">Board height</param>
		/// <param name="side">Hexagon side length</param>
		/// <param name="orientation">Orientation of the hexagons</param>
		public Board(int width, int height, int side, Hexagonal.HexOrientation orientation)
		{
			Initialize(width, height, side, orientation, 0, 0);
		}

		/// <param name="width">Board width</param>
		/// <param name="height">Board height</param>
		/// <param name="side">Hexagon side length</param>
		/// <param name="orientation">Orientation of the hexagons</param>
		/// <param name="xOffset">X coordinate offset</param>
		/// <param name="yOffset">Y coordinate offset</param>
		public Board(int width, int height, int side, Hexagonal.HexOrientation orientation, int xOffset, int yOffset)
		{
			Initialize(width, height, side, orientation, xOffset, yOffset);
		}

		#region Properties

		public Hexagonal.Hex[,] Hexes
		{
			get
			{
				return hexes;
			}
			set
			{
			}
		}

		public float PixelWidth
		{
			get
			{
				return pixelWidth;
			}
			set
			{
			}
		}

		public float PixelHeight
		{
			get
			{
				return pixelHeight;
			}
			set
			{
			}
		}

		public int XOffset
		{
			get
			{
				return xOffset;
			}
			set
			{
			}
		}

		public int YOffset
		{
			get
			{
				return xOffset;
			}
			set
			{
			}
		}

		public int Width
		{
			get
			{
				return width;
			}
			set
			{
			}
		}

		public int Height
		{
			get
			{
				return height;
			}
			set
			{
			}
		}

		public System.Drawing.Color BackgroundColor
		{
			get
			{
				return backgroundColor;
			}
			set
			{
				backgroundColor = value;
			}
		}

		public Hexagonal.BoardState BoardState
		{
			get
			{
				return boardState;
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		#endregion 

		/// <summary>
		/// Sets internal fields and creates board
		/// </summary>
		/// <param name="width">Board width</param>
		/// <param name="height">Board height</param>
		/// <param name="side">Hexagon side length</param>
		/// <param name="orientation">Orientation of the hexagons</param>
		/// <param name="xOffset">X coordinate offset</param>
		/// <param name="yOffset">Y coordinate offset</param>
		
		private void Initialize(int width, int height, int side, Hexagonal.HexOrientation orientation, int xOffset, int yOffset)
		{
			this.width = width;
			this.height = height;
			this.xOffset = xOffset;
			this.yOffset = yOffset;
			this.side = side;
			this.orientation = orientation;
			hexes = new Hex[height, width]; //opposite of what we'd expect
			this.boardState = new BoardState();

			float h = Hexagonal.Math.CalculateH(side); // short side
			float r = Hexagonal.Math.CalculateR(side); // long side

			//
			// Calculate pixel info..remove?
			// because of staggering, need to add an extra r/h
			float hexWidth = 0;
			float hexHeight = 0;
			switch (orientation)
			{
				case HexOrientation.Flat:
					hexWidth = side + h;
					hexHeight = r + r;
					this.pixelWidth = (width * hexWidth) + h;
					this.pixelHeight = (height * hexHeight) + r;
					break;
				case HexOrientation.Pointy:
					hexWidth = r + r;
					hexHeight = side + h;
					this.pixelWidth = (width * hexWidth) + r;
					this.pixelHeight = (height * hexHeight) + h;
					break;
				default:
					break;
			}


			bool inTopRow = false;
			bool inBottomRow = false;
			bool inLeftColumn = false;
			bool inRightColumn = false;
			bool isTopLeft = false;
			bool isTopRight = false;
			bool isBotomLeft = false;
			bool isBottomRight = false;


			// i = y coordinate (rows), j = x coordinate (columns) of the hex tiles 2D plane
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					// Set position booleans
					#region Position Booleans
						if (i == 0)
						{
							inTopRow = true;
						}
						else
						{
							inTopRow = false;
						}

						if (i == height - 1)
						{
							inBottomRow = true;
						}
						else
						{
							inBottomRow = false;
						}

						if (j == 0)
						{
							inLeftColumn = true;
						}
						else
						{
							inLeftColumn = false;
						}

						if (j == width - 1)
						{
							inRightColumn = true;
						}
						else
						{
							inRightColumn = false;
						}

						if (inTopRow && inLeftColumn)
						{
							isTopLeft = true;
						}
						else
						{
							isTopLeft = false;
						}

						if (inTopRow && inRightColumn)
						{
							isTopRight = true;
						}
						else
						{
							isTopRight = false;
						}

						if (inBottomRow && inLeftColumn)
						{
							isBotomLeft = true;
						}
						else
						{
							isBotomLeft = false;
						}

						if (inBottomRow && inRightColumn)
						{
							isBottomRight = true;
						}
						else
						{
							isBottomRight = false;
						}
						#endregion

					//
					// Calculate Hex positions
					//
					if (isTopLeft)
					{
						//First hex
						switch (orientation)
						{ 
							case HexOrientation.Flat:
								hexes[0, 0] = new Hex(0 + h + xOffset, 0 + yOffset, side, orientation);
								break;
							case HexOrientation.Pointy:
								hexes[0, 0] = new Hex(0 + r + xOffset, 0 + yOffset, side, orientation);
								break;
							default:
								break;
						}

							

					}
					else
					{
						switch (orientation)
						{
							case HexOrientation.Flat:
								if (inLeftColumn)
								{
									// Calculate from hex above
									hexes[i, j] = new Hex(hexes[i - 1, j].Points[(int)Hexagonal.FlatVertice.BottomLeft], side, orientation);
								}
								else
								{
									// Calculate from Hex to the left and need to stagger the columns
									if (j % 2 == 0)
									{
										// Calculate from Hex to left's Upper Right Vertice plus h and R offset 
										float x = hexes[i, j - 1].Points[(int)Hexagonal.FlatVertice.UpperRight].X;
										float y = hexes[i, j - 1].Points[(int)Hexagonal.FlatVertice.UpperRight].Y;
										x += h;
										y -= r;
										hexes[i, j] = new Hex(x, y, side, orientation);
									}
									else
									{
										// Calculate from Hex to left's Middle Right Vertice
										hexes[i, j] = new Hex(hexes[i, j - 1].Points[(int)Hexagonal.FlatVertice.MiddleRight], side, orientation);
									}
								}
								break;
							case HexOrientation.Pointy:
								if (inLeftColumn)
								{
									// Calculate from hex above and need to stagger the rows
									if (i % 2 == 0)
									{
										hexes[i, j] = new Hex(hexes[i - 1, j].Points[(int)Hexagonal.PointyVertice.BottomLeft], side, orientation);
									}
									else
									{
										hexes[i, j] = new Hex(hexes[i - 1, j].Points[(int)Hexagonal.PointyVertice.BottomRight], side, orientation);
									}

								}
								else
								{
									// Calculate from Hex to the left
									float x = hexes[i, j - 1].Points[(int)Hexagonal.PointyVertice.UpperRight].X;
									float y = hexes[i, j - 1].Points[(int)Hexagonal.PointyVertice.UpperRight].Y;
									x += r;
									y -= h;
									hexes[i, j] = new Hex(x, y, side, orientation);	
								}
								break;
							default:
								break;
						}


					}


				}
			}


			
		}

		public bool PointInBoardRectangle(System.Drawing.Point point)
		{
			return PointInBoardRectangle(point.X,point.Y);
		}

		public bool PointInBoardRectangle(int x, int y)
		{
			//
			// Quick check to see if X,Y coordinate is even in the bounding rectangle of the board.
			// Can produce a false positive because of the staggerring effect of hexes around the edge
			// of the board, but can be used to rule out an x,y point.
			//
			int topLeftX = 0 + XOffset;
			int topLeftY = 0 + yOffset;
			float bottomRightX = topLeftX + pixelWidth;
			float bottomRightY = topLeftY + PixelHeight;


			if (x > topLeftX && x < bottomRightX && y > topLeftY && y < bottomRightY)
			{
				return true;
			}
			else 
			{
				return false;
			}

		}

		public Hex FindHexMouseClick(System.Drawing.Point point)
		{
			return FindHexMouseClick(point.X,point.Y);
		}

		public Hex FindHexMouseClick(int x, int y)
		{
			Hex target = null;

			if (PointInBoardRectangle(x, y))
			{
				for (int i = 0; i < hexes.GetLength(0); i++)
				{
					for (int j = 0; j < hexes.GetLength(1); j++)
					{
						if (Math.InsidePolygon(hexes[i, j].Points, 6, new System.Drawing.PointF(x, y)))
						{
							target = hexes[i, j];
							break;
						}
					}

					if (target != null)
					{
						break;
					}
				}

			}
			
			return target;
			
		}

		

	}
}
