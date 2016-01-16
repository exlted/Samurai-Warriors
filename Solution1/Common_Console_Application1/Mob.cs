using Global;
using System;
using System.Drawing;

namespace Creature
{
    internal class Mob
    {
        private static Random random = new Random();
        public Point Coord = new Point();
        public int MaxHP;
        public int HP;
        public int Str;
        public int Def;
        public int Lvl;
        public int Exp;
        public bool isAlive;

        public enum moveDirection { up, down, left, right, none }

        public Mob(int xPos, int yPos, int Health, int Strength, int Defense, int Level = 1, int Experience = 0)
        {
            Coord.X = xPos;
            Coord.Y = yPos;
            MaxHP = Health;
            HP = Health;
            Str = Strength;
            Def = Defense;
            Lvl = Level;
            Exp = Experience;
            isAlive = true;
        }

        public static bool Movement(Mob.moveDirection moving, int random)
        {
            switch (moving)
            {
                case Mob.moveDirection.up:
                    global.player.Coord.Y -= 1;
                    if (PCollision(random))
                    {
                        global.player.Coord.Y += 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case Mob.moveDirection.down:
                    global.player.Coord.Y += 1;
                    if (PCollision(random))
                    {
                        global.player.Coord.Y -= 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case Mob.moveDirection.left:
                    global.player.Coord.X -= 1;
                    if (PCollision(random))
                    {
                        global.player.Coord.X += 1;
                        return false; ;
                    }
                    else
                    {
                        return true;
                    }

                case Mob.moveDirection.right:
                    global.player.Coord.X += 1;
                    if (PCollision(random))
                    {
                        global.player.Coord.X -= 1;
                        return false;
                    }
                    else return true;

                case Mob.moveDirection.none:
                    //global.player.isAlive = false;
                    //Console.Write(global.player.Coord.X + " " + global.player.Coord.Y);
                    return false;

                default:
                    return false;
            }
        }

        public static void AI()
        {
            Random random = new Random();
            int rise, run;
            for (int i = 0; i < global.mobCount; i++)
            {
                if (global.monster[global.currentFloor, i].isAlive)
                {
                    rise = global.player.Coord.Y - global.monster[global.currentFloor, i].Coord.Y;
                    run = global.player.Coord.X - global.monster[global.currentFloor, i].Coord.X;
                    if (Math.Abs(rise) + Math.Abs(run) <= 10 && random.Next(0, 101) > 10)
                    {
                        if (Math.Abs(run) > Math.Abs(rise))
                        {
                            if (run > 0)
                            {
                                global.monster[global.currentFloor, i].Coord.X += 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.X -= 1;
                                continue;
                            }
                            else {
                                global.monster[global.currentFloor, i].Coord.X -= 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.X += 1;
                                continue;
                            }
                        }
                        else {
                            if (rise > 0)
                            {
                                global.monster[global.currentFloor, i].Coord.Y += 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.Y -= 1;
                                continue;
                            }
                            else
                            {
                                global.monster[global.currentFloor, i].Coord.Y -= 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.Y += 1;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        switch (random.Next(1, 6))
                        {
                            case 1:
                                global.monster[global.currentFloor, i].Coord.Y -= 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.Y += 1;
                                continue;

                            case 2:
                                global.monster[global.currentFloor, i].Coord.Y += 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.Y -= 1;
                                continue;

                            case 3:
                                global.monster[global.currentFloor, i].Coord.X -= 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.X += 1;
                                continue;

                            case 4:
                                global.monster[global.currentFloor, i].Coord.X += 1;
                                if (MCollision(i, random.Next(0, 6)))
                                    global.monster[global.currentFloor, i].Coord.X -= 1;
                                continue;

                            default:
                                continue;
                        }
                    }
                }
            }
        }

        public static Mob LevelUp(Mob player, int StrRand, int DefRand, int HPRand)
        {
            Random random = new Random();
            player.Str += StrRand;
            player.Def += DefRand;
            player.MaxHP += HPRand;
            player.HP = player.MaxHP;
            player.Lvl += 1;
            player.Exp = 0;
            global.print("Level up!");
            return player;
        }

        public static void checkDamage(Mob attacker, Mob defender, int random)
        {
            Random random2 = new Random();
            if (attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) > 0)
            {
                defender.HP -= ((attacker.Str + (random - 2)) - defender.Def);
                if (defender.HP <= 0)
                {
                    defender.isAlive = false;
                    global.print("You defeated the enemy!");
                    attacker.Exp += 5 * defender.Lvl;
                }
                else global.print("Dealt " + ((attacker.Str + (random - 2)) - defender.Def) + " damage");
            }
            else if (((attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) <= 0)))
            {
                global.print("You missed...");
            }
            if (global.player.Exp >= global.player.Lvl * 5)
            {
                LevelUp(global.player, random2.Next(3, 6), random2.Next(0, 4), random2.Next(10, 20));
            }
        }

        public static void checkDamage(Mob attacker, Mob defender, int random, bool meaningless)
        {
            if (attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) > 0)
            {
                defender.HP -= ((attacker.Str + (random - 2)) - defender.Def);
                if (defender.HP <= 0)
                {
                    defender.isAlive = false;
                    global.print("You defeated the enemy!");
                    attacker.Exp += 5;
                }
                else global.print("Monster dealt " + ((attacker.Str + (random - 2)) - defender.Def) + " damage");
            }
            else if (((attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) <= 0)))
            {
                global.print("Monster missed...");
            }
        }

