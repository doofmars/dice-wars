using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Hexagonal
{
    class Builder
    {
        public class BoardBuilder
        {
            //Required
            private int width;
            private int height;
            private int side;
            //Optional
            private int player = 2;
            private HexOrientation orientation = HexOrientation.Pointy;
            private int xOffset = 0;
            private int yOffset = 0;
            private BoardState boardState = new BoardStateBuilder().build();


            public BoardBuilder withWidht(int width)
            {
                if (width <= 0)
                {
                    throw new ArgumentException("Width must be greater than 0");
                }
                this.width = width;
                return this;
            }

            public BoardBuilder witHeight(int height)
            {
                if (height <= 0)
                {
                    throw new ArgumentException("Height must be greater than 0");
                }
                this.height = height;
                return this;
            }

            public BoardBuilder withSide(int side)
            {
                if (side <= 0)
                {
                    throw new ArgumentException("Side must be greater than 0");
                }
                this.side = side;
                return this;
            }

            public BoardBuilder withPlayer(int player)
            {
                if (player <= 0)
                {
                    throw new ArgumentException("Side must be greater than 0");
                }
                this.player = player;
                return this;
            }

            public BoardBuilder withOrientation(HexOrientation orientation)
            {
                this.orientation = orientation;
                return this;
            }

            public BoardBuilder withXOffset(int xOffset)
            {
                this.xOffset = xOffset;
                return this;
            }

            public BoardBuilder withYOffset(int yOffset)
            {
                this.yOffset = yOffset;
                return this;
            }

            public BoardBuilder withBoardState(Hexagonal.BoardState boardState)
            {
                this.boardState = boardState;
                return this;
            }

            public Board build()
            {
                if (this.width == 0 || this.height == 0 || this.side == 0)
                {
                    throw new ArgumentException("width, height and side must be set!");
                }
                ArrayList players = new ArrayList();
                for (int i = 0; i < player; i++)
                {
                    players.Add(new Player(i, PlayerColors.colors[i]));
                }
                this.boardState.ActivePlayer = ((Player)players[0]).ID;
                return new Board(this.width, this.height, this.side, this.orientation, this.xOffset, this.yOffset, this.boardState, players);
            }
        }

        public class BoardStateBuilder
        {
            private System.Drawing.Color backgroundColor = Color.White;
			private System.Drawing.Color gridColor = Color.Black;
			private int gridPenWidth = 1;
			private System.Drawing.Color activeHexBorderColor = Color.Blue;
			private int activeHexBorderWidth = 1;

            public BoardStateBuilder withBackgroundColour(Color backgroundColor)
            {
                this.backgroundColor = backgroundColor;
                return this;
            }

            public BoardStateBuilder withGridColor(Color gridColor)
            {
                this.gridColor = gridColor;
                return this;
            }

            public BoardStateBuilder withGridPenWidth(int gridPenWidth)
            {
                this.gridPenWidth = gridPenWidth;
                return this;
            }

            public BoardStateBuilder withActiveHexBorderColor(Color activeHexBorderColor)
            {
                this.activeHexBorderColor = activeHexBorderColor;
                return this;
            }

            public BoardStateBuilder withActiveGridPenWidth(int activeHexBorderWidth)
            {
                this.activeHexBorderWidth = activeHexBorderWidth;
                return this;
            }

            public BoardState build ()
            {
                return new BoardState(this.backgroundColor, this.gridColor, this.gridPenWidth, this.activeHexBorderColor, this.activeHexBorderWidth);
            }
        }
    }
}
