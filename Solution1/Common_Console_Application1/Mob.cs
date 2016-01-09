using System;

namespace Creature
{
    internal class Mob
    { 
        public int x;
        public int y;
        public int HP;
        public int Str;
        public int Def;
        public int Lvl;
        public int Exp;
        public bool isAlive;

        public enum moveDirection { up, down, left, right, none }

        public Mob(int xPos, int yPos, int Health, int Strength, int Defense, int Level = 1, int Experience = 0)
        {
            x = xPos;
            y = yPos;
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
                    if (creature.y > 1)
                    {
                        creature.y -= 1;
                    }
                    return creature;

                case moveDirection.down:
                    if (creature.y < 39)
                    {
                        creature.y += 1;
                    }
                    return creature;

                case moveDirection.left:
                    if (creature.x > 1)
                    {
                        creature.x -= 1;
                    }
                    return creature;

                case moveDirection.right:
                    if (creature.x < 179)
                    {
                        creature.x += 1;
                    }
                    return creature;

                default:
                    return creature;
            }
        }

        public static Mob Movement(Mob creature, int moving)
        {
            switch (moving)
            {
                case 1:
                    if (creature.y > 1)
                    {
                        creature.y -= 1;
                    }
                    return creature;

                case 2:
                    if (creature.y < 39)
                    {
                        creature.y += 1;
                    }
                    return creature;

                case 3:
                    if (creature.x > 1)
                    {
                        creature.x -= 1;
                    }
                    return creature;

                case 4:
                    if (creature.x < 179)
                    {
                        creature.x += 1;
                    }
                    return creature;

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

        public static Mob isKilled(Mob player, Mob monster)
        {
            if (player.x == monster.x && player.y == monster.y)
            {
                monster.isAlive = false;
                return monster;
            }
            else return monster;
        }

        public static Mob CheckDamage(Mob attacker, Mob defender)
        {
            defender.HP -= (attacker.Str - defender.Def);
            return defender;
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