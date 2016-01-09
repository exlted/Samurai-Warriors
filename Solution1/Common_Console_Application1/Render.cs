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

        public static Dictionary<Point, world> initialRender(Mob player, Mob[] monster, int mobCount, Dictionary<Point, world> world)
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
            for (int i = 0; i < Console.WindowHeight - 5; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (i == 0 && j == 0)
                        Console.Write(ascii[39]);
                    else if (i == 0 && j == 180)
                        Console.Write(ascii[12]);
                    else if (i == 40 && j == 0)
                        Console.Write(ascii[13]);
                    else if (i == 40 && j == 180)
                        Console.Write(ascii[38]);
                    else if ((i == 0 || i == 40) && (j != 180 || j != 0))
                        Console.Write(ascii[17]);
                    else if ((j == 0 || j == 180) && (i != 0 || i != 40))
                        Console.Write(ascii[0]);
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    world.Add(temp, tempW);
                }
            }
            Console.SetCursorPosition(player.Coord.X, player.Coord.Y);
            Console.Write("P");
            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].Coord.X, monster[i].Coord.Y);
                Console.Write("M");
            }
            Console.SetCursorPosition(1, 43);
            return world;
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
            Console.SetCursorPosition(1, 43);
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
            Console.SetCursorPosition(1, 43);
        }

        public static void renderUI()
        {

            for(int i = 40; i <= 44; i++)
            {
                for(int j = 0; j <= 180; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (i == 40 && j == 0)
                        Console.Write(ascii[19]);
                    else if (i == 44 && j == 0)
                        Console.Write(ascii[19]);
                    else if (i == 40 && j == 180)
                        Console.Write(ascii[2]);
                    else if (i == 44 && j == 180)
                        Console.Write(ascii[2]);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(ascii[26]);
                    else if ((j == 0 || j == 180) && (i != 40 || i != 44))
                        Console.Write(ascii[0]);
                    else if (i == 40 && j == 0)
                        Console.Write(ascii[0]);
                    else if (i == 40 && j == 180)
                        Console.Write(ascii[0]);
                }
            }
            Console.SetCursorPosition(1, 43);
        }
    }
}