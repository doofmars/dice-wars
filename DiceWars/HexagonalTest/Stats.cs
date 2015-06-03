using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HexagonalTest
{
    public partial class Stats : Form
    {
        public Stats()
        {
            
            InitializeComponent();
           
            List<List<string>> dbData = new List<List<string>>();
            Datenbank.SqliteDatabase database = new Datenbank.SqliteDatabase();
            database.connectDB();
            dbData = database.getData();

            //The list is empty so no data is in the database
            if (dbData.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("Database is empty!");
                Close();
            }
            // the normal way... read data from database
            else
            {
                //go through the database content. the data is saved in a 2D List. The data is (name of winner, played time, count enemys, board size)
                for(int i = 0 ; i < dbData.Count; i++){
                    tableLayoutPanelDatabase.RowCount = tableLayoutPanelDatabase.RowCount + 1;
                    this.tableLayoutPanelDatabase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

                    for (int j = 0; j < dbData[i].Count; j++)
                    {
                        this.tableLayoutPanelDatabase.Controls.Add(new Label() { Text = dbData[i][j].ToString() }, j, tableLayoutPanelDatabase.RowCount - 1);
                    }
      
                }

            }
        
        }


        
    }
}
