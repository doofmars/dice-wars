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


		public HexState()
		{
            Random rnd = new Random();
            int colorId = rnd.Next(0, 4);// creates a number between 0 and 3
            switch (colorId) {
                case 0:
                    this.backgroundColor = Color.Red;
                    break;
                case 1:
                    this.backgroundColor = Color.Blue;
                    break;
                case 2:
                    this.backgroundColor = Color.Yellow;
                    break;
                case 3:
                    this.backgroundColor = Color.Green;
                    break;
                default:
                this.backgroundColor = Color.White;
                break;
            }
			
		}

	}
}
