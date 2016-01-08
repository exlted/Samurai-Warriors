using System;
using System.Text;
using API;

namespace Common_Console_Application1
{
    class Program
    {
        struct PlayerPos
        {
            public int x;
            public int xOld;
            public int y;
            public int yOld;
        }
        static void Main(string[] args)
        {
            char[] ascii = new char[41];

            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
            Console.SetWindowSize(181, 45);

            if (true)
            {
                int i = 0;
                for (char c = (char)179; c <= (char)218; ++c)
                {
                    ascii[i] = c;
                    i++;
                }
            }
            //int k = 0;
            //for (int i = 0; i < Console.WindowWidth; i++)
            //{
            //    for (int j = 0; j < (Console.WindowHeight - 5); j++)
            //    {
            //        Console.SetCursorPosition(i, j);
            //        Console.Write(ascii[k]);
            //        k += 1;
            //        if (k > 40)
            //        {
            //            k = 0;
            //        }
            //    }
            //}
            //Capi.WaitForInput();
            while (true)
            {
                ConsoleKeyInfo input;
                PlayerPos player;
                player.x = 1;
                player.y = 1;
                player.xOld = 1;
                player.yOld = 1;
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
                Console.SetCursorPosition(1, 1);
                Console.Write("P");
                while (true)
                {
                    input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (player.y > 1)
                            {
                                player.yOld = player.y;
                                player.xOld = player.x;
                                player.y -= 1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (player.y < 39)
                            {
                                player.yOld = player.y;
                                player.xOld = player.x;
                                player.y += 1;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (player.x > 1)
                            {
                                player.xOld = player.x;
                                player.yOld = player.y;
                                player.x -= 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (player.x < 179)
                            {
                                player.xOld = player.x;
                                player.yOld = player.y;
                                player.x += 1;
                            }
                            break;
                        default:
                            break;
                    }
                    Console.SetCursorPosition(player.xOld, player.yOld);
                    Console.Write(".");
                    Console.SetCursorPosition(player.x, player.y);
                    Console.Write("P");
                    Console.SetCursorPosition(0, 44);
                }
            }
        }
    }
}
/*
    3 stats - Health, Attack, Defense
    Attack/Defense 1 = 1
    on attack, roll d20, 0 = -2 str, 1-5 = -1 str, 6-15 = 0 str, 7-19 = +1 str, 20 = +2 str
    Def static
    1 attack not defended = 1 health
    Stat Rolls on level up - Str (3-5) Def (0-3) Health (10-20)
    Lv 1 Stats - Str (5-15) Def (0-5) Health (48 - 60)S
*/