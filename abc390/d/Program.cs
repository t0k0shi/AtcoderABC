using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            long[] A = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            Console.WriteLine(SolveStoneBagsProblem(N, A));
        }

        static int SolveStoneBagsProblem(int N, long[] A)
        {
            HashSet<long> results = new HashSet<long>();
            EnumeratePartitions(0, new List<long>(), A, results);
            return results.Count;
        }

        static void EnumeratePartitions(int index, List<long> groups, long[] A, HashSet<long> results)
        {
            if (index == A.Length)
            {
                long xorVal = 0;
                for (int i = 0; i < groups.Count; i++)
                {
                    xorVal ^= groups[i];
                }
                results.Add(xorVal);
                return;
            }
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i] += A[index];
                EnumeratePartitions(index + 1, groups, A, results);
                groups[i] -= A[index];
            }
            groups.Add(A[index]);
            EnumeratePartitions(index + 1, groups, A, results);
            groups.RemoveAt(groups.Count - 1);
        }
    }
}
