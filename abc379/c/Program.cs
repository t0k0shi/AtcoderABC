using System;
using System.Linq;
using System.Numerics;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');
            long N = long.Parse(firstLine[0]);
            int M = int.Parse(firstLine[1]);
            var X = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var A = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            if (A.Sum() != N)
            {
                Console.WriteLine(-1);
                return;
            }
            var combined = X.Zip(A, (x, a) => new { x, a }).OrderBy(item => item.x).ToArray();
            BigInteger sumAiXi = 0;
            foreach (var item in combined)
            {
                sumAiXi += (BigInteger)item.a * item.x;
            }
            long cumulative = 0;
            long prev_x = 0;
            foreach (var item in combined)
            {
                long gap = item.x - prev_x - 1;
                if (cumulative < gap)
                {
                    Console.WriteLine(-1);
                    return;
                }
                cumulative -= gap;
                cumulative += item.a;
                if (cumulative < 1)
                {
                    Console.WriteLine(-1);
                    return;
                }
                cumulative -= 1;
                prev_x = item.x;
            }
            long remaining_gap = N - prev_x;
            if (cumulative < remaining_gap)
            {
                Console.WriteLine(-1);
                return;
            }
            BigInteger totalMoves = ((BigInteger)N * (N + 1)) / 2 - sumAiXi;
            Console.WriteLine(totalMoves);
        }
    }
}
