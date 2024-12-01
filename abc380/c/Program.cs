using System;
using System.Text;
using System.Collections.Generic;

namespace x
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);
            string S = Console.ReadLine();

            int i = 0;
            List<(int l, int r)> oneBlocks = new List<(int, int)>();

            while (i < N)
            {
                if (S[i] == '1')
                {
                    int l = i;
                    while (i < N && S[i] == '1') i++;
                    int r = i - 1;
                    oneBlocks.Add((l, r));
                }
                else
                {
                    i++;
                }
            }

            if (oneBlocks.Count >= K)
            {
                int lKMinus1 = oneBlocks[K - 2].l;
                int rKMinus1 = oneBlocks[K - 2].r;
                int lK = oneBlocks[K - 1].l;
                int rK = oneBlocks[K - 1].r;

                char[] T = new char[N];

                for (int idx = 0; idx <= rKMinus1; idx++)
                {
                    T[idx] = S[idx];
                }

                int lenK = rK - lK + 1;

                for (int idx = rKMinus1 + 1; idx <= rKMinus1 + lenK; idx++)
                {
                    T[idx] = '1';
                }

                for (int idx = rKMinus1 + lenK + 1; idx <= rK; idx++)
                {
                    T[idx] = '0';
                }

                for (int idx = rK + 1; idx < N; idx++)
                {
                    T[idx] = S[idx];
                }

                Console.WriteLine(new string(T));
            }
            else
            {
                Console.WriteLine(S);
            }
        }
    }
}
