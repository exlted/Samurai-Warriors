using Global;
using System;
using System.Collections.Generic;
using System.Drawing;

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
        private static Random random = new Random();

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
            global.currentFloor = 0;
            for (int i = 0; i < global.floorCount; i++)
            {
                global.world[i].Clear();
            }
        }

        public static void randomGen(int roomNum, int roomSize, int seed, int floor)
        {
            int RanX = 0, RanY = 0, RanSizeX, RanSizeY;
            int[] X = new int[roomNum];
            int[] Y = new int[roomNum];
            int[] SizeX = new int[roomNum];
            int[] SizeY = new int[roomNum];
            Point temp = new Point();
            for (int i = 0; i < roomNum; i += 0)
            {
                RanSizeX = random.Next(roomSize - 2, roomSize + 2);
                RanSizeY = random.Next(roomSize - 2, roomSize + 2);
                RanX = random.Next(0, 180 - RanSizeX);
                RanY = random.Next(0, 40 - RanSizeY);
                if (intersects(RanX, RanY, RanSizeX, RanSizeY, floor) == false)
                {
                    generateRooms(RanX, RanY, RanSizeX, RanSizeY, floor);
                    X[i] = RanX;
                    Y[i] = RanY;
                    SizeX[i] = RanSizeX;
                    SizeY[i] = RanSizeY;
                    i++;
                }
            }
            for (int i = 1; i < roomNum; i++)
            {
                corridorGen(X[i] + SizeX[i] / 2, Y[i] + SizeY[i] / 2, X[i - 1] + SizeX[i - 1] / 2, Y[i - 1] + SizeY[i - 1] / 2, floor);
            }
            temp.X = X[0] + (SizeX[0] / 2);
            temp.Y = Y[0] + (SizeY[0] / 2);
            global.firstRooms[floor] = temp;
            temp.X = X[roomNum - 1] + (SizeX[roomNum - 1] / 2);
            temp.Y = Y[roomNum - 1] + (SizeY[roomNum - 1] / 2);
            global.lastRooms[floor] = temp;
            textureGen(floor);
        }

        private static void generateRooms(int XCoord, int YCoord, int X, int Y, int floor)
        {
            Dictionary<Point, world>[] room = new Dictionary<Point, world>[global.floorCount];
            for (int i = 0; i < global.floorCount; i++)
            {
                room[i] = new Dictionary<Point, world>();
            }
            Point temp = new Point();
            for (int i = XCoord + 1; i <= XCoord + X - 1; i++)
            {
                for (int j = YCoord + 1; j <= YCoord + Y - 1; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    room[floor].Add(temp, new world(Convert.ToChar("."), true, false, true, true, Color.DarkGray));
                }
            }
            for (int i = XCoord + 1; i <= XCoord + X - 1; i++)
            {
                for (int j = YCoord + 1; j <= YCoord + Y - 1; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    global.world[floor][temp] = new world(room[floor][temp].renderChar, room[floor][temp].isPassable, room[floor][temp].updateOnTick, room[floor][temp].isInside, room[floor][temp].isSeethrough, room[floor][temp].color);
                }
            }
        }

        private static void corridorGen(int X1, int Y1, int X2, int Y2, int floor)
        {
            if (X1 == X2)
            {
                yCoor(Y1, Y2, X2, floor);
            }
            else if (Y1 == Y2)
            {
                xCoor(X1, X2, Y1, floor);
            }
            else
            {
                xCoor(X1, X2, Y1, floor);
                yCoor(Y1, Y2, X2, floor);
            }
        }

        private static void xCoor(int X1, int X2, int Y1, int floor)
        {
            Point temp = new Point();
            temp.Y = Y1;
            if (X1 > X2)
            {
                for (int i = X2; i <= X1; i++)
                {
                    temp.X = i;
                    global.world[floor][temp].renderChar = '.';
                    global.world[floor][temp].isPassable = true;
                    global.world[floor][temp].isSeethrough = true;
                    global.world[floor][temp].isInside = true;
                    global.world[floor][temp].updateOnTick = false;
                    global.world[floor][temp].color = Color.DarkGray;
                }
            }
            else if (X1 < X2)
            {
                for (int i = X1; i <= X2; i++)
                {
                    temp.X = i;
                    global.world[floor][temp].renderChar = '.';
                    global.world[floor][temp].isPassable = true;
                    global.world[floor][temp].isSeethrough = true;
                    global.world[floor][temp].isInside = true;
                    global.world[floor][temp].updateOnTick = false;
                    global.world[floor][temp].color = Color.DarkGray;
                }
            }
        }

        private static void yCoor(int Y1, int Y2, int X2, int floor)
        {
            Point temp = new Point();
            temp.X = X2;
            if (Y1 > Y2)
            {
                for (int i = Y2; i <= Y1; i++)
                {
                    temp.Y = i;
                    global.world[floor][temp].renderChar = '.';
                    global.world[floor][temp].isPassable = true;
                    global.world[floor][temp].isSeethrough = true;
                    global.world[floor][temp].isInside = true;
                    global.world[floor][temp].updateOnTick = false;
                    global.world[floor][temp].color = Color.DarkGray;
                }
            }
            else if (Y1 < Y2)
            {
                for (int i = Y1; i <= Y2; i++)
                {
                    temp.Y = i;
                    global.world[floor][temp].renderChar = '.';
                    global.world[floor][temp].isPassable = true;
                    global.world[floor][temp].isSeethrough = true;
                    global.world[floor][temp].isInside = true;
                    global.world[floor][temp].updateOnTick = false;
                    global.world[floor][temp].color = Color.DarkGray;
                }
            }
        }

        private static bool intersects(int X, int Y, int SizeX, int SizeY, int floor)
        {
            Point temp = new Point();
            for (int i = X; i <= X + SizeX; i++)
            {
                for (int j = Y; j <= Y + SizeY; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    if (global.world[floor][temp].isPassable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void ladderGen(int floor)
        {
            if (!(floor == global.floorCount - 1))
            {
                global.world[floor][global.lastRooms[floor]].renderChar = 'O';
                global.world[floor][global.lastRooms[floor]].isDownLadder = true;
                global.world[floor][global.lastRooms[floor]].color = Color.DarkGray;
                global.world[floor + 1][global.firstRooms[floor + 1]].renderChar = '#';
                global.world[floor + 1][global.firstRooms[floor + 1]].isUpLadder = true;
                global.world[floor + 1][global.firstRooms[floor + 1]].color = Color.Yellow;
                if (floor == global.floorCount - 2)
                {
                    global.world[floor + 1][global.lastRooms[floor + 1]].renderChar = 'O';
                    global.world[floor + 1][global.lastRooms[floor + 1]].isDownLadder = true;
                    global.world[floor + 1][global.lastRooms[floor + 1]].color = Color.DarkGray;
                }
            }
        }

        private static void textureGen(int floor)
        {
            Point temp = new Point();
            int amt = random.Next(5, 200);
            for (int i = 0; i < amt; i++)
            {
                while (true)
                {
                    temp.X = random.Next(0, 180);
                    temp.Y = random.Next(0, 40);
                    if (global.world[floor][temp].isPassable)
                    {
                        global.world[floor][temp].renderChar = '*';
                        global.world[floor][temp].color = Color.DarkKhaki;
                        break;
                    }
                }
            }
            int amt2 = random.Next(5, 50);
            for (int i = 0; i < amt2; i++)
            {
                while (true)
                {
                    temp.X = random.Next(0, 180);
                    temp.Y = random.Next(0, 40);
                    if (global.world[floor][temp].isPassable)
                    {
                        global.world[floor][temp].renderChar = '%';
                        global.world[floor][temp].color = Color.DarkGreen;
                        break;
                    }
                }
            }
        }
    }
}