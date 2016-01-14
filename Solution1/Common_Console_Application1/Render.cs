using Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using World;

namespace render
{
    internal class Render
    {
        public static void generateWorld()
        {
            Point temp = new Point();
            for (int i = 0; i < Console.WindowHeight - 5; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 0 && j == 0)
                    {
                        global.world[temp].renderChar = global.ascii[39];
                        global.world[temp].isPassable = false;
                    }
                    else if (i == 0 && j == 180)
                    {
                        global.world[temp].renderChar = global.ascii[12];
                        global.world[temp].isPassable = false;
                    }
                    else if (i == 40 && j == 180)
                    {
                        global.world[temp].renderChar = global.ascii[0];
                        global.world[temp].isPassable = false;
                    }
                    else if ((i == 0) && (j != 180 || j != 0))
                    {
                        global.world[temp].renderChar = global.ascii[17];
                        global.world[temp].isPassable = false;
                    }
                    else if ((j == 0 || j == 180) && (i != 0 || i != 40))
                    {
                        global.world[temp].renderChar = global.ascii[0];
                        global.world[temp].isPassable = false;
                    }
                    else if ((j == 0 || j == 180) && (i != 40 || i != 44))
                    {
                        global.world[temp].renderChar = global.ascii[0];
                        global.world[temp].isPassable = false;
                    }
                    else if (i >= 1 && i <= 39 && j >= 1 && j <= 179)
                    {
                        global.world[temp].renderChar = Convert.ToChar(".");
                        global.world[temp].isPassable = true;
                    }
                }
            }
        }

        public static void initialRender()
        {
            Point temp = new Point();
            world tempW = new world(Convert.ToChar("."), true, false, true, true);
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.SetWindowSize(181, 46);
            Console.SetBufferSize(181, 46);
            for (int i = 40; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if ((j == 180 && (i == 40 || i == 44)))
                        Console.Write(global.ascii[2]);
                    else if ((j == 0 && (i == 40 || i == 44)))
                        Console.Write(global.ascii[19]);
                    else if (j == 0 || j == 180)
                        Console.Write(global.ascii[0]);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(global.ascii[26]);
                }
            }
            //UI lines
            Console.SetCursorPosition(5, 40);
            Console.Write(global.ascii[24]);
            Console.SetCursorPosition(5, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(5, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(5, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(5, 44);
            Console.Write(global.ascii[23]);
            Console.SetCursorPosition(66, 40);
            Console.Write(global.ascii[24]);
            Console.SetCursorPosition(66, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(66, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(66, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(66, 44);
            Console.Write(global.ascii[23]);
            Console.SetCursorPosition(127, 40);
            Console.Write(global.ascii[24]);
            Console.SetCursorPosition(127, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(127, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(127, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(127, 44);
            Console.Write(global.ascii[23]);
            Console.SetCursorPosition(175, 40);
            Console.Write(global.ascii[24]);
            Console.SetCursorPosition(175, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(175, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(175, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(175, 44);
            Console.Write(global.ascii[23]);
            //ascii art in UI left
            Console.SetCursorPosition(1, 41);
            Console.Write("/");
            Console.SetCursorPosition(2, 41);
            Console.Write("\\");
            Console.SetCursorPosition(3, 41);
            Console.Write("/");
            Console.SetCursorPosition(4, 41);
            Console.Write("\\");
            Console.SetCursorPosition(1, 42);
            Console.Write(global.ascii[0]);
            Console.SetCursorPosition(2, 42);
            Console.Write("@");
            Console.SetCursorPosition(3, 42);
            Console.Write("#");
            Console.SetCursorPosition(4, 42);
            Console.Write(global.ascii[0]);
            Console.SetCursorPosition(1, 43);
            Console.Write("\\");
            Console.SetCursorPosition(2, 43);
            Console.Write("/");
            Console.SetCursorPosition(3, 43);
            Console.Write("\\");
            Console.SetCursorPosition(4, 43);
            Console.Write("/");
            //ascii art of UI right
            Console.SetCursorPosition(176, 41);
            Console.Write("/");
            Console.SetCursorPosition(177, 41);
            Console.Write("\\");
            Console.SetCursorPosition(178, 41);
            Console.Write("/");
            Console.SetCursorPosition(179, 41);
            Console.Write("\\");
            Console.SetCursorPosition(176, 42);
            Console.Write(global.ascii[0]);
            Console.SetCursorPosition(177, 42);
            Console.Write("#");
            Console.SetCursorPosition(178, 42);
            Console.Write("@");
            Console.SetCursorPosition(179, 42);
            Console.Write(global.ascii[0]);
            Console.SetCursorPosition(176, 43);
            Console.Write("\\");
            Console.SetCursorPosition(177, 43);
            Console.Write("/");
            Console.SetCursorPosition(178, 43);
            Console.Write("\\");
            Console.SetCursorPosition(179, 43);
            Console.Write("/");
            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 181; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 40)
                        tempW.isPassable = false;
                    global.world.Add(temp, new world(tempW.renderChar, tempW.isPassable, tempW.updateOnTick, tempW.isInside, tempW.isSeethrough));
                }
            }
            generateWorld();
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
                    Console.Write(global.world[temp].renderChar);
                }
            }
        }

        public static void randomGen(int roomNum, int roomSize, int seed)
        {
            //generateRooms(0, 0, 30, 15);
        }

        public static void generateRooms(int XCoord, int YCoord, int X, int Y)
        {
            Dictionary<Point, world> room = new Dictionary<Point, world>();
            Point temp = new Point();
            for (int i = XCoord; i <= XCoord + X; i++)
            {
                for (int j = YCoord; j <= YCoord + Y; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    if (i == XCoord && j == YCoord)
                    {
                        room.Add(temp, new world(global.ascii[39], false, false, false, false));
                    }
                    else if (i == XCoord && j == YCoord + Y)
                    {
                        room.Add(temp, new world(global.ascii[13], false, false, false, false));
                    }
                    else if (i == XCoord + X && j == YCoord)
                    {
                        room.Add(temp, new world(global.ascii[12], false, false, false, false));
                    }
                    else if (i == XCoord + X && j == YCoord + Y)
                    {
                        room.Add(temp, new world(global.ascii[38], false, false, false, false));
                    }
                    else if ((i == XCoord || i == XCoord + X) && (j != YCoord + Y || j != YCoord))
                    {
                        room.Add(temp, new world(global.ascii[0], false, false, false, false));
                    }
                    else if ((j == YCoord || j == YCoord + Y) && (i != XCoord || i != XCoord + X))
                    {
                        room.Add(temp, new world(global.ascii[17], false, false, false, false));
                    }
                    else if (i >= (XCoord + 1) && i <= (XCoord + X - 1) && j >= (YCoord + 1) && j <= (YCoord + Y - 1))
                    {
                        room.Add(temp, new world(Convert.ToChar("."), true, false, true, true));
                    }
                }
            }
            for (int i = XCoord; i <= XCoord + X; i++)
            {
                for (int j = YCoord; j <= YCoord + Y; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    global.world[temp] = new world(room[temp].renderChar, room[temp].isPassable, room[temp].updateOnTick, room[temp].isInside, room[temp].isSeethrough, room[temp].colorCode);
                }
            }
        }

        public static void clearMobs()
        {
            Console.SetCursorPosition(global.player.Coord.X, global.player.Coord.Y);
            Console.Write(".");

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                Console.SetCursorPosition(global.monster[i].Coord.X, global.monster[i].Coord.Y);
                Console.Write(".");
            }
        }

        public static void renderMobs()
        {
            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                if (global.monster[i].isAlive)
                {
                    Console.SetCursorPosition(global.monster[i].Coord.X, global.monster[i].Coord.Y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("M");
                }
            }
            Console.SetCursorPosition(global.player.Coord.X, global.player.Coord.Y);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("P");
            Console.SetCursorPosition(0, 45);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void renderUI()
        {
            //static stat identifiers
            Console.SetCursorPosition(10, 41);
            Console.Write("HP:");
            Console.SetCursorPosition(10, 43);
            Console.Write("Str:");
            Console.SetCursorPosition(24, 43);
            Console.Write("Def:");
            Console.SetCursorPosition(70, 41);
            Console.Write("Exp:");
            Console.SetCursorPosition(70, 43);
            Console.Write("Lvl:");
            //non-static stat numbers (might need to be moved / aren't updating after level up)
            Console.SetCursorPosition(35, 42);
            Console.Write(global.player.HP + " / " + global.player.MaxHP + "          ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(15, 43);
            Console.Write(global.player.Str);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(29, 43);
            Console.Write(global.player.Def);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(76, 43);
            Console.Write(global.player.Lvl);
            //HP bar
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int percent = (global.player.HP * 100) / global.player.MaxHP;
            Console.SetCursorPosition(14, 41);
            for (int i = 1; i <= (percent / 2); i++)
            {
                Console.Write(global.ascii[27]);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            for (int j = (percent / 2) + 1; j <= 50; j++)
            {
                Console.Write(global.ascii[27]);
                if (global.player.HP <= -5)
                {
                    break;
                }
            }
            //Exp Bar
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(75, 41);
            percent = (global.player.Exp * 100) / (5 * global.player.Lvl);
            for (int e = 1; e <= (percent / 2); e++)
            {
                Console.Write(global.ascii[27]);
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int a = (percent / 2) + 1; a <= 50; a++)
            {
                Console.Write(global.ascii[27]);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 45);
        }

        public static void renderChar()
        {
        }
    }
}