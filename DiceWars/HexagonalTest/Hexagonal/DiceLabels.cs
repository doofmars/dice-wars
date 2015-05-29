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

        public void changeLabel(int x, int y, int dices, Color backColor)
        {
            labels[x, y].Text = dices.ToString();
            labels[x, y].BackColor = backColor;
        }

        public void changeLabel(int x, int y, int dices)
        {
            labels[x, y].Text = dices.ToString();
        }
    }
}
