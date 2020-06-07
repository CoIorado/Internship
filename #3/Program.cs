using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = default;
            while (true)
            {
                try
                {
                    Console.Write("a = ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    a = double.Parse(Console.ReadLine());
                    Console.ResetColor();
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" >> Введено не число. Повторите попытку:");
                    Console.ResetColor();
                }
            }

            double result = f(a);

            Console.Write("f(a) = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(result);
            Console.ResetColor();
        }

        private static double f(double x)
        {
            if (x <= -1)
                return Math.Round(-1 / (x * x), 3);
            else if (x <= 2)
                return Math.Round(x * x, 3);
            else
                return 4;
        }

    }
}
