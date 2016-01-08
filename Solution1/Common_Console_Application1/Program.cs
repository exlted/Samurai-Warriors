using Creature;
using Render;
using System;

namespace Common_Console_Application1
{
    internal class Program
    {
        private static int mobCount = 10;

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
            Mob player = new Mob(1, 1);
            Mob[] monster = new Mob[mobCount];

            for (int i = 0; i <= mobCount - 1; i++)
            {
                monster[i] = new Mob(random.Next(1, 179), random.Next(1, 39));
            }
            render.initialRender(player, monster, mobCount);

            //Main loop
            while (true)
            {
                player = playerInput(Console.ReadKey(), player);
                render.clearMobs(player, monster, mobCount);
                for (int i = 0; i <= mobCount - 1; i++)
                {
                    if (monster[i].isAlive)
                    {
                        Mob.Movement(monster[i], random.Next(1, 6));
                        Mob.isKilled(player, monster[i]);
                    }
                }
                render.renderMobs(player, monster, mobCount);
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