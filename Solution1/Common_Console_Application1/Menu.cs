using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global;

namespace menu
{
    class Menu
    {
        public static bool menu()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            Console.Write("1: Start Game \n2: Exit Game ");
            while (true)
            {
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    case ConsoleKey.NumPad1:
                        return true;
                    case ConsoleKey.NumPad2:
                        return false;
                    default:
                        continue;
                }
            }
        }

        public static bool endMenu()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            Console.Clear();
            Console.WriteLine("1: Restart Game \n2: Exit Game \n ");
            while (true)
            {
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        global.reInitPlayer();
                        global.world.Clear();
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    case ConsoleKey.NumPad1:
                        global.reInitPlayer();
                        global.world.Clear();
                        return true;
                    case ConsoleKey.NumPad2:
                        return false;
                    default:
                        continue;
                }
            }
        }
    }
}
