using System.Drawing;
using Global;
using System.Collections.Generic;

namespace World
{
    internal class world
    {
        public bool isPassable;
        public bool updateOnTick;
        public bool isInside;
        public bool isSeethrough;
        public bool isUpLadder;
        public bool isDownLadder;
        public char renderChar;
        public Color color;

        public world(char render, bool passable, bool update, bool inside, bool seethrough, Color colorIs)
        {
            isPassable = passable;
            updateOnTick = update;
            renderChar = render;
            color = colorIs;
            isSeethrough = seethrough;
            isInside = inside;
            isUpLadder = false;
            isDownLadder = false;
        }

        public static void initWorld()
        {
            for (int i = 0; i < global.floorCount; i++)
            {
                global.world[i] = new Dictionary<Point, world>();
            }
        }

        public static void worldReInit()
        {
            for (int i = 0; i < global.floorCount; i++)
            {
                global.world[i].Clear();
            }
        }
    }
}