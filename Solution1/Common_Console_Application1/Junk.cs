using Creature;
using Global;
using System;

namespace Common_Console_Application1
{
    internal class Junk
    {
        public static void spawnMonster(int Level = 1)
        {
            for (int i = 0; i < global.mobCount; i++)
            {
                Random random = new Random();
                while (true)
                {
                    global.monster[i].Coord.X = random.Next(1, 180);
                    global.monster[i].Coord.Y = random.Next(1, 40);
                    if (global.world[global.monster[i].Coord].isInside)
                    {
                        break;
                    }
                }
                global.monster[i].HP = random.Next(48, 61);
                global.monster[i].MaxHP = global.monster[i].HP;
                global.monster[i].Str = random.Next(5, 16);
                global.monster[i].Def = random.Next(0, 6);
                global.monster[i].Exp = 0;
                global.monster[i].Lvl = Level;
                for (int j = 1; j < Level; j++)
                {
                    Mob.LevelUp(global.monster[i], random.Next(3, 6), random.Next(0, 4), random.Next(10, 21));
                }
            }
        }
    }
}