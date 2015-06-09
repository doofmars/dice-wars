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
        private HexagonalTest.DTOClass transferObject;
        private HexagonalTest.Fight fightForm;
		private Hexagonal.HexOrientation orientation;
		private System.Drawing.Color backgroundColor;
		private Hexagonal.BoardState boardState;
        private ArrayList players = new ArrayList();
        private int[,] textPosX; // MaHa
        private int[,] textPosY; // MaHa
		
        private float pixelWidth;
		private float pixelHeight;

        private static readonly int MAX_DICE = 9;
        private static readonly Random RANDOM = new Random();
        private List<int> fieldHelper;

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
        public Board(int width, int height, int side, Hexagonal.HexOrientation orientation, int xOffset, int yOffset, BoardState boardState, ArrayList players, HexagonalTest.DTOClass dataTransfer)
		{                                                    
			this.width = width;                              
			this.height = height;                            
			this.side = side;
            this.transferObject = dataTransfer;
               
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

            //Initalize, fill and shuffle field helper to give each player the same amount of fields on the start
            this.fieldHelper = new List<int>(width*height);
            int f = 0;
            while(f < fieldHelper.Capacity) 
            {
                for (int p = players.Count - 1; p >= 0 && f < fieldHelper.Capacity; p--)
                {
                    fieldHelper.Add(p);
                    f++;
                }
            }
            Math.Shuffle<int>(fieldHelper);

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

            // f = field number in 2D plane
            f = 0;
			// i = y coordinate (rows), j = x coordinate (columns) of the hex tiles 2D plane
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
                    Player player = getPlayerByID(fieldHelper[f]);
                    player.addField();
                    player.Dices += 1;
                    Hex current = new Hex(side, orientation, player.Color, j, i, 1);
                    f++;
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
            //Give players extra dices at the start.
            //Each player gets total number of fields minus his largest patch plus MAX_DICE
            foreach (Player player in players)
            {
                int largestPatch = findLargesPatchForPlayer(player);
                this.distributeDices(player, (width*height) - largestPatch + MAX_DICE);
            }
            Console.WriteLine(getStatus());		
		}

        /// <summary>
        /// Function to set the Active player to be the next player
        /// </summary>
        public void nextPlayer()
        {
            Player currentPlayer = this.getPlayerByID(this.boardState.ActivePlayer);
            int largestPatch = findLargesPatchForPlayer(currentPlayer);

            this.distributeDices(currentPlayer, largestPatch);
            Console.WriteLine("Dice to distribute: " + largestPatch);
            Console.WriteLine("Current Bank " + currentPlayer.Bank);

            boardState.ActivePlayer = nextActivePlayer(currentPlayer.ID);
        }

        /// <summary>
        /// Select next player and test if he still has fields
        /// Either return this player or select next one via recursion
        /// </summary>
        /// <param name="currentPlayerId">The current players id uses for recursion</param>
        /// <returns>the next player who still has fields</returns>
        private int nextActivePlayer(int currentPlayerId)
        {
            //next Player:
            if (currentPlayerId + 1 >= players.Count)
            {
                currentPlayerId = 0;
            }
            else
            {
                currentPlayerId = currentPlayerId + 1;
            }
            //termination condition for recursion, prevents stack overflow.
            if (currentPlayerId == boardState.ActivePlayer)
            {
                return boardState.ActivePlayer;
            }
            //test if player has fields or find next player recursive 
            if (getPlayerByID(currentPlayerId).Fields > 0)
            {
                return currentPlayerId;
            }
            else
            {
                return nextActivePlayer(currentPlayerId);
            }
        }

        /// <summary>
        /// Function to move 2/3 of the units from an hex to anoter
        /// From hex must be not null, not exhausted and neighbor of to
        /// </summary>
        /// <param name="from">Units to move from</param>
        /// <param name="to">Units to move to</param>
        public bool moveDices(Hex from, Hex to)
        {
            if (from == null || !from.IsNeighbor(to) || from.Exhausted)
            {
                Console.WriteLine("Move of units not possible");
                DiceLabels.GetInstance.changeGameLabel(from.HexState.BackgroundColor, "Can't move");
                return false;
            }
            if (from.Dices > 2)
            {
                int modulo = from.Dices % 3;
                int transfer = (int)((from.Dices - modulo) * (2.0/3.0));
                if (to.Dices + transfer > MAX_DICE)
                {
                    transfer = MAX_DICE - to.Dices;
                }
                from.Dices -= transfer;
                to.Dices += transfer;
                to.Exhausted = true;

                DiceLabels.GetInstance.changeGameLabel(from.HexState.BackgroundColor, "Dices moved");
                return false;
            }
            return true;
        }


        /// <summary>
        /// This function is triggered, when an player attacks another player
        /// </summary>
        /// <param name="attacker">the hex field where the attack has started</param>
        /// <param name="defender">the desination where the attack leads to</param>
        public void performAttack(Hex attacker, Hex defender)
        {
            Console.WriteLine("Attacker:" + attacker.Dices + " Defender:" + defender.Dices);
            if (attacker.Dices <= 1 || attacker.Exhausted) 
            {
                Console.WriteLine("Attack not possible");
                DiceLabels.GetInstance.changeGameLabel(attacker.HexState.BackgroundColor, "Not possibl");
                return;
            }
            Player attackerP = findPlayerByColor(attacker.HexState.BackgroundColor);
            Player defenderP = findPlayerByColor(defender.HexState.BackgroundColor);
            int attackerEyes = RandomGenerator.getInstance().rollTheDice(attacker.Dices);
            int defenderEyes = RandomGenerator.getInstance().rollTheDice(defender.Dices);

            //
            DiceLabels.GetInstance.changeGameLabel(attackerP.Color, defenderP.Color, attackerEyes, defenderEyes);
            //

            Console.WriteLine("Attacker Eyes:" + attackerEyes + " Defender Eyes:" + defenderEyes);
            if (true)//attackerEyes > defenderEyes
            {
                Console.WriteLine("Attacker won");
                defender.HexState.BackgroundColor = attacker.HexState.BackgroundColor;
                defenderP.Dices += ((defender.Dices) * -1);
                defender.Dices = attacker.Dices - 1;
                attacker.Dices = 1;
                attackerP.Fields += 1;
                defenderP.Fields -= 1;
                this.BoardState.ActiveHex = defender;

            }
            else
            {
                Console.WriteLine("Attacker lost");
                attackerP.Dices += ((attacker.Dices - 1) * -1);
                attacker.Dices = 1;
            }

            if (defenderP.Fields == 0)
            {
                //Triggered when player is defeated
                Console.WriteLine(defenderP.Color.Name + " has been defeated.");
            }
            if (attackerP.Fields == this.width * this.height)
            {
                //Triggered if player has won
                Console.WriteLine(attackerP.Color.Name + " has won.");
                HexagonalTest.GameOver gameOverForm = new HexagonalTest.GameOver(attackerP.Color.Name, transferObject);
                gameOverForm.Show();
                
                
            }
        }


        /// <summary>
        /// Get all fields as list for the player
        /// </summary>
        /// <param name="playerColor">The players color</param>
        /// <returns>The fields</returns>
        private ArrayList getFieldsForPlayer(Color playerColor)
        {
            ArrayList fields = new ArrayList();
            for (int x = 0; x < this.height; x++)
            {
                for (int y = 0; y < this.width; y++)
                {
                    Hex field = this.Hexes[x, y];
                    if (field.HexState.BackgroundColor == playerColor)
                    {
                        field.Exhausted = false; //reset exhausted state
                        fields.Add(field);
                    }
                }
            }
            return fields;
        }

        /// <summary>
        /// Finds the largest patch for the given player color
        /// </summary>
        /// <param name="player">The players</param>
        /// <returns>the size of the lagest patch</returns>
        public int findLargesPatchForPlayer(Player player)
        {
            int largestField = 0;
            ArrayList fields = getFieldsForPlayer(player.Color);
            while (fields.Count > 0)
            {
                ArrayList patch = getPatch((Hex)fields[0], new ArrayList());
                //test if larger
                if (largestField < patch.Count)
                {
                    largestField = patch.Count;
                }
                //strike out visited
                foreach (Hex patchHex in patch)
                {
                    foreach (Hex hex in fields)
                    { 
                        if (hex.Equals(patchHex))
                        {
                            //already visited
                            fields.Remove(patchHex);
                            break;
                            
                        }
                     }
                }
            }
            return largestField;
        }

        /// <summary>
        /// Function to get all connected hex fields
        /// </summary>
        /// <param name="hex">the starting hex</param>
        /// <param name="visited">for recursion, first call must be an empty arraylist</param>
        /// <returns>List of hexes that are connected containing the start hex</returns>
        public ArrayList getPatch(Hex hex, ArrayList visited)
        {
            visited.Add(hex);
            for (int x = -1; x <= 1; x++)
            {
                int yStart = -1;
                int yEnd = 1;
                if (hex.GridPositionY % 2 == 0)
                {
                    if (x == 1)
                    {
                        yStart = 0;
                        yEnd = 0;
                    }
                }
                else
                {
                    if (x == -1)
                    {
                        yStart = 0;
                        yEnd = 0;
                    }
                }
                for (int y = yStart; y <= yEnd; y++)
                {
                    if (!(x == 0 && y == 0) && !(hex.GridPositionX + x < 0 || hex.GridPositionX + x >= this.width || hex.GridPositionY + y < 0 || hex.GridPositionY + y >= this.height))
                    {
                        Hex neighbor = this.Hexes[(hex.GridPositionY + y), (hex.GridPositionX + x)];
                        if (neighbor.HexState.BackgroundColor == hex.HexState.BackgroundColor && !visited.Contains(neighbor)) 
                        {
                            visited = getPatch(neighbor, visited);
                        }
                    }
                }
            }
            return visited;
        }

        /// <summary>
        /// Function to give the given player new dices
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="dice">number of dices</param>
        private void distributeDices(Player player, int dice)
        {
            ArrayList fields = getFieldsForPlayer(player.Color);
            dice += player.Bank;

            while(fields.Count > 0 && dice > 0)
            {
                Hex randomHex = (Hex)fields[RANDOM.Next(fields.Count)];
                if (randomHex.Dices < MAX_DICE) 
                {
                    player.Dices += 1;
                    randomHex.Dices += 1;
                    dice -= 1;
                }
                else
                {
                    fields.Remove(randomHex);
                }
            }
            if (dice > 0)
            {
                player.Dices += dice;
                player.Bank = dice;
            }
        }

        /// <summary>
        /// Function to find a player by its id
        /// </summary>
        /// <param name="id">the players id</param>
        /// <returns>The Player</returns>
        private Player getPlayerByID(int id)
        {
            return (Player)this.players[id];
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
        /// Get the field distribution for every player as string
        /// </summary>
        /// <returns>A String</returns>
        public String getStatus()
        {
            String status = "";
            foreach (Player player in players)
            {
                if (player.Fields > 0)
                {
                    status += player.Color.Name + "=" + player.Fields + "(" + player.Dices + ")     ";
                }
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
