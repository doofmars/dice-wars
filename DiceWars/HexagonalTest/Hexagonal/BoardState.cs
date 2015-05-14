using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Hexagonal
{
	public class BoardState
	{
		private System.Drawing.Color backgroundColor;
		private System.Drawing.Color gridColor;
		private int gridPenWidth;
		private Hexagonal.Hex activeHex;
		private System.Drawing.Color activeHexBorderColor;
		private int activeHexBorderWidth;
        private int activePlayer;

		#region Properties

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

		public System.Drawing.Color GridColor
		{
			get
			{
				return gridColor;
			}
			set
			{
				gridColor = value;
			}
		}

		public int GridPenWidth
		{
			get
			{
				return gridPenWidth;
			}
			set
			{
				gridPenWidth = value;
			}
		}

		public Hexagonal.Hex ActiveHex
		{
			get
			{
				return activeHex;
			}
			set
			{
				activeHex = value;
			}
		}

		public System.Drawing.Color ActiveHexBorderColor
		{
			get
			{
				return activeHexBorderColor;
			}
			set
			{
				activeHexBorderColor = value;
			}
		}

        public int ActiveHexBorderWidth
        {
            get
            {
                return activeHexBorderWidth;
            }
            set
            {
                activeHexBorderWidth = value;
            }
        }

        public int ActivePlayer
        {
            get
            {
                return activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
		#endregion

        public BoardState(Color backgroundColor, Color gridColor, int gridPenWidth, Color activeHexBorderColor, int activeHexBorderWidth)
		{
            this.backgroundColor = backgroundColor;
            this.gridColor = gridColor;
            this.gridPenWidth = gridPenWidth;
			this.activeHex = null;
            this.activeHexBorderColor = activeHexBorderColor;
            this.activeHexBorderWidth = activeHexBorderWidth;
		}


	}
}
