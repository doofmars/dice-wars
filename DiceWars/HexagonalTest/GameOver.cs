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
      
        public GameOver(string nameOfPlayer)
        {
            InitializeComponent(nameOfPlayer);
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.Close();
            HexagonalTest.WinnerName winForm = new HexagonalTest.WinnerName();
            winForm.Show();

        }
    }
}
