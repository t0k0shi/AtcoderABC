using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int N = int.Parse(firstLine[0]);
        int W = int.Parse(firstLine[1]);

        var X = new int[N];
        var Y = new long[N];
        var blocks = new List<(long y, int index)>[W + 1];
        for (int i = 1; i <= W; i++)
        {
            blocks[i] = new List<(long y, int index)>();
        }

        for (int i = 0; i < N; i++)
        {
            string[] line = Console.ReadLine().Split();
            X[i] = int.Parse(line[0]);
            Y[i] = long.Parse(line[1]);
            blocks[X[i]].Add((Y[i], i));
        }

        int[] cnt = new int[N];
        long[] disappear = new long[N + 1];
        Array.Fill(disappear, long.MinValue);

        for (int x = 1; x <= W; x++)
        {
            blocks[x].Sort((a, b) => a.y.CompareTo(b.y));
            for (int j = 0; j < blocks[x].Count; j++)
            {
                cnt[blocks[x][j].index] = j;
                disappear[j] = Math.Max(disappear[j], blocks[x][j].y);
            }
            disappear[blocks[x].Count] = long.MaxValue / 2;
        }

        for (int i = 0; i < N; i++)
        {
            disappear[i + 1] = Math.Max(disappear[i + 1], disappear[i] + 1);
        }

        int Q = int.Parse(Console.ReadLine());
        string[] results = new string[Q];
        for (int i = 0; i < Q; i++)
        {
            string[] line = Console.ReadLine().Split();
            long T = long.Parse(line[0]);
            int A = int.Parse(line[1]) - 1;
            results[i] = (T < disappear[cnt[A]]) ? "Yes" : "No";
        }

        Console.WriteLine(string.Join("\n", results));
    }
}
