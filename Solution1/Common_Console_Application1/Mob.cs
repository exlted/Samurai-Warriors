using Global;
using System;
using System.Drawing;

namespace Creature
{
    internal class Mob
    {
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

        public static bool Movement(int i, int moving, int random)
        {
            switch (moving)
            {
                case 1:
                    global.monster[i].Coord.Y -= 1;
                    if (MCollision(i, random))
                    {
                        global.monster[i].Coord.Y += 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case 2:
                    global.monster[i].Coord.Y += 1;
                    if (MCollision(i, random))
                    {
                        global.monster[i].Coord.Y -= 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case 3:
                    global.monster[i].Coord.X -= 1;
                    if (MCollision(i, random))
                    {
                        global.monster[i].Coord.X += 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case 4:
                    global.monster[i].Coord.X += 1;
                    if (MCollision(i, random))
                    {
                        global.monster[i].Coord.X -= 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                default:
                    return false;
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
            if (attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) > 0)
            {
                defender.HP -= ((attacker.Str + (random - 2)) - defender.Def);
                if (defender.HP <= 0)
                {
                    defender.isAlive = false;
                    global.print("You defeated the enemy!");
                    attacker.Exp += 5;
                }
                else global.print("Dealt " + ((attacker.Str + (random - 2)) - defender.Def) + " damage");
            }
            else if (((attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) <= 0)))
            {
                global.print("You missed...");
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
                if (global.world[global.player.Coord].isPassable)
                {
                    for (int i = 0; i < global.mobCount; i++)
                    {
                        if (global.player.Coord == global.monster[i].Coord && global.monster[i].isAlive)
                        {
                            Mob.checkDamage(global.player, global.monster[i], random);
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        private static bool MCollision(int i, int random)
        {
            if (!(global.monster[i].Coord.Y >= 40 || global.monster[i].Coord.Y <= 0 || global.monster[i].Coord.X <= 0 || global.monster[i].Coord.X >= 180))
            {
                if (global.world[global.monster[i].Coord].isPassable)
                {
                    if (global.monster[i].Coord == global.player.Coord && global.player.isAlive)
                    {
                        Mob.checkDamage(global.monster[i], global.player, random, true);
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
    }
}