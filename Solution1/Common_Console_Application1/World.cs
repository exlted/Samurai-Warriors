namespace World
{
    class world
    {
        public bool isPassable;
        public bool updateOnTick;
        public char renderChar;
        public int colorCode;

        public world(char render, bool passable, bool update, int color = 1)
        {
            isPassable = passable;
            updateOnTick = update;
            renderChar = render;
            colorCode = color;
        }
    }
}