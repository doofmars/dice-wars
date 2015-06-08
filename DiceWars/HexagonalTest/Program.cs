using System;
using System.Collections.Generic;
using System.Text;
using Hexagonal;


namespace HexagonalTest
{   
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting Form...");
			//System.Windows.Forms.Application.Run(new HexagonalTest.TestForm() );
            System.Windows.Forms.Application.Run(new HexagonalTest.MainWIndow());            
		}
	}
}
