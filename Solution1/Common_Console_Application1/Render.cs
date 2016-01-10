using Creature;
using Global;
using System;
using System.Drawing;
using System.Text;
using World;

namespace render
{
    internal class Render
    {
        public static void generateWorld()
        {
            Point temp = new Point();
            for (int i = 0; i < Console.WindowHeight - 5; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 0 && j == 0)
                    {
                        global.world[temp].renderChar = global.ascii[39];
                        global.world[temp].isPassable = false;
                    }
                    else if (i == 0 && j == 180)
                    {
                        global.world[temp].renderChar = global.ascii[12];
                        global.world[temp].isPassable = false;
                    }
                    else if (i == 40 && j == 180)
                    {
                        global.world[temp].renderChar = global.ascii[0];
                        global.world[temp].isPassable = false;
                    }
                    else if ((i == 0) && (j != 180 || j != 0))
                    {
                        global.world[temp].renderChar = global.ascii[17];
                        global.world[temp].isPassable = false;
                    }
                    else if ((j == 0 || j == 180) && (i != 0 || i != 40))
                    {
                        global.world[temp].renderChar = global.ascii[0];
                        global.world[temp].isPassable = false;
                    }
                    else if ((j == 0 || j == 180) && (i != 40 || i != 44))
                    {
                        global.world[temp].renderChar = global.ascii[0];
                        global.world[temp].isPassable = false;
                    }
                    else if (i >= 1 && i <= 39 && j >= 1 && j <= 179)
                    {
                        global.world[temp].renderChar = Convert.ToChar(".");
                        global.world[temp].isPassable = true;
                    }
                }
            }
        }

        public static void initialRender(Mob player)
        {
            Point temp = new Point();
            world tempW = new world(Convert.ToChar("."), true, false);
            Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.SetWindowSize(181, 46);
            Console.SetBufferSize(181, 46);
            for (int i = 40; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if ((j == 180 && (i == 40 || i == 44)))
                        Console.Write(global.ascii[2]);
                    else if ((j == 0 && (i == 40 || i == 44)))
                        Console.Write(global.ascii[19]);
                    else if (j == 0 || j == 180)
                        Console.Write(global.ascii[0]);
                    else if ((i == 40 || i == 44) && (j != 0 || j != 180))
                        Console.Write(global.ascii[26]);
                }
            }
            Console.SetCursorPosition(5, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(5, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(5, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(62, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(62, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(62, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(120, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(120, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(120, 43);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(175, 41);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(175, 42);
            Console.Write(global.ascii[7]);
            Console.SetCursorPosition(175, 43);
            Console.Write(global.ascii[7]);
            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 181; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 40)
                        tempW.isPassable = false;
                    global.world.Add(temp, new world(tempW.renderChar, tempW.isPassable, tempW.updateOnTick));
                }
            }
            generateWorld();
            initRender();
            renderMobs(player);
            renderUI();
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
                    Console.Write(global.world[temp].renderChar);
                }
            }
        }

        public static void clearMobs(Mob player)
        {
            Console.SetCursorPosition(player.Coord.X, player.Coord.Y);
            Console.Write(".");

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                Console.SetCursorPosition(global.monster[i].Coord.X, global.monster[i].Coord.Y);
                Console.Write(".");
            }
        }

        public static void renderMobs(Mob player)
        {
            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                if (global.monster[i].isAlive)
                {
                    Console.SetCursorPosition(global.monster[i].Coord.X, global.monster[i].Coord.Y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("M");
                }
            }
            Console.SetCursorPosition(player.Coord.X, player.Coord.Y);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("P");
            Console.SetCursorPosition(0, 45);
            Console.ForegroundColor = ConsoleColor.Gray;
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