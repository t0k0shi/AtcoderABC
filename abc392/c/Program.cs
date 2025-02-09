using System;
using System.Collections.Generic;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] P = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] Q = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int[] bibToPerson = new int[N + 1];
            for (int i = 0; i < N; i++)
            {
                int bibNumber = Q[i];
                bibToPerson[bibNumber] = i + 1; 
            }

            int[] S = new int[N];

            for (int i = 1; i <= N; i++)
            {
                int personWearingBibI = bibToPerson[i];
                int personBeingWatched = P[personWearingBibI - 1];
                int bibNumberOfPersonBeingWatched = Q[personBeingWatched - 1];
                S[i - 1] = bibNumberOfPersonBeingWatched;
            }

            Console.WriteLine(string.Join(" ", S));
        }
    }
}
