using System;
using System.Collections.Generic;
using System.Text;
using Hexagonal;



namespace HexagonalTest
{   
	class Program
	{
        
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [System.Runtime.InteropServices.DllImportAttribute("kernel32")]
        public static extern IntPtr GetConsoleWindow();
        [System.Runtime.InteropServices.DllImportAttribute("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
		static void Main(string[] args)
		{
            IntPtr hConsole = GetConsoleWindow();
            if (IntPtr.Zero != hConsole)
            {
                ShowWindow(hConsole, 0);
            }
			Console.WriteLine("Starting Form...");
            RandomGenerator.getInstance().initialize();
            System.Windows.Forms.Application.Run(new HexagonalTest.MainWIndow());            
		}
	}
}
