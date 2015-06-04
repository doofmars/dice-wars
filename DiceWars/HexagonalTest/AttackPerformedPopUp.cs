using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hexagonal
{
    public partial class AttackPerformedPopUp : Form
    {
        private Color colorAttacker;
        private Color colorDefender;
        private int dicesAttacker;
        private int dicesDefender;

        public AttackPerformedPopUp(Color colorAttacker, Color colorDefender, int dicesAttacker, int dicesDefender)
        {
            InitializeComponent();

            this.dicesAttacker = dicesAttacker;
            this.dicesDefender = dicesDefender;
            this.colorAttacker = colorAttacker;
            this.colorDefender = colorDefender;

            label1.BackColor = colorAttacker;
            label2.BackColor = colorDefender;

            label4.Text = dicesAttacker.ToString();
            label5.Text = dicesDefender.ToString() ;
        }

        private void AttackPerformedPopUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
