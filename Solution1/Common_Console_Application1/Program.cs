﻿using API;
using Creature;
using Global;
using render;
using System;
using menu;
using System.Threading;

namespace Common_Console_Application1
{
    internal class Program
    {
        private static Random random = new Random();

        private static bool playerInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    return Mob.Movement(Mob.moveDirection.up, random.Next(0, 5));

                case ConsoleKey.DownArrow:
                    return Mob.Movement(Mob.moveDirection.down, random.Next(0, 5));

                case ConsoleKey.LeftArrow:
                    return Mob.Movement(Mob.moveDirection.left, random.Next(0, 5));

                case ConsoleKey.RightArrow:
                    return Mob.Movement(Mob.moveDirection.right, random.Next(0, 5));

                default:
                    //return Mob.Movement(Mob.moveDirection.none, random.Next(0, 5));
                    //global.player.HP -= 5;
                    //global.print("test");
                    return false;
            }
        }

        private static bool MainLoop()
        {
            ConsoleKeyInfo input;
            while (true)
            {
                input = Console.ReadKey();
                Render.clearMobs();
                playerInput(input);
                Mob.AI();
                Render.renderMobs();
                Render.renderUI();
                if (!global.player.isAlive)
                {
                    global.print("Game Over");
                    return true;
                }
                else if (global.checkWin())
                {
                    global.print("You Win!");
                    return true;
                }
                continue;
            }
        }

        private static void Main(string[] args)
        {
            //Initializing variables
            if (Menu.menu())
            {
                while (true)
                {
                    for (int i = 0; i <= global.mobCount - 1; i++)
                    {
                        global.monster[i] = new Mob(random.Next(1, 180), random.Next(1, 40), random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
                    }
                    Render.initialRender();
                    Render.randomGen(3, 10, 0);
                    //Mob.spawnMonster();
                    Render.initRender();
                    Render.renderMobs();
                    Render.renderUI();
                    if (MainLoop())
                    {
                        if (Menu.endMenu())
                        {
                            global.reInitPlayer();
                            global.world.Clear();
                            continue;
                        }
                        else break;
                    }
                }
            }
            Capi.WaitForInput();
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
    Lv 1 Stats - Str (5-15) Def (0-5) Health (48 - 60)
*/