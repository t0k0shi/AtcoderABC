using System;
using System.Collections.Generic;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = input[0];
            int Q = input[1];

            Dictionary<int, int> pigeonNest = new Dictionary<int, int>();
            int[] nestCount = new int[N + 1];
            int multipleNestCount = 0;

            for (int i = 1; i <= N; i++)
            {
                pigeonNest[i] = i;
                nestCount[i] = 1;
            }

            for (int q = 0; q < Q; q++)
            {
                string[] query = Console.ReadLine().Split();
                if (query[0] == "1")
                {
                    int P = int.Parse(query[1]);
                    int H = int.Parse(query[2]);
                    int oldNest = pigeonNest[P];

                    nestCount[oldNest]--;
                    if (nestCount[oldNest] == 1)
                    {
                        multipleNestCount--;
                    }

                    pigeonNest[P] = H;
                    if (nestCount[H] == 1)
                    {
                        multipleNestCount++;
                    }
                    nestCount[H]++;
                }
                else if (query[0] == "2")
                {
                    Console.WriteLine(multipleNestCount);
                }
            }
        }
    }
}
