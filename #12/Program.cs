using System;
using System.Linq;

namespace Intership
{
    class Program
    {
		static void Main(string[] args)
		{
            #region объявление данных
			int[] asc = ArrayGenerator.GetAscending(10);
			int[] decs = ArrayGenerator.GetDescending(10);
			int[] rnd = ArrayGenerator.GetRandom(10);

			int[] ascCopy = asc;
			int[] decsCopy = decs;
			int[] rndCopy = rnd;

			Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" >> ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Before sorting:\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("ASC ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in asc)
				Console.Write(num + " ");
            Console.WriteLine("\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("DEC ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in decs)
				Console.Write(num + " ");
			Console.WriteLine("\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("RND ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in rnd)
				Console.Write(num + " ");
			Console.WriteLine("\n");

			int[] comparisons = new int[3];
			comparisons.Select(num => num = 0);
			int[] swaps = new int[3];
			swaps.Select(num => num = 0);
            #endregion

            #region сортировка слиянием
            asc = Sorting.MergeSort(asc, ref comparisons[0], ref swaps[0]);
			decs = Sorting.MergeSort(decs, ref comparisons[1], ref swaps[1]);
			rnd = Sorting.MergeSort(rnd, ref comparisons[2], ref comparisons[2]);

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("\n\n >> ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("After merge sorting:\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("ASC ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in asc)
				Console.Write(num + " ");
			Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nCOM ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(comparisons[0]);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("SWA ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(swaps[0]);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\nDEC ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in decs)
				Console.Write(num + " ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("\nCOM ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(comparisons[1]);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("SWA ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(swaps[1]);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\nRND ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in rnd)
				Console.Write(num + " ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("\nCOM ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(comparisons[2]);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("SWA ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(swaps[2]);
            #endregion

            comparisons.Select(num => num = 0);
			swaps.Select(num => num = 0);

            #region сортировка подсчётом
            ascCopy = Sorting.CountingSort(ascCopy, ref comparisons[0], ref swaps[0]);
			decsCopy = Sorting.CountingSort(decsCopy, ref comparisons[1], ref swaps[1]);
			rndCopy = Sorting.CountingSort(rndCopy, ref comparisons[2], ref comparisons[2]);

			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("\n\n >> ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("After counting sorting:\n");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("ASC ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in asc)
				Console.Write(num + " ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("\nCOM ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(comparisons[0]);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("SWA ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(swaps[0]);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\nDEC ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in decs)
				Console.Write(num + " ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("\nCOM ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(comparisons[1]);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("SWA ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(swaps[1]);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\nRND ");
			Console.ForegroundColor = ConsoleColor.White;
			foreach (int num in rnd)
				Console.Write(num + " ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("\nCOM ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(comparisons[2]);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("SWA ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(swaps[2]);
            #endregion
        }
    }

    public static class Sorting
    {
		public static int[] MergeSort(int[] array, ref int comparisons, ref int swaps)
		{
			if (array.Length == 1)
			{
				return array;
			}

			int middle = array.Length / 2;
			return Merge(MergeSort(array.Take(middle).ToArray(), ref comparisons, ref swaps), MergeSort(array.Skip(middle).ToArray(), ref comparisons, ref swaps), ref comparisons, ref swaps);
		}           //функция сортировки массива методом слияния

		private static int[] Merge(int[] arr1, int[] arr2, ref int comparisons, ref int swaps)
		{
			int ptr1 = 0, ptr2 = 0;
			int[] merged = new int[arr1.Length + arr2.Length];

			for (int i = 0; i < merged.Length; i++)
			{
				if (ptr1 < arr1.Length && ptr2 < arr2.Length)
				{
					merged[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];

					swaps++;                                 //подсчет кол-ва пересылок
					comparisons += 3;                              //подсчет кол-ва сравнений
				}
				else
				{
					merged[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];

					swaps++;                                 //подсчет кол-ва пересылок
					if (ptr1 >= arr1.Length)                    //подсчет кол-ва сравнений
						comparisons += 2;                          //
					else                                        //
						comparisons += 3;                          //
				}
			}

			return merged;
		}   //функция слияния двух массивов с минимальной сортировкой

		public static int[] CountingSort(int[] array, ref int comparisons, ref int swaps)
		{
			//поиск минимального и максимального значений
			var min = array[0];
			var max = array[0];
			foreach (int element in array)
			{
				if (element > max)
				{
					max = element;
					comparisons += 1;
				}
				else if (element < min)
				{
					min = element;
					comparisons += 2;
				}
                else
                {
					comparisons += 2;
                }
			}

			int correctionFactor = min != 0 ? -min : 0;
			comparisons++;
			max += correctionFactor;

			var count = new int[max + 1];
			for (int i = 0; i < array.Length; i++)
			{
				count[array[i] + correctionFactor]++;
			}

			var index = 0;
			for (int i = 0; i < count.Length; i++)
			{
				for (var j = 0; j < count[i]; j++)
				{
					array[index] = i - correctionFactor;
					swaps++;
					index++;
				}
			}

			return array;
		}        //функция сортировки массива методом подсчета
	}

    public static class ArrayGenerator
    {
        public static int[] GetAscending(int size)
        {
			Random rnd = new Random();
			int[] array = new int[size];

			array[0] = rnd.Next(-100, 100);
            for (int i = 1; i < size; i++)
            {
				array[i] = rnd.Next(array[i - 1] + 1, array[i - 1] + 100);
            }

			return array;
        }    //функция генерации возрастающего массив

		public static int[] GetDescending(int size)
		{
			Random rnd = new Random();
			int[] array = new int[size];

			array[0] = rnd.Next(0, 100);
			for (int i = 1; i < size; i++)
			{
				array[i] = rnd.Next(array[i - 1] - 100, array[i - 1]);
			}

			return array;
		}   //функция генерации убывающего массива

		public static int[] GetRandom(int size)
		{
			Random rnd = new Random();
			int[] array = new int[size];

			for (int i = 0; i < size; i++)
			{
				array[i] = rnd.Next(-100, 100);
			}

			return array;
		}       //функция генерации неупорядоченного массива
	}
}
