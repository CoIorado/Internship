using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";                                          //исходный вектор
            while (true)                                                //ввод данных и проверка
            {
                Console.Write("f = ");                                  //ввод вектора в консоль
                Console.ForegroundColor = ConsoleColor.Cyan;            //
                input = Console.ReadLine();                             //
                Console.ResetColor();                                   //

                while (input.Contains(" "))                             //удаление всех пробелов
                    input = input.Replace(" ", "");                     //

                bool isOnlyBinary = true;                               //гипотеза: в строке содержатся только двоичные символы - правда
                foreach (char c in input)
                {
                    if (c < '0' || c > '1')                             //если встречается символ отличный от 0 или 1, то
                    {                                                   //
                        isOnlyBinary = false;                           //гипотеза опровергнута
                        break;                                          //
                    }                                                   //
                }

                if (!isOnlyBinary)                                      //вывод пользователю ошибки в случае неверного символа в введенном векторе
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В векторе обнаружен неизвестный символ. Повторите попытку:");
                    Console.ResetColor();
                    continue;
                }

                if (Math.Log2(input.Length) != Math.Round(Math.Log2(input.Length)) || input.Length == 1)     //вывод пользователю ошибки в случае ввода неверного количества битов в векторе
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверное количество битов в векторе. Повторите попытку:");
                    Console.ResetColor();
                    continue;
                }

                break;
            }

            bool[] x = new bool[(int)Math.Log2(input.Length)];          //переменные

            List<int> indexesToDelete = new List<int>();                //индексы фиктивных битов, которые в дальнейшем необходимо удалить
            int pairs = 1;                                              //кол-во пар сравниваемых элементов
            for (int i = x.Length; i > 0; i--)                          //цикл повторяется кол-во раз, равное кол-ву переменных
            {
                int bitAmount = (int)Math.Pow(2, i - 1);                //по столько бит сравниваем каждую итерацию (кол-во битов в паре)

                bool isAllEqual = true;                                 //гипотеза: все рассматриваемые пары битов равны
                int current = 0;                                        //индекс текущего бита
                List<int> tmp = new List<int>();                        //индексы одной из пар на текущей итерации
                for (int j = 0; j < pairs; j++)                         //цикл повторяется кол-во раз, равное кол-ву пар
                {
                    string first = "";                                  //первая часть пары
                    for (int k = current; k < current + bitAmount; k++) //
                    {                                                   //
                        first += input[k];                              //заполнение первой части пары битами из вектора
                        tmp.Add(k);                                     //
                    }                                                   //
                    current += bitAmount;

                    string second = "";                                 //вторая часть пары
                    for (int k = current; k < current + bitAmount; k++) //
                        second += input[k];                             //заполнение второй части пары битами из вектора
                    current += bitAmount;

                    if (first != second)                                //сравнение частей пары
                    {                                                   //
                        isAllEqual = false;                             //
                        break;                                          //
                    }                                                   //
                }

                if (isAllEqual)                                         //если все рассматриваемые пары битов равны, то
                {                                                       //
                    x[x.Length - i] = false;                            //переменная считается фиктивной
                    foreach (int index in tmp)                          //
                        indexesToDelete.Add(index);                     //в список индексов для удаления добавляются индексы первых пар из текущей итерации
                }                                                       //
                else                                                    //иначе
                {                                                       //
                    x[x.Length - i] = true;                             //переменная считается существенной
                }                                                       //

                pairs *= 2;
            }

            Console.WriteLine();                                        //вывод информации о фиктивных/существенных переменных
            for (int i = 0; i < x.Length; i++)                          //
            {                                                           //
                Console.Write($"x{i + 1} - ");                          //
                                                                        //
                if (x[i])                                               //
                {                                                       //
                    Console.ForegroundColor = ConsoleColor.Green;       //
                    Console.WriteLine("существенная");                  //
                }                                                       //
                else                                                    //
                {                                                       //
                    Console.ForegroundColor = ConsoleColor.Red;         //
                    Console.WriteLine("фиктивная");                     //
                }                                                       //
                Console.ResetColor();                                   //
            }                                                           //

            string newVector = "";                                      //новый вектор (без фиктивных переменных)
            for (int i = 0; i < input.Length; i++)                      //
            {                                                           //
                if (!indexesToDelete.Contains(i))                       //заполнение нового вектора
                    newVector += input[i];                              //
            }                                                           //

            Console.Write("\nf = ");                                    //вывод нового вектора
            Console.ForegroundColor = ConsoleColor.Cyan;                //
            Console.WriteLine(newVector);                               //
            Console.ResetColor();                                       //
        }
    }
}
