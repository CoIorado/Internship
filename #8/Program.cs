using System;
using System.Collections.Generic;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] incMatrix = RandomMatrix();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Матрица инцидентности:\n");
            Console.ResetColor();
            PrintMatrix(incMatrix, "    ");
            Console.WriteLine();

            int[,] adjMatrix = AdjMatrix(incMatrix);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Матрица смежности:\n");
            Console.ResetColor();
            PrintMatrix(adjMatrix, "    ");
            Console.WriteLine();

            var comps = FindComps(adjMatrix);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" >> Граф имеет ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(comps.Count);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (comps.Count % 10 == 1)
                Console.WriteLine(" компоненту связности:\n");
            else if (comps.Count % 10 >= 2 && comps.Count % 10 <= 4)
                Console.WriteLine(" компоненты связности:\n");
            else
                Console.WriteLine(" компонент связности:\n");
            Console.ResetColor();

            for (int i = 0; i < comps.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"    Component #{i + 1}: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(comps[i]);
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private static void DFS(int v, ref bool[] used, ref List<int> comps, int[,] matrix)  //функция обхода графа в глубину
        {
            used[v] = true;
            comps.Add(v + 1);

            List<int> vertexes = new List<int>();                       //список вершин, с которыми связана вершина v
            for (int i = 0; i < matrix.GetLength(0); i++)               //заполнение списка
            {
                if (matrix[v, i] == 1)
                    vertexes.Add(i);
            }

            for (int i = 0; i < vertexes.Count; i++)                    //рекурсивный обход каждой вершины
            {
                int to = vertexes[i];
                if (!used[to])
                    DFS(to, ref used, ref comps, matrix);
            }
        }

        private static List<string> FindComps(int[,] matrix)                //функция нахождения компонент связности графа
        {
            int n = matrix.GetLength(0);                                    //размерность матрицы
            bool[] used = new bool[n];                                      //логический массив, хранящий информацию о прохождении каждой из вершин (true - через вершину проходили; false - нет)
            List<int> comp = new List<int>();                               //список-компонента связности, хранящий номера вершин
            List<string> result = new List<string>();                       //список компонент связности, хранящихся в виде строк из списка вершин

            for (int i = 0; i < n; i++)                                     //иниализация логического массива по умолчанию
                used[i] = false;

            for (int i = 0; i < n; i++)                                     //проход по вершинам
            {
                if (!used[i])                                               //если вершина еще не была пройдена, то
                {
                    comp.Clear();                                           //предыдущая компонента связности удаляется из памяти,
                    DFS(i, ref used, ref comp, matrix);                     //выполняется проход в глубину и "сбор" новой компоненты,

                    comp.Sort();                                            //вершины сортируются по возрастанию,
                    string tmp = "";                                        //
                    for (int j = 0; j < comp.Count; j++)                    //последовательность вершин записывается в строчную переменную tmp,
                        tmp += comp[j] + " ";                               //

                    result.Add(tmp);                                        //в список результата добавляется полученная строка, представляющая компоненту связности
                }
            }
            return result;
        }

        private static int[,] AdjMatrix(int[,] incMatrix)                   //функция преобразования матрицы инцидентности в матрицу смежности
        {
            int n = incMatrix.GetLength(0);
            int[,] adjMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    adjMatrix[i, j] = 0;
                }
            }

            for (int j = 0; j < incMatrix.GetLength(1); j++)
            {
                List<int> vertexes = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    if (incMatrix[i, j] == 1)
                        vertexes.Add(i);
                }
                adjMatrix[vertexes[0], vertexes[1]] = 1;
                adjMatrix[vertexes[1], vertexes[0]] = 1;
            }

            return adjMatrix;
        }

        private static int[,] RandomMatrix()                                //функция генерации случайной матрицы инцидентности
        {
            Random rnd = new Random();
            int vertex = rnd.Next(3, 10);
            int maxEdges = vertex * (vertex - 1) / 2;
            int edges = rnd.Next(1, maxEdges + 1);
            int[,] incMatrix = new int[vertex, edges];

            for (int j = 0; j < edges; j++)
            {
                for (int i = 0; i < vertex; i++)
                {
                    incMatrix[i, j] = 0;
                }

                int v1 = rnd.Next(0, vertex);
                int v2 = rnd.Next(0, vertex);
                while (v1 == v2)
                    v2 = rnd.Next(0, vertex);

                incMatrix[v1, j] = 1;
                incMatrix[v2, j] = 1;
            }

            return incMatrix;
        }

        private static void PrintMatrix(int[,] matrix, string bound = "")   //функция печати матрицы
        {
            Console.ResetColor();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(bound);
                if (matrix[i, 0] != 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(matrix[i, 0] + " ");
                Console.ResetColor();

                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] != 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matrix[i, j] + " ");
                    Console.ResetColor();
                }

                if (matrix[i, matrix.GetLength(1) - 1] != 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(matrix[i, matrix.GetLength(1) - 1]);
                Console.ResetColor();
                Console.Write(bound);

                Console.WriteLine();
            }
        }
    }
}
