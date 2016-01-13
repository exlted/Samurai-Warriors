using Creature;
using Global;
using render;
using System;
using API;

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

        private static void Main(string[] args)
        {
            //Initializing variables
            ConsoleKeyInfo input;

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                global.monster[i] = new Mob(random.Next(1, 180), random.Next(1, 40), random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
            }

            Render.initialRender();
            Render.generateRooms(0,0,30,15);
            Render.initRender();
            Render.renderMobs();
            Render.renderUI();

            //Main loop
            while (true)
            {
                input = Console.ReadKey();
                Render.clearMobs();
                playerInput(input);
                for (int i = 0; i <= global.mobCount - 1; i++)
                {
                    if (global.monster[i].isAlive)
                    {
                        Mob.Movement(i, random.Next(1, 6), random.Next(0, 5));

                        Mob.checkDamage(global.player, global.monster[i], random.Next(0, 5));
                        if (global.player.Exp == 5 * global.player.Lvl)
                        {
                            Mob.LevelUp(global.player, random.Next(3, 6), random.Next(0, 4), random.Next(10, 21));
                        }
                    }
                }
                Render.renderMobs();
                Render.renderUI();
                if (!global.player.isAlive)
                {
                    global.print("Game Over");
                    break;
                }
                else if (global.checkWin())
                {
                    global.print("You Win!");
                    break;
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