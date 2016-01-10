using Creature;
using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using World;

namespace render
{
    internal class Render
    {
        static char[] ascii = new char[41];

        public static Dictionary<Point, world> generateWorld(Dictionary<Point, world> world)
        {
            int e = 0;
            for (char c = (char)179; c <= (char)218; ++c)
            {
                ascii[e] = c;
                e++;
            }
            Point temp = new Point();
            for (int i = 0; i < Console.WindowHeight - 5; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 0 && j == 0)
                    {
                        world[temp].renderChar = ascii[39];
                        world[temp].isPassable = false;
                    }
                    else if (i == 0 && j == 180)
                    {
                        world[temp].renderChar = ascii[12];
                        world[temp].isPassable = false;
                    }
                    else if (i == 40 && j == 180)
                    {
                        world[temp].renderChar = ascii[0];
                        world[temp].isPassable = false;
                    }
                    else if ((i == 0) && (j != 180 || j != 0))
                    {
                        world[temp].renderChar = ascii[17];
                        world[temp].isPassable = false;
                    }
                    else if ((j == 0 || j == 180) && (i != 0 || i != 40))
                    {
                        world[temp].renderChar = ascii[0];
                        world[temp].isPassable = false;
                    }
                    else if ((j == 0 || j == 180) && (i != 40 || i != 44))
                    {
                        world[temp].renderChar = ascii[0];
                        world[temp].isPassable = false;
                    }
                    else if (i >= 1 && i <= 39 && j >= 1 && j <= 179)
                    {
                        world[temp].renderChar = Convert.ToChar(".");
                        world[temp].isPassable = true;
                    }
                }
            }
            return world;
        }

        public static Dictionary<Point, world> initialRender(Dictionary<Point, world> World)
        {
            Point temp = new Point();
            world tempW = new world(Convert.ToChar("."), true, false);
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.SetWindowSize(181, 46);
            Console.SetBufferSize(181, 46);
            if (true)
            {
                int i = 0;
                for (char c = (char)179; c <= (char)218; ++c)
                {
                    ascii[i] = c;
                    i++;
                }
            }
            for (int i = 40; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if ((j == 180 && (i == 40 || i == 44)))
                        Console.Write(ascii[2]);
                    else if ((j == 0 && (i == 40 || i == 44)))
                        Console.Write(ascii[19]);
                    else if (j == 0 || j == 180)
                        Console.Write(ascii[0]);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(ascii[26]);
                }
            }
            Console.SetCursorPosition(5, 41);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(5, 42);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(5, 43);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(62, 41);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(62, 42);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(62, 43);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(120, 41);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(120, 42);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(120, 43);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(175, 41);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(175, 42);
            Console.Write(ascii[7]);
            Console.SetCursorPosition(175, 43);
            Console.Write(ascii[7]);
            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 181; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 40)
                        tempW.isPassable = false;
                    World.Add(temp, new world(tempW.renderChar, tempW.isPassable, tempW.updateOnTick));
                }
            }
            return World;
        }

        public static void initRender(Dictionary<Point, world> world)
        {
            Point temp = new Point();
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    Console.SetCursorPosition(i, j);
                    Console.Write(world[temp].renderChar);
                }
            }
        }

        public static void initMobRender(Mob player, Mob[] monster, int mobCount)
        {
            Console.SetCursorPosition(player.Coord.X, player.Coord.Y);
            Console.Write("P");
            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].Coord.X, monster[i].Coord.Y);
                Console.Write("M");
            }
            Console.SetCursorPosition(122, 43);
        }
        public static void clearMobs(Mob player, Mob[] monster, int mobCount)
        {
            Console.SetCursorPosition(player.Coord.X, player.Coord.Y);
            Console.Write(".");

            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].Coord.X, monster[i].Coord.Y);
                Console.Write(".");
            }
            Console.SetCursorPosition(122, 43);
            Console.Write("                                        ");
        }

        public static void renderMobs(Mob player, Mob[] monster, int mobCount)
        {
            for (int i = 0; i <= mobCount - 1; i++)
            {
                if (monster[i].isAlive)
                {
                    Console.SetCursorPosition(monster[i].Coord.X, monster[i].Coord.Y);
                    Console.Write("M");
                }
            }
            Console.SetCursorPosition(player.Coord.X, player.Coord.Y);
            Console.Write("P");
            Console.SetCursorPosition(122, 43);
        }

        public static void renderUI()
        {
            Console.SetCursorPosition(10, 41);
            Console.Write("HP:");
            Console.SetCursorPosition(10, 43);
            Console.Write("Str:");
            Console.SetCursorPosition(24, 43);
            Console.Write("Def:");
            Console.SetCursorPosition(67, 41);
            Console.Write("Exp:");

        }
    }
}