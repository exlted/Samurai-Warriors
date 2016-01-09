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
        public static void initRender(Dictionary<Point, world> world)
        {
            Point temp = new Point();
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; i < 41; i++)
                {
                    temp.X = i;
                    temp.Y = j;
                    Console.SetCursorPosition(i, j);
                    Console.Write(world[temp].renderChar);
                }
            }
        }
    }
}
