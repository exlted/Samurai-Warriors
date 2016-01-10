using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using System.Drawing;

namespace Common_Console_Application1
{
    class TemporaryRender
    {
        static char[] ascii = new char[41];
        public static void initRender(Dictionary<Point, world> world)
        {
            Point temp = new Point();
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; i < 40; i++)
                {
                    temp.X = i;
                    temp.Y = j;
                    Console.SetCursorPosition(i, j);
                    Console.Write(world[temp].renderChar);
                }
            }
        }
        public static Dictionary<Point, world> generateWorld(Dictionary<Point, world> world)
        {
                int e = 0;
                for (char c = (char)179; c <= (char)218; ++c)
                {
                    ascii[e] = c;
                    e++;
                }
            Point temp = new Point();
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    temp.X = j;
                    temp.Y = i;
                    if (i == 0 && j == 0)
                    {
                        world[temp].renderChar = ascii[39];
                        world[temp].isPassable = false;
                        return world;
                    }
                        //Console.Write(ascii[39]);
                    else if (i == 0 && j == 180)
                    {
                        world[temp].renderChar = ascii[12];
                        world[temp].isPassable = false;
                        return world;
                    }
                        //Console.Write(ascii[12]);

                        //Console.Write(ascii[19]);

                        //Console.Write(ascii[19]);

                        //Console.Write(ascii[2]);

                        //Console.Write(ascii[2]);
                    else if (i == 40 && j == 180)
                    {
                        world[temp].renderChar = ascii[0];
                        world[temp].isPassable = false;
                        return world;
                    }
                        //Console.Write(ascii[0]);
                    else if ((i == 0) && (j != 180 || j != 0))
                    {
                        world[temp].renderChar = ascii[17];
                        world[temp].isPassable = false;
                        return world;
                    }
                        //Console.Write(ascii[17]);
                    else if ((j == 0 || j == 180) && (i != 0 || i != 40))
                    {
                        world[temp].renderChar = ascii[0];
                        world[temp].isPassable = false;
                        return world;
                    }
                        //Console.Write(ascii[0]);

                        //Console.Write(ascii[26]);
                    else if ((j == 0 || j == 180) && (i != 40 || i != 44))
                    {
                        world[temp].renderChar = ascii[0];
                        world[temp].isPassable = false;
                        return world;
                    }
                        //Console.Write(ascii[0]);
                    else if (i >= 1 && i <= 39 && j >= 1 && j <= 179)
                    {
                        world[temp].renderChar = Convert.ToChar(".");
                        world[temp].isPassable = true;
                        return world;
                        //Console.Write(".");
                    }
                }
            }
            return world;
        }
    }
}
