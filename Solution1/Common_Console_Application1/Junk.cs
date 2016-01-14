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

        //public static void AI(int random)
        //{
        //    int rise, run;
        //    for (int i = 0; i < global.mobCount; i++)
        //    {
        //        if (global.monster[i].isAlive)
        //        {
        //            rise = Math.Abs(global.player.Coord.Y - global.monster[i].Coord.Y);
        //            run = Math.Abs(global.player.Coord.X - global.monster[i].Coord.X);
        //            if (Math.Abs(rise) + Math.Abs(run) <= 10)
        //            {
        //                if (rise + run <= 10)
        //                {
        //                    if (run > rise)
        //                    {
        //                        if (run < 0)
        //                        {
        //                            global.monster[i].Coord.X -= 1;
        //                            if (MCollision(i, random))
        //                            {
        //                                global.monster[i].Coord.X += 1;
        //                            }
        //                            else
        //                            {
        //                            }
        //                        }
        //                        else {
        //                            // right
        //                            global.monster[i].Coord.X += 1;
        //                            if (MCollision(i, random))
        //                            {
        //                                global.monster[i].Coord.X -= 1;
        //                            }
        //                            else
        //                            {
        //                            }
        //                        }
        //                    }
        //                    else {
        //                        if (rise < 0)
        //                        {
        //                            global.monster[i].Coord.Y += 1;
        //                            if (MCollision(i, random))
        //                            {
        //                                global.monster[i].Coord.Y -= 1;
        //                            }
        //                            else
        //                            {
        //                            }
        //                        }
        //                        else {
        //                            // down
        //                            global.monster[i].Coord.Y -= 1;
        //                            if (MCollision(i, random))
        //                            {
        //                                global.monster[i].Coord.Y += 1;
        //                            }
        //                            else
        //                            {
        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //            }
        //        }
        //    }
        //}
        //public static void AI(int random)
        //{
        //    int rise, run;
        //    for (int i = 0; i < global.mobCount; i++)
        //    {
        //        rise = Math.Abs(global.player.Coord.Y - global.monster[i].Coord.Y);
        //        run = Math.Abs(global.player.Coord.X - global.monster[i].Coord.X);
        //        if (Math.Abs(rise) + Math.Abs(run) <= 10)
        //        {
        //            if (rise + run <= 10)
        //            {
        //                if (run > rise)
        //                {
        //                    if (run < 0)
        //                    {
        //                        global.monster[i].Coord.X -= 1;
        //                        if (MCollision(i, random))
        //                        {
        //                            global.monster[i].Coord.X += 1;
        //                        }
        //                        else
        //                        {
        //                        }
        //                    }
        //                    else {
        //                        // right
        //                        global.monster[i].Coord.X += 1;
        //                        if (MCollision(i, random))
        //                        {
        //                            global.monster[i].Coord.X -= 1;
        //                        }
        //                        else
        //                        {
        //                        }
        //                    }
        //                }
        //                else {
        //                    if (rise < 0)
        //                    {
        //                        global.monster[i].Coord.Y += 1;
        //                        if (MCollision(i, random))
        //                        {
        //                            global.monster[i].Coord.Y -= 1;
        //                        }
        //                        else
        //                        {
        //                        }
        //                    }
        //                    else {
        //                        // down
        //                        global.monster[i].Coord.Y -= 1;
        //                        if (MCollision(i, random))
        //                        {
        //                            global.monster[i].Coord.Y += 1;
        //                        }
        //                        else
        //                        {
        //                        }

        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}