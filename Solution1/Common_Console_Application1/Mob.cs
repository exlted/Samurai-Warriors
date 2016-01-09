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

        public static Mob LevelUp(Mob player)
        {
            Random random = new Random();
            player.Str += random.Next(3, 6);
            player.Def += random.Next(0, 4);
            player.HP += random.Next(10, 21);
            player.Lvl += 1;
            player.Exp = 0;
            return player;
        }

        public static Mob checkDamage(Mob attacker, Mob defender, int random)
        {
            if (attacker.Coord == defender.Coord)
            {
                defender.HP -= ((attacker.Str + (random - 2)) - defender.Def);
                Console.SetCursorPosition(1, 43);
                Console.Write("dealt " + ((attacker.Str + (random - 2)) - defender.Def) + " damage");
                if (defender.HP<=0)
                {
                    defender.isAlive = false;
                }
                return defender;
            }
            else return defender;
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