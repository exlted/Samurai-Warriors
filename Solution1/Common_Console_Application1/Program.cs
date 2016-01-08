﻿using System;
using System.Text;

namespace Common_Console_Application1
{
    internal class Program
    {
        private struct PlayerPos
        {
            public int x;
            public int y;
            public int HP;
            public int Str;
            public int Def;
            public int Lvl;
            public int Exp;
            public bool isAlive;
        }

        private static PlayerPos MonsterMovement(PlayerPos monster, int rnd)
        {
            switch (rnd)
            {
                case 1:
                    if (monster.y > 1)
                    {
                        monster.y -= 1;
                    }
                    return monster;

                case 2:
                    if (monster.y < 39)
                    {
                        monster.y += 1;
                    }
                    return monster;

                case 3:
                    if (monster.x > 1)
                    {
                        monster.x -= 1;
                    }
                    return monster;

                case 4:
                    if (monster.x < 179)
                    {
                        monster.x += 1;
                    }
                    return monster;

                default:
                    return monster;
            }
        }

        private static bool killCheck(int playerX, int playerY, int monsterX, int monsterY)
        {
            bool isAlive = true;
            if (playerX == monsterX && playerY == monsterY)
            {
                isAlive = false;
                Console.Write("killed monster");
                return isAlive;
            }
            else return isAlive;
        }

        private static void Main(string[] args)
        {
            //Initializing variables
            char[] ascii = new char[41];
            ConsoleKeyInfo input;
            PlayerPos player;
            PlayerPos[] monster = new PlayerPos[2];
            Random random = new Random();
            player.x = 1;
            player.y = 1;
            monster[0].x = 5;
            monster[0].y = 5;
            monster[0].isAlive = true;
            monster[1].x = 20;
            monster[1].y = 35;
            monster[1].isAlive = true;
            Console.OutputEncoding = Encoding.GetEncoding(1252);
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
            Console.SetCursorPosition(5, 5);
            Console.Write("M");
            Console.SetCursorPosition(20, 35);
            Console.Write("M");
            Console.SetCursorPosition(0, 44);

            //Main loop
            while (true)
            {
                input = Console.ReadKey();
                Console.SetCursorPosition(player.x, player.y);
                Console.Write(".");
                Console.SetCursorPosition(monster[0].x, monster[0].y);
                Console.Write(".");
                Console.SetCursorPosition(monster[1].x, monster[1].y);
                Console.Write(".");

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

                if (monster[0].isAlive)
                {
                    monster[0] = MonsterMovement(monster[0], random.Next(1, 6));
                    Console.SetCursorPosition(monster[0].x, monster[0].y);
                    Console.Write("M");
                    Console.SetCursorPosition(0, 44);
                    monster[0].isAlive = killCheck(player.x, player.y, monster[0].x, monster[0].y);
                }
                else
                {
                    Console.SetCursorPosition(0, 44);
                    Console.Write("              ");
                }
                if (monster[1].isAlive)
                {
                    monster[1] = MonsterMovement(monster[1], random.Next(1, 6));
                    Console.SetCursorPosition(monster[1].x, monster[1].y);
                    Console.Write("M");
                    Console.SetCursorPosition(0, 44);
                    monster[1].isAlive = killCheck(player.x, player.y, monster[1].x, monster[1].y);
                }
                else
                {
                    Console.SetCursorPosition(0, 44);
                    Console.Write("              ");
                }
                Console.SetCursorPosition(player.x, player.y);
                Console.Write("P");
                Console.SetCursorPosition(0, 44);

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
