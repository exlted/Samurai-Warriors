using Creature;
using System;
using System.Collections.Generic;
using System.Drawing;
using World;
using Console = Colorful.Console;

namespace Global
{
    internal class global
    {
        public static int mobCount = 10;

        public static int floorCount = 5;

        public static int currentFloor = 0;

        private static Random random = new Random();

        public static Mob player = new Mob(1, 1, random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));

        public static Dictionary<Point, world>[] world = new Dictionary<Point, world>[floorCount];

        public static string[] titleArt = { "   _____                                 _  __          __             _                ", @"  / ____|                               (_) \ \        / /            (_)               ", @" | (___   __ _ _ __ ___  _   _ _ __ __ _ _   \ \  /\  / /_ _ _ __ _ __ _  ___  _ __ ___ ", @"  \___ \ / _` | '_ ` _ \| | | | '__/ _` | |   \ \/  \/ / _` | '__| '__| |/ _ \| '__/ __|", @"  ____) | (_| | | | | | | |_| | | | (_| | |    \  /\  / (_| | |  | |  | | (_) | |  \__ \", @" |_____/ \__,_|_| |_| |_|\__,_|_|  \__,_|_|     \/  \/ \__,_|_|  |_|  |_|\___/|_|  |___/" };

        public static char[] ascii = { Convert.ToChar(179), Convert.ToChar(180), Convert.ToChar(181), Convert.ToChar(182), Convert.ToChar(183), Convert.ToChar(184), Convert.ToChar(185),
            Convert.ToChar(186), Convert.ToChar(187), Convert.ToChar(188), Convert.ToChar(189), Convert.ToChar(190), Convert.ToChar(191), Convert.ToChar(192), Convert.ToChar(193), Convert.ToChar(194),
            Convert.ToChar(195), Convert.ToChar(196), Convert.ToChar(197), Convert.ToChar(198), Convert.ToChar(199), Convert.ToChar(200), Convert.ToChar(201), Convert.ToChar(202), Convert.ToChar(203),
            Convert.ToChar(204), Convert.ToChar(205), Convert.ToChar(206), Convert.ToChar(207), Convert.ToChar(208), Convert.ToChar(209), Convert.ToChar(210), Convert.ToChar(211), Convert.ToChar(212),
            Convert.ToChar(213), Convert.ToChar(214), Convert.ToChar(215), Convert.ToChar(216), Convert.ToChar(217), Convert.ToChar(218)};

        public static Mob[,] monster = new Mob[floorCount, mobCount];

        private static string[] lastMessages = { "", "", "" };

        public static void print(string message)
        {
            lastMessages[2] = lastMessages[1];
            lastMessages[1] = lastMessages[0];
            lastMessages[0] = message;
            for (int h = 0; h < 3; h++)
            {
                switch (h)
                {
                    case 2:
                        Console.SetCursorPosition(129, 41);
                        Console.Write(lastMessages[h], Color.DarkGray);
                        for (int i = lastMessages[h].Length; i < 44; i++)
                        {
                            Console.Write(" ");
                        }
                        continue;

                    case 1:
                        Console.SetCursorPosition(129, 42);
                        Console.Write(lastMessages[h], Color.DarkGray);
                        for (int i = lastMessages[h].Length; i < 44; i++)
                        {
                            Console.Write(" ");
                        }
                        continue;

                    case 0:
                        Console.SetCursorPosition(129, 43);
                        Console.Write(lastMessages[h], Color.DarkGray);
                        for (int i = lastMessages[h].Length; i < 44; i++)
                        {
                            Console.Write(" ");
                        }
                        continue;

                    default:
                        break;
                }
            }
        }

        public static bool checkWin()
        {
            for (int i = 0; i < mobCount; i++)
            {
                if (monster[currentFloor, i].isAlive)
                {
                    return false;
                }
            }
            return true;
        }

        public static void reInitPlayer()
        {
            player = new Mob(1, 1, random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
        }

        public static void print(int horizontal, int vertical, string message, bool isCentered = true)
        {
            if (isCentered)
            {
                Console.SetCursorPosition(horizontal - message.Length / 2, vertical);
                Console.Write(message, Color.DarkGray);
            }
            else
            {
                Console.SetCursorPosition(horizontal, vertical);
                Console.Write(message, Color.DarkGray);
            }
        }

        public static void print(int horizontal, int vertical, string[] message, bool isCentered = true)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if (isCentered)
                {
                    Console.SetCursorPosition(horizontal - message[i].Length / 2, vertical + i);
                    Console.Write(message[i], Color.DarkGray);
                }
                else
                {
                    Console.SetCursorPosition(horizontal - message[i].Length / 2, vertical + i);
                    Console.Write(message[i], Color.DarkGray);
                }
            }
        }

        public static void initWorld()
        {
            for (int i = 0; i < global.floorCount; i++)
            {
                world[i] = new Dictionary<Point, world>();
            }
        }

        public static void worldReInit()
        {
            for (int i = 0; i < global.floorCount; i++)
            {
                world[i].Clear();
            }
        }
    }
}