namespace World
{
    internal class world
    {
        public bool isPassable;
        public bool updateOnTick;
        public bool isInside;
        public bool isSeethrough;
        public char renderChar;
        public int colorCode;

        public world(char render, bool passable, bool update, bool inside, bool seethrough, int color = 1)
        {
            isPassable = passable;
            updateOnTick = update;
            renderChar = render;
            colorCode = color;
            isSeethrough = seethrough;
            isInside = inside;
        }
    }
}