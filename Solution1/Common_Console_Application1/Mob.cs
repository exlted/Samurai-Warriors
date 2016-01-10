using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using World;

namespace Creature
{
    internal class Mob
    {
        public Point Coord = new Point();
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
            HP = Health;
            Str = Strength;
            Def = Defense;
            Lvl = Level;
            Exp = Experience;
            isAlive = true;
        }

        public static Mob Movement(Mob creature, moveDirection moving, Dictionary<Point, world> world)
        {
            switch (moving)
            {
                case moveDirection.up:
                    creature.Coord.Y -= 1;
                    if (world[creature.Coord].isPassable)
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
                    if (world[creature.Coord].isPassable)
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
                    if (world[creature.Coord].isPassable)
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
                    if (world[creature.Coord].isPassable)
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

        public static Mob Movement(Mob creature, int moving, Dictionary<Point, world> world)
        {
            switch (moving)
            {
                case 1:
                    creature.Coord.Y -= 1;
                    if (world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.Y += 1;
                        return creature;
                    }

                case 2:
                    creature.Coord.Y += 1;
                    if (world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.Y -= 1;
                        return creature;
                    }

                case 3:
                    creature.Coord.X -= 1;
                    if (world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.X += 1;
                        return creature;
                    }

                case 4:
                    creature.Coord.X += 1;
                    if (world[creature.Coord].isPassable)
                    {
                        return creature;
                    }
                    else
                    {
                        creature.Coord.X -= 1;
                        return creature;
                    }

                default:
                    return creature;
            }
        }

        public static Mob LevelUp(Mob player, int textPos, int StrRand, int DefRand, int HPRand)
        {
            Random random = new Random();
            player.Str += StrRand;
            player.Def += DefRand;
            player.HP += HPRand;
            player.Lvl += 1;
            player.Exp = 0;
            switch (textPos)
            {
                case 0:
                    Console.SetCursorPosition(122, 41);
                    break;
                case 1:
                    Console.SetCursorPosition(122, 42);
                    break;
                case 2:
                    Console.SetCursorPosition(122, 43);
                    break;
                default:
                    Console.SetCursorPosition(122, 43);
                    break;
            }
            Console.Write("Level up!                         ");
            return player;
        }

        public static bool checkDamage(Mob attacker, Mob defender, int random, int textPos)
        {
            switch (textPos)
            {
                case 0:
                    Console.SetCursorPosition(122, 41);
                    break;
                case 1:
                    Console.SetCursorPosition(122, 42);
                    break;
                case 2:
                    Console.SetCursorPosition(122, 43);
                    break;
                default:
                    Console.SetCursorPosition(122, 43);
                    break;
            }
            if (attacker.Coord == defender.Coord && ((attacker.Str + (random - 2)) - defender.Def) > 0)
            {
                defender.HP -= ((attacker.Str + (random - 2)) - defender.Def);
                if (defender.HP<=0)
                {
                    defender.isAlive = false;
                    Console.Write("You defeated the enemy!                         ");
                    attacker.Exp += 5;
                }
                else Console.Write("dealt " + ((attacker.Str + (random - 2)) - defender.Def) + " damage                    ");
                return true;
            }
            else if(((attacker.Str + (random - 2)) - defender.Def) <= 0)
            {
                Console.Write("You missed...                 ");
                return true;
            }
            else return false;
        }

        //public static Mob CheckCollision(Mob creature, moveDirection moving)
        //{
        //    switch (moving)
        //    {
        //        case moveDirection.up:
        //
        //        case moveDirection.down:
        //
        //        case moveDirection.left:
        //
        //        case moveDirection.right:
        //
        //        default:
        //            return creature;
        //    }
        //}
    }
}