using System;

namespace API
{
    public class Capi
    {
        public static string Read()//Shortcut for Console.ReadLine
        {
            string input = Console.ReadLine();
            return input;
        }

        public static char WaitForInput() //waits for any button press and returns pressed key, if key has no associated character, returns a instead
        {
            char input;
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Press Any Key to Continue");
            try
            {
                input = Convert.ToChar(Console.ReadKey());
                return input;
            }
            catch
            {
                return Convert.ToChar('a');
            }
        }
    }
}