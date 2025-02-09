using System;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int A1 = int.Parse(input[0]);
            int A2 = int.Parse(input[1]);
            int A3 = int.Parse(input[2]);

            bool isPossible = (A1 * A2 == A3) || (A1 * A3 == A2) || (A2 * A3 == A1);

            Console.WriteLine(isPossible ? "Yes" : "No");

        }
    }
}
