using System;

class Program
{
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        int N = int.Parse(nm[0]);
        int M = int.Parse(nm[1]);

        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] B = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        var A_list = new (int A_i, int personIndex)[N];
        for (int i = 0; i < N; i++)
        {
            A_list[i] = (A[i], i + 1);
        }

        Array.Sort(A_list, (x, y) => x.A_i.CompareTo(y.A_i));

        int[] minPersonIndex = new int[N];
        minPersonIndex[0] = A_list[0].personIndex;
        for (int i = 1; i < N; i++)
        {
            minPersonIndex[i] = Math.Min(minPersonIndex[i - 1], A_list[i].personIndex);
        }

        for (int i = 0; i < M; i++)
        {
            int B_j = B[i];
            int left = 0;
            int right = N;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (A_list[mid].A_i <= B_j)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            if (left == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(minPersonIndex[left - 1]);
            }
        }
    }
}
