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
        private Color color;

        public Player(int id, Color color)
        {
            this.id = id;
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

        public Color Colour
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
    }
}
