using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n;                                                 //размерность матрицы
            while (true)                                            //ввод с проверкой
            {
                try
                {
                    Console.Write("n = ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    n = uint.Parse(Console.ReadLine());

                    if (n < 2)
                        throw new FormatException();

                    Console.ResetColor();
                    break;
                }
                catch (Exception)
                {
                    WriteError(" >> Неверный ввод. Введите натуральное число (>= 2):");
                    continue;
                }
            }

            double[,] matrix = new double[n, n];                    //сама матрица
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n >> ");
            Console.ResetColor();
            Console.WriteLine("Введите матрицу по строкам:");
            for (int i = 0; i < n; i++)                             //ввод матрицы с проверкой
            {
                string[] line;                                      //строка матрицы
                while (true)
                {
                    Console.Write($"[{i + 1}]: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string input = Console.ReadLine().Trim();       //ввод пользователя
                    while (input.Contains("  "))                    //удаление лишних пробелов
                        input = input.Replace("  ", " ");           //
                    line = input.Split();                           //разделение ввода на массив элементов

                    if (line.Length != n)                           //если кол-во элементов в строке не равно заданному n, то ввод считается неверным
                    {
                        WriteError(" >> Неверная длина строки. Повторите попытку:");
                        continue;
                    }

                    bool isCorrect = true;                          //гипотеза: строка введена верно
                    foreach (string num in line)                    //если какой-либо элемент введенной строки не явл. числом, то гипотеза опровергнута
                    {
                        try { double.Parse(num); }
                        catch (FormatException)
                        {
                            WriteError(" >> Введено не число. Повторите попытку:");
                            isCorrect = false;
                            break;
                        }
                    }

                    if (!isCorrect)
                        continue;

                    Console.ResetColor();
                    break;
                }
                for (int j = 0; j < n; j++)                         //заполнение матрицы введенными значениями
                    matrix[i, j] = double.Parse(line[j]);           //
            }

            byte[] sequence = new byte[n];                          //последовательность нулей и единиц

            for (int i = 0; i < n; i++)                             //проход по строкам матрицы
            {
                bool isAscending = true, isDescending = true;       //две гипотезы: строка является возрастающей, и строка является убывающей

                for (int j = 1; j < n; j++)                         //проход по элементам строки
                {                                                   //
                    if (matrix[i, j] >= matrix[i, j - 1])           //если хотя бы один следующий элемент >= предыдущего,
                        isDescending = false;                       //то i-ая строка не явл. убывающей
                    if (matrix[i, j] <= matrix[i, j - 1])           //если хотя бы один следующий элемент <= предыдущего,
                        isAscending = false;                        //то i-ая строка не явл. возрастающей

                    if (!isAscending && !isDescending)
                        break;
                }

                if (isAscending || isDescending)                    //заполнение последовательности нулей и единиц
                    sequence[i] = 1;
                else
                    sequence[i] = 0;
            }

            Console.Write("\nb: ");                                 //вывод последовательности нулей и единиц
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (int num in sequence)
                Console.Write(num + " ");
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
