﻿using Global;
using System;
using System.Drawing;
using System.Text;
using World;
using Console = Colorful.Console;

namespace render
{
    internal class Render
    {
        private static Random random = new Random();
        private static int randomLadderPosition = random.Next(0, 200);

        public static void initialRender(bool fullInit = true)
        {
            if (fullInit)
            {
                Point temp = new Point();
                Console.OutputEncoding = Encoding.GetEncoding(1252);
                Console.SetWindowSize(181, 46);
                Console.SetBufferSize(181, 46);
                for (int h = 0; h < global.floorCount; h++)
                {
                    for (int i = 0; i < 41; i++)
                    {
                        for (int j = 0; j < 181; j++)
                        {
                            temp.X = j;
                            temp.Y = i;
                            global.world[h].Add(temp, new world(Convert.ToChar(219), false, false, false, false, Color.SaddleBrown));
                        }
                    }
                }
            }
            for (int i = 40; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if ((j == 180 && (i == 40 || i == 44)))
                        Console.Write(Convert.ToString(global.ascii[2]), Color.DarkGray);
                    else if ((j == 0 && (i == 40 || i == 44)))
                        Console.Write(Convert.ToString(global.ascii[19]), Color.DarkGray);
                    else if (j == 0 || j == 180)
                        Console.Write(Convert.ToString(global.ascii[19]), Color.DarkGray);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(Convert.ToString(global.ascii[26]), Color.DarkGray);
                }
            }
            //UI lines
            Console.SetCursorPosition(5, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(5, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(5, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(5, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(5, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            Console.SetCursorPosition(66, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(66, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(66, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(66, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(66, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            Console.SetCursorPosition(127, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(127, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(127, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(127, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(127, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
            Console.SetCursorPosition(175, 40);
            Console.Write(Convert.ToString(global.ascii[24]), Color.DarkGray);
            Console.SetCursorPosition(175, 41);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(175, 42);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(175, 43);
            Console.Write(Convert.ToString(global.ascii[7]), Color.DarkGray);
            Console.SetCursorPosition(175, 44);
            Console.Write(Convert.ToString(global.ascii[23]), Color.DarkGray);
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
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
            Console.SetCursorPosition(2, 42);
            Console.Write("@", Color.DarkGray);
            Console.SetCursorPosition(3, 42);
            Console.Write("#", Color.DarkGray);
            Console.SetCursorPosition(4, 42);
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
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
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
            Console.SetCursorPosition(177, 42);
            Console.Write("#", Color.DarkGray);
            Console.SetCursorPosition(178, 42);
            Console.Write("@", Color.DarkGray);
            Console.SetCursorPosition(179, 42);
            Console.Write(Convert.ToString(global.ascii[0]), Color.DarkGray);
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
                    Console.Write(Convert.ToString(global.world[global.currentFloor][temp].renderChar), global.world[global.currentFloor][temp].color);
                }
            }
        }

        public static void clearMobs()
        {
            Console.SetCursorPosition(global.player.Coord.X, global.player.Coord.Y);
            Console.Write(global.world[global.currentFloor][global.player.Coord].renderChar, global.world[global.currentFloor][global.player.Coord].color);

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                Console.SetCursorPosition(global.monster[global.currentFloor, i].Coord.X, global.monster[global.currentFloor, i].Coord.Y);
                Console.Write(global.world[global.currentFloor][global.monster[global.currentFloor, i].Coord].renderChar, global.world[global.currentFloor][global.monster[global.currentFloor, i].Coord].color);
            }
        }

        public static void renderMobs()
        {
            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                if (global.monster[global.currentFloor, i].isAlive)
                {
                    Console.SetCursorPosition(global.monster[global.currentFloor, i].Coord.X, global.monster[global.currentFloor, i].Coord.Y);
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
            Console.SetCursorPosition(84, 43);
            Console.Write("Flr:", Color.DarkGray);
            Console.SetCursorPosition(1, 45);
            Console.Write("Dooooom Counter : ", Color.DarkGray);
            //non-static stat numbers (might need to be moved / aren't updating after level up)
            Console.SetCursorPosition(35, 42);
            Console.Write(global.player.HP + " / " + global.player.MaxHP + "          ", Color.DarkGray);
            Console.SetCursorPosition(15, 43);
            Console.Write(Convert.ToString(global.player.Str), Color.Yellow);
            Console.SetCursorPosition(29, 43);
            Console.Write(Convert.ToString(global.player.Def), Color.Cyan);
            Console.SetCursorPosition(76, 43);
            Console.Write(Convert.ToString(global.player.Lvl), Color.Blue);
            Console.SetCursorPosition(89, 43);
            Console.Write(Convert.ToString(global.currentFloor + 1), Color.Orange);
            Console.SetCursorPosition(19, 45);
            Console.Write(Convert.ToString(global.Doooooom), Color.Red);
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