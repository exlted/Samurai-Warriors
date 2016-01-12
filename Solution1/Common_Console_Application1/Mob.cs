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

        public static Mob Movement(Mob creature, moveDirection moving)
        {
            switch (moving)
            {
                case moveDirection.up:
                    creature.Coord.Y -= 1;
                    if (global.world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.Y += 1;
                        return creature;
                    }

                case moveDirection.down:
                    creature.Coord.Y += 1;
                    if (global.world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.Y -= 1;
                        return creature;
                    }

                case moveDirection.left:
                    creature.Coord.X -= 1;
                    if (global.world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.X += 1;
                        return creature;
                    }

                case moveDirection.right:
                    creature.Coord.X += 1;
                    if (global.world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.X -= 1;
                        return creature;
                    }

                case moveDirection.none:
                    Console.Write(creature.Coord.X + " " + creature.Coord.Y);
                    return creature;

                default:
                    return creature;
            }
        }

        public static Mob Movement(int i, int moving)
        {
            switch (moving)
            {
                case 1:
                    global.monster[i].Coord.Y -= 1;
                    if (global.world[global.monster[i].Coord].isPassable)
                    {
                        return global.monster[i];
                    }
                    else
                    {
                        global.monster[i].Coord.Y += 1;
                        return global.monster[i];
                    }

                case 2:
                    global.monster[i].Coord.Y += 1;
                    if (global.world[global.monster[i].Coord].isPassable)
                    {
                        return global.monster[i];
                    }
                    else
                    {
                        global.monster[i].Coord.Y -= 1;
                        return global.monster[i];
                    }

                case 3:
                    global.monster[i].Coord.X -= 1;
                    if (global.world[global.monster[i].Coord].isPassable)
                    {
                        return global.monster[i];
                    }
                    else
                    {
                        global.monster[i].Coord.X += 1;
                        return global.monster[i];
                    }

                case 4:
                    global.monster[i].Coord.X += 1;
                    if (global.world[global.monster[i].Coord].isPassable)
                    {
                        return global.monster[i];
                    }
                    else
                    {
                        global.monster[i].Coord.X -= 1;
                        return global.monster[i];
                    }

                default:
                    return global.monster[i];
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
            global.print("Level up!                         ");
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
                    global.print("You defeated the enemy!                   ");
                    attacker.Exp += 5;
                }
                else global.print("Dealt " + ((attacker.Str + (random - 2)) - defender.Def) + " damage                    ");
            }
            else if (((attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) <= 0)))
            {
                global.print("You missed...                 ");
            }
        }
    }
}