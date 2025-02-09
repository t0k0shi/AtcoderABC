using System;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = input[0];
            int M = input[1];
            char[][] S = new char[N][];
            char[][] T = new char[M][];

            for (int i = 0; i < N; i++)
            {
                S[i] = Console.ReadLine().ToCharArray();
            }

            for (int i = 0; i < M; i++)
            {
                T[i] = Console.ReadLine().ToCharArray();
            }

            for (int a = 0; a <= N - M; a++)
            {
                for (int b = 0; b <= N - M; b++)
                {
                    if (IsSubGridMatch(S, T, a, b, M))
                    {
                        Console.WriteLine($"{a + 1} {b + 1}");
                        return;
                    }
                }
            }
        }

        static bool IsSubGridMatch(char[][] S, char[][] T, int a, int b, int M)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (S[a + i][b + j] != T[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
