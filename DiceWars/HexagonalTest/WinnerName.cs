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
        public WinnerName()
        {
            InitializeComponent();
        }

        private void buttonSaveName_Click(object sender, EventArgs e)
        {
            textBoxWinnerName.Clear();
            
            if (String.IsNullOrEmpty(textBoxWinnerName.Text))
            {
                 System.Windows.Forms.MessageBox.Show("Enter a name!");

            }
            else
            {
                //TODOOOO 
                //Fill the database with name, time, enemys, size of board
               
            }
        }
    }
}
