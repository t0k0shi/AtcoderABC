using System;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hw = Console.ReadLine().Split();
            int H = int.Parse(hw[0]);
            int W = int.Parse(hw[1]);
            string[] S = new string[H];
            for (int i = 0; i < H; i++)
            {
                S[i] = Console.ReadLine();
            }
            int minR = H, maxR = -1;
            int minC = W, maxC = -1;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (S[i][j] == '#')
                    {
                        if (i < minR) minR = i;
                        if (i > maxR) maxR = i;
                        if (j < minC) minC = j;
                        if (j > maxC) maxC = j;
                    }
                }
            }
            for (int i = minR; i <= maxR; i++)
            {
                for (int j = minC; j <= maxC; j++)
                {
                    if (S[i][j] == '.')
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
