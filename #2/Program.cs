using System.IO;

namespace Intership
{
    class Program
    {
        static long n, k, f;
        static long[,] a = new long[100, 100];

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("INPUT.TXT"))
            {
                string[] input = reader.ReadLine().Split();
                n = long.Parse(input[0]);
                k = long.Parse(input[1]);
            }

            Calculate(n, 0, 0);

            using (StreamWriter writer = new StreamWriter("OUTPUT.TXT"))
            {
                writer.Write(f);
            }
        }

        static void Calculate(long i, long t, long p)
        {
            p = f;

            if (i == 0)
            {
                if (t == k)
                    f++;
                return;
            }

            if (t + i <= k)
            {
                if (a[i - 1, t + 1] == 0)
                {
                    Calculate(i - 1, t + 1, p);
                }
                else if (a[i - 1, t + 1] > 0)
                {
                    f += a[i - 1, t + 1];
                }
            }

            if (t + i <= k)
            {
                if (a[i + 1, t + 1] == 0)
                {
                    Calculate(i + 1, t + 1, p);
                }
                else if (a[i + 1, t + 1] > 0)
                {
                    f += a[i + 1, t + 1];
                }
            }

            if (p != f)
            {
                a[i, t] = f - p;
            }
            else
            {
                a[i, t] = -1;
            }
        }
    }
}
