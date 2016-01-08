using Creature;
using System;
using System.Text;
using API;

namespace Common_Console_Application1
{
    internal class Program
    {
        private static int mobCount = 10;

        private static void initialRender()
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
        }

        private static void clearMobs(Mob player, Mob[] monster)
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

        private static void renderMobs(Mob player, Mob[] monster)
        {
            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].x, monster[i].y);
                Console.Write("M");
            }
            Console.SetCursorPosition(player.x, player.y);
            Console.Write("P");
            Console.SetCursorPosition(0, 44);
        }

        private static void Main(string[] args)
        {
            //Initializing variables
            Random random = new Random();
            ConsoleKeyInfo input;
            Mob player = new Mob(1, 1);
            Mob[] monster = new Mob[mobCount];

            for (int i = 0; i <= mobCount - 1; i++)
            {
                monster[i] = new Mob(random.Next(1, 179), random.Next(1, 39));
            }

            initialRender();

            Console.SetCursorPosition(player.x, player.y);
            Console.Write("P");
            for (int i = 0; i <= mobCount - 1; i++)
            {
                Console.SetCursorPosition(monster[i].x, monster[i].y);
                Console.Write("M");
            }
            Console.SetCursorPosition(0, 44);

            //Main loop
            while (true)
            {
                input = Console.ReadKey();
                clearMobs(player, monster);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        player = Mob.Movement(player, Mob.moveDirection.up);
                        break;

                    case ConsoleKey.DownArrow:
                        player = Mob.Movement(player, Mob.moveDirection.down);
                        break;

                    case ConsoleKey.LeftArrow:
                        player = Mob.Movement(player, Mob.moveDirection.left);
                        break;

                    case ConsoleKey.RightArrow:
                        player = Mob.Movement(player, Mob.moveDirection.right);
                        break;

                    default:
                        break;
                }
                for (int i = 0; i <= mobCount - 1; i++)
                {
                    Mob.Movement(monster[i], random.Next(1, 6));
                }
                renderMobs(player, monster);
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
    Lv 1 Stats - Str (5-15) Def (0-5) Health (48 - 60)
*/