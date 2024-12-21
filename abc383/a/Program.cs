using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] T = new int[N];
        int[] V = new int[N];

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            T[i] = int.Parse(input[0]);
            V[i] = int.Parse(input[1]);
        }

        int currentWater = 0;
        int currentTime = 0;

        for (int i = 0; i < N; i++)
        {
            // 水が減る分を計算
            currentWater -= (T[i] - currentTime);
            if (currentWater < 0)
            {
                currentWater = 0;
            }

            // 水を追加
            currentWater += V[i];
            currentTime = T[i];
        }

        Console.WriteLine(currentWater);
    }
}
