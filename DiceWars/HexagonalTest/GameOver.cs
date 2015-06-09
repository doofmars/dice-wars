using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HexagonalTest
{
    public partial class GameOver : Form
    {

        private HexagonalTest.DTOClass transferObject;
        public GameOver(string nameOfPlayer, DTOClass data)
        {
            this.transferObject = data;
            InitializeComponent(nameOfPlayer);
            
            //Stop the timer and save the time
            transferObject.stopTimer();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            
            HexagonalTest.WinnerName winForm = new HexagonalTest.WinnerName( transferObject );
            winForm.Show();
            this.Close();

        }
    }
}
