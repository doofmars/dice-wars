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
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] data = new byte[8];
            rng.GetBytes(data);
            ulong value = BitConverter.ToUInt64(data, 0);

            Random rnd = new Random();
            int colorId = rnd.Next(0, 8);// creates a number between 0 and 7
            switch (value % 4)
            {
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
            Console.WriteLine(backgroundColor);
			
		}

	}
}
