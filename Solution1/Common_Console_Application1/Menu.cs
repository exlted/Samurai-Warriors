using Global;
using render;
using System;
using System.Drawing;
using Console = Colorful.Console;
using print;
using Creature;
using World;

namespace menu
{
    internal class Menu
    {
        private static void renderMenu(string[] menuItems, int menuPos)
        {
            int menuDrawPos = -1;
            Write.print(Console.WindowWidth / 2, 5, global.titleArt);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == menuPos)
                    Console.BackgroundColor = Color.DarkBlue;

                Write.print(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + menuDrawPos, (i + 1) + ": " + menuItems[i], false);
                menuDrawPos += 2;
                Console.BackgroundColor = Color.Black;
            }
        }

        public static int menu()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            string[] menuItems = { "Start New Game", "View Credits",  "Exit Game" };
            int menuPos = 0;
            renderMenu(menuItems, menuPos);
            Console.SetCursorPosition(0, 45);
            while (true)
            {
                renderMenu(menuItems, Math.Abs(menuPos % menuItems.Length));
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuPos -= 1;
                        continue;
                    case ConsoleKey.DownArrow:
                        menuPos += 1;
                        continue;
                    case ConsoleKey.Enter:
                        switch(Math.Abs(menuPos % menuItems.Length))
                        {
                            case 0:
                                return 0;
                            case 1:
                                Write.rollCredits(global.credits);
                                continue;
                            case 2:
                                return 2;
                            default: continue;
                        }
                    default:
                        continue;
                }
            }
        }

        public static int endMenu()
        {
            Console.Clear();
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            string[] menuItems = { "Start New Game", "View Credits", "Exit Game" };
            int menuPos = 0;
            renderMenu(menuItems, menuPos);
            Console.SetCursorPosition(0, 45);
            while (true)
            {
                renderMenu(menuItems, Math.Abs(menuPos % menuItems.Length));
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuPos -= 1;
                        continue;
                    case ConsoleKey.DownArrow:
                        menuPos += 1;
                        continue;
                    case ConsoleKey.Enter:
                        switch (Math.Abs(menuPos % menuItems.Length))
                        {
                            case 0:
                                return 0;
                            case 1:
                                Write.rollCredits(global.credits);
                                continue;
                            case 2:
                                return 2;
                            default: continue;
                        }
                    default:
                        continue;
                }
            }
        }

        public static bool escapeMenu()
        {
            Console.Clear();
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            string[] menuItems = { "Resume Game", "Exit Game" };
            int menuPos = 0;
            renderMenu(menuItems, menuPos);
            Console.SetCursorPosition(0, 45);
            while (true)
            {
                renderMenu(menuItems, menuPos % menuItems.Length);
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuPos -= 1;
                        continue;
                    case ConsoleKey.DownArrow:
                        menuPos += 1;
                        continue;
                    case ConsoleKey.Enter:
                        switch (Math.Abs(menuPos % menuItems.Length))
                        {
                            case 0:
                                Render.initialRender(false);
                                Render.initRender();
                                Render.renderMobs();
                                Render.renderUI();
                                return true;
                            case 1:
                                return false;
                            default: continue;
                        }
                    default:
                        continue;
                }
            }
        }
    }
}