using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Creature;

namespace World
{
    class world
    {
        public bool isPassable;
        public bool updateOnTick;
        public char renderChar;
        public int xCoord;
        public int yCoord;

        public world(int x, int y, char render, bool passable, bool update)
        {
            isPassable = passable;
            updateOnTick = update;
            xCoord = x;
            yCoord = y;
            renderChar = render;
        }
    }
}