using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
class Program
{
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int a = N / 100;
            int b = (N / 10) % 10;
            int c = N % 10;

            int bca = b * 100 + c * 10 + a;
            int cab = c * 100 + a * 10 + b;

            Console.WriteLine($"{bca} {cab}");
        }
    }
}
