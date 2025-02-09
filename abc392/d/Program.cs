using System;
using System.Collections.Generic;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] K = new int[N];
            Dictionary<int, int>[] dice = new Dictionary<int, int>[N];

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                K[i] = int.Parse(tokens[0]);
                dice[i] = new Dictionary<int, int>();
                for (int j = 1; j <= K[i]; j++)
                {
                    int num = int.Parse(tokens[j]);
                    if (dice[i].ContainsKey(num))
                    {
                        dice[i][num]++;
                    }
                    else
                    {
                        dice[i][num] = 1;
                    }
                }
            }

            double maxProb = 0.0;

            for (int i = 0; i < N; i++)
            {
                var dice_i = dice[i];
                for (int j = i + 1; j < N; j++)
                {
                    var dice_j = dice[j];
                    double prob = 0.0;
                    foreach (var kvp in dice_i)
                    {
                        int num = kvp.Key;
                        int count_i = kvp.Value;
                        if (dice_j.ContainsKey(num))
                        {
                            int count_j = dice_j[num];
                            double pi = (double)count_i / K[i];
                            double pj = (double)count_j / K[j];
                            prob += pi * pj;
                        }
                    }
                    if (prob > maxProb)
                        maxProb = prob;
                }
            }

            Console.WriteLine("{0:F15}", maxProb);
        }
    }
}
