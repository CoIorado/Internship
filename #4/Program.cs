using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                try
                {
                    Console.Write("n = ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    n = int.Parse(Console.ReadLine());

                    if (n < 1)
                        throw new FormatException();

                    Console.ResetColor();
                    break;
                }
                catch (FormatException)
                {
                    WriteError(" >> Неверный ввод. Введите натуральное число:");
                }
            }

            string[] line;
            List<int> binary = new List<int>(n + 1);
            while (true)
            {
                Console.Write("ai: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine().Trim();
                while (input.Contains("  "))
                    input = input.Replace("  ", " ");
                line = input.Split();

                if (line.Length != n + 1)
                {
                    WriteError(" >> Неверная длина последовательности. Повторите попытку:");
                    continue;
                }

                bool isCorrect = true;
                foreach (string num in line)
                {
                    try { int.Parse(num); }
                    catch (FormatException)
                    {
                        WriteError(" >> В последовательности битов обнаружен сторонний символ. Повторите попытку:");
                        isCorrect = false;
                        break;
                    }

                    if (num != "0" && num != "1")
                    {
                        WriteError(" >> В последовательности битов обнаружено стороннее число. Повторите попытку:");
                        isCorrect = false;
                        break;
                    }
                }

                if (!isCorrect)
                    continue;

                if (int.Parse(line[^1]) == 0)
                {
                    WriteError(" >> Последовательность ai не может оканчиваться нулем. Повторите попытку:");
                    continue;
                }

                Console.ResetColor();
                break;

            }
            for (int i = 0; i < line.Length; i++)
                binary.Add(int.Parse(line[i]));

            int p = 0;
            for (int i = n; i > -1; i--)
                p += (int)Math.Pow(2, i) * binary[n - i];

            p++;
            binary.Clear();

            while (p != 0)
            {
                binary.Add(p % 2);
                p /= 2;
            }
            binary.Reverse();

            Console.Write("p + 1 = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (int bit in binary)
                Console.Write(bit + " ");
            Console.ResetColor();
        }

        private static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
