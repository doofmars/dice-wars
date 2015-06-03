using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace HexagonalTest.Datenbank
{
    class SqliteDatabase
    {
        string pathOfProject  = System.IO.Directory.GetCurrentDirectory();
        private SQLiteConnection connector;
        private SQLiteCommand query;
        private SQLiteDataReader reader;
        private List<List<string>> dataFromDB;
 
        public void connectDB()
        {
            connector = new SQLiteConnection("Data Source=MyDatabase.sqlite");
            connector.Open();
            query = new SQLiteCommand(connector);

            query.CommandText = "CREATE TABLE IF NOT EXISTS GameData (id INTEGER PRIMARY KEY, name TEXT, timePlayed TEXT, enemies INT, sizeOfField TEXT);";
            query.ExecuteNonQuery();
            
            //query.Dispose(); 
        }


        public List<List<string>> getData()
        {
            query.CommandText = "SELECT * FROM GameData ORDER BY id;";
            reader = query.ExecuteReader();
            dataFromDB = new List<List<string>>();
            
            int i = 0;

            if(reader.HasRows)
            while(reader.Read()){

                dataFromDB.Add(new List<string>());
                string name = reader.GetString(reader.GetOrdinal("name"));
                string time = reader.GetString(reader.GetOrdinal("timePlayed"));
                string enemies = reader.GetValue(reader.GetOrdinal("enemies")).ToString();
                string size = reader.GetString(reader.GetOrdinal("sizeOfField"));

                dataFromDB[i].Add(name);
                dataFromDB[i].Add(time);
                dataFromDB[i].Add(enemies);
                dataFromDB[i].Add(size);

             
                i++;
            }
            return dataFromDB;
        }

        public void writeData( string name, string timeplayed, int enemies, string sizeOfField)
        {
            query.CommandText = "INSERT INTO GameData (id, name, timePlayed, enemies, sizeOfField) VALUES(null" + ", '" + name + "', '" + timeplayed + "', " + enemies + ", '" + sizeOfField + "');";
            query.ExecuteNonQuery();
            //query.Dispose();
        }
        public void closeDatabase()
        {
            connector.Close();
            connector.Dispose();
        }

    }
}
