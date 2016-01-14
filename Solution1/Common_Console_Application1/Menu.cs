﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global;
using render;

namespace menu
{
    class Menu
    {
        public static bool menu()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            global.print(Console.WindowHeight / 2 - 1, Console.WindowWidth / 2 - 7, "1: Start New Game");
            global.print(Console.WindowHeight / 2 + 1, Console.WindowWidth / 2 - 6, "2: Exit Game");
            Console.SetCursorPosition(0, Console.WindowHeight);
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
            Console.WriteLine("1: Start New Game \n2: Exit Game \n ");
            while (true)
            {
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Render.initialRender(false);
                        global.reInitPlayer();
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    case ConsoleKey.NumPad1:
                        Render.initialRender(false);
                        global.reInitPlayer();
                        return true;
                    case ConsoleKey.NumPad2:
                        return false;
                    default:
                        continue;
                }
            }
        }

        public static bool escapeMenu()
        {
            Console.Clear();
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            Console.Write("1: Resume Game \n2: Exit To Menu ");
            while (true)
            {
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Render.initialRender(false);
                        Render.initRender();
                        Render.renderMobs();
                        Render.renderUI();
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    case ConsoleKey.NumPad1:
                        Render.initialRender(false);
                        Render.initRender();
                        Render.renderMobs();
                        Render.renderUI();
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
