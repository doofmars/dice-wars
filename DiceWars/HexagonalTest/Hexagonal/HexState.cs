using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Hexagonal
{
	public class HexState
	{
		private System.Drawing.Color backgroundColor;
		

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


		public HexState(Color color)
		{
            this.backgroundColor = color;
		}

	}
}
