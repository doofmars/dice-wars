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


        private Label labelAttacker;
        private Label labelDefender;
        private Label labelAttackerDices;
        private Label labelDefenderDices;

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

        public void addGameLabels(Label attack, Label defend, Label attackDice, Label defendDice)
        {
            labelAttacker = attack;
            labelDefender = defend;
            labelAttackerDices = attackDice;
            labelDefenderDices = defendDice;
        }

        public void changeGameLabel(Color attacker, Color defender, int attackerEyes, int defenderEyes)
        {
            labelAttacker.BackColor = attacker;
            labelDefender.BackColor = defender;
            labelAttackerDices.Text = attackerEyes.ToString();
            labelDefenderDices.Text = defenderEyes.ToString();
        }

        public void changeGameLabel(Color attacker, String sMessage)
        {
            labelAttacker.BackColor = attacker;
            labelAttackerDices.Text = sMessage;

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
