using Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using World;
using Console = Colorful.Console;

namespace render
{
    internal class Render
    {
        private static Random random = new Random();
        private static int randomLadderPosition = random.Next(0, 200);

        public static void initialRender(bool fullInit = true)
        {
            if (fullInit)
            {
                Point temp = new Point();
                Console.OutputEncoding = Encoding.GetEncoding(1252);
                Console.SetWindowSize(181, 46);
                Console.SetBufferSize(181, 46);
                for (int h = 0; h < global.floorCount; h++)
                {
                    for (int i = 0; i < 41; i++)
                    {
                        for (int j = 0; j < 181; j++)
                        {
                            temp.X = j;
                            temp.Y = i;
                            global.world[h].Add(temp, new world(Convert.ToChar(219), false, false, false, false, Color.SaddleBrown));
                        }
                    }
                }
            }
            for (int i = 40; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if ((j == 180 && (i == 40 || i == 44)))
                        Console.Write(Convert.ToString(global.ascii[2]), Color.DarkGray);
                    else if ((j == 0 && (i == 40 || i == 44)))
                        Console.Write(Convert.ToString(global.ascii[19]), Color.DarkGray);
                    else if (j == 0 || j == 180)
                        Console.Write(Convert.ToString(global.ascii[19]), Color.DarkGray);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(Convert.ToString(global.ascii[26]), Color.DarkGray);
                }
            }
            //UI lines
            Console.SetCursorPosition(5, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(5, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(5, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(5, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(5, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            Console.SetCursorPosition(66, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(66, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(66, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(66, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(66, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            Console.SetCursorPosition(127, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(127, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(127, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(127, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(127, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            Console.SetCursorPosition(175, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(175, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(175, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(175, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(175, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            //ascii art in UI left
            Console.SetCursorPosition(1, 41);
            Console.Write("/", Color.DarkGray);
            Console.SetCursorPosition(2, 41);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(3, 41);
            Console.Write("/", Color.DarkGray);
            Console.SetCursorPosition(4, 41);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(1, 42);
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
            Console.SetCursorPosition(2, 42);
            Console.Write("@", Color.DarkGray);
            Console.SetCursorPosition(3, 42);
            Console.Write("#", Color.DarkGray);
            Console.SetCursorPosition(4, 42);
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
            Console.SetCursorPosition(1, 43);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(2, 43);
            Console.Write("/", Color.DarkGray);
            Console.SetCursorPosition(3, 43);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(4, 43);
            Console.Write("/", Color.DarkGray);
            //ascii art of UI right
            Console.SetCursorPosition(176, 41);
            Console.Write("/", Color.DarkGray);
            Console.SetCursorPosition(177, 41);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(178, 41);
            Console.Write("/", Color.DarkGray);
            Console.SetCursorPosition(179, 41);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(176, 42);
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
            Console.SetCursorPosition(177, 42);
            Console.Write("#", Color.DarkGray);
            Console.SetCursorPosition(178, 42);
            Console.Write("@", Color.DarkGray);
            Console.SetCursorPosition(179, 42);
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
            Console.SetCursorPosition(176, 43);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(177, 43);
            Console.Write("/", Color.DarkGray);
            Console.SetCursorPosition(178, 43);
            Console.Write("\\", Color.DarkGray);
            Console.SetCursorPosition(179, 43);
            Console.Write("/", Color.DarkGray);
        }

        public static void initRender()
        {
            Point temp = new Point();
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    Console.SetCursorPosition(i, j);
                    Console.Write(Convert.ToString(global.world[global.currentFloor][temp].renderChar), global.world[global.currentFloor][temp].color);
                }
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

        public static void generateRooms(int XCoord, int YCoord, int X, int Y, int floor)
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

        public static void corridorGen(int X1, int Y1, int X2, int Y2, int floor)
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
            if(!(floor == global.floorCount - 1))
            {
                global.world[floor][global.lastRooms[floor]].renderChar = 'O';
                global.world[floor][global.lastRooms[floor]].isDownLadder = true;
                global.world[floor][global.lastRooms[floor]].color = Color.DarkGray;
                global.world[floor + 1][global.firstRooms[floor + 1]].renderChar = '#';
                global.world[floor + 1][global.firstRooms[floor + 1]].isUpLadder = true;
                global.world[floor + 1][global.firstRooms[floor + 1]].color = Color.Yellow;
                if(floor == global.floorCount - 2)
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
            for(int i = 0; i < amt; i++)
            {
                while(true)
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

        public static void clearMobs()
        {
            Console.SetCursorPosition(global.player.Coord.X, global.player.Coord.Y);
            Console.Write(global.world[global.currentFloor][global.player.Coord].renderChar, global.world[global.currentFloor][global.player.Coord].color);

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                Console.SetCursorPosition(global.monster[global.currentFloor, i].Coord.X, global.monster[global.currentFloor, i].Coord.Y);
                Console.Write(global.world[global.currentFloor][global.monster[global.currentFloor,i].Coord].renderChar, global.world[global.currentFloor][global.monster[global.currentFloor, i].Coord].color);
            }
        }

        public static void renderMobs()
        {
            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                if (global.monster[global.currentFloor, i].isAlive)
                {
                    Console.SetCursorPosition(global.monster[global.currentFloor, i].Coord.X, global.monster[global.currentFloor, i].Coord.Y);
                    Console.Write("M", Color.Red);
                }
            }
            Console.SetCursorPosition(global.player.Coord.X, global.player.Coord.Y);
            Console.Write("P", Color.DarkCyan);
            Console.SetCursorPosition(0, 45);
        }

        public static void renderUI()
        {
            //static stat identifiers
            Console.SetCursorPosition(10, 41);
            Console.Write("HP:", Color.DarkGray);
            Console.SetCursorPosition(10, 43);
            Console.Write("Str:", Color.DarkGray);
            Console.SetCursorPosition(24, 43);
            Console.Write("Def:", Color.DarkGray);
            Console.SetCursorPosition(70, 41);
            Console.Write("Exp:", Color.DarkGray);
            Console.SetCursorPosition(70, 43);
            Console.Write("Lvl:", Color.DarkGray);
            Console.SetCursorPosition(84, 43);
            Console.Write("Flr:", Color.DarkGray);
            //non-static stat numbers (might need to be moved / aren't updating after level up)
            Console.SetCursorPosition(35, 42);
            Console.Write(global.player.HP + " / " + global.player.MaxHP + "          ", Color.DarkGray);
            Console.SetCursorPosition(15, 43);
            Console.Write(Convert.ToString(global.player.Str), Color.Yellow);
            Console.SetCursorPosition(29, 43);
            Console.Write(Convert.ToString(global.player.Def), Color.Cyan);
            Console.SetCursorPosition(76, 43);
            Console.Write(Convert.ToString(global.player.Lvl), Color.Blue);
            Console.SetCursorPosition(89, 43);
            Console.Write(Convert.ToString(global.currentFloor + 1), Color.Orange);
            //HP bar
            int percent = (global.player.HP * 100) / global.player.MaxHP;
            int healthPos = 14;
            for (int i = 1; i <= (percent / 2); i++)
            {
                Console.SetCursorPosition(healthPos++, 41);
                Console.Write(Convert.ToString(global.ascii[27]), Color.DarkRed);
            }
            for (int j = (percent / 2) + 1; j <= 50; j++)
            {
                Console.SetCursorPosition(healthPos++, 41);
                Console.Write(Convert.ToString(global.ascii[27]), Color.Black);
                if (global.player.HP <= -5)
                {
                    break;
                }
            }
            //Exp Bar
            percent = (global.player.Exp * 100) / (5 * global.player.Lvl);
            int expPos = 75;
            for (int e = 1; e <= (percent / 2); e++)
            {
                Console.SetCursorPosition(expPos++, 41);
                Console.Write(Convert.ToString(global.ascii[27]), Color.Green);
            }
            for (int a = (percent / 2) + 1; a <= 50; a++)
            {
                Console.SetCursorPosition(expPos++, 41);
                Console.Write(Convert.ToString(global.ascii[27]), Color.DarkGray);
            }

            Console.SetCursorPosition(0, 45);
        }
    }
}