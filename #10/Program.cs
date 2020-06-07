using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ввод данных
            BinaryTree tree = Generator.RandomBinaryTree(TreeType.Balanced);
            #endregion

            #region идеально сбалансированное дерево
            tree.PrintAdvanced();

            List<int> levelList;
            List<int> lvlOrder = tree.Levelorder(out levelList);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Количество вершин на уровнях:");
            for (int i = 0; i < levelList.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"LVL#{i + 1} - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(levelList[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" v.");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Обход дерева по уровням:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
            Console.ResetColor();
            foreach (int node in lvlOrder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine("\n\n");
            #endregion

            #region дерево поиска
            tree.IntoSearch();
            tree.PrintAdvanced();

            lvlOrder = tree.Levelorder(out levelList);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Количество вершин на уровнях:");
            for (int i = 0; i < levelList.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"LVL#{i + 1} - ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(levelList[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" v.");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n >> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Обход дерева по уровням:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
            Console.ResetColor();
            foreach (int node in lvlOrder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }

    class Generator
    {
        public static BinaryTree RandomBinaryTree(TreeType treeType)
        {
            Random rnd = new Random();
            object syncLock = new object();
            BinaryTree tree = new BinaryTree(treeType);

            int count = rnd.Next(5, 10);
            for (int i = 0; i < count; i++)
            {
                int randomNumber;
                lock (syncLock)
                {
                    randomNumber = rnd.Next(-100, 100);
                }

                try
                {
                    tree.Add(randomNumber);
                }
                catch (SameDataException)
                {
                    i--;
                }
            }

            return tree;
        }
    }
}
