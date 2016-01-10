using Creature;
using System;
using System.Collections.Generic;
using System.Drawing;
using World;

namespace Global
{
    internal class global
    {
        public static int mobCount = 10;

        public static Dictionary<Point, world> world = new Dictionary<Point, world>();

        public static char[] ascii = { Convert.ToChar(179), Convert.ToChar(180), Convert.ToChar(181), Convert.ToChar(182), Convert.ToChar(183), Convert.ToChar(184), Convert.ToChar(185),
            Convert.ToChar(186), Convert.ToChar(187), Convert.ToChar(188), Convert.ToChar(189), Convert.ToChar(190), Convert.ToChar(191), Convert.ToChar(192), Convert.ToChar(193), Convert.ToChar(194),
            Convert.ToChar(195), Convert.ToChar(196), Convert.ToChar(197), Convert.ToChar(198), Convert.ToChar(199), Convert.ToChar(200), Convert.ToChar(201), Convert.ToChar(202), Convert.ToChar(203),
            Convert.ToChar(204), Convert.ToChar(205), Convert.ToChar(206), Convert.ToChar(207), Convert.ToChar(208), Convert.ToChar(209), Convert.ToChar(210), Convert.ToChar(211), Convert.ToChar(212),
            Convert.ToChar(213), Convert.ToChar(214), Convert.ToChar(215), Convert.ToChar(216), Convert.ToChar(217), Convert.ToChar(218)};

        public static int textPos = 0;

        public static Mob[] monster = new Mob[mobCount];

        public static void print(string message)
        {
            switch (textPos)
            {
                case 0:
                    Console.SetCursorPosition(122, 41);
                    break;

                case 1:
                    Console.SetCursorPosition(122, 42);
                    break;

                case 2:
                    Console.SetCursorPosition(122, 43);
                    break;

                default:
                    Console.SetCursorPosition(122, 43);
                    break;
            }
            Console.Write(message);
            switch (textPos)
            {
                case 0:
                    textPos = 1;
                    break;

                case 1:
                    textPos = 2;
                    break;

                case 2:
                    textPos = 0;
                    break;

                default:
                    textPos = 0;
                    break;
            }
        }
    }
}