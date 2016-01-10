using Creature;
using Global;
using render;
using System;

namespace Common_Console_Application1
{
    internal class Program
    {
        private static Mob playerInput(ConsoleKeyInfo input, Mob player)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    return Mob.Movement(player, Mob.moveDirection.up);

                case ConsoleKey.DownArrow:
                    return Mob.Movement(player, Mob.moveDirection.down);

                case ConsoleKey.LeftArrow:
                    return Mob.Movement(player, Mob.moveDirection.left);

                case ConsoleKey.RightArrow:
                    return Mob.Movement(player, Mob.moveDirection.right);

                default:
                    return player;
            }
        }

        private static void Main(string[] args)
        {
            //Initializing variables
            Random random = new Random();
            ConsoleKeyInfo input;
            Mob player = new Mob(1, 1, random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));

            for (int i = 0; i <= global.mobCount - 1; i++)
            {
                global.monster[i] = new Mob(random.Next(1, 180), random.Next(1, 40), random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
            }

            Render.initialRender(player);

            //Main loop
            while (true)
            {
                input = Console.ReadKey();
                Render.clearMobs(player);
                player = playerInput(input, player);
                for (int i = 0; i <= global.mobCount - 1; i++)
                {
                    if (global.monster[i].isAlive)
                    {
                        Mob.Movement(i, random.Next(1, 6));

                        Mob.checkDamage(player, global.monster[i], random.Next(0, 5));
                        if (player.Exp == 5 * player.Lvl)
                        {
                            Mob.LevelUp(player, random.Next(3, 6), random.Next(0, 4), random.Next(10, 21));
                        }
                    }
                }
                Render.renderMobs(player);
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