using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var hwx = Console.ReadLine().Split(' ');
        int H = int.Parse(hwx[0]);
        int W = int.Parse(hwx[1]);
        long X = long.Parse(hwx[2]);
        var pq = Console.ReadLine().Split(' ');
        int P = int.Parse(pq[0]) - 1;
        int Q = int.Parse(pq[1]) - 1;
        var S = new long[H][];
        for (int i = 0; i < H; i++)
        {
            S[i] = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        long T = S[P][Q];
        var visited = new bool[H, W];
        visited[P, Q] = true;
        var dirs = new int[][] { new int[]{1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1} };
        var pq2 = new SimplePriorityQueue();

        for (int i = 0; i < 4; i++)
        {
            int np = P + dirs[i][0];
            int nq = Q + dirs[i][1];
            if (np < 0 || np >= H || nq < 0 || nq >= W) continue;
            if (!visited[np, nq])
            {
                pq2.Push(S[np][nq], np, nq);
            }
        }

        while (pq2.Count > 0)
        {
            var top = pq2.Peek();
            long val = top.Item1;
            int rr = top.Item2;
            int cc = top.Item3;

            if (CanAbsorb(val, T, X))
            {
                pq2.Pop();
                if (visited[rr, cc]) continue;
                visited[rr, cc] = true;
                T += val;
                for (int i = 0; i < 4; i++)
                {
                    int np = rr + dirs[i][0];
                    int nq = cc + dirs[i][1];
                    if (np < 0 || np >= H || nq < 0 || nq >= W) continue;
                    if (!visited[np, nq])
                    {
                        pq2.Push(S[np][nq], np, nq);
                    }
                }
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(T);
    }

    static bool CanAbsorb(long val, long T, long X)
    {
        long q = T / X;
        long r = T % X;
        if (r > 0)
        {
            return val <= q; 
        }
        else
        {
            return val < q;
        }
    }
}

class SimplePriorityQueue
{
    List<(long, int, int)> heap = new List<(long, int, int)>();
    public int Count { get { return heap.Count; } }
    public void Push(long v, int r, int c)
    {
        heap.Add((v, r, c));
        int i = Count - 1;
        while (i > 0)
        {
            int p = (i - 1) / 2;
            if (heap[p].Item1 <= heap[i].Item1) break;
            var tmp = heap[i];
            heap[i] = heap[p];
            heap[p] = tmp;
            i = p;
        }
    }
    public (long, int, int) Peek()
    {
        return heap[0];
    }
    public (long, int, int) Pop()
    {
        var ret = heap[0];
        heap[0] = heap[Count - 1];
        heap.RemoveAt(Count - 1);
        int i = 0;
        while (true)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;
            if (left >= Count) break;
            int nxt = left;
            if (right < Count && heap[right].Item1 < heap[left].Item1) nxt = right;
            if (heap[nxt].Item1 >= heap[i].Item1) break;
            var tmp = heap[i];
            heap[i] = heap[nxt];
            heap[nxt] = tmp;
            i = nxt;
        }
        return ret;
    }
}
