using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace HexagonalTest.Hexagonal
{
    class Database
    {
        private static Database instance = null;
        private static readonly object padlock = new object();

        Database()
        {

        }

        public static Database Instance
        {
            get
            {
                lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }
    }
        
    }

        
       
    

}
