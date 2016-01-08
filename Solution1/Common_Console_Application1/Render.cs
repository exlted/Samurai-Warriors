using Creature;
using System;
using System.Text;

namespace Render
{
    internal class render
    {
        public static void initialRender(Mob player, Mob[] monster, int mobCount)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.SetWindowSize(181, 45);
            char[] ascii = new char[41];
            if (true)
            {
                int i = 0;
                for (char c = (char)179; c <= (char)218; ++c)
                {
                    ascii[i] = c;
                    i++;
                }
            }
            for (int i = 0; i < Console.WindowHeight - 4; i++)
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
            Console.SetCursorPosition(player.x, player.y);
            Console.Write("P");
            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].x, monster[i].y);
                Console.Write("M");
            }
            Console.SetCursorPosition(0, 44);
        }

        public static void clearMobs(Mob player, Mob[] monster, int mobCount)
        {
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(".");

            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].x, monster[i].y);
                Console.Write(".");
            }
            Console.SetCursorPosition(0, 44);
        }

        public static void renderMobs(Mob player, Mob[] monster, int mobCount)
        {
            for (int i = 0; i <= mobCount - 1; i++)
            {
                if (monster[i].isAlive)
                {
                    Console.SetCursorPosition(monster[i].x, monster[i].y);
                    Console.Write("M");
                }
            }
            Console.SetCursorPosition(player.x, player.y);
            Console.Write("P");
            Console.SetCursorPosition(0, 44);
        }

        public static void renderUI()
        {
        }
    }
}