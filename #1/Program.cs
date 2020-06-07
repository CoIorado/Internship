using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            string[][] inputForSolve;
            double answer;

            using (StreamReader reader = new StreamReader("INPUT.TXT"))
            {
                input = reader.ReadToEnd().Split('\n');
                inputForSolve = new string[input.Length][];
                for (int i = 0; i < input.Length; i++)
                {
                    string[] line = input[i].Split(' ');
                    inputForSolve[i] = new string[line.Length];
                    for (int j = 0; j < line.Length; j++)
                    {
                        inputForSolve[i][j] = line[j];
                    }
                }
            }

            answer = Solve(inputForSolve);

            using (StreamWriter writer = new StreamWriter("OUTPUT.TXT", false, System.Text.Encoding.Default))
            {
                if (Math.Round(answer) == answer)
                    writer.Write(answer + ".00");
                else
                    writer.Write(answer);
            }
        }

        public static double Solve(string[][] input)
        {
            double K = AsDouble(input[0][0]);
            double T = AsDouble(input[0][1]);

            List<double> Xs = new List<double>();
            List<double> Ys = new List<double>();
            List<double> Rs = new List<double>();

            for (int i = 1; i <= K; i++)
            {
                Xs.Add(AsDouble(input[i][0]));
                Ys.Add(AsDouble(input[i][1]));
                Rs.Add(AsDouble(input[i][2]));
            }

            if (K == 1)
            {
                return T;
            }

            double minDist = double.MaxValue;

            for (int i = 0; i < Xs.Count; i++)
            {
                for (int j = i + 1; j < Xs.Count; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(Xs[j] - Xs[i], 2) + Math.Pow(Ys[j] - Ys[i], 2)) - Rs[j] - Rs[i];

                    if (distance < minDist)
                        minDist = distance;
                }
            }

            if (minDist <= 0)
            {
                return 0;
            }
            else if (minDist > T * 2)
            {
                return T;
            }
            else
            {
                return Math.Round(minDist / 2, 2);
            }
        }

        public static double AsDouble(string s)
        {
            try
            {
                return double.Parse(s, CultureInfo.GetCultureInfo("en"));
            }
            catch (FormatException)
            {
                return double.Parse(s, CultureInfo.InvariantCulture);
            }
        }

    }
}
