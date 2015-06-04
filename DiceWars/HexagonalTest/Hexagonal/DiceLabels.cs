using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hexagonal
{
    class DiceLabels
    {
        private DiceLabels() { }
        private static DiceLabels instance = null;
        private Label[,] labels; 

        public static DiceLabels GetInstance
        {
           get
           {
              if (instance == null)
              {
                  instance = new DiceLabels();
              }
              return instance;
           }
        }

        public void addLabels(Label[,] labels)
        {
            this.labels = labels;
        }

        public void update(Hex hex)
        {
            if (labels == null) 
            { 
                return; 
            }
            labels[hex.GridPositionY, hex.GridPositionX].Text = hex.Dices.ToString();
            labels[hex.GridPositionY, hex.GridPositionX].BackColor = hex.HexState.BackgroundColor;
        }
    }
}
