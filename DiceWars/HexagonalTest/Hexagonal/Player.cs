using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Hexagonal
{
    public class Player
    {
        private int id;
        private int fields;
        private int dices;
        private int bank;
        private Color color;

        public Player(int id, Color color)
        {
            this.id = id;
            this.dices = 0;
            this.fields = 0;
            this.bank = 0;
            this.color = color;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                this.color = value;
            }
        }

        public int Fields
        {
            get
            {
                return fields;
            }
            set
            {
                this.fields = value;
            }
        }

        public int Bank
        {
            get
            {
                return bank;
            }
            set
            {
                this.bank = value;
            }
        }

        public void addField()
        {
            this.fields++;
        }
        
        public void removeField()
        {
            if (fields > 0)
            {
                this.fields--;
            }
        }

        public int Dices
        {
            get
            {
                return dices;
            }
            set
            {
                this.dices = value;
            }
        }

        public void addDices(int dices)
        {
            this.dices += dices;
        }
    }


}
