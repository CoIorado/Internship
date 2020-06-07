using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static double a1, a2, a3, M, N;
        static SortedDictionary<int, double> sequence = new SortedDictionary<int, double>();    //последовательность чисел в виде [индекс] - [значение]

        static void Main(string[] args)
        {
            a1 = ReadNum("a[1]");                                       //считывание данных
            a2 = ReadNum("a[2]");                                       //
            a3 = ReadNum("a[3]");                                       //
            M = ReadNum(nameof(M), true);                               //
            N = ReadNum(nameof(N));                                     //

            int j = 1;
            if (a1 == 0 && a2 == 0 && a3 == 0)                          //в случае, когда a1, a2, a3 равны нулю, функция f(a) не вызывается
            {
                for (j = 1; j <= 3; j++)
                    sequence.Add(j, 0);
                j--;
            }
            else
            {
                while (Math.Abs(a(j)) <= M)                             //доведение ряда до |aj| <= M
                {
                    j++;
                }
                sequence.Remove(j--);                                   //удаление из последовательности последнего элемента
            }

            Console.WriteLine();
            if (j == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ни один элемент последовательности не удовлетворяет неравенству ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("|aj| <= M");
                Console.ResetColor();
                return;
            }
            else
            {
                foreach (KeyValuePair<int, double> elem in sequence)    //вывод последовательности в консоль
                {                                                       //
                    Console.Write($"a[{elem.Key}] = ");                 //
                    Console.ForegroundColor = ConsoleColor.Cyan;        //
                    Console.WriteLine(elem.Value);                      //
                    Console.ResetColor();                               //
                }                                                       //

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n >> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Равенство |aj| = M ");
                if (Math.Abs(sequence[j]) == M)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("выполняется.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("не выполняется");
                }
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n >> ");
            if (j < N)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("j < N");
            }
            else if (j > N)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("j > N");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("j = N");
            }
            Console.ResetColor();
        }

        private static double a(int k)                                                         //рекурсивная функция вычисления ряда
        {
            if (k == 1)
            {
                sequence.TryAdd(k, a1);
                return a1;
            }
            if (k == 2)
            {
                sequence.TryAdd(k, a2);
                return a2;
            }
            if (k == 3)
            {
                sequence.TryAdd(k, a3);
                return a3;
            }

            double result = Math.Round(3 * a(k - 1) / 2 - 2 * a(k - 2) / 3 - a(k - 3) / 3, 3);
            sequence.TryAdd(k, result);
            return result;
        }

        private static double ReadNum(string varName, bool onlyPositive = false)               //функция для считывания ввода числа
        {
            double input;
            while (true)
            {
                try
                {
                    Console.Write($"{varName} = ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = double.Parse(Console.ReadLine());
                    Console.ResetColor();

                    if (onlyPositive && input < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" >> Допускаются только неотрицательные числа. Повторите попытку:");
                        Console.ResetColor();
                        continue;
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" >> Введено не число. Повторите попытку:");
                    Console.ResetColor();
                }
            }
            return input;
        }
    }
}
