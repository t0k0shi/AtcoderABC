using System;
using System.Collections.Generic;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            
            HashSet<int> aSet = new HashSet<int>(A);
            List<int> missingNumbers = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                if (!aSet.Contains(i))
                {
                    missingNumbers.Add(i);
                }
            }

            Console.WriteLine(missingNumbers.Count);
            if (missingNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", missingNumbers));
            }
        }
    }
}
