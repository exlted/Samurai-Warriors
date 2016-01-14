using System.Text;
using System;

namespace World
{
    internal class world
    {
        public bool isPassable;
        public bool updateOnTick;
        public bool isInside;
        public bool isSeethrough;
        public char renderChar;
        public ConsoleColor color;

        public world(char render, bool passable, bool update, bool inside, bool seethrough, ConsoleColor colorIs = ConsoleColor.DarkGray)
        {
            isPassable = passable;
            updateOnTick = update;
            renderChar = render;
            color = colorIs;
            isSeethrough = seethrough;
            isInside = inside;
        }
    }
}