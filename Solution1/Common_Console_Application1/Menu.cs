using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global;
using render;
using System.Drawing;
using Console = Colorful.Console;

namespace menu
{
    class Menu
    {
        private static void renderMenu(string[] menuItems, int menuPos)
        {
            int menuDrawPos = -1;
            global.print(Console.WindowWidth / 2, 5, global.titleArt);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i + 1 == menuPos)
                    Console.BackgroundColor = Color.DarkBlue;

                global.print(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + menuDrawPos, (i + 1) + ": "  + menuItems[i], false);
                menuDrawPos += 2;
                Console.BackgroundColor = Color.Black;
            }
        }
        public static bool menu()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            string[] menuItems = { "Start New Game", "Exit Game" };
            int menuPos = 1;
            renderMenu(menuItems, menuPos);
            Console.SetCursorPosition(0, 45);
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
                    case ConsoleKey.UpArrow:
                        switch(menuPos)
                        {
                            case 1:
                                menuPos = 2;
                                renderMenu(menuItems, menuPos);
                                continue;
                            case 2:
                                menuPos = 1;
                                renderMenu(menuItems, menuPos);
                                continue;
                            default: continue;
                        }
                    case ConsoleKey.DownArrow:
                        switch (menuPos)
                        {
                            case 1:
                                menuPos = 2;
                                renderMenu(menuItems, menuPos);
                                continue;
                            case 2:
                                menuPos = 1;
                                renderMenu(menuItems, menuPos);
                                continue;
                            default: continue;
                        }
                        case ConsoleKey.Enter:
                        if (menuPos == 1)
                            return true;
                        else return false;
                    default:
                        continue;
                }
            }
        }

        public static bool endMenu()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            Console.Clear();
            string[] menuItems = { "Start New Game", "Exit Game" };
            int menuPos = 1;
              renderMenu(menuItems, menuPos);
            Console.SetCursorPosition(0, 45);
            while (true)
            {
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        global.reInitPlayer();
                        global.worldReInit();
                        Render.initialRender();
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    case ConsoleKey.NumPad1:
                        global.reInitPlayer();
                        global.worldReInit();
                        Render.initialRender();
                        return true;
                    case ConsoleKey.NumPad2:
                        return false;
                    case ConsoleKey.UpArrow:
                        switch (menuPos)
                        {
                            case 1:
                                menuPos = 2;
                                renderMenu(menuItems, menuPos);
                                continue;
                            case 2:
                                menuPos = 1;
                                renderMenu(menuItems, menuPos);
                                continue;
                            default: continue;
                        }
                    case ConsoleKey.DownArrow:
                        switch (menuPos)
                        {
                            case 1:
                                menuPos = 2;
                                renderMenu(menuItems, menuPos);
                                continue;
                            case 2:
                                menuPos = 1;
                                renderMenu(menuItems, menuPos);
                                continue;
                            default: continue;
                        }
                    case ConsoleKey.Enter:
                        if (menuPos == 1)
                        {
                            global.reInitPlayer();
                            global.worldReInit();
                            Render.initialRender();
                            return true;
                        }
                        else return false;
                    default:
                        continue;
                }
            }
        }

        public static bool escapeMenu()
        {
            Console.Clear();
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            string[] menuItems = { "Resume Game", "Exit to menu" };
            int menuPos = 1;
            renderMenu(menuItems, menuPos);
            Console.SetCursorPosition(0, 45);
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
                    case ConsoleKey.UpArrow:
                        switch (menuPos)
                        {
                            case 1:
                                menuPos = 2;
                                renderMenu(menuItems, menuPos);
                                continue;
                            case 2:
                                menuPos = 1;
                                renderMenu(menuItems, menuPos);
                                continue;
                            default: continue;
                        }
                    case ConsoleKey.DownArrow:
                        switch (menuPos)
                        {
                            case 1:
                                menuPos = 2;
                                renderMenu(menuItems, menuPos);
                                continue;
                            case 2:
                                menuPos = 1;
                                renderMenu(menuItems, menuPos);
                                continue;
                            default: continue;
                        }
                    case ConsoleKey.Enter:
                        if (menuPos == 1)
                        {
                            Render.initialRender(false);
                            Render.initRender();
                            Render.renderMobs();
                            Render.renderUI();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    default:
                        continue;
                }
            }
        }
    }
}
