using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
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
        private static readonly Random RANDOM = new Random();
        private int[,] textPosX; // MaHa
        private int[,] textPosY; // MaHa



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

            textPosX = new int[height, width]; // MaHa
            textPosY = new int[height, width]; // MaHa

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
                    Hex current = new Hex(side, orientation, randomPlayer.Color, j, i, 5);
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
                                current.Initialize(0 + h + xOffset, 0 + yOffset);
								hexes[0, 0] = current;
								break;
							case HexOrientation.Pointy:
                                current.Initialize(0 + r + xOffset, 0 + yOffset);
                                hexes[0, 0] = current;

                                // MaHa
                                textPosX[0, 0] = 0 + (int)r + xOffset;
                                textPosY[0, 0] = 0 + yOffset;

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
                                    current.Initialize(hexes[i - 1, j].Points[(int)Hexagonal.FlatVertice.BottomLeft]);
									hexes[i, j] = current;
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
                                        current.Initialize(x, y);
                                        hexes[i, j] = current;
									}
									else
									{
										// Calculate from Hex to left's Middle Right Vertice
                                        current.Initialize(hexes[i, j - 1].Points[(int)Hexagonal.FlatVertice.MiddleRight]);
                                        hexes[i, j] = current;
									}
								}
								break;
							case HexOrientation.Pointy:
								if (inLeftColumn)
								{
									// Calculate from hex above and need to stagger the rows
									if (i % 2 == 0)
									{
                                        current.Initialize(hexes[i - 1, j].Points[(int)Hexagonal.PointyVertice.BottomLeft]);
                                        hexes[i, j] = current;
                                        // MaHa
                                        int tmpX = hexes[i, j].TmpX;
                                        int tmpY = hexes[i, j].TmpY;
                                        textPosX[i, j] = tmpX;
                                        textPosY[i, j] = tmpY;
									}
									else
									{
                                        current.Initialize(hexes[i - 1, j].Points[(int)Hexagonal.PointyVertice.BottomRight]);
                                        hexes[i, j] = current;
                                        
                                        // MaHa
                                        int tmpX = hexes[i, j].TmpX;
                                        int tmpY = hexes[i, j].TmpY;
                                        textPosX[i, j] = tmpX;
                                        textPosY[i, j] = tmpY;
									}

								}
								else
								{
									// Calculate from Hex to the left
									float x = hexes[i, j - 1].Points[(int)Hexagonal.PointyVertice.UpperRight].X;
									float y = hexes[i, j - 1].Points[(int)Hexagonal.PointyVertice.UpperRight].Y;
									x += r;
									y -= h;
                                    current.Initialize(x, y);
                                    hexes[i, j] = current;	

                                    // MaHa
                                    textPosX[i, j] = (int)x;
                                    textPosY[i, j] = (int)y;
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
            Player candidate = (Player)players[RANDOM.Next(0, players.Count)];
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
        public Color getCurrentPlayerColor()
        {
            return ((Player)this.players[this.boardState.ActivePlayer]).Color;
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
                if (player.Color == color)
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
            Console.WriteLine("Attacker:" + attacker.Dices + " Defender:" + defender.Dices);
            if (attacker.Dices <= 1) 
            {
                Console.WriteLine("Attack not possible");
                return;
            }
            Player attackerP = findPlayerByColor(attacker.HexState.BackgroundColor);
            Player defenderP = findPlayerByColor(defender.HexState.BackgroundColor);
            int attackerEyes = rollTheDice(attacker.Dices);
            int defenderEyes = rollTheDice(attacker.Dices);

            Console.WriteLine("Attacker Eyes:" + attackerEyes + " Defender Eyes:" + defenderEyes);
            if (attackerEyes > defenderEyes)
            {
                Console.WriteLine("Attacker won");
                defender.Dices = attacker.Dices - 1;
                attacker.Dices = 1;
                attackerP.Fields += 1;
                defenderP.Fields -= 1;
                defender.HexState.BackgroundColor = attacker.HexState.BackgroundColor;
                this.BoardState.ActiveHex = defender;

                //MaHa
                DiceLabels.GetInstance.changeLabel(attacker.GridPositionY, attacker.GridPositionX, 1);
                DiceLabels.GetInstance.changeLabel(defender.GridPositionY, defender.GridPositionX, defender.Dices, attacker.HexState.BackgroundColor);
                //

            }
            else
            {
                Console.WriteLine("Attacker lost");
                attacker.Dices = 1;
                //MaHa
                DiceLabels.GetInstance.changeLabel(attacker.GridPositionY, attacker.GridPositionX, attacker.Dices);
                //
            }

            if (defenderP.Fields == 0)
            {
                //Triggered when player is defeated
                Console.WriteLine(defenderP.Color.Name + " has been defeated.");
            }
            if (attackerP.Fields == this.width * this.height)
            {
                //Triggered if player has won
                Console.WriteLine(defenderP.Color.Name + " has won.");
            }
        }

        private int rollTheDice(int dices)
        {
            if (dices > 1)
            {
                return rollTheDice(dices - 1) + RANDOM.Next(1, 7);
            }
            else
            {
                return 0;
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
                status += player.Color.Name + "=" + player.Fields + "     ";
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
        public int[,] TextPosX 
        {
            get
            {
                return this.textPosX;
            }
        }

        public int[,] TextPosY
        {
            get
            {
                return this.textPosY;
            }
        }
	}


    


}
