using System;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            long[] A = Console.ReadLine().Split().Select(long.Parse).ToArray();

            if (N == 2)
            {
                Console.WriteLine("Yes");
                return;
            }

            bool isGeometric = true;
            long baseMul = A[1];
            long baseDiv = A[0];

            for (int i = 2; i < N; i++)
            {
                if (A[i] * baseDiv != A[i - 1] * baseMul)
                {
                    isGeometric = false;
                    break;
                }
            }

            Console.WriteLine(isGeometric ? "Yes" : "No");
        }
    }
}