        private static bool PCollision(int random)
        {
            if (!(global.player.Coord.Y >= 40 || global.player.Coord.Y <= 0 || global.player.Coord.X <= 0 || global.player.Coord.X >= 180))
            {
                if (global.world[global.currentFloor][global.player.Coord].isPassable)
                {
                    for (int i = 0; i < global.mobCount; i++)
                    {
                        if (global.player.Coord == global.monster[global.currentFloor, i].Coord && global.monster[global.currentFloor, i].isAlive)
                        {
                            Mob.checkDamage(global.player, global.monster[global.currentFloor, i], random);
                            return true;
                        }
                    }
                    return false;
                }
                return true;
            }
            return true;
        }

        private static bool MCollision(int i, int random)
        {
            if (!(global.monster[global.currentFloor, i].Coord.Y >= 40 || global.monster[global.currentFloor, i].Coord.Y <= 0 || global.monster[global.currentFloor, i].Coord.X <= 0 || global.monster[global.currentFloor, i].Coord.X >= 180))
            {
                if (global.world[global.currentFloor][global.monster[global.currentFloor, i].Coord].isPassable)
                {
                    if (global.monster[global.currentFloor, i].Coord == global.player.Coord && global.player.isAlive)
                    {
                        Mob.checkDamage(global.monster[global.currentFloor, i], global.player, random, true);
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return true;
        }

        public static void spawnMonster(int Level = 1)
        {
            if (Level == 1)
                Level = global.currentFloor + 1;
            for (int i = 0; i < global.mobCount; i++)
            {
                while (true)
                {
                    global.monster[global.currentFloor, i].Coord.X = random.Next(1, 180);
                    global.monster[global.currentFloor, i].Coord.Y = random.Next(1, 40);
                    if (global.world[global.currentFloor][global.monster[global.currentFloor, i].Coord].isInside)
                    {
                        break;
                    }
                }
                global.monster[global.currentFloor, i].HP = random.Next(48, 61);
                global.monster[global.currentFloor, i].MaxHP = global.monster[global.currentFloor, i].HP;
                global.monster[global.currentFloor, i].Str = random.Next(5, 16);
                global.monster[global.currentFloor, i].Def = random.Next(0, 6);
                global.monster[global.currentFloor, i].Exp = 0;
                global.monster[global.currentFloor, i].Lvl = Level;
                for (int j = 1; j < Level; j++)
                {
                    Mob.LevelUp(global.monster[global.currentFloor, i], random.Next(3, 6), random.Next(0, 4), random.Next(10, 21));
                }
            }
            if(!global.usedLadder)
            {
                while (true)
                {
                    global.player.Coord.X = random.Next(1, 180);
                    global.player.Coord.Y = random.Next(1, 40);
                    if (global.world[global.currentFloor][global.player.Coord].isInside)
                    {
                        break;
                    }
                }
            }
            if(global.currentFloor == 0)
            {
                global.player.HP = random.Next(48, 61);
                global.player.MaxHP = global.player.HP;
                global.player.Str = random.Next(5, 16);
                global.player.Def = random.Next(0, 6);
                global.player.Exp = 0;
                global.player.Lvl = Level;
            }
            global.usedLadder = false;
        }

        public static bool checkWin()
        {
            for (int i = 0; i < global.mobCount; i++)
            {
                if (global.monster[global.currentFloor, i].isAlive)
                {
                    return false;
                }
            }
            return true;
        }

        public static void reInitPlayer()
        {
            global.player = new Mob(1, 1, random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
        }

    }
}