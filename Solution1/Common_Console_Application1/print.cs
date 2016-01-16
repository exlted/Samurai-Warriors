using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace print
{
    class Write
    {
        private static string[] lastMessages = { "", "", "" };

        public static void print(string message)
        {
            lastMessages[2] = lastMessages[1];
            lastMessages[1] = lastMessages[0];
            lastMessages[0] = message;
            for (int h = 0; h < 3; h++)
            {
                switch (h)
                {
                    case 2:
                        Console.SetCursorPosition(129, 41);
                        Console.Write(lastMessages[h], Color.DarkGray);
                        for (int i = lastMessages[h].Length; i < 44; i++)
                        {
                            Console.Write(" ");
                        }
                        continue;

                    case 1:
                        Console.SetCursorPosition(129, 42);
                        Console.Write(lastMessages[h], Color.DarkGray);
                        for (int i = lastMessages[h].Length; i < 44; i++)
                        {
                            Console.Write(" ");
                        }
                        continue;

                    case 0:
                        Console.SetCursorPosition(129, 43);
                        Console.Write(lastMessages[h], Color.DarkGray);
                        for (int i = lastMessages[h].Length; i < 44; i++)
                        {
                            Console.Write(" ");
                        }
                        continue;

                    default:
                        break;
                }
            }
        }

        public static void print(int horizontal, int vertical, string message, bool isCentered = true)
        {
            if (isCentered)
            {
                Console.SetCursorPosition(horizontal - message.Length / 2, vertical);
                Console.Write(message, Color.DarkGray);
            }
            else
            {
                Console.SetCursorPosition(horizontal, vertical);
                Console.Write(message, Color.DarkGray);
            }
        }

        public static void print(int horizontal, int vertical, string[] message, bool isCentered = true)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if (isCentered)
                {
                    Console.SetCursorPosition(horizontal - message[i].Length / 2, vertical + i);
                    Console.Write(message[i], Color.DarkGray);
                }
                else
                {
                    Console.SetCursorPosition(horizontal - message[i].Length / 2, vertical + i);
                    Console.Write(message[i], Color.DarkGray);
                }
            }
        }

    }
}
