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
            public int y;
        }
        static void Main(string[] args)
        {
            char[] ascii = new char[43];

            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
            Console.SetWindowSize(181, 45);

            if (true)
            {
                ascii[0] = Convert.ToChar(169);
                ascii[1] = Convert.ToChar(170);
                int i = 2;
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
            Console.SetCursorPosition(1, 1);
            Console.Write("P");
            while (true)
            {
                ConsoleKeyInfo input;
                PlayerPos player;
                player.x = 1;
                player.y = 1;

                while (true)
                {
                    input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (player.y > 1)
                            {
                                player.y -= 1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (player.y < 39)
                            {
                                player.y += 1;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (player.x > 1)
                            {
                                player.x -= 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (player.x < 179)
                            {
                                player.x += 1;
                            }
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                    for (int i = 0; i < Console.; i++)
                    {
                        for (int i = 0; i < length; i++)
                        {

                        }
                    }
                    Console.SetCursorPosition(player.x, player.y);
                    Console.Write("p");
                    Console.SetCursorPosition(0, 45);
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