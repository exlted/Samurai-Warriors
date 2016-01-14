﻿using Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using World;
using Console = Colorful.Console;
using Colorful;

namespace render
{
    internal class Render
    {
        private static Random random = new Random();

        public static void initialRender(bool fullInit = true)
        {
            if (fullInit)
            {
                Point temp = new Point();
                Console.OutputEncoding = Encoding.GetEncoding(1252);
                Console.SetWindowSize(181, 46);
                Console.SetBufferSize(181, 46);
                for (int i = 0; i < 41; i++)
                {
                    for (int j = 0; j < 181; j++)
                    {
                        temp.X = j;
                        temp.Y = i;
                        global.world.Add(temp, new world(Convert.ToChar(219), false, false, false, false, Color.SaddleBrown));
                    }
                }
            }
            for (int i = 40; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if ((j == 180 && (i == 40 || i == 44)))
                        Console.Write(global.ascii[2], Color.DarkGray);
                    else if ((j == 0 && (i == 40 || i == 44)))
                        Console.Write(global.ascii[19], Color.DarkGray);
                    else if (j == 0 || j == 180)
                        Console.Write(global.ascii[19], Color.DarkGray);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(global.ascii[26], Color.DarkGray);
                }
            }
            //UI lines
            Console.SetCursorPosition(5, 40);
            Console.Write(global.ascii[24], Color.DarkGray);
            Console.SetCursorPosition(5, 41);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(5, 42);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(5, 43);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(5, 44);
            Console.Write(global.ascii[23], Color.DarkGray);
            Console.SetCursorPosition(66, 40);
            Console.Write(global.ascii[24], Color.DarkGray);
            Console.SetCursorPosition(66, 41);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(66, 42);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(66, 43);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(66, 44);
            Console.Write(global.ascii[23], Color.DarkGray);
            Console.SetCursorPosition(127, 40);
            Console.Write(global.ascii[24], Color.DarkGray);
            Console.SetCursorPosition(127, 41);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(127, 42);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(127, 43);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(127, 44);
            Console.Write(global.ascii[23], Color.DarkGray);
            Console.SetCursorPosition(175, 40);
            Console.Write(global.ascii[24], Color.DarkGray);
            Console.SetCursorPosition(175, 41);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(175, 42);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(175, 43);
            Console.Write(global.ascii[7], Color.DarkGray);
            Console.SetCursorPosition(175, 44);
            Console.Write(global.ascii[23], Color.DarkGray);
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
            Console.Write(global.ascii[0], Color.DarkGray);
            Console.SetCursorPosition(2, 42);
            Console.Write("@", Color.DarkGray);
            Console.SetCursorPosition(3, 42);
            Console.Write("#", Color.DarkGray);
            Console.SetCursorPosition(4, 42);
            Console.Write(global.ascii[0], Color.DarkGray);
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
            Console.Write(global.ascii[0], Color.DarkGray);
            Console.SetCursorPosition(177, 42);
            Console.Write("#", Color.DarkGray);
            Console.SetCursorPosition(178, 42);
            Console.Write("@", Color.DarkGray);
            Console.SetCursorPosition(179, 42);
            Console.Write(global.ascii[0], Color.DarkGray);
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
                    Console.Write(global.world[temp].renderChar, global.world[temp].color);
                }
            }
        }

        public static void randomGen(int roomNum, int roomSize, int seed)
        {
            int RanX, RanY, RanSizeX, RanSizeY;
            int[] X = new int[roomNum];
            int[] Y = new int[roomNum];
            int[] SizeX = new int[roomNum];
            int[] SizeY = new int[roomNum];
            for (int i = 0; i < roomNum; i += 0)
            {
                RanSizeX = random.Next(roomSize - 2, roomSize + 2);
                RanSizeY = random.Next(roomSize - 2, roomSize + 2);
                RanX = random.Next(0, 180 - RanSizeX);
                RanY = random.Next(0, 40 - RanSizeY);
                if (intersects(RanX, RanY, RanSizeX, RanSizeY) == false)
                {
                    generateRooms(RanX, RanY, RanSizeX, RanSizeY);
                    X[i] = RanX;
                    Y[i] = RanY;
                    SizeX[i] = RanSizeX;
                    SizeY[i] = RanSizeX;
                    i++;
                }
            }
            for (int j = 0; j < roomNum; j++)
            {
                corridorGen(X[j], Y[j], SizeX[j], SizeY[j]);
            }
        }

        public static void generateRooms(int XCoord, int YCoord, int X, int Y)
        {
            Dictionary<Point, world> room = new Dictionary<Point, world>();
            room.Clear();
            Point temp = new Point();
            for (int i = XCoord + 1; i <= XCoord + X - 1; i++)
            {
                for (int j = YCoord + 1; j <= YCoord + Y - 1; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    room.Add(temp, new world(Convert.ToChar("."), true, false, true, true, Color.DarkSlateGray));
                }
            }
            for (int i = XCoord + 1; i <= XCoord + X - 1; i++)
            {
                for (int j = YCoord + 1; j <= YCoord + Y - 1; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    global.world[temp] = new world(room[temp].renderChar, room[temp].isPassable, room[temp].updateOnTick, room[temp].isInside, room[temp].isSeethrough, room[temp].color);
                }
            }
        }

        public static void corridorGen(int X, int Y, int SizeX, int SizeY)
                        {
            Point temp = new Point();
            temp.X = X + (SizeX / 2);
            temp.Y = Y + (SizeY / 2);
            int dir = random.Next(0, 3);
            if(X <= SizeX + 2 || X >= 178 - SizeX)
            {

            }
            switch (dir)
            {
                case 0:
                    for (int i = Y + SizeY; i <= Y + SizeY + 30; i++)
                    {
                        if(i>=41||i<=0)
                        {
                            break;
                        }
                        temp.Y = i;
                        if(global.world[temp].isPassable)
                        {
                            i += 30;
                        }
                        if(i >= 38)
                        {
                            dir = random.Next(1,2);
                            if (dir == 2)
                                dir = 3;
                            i += 30;
                        }
                        global.world[temp].renderChar = '.';
                        global.world[temp].isPassable = true;
                        global.world[temp].isInside = true;
                        global.world[temp].isSeethrough = true;
                        global.world[temp].updateOnTick = false;
                        global.world[temp].color = Color.DarkSlateGray;
                    }
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:
                    break;
            }
        }

        private static bool intersects(int X, int Y, int SizeX, int SizeY)
        {
            Point temp = new Point();
            for (int i = X; i <= X + SizeX; i++)
            {
                for(int j = Y; j <= Y + SizeY; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    if(global.world[temp].isPassable)
                    {
                        return true;
                    }
                    for(int k = 0; k < 2; k++)
                    {
                        temp.X++;
                        if (global.world[temp].isPassable)
                            return true;
                    }
                }
            }
            return false;
        }

        public static void clearMobs()
        {
            Console.SetCursorPosition(global.player.Coord.X, global.player.Coord.Y);
            Console.Write(".", Color.DarkSlateGray);

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                Console.SetCursorPosition(global.monster[i].Coord.X, global.monster[i].Coord.Y);
                Console.Write(".", Color.DarkSlateGray);
            }
        }

        public static void renderMobs()
        {
            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                if (global.monster[i].isAlive)
                {
                    Console.SetCursorPosition(global.monster[i].Coord.X, global.monster[i].Coord.Y);
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
            //non-static stat numbers (might need to be moved / aren't updating after level up)
            Console.SetCursorPosition(35, 42);
            Console.Write(global.player.HP + " / " + global.player.MaxHP + "          ", Color.DarkGray);
            Console.SetCursorPosition(15, 43);
            Console.Write(Convert.ToString(global.player.Str), Color.Yellow);
            Console.SetCursorPosition(29, 43);
            Console.Write(Convert.ToString(global.player.Def), Color.Cyan);
            Console.SetCursorPosition(76, 43);
            Console.Write(Convert.ToString(global.player.Lvl), Color.Blue);
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