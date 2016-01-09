namespace World
{
    class world
    {
        public bool isPassable;
        public bool updateOnTick;
        public char renderChar;

        public world(char render, bool passable, bool update)
        {
            isPassable = passable;
            updateOnTick = update;
            renderChar = render;
        }
    }
}