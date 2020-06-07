using System;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = CreateList();
            Console.WriteLine();
            list.Print();
        }

        static LinkedList CreateList()
        {
            Console.ResetColor();
            int N;

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" N = ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    N = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    if (N < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n >> ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Длина списка не может быть отрицательной! Повторите попытку:\n");
                        Console.ResetColor();
                        continue;
                    }

                    if (N == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n >> ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Длина списка не должна быть нулевой! Повторите попытку:\n");
                        Console.ResetColor();
                        continue;
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n >> ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод! Введите целое положительное число:\n");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            LinkedList list = new LinkedList();

            for (int i = 0; i < N; i++)
            {
                int input;
                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($" #{i + 1} = ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        input = int.Parse(Console.ReadLine());
                        Console.ResetColor();

                        break;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n >> ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный ввод! Введите целое число:\n");
                        Console.ResetColor();
                    }
                }

                list.AddRight(input);
            }

            return list;
        }
    }
}
