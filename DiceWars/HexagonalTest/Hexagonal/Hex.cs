using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Hexagonal
{
	public class Hex
	{
		private System.Drawing.PointF[] points;
		private float side;
		private float h;
		private float r;
		private Hexagonal.HexOrientation orientation;
		// MaHa 
        private int tmpX;
        private int tmpY;
        //
        private float x;
		private float y;
        private int gridPosX;
        private int gridPosY;
		private HexState hexState;
        private int dices;
	
        /// <summary>
        /// Constructor to initalize the Hexagon with the fixed values
        /// </summary>
        /// <param name="side">Hexagon side length</param>
        /// <param name="orientation">Orientation of the hexagons</param>
        /// <param name="playerColor">The players color</param>
        /// <param name="posX">The X position in the grid</param>
        /// <param name="posY">The Y position in the grid</param>
        /// <param name="dices">Number of dices on this Hex</param>
        public Hex(float side, Hexagonal.HexOrientation orientation, Color playerColor, int posX, int posY, int dices)
        {
            this.side = side;
            this.orientation = orientation;
            this.hexState = new HexState(playerColor);
            this.dices = dices;
            

            //The IsNeigbour relys on the gridPosition
            if (orientation == Hexagonal.HexOrientation.Pointy) {
                this.gridPosX = posX;
                this.gridPosY = posY;
            }
            else
            {
                this.gridPosX = posY;
                this.gridPosY = posX;
            }
        }

        public void Initialize(PointF point)
		{
            Initialize(point.X, point.Y);
		}

		/// <summary>
		/// Sets internal fields and calls CalculateVertices()
		/// </summary>
        public void Initialize(float x, float y)
		{
			this.x = x;
			this.y = y;
            this.tmpX = (int)x;
            this.tmpY = (int)y;
            
			CalculateVertices();
		}

		/// <summary>
		/// Calculates the vertices of the hex based on orientation. Assumes that points[0] contains a value.
		/// </summary>
		private void CalculateVertices()
		{
			//  
			//  h = short length (outside)
			//  r = long length (outside)
			//  side = length of a side of the hexagon, all 6 are equal length
			//
			//  h = sin (30 degrees) x side
			//  r = cos (30 degrees) x side
			//
			//		 h
			//	     ---
			//   ----     |r
			//  /    \    |          
			// /      \   |
			// \      /
			//  \____/
			//
			// Flat orientation (scale is off)
			//
	        //     /\
			//    /  \
			//   /    \
			//   |    |
			//   |    |
			//   |    |
			//   \    /
			//    \  /
			//     \/
			// Pointy orientation (scale is off)
         
			h = Hexagonal.Math.CalculateH(side);
			r = Hexagonal.Math.CalculateR(side);

			switch (orientation)
			{ 
				case Hexagonal.HexOrientation.Flat:
					// x,y coordinates are top left point
					points = new System.Drawing.PointF[6];
					points[0] = new PointF(x, y);
					points[1] = new PointF(x + side, y);
					points[2] = new PointF(x + side + h, y + r);
					points[3] = new PointF(x + side, y + r + r);
					points[4] = new PointF(x, y + r + r);
					points[5] = new PointF(x - h, y + r );
					break;
				case Hexagonal.HexOrientation.Pointy:
					//x,y coordinates are top center point
					points = new System.Drawing.PointF[6];
					points[0] = new PointF(x, y);
					points[1] = new PointF(x + r, y + h);
					points[2] = new PointF(x + r, y + side + h);
					points[3] = new PointF(x, y + side + h + h);
					points[4] = new PointF(x - r, y + side + h);
					points[5] = new PointF(x - r, y + h);
					break;
				default:
					throw new Exception("No HexOrientation defined for Hex object.");
			
			}
			
		}

        /// <summary>
        /// Determines if that Hex is the neighbor of this Hex
		/// </summary>
        public Boolean IsNeighbor(Hex that)
        {
            if(that == null || this.Equals(that)){
                return false;
            }
            //Left or right of target
            if (this.GridPositionY == that.GridPositionY && (this.GridPositionX == that.GridPositionX + 1 || this.GridPositionX == that.GridPositionX - 1))
            {
                return true;
            }
            //Diagonal
            if (this.GridPositionX == that.GridPositionX && (this.GridPositionY == that.GridPositionY + 1 || this.GridPositionY == that.GridPositionY - 1))
            {
                return true;
            }
            //Diagonal the other way, depends on the GridPositionY
            if (this.GridPositionY % 2 == 0)
            {
                if (this.GridPositionX == that.GridPositionX +1 && (this.GridPositionY == that.GridPositionY + 1 || this.GridPositionY == that.GridPositionY - 1))
                {
                    return true;
                }
            }
            else
            {
                if (this.GridPositionX == that.GridPositionX - 1 && (this.GridPositionY == that.GridPositionY + 1 || this.GridPositionY == that.GridPositionY - 1))
                {
                    return true;
                }
            }
            return false;
        }

		public Hexagonal.HexOrientation Orientation
		{
			get
			{
				return orientation;
			}
			set
			{
				orientation = value;
			}
		}

		public System.Drawing.PointF[] Points
		{
			get
			{
				return points;
			}
			set
			{
			}
		}

		public float Side
		{
			get
			{
				return side;
			}
			set
			{
			}
		}

		public float H
		{
			get
			{
				return h;
			}
			set
			{
			}
		}

        public int Dices
        {
            get
            {
                return dices;
            }
            set
            {
                dices = value;
            }
        }

		public float R
		{
			get
			{
				return r;
			}
			set
			{
			}
		}

        public int GridPositionX
        {
            get
            {
                return gridPosX;
            }
            set
            {
                gridPosX = value;
            }
        }

        public int GridPositionY
        {
            get
            {
                return gridPosY;
            }
            set
            {
                gridPosY = value;
            }
        }

        // MaHa
        public int TmpX
        {
            get
            {
                return tmpX;
            }
        }

        // MaHa
        public int TmpY
        {
            get
            {
                return tmpY;
            }
        }

		public Hexagonal.HexState HexState
		{
			get
			{
				return hexState;
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

        public override string ToString()
        {
            return "Hexagon[ x=" + gridPosX + ", y=" + gridPosY + "]";
        }

        public override int GetHashCode()
        {
            return 1337;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                return false;
            }

            if (this.GetType() != obj.GetType()) 
            {
                return false;
            }

            Hex that = (Hex)obj;

            if (this.side == that.side && 
                this.h == that.h && 
                this.r == that.r && 
                this.orientation == that.orientation && 
                this.x == that.x && 
                this.y == that.y &&
                this.gridPosX == that.gridPosX &&
                this.gridPosY == that.gridPosY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


	}
}
