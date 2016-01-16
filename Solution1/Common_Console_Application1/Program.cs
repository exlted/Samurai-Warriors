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
                            global.currentFloor += 1;
                            global.usedLadder = true;
                            return true;
                        }
                        else if(global.world[global.currentFloor][global.player.Coord].isUpLadder)
                        {
                            global.currentFloor -= 1;
                            global.usedLadder = true;
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
                else if (Mob.checkWin())
                {
                    if (global.currentFloor != global.floorCount - 1)
                    {
                        Write.print("You beat this floor");
                        global.currentFloor += 1;
                        return false;
                    }
                    else
                    {
                        Write.print("You win!");
                        return true;
                    }
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
                    if (global.currentFloor == 0)
                    {
                        for (int h = 0; h < global.floorCount; h++)
                        {
                            for (int i = 0; i <= global.mobCount - 1; i++)
                            {
                                global.monster[h, i] = new Mob(random.Next(1, 180), random.Next(1, 40), random.Next(48, 61), random.Next(5, 16), random.Next(0, 6));
                            }
                            Render.randomGen(20, 10, 0, h);
                            if(h>0)
                            {
                                Render.ladderGen(h - 1);
                            }
                        }
                    }
            
                    Mob.spawnMonster();
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
