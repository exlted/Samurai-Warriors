using System;
using System.Text;
using API;

namespace Common_Console_Application1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
            char[] ascii = new char[41];
            if (true)
            {
                ascii[0] = Convert.ToChar(169);
                ascii[1] = Convert.ToChar(170);
                int i = 2;
                for (char c = (char)179; c <= (char)218; ++c)
                {
                    ascii[i] = c;
                    i++;
                    if(i>40)
                    {
                        Console.WriteLine("Table not large enough!");
                        break;
                    }
                }
            }
            int k = 0;
            for (int i = 0; i < (Console.WindowWidth-10); i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(ascii[k]);
                    k += 1;
                    if(k>40)
                    {
                        k = 0;
                    }
                }
            }
            Capi.WaitForInput();
        }
    }
}
