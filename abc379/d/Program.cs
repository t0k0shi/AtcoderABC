using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int Q = int.Parse(Console.ReadLine());
            List<long> plantTimes = new List<long>();
            long currentTime = 0;
            int harvestIndex = 0;
            List<int> results = new List<int>();
            for (int q = 0; q < Q; q++)
            {
                var input = Console.ReadLine().Split(' ');
                if (input[0] == "1")
                {
                    plantTimes.Add(currentTime);
                }
                else if (input[0] == "2")
                {
                    long T = long.Parse(input[1]);
                    currentTime += T;
                }
                else if (input[0] == "3")
                {
                    long H = long.Parse(input[1]);
                    long threshold = currentTime - H;
                    int left = harvestIndex;
                    int right = plantTimes.Count;
                    while (left < right)
                    {
                        int mid = left + (right - left) / 2;
                        if (plantTimes[mid] <= threshold)
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid;
                        }
                    }
                    int harvested = left - harvestIndex;
                    results.Add(harvested);
                    harvestIndex = left;
                }
            }
            foreach (var res in results)
            {
                Console.WriteLine(res);
            }
        }
    }
}
