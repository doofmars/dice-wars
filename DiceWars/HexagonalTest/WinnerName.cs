using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HexagonalTest
{
    public partial class WinnerName : Form
    {
        private HexagonalTest.DTOClass dataTransferObject;
        public WinnerName(HexagonalTest.DTOClass data)
        {
            this.dataTransferObject = data;
            InitializeComponent();
        }

        private void buttonSaveName_Click(object sender, EventArgs e)
        {

            string inputName = textBoxWinnerName.Text.ToString();

            if (String.IsNullOrEmpty(inputName))
            {
                dataTransferObject.setName("anonymous");
            }
            else
            {
                //set the winnername to the DTO Object
                dataTransferObject.setName(textBoxWinnerName.Text.ToString());
                
            }
                

                //Save the data in the database and close the db connection
                HexagonalTest.Datenbank.SqliteDatabase dbHandler = new Datenbank.SqliteDatabase();
                dbHandler.connectDB();
                dbHandler.writeData(dataTransferObject.getName(), dataTransferObject.getTime(), dataTransferObject.getEnemyCount(), dataTransferObject.getFieldSize());
                dbHandler.closeDatabase();

                //restart the Application
                Application.Exit();
                System.Diagnostics.Process.Start( Application.ExecutablePath); // to start new instance of application
                


            
        }
    }
}
