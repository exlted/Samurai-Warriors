﻿using System.Drawing;
using System;
using Colorful;

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

        public world(char render, bool passable, bool update, bool inside, bool seethrough,  ConsoleColor colorIs)
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