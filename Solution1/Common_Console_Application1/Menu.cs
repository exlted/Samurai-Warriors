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
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuPos -= 1;
                        renderMenu(menuItems, menuPos % menuItems.Length);
                        continue;
                    case ConsoleKey.DownArrow:
                        menuPos += 1;
                        renderMenu(menuItems, menuPos % menuItems.Length);
                        continue;
                    case ConsoleKey.Enter:
                        switch(menuPos % menuItems.Length)
                        {
                            case 0:
                                return 0;
                            case 1:
                                credits();
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
                        Mob.reInitPlayer();
                        world.worldReInit();
                        Render.initialRender();
                        return true;

                    case ConsoleKey.D2:
                        return false;

                    case ConsoleKey.NumPad1:
                        Mob.reInitPlayer();
                        world.worldReInit();
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
                            Mob.reInitPlayer();
                            world.worldReInit();
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

        public static void credits()
        {

        }

    }
}