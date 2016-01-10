﻿using System;
using System.Drawing;
using System.Collections.Generic;
using Creature;
using render;
using World;

namespace Common_Console_Application1
{
    internal class Program
    {
        private static int mobCount = 10;

        private static Mob playerInput(ConsoleKeyInfo input, Mob player, Dictionary<Point, world> world)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    return Mob.Movement(player, Mob.moveDirection.up, world);

                case ConsoleKey.DownArrow:
                    return Mob.Movement(player, Mob.moveDirection.down, world);

                case ConsoleKey.LeftArrow:
                    return Mob.Movement(player, Mob.moveDirection.left, world);

                case ConsoleKey.RightArrow:
                    return Mob.Movement(player, Mob.moveDirection.right, world);

                default:
                    return player;
            }
        }

        private static void Main(string[] args)
        {
            //Initializing variables
            Dictionary<Point, world> world = new Dictionary<Point, world>();
            Random random = new Random();
            ConsoleKeyInfo input;
            Mob player = new Mob(1, 1, random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
            Mob[] monster = new Mob[mobCount];
            int textPos = 0;
            bool didDamage = false;

            for (int i = 0; i <= mobCount - 1; i++)
            {
                monster[i] = new Mob(random.Next(1, 180), random.Next(1, 40), random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
            }


            world = Render.initialRender(world);
            world = Render.generateWorld(world);
            Render.initRender(world);
            Render.renderMobs(player, monster, mobCount);
            Render.renderUI();

            //Main loop
            while (true)
            {
                input = Console.ReadKey();
                Render.clearMobs(player, monster, mobCount);
                player = playerInput(input, player, world);
                for (int i = 0; i <= mobCount - 1; i++)
                {
                    if (monster[i].isAlive)
                    {
                        Mob.Movement(monster[i], random.Next(1, 6) ,world);
                        
                        if(Mob.checkDamage(player, monster[i], random.Next(0, 5), textPos))
                        {
                            switch (textPos)
                            {
                                case 0:
                                    textPos = 1;
                                    break;
                                case 1:
                                    textPos = 2;
                                    break;
                                case 2:
                                    textPos = 0;
                                    break;
                                default:
                                    textPos = 0;
                                    break;
                            }
                        }
                        if (player.Exp == 5)
                        {
                            Mob.LevelUp(player, textPos, random.Next(3, 6), random.Next(0, 4), random.Next(10, 21));
                            switch (textPos)
                            {
                                case 0:
                                    textPos = 1;
                                    break;
                                case 1:
                                    textPos = 2;
                                    break;
                                case 2:
                                    textPos = 0;
                                    break;
                                default:
                                    textPos = 0;
                                    break;
                            }
                        }
                    }
                }
                Render.renderMobs(player, monster, mobCount);
            }
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