using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var line1 = Console.ReadLine().Split(' ');
        int N = int.Parse(line1[0]);
        long S = long.Parse(line1[1]);
        var A = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

        long sumCycle = 0;
        for (int i = 0; i < N; i++)
        {
            sumCycle += A[i];
        }

        if (sumCycle == S)
        {
            Console.WriteLine("Yes");
            return;
        }
        else if (sumCycle > S)
        {
            // S 以下の場合は、単一周期内でSに等しい部分和があるか確認
            if (CheckSubsequenceSum(A, S))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            return;
        }
        else
        {
            // sumCycle < S の場合
            long q = S / sumCycle;
            long r = S % sumCycle;

            if (r == 0)
            {
                // q回分のフルサイクルでSが表現可能
                if (q >= 1)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                // r > 0の場合、部分和rが単一周期中に存在すればq回のフルサイクルと組み合わせて実現可能
                if (CheckSubsequenceSum(A, r))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }

    static bool CheckSubsequenceSum(long[] A, long target)
    {
        int N = A.Length;
        var B = new long[2*N];
        for (int i = 0; i < N; i++)
        {
            B[i] = A[i];
            B[i+N] = A[i];
        }
        long currentSum = 0;
        int left = 0;
        for (int right = 0; right < 2*N; right++)
        {
            currentSum += B[right];
            while (currentSum > target && left <= right)
            {
                currentSum -= B[left];
                left++;
            }
            if (currentSum == target && right - left + 1 > 0)
            {
                return true;
            }
            if (left == N) break; 
        }
        return false;
    }
}
