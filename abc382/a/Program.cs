using System;
using System.Collections.Generic;

class Program
{
    static List<List<long>> sequences = new List<List<long>>();
    static long N, M;

    static void Main()
    {
        var input = Console.ReadLine().Split();
        N = long.Parse(input[0]);
        M = long.Parse(input[1]);

        // 開始位置での最大値を計算
        long maxA1 = M - (N - 1) * 10;
        for (long A1 = 1; A1 <= maxA1; A1++)
        {
            List<long> sequence = new List<long> { A1 };
            DFS(2, A1, sequence);
        }

        Console.WriteLine(sequences.Count);
        foreach (var seq in sequences)
        {
            Console.WriteLine(string.Join(" ", seq));
        }
    }

    static void DFS(int pos, long prevA, List<long> sequence)
    {
        if (pos > N)
        {
            if (sequence[sequence.Count - 1] <= M)
            {
                sequences.Add(new List<long>(sequence));
            }
            return;
        }

        long minAi = prevA + 10;
        long maxAi = M - (N - pos) * 10;

        if (minAi > maxAi)
        {
            return;
        }

        for (long Ai = minAi; Ai <= maxAi; Ai++)
        {
            sequence.Add(Ai);
            DFS(pos + 1, Ai, sequence);
            sequence.RemoveAt(sequence.Count - 1);
        }
    }
}
