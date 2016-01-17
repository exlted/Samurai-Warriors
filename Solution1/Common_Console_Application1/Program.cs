/*
Samurai Warriors by Benjamin 'exlted' King and Trevor 'fritz1and2' Lory

It references Colorful Console by tomakita found at - https://github.com/tomakita/Colorful.Console

*/

using Creature;
using Global;
using menu;
using print;
using render;
using System;
using Console = Colorful.Console;
using World;

namespace Common_Console_Application1
{
    internal class Program
    {
        private static Random random = new Random();

        private static bool MainLoop()
        {
            ConsoleKeyInfo input;
            while (true)
            {
                global.Doooooom--;
                input = Console.ReadKey();
                Render.clearMobs();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        Mob.Movement(Mob.moveDirection.up, random.Next(0, 5));
                        break;

                    case ConsoleKey.DownArrow:
                        Mob.Movement(Mob.moveDirection.down, random.Next(0, 5));
                        break;

                    case ConsoleKey.LeftArrow:
                        Mob.Movement(Mob.moveDirection.left, random.Next(0, 5));
                        break;

                    case ConsoleKey.RightArrow:
                        Mob.Movement(Mob.moveDirection.right, random.Next(0, 5));
                        break;

                    case ConsoleKey.Escape:
                        if (!Menu.escapeMenu())
                            return true;
                        continue;
                    case ConsoleKey.Enter:
                        if(global.world[global.currentFloor][global.player.Coord].isDownLadder)
                        {
                            if(global.currentFloor == global.floorCount - 1)
                            {
                                Write.print("You Win!");
                                Write.rollCredits(global.credits);
                                return true;
                            }
                            global.currentFloor += 1;
                            global.usedLadder = true;
                            global.player.Coord = global.firstRooms[global.currentFloor];
                            return true;
                        }
                        else if(global.world[global.currentFloor][global.player.Coord].isUpLadder)
                        {
                            global.currentFloor -= 1;
                            global.usedLadder = true;
                            global.player.Coord = global.lastRooms[global.currentFloor];
                            return true;
                        }
                        continue;
                    default:
                        //return Mob.Movement(Mob.moveDirection.none, random.Next(0, 5));
                        //global.player.isAlive = false;
                        //global.print("test");
                        break;
                }
                Mob.AI();
                Render.renderMobs();
                Render.renderUI();
                if (!global.player.isAlive)
                {
                    Write.print("Game Over");
                    return true;
                }
                continue;
            }
        }

        private static void Main(string[] args)
        {
            Console.SetWindowSize(181, 46);
            Console.SetBufferSize(181, 46);
            if (Menu.menu() == 0)
            {
                World.world.initWorld();
                Render.initialRender();
                while (true)
                {
                    if (!global.usedLadder)
                    {
                        for (int h = 0; h < global.floorCount; h++)
                        {
                            for (int i = 0; i <= global.mobCount - 1; i++)
                            {
                                global.monster[h, i] = new Mob(random.Next(1, 180), random.Next(1, 40), random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
                            }
                            world.randomGen(20, 10, 0, h);
                            Mob.spawnMonster(h);
                            if (h>0)
                            {
                                world.ladderGen(h - 1);
                            }
                        }
                    }
                    Mob.initPlayer();
                    Render.initRender();
                    Render.renderMobs();
                    Render.renderUI();
                    if (MainLoop())
                    {
                        if(!global.usedLadder)
                        {
                            if (Menu.endMenu() == 0)
                            {
                                Mob.reInitPlayer();
                                world.worldReInit();
                                Render.initialRender();
                                continue;
                            }
                            else break;
                        }
                    }
                    else continue;
                }
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

                                    /)
                                   //
                 __*_             //
              /-(____)           //
             ////- -|\          //
          ,____o% -,_          //
         /  \\   |||  ;       //
        /____\....::./\      //
       _/__/#\_ _,,_/--\    //
       /___/######## \/""-(\</
      _/__/ '#######  ""^(/</
    __/ /   ,)))=:=(,    //.
   |,--\   /Q...... /.  (/
   /       .Q....../..\
          /.Q ..../...\
         /......./.....\
         /...../  \.....\
         /_.._./   \..._\
          (` )      (` )
          | /        \ |
          '(          )'
         /+|          |+\
         |,/          \,/
*/
