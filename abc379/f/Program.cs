using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');
            int N = int.Parse(firstLine[0]);
            int Q = int.Parse(firstLine[1]);
            var H = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] left = new int[N];
            Stack<int> stack = new Stack<int>();
            for(int k =0; k < N; k++)
            {
                while(stack.Count >0 && H[stack.Peek()] < H[k])
                {
                    stack.Pop();
                }
                left[k] = stack.Count >0 ? stack.Peek() +1 : 0;
                stack.Push(k);
            }
            var queries = new Query[Q];
            for(int i=0; i<Q; i++)
            {
                var q = Console.ReadLine().Split(' ');
                queries[i] = new Query { l = int.Parse(q[0]), r = int.Parse(q[1]), index = i };
            }
            Array.Sort(queries, (a, b) => a.l.CompareTo(b.l));
            var sortedK = Enumerable.Range(1, N).Select(k => new { k, leftK = left[k-1] }).OrderBy(x => x.leftK).ToArray();
            BIT bit = new BIT(N);
            int currentK =0;
            int QSorted = Q;
            int[] answers = new int[Q];
            for(int i=0; i<Q; i++)
            {
                int currentL = queries[i].l;
                while(currentK < N && sortedK[currentK].leftK <= currentL)
                {
                    bit.Update(sortedK[currentK].k);
                    currentK++;
                }
                answers[queries[i].index] = bit.Query(N) - bit.Query(queries[i].r);
            }
            foreach(var ans in answers)
            {
                Console.WriteLine(ans);
            }
        }
    }

    class Query
    {
        public int l;
        public int r;
        public int index;
    }

    class BIT
    {
        private int[] tree;
        private int size;
        public BIT(int n)
        {
            size = n +1;
            tree = new int[size];
        }
        public void Update(int idx, int val=1)
        {
            while(idx < size)
            {
                tree[idx] += val;
                idx += idx & -idx;
            }
        }
        public int Query(int idx)
        {
            int res =0;
            while(idx >0)
            {
                res += tree[idx];
                idx -= idx & -idx;
            }
            return res;
        }
    }
}
