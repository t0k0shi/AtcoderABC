using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);
            string S = Console.ReadLine();

            int maxStrawberries = 0;

            for (int i = 0; i <= N - K; i++)
            {
                bool canEat = true;
                for (int j = 0; j < K; j++)
                {
                    if (S[i + j] == 'X')
                    {
                        canEat = false;
                        break;
                    }
                }
                if (canEat)
                {
                    maxStrawberries++;
                    i += K - 1;
                }
            }

            Console.WriteLine(maxStrawberries);
        }
    }

}