using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;

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
		private Hexagonal.HexOrientation orientation;
		private System.Drawing.Color backgroundColor;
		private Hexagonal.BoardState boardState;
        private ArrayList players = new ArrayList();

		private float pixelWidth;
		private float pixelHeight;

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

        /// <param name="width">Board width</param>
        /// <param name="height">Board height</param>
        /// <param name="side">Hexagon side length</param>
        /// <param name="orientation">Orientation of the hexagons</param>
        /// <param name="xOffset">X coordinate offset</param>
        /// <param name="yOffset">Y coordinate offset</param>
        public Board(int width, int height, int side, Hexagonal.HexOrientation orientation, int xOffset, int yOffset, BoardState boardState, ArrayList players)
		{                                                    
			this.width = width;                              
			this.height = height;                            
			this.side = side;                                
			this.orientation = orientation;                  
			this.xOffset = xOffset;
			this.yOffset = yOffset;
            this.boardState = boardState;
            this.players = players;
			hexes = new Hex[height, width]; //opposite of what we'd expect

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
                    Player randomPlayer = getRandomPlayer();
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
								hexes[0, 0] = new Hex(0 + h + xOffset, 0 + yOffset, side, orientation, randomPlayer, 0, 0);
								break;
							case HexOrientation.Pointy:
                                hexes[0, 0] = new Hex(0 + r + xOffset, 0 + yOffset, side, orientation, randomPlayer, 0, 0);
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
									hexes[i, j] = new Hex(hexes[i - 1, j].Points[(int)Hexagonal.FlatVertice.BottomLeft], side, orientation, randomPlayer, j, i);
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
                                        hexes[i, j] = new Hex(x, y, side, orientation, randomPlayer, j, i);
									}
									else
									{
										// Calculate from Hex to left's Middle Right Vertice
                                        hexes[i, j] = new Hex(hexes[i, j - 1].Points[(int)Hexagonal.FlatVertice.MiddleRight], side, orientation, randomPlayer, j, i);
									}
								}
								break;
							case HexOrientation.Pointy:
								if (inLeftColumn)
								{
									// Calculate from hex above and need to stagger the rows
									if (i % 2 == 0)
									{
                                        hexes[i, j] = new Hex(hexes[i - 1, j].Points[(int)Hexagonal.PointyVertice.BottomLeft], side, orientation, randomPlayer, j, i);
									}
									else
									{
                                        hexes[i, j] = new Hex(hexes[i - 1, j].Points[(int)Hexagonal.PointyVertice.BottomRight], side, orientation, randomPlayer, j, i);
									}

								}
								else
								{
									// Calculate from Hex to the left
									float x = hexes[i, j - 1].Points[(int)Hexagonal.PointyVertice.UpperRight].X;
									float y = hexes[i, j - 1].Points[(int)Hexagonal.PointyVertice.UpperRight].Y;
									x += r;
									y -= h;
                                    hexes[i, j] = new Hex(x, y, side, orientation, randomPlayer, j, i);	
								}
								break;
							default:
								break;
						}


					}


				}
			}

            Console.WriteLine(getStatus());
			
		}

        /// This function is pretty nasty because the default c# random function cant provide enough entropy
        private Player getRandomPlayer()
        {
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] data = new byte[8];
            rng.GetBytes(data);
            ulong randomValue = BitConverter.ToUInt64(data, 0);
            int index = (int)(randomValue % (ulong)this.players.Count);
            Player candidate = (Player)this.players[index];
            candidate.addField();
            return candidate;
        }

        /// <summary>
        /// Function to set the Active player to be the next player
        /// </summary>
        public void nextPlayer()
        {
            int currentPlayer = this.boardState.ActivePlayer;
            if (currentPlayer + 1 >= players.Count)
            {
                boardState.ActivePlayer = 0;
            }
            else
            {
                boardState.ActivePlayer = currentPlayer + 1;
            }
        }

        /// <summary>
        /// Function to get the color of the ActivePlayer
        /// </summary>
        /// <returns>A Color</returns>
        public Color getCurrentPlayerColour()
        {
            return ((Player)this.players[this.boardState.ActivePlayer]).Colour;
        }

        /// <summary>
        /// Function to find a player by its color
        /// </summary>
        /// <param name="color">The color of the player</param>
        /// <returns>The player object</returns>
        private Player findPlayerByColor(Color color)
        {
            foreach (Player player in players)
            {
                if (player.Colour == color)
                {
                    return player;
                }
            }
            throw new ArgumentException("This should never have happend and I'm really sorry");
        }

        /// <summary>
        /// This function is triggered, when an player attacks another player
        /// </summary>
        /// <param name="attacker">the hex field where the attack has started</param>
        /// <param name="defender">the desination where the attack leads to</param>
        public void performAttack(Hex attacker, Hex defender)
        {
            Player attackerP = findPlayerByColor(attacker.HexState.BackgroundColor);
            Player defenderP = findPlayerByColor(defender.HexState.BackgroundColor);

            defender.HexState.BackgroundColor = attacker.HexState.BackgroundColor;
            this.BoardState.ActiveHex = defender;
            attackerP.Fields += 1;
            defenderP.Fields -= 1;

            if (defenderP.Fields == 0)
            {
                Console.WriteLine(defenderP.Colour.Name + " has been defeated.");
            }
            if (attackerP.Fields == this.width * this.height)
            {
                Console.WriteLine(defenderP.Colour.Name + " has won.");
            }
        }

        /// <summary>
        /// Get the field distribution for every player as string
        /// </summary>
        /// <returns>A String</returns>
        public String getStatus()
        {
            String status = "";
            foreach (Player player in players)
            {
                status += player.Colour.Name + "=" + player.Fields + "     ";
            }
            return status;
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
