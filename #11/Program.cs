using System;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите текст:");
            Console.ResetColor();
            Console.Write("    ");
            string text = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(text))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите текст:");
                Console.ResetColor();
                Console.Write("    ");
                text = Console.ReadLine();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите текст:");
            Console.ResetColor();
            Console.WriteLine("    " + text);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите, на сколько букв производить сдвиг:");
            Console.ResetColor();
            int n;
            while (true)
            {
                try
                {
                    Console.Write("    n = ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    n = int.Parse(Console.ReadLine());

                    if (n < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n >> ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введено ненатуральное число! Повторите попытку:");
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
                    Console.WriteLine("Введено ненатуральное число! Повторите попытку:");
                    Console.ResetColor();
                }
            }

            text = Cryptography.Encrypt(text, n);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Зашифрованный текст:");
            Console.ResetColor();
            Console.WriteLine("    " + text);

            text = Cryptography.Decrypt(text, n);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Расшифрованный текст:");
            Console.ResetColor();
            Console.WriteLine("    " + text);
        }
    }
}
